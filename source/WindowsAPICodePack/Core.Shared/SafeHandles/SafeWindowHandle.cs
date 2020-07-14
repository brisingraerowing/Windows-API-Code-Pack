//Copyright (c) Microsoft Corporation.  All rights reserved.  Distributed under the Microsoft Public License (MS-PL)

using Microsoft.WindowsAPICodePack.Win32Native;
using System.Security.Permissions;
namespace Microsoft.WindowsAPICodePack
{
    /// <summary>
    /// Safe Window Handle
    /// </summary>
    public class SafeWindowHandle : ZeroInvalidHandle
    {
        /// <summary>
        /// Release the handle
        /// </summary>
        /// <returns>true if handled is release successfully, false otherwise</returns>
        protected override bool ReleaseHandle() => IsInvalid ? true : Core.DestroyWindow(handle) != 0;
    }
}
