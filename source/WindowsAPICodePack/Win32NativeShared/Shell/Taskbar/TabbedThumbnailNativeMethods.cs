//Copyright (c) Microsoft Corporation.  All rights reserved.

using System;
using System.Runtime.InteropServices;
using Microsoft.WindowsAPICodePack.Win32Native.Shell;

namespace Microsoft.WindowsAPICodePack.Win32Native.Taskbar
{
    public static class TabbedThumbnailNativeMethods
    {
        [DllImport("gdi32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool StretchBlt(
            IntPtr hDestDC, int destX, int destY, int destWidth, int destHeight,
            IntPtr hSrcDC, int srcX, int srcY, int srcWidth, int srcHeight,
            uint operation);
    }
}
