using Microsoft.WindowsAPICodePack.Win32Native.Core;
using Microsoft.WindowsAPICodePack.Win32Native.PortableDevices;
using Microsoft.WindowsAPICodePack.Win32Native.PortableDevices.ClientInterfaces;
using Microsoft.WindowsAPICodePack.Win32Native.PortableDevices.CollectionInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.WindowsAPICodePack.Win32Native.PortableDevices.CoClasses.ClientClasses
{
    [ComImport,
        Guid(WPDCOMGuids.PortableDeviceFTM),
        ClassInterface(ClassInterfaceType.None),
        TypeLibType(TypeLibTypeFlags.FCanCreate)]
    public class PortableDevice : IPortableDevice
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public extern virtual HResult Open(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pszPnPDeviceID,
            [In, MarshalAs(UnmanagedType.Interface)] ref IPortableDeviceValues pClientInfo);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public extern virtual HResult SendCommand(
            [In] uint dwFlags,
            [In, MarshalAs(UnmanagedType.Interface)] ref IPortableDeviceValues pParameters,
            [Out, MarshalAs(UnmanagedType.Interface)] out IPortableDeviceValues ppResults);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public extern virtual HResult Content(
            [Out, MarshalAs(UnmanagedType.Interface)] out IPortableDeviceContent ppContent);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public extern virtual HResult Capabilities(
            [Out, MarshalAs(UnmanagedType.Interface)] out IPortableDeviceCapabilities ppCapabilities);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HResult Cancel();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HResult Close();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HResult Advise(
            [In] uint dwFlags,
            [In, MarshalAs(UnmanagedType.Interface)] ref IPortableDeviceEventCallback pCallback,
            [In, MarshalAs(UnmanagedType.Interface)] ref IPortableDeviceValues pParameters,
            [Out, MarshalAs(UnmanagedType.LPWStr)] out string ppszCookie);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HResult Unadvise(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pszCookie);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HResult GetPnPDeviceID(
            [Out, MarshalAs(UnmanagedType.LPWStr)] out string ppszPnPDeviceID);
    }
}
