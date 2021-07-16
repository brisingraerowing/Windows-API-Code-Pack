//Copyright (c) Pierre Sprimont.  All rights reserved.

using Microsoft.WindowsAPICodePack.Win32Native;

using System;
using System.Runtime.InteropServices;

using static System.Runtime.InteropServices.UnmanagedType;

namespace Microsoft.WindowsAPICodePack.COMNative.MediaDevices
{
    [ComImport,
        Guid(NativeAPI.Guids.MediaDevices.IWMDMObjectInfo),
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IWMDMObjectInfo
    {
        [PreserveSig]
        HResult GetPlayLength(
            [Out, MarshalAs(U4)] out uint pdwLength);

        [PreserveSig]
        HResult SetPlayLength(
            [In, MarshalAs(U4)] uint dwLength);

        [PreserveSig]
        HResult GetPlayOffset(
            [Out, MarshalAs(U4)] out uint pdwOffset);

        [PreserveSig]
        HResult SetPlayOffset(
            [In, MarshalAs(U4)] uint dwOffset);

        [PreserveSig]
        HResult GetTotalLength(
            [Out, MarshalAs(U4)] out uint pdwLength);

        [PreserveSig]
        HResult GetLastPlayPosition(
            [Out, MarshalAs(U4)] out uint pdwLastPos);

        [PreserveSig]
        HResult GetLongestPlayPosition(
            [Out, MarshalAs(U4)] out uint pdwLongestPos);
    }
}
