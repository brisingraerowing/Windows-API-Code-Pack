//Copyright (c) Microsoft Corporation.  All rights reserved.  Distributed under the Microsoft Public License (MS-PL)

using Microsoft.WindowsAPICodePack.Win32Native.GDI;

namespace Microsoft.WindowsAPICodePack
{
    /// <summary>
    /// Safe Region Handle
    /// </summary>
    public class SafeRegionHandle : ZeroInvalidHandle
    {
        /// <summary>
        /// Release the handle
        /// </summary>
        /// <returns>true if handled is release successfully, false otherwise</returns>
        protected override bool ReleaseHandle() => GDI.DeleteObject(handle);
    }
}
