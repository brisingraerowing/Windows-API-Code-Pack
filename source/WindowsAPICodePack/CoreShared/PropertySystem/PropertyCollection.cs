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
using System.Collections.ObjectModel;

namespace Microsoft.WindowsAPICodePack

{
    // todo: use the new interfaces of WinCopies.Util instead.
    public interface IUIntIndexedCollection<T> : IEnumerable<T>, IEnumerable
    {
        uint Count { get; }

        bool IsReadOnly { get; }

        void Add(ref T item);

        void Clear();

        bool Contains(in T item);

        void CopyTo(in T[] array, uint arrayIndex);

        bool Remove(in T item);
    }

    public interface IUIntIndexedList<T> : IUIntIndexedCollection<T>, IEnumerable<T>, IEnumerable
    {
        T GetAt(ref uint index);

        uint? IndexOf(in T item);

        void RemoveAt(ref uint index);
    }

    public interface IUIntIndexedCollection : IEnumerable
    {
        uint Count { get; }

        object SyncRoot { get; }

        bool IsSynchronized { get; }

        void CopyTo(in Array array, uint index);
    }

    public interface IUIntIndexedList : IUIntIndexedCollection, IEnumerable
    {
        bool IsReadOnly { get; }

        bool IsFixedSize { get; }

        object GetAt(ref uint index);

        uint Add(ref object value);

        void Clear();

        bool Contains(in object value);

        uint? IndexOf(in object value);

        void Remove(in object value);

        void RemoveAt(ref uint index);
    }

    public interface IReadOnlyUIntIndexedList<out T> : IReadOnlyUIntIndexedCollection<T>, IEnumerable<T>, IEnumerable
    {
        T GetAt(ref uint index);
    }

    public interface IReadOnlyUIntIndexedCollection<out T> : IEnumerable<T>, IEnumerable
    {
        uint Count { get; }
    }

    [Serializable]
    [DebuggerDisplay("Count = {Count}")]
    public class Collection<T> : /*IDisposable, */ IUIntIndexedList<T>, IUIntIndexedCollection<T>, IEnumerable<T>, IEnumerable, IUIntIndexedList, IUIntIndexedCollection, IReadOnlyUIntIndexedList<T>, IReadOnlyUIntIndexedCollection<T>, WinCopies.Collections.IUIntIndexedCollection<T>

    {

        [NonSerialized]
        private object _syncRoot;

        bool IUIntIndexedCollection.IsSynchronized => false;

        object IUIntIndexedCollection.SyncRoot
        {
            get
            {
                if (_syncRoot is null)

                    if (Items is IUIntIndexedCollection c)

                        _syncRoot = c.SyncRoot;

                    else

                        _ = System.Threading.Interlocked.CompareExchange<object>(ref _syncRoot, new object(), null);

                return _syncRoot;
            }
        }

        private const bool _isReadOnly = false;

        protected INativeCollection<T> Items { get; private set; }

        public Collection(in INativeCollection<T> items) => Items = (items ?? throw new ArgumentNullException(nameof(items))).IsReadOnly ? throw new ArgumentException("The given collection is read-only.") : items;

        public T GetAt(ref uint index)
        {
            _ = Items.GetAt(ref index, out T item);

            return item;
        }

        T WinCopies.Collections.IUIntIndexedCollection<T>.this[uint index] => GetAt(ref index);

        object WinCopies.Collections.IUIntIndexedCollection.this[uint index] => GetAt(ref index);

        uint IUIntIndexedList.Add(ref object value)
        {
            var _value = (T)value;

            AddItem(ref _value);

            return Count;
        }

        bool IUIntIndexedList.Contains(in object value)

        {

            if (value is null) return false;

            var _value = (T)value;

            return Contains(_value);

        }

        uint? IUIntIndexedList.IndexOf(in object value)

        {

            if (value is null) return null;

            var _value = (T)value;

            return IndexOf(_value);

        }

        void IUIntIndexedList.Remove(in object value)

        {

            ThrowIfNull(value, nameof(value));

            var _value = (T)value;

            _ = Remove(_value);

        }

        object IUIntIndexedList.GetAt(ref uint index) => GetAt(ref index);

        bool IUIntIndexedCollection<T>.IsReadOnly => _isReadOnly;

        bool IUIntIndexedList.IsReadOnly => _isReadOnly;

        public bool IsFixedSize => Items.IsFixedSize;

        //public bool IsDisposed { get; private set; }

        public uint Count
        {
            get
            {
                _ = Items.GetCount(out uint count);

                return count;
            }
        }

        //protected virtual void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        Items.Dispose();

        //        Items = null;
        //    }

        //    IsDisposed = true;
        //}

        //public void Dispose()
        //{
        //    Dispose(true);

        //    GC.SuppressFinalize(this);
        //}

        //~Collection() => Dispose(false);

        public void Add(ref T item) => AddItem(ref item);

        public void Clear() => ClearItems();

        public bool Contains(in T item)
        {

            if (item

#if NETCORE

                is null

#else

                .Equals(null)

#endif

                ) return false;

            foreach (T _item in Items)

                if (_item.Equals(item))

                    return true;

            return false;
        }

        public void CopyTo(in T[] array, uint index)

        {

            ThrowIfNull(array, nameof(array));

            if (array.Length <= Count + index)

                throw new ArgumentException($"{nameof(array)} does not have the required length.");

            uint i = 0;

            _ = Items.GetAt(ref i, out T item);

            array[index] = item;

            for (i = 1; i < Count; i++)

            {

                _ = Items.GetAt(ref i, out item);

                array[++index] = item;

            }

        }

        void IUIntIndexedCollection.CopyTo(in Array array, uint index)

        {

            ThrowIfNull(array, nameof(array));

            if (array.Length <= Count + index)

                throw new ArgumentException($"{nameof(array)} does not have the required length.");

            uint i = 0;

            _ = Items.GetAt(ref i, out T item);

            array.SetValue(item, index);

            for (i = 1; i < Count; i++)

            {

                _ = Items.GetAt(ref i, out item);

                array.SetValue(item, index);

            }

        }

        public IEnumerator<T> GetEnumerator() => new WinCopies.Collections.UIntIndexedCollectionEnumerator<T>(this);

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public uint? IndexOf(in T item)

        {

            for (uint i = 0; i < Count; i++)

            {

                _ = Items.GetAt(ref i, out T _item);

                if (_item.Equals(item))

                    return i;

            }

            return null;

        }

        public bool Remove(in T item)

        {

            uint? index = IndexOf(item);

            if (index is null)

                return false;

            uint _index = index.Value;

            Marshal.ThrowExceptionForHR((int)Items.RemoveAt(ref _index));

            return true;

        }

        public void RemoveAt(ref uint index) => Items.RemoveAt(ref index);

        protected virtual void ClearItems() => Items.Clear();

        protected virtual void AddItem(ref T item)
        {
            ThrowIfNull(item, nameof(item));

            Marshal.ThrowExceptionForHR((int)Items.Add(ref item));
        }

        protected virtual void RemoveItem(ref uint index) => Marshal.ThrowExceptionForHR((int)Items.RemoveAt(ref index));
    }

    [Serializable]
    [DebuggerDisplay("Count = {Count}")]
    public class ReadOnlyCollection<T> : IUIntIndexedList<T>, IUIntIndexedCollection<T>, IEnumerable<T>, IEnumerable, IUIntIndexedList, IUIntIndexedCollection, IReadOnlyUIntIndexedList<T>, IReadOnlyUIntIndexedCollection<T>, WinCopies.Collections.IUIntIndexedCollection<T>
    {

        [NonSerialized]
        private object _syncRoot;

        bool IUIntIndexedCollection.IsSynchronized => false;

        object IUIntIndexedCollection.SyncRoot
        {
            get
            {
                if (_syncRoot is null)

                    if (Items is IUIntIndexedCollection c)

                        _syncRoot = c.SyncRoot;

                    else

                        _ = System.Threading.Interlocked.CompareExchange<object>(ref _syncRoot, new object(), null);

                return _syncRoot;
            }
        }

        private const bool _isReadOnly = true;

        bool IUIntIndexedCollection<T>.IsReadOnly => _isReadOnly;

        bool IUIntIndexedList.IsReadOnly => _isReadOnly;

        bool IUIntIndexedList.IsFixedSize => true;

        protected IReadOnlyNativeCollection<T> Items { get; private set; }

        public ReadOnlyCollection(in IReadOnlyNativeCollection<T> list) => Items = list;

        public T GetAt(ref uint index)
        {
            _ = Items.GetAt(ref index, out T item);

            return item;
        }

        object IUIntIndexedList.GetAt(ref uint index)
        {
            _ = Items.GetAt(ref index, out T item);

            return item;
        }

        T WinCopies.Collections.IUIntIndexedCollection<T>.this[uint index] => GetAt(ref index);

        object WinCopies.Collections.IUIntIndexedCollection.this[uint index] => GetAt(ref index);

        public uint Count { get; }

        public bool Contains(in T value)
        {

            foreach (T _value in Items)

                if (_value.Equals(value))

                    return true;

            return false;

        }

        public void CopyTo(in T[] array, uint index)

        {

            ThrowIfNull(array, nameof(array));

            _ = Items.GetCount(out uint count);

            if (array.Length <= count + index)

                throw new ArgumentException($"{nameof(array)} does not have the required length.");

            uint i = 0;

            _ = Items.GetAt(ref i, out T item);

            array[index] = item;

            for (i = 1; i < count; i++)

            {

                _ = Items.GetAt(ref i, out item);

                array[++index] = item;

            }

        }

        public IEnumerator<T> GetEnumerator() => new WinCopies.Collections.UIntIndexedCollectionEnumerator<T>(this);

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public uint? IndexOf(in T item)

        {

            for (uint i = 0; i < Count; i++)

            {

                _ = Items.GetAt(ref i, out T _item);

                if (_item.Equals(item))

                    return i;

            }

            return null;

        }

        uint? IUIntIndexedList.IndexOf(in object value) => value is T _value ? IndexOf(in _value) : null;

        bool IUIntIndexedList.Contains(in object value)

        {

            if (value is null) return false;

            var _value = (T)value;

            return Contains(_value);

        }

        void IUIntIndexedCollection.CopyTo(in Array array, uint index)

        {

            ThrowIfNull(array, nameof(array));

            if (array.Length <= Count + index)

                throw new ArgumentException($"{nameof(array)} does not have the required length.");

            uint i = 0;

            _ = Items.GetAt(ref i, out T item);

            array.SetValue(item, index);

            for (i = 1; i < Count; i++)

            {

                _ = Items.GetAt(ref i, out item);

                array.SetValue(item, index);

            }

        }

        uint IUIntIndexedList.Add(ref object value) => throw new InvalidOperationException("The current collection is read-only.");

        void IUIntIndexedList.Remove(in object value) => throw new InvalidOperationException("The current collection is read-only.");

        void IUIntIndexedList.RemoveAt(ref uint index) => throw new InvalidOperationException("The current collection is read-only.");

        void IUIntIndexedCollection<T>.Clear() => throw new InvalidOperationException("The current collection is read-only.");

        void IUIntIndexedList.Clear() => throw new InvalidOperationException("The current collection is read-only.");

        void IUIntIndexedCollection<T>.Add(ref T item) => throw new InvalidOperationException("The current collection is read-only.");

        bool IUIntIndexedCollection<T>.Remove(in T item) => throw new InvalidOperationException("The current collection is read-only.");

        void IUIntIndexedList<T>.RemoveAt(ref uint index) => throw new InvalidOperationException("The current collection is read-only.");
    }

}

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

        internal Func<ObjectProperty, IPropertyInfo> PropertyInfoDelegate { get; private set; }

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

                            objectProperty.PropertyInfo = PropertyInfoDelegate(objectProperty);

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

                return _getDictionaryDelegate().Values;
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

            _innerDictionary = new Dictionary<ObjectProperty>((int)Count, () => PropertyInfoDelegate = null);

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
                _getDictionaryDelegate = null;
                NativePropertiesCollection.Dispose();
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

            return _getDictionaryDelegate().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            if (IsDisposed)

                throw new InvalidOperationException("The current object is disposed.");

            return ((IEnumerable)_getDictionaryDelegate()).GetEnumerator();
        }

        #endregion
    }

    /// <summary>
    /// Represents a collection of property attributes.
    /// </summary>
    /// <seealso cref="ObjectPropertyAttribute"/>
    /// <seealso cref="ObjectProperty"/>
    /// <seealso cref="PropertyCollection"/>
    internal sealed class PropertyAttributeCollection : IEnumerable<ObjectPropertyAttribute>, WinCopies.Collections.IUIntIndexedCollection<ObjectPropertyAttribute>
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

        object WinCopies.Collections.IUIntIndexedCollection.this[uint index] => this[index];

        #endregion

        #region IEnumerable Support

        private class UIntIndexedCollectionEnumerator : UIntIndexedCollectionEnumeratorBase, IEnumerator<ObjectPropertyAttribute>

        {

            public UIntIndexedCollectionEnumerator(WinCopies.Collections.IUIntIndexedCollection<ObjectPropertyAttribute> uIntIndexedCollection) : base(uIntIndexedCollection) { }

            public ObjectPropertyAttribute Current => ((PropertyAttributeCollection)UIntIndexedCollection).IsDisposed ? throw new InvalidOperationException("The collection is disposed.") : ((WinCopies.Collections.IUIntIndexedCollection<ObjectPropertyAttribute>)UIntIndexedCollection)[Index.Value];

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
