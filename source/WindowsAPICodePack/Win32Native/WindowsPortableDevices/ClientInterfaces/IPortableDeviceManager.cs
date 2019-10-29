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
        HResult GetDevices([MarshalAs(UnmanagedType.LPWStr)] ref StringBuilder pPnPDeviceIDs, ref uint pcPnPDeviceIDs);

        HResult RefreshDeviceList();

        HResult GetDeviceFriendlyName([MarshalAs(UnmanagedType.LPWStr)] ref string pszPnPDeviceID, [MarshalAs(UnmanagedType.LPWStr)] ref StringBuilder pDeviceFriendlyName, ref uint pcchDeviceFriendlyName);

        HResult GetDeviceDescription([MarshalAs(UnmanagedType.LPWStr)] ref string pszPnPDeviceID, [MarshalAs(UnmanagedType.LPWStr)] ref StringBuilder pDeviceDescription, ref uint pcchDeviceDescription);

        HResult GetDeviceManufacturer([MarshalAs(UnmanagedType.LPWStr)] ref string pszPnPDeviceID, [MarshalAs(UnmanagedType.LPWStr)] ref StringBuilder pDeviceManufacturer, ref uint pcchDeviceManufacturer);

        HResult GetDeviceProperty([MarshalAs(UnmanagedType.LPWStr)] ref string pszPnPDeviceID, [MarshalAs(UnmanagedType.LPWStr)] ref string pszDevicePropertyName, [MarshalAs(UnmanagedType.LPWStr)] ref StringBuilder pData, ref uint pcbData, ref uint pdwType);

        HResult GetPrivateDevices([MarshalAs(UnmanagedType.LPWStr)] ref string pPnPDeviceIDs, ref uint pcPnPDeviceIDs);
    }
}
