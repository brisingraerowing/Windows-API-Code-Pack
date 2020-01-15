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
        public string ClientName { get; }
        public uint MajorVersion { get; }
        public uint MinorVersion { get; }
        public uint Revision { get; }

        public ClientVersion(in string clientName, in uint majorVersion, in uint minorVersion, in uint revision)

        {

            ClientName = clientName;

            MajorVersion = majorVersion;

            MinorVersion = minorVersion;

            Revision = revision;

        }
    }

    public struct PortableDeviceOpeningOptions
    {

        public GenericRights GenericRights { get; }

        public FileShareOptions FileShare { get; }

        public bool ManualCloseOnDisconnect { get; }

        public PortableDeviceOpeningOptions(in GenericRights genericRights, in FileShareOptions fileShare, in bool manualCloseOnDisconnect)

        {

            GenericRights = genericRights;

            FileShare = fileShare;

            ManualCloseOnDisconnect = manualCloseOnDisconnect;

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

        public bool IsOpen { get; private set; }

        internal PortableDevice(in PortableDeviceManager portableDeviceManager, in string deviceId)

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

        public void Open(in ClientVersion clientVersion, in PortableDeviceOpeningOptions portableDeviceOpeningOptions)

        {

            if (IsDisposed)

                throw new InvalidOperationException("The current object is disposed.");

            if (IsOpen) return;

            //if ((wszPnPDeviceID == null) || (ppDevice == null))
            //{
            //    hr = HResult.InvalidArgument;
            //    return hr;
            //}

            // CoCreate an IPortableDeviceValues interface to hold the client information.
            IPortableDeviceValues pClientInformation = new PortableDeviceValues();

            // if (CoreErrorHelper.Succeeded(hr))
            // {

            // Attempt to set all properties for client information. If we fail to set
            // any of the properties below it is OK. Failing to set a property in the
            // client information isn't a fatal error.
            _ = pClientInformation.SetStringValue(Properties.Client.Name, clientVersion.ClientName);

            // Marshal.ThrowExceptionForHR((int)ClientInfoHR);

            _ = pClientInformation.SetUnsignedIntegerValue(Properties.Client.MajorVersion, clientVersion.MajorVersion);

            // Marshal.ThrowExceptionForHR((int)ClientInfoHR);

            _ = pClientInformation.SetUnsignedIntegerValue(Properties.Client.MinorVersion, clientVersion.MinorVersion);

            // Marshal.ThrowExceptionForHR((int)ClientInfoHR);

            _ = pClientInformation.SetUnsignedIntegerValue(Properties.Client.Revision, clientVersion.Revision);

            // Marshal.ThrowExceptionForHR((int)ClientInfoHR);

            // else
            // {
            // Failed to CoCreateInstance Win32Native.Guids.PortableDevices.PortableDeviceValues for client information
            // }

            Marshal.ThrowExceptionForHR((int)pClientInformation.SetUnsignedIntegerValue(Properties.Client.SecurityQualityOfService, (uint)SecurityImpersonationLevel.SecurityImpersonation << 16));

            // todo: to add an option for retrying this assignment if a higher rights setting fails (bool retryIfHigherRightsSettingFails = false)

            Marshal.ThrowExceptionForHR((int)pClientInformation.SetUnsignedIntegerValue(Properties.Client.DesiredAccess, (uint)portableDeviceOpeningOptions.GenericRights));

            Marshal.ThrowExceptionForHR((int)pClientInformation.SetUnsignedIntegerValue(Properties.Client.ShareMode, (uint)portableDeviceOpeningOptions.FileShare));

            Marshal.ThrowExceptionForHR((int)pClientInformation.SetBoolValue(Properties.Client.ManualCloseOnDisconnect, portableDeviceOpeningOptions.ManualCloseOnDisconnect));

            //if (CoreErrorHelper.Succeeded(hr))
            //{

            //if (CoreErrorHelper.Succeeded(hr))
            //{
            // Attempt to open the device using the PnPDeviceID string given
            // to this function and the newly created client information.
            // Note that we're attempting to open the device the first 
            // time using the default (read/write) access. If this fails
            // with HResult.AccessDenied, we'll attempt to open a second time
            // with read-only access.
            Marshal.ThrowExceptionForHR((int)_portableDevice.Open(DeviceId, pClientInformation));

            //if (hr == HResult.AccessDenied)
            //{

            // Attempt to open for read-only access
            //ClientInfoHR = pClientInformation.SetUnsignedIntegerValue(
            //Properties.Client.DesiredAccess,
            //(uint)GenericRights.Read);

            //Marshal.ThrowExceptionForHR((int)ClientInfoHR);

            //hr = _portableDevice.Open(DeviceId, pClientInformation);

            //Marshal.ThrowExceptionForHR((int)hr);

            //}

            // if (CoreErrorHelper.Succeeded(hr))
            // {
            // The device successfully opened, obtain an instance of the Device into
            // ppDevice so the caller can be returned an opened IPortableDevice.
            // hr = pDevice.QueryInterface(Win32Native.Guids.PortableDevices.IPortableDevice, ref ppDevice);

            // if (CoreErrorHelper.Failed(hr))
            // {
            // Failed to QueryInterface the opened IPortableDevice
            // }

            // }

            //}
            //else
            //{
            //    // Failed to CoCreateInstance Win32Native.Guids.PortableDevices.PortableDevice
            //}
            //}

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
                _ = Marshal.ReleaseComObject(pClientInformation);
            }

            // return hr;
            // }

            IsOpen = true;

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

        #region IDisposable Support

        public bool IsDisposed { get; private set; }

        protected virtual void Dispose(bool disposing)
        {

            if (!IsDisposed)
            {
                if (disposing)
                {
                    _ = PortableDeviceManager._portableDevices.Remove(this);
                    _ = PortableDeviceManager._privatePortableDevices.Remove(this);
                }

                _ = Marshal.ReleaseComObject(_portableDevice);
                _portableDevice = null;

                IsDisposed = true;
            }
        }

        ~PortableDevice()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion

    }
}
