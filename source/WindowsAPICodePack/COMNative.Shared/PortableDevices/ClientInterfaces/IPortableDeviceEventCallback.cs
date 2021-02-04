//Copyright (c) Pierre Sprimont.  All rights reserved.

using System;
using System.Runtime.InteropServices;

using Microsoft.WindowsAPICodePack.COMNative.PortableDevices.PropertySystem;
using Microsoft.WindowsAPICodePack.Win32Native;

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
