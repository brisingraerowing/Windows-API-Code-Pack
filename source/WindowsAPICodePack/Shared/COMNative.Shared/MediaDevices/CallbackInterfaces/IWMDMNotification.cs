//Copyright (c) Pierre Sprimont.  All rights reserved.

using Microsoft.WindowsAPICodePack.Win32Native;

using System;
using System.Runtime.InteropServices;

namespace Microsoft.WindowsAPICodePack.COMNative.MediaDevices
{
    [ComImport,
        Guid(NativeAPI.Guids.MediaDevices.IWMDMNotification),
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IWMDMNotification
    {
        [PreserveSig]
        HResult WMDMMessage(
            [In, MarshalAs(UnmanagedType.U4)] uint dwMessageType,
            [In, MarshalAs(UnmanagedType.LPWStr)] string pwszCanonicalName);
    }
}
