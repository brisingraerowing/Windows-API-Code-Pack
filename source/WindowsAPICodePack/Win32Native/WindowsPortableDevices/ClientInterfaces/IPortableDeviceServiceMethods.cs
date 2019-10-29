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
        Guid(WPDCOMGuids.IPortableDeviceServiceMethods),
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IPortableDeviceServiceMethods
    {
        HResult Invoke(ref Guid Method, ref IPortableDeviceValues pParameters, [MarshalAs(UnmanagedType.Interface)] ref IPortableDeviceValues ppResults);

        HResult InvokeAsync(ref Guid Method, ref IPortableDeviceValues pParameters, [MarshalAs(UnmanagedType.Interface)] ref IPortableDeviceServiceMethodCallback pCallback);

        HResult Cancel([MarshalAs(UnmanagedType.Interface)] ref IPortableDeviceServiceMethodCallback pCallback);
    }
}
