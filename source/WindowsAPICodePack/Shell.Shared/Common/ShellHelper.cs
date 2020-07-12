//Copyright (c) Microsoft Corporation.  All rights reserved.  Distributed under the Microsoft Public License (MS-PL)

using System;
using System.IO;
using System.Runtime.InteropServices;
using Microsoft.WindowsAPICodePack.PropertySystem;
using Microsoft.WindowsAPICodePack.Shell.PropertySystem;
using Microsoft.WindowsAPICodePack.Win32Native;
using Microsoft.WindowsAPICodePack.Win32Native.Shell;
using Microsoft.WindowsAPICodePack.COMNative.Shell.PropertySystem;
using Microsoft.WindowsAPICodePack.Win32Native.Shell.Resources;
using Microsoft.WindowsAPICodePack.COMNative.Shell;

namespace Microsoft.WindowsAPICodePack.Shell
{
    /// <summary>
    /// A helper class for Shell Objects
    /// </summary>
    internal static class ShellHelper
    {
        internal static string GetParsingName(IShellItem shellItem)
        {
            if (shellItem == null) return null;

            string path = null;

            HResult hr = shellItem.GetDisplayName(ShellItemDesignNameOptions.DesktopAbsoluteParsing, out IntPtr pszPath);

            if (hr != HResult.Ok && hr != HResult.InvalidArguments)

                throw new ShellException(LocalizedMessages.ShellHelperGetParsingNameFailed, hr);

            if (pszPath != IntPtr.Zero)
            {
                path = Marshal.PtrToStringAuto(pszPath);
                Marshal.FreeCoTaskMem(pszPath);
                pszPath = IntPtr.Zero;
            }

            return path;

        }

        internal static string GetAbsolutePath(string path) => Uri.IsWellFormedUriString(path, UriKind.Absolute) ? path : Path.GetFullPath(path);

        internal static PropertyKey ItemTypePropertyKey = new PropertyKey(new Guid("28636AA6-953D-11D2-B5D6-00C04FD918D0"), 11);

        internal static string GetItemType(IShellItem2 shellItem) => shellItem != null && shellItem.GetString(ref ItemTypePropertyKey, out string itemType) == HResult.Ok ? itemType : null;

        internal static IntPtr PidlFromParsingName(string name) => (CoreErrorHelper.Succeeded(Win32Native.Shell.Shell.SHParseDisplayName(
                name, IntPtr.Zero, out IntPtr pidl, 0,
                out _)) ? pidl : IntPtr.Zero);

        internal static IntPtr PidlFromShellItem(IShellItem nativeShellItem) => PidlFromUnknown(Marshal.GetIUnknownForObject(nativeShellItem));

        internal static IntPtr PidlFromUnknown(IntPtr unknown) => CoreErrorHelper.Succeeded(Win32Native.Shell.Shell.SHGetIDListFromObject(unknown, out IntPtr pidl)) ? pidl : IntPtr.Zero;

    }
}
