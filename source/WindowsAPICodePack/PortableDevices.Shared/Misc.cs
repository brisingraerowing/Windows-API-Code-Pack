using Microsoft.WindowsAPICodePack.COMNative.PortableDevices.PropertySystem;
using Microsoft.WindowsAPICodePack.PortableDevices.PropertySystem;
using Microsoft.WindowsAPICodePack.Win32Native;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

using static WinCopies.
#if WAPICP3
    ThrowHelper;
#else
    Util.Util;
#endif

namespace Microsoft.WindowsAPICodePack.PortableDevices
{
#if WAPICP3
    internal class PortableDeviceEventCallback : COMNative.PortableDevices.EventSystem.IPortableDeviceEventCallback
    {
        private PortableDevice _portableDevice;

        public PortableDeviceEventCallback(in PortableDevice portableDevice) => _portableDevice = portableDevice;

        public HResult OnEvent(IPortableDeviceValues pEventParameters)
        {
            _portableDevice.OnUpdate(new PortableDeviceUpdatedEventArgs(pEventParameters));

            return HResult.Ok;
        }
    }

    public class PortableDeviceUpdatedEventArgs : EventArgs
    {
        public ReadOnlyPortableDeviceValueCollection EventArgValues { get; }

        public PortableDeviceUpdatedEventArgs(in IPortableDeviceValues portableDeviceValues) => EventArgValues = new ReadOnlyPortableDeviceValueCollection(new NativeValueCollection(portableDeviceValues));
    }

    public class PortableDeviceObjectEventArgs : EventArgs
    {
        public string Id { get; }

        public PortableDeviceObjectEventArgs(in string id) => Id = id;
    }

    public delegate void PortableDeviceUpdatedEventHandler(object sender, PortableDeviceUpdatedEventArgs e);
    public delegate void PortableDeviceObjectEventHandler(object sender, PortableDeviceObjectEventArgs e);
#endif

    public delegate bool PortableDeviceTransferCallback(uint written);

    public enum PortableDeviceFileType : short
    {
        None = 0,

        Folder = 1,

        File = 2,

        FunctionalObject = 3
    }

    public interface IEnumerable
#if WAPICP3
        : System.Collections.Generic.IEnumerable<IPortableDeviceObject>
#endif
    {
        void TransferTo(System.IO.FileStream stream, int bufferSize, bool forceBufferSize, Guid contentType, Guid objectFormat, PortableDeviceTransferCallback d);
    }

    public interface IEnumerablePortableDeviceObject : IPortableDeviceObject,/*PortableDevices Enumerable Interface*/ IEnumerable
#if !WAPICP3
, System.Collections.Generic. IEnumerable<IPortableDeviceObject>, System.Collections.Generic.IReadOnlyCollection<IPortableDeviceObject>, System.Collections.Generic.IReadOnlyList<IPortableDeviceObject>
#endif
    {
        // Left empty.
    }

    public interface IPortableDeviceFolder : IEnumerablePortableDeviceObject
    {
        IPortableDeviceObjectStorageCapacity StorageCapacity { get; }
    }

    public interface IPortableDeviceFile : IPortableDeviceObject
    {
        /// <summary>
        /// Gets the size, in bytes, of the current file.
        /// </summary>
        ulong Size { get; }

        /// <summary>
        /// Transfers the current file from its device to a given <see cref="Stream"/>. Note that, in order to keep this method atomic, <paramref name="stream"/> is not flushed, closed nor disposed. The caller is responsible to correctly dispose <paramref name="stream"/>.
        /// </summary>
        /// <param name="stream">The <see cref="Stream"/> to write to.</param>
        /// <param name="bufferSize">The default buffer size to use if any optimal buffer size could be retrieved.</param>
        /// <param name="forceBufferSize">Whether to force using <paramref name="bufferSize"/> even if an optimal buffer size could be retrieved.</param>
        /// <param name="d">A callback that will be called when each buffer has been written to <paramref name="stream"/>. This parameter can be <see langword="null"/>.</param>
        /// <exception cref="ArgumentException"><paramref name="stream"/>.<see cref="Stream.CanWrite"/> is set to <see langword="false"/>.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="bufferSize"/> is less than or equal to 0.</exception>
        /// <seealso cref="TransferFrom(string, FileMode,  FileShare, int, bool, PortableDeviceTransferCallback)"/>
        void TransferFrom(System.IO.Stream stream, int bufferSize, bool forceBufferSize, PortableDeviceTransferCallback d);

#if WAPICP3
        /// <summary>
        /// Transfers the current file from its device to a given path on the destination computer file system. For potential exceptions, see <see cref="FileStream"/>'s constructors in addition to those specific for this method.
        /// </summary>
        /// <param name="path">The path to write to.</param>
        /// <param name="fileMode">How the destination file should be opened.</param>
        /// <param name="fileShare">How access to the destination file should be shared.</param>
        /// <param name="bufferSize">The default buffer size to use if any optimal buffer size could be retrieved.</param>
        /// <param name="forceBufferSize">Whether to force using <paramref name="bufferSize"/> even if an optimal buffer size could be retrieved.</param>
        /// <param name="d">A callback that will be called when each buffer has been written. This parameter can be <see langword="null"/>.</param>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="bufferSize"/> is less than or equal to 0.</exception>
        /// <seealso cref="TransferFrom(Stream, int, bool, PortableDeviceTransferCallback)"/>
        void TransferFrom(string path, FileMode fileMode, FileShare fileShare, int bufferSize, bool forceBufferSize, PortableDeviceTransferCallback d);
#endif
    }

    public static class PortableDevicesHelper
    {
        public static void ThrowIfOperationIsNotAllowed(this IPortableDeviceObject portableDeviceObject)
        {
            if ((portableDeviceObject ?? throw GetArgumentNullException(nameof(portableDeviceObject))).ParentPortableDevice.IsDisposed)

                throw new ObjectDisposedException("The parent portalbe device is disposed.");

            if (!portableDeviceObject.ParentPortableDevice.IsOpen)

                throw new PortableDeviceException("The portable device is not open.");
        }
    }
}
