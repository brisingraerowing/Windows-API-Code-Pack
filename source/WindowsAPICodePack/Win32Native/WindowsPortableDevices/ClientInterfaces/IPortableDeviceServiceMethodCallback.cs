using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAPICodePack.Win32Native.Core;
using Microsoft.WindowsAPICodePack.Win32Native.PortableDevices.CollectionInterfaces;

namespace Microsoft.WindowsAPICodePack.Win32Native.PortableDevices.ClientInterfaces
{
    [ComImport,
        Guid(Win32Native.Guids.PortableDevices.IPortableDeviceServiceMethodCallback),
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IPortableDeviceServiceMethodCallback
    {
        HResult OnComplete(
            [In] HResult hrStatus,
            [In, MarshalAs(UnmanagedType.Interface)] ref IPortableDeviceValues pResults);
    }
}
