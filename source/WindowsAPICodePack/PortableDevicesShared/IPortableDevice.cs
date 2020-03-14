using Microsoft.WindowsAPICodePack.PortableDevices;
using Microsoft.WindowsAPICodePack.PortableDevices.PropertySystem;
using Microsoft.WindowsAPICodePack.PropertySystem;
using Microsoft.WindowsAPICodePack.Win32Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.WindowsAPICodePack.PortableDevices
{
    /// <summary>
    /// Represents a portable device.
    /// </summary>
    public interface IPortableDevice : IEnumerable<IPortableDeviceObject>, IReadOnlyCollection<IPortableDeviceObject>, IReadOnlyList<IPortableDeviceObject>, WinCopies.Util.DotNetFix. IDisposable
    {

        /// <summary>
        /// Gets the <see cref="IPortableDeviceManager"/> for this device.
        /// </summary>
        IPortableDeviceManager PortableDeviceManager { get; }

        IDeviceCapabilities DeviceCapabilities { get; }

        PropertyCollection Properties { get; }

        string DeviceId { get; }

        /// <summary>
        /// Gets the device friendly name.
        /// </summary>
        string DeviceFriendlyName { get; }

        /// <summary>
        /// Gets the device description.
        /// </summary>
        string DeviceDescription { get; }

        /// <summary>
        /// Gets the device manufacturer.
        /// </summary>
        string DeviceManufacturer { get; }

        /// <summary>
        /// Gets a value that indicates whether the device is open.
        /// </summary>
        bool IsOpen { get; }

        PortableDeviceOpeningOptions PortableDeviceOpeningOptions { get; }

        /// <summary>
        /// Opens a connection to the device.
        /// </summary>
        /// <param name="clientVersion">The client info and version that will be registered by the device.</param>
        /// <param name="portableDeviceOpeningOptions">The opening options.</param>
        void Open(in ClientVersion clientVersion, in PortableDeviceOpeningOptions portableDeviceOpeningOptions);

        /// <summary>
        /// Closes the connection with the device.
        /// </summary>
        void Close();

        /// <summary>
        /// Returns a property that is specific to the current device model.
        /// </summary>
        /// <param name="propertyName">The name of the property for which to get the value.</param>
        /// <param name="defaultValue">The default value that is returned if the operation fails.</param>
        /// <param name="doNotExpand">A value that indicates whether to expand environment variables.</param>
        /// <param name="valueKind">The kind of data that was retrieved.</param>
        /// <returns>If the method succeeds, the value of the property that was requested are returned; otherwise this method returns <paramref name="defaultValue"/>.</returns>
        object GetDeviceProperty(in string propertyName, in object defaultValue, in bool doNotExpand, out BlobValueKind valueKind);

        ReadOnlyPortableDeviceValueCollection SendCommand(in ReadOnlyPortableDeviceValueCollection parameters);

        ReadOnlyPortableDeviceValueCollection SendCommand(in PortableDeviceValueCollection parameters);

    }

    /// <summary>
    /// Represents a content object that is stored directly on a <see cref="IPortableDevice"/> or on a parent <see cref="IPortableDeviceObject"/>.
    /// </summary>
    public interface IPortableDeviceObject : WinCopies.Util.DotNetFix.IDisposable, IEnumerable<IPortableDeviceObject>

    {

        /// <summary>
        /// Gets the id of the current <see cref="IPortableDeviceObject"/> on its parent device.
        /// </summary>
        string Id { get; }

#if NETFRAMEWORK

        string Name { get; }

#else

#nullable enable
        string? Name { get; }
#nullable disable

#endif

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
