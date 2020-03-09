// Copyright (c) Microsoft Corporation.  All rights reserved.

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Microsoft.WindowsAPICodePack.PropertySystem;
using Microsoft.WindowsAPICodePack.Win32Native.PortableDevices;
using Microsoft.WindowsAPICodePack.Win32Native.PortableDevices.PropertySystem;
using Microsoft.WindowsAPICodePack.Win32Native.PropertySystem;
using Microsoft.WindowsAPICodePack.Win32Native.Sensors;
using Microsoft.WindowsAPICodePack.Win32Native.Shell.PropertySystem;

namespace Microsoft.WindowsAPICodePack.Sensors
{
    /// <summary>
    /// Defines a mapping of data field identifiers to the data returned in a sensor report.
    /// </summary>    
    public class SensorData : IDictionary<Guid, IList<object>>
    {
        #region implementation
        internal static SensorData FromNativeReport(in ISensor iSensor, in ISensorDataReport iReport)
        {
            var data = new SensorData();

            _ = iSensor.GetSupportedDataFields(out IPortableDeviceKeyCollection keyCollection);
            iReport.GetSensorValues(keyCollection, out IPortableDeviceValues valuesCollection);

            uint items = 0;

            _ = keyCollection.GetCount(ref items);

            for (uint index = 0; index < items; index++)
            {
                var key = new PropertyKey();

                _ = keyCollection.GetAt(index, ref key);
                _ = valuesCollection.GetValue(ref key, out PropVariant propValue);

                if (data.ContainsKey(key.FormatId))

                    data[key.FormatId].Add(propValue.Value);

                else

                    data.Add(key.FormatId, new List<object> { propValue.Value });

                propValue.Dispose();
            }

            if (keyCollection != null)

            {

                _ = Marshal.ReleaseComObject(keyCollection);

                keyCollection = null;

            }

            if (valuesCollection != null)

            {

                _ = Marshal.ReleaseComObject(valuesCollection);

                keyCollection = null;

            }

            return data;
        }
        #endregion

        private readonly Dictionary<Guid, IList<object>> sensorDataDictionary = new Dictionary<Guid, IList<object>>();

        #region IDictionary<Guid,IList<object>> Members

        /// <summary>
        /// Adds a data item to the dictionary.
        /// </summary>
        /// <param name="key">The data field identifier.</param>
        /// <param name="value">The data list.</param>
        public void Add(Guid key, IList<object> value) => sensorDataDictionary.Add(key, value);

        /// <summary>
        /// Determines if a particular data field itentifer is present in the collection.
        /// </summary>
        /// <param name="key">The data field identifier.</param>
        /// <returns><b>true</b> if the data field identifier is present.</returns>
        public bool ContainsKey(Guid key) => sensorDataDictionary.ContainsKey(key);

        /// <summary>
        /// Gets the list of the data field identifiers in this collection.
        /// </summary>
        public System.Collections.Generic.ICollection<Guid> Keys => sensorDataDictionary.Keys;

        /// <summary>
        /// Removes a particular data field identifier from the collection.
        /// </summary>
        /// <param name="key">The data field identifier.</param>
        /// <returns><b>true</b> if the item was removed.</returns>
        public bool Remove(Guid key) => sensorDataDictionary.Remove(key);

        /// <summary>
        /// Attempts to get the value of a data item.
        /// </summary>
        /// <param name="key">The data field identifier.</param>
        /// <param name="value">The data list.</param>
        /// <returns><b>true</b> if able to obtain the value; otherwise <b>false</b>.</returns>
        public bool TryGetValue(Guid key, out IList<object> value) => sensorDataDictionary.TryGetValue(key, out value);

        /// <summary>
        /// Gets the list of data values in the dictionary.
        /// </summary>
        public System.Collections.Generic.ICollection<IList<object>> Values => sensorDataDictionary.Values;

        /// <summary>
        /// Gets or sets the index operator for the dictionary by key.
        /// </summary>
        /// <param name="key">A GUID.</param>
        /// <returns>The item at the specified index.</returns>
        public IList<object> this[Guid key]
        {
            get => sensorDataDictionary[key];
            set => sensorDataDictionary[key] = value;
        }

        #endregion

        #region System.Collections.Generic.ICollection<KeyValuePair<Guid,IList<object>>> Members
        /// <summary>
        /// Adds a specified key/value data pair to the collection.
        /// </summary>
        /// <param name="item">The item to add.</param>
        public void Add(KeyValuePair<Guid, IList<object>> item) => (sensorDataDictionary as System.Collections.Generic.ICollection<KeyValuePair<Guid, IList<object>>>).Add(item);

        /// <summary>
        /// Clears the items from the collection.
        /// </summary>
        public void Clear() => (sensorDataDictionary as System.Collections.Generic.ICollection<KeyValuePair<Guid, IList<object>>>).Clear();

        /// <summary>
        /// Determines if the collection contains the specified key/value pair. 
        /// </summary>
        /// <param name="item">The item to locate.</param>
        /// <returns><b>true</b> if the collection contains the key/value pair; otherwise false.</returns>
        public bool Contains(KeyValuePair<Guid, IList<object>> item) => (sensorDataDictionary as System.Collections.Generic.ICollection<KeyValuePair<Guid, IList<object>>>).Contains(item);

        /// <summary>
        /// Copies an element collection to another collection.
        /// </summary>
        /// <param name="array">The destination collection.</param>
        /// <param name="arrayIndex">The index of the item to copy.</param>
        public void CopyTo( KeyValuePair<Guid, IList<object>>[] array, int arrayIndex) => (sensorDataDictionary as System.Collections.Generic.ICollection<KeyValuePair<Guid, IList<object>>>).CopyTo(array, arrayIndex);

        /// <summary>
        /// Returns the number of items in the collection.
        /// </summary>
        public int Count => sensorDataDictionary.Count;

        /// <summary>
        /// Gets a value that determines if the collection is read-only.
        /// </summary>
        public bool IsReadOnly => true;

        /// <summary>
        /// Removes a particular item from the collection.
        /// </summary>
        /// <param name="item">The item to remove.</param>
        /// <returns><b>true</b> if successful; otherwise <b>false</b></returns>
        public bool Remove(KeyValuePair<Guid, IList<object>> item) => (sensorDataDictionary as System.Collections.Generic.ICollection<KeyValuePair<Guid, IList<object>>>).Remove(item);

        #endregion

        #region IEnumerable<KeyValuePair<Guid,IList<object>>> Members
        /// <summary>
        /// Returns an enumerator for the collection.
        /// </summary>
        /// <returns>An enumerator.</returns>
        public IEnumerator<KeyValuePair<Guid, IList<object>>> GetEnumerator() => sensorDataDictionary as IEnumerator<KeyValuePair<Guid, IList<object>>>;

        #endregion

        #region IEnumerable Members
        /// <summary>
        /// Returns an enumerator for the collection.
        /// </summary>
        /// <returns>An enumerator.</returns>
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => sensorDataDictionary as System.Collections.IEnumerator;

        #endregion
    }
}
