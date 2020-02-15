using Microsoft.WindowsAPICodePack.PropertySystem;
using Microsoft.WindowsAPICodePack.Win32Native;
using Microsoft.WindowsAPICodePack.Win32Native.PropertySystem;
using Microsoft.WindowsAPICodePack.Win32Native.Shell.PropertySystem;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.WindowsAPICodePack.Win32Native.PropertySystem
{
    public interface IObjectProperty
    {

        PropertyKey PropertyKey { get; }

        PropVariant GetValue();
    }

    public struct ObjectProperty : IObjectProperty, IDisposable

    {

        public PropertyKey PropertyKey { get; private set; }

        private PropVariant _propVariant;

        public PropVariant GetValue() => _propVariant;

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

    public interface INativePropertiesCollection
    {
        HResult GetAt(in uint index, ref PropertyKey propertyKey);

        HResult GetCount(out uint count);

        HResult GetValues(out INativePropertyValuesCollection values);

        HResult GetAttributes(ref PropertyKey propertyKey, out IReadOnlyNativePropertyValuesCollection attributes);

        HResult SetValues(ref IEnumerable<IObjectProperty> values, out IReadOnlyNativePropertyValuesCollection results);
    }

    public interface INativePropertyInfo

    {

        HResult IsReadable(out bool isReadable);

        HResult IsReadOnly(out bool isReadOnly);

        HResult IsRemovable(out bool isRemovable);

    }

    public interface IReadOnlyNativePropertyValuesCollection

    {
        HResult GetAt(in uint index, ref PropertyKey propertyKey, ref PropVariant propVariant);

        HResult GetCount(out uint count);

        HResult GetValue(ref PropertyKey propertyKey, out PropVariant propVariant);

    }

    public interface INativePropertyValuesCollection : IReadOnlyNativePropertyValuesCollection

    {

        bool IsReadOnly { get; }

        HResult SetValue(ref PropertyKey propertyKey, ref PropVariant propVariant);

    }
}
