//Copyright (c) Microsoft Corporation.  All rights reserved.

using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Microsoft.WindowsAPICodePack.Shell;
using Microsoft.WindowsAPICodePack.Win32Native.Dialogs;
using Microsoft.WindowsAPICodePack.Win32Native.Shell;
using WinCopies.Collections;

namespace Microsoft.WindowsAPICodePack.Dialogs
{
    /// <summary>
    /// Creates a Vista or Windows 7 Common File Dialog, allowing the user to select one or more files.
    /// </summary>
    /// 
    public sealed class CommonOpenFileDialog : CommonFileDialog
    {
        private NativeFileOpenDialog openDialogCoClass;

        /// <summary>
        /// Creates a new instance of this class.
        /// </summary>
        public CommonOpenFileDialog()
            : base() =>
            // For Open file dialog, allow read only files.
            EnsureReadOnly = true;

        /// <summary>
        /// Creates a new instance of this class with the specified name.
        /// </summary>
        /// <param name="name">The name of this dialog.</param>
        public CommonOpenFileDialog(string name)
            : base(name) =>
            // For Open file dialog, allow read only files.
            EnsureReadOnly = true;

        #region Public API specific to Open

        /// <summary>
        /// Gets a collection of the selected file names.
        /// </summary>
        /// <remarks>This property should only be used when the
        /// <see cref="Multiselect"/>
        /// property is <b>true</b>.</remarks>
        public IEnumerable<string> FileNames
        {
            get
            {
                CheckFileNamesAvailable();
                return FileNameCollection;
            }
        }

        /// <summary>
        /// Gets a collection of the selected items as ShellObject objects.
        /// </summary>
        /// <remarks>This property should only be used when the
        /// <see cref="Multiselect"/>
        /// property is <b>true</b>.</remarks>
        public System.Collections.Generic.ICollection<ShellObject> FilesAsShellObject
        {
            get
            {
                // Check if we have selected files from the user.              
                CheckFileItemsAvailable();

                // temp collection to hold our shellobjects
                var resultItems = new ArrayBuilder<ShellObject>();

                // Loop through our existing list of filenames, and try to create a concrete type of
                // ShellObject (e.g. ShellLibrary, FileSystemFolder, ShellFile, etc)
                foreach (IShellItem si in items)

                    _ = resultItems.AddLast(ShellObjectFactory.Create(si));

                return new System.Collections.ObjectModel.Collection<ShellObject>( resultItems.ToList());
            }
        }

        /// <summary>
        /// Gets or sets a value that determines whether the user can select more than one file.
        /// </summary>
        public bool Multiselect { get; set; }

        /// <summary>
        /// Gets or sets a value that determines whether the user can select folders or files.
        /// Default value is false.
        /// </summary>
        public bool IsFolderPicker { get; set; }

        /// <summary>
        /// Gets or sets a value that determines whether the user can select non-filesystem items, 
        /// such as <b>Library</b>, <b>Search Connectors</b>, or <b>Known Folders</b>.
        /// </summary>
        public bool AllowNonFileSystemItems { get; set; }
        #endregion

        internal override IFileDialog GetNativeFileDialog()
        {
            Debug.Assert(openDialogCoClass != null, "Must call Initialize() before fetching dialog interface");

            return (IFileDialog)openDialogCoClass;
        }

        internal override void InitializeNativeFileDialog()
        {
            if (openDialogCoClass == null)

                openDialogCoClass = new NativeFileOpenDialog();
        }

        internal override void CleanUpNativeFileDialog()
        {
            if (openDialogCoClass is object)

                _ = Marshal.ReleaseComObject(openDialogCoClass);
        }

        internal override void PopulateWithFileNames(System.Collections.ObjectModel.Collection<string> names)
        {
            openDialogCoClass.GetResults(out IShellItemArray resultsArray);
            Marshal.ThrowExceptionForHR((int)resultsArray.GetCount(out uint count));
            names.Clear();
            for (int i = 0; i < count; i++)

                names.Add(GetFileNameFromShellItem(GetShellItemAt(resultsArray, i)));
        }

        internal override void PopulateWithIShellItems(System.Collections.ObjectModel.Collection<IShellItem> items)
        {
            openDialogCoClass.GetResults(out IShellItemArray resultsArray);
            Marshal.ThrowExceptionForHR((int)resultsArray.GetCount(out uint count));
            items.Clear();
            for (int i = 0; i < count; i++)

                items.Add(GetShellItemAt(resultsArray, i));
        }

        internal override FileOpenOptions GetDerivedOptionFlags(FileOpenOptions flags)
        {
            if (Multiselect)

                flags |= FileOpenOptions.AllowMultiSelect;

            if (IsFolderPicker)

                flags |= FileOpenOptions.PickFolders;



            flags |= AllowNonFileSystemItems ? FileOpenOptions.AllNonStorageItems : FileOpenOptions.ForceFilesystem;



            return flags;
        }
    }
}
