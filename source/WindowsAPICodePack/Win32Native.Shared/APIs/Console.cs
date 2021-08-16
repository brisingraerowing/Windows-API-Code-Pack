using Microsoft.WindowsAPICodePack.Win32Native.Shell.DesktopWindowManager;

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Microsoft.WindowsAPICodePack.Win32Native.Console
{
    public static class Console
    {
        [DllImport(NativeAPI.Consts.DllNames.Kernel32, ExactSpelling = true)]
        public static extern IntPtr GetConsoleWindow();

        public static void DeleteConsoleMenu(in System.Collections.Generic.IEnumerable<KeyValuePair<SystemMenuCommands, MenuFlags>> enumerable)
        {
            foreach (KeyValuePair<SystemMenuCommands, MenuFlags> item in enumerable)

                Menus.Menus.DeleteMenu(DesktopWindowManager.GetSystemMenu(GetConsoleWindow(), false), item.Key, item.Value);
        }

        public static void DeleteConsoleMenu(params KeyValuePair<SystemMenuCommands, MenuFlags>[] menus) => DeleteConsoleMenu((System.Collections.Generic.IEnumerable<KeyValuePair<SystemMenuCommands, MenuFlags>>)menus);
    }
}
