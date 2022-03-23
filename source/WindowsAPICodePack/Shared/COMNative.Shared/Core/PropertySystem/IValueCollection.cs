using Microsoft.WindowsAPICodePack.COMNative.Shell.PropertySystem;
using Microsoft.WindowsAPICodePack.PropertySystem;
using Microsoft.WindowsAPICodePack.Win32Native;

using System;

namespace Microsoft.WindowsAPICodePack.COMNative.PropertySystem
{
    public interface INativeReadOnlyValueCollection : WinCopies.
#if WAPICP2
        Util.
#endif
        DotNetFix.IDisposable
    {
        bool IsReadOnly { get; }

        HResult GetCount(out uint pcelt);

        //HResult GetAt( in uint index,  ref PropertyKey pKey,  PropVariant pValue);

        HResult GetValue(ref PropertyKey key, out object pValue, out Type valueType);

        HResult GetStringValue(ref PropertyKey key, out string pValue);

        HResult GetUnsignedIntegerValue(ref PropertyKey key, out uint pValue);

        HResult GetSignedIntegerValue(ref PropertyKey key, out int pValue);

        HResult GetUnsignedLargeIntegerValue(ref PropertyKey key, out ulong pValue);

        HResult GetSignedLargeIntegerValue(ref PropertyKey key, out long pValue);

        HResult GetFloatValue(ref PropertyKey key, out float pValue);

        HResult GetErrorValue(ref PropertyKey key, out HResult pValue);

        HResult GetKeyValue(ref PropertyKey key, out PropertyKey pValue);

        HResult GetBoolValue(ref PropertyKey key, out bool pValue);

        HResult GetIUnknownValue(ref PropertyKey key, out object ppValue);

        HResult GetGuidValue(ref PropertyKey key, out Guid pValue);

        HResult GetBufferValue(ref PropertyKey key, out byte[] ppValue);

        //HResult GetIPortableDeviceValuesValue(in PropertyKey key, out IPortableDeviceValues ppValue);

        //HResult GetPropVariantCollectionValue(in PropertyKey key, out ICollection<PropVariant> ppValue);

        //HResult GetPropertyKeyCollectionValue(in PropertyKey key, out ICollection<PropertyKey> ppValue);

        //HResult GetIPortableDeviceValuesCollectionValue(in PropertyKey key, out IPortableDeviceValuesCollection ppValue);

        HResult CopyValuesFromPropertyStore(ref IPropertyStore pStore);

        HResult CopyValuesToPropertyStore(ref IPropertyStore pStore);
    }

    public interface INativeValueCollection : INativeReadOnlyValueCollection
    {
        HResult SetStringValue(ref PropertyKey key, in string Value);

        HResult SetUnsignedIntegerValue(ref PropertyKey key, in uint Value);

        HResult SetSignedIntegerValue(ref PropertyKey key, in int Value);

        HResult SetUnsignedLargeIntegerValue(ref PropertyKey key, in ulong Value);

        HResult SetSignedLargeIntegerValue(ref PropertyKey key, in long Value);

        HResult SetFloatValue(ref PropertyKey key, in float Value);

        HResult SetErrorValue(ref PropertyKey key, in HResult Value);

        HResult SetKeyValue(ref PropertyKey key, ref PropertyKey Value);

        HResult SetBoolValue(ref PropertyKey key, in bool Value);

        HResult SetIUnknownValue(ref PropertyKey key, ref object pValue);

        HResult SetGuidValue(ref PropertyKey key, ref Guid Value);

        HResult SetBufferValue(ref PropertyKey key, in byte[] pValue);

        //HResult SetIPortableDeviceValuesValue(ref PropertyKey key, in IPortableDeviceValues pValue);

        //HResult SetPropVariantCollectionValue(ref PropertyKey key, in ICollection<PropVariant> pValue);

        //HResult SetPropertyKeyCollectionValue(ref PropertyKey key, in ICollection<PropertyKey> pValue);

        //HResult SetIPortableDeviceValuesCollectionValue(ref PropertyKey key, in IPortableDeviceValuesCollection pValue);

        HResult RemoveValue(ref PropertyKey key);

        HResult Clear();
    }
}
