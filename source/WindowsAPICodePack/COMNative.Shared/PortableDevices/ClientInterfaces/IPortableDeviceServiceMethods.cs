//Copyright (c) Pierre Sprimont.  All rights reserved.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAPICodePack.COMNative;
using Microsoft.WindowsAPICodePack.COMNative.PortableDevices;
using Microsoft.WindowsAPICodePack.COMNative.PortableDevices.PropertySystem;
using Microsoft.WindowsAPICodePack.Win32Native;

namespace Microsoft.WindowsAPICodePack.COMNative.PortableDevices
{
    [ComImport,
        Guid(Win32Native.Guids.PortableDevices.IPortableDeviceServiceMethods),
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IPortableDeviceServiceMethods
    {
        [PreserveSig]
        HResult Invoke(
            [In] ref Guid Method,
            [In] ref IPortableDeviceValues pParameters,
            [In, Out, MarshalAs(UnmanagedType.Interface)] ref IPortableDeviceValues ppResults);

        [PreserveSig]
        HResult InvokeAsync(
            [In] ref Guid Method,
            [In] ref IPortableDeviceValues pParameters,
            [In, MarshalAs(UnmanagedType.Interface)] ref IPortableDeviceServiceMethodCallback pCallback);

        [PreserveSig]
        HResult Cancel(
            [In, MarshalAs(UnmanagedType.Interface)] ref IPortableDeviceServiceMethodCallback pCallback);
    }
}
