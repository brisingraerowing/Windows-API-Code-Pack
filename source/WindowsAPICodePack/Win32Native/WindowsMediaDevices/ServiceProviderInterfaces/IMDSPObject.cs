using Microsoft.WindowsAPICodePack.Win32Native.Core;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Microsoft.WindowsAPICodePack. Win32Native.MediaDevices
{
    [ComImport,
        Guid(Guids.MediaDevices.IMDSPObject),
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IMDSPObject
    {
        HResult Open(
            [In] ushort fuMode);
        
        HResult Read(
            [Out] out StringBuilder pData,
            [Out, In] ref uint pdwSize,
            [Out, In] ref StringBuilder abMac);
        
        HResult Write(
            [In] ref StringBuilder pData,
            [Out, In] ref uint pdwSize,
            [Out, In] ref StringBuilder abMac);
        
        HResult Delete(
            [In] ushort fuMode,
            [In] ref IWMDMProgress pProgress);
        
        HResult Seek(
            [In] ushort fuFlags,
            [In] uint dwOffset);
        
        HResult Rename(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pwszNewName,
            [In] ref IWMDMProgress pProgress);
        
        HResult Move(
            [In] ushort fuMode,
            [In] ref IWMDMProgress pProgress,
            [In] ref IMDSPStorage pTarget);
        
        HResult Close();
    }

    public interface IMDSPObject2 : IMDSPObject

    {
        HResult ReadOnClearChannel(
            [Out] out StringBuilder pData,
            [Out, In] ref uint pdwSize);
        
        HResult WriteOnClearChannel(
            [In] ref StringBuilder pData,
            [Out, In] ref uint pdwSize);

    }
}
