//Copyright (c) Microsoft Corporation.  All rights reserved.  Distributed under the Microsoft Public License (MS-PL)

using System;
using System.Runtime.InteropServices;
using System.Security;
using Microsoft.WindowsAPICodePack.Win32Native.Shell;
using Microsoft.WindowsAPICodePack.Win32Native.Taskbar;
using static Microsoft.WindowsAPICodePack.Win32Native.Consts.Shell.DesktopWindowManager;
using static Microsoft.WindowsAPICodePack.Win32Native.Consts.DllNames;

namespace Microsoft.WindowsAPICodePack.Win32Native.Shell.DesktopWindowManager
{

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
    public static class DesktopWindowManager
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
        public static void SetIconicThumbnail(IntPtr hwnd, IntPtr hBitmap) => Marshal.ThrowExceptionForHR(DwmSetIconicThumbnail(
                hwnd,
                hBitmap,
                DisplayFrame));

        /// <summary>
        /// Sets the specified peek (live preview) bitmap for the specified
        /// window.  This is typically done in response to a DWM message.
        /// </summary>
        /// <param name="hwnd">The window handle.</param>
        /// <param name="bitmap">The thumbnail bitmap.</param>
        /// <param name="displayFrame">Whether to display a standard window
        /// frame around the bitmap.</param>
        public static void SetPeekBitmap(IntPtr hwnd, IntPtr bitmap, bool displayFrame) => Marshal.ThrowExceptionForHR(DwmSetIconicLivePreviewBitmap(
                hwnd,
                bitmap,
                IntPtr.Zero,
                displayFrame ? DisplayFrame : (uint)0));

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
                Marshal.ThrowExceptionForHR(DwmSetWindowAttribute(hwnd, HasIconicBitmap, t, 4));

                Marshal.ThrowExceptionForHR(DwmSetWindowAttribute(hwnd, ForceIconicRepresentation, t, 4));
            }
            finally
            {
                Marshal.FreeHGlobal(t);
            }
        }
    }

    public struct ChangeFilterStruct
    {
        public uint cbSize;
        public MessageResultInfo ExtStatus;
    }

    /// <summary>
    /// The action to be performed by the <see cref="TabbedThumbnailNativeMethods.ChangeWindowMessageFilterEx(IntPtr, WindowMessage, MessageFilterAction, ref ChangeFilterStruct)"/>.
    /// </summary>
    public enum MessageFilterAction : uint

    {

        /// <summary>
        /// Resets the window message filter for hWnd to the default. Any message allowed globally or process-wide will get through, but any message not included in those two categories, and which comes from a lower privileged process, will be blocked.
        /// </summary>
        Reset,

        /// <summary>
        /// Allows the message through the filter. This enables the message to be received by hWnd, regardless of the source of the message, even it comes from a lower privileged process.
        /// </summary>
        Allow,

        /// <summary>
        /// Blocks the message to be delivered to hWnd if it comes from a lower privileged process, unless the message is allowed process-wide by using the ChangeWindowMessageFilter function or globally.
        /// </summary>
        Disallow

    }

    /// <summary>
    /// Result info for the <see cref="TabbedThumbnailNativeMethods.ChangeWindowMessageFilterEx(IntPtr, ushort, MessageFilterAction, ref ChangeFilterStruct)"/>.
    /// </summary>
    public enum MessageResultInfo : uint

    {

        /// <summary>
        /// See the Remarks section of the <see cref="ChangeFilterStruct"/> structure. Applies to <see cref="MessageFilterAction.Allow"/> and <see cref="MessageFilterAction.Disallow"/>.
        /// </summary>
        None,

        /// <summary>
        /// The message has already been allowed by this window's message filter, and the function thus succeeded with no change to the window's message filter. Applies to <see cref="MessageFilterAction.Allow"/>.
        /// </summary>
        AlreadyAllowedForWindow,

        /// <summary>
        /// The message has already been blocked by this window's message filter, and the function thus succeeded with no change to the window's message filter. Applies to <see cref="MessageFilterAction.Disallow"/>.
        /// </summary>
        AlreadyDisallowedForWindow,

        /// <summary>
        /// The message is allowed at a scope higher than the window. Applies to <see cref="MessageFilterAction.Disallow"/>.
        /// </summary>
        AllowedHigher

    }

    public static class HandlerNativeMethods
    {

        [DllImport(User32)]
        public static extern IntPtr GetDC([In] IntPtr hWnd);

        [DllImport(User32)]
        public static extern IntPtr GetWindowDC(IntPtr hwnd);

        [DllImport(User32)]
        public static extern int ReleaseDC(IntPtr hwnd, IntPtr hdc);

        [DllImport(User32, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ChangeWindowMessageFilterEx(
    [In] IntPtr hwnd,                                         // Window
    [In] WindowMessage message,                                      // WM_ message
    [In] MessageFilterAction action,                                         // Message filter action value
    [In, Out] ref ChangeFilterStruct pChangeFilterStruct);    // Optional

        [DllImport(User32)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetWindowRect(IntPtr hwnd, [Out] out NativeRect rect);

        [DllImport(User32)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetClientRect(IntPtr hwnd, [Out] out NativeRect rect);

        public static bool GetClientSize(IntPtr hwnd, out System.Drawing.Size size)
        {
            if (GetClientRect(hwnd, out NativeRect rect))
            {
                size = new System.Drawing.Size(rect.Right, rect.Bottom);
                return true;
            }
            size = new System.Drawing.Size(-1, -1);
            return false;
        }

        [DllImport(User32)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ClientToScreen(
            IntPtr hwnd,
            ref NativePoint point);

        [DllImport(User32)]
        public static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        [DllImport(User32)]
        public static extern IntPtr GetFocus();

        //[DllImport(User32)]
        //public static extern uint GetWindowLong(IntPtr hwnd, GetWindowLong index);

        [DllImport(User32, EntryPoint = "GetWindowLong")]
        private static extern int GetWindowLongPtr32(IntPtr hWnd, GetWindowLongEnum nIndex);

        [DllImport(User32, EntryPoint = "GetWindowLongPtr")]
        private static extern int GetWindowLongPtr64(IntPtr hWnd, GetWindowLongEnum nIndex);

        // This static method is required because Win32 does not support
        // GetWindowLongPtr directly
        public static int GetWindowLongPtr(IntPtr hWnd, GetWindowLongEnum nIndex) => IntPtr.Size == 8 ? GetWindowLongPtr64(hWnd, nIndex) : GetWindowLongPtr32(hWnd, nIndex);

        //[DllImport(User32)]
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

        [DllImport(User32, EntryPoint = "SetWindowLong")]
        private static extern int SetWindowLong32(IntPtr hWnd, GetWindowLongEnum nIndex, uint dwNewLong);

        [DllImport(User32, EntryPoint = "SetWindowLongPtr")]
        private static extern int SetWindowLongPtr64(IntPtr hWnd, GetWindowLongEnum nIndex, uint dwNewLong);

        [DllImport(User32)]
        public static extern bool SetWindowPos(
            IntPtr hWnd,
            IntPtr hWndInsertAfter,
            int x,
            int y,
            int cx,
            int cy,
            SetWindowPositionOptions flags);

        [DllImport(User32, CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr GetForegroundWindow();

        [DllImport(User32, CharSet = CharSet.Auto, SetLastError = true)]
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
