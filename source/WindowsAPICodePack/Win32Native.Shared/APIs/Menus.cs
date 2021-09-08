using Microsoft.WindowsAPICodePack.Win32Native.Shell.DesktopWindowManager;

using System;
using System.Runtime.InteropServices;
#if !NETSTANDARD
using System.Windows.Interop;
#endif

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

    /// <summary>
    /// Options for <see cref="Menus.TrackPopupMenu(IntPtr, TrackPopupMenuFlags, int, int, int, IntPtr, IntPtr)"/>.
    /// </summary>
    [Flags]
    public enum TrackPopupMenuFlags : uint
    {
        /// <summary>
        /// <para>Name: TPM_LEFTBUTTON</para>
        /// <para>Description: The user can select menu items with only the left mouse button.</para>
        /// </summary>
        LeftButton = 0x0000,

        /// <summary>
        /// <para>Name: TPM_RIGHTBUTTON</para>
        /// <para>Description: The user can select menu items with both the left and right mouse buttons.</para>
        /// </summary>
        RightButton = 0x0002,

        /// <summary>
        /// <para>Name: TPM_LEFTALIGN</para>
        /// <para>Description: Positions the shortcut menu so that its left side is aligned with the coordinate specified by the x parameter.</para>
        /// </summary>
        LeftAlign = LeftButton,

        /// <summary>
        /// <para>Name: TPM_CENTERALIGN</para>
        /// <para>Description: Centers the shortcut menu horizontally relative to the coordinate specified by the x parameter.</para>
        /// </summary>
        CenterAlign = 0x0004,

        /// <summary>
        /// <para>Name: TPM_RIGHTALIGN</para>
        /// <para>Description: Positions the shortcut menu so that its right side is aligned with the coordinate specified by the x parameter.</para>
        /// </summary>
        RightAlign = 0x0008,

        /// <summary>
        /// <para>Name: TPM_TOPALIGN</para>
        /// <para>Description: Positions the shortcut menu so that its top side is aligned with the coordinate specified by the y parameter.</para>
        /// </summary>
        TopAlign = LeftButton,

        /// <summary>
        /// <para>Name: TPM_VCENTERALIGN</para>
        /// <para>Description: Centers the shortcut menu vertically relative to the coordinate specified by the y parameter.</para>
        /// </summary>
        VerticalCenterAlign = 0x0010,

        /// <summary>
        /// <para>Name: TPM_BOTTOMALIGN</para>
        /// <para>Description: Positions the shortcut menu so that its bottom side is aligned with the coordinate specified by the y parameter.</para>
        /// </summary>
        BottomAlign = 0x0020,

        /// <summary>
        /// <para>Name: TPM_HORIZONTAL</para>
        /// <para>Description: If the menu cannot be shown at the specified location without overlapping the excluded rectangle, the system tries to accommodate the requested horizontal alignment before the requested vertical alignment.</para>
        /// </summary>
        Horizontal = LeftButton,  /* Horz alignment matters more */

        /// <summary>
        /// <para>Name: TPM_VERTICAL</para>
        /// <para>Description: If the menu cannot be shown at the specified location without overlapping the excluded rectangle, the system tries to accommodate the requested vertical alignment before the requested horizontal alignment.</para>
        /// </summary>
        Vertical = 0x0040,   /* Vert alignment matters more */

        /// <summary>
        /// <para>Name: TPM_NONOTIFY</para>
        /// <para>Description: The function does not send notification messages when the user clicks a menu item.</para>
        /// </summary>
        NoNotify = 0x0080,    /* Don't send any notification msgs */

        /// <summary>
        /// <para>Name: TPM_RETURNCMD</para>
        /// <para>Description: The function returns the menu item identifier of the user's selection in the return value.</para>
        /// </summary>
        ReturnCommand = 0x0100,

        /// <summary>
        /// <para>Name: TPM_RECURSE</para>
        /// <para>Description: Displays a menu when another menu is already displayed. This is intended to support context menus within a menu.</para>
        /// </summary>
        Recurse = 0x0001,

        /// <summary>
        /// <para>Name: TPM_HORPOSANIMATION</para>
        /// <para>Description: Animates the menu from left to right.</para>
        /// </summary>
        HorizontalPositionAnimation = 0x0400,

        /// <summary>
        /// <para>Name: TPM_HORNEGANIMATION</para>
        /// <para>Description: Animates the menu from right to left.</para>
        /// </summary>
        HorizontalNegativeAnimation = 0x0800,

        /// <summary>
        /// <para>Name: TPM_VERPOSANIMATION</para>
        /// <para>Description: Animates the menu from top to bottom.</para>
        /// </summary>
        VerticalPositionAnimation = 0x1000,

        /// <summary>
        /// <para>Name: TPM_VERNEGANIMATION</para>
        /// <para>Description: Animates the menu from bottom to top.</para>
        /// </summary>
        VerticalNegativeAnimation = 0x2000,

        /// <summary>
        /// <para>Name: TPM_NOANIMATION</para>
        /// <para>Description: Displays menu without animation.</para>
        /// </summary>
        NoAnimation = 0x4000,

        /// <summary>
        /// <para>Name: TPM_LAYOUTRTL</para>
        /// <para>Description: Uses right-to-left text layout. By default, the text layout is left-to-right.</para>
        /// </summary>
        LayoutRightToLeft = 0x8000,

        WorkArea = 0x10000
    }

    public struct TrackPopupMenuParams
    {
        [MarshalAs(U4)]
        public uint cbSize;     /* Size of structure */

        public System.Drawing.Rectangle rcExclude;  /* Screen coordinates of rectangle to exclude when positioning */
    }

    public static class Menus
    {
        [DllImport(User32, ExactSpelling = true)]
        public static extern IntPtr CreatePopupMenu();

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

#if !NETSTANDARD
        public static IntPtr GetSystemMenu(in System.Windows.Window window, in bool bRevert) => DesktopWindowManager.GetSystemMenu(new WindowInteropHelper(window).Handle, bRevert);

        public static IntPtr GetSystemMenu(in System.Windows.Forms.Form form, in bool bRevert) => DesktopWindowManager.GetSystemMenu(form.Handle, bRevert);
#endif

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

        [DllImport(User32, CharSet = CharSet.Unicode, ExactSpelling = true, SetLastError = true)]
        [return: MarshalAs(U4)]
        public static extern uint TrackPopupMenu([In] IntPtr hMenu, [In, MarshalAs(U4)] TrackPopupMenuFlags uFlags, [In, MarshalAs(I4)] int x, [In, MarshalAs(I4)] int y, [In, MarshalAs(I4)] int nReserved, [In] IntPtr hWnd, IntPtr prcRect);

        public static uint TrackPopupMenu(in IntPtr hMenu, in TrackPopupMenuFlags uFlags, in System.Drawing.Point point, in IntPtr hWnd) => TrackPopupMenu(hMenu, uFlags, point.X, point.Y, 0, hWnd, IntPtr.Zero);

        [DllImport(User32, CharSet = CharSet.Unicode, ExactSpelling = true, SetLastError = true)]
        [return: MarshalAs(U4)]
        public static extern uint TrackPopupMenuEx([In] IntPtr hMenu, [In, MarshalAs(U4)] TrackPopupMenuFlags uFlags, [In, MarshalAs(I4)] int x, [In, MarshalAs(I4)] int y, [In] IntPtr hwnd, [In] IntPtr lptpm);

        [DllImport(User32, CharSet = CharSet.Unicode, ExactSpelling = true, SetLastError = true)]
        [return: MarshalAs(U4)]
        public static extern uint TrackPopupMenuEx([In] IntPtr hMenu, [In, MarshalAs(U4)] TrackPopupMenuFlags uFlags, [In, MarshalAs(I4)] int x, [In, MarshalAs(I4)] int y, [In] IntPtr hwnd, [In] TrackPopupMenuParams lptpm);

        public static uint TrackPopupMenuEx(in IntPtr hMenu, in TrackPopupMenuFlags uFlags, in System.Drawing.Point point, in IntPtr hwnd, in System.Drawing.Rectangle? lptpm) => lptpm.HasValue ? TrackPopupMenuEx(hMenu, uFlags, point.X, point.Y, hwnd, new TrackPopupMenuParams() { cbSize = (uint)Marshal.SizeOf
#if CS7
            <
#else
            (typeof(
#endif
            TrackPopupMenuParams
#if CS7
            >(
#else
            )
#endif
            ), rcExclude = lptpm.Value }) : TrackPopupMenuEx(hMenu, uFlags, point.X, point.Y, hwnd, IntPtr.Zero);
        }
}
