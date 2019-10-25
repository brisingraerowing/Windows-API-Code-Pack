// Copyright (c) Microsoft Corporation.  All rights reserved.

using System.Runtime.InteropServices;

namespace Microsoft.WindowsAPICodePack.Win32Native.Sensors
{

    public static class SensorNativeMethods
    {
        [DllImport("kernel32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SystemTimeToFileTime(
            ref SystemTime lpSystemTime,
            out System.Runtime.InteropServices.ComTypes.FILETIME lpFileTime);
    }
}
