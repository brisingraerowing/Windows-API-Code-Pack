//Copyright (c) Pierre Sprimont.  All rights reserved.

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.WindowsAPICodePack.COMNative.PortableDevices.PortableDeviceHelper;

namespace Microsoft.WindowsAPICodePack.PortableDevices
{
    public interface IPortableDeviceManager : IDisposable
    {
        ReadOnlyCollection<PortableDevice> PortableDevices { get; }

        ReadOnlyCollection<PortableDevice> PrivatePortableDevices { get; }

#if WAPICP3
        event PortableDeviceUpdatedEventHandler PortableDeviceUpdated;
        event PortableDeviceObjectEventHandler PortableDeviceObjectAdded;
        event PortableDeviceObjectEventHandler PortableDeviceObjectRemoved;
        //        void TransferFrom(string path, FileMode fileMode, FileShare fileShare, int bufferSize, bool forceBufferSize, PortableDeviceTransferStartedCallback started, PortableDeviceTransferCallback d);
#endif

        void RefreshDeviceList();

        void GetDevices();

        void GetPrivateDevices();
    }

    public class PortableDeviceManager : IPortableDeviceManager
    {
        internal Microsoft.WindowsAPICodePack.COMNative.PortableDevices.IPortableDeviceManager _Manager { get; set; } = null;

        private List<PortableDevice> _portableDevices = null;

        public ReadOnlyCollection<PortableDevice> PortableDevices { get; }

        private List<PortableDevice> _privatePortableDevices = null;

        public ReadOnlyCollection<PortableDevice> PrivatePortableDevices { get; }

#if WAPICP3
        public event PortableDeviceUpdatedEventHandler PortableDeviceUpdated;
        public event PortableDeviceObjectEventHandler PortableDeviceObjectAdded;
        public event PortableDeviceObjectEventHandler PortableDeviceObjectRemoved;
#endif

        public PortableDeviceManager()
        {
            _Manager = (COMNative.PortableDevices.IPortableDeviceManager)new COMNative.PortableDevices.PortableDeviceManager();

            _portableDevices = new List<PortableDevice>();

            PortableDevices = new ReadOnlyCollection<PortableDevice>(_portableDevices);

            _privatePortableDevices = new List<PortableDevice>();

            PrivatePortableDevices = new ReadOnlyCollection<PortableDevice>(_privatePortableDevices);
        }

#if WAPICP3
        internal void RaisePortableDeviceUpdatedEvent(in PortableDeviceUpdatedEventArgs e) => PortableDeviceUpdated?.Invoke(this, e);

        internal void RaisePortableDeviceObjectAddedEvent(in string id)=> PortableDeviceObjectAdded?.Invoke(this, new PortableDeviceObjectEventArgs(id));

        internal void RaisePortableDeviceObjectRemovedEvent(in string id) => PortableDeviceObjectRemoved?.Invoke(this, new PortableDeviceObjectEventArgs(id));
#endif

        public void RefreshDeviceList() => ThrowWhenFailHResult(_Manager.RefreshDeviceList());

        public void GetDevices()
        {
            uint count = 1;

            ThrowWhenFailHResult(_Manager.GetDevices(null, ref count)); // We get the PortableDevices.

            if (count == 0)
            {
                _portableDevices.Clear(); // We found no devices anymore, so we clear the existing PortableDevices.

                return;
            }

            string[] deviceIDs = new string[count];

            ThrowWhenFailHResult(_Manager.GetDevices(deviceIDs, ref count));

            if (count == 0)
            {
                _portableDevices.Clear(); // We found no devices anymore, so we clear the existing PortableDevices.

                return;
            }

            OnUpdatePortableDevices(deviceIDs, false);
        }

        public void GetPrivateDevices()
        {
            uint count = 1;

            ThrowWhenFailHResult(_Manager.GetPrivateDevices(null, ref count)); // We get the PortableDevices.

            if (count == 0)
            {
                _privatePortableDevices.Clear(); // We found no devices anymore, so we clear the existing PortableDevices.

                return;
            }

            string[] deviceIDs = new string[count];

            ThrowWhenFailHResult(_Manager.GetPrivateDevices(deviceIDs, ref count));

            if (count == 0)
            {
                _privatePortableDevices.Clear(); // We found no devices anymore, so we clear the existing PortableDevices.

                return;
            }

            OnUpdatePortableDevices(deviceIDs, true);
        }

        protected virtual void OnUpdatePortableDevices(string[] deviceIDs, in bool privateDevices)
        {
            if (deviceIDs is null)

                throw new ArgumentNullException(nameof(deviceIDs));

            List<PortableDevice> portableDevices = privateDevices ? _privatePortableDevices : _portableDevices;

            _ = portableDevices.RemoveAll(d => !deviceIDs.Contains(d.DeviceId));

            for (int i = 0; i < deviceIDs.Length; i++)
            {
                if (portableDevices.Any(d => d.DeviceId == deviceIDs[i]))

                    continue;

                OnAddPortableDevice(deviceIDs[i], privateDevices);

                deviceIDs[i] = null;
            }
        }

        protected virtual void OnAddPortableDevice(in string deviceId, in bool isPrivateDevice) => OnAddPortableDevice(new PortableDevice(this, deviceId), isPrivateDevice);

        protected virtual void OnAddPortableDevice(in PortableDevice portableDevice, in bool isPrivateDevice) => (isPrivateDevice ? _privatePortableDevices : _portableDevices).Add(portableDevice);

        #region IDisposable Support
        public bool IsDisposed { get; private set; } = false;

        protected virtual void Dispose(in bool disposing)
        {
            if (IsDisposed) return;

            //foreach (PortableDevice portableDevice in _portableDevices)

            //    portableDevice.Dispose();

            _portableDevices.Clear();

            //foreach (PortableDevice privatePortableDevice in _privatePortableDevices)

            //    privatePortableDevice.Dispose();

            _privatePortableDevices.Clear();

            _ = Marshal.ReleaseComObject(_Manager);

            _Manager = null;

            IsDisposed = true;
        }

        ~PortableDeviceManager() => Dispose(false);

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
