using Microsoft.WindowsAPICodePack.Win32Native;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Microsoft.WindowsAPICodePack. Win32Native.MediaDevices
{
    [ComImport,
        Guid(Guids.MediaDevices.IMDSPStorage),
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IMDSPStorage
    {
        [PreserveSig]
        HResult SetAttributes(
            [In] uint dwAttributes,
            [In] ref WaveFormatEx pFormat);

        [PreserveSig]
        HResult GetStorageGlobals(
            [Out] out IMDSPStorageGlobals ppStorageGlobals);

        [PreserveSig]
        HResult GetAttributes(
            [Out] out uint pdwAttributes,
            [Out, In] ref WaveFormatEx pFormat);

        [PreserveSig]
        HResult GetName(
            [Out, MarshalAs(UnmanagedType.LPWStr)] string pwszName,
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
            [Out, In] ref StringBuilder abMac);

        [PreserveSig]
        HResult CreateStorage(
            [In] uint dwAttributes,
            [In] ref WaveFormatEx pFormat,
            [In, MarshalAs(UnmanagedType.LPWStr)] string pwszName,
            [Out] out IMDSPStorage ppNewStorage);

        [PreserveSig]
        HResult EnumStorage(
            [Out] out IMDSPEnumStorage ppEnumStorage);

        [PreserveSig]
        HResult SendOpaqueCommand(
            [Out, In] ref OpaqueCommand pCommand);
    }

    public interface IMDSPStorage2 : IMDSPStorage
    {
        [PreserveSig]
        HResult GetStorage(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pszStorageName,
            [Out] out IMDSPStorage ppStorage);

        [PreserveSig]
        HResult CreateStorage2(
            [In] uint dwAttributes,
            [In] uint dwAttributesEx,
            [In] ref WaveFormatEx pAudioFormat,
            [In] ref VideoInfoHeader pVideoFormat,
            [In, MarshalAs(UnmanagedType.LPWStr)] string pwszName,
            [In] ulong qwFileSize,
            [Out] out IMDSPStorage ppNewStorage);

        [PreserveSig]
        HResult SetAttributes2(
            [In] uint dwAttributes,
            [In] uint dwAttributesEx,
            [In] ref WaveFormatEx pAudioFormat,
            [In] ref VideoInfoHeader pVideoFormat);

        [PreserveSig]
        HResult GetAttributes2(
            [Out] out uint pdwAttributes,
            [Out] out uint pdwAttributesEx,
            [Out, In] ref WaveFormatEx pAudioFormat,
            [Out, In] ref VideoInfoHeader pVideoFormat);
    }

    public interface IMDSPStorage3 : IMDSPStorage2
    {
        [PreserveSig]
        HResult GetMetadata(
            [In] ref IWMDMMetaData pMetadata);

        [PreserveSig]
        HResult SetMetadata(
            [In] ref IWMDMMetaData pMetadata);
    }

    public interface IMDSPStorage4 : IMDSPStorage3
    {
        [PreserveSig]
        HResult SetReferences(
            [In] uint dwRefs,
            [In] ref IMDSPStorage ppISPStorage);

        [PreserveSig]
        HResult GetReferences(
            [Out] out uint pdwRefs,
            [Out] out IMDSPStorage pppISPStorage);

        [PreserveSig]
        HResult CreateStorageWithMetadata(
            [In] uint dwAttributes,
            [In, MarshalAs(UnmanagedType.LPWStr)] string pwszName,
            [In] ref IWMDMMetaData pMetadata,
            [In] ulong qwFileSize,
            [Out] out IMDSPStorage ppNewStorage);

        [PreserveSig]
        HResult GetSpecifiedMetadata(
            [In] uint cProperties,
            [In, MarshalAs(UnmanagedType.LPWStr)] string ppwszPropNames,
            [In] ref IWMDMMetaData pMetadata);

        [PreserveSig]
        HResult FindStorage(
            [In] FindScope findScope,
            [In, MarshalAs(UnmanagedType.LPWStr)] string pwszUniqueID,
            [Out] out IMDSPStorage ppStorage);

        [PreserveSig]
        HResult GetParent(
            [Out] out IMDSPStorage ppStorage);
    }
}
