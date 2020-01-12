using Microsoft.WindowsAPICodePack.Win32Native;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Microsoft.WindowsAPICodePack. Win32Native.MediaDevices
{
    [ComImport,
        Guid(Guids.MediaDevices.IMDSPDeviceControl),
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IMDSPDeviceControl
    {
        HResult GetDCStatus(
            [Out] out uint pdwStatus);
        
        HResult GetCapabilities(
            [Out] out uint pdwCapabilitiesMask);
        
        HResult Play();
        
        HResult Record(
            [In] ref WaveFormatEx pFormat);
        
        HResult Pause();
        
        HResult Resume();
        
        HResult Stop();
        
        HResult Seek(
            [In] ushort fuMode,
            [In] short nOffset);
    }
}
