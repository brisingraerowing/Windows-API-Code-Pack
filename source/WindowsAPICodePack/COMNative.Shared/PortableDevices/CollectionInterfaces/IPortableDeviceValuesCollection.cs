//Copyright (c) Pierre Sprimont.  All rights reserved.

using Microsoft.WindowsAPICodePack.COMNative;
using Microsoft.WindowsAPICodePack.Win32Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.WindowsAPICodePack.COMNative.PortableDevices.PropertySystem
{
    [ComImport,
        Guid(NativeAPI.Guids.PortableDevices.IPortableDeviceValuesCollection),
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IPortableDeviceValuesCollection
    {
        [PreserveSig]
        HResult GetCount(
            [In] ref uint pcElems);

        [PreserveSig]
        HResult GetAt(
            [In] uint dwIndex,
            [Out, MarshalAs(UnmanagedType.Interface)] out IPortableDeviceValues ppValues);

        [PreserveSig]
        HResult Add(
            [In, MarshalAs(UnmanagedType.Interface)] ref IPortableDeviceValues pValues);

        [PreserveSig]
        HResult Clear();

        [PreserveSig]
        HResult RemoveAt(
            [In] uint dwIndex);
    }
}
