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
        Guid(NativeAPI.Guids.MediaDevices.IMDSPDirectTransfer),
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IMDSPDirectTransfer
    {
        [PreserveSig]
        HResult TransferToDevice(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pwszSourceFilePath,
            [In] ref IWMDMOperation pSourceOperation,
            [In] ushort fuFlags,
            [In, MarshalAs(UnmanagedType.LPWStr)] string pwszDestinationName,
            [In] ref IWMDMMetaData pSourceMetaData,
            [In] ref IWMDMProgress pTransferProgress,
            [Out] out IMDSPStorage ppNewObject);
    }
}
