﻿//Copyright (c) Microsoft Corporation.  All rights reserved.  Distributed under the Microsoft Public License (MS-PL)

using Microsoft.WindowsAPICodePack.COMNative.Shell;
using Microsoft.WindowsAPICodePack.COMNative.Shell.PropertySystem;
using Microsoft.WindowsAPICodePack.PropertySystem;
using Microsoft.WindowsAPICodePack.Win32Native;
using Microsoft.WindowsAPICodePack.Win32Native.Shell;
using Microsoft.WindowsAPICodePack.Win32Native.Shell.Resources;

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Linq;

namespace Microsoft.WindowsAPICodePack.Shell
{
    /// <summary>
    /// Create and modify search folders.
    /// </summary>
    public class ShellSearchFolder : ShellSearchCollection
    {
        private SearchCondition searchCondition;
        private string[] searchScopePaths;

        internal ISearchFolderItemFactory NativeSearchFolderItemFactory { get; set; }

        /// <summary>
        /// Gets the <see cref="Shell.SearchCondition"/> of the search. 
        /// When this property is not set, the resulting search will have no filters applied.
        /// </summary>
        public SearchCondition SearchCondition
        {
            get => searchCondition;

            private set
            {
                searchCondition = value;

                CoreErrorHelper.ThrowExceptionForHResult(NativeSearchFolderItemFactory.SetCondition(searchCondition.NativeSearchCondition));
            }
        }

        /// <summary>
        /// Gets the search scope, as specified using an array of locations to search. 
        /// The search will include this location and all its subcontainers. The default is FOLDERID_Profile
        /// </summary>
        public IEnumerable<string> SearchScopePaths
        {
            get
            {
                foreach (string scopePath in searchScopePaths)

                    yield return scopePath;
            }

            private set
            {
                searchScopePaths = value.ToArray();

                var shellItems = new List<IShellItem>(searchScopePaths.Length);

                var shellItemGuid = new Guid(NativeAPI.Guids.Shell.IShellItem);

                // Guid shellItemArrayGuid = new Guid(ShellIIDGuid.IShellItemArray);

                // Create IShellItem for all the scopes we were given
                int hr;

                foreach (string path in searchScopePaths)
                {
                    hr = COMNative.Shell.Shell.SHCreateItemFromParsingName(path, IntPtr.Zero, ref shellItemGuid, out IShellItem scopeShellItem);

                    if (CoreErrorHelper.Succeeded(hr)) shellItems.Add(scopeShellItem);
                }

                // Create a new IShellItemArray
                IShellItemArray scopeShellItemArray = new ShellItemArray(shellItems.ToArray());

                // Set the scope on the native ISearchFolderItemFactory
                HResult hResult = NativeSearchFolderItemFactory.SetScope(scopeShellItemArray);

                if (!CoreErrorHelper.Succeeded((int)hResult)) throw new ShellException((int)hResult);
            }
        }

        internal override IShellItem NativeShellItem
        {
            get
            {
                if (NativeSearchFolderItemFactory == null) return null;

                var guid = new Guid(NativeAPI.Guids.Shell.IShellItem);

                int hr = NativeSearchFolderItemFactory.GetShellItem(ref guid, out IShellItem shellItem);

                return CoreErrorHelper.Succeeded(hr) ? shellItem : throw new ShellException(hr);
            }
        }

        /// <summary>
        /// Create a simple search folder. Once the appropriate parameters are set, 
        /// the search folder can be enumerated to get the search results.
        /// </summary>
        /// <param name="searchCondition">Specific condition on which to perform the search (property and expected value)</param>
        /// <param name="searchScopePath">List of folders/paths to perform the search on. These locations need to be indexed by the system.</param>
        public ShellSearchFolder(SearchCondition searchCondition, params ShellContainer[] searchScopePath)
        {
            CoreHelpers.ThrowIfNotVista();

            NativeSearchFolderItemFactory = (ISearchFolderItemFactory)new SearchFolderItemFactoryCoClass();

            SearchCondition = searchCondition;

            if (searchScopePath != null && searchScopePath.Length > 0 && searchScopePath[0] != null)

                SearchScopePaths = searchScopePath.Select(cont => cont.ParsingName);
        }

        /// <summary>
        /// Create a simple search folder. Once the appropiate parameters are set, 
        /// the search folder can be enumerated to get the search results.
        /// </summary>
        /// <param name="searchCondition">Specific condition on which to perform the search (property and expected value)</param>
        /// <param name="searchScopePath">List of folders/paths to perform the search on. These locations need to be indexed by the system.</param>
        public ShellSearchFolder(SearchCondition searchCondition, params string[] searchScopePath)
        {
            CoreHelpers.ThrowIfNotVista();

            NativeSearchFolderItemFactory = (ISearchFolderItemFactory)new SearchFolderItemFactoryCoClass();

            if (searchScopePath != null && searchScopePath.Length > 0 && searchScopePath[0] != null)

                SearchScopePaths = searchScopePath;

            SearchCondition = searchCondition;
        }

        /// <summary>
        /// Creates a list of stack keys, as specified. If this method is not called, 
        /// by default the folder will not be stacked.
        /// </summary>
        /// <param name="canonicalNames">Array of canonical names for properties on which the folder is stacked.</param>
        /// <exception cref="System.ArgumentException">If one of the given canonical names is invalid.</exception>
        public void SetStacks(params string[] canonicalNames)
        {
            var propertyKeyList = canonicalNames == null ? throw new ArgumentNullException(nameof(canonicalNames)) : new List<PropertyKey>();

            int result;

            foreach (string prop in canonicalNames)
            {
                // Get the PropertyKey using the canonicalName passed in
                result = PropertySystemNativeMethods.PSGetPropertyKeyFromName(prop, out PropertyKey propKey);

                propertyKeyList.Add(CoreErrorHelper.Succeeded(result) ? propKey : throw new ArgumentException(LocalizedMessages.ShellInvalidCanonicalName, nameof(canonicalNames), Marshal.GetExceptionForHR(result)));
            }

            if (propertyKeyList.Count > 0)

                SetStacks(propertyKeyList.ToArray());
        }

        /// <summary>
        /// Creates a list of stack keys, as specified. If this method is not called, 
        /// by default the folder will not be stacked.
        /// </summary>
        /// <param name="propertyKeys">Array of property keys on which the folder is stacked.</param>
        public void SetStacks(params PropertyKey[] propertyKeys)
        {
            if (propertyKeys != null && propertyKeys.Length > 0)

                CoreErrorHelper.ThrowExceptionForHResult(NativeSearchFolderItemFactory.SetStacks((uint)propertyKeys.Length, propertyKeys));
        }

        /// <summary>
        /// Sets the search folder display name.
        /// </summary>
        public void SetDisplayName(string displayName)
        {
            HResult hr = NativeSearchFolderItemFactory.SetDisplayName(displayName);

            if (!CoreErrorHelper.Succeeded(hr)) throw new ShellException(hr);
        }



        /// <summary>
        /// Sets the search folder icon size.
        /// The default settings are based on the FolderTypeID which is set by the 
        /// SearchFolder::SetFolderTypeID method.
        /// </summary>
        public void SetIconSize(int value)
        {
            HResult hr = NativeSearchFolderItemFactory.SetIconSize(value);

            if (!CoreErrorHelper.Succeeded(hr)) throw new ShellException(hr);
        }

        /// <summary>
        /// Sets a search folder type ID, as specified. 
        /// </summary>
        public void SetFolderTypeID(Guid value)
        {
            HResult hr = NativeSearchFolderItemFactory.SetFolderTypeID(value);

            if (!CoreErrorHelper.Succeeded(hr)) throw new ShellException(hr);
        }

        /// <summary>
        /// Sets folder logical view mode. The default settings are based on the FolderTypeID which is set 
        /// by the SearchFolder::SetFolderTypeID method.        
        /// </summary>
        /// <param name="mode">The logical view mode to set.</param>
        public void SetFolderLogicalViewMode(FolderLogicalViewMode mode)
        {
            HResult hr = NativeSearchFolderItemFactory.SetFolderLogicalViewMode(mode);

            if (!CoreErrorHelper.Succeeded(hr)) throw new ShellException(hr);
        }

        /// <summary>
        /// Creates a new column list whose columns are all visible, 
        /// given an array of PropertyKey structures. The default is based on FolderTypeID.
        /// </summary>
        /// <remarks>This property may not work correctly with the ExplorerBrowser control.</remarks>
        public void SetVisibleColumns(PropertyKey[] value)
        {
            HResult hr = NativeSearchFolderItemFactory.SetVisibleColumns(value == null ? 0 : (uint)value.Length, value);

            if (!CoreErrorHelper.Succeeded(hr))

                throw new ShellException(LocalizedMessages.ShellSearchFolderUnableToSetVisibleColumns, Marshal.GetExceptionForHR((int)hr));
        }

        /// <summary>
        /// Creates a list of sort column directions, as specified.
        /// </summary>
        /// <remarks>This property may not work correctly with the ExplorerBrowser control.</remarks>
        public void SortColumns(SortColumn[] value)
        {
            HResult hr = NativeSearchFolderItemFactory.SetSortColumns(value == null ? 0 : (uint)value.Length, value);

            if (!CoreErrorHelper.Succeeded(hr))

                throw new ShellException(LocalizedMessages.ShellSearchFolderUnableToSetSortColumns, Marshal.GetExceptionForHR((int)hr));
        }

        /// <summary>
        /// Sets a group column, as specified. If no group column is specified, no grouping occurs. 
        /// </summary>
        /// <remarks>This property may not work correctly with the ExplorerBrowser control.</remarks>
        public void SetGroupColumn(PropertyKey propertyKey)
        {
            HResult hr = NativeSearchFolderItemFactory.SetGroupColumn(ref propertyKey);

            if (!CoreErrorHelper.Succeeded(hr)) throw new ShellException(hr);
        }
    }
}
