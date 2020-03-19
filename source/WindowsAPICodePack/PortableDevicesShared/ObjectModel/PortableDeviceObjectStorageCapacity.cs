//Copyright (c) Pierre Sprimont.  All rights reserved.

using Microsoft.WindowsAPICodePack.Win32Native.Shell.PropertySystem;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.WindowsAPICodePack.PortableDevices
{

    public interface IPortableDeviceObjectStorageCapacity

    {

        ulong Capacity { get; }

        ulong FreeSpaceInBytes { get; }

    }

    public sealed class PortableDeviceObjectStorageCapacity : IPortableDeviceObjectStorageCapacity

    {

        private            PortableDeviceObject            _portableDeviceObject;

        private ulong _capacity;

        public ulong Capacity { get { _portableDeviceObject.ThrowIfOperationIsNotAllowed(); return _capacity; } }

        public ulong FreeSpaceInBytes

        {

            get

            {

                _portableDeviceObject.ThrowIfOperationIsNotAllowed();

                if (_portableDeviceObject.Properties.TryGetValue(PropertySystem.Properties.Storage.FreeSpaceInBytes, out WindowsAPICodePack.PropertySystem.Property objectProperty) && objectProperty.TryGetValue(out ulong value))

                    return value;

                else

                    throw new PropertySystemException("Cannot read property.");

            }

        }

        public PortableDeviceObjectStorageCapacity(            PortableDeviceObject            portableDeviceObject, ulong capacity)

        {

            _portableDeviceObject = portableDeviceObject;

            _capacity = capacity;

        }
    }
}
