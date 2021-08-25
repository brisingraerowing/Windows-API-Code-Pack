using Microsoft.WindowsAPICodePack.Win32Native.Shell.DesktopWindowManager;

using System;
using System.Runtime.InteropServices;

using static Microsoft.WindowsAPICodePack.NativeAPI.Consts.DllNames;

using static System.Runtime.InteropServices.UnmanagedType;

namespace Microsoft.WindowsAPICodePack.Win32Native.Menus
{
    public struct MenuItemInfo
    {
        [MarshalAs(U4)]
        public uint cbSize;
        [MarshalAs(U4)]
        public uint fMask;
        [MarshalAs(U4)]
        public uint fType;         // used if MIIM_TYPE (4.0) or MIIM_FTYPE (>4.0)
        [MarshalAs(U4)]
        public uint fState;        // used if MIIM_STATE
        [MarshalAs(U4)]
        public uint wID;           // used if MIIM_ID
        public IntPtr hSubMenu;      // used if MIIM_SUBMENU
        public IntPtr hbmpChecked;   // used if MIIM_CHECKMARKS
        public IntPtr hbmpUnchecked; // used if MIIM_CHECKMARKS
        public UIntPtr dwItemData;   // used if MIIM_DATA
        [MarshalAs(LPWStr)]
        public string dwTypeData;    // used if MIIM_TYPE (4.0) or MIIM_STRING (>4.0)
        [MarshalAs(U4)]
        public uint cch;           // used if MIIM_TYPE (4.0) or MIIM_STRING (>4.0)
        public IntPtr hbmpItem;      // used if MIIM_BITMAP
    }

    public static class Menus
    {
        [DllImport(User32, CharSet = CharSet.Unicode, ExactSpelling = true, SetLastError = true)]
        [return: MarshalAs(Bool)]
        public static extern bool AppendMenuW([In] IntPtr hMenu, [In, MarshalAs(U4)] MenuFlags uFlags, [In] UIntPtr uIDNewItem, [In, MarshalAs(LPWStr)] string lpNewItem);

        [DllImport(User32, CharSet = CharSet.Unicode, ExactSpelling = true, SetLastError = true)]
        [return: MarshalAs(Bool)]
        public static extern bool AppendMenuW([In] IntPtr hMenu, [In, MarshalAs(U4)] MenuFlags uFlags, [In] UIntPtr uIDNewItem, [In] IntPtr lpNewItem);

        public static bool AppendMenuW(in IntPtr hMenu, in MenuFlags uFlags, in uint uIDNewItem, in string lpNewItem) => AppendMenuW(hMenu, uFlags, (UIntPtr)uIDNewItem, lpNewItem);

        public static bool AppendMenuW(in IntPtr hMenu, in MenuFlags uFlags, in UIntPtr uIDNewItem, in IntPtr lpNewItem) => AppendMenuW(hMenu, uFlags, uIDNewItem, lpNewItem);

        [DllImport(User32)]
        [return: MarshalAs(Bool)]
        public static extern bool EnableMenuItem([In] IntPtr hMenu, [In, MarshalAs(U4)] uint uIDEnableItem, [In, MarshalAs(U4)] MenuFlags uEnable);

        public static bool EnableMenuItem(in IntPtr hMenu, in SystemMenuCommands uIDEnableItem) => EnableMenuItem(hMenu, (uint)uIDEnableItem, MenuFlags.ByCommand);

        public static bool EnableMenuItem(in IntPtr hMenu, in uint uIDEnableItem) => EnableMenuItem(hMenu, uIDEnableItem, MenuFlags.ByPosition);

        [DllImport(User32, SetLastError = true)]
        [return: MarshalAs(Bool)]
        public static extern bool DeleteMenu([In] IntPtr hMenu, [In, MarshalAs(U4)] uint uPosition, [In, MarshalAs(U4)] MenuFlags uFlags);

        public static bool DeleteMenu(in IntPtr hMenu, in SystemMenuCommands uCommand) => DeleteMenu(hMenu, (uint)uCommand, MenuFlags.ByCommand);

        public static bool DeleteMenu(in IntPtr hMenu, in uint uPosition) => DeleteMenu(hMenu, uPosition, MenuFlags.ByPosition);

        [DllImport(User32, SetLastError = true, ExactSpelling = true)]
        [return: MarshalAs(Bool)]
        public static extern bool DestroyMenu([In] IntPtr hMenu);

        [DllImport(User32, SetLastError = true, ExactSpelling = true)]
        [return: MarshalAs(U4)]
        public static extern uint GetMenuItemID([In] IntPtr hMenu, [In, MarshalAs(I4)] int nPos);

        [DllImport(User32, SetLastError = true, ExactSpelling = true)]
        public static extern IntPtr GetSubMenu([In] IntPtr hMenu, [In, MarshalAs(I4)] int nPos);

        [DllImport(User32, SetLastError = true, CharSet = CharSet.Unicode, ExactSpelling = true)]
        [return: MarshalAs(Bool)]
        public static extern bool GetMenuItemInfoW([In] IntPtr hmenu, [In, MarshalAs(U4)] uint item, [In, MarshalAs(Bool)] bool fByPosition, [In, Out] ref MenuItemInfo lpmii);

        [DllImport(User32, SetLastError = true, ExactSpelling = true)]
        [return:MarshalAs(I4)]
        public static extern int GetMenuItemCount([In] IntPtr hMenu);
    }
}
