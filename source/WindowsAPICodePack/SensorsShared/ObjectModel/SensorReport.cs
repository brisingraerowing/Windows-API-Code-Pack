// Copyright (c) Microsoft Corporation.  All rights reserved.

using Microsoft.WindowsAPICodePack.Win32Native.Sensors;
using System;
using System.Runtime.InteropServices.ComTypes;

namespace Microsoft.WindowsAPICodePack.Sensors
{
    /// <summary>
    /// Represents all the data from a single sensor data report.
    /// </summary>
    public class SensorReport
    {
        /// <summary>
        /// Gets the time when the data report was generated.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", MessageId = "TimeStamp")]
        public DateTime TimeStamp { get; private set; } = new DateTime();

        /// <summary>
        /// Gets the data values in the report.
        /// </summary>
        public SensorData Values { get; private set; }

        /// <summary>
        /// Gets the sensor that is the source of this data report.
        /// </summary>
        public Sensor Source { get; private set; }

        #region implementation

        internal static SensorReport FromNativeReport(in Sensor originator, in ISensorDataReport iReport)
        {
            iReport.GetTimestamp(out SystemTime systemTimeStamp);
            _ = SensorNativeMethods.SystemTimeToFileTime(ref systemTimeStamp, out FILETIME ftTimeStamp);
            long lTimeStamp = (((long)ftTimeStamp.dwHighDateTime) << 32) + ftTimeStamp.dwLowDateTime;
            var sensorReport = new SensorReport
            {
                Source = originator
            };
            var timeStamp = DateTime.FromFileTime(lTimeStamp);
            sensorReport.TimeStamp = timeStamp;
            sensorReport.Values = SensorData.FromNativeReport(originator.InternalObject, iReport);

            return sensorReport;
        }
        #endregion

    }
}
