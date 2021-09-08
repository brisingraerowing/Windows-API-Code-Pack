#if (!NETSTANDARD || NETSTANDARD2_1_OR_GREATER) && WAPICP3
using Microsoft.WindowsAPICodePack.COMNative.Shell;
using Microsoft.WindowsAPICodePack.Win32Native;
using Microsoft.WindowsAPICodePack.Win32Native.Menus;

using System;
using System.Runtime.InteropServices;

using static Microsoft.WindowsAPICodePack.Win32Native.CoreHelpers;

using static WinCopies.
#if !WAPICP3
    Util.Util;

using static WinCopies.Util.
#endif
    ThrowHelper;

namespace Microsoft.WindowsAPICodePack.Shell
{
    public struct HookRegistration
    {
        public Action<HwndSourceHook> AddHook
        {
            get;
#if CS9
            init;
#endif
        }

        public Action<HwndSourceHook> RemoveHook
        {
            get;
#if CS9
            init;
#endif
        }

        public HookRegistration(in Action<HwndSourceHook> addHook, in Action<HwndSourceHook> removeHook)
        {
            AddHook = addHook;

            RemoveHook = removeHook;
        }

        public bool Validate() => AddHook != null && RemoveHook != null;
    }

    public class ShellContextMenu : WinCopies.
#if !WAPICP3
        Util.
#endif
        DotNetFix.IDisposable
    {
        private IContextMenu _contextMenu;
        private IContextMenu2 _contextMenu2;
        private IContextMenu3 _contextMenu3;
        private ShellContainer _folder;
        private HookRegistration _hookRegistration;
        private uint _first;
        private uint _last;
        private IntPtr _menu;

        public bool IsDisposed => _folder == null;

        public ShellContextMenu(in ShellContainer folder, in HookRegistration hookRegistration, in
#if CS6
            System.
#else
            WinCopies.
#endif
            Collections.Generic.IReadOnlyList<ShellObject> items)
        {
            _folder = folder ?? throw GetArgumentNullException(nameof(folder));

            if (!hookRegistration.Validate())

                throw new ArgumentException("Hook registration validation failed. One or more delegate is null.");

            ThrowIfNull(items, nameof(items));

            _hookRegistration = hookRegistration;

            var ptrs = new IntPtr[items.Count];

            for (int i = 0; i < items.Count; i++)

                ptrs[i] = COMNative.Shell.Shell.GetPidl(items[i].ParsingName);

            var guid = new Guid(NativeAPI.Guids.Shell.IContextMenu);

            HResult hr = folder.NativeShellFolder.GetUIObjectOf(IntPtr.Zero, (uint)items.Count, ptrs, ref guid, IntPtr.Zero, out IntPtr intPtr);

            _contextMenu = GetTypedObjectForIUnknown<IContextMenu>(intPtr);

            _contextMenu2 = QueryInterfaceForIUnknown<IContextMenu2>(intPtr, NativeAPI.Guids.Shell.IContextMenu2);

            _contextMenu3 = QueryInterfaceForIUnknown<IContextMenu3>(intPtr, NativeAPI.Guids.Shell.IContextMenu3);

            intPtr = IntPtr.Zero;
        }

#if CS6
        public ShellContextMenu(in ShellContainer folder, in HookRegistration hookRegistration, params ShellObject[] items) : this(folder ?? throw GetArgumentNullException(nameof(folder)), hookRegistration, (System.Collections.Generic.IReadOnlyList<ShellObject>)(items ?? throw GetArgumentNullException(nameof(items)))) { }
#endif

        protected virtual IntPtr OnSourceHook(WindowMessage msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            if (_contextMenu2 != null &&
                (msg == WindowMessage.InitializeMenuPopup ||
                 msg == WindowMessage.MeasureItem ||
                 msg == WindowMessage.DrawItem))
            {
                if (_contextMenu2.HandleMenuMsg((uint)msg, wParam, lParam) == HResult.Ok)

                    handled = true;
            }

            if (_contextMenu3 != null &&
                msg == WindowMessage.MenuChar)
            {
                if (_contextMenu3.HandleMenuMsg2((uint)msg, wParam, lParam, IntPtr.Zero) == HResult.Ok)

                    handled = true;
            }

            return IntPtr.Zero;
        }

        public IntPtr Query(in uint first, in uint last, in ContextMenuFlags flags)
        {
            ThrowIfDisposed(this);

            if (_menu == IntPtr.Zero)
            {
                if (first == 0)

                    throw new ArgumentOutOfRangeException(nameof(first), first, $"{nameof(first)} cannot be equal to zero.");

                if (last < first)

                    throw new ArgumentException($"{nameof(first)} must be less than {nameof(last)}.");

                _first = first;

                _last = last;

                _menu = Menus.CreatePopupMenu();

                CoreErrorHelper.ThrowExceptionForHR(_contextMenu.QueryContextMenu(_menu, 0, first, last, flags));
            }

            return _menu;
        }

        public void Show(in IntPtr hwnd, in System.Drawing.Point point)
        {
            ThrowIfDisposed(this);

            if (_menu == IntPtr.Zero)

                throw new InvalidOperationException($"The current context menu is not initialized. You need to call the {nameof(Query)} method before calling the {nameof(Show)} method.");

            _hookRegistration.AddHook(OnSourceHook);

            uint selected = Menus.TrackPopupMenuEx(_menu, TrackPopupMenuFlags.ReturnCommand, point, hwnd, null);

            if (selected >= _first)
            {
                selected -= _first;

                var ci = new ContextMenuInvokeCommandInfo
                {
                    cbSize = (uint)Marshal.SizeOf
#if CS7
                    <
#else
                    (typeof(
#endif
                        ContextMenuInvokeCommandInfo
#if CS7
                        >(
#else
                        )
#endif
                    ),

                    lpVerb = (IntPtr)selected,
                    lpVerbW = (IntPtr)selected,

                    lpDirectory = _folder.ParsingName,
                    lpDirectoryW = _folder.ParsingName,

                    fMask = ContextMenuInvokeCommandFlags.Unicode | ContextMenuInvokeCommandFlags.PtInvoke,

                    ptInvoke = point,

                    nShow = ShowWindowCommands.ShowNormal
                };

                _ = _contextMenu.InvokeCommand(ci);
            }

            _hookRegistration.RemoveHook(OnSourceHook);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (IsDisposed)

                return;

            if (disposing)
            {
                _folder = null;

                _hookRegistration = default;
            }

            _menu = IntPtr.Zero;

            DisposeCOMObject(ref _contextMenu);
            DisposeCOMObject(ref _contextMenu2);
            DisposeCOMObject(ref _contextMenu3);
        }

        ~ShellContextMenu() => Dispose(false);

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }
    }
}
#endif
