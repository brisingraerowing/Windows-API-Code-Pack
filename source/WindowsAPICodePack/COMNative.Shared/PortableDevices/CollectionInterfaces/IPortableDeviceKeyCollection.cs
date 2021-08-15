//Copyright (c) Pierre Sprimont.  All rights reserved.

using Microsoft.WindowsAPICodePack.PropertySystem;
using Microsoft.WindowsAPICodePack.Win32Native;

using System;
using System.Runtime.InteropServices;

using GuidAttribute = System.Runtime.InteropServices.GuidAttribute;

namespace Microsoft.WindowsAPICodePack.COMNative.PortableDevices.PropertySystem
{
    [ComImport,
    Guid(NativeAPI.Guids.PortableDevices.IPortableDeviceKeyCollection),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IPortableDeviceKeyCollection
    {
        [PreserveSig]
        HResult GetCount(
            [In] ref uint pcElems);

        [PreserveSig]
        HResult GetAt(
            [In] uint dwIndex,
            [In] ref PropertyKey pKey);

        [PreserveSig]
        HResult Add(
            [In] ref PropertyKey Key);

        [PreserveSig]
        HResult Clear();

        [PreserveSig]
        HResult RemoveAt(
            [In] uint dwIndex);
    }
}
