using Microsoft.WindowsAPICodePack.Win32Native.Core;
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
        HResult Begin(
            [In] uint dwEstimatedTicks);
        
        HResult Progress(
            [In] uint dwTranspiredTicks);
        
        HResult End();
    }

    public interface IWMDMProgress2 : IWMDMProgress

    {
        HResult End2(
            [In] HResult hrCompletionCode);

    }

    public interface IWMDMProgress3 : IWMDMProgress2

    {
        HResult Begin3(
            [In] Guid EventId,
            [In] uint dwEstimatedTicks,
            [Out,In] ref OpaqueCommand pContext);
        
        HResult Progress3(
            [In] Guid EventId,
            [In] uint dwTranspiredTicks,
            [Out,In] ref OpaqueCommand pContext);
        
        HResult End3(
            [In] Guid EventId,
            [In] HResult hrCompletionCode,
            [Out,In] ref OpaqueCommand pContext);

    }
}
