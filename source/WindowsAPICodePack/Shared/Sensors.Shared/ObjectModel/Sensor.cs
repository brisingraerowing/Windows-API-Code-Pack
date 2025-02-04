﻿//Copyright (c) Microsoft Corporation.  All rights reserved.  Distributed under the Microsoft Public License (MS-PL)

using Microsoft.WindowsAPICodePack.COMNative.PortableDevices.PropertySystem;
using Microsoft.WindowsAPICodePack.COMNative.Sensors;
using Microsoft.WindowsAPICodePack.PropertySystem;
using Microsoft.WindowsAPICodePack.Sensors.Resources;
using Microsoft.WindowsAPICodePack.Win32Native;
using Microsoft.WindowsAPICodePack.Win32Native.PropertySystem;

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Linq;

namespace Microsoft.WindowsAPICodePack.Sensors
{
    /// <summary>
    /// Represents the method that will handle the DataReportChanged event.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void DataReportChangedEventHandler(Sensor sender, in EventArgs e);

    /// <summary>
    /// Represents the method that will handle the StatChanged event.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void StateChangedEventHandler(in Sensor sender, in EventArgs e);

    /// <summary>
    /// Defines a general wrapper for a sensor.
    /// </summary>
    public class Sensor : ISensorEvents
    {
        private Guid? sensorId;
        private Guid? categoryId;
        private Guid? typeId;
        private string friendlyName;
        private string manufacturer;
        private string model;
        private string serialNumber;
        private string description;
        private SensorConnectionType? connectionType;
        private string devicePath;

        #region Public properties
        /// <summary>
        /// Gets a value that specifies the most recent data reported by the sensor.
        /// </summary>        
        public SensorReport DataReport { get; private set; }

        /// <summary>
        /// Gets a value that specifies the GUID for the sensor instance.
        /// </summary>
        public Guid? SensorId => sensorId == null && nativeISensor.GetID(out Guid id) == HResult.Ok ? (sensorId = id) : sensorId;

        /// <summary>
        /// Gets a value that specifies the GUID for the sensor category.
        /// </summary>
        public Guid? CategoryId => categoryId == null && nativeISensor.GetCategory(out Guid id) == HResult.Ok ? (categoryId = id) : categoryId;

        /// <summary>
        /// Gets a value that specifies the GUID for the sensor type.
        /// </summary>
        public Guid? TypeId => typeId == null && nativeISensor.GetType(out Guid id) == HResult.Ok ? (typeId = id) : typeId;

        /// <summary>
        /// Gets a value that specifies the sensor's friendly name.
        /// </summary>
        public string FriendlyName => friendlyName == null && nativeISensor.GetFriendlyName(out string name) == HResult.Ok ? (friendlyName = name) : friendlyName;

        /// <summary>
        /// Gets a value that specifies the sensor's current state.
        /// </summary>
        public SensorState State
        {
            get
            {
                nativeISensor.GetState(out NativeSensorState state);
                return (SensorState)state;
            }
        }

        /// <summary>
        /// Gets or sets a value that specifies the report interval.
        /// </summary>
        public uint ReportInterval
        {
            get => (uint)GetProperty(PropertySystem.CurrentReportInterval);
            set => SetProperties(new DataFieldInfo[] { new DataFieldInfo(PropertySystem.CurrentReportInterval, value) });
        }

        /// <summary>
        /// Gets a value that specifies the minimum report interval.
        /// </summary>
        public uint MinimumReportInterval => (uint)GetProperty(PropertySystem.MinReportInterval);

        /// <summary>
        /// Gets a value that specifies the manufacturer of the sensor.
        /// </summary>
        public string Manufacturer => manufacturer ?? (manufacturer = (string)GetProperty(PropertySystem.Manufacturer));

        /// <summary>
        /// Gets a value that specifies the sensor's model.
        /// </summary>
        public string Model => model ?? (model = (string)GetProperty(PropertySystem.Model));

        /// <summary>
        /// Gets a value that specifies the sensor's serial number.
        /// </summary>
        public string SerialNumber => serialNumber ?? (serialNumber = (string)GetProperty(PropertySystem.SerialNumber));

        /// <summary>
        /// Gets a value that specifies the sensor's description.
        /// </summary>
        public string Description => description ?? (description = (string)GetProperty(PropertySystem.Description));

        /// <summary>
        /// Gets a value that specifies the sensor's connection type.
        /// </summary>
        public SensorConnectionType? ConnectionType => connectionType ?? (connectionType = (SensorConnectionType)GetProperty(PropertySystem.ConnectionType));

        /// <summary>
        /// Gets a value that specifies the sensor's device path.
        /// </summary>
        public string DevicePath => devicePath ?? (devicePath = (string)GetProperty(PropertySystem.DevicePath));

        /// <summary>
        /// Gets or sets a value that specifies whether the data should be automatically updated.   
        /// If the value is not set, call TryUpdateDataReport or UpdateDataReport to update the DataReport member.
        /// </summary>        
        public bool AutoUpdateDataReport
        {
            get => IsEventInterestSet(Guids.EventSystem.DataUpdated);

            set
            {
                if (value)

                    SetEventInterest(new Guid(Guids.EventSystem.DataUpdated));

                else

                    ClearEventInterest(new Guid(Guids.EventSystem.DataUpdated));
            }
        }
        #endregion

        /// <summary>
        /// Occurs when the DataReport member changes.
        /// </summary>
        public event DataReportChangedEventHandler DataReportChanged;

        /// <summary>
        /// Occurs when the State member changes.
        /// </summary>
        public event StateChangedEventHandler StateChanged;

        #region Public methods
        /// <summary>
        /// Attempts a synchronous data update from the sensor.
        /// </summary>
        /// <returns><b>true</b> if the request was successful; otherwise <b>false</b>.</returns>
        public bool TryUpdateData() => InternalUpdateData() == HResult.Ok;

        /// <summary>
        /// Requests a synchronous data update from the sensor. The method throws an exception if the request fails.
        /// </summary>
        public void UpdateData()
        {
            HResult hr = InternalUpdateData();

            if (hr != HResult.Ok)

                throw new SensorPlatformException(LocalizedMessages.SensorsNotFound, Marshal.GetExceptionForHR((int)hr));
        }

        internal HResult InternalUpdateData()
        {
            HResult hr = nativeISensor.GetData(out ISensorDataReport iReport);

            if (hr == HResult.Ok)

                try
                {
                    DataReport = SensorReport.FromNativeReport(this, iReport);

                    DataReportChanged?.Invoke(this, EventArgs.Empty);
                }

                finally
                {
                    _ = Marshal.ReleaseComObject(iReport);
                }

            return hr;
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString() => string.Format(System.Globalization.CultureInfo.InvariantCulture,
                LocalizedMessages.SensorGetString,
                SensorId,
                TypeId,
                CategoryId,
                FriendlyName);

        /// <summary>
        /// Retrieves a property value by the property key.
        /// </summary>
        /// <param name="propKey">A property key.</param>
        /// <returns>A property value.</returns>        
        public object GetProperty(PropertyKey propKey)
        {
#if CS8
            using var pv = new PropVariant();
#else
            using (var pv = new PropVariant())
            {
#endif
                HResult hr = nativeISensor.GetProperty(ref propKey, pv);

                if (hr != HResult.Ok)
                {
                    Exception e = Marshal.GetExceptionForHR((int)hr);

                    throw hr == HResult.ElementNotFound ? new ArgumentOutOfRangeException(LocalizedMessages.SensorPropertyNotFound, e) : e;
                }

                return pv.Value;
#if !CS8
            }
#endif
        }

        /// <summary>
        /// Retrieves a property value by the property index.
        /// Assumes the GUID component in the property key takes the sensor's type GUID.
        /// </summary>
        /// <param name="propIndex">A property index.</param>
        /// <returns>A property value.</returns>
        public object GetProperty(in int propIndex)
        {
            var propKey = new PropertyKey(Guids.PropertySystem.PropertyCommon, (uint)propIndex);

            return GetProperty(propKey);
        }

        /// <summary>
        /// Retrieves the values of multiple properties by property key.
        /// </summary>
        /// <param name="propKeys">An array of properties to retrieve.</param>
        /// <returns>A dictionary that contains the property keys and values.</returns>
        public IDictionary<PropertyKey, object> GetProperties(in PropertyKey[] propKeys)
        {
            if (propKeys == null || propKeys.Length == 0)

                throw new ArgumentException(LocalizedMessages.SensorEmptyProperties, nameof(propKeys));

            var keyCollection = (IPortableDeviceKeyCollection)new PortableDeviceKeyCollection();

            try
            {
                PropertyKey propKey;

                for (int i = 0; i < propKeys.Length; i++)
                {
                    propKey = propKeys[i];
                    _ = keyCollection.Add(ref propKey);
                }

                var data = new Dictionary<PropertyKey, object>();

                HResult hr = nativeISensor.GetProperties(keyCollection, out IPortableDeviceValues valuesCollection);

                if (CoreErrorHelper.Succeeded(hr) && valuesCollection != null)

                    try
                    {
                        uint count = 0;

                        _ = valuesCollection.GetCount(ref count);

                        PropVariant propVal;

                        for (uint i = 0; i < count; i++)
                        {
                            propVal = new PropVariant();

                            propKey = new PropertyKey();
                            _ = valuesCollection.GetAt(i, ref propKey, propVal);
                            data.Add(propKey, propVal.Value);
                            propVal.Dispose();
                        }
                    }

                    finally
                    {
                        _ = Marshal.ReleaseComObject(valuesCollection);
                        valuesCollection = null;
                    }

                return data;
            }

            finally
            {
                _ = Marshal.ReleaseComObject(keyCollection);
            }
        }

        /// <summary>
        /// Returns a list of supported properties for the sensor.
        /// </summary>
        /// <returns>A strongly typed list of supported properties.</returns>        
        public IList<PropertyKey> GetSupportedProperties()
        {
            if (nativeISensor == null)

                throw new SensorPlatformException(LocalizedMessages.SensorNotInitialized);

            var list = new List<PropertyKey>();

            if (nativeISensor.GetSupportedDataFields(out IPortableDeviceKeyCollection collection) == HResult.Ok)

                try
                {
                    uint elements = 0;

                    _ = collection.GetCount(ref elements);

                    if (elements == 0) return null;

                    PropertyKey key;

                    for (uint element = 0; element < elements; element++)
                    {
                        key = new PropertyKey();

                        if (collection.GetAt(element, ref key) == HResult.Ok)

                            list.Add(key);
                    }
                }

                finally
                {
                    _ = Marshal.ReleaseComObject(collection);
                    collection = null;
                }

            return list;
        }

        /// <summary>
        /// Retrieves the values of multiple properties by their index.
        /// Assumes that the GUID component of the property keys is the sensor's type GUID.
        /// </summary>
        /// <param name="propIndexes">The indexes of the properties to retrieve.</param>
        /// <returns>An array that contains the property values.</returns>
        /// <remarks>
        /// The returned array will contain null values for some properties if the values could not be retrieved.
        /// </remarks>        
        public object[] GetProperties(params int[] propIndexes)
        {
            if (propIndexes == null || propIndexes.Length == 0)

                throw new ArgumentNullException(nameof(propIndexes));

            var keyCollection = (IPortableDeviceKeyCollection)new PortableDeviceKeyCollection();

            try
            {
                var propKeyToIdx = new Dictionary<PropertyKey, int>();

                PropertyKey propKey;

                for (int i = 0; i < propIndexes.Length; i++)
                {
                    propKey = new PropertyKey(TypeId.Value, (uint)propIndexes[i]);
                    _ = keyCollection.Add(ref propKey);
                    propKeyToIdx.Add(propKey, i);
                }

                object[] data = new object[propIndexes.Length];
                HResult hr = nativeISensor.GetProperties(keyCollection, out IPortableDeviceValues valuesCollection);

                if (hr == HResult.Ok)
                {
                    try
                    {
                        if (valuesCollection == null) return data;

                        uint count = 0;

                        _ = valuesCollection.GetCount(ref count);

                        PropVariant propVal;

                        for (uint i = 0; i < count; i++)
                        {
                            propKey = new PropertyKey();
                            propVal = new PropVariant();

                            _ = valuesCollection.GetAt(i, ref propKey, propVal);

                            int idx = propKeyToIdx[propKey];
                            data[idx] = propVal.Value;

                            propVal.Dispose();
                        }
                    }

                    finally
                    {
                        _ = Marshal.ReleaseComObject(valuesCollection);
                        valuesCollection = null;
                    }
                }

                return data;
            }

            finally
            {
                _ = Marshal.ReleaseComObject(keyCollection);
            }
        }

        /// <summary>
        /// Sets the values of multiple properties.
        /// </summary>
        /// <param name="data">An array that contains the property keys and values.</param>
        /// <returns>A dictionary of the new values for the properties. Actual values may not match the requested values.</returns>
        public IDictionary<PropertyKey, object> SetProperties(in DataFieldInfo[] data)
        {
            if (data == null || data.Length == 0)

                throw new ArgumentException(LocalizedMessages.SensorEmptyData, nameof(data));

            var pdv = (IPortableDeviceValues)new PortableDeviceValues();

            PropertyKey propKey;
            object value;

            for (int i = 0; i < data.Length; i++)
            {
                propKey = data[i].Key;

                value = data[i].Value ?? throw new ArgumentException(
                        string.Format(System.Globalization.CultureInfo.InvariantCulture,
                            LocalizedMessages.SensorNullValueAtIndex, i),
                        nameof(data));

                try
                {
                    // new PropVariant will throw an ArgumentException if the value can 
                    // not be converted to an appropriate PropVariant.
#if CS8
                    using var pv = PropVariant.FromObject(value);
#else
                    using (var pv = PropVariant.FromObject(value))
#endif
                        _ = pdv.SetValue(ref propKey, pv);
                }

                catch (ArgumentException)
                {
#if CS8
                    _ = value switch
                    {
                        Guid guid => pdv.SetGuidValue(ref propKey, ref guid),
                        byte[] buffer => pdv.SetBufferValue(ref propKey, buffer, (uint)buffer.Length),
                        _ => pdv.SetIUnknownValue(ref propKey, value),
                    };
#else
                    switch (value)
                    {
                        case Guid guid:
                            _ = pdv.SetGuidValue(ref propKey, ref guid);
                            break;
                        case byte[] buffer:
                            _ = pdv.SetBufferValue(ref propKey, buffer, (uint)buffer.Length);
                            break;
                        default:
                            _ = pdv.SetIUnknownValue(ref propKey, value);
                            break;
                    }
#endif
                }
            }

            var results = new Dictionary<PropertyKey, object>();

            HResult hr = nativeISensor.SetProperties(pdv, out IPortableDeviceValues pdv2);

            if (hr == HResult.Ok)
            {
                try
                {
                    uint count = 0;

                    _ = pdv2.GetCount(ref count);

                    for (uint i = 0; i < count; i++)
                    {
#if CS8
                        using var propVal = new PropVariant();
#else
                        using (var propVal = new PropVariant())
                        {
#endif
                            propKey = new PropertyKey();
                            _ = pdv2.GetAt(i, ref propKey, propVal);
                            results.Add(propKey, propVal.Value);
#if !CS8
                        }
#endif
                    }
                }
                finally
                {
                    _ = Marshal.ReleaseComObject(pdv2);
                    pdv2 = null;
                }
            }

            return results;
        }
        #endregion

        #region overridable methods
        /// <summary>
        /// Initializes the Sensor wrapper after it has been bound to the native ISensor interface
        /// and is ready for subsequent initialization.
        /// </summary>
        protected virtual void Initialize()
        {
        }

        #endregion

        #region ISensorEvents Members
        void ISensorEvents.OnStateChanged(ISensor sensor, NativeSensorState state) => StateChanged?.Invoke(this, EventArgs.Empty);

        void ISensorEvents.OnDataUpdated(ISensor sensor, ISensorDataReport newData)
        {
            DataReport = SensorReport.FromNativeReport(this, newData);

            DataReportChanged?.Invoke(this, EventArgs.Empty);
        }

        void ISensorEvents.OnEvent(ISensor sensor, Guid eventID, ISensorDataReport newData) { /* Left empty. */ }

        void ISensorEvents.OnLeave(Guid sensorIdArgs) => SensorManager.OnSensorsChanged(sensorIdArgs, SensorAvailabilityChange.Removal);
        #endregion

        #region Implementation
        private ISensor nativeISensor;

        internal ISensor InternalObject
        {
            get => nativeISensor;

            set
            {
                nativeISensor = value;
                SetEventInterest(new Guid(Guids.EventSystem.StateChanged));
                nativeISensor.SetEventSink(this);
                Initialize();
            }
        }

        /// <summary>
        /// Informs the sensor driver of interest in a specific type of event.
        /// </summary>
        /// <param name="eventType">The type of event of interest.</param>        
        protected void SetEventInterest(Guid eventType)
        {
            if (nativeISensor == null)

                throw new SensorPlatformException(LocalizedMessages.SensorNotInitialized);

            Guid[] interestingEvents = GetInterestingEvents();

            if (interestingEvents.Any(g => g == eventType)) return;

            int interestCount = interestingEvents.Length;

            var newEventInterest = new Guid[interestCount + 1];
            interestingEvents.CopyTo(newEventInterest, 0);
            newEventInterest[interestCount] = eventType;

            HResult hr = nativeISensor.SetEventInterest(newEventInterest, (uint)(interestCount + 1));

            if (hr != HResult.Ok)

                throw Marshal.GetExceptionForHR((int)hr);
        }

        /// <summary>
        ///  Informs the sensor driver to clear a specific type of event.
        /// </summary>
        /// <param name="eventType">The type of event of interest.</param>
        protected void ClearEventInterest(in Guid eventType)
        {
            if (nativeISensor == null)

                throw new SensorPlatformException(LocalizedMessages.SensorNotInitialized);

            if (IsEventInterestSet(eventType.ToString()))
            {
                Guid[] interestingEvents = GetInterestingEvents();
                int interestCount = interestingEvents.Length;

                var newEventInterest = new Guid[interestCount - 1];

                int eventIndex = 0;

                foreach (Guid g in interestingEvents)

                    if (g != eventType)
                    {
                        newEventInterest[eventIndex] = g;
                        eventIndex++;
                    }

                _ = nativeISensor.SetEventInterest(newEventInterest, (uint)(interestCount - 1));
            }

        }

        /// <summary>
        /// Determines whether the sensor driver will file events for a particular type of event.
        /// </summary>
        /// <param name="eventType">The type of event, as a GUID.</param>
        /// <returns><b>true</b> if the sensor will report interest in the specified event.</returns>
        protected bool IsEventInterestSet(string eventType) => nativeISensor == null
                ? throw new SensorPlatformException(LocalizedMessages.SensorNotInitialized)
                : GetInterestingEvents()
                .Any(g => string.CompareOrdinal(g.ToString(), eventType) == 0);

        private Guid[] GetInterestingEvents()
        {
            nativeISensor.GetEventInterest(out IntPtr values, out uint interestCount);

            var interestingEvents = new Guid[interestCount];

#if CS8
            static IntPtr IncrementIntPtr(IntPtr source, int increment) => IntPtr.Size switch
            {
                8 => new IntPtr(source.ToInt64() + increment),
                4 => new IntPtr(source.ToInt32() + increment),
                _ => throw new SensorPlatformException(LocalizedMessages.SensorUnexpectedPointerSize),
            };
#else
            IntPtr IncrementIntPtr(IntPtr source, int increment)
            {
                switch (IntPtr.Size)
                {
                    case 8:
                        return new IntPtr(source.ToInt64() + increment);
                    case 4:
                        return new IntPtr(source.ToInt32() + increment);
                    default:
                        throw new SensorPlatformException(LocalizedMessages.SensorUnexpectedPointerSize);
                }
            }
#endif

            for (int index = 0; index < interestCount; index++)
            {
                interestingEvents[index] = (Guid)Marshal.PtrToStructure(values, typeof(Guid));

                values = IncrementIntPtr(values, Marshal.SizeOf(typeof(Guid)));
            }

            return interestingEvents;
        }

        #endregion
    }

    #region Helper types
    /// <summary>
    /// Defines a structure that contains the property ID (key) and value.
    /// </summary>
    public struct DataFieldInfo : IEquatable<DataFieldInfo>
    {
        private PropertyKey _propKey;

        /// <summary>
        /// Initializes the structure.
        /// </summary>
        /// <param name="propKey">A property ID (key).</param>
        /// <param name="value">A property value. The type must be valid for the property ID.</param>
        public DataFieldInfo(PropertyKey propKey, object value)
        {
            _propKey = propKey;

            Value = value;
        }

        /// <summary>
        /// Gets the property's key.
        /// </summary>
        public PropertyKey Key => _propKey;

        /// <summary>
        /// Gets the property's value.
        /// </summary>
        public object Value { get; }

        /// <summary>
        /// Returns the hash code for a particular DataFieldInfo structure.
        /// </summary>
        /// <returns>A hash code.</returns>
        public override int GetHashCode() => _propKey.GetHashCode() ^ (Value != null ? Value.GetHashCode() : 0);

        /// <summary>
        /// Determines if this object and another object are equal.
        /// </summary>
        /// <param name="obj">The object to compare.</param>
        /// <returns><b>true</b> if this instance and another object are equal; otherwise <b>false</b>.</returns>
        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is DataFieldInfo)) return false;

            var other = (DataFieldInfo)obj;

            return Value.Equals(other.Value) && _propKey.Equals(other._propKey);
        }

        #region IEquatable<DataFieldInfo> Members
        /// <summary>
        /// Determines if this key and value pair and another key and value pair are equal.
        /// </summary>
        /// <param name="other">The item to compare.</param>
        /// <returns><b>true</b> if equal; otherwise <b>false</b>.</returns>
        public bool Equals(DataFieldInfo other) => Value.Equals(other.Value) && _propKey.Equals(other._propKey);
        #endregion

        /// <summary>
        /// DataFieldInfo == operator overload
        /// </summary>
        /// <param name="first">The first item to compare.</param>
        /// <param name="second">The second item to compare.</param>
        /// <returns><b>true</b> if equal; otherwise <b>false</b>.</returns>
        public static bool operator ==(DataFieldInfo first, DataFieldInfo second) => first.Equals(second);

        /// <summary>
        /// DataFieldInfo != operator overload
        /// </summary>
        /// <param name="first">The first item to compare.</param>
        /// <param name="second">The second item to comare.</param>
        /// <returns><b>true</b> if not equal; otherwise <b>false</b>.</returns>
        public static bool operator !=(DataFieldInfo first, DataFieldInfo second) => !first.Equals(second);
    }
    #endregion
}
