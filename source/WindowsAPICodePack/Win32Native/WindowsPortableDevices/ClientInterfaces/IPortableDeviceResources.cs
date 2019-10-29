using Microsoft.WindowsAPICodePack.Win32Native.Shell.PropertySystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAPICodePack.Win32Native.PortableDevices.CollectionInterfaces;
using Microsoft.WindowsAPICodePack.Win32Native.Core;

namespace Microsoft.WindowsAPICodePack.Win32Native.PortableDevices.ClientInterfaces
{
    [ComImport,
        Guid(WPDCOMGuids.IPortableDeviceResources),
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IPortableDeviceResources
    {
        HResult GetSupportedResources([MarshalAs(UnmanagedType.LPWStr)] ref string pszObjectID, [MarshalAs(UnmanagedType.Interface)] ref IPortableDeviceKeyCollection ppKeys);

        HResult GetResourceAttributes([MarshalAs(UnmanagedType.LPWStr)] ref string pszObjectID, ref PropertyKey Key, [MarshalAs(UnmanagedType.Interface)] ref IPortableDeviceValues ppResourceAttributes);

        HResult GetStream([MarshalAs(UnmanagedType.LPWStr)] ref string pszObjectID, ref PropertyKey Key, uint dwMode, uint pdwOptimalBufferSize, [MarshalAs(UnmanagedType.Interface)] ref System.Runtime.InteropServices.ComTypes.IStream ppStream);

        HResult Delete([MarshalAs(UnmanagedType.LPWStr)] ref string pszObjectID, [MarshalAs(UnmanagedType.Interface)] ref IPortableDeviceKeyCollection pKeys);

        HResult Cancel();

        HResult CreateResource([MarshalAs(UnmanagedType.Interface)] ref IPortableDeviceValues pResourceAttributes, [MarshalAs(UnmanagedType.Interface)] ref System.Runtime.InteropServices.ComTypes.IStream ppData, ref uint pdwOptimalWriteBufferSize, [MarshalAs(UnmanagedType.LPWStr)] ref string ppszCookie);
    }
}
