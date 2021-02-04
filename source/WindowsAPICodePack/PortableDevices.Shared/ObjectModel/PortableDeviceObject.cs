//Copyright (c) Pierre Sprimont.  All rights reserved.

using System;
using System.Diagnostics;

#if WAPICP3
using Microsoft.WindowsAPICodePack.COMNative.PortableDevices.PropertySystem;
using Microsoft.WindowsAPICodePack.PortableDevices.CommandSystem.Object;
using Microsoft.WindowsAPICodePack.PortableDevices.PropertySystem;
using Microsoft.WindowsAPICodePack.Win32Native;
using Microsoft.WindowsAPICodePack.Win32Native.PropertySystem;

using System.IO;
using System.Runtime.InteropServices;

using static Microsoft.WindowsAPICodePack.COMNative.PortableDevices.PortableDeviceHelper;

using static WinCopies.ThrowHelper;
#else
using Microsoft.WindowsAPICodePack.PortableDevices.PropertySystem;

using static WinCopies.Util.Util;
#endif

using PropertyCollection = Microsoft.WindowsAPICodePack.PortableDevices.PropertySystem.PropertyCollection;

namespace Microsoft.WindowsAPICodePack.PortableDevices
{
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
