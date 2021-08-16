using Microsoft.WindowsAPICodePack.Win32Native.Shell.DesktopWindowManager;

using System;
using System.Runtime.InteropServices;

using static System.Runtime.InteropServices.UnmanagedType;

namespace Microsoft.WindowsAPICodePack.Win32Native.Menus
{
    public static class Menus
    {
        [DllImport(NativeAPI.Consts.DllNames.User32)]
        [return: MarshalAs(Bool)]
        public static extern bool DeleteMenu([In] IntPtr hMenu, [In, MarshalAs(U4)] SystemMenuCommands uPosition, [In, MarshalAs(U4)] MenuFlags uFlags);
    }
}
