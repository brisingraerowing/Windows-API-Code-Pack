using Microsoft.WindowsAPICodePack.PortableDevices.Commands;
using Microsoft.WindowsAPICodePack.PortableDevices.Commands.Object;
using Microsoft.WindowsAPICodePack.PortableDevices.Commands.Service;
using Microsoft.WindowsAPICodePack.Shell;
using Microsoft.WindowsAPICodePack.Win32Native;
using Microsoft.WindowsAPICodePack.Win32Native.PortableDevices;
using Microsoft.WindowsAPICodePack.Win32Native.PortableDevices.PropertySystem;
using Microsoft.WindowsAPICodePack.Win32Native.Shell.PropertySystem;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Common = Microsoft.WindowsAPICodePack.PortableDevices.Commands.Common;
using GuidAttribute = Microsoft.WindowsAPICodePack.Win32Native.Shell.PropertySystem.GuidAttribute;

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

        public override bool Equals(object obj) => obj is ClientVersion _obj ? _obj.ClientName == ClientName && _obj.MajorVersion == MajorVersion && _obj.MinorVersion == MinorVersion && _obj.Revision == Revision : false;

        public override int GetHashCode() => ClientName.GetHashCode() ^ MajorVersion.GetHashCode() ^ MinorVersion.GetHashCode() ^ Revision.GetHashCode();

        public static bool operator ==(ClientVersion left, ClientVersion right) => left.Equals(right);

        public static bool operator !=(ClientVersion left, ClientVersion right) => !(left == right);
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

#pragma warning disable CA2243 // Attribute string literals should parse correctly
    public class SupportedCommands

    {
        [Guid(Microsoft.WindowsAPICodePack.Win32Native.Guids.PortableDevices.CommandSystem.Common)]
        private readonly Common _common;
        [Guid(Microsoft.WindowsAPICodePack.Win32Native.Guids.PortableDevices.CommandSystem.Capabilities)]
        private readonly Commands.Capability _capability;
        [Guid(Microsoft.WindowsAPICodePack.Win32Native.Guids.PortableDevices.CommandSystem.Storage)]
        private readonly Storage _storage;
        [Guid(Microsoft.WindowsAPICodePack.Win32Native.Guids.PortableDevices.CommandSystem.SMS)]
        private readonly SMS _sms;
        [Guid(Microsoft.WindowsAPICodePack.Win32Native.Guids.PortableDevices.CommandSystem.StillImageCapture)]
        private readonly StillImageCapture _stillImageCapture;
        [Guid(Microsoft.WindowsAPICodePack.Win32Native.Guids.PortableDevices.CommandSystem.MediaCapture)]
        private readonly MediaCapture _mediaCapture;
        [Guid(Microsoft.WindowsAPICodePack.Win32Native.Guids.PortableDevices.CommandSystem.DeviceHints)]
        private readonly DeviceHint _deviceHint;
        [Guid(Microsoft.WindowsAPICodePack.Win32Native.Guids.PortableDevices.CommandSystem.ClassExtensionV1)]
        [Guid(Microsoft.WindowsAPICodePack.Win32Native.Guids.PortableDevices.CommandSystem.ClassExtensionV2)]
        private readonly ClassExtension _classExtension;
        [Guid(Microsoft.WindowsAPICodePack.Win32Native.Guids.PortableDevices.CommandSystem.NetworkConfiguration)]
        private readonly NetworkConfiguration _networkConfiguration;

        public class ObjectCommands

        {
            [Guid(Microsoft.WindowsAPICodePack.Win32Native.Guids.PortableDevices.CommandSystem.Object.Enumeration)]
            private readonly Enumeration _enumeration;
            [Guid(Microsoft.WindowsAPICodePack.Win32Native.Guids.PortableDevices.CommandSystem.Object.Properties)]
            private readonly Property _property;
            [Guid(Microsoft.WindowsAPICodePack.Win32Native.Guids.PortableDevices.CommandSystem.Object.PropertiesBulk)]
            private readonly PropertyBulk _propertyBulk;
            [Guid(Microsoft.WindowsAPICodePack.Win32Native.Guids.PortableDevices.CommandSystem.Object.Resources)]
            private readonly Resource _resource;
            [Guid(Microsoft.WindowsAPICodePack.Win32Native.Guids.PortableDevices.CommandSystem.Object.Management)]
            private readonly Management _management;

            public Enumeration Enumeration => _enumeration;

            public Property Property => _property;

            public PropertyBulk PropertyBulk => _propertyBulk;

            public Resource Resource => _resource;

            public Management Management => _management;

            public ObjectCommands() { }

            public ObjectCommands(in Enumeration enumeration, in Property property, in PropertyBulk propertyBulk, in Resource resource, in Management management)

            {

                _enumeration = enumeration;

                _property = property;

                _propertyBulk = propertyBulk;

                _resource = resource;

                _management = management;

            }

        }

        public class ServiceCommands

        {
            [Guid(Microsoft.WindowsAPICodePack.Win32Native.Guids.PortableDevices.CommandSystem.Service.Common)]
            private readonly Commands.Service.Common _common;
            [Guid(Microsoft.WindowsAPICodePack.Win32Native.Guids.PortableDevices.CommandSystem.Service.Capabilities)]
            private readonly Commands.Service.Capability _capability;
            [Guid(Microsoft.WindowsAPICodePack.Win32Native.Guids.PortableDevices.CommandSystem.Service.Methods)]
            private readonly Method _method;

            public Commands.Service.Common Common => _common;

            public Commands.Service.Capability Capability => _capability;

            public Method Method => _method;

            public ServiceCommands() { }

            public ServiceCommands(in Commands.Service.Common common, in Commands.Service.Capability capability, in Method method)

            {

                _common = common;

                _capability = capability;

                _method = method;

            }

        }

        public Common Common => _common;

        public ObjectCommands Object { get; }

        public Commands.Capability Capability => _capability;

        public Storage Storage => _storage;

        public SMS SMS => _sms;

        public StillImageCapture StillImageCapture => _stillImageCapture;

        public MediaCapture MediaCapture => _mediaCapture;

        public DeviceHint DeviceHint => _deviceHint;

        public ClassExtension ClassExtension => _classExtension;

        public NetworkConfiguration NetworkConfiguration => _networkConfiguration;

        public ServiceCommands Service { get; }

        public SupportedCommands() { Object = new ObjectCommands(); Service = new ServiceCommands(); }

        public SupportedCommands(in Common common, in ObjectCommands @object, in Commands.Capability capability, in Storage storage, in SMS sms, in StillImageCapture stillImageCapture, in MediaCapture mediaCapture, in DeviceHint deviceHint, in ClassExtension classExtension, in NetworkConfiguration networkConfiguration, in ServiceCommands service)

        {

            _common = common;

            Object = @object;

            _capability = capability;

            _storage = storage;

            _sms = sms;

            _stillImageCapture = stillImageCapture;

            _mediaCapture = mediaCapture;

            _deviceHint = deviceHint;

            _classExtension = classExtension;

            _networkConfiguration = networkConfiguration;

            Service = service;

        }

    }
#pragma warning restore CA2243 // Attribute string literals should parse correctly

    public class DeviceCapabilities : IDisposable

    {

        private readonly PortableDevice _portableDevice;

        private readonly IPortableDeviceCapabilities _portableDeviceCapabilities;

        public DeviceCapabilities(in PortableDevice portableDevice)
        {
            _portableDevice = portableDevice ?? throw new ArgumentNullException(nameof(portableDevice));

            Marshal.ThrowExceptionForHR((int)_portableDevice._portableDevice.Capabilities(out _portableDeviceCapabilities));
        }

        private SupportedCommands _commands;

        public SupportedCommands Commands

        {

            get

            {

                if (_commands is null)

                {

                    Marshal.ThrowExceptionForHR((int)_portableDeviceCapabilities.GetSupportedCommands(out IPortableDeviceKeyCollection supportedCommands));

                    uint count = 0;

                    Marshal.ThrowExceptionForHR((int)supportedCommands.GetCount(ref count));

                    PropertyKey propertyKey;

                    PropertyKeyAttribute propertyKeyAttribute;

                    string @namespace = typeof(Microsoft.WindowsAPICodePack.PortableDevices.Commands.Commands).Namespace;

                    List<TypeInfo> commandEnums = Assembly.GetExecutingAssembly().DefinedTypes.Where(t => t.IsEnum && t.Namespace.StartsWith(@namespace, StringComparison.Ordinal)).ToList();

                    var commands = new SupportedCommands();

                    Type supportedCommandsType = typeof(SupportedCommands);

                    Type[] nestedSupportedCommandsTypes = typeof(SupportedCommands).GetNestedTypes();

                    for (uint i = 0; i < count; i++) // We browse all the given property keys.

                    {

                        propertyKey = new PropertyKey();

                        Marshal.ThrowExceptionForHR((int)supportedCommands.GetAt(i, ref propertyKey)); // We get the property key at the current index.

                        void setSupportedCommand()

                        {

                            foreach (TypeInfo t in commandEnums) // We browse the enums of the commands namespace.

                            {

                                FieldInfo[] fields = t.GetFields();

                                foreach (FieldInfo f in fields) // We browse the fields (the enum values) of the current enum.

                                {

                                    propertyKeyAttribute = f.GetCustomAttributes<PropertyKeyAttribute>().FirstOrDefault(); // As only one PropertyKeyAttribute is allowed by field, we get the first PropertyKeyAttribute of the current enum field.

                                    if (propertyKeyAttribute?.Guid == propertyKey.FormatId.ToString() && propertyKeyAttribute.PropertyId == propertyKey.PropertyId) // If the property keys are equal, we know that the command corresponding to the current enum field is supported.

                                    {

                                        bool browseFields(in IEnumerable<FieldInfo> _fields, in object obj)

                                        {

                                            foreach (FieldInfo _f in _fields) // We browse the fields of the SupportedCommands class.

                                                if (_f.GetCustomAttributes<GuidAttribute>().Where(a => a.Guid == propertyKeyAttribute.Guid).FirstOrDefault() is object) // If a field has a GuidAttribute whose the Guid is the same as the Guid of the enum field's PropertyKeyAttribute,

                                                {

                                                    _f.SetValue(obj, (uint)_f.GetValue(obj) | (uint)f.GetValue(null)); // we set this field with the previous value of this field combined with the value of the current enum field.

                                                    return true;

                                                }

                                            return false;

                                        }

                                        if (!browseFields(supportedCommandsType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance), commands))

                                            foreach (Type nestedSupportedCommandsType in nestedSupportedCommandsTypes)

                                                if (browseFields(nestedSupportedCommandsType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance), supportedCommandsType.GetProperty(nestedSupportedCommandsType.Name.Remove(nestedSupportedCommandsType.Name.Length - "Commands".Length)).GetValue(commands)))

                                                    return;

                                    }

                                }

                            }

                        }

                        setSupportedCommand();

                    }

                    _commands = commands;

                    _ = Marshal.FinalReleaseComObject(supportedCommands);

                }

                return _commands;

            }

        }

    }

    [DebuggerDisplay("{FriendlyName}, {DeviceDescription}, {Manufacturer}")]
    public class PortableDevice : IPortableDevice
    {

        /// <summary>
        /// If the current <see cref="PortableDevice"/> has been created by a <see cref="PortableDevices.PortableDeviceManager"/>, gets that manager, otherwise this property gets <see langword="null"/>.
        /// </summary>
        public PortableDeviceManager PortableDeviceManager { get; internal set; }

        IPortableDeviceManager IPortableDevice.PortableDeviceManager => PortableDeviceManager;

        internal Win32Native.PortableDevices.IPortableDevice _portableDevice = null;

        private DeviceCapabilities _deviceCapabilities = null;

        public DeviceCapabilities DeviceCapabilities => _deviceCapabilities ?? (_deviceCapabilities = new DeviceCapabilities(this));

        /// <summary>
        /// Gets the device id of the current <see cref="PortableDevice"/>.
        /// </summary>
        public string DeviceId { get; }

        /// <summary>
        /// If the current <see cref="PortableDevice"/> has been created by a <see cref="PortableDevices.PortableDeviceManager"/>, gets the device friendly name of the current <see cref="PortableDevice"/>, otherwise gets <see langword="null"/>.
        /// </summary>
        public string DeviceFriendlyName { get; internal set; }

        /// <summary>
        /// If the current <see cref="PortableDevice"/> has been created by a <see cref="PortableDevices.PortableDeviceManager"/>, gets the device description of the current <see cref="PortableDevice"/>, otherwise gets <see langword="null"/>.
        /// </summary>
        public string DeviceDescription { get; internal set; }

        /// <summary>
        /// If the current <see cref="PortableDevice"/> has been created by a <see cref="PortableDevices.PortableDeviceManager"/>, gets the device manufacturer of the current <see cref="PortableDevice"/>, otherwise gets <see langword="null"/>.
        /// </summary>
        public string DeviceManufacturer { get; internal set; }

        public bool IsOpen { get; private set; }

        internal PortableDevice(in PortableDeviceManager portableDeviceManager, in string deviceId)

        {

            PortableDeviceManager = portableDeviceManager;

            DeviceId = deviceId;

            uint length = 0;

            Marshal.ThrowExceptionForHR((int)PortableDeviceManager._Manager.GetDeviceFriendlyName(DeviceId, null, length));

            var stringBuilder = new StringBuilder((int)length);

            Marshal.ThrowExceptionForHR((int)PortableDeviceManager._Manager.GetDeviceFriendlyName(DeviceId, stringBuilder, ref length));

            DeviceFriendlyName = stringBuilder.ToString();

            length = 0;

            Marshal.ThrowExceptionForHR((int)PortableDeviceManager._Manager.GetDeviceDescription(DeviceId, null, length));

            stringBuilder = new StringBuilder((int)length);

            Marshal.ThrowExceptionForHR((int)PortableDeviceManager._Manager.GetDeviceDescription(DeviceId, stringBuilder, ref length));

            DeviceDescription = stringBuilder.ToString();

            length = 0;

            Marshal.ThrowExceptionForHR((int)PortableDeviceManager._Manager.GetDeviceManufacturer(DeviceId, null, length));

            stringBuilder = new StringBuilder((int)length);

            Marshal.ThrowExceptionForHR((int)PortableDeviceManager._Manager.GetDeviceManufacturer(DeviceId, stringBuilder, ref length));

            DeviceManufacturer = stringBuilder.ToString();



            _portableDevice = new Win32Native.PortableDevices.PortableDevice();

        }

        public PortableDevice(in string deviceId) => DeviceId = deviceId;

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
                pClientInformation = null;
            }

            // return hr;
            // }

            _items = null; // We have to reset the _items field in order to re-load it with the portable device's items when needed.

            IsOpen = true;

        }

        public void Close()
        {
            Marshal.ThrowExceptionForHR((int)_portableDevice.Close());

            IsOpen = false;
        }

        public object GetDeviceProperty(in string propertyName, in object defaultValue, in bool doNotExpand, out BlobValueKind valueKind)

        {

            if (PortableDeviceManager is null)

                throw new InvalidOperationException("This PortableDevice object has not been created by a PortableDeviceManager.");

            uint pcbData = 0;

            BlobValueKind _valueKind = BlobValueKind.None;

            HResult hr;

            if ((hr = PortableDeviceManager._Manager.GetDeviceProperty(DeviceId, propertyName, null, ref pcbData, ref _valueKind)) == CoreErrorHelper.HResultFromWin32(ErrorCode.InsufficientBuffer))

            {

                byte[] bytes = new byte[pcbData];

                hr = PortableDeviceManager._Manager.GetDeviceProperty(DeviceId, propertyName, bytes, ref pcbData, ref _valueKind);

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

        private List<IPortableDeviceObject> _items;

        private List<IPortableDeviceObject> _Items

        {

            get

            {

                if (_items is null)

                    if (IsOpen)

                        GetItems();

                    else

                        _items = new List<IPortableDeviceObject>();

                return _items;

            }

        }

        public IPortableDeviceObject this[int index] => _Items[index];

        private void GetItems()

        {

            _ = _portableDevice.Content(out IPortableDeviceContent portableDeviceContent);

            if (CoreErrorHelper.Succeeded(portableDeviceContent.EnumObjects(0, Consts.DeviceObjectId, null, out IEnumPortableDeviceObjectIDs enumPortableDeviceObjectIDs)))

            {

                var items = new LinkedList<IPortableDeviceObject>();

                while (true)

                {

                    string[] objectIDs = new string[10];

                    if (CoreErrorHelper.Succeeded(enumPortableDeviceObjectIDs.Next(10, objectIDs, out uint fetched)))

                        for (uint i = 0; i < fetched; i++)

                            _ = items.AddLast(new PortableDeviceObject(objectIDs[i], this, null));

                    else break;

                }

                _items = new List<IPortableDeviceObject>(items.Count);

                if (items.Count > 0)

                {

                    _items[0] = items.First.Value;

                    if (items.Count > 1)

                        for (int i = 1; i < items.Count; i++)

                        {

                            items.RemoveFirst();

                            _items[i] = items.First.Value;

                        }

                }

            }

        }

        #region IDisposable Support

        public bool IsDisposed { get; private set; } = false;

        protected virtual void Dispose(in bool disposing)
        {

            if (IsDisposed) return;

            if (disposing)
            {
                IsOpen = false;
                _ = PortableDeviceManager._portableDevices.Remove(this);
                _ = PortableDeviceManager._privatePortableDevices.Remove(this);
            }

            _ = Marshal.ReleaseComObject(_portableDevice);
            _portableDevice = null;
            IsDisposed = true;

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

        #region IEnumerable Support

        public IEnumerator<IPortableDeviceObject> GetEnumerator() => _Items.GetEnumerator();

        #endregion

    }

    public class PortableDeviceObject : IPortableDeviceObject

    {

        public string Id { get; }

        public IPortableDevice ParentPortableDevice { get; }

        public IPortableDeviceObject Parent { get; }

        internal PortableDeviceObject(string id, IPortableDevice parentPortableDevice, IPortableDeviceObject parent)

        {

            Id = id;

            ParentPortableDevice = parentPortableDevice;

            Parent = parent;

        }

    }
}
