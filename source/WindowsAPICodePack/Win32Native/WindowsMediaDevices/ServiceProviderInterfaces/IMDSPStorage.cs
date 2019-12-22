using Microsoft.WindowsAPICodePack.Win32Native.Core;
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
        HResult SetAttributes(
            [In] uint dwAttributes,
            [In] ref WAVEFORMATEX pFormat);
        
        HResult GetStorageGlobals(
            [Out] out IMDSPStorageGlobals ppStorageGlobals);
        
        HResult GetAttributes(
            [Out] out uint pdwAttributes,
            [Out, In] ref WAVEFORMATEX pFormat);
        
        HResult GetName(
            [Out, MarshalAs(UnmanagedType.LPWStr)] string pwszName,
            [In] ushort nMaxChars);
        
        HResult GetDate(
            [Out] out WMDMDATETIME pDateTimeUTC);
        
        HResult GetSize(
            [Out] out uint pdwSizeLow,
            [Out] out uint pdwSizeHigh);
        
        HResult GetRights(
            [Out] out WMDMRIGHTS ppRights,
            [Out] out ushort pnRightsCount,
            [Out, In] ref StringBuilder abMac);
        
        HResult CreateStorage(
            [In] uint dwAttributes,
            [In] ref WAVEFORMATEX pFormat,
            [In, MarshalAs(UnmanagedType.LPWStr)] string pwszName,
            [Out] out IMDSPStorage ppNewStorage);
        
        HResult EnumStorage(
            [Out] out IMDSPEnumStorage ppEnumStorage);
        
        HResult SendOpaqueCommand(
            [Out, In] ref OPAQUECOMMAND pCommand);
    }

    public interface IMDSPStorage2 : IMDSPStorage
    {
        HResult GetStorage(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pszStorageName,
            [Out] out IMDSPStorage ppStorage);
        
        HResult CreateStorage2(
            [In] uint dwAttributes,
            [In] uint dwAttributesEx,
            [In] ref WAVEFORMATEX pAudioFormat,
            [In] ref VIDEOINFOHEADER pVideoFormat,
            [In, MarshalAs(UnmanagedType.LPWStr)] string pwszName,
            [In] ulong qwFileSize,
            [Out] out IMDSPStorage ppNewStorage);
        
        HResult SetAttributes2(
            [In] uint dwAttributes,
            [In] uint dwAttributesEx,
            [In] ref WAVEFORMATEX pAudioFormat,
            [In] ref VIDEOINFOHEADER pVideoFormat);
        
        HResult GetAttributes2(
            [Out] out uint pdwAttributes,
            [Out] out uint pdwAttributesEx,
            [Out, In] ref WAVEFORMATEX pAudioFormat,
            [Out, In] ref VIDEOINFOHEADER pVideoFormat);
    }

    public interface IMDSPStorage3 : IMDSPStorage2
    {
        HResult GetMetadata(
            [In] ref IWMDMMetaData pMetadata);
        
        HResult SetMetadata(
            [In] ref IWMDMMetaData pMetadata);
    }

    public interface IMDSPStorage4 : IMDSPStorage3
    {
        HResult SetReferences(
            [In] uint dwRefs,
            [In] ref IMDSPStorage ppISPStorage);
        
        HResult GetReferences(
            [Out] out uint pdwRefs,
            [Out] out IMDSPStorage pppISPStorage);
        
        HResult CreateStorageWithMetadata(
            [In] uint dwAttributes,
            [In, MarshalAs(UnmanagedType.LPWStr)] string pwszName,
            [In] ref IWMDMMetaData pMetadata,
            [In] ulong qwFileSize,
            [Out] out IMDSPStorage ppNewStorage);
        
        HResult GetSpecifiedMetadata(
            [In] uint cProperties,
            [In, MarshalAs(UnmanagedType.LPWStr)] string ppwszPropNames,
            [In] ref IWMDMMetaData pMetadata);
        
        HResult FindStorage(
            [In] WMDM_FIND_SCOPE findScope,
            [In, MarshalAs(UnmanagedType.LPWStr)] string pwszUniqueID,
            [Out] out IMDSPStorage ppStorage);
        
        HResult GetParent(
            [Out] out IMDSPStorage ppStorage);
    }
}
