using Microsoft.WindowsAPICodePack.Win32Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.WindowsAPICodePack.PortableDevices
{
    public interface IPortableDevice : IDisposable, IEnumerable<IPortableDeviceContentObject>
    {

        IPortableDeviceManager PortableDeviceManager { get; }

        string DeviceFriendlyName { get; }

        string DeviceDescription { get; }

        string DeviceManufacturer { get; }

        bool IsOpen { get; }

        GenericRights OpeningRights { get; }

        FileShareOptions OpeningFileShareOptions { get; }

        void Open(in ClientVersion clientVersion, in PortableDeviceOpeningOptions portableDeviceOpeningOptions);

        void Close();

        object GetDeviceProperty(string propertyName, object defaultValue, bool doNotExpand, out BlobValueKind valueKind);

    }
}

public interface IPortableDeviceContentObject : IDisposable, IEnumerable<IPortableDeviceContentObject>

{



}
