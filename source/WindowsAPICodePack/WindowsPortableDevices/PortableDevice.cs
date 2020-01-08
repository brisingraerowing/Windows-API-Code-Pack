using Microsoft.WindowsAPICodePack.Shell;
using Microsoft.WindowsAPICodePack.Shell.Registry;
using Microsoft.WindowsAPICodePack.Win32Native.Core;
using Microsoft.WindowsAPICodePack.Win32Native.PortableDevices;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.WindowsAPICodePack.PortableDevices
{
    [DebuggerDisplay("{FriendlyName}, {DeviceDescription}, {Manufacturer}")]
    public class PortableDevice : IPortableDevice
    {

        public PortableDeviceManager PortableDeviceManager { get; internal set; }

        private Microsoft.WindowsAPICodePack.Win32Native.PortableDevices.IPortableDevice _portableDevice = null;

        public string DeviceId { get; }

        public string DeviceFriendlyName { get; internal set; }

        public string DeviceDescription { get; internal set; }

        public string DeviceManufacturer { get; internal set; }

        internal PortableDevice(PortableDeviceManager portableDeviceManager, string deviceId)

        {

            PortableDeviceManager = portableDeviceManager;

            DeviceId = deviceId;

            uint length = 0;

            Marshal.ThrowExceptionForHR((int)PortableDeviceManager.Manager.GetDeviceFriendlyName(DeviceId, null, length));

            var stringBuilder = new StringBuilder((int)length);

            Marshal.ThrowExceptionForHR((int)PortableDeviceManager.Manager.GetDeviceFriendlyName(DeviceId, stringBuilder, ref length));

            DeviceFriendlyName = stringBuilder.ToString();

            length = 0;

            Marshal.ThrowExceptionForHR((int)PortableDeviceManager.Manager.GetDeviceDescription(DeviceId, null, length));

            stringBuilder = new StringBuilder((int)length);

            Marshal.ThrowExceptionForHR((int)PortableDeviceManager.Manager.GetDeviceDescription(DeviceId, stringBuilder, ref length));

            DeviceDescription = stringBuilder.ToString();

            length = 0;

            Marshal.ThrowExceptionForHR((int)PortableDeviceManager.Manager.GetDeviceManufacturer(DeviceId, null, length));

            stringBuilder = new StringBuilder((int)length);

            Marshal.ThrowExceptionForHR((int)PortableDeviceManager.Manager.GetDeviceManufacturer(DeviceId, stringBuilder, ref length));

            DeviceManufacturer = stringBuilder.ToString();



            _portableDevice = new Microsoft.WindowsAPICodePack.Win32Native.PortableDevices.PortableDevice();

        }

        public void GetDeviceDeviceProperty(string propertyName, object defaultValue, out RegistryValueKind valueKind)

        {

            uint pcbData = 0;

            RegistryValueKind _valueKind = RegistryValueKind.None;

            // todo: if (HRESULT_FROM_WIN32(ERROR_INSUFFICIENT_BUFFER))

            PortableDeviceManager.Manager.GetDeviceProperty(DeviceId, propertyName, null, ref pcbData, _valueKind);

            byte[] bytes = new byte[pcbData];

            if (    PortableDeviceManager.Manager.GetDeviceProperty(DeviceId, propertyName, ref bytes, ref pcbData, _valueKind) == HResult.Ok )

                switch (_valueKind)

                {

                    case RegistryValueKind.String:

                }

        }
    }
}
