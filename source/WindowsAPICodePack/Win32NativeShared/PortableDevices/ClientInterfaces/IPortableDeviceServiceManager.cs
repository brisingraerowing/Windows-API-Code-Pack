//Copyright (c) Pierre Sprimont.  All rights reserved.

using Microsoft.WindowsAPICodePack.Win32Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.WindowsAPICodePack.Win32Native.PortableDevices
{
    [ComImport,
        Guid(Win32Native.Guids.PortableDevices.IPortableDeviceServiceManager),
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
