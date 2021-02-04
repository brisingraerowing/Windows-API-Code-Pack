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
        Guid(NativeAPI.Guids.MediaDevices.IWMDMStorageControl),
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IWMDMStorageControl
    {
        [PreserveSig]
        HResult Insert(
            [In] ushort fuMode,
            [In, MarshalAs(UnmanagedType.LPWStr)] string pwszFile,
            [In, MarshalAs(UnmanagedType.Interface)]
#if !WAPICP3
ref
#endif
         IWMDMOperation pOperation,
            [In, MarshalAs(UnmanagedType.Interface)]
#if !WAPICP3
ref
#endif
         IWMDMProgress pProgress,
            [Out, MarshalAs(UnmanagedType.Interface)] out IWMDMStorage ppNewObject);

        [PreserveSig]
        HResult Delete(
            [In] ushort fuMode,
            [In, MarshalAs(UnmanagedType.Interface)]
#if !WAPICP3
ref
#endif
         IWMDMProgress pProgress);

        [PreserveSig]
        HResult Rename(
            [In] ushort fuMode,
            [In, MarshalAs(UnmanagedType.LPWStr)] string pwszNewName,
            [In, MarshalAs(UnmanagedType.Interface)]
#if !WAPICP3
ref
#endif
         IWMDMProgress pProgress);

        [PreserveSig]
        HResult Read(
            [In] ushort fuMode,
            [In, MarshalAs(UnmanagedType.LPWStr)] string pwszFile,
            [In, MarshalAs(UnmanagedType.Interface)]
#if !WAPICP3
ref
#endif
         IWMDMProgress pProgress,
            [In, MarshalAs(UnmanagedType.Interface)]
#if !WAPICP3
ref
#endif
         IWMDMOperation pOperation);

        [PreserveSig]
        HResult Move(
            [In] ushort fuMode,
            [In, MarshalAs(UnmanagedType.Interface)]
#if !WAPICP3
ref
#endif
         IWMDMStorage pTargetObject,
            [In, MarshalAs(UnmanagedType.Interface)]
#if !WAPICP3
ref
#endif
         IWMDMProgress pProgress);
    }

    public interface IWMDMStorageControl2 : IWMDMStorageControl

    {
        [PreserveSig]
        HResult Insert2(
            [In] ushort fuMode,
            [In, MarshalAs(UnmanagedType.LPWStr)] string pwszFileSource,
            [In, MarshalAs(UnmanagedType.LPWStr)] string pwszFileDest,
            [In, MarshalAs(UnmanagedType.Interface)]
#if !WAPICP3
ref
#endif
         IWMDMOperation pOperation,
            [In, MarshalAs(UnmanagedType.Interface)]
#if !WAPICP3
ref
#endif
         IWMDMProgress pProgress,
            [In, MarshalAs(UnmanagedType.IUnknown)] ref object pUnknown,
            [In, Out, MarshalAs(UnmanagedType.Interface)]
#if !WAPICP3
ref
#endif
         IWMDMStorage ppNewObject);

    }

    public interface IWMDMStorageControl3 : IWMDMStorageControl2

    {
        [PreserveSig]
        HResult Insert3(
            [In] ushort fuMode,
            [In] ushort fuType,
            [In, MarshalAs(UnmanagedType.LPWStr)] string pwszFileSource,
            [In, MarshalAs(UnmanagedType.LPWStr)] string pwszFileDest,
            [In, MarshalAs(UnmanagedType.Interface)]
#if !WAPICP3
ref
#endif
         IWMDMOperation pOperation,
            [In, MarshalAs(UnmanagedType.Interface)]
#if !WAPICP3
ref
#endif
         IWMDMProgress pProgress,
            [In, MarshalAs(UnmanagedType.Interface)]
#if !WAPICP3
ref
#endif
         IWMDMMetaData pMetaData,
            [In, MarshalAs(UnmanagedType.IUnknown)] ref object pUnknown,
            [In, Out, MarshalAs(UnmanagedType.Interface)]
#if !WAPICP3
ref
#endif
         IWMDMStorage ppNewObject);

    }
}
