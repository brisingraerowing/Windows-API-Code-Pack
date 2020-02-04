using Microsoft.WindowsAPICodePack.PropertySystem;
using Microsoft.WindowsAPICodePack.Win32Native;
using Microsoft.WindowsAPICodePack.Win32Native.PortableDevices;
using Microsoft.WindowsAPICodePack.Win32Native.PropertySystem;
using MS.WindowsAPICodePack.Win32Native.Shell.PropertySystem;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.WindowsAPICodePack.PortableDevices
{
    public sealed class PortableDeviceProperties : INativePropertyCollection
    {
        private IPortableDeviceKeyCollection _nativePortableDeviceKeyCollection;
        private IPortableDeviceValues _nativePortableDeviceValues;

        HResult INativePropertyCollection.GetAt(in uint index, ref PropertyKey propertyKey) => _nativePortableDeviceKeyCollection.GetAt(index, ref propertyKey);

        HResult INativePropertyCollection.GetAttributes(ref PropertyKey propertyKey, out INativePropertyAttributeCollection nativePropertyAttributeCollection) => throw new NotImplementedException();

        HResult INativePropertyCollection.GetCount(out uint count) => throw new NotImplementedException();

        HResult INativePropertyCollection.GetValue(ref PropertyKey propertyKey, out PropVariant propVariant) => _nativePortableDeviceValues.GetValue(ref propertyKey, out propVariant);

        HResult INativePropertyCollection.SetValue(ref PropertyKey propertyKey, ref PropVariant propVariant) => throw new NotImplementedException();
    }
}
