//Copyright (c) Pierre Sprimont.  All rights reserved.

using Microsoft.WindowsAPICodePack.COMNative;
using Microsoft.WindowsAPICodePack.Win32Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.WindowsAPICodePack.COMNative.PortableDevices
{
    [ComImport,
        Guid(NativeAPI.Guids.PortableDevices.IPortableDeviceManager),
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IPortableDeviceManager
    {
        [PreserveSig]
        HResult GetDevices(
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPWStr)] string[] pPnPDeviceIDs,
            [In, Out] ref uint pcPnPDeviceIDs);

        [PreserveSig]
        HResult RefreshDeviceList();

        [PreserveSig]
        HResult GetDeviceFriendlyName(
            [In, MarshalAs(UnmanagedType.LPWStr)]  string pszPnPDeviceID,
            [In, Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pDeviceFriendlyName,
            [In, Out] ref uint pcchDeviceFriendlyName);

        [PreserveSig]
        HResult GetDeviceDescription(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pszPnPDeviceID,
            [In, Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pDeviceDescription,
            [In, Out] ref uint pcchDeviceDescription);

        [PreserveSig]
        HResult GetDeviceManufacturer(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pszPnPDeviceID,
            [In, Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pDeviceManufacturer,
            [In, Out] ref uint pcchDeviceManufacturer);

        [PreserveSig]
        HResult GetDeviceProperty(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pszPnPDeviceID,
            [In, MarshalAs(UnmanagedType.LPWStr)] string pszDevicePropertyName,
            [In, Out] byte[] pData,
            [In, Out] ref uint pcbData,
            [In, Out] ref BlobValueKind pdwType);

        [PreserveSig]
        HResult GetPrivateDevices(
            [In, Out, MarshalAs( UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPWStr)] string[] pPnPDeviceIDs,
            [In, Out] ref uint pcPnPDeviceIDs);
    }
}
