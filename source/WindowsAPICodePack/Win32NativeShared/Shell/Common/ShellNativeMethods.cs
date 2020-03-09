//Copyright (c) Microsoft Corporation.  All rights reserved.

using Microsoft.WindowsAPICodePack.Win32Native;
using Microsoft.WindowsAPICodePack.Win32Native.Shell;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using static Microsoft.WindowsAPICodePack.Win32Native.Shell.ShellNativeMethods;
using FileAttributes = Microsoft.WindowsAPICodePack.Win32Native.Shell.FileAttributes;

namespace Microsoft.WindowsAPICodePack.Win32Native.Shell
{

    /// <summary>
    /// An application-defined callback for some file management. It is called when a portion of a copy or move operation is completed. The LPPROGRESS_ROUTINE type defines a pointer to this callback function. CopyProgressRoutine is a placeholder for the application-defined function name.
    /// </summary>
    /// <param name="TotalFileSize">The total size of the file, in bytes.</param>
    /// <param name="TotalBytesTransferred">The total number of bytes transferred from the source file to the destination file since the copy operation began.</param>
    /// <param name="StreamSize">The total size of the current file stream, in bytes.</param>
    /// <param name="StreamBytesTransferred">The total number of bytes in the current stream that have been transferred from the source file to the destination file since the copy operation began.</param>
    /// <param name="dwStreamNumber">A handle to the current stream. The first time CopyProgressRoutine is called, the stream number is 1.</param>
    /// <param name="dwCallbackReason">The reason that <see cref="CopyProgressRoutine"/> was called. This parameter can be one of the values of the <see cref="CopyProgressCallbackReason"/> enum.</param>
    /// <param name="hSourceFile">A handle to the source file.</param>
    /// <param name="hDestinationFile">A handle to the destination file.</param>
    /// <param name="lpData">Argument passed to CopyProgressRoutine by <see cref="Win32Native.Shell.ShellNativeMethods.CopyFileEx(string, string, CopyProgressRoutine, IntPtr, ref bool, CopyFileFlags)"/>, MoveFileTransacted, or MoveFileWithProgress.</param>
    /// <returns>The CopyProgressRoutine function should return one of the values of the <see cref="CopyProgressResult"/> enum.</returns>
    /// <remarks>An application can use this information to display a progress bar that shows the total number of bytes copied as a percent of the total file size.</remarks>
    public delegate CopyProgressResult CopyProgressRoutine(
        long TotalFileSize,
        long TotalBytesTransferred,
        long StreamSize,
        long StreamBytesTransferred,
        uint dwStreamNumber,
        CopyProgressCallbackReason dwCallbackReason,
        IntPtr hSourceFile,
        IntPtr hDestinationFile,
        IntPtr lpData);

    [Flags]
    public enum FileOpenOptions
    {
        OverwritePrompt = 0x00000002,
        StrictFileTypes = 0x00000004,
        NoChangeDirectory = 0x00000008,
        PickFolders = 0x00000020,
        // Ensure that items returned are filesystem items.
        ForceFilesystem = 0x00000040,
        // Allow choosing items that have no storage.
        AllNonStorageItems = 0x00000080,
        NoValidate = 0x00000100,
        AllowMultiSelect = 0x00000200,
        PathMustExist = 0x00000800,
        FileMustExist = 0x00001000,
        CreatePrompt = 0x00002000,
        ShareAware = 0x00004000,
        NoReadOnlyReturn = 0x00008000,
        NoTestFileCreate = 0x00010000,
        HideMruPlaces = 0x00020000,
        HidePinnedPlaces = 0x00040000,
        NoDereferenceLinks = 0x00100000,
        DontAddToRecent = 0x02000000,
        ForceShowHidden = 0x10000000,
        DefaultNoMiniMode = 0x20000000
    }

    public enum ControlState
    {
        Inactive = 0x00000000,
        Enable = 0x00000001,
        Visible = 0x00000002
    }

    public enum ShellItemDesignNameOptions
    {
        Normal = 0x00000000,           // SIGDN_NORMAL
        ParentRelativeParsing = unchecked((int)0x80018001),   // SIGDN_INFOLDER | SIGDN_FORPARSING
        DesktopAbsoluteParsing = unchecked((int)0x80028000),  // SIGDN_FORPARSING
        ParentRelativeEditing = unchecked((int)0x80031001),   // SIGDN_INFOLDER | SIGDN_FOREDITING
        DesktopAbsoluteEditing = unchecked((int)0x8004c000),  // SIGDN_FORPARSING | SIGDN_FORADDRESSBAR
        FileSystemPath = unchecked((int)0x80058000),             // SIGDN_FORPARSING
        Url = unchecked((int)0x80068000),                     // SIGDN_FORPARSING
        ParentRelativeForAddressBar = unchecked((int)0x8007c001),     // SIGDN_INFOLDER | SIGDN_FORPARSING | SIGDN_FORADDRESSBAR
        ParentRelative = unchecked((int)0x80080001)           // SIGDN_INFOLDER
    }

    public enum FileDialogEventShareViolationResponse
    {
        Default = 0x00000000,
        Accept = 0x00000001,
        Refuse = 0x00000002
    }

    public enum FileDialogEventOverwriteResponse
    {
        Default = 0x00000000,
        Accept = 0x00000001,
        Refuse = 0x00000002
    }

    public enum FileDialogAddPlacement
    {
        Bottom = 0x00000000,
        Top = 0x00000001,
    }

    /// <summary>
    /// Provides attributes for files and directories.
    /// </summary>
    [Flags]
    [ComVisible(true)]
    [System.Serializable]
    public enum FileAttributes
    {
        /// <summary>
        /// The file is read-only. <see cref="ReadOnly"/> is supported on Windows, Linux, and macOS. On Linux and macOS, changing the <see cref="ReadOnly"/> flag is a permissions operation.
        /// </summary>
        ReadOnly = 1,

        /// <summary>
        /// The file is hidden, and thus is not included in an ordinary directory listing. <see cref="Hidden"/> is supported on Windows, Linux, and macOS.
        /// </summary>
        Hidden = 2,

        /// <summary>
        /// The file is a system file. That is, the file is part of the operating system or is used exclusively by the operating system.
        /// </summary>
        System = 4,

        /// <summary>
        /// The file is a directory. <see cref="Directory"/> is supported on Windows, Linux, and macOS.
        /// </summary>
        Directory = 16,

        /// <summary>
        /// This file is marked to be included in incremental backup operation. Windows sets this attribute whenever the file is modified, and backup software should clear it when processing the file during incremental backup.
        /// </summary>
        Archive = 32,

        /// <summary>
        /// Reserved for future use.
        /// </summary>
        Device = 64,

        /// <summary>
        /// The file is a standard file that has no special attributes. This attribute is valid only if it is used alone. <see cref="Normal"/> is supported on Windows, Linux, and macOS.
        /// </summary>
        Normal = 128,

        /// <summary>
        /// The file is temporary. A temporary file contains data that is needed while an application is executing but is not needed after the application is finished. File systems try to keep all the data in memory for quicker access rather than flushing the data back to mass storage. A temporary file should be deleted by the application as soon as it is no longer needed.
        /// </summary>
        Temporary = 256,

        /// <summary>
        /// The file is a sparse file. Sparse files are typically large files whose data consists of mostly zeros.
        /// </summary>
        SparseFile = 512,

        /// <summary>
        /// The file contains a reparse point, which is a block of user-defined data associated with a file or a directory. <see cref="ReparsePoint"/> is supported on Windows, Linux, and macOS.
        /// </summary>
        ReparsePoint = 1024,

        /// <summary>
        /// The file is compressed.
        /// </summary>
        Compressed = 2048,

        /// <summary>
        /// The file is offline. The data of the file is not immediately available.
        /// </summary>
        Offline = 4096,

        /// <summary>
        /// The file will not be indexed by the operating system's content indexing service.
        /// </summary>
        NotContentIndexed = 8192,

        /// <summary>
        /// The file or directory is encrypted. For a file, this means that all data in the file is encrypted. For a directory, this means that encryption is the default for newly created files and directories.
        /// </summary>
        Encrypted = 16384,

        /// <summary>
        /// The file or directory includes data integrity support. When this value is applied to a file, all data streams in the file have integrity support. When this value is applied to a directory, all new files and subdirectories within that directory, by default, include integrity support.
        /// </summary>
        IntegrityStream = 32768,

        /// <summary>
        /// This value is reserved for system use.
        /// </summary>
        Virtual = 65536,

        /// <summary>
        /// The file or directory is excluded from the data integrity scan. When this value is applied to a directory, by default, all new files and subdirectories within that directory are excluded from data integrity.
        /// </summary>
        NoScrubData = 131072,

        /// <summary>
        /// This attribute only appears in directory enumeration classes (FILE_DIRECTORY_INFORMATION, FILE_BOTH_DIR_INFORMATION, etc.). When this attribute is set, it means that the file or directory has no physical representation on the local system; the item is virtual. Opening the item will be more expensive than normal, e.g. it will cause at least some of it to be fetched from a remote store.
        /// </summary>
        RecallOnOpen = 262144,

        Pinned = 524288,

        Unpinned = 1048576,

        /// <summary>
        /// Same as <see cref="RecallOnOpen"/>
        /// </summary>
        EA = RecallOnOpen,

        /// <summary>
        /// When this attribute is set, it means that the file or directory is not fully present locally. For a file that means that not all of its data is on local storage (e.g. it may be sparse with some data still in remote storage). For a directory it means that some of the directory contents are being virtualized from another location. Reading the file / enumerating the directory will be more expensive than normal, e.g. it will cause at least some of the file/directory content to be fetched from a remote store. Only kernel-mode callers can set this bit.
        /// </summary>
        RecallOnDataAccess = 4194304
    }

    [Flags]
    public enum GetFileInfoOptions : uint
    {

        /// <summary>
        /// Apply the appropriate overlays to the file's icon. The <see cref="Icon"/> flag must also be set. <b>Windows ME or higher.</b>
        /// </summary>
        AddOverlays = 0x000000020,

        /// <summary>
        /// Modify <see cref="Attributes"/> to indicate that the <see cref="SHFILEINFO.dwAttributes"/> member of the <see cref="SHFILEINFO"/> structure at <b>psfi</b> contains the specific attributes that are desired. These attributes are passed to <see cref="IShellFolder.GetAttributesOf"/>. If this flag is not specified, 0xFFFFFFFF is passed to <see cref="IShellFolder.GetAttributesOf"/>, requesting all attributes. This flag cannot be specified with the <see cref="Icon"/> flag.
        /// </summary>
        AttributesSpecified = 0x000020000,

        /// <summary>
        /// Retrieve the item attributes. The attributes are copied to the <see cref="SHFILEINFO.dwAttributes"/> member of the structure specified in the <b>psfi</b> parameter. These are the same attributes that are obtained from <see cref="IShellFolder.GetAttributesOf"/>.
        /// </summary>
        Attributes = 0x000000800,

        /// <summary>
        /// Retrieve the display name for the file, which is the name as it appears in Windows Explorer. The name is copied to the <see cref="SHFILEINFO.szDisplayName"/> member of the structure specified in <b>psfi</b>. The returned display name uses the long file name, if there is one, rather than the 8.3 form of the file name. Note that the display name can be affected by settings such as whether extensions are shown.
        /// </summary>
        DisplayName = 0x000000200,

        /// <summary>
        /// Retrieve the type of the executable file if <b>pszPath</b> identifies an executable file. The information is packed into the return value. This flag cannot be specified with any other flags.
        /// </summary>
        ExeType = 0x000002000,

        /// <summary>
        /// Retrieve the handle to the icon that represents the file and the index of the icon within the system image list. The handle is copied to the <see cref="SHFILEINFO.hIcon"/> member of the structure specified by <b>psfi</b>, and the index is copied to the <see cref="SHFILEINFO.iIcon"/> member.
        /// </summary>
        Icon = 0x000000100,

        /// <summary>
        /// Retrieve the name of the file that contains the icon representing the file specified by <b>pszPath</b>, as returned by the <see cref="IExtractIcon.GetIconLocation"/> method of the file's icon handler. Also retrieve the icon index within that file. The name of the file containing the icon is copied to the <see cref="SHFILEINFO.szDisplayName"/> member of the structure specified by <b>psfi</b>. The icon's index is copied to that structure's <see cref="SHFILEINFO.iIcon"/> member.
        /// </summary>
        IconLocation = 0x000001000,

        /// <summary>
        /// Modify <see cref="Icon"/>, causing the function to retrieve the file's large icon. The <see cref="Icon"/> flag must also be set.
        /// </summary>
        LargeIcon = 0x000000000,

        /// <summary>
        /// Modify <see cref="Icon"/>, causing the function to add the link overlay to the file's icon. The <see cref="Icon"/> flag must also be set.
        /// </summary>
        LinkOverlay = 0x000008000,

        /// <summary>
        /// Modify <see cref="Icon"/>, causing the function to retrieve the file's open icon. Also used to modify <see cref="SysIconIndex"/>, causing the function to return the handle to the system image list that contains the file's small open icon. A container object displays an open icon to indicate that the container is open. The <see cref="Icon"/> and/or <see cref="SysIconIndex"/> flag must also be set.
        /// </summary>
        OpenIcon = 0x000000002,

        /// <summary>
        /// Return the index of the overlay icon. The value of the overlay index is returned in the upper eight bits of the <see cref="SHFILEINFO.iIcon"/> member of the structure specified by <b>psfi</b>. This flag requires that the <see cref="Icon"/> be set as well. <b>Windows ME or higher.</b>
        /// </summary>
        OverlayIndex = 0x000000040,

        /// <summary>
        /// Indicate that <b>pszPath</b> is the address of an <see cref="ITEMIDLIST"/> structure rather than a path name.
        /// </summary>
        PIDL = 0x000000008,

        /// <summary>
        /// Modify <see cref="Icon"/>, causing the function to blend the file's icon with the system highlight color. The <see cref="Icon"/> flag must also be set.
        /// </summary>
        Selected = 0x000010000,

        /// <summary>
        /// Modify <see cref="Icon"/>, causing the function to retrieve a Shell-sized icon. If this flag is not specified the function sizes the icon according to the system metric values. The <see cref="Icon"/> flag must also be set.
        /// </summary>
        ShelliconSize = 0x000000004,

        /// <summary>
        /// Modify <see cref="Icon"/>, causing the function to retrieve the file's small icon. Also used to modify <see cref="SysIconIndex"/>, causing the function to return the handle to the system image list that contains small icon images. The <see cref="Icon"/> and/or <see cref="SysIconIndex"/> flag must also be set.
        /// </summary>
        SmallIcon = 0x000000001,

        /// <summary>
        /// Retrieve the index of a system image list icon. If successful, the index is copied to the <see cref="SHFILEINFO.iIcon"/> member of <b>psfi</b>. The return value is a handle to the system image list. Only those images whose indices are successfully copied to iIcon are valid. Attempting to access other images in the system image list will result in undefined behavior.
        /// </summary>
        SysIconIndex = 0x000004000,

        /// <summary>
        /// Retrieve the string that describes the file's type. The string is copied to the <see cref="SHFILEINFO.szTypeName"/> member of the structure specified in <b>psfi</b>.
        /// </summary>
        TypeName = 0x000000400,

        /// <summary>
        /// Indicates that the function should not attempt to access the file specified by <b>pszPath</b>. Rather, it should act as if the file specified by <b>pszPath</b> exists with the file attributes passed in <b>dwFileAttributes</b>. This flag cannot be combined with the <see cref="Attributes"/>, <see cref="ExeType"/>, or <see cref="PIDL"/> flags.
        /// </summary>
        UseFileAttributes = 0x000000010

    }

}

namespace Microsoft.WindowsAPICodePack.Win32Native.Shell
{

        #region Shell Structs

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public struct FilterSpec
        {
            [MarshalAs(UnmanagedType.LPWStr)]
            public string Name;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string Spec;

            public FilterSpec(string name, string spec)
            {
                Name = name;
                Spec = spec;
            }
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public struct ThumbnailId
        {
            [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 16)]
            public byte rgbKey;
        }

        /// <summary>
        /// Contains information about a file object.
        /// </summary>
        /// <remarks>This structure is used with the <see cref="SHGetFileInfo"/> function.</remarks>
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public struct SHFILEINFO
        {

            /// <summary>
            /// A handle to the icon that represents the file. You are responsible for destroying this handle with DestroyIcon when you no longer need it.
            /// </summary>
            public IntPtr hIcon;

            /// <summary>
            /// The index of the icon image within the system image list.
            /// </summary>
            public int iIcon;

            /// <summary>
            /// An array of values that indicates the attributes of the file object. For information about these values, see the <see cref="IShellFolder.GetAttributesOf"/> method.
            /// </summary>
            public ShellFileGetAttributesOptions dwAttributes;

            /// <summary>
            /// A string that contains the name of the file as it appears in the Windows Shell, or the path and file name of the file that contains the icon representing the file.
            /// </summary>
            [MarshalAs(UnmanagedType.BStr)]
            public string szDisplayName;

            /// <summary>
            /// A string that describes the type of file.
            /// </summary>
            [MarshalAs(UnmanagedType.BStr)]
            public string szTypeName;

        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct SHQUERYRBINFO
        {
            public int cbSize;
            public long i64Size;
            public long i64NumItems;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct ShellNotifyStruct
        {
            public IntPtr item1;
            public IntPtr item2;
        };

        [StructLayout(LayoutKind.Sequential)]
        public struct SHChangeNotifyEntry
        {
            public IntPtr pIdl;

            [MarshalAs(UnmanagedType.Bool)]
            public bool recursively;
        }

        #endregion

        #region Shell Library Enums

        public enum LibraryFolderFilter
        {
            ForceFileSystem = 1,
            StorageItems = 2,
            AllItems = 3
        };

        [Flags]
        public enum LibraryOptions
        {
            Default = 0,
            PinnedToNavigationPane = 0x1,
            MaskAll = 0x1
        };

        public enum DefaultSaveFolderType
        {
            Detect = 1,
            Private = 2,
            Public = 3
        };

        public enum LibrarySaveOptions
        {
            FailIfThere = 0,
            OverrideExisting = 1,
            MakeUniqueName = 2
        };

        public enum LibraryManageDialogOptions
        {
            Default = 0,
            NonIndexableLocationWarning = 1
        };


        #endregion

        #region Shell Enums

        [Flags]
        public enum ShellChangeNotifyEventSource
        {
            InterruptLevel = 0x0001,
            ShellLevel = 0x0002,
            RecursiveInterrupt = 0x1000,
            NewDelivery = 0x8000
        }

        /// <summary>
        /// Indicate flags that modify the property store object retrieved by methods 
        /// that create a property store, such as IShellItem2::GetPropertyStore or 
        /// IPropertyStoreFactory::GetPropertyStore.
        /// </summary>
        [Flags]
        public enum GetPropertyStoreOptions
        {
            /// <summary>
            /// Meaning to a calling process: Return a read-only property store that contains all 
            /// properties. Slow items (offline files) are not opened. 
            /// Combination with other flags: Can be overridden by other flags.
            /// </summary>
            Default = 0,

            /// <summary>
            /// Meaning to a calling process: Include only properties directly from the property
            /// handler, which opens the file on the disk, network, or device. Meaning to a file 
            /// folder: Only include properties directly from the handler.
            /// 
            /// Meaning to other folders: When delegating to a file folder, pass this flag on 
            /// to the file folder; do not do any multiplexing (MUX). When not delegating to a 
            /// file folder, ignore this flag instead of returning a failure code.
            /// 
            /// Combination with other flags: Cannot be combined with GPS_TEMPORARY, 
            /// GPS_FASTPROPERTIESONLY, or GPS_BESTEFFORT.
            /// </summary>
            HandlePropertiesOnly = 0x1,

            /// <summary>
            /// Meaning to a calling process: Can write properties to the item. 
            /// Note: The store may contain fewer properties than a read-only store. 
            /// 
            /// Meaning to a file folder: ReadWrite.
            /// 
            /// Meaning to other folders: ReadWrite. Note: When using default MUX, 
            /// return a single unmultiplexed store because the default MUX does not support ReadWrite.
            /// 
            /// Combination with other flags: Cannot be combined with GPS_TEMPORARY, GPS_FASTPROPERTIESONLY, 
            /// GPS_BESTEFFORT, or GPS_DELAYCREATION. Implies GPS_HANDLERPROPERTIESONLY.
            /// </summary>
            ReadWrite = 0x2,

            /// <summary>
            /// Meaning to a calling process: Provides a writable store, with no initial properties, 
            /// that exists for the lifetime of the Shell item instance; basically, a property bag 
            /// attached to the item instance. 
            /// 
            /// Meaning to a file folder: Not applicable. Handled by the Shell item.
            /// 
            /// Meaning to other folders: Not applicable. Handled by the Shell item.
            /// 
            /// Combination with other flags: Cannot be combined with any other flag. Implies GPS_READWRITE
            /// </summary>
            Temporary = 0x4,

            /// <summary>
            /// Meaning to a calling process: Provides a store that does not involve reading from the 
            /// disk or network. Note: Some values may be different, or missing, compared to a store 
            /// without this flag. 
            /// 
            /// Meaning to a file folder: Include the "innate" and "fallback" stores only. Do not load the handler.
            /// 
            /// Meaning to other folders: Include only properties that are available in memory or can 
            /// be computed very quickly (no properties from disk, network, or peripheral IO devices). 
            /// This is normally only data sources from the IDLIST. When delegating to other folders, pass this flag on to them.
            /// 
            /// Combination with other flags: Cannot be combined with GPS_TEMPORARY, GPS_READWRITE, 
            /// GPS_HANDLERPROPERTIESONLY, or GPS_DELAYCREATION.
            /// </summary>
            FastPropertiesOnly = 0x8,

            /// <summary>
            /// Meaning to a calling process: Open a slow item (offline file) if necessary. 
            /// Meaning to a file folder: Retrieve a file from offline storage, if necessary. 
            /// Note: Without this flag, the handler is not created for offline files.
            /// 
            /// Meaning to other folders: Do not return any properties that are very slow.
            /// 
            /// Combination with other flags: Cannot be combined with GPS_TEMPORARY or GPS_FASTPROPERTIESONLY.
            /// </summary>
            OpensLowItem = 0x10,

            /// <summary>
            /// Meaning to a calling process: Delay memory-intensive operations, such as file access, until 
            /// a property is requested that requires such access. 
            /// 
            /// Meaning to a file folder: Do not create the handler until needed; for example, either 
            /// GetCount/GetAt or GetValue, where the innate store does not satisfy the request. 
            /// Note: GetValue might fail due to file access problems.
            /// 
            /// Meaning to other folders: If the folder has memory-intensive properties, such as 
            /// delegating to a file folder or network access, it can optimize performance by 
            /// supporting IDelayedPropertyStoreFactory and splitting up its properties into a 
            /// fast and a slow store. It can then use delayed MUX to recombine them.
            /// 
            /// Combination with other flags: Cannot be combined with GPS_TEMPORARY or 
            /// GPS_READWRITE
            /// </summary>
            DelayCreation = 0x20,

            /// <summary>
            /// Meaning to a calling process: Succeed at getting the store, even if some 
            /// properties are not returned. Note: Some values may be different, or missing,
            /// compared to a store without this flag. 
            /// 
            /// Meaning to a file folder: Succeed and return a store, even if the handler or 
            /// innate store has an error during creation. Only fail if substores fail.
            /// 
            /// Meaning to other folders: Succeed on getting the store, even if some properties 
            /// are not returned.
            /// 
            /// Combination with other flags: Cannot be combined with GPS_TEMPORARY, 
            /// GPS_READWRITE, or GPS_HANDLERPROPERTIESONLY.
            /// </summary>
            BestEffort = 0x40,

            /// <summary>
            /// Mask for valid GETPROPERTYSTOREFLAGS values.
            /// </summary>
            MaskValid = 0xff,
        }

        public enum ShellItemAttributeOptions
        {
            // if multiple items and the attirbutes together.
            And = 0x00000001,
            // if multiple items or the attributes together.
            Or = 0x00000002,
            // Call GetAttributes directly on the 
            // ShellFolder for multiple attributes.
            AppCompat = 0x00000003,

            // A mask for SIATTRIBFLAGS_AND, SIATTRIBFLAGS_OR, and SIATTRIBFLAGS_APPCOMPAT. Callers normally do not use this value.
            Mask = 0x00000003,

            // Windows 7 and later. Examine all items in the array to compute the attributes. 
            // Note that this can result in poor performance over large arrays and therefore it 
            // should be used only when needed. Cases in which you pass this flag should be extremely rare.
            AllItems = 0x00004000
        }

        [Flags]
        public enum SIIGBF
        {
            ResizeToFit = 0x00,
            BiggerSizeOk = 0x01,
            MemoryOnly = 0x02,
            IconOnly = 0x04,
            ThumbnailOnly = 0x08,
            InCacheOnly = 0x10,
        }

        [Flags]
        public enum ThumbnailOptions
        {
            Extract = 0x00000000,
            InCacheOnly = 0x00000001,
            FastExtract = 0x00000002,
            ForceExtraction = 0x00000004,
            SlowReclaim = 0x00000008,
            ExtractDoNotCache = 0x00000020
        }

        [Flags]
        public enum ThumbnailCacheOptions
        {
            Default = 0x00000000,
            LowQuality = 0x00000001,
            Cached = 0x00000002,
        }

        [Flags]
        public enum ShellFileGetAttributesOptions
        {
            /// <summary>
            /// The specified items can be copied.
            /// </summary>
            CanCopy = 0x00000001,

            /// <summary>
            /// The specified items can be moved.
            /// </summary>
            CanMove = 0x00000002,

            /// <summary>
            /// Shortcuts can be created for the specified items. This flag has the same value as DROPEFFECT. 
            /// The normal use of this flag is to add a Create Shortcut item to the shortcut menu that is displayed 
            /// during drag-and-drop operations. However, SFGAO_CANLINK also adds a Create Shortcut item to the Microsoft 
            /// Windows Explorer's File menu and to normal shortcut menus. 
            /// If this item is selected, your application's IContextMenu::InvokeCommand is invoked with the lpVerb 
            /// member of the CMINVOKECOMMANDINFO structure set to "link." Your application is responsible for creating the link.
            /// </summary>
            CanLink = 0x00000004,

            /// <summary>
            /// The specified items can be bound to an IStorage interface through IShellFolder::BindToObject.
            /// </summary>
            Storage = 0x00000008,

            /// <summary>
            /// The specified items can be renamed.
            /// </summary>
            CanRename = 0x00000010,

            /// <summary>
            /// The specified items can be deleted.
            /// </summary>
            CanDelete = 0x00000020,

            /// <summary>
            /// The specified items have property sheets.
            /// </summary>
            HasPropertySheet = 0x00000040,

            /// <summary>
            /// The specified items are drop targets.
            /// </summary>
            DropTarget = 0x00000100,

            /// <summary>
            /// This flag is a mask for the capability flags.
            /// </summary>
            CapabilityMask = 0x00000177,

            /// <summary>
            /// Windows 7 and later. The specified items are system items.
            /// </summary>
            System = 0x00001000,

            /// <summary>
            /// The specified items are encrypted.
            /// </summary>
            Encrypted = 0x00002000,

            /// <summary>
            /// Indicates that accessing the object = through IStream or other storage interfaces, 
            /// is a slow operation. 
            /// Applications should avoid accessing items flagged with SFGAO_ISSLOW.
            /// </summary>
            IsSlow = 0x00004000,

            /// <summary>
            /// The specified items are ghosted icons.
            /// </summary>
            Ghosted = 0x00008000,

            /// <summary>
            /// The specified items are shortcuts.
            /// </summary>
            Link = 0x00010000,

            /// <summary>
            /// The specified folder objects are shared.
            /// </summary>    
            Share = 0x00020000,

            /// <summary>
            /// The specified items are read-only. In the case of folders, this means 
            /// that new items cannot be created in those folders.
            /// </summary>
            ReadOnly = 0x00040000,

            /// <summary>
            /// The item is hidden and should not be displayed unless the 
            /// Show hidden files and folders option is enabled in Folder Settings.
            /// </summary>
            Hidden = 0x00080000,

            /// <summary>
            /// This flag is a mask for the display attributes.
            /// </summary>
            DisplayAttributeMask = 0x000FC000,

            /// <summary>
            /// The specified folders contain one or more file system folders.
            /// </summary>
            FileSystemAncestor = 0x10000000,

            /// <summary>
            /// The specified items are folders.
            /// </summary>
            Folder = 0x20000000,

            /// <summary>
            /// The specified folders or file objects are part of the file system 
            /// that is, they are files, directories, or root directories).
            /// </summary>
            FileSystem = 0x40000000,

            /// <summary>
            /// The specified folders have subfolders = and are, therefore, 
            /// expandable in the left pane of Windows Explorer).
            /// </summary>
            HasSubFolder = unchecked((int)0x80000000),

            /// <summary>
            /// This flag is a mask for the contents attributes.
            /// </summary>
            ContentsMask = unchecked((int)0x80000000),

            /// <summary>
            /// When specified as input, SFGAO_VALIDATE instructs the folder to validate that the items 
            /// pointed to by the contents of apidl exist. If one or more of those items do not exist, 
            /// IShellFolder::GetAttributesOf returns a failure code. 
            /// When used with the file system folder, SFGAO_VALIDATE instructs the folder to discard cached 
            /// properties retrieved by clients of IShellFolder2::GetDetailsEx that may 
            /// have accumulated for the specified items.
            /// </summary>
            Validate = 0x01000000,

            /// <summary>
            /// The specified items are on removable media or are themselves removable devices.
            /// </summary>
            Removable = 0x02000000,

            /// <summary>
            /// The specified items are compressed.
            /// </summary>
            Compressed = 0x04000000,

            /// <summary>
            /// The specified items can be browsed in place.
            /// </summary>
            Browsable = 0x08000000,

            /// <summary>
            /// The items are nonenumerated items.
            /// </summary>
            Nonenumerated = 0x00100000,

            /// <summary>
            /// The objects contain new content.
            /// </summary>
            NewContent = 0x00200000,

            /// <summary>
            /// It is possible to create monikers for the specified file objects or folders.
            /// </summary>
            CanMoniker = 0x00400000,

            /// <summary>
            /// Not supported.
            /// </summary>
            HasStorage = 0x00400000,

            /// <summary>
            /// Indicates that the item has a stream associated with it that can be accessed 
            /// by a call to IShellFolder::BindToObject with IID_IStream in the riid parameter.
            /// </summary>
            Stream = 0x00400000,

            /// <summary>
            /// Children of this item are accessible through IStream or IStorage. 
            /// Those children are flagged with SFGAO_STORAGE or SFGAO_STREAM.
            /// </summary>
            StorageAncestor = 0x00800000,

            /// <summary>
            /// This flag is a mask for the storage capability attributes.
            /// </summary>
            StorageCapabilityMask = 0x70C50008,

            /// <summary>
            /// Mask used by PKEY_SFGAOFlags to remove certain values that are considered 
            /// to cause slow calculations or lack context. 
            /// Equal to SFGAO_VALIDATE | SFGAO_ISSLOW | SFGAO_HASSUBFOLDER.
            /// </summary>
            PkeyMask = unchecked((int)0x81044000),
        }

        [Flags]
        public enum ShellFolderEnumerationOptions : ushort
        {
            CheckingForChildren = 0x0010,
            Folders = 0x0020,
            NonFolders = 0x0040,
            IncludeHidden = 0x0080,
            InitializeOnFirstNext = 0x0100,
            NetPrinterSearch = 0x0200,
            Shareable = 0x0400,
            Storage = 0x0800,
            NavigationEnum = 0x1000,
            FastItems = 0x2000,
            FlatList = 0x4000,
            EnableAsync = 0x8000
        }

        #endregion

    public static class ShellNativeMethods
    {

        #region Shell Helper Methods

        /// <summary>
        /// Retrieves information about an object in the file system, such as a file, folder, directory, or drive root.
        /// </summary>
        /// <param name="pszPath"><para>A string of maximum length <see cref="MaxPath"/> that contains the path and file name. Both absolute and relative paths are valid.</para>
        /// <para>If the <b>uFlags</b> parameter includes the <see cref="GetFileInfoOptions.PIDL"/> flag, this parameter must be the address of an ITEMIDLIST(PIDL) structure that contains the list of item identifiers that uniquely identifies the file within the Shell's namespace. The PIDL must be a fully qualified PIDL. Relative PIDLs are not allowed.</para>
        /// <para>If the <b>uFlags</b> parameter includes the <see cref="GetFileInfoOptions.UseFileAttributes"/> flag, this parameter does not have to be a valid file name. The function will proceed as if the file exists with the specified name and with the file attributes passed in the <b>dwFileAttributes</b> parameter. This allows you to obtain information about a file type by passing just the extension for <b>pszPath</b> and passing <see cref="FileAttributes.Normal"/> in <b>dwFileAttributes</b>.</para>
        /// <para>This string can use either short (the 8.3 form) or long file names.</para></param>
        /// <param name="dwFileAttributes">A combination of one or more <see cref="FileAttributes"/> flags. If <b>uFlags</b> does not include the <see cref="GetFileInfoOptions.UseFileAttributes"/> flag, this parameter is ignored.</param>
        /// <param name="psfi">A <see cref="SHFILEINFO"/> structure to receive the file information.</param>
        /// <param name="cbFileInfo">The size, in bytes, of the <see cref="SHFILEINFO"/> structure pointed to by the <b>psfi</b> parameter.</param>
        /// <param name="uFlags">The flags that specify the file information to retrieve. This parameter can be a combination of the values of the <see cref="GetFileInfoOptions"/> enum.</param>
        /// <returns><para>Returns a value whose meaning depends on the <b>uFlags</b> parameter.</para>
        /// <para>If <b>uFlags</b> does not contain <see cref="GetFileInfoOptions.ExeType"/> or <see cref="GetFileInfoOptions.SysIconIndex"/>, the return value is nonzero if successful, or zero otherwise.</para>
        /// <para>If <b>uFlags</b> contains the <see cref="GetFileInfoOptions.ExeType"/> flag, the return value specifies the type of the executable file. It will be one of the following values.</para>
        /// Return code                                    | Description
        /// -----------------------------------------------+------------------------------------------
        /// 0                                              | Nonexecutable file or an error condition.
        /// LOWORD = NE or PE and HIWORD = Windows version | Windows application.
        /// LOWORD = MZ and HIWORD = 0                     | MS-DOS.exe or .com file
        /// LOWORD = PE and HIWORD = 0                     | Console application or.bat file</returns>
        /// <remarks><para>You should call this function from a background thread. Failure to do so could cause the UI to stop responding.</para>
        /// <para>If <see cref="SHGetFileInfo"/> returns an icon handle in the <b>hIcon</b> member of the <see cref="SHFILEINFO"/> structure pointed to by <b>psfi</b>, you are responsible for freeing it with <see cref="CoreNativeMethods.DestroyIcon"/> when you no longer need it.</para>
        /// <para>Note: Once you have a handle to a system image list, you can use the <b>Image List API</b> to manipulate it like any other image list. Because system image lists are created on a per-process basis, you should treat them as read-only objects. Writing to a system image list may overwrite or delete one of the system images, making it unavailable or incorrect for the remainder of the process.</para>
        /// <para>When you use the <see cref="GetFileInfoOptions.ExeType"/> flag with a Windows application, the Windows version of the executable is given in the HIWORD of the return value. This version is returned as a hexadecimal value. For details on equating this value with a specific Windows version, see <a href="https://docs.microsoft.com/windows/desktop/WinProg/using-the-windows-headers">Using the Windows Headers</a>.</para></remarks>
        [DllImport("shell32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern HResult SHGetFileInfo(string pszPath, FileAttributes dwFileAttributes, out SHFILEINFO psfi, uint cbFileInfo, GetFileInfoOptions uFlags);

        [DllImport("shell32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern int SHCreateShellItemArrayFromDataObject(
            System.Runtime.InteropServices.ComTypes.IDataObject pdo,
            ref Guid riid,
            [MarshalAs(UnmanagedType.Interface)] out IShellItemArray iShellItemArray);

        [DllImport("shell32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern int SHCreateItemFromParsingName(
            [MarshalAs(UnmanagedType.LPWStr)] string path,
            // The following parameter is not used - binding context.
            IntPtr pbc,
            ref Guid riid,
            [MarshalAs(UnmanagedType.Interface)] out IShellItem2 shellItem);

        [DllImport("shell32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern int SHCreateItemFromParsingName(
            [MarshalAs(UnmanagedType.LPWStr)] string path,
            // The following parameter is not used - binding context.
            IntPtr pbc,
            ref Guid riid,
            [MarshalAs(UnmanagedType.Interface)] out IShellItem shellItem);

        [DllImport("shlwapi.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern int PathParseIconLocation(
            [MarshalAs(UnmanagedType.LPWStr)] ref string pszIconFile);


        [DllImport("shell32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern int SHCreateItemFromIDList(
            /*PCIDLIST_ABSOLUTE*/ IntPtr pidl,
            ref Guid riid,
            [MarshalAs(UnmanagedType.Interface)] out IShellItem2 ppv);

        [DllImport("shell32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern int SHParseDisplayName(
            [MarshalAs(UnmanagedType.LPWStr)] string pszName,
            IntPtr pbc,
            out IntPtr ppidl,
            ShellFileGetAttributesOptions sfgaoIn,
            out ShellFileGetAttributesOptions psfgaoOut
        );

        [DllImport("shell32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern int SHGetIDListFromObject(IntPtr iUnknown,
            out IntPtr ppidl
        );

        [DllImport("shell32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern int SHGetDesktopFolder(
            [MarshalAs(UnmanagedType.Interface)] out IShellFolder ppshf
        );

        [DllImport("shell32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern int SHCreateShellItem(
            IntPtr pidlParent,
            [In, MarshalAs(UnmanagedType.Interface)] IShellFolder psfParent,
            IntPtr pidl,
            [MarshalAs(UnmanagedType.Interface)] out IShellItem ppsi
        );

        [DllImport("shell32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern uint ILGetSize(IntPtr pidl);

        [DllImport("shell32.dll", CharSet = CharSet.None)]
        public static extern void ILFree(IntPtr pidl);

        [DllImport("shell32.dll")]
        public static extern HResult SHQueryRecycleBin(string pszRootPath, ref SHQUERYRBINFO
   pSHQueryRBInfo);

        [DllImport("shell32.dll")]
        public static extern HResult SHEmptyRecycleBin(IntPtr hWnd, string pszRootPath, EmptyRecycleBinFlags dwFlags);

        /// <summary>
        /// <para>Copies an existing file to a new file, notifying the application of its progress through a callback function.</para>
        ///
        /// <para>To perform this operation as a transacted operation, use the CopyFileTransacted function.</para>
        /// </summary>
        /// <param name="lpExistingFileName"><para>The name of an existing file.</para>
        ///
        /// <para>In the ANSI version of this function, the name is limited to MAX_PATH characters. To extend this limit to 32,767 wide characters, call the Unicode version of the function and prepend "\?" to the path.For more information, see Naming a File.</para>
        /// <para>Tip Starting in Windows 10, version 1607, for the unicode version of this function (CopyFileExW), you can opt-in to remove the MAX_PATH character limitation without prepending "\\?\". See the "Maximum Path Limitation" section of Naming Files, Paths, and Namespaces for details.</para>
        ///
        ///<para>If lpExistingFileName does not exist, the <see cref="CopyFileEx(string, string, CopyProgressRoutine, IntPtr, ref bool, CopyFileFlags)"/> function fails, and the <see cref="Marshal. GetLastWin32Error"/> function returns <see cref="ErrorCode.ERROR_FILE_NOT_FOUND"/>.</para></param>
        /// <param name="lpNewFileName"><para>The name of the new file.</para>
        ///
        /// <para>In the ANSI version of this function, the name is limited to MAX_PATH characters. To extend this limit to 32,767 wide characters, call the Unicode version of the function and prepend "\?" to the path.For more information, see Naming a File.</para>
        ///
        /// <para>Tip Starting inWindows 10, version 1607, for the unicode version of this function (CopyFileExW), you can opt-in to remove the MAX_PATH character limitation without prepending "\\?\". See the "Maximum Path Limitation" section of Naming Files, Paths, and Namespaces for details.</para></param>
        /// <param name="lpProgressRoutine">The address of a callback function of type <see cref="CopyProgressRoutine"/> that is called each time another portion of the file has been copied. This parameter can be <see langword="null"/>. For more information on the progress callback function, see the <see cref="CopyProgressRoutine"/> function.</param>
        /// <param name="lpData">The argument to be passed to the callback function. This parameter can be <see langword="null"/>.</param>
        /// <param name="pbCancel">If this flag is set to <see langword="true"/> during the copy operation, the operation is canceled. Otherwise, the copy operation will continue to completion.</param>
        /// <param name="dwCopyFlags">Flags that specify how the file is to be copied. This parameter can be a combination of the <see cref="CopyFileFlags"/> enum.</param>
        /// <returns><para>If the function succeeds, the return value is nonzero.</para>
        ///
        /// <para>If the function fails, the return value is zero.To get extended error information call <see cref="Marshal.GetLastWin32Error"/>.</para>
        ///
        /// <para>If lpProgressRoutine returns <see cref="CopyProgressResult.Cancel"/> due to the user canceling the operation, <see cref="CopyFileEx(string, string, CopyProgressRoutine, IntPtr, ref bool, CopyFileFlags)"/> will return zero and <see cref="Marshal.GetLastWin32Error"/> will return <see cref="ErrorCode.ERROR_REQUEST_ABORTED"/>. In this case, the partially copied destination file is deleted.</para>
        ///
        /// <para>If lpProgressRoutine returns <see cref="CopyProgressResult.Stop"/> due to the user stopping the operation, <see cref="CopyFileEx(string, string, CopyProgressRoutine, IntPtr, ref bool, CopyFileFlags)"/> will return zero and <see cref="Marshal.GetLastWin32Error"/> will return <see cref="ErrorCode.ERROR_REQUEST_ABORTED"/>. In this case, the partially copied destination file is left intact.</para></returns>
        /// <remarks><para>This function preserves extended attributes, OLE structured storage, NTFS file system alternate data streams, security resource attributes, and file attributes.</para>
        ///
        /// <para>Windows 7, Windows Server 2008 R2, Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP:  Security resource attributes (ATTRIBUTE_SECURITY_INFORMATION) for the existing file are not copied to the new file until Windows 8 and Windows Server 2012.</para>
        ///
        /// <para>The security resource properties(ATTRIBUTE_SECURITY_INFORMATION) for the existing file are copied to the new file.</para>
        ///
        /// <para>Windows 7, Windows Server 2008 R2, Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP:  Security resource properties for the existing file are not copied to the new file until Windows 8 and Windows Server 2012.</para>
        ///
        /// <para>This function fails with <see cref="HResult.AccessDenied"/> if the destination file already exists and has the <see cref="System.IO.FileAttributes.Hidden"/> or <see cref="System.IO.FileAttributes.ReadOnly"/> attribute set.</para>
        ///
        /// <para>When encrypted files are copied using <see cref="CopyFileEx(string, string, CopyProgressRoutine, IntPtr, ref bool, CopyFileFlags)"/>, the function attempts to encrypt the destination file with the keys used in the encryption of the source file.If this cannot be done, this function attempts to encrypt the destination file with default keys.If both of these methods cannot be done, <see cref="CopyFileEx(string, string, CopyProgressRoutine, IntPtr, ref bool, CopyFileFlags)"/> fails with an <see cref="ErrorCode.ERROR_ENCRYPTION_FAILED"/> error code. If you want <see cref="CopyFileEx(string, string, CopyProgressRoutine, IntPtr, ref bool, CopyFileFlags)"/> to complete the copy operation even if the destination file cannot be encrypted, include the <see cref="CopyFileFlags.AllowDecryptedDestination"/> as the value of the dwCopyFlags parameter in your call to <see cref="CopyFileEx(string, string, CopyProgressRoutine, IntPtr, ref bool, CopyFileFlags)"/>.</para>
        ///
        /// If <see cref="CopyFileFlags.CopySymLink"/> is specified, the following rules apply:
        ///
        /// If the source file is a symbolic link, the symbolic link is copied, not the target file.
        /// If the source file is not a symbolic link, there is no change in behavior.
        /// If the destination file is an existing symbolic link, the symbolic link is overwritten, not the target file.
        /// If <see cref="CopyFileFlags.FailIfExists"/> is also specified, and the destination file is an existing symbolic link, the operation fails in all cases.
        ///
        /// If <see cref="CopyFileFlags.CopySymLink"/> is not specified, the following rules apply:
        ///
        /// If <see cref="CopyFileFlags.FailIfExists"/> is also specified, and the destination file is an existing symbolic link, the operation fails only if the target of the symbolic link exists.
        /// If <see cref="CopyFileFlags.FailIfExists"/> is not specified, there is no change in behavior.
        ///
        /// Windows 7, Windows Server 2008 R2, Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP:  If you are writing an application that is optimizing file copy operations across a LAN, consider using the TransmitFile function from Windows Sockets(Winsock). TransmitFile supports high-performance network transfers and provides a simple interface to send the contents of a file to a remote computer.To use TransmitFile, you must write a Winsock client application that sends the file from the source computer as well as a Winsock server application that uses other Winsock functions to receive the file on the remote computer.
        ///
        /// In Windows 8 and Windows Server 2012, this function is supported by the following technologies.
        /// Technology Supported
        /// Server Message Block (SMB) 3.0 protocol Yes
        /// SMB 3.0 Transparent Failover (TFO) Yes
        /// SMB 3.0 with Scale-out File Shares (SO) Yes
        /// Cluster Shared Volume File System (CsvFS) Yes
        /// Resilient File System (ReFS) Yes </remarks>

        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CopyFileEx([In, MarshalAs(UnmanagedType.LPWStr)] string lpExistingFileName, [In, MarshalAs(UnmanagedType.LPWStr)] string lpNewFileName,
   [In] CopyProgressRoutine lpProgressRoutine, [In] IntPtr lpData, [In, Out, MarshalAs(UnmanagedType.Bool)] ref bool pbCancel,
   [In, MarshalAs(UnmanagedType.U4)] CopyFileFlags dwCopyFlags);

        [DllImport("gdi32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool DeleteObject(IntPtr hObject);

        #endregion

        #region Shell Library Helper Methods

        [DllImport("Shell32", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Winapi, SetLastError = true)]
        public static extern int SHShowManageLibraryUI(
            [In, MarshalAs(UnmanagedType.Interface)] IShellItem library,
            [In] IntPtr hwndOwner,
            [In] string title,
            [In] string instruction,
            [In] LibraryManageDialogOptions lmdOptions);

        #endregion

        #region Shell notification definitions

        [DllImport("shell32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SHGetPathFromIDListW(IntPtr pidl, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszPath);

        [DllImport("shell32.dll")]
        public static extern uint SHChangeNotifyRegister(
            IntPtr windowHandle,
            ShellChangeNotifyEventSource sources,
            ShellObjectChangeTypes events,
            uint message,
            int entries,
            ref SHChangeNotifyEntry changeNotifyEntry);

        [DllImport("shell32.dll")]
        public static extern IntPtr SHChangeNotification_Lock(
            IntPtr windowHandle,
            int processId,
            out IntPtr pidl,
            out uint lEvent);

        [DllImport("shell32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SHChangeNotification_Unlock(IntPtr hLock);

        [DllImport("shell32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SHChangeNotifyDeregister(uint hNotify);

        #endregion
    }
}
