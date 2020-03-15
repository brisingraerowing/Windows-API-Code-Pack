using Microsoft.WindowsAPICodePack.PortableDevices.PropertySystem;
using Microsoft.WindowsAPICodePack.PropertySystem;
using Microsoft.WindowsAPICodePack.Win32Native.PortableDevices;
using Microsoft.WindowsAPICodePack.Win32Native.Shell.PropertySystem;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using static Microsoft.WindowsAPICodePack.Win32Native.PortableDevices.PortableDeviceHelper;

namespace Microsoft.WindowsAPICodePack.PortableDevices
{

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

        IPortableDeviceObjectStorageCapacity StorageCapacity { get; }

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

    public class PortableDeviceObject : IPortableDeviceObject

    {
        private string _id;
        private PortableDevice _parentPortableDevice;
        private PortableDeviceObject _parent;

        // todo: replace by the same method of the WinCopies.Util package.

        private void ThrowIfDisposed()

        {

            if (IsDisposed)

                throw new InvalidOperationException("The current object is disposed.");

        }

        private void ThrowIfOperationIsNotAllowed()

        {

            if (ParentPortableDevice.IsDisposed)

                throw new ObjectDisposedException("The parent IPortableDevice is disposed.");

            if (!_parentPortableDevice.IsOpen)

                throw new PortableDeviceException("The IPortableDevice is not open.");

        }

        private IList<IPortableDeviceObject> _items;

        private IList<IPortableDeviceObject> _Items
        {
            get
            {

                ThrowIfOperationIsNotAllowed();

                return _items ?? (_items = GetItems<IPortableDeviceObject>(_parentPortableDevice.Content, _id, (in string id) => new PortableDeviceObject(id, this, _parentPortableDevice)));
            }
        }

        public string Id { get { ThrowIfOperationIsNotAllowed(); return _id; } }

        public IPortableDevice ParentPortableDevice { get { ThrowIfDisposed(); return _parentPortableDevice; } }

        public IPortableDeviceObject Parent { get { ThrowIfDisposed(); return _parent; } }

        public bool IsDisposed { get; private set; }

#if NETFRAMEWORK
        
        private string _name;

        public string Name { get { ThrowIfDisposed(); return _name; } }

#else

#nullable enable
        private string? _name;

        public string? Name { get { ThrowIfDisposed(); return _name; } }
#nullable disable

#endif

        private IPortableDeviceObjectStorageCapacity _storageCapacity;

        public IPortableDeviceObjectStorageCapacity StorageCapacity { get { ThrowIfDisposed(); return _storageCapacity; } } 

        private PropertyCollection _properties;

        /// <summary>
        /// Gets all of the properties that are supported by the current <see cref="PortableDevice"/>.
        /// </summary>
        public PropertyCollection Properties
        {
            get
            {
                ThrowIfDisposed();

                return _properties ?? (_properties = new PropertyCollection(new PortableDeviceProperties(_id, _parentPortableDevice)));
            }
        }

        internal PortableDeviceObject(string id, PortableDevice parentPortableDevice) : this(id, null, parentPortableDevice, true)

        {

        }

#if DEBUG

        internal PortableDeviceObject(string id, PortableDeviceObject parent, PortableDevice parentPortableDevice) : this(id, parent, parentPortableDevice, false) { }

#endif

        internal PortableDeviceObject(string id, PortableDeviceObject parent, PortableDevice parentPortableDevice
#if DEBUG
            , bool allowNullParentPortableDeviceObject
#endif
            )

        {

            Debug.Assert(id is object && parentPortableDevice is object);

#if DEBUG

            if (!allowNullParentPortableDeviceObject)

                Debug.Assert(parent is object);

#endif

            _id = id;

            _parent = parent;

            _parentPortableDevice = parentPortableDevice;

            Debug.WriteLine($"The {id} object is requesting the Name property.");

            if (Properties.TryGetValue(PortableDevices.PropertySystem.Properties.Legacy.Object.Common.Name, out Property objectProperty) && objectProperty.TryGetValue(out string value))

                _name = value;

            if (Properties.TryGetValue(PortableDevices.PropertySystem.Properties.Storage.Capacity, out Property _objectProperty) && _objectProperty.TryGetValue(out ulong _value))

                _storageCapacity = new PortableDeviceObjectStorageCapacity(this, _value);

        }

        public IEnumerator<IPortableDeviceObject> GetEnumerator() => _Items.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

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

                    _storageCapacity = null;

                    if (_items is object)

                    {

                        _items.Clear();

                        _items = null;

                    }
                }

                IsDisposed = true;
            }
        }

        public void Dispose() => Dispose(true);

        #endregion

    }
}
