//Copyright (c) Pierre Sprimont.  All rights reserved.

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

//internal interface INativePropertyKeyCollectionProvider
//{

//    Win32Native.PortableDevices.PropertySystem.IPortableDeviceKeyCollection NativeItems { get; }

//}

//namespace Microsoft.WindowsAPICodePack.PortableDevices.CommandSystem
//{
//#pragma warning disable CA2243 // Attribute string literals should parse correctly
//    [Flags]
//    public enum Common : uint
//    {

//        None = 0,
//        [PropertyKey(CommandSystem.Common, 2)]
//        ResetDevice = 1,
//        [PropertyKey(CommandSystem.Common, 3)]
//        GetObjectIdsFromPersistentUniqueIds = 2,
//        [PropertyKey(CommandSystem.Common, 4)]
//        SaveClientInformation = 4

//    }

//    namespace Object

//    {

//        [Flags]
//        public enum Enumeration : uint
//        {

//            None = 0,
//            [PropertyKey(CommandSystem.Object.Enumeration, 2)]
//            StartFind = 1,
//            [PropertyKey(CommandSystem.Object.Enumeration, 3)]
//            FindNext = 2,
//            [PropertyKey(CommandSystem.Object.Enumeration, 4)]
//            EndFind = 4

//        }

//        [Flags]
//        public enum Property : uint
//        {

//            None = 0,
//            [PropertyKey(CommandSystem.Object.Properties, 2)]
//            GetSupported = 1,
//            [PropertyKey(CommandSystem.Object.Properties, 3)]
//            GetAttributes = 2,
//            [PropertyKey(CommandSystem.Object.Properties, 4)]
//            Get = 4,
//            [PropertyKey(CommandSystem.Object.Properties, 5)]
//            Set = 8,
//            [PropertyKey(CommandSystem.Object.Properties, 6)]
//            GetAll = 16,
//            [PropertyKey(CommandSystem.Object.Properties, 7)]
//            Delete = 32

//        }

//        [Flags]
//        public enum PropertyBulk : uint
//        {

//            None = 0,
//            [PropertyKey(CommandSystem.Object.PropertiesBulk, 2)]
//            GetValuesByObjectListStart = 1,
//            [PropertyKey(CommandSystem.Object.PropertiesBulk, 3)]
//            GetValuesByObjectListNext = 2,
//            [PropertyKey(CommandSystem.Object.PropertiesBulk, 4)]
//            GetValuesByObjectListEnd = 4,
//            [PropertyKey(CommandSystem.Object.PropertiesBulk, 5)]
//            GetValuesByObjectFormatStart = 8,
//            [PropertyKey(CommandSystem.Object.PropertiesBulk, 6)]
//            GetValuesByObjectFormatNext = 16,
//            [PropertyKey(CommandSystem.Object.PropertiesBulk, 7)]
//            GetValuesByObjectFormatEnd = 32,
//            [PropertyKey(CommandSystem.Object.PropertiesBulk, 8)]
//            SetValuesByObjectListStart = 64,
//            [PropertyKey(CommandSystem.Object.PropertiesBulk, 9)]
//            SetValuesByObjectListNext = 128,
//            [PropertyKey(CommandSystem.Object.PropertiesBulk, 10)]
//            SetValuesByObjectListEnd = 256,

//        }

//        [Flags]
//        public enum Resource : uint
//        {

//            None = 0,
//            [PropertyKey(CommandSystem.Object.Resources, 2)]
//            GetSupported = 1,
//            [PropertyKey(CommandSystem.Object.Resources, 3)]
//            GetAttributes = 2,
//            [PropertyKey(CommandSystem.Object.Resources, 4)]
//            Open = 4,
//            [PropertyKey(CommandSystem.Object.Resources, 5)]
//            Read = 8,
//            [PropertyKey(CommandSystem.Object.Resources, 6)]
//            Write = 16,
//            [PropertyKey(CommandSystem.Object.Resources, 7)]
//            Close = 32,
//            [PropertyKey(CommandSystem.Object.Resources, 8)]
//            Delete = 64,
//            [PropertyKey(CommandSystem.Object.Resources, 9)]
//            CreateResource = 128,
//            [PropertyKey(CommandSystem.Object.Resources, 10)]
//            Revert = 256,
//            [PropertyKey(CommandSystem.Object.Resources, 11)]
//            Seek = 512,
//            [PropertyKey(CommandSystem.Object.Resources, 12)]
//            Commit = 1024,
//            [PropertyKey(CommandSystem.Object.Resources, 13)]
//            SeekInUnits = 2048

//        }

//        [Flags]
//        public enum Management : uint
//        {

//            None = 0,
//            [PropertyKey(CommandSystem.Object.Management, 2)]
//            CreateObjectWithPropertiesOnly = 1,
//            [PropertyKey(CommandSystem.Object.Management, 3)]
//            CreateObjectWithPropertiesAndData = 2,
//            [PropertyKey(CommandSystem.Object.Management, 4)]
//            WriteObjectData = 4,
//            [PropertyKey(CommandSystem.Object.Management, 5)]
//            CommitObject = 8,
//            [PropertyKey(CommandSystem.Object.Management, 6)]
//            RevertObject = 16,
//            [PropertyKey(CommandSystem.Object.Management, 7)]
//            DeleteObjects = 32,
//            [PropertyKey(CommandSystem.Object.Management, 8)]
//            MoveObjects = 64,
//            [PropertyKey(CommandSystem.Object.Management, 9)]
//            CopyObjects = 128,
//            [PropertyKey(CommandSystem.Object.Management, 10)]
//            UpdateObjectWithPropertiesAndData = 256

//        }

//    }

//    [Flags]
//    public enum Capability : uint
//    {

//        None = 0,
//        [PropertyKey(CommandSystem.Capabilities, 2)]
//        GetSupportedCommands = 1,
//        [PropertyKey(CommandSystem.Capabilities, 3)]
//        GetCommandOptions = 2,
//        [PropertyKey(CommandSystem.Capabilities, 4)]
//        GetSupportedFunctionalCategories = 4,
//        [PropertyKey(CommandSystem.Capabilities, 5)]
//        GetFunctionalObjects = 8,
//        [PropertyKey(CommandSystem.Capabilities, 6)]
//        GetSupportedContentTypes = 16,
//        [PropertyKey(CommandSystem.Capabilities, 7)]
//        GetSupportedFormats = 32,
//        [PropertyKey(CommandSystem.Capabilities, 8)]
//        GetSupportedFormatProperties = 64,
//        [PropertyKey(CommandSystem.Capabilities, 9)]
//        GetFixedPropertyAttributes = 128,
//        [PropertyKey(CommandSystem.Capabilities, 10)]
//        GetSupportedEvents = 256,
//        [PropertyKey(CommandSystem.Capabilities, 11)]
//        GetEventOptions = 512

//    }

//    [Flags]
//    public enum Storage : uint
//    {

//        None = 0,
//        [PropertyKey(CommandSystem.Storage, 2)]
//        Format = 1,
//        [PropertyKey(CommandSystem.Storage, 4)]
//        Eject = 2

//    }

//    [Flags]
//    public enum SMS : uint
//    {

//        None = 0,
//        [PropertyKey(CommandSystem.SMS, 2)]
//        Send = 1


//    }

//    [Flags]
//    public enum StillImageCapture : uint
//    {

//        None = 0,
//        [PropertyKey(CommandSystem.StillImageCapture, 2)]
//        Initiate = 1

//    }

//    [Flags]
//    public enum MediaCapture : uint
//    {

//        None = 0,
//        [PropertyKey(CommandSystem.MediaCapture, 2)]
//        Start = 1,
//        [PropertyKey(CommandSystem.MediaCapture, 3)]
//        Stop = 2,
//        [PropertyKey(CommandSystem.MediaCapture, 4)]
//        Pause = 4

//    }

//    [Flags]
//    public enum DeviceHint : uint
//    {

//        None = 0,
//        [PropertyKey(CommandSystem.DeviceHints, 2)]
//        GetContentLocation = 1

//    }

//    [Flags]
//    public enum ClassExtension : uint
//    {

//        None = 0,
//        [PropertyKey(CommandSystem.ClassExtensionV1, 2)]
//        WriteDeviceInformation = 1,
//        [PropertyKey(CommandSystem.ClassExtensionV2, 2)]
//        RegisterServiceInterfaces = 2,
//        [PropertyKey(CommandSystem.ClassExtensionV2, 3)]
//        UnregisterServiceInterfaces = 4

//    }

//    [Flags]
//    public enum NetworkConfiguration : uint
//    {

//        None = 0,
//        [PropertyKey(CommandSystem.NetworkConfiguration, 2)]
//        GenerateKeyPair = 1,
//        [PropertyKey(CommandSystem.NetworkConfiguration, 3)]
//        CommitKeyPair = 2,
//        [PropertyKey(CommandSystem.NetworkConfiguration, 4)]
//        ProcessWirelessProfile = 4

//    }

//    namespace Service

//    {

//        [Flags]
//        public enum Common : uint
//        {
//            None = 0,
//            [PropertyKey(CommandSystem.Service.Common, 2)]
//            GetServiceObjectId = 1

//        }

//        [Flags]
//        public enum Capability : uint
//        {

//            None = 0,
//            [PropertyKey(CommandSystem.Service.Capabilities, 2)]
//            GetSupportedMethods = 1,
//            [PropertyKey(CommandSystem.Service.Capabilities, 3)]
//            GetSupportedMethodsByFormat = 2,
//            [PropertyKey(CommandSystem.Service.Capabilities, 4)]
//            GetMethodAttributes = 4,
//            [PropertyKey(CommandSystem.Service.Capabilities, 5)]
//            GetMethodParameterAttributes = 8,
//            [PropertyKey(CommandSystem.Service.Capabilities, 6)]
//            GetSupportedFormats = 16,
//            [PropertyKey(CommandSystem.Service.Capabilities, 7)]
//            GetFormatAttributes = 32,
//            [PropertyKey(CommandSystem.Service.Capabilities, 8)]
//            GetSupportedFormatProperties = 64,
//            [PropertyKey(CommandSystem.Service.Capabilities, 9)]
//            GetFormatPropertyAttributes = 128,
//            [PropertyKey(CommandSystem.Service.Capabilities, 10)]
//            GetSupportedEvents = 256,
//            [PropertyKey(CommandSystem.Service.Capabilities, 11)]
//            GetEventAttributes = 512,
//            [PropertyKey(CommandSystem.Service.Capabilities, 12)]
//            GetEventParameterAttributes = 1024,
//            [PropertyKey(CommandSystem.Service.Capabilities, 13)]
//            GetInheritedServices = 2048,
//            [PropertyKey(CommandSystem.Service.Capabilities, 14)]
//            GetFormatRenderingProfiles = 4096,
//            [PropertyKey(CommandSystem.Service.Capabilities, 15)]
//            GetSupportedCommands = 8192,
//            [PropertyKey(CommandSystem.Service.Capabilities, 16)]
//            GetCommandOptions = 16384

//        }

//        [Flags]
//        public enum Method : uint
//        {

//            None = 0,
//            [PropertyKey(CommandSystem.Service.Methods, 2)]
//            StartInvoke = 1,
//            [PropertyKey(CommandSystem.Service.Methods, 3)]
//            CancelInvoke = 2,
//            [PropertyKey(CommandSystem.Service.Methods, 4)]
//            EndInvoke = 4

//        }

//    }
//#pragma warning restore CA2243 // Attribute string literals should parse correctly

//    public static class Commands
//    {

//    }

//    public static class CommonCommands

//    {

//        public static void ResetDevice(PortableDevice portableDevice)

//        {

//            var values = new PortableDeviceValues();

//            _ = values.SetGuidValue(Win32Native.PortableDevices.CommandSystem.Common.Parameters.CommandCategory, new Guid(CommandSystem.Common));

//            _ = values.SetUnsignedIntegerValue(Win32Native.PortableDevices.CommandSystem.Common.Parameters.CommandId, Win32Native.PortableDevices.CommandSystem.Common.Commands.ResetDevice.PropertyId);

//            Commands.SendCommand(portableDevice, values, out _);

//            _ = Marshal.ReleaseComObject(values);

//        }

//        public static string[] GetObjectIdsFromPersistentUniqueIds(PortableDevice portableDevice, string[] persistentUniqueIds)

//        {

//            if (portableDevice is null)

//                throw new ArgumentNullException(nameof(portableDevice));

//            if (persistentUniqueIds is null)

//                throw new ArgumentNullException(nameof(persistentUniqueIds));

//            var values = new PortableDeviceValues();

//            _ = values.SetGuidValue(Win32Native.PortableDevices.CommandSystem.Common.Parameters.CommandCategory, new Guid(CommandSystem.Common));

//            _ = values.SetUnsignedIntegerValue(Win32Native.PortableDevices.CommandSystem.Common.Parameters.CommandId, Win32Native.PortableDevices.CommandSystem.Common.Commands.GetObjectIdsFromPersistentUniqueIds.PropertyId);

//            var parameters = new PortableDevicePropVariantCollection();

//            foreach (string persistentUniqueId in persistentUniqueIds)

//                _ = parameters.Add(new PropVariant(persistentUniqueId));

//            _ = values.SetIPortableDevicePropVariantCollectionValue(Win32Native.PortableDevices.CommandSystem.Common.Parameters.PersistentUniqueIds, parameters);

//            Commands.SendCommand(portableDevice, values, out IPortableDeviceValues results);

//            _ = results.GetIPortableDevicePropVariantCollectionValue(Win32Native.PortableDevices.CommandSystem.Common.Parameters.ObjectIds, out IPortableDevicePropVariantCollection _results);

//            uint count = 0;

//            _ = _results.GetCount(count);

//            string[] __results = new string[count];

//            for (uint i = 0; i < count; i++)

//            {

//                var propVar = new PropVariant();

//                _ = _results.GetAt(i, ref propVar);

//                __results[i] = (string)propVar.Value;

//                propVar.Dispose();

//            }

//            _ = Marshal.ReleaseComObject(values);

//            values = null;

//            _ = Marshal.ReleaseComObject(parameters);

//            parameters = null;

//            _ = Marshal.ReleaseComObject(results);

//            results = null;

//            _ = Marshal.ReleaseComObject(_results);

//            _results = null;

//            return __results;

//        }

//    }
//}
