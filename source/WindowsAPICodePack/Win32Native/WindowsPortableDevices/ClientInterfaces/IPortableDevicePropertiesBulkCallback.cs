using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAPICodePack.Win32Native.Core;
using Microsoft.WindowsAPICodePack.Win32Native.PortableDevices;

namespace Microsoft.WindowsAPICodePack.Win32Native.PortableDevices
{
    [ComImport,
        Guid(Win32Native.Guids.PortableDevices.IPortableDevicePropertiesBulkCallback),
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IPortableDevicePropertiesBulkCallback
    {
        HResult OnStart(
            [In] ref Guid pContext);

        HResult OnProgress(
            [In] ref Guid pContext,
            [In, MarshalAs(UnmanagedType.Interface)] ref IPortableDeviceValuesCollection pResults);

        HResult OnEnd(
            [In] ref Guid pContext,
            [In] HResult hrStatus);
    }
}
