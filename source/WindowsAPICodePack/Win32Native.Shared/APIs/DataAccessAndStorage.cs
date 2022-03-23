using Microsoft.WindowsAPICodePack.Win32Native.Shell;

using System;
using System.Runtime.InteropServices;

using static Microsoft.WindowsAPICodePack.NativeAPI.Consts.DllNames;
using static Microsoft.WindowsAPICodePack.NativeAPI.Consts.Shell;
using static Microsoft.WindowsAPICodePack.Win32Native.CoreErrorHelper;
using static Microsoft.WindowsAPICodePack.Win32Native.ErrorCode;

using static System.Runtime.InteropServices.Marshal;
using static System.Runtime.InteropServices.UnmanagedType;

namespace Microsoft.WindowsAPICodePack.Win32Native.DataAccessAndStorage
{
    public static partial class NativeMethods
    {
        /// <summary>
        /// Searches a directory for a file or subdirectory with a name that matches a specific name (or partial name if wildcards are used). See the Remarks section.
        /// </summary>
        /// <param name="lpFileName">
        /// <para>The directory or path, and the file name. The file name can include wildcard characters, for example, an asterisk (*) or a question mark (?).</para>
        /// <para>This parameter should not be <see langword="null"/>, an invalid string (for example, an empty string or a string that is missing the terminating null character), or end in a trailing backslash (\).</para>
        /// <para>If the string ends with a wildcard, period (.), or directory name, the user must have access permissions to the root and all subdirectories on the path.</para>
        /// <para>In the ANSI version of this function, the name is limited to <see cref="MaxPath"/> characters. To extend this limit to 32,767 wide characters, call this Unicode version of the function and prepend "\\?\" to the path. For more information, see <see href="https://docs.microsoft.com/en-us/windows/desktop/FileIO/naming-a-file">Naming a File</see>.</para>
        /// <para>Tip: Starting in Windows 10, version 1607, for the unicode version of this function (<see cref="FindFirstFile"/>), you can opt-in to remove the <see cref="MaxPath"/> character limitation without prepending "\\?\". See the "Maximum Path Limitation" section of <see href="https://docs.microsoft.com/en-us/windows/desktop/FileIO/naming-a-file">Naming Files, Paths, and Namespaces</see> for details.</para>
        /// </param>
        /// <param name="lpFindFileData">Information about a found file or directory.</param>
        /// <returns>
        /// <para>If the function succeeds, the return value is a search handle used in a subsequent call to <see cref="FindNextFile"/> or <see cref="FindClose"/>, and the <paramref name="lpFindFileData"/> parameter contains information about the first file or directory found.</para>
        /// <para>If the function fails or fails to locate files from the search string in the <paramref name="lpFileName"/> parameter, the return value is <see cref="InvalidHandleValue"/> and the contents of <paramref name="lpFindFileData"/> are indeterminate. To get extended error information, call the <see cref="GetLastWin32Error"/> function.</para>
        /// <para>If the function fails because no matching files can be found, the <see cref="GetLastWin32Error"/> function returns <see cref="FileNotFound"/>.</para>
        /// </returns>
        /// <remarks>
        /// <para>To specify additional attributes to use in a search, use the <see cref="FindFirstFileEx"/> function.</para>
        /// <para>To perform this operation as a transacted operation, use the <see cref="FindFirstFileTransacted"/> function.</para>
        /// <para>See <see href="https://docs.microsoft.com/en-us/windows/win32/api/fileapi/nf-fileapi-findfirstfilew">FindFirstFileW</see> for other remarks.</para>
        /// </remarks>
        [DllImport(Shell32, CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern IntPtr FindFirstFile(
            [In, MarshalAs(LPWStr)] string lpFileName,
            [Out] out Win32FindData lpFindFileData);
    }
}
