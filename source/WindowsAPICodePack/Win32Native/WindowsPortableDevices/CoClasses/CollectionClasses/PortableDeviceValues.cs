using Microsoft.WindowsAPICodePack.Win32Native.PortableDevices.PropertySystem;
using Microsoft.WindowsAPICodePack.Win32Native.Shell.PropertySystem;
using MS.WindowsAPICodePack.Win32Native.Shell.PropertySystem;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using GuidAttribute = System.Runtime.InteropServices.GuidAttribute;

namespace Microsoft.WindowsAPICodePack.Win32Native.PortableDevices.PropertySystem
{
    [ComImport,
        Guid(Guids.PortableDevices.PortableDeviceValues),
        ClassInterface(ClassInterfaceType.None),
        TypeLibType(TypeLibTypeFlags.FCanCreate)]
    public class PortableDeviceValues : IPortableDeviceValues
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public extern virtual HResult GetCount([In] ref uint pcelt);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public extern virtual HResult GetAt([In] uint index, [In, Out] ref PropertyKey pKey, [In, Out] ref PropVariant pValue);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public extern virtual HResult SetValue([In] ref PropertyKey key, [In] ref PropVariant pValue);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public extern virtual HResult GetValue([In] ref PropertyKey key, [Out] out PropVariant pValue);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public extern virtual HResult SetStringValue([In] ref PropertyKey key, [In, MarshalAs(UnmanagedType.LPWStr)] string Value);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public extern virtual HResult GetStringValue([In] ref PropertyKey key, [MarshalAs(UnmanagedType.LPWStr), Out] out string pValue);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public extern virtual HResult SetUnsignedIntegerValue([In] ref PropertyKey key, [In] uint Value);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public extern virtual HResult GetUnsignedIntegerValue([In] ref PropertyKey key, [Out] out uint pValue);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public extern virtual HResult SetSignedIntegerValue([In] ref PropertyKey key, [In] int Value);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public extern virtual HResult GetSignedIntegerValue([In] ref PropertyKey key, [Out] out int pValue);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public extern virtual HResult SetUnsignedLargeIntegerValue([In] ref PropertyKey key, [In] ulong Value);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public extern virtual HResult GetUnsignedLargeIntegerValue([In] ref PropertyKey key, [Out] out ulong pValue);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public extern virtual HResult SetSignedLargeIntegerValue([In] ref PropertyKey key, [In] long Value);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public extern virtual HResult GetSignedLargeIntegerValue([In] ref PropertyKey key, [Out] out long pValue);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public extern virtual HResult SetFloatValue([In] ref PropertyKey key, [In] float Value);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public extern virtual HResult GetFloatValue([In] ref PropertyKey key, [Out] out float pValue);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public extern virtual HResult SetErrorValue([In] ref PropertyKey key, [In, MarshalAs(UnmanagedType.Error)] HResult Value);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public extern virtual HResult GetErrorValue([In] ref PropertyKey key, [MarshalAs(UnmanagedType.Error), Out] out HResult pValue);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public extern virtual HResult SetKeyValue([In] ref PropertyKey key, [In] ref PropertyKey Value);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public extern virtual HResult GetKeyValue([In] ref PropertyKey key, [Out] out PropertyKey pValue);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public extern virtual HResult SetBoolValue([In] ref PropertyKey key, [In, MarshalAs(UnmanagedType.Bool)] bool Value);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public extern virtual HResult GetBoolValue([In] ref PropertyKey key, [MarshalAs(UnmanagedType.Bool), Out] out bool pValue);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public extern virtual HResult SetIUnknownValue([In] ref PropertyKey key, [In, MarshalAs(UnmanagedType.IUnknown)] ref object pValue);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public extern virtual HResult GetIUnknownValue([In] ref PropertyKey key, [MarshalAs(UnmanagedType.IUnknown), Out] out object ppValue);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public extern virtual HResult SetGuidValue([In] ref PropertyKey key, [In] ref Guid Value);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public extern virtual HResult GetGuidValue([In] ref PropertyKey key, [Out] out Guid pValue);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public extern virtual HResult SetBufferValue([In] ref PropertyKey key, [In] byte[] pValue, [In] uint cbValue);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public extern virtual HResult GetBufferValue([In] ref PropertyKey key, [Out] IntPtr ppValue, [Out] out uint pcbValue);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public extern virtual HResult SetIPortableDeviceValuesValue([In] ref PropertyKey key, [In, MarshalAs(UnmanagedType.Interface)] ref IPortableDeviceValues pValue);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public extern virtual HResult GetIPortableDeviceValuesValue([In] ref PropertyKey key, [MarshalAs(UnmanagedType.Interface), Out] out IPortableDeviceValues ppValue);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public extern virtual HResult SetIPortableDevicePropVariantCollectionValue([In] ref PropertyKey key, [In, MarshalAs(UnmanagedType.Interface)] ref IPortableDevicePropVariantCollection pValue);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public extern virtual HResult GetIPortableDevicePropVariantCollectionValue([In] ref PropertyKey key, [MarshalAs(UnmanagedType.Interface), Out] out IPortableDevicePropVariantCollection ppValue);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public extern virtual HResult SetIPortableDeviceKeyCollectionValue([In] ref PropertyKey key, [In, MarshalAs(UnmanagedType.Interface)] ref IPortableDeviceKeyCollection pValue);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public extern virtual HResult GetIPortableDeviceKeyCollectionValue([In] ref PropertyKey key, [MarshalAs(UnmanagedType.Interface), Out] out IPortableDeviceKeyCollection ppValue);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public extern virtual HResult SetIPortableDeviceValuesCollectionValue([In] ref PropertyKey key, [In, MarshalAs(UnmanagedType.Interface)] ref IPortableDeviceValuesCollection pValue);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public extern virtual HResult GetIPortableDeviceValuesCollectionValue([In] ref PropertyKey key, [MarshalAs(UnmanagedType.Interface), Out] out IPortableDeviceValuesCollection ppValue);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public extern virtual HResult RemoveValue([In] ref PropertyKey key);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public extern virtual HResult CopyValuesFromPropertyStore([In, MarshalAs(UnmanagedType.Interface)] ref IPropertyStore pStore);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public extern virtual HResult CopyValuesToPropertyStore([In, MarshalAs(UnmanagedType.Interface)] ref IPropertyStore pStore);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public extern virtual HResult Clear();
    }
}
