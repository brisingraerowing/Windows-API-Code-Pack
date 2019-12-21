using Microsoft.WindowsAPICodePack.Win32Native.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.WindowsAPICodePack.Win32Native.PortableDevices
{
    [ComImport,
        Guid(Win32Native.Guids.PortableDevices.IPortableDeviceDataStream)]
    public interface IPortableDeviceDataStream : System.Runtime.InteropServices.ComTypes.IStream
    {
        HResult GetObjectID(
            [Out, MarshalAs(UnmanagedType.LPWStr)] out string ppszObjectID);

        HResult Cancel();
    }
}
