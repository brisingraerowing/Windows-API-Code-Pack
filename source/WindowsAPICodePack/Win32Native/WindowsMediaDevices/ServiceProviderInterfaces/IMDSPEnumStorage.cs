using Microsoft.WindowsAPICodePack.Win32Native;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Microsoft.WindowsAPICodePack.Win32Native.MediaDevices
{
    [ComImport,
        Guid(Guids.MediaDevices.IMDSPEnumStorage),
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IMDSPEnumStorage
    {
        HResult Next(
            [In] uint celt,
            [Out] out IMDSPStorage ppStorage,
            [Out] out uint pceltFetched);

        HResult Skip(
           [In] uint celt,
            [Out] out uint pceltFetched);

        HResult Reset();

        HResult Clone(
            [Out] out IMDSPEnumStorage ppEnumStorage);
    }
}
