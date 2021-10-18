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
    public static class Menus
    {
        [DllImport(User32, ExactSpelling = true)]
        public static extern IntPtr CreatePopupMenu();

        [DllImport(User32, CharSet = CharSet.Unicode, ExactSpelling = true, SetLastError = true)]
        [return: MarshalAs(Bool)]
        public static extern bool AppendMenuW([In] IntPtr hMenu, [In, MarshalAs(U4)]
#if !WAPICP3
        Shell.DesktopWindowManager.
#endif
        MenuFlags uFlags, [In] UIntPtr uIDNewItem, [In, MarshalAs(LPWStr)] string lpNewItem);

        [DllImport(User32, CharSet = CharSet.Unicode, ExactSpelling = true, SetLastError = true)]
        [return: MarshalAs(Bool)]
        public static extern bool AppendMenuW([In] IntPtr hMenu, [In, MarshalAs(U4)] 
#if !WAPICP3
        Shell.DesktopWindowManager.
#endif
      MenuFlags uFlags, [In] UIntPtr uIDNewItem, [In] IntPtr lpNewItem);

        public static bool AppendMenu(in IntPtr hMenu, in
#if !WAPICP3
        Shell.DesktopWindowManager.
#endif
      MenuFlags uFlags, in uint uIDNewItem, in string lpNewItem) => AppendMenuW(hMenu, uFlags, (UIntPtr)uIDNewItem, lpNewItem);

        public static bool AppendMenu(in IntPtr hMenu, in
#if !WAPICP3
        Shell.DesktopWindowManager.
#endif
      MenuFlags uFlags, in UIntPtr uIDNewItem, in IntPtr lpNewItem) => AppendMenuW(hMenu, uFlags, uIDNewItem, lpNewItem);

        [DllImport(User32)]
        [return: MarshalAs(Bool)]
        public static extern bool EnableMenuItem([In] IntPtr hMenu, [In, MarshalAs(U4)] uint uIDEnableItem, [In, MarshalAs(U4)] 
#if !WAPICP3
        Shell.DesktopWindowManager.
#endif
      MenuFlags uEnable);

        public static bool EnableMenuItemByCommand(in IntPtr hMenu, in SystemMenuCommands uIDEnableItem, in
#if !WAPICP3
        Shell.DesktopWindowManager.
#endif
      MenuFlags uEnable) => EnableMenuItem(hMenu, (uint)uIDEnableItem,
#if !WAPICP3
        Shell.DesktopWindowManager.
#endif
      MenuFlags.ByCommand | uEnable);

        public static bool EnableMenuItemByPosition(in IntPtr hMenu, in uint uIDEnableItem, in
#if !WAPICP3
        Shell.DesktopWindowManager.
#endif
      MenuFlags uEnable) => EnableMenuItem(hMenu, uIDEnableItem,
#if !WAPICP3
        Shell.DesktopWindowManager.
#endif
      MenuFlags.ByPosition | uEnable);

        [DllImport(User32, SetLastError = true)]
        [return: MarshalAs(Bool)]
        public static extern bool DeleteMenu([In] IntPtr hMenu, [In, MarshalAs(U4)] uint uPosition, [In, MarshalAs(U4)] 
#if !WAPICP3
        Shell.DesktopWindowManager.
#endif
      MenuFlags uFlags);

        public static bool DeleteMenu(in IntPtr hMenu, in SystemMenuCommands uCommand) => DeleteMenu(hMenu, (uint)uCommand,
#if !WAPICP3
        Shell.DesktopWindowManager.
#endif
      MenuFlags.ByCommand);

        public static bool DeleteMenu(in IntPtr hMenu, in uint uPosition) => DeleteMenu(hMenu, uPosition,
#if !WAPICP3
        Shell.DesktopWindowManager.
#endif
      MenuFlags.ByPosition);

        [DllImport(User32, SetLastError = true, ExactSpelling = true)]
        [return: MarshalAs(Bool)]
        public static extern bool DestroyMenu([In] IntPtr hMenu);

        [DllImport(User32, SetLastError = true, ExactSpelling = true)]
#if !WAPICP3
        [return: MarshalAs(U4)]
#endif
        public static extern
#if WAPICP3
            object
#else
            uint
#endif
            GetMenuItemID([In] IntPtr hMenu, [In, MarshalAs(I4)] int nPos);

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

        public static uint TrackPopupMenuEx(in IntPtr hMenu, in TrackPopupMenuFlags uFlags, in System.Drawing.Point point, in IntPtr hwnd, in System.Drawing.Rectangle? lptpm) => lptpm.HasValue ? TrackPopupMenuEx(hMenu, uFlags, point.X, point.Y, hwnd, new TrackPopupMenuParams()
        {
            cbSize = (uint)Marshal.SizeOf
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
            ),
            rcExclude = lptpm.Value
        }) : TrackPopupMenuEx(hMenu, uFlags, point.X, point.Y, hwnd, IntPtr.Zero);
    }
}
