using System;

namespace Microsoft.WindowsAPICodePack.Win32Native.Shell
{
    /// <summary>
    /// Flags that specify how the file is to be copied.
    /// </summary>
    [Flags]
    public enum CopyFileFlags : uint
    {
        /// <summary>
        /// The copy operation fails immediately if the target file already exists.
        /// </summary>
        FailIfExists = 0x00000001,

        /// <summary>
        /// Progress of the copy is tracked in the target file in case the copy fails. The failed copy can be restarted at a later time by specifying the same values for lpExistingFileName and lpNewFileName as those used in the call that failed. This can significantly slow down the copy operation as the new file may be flushed multiple times during the copy operation.
        /// </summary>
        Restartable = 0x00000002,

        /// <summary>
        /// The file is copied and the original file is opened for write access.
        /// </summary>
        OpenSourceForWrite = 0x00000004,

        /// <summary>
        /// An attempt to copy an encrypted file will succeed even if the destination copy cannot be encrypted.
        /// </summary>
        AllowDecryptedDestination = 0x00000008,

        /// <summary>
        /// If the source file is a symbolic link, the destination file is also a symbolic link pointing to the same file that the source symbolic link is pointing to.
        ///
        /// Windows Server 2003 and Windows XP:  This value is not supported.
        /// </summary>
        CopySymLink = 0x00000800, //NT 6.0+

        /// <summary>
        /// The copy operation is performed using unbuffered I/O, bypassing system I/O cache resources. Recommended for very large file transfers.
        ///
        /// Windows Server 2003 and Windows XP:  This value is not supported.
        /// </summary>
        NoBuffering = 0x00001000 //NT 6.0+
    }

    /// <summary>
    /// Flags that specify how the file is to be moved.
    /// </summary>
    [Flags]
    public enum MoveFileFlags
    {
        /// <summary>
        /// <para>If a file named lpNewFileName exists, the function replaces its contents with the contents of the lpExistingFileName file.</para>
        /// <para>This value cannot be used if lpNewFileName or lpExistingFileName names a directory.</para>
        /// </summary>
        ReplaceExisting = 1,

        /// <summary>
        /// <para>If the file is to be moved to a different volume, the function simulates the move by using the CopyFile and DeleteFile functions.</para>
        /// <para>If the file is successfully copied to a different volume and the original file is unable to be deleted, the function succeeds leaving the source file intact.</para>
        /// <para>This value cannot be used with <see cref="DelayUntilReboot"/>.</para>
        /// </summary>
        CopyAllowed = 2,

        /// <summary>
        /// <para>The system does not move the file until the operating system is restarted. The system moves the file immediately after AUTOCHK is executed, but before creating any paging files. Consequently, this parameter enables the function to delete paging files from previous startups.</para>
        /// <para>This value can only be used if the process is in the context of a user who belongs to the administrators group or the LocalSystem account.
        /// <para>This value cannot be used with <see cref="CopyAllowed"/>.</para></para>
        /// </summary>
        DelayUntilReboot = 4,

        /// <summary>
        /// <para>The function does not return until the file has actually been moved on the disk.</para>
        /// <para>Setting this value guarantees that a move performed as a copy and delete operation is flushed to disk before the function returns. The flush occurs at the end of the copy operation.</para>
        /// <para>This value has no effect if <see cref="DelayUntilReboot"/> is set.</para>
        /// </summary>
        WriteThrough = 8,

        /// <summary>
        /// Reserved for future use.
        /// </summary>
        CreateHardLink = 16,

        /// <summary>
        /// The function fails if the source file is a link source, but the file cannot be tracked after the move. This situation can occur if the destination is a volume formatted with the FAT file system.
        /// </summary>
        FailIfNotTrackable = 32
    }
}
