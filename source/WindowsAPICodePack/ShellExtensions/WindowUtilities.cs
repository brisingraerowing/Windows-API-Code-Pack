using Microsoft.WindowsAPICodePack.Shell;
using Microsoft.WindowsAPICodePack.ShellExtensions.Interop;
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
            int result = HandlerNativeMethods.GetWindowLongPtr(hwnd, GetWindowLong.Style);

            if (result == 0)

                Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error());

            return (WindowStyles)result;
        }

        public static WindowStylesEx GetWindowStylesEx(IntPtr hwnd)
        {
            int result = HandlerNativeMethods.GetWindowLongPtr(hwnd, GetWindowLong.ExStyle);

            if (result == 0)

                Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error());

            return (WindowStylesEx)result;
        }

        public static void SetWindowStyles(IntPtr hwnd, WindowStyles styles)
        {
            if (HandlerNativeMethods.SetWindowLongPtr(hwnd, GetWindowLong.Style, (uint)styles) == 0)

                Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error());
        }

        public static void SetWindowStylesEx(IntPtr hwnd, WindowStylesEx styles)
        {
            if (HandlerNativeMethods.SetWindowLongPtr(hwnd, GetWindowLong.ExStyle, (uint)styles) == 0)

                Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error());
        }

        public static void SetWindow(IntPtr hWnd, IntPtr hWndInsertAfter, int x, int y, int cx, int cy, WindowStyles styles, WindowStylesEx stylesEx, SetWindowPositionOptions windowPositionOptions)
        {

            SetWindowStyles(hWnd, styles);
            SetWindowStylesEx(hWnd, stylesEx);
            HandlerNativeMethods.SetWindowPos(hWnd, hWndInsertAfter, x, y, cx, cy, windowPositionOptions);

        }

        public static bool IsOnForeground(IntPtr hWnd)
        {

            IntPtr activatedHandle = HandlerNativeMethods.GetForegroundWindow();

            return activatedHandle != null && activatedHandle != IntPtr.Zero && activatedHandle == hWnd;

        }

        public static bool AreAnyCurrentThreadWindowOnForeground()
        {

            IntPtr activatedHandle = HandlerNativeMethods.GetForegroundWindow();

            if (activatedHandle == null || activatedHandle == IntPtr.Zero) return false;

            int procId = Process.GetCurrentProcess().Id;

            HandlerNativeMethods.GetWindowThreadProcessId(activatedHandle, out int activeProcId);

            return activeProcId == procId;

        }

    }
}
