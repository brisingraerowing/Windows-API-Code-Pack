//Copyright (c) Microsoft Corporation.  All rights reserved.  Distributed under the Microsoft Public License (MS-PL)

using Microsoft.WindowsAPICodePack.Resources;
using Microsoft.WindowsAPICodePack.Win32Native.ApplicationServices;

using System;
using System.Runtime.InteropServices;

namespace Microsoft.WindowsAPICodePack.ApplicationServices
{
    internal static class Power
    {
        internal static PowerManagementNativeMethods.SystemPowerCapabilities
            GetSystemPowerCapabilities() => PowerManagementNativeMethods.CallNtPowerInformation(
              PowerManagementNativeMethods.PowerInformationLevel.SystemPowerCapabilities,
              IntPtr.Zero, 0, out PowerManagementNativeMethods.SystemPowerCapabilities powerCap,
              (uint)Marshal.SizeOf(typeof(PowerManagementNativeMethods.SystemPowerCapabilities))
              ) == NativeAPI.Consts.Common.StatusAccessDenied
                ? throw new UnauthorizedAccessException(LocalizedMessages.PowerInsufficientAccessCapabilities)
                : powerCap;

        internal static PowerManagementNativeMethods.SystemBatteryState GetSystemBatteryState() => PowerManagementNativeMethods.CallNtPowerInformation(
              PowerManagementNativeMethods.PowerInformationLevel.SystemBatteryState,
              IntPtr.Zero, 0, out PowerManagementNativeMethods.SystemBatteryState batteryState,
              (uint)Marshal.SizeOf(typeof(PowerManagementNativeMethods.SystemBatteryState))
              ) == NativeAPI.Consts.Common.StatusAccessDenied
                ? throw new UnauthorizedAccessException(LocalizedMessages.PowerInsufficientAccessBatteryState)
                : batteryState;

        /// <summary>
        /// Registers the application to receive power setting notifications 
        /// for the specific power setting event.
        /// </summary>
        /// <param name="handle">Handle indicating where the power setting 
        /// notifications are to be sent.</param>
        /// <param name="powerSetting">The GUID of the power setting for 
        /// which notifications are to be sent.</param>
        /// <returns>Returns a notification handle for unregistering 
        /// power notifications.</returns>
        internal static int RegisterPowerSettingNotification(IntPtr handle, Guid powerSetting) => PowerManagementNativeMethods.RegisterPowerSettingNotification(handle, ref powerSetting, 0);
    }
}
