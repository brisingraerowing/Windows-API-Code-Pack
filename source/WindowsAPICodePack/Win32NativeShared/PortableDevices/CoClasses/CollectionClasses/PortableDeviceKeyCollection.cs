//Copyright (c) Pierre Sprimont.  All rights reserved.

using Microsoft.WindowsAPICodePack.PropertySystem;
using Microsoft.WindowsAPICodePack.Win32Native.PortableDevices;
using Microsoft.WindowsAPICodePack.Win32Native.PropertySystem;
using Microsoft.WindowsAPICodePack.Win32Native.Shell.PropertySystem;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Microsoft.WindowsAPICodePack. Win32Native.PortableDevices.PropertySystem
{
    [ComImport,
        System.Runtime.InteropServices.Guid(Guids.PortableDevices.PortableDeviceValues),
        ClassInterface(ClassInterfaceType.None),
        TypeLibType(TypeLibTypeFlags.FCanCreate)]
    public class PortableDeviceKeyCollection { }
}
