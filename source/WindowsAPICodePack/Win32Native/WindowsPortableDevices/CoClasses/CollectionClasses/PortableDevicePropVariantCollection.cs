using Microsoft.WindowsAPICodePack.Win32Native.PortableDevices.PropertySystem;
using MS.WindowsAPICodePack.Win32Native.Shell.PropertySystem;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace Microsoft.WindowsAPICodePack.Win32Native.PortableDevices.PropertySystem
{
    [ComImport,
        Guid(Guids.PortableDevices.PortableDevicePropVariantCollection),
        ClassInterface(ClassInterfaceType.None),
        TypeLibType(TypeLibTypeFlags.FCanCreate)]
    public class PortableDevicePropVariantCollection : IPortableDevicePropVariantCollection
    {
        [PreserveSig]
        public extern HResult GetCount([In] ref uint pcElems);
        [PreserveSig]
        public extern HResult GetAt([In] uint dwIndex, [In] ref PropVariant pValue);
        [PreserveSig]
        public extern HResult Add([In] ref PropVariant pValue);
        [PreserveSig]
        public extern HResult GetType([Out] out ushort pvt);
        [PreserveSig]
        public extern HResult ChangeType([In] ushort vt);
        [PreserveSig]
        public extern HResult Clear();
        [PreserveSig]
        public extern HResult RemoveAt([In] uint dwIndex);
    }
}
