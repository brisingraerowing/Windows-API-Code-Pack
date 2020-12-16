//Copyright (c) Pierre Sprimont.  All rights reserved.

using Microsoft.WindowsAPICodePack.PortableDevices.PropertySystem;

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

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
                ThrowIfOperationIsNotAllowed();

#if CS7
                return _items ?? (_items = GetItems<IPortableDeviceObject>(_parentPortableDevice.Content, _id, (in string id) => PortableDevice.GetPortableDeviceObject(id, false, this, _parentPortableDevice)));
#else
                return _items ??= GetItems<IPortableDeviceObject>(_parentPortableDevice.Content, _id, (in string id) => PortableDevice.GetPortableDeviceObject(id, false, this, _parentPortableDevice));
#endif
            }
        }

        public EnumerablePortableDeviceObject(in string id, in bool isRoot, in PortableDevice parentPortableDevice, in PortableDeviceProperties properties) : this(id, isRoot, null, parentPortableDevice, properties)
        {
            // Left empty.
        }

        public EnumerablePortableDeviceObject(in string id, in bool isRoot, in PortableDeviceObject parent, in PortableDevice parentPortableDevice, in PortableDeviceProperties properties

            ) : base(id, isRoot, parent, parentPortableDevice, properties)
        {
            // Left empty.
        }

        public IEnumerator<IPortableDeviceObject> GetEnumerator() => _Items.GetEnumerator();

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

        public void TransferTo( FileStream stream, int bufferSize, bool forceBufferSize, Guid contentType, Guid objectFormat, PortableDeviceTransferCallback d) => _parentPortableDevice.TransferTo(stream, bufferSize, forceBufferSize, Id, contentType, objectFormat, d);
    }
}
