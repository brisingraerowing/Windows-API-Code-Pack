using Microsoft.WindowsAPICodePack.Win32Native.Core;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Microsoft.WindowsAPICodePack.Win32Native.MediaDevices.ClientInterfaces
{
    [ComImport,
        Guid(Guids.MediaDevices.IWMDMEnumStorage),
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IWMDMEnumStorage
    {
        HResult Next(
            [In] uint celt,
            [Out, MarshalAs(UnmanagedType.Interface)] out IWMDMStorage ppStorage,
            [Out] out uint pceltFetched);
        
        HResult  Skip(
            [In] uint celt,
            [Out] out uint pceltFetched);
        
        HResult Reset();
        
        HResult Clone(
            [Out,MarshalAs(UnmanagedType.Interface)] IWMDMEnumStorage ppEnumStorage);
    }
}
