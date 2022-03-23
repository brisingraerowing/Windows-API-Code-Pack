#if (!NETSTANDARD || NETSTANDARD2_1_OR_GREATER) && WAPICP3
using Microsoft.WindowsAPICodePack.COMNative.Shell;
using Microsoft.WindowsAPICodePack.Win32Native;
using Microsoft.WindowsAPICodePack.Win32Native.Menus;

using System;
using System.Drawing;
using System.Runtime.InteropServices;

using static Microsoft.WindowsAPICodePack.Win32Native.CoreHelpers;
using static Microsoft.WindowsAPICodePack.Win32Native.CoreErrorHelper;

using static WinCopies.
#if !WAPICP3
    Util.Util;

using static WinCopies.Util.
#endif
    ThrowHelper;
using System.Text;

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

            var guid = new Guid(NativeAPI.Guids.Shell.IContextMenu);

            ThrowExceptionForHResult(folder.NativeShellFolder.GetUIObjectOf(IntPtr.Zero, (uint)items.Count, ShellContainer.GetPIDLs(items), ref guid, IntPtr.Zero, out IntPtr intPtr));

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
            if ((_contextMenu2 != null &&
                (msg == WindowMessage.InitializeMenuPopup ||
                 msg == WindowMessage.MeasureItem ||
                 msg == WindowMessage.DrawItem) && _contextMenu2.HandleMenuMsg((uint)msg, wParam, lParam) == HResult.Ok) ||
                 (_contextMenu3 != null &&
                msg == WindowMessage.MenuChar && _contextMenu3.HandleMenuMsg2((uint)msg, wParam, lParam, IntPtr.Zero) == HResult.Ok))

                handled = true;

            return IntPtr.Zero;
        }

        public string
#if CS8
            ?
#endif
            GetCommandString(in uint selected, in GetCommandStringFlags flags)
        {
            var bytes = new byte[NativeAPI.Consts.Shell.MaxPath];

            ThrowExceptionForHResult(_contextMenu.GetCommandString(selected, flags, 0, bytes, NativeAPI.Consts.Shell.MaxPath));

            const int max = NativeAPI.Consts.Shell.MaxPath - 1;

            int i;

            for (i = 0; i < max && (bytes[i] != 0 || bytes[i + 1] != 0); i += 2) { /* Left empty. */ }

            return i < max ? Encoding.Unicode.GetString(bytes, 0, i) : null;
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

                ThrowExceptionForHResult(_contextMenu.QueryContextMenu(_menu = Menus.CreatePopupMenu(), 0, first, last, flags));
            }

            return _menu;
        }

        public ContextMenuInvokeCommandInfo GetInvokeCommandInfo(in IntPtr selected) => new
#if CS9
            ()
#else
            ContextMenuInvokeCommandInfo
#endif
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

            lpDirectory = _folder.ParsingName,
            lpDirectoryW = _folder.ParsingName,

            lpVerb = selected,
            lpVerbW = selected
        };

        public ContextMenuInvokeCommandInfo GetInvokeCommandInfo(in uint selected) => GetInvokeCommandInfo((IntPtr)selected);

        public ContextMenuInvokeCommandInfo GetDefaultInvokeCommandInfo(in IntPtr selected, in Point point)
        {
            ContextMenuInvokeCommandInfo ci = GetInvokeCommandInfo(selected);
            ci.fMask = ContextMenuInvokeCommandFlags.Unicode | ContextMenuInvokeCommandFlags.PtInvoke;
            ci.ptInvoke = point;
            ci.nShow = ShowWindowCommands.ShowNormal;

            return ci;
        }

        public ContextMenuInvokeCommandInfo GetDefaultInvokeCommandInfo(in uint selected, in Point point) => GetDefaultInvokeCommandInfo((IntPtr)selected, point);

        public void InvokeCommand(ref ContextMenuInvokeCommandInfo ci) => ThrowExceptionForHResult(_contextMenu.InvokeCommand(ref ci));

        public void Show(in IntPtr hwnd, in Point point)
        {
            ThrowIfDisposed(this);

            if (_menu == IntPtr.Zero)

                throw new InvalidOperationException($"The current context menu is not initialized. You need to call the {nameof(Query)} method before calling the {nameof(Show)} method.");

            _hookRegistration.AddHook(OnSourceHook);

            uint selected = Menus.TrackPopupMenuEx(_menu, TrackPopupMenuFlags.ReturnCommand, point, hwnd, null);

            if (selected >= _first)
            {
                selected -= _first;

                ContextMenuInvokeCommandInfo ci = GetDefaultInvokeCommandInfo(selected, point);

                InvokeCommand(ref ci);
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
