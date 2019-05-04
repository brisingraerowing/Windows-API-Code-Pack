//Copyright (c) Microsoft Corporation.  All rights reserved.

using Microsoft.WindowsAPICodePack.Win32Native;
using Microsoft.WindowsAPICodePack.Win32Native.Core;

namespace MS.WindowsAPICodePack.Internal
{
    /// <summary>
    /// Safe Icon Handle
    /// </summary>
    public class SafeIconHandle : ZeroInvalidHandle
    {
        /// <summary>
        /// Release the handle
        /// </summary>
        /// <returns>true if handled is release successfully, false otherwise</returns>
        protected override bool ReleaseHandle() => CoreNativeMethods.DestroyIcon(handle);
    }
}
