//Copyright (c) Pierre Sprimont.  All rights reserved.

using Microsoft.WindowsAPICodePack.Win32Native;

using System;
using System.Runtime.InteropServices;
using System.Text;

using static System.Runtime.InteropServices.UnmanagedType;

namespace Microsoft.WindowsAPICodePack.COMNative.MediaDevices
{
    [ComImport,
        Guid(NativeAPI.Guids.MediaDevices.IMDSPStorageGlobals),
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IMDSPStorageGlobals
    {
        [PreserveSig]
        HResult GetCapabilities(
            [Out, MarshalAs(U4)] out uint pdwCapabilities);

        [PreserveSig]
        HResult GetSerialNumber(
            [Out] out WMDMID pSerialNum,
            [Out, In] ref StringBuilder abMac);

        [PreserveSig]
        HResult GetTotalSize(
            [Out, MarshalAs(U4)] out uint pdwTotalSizeLow,
            [Out, MarshalAs(U4)] out uint pdwTotalSizeHigh);

        [PreserveSig]
        HResult GetTotalFree(
            [Out, MarshalAs(U4)] out uint pdwFreeLow,
            [Out, MarshalAs(U4)] out uint pdwFreeHigh);

        [PreserveSig]
        HResult GetTotalBad(
            [Out, MarshalAs(U4)] out uint pdwBadLow,
            [Out, MarshalAs(U4)] out uint pdwBadHigh);

        [PreserveSig]
        HResult GetStatus(
            [Out, MarshalAs(U4)] out uint pdwStatus);

        [PreserveSig]
        HResult Initialize(
            [In, MarshalAs(U2)] ushort fuMode,
            [In, MarshalAs(Interface)] ref IWMDMProgress pProgress);

        [PreserveSig]
        HResult GetDevice(
            [Out, MarshalAs(Interface)] out IMDSPDevice ppDevice);

        [PreserveSig]
        HResult GetRootStorage(
            [Out, MarshalAs(Interface)] out IMDSPStorage ppRoot);
    }
}
