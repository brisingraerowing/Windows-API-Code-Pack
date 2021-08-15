//Copyright (c) Pierre Sprimont.  All rights reserved.

using Microsoft.WindowsAPICodePack.Win32Native;

using System;
using System.Runtime.InteropServices;

namespace Microsoft.WindowsAPICodePack.COMNative.PortableDevices
{
    [ComImport,
    Guid(NativeAPI.Guids.PortableDevices.IPortableDeviceDataStream)]
    public interface IPortableDeviceDataStream : System.Runtime.InteropServices.ComTypes.IStream
    {
        [PreserveSig]
        HResult GetObjectID(
            [Out, MarshalAs(UnmanagedType.LPWStr)] out string ppszObjectID);

        [PreserveSig]
        HResult Cancel();
    }
}
