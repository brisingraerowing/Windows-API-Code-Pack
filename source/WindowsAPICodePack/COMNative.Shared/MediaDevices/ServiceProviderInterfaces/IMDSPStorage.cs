//Copyright (c) Pierre Sprimont.  All rights reserved.

using Microsoft.WindowsAPICodePack.Win32Native;

using System;
using System.Runtime.InteropServices;
using System.Text;

using static System.Runtime.InteropServices.UnmanagedType;

namespace Microsoft.WindowsAPICodePack.COMNative.MediaDevices
{
    [ComImport,
        Guid(NativeAPI.Guids.MediaDevices.IMDSPStorage),
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IMDSPStorage
    {
        [PreserveSig]
        HResult SetAttributes(
            [In, MarshalAs(U4)] uint dwAttributes,
            [In] ref WaveFormatEx pFormat);

        [PreserveSig]
        HResult GetStorageGlobals(
            [Out, MarshalAs(Interface)] out IMDSPStorageGlobals ppStorageGlobals);

        [PreserveSig]
        HResult GetAttributes(
            [Out, MarshalAs(U4)] out uint pdwAttributes,
            [Out, In] ref WaveFormatEx pFormat);

        [PreserveSig]
        HResult GetName(
            [Out, MarshalAs(LPWStr)] string pwszName,
            [In, MarshalAs(U2)] ushort nMaxChars);

        [PreserveSig]
        HResult GetDate(
            [Out] out WMDMDateTime pDateTimeUTC);

        [PreserveSig]
        HResult GetSize(
            [Out, MarshalAs(U4)] out uint pdwSizeLow,
            [Out, MarshalAs(U4)] out uint pdwSizeHigh);

        [PreserveSig]
        HResult GetRights(
            [Out] out WMDMRights ppRights,
            [Out, MarshalAs(U2)] out ushort pnRightsCount,
            [Out, In] ref StringBuilder abMac);

        [PreserveSig]
        HResult CreateStorage(
            [In, MarshalAs(U4)] uint dwAttributes,
            [In] ref WaveFormatEx pFormat,
            [In, MarshalAs(LPWStr)] string pwszName,
            [Out, MarshalAs(Interface)] out IMDSPStorage ppNewStorage);

        [PreserveSig]
        HResult EnumStorage(
            [Out, MarshalAs(Interface)] out IMDSPEnumStorage ppEnumStorage);

        [PreserveSig]
        HResult SendOpaqueCommand(
            [Out, In] ref OpaqueCommand pCommand);
    }

    [ComImport,
        Guid(NativeAPI.Guids.MediaDevices.IMDSPStorage2),
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IMDSPStorage2 : IMDSPStorage
    {
        [PreserveSig]
        HResult GetStorage(
            [In, MarshalAs(LPWStr)] string pszStorageName,
            [Out, MarshalAs(Interface)] out IMDSPStorage ppStorage);

        [PreserveSig]
        HResult CreateStorage2(
            [In, MarshalAs(U4)] uint dwAttributes,
            [In, MarshalAs(U4)] uint dwAttributesEx,
            [In] ref WaveFormatEx pAudioFormat,
            [In] ref VideoInfoHeader pVideoFormat,
            [In, MarshalAs(LPWStr)] string pwszName,
            [In, MarshalAs(U8)] ulong qwFileSize,
            [Out, MarshalAs(Interface)] out IMDSPStorage ppNewStorage);

        [PreserveSig]
        HResult SetAttributes2(
            [In, MarshalAs(U4)] uint dwAttributes,
            [In, MarshalAs(U4)] uint dwAttributesEx,
            [In] ref WaveFormatEx pAudioFormat,
            [In] ref VideoInfoHeader pVideoFormat);

        [PreserveSig]
        HResult GetAttributes2(
            [Out, MarshalAs(U4)] out uint pdwAttributes,
            [Out, MarshalAs(U4)] out uint pdwAttributesEx,
            [Out, In] ref WaveFormatEx pAudioFormat,
            [Out, In] ref VideoInfoHeader pVideoFormat);
    }

    [ComImport,
        Guid(NativeAPI.Guids.MediaDevices.IMDSPStorage3),
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IMDSPStorage3 : IMDSPStorage2
    {
        [PreserveSig]
        HResult GetMetadata(
            [In, MarshalAs(Interface)] ref IWMDMMetaData pMetadata);

        [PreserveSig]
        HResult SetMetadata(
            [In, MarshalAs(Interface)] ref IWMDMMetaData pMetadata);
    }

    [ComImport,
        Guid(NativeAPI.Guids.MediaDevices.IMDSPStorage4),
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IMDSPStorage4 : IMDSPStorage3
    {
        [PreserveSig]
        HResult SetReferences(
            [In, MarshalAs(U4)] uint dwRefs,
            [In, MarshalAs(Interface)] ref IMDSPStorage ppISPStorage);

        [PreserveSig]
        HResult GetReferences(
            [Out, MarshalAs(U4)] out uint pdwRefs,
            [Out, MarshalAs(Interface)] out IMDSPStorage pppISPStorage);

        [PreserveSig]
        HResult CreateStorageWithMetadata(
            [In, MarshalAs(U4)] uint dwAttributes,
            [In, MarshalAs(LPWStr)] string pwszName,
            [In, MarshalAs(Interface)] ref IWMDMMetaData pMetadata,
            [In, MarshalAs(U8)] ulong qwFileSize,
            [Out, MarshalAs(Interface)] out IMDSPStorage ppNewStorage);

        [PreserveSig]
        HResult GetSpecifiedMetadata(
            [In, MarshalAs(U4)] uint cProperties,
            [In, MarshalAs(LPWStr)] string ppwszPropNames,
            [In, MarshalAs(Interface)] ref IWMDMMetaData pMetadata);

        [PreserveSig]
        HResult FindStorage(
            [In] FindScope findScope,
            [In, MarshalAs(LPWStr)] string pwszUniqueID,
            [Out, MarshalAs(Interface)] out IMDSPStorage ppStorage);

        [PreserveSig]
        HResult GetParent(
            [Out, MarshalAs(Interface)] out IMDSPStorage ppStorage);
    }
}
