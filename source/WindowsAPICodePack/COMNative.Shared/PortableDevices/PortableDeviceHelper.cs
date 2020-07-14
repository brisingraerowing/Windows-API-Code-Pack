//Copyright (c) Pierre Sprimont.  All rights reserved.

using Microsoft.WindowsAPICodePack.PortableDevices;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using WinCopies.Collections;
using Microsoft.WindowsAPICodePack.Win32Native;

namespace Microsoft.WindowsAPICodePack.COMNative.PortableDevices
{
    public static class PortableDeviceHelper
    {
        public delegate T GetPortableDeviceObject<T>(in string id);

        public static IList<T> GetItems<T>(in IPortableDeviceContent portableDeviceContent, in string id, in GetPortableDeviceObject<T> getPortableDeviceObjectDelegate)
        {
            HResult hr = portableDeviceContent.EnumObjects(0, id, null, out IEnumPortableDeviceObjectIDs enumPortableDeviceObjectIDs);

            if (CoreErrorHelper.Succeeded(hr))
            {
                var items = new ArrayBuilder<T>();

                do
                {
                    string[] objectIDs = new string[10];

                    uint fetched = 0;

                    hr = enumPortableDeviceObjectIDs.Next(10, objectIDs, ref fetched);

                    if (CoreErrorHelper.Succeeded(hr))
                    {
                        if (fetched == 0)

                            break;

                        for (uint i = 0; i < fetched; i++)

                            _ = items.AddLast(getPortableDeviceObjectDelegate(objectIDs[i]));
                    }

                    else ThrowWhenFailHResult(hr);

                } while (hr == HResult.Ok);

                return items.ToList();
            }

            else

                throw GetPortableDeviceExceptionForHR(hr);
        }

        public static PortableDeviceException GetPortableDeviceExceptionForHR(HResult hr) => new PortableDeviceException("An operation has not succeeded, see the inner exception.", Marshal.GetExceptionForHR((int)hr));

        public static void ThrowWhenFailHResult(HResult hr)
        {
            if (!CoreErrorHelper.Succeeded(hr))

                throw GetPortableDeviceExceptionForHR(hr);
        }
    }
}
