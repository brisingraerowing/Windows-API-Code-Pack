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
        HResult OnStart(ref Guid pContext);

        HResult OnProgress(ref Guid pContext, [MarshalAs(UnmanagedType.Interface)] ref IPortableDeviceValuesCollection pResults);

        HResult OnEnd(ref Guid pContext, ref HResult hrStatus);
    }
}
