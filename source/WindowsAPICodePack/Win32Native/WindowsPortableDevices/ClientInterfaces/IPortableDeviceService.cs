using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAPICodePack.Win32Native.Core;
using Microsoft.WindowsAPICodePack.Win32Native.PortableDevices.CollectionInterfaces;

namespace Microsoft.WindowsAPICodePack.Win32Native.PortableDevices.ClientInterfaces
{
    [ComImport,
        Guid(WPDCOMGuids.IPortableDeviceService),
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IPortableDeviceService
    {
        HResult Open([MarshalAs(UnmanagedType.LPWStr)] ref string pszPnPServiceID, [MarshalAs(UnmanagedType.Interface)] ref IPortableDeviceValues pClientInfo);

        HResult Capabilities([MarshalAs(UnmanagedType.Interface)] ref IPortableDeviceServiceCapabilities ppCapabilities);

        HResult Content([MarshalAs(UnmanagedType.Interface)] ref IPortableDeviceContent2 ppContent);

        HResult Methods([MarshalAs(UnmanagedType.Interface)] ref IPortableDeviceServiceMethods ppMethods);

        HResult Cancel();

        HResult Close();

        HResult GetServiceObjectID([MarshalAs(UnmanagedType.LPWStr)] ref string ppszServiceObjectID);

        HResult GetPnPServiceID([MarshalAs(UnmanagedType.LPWStr)] ref string ppszPnPServiceID);

        HResult Advise(uint dwFlags, [MarshalAs(UnmanagedType.Interface)] ref IPortableDeviceEventCallback pCallback, [MarshalAs(UnmanagedType.Interface)] ref IPortableDeviceValues pParameters, [MarshalAs(UnmanagedType.LPWStr)] ref string ppszCookie);

        HResult Unadvise([MarshalAs(UnmanagedType.LPWStr)] ref string pszCookie);

        HResult SendCommand(uint dwFlags, [MarshalAs(UnmanagedType.Interface)] ref IPortableDeviceValues pParameters, [MarshalAs(UnmanagedType.Interface)] ref IPortableDeviceValues ppResults);
    }
}
