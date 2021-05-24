//Copyright (c) Pierre Sprimont.  All rights reserved.

using Microsoft.WindowsAPICodePack.COMNative.PortableDevices;
using Microsoft.WindowsAPICodePack.COMNative.PortableDevices.PropertySystem;
using Microsoft.WindowsAPICodePack.COMNative.Shell.PropertySystem;
using Microsoft.WindowsAPICodePack.PortableDevices.CommandSystem.Object;
using Microsoft.WindowsAPICodePack.PortableDevices.PropertySystem;
using Microsoft.WindowsAPICodePack.PropertySystem;
using Microsoft.WindowsAPICodePack.Win32Native;
using Microsoft.WindowsAPICodePack.Win32Native.PropertySystem;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

using static Microsoft.WindowsAPICodePack.COMNative.PortableDevices.PortableDeviceHelper;

using static System.Runtime.InteropServices.Marshal;

using static WinCopies.
#if WAPICP3
    ThrowHelper;

using WinCopies;
#else
Util.Util;

using WinCopies.Util;
#endif

using PropertyCollection = Microsoft.WindowsAPICodePack.PortableDevices.PropertySystem.PropertyCollection;

namespace Microsoft.WindowsAPICodePack.PortableDevices
{
    //#if WAPICP3
    //    public delegate bool PortableDeviceTransferStartedCallback(IPortableDeviceObject item);
    //#endif

    [DebuggerDisplay("{FriendlyName}, {DeviceDescription}, {Manufacturer}")]
    public class PortableDevice : IPortableDevice, WinCopies.
#if WAPICP2
        Util.
#endif
        DotNetFix.IDisposable
    {
        #region Fields
        private IPortableDeviceProperties _nativePortableDeviceProperties;
        private IList<IPortableDeviceObject> _items;
        private PortableDeviceManager _portableDeviceManager;
        private COMNative.PortableDevices.IPortableDevice _nativePortableDevice;
        private string _deviceFriendlyName;
        private string _deviceDescription;
        private string _deviceManufacturer;
        private bool _isOpen;
        private readonly string _deviceId;
        private IDeviceCapabilities _deviceCapabilities;
        private IPortableDeviceContent2 _content = null;
        private WindowsAPICodePack.PropertySystem.PropertyCollection _properties;
#if WAPICP3
        private string _eventCookie;
#endif
        #endregion

        #region Properties
#if !WAPICP3
        private IList<IPortableDeviceObject> _Items => IsOpen ? _items
#if CS8
            ??=
#else
?? (_items =
#endif
            GetItems(Content, NativeAPI.Consts.PortableDevices.DeviceObjectId, (in string id) => GetPortableDeviceObject(id, true, null, this))
#if !CS8
            )
#endif
            : throw new PortableDeviceException("The device is not open.");
#endif

        internal IPortableDeviceProperties NativePortableDeviceProperties
        {
            get
            {
                TryGetNativePortableDeviceProperties();

                return _nativePortableDeviceProperties;
            }
        }

        /// <summary>
        /// If the current <see cref="PortableDevice"/> has been created by a <see cref="PortableDevices.PortableDeviceManager"/>, gets that manager; otherwise returns <see langword="null"/>.
        /// </summary>
        public PortableDeviceManager PortableDeviceManager { get { ThrowIfDisposed(); return _portableDeviceManager; } }

        IPortableDeviceManager IPortableDevice.PortableDeviceManager => PortableDeviceManager;

        internal COMNative.PortableDevices.IPortableDevice NativePortableDevice { get { ThrowIfDisposed(); return _nativePortableDevice; } private set { ThrowIfDisposed(); _nativePortableDevice = value; } }

        /// <summary>
        /// Gets the capabilities that are supported by the current <see cref="PortableDevice"/>. These capabilities do not include the supported properties. For supported properties, see the <see cref="Properties"/> property.
        /// </summary>
        public IDeviceCapabilities DeviceCapabilities
        {
            get
            {
                ThrowOnInvalidOperation();

#if CS8
                return _deviceCapabilities ??= new DeviceCapabilities(this);
#else
                return _deviceCapabilities ?? (_deviceCapabilities = new DeviceCapabilities(this));
#endif
            }
        }

        internal IPortableDeviceContent2 Content
        {
            get
            {
                SetContent();

                return _content;
            }
        }

        protected void SetContent()
        {
            ThrowOnInvalidOperation();

            if (_content is null)
            {
                ThrowWhenFailHResult(NativePortableDevice.Content(out IPortableDeviceContent content));

                _content = (IPortableDeviceContent2)content;
            }
        }

        /// <summary>
        /// Gets all of the properties that are supported by the current <see cref="PortableDevice"/>.
        /// </summary>
        public WindowsAPICodePack.PropertySystem.PropertyCollection Properties
        {
            get
            {
                TryGetNativePortableDeviceProperties();
#if CS8
                return _properties ??= new PropertyCollection(new PortableDeviceProperties(NativeAPI.Consts.PortableDevices.DeviceObjectId, this));
#else
                return _properties ?? (_properties = new PropertyCollection(new PortableDeviceProperties(NativeAPI.Consts.PortableDevices.DeviceObjectId, this)));
#endif
            }
        }

        /// <summary>
        /// Gets the device id of the current <see cref="PortableDevice"/>.
        /// </summary>
        public string DeviceId
        {
            get
            {
                ThrowIfDisposed();

                return _deviceId;
            }
        }

        /// <summary>
        /// If the current <see cref="PortableDevice"/> has been created by a <see cref="PortableDevices.PortableDeviceManager"/>, gets the device friendly name of the current <see cref="PortableDevice"/>, otherwise gets <see langword="null"/>.
        /// </summary>
        public string DeviceFriendlyName { get { ThrowIfDisposed(); return _deviceFriendlyName; } internal set { ThrowIfDisposed(); _deviceFriendlyName = value; } }

        /// <summary>
        /// If the current <see cref="PortableDevice"/> has been created by a <see cref="PortableDevices.PortableDeviceManager"/>, gets the device description of the current <see cref="PortableDevice"/>, otherwise gets <see langword="null"/>.
        /// </summary>
        public string DeviceDescription { get { ThrowIfDisposed(); return _deviceDescription; } internal set { ThrowIfDisposed(); _deviceDescription = value; } }

        /// <summary>
        /// If the current <see cref="PortableDevice"/> has been created by a <see cref="PortableDevices.PortableDeviceManager"/>, gets the device manufacturer of the current <see cref="PortableDevice"/>, otherwise gets <see langword="null"/>.
        /// </summary>
        public string DeviceManufacturer { get { ThrowIfDisposed(); return _deviceManufacturer; } internal set { ThrowIfDisposed(); _deviceManufacturer = value; } }

        public bool IsOpen { get { ThrowIfDisposed(); return _isOpen; } }

#if !WAPICP3
        public int Count => _Items.Count;

        public IPortableDeviceObject this[int index] => _Items[index];
#endif

        public PortableDeviceOpeningOptions PortableDeviceOpeningOptions { get; private set; }
        #endregion

        internal PortableDevice(in PortableDeviceManager portableDeviceManager, in string deviceId)
        {
            _portableDeviceManager = portableDeviceManager;

            _deviceId = deviceId;

            uint length = 0;

            ThrowWhenFailHResult(PortableDeviceManager._Manager.GetDeviceFriendlyName(DeviceId, null, ref length));

            var stringBuilder = new StringBuilder((int)length);

            ThrowWhenFailHResult(PortableDeviceManager._Manager.GetDeviceFriendlyName(DeviceId, stringBuilder, ref length));

            DeviceFriendlyName = stringBuilder.ToString();

            length = 0;

            ThrowWhenFailHResult(PortableDeviceManager._Manager.GetDeviceDescription(DeviceId, null, ref length));

            stringBuilder = new StringBuilder((int)length);

            ThrowWhenFailHResult(PortableDeviceManager._Manager.GetDeviceDescription(DeviceId, stringBuilder, ref length));

            DeviceDescription = stringBuilder.ToString();

            length = 0;

            ThrowWhenFailHResult(PortableDeviceManager._Manager.GetDeviceManufacturer(DeviceId, null, ref length));

            stringBuilder = new StringBuilder((int)length);

            ThrowWhenFailHResult(PortableDeviceManager._Manager.GetDeviceManufacturer(DeviceId, stringBuilder, ref length));

            DeviceManufacturer = stringBuilder.ToString();



            NativePortableDevice = (COMNative.PortableDevices.IPortableDevice)new COMNative.PortableDevices.PortableDevice();
        }

        #region Methods
#if WAPICP3
        public System.Collections.Generic.IEnumerable<IPortableDeviceObject> GetPortableDeviceItem(in string id)
        {
            var keyCollection = (IPortableDeviceKeyCollection)new PortableDeviceKeyCollection();

            PropertyKey propKey = PropertySystem.Properties.Legacy.Object.Common.ParentId;

            _ = keyCollection.Add(ref propKey);

            _ = NativePortableDeviceProperties.GetValues(id, keyCollection, out IPortableDeviceValues values);

            _ = values.GetStringValue(ref propKey, out string value);

            _ = ReleaseComObject(values);

            values = null;

            if (value == NativeAPI.Consts.PortableDevices.DeviceObjectId)
            {
                _ = ReleaseComObject(keyCollection);

                keyCollection = null;

                return this;
            }

            var stack = new WinCopies.Collections.Generic.Stack<string>();

            stack.Push(value);

            do
            {
                _ = NativePortableDeviceProperties.GetValues(value, keyCollection, out values);

                _ = values.GetStringValue(ref propKey, out value);

                _ = ReleaseComObject(values);

                values = null;

                stack.Push(value);
            } while (value != NativeAPI.Consts.PortableDevices.DeviceObjectId);

            _ = stack.Pop(); // We remove the PortableDevice id.

            string current;

            bool predicate(IPortableDeviceObject _item) => _item.Id == current;

            current = stack.Pop();

            var item = (EnumerablePortableDeviceObject)this.First(predicate);

            while (stack.Count != 0)
            {
                current = stack.Pop();

                item = (EnumerablePortableDeviceObject)item.First(predicate);
            }

            _ = ReleaseComObject(keyCollection);

            keyCollection = null;

            return item;
        }

        public static string GetId(in ReadOnlyPortableDeviceValueCollection values)
        {
            ThrowIfNull(values, nameof(values));

            PropertyKey propKey = PropertySystem.Properties.Legacy.Object.Common.Id;

            return values.GetStringValue(ref propKey);
        }

        public System.Collections.Generic.IEnumerable<IPortableDeviceObject> GetPortableDeviceItem(in ReadOnlyPortableDeviceValueCollection values, out string id)
        {
            ThrowIfNull(values, nameof(values));

            id = GetId(values);

            return GetPortableDeviceItem(id);
        }

        internal void OnUpdate(PortableDeviceUpdatedEventArgs e)
        {
            if (IsOpen && !IsDisposed)
            {
                PropertyKey eventId = EventSystem.Parameter.EventId;

                Guid guid = e.EventArgValues.GetGuidValue(ref eventId);

                if (guid == new Guid(Guids.EventSystem.ObjectAdded))

                    _portableDeviceManager.RaisePortableDeviceObjectAddedEvent(GetId(e.EventArgValues));

                else if (guid == new Guid(Guids.EventSystem.ObjectRemoved))

                    _portableDeviceManager.RaisePortableDeviceObjectRemovedEvent(GetId(e.EventArgValues));

                _portableDeviceManager.RaisePortableDeviceUpdatedEvent(e);
            }
        }
#endif

        internal void TransferTo(FileStream stream, int bufferSize, in bool forceBufferSize, in string id, in Guid contentType, in Guid objectFormat, in PortableDeviceTransferCallback d)
        {
            if (!(stream ?? throw GetArgumentNullException(nameof(stream))).CanWrite)

                throw new ArgumentException("The given stream does not support writting.");

            if (bufferSize <= 0)

                throw new ArgumentOutOfRangeException(nameof(bufferSize));

            if (!DeviceCapabilities.Commands.Contains(Management.Commands.CommitObject))

                throw new InvalidOperationException("The portable device does not allow committing.");

            var properties = (IPortableDeviceValues)new PortableDeviceValues();

            PropertyKey propKey = PropertySystem.Properties.Legacy.Object.Common.ParentId;

            ThrowWhenFailHResult(properties.SetStringValue(ref propKey, id));

            propKey = PropertySystem.Properties.Legacy.Object.Common.Size;

            ThrowWhenFailHResult(properties.SetUnsignedLargeIntegerValue(ref propKey, (ulong)stream.Length));

            propKey = PropertySystem.Properties.Legacy.Object.Common.OriginalFileName;

            string name = Path.GetFileNameWithoutExtension(stream.Name);

            ThrowWhenFailHResult(properties.SetStringValue(ref propKey, name + System.IO.Path.GetExtension(stream.Name)));

            propKey = PropertySystem.Properties.Legacy.Object.Common.Name;

            ThrowWhenFailHResult(properties.SetStringValue(ref propKey, name));

            propKey = PropertySystem.Properties.Object.ContentType;

            ThrowWhenFailHResult(properties.SetGuidValue(ref propKey, contentType));

            propKey = PropertySystem.Properties.Legacy.Object.Common.Format;

            ThrowWhenFailHResult(properties.SetGuidValue(ref propKey, objectFormat));

            uint optimalBufferSize = 0;

            ThrowWhenFailHResult(Content.CreateObjectWithPropertiesAndData(properties, out IStream writer, ref optimalBufferSize, null));

            _ = Marshal.ReleaseComObject(properties);

            properties = null;

            IntPtr bytesWrittenPtr = Marshal.AllocCoTaskMem(Marshal.SizeOf<uint>());

            Write(forceBufferSize, optimalBufferSize, bufferSize, buffer => stream.Read(buffer, 0, buffer.Length /* In order to use the real buffer size (the optimal buffer size retrieved previously). */), (byte[] buffer, int realBufferLength) =>
            {
                // TODO: re-implement IStream
                writer.Write(buffer, realBufferLength, bytesWrittenPtr);

                uint bytesWritten;

                return (bytesWritten = Marshal.PtrToStructure<uint>(bytesWrittenPtr)) < realBufferLength ? throw new InvalidOperationException("The file could not be written.") : bytesWritten;
            }, d);

            writer.Commit(0);

            // TODO: ((IPortableDeviceDataStream)writer).GetObjectID(out string newObjectId);
        }

        internal string CreateFolder(in string name, in string id)
        {
            SetContent();

            var values = (IPortableDeviceValues)new PortableDeviceValues();

            PropertyKey pKey = PropertySystem.Properties.Legacy.Object.Common.ParentId;

            ThrowExceptionForHR((int)values.SetStringValue(ref pKey, id));

            pKey = PropertySystem.Properties.Legacy.Object.Common.Name;

            ThrowExceptionForHR((int)values.SetStringValue(ref pKey, name));

            pKey = PropertySystem.Properties.Object.ContentType;

            var guid = new Guid(Guids.PropertySystem.ContentType.Folder);

            ThrowExceptionForHR((int)values.SetGuidValue(ref pKey, ref guid));

            string folderId = null;

            ThrowExceptionForHR((int)_content.CreateObjectWithPropertiesOnly(values, ref folderId));

            return folderId;
        }

        public string CreateFolder(string name) => CreateFolder(name, DeviceId);

        internal delegate int StreamReader(byte[] buffer);
        internal delegate uint StreamWriter(byte[] buffer, int realBufferLength);

        internal static void Write(in bool forceBufferSize, in uint optimalBufferSize, int bufferSize, StreamReader reader, StreamWriter writer, PortableDeviceTransferCallback d)
        {
            if (!forceBufferSize || optimalBufferSize != 0)

                bufferSize = (optimalBufferSize > int.MaxValue ? int.MaxValue : (int)optimalBufferSize);

            // TODO: check if the device has enough space.
            byte[] buffer = new byte[bufferSize];

            int realBufferLength = 0;

            bool condition() => (realBufferLength = reader(buffer)) > 0;

            uint write() => writer(buffer, realBufferLength);

            if (d == null)

                while (condition())

                    _ = write();

            else
            {
                uint bytesWritten = 0;

                while (d(bytesWritten) && condition())

                    bytesWritten = write();
            }

            // We don't need to call d here because, due to its location, it is called before the first loop and after the last one.
        }

        public void TransferTo(FileStream stream, int bufferSize, bool forceBufferSize, Guid contentType, Guid objectFormat, PortableDeviceTransferCallback d) => TransferTo(stream, bufferSize, forceBufferSize, DeviceId, contentType, objectFormat, d);

        private void TryGetNativePortableDeviceProperties()
        {
            ThrowOnInvalidOperation();

            if (_nativePortableDeviceProperties == null)

                ThrowWhenFailHResult(Content.Properties(out _nativePortableDeviceProperties));
        }

        // todo: replace by the same method of the WinCopies.Util package.

        private void ThrowIfDisposed()
        {
            if (IsDisposed)

                throw new InvalidOperationException("The current object is disposed.");
        }

        private void ThrowOnInvalidOperation()
        {
            ThrowIfDisposed();

            if (!_isOpen)

                throw new InvalidOperationException("The current PortableDevice is not open.");
        }

        // public PortableDevice(in string deviceId) => _deviceId = deviceId;

        public void Open(in ClientVersion clientVersion, in PortableDeviceOpeningOptions portableDeviceOpeningOptions)
        {
            if (IsOpen) return;

            ThrowIfDisposed();

            //if ((wszPnPDeviceID == null) || (ppDevice == null))
            //{
            //    hr = HResult.InvalidArgument;
            //    return hr;
            //}

            // CoCreate an IPortableDeviceValues interface to hold the client information.
            var pClientInformation = (IPortableDeviceValues)new PortableDeviceValues();

            // if (CoreErrorHelper.Succeeded(hr))
            // {

            // Attempt to set all properties for client information. If we fail to set
            // any of the properties below it is OK. Failing to set a property in the
            // client information isn't a fatal error.
            ThrowWhenFailHResult(pClientInformation.SetStringValue(PropertySystem.Properties.Client.Name, clientVersion.ClientName));

            // ThrowWhenFailHResult(ClientInfoHR);

            ThrowWhenFailHResult(pClientInformation.SetUnsignedIntegerValue(PropertySystem.Properties.Client.MajorVersion, clientVersion.MajorVersion));

            // ThrowWhenFailHResult(ClientInfoHR);

            ThrowWhenFailHResult(pClientInformation.SetUnsignedIntegerValue(PropertySystem.Properties.Client.MinorVersion, clientVersion.MinorVersion));

            // ThrowWhenFailHResult(ClientInfoHR);

            ThrowWhenFailHResult(pClientInformation.SetUnsignedIntegerValue(PropertySystem.Properties.Client.Revision, clientVersion.Revision));

            // ThrowWhenFailHResult(ClientInfoHR);

            // else
            // {
            // Failed to CoCreateInstance NativeAPI.Guids.PortableDevices.PortableDeviceValues for client information
            // }

            ThrowWhenFailHResult(pClientInformation.SetUnsignedIntegerValue(PropertySystem.Properties.Client.SecurityQualityOfService, (uint)SecurityImpersonationLevel.SecurityImpersonation << 16));

            // todo: to add an option for retrying this assignment if a higher rights setting fails (bool retryIfHigherRightsSettingFails = false)

            ThrowWhenFailHResult(pClientInformation.SetUnsignedIntegerValue(PropertySystem.Properties.Client.DesiredAccess, (uint)portableDeviceOpeningOptions.GenericRights));

            ThrowWhenFailHResult(pClientInformation.SetUnsignedIntegerValue(PropertySystem.Properties.Client.ShareMode, (uint)portableDeviceOpeningOptions.FileShare));

            ThrowWhenFailHResult(pClientInformation.SetBoolValue(PropertySystem.Properties.Client.ManualCloseOnDisconnect, portableDeviceOpeningOptions.ManualCloseOnDisconnect));

            //if (CoreErrorHelper.Succeeded(hr))
            //{

            //if (CoreErrorHelper.Succeeded(hr))
            //{
            // Attempt to open the device using the PnPDeviceID string given
            // to this function and the newly created client information.
            // Note that we're attempting to open the device the first 
            // time using the default (read/write) access. If this fails
            // with HResult.AccessDenied, we'll attempt to open a second time
            // with read-only access.
            ThrowWhenFailHResult(NativePortableDevice.Open(DeviceId, pClientInformation));

            //if (hr == HResult.AccessDenied)
            //{

            // Attempt to open for read-only access
            //ClientInfoHR = pClientInformation.SetUnsignedIntegerValue(
            //Microsoft.WindowsAPICodePack.COMNative.PortableDevices.PropertySystem.Properties.Client.DesiredAccess,
            //(uint)GenericRights.Read);

            //ThrowWhenFailHResult(ClientInfoHR);

            //hr = _portableDevice.Open(DeviceId, pClientInformation);

            //ThrowWhenFailHResult(hr);

            //}

            // if (CoreErrorHelper.Succeeded(hr))
            // {
            // The device successfully opened, obtain an instance of the Device into
            // ppDevice so the caller can be returned an opened IPortableDevice.
            // hr = pDevice.QueryInterface(NativeAPI.Guids.PortableDevices.IPortableDevice, ref ppDevice);

            // if (CoreErrorHelper.Failed(hr))
            // {
            // Failed to QueryInterface the opened IPortableDevice
            // }

            // }

            //}
            //else
            //{
            //    // Failed to CoCreateInstance NativeAPI.Guids.PortableDevices.PortableDevice
            //}
            //}

            // Release the IPortableDevice when finished
            //if (pDevice != null)
            //{
            //    pDevice.Release();
            //    Marshal.ReleaseCOMObject(pDevice);
            //}

            // Release the IPortableDeviceValues that contains the client information when finished
            if (pClientInformation != null)
            {
                // pClientInformation.Release();
                _ = Marshal.ReleaseComObject(pClientInformation);
                pClientInformation = null;
            }

            // return hr;
            // }

            _isOpen = true;

            PortableDeviceOpeningOptions = portableDeviceOpeningOptions;

#if WAPICP3
            _ = NativePortableDevice.Advise(0, new PortableDeviceEventCallback(this), null, out _eventCookie);
#endif
        }

        public void Close()
        {
            ThrowIfDisposed();

            if (!_isOpen)

                return;

#if WAPICP3
            _ = _nativePortableDevice.Unadvise(_eventCookie);
#endif

            ThrowWhenFailHResult(NativePortableDevice.Close());

            _items = null;

            _deviceCapabilities = null;

            _properties = null;

            _isOpen = false;
        }

        public object GetDeviceProperty(in string propertyName, in object defaultValue, in bool doNotExpand, out BlobValueKind valueKind)
        {
            ThrowIfDisposed();

            if (PortableDeviceManager is null)

                throw new InvalidOperationException("This PortableDevice object has not been created by a PortableDeviceManager.");

            uint pcbData = 0;

            BlobValueKind _valueKind = BlobValueKind.None;

            HResult hr;

            if ((hr = PortableDeviceManager._Manager.GetDeviceProperty(DeviceId, propertyName, null, ref pcbData, ref _valueKind)) == CoreErrorHelper.HResultFromWin32(ErrorCode.InsufficientBuffer))
            {
                byte[] bytes = new byte[pcbData];

                hr = PortableDeviceManager._Manager.GetDeviceProperty(DeviceId, propertyName, bytes, ref pcbData, ref _valueKind);

                if (hr == HResult.Ok)

                    return BlobHelper.ToDotNetType(bytes, (valueKind = _valueKind), doNotExpand);

                else if (hr == CoreErrorHelper.HResultFromWin32(ErrorCode.InsufficientBuffer))
                {
                    valueKind = BlobValueKind.None;

                    return defaultValue;
                }

                else ThrowWhenFailHResult(hr);
            }

            ThrowWhenFailHResult(hr);

            valueKind = BlobValueKind.None;

            return null;
        }

        internal static IPortableDeviceObject GetPortableDeviceObject(string id, bool isRoot, EnumerablePortableDeviceObject parentPortableDeviceObject, PortableDevice parentPortableDevice)
        {
            // if (isRoot) return new PortableDeviceFolder(id, true, parentPortableDevice, null);

            var properties = new PortableDeviceProperties(id, parentPortableDevice);

            IPortableDeviceObject getPortableDeviceObject() => new PortableDeviceCommonObject(id, isRoot, parentPortableDeviceObject, parentPortableDevice, null); // We return a common PortableDeviceObject because we can not read the properties for the current id. Also, we cannot try to enumerate through the current id in order to determine whether the current id represents a folder, because the enumeration could fail only because an id would represent a folder that is currently empty.

            try // This try-catch block is here to prevent exception that can be thrown by some of the properties that we are using.
            {
                // First, we try to get the common interop interface for properties.

                if (CoreErrorHelper.Succeeded(properties.GetValues(out COMNative.PropertySystem.INativePropertyValuesCollection values)))
                {
                    // If the operation succeeds, we try to get a PropVariant that will contain the requested value.

                    PropertyKey propKey = PropertySystem.Properties.Object.ContentType;

                    if (CoreErrorHelper.Succeeded(values.GetValue(ref propKey, out PropVariant propVariant)) && propVariant.VarType == VarEnum.VT_CLSID)
                    {
                        // If the operation succeeds and if the variant type of the given value VT_CLSID, we can switch this value in order to know which managed type to return.

                        string guid = ((Guid)propVariant.Value).ToString();

                        propVariant.Dispose();

                        return string.Compare(guid, Guids.PropertySystem.ContentType.Folder, true) == 0 || string.Compare(guid, Guids.PropertySystem.ContentType.All, true) == 0
                            ? new PortableDeviceFolder(id, isRoot, parentPortableDeviceObject, parentPortableDevice, properties)
                            : string.Compare(guid, Guids.PropertySystem.ContentType.FunctionalObject, true) == 0
                                ? new PortableDeviceFunctionalObject(id, isRoot, parentPortableDeviceObject, parentPortableDevice, properties)
                                : (IPortableDeviceObject)new PortableDeviceFile(id, isRoot, parentPortableDeviceObject, parentPortableDevice, properties);
                    }

                    propVariant.Dispose();

                    return getPortableDeviceObject();
                }

                else

                    return getPortableDeviceObject();
            }

            catch (Exception ex) when (ex.Is(false, typeof(PropertySystemException), typeof(PortableDeviceException)))
            {
                return getPortableDeviceObject();
            }
        }

        ///// <summary>
        ///// This method is used to send command to portable devices. This method takes two parameters of unmanaged type. If no managed wrapper is available in this code pack, you can use this method to create your own managed wrapper. Otherwise, if a managed wrapper exists, it is recommended to use these wrappers.
        ///// </summary>
        ///// <param name="portableDevice">The <see cref="PortableDevice"/> to send the command to.</param>
        ///// <param name="parameters">The parameters of the command.</param>
        ///// <param name="results">The results of the command.</param>
        private ReadOnlyPortableDeviceValueCollection SendCommand(in IPortableDeviceValues parameters)
        {
            ThrowIfDisposed();

            ThrowWhenFailHResult(NativePortableDevice.SendCommand(0, parameters, out IPortableDeviceValues _results));

            _ = _results.GetErrorValue(CommandSystem.Common.Parameters.HResult, out HResult result);

            ThrowWhenFailHResult(result);

            return new ReadOnlyPortableDeviceValueCollection(new NativeReadOnlyValueCollection(_results));
        }

        public ReadOnlyPortableDeviceValueCollection SendCommand(in ReadOnlyPortableDeviceValueCollection parameters) => SendCommand((parameters == null ? throw GetArgumentNullException(nameof(parameters)) : (INativePortableDeviceValuesCollectionProvider)parameters).NativeItems);

        public ReadOnlyPortableDeviceValueCollection SendCommand(in PortableDeviceValueCollection parameters) => SendCommand(((INativePortableDeviceValuesCollectionProvider)parameters).NativeItems);
        #endregion

        #region IDisposable Support
        public bool IsDisposed { get; private set; } = false;

        protected virtual void Dispose(in bool disposing)
        {
            if (IsDisposed) return;

            Close();

            if (disposing)
            {
                if (_items is object)
                {
                    _items.Clear();

                    _items = null;
                }

                _deviceCapabilities = null;

                _portableDeviceManager = null;

                //if (_collectionBridge is object)

                //{

                //    _collectionBridge.Dispose();

                //    _collectionBridge = null;

                //}
            }

            if (_content is object)
            {
                _ = Marshal.ReleaseComObject(_content);
                _content = null;
            }

            if (_nativePortableDeviceProperties is object)
            {
                _ = Marshal.ReleaseComObject(_nativePortableDeviceProperties);
                _nativePortableDeviceProperties = null;
            }

            _ = Marshal.ReleaseComObject(NativePortableDevice);
            NativePortableDevice = null;

            IsDisposed = true;
        }

        ~PortableDevice() => Dispose(false);

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion

        #region IEnumerable Support
        public IEnumerator<IPortableDeviceObject> GetEnumerator() =>
#if WAPICP3
IsDisposed ? throw GetExceptionForDispose(false) : IsOpen ? GetItems(Content, DeviceId, (in string id) => PortableDevice.GetPortableDeviceObject(id, false, null, this)).GetEnumerator() : throw new InvalidOperationException("The parent portable device is not open.");
#else
            _Items.GetEnumerator();
#endif

        IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();
        #endregion
    }
}
