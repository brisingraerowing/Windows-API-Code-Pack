//Copyright (c) Pierre Sprimont.  All rights reserved.

using Microsoft.WindowsAPICodePack.COMNative;
using Microsoft.WindowsAPICodePack.Win32Native;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Microsoft.WindowsAPICodePack.COMNative.MediaDevices
{
    [ComImport,
        Guid(Win32Native.Guids.MediaDevices.IWMDMStorage),
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IWMDMStorage
    {
        [PreserveSig]
        HResult SetAttributes(
            [In] uint dwAttributes,
            [In] ref WaveFormatEx pFormat);

        [PreserveSig]
        HResult GetStorageGlobals(
            [Out, MarshalAs(UnmanagedType.Interface)] out IWMDMStorageGlobals ppStorageGlobals);

        [PreserveSig]
        HResult GetAttributes(
            [Out] out uint pdwAttributes,
            [In,Out] ref WaveFormatEx pFormat);

        [PreserveSig]
        HResult GetName(
            [Out,MarshalAs(UnmanagedType.LPWStr)] out string pwszName,
            [In] ushort nMaxChars);

        [PreserveSig]
        HResult GetDate(
            [Out] out WMDMDateTime pDateTimeUTC);

        [PreserveSig]
        HResult GetSize(
            [Out] out uint pdwSizeLow,
            [Out] out uint pdwSizeHigh);

        [PreserveSig]
        HResult GetRights(
            [Out] out WMDMRights ppRights,
            [Out] out ushort pnRightsCount,
            [In,Out] ref char[] abMac);

        [PreserveSig]
        HResult EnumStorage(
            [Out, MarshalAs(UnmanagedType.Interface)] out IWMDMEnumStorage pEnumStorage);

        [PreserveSig]
        HResult SendOpaqueCommand(
            [In,Out] ref OpaqueCommand pCommand);
    }

    public interface IWMDMStorage2 : IWMDMStorage
    {
        [PreserveSig]
        HResult GetStorage(
            [In,MarshalAs(UnmanagedType.LPWStr)] string pszStorageName,
            [Out,MarshalAs(UnmanagedType.Interface)] out IWMDMStorage ppStorage);

        [PreserveSig]
        HResult SetAttributes2(
            [In] uint dwAttributes,
            [In] uint dwAttributesEx,
            [In] ref WaveFormatEx pFormat,
            [In] ref VideoInfoHeader pVideoFormat);
        
        [PreserveSig]
        HResult GetAttributes2(
            [Out] out uint pdwAttributes,
            [Out] out uint pdwAttributesEx,
            [In,Out] ref WaveFormatEx pAudioFormat,
            [In,Out] ref VideoInfoHeader pVideoFormat);

    }

    public interface IWMDMStorage3 : IWMDMStorage2

    {
        [PreserveSig]
        HResult GetMetadata(
            [Out, MarshalAs(UnmanagedType.Interface)] out IWMDMMetaData ppMetadata);

        [PreserveSig]
        HResult SetMetadata(
            [In, MarshalAs(UnmanagedType.Interface)] ref IWMDMMetaData pMetadata);

        [PreserveSig]
        HResult CreateEmptyMetadataObject(
            [Out, MarshalAs(UnmanagedType.Interface)] out IWMDMMetaData ppMetadata);

        [PreserveSig]
        HResult SetEnumPreference(
            [In,Out] ref StorageEnumMode pMode,
            [In] uint nViews,
            [In] ref MetadataView pViews);

    }

    public interface IWMDMStorage4 : IWMDMStorage3

    {
        [PreserveSig]
        HResult SetReferences(
            [In] uint dwRefs,
            [In,MarshalAs(UnmanagedType.Interface)] ref IWMDMStorage ppIWMDMStorage);

        [PreserveSig]
        HResult GetReferences(
            [Out] out uint pdwRefs,
            [Out, MarshalAs(UnmanagedType.Interface)] out IWMDMStorage pppIWMDMStorage);

        [PreserveSig]
        HResult GetRightsWithProgress(
            [In, MarshalAs(UnmanagedType.Interface)] ref IWMDMProgress3 pIProgressCallback,
            [Out] out WMDMRights ppRights,
            [Out] out ushort pnRightsCount);

        [PreserveSig]
        HResult GetSpecifiedMetadata(
            [In] uint cProperties,
            [In, MarshalAs(UnmanagedType.LPWStr)] string ppwszPropNames,
            [Out] out IWMDMMetaData ppMetadata);

        [PreserveSig]
        HResult FindStorage(
            [In] FindScope findScope,
            [In,MarshalAs(UnmanagedType.LPWStr)] string pwszUniqueID,
            [Out, MarshalAs(UnmanagedType.Interface)] out IWMDMStorage ppStorage);

        [PreserveSig]
        HResult GetParent(
            [Out, MarshalAs(UnmanagedType.Interface)] out IWMDMStorage ppStorage);

    }
}
