using Microsoft.WindowsAPICodePack.PropertySystem;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.WindowsAPICodePack.PortableDevices.PropertySystem
{
    public interface IPortableDeviceKeyCollection : WinCopies.Util.DotNetFix.IDisposable
    {
        uint Count { get; }

        PropertyKey GetAt(
            in uint dwIndex);

        void Add(
            ref PropertyKey Key);

        void Clear();

        void RemoveAt(
            in uint dwIndex);
    }
}
