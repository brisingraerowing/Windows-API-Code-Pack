//Copyright (c) Pierre Sprimont.  All rights reserved.

using Microsoft.WindowsAPICodePack.COMNative;
using Microsoft.WindowsAPICodePack.COMNative.PortableDevices;
using Microsoft.WindowsAPICodePack.COMNative.PortableDevices.EventSystem;
using Microsoft.WindowsAPICodePack.COMNative.PortableDevices.PropertySystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.WindowsAPICodePack.COMNative.PortableDevices
{
    [ComImport,
        Guid(NativeAPI.Guids.PortableDevices.PortableDeviceFTM),
        ClassInterface(ClassInterfaceType.None),
        TypeLibType(TypeLibTypeFlags.FCanCreate)]
    public class PortableDevice 
    {

    }
}
