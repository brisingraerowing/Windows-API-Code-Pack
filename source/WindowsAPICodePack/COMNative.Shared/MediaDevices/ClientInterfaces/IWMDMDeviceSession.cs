//Copyright (c) Pierre Sprimont.  All rights reserved.

using Microsoft.WindowsAPICodePack.COMNative;
using Microsoft.WindowsAPICodePack.Win32Native;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Microsoft.WindowsAPICodePack.COMNative.MediaDevices
{
    [ComImport,
        Guid(NativeAPI.Guids.MediaDevices.IWMDMDeviceSession),
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IWMDMDeviceSession
    {
        [PreserveSig]
        HResult BeginSession(
            [In] SessionType type,
            [In] ref StringBuilder pCtx,
            [In] uint dwSizeCtx);

        [PreserveSig]
        HResult EndSession(
            [In] SessionType type,
            [In] ref StringBuilder pCtx,
            [In] uint dwSizeCtx);
    }
}
