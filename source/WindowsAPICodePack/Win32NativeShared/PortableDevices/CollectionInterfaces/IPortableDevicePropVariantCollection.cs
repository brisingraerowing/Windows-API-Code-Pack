using Microsoft.WindowsAPICodePack.Win32Native;
using Microsoft.WindowsAPICodePack.Win32Native.PropertySystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.WindowsAPICodePack.Win32Native.PortableDevices
{
    [ComImport,
        Guid(Win32Native.Guids.PortableDevices.IPortableDevicePropVariantCollection),
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IPortableDevicePropVariantCollection
    {
        [PreserveSig]
        HResult GetCount(
            [In] ref uint pcElems);

        [PreserveSig]
        HResult GetAt(
            [In] uint dwIndex, 
            [In] ref PropVariant pValue);

        [PreserveSig]
        HResult Add(
            [In] ref PropVariant pValue);

        [PreserveSig]
        HResult GetType(
            [Out] out ushort pvt);

        [PreserveSig]
        HResult ChangeType(
            [In] ushort vt);

        [PreserveSig]
        HResult Clear();

        [PreserveSig]
        HResult RemoveAt(
            [In] uint dwIndex);
    }
}
