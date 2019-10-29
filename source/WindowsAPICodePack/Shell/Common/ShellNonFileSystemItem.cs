﻿//Copyright (c) Microsoft Corporation.  All rights reserved.

using Microsoft.WindowsAPICodePack.Win32Native.Shell;

namespace Microsoft.WindowsAPICodePack.Shell
{
    /// <summary>
    /// Represents a non filesystem item (e.g. virtual items inside Control Panel)
    /// </summary>
    public class ShellNonFileSystemItem : ShellObject
    {
        internal ShellNonFileSystemItem(IShellItem2 shellItem) => nativeShellItem = shellItem;
    }
}