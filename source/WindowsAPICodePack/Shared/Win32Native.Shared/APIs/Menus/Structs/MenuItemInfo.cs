using System;
using System.Runtime.InteropServices;

using static System.Runtime.InteropServices.UnmanagedType;

namespace Microsoft.WindowsAPICodePack.Win32Native.Menus
{
    public struct MenuItemInfo
    {
        [MarshalAs(U4)]
        public uint cbSize;
        [MarshalAs(U4)]
        public MenuItemInfoFlags fMask;
        [MarshalAs(U4)]
        public
#if WAPICP3
            MenuFlags
#else
uint
#endif
            fType;         // used if MIIM_TYPE (4.0) or MIIM_FTYPE (>4.0)
        [MarshalAs(U4)]
        public
#if WAPICP3
            MenuStates
#else
uint
#endif
         fState;        // used if MIIM_STATE
        [MarshalAs(U4)]
        public uint wID;           // used if MIIM_ID
        public IntPtr hSubMenu;      // used if MIIM_SUBMENU
        public IntPtr hbmpChecked;   // used if MIIM_CHECKMARKS
        public IntPtr hbmpUnchecked; // used if MIIM_CHECKMARKS
        public UIntPtr dwItemData;   // used if MIIM_DATA
        [MarshalAs(LPWStr)]
        public string dwTypeData;    // used if MIIM_TYPE (4.0) or MIIM_STRING (>4.0)
        [MarshalAs(U4)]
        public uint cch;           // used if MIIM_TYPE (4.0) or MIIM_STRING (>4.0)
        public IntPtr hbmpItem;      // used if MIIM_BITMAP
    }
}
