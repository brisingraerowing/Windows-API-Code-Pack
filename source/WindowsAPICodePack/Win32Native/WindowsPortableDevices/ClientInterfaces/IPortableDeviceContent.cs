using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAPICodePack.Win32Native.Core;
using Microsoft.WindowsAPICodePack.Win32Native.PortableDevices;

namespace Microsoft.WindowsAPICodePack.Win32Native.PortableDevices
{
    [ComImport,
        Guid(Win32Native.Guids.PortableDevices.IPortableDeviceContent),
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IPortableDeviceContent
    {
        HResult EnumObjects(
            [In] uint dwFlags,
            [In, MarshalAs(UnmanagedType.LPWStr)] string pszParentObjectID,
            [In, MarshalAs(UnmanagedType.Interface)] ref IPortableDeviceValues pFilter,
            [Out, MarshalAs(UnmanagedType.Interface)] out IEnumPortableDeviceObjectIDs ppEnum);

        HResult Properties(
            [Out, MarshalAs(UnmanagedType.Interface)] out IPortableDeviceProperties ppProperties);

        HResult Transfer(
            [Out, MarshalAs(UnmanagedType.Interface)] out IPortableDeviceResources ppResources);

        HResult CreateObjectWithPropertiesOnly(
            [In, MarshalAs(UnmanagedType.Interface)] ref IPortableDeviceValues pValues,
            [In, Out, MarshalAs(UnmanagedType.LPWStr)] ref string ppszObjectID);

        HResult CreateObjectWithPropertiesAndData(
            [In, MarshalAs(UnmanagedType.Interface)] ref IPortableDeviceValues pValues,
            [Out, MarshalAs(UnmanagedType.Interface)] out System.Runtime.InteropServices.ComTypes.IStream ppData,
            [In, Out] ref uint pdwOptimalWriteBufferSize,
            [In, Out, MarshalAs(UnmanagedType.LPWStr)] ref string ppszCookie);

        HResult Delete(
            [In] DeleteObjectOptions dwOptions,
            [In, MarshalAs(UnmanagedType.Interface)] ref IPortableDevicePropVariantCollection pObjectIDs,
            [In, Out, MarshalAs(UnmanagedType.Interface)] ref IPortableDevicePropVariantCollection ppResults);

        HResult GetObjectIDsFromPersistentUniqueIDs(
            [In, MarshalAs(UnmanagedType.Interface)] ref IPortableDevicePropVariantCollection pPersistentUniqueIDs,
            [Out, MarshalAs(UnmanagedType.Interface)] out IPortableDevicePropVariantCollection ppObjectIDs);

        HResult Cancel();

        HResult Move(
            [In, MarshalAs(UnmanagedType.Interface)] ref IPortableDevicePropVariantCollection pObjectIDs,
            [In, MarshalAs(UnmanagedType.LPWStr)] string pszDestinationFolderObjectID,
            [In, Out, MarshalAs(UnmanagedType.Interface)] ref IPortableDevicePropVariantCollection ppResults);

        HResult Copy(
            [In, MarshalAs(UnmanagedType.Interface)] ref IPortableDevicePropVariantCollection pObjectIDs,
            [In, MarshalAs(UnmanagedType.LPWStr)] string pszDestinationFolderObjectID,
            [In, Out, MarshalAs(UnmanagedType.Interface)] ref IPortableDevicePropVariantCollection ppResults);
    }
}
