using Microsoft.WindowsAPICodePack.Win32Native.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.WindowsAPICodePack.Win32Native.PortableDevices.ClientInterfaces
{
    [ComImport,
        Guid(WPDCOMGuids.IPortableDeviceDataStream)]
    public interface IPortableDeviceDataStream : System.Runtime.InteropServices.ComTypes.IStream
    {
        HResult GetObjectID([MarshalAs(UnmanagedType.LPWStr)] ref string ppszObjectID);

        HResult Cancel();
    }
}
