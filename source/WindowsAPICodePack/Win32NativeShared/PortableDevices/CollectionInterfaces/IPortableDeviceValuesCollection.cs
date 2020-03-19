//Copyright (c) Pierre Sprimont.  All rights reserved.

using Microsoft.WindowsAPICodePack.Win32Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.WindowsAPICodePack.Win32Native.PortableDevices.PropertySystem
{
    [ComImport,
        Guid(Win32Native.Guids.PortableDevices.IPortableDeviceValuesCollection),
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
