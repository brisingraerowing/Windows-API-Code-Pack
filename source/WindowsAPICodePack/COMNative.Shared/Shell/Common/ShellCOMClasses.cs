//Copyright (c) Microsoft Corporation.  All rights reserved.

using System;
using System.Runtime.InteropServices;

namespace Microsoft.WindowsAPICodePack.COMNative.Shell
{
    [ComImport,
    Guid(Win32Native.Guids.Shell.IShellLibrary),
    CoClass(typeof(ShellLibraryCoClass))]
    public interface INativeShellLibrary : IShellLibrary
    {
    }

    [ComImport,
    ClassInterface(ClassInterfaceType.None),
    TypeLibType(TypeLibTypeFlags.FCanCreate),
    Guid(Win32Native.Guids.Shell.ShellLibrary)]
    public class ShellLibraryCoClass
    {
    }
}
