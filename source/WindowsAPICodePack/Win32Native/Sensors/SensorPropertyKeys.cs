// Copyright (c) Microsoft Corporation.  All rights reserved.

using System;
using Microsoft.WindowsAPICodePack.PropertySystem;
using Microsoft.WindowsAPICodePack.Win32Native.PropertySystem;
using Microsoft.WindowsAPICodePack.Win32Native.Shell.PropertySystem;

namespace Microsoft.WindowsAPICodePack.Sensors
{

    namespace EventSystem

    {

        public static class Parameter

        {

            public static PropertyKey EventId => new PropertyKey(Guids.EventSystem.ParameterCommon, 2);
            public static PropertyKey State => new PropertyKey(Guids.EventSystem.ParameterCommon, 3); // [VT_UI4]

        }

    }

    public static class PropertySystem

    {

        public static PropertyKey Type => new PropertyKey(Guids.PropertySystem.PropertyCommon, 2); //[VT_CLSID]

        public static PropertyKey State => new PropertyKey(Guids.PropertySystem.PropertyCommon, 3); //[VT_UI4]

        public static PropertyKey SamplingRate => new PropertyKey(Guids.PropertySystem.PropertyCommon, 4);

        public static PropertyKey PersistentUniqueID => new PropertyKey(Guids.PropertySystem.PropertyCommon, 5); //[VT_CLSID]

        public static PropertyKey Manufacturer => new PropertyKey(Guids.PropertySystem.PropertyCommon, 6); //[VT_LPWSTR]

        public static PropertyKey Model => new PropertyKey(Guids.PropertySystem.PropertyCommon, 7); //[VT_LPWSTR]

        public static PropertyKey SerialNumber => new PropertyKey(Guids.PropertySystem.PropertyCommon, 8); //[VT_LPWSTR]

        public static PropertyKey FriendlyName => new PropertyKey(Guids.PropertySystem.PropertyCommon, 9); //[VT_LPWSTR]

        public static PropertyKey Description => new PropertyKey(Guids.PropertySystem.PropertyCommon, 10); //[VT_LPWSTR]

        public static PropertyKey ConnectionType => new PropertyKey(Guids.PropertySystem.PropertyCommon, 11); //[VT_UI4]

        public static PropertyKey MinReportInterval => new PropertyKey(Guids.PropertySystem.PropertyCommon, 12); //[VT_UI4]

        public static PropertyKey CurrentReportInterval => new PropertyKey(Guids.PropertySystem.PropertyCommon, 13); //[VT_UI4]

        public static PropertyKey ChangeSensitivity => new PropertyKey(Guids.PropertySystem.PropertyCommon, 14); //[VT_UNKNOWN], IPortableDeviceValues

        public static PropertyKey DevicePath => new PropertyKey(Guids.PropertySystem.PropertyCommon, 15); //[VT_LPWSTR]

        public static PropertyKey LightResponseCurve => new PropertyKey(Guids.PropertySystem.PropertyCommon, 16); //[VT_VECTOR|VT_UI1]

        public static PropertyKey Accuracy => new PropertyKey(Guids.PropertySystem.PropertyCommon, 17); //[VT_UNKNOWN], IPortableDeviceValues

        public static PropertyKey Resolution => new PropertyKey(Guids.PropertySystem.PropertyCommon, 18); //[VT_UNKNOWN], IPortableDeviceValues

        public static PropertyKey LocationDesiredAccuracy => new PropertyKey(Guids.PropertySystem.PropertyCommon, 19); //[VT_UI4]

        public static PropertyKey RangeMinimum => new PropertyKey(Guids.PropertySystem.PropertyCommon, 20); //[VT_UNKNOWN], IPortableDeviceValues

        public static PropertyKey RangeMaximum => new PropertyKey(Guids.PropertySystem.PropertyCommon, 21); //[VT_UNKNOWN], IPortableDeviceValues

        public static PropertyKey HidUsage => new PropertyKey(Guids.PropertySystem.PropertyCommon, 22); //[VT_UI4]

        public static PropertyKey RadioState => new PropertyKey(Guids.PropertySystem.PropertyCommon, 23); //[VT_UI4]

        public static PropertyKey RadioStatePrevious => new PropertyKey(Guids.PropertySystem.PropertyCommon, 24); //[VT_UI4]

    }

    public static class DataType

    {
        public static PropertyKey Timestamp => new PropertyKey(Guids.DataType.Common, 2); //[VT_FILETIME]

        public static class Location

        {

            // LATITUDE: Degrees latitude where North is positive
            public static PropertyKey LatitudeDegrees => new PropertyKey(Guids.DataType.Location, 2); //[VT_R8]
                                                                                                      // LONGITUDE: Degrees longitude where East is positive
            public static PropertyKey LongitudeDegrees => new PropertyKey(Guids.DataType.Location, 3); //[VT_R8]
                                                                                                       // ALTITUDE_SEALEVEL_METERS: Altitude with regards to sea level, in meters
            public static PropertyKey AltitudeSeaLevelMeters => new PropertyKey(Guids.DataType.Location, 4); //[VT_R8]
                                                                                                             // ALTITUDE_ELLIPSOID_METERS: Altitude with regards to ellipsoid, in meters
            public static PropertyKey AltitudeEllipsoidMeters => new PropertyKey(Guids.DataType.Location, 5); //[VT_R8]
                                                                                                              // SPEED_KNOTS: Speed measured in knots
            public static PropertyKey SpeedKnots => new PropertyKey(Guids.DataType.Location, 6); //[VT_R8]
                                                                                                 // TRUE_HEADING_DEGREES: Heading relative to true North in degrees
            public static PropertyKey TrueHeadingDegrees => new PropertyKey(Guids.DataType.Location, 7); //[VT_R8]
                                                                                                         // MAGNETIC_HEADING_DEGREES: Heading relative to magnetic North in degrees
            public static PropertyKey MagneticHeadingDegrees => new PropertyKey(Guids.DataType.Location, 8); //[VT_R8]
                                                                                                             // MAGNETIC_VARIATION: Magnetic variation. East is positive
            public static PropertyKey MagneticVariation => new PropertyKey(Guids.DataType.Location, 9); //[VT_R8]
                                                                                                        // FIX_QUALITY: Quality of fix
            public static PropertyKey FixQuality => new PropertyKey(Guids.DataType.Location, 10); //[VT_I4]
                                                                                                  // FIX_TYPE: Fix Type
            public static PropertyKey FixType => new PropertyKey(Guids.DataType.Location, 11); //[VT_I4]
                                                                                               // POSITION_DILUTION_OF_PRECISION: Position Dilution of Precision
            public static PropertyKey PositionDilutionOfPrecision => new PropertyKey(Guids.DataType.Location, 12); //[VT_R8]
                                                                                                                   // HORIZONAL_DILUTION_OF_PRECISION: HORIZONTAL Dilution of Precision
            public static PropertyKey HorizonalDilutionOfPrecision => new PropertyKey(Guids.DataType.Location, 13); //[VT_R8]
                                                                                                                    // VERTICAL_DILUTION_OF_PRECISION: VERTICAL Dilution of Precision
            public static PropertyKey VerticalDilutionOfPrecision => new PropertyKey(Guids.DataType.Location, 14); //[VT_R8]
                                                                                                                   // SATELLITES_USED_COUNT: Number of satellites used in solution
            public static PropertyKey SatellitesUsedCount => new PropertyKey(Guids.DataType.Location, 15); //[VT_I4]
                                                                                                           // SATELLITES_USED_PRNS: PRN numbers of satellites used in the solution
            public static PropertyKey SatellitesUsedPRNS => new PropertyKey(Guids.DataType.Location, 16); //[VT_VECTOR | VT_UI1]
                                                                                                          // SATELLITES_IN_VIEW: Number of satellites in view.  From 0-GPS_MAX_SATELLITES
            public static PropertyKey SatellitesInView => new PropertyKey(Guids.DataType.Location, 17); //[VT_I4]
                                                                                                        // SATELLITES_IN_VIEW_PRNS: PRN numbers of satellites in view
            public static PropertyKey SatellitesInViewPRNS => new PropertyKey(Guids.DataType.Location, 18); //[VT_VECTOR | VT_UI1]
                                                                                                            // SATELLITES_IN_VIEW_ELEVATION: Elevation of each sattellite in view
            public static PropertyKey SatellitesInViewElevation => new PropertyKey(Guids.DataType.Location, 19); //[VT_VECTOR | VT_UI1]
                                                                                                                 // SATELLITES_IN_VIEW_AZIMUTH: Azimuth of each satellite in view
            public static PropertyKey SatellitesInViewAzimuth => new PropertyKey(Guids.DataType.Location, 20); //[VT_VECTOR | VT_UI1
                                                                                                               // SATELLITES_IN_VIEW_STN_RATIO: Signal to noise ratio for each satellite in view
            public static PropertyKey SatellitesInViewSTNRatio => new PropertyKey(Guids.DataType.Location, 21); //[VT_VECTOR | VT_UI1]
                                                                                                                // ERROR_RADIUS_METERS: Accuracy of Latitude and Longitude values
            public static PropertyKey ErrorRadiusMeters => new PropertyKey(Guids.DataType.Location, 22); //[VT_R8]
                                                                                                         // ADDRESS1: AddressLine1
            public static PropertyKey Address1 => new PropertyKey(Guids.DataType.Location, 23); //[VT_LPWSTR]
                                                                                                // ADDRESS2: AddressLine2
            public static PropertyKey Address2 => new PropertyKey(Guids.DataType.Location, 24); //[VT_LPWSTR]
                                                                                                // CITY: City
            public static PropertyKey City => new PropertyKey(Guids.DataType.Location, 25); //[VT_LPWSTR]
                                                                                            // STATE_PROVINCE: State/Province
            public static PropertyKey StateProvince => new PropertyKey(Guids.DataType.Location, 26); //[VT_LPWSTR]
                                                                                                     // POSTALCODE: Postal Code (e.g. ZIP)
            public static PropertyKey PostalCode => new PropertyKey(Guids.DataType.Location, 27); //[VT_LPWSTR]
                                                                                                  // COUNTRY_REGION: Country/Region
            public static PropertyKey CountryRegion => new PropertyKey(Guids.DataType.Location, 28); //[VT_LPWSTR]
                                                                                                     // ALTITUDE_ELLIPSOID_ERROR_METERS: Altitude Error with regards to ellipsoid, in meters
            public static PropertyKey AltitudeEllipsoidErrorMeters => new PropertyKey(Guids.DataType.Location, 29); //[VT_R8]
                                                                                                                    // ALTITUDE_SEALEVEL_ERROR_METERS: Altitude Error with regards to sea level, in meters
            public static PropertyKey AltitudeSeaLevelErrorMeters => new PropertyKey(Guids.DataType.Location, 30); //[VT_R8]
                                                                                                                   // GPS_SELECTION_MODE:
            public static PropertyKey GPSSelectionMode => new PropertyKey(Guids.DataType.Location, 31); //[VT_I4]
                                                                                                        // GPS_OPERATION_MODE:
            public static PropertyKey GPSOperationMode => new PropertyKey(Guids.DataType.Location, 32); //[VT_I4]
                                                                                                        // GPS_STATUS:
            public static PropertyKey GPSStatus => new PropertyKey(Guids.DataType.Location, 33); //[VT_I4]
                                                                                                 // GEOIDAL_SEPARATION:
            public static PropertyKey GeoidalSeparation => new PropertyKey(Guids.DataType.Location, 34); //[VT_R8]
                                                                                                         // DGPS_DATA_AGE:
            public static PropertyKey DGPSDataAge => new PropertyKey(Guids.DataType.Location, 35); //[VT_R8]
                                                                                                   // ALTITUDE_ANTENNA_SEALEVEL_METERS:
            public static PropertyKey AltitudeAntennaSeaLevelMeters => new PropertyKey(Guids.DataType.Location, 36); //[VT_R8]
                                                                                                                     // DIFFERENTIAL_REFERENCE_STATION_ID:
            public static PropertyKey DifferentialReferenceStationId => new PropertyKey(Guids.DataType.Location, 37); //[VT_I4]
                                                                                                                      // NMEA_SENTENCE:
            public static PropertyKey NMEASentence => new PropertyKey(Guids.DataType.Location, 38); //[VT_LPWSTR]
                                                                                                    // SATELLITES_IN_VIEW_ID:
            public static PropertyKey SatellitesInViewId => new PropertyKey(Guids.DataType.Location, 39); //[VT_VECTOR|VT_UI1]
                                                                                                          // LOCATION_SOURCE:
            public static PropertyKey LocationSource => new PropertyKey(Guids.DataType.Location, 40); //[VT_UI4]
                                                                                                      // SATELLITES_USED_PRNS_AND_CONSTELLATIONS: PRN numbers and constellation information of satellites used in the solution
            public static PropertyKey SatellitesUsedPRNSAndConstellations => new PropertyKey(Guids.DataType.Location, 41); //[VT_VECTOR | VT_UI2]

        }

        public static class Environmental

        {

            public static PropertyKey TemperatureCelsius => new PropertyKey(Guids.DataType.Environmental, 2); //[VT_R4]
            public static PropertyKey RelativeHumidityPercent => new PropertyKey(Guids.DataType.Environmental, 3); //[VT_R4]
            public static PropertyKey AtmosphericPressureBar => new PropertyKey(Guids.DataType.Environmental, 4); //[VT_R4]
            public static PropertyKey WindDirectionDegreesAnticlockwise => new PropertyKey(Guids.DataType.Environmental, 5); //[VT_R4]
            public static PropertyKey WindSpeedMetersPerSecond => new PropertyKey(Guids.DataType.Environmental, 6); //[VT_R4]

        }

        public static class Motion

        {

            // Accelerometer Data Types
            public static PropertyKey AccelerationXG => new PropertyKey(Guids.DataType.Motion, 2); //[VT_R8]
            public static PropertyKey AccelerationYG => new PropertyKey(Guids.DataType.Motion, 3); //[VT_R8]
            public static PropertyKey AccelerationZG => new PropertyKey(Guids.DataType.Motion, 4); //[VT_R8]
                                                                                                   // Gyrometer Data Types
            public static PropertyKey AngularAccelerationXDegreesPerSecondSquared => new PropertyKey(Guids.DataType.Motion, 5); //[VT_R8]
            public static PropertyKey AngularAccelerationYDegreesPerSecondSquared => new PropertyKey(Guids.DataType.Motion, 6); //[VT_R8]
            public static PropertyKey AngularAccelerationZDegreesPerSecondSquared => new PropertyKey(Guids.DataType.Motion, 7); //[VT_R8]
            public static PropertyKey SpeedMetersPerSecond => new PropertyKey(Guids.DataType.Motion, 8); //[VT_R8]
            public static PropertyKey MotionState => new PropertyKey(Guids.DataType.Motion, 9); //[VT_BOOL]
                                                                                                // Additional Motion Data Types
            public static PropertyKey AngularVelocityXDegreesPerSecond => new PropertyKey(Guids.DataType.Motion, 10); //[VT_R8]
            public static PropertyKey AngularVelocityYDegreesPerSecond => new PropertyKey(Guids.DataType.Motion, 11); //[VT_R8]
            public static PropertyKey AngularVelocityZDegreesPerSecond => new PropertyKey(Guids.DataType.Motion, 12); //[VT_R8]

        }

        public static class Orientation

        {

            // Inclinometer Data Types
            public static PropertyKey TiltXDegrees => new PropertyKey(Guids.DataType.Orientation, 2); //[VT_R4]
            public static PropertyKey TiltYDegrees => new PropertyKey(Guids.DataType.Orientation, 3); //[VT_R4]
            public static PropertyKey TiltZDegrees => new PropertyKey(Guids.DataType.Orientation, 4); //[VT_R4]
                                                                                                      // Compass Data Types
            public static PropertyKey MagneticHeadingXDegrees => new PropertyKey(Guids.DataType.Orientation, 5); //[VT_R4]
            public static PropertyKey MagneticHeadingYDegrees => new PropertyKey(Guids.DataType.Orientation, 6); //[VT_R4]
            public static PropertyKey MagneticHeadingZDegrees => new PropertyKey(Guids.DataType.Orientation, 7); //[VT_R4]
                                                                                                                 // Distance Data Types
            public static PropertyKey DistanceXMeters => new PropertyKey(Guids.DataType.Orientation, 8); //[VT_R4]
            public static PropertyKey DistanceYMeters => new PropertyKey(Guids.DataType.Orientation, 9); //[VT_R4]
            public static PropertyKey DistanceZMeters => new PropertyKey(Guids.DataType.Orientation, 10); //[VT_R4]
                                                                                                          // Additional Compass Data Types
            public static PropertyKey MagneticHeadingCompensatedMagneticNorthDegrees => new PropertyKey(Guids.DataType.Orientation, 11); //[VT_R8]
            public static PropertyKey MagneticHeadingCompensatedTrueNorthDegrees => new PropertyKey(Guids.DataType.Orientation, 12); //[VT_R8]
            public static PropertyKey MagneticHeadingMagneticNorthDegrees => new PropertyKey(Guids.DataType.Orientation, 13); //[VT_R8]
            public static PropertyKey MagneticHeadingTrueNorthDegrees => new PropertyKey(Guids.DataType.Orientation, 14); //[VT_R8]
                                                                                                                          // Additional Orientation Data Types
            public static PropertyKey QuadrantAngleDegrees => new PropertyKey(Guids.DataType.Orientation, 15); //[VT_R8]
            public static PropertyKey RotationMatrix => new PropertyKey(Guids.DataType.Orientation, 16); //[VT_VECTOR|VT_UI1]
            public static PropertyKey Quaternion => new PropertyKey(Guids.DataType.Orientation, 17); //[VT_VECTOR|VT_UI1]
            public static PropertyKey SimpleDeviceOrientation => new PropertyKey(Guids.DataType.Orientation, 18); //[VT_UI4]
                                                                                                                  // Compass (Magnetometer) Data Types
            public static PropertyKey MagneticFieldStrengthXMilligauss => new PropertyKey(Guids.DataType.Orientation, 19); //[VT_R8]
            public static PropertyKey MagneticFieldStrengthYMilligauss => new PropertyKey(Guids.DataType.Orientation, 20); //[VT_R8]
            public static PropertyKey MagneticFieldStrengthZMilligauss => new PropertyKey(Guids.DataType.Orientation, 21); //[VT_R8]
                                                                                                                           // Magnetometer Accuracy Data Types
            public static PropertyKey Magnetometer_accuracy => new PropertyKey(Guids.DataType.Orientation, 22); //[VT_I4]

        }

        public static class Mechanical

        {

            public static PropertyKey BooleanSwitchState => new PropertyKey(Guids.DataType.Mechanical, 2); //[VT_BOOL]
            public static PropertyKey MultivalueSwitchState => new PropertyKey(Guids.DataType.Mechanical, 3); //[VT_R8]
            public static PropertyKey ForceNewtons => new PropertyKey(Guids.DataType.Mechanical, 4); //[VT_R8]
            public static PropertyKey AbsolutePressurePascal => new PropertyKey(Guids.DataType.Mechanical, 5); //[VT_R8]
            public static PropertyKey GaugePressurePascal => new PropertyKey(Guids.DataType.Mechanical, 6); //[VT_R8]
            public static PropertyKey Strain => new PropertyKey(Guids.DataType.Mechanical, 7); //[VT_R8]
            public static PropertyKey WeightKilograms => new PropertyKey(Guids.DataType.Mechanical, 8); //[VT_R8]
            public static PropertyKey BooleanSwitchArrayStates => new PropertyKey(Guids.DataType.Mechanical, 10); //[VT_UI4]
        }

        public static class Biometric

        {

            public static PropertyKey HumanPresence => new PropertyKey(Guids.DataType.Biometric, 2); //[VT_BOOL]
            public static PropertyKey HumanProximityMeters => new PropertyKey(Guids.DataType.Biometric, 3); //[VT_R4]
            public static PropertyKey TouchState => new PropertyKey(Guids.DataType.Biometric, 4); //[VT_BOOL]

        }

        public static class Light

        {

            // Ambient light in LUX, Lumens per square meter, the ACPI convention for reporting ambient light values
            public static PropertyKey LightLevelLux => new PropertyKey(Guids.DataType.Light, 2); //[VT_R4]
            public static PropertyKey LightTemperatureKelvin => new PropertyKey(Guids.DataType.Light, 3); //[VT_R4]
            public static PropertyKey LightChromacity => new PropertyKey(Guids.DataType.Light, 4); //[VT_VECTOR|VT_UI1]

        }
        // EM4102 RFID protocol uses 40 bit tags, stored in 64 bit value: VT_UI8
        public static PropertyKey RFIDTag40Bit => new PropertyKey(Guids.DataType.Scanner, 2); //[VT_UI8]

        public static class Electrical

        {

            public static PropertyKey VoltageVolts => new PropertyKey(Guids.DataType.Electrical, 2); //[VT_R8]
            public static PropertyKey CurrentAmps => new PropertyKey(Guids.DataType.Electrical, 3); //[VT_R8]
            public static PropertyKey CapacitanceFarad => new PropertyKey(Guids.DataType.Electrical, 4); //[VT_R8]
            public static PropertyKey ResistanceOHMS => new PropertyKey(Guids.DataType.Electrical, 5); //[VT_R8]
            public static PropertyKey InductanceHenry => new PropertyKey(Guids.DataType.Electrical, 6); //[VT_R8]
            public static PropertyKey ElectricalPowerWatts => new PropertyKey(Guids.DataType.Electrical, 7); //[VT_R8]
            public static PropertyKey ElectricalPercentOfRange => new PropertyKey(Guids.DataType.Electrical, 8); //[VT_R8]
            public static PropertyKey ElectricalFrequencyHertz => new PropertyKey(Guids.DataType.Electrical, 9); //[VT_R8]

        }

        //
        // Custom Sensor Data Types (additions to sensors.h)
        //

        public static class Custom

        {

            public static PropertyKey Usage => new PropertyKey(Guids.DataType.Custom, 5);    //[VT_UI4]
            public static PropertyKey Boolean_array => new PropertyKey(Guids.DataType.Custom, 6);    //[VT_UI4]
            public static PropertyKey Value1 => new PropertyKey(Guids.DataType.Custom, 7);    //[VT_UI4||VT_R4]
            public static PropertyKey Value2 => new PropertyKey(Guids.DataType.Custom, 8);    //[VT_UI4||VT_R4]
            public static PropertyKey Value3 => new PropertyKey(Guids.DataType.Custom, 9);    //[VT_UI4||VT_R4]
            public static PropertyKey Value4 => new PropertyKey(Guids.DataType.Custom, 10);   //[VT_UI4||VT_R4]
            public static PropertyKey Value5 => new PropertyKey(Guids.DataType.Custom, 11);   //[VT_UI4||VT_R4]
            public static PropertyKey Value6 => new PropertyKey(Guids.DataType.Custom, 12);   //[VT_UI4||VT_R4]
            public static PropertyKey Value7 => new PropertyKey(Guids.DataType.Custom, 13);   //[VT_UI4||VT_R4]
            public static PropertyKey Value8 => new PropertyKey(Guids.DataType.Custom, 14);   //[VT_UI4||VT_R4]
            public static PropertyKey Value9 => new PropertyKey(Guids.DataType.Custom, 15);   //[VT_UI4||VT_R4]
            public static PropertyKey Value10 => new PropertyKey(Guids.DataType.Custom, 16);   //[VT_UI4||VT_R4]
            public static PropertyKey Value11 => new PropertyKey(Guids.DataType.Custom, 17);   //[VT_UI4||VT_R4]
            public static PropertyKey Value12 => new PropertyKey(Guids.DataType.Custom, 18);   //[VT_UI4||VT_R4]
            public static PropertyKey Value13 => new PropertyKey(Guids.DataType.Custom, 19);   //[VT_UI4||VT_R4]
            public static PropertyKey Value14 => new PropertyKey(Guids.DataType.Custom, 20);   //[VT_UI4||VT_R4]
            public static PropertyKey Value15 => new PropertyKey(Guids.DataType.Custom, 21);   //[VT_UI4||VT_R4]
            public static PropertyKey Value16 => new PropertyKey(Guids.DataType.Custom, 22);   //[VT_UI4||VT_R4]
            public static PropertyKey Value17 => new PropertyKey(Guids.DataType.Custom, 23);   //[VT_UI4||VT_R4]
            public static PropertyKey Value18 => new PropertyKey(Guids.DataType.Custom, 24);   //[VT_UI4||VT_R4]
            public static PropertyKey Value19 => new PropertyKey(Guids.DataType.Custom, 25);   //[VT_UI4||VT_R4]
            public static PropertyKey Value20 => new PropertyKey(Guids.DataType.Custom, 26);   //[VT_UI4||VT_R4]
            public static PropertyKey Value21 => new PropertyKey(Guids.DataType.Custom, 27);   //[VT_UI4||VT_R4]
            public static PropertyKey Value22 => new PropertyKey(Guids.DataType.Custom, 28);   //[VT_UI4||VT_R4]
            public static PropertyKey Value23 => new PropertyKey(Guids.DataType.Custom, 29);   //[VT_UI4||VT_R4]
            public static PropertyKey Value24 => new PropertyKey(Guids.DataType.Custom, 30);   //[VT_UI4||VT_R4]
            public static PropertyKey Value25 => new PropertyKey(Guids.DataType.Custom, 31);   //[VT_UI4||VT_R4]
            public static PropertyKey Value26 => new PropertyKey(Guids.DataType.Custom, 32);   //[VT_UI4||VT_R4]
            public static PropertyKey Value27 => new PropertyKey(Guids.DataType.Custom, 33);   //[VT_UI4||VT_R4]
            public static PropertyKey Value28 => new PropertyKey(Guids.DataType.Custom, 34);   //[VT_UI4||VT_R4]

        }

        ////

        /// <summary>
        /// The sensor angle in degrees (X-axis) property key.
        /// </summary>
        public static PropertyKey AngleXDegrees => new PropertyKey(new Guid(0XC2FB0F5F, 0XE2D2, 0X4C78, 0XBC, 0XD0, 0X35, 0X2A, 0X95, 0X82, 0X81, 0X9D), 2);

        /// <summary>
        /// The sensor angle in degrees (Y-axis) property key.
        /// </summary>
        public static PropertyKey AngleYDegrees => new PropertyKey(new Guid(0XC2FB0F5F, 0XE2D2, 0X4C78, 0XBC, 0XD0, 0X35, 0X2A, 0X95, 0X82, 0X81, 0X9D), 3);

        /// <summary>
        /// The sensor angle in degrees (Z-axis) property key.
        /// </summary>
        public static PropertyKey AngleZDegrees => new PropertyKey(new Guid(0XC2FB0F5F, 0XE2D2, 0X4C78, 0XBC, 0XD0, 0X35, 0X2A, 0X95, 0X82, 0X81, 0X9D), 4);

        /// <summary>
        /// The sensor magnetic heading (X-axis) property key.
        /// </summary>
        public static PropertyKey MagneticHeadingXDegrees => new PropertyKey(new Guid(0XC2FB0F5F, 0XE2D2, 0X4C78, 0XBC, 0XD0, 0X35, 0X2A, 0X95, 0X82, 0X81, 0X9D), 5);

        /// <summary>
        /// The sensor magnetic heading (Y-axis) property key.
        /// </summary>
        public static PropertyKey MagneticHeadingYDegrees => new PropertyKey(new Guid(0XC2FB0F5F, 0XE2D2, 0X4C78, 0XBC, 0XD0, 0X35, 0X2A, 0X95, 0X82, 0X81, 0X9D), 6);

        /// <summary>
        /// The sensor magnetic heading (Z-axis) property key.
        /// </summary>
        public static PropertyKey MagneticHeadingZDegrees => new PropertyKey(new Guid(0XC2FB0F5F, 0XE2D2, 0X4C78, 0XBC, 0XD0, 0X35, 0X2A, 0X95, 0X82, 0X81, 0X9D), 7);

        /// <summary>
        /// The sensor distance (X-axis) data property key.
        /// </summary>
        public static PropertyKey DistanceXMeters => new PropertyKey(new Guid(0XC2FB0F5F, 0XE2D2, 0X4C78, 0XBC, 0XD0, 0X35, 0X2A, 0X95, 0X82, 0X81, 0X9D), 8);

        /// <summary>
        /// The sensor distance (Y-axis) data property key.
        /// </summary>
        public static PropertyKey DistanceYMeters => new PropertyKey(new Guid(0XC2FB0F5F, 0XE2D2, 0X4C78, 0XBC, 0XD0, 0X35, 0X2A, 0X95, 0X82, 0X81, 0X9D), 9);

        /// <summary>
        /// The sensor distance (Z-axis) data property key.
        /// </summary>
        public static PropertyKey DistanceZMeters => new PropertyKey(new Guid(0XC2FB0F5F, 0XE2D2, 0X4C78, 0XBC, 0XD0, 0X35, 0X2A, 0X95, 0X82, 0X81, 0X9D), 10);
    }
}
