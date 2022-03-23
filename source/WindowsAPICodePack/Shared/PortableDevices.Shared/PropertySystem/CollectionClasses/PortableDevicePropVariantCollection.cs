//Copyright (c) Pierre Sprimont.  All rights reserved.

//using Microsoft.WindowsAPICodePack.Win32Native.PropertySystem;
//using System;
//using System.Collections.Generic;
//using System.Runtime.InteropServices;
//using System.Text;
//using WinCopies.Util;

//namespace Microsoft.WindowsAPICodePack.PortableDevices.PropertySystem
//{
//    public class PortableDevicePropVariantCollection : IPortableDevicePropVariantCollection
//    {
//        private COMNative.PortableDevices.PropertySystem.IPortableDevicePropVariantCollection _portableDevicePropVariantCollection;

//        internal COMNative.PortableDevices.PropertySystem.IPortableDevicePropVariantCollection _PortableDevicePropVariantCollection { get { ThrowIfDisposed(); return _portableDevicePropVariantCollection; } }

//        public PortableDevicePropVariantCollection() => _portableDevicePropVariantCollection = new COMNative.PortableDevices.PropertySystem.PortableDevicePropVariantCollection();

//        // todo: replace by the same WinCopies.Util extension method.

//        private void ThrowIfDisposed()

//        {

//            if (IsDisposed)

//                throw new InvalidOperationException("The current collection is disposed.");

//        }

//        public void Add(in object pValue)
//        {
//            ThrowIfDisposed();

//            var propVar = PropVariant.FromObject(pValue);

//            CoreErrorHelper.ThrowExceptionForHResult(_PortableDevicePropVariantCollection.Add(ref propVar));

//            propVar.Dispose();
//        }

//        public void ChangeItemVariantType(in VarEnum vt) => CoreErrorHelper.ThrowExceptionForHResult(_portableDevicePropVariantCollection.ChangeType(vt));

//        public void Clear() => _PortableDevicePropVariantCollection.Clear();

//        public object GetAt(in uint dwIndex, out Type valueType)
//        {
//            ThrowIfDisposed();

//            if (dwIndex < 0 || dwIndex >= Count)

//                throw new IndexOutOfRangeException();

//            var propVar = new PropVariant();

//            _ = _PortableDevicePropVariantCollection.GetAt(dwIndex, ref propVar);

//            (object value, Type valueType) result = (propVar.Value, NativePropertyHelper.VarEnumToSystemType(propVar.VarType));

//            propVar.Dispose();

//            valueType = result.valueType;

//            return result.value;
//        }

//        public uint Count
//        {
//            get
//            {
//                ThrowIfDisposed();

//                uint count = 0;

//                _ = _PortableDevicePropVariantCollection.GetCount(ref count);

//                return count;
//            }
//        }

//        public void RemoveAt(in uint dwIndex)
//        {
//            ThrowIfDisposed();

//            if (dwIndex < 0 || dwIndex >= Count)

//                throw new IndexOutOfRangeException();

//            _ = _PortableDevicePropVariantCollection.RemoveAt(dwIndex);
//        }

//        public VarEnum GetItemVariantType()
//        {
//            _ = _PortableDevicePropVariantCollection.GetType(out VarEnum pvt);

//            return pvt;
//        }

//        #region IDisposable Support
//        public bool IsDisposed { get; private set; } = false;

//        protected virtual void Dispose(bool disposing)
//        {
//            if (!IsDisposed)
//            {
//                _ = Marshal.ReleaseComObject(_portableDevicePropVariantCollection);
//                _portableDevicePropVariantCollection = null;

//                IsDisposed = true;
//            }
//        }

//        ~PortableDevicePropVariantCollection()
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
