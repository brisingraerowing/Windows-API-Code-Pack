using Microsoft.WindowsAPICodePack.Win32Native.Core;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Microsoft.WindowsAPICodePack.Win32Native.MediaDevices.ClientInterfaces
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
            [Out, In] ref char[] abMac);

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
            [Out] out WAVEFORMATEX ppFormatEx,
            [Out] out ushort pnFormatCount,
            [Out, MarshalAs(UnmanagedType.LPWStr)] out string pppwszMimeType,
            [Out] ushort pnMimeTypeCount);
        
        HResult SendOpaqueCommand(
            [Out, In] ref OPAQUECOMMAND pCommand);
    }
}
