using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using Microsoft.WindowsAPICodePack.Win32Native;
using Microsoft.WindowsAPICodePack.Win32Native.Shell.PropertySystem;
using Microsoft.WindowsAPICodePack.Win32Native.PortableDevices.PropertySystem;
using MS.WindowsAPICodePack.Win32Native.Shell.PropertySystem;
using static Microsoft.WindowsAPICodePack.Win32Native.Guids.PortableDevices;

namespace Microsoft.WindowsAPICodePack.PortableDevices.Commands
{
#pragma warning disable CA2243 // Attribute string literals should parse correctly
    [Flags]
    public enum Common:uint
    {

        None=0,
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
        public enum Enumeration : uint
        {

            None = 0,
            [PropertyKey(CommandCategories.Object.Enumeration, 2)]
            StartFind = 1,
            [PropertyKey(CommandCategories.Object.Enumeration, 3)]
            FindNext = 2,
            [PropertyKey(CommandCategories.Object.Enumeration, 4)]
            EndFind = 4

        }

        [Flags]
        public enum Property : uint
        {

            None = 0,
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
        public enum PropertyBulk : uint
        {

            None = 0,
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
        public enum Resource : uint
        {

            None = 0,
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
        public enum Management : uint
        {

            None = 0,
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
    public enum Capability : uint
    {

        None = 0,
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
    public enum Storage : uint
    {

        None = 0,
        [PropertyKey(CommandCategories.Storage, 2)]
        Format = 1,
        [PropertyKey(CommandCategories.Storage, 4)]
        Eject = 2

    }

    [Flags]
    public enum SMS : uint
    {

        None = 0,
        [PropertyKey(CommandCategories.SMS, 2)]
        Send = 1


    }

    [Flags]
    public enum StillImageCapture : uint
    {

        None = 0,
        [PropertyKey(CommandCategories.StillImageCapture, 2)]
        Initiate = 1

    }

    [Flags]
    public enum MediaCapture : uint
    {

        None = 0,
        [PropertyKey(CommandCategories.MediaCapture, 2)]
        Start = 1,
        [PropertyKey(CommandCategories.MediaCapture, 3)]
        Stop = 2,
        [PropertyKey(CommandCategories.MediaCapture, 4)]
        Pause = 4

    }

    [Flags]
    public enum DeviceHint : uint
    {

        None = 0,
        [PropertyKey(CommandCategories.DeviceHints, 2)]
        GetContentLocation = 1

    }

    [Flags]
    public enum ClassExtension : uint
    {

        None = 0,
        [PropertyKey(CommandCategories.ClassExtensionV1, 2)]
        WriteDeviceInformation = 1,
        [PropertyKey(CommandCategories.ClassExtensionV2, 2)]
        RegisterServiceInterfaces = 2,
        [PropertyKey(CommandCategories.ClassExtensionV2, 3)]
        UnregisterServiceInterfaces = 4

    }

    [Flags]
    public enum NetworkConfiguration : uint
    {

        None = 0,
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
        public enum Common : uint
        {
            None = 0,
            [PropertyKey(CommandCategories.Service.Common, 2)]
            GetServiceObjectId = 1

        }

        [Flags]
        public enum Capability : uint
        {

            None = 0,
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
        public enum Method : uint
        {

            None = 0,
            [PropertyKey(CommandCategories.Service.Methods, 2)]
            StartInvoke = 1,
            [PropertyKey(CommandCategories.Service.Methods, 3)]
            CancelInvoke = 2,
            [PropertyKey(CommandCategories.Service.Methods, 4)]
            EndInvoke = 4

        }

    }
#pragma warning restore CA2243 // Attribute string literals should parse correctly

    public static class Commands
    {

        /// <summary>
        /// This method is used to send command to portable devices. This method takes two parameters of unmanaged type. If no managed wrapper is available in this code pack, you can use this method to create your own managed wrapper. Otherwise, if a managed wrapper exists, it is recommended to use these wrappers.
        /// </summary>
        /// <param name="portableDevice">The <see cref="PortableDevice"/> to send the command to.</param>
        /// <param name="parameters">The parameters of the command.</param>
        /// <param name="results">The results of the command.</param>
        public static void SendCommand(PortableDevice portableDevice, IPortableDeviceValues parameters, out IPortableDeviceValues results)

        {

            Marshal.ThrowExceptionForHR((int)(portableDevice ?? throw new ArgumentNullException(nameof(portableDevice)))._portableDevice.SendCommand(0, parameters, out results));

            Marshal.ThrowExceptionForHR((int)results.GetErrorValue(Win32Native.PortableDevices.Commands.Common.Parameters.HResult, out HResult result));

            Marshal.ThrowExceptionForHR((int)result);

        }

    }

    public static class CommonCommands

    {

        public static void ResetDevice(PortableDevice portableDevice)

        {

            var values = new PortableDeviceValues();

            _ = values.SetGuidValue(Win32Native.PortableDevices.Commands.Common.Parameters.CommandCategory, new Guid(CommandCategories.Common));

            _ = values.SetUnsignedIntegerValue(Win32Native.PortableDevices.Commands.Common.Parameters.CommandId, Win32Native.PortableDevices.Commands.Common.Commands.ResetDevice.PropertyId);

            Commands. SendCommand(portableDevice, values, out _);

            _ = Marshal.ReleaseComObject(values);

        }

        public static string[] GetObjectIdsFromPersistentUniqueIds(PortableDevice portableDevice, string[] persistentUniqueIds)

        {

            if (portableDevice is null)

                throw new ArgumentNullException(nameof(portableDevice));

            if (persistentUniqueIds is null)

                throw new ArgumentNullException(nameof(persistentUniqueIds));

            var values = new PortableDeviceValues();

            _ = values.SetGuidValue(Win32Native.PortableDevices.Commands.Common.Parameters.CommandCategory, new Guid(CommandCategories.Common));

            _ = values.SetUnsignedIntegerValue(Win32Native.PortableDevices.Commands.Common.Parameters.CommandId, Win32Native.PortableDevices.Commands.Common.Commands.GetObjectIdsFromPersistentUniqueIds.PropertyId);

            var parameters = new PortableDevicePropVariantCollection();

            foreach (string persistentUniqueId in persistentUniqueIds)

                _ = parameters.Add(new PropVariant(persistentUniqueId));

            _ = values.SetIPortableDevicePropVariantCollectionValue(Win32Native.PortableDevices.Commands.Common.Parameters.PersistentUniqueIds, parameters);

            Commands. SendCommand(portableDevice, values, out IPortableDeviceValues results);

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
