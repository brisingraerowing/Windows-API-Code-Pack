//Copyright (c) Pierre Sprimont.  All rights reserved.

using Microsoft.WindowsAPICodePack.COMNative.PortableDevices.ResourceSystem;
using Microsoft.WindowsAPICodePack.COMNative.Shell.PropertySystem;
using Microsoft.WindowsAPICodePack.PortableDevices.CommandSystem.Object;
using Microsoft.WindowsAPICodePack.PortableDevices.PropertySystem;
using Microsoft.WindowsAPICodePack.PropertySystem;
using Microsoft.WindowsAPICodePack.Win32Native.Storage;

using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

using static Microsoft.WindowsAPICodePack.COMNative.PortableDevices.PortableDeviceHelper;
using static Microsoft.WindowsAPICodePack.PortableDevices.PortableDevice;

using static WinCopies.
#if WAPICP2
    Util.Util;
#else
    ThrowHelper;
#endif

namespace Microsoft.WindowsAPICodePack.PortableDevices
{
    internal sealed class PortableDeviceFile : NotEnumerablePortableDeviceObject, IPortableDeviceFile
    {
        protected override PortableDeviceFileType FileTypeOverride => PortableDeviceFileType.File;

        public ulong Size
        {
            get
            {
                this.ThrowIfOperationIsNotAllowed();

                return Properties.TryGetValue(PropertySystem.Properties.Object.ContentType, out WindowsAPICodePack.PropertySystem.Property property) && property.TryGetValue(out ulong value)
                    ? value
                    : throw new PropertySystemException("Cannot read the property.");
            }
        }

        public PortableDeviceFile(in string id, in bool isRoot, in PortableDevice parentPortableDevice, in PortableDeviceProperties properties) : base(id, isRoot, parentPortableDevice, properties)
        {
            // Left empty.
        }

        public PortableDeviceFile(in string id, in bool isRoot, in EnumerablePortableDeviceObject parent, in PortableDevice parentPortableDevice, in PortableDeviceProperties properties) : base(id, isRoot, parent, parentPortableDevice, properties)
        {
            //if (Properties.TryGetValue(PortableDevices.PropertySystem.Properties.Storage.Capacity, out Property _objectProperty) && _objectProperty.TryGetValue(out ulong _value))

            //    _storageCapacity = new PortableDeviceObjectStorageCapacity(this, _value);
        }

        public void TransferFrom(Stream stream, int bufferSize, bool forceBufferSize, PortableDeviceTransferCallback d)
        {
            if (!(stream ?? throw GetArgumentNullException(nameof(stream))).CanWrite)

                throw new ArgumentException("The given stream does not support writting.");

            if (bufferSize <= 0)

                throw new ArgumentOutOfRangeException(nameof(bufferSize));

            ThrowWhenFailHResult(_parentPortableDevice.Content.Transfer(out IPortableDeviceResources resources));

            PropertyKey propKey = ResourceSystem.Resources.Default;

            uint optimalBufferSize = 0;

            ThrowWhenFailHResult(resources.GetStream(Id, ref propKey, (uint)STGM.Access.Read, ref optimalBufferSize, out System.Runtime.InteropServices.ComTypes.IStream reader));

            _ = Marshal.ReleaseComObject(resources);

            resources = null;

            IntPtr realBufferLengthPtr = Marshal.AllocCoTaskMem(Marshal.SizeOf<uint>());

            Write(forceBufferSize, optimalBufferSize, bufferSize, buffer =>
            {
                reader.Read(buffer, buffer.Length /* In order to use the real buffer size (the optimal buffer size retrieved previously). */, realBufferLengthPtr);

                return (int)Marshal.PtrToStructure<uint>(realBufferLengthPtr);
            }, (byte[] buffer, int realBufferLength) =>
            {
                stream.Write(buffer, 0, realBufferLength);

                return (uint)realBufferLength;
            }, d);
        }

        public void TransferFrom(string path, FileMode fileMode, FileShare fileShare, int bufferSize, bool forceBufferSize, PortableDeviceTransferCallback d)
        {
            FileStream stream = forceBufferSize ? new FileStream(path, fileMode, FileAccess.Write, fileShare, bufferSize) : new FileStream(path, fileMode, FileAccess.Write, fileShare);

            try
            {
                TransferFrom(stream, bufferSize, forceBufferSize, d);

                stream.Flush();

                stream.Close();
            }

            finally
            {
                stream.Dispose();
            }
        }
    }
}
