//Copyright (c) Pierre Sprimont.  All rights reserved.

using Microsoft.WindowsAPICodePack.Win32Native;

using System;
using System.Runtime.InteropServices;

using static System.Runtime.InteropServices.UnmanagedType;

namespace Microsoft.WindowsAPICodePack.COMNative.MediaDevices
{
    [ComImport,
        Guid(NativeAPI.Guids.MediaDevices.IWMDMStorage),
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IWMDMStorage
    {
        [PreserveSig]
        HResult SetAttributes(
            [In, MarshalAs(U4)] uint dwAttributes,
            [In] ref WaveFormatEx pFormat);

        [PreserveSig]
        HResult GetStorageGlobals(
            [Out, MarshalAs(Interface)] out IWMDMStorageGlobals ppStorageGlobals);

        [PreserveSig]
        HResult GetAttributes(
            [Out, MarshalAs(U4)] out uint pdwAttributes,
            [In, Out] ref WaveFormatEx pFormat);

        [PreserveSig]
        HResult GetName(
            [Out, MarshalAs(LPWStr)] out string pwszName,
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
            [In, Out] ref char[] abMac);

        [PreserveSig]
        HResult EnumStorage(
            [Out, MarshalAs(Interface)] out IWMDMEnumStorage pEnumStorage);

        [PreserveSig]
        HResult SendOpaqueCommand(
            [In, Out] ref OpaqueCommand pCommand);
    }

    [ComImport,
        Guid(NativeAPI.Guids.MediaDevices.IWMDMStorage2),
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IWMDMStorage2 : IWMDMStorage
    {
        [PreserveSig]
        HResult GetStorage(
            [In, MarshalAs(LPWStr)] string pszStorageName,
            [Out, MarshalAs(Interface)] out IWMDMStorage ppStorage);

        [PreserveSig]
        HResult SetAttributes2(
            [In, MarshalAs(U4)] uint dwAttributes,
            [In, MarshalAs(U4)] uint dwAttributesEx,
            [In] ref WaveFormatEx pFormat,
            [In] ref VideoInfoHeader pVideoFormat);

        [PreserveSig]
        HResult GetAttributes2(
            [Out, MarshalAs(U4)] out uint pdwAttributes,
            [Out, MarshalAs(U4)] out uint pdwAttributesEx,
            [In, Out] ref WaveFormatEx pAudioFormat,
            [In, Out] ref VideoInfoHeader pVideoFormat);
    }

    [ComImport,
        Guid(NativeAPI.Guids.MediaDevices.IWMDMStorage3),
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IWMDMStorage3 : IWMDMStorage2
    {
        [PreserveSig]
        HResult GetMetadata(
            [Out, MarshalAs(Interface)] out IWMDMMetaData ppMetadata);

        [PreserveSig]
        HResult SetMetadata(
            [In, MarshalAs(Interface)]
#if !WAPICP3
ref
#endif
        IWMDMMetaData pMetadata);

        [PreserveSig]
        HResult CreateEmptyMetadataObject(
            [Out, MarshalAs(Interface)] out IWMDMMetaData ppMetadata);

        [PreserveSig]
        HResult SetEnumPreference(
            [In, Out] ref StorageEnumMode pMode,
            [In, MarshalAs(U4)] uint nViews,
            [In] ref MetadataView pViews);
    }

    [ComImport,
        Guid(NativeAPI.Guids.MediaDevices.IWMDMStorage4),
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IWMDMStorage4 : IWMDMStorage3
    {
        [PreserveSig]
        HResult SetReferences(
            [In, MarshalAs(U4)] uint dwRefs,
            [In, MarshalAs(Interface)]
#if !WAPICP3
ref
#endif
         IWMDMStorage ppIWMDMStorage);

        [PreserveSig]
        HResult GetReferences(
            [Out, MarshalAs(U4)] out uint pdwRefs,
            [Out, MarshalAs(Interface)] out IWMDMStorage pppIWMDMStorage);

        [PreserveSig]
        HResult GetRightsWithProgress(
            [In, MarshalAs(Interface)]
#if !WAPICP3
ref
#endif
         IWMDMProgress3 pIProgressCallback,
            [Out] out WMDMRights ppRights,
            [Out, MarshalAs(U2)] out ushort pnRightsCount);

        [PreserveSig]
        HResult GetSpecifiedMetadata(
            [In, MarshalAs(U4)] uint cProperties,
            [In, MarshalAs(LPWStr)] string ppwszPropNames,
            [Out, MarshalAs(Interface)] out IWMDMMetaData ppMetadata);

        [PreserveSig]
        HResult FindStorage(
            [In] FindScope findScope,
            [In, MarshalAs(LPWStr)] string pwszUniqueID,
            [Out, MarshalAs(Interface)] out IWMDMStorage ppStorage);

        [PreserveSig]
        HResult GetParent(
            [Out, MarshalAs(Interface)] out IWMDMStorage ppStorage);
    }
}
