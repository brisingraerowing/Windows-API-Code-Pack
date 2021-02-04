//Copyright (c) Pierre Sprimont.  All rights reserved.

using Microsoft.WindowsAPICodePack.PortableDevices.PropertySystem;

namespace Microsoft.WindowsAPICodePack.PortableDevices
{
    internal sealed class PortableDeviceCommonObject : NotEnumerablePortableDeviceObject
    {
        protected override PortableDeviceFileType FileTypeOverride => PortableDeviceFileType.None;

        public PortableDeviceCommonObject(in string id, in bool isRoot, in PortableDevice parentPortableDevice, in PortableDeviceProperties properties) : base(id, isRoot, parentPortableDevice, properties)
        {
            // Left empty.
        }

        public PortableDeviceCommonObject(in string id, in bool isRoot, in EnumerablePortableDeviceObject parent, in PortableDevice parentPortableDevice, in PortableDeviceProperties properties) : base(id, isRoot, parent, parentPortableDevice, properties)
        {
            // Left empty.
        }
    }
}
