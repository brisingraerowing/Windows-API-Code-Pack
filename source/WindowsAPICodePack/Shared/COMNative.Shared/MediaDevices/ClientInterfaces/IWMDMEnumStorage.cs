//Copyright (c) Pierre Sprimont.  All rights reserved.

using Microsoft.WindowsAPICodePack.Win32Native;

using System;
using System.Runtime.InteropServices;

using static System.Runtime.InteropServices.UnmanagedType;

namespace Microsoft.WindowsAPICodePack.COMNative.MediaDevices
{
    [ComImport,
        Guid(NativeAPI.Guids.MediaDevices.IWMDMEnumStorage),
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IWMDMEnumStorage
    {
        [PreserveSig]
        HResult Next(
            [In, MarshalAs(U4)] uint celt,
            [Out, MarshalAs(Interface)] out IWMDMStorage ppStorage,
            [Out, MarshalAs(U4)] out uint pceltFetched);

        [PreserveSig]
        HResult Skip(
            [In, MarshalAs(U4)] uint celt,
            [Out, MarshalAs(U4)] out uint pceltFetched);

        [PreserveSig]
        HResult Reset();

        [PreserveSig]
        HResult Clone(
            [Out, MarshalAs(Interface)] IWMDMEnumStorage ppEnumStorage);
    }
}
