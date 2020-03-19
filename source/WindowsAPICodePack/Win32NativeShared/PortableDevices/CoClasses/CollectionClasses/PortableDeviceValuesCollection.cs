//Copyright (c) Pierre Sprimont.  All rights reserved.

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using GuidAttribute = System.Runtime.InteropServices.GuidAttribute;

namespace Microsoft.WindowsAPICodePack.Win32Native.PortableDevices.PropertySystem
{
    [ComImport,
        Guid(Guids.PortableDevices.PortableDeviceValuesCollection),
        ClassInterface(ClassInterfaceType.None),
        TypeLibType(TypeLibTypeFlags.FCanCreate)]
    public class PortableDeviceValuesCollection { }
}
