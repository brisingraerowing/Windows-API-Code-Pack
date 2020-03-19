//Copyright (c) Pierre Sprimont.  All rights reserved.

using Microsoft.WindowsAPICodePack.Win32Native;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Microsoft.WindowsAPICodePack. Win32Native.MediaDevices
{
    [ComImport,
        Guid(Guids.MediaDevices.IWMDMRevoked),
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IWMDMRevoked
    {
        [PreserveSig]
        HResult GetRevocationURL(
            [In,Out,MarshalAs(UnmanagedType.LPWStr)] ref string ppwszRevocationURL,
            [In,Out] ref uint pdwBufferLen,
            [Out] out uint pdwRevokedBitFlag);
    }
}
