using Microsoft.WindowsAPICodePack.Win32Native;
using Microsoft.WindowsAPICodePack.Win32Native.PropertySystem;
using Microsoft.WindowsAPICodePack.Win32Native.Shell.PropertySystem;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.WindowsAPICodePack.PropertySystem
{
    public struct NativeObjectProperty
    {

        public PropertyKey PropertyKey { get; }

        public PropVariant PropVariant { get; }

        internal NativeObjectProperty(PropertyKey propertyKey, PropVariant propVariant)
        {
            PropertyKey = propertyKey;

            PropVariant = propVariant;
        }
    }

    public interface INativePropertiesCollection
    {
        HResult GetAt(uint index, ref PropertyKey propertyKey);

        HResult GetCount(out uint count);

        HResult GetValues(out IReadOnlyNativePropertyValuesCollection values);

        HResult GetAttributes(ref PropertyKey propertyKey, out IReadOnlyNativePropertyValuesCollection attributes);

        HResult SetValues(ref IEnumerable<NativeObjectProperty> values, out IReadOnlyNativePropertyValuesCollection results);
    }

    public interface IReadOnlyNativePropertyValuesCollection

    {
        HResult GetAt(uint index, ref PropertyKey propertyKey, ref PropVariant propVariant);

        HResult GetCount(out uint count);

        HResult GetValue(ref PropertyKey propertyKey, out PropVariant propVariant);

    }

    public interface INativePropertyValuesCollection : IReadOnlyNativePropertyValuesCollection

    {

        HResult SetValue(ref PropertyKey propertyKey, ref PropVariant propVariant);

    }
}
