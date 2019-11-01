using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAPICodePack.Win32Native.Core;
using Microsoft.WindowsAPICodePack.Win32Native.PortableDevices.ClientInterfaces;

namespace Microsoft.WindowsAPICodePack.Win32Native.PortableDevices.CoClasses.ClientClasses
{
    [ComImport,
        Guid(WPDCOMGuids.PortableDeviceManager),
        ClassInterface(ClassInterfaceType.None),
        TypeLibType(TypeLibTypeFlags.FCanCreate)]
    public class PortableDeviceManager : IPortableDeviceManager
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public extern virtual HResult GetDevices(
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPWStr)] string[] pPnPDeviceIDs,
            [In, Out] ref uint pcPnPDeviceIDs);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public extern virtual HResult RefreshDeviceList();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public extern virtual HResult GetDeviceFriendlyName(
            [ In, MarshalAs(UnmanagedType.LPWStr)]  string pszPnPDeviceID, 
            [ In, Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pDeviceFriendlyName, 
            [In,Out] ref uint pcchDeviceFriendlyName);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public extern virtual HResult GetDeviceDescription(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pszPnPDeviceID, 
            [In,Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pDeviceDescription, 
            [In,Out] ref uint pcchDeviceDescription);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public extern virtual HResult GetDeviceManufacturer(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pszPnPDeviceID, 
            [In,Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pDeviceManufacturer, 
            [In,Out] ref uint pcchDeviceManufacturer);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public extern virtual HResult GetDeviceProperty(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pszPnPDeviceID, 
            [In, MarshalAs(UnmanagedType.LPWStr)] string pszDevicePropertyName, 
            [In,Out, MarshalAs(UnmanagedType.LPWStr)] ref byte pData, 
            [In,Out] ref uint pcbData, 
            [In,Out] ref uint pdwType);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public extern virtual HResult GetPrivateDevices(
            [In,Out, MarshalAs(UnmanagedType.LPWStr)] string[] pPnPDeviceIDs, 
            [In,Out] ref uint pcPnPDeviceIDs);
    }
}
