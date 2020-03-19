//Copyright (c) Pierre Sprimont.  All rights reserved.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAPICodePack.Win32Native;
using Microsoft.WindowsAPICodePack.Win32Native.PortableDevices;

namespace Microsoft.WindowsAPICodePack.Win32Native.PortableDevices.PropertySystem
{
    [ComImport,
        Guid(Win32Native.Guids.PortableDevices.IPortableDevicePropertiesBulk),
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IPortableDevicePropertiesBulk
    {
        [PreserveSig]
        HResult QueueGetValuesByObjectList(
            [In, MarshalAs(UnmanagedType.Interface)] ref IPortableDevicePropVariantCollection pObjectIDs,
            [In, MarshalAs(UnmanagedType.Interface)] ref IPortableDeviceKeyCollection pKeys,
            [In, MarshalAs(UnmanagedType.Interface)] ref IPortableDevicePropertiesBulkCallback pCallback,
            [Out] out Guid pContext);

        [PreserveSig]
        HResult QueueGetValuesByObjectFormat(
            [In] ref Guid pguidObjectFormat,
            [In, MarshalAs(UnmanagedType.LPWStr)] string pszParentObjectID,
            [In] uint dwDepth,
            [In, MarshalAs(UnmanagedType.Interface)] ref IPortableDeviceKeyCollection pKeys,
            [In, MarshalAs(UnmanagedType.Interface)] ref IPortableDevicePropertiesBulkCallback pCallback,
            [Out] out Guid pContext);

        [PreserveSig]
        HResult QueueSetValuesByObjectList(
            [In, MarshalAs(UnmanagedType.Interface)] ref IPortableDeviceValuesCollection pObjectValues,
            [In, MarshalAs(UnmanagedType.Interface)] ref IPortableDevicePropertiesBulkCallback pCallback,
            [Out] out Guid pContext);

        [PreserveSig]
        HResult Start(
            [In] ref Guid pContext);

        [PreserveSig]
        HResult Cancel(
            [In] ref Guid pContext);
    }
}
