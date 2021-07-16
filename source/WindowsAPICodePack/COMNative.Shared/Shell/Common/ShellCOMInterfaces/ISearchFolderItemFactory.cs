//Copyright (c) Microsoft Corporation.  All rights reserved.  Distributed under the Microsoft Public License (MS-PL)

using Microsoft.WindowsAPICodePack.PropertySystem;
using Microsoft.WindowsAPICodePack.Win32Native;

using System;
using System.Runtime.InteropServices;

namespace Microsoft.WindowsAPICodePack.COMNative.Shell
{
    [ComImport,
    Guid(NativeAPI.Guids.Shell.ISearchFolderItemFactory),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ISearchFolderItemFactory
    {
        [PreserveSig]
        HResult SetDisplayName([In, MarshalAs(UnmanagedType.LPWStr)] string pszDisplayName);

        [PreserveSig]
        HResult SetFolderTypeID([In] Guid ftid);

        [PreserveSig]
        HResult SetFolderLogicalViewMode([In] FolderLogicalViewMode flvm);

        [PreserveSig]
        HResult SetIconSize([In] int iIconSize);

        [PreserveSig]
        HResult SetVisibleColumns([In] uint cVisibleColumns, [In, MarshalAs(UnmanagedType.LPArray)] PropertyKey[] rgKey);

        [PreserveSig]
        HResult SetSortColumns([In] uint cSortColumns, [In, MarshalAs(UnmanagedType.LPArray)] SortColumn[] rgSortColumns);

        [PreserveSig]
        HResult SetGroupColumn([In] ref PropertyKey keyGroup);

        [PreserveSig]
        HResult SetStacks([In] uint cStackKeys, [In, MarshalAs(UnmanagedType.LPArray)] PropertyKey[] rgStackKeys);

        [PreserveSig]
        HResult SetScope([In, MarshalAs(UnmanagedType.Interface)] IShellItemArray ppv);

        [PreserveSig]
        HResult SetCondition([In] ICondition pCondition);

        [PreserveSig]
        int GetShellItem(ref Guid riid, [Out, MarshalAs(UnmanagedType.Interface)] out IShellItem ppv);

        [PreserveSig]
        HResult GetIDList([Out] IntPtr ppidl);
    }
}
