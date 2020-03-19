//Copyright (c) Pierre Sprimont.  All rights reserved.

using Microsoft.WindowsAPICodePack.Win32Native;
using Microsoft.WindowsAPICodePack.Win32Native.PortableDevices.PropertySystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.WindowsAPICodePack.Win32Native.PortableDevices
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
