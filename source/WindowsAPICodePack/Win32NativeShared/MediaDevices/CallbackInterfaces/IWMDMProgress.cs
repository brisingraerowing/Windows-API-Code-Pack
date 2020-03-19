//Copyright (c) Pierre Sprimont.  All rights reserved.

using Microsoft.WindowsAPICodePack.Win32Native;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Microsoft.WindowsAPICodePack. Win32Native.MediaDevices
{
    [ComImport,
        Guid(Guids.MediaDevices.IWMDMProgress),
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IWMDMProgress
    {
        [PreserveSig]
        HResult Begin(
            [In] uint dwEstimatedTicks);

        [PreserveSig]
        HResult Progress(
            [In] uint dwTranspiredTicks);

        [PreserveSig]
        HResult End();
    }

    public interface IWMDMProgress2 : IWMDMProgress

    {
        [PreserveSig]
        HResult End2(
            [In] HResult hrCompletionCode);

    }

    public interface IWMDMProgress3 : IWMDMProgress2

    {
        [PreserveSig]
        HResult Begin3(
            [In] Guid EventId,
            [In] uint dwEstimatedTicks,
            [Out,In] ref OpaqueCommand pContext);

        [PreserveSig]
        HResult Progress3(
            [In] Guid EventId,
            [In] uint dwTranspiredTicks,
            [Out,In] ref OpaqueCommand pContext);

        [PreserveSig]
        HResult End3(
            [In] Guid EventId,
            [In] HResult hrCompletionCode,
            [Out,In] ref OpaqueCommand pContext);

    }
}
