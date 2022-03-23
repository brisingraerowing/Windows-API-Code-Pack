//Copyright (c) Microsoft Corporation.  All rights reserved.  Distributed under the Microsoft Public License (MS-PL)

using Microsoft.WindowsAPICodePack.COMNative.Shell;
using Microsoft.WindowsAPICodePack.Win32Native.Shell;

namespace Microsoft.WindowsAPICodePack.Shell
{
    /// <summary>
    /// Represents the base class for all search-related classes.
    /// </summary>
    public class ShellSearchCollection : ShellContainer
    {
        public ShellSearchCollection() { }

        public ShellSearchCollection(IShellItem2 shellItem) : base(shellItem) { }
    }
}
