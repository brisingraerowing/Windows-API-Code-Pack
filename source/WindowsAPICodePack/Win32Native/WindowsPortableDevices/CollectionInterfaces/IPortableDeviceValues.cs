using Microsoft.WindowsAPICodePack.Win32Native;
using Microsoft.WindowsAPICodePack.Win32Native.PropertySystem;
using Microsoft.WindowsAPICodePack.Win32Native.Shell.PropertySystem;
using MS.WindowsAPICodePack.Win32Native.Shell.PropertySystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using GuidAttribute = System.Runtime.InteropServices.GuidAttribute;

namespace Microsoft.WindowsAPICodePack.Win32Native.PortableDevices
{
    [ComImport,
        Guid(Win32Native.Guids.PortableDevices.IPortableDeviceValues),
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IPortableDeviceValues
    {
        [PreserveSig]
        HResult GetCount(
            [In] ref uint pcelt);

        [PreserveSig]
        HResult GetAt(
            [In] uint index,
            [In, Out] ref PropertyKey pKey,
            [In, Out] ref PropVariant pValue);

        [PreserveSig]
        HResult SetValue(
            [In] ref PropertyKey key,
            [In] ref PropVariant pValue);

        [PreserveSig]
        HResult GetValue(
            [In] ref PropertyKey key,
            [Out] out PropVariant pValue);

        [PreserveSig]
        HResult SetStringValue(
            [In] ref PropertyKey key,
            [In, MarshalAs(UnmanagedType.LPWStr)] string Value);

        [PreserveSig]
        HResult GetStringValue(
            [In] ref PropertyKey key,
            [Out, MarshalAs(UnmanagedType.LPWStr)] out string pValue);

        [PreserveSig]
        HResult SetUnsignedIntegerValue(
            [In] ref PropertyKey key,
            [In] uint Value);

        [PreserveSig]
        HResult GetUnsignedIntegerValue(
            [In] ref PropertyKey key,
            [Out] out uint pValue);

        [PreserveSig]
        HResult SetSignedIntegerValue(
            [In] ref PropertyKey key,
            [In] int Value);

        [PreserveSig]
        HResult GetSignedIntegerValue(
            [In] ref PropertyKey key,
            [Out] out int pValue);

        [PreserveSig]
        HResult SetUnsignedLargeIntegerValue(
            [In] ref PropertyKey key,
            [In] ulong Value);

        [PreserveSig]
        HResult GetUnsignedLargeIntegerValue(
            [In] ref PropertyKey key,
            [Out] out ulong pValue);

        [PreserveSig]
        HResult SetSignedLargeIntegerValue(
            [In] ref PropertyKey key,
            [In] long Value);

        [PreserveSig]
        HResult GetSignedLargeIntegerValue(
            [In] ref PropertyKey key,
            [Out] out long pValue);

        [PreserveSig]
        HResult SetFloatValue(
            [In] ref PropertyKey key,
            [In] float Value);

        [PreserveSig]
        HResult GetFloatValue(
            [In] ref PropertyKey key,
            [Out] out float pValue);

        [PreserveSig]
        HResult SetErrorValue(
            [In] ref PropertyKey key,
            [In, MarshalAs(UnmanagedType.Error)] HResult Value);

        [PreserveSig]
        HResult GetErrorValue(
            [In] ref PropertyKey key,
            [Out, MarshalAs(UnmanagedType.Error)] out HResult pValue);

        [PreserveSig]
        HResult SetKeyValue(
            [In] ref PropertyKey key,
            [In] ref PropertyKey Value);

        [PreserveSig]
        HResult GetKeyValue(
            [In] ref PropertyKey key,
            [Out] out PropertyKey pValue);

        [PreserveSig]
        HResult SetBoolValue(
            [In] ref PropertyKey key,
            [In, MarshalAs(UnmanagedType.Bool)] bool Value);

        [PreserveSig]
        HResult GetBoolValue(
            [In] ref PropertyKey key,
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pValue);

        [PreserveSig]
        HResult SetIUnknownValue(
            [In] ref PropertyKey key,
            [In, MarshalAs(UnmanagedType.IUnknown)] ref object pValue);

        [PreserveSig]
        HResult GetIUnknownValue(
            [In] ref PropertyKey key,
            [Out, MarshalAs(UnmanagedType.IUnknown)] out object ppValue);

        [PreserveSig]
        HResult SetGuidValue(
            [In] ref PropertyKey key,
            [In] ref Guid Value);

        [PreserveSig]
        HResult GetGuidValue(
            [In] ref PropertyKey key,
            [Out] out Guid pValue);

        [PreserveSig]
        HResult SetBufferValue(
            [In] ref PropertyKey key,
            [In] byte[] pValue,
            [In] uint cbValue);

        [PreserveSig]
        HResult GetBufferValue(
            [In] ref PropertyKey key,
            [Out] IntPtr ppValue,
            [Out] out uint pcbValue);

        [PreserveSig]
        HResult SetIPortableDeviceValuesValue(
            [In] ref PropertyKey key, 
            [In, MarshalAs(UnmanagedType.Interface)] ref IPortableDeviceValues pValue);

        [PreserveSig]
        HResult GetIPortableDeviceValuesValue(
            [In] ref PropertyKey key, 
            [Out, MarshalAs(UnmanagedType.Interface)] out IPortableDeviceValues ppValue);

        [PreserveSig]
        HResult SetIPortableDevicePropVariantCollectionValue(
            [In] ref PropertyKey key, 
            [In, MarshalAs(UnmanagedType.Interface)] ref IPortableDevicePropVariantCollection pValue);

        [PreserveSig]
        HResult GetIPortableDevicePropVariantCollectionValue(
            [In] ref PropertyKey key, 
            [Out, MarshalAs(UnmanagedType.Interface)] out IPortableDevicePropVariantCollection ppValue);

        [PreserveSig]
        HResult SetIPortableDeviceKeyCollectionValue(
            [In] ref PropertyKey key, 
            [In, MarshalAs(UnmanagedType.Interface)] ref IPortableDeviceKeyCollection pValue);

        [PreserveSig]
        HResult GetIPortableDeviceKeyCollectionValue(
            [In] ref PropertyKey key, 
            [Out, MarshalAs(UnmanagedType.Interface)] out IPortableDeviceKeyCollection ppValue);

        [PreserveSig]
        HResult SetIPortableDeviceValuesCollectionValue(
            [In] ref PropertyKey key, 
            [In, MarshalAs(UnmanagedType.Interface)] ref IPortableDeviceValuesCollection pValue);

        [PreserveSig]
        HResult GetIPortableDeviceValuesCollectionValue(
            [In] ref PropertyKey key, 
            [Out, MarshalAs(UnmanagedType.Interface)] out IPortableDeviceValuesCollection ppValue);

        [PreserveSig]
        HResult RemoveValue(
            [In] ref PropertyKey key);

        [PreserveSig]
        HResult CopyValuesFromPropertyStore(
            [In, MarshalAs(UnmanagedType.Interface)] ref IPropertyStore pStore);

        [PreserveSig]
        HResult CopyValuesToPropertyStore(
            [In, MarshalAs(UnmanagedType.Interface)] ref IPropertyStore pStore);

        [PreserveSig]
        HResult Clear();
    }
}
