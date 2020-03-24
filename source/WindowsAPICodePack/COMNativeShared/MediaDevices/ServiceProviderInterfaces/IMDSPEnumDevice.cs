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
        Guid(Win32Native.Guids.MediaDevices.IMDSPEnumDevice),
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IMDSPEnumDevice
    {
        [PreserveSig]
        HResult Next(
            [In] uint celt,
            [Out] out IMDSPDevice ppDevice,
            [Out] out uint pceltFetched);

        [PreserveSig]
        HResult Skip(
            [In] uint celt,
            [Out] out uint pceltFetched);

        [PreserveSig]
        HResult Reset();

        [PreserveSig]
        HResult Clone(
            [Out] out IMDSPEnumDevice ppEnumDevice);
    }
}
