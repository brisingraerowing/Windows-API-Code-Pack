using Microsoft.WindowsAPICodePack.Win32Native.PortableDevices.PropertySystem;
using Microsoft.WindowsAPICodePack.Win32Native.PropertySystem;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace Microsoft.WindowsAPICodePack.Win32Native.PortableDevices.PropertySystem
{
    [ComImport,
        Guid(Guids.PortableDevices.PortableDevicePropVariantCollection),
        ClassInterface(ClassInterfaceType.None),
        TypeLibType(TypeLibTypeFlags.FCanCreate)]
    public class PortableDevicePropVariantCollection { }
}
