//Copyright (c) Microsoft Corporation.  All rights reserved.  Distributed under the Microsoft Public License (MS-PL)

using Microsoft.WindowsAPICodePack.ExtendedLinguisticServices;
using System;
using System.Runtime.InteropServices;

namespace Microsoft.WindowsAPICodePack.Win32Native.ExtendedLinguisticServices
{

    public static class ExtendedLinguisticServicesNativeMethods
    {
        [DllImport("elscore.dll", EntryPoint = "MappingGetServices", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern uint MappingGetServices(ref Win32EnumOptions enumOptions, ref IntPtr services, ref uint servicesCount);

        // For performance reasons, if we need to pass NULL as the MappingEnumOptions
        [DllImport("elscore.dll", EntryPoint = "MappingGetServices", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern uint MappingGetServices(IntPtr enumOptions, ref IntPtr services, ref uint servicesCount);

        [DllImport("elscore.dll", EntryPoint = "MappingRecognizeText", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern uint MappingRecognizeText(IntPtr service, IntPtr text, uint length, uint index, IntPtr options, ref Win32PropertyBag bag);

        [DllImport("elscore.dll", EntryPoint = "MappingDoAction", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern uint MappingDoAction(ref Win32PropertyBag bag, uint rangeIndex, string action);

        [DllImport("elscore.dll", EntryPoint = "MappingFreePropertyBag", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern uint MappingFreePropertyBag(ref Win32PropertyBag bag);

        [DllImport("elscore.dll", EntryPoint = "MappingFreeServices", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern uint MappingFreeServices(IntPtr pServiceInfo);

        [DllImport("elscore.dll", EntryPoint = "MappingFreeServices", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern void MappingFreeServicesVoid(IntPtr pServiceInfo);
    }

}
