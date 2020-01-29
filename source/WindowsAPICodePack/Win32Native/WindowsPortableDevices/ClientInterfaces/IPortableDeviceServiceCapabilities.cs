﻿using Microsoft.WindowsAPICodePack.Win32Native.Shell.PropertySystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAPICodePack.Win32Native.PortableDevices;
using Microsoft.WindowsAPICodePack.Win32Native;
using Microsoft.WindowsAPICodePack.Win32Native.PortableDevices.PropertySystem;
using GuidAttribute = System.Runtime.InteropServices.GuidAttribute;

namespace Microsoft.WindowsAPICodePack.Win32Native.PortableDevices
{
    [ComImport,
        Guid(Win32Native.Guids.PortableDevices.IPortableDeviceServiceCapabilities),
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IPortableDeviceServiceCapabilities
    {
        [PreserveSig]
        HResult GetSupportedMethods(
            [Out, MarshalAs(UnmanagedType.Interface)] out IPortableDevicePropVariantCollection ppMethods);

        [PreserveSig]
        HResult GetSupportedMethodsByFormat(
            [In] ref Guid Format,
            [Out, MarshalAs(UnmanagedType.Interface)] out IPortableDevicePropVariantCollection ppMethods);

        [PreserveSig]
        HResult GetMethodAttributes(
            [In] ref Guid Method,
            [Out, MarshalAs(UnmanagedType.Interface)] out IPortableDeviceValues ppAttributes);

        [PreserveSig]
        HResult GetMethodParameterAttributes(
            [In] ref Guid Method,
            [In] ref PropertyKey ppAttributes,
            [Out, MarshalAs(UnmanagedType.Interface)] out IPortableDeviceValues Parameter);

        [PreserveSig]
        HResult GetSupportedFormats(
            [Out, MarshalAs(UnmanagedType.Interface)] out IPortableDevicePropVariantCollection ppFormats);

        [PreserveSig]
        HResult GetFormatAttributes(
            [In] ref Guid Format,
            [Out, MarshalAs(UnmanagedType.Interface)] out IPortableDeviceValues ppAttributes);

        [PreserveSig]
        HResult GetSupportedFormatProperties(
            [In] ref Guid Format,
            [Out, MarshalAs(UnmanagedType.Interface)] out IPortableDeviceKeyCollection ppKeys);

        [PreserveSig]
        HResult GetFormatPropertyAttributes(
            [In] ref Guid Format,
            [In] ref PropertyKey Property,
            [Out, MarshalAs(UnmanagedType.Interface)] out IPortableDeviceValues ppAttributes);

        [PreserveSig]
        HResult GetSupportedEvents(
            [Out, MarshalAs(UnmanagedType.Interface)] out IPortableDevicePropVariantCollection ppEvents);

        [PreserveSig]
        HResult GetEventAttributes(
            [In] ref Guid Event,
            [Out, MarshalAs(UnmanagedType.Interface)] out IPortableDeviceValues ppAttributes);

        [PreserveSig]
        HResult GetEventParameterAttributes(
            [In] ref Guid Event,
            [In] ref PropertyKey ppAttributes,
            [Out, MarshalAs(UnmanagedType.Interface)] out IPortableDeviceValues Parameter);

        [PreserveSig]
        HResult GetInheritedServices(
            [In] uint dwInheritanceType,
            [Out, MarshalAs(UnmanagedType.Interface)] out IPortableDevicePropVariantCollection ppServices);

        [PreserveSig]
        HResult GetFormatRenderingProfiles(
            [In] ref Guid Format,
            [Out, MarshalAs(UnmanagedType.Interface)] out IPortableDeviceValuesCollection ppRenderingProfiles);

        [PreserveSig]
        HResult GetSupportedCommands(
            [Out, MarshalAs(UnmanagedType.Interface)] out IPortableDeviceKeyCollection ppCommands);

        [PreserveSig]
        HResult GetCommandOptions(
            [In] ref PropertyKey Command,
            [Out, MarshalAs(UnmanagedType.Interface)] out IPortableDeviceValues ppOptions);

        [PreserveSig]
        HResult Cancel();
    }
}
