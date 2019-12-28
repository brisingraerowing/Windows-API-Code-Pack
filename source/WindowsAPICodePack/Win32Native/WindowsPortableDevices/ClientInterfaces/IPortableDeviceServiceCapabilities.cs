using Microsoft.WindowsAPICodePack.Win32Native.Shell.PropertySystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAPICodePack.Win32Native.PortableDevices;
using Microsoft.WindowsAPICodePack.Win32Native.Core;

namespace Microsoft.WindowsAPICodePack.Win32Native.PortableDevices
{
    [ComImport,
        Guid(Win32Native.Guids.PortableDevices.IPortableDeviceServiceCapabilities),
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IPortableDeviceServiceCapabilities
    {
        HResult GetSupportedMethods(
            [Out, MarshalAs(UnmanagedType.Interface)] out IPortableDevicePropVariantCollection ppMethods);

        HResult GetSupportedMethodsByFormat(
            [In] ref Guid Format,
            [Out, MarshalAs(UnmanagedType.Interface)] out IPortableDevicePropVariantCollection ppMethods);

        HResult GetMethodAttributes(
            [In] ref Guid Method,
            [Out, MarshalAs(UnmanagedType.Interface)] out IPortableDeviceValues ppAttributes);

        HResult GetMethodParameterAttributes(
            [In] ref Guid Method,
            [In] ref PropertyKey ppAttributes,
            [Out, MarshalAs(UnmanagedType.Interface)] out IPortableDeviceValues Parameter);

        HResult GetSupportedFormats(
            [Out, MarshalAs(UnmanagedType.Interface)] out IPortableDevicePropVariantCollection ppFormats);

        HResult GetFormatAttributes(
            [In] ref Guid Format,
            [Out, MarshalAs(UnmanagedType.Interface)] out IPortableDeviceValues ppAttributes);

        HResult GetSupportedFormatProperties(
            [In] ref Guid Format,
            [Out, MarshalAs(UnmanagedType.Interface)] out IPortableDeviceKeyCollection ppKeys);

        HResult GetFormatPropertyAttributes(
            [In] ref Guid Format,
            [In] ref PropertyKey Property,
            [Out, MarshalAs(UnmanagedType.Interface)] out IPortableDeviceValues ppAttributes);

        HResult GetSupportedEvents(
            [Out, MarshalAs(UnmanagedType.Interface)] out IPortableDevicePropVariantCollection ppEvents);

        HResult GetEventAttributes(
            [In] ref Guid Event,
            [Out, MarshalAs(UnmanagedType.Interface)] out IPortableDeviceValues ppAttributes);

        HResult GetEventParameterAttributes(
            [In] ref Guid Event,
            [In] ref PropertyKey ppAttributes,
            [Out, MarshalAs(UnmanagedType.Interface)] out IPortableDeviceValues Parameter);

        HResult GetInheritedServices(
            [In] uint dwInheritanceType,
            [Out, MarshalAs(UnmanagedType.Interface)] out IPortableDevicePropVariantCollection ppServices);

        HResult GetFormatRenderingProfiles(
            [In] ref Guid Format,
            [Out, MarshalAs(UnmanagedType.Interface)] out IPortableDeviceValuesCollection ppRenderingProfiles);

        HResult GetSupportedCommands(
            [Out, MarshalAs(UnmanagedType.Interface)] out IPortableDeviceKeyCollection ppCommands);

        HResult GetCommandOptions(
            [In] ref PropertyKey Command,
            [Out, MarshalAs(UnmanagedType.Interface)] out IPortableDeviceValues ppOptions);

        HResult Cancel();
    }
}
