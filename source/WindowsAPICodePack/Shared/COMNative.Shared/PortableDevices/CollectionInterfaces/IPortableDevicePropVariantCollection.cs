//Copyright (c) Pierre Sprimont.  All rights reserved.

using Microsoft.WindowsAPICodePack.Win32Native;
using Microsoft.WindowsAPICodePack.Win32Native.PropertySystem;

using System;
using System.Runtime.InteropServices;

using GuidAttribute = System.Runtime.InteropServices.GuidAttribute;

namespace Microsoft.WindowsAPICodePack.COMNative.PortableDevices.PropertySystem
{
    [ComImport,
    Guid(NativeAPI.Guids.PortableDevices.IPortableDevicePropVariantCollection),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IPortableDevicePropVariantCollection
    {
        [PreserveSig]
        HResult GetCount(
            [In] ref uint pcElems);

        [PreserveSig]
        HResult GetAt(
            [In] uint dwIndex, 
            [In] PropVariant pValue);

        [PreserveSig]
        HResult Add(
            [In] PropVariant pValue);

        [PreserveSig]
        HResult GetType(
            [Out] out VarEnum pvt);

        [PreserveSig]
        HResult ChangeType(
            [In] VarEnum vt);

        [PreserveSig]
        HResult Clear();

        [PreserveSig]
        HResult RemoveAt(
            [In] uint dwIndex);
    }
}
