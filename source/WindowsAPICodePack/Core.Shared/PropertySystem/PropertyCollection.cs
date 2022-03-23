using Microsoft.WindowsAPICodePack.COMNative.PropertySystem;
using Microsoft.WindowsAPICodePack.COMNative.Shell.PropertySystem;
using Microsoft.WindowsAPICodePack.Win32Native;
using Microsoft.WindowsAPICodePack.Win32Native.PropertySystem;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;

using WinCopies.Collections;

#if WAPICP3
using Microsoft.WindowsAPICodePack.COMNative;

using WinCopies.Collections.DotNetFix;
using WinCopies.Collections.DotNetFix.Generic;
using WinCopies.Collections.Enumeration.Generic;

using static WinCopies.ThrowHelper;

using IDisposable = WinCopies.DotNetFix.IDisposable;
#else
using static WinCopies.Util.Util;

using IDisposable = WinCopies.Util.DotNetFix.IDisposable;
#endif

namespace Microsoft.WindowsAPICodePack.PropertySystem
{
#if !WAPICP3
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

    public interface IReadOnlyUIntIndexedCollection<
#if CS5
        out
#endif
        T> : IEnumerable<T>, IEnumerable
    {
        uint Count { get; }
    }
#endif

    public interface IUIntIndexedCollection :
#if WAPICP3
        WinCopies.Collections.DotNetFix.IUIntIndexedCollection
    {
#else
        IEnumerable
    {
        uint Count { get; }

        object SyncRoot { get; }

        bool IsSynchronized { get; }

        void CopyTo(in Array array, uint index);
#endif
        // Left empty.
    }

    public interface IReadOnlyUIntIndexedList<
#if CS5
        out
#endif
        T> :
#if WAPICP3
       WinCopies.Collections.DotNetFix.Generic.IReadOnlyUIntIndexedList<T>, WinCopies.Collections.DotNetFix.IReadOnlyUIntIndexedList
#else
        IReadOnlyUIntIndexedCollection<T>, IEnumerable<T>, IEnumerable
#endif
    {
        T GetAt(ref uint index);
    }

    public interface IUIntIndexedList : IUIntIndexedCollection,
#if WAPICP3
        IReadOnlyUIntIndexedList
#else
        IEnumerable
#endif
    {
        bool IsReadOnly { get; }

        bool IsFixedSize { get; }

        object GetAt(ref uint index);

        uint Add(ref object value);

        bool Contains(
#if !WAPICP3
in
#endif
            object value);

        uint? IndexOf(
#if !WAPICP3
in
#endif
            object value);

        void Remove(
#if !WAPICP3
in
#endif
            object value);

        void RemoveAt(ref uint index);

        void Clear();
    }

    public interface ICollection<T> : IDisposable, IUIntIndexedCollection, IUIntIndexedList,
#if !WAPICP3
     IUIntIndexedList<T>, IUIntIndexedCollection<T>, IEnumerable<T>, IEnumerable, IReadOnlyUIntIndexedCollection<T>, WinCopies.Collections.
#endif
        IUIntIndexedCollection<T>, IReadOnlyUIntIndexedList<T>
    {
        // Left empty.
    }

    [Serializable]
    [DebuggerDisplay("Count = {Count}")]
    public class Collection<T> : IDisposable, ICollection<T>
#if !WAPICP3
        , IUIntIndexedList<T>, IUIntIndexedCollection<T>, IEnumerable<T>, IEnumerable, IUIntIndexedList, IUIntIndexedCollection, IReadOnlyUIntIndexedList<T>, IReadOnlyUIntIndexedCollection<T>, WinCopies.Collections.IUIntIndexedCollection<T>
#endif
    {
        [NonSerialized]
        private object _syncRoot;
        private INativeCollection<T> _items;
        private const bool _isReadOnly = false;

        protected void ThrowIfDisposed() => WinCopies.
#if WAPICP3
            ThrowHelper
#else
            Util.Util
#endif
            .ThrowIfDisposed(this);

        protected U GetOrThrowIfDisposed<U>(in U value) => WinCopies.
#if !WAPICP3
            Util.
#endif
            ThrowHelper.GetOrThrowIfDisposed(this, value);

        bool
#if WAPICP3
           WinCopies.Collections.DotNetFix.
#endif
            IUIntIndexedCollection.IsSynchronized => false;

        object
#if WAPICP3
           WinCopies.Collections.DotNetFix.
#endif
             IUIntIndexedCollection.SyncRoot
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

        protected internal INativeCollection<T> Items { get => GetOrThrowIfDisposed(_items); private set => _items = GetOrThrowIfDisposed(value); }

        public Collection(in INativeCollection<T> items) => _items = (items ?? throw new ArgumentNullException(nameof(items))).IsReadOnly ? throw new ArgumentException("The given collection is read-only.") : items.IsDisposed ? throw new ObjectDisposedException(nameof(items)) : items;

        public T GetAt(ref uint index) => GetItem(ref index);

        protected virtual T GetItem(ref uint index)
        {
            ThrowIfDisposed();

            _ = Items.GetAt(ref index, out T item);

            return item;
        }

        T WinCopies.Collections.
#if WAPICP2
            IUIntIndexedCollection
#else
            DotNetFix.Generic.IReadOnlyUIntIndexedList
#endif
            <T>.this[uint index] => GetAt(ref index);

        object WinCopies.Collections.
#if WAPICP2
            IUIntIndexedCollection
#else
            DotNetFix.IReadOnlyUIntIndexedList
#endif
            .this[uint index] => GetAt(ref index);

        uint IUIntIndexedList.Add(ref object value)
        {
            var _value = (T)GetOrThrowIfDisposed(value);

            AddItem(ref _value);

            value = _value;

            return Count;
        }

        bool IUIntIndexedList.Contains(
#if !WAPICP3
in
#endif
             object value)
#if WAPICP3
            => Contains(value);

        bool IReadOnlyUIntIndexedList.Contains(in object value) => Contains(value);

        private bool Contains(in object value)
#endif
            =>
#if !CS9
            !(
#endif
            GetOrThrowIfDisposed(value) is
#if CS9
            not
#endif
            null && Contains((T)value)
#if !CS9
            )
#endif
            ;

        uint? IUIntIndexedList.IndexOf(
#if !WAPICP3
in
#endif
             object value)
#if WAPICP3
            => IndexOf(value);

        uint? IReadOnlyUIntIndexedList.IndexOf(in object value) => IndexOf(value);

        private uint? IndexOf(in object value)
#endif
            => GetOrThrowIfDisposed(value) is null ? null : IndexOf((T)value);

        void IUIntIndexedList.Remove(
#if !WAPICP3
in
#endif
             object value) => Remove((T)GetOrThrowIfDisposed(value));

        object IUIntIndexedList.GetAt(ref uint index) => GetAt(ref index);

        private bool IsReadOnly => GetOrThrowIfDisposed(_isReadOnly);

#if WAPICP3
        bool IUIntIndexedList.IsReadOnly => IsReadOnly;
#else
        bool IUIntIndexedCollection<T>.IsReadOnly => IsReadOnly;

        bool IUIntIndexedList.IsReadOnly => IsReadOnly;
#endif

        public bool IsFixedSize => Items.IsFixedSize;

        public bool IsDisposed { get; private set; }

        protected virtual void Dispose(bool disposing)
        {
            if (!IsDisposed)
            {
                if (disposing)
                {
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

#if WAPICP3
        void IUIntIndexedCollection<T>.Add(T item) => Add(ref item);
#endif

        public void Clear() => ClearItems();

        public bool Contains(
#if !WAPICP3
            in
#endif
            T item)
        {
            if (GetOrThrowIfDisposed(item)
#if CS8
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

        public void CopyTo(
#if !WAPICP3
            in
#endif
            T[] array, uint index)
        {
            uint i = (GetOrThrowIfDisposed(array) ?? throw GetArgumentNullException(nameof(array))).Length <= Count + index ? throw new ArgumentException($"{nameof(array)} does not have the required length.") : 0u;

            _ = _items.GetAt(ref i, out T item);

            array[index] = item;

            for (i = 1; i < Count; i++)
            {
                _ = Items.GetAt(ref i, out item);

                array[++index] = item;
            }
        }

        void
#if WAPICP3
            WinCopies.Collections.DotNetFix.
#endif
            IUIntIndexedCollection.CopyTo(in Array array,
#if WAPICP3
            int
#else
            uint
#endif
            index)
        {
            uint i = (GetOrThrowIfDisposed(array) ?? throw GetArgumentNullException(nameof(array))).Length <= Count + index ? throw new ArgumentException($"{nameof(array)} does not have the required length.") : 0u;

            _ = _items.GetAt(ref i, out T item);

            array.SetValue(item, index);

            for (i = 1; i < Count; i++)
            {
                _ = Items.GetAt(ref i, out item);

                array.SetValue(item, index);
            }
        }

        public System.Collections.Generic.IEnumerator<T> GetEnumerator() => Items.GetEnumerator();

        System.Collections.IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

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

        public bool Remove(
#if !WAPICP3
            in
#endif
            T item)
        {
            ThrowIfDisposed();

            uint? index = IndexOf(item);

            if (index is null)

                return false;

            uint _index = index.Value;

            CoreErrorHelper.ThrowExceptionForHResult(Items.RemoveAt(_index));

            return true;
        }

        public void RemoveAt(ref uint index) => Items.RemoveAt(index);

        protected virtual void ClearItems() => Items.Clear();

        protected virtual void AddItem(ref T item)
        {
            ThrowIfDisposed();

#if WAPICP3
            if (item == null)

                throw GetArgumentNullException(
#else
            ThrowIfNull(item,
#endif
                    nameof(item));

            CoreErrorHelper.ThrowExceptionForHResult(Items.Add(ref item));
        }

        protected virtual void RemoveItem(ref uint index)
        {
            ThrowIfDisposed();

            CoreErrorHelper.ThrowExceptionForHResult(Items.RemoveAt(index));
        }

#if WAPICP3
        protected IUIntCountableEnumerator<T> GetUIntCountableEnumerator() => new UIntCountableEnumerator<System.Collections.Generic.IEnumerator<T>, T>(GetEnumerator(), () => Count);

        IUIntCountableEnumerator<T> IUIntCountableEnumerable<T, IUIntCountableEnumerator<T>>.GetEnumerator() => GetUIntCountableEnumerator();
        IUIntCountableEnumerator<T> WinCopies.Collections.Enumeration.DotNetFix.IEnumerable<IUIntCountableEnumerator<T>>.GetEnumerator() => GetUIntCountableEnumerator();
        IUIntCountableEnumerator<T> IEnumerable<T, IUIntCountableEnumerator<T>>.GetEnumerator() => GetUIntCountableEnumerator();
        IUIntCountableEnumerator WinCopies.Collections.Enumeration.DotNetFix.IEnumerable<IUIntCountableEnumerator>.GetEnumerator() => GetUIntCountableEnumerator();
#endif
    }

    [Serializable]
    [DebuggerDisplay("Count = {Count}")]
    public class ReadOnlyCollection<T> :
#if !WAPICP3
IUIntIndexedList<T>, IUIntIndexedCollection<T>, IEnumerable<T>, IEnumerable, IUIntIndexedList, IUIntIndexedCollection, IReadOnlyUIntIndexedList<T>, IReadOnlyUIntIndexedCollection<T>, WinCopies.Collections.IUIntIndexedCollection<T>, WinCopies.Util.DotNetFix.IDisposable,
#endif
        ICollection<T>
    {
        private const bool _isReadOnly = true;

        public bool IsDisposed { get; private set; }

        protected virtual void Dispose(bool disposing)
        {
            if (!IsDisposed && disposing)
            {
                Items.Dispose();

                _items = null;
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

        protected void ThrowIfDisposed() => WinCopies.
#if WAPICP3
            ThrowHelper
#else
            Util.Util
#endif
            .ThrowIfDisposed(this);

        protected U GetOrThrowIfDisposed<U>(in U value) => WinCopies.
#if !WAPICP3
            Util.
#endif
            ThrowHelper.GetOrThrowIfDisposed(this, value);

        bool
#if WAPICP3
            WinCopies.Collections.DotNetFix.
#endif
            IUIntIndexedCollection.IsSynchronized => false;

        object
#if WAPICP3
            WinCopies.Collections.DotNetFix.
#endif
            IUIntIndexedCollection.SyncRoot
        {
            get
            {
                if (GetOrThrowIfDisposed(_syncRoot) is null)

                    if (Items is IUIntIndexedCollection c)

                        _syncRoot = c.SyncRoot;

                    else

                        _ = System.Threading.Interlocked.CompareExchange<object>(ref _syncRoot, new object(), null);

                return _syncRoot;
            }
        }

#if !WAPICP3
        bool IUIntIndexedCollection<T>.IsReadOnly => GetOrThrowIfDisposed(_isReadOnly);
#endif

        bool IUIntIndexedList.IsReadOnly => GetOrThrowIfDisposed(_isReadOnly);

        bool IUIntIndexedList.IsFixedSize => GetOrThrowIfDisposed(true);

        private INativeReadOnlyCollection<T> _items;

        protected INativeReadOnlyCollection<T> Items => GetOrThrowIfDisposed(_items);

        public ReadOnlyCollection(in INativeReadOnlyCollection<T> list) => _items = (list ?? throw new ArgumentNullException(nameof(list))).IsDisposed ? throw new ObjectDisposedException(nameof(list)) : list;

        public ReadOnlyCollection(in Collection<T> collection) : this(collection.Items) { /* Left empty. */ }

#if !WAPICP3
        private IDisposable _collectionBridge;

        public ReadOnlyCollection(in INativeReadOnlyCollection<T> list, IDisposable collectionBridge) : this(list) => _collectionBridge = collectionBridge ?? throw new ArgumentNullException(nameof(collectionBridge));

        public ReadOnlyCollection(in Collection<T> collection, IDisposable collectionBridge) : this(collection) => _collectionBridge = collectionBridge ?? throw new ArgumentNullException(nameof(collectionBridge));
#endif

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

        T WinCopies.Collections.
#if WAPICP3
            DotNetFix.Generic.IReadOnlyUIntIndexedList
#else
            IUIntIndexedCollection
#endif
            <T>.this[uint index] => GetAt(ref index);

        object

#if WAPICP3
            IReadOnlyUIntIndexedList
#else
            WinCopies.Collections.IUIntIndexedCollection
#endif
            .this[uint index] => GetAt(ref index);

        public uint Count
        {
            get
            {
                _ = Items.GetCount(out uint count);

                return count;
            }
        }

        public bool Contains(
#if !WAPICP3
            in
#endif
            T value)
        {
            foreach (T _value in Items)

                if (_value.Equals(value))

                    return true;

            return false;
        }

        public void CopyTo(
#if !WAPICP3
            in
#endif
            T[] array, uint index)
        {
            ThrowIfNull(GetOrThrowIfDisposed(array), nameof(array));

            _ = _items.GetCount(out uint count);

            uint i = array.Length <= count + index ? throw new ArgumentException($"{nameof(array)} does not have the required length.") : 0u;

            _ = _items.GetAt(ref i, out T item);

            array[index] = item;

            for (i = 1; i < count; i++)
            {
                _ = Items.GetAt(ref i, out item);

                array[++index] = item;
            }
        }

        public System.Collections.Generic.IEnumerator<T> GetEnumerator() => Items.GetEnumerator();

        System.Collections.IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

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

        uint? IUIntIndexedList.IndexOf(
#if !WAPICP3
in
#endif
             object value)
#if WAPICP3
            => IndexOf(value);

        uint? IReadOnlyUIntIndexedList.IndexOf(in object value) => IndexOf(value);

        private uint? IndexOf(in object value)
#endif
        {
            ThrowIfDisposed();

            return value is T _value ? IndexOf(in _value) : null;
        }

        bool IUIntIndexedList.Contains(
#if !WAPICP3
in
#endif
             object value)
#if WAPICP3
            => Contains(value);

        bool IReadOnlyUIntIndexedList.Contains(in object value) => Contains(value);

        private bool Contains(in object value)
#endif
            =>
#if !CS9
            !(
#endif
            GetOrThrowIfDisposed(value) is
#if CS9
            not
#endif
            null
#if !CS9
            )
#endif
            && Contains((T)value);

        void
#if WAPICP3
           WinCopies.Collections.DotNetFix.
#endif
            IUIntIndexedCollection.CopyTo(in Array array,
#if WAPICP3
            int
#else
            uint
#endif
            index)
        {
            uint i = (GetOrThrowIfDisposed(array) ?? throw GetArgumentNullException(nameof(array))).Length <= Count + index ? throw new ArgumentException($"{nameof(array)} does not have the required length.") : 0u;

            _ = _items.GetAt(ref i, out T item);

            array.SetValue(item, index);

            for (i = 1u; i < Count; i++)
            {
                _ = _items.GetAt(ref i, out item);

                array.SetValue(item, index);
            }
        }

        uint IUIntIndexedList.Add(ref object value) => throw new InvalidOperationException("The current collection is read-only.");

        void IUIntIndexedList.Remove(
#if !WAPICP3
in
#endif
             object value) => throw new InvalidOperationException("The current collection is read-only.");

        void IUIntIndexedList.RemoveAt(ref uint index) => throw new InvalidOperationException("The current collection is read-only.");

        void IUIntIndexedCollection<T>.Clear() => throw new InvalidOperationException("The current collection is read-only.");

        void IUIntIndexedList.Clear() => throw new InvalidOperationException("The current collection is read-only.");

        void IUIntIndexedCollection<T>.Add(
#if !WAPICP3
            ref
#endif
            T item) => throw new InvalidOperationException("The current collection is read-only.");

        bool IUIntIndexedCollection<T>.Remove(
#if !WAPICP3
            in
#endif
            T item) => throw new InvalidOperationException("The current collection is read-only.");

#if WAPICP3
        private IUIntCountableEnumerator<T> GetUIntCountableEnumerator() => new UIntCountableEnumerator<System.Collections.Generic.IEnumerator<T>, T>(GetEnumerator(), () => Count);

        IUIntCountableEnumerator<T> IUIntCountableEnumerable<T, IUIntCountableEnumerator<T>>.GetEnumerator() => GetUIntCountableEnumerator();

        IUIntCountableEnumerator WinCopies.Collections.Enumeration.DotNetFix.IEnumerable<IUIntCountableEnumerator>.GetEnumerator() => GetUIntCountableEnumerator();

        IUIntCountableEnumerator<T> WinCopies.Collections.Enumeration.DotNetFix.IEnumerable<IUIntCountableEnumerator<T>>.GetEnumerator() => GetUIntCountableEnumerator();

        IUIntCountableEnumerator<T> IEnumerable<T, IUIntCountableEnumerator<T>>.GetEnumerator() => GetUIntCountableEnumerator();
#else
        void IUIntIndexedList<T>.RemoveAt(ref uint index) => throw new InvalidOperationException("The current collection is read-only.");
#endif
    }

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

        public Dictionary() => _addAction = (PropertyKey key, TValue value) =>
                             {

                                 _innerDictionary.Add(key, value);

                                 _addAction = null;

                             };

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

        public System.Collections.Generic.IEnumerator<KeyValuePair<PropertyKey, TValue>> GetEnumerator() => _innerDictionary.GetEnumerator();

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => ((IEnumerable)_innerDictionary).GetEnumerator();

        bool IDictionary<PropertyKey, TValue>.Remove(PropertyKey key) => _innerDictionary.Remove(key);

        bool System.Collections.Generic.ICollection<KeyValuePair<PropertyKey, TValue>>.Remove(KeyValuePair<PropertyKey, TValue> item) => ((ICollection<KeyValuePair<PropertyKey, TValue>>)_innerDictionary).Remove(item);

        public bool TryGetValue(PropertyKey key, out TValue value) => _innerDictionary.TryGetValue(key, out value);
    }

    // todo: this collection implements the .Net IReadOnlyDictionary interface, but this interface does not support the uint indexing.

    public class PropertyCollection : IDisposable,
#if CS6
        IReadOnlyDictionary<PropertyKey, Property>
#else
        System.Collections.Generic.IEnumerable<KeyValuePair<PropertyKey, Property>>
#endif
    {
        #region Private/Internal Fields
        protected internal INativePropertiesCollection Items { get; }

        private INativePropertyValuesCollection _nativePropertyValuesCollection;

        internal INativePropertyValuesCollection NativePropertyValuesCollection => _nativePropertyValuesCollection;

        private uint? _count;

        private Dictionary<Property> _innerDictionary;

        private Func<Dictionary<Property>> _getDictionaryDelegate;
        #endregion

        #region Public Properties
        public Property this[PropertyKey key]
        {
            get
            {
                if (IsDisposed)

                    throw new InvalidOperationException("The current object is disposed.");

                if (_innerDictionary.TryGetValue(key, out Property value))

                    return value;

                else
                {
                    for (uint i = 0; i < Count; i++)
                    {
                        var propertyKey = new PropertyKey();

                        _ = Items.GetAt(i, ref propertyKey);

                        if (propertyKey == key)
                        {

                            var objectProperty = new Property(this, propertyKey, CoreErrorHelper.Succeeded(Items.GetPropertyInfo(ref propertyKey, out IPropertyInfo propertyInfo)) ? propertyInfo : PropertyInfo.DefaultPropertyInfo);

                            _innerDictionary.Add(key, objectProperty);

                            return objectProperty;
                        }
                    }

                    throw new IndexOutOfRangeException("The key was not found.");
                }
            }
        }

        public System.Collections.Generic.IEnumerable<PropertyKey> Keys
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

        public System.Collections.Generic.IEnumerable<Property> Values => IsDisposed ? throw new InvalidOperationException("The current object is disposed.") : _getDictionaryDelegate().Values;

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

#if CS6
        int IReadOnlyCollection<KeyValuePair<PropertyKey, Property>>.Count => (int)Count;
#endif

        #region Public Constructors
        public PropertyCollection(in INativePropertiesCollection nativePropertyCollection)
        {
            ThrowIfNull(nativePropertyCollection, nameof(nativePropertyCollection));

            Items = nativePropertyCollection;

            CoreErrorHelper.ThrowExceptionForHResult(nativePropertyCollection.GetValues(out _nativePropertyValuesCollection));

            _innerDictionary = new Dictionary<Property>();

            _getDictionaryDelegate = () =>
            {
                PopulateDictionary();

                _getDictionaryDelegate = () => _innerDictionary;

                return _innerDictionary;
            };
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

                        _innerDictionary.Add(propertyKey, new Property(this, propertyKey, CoreErrorHelper.Succeeded(Items.GetPropertyInfo(ref propertyKey, out IPropertyInfo propertyInfo)) ? propertyInfo : PropertyInfo.DefaultPropertyInfo));
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

        public bool TryGetValue(PropertyKey key, out Property value)
        {
            if (IsDisposed)

                throw new InvalidOperationException("The current object is disposed.");

            foreach (KeyValuePair<PropertyKey, Property> _value in _innerDictionary)

                if (_value.Key == key)
                {
                    value = _value.Value;

                    return true;
                }

            foreach (PropertyKey propertyKey in Keys)

                if (key == propertyKey)
                {
                    PropertyKey _propertyKey = propertyKey;

                    var property = new Property(this, _propertyKey, CoreErrorHelper.Succeeded(Items.GetPropertyInfo(ref _propertyKey, out IPropertyInfo propertyInfo)) ? propertyInfo : PropertyInfo.DefaultPropertyInfo);

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

        // ~PropertyCollection() => Dispose(false);

        public void Dispose()
        {
            if (!IsDisposed)
            {
                ((System.Collections.Generic.ICollection<KeyValuePair<PropertyKey, Property>>)_innerDictionary).Clear();
                _innerDictionary = null;
                _getDictionaryDelegate = null;
                Items.Dispose();
                _nativePropertyValuesCollection = null;

                IsDisposed = true;
            }
        }
        #endregion

        #region IEnumerable Support
        public System.Collections.Generic.IEnumerator<KeyValuePair<PropertyKey, Property>> GetEnumerator() => IsDisposed
                ? throw new InvalidOperationException("The current object is disposed.")
                : _getDictionaryDelegate().GetEnumerator();

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => IsDisposed
                ? throw new InvalidOperationException("The current object is disposed.")
                : ((IEnumerable)_getDictionaryDelegate()).GetEnumerator();
        #endregion
    }

    /// <summary>
    /// Represents a collection of property attributes.
    /// </summary>
    /// <seealso cref="PropertyAttribute"/>
    /// <seealso cref="Property"/>
    /// <seealso cref="PropertyCollection"/>
    internal sealed class PropertyAttributeCollection : System.Collections.Generic.IEnumerable<PropertyAttribute>, WinCopies.Collections.
#if WAPICP2
        IUIntIndexedCollection
#else
        DotNetFix.Generic.IReadOnlyUIntIndexedList
#endif
        <PropertyAttribute>
    {
        #region Private Fields
        private IDisposableReadOnlyNativePropertyValuesCollection _nativePropertyValuesCollection;

        private readonly Dictionary<PropertyAttribute> _innerDictionary;

        private uint? _count;

        private Func<Dictionary<PropertyAttribute>> _getDictionaryDelegate;
        #endregion

        #region Public Indexers
        public PropertyAttribute this[PropertyKey key] => IsDisposed ? throw new InvalidOperationException("The current object is disposed.") : _getDictionaryDelegate()[key];

        public PropertyAttribute this[uint index]
        {
            get
            {
                if (IsDisposed)

                    throw new InvalidOperationException("The current object is disposed.");

                // todo: replace this code by a custom dictionary that supports uint indexing.

                int i = 0;

                Dictionary<PropertyAttribute> dic = _getDictionaryDelegate();

                foreach (PropertyAttribute value in dic.Values)
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

            _innerDictionary = new Dictionary<PropertyAttribute>();

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

            for (uint i = 0; i < Count; i++)
            {
                propertyKey = new PropertyKey();

                _ = _nativePropertyValuesCollection.GetAt(i, ref propertyKey, out PropVariant propVariant);

                _innerDictionary.Add(propertyKey, new PropertyAttribute(propertyKey, NativePropertyHelper.VarEnumToSystemType(propVariant.VarType), propVariant.Value));
            }
        }

#if WAPICP2
        #region IUIntIndexedCollection Support

        object WinCopies.Collections.IUIntIndexedCollection.this[uint index] => this[index];

        #endregion
#endif

        #region IEnumerable Support

#if WAPICP2
        private class UIntIndexedCollectionEnumerator : UIntIndexedCollectionEnumeratorBase, System.Collections.Generic.IEnumerator<PropertyAttribute>
        {
            public UIntIndexedCollectionEnumerator(WinCopies.Collections.IUIntIndexedCollection<PropertyAttribute> uIntIndexedCollection) : base(uIntIndexedCollection) { }

            public PropertyAttribute Current => ((PropertyAttributeCollection)UIntIndexedCollection).IsDisposed ? throw new InvalidOperationException("The collection is disposed.") : ((WinCopies.Collections.IUIntIndexedCollection<PropertyAttribute>)UIntIndexedCollection)[Index.Value];

            object System.Collections.IEnumerator.Current => Current;
        }
#else
        // TODO: remove after referenced WinCopies > 3.1.0.1
        private class _Class : IUIntIndexedList<PropertyAttribute>
        {
            private readonly PropertyAttributeCollection _propertyAttributes;

            public _Class(PropertyAttributeCollection propertyAttributes) => _propertyAttributes = propertyAttributes;

            PropertyAttribute WinCopies.Collections.DotNetFix.Generic.IReadOnlyUIntIndexedList<PropertyAttribute>.this[uint index] => _propertyAttributes[index];

            uint IUIntCountable.Count => _propertyAttributes.Count;

        #region Unsupported items
            System.Collections.Generic.IEnumerator<PropertyAttribute> System.Collections.Generic.IEnumerable<PropertyAttribute>.GetEnumerator() => throw new NotImplementedException();
            System.Collections.IEnumerator IEnumerable.GetEnumerator() => throw new NotImplementedException();
            void IUIntIndexedCollection<PropertyAttribute>.Add(PropertyAttribute item) => throw new NotImplementedException();
            void IUIntIndexedCollection<PropertyAttribute>.Clear() => throw new NotImplementedException();
            bool IUIntIndexedCollection<PropertyAttribute>.Contains(PropertyAttribute item) => throw new NotImplementedException();
            void IUIntIndexedCollection<PropertyAttribute>.CopyTo(PropertyAttribute[] array, uint arrayIndex) => throw new NotImplementedException();
            bool IUIntIndexedCollection<PropertyAttribute>.Remove(PropertyAttribute item) => throw new NotImplementedException();

            PropertyAttribute IUIntIndexedList<PropertyAttribute>.this[uint index] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
            uint? IUIntIndexedList<PropertyAttribute>.IndexOf(PropertyAttribute item) => throw new NotImplementedException();
            void IUIntIndexedList<PropertyAttribute>.Insert(uint index, PropertyAttribute item) => throw new NotImplementedException();
            void IUIntIndexedList<PropertyAttribute>.RemoveAt(uint index) => throw new NotImplementedException();
            public IUIntCountableEnumerator<PropertyAttribute> GetEnumerator() => throw new NotImplementedException();
        #endregion
        }
#endif

        public System.Collections.Generic.IEnumerator<PropertyAttribute> GetEnumerator() => IsDisposed
                ? throw new InvalidOperationException("The current object is disposed.")
                : new
#if WAPICP2
UIntIndexedCollectionEnumerator(this);
#else
            UIntIndexedListEnumerator<PropertyAttribute>(new _Class(this));
#endif

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();

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

#if WAPICP3
        private IUIntCountableEnumerator<PropertyAttribute> GetUIntCountableEnumerator() => new UIntCountableEnumerator<System.Collections.Generic.IEnumerator<PropertyAttribute>, PropertyAttribute>(GetEnumerator(), () => Count);

        IUIntCountableEnumerator<PropertyAttribute> IUIntCountableEnumerable<PropertyAttribute, IUIntCountableEnumerator<PropertyAttribute>>.GetEnumerator() => GetUIntCountableEnumerator();

#if !CS8
        IUIntCountableEnumerator<PropertyAttribute> WinCopies.Collections.Enumeration.DotNetFix.IEnumerable<IUIntCountableEnumerator<PropertyAttribute>>.GetEnumerator() => GetUIntCountableEnumerator();

        IUIntCountableEnumerator<PropertyAttribute> IEnumerable<PropertyAttribute, IUIntCountableEnumerator<PropertyAttribute>>.GetEnumerator() => GetUIntCountableEnumerator();
#endif
#endif
        #endregion
    }
}
