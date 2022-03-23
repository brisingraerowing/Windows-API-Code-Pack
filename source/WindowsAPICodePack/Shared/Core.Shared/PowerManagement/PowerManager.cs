//Copyright (c) Microsoft Corporation.  All rights reserved.  Distributed under the Microsoft Public License (MS-PL)

using Microsoft.WindowsAPICodePack.Resources;
using Microsoft.WindowsAPICodePack.Win32Native;
using Microsoft.WindowsAPICodePack.Win32Native.ApplicationServices;

using System;
using System.ComponentModel;

using static Microsoft.WindowsAPICodePack.ApplicationServices.Guids.EventManager;

namespace Microsoft.WindowsAPICodePack.ApplicationServices
{
    /// <summary>
    /// Enables registration for 
    /// power-related event notifications and provides access to power settings.
    /// </summary>
    public static class PowerManager
    {
        private static bool? isMonitorOn;
        private static bool monitorRequired;
        private static bool requestBlockSleep;

        private static readonly object monitoronlock = new
#if !CS9
            object
#endif
            ();

        #region Notifications
        /// <summary>
        /// Raised each time the active power scheme changes.
        /// </summary>
        /// <exception cref="InvalidOperationException">The event handler specified for removal was not registered.</exception>
        /// <exception cref="PlatformNotSupportedException">Requires Vista/Windows Server 2008.</exception>
        public static event EventHandler PowerPersonalityChanged
        {
            add => MessageManager.RegisterPowerEvent(new Guid(PowerPersonalityChange), value);

            remove
            {
                CoreHelpers.ThrowIfNotVista();

                MessageManager.UnregisterPowerEvent(new Guid(PowerPersonalityChange), value);
            }
        }

        /// <summary>
        /// Raised when the power source changes.
        /// </summary>
        /// <exception cref="InvalidOperationException">The event handler specified for removal was not registered.</exception>
        /// <exception cref="PlatformNotSupportedException">Requires Vista/Windows Server 2008.</exception>
        public static event EventHandler PowerSourceChanged
        {
            add
            {
                CoreHelpers.ThrowIfNotVista();

                MessageManager.RegisterPowerEvent(new Guid(PowerSourceChange), value);
            }

            remove
            {
                CoreHelpers.ThrowIfNotVista();

                MessageManager.UnregisterPowerEvent(new Guid(PowerSourceChange), value);
            }
        }

        /// <summary>
        /// Raised when the remaining battery life changes.
        /// </summary>
        /// <exception cref="InvalidOperationException">The event handler specified for removal was not registered.</exception>
        /// <exception cref="PlatformNotSupportedException">Requires Vista/Windows Server 2008.</exception>
        public static event EventHandler BatteryLifePercentChanged
        {
            add
            {
                CoreHelpers.ThrowIfNotVista();

                MessageManager.RegisterPowerEvent(new Guid(BatteryCapacityChange), value);
            }

            remove
            {
                CoreHelpers.ThrowIfNotVista();

                MessageManager.UnregisterPowerEvent(new Guid(BatteryCapacityChange), value);
            }
        }

        /// <summary>
        /// Raised when the monitor status changes.
        /// </summary>
        /// <exception cref="InvalidOperationException">The event handler specified for removal was not registered.</exception>
        /// <exception cref="PlatformNotSupportedException">Requires Vista/Windows Server 2008.</exception>
        public static event EventHandler IsMonitorOnChanged
        {
            add
            {
                CoreHelpers.ThrowIfNotVista();

                MessageManager.RegisterPowerEvent(new Guid(MonitorPowerStatus), value);
            }

            remove
            {
                CoreHelpers.ThrowIfNotVista();

                MessageManager.UnregisterPowerEvent(new Guid(MonitorPowerStatus), value);
            }
        }

        /// <summary>
        /// Raised when the system will not be moving into an idle 
        /// state in the near future so applications should
        /// perform any tasks that 
        /// would otherwise prevent the computer from entering an idle state. 
        /// </summary>
        /// <exception cref="InvalidOperationException">The event handler specified for removal was not registered.</exception>
        /// <exception cref="PlatformNotSupportedException">Requires Vista/Windows Server 2008.</exception>
        public static event EventHandler SystemBusyChanged
        {
            add
            {
                CoreHelpers.ThrowIfNotVista();

                MessageManager.RegisterPowerEvent(new Guid(BackgroundTaskNotification), value);
            }

            remove
            {
                CoreHelpers.ThrowIfNotVista();

                MessageManager.UnregisterPowerEvent(new Guid(BackgroundTaskNotification), value);
            }
        }
        #endregion

        /// <summary>
        /// Gets a snapshot of the current battery state.
        /// </summary>
        /// <returns>A <see cref="BatteryState"/> instance that represents 
        /// the state of the battery at the time this method was called.</returns>
        /// <exception cref="InvalidOperationException">The system does not have a battery.</exception>
        /// <exception cref="PlatformNotSupportedException">Requires XP/Windows Server 2003 or higher.</exception>        
        public static BatteryState GetCurrentBatteryState()
        {
            CoreHelpers.ThrowIfNotXP();

            return new BatteryState();
        }

        #region Power System Properties
        /// <summary>
        /// Gets or sets a value that indicates whether the monitor is 
        /// set to remain active.  
        /// </summary>
        /// <exception cref="PlatformNotSupportedException">Requires XP/Windows Server 2003 or higher.</exception>
        /// <exception cref="System.Security.SecurityException">The caller does not have sufficient privileges to set this property.
        /// </exception>
        /// <remarks>This information is typically used by applications
        /// that display information but do not require 
        /// user interaction. For example, video playback applications.</remarks>
        /// <permission cref="System.Security.Permissions.SecurityPermission"> to set this property. Demand value: <see cref="System.Security.Permissions.SecurityAction.Demand"/>; Named Permission Sets: <b>FullTrust</b>.</permission>
        /// <value><see langword="true"/> if the monitor
        /// is required to remain on.</value>
        public static bool MonitorRequired
        {
            get
            {
                CoreHelpers.ThrowIfNotXP();

                return monitorRequired;
            }

            [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
            set
            {
                CoreHelpers.ThrowIfNotXP();

                ExecutionStates executionStates = ExecutionStates.Continuous;

                if (value)

                    executionStates |= ExecutionStates.DisplayRequired;

                SetThreadExecutionState(executionStates);

                monitorRequired = value;
            }
        }

        /// <summary>
        /// Gets or sets a value that indicates whether the system 
        /// is required to be in the working state.
        /// </summary>
        /// <exception cref="PlatformNotSupportedException">Requires XP/Windows Server 2003 or higher.</exception>
        /// <exception cref="System.Security.SecurityException">The caller does not have sufficient privileges to set this property.
        /// </exception>
        /// <permission cref="System.Security.Permissions.SecurityPermission"> to set this property. Demand value: <see cref="System.Security.Permissions.SecurityAction.Demand"/>; Named Permission Sets: <b>FullTrust</b>.</permission>
        public static bool RequestBlockSleep
        {
            get
            {
                CoreHelpers.ThrowIfNotXP();

                return requestBlockSleep;
            }

            [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
            set
            {
                CoreHelpers.ThrowIfNotXP();

                ExecutionStates executionStates = ExecutionStates.Continuous;

                if (value)

                    executionStates |= ExecutionStates.SystemRequired;

                SetThreadExecutionState(executionStates);

                requestBlockSleep = value;
            }
        }

        /// <summary>
        /// Gets a value that indicates whether a battery is present.  
        /// The battery can be a short term battery.
        /// </summary>
        /// <exception cref="PlatformNotSupportedException">Requires XP/Windows Server 2003 or higher.</exception>
        public static bool IsBatteryPresent
        {
            get
            {
                CoreHelpers.ThrowIfNotXP();

                return Power.GetSystemBatteryState().BatteryPresent;
            }
        }

        /// <summary>
        /// Gets a value that indicates whether the battery is a short term battery. 
        /// </summary>
        /// <exception cref="PlatformNotSupportedException">Requires XP/Windows Server 2003 or higher.</exception>
        public static bool IsBatteryShortTerm
        {
            get
            {
                CoreHelpers.ThrowIfNotXP();
                return Power.GetSystemPowerCapabilities().BatteriesAreShortTerm;
            }
        }

        /// <summary>
        /// Gets a value that indicates a UPS is present to prevent 
        /// sudden loss of power.
        /// </summary>
        /// <exception cref="PlatformNotSupportedException">Requires XP/Windows Server 2003 or higher.</exception>
        public static bool IsUpsPresent
        {
            get
            {
                CoreHelpers.ThrowIfNotXP();

                // Because the native method doesn't return the correct value for .UpsPresent,
                // use .BatteriesAreShortTerm and .SystemBatteriesPresent to check for UPS
                PowerManagementNativeMethods.SystemPowerCapabilities batt = Power.GetSystemPowerCapabilities();

                return batt.BatteriesAreShortTerm && batt.SystemBatteriesPresent;
            }
        }

        /// <summary>
        /// Gets a value that indicates the current power scheme.  
        /// </summary>
        /// <exception cref="PlatformNotSupportedException">Requires Vista/Windows Server 2008.</exception>
        /// <value>A <see cref="PowerPersonality"/> value.</value>
        public static PowerPersonality PowerPersonality
        {
            get
            {
                PowerManagementNativeMethods.PowerGetActiveScheme(IntPtr.Zero, out Guid guid);

                try
                {
                    return PowerPersonalityGuids.GuidToEnum(guid.ToString());
                }

                finally
                {
                    _ = Core.LocalFree(ref guid);
                }
            }
        }



        /// <summary>
        /// Gets a value that indicates the remaining battery life 
        /// (as a percentage of the full battery charge). 
        /// This value is in the range 0-100, 
        /// where 0 is not charged and 100 is fully charged.  
        /// </summary>
        /// <exception cref="InvalidOperationException">The system does not have a battery.</exception>
        /// <exception cref="PlatformNotSupportedException">Requires Vista/Windows Server 2008.</exception>
        /// <value>An <see cref="int"/> value.</value>
        public static int BatteryLifePercent
        {
            get
            {
                // Because of the way this value is being calculated, it should not be limited to granularity
                // as the data from the event (old way) was.
                CoreHelpers.ThrowIfNotVista();

                PowerManagementNativeMethods.SystemBatteryState state = Power.GetSystemBatteryState().BatteryPresent ? Power.GetSystemBatteryState() : throw new InvalidOperationException(LocalizedMessages.PowerManagerBatteryNotPresent);

                return (int)Math.Round((double)state.RemainingCapacity / state.MaxCapacity * 100, 0);
            }
        }

        /// <summary>
        /// Gets a value that indictates whether the monitor is on. 
        /// </summary>
        /// <exception cref="PlatformNotSupportedException">Requires Vista/Windows Server 2008.</exception>
        public static bool IsMonitorOn
        {
            get
            {
                CoreHelpers.ThrowIfNotVista();

                lock (monitoronlock)

                    if (isMonitorOn == null)
                    {
#if CS8
                        static
#endif
                            void dummy(object sender, EventArgs args)
                        { /* Left empty. */ }

                        IsMonitorOnChanged += dummy;

                        // Wait until Windows updates the power source 
                        // (through RegisterPowerSettingNotification)

                        _ = EventManager.monitorOnReset.WaitOne();
                    }

                return (bool)isMonitorOn;
            }

            internal set => isMonitorOn = value;
        }

        /// <summary>
        /// Gets the current power source.  
        /// </summary>
        /// <exception cref="PlatformNotSupportedException">Requires Vista/Windows Server 2008.</exception>
        /// <value>A <see cref="PowerSource"/> value.</value>
        public static PowerSource PowerSource
        {
            get
            {
                CoreHelpers.ThrowIfNotVista();

                return IsUpsPresent ? PowerSource.Ups : !IsBatteryPresent || GetCurrentBatteryState().ACOnline ? PowerSource.AC : PowerSource.Battery;
            }
        }
        #endregion

        /// <summary>
        /// Allows an application to inform the system that it 
        /// is in use, thereby preventing the system from entering 
        /// the sleeping power state or turning off the display 
        /// while the application is running.
        /// </summary>
        /// <param name="executionStateOptions">The thread's execution requirements.</param>
        /// <exception cref="Win32Exception">Thrown if the SetThreadExecutionState call fails.</exception>
        public static void SetThreadExecutionState(ExecutionStates executionStateOptions)
        {
            if (PowerManagementNativeMethods.SetThreadExecutionState(executionStateOptions) == ExecutionStates.None)

                throw new Win32Exception(LocalizedMessages.PowerExecutionStateFailed);
        }
    }
}
