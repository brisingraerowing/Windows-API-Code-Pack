using System;
using System.Runtime.InteropServices;

namespace Microsoft.WindowsAPICodePack.Win32Native.Shell
{
    public enum FileAccess:uint
    {
        Read = 0x80000000,
        Write = 0x40000000,
        Execute = 0x20000000,
        All = 0x10000000
    }

    /// <summary>
    /// Provides attributes for files and directories.
    /// </summary>
    [Flags]
    [ComVisible(true)]
    [Serializable]
    public enum FileAttributes : uint
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
}
