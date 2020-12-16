//Copyright (c) Pierre Sprimont.  All rights reserved.

using Microsoft.WindowsAPICodePack.COMNative.Shell.PropertySystem;
using Microsoft.WindowsAPICodePack.PropertySystem;
using Microsoft.WindowsAPICodePack.PortableDevices.PropertySystem;

using System;

namespace Microsoft.WindowsAPICodePack.PortableDevices
{
    internal sealed class PortableDeviceFolder : EnumerablePortableDeviceObject, IPortableDeviceFolder
    {
        protected override PortableDeviceFileType FileTypeOverride => PortableDeviceFileType.Folder;

        protected override Guid TypeOverride => new Guid(Guids.PropertySystem.ContentType.Folder);

        private IPortableDeviceObjectStorageCapacity _storageCapacity;

        public IPortableDeviceObjectStorageCapacity StorageCapacity
        {
            get
            {
                ThrowIfOperationIsNotAllowed();

                return _storageCapacity ?? (_storageCapacity = Properties.TryGetValue(PortableDevices.PropertySystem.Properties.Storage.Capacity, out Property _objectProperty) && _objectProperty.TryGetValue(out ulong _value)
                        ? (IPortableDeviceObjectStorageCapacity)new PortableDeviceObjectStorageCapacity(this, _value)
                        : throw new PropertySystemException("Cannot read property."));
            }
        }

        public PortableDeviceFolder(in string id, in bool isRoot, in PortableDevice parentPortableDevice, in PortableDeviceProperties properties) : this(id, isRoot, null, parentPortableDevice, properties)
        {
            // Left empty.
        }

        public PortableDeviceFolder(in string id, in bool isRoot, in PortableDeviceObject parent, in PortableDevice parentPortableDevice, in PortableDeviceProperties properties

            ) : base(id, isRoot, parent, parentPortableDevice, properties)
        {
            // Left empty.
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            if (disposing)

                _storageCapacity = null;
        }
    }
}
