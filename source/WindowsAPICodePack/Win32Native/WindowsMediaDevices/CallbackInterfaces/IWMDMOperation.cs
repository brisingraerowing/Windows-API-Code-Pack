using Microsoft.WindowsAPICodePack.Win32Native.Core;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Microsoft.WindowsAPICodePack. Win32Native.MediaDevices
{
    [ComImport,
        Guid(Guids.MediaDevices.IWMDMOperation),
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IWMDMOperation
    {
        HResult BeginRead();
        
        HResult BeginWrite();
        
        HResult GetObjectName(
            [Out, MarshalAs(UnmanagedType.LPWStr)] out string pwszName,
            [In] ushort nMaxChars);
        
        HResult SetObjectName(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pwszName,
            [In] ushort nMaxChars);
        
        HResult GetObjectAttributes(
            [Out] out uint pdwAttributes,
            [Out,In] ref WaveFormatEx pFormat);
        
        HResult SetObjectAttributes(
            [In] uint dwAttributes,
            [In] ref WaveFormatEx pFormat);
        
        HResult GetObjectTotalSize(
            [Out] out uint pdwSize,
            [Out] out uint pdwSizeHigh);
        
        HResult SetObjectTotalSize(
            [In] uint dwSize,
            [In] uint dwSizeHigh);
        
        HResult TransferObjectData(
            [In,Out] ref StringBuilder pData,
            [In,Out] ref uint pdwSize,
            [In,Out] ref StringBuilder abMac);
        
        HResult End(
            [In] ref HResult phCompletionCode,
            [In,MarshalAs(UnmanagedType.IUnknown)] object pNewObject);
    }

    public interface IWMDMOperation2 : IWMDMOperation

    {
        HResult SetObjectAttributes2(
            [In] uint dwAttributes,
            [In] uint dwAttributesEx,
            [In] ref WaveFormatEx pFormat,
            [In] ref VideoInfoHeader pVideoFormat);
        
        HResult GetObjectAttributes2(
            [Out] out uint pdwAttributes,
            [Out] out uint pdwAttributesEx,
            [Out,In] ref WaveFormatEx pAudioFormat,
            [Out,In] ref VideoInfoHeader pVideoFormat);

    }

    public interface IWMDMOperation3 : IWMDMOperation2

    {
        HResult TransferObjectDataOnClearChannel(
            [Out,In] ref StringBuilder pData,
            [Out,In] ref uint pdwSize);

    }
}
