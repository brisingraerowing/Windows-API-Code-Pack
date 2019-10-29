// Copyright (c) Microsoft Corporation.  All rights reserved.

using System;
using Microsoft.WindowsAPICodePack.Sensors;
using Xunit;
using Xunit.Extensions;

namespace Tests
{
    public class UnknownSensorTests
    {
        [Fact]
        public void ConstructAndConfirmThatGettersThrow()
        {
            var us = new UnknownSensor();

            _ = Assert.Throws<SensorPlatformException>(() => { bool b = us.AutoUpdateDataReport; }); // BUG: Inconsistency with the rest of the API
            _ = Assert.Throws<NullReferenceException>(() => { Guid? g = us.CategoryId; });
            _ = Assert.Throws<NullReferenceException>(() => { SensorConnectionType? t = us.ConnectionType; });
            Assert.Null(us.DataReport);   // BUG: Inconsistency
            _ = Assert.Throws<NullReferenceException>(() => { string s = us.Description; });
            _ = Assert.Throws<NullReferenceException>(() => { string s = us.DevicePath; });
            _ = Assert.Throws<NullReferenceException>(() => { string s = us.FriendlyName; });
            _ = Assert.Throws<NullReferenceException>(() => { string s = us.Manufacturer; });
            _ = Assert.Throws<NullReferenceException>(() => { uint u = us.MinimumReportInterval; });
            _ = Assert.Throws<NullReferenceException>(() => { string s = us.Model; });
            _ = Assert.Throws<NullReferenceException>(() => { uint u = us.ReportInterval; });
            _ = Assert.Throws<NullReferenceException>(() => { Guid? g = us.SensorId; });
            _ = Assert.Throws<NullReferenceException>(() => { string s = us.SerialNumber; });
            _ = Assert.Throws<NullReferenceException>(() => { SensorState s = us.State; });
            _ = Assert.Throws<NullReferenceException>(() => { Guid? g = us.TypeId; });
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void AutoUpdateDataReportPropertySetterThrows(bool autoUpdate)
        {
            var us = new UnknownSensor();
            _ = Assert.Throws<SensorPlatformException>(() => { us.AutoUpdateDataReport = autoUpdate; }); // BUG: Inconsistency with the rest of the API
        }

        [Theory]
        [InlineData(uint.MinValue)]
        [InlineData(uint.MinValue + 1)]
        [InlineData(uint.MinValue + 2)]
        [InlineData(uint.MaxValue - 1)]
        [InlineData(uint.MaxValue)]
        public void ReportIntervalPropertySetterThrows(uint interval)
        {
            var us = new UnknownSensor();
            _ = Assert.Throws<NullReferenceException>(() => { us.ReportInterval = interval; });
        }
    }
}
