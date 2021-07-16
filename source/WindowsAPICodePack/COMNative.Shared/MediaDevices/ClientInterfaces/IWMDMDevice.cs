//Copyright (c) Pierre Sprimont.  All rights reserved.

using Microsoft.WindowsAPICodePack.COMNative.COM;
using Microsoft.WindowsAPICodePack.Win32Native;
using Microsoft.WindowsAPICodePack.Win32Native.PropertySystem;

using System;
using System.Runtime.InteropServices;
using System.Text;

using static System.Runtime.InteropServices.UnmanagedType;

using GuidAttribute = System.Runtime.InteropServices.GuidAttribute;

namespace Microsoft.WindowsAPICodePack.COMNative.MediaDevices
{
    [ComImport,
        Guid(NativeAPI.Guids.MediaDevices.IWMDMDevice),
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IWMDMDevice
    {
        [PreserveSig]
        HResult GetName(
            [Out, MarshalAs(LPWStr)] string pwszName,
            [In, MarshalAs(U2)] ushort nMaxChars);

        [PreserveSig]
        HResult GetManufacturer(
            [Out, MarshalAs(LPWStr)] string pwszName,
            [In, MarshalAs(U2)] ushort nMaxChars);

        [PreserveSig]
        HResult GetVersion(
            [Out, MarshalAs(U4)] out uint pdwVersion);

        [PreserveSig]
        HResult GetType(
            [Out, MarshalAs(U4)] out uint pdwType);

        [PreserveSig]
        HResult GetSerialNumber(
            [Out] out WMDMID pSerialNumber,
            [Out, In] ref StringBuilder abMac);

        [PreserveSig]
        HResult GetPowerSource(
            [Out, MarshalAs(U4)] out uint pdwPowerSource,
            [Out, MarshalAs(U4)] out uint pdwPercentRemaining);

        [PreserveSig]
        HResult GetStatus(
            [Out, MarshalAs(U4)] out uint pdwStatus);

        [PreserveSig]
        HResult GetDeviceIcon(
            [Out, MarshalAs(U4)] out uint hIcon);

        [PreserveSig]
        HResult EnumStorage(
            [Out, MarshalAs(Interface)] out IWMDMEnumStorage ppEnumStorage);

        [PreserveSig]
        HResult GetFormatSupport(
            [Out] out WaveFormatEx ppFormatEx,
            [Out, MarshalAs(U2)] out ushort pnFormatCount,
            [Out, MarshalAs(LPWStr)] out string pppwszMimeType,
            [Out, MarshalAs(U2)] out ushort pnMimeTypeCount);

        [PreserveSig]
        HResult SendOpaqueCommand(
            [Out, In] ref OpaqueCommand pCommand);
    }

    [ComImport,
        Guid(NativeAPI.Guids.MediaDevices.IWMDMDevice2),
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IWMDMDevice2 : IWMDMDevice
    {
        [PreserveSig]
        HResult GetStorage(
            [In, MarshalAs(LPWStr)] string pszStorageName,
            [Out, MarshalAs(Interface)] out IWMDMStorage ppStorage);

        [PreserveSig]
        HResult GetFormatSupport2(
            [In, MarshalAs(U4)] uint dwFlags,
            [Out] out WaveFormatEx ppAudioFormatEx,
            [Out, MarshalAs(U2)] out ushort pnAudioFormatCount,
            [Out] out VideoInfoHeader ppVideoFormatEx,
            [Out, MarshalAs(U2)] out ushort pnVideoFormatCount,
            [Out] out FileCapabilities ppFileType,
            [Out, MarshalAs(U2)] out ushort pnFileTypeCount);

        [PreserveSig]
        HResult GetSpecifyPropertyPages(
            [Out, MarshalAs(Interface)] out ISpecifyPropertyPages ppSpecifyPropPages,
            [Out, MarshalAs(IUnknown)] out object pppUnknowns,
            [Out, MarshalAs(U4)] out uint pcUnks);

        [PreserveSig]
        HResult GetCanonicalName(
            [Out, MarshalAs(LPWStr)] out string pwszPnPName,
            [In, MarshalAs(U2)] ushort nMaxChars);
    }

    [ComImport,
        Guid(NativeAPI.Guids.MediaDevices.IWMDMDevice3),
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IWMDMDevice3 : IWMDMDevice2
    {
        [PreserveSig]
        HResult GetProperty(
            [In, MarshalAs(LPWStr)] string pwszPropName,
            [Out] PropVariant pValue);

        [PreserveSig]
        HResult SetProperty(
            [In, MarshalAs(LPWStr)] string pwszPropName,
            [In] in PropVariant pValue);

        [PreserveSig]
        HResult GetFormatCapability(
            [In] FormatCode format,
            [Out] out FormatCapability pFormatSupport);

        [PreserveSig]
        HResult DeviceIoControl(
            [In, MarshalAs(U4)] uint dwIoControlCode,
            [In] char[] lpInBuffer,
            [In, MarshalAs(U4)] uint nInBufferSize,
            [Out] out char[] lpOutBuffer,
            [In, Out, MarshalAs(U4)] ref uint pnOutBufferSize);

        [PreserveSig]
        HResult FindStorage(
            [In] FindScope findScope,
            [In, MarshalAs(LPWStr)] string pwszUniqueID,
            [Out, MarshalAs(Interface)] out IWMDMStorage ppStorage);
    }
}
