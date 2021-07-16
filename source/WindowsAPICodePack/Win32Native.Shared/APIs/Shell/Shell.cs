using System;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;

using static Microsoft.WindowsAPICodePack.NativeAPI.Consts.DllNames;
using static Microsoft.WindowsAPICodePack.NativeAPI.Consts.Shell;
using static Microsoft.WindowsAPICodePack.Win32Native.ErrorCode;
using static Microsoft.WindowsAPICodePack.Win32Native.Shell.CopyProgressResult;
using static Microsoft.WindowsAPICodePack.Win32Native.Shell.MoveFileFlags;
using static Microsoft.WindowsAPICodePack.Win32Native.Shell.GetFileInfoOptions;

namespace Microsoft.WindowsAPICodePack.Win32Native.Shell
{
    public static partial class Shell
    {
        #region Shell Helper Methods
        /// <summary>
        /// <para>Moves a file or directory, including its children. You can provide a callback function that receives progress notifications.</para>
        /// <para>To perform this operation as a transacted operation, use the MoveFileTransacted function.</para>
        /// </summary>
        /// <param name="lpExistingFileName"><para>The name of the existing file or directory on the local computer.</para>
        /// <para>If <paramref name="dwFlags"/> specifies <see cref="DelayUntilReboot"/>, the file cannot exist on a remote share because delayed operations are performed before the network is available.</para>
        /// <para>See Remarks section about the <see cref="MaxPath"/> limitation.</para></param>
        /// <param name="lpNewFileName"><para>The new name of the file or directory on the local computer.</para>
        /// <para>When moving a file, <paramref name="lpNewFileName"/> can be on a different file system or volume. If <paramref name="lpNewFileName"/> is on another drive, you must set the <see cref="CopyAllowed"/> flag in <paramref name="dwFlags"/>.</para>
        /// <para>When moving a directory, <paramref name="lpExistingFileName"/> and <paramref name="lpNewFileName"/> must be on the same drive.</para>
        /// <para>If <paramref name="dwFlags"/> specifies <see cref="DelayUntilReboot"/> and <paramref name="lpNewFileName"/> is <see langword="null"/>, <see cref="MoveFileWithProgressW"/> registers <paramref name="lpExistingFileName"/> to be deleted when the system restarts. The function fails if it cannot access the registry to store the information about the delete operation. If <paramref name="lpExistingFileName"/> refers to a directory, the system removes the directory at restart only if the directory is empty.</para>
        /// <para>See Remarks section about the <see cref="MaxPath"/> limitation.</para></param>
        /// <param name="lpProgressRoutine">A <see cref="CopyProgressRoutine"/> callback function that is called each time another portion of the file has been moved. The callback function can be useful if you provide a user interface that displays the progress of the operation. This parameter can be <see langword="null"/>.</param>
        /// <param name="lpData">An argument to be passed to the <see cref="CopyProgressRoutine"/> callback function. This parameter can be <see langword="null"/>.</param>
        /// <param name="dwFlags">The move options. This parameter can be one or more of the values of the <see cref="MoveFileFlags"/>.</param>
        /// <returns><para>If the function succeeds, the return value is nonzero.</para>
        /// <para>If the function fails, the return value is zero. To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.</para>
        /// <para>When moving a file across volumes, if <paramref name="lpProgressRoutine"/> returns <see cref="Cancel"/> (or <see cref="Stop"/>) due to the user canceling (or stopping) the operation, <see cref="MoveFileWithProgressW"/> will return zero and <see cref="Marshal.GetLastWin32Error"/> will return <see cref="RequestAborted"/>. The existing file is left intact.</para></returns>
        /// <remarks><para>The names are limited to <see cref="MaxPath"/> characters. To extend this limit to 32,767 wide characters, prepend "\?" to the path. For more information, see Naming a File: https://docs.microsoft.com/en-us/windows/desktop/FileIO/naming-a-file
        /// </para>
        /// <para>Tip: Starting with Windows 10, version 1607, you can opt-in to remove the <see cref="MaxPath"/> limitation without prepending "\\?\". See the "Maximum Path Length Limitation" section of Naming Files, Paths, and Namespaces for details.</para>
        /// <para>The <see cref="MoveFileWithProgressW"/> function coordinates its operation with the link tracking service, so link sources can be tracked as they are moved.</para>
        /// <para>To delete or rename a file, you must have either delete permission on the file or delete child permission in the parent directory. If you set up a directory with all access except delete and delete child and the ACLs of new files are inherited, then you should be able to create a file without being able to delete it. However, you can then create a file, and you will get all the access you request on the handle returned to you at the time you create the file. If you requested delete permission at the time you created the file, you could delete or rename the file with that handle but not with any other.</para></remarks>
        [DllImport(Kernel32, CharSet = CharSet.Unicode, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool MoveFileWithProgressW([In, MarshalAs(UnmanagedType.LPWStr)] string lpExistingFileName, [In, MarshalAs(UnmanagedType.LPWStr)] string lpNewFileName, [In] CopyProgressRoutine lpProgressRoutine, [In] IntPtr lpData, [In, MarshalAs(UnmanagedType.U4)] MoveFileFlags dwFlags);

        [DllImport(Kernel32, SetLastError = true, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CreateDirectoryW([In, MarshalAs(UnmanagedType.LPWStr)] string lpPathName, [In] IntPtr lpSecurityAttributes);

        [DllImport(Kernel32, CharSet = CharSet.Unicode, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool RemoveDirectoryW([In, MarshalAs(UnmanagedType.LPWStr)] string lpPathName);

        [DllImport(Kernel32, CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern bool DeleteFileW([In, MarshalAs(UnmanagedType.LPWStr)] string lpFileName);

        [DllImport(Shell32, EntryPoint = "#62", CharSet = CharSet.Unicode, SetLastError = true)]
        [SuppressUnmanagedCodeSecurity]
        public static extern bool SHPickIconDialog(IntPtr hWnd, StringBuilder pszFilename, int cchFilenameMax, out int pnIconIndex);

        /// <summary>
        /// Retrieves information about an object in the file system, such as a file, folder, directory, or drive root.
        /// </summary>
        /// <param name="pszPath"><para>A string of maximum length <see cref="MaxPath"/> that contains the path and file name. Both absolute and relative paths are valid.</para>
        /// <para>If the <b>uFlags</b> parameter includes the <see cref="PIDL"/> flag, this parameter must be the address of an ITEMIDLIST(PIDL) structure that contains the list of item identifiers that uniquely identifies the file within the Shell's namespace. The PIDL must be a fully qualified PIDL. Relative PIDLs are not allowed.</para>
        /// <para>If the <b>uFlags</b> parameter includes the <see cref="UseFileAttributes"/> flag, this parameter does not have to be a valid file name. The function will proceed as if the file exists with the specified name and with the file attributes passed in the <b>dwFileAttributes</b> parameter. This allows you to obtain information about a file type by passing just the extension for <b>pszPath</b> and passing <see cref="FileAttributes.Normal"/> in <b>dwFileAttributes</b>.</para>
        /// <para>This string can use either short (the 8.3 form) or long file names.</para></param>
        /// <param name="dwFileAttributes">A combination of one or more <see cref="FileAttributes"/> flags. If <b>uFlags</b> does not include the <see cref="UseFileAttributes"/> flag, this parameter is ignored.</param>
        /// <param name="psfi">A <see cref="SHFILEINFO"/> structure to receive the file information.</param>
        /// <param name="cbFileInfo">The size, in bytes, of the <see cref="SHFILEINFO"/> structure pointed to by the <b>psfi</b> parameter.</param>
        /// <param name="uFlags">The flags that specify the file information to retrieve. This parameter can be a combination of the values of the <see cref="GetFileInfoOptions"/> enum.</param>
        /// <returns><para>Returns a value whose meaning depends on the <b>uFlags</b> parameter.</para>
        /// <para>If <b>uFlags</b> does not contain <see cref="ExeType"/> or <see cref="SysIconIndex"/>, the return value is nonzero if successful, or zero otherwise.</para>
        /// <para>If <b>uFlags</b> contains the <see cref="ExeType"/> flag, the return value specifies the type of the executable file. It will be one of the following values.</para>
        /// Return code                                    | Description
        /// -----------------------------------------------+------------------------------------------
        /// 0                                              | Nonexecutable file or an error condition.
        /// LOWORD = NE or PE and HIWORD = Windows version | Windows application.
        /// LOWORD = MZ and HIWORD = 0                     | MS-DOS.exe or .com file
        /// LOWORD = PE and HIWORD = 0                     | Console application or.bat file</returns>
        /// <remarks><para>You should call this function from a background thread. Failure to do so could cause the UI to stop responding.</para>
        /// <para>If <see cref="SHGetFileInfo"/> returns an icon handle in the <b>hIcon</b> member of the <see cref="SHFILEINFO"/> structure pointed to by <b>psfi</b>, you are responsible for freeing it with <see cref="Core.DestroyIcon"/> when you no longer need it.</para>
        /// <para>Note: Once you have a handle to a system image list, you can use the <b>Image List API</b> to manipulate it like any other image list. Because system image lists are created on a per-process basis, you should treat them as read-only objects. Writing to a system image list may overwrite or delete one of the system images, making it unavailable or incorrect for the remainder of the process.</para>
        /// <para>When you use the <see cref="GetFileInfoOptions.ExeType"/> flag with a Windows application, the Windows version of the executable is given in the HIWORD of the return value. This version is returned as a hexadecimal value. For details on equating this value with a specific Windows version, see <a href="https://docs.microsoft.com/windows/desktop/WinProg/using-the-windows-headers">Using the Windows Headers</a>.</para></remarks>
        [DllImport(Shell32, CharSet = CharSet.Unicode, SetLastError = true, EntryPoint = "SHGetFileInfoW")]
        public static extern HResult SHGetFileInfo([In, MarshalAs(UnmanagedType.LPWStr)] string pszPath, [MarshalAs(UnmanagedType.U4)] FileAttributes dwFileAttributes, [In, Out] ref SHFILEINFO psfi, [MarshalAs(UnmanagedType.U4)] uint cbFileInfo, GetFileInfoOptions uFlags);

        [DllImport("shlwapi.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern int PathParseIconLocation(
            [MarshalAs(UnmanagedType.LPWStr)] ref string pszIconFile);

        [DllImport(Shell32, CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern int SHParseDisplayName(
            [MarshalAs(UnmanagedType.LPWStr)] string pszName,
            IntPtr pbc,
            out IntPtr ppidl,
            ShellFileGetAttributesOptions sfgaoIn,
            out ShellFileGetAttributesOptions psfgaoOut
        );

        [DllImport(Shell32, CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern int SHGetIDListFromObject(IntPtr iUnknown,
            out IntPtr ppidl
        );

        [DllImport(Shell32, CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern uint ILGetSize(IntPtr pidl);

        [DllImport(Shell32, CharSet = CharSet.None)]
        public static extern void ILFree(IntPtr pidl);

        [DllImport(Shell32, SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern HResult SHQueryRecycleBin(string pszRootPath, ref SHQUERYRBINFO pSHQueryRBInfo);

        [DllImport(Shell32, SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern HResult SHEmptyRecycleBin(IntPtr hWnd, string pszRootPath, EmptyRecycleBinFlags dwFlags);

        /// <summary>
        /// <para>Copies an existing file to a new file, notifying the application of its progress through a callback function.</para>
        /// <para>To perform this operation as a transacted operation, use the CopyFileTransacted function.</para>
        /// </summary>
        /// <param name="lpExistingFileName"><para>The name of an existing file.</para>
        /// <para>See Remarks section about the <see cref="MaxPath"/> limitation.</para>
        /// <para>If lpExistingFileName does not exist, the <see cref="CopyFileEx(string, string, CopyProgressRoutine, IntPtr, ref bool, CopyFileFlags)"/> function fails, and the <see cref="Marshal. GetLastWin32Error"/> function returns <see cref="FileNotFound"/>.</para></param>
        /// <param name="lpNewFileName"><para>The name of the new file.</para>
        /// <para>See Remarks section about the <see cref="MaxPath"/> limitation.</para>
        /// <param name="lpProgressRoutine">The address of a callback function of type <see cref="CopyProgressRoutine"/> that is called each time another portion of the file has been copied. This parameter can be <see langword="null"/>. For more information on the progress callback function, see the <see cref="CopyProgressRoutine"/> function.</param>
        /// <param name="lpData">The argument to be passed to the callback function. This parameter can be <see langword="null"/>.</param>
        /// <param name="pbCancel">If this flag is set to <see langword="true"/> during the copy operation, the operation is canceled. Otherwise, the copy operation will continue to completion.</param>
        /// <param name="dwCopyFlags">Flags that specify how the file is to be copied. This parameter can be a combination of the <see cref="CopyFileFlags"/> enum.</param>
        /// <returns><para>If the function succeeds, the return value is nonzero.</para>
        /// <para>If the function fails, the return value is zero.To get extended error information call <see cref="Marshal.GetLastWin32Error"/>.</para>
        /// <para>If lpProgressRoutine returns <see cref="Cancel"/> due to the user canceling the operation, <see cref="CopyFileEx(string, string, CopyProgressRoutine, IntPtr, ref bool, CopyFileFlags)"/> will return zero and <see cref="Marshal.GetLastWin32Error"/> will return <see cref="RequestAborted"/>. In this case, the partially copied destination file is deleted.</para>
        /// <para>If lpProgressRoutine returns <see cref="Stop"/> due to the user stopping the operation, <see cref="CopyFileEx(string, string, CopyProgressRoutine, IntPtr, ref bool, CopyFileFlags)"/> will return zero and <see cref="Marshal.GetLastWin32Error"/> will return <see cref="RequestAborted"/>. In this case, the partially copied destination file is left intact.</para></returns>
        /// <remarks><para>The names are limited to <see cref="MaxPath"/> characters. To extend this limit to 32,767 wide characters, prepend "\?" to the path. For more information, see Naming a File: https://docs.microsoft.com/en-us/windows/desktop/FileIO/naming-a-file
        /// </para>
        /// <para>Tip: Starting with Windows 10, version 1607, you can opt-in to remove the <see cref="MaxPath"/> limitation without prepending "\\?\". See the "Maximum Path Length Limitation" section of Naming Files, Paths, and Namespaces for details.</para>
        /// <para>This function preserves extended attributes, OLE structured storage, NTFS file system alternate data streams, security resource attributes, and file attributes.</para>
        /// <para>Windows 7, Windows Server 2008 R2, Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP:  Security resource attributes (ATTRIBUTE_SECURITY_INFORMATION) for the existing file are not copied to the new file until Windows 8 and Windows Server 2012.</para>
        /// <para>The security resource properties(ATTRIBUTE_SECURITY_INFORMATION) for the existing file are copied to the new file.</para>
        /// <para>Windows 7, Windows Server 2008 R2, Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP:  Security resource properties for the existing file are not copied to the new file until Windows 8 and Windows Server 2012.</para>
        /// <para>This function fails with <see cref="HResult.AccessDenied"/> if the destination file already exists and has the <see cref="System.IO.FileAttributes.Hidden"/> or <see cref="System.IO.FileAttributes.ReadOnly"/> attribute set.</para>
        /// <para>When encrypted files are copied using <see cref="CopyFileEx(string, string, CopyProgressRoutine, IntPtr, ref bool, CopyFileFlags)"/>, the function attempts to encrypt the destination file with the keys used in the encryption of the source file.If this cannot be done, this function attempts to encrypt the destination file with default keys.If both of these methods cannot be done, <see cref="CopyFileEx(string, string, CopyProgressRoutine, IntPtr, ref bool, CopyFileFlags)"/> fails with an <see cref="EncryptionFailed"/> error code. If you want <see cref="CopyFileEx(string, string, CopyProgressRoutine, IntPtr, ref bool, CopyFileFlags)"/> to complete the copy operation even if the destination file cannot be encrypted, include the <see cref="AllowDecryptedDestination"/> as the value of the dwCopyFlags parameter in your call to <see cref="CopyFileEx(string, string, CopyProgressRoutine, IntPtr, ref bool, CopyFileFlags)"/>.</para>
        /// <para>If <see cref="CopySymLink"/> is specified, the following rules apply:</para>
        /// <para>If the source file is a symbolic link, the symbolic link is copied, not the target file.</para>
        /// <para>If the source file is not a symbolic link, there is no change in behavior.</para>
        /// <para>If the destination file is an existing symbolic link, the symbolic link is overwritten, not the target file.</para>
        /// <para>If <see cref="FailIfExists"/> is also specified, and the destination file is an existing symbolic link, the operation fails in all cases.</para>
        /// <para>If <see cref="CopySymLink"/> is not specified, the following rules apply:</para>
        /// <para>If <see cref="FailIfExists"/> is also specified, and the destination file is an existing symbolic link, the operation fails only if the target of the symbolic link exists.</para>
        /// <para>If <see cref="FailIfExists"/> is not specified, there is no change in behavior.</para>
        /// <para>Windows 7, Windows Server 2008 R2, Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP:  If you are writing an application that is optimizing file copy operations across a LAN, consider using the TransmitFile function from Windows Sockets(Winsock). TransmitFile supports high-performance network transfers and provides a simple interface to send the contents of a file to a remote computer.To use TransmitFile, you must write a Winsock client application that sends the file from the source computer as well as a Winsock server application that uses other Winsock functions to receive the file on the remote computer.</para>
        /// <para>In Windows 8 and Windows Server 2012, this function is supported by the following technologies: Server Message Block (SMB) 3.0 protocol, SMB 3.0 Transparent Failover (TFO), SMB 3.0 with Scale-out File Shares (SO), Cluster .Shared Volume File System (CsvFS), Resilient File System (ReFS) Yes </remarks></para>
        [DllImport(Kernel32, SetLastError = true, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CopyFileEx([In, MarshalAs(UnmanagedType.LPWStr)] string lpExistingFileName, [In, MarshalAs(UnmanagedType.LPWStr)] string lpNewFileName,
            [In] CopyProgressRoutine lpProgressRoutine, [In] IntPtr lpData, [In, Out, MarshalAs(UnmanagedType.Bool)] ref bool pbCancel,
            [In, MarshalAs(UnmanagedType.U4)] CopyFileFlags dwCopyFlags);
        #endregion

        #region Shell notification definitions
        [DllImport(Shell32, SetLastError = true, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SHGetPathFromIDListW(IntPtr pidl, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszPath);

        [DllImport(Shell32, SetLastError = true)]
        public static extern uint SHChangeNotifyRegister(
            IntPtr windowHandle,
            ShellChangeNotifyEventSource sources,
            ShellObjectChangeTypes events,
            uint message,
            int entries,
            ref SHChangeNotifyEntry changeNotifyEntry);

        [DllImport(Shell32)]
        public static extern IntPtr SHChangeNotification_Lock(
            IntPtr windowHandle,
            int processId,
            out IntPtr pidl,
            out uint lEvent);

        [DllImport(Shell32, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SHChangeNotification_Unlock(IntPtr hLock);

        [DllImport(Shell32, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SHChangeNotifyDeregister(uint hNotify);
        #endregion
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SHChangeNotifyEntry
    {
        public IntPtr pIdl;

        [MarshalAs(UnmanagedType.Bool)]
        public bool recursively;
    }

    [Flags]
    public enum ShellChangeNotifyEventSource
    {
        InterruptLevel = 0x0001,
        ShellLevel = 0x0002,
        RecursiveInterrupt = 0x1000,
        NewDelivery = 0x8000
    }

    public enum LibraryManageDialogOptions
    {
        Default = 0,
        NonIndexableLocationWarning = 1
    };

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
    /// <param name="lpData">Argument passed to CopyProgressRoutine by <see cref="Win32Native.Shell.Shell.CopyFileEx(string, string, CopyProgressRoutine, IntPtr, ref bool, CopyFileFlags)"/>, MoveFileTransacted, or MoveFileWithProgress.</param>
    /// <returns>The CopyProgressRoutine function should return one of the values of the <see cref="CopyProgressResult"/> enum.</returns>
    /// <remarks>An application can use this information to display a progress bar that shows the total number of bytes copied as a percent of the total file size.</remarks>
    public delegate CopyProgressResult CopyProgressRoutine(
        [In, MarshalAs(UnmanagedType.I8)] long TotalFileSize,
        [In, MarshalAs(UnmanagedType.I8)] long TotalBytesTransferred,
        [In, MarshalAs(UnmanagedType.I8)] long StreamSize,
        [In, MarshalAs(UnmanagedType.I8)] long StreamBytesTransferred,
        [In, MarshalAs(UnmanagedType.U4)] uint dwStreamNumber,
        [In, MarshalAs(UnmanagedType.U4)] CopyProgressCallbackReason dwCallbackReason,
        [In] IntPtr hSourceFile,
        [In] IntPtr hDestinationFile,
        [In] IntPtr lpData);
}
