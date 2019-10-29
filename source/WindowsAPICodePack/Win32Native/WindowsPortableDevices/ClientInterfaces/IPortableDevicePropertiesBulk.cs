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
        HResult QueueGetValuesByObjectList([MarshalAs(UnmanagedType.Interface)] ref IPortableDevicePropVariantCollection pObjectIDs, [MarshalAs(UnmanagedType.Interface)] ref IPortableDeviceKeyCollection pKeys, [MarshalAs(UnmanagedType.Interface)] ref IPortableDevicePropertiesBulkCallback pCallback, ref Guid pContext);

        HResult QueueGetValuesByObjectFormat(ref Guid pguidObjectFormat, [MarshalAs(UnmanagedType.LPWStr)] ref string pszParentObjectID, uint dwDepth, [MarshalAs(UnmanagedType.Interface)] ref IPortableDeviceKeyCollection pKeys, [MarshalAs(UnmanagedType.Interface)] ref IPortableDevicePropertiesBulkCallback pCallback, ref Guid pContext);

        HResult QueueSetValuesByObjectList([MarshalAs(UnmanagedType.Interface)] ref IPortableDeviceValuesCollection pObjectValues, [MarshalAs(UnmanagedType.Interface)] ref IPortableDevicePropertiesBulkCallback pCallback, ref Guid pContext);

        HResult Start(ref Guid pContext);

        HResult Cancel(ref Guid pContext);
    }
}
