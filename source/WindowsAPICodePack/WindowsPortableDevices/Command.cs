using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using Microsoft.WindowsAPICodePack.Win32Native.Core.PropertySystem;
using Microsoft.WindowsAPICodePack.Win32Native.PortableDevices.PropertySystem;
using MS.WindowsAPICodePack.Win32Native.Shell.PropertySystem;
using static Microsoft.WindowsAPICodePack.Win32Native.Guids.PortableDevices;

namespace Microsoft.WindowsAPICodePack.PortableDevices.Commands
{
    [Flags]
    public enum CommonCommandCategory
    {

        [PropertyKey(CommandCategories.Common, 2)]
        ResetDevice = 1,
        [PropertyKey(CommandCategories.Common, 3)]
        GetObjectIdsFromPersistentUniqueIds = 2,
        [PropertyKey(CommandCategories.Common, 4)]
        SaveClientInformation = 4

    }

    namespace Object

    {

        [Flags]
        public enum Enumeration
        {

            [PropertyKey(CommandCategories.Object.Enumeration, 2)]
            StartFind = 1,
            [PropertyKey(CommandCategories.Object.Enumeration, 3)]
            FindNext = 2,
            [PropertyKey(CommandCategories.Object.Enumeration, 4)]
            EndFind = 4

        }

        [Flags]
        public enum Property
        {

            [PropertyKey(CommandCategories.Object.Properties, 2)]
            GetSupported = 1,
            [PropertyKey(CommandCategories.Object.Properties, 3)]
            GetAttributes = 2,
            [PropertyKey(CommandCategories.Object.Properties, 4)]
            Get = 4,
            [PropertyKey(CommandCategories.Object.Properties, 5)]
            Set = 8,
            [PropertyKey(CommandCategories.Object.Properties, 6)]
            GetAll = 16,
            [PropertyKey(CommandCategories.Object.Properties, 7)]
            Delete = 32

        }

        [Flags]
        public enum PropertyBulk
        {

            [PropertyKey(CommandCategories.Object.PropertiesBulk, 2)]
            GetValuesByObjectListStart = 1,
            [PropertyKey(CommandCategories.Object.PropertiesBulk, 3)]
            GetValuesByObjectListNext = 2,
            [PropertyKey(CommandCategories.Object.PropertiesBulk, 4)]
            GetValuesByObjectListEnd = 4,
            [PropertyKey(CommandCategories.Object.PropertiesBulk, 5)]
            GetValuesByObjectFormatStart = 8,
            [PropertyKey(CommandCategories.Object.PropertiesBulk, 6)]
            GetValuesByObjectFormatNext = 16,
            [PropertyKey(CommandCategories.Object.PropertiesBulk, 7)]
            GetValuesByObjectFormatEnd = 32,
            [PropertyKey(CommandCategories.Object.PropertiesBulk, 8)]
            SetValuesByObjectListStart = 64,
            [PropertyKey(CommandCategories.Object.PropertiesBulk, 9)]
            SetValuesByObjectListNext = 128,
            [PropertyKey(CommandCategories.Object.PropertiesBulk, 10)]
            SetValuesByObjectListEnd = 256,

        }

        [Flags]
        public enum Resource
        {

            [PropertyKey(CommandCategories.Object.Resources, 2)]
            GetSupported = 1,
            [PropertyKey(CommandCategories.Object.Resources, 3)]
            GetAttributes = 2,
            [PropertyKey(CommandCategories.Object.Resources, 4)]
            Open = 4,
            [PropertyKey(CommandCategories.Object.Resources, 5)]
            Read = 8,
            [PropertyKey(CommandCategories.Object.Resources, 6)]
            Write = 16,
            [PropertyKey(CommandCategories.Object.Resources, 7)]
            Close = 32,
            [PropertyKey(CommandCategories.Object.Resources, 8)]
            Delete = 64,
            [PropertyKey(CommandCategories.Object.Resources, 9)]
            CreateResource = 128,
            [PropertyKey(CommandCategories.Object.Resources, 10)]
            Revert = 256,
            [PropertyKey(CommandCategories.Object.Resources, 11)]
            Seek = 512,
            [PropertyKey(CommandCategories.Object.Resources, 12)]
            Commit = 1024,
            [PropertyKey(CommandCategories.Object.Resources, 13)]
            SeekInUnits = 2048

        }

        [Flags]
        public enum Management
        {

            [PropertyKey(CommandCategories.Object.Management, 2)]
            CreateObjectWithPropertiesOnly = 1,
            [PropertyKey(CommandCategories.Object.Management, 3)]
            CreateObjectWithPropertiesAndData = 2,
            [PropertyKey(CommandCategories.Object.Management, 4)]
            WriteObjectData = 4,
            [PropertyKey(CommandCategories.Object.Management, 5)]
            CommitObject = 8,
            [PropertyKey(CommandCategories.Object.Management, 6)]
            RevertObject = 16,
            [PropertyKey(CommandCategories.Object.Management, 7)]
            DeleteObjects = 32,
            [PropertyKey(CommandCategories.Object.Management, 8)]
            MoveObjects = 64,
            [PropertyKey(CommandCategories.Object.Management, 9)]
            CopyObjects = 128,
            [PropertyKey(CommandCategories.Object.Management, 10)]
            UpdateObjectWithPropertiesAndData = 256

        }

    }

    [Flags]
    public enum Capability
    {

        [PropertyKey(CommandCategories.Capabilities, 2)]
        GetSupportedCommands = 1,
        [PropertyKey(CommandCategories.Capabilities, 3)]
        GetCommandOptions = 2,
        [PropertyKey(CommandCategories.Capabilities, 4)]
        GetSupportedFunctionalCategories = 4,
        [PropertyKey(CommandCategories.Capabilities, 5)]
        GetFunctionalObjects = 8,
        [PropertyKey(CommandCategories.Capabilities, 6)]
        GetSupportedContentTypes = 16,
        [PropertyKey(CommandCategories.Capabilities, 7)]
        GetSupportedFormats = 32,
        [PropertyKey(CommandCategories.Capabilities, 8)]
        GetSupportedFormatProperties = 64,
        [PropertyKey(CommandCategories.Capabilities, 9)]
        GetFixedPropertyAttributes = 128,
        [PropertyKey(CommandCategories.Capabilities, 10)]
        GetSupportedEvents = 256,
        [PropertyKey(CommandCategories.Capabilities, 11)]
        GetEventOptions = 512

    }

    [Flags]
    public enum Storage
    {

        [PropertyKey(CommandCategories.Storage, 2)]
        Format = 1,
        [PropertyKey(CommandCategories.Storage, 4)]
        Eject = 2

    }

    [Flags]
    public enum SMS
    {

        [PropertyKey(CommandCategories.SMS, 2)]
        Send = 1


    }

    [Flags]
    public enum StillImageCapture
    {

        [PropertyKey(CommandCategories.StillImageCapture, 2)]
        Initiate = 1

    }
    [Flags]
    public enum MediaCapture
    {

        [PropertyKey(CommandCategories.MediaCapture, 2)]
        Start = 1,
        [PropertyKey(CommandCategories.MediaCapture, 3)]
        Stop = 2,
        [PropertyKey(CommandCategories.MediaCapture, 4)]
        Pause = 4

    }

    [Flags]
    public enum DeviceHint
    {

        [PropertyKey(CommandCategories.DeviceHints, 2)]
        GetContentLocation = 1

    }

    [Flags]
    public enum ClassExtension
    {

        [PropertyKey(CommandCategories.ClassExtensionV1, 2)]
        WriteDeviceInformation = 1,
        [PropertyKey(CommandCategories.ClassExtensionV2, 2)]
        RegisterServiceInterfaces = 2,
        [PropertyKey(CommandCategories.ClassExtensionV2, 3)]
        UnregisterServiceInterfaces = 4

    }

    [Flags]
    public enum NetworkConfiguration
    {

        [PropertyKey(CommandCategories.NetworkConfiguration, 2)]
        GenerateKeyPair = 1,
        [PropertyKey(CommandCategories.NetworkConfiguration, 3)]
        CommitKeyPair = 2,
        [PropertyKey(CommandCategories.NetworkConfiguration, 4)]
        ProcessWirelessProfile = 4

    }

    namespace Service

    {

        [Flags]
        public enum Common
        {
            [PropertyKey(CommandCategories.Service.Common, 2)]
            GetServiceObjectId = 1

        }

        [Flags]
        public enum Capability
        {

            [PropertyKey(CommandCategories.Service.Capabilities, 2)]
            GetSupportedMethods = 1,
            [PropertyKey(CommandCategories.Service.Capabilities, 3)]
            GetSupportedMethodsByFormat = 2,
            [PropertyKey(CommandCategories.Service.Capabilities, 4)]
            GetMethodAttributes = 4,
            [PropertyKey(CommandCategories.Service.Capabilities, 5)]
            GetMethodParameterAttributes = 8,
            [PropertyKey(CommandCategories.Service.Capabilities, 6)]
            GetSupportedFormats = 16,
            [PropertyKey(CommandCategories.Service.Capabilities, 7)]
            GetFormatAttributes = 32,
            [PropertyKey(CommandCategories.Service.Capabilities, 8)]
            GetSupportedFormatProperties = 64,
            [PropertyKey(CommandCategories.Service.Capabilities, 9)]
            GetFormatPropertyAttributes = 128,
            [PropertyKey(CommandCategories.Service.Capabilities, 10)]
            GetSupportedEvents = 256,
            [PropertyKey(CommandCategories.Service.Capabilities, 11)]
            GetEventAttributes = 512,
            [PropertyKey(CommandCategories.Service.Capabilities, 12)]
            GetEventParameterAttributes = 1024,
            [PropertyKey(CommandCategories.Service.Capabilities, 13)]
            GetInheritedServices = 2048,
            [PropertyKey(CommandCategories.Service.Capabilities, 14)]
            GetFormatRenderingProfiles = 4096,
            [PropertyKey(CommandCategories.Service.Capabilities, 15)]
            GetSupportedCommands = 8192,
            [PropertyKey(CommandCategories.Service.Capabilities, 16)]
            GetCommandOptions = 16384

        }

        [Flags]
        public enum Method
        {

            [PropertyKey(CommandCategories.Service.Methods, 2)]
            StartInvoke = 1,
            [PropertyKey(CommandCategories.Service.Methods, 3)]
            CancelInvoke = 2,
            [PropertyKey(CommandCategories.Service.Methods, 4)]
            EndInvoke = 4

        }

    }

    public abstract class Commands
    {

        protected void SendCommand(PortableDevice portableDevice, IPortableDeviceValues parameters, out IPortableDeviceValues results)

        {

            if (portableDevice is null)

                throw new ArgumentNullException(nameof(portableDevice));

            portableDevice._portableDevice.SendCommand(0, parameters, out results);

        }

    }

    public class CommonCommands : Commands

    {

        public void ResetDevice(PortableDevice portableDevice)

        {

            var values = new PortableDeviceValues();

            _ = values.SetGuidValue(Win32Native.PortableDevices.Commands.Common.Parameters.CommandCategory, new Guid(CommandCategories.Common));

            _ = values.SetUnsignedIntegerValue(Win32Native.PortableDevices.Commands.Common.Parameters.CommandId, Win32Native.PortableDevices.Commands.Common.Commands.ResetDevice.PropertyId);

            SendCommand(portableDevice, values, out _);

            _ = Marshal.ReleaseComObject(values);

        }

        public string[] GetObjectIdsFromPersistentUniqueIds(PortableDevice portableDevice, string[] persistentUniqueIds)

        {

            if (persistentUniqueIds is null)

                throw new ArgumentNullException(nameof(persistentUniqueIds));

            var values = new PortableDeviceValues();

            _ = values.SetGuidValue(Win32Native.PortableDevices.Commands.Common.Parameters.CommandCategory, new Guid(CommandCategories.Common));

            _ = values.SetUnsignedIntegerValue(Win32Native.PortableDevices.Commands.Common.Parameters.CommandId, Win32Native.PortableDevices.Commands.Common.Commands.GetObjectIdsFromPersistentUniqueIds.PropertyId);

            var parameters = new PortableDevicePropVariantCollection();

            foreach (string persistentUniqueId in persistentUniqueIds)

                _ = parameters.Add(new PropVariant(persistentUniqueId));

            _ = values.SetIPortableDevicePropVariantCollectionValue(Win32Native.PortableDevices.Commands.Common.Parameters.PersistentUniqueIds, parameters);

            SendCommand(portableDevice, values, out IPortableDeviceValues results);

            _ = results.GetIPortableDevicePropVariantCollectionValue(Win32Native.PortableDevices.Commands.Common.Parameters.ObjectIds, out IPortableDevicePropVariantCollection _results);

            uint count = 0;

            _ = _results.GetCount(count);

            var __results = new string[count];

            for (uint i = 0; i < count; i++)

            {

                var propVar = new PropVariant();

                _ = _results.GetAt(i, ref propVar);

                __results[i] = (string)propVar.Value;

                propVar.Dispose();

            }

            _ = Marshal.ReleaseComObject(values);

            values = null;

            _ = Marshal.ReleaseComObject(parameters);

            parameters = null;

            _ = Marshal.ReleaseComObject(results);

            results = null;

            _ = Marshal.ReleaseComObject(_results);

            _results = null;

            return __results;

        }

    }
}
