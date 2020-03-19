//Copyright (c) Pierre Sprimont.  All rights reserved.

using Microsoft.WindowsAPICodePack.Win32Native;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Microsoft.WindowsAPICodePack. Win32Native.MediaDevices
{
    [ComImport,
        Guid(Guids.MediaDevices.IWMDMMetaData),
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IWMDMMetaData
    {
        [PreserveSig]
        HResult AddItem(
            [In] DataType Type,
            [In,MarshalAs(UnmanagedType.LPWStr)] string pwszTagName,
            [In] ref StringBuilder pValue,
            [In] ushort iLength);

        [PreserveSig]
        HResult QueryByName(
            [In,MarshalAs(UnmanagedType.LPWStr)] string pwszTagName,
            [Out] out DataType pType,
            [Out] out StringBuilder pValue,
            [Out] out ushort pcbLength);

        [PreserveSig]
        HResult QueryByIndex(
            [In] ushort iIndex,
            [Out] out IntPtr ppwszName,
            [Out] out DataType pType,
            [Out] out char[] ppValue,
            [Out] out ushort pcbLength);

        [PreserveSig]
        HResult GetItemCount(
            [Out] out ushort iCount);
    }
}
