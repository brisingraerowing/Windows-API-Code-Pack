using Microsoft.WindowsAPICodePack.Win32Native;
using Microsoft.WindowsAPICodePack.Win32Native.PortableDevices.PropertySystem;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Microsoft.WindowsAPICodePack.Win32Native.PortableDevices
{
    [ComImport,
        Guid(Guids.PortableDevices.IWpdSerializer),
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IWpdSerializer
    {
        HResult GetIPortableDeviceValuesFromBuffer(
            [In] ref StringBuilder pBuffer,
            [In] uint dwInputBufferLength,
            [Out] out IPortableDeviceValues ppParams);

        HResult WriteIPortableDeviceValuesToBuffer(
            [In] uint dwOutputBufferLength,
            [In] ref IPortableDeviceValues pResults,
            [Out] out StringBuilder pBuffer,
            [Out] out uint pdwBytesWritten);
        
        HResult GetBufferFromIPortableDeviceValues(
            [In] ref IPortableDeviceValues pSource,
            [Out] out StringBuilder ppBuffer,
            [Out] out uint pdwBufferSize);
        
        HResult GetSerializedSize(
            [In] ref IPortableDeviceValues pSource,
            [Out] out uint pdwSize);

    }
}
