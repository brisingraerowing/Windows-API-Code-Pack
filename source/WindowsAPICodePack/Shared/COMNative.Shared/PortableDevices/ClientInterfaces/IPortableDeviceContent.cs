//Copyright (c) Pierre Sprimont.  All rights reserved.

using Microsoft.WindowsAPICodePack.COMNative.PortableDevices.PropertySystem;
using Microsoft.WindowsAPICodePack.COMNative.PortableDevices.ResourceSystem;
using Microsoft.WindowsAPICodePack.Win32Native;

using System;
using System.Runtime.InteropServices;

namespace Microsoft.WindowsAPICodePack.COMNative.PortableDevices
{
    [ComImport,
    Guid(NativeAPI.Guids.PortableDevices.IPortableDeviceContent),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IPortableDeviceContent
    {
        [PreserveSig]
        HResult EnumObjects(
            [In] uint dwFlags,
            [In, MarshalAs(UnmanagedType.LPWStr)] string pszParentObjectID,
            [In, MarshalAs(UnmanagedType.Interface)] IPortableDeviceValues pFilter,
            [Out, MarshalAs(UnmanagedType.Interface)] out IEnumPortableDeviceObjectIDs ppEnum);

        [PreserveSig]
        HResult Properties(
            [Out, MarshalAs(UnmanagedType.Interface)] out IPortableDeviceProperties ppProperties);

        [PreserveSig]
        HResult Transfer(
            [Out, MarshalAs(UnmanagedType.Interface)] out IPortableDeviceResources ppResources);

        [PreserveSig]
        HResult CreateObjectWithPropertiesOnly(
            [In, MarshalAs(UnmanagedType.Interface)]  IPortableDeviceValues pValues,
            [In, Out, MarshalAs(UnmanagedType.LPWStr)] ref string ppszObjectID);

        [PreserveSig]
        HResult CreateObjectWithPropertiesAndData(
            [In, MarshalAs(UnmanagedType.Interface)]  IPortableDeviceValues pValues,
            [Out, MarshalAs(UnmanagedType.Interface)] out System.Runtime.InteropServices.ComTypes.IStream ppData,
            [In, Out, MarshalAs(UnmanagedType.U4)] ref uint pdwOptimalWriteBufferSize,
            [In, Out, MarshalAs(UnmanagedType.LPWStr)] ref  string ppszCookie);

        [PreserveSig]
        HResult Delete(
            [In] DeleteObjectOptionValues dwOptions,
            [In, MarshalAs(UnmanagedType.Interface)]  IPortableDevicePropVariantCollection pObjectIDs,
            [In, Out, MarshalAs(UnmanagedType.Interface)]
#if !WAPICP3
ref
#endif
         IPortableDevicePropVariantCollection ppResults);

        [PreserveSig]
        HResult GetObjectIDsFromPersistentUniqueIDs(
            [In, MarshalAs(UnmanagedType.Interface)]  IPortableDevicePropVariantCollection pPersistentUniqueIDs,
            [Out, MarshalAs(UnmanagedType.Interface)] out IPortableDevicePropVariantCollection ppObjectIDs);

        [PreserveSig]
        HResult Cancel();

        [PreserveSig]
        HResult Move(
            [In, MarshalAs(UnmanagedType.Interface)]
#if !WAPICP3
ref
#endif
         IPortableDevicePropVariantCollection pObjectIDs,
            [In, MarshalAs(UnmanagedType.LPWStr)] string pszDestinationFolderObjectID,
            [In, Out, MarshalAs(UnmanagedType.Interface)]
#if !WAPICP3
ref
#endif
         IPortableDevicePropVariantCollection ppResults);

        [PreserveSig]
        HResult Copy(
            [In, MarshalAs(UnmanagedType.Interface)]
#if !WAPICP3
ref
#endif
         IPortableDevicePropVariantCollection pObjectIDs,
            [In, MarshalAs(UnmanagedType.LPWStr)] string pszDestinationFolderObjectID,
            [In, Out, MarshalAs(UnmanagedType.Interface)]
#if !WAPICP3
ref
#endif
         IPortableDevicePropVariantCollection ppResults);
    }

    [ComImport,
        Guid(NativeAPI.Guids.PortableDevices.IPortableDeviceContent2)]
    public interface IPortableDeviceContent2 : IPortableDeviceContent
    {
        [PreserveSig]
        HResult UpdateObjectWithPropertiesAndData(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pszObjectID,
            [In, MarshalAs(UnmanagedType.Interface)]
#if !WAPICP3
ref
#endif
         IPortableDeviceValues pProperties,
            [Out, MarshalAs(UnmanagedType.Interface)] out System.Runtime.InteropServices.ComTypes.IStream ppData,
            [In, Out] ref uint pdwOptimalWriteBufferSize);
    }
}
