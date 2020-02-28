using Microsoft.WindowsAPICodePack.Shell;
using Microsoft.WindowsAPICodePack.Win32Native.Shell;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.WindowsAPICodePack.ShellExtensions
{
    public static class WindowUtilities
    {

        public static WindowStyles GetWindowStyles(IntPtr hwnd)
        {
            int result = HandlerNativeMethods.GetWindowLongPtr(hwnd, GetWindowLongEnum.Style);

            if (result == 0)

                Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error());

            return (WindowStyles)result;
        }

        public static WindowStylesEx GetWindowStylesEx(IntPtr hwnd)
        {
            int result = HandlerNativeMethods.GetWindowLongPtr(hwnd, GetWindowLongEnum.ExStyle);

            if (result == 0)

                Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error());

            return (WindowStylesEx)result;
        }

        public static void SetWindowStyles(IntPtr hwnd, WindowStyles styles)
        {
            if (HandlerNativeMethods.SetWindowLongPtr(hwnd, GetWindowLongEnum.Style, (uint)styles) == 0)

                Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error());
        }

        public static void SetWindowStylesEx(IntPtr hwnd, WindowStylesEx styles)
        {
            if (HandlerNativeMethods.SetWindowLongPtr(hwnd, GetWindowLongEnum.ExStyle, (uint)styles) == 0)

                Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error());
        }

        public static void SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int x, int y, int cx, int cy, SetWindowPositionOptions windowPositionOptions)

        {

            if (!HandlerNativeMethods.SetWindowPos(hWnd, hWndInsertAfter, x, y, cx, cy, windowPositionOptions))

                Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error());

        }

        public static void SetWindow(IntPtr hWnd, IntPtr hWndInsertAfter, int x, int y, int cx, int cy, WindowStyles styles, WindowStylesEx stylesEx, SetWindowPositionOptions windowPositionOptions)
        {

            SetWindowStyles(hWnd, styles);
            SetWindowStylesEx(hWnd, stylesEx);
            SetWindowPos(hWnd, hWndInsertAfter, x, y, cx, cy, windowPositionOptions);

        }

        public static bool IsOnForeground(IntPtr hWnd)
        {

            IntPtr activatedHandle = HandlerNativeMethods.GetForegroundWindow();

            return activatedHandle != null && activatedHandle != IntPtr.Zero && activatedHandle == hWnd;

        }

        // TODO: also return the int given by HandlerNativeMethods.GetWindowThreadProcessId?
        public static int GetWindowThreadProcessId(IntPtr activatedHandle)

        {

            _ = HandlerNativeMethods.GetWindowThreadProcessId(activatedHandle, out int activeProcId);

            return activeProcId;

        }

        // TODO: should HandlerNativeMethods.GetForegroundWindow() be used directly?
        public static IntPtr GetForegroundWindow() => HandlerNativeMethods.GetForegroundWindow();

        public static bool AreAnyCurrentThreadWindowOnForeground()
        {

            IntPtr activatedHandle = GetForegroundWindow();

            if (activatedHandle == null || activatedHandle == IntPtr.Zero) return false;

            int procId = Process.GetCurrentProcess().Id;

            return GetWindowThreadProcessId(activatedHandle) == procId;

        }

    }
}
