using Microsoft.WindowsAPICodePack.Win32Native;
using Microsoft.WindowsAPICodePack.Win32Native.PropertySystem;
using Microsoft.WindowsAPICodePack.Win32Native.Shell.PropertySystem;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using WinCopies.Collections;
using IDisposable = WinCopies.Util.DotNetFix.IDisposable;
using static WinCopies.Util.Util;

namespace Microsoft.WindowsAPICodePack.PropertySystem
{
    // todo: this collection implements the .Net IReadOnlyDictionary interface, but this interface does not support the uint indexing.

    public sealed class PropertyCollection : IReadOnlyDictionary<PropertyKey, ObjectProperty>, IDisposable
    {

        #region Private Fields

        private Dictionary<PropertyKey, ObjectProperty> _innerDictionary;

        private INativePropertiesCollection _nativePropertiesCollection;

        private INativePropertyValuesCollection _nativePropertyValuesCollection;

        #endregion

        #region Public Properties

        public ObjectProperty this[PropertyKey key]
        {
            get
            {

                if (IsDisposed)

                    throw new InvalidOperationException("The current object is disposed.");

                if (_innerDictionary.TryGetValue(key, out ObjectProperty value))

                    return value;

                else
                {
                    for (uint i = 0; i < Count; i++)
                    {
                        var propertyKey = new PropertyKey();

                        _ = _nativePropertiesCollection.GetAt(i, ref propertyKey);

                        if (propertyKey == key)
                        {

                            var objectProperty = new ObjectProperty(_nativePropertiesCollection, _nativePropertyValuesCollection, propertyKey);

                            _innerDictionary.Add(key, objectProperty);

                            return objectProperty;
                        }
                    }

                    throw new IndexOutOfRangeException("The key was not found.");
                }
            }
        }

        public IEnumerable<PropertyKey> Keys
        {
            get
            {
                for (uint i = 0; i < Count; i++)
                {
                    if (IsDisposed)

                        throw new InvalidOperationException("The current object is disposed.");

                    var propertyKey = new PropertyKey();

                    _ = _nativePropertiesCollection.GetAt(i, ref propertyKey);

                    yield return propertyKey;
                }
            }
        }

        public IEnumerable<ObjectProperty> Values
        {
            get
            {
                if (IsDisposed)

                    throw new InvalidOperationException("The current object is disposed.");

                PopulateInnerDictionary();

                return _innerDictionary.Values;
            }
        }

        public uint Count
        {
            get
            {
                if (IsDisposed)

                    throw new InvalidOperationException("The current object is disposed.");

                _ = _nativePropertiesCollection.GetCount(out uint count);

                return count;
            }
        }

        #endregion

        #region Explicit Interface Implementations

        int IReadOnlyCollection<KeyValuePair<PropertyKey, ObjectProperty>>.Count => (int)Count;

        #endregion

        #region Public Constructors

        public PropertyCollection(in INativePropertiesCollection nativePropertyCollection)

        {

            ThrowIfNull(nativePropertyCollection, nameof(nativePropertyCollection));

            _nativePropertiesCollection = nativePropertyCollection;

            Marshal.ThrowExceptionForHR((int)nativePropertyCollection.GetValues(out _nativePropertyValuesCollection));

        }

        #endregion

        #region Private Methods

        private void PopulateInnerDictionary()
        {
            if (_innerDictionary.Count != Count)

                for (uint i = 0; i < Count; i++)
                {

                    var propertyKey = new PropertyKey();

                    _ = _nativePropertiesCollection.GetAt(i, ref propertyKey);

                    if (!_innerDictionary.ContainsKey(propertyKey))

                        _innerDictionary.Add(propertyKey, new ObjectProperty(_nativePropertiesCollection, _nativePropertyValuesCollection, propertyKey));
                }
        }

        #endregion

        #region Public Methods

        public bool ContainsKey(PropertyKey key)
        {
            if (IsDisposed)

                throw new InvalidOperationException("The current object is disposed.");

            foreach (PropertyKey propertyKey in Keys)

                if (propertyKey == key)

                    return true;

            return false;
        }

        public bool TryGetValue(PropertyKey key, out ObjectProperty value)
        {
            if (IsDisposed)

                throw new InvalidOperationException("The current object is disposed.");

            foreach (KeyValuePair<PropertyKey, ObjectProperty> _value in _innerDictionary)

                if (_value.Key == key)
                {

                    value = _value.Value;

                    return true;

                }

            foreach (PropertyKey propertyKey in Keys)

                if (key == propertyKey)
                {

                    var property = new ObjectProperty(_nativePropertiesCollection, _nativePropertyValuesCollection, propertyKey);

                    _innerDictionary.Add(propertyKey, property);

                    value = property;

                    return true;

                }

            value = null;

            return false;
        }

        #endregion

        #region IDisposable Support
        public bool IsDisposed { get; private set; } = false;

        // ~PropertyCollection()
        // {
        //   Dispose(false);
        // }

        public void Dispose()
        {
            if (!IsDisposed)
            {
                _innerDictionary.Clear();
                _innerDictionary = null;
                _nativePropertiesCollection.Dispose();
                _nativePropertiesCollection = null;
                _nativePropertyValuesCollection.Dispose();
                _nativePropertyValuesCollection = null;

                IsDisposed = true;
            }
        }
        #endregion

        #region IEnumerable Support

        public IEnumerator<KeyValuePair<PropertyKey, ObjectProperty>> GetEnumerator()
        {
            if (IsDisposed)

                throw new InvalidOperationException("The current object is disposed.");

            PopulateInnerDictionary();

            return _innerDictionary.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            if (IsDisposed)

                throw new InvalidOperationException("The current object is disposed.");

            PopulateInnerDictionary();

            return ((IEnumerable)_innerDictionary).GetEnumerator();
        }

        #endregion
    }

    /// <summary>
    /// Represents a collection of property attributes.
    /// </summary>
    /// <seealso cref="ObjectPropertyAttribute"/>
    /// <seealso cref="ObjectProperty"/>
    /// <seealso cref="PropertyCollection"/>
    internal sealed class PropertyAttributeCollection : IEnumerable<ObjectPropertyAttribute>, IUIntIndexedCollection<ObjectPropertyAttribute>
    {

        #region Private Fields

        private IReadOnlyNativePropertyValuesCollection _nativePropertyValuesCollection;

        #endregion

        #region Public Indexers

        public (Type type, object value) this[PropertyKey key]
        {
            get
            {

                if (IsDisposed)

                    throw new InvalidOperationException("The current object is disposed.");

                for (uint i = 0; i < Count; i++)
                {
                    var propertyKey = new PropertyKey();

                    var propVariant = new PropVariant();

                    _ = _nativePropertyValuesCollection.GetAt(i, ref propertyKey, ref propVariant);

                    if (propertyKey == key)
                    {
                        Type type = NativePropertyHelper.VarEnumToSystemType(propVariant.VarType);

                        object value = propVariant.Value;

                        propVariant.Dispose();

                        return (type, value);
                    }
                }

                throw new IndexOutOfRangeException("The key was not found.");
            }
        }

        public ObjectPropertyAttribute this[uint index]
        {
            get
            {
                if (IsDisposed)

                    throw new InvalidOperationException("The current object is disposed.");

                var propertyKey = new PropertyKey();

                var propVariant = new PropVariant();

                Marshal.ThrowExceptionForHR((int)_nativePropertyValuesCollection.GetAt(index, ref propertyKey, ref propVariant));

                var objectPropertyAttribute = new ObjectPropertyAttribute(propertyKey, NativePropertyHelper.VarEnumToSystemType(propVariant.VarType), propVariant.Value);

                propVariant.Dispose();

                return objectPropertyAttribute;

                throw new IndexOutOfRangeException("The key was not found.");
            }
        }

        #endregion

        #region Public Constructors

        public PropertyAttributeCollection(in IReadOnlyNativePropertyValuesCollection nativePropertyValuesCollection) => _nativePropertyValuesCollection = nativePropertyValuesCollection;

        #endregion

        #region Public Properties

        public uint Count
        {
            get
            {
                if (IsDisposed)

                    throw new InvalidOperationException("The current object is disposed.");

                _ = _nativePropertyValuesCollection.GetCount(out uint count);

                return count;
            }
        }

        #endregion

        #region IUIntIndexedCollection Support

        object IUIntIndexedCollection.this[uint index] => this[index];

        #endregion

        #region IEnumerable Support

        private class UIntIndexedCollectionEnumerator : UIntIndexedCollectionEnumeratorBase, IEnumerator<ObjectPropertyAttribute>

        {

            public UIntIndexedCollectionEnumerator(IUIntIndexedCollection<ObjectPropertyAttribute> uIntIndexedCollection) : base(uIntIndexedCollection) { }

            public ObjectPropertyAttribute Current => ((PropertyAttributeCollection)UIntIndexedCollection).IsDisposed ? throw new InvalidOperationException("The collection is disposed.") : ((IUIntIndexedCollection<ObjectPropertyAttribute>)UIntIndexedCollection)[Index.Value];

            object IEnumerator.Current => Current;

        }

        public IEnumerator<ObjectPropertyAttribute> GetEnumerator()
        {
            if (IsDisposed)

                throw new InvalidOperationException("The current object is disposed.");

            return new UIntIndexedCollectionEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        #endregion

        #region IDisposable Support
        public bool IsDisposed { get; private set; } = false;

        // ~PropertyCollection()
        // {
        //   Dispose(false);
        // }

        public void Dispose()
        {
            if (!IsDisposed)
            {
                _nativePropertyValuesCollection = null;

                IsDisposed = true;
            }
        }
        #endregion
    }
}
