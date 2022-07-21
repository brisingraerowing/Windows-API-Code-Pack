//Copyright (c) Microsoft Corporation.  All rights reserved.  Distributed under the Microsoft Public License (MS-PL)

using Microsoft.WindowsAPICodePack.COMNative.PropertySystem;
using Microsoft.WindowsAPICodePack.COMNative.Shell;
using Microsoft.WindowsAPICodePack.COMNative.Shell.PropertySystem;
using Microsoft.WindowsAPICodePack.PropertySystem;
using Microsoft.WindowsAPICodePack.Win32Native;
using Microsoft.WindowsAPICodePack.Win32Native.PropertySystem;
using Microsoft.WindowsAPICodePack.Win32Native.Shell;
using Microsoft.WindowsAPICodePack.Win32Native.Shell.Resources;

using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Microsoft.WindowsAPICodePack.Shell.PropertySystem
{
    /// <summary>
    /// Defines a strongly-typed property object. 
    /// All writable property objects must be of this type 
    /// to be able to call the value setter.
    /// </summary>
    /// <typeparam name="T">The type of this property's value. 
    /// Because a property value can be empty, only nullable types 
    /// are allowed.</typeparam>
    public class ShellProperty<T> : IShellProperty
    {
        #region Private Fields
        private PropertyKey propertyKey;
        string imageReferencePath = null;
        int? imageReferenceIconIndex;
        #endregion

        #region Private Methods
        private ShellObject ParentShellObject { get; set; }

        private IPropertyStore NativePropertyStore { get; set; }

        private void GetImageReference()
        {
            IPropertyStore store = ShellPropertyCollection.CreateDefaultPropertyStore(ParentShellObject);

            using
#if !CS8
                (
#endif
            var propVar = new PropVariant()
#if CS8
            ;
#else
            )
            {
#endif
                _ = store.GetValue(ref propertyKey, propVar);

                _ = Marshal.ReleaseComObject(store);

                store = null;

                ((IPropertyDescription2)Description.NativePropertyDescription).GetImageReferenceForValue(
                    propVar, out string refPath);

                if (refPath == null) return;

                int index = Win32Native.Shell.Shell.PathParseIconLocation(ref refPath);

                if (refPath != null)
                {
                    imageReferencePath = refPath;
                    imageReferenceIconIndex = index;
                }
#if !CS8
            }
#endif
        }

        private void StorePropVariantValue(PropVariant propVar)
        {
            var guid = new Guid(NativeAPI.Guids.Shell.IPropertyStore);

            IPropertyStore writablePropStore = null;

            try
            {
                int hr = ParentShellObject.NativeShellItem2.GetPropertyStore(
                        GetPropertyStoreOptions.ReadWrite,
                        ref guid,
                        out writablePropStore);

                HResult result = CoreErrorHelper.Succeeded(hr) ? writablePropStore.SetValue(ref propertyKey, propVar) : throw new PropertySystemException(LocalizedMessages.ShellPropertyUnableToGetWritableProperty,
                        Marshal.GetExceptionForHR(hr));

                _ = AllowSetTruncatedValue && result == HResult.InPlaceStringTruncated ? CoreErrorHelper.Succeeded(result) ? writablePropStore.Commit() : throw new PropertySystemException(LocalizedMessages.ShellPropertySetValue, Marshal.GetExceptionForHR((int)result)) : throw new ArgumentOutOfRangeException(nameof(propVar), LocalizedMessages.ShellPropertyValueTruncated);
            }

            catch (InvalidComObjectException e)
            {
                throw new PropertySystemException(LocalizedMessages.ShellPropertyUnableToGetWritableProperty, e);
            }

            catch (InvalidCastException)
            {
                throw new PropertySystemException(LocalizedMessages.ShellPropertyUnableToGetWritableProperty);
            }

            finally
            {
                CoreHelpers.DisposeCOMObject(ref writablePropStore);
            }
        }
        #endregion Private Methods

        #region Public Properties
        /// <summary>
        /// Gets or sets the strongly-typed value of this property.
        /// The value of the property is cleared if the value is set to null.
        /// </summary>
        /// <exception cref="COMException">
        /// If the property value cannot be retrieved or updated in the Property System</exception>
        /// <exception cref="NotSupportedException">If the type of this property is not supported; e.g. writing a binary object.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if <see cref="AllowSetTruncatedValue"/> is false, and either 
        /// a string value was truncated or a numeric value was rounded.</exception>        
        public T
#if CS9
            ?
#endif
            Value
        {
            get
            {
                // Make sure we load the correct type
                Debug.Assert(ValueType == NativePropertyHelper.VarEnumToSystemType(Description.VarEnumType));

                using
#if !CS8
                (
#endif
                var propVar = new PropVariant()
#if CS8
                ;
#else
                )
                {
#endif
                    if (ParentShellObject.NativePropertyStore != null)

                        // If there is a valid property store for this shell object, then use it.
                        _ = ParentShellObject.NativePropertyStore.GetValue(ref propertyKey, propVar);

                    else if (ParentShellObject != null)

                        // Use IShellItem2.GetProperty instead of creating a new property store
                        // The file might be locked. This is probably quicker, and sufficient for what we need
                        ParentShellObject.NativeShellItem2.GetProperty(ref propertyKey, propVar);

                    else if (NativePropertyStore != null)

                        _ = NativePropertyStore.GetValue(ref propertyKey, propVar);

                    //Get the value
                    object value = propVar.Value;

                    if (value == null)

                        return default;

                    Type type = typeof(T);

                    if (type.IsValueType)

                        value = (type = Nullable.GetUnderlyingType(type) ?? type).IsEnum ? Enum.ToObject(type, Convert.ChangeType(value,
#if CS8
                            type.GetEnumUnderlyingType()
#else
                            Enum.GetUnderlyingType(type)
#endif
                        )) : Convert.ChangeType(value, type);

                    return (T)value;
#if !CS8
                }
#endif
            }

            set
            {
                // Make sure we use the correct type
                Debug.Assert(ValueType == NativePropertyHelper.VarEnumToSystemType(Description.VarEnumType));

                Type getType(Type type) => (type = Nullable.GetUnderlyingType(type) ?? type).IsEnum ?
#if CS8
                    type.GetEnumUnderlyingType()
#else
                    Enum.GetUnderlyingType(type)
#endif
                    : type;

                if (getType(typeof(T)) == getType(ValueType) ? value == null : throw new NotSupportedException(
                    string.Format(System.Globalization.CultureInfo.InvariantCulture,
                    LocalizedMessages.ShellPropertyWrongType, ValueType.Name)))
                {
                    ClearValue();

                    return;
                }

                using (ShellPropertyWriter propertyWriter = ParentShellObject == null && NativePropertyStore != null ? throw new InvalidOperationException(LocalizedMessages.ShellPropertyCannotSetProperty) : ParentShellObject.Properties.GetPropertyWriter())

                    propertyWriter.WriteProperty<T>(this, value, AllowSetTruncatedValue);
            }
        }
        #endregion Public Properties

        #region Constructors
        private ShellProperty(in PropertyKey propertyKey,
            in ShellPropertyDescription description)
        {
            this.propertyKey = propertyKey;
            Description = description;
            AllowSetTruncatedValue = false;
        }

        /// <summary>
        /// Constructs a new Property object.
        /// </summary>
        internal ShellProperty(
            PropertyKey propertyKey,
            ShellPropertyDescription description,
            ShellObject parent) : this(propertyKey, description) =>

            ParentShellObject = parent;

        /// <summary>
        /// Constructs a new Property object
        /// </summary>
        internal ShellProperty(
            PropertyKey propertyKey,
            ShellPropertyDescription description,
            IPropertyStore propertyStore) : this(propertyKey, description) =>

            NativePropertyStore = propertyStore;
        #endregion

        #region IProperty Members
        /// <summary>
        /// Gets the property key identifying this property.
        /// </summary>
        public PropertyKey PropertyKey => propertyKey;

        /// <summary>
        /// Returns a formatted, Unicode string representation of a property value.
        /// </summary>
        /// <param name="format">One or more of the <see cref="PropertyDescriptionFormatOptions"/> flags 
        /// that indicate the desired format.</param>
        /// <param name="formattedString">The formatted value as a <see cref="string"/>, or <see langword="null"/> if this property 
        /// cannot be formatted for display.</param>
        /// <returns><see langword="true"/> if the method successfully locates the formatted <see cref="string"/>; otherwise <see langword="false"/>.</returns>
        public bool TryFormatForDisplay(PropertyDescriptionFormatOptions format, out string formattedString)
        {
            if (Description == null || Description.NativePropertyDescription == null)
            {
                // We cannot do anything without a property description
                formattedString = null;

                return false;
            }

            IPropertyStore store = ShellPropertyCollection.CreateDefaultPropertyStore(ParentShellObject);

            using
#if !CS8
            (
#endif
                var propVar = new PropVariant()
#if CS8
                ;
#else
            )
            {
#endif
                _ = store.GetValue(ref propertyKey, propVar);

                // Release the Propertystore
                _ = Marshal.ReleaseComObject(store);
                store = null;

                HResult hr = Description.NativePropertyDescription.FormatForDisplay(propVar, ref format, out formattedString);

                // Sometimes, the value cannot be displayed properly, such as for blobs
                // or if we get argument exception
                if (CoreErrorHelper.Succeeded(hr))

                    return true;

                formattedString = null;

                return false;
#if !CS8
            }
#endif
        }

        /// <summary>
        /// Returns a formatted, Unicode string representation of a property value.
        /// </summary>
        /// <param name="format">One or more of the PropertyDescriptionFormat flags 
        /// that indicate the desired format.</param>
        /// <returns>The formatted value as a string, or null if this property 
        /// cannot be formatted for display.</returns>
        public string FormatForDisplay(PropertyDescriptionFormatOptions format)
        {
            if (Description == null || Description.NativePropertyDescription == null)

                // We cannot do anything without a property description
                return null;

            IPropertyStore store = ShellPropertyCollection.CreateDefaultPropertyStore(ParentShellObject);

            using
#if !CS8
            (
#endif
                var propVar = new PropVariant()
#if CS8
                ;
#else
            )
            {
#endif
                _ = store.GetValue(ref propertyKey, propVar);

                // Release the Propertystore
                _ = Marshal.ReleaseComObject(store);
                store = null;

                HResult hr = Description.NativePropertyDescription.FormatForDisplay(propVar, ref format, out string formattedString);

                // Sometimes, the value cannot be displayed properly, such as for blobs
                // or if we get argument exception
                return CoreErrorHelper.Succeeded(hr) ? formattedString : throw new ShellException(hr);
#if !CS8
            }
#endif
        }

        /// <summary>
        /// Get the property description object.
        /// </summary>
        public ShellPropertyDescription Description { get; }

        /// <summary>
        /// Gets the case-sensitive name of a property as it is known to the system,
        /// regardless of its localized name.
        /// </summary>
        public string CanonicalName => Description.CanonicalName;

        /// <summary>
        /// Clears the value of the property.
        /// </summary>
        public void ClearValue()
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

        /// <summary>
        /// Gets the value for this property using the generic Object type.
        /// To obtain a specific type for this value, use the more type strong
        /// Property&lt;T&gt; class.
        /// Also, you can only set a value for this type using Property&lt;T&gt;
        /// </summary>
        public object ValueAsObject
        {
            get
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
                {
#endif
                    if (ParentShellObject != null)
                    {
                        IPropertyStore store = ShellPropertyCollection.CreateDefaultPropertyStore(ParentShellObject);

                        _ = store.GetValue(ref propertyKey, propVar);

                        CoreHelpers.DisposeCOMObject(ref store);
                    }

                    else

                        _ = NativePropertyStore?.GetValue(ref propertyKey, propVar);

                    return propVar?.Value;
#if !CS8
                }
#endif
            }
        }

        /// <summary>
        /// Gets the associated runtime type.
        /// </summary>
        public Type ValueType
#if DEBUG
        {
            get
            {
                // The type for this object need to match that of the description
                Type tmp;
                Type
#if CS8
                    ?
#endif
                    type = Nullable.GetUnderlyingType(tmp = typeof(T)) ?? tmp;
                Type _type = Nullable.GetUnderlyingType(tmp = Description.ValueType) ?? tmp;

                Debug.Assert(_type == (type.IsEnum ?
#if CS5
                    type.GetEnumUnderlyingType()
#else
                    Enum.GetUnderlyingType(type)
#endif
                    : type));

                return
#else
                    =>
#endif
                 Description.ValueType;
#if DEBUG
            }
        }
#endif

        /// <summary>
        /// Gets the image reference path and icon index associated with a property value (Windows 7 only).
        /// </summary>
        public IconReference IconReference
        {
            get
            {
                if (!CoreHelpers.RunningOnWin7)

                    throw new PlatformNotSupportedException(LocalizedMessages.ShellPropertyWindows7);

                GetImageReference();

                return new IconReference(imageReferencePath, imageReferenceIconIndex ?? -1);
            }
        }

        /// <summary>
        /// Gets or sets a value that determines if a value can be truncated. The default for this property is <see langword="false"/>.
        /// </summary>
        /// <remarks>
        /// An <see cref="ArgumentOutOfRangeException"/> will be thrown if
        /// this property is not set to <see langword="true"/>, and a property value was set
        /// but later truncated. 
        /// </remarks>
        public bool AllowSetTruncatedValue { get; set; }
        #endregion
    }
}
