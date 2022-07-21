//Copyright (c) Pierre Sprimont.  All rights reserved.

using Microsoft.WindowsAPICodePack.PortableDevices;
using Microsoft.WindowsAPICodePack.Win32Native;

using System.Collections.Generic;
using System.Runtime.InteropServices;

using WinCopies.Collections
#if WAPICP3
    .Generic;

using static WinCopies.ThrowHelper;
#else
            ;

using static WinCopies.Util.Util;
#endif

namespace Microsoft.WindowsAPICodePack.COMNative.PortableDevices
{
    public static class PortableDeviceHelper
    {
        public delegate T GetPortableDeviceObject<T>(in string id);

#if CS7
        public static
#if WAPICP3
            EnumerableHelper<T>.IEnumerableLinkedList
#else
            IList<T> 
#endif
            GetItems<T>(in IPortableDeviceContent portableDeviceContent, in string id, in GetPortableDeviceObject<T> getPortableDeviceObjectDelegate)
        {
            ThrowIfNull(portableDeviceContent, nameof(portableDeviceContent));
            ThrowIfNullEmptyOrWhiteSpace(id);
            ThrowIfNull(getPortableDeviceObjectDelegate, nameof(getPortableDeviceObjectDelegate));

            HResult hr = portableDeviceContent.EnumObjects(0, id, null, out IEnumPortableDeviceObjectIDs enumPortableDeviceObjectIDs);

            if (CoreErrorHelper.Succeeded(hr))
            {
                var items =
#if WAPICP3
                    WinCopies.Collections.Generic.EnumerableHelper<T>.GetEnumerableLinkedList();
#else
                    new ArrayBuilder<T>();
#endif

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

#if !WAPICP3
                            _ =
#endif
                            items.AddLast(getPortableDeviceObjectDelegate(objectIDs[i]));
                    }

                    else ThrowWhenFailHResult(hr);

                } while (hr == HResult.Ok);

                return items
#if !WAPICP3
                    .ToList();
#else
                    ;
#endif
            }

            else

                throw GetPortableDeviceExceptionForHR(hr);
        }
#endif

        public static PortableDeviceException GetPortableDeviceExceptionForHR(HResult hr) => new PortableDeviceException("An operation has not succeeded, see the inner exception.", Marshal.GetExceptionForHR((int)hr));

        public static void ThrowWhenFailHResult(HResult hr)
        {
            if (!CoreErrorHelper.Succeeded(hr))

                throw GetPortableDeviceExceptionForHR(hr);
        }
    }
}
