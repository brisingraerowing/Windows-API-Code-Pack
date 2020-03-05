using Microsoft.WindowsAPICodePack.PropertySystem;
using Microsoft.WindowsAPICodePack.Win32Native;
using Microsoft.WindowsAPICodePack.Win32Native.PortableDevices;
using Microsoft.WindowsAPICodePack.Win32Native.PortableDevices.PropertySystem;
using Microsoft.WindowsAPICodePack.Win32Native.PropertySystem;
using Microsoft.WindowsAPICodePack.Win32Native.Shell.PropertySystem;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using static Microsoft.WindowsAPICodePack.PortableDevices.PortableDeviceHelper;

namespace Microsoft.WindowsAPICodePack.PortableDevices.PropertySystem
{
    public class PortableDeviceValues : IPortableDeviceValues
    {
        private Win32Native.PortableDevices.PropertySystem.IPortableDeviceValues _nativePortableDeviceValues;
        private Dictionary<PropertyKey, object> _dic = new Dictionary<PropertyKey, object>();

        internal Win32Native.PortableDevices.PropertySystem.IPortableDeviceValues _NativePortableDeviceValues { get { ThrowIfDisposed(); return _nativePortableDeviceValues; } private set => _nativePortableDeviceValues = value; }

        public PortableDeviceValues() => _NativePortableDeviceValues = new Win32Native.PortableDevices.PropertySystem.PortableDeviceValues();

        // todo: replace by the same WinCopies.Util extension method.

        private void ThrowIfDisposed()

        {

            if (IsDisposed)

                throw new InvalidOperationException("The current collection is disposed.");

        }

        public object GetAt(in uint index, out PropertyKey propertyKey, out Type valueType)

        {

            ThrowIfDisposed();

            var propKey = new PropertyKey();

            var propVar = new PropVariant();

            HResult hr = _NativePortableDeviceValues.GetAt(index, ref propKey, ref propVar);

            if (hr == HResult.InvalidArguments)

                throw new IndexOutOfRangeException();

            propertyKey = propKey;

            (object value, Type valueType) result;

            if (_dic.ContainsKey(propKey))

            {

                object _result = _dic[propertyKey];

                result = (_result, _result.GetType());

            }

            else

                result = (propVar.Value, NativePropertyHelper.VarEnumToSystemType(propVar.VarType));

            propVar.Dispose();

            valueType = result.valueType;

            return result.value;

        }

        public uint Count
        {
            get
            {

                ThrowIfDisposed();

                uint count = 0;

                _ = _NativePortableDeviceValues.GetCount(ref count);

                return count;
            }
        }

        public void Clear()
        {
            ThrowIfDisposed();

            _ = _NativePortableDeviceValues.Clear();
        }

        /// <summary>
        /// Copies the values from a given <see cref="IPropertyStore"/> into the current collection. See Remarks section.
        /// </summary>
        /// <param name="pStore">The <see cref="IPropertyStore"/> from which to copy the values.</param>
        /// <remarks>By using this method, you use the <see cref="IPropertyStore"/> interface, which is an unmanaged type, so be careful to free the COM memory after using this interface.</remarks>
        public void CopyValuesFromPropertyStore(ref IPropertyStore pStore)
        {
            ThrowIfDisposed();

            ThrowWhenFailHResult(_NativePortableDeviceValues.CopyValuesFromPropertyStore(pStore));
        }

        /// <summary>
        /// Copies the values from the current collection into a given <see cref="IPropertyStore"/>. See Remarks section.
        /// </summary>
        /// <param name="pStore">The <see cref="IPropertyStore"/> into which to copy the values.</param>
        /// <remarks>By using this method, you use the <see cref="IPropertyStore"/> interface, which is an unmanaged type, so be careful to free the COM memory after using this interface.</remarks>
        public void CopyValuesToPropertyStore(ref IPropertyStore pStore)
        {
            ThrowIfDisposed();

            ThrowWhenFailHResult(_NativePortableDeviceValues.CopyValuesToPropertyStore(pStore));
        }

        private PropertySystemException GetDataTypeMismatchException() => throw new PropertySystemException("The types do not correspond.");

        private void ThrowOnError(HResult hr)

        {

            ThrowIfDisposed();

            if (hr == HResult.DispTypeMismatch)

                throw GetDataTypeMismatchException();

            if (hr == HResult.ElementNotFound)

                throw new IndexOutOfRangeException();

            Marshal.ThrowExceptionForHR((int)hr);

        }

        public bool GetBoolValue(ref PropertyKey key)
        {
            ThrowOnError(_NativePortableDeviceValues.GetBoolValue(key, out bool value));

            return value;
        }

        public byte[] GetBufferValue(ref PropertyKey key)
        {
            ThrowOnError(_NativePortableDeviceValues.GetBufferValue(ref key,
                out byte[] value,
#if DEBUG
                out uint count
#else
                out uint _
#endif
                ));

            Debug.Assert(value.Length == count);

            return value;
        }

        public HResult GetErrorValue(ref PropertyKey key)
        {
            ThrowOnError(_NativePortableDeviceValues.GetErrorValue(ref key, out HResult value));

            return value;
        }

        public float GetFloatValue(ref PropertyKey key)
        {
            ThrowOnError(_NativePortableDeviceValues.GetFloatValue(ref key, out float value));

            return value;
        }

        public Guid GetGuidValue(ref PropertyKey key)
        {
            ThrowOnError(_NativePortableDeviceValues.GetGuidValue(ref key, out Guid value));

            return value;
        }

        private T GetFromDictionary<T>(in PropertyKey key) where T : class
        {

            ThrowIfDisposed();

            if (_dic.TryGetValue(key, out object value))

                return value as T ?? throw GetDataTypeMismatchException();

            else

                throw new IndexOutOfRangeException();

        }

        public PortableDeviceKeyCollection GetPortableDeviceKeyCollectionValue(in PropertyKey key) => GetFromDictionary<PortableDeviceKeyCollection>(key);

        public PortableDevicePropVariantCollection GetPortableDevicePropVariantCollectionValue(in PropertyKey key) => GetFromDictionary<PortableDevicePropVariantCollection>(key);

        public PortableDeviceValuesCollection GetPortableDeviceValuesCollectionValue(in PropertyKey key) => GetFromDictionary<PortableDeviceValuesCollection>(key);

        public PortableDeviceValues GetPortableDeviceValuesValue(in PropertyKey key) => GetFromDictionary<PortableDeviceValues>(key);

        /// <summary>
        /// Returns an unmanaged object that inherits from the native IUnknown interface. See Remarks section.
        /// </summary>
        /// <param name="key">The property at which the value to retrieve is stored.</param>
        /// <remarks>By using this method, you use the IUnknown interface, which is an unmanaged type, so be careful to free the COM memory after using this interface.</remarks>
        public object GetIUnknownValue(ref PropertyKey key)
        {
            ThrowOnError(_NativePortableDeviceValues.GetIUnknownValue(ref key, out object value));

            return value;
        }

        public PropertyKey GetKeyValue(ref PropertyKey key)
        {
            ThrowOnError(_NativePortableDeviceValues.GetKeyValue(ref key, out PropertyKey value));

            return value;
        }

        public int GetSignedIntegerValue(ref PropertyKey key)
        {
            ThrowOnError(_NativePortableDeviceValues.GetSignedIntegerValue(ref key, out int value));

            return value;
        }

        public long GetSignedLargeIntegerValue(ref PropertyKey key)
        {
            ThrowOnError(_NativePortableDeviceValues.GetSignedLargeIntegerValue(ref key, out long value));

            return value;
        }

        public string GetStringValue(ref PropertyKey key)
        {
            ThrowOnError(_NativePortableDeviceValues.GetStringValue(ref key, out string value));

            return value;
        }

        public uint GetUnsignedIntegerValue(ref PropertyKey key)
        {
            ThrowOnError(_NativePortableDeviceValues.GetUnsignedIntegerValue(ref key, out uint value));

            return value;
        }

        public ulong GetUnsignedLargeIntegerValue(ref PropertyKey key)
        {
            ThrowOnError(_NativePortableDeviceValues.GetUnsignedIntegerValue(ref key, out uint value));

            return value;
        }

        public object GetValue(ref PropertyKey key, out Type valueType) // Setting a value object is not allowed because we don't know if we'll get a native or a managed object; thus, a check could be broken in case of interface update.
        {
            ThrowIfDisposed();

            if (_dic.TryGetValue(key, out object value))

            {

                valueType = value.GetType();

                return value;

            }

            HResult hr = _NativePortableDeviceValues.GetValue(ref key, out PropVariant propVariant);

            if (hr == HResult.ElementNotFound)

                throw new IndexOutOfRangeException();

            Marshal.ThrowExceptionForHR((int)hr);

            (object value, Type valueType) result = (propVariant.Value, NativePropertyHelper.VarEnumToSystemType(propVariant.VarType));

            propVariant.Dispose();

            valueType = result.valueType;

            return result.value;
        }

        public void RemoveValue(ref PropertyKey key)
        {
            ThrowIfDisposed();

            Marshal.ThrowExceptionForHR((int)_NativePortableDeviceValues.RemoveValue(key));

            _ = _dic.Remove(key);
        }

        public void SetBoolValue(ref PropertyKey key, in bool value)
        {
            ThrowIfDisposed();

            Marshal.ThrowExceptionForHR((int)_NativePortableDeviceValues.SetBoolValue(ref key, value));
        }

        public void SetBufferValue(ref PropertyKey key, in byte[] value)
        {
            ThrowIfDisposed();

            Marshal.ThrowExceptionForHR((int)_NativePortableDeviceValues.SetBufferValue(ref key, value, (uint)value.Length));
        }

        public void SetErrorValue(ref PropertyKey key, in HResult value)
        {
            ThrowIfDisposed();

            Marshal.ThrowExceptionForHR((int)_NativePortableDeviceValues.SetErrorValue(ref key, value));
        }

        public void SetFloatValue(ref PropertyKey key, in float value)
        {
            ThrowIfDisposed();

            Marshal.ThrowExceptionForHR((int)_NativePortableDeviceValues.SetFloatValue(ref key, value));
        }

        public void SetGuidValue(ref PropertyKey key, ref Guid value)
        {
            ThrowIfDisposed();

            Marshal.ThrowExceptionForHR((int)_NativePortableDeviceValues.SetGuidValue(ref key, ref value));
        }

        public void SetPortableDeviceKeyCollectionValue(ref PropertyKey key, ref PortableDeviceKeyCollection value)
        {
            ThrowIfDisposed();

            Win32Native.PortableDevices.PropertySystem.IPortableDeviceKeyCollection temp = value._PortableDeviceKeyCollection;

            Marshal.ThrowExceptionForHR((int)_NativePortableDeviceValues.SetIPortableDeviceKeyCollectionValue(ref key, ref temp));

            if (_dic.ContainsKey(key))

                _dic[key] = value;

            else

                _dic.Add(key, value);
        }

        public void SetPortableDevicePropVariantCollectionValue(ref PropertyKey key, ref PortableDevicePropVariantCollection value)
        {
            ThrowIfDisposed();

            Win32Native.PortableDevices.PropertySystem.IPortableDevicePropVariantCollection temp = value._PortableDevicePropVariantCollection;

            Marshal.ThrowExceptionForHR((int)_NativePortableDeviceValues.SetIPortableDevicePropVariantCollectionValue(ref key, ref temp));

            if (_dic.ContainsKey(key))

                _dic[key] = value;

            else

                _dic.Add(key, value);
        }

        public void SetPortableDeviceValuesCollectionValue(ref PropertyKey key, ref PortableDeviceValuesCollection value)
        {
            ThrowIfDisposed();

            Win32Native.PortableDevices.PropertySystem.IPortableDeviceValuesCollection temp = value._PortableDeviceValuesCollection;

            Marshal.ThrowExceptionForHR((int)_NativePortableDeviceValues.SetIPortableDeviceValuesCollectionValue(ref key, ref temp));

            if (_dic.ContainsKey(key))

                _dic[key] = value;

            else

                _dic.Add(key, value);
        }

        public void SetPortableDeviceValuesValue(ref PropertyKey key, ref PortableDeviceValues value)
        {
            ThrowIfDisposed();

            Win32Native.PortableDevices.PropertySystem.IPortableDeviceValues temp = value._PortableDeviceValues;

            Marshal.ThrowExceptionForHR((int)_NativePortableDeviceValues.SetIPortableDeviceValuesValue(ref key, ref temp));

            if (_dic.ContainsKey(key))

                _dic[key] = value;

            else

                _dic.Add(key, value);
        }

        public void SetIUnknownValue(ref PropertyKey key, ref object value)
        {
            ThrowIfDisposed();

            Marshal.ThrowExceptionForHR((int)_NativePortableDeviceValues.SetIUnknownValue(ref key, ref value));
        }

        public void SetKeyValue(ref PropertyKey key, ref PropertyKey value)
        {
            ThrowIfDisposed();

            Marshal.ThrowExceptionForHR((int)_NativePortableDeviceValues.SetKeyValue(ref key, ref value));
        }

        public void SetSignedIntegerValue(ref PropertyKey key, in int value)
        {
            ThrowIfDisposed();

            Marshal.ThrowExceptionForHR((int)_NativePortableDeviceValues.SetSignedIntegerValue(ref key, value));
        }

        public void SetSignedLargeIntegerValue(ref PropertyKey key, in long value)
        {
            ThrowIfDisposed();

            Marshal.ThrowExceptionForHR((int)_NativePortableDeviceValues.SetSignedLargeIntegerValue(ref key, value));
        }

        public void SetStringValue(ref PropertyKey key, in string value)
        {
            ThrowIfDisposed();

            Marshal.ThrowExceptionForHR((int)_NativePortableDeviceValues.SetStringValue(ref key, value));
        }

        public void SetUnsignedIntegerValue(ref PropertyKey key, in uint value)
        {
            ThrowIfDisposed();

            Marshal.ThrowExceptionForHR((int)_NativePortableDeviceValues.SetUnsignedIntegerValue(ref key, value));
        }

        public void SetUnsignedLargeIntegerValue(ref PropertyKey key, in ulong value)
        {
            ThrowIfDisposed();

            Marshal.ThrowExceptionForHR((int)_NativePortableDeviceValues.SetUnsignedLargeIntegerValue(ref key, value));
        }

        #region IDisposable Support
        public bool IsDisposed { get; private set; } = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!IsDisposed)
            {
                if (disposing)

                    _dic.Clear();

                _ = Marshal.ReleaseComObject(_NativePortableDeviceValues);
                _NativePortableDeviceValues = null;

                IsDisposed = true;
            }
        }

        ~PortableDeviceValues()
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
