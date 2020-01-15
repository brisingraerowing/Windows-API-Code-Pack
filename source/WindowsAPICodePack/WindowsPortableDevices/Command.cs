using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.WindowsAPICodePack.PortableDevices.PropertySystem.Commands
{
    [Flags]
    public enum Common
    {

        ResetDevice = 1,
        GetObjectIdsFromPersistentUniqueIds = 2,
        SaveClientInformation = 4

    }

    namespace Object

    {

        [Flags]
        public enum Enumeration
        {

            StartFind = 1,
            FindNext = 2,
            EndFind = 4

        }

        [Flags]
        public enum Property
        {

            GetSupported = 1,
            GetAttributes = 2,
            Get = 4,
            Set = 8,
            GetAll = 16,
            Delete = 32

        }

        [Flags]
        public enum PropertyBulk
        {

            GetValuesByObjectListStart = 1,
            GetValuesByObjectListNext = 2,
            GetValuesByObjectListEnd = 4,
            GetValuesByObjectFormatStart = 8,
            GetValuesByObjectFormatNext = 16,
            GetValuesByObjectFormatEnd = 32,
            SetValuesByObjectListStart = 64,
            SetValuesByObjectListNext = 128,
            SetValuesByObjectListEnd = 256,

        }

        [Flags]
        public enum Resource
        {

            GetSupported = 1,
            GetAttributes = 2,
            Open = 4,
            Read = 8,
            Write = 16,
            Close = 32,
            Delete = 64,
            CreateResource = 128,
            Revert = 256,
            Seek = 512,
            Commit = 1024,
            SeekInUnits = 2048

        }

        [Flags]
        public enum Management
        {

            CreateObjectWithPropertiesOnly = 1,
            CreateObjectWithPropertiesAndData = 2,
            WriteObjectData = 4,
            CommitObject = 8,
            RevertObject = 16,
            DeleteObjects = 32,
            MoveObjects = 64,
            CopyObjects = 128,
            UpdateObjectWithPropertiesAndData = 256

        }

    }

    [Flags]
    public enum Capability
    {

        GetSupportedCommands = 1,
        GetCommandOptions = 2,
        GetSupportedFunctionalCategories = 4,
        GetFunctionalObjects = 8,
        GetSupportedContentTypes = 16,
        GetSupportedFormats = 32,
        GetSupportedFormatProperties = 64,
        GetFixedPropertyAttributes = 128,
        GetSupportedEvents = 256,
        GetEventOptions = 512

    }

    [Flags]
    public enum Storage
    {

        Format = 1,
        Eject = 2

    }

    [Flags]
    public enum SMS
    {

        Send = 1


    }

    [Flags]
    public enum StillImageCapture
    {

        Initiate = 1

    }
    [Flags]
    public enum MediaCapture
    {

        Start = 1,
        Stop = 2,
        Pause = 4

    }

    [Flags]
    public enum DeviceHint
    {

        GetContentLocation = 1

    }

    [Flags]
    public enum ClassExtension
    {

        WriteDeviceInformation = 1,
        RegisterServiceInterfaces = 2,
        UnregisterServiceInterfaces = 4

    }

    [Flags]
    public enum NetworkConfiguration
    {

        GenerateKeyPair = 1,
        CommitKeyPair = 2,
        ProcessWirelessProfile = 4

    }

    namespace Service

    {

        [Flags]
        public enum Common
        {

            GetServiceObjectId = 1

        }

        [Flags]
        public enum Capability
        {

            GetSupportedMethods = 1,
            GetSupportedMethodsByFormat = 2,
            GetMethodAttributes = 4,
            GetMethodParameterAttributes = 8,
            GetSupportedFormats = 16,
            GetFormatAttributes = 32,
            GetSupportedFormatProperties = 64,
            GetFormatPropertyAttributes = 128,
            GetSupportedEvents = 256,
            GetEventAttributes = 512,
            GetEventParameterAttributes = 1024,
            GetInheritedServices = 2048,
            GetFormatRenderingProfiles = 4096,
            GetSupportedCommands = 8192,
            GetCommandOptions = 16384

        }

        [Flags]
        public enum Method
        {

            StartInvoke = 1,
            CancelInvoke = 2,
            EndInvoke = 4

        }

    }

    public class Command
    {

    }
}
