// Copyright (c) Microsoft Corporation.  All rights reserved.

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Microsoft.WindowsAPICodePack.Shell.PropertySystem;
using Microsoft.WindowsAPICodePack.Win32Native.Core;
using Microsoft.WindowsAPICodePack.Win32Native.PortableDevices.CollectionInterfaces;
using Microsoft.WindowsAPICodePack.Win32Native.Shell.PropertySystem;
using MS.WindowsAPICodePack.Win32Native.Shell.PropertySystem;

// todo: replace by the upcoming WPD implementation

namespace Microsoft.WindowsAPICodePack.Win32Native.Sensors
{

    ///// <summary>
    ///// Exposes methods for enumerating, getting, and setting property values.
    ///// </summary>
    //[ComImport, Guid("886D8EEB-8CF2-4446-8D02-CDBA1DBDCF99"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    //public interface IPropertyStore
    //{
    //    void GetCount(out uint cProps);
    //    void GetAt([In] uint iProp, out PropertyKey pKey);
    //    void GetValue([In] ref PropertyKey key, [Out] PropVariant pv);
    //    void SetValue([In] ref PropertyKey key, [In] PropVariant propvar);
    //    void Commit();
    //}

    [ComImport, Guid("DE2D022D-2480-43BE-97F0-D1FA2CF98F4F"), ClassInterface(ClassInterfaceType.None), TypeLibType(TypeLibTypeFlags.FCanCreate)]
    public class PortableDeviceKeyCollection : IPortableDeviceKeyCollection
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HResult GetCount(ref uint pcElems);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HResult GetAt([In] uint dwIndex, ref PropertyKey pKey);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HResult Add([In] ref PropertyKey Key);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HResult Clear();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HResult RemoveAt([In] uint dwIndex);
    }

    [ComImport, Guid("0C15D503-D017-47CE-9016-7B3F978721CC"), ClassInterface(ClassInterfaceType.None), TypeLibType(TypeLibTypeFlags.FCanCreate)]
    public class PortableDeviceValues : IPortableDeviceValues
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HResult GetCount(ref uint pcelt);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HResult GetAt([In] uint index, [In, Out] ref PropertyKey pKey, [In, Out] ref PropVariant pValue);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HResult SetValue([In] ref PropertyKey key, [In] ref PropVariant pValue);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HResult GetValue([In] ref PropertyKey key, [Out] out PropVariant pValue);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HResult SetStringValue([In] ref PropertyKey key, [In, MarshalAs(UnmanagedType.LPWStr)] string Value);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HResult GetStringValue([In] ref PropertyKey key, [MarshalAs(UnmanagedType.LPWStr)] out string pValue);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HResult SetUnsignedIntegerValue([In] ref PropertyKey key, [In] uint Value);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HResult GetUnsignedIntegerValue([In] ref PropertyKey key, out uint pValue);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HResult SetSignedIntegerValue([In] ref PropertyKey key, [In] int Value);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HResult GetSignedIntegerValue([In] ref PropertyKey key, out int pValue);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HResult SetUnsignedLargeIntegerValue([In] ref PropertyKey key, [In] ulong Value);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HResult GetUnsignedLargeIntegerValue([In] ref PropertyKey key, out ulong pValue);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HResult SetSignedLargeIntegerValue([In] ref PropertyKey key, [In] long Value);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HResult GetSignedLargeIntegerValue([In] ref PropertyKey key, out long pValue);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HResult SetFloatValue([In] ref PropertyKey key, [In] float Value);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HResult GetFloatValue([In] ref PropertyKey key, out float pValue);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HResult SetErrorValue([In] ref PropertyKey key, [In, MarshalAs(UnmanagedType.Error)] HResult Value);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HResult GetErrorValue([In] ref PropertyKey key, [MarshalAs(UnmanagedType.Error)] out HResult pValue);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HResult SetKeyValue([In] ref PropertyKey key, [In] ref PropertyKey Value);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HResult GetKeyValue([In] ref PropertyKey key, out PropertyKey pValue);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HResult SetBoolValue([In] ref PropertyKey key, [In, MarshalAs(UnmanagedType.Bool)] bool Value);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HResult GetBoolValue([In] ref PropertyKey key, [Out, MarshalAs(UnmanagedType.Bool)] out bool pValue);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HResult SetIUnknownValue([In] ref PropertyKey key, [In, MarshalAs(UnmanagedType.IUnknown)] ref object pValue);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HResult GetIUnknownValue([In] ref PropertyKey key, [MarshalAs(UnmanagedType.IUnknown)] out object ppValue);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HResult SetGuidValue([In] ref PropertyKey key, [In] ref Guid Value);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HResult GetGuidValue([In] ref PropertyKey key, out Guid pValue);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HResult SetBufferValue([In] ref PropertyKey key, [In] byte[] pValue, [In] uint cbValue);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HResult GetBufferValue([In] ref PropertyKey key, [Out] IntPtr ppValue, out uint pcbValue);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HResult SetIPortableDeviceValuesValue([In] ref PropertyKey key, [In, MarshalAs(UnmanagedType.Interface)] ref IPortableDeviceValues pValue);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HResult GetIPortableDeviceValuesValue([In] ref PropertyKey key, [MarshalAs(UnmanagedType.Interface)] out IPortableDeviceValues ppValue);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HResult SetIPortableDevicePropVariantCollectionValue([In] ref PropertyKey key, [In, MarshalAs(UnmanagedType.Interface)] ref IPortableDevicePropVariantCollection pValue);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HResult GetIPortableDevicePropVariantCollectionValue([In] ref PropertyKey key, [MarshalAs(UnmanagedType.Interface)] out IPortableDevicePropVariantCollection ppValue);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HResult SetIPortableDeviceKeyCollectionValue([In] ref PropertyKey key, [In, MarshalAs(UnmanagedType.Interface)] ref IPortableDeviceKeyCollection pValue);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HResult GetIPortableDeviceKeyCollectionValue([In] ref PropertyKey key, [MarshalAs(UnmanagedType.Interface)] out IPortableDeviceKeyCollection ppValue);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HResult SetIPortableDeviceValuesCollectionValue([In] ref PropertyKey key, [In, MarshalAs(UnmanagedType.Interface)] ref IPortableDeviceValuesCollection pValue);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HResult GetIPortableDeviceValuesCollectionValue([In] ref PropertyKey key, [MarshalAs(UnmanagedType.Interface)] out IPortableDeviceValuesCollection ppValue);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HResult RemoveValue([In] ref PropertyKey key);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HResult CopyValuesFromPropertyStore([In, MarshalAs(UnmanagedType.Interface)] ref IPropertyStore pStore);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HResult CopyValuesToPropertyStore([In, MarshalAs(UnmanagedType.Interface)] ref IPropertyStore pStore);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HResult Clear();
    }
}
