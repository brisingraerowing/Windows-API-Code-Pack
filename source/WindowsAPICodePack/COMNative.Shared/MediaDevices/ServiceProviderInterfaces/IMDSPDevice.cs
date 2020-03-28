//Copyright (c) Pierre Sprimont.  All rights reserved.

using Microsoft.WindowsAPICodePack.COMNative;
using Microsoft.WindowsAPICodePack.COMNative.COM;
using Microsoft.WindowsAPICodePack.COMNative.PropertySystem;
using Microsoft.WindowsAPICodePack.Win32Native;
using Microsoft.WindowsAPICodePack.Win32Native.PropertySystem;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using GuidAttribute = System.Runtime.InteropServices.GuidAttribute;

namespace Microsoft.WindowsAPICodePack.COMNative.MediaDevices
{
    [ComImport,
        Guid(Win32Native.Guids.MediaDevices.IMDSPDevice),
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IMDSPDevice
    {
        [PreserveSig]
        HResult GetName(
            [Out, MarshalAs(UnmanagedType.LPWStr)] out string pwszName,
            [In] ushort nMaxChars);

        [PreserveSig]
        HResult GetManufacturer(
            [Out,MarshalAs(UnmanagedType.LPWStr)] out string pwszName,
            [In] ushort nMaxChars);

        [PreserveSig]
        HResult GetVersion(
            [Out] out uint pdwVersion);

        [PreserveSig]
        HResult GetType(
            [Out] out uint pdwType);

        [PreserveSig]
        HResult GetSerialNumber(
            [Out] out WMDMID pSerialNumber,
            [Out,In] ref StringBuilder abMac);

        [PreserveSig]
        HResult GetPowerSource(
            [Out] uint pdwPowerSource,
            [Out] uint pdwPercentRemaining);

        [PreserveSig]
        HResult GetStatus(
            [Out] uint pdwStatus);

        [PreserveSig]
        HResult GetDeviceIcon(
            [Out] uint hIcon);

        [PreserveSig]
        HResult EnumStorage(
            [Out] out IMDSPEnumStorage ppEnumStorage);

        [PreserveSig]
        HResult GetFormatSupport(
            [Out] out WaveFormatEx pFormatEx,
            [Out] out ushort pnFormatCount,
            [Out, MarshalAs(UnmanagedType.LPWStr)] out string pppwszMimeType,
            [Out] out ushort pnMimeTypeCount);

        [PreserveSig]
        HResult SendOpaqueCommand(
            [Out, In] ref OpaqueCommand pCommand);
    }

    public interface IMDSPDevice2 : IMDSPDevice

    {
        [PreserveSig]
        HResult GetStorage(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pszStorageName,
            [Out] out IMDSPStorage ppStorage);

        [PreserveSig]
        HResult GetFormatSupport2(
            [In] uint dwFlags,
            [Out] out WaveFormatEx ppAudioFormatEx,
            [Out] out ushort pnAudioFormatCount,
            [Out] out VideoInfoHeader ppVideoFormatEx,
            [Out] out ushort pnVideoFormatCount,
            [Out] out FileCapabilities ppFileType,
            [Out] out ushort pnFileTypeCount);

        [PreserveSig]
        HResult GetSpecifyPropertyPages(
            [Out] out ISpecifyPropertyPages ppSpecifyPropPages,
            [Out, MarshalAs(UnmanagedType.IUnknown)] out object pppUnknowns,
            [Out] out uint pcUnks);

        [PreserveSig]
        HResult GetCanonicalName(
            [Out, MarshalAs(UnmanagedType.LPWStr)] out string pwszPnPName,
            [In] ushort nMaxChars);

    }

    public interface IMDSPDevice3 : IMDSPDevice2

    {
        [PreserveSig]
        HResult GetProperty(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pwszPropName,
            [Out] PropVariant pValue);

        [PreserveSig]
        HResult SetProperty(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pwszPropName,
            [In] in PropVariant pValue);

        [PreserveSig]
        HResult GetFormatCapability(
            [In] FormatCode format,
            [Out] out FormatCapability pFormatSupport);

        [PreserveSig]
        HResult DeviceIoControl(
            [In] uint dwIoControlCode,
            [In] ref StringBuilder lpInBuffer,
            [In] uint nInBufferSize,
            [Out] out StringBuilder lpOutBuffer,
            [Out, In] ref uint pnOutBufferSize);

        [PreserveSig]
        HResult FindStorage(
           [In] FindScope findScope,
            [In, MarshalAs(UnmanagedType.LPWStr)] string pwszUniqueID,
            [Out] out IMDSPStorage ppStorage);

    }
}
