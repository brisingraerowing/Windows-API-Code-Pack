//Copyright (c) Microsoft Corporation.  All rights reserved.  Distributed under the Microsoft Public License (MS-PL)

using System;
using System.Runtime.InteropServices;

namespace Microsoft.WindowsAPICodePack.COMNative.Shell
{
    [ComImport,
    Guid(NativeAPI.Guids.Shell.IShellLibrary),
    CoClass(typeof(ShellLibraryCoClass))]
    public interface INativeShellLibrary : IShellLibrary
    {
    }

    [ComImport,
    ClassInterface(ClassInterfaceType.None),
    TypeLibType(TypeLibTypeFlags.FCanCreate),
    Guid(NativeAPI.Guids.Shell.ShellLibrary)]
    public class ShellLibraryCoClass
    {
    }
}
