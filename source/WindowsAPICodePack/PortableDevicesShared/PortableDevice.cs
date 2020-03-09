using Microsoft.WindowsAPICodePack.PropertySystem;
using Microsoft.WindowsAPICodePack.Shell;
using Microsoft.WindowsAPICodePack.Win32Native;
using Microsoft.WindowsAPICodePack.Win32Native.PortableDevices;
using Microsoft.WindowsAPICodePack.Win32Native.PortableDevices.PropertySystem;
using Microsoft.WindowsAPICodePack.Win32Native.PropertySystem;
using Microsoft.WindowsAPICodePack.Win32Native.Shell.PropertySystem;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using GuidAttribute = Microsoft.WindowsAPICodePack.Win32Native.Shell.PropertySystem.GuidAttribute;
using static Microsoft.WindowsAPICodePack.PortableDevices.PortableDeviceHelper;
using Microsoft.WindowsAPICodePack.PortableDevices.PropertySystem;

namespace Microsoft.WindowsAPICodePack.PortableDevices
{

    internal interface INativePropertyKeyCollectionProvider
    {

        Win32Native.PortableDevices.PropertySystem.IPortableDeviceKeyCollection NativeItems { get; }

    }

    internal class NativeReadOnlyPropertyKeyCollection : IReadOnlyNativeCollection<PropertyKey>, WinCopies.Collections.IUIntIndexedCollection<PropertyKey>

    {

        private Win32Native.PortableDevices.PropertySystem.IPortableDeviceKeyCollection _portableDeviceKeyCollection;

        protected internal Win32Native.PortableDevices.PropertySystem.IPortableDeviceKeyCollection PortableDeviceKeyCollection { get { ThrowIfDisposed(); return _portableDeviceKeyCollection; } }

        //IPortableDeviceKeyCollection INativePropertyKeyCollectionProvider.NativeItems => PortableDeviceKeyCollection;

        // todo: replace by the same method of the WinCopies.Util.Util class.

        private protected void ThrowIfDisposed()

        {

            if (_isDisposed) throw new InvalidOperationException("The collection is disposed.");

        }

        private readonly bool _isReadOnly;

        bool IReadOnlyNativeCollection<PropertyKey>.IsReadOnly
        {
            get
            {
                ThrowIfDisposed();

                return _isReadOnly;
            }
        }

        public NativeReadOnlyPropertyKeyCollection(Win32Native.PortableDevices.PropertySystem.IPortableDeviceKeyCollection portableDeviceKeyCollection, bool isReadOnly)
        {
            _portableDeviceKeyCollection = portableDeviceKeyCollection;

            _isReadOnly = isReadOnly;
        }

        private bool _isDisposed = false;

        bool WinCopies.Util.DotNetFix.IDisposable.IsDisposed => _isDisposed;

        private void Dispose(bool disposing)
        {

            if (disposing || _isDisposed)

                return;

            _ = Marshal.ReleaseComObject(_portableDeviceKeyCollection);

            _portableDeviceKeyCollection = null;

            _isDisposed = true;

        }

        void IDisposable.Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        ~NativeReadOnlyPropertyKeyCollection() => Dispose(false);

        private HResult GetAt(ref uint index, out PropertyKey item)
        {
            ThrowIfDisposed();

            var propertyKey = new PropertyKey();

            HResult result = _portableDeviceKeyCollection.GetAt(index, ref propertyKey);

            item = propertyKey;

            return result;
        }

        HResult IReadOnlyNativeCollection<PropertyKey>.GetAt(ref uint index, out PropertyKey item) => GetAt(ref index, out item);

        private PropertyKey this[uint index]
        {
            get
            {
                if (index < 0 || index >= Count)

                    throw new IndexOutOfRangeException();

                _ = GetAt(ref index, out PropertyKey item);

                return item;
            }
        }

        PropertyKey WinCopies.Collections.IUIntIndexedCollection<PropertyKey>.this[uint index] => this[index];

        object WinCopies.Collections.IUIntIndexedCollection.this[uint index] => this[index];

        private HResult GetCount(out uint count)
        {
            ThrowIfDisposed();

            uint _count = 0;

            HResult result = _portableDeviceKeyCollection.GetCount(ref _count);

            count = _count;

            return result;
        }

        HResult IReadOnlyNativeCollection<PropertyKey>.GetCount(out uint count) => GetCount(out count);

        private uint Count

        {

            get

            {

                _ = GetCount(out uint count);

                return count;

            }

        }

        uint WinCopies.Collections.IUIntIndexedCollection.Count => Count;

        private IEnumerator<PropertyKey> GetEnumerator()
        {
            ThrowIfDisposed();

            return new WinCopies.Collections.UIntIndexedCollectionEnumerator<PropertyKey>(this);
        }

        IEnumerator<PropertyKey> IEnumerable<PropertyKey>.GetEnumerator() => GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    internal sealed class NativePropertyKeyCollection : NativeReadOnlyPropertyKeyCollection, INativeCollection<PropertyKey>

    {
        bool IReadOnlyNativeCollection<PropertyKey>.IsReadOnly
        {
            get
            {
                ThrowIfDisposed();

                return false;
            }
        }

        bool INativeCollection<PropertyKey>.IsFixedSize
        {
            get
            {
                ThrowIfDisposed();

                return false;
            }
        }

        HResult INativeCollection<PropertyKey>.Add(ref PropertyKey value)
        {
            ThrowIfDisposed();

            return PortableDeviceKeyCollection.Add(ref value);
        }

        HResult INativeCollection<PropertyKey>.Clear()
        {
            ThrowIfDisposed();

            return PortableDeviceKeyCollection.Clear();
        }

        HResult INativeCollection<PropertyKey>.RemoveAt(in uint index)
        {
            ThrowIfDisposed();

            return PortableDeviceKeyCollection.RemoveAt(index);
        }
    }

    internal class NativeReadOnlyValueCollection : IReadOnlyNativeValueCollection

    {

        private Win32Native.PortableDevices.PropertySystem.PortableDeviceValues _portableDeviceValues;
        //protected Dictionary<PropertyKey, object> Dic = new Dictionary<PropertyKey, object>();

        protected internal Win32Native.PortableDevices.PropertySystem.PortableDeviceValues PortableDeviceValues { get { ThrowIfDisposed(); return _portableDeviceValues; } }

        //IPortableDeviceKeyCollection INativePropertyKeyCollectionProvider.NativeItems => PortableDeviceKeyCollection;

        // todo: replace by the same method of the WinCopies.Util.Util class.

        private protected void ThrowIfDisposed()

        {

            if (_isDisposed) throw new InvalidOperationException("The collection is disposed.");

        }

        private readonly bool _isReadOnly;

        bool IReadOnlyNativeValueCollection.IsReadOnly
        {
            get
            {
                ThrowIfDisposed();

                return _isReadOnly;
            }
        }

        public NativeReadOnlyValueCollection(Win32Native.PortableDevices.PropertySystem.PortableDeviceValues portableDeviceValues, bool isReadOnly)
        {
            _portableDeviceValues = portableDeviceValues;

            _isReadOnly = isReadOnly;
        }

        private bool _isDisposed = false;

        bool WinCopies.Util.DotNetFix.IDisposable.IsDisposed => _isDisposed;

        private void Dispose(bool disposing)
        {

            if (disposing || _isDisposed)

                return;

            _ = Marshal.ReleaseComObject(_portableDeviceValues);

            _portableDeviceValues = null;

            _isDisposed = true;

        }

        void IDisposable.Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        ~NativeReadOnlyValueCollection() => Dispose(false);

        //uint Count

        //{

        //    get

        //    {

        //        uint count = 0;

        //        _ = _portableDeviceValues.GetCount(ref count);

        //        return count;

        //    }

        //}

        //HResult IReadOnlyNativeValueCollection.GetAt(in uint index, ref PropertyKey propertyKey, ref PropVariant propVariant)

        //{

        //    ThrowIfDisposed();

        //    if (index < 0 || index >= Count)

        //        throw new IndexOutOfRangeException();

        //    var propKey = new PropertyKey();

        //    var propVar = new PropVariant();

        //    _ = _portableDeviceValues.GetAt(index, ref propKey, ref propVar);

        //    propertyKey = propKey;

        //    (object value, Type valueType) result;

        //    if (_dic.ContainsKey(propKey))

        //    {

        //        object _result = _dic[propertyKey];

        //        result = (_result, _result.GetType());

        //    }

        //    else

        //        result = (propVar.Value, NativePropertyHelper.VarEnumToSystemType(propVar.VarType));

        //    propVar.Dispose();

        //    valueType = result.valueType;

        //    return result.value;

        //}

        //HResult IReadOnlyNativeCollection<PropertyKey>.GetAt(ref uint index, out PropertyKey item) => GetAt(ref index, out item);

        //private PropertyKey this[PropertyKey key]
        //{
        //    get
        //    {
        //        _ = GetAt(ref index, out PropertyKey item);

        //        return item;
        //    }
        //}

        //PropertyKey WinCopies.Collections.IUIntIndexedCollection<PropertyKey>.this[uint index] => this[index];

        //object WinCopies.Collections.IUIntIndexedCollection.this[uint index] => this[index];

        HResult IReadOnlyNativeValueCollection.GetCount(out uint count)
        {
            ThrowIfDisposed();

            uint _count = 0;

            HResult result = _portableDeviceValues.GetCount(ref _count);

            count = _count;

            return result;
        }

        HResult IReadOnlyNativeValueCollection.GetValue(ref PropertyKey key, out object pValue, out Type valueType)

        {
            ThrowIfDisposed();

            if (Dic.TryGetValue(key, out object value))

            {

                pValue = value;

                valueType = value.GetType();

                return HResult.Ok;

            }

            HResult hr = _portableDeviceValues.GetValue(ref key, out PropVariant propVariant);

            if (hr == HResult.ElementNotFound)

            {

                propVariant.Dispose();

                pValue = null;

                valueType = null;

                return hr;

            }

            (object value, Type valueType) result = (propVariant.Value, NativePropertyHelper.VarEnumToSystemType(propVariant.VarType));

            propVariant.Dispose();

            pValue = result.value;

            valueType = result.valueType;

            return HResult.Ok;
        }

        HResult IReadOnlyNativeValueCollection.GetStringValue(ref PropertyKey key, out string pValue) => PortableDeviceValues.GetStringValue(ref key, out pValue);

        HResult IReadOnlyNativeValueCollection.GetUnsignedIntegerValue(ref PropertyKey key, out uint pValue) => PortableDeviceValues.GetUnsignedIntegerValue(ref key, out pValue);

        HResult IReadOnlyNativeValueCollection.GetSignedIntegerValue(ref PropertyKey key, out int pValue) => PortableDeviceValues.GetSignedIntegerValue(ref key, out pValue);

        HResult IReadOnlyNativeValueCollection.GetUnsignedLargeIntegerValue(ref PropertyKey key, out ulong pValue) => PortableDeviceValues.GetUnsignedLargeIntegerValue(ref key, out pValue);

        HResult IReadOnlyNativeValueCollection.GetSignedLargeIntegerValue(ref PropertyKey key, out long pValue) => PortableDeviceValues.GetSignedLargeIntegerValue(ref key, out pValue);

        HResult IReadOnlyNativeValueCollection.GetFloatValue(ref PropertyKey key, out float pValue) => PortableDeviceValues.GetFloatValue(ref key, out pValue);

        HResult IReadOnlyNativeValueCollection.GetErrorValue(ref PropertyKey key, out HResult pValue) => PortableDeviceValues.GetErrorValue(ref key, out pValue);

        HResult IReadOnlyNativeValueCollection.GetKeyValue(ref PropertyKey key, out PropertyKey pValue) => PortableDeviceValues.GetKeyValue(ref key, out pValue);

        HResult IReadOnlyNativeValueCollection.GetBoolValue(ref PropertyKey key, out bool pValue) => PortableDeviceValues.GetBoolValue(ref key, out pValue);

        HResult IReadOnlyNativeValueCollection.GetIUnknownValue(ref PropertyKey key, out object ppValue) => PortableDeviceValues.GetIUnknownValue(ref key, out ppValue);

        HResult IReadOnlyNativeValueCollection.GetGuidValue(ref PropertyKey key, out Guid pValue) => PortableDeviceValues.GetGuidValue(ref key, out pValue);

        HResult IReadOnlyNativeValueCollection.GetBufferValue(ref PropertyKey key, out byte[] ppValue)
        {
            HResult hr = PortableDeviceValues.GetBufferValue(ref key,
                   out ppValue,
#if DEBUG
                out uint count
#else
                out uint _
#endif
                );

#if DEBUG

            if (CoreErrorHelper.Succeeded(hr))

                Debug.Assert(ppValue.Length == count);

#endif 

            return hr;
        }

        //private HResult GetFromDictionary<T>(in PropertyKey key, out T value) where T : class
        //{

        //    ThrowIfDisposed();

        //    if (Dic.TryGetValue(key, out object _value))

        //        if (_value is T __value)

        //        {

        //            value = __value;

        //            return HResult.Ok;

        //        }

        //        else

        //        {

        //            value = null;

        //            return HResult.DispTypeMismatch;

        //        }

        //    else

        //    {

        //        value = null;

        //        return HResult.ElementNotFound;

        //    }

        //}

        //HResult IReadOnlyNativeValueCollection.GetIPortableDeviceValuesValue(in PropertyKey key, out IPortableDeviceValues ppValue)

        //{

        //    GetFromDictionary<ICollection<>>

        //}

        //HResult IReadOnlyNativeValueCollection.GetPropVariantCollectionValue(in PropertyKey key, out ICollection<PropVariant> ppValue)

        //{

        //    HResult hr = GetFromDictionary<ICollection<PropVariant>>(key, out ICollection<PropVariant> value);

        //    if (CoreErrorHelper.Succeeded(hr))

        //        ppValue = value;

        //    else if (hr == HResult.ElementNotFound)

        //    {

        //        hr = _portableDeviceValues.GetIPortableDevicePropVariantCollectionValue(key, out IPortableDevicePropVariantCollection portableDevicePropVariantCollection);

        //        if (CoreErrorHelper.Succeeded(hr))

        //        {

        //            Dic.Add(key, new ReadOnlyCollection<PropVariant>(new propvariant(portableDevicePropVariantCollection)));

        //            ppValue = value;

        //        }

        //        else

        //            ppValue = null;

        //    }

        //    else

        //        ppValue = null;

        //    return hr;

        //}

        //HResult IReadOnlyNativeValueCollection.GetPropertyKeyCollectionValue(in PropertyKey key, out ICollection<PropertyKey> ppValue)

        //{

        //    HResult hr = GetFromDictionary<ICollection<PropertyKey>>(key, out ICollection<PropertyKey> value);

        //    if (CoreErrorHelper.Succeeded(hr))

        //        ppValue = value;

        //    else if (hr == HResult.ElementNotFound)

        //    {

        //        hr = _portableDeviceValues.GetIPortableDeviceKeyCollectionValue(key, out IPortableDeviceKeyCollection portableDevicePropVariantCollection);

        //        if (CoreErrorHelper.Succeeded(hr))

        //        {

        //            Dic.Add(key, new ReadOnlyCollection<PropertyKey>(new NativePropertyKeyCollection(portableDevicePropVariantCollection)));

        //            ppValue = value;

        //        }

        //        else

        //            ppValue = null;

        //    }

        //    else

        //        ppValue = null;

        //    return hr;

        //}

        //HResult IReadOnlyNativeValueCollection.GetIPortableDeviceValuesCollectionValue(ref PropertyKey key, out IPortableDeviceValuesCollection ppValue) => throw new NotImplementedException();

        HResult IReadOnlyNativeValueCollection.CopyValuesFromPropertyStore(ref IPropertyStore pStore) => PortableDeviceValues.CopyValuesFromPropertyStore(pStore);

        HResult IReadOnlyNativeValueCollection.CopyValuesToPropertyStore(ref IPropertyStore pStore) => PortableDeviceValues.CopyValuesToPropertyStore(ref pStore);
    }

    internal sealed class NativeValueCollection : NativeReadOnlyValueCollection, INativeValueCollection

    {

        HResult INativeValueCollection.Clear() => PortableDeviceValues.Clear();

        HResult INativeValueCollection.RemoveValue(ref PropertyKey propertyKey) => PortableDeviceValues.RemoveValue(ref propertyKey);

        HResult INativeValueCollection.SetStringValue(ref PropertyKey key, in string Value) => PortableDeviceValues.SetStringValue(ref key, Value);

        HResult INativeValueCollection.SetUnsignedIntegerValue(ref PropertyKey key, in uint Value) => PortableDeviceValues.SetUnsignedIntegerValue(ref key, Value);

        HResult INativeValueCollection.SetSignedIntegerValue(ref PropertyKey key, in int Value) => PortableDeviceValues.SetSignedIntegerValue(ref key, Value);

        HResult INativeValueCollection.SetUnsignedLargeIntegerValue(ref PropertyKey key, in ulong Value) => PortableDeviceValues.SetUnsignedLargeIntegerValue(ref key, Value);

        HResult INativeValueCollection.SetSignedLargeIntegerValue(ref PropertyKey key, in long Value) => PortableDeviceValues.SetSignedLargeIntegerValue(ref key, Value);

        HResult INativeValueCollection.SetFloatValue(ref PropertyKey key,in float Value) => PortableDeviceValues.SetFloatValue(ref key, Value);

        HResult INativeValueCollection.SetErrorValue(ref PropertyKey key, in HResult Value) => PortableDeviceValues.SetErrorValue(ref key, Value);

        HResult INativeValueCollection.SetKeyValue(ref PropertyKey key, ref PropertyKey Value) => PortableDeviceValues.SetKeyValue(ref key, ref Value);

        HResult INativeValueCollection.SetBoolValue(ref PropertyKey key, in bool Value) => PortableDeviceValues.SetBoolValue(ref key, Value);

        HResult INativeValueCollection.SetIUnknownValue(ref PropertyKey key, ref object pValue) => PortableDeviceValues.SetIUnknownValue(ref key, ref pValue);

        HResult INativeValueCollection.SetGuidValue(ref PropertyKey key, ref Guid Value) => PortableDeviceValues.SetGuidValue(ref key, ref Value);

        HResult INativeValueCollection.SetBufferValue(ref PropertyKey key, in byte[] pValue) => PortableDeviceValues.SetBufferValue(ref key, pValue, (uint) pValue.Length);

        //private HResult SetToDictionary<T>(ref PropertyKey key, T value) where T : class

        //{

        //        else

        //        {

        //            PortableDeviceValues.

        //        }

        //}

        //HResult INativeValueCollection.SetIPortableDeviceValuesValue(ref PropertyKey key, in IPortableDeviceValues pValue) => throw new NotImplementedException();

        //HResult INativeValueCollection.SetPropVariantCollectionValue(ref PropertyKey key, in ICollection<PropVariant> pValue) => throw new NotImplementedException();

        //HResult INativeValueCollection.SetPropertyKeyCollectionValue(ref PropertyKey key, in ICollection<PropertyKey> pValue)

        //{

        //    if (Dic.TryGetValue(key, out object _value))

        //        if (pValue == _value)

        //            return HResult.Ok;

        //        else

        //        { 

        //            Dic[key] = pValue;

        //            PortableDeviceValues.SetIPortableDeviceKeyCollectionValue(ref key, )

        //}

        //HResult INativeValueCollection.SetIPortableDeviceValuesCollectionValue(ref PropertyKey key, in IPortableDeviceValuesCollection pValue) => throw new NotImplementedException();
    }

    public sealed class DeviceCapabilities

    {

        private readonly PortableDevice _portableDevice;

        private IPortableDeviceCapabilities _portableDeviceCapabilities;

        internal DeviceCapabilities(in PortableDevice portableDevice)
        {
            _portableDevice = portableDevice ?? throw new ArgumentNullException(nameof(portableDevice));

            ThrowWhenFailHResult(_portableDevice.NativePortableDevice.Capabilities(out _portableDeviceCapabilities));
        }

        private ReadOnlyCollection<PropertyKey> _commands;

        public ReadOnlyCollection<PropertyKey> Commands

        {

            get

            {

                if (_commands is null)

                {

                    ThrowWhenFailHResult(_portableDeviceCapabilities.GetSupportedCommands(out Win32Native.PortableDevices.PropertySystem.IPortableDeviceKeyCollection supportedCommands));

                    _commands = new ReadOnlyPropertyKeyCollection(new NativeReadOnlyPropertyKeyCollection(supportedCommands, true));

                }

                return _commands;

            }

        }

        ~DeviceCapabilities()

        {

            _ = Marshal.ReleaseComObject(_portableDeviceCapabilities);

            _portableDeviceCapabilities = null;

        }

    }

    public class PortableDeviceHelper

    {

        public static void ThrowWhenFailHResult(HResult hResult)

        {

            if (!CoreErrorHelper.Succeeded(hResult))

                throw new PropertySystemException("An operation has not succeeded, see the inner exception.", Marshal.GetExceptionForHR((int)hResult));

        }

    }

    [DebuggerDisplay("{FriendlyName}, {DeviceDescription}, {Manufacturer}")]
    public class PortableDevice : IPortableDevice
    {

        /// <summary>
        /// If the current <see cref="PortableDevice"/> has been created by a <see cref="PortableDevices.PortableDeviceManager"/>, gets that manager; otherwise returns <see langword="null"/>.
        /// </summary>
        public PortableDeviceManager PortableDeviceManager { get; internal set; }

        IPortableDeviceManager IPortableDevice.PortableDeviceManager => PortableDeviceManager;

        internal Win32Native.PortableDevices.IPortableDevice NativePortableDevice { get; private set; } = null;

        internal IPortableDeviceProperties NativePortableDeviceProperties { get; private set; }

        private DeviceCapabilities _deviceCapabilities = null;

        /// <summary>
        /// Gets the capabilities that are supported by the current <see cref="PortableDevice"/>. These capabilities do not include the supported properties. For supported properties, see the <see cref="Properties"/> property.
        /// </summary>
        public DeviceCapabilities DeviceCapabilities => _deviceCapabilities ?? (_deviceCapabilities = new DeviceCapabilities(this));

        private IPortableDeviceContent2 _content = null;

        internal IPortableDeviceContent2 Content

        {

            get

            {

                if (_content is null)

                {

                    ThrowWhenFailHResult(NativePortableDevice.Content(out IPortableDeviceContent content));

                    _content = (IPortableDeviceContent2)content;

                }

                return _content;

            }

        }

        private PropertyCollection _properties = null;

        /// <summary>
        /// Gets all of the properties that are supported by the current <see cref="PortableDevice"/>.
        /// </summary>
        public PropertyCollection Properties => _properties ?? (_properties = new PropertyCollection(new PortableDeviceProperties(Consts.DeviceObjectId, this)));

        /// <summary>
        /// Gets the device id of the current <see cref="PortableDevice"/>.
        /// </summary>
        public string DeviceId { get; }

        /// <summary>
        /// If the current <see cref="PortableDevice"/> has been created by a <see cref="PortableDevices.PortableDeviceManager"/>, gets the device friendly name of the current <see cref="PortableDevice"/>, otherwise gets <see langword="null"/>.
        /// </summary>
        public string DeviceFriendlyName { get; internal set; }

        /// <summary>
        /// If the current <see cref="PortableDevice"/> has been created by a <see cref="PortableDevices.PortableDeviceManager"/>, gets the device description of the current <see cref="PortableDevice"/>, otherwise gets <see langword="null"/>.
        /// </summary>
        public string DeviceDescription { get; internal set; }

        /// <summary>
        /// If the current <see cref="PortableDevice"/> has been created by a <see cref="PortableDevices.PortableDeviceManager"/>, gets the device manufacturer of the current <see cref="PortableDevice"/>, otherwise gets <see langword="null"/>.
        /// </summary>
        public string DeviceManufacturer { get; internal set; }

        public bool IsOpen { get; private set; }

        internal PortableDevice(in PortableDeviceManager portableDeviceManager, in string deviceId)

        {

            PortableDeviceManager = portableDeviceManager;

            DeviceId = deviceId;

            uint length = 0;

            ThrowWhenFailHResult(PortableDeviceManager._Manager.GetDeviceFriendlyName(DeviceId, null, length));

            var stringBuilder = new StringBuilder((int)length);

            ThrowWhenFailHResult(PortableDeviceManager._Manager.GetDeviceFriendlyName(DeviceId, stringBuilder, ref length));

            DeviceFriendlyName = stringBuilder.ToString();

            length = 0;

            ThrowWhenFailHResult(PortableDeviceManager._Manager.GetDeviceDescription(DeviceId, null, length));

            stringBuilder = new StringBuilder((int)length);

            ThrowWhenFailHResult(PortableDeviceManager._Manager.GetDeviceDescription(DeviceId, stringBuilder, ref length));

            DeviceDescription = stringBuilder.ToString();

            length = 0;

            ThrowWhenFailHResult(PortableDeviceManager._Manager.GetDeviceManufacturer(DeviceId, null, length));

            stringBuilder = new StringBuilder((int)length);

            ThrowWhenFailHResult(PortableDeviceManager._Manager.GetDeviceManufacturer(DeviceId, stringBuilder, ref length));

            DeviceManufacturer = stringBuilder.ToString();



            NativePortableDevice = new Win32Native.PortableDevices.PortableDevice();

        }

        public PortableDevice(in string deviceId) => DeviceId = deviceId;

        public void Open(in ClientVersion clientVersion, in PortableDeviceOpeningOptions portableDeviceOpeningOptions)

        {

            if (IsDisposed)

                throw new InvalidOperationException("The current object is disposed.");

            if (IsOpen) return;

            //if ((wszPnPDeviceID == null) || (ppDevice == null))
            //{
            //    hr = HResult.InvalidArgument;
            //    return hr;
            //}

            // CoCreate an IPortableDeviceValues interface to hold the client information.
            Win32Native.PortableDevices.PropertySystem.IPortableDeviceValues pClientInformation = new Win32Native.PortableDevices.PropertySystem.PortableDeviceValues();

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
            // Failed to CoCreateInstance Win32Native.Guids.PortableDevices.PortableDeviceValues for client information
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
            //Microsoft.WindowsAPICodePack.Win32Native.PortableDevices.PropertySystem.Properties.Client.DesiredAccess,
            //(uint)GenericRights.Read);

            //ThrowWhenFailHResult(ClientInfoHR);

            //hr = _portableDevice.Open(DeviceId, pClientInformation);

            //ThrowWhenFailHResult(hr);

            //}

            // if (CoreErrorHelper.Succeeded(hr))
            // {
            // The device successfully opened, obtain an instance of the Device into
            // ppDevice so the caller can be returned an opened IPortableDevice.
            // hr = pDevice.QueryInterface(Win32Native.Guids.PortableDevices.IPortableDevice, ref ppDevice);

            // if (CoreErrorHelper.Failed(hr))
            // {
            // Failed to QueryInterface the opened IPortableDevice
            // }

            // }

            //}
            //else
            //{
            //    // Failed to CoCreateInstance Win32Native.Guids.PortableDevices.PortableDevice
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

            IsOpen = true;

        }

        public void Close()
        {
            ThrowWhenFailHResult(NativePortableDevice.Close());

            IsOpen = false;
        }

        public object GetDeviceProperty(in string propertyName, in object defaultValue, in bool doNotExpand, out BlobValueKind valueKind)

        {

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

        private List<IPortableDeviceObject> _items;

        private List<IPortableDeviceObject> _Items

        {

            get

            {

                if (_items is null)

                    if (IsOpen)

                        GetItems();

                    else

                        throw new PortableDeviceException("The device is not open.");

                return _items;

            }

        }

        public IPortableDeviceObject this[int index] => _Items[index];

        private void GetItems()

        {

            if (CoreErrorHelper.Succeeded(Content.EnumObjects(0, Consts.DeviceObjectId, null, out IEnumPortableDeviceObjectIDs enumPortableDeviceObjectIDs)))

            {

                var items = new LinkedList<IPortableDeviceObject>();

                while (true)

                {

                    string[] objectIDs = new string[10];

                    if (CoreErrorHelper.Succeeded(enumPortableDeviceObjectIDs.Next(10, objectIDs, out uint fetched)))

                        for (uint i = 0; i < fetched; i++)

                            _ = items.AddLast(new PortableDeviceObject(objectIDs[i], this));

                    else break;

                }

                _items = new List<IPortableDeviceObject>(items.Count);

                if (items.Count > 0)

                {

                    _items[0] = items.First.Value;

                    if (items.Count > 1)

                        for (int i = 1; i < items.Count; i++)

                        {

                            items.RemoveFirst();

                            _items[i] = items.First.Value;

                        }

                }

            }

        }

        ///// <summary>
        ///// This method is used to send command to portable devices. This method takes two parameters of unmanaged type. If no managed wrapper is available in this code pack, you can use this method to create your own managed wrapper. Otherwise, if a managed wrapper exists, it is recommended to use these wrappers.
        ///// </summary>
        ///// <param name="portableDevice">The <see cref="PortableDevice"/> to send the command to.</param>
        ///// <param name="parameters">The parameters of the command.</param>
        ///// <param name="results">The results of the command.</param>
        public void SendCommand(WindowsAPICodePack.PropertySystem.ValueCollection parameters, out PropertySystem.IPortableDeviceValues results)

        {

            ThrowWhenFailHResult(NativePortableDevice.SendCommand(0, parameters.._PortableDeviceValues, out WindowsAPICodePack.Win32Native.PortableDevices.PropertySystem.IPortableDeviceValues _results));

            _ = _results.GetErrorValue(CommandSystem.Common.Parameters.HResult, out HResult result);

            ThrowWhenFailHResult(result);

            results = new PropertySystem.PortableDeviceValues(_results);

        }

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

                if (_deviceCapabilities is object)

                    _deviceCapabilities = null;
            }

            if (_content is object)

            {

                _ = Marshal.ReleaseComObject(_content);
                _content = null;

            }

            _ = Marshal.ReleaseComObject(NativePortableDeviceProperties);
            NativePortableDeviceProperties = null;
            _ = Marshal.ReleaseComObject(NativePortableDevice);
            NativePortableDevice = null;
            IsDisposed = true;

        }

        ~PortableDevice()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion

        #region IEnumerable Support

        public IEnumerator<IPortableDeviceObject> GetEnumerator() => _Items.GetEnumerator();

        #endregion

    }

    public class PortableDeviceObject : IPortableDeviceObject

    {

        public string Id { get; }

        public IPortableDevice ParentPortableDevice { get; }

        internal PortableDeviceObject(string id, IPortableDevice parentPortableDevice)

        {

            Id = id;

            ParentPortableDevice = parentPortableDevice;

        }

    }
}
