//Copyright (c) Pierre Sprimont.  All rights reserved.

using Microsoft.WindowsAPICodePack.Win32Native;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Microsoft.WindowsAPICodePack. Win32Native.MediaDevices
{
    [ComImport,
        Guid(Guids.MediaDevices.IMDSPStorageGlobals),
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IMDSPStorageGlobals
    {
        [PreserveSig]
        HResult GetCapabilities(
            [Out] out uint pdwCapabilities);

        [PreserveSig]
        HResult GetSerialNumber(
            [Out] out WMDMID pSerialNum,
            [Out, In] ref StringBuilder abMac);

        [PreserveSig]
        HResult GetTotalSize(
            [Out] out uint pdwTotalSizeLow,
            [Out] out uint pdwTotalSizeHigh);

        [PreserveSig]
        HResult GetTotalFree(
            [Out] out uint pdwFreeLow,
            [Out] out uint pdwFreeHigh);

        [PreserveSig]
        HResult GetTotalBad(
            [Out] out uint pdwBadLow,
            [Out] out uint pdwBadHigh);

        [PreserveSig]
        HResult GetStatus(
            [Out] out uint pdwStatus);

        [PreserveSig]
        HResult Initialize(
            [In] ushort fuMode,
            [In] ref IWMDMProgress pProgress);

        [PreserveSig]
        HResult GetDevice(
            [Out] out IMDSPDevice ppDevice);

        [PreserveSig]
        HResult GetRootStorage(
            [Out] out IMDSPStorage ppRoot);
    }
}
