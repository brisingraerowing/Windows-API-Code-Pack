using Microsoft.WindowsAPICodePack.Win32Native.Core;
using Microsoft.WindowsAPICodePack.Win32Native.Shell.PropertySystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.WindowsAPICodePack.Win32Native.PortableDevices.CollectionInterfaces
{
    [ComImport,
        Guid(WPDCOMGuids.IPortableDeviceKeyCollection),
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IPortableDeviceKeyCollection
    {
        HResult GetCount(
            [In] ref uint pcElems);

        HResult GetAt(
            [In] uint dwIndex,
            [In] ref PropertyKey pKey);

        HResult Add(
            [In] ref PropertyKey Key);

        HResult Clear();

        HResult RemoveAt(
            [In] uint dwIndex);
    }
}
