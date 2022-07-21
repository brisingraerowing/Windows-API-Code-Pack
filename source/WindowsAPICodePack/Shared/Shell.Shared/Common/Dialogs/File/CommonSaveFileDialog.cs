//Copyright (c) Microsoft Corporation.  All rights reserved.  Distributed under the Microsoft Public License (MS-PL)

using Microsoft.WindowsAPICodePack.COMNative.Dialogs;
using Microsoft.WindowsAPICodePack.COMNative.Shell;
using Microsoft.WindowsAPICodePack.COMNative.Shell.PropertySystem;
using Microsoft.WindowsAPICodePack.PropertySystem;
using Microsoft.WindowsAPICodePack.Shell;
using Microsoft.WindowsAPICodePack.Shell.PropertySystem;
using Microsoft.WindowsAPICodePack.Win32Native;
using Microsoft.WindowsAPICodePack.Win32Native.Shell;

using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;

using WinCopies;
using WinCopies.Util;

using static Microsoft.WindowsAPICodePack.Shell.Resources.LocalizedMessages;

namespace Microsoft.WindowsAPICodePack.Dialogs
{
    /// <summary>
    /// Creates a Vista or Windows 7 Common File Dialog, allowing the user to select the filename and location for a saved file.
    /// </summary>
    /// <permission cref="System.Security.Permissions.FileDialogPermission">
    /// to save a file. Associated enumeration: <see cref="System.Security.Permissions.SecurityAction.LinkDemand"/>.
    /// </permission>
    public sealed class CommonSaveFileDialog : CommonFileDialog
    {
        private NativeFileSaveDialog saveDialogCoClass;
        private byte _bools = 0b1;

        /// <summary>
        /// Creates a new instance of this class.
        /// </summary>
        public CommonSaveFileDialog() { /* Left empty. */ }

        /// <summary>
        /// Creates a new instance of this class with the specified name.
        /// </summary>
        /// <param name="name">The name of this dialog.</param>
        public CommonSaveFileDialog(string name) : base(name) { /* Left empty. */ }

        private bool GetBit(in byte pos) => _bools.GetBit(pos);

        private void UpdateValue(in byte pos, in bool value, in string exceptionMessage)
        {
            ThrowIfDialogShowing(exceptionMessage);

            UtilHelpers.SetBit(ref _bools, pos, value);
        }

        #region Public API specific to Save
        /// <summary>
        /// Gets or sets a value that controls whether to prompt before 
        /// overwriting an existing file of the same name. Default value is true.
        /// </summary>
        /// <permission cref="InvalidOperationException">
        /// This property cannot be changed when the dialog is showing.
        /// </permission>
        public bool OverwritePrompt { get => GetBit(0); set => UpdateValue(0, value, OverwritePromptCannotBeChanged); }

        /// <summary>
        /// Gets or sets a value that controls whether to prompt for creation if the item returned in the save dialog does not exist. 
        /// </summary>
        /// <remarks>Note that this does not actually create the item.</remarks>
        /// <permission cref="InvalidOperationException">
        /// This property cannot be changed when the dialog is showing.
        /// </permission>
        public bool CreatePrompt { get => GetBit(1); set => UpdateValue(1, value, CreatePromptCannotBeChanged); }

        /// <summary>
        /// Gets or sets a value that controls whether to the save dialog 
        /// displays in expanded mode. 
        /// </summary>
        /// <remarks>Expanded mode controls whether the dialog
        /// shows folders for browsing or hides them.</remarks>
        /// <permission cref="InvalidOperationException">
        /// This property cannot be changed when the dialog is showing.
        /// </permission>
        public bool IsExpandedMode { get => GetBit(2); set => UpdateValue(2, value, IsExpandedModeCannotBeChanged); }

        /// <summary>
        /// Gets or sets a value that controls whether the 
        /// returned file name has a file extension that matches the 
        /// currently selected file type.  If necessary, the dialog appends the correct 
        /// file extension.
        /// </summary>
        /// <permission cref="InvalidOperationException">
        /// This property cannot be changed when the dialog is showing.
        /// </permission>
        public bool AlwaysAppendDefaultExtension { get => GetBit(3); set => UpdateValue(3, value, AlwaysAppendDefaultExtensionCannotBeChanged); }

        /// <summary>
        /// Sets an item to appear as the initial entry in a <b>Save As</b> dialog.
        /// </summary>
        /// <param name="item">The initial entry to be set in the dialog.</param>
        /// <remarks>The name of the item is displayed in the file name edit box, 
        /// and the containing folder is opened in the view. This would generally be 
        /// used when the application is saving an item that already exists.</remarks>
        public void SetSaveAsItem(ShellObject item)
        {
            if (item == null)

                throw new ArgumentNullException(nameof(item));

            InitializeNativeFileDialog();

            // Get the native IShellItem from ShellObject
            if (GetNativeFileDialog() is IFileSaveDialog nativeDialog)

                nativeDialog.SetSaveAsItem(item.NativeShellItem);
        }

        /// <summary>
        /// Specifies which properties will be collected in the save dialog.
        /// </summary>
        /// <param name="appendDefault"><see langword="true"/> to show default properties for the currently selected 
        /// filetype in addition to the properties specified by propertyList. <see langword="false"/> to show only properties 
        /// specified by <paramref name="propertyList"/>.</param>
        /// <param name="propertyList">List of properties to collect. This parameter can be <see langword="null"/>.</param>
        /// <remarks>
        /// <see cref="SetCollectedPropertyKeys"/> can be called at any time before the dialog is displayed or while it 
        /// is visible. If different properties are to be collected depending on the chosen filetype, 
        /// then <see cref="IFileSaveDialog.SetCollectedProperties"/> can be called in response to <see cref="CommonFileDialog.FileTypeChanged"/> event.
        /// Note: By default, no properties are collected in the save dialog.
        /// </remarks>
        public void SetCollectedPropertyKeys(bool appendDefault, params PropertyKey[] propertyList)
        {
            // Loop through all our property keys and create a semicolon-delimited property list string.
            // The string we pass to PSGetPropertyDescriptionListFromString must
            // start with "prop:", followed a list of canonical names for each 
            // property that is to collected.
            if (propertyList is object && propertyList.Length > 0 && propertyList[0] != null)
            {
                var sb = new StringBuilder("prop:");

                foreach (PropertyKey key in propertyList)
                {
                    string canonicalName = ShellPropertyDescriptionsCache.Cache.GetPropertyDescription(key).CanonicalName;

                    if (!string.IsNullOrEmpty(canonicalName))
                        
                        _ = sb.AppendFormat("{0};", canonicalName);
                }

                var guid = new Guid(NativeAPI.Guids.Shell.IPropertyDescriptionList);

                IPropertyDescriptionList propertyDescriptionList = null;

                try
                {
                    int hr = PropertySystemNativeMethods.PSGetPropertyDescriptionListFromString(
                        sb.ToString(),
                        ref guid,
                        out propertyDescriptionList);

                    // If we get a IPropertyDescriptionList, setit on the native dialog.
                    if (CoreErrorHelper.Succeeded(hr))
                    {
                        InitializeNativeFileDialog();

                        if (GetNativeFileDialog() is IFileSaveDialog nativeDialog)
                        {
                            hr = nativeDialog.SetCollectedProperties(propertyDescriptionList, appendDefault);

                            if (!CoreErrorHelper.Succeeded(hr))

                                throw new ShellException(hr);
                        }
                    }
                }

                finally
                {
                    if (propertyDescriptionList is object)

                        _ = Marshal.ReleaseComObject(propertyDescriptionList);
                }
            }
        }

        /// <summary>
        /// Retrieves the set of property values for a saved item or an item in the process of being saved.
        /// </summary>
        /// <returns>Collection of property values collected from the save dialog.</returns>
        /// <remarks>This property can be called while the dialog is showing to retrieve the current 
        /// set of values in the metadata collection pane. It can also be called after the dialog 
        /// has closed, to retrieve the final set of values. The call to this method will fail 
        /// unless property collection has been turned on with a call to <see cref="SetCollectedPropertyKeys"/> method.
        /// </remarks>
        public ShellPropertyCollection CollectedProperties
        {
            get
            {
                InitializeNativeFileDialog();

                if (GetNativeFileDialog() is IFileSaveDialog nativeDialog)
                {
                    HResult hr = nativeDialog.GetProperties(out IPropertyStore propertyStore);

                    if (propertyStore != null && CoreErrorHelper.Succeeded(hr))

                        return new ShellPropertyCollection(propertyStore);
                }

                return null;
            }
        }
        #endregion Public API specific to Save

        internal override void InitializeNativeFileDialog()
        {
#if !CS8
            if (
#endif
            saveDialogCoClass
#if CS8
            ??=
#else
            == null)

                saveDialogCoClass =
#endif
            new NativeFileSaveDialog();
        }

        internal override IFileDialog GetNativeFileDialog()
        {
            Debug.Assert(saveDialogCoClass != null, "Must call Initialize() before fetching dialog interface");

            return saveDialogCoClass;
        }

        private void Populate<T>(in System.Collections.ObjectModel.Collection<T> items, in ConverterIn<IShellItem, T> converter)
        {
            saveDialogCoClass.GetResult(out IShellItem item);

            (items ?? throw new InvalidOperationException(SaveFileNullItem)).Clear();

            items.Add(converter(item));
        }

        internal override void PopulateWithFileNames(in System.Collections.ObjectModel.Collection<string> names) => Populate(names, (in IShellItem item) => GetFileNameFromShellItem(item));

        internal override void PopulateWithIShellItems(in System.Collections.ObjectModel.Collection<IShellItem> items) => Populate(items, Delegates.SelfIn);

        internal override void CleanUpNativeFileDialog()
        {
            if (saveDialogCoClass != null)

                _ = Marshal.ReleaseComObject(saveDialogCoClass);
        }

        internal override FileOpenOptions GetDerivedOptionFlags(FileOpenOptions flags)
        {
            if (OverwritePrompt)

                flags |= FileOpenOptions.OverwritePrompt;

            if (CreatePrompt)

                flags |= FileOpenOptions.CreatePrompt;

            if (!IsExpandedMode)

                flags |= FileOpenOptions.DefaultNoMiniMode;

            return AlwaysAppendDefaultExtension ? flags | FileOpenOptions.StrictFileTypes : flags;
        }
    }
}
