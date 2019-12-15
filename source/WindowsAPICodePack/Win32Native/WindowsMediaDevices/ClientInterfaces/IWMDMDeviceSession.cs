using Microsoft.WindowsAPICodePack.Win32Native.Core;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Microsoft.WindowsAPICodePack.Win32Native.MediaDevices.ClientInterfaces
{
    [ComImport,
        Guid(Guids.MediaDevices.IWMDMDeviceSession),
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IWMDMDeviceSession
    {
        HResult BeginSession(
            [In] WMDM_SESSION_TYPE type,
            [In] ref StringBuilder pCtx,
            [In] uint dwSizeCtx);
        
        HResult EndSession(
            [In] WMDM_SESSION_TYPE type,
            [In] ref StringBuilder pCtx,
            [In] uint dwSizeCtx);
    }
}
