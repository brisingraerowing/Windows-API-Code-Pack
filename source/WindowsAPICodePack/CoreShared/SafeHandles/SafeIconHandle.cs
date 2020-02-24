//Copyright (c) Microsoft Corporation.  All rights reserved.

using Microsoft.WindowsAPICodePack.Win32Native;

namespace MS.WindowsAPICodePack
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
