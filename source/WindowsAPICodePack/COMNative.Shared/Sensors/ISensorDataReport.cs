//Copyright (c) Microsoft Corporation.  All rights reserved.  Distributed under the Microsoft Public License (MS-PL)

using System;
using System.Globalization;
using System.Runtime.InteropServices;
using Microsoft.WindowsAPICodePack.PropertySystem;
using Microsoft.WindowsAPICodePack.COMNative.PortableDevices;
using Microsoft.WindowsAPICodePack.COMNative.PortableDevices.PropertySystem;
using Microsoft.WindowsAPICodePack.COMNative.PropertySystem;
using Microsoft.WindowsAPICodePack.COMNative.Shell.PropertySystem;
using GuidAttribute = System.Runtime.InteropServices.GuidAttribute;
using Microsoft.WindowsAPICodePack.Win32Native.TimeZone;
using Microsoft.WindowsAPICodePack.Win32Native.PropertySystem;

namespace Microsoft.WindowsAPICodePack.COMNative.Sensors
{

    /// <summary>
    /// COM interop wrapper for the ISensorDataReport interface.
    /// </summary>
    [ComImport, Guid("0AB9DF9B-C4B5-4796-8898-0470706A2E1D"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ISensorDataReport
    {
        /// <summary>
        /// Get the timestamp for the data report
        /// </summary>
        /// <param name="timeStamp">The timestamp returned for the data report</param>
        void GetTimestamp(out SystemTime timeStamp);

        /// <summary>
        /// Get a single value reported by the sensor
        /// </summary>
        /// <param name="propKey">The data field ID of interest</param>
        /// <param name="propValue">The data returned</param>
        void GetSensorValue(
            [In] ref PropertyKey propKey,
            [Out] PropVariant propValue);

        /// <summary>
        /// Get multiple values reported by a sensor
        /// </summary>
        /// <param name="keys">The collection of keys for values to obtain data for</param>
        /// <param name="values">The values returned by the query</param>
        void GetSensorValues(
            [In, MarshalAs(UnmanagedType.Interface)] IPortableDeviceKeyCollection keys,
            [Out, MarshalAs(UnmanagedType.Interface)] out IPortableDeviceValues values);
    }
}
