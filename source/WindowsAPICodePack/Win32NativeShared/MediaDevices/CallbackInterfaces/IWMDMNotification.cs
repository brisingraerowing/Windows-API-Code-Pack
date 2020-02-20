﻿//Copyright (c) Pierre Sprimont.  All rights reserved.

using Microsoft.WindowsAPICodePack.Win32Native;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Microsoft.WindowsAPICodePack. Win32Native.MediaDevices
{
    [ComImport,
        Guid(Guids.MediaDevices.IWMDMNotification),
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IWMDMNotification
    {
        [PreserveSig]
        HResult WMDMMessage(
            [In] uint dwMessageType,
            [In,MarshalAs(UnmanagedType.LPWStr)] string pwszCanonicalName);
    }
}