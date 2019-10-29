using Microsoft.WindowsAPICodePack.Win32Native.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.WindowsAPICodePack.Win32Native.PortableDevices.ClientInterfaces
{
    [ComImport,
        Guid(WPDCOMGuids.IPortableDeviceServiceManager),
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IPortableDeviceServiceManager
    {
        HResult GetDeviceServices([MarshalAs(UnmanagedType.LPWStr)] ref string pszPnPDeviceID, ref Guid guidServiceCategory, [MarshalAs(UnmanagedType.LPWStr)] ref string pServices, ref uint pcServices);

        HResult GetDeviceForService([MarshalAs(UnmanagedType.LPWStr)] ref string pszPnPServiceID, [MarshalAs(UnmanagedType.LPWStr)] ref string ppszPnPDeviceID);
    }
}
