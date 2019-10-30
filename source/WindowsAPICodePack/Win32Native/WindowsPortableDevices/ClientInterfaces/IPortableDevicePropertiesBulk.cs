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
        Guid(WPDCOMGuids.IPortableDevicePropertiesBulk),
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IPortableDevicePropertiesBulk
    {
        HResult QueueGetValuesByObjectList(
            [In, MarshalAs(UnmanagedType.Interface)] ref IPortableDevicePropVariantCollection pObjectIDs,
            [In, MarshalAs(UnmanagedType.Interface)] ref IPortableDeviceKeyCollection pKeys,
            [In, MarshalAs(UnmanagedType.Interface)] ref IPortableDevicePropertiesBulkCallback pCallback,
            [Out] out Guid pContext);

        HResult QueueGetValuesByObjectFormat(
            [In] Guid pguidObjectFormat,
            [In, MarshalAs(UnmanagedType.LPWStr)] string pszParentObjectID,
            [In] uint dwDepth,
            [In, MarshalAs(UnmanagedType.Interface)] ref IPortableDeviceKeyCollection pKeys,
            [In, MarshalAs(UnmanagedType.Interface)] ref IPortableDevicePropertiesBulkCallback pCallback,
            [Out] out Guid pContext);

        HResult QueueSetValuesByObjectList(
            [In, MarshalAs(UnmanagedType.Interface)] ref IPortableDeviceValuesCollection pObjectValues,
            [In, MarshalAs(UnmanagedType.Interface)] ref IPortableDevicePropertiesBulkCallback pCallback,
            [Out] out Guid pContext);

        HResult Start(
            [In] Guid pContext);

        HResult Cancel(
            [In] Guid pContext);
    }
}
