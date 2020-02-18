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

    internal sealed class Dictionary<TValue> : IDictionary<PropertyKey, TValue>

    {

        private readonly Dictionary<PropertyKey, TValue> _innerDictionary = new Dictionary<PropertyKey, TValue>();

        private Action<PropertyKey, TValue> _addAction;

        private int _count;

        private Action _disposeAction;

        public Dictionary(in int count, Action disposeAction)
        {
            _addAction = (PropertyKey key, TValue value) =>
            {

                _innerDictionary.Add(key, value);

                if (Count == _count)

                    _disposeAction();

                _addAction = null;

                _disposeAction = null;

            };

            _count = count;

            _disposeAction = disposeAction;
        }

        public TValue this[PropertyKey key] { get => _innerDictionary[key]; set => _innerDictionary[key] = value; }

        public ICollection<PropertyKey> Keys => _innerDictionary.Keys;

        public ICollection<TValue> Values => _innerDictionary.Values;

        public int Count => _innerDictionary.Count;

        bool ICollection<KeyValuePair<PropertyKey, TValue>>.IsReadOnly => false;

        public void Add(PropertyKey key, TValue value) => _addAction(key, value);
        void ICollection<KeyValuePair<PropertyKey, TValue>>.Add(KeyValuePair<PropertyKey, TValue> item) => _addAction(item.Key, item.Value);
        void ICollection<KeyValuePair<PropertyKey, TValue>>.Clear() => _innerDictionary.Clear();
        bool ICollection<KeyValuePair<PropertyKey, TValue>>.Contains(KeyValuePair<PropertyKey, TValue> item) => ((ICollection<KeyValuePair<PropertyKey, TValue>>)_innerDictionary).Contains(item);
        public bool ContainsKey(PropertyKey key) => _innerDictionary.ContainsKey(key);
        void ICollection<KeyValuePair<PropertyKey, TValue>>.CopyTo(KeyValuePair<PropertyKey, TValue>[] array, int arrayIndex) => ((ICollection<KeyValuePair<PropertyKey, TValue>>)_innerDictionary).CopyTo(array, arrayIndex);
        public IEnumerator<KeyValuePair<PropertyKey, TValue>> GetEnumerator() => _innerDictionary.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)_innerDictionary).GetEnumerator();
        bool IDictionary<PropertyKey, TValue>.Remove(PropertyKey key) => _innerDictionary.Remove(key);
        bool ICollection<KeyValuePair<PropertyKey, TValue>>.Remove(KeyValuePair<PropertyKey, TValue> item) => ((ICollection<KeyValuePair<PropertyKey, TValue>>)_innerDictionary).Remove(item);
        public bool TryGetValue(PropertyKey key, out TValue value) => _innerDictionary.TryGetValue(key, out value);
    }

    // todo: this collection implements the .Net IReadOnlyDictionary interface, but this interface does not support the uint indexing.

    public sealed class PropertyCollection : IReadOnlyDictionary<PropertyKey, ObjectProperty>, IDisposable
    {

        #region Private/Internal Fields

        internal INativePropertiesCollection NativePropertiesCollection { get; }

        private INativePropertyValuesCollection _nativePropertyValuesCollection;

        internal Func<ObjectProperty, IPropertyInfo> _propertyInfoDelegate;

        private uint? _count;

        private Dictionary<ObjectProperty> _innerDictionary;

        private Func<Dictionary<ObjectProperty>> _getDictionaryDelegate;

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

                        _ = NativePropertiesCollection.GetAt(i, ref propertyKey);

                        if (propertyKey == key)
                        {

                            var objectProperty = new ObjectProperty(this, _nativePropertyValuesCollection, propertyKey);

                            objectProperty.PropertyInfo = _propertyInfoDelegate(objectProperty);

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

                    _ = NativePropertiesCollection.GetAt(i, ref propertyKey);

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

                PopulateDictionary();

                return _innerDictionary.Values;
            }
        }

        public uint Count
        {
            get
            {
                if (IsDisposed)

                    throw new InvalidOperationException("The current object is disposed.");

                if (_count is null)

                {

                    _ = NativePropertiesCollection.GetCount(out uint count);

                    _count = count;

                }

                return _count.Value;
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

            _innerDictionary = new Dictionary<ObjectProperty>((int)Count, () => _propertyInfoDelegate = null);

            _getDictionaryDelegate = () =>

            {

                PopulateDictionary();

                _getDictionaryDelegate = () => _innerDictionary;

                return _innerDictionary;

            };

            NativePropertiesCollection = nativePropertyCollection;

            Marshal.ThrowExceptionForHR((int)nativePropertyCollection.GetValues(out _nativePropertyValuesCollection));

        }

        #endregion

        #region Private Methods

        private void PopulateDictionary()
        {
            if ((int)Count != _innerDictionary.Count)

            {

                PropertyKey propertyKey;

                for (uint i = 0; i < Count; i++)
                {

                    propertyKey = new PropertyKey();

                    _ = NativePropertiesCollection.GetAt(i, ref propertyKey);

                    if (!_innerDictionary.ContainsKey(propertyKey))

                        _innerDictionary.Add(propertyKey, new ObjectProperty(this, _nativePropertyValuesCollection, propertyKey));
                }

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

                    var property = new ObjectProperty(this, _nativePropertyValuesCollection, propertyKey);

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
                ((ICollection<KeyValuePair<PropertyKey, ObjectProperty>>)_innerDictionary).Clear();
                _innerDictionary = null;
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

            PopulateDictionary();

            return _innerDictionary.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            if (IsDisposed)

                throw new InvalidOperationException("The current object is disposed.");

            PopulateDictionary();

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

        private IDisposableReadOnlyNativePropertyValuesCollection _nativePropertyValuesCollection;

        private Dictionary<ObjectPropertyAttribute> _innerDictionary;

        private uint? _count;

        private Func<Dictionary<ObjectPropertyAttribute>> _getDictionaryDelegate;

        #endregion

        #region Public Indexers

        public ObjectPropertyAttribute this[PropertyKey key]
        {
            get
            {

                if (IsDisposed)

                    throw new InvalidOperationException("The current object is disposed.");

                return _getDictionaryDelegate()[key];
            }
        }

        public ObjectPropertyAttribute this[uint index]
        {
            get
            {
                if (IsDisposed)

                    throw new InvalidOperationException("The current object is disposed.");

                // todo: replace this code by a custom dictionary that supports uint indexing.

                int i = 0;

                Dictionary<ObjectPropertyAttribute> dic = _getDictionaryDelegate();

                foreach (ObjectPropertyAttribute value in dic.Values)

                {

                    if (i++ == index)

                        return value;

                }

                throw new ArgumentOutOfRangeException(nameof(index), index, "'index' is out of range.");
            }
        }

        #endregion

        #region Public Properties

        public uint Count
        {
            get
            {
                if (IsDisposed)

                    throw new InvalidOperationException("The current object is disposed.");

                if (_count is null)

                    if (_nativePropertyValuesCollection is object)

                    {

                        _ = _nativePropertyValuesCollection.GetCount(out uint count);

                        _count = count;

                    }

                    else

                        _count = (uint)_innerDictionary.Count;

                return _count.Value;
            }
        }

        #endregion

        #region Public Constructors

        public PropertyAttributeCollection(in IDisposableReadOnlyNativePropertyValuesCollection nativePropertyValuesCollection)
        {
            ThrowIfNull(nativePropertyValuesCollection, nameof(nativePropertyValuesCollection));

            _innerDictionary = new Dictionary<ObjectPropertyAttribute>((int)Count, () => { _nativePropertyValuesCollection.Dispose(); _nativePropertyValuesCollection = null; });

            _getDictionaryDelegate = () =>

            {

                PopulateDictionary();

                _getDictionaryDelegate = () => _innerDictionary;

                return _innerDictionary;

            };

            _nativePropertyValuesCollection = nativePropertyValuesCollection;
        }

        #endregion

        private void PopulateDictionary()

        {

            PropertyKey propertyKey;

            PropVariant propVariant;

            for (uint i = 0; i < Count; i++)
            {
                propertyKey = new PropertyKey();

                using (propVariant = new PropVariant())

                {

                    _ = _nativePropertyValuesCollection.GetAt(i, ref propertyKey, ref propVariant);

                    _innerDictionary.Add(propertyKey, new ObjectPropertyAttribute(propertyKey, NativePropertyHelper.VarEnumToSystemType(propVariant.VarType), propVariant.Value));

                }
            }

        }

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
