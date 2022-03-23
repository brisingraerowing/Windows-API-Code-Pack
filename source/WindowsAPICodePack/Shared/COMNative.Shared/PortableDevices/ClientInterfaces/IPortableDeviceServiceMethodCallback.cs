//Copyright (c) Pierre Sprimont.  All rights reserved.

using Microsoft.WindowsAPICodePack.COMNative.PortableDevices.PropertySystem;
using Microsoft.WindowsAPICodePack.Win32Native;

using System;
using System.Runtime.InteropServices;

namespace Microsoft.WindowsAPICodePack.COMNative.PortableDevices
{
    [ComImport,
    Guid(NativeAPI.Guids.PortableDevices.IPortableDeviceServiceMethodCallback),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IPortableDeviceServiceMethodCallback
    {
        [PreserveSig]
        HResult OnComplete(
            [In] HResult hrStatus,
            [In, MarshalAs(UnmanagedType.Interface)]
#if !WAPICP3
ref
#endif
         IPortableDeviceValues pResults);
    }
}
