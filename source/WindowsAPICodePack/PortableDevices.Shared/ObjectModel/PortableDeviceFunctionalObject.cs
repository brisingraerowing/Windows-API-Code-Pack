//Copyright (c) Pierre Sprimont.  All rights reserved.

using Microsoft.WindowsAPICodePack.PortableDevices.PropertySystem;

using System;

namespace Microsoft.WindowsAPICodePack.PortableDevices
{
    internal sealed class PortableDeviceFunctionalObject : EnumerablePortableDeviceObject
    {
        protected override PortableDeviceFileType FileTypeOverride => PortableDeviceFileType.FunctionalObject;

        protected override Guid TypeOverride => new Guid(Guids.PropertySystem.ContentType.FunctionalObject);

        public PortableDeviceFunctionalObject(in string id, in bool isRoot, in PortableDevice parentPortableDevice, in PortableDeviceProperties properties) : this(id, isRoot, null, parentPortableDevice, properties)
        {
            // Left empty.
        }

        public PortableDeviceFunctionalObject(in string id, in bool isRoot, in PortableDeviceObject parent, in PortableDevice parentPortableDevice, in PortableDeviceProperties properties) : base(id, isRoot, parent, parentPortableDevice, properties)
        {
            // Left empty.
        }
    }
}
