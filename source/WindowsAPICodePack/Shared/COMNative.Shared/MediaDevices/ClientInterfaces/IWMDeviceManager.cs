//Copyright (c) Pierre Sprimont.  All rights reserved.

using Microsoft.WindowsAPICodePack.Win32Native;

using System;
using System.Runtime.InteropServices;

using static System.Runtime.InteropServices.UnmanagedType;

namespace Microsoft.WindowsAPICodePack.COMNative.MediaDevices
{
    [ComImport,
        Guid(NativeAPI.Guids.MediaDevices.IWMDeviceManager),
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IWMDeviceManager
    {
        [PreserveSig]
        HResult GetRevision(
            [Out, MarshalAs(U4)] out uint pdwRevision);

        [PreserveSig]
        HResult GetDeviceCount(
            [Out, MarshalAs(U4)] out uint pdwCount);

        [PreserveSig]
        HResult EnumDevices(
            [Out, MarshalAs(Interface)] out IWMDMEnumDevice ppEnumDevice);
    }

    [ComImport,
        Guid(NativeAPI.Guids.MediaDevices.IWMDeviceManager2)]
    public interface IWMDeviceManager2 : IWMDeviceManager
    {
        [PreserveSig]
        HResult GetDeviceFromCanonicalName(
            [In, MarshalAs(LPWStr)] string pwszCanonicalName,
            [Out, MarshalAs(Interface)] out IWMDMDevice ppDevice);

        [PreserveSig]
        HResult EnumDevices2(
            [Out, MarshalAs(Interface)] out IWMDMEnumDevice ppEnumDevice);

        [PreserveSig]
        HResult Reinitialize();
    }

    [Flags]
    public enum DeviceEnumPreferences : uint
    {
        /// <summary>
        /// By default, for devices containing multiple storage media (for example, multiple flash memory cards), each of these storages enumerates as a separate pseudo-device. However, when this flag is set, storages are not visible as devices, and only devices are visible as devices. See <see cref="IWMDeviceManager3.SetDeviceEnumPreference(DeviceEnumPreferences)"/> Remarks for more information.
        /// </summary>
        DoNotVirtualizeStoragesAsDevices = 0x00000001,

        /// <summary>
        /// When this flag is set, the service provider can send device arrival and removal by an additional mechanism, such as by using a window message, as well as the default mechanism of calling any application-implemented IWMDMNotification interfaces.
        /// </summary>
        AllowOutOfBandNotification = 0x00000002
    }

    [ComImport,
        Guid(NativeAPI.Guids.MediaDevices.IWMDeviceManager3)]
    public interface IWMDeviceManager3 : IWMDeviceManager2
    {
        /// <summary>
        /// The <see cref="SetDeviceEnumPreference"/> method sets the device enumeration preferences.
        /// </summary>
        /// <param name="dwEnumPref">Specifies a bitwise OR combination of one or more of the following bit values that specify enumeration preference. Each set bit enables the corresponding extended behavior, whereas the absence of that bit disables the extended behavior and specifies the default, backward-compatible enumeration behavior. The possible values for fuPrefs are provided in the <see cref="DeviceEnumPreferences"/> interface.</param>
        /// <returns><para>The method returns an <see cref="HResult"/>. Possible values include, but are not limited to, those in the following table.</para>
        /// <para><see cref="HResult.Ok"/>: The method succeeded.</para>
        /// <para><see cref="HResult.InvalidArguments"/>: The fuPrefs parameter specifies an unsupported bit value.</para>
        /// <para><see cref="HResult.WMDMCallOutOfSequence"/>: The method was called after an enumeration operation; it must be called before the enumeration operation.</para></returns>
        /// <remarks><para>This method provides clients the ability to override the default device enumeration behavior of Windows Media Device Manager. In order to override the default behavior, the client application must call this method immediately after creating the device manager object by querying for the <see cref="IWMDeviceManager3"/> interface from Media Device Manager. The call must be made before any enumeration occurs, either explicitly or implicitly as a result of another operation.</para>
        /// <para>After a preference flag is set, it cannot be changed for the lifetime of the application (not just the lifetime of the Windows Media Device Manager object). Attempting to change a preference flag will result in an error. Calling this method again with the same flag settings does not return an error, and also does have any effect on enumeration.</para>
        /// <para>The service provider may not honor the <see cref="DeviceEnumPreferences.DoNotVirtualizeStoragesAsDevices"/> flag. A more robust way to determine if storages are hosted by the same device is to call <see cref="IWMDMDevice2.GetCanonicalName"/>. Storages from the same device will return identical values, except for the final digit after the last "$" character.</para></remarks>
        [PreserveSig]
        HResult SetDeviceEnumPreference(
            [In, MarshalAs(U4)] DeviceEnumPreferences dwEnumPref);
    }
}
