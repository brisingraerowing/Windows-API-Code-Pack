using Microsoft.WindowsAPICodePack.COMNative.PropertySystem;
using Microsoft.WindowsAPICodePack.COMNative.Shell.PropertySystem;
using Microsoft.WindowsAPICodePack.Win32Native;
using Microsoft.WindowsAPICodePack.Win32Native.PropertySystem;
using Microsoft.WindowsAPICodePack.Win32Native.Shell.Resources;

using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

using WinCopies;

namespace Microsoft.WindowsAPICodePack.PropertySystem
{
    /// <summary>
    /// This class wraps native <see cref="PropVariant"/>s into managed objects. Please note that the Shell API, however, has its own managed wrapper, the <c>ShellProperty</c> class.
    /// </summary>
    public sealed class Property : IProperty, IEquatable<IProperty>
    {
        private PropertyCollection _propertyCollection;
        private PropertyKey _propertyKey;
        private
#if WAPICP3
    WinCopies.Collections.DotNetFix.Generic.IReadOnlyUIntIndexedList
#else
    WinCopies.Collections.IUIntIndexedCollection
#endif
            <PropertyAttribute> _attributes;
        private bool _allowSetTruncatedValue;

        public bool TryGetValue<T>(out T value)
        {
            if (IsSet)
            {
                bool? _value = PropertyInfo.IsReadable;

                if ((_value.HasValue && _value.Value) || !_value.HasValue)

                    try
                    {
                        object result = GetValue(out Type resultType);

                        Debug.WriteLine($"The given value is from {resultType} type and is {result}.");

                        if (resultType == typeof(T))
                        {
                            value = (T)result;

                            return true;
                        }
                    }

                    catch (PropertySystemException)
                    {

                    }
            }

            value = default;

            return false;
        }

        /// <summary>
        /// Gets the attributes for this property.
        /// </summary>
        public
#if WAPICP3
    WinCopies.Collections.DotNetFix.Generic.IReadOnlyUIntIndexedList
#else
    WinCopies.Collections.IUIntIndexedCollection
#endif
            <PropertyAttribute> Attributes
        {
            get
            {
                if (IsDisposed)

                    throw new InvalidOperationException("The current object is disposed.");

                if (_attributes is null)
                {
                    PropertyKey propertyKey = _propertyKey;

                    CoreErrorHelper.ThrowExceptionForHResult(_propertyCollection.Items.GetAttributes(ref propertyKey, out IDisposableReadOnlyNativePropertyValuesCollection attributes));

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
                HResult hr = GetPropVariant(out PropVariant propVariant);

                if (CoreErrorHelper.Succeeded(hr))
                {
                    bool result = !IsBlank(propVariant);

                    propVariant.Dispose();

                    return result;
                }

                else
                {
                    propVariant.Dispose();

                    throw new PropertySystemException("An error has occurred. This property may be not readable.", (int)hr);
                }
            }
        }

        /// <summary>
        /// Gets or sets a value that indicates whether the current property supports setting a truncated value.
        /// </summary>
        public bool AllowSetTruncatedValue { get => IsDisposed ? throw new InvalidOperationException("The current object is disposed.") : _allowSetTruncatedValue; set => _allowSetTruncatedValue = IsDisposed ? throw new InvalidOperationException("The current object is disposed.") : value; }

        private static bool IsBlank(in PropVariant propVariant) => propVariant.VarType == VarEnum.VT_HRESULT;

        internal Property(in PropertyCollection propertyCollection, in PropertyKey propertyKey, in IPropertyInfo propertyInfo)
        {
            _propertyCollection = propertyCollection;

            _propertyKey = propertyKey;

            PropertyInfo = propertyInfo;
        }

        private void StorePropVariantValue(PropVariant propVar)
        {
            PropertyKey propertyKey = PropertyKey;

            HResult result = _propertyCollection.NativePropertyValuesCollection.SetValue(ref propertyKey, propVar);

            if (!AllowSetTruncatedValue && result == HResult.InPlaceStringTruncated)

                throw new ArgumentOutOfRangeException(nameof(propVar), LocalizedMessages.ShellPropertyValueTruncated);

            if (!CoreErrorHelper.Succeeded(result))

                throw new PropertySystemException("An error has occurred. This property may be read-only.", Marshal.GetExceptionForHR((int)result));
        }

        /// <summary>
        /// Gets the value of this property.
        /// </summary>
        public object GetValue(out Type valueType)
        {
            if (IsDisposed)

                throw new InvalidOperationException("The current object is disposed.");

#if CS7
            (Type valueType, object value)
#else
            ValueTuple<Type, object>
#endif
            result;

            if ((PropertyInfo.IsReadable.HasValue && PropertyInfo.IsReadable.Value) || !PropertyInfo.IsReadable.HasValue)
            {
                HResult hr = GetPropVariant(out PropVariant propVariant);

                if (CoreErrorHelper.Succeeded(hr))
                {
                    if (Property.IsBlank(propVariant))

                        throw new PropertySystemException("The property is not set.");

                    result =
#if !CS7
                        new ValueTuple<Type, object>
#endif
                        (NativePropertyHelper.VarEnumToSystemType(propVariant.VarType), propVariant.Value);

                    propVariant.Dispose();

                    valueType = result.
#if CS7
                        valueType
#else
                        item1
#endif
                        ;

                    return result.
#if CS7
                        value
#else
                        item2
#endif
                        ;
                }

                propVariant.Dispose();

                throw new PropertySystemException("An error has occurred. This property may be not readable.", (int)hr);
            }

            throw new PropertySystemException("An error has occurred. This property may be not readable.");
        }

        /// <summary>
        /// <para>Sets the value of this property.</para>
        /// <para>The value of the property is cleared if the value is set to null.</para>
        /// </summary>
        public void SetValue(in object value)
        {
            if (IsDisposed)

                throw new InvalidOperationException("The current object is disposed.");

            if (PropertyInfo.IsReadOnly.HasValue && PropertyInfo.IsReadOnly.Value) throw new PropertySystemException("This property is read-only.");

            if (value == null)
            {
                ClearValueInternal();

                return;
            }

            else
            {
                Type type = value.GetType();

                if (System.Nullable.GetUnderlyingType(type) != null)
                {
                    System.Reflection.PropertyInfo pi = type.GetProperty("HasValue");

                    if (!(pi == null || (bool)pi.GetValue(value, null)))
                    {
                        ClearValueInternal();

                        return;
                    }
                }
            }

            using
#if !CS8
            (
#endif
             var propVariant = PropVariant.FromObject(value)
#if CS8
             ;
#else
            )
#endif

            StorePropVariantValue(propVariant);
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

            ClearValueInternal();
        }

        private void ClearValueInternal()
        {
            using
#if !CS8
            (
#endif
             var propVar = new PropVariant()
#if CS8
             ;
#else
            )
#endif

            StorePropVariantValue(propVar);
        }

        public void RemoveProperty()
        {
            HResult hr =
                IsDisposed ?
                throw new InvalidOperationException("The current object is disposed.")
                : PropertyInfo.IsRemovable.HasValue && !PropertyInfo.IsRemovable.Value
                ? throw new PropertySystemException("This property is not removable.")
                : _propertyCollection.Items.Delete(PropertyKey);

            if (!CoreErrorHelper.Succeeded(hr))

                throw new PropertySystemException("An error has occurred. This property may be not removable.", (int)hr);
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
                _attributes = null;
                PropertyInfo = null;
                _allowSetTruncatedValue = false;

                IsDisposed = true;
            }

            // GC.SuppressFinalize(this);
        }

        private HResult GetPropVariant(out PropVariant propVariant)
        {
            PropertyKey propertyKey = _propertyKey;

            return _propertyCollection.NativePropertyValuesCollection.GetValue(ref propertyKey, out propVariant);
        }

        HResult IProperty.GetValue(out PropVariant propVariant) => GetPropVariant(out propVariant);
        #endregion

        #region IEquatable Support
        /// <summary>
        /// Checks if the current property is equal to a given <see cref="IProperty"/>.
        /// </summary>
        /// <param name="other">The <see cref="IProperty"/> to check equality.</param>
        /// <returns><see langword="true"/> if the <paramref name="other"/> is equal to the current <see cref="IProperty"/>, otherwise <see langword="false"/>.</returns>
        public bool Equals(IProperty other) => other?.PropertyKey.Equals(PropertyKey) == true;
        #endregion
    }

    public sealed class PropertyAttribute : IEquatable<PropertyAttribute>
    {
        internal PropertyAttribute(in PropertyKey propertyKey, in Type type, in object value)
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
        public bool Equals(PropertyAttribute other) => other?.PropertyKey.Equals(PropertyKey) == true;

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
