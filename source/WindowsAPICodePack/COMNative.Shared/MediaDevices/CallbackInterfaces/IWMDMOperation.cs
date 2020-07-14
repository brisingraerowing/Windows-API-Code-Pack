//Copyright (c) Pierre Sprimont.  All rights reserved.

using Microsoft.WindowsAPICodePack.COMNative;
using Microsoft.WindowsAPICodePack.COMNative.MediaDevices;
using Microsoft.WindowsAPICodePack.Win32Native;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

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
            [Out, MarshalAs(UnmanagedType.LPWStr)] out string pwszName,
            [In] ushort nMaxChars);

        [PreserveSig]
        HResult SetObjectName(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pwszName,
            [In] ushort nMaxChars);

        [PreserveSig]
        HResult GetObjectAttributes(
            [Out] out uint pdwAttributes,
            [Out,In] ref WaveFormatEx pFormat);

        [PreserveSig]
        HResult SetObjectAttributes(
            [In] uint dwAttributes,
            [In] ref WaveFormatEx pFormat);

        [PreserveSig]
        HResult GetObjectTotalSize(
            [Out] out uint pdwSize,
            [Out] out uint pdwSizeHigh);

        [PreserveSig]
        HResult SetObjectTotalSize(
            [In] uint dwSize,
            [In] uint dwSizeHigh);

        [PreserveSig]
        HResult TransferObjectData(
            [In,Out] ref StringBuilder pData,
            [In,Out] ref uint pdwSize,
            [In,Out] ref StringBuilder abMac);

        [PreserveSig]
        HResult End(
            [In] ref HResult phCompletionCode,
            [In,MarshalAs(UnmanagedType.IUnknown)] object pNewObject);
    }

    public interface IWMDMOperation2 : IWMDMOperation

    {
        [PreserveSig]
        HResult SetObjectAttributes2(
            [In] uint dwAttributes,
            [In] uint dwAttributesEx,
            [In] ref WaveFormatEx pFormat,
            [In] ref VideoInfoHeader pVideoFormat);

        [PreserveSig]
        HResult GetObjectAttributes2(
            [Out] out uint pdwAttributes,
            [Out] out uint pdwAttributesEx,
            [Out,In] ref WaveFormatEx pAudioFormat,
            [Out,In] ref VideoInfoHeader pVideoFormat);

    }

    public interface IWMDMOperation3 : IWMDMOperation2

    {
        [PreserveSig]
        HResult TransferObjectDataOnClearChannel(
            [Out,In] ref StringBuilder pData,
            [Out,In] ref uint pdwSize);

    }
}
