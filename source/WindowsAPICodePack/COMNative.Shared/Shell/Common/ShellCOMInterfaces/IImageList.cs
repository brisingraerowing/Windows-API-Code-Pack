using Microsoft.WindowsAPICodePack.Win32Native;

using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace Microsoft.WindowsAPICodePack.COMNative.Shell
{
    [ComImport(),
    Guid(NativeAPI.Guids.Shell.IImageList),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IImageList
    {
        [PreserveSig]
        HResult Add([In] IntPtr hbmImage, [In] IntPtr hbmMask, [Out] out int pi);

        [PreserveSig]
        HResult ReplaceIcon(int i, [In] IntPtr hicon, [Out] out int pi);

        [PreserveSig]
        HResult SetOverlayImage(int iImage, int iOverlay);

        [PreserveSig]
        HResult Replace(int i, [In] IntPtr hbmImage, [In] IntPtr hbmMask);

        [PreserveSig]
        HResult AddMasked([In] IntPtr hbmImage, uint crMask, [Out] out int pi);

        [PreserveSig]
        HResult Draw([In] IntPtr  /*IMAGELISTDRAWPARAMS*/ pimldp);

        [PreserveSig]
        HResult Remove(int i);

        [PreserveSig]
        HResult GetIcon(int i, ImageListDrawFlags flags, [Out] out IntPtr picon);

        [PreserveSig]
        HResult GetImageInfo(int i, [Out] out ImageInfo pImageInfo);

        [PreserveSig]
        HResult Copy(int iDst, [In] object punkSrc, int iSrc, uint uFlags);

        [PreserveSig]
        HResult Merge(int i1, [In] object punk2, int i2, int dx, int dy, ref Guid riid, [Out] out IntPtr ppv);

        [PreserveSig]
        HResult Clone(ref Guid riid, [Out] out IntPtr ppv);

        [PreserveSig]
        HResult GetImageRect(int i, [Out] out Rectangle prc);

        [PreserveSig]
        HResult GetIconSize([Out] out int cx, [Out] out int cy);

        [PreserveSig]
        HResult SetIconSize(int cx, int cy);

        [PreserveSig]
        HResult GetImageCount([Out] out int pi);

        [PreserveSig]
        HResult SetImageCount(uint uNewCount);

        [PreserveSig]
        HResult SetBkColor(uint clrBk, [Out] out uint pclr);

        [PreserveSig]
        HResult GetBkColor([Out] out uint pclr);

        [PreserveSig]
        HResult BeginDrag(int iTrack, int dxHotspot, int dyHotspot);

        [PreserveSig]
        HResult EndDrag();

        [PreserveSig]
        HResult DragEnter([In] IntPtr hwndLock, int x, int y);

        [PreserveSig]
        HResult DragLeave([In] IntPtr hwndLock);

        [PreserveSig]
        HResult DragMove(int x, int y);

        [PreserveSig]
        HResult SetDragCursorImage([In] object punk, int iDrag, int dxHotspot, int dyHotspot);

        [PreserveSig]
        HResult DragShowNolock(bool /*BOOL*/ fShow);

        [PreserveSig]
        HResult GetDragImage([Out] out Point ppt, [Out] out Point pptHotspot, ref Guid riid, [Out] out IntPtr ppv);

        [PreserveSig]
        HResult GetItemFlags(int i, [Out] out uint dwFlags);

        [PreserveSig]
        HResult GetOverlayImage(int iOverlay, [Out] out int piIndex);
    };
}
