using Microsoft.WindowsAPICodePack.Win32Native;
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
        [PreserveSig]
        HResult Open(
            [In] ushort fuMode);

        [PreserveSig]
        HResult Read(
            [Out] out StringBuilder pData,
            [Out, In] ref uint pdwSize,
            [Out, In] ref StringBuilder abMac);

        [PreserveSig]
        HResult Write(
            [In] ref StringBuilder pData,
            [Out, In] ref uint pdwSize,
            [Out, In] ref StringBuilder abMac);

        [PreserveSig]
        HResult Delete(
            [In] ushort fuMode,
            [In] ref IWMDMProgress pProgress);

        [PreserveSig]
        HResult Seek(
            [In] ushort fuFlags,
            [In] uint dwOffset);

        [PreserveSig]
        HResult Rename(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pwszNewName,
            [In] ref IWMDMProgress pProgress);

        [PreserveSig]
        HResult Move(
            [In] ushort fuMode,
            [In] ref IWMDMProgress pProgress,
            [In] ref IMDSPStorage pTarget);

        [PreserveSig]
        HResult Close();
    }

    public interface IMDSPObject2 : IMDSPObject

    {
        [PreserveSig]
        HResult ReadOnClearChannel(
            [Out] out StringBuilder pData,
            [Out, In] ref uint pdwSize);

        [PreserveSig]
        HResult WriteOnClearChannel(
            [In] ref StringBuilder pData,
            [Out, In] ref uint pdwSize);

    }
}
