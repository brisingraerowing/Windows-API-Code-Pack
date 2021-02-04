//Copyright (c) Pierre Sprimont.  All rights reserved.

using Microsoft.WindowsAPICodePack.PortableDevices.PropertySystem;

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

#if WAPICP3
using WinCopies.Collections.DotNetFix.Generic;
#endif

using static Microsoft.WindowsAPICodePack.COMNative.PortableDevices.PortableDeviceHelper;

namespace Microsoft.WindowsAPICodePack.PortableDevices
{
    internal abstract class EnumerablePortableDeviceObject : PortableDeviceObject, IEnumerablePortableDeviceObject
    {
        public IPortableDeviceObject this[int index] => _Items[index];

        public int Count => _Items.Count;

        private IList<IPortableDeviceObject> _items;

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

#if WAPICP3
        public event PortableDeviceObjectEventHandler PortableDeviceObjectAdded;
        public event PortableDeviceObjectEventHandler PortableDeviceObjectRemoved;
#endif

        public EnumerablePortableDeviceObject(in string id, in bool isRoot, in PortableDevice parentPortableDevice, in PortableDeviceProperties properties) : base(id, isRoot, parentPortableDevice, properties)
        {
            // Left empty.
        }

        public EnumerablePortableDeviceObject(in string id, in bool isRoot, in EnumerablePortableDeviceObject parent, in PortableDevice parentPortableDevice, in PortableDeviceProperties properties) : base(id, isRoot, parent, parentPortableDevice, properties)
        {
            // Left empty.
        }

        public System.Collections.Generic.IEnumerator<IPortableDeviceObject> GetEnumerator() => _Items.GetEnumerator();

        IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            if (disposing && _items is object)
            {
                _items.Clear();

                _items = null;
            }
        }

#if WAPICP3
        internal void AddItem(in string id)
        {
            IPortableDeviceObject item = PortableDevice.GetPortableDeviceObject(id, false, this, _parentPortableDevice);

            _items.Add(item);

            PortableDeviceObjectAdded?.Invoke(this, new PortableDeviceObjectEventArgs(item));
        }

        internal void RemoveItem(in IPortableDeviceObject item)
        {
            _items.Remove(item);

            PortableDeviceObjectRemoved?.Invoke(this, new PortableDeviceObjectEventArgs(item));
        }
#endif

        public void TransferTo(FileStream stream, int bufferSize, bool forceBufferSize, Guid contentType, Guid objectFormat, PortableDeviceTransferCallback d) => _parentPortableDevice.TransferTo(stream, bufferSize, forceBufferSize, Id, contentType, objectFormat, d);
    }
}
