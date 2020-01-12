using Microsoft.WindowsAPICodePack.Win32Native;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Microsoft.WindowsAPICodePack. Win32Native.MediaDevices
{
    [ComImport,
        Guid(Guids.MediaDevices.IWMDMStorageControl),
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IWMDMStorageControl
    {
        HResult Insert(
            [In] ushort fuMode,
            [In,MarshalAs(UnmanagedType.LPWStr)] string pwszFile,
            [In,MarshalAs(UnmanagedType.Interface)] ref IWMDMOperation pOperation,
            [In,MarshalAs(UnmanagedType.Interface)] ref IWMDMProgress pProgress,
            [Out,MarshalAs(UnmanagedType.Interface)] out IWMDMStorage ppNewObject);
        
        HResult Delete(
            [In] ushort fuMode,
            [In,MarshalAs(UnmanagedType.Interface)] ref IWMDMProgress pProgress);
        
        HResult Rename(
            [In] ushort fuMode,
            [In,MarshalAs(UnmanagedType.LPWStr)] string pwszNewName,
            [In,MarshalAs(UnmanagedType.Interface)] ref IWMDMProgress pProgress);
        
        HResult Read(
            [In] ushort fuMode,
            [In, MarshalAs(UnmanagedType.LPWStr)] string pwszFile,
            [In,MarshalAs(UnmanagedType.Interface)] ref IWMDMProgress pProgress,
            [In,MarshalAs(UnmanagedType.Interface)] ref IWMDMOperation pOperation);
        
        HResult Move(
            [In] ushort fuMode,
            [In,MarshalAs(UnmanagedType.Interface)] ref IWMDMStorage pTargetObject,
            [In,MarshalAs(UnmanagedType.Interface)] ref IWMDMProgress pProgress);
    }

    public interface IWMDMStorageControl2 : IWMDMStorageControl

    {
        HResult Insert2(
            [In] ushort fuMode,
            [In,MarshalAs(UnmanagedType.LPWStr)] string pwszFileSource,
            [In,MarshalAs(UnmanagedType.LPWStr)] string pwszFileDest,
            [In,MarshalAs(UnmanagedType.Interface)] ref IWMDMOperation pOperation,
            [In,MarshalAs(UnmanagedType.Interface)] ref IWMDMProgress pProgress,
            [In,MarshalAs(UnmanagedType.IUnknown)] ref object pUnknown,
            [In,Out,MarshalAs(UnmanagedType.Interface)] ref IWMDMStorage ppNewObject);

    }

    public interface IWMDMStorageControl3 : IWMDMStorageControl2

    {
        HResult Insert3(
            [In] ushort fuMode,
            [In] ushort fuType,
            [In,MarshalAs(UnmanagedType.LPWStr)] string pwszFileSource,
            [In,MarshalAs(UnmanagedType.LPWStr)] string pwszFileDest,
            [In,MarshalAs(UnmanagedType.Interface)] ref IWMDMOperation pOperation,
            [In,MarshalAs(UnmanagedType.Interface)] ref IWMDMProgress pProgress,
            [In,MarshalAs(UnmanagedType.Interface)] ref IWMDMMetaData pMetaData,
            [In,MarshalAs(UnmanagedType.IUnknown)] ref object pUnknown,
            [In,Out,MarshalAs(UnmanagedType.Interface)] ref IWMDMStorage ppNewObject);

    }
}
