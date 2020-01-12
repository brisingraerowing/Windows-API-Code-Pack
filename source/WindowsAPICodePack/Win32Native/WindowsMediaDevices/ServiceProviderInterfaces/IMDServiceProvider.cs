using Microsoft.WindowsAPICodePack.Win32Native;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Microsoft.WindowsAPICodePack. Win32Native.MediaDevices
{
    [ComImport,
        Guid(Guids.MediaDevices.IMDServiceProvider),
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IMDServiceProvider
    {
        HResult GetDeviceCount(
            [Out] out uint pdwCount);
        
        HResult EnumDevices(
            [Out] out IMDSPEnumDevice ppEnumDevice);

    }

    public interface IMDServiceProvider2 : IMDServiceProvider

    {
        HResult CreateDevice(
            [In,MarshalAs(UnmanagedType.LPWStr)] string pwszDevicePath,
            [Out] out uint pdwCount,
            [Out] out IMDSPDevice pppDeviceArray);

    }

    public interface IMDServiceProvider3 : IMDServiceProvider2

    {
        HResult SetDeviceEnumPreference(
            [In] uint dwEnumPref);

    }
}
