//Copyright (c) Pierre Sprimont.  All rights reserved.

using System;

namespace Microsoft.WindowsAPICodePack.PortableDevices
{
    /// <summary>
    /// Represents a content object that is stored directly on a <see cref="IPortableDevice"/> or on a parent <see cref="IPortableDeviceObject"/>.
    /// </summary>
    public interface IPortableDeviceObject : WinCopies.
#if WAPICP2
        Util.
#endif
        DotNetFix.IDisposable
    {
        bool IsRoot { get; }

        /// <summary>
        /// Gets the id of the current <see cref="IPortableDeviceObject"/> on its parent device.
        /// </summary>
        string Id { get; }

#if CS7
        string Name { get; }
#else
#nullable enable
        string? Name { get; }
#nullable disable
#endif

        PortableDeviceFileType FileType { get; }

        Guid Type { get; }

        Microsoft.WindowsAPICodePack.PropertySystem.PropertyCollection Properties { get; }

        /// <summary>
        /// Gets the <see cref="IPortableDevice"/> on which the current <see cref="IPortableDeviceObject"/> is stored.
        /// </summary>
        IPortableDevice ParentPortableDevice { get; }

        /// <summary>
        /// Gets the parent <see cref="IPortableDeviceObject"/> if any; otherwise returns <see langword="null"/>.
        /// </summary>
        IPortableDeviceObject Parent { get; }
    }
}
