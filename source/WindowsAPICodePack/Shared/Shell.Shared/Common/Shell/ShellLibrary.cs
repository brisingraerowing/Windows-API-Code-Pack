//Copyright (c) Microsoft Corporation.  All rights reserved.  Distributed under the Microsoft Public License (MS-PL)

using Microsoft.WindowsAPICodePack.COMNative.Shell;
using Microsoft.WindowsAPICodePack.Shell.Guids;
using Microsoft.WindowsAPICodePack.Win32Native;
using Microsoft.WindowsAPICodePack.Win32Native.Shell;
using Microsoft.WindowsAPICodePack.Win32Native.Shell.Resources;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using WinCopies;
using WinCopies.Util;

namespace Microsoft.WindowsAPICodePack.Shell
{
    /// <summary>
    /// A Shell Library in the Shell Namespace
    /// </summary>
    public sealed class ShellLibrary : ShellContainer, IList<ShellFileSystemFolder>
    {
        #region Private Fields
        private INativeShellLibrary nativeShellLibrary;
        private readonly IKnownFolder knownFolder;

        private static readonly Guid[] FolderTypesGuids =
        {
            new Guid(ShellKnownFolderID.GenericLibrary),
            new Guid(ShellKnownFolderID.DocumentsLibrary),
            new Guid(ShellKnownFolderID.MusicLibrary),
            new Guid(ShellKnownFolderID.PicturesLibrary),
            new Guid(ShellKnownFolderID.VideosLibrary)
        };
        #endregion

        #region Internal Properties
        internal const string FileExtension = ".library-ms";

        internal override IShellItem NativeShellItem => NativeShellItem2;

        internal override IShellItem2 NativeShellItem2 => _nativeShellItem;
        #endregion

        #region Public Properties
        /// <summary>
        /// The name of the library, every library must have a name.
        /// </summary>
        /// <exception cref="COMException">Will throw if no Icon is set</exception>
        public override string Name => base.Name == null && NativeShellItem != null ? (base.Name = Path.GetFileNameWithoutExtension(ShellHelper.GetParsingName(NativeShellItem))) : base.Name;

        /// <summary>
        /// The Resource Reference to the icon.
        /// </summary>
        public IconReference IconResourceId
        {
            get
            {
                nativeShellLibrary.GetIcon(out string iconRef);

                return new IconReference(iconRef);
            }

            set => nativeShellLibrary.SetIcon(value.ReferencePath);
        }

        /// <summary>
        /// One of predefined Library types
        /// </summary>
        /// <exception cref="COMException">Will throw if no Library Type is set</exception>
        public LibraryFolderType LibraryType
        {
            get
            {
                nativeShellLibrary.GetFolderType(out Guid folderTypeGuid);

                return GetFolderTypeFromGuid(folderTypeGuid);
            }

            set
            {
                Guid guid = FolderTypesGuids[(int)value];
                nativeShellLibrary.SetFolderType(ref guid);
            }
        }

        /// <summary>
        /// The Guid of the Library type
        /// </summary>
        /// <exception cref="COMException">Will throw if no Library Type is set</exception>
        public Guid LibraryTypeId
        {
            get
            {
                nativeShellLibrary.GetFolderType(out Guid folderTypeGuid);

                return folderTypeGuid;
            }
        }

        private static LibraryFolderType GetFolderTypeFromGuid(Guid folderTypeGuid)
        {
            for (int i = 0; i < FolderTypesGuids.Length; i++)

                if (folderTypeGuid.Equals(FolderTypesGuids[i]))

                    return (LibraryFolderType)i;

            throw new ArgumentOutOfRangeException(nameof(folderTypeGuid), LocalizedMessages.ShellLibraryInvalidFolderType);
        }

        /// <summary>
        /// By default, this folder is the first location 
        /// added to the library. The default save folder 
        /// is both the default folder where files can 
        /// be saved, and also where the library XML 
        /// file will be saved, if no other path is specified
        /// </summary>
        public string DefaultSaveFolder
        {
            get
            {
                var guid = new Guid(NativeAPI.Guids.Shell.IShellItem);

                nativeShellLibrary.GetDefaultSaveFolder(
                    DefaultSaveFolderType.Detect,
                    ref guid,
                    out IShellItem saveFolderItem);

                return ShellHelper.GetParsingName(saveFolderItem);
            }

            set
            {
                string fullPath = string.IsNullOrEmpty(value) ? throw new ArgumentNullException(nameof(value)) : Directory.Exists(value) ? new DirectoryInfo(value).FullName : throw new DirectoryNotFoundException(LocalizedMessages.ShellLibraryDefaultSaveFolderNotFound);

                var guid = new Guid(NativeAPI.Guids.Shell.IShellItem);

                _ = COMNative.Shell.Shell.SHCreateItemFromParsingName(fullPath, IntPtr.Zero, ref guid, out IShellItem saveFolderItem);

                nativeShellLibrary.SetDefaultSaveFolder(
                    DefaultSaveFolderType.Detect,
                    saveFolderItem);
            }
        }

        /// <summary>
        /// Whether the library will be pinned to the Explorer Navigation Pane.
        /// </summary>
        public bool IsPinnedToNavigationPane
        {
            get
            {
                nativeShellLibrary.GetOptions(out LibraryOptions flags);

                return (flags & LibraryOptions.PinnedToNavigationPane) == LibraryOptions.PinnedToNavigationPane;
            }

            set
            {
                LibraryOptions flags = LibraryOptions.Default;

                if (value)

                    flags |= LibraryOptions.PinnedToNavigationPane;

                else

                    flags &= ~LibraryOptions.PinnedToNavigationPane;

                nativeShellLibrary.SetOptions(LibraryOptions.PinnedToNavigationPane, flags);
            }
        }
        #endregion Public Properties

        #region Constructors
        #region Private
        private ShellLibrary() => CoreHelpers.ThrowIfNotWin7();

        //Construct the ShellLibrary object from a native Shell Library
        private ShellLibrary(in INativeShellLibrary nativeShellLibrary) : this()
            => this.nativeShellLibrary = nativeShellLibrary;

        /// <summary>
        /// Creates a shell library in the Libraries Known Folder, 
        /// using the given IKnownFolder
        /// </summary>
        /// <param name="sourceKnownFolder">KnownFolder from which to create the new Shell Library</param>
        /// <param name="isReadOnly">If <B>true</B> , opens the library in read-only mode.</param>
        private ShellLibrary(in IKnownFolder sourceKnownFolder, in bool isReadOnly) : this()
        {
            Debug.Assert(sourceKnownFolder != null);

            // Keep a reference locally
            knownFolder = sourceKnownFolder;

            nativeShellLibrary = (INativeShellLibrary)new ShellLibraryCoClass();

            AccessModes flags = isReadOnly ?
                    AccessModes.Read :
                    AccessModes.ReadWrite;

            // Get the IShellItem2
            _nativeShellItem = ((ShellObject)sourceKnownFolder).NativeShellItem2;

            Guid guid = sourceKnownFolder.FolderId;

            // Load the library from the IShellItem2

            try
            {
                nativeShellLibrary.LoadLibraryFromKnownFolder(ref guid, flags);
            }

            catch (Exception ex) when (ex.Is(false, typeof(InvalidCastException), typeof(NotImplementedException)))
            {
                throw new ArgumentException(LocalizedMessages.ShellLibraryInvalidLibrary, nameof(sourceKnownFolder));
            }
        }
        #endregion Private

        #region Public
        /// <summary>
        /// Creates a shell library in the Libraries Known Folder, 
        /// using the given shell library name.
        /// </summary>
        /// <param name="libraryName">The name of this library</param>
        /// <param name="overwrite">Allow overwriting an existing library; if one exists with the same name</param>
        public ShellLibrary(string libraryName, bool overwrite) : this()
        {
            Name = string.IsNullOrEmpty(libraryName) ? throw new ArgumentException(LocalizedMessages.ShellLibraryEmptyName, nameof(libraryName)) : libraryName;

            var guid = new Guid(Guids.KnownFolders.Windows7.Libraries);

            (nativeShellLibrary = (INativeShellLibrary)new ShellLibraryCoClass()).SaveInKnownFolder(ref guid, libraryName, overwrite
                ? LibrarySaveOptions.OverrideExisting
                : LibrarySaveOptions.FailIfThere, out _nativeShellItem);
        }

        /// <summary>
        /// Creates a shell library in a given Known Folder, using the given shell library name.
        /// </summary>
        /// <param name="libraryName">The name of this library</param>
        /// <param name="sourceKnownFolder">The known folder</param>
        /// <param name="overwrite">Override an existing library with the same name</param>
        public ShellLibrary(string libraryName, IKnownFolder sourceKnownFolder, bool overwrite) : this()
        {
            knownFolder = string.IsNullOrEmpty(libraryName) ? throw new ArgumentException(LocalizedMessages.ShellLibraryEmptyName, nameof(libraryName)) : sourceKnownFolder;

            Name = libraryName;
            Guid guid = knownFolder.FolderId;

            LibrarySaveOptions flags = overwrite ?
                    LibrarySaveOptions.OverrideExisting :
                    LibrarySaveOptions.FailIfThere;

            nativeShellLibrary = (INativeShellLibrary)new ShellLibraryCoClass();
            nativeShellLibrary.SaveInKnownFolder(ref guid, libraryName, flags, out _nativeShellItem);
        }

        /// <summary>
        /// Creates a shell library in a given local folder, using the given shell library name.
        /// </summary>
        /// <param name="libraryName">The name of this library</param>
        /// <param name="folderPath">The path to the local folder</param>
        /// <param name="overwrite">Override an existing library with the same name</param>
        public ShellLibrary(string libraryName, string folderPath, bool overwrite) : this()
        {
            Name = string.IsNullOrEmpty(libraryName) ? throw new ArgumentException(LocalizedMessages.ShellLibraryEmptyName, nameof(libraryName)) : Directory.Exists(folderPath) ? libraryName : throw new DirectoryNotFoundException(LocalizedMessages.ShellLibraryFolderNotFound);

            var guid = new Guid(NativeAPI.Guids.Shell.IShellItem);

            _ = COMNative.Shell.Shell.SHCreateItemFromParsingName(folderPath, IntPtr.Zero, ref guid, out IShellItem shellItemIn);

            (nativeShellLibrary = (INativeShellLibrary)new ShellLibraryCoClass()).Save(shellItemIn, libraryName, overwrite ?
                LibrarySaveOptions.OverrideExisting :
                LibrarySaveOptions.FailIfThere, out _nativeShellItem);
        }
        #endregion Public
        #endregion Constructors

        /// <summary>
        /// Close the library, and release its associated file system resources.
        /// </summary>
        public void Close() => Dispose();

        #region Static Shell Library methods
        /// <summary>
        /// Get a the known folder FOLDERID_Libraries.
        /// </summary>
        public static IKnownFolder LibrariesKnownFolder
        {
            get
            {
                CoreHelpers.ThrowIfNotWin7();
                return KnownFolderHelper.FromKnownFolderId(new Guid(Guids.KnownFolders.Windows7.Libraries));
            }
        }

        /// <summary>
        /// Load the library using a number of options
        /// </summary>
        /// <param name="libraryName">The name of the library</param>
        /// <param name="isReadOnly">If <see langword="true"/>, loads the library in read-only mode.</param>
        /// <returns>A <see cref="ShellLibrary"/> Object</returns>
        public static ShellLibrary Load(string libraryName, bool isReadOnly)
        {
            CoreHelpers.ThrowIfNotWin7();

            using
#if !CS8
                (
#endif
                IKnownFolder kf = KnownFolders.Libraries
#if CS8
                ;
#else
            )
            {
#endif
            var guid = new Guid(NativeAPI.Guids.Shell.IShellItem);
            string shellItemPath = Path.Combine((kf != null) ? kf.Path : string.Empty, libraryName + FileExtension);
            int hr = COMNative.Shell.Shell.SHCreateItemFromParsingName(shellItemPath, IntPtr.Zero, ref guid, out IShellItem nativeShellItem);

            var nativeShellLibrary = CoreErrorHelper.Succeeded(hr) ? (INativeShellLibrary)new ShellLibraryCoClass() : throw new ShellException(hr);
            AccessModes flags = isReadOnly ?
                    AccessModes.Read :
                    AccessModes.ReadWrite;
            CoreErrorHelper.ThrowExceptionForHResult(nativeShellLibrary.LoadLibraryFromItem(nativeShellItem, flags));

            var library = new ShellLibrary(nativeShellLibrary);

            try
            {
                library._nativeShellItem = (IShellItem2)nativeShellItem;
                library.Name = libraryName;

                return library;
            }

            catch
            {
                library.Dispose();

                throw;
            }
#if !CS8
            }
#endif
        }

        /// <summary>
        /// Load the library using a number of options.
        /// </summary>
        /// <param name="libraryName">The name of the library.</param>
        /// <param name="folderPath">The path to the library.</param>
        /// <param name="isReadOnly">If <see langword="true"/>, opens the library in read-only mode.</param>
        /// <returns>A <see cref="ShellLibrary"/> Object</returns>
        public static ShellLibrary Load(string libraryName, string folderPath, bool isReadOnly)
        {
            CoreHelpers.ThrowIfNotWin7();

            // Create the shell item path
            string shellItemPath = Path.Combine(folderPath, libraryName + FileExtension);
            var item = new ShellFile(shellItemPath);

            IShellItem nativeShellItem = item.NativeShellItem;
            var nativeShellLibrary = (INativeShellLibrary)new ShellLibraryCoClass();
            AccessModes flags = isReadOnly ?
                    AccessModes.Read :
                    AccessModes.ReadWrite;
            CoreErrorHelper.ThrowExceptionForHResult(nativeShellLibrary.LoadLibraryFromItem(nativeShellItem, flags));

            var library = new ShellLibrary(nativeShellLibrary);

            try
            {
                library._nativeShellItem = (IShellItem2)nativeShellItem;
                library.Name = libraryName;

                item.Dispose();

                return library;
            }
            catch
            {
                library.Dispose();

                throw;
            }
        }

        /// <summary>
        /// Load the library using a number of options.
        /// </summary>
        /// <param name="nativeShellItem">IShellItem</param>
        /// <param name="isReadOnly">read-only flag</param>
        /// <returns>A <see cref="ShellLibrary"/> Object</returns>
        internal static ShellLibrary FromShellItem(IShellItem nativeShellItem, bool isReadOnly)
        {
            CoreHelpers.ThrowIfNotWin7();

            var nativeShellLibrary = (INativeShellLibrary)new ShellLibraryCoClass();

            CoreErrorHelper.ThrowExceptionForHResult(nativeShellLibrary.LoadLibraryFromItem(nativeShellItem, isReadOnly ?
                    AccessModes.Read :
                    AccessModes.ReadWrite));

            var library = new ShellLibrary(nativeShellLibrary)
            {
                _nativeShellItem = (IShellItem2)nativeShellItem
            };

            return library;
        }

        /// <summary>
        /// Load the library using a number of options.
        /// </summary>
        /// <param name="sourceKnownFolder">A known folder.</param>
        /// <param name="isReadOnly">If <see langword="true"/>, opens the library in read-only mode.</param>
        /// <returns>A <see cref="ShellLibrary"/> Object</returns>
        public static ShellLibrary Load(IKnownFolder sourceKnownFolder, bool isReadOnly)
        {
            CoreHelpers.ThrowIfNotWin7();
            return new ShellLibrary(sourceKnownFolder, isReadOnly);
        }

        private static void ShowManageLibraryUI(ShellLibrary shellLibrary, IntPtr windowHandle, string title, string instruction, bool allowAllLocations)
        {
            int hr = 0;

            var staWorker = new Thread(() => hr = COMNative.Shell.Shell.SHShowManageLibraryUI(
                    shellLibrary.NativeShellItem,
                    windowHandle,
                    title,
                    instruction,
                    allowAllLocations
                      ? LibraryManageDialogOptions.NonIndexableLocationWarning
                      : LibraryManageDialogOptions.Default));

            staWorker.SetApartmentState(ApartmentState.STA);
            staWorker.Start();
            staWorker.Join();

            if (!CoreErrorHelper.Succeeded(hr)) throw new ShellException(hr);
        }

        /// <summary>
        /// Shows the library management dialog which enables users to mange the library folders and default save location.
        /// </summary>
        /// <param name="libraryName">The name of the library</param>
        /// <param name="folderPath">The path to the library.</param>
        /// <param name="windowHandle">The parent window,or IntPtr.Zero for no parent</param>
        /// <param name="title">A title for the library management dialog, or null to use the library name as the title</param>
        /// <param name="instruction">An optional help string to display for the library management dialog</param>
        /// <param name="allowAllLocations">If true, do not show warning dialogs about locations that cannot be indexed</param>
        /// <remarks>If the library is already open in read-write mode, the dialog will not save the changes.</remarks>
        public static void ShowManageLibraryUI(string libraryName, string folderPath, IntPtr windowHandle, string title, string instruction, bool allowAllLocations)
        {
            // this method is not safe for MTA consumption and will blow
            // Access Violations if called from an MTA thread so we wrap this
            // call up into a Worker thread that performs all operations in a
            // single threaded apartment
            using (ShellLibrary shellLibrary = Load(libraryName, folderPath, true))

                ShowManageLibraryUI(shellLibrary, windowHandle, title, instruction, allowAllLocations);
        }

        /// <summary>
        /// Shows the library management dialog which enables users to mange the library folders and default save location.
        /// </summary>
        /// <param name="libraryName">The name of the library</param>
        /// <param name="windowHandle">The parent window,or IntPtr.Zero for no parent</param>
        /// <param name="title">A title for the library management dialog, or null to use the library name as the title</param>
        /// <param name="instruction">An optional help string to display for the library management dialog</param>
        /// <param name="allowAllLocations">If true, do not show warning dialogs about locations that cannot be indexed</param>
        /// <remarks>If the library is already open in read-write mode, the dialog will not save the changes.</remarks>
        public static void ShowManageLibraryUI(string libraryName, IntPtr windowHandle, string title, string instruction, bool allowAllLocations)
        {
            // this method is not safe for MTA consumption and will blow
            // Access Violations if called from an MTA thread so we wrap this
            // call up into a Worker thread that performs all operations in a
            // single threaded apartment
            using (ShellLibrary shellLibrary = Load(libraryName, true))

                ShowManageLibraryUI(shellLibrary, windowHandle, title, instruction, allowAllLocations);
        }

        /// <summary>
        /// Shows the library management dialog which enables users to mange the library folders and default save location.
        /// </summary>
        /// <param name="sourceKnownFolder">A known folder.</param>
        /// <param name="windowHandle">The parent window,or IntPtr.Zero for no parent</param>
        /// <param name="title">A title for the library management dialog, or null to use the library name as the title</param>
        /// <param name="instruction">An optional help string to display for the library management dialog</param>
        /// <param name="allowAllLocations">If true, do not show warning dialogs about locations that cannot be indexed</param>
        /// <remarks>If the library is already open in read-write mode, the dialog will not save the changes.</remarks>
        public static void ShowManageLibraryUI(IKnownFolder sourceKnownFolder, IntPtr windowHandle, string title, string instruction, bool allowAllLocations)
        {
            // this method is not safe for MTA consumption and will blow
            // Access Violations if called from an MTA thread so we wrap this
            // call up into a Worker thread that performs all operations in a
            // single threaded apartment
            using (ShellLibrary shellLibrary = Load(sourceKnownFolder, true))

                ShowManageLibraryUI(shellLibrary, windowHandle, title, instruction, allowAllLocations);
        }
        #endregion Static Shell Library methods

        #region Collection Members
        /// <summary>
        /// Add a new FileSystemFolder or SearchConnector.
        /// </summary>
        /// <param name="item">The folder to add to the library.</param>
        public void Add(ShellFileSystemFolder item) => (item == null ? throw new ArgumentNullException(nameof(item)) : nativeShellLibrary).AddFolder(item.NativeShellItem);

        /// <summary>
        /// Add an existing folder to this library.
        /// </summary>
        /// <param name="folderPath">The path to the folder to be added to the library.</param>
        public void Add(string folderPath)
        {
            using (var item = Directory.Exists(folderPath) ? ShellFileSystemFolder.FromFolderPath(folderPath) : throw new DirectoryNotFoundException(LocalizedMessages.ShellLibraryFolderNotFound))

                Add(item);
        }

        /// <summary>
        /// Clear all items of this Library.
        /// </summary>
        public void Clear()
        {
            foreach (ShellFileSystemFolder folder in ItemsList)

                nativeShellLibrary.RemoveFolder(folder.NativeShellItem);
        }

        /// <summary>
        /// Remove a folder or search connector.
        /// </summary>
        /// <param name="item">The item to remove.</param>
        /// <returns><see langword="true"/> if the item was removed.</returns>
        public bool Remove(ShellFileSystemFolder item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));

            try
            {
                nativeShellLibrary.RemoveFolder(item.NativeShellItem);
            }

            catch (COMException)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Remove a folder or search connector.
        /// </summary>
        /// <param name="folderPath">The path of the item to remove.</param>
        /// <returns><see langword="true"/> if the item was removed.</returns>
        public bool Remove(string folderPath)
        {
            using (var item = ShellFileSystemFolder.FromFolderPath(folderPath))

                return Remove(item);
        }
        #endregion Collection Members

        public void Commit() => CoreErrorHelper.ThrowExceptionForHResult(nativeShellLibrary.Commit());

        #region Disposable Pattern
        /// <summary>
        /// Release resources
        /// </summary>
        /// <param name="disposing">Indicates that this was called from Dispose(), rather than from the finalizer.</param>
        protected override void Dispose(bool disposing)
        {
            CoreHelpers.DisposeCOMObject(ref nativeShellLibrary);

            base.Dispose(disposing);
        }

        /// <summary>
        /// Release resources
        /// </summary>
        ~ShellLibrary() => Dispose(false);
        #endregion

        #region Private Properties
        private List<ShellFileSystemFolder> ItemsList => GetFolders();

        private List<ShellFileSystemFolder> GetFolders()
        {
            var list = new List<ShellFileSystemFolder>();

            var shellItemArrayGuid = new Guid(NativeAPI.Guids.Shell.IShellItemArray);

            HResult hr = nativeShellLibrary.GetFolders(LibraryFolderFilter.AllItems, ref shellItemArrayGuid, out IShellItemArray itemArray);

            if (!CoreErrorHelper.Succeeded(hr)) return list;

            CoreErrorHelper.ThrowExceptionForHResult(itemArray.GetCount(out uint count));

            for (uint i = 0; i < count; ++i)
            {
                CoreErrorHelper.ThrowExceptionForHResult(itemArray.GetItemAt(i, out IShellItem shellItem));
                list.Add(new ShellFileSystemFolder(shellItem as IShellItem2));
            }

            CoreHelpers.DisposeCOMObject(ref itemArray);

            return list;
        }
        #endregion

        /// <summary>
        /// Retrieves the collection enumerator.
        /// </summary>
        /// <returns>The enumerator.</returns>
        public new IEnumerator<ShellFileSystemFolder> GetEnumerator() => ItemsList.GetEnumerator();

        /// <summary>
        /// Retrieves the collection enumerator.
        /// </summary>
        /// <returns>The enumerator.</returns>
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => ItemsList.GetEnumerator();

        #region System.Collections.Generic.ICollection<ShellFileSystemFolder> Members
        /// <summary>
        /// Determines if an item with the specified path exists in the collection.
        /// </summary>
        /// <param name="fullPath">The path of the item.</param>
        /// <returns><B>true</B> if the item exists in the collection.</returns>
        public bool Contains(string fullPath) => string.IsNullOrEmpty(fullPath)
                ? throw new ArgumentNullException(nameof(fullPath))
                : ItemsList.Any(folder => string.Equals(fullPath, folder.Path, StringComparison.OrdinalIgnoreCase));

        /// <summary>
        /// Determines if a folder exists in the collection.
        /// </summary>
        /// <param name="item">The folder.</param>
        /// <returns><B>true</B>, if the folder exists in the collection.</returns>
        public bool Contains(ShellFileSystemFolder item) => item == null
                ? throw new ArgumentNullException(nameof(item))
                : ItemsList.Any(folder => string.Equals(item.Path, folder.Path, StringComparison.OrdinalIgnoreCase));
        #endregion

        #region IList<FileSystemFolder> Members
        /// <summary>
        /// Searches for the specified FileSystemFolder and returns the zero-based index of the
        /// first occurrence within Library list.
        /// </summary>
        /// <param name="item">The item to search for.</param>
        /// <returns>The index of the item in the collection, or -1 if the item does not exist.</returns>
        public int IndexOf(ShellFileSystemFolder item) => ItemsList.IndexOf(item);

        /// <summary>
        /// Inserts a FileSystemFolder at the specified index.
        /// </summary>
        /// <param name="index">The index to insert at.</param>
        /// <param name="item">The FileSystemFolder to insert.</param>
        void IList<ShellFileSystemFolder>.Insert(int index, ShellFileSystemFolder item) =>
            // Index related options are not supported by IShellLibrary doesn't support them.
            throw new NotSupportedException();

        /// <summary>
        /// Removes an item at the specified index.
        /// </summary>
        /// <param name="index">The index to remove.</param>
        void IList<ShellFileSystemFolder>.RemoveAt(int index) =>
            // Index related options are not supported by IShellLibrary doesn't support them.
            throw new NotSupportedException();

        /// <summary>
        /// Retrieves the folder at the specified index
        /// </summary>
        /// <param name="index">The index of the folder to retrieve.</param>
        /// <returns>A folder.</returns>
        public ShellFileSystemFolder this[int index]
        {
            get => ItemsList[index];

            set =>
                // Index related options are not supported by IShellLibrary
                // doesn't support them.
                throw new NotSupportedException();
        }
        #endregion

        #region System.Collections.Generic.ICollection<ShellFileSystemFolder> Members
        /// <summary>
        /// Copies the collection to an array.
        /// </summary>
        /// <param name="array">The array to copy to.</param>
        /// <param name="arrayIndex">The index in the array at which to start the copy.</param>
        void ICollection<ShellFileSystemFolder>.CopyTo(ShellFileSystemFolder[] array, int arrayIndex) => throw new NotSupportedException();

        /// <summary>
        /// The count of the items in the list.
        /// </summary>
        public int Count => ItemsList.Count;

        /// <summary>
        /// Indicates whether this list is read-only or not.
        /// </summary>
        public bool IsReadOnly => false;
        #endregion

        /// <summary>
        /// Indicates whether this feature is supported on the current platform.
        /// </summary>
        new public static bool IsPlatformSupported =>
                // We need Windows 7 onwards ...
                CoreHelpers.RunningOnWin7;
    }
}
