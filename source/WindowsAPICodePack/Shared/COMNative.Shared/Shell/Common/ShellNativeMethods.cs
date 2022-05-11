using Microsoft.WindowsAPICodePack.Win32Native;
using Microsoft.WindowsAPICodePack.Win32Native.Shell;

using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

using static Microsoft.WindowsAPICodePack.NativeAPI.Consts.DllNames;
using static Microsoft.WindowsAPICodePack.NativeAPI.Consts.Shell;

namespace Microsoft.WindowsAPICodePack.COMNative.Shell
{
    public static class Shell
    {
        #region Shell Library Helper Methods
        [DllImport(Shell32, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Winapi, SetLastError = true)]
        public static extern int SHShowManageLibraryUI(
            [In, MarshalAs(UnmanagedType.Interface)] IShellItem library,
            [In] IntPtr hwndOwner,
            [In] string title,
            [In] string instruction,
            [In] LibraryManageDialogOptions lmdOptions);
        #endregion

#if WAPICP3
        public static IntPtr GetPidl(string directory, string name = null)
        {
            if (name == null)
            {
                DirectoryInfo parent = Directory.GetParent(directory);

                if (parent == null)

                    return IntPtr.Zero;

                name = Path.GetFileName(directory);

                directory = parent.FullName;

            }

            IShellFolder oParentFolder = GetParentFolder(directory);

            if (oParentFolder == null)

                return IntPtr.Zero;

            uint pchEaten = 0;
            uint pdwAttributes = 0;

            _ = oParentFolder.ParseDisplayName(IntPtr.Zero, IntPtr.Zero, name, ref pchEaten, out IntPtr pPidl, ref pdwAttributes);

            _ = Marshal.ReleaseComObject(oParentFolder);

            oParentFolder = null;

            return pPidl;
        }

        public static IShellFolder GetParentFolder(string folderName)
        {
            _ = SHGetDesktopFolder(out IShellFolder oDesktopFolder);

            if (oDesktopFolder == null)

                return null;

            uint pchEaten = 0;
            uint pdwAttributes = 0;

            HResult nResult = oDesktopFolder.ParseDisplayName(IntPtr.Zero, IntPtr.Zero, folderName, ref pchEaten, out IntPtr pPidl, ref pdwAttributes);

            if (!CoreErrorHelper.Succeeded(nResult))

                return null;

            IntPtr pStrRet = Marshal.AllocCoTaskMem((MaxPath * 2) + 4);

            Marshal.WriteInt32(pStrRet, 0, 0);

            _ = oDesktopFolder.GetDisplayNameOf(pPidl, GetDisplayNameFlags.ForParsing, pStrRet);

            var strFolder = new StringBuilder(MaxPath);

            _ = StrRetToBufW(pStrRet, pPidl, strFolder, MaxPath);

            Marshal.FreeCoTaskMem(pStrRet);

            pStrRet = IntPtr.Zero;

            Guid guid = new Guid(NativeAPI.Guids.Shell.IShellFolder);

            nResult = oDesktopFolder.BindToObject(pPidl, IntPtr.Zero, ref guid, out IShellFolder shellFolder);

            Marshal.FreeCoTaskMem(pPidl);

            _ = Marshal.ReleaseComObject(oDesktopFolder);

            oDesktopFolder = null;

            return CoreErrorHelper.Succeeded(nResult) ? shellFolder : null;
        }
#endif

        [DllImport(Shell32, CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern int SHCreateShellItemArrayFromDataObject(
            System.Runtime.InteropServices.ComTypes.IDataObject pdo,
            ref Guid riid,
            [MarshalAs(UnmanagedType.Interface)] out IShellItemArray iShellItemArray);

        [DllImport(Shell32, CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern
#if WAPICP3
            HResult
#else
            int
#endif
            SHCreateItemFromParsingName(
            [MarshalAs(UnmanagedType.LPWStr)] string path,
            // The following parameter is not used - binding context.
            IntPtr pbc,
            ref Guid riid,
            [MarshalAs(UnmanagedType.Interface)] out IShellItem2 shellItem);

        [DllImport(Shell32, CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern int SHCreateItemFromParsingName(
            [MarshalAs(UnmanagedType.LPWStr)] string path,
            // The following parameter is not used - binding context.
            IntPtr pbc,
            ref Guid riid,
            [MarshalAs(UnmanagedType.Interface)] out IShellItem shellItem);

        [DllImport(Shell32, CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern int SHCreateItemFromIDList(
            /*PCIDLIST_ABSOLUTE*/ IntPtr pidl,
            ref Guid riid,
            [MarshalAs(UnmanagedType.Interface)] out IShellItem2 ppv);

        [DllImport(Shell32, CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern
#if WAPICP3
            HResult
#else
            int
#endif
            SHGetDesktopFolder(
            [MarshalAs(UnmanagedType.Interface)] out IShellFolder ppshf
        );

        [DllImport(Shell32, CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern int SHCreateShellItem(
            IntPtr pidlParent,
            [In, MarshalAs(UnmanagedType.Interface)] IShellFolder psfParent,
            IntPtr pidl,
            [MarshalAs(UnmanagedType.Interface)] out IShellItem ppsi
        );

        [DllImport(Shlwapi, ExactSpelling = true, CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern HResult StrRetToBufW(IntPtr pstr, IntPtr pidl, StringBuilder pszBuf, [MarshalAs(UnmanagedType.U4)] uint cchBuf);
    }
}
