using Microsoft.WindowsAPICodePack.Win32Native;
using Microsoft.WindowsAPICodePack.Win32Native.Shell.PropertySystem;
using MS.WindowsAPICodePack.Win32Native.Shell.PropertySystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.WindowsAPICodePack.Win32Native.PortableDevices.PropertySystem
{
    [ComImport,
        Guid(Win32Native.Guids.PortableDevices.IPortableDeviceValues),
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IPortableDeviceValues
    {
        HResult GetCount(
            [In] ref uint pcelt);

        HResult GetAt(
            [In] uint index,
            [In, Out] ref PropertyKey pKey,
            [In, Out] ref PropVariant pValue);

        HResult SetValue(
            [In] ref PropertyKey key,
            [In] ref PropVariant pValue);

        HResult GetValue(
            [In] ref PropertyKey key,
            [Out] out PropVariant pValue);

        HResult SetStringValue(
            [In] ref PropertyKey key,
            [In, MarshalAs(UnmanagedType.LPWStr)] string Value);

        HResult GetStringValue(
            [In] ref PropertyKey key,
            [Out, MarshalAs(UnmanagedType.LPWStr)] out string pValue);

        HResult SetUnsignedIntegerValue(
            [In] ref PropertyKey key,
            [In] uint Value);

        HResult GetUnsignedIntegerValue(
            [In] ref PropertyKey key,
            [Out] out uint pValue);

        HResult SetSignedIntegerValue(
            [In] ref PropertyKey key,
            [In] int Value);

        HResult GetSignedIntegerValue(
            [In] ref PropertyKey key,
            [Out] out int pValue);

        HResult SetUnsignedLargeIntegerValue(
            [In] ref PropertyKey key,
            [In] ulong Value);

        HResult GetUnsignedLargeIntegerValue(
            [In] ref PropertyKey key,
            [Out] out ulong pValue);

        HResult SetSignedLargeIntegerValue(
            [In] ref PropertyKey key,
            [In] long Value);

        HResult GetSignedLargeIntegerValue(
            [In] ref PropertyKey key,
            [Out] out long pValue);

        HResult SetFloatValue(
            [In] ref PropertyKey key,
            [In] float Value);

        HResult GetFloatValue(
            [In] ref PropertyKey key,
            [Out] out float pValue);

        HResult SetErrorValue(
            [In] ref PropertyKey key,
            [In, MarshalAs(UnmanagedType.Error)] HResult Value);

        HResult GetErrorValue(
            [In] ref PropertyKey key,
            [Out, MarshalAs(UnmanagedType.Error)] out HResult pValue);

        HResult SetKeyValue(
            [In] ref PropertyKey key,
            [In] ref PropertyKey Value);

        HResult GetKeyValue(
            [In] ref PropertyKey key,
            [Out] out PropertyKey pValue);

        HResult SetBoolValue(
            [In] ref PropertyKey key,
            [In, MarshalAs(UnmanagedType.Bool)] bool Value);

        HResult GetBoolValue(
            [In] ref PropertyKey key,
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pValue);

        HResult SetIUnknownValue(
            [In] ref PropertyKey key,
            [In, MarshalAs(UnmanagedType.IUnknown)] ref object pValue);

        HResult GetIUnknownValue(
            [In] ref PropertyKey key,
            [Out, MarshalAs(UnmanagedType.IUnknown)] out object ppValue);

        HResult SetGuidValue(
            [In] ref PropertyKey key,
            [In] ref Guid Value);

        HResult GetGuidValue(
            [In] ref PropertyKey key,
            [Out] out Guid pValue);

        HResult SetBufferValue(
            [In] ref PropertyKey key,
            [In] byte[] pValue,
            [In] uint cbValue);

        HResult GetBufferValue(
            [In] ref PropertyKey key,
            [Out] IntPtr ppValue,
            [Out] out uint pcbValue);

        HResult SetIPortableDeviceValuesValue(
            [In] ref PropertyKey key, 
            [In, MarshalAs(UnmanagedType.Interface)] ref IPortableDeviceValues pValue);

        HResult GetIPortableDeviceValuesValue(
            [In] ref PropertyKey key, 
            [Out, MarshalAs(UnmanagedType.Interface)] out IPortableDeviceValues ppValue);

        HResult SetIPortableDevicePropVariantCollectionValue(
            [In] ref PropertyKey key, 
            [In, MarshalAs(UnmanagedType.Interface)] ref IPortableDevicePropVariantCollection pValue);

        HResult GetIPortableDevicePropVariantCollectionValue(
            [In] ref PropertyKey key, 
            [Out, MarshalAs(UnmanagedType.Interface)] out IPortableDevicePropVariantCollection ppValue);

        HResult SetIPortableDeviceKeyCollectionValue(
            [In] ref PropertyKey key, 
            [In, MarshalAs(UnmanagedType.Interface)] ref IPortableDeviceKeyCollection pValue);

        HResult GetIPortableDeviceKeyCollectionValue(
            [In] ref PropertyKey key, 
            [Out, MarshalAs(UnmanagedType.Interface)] out IPortableDeviceKeyCollection ppValue);

        HResult SetIPortableDeviceValuesCollectionValue(
            [In] ref PropertyKey key, 
            [In, MarshalAs(UnmanagedType.Interface)] ref IPortableDeviceValuesCollection pValue);

        HResult GetIPortableDeviceValuesCollectionValue(
            [In] ref PropertyKey key, 
            [Out, MarshalAs(UnmanagedType.Interface)] out IPortableDeviceValuesCollection ppValue);

        HResult RemoveValue(
            [In] ref PropertyKey key);

        HResult CopyValuesFromPropertyStore(
            [In, MarshalAs(UnmanagedType.Interface)] ref IPropertyStore pStore);

        HResult CopyValuesToPropertyStore(
            [In, MarshalAs(UnmanagedType.Interface)] ref IPropertyStore pStore);

        HResult Clear();
    }
}
