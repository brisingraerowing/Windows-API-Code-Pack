//Copyright (c) Microsoft Corporation.  All rights reserved.  Distributed under the Microsoft Public License (MS-PL)

using Microsoft.WindowsAPICodePack.Resources;
using Microsoft.WindowsAPICodePack.Win32Native.ApplicationServices;

using System;

namespace Microsoft.WindowsAPICodePack.ApplicationServices
{
    /// <summary>
    /// A snapshot of the state of the battery.
    /// </summary>
    public class BatteryState
    {
        #region Public properties
        /// <summary>
        /// Gets a value that indicates whether the battery charger is operating on external power.
        /// </summary>
        /// <value>A <see cref="bool"/> value. <see langword="true"/> indicates the battery charger is operating on AC power.</value>
        public bool ACOnline { get; private set; }

        /// <summary>
        /// Gets the maximum charge of the battery (in mW).
        /// </summary>
        public int MaxCharge { get; private set; }

        /// <summary>
        /// Gets the current charge of the battery (in mW).
        /// </summary>
        public int CurrentCharge { get; private set; }

        /// <summary>
        /// Gets the rate of discharge for the battery (in mW). 
        /// </summary>
        /// <remarks>
        /// <para><b>If plugged in, <i>fully charged</i>:</b> <see cref="ChargeRate"/> = 0.</para>
        /// <para><b>If plugged in, <i>charging</i>:</b> <see cref="ChargeRate"/> = positive mW per hour.</para>
        /// <para><b>If unplugged</b>: <see cref="ChargeRate"/> = negative mW per hour.</para>
        /// </remarks>
        public int ChargeRate { get; private set; }

        /// <summary>
        /// Gets the estimated time remaining until the battery is empty.
        /// </summary>
        public TimeSpan EstimatedTimeRemaining { get; private set; }

        /// <summary>
        /// Gets the manufacturer's suggested battery charge level that should cause a critical alert to be sent to the user.
        /// </summary>
        public int SuggestedCriticalBatteryCharge { get; private set; }

        /// <summary>
        /// Gets the manufacturer's suggested battery charge level that should cause a warning to be sent to the user.
        /// </summary>
        public int SuggestedBatteryWarningCharge { get; private set; }
        #endregion

        internal BatteryState()
        {
            PowerManagementNativeMethods.SystemBatteryState state = Power.GetSystemBatteryState();

            ACOnline = state.BatteryPresent ? state.AcOnLine : throw new InvalidOperationException(LocalizedMessages.PowerManagerBatteryNotPresent);
            MaxCharge = (int)state.MaxCapacity;
            CurrentCharge = (int)state.RemainingCapacity;
            ChargeRate = (int)state.Rate;

            uint estimatedTime = state.EstimatedTime;
            EstimatedTimeRemaining = estimatedTime == uint.MaxValue ? TimeSpan.MaxValue : new TimeSpan(0, 0, (int)estimatedTime);

            SuggestedCriticalBatteryCharge = (int)state.DefaultAlert1;
            SuggestedBatteryWarningCharge = (int)state.DefaultAlert2;
        }

        /// <summary>
        /// Generates a string that represents this <see cref="BatteryState"/> object.
        /// </summary>
        /// <returns>A <see cref="string"/> representation of this object's current state.</returns>        
        public override string ToString() => string.Format(System.Globalization.CultureInfo.InvariantCulture,
                LocalizedMessages.BatteryStateStringRepresentation,
                Environment.NewLine,
                ACOnline,
                MaxCharge,
                CurrentCharge,
                ChargeRate,
                EstimatedTimeRemaining,
                SuggestedCriticalBatteryCharge,
                SuggestedBatteryWarningCharge
                );
    }
}
