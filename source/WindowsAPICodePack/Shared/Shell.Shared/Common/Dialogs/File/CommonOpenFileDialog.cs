//Copyright (c) Microsoft Corporation.  All rights reserved.  Distributed under the Microsoft Public License (MS-PL)

using Microsoft.WindowsAPICodePack.COMNative.Dialogs;
using Microsoft.WindowsAPICodePack.COMNative.Shell;
using Microsoft.WindowsAPICodePack.Shell;
using Microsoft.WindowsAPICodePack.Win32Native;
using Microsoft.WindowsAPICodePack.Win32Native.Shell;

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Runtime.InteropServices;

using WinCopies;
using WinCopies.Util;

namespace Microsoft.WindowsAPICodePack.Dialogs
{
    /// <summary>
    /// Creates a Vista or Windows 7 Common File Dialog, allowing the user to select one or more files.
    /// </summary>
    public sealed class CommonOpenFileDialog : CommonFileDialog
    {
        private byte _bools;
        private NativeFileOpenDialog openDialogCoClass;

        /// <summary>
        /// Creates a new instance of this class.
        /// </summary>
        public CommonOpenFileDialog() : base() => EnsureReadOnly = true; // For Open file dialog, allow read only files.

        /// <summary>
        /// Creates a new instance of this class with the specified name.
        /// </summary>
        /// <param name="name">The name of this dialog.</param>
        public CommonOpenFileDialog(string name) : base(name) => EnsureReadOnly = true; // For Open file dialog, allow read only files.

        #region Public API specific to Open
        /// <summary>
        /// Gets a collection of the selected file names.
        /// </summary>
        /// <remarks>This property should only be used when the <see cref="Multiselect"/> property is <see langword="true"/>.</remarks>
        public
#if CS6
            System.Collections.Generic.IReadOnlyList
#else
            ReadOnlyCollection
#endif
            <string> FileNames
        {
            get
            {
                CheckFileNamesAvailable();
                return FileNameCollection;
            }
        }

        /// <summary>
        /// Gets a collection of the selected items as <see cref="ShellObject"/> objects.
        /// </summary>
        /// <remarks>This property should only be used when the <see cref="Multiselect"/> property is <see langword="true"/>.</remarks>
        public ICollection<ShellObject> FilesAsShellObject
        {
            get
            {
                // Check if we have selected files from the user.              
                CheckFileItemsAvailable();

                var list = new List<ShellObject>(items.Count);

                // Loop through our existing list of filenames, and try to create a concrete type of
                // ShellObject (e.g. ShellLibrary, FileSystemFolder, ShellFile, etc)
                foreach (IShellItem si in items)

                    list.Add(ShellObjectFactory.Create(si));

                return new Collection<ShellObject>(list);
            }
        }

        /// <summary>
        /// Gets or sets a value that determines whether the user can select more than one file.
        /// </summary>
        public bool Multiselect { get => GetBit(0); set => SetBit(0, value); }

        /// <summary>
        /// Gets or sets a value that determines whether the user can select folders or files.
        /// Default value is <see langword="false"/>.
        /// </summary>
        public bool IsFolderPicker { get => GetBit(1); set => SetBit(1, value); }

        /// <summary>
        /// Gets or sets a value that determines whether the user can select non-filesystem items, 
        /// such as <b>Library</b>, <b>Search Connectors</b>, or <b>Known Folders</b>.
        /// </summary>
        public bool AllowNonFileSystemItems { get => GetBit(2); set => SetBit(2, value); }
        #endregion Public API specific to Open

        private bool GetBit(in byte pos) => _bools.GetBit(pos);
        private void SetBit(in byte pos, in bool value) =>
#if WAPICP3
            UtilHelpers
#else
            Util
#endif
            .SetBit(ref _bools, pos, value);

        internal override IFileDialog GetNativeFileDialog()
        {
            Debug.Assert(openDialogCoClass != null, "Must call Initialize() before fetching dialog interface.");

            return openDialogCoClass;
        }

        internal override void InitializeNativeFileDialog()
        {
            if (openDialogCoClass == null)

                openDialogCoClass = new NativeFileOpenDialog();
        }

        internal override void CleanUpNativeFileDialog()
        {
            if (openDialogCoClass != null)

                _ = Marshal.ReleaseComObject(openDialogCoClass);
        }

        private void Populate<T>(in Collection<T> items, in ConverterIn<IShellItem, T> converter)
        {
            openDialogCoClass.GetResults(out IShellItemArray resultsArray);
            CoreErrorHelper.ThrowExceptionForHResult(resultsArray.GetCount(out uint count));
            items.Clear();
            for (int i = 0; i < count; i++)

                items.Add(converter(GetShellItemAt(resultsArray, i)));
        }

        internal override void PopulateWithFileNames(in Collection<string> names) => Populate(names, (in IShellItem item) => GetFileNameFromShellItem(item));

        internal override void PopulateWithIShellItems(in Collection<IShellItem> items) => Populate(items, Delegates.SelfIn);

        internal override FileOpenOptions GetDerivedOptionFlags(FileOpenOptions flags)
        {
            if (Multiselect)

                flags |= FileOpenOptions.AllowMultiSelect;

            if (IsFolderPicker)

                flags |= FileOpenOptions.PickFolders;

            return flags | (AllowNonFileSystemItems ? FileOpenOptions.AllNonStorageItems : FileOpenOptions.ForceFilesystem);
        }
    }
}
