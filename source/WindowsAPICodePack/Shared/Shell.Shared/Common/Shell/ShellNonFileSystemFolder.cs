//Copyright (c) Microsoft Corporation.  All rights reserved.  Distributed under the Microsoft Public License (MS-PL)

using Microsoft.WindowsAPICodePack.COMNative.Shell;

namespace Microsoft.WindowsAPICodePack.Shell
{
    /// <summary>
    /// Represents a Non FileSystem folder (e.g. My Computer, Control Panel)
    /// </summary>
    public class ShellNonFileSystemFolder : ShellFolder
    {
        #region Internal Constructors
        internal ShellNonFileSystemFolder() { /* Left empty */ }

        internal ShellNonFileSystemFolder(IShellItem2 shellItem) => _nativeShellItem = shellItem;
        #endregion
    }
}
