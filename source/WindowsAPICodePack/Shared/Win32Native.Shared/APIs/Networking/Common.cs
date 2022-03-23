using Microsoft.WindowsAPICodePack.Win32Native.Shell;

using System;
using System.Runtime.InteropServices;

using static Microsoft.WindowsAPICodePack.NativeAPI.Consts.DllNames;
using static Microsoft.WindowsAPICodePack.Win32Native.ErrorCode;
using static Microsoft.WindowsAPICodePack.Win32Native.Net.FTP.NativeMethods;
using static Microsoft.WindowsAPICodePack.Win32Native.Net.InternetFlags;
using static Microsoft.WindowsAPICodePack.Win32Native.Net.InternetOpenType;
using static Microsoft.WindowsAPICodePack.Win32Native.Net.InternetStatus;

using static System.Runtime.InteropServices.CharSet;
using static System.Runtime.InteropServices.Marshal;
using static System.Runtime.InteropServices.UnmanagedType;

namespace Microsoft.WindowsAPICodePack.Win32Native.Net
{
    /// <summary>
    /// Provides procedural methods to work with Internet connections. See the Remarks section.
    /// </summary>
    /// <remarks>Note: WinINet does not support server implementations. In addition, it should not be used from a service. For server implementations or services use Microsoft Windows HTTP Services (WinHTTP).</remarks>
    public static class NativeMethods
    {
        [DllImport(Wininet, SetLastError = true, CharSet = Unicode, PreserveSig = true)]
        [return: MarshalAs(Bool)]
        public static extern bool InternetGetLastResponseInfo(IntPtr lpdwError,
            IntPtr lpszBuffer,
            [In, Out, MarshalAs(U4)] ref uint lpdwBufferLength);

        /// <summary>
        /// Initializes an application's use of the WinINet functions.
        /// </summary>
        /// <param name="lpszAgent">The name of the application or entity calling the WinINet functions. This name is used as the user agent in the HTTP protocol.</param>
        /// <param name="dwAccessType">Type of access required. This parameter can be one of the following values: <see cref="Direct"/>, <see cref="Preconfig"/>, <see cref="PreconfigWithNoAutoProxy"/>, <see cref="Proxy"/>.</param>
        /// <param name="dwFlags">Options. This parameter can be a combination of the following values: <see cref="Async"/>, <see cref="FromCache"/>, <see cref="Offline"/>.</param>
        /// <returns>Returns a valid handle that the application passes to subsequent WinINet functions. If this method fails, it returns <see cref="IntPtr.Zero"/>. To retrieve a specific error message, call <see cref="GetLastWin32Error"/>.</returns>
        [DllImport(Wininet, SetLastError = true, CharSet = Unicode, PreserveSig = true)]
        public static extern IntPtr InternetOpen([In, MarshalAs(LPWStr)] string lpszAgent,
            [In, MarshalAs(U4)] InternetOpenType dwAccessType,
            [In, MarshalAs(LPWStr)] string lpszProxy,
            [In, MarshalAs(LPWStr)] string lpszProxyBypass,
            [In, MarshalAs(U4)] InternetFlags dwFlags);

        /// <summary>
        /// Opens a File Transfer Protocol (FTP) or HTTP session for a given site.
        /// </summary>
        /// <param name="hInternet">Handle returned by a previous call to <see cref="InternetOpen"/>.</param>
        /// <param name="lpszServerName">The host name of an Internet server. Alternately, the string can contain the IP number of the site, in ASCII dotted-decimal format (for example, 11.0.1.45).</param>
        /// <param name="nServerPort">Transmission Control Protocol/Internet Protocol (TCP/IP) port on the server. These flags set only the port that is used. The service is set by the value of dwService.</param>
        /// <param name="lpszUserName">The name of the user to log on. If this parameter is NULL, the function uses an appropriate default. For the FTP protocol, the default is "anonymous".</param>
        /// <param name="lpszPassword">The password to use to log on. If both <paramref name="lpszPassword"/> and <paramref name="lpszUserName"/> are <see langword="null"/>, the function uses the default "anonymous" password. In the case of FTP, the default password is the user's email name. If <paramref name="lpszPassword"/> is <see langword="null"/>, but <paramref name="lpszUserName"/> is not <see langword="null"/>, the function uses a blank password.</param>
        /// <param name="dwService">Type of service to access.</param>
        /// <param name="dwFlags">Options specific to the service used. If <paramref name="dwService"/> is <see cref="InternetService.FTP"/>, <see cref="InternetFlags.Passive"/> causes the application to use passive FTP semantics.</param>
        /// <param name="dwContext">Pointer to a variable that contains an application-defined value that is used to identify the application context for the returned handle in callbacks.</param>
        /// <returns>Returns a valid handle to the session if the connection is successful, or <see cref="IntPtr.Zero"/> otherwise. To retrieve extended error information, call <see cref="GetLastWin32Error"/>. An application can also use <see cref="InternetGetLastResponseInfo"/> to determine why access to the service was denied.</returns>
        [DllImport(Wininet, SetLastError = true, CharSet = Unicode, PreserveSig = true)]
        public static extern IntPtr InternetConnect(IntPtr hInternet,
            [In, MarshalAs(LPWStr)] string lpszServerName,
            [In, MarshalAs(U2)] InternetPort nServerPort,
            [In, MarshalAs(LPWStr)] string lpszUserName,
            [In, MarshalAs(LPWStr)] string lpszPassword,
            [In, MarshalAs(U4)] InternetService dwService,
            [In, MarshalAs(U4)] InternetFlags dwFlags,
            UIntPtr dwContext);

        /// <summary>
        /// Closes a single Internet handle. See the Remarks section.
        /// </summary>
        /// <param name="hInternet">Handle to be closed.</param>
        /// <returns>Returns <see langword="true"/> if the handle is successfully closed, or <see langword="false"/> otherwise. To get extended error information, call <see cref="GetLastWin32Error"/>.</returns>
        /// <remarks>
        /// <para>The function terminates any pending operations on the handle and discards any outstanding data.</para>
        /// <para>It is safe to call <see cref="InternetCloseHandle"/> as long as no API calls are being made or will be made using the handle. Once an API has returned <see cref="IOPending"/>, it is safe to call <see cref="InternetCloseHandle"/> to cancel that I/O, as long as no subsequent API calls will be issued with the handle.</para>
        /// <para>It is safe to call <see cref="InternetCloseHandle"/> in a callback for the handle being closed. If there is a status callback registered for the handle being closed, and the handle was created with a non-<see langword="null"/> context value, an <see cref="HandleClosing"/> callback will be made. This indication will be the last callback made from a handle and indicates that the handle is being destroyed.</para>
        /// <para>If asynchronous requests are pending for the handle or any of its child handles, the handle cannot be closed immediately, but it will be invalidated. Any new requests attempted using the handle will return with an <see cref="InvalidHandle"/> notification. The asynchronous requests will complete with <see cref="RequestComplete"/>. Applications must be prepared to receive any <see cref="RequestComplete"/> indications on the handle before the final <see cref="HandleClosing"/> indication is made, which indicates that the handle is completely closed.</para>
        /// <para>An application can call <see cref="GetLastWin32Error"/> to determine if requests are pending. If <see cref="GetLastWin32Error"/> returns <see cref="IOPending"/>, there were outstanding requests when the handle was closed.</para>
        /// </remarks>
        [DllImport(Wininet, SetLastError = true, CharSet = Unicode, PreserveSig = true)]
        [return: MarshalAs(Bool)]
        public static extern bool InternetCloseHandle(IntPtr hInternet);

        /// <summary>
        /// <para>This implementation is designed for FTP protocol ONLY. Documentation about the behavior this function has for Gopher protocol is here for information only.</para>
        /// <para>Continues a file search started as a result of a previous call to <see cref="FtpFindFirstFile"/>.</para>
        /// <para><b>Windows XP and Windows Server 2003 R2 and earlier:</b> Or continues a file search as a result of a previous call to <see cref="GopherFindFirstFile"/>.</para>
        /// </summary>
        /// <param name="hFind"><para>Handle returned from either <see cref="FtpFindFirstFile"/> or <see cref="InternetOpenUrl"/> (directories only).</para>
        /// <para><b>Windows XP and Windows Server 2003 R2 and earlier:</b> Also a handle returned from <see cref="GopherFindFirstFile"/>.</para></param>
        /// <param name="lpvFindData">Information about the file or directory.</param>
        /// <returns>Returns <see langword="true"/> if the function succeeds, or <see langword="false"/> otherwise. To get extended error information, call <see cref="GetLastWin32Error"/>. If the function finds no matching files, <see cref="GetLastWin32Error"/> returns <see cref="NoMoreFiles"/>.</returns>
        [DllImport(Wininet, SetLastError = true, CharSet = Unicode, PreserveSig = true)]
        [return: MarshalAs(Bool)]
        public static extern bool InternetFindNextFile(IntPtr hFind,
            [Out] out Win32FindData lpvFindData);

        /// <summary>
        /// Writes data to an open Internet file. See the Remarks section.
        /// </summary>
        /// <param name="hFile">Handle returned from a previous call to <see cref="FtpOpenFile"/> or an handle sent by <see cref="HttpSendRequestEx"/>.</param>
        /// <param name="lpBuffer">A buffer that contains the data to be written to the file.</param>
        /// <param name="dwNumberOfBytesToWrite">Number of bytes to be written to the file.</param>
        /// <param name="lpdwNumberOfBytesWritten">A variable that receives the number of bytes written to the file.</param>
        /// <returns>Returns <see langword="true"/> if the function succeeds, or <see langword="false"/> otherwise. To get extended error information, call <see cref="GetLastWin32Error"/>. An application can also use <see cref="InternetGetLastResponseInfo"/> when necessary.</returns>
        /// <remarks>When the application is sending data, it must call <see cref="InternetCloseHandle"/> to end the data transfer.</remarks>
        [DllImport(Wininet, SetLastError = true, CharSet = Unicode, PreserveSig = true)]
        [return: MarshalAs(Bool)]
        public static extern bool InternetWriteFile(IntPtr hFile,
            [MarshalAs(LPArray, SizeParamIndex = 2)] byte[] lpBuffer,
            [In, MarshalAs(U4)] uint dwNumberOfBytesToWrite,
            [Out, MarshalAs(U4)] out uint lpdwNumberOfBytesWritten);
    }
}
