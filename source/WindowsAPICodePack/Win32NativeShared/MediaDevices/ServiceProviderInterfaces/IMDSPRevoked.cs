//Copyright (c) Pierre Sprimont.  All rights reserved.

using Microsoft.WindowsAPICodePack.Win32Native;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Microsoft.WindowsAPICodePack. Win32Native.MediaDevices
{
    [ComImport,
        Guid(Guids.MediaDevices.IMDSPRevoked),
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IMDSPRevoked
    {
        [PreserveSig]
        HResult GetRevocationURL(
            [Out,In,MarshalAs(UnmanagedType.LPWStr)] ref string ppwszRevocationURL,
            [Out,In] ref uint pdwBufferLen);
    }
}
