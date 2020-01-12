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
        Guid(Win32Native.Guids.PortableDevices.IPortableDeviceManager),
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IPortableDeviceManager
    {
        HResult GetDevices(
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPWStr)] string[] pPnPDeviceIDs,
            [In, Out] ref uint pcPnPDeviceIDs);

        HResult RefreshDeviceList();

        HResult GetDeviceFriendlyName(
            [In, MarshalAs(UnmanagedType.LPWStr)]  string pszPnPDeviceID,
            [In, Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pDeviceFriendlyName,
            [In, Out] ref uint pcchDeviceFriendlyName);

        HResult GetDeviceDescription(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pszPnPDeviceID,
            [In, Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pDeviceDescription,
            [In, Out] ref uint pcchDeviceDescription);

        HResult GetDeviceManufacturer(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pszPnPDeviceID,
            [In, Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pDeviceManufacturer,
            [In, Out] ref uint pcchDeviceManufacturer);

        HResult GetDeviceProperty(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pszPnPDeviceID,
            [In, MarshalAs(UnmanagedType.LPWStr)] string pszDevicePropertyName,
            [In, Out] byte[] pData,
            [In, Out] ref uint pcbData,
            [In, Out] ref BlobValueKind pdwType);

        HResult GetPrivateDevices(
            [In, Out, MarshalAs( UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPWStr)] string[] pPnPDeviceIDs,
            [In, Out] ref uint pcPnPDeviceIDs);
    }
}
