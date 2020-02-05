using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;
using Microsoft.WindowsAPICodePack.Win32Native;
using Microsoft.WindowsAPICodePack.Win32Native.Shell;
using Microsoft.WindowsAPICodePack.Win32Native.Shell.PropertySystem;
using Microsoft.WindowsAPICodePack.Win32Native.Shell.Resources;
using System.Collections.Generic;
using System.Text;
using Microsoft.WindowsAPICodePack.Win32Native.PropertySystem;

namespace Microsoft.WindowsAPICodePack.PropertySystem
{
    /// <summary>
    /// This class wraps native <see cref="PropVariant"/> types into managed type. Please note that the Shell API, however, has its own managed wrapper, the <c>ShellProperty</c> class.
    /// </summary>
    public sealed class ObjectProperty : IDisposable
    {

        private INativePropertiesCollection _nativePropertiesCollection;
        private INativePropertyValuesCollection _nativePropertyValuesCollection;
        private IReadOnlyNativePropertyValuesCollection _nativePropertyAttributesCollection = null;
        private readonly PropertyKey _propertyKey;

        public

        internal ObjectProperty(in INativePropertiesCollection nativePropertiesCollection, in INativePropertyValuesCollection nativePropertyValuesCollection, in PropertyKey propertyKey)

        {

            _nativePropertiesCollection = nativePropertiesCollection;

            _nativePropertyValuesCollection = nativePropertyValuesCollection;

            _propertyKey = propertyKey;

        }

        private void StorePropVariantValue(ref PropVariant propVar, out bool stringTruncated)
        {

            PropertyKey propertyKey = PropertyKey;

            HResult result = _nativePropertyValuesCollection.SetValue(ref propertyKey, ref propVar);

            if (!CoreErrorHelper.Succeeded(result))

                throw new PropertySystemException(LocalizedMessages.ShellPropertySetValue, Marshal.GetExceptionForHR((int)result));

            stringTruncated = result == HResult.InPlaceStringTruncated ? true : false;
        }

        /// <summary>
        /// Gets the value of this property.
        /// </summary>
        public (Type type, object value) GetValue()
        {

            if (IsDisposed)

                throw new InvalidOperationException("The current object is disposed.");

            PropertyKey propertyKey = PropertyKey;

            Marshal.ThrowExceptionForHR((int)_nativePropertyValuesCollection.GetValue(ref propertyKey, out PropVariant propVariant));

            (Type, object) result = (NativePropertyHelper.VarEnumToSystemType(propVariant.VarType), propVariant.Value);

            propVariant.Dispose();

            return result;

        }

        /// <summary>
        /// Sets the value of this property.
        /// The value of the property is cleared if the value is set to null.
        /// </summary>
        public void SetValue(object value, out bool stringTruncated)
        {

            if (IsDisposed)

                throw new InvalidOperationException("The current object is disposed.");

            if (value is Nullable)
            {
                PropertyInfo pi = value.GetType().GetProperty("HasValue");

                if (pi != null && !(bool)pi.GetValue(value, null))
                {
                    ClearValue();
                    stringTruncated = false;
                    return;
                }
            }
            else if (value == null)
            {
                ClearValue();
                stringTruncated = false;
                return;
            }

            PropVariant propVariant = PropVariant.FromObject(value);

            StorePropVariantValue(ref propVariant, out stringTruncated);
        }

        /// <summary>
        /// Gets the property key identifying this property.
        /// </summary>
        public PropertyKey PropertyKey => IsDisposed ? throw new InvalidOperationException("The current object is disposed.") : _propertyKey;

        /// <summary>
        /// Clears the value of the property.
        /// </summary>
        public void ClearValue()
        {

            if (IsDisposed)

                throw new InvalidOperationException("The current object is disposed.");

            var propVar = new PropVariant();

            StorePropVariantValue(ref propVar, out _);
        }

        #region IDisposable Support
        public bool IsDisposed { get; private set; } = false;

        // ~ObjectProperty()
        // {
        //   Dispose(false);
        // }

        public void Dispose()
        {
            if (!IsDisposed)
            {
                _nativePropertyValuesCollection = null;

                IsDisposed = true;
            }

            // GC.SuppressFinalize(this);
        }
        #endregion

    }

    public struct ObjectPropertyAttribute : IDisposable
    {
        private object _value;
        private Type _type;
        private PropertyKey? _propertyKey;

        internal ObjectPropertyAttribute(in PropertyKey propertyKey, in Type type, in object value)

        {

            _propertyKey = propertyKey;

            _type = type;

            _value = value;

            IsDisposed = false;

        }

        public object Value { get => IsDisposed ? throw new InvalidOperationException("The current object is disposed.") : _value; private set => _value = value; }

        public Type Type { get => IsDisposed ? throw new InvalidOperationException("The current object is disposed.") : _type; private set => _type = value; }

        public PropertyKey? PropertyKey { get => IsDisposed ? throw new InvalidOperationException("The current object is disposed.") : _propertyKey; private set => _propertyKey = value; }

        #region IDisposable Support
        public bool IsDisposed { get; private set; }

        // ~ObjectProperty()
        // {
        //   Dispose(false);
        // }

        public void Dispose()
        {
            if (!IsDisposed)
            {
                PropertyKey = null;

                Type = null;

                Value = null;

                IsDisposed = true;
            }

            // GC.SuppressFinalize(this);
        }
        #endregion

    }
}
