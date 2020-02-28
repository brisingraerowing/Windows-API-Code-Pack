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
    /// This class wraps native <see cref="PropVariant"/>s into managed objects. Please note that the Shell API, however, has its own managed wrapper, the <c>ShellProperty</c> class.
    /// </summary>
    public sealed class ObjectProperty : IObjectProperty, IEquatable<IObjectProperty>
    {

        private PropertyCollection _propertyCollection;
        private INativePropertyValuesCollection _nativePropertyValuesCollection;
        private PropertyKey _propertyKey;
        private WinCopies.Collections.IUIntIndexedCollection<ObjectPropertyAttribute> _attributes;
        private bool _allowSetTruncatedValue;

        /// <summary>
        /// Gets the attributes for this property.
        /// </summary>
        public WinCopies.Collections. IUIntIndexedCollection<ObjectPropertyAttribute> Attributes
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

        /// <summary>
        /// Gets the current property info.
        /// </summary>
        public IPropertyInfo PropertyInfo { get; internal set; }

        /// <summary>
        /// Gets a value that indicates whether the current property is set.
        /// </summary>
        public bool IsSet
        {

            get
            {

                bool result;

                using (PropVariant propVariant = GetPropVariant())

                    result = !IsBlank(propVariant);

                return result;

            }
        }

        private bool IsBlank(in PropVariant propVariant) => propVariant.VarType == VarEnum.VT_HRESULT;

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

        /// <summary>
        /// Gets or sets a value that indicates whether the current property supports setting a truncated value.
        /// </summary>
        public bool AllowSetTruncatedValue { get => IsDisposed ? throw new InvalidOperationException("The current object is disposed.") : _allowSetTruncatedValue; set => _allowSetTruncatedValue = IsDisposed ? throw new InvalidOperationException("The current object is disposed.") : value; }

        /// <summary>
        /// Gets the value of this property.
        /// </summary>
        public (Type type, object value) GetValue()
        {

            if (IsDisposed)

                throw new InvalidOperationException("The current object is disposed.");

            if (!PropertyInfo.IsReadable)

                throw new PropertySystemException("This property is not readable.");

            (Type, object) result;

            using (PropVariant propVariant = GetPropVariant())

            {

                if (IsBlank(propVariant))

                    throw new PropertySystemException("This property is not set.");

                result = (NativePropertyHelper.VarEnumToSystemType(propVariant.VarType), propVariant.Value);

            }

            return result;

        }

        /// <summary>
        /// <para>Sets the value of this property.</para>
        /// <para>The value of the property is cleared if the value is set to null.</para>
        /// </summary>
        public void SetValue(object value)
        {

            if (IsDisposed)

                throw new InvalidOperationException("The current object is disposed.");

            if (!PropertyInfo.IsReadOnly) throw new PropertySystemException("This property is read-only.");

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

        public void RemoveProperty()
        {

            if (IsDisposed)

                throw new InvalidOperationException("The current object is disposed.");

            if (!PropertyInfo.IsRemovable)

                throw new PropertySystemException("This property is not removable.");

            _ = _propertyCollection.NativePropertiesCollection.Delete(PropertyKey);

        }

        #region IDisposable Support
        /// <summary>
        /// Gets a value that indicates whether the current object is disposed.
        /// </summary>
        public bool IsDisposed { get; private set; } = false;

        // ~ObjectProperty()
        // {
        //   Dispose(false);
        // }

        /// <summary>
        /// Frees all resources for the current property.
        /// </summary>
        public void Dispose()
        {
            if (!IsDisposed)
            {
                _propertyCollection = null;
                _nativePropertyValuesCollection = null;
                _attributes = null;
                PropertyInfo = null;
                _allowSetTruncatedValue = false;

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
        #endregion

        #region IEquatable Support


        /// <summary>
        /// Checks if the current property is equal to a given <see cref="IObjectProperty"/>.
        /// </summary>
        /// <param name="other">The <see cref="IObjectProperty"/> to check equality.</param>
        /// <returns><see langword="true"/> if the <paramref name="other"/> is equal to the current <see cref="IObjectProperty"/>, otherwise <see langword="false"/>.</returns>
        public bool Equals(IObjectProperty other) => other?.PropertyKey.Equals(PropertyKey) == true;

        #endregion

    }

    public sealed class ObjectPropertyAttribute : IEquatable<ObjectPropertyAttribute>
    {
        internal ObjectPropertyAttribute(in PropertyKey propertyKey, in Type type, in object value)

        {

            PropertyKey = propertyKey;

            Type = type;

            Value = value;

        }

        /// <summary>
        /// Gets the current attribute value.
        /// </summary>
        public object Value { get; private set; }

        /// <summary>
        /// Gets the current attribute value type.
        /// </summary>
        public Type Type { get; private set; }

        /// <summary>
        /// Gets the <see cref="PropertyKey"/> that identifies the current property attribute.
        /// </summary>
        public PropertyKey PropertyKey { get; private set; }

        /// <summary>
        /// Checks if the current property is equal to a given property attribute.
        /// </summary>
        /// <param name="other">The property attribute to check equality.</param>
        /// <returns><see langword="true"/> if the <paramref name="other"/> is equal to the current property attribute, otherwise <see langword="false"/>.</returns>
        public bool Equals(ObjectPropertyAttribute other) => other?.PropertyKey.Equals(PropertyKey) == true;

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
