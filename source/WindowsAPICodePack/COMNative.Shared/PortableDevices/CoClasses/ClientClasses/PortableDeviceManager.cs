//Copyright (c) Pierre Sprimont.  All rights reserved.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAPICodePack.COMNative;

namespace Microsoft.WindowsAPICodePack.COMNative.PortableDevices
{
    [ComImport,
        Guid(NativeAPI.Guids.PortableDevices.PortableDeviceManager),
        ClassInterface(ClassInterfaceType.None),
        TypeLibType(TypeLibTypeFlags.FCanCreate)]
    public class PortableDeviceManager 
    {
      
    }
}
