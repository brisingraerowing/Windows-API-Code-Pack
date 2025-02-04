﻿using Microsoft.WindowsAPICodePack.Shell.Resources;
using Microsoft.WindowsAPICodePack.Win32Native;
using Microsoft.WindowsAPICodePack.Win32Native.Shell;

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;

namespace Microsoft.WindowsAPICodePack.Shell
{
    internal class MessageListener : IDisposable
    {
        public const uint CreateWindowMessage = (uint)WindowMessage.User + 1;
        public const uint DestroyWindowMessage = (uint)WindowMessage.User + 2;
        public const uint BaseUserMessage = (uint)WindowMessage.User + 5;

        private const string MessageWindowClassName = "MessageListenerClass";
        private const string MessageListenerWindowTitle = "MessageListenerWindow";
        private static readonly object _threadlock = new object();
        private static uint _atom;
        private static Thread _windowThread = null;
        private static volatile bool _running = false;

        private static readonly ShellObjectWatcherNativeMethods.WndProcDelegate wndProc = WndProc;
        // Dictionary relating window's hwnd to its message window
        private static readonly Dictionary<IntPtr, MessageListener> _listeners = new Dictionary<IntPtr, MessageListener>();
        private static IntPtr _firstWindowHandle = IntPtr.Zero;

        private static readonly object _crossThreadWindowLock = new object();
        private static IntPtr _tempHandle = IntPtr.Zero;

        public IntPtr WindowHandle { get; private set; }
        public static bool Running => _running;

        public event EventHandler<WindowMessageEventArgs> MessageReceived;

        public MessageListener()
        {
            lock (_threadlock)
            {
                if (_windowThread == null)
                {
                    _windowThread = new Thread(ThreadMethod);
                    _windowThread.SetApartmentState(ApartmentState.STA);
                    _windowThread.Name = "ShellObjectWatcherMessageListenerHelperThread";

                    lock (_crossThreadWindowLock)
                    {
                        _windowThread.Start();
                        _ = Monitor.Wait(_crossThreadWindowLock);
                    }

                    _firstWindowHandle = WindowHandle;
                }

                else

                    CrossThreadCreateWindow();

                _listeners.Add(WindowHandle == IntPtr.Zero
                    ? throw new ShellException(LocalizedMessages.MessageListenerCannotCreateWindow,
                        Marshal.GetExceptionForHR(Marshal.GetHRForLastWin32Error()))
                    : WindowHandle, this);
            }
        }

        private void CrossThreadCreateWindow()
        {
            if (_firstWindowHandle == IntPtr.Zero)

                throw new InvalidOperationException(LocalizedMessages.MessageListenerNoWindowHandle);

            lock (_crossThreadWindowLock)
            {
                Core.PostMessage(_firstWindowHandle, (WindowMessage)CreateWindowMessage, IntPtr.Zero, IntPtr.Zero);
                _ = Monitor.Wait(_crossThreadWindowLock);
            }

            WindowHandle = _tempHandle;
        }

        private static void RegisterWindowClass()
        {
            var classEx = new WindowClassEx
            {
                ClassName = MessageWindowClassName,
                WndProc = wndProc,

                Size = (uint)Marshal.SizeOf(typeof(WindowClassEx))
            };

            uint atom = ShellObjectWatcherNativeMethods.RegisterClassEx(ref classEx);

            if (atom == 0)

                throw new ShellException(LocalizedMessages.MessageListenerClassNotRegistered,
                    Marshal.GetExceptionForHR(Marshal.GetHRForLastWin32Error()));

            _atom = atom;
        }

        private static IntPtr CreateWindow() => ShellObjectWatcherNativeMethods.CreateMessageOnlyWindow(
                MessageWindowClassName, //class name
                MessageListenerWindowTitle //title
                );

        private void ThreadMethod() // Message Loop
        {
            lock (_crossThreadWindowLock)
            {
                _running = true;

                if (_atom == 0)

                    RegisterWindowClass();

                WindowHandle = CreateWindow();

                Monitor.Pulse(_crossThreadWindowLock);
            }

            while (_running)

                if (ShellObjectWatcherNativeMethods.GetMessage(out Message msg, IntPtr.Zero, 0, 0))

                    ShellObjectWatcherNativeMethods.DispatchMessage(ref msg);
        }

        private static int WndProc(IntPtr hwnd, uint msg, IntPtr wparam, IntPtr lparam)
        {
            switch (msg)
            {
                case CreateWindowMessage:
                    lock (_crossThreadWindowLock)
                    {
                        _tempHandle = CreateWindow();
                        Monitor.Pulse(_crossThreadWindowLock);
                    }
                    break;

                case (uint)WindowMessage.Destroy:
                    lock (_crossThreadWindowLock)
                    {
                        _running = false;
                        _windowThread = null;
                        Monitor.Pulse(_crossThreadWindowLock);
                    }
                    break;

                default:
                    MessageListener listener;

                    if (_listeners.TryGetValue(hwnd, out listener))
                    {
                        var message = new Message(hwnd, msg, wparam, lparam, 0, new NativePoint());
                        listener.MessageReceived.SafeRaise(listener, new WindowMessageEventArgs(message));
                    }

                    break;
            }

            return ShellObjectWatcherNativeMethods.DefWindowProc(hwnd, msg, wparam, lparam);
        }

        #region IDisposable Members
        ~MessageListener() => Dispose(false);

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                lock (_threadlock)
                {
                    _ = _listeners.Remove(WindowHandle);

                    if (_listeners.Count == 0)

                        lock (_crossThreadWindowLock)
                        {
                            Core.PostMessage(WindowHandle, WindowMessage.Destroy, IntPtr.Zero, IntPtr.Zero);
                            _ = Monitor.Wait(_crossThreadWindowLock);
                        }
                }
            }
        }
        #endregion
    }

    /// <summary>
    /// Encapsulates the data about a window message 
    /// </summary>
    public class WindowMessageEventArgs : EventArgs
    {
        /// <summary>
        /// Received windows message.
        /// </summary>
        public Message Message { get; private set; }

        internal WindowMessageEventArgs(Message msg) => Message = msg;
    }
}
