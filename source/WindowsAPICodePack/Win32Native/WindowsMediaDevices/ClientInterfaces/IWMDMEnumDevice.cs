using Microsoft.WindowsAPICodePack.Win32Native.Core;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Microsoft.WindowsAPICodePack.Win32Native.MediaDevices
{
    [ComImport,
        Guid(Guids.MediaDevices.IWMDMEnumDevice),
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IWMDMEnumDevice
    {
        HResult Next(
            [In] uint celt,
            [Out,MarshalAs(UnmanagedType.Interface)] out IWMDMDevice ppDevice,
            [Out] out uint pceltFetched);
        
        HResult Skip(
            [In] uint celt,
            [Out] out uint pceltFetched);
        
        HResult Reset();
        
        HResult Clone(
           [Out, MarshalAs(UnmanagedType.Interface)] out IWMDMEnumDevice ppEnumDevice);
    }
}
