//Copyright (c) Pierre Sprimont.  All rights reserved.

using Microsoft.WindowsAPICodePack.Win32Native;

using System;
using System.Runtime.InteropServices;

namespace Microsoft.WindowsAPICodePack.COMNative.MediaDevices
{
    [ComImport,
        Guid(NativeAPI.Guids.MediaDevices.IMDSPRevoked),
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IMDSPRevoked
    {
        [PreserveSig]
        HResult GetRevocationURL(
            [Out, In, MarshalAs(UnmanagedType.LPWStr)] ref string ppwszRevocationURL,
            [Out, In, MarshalAs(UnmanagedType.U4)] ref uint pdwBufferLen);
    }
}
