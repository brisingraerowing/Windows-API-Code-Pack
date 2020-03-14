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
using static Microsoft.WindowsAPICodePack.Win32Native.PortableDevices.PortableDeviceHelper;
using Microsoft.WindowsAPICodePack.PortableDevices.PropertySystem;
using WinCopies.Collections;
using ObjectProperty = Microsoft.WindowsAPICodePack.PropertySystem.ObjectProperty;

namespace Microsoft.WindowsAPICodePack.PortableDevices
{

    //internal interface INativePropertyKeyCollectionProvider
    //{

    //    Win32Native.PortableDevices.PropertySystem.IPortableDeviceKeyCollection NativeItems { get; }

    //}

    internal class NativeReadOnlyPropertyKeyCollection : INativeReadOnlyCollection<PropertyKey>, WinCopies.Collections.IUIntIndexedCollection<PropertyKey>

    {

        private Win32Native.PortableDevices.PropertySystem.IPortableDeviceKeyCollection _portableDeviceKeyCollection;

        protected internal Win32Native.PortableDevices.PropertySystem.IPortableDeviceKeyCollection PortableDeviceKeyCollection { get { ThrowIfDisposed(); return _portableDeviceKeyCollection; } }

        //IPortableDeviceKeyCollection INativePropertyKeyCollectionProvider.NativeItems => PortableDeviceKeyCollection;

        // todo: replace by the same method of the WinCopies.Util.Util class.

        private protected void ThrowIfDisposed()

        {

            if (_isDisposed) throw new InvalidOperationException("The collection is disposed.");

        }

        bool INativeReadOnlyCollection<PropertyKey>.IsReadOnly
        {
            get
            {
                ThrowIfDisposed();

                return true;
            }
        }

        public NativeReadOnlyPropertyKeyCollection(Win32Native.PortableDevices.PropertySystem.IPortableDeviceKeyCollection portableDeviceKeyCollection) => _portableDeviceKeyCollection = portableDeviceKeyCollection;

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

        HResult INativeReadOnlyCollection<PropertyKey>.GetAt(ref uint index, out PropertyKey item) => GetAt(ref index, out item);

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

        HResult INativeReadOnlyCollection<PropertyKey>.GetCount(out uint count) => GetCount(out count);

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

        public NativePropertyKeyCollection(IPortableDeviceKeyCollection portableDeviceKeyCollection) : base(portableDeviceKeyCollection) { }

        bool INativeReadOnlyCollection<PropertyKey>.IsReadOnly
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

    internal class NativeReadOnlyValueCollection : INativeReadOnlyPortableDeviceValueCollection

    {

        bool INativeReadOnlyValueCollection.IsReadOnly
        {
            get
            {
                ThrowIfDisposed();

                return true;
            }
        }

        private Win32Native.PortableDevices.PropertySystem.IPortableDeviceValues _portableDeviceValues;
        //protected Dictionary<PropertyKey, object> Dic = new Dictionary<PropertyKey, object>();

        protected internal Win32Native.PortableDevices.PropertySystem.IPortableDeviceValues PortableDeviceValues { get { ThrowIfDisposed(); return _portableDeviceValues; } }

        IPortableDeviceValues INativePortableDeviceValuesCollectionProvider.NativeItems => PortableDeviceValues;

        //IPortableDeviceKeyCollection INativePropertyKeyCollectionProvider.NativeItems => PortableDeviceKeyCollection;

        // todo: replace by the same method of the WinCopies.Util.Util class.

        private protected void ThrowIfDisposed()

        {

            if (_isDisposed) throw new InvalidOperationException("The collection is disposed.");

        }

        //private readonly bool _isReadOnly;

        //bool INativeReadOnlyValueCollection.IsReadOnly
        //{
        //    get
        //    {
        //        ThrowIfDisposed();

        //        return _isReadOnly;
        //    }
        //}

        public NativeReadOnlyValueCollection(Win32Native.PortableDevices.PropertySystem.IPortableDeviceValues portableDeviceValues) => _portableDeviceValues = portableDeviceValues;

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

        //HResult INativeReadOnlyValueCollection.GetAt(in uint index, ref PropertyKey propertyKey, PropVariant propVariant)

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

        //HResult INativeReadOnlyCollection<PropertyKey>.GetAt(ref uint index, out PropertyKey item) => GetAt(ref index, out item);

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

        HResult INativeReadOnlyValueCollection.GetCount(out uint count)
        {
            ThrowIfDisposed();

            uint _count = 0;

            HResult result = _portableDeviceValues.GetCount(ref _count);

            count = _count;

            return result;
        }

        HResult INativeReadOnlyValueCollection.GetValue(ref PropertyKey key, out object pValue, out Type valueType)

        {
            ThrowIfDisposed();

            //if (Dic.TryGetValue(key, out object value))

            //{

            //    pValue = value;

            //    valueType = value.GetType();

            //    return HResult.Ok;

            //}

            var propVariant = new PropVariant();

            HResult hr = _portableDeviceValues.GetValue(ref key, propVariant);

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

        HResult INativeReadOnlyValueCollection.GetStringValue(ref PropertyKey key, out string pValue) => PortableDeviceValues.GetStringValue(ref key, out pValue);

        HResult INativeReadOnlyValueCollection.GetUnsignedIntegerValue(ref PropertyKey key, out uint pValue) => PortableDeviceValues.GetUnsignedIntegerValue(ref key, out pValue);

        HResult INativeReadOnlyValueCollection.GetSignedIntegerValue(ref PropertyKey key, out int pValue) => PortableDeviceValues.GetSignedIntegerValue(ref key, out pValue);

        HResult INativeReadOnlyValueCollection.GetUnsignedLargeIntegerValue(ref PropertyKey key, out ulong pValue) => PortableDeviceValues.GetUnsignedLargeIntegerValue(ref key, out pValue);

        HResult INativeReadOnlyValueCollection.GetSignedLargeIntegerValue(ref PropertyKey key, out long pValue) => PortableDeviceValues.GetSignedLargeIntegerValue(ref key, out pValue);

        HResult INativeReadOnlyValueCollection.GetFloatValue(ref PropertyKey key, out float pValue) => PortableDeviceValues.GetFloatValue(ref key, out pValue);

        HResult INativeReadOnlyValueCollection.GetErrorValue(ref PropertyKey key, out HResult pValue) => PortableDeviceValues.GetErrorValue(ref key, out pValue);

        HResult INativeReadOnlyValueCollection.GetKeyValue(ref PropertyKey key, out PropertyKey pValue) => PortableDeviceValues.GetKeyValue(ref key, out pValue);

        HResult INativeReadOnlyValueCollection.GetBoolValue(ref PropertyKey key, out bool pValue) => PortableDeviceValues.GetBoolValue(ref key, out pValue);

        HResult INativeReadOnlyValueCollection.GetIUnknownValue(ref PropertyKey key, out object ppValue) => PortableDeviceValues.GetIUnknownValue(ref key, out ppValue);

        HResult INativeReadOnlyValueCollection.GetGuidValue(ref PropertyKey key, out Guid pValue) => PortableDeviceValues.GetGuidValue(ref key, out pValue);

        HResult INativeReadOnlyValueCollection.GetBufferValue(ref PropertyKey key, out byte[] ppValue)
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

        //HResult INativeReadOnlyValueCollection.GetIPortableDeviceValuesValue(in PropertyKey key, out IPortableDeviceValues ppValue)

        //{

        //    GetFromDictionary<ICollection<>>

        //}

        //HResult INativeReadOnlyValueCollection.GetPropVariantCollectionValue(in PropertyKey key, out ICollection<PropVariant> ppValue)

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

        //HResult INativeReadOnlyValueCollection.GetPropertyKeyCollectionValue(in PropertyKey key, out ICollection<PropertyKey> ppValue)

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

        //HResult INativeReadOnlyValueCollection.GetIPortableDeviceValuesCollectionValue(ref PropertyKey key, out IPortableDeviceValuesCollection ppValue) => throw new NotImplementedException();

        HResult INativeReadOnlyValueCollection.CopyValuesFromPropertyStore(ref IPropertyStore pStore) => PortableDeviceValues.CopyValuesFromPropertyStore(pStore);

        HResult INativeReadOnlyValueCollection.CopyValuesToPropertyStore(ref IPropertyStore pStore) => PortableDeviceValues.CopyValuesToPropertyStore(ref pStore);
    }

    internal sealed class NativeValueCollection : NativeReadOnlyValueCollection, INativeValueCollection

    {

        public NativeValueCollection(IPortableDeviceValues portableDeviceValues) : base(portableDeviceValues) { }

        bool INativeReadOnlyValueCollection.IsReadOnly
        {
            get
            {
                ThrowIfDisposed();

                return false;
            }
        }

        HResult INativeValueCollection.Clear() => PortableDeviceValues.Clear();

        HResult INativeValueCollection.RemoveValue(ref PropertyKey propertyKey) => PortableDeviceValues.RemoveValue(ref propertyKey);

        HResult INativeValueCollection.SetStringValue(ref PropertyKey key, in string Value) => PortableDeviceValues.SetStringValue(ref key, Value);

        HResult INativeValueCollection.SetUnsignedIntegerValue(ref PropertyKey key, in uint Value) => PortableDeviceValues.SetUnsignedIntegerValue(ref key, Value);

        HResult INativeValueCollection.SetSignedIntegerValue(ref PropertyKey key, in int Value) => PortableDeviceValues.SetSignedIntegerValue(ref key, Value);

        HResult INativeValueCollection.SetUnsignedLargeIntegerValue(ref PropertyKey key, in ulong Value) => PortableDeviceValues.SetUnsignedLargeIntegerValue(ref key, Value);

        HResult INativeValueCollection.SetSignedLargeIntegerValue(ref PropertyKey key, in long Value) => PortableDeviceValues.SetSignedLargeIntegerValue(ref key, Value);

        HResult INativeValueCollection.SetFloatValue(ref PropertyKey key, in float Value) => PortableDeviceValues.SetFloatValue(ref key, Value);

        HResult INativeValueCollection.SetErrorValue(ref PropertyKey key, in HResult Value) => PortableDeviceValues.SetErrorValue(ref key, Value);

        HResult INativeValueCollection.SetKeyValue(ref PropertyKey key, ref PropertyKey Value) => PortableDeviceValues.SetKeyValue(ref key, ref Value);

        HResult INativeValueCollection.SetBoolValue(ref PropertyKey key, in bool Value) => PortableDeviceValues.SetBoolValue(ref key, Value);

        HResult INativeValueCollection.SetIUnknownValue(ref PropertyKey key, ref object pValue) => PortableDeviceValues.SetIUnknownValue(ref key, ref pValue);

        HResult INativeValueCollection.SetGuidValue(ref PropertyKey key, ref Guid Value) => PortableDeviceValues.SetGuidValue(ref key, ref Value);

        HResult INativeValueCollection.SetBufferValue(ref PropertyKey key, in byte[] pValue) => PortableDeviceValues.SetBufferValue(ref key, pValue, (uint)pValue.Length);

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

    public interface IDeviceCapabilities

    {

        WindowsAPICodePack.PropertySystem.ReadOnlyCollection<PropertyKey> Commands { get; }

    }

    public sealed class DeviceCapabilities : IDeviceCapabilities

    {

        private readonly PortableDevice _portableDevice;

        private IPortableDeviceCapabilities _portableDeviceCapabilities;

        internal DeviceCapabilities(in PortableDevice portableDevice)
        {
            _portableDevice = portableDevice ?? throw new ArgumentNullException(nameof(portableDevice));

            ThrowWhenFailHResult(_portableDevice.NativePortableDevice.Capabilities(out IPortableDeviceCapabilities portableDeviceCapabilities));

            _portableDeviceCapabilities = portableDeviceCapabilities;
        }

        private WindowsAPICodePack.PropertySystem.ReadOnlyCollection<PropertyKey> _commands;

        public WindowsAPICodePack.PropertySystem.ReadOnlyCollection<PropertyKey> Commands

        {

            get

            {

                if (_commands is null)

                {

                    ThrowWhenFailHResult(_portableDeviceCapabilities.GetSupportedCommands(out Win32Native.PortableDevices.PropertySystem.IPortableDeviceKeyCollection supportedCommands));

                    _commands = new WindowsAPICodePack.PropertySystem.ReadOnlyCollection<PropertyKey>(new NativeReadOnlyPropertyKeyCollection(supportedCommands));

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

    [DebuggerDisplay("{FriendlyName}, {DeviceDescription}, {Manufacturer}")]
    public class PortableDevice : IPortableDevice, WinCopies.Util.DotNetFix.IDisposable
    {

        // todo: replace by the same method of the WinCopies.Util package.

        private void ThrowIfDisposed()

        {

            if (IsDisposed)

                throw new InvalidOperationException("The current object is disposed.");

        }

        /// <summary>
        /// If the current <see cref="PortableDevice"/> has been created by a <see cref="PortableDevices.PortableDeviceManager"/>, gets that manager; otherwise returns <see langword="null"/>.
        /// </summary>
        public PortableDeviceManager PortableDeviceManager { get { ThrowIfDisposed(); return _portableDeviceManager; } }

        IPortableDeviceManager IPortableDevice.PortableDeviceManager => PortableDeviceManager;

        internal Win32Native.PortableDevices.IPortableDevice NativePortableDevice { get { ThrowIfDisposed(); return _nativePortableDevice; } private set { ThrowIfDisposed(); _nativePortableDevice = value; } }

        private IDeviceCapabilities _deviceCapabilities;

        /// <summary>
        /// Gets the capabilities that are supported by the current <see cref="PortableDevice"/>. These capabilities do not include the supported properties. For supported properties, see the <see cref="Properties"/> property.
        /// </summary>
        public IDeviceCapabilities DeviceCapabilities
        {
            get
            {
                ThrowIfDisposed();

                return _deviceCapabilities ?? (_deviceCapabilities = new DeviceCapabilities(this));
            }
        }

        private IPortableDeviceContent2 _content = null;

        internal IPortableDeviceContent2 Content

        {

            get

            {

                ThrowIfDisposed();

                if (_content is null)

                {

                    ThrowWhenFailHResult(NativePortableDevice.Content(out IPortableDeviceContent content));

                    _content = (IPortableDeviceContent2)content;

                }

                return _content;

            }

        }

        private PropertyCollection _properties;

        /// <summary>
        /// Gets all of the properties that are supported by the current <see cref="PortableDevice"/>.
        /// </summary>
        public PropertyCollection Properties
        {
            get
            {
                ThrowIfDisposed();

                return _properties ?? (_properties = new PropertyCollection(new PortableDeviceProperties(Consts.DeviceObjectId, this)));
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

        public bool IsOpen { get { ThrowIfDisposed(); return _isOpen; } private set { ThrowIfDisposed(); _isOpen = value; } }

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



            NativePortableDevice = (Win32Native.PortableDevices.IPortableDevice)new Win32Native.PortableDevices.PortableDevice();

        }

        // public PortableDevice(in string deviceId) => _deviceId = deviceId;

        public PortableDeviceOpeningOptions PortableDeviceOpeningOptions { get; private set; }

        public void Open(in ClientVersion clientVersion, in PortableDeviceOpeningOptions portableDeviceOpeningOptions)

        {

            ThrowIfDisposed();

            if (IsOpen) return;

            //if ((wszPnPDeviceID == null) || (ppDevice == null))
            //{
            //    hr = HResult.InvalidArgument;
            //    return hr;
            //}

            // CoCreate an IPortableDeviceValues interface to hold the client information.
            var pClientInformation = (Win32Native.PortableDevices.PropertySystem.IPortableDeviceValues)new Win32Native.PortableDevices.PropertySystem.PortableDeviceValues();

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

            PortableDeviceOpeningOptions = portableDeviceOpeningOptions;

        }

        public void Close()
        {
            ThrowIfDisposed();

            ThrowWhenFailHResult(NativePortableDevice.Close());

            _items = null;

            IsOpen = false;
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

        private IList<IPortableDeviceObject> _items;
        private PortableDeviceManager _portableDeviceManager;
        private Win32Native.PortableDevices.IPortableDevice _nativePortableDevice;
        private string _deviceFriendlyName;
        private string _deviceDescription;
        private string _deviceManufacturer;
        private bool _isOpen;
        private readonly string _deviceId;

        private IList<IPortableDeviceObject> _Items => IsOpen ? _items ?? (_items = GetItems<IPortableDeviceObject>(Content, Consts.DeviceObjectId, (in string id) => new PortableDeviceObject(id, this))) : throw new PortableDeviceException("The device is not open.");

        public IPortableDeviceObject this[int index] => _Items[index];

        public int Count => _Items.Count;

        ///// <summary>
        ///// This method is used to send command to portable devices. This method takes two parameters of unmanaged type. If no managed wrapper is available in this code pack, you can use this method to create your own managed wrapper. Otherwise, if a managed wrapper exists, it is recommended to use these wrappers.
        ///// </summary>
        ///// <param name="portableDevice">The <see cref="PortableDevice"/> to send the command to.</param>
        ///// <param name="parameters">The parameters of the command.</param>
        ///// <param name="results">The results of the command.</param>
        private ReadOnlyPortableDeviceValueCollection SendCommand(in IPortableDeviceValues parameters)

        {

            ThrowIfDisposed();

            ThrowWhenFailHResult(NativePortableDevice.SendCommand(0, parameters, out WindowsAPICodePack.Win32Native.PortableDevices.PropertySystem.IPortableDeviceValues _results));

            _ = _results.GetErrorValue(CommandSystem.Common.Parameters.HResult, out HResult result);

            ThrowWhenFailHResult(result);

            return new ReadOnlyPortableDeviceValueCollection(new NativeReadOnlyValueCollection(_results));

        }

        public ReadOnlyPortableDeviceValueCollection SendCommand(in ReadOnlyPortableDeviceValueCollection parameters) => SendCommand(((INativePortableDeviceValuesCollectionProvider)parameters).NativeItems);

        public ReadOnlyPortableDeviceValueCollection SendCommand(in PortableDeviceValueCollection parameters) => SendCommand(((INativePortableDeviceValuesCollectionProvider)parameters).NativeItems);

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

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        #endregion

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
        
        private readonly string _name;

        public string Name { get { ThrowIfDisposed(); return _name; } }

#else

#nullable enable
        private readonly string? _name;

        public string? Name { get { ThrowIfDisposed(); return _name; } }
#nullable disable

#endif

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

            if (Properties.TryGetValue(PortableDevices.PropertySystem.Properties.Legacy.Object.Common.Name, out ObjectProperty objectProperty) && objectProperty.IsSet)

            {

                Debug.WriteLine($"The {id} object is requesting the Name property.");

                object value = objectProperty.GetValue(out Type valueType);

                Debug.WriteLine($"The given value is from {valueType} type and is {value}.");

                if (valueType == typeof(string))

                    _name = (string)value;

            }

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
                }

                IsDisposed = true;
            }
        }

        public void Dispose() => Dispose(true);

        #endregion

    }
}
