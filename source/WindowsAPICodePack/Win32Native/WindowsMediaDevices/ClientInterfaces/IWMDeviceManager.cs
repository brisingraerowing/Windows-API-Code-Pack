using Microsoft.WindowsAPICodePack.Win32Native;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Microsoft.WindowsAPICodePack.Win32Native.MediaDevices
{
    [ComImport,
        Guid(Win32Native.Guids.MediaDevices.IWMDeviceManager),
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IWMDeviceManager

    {
        [PreserveSig]
        HResult GetRevision(
            [Out] out uint pdwRevision);

        [PreserveSig]
        HResult GetDeviceCount(
            [Out] out uint pdwCount) ;

        [PreserveSig]
        HResult EnumDevices(
            [Out, MarshalAs(UnmanagedType.Interface)] out IWMDMEnumDevice ppEnumDevice);
    }

    [ComImport,
        Guid(Win32Native.Guids.MediaDevices.IWMDeviceManager2)]
    public interface IWMDeviceManager2 : IWMDeviceManager

    {
        [PreserveSig]
        HResult GetDeviceFromCanonicalName(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pwszCanonicalName,
            [Out, MarshalAs(UnmanagedType.Interface)] out IWMDMDevice ppDevice);

        [PreserveSig]
        HResult EnumDevices2(
            [Out, MarshalAs(UnmanagedType.Interface)] out IWMDMEnumDevice ppEnumDevice);

        [PreserveSig]
        HResult Reinitialize();

    }

    [ComImport,
        Guid(Win32Native.Guids.MediaDevices.IWMDeviceManager3)]
    public interface IWMDeviceManager3 : IWMDeviceManager2

    {
        [PreserveSig]
        HResult SetDeviceEnumPreference(
            [In] uint dwEnumPref);

    }
}
