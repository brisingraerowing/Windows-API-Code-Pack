using Microsoft.WindowsAPICodePack.Win32Native.Core;
using Microsoft.WindowsAPICodePack.Win32Native.Core.COM;
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
        HResult GetName(
            [Out, MarshalAs(UnmanagedType.LPWStr)] out string pwszName,
            [In] ushort nMaxChars);

        HResult GetManufacturer(
            [Out, MarshalAs(UnmanagedType.LPWStr)] out string pwszName,
            [In] ushort nMaxChars);

        HResult GetVersion(
            [Out] out uint pdwVersion);

        HResult GetType(
            [Out] out uint pdwType);

        HResult GetSerialNumber(
            [Out] out WMDMID pSerialNumber,
            [Out, In] ref StringBuilder abMac);

        HResult GetPowerSource(
            [Out] out uint pdwPowerSource,
            [Out] out uint pdwPercentRemaining);

        HResult GetStatus(
            [Out] uint pdwStatus);

        HResult GetDeviceIcon(
            [Out] out uint hIcon);

        HResult EnumStorage(
            [Out, MarshalAs(UnmanagedType.Interface)] out IWMDMEnumStorage ppEnumStorage);

        HResult GetFormatSupport(
            [Out] out WaveFormatEx ppFormatEx,
            [Out] out ushort pnFormatCount,
            [Out, MarshalAs(UnmanagedType.LPWStr)] out string pppwszMimeType,
            [Out] out ushort pnMimeTypeCount);
        
        HResult SendOpaqueCommand(
            [Out, In] ref OpaqueCommand pCommand);
    }

    public interface IWMDMDevice2 : IWMDMDevice

    {
        HResult GetStorage(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pszStorageName,
            [Out,MarshalAs(UnmanagedType.Interface)] out IWMDMStorage ppStorage);
        
        HResult GetFormatSupport2(
            [In] uint dwFlags,
            [Out] out WaveFormatEx ppAudioFormatEx,
            [Out] out ushort pnAudioFormatCount,
            [Out] out VideoInfoHeader ppVideoFormatEx,
            [Out] out ushort pnVideoFormatCount,
            [Out] out FileCapabilities ppFileType,
            [Out] out ushort pnFileTypeCount);
        
        HResult GetSpecifyPropertyPages(
            [Out,MarshalAs(UnmanagedType.Interface)] out ISpecifyPropertyPages ppSpecifyPropPages,
            [Out, MarshalAs(UnmanagedType.IUnknown)] out object pppUnknowns,
            [Out] out uint pcUnks);
        
        HResult GetCanonicalName(
            [Out, MarshalAs(UnmanagedType.LPWStr)] out string pwszPnPName,
            [In] ushort nMaxChars);

    }

    public interface IWMDMDevice3 : IWMDMDevice2

    {
        HResult GetProperty(
            [In,MarshalAs(UnmanagedType.LPWStr)] string pwszPropName,
            [Out] out PropVariant pValue);
        
        HResult SetProperty(
            [In,MarshalAs(UnmanagedType.LPWStr)] string pwszPropName,
            [In] in PropVariant pValue);

        HResult GetFormatCapability(
            [In] FormatCode format,
            [Out] out FormatCapability pFormatSupport);
        
        HResult DeviceIoControl(
            [In] uint dwIoControlCode,
            [In] char[] lpInBuffer,
            [In] uint nInBufferSize,
            [Out] out char[] lpOutBuffer,
            [In,Out] ref uint pnOutBufferSize);
        
        HResult FindStorage(
            [In] FindScope findScope,
            [In, MarshalAs(UnmanagedType.LPWStr)] string pwszUniqueID,
            [Out, MarshalAs(UnmanagedType.Interface)] out IWMDMStorage ppStorage);

    }
}
