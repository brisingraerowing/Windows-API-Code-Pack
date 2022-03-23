//Copyright (c) Pierre Sprimont.  All rights reserved.

using Microsoft.WindowsAPICodePack.Win32Native;

using System;
using System.Runtime.InteropServices;
using System.Text;

using static System.Runtime.InteropServices.UnmanagedType;

namespace Microsoft.WindowsAPICodePack.COMNative.MediaDevices
{
    [ComImport,
        Guid(NativeAPI.Guids.MediaDevices.IMDSPObject),
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IMDSPObject
    {
        [PreserveSig]
        HResult Open(
            [In, MarshalAs(U2)] ushort fuMode);

        [PreserveSig]
        HResult Read(
            [Out] out StringBuilder pData,
            [Out, In, MarshalAs(U4)] ref uint pdwSize,
            [Out, In] ref StringBuilder abMac);

        [PreserveSig]
        HResult Write(
            [In] ref StringBuilder pData,
            [Out, In, MarshalAs(U4)] ref uint pdwSize,
            [Out, In] ref StringBuilder abMac);

        [PreserveSig]
        HResult Delete(
            [In, MarshalAs(U2)] ushort fuMode,
            [In, MarshalAs(Interface)] ref IWMDMProgress pProgress);

        [PreserveSig]
        HResult Seek(
            [In, MarshalAs(U2)] ushort fuFlags,
            [In, MarshalAs(U4)] uint dwOffset);

        [PreserveSig]
        HResult Rename(
            [In, MarshalAs(LPWStr)] string pwszNewName,
            [In, MarshalAs(Interface)] ref IWMDMProgress pProgress);

        [PreserveSig]
        HResult Move(
            [In, MarshalAs(U2)] ushort fuMode,
            [In, MarshalAs(Interface)] ref IWMDMProgress pProgress,
            [In, MarshalAs(Interface)] ref IMDSPStorage pTarget);

        [PreserveSig]
        HResult Close();
    }

    [ComImport,
        Guid(NativeAPI.Guids.MediaDevices.IMDSPObject2),
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IMDSPObject2 : IMDSPObject

    {
        [PreserveSig]
        HResult ReadOnClearChannel(
            [Out] out StringBuilder pData,
            [Out, In, MarshalAs(U4)] ref uint pdwSize);

        [PreserveSig]
        HResult WriteOnClearChannel(
            [In] ref StringBuilder pData,
            [Out, In, MarshalAs(U4)] ref uint pdwSize);

    }
}
