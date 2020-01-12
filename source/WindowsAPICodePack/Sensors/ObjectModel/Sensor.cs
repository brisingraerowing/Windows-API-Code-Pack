// Copyright (c) Microsoft Corporation.  All rights reserved.

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Microsoft.WindowsAPICodePack.Sensors.Resources;
using System.Linq;
using Microsoft.WindowsAPICodePack.Win32Native.Shell.PropertySystem;
using MS.WindowsAPICodePack.Win32Native.Shell.PropertySystem;
using Microsoft.WindowsAPICodePack.Win32Native;
using Microsoft.WindowsAPICodePack.Win32Native.Sensors;
using Microsoft.WindowsAPICodePack.Win32Native.PortableDevices;
using Microsoft.WindowsAPICodePack.Win32Native.PortableDevices.PropertySystem;

namespace Microsoft.WindowsAPICodePack.Sensors
{
    /// <summary>
    /// Represents the method that will handle the DataReportChanged event.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void DataReportChangedEventHandler(Sensor sender, EventArgs e);

    /// <summary>
    /// Represents the method that will handle the StatChanged event.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void StateChangedEventHandler(Sensor sender, EventArgs e);

    /// <summary>
    /// Defines a general wrapper for a sensor.
    /// </summary>
    public class Sensor : ISensorEvents
    {
        /// <summary>
        /// Occurs when the DataReport member changes.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1009:DeclareEventHandlersCorrectly",
            Justification = "The event is raised by a static method, so passing in the sender instance is not possible")]
        public event DataReportChangedEventHandler DataReportChanged;

        /// <summary>
        /// Occurs when the State member changes.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1009:DeclareEventHandlersCorrectly",
            Justification = "The event is raised by a static method, so passing in the sender instance is not possible")]
        public event StateChangedEventHandler StateChanged;


        #region Public properties

        /// <summary>
        /// Gets a value that specifies the most recent data reported by the sensor.
        /// </summary>        
        public SensorReport DataReport { get; private set; }

        /// <summary>
        /// Gets a value that specifies the GUID for the sensor instance.
        /// </summary>
        public Guid? SensorId
        {
            get
            {
                if (sensorId == null && nativeISensor.GetID(out Guid id) == HResult.Ok)

                    sensorId = id;

                return sensorId;
            }
        }

        private Guid? sensorId;

        /// <summary>
        /// Gets a value that specifies the GUID for the sensor category.
        /// </summary>
        public Guid? CategoryId
        {
            get
            {
                if (categoryId == null && nativeISensor.GetCategory(out Guid id) == HResult.Ok)

                    categoryId = id;

                return categoryId;
            }
        }

        private Guid? categoryId;

        /// <summary>
        /// Gets a value that specifies the GUID for the sensor type.
        /// </summary>
        public Guid? TypeId
        {
            get
            {
                if (typeId == null && nativeISensor.GetType(out Guid id) == HResult.Ok)

                    typeId = id;

                return typeId;
            }
        }

        private Guid? typeId;

        /// <summary>
        /// Gets a value that specifies the sensor's friendly name.
        /// </summary>
        public string FriendlyName
        {
            get
            {
                if (friendlyName == null && nativeISensor.GetFriendlyName(out string name) == HResult.Ok)

                    friendlyName = name;

                return friendlyName;
            }
        }

        private string friendlyName;

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
            get => (uint)GetProperty(SensorPropertyKeys.SensorPropertyCurrentReportInterval);
            set => SetProperties(new DataFieldInfo[] { new DataFieldInfo(SensorPropertyKeys.SensorPropertyCurrentReportInterval, value) });
        }

        /// <summary>
        /// Gets a value that specifies the minimum report interval.
        /// </summary>
        public uint MinimumReportInterval => (uint)GetProperty(SensorPropertyKeys.SensorPropertyMinReportInterval);

        /// <summary>
        /// Gets a value that specifies the manufacturer of the sensor.
        /// </summary>
        public string Manufacturer
        {
            get
            {
                if (manufacturer == null)

                    manufacturer = (string)GetProperty(SensorPropertyKeys.SensorPropertyManufacturer);

                return manufacturer;
            }
        }

        private string manufacturer;

        /// <summary>
        /// Gets a value that specifies the sensor's model.
        /// </summary>
        public string Model
        {
            get
            {
                if (model == null)

                    model = (string)GetProperty(SensorPropertyKeys.SensorPropertyModel);

                return model;
            }
        }

        private string model;

        /// <summary>
        /// Gets a value that specifies the sensor's serial number.
        /// </summary>
        public string SerialNumber
        {
            get
            {
                if (serialNumber == null)

                    serialNumber = (string)GetProperty(SensorPropertyKeys.SensorPropertySerialNumber);

                return serialNumber;
            }
        }

        private string serialNumber;

        /// <summary>
        /// Gets a value that specifies the sensor's description.
        /// </summary>
        public string Description
        {
            get
            {
                if (description == null)

                    description = (string)GetProperty(SensorPropertyKeys.SensorPropertyDescription);

                return description;
            }
        }

        private string description;

        /// <summary>
        /// Gets a value that specifies the sensor's connection type.
        /// </summary>
        public SensorConnectionType? ConnectionType
        {
            get
            {
                if (connectionType == null)

                    connectionType = (SensorConnectionType)GetProperty(SensorPropertyKeys.SensorPropertyConnectionType);

                return connectionType;
            }
        }

        private SensorConnectionType? connectionType;

        /// <summary>
        /// Gets a value that specifies the sensor's device path.
        /// </summary>
        public string DevicePath
        {
            get
            {
                if (devicePath == null)

                    devicePath = (string)GetProperty(SensorPropertyKeys.SensorPropertyDeviceId);

                return devicePath;
            }
        }

        private string devicePath;

        /// <summary>
        /// Gets or sets a value that specifies whether the data should be automatically updated.   
        /// If the value is not set, call TryUpdateDataReport or UpdateDataReport to update the DataReport member.
        /// </summary>        
        public bool AutoUpdateDataReport
        {
            get => IsEventInterestSet(EventInterestTypes.DataUpdated);
            set
            {
                if (value)

                    SetEventInterest(EventInterestTypes.DataUpdated);

                else

                    ClearEventInterest(EventInterestTypes.DataUpdated);
            }
        }

        #endregion

        #region public methods
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
            {
                try
                {
                    DataReport = SensorReport.FromNativeReport(this, iReport);

                    if (DataReportChanged != null)

                        DataReportChanged.Invoke(this, EventArgs.Empty);

                }
                finally
                {
                    _ = Marshal.ReleaseComObject(iReport);
                }
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
            using (var pv = new PropVariant())
            {
                HResult hr = nativeISensor.GetProperty(ref propKey, pv);

                if (hr != HResult.Ok)
                {
                    Exception e = Marshal.GetExceptionForHR((int)hr);

                    throw hr == HResult.ElementNotFound ? new ArgumentOutOfRangeException(LocalizedMessages.SensorPropertyNotFound, e) : e;
                }

                return pv.Value;
            }
        }

        /// <summary>
        /// Retrieves a property value by the property index.
        /// Assumes the GUID component in the property key takes the sensor's type GUID.
        /// </summary>
        /// <param name="propIndex">A property index.</param>
        /// <returns>A property value.</returns>
        public object GetProperty(int propIndex) => GetProperty(new PropertyKey(SensorPropertyKeys.SensorPropertyCommonGuid, propIndex));

        /// <summary>
        /// Retrieves the values of multiple properties by property key.
        /// </summary>
        /// <param name="propKeys">An array of properties to retrieve.</param>
        /// <returns>A dictionary that contains the property keys and values.</returns>
        public IDictionary<PropertyKey, object> GetProperties(PropertyKey[] propKeys)
        {
            if (propKeys == null || propKeys.Length == 0)

                throw new ArgumentException(LocalizedMessages.SensorEmptyProperties, nameof(propKeys));

            IPortableDeviceKeyCollection keyCollection = new PortableDeviceKeyCollection();

            try
            {
                for (int i = 0; i < propKeys.Length; i++)
                {
                    PropertyKey propKey = propKeys[i];
                    _ = keyCollection.Add(ref propKey);
                }

                var data = new Dictionary<PropertyKey, object>();

                HResult hr = nativeISensor.GetProperties(keyCollection, out IPortableDeviceValues valuesCollection);

                if (CoreErrorHelper.Succeeded(hr) && valuesCollection != null)

                    try
                    {

                        uint count = 0;

                        _ = valuesCollection.GetCount(ref count);

                        for (uint i = 0; i < count; i++)
                        {
                            var propVal = new PropVariant();

                            var propKey = new PropertyKey();
                            valuesCollection.GetAt(i, ref propKey, ref propVal);
                            data.Add(propKey, propVal.Value);
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

                    collection.GetCount(ref elements);

                    if (elements == 0) return null;

                    for (uint element = 0; element < elements; element++)
                    {
                        PropertyKey key = new PropertyKey();

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

            IPortableDeviceKeyCollection keyCollection = new PortableDeviceKeyCollection();

            try
            {
                var propKeyToIdx = new Dictionary<PropertyKey, int>();

                for (int i = 0; i < propIndexes.Length; i++)
                {
                    var propKey = new PropertyKey(TypeId.Value, propIndexes[i]);
                    keyCollection.Add(ref propKey);
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
                        valuesCollection.GetCount(ref count);

                        for (uint i = 0; i < count; i++)
                        {
                            var propKey = new PropertyKey();
                            var propVal = new PropVariant();

                            valuesCollection.GetAt(i, ref propKey, propVal);

                            int idx = propKeyToIdx[propKey];
                            data[idx] = propVal.Value;
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
        public IDictionary<PropertyKey, object> SetProperties(DataFieldInfo[] data)
        {
            if (data == null || data.Length == 0)

                throw new ArgumentException(LocalizedMessages.SensorEmptyData, nameof(data));

            IPortableDeviceValues pdv = new PortableDeviceValues();

            PropertyKey propKey;

            for (int i = 0; i < data.Length; i++)
            {
                propKey = data[i].Key;
                object value = data[i].Value;

                if (value == null)

                    throw new ArgumentException(
                        string.Format(System.Globalization.CultureInfo.InvariantCulture,
                            LocalizedMessages.SensorNullValueAtIndex, i),
                        nameof(data));

                try
                {
                    // new PropVariant will throw an ArgumentException if the value can 
                    // not be converted to an appropriate PropVariant.
                    using (var pv = PropVariant.FromObject(value))

                        pdv.SetValue(ref propKey, pv);
                }
                catch (ArgumentException)
                {
                    if (value is Guid guid)

                        pdv.SetGuidValue(ref propKey, ref guid);

                    else if (value is byte[] buffer)

                        pdv.SetBufferValue(ref propKey, buffer, (uint)buffer.Length);

                    else

                        pdv.SetIUnknownValue(ref propKey, value);
                }
            }

            var results = new Dictionary<PropertyKey, object>();
            HResult hr = nativeISensor.SetProperties(pdv, out IPortableDeviceValues pdv2);

            if (hr == HResult.Ok)
            {
                try
                {
                    uint count = 0;
                    pdv2.GetCount(ref count);

                    for (uint i = 0; i < count; i++)
                    {
                        using (var propVal = new PropVariant())
                        {
                            propKey = new PropertyKey();
                            pdv2.GetAt(i, ref propKey, propVal);
                            results.Add(propKey, propVal.Value);
                        }
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

        void ISensorEvents.OnEvent(ISensor sensor, Guid eventID, ISensorDataReport newData)
        {
        }

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
                SetEventInterest(EventInterestTypes.StateChanged);
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
        protected void ClearEventInterest(Guid eventType)
        {
            if (nativeISensor == null)

                throw new SensorPlatformException(LocalizedMessages.SensorNotInitialized);

            if (IsEventInterestSet(eventType))
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
        protected bool IsEventInterestSet(Guid eventType)
        {
            if (nativeISensor == null)

                throw new SensorPlatformException(LocalizedMessages.SensorNotInitialized);

            return GetInterestingEvents()
                .Any(g => g.CompareTo(eventType) == 0);
        }

        private Guid[] GetInterestingEvents()
        {
            nativeISensor.GetEventInterest(out IntPtr values, out uint interestCount);
            var interestingEvents = new Guid[interestCount];

            for (int index = 0; index < interestCount; index++)
            {
                interestingEvents[index] = (Guid)Marshal.PtrToStructure(values, typeof(Guid));
                values = IncrementIntPtr(values, Marshal.SizeOf(typeof(Guid)));
            }

            return interestingEvents;
        }

        private static IntPtr IncrementIntPtr(IntPtr source, int increment)
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
