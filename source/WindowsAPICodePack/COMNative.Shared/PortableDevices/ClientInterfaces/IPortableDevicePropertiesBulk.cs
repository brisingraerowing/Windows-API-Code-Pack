//Copyright (c) Pierre Sprimont.  All rights reserved.

using Microsoft.WindowsAPICodePack.Win32Native;

using System;
using System.Runtime.InteropServices;

namespace Microsoft.WindowsAPICodePack.COMNative.PortableDevices.PropertySystem
{
    [ComImport,
    Guid(NativeAPI.Guids.PortableDevices.IPortableDevicePropertiesBulk),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IPortableDevicePropertiesBulk
    {
        [PreserveSig]
        HResult QueueGetValuesByObjectList(
            [In, MarshalAs(UnmanagedType.Interface)]
#if !WAPICP3
ref
#endif
         IPortableDevicePropVariantCollection pObjectIDs,
            [In, MarshalAs(UnmanagedType.Interface)]
#if !WAPICP3
ref
#endif
         IPortableDeviceKeyCollection pKeys,
            [In, MarshalAs(UnmanagedType.Interface)]
#if !WAPICP3
ref
#endif
         IPortableDevicePropertiesBulkCallback pCallback,
            [Out] out Guid pContext);

        [PreserveSig]
        HResult QueueGetValuesByObjectFormat(
            [In] ref Guid pguidObjectFormat,
            [In, MarshalAs(UnmanagedType.LPWStr)] string pszParentObjectID,
            [In] uint dwDepth,
            [In, MarshalAs(UnmanagedType.Interface)]
#if !WAPICP3
ref
#endif
         IPortableDeviceKeyCollection pKeys,
            [In, MarshalAs(UnmanagedType.Interface)]
#if !WAPICP3
ref
#endif
         IPortableDevicePropertiesBulkCallback pCallback,
            [Out] out Guid pContext);

        [PreserveSig]
        HResult QueueSetValuesByObjectList(
            [In, MarshalAs(UnmanagedType.Interface)]
#if !WAPICP3
ref
#endif
         IPortableDeviceValuesCollection pObjectValues,
            [In, MarshalAs(UnmanagedType.Interface)]
#if !WAPICP3
ref
#endif
         IPortableDevicePropertiesBulkCallback pCallback,
            [Out] out Guid pContext);

        [PreserveSig]
        HResult Start(
            [In] ref Guid pContext);

        [PreserveSig]
        HResult Cancel(
            [In] ref Guid pContext);
    }
}
