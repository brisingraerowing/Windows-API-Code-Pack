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
        public static PropertyKey TIMESTAMP=>new PropertyKey(Guids.DataType.Common, 2); //[VT_FILETIME]

        public static class Location

        {

            // LATITUDE: Degrees latitude where North is positive
            public static PropertyKey LATITUDE_DEGREES                   => new PropertyKey(Guids.DataType.Location,  2); //[VT_R8]
                                                                                                                                                                    // LONGITUDE: Degrees longitude where East is positive
            public static PropertyKey LONGITUDE_DEGREES                  => new PropertyKey(Guids.DataType.Location,  3); //[VT_R8]
                                                                                                                                                                    // ALTITUDE_SEALEVEL_METERS: Altitude with regards to sea level, in meters
            public static PropertyKey ALTITUDE_SEALEVEL_METERS           => new PropertyKey(Guids.DataType.Location,  4); //[VT_R8]
                                                                                                                                                                    // ALTITUDE_ELLIPSOID_METERS: Altitude with regards to ellipsoid, in meters
            public static PropertyKey ALTITUDE_ELLIPSOID_METERS          => new PropertyKey(Guids.DataType.Location,  5); //[VT_R8]
                                                                                                                                                                    // SPEED_KNOTS: Speed measured in knots
            public static PropertyKey SPEED_KNOTS                        => new PropertyKey(Guids.DataType.Location,  6); //[VT_R8]
                                                                                                                                                                    // TRUE_HEADING_DEGREES: Heading relative to true North in degrees
            public static PropertyKey TRUE_HEADING_DEGREES               => new PropertyKey(Guids.DataType.Location,  7); //[VT_R8]
                                                                                                                                                                    // MAGNETIC_HEADING_DEGREES: Heading relative to magnetic North in degrees
            public static PropertyKey MAGNETIC_HEADING_DEGREES           => new PropertyKey(Guids.DataType.Location,  8); //[VT_R8]
                                                                                                                                                                    // MAGNETIC_VARIATION: Magnetic variation. East is positive
            public static PropertyKey MAGNETIC_VARIATION                 => new PropertyKey(Guids.DataType.Location,  9); //[VT_R8]
                                                                                                                                                                    // FIX_QUALITY: Quality of fix
            public static PropertyKey FIX_QUALITY                        => new PropertyKey(Guids.DataType.Location,  10); //[VT_I4]
                                                                                                                                                                     // FIX_TYPE: Fix Type
            public static PropertyKey FIX_TYPE                           => new PropertyKey(Guids.DataType.Location,  11); //[VT_I4]
                                                                                                                                                                     // POSITION_DILUTION_OF_PRECISION: Position Dilution of Precision
            public static PropertyKey POSITION_DILUTION_OF_PRECISION     => new PropertyKey(Guids.DataType.Location,  12); //[VT_R8]
                                                                                                                                                                     // HORIZONAL_DILUTION_OF_PRECISION: HORIZONTAL Dilution of Precision
            public static PropertyKey HORIZONAL_DILUTION_OF_PRECISION    => new PropertyKey(Guids.DataType.Location,  13); //[VT_R8]
                                                                                                                                                                     // VERTICAL_DILUTION_OF_PRECISION: VERTICAL Dilution of Precision
            public static PropertyKey VERTICAL_DILUTION_OF_PRECISION     => new PropertyKey(Guids.DataType.Location,  14); //[VT_R8]
                                                                                                                                                                     // SATELLITES_USED_COUNT: Number of satellites used in solution
            public static PropertyKey SATELLITES_USED_COUNT              => new PropertyKey(Guids.DataType.Location,  15); //[VT_I4]
                                                                                                                                                                     // SATELLITES_USED_PRNS: PRN numbers of satellites used in the solution
            public static PropertyKey SATELLITES_USED_PRNS               => new PropertyKey(Guids.DataType.Location,  16); //[VT_VECTOR | VT_UI1]
                                                                                                                                                                     // SATELLITES_IN_VIEW: Number of satellites in view.  From 0-GPS_MAX_SATELLITES
            public static PropertyKey SATELLITES_IN_VIEW                 => new PropertyKey(Guids.DataType.Location,  17); //[VT_I4]
                                                                                                                                                                     // SATELLITES_IN_VIEW_PRNS: PRN numbers of satellites in view
            public static PropertyKey SATELLITES_IN_VIEW_PRNS            => new PropertyKey(Guids.DataType.Location,  18); //[VT_VECTOR | VT_UI1]
                                                                                                                                                                     // SATELLITES_IN_VIEW_ELEVATION: Elevation of each sattellite in view
            public static PropertyKey SATELLITES_IN_VIEW_ELEVATION       => new PropertyKey(Guids.DataType.Location,  19); //[VT_VECTOR | VT_UI1]
                                                                                                                                                                     // SATELLITES_IN_VIEW_AZIMUTH: Azimuth of each satellite in view
            public static PropertyKey SATELLITES_IN_VIEW_AZIMUTH         => new PropertyKey(Guids.DataType.Location,  20); //[VT_VECTOR | VT_UI1
                                                                                                                                                                     // SATELLITES_IN_VIEW_STN_RATIO: Signal to noise ratio for each satellite in view
            public static PropertyKey SATELLITES_IN_VIEW_STN_RATIO       => new PropertyKey(Guids.DataType.Location,  21); //[VT_VECTOR | VT_UI1]
                                                                                                                                                                     // ERROR_RADIUS_METERS: Accuracy of Latitude and Longitude values
            public static PropertyKey ERROR_RADIUS_METERS                => new PropertyKey(Guids.DataType.Location,  22); //[VT_R8]
                                                                                                                                                                     // ADDRESS1: AddressLine1
            public static PropertyKey ADDRESS1                           => new PropertyKey(Guids.DataType.Location,  23); //[VT_LPWSTR]
                                                                                                                                                                     // ADDRESS2: AddressLine2
            public static PropertyKey ADDRESS2                           => new PropertyKey(Guids.DataType.Location,  24); //[VT_LPWSTR]
                                                                                                                                                                     // CITY: City
            public static PropertyKey CITY                               => new PropertyKey(Guids.DataType.Location,  25); //[VT_LPWSTR]
                                                                                                                                                                     // STATE_PROVINCE: State/Province
            public static PropertyKey STATE_PROVINCE                     => new PropertyKey(Guids.DataType.Location,  26); //[VT_LPWSTR]
                                                                                                                                                                     // POSTALCODE: Postal Code (e.g. ZIP)
            public static PropertyKey POSTALCODE                         => new PropertyKey(Guids.DataType.Location,  27); //[VT_LPWSTR]
                                                                                                                                                                     // COUNTRY_REGION: Country/Region
            public static PropertyKey COUNTRY_REGION                     => new PropertyKey(Guids.DataType.Location,  28); //[VT_LPWSTR]
                                                                                                                                                                     // ALTITUDE_ELLIPSOID_ERROR_METERS: Altitude Error with regards to ellipsoid, in meters
            public static PropertyKey ALTITUDE_ELLIPSOID_ERROR_METERS    => new PropertyKey(Guids.DataType.Location,  29); //[VT_R8]
                                                                                                                                                                     // ALTITUDE_SEALEVEL_ERROR_METERS: Altitude Error with regards to sea level, in meters
            public static PropertyKey ALTITUDE_SEALEVEL_ERROR_METERS     => new PropertyKey(Guids.DataType.Location,  30); //[VT_R8]
                                                                                                                                                                     // GPS_SELECTION_MODE:
            public static PropertyKey GPS_SELECTION_MODE                 => new PropertyKey(Guids.DataType.Location,  31); //[VT_I4]
                                                                                                                                                                     // GPS_OPERATION_MODE:
            public static PropertyKey GPS_OPERATION_MODE                 => new PropertyKey(Guids.DataType.Location,  32); //[VT_I4]
                                                                                                                                                                     // GPS_STATUS:
            public static PropertyKey GPS_STATUS                         => new PropertyKey(Guids.DataType.Location,  33); //[VT_I4]
                                                                                                                                                                     // GEOIDAL_SEPARATION:
            public static PropertyKey GEOIDAL_SEPARATION                 => new PropertyKey(Guids.DataType.Location,  34); //[VT_R8]
                                                                                                                                                                     // DGPS_DATA_AGE:
            public static PropertyKey DGPS_DATA_AGE                      => new PropertyKey(Guids.DataType.Location,  35); //[VT_R8]
                                                                                                                                                                     // ALTITUDE_ANTENNA_SEALEVEL_METERS:
            public static PropertyKey ALTITUDE_ANTENNA_SEALEVEL_METERS   => new PropertyKey(Guids.DataType.Location,  36); //[VT_R8]
                                                                                                                                                                     // DIFFERENTIAL_REFERENCE_STATION_ID:
            public static PropertyKey DIFFERENTIAL_REFERENCE_STATION_ID  => new PropertyKey(Guids.DataType.Location,  37); //[VT_I4]
                                                                                                                                                                     // NMEA_SENTENCE:
            public static PropertyKey NMEA_SENTENCE                      => new PropertyKey(Guids.DataType.Location,  38); //[VT_LPWSTR]
                                                                                                                                                                     // SATELLITES_IN_VIEW_ID:
            public static PropertyKey SATELLITES_IN_VIEW_ID              => new PropertyKey(Guids.DataType.Location,  39); //[VT_VECTOR|VT_UI1]
                                                                                                                                                                     // LOCATION_SOURCE:
            public static PropertyKey LOCATION_SOURCE                    => new PropertyKey(Guids.DataType.Location,  40); //[VT_UI4]
                                                                                                                                                                     // SATELLITES_USED_PRNS_AND_CONSTELLATIONS: PRN numbers and constellation information of satellites used in the solution
            public static PropertyKey SATELLITES_USED_PRNS_AND_CONSTELLATIONS => new PropertyKey(Guids.DataType.Location,  41); //[VT_VECTOR | VT_UI2]

        }

        public static class Environmental

        {

            public static PropertyKey TEMPERATURE_CELSIUS                    => new PropertyKey(Guids.DataType.Environmental,  2); //[VT_R4]
            public static PropertyKey RELATIVE_HUMIDITY_PERCENT              => new PropertyKey(Guids.DataType.Environmental,  3); //[VT_R4]
            public static PropertyKey ATMOSPHERIC_PRESSURE_BAR               => new PropertyKey(Guids.DataType.Environmental,  4); //[VT_R4]
            public static PropertyKey WIND_DIRECTION_DEGREES_ANTICLOCKWISE   => new PropertyKey(Guids.DataType.Environmental,  5); //[VT_R4]
            public static PropertyKey WIND_SPEED_METERS_PER_SECOND           => new PropertyKey(Guids.DataType.Environmental,  6); //[VT_R4]

        }

        public static class Motion

        {
            // Accelerometer Data Types
            public static PropertyKey ACCELERATION_X_G                                   => new PropertyKey(Guids.DataType.Motion,  2); //[VT_R8]
            public static PropertyKey ACCELERATION_Y_G                                   => new PropertyKey(Guids.DataType.Motion,  3); //[VT_R8]
            public static PropertyKey ACCELERATION_Z_G                                   => new PropertyKey(Guids.DataType.Motion,  4); //[VT_R8]
                                                                                                                                                                                   // Gyrometer Data Types
            public static PropertyKey ANGULAR_ACCELERATION_X_DEGREES_PER_SECOND_SQUARED  => new PropertyKey(Guids.DataType.Motion,  5); //[VT_R8]
            public static PropertyKey ANGULAR_ACCELERATION_Y_DEGREES_PER_SECOND_SQUARED  => new PropertyKey(Guids.DataType.Motion,  6); //[VT_R8]
            public static PropertyKey ANGULAR_ACCELERATION_Z_DEGREES_PER_SECOND_SQUARED  => new PropertyKey(Guids.DataType.Motion,  7); //[VT_R8]
            public static PropertyKey SPEED_METERS_PER_SECOND                            => new PropertyKey(Guids.DataType.Motion,  8); //[VT_R8]
            public static PropertyKey MOTION_STATE                                       => new PropertyKey(Guids.DataType.Motion,  9); //[VT_BOOL]
                                                                                                                                                                                   // Additional Motion Data Types
            public static PropertyKey ANGULAR_VELOCITY_X_DEGREES_PER_SECOND              => new PropertyKey(Guids.DataType.Motion,  10); //[VT_R8]
            public static PropertyKey ANGULAR_VELOCITY_Y_DEGREES_PER_SECOND              => new PropertyKey(Guids.DataType.Motion,  11); //[VT_R8]
            public static PropertyKey ANGULAR_VELOCITY_Z_DEGREES_PER_SECOND              => new PropertyKey(Guids.DataType.Motion,  12); //[VT_R8]

        }

        public static class Orientation

        {

            // Inclinometer Data Types
            public static PropertyKey TILT_X_DEGREES                 => new PropertyKey(Guids.DataType.Orientation,  2); //[VT_R4]
            public static PropertyKey TILT_Y_DEGREES                 => new PropertyKey(Guids.DataType.Orientation,  3); //[VT_R4]
            public static PropertyKey TILT_Z_DEGREES                 => new PropertyKey(Guids.DataType.Orientation,  4); //[VT_R4]
                                                                                                                                                                // Compass Data Types
            public static PropertyKey MAGNETIC_HEADING_X_DEGREES     => new PropertyKey(Guids.DataType.Orientation,  5); //[VT_R4]
            public static PropertyKey MAGNETIC_HEADING_Y_DEGREES     => new PropertyKey(Guids.DataType.Orientation,  6); //[VT_R4]
            public static PropertyKey MAGNETIC_HEADING_Z_DEGREES     => new PropertyKey(Guids.DataType.Orientation,  7); //[VT_R4]
                                                                                                                                                                // Distance Data Types
            public static PropertyKey DISTANCE_X_METERS              => new PropertyKey(Guids.DataType.Orientation,  8); //[VT_R4]
            public static PropertyKey DISTANCE_Y_METERS              => new PropertyKey(Guids.DataType.Orientation,  9); //[VT_R4]
            public static PropertyKey DISTANCE_Z_METERS              => new PropertyKey(Guids.DataType.Orientation,  10); //[VT_R4]
                                                                                                                                                                 // Additional Compass Data Types
            public static PropertyKey MAGNETIC_HEADING_COMPENSATED_MAGNETIC_NORTH_DEGREES    => new PropertyKey(Guids.DataType.Orientation,  11); //[VT_R8]
            public static PropertyKey MAGNETIC_HEADING_COMPENSATED_TRUE_NORTH_DEGREES        => new PropertyKey(Guids.DataType.Orientation,  12); //[VT_R8]
            public static PropertyKey MAGNETIC_HEADING_MAGNETIC_NORTH_DEGREES                => new PropertyKey(Guids.DataType.Orientation,  13); //[VT_R8]
            public static PropertyKey MAGNETIC_HEADING_TRUE_NORTH_DEGREES                    => new PropertyKey(Guids.DataType.Orientation,  14); //[VT_R8]
                                                                                                                                                                                         // Additional Orientation Data Types
            public static PropertyKey QUADRANT_ANGLE_DEGREES         => new PropertyKey(Guids.DataType.Orientation,  15); //[VT_R8]
            public static PropertyKey ROTATION_MATRIX                => new PropertyKey(Guids.DataType.Orientation,  16); //[VT_VECTOR|VT_UI1]
            public static PropertyKey QUATERNION                     => new PropertyKey(Guids.DataType.Orientation,  17); //[VT_VECTOR|VT_UI1]
            public static PropertyKey SIMPLE_DEVICE_ORIENTATION      => new PropertyKey(Guids.DataType.Orientation,  18); //[VT_UI4]
                                                                                                                                                                 // Compass (Magnetometer) Data Types
            public static PropertyKey MAGNETIC_FIELD_STRENGTH_X_MILLIGAUSS     => new PropertyKey(Guids.DataType.Orientation,  19); //[VT_R8]
            public static PropertyKey MAGNETIC_FIELD_STRENGTH_Y_MILLIGAUSS     => new PropertyKey(Guids.DataType.Orientation,  20); //[VT_R8]
            public static PropertyKey MAGNETIC_FIELD_STRENGTH_Z_MILLIGAUSS     => new PropertyKey(Guids.DataType.Orientation,  21); //[VT_R8]
                                                                                                                                                                           // Magnetometer Accuracy Data Types
            public static PropertyKey MAGNETOMETER_ACCURACY          => new PropertyKey(Guids.DataType.Orientation,  22); //[VT_I4]
        
        }

        public static class Mechanical

        {

            public static PropertyKey BOOLEAN_SWITCH_STATE           => new PropertyKey(Guids.DataType.Mechanical,  2); //[VT_BOOL]
            public static PropertyKey MULTIVALUE_SWITCH_STATE        => new PropertyKey(Guids.DataType.Mechanical,  3); //[VT_R8]
            public static PropertyKey FORCE_NEWTONS                  => new PropertyKey(Guids.DataType.Mechanical,  4); //[VT_R8]
            public static PropertyKey ABSOLUTE_PRESSURE_PASCAL       => new PropertyKey(Guids.DataType.Mechanical,  5); //[VT_R8]
            public static PropertyKey GAUGE_PRESSURE_PASCAL          => new PropertyKey(Guids.DataType.Mechanical,  6); //[VT_R8]
            public static PropertyKey STRAIN                         => new PropertyKey(Guids.DataType.Mechanical,  7); //[VT_R8]
            public static PropertyKey WEIGHT_KILOGRAMS               => new PropertyKey(Guids.DataType.Mechanical,  8); //[VT_R8]
            public static PropertyKey BOOLEAN_SWITCH_ARRAY_STATES    => new PropertyKey(Guids.DataType.Mechanical,  10); //[VT_UI4]
        }

        public static class Biometric

        {

            public static PropertyKey HUMAN_PRESENCE                 => new PropertyKey(Guids.DataType.Biometric,  2); //[VT_BOOL]
            public static PropertyKey HUMAN_PROXIMITY_METERS         => new PropertyKey(Guids.DataType.Biometric,  3); //[VT_R4]
            public static PropertyKey TOUCH_STATE                    => new PropertyKey(Guids.DataType.Biometric,  4); //[VT_BOOL]

        }

        public static class Light

        {

            // Ambient light in LUX, Lumens per square meter, the ACPI convention for reporting ambient light values
            public static PropertyKey LIGHT_LEVEL_LUX                => new PropertyKey(Guids.DataType.Light,  2); //[VT_R4]
            public static PropertyKey LIGHT_TEMPERATURE_KELVIN       => new PropertyKey(Guids.DataType.Light,  3); //[VT_R4]
            public static PropertyKey LIGHT_CHROMACITY               => new PropertyKey(Guids.DataType.Light,  4); //[VT_VECTOR|VT_UI1]

        }
        // EM4102 RFID protocol uses 40 bit tags, stored in 64 bit value: VT_UI8
        public static PropertyKey RFID_TAG_40_BIT                => new PropertyKey(Guids.DataType.Scanner,  2); //[VT_UI8]

        public static class Electrical

        {

            public static PropertyKey VOLTAGE_VOLTS                  => new PropertyKey(Guids.DataType.Electrical,  2); //[VT_R8]
            public static PropertyKey CURRENT_AMPS                   => new PropertyKey(Guids.DataType.Electrical,  3); //[VT_R8]
            public static PropertyKey CAPACITANCE_FARAD              => new PropertyKey(Guids.DataType.Electrical,  4); //[VT_R8]
            public static PropertyKey RESISTANCE_OHMS                => new PropertyKey(Guids.DataType.Electrical,  5); //[VT_R8]
            public static PropertyKey INDUCTANCE_HENRY               => new PropertyKey(Guids.DataType.Electrical,  6); //[VT_R8]
            public static PropertyKey ELECTRICAL_POWER_WATTS         => new PropertyKey(Guids.DataType.Electrical,  7); //[VT_R8]
            public static PropertyKey ELECTRICAL_PERCENT_OF_RANGE    => new PropertyKey(Guids.DataType.Electrical,  8); //[VT_R8]
            public static PropertyKey ELECTRICAL_FREQUENCY_HERTZ     => new PropertyKey(Guids.DataType.Electrical,  9); //[VT_R8]

        }

        //
        // Custom Sensor Data Types (additions to sensors.h)
        //

        public static class Custom

        {

            public static PropertyKey CUSTOM_USAGE                   => new PropertyKey(Guids.DataType.Custom,  5);    //[VT_UI4]
            public static PropertyKey CUSTOM_BOOLEAN_ARRAY           => new PropertyKey(Guids.DataType.Custom,  6);    //[VT_UI4]
            public static PropertyKey CUSTOM_VALUE1                  => new PropertyKey(Guids.DataType.Custom,  7);    //[VT_UI4||VT_R4]
            public static PropertyKey CUSTOM_VALUE2                  => new PropertyKey(Guids.DataType.Custom,  8);    //[VT_UI4||VT_R4]
            public static PropertyKey CUSTOM_VALUE3                  => new PropertyKey(Guids.DataType.Custom,  9);    //[VT_UI4||VT_R4]
            public static PropertyKey CUSTOM_VALUE4                  => new PropertyKey(Guids.DataType.Custom,  10);   //[VT_UI4||VT_R4]
            public static PropertyKey CUSTOM_VALUE5                  => new PropertyKey(Guids.DataType.Custom,  11);   //[VT_UI4||VT_R4]
            public static PropertyKey CUSTOM_VALUE6                  => new PropertyKey(Guids.DataType.Custom,  12);   //[VT_UI4||VT_R4]
            public static PropertyKey CUSTOM_VALUE7                  => new PropertyKey(Guids.DataType.Custom,  13);   //[VT_UI4||VT_R4]
            public static PropertyKey CUSTOM_VALUE8                  => new PropertyKey(Guids.DataType.Custom,  14);   //[VT_UI4||VT_R4]
            public static PropertyKey CUSTOM_VALUE9                  => new PropertyKey(Guids.DataType.Custom,  15);   //[VT_UI4||VT_R4]
            public static PropertyKey CUSTOM_VALUE10                 => new PropertyKey(Guids.DataType.Custom,  16);   //[VT_UI4||VT_R4]
            public static PropertyKey CUSTOM_VALUE11                 => new PropertyKey(Guids.DataType.Custom,  17);   //[VT_UI4||VT_R4]
            public static PropertyKey CUSTOM_VALUE12                 => new PropertyKey(Guids.DataType.Custom,  18);   //[VT_UI4||VT_R4]
            public static PropertyKey CUSTOM_VALUE13                 => new PropertyKey(Guids.DataType.Custom,  19);   //[VT_UI4||VT_R4]
            public static PropertyKey CUSTOM_VALUE14                 => new PropertyKey(Guids.DataType.Custom,  20);   //[VT_UI4||VT_R4]
            public static PropertyKey CUSTOM_VALUE15                 => new PropertyKey(Guids.DataType.Custom,  21);   //[VT_UI4||VT_R4]
            public static PropertyKey CUSTOM_VALUE16                 => new PropertyKey(Guids.DataType.Custom,  22);   //[VT_UI4||VT_R4]
            public static PropertyKey CUSTOM_VALUE17                 => new PropertyKey(Guids.DataType.Custom,  23);   //[VT_UI4||VT_R4]
            public static PropertyKey CUSTOM_VALUE18                 => new PropertyKey(Guids.DataType.Custom,  24);   //[VT_UI4||VT_R4]
            public static PropertyKey CUSTOM_VALUE19                 => new PropertyKey(Guids.DataType.Custom,  25);   //[VT_UI4||VT_R4]
            public static PropertyKey CUSTOM_VALUE20                 => new PropertyKey(Guids.DataType.Custom,  26);   //[VT_UI4||VT_R4]
            public static PropertyKey CUSTOM_VALUE21                 => new PropertyKey(Guids.DataType.Custom,  27);   //[VT_UI4||VT_R4]
            public static PropertyKey CUSTOM_VALUE22                 => new PropertyKey(Guids.DataType.Custom,  28);   //[VT_UI4||VT_R4]
            public static PropertyKey CUSTOM_VALUE23                 => new PropertyKey(Guids.DataType.Custom,  29);   //[VT_UI4||VT_R4]
            public static PropertyKey CUSTOM_VALUE24                 => new PropertyKey(Guids.DataType.Custom,  30);   //[VT_UI4||VT_R4]
            public static PropertyKey CUSTOM_VALUE25                 => new PropertyKey(Guids.DataType.Custom,  31);   //[VT_UI4||VT_R4]
            public static PropertyKey CUSTOM_VALUE26                 => new PropertyKey(Guids.DataType.Custom,  32);   //[VT_UI4||VT_R4]
            public static PropertyKey CUSTOM_VALUE27                 => new PropertyKey(Guids.DataType.Custom,  33);   //[VT_UI4||VT_R4]
            public static PropertyKey CUSTOM_VALUE28                 => new PropertyKey(Guids.DataType.Custom,  34);   //[VT_UI4||VT_R4]

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
}
