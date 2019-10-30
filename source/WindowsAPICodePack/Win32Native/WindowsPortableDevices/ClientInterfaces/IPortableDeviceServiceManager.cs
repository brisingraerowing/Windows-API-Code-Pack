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
        HResult GetDeviceServices(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pszPnPDeviceID,
            [In] Guid guidServiceCategory,
            [In, Out, MarshalAs(UnmanagedType.LPWStr)] ref string pServices,
            [In, Out] ref uint pcServices);

        HResult GetDeviceForService(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pszPnPServiceID,
            [Out, MarshalAs(UnmanagedType.LPWStr)] out string ppszPnPDeviceID);
    }
}
