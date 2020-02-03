using Microsoft.WindowsAPICodePack.Win32Native.Shell.PropertySystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAPICodePack.Win32Native.PortableDevices;
using Microsoft.WindowsAPICodePack.Win32Native;
using GuidAttribute = System.Runtime.InteropServices.GuidAttribute;
using Microsoft.WindowsAPICodePack.Win32Native.PropertySystem;

namespace Microsoft.WindowsAPICodePack.Win32Native.PortableDevices.PropertySystem
{
    [ComImport,
        Guid(Win32Native.Guids.PortableDevices.IPortableDeviceProperties),
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IPortableDeviceProperties
    {
        [PreserveSig]
        HResult GetSupportedProperties(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pszObjectID,
            [Out, MarshalAs(UnmanagedType.Interface)] out IPortableDeviceKeyCollection ppKeys);

        [PreserveSig]
        HResult GetPropertyAttributes(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pszObjectID,
            [In] ref PropertyKey Key,
            [Out, MarshalAs(UnmanagedType.Interface)] out IPortableDeviceValues ppAttributes);

        [PreserveSig]
        HResult GetValues(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pszObjectID,
            [In, MarshalAs(UnmanagedType.Interface)] ref IPortableDeviceKeyCollection pKeys,
            [Out, MarshalAs(UnmanagedType.Interface)] out IPortableDeviceValues ppValues);

        [PreserveSig]
        HResult SetValues(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pszObjectID,
            [In, MarshalAs(UnmanagedType.Interface)] ref IPortableDeviceValues pValues,
            [Out, MarshalAs(UnmanagedType.Interface)] out IPortableDeviceValues ppResults);

        [PreserveSig]
        HResult Delete(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pszObjectID,
            [In, MarshalAs(UnmanagedType.Interface)] ref IPortableDeviceKeyCollection pKeys);

        [PreserveSig]
        HResult Cancel();
    }
}
