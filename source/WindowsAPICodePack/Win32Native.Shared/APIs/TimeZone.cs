// Copyright (c) Microsoft Corporation.  All rights reserved.

using System;
using System.Globalization;
using System.Runtime.InteropServices;
using static Microsoft.WindowsAPICodePack.Win32Native.Consts.DllNames;

namespace Microsoft.WindowsAPICodePack.Win32Native.TimeZone
{

    public static class TimeZone
    {
        [DllImport(Kernel32)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SystemTimeToFileTime(
            ref SystemTime lpSystemTime,
            out System.Runtime.InteropServices.ComTypes.FILETIME lpFileTime);
    }

    /// <summary>
    /// The SystemTime structure represents a date and time using individual members for 
    /// the month, day, year, weekday, hour, minute, second, and millisecond.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct SystemTime
    {
        internal ushort Year;
        internal ushort Month;
        internal ushort DayOfWeek;
        internal ushort Day;
        internal ushort Hour;
        internal ushort Minute;
        internal ushort Second;
        internal ushort Millisecond;

        /// <summary>
        /// Gets the <see cref="DateTime"/> representation of this object.
        /// </summary>
        public DateTime DateTime => new DateTime(Year, Month, Day, Hour, Minute, Second, Millisecond);

        public static implicit operator DateTime(SystemTime systemTime) => systemTime.DateTime;

        public override string ToString() => string.Format(CultureInfo.InvariantCulture.NumberFormat,
                "{0:D2}/{1:D2}/{2:D4}, {3:D2}:{4:D2}:{5:D2}.{6}",
                Month, Day, Year, Hour, Minute, Second, Millisecond);
    }
}
