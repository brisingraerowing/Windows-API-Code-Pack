using Microsoft.WindowsAPICodePack.Win32Native;
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
        HResult SeekInUnits(
            [In] long dlibMove,
            [In] StreamUnits units,
            [In] uint dwOrigin,
            [In, Out] ref ulong plibNewPosition);
    }
}
