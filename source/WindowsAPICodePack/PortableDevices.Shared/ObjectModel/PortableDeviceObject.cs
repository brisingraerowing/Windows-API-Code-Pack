//Copyright (c) Pierre Sprimont.  All rights reserved.

using Microsoft.WindowsAPICodePack.PortableDevices.PropertySystem;
using Microsoft.WindowsAPICodePack.PropertySystem;
using Microsoft.WindowsAPICodePack.Win32Native;
using Microsoft.WindowsAPICodePack.COMNative.PortableDevices;
using Microsoft.WindowsAPICodePack.COMNative.Shell.PropertySystem;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using static Microsoft.WindowsAPICodePack.COMNative.PortableDevices.PortableDeviceHelper;
using PropertyCollection = Microsoft.WindowsAPICodePack.PortableDevices.PropertySystem.PropertyCollection;

namespace Microsoft.WindowsAPICodePack.PortableDevices
{

    public enum PortableDeviceFileType : short

    {

        None,

        Folder,

        File,

        FunctionalObject

    }

    /// <summary>
    /// Represents a content object that is stored directly on a <see cref="IPortableDevice"/> or on a parent <see cref="IPortableDeviceObject"/>.
    /// </summary>
    public interface IPortableDeviceObject : WinCopies.Util.DotNetFix.IDisposable

    {

        bool IsRoot { get; }

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

    public interface IEnumerablePortableDeviceObject : IPortableDeviceObject, IEnumerable<IPortableDeviceObject>, System.Collections.Generic.IReadOnlyCollection<IPortableDeviceObject>, System.Collections.Generic.IReadOnlyList<IPortableDeviceObject>

    {



    }

    public interface IPortableDeviceFolder : IEnumerablePortableDeviceObject 

    {

        IPortableDeviceObjectStorageCapacity StorageCapacity { get; }

    }

    public interface IPortableDeviceFile : IPortableDeviceObject

    {

        ulong Size { get; }

    }

    // todo: implement other common properties

    public abstract class PortableDeviceObject : IPortableDeviceObject

    {
        private bool _isRoot;

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

#if NETFRAMEWORK

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

#if NETFRAMEWORK

                return _properties ?? (_properties = new PropertyCollection(new PortableDeviceProperties(_id, _parentPortableDevice)));

#else

                return _properties ??= new PropertyCollection(new PortableDeviceProperties(_id, _parentPortableDevice));

#endif
            }
        }

        private protected PortableDeviceObject(in string id, in bool isRoot, in PortableDevice parentPortableDevice, in PortableDeviceProperties properties) : this(id, isRoot, null, parentPortableDevice, properties)

        {

        }

        private protected PortableDeviceObject(in string id, in bool isRoot, in PortableDeviceObject parent, in PortableDevice parentPortableDevice, in PortableDeviceProperties properties)

        {

            Debug.Assert(id is object && parentPortableDevice is object, $"{nameof(id)} and {nameof(ParentPortableDevice)} cannot be null.");

            Debug.Assert(isRoot ^ (parent is object), $"{nameof(parent)} does not have a valid value for this context.");

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

    internal abstract class EnumerablePortableDeviceObject : PortableDeviceObject, IEnumerablePortableDeviceObject

    {



        public IPortableDeviceObject this[int index] => _Items[index];

        public int Count => _Items.Count;

        private IList<IPortableDeviceObject> _items;

        private IList<IPortableDeviceObject> _Items
        {
            get
            {

                ThrowIfOperationIsNotAllowed();

#if NETFRAMEWORK

                return _items ?? (_items = GetItems<IPortableDeviceObject>(_parentPortableDevice.Content, _id, (in string id) => PortableDevice.GetPortableDeviceObject(id, false, this, _parentPortableDevice)));

#else

                return _items ??= GetItems<IPortableDeviceObject>(_parentPortableDevice.Content, _id, (in string id) => PortableDevice.GetPortableDeviceObject(id, false, this, _parentPortableDevice));

#endif
            }
        }

        public EnumerablePortableDeviceObject(in string id, in bool isRoot, in PortableDevice parentPortableDevice, in PortableDeviceProperties properties) : this(id, isRoot, null, parentPortableDevice, properties)

        { }

        public EnumerablePortableDeviceObject(in string id, in bool isRoot, in PortableDeviceObject parent, in PortableDevice parentPortableDevice, in PortableDeviceProperties properties

            ) : base(id, isRoot, parent, parentPortableDevice, properties)

        { }

        public IEnumerator<IPortableDeviceObject> GetEnumerator() => _Items.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            if (disposing && _items is object)

                {

                    _items.Clear();

                    _items = null;

                }
        }
    }

    internal sealed class PortableDeviceFolder : EnumerablePortableDeviceObject, IPortableDeviceFolder

    {

        protected override PortableDeviceFileType FileTypeOverride => PortableDeviceFileType.Folder;

        protected override Guid TypeOverride => new Guid(Guids.PropertySystem.ContentType.Folder);

        private IPortableDeviceObjectStorageCapacity _storageCapacity;

        public IPortableDeviceObjectStorageCapacity StorageCapacity
        {
            get
            {
                ThrowIfOperationIsNotAllowed();

                if (_storageCapacity is null)

                    if (Properties.TryGetValue(PortableDevices.PropertySystem.Properties.Storage.Capacity, out Property _objectProperty) && _objectProperty.TryGetValue(out ulong _value))

                        _storageCapacity = new PortableDeviceObjectStorageCapacity(this, _value);

                    else

                        throw new PropertySystemException("Cannot read property.");

                return _storageCapacity;
            }
        }

        public PortableDeviceFolder(in string id, in bool isRoot, in PortableDevice parentPortableDevice, in PortableDeviceProperties properties) : this(id, isRoot, null, parentPortableDevice, properties)

        { }

        public PortableDeviceFolder(in string id, in bool isRoot, in PortableDeviceObject parent, in PortableDevice parentPortableDevice, in PortableDeviceProperties properties

            ) : base(id, isRoot, parent, parentPortableDevice, properties)

        { }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            if (disposing)

                _storageCapacity = null;
        }
    }

    internal abstract class NotEnumerablePortableDeviceObject : PortableDeviceObject

    {

        private Guid _type;

        protected sealed override Guid TypeOverride
        {
            get
            {
                if (_type == null && Properties.TryGetValue(PropertySystem.Properties.Object.ContentType, out Property property) && property.TryGetValue(out Guid value))

                    _type = value;

                else

                    throw new PropertySystemException("Cannot read the property.");

                return _type;
            }
        }

        public NotEnumerablePortableDeviceObject(in string id, in bool isRoot, in PortableDevice parentPortableDevice, PortableDeviceProperties properties) : this(id, isRoot, null, parentPortableDevice, properties) { }

        public NotEnumerablePortableDeviceObject(in string id, in bool isRoot, in PortableDeviceObject parent, in PortableDevice parentPortableDevice, PortableDeviceProperties properties) : base(id, isRoot, parent, parentPortableDevice, properties) { }

    }

    internal sealed class PortableDeviceFile : NotEnumerablePortableDeviceObject

    {

        protected override PortableDeviceFileType FileTypeOverride => PortableDeviceFileType.File;

        public ulong Size
        {
            get
            {

                ThrowIfOperationIsNotAllowed();

                if (Properties.TryGetValue(PropertySystem.Properties.Object.ContentType, out Property property) && property.TryGetValue(out ulong value))

                    return value;

                else

                    throw new PropertySystemException("Cannot read the property.");

            }
        }

        public PortableDeviceFile(in string id, in bool isRoot, in PortableDevice parentPortableDevice, in PortableDeviceProperties properties) : this(id, isRoot, null, parentPortableDevice, properties)

        { }

        public PortableDeviceFile(in string id, in bool isRoot, in PortableDeviceObject parent, in PortableDevice parentPortableDevice, in PortableDeviceProperties properties

            ) : base(id, isRoot, parent, parentPortableDevice, properties)
        {

            //if (Properties.TryGetValue(PortableDevices.PropertySystem.Properties.Storage.Capacity, out Property _objectProperty) && _objectProperty.TryGetValue(out ulong _value))

            //    _storageCapacity = new PortableDeviceObjectStorageCapacity(this, _value);

        }
    }

    internal sealed class PortableDeviceFunctionalObject : EnumerablePortableDeviceObject

    {

        protected override PortableDeviceFileType FileTypeOverride => PortableDeviceFileType.FunctionalObject;

        protected override Guid TypeOverride => new Guid(Guids.PropertySystem.ContentType.FunctionalObject);

        public PortableDeviceFunctionalObject(in string id, in bool isRoot, in PortableDevice parentPortableDevice, in PortableDeviceProperties properties) : this(id, isRoot, null, parentPortableDevice, properties) { }

        public PortableDeviceFunctionalObject(in string id, in bool isRoot, in PortableDeviceObject parent, in PortableDevice parentPortableDevice, in PortableDeviceProperties properties) : base(id, isRoot, parent, parentPortableDevice, properties) { }

    }

    internal sealed class PortableDeviceCommonObject : NotEnumerablePortableDeviceObject

    {

        protected override PortableDeviceFileType FileTypeOverride => PortableDeviceFileType.None;

        public PortableDeviceCommonObject(in string id, in bool isRoot, in PortableDevice parentPortableDevice, in PortableDeviceProperties properties) : this(id, isRoot, null, parentPortableDevice, properties) { } 

        public PortableDeviceCommonObject(in string id, in bool isRoot, in PortableDeviceObject parent, in PortableDevice parentPortableDevice, in PortableDeviceProperties properties) : base(id, isRoot, parent, parentPortableDevice, properties) { }

    }
}
