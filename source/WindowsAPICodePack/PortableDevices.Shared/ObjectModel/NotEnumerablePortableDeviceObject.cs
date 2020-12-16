//Copyright (c) Pierre Sprimont.  All rights reserved.

using Microsoft.WindowsAPICodePack.COMNative.Shell.PropertySystem;
using Microsoft.WindowsAPICodePack.PropertySystem;
using Microsoft.WindowsAPICodePack.PortableDevices.PropertySystem;

using System;

namespace Microsoft.WindowsAPICodePack.PortableDevices
{
    internal abstract class NotEnumerablePortableDeviceObject : PortableDeviceObject
    {
        private Guid? _type;

        protected sealed override Guid TypeOverride => (_type ?? (_type = Properties.TryGetValue(PropertySystem.Properties.Object.ContentType, out Property property) && property.TryGetValue(out Guid value)
                        ? value
                        : throw new PropertySystemException("Cannot read the property."))).Value;

        public NotEnumerablePortableDeviceObject(in string id, in bool isRoot, in PortableDevice parentPortableDevice, PortableDeviceProperties properties) : this(id, isRoot, null, parentPortableDevice, properties)
        {
            // Left empty.
        }

        public NotEnumerablePortableDeviceObject(in string id, in bool isRoot, in PortableDeviceObject parent, in PortableDevice parentPortableDevice, PortableDeviceProperties properties) : base(id, isRoot, parent, parentPortableDevice, properties)
        {
            // Left empty.
        }
    }
}
