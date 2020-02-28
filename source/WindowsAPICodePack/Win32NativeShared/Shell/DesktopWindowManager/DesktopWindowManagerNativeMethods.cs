//Copyright (c) Microsoft Corporation.  All rights reserved.

using System;
using System.Runtime.InteropServices;
using System.Security;
using Microsoft.WindowsAPICodePack.Win32Native.Shell;
using Microsoft.WindowsAPICodePack.Win32Native.ShellExtensions;
using static Microsoft.WindowsAPICodePack.Win32Native.Shell.Consts.DesktopWindowManager;

namespace Microsoft.WindowsAPICodePack.Win32Native.Shell
{
    public static class DWMMessages
    {
        public const int WM_DWMCOMPOSITIONCHANGED = 0x031E;
        public const int WM_DWMNCRENDERINGCHANGED = 0x031F;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Margins
    {
        public int LeftWidth;      // width of left border that retains its size
        public int RightWidth;     // width of right border that retains its size
        public int TopHeight;      // height of top border that retains its size
        public int BottomHeight;   // height of bottom border that retains its size

        public Margins(bool fullWindow) => LeftWidth = RightWidth = TopHeight = BottomHeight = fullWindow ? -1 : 0;
    };

    public enum CompositionEnable
    {
        Disable = 0,
        Enable = 1
    }

        /// <summary>
        /// public class that contains interop declarations for 
        /// functions that are not benign and are performance critical. 
        /// </summary>
        public static class DesktopWindowManagerNativeMethods
        {
            [DllImport("DwmApi.dll")]
            public static extern int DwmExtendFrameIntoClientArea(
                IntPtr hwnd,
                ref Margins m);

            [DllImport("DwmApi.dll", PreserveSig = false)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool DwmIsCompositionEnabled();

            [DllImport("DwmApi.dll")]
            public static extern int DwmEnableComposition(
                CompositionEnable compositionAction);

            [DllImport("dwmapi.dll")]
            public static extern int DwmSetIconicThumbnail(
                IntPtr hwnd, IntPtr hbitmap, uint flags);

            [DllImport("dwmapi.dll")]
            public static extern int DwmInvalidateIconicBitmaps(IntPtr hwnd);

            [DllImport("dwmapi.dll")]
            public static extern int DwmSetIconicLivePreviewBitmap(
                IntPtr hwnd,
                IntPtr hbitmap,
                ref NativePoint ptClient,
                uint flags);

            [DllImport("dwmapi.dll")]
            public static extern int DwmSetIconicLivePreviewBitmap(
                IntPtr hwnd, IntPtr hbitmap, IntPtr ptClient, uint flags);

            [DllImport("dwmapi.dll", PreserveSig = true)]
            public static extern int DwmSetWindowAttribute(
                IntPtr hwnd,
                //DWMWA_* values.
                uint dwAttributeToSet,
                IntPtr pvAttributeValue,
                uint cbAttribute);

            /// <summary>
            /// Sets the specified iconic thumbnail for the specified window.
            /// This is typically done in response to a DWM message.
            /// </summary>
            /// <param name="hwnd">The window handle.</param>
            /// <param name="hBitmap">The thumbnail bitmap.</param>
            public static void SetIconicThumbnail(IntPtr hwnd, IntPtr hBitmap)
            {
                int rc = DwmSetIconicThumbnail(
                    hwnd,
                    hBitmap,
                    DisplayFrame);

                if (rc != 0)
                
                    throw Marshal.GetExceptionForHR(rc);
                            }

            /// <summary>
            /// Sets the specified peek (live preview) bitmap for the specified
            /// window.  This is typically done in response to a DWM message.
            /// </summary>
            /// <param name="hwnd">The window handle.</param>
            /// <param name="bitmap">The thumbnail bitmap.</param>
            /// <param name="displayFrame">Whether to display a standard window
            /// frame around the bitmap.</param>
            public static void SetPeekBitmap(IntPtr hwnd, IntPtr bitmap, bool displayFrame)
            {
                int rc = DwmSetIconicLivePreviewBitmap(
                    hwnd,
                    bitmap,
                    IntPtr.Zero,
                    displayFrame ? DisplayFrame : (uint)0);

                if (rc != 0)
                
                    throw Marshal.GetExceptionForHR(rc);
                            }

            /// <summary>
            /// Sets the specified peek (live preview) bitmap for the specified
            /// window.  This is typically done in response to a DWM message.
            /// </summary>
            /// <param name="hwnd">The window handle.</param>
            /// <param name="bitmap">The thumbnail bitmap.</param>
            /// <param name="offset">The client area offset at which to display
            /// the specified bitmap.  The rest of the parent window will be
            /// displayed as "remembered" by the DWM.</param>
            /// <param name="displayFrame">Whether to display a standard window
            /// frame around the bitmap.</param>
            public static void SetPeekBitmap(IntPtr hwnd, IntPtr bitmap, System.Drawing.Point offset, bool displayFrame)
            {
                var nativePoint = new NativePoint(offset.X, offset.Y);
                int rc = DwmSetIconicLivePreviewBitmap(
                    hwnd,
                    bitmap,
                    ref nativePoint,
                    displayFrame ? DisplayFrame : (uint)0);

                if (rc != 0)
                {
                    Exception e = Marshal.GetExceptionForHR(rc);

                    if (e is ArgumentException)
                    {
                        // Ignore argument exception as it's not really recommended to be throwing
                        // exception when rendering the peek bitmap. If it's some other kind of exception,
                        // then throw it.
                    }
                    else
                    
                        throw e;
                }
            }

            /// <summary>
            /// Call this method to either enable custom previews on the taskbar (second argument as true)
            /// or to disable (second argument as false). If called with True, the method will call DwmSetWindowAttribute
            /// for the specific window handle and let DWM know that we will be providing a custom bitmap for the thumbnail
            /// as well as Aero peek.
            /// </summary>
            /// <param name="hwnd"></param>
            /// <param name="enable"></param>
            public static void EnableCustomWindowPreview(IntPtr hwnd, bool enable)
            {
                IntPtr t = Marshal.AllocHGlobal(4);
                Marshal.WriteInt32(t, enable ? 1 : 0);

                try
                {
                    int rc = DwmSetWindowAttribute(hwnd, HasIconicBitmap, t, 4);

                    if (rc != 0)
                    
                        throw Marshal.GetExceptionForHR(rc);
                    
                    rc = DwmSetWindowAttribute(hwnd, ForceIconicRepresentation, t, 4);

                    if (rc != 0)
                    
                        throw Marshal.GetExceptionForHR(rc);
                                    }
                finally
                {
                    Marshal.FreeHGlobal(t);
                }
            }
        }

        public static class HandlerNativeMethods
        {

            [DllImport("user32.dll")]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool GetWindowRect(IntPtr hwnd, [Out] out NativeRect rect);

            [DllImport("user32.dll")]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool GetClientRect(IntPtr hwnd, [Out] out NativeRect rect);

            public static bool GetClientSize(IntPtr hwnd, out System.Drawing.Size size)
            {
                if (!GetClientRect(hwnd, out NativeRect rect))
                {
                    size = new System.Drawing.Size(-1, -1);
                    return false;
                }
                size = new System.Drawing.Size(rect.Right, rect.Bottom);
                return true;
            }

            [DllImport("user32.dll")]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool ClientToScreen(
                IntPtr hwnd,
                ref NativePoint point);

            [DllImport("user32.dll")]
            public static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

            [DllImport("user32.dll")]
            public static extern IntPtr GetFocus();

            //[DllImport("user32.dll")]
            //public static extern uint GetWindowLong(IntPtr hwnd, GetWindowLong index);

            [DllImport("user32.dll", EntryPoint = "GetWindowLong")]
            private static extern int GetWindowLongPtr32(IntPtr hWnd, GetWindowLongEnum nIndex);

            [DllImport("user32.dll", EntryPoint = "GetWindowLongPtr")]
            private static extern int GetWindowLongPtr64(IntPtr hWnd, GetWindowLongEnum nIndex);

            // This static method is required because Win32 does not support
            // GetWindowLongPtr directly
            public static int GetWindowLongPtr(IntPtr hWnd, GetWindowLongEnum nIndex) => IntPtr.Size == 8 ? GetWindowLongPtr64(hWnd, nIndex) : GetWindowLongPtr32(hWnd, nIndex);

        //[DllImport("user32.dll")]
        //public static extern int SetWindowLong(IntPtr hwnd, GetWindowLong index, uint newStyle);

        /// <summary>
        /// This helper static method is required because the 32-bit version of user32.dll does not contain this API
        /// (on any versions of Windows), so linking the method will fail at run-time. The bridge dispatches the request
        /// to the correct function (GetWindowLong in 32-bit mode and GetWindowLongPtr in 64-bit mode).
        /// </summary>
        /// <param name="hWnd">The pointer to the window.</param>
        /// <param name="nIndex">The property to set.</param>
        /// <param name="dwNewLong">The value to set.</param>
        /// <returns></returns>
        public static int SetWindowLongPtr(IntPtr hWnd, GetWindowLongEnum nIndex, uint dwNewLong) => IntPtr.Size == 8
                    ? SetWindowLongPtr64(hWnd, nIndex, dwNewLong)
                    : SetWindowLong32(hWnd, nIndex, dwNewLong);

            [DllImport("user32.dll", EntryPoint = "SetWindowLong")]
            private static extern int SetWindowLong32(IntPtr hWnd, GetWindowLongEnum nIndex, uint dwNewLong);

            [DllImport("user32.dll", EntryPoint = "SetWindowLongPtr")]
            private static extern int SetWindowLongPtr64(IntPtr hWnd, GetWindowLongEnum nIndex, uint dwNewLong);

            [DllImport("user32.dll")]
            public static extern bool SetWindowPos(
                IntPtr hWnd,
                IntPtr hWndInsertAfter,
                int x,
                int y,
                int cx,
                int cy,
                SetWindowPositionOptions flags);

            [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
            public static extern IntPtr GetForegroundWindow();

            [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            public static extern int GetWindowThreadProcessId(IntPtr handle, out int processId);
        }

        public enum GetWindowLongEnum
        {

            WindowProcedure = -4,
            HandleInstance = -6,
            HWndParent = -8,
            Style = -16,
            ExStyle = -20,
            UserData = -21,
            Id = -12,
            User = 0x8,
            MessageResult = 0x0,
            DLGProcedure = 0x4

        }

        [Flags]
        public enum SetWindowPositionOptions
        {
            AsyncWindowPos = 0x4000,
            DeferErase = 0x2000,
            DrawFrame = FrameChanged,
            FrameChanged = 0x0020,  // The frame changed: send WM_NCCALCSIZE
            HideWindow = 0x0080,
            NoActivate = 0x0010,
            CoCopyBits = 0x0100,
            NoMove = 0x0002,
            NoOwnerZOrder = 0x0200,  // Don't do owner Z ordering
            NoRedraw = 0x0008,
            NoResposition = NoOwnerZOrder,
            NoSendChanging = 0x0400,  // Don't send WM_WINDOWPOSCHANGING
            NoSize = 0x0001,
            NoZOrder = 0x0004,
            ShowWindow = 0x0040
        }

        public enum SetWindowPositionInsertAfter
        {
            NoTopMost = -2,
            TopMost = -1,
            Top = 0,
            Bottom = 1
        }

        public enum SystemCommand
        {

            ContextHelp = 0xF180

        }

}
