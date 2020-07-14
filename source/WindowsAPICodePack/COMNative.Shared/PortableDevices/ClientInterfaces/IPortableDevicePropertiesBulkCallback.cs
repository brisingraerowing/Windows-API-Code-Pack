//Copyright (c) Pierre Sprimont.  All rights reserved.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAPICodePack.COMNative;
using Microsoft.WindowsAPICodePack.COMNative.PortableDevices;
using Microsoft.WindowsAPICodePack.Win32Native;

namespace Microsoft.WindowsAPICodePack.COMNative.PortableDevices.PropertySystem
{
    [ComImport,
        Guid(NativeAPI.Guids.PortableDevices.IPortableDevicePropertiesBulkCallback),
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
