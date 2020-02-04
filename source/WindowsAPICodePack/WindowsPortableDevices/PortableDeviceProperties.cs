using Microsoft.WindowsAPICodePack.PropertySystem;
using Microsoft.WindowsAPICodePack.Win32Native;
using Microsoft.WindowsAPICodePack.Win32Native.PortableDevices;
using Microsoft.WindowsAPICodePack.Win32Native.PortableDevices.PropertySystem;
using Microsoft.WindowsAPICodePack.Win32Native.PropertySystem;
using MS.WindowsAPICodePack.Win32Native.Shell.PropertySystem;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Microsoft.WindowsAPICodePack.PortableDevices
{
    public sealed class PortableDeviceProperties : INativePropertiesCollection, IDisposable
    {
        private IPortableDeviceKeyCollection _nativePortableDeviceKeyCollection;
        private IPortableDeviceProperties _nativePortableDeviceProperties;
        private string _objectId;

        public void Dispose()
        {
            _nativePortableDeviceKeyCollection = null;
            _nativePortableDeviceProperties = null;
            _objectId = null;
        }

        public PortableDeviceProperties(in string objectId, in IPortableDeviceKeyCollection nativePortableDeviceKeyCollection, in IPortableDeviceProperties nativePortableDeviceProperties)

        {

            _objectId = objectId;

            _nativePortableDeviceKeyCollection = nativePortableDeviceKeyCollection;

            _nativePortableDeviceProperties = nativePortableDeviceProperties;

        }

        ~PortableDeviceProperties()
        {

            Dispose();

        }

        HResult INativePropertiesCollection.GetAt(uint index, ref PropertyKey propertyKey) => _nativePortableDeviceKeyCollection.GetAt(index, ref propertyKey);

        HResult INativePropertiesCollection.GetAttributes(ref PropertyKey propertyKey, out IReadOnlyNativePropertyValuesCollection attributes)

        {

            HResult hr = _nativePortableDeviceProperties.GetPropertyAttributes(_objectId, ref propertyKey, out IPortableDeviceValues portableDeviceValues);

            attributes = new PortableDeviceValuesCollection(portableDeviceValues);

            return hr;

        }

        HResult INativePropertiesCollection.GetCount(out uint count)
        {

            uint _count = 0;

            HResult hr = _nativePortableDeviceKeyCollection.GetCount(ref _count);

            count = _count;

            return hr;
        }

        HResult INativePropertiesCollection.GetValues(out IReadOnlyNativePropertyValuesCollection values)

        {

            HResult hr = _nativePortableDeviceProperties.GetValues(_objectId, ref _nativePortableDeviceKeyCollection, out IPortableDeviceValues portableDeviceValues);

            values = new PortableDeviceValuesCollection(portableDeviceValues);

            return hr;

        }

        HResult INativePropertiesCollection.SetValues(ref IEnumerable<NativeObjectProperty> values, out IReadOnlyNativePropertyValuesCollection results)
        {
            var _values = new PortableDeviceValues();

            PropertyKey propertyKey;

            PropVariant propVariant;

            foreach (NativeObjectProperty value in values)

            {

                propertyKey = value.PropertyKey;

                propVariant = value.PropVariant;

                Marshal.ThrowExceptionForHR((int)_values.SetValue(ref propertyKey, ref propVariant));

            }

            HResult hr = _nativePortableDeviceProperties.SetValues(_objectId, _values, out IPortableDeviceValues _results);

            results = new PortableDeviceValuesCollection(_results);

            return hr;
        }
    }

    public sealed class PortableDeviceValuesCollection : INativePropertyValuesCollection
    {
        private IPortableDeviceValues _nativePortableDeviceValues;

        public PortableDeviceValuesCollection( in IPortableDeviceValues portableDeviceValues) => _nativePortableDeviceValues = portableDeviceValues;

        HResult IReadOnlyNativePropertyValuesCollection.GetAt(uint index, ref PropertyKey propertyKey, ref PropVariant propVariant) => _nativePortableDeviceValues.GetAt(index, ref propertyKey, ref propVariant);

        HResult IReadOnlyNativePropertyValuesCollection.GetCount(out uint count)
        {

            uint _count = 0;

            HResult hr = _nativePortableDeviceValues.GetCount(ref _count);

            count = _count;

            return hr;

        }

        HResult IReadOnlyNativePropertyValuesCollection.GetValue(ref PropertyKey propertyKey, out PropVariant propVariant) => _nativePortableDeviceValues.GetValue(ref propertyKey, out propVariant);

        HResult INativePropertyValuesCollection.SetValue(ref PropertyKey propertyKey, ref PropVariant propVariant) => _nativePortableDeviceValues.SetValue(ref propertyKey, ref propVariant);
    }
}
