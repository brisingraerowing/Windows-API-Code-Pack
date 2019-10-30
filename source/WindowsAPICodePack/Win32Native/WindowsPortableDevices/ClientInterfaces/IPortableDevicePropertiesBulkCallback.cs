using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAPICodePack.Win32Native.Core;
using Microsoft.WindowsAPICodePack.Win32Native.PortableDevices.CollectionInterfaces;

namespace Microsoft.WindowsAPICodePack.Win32Native.PortableDevices.ClientInterfaces
{
    [ComImport,
        Guid(WPDCOMGuids.IPortableDevicePropertiesBulkCallback),
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IPortableDevicePropertiesBulkCallback
    {
        HResult OnStart(
            [In] Guid pContext);

        HResult OnProgress(
            [In] Guid pContext,
            [In, MarshalAs(UnmanagedType.Interface)] ref IPortableDeviceValuesCollection pResults);

        HResult OnEnd(
            [In] Guid pContext,
            [In] HResult hrStatus);
    }
}
