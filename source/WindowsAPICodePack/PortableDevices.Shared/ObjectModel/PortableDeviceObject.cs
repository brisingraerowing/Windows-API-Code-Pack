//Copyright (c) Pierre Sprimont.  All rights reserved.

using Microsoft.WindowsAPICodePack.COMNative.PortableDevices.PropertySystem;
using Microsoft.WindowsAPICodePack.PortableDevices.PropertySystem;
using Microsoft.WindowsAPICodePack.PropertySystem;
using Microsoft.WindowsAPICodePack.Win32Native.PropertySystem;

using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;

#if WAPICP3
using WinCopies.Collections.Generic;

using static WinCopies.ThrowHelper;
#else
using System.Collections.Generic;

using static WinCopies.Util.Util;
#endif

using static Microsoft.WindowsAPICodePack.COMNative.PortableDevices.PortableDeviceHelper;

using PropertyCollection = Microsoft.WindowsAPICodePack.PortableDevices.PropertySystem.PropertyCollection;
using Microsoft.WindowsAPICodePack.Win32Native;
using Microsoft.WindowsAPICodePack.PortableDevices.CommandSystem.Object;

namespace Microsoft.WindowsAPICodePack.PortableDevices
{
    public enum PortableDeviceFileType : short
    {
        None = 0,

        Folder = 1,

        File = 2,

        FunctionalObject = 3
    }

    public interface IEnumerable
#if WAPICP3
        : System.Collections.Generic.IReadOnlyCollection<IPortableDeviceObject>, System.Collections.Generic.IReadOnlyList<IPortableDeviceObject>
#endif
    {
        void TransferTo(System.IO.FileStream stream, int bufferSize, bool forceBufferSize, Guid contentType, Guid objectFormat, PortableDeviceTransferCallback d);

#if WAPICP3
        event PortableDeviceObjectEventHandler PortableDeviceObjectAdded;
        event PortableDeviceObjectEventHandler PortableDeviceObjectRemoved;
        //        void TransferFrom(string path, FileMode fileMode, FileShare fileShare, int bufferSize, bool forceBufferSize, PortableDeviceTransferStartedCallback started, PortableDeviceTransferCallback d);
#endif
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

    // todo: implement other common properties

#if WAPICP3
    internal
#else
        public
#endif
        abstract class PortableDeviceObject : IPortableDeviceObject
    {
        #region Fields
        private readonly bool _isRoot;
        private protected string _id;
        private protected PortableDevice _parentPortableDevice;
        private EnumerablePortableDeviceObject _parent;
        private PropertyCollection _properties;
        #endregion

        #region Properties
        #region Abstract
        protected abstract PortableDeviceFileType FileTypeOverride { get; }

        protected abstract Guid TypeOverride { get; }
        #endregion

#if WAPICP3
        public string Path { get; }
#endif

        public bool IsRoot => IsDisposed ? throw GetExceptionForDispose(false) : _isRoot;

        public PortableDeviceFileType FileType => IsDisposed ? throw GetExceptionForDispose(false) : FileTypeOverride;

        public Guid Type { get { this.ThrowIfOperationIsNotAllowed(); return TypeOverride; } }

        public string Id { get { this.ThrowIfOperationIsNotAllowed(); return _id; } }

        public IPortableDevice ParentPortableDevice => IsDisposed ? throw GetExceptionForDispose(false) : _parentPortableDevice;

        public
#if WAPICP3
           IEnumerablePortableDeviceObject
#else
IPortableDeviceObject
#endif
            Parent => IsDisposed ? throw GetExceptionForDispose(false) : _parent;

#if CS7
        private string _name;

        public string Name { get { this.ThrowIfOperationIsNotAllowed(); return _name; } }
#else
#nullable enable
        private string? _name;

        public string? Name { get { ThrowIfOperationIsNotAllowed(); return _name; } }
#nullable disable
#endif

        /// <summary>
        /// Gets all of the properties that are supported by the current <see cref="PortableDevice"/>.
        /// </summary>
        public Microsoft.WindowsAPICodePack.PropertySystem.PropertyCollection Properties
        {
            get
            {
                this.ThrowIfOperationIsNotAllowed();

#if CS7
                return _properties ?? (_properties = new PropertyCollection(new PortableDeviceProperties(_id, _parentPortableDevice)));
#else
                return _properties ??= new PropertyCollection(new PortableDeviceProperties(_id, _parentPortableDevice));
#endif
            }
        }
        #endregion

        private protected PortableDeviceObject(in string id, in bool isRoot, in PortableDevice parentPortableDevice, in PortableDeviceProperties properties) : this(id, isRoot, null, parentPortableDevice, properties)
        {
            // Left empty.
        }

        private protected PortableDeviceObject(in string id, in bool isRoot, in EnumerablePortableDeviceObject parent, in PortableDevice parentPortableDevice, in PortableDeviceProperties properties)
        {
            Debug.Assert(id is object && parentPortableDevice is object, $"{nameof(id)} and {nameof(ParentPortableDevice)} cannot be null.");

            Debug.Assert(isRoot == (parent == null), $"{nameof(parent)} does not have a valid value for this context.");

            _id = id;

            _isRoot = isRoot;

            _parent = parent;

            _parentPortableDevice = parentPortableDevice;

            Debug.WriteLine($"The {id} object is requesting the Name property.");

            if (Properties.TryGetValue(PortableDevices.PropertySystem.Properties.Legacy.Object.Common.Name, out WindowsAPICodePack.PropertySystem. Property objectProperty) && objectProperty.TryGetValue(out string value))

                _name = value;

#if WAPICP3
            Path = $"{(parent == null ? parentPortableDevice.DeviceFriendlyName : parent.Path)}\\{_name ?? id}";
#endif

            _properties = new PropertyCollection(properties ?? new PortableDeviceProperties(id, parentPortableDevice));
        }

        #region Methods
#if WAPICP3
        public void Delete()
        {
            ThrowIfDisposed(this);

            if (this is IEnumerable enumerable && enumerable.Count != 0)

                throw new InvalidOperationException("The enumerable object is not empty.");

            if (!ParentPortableDevice.DeviceCapabilities.Commands.Contains(Management.Commands.DeleteObjects))

                throw new InvalidOperationException("The portable device does not allow deleting.");

            var propVars = (IPortableDevicePropVariantCollection)new PortableDevicePropVariantCollection();

            var propVar = new PropVariant(Id);

            ThrowWhenFailHResult(propVars.Add(propVar));

            HResult hr = _parentPortableDevice.Content.Delete(DeleteObjectOptionValues.NoRecursion, propVars, null);

            if (hr == HResult.AccessDenied)

                throw new UnauthorizedAccessException($"The item could not be deleted. HResult: {hr}.");

            if (hr == CoreErrorHelper.HResultFromWin32(ErrorCode.DirNotEmpty) || hr == CoreErrorHelper.HResultFromWin32(ErrorCode.InvalidOperation))

                throw new InvalidOperationException("The enumerable object is not empty.");

            if (hr == CoreErrorHelper.HResultFromWin32(ErrorCode.NotFound))
            {
                if (this is IEnumerable)

                    throw new DirectoryNotFoundException();

                throw new FileNotFoundException();
            }

            ThrowWhenFailHResult(hr);

            propVar.Dispose();

            propVar = null;

            Marshal.ReleaseComObject(propVars);

            propVars = null;

            Dispose();
        }
#endif
        #endregion

        #region IDisposable Support
        public bool IsDisposed { get; private set; }

        protected virtual void Dispose(bool disposing)
        {
            if (!IsDisposed)
            {
                if (disposing)
                {
                    _parent = null;

                    _parentPortableDevice = null;

                    _properties.Dispose();

                    _properties = null;

                    _id = "";

                    _name = null;

                    IsDisposed = true;
                }
            }
        }

        public void Dispose() => Dispose(true);
        #endregion
    }
}
