using Microsoft.WindowsAPICodePack.Win32Native;
using Microsoft.WindowsAPICodePack.Win32Native.Shell.PropertySystem;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.WindowsAPICodePack.PropertySystem
{
    public class PropertyCollection : IReadOnlyDictionary<PropertyKey, ObjectProperty>, IDisposable
    {

        private Dictionary<PropertyKey, ObjectProperty> _innerDictionary;

        private INativePropertyCollection _nativePropertyCollection;

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

                        _ = _nativePropertyCollection.GetAt(i, ref propertyKey);

                        if (propertyKey == key)
                        {

                            var objectProperty = new ObjectProperty(_nativePropertyCollection, propertyKey);

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

                    _ = _nativePropertyCollection.GetAt(i, ref propertyKey);

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

        private void PopulateInnerDictionary()
        {
            if (_innerDictionary.Count != Count)

                for (uint i = 0; i < Count; i++)
                {

                    var propertyKey = new PropertyKey();

                    _ = _nativePropertyCollection.GetAt(i, ref propertyKey);

                    if (!_innerDictionary.ContainsKey(propertyKey))

                        _innerDictionary.Add(propertyKey, new ObjectProperty(_nativePropertyCollection, propertyKey));
                }
        }

        public int Count
        {
            get
            {
                if (IsDisposed)

                    throw new InvalidOperationException("The current object is disposed.");

                _ = _nativePropertyCollection.GetCount(out uint count);

                return (int)count;
            }
        }

        public bool ContainsKey(PropertyKey key)
        {
            if (IsDisposed)

                throw new InvalidOperationException("The current object is disposed.");

            foreach (PropertyKey propertyKey in Keys)

                if (propertyKey == key)

                    return true;

            return false;
        }

        public IEnumerator<KeyValuePair<PropertyKey, ObjectProperty>> GetEnumerator()
        {
            if (IsDisposed)

                throw new InvalidOperationException("The current object is disposed.");

            PopulateInnerDictionary();

            return _innerDictionary.GetEnumerator();
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

                    var property = new ObjectProperty(_nativePropertyCollection, propertyKey);

                    _innerDictionary.Add(propertyKey, property);

                    value = property;

                    return true;

                }

            value = null;

            return false;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            if (IsDisposed)

                throw new InvalidOperationException("The current object is disposed.");

            PopulateInnerDictionary();

            return ((IEnumerable)_innerDictionary).GetEnumerator();
        }

        #region IDisposable Support
        public bool IsDisposed { get; private set; } = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!IsDisposed)
            {
                if (disposing)
                {
                    _innerDictionary.Clear();
                    _innerDictionary = null;
                }

                IsDisposed = true;
            }
        }

        // ~PropertyCollection()
        // {
        //   Dispose(false);
        // }

        public void Dispose() => Dispose(true); // GC.SuppressFinalize(this);
        #endregion
    }
}
