//#pragma warning disable CA2243 // Attribute string literals should parse correctly
//public class SupportedCommands

//{
//[Guid(Microsoft.WindowsAPICodePack.PortableDevices.Guids.CommandSystem.Common)]
//private readonly Common _common;
//[Guid(Microsoft.WindowsAPICodePack.PortableDevices.Guids.CommandSystem.Capabilities)]
//private readonly Commands.Capability _capability;
//[Guid(Microsoft.WindowsAPICodePack.PortableDevices.Guids.CommandSystem.Storage)]
//private readonly Storage _storage;
//[Guid(Microsoft.WindowsAPICodePack.PortableDevices.Guids.CommandSystem.SMS)]
//private readonly SMS _sms;
//[Guid(Microsoft.WindowsAPICodePack.PortableDevices.Guids.CommandSystem.StillImageCapture)]
//private readonly StillImageCapture _stillImageCapture;
//[Guid(Microsoft.WindowsAPICodePack.PortableDevices.Guids.CommandSystem.MediaCapture)]
//private readonly MediaCapture _mediaCapture;
//[Guid(Microsoft.WindowsAPICodePack.PortableDevices.Guids.CommandSystem.DeviceHints)]
//private readonly DeviceHint _deviceHint;
//[Guid(Microsoft.WindowsAPICodePack.PortableDevices.Guids.CommandSystem.ClassExtensionV1)]
//[Guid(Microsoft.WindowsAPICodePack.PortableDevices.Guids.CommandSystem.ClassExtensionV2)]
//private readonly ClassExtension _classExtension;
//[Guid(Microsoft.WindowsAPICodePack.PortableDevices.Guids.CommandSystem.NetworkConfiguration)]
//private readonly NetworkConfiguration _networkConfiguration;

//public class ObjectCommands

//{
//    [Guid(Microsoft.WindowsAPICodePack.PortableDevices.Guids.CommandSystem.Object.Enumeration)]
//    private readonly Enumeration _enumeration;
//    [Guid(Microsoft.WindowsAPICodePack.PortableDevices.Guids.CommandSystem.Object.Properties)]
//    private readonly Property _property;
//    [Guid(Microsoft.WindowsAPICodePack.PortableDevices.Guids.CommandSystem.Object.PropertiesBulk)]
//    private readonly PropertyBulk _propertyBulk;
//    [Guid(Microsoft.WindowsAPICodePack.PortableDevices.Guids.CommandSystem.Object.Resources)]
//    private readonly Resource _resource;
//    [Guid(Microsoft.WindowsAPICodePack.PortableDevices.Guids.CommandSystem.Object.Management)]
//    private readonly Management _management;

//    public Enumeration Enumeration => _enumeration;

//    public Property Property => _property;

//    public PropertyBulk PropertyBulk => _propertyBulk;

//    public Resource Resource => _resource;

//    public Management Management => _management;

//    public ObjectCommands() { }

//    public ObjectCommands(in Enumeration enumeration, in Property property, in PropertyBulk propertyBulk, in Resource resource, in Management management)

//    {

//        _enumeration = enumeration;

//        _property = property;

//        _propertyBulk = propertyBulk;

//        _resource = resource;

//        _management = management;

//    }

//}

//public class ServiceCommands

//{
//    [Guid(Microsoft.WindowsAPICodePack.PortableDevices.Guids.CommandSystem.Service.Common)]
//    private readonly Commands.Service.Common _common;
//    [Guid(Microsoft.WindowsAPICodePack.PortableDevices.Guids.CommandSystem.Service.Capabilities)]
//    private readonly Commands.Service.Capability _capability;
//    [Guid(Microsoft.WindowsAPICodePack.PortableDevices.Guids.CommandSystem.Service.Methods)]
//    private readonly Method _method;

//    public Commands.Service.Common Common => _common;

//    public Commands.Service.Capability Capability => _capability;

//    public Method Method => _method;

//    public ServiceCommands() { }

//    public ServiceCommands(in Commands.Service.Common common, in Commands.Service.Capability capability, in Method method)

//    {

//        _common = common;

//        _capability = capability;

//        _method = method;

//    }

//}

//public Common Common => _common;

//public ObjectCommands Object { get; }

//public Commands.Capability Capability => _capability;

//public Storage Storage => _storage;

//public SMS SMS => _sms;

//public StillImageCapture StillImageCapture => _stillImageCapture;

//public MediaCapture MediaCapture => _mediaCapture;

//public DeviceHint DeviceHint => _deviceHint;

//public ClassExtension ClassExtension => _classExtension;

//public NetworkConfiguration NetworkConfiguration => _networkConfiguration;

//public ServiceCommands Service { get; }

//    public SupportedCommands() { Object = new ObjectCommands(); Service = new ServiceCommands(); }

//    public SupportedCommands(in Common common, in ObjectCommands @object, in Commands.Capability capability, in Storage storage, in SMS sms, in StillImageCapture stillImageCapture, in MediaCapture mediaCapture, in DeviceHint deviceHint, in ClassExtension classExtension, in NetworkConfiguration networkConfiguration, in ServiceCommands service)

//    {

//        _common = common;

//        Object = @object;

//        _capability = capability;

//        _storage = storage;

//        _sms = sms;

//        _stillImageCapture = stillImageCapture;

//        _mediaCapture = mediaCapture;

//        _deviceHint = deviceHint;

//        _classExtension = classExtension;

//        _networkConfiguration = networkConfiguration;

//        Service = service;

//    }

//}
//#pragma warning restore CA2243 // Attribute string literals should parse correctly

//using Microsoft.WindowsAPICodePack.PropertySystem;
//using System;
//using System.Collections.Generic;
//using System.Runtime.InteropServices;
//using System.Text;

//namespace Microsoft.WindowsAPICodePack.PortableDevices.PropertySystem
//{
//    public class PortableDeviceKeyCollection : Collection<PropertyKey>, IPortableDeviceKeyCollection
//    {
//        private Win32Native.PortableDevices.PropertySystem.IPortableDeviceKeyCollection _portableDeviceKeyCollection;

//        internal Win32Native.PortableDevices.PropertySystem.IPortableDeviceKeyCollection _PortableDeviceKeyCollection { get { ThrowIfDisposed(); return _portableDeviceKeyCollection; } } 

//        // todo: replace by the same WinCopies.Util extension method.

//        private void ThrowIfDisposed()

//        {

//            if (IsDisposed)

//                throw new InvalidOperationException("The current collection is disposed.");

//        }

//        public PortableDeviceKeyCollection() => _portableDeviceKeyCollection = new Win32Native.PortableDevices.PropertySystem.PortableDeviceKeyCollection();

//        public void Add(ref PropertyKey Key) => Marshal.ThrowExceptionForHR((int)_PortableDeviceKeyCollection.Add(ref Key));

//        public void Clear() => _PortableDeviceKeyCollection.Clear();

//        public PropertyKey GetAt(in uint dwIndex)
//        {
//            ThrowIfDisposed();

//            if (dwIndex < 0 || dwIndex >= Count)

//                throw new IndexOutOfRangeException();

//            var key = new PropertyKey();

//            Marshal.ThrowExceptionForHR((int)_PortableDeviceKeyCollection.GetAt(dwIndex, ref key));

//            return key;
//        }

//        public uint Count
//        {
//            get
//            {

//                ThrowIfDisposed();

//                uint count = 0;

//                _ = _PortableDeviceKeyCollection.GetCount(ref count);

//                return count;

//            }
//        }

//        public void RemoveAt(in uint dwIndex)
//        {
//            ThrowIfDisposed();

//            if (dwIndex<0||dwIndex >= Count)

//                throw new IndexOutOfRangeException();

//            _ = _PortableDeviceKeyCollection.RemoveAt(dwIndex);
//        }

//        #region IDisposable Support

//        public bool IsDisposed { get; private set; } = false;

//        protected virtual void Dispose(bool disposing)
//        {
//            if (!IsDisposed)
//            {
//                _ = Marshal.ReleaseComObject(_portableDeviceKeyCollection);
//                _portableDeviceKeyCollection = null;

//                IsDisposed = true;
//            }
//        }

//        ~PortableDeviceKeyCollection()
//        {
//            Dispose(false);
//        }

//        public void Dispose()
//        {
//            Dispose(true);
//            GC.SuppressFinalize(this);
//        }
//        #endregion
//    }
//}

//using Microsoft.WindowsAPICodePack.PropertySystem;
//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace Microsoft.WindowsAPICodePack.PortableDevices.PropertySystem
//{
//    public interface IPortableDeviceKeyCollection : WinCopies.Util.DotNetFix.IDisposable
//    {
//        uint Count { get; }

//        PropertyKey GetAt(
//            in uint dwIndex);

//        void Add(
//            ref PropertyKey Key);

//        void Clear();

//        void RemoveAt(
//            in uint dwIndex);
//    }
//}
