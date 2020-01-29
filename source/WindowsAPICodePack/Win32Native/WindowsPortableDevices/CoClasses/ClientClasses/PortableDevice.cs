using Microsoft.WindowsAPICodePack.Win32Native;
using Microsoft.WindowsAPICodePack.Win32Native.PortableDevices;
using Microsoft.WindowsAPICodePack.Win32Native.PortableDevices.PropertySystem;
using Microsoft.WindowsAPICodePack.Win32Native.PortableDevices.PropertySystem.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.WindowsAPICodePack.Win32Native.PortableDevices
{
    [ComImport,
        Guid(Win32Native.Guids.PortableDevices.PortableDeviceFTM),
        ClassInterface(ClassInterfaceType.None),
        TypeLibType(TypeLibTypeFlags.FCanCreate)]
    public class PortableDevice : IPortableDevice
    {
        [PreserveSig]
        public extern virtual HResult Open(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pszPnPDeviceID,
            [In, MarshalAs(UnmanagedType.Interface)] ref IPortableDeviceValues pClientInfo);

        [PreserveSig]
        public extern virtual HResult SendCommand(
            [In] uint dwFlags,
            [In, MarshalAs(UnmanagedType.Interface)] ref IPortableDeviceValues pParameters,
            [Out, MarshalAs(UnmanagedType.Interface)] out IPortableDeviceValues ppResults);

        [PreserveSig]
        public extern virtual HResult Content(
            [Out, MarshalAs(UnmanagedType.Interface)] out IPortableDeviceContent ppContent);

        [PreserveSig]
        public extern virtual HResult Capabilities(
            [Out, MarshalAs(UnmanagedType.Interface)] out IPortableDeviceCapabilities ppCapabilities);

        [PreserveSig]
        public virtual extern HResult Cancel();

        [PreserveSig]
        public virtual extern HResult Close();

        [PreserveSig]
        public virtual extern HResult Advise(
            [In] uint dwFlags,
            [In, MarshalAs(UnmanagedType.Interface)] ref IPortableDeviceEventCallback pCallback,
            [In, MarshalAs(UnmanagedType.Interface)] ref IPortableDeviceValues pParameters,
            [Out, MarshalAs(UnmanagedType.LPWStr)] out string ppszCookie);

        [PreserveSig]
        public virtual extern HResult Unadvise(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pszCookie);

        public virtual extern HResult GetPnPDeviceID(
            [Out, MarshalAs(UnmanagedType.LPWStr)] out string ppszPnPDeviceID);
    }
}
