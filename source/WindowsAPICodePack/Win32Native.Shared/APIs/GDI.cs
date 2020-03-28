using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Text;
using static Microsoft.WindowsAPICodePack.Win32Native.Consts.DllNames;

namespace Microsoft.WindowsAPICodePack.Win32Native.GDI
{
    public static class GDI
    {

        [DllImport(Gdi32)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool DeleteObject([In] IntPtr hObject);

        [DllImport(Gdi32)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool StretchBlt(
            [In]IntPtr hDestDC, [In, MarshalAs(UnmanagedType.I4)] int destX, [In, MarshalAs(UnmanagedType.I4)] int destY, [In, MarshalAs(UnmanagedType.I4)] int destWidth, [In, MarshalAs(UnmanagedType.I4)] int destHeight,
            IntPtr hSrcDC, [In, MarshalAs(UnmanagedType.I4)] int srcX, [In, MarshalAs(UnmanagedType.I4)] int srcY, [In, MarshalAs(UnmanagedType.I4)] int srcWidth, [In, MarshalAs(UnmanagedType.I4)] int srcHeight,
            [In, MarshalAs(UnmanagedType.U4)] uint operation);

        [DllImport(Gdi32)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool MaskBlt([In] IntPtr hdcDest, [In, MarshalAs(UnmanagedType.I4)] int xDest, [In, MarshalAs(UnmanagedType.I4)] int yDest, [In, MarshalAs(UnmanagedType.I4)] int width, [In, MarshalAs(UnmanagedType.I4)] int height, [In] IntPtr hdcSrc, [In, MarshalAs(UnmanagedType.I4)] int xSrc, [In, MarshalAs(UnmanagedType.I4)] int ySrc, [In] IntPtr hbmMask, [In, MarshalAs(UnmanagedType.I4)] int xMask, [In, MarshalAs(UnmanagedType.I4)] int yMask, [In, MarshalAs(UnmanagedType.U4)] uint rop);

        [DllImport(Gdi32)]
        [return: MarshalAs(UnmanagedType.U4)]
        public static extern uint SetBkColor([In]IntPtr hdc, [In, MarshalAs(UnmanagedType.U4)] uint color);

        [DllImport(Gdi32)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool BitBlt([In] IntPtr hdc, [In, MarshalAs(UnmanagedType.I4)] int x, [In, MarshalAs(UnmanagedType.I4)] int y, [In, MarshalAs(UnmanagedType.I4)] int cx, [In, MarshalAs(UnmanagedType.I4)] int cy, [In] IntPtr hdcSrc, [In, MarshalAs(UnmanagedType.I4)] int x1, [In, MarshalAs(UnmanagedType.I4)] int y1, [In, MarshalAs(UnmanagedType.U4)] uint rop);

        [DllImport(Gdi32)]
        public static extern IntPtr CreateCompatibleDC([In] IntPtr hdc);

        [DllImport(Gdi32)]
        public static extern IntPtr CreateDIBSection([In] IntPtr hdc, [In] ref BitmapInfo pbmi, [In] uint usage, [Out] out IntPtr ppvBits, [In] IntPtr hSection, [In, MarshalAs(UnmanagedType.U4)] uint offset);

        [DllImport(Gdi32)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool DeleteDC([In] IntPtr hdc);

        [DllImport(Gdi32)]
        public static extern IntPtr SelectObject([In] IntPtr hdc, [In] IntPtr h);

        public static extern IntPtr CreateCompatibleBitmap([In] IntPtr hdc, [In,MarshalAs(UnmanagedType.I4)] int cx, [In,MarshalAs(UnmanagedType.I4)] int cy);

    }

    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    public  struct BitmapInfo
    {
        public BitmapInfoHeader bmiHeader;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public RGBQuad[] bmiColors;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    public  struct BitmapInfoHeader
    {
        [MarshalAs(UnmanagedType.U4)]
        public uint biSize;
        [MarshalAs(UnmanagedType.I4)]
        public int biWidth;
        [MarshalAs(UnmanagedType.I4)]
        public int biHeight;
        [MarshalAs(UnmanagedType.U2)]
        public ushort biPlanes;
        [MarshalAs(UnmanagedType.U2)]
        public ushort biBitCount;
        [MarshalAs(UnmanagedType.U2)]
        public ushort biCompression;
        [MarshalAs(UnmanagedType.U2)]
        public ushort biSizeImage;
        [MarshalAs(UnmanagedType.I4)]
        public int biXPelsPerMeter;
        [MarshalAs(UnmanagedType.I4)]
        public int biYPelsPerMeter;
        [MarshalAs(UnmanagedType.U4)]
        public uint biClrUsed;
        [MarshalAs(UnmanagedType.U4)]
        public uint biClrImportant;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct RGBQuad
    {
        public byte rgbBlue;
        public byte rgbGreen;
        public byte rgbRed;
        public byte rgbReserved;
    }
}
