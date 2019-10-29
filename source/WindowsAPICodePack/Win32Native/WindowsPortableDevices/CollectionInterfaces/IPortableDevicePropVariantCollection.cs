using Microsoft.WindowsAPICodePack.Win32Native.Core;
using MS.WindowsAPICodePack.Win32Native.Shell.PropertySystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.WindowsAPICodePack.Win32Native.PortableDevices.CollectionInterfaces
{
    [ComImport,
        Guid(WPDCOMGuids.IPortableDevicePropVariantCollection),
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IPortableDevicePropVariantCollection
    {
        HResult GetCount([In] ref uint pcElems);

        HResult GetAt([In] uint dwIndex, [In, Out] ref PropVariant pValue);

        HResult Add([In] ref PropVariant pValue);

        HResult GetType([Out] out ushort pvt);

        HResult ChangeType([In] ushort vt);

        HResult Clear();

        HResult RemoveAt([In] uint dwIndex);
    }
}
