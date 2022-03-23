﻿//Copyright (c) Microsoft Corporation.  All rights reserved.  Distributed under the Microsoft Public License (MS-PL)

using Microsoft.WindowsAPICodePack.COMNative.Shell;
using Microsoft.WindowsAPICodePack.Shell;
using Microsoft.WindowsAPICodePack.Shell.PropertySystem;
using Microsoft.WindowsAPICodePack.Win32Native.Shell;

namespace Microsoft.WindowsAPICodePack.Taskbar
{
    /// <summary>
    /// Interface for jump list items
    /// </summary>
    public interface IJumpListItem
    {
        /// <summary>
        /// Gets or sets this item's path
        /// </summary>
        string Path { get; set; }
    }

    /// <summary>
    /// Interface for jump list tasks
    /// </summary>
    public abstract class JumpListTask
    {
        internal abstract IShellLinkW NativeShellLink { get; }
    }
}
