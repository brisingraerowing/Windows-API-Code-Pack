//Copyright (c) Microsoft Corporation.  All rights reserved.  Distributed under the Microsoft Public License (MS-PL)

using Microsoft.WindowsAPICodePack.COMNative.Shell.PropertySystem;
using Microsoft.WindowsAPICodePack.PropertySystem;
using Microsoft.WindowsAPICodePack.Win32Native;
using Microsoft.WindowsAPICodePack.Win32Native.PropertySystem;
using Microsoft.WindowsAPICodePack.Win32Native.Shell;
using Microsoft.WindowsAPICodePack.Win32Native.Shell.Resources;

using System;
using System.Runtime.InteropServices;

namespace Microsoft.WindowsAPICodePack.Shell.PropertySystem
{
    /// <summary>
    /// Creates a property writer capable of setting multiple properties for a given <see cref="ShellObject"/>.
    /// </summary>
    public class ShellPropertyWriter : IDisposable
    {
        // Reference to our writable PropertyStore
        internal IPropertyStore writablePropStore;

        internal ShellPropertyWriter(in ShellObject parent)
        {
            ParentShellObject = parent;

            // Open the property store for this shell object...
            var guid = new Guid(NativeAPI.Guids.Shell.IPropertyStore);

            try
            {
#if WAPICP3
                HResult
#else
                int
#endif
                hr = ParentShellObject.NativeShellItem2.GetPropertyStore(
                        GetPropertyStoreOptions.ReadWrite,
                        ref guid,
                        out writablePropStore);

                // If we succeed in creating a valid property store for this ShellObject,
                // then set it on the parent shell object for others to use.
                // Once this writer is closed/commited, we will set the 
                if (CoreErrorHelper.Succeeded(hr) ? ParentShellObject.NativePropertyStore == null : throw new PropertySystemException(LocalizedMessages.ShellPropertyUnableToGetWritableProperty,
                    Marshal.GetExceptionForHR((int)hr)))

                    ParentShellObject.NativePropertyStore = writablePropStore;
            }

            catch (InvalidComObjectException e)
            {
                throw new PropertySystemException(LocalizedMessages.ShellPropertyUnableToGetWritableProperty, e);
            }

            catch (InvalidCastException)
            {
                throw new PropertySystemException(LocalizedMessages.ShellPropertyUnableToGetWritableProperty);
            }
        }

        /// <summary>
        /// Reference to parent <see cref="ShellObject"/> (associated with this writer).
        /// </summary>
        protected ShellObject ParentShellObject { get; private set; }

        /// <summary>
        /// Writes the given property key and value.
        /// </summary>
        /// <param name="key">The property key.</param>
        /// <param name="value">The value associated with the key.</param>
        public void WriteProperty(PropertyKey key, object value) => WriteProperty(key, value, true);

        /// <summary>
        /// Writes the given property key and value. To allow truncation of the given value, set <paramref name="allowTruncatedValue"/> to <see langword="true"/>.
        /// </summary>
        /// <param name="key">The property key.</param>
        /// <param name="value">The value associated with the key.</param>
        /// <param name="allowTruncatedValue"><see langword="true"/> to allow truncation (default); otherwise <see langword="false"/>.</param>
        /// <exception cref="InvalidOperationException">If the writable property store is already closed.</exception>
        /// <exception cref="ArgumentOutOfRangeException">If <paramref name="allowTruncatedValue"/> is set to <see langword="false"/> 
        /// and while setting the value on the property it had to be truncated in a string or rounded in 
        /// a numeric value.</exception>
        public void WriteProperty(PropertyKey key, object value, bool allowTruncatedValue)
        {
            if (value != null)
            {
                Type type = value.GetType();

                if (type.IsEnum)
                {
                    value = Convert.ChangeType(value,
#if CS8
                        type.GetEnumUnderlyingType()
#else
                        Enum.GetUnderlyingType(type)
#endif
                    );
                }
            }

            using (var propVar = writablePropStore == null ? throw new InvalidOperationException("Writeable store has been closed.") : PropVariant.FromObject(value))
            {
                HResult result = writablePropStore.SetValue(ref key, propVar);

                if (!allowTruncatedValue && (result == HResult.InPlaceStringTruncated))
                {
                    // At this point we can't revert back the commit
                    // so don't commit, close the property store and throw an exception
                    // to let the user know.
                    CoreHelpers.DisposeCOMObject(ref writablePropStore);

                    throw new ArgumentOutOfRangeException(nameof(value), LocalizedMessages.ShellPropertyValueTruncated);
                }

                if (!CoreErrorHelper.Succeeded(result))

                    throw new PropertySystemException(LocalizedMessages.ShellPropertySetValue, Marshal.GetExceptionForHR((int)result));
            }
        }

        /// <summary>
        /// Writes the specified property given the canonical name and a value.
        /// </summary>
        /// <param name="canonicalName">The canonical name.</param>
        /// <param name="value">The property value.</param>
        public void WriteProperty(string canonicalName, object value) => WriteProperty(canonicalName, value, true);

        /// <summary>
        /// Writes the specified property given the canonical name and a value. To allow truncation of the given value, set <paramref name="allowTruncatedValue"/> to <see langword="true"/>.
        /// </summary>
        /// <param name="canonicalName">The canonical name.</param>
        /// <param name="value">The property value.</param>
        /// <param name="allowTruncatedValue"><see langword="true"/> to allow truncation (default); otherwise <see langword="false"/>.</param>
        /// <exception cref="ArgumentException">If the given canonical name is not valid.</exception>
        public void WriteProperty(string canonicalName, object value, bool allowTruncatedValue)
        {
            // Get the PropertyKey using the canonicalName passed in
            int result = PropertySystemNativeMethods.PSGetPropertyKeyFromName(canonicalName, out PropertyKey propKey);

            WriteProperty(CoreErrorHelper.Succeeded(result) ? propKey : throw new ArgumentException(
                    LocalizedMessages.ShellInvalidCanonicalName,
                    Marshal.GetExceptionForHR(result)), value, allowTruncatedValue);
        }

        /// <summary>
        /// Writes the specified property using an <see cref="IShellProperty"/> and a value.
        /// </summary>
        /// <param name="shellProperty">The property name.</param>
        /// <param name="value">The property value.</param>
        public void WriteProperty(IShellProperty shellProperty, object value) => WriteProperty(shellProperty, value, true);

        /// <summary>
        /// Writes the specified property given an <see cref="IShellProperty"/> and a value. To allow truncation of the given value, set <paramref name="allowTruncatedValue"/> to <see langword="true"/>.
        /// </summary>
        /// <param name="shellProperty">The property name.</param>
        /// <param name="value">The property value.</param>
        /// <param name="allowTruncatedValue"><see langword="true"/> to allow truncation (default); otherwise <see langword="false"/>.</param>
        public void WriteProperty(IShellProperty shellProperty, object value, bool allowTruncatedValue) => WriteProperty((shellProperty ?? throw new ArgumentNullException(nameof(shellProperty))).PropertyKey, value, allowTruncatedValue);

        /// <summary>
        /// Writes the specified property using a strongly-typed <see cref="ShellProperty{T}"/> and a value.
        /// </summary>
        /// <typeparam name="T">The type of the property name.</typeparam>
        /// <param name="shellProperty">The property name.</param>
        /// <param name="value">The property value.</param>
        public void WriteProperty<T>(ShellProperty<T> shellProperty, T value) => WriteProperty(shellProperty, value, true);

        /// <summary>
        /// Writes the specified property given a strongly-typed <see cref="ShellProperty{T}"/> and a value. To allow truncation of the given value, set <paramref name="allowTruncatedValue"/> to <see langword="true"/>.
        /// </summary>
        /// <typeparam name="T">The type of the property name.</typeparam>
        /// <param name="shellProperty">The property name.</param>
        /// <param name="value">The property value.</param>
        /// <param name="allowTruncatedValue"><see langword="true"/> to allow truncation (default); otherwise <see langword="false"/>.</param>
        public void WriteProperty<T>(ShellProperty<T> shellProperty, T value, bool allowTruncatedValue) => WriteProperty((shellProperty ?? throw new ArgumentNullException(nameof(shellProperty))).PropertyKey, value, allowTruncatedValue);

        #region IDisposable Members
        /// <summary>
        /// Release the native objects.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~ShellPropertyWriter() => Dispose(false);

        /// <summary>
        /// Release the native and managed objects.
        /// </summary>
        /// <param name="disposing"><see langword="true"/> to release both managed and unmanaged resources; <see langword="false"/> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing) => Close();

        /// <summary>
        /// Call this method to commit the writes (calls to WriteProperty method)
        /// and dispose off the writer.
        /// </summary>
        public void Close()
        {
            // Close the property writer (commit, etc)
            if (writablePropStore != null)
            {
                writablePropStore.Commit();

                CoreHelpers.DisposeCOMObject(ref writablePropStore);
            }

            ParentShellObject.NativePropertyStore = null;
        }
        #endregion
    }
}
