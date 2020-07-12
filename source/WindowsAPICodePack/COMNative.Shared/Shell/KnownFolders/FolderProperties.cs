//Copyright (c) Microsoft Corporation.  All rights reserved.  Distributed under the Microsoft Public License (MS-PL)

using Microsoft.WindowsAPICodePack.Win32Native.Shell;
using System;
using System.Runtime.InteropServices;
using System.Windows.Media.Imaging;

namespace Microsoft.WindowsAPICodePack.COMNative.Shell
{
    /// <summary>
    /// Structure used publicly to store property values for a known folder. This structure holds the information returned in the FOLDER_DEFINITION structure, and resources referenced by fields in NativeFolderDefinition, such as icon and tool tip.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct FolderProperties
    {
        public string name;
        public FolderCategory category;
        public string canonicalName;
        public string description;
        public Guid parentId;
        public string parent;
        public string relativePath;
        public string parsingName;
        public string tooltipResourceId;
        public string tooltip;
        public string localizedName;
        public string localizedNameResourceId;
        public string iconResourceId;
        public BitmapSource icon;
        public DefinitionOptions definitionOptions;
        public FileAttributes fileAttributes;
        public Guid folderTypeId;
        public string folderType;
        public Guid folderId;
        public string path;
        public bool pathExists;
        public RedirectionCapability redirection;
        public string security;
    }
}
