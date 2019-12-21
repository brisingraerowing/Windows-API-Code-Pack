using Microsoft.WindowsAPICodePack.Win32Native.Core;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Microsoft.WindowsAPICodePack. Win32Native.MediaDevices
{
    [ComImport,
        Guid(Guids.MediaDevices.IWMDMNotification),
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IWMDMNotification
    {
        HResult WMDMMessage(
            [In] uint dwMessageType,
            [In,MarshalAs(UnmanagedType.LPWStr)] string pwszCanonicalName);
    }
}
