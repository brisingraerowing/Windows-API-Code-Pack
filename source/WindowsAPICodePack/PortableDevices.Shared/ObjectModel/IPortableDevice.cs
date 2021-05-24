using Microsoft.WindowsAPICodePack.PortableDevices.PropertySystem;
using System;
using System.IO;

#if !WAPICP3
using System.Collections.Generic;
#endif

namespace Microsoft.WindowsAPICodePack.PortableDevices
{
    /// <summary>
    /// Represents a portable device.
    /// </summary>
    public interface IPortableDevice :  /*PortableDevices Enumerable Interface*/ IEnumerable, WinCopies.
#if WAPICP2
        Util.
#endif
        DotNetFix.IDisposable
#if !WAPICP3
, IReadOnlyCollection<IPortableDeviceObject>, IReadOnlyList<IPortableDeviceObject>
#endif
    {
        /// <summary>
        /// Gets the <see cref="IPortableDeviceManager"/> for this device.
        /// </summary>
        IPortableDeviceManager PortableDeviceManager { get; }

        IDeviceCapabilities DeviceCapabilities { get; }

        Microsoft.WindowsAPICodePack.PropertySystem.PropertyCollection Properties { get; }

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

#if WAPICP3
        string CreateFolder(string name);

        void TransferTo(FileStream stream, int bufferSize, bool forceBufferSize, Guid contentType, Guid objectFormat, PortableDeviceTransferCallback d);
#endif
    }
}
