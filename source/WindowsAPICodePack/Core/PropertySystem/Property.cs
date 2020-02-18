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
using WinCopies.Collections;

namespace Microsoft.WindowsAPICodePack.PropertySystem
{

    /// <summary>
    /// This class wraps native <see cref="PropVariant"/> types into managed type. Please note that the Shell API, however, has its own managed wrapper, the <c>ShellProperty</c> class.
    /// </summary>
    public sealed class ObjectProperty : IObjectProperty, IEquatable<IObjectProperty>, IEquatable<PropertyKey>
    {

        private PropertyCollection _propertyCollection;
        private INativePropertyValuesCollection _nativePropertyValuesCollection;
        private PropertyKey _propertyKey;
        private IUIntIndexedCollection<ObjectPropertyAttribute> _attributes;

        public IUIntIndexedCollection<ObjectPropertyAttribute> Attributes
        {
            get
            {

                if (IsDisposed)

                    throw new InvalidOperationException("The current object is disposed.");

                if (_attributes is null)

                {

                    PropertyKey propertyKey = _propertyKey;

                    Marshal.ThrowExceptionForHR((int)_propertyCollection.NativePropertiesCollection.GetAttributes(ref propertyKey, out IDisposableReadOnlyNativePropertyValuesCollection attributes));

                    _attributes = new PropertyAttributeCollection(attributes);

                }

                return _attributes;
            }
        }

        public IPropertyInfo PropertyInfo { get; internal set; }

        internal ObjectProperty(in PropertyCollection propertyCollection, in INativePropertyValuesCollection nativePropertyValuesCollection, in PropertyKey propertyKey)

        {

            _propertyCollection = propertyCollection;

            _nativePropertyValuesCollection = nativePropertyValuesCollection;

            _propertyKey = propertyKey;

        }

        private void StorePropVariantValue(ref PropVariant propVar)
        {

            PropertyKey propertyKey = PropertyKey;

            HResult result = _nativePropertyValuesCollection.SetValue(ref propertyKey, ref propVar);

            if (!AllowSetTruncatedValue && result == HResult.InPlaceStringTruncated)

                throw new ArgumentOutOfRangeException(nameof(propVar), LocalizedMessages.ShellPropertyValueTruncated);

            if (!CoreErrorHelper.Succeeded(result))

                throw new PropertySystemException(LocalizedMessages.ShellPropertySetValue, Marshal.GetExceptionForHR((int)result));
        }

        public bool AllowSetTruncatedValue { get; set; }

        /// <summary>
        /// Gets the value of this property.
        /// </summary>
        public (Type type, object value) GetValue()
        {

            if (IsDisposed)

                throw new InvalidOperationException("The current object is disposed.");

            (Type, object) result;

            using (PropVariant propVariant = GetPropVariant())

                result = (NativePropertyHelper.VarEnumToSystemType(propVariant.VarType), propVariant.Value);

            return result;

        }

        /// <summary>
        /// Sets the value of this property.
        /// The value of the property is cleared if the value is set to null.
        /// </summary>
        public void SetValue(object value)
        {

            if (IsDisposed)

                throw new InvalidOperationException("The current object is disposed.");

            if (value is Nullable)
            {
                PropertyInfo pi = value.GetType().GetProperty("HasValue");

                if (pi != null && !(bool)pi.GetValue(value, null))
                {
                    ClearValue();
                    return;
                }
            }
            else if (value == null)
            {
                ClearValue();
                return;
            }

            PropVariant propVariant = PropVariant.FromObject(value);

            StorePropVariantValue(ref propVariant);
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

            StorePropVariantValue(ref propVar);
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
                _propertyCollection = null;
                _nativePropertyValuesCollection = null;
                _attributes = null;
                PropertyInfo = null;

                IsDisposed = true;
            }

            // GC.SuppressFinalize(this);
        }

        private PropVariant GetPropVariant()
        {
            PropertyKey propertyKey = _propertyKey;

            Marshal.ThrowExceptionForHR((int)_nativePropertyValuesCollection.GetValue(ref propertyKey, out PropVariant propVariant));

            return propVariant;
        }

        PropVariant IObjectProperty.GetValue() => GetPropVariant();

        public bool Equals(IObjectProperty other) => other?.PropertyKey.Equals(PropertyKey) == true;

        public bool Equals(PropertyKey other) => other.Equals(PropertyKey);
        #endregion

    }

    public sealed class ObjectPropertyAttribute : IEquatable<ObjectPropertyAttribute>, IEquatable<PropertyKey>
    {
        internal ObjectPropertyAttribute(in PropertyKey propertyKey, in Type type, in object value)

        {

            PropertyKey = propertyKey;

            Type = type;

            Value = value;

        }

        public object Value { get; private set; }

        public Type Type { get; private set; }

        public PropertyKey PropertyKey { get; private set; }

        public bool Equals(ObjectPropertyAttribute other) => other?.PropertyKey.Equals(PropertyKey) == true;

        public bool Equals(PropertyKey other) => other.Equals(PropertyKey);

        //#region IDisposable Support
        //public bool IsDisposed { get; private set; }

        // ~ObjectProperty()
        // {
        //   Dispose(false);
        // }

        //public void Dispose()
        //{
        //    if (!IsDisposed)
        //    {
        //        Type = null;
        //        Value = null;
        //        IsDisposed = true;
        //    }

        // GC.SuppressFinalize(this);
        //}
        //#endregion

    }
}
