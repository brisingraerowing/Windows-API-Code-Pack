//Copyright (c) Microsoft Corporation.  All rights reserved.  Distributed under the Microsoft Public License (MS-PL)  Distributed under Microsoft Public License (MS-PL)

using Microsoft.WindowsAPICodePack.COMNative.Shell;
using Microsoft.WindowsAPICodePack.COMNative.Shell.PropertySystem;
using Microsoft.WindowsAPICodePack.Shell.PropertySystem;
using Microsoft.WindowsAPICodePack.Win32Native;
using Microsoft.WindowsAPICodePack.Win32Native.Shell;
using Microsoft.WindowsAPICodePack.Win32Native.Shell.Resources;

using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography;

namespace Microsoft.WindowsAPICodePack.Shell
{
    /// <summary>
    /// The base class for all Shell objects in Shell Namespace.
    /// </summary>
    public abstract class ShellObject : IDisposable, IEquatable<ShellObject>
    {
        #region Public Static Methods
#if !WAPICP3
        /// <summary>
        /// Creates a ShellObject subclass given a parsing name.
        /// For file system items, this method will only accept absolute paths.
        /// </summary>
        /// <param name="parsingName">The parsing name of the object.</param>
        /// <returns>A newly constructed ShellObject object.</returns>
        public static ShellObject FromParsingName(string parsingName) => ShellObjectFactory.Create(parsingName);
#endif

        /// <summary>
        /// Indicates whether this feature is supported on the current platform.
        /// </summary>
        public static bool IsPlatformSupported =>
                // We need Windows Vista onwards ...
                CoreHelpers.RunningOnVista;
        #endregion

        #region Fields
        #region Private Fields
        // Parsing name for this Object e.g. c:\Windows\file.txt,
        // or ::{Some Guid}
        private string _internalParsingName;

        // A friendly name for this object that' suitable for display
        private string
#if CS8
            ?
#endif
            _internalName;

        // PID List (PIDL) for this object
        private IntPtr _internalPIDL = IntPtr.Zero;

        private ShellProperties _properties;
        private ShellObject
#if CS8
            ?
#endif
            _parentShellObject;
        private bool _isDisposed;
        private static readonly SHA256 _hashProvider = SHA256.Create();
        private int? _hashValue;
        private ShellThumbnail _thumbnail;
        private IPropertyStore _nativePropertyStore;
        #endregion

        #region Internal Fields
        // Internal member to keep track of the native IShellItem2
        internal IShellItem2 _nativeShellItem;
        #endregion
        #endregion

        #region Properties
        #region Internal Properties
        /// <summary>
        /// Return the native <see cref="ShellFolder"/> object as newer <see cref="IShellItem2"/>.
        /// </summary>
        /// <exception cref="ExternalException">If the native object cannot be created.
        /// The <see cref="ExternalException.ErrorCode"/> property will contain the external error code.</exception>
        internal virtual IShellItem2 NativeShellItem2
        {
            get
            {
                if (_nativeShellItem == null && ParsingName != null)
                {
                    var guid = new Guid(NativeAPI.Guids.Shell.IShellItem2);
                    HResult retCode =
#if !WAPICP3
                        (HResult)
#endif
                        COMNative.Shell.Shell.SHCreateItemFromParsingName(ParsingName, IntPtr.Zero, ref guid, out _nativeShellItem);

                    if (_nativeShellItem == null || !CoreErrorHelper.Succeeded(retCode))

                        throw new ShellException(LocalizedMessages.ShellObjectCreationFailed, CoreErrorHelper.GetExceptionForHR(retCode));
                }

                return _nativeShellItem;
            }
        }

        /// <summary>
        /// Return the native ShellFolder object. This property should not be used directly except on Win32 API reimplementation.
        /// </summary>
        internal virtual IShellItem NativeShellItem => NativeShellItem2;

        /// <summary>
        /// Gets access to the native IPropertyStore (if one is already
        /// created for this item and still valid. This is usually done by the
        /// ShellPropertyWriter class. The reference will be set to null
        /// when the writer has been closed/commited).
        /// </summary>
        internal IPropertyStore NativePropertyStore { get => _nativePropertyStore; set => _nativePropertyStore = value; }
        #endregion

        #region Public Properties
        /// <summary>
        /// Gets an object that allows the manipulation of ShellProperties for this shell item.
        /// </summary>
        public ShellProperties Properties => _properties
#if CS8
            ??=
#else
            ?? (_properties =
#endif
            new ShellProperties(this)
#if !CS8
            )
#endif
            ;

        /// <summary>
        /// Gets the parsing name for this ShellItem.
        /// </summary>
        virtual public string ParsingName
        {
            get => (_internalParsingName == null && _nativeShellItem != null ? _internalParsingName = ShellHelper.GetParsingName(_nativeShellItem) : _internalParsingName) ?? string.Empty;

            protected set => _internalParsingName = value;
        }

        /// <summary>
        /// Gets the normal display for this ShellItem.
        /// </summary>
        public virtual string
#if CS8
            ?
#endif
            Name
        {
            get
            {
                if (_internalName == null && NativeShellItem != null && NativeShellItem.GetDisplayName(ShellItemDesignNameOptions.Normal, out IntPtr pszString) == HResult.Ok && (_internalName = Marshal.PtrToStringAuto(pszString)) != null)

                    // Free the string
                    Marshal.FreeCoTaskMem(pszString);

                return _internalName;
            }

            protected set => _internalName = value;
        }

        /// <summary>
        /// Gets the PID List (PIDL) for this ShellItem. This property should not be used directly except on Win32 API reimplementation.
        /// </summary>
        internal virtual IntPtr PIDL
        {
            get =>
                // Get teh PIDL for the ShellItem
                _internalPIDL == IntPtr.Zero && NativeShellItem != null ? _internalPIDL = ShellHelper.PidlFromShellItem(NativeShellItem) : _internalPIDL;

            set => _internalPIDL = value;
        }

        /// <summary>
        /// Gets a value that determines if this ShellObject is a link or shortcut.
        /// </summary>
        public bool IsLink => GetValue(ShellFileGetAttributesOptions.Link);

        /// <summary>
        /// Gets a value that determines if this ShellObject is a file system object.
        /// </summary>
        public bool IsFileSystemObject => GetValue(ShellFileGetAttributesOptions.FileSystem);

        /// <summary>
        /// Gets the thumbnail of the ShellObject.
        /// </summary>
        public ShellThumbnail Thumbnail => _thumbnail
#if CS8
            ??=
#else
            ?? (_thumbnail =
#endif
            new ShellThumbnail(this)
#if !CS8
            )
#endif
            ;

        /// <summary>
        /// Gets the parent ShellObject.
        /// Returns null if the object has no parent, i.e. if this object is the Desktop folder.
        /// </summary>
        public ShellObject
#if CS8
            ?
#endif
            Parent
        {
            get
            {
                if (_parentShellObject == null && NativeShellItem2 != null)
                {
                    HResult hr = NativeShellItem2.GetParent(out IShellItem parentShellItem);

                    switch (hr)
                    {
                        case HResult.Ok when parentShellItem != null:

                            _parentShellObject = ShellObjectFactory.Create(parentShellItem);

                            break;

                        case HResult.NoObject:

                            // Should return null if the parent is desktop
                            return null;

                        default:

                            throw new ShellException(hr);
                    }
                }

                return _parentShellObject;
            }
        }
        #endregion
        #endregion

        #region Constructors
        internal ShellObject() { }

        protected ShellObject(in IShellItem2 shellItem) => _nativeShellItem = shellItem;
        #endregion

        #region Methods
        private bool GetValue(in ShellFileGetAttributesOptions value)
        {
            try
            {
                NativeShellItem.GetAttributes(value, out ShellFileGetAttributesOptions sfgao);

                return (sfgao & value) != 0;
            }

            catch (Exception ex) when (ex is FileNotFoundException || ex is NullReferenceException /*NativeShellItem is null*/)
            {
                return false;
            }
        }

        #region Public Methods
        /// <summary>
        /// Overrides object.ToString()
        /// </summary>
        /// <returns>A string representation of the object.</returns>
        public override string ToString() => Name;

        /// <summary>
        /// Returns the display name of the ShellFolder object. DisplayNameType represents one of the 
        /// values that indicates how the name should look. 
        /// See <see cref="DisplayNameType"/>for a list of possible values.
        /// </summary>
        /// <param name="displayNameType">A disaply name type.</param>
        /// <returns>A string.</returns>
        public virtual string
#if CS8
                ?
#endif
                GetDisplayName(DisplayNameType displayNameType)
        {
            string
#if CS8
                ?
#endif
                returnValue = null;

            HResult hr = NativeShellItem2 == null ? HResult.Ok : hr = NativeShellItem2.GetDisplayName((ShellItemDesignNameOptions)displayNameType, out returnValue);

            return hr == HResult.Ok ? returnValue : throw new ShellException(LocalizedMessages.ShellObjectCannotGetDisplayName, hr);
        }

        /// <summary>
        /// Updates the native shell item that maps to this shell object. This is necessary when the shell item 
        /// changes after the shell object has been created. Without this method call, the retrieval of properties will
        /// return stale data. 
        /// </summary>
        /// <param name="bindContext">Bind context object</param>
        public void Update(IBindCtx bindContext)
        {
            if (NativeShellItem2 != null)
            {
                HResult hr = NativeShellItem2.Update(bindContext);

                if (CoreErrorHelper.Failed(hr))

                    throw new ShellException(hr);
            }
        }
        #endregion
        #endregion

        #region IDisposable Members
        /// <summary>
        /// Release the native and managed objects
        /// </summary>
        /// <param name="disposing">Indicates that this is being called from Dispose(), rather than the finalizer.</param>
        protected virtual void Dispose(bool disposing)
        {
            _properties?.Dispose();

            if (disposing)
            {
                _internalName = null;
                _internalParsingName = null;
                _properties = null;
                _thumbnail = null;
                _parentShellObject = null;
            }

            if (_internalPIDL != IntPtr.Zero)
            {
                Win32Native.Shell.Shell.ILFree(_internalPIDL);
                _internalPIDL = IntPtr.Zero;
            }

            CoreHelpers.DisposeCOMObject(ref _nativeShellItem);
            CoreHelpers.DisposeCOMObject(ref _nativePropertyStore);
        }

        /// <summary>
        /// Release the native objects.
        /// </summary>
        public void Dispose()
        {
            if (_isDisposed)

                return;

            Dispose(true);
            GC.SuppressFinalize(this);
            _isDisposed = true;
        }

        /// <summary>
        /// Implement the finalizer.
        /// </summary>
        ~ShellObject() => Dispose(false);
        #endregion

        #region equality and hashing
        /// <summary>
        /// Returns the hash code of the object.
        /// </summary>
        public override int GetHashCode()
        {
            if (!_hashValue.HasValue)
            {
                uint size = Win32Native.Shell.Shell.ILGetSize(PIDL);

                if (size != 0)
                {
                    byte[] pidlData = new byte[size];
                    Marshal.Copy(PIDL, pidlData, 0, (int)size);
                    _hashValue = BitConverter.ToInt32(_hashProvider.ComputeHash(pidlData), 0);
                }

                else

                    _hashValue = 0;
            }

            return _hashValue.Value;
        }

        /// <summary>
        /// Determines if two <see cref="ShellObject"/>s are identical.
        /// </summary>
        /// <param name="other">The <see cref="ShellObject"/> to comare this one to.</param>
        /// <returns><see langword="true"/> if the <see cref="ShellObject"/>s are equal, <see langword="false"/> otherwise.</returns>
        public bool Equals(ShellObject
#if CS8
            ?
#endif
            other)
        {
            if (other != null)
            {
                IShellItem ifirst = NativeShellItem;
                IShellItem isecond = other.NativeShellItem;

                if (ifirst != null && isecond != null)

                    return (ifirst.Compare(
                         isecond, SICHINTF.AllFields, out int result) == HResult.Ok) && (result == 0);
            }

            return false;
        }

        /// <summary>
        /// Returns whether this object is equal to another.
        /// </summary>
        /// <param name="obj">The object to compare against.</param>
        /// <returns>Equality result.</returns>
        public override bool Equals(object
#if CS8
            ?
#endif
            obj) => Equals(obj as ShellObject);

        /// <summary>
        /// Implements the == (equality) operator.
        /// </summary>
        /// <param name="leftShellObject">First object to compare.</param>
        /// <param name="rightShellObject">Second object to compare.</param>
        /// <returns><see langword="true"/> if leftShellObject equals rightShellObject; <see langword="false"/> otherwise.</returns>
        public static bool operator ==(ShellObject
#if CS8
            ?
#endif
            leftShellObject, ShellObject
#if CS8
            ?
#endif
            rightShellObject) => Equals(leftShellObject, null) ? Equals(rightShellObject, null) : leftShellObject.Equals(rightShellObject);

        /// <summary>
        /// Implements the != (inequality) operator.
        /// </summary>
        /// <param name="leftShellObject">First object to compare.</param>
        /// <param name="rightShellObject">Second object to compare.</param>
        /// <returns><see langword="true"/> if leftShellObject does not equal leftShellObject; <see langword="false"/> otherwise.</returns>        
        public static bool operator !=(ShellObject
#if CS8
            ?
#endif
            leftShellObject, ShellObject
#if CS8
            ?
#endif
            rightShellObject) => !(leftShellObject == rightShellObject);
        #endregion
    }
}
