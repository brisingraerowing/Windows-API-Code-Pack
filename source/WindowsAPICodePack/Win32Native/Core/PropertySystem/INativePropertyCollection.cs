using Microsoft.WindowsAPICodePack.Win32Native;
using Microsoft.WindowsAPICodePack.Win32Native.PropertySystem;
using Microsoft.WindowsAPICodePack.Win32Native.Shell.PropertySystem;
using MS.WindowsAPICodePack.Win32Native.Shell.PropertySystem;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.WindowsAPICodePack.PropertySystem
{
    public interface INativePropertyCollection
    {
        HResult GetAt(in uint index, ref PropertyKey propertyKey);

        HResult GetCount(out uint count);

        HResult GetValue(ref PropertyKey propertyKey, out PropVariant propVariant);

        HResult GetAttributes(ref PropertyKey propertyKey, out INativePropertyAttributeCollection nativePropertyAttributeCollection);

        HResult SetValue(ref PropertyKey propertyKey, ref PropVariant propVariant);
    }

    public interface INativePropertyAttributeCollection

    {
        HResult GetAt(uint index, ref PropertyKey propertyKey, ref PropVariant propVariant);

    }
}
