//Copyright (c) Microsoft Corporation.  All rights reserved.  Distributed under the Microsoft Public License (MS-PL)

using Microsoft.WindowsAPICodePack.Win32Native;
using Microsoft.WindowsAPICodePack.Win32Native.Shell;
using Microsoft.WindowsAPICodePack.Win32Native.Taskbar;
using Microsoft.WindowsAPICodePack.Win32Native.PropertySystem;

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

using GuidAttribute = System.Runtime.InteropServices.GuidAttribute;

namespace Microsoft.WindowsAPICodePack.COMNative.Shell
{
    public enum SICHINTF
    {
        Display = 0x00000000,
        Canonical = 0x10000000,
        TestFileSysPathIfNotEqual = 0x20000000,
        AllFields = unchecked((int)0x80000000)
#if !WAPICP3
            ,
        SICHINT_DISPLAY = Display,
        SICHINT_CANONICAL = Canonical,
        SICHINT_TEST_FILESYSPATH_IF_NOT_EQUAL = TestFileSysPathIfNotEqual,
        SICHINT_ALLFIELDS = AllFields
#endif
    }

    // Disable warning if a method declaration hides another inherited from a parent COM interface
    // To successfully import a COM interface, all inherited methods need to be declared again with 
    // the exception of those already declared in "IUnknown"
#pragma warning disable 108
    #region COM Interfaces
    [ComImport(),
    Guid(NativeAPI.Guids.Shell.IModalWindow),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IModalWindow
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime),
        PreserveSig]
        int Show([In] IntPtr parent);
    }

    [ComImport,
    Guid(NativeAPI.Guids.Shell.IShellLibrary),
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
            [In] LibraryFolderFilter lff,
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
            [In] DefaultSaveFolderType dsft,
            [In] ref Guid riid,
            [MarshalAs(UnmanagedType.Interface)] out IShellItem ppv);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void SetDefaultSaveFolder(
            [In] DefaultSaveFolderType dsft,
            [In, MarshalAs(UnmanagedType.Interface)] IShellItem si);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetOptions(
            out LibraryOptions lofOptions);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void SetOptions(
            [In] LibraryOptions lofMask,
            [In] LibraryOptions lofOptions);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetFolderType(out Guid ftid);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void SetFolderType([In] ref Guid ftid);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetIcon([MarshalAs(UnmanagedType.LPWStr)] out string icon);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void SetIcon([In, MarshalAs(UnmanagedType.LPWStr)] string icon);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HResult Commit();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void Save(
            [In, MarshalAs(UnmanagedType.Interface)] IShellItem folderToSaveIn,
            [In, MarshalAs(UnmanagedType.LPWStr)] string libraryName,
            [In] LibrarySaveOptions lsf,
            [MarshalAs(UnmanagedType.Interface)] out IShellItem2 savedTo);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void SaveInKnownFolder(
            [In] ref Guid kfidToSaveIn,
            [In, MarshalAs(UnmanagedType.LPWStr)] string libraryName,
            [In] LibrarySaveOptions lsf,
            [MarshalAs(UnmanagedType.Interface)] out IShellItem2 savedTo);
    }

    [ComImport(),
    Guid("bcc18b79-ba16-442f-80c4-8a59c30c463b"),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IShellItemImageFactory
    {
        [PreserveSig]
        HResult GetImage(
        [In, MarshalAs(UnmanagedType.Struct)] Size size,
        [In] SIIGBF flags,
        [Out] out IntPtr phbm);
    }

    [ComImport,
    Guid(NativeAPI.Guids.Shell.IThumbnailCache),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IThumbnailCache
    {
        void GetThumbnail([In] IShellItem pShellItem,
        [In] uint cxyRequestedThumbSize,
        [In] ThumbnailOptions flags,
        [Out] out ISharedBitmap ppvThumb,
        [Out] out ThumbnailCacheOptions pOutFlags,
        [Out] ThumbnailId pThumbnailID);

        void GetThumbnailByID([In] ThumbnailId thumbnailID,
        [In] uint cxyRequestedThumbSize,
        [Out] out ISharedBitmap ppvThumb,
        [Out] out ThumbnailCacheOptions pOutFlags);
    }

    [ComImport,
    Guid(NativeAPI.Guids.Shell.ISharedBitmap),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ISharedBitmap
    {
        void GetSharedBitmap([Out] out IntPtr phbm);
        void GetSize([Out] out Size pSize);
        void GetFormat([Out] out ThumbnailAlphaType pat);
        void InitializeBitmap([In] IntPtr hbm, [In] ThumbnailAlphaType wtsAT);
        void Detach([Out] out IntPtr phbm);
    }

    [ComImport,
    Guid(NativeAPI.Guids.Shell.IEnumIDList),
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

    /// <summary>
    /// Provides the managed definition of the IPersistStream interface, with functionality from IPersist.
    /// </summary>
    [ComImport,
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown),
    Guid(NativeAPI.Guids.Shell.IPersistStream)]
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
        HResult Load([In, MarshalAs(UnmanagedType.Interface)] System.Runtime.InteropServices.ComTypes.IStream stm);

        [PreserveSig]
        HResult Save([In, MarshalAs(UnmanagedType.Interface)] System.Runtime.InteropServices.ComTypes.IStream stm, bool fRemember);

        [PreserveSig]
        HResult GetSizeMax(out ulong cbSize);
    }

    [ComImport(),
    Guid(NativeAPI.Guids.Shell.ICondition),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICondition : IPersistStream
    {
        /// <summary>
        /// Retrieves the class identifier (CLSID) of an object.
        /// </summary>
        /// <param name="pClassID">When this method returns, contains a reference to the CLSID. This parameter is passed uninitialized.</param>
        [PreserveSig]
        void GetClassID(out Guid pClassID);

        /// <summary>
        /// Checks an object for changes since it was last saved to its current file.
        /// </summary>
        /// <returns>S_OK if the file has changed since it was last saved; S_FALSE if the file has not changed since it was last saved.</returns>
        [PreserveSig]
        HResult IsDirty();

        [PreserveSig]
        HResult Load([In, MarshalAs(UnmanagedType.Interface)] System.Runtime.InteropServices.ComTypes.IStream stm);

        [PreserveSig]
        HResult Save([In, MarshalAs(UnmanagedType.Interface)] System.Runtime.InteropServices.ComTypes.IStream stm, bool fRemember);

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
    }

    [ComImport,
    Guid(NativeAPI.Guids.Shell.IRichChunk),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IRichChunk
    {
        // The position *pFirstPos is zero-based.
        // Any one of pFirstPos, pLength, ppsz and pValue may be NULL.
        [PreserveSig]
        HResult GetData(/*[out, annotation("__out_opt")] ULONG* pFirstPos, [out, annotation("__out_opt")] ULONG* pLength, [out, annotation("__deref_opt_out_opt")] LPWSTR* ppsz, [out, annotation("__out_opt")] PROPVARIANT* pValue*/);
    }

    [ComImport,
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown),
    Guid(NativeAPI.Guids.Shell.IEnumUnknown)]
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
    Guid(NativeAPI.Guids.Shell.IConditionFactory),
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
    }

    [ComImport,
    Guid(NativeAPI.Guids.Shell.IConditionFactory),
    CoClass(typeof(ConditionFactoryCoClass))]
    public interface INativeConditionFactory : IConditionFactory
    {
    }

    [ComImport,
    ClassInterface(ClassInterfaceType.None),
    TypeLibType(TypeLibTypeFlags.FCanCreate),
    Guid(NativeAPI.Guids.Shell.ConditionFactory)]
    public class ConditionFactoryCoClass
    {
    }



    [ComImport,
    Guid(NativeAPI.Guids.Shell.ISearchFolderItemFactory),
    CoClass(typeof(SearchFolderItemFactoryCoClass))]
    public interface INativeSearchFolderItemFactory : ISearchFolderItemFactory
    {
    }

    [ComImport,
    ClassInterface(ClassInterfaceType.None),
    TypeLibType(TypeLibTypeFlags.FCanCreate),
    Guid(NativeAPI.Guids.Shell.SearchFolderItemFactory)]
    public class SearchFolderItemFactoryCoClass
    {
    }

    [ComImport,
    Guid(NativeAPI.Guids.Shell.IEntity),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IEntity
    {
        // TODO
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
    #endregion
#pragma warning restore 108
}
