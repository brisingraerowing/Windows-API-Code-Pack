//Copyright (c) Pierre Sprimont.  All rights reserved.

using System;
using System.Runtime.InteropServices;

using GuidAttribute = System.Runtime.InteropServices.GuidAttribute;

namespace Microsoft.WindowsAPICodePack.COMNative.PortableDevices.PropertySystem
{
    [ComImport,
        Guid(NativeAPI.Guids.PortableDevices.PortableDeviceValuesCollection),
        ClassInterface(ClassInterfaceType.None),
        TypeLibType(TypeLibTypeFlags.FCanCreate)]
    public class PortableDeviceValuesCollection { }
}
