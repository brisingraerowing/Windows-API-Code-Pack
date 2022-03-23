//Copyright (c) Pierre Sprimont.  All rights reserved.

using Microsoft.WindowsAPICodePack.Win32Native;

using System;
using System.Runtime.InteropServices;
using System.Text;

using static System.Runtime.InteropServices.UnmanagedType;

namespace Microsoft.WindowsAPICodePack.COMNative.MediaDevices
{
    [ComImport,
        Guid(NativeAPI.Guids.MediaDevices.IWMDMOperation),
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IWMDMOperation
    {
        [PreserveSig]
        HResult BeginRead();

        [PreserveSig]
        HResult BeginWrite();

        [PreserveSig]
        HResult GetObjectName(
            [Out, MarshalAs(LPWStr)] out string pwszName,
            [In, MarshalAs(U2)] ushort nMaxChars);

        [PreserveSig]
        HResult SetObjectName(
            [In, MarshalAs(LPWStr)] string pwszName,
            [In, MarshalAs(U2)] ushort nMaxChars);

        [PreserveSig]
        HResult GetObjectAttributes(
            [Out, MarshalAs(U4)] out uint pdwAttributes,
            [Out, In] ref WaveFormatEx pFormat);

        [PreserveSig]
        HResult SetObjectAttributes(
            [In, MarshalAs(U4)] uint dwAttributes,
            [In] ref WaveFormatEx pFormat);

        [PreserveSig]
        HResult GetObjectTotalSize(
            [Out, MarshalAs(U4)] out uint pdwSize,
            [Out, MarshalAs(U4)] out uint pdwSizeHigh);

        [PreserveSig]
        HResult SetObjectTotalSize(
            [In, MarshalAs(U4)] uint dwSize,
            [In, MarshalAs(U4)] uint dwSizeHigh);

        [PreserveSig]
        HResult TransferObjectData(
            [In, Out] ref StringBuilder pData,
            [In, Out, MarshalAs(U4)] ref uint pdwSize,
            [In, Out] ref StringBuilder abMac);

        [PreserveSig]
        HResult End(
            [In] ref HResult phCompletionCode,
            [In, MarshalAs(IUnknown)] object pNewObject);
    }

    [ComImport,
        Guid(NativeAPI.Guids.MediaDevices.IWMDMOperation2),
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IWMDMOperation2 : IWMDMOperation
    {
        [PreserveSig]
        HResult SetObjectAttributes2(
            [In, MarshalAs(U4)] uint dwAttributes,
            [In, MarshalAs(U4)] uint dwAttributesEx,
            [In] ref WaveFormatEx pFormat,
            [In] ref VideoInfoHeader pVideoFormat);

        [PreserveSig]
        HResult GetObjectAttributes2(
            [Out, MarshalAs(U4)] out uint pdwAttributes,
            [Out, MarshalAs(U4)] out uint pdwAttributesEx,
            [Out, In] ref WaveFormatEx pAudioFormat,
            [Out, In] ref VideoInfoHeader pVideoFormat);
    }

    [ComImport,
        Guid(NativeAPI.Guids.MediaDevices.IWMDMOperation3),
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IWMDMOperation3 : IWMDMOperation2
    {
        [PreserveSig]
        HResult TransferObjectDataOnClearChannel(
            [Out, In] ref StringBuilder pData,
            [Out, In, MarshalAs(U4)] ref uint pdwSize);
    }
}
