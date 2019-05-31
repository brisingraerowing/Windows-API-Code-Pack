//Copyright (c) Microsoft Corporation.  All rights reserved.

using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using Microsoft.WindowsAPICodePack.Shell;
using Microsoft.WindowsAPICodePack.Win32Native;
using Microsoft.WindowsAPICodePack.Win32Native.Core;
using Microsoft.WindowsAPICodePack.Win32Native.Shell.PropertySystem;
using Microsoft.WindowsAPICodePack.Win32Native.Taskbar;
using MS.WindowsAPICodePack.Win32Native.Shell.PropertySystem;

namespace Microsoft.WindowsAPICodePack.Win32Native.Shell
{
    public enum SICHINTF
    {
        SICHINT_DISPLAY = 0x00000000,
        SICHINT_CANONICAL = 0x10000000,
        SICHINT_TEST_FILESYSPATH_IF_NOT_EQUAL = 0x20000000,
        SICHINT_ALLFIELDS = unchecked((int)0x80000000)
    }

    // Disable warning if a method declaration hides another inherited from a parent COM interface
    // To successfully import a COM interface, all inherited methods need to be declared again with 
    // the exception of those already declared in "IUnknown"
#pragma warning disable 108

    #region COM Interfaces

    [ComImport(),
    Guid(ShellIIDGuid.IModalWindow),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IModalWindow
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime),
        PreserveSig]
        int Show([In] IntPtr parent);
    }

    [ComImport,
    Guid(ShellIIDGuid.IShellItem),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IShellItem
    {
        // Not supported: IBindCtx.
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HResult BindToHandler(
            [In] IntPtr pbc,
            [In] ref Guid bhid,
            [In] ref Guid riid,
            [Out, MarshalAs(UnmanagedType.Interface)] out IShellFolder ppv);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetParent([MarshalAs(UnmanagedType.Interface)] out IShellItem ppsi);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HResult GetDisplayName(
            [In] ShellNativeMethods.ShellItemDesignNameOptions sigdnName,
            out IntPtr ppszName);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetAttributes([In] ShellNativeMethods.ShellFileGetAttributesOptions sfgaoMask, out ShellNativeMethods.ShellFileGetAttributesOptions psfgaoAttribs);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HResult Compare(
            [In, MarshalAs(UnmanagedType.Interface)] IShellItem psi,
            [In] SICHINTF hint,
            out int piOrder);
    }

    [ComImport,
    Guid(ShellIIDGuid.IShellItem2),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IShellItem2 : IShellItem
    {
        // Not supported: IBindCtx.
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HResult BindToHandler(
            [In] IntPtr pbc,
            [In] ref Guid bhid,
            [In] ref Guid riid,
            [Out, MarshalAs(UnmanagedType.Interface)] out IShellFolder ppv);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HResult GetParent([MarshalAs(UnmanagedType.Interface)] out IShellItem ppsi);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HResult GetDisplayName(
            [In] ShellNativeMethods.ShellItemDesignNameOptions sigdnName,
            [MarshalAs(UnmanagedType.LPWStr)] out string ppszName);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetAttributes([In] ShellNativeMethods.ShellFileGetAttributesOptions sfgaoMask, out ShellNativeMethods.ShellFileGetAttributesOptions psfgaoAttribs);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void Compare(
            [In, MarshalAs(UnmanagedType.Interface)] IShellItem psi,
            [In] uint hint,
            out int piOrder);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), PreserveSig]
        int GetPropertyStore(
            [In] ShellNativeMethods.GetPropertyStoreOptions Flags,
            [In] ref Guid riid,
            [Out, MarshalAs(UnmanagedType.Interface)] out IPropertyStore ppv);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetPropertyStoreWithCreateObject([In] ShellNativeMethods.GetPropertyStoreOptions Flags, [In, MarshalAs(UnmanagedType.IUnknown)] object punkCreateObject, [In] ref Guid riid, out IntPtr ppv);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetPropertyStoreForKeys([In] ref PropertyKey rgKeys, [In] uint cKeys, [In] ShellNativeMethods.GetPropertyStoreOptions Flags, [In] ref Guid riid, [Out, MarshalAs(UnmanagedType.IUnknown)] out IPropertyStore ppv);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetPropertyDescriptionList([In] ref PropertyKey keyType, [In] ref Guid riid, out IntPtr ppv);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HResult Update([In, MarshalAs(UnmanagedType.Interface)] IBindCtx pbc);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetProperty([In] ref PropertyKey key, [Out] PropVariant ppropvar);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetCLSID([In] ref PropertyKey key, out Guid pclsid);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetFileTime([In] ref PropertyKey key, out System.Runtime.InteropServices.ComTypes.FILETIME pft);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetInt32([In] ref PropertyKey key, out int pi);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HResult GetString([In] ref PropertyKey key, [MarshalAs(UnmanagedType.LPWStr)] out string ppsz);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetUInt32([In] ref PropertyKey key, out uint pui);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetUInt64([In] ref PropertyKey key, out ulong pull);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetBool([In] ref PropertyKey key, out int pf);
    }

    [ComImport,
    Guid(ShellIIDGuid.IShellItemArray),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IShellItemArray
    {
        // Not supported: IBindCtx.
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HResult BindToHandler(
            [In, MarshalAs(UnmanagedType.Interface)] IntPtr pbc,
            [In] ref Guid rbhid,
            [In] ref Guid riid,
            out IntPtr ppvOut);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HResult GetPropertyStore(
            [In] int Flags,
            [In] ref Guid riid,
            out IntPtr ppv);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HResult GetPropertyDescriptionList(
            [In] ref PropertyKey keyType,
            [In] ref Guid riid,
            out IntPtr ppv);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HResult GetAttributes(
            [In] ShellNativeMethods.ShellItemAttributeOptions dwAttribFlags,
            [In] ShellNativeMethods.ShellFileGetAttributesOptions sfgaoMask,
            out ShellNativeMethods.ShellFileGetAttributesOptions psfgaoAttribs);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HResult GetCount(out uint pdwNumItems);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HResult GetItemAt(
            [In] uint dwIndex,
            [MarshalAs(UnmanagedType.Interface)] out IShellItem ppsi);

        // Not supported: IEnumShellItems (will use GetCount and GetItemAt instead).
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HResult EnumItems([MarshalAs(UnmanagedType.Interface)] out IntPtr ppenumShellItems);
    }

    [ComImport,
    Guid(ShellIIDGuid.IShellLibrary),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IShellLibrary
    {
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HResult LoadLibraryFromItem(
            [In, MarshalAs(UnmanagedType.Interface)] IShellItem library,
            [In] AccessModes grfMode);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void LoadLibraryFromKnownFolder(
            [In] ref Guid knownfidLibrary,
            [In] AccessModes grfMode);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void AddFolder([In, MarshalAs(UnmanagedType.Interface)] IShellItem location);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void RemoveFolder([In, MarshalAs(UnmanagedType.Interface)] IShellItem location);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HResult GetFolders(
            [In] ShellNativeMethods.LibraryFolderFilter lff,
            [In] ref Guid riid,
            [MarshalAs(UnmanagedType.Interface)] out IShellItemArray ppv);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void ResolveFolder(
            [In, MarshalAs(UnmanagedType.Interface)] IShellItem folderToResolve,
            [In] uint timeout,
            [In] ref Guid riid,
            [MarshalAs(UnmanagedType.Interface)] out IShellItem ppv);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetDefaultSaveFolder(
            [In] ShellNativeMethods.DefaultSaveFolderType dsft,
            [In] ref Guid riid,
            [MarshalAs(UnmanagedType.Interface)] out IShellItem ppv);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void SetDefaultSaveFolder(
            [In] ShellNativeMethods.DefaultSaveFolderType dsft,
            [In, MarshalAs(UnmanagedType.Interface)] IShellItem si);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetOptions(
            out ShellNativeMethods.LibraryOptions lofOptions);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void SetOptions(
            [In] ShellNativeMethods.LibraryOptions lofMask,
            [In] ShellNativeMethods.LibraryOptions lofOptions);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetFolderType(out Guid ftid);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void SetFolderType([In] ref Guid ftid);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetIcon([MarshalAs(UnmanagedType.LPWStr)] out string icon);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void SetIcon([In, MarshalAs(UnmanagedType.LPWStr)] string icon);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void Commit();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void Save(
            [In, MarshalAs(UnmanagedType.Interface)] IShellItem folderToSaveIn,
            [In, MarshalAs(UnmanagedType.LPWStr)] string libraryName,
            [In] ShellNativeMethods.LibrarySaveOptions lsf,
            [MarshalAs(UnmanagedType.Interface)] out IShellItem2 savedTo);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void SaveInKnownFolder(
            [In] ref Guid kfidToSaveIn,
            [In, MarshalAs(UnmanagedType.LPWStr)] string libraryName,
            [In] ShellNativeMethods.LibrarySaveOptions lsf,
            [MarshalAs(UnmanagedType.Interface)] out IShellItem2 savedTo);
    };

    [ComImport()]
    [Guid("bcc18b79-ba16-442f-80c4-8a59c30c463b")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    interface IShellItemImageFactory
    {
        [PreserveSig]
        HResult GetImage(
        [In, MarshalAs(UnmanagedType.Struct)] CoreNativeMethods.Size size,
        [In] ShellNativeMethods.SIIGBF flags,
        [Out] out IntPtr phbm);
    }

    [ComImport,
    Guid(ShellIIDGuid.IThumbnailCache),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    interface IThumbnailCache
    {
        void GetThumbnail([In] IShellItem pShellItem,
        [In] uint cxyRequestedThumbSize,
        [In] ShellNativeMethods.ThumbnailOptions flags,
        [Out] out ISharedBitmap ppvThumb,
        [Out] out ShellNativeMethods.ThumbnailCacheOptions pOutFlags,
        [Out] ShellNativeMethods.ThumbnailId pThumbnailID);

        void GetThumbnailByID([In] ShellNativeMethods.ThumbnailId thumbnailID,
        [In] uint cxyRequestedThumbSize,
        [Out] out ISharedBitmap ppvThumb,
        [Out] out ShellNativeMethods.ThumbnailCacheOptions pOutFlags);
    }

    [ComImport,
    Guid(ShellIIDGuid.ISharedBitmap),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    interface ISharedBitmap
    {
        void GetSharedBitmap([Out] out IntPtr phbm);
        void GetSize([Out] out CoreNativeMethods.Size pSize);
        void GetFormat([Out] out ThumbnailAlphaType pat);
        void InitializeBitmap([In] IntPtr hbm, [In] ThumbnailAlphaType wtsAT);
        void Detach([Out] out IntPtr phbm);
    }
    [ComImport,
    Guid(ShellIIDGuid.IShellFolder),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown),
    ComConversionLoss]
    public interface IShellFolder
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void ParseDisplayName(IntPtr hwnd, [In, MarshalAs(UnmanagedType.Interface)] IBindCtx pbc, [In, MarshalAs(UnmanagedType.LPWStr)] string pszDisplayName, [In, Out] ref uint pchEaten, [Out] IntPtr ppidl, [In, Out] ref uint pdwAttributes);
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HResult EnumObjects([In] IntPtr hwnd, [In] ShellNativeMethods.ShellFolderEnumerationOptions grfFlags, [MarshalAs(UnmanagedType.Interface)] out IEnumIDList ppenumIDList);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HResult BindToObject([In] IntPtr pidl, /*[In, MarshalAs(UnmanagedType.Interface)] IBindCtx*/ IntPtr pbc, [In] ref Guid riid, [Out, MarshalAs(UnmanagedType.Interface)] out IShellFolder ppv);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void BindToStorage([In] ref IntPtr pidl, [In, MarshalAs(UnmanagedType.Interface)] IBindCtx pbc, [In] ref Guid riid, out IntPtr ppv);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void CompareIDs([In] IntPtr lParam, [In] ref IntPtr pidl1, [In] ref IntPtr pidl2);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void CreateViewObject([In] IntPtr hwndOwner, [In] ref Guid riid, out IntPtr ppv);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetAttributesOf([In] uint cidl, [In] IntPtr apidl, [In, Out] ref uint rgfInOut);


        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetUIObjectOf([In] IntPtr hwndOwner, [In] uint cidl, [In] IntPtr apidl, [In] ref Guid riid, [In, Out] ref uint rgfReserved, out IntPtr ppv);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetDisplayNameOf([In] ref IntPtr pidl, [In] uint uFlags, out IntPtr pName);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void SetNameOf([In] IntPtr hwnd, [In] ref IntPtr pidl, [In, MarshalAs(UnmanagedType.LPWStr)] string pszName, [In] uint uFlags, [Out] IntPtr ppidlOut);
    }

    [ComImport,
    Guid(ShellIIDGuid.IShellFolder2),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown),
    ComConversionLoss]
    public interface IShellFolder2 : IShellFolder
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void ParseDisplayName([In] IntPtr hwnd, [In, MarshalAs(UnmanagedType.Interface)] IBindCtx pbc, [In, MarshalAs(UnmanagedType.LPWStr)] string pszDisplayName, [In, Out] ref uint pchEaten, [Out] IntPtr ppidl, [In, Out] ref uint pdwAttributes);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void EnumObjects([In] IntPtr hwnd, [In] ShellNativeMethods.ShellFolderEnumerationOptions grfFlags, [MarshalAs(UnmanagedType.Interface)] out IEnumIDList ppenumIDList);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void BindToObject([In] IntPtr pidl, /*[In, MarshalAs(UnmanagedType.Interface)] IBindCtx*/ IntPtr pbc, [In] ref Guid riid, [Out, MarshalAs(UnmanagedType.Interface)] out IShellFolder ppv);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void BindToStorage([In] ref IntPtr pidl, [In, MarshalAs(UnmanagedType.Interface)] IBindCtx pbc, [In] ref Guid riid, out IntPtr ppv);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void CompareIDs([In] IntPtr lParam, [In] ref IntPtr pidl1, [In] ref IntPtr pidl2);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void CreateViewObject([In] IntPtr hwndOwner, [In] ref Guid riid, out IntPtr ppv);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetAttributesOf([In] uint cidl, [In] IntPtr apidl, [In, Out] ref uint rgfInOut);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetUIObjectOf([In] IntPtr hwndOwner, [In] uint cidl, [In] IntPtr apidl, [In] ref Guid riid, [In, Out] ref uint rgfReserved, out IntPtr ppv);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetDisplayNameOf([In] ref IntPtr pidl, [In] uint uFlags, out IntPtr pName);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void SetNameOf([In] IntPtr hwnd, [In] ref IntPtr pidl, [In, MarshalAs(UnmanagedType.LPWStr)] string pszName, [In] uint uFlags, [Out] IntPtr ppidlOut);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetDefaultSearchGUID(out Guid pguid);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void EnumSearches([Out] out IntPtr ppenum);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetDefaultColumn([In] uint dwRes, out uint pSort, out uint pDisplay);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetDefaultColumnState([In] uint iColumn, out uint pcsFlags);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetDetailsEx([In] ref IntPtr pidl, [In] ref PropertyKey pscid, [MarshalAs(UnmanagedType.Struct)] out object pv);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetDetailsOf([In] ref IntPtr pidl, [In] uint iColumn, out IntPtr psd);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void MapColumnToSCID([In] uint iColumn, out PropertyKey pscid);
    }

    [ComImport,
    Guid(ShellIIDGuid.IEnumIDList),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IEnumIDList
    {
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HResult Next(uint celt, out IntPtr rgelt, out uint pceltFetched);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HResult Skip([In] uint celt);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HResult Reset();

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HResult Clone([MarshalAs(UnmanagedType.Interface)] out IEnumIDList ppenum);
    }

    [ComImport,
    Guid(ShellIIDGuid.IShellLinkW),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IShellLinkW
    {
        void GetPath(
            [Out(), MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszFile,
            int cchMaxPath,
            //ref _WIN32_FIND_DATAW pfd,
            IntPtr pfd,
            uint fFlags);
        void GetIDList(out IntPtr ppidl);
        void SetIDList(IntPtr pidl);
        void GetDescription(
            [Out(), MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszFile,
            int cchMaxName);
        void SetDescription(
            [MarshalAs(UnmanagedType.LPWStr)] string pszName);
        void GetWorkingDirectory(
            [Out(), MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszDir,
            int cchMaxPath
            );
        void SetWorkingDirectory(
            [MarshalAs(UnmanagedType.LPWStr)] string pszDir);
        void GetArguments(
            [Out(), MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszArgs,
            int cchMaxPath);
        void SetArguments(
            [MarshalAs(UnmanagedType.LPWStr)] string pszArgs);
        void GetHotKey(out short wHotKey);
        void SetHotKey(short wHotKey);
        void GetShowCmd(out uint iShowCmd);
        void SetShowCmd(uint iShowCmd);
        void GetIconLocation(
            [Out(), MarshalAs(UnmanagedType.LPWStr)] out StringBuilder pszIconPath,
            int cchIconPath,
            out int iIcon);
        void SetIconLocation(
            [MarshalAs(UnmanagedType.LPWStr)] string pszIconPath,
            int iIcon);
        void SetRelativePath(
            [MarshalAs(UnmanagedType.LPWStr)] string pszPathRel,
            uint dwReserved);
        void Resolve(IntPtr hwnd, uint fFlags);
        void SetPath(
            [MarshalAs(UnmanagedType.LPWStr)] string pszFile);
    }

    [ComImport,
    Guid(ShellIIDGuid.CShellLink),
    ClassInterface(ClassInterfaceType.None)]
    public class CShellLink { }

    /// <summary>
    /// Provides the managed definition of the IPersistStream interface, with functionality
    ///    from IPersist.
    /// </summary>
    [ComImport]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid(ShellIIDGuid.IPersistStream)]
    public interface IPersistStream
    {
        /// <summary>
        /// Retrieves the class identifier (CLSID) of an object.
        /// </summary>
        /// <param name="pClassID">When this method returns, contains a reference to the CLSID. This parameter
        ///    is passed uninitialized.</param>
        [PreserveSig]
        void GetClassID(out Guid pClassID);

        /// <summary>
        /// Checks an object for changes since it was last saved to its current file.
        /// </summary>
        /// <returns>S_OK if the file has changed since it was last saved; S_FALSE if the file
        ///    has not changed since it was last saved.</returns>
        [PreserveSig]
        HResult IsDirty();

        [PreserveSig]
        HResult Load([In, MarshalAs(UnmanagedType.Interface)] IStream stm);

        [PreserveSig]
        HResult Save([In, MarshalAs(UnmanagedType.Interface)] IStream stm, bool fRemember);

        [PreserveSig]
        HResult GetSizeMax(out ulong cbSize);
    }

    [ComImport(),
    Guid(ShellIIDGuid.ICondition),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICondition : IPersistStream
    {
        // Summary:
        //     Retrieves the class identifier (CLSID) of an object.
        //
        // Parameters:
        //   pClassID:
        //     When this method returns, contains a reference to the CLSID. This parameter
        //     is passed uninitialized.
        [PreserveSig]
        void GetClassID(out Guid pClassID);
        //
        // Summary:
        //     Checks an object for changes since it was last saved to its current file.
        //
        // Returns:
        //     S_OK if the file has changed since it was last saved; S_FALSE if the file
        //     has not changed since it was last saved.
        [PreserveSig]
        HResult IsDirty();

        [PreserveSig]
        HResult Load([In, MarshalAs(UnmanagedType.Interface)] IStream stm);

        [PreserveSig]
        HResult Save([In, MarshalAs(UnmanagedType.Interface)] IStream stm, bool fRemember);

        [PreserveSig]
        HResult GetSizeMax(out ulong cbSize);

        // For any node, return what kind of node it is.
        [PreserveSig]
        HResult GetConditionType([Out()] out SearchConditionType pNodeType);

        // riid must be IID_IEnumUnknown, IID_IEnumVARIANT or IID_IObjectArray, or in the case of a negation node IID_ICondition.
        // If this is a leaf node, E_FAIL will be returned.
        // If this is a negation node, then if riid is IID_ICondition, *ppv will be set to a single ICondition, otherwise an enumeration of one.
        // If this is a conjunction or a disjunction, *ppv will be set to an enumeration of the subconditions.
        [PreserveSig]
        HResult GetSubConditions([In] ref Guid riid, [Out, MarshalAs(UnmanagedType.Interface)] out object ppv);

        // If this is not a leaf node, E_FAIL will be returned.
        // Retrieve the property name, operation and value from the leaf node.
        // Any one of ppszPropertyName, pcop and ppropvar may be NULL.
        [PreserveSig]
        HResult GetComparisonInfo(
            [Out, MarshalAs(UnmanagedType.LPWStr)] out string ppszPropertyName,
            [Out] out SearchConditionOperation pcop,
            [Out] PropVariant ppropvar);

        // If this is not a leaf node, E_FAIL will be returned.
        // *ppszValueTypeName will be set to the semantic type of the value, or to NULL if this is not meaningful.
        [PreserveSig]
        HResult GetValueType([Out, MarshalAs(UnmanagedType.LPWStr)] out string ppszValueTypeName);

        // If this is not a leaf node, E_FAIL will be returned.
        // If the value of the leaf node is VT_EMPTY, *ppszNormalization will be set to an empty string.
        // If the value is a string (VT_LPWSTR, VT_BSTR or VT_LPSTR), then *ppszNormalization will be set to a
        // character-normalized form of the value.
        // Otherwise, *ppszNormalization will be set to some (character-normalized) string representation of the value.
        [PreserveSig]
        HResult GetValueNormalization([Out, MarshalAs(UnmanagedType.LPWStr)] out string ppszNormalization);

        // Return information about what parts of the input produced the property, the operation and the value.
        // Any one of ppPropertyTerm, ppOperationTerm and ppValueTerm may be NULL.
        // For a leaf node returned by the parser, the position information of each IRichChunk identifies the tokens that
        // contributed the property/operation/value, the string value is the corresponding part of the input string, and
        // the PROPVARIANT is VT_EMPTY.
        [PreserveSig]
        HResult GetInputTerms([Out] out IRichChunk ppPropertyTerm, [Out] out IRichChunk ppOperationTerm, [Out] out IRichChunk ppValueTerm);

        // Make a deep copy of this ICondition.
        [PreserveSig]
        HResult Clone([Out()] out ICondition ppc);
    };

    [ComImport,
    Guid(ShellIIDGuid.IRichChunk),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IRichChunk
    {
        // The position *pFirstPos is zero-based.
        // Any one of pFirstPos, pLength, ppsz and pValue may be NULL.
        [PreserveSig]
        HResult GetData(/*[out, annotation("__out_opt")] ULONG* pFirstPos, [out, annotation("__out_opt")] ULONG* pLength, [out, annotation("__deref_opt_out_opt")] LPWSTR* ppsz, [out, annotation("__out_opt")] PROPVARIANT* pValue*/);
    }

    [ComImport]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid(ShellIIDGuid.IEnumUnknown)]
    public interface IEnumUnknown
    {
        [PreserveSig]
        HResult Next(uint requestedNumber, ref IntPtr buffer, ref uint fetchedNumber);
        [PreserveSig]
        HResult Skip(uint number);
        [PreserveSig]
        HResult Reset();
        [PreserveSig]
        HResult Clone(out IEnumUnknown result);
    }


    [ComImport,
    Guid(ShellIIDGuid.IConditionFactory),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IConditionFactory
    {
        [PreserveSig]
        HResult MakeNot([In] ICondition pcSub, [In] bool fSimplify, [Out] out ICondition ppcResult);

        [PreserveSig]
        HResult MakeAndOr([In] SearchConditionType ct, [In] IEnumUnknown peuSubs, [In] bool fSimplify, [Out] out ICondition ppcResult);

        [PreserveSig]
        HResult MakeLeaf(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pszPropertyName,
            [In] SearchConditionOperation cop,
            [In, MarshalAs(UnmanagedType.LPWStr)] string pszValueType,
            [In] PropVariant ppropvar,
            IRichChunk richChunk1,
            IRichChunk richChunk2,
            IRichChunk richChunk3,
            [In] bool fExpand,
            [Out] out ICondition ppcResult);

        [PreserveSig]
        HResult Resolve(/*[In] ICondition pc, [In] STRUCTURED_QUERY_RESOLVE_OPTION sqro, [In] ref SYSTEMTIME pstReferenceTime, [Out] out ICondition ppcResolved*/);

    };

    [ComImport,
    Guid(ShellIIDGuid.IConditionFactory),
    CoClass(typeof(ConditionFactoryCoClass))]
    public interface INativeConditionFactory : IConditionFactory
    {
    }

    [ComImport,
    ClassInterface(ClassInterfaceType.None),
    TypeLibType(TypeLibTypeFlags.FCanCreate),
    Guid(ShellCLSIDGuid.ConditionFactory)]
    public class ConditionFactoryCoClass
    {
    }



    [ComImport,
    Guid(ShellIIDGuid.ISearchFolderItemFactory),
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
    };

    [ComImport,
    Guid(ShellIIDGuid.ISearchFolderItemFactory),
    CoClass(typeof(SearchFolderItemFactoryCoClass))]
    public interface INativeSearchFolderItemFactory : ISearchFolderItemFactory
    {
    }

    [ComImport,
    ClassInterface(ClassInterfaceType.None),
    TypeLibType(TypeLibTypeFlags.FCanCreate),
    Guid(ShellCLSIDGuid.SearchFolderItemFactory)]
    public class SearchFolderItemFactoryCoClass
    {
    }

    [ComImport,
    Guid(ShellIIDGuid.IQuerySolution),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IQuerySolution : IConditionFactory
    {
        [PreserveSig]
        HResult MakeNot([In] ICondition pcSub, [In] bool fSimplify, [Out] out ICondition ppcResult);

        [PreserveSig]
        HResult MakeAndOr([In] SearchConditionType ct, [In] IEnumUnknown peuSubs, [In] bool fSimplify, [Out] out ICondition ppcResult);

        [PreserveSig]
        HResult MakeLeaf(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pszPropertyName,
            [In] SearchConditionOperation cop,
            [In, MarshalAs(UnmanagedType.LPWStr)] string pszValueType,
            [In] PropVariant ppropvar,
            IRichChunk richChunk1,
            IRichChunk richChunk2,
            IRichChunk richChunk3,
            [In] bool fExpand,
            [Out] out ICondition ppcResult);

        [PreserveSig]
        HResult Resolve(/*[In] ICondition pc, [In] int sqro, [In] ref SYSTEMTIME pstReferenceTime, [Out] out ICondition ppcResolved*/);

        // Retrieve the condition tree and the "main type" of the solution.
        // ppQueryNode and ppMainType may be NULL.
        [PreserveSig]
        HResult GetQuery([Out, MarshalAs(UnmanagedType.Interface)] out ICondition ppQueryNode, [Out, MarshalAs(UnmanagedType.Interface)] out IEntity ppMainType);

        // Identify parts of the input string not accounted for.
        // Each parse error is represented by an IRichChunk where the position information
        // reflect token counts, the string is NULL and the value is a VT_I4
        // where lVal is from the ParseErrorType enumeration. The valid
        // values for riid are IID_IEnumUnknown and IID_IEnumVARIANT.
        [PreserveSig]
        HResult GetErrors([In] ref Guid riid, [Out] out /* void** */ IntPtr ppParseErrors);

        // Report the query string, how it was tokenized and what LCID and word breaker were used (for recognizing keywords).
        // ppszInputString, ppTokens, pLocale and ppWordBreaker may be NULL.
        [PreserveSig]
        HResult GetLexicalData([MarshalAs(UnmanagedType.LPWStr)] out string ppszInputString, [Out] /* ITokenCollection** */ out IntPtr ppTokens, [Out] out uint plcid, [Out] /* IUnknown** */ out IntPtr ppWordBreaker);
    }

    [ComImport,
    Guid(ShellIIDGuid.IQueryParser),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IQueryParser
    {
        // Parse parses an input string, producing a query solution.
        // pCustomProperties should be an enumeration of IRichChunk objects, one for each custom property
        // the application has recognized. pCustomProperties may be NULL, equivalent to an empty enumeration.
        // For each IRichChunk, the position information identifies the character span of the custom property,
        // the string value should be the name of an actual property, and the PROPVARIANT is completely ignored.
        [PreserveSig]
        HResult Parse([In, MarshalAs(UnmanagedType.LPWStr)] string pszInputString, [In] IEnumUnknown pCustomProperties, [Out] out IQuerySolution ppSolution);

        // Set a single option. See STRUCTURED_QUERY_SINGLE_OPTION above.
        [PreserveSig]
        HResult SetOption([In] StructuredQuerySingleOption option, [In] PropVariant pOptionValue);

        [PreserveSig]
        HResult GetOption([In] StructuredQuerySingleOption option, [Out] PropVariant pOptionValue);

        // Set a multi option. See STRUCTURED_QUERY_MULTIOPTION above.
        [PreserveSig]
        HResult SetMultiOption([In] StructuredQueryMultipleOption option, [In, MarshalAs(UnmanagedType.LPWStr)] string pszOptionKey, [In] PropVariant pOptionValue);

        // Get a schema provider for browsing the currently loaded schema.
        [PreserveSig]
        HResult GetSchemaProvider([Out] out /*ISchemaProvider*/ IntPtr ppSchemaProvider);

        // Restate a condition as a query string according to the currently selected syntax.
        // The parameter fUseEnglish is reserved for future use; must be FALSE.
        [PreserveSig]
        HResult RestateToString([In] ICondition pCondition, [In] bool fUseEnglish, [Out, MarshalAs(UnmanagedType.LPWStr)] out string ppszQueryString);

        // Parse a condition for a given property. It can be anything that would go after 'PROPERTY:' in an AQS expession.
        [PreserveSig]
        HResult ParsePropertyValue([In, MarshalAs(UnmanagedType.LPWStr)] string pszPropertyName, [In, MarshalAs(UnmanagedType.LPWStr)] string pszInputString, [Out] out IQuerySolution ppSolution);

        // Restate a condition for a given property. If the condition contains a leaf with any other property name, or no property name at all,
        // E_INVALIDARG will be returned.
        [PreserveSig]
        HResult RestatePropertyValueToString([In] ICondition pCondition, [In] bool fUseEnglish, [Out, MarshalAs(UnmanagedType.LPWStr)] out string ppszPropertyName, [Out, MarshalAs(UnmanagedType.LPWStr)] out string ppszQueryString);
    }

    [ComImport,
    Guid(ShellIIDGuid.IQueryParserManager),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IQueryParserManager
    {
        // Create a query parser loaded with the schema for a certain catalog localize to a certain language, and initialized with
        // standard defaults. One valid value for riid is IID_IQueryParser.
        [PreserveSig]
        HResult CreateLoadedParser([In, MarshalAs(UnmanagedType.LPWStr)] string pszCatalog, [In] ushort langidForKeywords, [In] ref Guid riid, [Out] out IQueryParser ppQueryParser);

        // In addition to setting AQS/NQS and automatic wildcard for the given query parser, this sets up standard named entity handlers and
        // sets the keyboard locale as locale for word breaking.
        [PreserveSig]
        HResult InitializeOptions([In] bool fUnderstandNQS, [In] bool fAutoWildCard, [In] IQueryParser pQueryParser);

        // Change one of the settings for the query parser manager, such as the name of the schema binary, or the location of the localized and unlocalized
        // schema binaries. By default, the settings point to the schema binaries used by Windows Shell.
        [PreserveSig]
        HResult SetOption([In] QueryParserManagerOption option, [In] PropVariant pOptionValue);

    };

    [ComImport,
    Guid(ShellIIDGuid.IQueryParserManager),
    CoClass(typeof(QueryParserManagerCoClass))]
    public interface INativeQueryParserManager : IQueryParserManager
    {
    }

    [ComImport,
    ClassInterface(ClassInterfaceType.None),
    TypeLibType(TypeLibTypeFlags.FCanCreate),
    Guid(ShellCLSIDGuid.QueryParserManager)]
    public class QueryParserManagerCoClass
    {
    }

    [ComImport,
    Guid(ShellIIDGuid.IEntity),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IEntity
    {
        // TODO
    }

    // todo: add a class to encapsulate this interface into the 'Shell' project and check, on the method calls, if all the enum params do are supported by the current version of the OS.

    [ComImport,
       Guid(ShellIIDGuid.IFileOperation),
       InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IFileOperation
    {

        /// <summary>
        /// Enables a handler to provide status and error information for all operations.
        /// </summary>
        /// <param name="pfops">An <see cref="IFileOperationProgressSink"/> object to be used for progress status and error notifications.</param>
        /// <param name="pdwCookie">When this method returns, this parameter points to a returned token that uniquely identifies this connection. The calling application uses this token later to delete the connection by passing it to <see cref="Unadvise"/>. If the call to <see cref="Advise"/> fails, this value is meaningless.</param>
        /// <returns>If this method succeeds, it returns <see cref="HResult.Ok"/>. Otherwise, it returns an <see cref="HResult"/> error code.</returns>
        /// <remarks>Several individual methods have the ability to declare their own progress sinks, which are redundant to the one set here. They are used when you only want to be given progress and error information for a specific operation.</remarks>
        HResult Advise(IFileOperationProgressSink pfops, out uint pdwCookie);

        /// <summary>
        /// Terminates an advisory connection previously established through <see cref="Advise"/>.
        /// </summary>
        /// <param name="dwCookie">The connection token that identifies the connection to delete. This value was originally retrieved by <see cref="Advise"/> when the connection was made.</param>
        /// <returns>Any value other than those listed here indicate a failure.
        /// | Return code              | Description                                                  |
        /// |--------------------------+--------------------------------------------------------------|
        /// | <see cref="HResult.Ok"/> | The connection was terminated successfully.                  |
        /// | CONNECT_E_NOCONNECTION   | The value in dwCookie does not represent a valid connection. |</returns>
        HResult Unadvise(uint dwCookie);

        /// <summary>
        /// Sets parameters for the current operation.
        /// </summary>
        /// <param name="dwOperationFlags">Flags that control the file operation. FOF flags are defined in Shellapi.h and FOFX flags are defined in Shobjidl.h. Note : If this method is not called, the default value used by the operation is <see cref=" ShellOperationFlags.FOF_ALLOWUNDO"/> | <see cref="ShellOperationFlags.FOF_NOCONFIRMMKDIR"/>.</param>
        /// <returns>If this method succeeds, it returns <see cref="HResult.Ok"/>. Otherwise, it returns an <see cref="HResult"/> error code.</returns>
        /// <remarks>Set these flags before you call <see cref="PerformOperations"/> to define the parameters for whatever operations are being performed, such as copy, delete, or rename.</remarks>
        HResult SetOperationFlags(ShellOperationFlags dwOperationFlags);

        /// <summary>
        /// Not implemented.
        /// </summary>
        /// <param name="pszMessage">The window title.</param>
        /// <returns>If this method succeeds, it returns <see cref="HResult.Ok"/>. Otherwise, it returns an <see cref="HResult"/> error code.</returns>
        HResult SetProgressMessage([MarshalAs(UnmanagedType.LPWStr)] string pszMessage);

        /// <summary>
        /// Specifies a dialog box used to display the progress of the operation.
        /// </summary>
        /// <param name="popd">An <see cref="IOperationsProgressDialog"/> object that represents the dialog box.</param>
        /// <returns>If this method succeeds, it returns <see cref="HResult.Ok"/>. Otherwise, it returns an <see cref="HResult"/> error code.</returns>
        HResult SetProgressDialog(IOperationsProgressDialog popd);

        /// <summary>
        /// Declares a set of properties and values to be set on an item or items.
        /// </summary>
        /// <param name="pproparray">An <see cref="IPropertyChangeArray"/>, which accesses a collection of <see cref="IPropertyChange"/> objects that specify the properties to be set and their new values.</param>
        /// <returns>If this method succeeds, it returns <see cref="HResult.Ok"/>. Otherwise, it returns an <see cref="HResult"/> error code.</returns>
        /// <remarks>This method does not set the new property values, it merely declares them. To set property values on an item or a group of items, you must make at least the sequence of calls detailed here:
        /// <ol><li>Call <see cref="SetProperties"/> to declare the specific properties to be set and their new values.</li>
        /// <li>Call <see cref="ApplyPropertiesToItem"/> or <see cref="ApplyPropertiesToItems"/> to declare the item or items whose properties are to be set.</li>
        /// <li>Call <see cref="PerformOperations"/> to apply the properties to the item or items.</li></ol></remarks>
        HResult SetProperties(IPropertyChangeArray pproparray);

        /// <summary>
        /// Sets the parent or owner window for progress and dialog windows.
        /// </summary>
        /// <param name="hwndOwner">A handle to the owner window of the operation. This window will receive error messages.</param>
        /// <returns>If this method succeeds, it returns <see cref="HResult.Ok"/>. Otherwise, it returns an <see cref="HResult"/> error code.</returns>
        HResult SetOwnerWindow(IntPtr hwndOwner);

        /// <summary>
        /// Declares a single item whose property values are to be set.
        /// </summary>
        /// <param name="psiItem">Pointer to the item to receive the new property values.</param>
        /// <returns>If this method succeeds, it returns <see cref="HResult.Ok"/>. Otherwise, it returns an <see cref="HResult"/> error code.</returns>
        /// <remarks>This method does not apply the properties to the item, it merely declares the item. To set property values on an item, you must make at least the sequence of calls detailed here:
        /// <ol><li>Call <see cref="SetProperties"/> to declare the specific properties to be set and their new values.</li>
        /// <li>Call <see cref="ApplyPropertiesToItem"/> to declare the item whose properties are to be set.</li>
        /// <li>Call <see cref="PerformOperations"/> to apply the properties to the item.</li></ol></remarks>
        HResult ApplyPropertiesToItem(IShellItem psiItem);

        /// <summary>
        /// Declares a set of items for which to apply a common set of property values.
        /// </summary>
        /// <param name="punkItems">Pointer to the IUnknown of the <see cref="IShellItemArray"/>, <see cref="IDataObject"/>, or <see cref="IEnumShellItems"/> object which represents the group of items. You can also point to an <see cref="IPersistIDList"/> object to represent a single item, effectively accomplishing the same function as <see cref="ApplyPropertiesToItem"/>.</param>
        /// <returns>If this method succeeds, it returns S_OK. Otherwise, it returns an <see cref="HResult"/> error code.</returns>
        /// <remarks>This method does not apply the properties to the items, it merely declares the items. To set property values on a group of items, you must make at least the sequence of calls detailed here:
        /// <ol><li>Call <see cref="SetProperties"/> to declare the specific properties to be set and their new values.</li>
        /// <li>Call <see cref="ApplyPropertiesToItems"/> to declare the items whose property values are to be set.</li>
        /// <li>Call <see cref="PerformOperations"/> to apply the properties to the items.</li></ol></remarks>
        HResult ApplyPropertiesToItems([MarshalAs(UnmanagedType.Interface)] object punkItems);

        /// <summary>
        /// Declares a single item that is to be given a new display name.
        /// </summary>
        /// <param name="psiItem">Pointer to an <see cref="IShellItem"/> that specifies the source item.</param>
        /// <param name="pszNewName">Pointer to the new <a href="https://msdn.microsoft.com/9b159be9-3797-4c8b-90f8-9d3b3a3afb71">display name</a> of the item. This is a null-terminated, Unicode string.</param>
        /// <param name="pfopsItem">Pointer to an <see cref="IFileOperationProgressSink"/> object to be used for status and failure notifications. If you call <see cref="Advise"/> for the overall operation, progress status and error notifications for the rename operation are included there, so set this parameter to <see langword="null"/>.</param>
        /// <returns>If this method succeeds, it returns <see cref="HResult.Ok"/>. Otherwise, it returns an <see cref="HResult"/> error code.</returns>
        /// <remarks>This method does not rename the item, it merely declares the item to be renamed. To rename an object, you must make at least the sequence of calls detailed here:
        /// <ol><li>Call <see cref="RenameItem"/> to declare the new name.</li>
        /// <li>Call <see cref="PerformOperations"/> to begin the rename operation.</li></ol></remarks>
        HResult RenameItem(IShellItem psiItem, [MarshalAs(UnmanagedType.LPWStr)] string pszNewName, [MarshalAs(UnmanagedType.LPWStr)] IFileOperationProgressSink pfopsItem);

        /// <summary>
        /// Declares a set of items that are to be given a new display name. All items are given the same name.
        /// </summary>
        /// <param name="pUnkItems">Pointer to the <see cref="UnmanagedType.IUnknown"/> of the <see cref="IShellItemArray"/>, <see cref="IDataObject"/>, or <see cref="IEnumShellItems"/> object which represents the group of items to be renamed. You can also point to an <see cref="IPersistIDList"/> object to represent a single item, effectively accomplishing the same function as <see cref="RenameItem"/>.</param>
        /// <param name="pszNewName">Pointer to the new display name of the items. This is a null-terminated, Unicode string.</param>
        /// <returns>If this method succeeds, it returns <see cref="HResult.Ok"/>. Otherwise, it returns an <see cref="HResult"/> error code.</returns>
        /// <remarks><para>If more than one of the items in the collection at pUnkItems is in the same folder, the renamed files are appended with a number in parentheses to differentiate them, for instance newfile(1).txt, newfile(2).txt, and newfile(3).txt.</para>
        /// <para>This method does not rename the items, it merely declares the items to be renamed.To rename a group of objects, you must make at least the sequence of calls detailed here:</para>
        /// <ol><li>Call <see cref="RenameItems"/> to declare the source files or folders and the new name.</li>
        /// <li>Call <see cref="PerformOperations"/> to begin the rename operation.</li></ol></remarks>
        HResult RenameItems([MarshalAs(UnmanagedType.Interface)] object pUnkItems, [MarshalAs(UnmanagedType.LPWStr)] string pszNewName);

        /// <summary>
        /// Declares a single item that is to be moved to a specified destination.
        /// </summary>
        /// <param name="psiItem">Pointer to an <see cref="IShellItem"/> that specifies the source item.</param>
        /// <param name="psiDestinationFolder">Pointer to an <see cref="IShellItem"/> that specifies the destination folder to contain the moved item.</param>
        /// <param name="pszNewName">Pointer to a new name for the item in its new location. This is a null-terminated Unicode string and can be <see langword="null"/>. If <see langword="null"/>, the name of the destination item is the same as the source.</param>
        /// <param name="pfopsItem">Pointer to an <see cref="IFileOperationProgressSink"/> object to be used for progress status and error notifications for this specific move operation. If you call <see cref="Advise"/> for the overall operation, progress status and error notifications for the move operation are included there, so set this parameter to <see langword="null"/>.</param>
        /// <returns>If this method succeeds, it returns S_OK. Otherwise, it returns an <see cref="HResult"/> error code.</returns>
        /// <remarks>This method does not move the item, it merely declares the item to be moved. To move an object, you must make at least the sequence of calls detailed here:
        /// <ol><li>Call <see cref="MoveItem"/> to declare the source item, destination folder, and destination name.</li>
        /// <li>Call <see cref="PerformOperations"/> to begin the move operation.</li></ol></remarks>
        HResult MoveItem(IShellItem psiItem, IShellItem psiDestinationFolder, [MarshalAs(UnmanagedType.LPWStr)] string pszNewName, IFileOperationProgressSink pfopsItem);

        /// <summary>
        /// Declares a set of items that are to be moved to a specified destination.
        /// </summary>
        /// <param name="punkItems">Pointer to the IUnknown of the <see cref="IShellItemArray"/>, <see cref="IDataObject"/>, or <see cref="IEnumShellItems"/> object which represents the group of items to be moved. You can also point to an <see cref="IPersistIDList"/> object to represent a single item, effectively accomplishing the same function as IFileOperation::MoveItem.</param>
        /// <param name="psiDestinationFolder">Pointer to an <see cref="IShellItem"/> that specifies the destination folder to contain the moved items.</param>
        /// <returns>If this method succeeds, it returns S_OK. Otherwise, it returns an <see cref="HResult"/> error code.</returns>
        /// <remarks>This method does not move the items, it merely declares the items to be moved. To move a group of items, you must make at least the sequence of calls detailed here:
        /// <ul><li>Call <see cref="MoveItems"/> to declare the source files or folders and the destination folder.</li>
        /// <li>Call <see cref="PerformOperations"/> to begin the move operation.</li></ul></remarks>
        HResult MoveItems([MarshalAs(UnmanagedType.Interface)] object punkItems, IShellItem psiDestinationFolder);

        /// <summary>
        /// Declares a single item that is to be copied to a specified destination.
        /// </summary>
        /// <param name="psiItem">Pointer to an <see cref="IShellItem"/> that specifies the source item.</param>
        /// <param name="psiDestinationFolder">Pointer to an <see cref="IShellItem"/> that specifies the destination folder to contain the copy of the item.</param>
        /// <param name="pszCopyName">Pointer to a new name for the item after it has been copied. This is a null-terminated Unicode string and can be <see langword="null"/>. If <see langword="null"/>, the name of the destination item is the same as the source.</param>
        /// <param name="pfopsItem">Pointer to an <see cref="IFileOperationProgressSink"/> object to be used for progress status and error notifications for this specific copy operation. If you call <see cref="Advise"/> for the overall operation, progress status and error notifications for the copy operation are included there, so set this parameter to <see langword="null"/>.</param>
        /// <returns>If this method succeeds, it returns S_OK. Otherwise, it returns an <see cref="HResult"/> error code.</returns>
        /// <remarks>This method does not copy the item, it merely declares the item to be copied. To copy an object, you must make at least the sequence of calls detailed here:
        /// <ol><li>Call <see cref="CopyItem"/> to declare the source item, destination folder, and destination name.</li>
        /// <li>Call <see cref="PerformOperations"/> to begin the copy operation.</li></ol></remarks>
        HResult CopyItem(IShellItem psiItem, IShellItem psiDestinationFolder, [MarshalAs(UnmanagedType.LPWStr)] string pszCopyName, IFileOperationProgressSink pfopsItem);

        /// <summary>
        /// Declares a set of items that are to be copied to a specified destination.
        /// </summary>
        /// <param name="punkItems">Pointer to the IUnknown of the <see cref="IShellItemArray"/>, <see cref="IDataObject"/>, or <see cref="IEnumShellItems"/> object which represents the group of items to be copied. You can also point to an <see cref="IPersistIDList"/> object to represent a single item, effectively accomplishing the same function as IFileOperation::CopyItem.</param>
        /// <param name="psiDestinationFolder">Pointer to an <see cref="IShellItem"/> that specifies the destination folder to contain the copy of the items.</param>
        /// <returns>If this method succeeds, it returns S_OK. Otherwise, it returns an <see cref="HResult"/> error code.</returns>
        /// <remarks>This method does not copy the items, it merely declares the items to be copied. To copy a group of items, you must make at least the sequence of calls detailed here:
        /// <ol><li>Call <see cref="CopyItems"/> to declare the source items and the destination folder.</li>
        /// <li>Call <see cref="PerformOperations"/> to begin the copy operation.</li></ol></remarks>
        HResult CopyItems([MarshalAs(UnmanagedType.Interface)] object punkItems, IShellItem psiDestinationFolder);

        /// <summary>
        /// Declares a single item that is to be deleted.
        /// </summary>
        /// <param name="psiItem">Pointer to an <see cref="IShellItem"/> that specifies the item to be deleted.</param>
        /// <param name="pfopsItem">Pointer to an <see cref="IFileOperationProgressSink"/> object to be used for progress status and error notifications for this specific delete operation. If you call <see cref="Advise"/> for the overall operation, progress status and error notifications for the delete operation are included there, so set this parameter to <see langword="null"/>.</param>
        /// <returns>If this method succeeds, it returns S_OK. Otherwise, it returns an <see cref="HResult"/> error code.</returns>
        /// <remarks>This method does not delete the item, it merely declares the item to be deleted. To delete an item, you must make at least the sequence of calls detailed here:
        /// <ol><li>Call <see cref="DeleteItem"/> to declare the file or folder to be deleted.</li>
        /// <li>Call <see cref="PerformOperations"/> to begin the delete operation.</li></ol></remarks>
        HResult DeleteItem(IShellItem psiItem, IFileOperationProgressSink pfopsItem);

        /// <summary>
        /// Declares a set of items that are to be deleted.
        /// </summary>
        /// <param name="punkItems">Pointer to the IUnknown of the <see cref="IShellItemArray"/>, <see cref="IDataObject"/>, or <see cref="IEnumShellItems"/> object which represents the group of items to be deleted. You can also point to an <see cref="IPersistIDList"/> object to represent a single item, effectively accomplishing the same function as IFileOperation::DeleteItem.</param>
        /// <returns>If this method succeeds, it returns S_OK. Otherwise, it returns an <see cref="HResult"/> error code.</returns>
        /// <remarks>This method does not delete the items, it merely declares the items to be deleted. To delete a group of items, you must make at least the sequence of calls detailed here:
        /// <ol><li>Call <see cref="DeleteItems"/> to declare the files or folders to be deleted.</li>
        /// <li>Call <see cref="PerformOperations"/> to begin the delete operation.</li></ol></remarks>
        HResult DeleteItems([MarshalAs(UnmanagedType.Interface)] object punkItems);

        /// <summary>
        /// Declares a new item that is to be created in a specified location.
        /// </summary>
        /// <param name="psiDestinationFolder">Pointer to an <see cref="IShellItem"/> that specifies the destination folder that will contain the new item.</param>
        /// <param name="dwFileAttributes">A bitwise value that specifies the file system attributes for the file or folder. See <see cref="File.GetAttributes(string)"/> for possible values.</param>
        /// <param name="pszName">Pointer to the file name of the new item, for instance <b>Newfile.txt</b>. This is a null-terminated, Unicode string.</param>
        /// <param name="pszTemplateName">Pointer to the name of the template file (for example Excel9.xls) that the new item is based on, stored in one of the following locations:
        /// <ol><li>CSIDL_COMMON_TEMPLATES.The default path for this folder is %ALLUSERSPROFILE%\Templates.</li>
        /// <li>CSIDL_TEMPLATES.The default path for this folder is %USERPROFILE%\Templates.</li>
        /// <li>%SystemRoot%\shellnew</li></ol>
        /// <para>This is a null-terminated, Unicode string used to specify an existing file of the same type as the new file, containing the minimal content that an application wants to include in any new file.</para>
        /// <para>This parameter is normally <see langword="null"/> to specify a new, blank file.</para></param>
        /// <param name="pfopsItem">Pointer to an <see cref="IFileOperationProgressSink"/> object to be used for status and failure notifications. If you call <see cref="Advise"/> for the overall operation, progress status and error notifications for the creation operation are included there, so set this parameter to <see langword="null"/>.</param>
        /// <returns>If this method succeeds, it returns <see cref="HResult.Ok"/>. Otherwise, it returns an <see cref="HResult"/> error code.</returns>
        /// <remarks>This method does not create the new item, it merely declares the item to be created. To create a new item, you must make at least the sequence of calls detailed here:
        /// <ol><li>Call <see cref="NewItem"/> to declare the specifics of the new file or folder.</li>
        /// <li>Call <see cref="PerformOperations"/> to create the new item.</li></ol></remarks>
        HResult NewItem(IShellItem psiDestinationFolder, FileAttributes dwFileAttributes, [MarshalAs(UnmanagedType.LPWStr)] string pszName, [MarshalAs(UnmanagedType.LPWStr)] string pszTemplateName, IFileOperationProgressSink pfopsItem);

        /// <summary>
        /// Executes all selected operations.
        /// </summary>
        /// <returns>Returns <see cref="HResult.Ok"/> if successful, or an error value otherwise. Note that if the operation was canceled by the user, this method can still return a success code. Use the <see cref="GetAnyOperationsAborted"/> method to determine if this was the case.</returns>
        /// <remarks>This method is called last to execute those actions that have been specified earlier by calling their individual methods. For instance, <see cref="RenameItem"/> does not rename the item, it simply sets the parameters. The actual renaming is done when you call <see cref="PerformOperations"/>.</remarks>
        HResult PerformOperations();

        /// <summary>
        /// Gets a value that states whether any file operations initiated by a call to <see cref="PerformOperations"/> were stopped before they were complete. The operations could be stopped either by user action or silently by the system.
        /// </summary>
        /// <param name="pfAnyOperationsAborted">When this method returns, points to <see langword="true"/> if any file operations were aborted before they were complete; otherwise, <see langword="false"/>.</param>
        /// <returns>If this method succeeds, it returns S_OK. Otherwise, it returns an <see cref="HResult"/> error code.</returns>
        /// <remarks><para>Call this method after <see cref="PerformOperations"/> returns.</para>
        /// <para>You should call <see cref="GetAnyOperationsAborted"/> regardless of whether <see cref="PerformOperations"/> returned a success or failure code.A success code can be returned even if the operation was stopped by the user or the system.</para>
        /// <para>This method provides the same functionality as the fAnyOperationsAborted member of the SHFILEOPSTRUCT structure used by the legacy function SHFileOperation.</para></remarks>
        HResult GetAnyOperationsAborted(out bool pfAnyOperationsAborted);

    }

    /// <summary>
    /// Exposes methods that are used to persist item identifier lists.
    /// </summary>
    [ComImport,
       Guid("1079ACFC-29BD-11D3-8E0D-00C04F6837D5"),
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IPersistIDList
    {

        /// <summary>
        /// Sets a persisted item identifier list.
        /// </summary>
        /// <param name="pidl">A pointer to the item identifier list to set.</param>
        /// <returns>If this method succeeds, it returns <see cref="HResult.Ok"/>. Otherwise, it returns an <see cref="HResult"/> error code.</returns>
        HResult SetIDList(IntPtr pidl);

        /// <summary>
        /// Gets an item identifier list.
        /// </summary>
        /// <param name="ppidl">The address of a pointer to the item identifier list to get.</param>
        /// <returns>If this method succeeds, it returns <see cref="HResult.Ok"/>. Otherwise, it returns an <see cref="HResult"/> error code.</returns>
        HResult GetIDList(IntPtr ppidl);

    }

    /// <summary>
    /// Exposes enumeration of <see cref="IShellItem"/> interfaces. This interface is typically obtained by calling the <b>IEnumShellItems</b> method.
    /// </summary>
    [ComImport,
        Guid("70629033-E363-4A28-A567-0DB78006E6D7"),
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IEnumShellItems
    {

        /// <summary>
        /// Gets an array of one or more IShellItem interfaces from the enumeration.
        /// </summary>
        /// <param name="clet">The number of elements in the array referenced by the rgelt parameter.</param>
        /// <param name="rgelt">The address of an array of pointers to <see cref="IShellItem"/> interfaces that receive the enumerated item or items. The calling application is responsible for freeing the IShellItem interfaces by calling the IUnknown.Release method.</param>
        /// <param name="pceltFetched">A pointer to a value that receives the number of <see cref="IShellItem"/> interfaces successfully retrieved. The count can be smaller than the value specified in the celt parameter. This parameter can be <see langword="null"/> on entry only if celt is one, because in that case the method can only retrieve one item and return <see cref="HResult.Ok"/>, or zero items and return <see cref="HResult.False"/>.</param>
        /// <returns>This method can return one of these values.
        /// | Return code                 | Description                                                                  |
        /// |-----------------------------+------------------------------------------------------------------------------|
        /// | <see cref="HResult.Ok"/>    | if at least <see cref="IShellItem"/> interface was retrieved.                |
        /// | <see cref="HResult.False"/> | if there are no more <see cref="IShellItem"/> interfaces in the enumeration. |
        /// |                             | Returns an error value if the function fails for any other reason.           |
        /// </returns>
        HResult Next(uint clet, IntPtr rgelt, ref uint pceltFetched);

        /// <summary>
        /// Skips a given number of <see cref="IShellItem"/> interfaces in the enumeration. Used when retrieving interfaces.
        /// </summary>
        /// <param name="celt">The number of <see cref="IShellItem"/> interfaces to skip.</param>
        /// <returns>If this method succeeds, it returns <see cref="HResult.Ok"/>. Otherwise, it returns an <see cref="HResult"/> error code.</returns>
        HResult Skip(uint celt);

        /// <summary>
        /// Resets the internal count of retrieved <see cref="IShellItem"/> interfaces in the enumeration.
        /// </summary>
        /// <returns>If this method succeeds, it returns <see cref="HResult"/>. Otherwise, it returns an <see cref="HResult"/> error code.</returns>
        HResult Reset();

        /// <summary>
        /// Gets a copy of the current enumeration.
        /// </summary>
        /// <param name="ppenum">The address of a pointer that receives a copy of this enumeration.</param>
        /// <returns>If this method succeeds, it returns <see cref="HResult.Ok"/>. Otherwise, it returns an <see cref="HResult"/> error code.</returns>
        HResult Clone(IntPtr ppenum);

    }

    /// <summary>
    /// Exposes methods to get, set, and query a progress dialog.
    /// </summary>
    [ComImport,
        Guid("0C9FB851-E5C9-43EB-A370-F0677B13874C"),
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IOperationsProgressDialog
    {

        /// <summary>
        /// Starts the specified progress dialog.
        /// </summary>
        /// <param name="hwndOwner">A handle to the parent window.</param>
        /// <param name="flags">Flags that customize the operation. Note that these flags are declared in Shlobj.h.</param>
        /// <returns>If this method succeeds, it returns <see cref="HResult"/>. Otherwise, it returns an <see cref="HResult"/> error code.</returns>
        /// <remarks><para>The progress dialog should be created on a separate thread than the file operation on which the dialog is reporting. If the dialog is running in the same thread as the file operation, progress messages are, at best, only sent as resources allow. Progress messages on the same thread as the file operation might not be sent at all.</para>
        /// <para>Once <see cref="StartProgressDialog"/> is called, that instance of the CLSID_ProgressDialog object cannot be accessed by IProgressDialog, IActionProgressDialog, or IActionProgress. Although QueryInterface can be used to access these interfaces, most of their methods cannot be invoked. IOperationsProgressDialog is the interface used to display the new progress dialog for the Windows Vista and later operations engine.</para></remarks>
        HResult StartProgressDialog(IntPtr hwndOwner, OPPROGDLG flags);

        /// <summary>
        /// Stops current progress dialog.
        /// </summary>
        /// <returns>If this method succeeds, it returns <see cref="HResult.Ok"/>. Otherwise, it returns an <see cref="HResult"/> error code.</returns>
        HResult StopProgressDialog();

        /// <summary>
        /// Sets which progress dialog operation is occurring, and whether we are in pre-flight or undo mode.
        /// </summary>
        /// <param name="action">Specifies operation.</param>
        /// <returns>If this method succeeds, it returns <see cref="HResult.Ok"/>. Otherwise, it returns an <see cref="HResult"/> error code.</returns>
        HResult SetOperation(SPACTION action);

        /// <summary>
        /// Sets progress dialog operations mode.
        /// </summary>
        /// <param name="mode">Specifies the operation mode.</param>
        /// <returns>If this method succeeds, it returns <see cref="HResult.Ok"/>. Otherwise, it returns an <see cref="HResult"/> error code.</returns>
        HResult SetMode(PDMODE mode);

        /// <summary>
        /// Updates the current progress dialog, as specified.
        /// </summary>
        /// <param name="ullPointsCurrent">Current points, used for showing progress in points.</param>
        /// <param name="ullPointsTotal">Total points, used for showing progress in points.</param>
        /// <param name="ullSizeCurrent">Current size in bytes, used for showing progress in bytes.</param>
        /// <param name="ullSizeTotal">Total size in bytes, used for showing progress in bytes.</param>
        /// <param name="ullItemsCurrent">Current items, used for showing progress in items.</param>
        /// <param name="ullItemsTotal">Specifies total items, used for showing progress in items.</param>
        /// <returns>If this method succeeds, it returns <see cref="HResult.Ok"/>. Otherwise, it returns an <see cref="HResult"/> error code.</returns>
        HResult UpdateProgress(ref ulong ullPointsCurrent, ref ulong ullPointsTotal, ref ulong ullSizeCurrent, ref ulong ullSizeTotal, ref ulong ullItemsCurrent, ref ulong ullItemsTotal);

        /// <summary>
        /// Called to specify the text elements stating the source and target in the current progress dialog.
        /// </summary>
        /// <param name="psiSource">A pointer to an <see cref="IShellItem"/> that represents the source Shell item.</param>
        /// <param name="psiTarget">A pointer to an <see cref="IShellItem"/> that represents the target Shell item.</param>
        /// <param name="psiItem">A pointer to an <see cref="IShellItem"/> that represents the item currently being operated on by the operation engine. This parameter is only used in Windows 7 and later. In earlier versions, this parameter should be <see langword="null"/>.</param>
        /// <returns>If this method succeeds, it returns <see cref="HResult.Ok"/>. Otherwise, it returns an <see cref="HResult"/> error code.</returns>
        HResult UpdateLocations(ref IShellItem psiSource, ref IShellItem psiTarget, ref IShellItem psiItem);

        /// <summary>
        /// Resets progress dialog timer to 0.
        /// </summary>
        /// <returns>If this method succeeds, it returns <see cref="HResult.Ok"/>. Otherwise, it returns an <see cref="HResult"/> error code.</returns>
        HResult ResetTimer();

        /// <summary>
        /// Pauses progress dialog timer.
        /// </summary>
        /// <returns>If this method succeeds, it returns <see cref="HResult.Ok"/>. Otherwise, it returns an <see cref="HResult"/> error code.</returns>
        HResult PauseTimer();

        /// <summary>
        /// Resumes progress dialog timer.
        /// </summary>
        /// <returns>If this method succeeds, it returns <see cref="HResult.Ok"/>. Otherwise, it returns an <see cref="HResult"/> error code.</returns>
        HResult ResumeTimer();

        /// <summary>
        /// Gets elapsed and remaining time for progress dialog.
        /// </summary>
        /// <param name="pullElapsed">A pointer to the elapsed time in milliseconds.</param>
        /// <param name="pullRemaining">A pointer to the remaining time in milliseconds.</param>
        /// <returns>If this method succeeds, it returns <see cref="HResult.Ok"/>. Otherwise, it returns an <see cref="HResult"/> error code.</returns>
        HResult GetMilliseconds(ref ulong pullElapsed, ref ulong pullRemaining);

        /// <summary>
        /// Gets operation status for progress dialog.
        /// </summary>
        /// <param name="popstatus">Contains pointer to the operation status. See <see cref="PDOPSTATUS"/>.</param>
        /// <returns>If this method succeeds, it returns <see cref="HResult.Ok"/>. Otherwise, it returns an <see cref="HResult"/> error code.</returns>
        HResult GetOperationStatus(ref PDOPSTATUS popstatus);

    }

    /// <summary>
    /// Exposes methods that provide a rich notification system used by callers of <see cref="IFileOperation"/> to monitor the details of the operations they are performing through that interface.
    /// </summary>
    [ComImport,
        Guid("04B0F1A7-9490-44BC-96E1-4296A31252E2"),
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IFileOperationProgressSink
    {

        /// <summary>
        /// Performs caller-implemented actions before any specific file operations are performed.
        /// </summary>
        /// <returns>If this method succeeds, it returns <see cref="HResult.Ok"/>. Otherwise, it returns an <see cref="HResult"/> error code.</returns>
        /// <remarks>StartOperations is the first of the <see cref="IFileOperationProgressSink"/> methods to be called after <see cref="IFileOperation.PerformOperations"/>. It can be used to perform any setup or initialization that you require before the file operations begin.</remarks>
        void StartOperations();

        /// <summary>
        /// Performs caller-implemented actions after the last operation performed by the call to <see cref="IFileOperation"/> is complete.
        /// </summary>
        /// <param name="hr">The return value of the final operation. Note that this is not the <see cref="HResult"/> returned by one of the <see cref="IFileOperation"/> methods, which simply queue the operations. Instead, this is the result of the actual operation, such as copy, delete, or move.</param>
        /// <returns>Not used.</returns>
        void FinishOperations(HResult hr);

        /// <summary>
        /// Performs caller-implemented actions before the rename process for each item begins.
        /// </summary>
        /// <param name="dwFlags">bitwise value that contains flags that control the operation. See <a href="https://msdn.microsoft.com/8a3da00a-1d96-444d-acbe-9327620b8d24">TRANSFER_SOURCE_FLAGS</a> for flag descriptions.</param>
        /// <param name="psiItem">Pointer to an <see cref="IShellItem"/> that specifies the item to be renamed.</param>
        /// <param name="pszNewName">Pointer to the new <a href="https://msdn.microsoft.com/9b159be9-3797-4c8b-90f8-9d3b3a3afb71">display name</a> of the item. This is a null-terminated, Unicode string.</param>
        /// <returns>Returns <see cref="HResult.Ok"/> if successful, or an error value otherwise. In the case of an error value, the rename operation and all subsequent operations pending from the call to <see cref="IFileOperation"/> are canceled.</returns>
        void PreRenameItem(uint dwFlags, IShellItem psiItem, [MarshalAs(UnmanagedType.LPWStr)] string pszNewName);

        /// <summary>
        /// Performs caller-implemented actions after the rename process for each item is complete.
        /// </summary>
        /// <param name="dwFlags">bitwise value that contains flags that were used during the rename operation. Some values can be set or changed during the rename operation. See <a href="https://msdn.microsoft.com/8a3da00a-1d96-444d-acbe-9327620b8d24">TRANSFER_SOURCE_FLAGS</a> for flag descriptions.</param>
        /// <param name="psiItem">Pointer to an <see cref="IShellItem"/> that specifies the item before it was renamed.</param>
        /// <param name="pszNewName">Pointer to the new <a href="https://msdn.microsoft.com/9b159be9-3797-4c8b-90f8-9d3b3a3afb71">display name</a> of the item. This is a null-terminated, Unicode string. Note that this might not be the name that you asked for, given collisions and other naming rules.</param>
        /// <param name="hrRename">The return value of the rename operation. Note that this is not the HRESULT returned by <see cref="IFileOperation.RenameItem"/>, which simply queues the rename operation. Instead, this is the result of the actual rename operation.</param>
        /// <param name="psiNewlyCreated">Pointer to an <see cref="IShellItem"/> that represents the item with its new name.</param>
        /// <returns>Returns <see cref="HResult.Ok"/> if successful, or an error value otherwise. In the case of an error value, all subsequent operations pending from the call to <see cref="IFileOperation"/> are canceled.</returns>
        void PostRenameItem(uint dwFlags, IShellItem psiItem, [MarshalAs(UnmanagedType.LPWStr)]string pszNewName, HResult hrRename, IShellItem psiNewlyCreated);

        /// <summary>
        /// Performs caller-implemented actions before the move process for each item begins.
        /// </summary>
        /// <param name="dwFlags">bitwise value that contains flags that control the operation. See <a href="https://msdn.microsoft.com/8a3da00a-1d96-444d-acbe-9327620b8d24">TRANSFER_SOURCE_FLAGS</a> for flag descriptions.</param>
        /// <param name="psiItem">Pointer to an <see cref="IShellItem"/> that specifies the item to be moved.</param>
        /// <param name="psiDestinationFolder">Pointer to an <see cref="IShellItem"/> that specifies the destination folder to contain the moved item.</param>
        /// <param name="pszNewName">Pointer to a new name for the item in its new location. This is a null-terminated Unicode string and can be <see langword="null"/>. If <see langword="null"/>, the name of the destination item is the same as the source.</param>
        /// <returns>Returns <see cref="HResult.Ok"/> if successful, or an error value otherwise. In the case of an error value, the move operation and all subsequent operations pending from the call to <see cref="IFileOperation"/> are canceled.</returns>
        void PreMoveItem(uint dwFlags, IShellItem psiItem, IShellItem psiDestinationFolder, [MarshalAs(UnmanagedType.LPWStr)] string pszNewName);

        /// <summary>
        /// Performs caller-implemented actions after the move process for each item is complete.
        /// </summary>
        /// <param name="dwFlags">bitwise value that contains flags that were used during the move operation. Some values can be set or changed during the move operation. See <a href="https://msdn.microsoft.com/8a3da00a-1d96-444d-acbe-9327620b8d24">TRANSFER_SOURCE_FLAGS for flag descriptions</a>.</param>
        /// <param name="psiItem">Pointer to an <see cref="IShellItem"/> that specifies the source item.</param>
        /// <param name="psiDestinationFolder">Pointer to an <see cref="IShellItem"/> that specifies the destination folder that contains the moved item.</param>
        /// <param name="pszNewName">Pointer to the name that was given to the item after it was moved. This is a null-terminated Unicode string. Note that this might not be the name that you asked for, given collisions and other naming rules.</param>
        /// <param name="hrMove">The return value of the move operation. Note that this is not the HRESULT returned by <see cref="IFileOperation.MoveItem"/>, which simply queues the move operation. Instead, this is the result of the actual move.</param>
        /// <param name="psiNewlyCreated">Pointer to an <see cref="IShellItem"/> that represents the moved item in its new location.</param>
        /// <returns>Returns <see cref="HResult.Ok"/> if successful, or an error value otherwise. In the case of an error value, all subsequent operations pending from the call to <see cref="IFileOperation"/> are canceled.</returns>
        void PostMoveItem(uint dwFlags, IShellItem psiItem, IShellItem psiDestinationFolder, [MarshalAs(UnmanagedType.LPWStr)] string pszNewName, HResult hrMove, IShellItem psiNewlyCreated);

        /// <summary>
        /// Performs caller-implemented actions before the copy process for each item begins.
        /// </summary>
        /// <param name="dwFlags">bitwise value that contains flags that control the operation. See <a href="https://msdn.microsoft.com/8a3da00a-1d96-444d-acbe-9327620b8d24">TRANSFER_SOURCE_FLAGS</a> for flag descriptions.</param>
        /// <param name="psiItem">Pointer to an <see cref="IShellItem"/> that specifies the source item.</param>
        /// <param name="psiDestinationFolder">Pointer to an <see cref="IShellItem"/> that specifies the destination folder to contain the copy of the item.</param>
        /// <param name="pszNewName">Pointer to a new name for the item after it has been copied. This is a null-terminated Unicode string and can be <see langword="null"/>. If <see langword="null"/>, the name of the destination item is the same as the source.</param>
        /// <returns>Returns <see cref="HResult.Ok"/> if successful, or an error value otherwise. In the case of an error value, the copy operation and all subsequent operations pending from the call to <see cref="IFileOperation"/> are canceled.</returns>
        void PreCopyItem(uint dwFlags, IShellItem psiItem, IShellItem psiDestinationFolder, [MarshalAs(UnmanagedType.LPWStr)]string pszNewName);

        /// <summary>
        /// Performs caller-implemented actions after the copy process for each item is complete.
        /// </summary>
        /// <param name="dwFlags">bitwise value that contains flags that were used during the copy operation. Some values can be set or changed during the copy operation. See <a href="https://msdn.microsoft.com/8a3da00a-1d96-444d-acbe-9327620b8d24">TRANSFER_SOURCE_FLAGS</a> for flag descriptions.</param>
        /// <param name="psiItem">Pointer to an <see cref="IShellItem"/> that specifies the source item.</param>
        /// <param name="psiDestinationFolder">Pointer to an <see cref="IShellItem"/> that specifies the destination folder to which the item was copied.</param>
        /// <param name="pszNewName">Pointer to the new name that was given to the item after it was copied. This is a null-terminated Unicode string. Note that this might not be the name that you asked for, given collisions and other naming rules.</param>
        /// <param name="hrCopy">The return value of the copy operation. Note that this is not the <see cref="HResult"/> returned by <see cref="IFileOperation.CopyItem"/>, which simply queues the copy operation. Instead, this is the result of the actual copy.</param>
        /// <param name="psiNewlyCreated">Pointer to an <see cref="IShellItem"/> that represents the new copy of the item.</param>
        /// <returns>Returns <see cref="HResult.Ok"/> if successful, or an error value otherwise. In the case of an error value, all subsequent operations pending from the call to <see cref="IFileOperation"/> are canceled.</returns>
        void PostCopyItem(uint dwFlags, IShellItem psiItem, IShellItem psiDestinationFolder, [MarshalAs(UnmanagedType.LPWStr)] string pszNewName, HResult hrCopy, IShellItem psiNewlyCreated);

        /// <summary>
        /// Performs caller-implemented actions before the delete process for each item begins.
        /// </summary>
        /// <param name="dwFlags">bitwise value that contains flags that control the operation. See <a href="https://msdn.microsoft.com/8a3da00a-1d96-444d-acbe-9327620b8d24">TRANSFER_SOURCE_FLAGS</a> for flag descriptions.</param>
        /// <param name="psiItem">Pointer to an <see cref="IShellItem"/> that specifies the item to be deleted.</param>
        /// <returns>Returns <see cref="HResult.Ok"/> if successful, or an error value otherwise. In the case of an error value, the delete operation and all subsequent operations pending from the call to <see cref="IFileOperation"/> are canceled.</returns>
        void PreDeleteItem(uint dwFlags, IShellItem psiItem);

        /// <summary>
        /// Performs caller-implemented actions after the delete process for each item is complete.
        /// </summary>
        /// <param name="dwFlags">bitwise value that contains flags that were used during the delete operation. Some values can be set or changed during the delete operation. See <a href="https://msdn.microsoft.com/8a3da00a-1d96-444d-acbe-9327620b8d24">TRANSFER_SOURCE_FLAGS</a> for flag descriptions.</param>
        /// <param name="psiItem">Pointer to an <see cref="IShellItem"/> that specifies the item that was deleted.</param>
        /// <param name="hrDelete">The return value of the delete operation. Note that this is not the <see cref="HResult"/> returned by <see cref="IFileOperation.DeleteItem"/>, which simply queues the delete operation. Instead, this is the result of the actual deletion.</param>
        /// <param name="psiNewlyCreated">A pointer to an <see cref="IShellItem"/> that specifies the deleted item, now in the Recycle Bin. If the item was fully deleted, this value is <see langword="null"/>.</param>
        /// <returns>Returns <see cref="HResult.Ok"/> if successful, or an error value otherwise. In the case of an error value, all subsequent operations pending from the call to <see cref="IFileOperation"/> are canceled.</returns>
        void PostDeleteItem(uint dwFlags, IShellItem psiItem, HResult hrDelete, IShellItem psiNewlyCreated);

        /// <summary>
        /// Performs caller-implemented actions before the process to create a new item begins.
        /// </summary>
        /// <param name="dwFlags">bitwise value that contains flags that control the operation. See <a href="https://msdn.microsoft.com/8a3da00a-1d96-444d-acbe-9327620b8d24">TRANSFER_SOURCE_FLAGS</a> for flag descriptions.</param>
        /// <param name="psiDestinationFolder">Pointer to an <see cref="IShellItem"/> that specifies the destination folder that will contain the new item.</param>
        /// <param name="pszNewName">Pointer to the file name of the new item, for instance <b>Newfile.txt</b>. This is a null-terminated, Unicode string.</param>
        /// <returns>Returns <see cref="HResult.Ok"/> if successful, or an error value otherwise. In the case of an error value, this operation and all subsequent operations pending from the call to <see cref="IFileOperation"/> are canceled.</returns>
        void PreNewItem(uint dwFlags, IShellItem psiDestinationFolder, [MarshalAs(UnmanagedType.LPWStr)] string pszNewName);

        /// <summary>
        /// Performs caller-implemented actions after the new item is created.
        /// </summary>
        /// <param name="dwFlags">bitwise value that contains flags that were used during the creation operation. Some values can be set or changed during the creation operation. See <a href="https://msdn.microsoft.com/8a3da00a-1d96-444d-acbe-9327620b8d24">TRANSFER_SOURCE_FLAGS</a> for flag descriptions.</param>
        /// <param name="psiDestinationFolder">Pointer to an <see cref="IShellItem"/> that specifies the destination folder to which the new item was added.</param>
        /// <param name="pszNewName">Pointer to the file name of the new item, for instance <b>Newfile.txt</b>. This is a null-terminated, Unicode string.</param>
        /// <param name="pszTemplateName">Pointer to the name of the template file (for example <b>Excel9.xls</b>) that the new item is based on, stored in one of the following locations:
        /// <ol><li>CSIDL_COMMON_TEMPLATES. The default path for this folder is %ALLUSERSPROFILE%\Templates.</li>
        /// <li>CSIDL_TEMPLATES. The default path for this folder is %USERPROFILE%\Templates.</li>
        /// <li>%SystemRoot%\shellnew</li></ol>
        /// <para>This is a null-terminated, Unicode string used to specify an existing file of the same type as the new file, containing the minimal content that an application wants to include in any new file.</para>
        /// <para>This parameter is normally <see langword="null"/> to specify a new, blank file.</para></param>
        /// <param name="dwFileAttributes">The file attributes applied to the new item.</param>
        /// <param name="hrNew">The return value of the creation operation. Note that this is not the <see cref="HResult"/> returned by <see cref="IFileOperation.NewItem"/>, which simply queues the creation operation. Instead, this is the result of the actual creation.</param>
        /// <param name="psiNewItem">Pointer to an <see cref="IShellItem"/> that represents the new item.</param>
        /// <returns>Returns <see cref="HResult.Ok"/> if successful, or an error value otherwise. In the case of an error value, all subsequent operations pending from the call to <see cref="IFileOperation"/> are canceled.</returns>
        void PostNewItem(uint dwFlags, IShellItem psiDestinationFolder, [MarshalAs(UnmanagedType.LPWStr)] string pszNewName, [MarshalAs(UnmanagedType.LPWStr)] string pszTemplateName, FileAttributes dwFileAttributes, HResult hrNew, IShellItem psiNewItem);

        /// <summary>
        /// Provides an estimate of the total amount of work currently done in relation to the total amount of work.
        /// </summary>
        /// <param name="iWorkTotal">An estimate of the amount of work to be completed.</param>
        /// <param name="iWorkSoFar">The portion of iWorkTotal that has been completed so far.</param>
        /// <returns>If this method succeeds, it returns <see cref="HResult.Ok"/>. Otherwise, it returns an <see cref="HResult"/> error code.</returns>
        /// <remarks>The iWorkTotal and iWorkSoFar values are "points" or estimates of the amount of work to be done, and how much is completed. They are not specified in any particular units, but should be roughly proportional to how much time the total process takes. For example, to copy one small file might be considered two points, and a large file might be considered ten points. If a process is performing an operation that copies five small files and one large file, and the process has completed four of the small files, iWorkSoFar would be eight points (4 x 2 = 8) and iWorkTotal would be twenty points (5 x 2 + 10 = 20), so the estimate would be 8 of 20 points (or 40%) complete.</remarks>
        void UpdateProgress(uint iWorkTotal, uint iWorkSoFar);

        /// <summary>
        /// Not supported.
        /// </summary>
        /// <returns>If this method succeeds, it returns <see cref="HResult.Ok"/>. Otherwise, it returns an <see cref="HResult"/> error code.</returns>
        /// <remarks>This method should return <see cref="HResult.Ok"/> rather than E_NOTIMPL.</remarks>
        void ResetTimer();

        /// <summary>
        /// Not supported.
        /// </summary>
        /// <returns>If this method succeeds, it returns <see cref="HResult.Ok"/>. Otherwise, it returns an <see cref="HResult"/> error code.</returns>
        /// <remarks>This method should return <see cref="HResult.Ok"/> rather than E_NOTIMPL.</remarks>
        void PauseTimer();

        /// <summary>
        /// Not supported.
        /// </summary>
        /// <returns>If this method succeeds, it returns <see cref="HResult.Ok"/>. Otherwise, it returns an <see cref="HResult"/> error code.</returns>
        /// <remarks>This method should return <see cref="HResult.Ok"/> rather than E_NOTIMPL.</remarks>
        void ResumeTimer();

    }
    #endregion

#pragma warning restore 108
}
