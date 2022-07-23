//Copyright (c) Microsoft Corporation.  All rights reserved.  Distributed under the Microsoft Public License (MS-PL)

using Microsoft.WindowsAPICodePack.COMNative.Shell;
using Microsoft.WindowsAPICodePack.COMNative.Shell.PropertySystem;
using Microsoft.WindowsAPICodePack.PropertySystem;
using Microsoft.WindowsAPICodePack.Win32Native;
using Microsoft.WindowsAPICodePack.Win32Native.Shell;
using Microsoft.WindowsAPICodePack.Win32Native.Shell.Resources;

using System;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.WindowsAPICodePack.Shell.PropertySystem
{
    /// <summary>
    /// Creates a readonly collection of IProperty objects.
    /// </summary>
    public class ShellPropertyCollection : System.Collections.ObjectModel.ReadOnlyCollection<IShellProperty>, IDisposable
    {
        private IPropertyStore nativePropertyStore;

        /// <summary>
        /// Creates a new Property collection given an IPropertyStore object
        /// </summary>
        /// <param name="nativePropertyStore">IPropertyStore</param>
        internal ShellPropertyCollection(IPropertyStore nativePropertyStore)
            : base(new List<IShellProperty>())
        {
            NativePropertyStore = nativePropertyStore;
            AddProperties(nativePropertyStore);
        }

        #region Public Constructors
        /// <summary>
        /// Creates a new Property collection given an <see cref="IShellItem2"/> native interface.
        /// </summary>
        /// <param name="parent">Parent <see cref="ShellObject"/>.</param>
        public ShellPropertyCollection(ShellObject parent)
            : base(new List<IShellProperty>())
        {
            ParentShellObject = parent ?? throw new ArgumentNullException(nameof(parent));
            IPropertyStore nativePropertyStore = null;

            try
            {
                nativePropertyStore = CreateDefaultPropertyStore(ParentShellObject);
                AddProperties(nativePropertyStore);
            }

            catch
            {
                parent?.Dispose();

                throw;
            }

            finally
            {
                CoreHelpers.DisposeCOMObject(ref nativePropertyStore);
            }
        }

        /// <summary>
        /// Creates a new <see cref="ShellPropertyCollection"/> object with the specified file or folder path.
        /// </summary>
        /// <param name="path">The path to the file or folder.</param>        
        public ShellPropertyCollection(string path) : this(ShellObjectFactory.Create(path)) { /* Left empty. */ }
        #endregion

        #region Private Methods
        private ShellObject ParentShellObject { get; set; }

        private IPropertyStore NativePropertyStore { get => nativePropertyStore; set => nativePropertyStore = value; }

        private void AddProperties(IPropertyStore nativePropertyStore)
        {
            // Populate the property collection
            _ = nativePropertyStore.GetCount(out uint propertyCount);

            for (uint i = 0; i < propertyCount; i++)
            {
                _ = nativePropertyStore.GetAt(i, out PropertyKey propKey);

                Items.Add(ParentShellObject != null ? ParentShellObject.Properties.CreateTypedProperty(propKey) : CreateTypedProperty(propKey, NativePropertyStore));
            }
        }

        internal static IPropertyStore CreateDefaultPropertyStore(ShellObject shellObj)
        {
            var guid = new Guid(NativeAPI.Guids.Shell.IPropertyStore);

#if WAPICP3
            HResult
#else
            int
#endif
            hr = shellObj.NativeShellItem2.GetPropertyStore(
                   GetPropertyStoreOptions.BestEffort,
                   ref guid,
                   out IPropertyStore nativePropertyStore);

            // throw on failure 
            return nativePropertyStore == null || !CoreErrorHelper.Succeeded(hr) ? throw new ShellException(hr) : nativePropertyStore;
        }
        #endregion

        #region Collection Public Methods
        /// <summary>
        /// Checks if a property with the given canonical name is available.
        /// </summary>
        /// <param name="canonicalName">The canonical name of the property.</param>
        /// <returns><see langword="true"/> if available, <see langword="false"/> otherwise.</returns>
        public bool Contains(string canonicalName) => string.IsNullOrEmpty(canonicalName)
                ? throw new ArgumentException(LocalizedMessages.PropertyCollectionNullCanonicalName, nameof(canonicalName))
                : Items.Any(p => p.CanonicalName == canonicalName);

        /// <summary>
        /// Checks if a property with the given property key is available.
        /// </summary>
        /// <param name="key">The property key.</param>
        /// <returns><see langword="true"/> if available, <see langword="false"/> otherwise.</returns>
        public bool Contains(PropertyKey key) => Items.Any(p => p.PropertyKey == key);

        /// <summary>
        /// Gets the property associated with the supplied canonical name string.
        /// The canonical name property is case-sensitive.
        /// </summary>
        /// <param name="canonicalName">The canonical name.</param>
        /// <returns>The property associated with the canonical name, if found.</returns>
        /// <exception cref="IndexOutOfRangeException">Throws IndexOutOfRangeException 
        /// if no matching property is found.</exception>
        public IShellProperty this[string canonicalName] => string.IsNullOrEmpty(canonicalName)
                    ? throw new ArgumentException(LocalizedMessages.PropertyCollectionNullCanonicalName, nameof(canonicalName))
                    : Items.FirstOrDefault(p => p.CanonicalName == canonicalName) ?? throw new IndexOutOfRangeException(LocalizedMessages.PropertyCollectionCanonicalInvalidIndex);

        /// <summary>
        /// Gets a property associated with the supplied property key.
        /// </summary>
        /// <param name="key">The property key.</param>
        /// <returns>The property associated with the property key, if found.</returns>
        /// <exception cref="IndexOutOfRangeException">Throws IndexOutOfRangeException 
        /// if no matching property is found.</exception>
        public IShellProperty this[PropertyKey key] => Items.FirstOrDefault(p => p.PropertyKey == key) ?? throw new IndexOutOfRangeException(LocalizedMessages.PropertyCollectionInvalidIndex);
        #endregion

        // TODO - ShellProperties.cs also has a similar class that is used for creating
        // a ShellObject specific IShellProperty. These 2 methods should be combined or moved to a 
        // common location.
        public static IShellProperty CreateTypedProperty(PropertyKey propKey, IPropertyStore NativePropertyStore) => ShellPropertyFactory.CreateShellProperty(propKey, NativePropertyStore);

        #region IDisposable Members
        /// <summary>
        /// Release the native and managed objects
        /// </summary>
        /// <param name="disposing">Indicates that this is being called from Dispose(), rather than the finalizer.</param>
        protected virtual void Dispose(bool disposing) => CoreHelpers.DisposeCOMObject(ref nativePropertyStore);

        /// <summary>
        /// Release the native objects.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Implement the finalizer.
        /// </summary>
        ~ShellPropertyCollection() => Dispose(false);
        #endregion
    }
}
