using Microsoft.WindowsAPICodePack.Win32Native.Shell;

using System;
using System.Runtime.InteropServices;
using System.Text;

using static Microsoft.WindowsAPICodePack.NativeAPI.Consts.DllNames;
using static Microsoft.WindowsAPICodePack.NativeAPI.Consts.Shell;
using static Microsoft.WindowsAPICodePack.Win32Native.ErrorCode;
using static Microsoft.WindowsAPICodePack.Win32Native.Net.FTP.TransferType;
using static Microsoft.WindowsAPICodePack.Win32Native.Net.InternetFlags;
using static Microsoft.WindowsAPICodePack.Win32Native.Net.NativeMethods;

using static System.Runtime.InteropServices.CharSet;
using static System.Runtime.InteropServices.Marshal;
using static System.Runtime.InteropServices.UnmanagedType;

namespace Microsoft.WindowsAPICodePack.Win32Native.Net.FTP
{
    public enum TransferType : uint
    {
        Unknown = 0x00000000,

        /// <summary>
        /// Transfers the file using the FTP ASCII (Type A) transfer method. Control and formatting data is converted to local equivalents.
        /// </summary>
        ASCII = 0x00000001,

        /// <summary>
        /// Transfers the file using the FTP Image (Type I) transfer method. The file is transferred exactly with no changes. This is the default transfer method.
        /// </summary>
        Binary = 0x00000002,

        Mask = ASCII | Binary
    }

    /// <summary>
    /// Provides procedural methods to work with FTP connections. See the Remarks section.
    /// </summary>
    /// <remarks>Note: WinINet does not support server implementations. In addition, it should not be used from a service. For server implementations or services use Microsoft Windows HTTP Services (WinHTTP).</remarks>
    public static class NativeMethods
    {
        /// <summary>
        /// Retrieves the current directory for the specified FTP session. See Remarks section.
        /// </summary>
        /// <param name="hConnect">Handle to an FTP session.</param>
        /// <param name="lpszCurrentDirectory">Pointer to a null-terminated string that receives the absolute path of the current directory.</param>
        /// <param name="lpdwCurrentDirectory">A variable that specifies the length of the buffer, in TCHARs. The buffer length must include room for a terminating null character. Using a length of <see cref="MaxPath"/> is sufficient for all paths. When the function returns, the variable receives the number of characters copied into the buffer.</param>
        /// <returns>Returns <see langword="true"/> if successful, or <see langword="false"/> otherwise. To get a specific error message, call <see cref="GetLastWin32Error"/>.</returns>
        /// <remarks>If the <paramref name="lpszCurrentDirectory"/> buffer is not large enough, <paramref name="lpdwCurrentDirectory"/> receives the number of bytes required to retrieve the full, current directory name.</remarks>
        [DllImport(Wininet, SetLastError = true, CharSet = Unicode, PreserveSig = true)]
        [return: MarshalAs(Bool)]
        public static extern bool FtpGetCurrentDirectory(IntPtr hConnect,
            StringBuilder lpszCurrentDirectory,
            [In, Out, MarshalAs(U4)] ref uint lpdwCurrentDirectory);

        /// <summary>
        /// Changes to a different working directory on the FTP server.
        /// </summary>
        /// <param name="hConnect">Handle to an FTP session.</param>
        /// <param name="lpszDirectory">Pointer to a null-terminated string that contains the name of the directory to become the current working directory. This can be either a fully qualified path or a name relative to the current directory.</param>
        /// <returns>Returns <see langword="true"/> if successful, or <see langword="false"/> otherwise. To get a specific error message, call <see cref="GetLastWin32Error"/>. If the error message indicates that the FTP server denied the request to change a directory, use <see cref="InternetGetLastResponseInfo"/> to determine why.</returns>
        /// <remarks>
        /// <para>An application should use <see cref="FtpGetCurrentDirectory"/> to determine the remote site's current working directory, instead of assuming that the remote system uses a hierarchical naming scheme for directories.</para>
        /// <para>The <paramref name="lpszDirectory"/> parameter can be either partially or fully qualified file names relative to the current directory.</para>
        /// </remarks>
        [DllImport(Wininet, SetLastError = true, CharSet = Unicode, PreserveSig = true)]
        [return: MarshalAs(Bool)]
        public static extern bool FtpSetCurrentDirectory(IntPtr hConnect,
            [In, MarshalAs(LPWStr)] string lpszDirectory);

        /// <summary>
        /// Searches the specified directory of the given FTP session. File and directory entries are returned to the application in the <see cref="Win32FindData"/> structure. See the Remarks section.
        /// </summary>
        /// <param name="hConnect">Handle to an FTP session returned from <see cref="InternetConnect"/>.</param>
        /// <param name="lpszSearchFile">A valid directory path or file name for the FTP server's file system. The string can contain wildcards, but no blank spaces are allowed. If the value of <paramref name="lpszSearchFile"/> is <see langword="null"/> or if it is an empty string, the function finds the first file in the current directory on the server.</param>
        /// <param name="lpFindFileData">Information about the found file or directory.</param>
        /// <param name="dwFlags">Controls the behavior of this function. This parameter can be a combination of the following values: <see cref="Hyperlink"/>, <see cref="NeedFile"/>, <see cref="NoCacheWrite"/>, <see cref="Reload"/>, <see cref="Resynchronize"/>.</param>
        /// <param name="dwContext">Pointer to a variable that specifies the application-defined value that associates this search with any application data. This parameter is used only if the application has already called <see cref="InternetSetStatusCallback"/> to set up a status callback function.</param>
        /// <returns>Returns a valid handle for the request if the directory enumeration was started successfully, or returns <see cref="IntPtr.Zero"/> otherwise. To get a specific error message, call <see cref="GetLastWin32Error"/>. If <see cref="GetLastWin32Error"/> returns <see cref="ErrorCode.InternetExtendedError"/>, as in the case where the function finds no matching files, call the <see cref="InternetGetLastResponseInfo"/> function to retrieve the extended error text, as documented in <see href="https://docs.microsoft.com/en-us/windows/desktop/WinInet/appendix-c-handling-errors">Handling Errors</see>.</returns>
        /// <remarks>
        /// <para>For <see cref="FtpFindFirstFile"/>, file times returned in the <see cref="Win32FindData"/> structure are in the local time zone, not in a coordinated universal time (UTC) format.</para>
        /// <para><see cref="FtpFindFirstFile"/> is similar to the <see cref="DataAccessAndStorage.NativeMethods.FindFirstFile"/> function. Note, however, that only one <see cref="FtpFindFirstFile"/> can occur at a time within a given FTP session. The enumerations, therefore, are correlated with the FTP session handle. This is because the FTP protocol allows only a single directory enumeration per session.</para>
        /// <para>After calling <see cref="FtpFindFirstFile"/> and until calling <see cref="InternetCloseHandle"/>, the application cannot call <see cref="FtpFindFirstFile"/> again on the given FTP session handle. If a call is made to <see cref="FtpFindFirstFile"/> on that handle, the function fails with <see cref="FTPTransferInProgress"/>. After the calling application has finished using the handle returned by <see cref="FtpFindFirstFile"/>, it must be closed using the <see cref="InternetCloseHandle"/> function.</para>
        /// <para>After beginning a directory enumeration with <see cref="FtpFindFirstFile"/>, the <see cref="InternetFindNextFile"/> function can be used to continue the enumeration.</para>
        /// <para>Because the FTP protocol provides no standard means of enumerating, some of the common information about files, such as file creation date and time, is not always available or correct. When this happens, <see cref="FtpFindFirstFile"/> and <see cref="InternetFindNextFile"/> fill in unavailable information with a best guess based on available information. For example, creation and last access dates are often the same as the file's modification date.</para>
        /// <para>The application cannot call <see cref="FtpFindFirstFile"/> between calls to <see cref="FtpOpenFile"/> and <see cref="InternetCloseHandle"/>.</para>
        /// </remarks>
        [DllImport(Wininet, SetLastError = true, CharSet = Unicode, PreserveSig = true)]
        public static extern IntPtr FtpFindFirstFile(IntPtr hConnect,
            [In, MarshalAs(LPWStr)] string lpszSearchFile,
            [Out] out Win32FindData lpFindFileData,
            [In] InternetFlags dwFlags,
            UIntPtr dwContext);

        /// <summary>
        /// Creates a new directory on the FTP server. See the Remarks section.
        /// </summary>
        /// <param name="hConnect">Handle returned by a previous call to <see cref="InternetConnect"/> using <see cref="InternetService.FTP"/>.</param>
        /// <param name="lpszDirectory">The name of the directory to be created. This can be either a fully qualified path or a name relative to the current directory.</param>
        /// <returns>Returns <see langword="true"/> if successful, or <see langword="false"/> otherwise. To get a specific error message, call <see cref="GetLastWin32Error"/>. If the error message indicates that the FTP server denied the request to create a directory, use <see cref="InternetGetLastResponseInfo"/> to determine why.</returns>
        /// <remarks>
        /// <para>An application should use <see cref="FtpGetCurrentDirectory"/> to determine the remote site's current working directory instead of assuming that the remote system uses a hierarchical naming scheme for directories.</para>
        /// <para>The <paramref name="lpszDirectory"/> parameter can be either partially or fully qualified file names relative to the current directory.</para>
        /// </remarks>
        [DllImport(Wininet, SetLastError = true, CharSet = Unicode, PreserveSig = true)]
        [return: MarshalAs(Bool)]
        public static extern bool FtpCreateDirectory(IntPtr hConnect,
            [In, MarshalAs(LPWStr)] string lpszDirectory);

        /// <summary>
        /// Removes the specified directory on the FTP server. The remarks are the same that for <see cref="FtpCreateDirectory(IntPtr, string)"/>.
        /// </summary>
        /// <param name="hConnect">Handle to an FTP session.</param>
        /// <param name="lpszDirectory">The name of the directory to be removed. This can be either a fully qualified path or a name relative to the current directory.</param>
        /// <returns>Returns <see langword="true"/> if successful, or <see langword="false"/> otherwise. To get a specific error message, call <see cref="GetLastWin32Error"/>. If the error message indicates that the FTP server denied the request to remove a directory, use <see cref="InternetGetLastResponseInfo"/> to determine why.</returns>
        [DllImport(Wininet, SetLastError = true, CharSet = Unicode, PreserveSig = true)]
        [return: MarshalAs(Bool)]
        public static extern bool FtpRemoveDirectory(IntPtr hConnect,
            [In, MarshalAs(LPWStr)] string lpszDirectory);

        /// <summary>
        /// Deletes a file stored on the FTP server. See the Remarks section.
        /// </summary>
        /// <param name="hConnect">Handle returned by a previous call to <see cref="InternetConnect"/> using <see cref="InternetService.FTP"/>.</param>
        /// <param name="lpszFileName">The name of the file to be deleted.</param>
        /// <returns>Returns <see langword="true"/> if successful, or <see langword="false"/> otherwise. To get a specific error message, call <see cref="GetLastWin32Error"/>.</returns>
        /// <remarks>The <paramref name="lpszFileName"/> parameter can be either partially or fully qualified file names relative to the current directory.</remarks>
        [DllImport(Wininet, SetLastError = true, CharSet = Unicode, PreserveSig = true)]
        [return: MarshalAs(Bool)]
        public static extern bool FtpDeleteFile(IntPtr hConnect,
            [In, MarshalAs(LPWStr)] string lpszFileName);

        /// <summary>
        /// Sends commands directly to an FTP server. See the Remarks section.
        /// </summary>
        /// <param name="hConnect">A handle returned from a call to <see cref="InternetConnect"/>.</param>
        /// <param name="fExpectResponse">A <see cref="bool"/> value that indicates whether the application expects a data connection to be established by the FTP server. This must be set to <see langword="true"/> if a data connection is expected, or <see langword="false"/> otherwise.</param>
        /// <param name="dwFlags">A parameter that can be set to one of the following values: <see cref="ASCII"/>, <see cref="Binary"/>.</param>
        /// <param name="lpszCommand">The command to send to the FTP server.</param>
        /// <param name="dwContext">A pointer to a variable that contains an application-defined value used to identify the application context in callback operations.</param>
        /// <param name="phFtpCommand">A pointer to a handle that is created if a valid data socket is opened. The <paramref name="fExpectResponse"/> parameter must be set to <see langword="true"/> for <paramref name="phFtpCommand"/> to be filled.</param>
        /// <returns>Returns <see langword="true"/> if successful, or <see langword="false"/> otherwise. To get a specific error message, call <see cref="GetLastWin32Error"/>.</returns>
        /// <remarks><see cref="GetLastWin32Error"/> can return <see cref="InternetNoDirectAccess"/> if the client application is offline. If one or more of the parameters are invalid, <see cref="GetLastWin32Error"/> will return <see cref="InvalidParameter"/>.</remarks>
        [DllImport(Wininet, SetLastError = true, CharSet = Unicode, PreserveSig = true)]
        [return: MarshalAs(Bool)]
        public static extern bool FtpCommand(IntPtr hConnect,
           [In, MarshalAs(Bool)] bool fExpectResponse,
           [In, MarshalAs(U4)] TransferType dwFlags,
           [In, MarshalAs(LPWStr)] string lpszCommand,
           UIntPtr dwContext,
           ref IntPtr phFtpCommand);

        /// <summary>
        /// Retrieves a file from the FTP server and stores it under the specified file name, creating a new local file in the process.
        /// </summary>
        /// <param name="hConnect">Handle to an FTP session.</param>
        /// <param name="lpszRemoteFile">The name of the file to be retrieved.</param>
        /// <param name="lpszNewFile">The name of the file to be created on the local system.</param>
        /// <param name="fFailIfExists">Indicates whether the function should proceed if a local file of the specified name already exists. If <paramref name="fFailIfExists"/> is <see langword="true"/> and the local file exists, <see cref="FtpGetFile"/> fails.</param>
        /// <param name="dwFlagsAndAttributes">File attributes for the new file. This parameter can be any combination of the <see cref="FileAttributes"/> flags used by the <see cref="CreateFile"/> function.</param>
        /// <param name="dwFlags"><para>Controls how the function will handle the file download. The first set of flag values indicates the conditions under which the transfer occurs. These transfer type flags can be used in combination with the second set of flags that control caching.</para>
        /// <para>The application can select one of these transfer type values: <see cref="ASCII"/>, <see cref="Binary"/>, <see cref="Unknown"/>, <see cref="TransferASCII"/>, <see cref="TransferBinary"/>.</para>
        /// <para>The following flags determine how the caching of this file will be done. Any combination of the following flags can be used with the transfer type flag: <see cref="Hyperlink"/>, <see cref="NeedFile"/>, <see cref="Reload"/>, <see cref="Resynchronize"/>.</para></param>
        /// <param name="dwContext">Pointer to a variable that contains the application-defined value that associates this search with any application data. This is used only if the application has already called <see cref="InternetSetStatusCallback"/> to set up a status callback function.</param>
        /// <returns>Returns <see langword="true"/> if successful, or <see langword="false"/> otherwise. To get a specific error message, call <see cref="GetLastWin32Error"/>.</returns>
        /// <remarks>
        /// <para><see cref="FtpGetFile"/> is a high-level routine that handles all the bookkeeping and overhead associated with reading a file from an FTP server and storing it locally. An application that needs to retrieve file data only or that requires close control over the file transfer should use the <see cref="FtpOpenFile"/> and <see cref="InternetReadFile"/> functions.</para>
        /// <para>If the <paramref name="dwFlags"/> parameter specifies <see cref="ASCII"/>, translation of the file data converts control and formatting characters to local equivalents. The default transfer is binary mode, where the file is downloaded in the same format as it is stored on the server.</para>
        /// <para>Both <paramref name="lpszRemoteFile"/> and <paramref name="lpszNewFile"/> can be either partially or fully qualified file names relative to the current directory.</para>
        /// </remarks>
        [DllImport(Wininet, SetLastError = true, CharSet = Unicode, PreserveSig = true)]
        [return: MarshalAs(Bool)]
        public static extern bool FtpGetFile(IntPtr hConnect,
            [In, MarshalAs(LPWStr)] string lpszRemoteFile,
            [In, MarshalAs(LPWStr)] string lpszNewFile,
            [In, MarshalAs(Bool)] bool fFailIfExists,
            [In, MarshalAs(U4)] FileAttributes dwFlagsAndAttributes,
            [In, MarshalAs(U4)] InternetFlags dwFlags,
            UIntPtr dwContext);

        /// <summary>
        /// Retrieves the file size of the requested FTP resource.
        /// </summary>
        /// <param name="hFile">Handle returned from a call to <see cref="FtpOpenFile"/>.</param>
        /// <param name="lpdwFileSizeHigh">Pointer to the high-order unsigned long integer of the file size of the requested FTP resource.</param>
        /// <returns>Returns the low-order unsigned long integer of the file size of the requested FTP resource.</returns>
        [DllImport(Wininet, SetLastError = true, CharSet = Unicode, PreserveSig = true)]
        [return: MarshalAs(U4)]
        public static extern uint FtpGetFileSize(IntPtr hFile,
            [Out, MarshalAs(U4)] out uint lpdwFileSizeHigh);

        /// <summary>
        /// Initiates access to a remote file on an FTP server for reading or writing. See the Remarks section.
        /// </summary>
        /// <param name="hConnect">Handle to an FTP session.</param>
        /// <param name="lpszFileName">Pointer to a null-terminated string that contains the name of the file to be accessed.</param>
        /// <param name="dwAccess">File access. This parameter can be <see cref="FileAccess.Read"/> or <see cref="FileAccess.Write"/>, but not both.</param>
        /// <param name="dwFlags">
        /// <para>Conditions under which the transfers occur. The application should select one transfer type and any of the flags that indicate how the caching of the file will be controlled.</para>
        /// <para>The transfer type can be one of the following values: <see cref="ASCII"/>, <see cref="Binary"/>, <see cref="Unknown"/>, <see cref="TransferASCII"/>, <see cref="TransferBinary"/>.</para>
        /// <para>The following values are used to control the caching of the file. The application can use one or more of these values: <see cref="Hyperlink"/>, <see cref="NeedFile"/>, <see cref="Reload"/>, <see cref="Resynchronize"/>.</para>
        /// </param>
        /// <param name="dwContext">Pointer to a variable that contains the application-defined value that associates this search with any application data. This is only used if the application has already called <see cref="InternetSetStatusCallback"/> to set up a status callback function.</param>
        /// <returns>Returns a handle if successful, or <see langword="null"/> otherwise. To retrieve a specific error message, call <see cref="GetLastWin32Error"/>.</returns>
        /// <remarks>
        /// <para>After calling <see cref="FtpOpenFile"/> and until calling <see cref="InternetCloseHandle"/>, all other calls to FTP functions on the same FTP session handle will fail and set the error message to <see cref="FTPTransferInProgress"/>. After the calling application has finished using the handle returned by <see cref="FtpOpenFile"/>, it must be closed using the <see cref="InternetCloseHandle"/> function.</para>
        /// <para>Only one file can be open in a single FTP session. Therefore, no file handle is returned and the application simply uses the FTP session handle when necessary.</para>
        /// <para>The <paramref name="lpszFileName"/> parameter can be either a partially or fully qualified file name relative to the current directory.</para>
        /// </remarks>
        [DllImport(Wininet, SetLastError = true, CharSet = Unicode, PreserveSig = true)]
        [return: MarshalAs(Bool)]
        public static extern bool FtpOpenFile(IntPtr hConnect,
            [In, MarshalAs(LPWStr)] string lpszFileName,
            [In, MarshalAs(U4)] FileAccess dwAccess,
            [In, MarshalAs(U4)] InternetFlags dwFlags,
            UIntPtr dwContext);

        /// <summary>
        /// Stores a file on the FTP server. See the Remarks section.
        /// </summary>
        /// <param name="hConnect">Handle to an FTP session.</param>
        /// <param name="lpszLocalFile">Pointer to a null-terminated string that contains the name of the file to be sent from the local system.</param>
        /// <param name="lpszNewRemoteFile">Pointer to a null-terminated string that contains the name of the file to be created on the remote system.</param>
        /// <param name="dwFlags">
        /// <para>Conditions under which the transfers occur. The application should select one transfer type and any of the flags that control how the caching of the file will be controlled.</para>
        /// <para>The transfer type can be any one of the following values: <see cref="ASCII"/>, <see cref="Binary"/>, <see cref="Unknown"/>, <see cref="TransferASCII"/>, <see cref="TransferBinary"/>.</para>
        /// <para>The following values are used to control the caching of the file. The application can use one or more of the following values: <see cref="Hyperlink"/>, <see cref="NeedFile"/>, <see cref="Reload"/>, <see cref="Resynchronize"/>.</para>
        /// </param>
        /// <param name="dwContext">Pointer to a variable that contains the application-defined value that associates this search with any application data. This parameter is used only if the application has already called <see cref="InternetSetStatusCallback"/> to set up a status callback.</param>
        /// <returns>Returns <see langword="true"/> if successful, or <see langword="false"/> otherwise. To get a specific error message, call <see cref="GetLastWin32Error"/>.</returns>
        /// <remarks>
        /// <para><see cref="FtpPutFile"/> is a high-level routine that handles all the bookkeeping and overhead associated with reading a file locally and storing it on an FTP server. An application that needs to send file data only, or that requires close control over the file transfer, should use the <see cref="FtpOpenFile"/> and <see cref="InternetWriteFile"/> functions.</para>
        /// <para>If the <paramref name="dwFlags"/> parameter specifies <see cref="ASCII"/>, translation of the file data converts control and formatting characters to local equivalents.</para>
        /// <para>Both <paramref name="lpszNewRemoteFile"/> and <paramref name="lpszLocalFile"/> can be either partially or fully qualified file names relative to the current directory.</para>
        /// </remarks>
        [DllImport(Wininet, SetLastError = true, CharSet = Unicode, PreserveSig = true)]
        [return: MarshalAs(Bool)]
        public static extern bool FtpPutFile(IntPtr hConnect,
            [In, MarshalAs(LPWStr)] string lpszLocalFile,
            [In, MarshalAs(LPWStr)] string lpszNewRemoteFile,
            [In, MarshalAs(U4)] InternetFlags dwFlags,
            UIntPtr dwContext);

        /// <summary>
        /// Renames a file stored on the FTP server. See the Remarks section.
        /// </summary>
        /// <param name="hConnect">Handle to an FTP session.</param>
        /// <param name="lpszExisting">The name of the file to be renamed.</param>
        /// <param name="lpszNew">The new name for the remote file.</param>
        /// <returns>Returns <see langword="true"/> if successful, or <see langword="false"/> otherwise. To get a specific error message, call <see cref="GetLastWin32Error"/>.</returns>
        /// <remarks>The <paramref name="lpszExisting"/> and <paramref name="lpszNew"/> parameters can be either partially or fully qualified file names relative to the current directory.</remarks>
        [DllImport(Wininet, SetLastError = true, CharSet = Unicode, PreserveSig = true)]
        [return: MarshalAs(Bool)]
        public static extern bool FtpRenameFile(IntPtr hConnect,
            [In, MarshalAs(LPWStr)] string lpszExisting,
            [In, MarshalAs(LPWStr)] string lpszNew);
    }
}
