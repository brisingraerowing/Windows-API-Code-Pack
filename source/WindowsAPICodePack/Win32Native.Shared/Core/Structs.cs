//Copyright (c) Microsoft Corporation.  All rights reserved.  Distributed under the Microsoft Public License (MS-PL)

using System;
using System.Runtime.InteropServices;

namespace Microsoft.WindowsAPICodePack.Win32Native
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct IconInfo
    {
        [MarshalAs(UnmanagedType.Bool)]
        public bool fIcon;
        [MarshalAs(UnmanagedType.U4)]
        public uint xHotspot;
        [MarshalAs(UnmanagedType.U4)]
        public uint yHotspot;
        public IntPtr hbmMask;
        public IntPtr hbmColor;
    }

    #region GDI and DWM Declarations

    /// <summary>
    /// A Wrapper for a SIZE struct
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct Size
    {
        /// <summary>
        /// Width
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// Height
        /// </summary>
        public int Height { get; set; }
    };

    #endregion
}
