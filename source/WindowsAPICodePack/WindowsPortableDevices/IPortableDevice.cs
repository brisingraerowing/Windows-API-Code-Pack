using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.WindowsAPICodePack.PortableDevices
{
    public interface IPortableDevice : IDisposable
    {

        IPortableDeviceManager PortableDeviceManager { get; }

        string DeviceFriendlyName { get; }

        string DeviceDescription { get; }

        string DeviceManufacturer { get; }

        void GetCapabilities();

    }
}
