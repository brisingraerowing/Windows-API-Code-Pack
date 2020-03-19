//Copyright (c) Pierre Sprimont.  All rights reserved.

using Microsoft.WindowsAPICodePack.Win32Native;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Microsoft.WindowsAPICodePack.Win32Native.MediaDevices
{
    [ComImport,
        Guid(Guids.MediaDevices.IWMDMEnumStorage),
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IWMDMEnumStorage
    {
        [PreserveSig]
        HResult Next(
            [In] uint celt,
            [Out, MarshalAs(UnmanagedType.Interface)] out IWMDMStorage ppStorage,
            [Out] out uint pceltFetched);

        [PreserveSig]
        HResult  Skip(
            [In] uint celt,
            [Out] out uint pceltFetched);

        [PreserveSig]
        HResult Reset();

        [PreserveSig]
        HResult Clone(
            [Out,MarshalAs(UnmanagedType.Interface)] IWMDMEnumStorage ppEnumStorage);
    }
}
