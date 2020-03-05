using Microsoft.WindowsAPICodePack.PropertySystem;
using Microsoft.WindowsAPICodePack.Win32Native;
using Microsoft.WindowsAPICodePack.Win32Native.PortableDevices;
using Microsoft.WindowsAPICodePack.PortableDevices.PropertySystem;
using Microsoft.WindowsAPICodePack.Win32Native.PropertySystem;
using Microsoft.WindowsAPICodePack.Win32Native.Shell.PropertySystem;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.WindowsAPICodePack.PortableDevices.PropertySystem
{
    public interface IPortableDeviceValues : WinCopies.Util.DotNetFix.IDisposable
    {
        uint Count { get; }

        object GetAt(in uint index, out PropertyKey key, out Type valueType);

        object GetValue(
            ref PropertyKey key,
            out Type valueType); // Setting a value object is not allowed because we don't know if we'll get a native or a managed object; thus, a check could be broken in case of interface update.

        void SetStringValue(
            ref PropertyKey key,
            in string value);

        string GetStringValue(
            ref PropertyKey key);

        void SetUnsignedIntegerValue(
            ref PropertyKey key,
            in uint value);

        uint GetUnsignedIntegerValue(
            ref PropertyKey key);

        void SetSignedIntegerValue(
            ref PropertyKey key,
            in int value);

        int GetSignedIntegerValue(
            ref PropertyKey key);

        void SetUnsignedLargeIntegerValue(
            ref PropertyKey key,
            in ulong value);

        ulong GetUnsignedLargeIntegerValue(
            ref PropertyKey key);

        void SetSignedLargeIntegerValue(
            ref PropertyKey key,
            in long value);

        long GetSignedLargeIntegerValue(
            ref PropertyKey key);

        void SetFloatValue(
            ref PropertyKey key,
            in float value);

        float GetFloatValue(
            ref PropertyKey key);

        void SetErrorValue(
            ref PropertyKey key,
            in HResult value);

        HResult GetErrorValue(
            ref PropertyKey key);

        void SetKeyValue(
            ref PropertyKey key,
            ref PropertyKey value);

        PropertyKey GetKeyValue(
            ref PropertyKey key);

        void SetBoolValue(
            ref PropertyKey key,
            in bool value);

        bool GetBoolValue(
            ref PropertyKey key);

        void SetIUnknownValue(
            ref PropertyKey key,
            ref object value);

        object GetIUnknownValue(
            ref PropertyKey key);

        void SetGuidValue(
            ref PropertyKey key,
            ref Guid value);

        Guid GetGuidValue(
            ref PropertyKey key);

        void SetBufferValue(
            ref PropertyKey key,
            in byte[] value);

        byte[] GetBufferValue(
            ref PropertyKey key);

        void SetPortableDeviceValuesValue(
            ref PropertyKey key,
            ref PortableDeviceValues value);

        PortableDeviceValues GetPortableDeviceValuesValue(
            in PropertyKey key);

        void SetPortableDevicePropVariantCollectionValue(
            ref PropertyKey key,
            ref PortableDevicePropVariantCollection value);

        PortableDevicePropVariantCollection GetPortableDevicePropVariantCollectionValue(
            in PropertyKey key);

        void SetPortableDeviceKeyCollectionValue(
            ref PropertyKey key,
            ref PortableDeviceKeyCollection value);

        PortableDeviceKeyCollection GetPortableDeviceKeyCollectionValue(
            in PropertyKey key);

        void SetPortableDeviceValuesCollectionValue(
            ref PropertyKey key,
            ref PortableDeviceValuesCollection value);

        PortableDeviceValuesCollection GetPortableDeviceValuesCollectionValue(
            in PropertyKey key);

        void RemoveValue(
            ref PropertyKey key);

        void CopyValuesFromPropertyStore(
            ref IPropertyStore pStore);

        void CopyValuesToPropertyStore(
            ref IPropertyStore pStore);

        void Clear();
    }
}
