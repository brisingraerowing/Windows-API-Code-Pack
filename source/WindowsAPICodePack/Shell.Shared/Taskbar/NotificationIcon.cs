using Microsoft.WindowsAPICodePack.Win32Native;
using Microsoft.WindowsAPICodePack.Win32Native.Shell;

using System;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interop;

using static Microsoft.WindowsAPICodePack.Win32Native.Shell.Shell;

using static WinCopies.
#if WAPICP3
    ThrowHelper;
#else
    Util.Util;
#endif

namespace Microsoft.WindowsAPICodePack.Taskbar
{
    public class NotificationIcon : WinCopies.DotNetFix.IDisposable
    {
        public Window Window { get; private set; }

        public WindowInteropHelper WindowInteropHelper { get; private set; }

        public Guid Guid { get; private set; }

        public Icon Icon { get; private set; }

        public ContextMenu ContextMenu { get; private set; }

        public string ToolTip { get; private set; }

        public bool Initialized { get; private set; }

        public bool DisposeIcon { get; }

        public bool IsDisposed => Window == null;

        public event EventHandler LeftButtonUp;
        public event EventHandler LeftButtonDown;
        public event EventHandler RightButtonUp;
        public event EventHandler RightButtonDown;

        const WindowMessage WMAPP_NOTIFYCALLBACK = (WindowMessage)((uint)WindowMessage.App + 1u);

        public NotificationIcon([DisallowNull] in Window window, in Guid guid, [DisallowNull] in Icon icon, [AllowNull] in string? toolTip, [AllowNull] in ContextMenu? contextMenu, in bool disposeIcon)
        {
            Window = window ?? throw GetArgumentNullException(nameof(window));

            Icon = icon ?? throw GetArgumentNullException(nameof(icon));

            WindowInteropHelper = new WindowInteropHelper(window);

            ToolTip = toolTip;

            ContextMenu = contextMenu;

            Guid = guid;

            DisposeIcon = disposeIcon;
        }

        public NotificationIcon(in Window window, in string guid, in Icon icon, in string? toolTip, in ContextMenu? contextMenu, in bool disposeIcon) : this(window, new Guid(guid), icon, toolTip, contextMenu, disposeIcon)
        {
            // Left empty.
        }

        protected virtual NotifyIconData GetNotifyIconData() => new() { cbSize = (uint)Marshal.SizeOf<NotifyIconData>(), hWnd = new WindowInteropHelper(Window).Handle };

        protected virtual bool AddNotificationIcon()
        {
            NotifyIconData nid = GetNotifyIconData();

            nid.uFlags = NotifyIconFlags.Icon | NotifyIconFlags.Tip | NotifyIconFlags.Message | NotifyIconFlags.ShowTip | NotifyIconFlags.Guid;
            nid.guidItem = Guid;
            nid.uCallbackMessage = (uint)WMAPP_NOTIFYCALLBACK;
            nid.szTip = ToolTip;

            nid.hIcon = Icon.Handle;
            _ = Shell_NotifyIconW(NotifyIconModification.Add, ref nid);

            nid.uVersion = NotifyIconVersion.Version4;

            if (Shell_NotifyIconW(NotifyIconModification.SetVersion, ref nid))
            {
                HwndSource.FromHwnd(WindowInteropHelper.Handle).AddHook(WndProc);

                return Initialized = true;
            }

            return false;
        }

        public bool Initialize() => IsDisposed ? throw GetExceptionForDispose(false) : AddNotificationIcon();

        protected virtual void RaiseEvent(in EventHandler eventHandler) => eventHandler?.Invoke(this, EventArgs.Empty);

        protected virtual void OnLeftButtonUp() => RaiseEvent(LeftButtonUp);

        protected virtual void OnLeftButtonDown() => RaiseEvent(LeftButtonDown);

        protected virtual void OnRightButtonUp() => RaiseEvent(RightButtonUp);

        protected virtual void OnRightButtonDown() => RaiseEvent(RightButtonDown);

        protected virtual void OnContextMenuOpening()
        {
            if (ContextMenu != null)

                if (ContextMenu.IsOpen)

                    ContextMenu.IsOpen = false;

                else
                {
                    _ = Core.SetForegroundWindow(WindowInteropHelper.Handle);

                    ContextMenu.IsOpen = true;
                }
        }

        protected virtual IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            switch ((WindowMessage)msg)
            {
                case WMAPP_NOTIFYCALLBACK:

                    int _lParam = InteropTools.LOWORD((int)lParam);

                    var windowMessage = (WindowMessage)_lParam;

                    switch (windowMessage)
                    {
                        case WindowMessage.LeftButtonUp:

                            OnLeftButtonUp();

                            break;

                        case WindowMessage.ContextMenu:

                            OnContextMenuOpening();

                            break;

                        case WindowMessage.LeftButtonDown:

                            OnLeftButtonDown();

                            break;

                        case WindowMessage.RightButtonUp:

                            OnRightButtonUp();

                            break;

                        case WindowMessage.RightButtonDown:

                            OnRightButtonDown();

                            break;
                    }

                    break;
            }

            return IntPtr.Zero;
        }

        public bool AddNotification(string text, string title)
        {
            NotifyIconData nid = GetNotifyIconData();

            nid.uFlags = NotifyIconFlags.Info | NotifyIconFlags.Guid;

            nid.guidItem = Guid;

            nid.dwInfoFlags = NotifyIconInfos.Info | NotifyIconInfos.RespectQuietTime;

            nid.szInfoTitle = title;

            nid.szInfo = text;

            return Shell_NotifyIconW(NotifyIconModification.Modify, ref nid);
        }

        protected virtual void Dispose(in bool disposing)
        {
            if (Initialized)
            {
                NotifyIconData nid = GetNotifyIconData();

                nid.uFlags = NotifyIconFlags.Guid;
                nid.guidItem = Guid;

                _ = Shell_NotifyIconW(NotifyIconModification.Delete, ref nid);
            }

            Window = null;

            WindowInteropHelper = null;

            if (DisposeIcon)

                Icon.Dispose();

            Icon = null;

            ToolTip = null;

            Guid = default;
        }

        public void Dispose()
        {
            if (IsDisposed)

                return;

            Dispose(true);

            GC.SuppressFinalize(this);
        }

        ~NotificationIcon() => Dispose(false);
    }
}
