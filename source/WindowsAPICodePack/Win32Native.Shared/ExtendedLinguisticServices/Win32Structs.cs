// Copyright (c) Microsoft Corporation.  All rights reserved.

using System;
using System.Runtime.InteropServices;

namespace Microsoft.WindowsAPICodePack.ExtendedLinguisticServices
{

    [Flags]
    public enum ServiceTypes
    {
        None = 0x0,
        IsOneToOneLanguageMapping = 0x1,
        HasSubServices = 0x2,
        OnlineOnly = 0x4,
        HighLevel = 0x8,
        LowLevel = 0x16,
    }

    [Flags]
    public enum EnumTypes
    {
        None = 0x0,
        OnlineService = 0x1,
        OfflineService = 0x2,
        HighLevel = 0x4,
        LowLevel = 0x8,
    }

    // Lives in native memory.
    // Only used for a temporary managed copy.
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct Win32Service
    {
        public IntPtr _size;
        [MarshalAs(UnmanagedType.LPWStr)]
        public string _copyright;
        public ushort _majorVersion;
        public ushort _minorVersion;
        public ushort _buildVersion;
        public ushort _stepVersion;
        public uint _inputContentTypesCount;
        public IntPtr _inputContentTypes;
        public uint _outputContentTypesCount;
        public IntPtr _outputContentTypes;
        public uint _inputLanguagesCount;
        public IntPtr _inputLanguages;
        public uint _outputLanguagesCount;
        public IntPtr _outputLanguages;
        public uint _inputScriptsCount;
        public IntPtr _inputScripts;
        public uint _outputScriptsCount;
        public IntPtr _outputScripts;
        public Guid _guid;
        [MarshalAs(UnmanagedType.LPWStr)]
        public string _category;
        [MarshalAs(UnmanagedType.LPWStr)]
        public string _description;
        public uint _privateDataSize;
        public IntPtr _privateData;
        public IntPtr _context;
        public ServiceTypes _serviceTypes;
    }

    // Lives in managed memory. Used to pass parameters.
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct Win32EnumOptions
    {
        public IntPtr _size;
        [MarshalAs(UnmanagedType.LPWStr)]
        public string _category;
        [MarshalAs(UnmanagedType.LPWStr)]
        public string _inputLanguage;
        [MarshalAs(UnmanagedType.LPWStr)]
        public string _outputLanguage;
        [MarshalAs(UnmanagedType.LPWStr)]
        public string _inputScript;
        [MarshalAs(UnmanagedType.LPWStr)]
        public string _outputScript;
        [MarshalAs(UnmanagedType.LPWStr)]
        public string _inputContentType;
        [MarshalAs(UnmanagedType.LPWStr)]
        public string _outputContentType;
        public IntPtr _pGuid;
        public EnumTypes _serviceTypes;
    }

    // Lives in managed memory. Used to pass parameters.
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct Win32Options
    {
        public IntPtr _size;
        [MarshalAs(UnmanagedType.LPWStr)]
        public string _inputLanguage;
        [MarshalAs(UnmanagedType.LPWStr)]
        public string _outputLanguage;
        [MarshalAs(UnmanagedType.LPWStr)]
        public string _inputScript;
        [MarshalAs(UnmanagedType.LPWStr)]
        public string _outputScript;
        [MarshalAs(UnmanagedType.LPWStr)]
        public string _inputContentType;
        [MarshalAs(UnmanagedType.LPWStr)]
        public string _outputContentType;
        public IntPtr _UILanguage;
        public IntPtr _recognizeCallback;
        public IntPtr _recognizeCallerData;
        public uint _recognizeCallerDataSize;
        public IntPtr _actionCallback;
        public IntPtr _actionCallerData;
        public uint _actionCallerDataSize;
        public uint _serviceFlag;
        public uint _getActionDisplayName;
    }

    // Lives in managed memory. Used to represent results.
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct Win32DataRange
    {
        public uint _startIndex;
        public uint _endIndex;
        public IntPtr _description;
        public uint _descriptionLength;
        public IntPtr _data;
        public uint _dataSize;
        [MarshalAs(UnmanagedType.LPWStr)]
        public string _contentType;
        public IntPtr _actionIDs;
        public uint _actionsCount;
        public IntPtr _actionDisplayNames;
    }

    // Lives in managed memory.
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct Win32PropertyBag
    {
        public IntPtr _size;
        public IntPtr _ranges;
        public uint _rangesCount;
        public IntPtr _serviceData;
        public uint _serviceDataSize;
        public IntPtr _callerData;
        public uint _callerDataSize;
        public IntPtr _context;
    }

}
