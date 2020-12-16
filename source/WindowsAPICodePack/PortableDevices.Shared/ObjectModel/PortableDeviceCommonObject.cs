//Copyright (c) Pierre Sprimont.  All rights reserved.

using Microsoft.WindowsAPICodePack.PortableDevices.PropertySystem;

namespace Microsoft.WindowsAPICodePack.PortableDevices
{
    internal sealed class PortableDeviceCommonObject : NotEnumerablePortableDeviceObject
    {
        protected override PortableDeviceFileType FileTypeOverride => PortableDeviceFileType.None;

        public PortableDeviceCommonObject(in string id, in bool isRoot, in PortableDevice parentPortableDevice, in PortableDeviceProperties properties) : this(id, isRoot, null, parentPortableDevice, properties) { }

        public PortableDeviceCommonObject(in string id, in bool isRoot, in PortableDeviceObject parent, in PortableDevice parentPortableDevice, in PortableDeviceProperties properties) : base(id, isRoot, parent, parentPortableDevice, properties)
        {
            // Left empty.
        }
    }
}
