//Copyright (c) Pierre Sprimont.  All rights reserved.

using Microsoft.WindowsAPICodePack.Win32Native;

using System;
using System.Runtime.InteropServices;

namespace Microsoft.WindowsAPICodePack.COMNative.MediaDevices
{
    [ComImport,
        Guid(NativeAPI.Guids.MediaDevices.IWMDMRevoked),
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IWMDMRevoked
    {
        [PreserveSig]
        HResult GetRevocationURL(
            [In, Out, MarshalAs(UnmanagedType.LPWStr)] ref string ppwszRevocationURL,
            [In, Out, MarshalAs(UnmanagedType.U4)] ref uint pdwBufferLen,
            [Out, MarshalAs(UnmanagedType.U4)] out uint pdwRevokedBitFlag);
    }
}
