using Microsoft.WindowsAPICodePack.Win32Native.Shell.DesktopWindowManager;

using System;
using System.Runtime.InteropServices;
using System.Windows.Interop;

using static Microsoft.WindowsAPICodePack.NativeAPI.Consts.DllNames;

using static System.Runtime.InteropServices.UnmanagedType;

namespace Microsoft.WindowsAPICodePack.Win32Native.Menus
{
    // TODO: implement other enums.
    public enum MenuItemInfoFlags : uint
    {
        /// <summary>
        /// Retrieves or sets the <see cref="MenuItemInfo.fState"/> member.
        /// </summary>
        State = 0x00000001,

        /// <summary>
        /// Retrieves or sets the <see cref="MenuItemInfo.wID"/> member.
        /// </summary>
        ID = 0x00000002,

        /// <summary>
        /// Retrieves or sets the <see cref="MenuItemInfo.hSubMenu"/> member.
        /// </summary>
        SubMenu = 0x00000004,

        /// <summary>
        /// Retrieves or sets the <see cref="MenuItemInfo.hbmpChecked"/> and <see cref="MenuItemInfo.hbmpUnchecked"/> members.
        /// </summary>
        CheckMarks = 0x00000008,

        /// <summary>
        /// <para>Retrieves or sets the <see cref="MenuItemInfo.fType"/> and <see cref="MenuItemInfo.dwTypeData"/> members.</para>
        /// <para>MIIM_TYPE is replaced by <see cref="Bitmap"/>, <see cref="FType"/>, and <see cref="String"/>.</para>
        /// </summary>
        Type = 0x00000010,

        /// <summary>
        /// Retrieves or sets the <see cref="MenuItemInfo.dwItemData"/> member.
        /// </summary>
        Data = 0x00000020,

        /// <summary>
        /// Retrieves or sets the <see cref="MenuItemInfo.dwTypeData"/> member.
        /// </summary>
        String = 0x00000040,

        /// <summary>
        /// Retrieves or sets the <see cref="MenuItemInfo.hbmpItem"/> member.
        /// </summary>
        Bitmap = 0x00000080,

        /// <summary>
        /// Retrieves or sets the <see cref="MenuItemInfo.fType"/> member.
        /// </summary>
        FType = 0x00000100
    }

    public struct MenuItemInfo
    {
        [MarshalAs(U4)]
        public uint cbSize;
        [MarshalAs(U4)]
        public MenuItemInfoFlags fMask;
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

        public static bool AppendMenu(in IntPtr hMenu, in MenuFlags uFlags, in uint uIDNewItem, in string lpNewItem) => AppendMenuW(hMenu, uFlags, (UIntPtr)uIDNewItem, lpNewItem);

        public static bool AppendMenu(in IntPtr hMenu, in MenuFlags uFlags, in UIntPtr uIDNewItem, in IntPtr lpNewItem) => AppendMenuW(hMenu, uFlags, uIDNewItem, lpNewItem);

        [DllImport(User32)]
        [return: MarshalAs(Bool)]
        public static extern bool EnableMenuItem([In] IntPtr hMenu, [In, MarshalAs(U4)] uint uIDEnableItem, [In, MarshalAs(U4)] MenuFlags uEnable);

        public static bool EnableMenuItemByCommand(in IntPtr hMenu, in SystemMenuCommands uIDEnableItem, in MenuFlags uEnable) => EnableMenuItem(hMenu, (uint)uIDEnableItem, MenuFlags.ByCommand | uEnable);

        public static bool EnableMenuItemByPosition(in IntPtr hMenu, in uint uIDEnableItem, in MenuFlags uEnable) => EnableMenuItem(hMenu, uIDEnableItem, MenuFlags.ByPosition | uEnable);

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
        public static extern IntPtr GetSystemMenu([In] IntPtr hWnd, [In, MarshalAs(Bool)] bool bRevert);

        public static IntPtr GetSystemMenu(in System.Windows.Window window, in bool bRevert) => DesktopWindowManager.GetSystemMenu(new WindowInteropHelper(window).Handle, bRevert);

        public static IntPtr GetSystemMenu(in System.Windows.Forms.Form form, in bool bRevert) => DesktopWindowManager.GetSystemMenu(form.Handle, bRevert);

        [DllImport(User32, SetLastError = true, ExactSpelling = true)]
        public static extern IntPtr GetSubMenu([In] IntPtr hMenu, [In, MarshalAs(I4)] int nPos);

        [DllImport(User32, SetLastError = true, CharSet = CharSet.Unicode, ExactSpelling = true)]
        [return: MarshalAs(Bool)]
        public static extern bool GetMenuItemInfoW([In] IntPtr hmenu, [In, MarshalAs(U4)] uint item, [In, MarshalAs(Bool)] bool fByPosition, [In, Out] ref MenuItemInfo lpmii);

        [DllImport(User32, SetLastError = true, ExactSpelling = true)]
        [return: MarshalAs(I4)]
        public static extern int GetMenuItemCount([In] IntPtr hMenu);

        [DllImport(User32, SetLastError = true, CharSet = CharSet.Unicode, ExactSpelling = true)]
        [return: MarshalAs(Bool)]
        public static extern bool SetMenuItemInfoW([In] IntPtr hmenu, [In, MarshalAs(U4)] uint item, [In, MarshalAs(Bool)] bool fByPositon, [In] ref MenuItemInfo lpmii);

        public static bool SetMenuItemInfo(IntPtr hmenu, uint item, ref MenuItemInfo lpmii) => SetMenuItemInfoW(hmenu, item, true, ref lpmii);

        public static bool SetMenuItemInfo(IntPtr hmenu, SystemMenuCommands item, ref MenuItemInfo lpmii) => SetMenuItemInfoW(hmenu, (uint)item, false, ref lpmii);
    }
}
