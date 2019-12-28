using Microsoft.WindowsAPICodePack.Win32Native.Core;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Microsoft.WindowsAPICodePack. Win32Native.MediaDevices
{
    [ComImport,
        Guid(Guids.MediaDevices.IWMDMStorage),
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IWMDMStorage
    {
        HResult SetAttributes(
            [In] uint dwAttributes,
            [In] ref WAVEFORMATEX pFormat);
        
        HResult GetStorageGlobals(
            [Out, MarshalAs(UnmanagedType.Interface)] out IWMDMStorageGlobals ppStorageGlobals);
        
        HResult GetAttributes(
            [Out] out uint pdwAttributes,
            [In,Out] ref WAVEFORMATEX pFormat);
        
        HResult GetName(
            [Out,MarshalAs(UnmanagedType.LPWStr)] out string pwszName,
            [In] ushort nMaxChars);
        
        HResult GetDate(
            [Out] out PWMDMDATETIME pDateTimeUTC);
        
        HResult GetSize(
            [Out] out uint pdwSizeLow,
            [Out] out uint pdwSizeHigh);
        
        HResult GetRights(
            [Out] out PWMDMRIGHTS ppRights,
            [Out] out ushort pnRightsCount,
            [In,Out] ref char[] abMac);
        
        HResult EnumStorage(
            [Out, MarshalAs(UnmanagedType.Interface)] out IWMDMEnumStorage pEnumStorage);
        
        HResult SendOpaqueCommand(
            [In,Out] ref OPAQUECOMMAND pCommand);
    }

    public interface IWMDMStorage2 : IWMDMStorage
    {
        HResult GetStorage(
            [In,MarshalAs(UnmanagedType.LPWStr)] string pszStorageName,
            [Out,MarshalAs(UnmanagedType.Interface)] out IWMDMStorage ppStorage);
        
        HResult SetAttributes2(
            [In] uint dwAttributes,
            [In] uint dwAttributesEx,
            [In] ref WAVEFORMATEX pFormat,
            [In] ref VIDEOINFOHEADER pVideoFormat);
        
        HResult GetAttributes2(
            [Out] out uint pdwAttributes,
            [Out] out uint pdwAttributesEx,
            [In,Out] ref WAVEFORMATEX pAudioFormat,
            [In,Out] ref VIDEOINFOHEADER pVideoFormat);

    }

    public interface IWMDMStorage3 : IWMDMStorage2

    {
        HResult GetMetadata(
            [Out, MarshalAs(UnmanagedType.Interface)] out IWMDMMetaData ppMetadata);
        
        HResult SetMetadata(
            [In, MarshalAs(UnmanagedType.Interface)] ref IWMDMMetaData pMetadata);
        
        HResult CreateEmptyMetadataObject(
            [Out, MarshalAs(UnmanagedType.Interface)] out IWMDMMetaData ppMetadata);
        
        HResult SetEnumPreference(
            [In,Out] ref StorageEnumMode pMode,
            [In] uint nViews,
            [In] ref WMDMMetadataView pViews);

    }

    public interface IWMDMStorage4 : IWMDMStorage3

    {
        HResult SetReferences(
            [In] uint dwRefs,
            [In,MarshalAs(UnmanagedType.Interface)] ref IWMDMStorage ppIWMDMStorage);
        
        HResult GetReferences(
            [Out] out uint pdwRefs,
            [Out, MarshalAs(UnmanagedType.Interface)] out IWMDMStorage pppIWMDMStorage);
        
        HResult GetRightsWithProgress(
            [In, MarshalAs(UnmanagedType.Interface)] ref IWMDMProgress3 pIProgressCallback,
            [Out] out PWMDMRIGHTS ppRights,
            [Out] out ushort pnRightsCount);
        
        HResult GetSpecifiedMetadata(
            [In] uint cProperties,
            [In, MarshalAs(UnmanagedType.LPWStr)] string ppwszPropNames,
            [Out] out IWMDMMetaData ppMetadata);
        
        HResult FindStorage(
            [In] FindScope findScope,
            [In,MarshalAs(UnmanagedType.LPWStr)] string pwszUniqueID,
            [Out, MarshalAs(UnmanagedType.Interface)] out IWMDMStorage ppStorage);
        
        HResult GetParent(
            [Out, MarshalAs(UnmanagedType.Interface)] out IWMDMStorage ppStorage);

    }
}
