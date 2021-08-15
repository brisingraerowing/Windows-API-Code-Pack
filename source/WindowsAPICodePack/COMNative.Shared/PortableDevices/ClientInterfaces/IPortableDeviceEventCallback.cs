//Copyright (c) Pierre Sprimont.  All rights reserved.

using Microsoft.WindowsAPICodePack.COMNative.PortableDevices.PropertySystem;
using Microsoft.WindowsAPICodePack.Win32Native;

using System;
using System.Runtime.InteropServices;

namespace Microsoft.WindowsAPICodePack.COMNative.PortableDevices.EventSystem
{
    [ComImport,
    Guid(NativeAPI.Guids.PortableDevices.IPortableDeviceEventCallback),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IPortableDeviceEventCallback
    {
        [PreserveSig]
        HResult OnEvent(
            [In, MarshalAs(UnmanagedType.Interface)]
#if !WAPICP3
ref
#endif
         IPortableDeviceValues pEventParameters);
    }
}
