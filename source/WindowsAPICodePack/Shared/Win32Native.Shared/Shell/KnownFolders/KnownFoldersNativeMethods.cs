//Copyright (c) Microsoft Corporation.  All rights reserved.  Distributed under the Microsoft Public License (MS-PL)

using Microsoft.WindowsAPICodePack.Win32Native.Shell;
using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Microsoft.WindowsAPICodePack.Win32Native.Shell
{
    /// <summary>
    /// Internal class that contains interop declarations for 
    /// functions that are considered benign but that
    /// are performance critical. 
    /// </summary>
    /// <remarks>
    /// Functions that are benign but not performance critical 
    /// should be located in the NativeMethods class.
    /// </remarks>
    [SuppressUnmanagedCodeSecurity]
    public static class KnownFoldersSafeNativeMethods
    {
        #region KnownFolders

        [StructLayout(LayoutKind.Sequential)]
        public struct NativeFolderDefinition
        {
            public FolderCategory category;
            public IntPtr name;
            public IntPtr description;
            public Guid parentId;
            public IntPtr relativePath;
            public IntPtr parsingName;
            public IntPtr tooltip;
            public IntPtr localizedName;
            public IntPtr icon;
            public IntPtr security;
            public uint attributes;
            public DefinitionOptions definitionOptions;
            public Guid folderTypeId;
        }

        #endregion
    }
}
