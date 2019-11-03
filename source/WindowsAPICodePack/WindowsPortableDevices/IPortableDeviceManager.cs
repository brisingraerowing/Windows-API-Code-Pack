using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.WindowsAPICodePack.PortableDevices
{
    public interface IPortableDeviceManager
    {
        IReadOnlyCollection<PortableDevice> PortableDevices { get; }

        IReadOnlyCollection<PortableDevice> PrivatePortableDevices { get; }

        void RefreshDeviceList();

        void GetDevices();

        void GetPrivateDevices();
    }
}
