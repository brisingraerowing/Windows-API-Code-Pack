//Copyright (c) Pierre Sprimont.  All rights reserved.

using Microsoft.WindowsAPICodePack.Win32Native;

using System;
using System.Runtime.InteropServices;

using static System.Runtime.InteropServices.UnmanagedType;

namespace Microsoft.WindowsAPICodePack.COMNative.MediaDevices
{
    [ComImport,
        Guid(NativeAPI.Guids.MediaDevices.IMDServiceProvider),
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IMDServiceProvider
    {
        [PreserveSig]
        HResult GetDeviceCount(
            [Out, MarshalAs(U4)] out uint pdwCount);

        [PreserveSig]
        HResult EnumDevices(
            [Out, MarshalAs(Interface)] out IMDSPEnumDevice ppEnumDevice);
    }

    [ComImport,
        Guid(NativeAPI.Guids.MediaDevices.IMDServiceProvider2),
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IMDServiceProvider2 : IMDServiceProvider
    {
        [PreserveSig]
        HResult CreateDevice(
            [In, MarshalAs(LPWStr)] string pwszDevicePath,
            [Out, MarshalAs(U4)] out uint pdwCount,
            [Out, MarshalAs(Interface)] out IMDSPDevice pppDeviceArray);
    }

    [ComImport,
        Guid(NativeAPI.Guids.MediaDevices.IMDServiceProvider3),
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IMDServiceProvider3 : IMDServiceProvider2
    {
        [PreserveSig]
        HResult SetDeviceEnumPreference(
            [In, MarshalAs(U4)] uint dwEnumPref);
    }
}
