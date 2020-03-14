using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.WindowsAPICodePack.PortableDevices
{
    public interface IPortableDeviceManager : IDisposable
    {
        ReadOnlyCollection<PortableDevice> PortableDevices { get; }

        ReadOnlyCollection<PortableDevice> PrivatePortableDevices { get; }

        void RefreshDeviceList();

        void GetDevices();

        void GetPrivateDevices();
    }
}
