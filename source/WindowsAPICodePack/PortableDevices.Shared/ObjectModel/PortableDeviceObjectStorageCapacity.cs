//Copyright (c) Pierre Sprimont.  All rights reserved.

using Microsoft.WindowsAPICodePack.COMNative.Shell.PropertySystem;

namespace Microsoft.WindowsAPICodePack.PortableDevices
{
    public interface IPortableDeviceObjectStorageCapacity
    {
        ulong Capacity { get; }

        ulong FreeSpaceInBytes { get; }
    }

    public sealed class PortableDeviceObjectStorageCapacity : IPortableDeviceObjectStorageCapacity
    {
        private readonly IPortableDeviceObject _portableDeviceObject;
        private readonly ulong _capacity;

        public ulong Capacity
        {
            get
            {
                _portableDeviceObject.ThrowIfOperationIsNotAllowed();

                return _capacity;
            }
        }

        public ulong FreeSpaceInBytes
        {
            get
            {
                _portableDeviceObject.ThrowIfOperationIsNotAllowed();

                return _portableDeviceObject.Properties.TryGetValue(PropertySystem.Properties.Storage.FreeSpaceInBytes, out WindowsAPICodePack.PropertySystem.Property objectProperty) && objectProperty.TryGetValue(out ulong value) ? value : throw new PropertySystemException("Cannot read property.");
            }
        }

        public PortableDeviceObjectStorageCapacity(in IPortableDeviceObject portableDeviceObject, in ulong capacity)
        {
            _portableDeviceObject = portableDeviceObject;

            _capacity = capacity;
        }
    }
}
