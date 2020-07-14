//Copyright (c) Pierre Sprimont.  All rights reserved.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAPICodePack.COMNative;
using Microsoft.WindowsAPICodePack.COMNative.PortableDevices;
using Microsoft.WindowsAPICodePack.COMNative.PortableDevices.EventSystem;
using Microsoft.WindowsAPICodePack.COMNative.PortableDevices.PropertySystem;
using Microsoft.WindowsAPICodePack.Win32Native;

namespace Microsoft.WindowsAPICodePack.COMNative.PortableDevices
{
    [ComImport,
        Guid(NativeAPI.Guids.PortableDevices.IPortableDeviceService),
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IPortableDeviceService
    {
        [PreserveSig]
        HResult Open(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pszPnPServiceID,
            [In, MarshalAs(UnmanagedType.Interface)] ref IPortableDeviceValues pClientInfo);

        [PreserveSig]
        HResult Capabilities(
            [Out, MarshalAs(UnmanagedType.Interface)] out IPortableDeviceServiceCapabilities ppCapabilities);

        [PreserveSig]
        HResult Content(
            [Out, MarshalAs(UnmanagedType.Interface)] out IPortableDeviceContent2 ppContent);

        [PreserveSig]
        HResult Methods(
            [Out, MarshalAs(UnmanagedType.Interface)] out IPortableDeviceServiceMethods ppMethods);

        [PreserveSig]
        HResult Cancel();

        [PreserveSig]
        HResult Close();

        [PreserveSig]
        HResult GetServiceObjectID(
            [Out, MarshalAs(UnmanagedType.LPWStr)] out string ppszServiceObjectID);

        [PreserveSig]
        HResult GetPnPServiceID(
            [Out, MarshalAs(UnmanagedType.LPWStr)] out string ppszPnPServiceID);

        [PreserveSig]
        HResult Advise(
            [In] uint dwFlags,
            [In, MarshalAs(UnmanagedType.Interface)] ref IPortableDeviceEventCallback pCallback,
            [In, MarshalAs(UnmanagedType.Interface)] ref IPortableDeviceValues pParameters,
            [Out, MarshalAs(UnmanagedType.LPWStr)] out string ppszCookie);

        [PreserveSig]
        HResult Unadvise(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pszCookie);

        [PreserveSig]
        HResult SendCommand(
            [In] uint dwFlags,
            [In, MarshalAs(UnmanagedType.Interface)] ref IPortableDeviceValues pParameters,
            [Out, MarshalAs(UnmanagedType.Interface)] out IPortableDeviceValues ppResults);
    }
}
