using Microsoft.WindowsAPICodePack.Win32Native.Core;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Microsoft.WindowsAPICodePack.Win32Native.MediaDevices
{
    [ComImport,
        Guid(Guids.MediaDevices.IMDSPObjectInfo),
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IMDSPObjectInfo
    {
        HResult GetPlayLength(
            [Out] out uint pdwLength);
        
        HResult SetPlayLength(
            [In] uint dwLength);
        
        HResult GetPlayOffset(
            [Out] out uint pdwOffset);
        
        HResult SetPlayOffset(
            [In] uint dwOffset);
        
        HResult GetTotalLength(
            [Out] out uint pdwLength);
        
        HResult GetLastPlayPosition(
            [Out] out uint pdwLastPos);
        
        HResult GetLongestPlayPosition(
            [Out] out uint pdwLongestPos);
    }
}
