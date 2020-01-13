using Microsoft.WindowsAPICodePack.Shell;
using Microsoft.WindowsAPICodePack.Win32Native;
using Microsoft.WindowsAPICodePack.Win32Native.PortableDevices;
using Microsoft.WindowsAPICodePack.Win32Native.PortableDevices.PropertySystem;
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
    public struct ClientVersion
    {
        public uint MajorVersion { get; }
        public uint MinorVersion { get; }
        public uint Revision { get; }

        public ClientVersion(uint majorVersion, uint minorVersion, uint revision)

        {

            MajorVersion = majorVersion;

            MinorVersion = minorVersion;

            Revision = revision;

        }
    }

    [DebuggerDisplay("{FriendlyName}, {DeviceDescription}, {Manufacturer}")]
    public class PortableDevice : IPortableDevice
    {

        public PortableDeviceManager PortableDeviceManager { get; internal set; }

        IPortableDeviceManager IPortableDevice.PortableDeviceManager => PortableDeviceManager;

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

        public void Open(string clientName, ClientVersion clientVersion)

        {

            HResult hr = HResult.Ok;
            Microsoft.WindowsAPICodePack.Win32Native.PortableDevices.PropertySystem.IPortableDeviceValues pClientInformation = null;

            //if ((wszPnPDeviceID == null) || (ppDevice == null))
            //{
            //    hr = HResult.InvalidArgument;
            //    return hr;
            //}

            // CoCreate an IPortableDeviceValues interface to hold the client information.
            pClientInformation = new Microsoft.WindowsAPICodePack.Win32Native.PortableDevices.PropertySystem.PortableDeviceValues();

            // if (CoreErrorHelper.Succeeded(hr))
            // {

            HResult ClientInfoHR = HResult.Ok;

            // Attempt to set all properties for client information. If we fail to set
            // any of the properties below it is OK. Failing to set a property in the
            // client information isn't a fatal error.
            ClientInfoHR = pClientInformation.SetStringValue(Microsoft.WindowsAPICodePack.Win32Native.PortableDevices.PropertySystem.Properties.Client.Name, clientName);

            // Marshal.ThrowExceptionForHR((int)ClientInfoHR);

            ClientInfoHR = pClientInformation.SetUnsignedIntegerValue(Microsoft.WindowsAPICodePack.Win32Native.PortableDevices.PropertySystem.Properties.Client.MajorVersion, clientVersion.MajorVersion);

            // Marshal.ThrowExceptionForHR((int)ClientInfoHR);

            ClientInfoHR = pClientInformation.SetUnsignedIntegerValue(Microsoft.WindowsAPICodePack.Win32Native.PortableDevices.PropertySystem.Properties.Client.MinorVersion, clientVersion.MinorVersion);

            // Marshal.ThrowExceptionForHR((int)ClientInfoHR);

            ClientInfoHR = pClientInformation.SetUnsignedIntegerValue(Microsoft.WindowsAPICodePack.Win32Native.PortableDevices.PropertySystem.Properties.Client.Revision, clientVersion.Revision);

            // Marshal.ThrowExceptionForHR((int)ClientInfoHR);

            // else
            // {
            // Failed to CoCreateInstance Win32Native.Guids.PortableDevices.PortableDeviceValues for client information
            // }

            ClientInfoHR = pClientInformation.SetUnsignedIntegerValue(Microsoft.WindowsAPICodePack.Win32Native.PortableDevices.PropertySystem.Properties.Client.SecurityQualityOfService,   (uint) Microsoft.WindowsAPICodePack.Win32Native.SecurityImpersonationLevel.SecurityImpersonation << 16);

            Marshal.ThrowExceptionForHR( (int) ClientInfoHR);

            if (CoreErrorHelper.Succeeded(hr))
            {

                //if (CoreErrorHelper.Succeeded(hr))
                //{
                // Attempt to open the device using the PnPDeviceID string given
                // to this function and the newly created client information.
                // Note that we're attempting to open the device the first 
                // time using the default (read/write) access. If this fails
                // with HResult.AccessDenied, we'll attempt to open a second time
                // with read-only access.
                hr = _portableDevice. Open(DeviceId, pClientInformation);

                if (hr == HResult.AccessDenied)
                {

                    // Attempt to open for read-only access
                    pClientInformation.SetUnsignedIntegerValue(
                                                               Microsoft.WindowsAPICodePack.Win32Native.PortableDevices.PropertySystem.Properties.Client.DesiredAccess,
                                                               GENERIC_READ);

                    hr = _portableDevice.Open(DeviceId, pClientInformation);

                }

                if (CoreErrorHelper.Succeeded(hr))
                {
                    // The device successfully opened, obtain an instance of the Device into
                    // ppDevice so the caller can be returned an opened IPortableDevice.
                    // hr = pDevice.QueryInterface(Win32Native.Guids.PortableDevices.IPortableDevice, ref ppDevice);

                    // if (CoreErrorHelper.Failed(hr))
                    // {
                        // Failed to QueryInterface the opened IPortableDevice
                    // }

                }

                //}
                //else
                //{
                //    // Failed to CoCreateInstance Win32Native.Guids.PortableDevices.PortableDevice
                //}
            }

            // Release the IPortableDevice when finished
            //if (pDevice != null)
            //{
            //    pDevice.Release();
            //    Marshal.ReleaseCOMObject(pDevice);
            //}

            // Release the IPortableDeviceValues that contains the client information when finished
            if (pClientInformation != null)
            {
                // pClientInformation.Release();
                Marshal.ReleaseComObject(pClientInformation);
            }

            // return hr;
        // }

    }

    public object GetDeviceProperty(string propertyName, object defaultValue, bool doNotExpand, out BlobValueKind valueKind)

    {

        uint pcbData = 0;

        BlobValueKind _valueKind = BlobValueKind.None;

        HResult hr;

        if ((hr = PortableDeviceManager.Manager.GetDeviceProperty(DeviceId, propertyName, null, ref pcbData, ref _valueKind)) == CoreErrorHelper.HResultFromWin32(ErrorCode.InsufficientBuffer))

        {

            byte[] bytes = new byte[pcbData];

            hr = PortableDeviceManager.Manager.GetDeviceProperty(DeviceId, propertyName, bytes, ref pcbData, ref _valueKind);

            if (hr == HResult.Ok)

                return BlobHelper.ToDotNetType(bytes, (valueKind = _valueKind), doNotExpand);

            else if (hr == CoreErrorHelper.HResultFromWin32(ErrorCode.InsufficientBuffer))

            {

                valueKind = BlobValueKind.None;

                return defaultValue;

            }

            else Marshal.ThrowExceptionForHR((int)hr);

        }

        Marshal.ThrowExceptionForHR((int)hr);

        valueKind = BlobValueKind.None;

        return null;

    }

}
}
