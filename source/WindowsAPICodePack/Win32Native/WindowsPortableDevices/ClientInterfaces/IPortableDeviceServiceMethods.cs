using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAPICodePack.Win32Native.Core;
using Microsoft.WindowsAPICodePack.Win32Native.PortableDevices;
using Microsoft.WindowsAPICodePack.Win32Native.PortableDevices.PropertySystem;

namespace Microsoft.WindowsAPICodePack.Win32Native.PortableDevices
{
    [ComImport,
        Guid(Win32Native.Guids.PortableDevices.IPortableDeviceServiceMethods),
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IPortableDeviceServiceMethods
    {
        HResult Invoke(
            [In] ref Guid Method,
            [In] ref IPortableDeviceValues pParameters,
            [In, Out, MarshalAs(UnmanagedType.Interface)] ref IPortableDeviceValues ppResults);

        HResult InvokeAsync(
            [In] ref Guid Method,
            [In] ref IPortableDeviceValues pParameters,
            [In, MarshalAs(UnmanagedType.Interface)] ref IPortableDeviceServiceMethodCallback pCallback);

        HResult Cancel(
            [In, MarshalAs(UnmanagedType.Interface)] ref IPortableDeviceServiceMethodCallback pCallback);
    }
}
