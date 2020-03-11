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
using static Microsoft.WindowsAPICodePack.Win32Native.PortableDevices.PortableDeviceHelper;
using System.Diagnostics;

namespace Microsoft.WindowsAPICodePack.PortableDevices.PropertySystem
{

    internal interface INativePortableDeviceValuesCollectionProvider

    {

        IPortableDeviceValues NativeItems { get; }

    }

    internal interface INativeReadOnlyPortableDeviceValueCollection : INativePortableDeviceValuesCollectionProvider, INativeReadOnlyValueCollection { }

    public class ReadOnlyPortableDeviceValueCollection : ReadOnlyValueCollection, INativePortableDeviceValuesCollectionProvider

    {

        IPortableDeviceValues INativePortableDeviceValuesCollectionProvider.NativeItems => ((INativePortableDeviceValuesCollectionProvider)Items).NativeItems;

        internal ReadOnlyPortableDeviceValueCollection(in INativeReadOnlyPortableDeviceValueCollection nativeCollection) : base(nativeCollection) { }

        public ReadOnlyPortableDeviceValueCollection(in PortableDeviceValueCollection collection) : this(collection.Items) { } 

    }

    internal interface INativePortableDeviceValueCollection : INativeReadOnlyPortableDeviceValueCollection, INativeValueCollection { }

    public class PortableDeviceValueCollection : ValueCollection, INativePortableDeviceValuesCollectionProvider

    {

        IPortableDeviceValues INativePortableDeviceValuesCollectionProvider.NativeItems => Items.NativeItems;

        internal new INativePortableDeviceValueCollection Items => (INativePortableDeviceValueCollection) base.Items;

        public PortableDeviceValueCollection() : base(new NativeValueCollection(new PortableDeviceValues())) { }

        internal PortableDeviceValueCollection(in INativePortableDeviceValueCollection nativeValueCollection) : base(nativeValueCollection) { }

    }

    //public class PropertyKeyCollection : WindowsAPICodePack.Collection<PropertyKey>, INativePropertyKeyCollectionProvider
    //{

    //    private IPortableDeviceKeyCollection _nativeItems;

    //    IPortableDeviceKeyCollection INativePropertyKeyCollectionProvider. NativeItems => _nativeItems ?? (_nativeItems = ((NativePropertyKeyCollection)Items).PortableDeviceKeyCollection);

    //    public PropertyKeyCollection() : base(new NativePropertyKeyCollection()) { }

    //}

    //public class ReadOnlyPropertyKeyCollection : ReadOnlyCollection<PropertyKey>

    //{

    //    private NativePropertyKeyCollection _nativeItems;

    //    internal NativePropertyKeyCollection NativeItems => _nativeItems ?? (_nativeItems = (NativePropertyKeyCollection)Items);

    //    internal ReadOnlyPropertyKeyCollection(NativeReadOnlyPropertyKeyCollection nativeItems) : base(nativeItems) { }

    //}

    internal sealed class PortableDeviceProperties : INativePropertiesCollection
    {

        private PortableDevice _portableDevice;
        private string _objectId;
        private Win32Native.PortableDevices.PropertySystem.IPortableDeviceKeyCollection _nativePortableDeviceKeyCollection;

        void IDisposable.Dispose() => Dispose(true);

        private void Dispose(bool disposing)

        {

            if (disposing)

            {

                _portableDevice = null;
                _objectId = null;

            }

            _ = Marshal.ReleaseComObject(_nativePortableDeviceKeyCollection);
            _nativePortableDeviceKeyCollection = null;

        }

        public PortableDeviceProperties(in string objectId, in PortableDevice portableDevice)

        {

            _objectId = objectId;

            ThrowWhenFailHResult(portableDevice.NativePortableDeviceProperties.GetSupportedProperties(_objectId, out _nativePortableDeviceKeyCollection));

        }

        ~PortableDeviceProperties()
        {

            Dispose(false);

        }

        HResult INativePropertiesCollection.GetAt(in uint index, ref PropertyKey propertyKey) =>

            // As this type is internal and calling the Dispose method directly is not recommended, implementing a property and checking it at the top of this method to know whether the current object is disposed is not necessary.

            _nativePortableDeviceKeyCollection.GetAt(index, ref propertyKey);

        HResult INativePropertiesCollection.GetAttributes(ref PropertyKey propertyKey, out IDisposableReadOnlyNativePropertyValuesCollection attributes)

        {

            // As this type is internal and calling the Dispose method directly is not recommended, implementing a property and checking it at the top of this method to know whether the current object is disposed is not necessary.

            HResult hr = _portableDevice.NativePortableDeviceProperties.GetPropertyAttributes(_objectId, ref propertyKey, out Win32Native.PortableDevices.PropertySystem.IPortableDeviceValues portableDeviceValues);

            attributes = new DisposablePortableDeviceValuesCollection(portableDeviceValues, null);

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

        PortableDeviceValuesCollectionInternal _portableDeviceValues;

        HResult INativePropertiesCollection.GetValues(out INativePropertyValuesCollection values)

        {

            // As this type is internal and calling the Dispose method directly is not recommended, implementing a property and checking it at the top of this method to know whether the current object is disposed is not necessary.

            HResult hr = HResult.Ok;

            if (_portableDeviceValues is null)

            {

                hr = _portableDevice.NativePortableDeviceProperties.GetValues(_objectId, ref _nativePortableDeviceKeyCollection, out Win32Native.PortableDevices.PropertySystem.IPortableDeviceValues portableDeviceValues);

                values = _portableDeviceValues = new PortableDeviceValuesCollectionInternal(portableDeviceValues, this);



            }

            else

                values = _portableDeviceValues;

            return hr;

        }

        HResult INativePropertiesCollection.SetValues(ref IEnumerable<IObjectProperty> values, out INativeReadOnlyPropertyValuesCollection results)
        {

            // As this type is internal and calling the Dispose method directly is not recommended, implementing a property and checking it at the top of this method to know whether the current object is disposed is not necessary.

            var _values = new Win32Native.PortableDevices.PropertySystem.PortableDeviceValues();

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

            hr = _portableDevice.NativePortableDeviceProperties.SetValues(_objectId, _values, out Win32Native.PortableDevices.PropertySystem.IPortableDeviceValues _results);

            results = new PortableDeviceValuesCollectionInternal(_results, null);

            return hr;

        }

        HResult INativePropertiesCollection.Delete(params PropertyKey[] properties) => Delete(properties);

        HResult INativePropertiesCollection.Delete(in IEnumerable<PropertyKey> properties) => Delete(properties);

        private HResult Delete(in IEnumerable<PropertyKey> properties)
        {

            Win32Native.PortableDevices.PropertySystem.IPortableDeviceKeyCollection portableDeviceKeyCollection = new Win32Native.PortableDevices.PropertySystem.PortableDeviceKeyCollection();

            PropertyKey _propertyKey;

            foreach (PropertyKey propertyKey in properties)

            {

                _propertyKey = propertyKey;

                _ = portableDeviceKeyCollection.Add(ref _propertyKey);

            }

            return _portableDevice.NativePortableDeviceProperties.Delete(_objectId, ref portableDeviceKeyCollection);

        }
    }

    internal sealed class PortableDevicePropertyInfo : IPropertyInfo

    {
        private bool? _isReadable;
        private bool? _isReadOnly;
        private bool? _isRemovable;

        public ObjectProperty ObjectProperty { get; private set; }

        public PortableDevicePropertyInfo(ObjectProperty objectProperty) => ObjectProperty = objectProperty;

        bool IPropertyInfo.IsReadable => (_isReadable ?? (_isReadable = GetAttributeValue(PropertySystem.Attribute.Property.CanRead))).Value;

        bool IPropertyInfo.IsReadOnly => (_isReadOnly ?? (_isReadOnly = !GetAttributeValue(PropertySystem.Attribute.Property.CanWrite))).Value;

        bool IPropertyInfo.IsRemovable => (_isRemovable ?? (_isRemovable = GetAttributeValue(PropertySystem.Attribute.Property.CanDelete))).Value;

        private bool GetAttributeValue(PropertyKey propertyKey)
        {

            ObjectPropertyAttribute objectPropertyAttribute;

            for (uint i = 0; i < ObjectProperty.Attributes.Count; i++)
            {

                objectPropertyAttribute = ObjectProperty.Attributes[i];

                if (objectPropertyAttribute.Equals(propertyKey) && (bool)objectPropertyAttribute.Value)

                    return true;

            }

            return false;

        }
    }

    internal abstract class PortableDeviceValuesCollectionAbstract : INativePropertyValuesCollection
    {
        private Win32Native.PortableDevices.PropertySystem.IPortableDeviceValues _nativePortableDeviceValues;
        private PortableDeviceProperties _portableDeviceProperties;

        private bool _disposed = false;

        protected Win32Native.PortableDevices.PropertySystem.IPortableDeviceValues NativePortableDeviceValues { get { Debug.Assert(!_disposed); return _nativePortableDeviceValues; } }

        protected PortableDeviceProperties PortableDeviceProperties { get { Debug.Assert(!_disposed); return _portableDeviceProperties; } }

        public bool IsReadOnly => _portableDeviceProperties is null;

        public PortableDeviceValuesCollectionAbstract(in Win32Native.PortableDevices.PropertySystem.IPortableDeviceValues portableDeviceValues, in PortableDeviceProperties portableDeviceProperties)
        {
            _nativePortableDeviceValues = portableDeviceValues;

            _portableDeviceProperties = portableDeviceProperties;
        }

        HResult INativeReadOnlyPropertyValuesCollection.GetAt(in uint index, ref PropertyKey propertyKey, ref PropVariant propVariant) => _nativePortableDeviceValues.GetAt(index, ref propertyKey, ref propVariant);

        HResult INativeReadOnlyPropertyValuesCollection.GetCount(out uint count)
        {

            uint _count = 0;

            HResult hr = _nativePortableDeviceValues.GetCount(ref _count);

            count = _count;

            return hr;

        }

        HResult INativeReadOnlyPropertyValuesCollection.GetValue(ref PropertyKey propertyKey, out PropVariant propVariant) => _nativePortableDeviceValues.GetValue(ref propertyKey, out propVariant);

        HResult INativePropertyValuesCollection.SetValue(ref PropertyKey propertyKey, ref PropVariant propVariant)
        {
            if (IsReadOnly)

                throw new InvalidOperationException("This collection is read-only.");

            HResult hr = _nativePortableDeviceValues.SetValue(ref propertyKey, ref propVariant);

            if (!CoreErrorHelper.Succeeded(hr))

                return hr;

            IEnumerable<IObjectProperty> values = new IObjectProperty[] { new Win32Native.PropertySystem.ObjectProperty(propertyKey, propVariant) }.AsEnumerable();

            hr = ((INativePropertiesCollection)_portableDeviceProperties).SetValues(ref values, out INativeReadOnlyPropertyValuesCollection results);

            if (CoreErrorHelper.Succeeded(hr))

            {

                hr = results.GetValue(ref propertyKey, out PropVariant _propVariant);

                if (CoreErrorHelper.Succeeded(hr))

                    hr = (HResult)_propVariant.Value;

                _propVariant.Dispose();

            }

            return hr;
        }

        protected void Dispose()
        {
            _ = Marshal.ReleaseComObject(_nativePortableDeviceValues);

            _nativePortableDeviceValues = null;

            _portableDeviceProperties = null;

            _disposed = true;
        }

        ~PortableDeviceValuesCollectionAbstract() => Dispose();
    }

    internal sealed class PortableDeviceValuesCollectionInternal : PortableDeviceValuesCollectionAbstract

    {
        public PortableDeviceValuesCollectionInternal(in Win32Native.PortableDevices.PropertySystem.IPortableDeviceValues portableDeviceValues, in PortableDeviceProperties portableDeviceProperties) : base(portableDeviceValues, portableDeviceProperties)
        {
        }
    }

    internal sealed class DisposablePortableDeviceValuesCollection : PortableDeviceValuesCollectionAbstract, IDisposableReadOnlyNativePropertyValuesCollection

    {
        public DisposablePortableDeviceValuesCollection(in Win32Native.PortableDevices.PropertySystem.IPortableDeviceValues portableDeviceValues, in PortableDeviceProperties portableDeviceProperties) : base(portableDeviceValues, portableDeviceProperties)
        {
        }

        void IDisposable.Dispose() => Dispose();
    }
}
