using System.Runtime.InteropServices;

using static System.Runtime.InteropServices.UnmanagedType;

namespace Microsoft.WindowsAPICodePack.Win32Native.Menus
{
    public struct TrackPopupMenuParams
    {
        [MarshalAs(U4)]
        public uint cbSize;     /* Size of structure */

        public System.Drawing.Rectangle rcExclude;  /* Screen coordinates of rectangle to exclude when positioning */
    }
}
