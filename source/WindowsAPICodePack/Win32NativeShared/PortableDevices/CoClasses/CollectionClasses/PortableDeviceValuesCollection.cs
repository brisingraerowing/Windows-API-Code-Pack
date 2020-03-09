using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using GuidAttribute = System.Runtime.InteropServices.GuidAttribute;

namespace Microsoft.WindowsAPICodePack.Win32Native.PortableDevices.PropertySystem
{
    [ComImport,
        Guid(Guids.PortableDevices.PortableDeviceValuesCollection),
        ClassInterface(ClassInterfaceType.None),
        TypeLibType(TypeLibTypeFlags.FCanCreate)]
    public class PortableDeviceValuesCollection : IPortableDeviceValuesCollection
    {
        [PreserveSig]
        public extern virtual HResult GetCount([In] ref uint pcElems) ;
        [PreserveSig]
        public extern virtual HResult GetAt([In] uint dwIndex, [MarshalAs(UnmanagedType.Interface), Out] out IPortableDeviceValues ppValues) ;
        [PreserveSig]
        public extern virtual HResult Add([In, MarshalAs(UnmanagedType.Interface)] ref IPortableDeviceValues pValues) ;
        [PreserveSig]
        public extern virtual HResult Clear() ;
        [PreserveSig]
        public extern virtual HResult RemoveAt([In] uint dwIndex) ; 
    }
}
