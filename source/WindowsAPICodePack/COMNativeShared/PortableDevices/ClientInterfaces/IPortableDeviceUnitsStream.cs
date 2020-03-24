//Copyright (c) Pierre Sprimont.  All rights reserved.

using Microsoft.WindowsAPICodePack.COMNative;
using Microsoft.WindowsAPICodePack.COMNative.PortableDevices.PropertySystem;
using Microsoft.WindowsAPICodePack.Win32Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.WindowsAPICodePack.COMNative.PortableDevices
{
    [ComImport,
        Guid(Win32Native.Guids.PortableDevices.IPortableDeviceUnitsStream),
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IPortableDeviceUnitsStream
    {
        [PreserveSig]
        HResult SeekInUnits(
            [In] long dlibMove,
            [In] StreamUnitValues units,
            [In] uint dwOrigin,
            [In, Out] ref ulong plibNewPosition);
    }
}
