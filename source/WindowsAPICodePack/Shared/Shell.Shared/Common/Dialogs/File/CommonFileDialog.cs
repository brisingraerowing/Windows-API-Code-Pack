//Copyright (c) Microsoft Corporation.  All rights reserved.  Distributed under the Microsoft Public License (MS-PL)

#region Usings
#region WAPICP
using Microsoft.WindowsAPICodePack.COMNative.Dialogs;
using Microsoft.WindowsAPICodePack.COMNative.Shell;
using Microsoft.WindowsAPICodePack.Controls;
using Microsoft.WindowsAPICodePack.Dialogs.Controls;
using Microsoft.WindowsAPICodePack.Shell;
using Microsoft.WindowsAPICodePack.Shell.Resources;
using Microsoft.WindowsAPICodePack.Win32Native.Shell;
using Microsoft.WindowsAPICodePack.Win32Native;
#endregion WAPICP

#region System
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Markup;
#endregion System

using WinCopies.Util;

using static Microsoft.WindowsAPICodePack.Shell.Resources.LocalizedMessages;

using static WinCopies.
#if WAPICP3
    ThrowHelper
#else
    Util.Util
#endif
    ;
#endregion

namespace Microsoft.WindowsAPICodePack.Dialogs
{
    /// <summary>
    /// Defines the abstract base class for the common file dialogs.
    /// </summary>
    [ContentProperty("Controls")]
    public abstract class CommonFileDialog : IDialogControlHost, System.IDisposable
    {
        #region Fields
        private ushort _bools = 0b111;
        private readonly Collection<string> filenames;
        internal readonly Collection<IShellItem> items;
        internal DialogShowState showState = DialogShowState.PreShow;
        private IFileDialog nativeDialog;
        private IFileDialogCustomize customize;
        private NativeDialogEventSink nativeEventSink;
        private IntPtr parentWindow = IntPtr.Zero;
        private string title;
        // Null = use default identifier.
        private Guid cookieIdentifier;
        private bool? canceled;
        #endregion Fields

        private bool ResetSelections { get => GetBit(7); set => SetBit(7, value); }
        private bool FilterSet { get => GetBit(10); set => SetBit(10, value); } // filters can only be set once

        /// <summary>
        /// The collection of names selected by the user.
        /// </summary>
        protected
#if CS6
            IReadOnlyList
#else
            ReadOnlyCollection
#endif
            <string> FileNameCollection
        { get; }

        #region Constructors
        /// <summary>
        /// Creates a new instance of this class.
        /// </summary>
        protected CommonFileDialog()
        {
            if (!CoreHelpers.RunningOnVista)

                throw new PlatformNotSupportedException(CommonFileDialogRequiresVista);

            FileNameCollection = new ReadOnlyCollection<string>(filenames = new Collection<string>());
            Filters = new CommonFileDialogFilterCollection();
            items = new Collection<IShellItem>();
            Controls = new CommonFileDialogControlCollection<CommonFileDialogControl>(this);
        }

        /// <summary>
        /// Creates a new instance of this class with the specified title.
        /// </summary>
        /// <param name="title">The title to display in the dialog.</param>
        protected CommonFileDialog(string title) : this() => this.title = title;
        #endregion

        // Template method to allow derived dialog to create actual
        // specific COM coclass (e.g. FileOpenDialog or FileSaveDialog).
        internal abstract void InitializeNativeFileDialog();
        internal abstract IFileDialog GetNativeFileDialog();
        internal abstract void PopulateWithFileNames(in Collection<string> names);
        internal abstract void PopulateWithIShellItems(in Collection<IShellItem> shellItems);
        internal abstract void CleanUpNativeFileDialog();
        internal abstract FileOpenOptions GetDerivedOptionFlags(FileOpenOptions flags);

        #region Public API
        /// <summary>
        /// Gets the collection of controls for the dialog.
        /// </summary>
        public CommonFileDialogControlCollection<CommonFileDialogControl> Controls { get; }

        /// <summary>
        /// Gets the filters used by the dialog.
        /// </summary>
        public CommonFileDialogFilterCollection Filters { get; }

        /// <summary>
        /// Gets or sets the dialog title.
        /// </summary>
        public string Title
        {
            get => title;

            set
            {
                title = value;

                if (NativeDialogShowing)

                    nativeDialog.SetTitle(value);
            }
        }

        // This is the first of many properties that are backed by the FOS_*
        // bitflag options set with IFileDialog.SetOptions(). 
        // SetOptions() fails
        // if called while dialog is showing (e.g. from a callback).

        /// <summary>
        /// Gets or sets a value that determines whether the file must exist beforehand.
        /// </summary>
        /// <value>A <see cref="bool"/> value. <see langword="true"/> if the file must exist.</value>
        /// <exception cref="InvalidOperationException">This property cannot be set when the dialog is visible.</exception>
        public bool EnsureFileExists { get => GetBit(3); set => SetValue(3, value, EnsureFileExistsCannotBeChanged); }

        /// <summary>
        /// Gets or sets a value that specifies whether the returned file must be in an existing folder.
        /// </summary>
        /// <value>A <see cref="bool"/> value. <see langword="true"/> if the file must exist.</value>
        /// <exception cref="InvalidOperationException">This property cannot be set when the dialog is visible.</exception>
        public bool EnsurePathExists { get => GetBit(4); set => SetValue(4, value, EnsurePathExistsCannotBeChanged); }

        /// <summary>Gets or sets a value that determines whether to validate file names.
        /// </summary>
        ///<value>A <see cref="bool"/> value. <see langword="true"/> to check for situations that would prevent an application from opening the selected file, such as sharing violations or access denied errors.</value>
        /// <exception cref="InvalidOperationException">This property cannot be set when the dialog is visible.</exception>
        public bool EnsureValidNames { get => GetBit(5); set => SetValue(5, value, EnsureValidNamesCannotBeChanged); }

        /// <summary>
        /// Gets or sets a value that determines whether read-only items are returned.
        /// Default value for <see cref="CommonOpenFileDialog"/> is <see langword="true"/> (allow read-only files) and
        /// <see cref="CommonSaveFileDialog"/> is <see langword="false"/> (don't allow read-only files).
        /// </summary>
        /// <value>A <see cref="bool"/> value. <see langword="true"/> includes read-only items.</value>
        /// <exception cref="InvalidOperationException">This property cannot be set when the dialog is visible.</exception>
        public bool EnsureReadOnly { get => GetBit(6); set => SetValue(6, value, EnsureReadonlyCannotBeChanged); }

        /// <summary>
        /// Gets or sets a value that determines the restore directory.
        /// </summary>
        /// <exception cref="InvalidOperationException">This property cannot be set when the dialog is visible.</exception>
        public bool RestoreDirectory { get => GetBit(8); set => SetValue(8, value, RestoreDirectoryCannotBeChanged); }

        /// <summary>
        /// Gets or sets a value that controls whether
        /// to show or hide the list of pinned places that
        /// the user can choose.
        /// </summary>
        /// <value>A <see cref="bool"/> value. <see langword="true"/> if the list is visible; otherwise <see langword="false"/>.</value>
        /// <exception cref="InvalidOperationException">This property cannot be set when the dialog is visible.</exception>
        public bool ShowPlacesList { get => GetBit(0); set => SetValue(0, value, ShowPlacesListCannotBeChanged); }

        /// <summary>
        /// Gets or sets a value that controls whether to show or hide the list of places where the user has recently opened or saved items.
        /// </summary>
        /// <exception cref="InvalidOperationException">This property cannot be set when the dialog is visible.</exception>
        public bool AddToMostRecentlyUsedList { get => GetBit(1); set => SetValue(1, value, AddToMostRecentlyUsedListCannotBeChanged); }

        ///<summary>
        /// Gets or sets a value that controls whether to show hidden items.
        /// </summary>
        /// <value>A <see cref="bool"/> value. <see langword="true"/> to show the items; otherwise <see langword="false"/>.</value>
        /// <exception cref="InvalidOperationException">This property cannot be set when the dialog is visible.</exception>
        public bool ShowHiddenItems { get => GetBit(9); set => SetValue(9, value, ShowHiddenItemsCannotBeChanged); }

        /// <summary>
        /// Gets or sets a value that controls whether
        /// properties can be edited.
        /// </summary>
        public bool AllowPropertyEditing { get; set; }

        ///<summary>
        /// Gets or sets a value that controls whether shortcuts should be treated as their target items, allowing an application to open a .lnk file.
        /// </summary>
        /// <value>A <see cref="bool"/> value. <see langword="true"/> indicates that shortcuts should be treated as their targets. </value>
        /// <exception cref="InvalidOperationException">This property cannot be set when the dialog is visible.</exception>
        public bool NavigateToShortcut { get => GetBit(2); set => SetValue(2, value, NavigateToShortcutCannotBeChanged); }

        /// <summary>
        /// Gets or sets the default file extension to be added to file names. If the value is null
        /// or string.Empty, the extension is not added to the file names.
        /// </summary>
        public string DefaultExtension { get; set; }

        /// <summary>
        /// Gets the index for the currently selected file type.
        /// </summary>
        public int SelectedFileTypeIndex
        {
            get
            {
                if (nativeDialog == null)

                    return -1;

                nativeDialog.GetFileTypeIndex(out uint fileType);

                return (int)fileType;
            }
        }

        // Null = use default directory.

        /// <summary>
        /// Gets or sets the initial directory displayed when the dialog is shown. 
        /// A null or empty string indicates that the dialog is using the default directory.
        /// </summary>
        /// <value>A <see cref="string"/> object.</value>
        public string InitialDirectory { get; set; }

        /// <summary>
        /// Gets or sets a location that is always selected when the dialog is opened, 
        /// regardless of previous user action. A null value implies that the dialog is using 
        /// the default location.
        /// </summary>
        public ShellContainer InitialDirectoryShellContainer { get; set; }

        /// <summary>
        /// Sets the folder and path used as a default if there is not a recently used folder value available.
        /// </summary>
        public string DefaultDirectory { get; set; }

        /// <summary>
        /// Sets the location (<see cref="Microsoft.WindowsAPICodePack.Shell.ShellContainer">ShellContainer</see> 
        /// used as a default if there is not a recently used folder value available.
        /// </summary>
        public ShellContainer DefaultDirectoryShellContainer { get; set; }

        /// <summary>
        /// Gets or sets a value that enables a calling application 
        /// to associate a GUID with a dialog's persisted state.
        /// </summary>
        public Guid CookieIdentifier { get => cookieIdentifier; set => cookieIdentifier = value; }

        /// <summary>
        /// Default file name.
        /// </summary>
        public string DefaultFileName { get; set; }

        /// <summary>
        /// Gets the selected filename.
        /// </summary>
        /// <exception cref="InvalidOperationException">This property cannot be used when multiple files are selected.</exception>
        public string FileName
        {
            get
            {
                CheckFileNamesAvailable();

                string returnFilename = filenames.Count > 1 ? throw new InvalidOperationException(CommonFileDialogMultipleFiles) : filenames[0];

                // "If extension is a null reference (Nothing in Visual 
                // Basic), the returned string contains the specified 
                // path with its extension removed."  Since we do not want 
                // to remove any existing extension, make sure the 
                // DefaultExtension property is NOT null.

                // if we should, and there is one to set...
                return string.IsNullOrEmpty(DefaultExtension) ? returnFilename : System.IO.Path.ChangeExtension(returnFilename, DefaultExtension);
            }
        }

        /// <summary>
        /// Gets the selected item as a <see cref="ShellObject"/>.
        /// </summary>
        /// <exception cref="InvalidOperationException">This property cannot be used when multiple files
        /// are selected.</exception>
        public ShellObject FileAsShellObject
        {
            get
            {
                CheckFileItemsAvailable();

                return items.Count > 1
                    ? throw new InvalidOperationException(CommonFileDialogMultipleItems)
                    : items.Count == 0 ? null : ShellObjectFactory.Create(items[0]);
            }
        }

        // Events.
        /// <summary>
        /// Raised just before the dialog is about to return with a result. Occurs when the user clicks on the Open 
        /// or Save button on a file dialog box. 
        /// </summary>
        public event CancelEventHandler FileOk;
        /// <summary>
        /// Raised just before the user navigates to a new folder.
        /// </summary>
        public event System.EventHandler<CommonFileDialogFolderChangeEventArgs> FolderChanging;
        /// <summary>
        /// Raised when the user navigates to a new folder.
        /// </summary>
        public event EventHandler FolderChanged;
        /// <summary>
        /// Raised when the user changes the selection in the dialog's view.
        /// </summary>
        public event EventHandler SelectionChanged;
        /// <summary>
        /// Raised when the dialog is opened to notify the application of the initial chosen filetype.
        /// </summary>
        public event EventHandler FileTypeChanged;
        /// <summary>
        /// Raised when the dialog is opening.
        /// </summary>
        public event EventHandler DialogOpening;

        /// <summary>
        /// Adds a location, such as a folder, library, search connector, or known folder, to the list of
        /// places available for a user to open or save items. This method actually adds an item
        /// to the <b>Favorite Links</b> or <b>Places</b> section of the Open/Save dialog.
        /// </summary>
        /// <param name="place">The item to add to the places list.</param>
        /// <param name="location">One of the enumeration values that indicates placement of the item in the list.</param>
        public void AddPlace(ShellContainer place, FileDialogAddPlaceLocation location)
        {
            // Get our native dialog
            if (place == null ? throw new ArgumentNullException(nameof(place)) : nativeDialog == null)
            {
                InitializeNativeFileDialog();
                nativeDialog = GetNativeFileDialog();
            }

            // Add the shellitem to the places list
            else

                nativeDialog.AddPlace(place.NativeShellItem, (FileDialogAddPlacement)location);
        }

        /// <summary>
        /// Adds a location (folder, library, search connector, known folder) to the list of
        /// places available for the user to open or save items. This method actually adds an item
        /// to the <b>Favorite Links</b> or <b>Places</b> section of the Open/Save dialog. Overload method
        /// takes in a string for the path.
        /// </summary>
        /// <param name="path">The item to add to the places list.</param>
        /// <param name="location">One of the enumeration values that indicates placement of the item in the list.</param>
        public void AddPlace(string path, FileDialogAddPlaceLocation location)
        {
            // Get our native dialog
            if (string.IsNullOrEmpty(path) ? throw new ArgumentNullException(nameof(path)) : nativeDialog == null)
            {
                InitializeNativeFileDialog();
                nativeDialog = GetNativeFileDialog();
            }

            // Create a native shellitem from our path
            var guid = new Guid(NativeAPI.Guids.Shell.IShellItem2);
            HResult retCode =
#if !WAPICP3
                (HResult)
#endif
                COMNative.Shell.Shell.SHCreateItemFromParsingName(path, IntPtr.Zero, ref guid, out IShellItem2 nativeShellItem);

            // Add the shellitem to the places list

            (CoreErrorHelper.Succeeded(retCode) ? nativeDialog : throw new CommonControlException(CommonFileDialogCannotCreateShellItem, CoreErrorHelper.GetExceptionForHR(retCode)))?.AddPlace(nativeShellItem, (FileDialogAddPlacement)location);
        }

        /// <summary>
        /// Displays the dialog.
        /// </summary>
        /// <param name="ownerWindowHandle">Window handle of any top-level window that will own the modal dialog box.</param>
        /// <returns>A <see cref="CommonFileDialogResult"/> object.</returns>
        public CommonFileDialogResult ShowDialog(IntPtr ownerWindowHandle)
        {
            // Set the parent / owner window
            parentWindow = ownerWindowHandle == IntPtr.Zero ? throw new ArgumentException(CommonFileDialogInvalidHandle, nameof(ownerWindowHandle)) : ownerWindowHandle;

            // Show the modal dialog
            return ShowDialog();
        }

        /// <summary>
        /// Displays the dialog.
        /// </summary>
        /// <param name="window">Top-level WPF window that will own the modal dialog box.</param>
        /// <returns>A <see cref="CommonFileDialogResult"/> object.</returns>
        public CommonFileDialogResult ShowDialog(System.Windows.Window window)
        {
            // Set the parent / owner window
            parentWindow = new WindowInteropHelper(window ?? throw GetArgumentNullException(nameof(window))).Handle;

            // Show the modal dialog
            return ShowDialog();
        }

        /// <summary>
        /// Displays the dialog.
        /// </summary>
        /// <returns>A <see cref="CommonFileDialogResult"/> object.</returns>
        public CommonFileDialogResult ShowDialog()
        {
            CommonFileDialogResult result;

            // Fetch derived native dialog (i.e. Save or Open).
            InitializeNativeFileDialog();
            nativeDialog = GetNativeFileDialog();

            // Apply outer properties to native dialog instance.
            ApplyNativeSettings(nativeDialog);
            InitializeEventSink(nativeDialog);

            // Clear user data if Reset has been called 
            // since the last show.
            if (ResetSelections)

                ResetSelections = false;

            // Show dialog.
            showState = DialogShowState.Showing;
            int hresult = nativeDialog.Show(parentWindow);
            showState = DialogShowState.Closed;

            // Create return information.
            if (CoreErrorHelper.Matches(hresult, (int)HResult.Win32ErrorCanceled))
            {
                canceled = true;
                result = CommonFileDialogResult.Cancel;
                filenames.Clear();
            }

            else
            {
                canceled = false;
                result = CommonFileDialogResult.Ok;

                // Populate filenames if user didn't cancel.
                PopulateWithFileNames(filenames);

                // Populate the actual IShellItems
                PopulateWithIShellItems(items);
            }

            return result;
        }

        /// <summary>
        /// Removes the current selection.
        /// </summary>
        public void ResetUserSelections() => ResetSelections = true;
        #endregion

        #region Configuration
        private void InitializeEventSink(IFileDialog nativeDlg)
        {
            // Check if we even need to have a sink.
            if (WinCopies.Diagnostics.Determine.OneOrMoreNotNull(FileOk, FolderChanging, FolderChanged, SelectionChanged, FileTypeChanged, DialogOpening) || (Controls != null && Controls.Count > 0))
            {
                nativeEventSink = new NativeDialogEventSink(this);
                nativeDlg.Advise(nativeEventSink, out uint cookie);
                nativeEventSink.Cookie = cookie;
            }
        }

        private void ApplyNativeSettings(IFileDialog dialog)
        {
            Debug.Assert(dialog != null, "No dialog instance to configure");

            if (parentWindow == IntPtr.Zero)

                if (Application.Current != null && Application.Current.MainWindow != null)

                    parentWindow = new WindowInteropHelper(Application.Current.MainWindow).Handle;

                else if (System.Windows.Forms.Application.OpenForms.Count > 0)

                    parentWindow = System.Windows.Forms.Application.OpenForms[0].Handle;

            var guid = new Guid(NativeAPI.Guids.Shell.IShellItem2);

            // Apply option bitflags.
            dialog.SetOptions(CalculateNativeDialogOptionFlags());

            // Other property sets.
            if (title != null) dialog.SetTitle(title);

            if (InitialDirectoryShellContainer != null)

                dialog.SetFolder(InitialDirectoryShellContainer.NativeShellItem);

            if (DefaultDirectoryShellContainer != null)

                dialog.SetDefaultFolder(DefaultDirectoryShellContainer.NativeShellItem);

            if (!string.IsNullOrEmpty(InitialDirectory))
            {
                // Create a native shellitem from our path
                _ = COMNative.Shell.Shell.SHCreateItemFromParsingName(InitialDirectory, IntPtr.Zero, ref guid, out IShellItem2 initialDirectoryShellItem);

                // If we get a real shell item back, 
                // then use that as the initial folder - otherwise,
                // we'll allow the dialog to revert to the default folder. 
                // (OR should we fail loudly?)
                if (initialDirectoryShellItem != null)
                    dialog.SetFolder(initialDirectoryShellItem);
            }

            if (!string.IsNullOrEmpty(DefaultDirectory))
            {
                // Create a native shellitem from our path
                _ = COMNative.Shell.Shell.SHCreateItemFromParsingName(DefaultDirectory, IntPtr.Zero, ref guid, out IShellItem2 defaultDirectoryShellItem);

                // If we get a real shell item back, 
                // then use that as the initial folder - otherwise,
                // we'll allow the dialog to revert to the default folder. 
                // (OR should we fail loudly?)
                if (defaultDirectoryShellItem != null)

                    dialog.SetDefaultFolder(defaultDirectoryShellItem);
            }

            // Apply file type filters, if available.
            if (Filters.Count > 0 && !FilterSet)
            {
                dialog.SetFileTypes(
                    (uint)Filters.Count,
                    Filters.GetAllFilterSpecs());

                FilterSet = true;

                SyncFileTypeComboToDefaultExtension(dialog);
            }

            if (cookieIdentifier != Guid.Empty)

                dialog.SetClientGuid(ref cookieIdentifier);

            // Set the default extension
            if (!string.IsNullOrEmpty(DefaultExtension))

                dialog.SetDefaultExtension(DefaultExtension);

            // Set the default filename
            dialog.SetFileName(DefaultFileName);
        }

        private FileOpenOptions CalculateNativeDialogOptionFlags()
        {
            // We start with only a few flags set by default, 
            // then go from there based on the current state
            // of the managed dialog's property values.
            FileOpenOptions flags = FileOpenOptions.NoTestFileCreate;

            // Call to derived (concrete) dialog to 
            // set dialog-specific flags.
            flags = GetDerivedOptionFlags(flags);

            // Apply other optional flags.
            if (EnsureFileExists)

                flags |= FileOpenOptions.FileMustExist;

            if (EnsurePathExists)

                flags |= FileOpenOptions.PathMustExist;

            if (!EnsureValidNames)

                flags |= FileOpenOptions.NoValidate;

            if (!EnsureReadOnly)

                flags |= FileOpenOptions.NoReadOnlyReturn;

            if (RestoreDirectory)

                flags |= FileOpenOptions.NoChangeDirectory;

            if (!ShowPlacesList)

                flags |= FileOpenOptions.HidePinnedPlaces;

            if (!AddToMostRecentlyUsedList)

                flags |= FileOpenOptions.DontAddToRecent;

            if (ShowHiddenItems)

                flags |= FileOpenOptions.ForceShowHidden;

            if (!NavigateToShortcut)

                flags |= FileOpenOptions.NoDereferenceLinks;

            return flags;
        }
        #endregion

        #region IDialogControlHost Members
        private static void GenerateNotImplementedException() => throw new NotImplementedException(LocalizedMessages.NotImplementedException);

        /// <summary>
        /// Returns if change to the colleciton is allowed.
        /// </summary>
        /// <returns>true if collection change is allowed.</returns>
        public virtual bool IsCollectionChangeAllowed() => true;

        /// <summary>
        /// Applies changes to the collection.
        /// </summary>
        public virtual void ApplyCollectionChanged()
        {
            // Query IFileDialogCustomize interface before adding controls
            GetCustomizedFileDialog();
            // Populate all the custom controls and add them to the dialog
            foreach (CommonFileDialogControl control in Controls)

                if (!control.IsAdded)
                {
                    control.HostingDialog = this;
                    control.Attach(customize);
                    control.IsAdded = true;
                }
        }

        /// <summary>
        /// Determines if changes to a specific property are allowed.
        /// </summary>
        /// <param name="propertyName">The name of the property.</param>
        /// <param name="control">The control propertyName applies to.</param>
        /// <returns>true if the property change is allowed.</returns>
        public virtual bool IsControlPropertyChangeAllowed(
#if !WAPICP3
            in
#endif
            string propertyName,
#if !WAPICP3
            in
#endif
            DialogControl control)
        {
            GenerateNotImplementedException();
            return false;
        }

        /// <summary>
        /// Called when a control currently in the collection 
        /// has a property changed.
        /// </summary>
        /// <param name="propertyName">The name of the property changed.</param>
        /// <param name="control">The control whose property has changed.</param>
        public virtual void ApplyControlPropertyChange(
#if !WAPICP3
            in
#endif
            string propertyName,
#if !WAPICP3
            in
#endif
            DialogControl control)
        {
            ThrowIfNull(control, nameof(control));

            bool isNotNull(
#if !WAPICP3
                in DialogControl _control,
#endif
                out CommonFileDialogControl
#if CS8
                ?
#endif
                dialogControl) => (dialogControl =
#if WAPICP3
                control
#else
                _control
#endif
                as CommonFileDialogControl) != null;

            if (propertyName == nameof(CommonFileDialogControl.Text))
            {
                if (control is CommonFileDialogTextBox textBox)

                    customize.SetEditBoxText(control.Id, textBox.Text);

                else if (isNotNull(
#if !WAPICP3
                    control,
#endif
                    out CommonFileDialogControl
#if CS8
                    ?
#endif
                    dialogControl))
                {
                    string
#if CS8
                        ?
#endif
                        text = dialogControl.Text;

                    if (text != null)

                        customize.SetControlLabel(control.Id, text);
                }
            }

            else
            {
                bool trySetControlState(
#if !WAPICP3
                    in DialogControl _control, in string __propertyName,
#endif
                    in string _propertyName, in Converter<CommonFileDialogControl, bool> converter, in ControlState controlState)
                {
                    if (
#if WAPICP3
                        propertyName
#else
                        __propertyName
#endif
                        == _propertyName && isNotNull(
#if !WAPICP3
                            _control,
#endif
                            out CommonFileDialogControl
#if CS8
                    ?
#endif
                dialogControl))
                    {
                        customize.GetControlState(
#if WAPICP3
                            control
#else
                            _control
#endif
                            .Id, out ControlState state);

                        if (converter(dialogControl))

                            state |= controlState;

                        else

                            state &= ~controlState;

                        customize.SetControlState(
#if WAPICP3
                            control
#else
                            _control
#endif
                            .Id, state);

                        return false;
                    }

                    return true;
                }

                if (trySetControlState(
#if !WAPICP3
                    control, propertyName,
#endif
                    nameof(CommonFileDialogControl.Visible), dialogControl => dialogControl.Visible, ControlState.Visible) && trySetControlState(
#if !WAPICP3
                    control, propertyName,
#endif
                    nameof(CommonFileDialogControl.Enabled), dialogControl => dialogControl.Enabled, ControlState.Enable))
                {
                    if (propertyName == nameof(CommonFileDialogRadioButtonList.SelectedIndex))
                    {
                        void setSelectedControlItem<T>(in T indexedControls) where T : DialogControl, ICommonFileDialogIndexedControls => customize.SetSelectedControlItem(indexedControls.Id, indexedControls.SelectedIndex);

                        if (control is CommonFileDialogRadioButtonList list)

                            setSelectedControlItem(list);

                        else if (control is CommonFileDialogComboBox box)

                            setSelectedControlItem(box);
                    }

                    else if (propertyName == nameof(CommonFileDialogCheckBox.IsChecked) && control is CommonFileDialogCheckBox checkBox)

                        customize.SetCheckButtonState(checkBox.Id, checkBox.IsChecked);
                }
            }
        }
        #endregion

        #region Helpers
        private bool GetBit(in byte pos) => _bools.GetBit(pos);
        private void SetBit(in byte pos, in bool value) => WinCopies.
#if WAPICP3
            UtilHelpers
#else
            Util.Util
#endif
            .SetBit(ref _bools, pos, value);

        private void SetValue(in Action action, in string exceptionMessage)
        {
            ThrowIfDialogShowing(exceptionMessage);

            action();
        }

        private void SetValue(byte pos, bool value, in string exceptionMessage) => SetValue(() => SetBit(pos, value), exceptionMessage);

        /// <summary>
        /// Tries to set the File(s) Type Combo to match the value in
        /// <see cref="DefaultExtension"/>. Only doing this if 'this' is a Save dialog
        /// as it makes no sense to do this if only Opening a file.
        /// </summary>
        /// <param name="dialog">The native/<see cref="IFileDialog"/> instance.</param>
        private void SyncFileTypeComboToDefaultExtension(IFileDialog dialog)
        {
            // make sure it's a Save dialog and that there is a default 
            // extension to sync to.
            if (
#if !CS9
                !(
#endif
                this is
#if CS9
                not
#endif
                CommonSaveFileDialog
#if !CS9
                )
#endif
                || DefaultExtension == null || Filters.Count <= 0)

                return;

            for (uint filtersCounter = 0; filtersCounter < Filters.Count; filtersCounter++)

                if (Filters[(int)filtersCounter].Extensions.Contains(DefaultExtension))
                {
                    // set the docType combo to match this 
                    // extension. property is a 1-based index.
                    dialog.SetFileTypeIndex(filtersCounter + 1);

                    // we're done, exit for
                    break;
                }
        }

        private void CheckFileCollectionAvailable(
#if DEBUG
            in ICollection items, in string propertyName
#endif
            )
        {
            if (showState != DialogShowState.Closed ? throw new InvalidOperationException(CommonFileDialogNotClosed) : canceled.GetValueOrDefault())

                throw new InvalidOperationException(CommonFileDialogCanceled);

#if DEBUG
            Debug.Assert(items.Count != 0,
              $"{propertyName} empty - shouldn't happen unless dialog canceled or not yet shown.");
#endif
        }

        /// <summary>
        /// Ensures that the user has selected one or more files.
        /// </summary>
        /// <permission cref="InvalidOperationException">
        /// The dialog has not been dismissed yet or the dialog was cancelled.
        /// </permission>
        protected void CheckFileNamesAvailable() => CheckFileCollectionAvailable(
#if DEBUG
            filenames, "FileNames"
#endif
            );

        /// <summary>
        /// Ensures that the user has selected one or more files.
        /// </summary>
        /// <permission cref="InvalidOperationException">
        /// The dialog has not been dismissed yet or the dialog was cancelled.
        /// </permission>
        protected void CheckFileItemsAvailable() => CheckFileCollectionAvailable(
#if DEBUG
            items, "Items list"
#endif
            );

        private bool NativeDialogShowing => (nativeDialog != null) && (showState == DialogShowState.Showing || showState == DialogShowState.Closing);

        internal static string
#if CS8
            ?
#endif
            GetFileNameFromShellItem(IShellItem item)
        {
            if (item.GetDisplayName(ShellItemDesignNameOptions.DesktopAbsoluteParsing, out IntPtr pszString) == HResult.Ok && pszString != IntPtr.Zero)
            {
                string
#if CS8
                    ?
#endif
                    filename = Marshal.PtrToStringAuto(pszString);

                Marshal.FreeCoTaskMem(pszString);

                return filename;
            }

            return null;
        }

        internal static IShellItem GetShellItemAt(IShellItemArray array, int i)
        {
            CoreErrorHelper.ThrowExceptionForHResult(array.GetItemAt((uint)i, out IShellItem result));

            return result;
        }

        /// <summary>
        /// Throws an exception when the dialog is showing preventing
        /// a requested change to a property or the visible set of controls.
        /// </summary>
        /// <param name="message">The message to include in the exception.</param>
        /// <permission cref="InvalidOperationException"> The dialog is in an
        /// invalid state to perform the requested operation.</permission>
        protected void ThrowIfDialogShowing(string message)
        {
            if (NativeDialogShowing)

                throw new InvalidOperationException(message);
        }

        /// <summary>
        /// Get the <see cref="IFileDialogCustomize"/> interface, preparing to add controls.
        /// </summary>
        private void GetCustomizedFileDialog()
        {
            if (customize == null)
            {
                if (nativeDialog == null)
                {
                    InitializeNativeFileDialog();
                    nativeDialog = GetNativeFileDialog();
                }

                customize = (IFileDialogCustomize)nativeDialog;
            }
        }
#endregion

#region CheckChanged handling members
        /// <summary>
        /// Raises the <see cref="FileOk"/> event just before the dialog is about to return with a result.
        /// </summary>
        /// <param name="e">The event data.</param>
        protected virtual void OnFileOk(CancelEventArgs e) => FileOk?.Invoke(this, e);

        /// <summary>
        /// Raises the <see cref="FolderChanging"/> to stop navigation to a particular location.
        /// </summary>
        /// <param name="e">Cancelable event arguments.</param>
        protected virtual void OnFolderChanging(CommonFileDialogFolderChangeEventArgs e) => FolderChanging?.Invoke(this, e);

        /// <summary>
        /// Raises the <see cref="FolderChanged"/> event when the user navigates to a new folder.
        /// </summary>
        /// <param name="e">The event data.</param>
        protected virtual void OnFolderChanged(EventArgs e) => FolderChanged?.Invoke(this, e);

        /// <summary>
        /// Raises the <see cref="SelectionChanged"/> event when the user changes the selection in the dialog's view.
        /// </summary>
        /// <param name="e">The event data.</param>
        protected virtual void OnSelectionChanged(EventArgs e) => SelectionChanged?.Invoke(this, e);

        /// <summary>
        /// Raises the <see cref="FileTypeChanged"/> event when the dialog is opened to notify the 
        /// application of the initial chosen filetype.
        /// </summary>
        /// <param name="e">The event data.</param>
        protected virtual void OnFileTypeChanged(EventArgs e) => FileTypeChanged?.Invoke(this, e);

        /// <summary>
        /// Raises the <see cref="DialogOpening"/> event when the dialog is opened.
        /// </summary>
        /// <param name="e">The event data.</param>
        protected virtual void OnOpening(EventArgs e) => DialogOpening?.Invoke(this, e);
#endregion

#region NativeDialogEventSink Nested Class
        private class NativeDialogEventSink : IFileDialogEvents, IFileDialogControlEvents
        {
            private readonly CommonFileDialog parent;
            private bool firstFolderChanged = true;

            public NativeDialogEventSink(CommonFileDialog commonDialog) => parent = commonDialog;

            public uint Cookie { get; set; }

            public HResult OnFileOk(IFileDialog pfd)
            {
                var args = new CancelEventArgs();
                parent.OnFileOk(args);

                if (!args.Cancel &&
                    // Make sure all custom properties are sync'ed
                    parent.Controls != null)

                    foreach (CommonFileDialogControl control in parent.Controls)

                        if (control is CommonFileDialogTextBox textBox)
                        {
                            textBox.SyncValue();
                            textBox.Closed = true;
                        }

                        // Also check subcontrols
                        else if (control is CommonFileDialogGroupBox groupBox)

                            foreach (CommonFileDialogControl subcontrol in groupBox.Items.Cast<CommonFileDialogControl>())

                                if (subcontrol is CommonFileDialogTextBox textbox)
                                {
                                    textbox.SyncValue();
                                    textbox.Closed = true;
                                }

                return args.Cancel ? HResult.False : HResult.Ok;
            }

            public HResult OnFolderChanging(IFileDialog pfd, IShellItem psiFolder)
            {
                var args = new CommonFileDialogFolderChangeEventArgs(GetFileNameFromShellItem(psiFolder));

                if (!firstFolderChanged)

                    parent.OnFolderChanging(args);

                return args.Cancel ? HResult.False : HResult.Ok;
            }

            public void OnFolderChange(IFileDialog pfd)
            {
                if (firstFolderChanged)
                {
                    firstFolderChanged = false;
                    parent.OnOpening(EventArgs.Empty);
                }

                else

                    parent.OnFolderChanged(EventArgs.Empty);
            }

            public void OnSelectionChange(IFileDialog pfd) => parent.OnSelectionChanged(EventArgs.Empty);

            public void OnShareViolation(
                IFileDialog pfd,
                IShellItem psi,
                out FileDialogEventShareViolationResponse pResponse) =>
                // Do nothing: we will ignore share violations, 
                // and don't register
                // for them, so this method should never be called.
                pResponse = FileDialogEventShareViolationResponse.Accept;

            public void OnTypeChange(IFileDialog pfd) => parent.OnFileTypeChanged(EventArgs.Empty);

            public void OnOverwrite(IFileDialog pfd, IShellItem psi, out FileDialogEventOverwriteResponse pResponse) =>
                // Don't accept or reject the dialog, keep default settings
                pResponse = FileDialogEventOverwriteResponse.Default;

            public void OnItemSelected(IFileDialogCustomize pfdc, int dwIDCtl, int dwIDItem)
            {
                // Find control
                DialogControl control = parent.Controls.GetControlbyId(dwIDCtl);


                // Process ComboBox and/or RadioButtonList                
                if (control is ICommonFileDialogIndexedControls controlInterface)
                {
                    // Update selected item and raise SelectedIndexChanged event                    
                    controlInterface.SelectedIndex = dwIDItem;
                    controlInterface.RaiseSelectedIndexChangedEvent();
                }

                // Process Menu
                else if (control is CommonFileDialogMenu menu)

                    // Find the menu item that was clicked and invoke it's click event
                    foreach (CommonFileDialogMenuItem item in menu.Items)

                        if (item.Id == dwIDItem)
                        {
                            item.RaiseClickEvent();
                            break;
                        }
            }

            public void OnButtonClicked(IFileDialogCustomize pfdc, int dwIDCtl)
            {
                // Find control and call corresponding event
                if (parent.Controls.GetControlbyId(dwIDCtl) is CommonFileDialogButton button)

                    button.RaiseClickEvent();
            }

            public void OnCheckButtonToggled(IFileDialogCustomize pfdc, int dwIDCtl, bool bChecked)
            {
                // Find control and update control and call corresponding event
                if (parent.Controls.GetControlbyId(dwIDCtl) is CommonFileDialogCheckBox box)
                {
                    box.IsChecked = bChecked;
                    box.RaiseCheckedChangedEvent();
                }
            }

            public void OnControlActivating(IFileDialogCustomize pfdc, int dwIDCtl) { /* Left empty. */ }
        }
#endregion

#region IDisposable Members
        /// <summary>
        /// Releases the unmanaged resources used by the CommonFileDialog class and optionally 
        /// releases the managed resources.
        /// </summary>
        /// <param name="disposing"><b>true</b> to release both managed and unmanaged resources; 
        /// <b>false</b> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)

                CleanUpNativeFileDialog();
        }

        /// <summary>
        /// Releases the resources used by the current instance of the CommonFileDialog class.
        /// </summary>        
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
#endregion

        /// <summary>
        /// Indicates whether this feature is supported on the current platform.
        /// </summary>
        public static bool IsPlatformSupported => CoreHelpers.RunningOnVista; // We need Windows Vista onwards ...
    }
}
