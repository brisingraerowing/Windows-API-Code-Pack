//Copyright (c) Pierre Sprimont.  All rights reserved.

using Microsoft.WindowsAPICodePack.Win32Native;

using System;
using System.Runtime.InteropServices;

using static System.Runtime.InteropServices.UnmanagedType;

namespace Microsoft.WindowsAPICodePack.COMNative.MediaDevices
{
    [ComImport,
        Guid(NativeAPI.Guids.MediaDevices.IMDSPDirectTransfer),
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IMDSPDirectTransfer
    {
        [PreserveSig]
        HResult TransferToDevice(
            [In, MarshalAs(LPWStr)] string pwszSourceFilePath,
            [In, MarshalAs(Interface)] ref IWMDMOperation pSourceOperation,
            [In, MarshalAs(U2)] ushort fuFlags,
            [In, MarshalAs(LPWStr)] string pwszDestinationName,
            [In, MarshalAs(Interface)] ref IWMDMMetaData pSourceMetaData,
            [In, MarshalAs(Interface)] ref IWMDMProgress pTransferProgress,
            [Out, MarshalAs(Interface)] out IMDSPStorage ppNewObject);
    }
}
