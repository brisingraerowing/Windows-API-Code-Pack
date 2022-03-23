//Copyright (c) Pierre Sprimont.  All rights reserved.

using Microsoft.WindowsAPICodePack.Win32Native;

using System;
using System.Runtime.InteropServices;

using static System.Runtime.InteropServices.UnmanagedType;

namespace Microsoft.WindowsAPICodePack.COMNative.MediaDevices
{
    [ComImport,
        Guid(NativeAPI.Guids.MediaDevices.IWMDMProgress),
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IWMDMProgress
    {
        [PreserveSig]
        HResult Begin(
            [In, MarshalAs(U4)] uint dwEstimatedTicks);

        [PreserveSig]
        HResult Progress(
            [In, MarshalAs(U4)] uint dwTranspiredTicks);

        [PreserveSig]
        HResult End();
    }

    [ComImport,
        Guid(NativeAPI.Guids.MediaDevices.IWMDMProgress2),
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IWMDMProgress2 : IWMDMProgress
    {
        [PreserveSig]
        HResult End2(
            [In] HResult hrCompletionCode);
    }

    [ComImport,
        Guid(NativeAPI.Guids.MediaDevices.IWMDMProgress3),
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IWMDMProgress3 : IWMDMProgress2
    {
        [PreserveSig]
        HResult Begin3(
            [In] Guid EventId,
            [In, MarshalAs(U4)] uint dwEstimatedTicks,
            [Out,In] ref OpaqueCommand pContext);

        [PreserveSig]
        HResult Progress3(
            [In] Guid EventId,
            [In, MarshalAs(U4)] uint dwTranspiredTicks,
            [Out,In] ref OpaqueCommand pContext);

        [PreserveSig]
        HResult End3(
            [In] Guid EventId,
            [In] HResult hrCompletionCode,
            [Out,In] ref OpaqueCommand pContext);
    }
}
