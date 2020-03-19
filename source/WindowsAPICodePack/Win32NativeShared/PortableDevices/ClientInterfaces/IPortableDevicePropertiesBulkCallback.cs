//Copyright (c) Pierre Sprimont.  All rights reserved.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAPICodePack.Win32Native;
using Microsoft.WindowsAPICodePack.Win32Native.PortableDevices;

namespace Microsoft.WindowsAPICodePack.Win32Native.PortableDevices.PropertySystem
{
    [ComImport,
        Guid(Win32Native.Guids.PortableDevices.IPortableDevicePropertiesBulkCallback),
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IPortableDevicePropertiesBulkCallback
    {
        [PreserveSig]
        HResult OnStart(
            [In] ref Guid pContext);

        [PreserveSig]
        HResult OnProgress(
            [In] ref Guid pContext,
            [In, MarshalAs(UnmanagedType.Interface)] ref IPortableDeviceValuesCollection pResults);

        [PreserveSig]
        HResult OnEnd(
            [In] ref Guid pContext,
            [In] HResult hrStatus);
    }
}
