//Copyright (c) Pierre Sprimont.  All rights reserved.

using Microsoft.WindowsAPICodePack.Win32Native;

using System;
using System.Runtime.InteropServices;
using System.Text;

using static System.Runtime.InteropServices.UnmanagedType;

namespace Microsoft.WindowsAPICodePack.COMNative.MediaDevices
{
    [ComImport,
        Guid(NativeAPI.Guids.MediaDevices.IWMDMMetaData),
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IWMDMMetaData
    {
        [PreserveSig]
        HResult AddItem(
            [In] DataType Type,
            [In, MarshalAs(LPWStr)] string pwszTagName,
            [In] ref StringBuilder pValue,
            [In, MarshalAs(U2)] ushort iLength);

        [PreserveSig]
        HResult QueryByName(
            [In, MarshalAs(LPWStr)] string pwszTagName,
            [Out] out DataType pType,
            [Out] out StringBuilder pValue,
            [Out, MarshalAs(U2)] out ushort pcbLength);

        [PreserveSig]
        HResult QueryByIndex(
            [In, MarshalAs(U2)] ushort iIndex,
            [Out] out IntPtr ppwszName,
            [Out] out DataType pType,
            [Out] out char[] ppValue,
            [Out, MarshalAs(U2)] out ushort pcbLength);

        [PreserveSig]
        HResult GetItemCount(
            [Out, MarshalAs(U2)] out ushort iCount);
    }
}
