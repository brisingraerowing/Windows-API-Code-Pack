//Copyright (c) Pierre Sprimont.  All rights reserved.

using Microsoft.WindowsAPICodePack.Win32Native;

using System;
using System.Runtime.InteropServices;

using static System.Runtime.InteropServices.UnmanagedType;

namespace Microsoft.WindowsAPICodePack.COMNative.MediaDevices
{
    [ComImport,
        Guid(NativeAPI.Guids.MediaDevices.IMDSPDeviceControl),
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IMDSPDeviceControl
    {
        [PreserveSig]
        HResult GetDCStatus(
            [Out, MarshalAs(U4)] out uint pdwStatus);

        [PreserveSig]
        HResult GetCapabilities(
            [Out, MarshalAs(U4)] out uint pdwCapabilitiesMask);

        [PreserveSig]
        HResult Play();

        [PreserveSig]
        HResult Record(
            [In] ref WaveFormatEx pFormat);

        [PreserveSig]
        HResult Pause();

        [PreserveSig]
        HResult Resume();

        [PreserveSig]
        HResult Stop();

        [PreserveSig]
        HResult Seek(
            [In, MarshalAs(U2)] ushort fuMode,
            [In, MarshalAs(I2)] short nOffset);
    }
}
