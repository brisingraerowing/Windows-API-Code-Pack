using Microsoft.WindowsAPICodePack.Win32Native.Core;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Microsoft.WindowsAPICodePack. Win32Native.MediaDevices.ClientInterfaces
{
    [ComImport,
        Guid(Guids.MediaDevices.IWMDMMetaData),
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IWMDMMetaData
    {
        HResult AddItem(
            [In] WMDM_TAG_DATATYPE Type,
            [In,MarshalAs(UnmanagedType.LPWStr)] string pwszTagName,
            [In] ref StringBuilder pValue,
            [In] ushort iLength);
        
        HResult QueryByName(
            [In,MarshalAs(UnmanagedType.LPWStr)] string pwszTagName,
            [Out] out WMDM_TAG_DATATYPE pType,
            [Out] out StringBuilder pValue,
            [Out] out ushort pcbLength);
        
        HResult QueryByIndex(
            [In] ushort iIndex,
            [Out] out IntPtr ppwszName,
            [Out] out WMDM_TAG_DATATYPE pType,
            [Out] out char[] ppValue,
            [Out] out ushort pcbLength);
        
        HResult GetItemCount(
            [Out] out ushort iCount);
    }
}
