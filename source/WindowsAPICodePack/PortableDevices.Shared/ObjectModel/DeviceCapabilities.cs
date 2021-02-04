//Copyright (c) Pierre Sprimont.  All rights reserved.

using Microsoft.WindowsAPICodePack.PropertySystem;
using Microsoft.WindowsAPICodePack.COMNative.PortableDevices;

using System;
using System.Runtime.InteropServices;

using static Microsoft.WindowsAPICodePack.COMNative.PortableDevices.PortableDeviceHelper;

namespace Microsoft.WindowsAPICodePack.PortableDevices
{
    public interface IDeviceCapabilities
    {
        // todo: add the other properties
        ReadOnlyCollection<PropertyKey> Commands { get; }
    }

    public sealed class DeviceCapabilities : IDeviceCapabilities
    {
        private readonly PortableDevice _portableDevice;

        private IPortableDeviceCapabilities _portableDeviceCapabilities;

        internal DeviceCapabilities(in PortableDevice portableDevice)
        {
            _portableDevice = portableDevice ?? throw new ArgumentNullException(nameof(portableDevice));

            ThrowWhenFailHResult(_portableDevice.NativePortableDevice.Capabilities(out IPortableDeviceCapabilities portableDeviceCapabilities));

            _portableDeviceCapabilities = portableDeviceCapabilities;
        }

        private ReadOnlyCollection<PropertyKey> _commands;

        public ReadOnlyCollection<PropertyKey> Commands
        {
            get
            {
                if (_commands == null)
                {
                    ThrowWhenFailHResult(_portableDeviceCapabilities.GetSupportedCommands(out COMNative.PortableDevices.PropertySystem.IPortableDeviceKeyCollection supportedCommands));

                    _commands = new ReadOnlyCollection<PropertyKey>(new NativeReadOnlyPropertyKeyCollection(supportedCommands));
                }

                return _commands;

            }

        }

        ~DeviceCapabilities()
        {
            _ = Marshal.ReleaseComObject(_portableDeviceCapabilities);

            _portableDeviceCapabilities = null;
        }
    }
}
