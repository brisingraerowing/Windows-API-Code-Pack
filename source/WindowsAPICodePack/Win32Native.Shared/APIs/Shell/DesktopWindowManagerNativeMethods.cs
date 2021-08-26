//Copyright (c) Microsoft Corporation.  All rights reserved.  Distributed under the Microsoft Public License (MS-PL)

using System;
using System.Runtime.InteropServices;
using System.Windows.Interop;

using static Microsoft.WindowsAPICodePack.NativeAPI.Consts.Shell.DesktopWindowManager;
using static Microsoft.WindowsAPICodePack.NativeAPI.Consts.DllNames;

using static System.Runtime.InteropServices.Marshal;

namespace Microsoft.WindowsAPICodePack.Win32Native.Shell.DesktopWindowManager
{
    [Flags]
    public enum MenuFlags : uint
    {
        Insert = 0x00000000,
        Change = 0x00000080,
        Append = 0x00000100,
        Delete = 0x00000200,
        Remove = 0x00001000,

        ByCommand = 0x00000000,
        ByPosition = 0x00000400,

        Separator = 0x00000800,

        Enabled = 0x00000000,
        Grayed = 0x00000001,
        Disabled = 0x00000002,

        Unchecked = 0x00000000,
        Checked = 0x00000008,
        UseCheckBitmaps = 0x00000200,

        String = 0x00000000,
        Bitmap = 0x00000004,
        OwnerDraw = 0x00000100,

        Popup = 0x00000010,
        MenuBarBreak = 0x00000020,
        MenuBreak = 0x00000040,

        Unhilite = 0x00000000,
        Hilite = 0x00000080,

        Default = 0x00001000,

        SystemMenu = 0x00002000,
        Help = 0x00004000,

        RightJustify = 0x00004000,



        MouseSelect = 0x00008000,

        End = 0x00000080,  /* Obsolete -- only used by old RES files */



        RadioCheck = 0x00000200,
        RightOrder = 0x00002000,

        /* Menu flags for Add/Check/EnableMenuItem() */
        MFS_Grayed = 0x00000003,
        MFS_Disabled = MFS_Grayed,
    }

    [Flags]
    public enum SystemMenuCommands : uint
    {
        Size = 0xF000,
        Move = 0xF010,
        Minimize = 0xF020,
        Maximize = 0xF030,
        NextWindow = 0xF040,
        PrevWindow = 0xF050,
        Close = 0xF060,
        VScroll = 0xF070,
        HScroll = 0xF080,
        MouseMenu = 0xF090,
        KeyMenu = 0xF100,
        Arrange = 0xF110,
        Restore = 0xF120,
        TaskList = 0xF130,
        ScreenSave = 0xF140,
        HotKey = 0xF150,
        Default = 0xF160,
        MonitorPower = 0xF170,
        ContextHelp = 0xF180,
        Separator = 0xF00F,

        IsSecure = 0x00000001,

        // Obsolete names
        Icon = Minimize,
        Zoom = Maximize
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
    public static class DesktopWindowManager
    {
        [Obsolete("Use the methods in Menus class instead."),
        DllImport(User32)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool EnableMenuItem([In] IntPtr hMenu, [In, MarshalAs(UnmanagedType.U4)] SystemMenuCommands uIDEnableItem, [In, MarshalAs(UnmanagedType.U4)] MenuFlags uEnable);

        [DllImport(User32)]
        public static extern IntPtr GetSystemMenu([In] IntPtr hWnd, [In, MarshalAs(UnmanagedType.Bool)] bool bRevert);

        public static IntPtr GetSystemMenu(in System.Windows.Forms.Form form, in bool bRevert) => GetSystemMenu(form.Handle, bRevert);

        public static IntPtr GetSystemMenu(in System.Windows.Window window, in bool bRevert) => GetSystemMenu(new WindowInteropHelper(window).Handle, bRevert);

        public static int GetSystemCommandWParam(in IntPtr wParam) => (int)wParam & 0xFFF0;

        [DllImport(DwmApi)]
        public static extern int DwmExtendFrameIntoClientArea(
            IntPtr hwnd,
            ref Margins m);

        [DllImport(DwmApi, PreserveSig = false)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool DwmIsCompositionEnabled();

        [DllImport(DwmApi)]
        public static extern int DwmEnableComposition(
            CompositionEnable compositionAction);

        [DllImport(DwmApi)]
        public static extern int DwmSetIconicThumbnail(
            IntPtr hwnd, IntPtr hbitmap, uint flags);

        [DllImport(DwmApi)]
        public static extern int DwmInvalidateIconicBitmaps(IntPtr hwnd);

        [DllImport(DwmApi)]
        public static extern int DwmSetIconicLivePreviewBitmap(
            IntPtr hwnd,
            IntPtr hbitmap,
            ref NativePoint ptClient,
            uint flags);

        [DllImport(DwmApi)]
        public static extern int DwmSetIconicLivePreviewBitmap(
            IntPtr hwnd, IntPtr hbitmap, IntPtr ptClient, uint flags);

        [DllImport(DwmApi, PreserveSig = true)]
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
                Exception e = GetExceptionForHR(rc);

                if (!(e is ArgumentException))

                    throw e;

                // Ignore argument exception as it's not really recommended to be throwing
                // exception when rendering the peek bitmap. If it's some other kind of exception,
                // then throw it.
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
            IntPtr t = AllocHGlobal(4);
            WriteInt32(t, enable ? 1 : 0);

            try
            {
                ThrowExceptionForHR(DwmSetWindowAttribute(hwnd, HasIconicBitmap, t, 4));

                ThrowExceptionForHR(DwmSetWindowAttribute(hwnd, ForceIconicRepresentation, t, 4));
            }
            finally
            {
                FreeHGlobal(t);
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
            [In] WindowMessage message,                               // WM_ message
            [In] MessageFilterAction action,                          // Message filter action value
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
        /// <summary>
        /// Retrieves information about the specified window. The function also retrieves the value at a specified offset into the extra window memory.
        /// </summary>
        /// <param name="hWnd">A handle to the window and, indirectly, the class to which the window belongs.</param>
        /// <param name="nIndex">The zero-based offset to the value to be retrieved. Valid values are in the range zero through the number of bytes of extra window memory, minus the size of a LONG_PTR. To retrieve any other value, specify one of the values of the <see cref="GetWindowLongEnum"/> enum.</param>
        /// <returns>
        /// <para>If the function succeeds, the return value is the requested value.</para>
        /// <para>If the function fails, the return value is zero. To get extended error information, call <see cref="GetLastWin32Error"/>.</para>
        /// <para>If <see cref="SetWindowLong32(IntPtr, GetWindowLongEnum, long)"/>, <see cref="SetWindowLongPtr(IntPtr, GetWindowLongEnum, long)"/> or <see cref="SetWindowLongPtr64(IntPtr, GetWindowLongEnum, long)"/> has not been called previously, <see cref="GetWindowLongPtr(IntPtr, GetWindowLongEnum)"/> returns zero for values in the extra window or class memory.</para>
        /// </returns>
        public static
#if WAPICP3
            long
#else
int
#endif
            GetWindowLongPtr(IntPtr hWnd, GetWindowLongEnum nIndex) => IntPtr.Size == 8 ? GetWindowLongPtr64(hWnd, nIndex) : GetWindowLongPtr32(hWnd, nIndex);

        //[DllImport(User32)]
        //public static extern int SetWindowLong(IntPtr hwnd, GetWindowLong index, uint newStyle);

        /// <summary>
        /// <para>Changes an attribute of the specified window. The function also sets a value at the specified offset in the extra window memory.</para>
        /// <para>This helper static method is required because the 32-bit version of user32.dll does not contain this API
        /// (on any versions of Windows), so linking the method will fail at run-time. The bridge dispatches the request
        /// to the correct function (<see cref="GetWindowLongPtr32(IntPtr, GetWindowLongEnum)"/> in 32-bit mode and <see cref="GetWindowLongPtr64(IntPtr, GetWindowLongEnum)"/> in 64-bit mode).</para>
        /// </summary>
        /// <param name="hWnd"><para>A handle to the window and, indirectly, the class to which the window belongs. The <see cref="SetWindowLongPtr(IntPtr, GetWindowLongEnum, long)"/> function fails if the process that owns the window specified by the hWnd parameter is at a higher process privilege in the UIPI hierarchy than the process the calling thread resides in.</para>
        /// <para>Windows XP/2000: The <see cref="SetWindowLongPtr(IntPtr, GetWindowLongEnum, long)"/> function fails if the window specified by the hWnd parameter does not belong to the same process as the calling thread.</para></param>
        /// <param name="nIndex">The zero-based offset to the value to be set. Valid values are in the range zero through the number of bytes of extra window memory, minus the size of a LONG_PTR. To set any other value, specify one of the values of the <see cref="GetWindowLongEnum"/>.</param>
        /// <param name="dwNewLong">The replacement value.</param>
        /// <returns><para>If the function succeeds, the return value is the previous value of the specified offset.</para>
        /// <para>If the function fails, the return value is zero. To get extended error information, call <see cref="GetLastWin32Error"/>.</para>
        /// <para>If the previous value is zero and the function succeeds, the return value is zero, but the function does not clear the last error information. To determine success or failure, clear the last error information by calling SetLastError with 0, then call <see cref="SetWindowLongPtr(IntPtr, GetWindowLongEnum, long)"/>.Function failure will be indicated by a return value of zero and a <see cref="GetLastWin32Error"/> result that is nonzero.</para></returns>
        public static int SetWindowLongPtr(IntPtr hWnd, GetWindowLongEnum nIndex,
#if WAPICP3
            long
#else
int
#endif
            dwNewLong) => IntPtr.Size == 8
                    ? SetWindowLongPtr64(hWnd, nIndex, dwNewLong)
                    : SetWindowLong32(hWnd, nIndex, dwNewLong);

        [DllImport(User32, EntryPoint = "SetWindowLong")]
        private static extern int SetWindowLong32(IntPtr hWnd, GetWindowLongEnum nIndex,
#if WAPICP3
            long
#else
int
#endif
            dwNewLong);

        [DllImport(User32, EntryPoint = "SetWindowLongPtr")]
        private static extern int SetWindowLongPtr64(IntPtr hWnd, GetWindowLongEnum nIndex,
#if WAPICP3
            long
#else
int
#endif
            dwNewLong);

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
		Size = 0xF000,
		Move = 0xF010,
		Minimize = 0xF020,
		Maximize = 0xF030,
		NextWindow = 0xF040,
		PrevWindow = 0xF050,
		Close = 0xF060,
		VerticalScroll = 0xF070,
		HorizontalScroll = 0xF080,
		MouseMenu = 0xF090,
		KeyMenu = 0xF100,
		Arrange = 0xF110,
		Restore = 0xF120,
		TaskList = 0xF130,
		ScreenSave = 0xF140,
		HotKey = 0xF150,
		Default = 0xF160
		MonitorPower = 0xF170
		ContextHelp = 0xF180
		Separator = 0xF00F
    }
}
