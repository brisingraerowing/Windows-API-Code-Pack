//using Microsoft.WindowsAPICodePack.PropertySystem;
//using System;
//using System.Collections.Generic;
//using System.Runtime.InteropServices;
//using System.Text;

//namespace Microsoft.WindowsAPICodePack.PortableDevices.PropertySystem
//{
//    public class PortableDeviceValuesCollection : Collection<PortableDeviceValues>, IPortableDeviceValuesCollection
//    {
//        private Win32Native.PortableDevices.PropertySystem.IPortableDeviceValuesCollection _portableDeviceValuesCollection;
//        private List<PortableDeviceValues> _items = new List<PortableDeviceValues>();

//        internal Win32Native.PortableDevices.PropertySystem.IPortableDeviceValuesCollection _PortableDeviceValuesCollection { get { ThrowIfDisposed(); return _portableDeviceValuesCollection; } }

//        public PortableDeviceValuesCollection() => _portableDeviceValuesCollection = new Win32Native.PortableDevices.PropertySystem.PortableDeviceValuesCollection();

//        // todo: replace by the same WinCopies.Util extension method.

//        private void ThrowIfDisposed()

//        {

//            if (IsDisposed)

//                throw new InvalidOperationException("The current collection is disposed.");

//        }

//        public uint Count
//        {
//            get
//            {
//                ThrowIfDisposed();

//                uint count = 0;

//                _ = _portableDeviceValuesCollection.GetCount(ref count);

//                return count;
//            }
//        }

//        public void AddItem(ref PortableDeviceValues values)
//        {
//            ThrowIfDisposed();

//            Win32Native.PortableDevices.PropertySystem.IPortableDeviceValues temp = values._PortableDeviceValues;

//            Marshal.ThrowExceptionForHR((int)_portableDeviceValuesCollection.Add(ref temp));

//            for (int i )
//        }

//        public void Clear() => throw new NotImplementedException();
//        public IPortableDeviceValues GetAt(in uint dwIndex) => throw new NotImplementedException();
//        public void RemoveAt(in uint dwIndex) => throw new NotImplementedException();

//        #region IDisposable Support

//        public bool IsDisposed { get; private set; }

//        protected virtual void Dispose(bool disposing)
//        {
//            if (!IsDisposed)
//            {

//                if (disposing)

//                    _dic.Clear();

//                _ = Marshal.ReleaseComObject(_portableDeviceValuesCollection);
//                _portableDeviceValuesCollection = null;

//                IsDisposed = true;
//            }
//        }

//        ~PortableDeviceValuesCollection()
//        {
//            Dispose(false);
//        }

//        public void Dispose()
//        {
//            Dispose(true);
//            GC.SuppressFinalize(this);
//        }
//        #endregion
//    }
//}
