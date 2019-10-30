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
        HResult GetSupportedMethods(
            [Out, MarshalAs(UnmanagedType.Interface)] out IPortableDevicePropVariantCollection ppMethods);

        HResult GetSupportedMethodsByFormat(
            [In] Guid Format,
            [Out, MarshalAs(UnmanagedType.Interface)] out IPortableDevicePropVariantCollection ppMethods);

        HResult GetMethodAttributes(
            [In] Guid Method,
            [Out, MarshalAs(UnmanagedType.Interface)] out IPortableDeviceValues ppAttributes);

        HResult GetMethodParameterAttributes(
            [In] Guid Method,
            [In] PropertyKey ppAttributes,
            [Out, MarshalAs(UnmanagedType.Interface)] out IPortableDeviceValues Parameter);

        HResult GetSupportedFormats(
            [Out, MarshalAs(UnmanagedType.Interface)] out IPortableDevicePropVariantCollection ppFormats);

        HResult GetFormatAttributes(
            [In] Guid Format,
            [Out, MarshalAs(UnmanagedType.Interface)] out IPortableDeviceValues ppAttributes);

        HResult GetSupportedFormatProperties(
            [In] Guid Format,
            [Out, MarshalAs(UnmanagedType.Interface)] out IPortableDeviceKeyCollection ppKeys);

        HResult GetFormatPropertyAttributes(
            [In] Guid Format,
            [In] PropertyKey Property,
            [Out, MarshalAs(UnmanagedType.Interface)] out IPortableDeviceValues ppAttributes);

        HResult GetSupportedEvents(
            [Out, MarshalAs(UnmanagedType.Interface)] out IPortableDevicePropVariantCollection ppEvents);

        HResult GetEventAttributes(
            [In] Guid Event,
            [Out, MarshalAs(UnmanagedType.Interface)] out IPortableDeviceValues ppAttributes);

        HResult GetEventParameterAttributes(
            [In] Guid Event,
            [In] PropertyKey ppAttributes,
            [Out, MarshalAs(UnmanagedType.Interface)] out IPortableDeviceValues Parameter);

        HResult GetInheritedServices(
            [In] uint dwInheritanceType,
            [Out, MarshalAs(UnmanagedType.Interface)] out IPortableDevicePropVariantCollection ppServices);

        HResult GetFormatRenderingProfiles(
            [In] Guid Format,
            [Out, MarshalAs(UnmanagedType.Interface)] out IPortableDeviceValuesCollection ppRenderingProfiles);

        HResult GetSupportedCommands(
            [Out, MarshalAs(UnmanagedType.Interface)] out IPortableDeviceKeyCollection ppCommands);

        HResult GetCommandOptions(
            [In] PropertyKey Command,
            [Out, MarshalAs(UnmanagedType.Interface)] out IPortableDeviceValues ppOptions);

        HResult Cancel();
    }
}
