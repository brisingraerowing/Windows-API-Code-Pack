using Microsoft.WindowsAPICodePack.Win32Native.Shell.PropertySystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAPICodePack.Win32Native.PortableDevices.CollectionInterfaces;
using Microsoft.WindowsAPICodePack.Win32Native.Core;

namespace Microsoft.WindowsAPICodePack.Win32Native.PortableDevices.ClientInterfaces
{
    [ComImport,
        Guid(WPDCOMGuids.IPortableDeviceProperties),
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IPortableDeviceProperties
    {
        HResult GetSupportedProperties([MarshalAs(UnmanagedType.LPWStr)] ref string pszObjectID, [MarshalAs(UnmanagedType.Interface)] ref IPortableDeviceKeyCollection ppKeys);

        HResult GetPropertyAttributes([MarshalAs(UnmanagedType.LPWStr)] ref string pszObjectID, ref PropertyKey Key, [MarshalAs(UnmanagedType.Interface)] ref IPortableDeviceValues ppAttributes);

        HResult GetValues([MarshalAs(UnmanagedType.LPWStr)] ref string pszObjectID, [MarshalAs(UnmanagedType.Interface)] ref IPortableDeviceKeyCollection pKeys, [MarshalAs(UnmanagedType.Interface)] ref IPortableDeviceValues ppValues);

        HResult SetValues([MarshalAs(UnmanagedType.LPWStr)] ref string pszObjectID, [MarshalAs(UnmanagedType.Interface)] ref IPortableDeviceValues pValues, [MarshalAs(UnmanagedType.Interface)] ref IPortableDeviceValues ppResults);

        HResult Delete([MarshalAs(UnmanagedType.LPWStr)] ref string pszObjectID, [MarshalAs(UnmanagedType.Interface)] ref IPortableDeviceKeyCollection pKeys);

        HResult Cancel();
    }
}
