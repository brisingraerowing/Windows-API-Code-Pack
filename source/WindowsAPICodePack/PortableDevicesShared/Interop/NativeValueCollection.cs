//Copyright (c) Pierre Sprimont.  All rights reserved.

using Microsoft.WindowsAPICodePack.PortableDevices.PropertySystem;
using Microsoft.WindowsAPICodePack.PropertySystem;
using Microsoft.WindowsAPICodePack.Win32Native;
using Microsoft.WindowsAPICodePack.Win32Native.PortableDevices.PropertySystem;
using Microsoft.WindowsAPICodePack.Win32Native.PropertySystem;
using Microsoft.WindowsAPICodePack.Win32Native.Shell.PropertySystem;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;

namespace Microsoft.WindowsAPICodePack.PortableDevices
{
    internal class NativeReadOnlyValueCollection : INativeReadOnlyPortableDeviceValueCollection

    {

        bool INativeReadOnlyValueCollection.IsReadOnly
        {
            get
            {
                ThrowIfDisposed();

                return true;
            }
        }

        private Win32Native.PortableDevices.PropertySystem.IPortableDeviceValues _portableDeviceValues;
        //protected Dictionary<PropertyKey, object> Dic = new Dictionary<PropertyKey, object>();

        protected internal Win32Native.PortableDevices.PropertySystem.IPortableDeviceValues PortableDeviceValues { get { ThrowIfDisposed(); return _portableDeviceValues; } }

        IPortableDeviceValues INativePortableDeviceValuesCollectionProvider.NativeItems => PortableDeviceValues;

        //IPortableDeviceKeyCollection INativePropertyKeyCollectionProvider.NativeItems => PortableDeviceKeyCollection;

        // todo: replace by the same method of the WinCopies.Util.Util class.

        private protected void ThrowIfDisposed()

        {

            if (_isDisposed) throw new InvalidOperationException("The collection is disposed.");

        }

        //private readonly bool _isReadOnly;

        //bool INativeReadOnlyValueCollection.IsReadOnly
        //{
        //    get
        //    {
        //        ThrowIfDisposed();

        //        return _isReadOnly;
        //    }
        //}

        public NativeReadOnlyValueCollection(IPortableDeviceValues portableDeviceValues) => _portableDeviceValues = portableDeviceValues;

        private bool _isDisposed = false;

        bool WinCopies.Util.DotNetFix.IDisposable.IsDisposed => _isDisposed;

        private void Dispose(bool disposing)
        {

            if (disposing || _isDisposed)

                return;

            _ = Marshal.ReleaseComObject(_portableDeviceValues);

            _portableDeviceValues = null;

            _isDisposed = true;

        }

        void IDisposable.Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        ~NativeReadOnlyValueCollection() => Dispose(false);

        //uint Count

        //{

        //    get

        //    {

        //        uint count = 0;

        //        _ = _portableDeviceValues.GetCount(ref count);

        //        return count;

        //    }

        //}

        //HResult INativeReadOnlyValueCollection.GetAt(in uint index, ref PropertyKey propertyKey, PropVariant propVariant)

        //{

        //    ThrowIfDisposed();

        //    if (index < 0 || index >= Count)

        //        throw new IndexOutOfRangeException();

        //    var propKey = new PropertyKey();

        //    var propVar = new PropVariant();

        //    _ = _portableDeviceValues.GetAt(index, ref propKey, ref propVar);

        //    propertyKey = propKey;

        //    (object value, Type valueType) result;

        //    if (_dic.ContainsKey(propKey))

        //    {

        //        object _result = _dic[propertyKey];

        //        result = (_result, _result.GetType());

        //    }

        //    else

        //        result = (propVar.Value, NativePropertyHelper.VarEnumToSystemType(propVar.VarType));

        //    propVar.Dispose();

        //    valueType = result.valueType;

        //    return result.value;

        //}

        //HResult INativeReadOnlyCollection<PropertyKey>.GetAt(ref uint index, out PropertyKey item) => GetAt(ref index, out item);

        //private PropertyKey this[PropertyKey key]
        //{
        //    get
        //    {
        //        _ = GetAt(ref index, out PropertyKey item);

        //        return item;
        //    }
        //}

        //PropertyKey WinCopies.Collections.IUIntIndexedCollection<PropertyKey>.this[uint index] => this[index];

        //object WinCopies.Collections.IUIntIndexedCollection.this[uint index] => this[index];

        HResult INativeReadOnlyValueCollection.GetCount(out uint count)
        {
            ThrowIfDisposed();

            uint _count = 0;

            HResult result = _portableDeviceValues.GetCount(ref _count);

            count = _count;

            return result;
        }

        HResult INativeReadOnlyValueCollection.GetValue(ref PropertyKey key, out object pValue, out Type valueType)

        {
            ThrowIfDisposed();

            //if (Dic.TryGetValue(key, out object value))

            //{

            //    pValue = value;

            //    valueType = value.GetType();

            //    return HResult.Ok;

            //}

            var propVariant = new PropVariant();

            HResult hr = _portableDeviceValues.GetValue(ref key, propVariant);

            if (hr == HResult.ElementNotFound)

            {

                propVariant.Dispose();

                pValue = null;

                valueType = null;

                return hr;

            }

            (object value, Type valueType) result = (propVariant.Value, NativePropertyHelper.VarEnumToSystemType(propVariant.VarType));

            propVariant.Dispose();

            pValue = result.value;

            valueType = result.valueType;

            return HResult.Ok;
        }

        HResult INativeReadOnlyValueCollection.GetStringValue(ref PropertyKey key, out string pValue) => PortableDeviceValues.GetStringValue(ref key, out pValue);

        HResult INativeReadOnlyValueCollection.GetUnsignedIntegerValue(ref PropertyKey key, out uint pValue) => PortableDeviceValues.GetUnsignedIntegerValue(ref key, out pValue);

        HResult INativeReadOnlyValueCollection.GetSignedIntegerValue(ref PropertyKey key, out int pValue) => PortableDeviceValues.GetSignedIntegerValue(ref key, out pValue);

        HResult INativeReadOnlyValueCollection.GetUnsignedLargeIntegerValue(ref PropertyKey key, out ulong pValue) => PortableDeviceValues.GetUnsignedLargeIntegerValue(ref key, out pValue);

        HResult INativeReadOnlyValueCollection.GetSignedLargeIntegerValue(ref PropertyKey key, out long pValue) => PortableDeviceValues.GetSignedLargeIntegerValue(ref key, out pValue);

        HResult INativeReadOnlyValueCollection.GetFloatValue(ref PropertyKey key, out float pValue) => PortableDeviceValues.GetFloatValue(ref key, out pValue);

        HResult INativeReadOnlyValueCollection.GetErrorValue(ref PropertyKey key, out HResult pValue) => PortableDeviceValues.GetErrorValue(ref key, out pValue);

        HResult INativeReadOnlyValueCollection.GetKeyValue(ref PropertyKey key, out PropertyKey pValue) => PortableDeviceValues.GetKeyValue(ref key, out pValue);

        HResult INativeReadOnlyValueCollection.GetBoolValue(ref PropertyKey key, out bool pValue) => PortableDeviceValues.GetBoolValue(ref key, out pValue);

        HResult INativeReadOnlyValueCollection.GetIUnknownValue(ref PropertyKey key, out object ppValue) => PortableDeviceValues.GetIUnknownValue(ref key, out ppValue);

        HResult INativeReadOnlyValueCollection.GetGuidValue(ref PropertyKey key, out Guid pValue) => PortableDeviceValues.GetGuidValue(ref key, out pValue);

        HResult INativeReadOnlyValueCollection.GetBufferValue(ref PropertyKey key, out byte[] ppValue)
        {
            HResult hr = PortableDeviceValues.GetBufferValue(ref key,
                   out ppValue,
#if DEBUG
                out uint count
#else
                out uint _
#endif
                );

#if DEBUG

            if (CoreErrorHelper.Succeeded(hr))

                Debug.Assert(ppValue.Length == count);

#endif

            return hr;
        }

        //private HResult GetFromDictionary<T>(in PropertyKey key, out T value) where T : class
        //{

        //    ThrowIfDisposed();

        //    if (Dic.TryGetValue(key, out object _value))

        //        if (_value is T __value)

        //        {

        //            value = __value;

        //            return HResult.Ok;

        //        }

        //        else

        //        {

        //            value = null;

        //            return HResult.DispTypeMismatch;

        //        }

        //    else

        //    {

        //        value = null;

        //        return HResult.ElementNotFound;

        //    }

        //}

        //HResult INativeReadOnlyValueCollection.GetIPortableDeviceValuesValue(in PropertyKey key, out IPortableDeviceValues ppValue)

        //{

        //    GetFromDictionary<ICollection<>>

        //}

        //HResult INativeReadOnlyValueCollection.GetPropVariantCollectionValue(in PropertyKey key, out ICollection<PropVariant> ppValue)

        //{

        //    HResult hr = GetFromDictionary<ICollection<PropVariant>>(key, out ICollection<PropVariant> value);

        //    if (CoreErrorHelper.Succeeded(hr))

        //        ppValue = value;

        //    else if (hr == HResult.ElementNotFound)

        //    {

        //        hr = _portableDeviceValues.GetIPortableDevicePropVariantCollectionValue(key, out IPortableDevicePropVariantCollection portableDevicePropVariantCollection);

        //        if (CoreErrorHelper.Succeeded(hr))

        //        {

        //            Dic.Add(key, new ReadOnlyCollection<PropVariant>(new propvariant(portableDevicePropVariantCollection)));

        //            ppValue = value;

        //        }

        //        else

        //            ppValue = null;

        //    }

        //    else

        //        ppValue = null;

        //    return hr;

        //}

        //HResult INativeReadOnlyValueCollection.GetPropertyKeyCollectionValue(in PropertyKey key, out ICollection<PropertyKey> ppValue)

        //{

        //    HResult hr = GetFromDictionary<ICollection<PropertyKey>>(key, out ICollection<PropertyKey> value);

        //    if (CoreErrorHelper.Succeeded(hr))

        //        ppValue = value;

        //    else if (hr == HResult.ElementNotFound)

        //    {

        //        hr = _portableDeviceValues.GetIPortableDeviceKeyCollectionValue(key, out IPortableDeviceKeyCollection portableDevicePropVariantCollection);

        //        if (CoreErrorHelper.Succeeded(hr))

        //        {

        //            Dic.Add(key, new ReadOnlyCollection<PropertyKey>(new NativePropertyKeyCollection(portableDevicePropVariantCollection)));

        //            ppValue = value;

        //        }

        //        else

        //            ppValue = null;

        //    }

        //    else

        //        ppValue = null;

        //    return hr;

        //}

        //HResult INativeReadOnlyValueCollection.GetIPortableDeviceValuesCollectionValue(ref PropertyKey key, out IPortableDeviceValuesCollection ppValue) => throw new NotImplementedException();

        HResult INativeReadOnlyValueCollection.CopyValuesFromPropertyStore(ref IPropertyStore pStore) => PortableDeviceValues.CopyValuesFromPropertyStore(pStore);

        HResult INativeReadOnlyValueCollection.CopyValuesToPropertyStore(ref IPropertyStore pStore) => PortableDeviceValues.CopyValuesToPropertyStore(ref pStore);
    }

    internal sealed class NativeValueCollection : NativeReadOnlyValueCollection, INativeValueCollection

    {

        public NativeValueCollection(IPortableDeviceValues portableDeviceValues) : base(portableDeviceValues) { }

        bool INativeReadOnlyValueCollection.IsReadOnly
        {
            get
            {
                ThrowIfDisposed();

                return false;
            }
        }

        HResult INativeValueCollection.Clear() => PortableDeviceValues.Clear();

        HResult INativeValueCollection.RemoveValue(ref PropertyKey propertyKey) => PortableDeviceValues.RemoveValue(ref propertyKey);

        HResult INativeValueCollection.SetStringValue(ref PropertyKey key, in string Value) => PortableDeviceValues.SetStringValue(ref key, Value);

        HResult INativeValueCollection.SetUnsignedIntegerValue(ref PropertyKey key, in uint Value) => PortableDeviceValues.SetUnsignedIntegerValue(ref key, Value);

        HResult INativeValueCollection.SetSignedIntegerValue(ref PropertyKey key, in int Value) => PortableDeviceValues.SetSignedIntegerValue(ref key, Value);

        HResult INativeValueCollection.SetUnsignedLargeIntegerValue(ref PropertyKey key, in ulong Value) => PortableDeviceValues.SetUnsignedLargeIntegerValue(ref key, Value);

        HResult INativeValueCollection.SetSignedLargeIntegerValue(ref PropertyKey key, in long Value) => PortableDeviceValues.SetSignedLargeIntegerValue(ref key, Value);

        HResult INativeValueCollection.SetFloatValue(ref PropertyKey key, in float Value) => PortableDeviceValues.SetFloatValue(ref key, Value);

        HResult INativeValueCollection.SetErrorValue(ref PropertyKey key, in HResult Value) => PortableDeviceValues.SetErrorValue(ref key, Value);

        HResult INativeValueCollection.SetKeyValue(ref PropertyKey key, ref PropertyKey Value) => PortableDeviceValues.SetKeyValue(ref key, ref Value);

        HResult INativeValueCollection.SetBoolValue(ref PropertyKey key, in bool Value) => PortableDeviceValues.SetBoolValue(ref key, Value);

        HResult INativeValueCollection.SetIUnknownValue(ref PropertyKey key, ref object pValue) => PortableDeviceValues.SetIUnknownValue(ref key, ref pValue);

        HResult INativeValueCollection.SetGuidValue(ref PropertyKey key, ref Guid Value) => PortableDeviceValues.SetGuidValue(ref key, ref Value);

        HResult INativeValueCollection.SetBufferValue(ref PropertyKey key, in byte[] pValue) => PortableDeviceValues.SetBufferValue(ref key, pValue, (uint)pValue.Length);

        //private HResult SetToDictionary<T>(ref PropertyKey key, T value) where T : class

        //{

        //        else

        //        {

        //            PortableDeviceValues.

        //        }

        //}

        //HResult INativeValueCollection.SetIPortableDeviceValuesValue(ref PropertyKey key, in IPortableDeviceValues pValue) => throw new NotImplementedException();

        //HResult INativeValueCollection.SetPropVariantCollectionValue(ref PropertyKey key, in ICollection<PropVariant> pValue) => throw new NotImplementedException();

        //HResult INativeValueCollection.SetPropertyKeyCollectionValue(ref PropertyKey key, in ICollection<PropertyKey> pValue)

        //{

        //    if (Dic.TryGetValue(key, out object _value))

        //        if (pValue == _value)

        //            return HResult.Ok;

        //        else

        //        { 

        //            Dic[key] = pValue;

        //            PortableDeviceValues.SetIPortableDeviceKeyCollectionValue(ref key, )

        //}

        //HResult INativeValueCollection.SetIPortableDeviceValuesCollectionValue(ref PropertyKey key, in IPortableDeviceValuesCollection pValue) => throw new NotImplementedException();
    }
}
