//Copyright (c) Microsoft Corporation.  All rights reserved.

using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using Microsoft.WindowsAPICodePack.Win32Native;
using Microsoft.WindowsAPICodePack.Win32Native.Shell.PropertySystem;
using Microsoft.WindowsAPICodePack.Win32Native.Shell.Resources;

namespace Microsoft.WindowsAPICodePack.Shell.PropertySystem
{
    /// <summary>
    /// Defines a partial class that implements helper methods for retrieving Shell properties
    /// using a canonical name, property key, or a strongly-typed property. Also provides
    /// access to all the strongly-typed system properties and default properties collections.
    /// </summary>
    public partial class ShellProperties : IDisposable
    {
        private ShellObject ParentShellObject { get; set; }
        private ShellPropertyCollection defaultPropertyCollection;

        internal ShellProperties(ShellObject parent) => ParentShellObject = parent;

        /// <summary>
        /// Returns a property available in the default property collection using 
        /// the given property key.
        /// </summary>
        /// <param name="key">The property key.</param>
        /// <returns>An IShellProperty.</returns>
        public IShellProperty GetProperty(PropertyKey key) => CreateTypedProperty(key);

        /// <summary>
        /// Returns a property available in the default property collection using 
        /// the given canonical name.
        /// </summary>
        /// <param name="canonicalName">The canonical name.</param>
        /// <returns>An IShellProperty.</returns>
        public IShellProperty GetProperty(string canonicalName) => CreateTypedProperty(canonicalName);

        /// <summary>
        /// Returns a strongly typed property available in the default property collection using 
        /// the given property key.
        /// </summary>
        /// <typeparam name="T">The type of property to retrieve.</typeparam>
        /// <param name="key">The property key.</param>
        /// <returns>A strongly-typed ShellProperty for the given property key.</returns>
        public ShellProperty<T> GetProperty<T>(PropertyKey key) => CreateTypedProperty(key) as ShellProperty<T>;

        /// <summary>
        /// Returns a strongly typed property available in the default property collection using 
        /// the given canonical name.
        /// </summary>
        /// <typeparam name="T">The type of property to retrieve.</typeparam>
        /// <param name="canonicalName">The canonical name.</param>
        /// <returns>A strongly-typed ShellProperty for the given canonical name.</returns>
        public ShellProperty<T> GetProperty<T>(string canonicalName) => CreateTypedProperty(canonicalName) as ShellProperty<T>;

        private PropertySystem propertySystem;
        /// <summary>
        /// Gets all the properties for the system through an accessor.
        /// </summary>
        public PropertySystem System => propertySystem ?? (propertySystem = new PropertySystem(ParentShellObject));

        /// <summary>
        /// Gets the collection of all the default properties for this item.
        /// </summary>
        public ShellPropertyCollection DefaultPropertyCollection => defaultPropertyCollection ?? (defaultPropertyCollection = new ShellPropertyCollection(ParentShellObject));

        /// <summary>
        /// Returns the shell property writer used when writing multiple properties.
        /// </summary>
        /// <returns>A ShellPropertyWriter.</returns>
        /// <remarks>Use the Using pattern with the returned ShellPropertyWriter or
        /// manually call the Close method on the writer to commit the changes 
        /// and dispose the writer</remarks>
        public ShellPropertyWriter GetPropertyWriter() => new ShellPropertyWriter(ParentShellObject);

        internal IShellProperty CreateTypedProperty<T>(PropertyKey propKey) => new ShellProperty<T>(propKey, ShellPropertyDescriptionsCache.Cache.GetPropertyDescription(propKey), ParentShellObject);

        internal IShellProperty CreateTypedProperty(PropertyKey propKey) => ShellPropertyFactory.CreateShellProperty(propKey, ParentShellObject);

        internal IShellProperty CreateTypedProperty(string canonicalName)
        {
            // Otherwise, call the native PropertyStore method

            int result = PropertySystemNativeMethods.PSGetPropertyKeyFromName(canonicalName, out PropertyKey propKey);

            return CoreErrorHelper.Succeeded(result) ? CreateTypedProperty(propKey) : throw new ArgumentException(
                    LocalizedMessages.ShellInvalidCanonicalName,
                    Marshal.GetExceptionForHR(result));
        }

        #region IDisposable Members

        /// <summary>
        /// Cleans up memory
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Cleans up memory
        /// </summary>
        protected virtual void Dispose(bool disposed)
        {
            if (disposed)

                defaultPropertyCollection?.Dispose();
        }

        ~ShellProperties()
        {

            Dispose(false);

        }

        #endregion
    }
}