//Copyright (c) Pierre Sprimont.  All rights reserved.

using Microsoft.WindowsAPICodePack.Win32Native;
using Microsoft.WindowsAPICodePack.Win32Native.PortableDevices;
using Microsoft.WindowsAPICodePack.Win32Native.PortableDevices.EventSystem;
using Microsoft.WindowsAPICodePack.Win32Native.PortableDevices.PropertySystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.WindowsAPICodePack.Win32Native.PortableDevices
{
    [ComImport,
        Guid(Win32Native.Guids.PortableDevices.PortableDeviceFTM),
        ClassInterface(ClassInterfaceType.None),
        TypeLibType(TypeLibTypeFlags.FCanCreate)]
    public class PortableDevice 
    {

    }
}
