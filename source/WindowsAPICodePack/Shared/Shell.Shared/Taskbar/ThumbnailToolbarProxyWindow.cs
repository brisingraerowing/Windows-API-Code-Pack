﻿//Copyright (c) Microsoft Corporation.  All rights reserved.  Distributed under the Microsoft Public License (MS-PL)

using Microsoft.WindowsAPICodePack.Shell.Resources;
using Microsoft.WindowsAPICodePack.Win32Native.Shell.DesktopWindowManager;

using System;
using System.Windows.Forms;

namespace Microsoft.WindowsAPICodePack.Taskbar
{
    internal class ThumbnailToolbarProxyWindow : NativeWindow, IDisposable
    {
        private ThumbnailToolBarButton[] _thumbnailButtons;
        private readonly IntPtr _internalWindowHandle;

        internal System.Windows.UIElement WindowsControl { get; set; }

        internal IntPtr WindowToTellTaskbarAbout => _internalWindowHandle != IntPtr.Zero ? _internalWindowHandle : Handle;

        internal TaskbarWindow TaskbarWindow { get; set; }

        internal ThumbnailToolbarProxyWindow(IntPtr windowHandle, ThumbnailToolBarButton[] buttons)
        {
            if (windowHandle == IntPtr.Zero)

                throw new ArgumentException(LocalizedMessages.CommonFileDialogInvalidHandle, nameof(windowHandle));

            if (buttons != null && buttons.Length == 0)

                throw new ArgumentException(LocalizedMessages.ThumbnailToolbarManagerNullEmptyArray, nameof(buttons));

            _internalWindowHandle = windowHandle;
            _thumbnailButtons = buttons;

            // Set the window handle on the buttons (for future updates)
            Array.ForEach(_thumbnailButtons, new Action<ThumbnailToolBarButton>(UpdateHandle));

            // Assign the window handle (coming from the user) to this native window
            // so we can intercept the window messages sent from the taskbar to this window.
            AssignHandle(windowHandle);
        }

        internal ThumbnailToolbarProxyWindow(System.Windows.UIElement windowsControl, ThumbnailToolBarButton[] buttons)
        {
            if (buttons != null && buttons.Length == 0)

                throw new ArgumentException(LocalizedMessages.ThumbnailToolbarManagerNullEmptyArray, nameof(buttons));

            WindowsControl = windowsControl ?? throw new ArgumentNullException(nameof(windowsControl));
            _internalWindowHandle = IntPtr.Zero;
            _thumbnailButtons = buttons;

            // Set the window handle on the buttons (for future updates)
            Array.ForEach(_thumbnailButtons, new Action<ThumbnailToolBarButton>(UpdateHandle));
        }

        private void UpdateHandle(ThumbnailToolBarButton button)
        {
            button.WindowHandle = _internalWindowHandle;
            button.AddedToTaskbar = false;
        }

        protected override void WndProc(ref Message m)
        {
            bool handled = TaskbarWindowManager.DispatchMessage(ref m, TaskbarWindow);

            // If it's a WM_Destroy message, then also forward it to the base class (our native window)
            if (((m.Msg == (int)WindowMessage.Destroy) ||
               (m.Msg == (int)WindowMessage.NCDestroy) ||
               ((m.Msg == (int)WindowMessage.SystemCommand) && (((int)m.WParam) == (int)SystemMenuCommands.Close))) ^ !handled)

                base.WndProc(ref m);
        }

        #region IDisposable Members
        ~ThumbnailToolbarProxyWindow() => Dispose(false);

        /// <summary>
        /// Release the native objects.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        public void Dispose(bool disposing)
        {
            if (disposing)

                // Dispose managed resources

                // Don't dispose the thumbnail buttons
                // as they might be used in another window.
                // Setting them to null will indicate we don't need use anymore.
                _thumbnailButtons = null;
        }
        #endregion
    }
}
