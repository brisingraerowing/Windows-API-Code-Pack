using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAPICodePack.Win32Native.Core;
using Microsoft.WindowsAPICodePack.Win32Native.PortableDevices.CollectionInterfaces;

namespace Microsoft.WindowsAPICodePack.Win32Native.PortableDevices
{
    [ComImport,
        Guid(Win32Native.Guids.PortableDevices.IPortableDeviceService),
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IPortableDeviceService
    {
        HResult Open(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pszPnPServiceID,
            [In, MarshalAs(UnmanagedType.Interface)] ref IPortableDeviceValues pClientInfo);

        HResult Capabilities(
            [Out, MarshalAs(UnmanagedType.Interface)] out IPortableDeviceServiceCapabilities ppCapabilities);

        HResult Content(
            [Out, MarshalAs(UnmanagedType.Interface)] out IPortableDeviceContent2 ppContent);

        HResult Methods(
            [Out, MarshalAs(UnmanagedType.Interface)] out IPortableDeviceServiceMethods ppMethods);

        HResult Cancel();

        HResult Close();

        HResult GetServiceObjectID(
            [Out, MarshalAs(UnmanagedType.LPWStr)] out string ppszServiceObjectID);

        HResult GetPnPServiceID(
            [Out, MarshalAs(UnmanagedType.LPWStr)] out string ppszPnPServiceID);

        HResult Advise(
            [In] uint dwFlags,
            [In, MarshalAs(UnmanagedType.Interface)] ref IPortableDeviceEventCallback pCallback,
            [In, MarshalAs(UnmanagedType.Interface)] ref IPortableDeviceValues pParameters,
            [Out, MarshalAs(UnmanagedType.LPWStr)] out string ppszCookie);

        HResult Unadvise(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pszCookie);

        HResult SendCommand(
            [In] uint dwFlags,
            [In, MarshalAs(UnmanagedType.Interface)] ref IPortableDeviceValues pParameters,
            [Out, MarshalAs(UnmanagedType.Interface)] out IPortableDeviceValues ppResults);
    }
}
