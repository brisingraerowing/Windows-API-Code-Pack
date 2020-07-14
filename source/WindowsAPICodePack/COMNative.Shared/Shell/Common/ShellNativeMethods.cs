using Microsoft.WindowsAPICodePack.COMNative.Shell;
using Microsoft.WindowsAPICodePack.Win32Native.Shell;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using static Microsoft.WindowsAPICodePack.NativeAPI.Consts.DllNames;

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

        [DllImport(Shell32, CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern int SHCreateShellItemArrayFromDataObject(
            System.Runtime.InteropServices.ComTypes.IDataObject pdo,
            ref Guid riid,
            [MarshalAs(UnmanagedType.Interface)] out IShellItemArray iShellItemArray);

        [DllImport(Shell32, CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern int SHCreateItemFromParsingName(
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
        public static extern int SHGetDesktopFolder(
            [MarshalAs(UnmanagedType.Interface)] out IShellFolder ppshf
        );

        [DllImport(Shell32, CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern int SHCreateShellItem(
            IntPtr pidlParent,
            [In, MarshalAs(UnmanagedType.Interface)] IShellFolder psfParent,
            IntPtr pidl,
            [MarshalAs(UnmanagedType.Interface)] out IShellItem ppsi
        );

    }
}
