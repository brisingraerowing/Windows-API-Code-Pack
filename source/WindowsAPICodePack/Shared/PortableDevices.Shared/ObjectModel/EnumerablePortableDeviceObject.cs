//Copyright (c) Pierre Sprimont.  All rights reserved.

using Microsoft.WindowsAPICodePack.PortableDevices.PropertySystem;

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

#if WAPICP3
using WinCopies.Collections.DotNetFix.Generic;

using static WinCopies.ThrowHelper;
#endif

using static Microsoft.WindowsAPICodePack.COMNative.PortableDevices.PortableDeviceHelper;

namespace Microsoft.WindowsAPICodePack.PortableDevices
{
    internal abstract class EnumerablePortableDeviceObject : PortableDeviceObject, IEnumerablePortableDeviceObject
    {
#if !WAPICP3
        public IPortableDeviceObject this[int index] => _Items[index];

        public int Count => _Items.Count;

        internal IList<IPortableDeviceObject> _items;

        private IList<IPortableDeviceObject> _Items
        {
            get
            {
                this.ThrowIfOperationIsNotAllowed();

                return _items
#if CS8
                ??=
#else
                ?? (_items =
#endif

                GetItems(_parentPortableDevice.Content, _id, (in string id) => PortableDevice.GetPortableDeviceObject(id, false, this, _parentPortableDevice))

#if !CS8
                )
#endif
                ;
            }
        }
#endif

        public EnumerablePortableDeviceObject(in string id, in bool isRoot, in PortableDevice parentPortableDevice, in PortableDeviceProperties properties) : base(id, isRoot, parentPortableDevice, properties)
        {
            // Left empty.
        }

        public EnumerablePortableDeviceObject(in string id, in bool isRoot, in EnumerablePortableDeviceObject parent, in PortableDevice parentPortableDevice, in PortableDeviceProperties properties) : base(id, isRoot, parent, parentPortableDevice, properties)
        {
            // Left empty.
        }

        public System.Collections.Generic.IEnumerator<IPortableDeviceObject> GetEnumerator() =>
#if WAPICP3
IsDisposed ? throw GetExceptionForDispose(false) : _parentPortableDevice.IsOpen ? GetItems(_parentPortableDevice.Content, _id, (in string id) => PortableDevice.GetPortableDeviceObject(id, false, this, _parentPortableDevice)).GetEnumerator() : throw new InvalidOperationException("The parent portable device is not open.");
#else
            _Items.GetEnumerator();
#endif

        IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();

#if !WAPICP3
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            if (disposing && _items is object)
            {
                _items.Clear();

                _items = null;
            }
        }
#endif

        //#if WAPICP3
        //        internal void AddItem(in string id)
        //        {
        //            IPortableDeviceObject item = PortableDevice.GetPortableDeviceObject(id, false, this, _parentPortableDevice);

        //            _items.Add(item);

        //            _parentPortableDevice._portableDeviceManager.RaisePortableDeviceObjectAddedEvent(item);
        //        }

        //        internal void RemoveItem(in IPortableDeviceObject item)
        //        {
        //            _items.Remove(item);

        //            _parentPortableDevice._portableDeviceManager.RaisePortableDeviceObjectRemovedEvent(item);
        //        }
        //#endif

        public void TransferTo(FileStream stream, int bufferSize, bool forceBufferSize, Guid contentType, Guid objectFormat, PortableDeviceTransferCallback d) => _parentPortableDevice.TransferTo(stream, bufferSize, forceBufferSize, Id, contentType, objectFormat, d);

        public void CreateFolder(in string name) => _parentPortableDevice.CreateFolder(name, Id);
    }
}
