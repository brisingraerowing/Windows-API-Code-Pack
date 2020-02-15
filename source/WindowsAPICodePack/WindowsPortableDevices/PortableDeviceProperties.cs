using Microsoft.WindowsAPICodePack.PropertySystem;
using Microsoft.WindowsAPICodePack.Win32Native;
using Microsoft.WindowsAPICodePack.Win32Native.PortableDevices;
using Microsoft.WindowsAPICodePack.Win32Native.PortableDevices.PropertySystem;
using Microsoft.WindowsAPICodePack.Win32Native.PropertySystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using ObjectProperty = Microsoft.WindowsAPICodePack.PropertySystem.ObjectProperty;

namespace Microsoft.WindowsAPICodePack.PortableDevices
{
    internal sealed class PortableDeviceProperties : INativePropertiesCollection
    {

        private IPortableDeviceProperties _nativePortableDeviceProperties;
        private IPortableDeviceKeyCollection _nativePortableDeviceKeyCollection;
        // private PortableDevice _portableDevice;
        private string _objectId;

        private void Dispose()
        {

            // As this type is internal and calling this method directly is not recommended, implementing a property and checking it at the top of this method to know whether the current object is already disposed is not necessary.

            _ = Marshal.ReleaseComObject(_nativePortableDeviceKeyCollection);
            _nativePortableDeviceKeyCollection = null;
            _ = Marshal.ReleaseComObject(_nativePortableDeviceProperties);
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

        HResult INativePropertiesCollection.GetAt(in uint index, ref PropertyKey propertyKey) =>

            // As this type is internal and calling the Dispose method directly is not recommended, implementing a property and checking it at the top of this method to know whether the current object is disposed is not necessary.

            _nativePortableDeviceKeyCollection.GetAt(index, ref propertyKey);

        HResult INativePropertiesCollection.GetAttributes(ref PropertyKey propertyKey, out IReadOnlyNativePropertyValuesCollection attributes)

        {

            // As this type is internal and calling the Dispose method directly is not recommended, implementing a property and checking it at the top of this method to know whether the current object is disposed is not necessary.

            HResult hr = _nativePortableDeviceProperties.GetPropertyAttributes(_objectId, ref propertyKey, out IPortableDeviceValues portableDeviceValues);

            attributes = new PortableDeviceValuesCollection(portableDeviceValues, null);

            return hr;

        }

        HResult INativePropertiesCollection.GetCount(out uint count)
        {

            // As this type is internal and calling the Dispose method directly is not recommended, implementing a property and checking it at the top of this method to know whether the current object is disposed is not necessary.

            uint _count = 0;

            HResult hr = _nativePortableDeviceKeyCollection.GetCount(ref _count);

            count = _count;

            return hr;

        }

        HResult INativePropertiesCollection.GetValues(out INativePropertyValuesCollection values)

        {

            // As this type is internal and calling the Dispose method directly is not recommended, implementing a property and checking it at the top of this method to know whether the current object is disposed is not necessary.

            HResult hr = _nativePortableDeviceProperties.GetValues(_objectId, ref _nativePortableDeviceKeyCollection, out IPortableDeviceValues portableDeviceValues);

            values = new PortableDeviceValuesCollection(portableDeviceValues, this);

            return hr;

        }

        HResult INativePropertiesCollection.SetValues(ref IEnumerable<IObjectProperty> values, out IReadOnlyNativePropertyValuesCollection results)
        {

            // As this type is internal and calling the Dispose method directly is not recommended, implementing a property and checking it at the top of this method to know whether the current object is disposed is not necessary.

            var _values = new PortableDeviceValues();

            PropertyKey propertyKey;

            PropVariant propVariant;

            HResult hr;

            foreach (IObjectProperty value in values)

            {

                propertyKey = value.PropertyKey;

                propVariant = value.GetValue();

                hr = _values.SetValue(ref propertyKey, ref propVariant);

                if (!CoreErrorHelper.Succeeded(hr))

                {

                    results = null;

                    return hr;

                }

            }

            hr = _nativePortableDeviceProperties.SetValues(_objectId, _values, out IPortableDeviceValues _results);

            results = new PortableDeviceValuesCollection(_results, null);

            return hr;

        }
    }

    internal sealed class PortableDevicePropertyInfo : INativePropertyInfo

    {

        public ObjectProperty ObjectProperty { get; private set; }

        public PortableDevicePropertyInfo(ObjectProperty objectProperty) => ObjectProperty = objectProperty;

        HResult INativePropertyInfo.IsReadable(out bool isReadable)
        {
            for (uint i = 0; i < ObjectProperty.Attributes.Count; i++)

                if (ObjectProperty.Attributes[i].Equals(PropertySystem.Attribute.Property.CanRead)) ;
        }

        HResult INativePropertyInfo.IsReadOnly(out bool isReadOnly) => throw new NotImplementedException();
        HResult INativePropertyInfo.IsRemovable(out bool isRemovable) => throw new NotImplementedException();
    }

    internal sealed class PortableDeviceValuesCollection : INativePropertyValuesCollection
    {
        private IPortableDeviceValues _nativePortableDeviceValues;
        private PortableDeviceProperties _portableDeviceProperties;

        public bool IsReadOnly => _portableDeviceProperties is null;

        public PortableDeviceValuesCollection(in IPortableDeviceValues portableDeviceValues, PortableDeviceProperties portableDeviceProperties)
        {
            _nativePortableDeviceValues = portableDeviceValues;

            _portableDeviceProperties = portableDeviceProperties;
        }

        HResult IReadOnlyNativePropertyValuesCollection.GetAt(in uint index, ref PropertyKey propertyKey, ref PropVariant propVariant) => _nativePortableDeviceValues.GetAt(index, ref propertyKey, ref propVariant);

        HResult IReadOnlyNativePropertyValuesCollection.GetCount(out uint count)
        {

            uint _count = 0;

            HResult hr = _nativePortableDeviceValues.GetCount(ref _count);

            count = _count;

            return hr;

        }

        HResult IReadOnlyNativePropertyValuesCollection.GetValue(ref PropertyKey propertyKey, out PropVariant propVariant) => _nativePortableDeviceValues.GetValue(ref propertyKey, out propVariant);

        HResult INativePropertyValuesCollection.SetValue(ref PropertyKey propertyKey, ref PropVariant propVariant)
        {
            if (IsReadOnly)

                throw new InvalidOperationException("This collection is read-only.");

            HResult hr = _nativePortableDeviceValues.SetValue(ref propertyKey, ref propVariant);

            if (!CoreErrorHelper.Succeeded(hr))

                return hr;

            IEnumerable<IObjectProperty> values = new IObjectProperty[] { new Win32Native.PropertySystem.ObjectProperty(propertyKey, propVariant) }.AsEnumerable();

            hr = ((INativePropertiesCollection)_portableDeviceProperties).SetValues(ref values, out IReadOnlyNativePropertyValuesCollection results);

            if (CoreErrorHelper.Succeeded(hr))

            {

                hr = results.GetValue(ref propertyKey, out PropVariant _propVariant);

                if (CoreErrorHelper.Succeeded(hr))

                    hr = (HResult)_propVariant.Value;

                _propVariant.Dispose();

            }

            return hr;
        }
    }
}
