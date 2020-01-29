using Microsoft.WindowsAPICodePack.Win32Native;
using Microsoft.WindowsAPICodePack.Win32Native.Shell.PropertySystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using GuidAttribute = System.Runtime.InteropServices.GuidAttribute;

namespace Microsoft.WindowsAPICodePack.Win32Native.PortableDevices.PropertySystem
{
    [ComImport,
        Guid(Win32Native.Guids.PortableDevices.IPortableDeviceKeyCollection),
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IPortableDeviceKeyCollection
    {
        [PreserveSig]
        HResult GetCount(
            [In] ref uint pcElems);

        [PreserveSig]
        HResult GetAt(
            [In] uint dwIndex,
            [In] ref PropertyKey pKey);

        [PreserveSig]
        HResult Add(
            [In] ref PropertyKey Key);

        [PreserveSig]
        HResult Clear();

        [PreserveSig]
        HResult RemoveAt(
            [In] uint dwIndex);
    }
}
