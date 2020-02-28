//Copyright (c) Microsoft Corporation.  All rights reserved.

using System;
using System.Runtime.InteropServices;
using Microsoft.WindowsAPICodePack.Win32Native.Shell;

namespace Microsoft.WindowsAPICodePack.Win32Native.Taskbar
{
    public static class TabbedThumbnailNativeMethods
    {


        [DllImport("gdi32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool StretchBlt(
            IntPtr hDestDC, int destX, int destY, int destWidth, int destHeight,
            IntPtr hSrcDC, int srcX, int srcY, int srcWidth, int srcHeight,
            uint operation);

        [DllImport("user32.dll")]
        public static extern IntPtr GetWindowDC(IntPtr hwnd);

        [DllImport("user32.dll")]
        public static extern int ReleaseDC(IntPtr hwnd, IntPtr hdc);

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ChangeWindowMessageFilterEx(
    [In] IntPtr hwnd,                                         // Window
    [In] WindowMessage message,                                      // WM_ message
    [In] MessageFilterAction action,                                         // Message filter action value
    [In, Out] ref ChangeFilterStruct pChangeFilterStruct);    // Optional

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
}
