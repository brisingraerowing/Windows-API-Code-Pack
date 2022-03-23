//Copyright (c) Pierre Sprimont.  All rights reserved.

using Microsoft.WindowsAPICodePack.COMNative.PortableDevices.PropertySystem;
using Microsoft.WindowsAPICodePack.Win32Native;

using System;
using System.Runtime.InteropServices;

namespace Microsoft.WindowsAPICodePack.COMNative.PortableDevices
{
    [ComImport,
    Guid(NativeAPI.Guids.PortableDevices.IPortableDeviceServiceMethods),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IPortableDeviceServiceMethods
    {
        [PreserveSig]
        HResult Invoke(
            [In] ref Guid Method,
            [In] ref IPortableDeviceValues pParameters,
            [In, Out, MarshalAs(UnmanagedType.Interface)]
#if !WAPICP3
ref
#endif
         IPortableDeviceValues ppResults);

        [PreserveSig]
        HResult InvokeAsync(
            [In] ref Guid Method,
            [In] ref IPortableDeviceValues pParameters,
            [In, MarshalAs(UnmanagedType.Interface)]
#if !WAPICP3
ref
#endif
         IPortableDeviceServiceMethodCallback pCallback);

        [PreserveSig]
        HResult Cancel(
            [In, MarshalAs(UnmanagedType.Interface)]
#if !WAPICP3
ref
#endif
         IPortableDeviceServiceMethodCallback pCallback);
    }
}
