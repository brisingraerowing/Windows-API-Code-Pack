//Copyright (c) Pierre Sprimont.  All rights reserved.

using Microsoft.WindowsAPICodePack.Win32Native;

using System;
using System.Runtime.InteropServices;

using static System.Runtime.InteropServices.UnmanagedType;

namespace Microsoft.WindowsAPICodePack.COMNative.MediaDevices
{
    [ComImport,
        Guid(NativeAPI.Guids.MediaDevices.IWMDMStorageControl),
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IWMDMStorageControl
    {
        [PreserveSig]
        HResult Insert(
            [In, MarshalAs(U2)] ushort fuMode,
            [In, MarshalAs(LPWStr)] string pwszFile,
            [In, MarshalAs(Interface)]
#if !WAPICP3
ref
#endif
         IWMDMOperation pOperation,
            [In, MarshalAs(Interface)]
#if !WAPICP3
ref
#endif
         IWMDMProgress pProgress,
            [Out, MarshalAs(Interface)] out IWMDMStorage ppNewObject);

        [PreserveSig]
        HResult Delete(
            [In, MarshalAs(U2)] ushort fuMode,
            [In, MarshalAs(Interface)]
#if !WAPICP3
ref
#endif
         IWMDMProgress pProgress);

        [PreserveSig]
        HResult Rename(
            [In, MarshalAs(U2)] ushort fuMode,
            [In, MarshalAs(LPWStr)] string pwszNewName,
            [In, MarshalAs(Interface)]
#if !WAPICP3
ref
#endif
         IWMDMProgress pProgress);

        [PreserveSig]
        HResult Read(
            [In, MarshalAs(U2)] ushort fuMode,
            [In, MarshalAs(LPWStr)] string pwszFile,
            [In, MarshalAs(Interface)]
#if !WAPICP3
ref
#endif
         IWMDMProgress pProgress,
            [In, MarshalAs(Interface)]
#if !WAPICP3
ref
#endif
         IWMDMOperation pOperation);

        [PreserveSig]
        HResult Move(
            [In, MarshalAs(U2)] ushort fuMode,
            [In, MarshalAs(Interface)]
#if !WAPICP3
ref
#endif
         IWMDMStorage pTargetObject,
            [In, MarshalAs(Interface)]
#if !WAPICP3
ref
#endif
         IWMDMProgress pProgress);
    }

    [ComImport,
        Guid(NativeAPI.Guids.MediaDevices.IWMDMStorageControl2),
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IWMDMStorageControl2 : IWMDMStorageControl
    {
        [PreserveSig]
        HResult Insert2(
            [In, MarshalAs(U2)] ushort fuMode,
            [In, MarshalAs(LPWStr)] string pwszFileSource,
            [In, MarshalAs(LPWStr)] string pwszFileDest,
            [In, MarshalAs(Interface)]
#if !WAPICP3
ref
#endif
         IWMDMOperation pOperation,
            [In, MarshalAs(Interface)]
#if !WAPICP3
ref
#endif
         IWMDMProgress pProgress,
            [In, MarshalAs(IUnknown)] ref object pUnknown,
            [In, Out, MarshalAs(Interface)]
#if !WAPICP3
ref
#endif
         IWMDMStorage ppNewObject);
    }

    [ComImport,
        Guid(NativeAPI.Guids.MediaDevices.IWMDMStorageControl3),
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IWMDMStorageControl3 : IWMDMStorageControl2
    {
        [PreserveSig]
        HResult Insert3(
            [In, MarshalAs(U2)] ushort fuMode,
            [In, MarshalAs(U2)] ushort fuType,
            [In, MarshalAs(LPWStr)] string pwszFileSource,
            [In, MarshalAs(LPWStr)] string pwszFileDest,
            [In, MarshalAs(Interface)]
#if !WAPICP3
ref
#endif
         IWMDMOperation pOperation,
            [In, MarshalAs(Interface)]
#if !WAPICP3
ref
#endif
         IWMDMProgress pProgress,
            [In, MarshalAs(Interface)]
#if !WAPICP3
ref
#endif
         IWMDMMetaData pMetaData,
            [In, MarshalAs(IUnknown)] ref object pUnknown,
            [In, Out, MarshalAs(Interface)]
#if !WAPICP3
ref
#endif
         IWMDMStorage ppNewObject);
    }
}
