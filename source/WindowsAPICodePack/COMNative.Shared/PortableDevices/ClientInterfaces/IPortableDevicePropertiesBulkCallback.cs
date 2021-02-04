//Copyright (c) Pierre Sprimont.  All rights reserved.

using System;
using System.Runtime.InteropServices;

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
            [In, MarshalAs(UnmanagedType.Interface)]
#if !WAPICP3
ref
#endif
         IPortableDeviceValuesCollection pResults);

        [PreserveSig]
        HResult OnEnd(
            [In] ref Guid pContext,
            [In] HResult hrStatus);
    }
}
