//Copyright (c) Pierre Sprimont.  All rights reserved.

using Microsoft.WindowsAPICodePack.Win32Native;

using System;
using System.Runtime.InteropServices;

namespace Microsoft.WindowsAPICodePack.COMNative.PortableDevices
{
    [ComImport,
    Guid(NativeAPI.Guids.PortableDevices.IPortableDeviceServiceManager),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IPortableDeviceServiceManager
    {
        [PreserveSig]
        HResult GetDeviceServices(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pszPnPDeviceID,
            [In] ref Guid guidServiceCategory,
            [In, Out, MarshalAs( UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPWStr)] string[] pServices,
            [In, Out] ref uint pcServices);

        [PreserveSig]
        HResult GetDeviceForService(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pszPnPServiceID,
            [Out, MarshalAs(UnmanagedType.LPWStr)] out string ppszPnPDeviceID);
    }
}
