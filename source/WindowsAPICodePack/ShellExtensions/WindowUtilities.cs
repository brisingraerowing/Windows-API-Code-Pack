using Microsoft.WindowsAPICodePack.Shell;
using Microsoft.WindowsAPICodePack.ShellExtensions.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.WindowsAPICodePack.ShellExtensions
{
    public static class WindowUtilities
    {

        public static WindowStyles GetWindowStyles(IntPtr hwnd) => (WindowStyles)HandlerNativeMethods.GetWindowLongPtr(hwnd, GetWindowLong.Style);

        public static WindowStylesEx GetWindowStylesEx(IntPtr hwnd) => (WindowStylesEx)HandlerNativeMethods.GetWindowLongPtr(hwnd, GetWindowLong.ExStyle);

        public static void SetWindowStyles(IntPtr hwnd, WindowStyles styles) => HandlerNativeMethods.SetWindowLongPtr(hwnd, GetWindowLong.Style, (uint)styles);

        public static void SetWindowStylesEx(IntPtr hwnd, WindowStylesEx styles) => HandlerNativeMethods.SetWindowLongPtr(hwnd, GetWindowLong.ExStyle, (uint)styles);

        public static void SetWindow(IntPtr hWnd, IntPtr hWndInsertAfter, int x, int y, int cx, int cy, WindowStyles styles, WindowStylesEx stylesEx, SetWindowPositionOptions windowPositionOptions)
        {

            SetWindowStyles(hWnd, styles);
            SetWindowStylesEx(hWnd, stylesEx);
            HandlerNativeMethods.SetWindowPos(hWnd, hWndInsertAfter, x, y, cx, cy, windowPositionOptions);

        }

    }
}
