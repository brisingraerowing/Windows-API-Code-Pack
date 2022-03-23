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

#if WAPICP3
        public static void DeleteConsoleMenu(in System.Collections.Generic.IEnumerable<SystemMenuCommands> enumerable)
        {
            foreach (SystemMenuCommands item in enumerable)

                _ = Menus.Menus.DeleteMenu(DesktopWindowManager.GetSystemMenu(GetConsoleWindow(), false), item);
        }

        public static void DeleteConsoleMenu(params SystemMenuCommands[] menus) => DeleteConsoleMenu((System.Collections.Generic.IEnumerable<SystemMenuCommands>)menus);

        public static void DeleteConsoleMenu(in System.Collections.Generic.IEnumerable<uint> enumerable)
        {
            foreach (uint item in enumerable)

                _ = Menus.Menus.DeleteMenu(DesktopWindowManager.GetSystemMenu(GetConsoleWindow(), false), item);
        }

        public static void DeleteConsoleMenu(params uint[] menus) => DeleteConsoleMenu((System.Collections.Generic.IEnumerable<uint>)menus);
#else
        public static void DeleteConsoleMenu(in System.Collections.Generic.IEnumerable<KeyValuePair<SystemMenuCommands, MenuFlags>> enumerable)
        {
            foreach (KeyValuePair<SystemMenuCommands, MenuFlags> item in enumerable)

                _ = Menus.Menus.DeleteMenu(DesktopWindowManager.GetSystemMenu(GetConsoleWindow(), false), (uint)item.Key, item.Value);
        }

        public static void DeleteConsoleMenu(params KeyValuePair<SystemMenuCommands, MenuFlags>[] menus) => DeleteConsoleMenu((System.Collections.Generic.IEnumerable<KeyValuePair<SystemMenuCommands, MenuFlags>>)menus);
#endif
    }
}
