using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAPICodePack.Win32Native;
using Microsoft.WindowsAPICodePack.Win32Native.PortableDevices;
using Microsoft.WindowsAPICodePack.Win32Native.PortableDevices.PropertySystem;
using Microsoft.WindowsAPICodePack.Win32Native.PortableDevices.ResourceSystem;

namespace Microsoft.WindowsAPICodePack.Win32Native.PortableDevices
{
    [ComImport,
        Guid(Win32Native.Guids.PortableDevices.IPortableDeviceContent),
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
            [In, MarshalAs(UnmanagedType.Interface)] ref IPortableDeviceValues pValues,
            [In, Out, MarshalAs(UnmanagedType.LPWStr)] ref string ppszObjectID);

        [PreserveSig]
        HResult CreateObjectWithPropertiesAndData(
            [In, MarshalAs(UnmanagedType.Interface)] ref IPortableDeviceValues pValues,
            [Out, MarshalAs(UnmanagedType.Interface)] out System.Runtime.InteropServices.ComTypes.IStream ppData,
            [In, Out] ref uint pdwOptimalWriteBufferSize,
            [In, Out, MarshalAs(UnmanagedType.LPWStr)] ref string ppszCookie);

        [PreserveSig]
        HResult Delete(
            [In] DeleteObjectOptions dwOptions,
            [In, MarshalAs(UnmanagedType.Interface)] ref IPortableDevicePropVariantCollection pObjectIDs,
            [In, Out, MarshalAs(UnmanagedType.Interface)] ref IPortableDevicePropVariantCollection ppResults);

        [PreserveSig]
        HResult GetObjectIDsFromPersistentUniqueIDs(
            [In, MarshalAs(UnmanagedType.Interface)] ref IPortableDevicePropVariantCollection pPersistentUniqueIDs,
            [Out, MarshalAs(UnmanagedType.Interface)] out IPortableDevicePropVariantCollection ppObjectIDs);

        [PreserveSig]
        HResult Cancel();

        [PreserveSig]
        HResult Move(
            [In, MarshalAs(UnmanagedType.Interface)] ref IPortableDevicePropVariantCollection pObjectIDs,
            [In, MarshalAs(UnmanagedType.LPWStr)] string pszDestinationFolderObjectID,
            [In, Out, MarshalAs(UnmanagedType.Interface)] ref IPortableDevicePropVariantCollection ppResults);

        [PreserveSig]
        HResult Copy(
            [In, MarshalAs(UnmanagedType.Interface)] ref IPortableDevicePropVariantCollection pObjectIDs,
            [In, MarshalAs(UnmanagedType.LPWStr)] string pszDestinationFolderObjectID,
            [In, Out, MarshalAs(UnmanagedType.Interface)] ref IPortableDevicePropVariantCollection ppResults);
    }

    [ComImport,
        Guid(Win32Native.Guids.PortableDevices.IPortableDeviceContent2)]
    public interface IPortableDeviceContent2 : IPortableDeviceContent
    {
        [PreserveSig]
        HResult UpdateObjectWithPropertiesAndData(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pszObjectID,
            [In, MarshalAs(UnmanagedType.Interface)] ref IPortableDeviceValues pProperties,
            [Out, MarshalAs(UnmanagedType.Interface)] out System.Runtime.InteropServices.ComTypes.IStream ppData,
            [In, Out] ref uint pdwOptimalWriteBufferSize);
    }
}
