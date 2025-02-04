﻿using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

using static Microsoft.WindowsAPICodePack.NativeAPI.Consts.DllNames;

namespace Microsoft.WindowsAPICodePack.Win32Native.Shell
{
    public static class ShellObjectWatcherNativeMethods
    {
        [DllImport(Ole32)]
        public static extern HResult CreateBindCtx(
            int reserved, // must be 0
            [Out] out IBindCtx bindCtx);

        [DllImport(User32, CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern uint RegisterClassEx(
            ref WindowClassEx windowClass
            );

        [DllImport(User32, CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern IntPtr CreateWindowEx(
            int extendedStyle,
            [MarshalAs(UnmanagedType.LPWStr)]
            string className, //string className, //optional
            [MarshalAs(UnmanagedType.LPWStr)]
            string windowName, //window name
            int style,
            int x,
            int y,
            int width,
            int height,
            IntPtr parentHandle,
            IntPtr menuHandle,
            IntPtr instanceHandle,
            IntPtr additionalData);

        public static IntPtr CreateMessageOnlyWindow(in string messageWindowClassName, in string messageListenerWindowTitle) => CreateWindowEx(
                0, //extended style
                messageWindowClassName, //class name
                messageListenerWindowTitle, //title
                0, //style
                0, 0, 0, 0, // x,y,width,height
                new IntPtr(-3), // -3 = Message-Only window
                IntPtr.Zero, IntPtr.Zero, IntPtr.Zero);

        [DllImport(User32)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetMessage(
            [Out] out Message message,
            IntPtr windowHandle,
            uint filterMinMessage,
            uint filterMaxMessage);

        [DllImport(User32)]
        public static extern int DefWindowProc(
            IntPtr hwnd,
            uint msg,
            IntPtr wparam,
            IntPtr lparam);

        [DllImport(User32)]
        public static extern void DispatchMessage([In] ref Message message);

        public delegate int WndProcDelegate(IntPtr hwnd, uint msg, IntPtr wparam, IntPtr lparam);
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct WindowClassEx
    {
        public uint Size;
        public uint Style;
        
        public ShellObjectWatcherNativeMethods.WndProcDelegate WndProc;
        
        public int ExtraClassBytes;
        public int ExtraWindowBytes;
        public IntPtr InstanceHandle;
        public IntPtr IconHandle;
        public IntPtr CursorHandle;
        public IntPtr BackgroundBrushHandle;
        
        public string MenuName;
        public string ClassName;
        
        public IntPtr SmallIconHandle;
    }

    /// <summary>
    /// Wraps the native Windows MSG structure.
    /// </summary>
    public struct Message
    {
        private NativePoint point;

        /// <summary>
        /// Gets the window handle
        /// </summary>
        public IntPtr WindowHandle { get; }

        /// <summary>
        /// Gets the window message
        /// </summary>
        public uint Msg { get; }

        /// <summary>
        /// Gets the WParam
        /// </summary>
        public IntPtr WParam { get; }

        /// <summary>
        /// Gets the LParam
        /// </summary>
        public IntPtr LParam { get; }

        /// <summary>
        /// Gets the time
        /// </summary>
        public int Time { get; }

        /// <summary>
        /// Gets the point
        /// </summary>
        public NativePoint Point => point;

        /// <summary>
        /// Creates a new instance of the Message struct
        /// </summary>
        /// <param name="windowHandle">Window handle</param>
        /// <param name="msg">Message</param>
        /// <param name="wparam">WParam</param>
        /// <param name="lparam">LParam</param>
        /// <param name="time">Time</param>
        /// <param name="point">Point</param>
        public Message(IntPtr windowHandle, uint msg, IntPtr wparam, IntPtr lparam, int time, NativePoint point)
            : this()
        {
            WindowHandle = windowHandle;
            Msg = msg;
            WParam = wparam;
            LParam = lparam;
            Time = time;
            this.point = point;
        }

        /// <summary>
        /// Determines if two messages are equal.
        /// </summary>
        /// <param name="first">First message</param>
        /// <param name="second">Second message</param>
        /// <returns>True if first and second message are equal; false otherwise.</returns>
        public static bool operator ==(Message first, Message second) => first.WindowHandle == second.WindowHandle
                && first.Msg == second.Msg
                && first.WParam == second.WParam
                && first.LParam == second.LParam
                && first.Time == second.Time
                && first.Point == second.Point;

        /// <summary>
        /// Determines if two messages are not equal.
        /// </summary>
        /// <param name="first">First message</param>
        /// <param name="second">Second message</param>
        /// <returns>True if first and second message are not equal; false otherwise.</returns>
        public static bool operator !=(Message first, Message second) => !(first == second);

        /// <summary>
        /// Determines if this message is equal to another.
        /// </summary>
        /// <param name="obj">Another message</param>
        /// <returns>True if this message is equal argument; false otherwise.</returns>
        public override bool Equals(object obj) => (obj != null && obj is Message) ? this == (Message)obj : false;

        /// <summary>
        /// Gets a hash code for the message.
        /// </summary>
        /// <returns>Hash code for this message.</returns>
        public override int GetHashCode()
        {
            int hash = WindowHandle.GetHashCode();
            hash = (hash * 31) + Msg.GetHashCode();
            hash = (hash * 31) + WParam.GetHashCode();
            hash = (hash * 31) + LParam.GetHashCode();
            hash = (hash * 31) + Time.GetHashCode();
            hash = (hash * 31) + Point.GetHashCode();
            return hash;
        }
    }

}
