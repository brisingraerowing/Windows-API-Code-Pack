//Copyright (c) Microsoft Corporation.  All rights reserved.  Distributed under the Microsoft Public License (MS-PL)

using System;
using System.Runtime.InteropServices;

namespace Microsoft.WindowsAPICodePack
{
    /// <summary>
    /// Base class for Safe handles with Null IntPtr as invalid
    /// </summary>
    public abstract class ZeroInvalidHandle : SafeHandle
    {
        /// <summary>
        /// Determines if this is a valid handle
        /// </summary>
        public override bool IsInvalid => handle == IntPtr.Zero;

        /// <summary>
        /// Default constructor
        /// </summary>
        protected ZeroInvalidHandle() : base(IntPtr.Zero, true) { /* Left empty. */ }
    }
}
