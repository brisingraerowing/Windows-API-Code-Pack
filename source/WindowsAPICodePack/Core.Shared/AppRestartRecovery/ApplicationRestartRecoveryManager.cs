//Copyright (c) Microsoft Corporation.  All rights reserved.  Distributed under the Microsoft Public License (MS-PL)

using Microsoft.WindowsAPICodePack.Resources;
using Microsoft.WindowsAPICodePack.Win32Native;
using Microsoft.WindowsAPICodePack.Win32Native.ApplicationServices;

using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

using static WinCopies.
#if WAPICP3
    ThrowHelper
#else
    Util.Util
#endif
    ;

namespace Microsoft.WindowsAPICodePack.ApplicationServices
{
    /// <summary>
    /// Provides access to the Application Restart and Recovery
    /// features available in Windows Vista or higher. Application Restart and Recovery lets an
    /// application do some recovery work to save data before the process exits.
    /// </summary>
    public static class ApplicationRestartRecoveryManager
    {
        /// <summary>
        /// Registers an application for recovery by Application Restart and Recovery.
        /// </summary>
        /// <param name="settings">An object that specifies the callback method, an optional parameter to pass to the callback method and a time interval.</param>
        /// <exception cref="ArgumentException">The registration failed due to an invalid parameter.</exception>
        /// <exception cref="Win32Exception">The registration failed.</exception>
        /// <remarks>The time interval is the period of time within which the recovery callback method calls the <see cref="ApplicationRecoveryInProgress"/> method to indicate that it is still performing recovery work.</remarks>
        public static void RegisterForApplicationRecovery(in RecoverySettings settings)
        {
            CoreHelpers.ThrowIfNotVista();

            ThrowIfNull(settings, nameof(settings));

            HResult hr = AppRestartRecoveryNativeMethods.RegisterApplicationRecoveryCallback(
                AppRestartRecoveryNativeMethods.RecoveryCallback, (IntPtr)GCHandle.Alloc(settings.RecoveryData), settings.PingInterval, 0);

            if (!CoreErrorHelper.Succeeded(hr))

                throw hr == HResult.InvalidArguments
                    ?
#if !CS9
                    (SystemException)
#endif
                    new ArgumentException(LocalizedMessages.ApplicationRecoveryBadParameters, nameof(settings))
                    : new ApplicationRecoveryException(LocalizedMessages.ApplicationRecoveryFailedToRegister);
        }

        private static void UnregisterApplication(in Func<HResult> action, in string msg)
        {
            CoreHelpers.ThrowIfNotVista();

            if (!CoreErrorHelper.Succeeded(action()))

                throw new ApplicationRecoveryException(msg);
        }

        /// <summary>
        /// Removes an application's recovery registration.
        /// </summary>
        /// <exception cref="ApplicationRecoveryException">
        /// The attempt to unregister for recovery failed.</exception>
        public static void UnregisterApplicationRecovery() => UnregisterApplication(AppRestartRecoveryNativeMethods.UnregisterApplicationRecoveryCallback, LocalizedMessages.ApplicationRecoveryFailedToUnregister);

        /// <summary>
        /// Removes an application's restart registration.
        /// </summary>
        /// <exception cref="ApplicationRecoveryException">
        /// The attempt to unregister for restart failed.</exception>
        public static void UnregisterApplicationRestart() => UnregisterApplication(AppRestartRecoveryNativeMethods.UnregisterApplicationRestart, LocalizedMessages.ApplicationRecoveryFailedToUnregisterForRestart);

        /// <summary>
        /// Called by an application's <see cref="RecoveryCallback"/> method 
        /// to indicate that it is still performing recovery work.
        /// </summary>
        /// <returns>A <see cref="bool"/> value indicating whether the user
        /// canceled the recovery.</returns>
        /// <exception cref="ApplicationRecoveryException">
        /// This method must be called from a registered callback method.</exception>
        public static bool ApplicationRecoveryInProgress()
        {
            CoreHelpers.ThrowIfNotVista();

            HResult hr = AppRestartRecoveryNativeMethods.ApplicationRecoveryInProgress(out bool canceled);

            return CoreErrorHelper.Succeeded(hr) ? canceled : throw new InvalidOperationException(LocalizedMessages.ApplicationRecoveryMustBeCalledFromCallback);
        }

        /// <summary>
        /// Called by an application's <see cref="RecoveryCallback"/> method to 
        /// indicate that the recovery work is complete.
        /// </summary>
        /// <remarks>
        /// This should
        /// be the last call made by the <see cref="RecoveryCallback"/> method because
        /// Windows Error Reporting will terminate the application
        /// after this method is invoked.
        /// </remarks>
        /// <param name="success"><see langword="true"/> to indicate that the program was able to complete its recovery
        /// work before terminating; otherwise <b>false</b>.</param>
        public static void ApplicationRecoveryFinished(in bool success)
        {
            CoreHelpers.ThrowIfNotVista();

            AppRestartRecoveryNativeMethods.ApplicationRecoveryFinished(success);
        }

        /// <summary>
        /// Registers an application for automatic restart if the application is terminated by Windows Error Reporting.
        /// </summary>
        /// <param name="settings">An object that specifies the command line arguments used to restart the application, and the conditions under which the application should not be restarted.</param>
        /// <exception cref="ArgumentException">Registration failed due to an invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">The attempt to register failed.</exception>
        /// <remarks>A registered application will not be restarted if it executed for less than 60 seconds before terminating.</remarks>
        public static void RegisterForApplicationRestart(in RestartSettings settings)
        {
            // Throw PlatformNotSupportedException if the user is not running Vista or beyond
            CoreHelpers.ThrowIfNotVista();

            switch (AppRestartRecoveryNativeMethods.RegisterApplicationRestart((settings ?? throw GetArgumentNullException(nameof(settings))).Command, settings.Restrictions))
            {
                case HResult.Fail:
                    throw new InvalidOperationException(LocalizedMessages.ApplicationRecoveryFailedToRegisterForRestart);
                case HResult.InvalidArguments:
                    throw new ArgumentException(LocalizedMessages.ApplicationRecoverFailedToRegisterForRestartBadParameters);
            }
        }
    }
}

