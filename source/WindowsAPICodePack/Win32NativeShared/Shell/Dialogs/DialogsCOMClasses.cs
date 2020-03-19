//Copyright (c) Microsoft Corporation.  All rights reserved.

using System;
using System.Runtime.InteropServices;

namespace Microsoft.WindowsAPICodePack.Win32Native.Dialogs
{

    // Dummy base interface for CommonFileDialog coclasses.
    public interface NativeCommonFileDialog
    {
    }

    // Coclass interfaces - designed to "look like" the object 
    // in the API, so that the 'new' operator can be used in a 
    // straightforward way. Behind the scenes, the C# compiler
    // morphs all 'new CoClass()' calls to 'new CoClassWrapper()'.

    [ComImport,
    Guid(Guids.Shell.IFileOpenDialog),
    CoClass(typeof(FileOpenDialogRCW))]
    public interface NativeFileOpenDialog : IFileOpenDialog
    {
    }

    [ComImport,
    Guid(Guids.Shell.IFileSaveDialog),
    CoClass(typeof(FileSaveDialogRCW))]
    public interface NativeFileSaveDialog : IFileSaveDialog
    {
    }

    // .NET classes representing runtime callable wrappers.
    [ComImport,
    ClassInterface(ClassInterfaceType.None),
    TypeLibType(TypeLibTypeFlags.FCanCreate),
    Guid(Guids.Shell.FileOpenDialog)]
    public class FileOpenDialogRCW
    {
    }

    [ComImport,
    ClassInterface(ClassInterfaceType.None),
    TypeLibType(TypeLibTypeFlags.FCanCreate),
    Guid(Guids.Shell.FileSaveDialog)]
    public class FileSaveDialogRCW
    {
    }

}
