//Copyright (c) Pierre Sprimont.  All rights reserved.

using Microsoft.WindowsAPICodePack.COMNative;
using Microsoft.WindowsAPICodePack.Win32Native;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Microsoft.WindowsAPICodePack.COMNative.MediaDevices
{
    [ComImport,
        Guid(NativeAPI.Guids.MediaDevices.IMDServiceProvider),
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IMDServiceProvider
    {
        [PreserveSig]
        HResult GetDeviceCount(
            [Out] out uint pdwCount);

        [PreserveSig]
        HResult EnumDevices(
            [Out] out IMDSPEnumDevice ppEnumDevice);

    }

    public interface IMDServiceProvider2 : IMDServiceProvider

    {
        [PreserveSig]
        HResult CreateDevice(
            [In,MarshalAs(UnmanagedType.LPWStr)] string pwszDevicePath,
            [Out] out uint pdwCount,
            [Out] out IMDSPDevice pppDeviceArray);

    }

    public interface IMDServiceProvider3 : IMDServiceProvider2

    {
        [PreserveSig]
        HResult SetDeviceEnumPreference(
            [In] uint dwEnumPref);

    }
}
