//Copyright (c) Pierre Sprimont.  All rights reserved.

using Microsoft.WindowsAPICodePack.PropertySystem;
using Microsoft.WindowsAPICodePack.Win32Native;
using Microsoft.WindowsAPICodePack.COMNative.PortableDevices.PropertySystem;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

#if !WAPICP2
using Microsoft.WindowsAPICodePack.COMNative;
#endif

namespace Microsoft.WindowsAPICodePack.PortableDevices
{
    internal class NativeReadOnlyPropertyKeyCollection : INativeReadOnlyCollection<PropertyKey>, WinCopies.Collections.
#if !WAPICP2
        DotNetFix.Generic.
#endif
        IUIntIndexedCollection<PropertyKey>
    {
        private COMNative.PortableDevices.PropertySystem.IPortableDeviceKeyCollection _portableDeviceKeyCollection;

        protected internal COMNative.PortableDevices.PropertySystem.IPortableDeviceKeyCollection PortableDeviceKeyCollection { get { ThrowIfDisposed(); return _portableDeviceKeyCollection; } }

        //IPortableDeviceKeyCollection INativePropertyKeyCollectionProvider.NativeItems => PortableDeviceKeyCollection;

        // todo: replace by the same method of the WinCopies.Util.Util class.

        private protected void ThrowIfDisposed()
        {
            if (_isDisposed) throw new InvalidOperationException("The collection is disposed.");
        }

        bool INativeReadOnlyCollection<PropertyKey>.IsReadOnly
        {
            get
            {
                ThrowIfDisposed();

                return true;
            }
        }

        public NativeReadOnlyPropertyKeyCollection(COMNative.PortableDevices.PropertySystem.IPortableDeviceKeyCollection portableDeviceKeyCollection) => _portableDeviceKeyCollection = portableDeviceKeyCollection;

        private bool _isDisposed = false;

        bool WinCopies.
#if WAPICP2
            Util.
#endif
            DotNetFix.IDisposable.IsDisposed => _isDisposed;

        private void Dispose(bool disposing)
        {

            if (disposing || _isDisposed)

                return;

            _ = Marshal.ReleaseComObject(_portableDeviceKeyCollection);

            _portableDeviceKeyCollection = null;

            _isDisposed = true;

        }

        void IDisposable.Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        ~NativeReadOnlyPropertyKeyCollection() => Dispose(false);

        private HResult GetAt(ref uint index, out PropertyKey item)
        {
            ThrowIfDisposed();

            var propertyKey = new PropertyKey();

            HResult result = _portableDeviceKeyCollection.GetAt(index, ref propertyKey);

            item = propertyKey;

            return result;
        }

        HResult INativeReadOnlyCollection<PropertyKey>.GetAt(ref uint index, out PropertyKey item) => GetAt(ref index, out item);

        private PropertyKey this[uint index]
        {
            get
            {
                if (index < 0 || index >= Count)

                    throw new IndexOutOfRangeException();

                _ = GetAt(ref index, out PropertyKey item);

                return item;
            }
        }

        PropertyKey WinCopies.Collections.IUIntIndexedCollection<PropertyKey>.this[uint index] => this[index];

        object WinCopies.Collections.IUIntIndexedCollection.this[uint index] => this[index];

        private HResult GetCount(out uint count)
        {
            ThrowIfDisposed();

            uint _count = 0;

            HResult result = _portableDeviceKeyCollection.GetCount(ref _count);

            count = _count;

            return result;
        }

        HResult INativeReadOnlyCollection<PropertyKey>.GetCount(out uint count) => GetCount(out count);

        private uint Count
        {
            get
            {
                _ = GetCount(out uint count);

                return count;
            }
        }

        uint WinCopies.Collections.IUIntIndexedCollection.Count => Count;

        private IEnumerator<PropertyKey> GetEnumerator()
        {
            ThrowIfDisposed();

            return new WinCopies.Collections.UIntIndexedCollectionEnumerator<PropertyKey>(this);
        }

        IEnumerator<PropertyKey> IEnumerable<PropertyKey>.GetEnumerator() => GetEnumerator();

        IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();
    }

    internal sealed class NativePropertyKeyCollection : NativeReadOnlyPropertyKeyCollection, INativeCollection<PropertyKey>
    {
        public NativePropertyKeyCollection(IPortableDeviceKeyCollection portableDeviceKeyCollection) : base(portableDeviceKeyCollection)
        {
            // Left empty.
        }

        bool INativeReadOnlyCollection<PropertyKey>.IsReadOnly
        {
            get
            {
                ThrowIfDisposed();

                return false;
            }
        }

        bool INativeCollection<PropertyKey>.IsFixedSize
        {
            get
            {
                ThrowIfDisposed();

                return false;
            }
        }

        HResult INativeCollection<PropertyKey>.Add(ref PropertyKey value)
        {
            ThrowIfDisposed();

            return PortableDeviceKeyCollection.Add(ref value);
        }

        HResult INativeCollection<PropertyKey>.Clear()
        {
            ThrowIfDisposed();

            return PortableDeviceKeyCollection.Clear();
        }

        HResult INativeCollection<PropertyKey>.RemoveAt(in uint index)
        {
            ThrowIfDisposed();

            return PortableDeviceKeyCollection.RemoveAt(index);
        }
    }
}
