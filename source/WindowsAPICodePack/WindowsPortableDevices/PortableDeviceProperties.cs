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
    public sealed class PortableDeviceProperties : INativePropertyCollection, IDisposable
    {
        private IPortableDeviceKeyCollection _nativePortableDeviceKeyCollection;
        private IPortableDeviceProperties _nativePortableDeviceProperties;
        private string _objectId;

        public void Dispose()
        {
            _nativePortableDeviceKeyCollection = null;
            _nativePortableDeviceProperties = null;
        }

        ~PortableDeviceProperties()
        {

            Dispose();

        }

        HResult INativePropertyCollection.GetAt(in uint index, ref PropertyKey propertyKey) => _nativePortableDeviceKeyCollection.GetAt(index, ref propertyKey);

        HResult INativePropertyCollection.GetAttributes(ref PropertyKey propertyKey, out INativePropertyValueCollection attributes)

        {

            HResult hr = _nativePortableDeviceProperties.GetPropertyAttributes(_objectId, ref propertyKey, out IPortableDeviceValues portableDeviceValues);

            attributes = new PortableDeviceValuesCollection(portableDeviceValues);

            return hr;

        }

        HResult INativePropertyCollection.GetCount(out uint count)
        {

            uint _count = 0;

            HResult hr = _nativePortableDeviceKeyCollection.GetCount(ref _count);

            count = _count;

            return hr;
        }

        HResult INativePropertyCollection.GetValues(out INativePropertyValueCollection values)

        {

            HResult hr = _nativePortableDeviceProperties.GetValues(_objectId, ref _nativePortableDeviceKeyCollection, out IPortableDeviceValues portableDeviceValues);

            values = new PortableDeviceValuesCollection(portableDeviceValues);

            return hr;

        }

        HResult INativePropertyCollection.SetValues(ref IEnumerable<NativeObjectProperty> values, out INativePropertyValueCollection results)
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

    public sealed class PortableDeviceValuesCollection : INativePropertyValueCollection
    {
        private IPortableDeviceValues _nativePortableDeviceValues;

        public PortableDeviceValuesCollection(IPortableDeviceValues portableDeviceValues) => _nativePortableDeviceValues = portableDeviceValues;

        HResult INativePropertyValueCollection.GetAt(uint index, ref PropertyKey propertyKey, ref PropVariant propVariant) => _nativePortableDeviceValues.GetAt(index, ref propertyKey, ref propVariant);

        HResult INativePropertyValueCollection.GetCount(out uint count)
        {

            uint _count = 0;

            HResult hr = _nativePortableDeviceValues.GetCount(ref _count);

            count = _count;

            return hr;

        }

        HResult INativePropertyValueCollection.GetValue(ref PropertyKey propertyKey, out PropVariant propVariant) => _nativePortableDeviceValues.GetValue(ref propertyKey, out propVariant);

        HResult INativePropertyValueCollection.SetValue(ref PropertyKey propertyKey, ref PropVariant propVariant) => _nativePortableDeviceValues.SetValue(ref propertyKey, ref propVariant);
    }
}
