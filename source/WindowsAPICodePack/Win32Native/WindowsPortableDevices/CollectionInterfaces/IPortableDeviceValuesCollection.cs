using Microsoft.WindowsAPICodePack.Win32Native.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.WindowsAPICodePack.Win32Native.PortableDevices.CollectionInterfaces
{
    [ComImport,
        Guid(Win32Native.Guids.PortableDevices.IPortableDeviceValuesCollection),
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IPortableDeviceValuesCollection
    {
        HResult GetCount( 
            [In] ref uint pcElems);

        HResult GetAt(
            [In] uint dwIndex, 
            [Out, MarshalAs(UnmanagedType.Interface)] out IPortableDeviceValues ppValues);

        HResult Add(
            [In, MarshalAs(UnmanagedType.Interface)] ref IPortableDeviceValues pValues);

        HResult Clear();

        HResult RemoveAt(
            [In] uint dwIndex);
    }
}
