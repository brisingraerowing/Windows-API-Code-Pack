﻿//Copyright (c) Microsoft Corporation.  All rights reserved.  Distributed under the Microsoft Public License (MS-PL)

using Microsoft.WindowsAPICodePack.Resources;
using Microsoft.WindowsAPICodePack.Win32Native.ApplicationServices;

using static Microsoft.WindowsAPICodePack.ApplicationServices.ApplicationRestartRecoveryManager;

namespace Microsoft.WindowsAPICodePack.ApplicationServices
{
    /// <summary>
    /// Defines methods and properties for recovery settings, and specifies options for an application that attempts
    /// to perform final actions after a fatal event, such as an
    /// unhandled exception.
    /// </summary>
    /// <remarks>This class is used to register for application recovery.
    /// See the <see cref="ApplicationRestartRecoveryManager"/> class.
    /// </remarks>
    public class RecoverySettings
    {
        /// <summary>
        /// Gets the recovery data object that contains the callback method and an optional
        /// parameter (usually the state of the application) to be passed to the 
        /// callback method.
        /// </summary>
        /// <value>A <see cref="RecoveryData"/> object.</value>
        public RecoveryData RecoveryData { get; }

        /// <summary>
        /// Gets the time interval for notifying Windows Error Reporting.  
        /// The <see cref="RecoveryCallback"/> method must invoke <see cref="ApplicationRecoveryInProgress"/> 
        /// within this interval to prevent WER from terminating the application.
        /// </summary>
        /// <remarks>        
        /// The recovery ping interval is specified in milliseconds. 
        /// By default, the interval is 5 seconds. 
        /// If you specify zero, the default interval is used. 
        /// </remarks>
        public uint PingInterval { get; }

        /// <summary>
        /// Initializes a new instance of the <b>RecoverySettings</b> class.
        /// </summary>
        /// <param name="data">A recovery data object that contains the callback method (invoked by the system
        /// before Windows Error Reporting terminates the application) and an optional state object.</param>
        /// <param name="interval">The time interval within which the 
        /// callback method must invoke <see cref="ApplicationRecoveryInProgress"/> to 
        /// prevent WER from terminating the application.</param>
        /// <seealso cref="ApplicationRestartRecoveryManager"/>
        public RecoverySettings(in RecoveryData data, in uint interval)
        {
            RecoveryData = data;
            PingInterval = interval;
        }

        /// <summary>
        /// Returns a string representation of the current state
        /// of this object.
        /// </summary>
        /// <returns>A <see cref="string"/> object.</returns>
        public override string ToString() => string.Format(System.Globalization.CultureInfo.InvariantCulture,
                LocalizedMessages.RecoverySettingsFormatString,
                RecoveryData.Callback.Method.ToString(),
                RecoveryData.State.ToString(),
                PingInterval);
    }
}
