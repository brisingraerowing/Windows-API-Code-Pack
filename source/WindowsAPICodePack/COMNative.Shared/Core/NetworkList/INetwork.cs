//Copyright (c) Microsoft Corporation.  All rights reserved.  Distributed under the Microsoft Public License (MS-PL)

using Microsoft.WindowsAPICodePack.COMNative.NetworkList;

using System;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Microsoft.WindowsAPICodePack.COMNative.Net
{
    [ComImport,
    TypeLibType(0x1040),
    Guid(NativeAPI.Guids.Net.INetwork)]
    public interface INetwork
    {
        [return: MarshalAs(UnmanagedType.BStr)]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        string GetName();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void SetName([In, MarshalAs(UnmanagedType.BStr)] string szNetworkNewName);

        [return: MarshalAs(UnmanagedType.BStr)]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        string GetDescription();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void SetDescription([In, MarshalAs(UnmanagedType.BStr)] string szDescription);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        Guid GetNetworkId();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        DomainType GetDomainType();

        [return: MarshalAs(UnmanagedType.Interface)]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        IEnumerable GetNetworkConnections();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetTimeCreatedAndConnected(
            [Out, MarshalAs(UnmanagedType.U4)] out uint pdwLowDateTimeCreated,
            [Out, MarshalAs(UnmanagedType.U4)] out uint pdwHighDateTimeCreated,
            [Out, MarshalAs(UnmanagedType.U4)] out uint pdwLowDateTimeConnected,
            [Out, MarshalAs(UnmanagedType.U4)] out uint pdwHighDateTimeConnected);

        bool IsConnectedToInternet
        {
            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
            get;
        }

        bool IsConnected
        {
            [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
            get;
        }

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        ConnectivityStates GetConnectivity();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        NetworkCategory GetCategory();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void SetCategory([In] NetworkCategory NewCategory);
    }
}