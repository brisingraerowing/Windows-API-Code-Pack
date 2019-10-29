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
        Guid(WPDCOMGuids.IPortableDeviceContent),
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IPortableDeviceContent
    {
        HResult EnumObjects(uint dwFlags, [MarshalAs(UnmanagedType.LPWStr)] ref string pszParentObjectID, [MarshalAs(UnmanagedType.Interface)] ref IPortableDeviceValues pFilter, [MarshalAs(UnmanagedType.Interface)] ref IEnumPortableDeviceObjectIDs ppEnum);

        HResult Properties([MarshalAs(UnmanagedType.Interface)] ref IPortableDeviceProperties ppProperties);

        HResult Transfer([MarshalAs(UnmanagedType.Interface)] ref IPortableDeviceResources ppResources);

        HResult CreateObjectWithPropertiesOnly([MarshalAs(UnmanagedType.Interface)] ref IPortableDeviceValues pValues, [MarshalAs(UnmanagedType.LPWStr)] ref string ppszObjectID);

        HResult CreateObjectWithPropertiesAndData([MarshalAs(UnmanagedType.Interface)] ref IPortableDeviceValues pValues, [MarshalAs(UnmanagedType.Interface)] ref System.Runtime.InteropServices.ComTypes.IStream ppData, ref uint pdwOptimalWriteBufferSize, [MarshalAs(UnmanagedType.LPWStr)] ref string ppszCookie);

        HResult Delete(DeleteObjectOptions dwOptions, [MarshalAs(UnmanagedType.Interface)] ref IPortableDevicePropVariantCollection pObjectIDs, [MarshalAs(UnmanagedType.Interface)] ref IPortableDevicePropVariantCollection ppResults);

        HResult GetObjectIDsFromPersistentUniqueIDs([MarshalAs(UnmanagedType.Interface)] ref IPortableDevicePropVariantCollection pPersistentUniqueIDs, [MarshalAs(UnmanagedType.Interface)] ref IPortableDevicePropVariantCollection ppObjectIDs);

        HResult Cancel();

        HResult Move([MarshalAs(UnmanagedType.Interface)] ref IPortableDevicePropVariantCollection pObjectIDs, [MarshalAs(UnmanagedType.LPWStr)] ref string pszDestinationFolderObjectID, [MarshalAs(UnmanagedType.Interface)] ref IPortableDevicePropVariantCollection ppResults);

        HResult Copy([MarshalAs(UnmanagedType.Interface)] ref IPortableDevicePropVariantCollection pObjectIDs, [MarshalAs(UnmanagedType.LPWStr)] ref string pszDestinationFolderObjectID, [MarshalAs(UnmanagedType.Interface)] ref IPortableDevicePropVariantCollection ppResults);
    }
}
