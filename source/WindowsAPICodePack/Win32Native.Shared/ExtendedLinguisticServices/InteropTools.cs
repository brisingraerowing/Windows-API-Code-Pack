//Copyright (c) Microsoft Corporation.  All rights reserved.  Distributed under the Microsoft Public License (MS-PL)

using System;
using System.Runtime.InteropServices;

namespace Microsoft.WindowsAPICodePack.Win32Native.ExtendedLinguisticServices
{
    public static class InteropTools
    {
        // TODO: put these fields to Win32Native?
        public static readonly IntPtr SizeOfWin32EnumOptions = (IntPtr)Marshal.SizeOf(typeof(Win32EnumOptions));
        public static readonly IntPtr SizeOfWin32Options = (IntPtr)Marshal.SizeOf(typeof(Win32Options));
        public static readonly ulong SizeOfService = (ulong)Marshal.SizeOf(typeof(Win32Service));
        public static readonly IntPtr SizeOfWin32PropertyBag = (IntPtr)Marshal.SizeOf(typeof(Win32PropertyBag));
        public static readonly ulong SizeOfWin32DataRange = (ulong)Marshal.SizeOf(typeof(Win32DataRange));
        public static readonly ulong OffsetOfGuidInService = (ulong)Marshal.OffsetOf(typeof(Win32Service), "_guid");
    }
}
