//Copyright (c) Pierre Sprimont.  All rights reserved.

using Microsoft.WindowsAPICodePack.COMNative.PortableDevices.PropertySystem;
using Microsoft.WindowsAPICodePack.COMNative.PropertySystem;
using Microsoft.WindowsAPICodePack.PropertySystem;
using Microsoft.WindowsAPICodePack.Win32Native;
using Microsoft.WindowsAPICodePack.Win32Native.PropertySystem;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;

using static Microsoft.WindowsAPICodePack.COMNative.PortableDevices.PortableDeviceHelper;

namespace Microsoft.WindowsAPICodePack.PortableDevices.PropertySystem
{
    internal class PropertyCollection : WindowsAPICodePack.PropertySystem.PropertyCollection
    {
        protected internal new INativePropertiesCollection Items => base.Items;

        public PropertyCollection(in INativePropertiesCollection nativePropertyCollection) : base(nativePropertyCollection) { }
    }

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

        internal new INativePortableDeviceValueCollection Items => (INativePortableDeviceValueCollection)base.Items;

        public PortableDeviceValueCollection() : base(new NativeValueCollection((IPortableDeviceValues)new PortableDeviceValues())) { }

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
        private string _objectId;
        private PortableDevice _portableDevice;
        private IPortableDeviceKeyCollection _nativePortableDeviceKeyCollection;

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

            _portableDevice = portableDevice;

            ThrowWhenFailHResult(portableDevice.NativePortableDeviceProperties.GetSupportedProperties(_objectId, out _nativePortableDeviceKeyCollection));
        }

        ~PortableDeviceProperties() => Dispose(false);

        HResult INativePropertiesCollection.GetAt(in uint index, ref PropertyKey propertyKey) =>

            // As this type is internal and calling the Dispose method directly is not recommended, implementing a property and checking it at the top of this method to know whether the current object is disposed is not necessary.

            _nativePortableDeviceKeyCollection.GetAt(index, ref propertyKey);

        public HResult GetAttributes(ref PropertyKey propertyKey, out IDisposableReadOnlyNativePropertyValuesCollection attributes)
        {
            // As this type is internal and calling the Dispose method directly is not recommended, implementing a property and checking it at the top of this method to know whether the current object is disposed is not necessary.

            HResult hr = _portableDevice.NativePortableDeviceProperties.GetPropertyAttributes(_objectId, ref propertyKey, out COMNative.PortableDevices.PropertySystem.IPortableDeviceValues portableDeviceValues);

            attributes = new DisposablePortableDeviceValuesCollection(portableDeviceValues, null);

            return hr;
        }

        HResult INativePropertiesCollection.GetPropertyInfo(ref PropertyKey propertyKey, out IPropertyInfo propertyInfo)
        {
            HResult hr = GetAttributes(ref propertyKey, out IDisposableReadOnlyNativePropertyValuesCollection attributes);

            if (CoreErrorHelper.Succeeded(hr))
            {
                PropertyKey[] propertyKeys = { Attribute.Property.CanRead, Attribute.Property.CanWrite, Attribute.Property.CanDelete };

                bool[] values = new bool[propertyKeys.Length];

#if DEBUG
                if (propertyKey.FormatId == new Guid("ef6b490d-5cd8-437a-affc-da8b60ee4a3c") && propertyKey.PropertyId == 4)

                    Debug.WriteLine("Name property.");
#endif

                PropVariant propVariant;

                for (short i = 0; i < propertyKeys.Length; i++)
                {
                    hr = attributes.GetValue(ref propertyKeys[i], out propVariant);

                    if (!CoreErrorHelper.Succeeded(hr))
                    {
                        propertyInfo = null;

                        propVariant.Dispose();

                        propVariant = null;

                        return hr;
                    }

                    else

                        values[i] = propVariant.VarType == VarEnum.VT_BOOL && (bool)propVariant.Value;

                    propVariant.Dispose();

                    propVariant = null;
                }

                Debug.WriteLine($"Original CanRead value: {values[0]}");

                Debug.WriteLine($"Original IsReadOnly value: {!values[1]}");

                Debug.WriteLine($"Original CanWrite value: {values[2]}");

                propertyInfo = new PropertyInfo(true, !values[1], values[2]);

                return HResult.Ok;
            }

            else
            {
                propertyInfo = null;

                return hr;
            }
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

        public HResult GetValues(out INativePropertyValuesCollection values)
        {
            // As this type is internal and calling the Dispose method directly is not recommended, implementing a property and checking it at the top of this method to know whether the current object is disposed is not necessary.

            HResult hr = HResult.Ok;

            if (_portableDeviceValues is null)
            {
                hr = _portableDevice.NativePortableDeviceProperties.GetValues(_objectId, _nativePortableDeviceKeyCollection, out COMNative.PortableDevices.PropertySystem.IPortableDeviceValues portableDeviceValues);

                values = _portableDeviceValues = new PortableDeviceValuesCollectionInternal(portableDeviceValues, this);
            }

            else

                values = _portableDeviceValues;

            return hr;
        }

        // todo: method for ValueCollection collections.

        HResult INativePropertiesCollection.SetValues(ref IEnumerable<IProperty> values, out INativeReadOnlyPropertyValuesCollection results)
        {
            // As this type is internal and calling the Dispose method directly is not recommended, implementing a property and checking it at the top of this method to know whether the current object is disposed is not necessary.

            var _values = (COMNative.PortableDevices.PropertySystem.IPortableDeviceValues)new COMNative.PortableDevices.PropertySystem.PortableDeviceValues();

            PropertyKey propertyKey;

            HResult hr;

            foreach (IProperty value in values)
            {
                propertyKey = value.PropertyKey;

                hr = value.GetValue(out PropVariant propVariant);

                if (!CoreErrorHelper.Succeeded(hr))
                {
                    propVariant.Dispose();

                    results = null;

                    return hr;
                }

                hr = _values.SetValue(ref propertyKey, propVariant);

                propVariant.Dispose();

                if (!CoreErrorHelper.Succeeded(hr))
                {
                    results = null;

                    return hr;
                }
            }

            hr = _portableDevice.NativePortableDeviceProperties.SetValues(_objectId, _values, out COMNative.PortableDevices.PropertySystem.IPortableDeviceValues _results);

            results = new PortableDeviceValuesCollectionInternal(_results, null);

            return hr;
        }

        HResult INativePropertiesCollection.Delete(params PropertyKey[] properties) => Delete(properties);

        public HResult Delete(in IEnumerable<PropertyKey> properties)
        {
            var portableDeviceKeyCollection = (IPortableDeviceKeyCollection)new PortableDeviceKeyCollection();

            PropertyKey _propertyKey;

            foreach (PropertyKey propertyKey in properties)
            {
                _propertyKey = propertyKey;

                _ = portableDeviceKeyCollection.Add(ref _propertyKey);
            }

            return _portableDevice.NativePortableDeviceProperties.Delete(_objectId, portableDeviceKeyCollection);
        }
    }

    //internal sealed class PortableDevicePropertyInfo : IPropertyInfo

    //{
    //    private bool? _isReadable;
    //    private bool? _isReadOnly;
    //    private bool? _isRemovable;

    //    public ObjectProperty ObjectProperty { get; private set; }

    //    public PortableDevicePropertyInfo(ObjectProperty objectProperty) => ObjectProperty = objectProperty;

    //    bool? IPropertyInfo.IsReadable => (_isReadable ?? (_isReadable = GetAttributeValue(PropertySystem.Attribute.Property.CanRead))).Value;

    //    bool? IPropertyInfo.IsReadOnly => (_isReadOnly ?? (_isReadOnly = !GetAttributeValue(PropertySystem.Attribute.Property.CanWrite))).Value;

    //    bool? IPropertyInfo.IsRemovable => (_isRemovable ?? (_isRemovable = GetAttributeValue(PropertySystem.Attribute.Property.CanDelete))).Value;

    //    private bool GetAttributeValue(PropertyKey propertyKey)
    //    {

    //        ObjectPropertyAttribute objectPropertyAttribute;

    //        for (uint i = 0; i < ObjectProperty.Attributes.Count; i++)
    //        {

    //            objectPropertyAttribute = ObjectProperty.Attributes[i];

    //            if (objectPropertyAttribute.Equals(propertyKey) && (bool)objectPropertyAttribute.Value)

    //                return true;

    //        }

    //        return false;

    //    }
    //}

    internal abstract class PortableDeviceValuesCollectionAbstract : INativePropertyValuesCollection
    {
        private COMNative.PortableDevices.PropertySystem.IPortableDeviceValues _nativePortableDeviceValues;
        private PortableDeviceProperties _portableDeviceProperties;

        private bool _disposed = false;

        protected COMNative.PortableDevices.PropertySystem.IPortableDeviceValues NativePortableDeviceValues { get { Debug.Assert(!_disposed); return _nativePortableDeviceValues; } }

        protected PortableDeviceProperties PortableDeviceProperties { get { Debug.Assert(!_disposed); return _portableDeviceProperties; } }

        public bool IsReadOnly => _portableDeviceProperties is null;

        public PortableDeviceValuesCollectionAbstract(in COMNative.PortableDevices.PropertySystem.IPortableDeviceValues portableDeviceValues, in PortableDeviceProperties portableDeviceProperties)
        {
            _nativePortableDeviceValues = portableDeviceValues;

            _portableDeviceProperties = portableDeviceProperties;
        }

        HResult INativeReadOnlyPropertyValuesCollection.GetAt(in uint index, ref PropertyKey propertyKey, out PropVariant propVariant)
        {
#if CS7
            using (var _propVariant = new PropVariant())
            {
#else
            using var _propVariant = new PropVariant();
#endif

                HResult hr = _nativePortableDeviceValues.GetAt(index, ref propertyKey, _propVariant);

                propVariant = _propVariant;

                return hr;

#if CS7
            }
#endif
        }

        HResult INativeReadOnlyPropertyValuesCollection.GetCount(out uint count)
        {
            uint _count = 0;

            HResult hr = _nativePortableDeviceValues.GetCount(ref _count);

            count = _count;

            return hr;
        }

        HResult INativeReadOnlyPropertyValuesCollection.GetValue(ref PropertyKey propertyKey, out PropVariant propVariant)
        {
            var _propVariant = new PropVariant();

            HResult hr = _nativePortableDeviceValues.GetValue(ref propertyKey, _propVariant);

            propVariant = _propVariant;

            return hr;
        }

        HResult INativePropertyValuesCollection.SetValue(ref PropertyKey propertyKey, PropVariant propVariant)
        {
            if (IsReadOnly)

                throw new InvalidOperationException("This collection is read-only.");

            HResult hr = _nativePortableDeviceValues.SetValue(ref propertyKey, propVariant);

            if (!CoreErrorHelper.Succeeded(hr))

                return hr;

            IEnumerable<IProperty> values = new IProperty[] { new COMNative.PropertySystem.ObjectProperty(propertyKey, propVariant) }.AsEnumerable();

            hr = ((INativePropertiesCollection)_portableDeviceProperties).SetValues(ref values, out INativeReadOnlyPropertyValuesCollection results);

            if (CoreErrorHelper.Succeeded(hr))
            {
#if CS7
                using (var _propVariant = new PropVariant())
                {
#else
                using var _propVariant = new PropVariant();
#endif

                    PropertyKey propKey = CommandSystem.Common.Parameters.HResult;

                    hr = results.GetValue(ref propKey, out propVariant);

                    if (CoreErrorHelper.Succeeded(hr))

                        hr = (HResult)_propVariant.Value;

#if CS7
                }
#endif
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
        public PortableDeviceValuesCollectionInternal(in COMNative.PortableDevices.PropertySystem.IPortableDeviceValues portableDeviceValues, in PortableDeviceProperties portableDeviceProperties) : base(portableDeviceValues, portableDeviceProperties)
        {
            // Left empty.
        }
    }

    internal sealed class DisposablePortableDeviceValuesCollection : PortableDeviceValuesCollectionAbstract, IDisposableReadOnlyNativePropertyValuesCollection
    {
        public DisposablePortableDeviceValuesCollection(in COMNative.PortableDevices.PropertySystem.IPortableDeviceValues portableDeviceValues, in PortableDeviceProperties portableDeviceProperties) : base(portableDeviceValues, portableDeviceProperties)
        {
            // Left empty.
        }

        void IDisposable.Dispose() => Dispose();
    }
}
