#if CS5
using Microsoft.WindowsAPICodePack.Win32Native;
using Microsoft.WindowsAPICodePack.Win32Native.Menus;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;

using WinCopies.Collections;

using static Microsoft.WindowsAPICodePack.Win32Native.Menus.MenuFlags;

namespace Microsoft.WindowsAPICodePack
{
    public class Menu : ICountable, IEnumerable<MenuItem>, WinCopies.DotNetFix.IDisposable
    {
        protected internal IntPtr Handle { get; }

        public int Count => Menus.GetMenuItemCount(Handle);

        public bool IsDisposed => Handle == IntPtr.Zero;

        public Menu(in IntPtr handle) => Handle = handle;

        public IEnumerator<MenuItem> GetEnumerator() => new MenuEnumerator(this);

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        protected virtual void Dispose(bool disposing) => Menus.DestroyMenu(Handle);

        ~Menu() => Dispose(false);

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }

    public class MenuItem
    {
        protected Bitmap _bitmap;

        public Menu Parent { get; }

        public Menu Children { get; }

        public uint? Id { get; }

        protected int Position { get; }

        public Bitmap Icon
        {
            get
            {
                IntPtr bitmapPtr = GetInfo(MenuItemInfoFlags.Bitmap).hbmpItem;

                if (bitmapPtr != _bitmap?.GetHbitmap())

                    _bitmap = bitmapPtr == IntPtr.Zero ? null : Image.FromHbitmap(bitmapPtr);

                return _bitmap;
            }

            set
            {
                SetInfo(MenuItemInfoFlags.Bitmap, new MenuItemInfo() { hbmpItem = value == null ? IntPtr.Zero : value.GetHbitmap() });

                _bitmap = value;
            }
        }

        public bool IsEnabled
        {
            get
            {
                MenuStates state = GetInfo(MenuItemInfoFlags.State).fState;

                return !(state.HasFlag((MenuStates)Disabled) || state.HasFlag((MenuStates)Grayed) || state.HasFlag(MenuStates.Grayed));
            }

            set => Menus.EnableMenuItemByPosition(Parent.Handle, (uint)Position, value ? Enabled : Grayed);
        }

        public bool IsChecked { get => GetInfo(MenuItemInfoFlags.State).fState.HasFlag(MenuStates.Checked); set => SetInfo(MenuItemInfoFlags.State, new MenuItemInfo { fState = value ? MenuStates.Checked : MenuStates.Unchecked }); }

        public string Header
        {
            get
            {
                MenuItemInfo info = GetInfo(MenuItemInfoFlags.State | MenuItemInfoFlags.String);

                info.dwTypeData = new string('\0', (int)++info.cch);

                GetInfo(MenuItemInfoFlags.State | MenuItemInfoFlags.String, ref info);

                return info.dwTypeData;
            }

            set => SetInfo(MenuItemInfoFlags.String, new MenuItemInfo() { dwTypeData = value });
        }

        public bool IsSeparator { get => GetInfo(MenuItemInfoFlags.FType).fType.HasFlag(Separator); set => SetInfo(MenuItemInfoFlags.FType, new MenuItemInfo() { fType = MenuFlags.Separator }); }

        internal MenuItem(in Menu parent, in uint id, in int pos)
        {
            Parent = parent;

            Id = id == unchecked((uint)-1) ?
#if !CS9
                (uint?)
#endif
                null : id;

            Position = pos;

            if (!Id.HasValue)

                Children = new Menu(Menus.GetSubMenu(parent.Handle, Position));
        }

        protected delegate bool MenuItemInfoAction(IntPtr hmenu, uint item, bool fByPosition, ref MenuItemInfo lpmii);

        protected void OnMenuItemInfoAction(in MenuItemInfoAction action, ref MenuItemInfo info)
        {
            if (!action(Parent.Handle, (uint)Position, true, ref info))

                throw CoreErrorHelper.GetExceptionForLastWin32Error();
        }

        protected void GetInfo(in MenuItemInfoFlags flags, ref MenuItemInfo info)
        {
            info.fMask = flags;
            info.cbSize = (uint)Marshal.SizeOf<MenuItemInfo>();
            info.fType = ByPosition;

            OnMenuItemInfoAction(Menus.GetMenuItemInfoW, ref info);
        }

        protected MenuItemInfo GetInfo(in MenuItemInfoFlags flags)
        {
            var info = new MenuItemInfo();

            GetInfo(flags, ref info);

            return info;
        }

        protected void SetInfo(in MenuItemInfoFlags flags, MenuItemInfo info)
        {
            info.fMask = flags;
            info.cbSize = (uint)Marshal.SizeOf<MenuItemInfo>();

            OnMenuItemInfoAction(Menus.SetMenuItemInfoW, ref info);
        }
    }

    public class MenuEnumerator : WinCopies.Collections.Generic.Enumerator<MenuItem>
    {
        private MenuItem _current;
        private int _currentPos;

        protected Menu Menu { get; }

        protected override MenuItem CurrentOverride => _current;

        public override bool? IsResetSupported => true;

        public MenuEnumerator(in Menu menu)
        {
            Menu = menu;

            ResetCurrentPos();
        }

        protected void ResetCurrentPos() => _currentPos = -1;

        protected override bool MoveNextOverride()
        {
            if (++_currentPos < Menu.Count)
            {
                _current = new MenuItem(Menu, Menus.GetMenuItemID(Menu.Handle, _currentPos), _currentPos);

                return true;
            }

            return false;
        }

        protected override void ResetCurrent()
        {
            base.ResetCurrent();

            _current = null;

            ResetCurrentPos();
        }

        protected override void ResetOverride2() { /* Left empty. */ }
    }
}
#endif
