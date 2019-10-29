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
        Guid(WPDCOMGuids.IPortableDeviceContent2)]
    public interface IPortableDeviceContent2 : IPortableDeviceContent
    {
        HResult UpdateObjectWithPropertiesAndData([MarshalAs(UnmanagedType.LPWStr)] ref string pszObjectID, [MarshalAs(UnmanagedType.Interface)] ref IPortableDeviceValues pProperties, [MarshalAs(UnmanagedType.Interface)] ref System.Runtime.InteropServices.ComTypes.IStream ppData, ref uint pdwOptimalWriteBufferSize);
    }
}
