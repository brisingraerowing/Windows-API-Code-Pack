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
#if !WAPICP3
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
#endif

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
        private uint _first;
        private uint _last;
        private IntPtr _menu;
        private HookRegistration
#if WAPICP3
            ?
#endif
            _hookRegistration;

        public bool IsDisposed => _folder == null;

        public ShellContextMenu(in ShellContainer folder, in HookRegistration
#if WAPICP3
            ?
#endif
            hookRegistration, in
#if CS6
            System.
#else
            WinCopies.
#endif
            Collections.Generic.IReadOnlyList<ShellObject> items)
        {
            _folder = folder ?? throw GetArgumentNullException(nameof(folder));

            UpdateHookRegistration(hookRegistration);

            ThrowIfNull(items, nameof(items));

            var guid = new Guid(NativeAPI.Guids.Shell.IContextMenu);

            ThrowExceptionForHResult(folder.NativeShellFolder.GetUIObjectOf(IntPtr.Zero, (uint)items.Count, ShellContainer.GetPIDLs(items), ref guid, IntPtr.Zero, out IntPtr intPtr));

            _contextMenu = GetTypedObjectForIUnknown<IContextMenu>(intPtr);
            _contextMenu2 = QueryInterfaceForIUnknown<IContextMenu2>(intPtr, NativeAPI.Guids.Shell.IContextMenu2);
            _contextMenu3 = QueryInterfaceForIUnknown<IContextMenu3>(intPtr, NativeAPI.Guids.Shell.IContextMenu3);

            intPtr = IntPtr.Zero;
        }

#if CS6
        public ShellContextMenu(in ShellContainer folder, in HookRegistration
#if WAPICP3
            ?
#endif
            hookRegistration, params ShellObject[] items) : this(folder ?? throw GetArgumentNullException(nameof(folder)), hookRegistration, (System.Collections.Generic.IReadOnlyList<ShellObject>)(items ?? throw GetArgumentNullException(nameof(items)))) { }
#endif

        public void UpdateHookRegistration(in HookRegistration
#if WAPICP3
            ?
#endif
            hookRegistration) => _hookRegistration = hookRegistration.HasValue && !hookRegistration.Value.Validate() ? throw new ArgumentException("Hook registration validation failed. One or more delegate is null.") : hookRegistration;

        protected virtual IntPtr OnSourceHook(WindowMessage msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            bool parse()
            {
                if (_contextMenu2 != null)

                    switch (msg)
                    {
                        case WindowMessage.InitializeMenuPopup:
                        case WindowMessage.MeasureItem:
                        case WindowMessage.DrawItem:

                            if (_contextMenu2.HandleMenuMsg((uint)msg, wParam, lParam) == HResult.Ok)

                                return true;

                            break;
                    }

                return false;
            }

            if (parse() || (_contextMenu3 != null && msg == WindowMessage.MenuChar && _contextMenu3.HandleMenuMsg2((uint)msg, wParam, lParam, IntPtr.Zero) == HResult.Ok))

                handled = true;

            return IntPtr.Zero;
        }

        public HResult TryGetCommandString(in uint selected, in GetCommandStringFlags flags, in bool unicode, out string
#if CS8
            ?
#endif
            result)
        {
            var bytes = new byte[NativeAPI.Consts.Shell.MaxPath];

            HResult hr = _contextMenu.GetCommandString(selected, flags, 0, bytes, NativeAPI.Consts.Shell.MaxPath);

            if (Succeeded(hr))
            {
                int max = NativeAPI.Consts.Shell.MaxPath;
                sbyte step;

                int i = 0;
                Func<bool> func;
                bool check(in byte b) => b != 0;
                bool defaultFunc() => check(bytes[i]);
                Encoding encoding;

                if (unicode)
                {
                    max--;
                    func = () => defaultFunc() || check(bytes[i + 1]);
                    step = 2;
                    encoding = Encoding.Unicode;
                }

                else
                {
                    func = defaultFunc;
                    step = 1;
                    encoding = Encoding.Default;
                }

                for (; i < max && func(); i += step) { /* Left empty. */ }

                result = i < max ? encoding.GetString(bytes, 0, i) : null;
            }

            else

                result = null;

            return hr;
        }

        public string
#if CS8
            ?
#endif
            TryGetCommandString(in uint selected, in GetCommandStringFlags flags, in bool unicode)
        {
            _ = TryGetCommandString(selected, flags, unicode, out string
#if CS8
            ?
#endif
            result);

            return result;
        }

        public string
#if CS8
            ?
#endif
            GetCommandString(in uint selected, in GetCommandStringFlags flags, in bool unicode)
        {
            ThrowExceptionForHResult(TryGetCommandString(selected, flags, unicode, out string
#if CS8
            ?
#endif
            result));

            return result;
        }

        public IntPtr Query(in uint first, in uint last, in ContextMenuFlags flags)
        {
            ThrowIfDisposed(this);

            if (_menu == IntPtr.Zero)
            {
                _first = first == 0 ? throw new ArgumentOutOfRangeException(nameof(first), first, $"{nameof(first)} cannot be equal to zero.") : first;
                _last = last < first ? throw new ArgumentException($"{nameof(first)} must be less than or equal to {nameof(last)}.") : last;

                ThrowExceptionForHResult(_contextMenu.QueryContextMenu(_menu = Menus.CreatePopupMenu(), 0, first, last, flags));
            }

            return _menu;
        }

        public bool TrySetMenuDefaultItem(in uint uItem, in bool fByPos) => Menus.SetMenuDefaultItem(_menu, uItem, fByPos);

        public bool TrySetMenuItemInfo(in uint item, in bool byPosition, MenuItemInfo menuItemInfo) => Menus.SetMenuItemInfoW(_menu, item, byPosition, ref menuItemInfo);

        public bool TrySetMenuItemInfo(in uint item, MenuItemInfo menuItemInfo) => Menus.SetMenuItemInfo(_menu, item, ref menuItemInfo);

        public ContextMenuInvokeCommandInfo GetInvokeCommandInfo(in IntPtr selected, in IntPtr selectedW) => new
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
            lpVerbW = selectedW
        };

        public ContextMenuInvokeCommandInfo GetInvokeCommandInfo(in uint selected)
        {
            var ptr = (IntPtr)selected;

            return GetInvokeCommandInfo(ptr, ptr);
        }

        public ContextMenuInvokeCommandInfo GetInvokeCommandInfo(in string selected) => GetInvokeCommandInfo(Marshal.StringToHGlobalAnsi(selected), Marshal.StringToHGlobalUni(selected));

        public ContextMenuInvokeCommandInfo GetDefaultInvokeCommandInfo(in IntPtr selected, in IntPtr selectedW, in Point point, in bool ctrl = false, in bool shift = false)
        {
            ContextMenuInvokeCommandInfo ci = GetInvokeCommandInfo(selected, selectedW);
            ci.fMask = ContextMenuInvokeCommandFlags.Unicode | ContextMenuInvokeCommandFlags.PtInvoke;

            if (ctrl)

                ci.fMask |= ContextMenuInvokeCommandFlags.ControlDown;

            if (shift)

                ci.fMask |= ContextMenuInvokeCommandFlags.ShiftDown;

            ci.ptInvoke = point;
            ci.nShow = ShowWindowCommands.ShowNormal;

            return ci;
        }

        public ContextMenuInvokeCommandInfo GetDefaultInvokeCommandInfo(in uint selected, in Point point, in bool ctrl = false, in bool shift = false)
        {
            var ptr = (IntPtr)selected;

            return GetDefaultInvokeCommandInfo(ptr, ptr, point, ctrl, shift);
        }

        public ContextMenuInvokeCommandInfo GetDefaultInvokeCommandInfo(in string selected, in Point point, in bool ctrl = false, in bool shift = false) => GetDefaultInvokeCommandInfo(Marshal.StringToHGlobalAnsi(selected), Marshal.StringToHGlobalUni(selected), point, ctrl, shift);

        public void InvokeCommand(ref ContextMenuInvokeCommandInfo ci) => ThrowExceptionForHResult(_contextMenu.InvokeCommand(ref ci));

        public bool TryPrependMenu(in MenuFlags uFlags, UIntPtr uIDNewItem, string lpNewItem) => Menus.PrependMenu(_menu, uFlags, uIDNewItem, lpNewItem);

        public bool TryPrependMenu(ref MenuItemInfo lpmi) => Menus.PrependMenu(_menu, ref lpmi);

        public bool TryInsertMenu(in uint item, in bool fByPosition, ref MenuItemInfo lpmi) => Menus.InsertMenuItemW(_menu, item, fByPosition, ref lpmi);

        public bool TryInsertMenu(in uint uPosition, in MenuFlags uFlags, in UIntPtr uIDNewItem, in string lpNewItem) => Menus.InsertMenuW(_menu, uPosition, uFlags, uIDNewItem, lpNewItem);

        public bool TryAppendMenu(in MenuFlags uFlags, in UIntPtr uIDNewItem, in string lpNewItem) => Menus.AppendMenuW(_menu, uFlags, uIDNewItem, lpNewItem);

        public bool TryAppendMenu(in MenuFlags uFlags, in UIntPtr uIDNewItem, in IntPtr lpNewItem) => Menus.AppendMenuW(_menu, uFlags, uIDNewItem, lpNewItem);

        public bool TryAppendMenu(in MenuFlags uFlags, in uint uIDNewItem, in string lpNewItem) => Menus.AppendMenu(_menu, uFlags, uIDNewItem, lpNewItem);

        public uint Show(in IntPtr hwnd, in Point point)
        {
            ThrowIfDisposed(this);

            if (_menu == IntPtr.Zero)

                throw new InvalidOperationException($"The current context menu is not initialized. You need to call the {nameof(Query)} method before calling the {nameof(Show)} method.");

#if WAPICP3
            (
#endif
                _hookRegistration
#if WAPICP3
                ?? throw new InvalidOperationException("No hook registration provided."))
#endif
                .AddHook(OnSourceHook);

            uint selected = Menus.TrackPopupMenuEx(_menu, TrackPopupMenuFlags.ReturnCommand, point, hwnd, null);

            _hookRegistration.Value.RemoveHook(OnSourceHook);

            return selected;
        }

        public uint Show2(in IntPtr hwnd, in Point point) => Show(hwnd, point) - _first;

        public void InvokeCommand(in uint command, in Point point, in bool ctrl = false, in bool shift = false)
        {
            ContextMenuInvokeCommandInfo ci = GetDefaultInvokeCommandInfo(command, point, ctrl, shift);

            InvokeCommand(ref ci);
        }

        public void InvokeCommand(in string command, in Point point, in bool ctrl = false, in bool shift = false)
        {
            ContextMenuInvokeCommandInfo ci = GetDefaultInvokeCommandInfo(command, point, ctrl, shift);

            InvokeCommand(ref ci);
        }

        public void TryInvokeCommand(uint command, in Point point, in bool ctrl = false, in bool shift = false)
        {
            if (command >= _first)
            {
                if (command > _last)

                    return;

                InvokeCommand(command, point, ctrl, shift);
            }
        }

        public void ShowAndInvokeCommand(in IntPtr hwnd, in Point point, in bool ctrl = false, in bool shift = false) => InvokeCommand(Show2(hwnd, point), point, ctrl, shift);

        public void ShowAndTryInvokeCommand(in IntPtr hwnd, in Point point, in bool ctrl = false, in bool shift = false) => TryInvokeCommand(Show2(hwnd, point), point, ctrl, shift);

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
