using Microsoft.WindowsAPICodePack.Win32Native.Core;
using Microsoft.WindowsAPICodePack.Win32Native.Core.COM;
using MS.WindowsAPICodePack.Win32Native.Shell.PropertySystem;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Microsoft.WindowsAPICodePack. Win32Native.MediaDevices
{
    [ComImport,
        Guid(Guids.MediaDevices.IMDSPDevice),
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IMDSPDevice
    {
        HResult GetName(
            [Out, MarshalAs(UnmanagedType.LPWStr)] out string pwszName,
            [In] ushort nMaxChars);
        
        HResult GetManufacturer(
            [Out,MarshalAs(UnmanagedType.LPWStr)] out string pwszName,
            [In] ushort nMaxChars);
        
        HResult GetVersion(
            [Out] out uint pdwVersion);
        
        HResult GetType(
            [Out] out uint pdwType);
        
        HResult GetSerialNumber(
            [Out] out WMDMID pSerialNumber,
            [Out,In] ref StringBuilder abMac);

        HResult GetPowerSource(
            [Out] uint pdwPowerSource,
            [Out] uint pdwPercentRemaining);

        HResult GetStatus(
            [Out] uint pdwStatus);

        HResult GetDeviceIcon(
            [Out] uint hIcon);

        HResult EnumStorage(
            [Out] out IMDSPEnumStorage ppEnumStorage);

        HResult GetFormatSupport(
            [Out] out WaveFormatEx pFormatEx,
            [Out] out ushort pnFormatCount,
            [Out, MarshalAs(UnmanagedType.LPWStr)] out string pppwszMimeType,
            [Out] out ushort pnMimeTypeCount);

        HResult SendOpaqueCommand(
            [Out, In] ref OpaqueCommand pCommand);
    }

    public interface IMDSPDevice2 : IMDSPDevice

    {
        HResult GetStorage(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pszStorageName,
            [Out] out IMDSPStorage ppStorage);
        
        HResult GetFormatSupport2(
            [In] uint dwFlags,
            [Out] out WaveFormatEx ppAudioFormatEx,
            [Out] out ushort pnAudioFormatCount,
            [Out] out VideoInfoHeader ppVideoFormatEx,
            [Out] out ushort pnVideoFormatCount,
            [Out] out FileCapabilities ppFileType,
            [Out] out ushort pnFileTypeCount);
        
        HResult GetSpecifyPropertyPages(
            [Out] out ISpecifyPropertyPages ppSpecifyPropPages,
            [Out, MarshalAs(UnmanagedType.IUnknown)] out object pppUnknowns,
            [Out] out uint pcUnks);
        
        HResult GetCanonicalName(
            [Out, MarshalAs(UnmanagedType.LPWStr)] out string pwszPnPName,
            [In] ushort nMaxChars);

    }

    public interface IMDSPDevice3 : IMDSPDevice2

    {
        HResult GetProperty(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pwszPropName,
            [Out] out PropVariant pValue);
        
        HResult SetProperty(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pwszPropName,
            [In] in PropVariant pValue);

        HResult GetFormatCapability(
            [In] FormatCode format,
            [Out] out FormatCapability pFormatSupport);
        
        HResult DeviceIoControl(
            [In] uint dwIoControlCode,
            [In] ref StringBuilder lpInBuffer,
            [In] uint nInBufferSize,
            [Out] out StringBuilder lpOutBuffer,
            [Out, In] ref uint pnOutBufferSize);
        
        HResult FindStorage(
           [In] FindScope findScope,
            [In, MarshalAs(UnmanagedType.LPWStr)] string pwszUniqueID,
            [Out] out IMDSPStorage ppStorage);

    }
}
