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
        Guid(WPDCOMGuids.IPortableDeviceManager),
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IPortableDeviceManager
    {
        HResult GetDevices(
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPWStr)] string[] pPnPDeviceIDs,
            [In, Out] ref uint pcPnPDeviceIDs);

        HResult RefreshDeviceList();

        HResult GetDeviceFriendlyName([ In, MarshalAs(UnmanagedType.LPWStr)]  string pszPnPDeviceID, [ In,Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pDeviceFriendlyName, [In,Out] ref uint pcchDeviceFriendlyName);

        HResult GetDeviceDescription([MarshalAs(UnmanagedType.LPWStr)] string pszPnPDeviceID, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder pDeviceDescription, ref uint pcchDeviceDescription);

        HResult GetDeviceManufacturer([MarshalAs(UnmanagedType.LPWStr)] string pszPnPDeviceID, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder pDeviceManufacturer, ref uint pcchDeviceManufacturer);

        HResult GetDeviceProperty([MarshalAs(UnmanagedType.LPWStr)] string pszPnPDeviceID, [MarshalAs(UnmanagedType.LPWStr)] ref string pszDevicePropertyName, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder pData, ref uint pcbData, ref uint pdwType);

        HResult GetPrivateDevices([MarshalAs(UnmanagedType.LPWStr)] string pPnPDeviceIDs, ref uint pcPnPDeviceIDs);
    }
}
