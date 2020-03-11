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
using static Microsoft.WindowsAPICodePack.PropertySystem.CollectionBridgeCollectionHelper;

namespace Microsoft.WindowsAPICodePack.PropertySystem

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

    public interface ICollection<T> : IDisposable, IUIntIndexedList<T>, IUIntIndexedCollection<T>, IEnumerable<T>, IEnumerable, IUIntIndexedList, IUIntIndexedCollection, IReadOnlyUIntIndexedList<T>, IReadOnlyUIntIndexedCollection<T>, WinCopies.Collections.IUIntIndexedCollection<T>

    {



    }

    [Serializable]
    [DebuggerDisplay("Count = {Count}")]
    public class Collection<T> : IDisposable, IUIntIndexedList<T>, IUIntIndexedCollection<T>, IEnumerable<T>, IEnumerable, IUIntIndexedList, IUIntIndexedCollection, IReadOnlyUIntIndexedList<T>, IReadOnlyUIntIndexedCollection<T>, WinCopies.Collections.IUIntIndexedCollection<T>, ICollection<T>, ICollectionBridgeCollectionInternal, ICollectionBridgeCollection

    {

        // todo: replace this by the same method of the WinCopies.Util package

        private void ThrowIfDisposed()

        {

            if (IsDisposed)

                throw new InvalidOperationException("The collection is disposed.");

        }

        [NonSerialized]
        private object _syncRoot;
        private INativeCollection<T> items;

        bool IUIntIndexedCollection.IsSynchronized => false;

        object IUIntIndexedCollection.SyncRoot
        {
            get
            {
                ThrowIfDisposed();

                if (_syncRoot is null)

                    if (Items is IUIntIndexedCollection c)

                        _syncRoot = c.SyncRoot;

                    else

                        _ = System.Threading.Interlocked.CompareExchange<object>(ref _syncRoot, new object(), null);

                return _syncRoot;
            }
        }

        private const bool _isReadOnly = false;

        protected internal INativeCollection<T> Items { get { ThrowIfDisposed(); return items; } private set { ThrowIfDisposed(); items = value; } }

        public Collection(in INativeCollection<T> items) => this.items = (items ?? throw new ArgumentNullException(nameof(items))).IsReadOnly ? throw new ArgumentException("The given collection is read-only.") : items.IsDisposed ? throw new ObjectDisposedException(nameof(items)) : items;

        private WinCopies.Util.DotNetFix.IDisposable _collectionBridge;

        private IDisposable CollectionBridge { get { ThrowIfDisposed(); return _collectionBridge.IsDisposed ? throw new ObjectDisposedException(nameof(CollectionBridge)) : _collectionBridge; } }

        IDisposable ICollectionBridgeCollectionInternal.CollectionBridge => CollectionBridge;

        public Collection(in INativeCollection<T> items, in IDisposable collectionBridge) : this(items) => _collectionBridge = collectionBridge ?? throw new ArgumentNullException(nameof(collectionBridge));

        object ICollectionBridgeCollectionInternal.GetNativeItems(in object collectionBridge) => GetNativeItems(this, collectionBridge);

        object ICollectionBridgeCollectionInternal.Items => Items;

        public T GetAt(ref uint index) => GetItem(ref index);

        protected virtual T GetItem(ref uint index)

        {
            ThrowIfDisposed();

            _ = Items.GetAt(ref index, out T item);

            return item;
        }

        T WinCopies.Collections.IUIntIndexedCollection<T>.this[uint index] => GetAt(ref index);

        object WinCopies.Collections.IUIntIndexedCollection.this[uint index] => GetAt(ref index);

        uint IUIntIndexedList.Add(ref object value)
        {
            ThrowIfDisposed();

            var _value = (T)value;

            AddItem(ref _value);

            return Count;
        }

        bool IUIntIndexedList.Contains(in object value)

        {
            ThrowIfDisposed();

            if (value is null) return false;

            var _value = (T)value;

            return Contains(_value);
        }

        uint? IUIntIndexedList.IndexOf(in object value)

        {
            ThrowIfDisposed();

            if (value is null) return null;

            var _value = (T)value;

            return IndexOf(_value);
        }

        void IUIntIndexedList.Remove(in object value)

        {
            ThrowIfDisposed();

            var _value = (T)value;

            _ = Remove(_value);
        }

        object IUIntIndexedList.GetAt(ref uint index) => GetAt(ref index);

        bool IUIntIndexedCollection<T>.IsReadOnly
        {
            get
            {
                ThrowIfDisposed();

                return _isReadOnly;
            }
        }

        bool IUIntIndexedList.IsReadOnly
        {
            get
            {
                ThrowIfDisposed();

                return _isReadOnly;
            }
        }

        public bool IsFixedSize
        {
            get
            {
                ThrowIfDisposed();

                return Items.IsFixedSize;
            }
        }

        public bool IsDisposed { get; private set; }

        protected virtual void Dispose(bool disposing)
        {
            if (!IsDisposed)

            {
                if (disposing)
                {
                    _collectionBridge = null;

                    Items.Dispose();

                    Items = null;
                }
            }

            IsDisposed = true;
        }

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        ~Collection() => Dispose(false);

        public uint Count
        {
            get
            {
                _ = Items.GetCount(out uint count);

                return count;
            }
        }

        public void Add(ref T item) => AddItem(ref item);

        public void Clear() => ClearItems();

        public bool Contains(in T item)
        {
            ThrowIfDisposed();

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
            ThrowIfDisposed();

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

        public IEnumerator<T> GetEnumerator() => Items.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public uint? IndexOf(in T item)

        {
            ThrowIfDisposed();

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
            ThrowIfDisposed();

            uint? index = IndexOf(item);

            if (index is null)

                return false;

            uint _index = index.Value;

            Marshal.ThrowExceptionForHR((int)Items.RemoveAt(_index));

            return true;

        }

        public void RemoveAt(ref uint index) => Items.RemoveAt(index);

        protected virtual void ClearItems() => Items.Clear();

        protected virtual void AddItem(ref T item)
        {
            ThrowIfDisposed();

            ThrowIfNull(item, nameof(item));

            Marshal.ThrowExceptionForHR((int)Items.Add(ref item));
        }

        protected virtual void RemoveItem(ref uint index)
        {
            ThrowIfDisposed();

            Marshal.ThrowExceptionForHR((int)Items.RemoveAt(index));
        }
    }

    [Serializable]
    [DebuggerDisplay("Count = {Count}")]
    public class ReadOnlyCollection<T> : IUIntIndexedList<T>, IUIntIndexedCollection<T>, IEnumerable<T>, IEnumerable, IUIntIndexedList, IUIntIndexedCollection, IReadOnlyUIntIndexedList<T>, IReadOnlyUIntIndexedCollection<T>, WinCopies.Collections.IUIntIndexedCollection<T>, WinCopies.Util.DotNetFix.IDisposable, ICollection<T>, ICollectionBridgeCollectionInternal, ICollectionBridgeCollection
    {

        public bool IsDisposed { get; private set; }

        protected virtual void Dispose(bool disposing)
        {
            if (!IsDisposed)

            {
                if (disposing)
                {
                    _collectionBridge = null;

                    Items.Dispose();

                    _items = null;
                }
            }

            IsDisposed = true;
        }

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        ~ReadOnlyCollection() => Dispose(false);

        [NonSerialized]
        private object _syncRoot;

        bool IUIntIndexedCollection.IsSynchronized => false;

        object IUIntIndexedCollection.SyncRoot
        {
            get
            {

                ThrowIfDisposed();

                if (_syncRoot is null)

                    if (Items is IUIntIndexedCollection c)

                        _syncRoot = c.SyncRoot;

                    else

                        _ = System.Threading.Interlocked.CompareExchange<object>(ref _syncRoot, new object(), null);

                return _syncRoot;
            }
        }

        private const bool _isReadOnly = true;

        bool IUIntIndexedCollection<T>.IsReadOnly
        {
            get
            {

                ThrowIfDisposed();

                return _isReadOnly;
            }
        }

        bool IUIntIndexedList.IsReadOnly
        {
            get
            {

                ThrowIfDisposed();

                return _isReadOnly;
            }
        }

        bool IUIntIndexedList.IsFixedSize
        {
            get
            {

                ThrowIfDisposed();

                return true;
            }
        }

        // todo: replace this by the same method of the WinCopies.Util package

        private void ThrowIfDisposed()

        {

            if (IsDisposed)

                throw new InvalidOperationException("The collection is disposed.");

        }

        private INativeReadOnlyCollection<T> _items;

        protected INativeReadOnlyCollection<T> Items
        {
            get
            {

                ThrowIfDisposed();

                return _items;
            }
        }

        object ICollectionBridgeCollectionInternal.Items => Items;

        public ReadOnlyCollection(in INativeReadOnlyCollection<T> list) => _items = (list ?? throw new ArgumentNullException(nameof(list))).IsDisposed ? throw new ObjectDisposedException(nameof(list)) : list;

        public ReadOnlyCollection(in Collection<T> collection) : this(collection.Items) { } 

        private IDisposable _collectionBridge;

        IDisposable ICollectionBridgeCollectionInternal.CollectionBridge
        {
            get
            {

                ThrowIfDisposed();

                return _collectionBridge;
            }
        }

        public ReadOnlyCollection(in INativeReadOnlyCollection<T> list, IDisposable collectionBridge) : this(list) => _collectionBridge = collectionBridge ?? throw new ArgumentNullException(nameof(collectionBridge));

        public ReadOnlyCollection(in Collection<T> collection, IDisposable collectionBridge) : this(collection) => _collectionBridge = collectionBridge ?? throw new ArgumentNullException(nameof(collectionBridge));

        object ICollectionBridgeCollectionInternal.GetNativeItems(in object collectionBridge) => GetNativeItems(this, collectionBridge);

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

        public uint Count

        {

            get

            {

                _ = Items.GetCount(out uint count);

                return count;

            }

        }

        public bool Contains(in T value)
        {

            ThrowIfDisposed();

            foreach (T _value in Items)

                if (_value.Equals(value))

                    return true;

            return false;

        }

        public void CopyTo(in T[] array, uint index)

        {

            ThrowIfDisposed();

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

        public IEnumerator<T> GetEnumerator() => Items.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public uint? IndexOf(in T item)

        {

            ThrowIfDisposed();

            for (uint i = 0; i < Count; i++)

            {

                _ = Items.GetAt(ref i, out T _item);

                if (_item.Equals(item))

                    return i;

            }

            return null;

        }

        uint? IUIntIndexedList.IndexOf(in object value)
        {

            ThrowIfDisposed();

            return value is T _value ? IndexOf(in _value) : null;

        }

        bool IUIntIndexedList.Contains(in object value)

        {

            ThrowIfDisposed();

            if (value is null) return false;

            var _value = (T)value;

            return Contains(_value);

        }

        void IUIntIndexedCollection.CopyTo(in Array array, uint index)

        {

            ThrowIfDisposed();

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

    public static class PropertySystemHelper

    {

        public static void ThrowWhenFailHResult(HResult hResult)

        {

            if (!CoreErrorHelper.Succeeded(hResult))

                throw new PropertySystemException("An operation has not succeeded, see the inner exception.", Marshal.GetExceptionForHR((int)hResult));

        }

    }

    internal sealed class Dictionary<TValue> : IDictionary<PropertyKey, TValue>

    {

        private readonly Dictionary<PropertyKey, TValue> _innerDictionary = new Dictionary<PropertyKey, TValue>();

        private Action<PropertyKey, TValue> _addAction;

        private readonly int _count;

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

        public System.Collections.Generic.ICollection<PropertyKey> Keys => _innerDictionary.Keys;

        public System.Collections.Generic.ICollection<TValue> Values => _innerDictionary.Values;

        public int Count => _innerDictionary.Count;

        bool System.Collections.Generic.ICollection<KeyValuePair<PropertyKey, TValue>>.IsReadOnly => false;

        public void Add(PropertyKey key, TValue value) => _addAction(key, value);
        void System.Collections.Generic.ICollection<KeyValuePair<PropertyKey, TValue>>.Add(KeyValuePair<PropertyKey, TValue> item) => _addAction(item.Key, item.Value);
        void System.Collections.Generic.ICollection<KeyValuePair<PropertyKey, TValue>>.Clear() => _innerDictionary.Clear();
        bool System.Collections.Generic.ICollection<KeyValuePair<PropertyKey, TValue>>.Contains(KeyValuePair<PropertyKey, TValue> item) => ((ICollection<KeyValuePair<PropertyKey, TValue>>)_innerDictionary).Contains(item);
        public bool ContainsKey(PropertyKey key) => _innerDictionary.ContainsKey(key);
        void System.Collections.Generic.ICollection<KeyValuePair<PropertyKey, TValue>>.CopyTo(KeyValuePair<PropertyKey, TValue>[] array, int arrayIndex) => ((System.Collections.Generic.ICollection<KeyValuePair<PropertyKey, TValue>>)_innerDictionary).CopyTo(array, arrayIndex);
        public IEnumerator<KeyValuePair<PropertyKey, TValue>> GetEnumerator() => _innerDictionary.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)_innerDictionary).GetEnumerator();
        bool IDictionary<PropertyKey, TValue>.Remove(PropertyKey key) => _innerDictionary.Remove(key);
        bool System.Collections.Generic.ICollection<KeyValuePair<PropertyKey, TValue>>.Remove(KeyValuePair<PropertyKey, TValue> item) => ((ICollection<KeyValuePair<PropertyKey, TValue>>)_innerDictionary).Remove(item);
        public bool TryGetValue(PropertyKey key, out TValue value) => _innerDictionary.TryGetValue(key, out value);
    }

    // todo: this collection implements the .Net IReadOnlyDictionary interface, but this interface does not support the uint indexing.

    public sealed class PropertyCollection : IReadOnlyDictionary<PropertyKey, ObjectProperty>, IDisposable
    {

        #region Private/Internal Fields

        internal INativePropertiesCollection Items { get; }

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

                        _ = Items.GetAt(i, ref propertyKey);

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

                    _ = Items.GetAt(i, ref propertyKey);

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

                    _ = Items.GetCount(out uint count);

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

            Items = nativePropertyCollection;

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

                    _ = Items.GetAt(i, ref propertyKey);

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
                ((System.Collections.Generic.ICollection<KeyValuePair<PropertyKey, ObjectProperty>>)_innerDictionary).Clear();
                _innerDictionary = null;
                _getDictionaryDelegate = null;
                Items.Dispose();
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

        private readonly Dictionary<ObjectPropertyAttribute> _innerDictionary;

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
