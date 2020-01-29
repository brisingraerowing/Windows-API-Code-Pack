using Microsoft.WindowsAPICodePack.Win32Native;
using Microsoft.WindowsAPICodePack.Win32Native.COM;
using MS.WindowsAPICodePack.Win32Native.Shell.PropertySystem;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Microsoft.WindowsAPICodePack.Win32Native.MediaDevices
{
    [ComImport,
        Guid(Win32Native.Guids.MediaDevices.IWMDMDevice),
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IWMDMDevice
    {
        [PreserveSig]
        HResult GetName(
            [Out, MarshalAs(UnmanagedType.LPWStr)] out string pwszName,
            [In] ushort nMaxChars);

        [PreserveSig]
        HResult GetManufacturer(
            [Out, MarshalAs(UnmanagedType.LPWStr)] out string pwszName,
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
            [Out, In] ref StringBuilder abMac);

        [PreserveSig]
        HResult GetPowerSource(
            [Out] out uint pdwPowerSource,
            [Out] out uint pdwPercentRemaining);

        [PreserveSig]
        HResult GetStatus(
            [Out] uint pdwStatus);

        [PreserveSig]
        HResult GetDeviceIcon(
            [Out] out uint hIcon);

        [PreserveSig]
        HResult EnumStorage(
            [Out, MarshalAs(UnmanagedType.Interface)] out IWMDMEnumStorage ppEnumStorage);

        [PreserveSig]
        HResult GetFormatSupport(
            [Out] out WaveFormatEx ppFormatEx,
            [Out] out ushort pnFormatCount,
            [Out, MarshalAs(UnmanagedType.LPWStr)] out string pppwszMimeType,
            [Out] out ushort pnMimeTypeCount);

        [PreserveSig]
        HResult SendOpaqueCommand(
            [Out, In] ref OpaqueCommand pCommand);
    }

    public interface IWMDMDevice2 : IWMDMDevice

    {
        [PreserveSig]
        HResult GetStorage(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pszStorageName,
            [Out,MarshalAs(UnmanagedType.Interface)] out IWMDMStorage ppStorage);

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
            [Out,MarshalAs(UnmanagedType.Interface)] out ISpecifyPropertyPages ppSpecifyPropPages,
            [Out, MarshalAs(UnmanagedType.IUnknown)] out object pppUnknowns,
            [Out] out uint pcUnks);

        [PreserveSig]
        HResult GetCanonicalName(
            [Out, MarshalAs(UnmanagedType.LPWStr)] out string pwszPnPName,
            [In] ushort nMaxChars);

    }

    public interface IWMDMDevice3 : IWMDMDevice2

    {
        [PreserveSig]
        HResult GetProperty(
            [In,MarshalAs(UnmanagedType.LPWStr)] string pwszPropName,
            [Out] out PropVariant pValue);

        [PreserveSig]
        HResult SetProperty(
            [In,MarshalAs(UnmanagedType.LPWStr)] string pwszPropName,
            [In] in PropVariant pValue);

        [PreserveSig]
        HResult GetFormatCapability(
            [In] FormatCode format,
            [Out] out FormatCapability pFormatSupport);

        [PreserveSig]
        HResult DeviceIoControl(
            [In] uint dwIoControlCode,
            [In] char[] lpInBuffer,
            [In] uint nInBufferSize,
            [Out] out char[] lpOutBuffer,
            [In,Out] ref uint pnOutBufferSize);

        [PreserveSig]
        HResult FindStorage(
            [In] FindScope findScope,
            [In, MarshalAs(UnmanagedType.LPWStr)] string pwszUniqueID,
            [Out, MarshalAs(UnmanagedType.Interface)] out IWMDMStorage ppStorage);

    }
}
