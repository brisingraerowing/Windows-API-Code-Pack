using Microsoft.WindowsAPICodePack.PropertySystem;
using Microsoft.WindowsAPICodePack.Win32Native;
using Microsoft.WindowsAPICodePack.Win32Native.PropertySystem;
using Microsoft.WindowsAPICodePack.Win32Native.Shell.PropertySystem;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.WindowsAPICodePack.Win32Native.PropertySystem
{
    public interface IProperty
    {

        PropertyKey PropertyKey { get; }

        HResult GetValue(out PropVariant propVariant);
    }

    public struct ObjectProperty : IProperty, IDisposable

    {

        public PropertyKey PropertyKey { get; private set; }

        private PropVariant _propVariant;

        public HResult GetValue(out PropVariant propVariant)
        {
            propVariant = _propVariant;

            return HResult.Ok;
        }

        public ObjectProperty(PropertyKey propertyKey, PropVariant propVariant)

        {

            PropertyKey = propertyKey;

            _propVariant = propVariant;

        }

        public void Dispose()

        {

            PropertyKey = new PropertyKey();

            _propVariant = null;

        }

    }

    public interface INativePropertiesCollection : IDisposable
    {
        HResult GetAt(in uint index, ref PropertyKey propertyKey);

        HResult GetCount(out uint count);

        HResult GetValues(out INativePropertyValuesCollection values);

        HResult GetAttributes(ref PropertyKey propertyKey, out IDisposableReadOnlyNativePropertyValuesCollection attributes);

        HResult GetPropertyInfo(ref PropertyKey propertyKey, out IPropertyInfo propertyInfo);

        HResult SetValues(ref IEnumerable<IProperty> values, out INativeReadOnlyPropertyValuesCollection results);

        HResult Delete(params PropertyKey[] properties);

        HResult Delete(in IEnumerable<PropertyKey> properties);
    }

    public interface IPropertyInfo

    {

        bool? IsReadable { get; }

        bool? IsReadOnly { get; }

        bool? IsRemovable { get; }

    }

    public sealed class PropertyInfo : IPropertyInfo

    {

        public static PropertyInfo DefaultPropertyInfo => new PropertyInfo(false, false, false);

        public bool? IsReadable { get; }

        public bool? IsReadOnly { get; }

        public bool? IsRemovable { get; }

        public PropertyInfo(bool isReadable, bool isReadOnly, bool isRemovable)

        {

            IsReadable = isReadable;

            IsReadOnly = isReadOnly;

            IsRemovable = isRemovable;

        }

    }

    public interface INativeReadOnlyPropertyValuesCollection

    {

        bool IsReadOnly { get; }

        HResult GetAt(in uint index, ref PropertyKey propertyKey, out PropVariant propVariant);

        HResult GetCount(out uint count);

        HResult GetValue(ref PropertyKey propertyKey, out PropVariant propVariant);

    }

    public interface IDisposableReadOnlyNativePropertyValuesCollection : INativeReadOnlyPropertyValuesCollection, IDisposable

    {



    }

    public interface INativePropertyValuesCollection : INativeReadOnlyPropertyValuesCollection

    {

        HResult SetValue(ref PropertyKey propertyKey, PropVariant propVariant);

    }
}
