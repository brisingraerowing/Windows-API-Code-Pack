using Microsoft.WindowsAPICodePack.Win32Native.Shell.PropertySystem;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.WindowsAPICodePack.PortableDevices
{

    public interface IPortableDeviceObjectStorageCapacity

    {

        ulong Capacity { get; }

        ulong? GetFreeSpaceInBytes();

    }

    public sealed class PortableDeviceObjectStorageCapacity : IPortableDeviceObjectStorageCapacity

    {

        private IPortableDeviceObject _portableDeviceObject;

        public ulong Capacity { get; }

        public ulong? GetFreeSpaceInBytes()

        {

                if (_portableDeviceObject.Properties.TryGetValue(PropertySystem.Properties.Storage.FreeSpaceInBytes, out WindowsAPICodePack.PropertySystem.Property objectProperty) && objectProperty.TryGetValue(out ulong value))

                    return value;

                else

                    return null;

        }

        public PortableDeviceObjectStorageCapacity(IPortableDeviceObject portableDeviceObject, ulong capacity)

        {

            _portableDeviceObject = portableDeviceObject;

            Capacity = capacity;

        }
    }
}
