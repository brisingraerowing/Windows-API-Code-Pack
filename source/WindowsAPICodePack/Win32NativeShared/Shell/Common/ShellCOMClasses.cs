//Copyright (c) Microsoft Corporation.  All rights reserved.

using System;
using System.Runtime.InteropServices;

namespace Microsoft.WindowsAPICodePack.Win32Native.Shell
{
    [ComImport,
    Guid(Guids.Shell.IShellLibrary),
    CoClass(typeof(ShellLibraryCoClass))]
    public interface INativeShellLibrary : IShellLibrary
    {
    }

    [ComImport,
    ClassInterface(ClassInterfaceType.None),
    TypeLibType(TypeLibTypeFlags.FCanCreate),
    Guid(Guids.Shell.ShellLibrary)]
    public class ShellLibraryCoClass
    {
    }
}
