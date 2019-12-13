using Microsoft.WindowsAPICodePack.Win32Native.Core;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Microsoft.WindowsAPICodePack.Win32Native.WindowsMediaDevices.ClientInterfaces
{
    [ComImport,
        Guid(Win32Native.Guids.MediaDevices.IWMDeviceManager),
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IWMDeviceManager

    {
        HResult GetRevision(
            [Out] out uint pdwRevision);
        
        HResult GetDeviceCount(
            [Out] out uint pdwCount) ;
        
        HResult EnumDevices(
            [Out, MarshalAs(UnmanagedType.Interface)] out IWMDMEnumDevice ppEnumDevice);
    }

    [ComImport,
        Guid(Win32Native.Guids.MediaDevices.IWMDeviceManager2)]
    public interface IWMDeviceManager2 : IWMDeviceManager

    {
        HResult GetDeviceFromCanonicalName(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pwszCanonicalName,
            [Out, MarshalAs(UnmanagedType.Interface)] out IWMDMDevice ppDevice);
        
        HResult EnumDevices2(
            [Out, MarshalAs(UnmanagedType.Interface)] out IWMDMEnumDevice ppEnumDevice);
        
        HResult Reinitialize();

    }

    [ComImport,
        Guid(Win32Native.Guids.MediaDevices.IWMDeviceManager3)]
    public interface IWMDeviceManager3 : IWMDeviceManager2

    {
        HResult SetDeviceEnumPreference(
            [In] uint dwEnumPref);

    }
}
