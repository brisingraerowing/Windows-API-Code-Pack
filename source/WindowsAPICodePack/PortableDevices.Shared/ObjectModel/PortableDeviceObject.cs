//Copyright (c) Pierre Sprimont.  All rights reserved.

using Microsoft.WindowsAPICodePack.PortableDevices.PropertySystem;
using Microsoft.WindowsAPICodePack.PropertySystem;

using System;
using System.Collections.Generic;
using System.Diagnostics;

using PropertyCollection = Microsoft.WindowsAPICodePack.PortableDevices.PropertySystem.PropertyCollection;

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
    {
        void TransferTo(System.IO.FileStream stream, int bufferSize, bool forceBufferSize, Guid contentType, Guid objectFormat, PortableDeviceTransferCallback d);
    }

    public interface IEnumerablePortableDeviceObject : IPortableDeviceObject, IEnumerable<IPortableDeviceObject>, System.Collections.Generic.IReadOnlyCollection<IPortableDeviceObject>, System.Collections.Generic.IReadOnlyList<IPortableDeviceObject>, IEnumerable
    {
        // Left empty.
    }

    public interface IPortableDeviceFolder : IEnumerablePortableDeviceObject
    {
        IPortableDeviceObjectStorageCapacity StorageCapacity { get; }
    }

    public interface IPortableDeviceFile : IPortableDeviceObject
    {
        ulong Size { get; }

        void TransferFrom(System.IO.Stream stream, int bufferSize, bool forceBufferSize, PortableDeviceTransferCallback d);
    }

    // todo: implement other common properties

    public abstract class PortableDeviceObject : IPortableDeviceObject
    {
        private readonly bool _isRoot;

        public bool IsRoot { get { ThrowIfDisposed(); return _isRoot; } }

        protected abstract PortableDeviceFileType FileTypeOverride { get; }

        public PortableDeviceFileType FileType { get { ThrowIfDisposed(); return FileTypeOverride; } }

        protected abstract Guid TypeOverride { get; }

        public Guid Type { get { ThrowIfOperationIsNotAllowed(); return TypeOverride; } }

        private protected string _id;
        private protected PortableDevice _parentPortableDevice;
        private PortableDeviceObject _parent;

        // todo: replace by the same method of the WinCopies.Util package.

        private protected void ThrowIfDisposed()
        {
            if (IsDisposed)

                throw new InvalidOperationException("The current object is disposed.");
        }

        // todo: to static helper method?

        internal void ThrowIfOperationIsNotAllowed()
        {
            if (ParentPortableDevice.IsDisposed)

                throw new ObjectDisposedException("The parent IPortableDevice is disposed.");

            if (!_parentPortableDevice.IsOpen)

                throw new PortableDeviceException("The IPortableDevice is not open.");
        }

        public string Id { get { ThrowIfOperationIsNotAllowed(); return _id; } }

        public IPortableDevice ParentPortableDevice { get { ThrowIfDisposed(); return _parentPortableDevice; } }

        public IPortableDeviceObject Parent { get { ThrowIfDisposed(); return _parent; } }

        public bool IsDisposed { get; private set; }

#if CS7
        private string _name;

        public string Name { get { ThrowIfOperationIsNotAllowed(); return _name; } }
#else
#nullable enable
        private string? _name;

        public string? Name { get { ThrowIfOperationIsNotAllowed(); return _name; } }
#nullable disable
#endif

        private PropertyCollection _properties;

        /// <summary>
        /// Gets all of the properties that are supported by the current <see cref="PortableDevice"/>.
        /// </summary>
        public Microsoft.WindowsAPICodePack.PropertySystem.PropertyCollection Properties
        {
            get
            {
                ThrowIfOperationIsNotAllowed();

#if CS7
                return _properties ?? (_properties = new PropertyCollection(new PortableDeviceProperties(_id, _parentPortableDevice)));
#else
                return _properties ??= new PropertyCollection(new PortableDeviceProperties(_id, _parentPortableDevice));
#endif
            }
        }

        private protected PortableDeviceObject(in string id, in bool isRoot, in PortableDevice parentPortableDevice, in PortableDeviceProperties properties) : this(id, isRoot, null, parentPortableDevice, properties)
        {
            // Left empty.
        }

        private protected PortableDeviceObject(in string id, in bool isRoot, in PortableDeviceObject parent, in PortableDevice parentPortableDevice, in PortableDeviceProperties properties)
        {
            Debug.Assert(id is object && parentPortableDevice is object, $"{nameof(id)} and {nameof(ParentPortableDevice)} cannot be null.");

            Debug.Assert(isRoot == (parent == null), $"{nameof(parent)} does not have a valid value for this context.");

            _id = id;

            _isRoot = isRoot;

            _parent = parent;

            _parentPortableDevice = parentPortableDevice;

            Debug.WriteLine($"The {id} object is requesting the Name property.");

            if (Properties.TryGetValue(PortableDevices.PropertySystem.Properties.Legacy.Object.Common.Name, out Property objectProperty) && objectProperty.TryGetValue(out string value))

                _name = value;

            if (properties is object)

                _properties = new PropertyCollection(properties);
        }

        #region IDisposable Support

        protected virtual void Dispose(bool disposing)
        {
            if (!IsDisposed)
            {
                if (disposing)
                {
                    _parent = null;

                    _parentPortableDevice = null;

                    _id = "";

                    _name = null;
                }

                IsDisposed = true;
            }
        }

        public void Dispose() => Dispose(true);

        #endregion
    }
}
