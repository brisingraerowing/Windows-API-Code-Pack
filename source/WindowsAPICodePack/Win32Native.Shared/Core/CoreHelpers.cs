//Copyright (c) Microsoft Corporation.  All rights reserved.  Distributed under the Microsoft Public License (MS-PL)

using System;
using System.Globalization;
using System.Text;
using Microsoft.WindowsAPICodePack.Win32Native.Resources;
using static Microsoft.WindowsAPICodePack.Win32Native.Consts.DllNames;

namespace Microsoft.WindowsAPICodePack.Win32Native
{
    /// <summary>
    /// Common Helper methods
    /// </summary>
    public static class CoreHelpers
    {
        /// <summary>
        /// Determines if the application is running on XP
        /// </summary>
        public static bool RunningOnXP => Environment.OSVersion.Platform == PlatformID.Win32NT &&
                    Environment.OSVersion.Version.Major >= 5;

        /// <summary>
        /// Throws PlatformNotSupportedException if the application is not running on Windows XP
        /// </summary>
        public static void ThrowIfNotXP()
        {
            if (!RunningOnXP)

                throw new PlatformNotSupportedException(LocalizedMessages.CoreHelpersRunningOnXp);
        }

        /// <summary>
        /// Determines if the application is running on Vista
        /// </summary>
        public static bool RunningOnVista => Environment.OSVersion.Version.Major >= 6;

        /// <summary>
        /// Throws PlatformNotSupportedException if the application is not running on Windows Vista
        /// </summary>
        public static void ThrowIfNotVista()
        {
            if (!RunningOnVista)

                throw new PlatformNotSupportedException(LocalizedMessages.CoreHelpersRunningOnVista);
        }

        /// <summary>
        /// Determines if the application is running on Windows 7
        /// </summary>
        public static bool RunningOnWin7 =>
                // Verifies that OS version is 6.1 or greater, and the Platform is WinNT.
                Environment.OSVersion.Platform == PlatformID.Win32NT &&
                    Environment.OSVersion.Version.CompareTo(new Version(6, 1)) >= 0;

        /// <summary>
        /// Throws PlatformNotSupportedException if the application is not running on Windows 7
        /// </summary>
        public static void ThrowIfNotWin7()
        {
            if (!RunningOnWin7)

                throw new PlatformNotSupportedException(LocalizedMessages.CoreHelpersRunningOn7);
        }

        /// <summary>
        /// Determines if the application is running on Windows 8
        /// </summary>
        public static bool RunningOnWin8 => Environment.OSVersion.Platform == PlatformID.Win32NT &&
            Environment.OSVersion.Version.CompareTo(new Version(6, 2)) >= 0;

        /// <summary>
        /// Throws PlatformNotSupportedException if the application is not running on Windows 8
        /// </summary>
        public static void ThrowIfNotWin8()
        {

            if (!RunningOnWin8)

                throw new PlatformNotSupportedException(LocalizedMessages.CoreHelpersRunningOn8);

        }

        /// <summary>
        /// Determines if the application is running on Windows 8.1
        /// </summary>
        public static bool RunningOnWin8_1 => Environment.OSVersion.Platform == PlatformID.Win32NT &&
            Environment.OSVersion.Version.CompareTo(new Version(6, 3)) >= 0;

        /// <summary>
        /// Throws PlatformNotSupportedException if the application is not running on Windows 8.1
        /// </summary>
        public static void ThrowIfNotWin8_1()
        {

            if (!RunningOnWin8_1)

                throw new PlatformNotSupportedException(LocalizedMessages.CoreHelpersRunningOn8_1);

        }

        /// <summary>
        /// Determines if the application is running on Windows 10
        /// </summary>
        public static bool RunningOnWin10 => Environment.OSVersion.Platform == PlatformID.Win32NT &&
            Environment.OSVersion.Version.CompareTo(new Version(10, 0)) >= 0;

        /// <summary>
        /// Throws PlatformNotSupportedException if the application is not running on Windows 10
        /// </summary>
        public static void ThrowIfNotWin10()
        {

            if (!RunningOnWin10)

                throw new PlatformNotSupportedException(LocalizedMessages.CoreHelpersRunningOn10);

        }

        /// <summary>
        /// Get a string resource given a resource Id
        /// </summary>
        /// <param name="resourceId">The resource Id</param>
        /// <returns>The string resource corresponding to the given resource Id. Returns null if the resource id
        /// is invalid or the string cannot be retrieved for any other reason.</returns>
        public static string GetStringResource(string resourceId)
        {
            string[] parts;
            string library;
            int index;

            if (string.IsNullOrEmpty(resourceId)) return string.Empty;

            // Known folder "Recent" has a malformed resource id
            // for its tooltip. This causes the resource id to
            // parse into 3 parts instead of 2 parts if we don't fix.
            resourceId = resourceId.Replace("shell32,dll", Shell32);
            parts = resourceId.Split(new char[] { ',' });

            library = parts[0];
            library = library.Replace(@"@", string.Empty);
            library = Environment.ExpandEnvironmentVariables(library);
            IntPtr handle = Core.LoadLibrary(library);

            parts[1] = parts[1].Replace("-", string.Empty);
            index = int.Parse(parts[1], CultureInfo.InvariantCulture);

            var stringValue = new StringBuilder(255);

            return Core.LoadString(handle, index, stringValue, 255) == 0 ? null : stringValue.ToString();
        }
    }
}
