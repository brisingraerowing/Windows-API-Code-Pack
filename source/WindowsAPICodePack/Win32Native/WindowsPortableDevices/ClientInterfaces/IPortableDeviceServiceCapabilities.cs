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
        Guid(WPDCOMGuids.IPortableDeviceServiceCapabilities),
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IPortableDeviceServiceCapabilities
    {
        HResult GetSupportedMethods([MarshalAs(UnmanagedType.Interface)] ref IPortableDevicePropVariantCollection ppMethods);

        HResult GetSupportedMethodsByFormat(ref Guid Format, [MarshalAs(UnmanagedType.Interface)] ref IPortableDevicePropVariantCollection ppMethods);

        HResult GetMethodAttributes(ref Guid Method, [MarshalAs(UnmanagedType.Interface)] ref IPortableDeviceValues ppAttributes);

        HResult GetMethodParameterAttributes(ref Guid Method, ref PropertyKey ppAttributes, [MarshalAs(UnmanagedType.Interface)] ref IPortableDeviceValues Parameter);

        HResult GetSupportedFormats([MarshalAs(UnmanagedType.Interface)] ref IPortableDevicePropVariantCollection ppFormats);

        HResult GetFormatAttributes(ref Guid Format, [MarshalAs(UnmanagedType.Interface)] ref IPortableDeviceValues ppAttributes);

        HResult GetSupportedFormatProperties(ref Guid Format, [MarshalAs(UnmanagedType.Interface)] ref IPortableDeviceKeyCollection ppKeys);

        HResult GetFormatPropertyAttributes(ref Guid Format, ref PropertyKey Property, [MarshalAs(UnmanagedType.Interface)] ref IPortableDeviceValues ppAttributes);

        HResult GetSupportedEvents([MarshalAs(UnmanagedType.Interface)] ref IPortableDevicePropVariantCollection ppEvents);

        HResult GetEventAttributes(ref Guid Event, [MarshalAs(UnmanagedType.Interface)] ref IPortableDeviceValues ppAttributes);

        HResult GetEventParameterAttributes(ref Guid Event, ref PropertyKey ppAttributes, [MarshalAs(UnmanagedType.Interface)] ref IPortableDeviceValues Parameter);

        HResult GetInheritedServices(uint dwInheritanceType, [MarshalAs(UnmanagedType.Interface)] ref IPortableDevicePropVariantCollection ppServices);

        HResult GetFormatRenderingProfiles(ref Guid Format, [MarshalAs(UnmanagedType.Interface)] ref IPortableDeviceValuesCollection ppRenderingProfiles);

        HResult GetSupportedCommands([MarshalAs(UnmanagedType.Interface)] ref IPortableDeviceKeyCollection ppCommands);

        HResult GetCommandOptions(ref PropertyKey Command, [MarshalAs(UnmanagedType.Interface)] ref IPortableDeviceValues ppOptions);

        HResult Cancel();
    }
}
