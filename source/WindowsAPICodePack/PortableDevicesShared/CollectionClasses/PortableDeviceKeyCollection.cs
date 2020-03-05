using Microsoft.WindowsAPICodePack.PropertySystem;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Microsoft.WindowsAPICodePack.PortableDevices.PropertySystem
{
    public class PortableDeviceKeyCollection : IPortableDeviceKeyCollection
    {
        private Win32Native.PortableDevices.PropertySystem.IPortableDeviceKeyCollection _portableDeviceKeyCollection;

        internal Win32Native.PortableDevices.PropertySystem.IPortableDeviceKeyCollection _PortableDeviceKeyCollection { get { ThrowIfDisposed(); return _portableDeviceKeyCollection; } private set => _portableDeviceKeyCollection = value; }

        // todo: replace by the same WinCopies.Util extension method.

        private void ThrowIfDisposed()

        {

            if (IsDisposed)

                throw new InvalidOperationException("The current collection is disposed.");

        }

        public PortableDeviceKeyCollection() => _PortableDeviceKeyCollection = new Win32Native.PortableDevices.PropertySystem.PortableDeviceKeyCollection();

        public bool IsDisposed { get; private set; } = false;

        public void Add(ref PropertyKey Key)
        {
            ThrowIfDisposed();

            Marshal.ThrowExceptionForHR((int)_PortableDeviceKeyCollection.Add(ref Key));
        }

        public void Clear()
        {
            ThrowIfDisposed();

            _ = _PortableDeviceKeyCollection.Clear();
        }

        public PropertyKey GetAt(in uint dwIndex)
        {
            ThrowIfDisposed();

            var key = new PropertyKey();

            Marshal.ThrowExceptionForHR((int)_PortableDeviceKeyCollection.GetAt(dwIndex, ref key));

            return key;
        }

        public uint Count
        {
            get
            {

                ThrowIfDisposed();

                uint count = 0;

                _ = _PortableDeviceKeyCollection.GetCount(ref count);

                return count;

            }
        }

        public void RemoveAt(in uint dwIndex)
        {
            ThrowIfDisposed();

            if (dwIndex >= Count)

                throw new IndexOutOfRangeException();

            _ = _PortableDeviceKeyCollection.RemoveAt(dwIndex);
        }

        #region IDisposable Support

        protected virtual void Dispose(bool disposing)
        {
            if (!IsDisposed)
            {
                _ = Marshal.ReleaseComObject(_PortableDeviceKeyCollection);
                _PortableDeviceKeyCollection = null;

                IsDisposed = true;
            }
        }

        ~PortableDeviceKeyCollection()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
