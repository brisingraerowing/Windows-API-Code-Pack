﻿using Microsoft.WindowsAPICodePack.COMNative.PropertySystem;
using Microsoft.WindowsAPICodePack.COMNative.Shell.PropertySystem;
using Microsoft.WindowsAPICodePack.Win32Native;

using System;

using static Microsoft.WindowsAPICodePack.PropertySystem.PropertySystemHelper;

namespace Microsoft.WindowsAPICodePack.PropertySystem
{
    public class ReadOnlyValueCollection : WinCopies.
#if !WAPICP3
        Util.
#endif
        DotNetFix.IDisposable
    {
        private INativeReadOnlyValueCollection _items;

        protected internal INativeReadOnlyValueCollection Items { get { ThrowIfDisposed(); return _items; } }

        public ReadOnlyValueCollection(in INativeReadOnlyValueCollection items) => _items = (items ?? throw new ArgumentNullException(nameof(items))).IsReadOnly ? throw new ArgumentException("The given collection is read-only.") : items.IsDisposed ? throw new ObjectDisposedException(nameof(items)) : items;

        public ReadOnlyValueCollection(in ValueCollection valueCollection) : this(valueCollection.Items) { }

        protected void ThrowIfDisposed() => WinCopies.
#if WAPICP3
            ThrowHelper
#else
            Util.Util
#endif
            .ThrowIfDisposed(this);

        public uint Count
        {
            get
            {
                _ = Items.GetCount(out uint count);

                return count;
            }
        }

        //public void Clear()
        //{
        //    ThrowIfDisposed();

        //    _portableDeviceValues.Clear();
        //}

        /// <summary>
        /// Copies the values from a given <see cref="IPropertyStore"/> into the current collection. See Remarks section.
        /// </summary>
        /// <param name="pStore">The <see cref="IPropertyStore"/> from which to copy the values.</param>
        /// <remarks>By using this method, you use the <see cref="IPropertyStore"/> interface, which is an unmanaged type, so be careful to free the COM memory after using this interface.</remarks>
        public void CopyValuesFromPropertyStore(ref IPropertyStore pStore) => ThrowWhenFailHResult(Items.CopyValuesFromPropertyStore(ref pStore));

        /// <summary>
        /// Copies the values from the current collection into a given <see cref="IPropertyStore"/>. See Remarks section.
        /// </summary>
        /// <param name="pStore">The <see cref="IPropertyStore"/> into which to copy the values.</param>
        /// <remarks>By using this method, you use the <see cref="IPropertyStore"/> interface, which is an unmanaged type, so be careful to free the COM memory after using this interface.</remarks>
        public void CopyValuesToPropertyStore(ref IPropertyStore pStore) => ThrowWhenFailHResult(Items.CopyValuesToPropertyStore(ref pStore));

        private static PropertySystemException GetDataTypeMismatchException() => throw new PropertySystemException("The types do not correspond.");

        private static void ThrowOnError(HResult hr) => CoreErrorHelper.ThrowExceptionForHResult(hr == HResult.DispTypeMismatch ? throw GetDataTypeMismatchException() : hr == HResult.ElementNotFound ? throw new IndexOutOfRangeException() : hr);

        public bool GetBoolValue(ref PropertyKey key)
        {
            ThrowOnError(Items.GetBoolValue(ref key, out bool value));

            return value;
        }

        public byte[] GetBufferValue(ref PropertyKey key)
        {
            ThrowOnError(Items.GetBufferValue(ref key,
                out byte[] value));

            return value;
        }

        public HResult GetErrorValue(ref PropertyKey key)
        {
            ThrowOnError(Items.GetErrorValue(ref key, out HResult value));

            return value;
        }

        public float GetFloatValue(ref PropertyKey key)
        {
            ThrowOnError(Items.GetFloatValue(ref key, out float value));

            return value;
        }

        public Guid GetGuidValue(ref PropertyKey key)
        {
            ThrowOnError(Items.GetGuidValue(ref key, out Guid value));

            return value;
        }

        //public ICollection<PropertyKey> GetPropertyKeyCollectionValue(ref PropertyKey key)
        //{
        //    ThrowOnError(Items.GetPropertyKeyCollectionValue(ref key, out ICollection<PropertyKey> values));

        //    return values;
        //}

        //public ICollection<PropVariant> GetPropVariantCollectionValue(ref PropertyKey key)
        //{

        //    ThrowOnError(Items.GetPropVariantCollectionValue(ref key, out ICollection<PropVariant> values));

        //    return values;

        //}

        //public GetPortableDeviceValuesCollectionValue(in PropertyKey key) => GetFromDictionary<PortableDeviceValuesCollection>(key);

        //public GetPortableDeviceValuesValue(in PropertyKey key) => GetFromDictionary<PortableDeviceValues>(key);

        /// <summary>
        /// Returns an unmanaged object that inherits from the native IUnknown interface. See Remarks section.
        /// </summary>
        /// <param name="key">The property at which the value to retrieve is stored.</param>
        /// <remarks>By using this method, you use the IUnknown interface, which is an unmanaged type, so be careful to free the COM memory after using this interface.</remarks>
        public object GetIUnknownValue(ref PropertyKey key)
        {
            ThrowOnError(Items.GetIUnknownValue(ref key, out object value));

            return value;
        }

        public PropertyKey GetKeyValue(ref PropertyKey key)
        {
            ThrowOnError(Items.GetKeyValue(ref key, out PropertyKey value));

            return value;
        }

        public int GetSignedIntegerValue(ref PropertyKey key)
        {
            ThrowOnError(Items.GetSignedIntegerValue(ref key, out int value));

            return value;
        }

        public long GetSignedLargeIntegerValue(ref PropertyKey key)
        {
            ThrowOnError(Items.GetSignedLargeIntegerValue(ref key, out long value));

            return value;
        }

        public string GetStringValue(ref PropertyKey key)
        {
            ThrowOnError(Items.GetStringValue(ref key, out string value));

            return value;
        }

        public uint GetUnsignedIntegerValue(ref PropertyKey key)
        {
            ThrowOnError(Items.GetUnsignedIntegerValue(ref key, out uint value));

            return value;
        }

        public ulong GetUnsignedLargeIntegerValue(ref PropertyKey key)
        {
            ThrowOnError(Items.GetUnsignedIntegerValue(ref key, out uint value));

            return value;
        }

        public object GetValue(ref PropertyKey key, out Type valueType) // Setting a value object is not allowed because we don't know if we'll get a native or a managed object; thus, a check could be broken in case of interface update.
        {
            ThrowOnError(Items.GetValue(ref key, out object value, out Type _valueType));

            valueType = _valueType;

            return value;
        }

        #region IDisposable Support
        public bool IsDisposed { get; private set; } = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!IsDisposed)
            {
                if (disposing)
                {
                    _items.Dispose();

                    _items = null;
                }

                IsDisposed = true;
            }
        }

        ~ReadOnlyValueCollection() => Dispose(false);

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }

    public class ValueCollection : WinCopies.
#if !WAPICP3
        Util.
#endif
        DotNetFix.IDisposable
    {
        private INativeValueCollection _items;

        public ValueCollection(in INativeValueCollection valueCollection) => _items = (valueCollection ?? throw new ArgumentNullException(nameof(valueCollection))).IsDisposed ? throw new ObjectDisposedException(nameof(valueCollection)) : valueCollection;

        public bool IsDisposed { get; private set; }

        protected virtual void Dispose(bool disposing)
        {
            if (!IsDisposed)
            {
                if (disposing)
                {
                    _items.Dispose();

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

        ~ValueCollection() => Dispose(false);

        protected internal INativeValueCollection Items
        {
            get
            {
                ThrowIfDisposed();

                return _items;
            }
        }

        private void ThrowIfDisposed() => WinCopies.
#if WAPICP3
            ThrowHelper
#else
            Util.Util
#endif
            .ThrowIfDisposed(this);

        public virtual void RemoveValue(ref PropertyKey key) => CoreErrorHelper.ThrowExceptionForHResult(Items.RemoveValue(ref key));

        //_ = _dic.Remove(key);

        public void SetBoolValue(ref PropertyKey key, in bool value) => CoreErrorHelper.ThrowExceptionForHResult(Items.SetBoolValue(ref key, value));

        public void SetBufferValue(ref PropertyKey key, in byte[] value) => CoreErrorHelper.ThrowExceptionForHResult(Items.SetBufferValue(ref key, value));

        public void SetErrorValue(ref PropertyKey key, in HResult value) => CoreErrorHelper.ThrowExceptionForHResult(Items.SetErrorValue(ref key, value));

        public void SetFloatValue(ref PropertyKey key, in float value) => CoreErrorHelper.ThrowExceptionForHResult(Items.SetFloatValue(ref key, value));

        public void SetGuidValue(ref PropertyKey key, ref Guid value) => CoreErrorHelper.ThrowExceptionForHResult(Items.SetGuidValue(ref key, ref value));

        //private void SetPortableDeviceKeyCollectionValue(ref PropertyKey key, in INativePropertyKeyCollectionProvider value)
        //{
        //    ThrowIfDisposed();

        //    COMNative.PortableDevices.PropertySystem.IPortableDeviceKeyCollection temp = value.NativeItems;

        //    CoreErrorHelper.ThrowExceptionForHResult(_portableDeviceValues.SetIPortableDeviceKeyCollectionValue(ref key, ref temp));

        //    if (_dic.ContainsKey(key))

        //        _dic[key] = value;

        //    else

        //        _dic.Add(key, value);
        //}

        //public void SetPortableDeviceKeyCollectionValue(ref PropertyKey key, in IReadOnlyCollection<PropertyKey> value) => Items;

        //public void SetPortableDevicePropVariantCollectionValue(ref PropertyKey key, ref PortableDevicePropVariantCollection value)
        //{
        //    ThrowIfDisposed();

        //    COMNative.PortableDevices.PropertySystem.IPortableDevicePropVariantCollection temp = value._PortableDevicePropVariantCollection;

        //    CoreErrorHelper.ThrowExceptionForHResult(_portableDeviceValues.SetIPortableDevicePropVariantCollectionValue(ref key, ref temp));

        //    if (_dic.ContainsKey(key))

        //        _dic[key] = value;

        //    else

        //        _dic.Add(key, value);
        //}

        //void IPortableDeviceValues.SetPortableDevicePropVariantCollectionValue(ref PropertyKey key, ref IPortableDevicePropVariantCollection value)
        //{
        //    if (value is PortableDevicePropVariantCollection _value)

        //        SetPortableDevicePropVariantCollectionValue(ref key, ref _value);

        //    else

        //        throw new ArgumentException($"{nameof(value)} must be {nameof(PortableDevicePropVariantCollection)}.");
        //}

        //public void SetPortableDeviceValuesCollectionValue(ref PropertyKey key, ref PortableDeviceValuesCollection value)
        //{
        //    ThrowIfDisposed();

        //    COMNative.PortableDevices.PropertySystem.IPortableDeviceValuesCollection temp = value._PortableDeviceValuesCollection;

        //    CoreErrorHelper.ThrowExceptionForHResult(_portableDeviceValues.SetIPortableDeviceValuesCollectionValue(ref key, ref temp));

        //    if (_dic.ContainsKey(key))

        //        _dic[key] = value;

        //    else

        //        _dic.Add(key, value);
        //}

        //void IPortableDeviceValues.SetPortableDeviceValuesCollectionValue(ref PropertyKey key, ref IPortableDeviceValuesCollection value)
        //{
        //    if (value is PortableDeviceValuesCollection _value)

        //        SetPortableDeviceValuesCollectionValue(ref key, ref _value);

        //    else

        //        throw new ArgumentException($"{nameof(value)} must be {nameof(PortableDeviceValuesCollection)}.");
        //}

        //public void SetPortableDeviceValuesValue(ref PropertyKey key, ref PortableDeviceValues value)
        //{
        //    ThrowIfDisposed();

        //    COMNative.PortableDevices.PropertySystem.IPortableDeviceValues temp = value._PortableDeviceValues;

        //    CoreErrorHelper.ThrowExceptionForHResult(_portableDeviceValues.SetIPortableDeviceValuesValue(ref key, ref temp));

        //    if (_dic.ContainsKey(key))

        //        _dic[key] = value;

        //    else

        //        _dic.Add(key, value);
        //}

        //void IPortableDeviceValues.SetPortableDeviceValuesValue(ref PropertyKey key, ref IPortableDeviceValues value)
        //{
        //    if (value is PortableDeviceValues _value)

        //        SetPortableDeviceValuesValue(ref key, ref _value);

        //    else

        //        throw new ArgumentException($"{nameof(value)} must be {nameof(PortableDeviceValues)}.");
        //}

        public void SetIUnknownValue(ref PropertyKey key, ref object value) => CoreErrorHelper.ThrowExceptionForHResult(Items.SetIUnknownValue(ref key, ref value));

        public void SetKeyValue(ref PropertyKey key, ref PropertyKey value) => CoreErrorHelper.ThrowExceptionForHResult(Items.SetKeyValue(ref key, ref value));

        public void SetSignedIntegerValue(ref PropertyKey key, in int value) => CoreErrorHelper.ThrowExceptionForHResult(Items.SetSignedIntegerValue(ref key, value));

        public void SetSignedLargeIntegerValue(ref PropertyKey key, in long value) => CoreErrorHelper.ThrowExceptionForHResult(Items.SetSignedLargeIntegerValue(ref key, value));

        public void SetStringValue(ref PropertyKey key, in string value) => CoreErrorHelper.ThrowExceptionForHResult(Items.SetStringValue(ref key, value));

        public void SetUnsignedIntegerValue(ref PropertyKey key, in uint value) => CoreErrorHelper.ThrowExceptionForHResult(Items.SetUnsignedIntegerValue(ref key, value));

        public void SetUnsignedLargeIntegerValue(ref PropertyKey key, in ulong value) => CoreErrorHelper.ThrowExceptionForHResult(Items.SetUnsignedLargeIntegerValue(ref key, value));
    }
}
