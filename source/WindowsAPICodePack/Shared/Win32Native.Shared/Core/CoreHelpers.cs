//Main of the code is Copyright (c) Microsoft Corporation.  All rights reserved.  Distributed under the Microsoft Public License (MS-PL)

//Some parts are: Copyright (c) 2018 Jacques Kang and distributed under the MIT License:

/* Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE. */

using Microsoft.WindowsAPICodePack.Win32Native.Resources;

using System;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Text;

using static Microsoft.WindowsAPICodePack.NativeAPI.Consts.DllNames;
using static Microsoft.WindowsAPICodePack.Win32Native.Resources.LocalizedMessages;

using static System.Environment;

namespace Microsoft.WindowsAPICodePack
{
    public struct Color
    {
        public byte R { get; }
        public byte G{ get; }
        public byte B { get; }

        public Color(in byte r, in byte g, in byte b)
        {
            R = r;
            G = g;
            B = b;
        }
    }

    public struct TransparentColor
    {
        public byte A { get; }

        public Color Color { get; }

        public TransparentColor(in byte a, in Color color)
        {
            A = a;
            Color = color;
        }
    }

    namespace Win32Native
    {
        /// <summary>
        /// Common Helper methods
        /// </summary>
        public static class CoreHelpers
        {
#if !NETSTANDARD || NETSTANDARD2_1_OR_GREATER
            public static T GetTypedObjectForIUnknown<T>(in IntPtr intPtr) => (T)Marshal.GetTypedObjectForIUnknown(intPtr, typeof(T));

            public static T QueryInterfaceForIUnknown<T>(in IntPtr intPtr, ref Guid guid) => CoreErrorHelper.Succeeded(Marshal.QueryInterface(intPtr, ref guid, out IntPtr intPtr2)) ? GetTypedObjectForIUnknown<T>(intPtr2) : default;

            public static T QueryInterfaceForIUnknown2<T>(in IntPtr intPtr, in Guid guid)
            {
                Guid _guid = guid;

                return QueryInterfaceForIUnknown<T>(intPtr, ref _guid);
            }

            public static T QueryInterfaceForIUnknown<T>(in IntPtr intPtr, in string guid) => QueryInterfaceForIUnknown2<T>(intPtr, new Guid(guid));
#endif

            public static void UpdateValue<T>(ref T value, in T newValue) where T : class
            {
                if (value != null)

                    _ = Marshal.ReleaseComObject(value);

                value = newValue;
            }

            public static void DisposeCOMObject<T>(ref T
#if CS9
                ?
#endif
                value) where T : class
            {
                if (value != null)
                {
                    _ = Marshal.ReleaseComObject(value);

                    value = null;
                }
            }

            public static SecurityAttributes GetSecurityAttributes(GCHandle securityDescriptorPinnedHandle, bool inheritHandle = false)
            {
                var securityAttributes = new SecurityAttributes { bInheritHandle = inheritHandle };

                securityAttributes.nLength = (uint)Marshal.SizeOf(securityAttributes);
                securityAttributes.lpSecurityDescriptor = securityDescriptorPinnedHandle.AddrOfPinnedObject();
                return securityAttributes;
            }

            /// <summary>
            /// Determines if the application is running on XP
            /// </summary>
            public static bool RunningOnXP => OSVersion.Platform == PlatformID.Win32NT && OSVersion.Version.Major >= 5;

            private static void ThrowIfPlatformNotSupported(in bool condition, in string errorMessage)
            {
                if (!condition)

                    throw new PlatformNotSupportedException(errorMessage);
            }

            /// <summary>
            /// Throws PlatformNotSupportedException if the application is not running on Windows XP
            /// </summary>
            public static void ThrowIfNotXP() => ThrowIfPlatformNotSupported(RunningOnXP, CoreHelpersRunningOnXp);

            /// <summary>
            /// Determines if the application is running on Vista
            /// </summary>
            public static bool RunningOnVista => OSVersion.Version.Major >= 6;

            /// <summary>
            /// Throws PlatformNotSupportedException if the application is not running on Windows Vista
            /// </summary>
            public static void ThrowIfNotVista() => ThrowIfPlatformNotSupported(RunningOnVista, CoreHelpersRunningOnVista);

            /// <summary>
            /// Determines if the application is running on Windows 7
            /// </summary>
            public static bool RunningOnWin7 =>
                    // Verifies that OS version is 6.1 or greater, and the Platform is WinNT.
                    OSVersion.Platform == PlatformID.Win32NT && OSVersion.Version.CompareTo(new Version(6, 1)) >= 0;

            /// <summary>
            /// Throws PlatformNotSupportedException if the application is not running on Windows 7
            /// </summary>
            public static void ThrowIfNotWin7()
            {
                if (!RunningOnWin7)

                    throw new PlatformNotSupportedException(CoreHelpersRunningOn7);
            }

            /// <summary>
            /// Determines if the application is running on Windows 8
            /// </summary>
            public static bool RunningOnWin8 => OSVersion.Platform == PlatformID.Win32NT && OSVersion.Version.CompareTo(new Version(6, 2)) >= 0;

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
            public static bool RunningOnWin8_1 => OSVersion.Platform == PlatformID.Win32NT && OSVersion.Version.CompareTo(new Version(6, 3)) >= 0;

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
            public static bool RunningOnWin10 => OSVersion.Platform == PlatformID.Win32NT && OSVersion.Version.CompareTo(new Version(10, 0)) >= 0;

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
                library = ExpandEnvironmentVariables(library);
                IntPtr handle = Core.LoadLibrary(library);

                parts[1] = parts[1].Replace("-", string.Empty);
                index = int.Parse(parts[1], CultureInfo.InvariantCulture);

                var stringValue = new StringBuilder(255);

                return Core.LoadString(handle, index, stringValue, 255) == 0 ? null : stringValue.ToString();
            }
        }
    }
}
