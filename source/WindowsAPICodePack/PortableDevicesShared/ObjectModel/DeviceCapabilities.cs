//Copyright (c) Pierre Sprimont.  All rights reserved.

using Microsoft.WindowsAPICodePack.PropertySystem;
using Microsoft.WindowsAPICodePack.COMNative.PortableDevices;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using static Microsoft.WindowsAPICodePack.COMNative.PortableDevices.PortableDeviceHelper;

namespace Microsoft.WindowsAPICodePack.PortableDevices
{
    public interface IDeviceCapabilities

    {

        WindowsAPICodePack.PropertySystem.ReadOnlyCollection<PropertyKey> Commands { get; }

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

        private WindowsAPICodePack.PropertySystem.ReadOnlyCollection<PropertyKey> _commands;

        public WindowsAPICodePack.PropertySystem.ReadOnlyCollection<PropertyKey> Commands

        {

            get

            {

                if (_commands is null)

                {

                    ThrowWhenFailHResult(_portableDeviceCapabilities.GetSupportedCommands(out COMNative.PortableDevices.PropertySystem.IPortableDeviceKeyCollection supportedCommands));

                    _commands = new WindowsAPICodePack.PropertySystem.ReadOnlyCollection<PropertyKey>(new NativeReadOnlyPropertyKeyCollection(supportedCommands));

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
