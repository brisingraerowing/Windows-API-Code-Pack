using System;
using System.Runtime.InteropServices;
using Microsoft.WindowsAPICodePack.Win32Native.Core;
using Microsoft.WindowsAPICodePack.Win32Native.PortableDevices;
using Microsoft.WindowsAPICodePack.Win32Native.PortableDevices.ClientInterfaces;

namespace Microsoft.WindowsAPICodePack.Win32Native.PortableDevices
{
    /// <summary>
    /// The <see cref="IEnumPortableDeviceObjectIDs"/> interface enumerates the objects on a portable device. Get this interface initially by calling <see cref="IPortableDeviceContent.EnumObjects"/> on a device.
    /// </summary>
    [ComImport(),
        Guid(Win32Native.Guids.PortableDevices.IEnumPortableDeviceObjectID),
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IEnumPortableDeviceObjectIDs
    {
        /// <summary>
        /// The <see cref="Next"/> method retrieves the next one or more object IDs in the enumeration sequence.
        /// </summary>
        /// <param name="cObjects">A count of the objects requested.</param>
        /// <param name="pObjIDs">An array of <see cref="string"/>s, each specifying a retrieved object ID. The caller must allocate an array of <paramref name="cObjects"/> <see cref="string"/> elements. The caller must free both the array and the returned strings. The strings are freed by calling <see cref="CoTaskMemFree"/>.</param>
        /// <param name="pcFetched">On input, this parameter is ignored. On output, the number of IDs actually retrieved. If no object IDs are released and the return value is <see cref="HResult.False"/>, there are no more objects to enumerate.</param>
        /// <returns><para>The method returns an <see cref="HResult"/>. Possible values include, but are not limited to, those in the following list.</para>
        /// <para><ul><li><see cref="HResult.Ok"/></li><li><see cref="HResult.False"/></li></ul></para></returns>
        /// <remarks>If fewer than the requested number of elements remain in the sequence, this method retrieves the remaining elements. The number of elements that are actually retrieved is returned through pcFetched (unless the caller passed in NULL for that parameter). Enumerated objects are all peers—that is, enumerating children of an object will enumerate only direct children, not grandchild or deeper objects.</remarks>
        HResult Next(
            [In] uint cObjects,
            [In, Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPWStr)] string[] pObjIDs,
            [Out] out uint pcFetched);

        /// <summary>
        /// The <see cref="Skip"/> method skips a specified number of objects in the enumeration sequence.
        /// </summary>
        /// <param name="cObjects">The number of objects to skip.</param>
        /// <returns><para>The method returns an <see cref="HResult"/>. Possible values include, but are not limited to, those in the following list.</para>
        /// <para><ul><li><see cref="HResult.Ok"/></li><li><see cref="HResult.False"/></li></ul></para></returns>
        HResult Skip(
            [In] uint cObjects);

        /// <summary>
        /// The <see cref="Reset"/> method resets the enumeration sequence to the beginning.
        /// </summary>
        /// <returns><para>The method returns an <see cref="HResult"/>. Possible values include, but are not limited to, those in the following list.</para>
        /// <para><ul><li><see cref="HResult.Ok"/></li></ul></para></returns>
        /// <remarks>There is no guarantee that the same objects will be enumerated after this method is called. This is because objects that were enumerated previously might have been deleted or new objects might have been added.</remarks>
        HResult Reset();

        /// <summary>
        /// <para>The <see cref="Clone"/> method duplicates the current <see cref="IEnumPortableDeviceObjectIDs"/> interface.</para>
        /// <para><b>Not implemented in this release.</b></para>
        /// </summary>
        /// <param name="ppEnum">Variable that receives a reference to an enumeration interface. The caller must release this interface when it is finished with the interface.</param>
        /// <returns><para>The method returns an <see cref="HResult"/>. Possible values include, but are not limited to, those in the following list.</para>
        /// <para><ul><li><see cref="HResult.NotImplemented"/></li></ul></para></returns>
        HResult Clone(
            [Out, MarshalAs(UnmanagedType.Interface)] out IEnumPortableDeviceObjectIDs ppEnum);

        /// <summary>
        /// The <see cref="Cancel"/> method cancels a pending operation.
        /// </summary>
        /// <returns><para>The method returns an <see cref="HResult"/>. Possible values include, but are not limited to, those in the following list.</para>
        /// <para><ul><li><see cref="HResult.Ok"/></li>
        /// <li><see cref="HResult.DeviceNotOpen"/></li></ul></para></returns>
        /// <remarks>This method cancels all pending operations on the current device handle, which corresponds to a session associated with an <see cref="IPortableDevice"/> interface. The Windows Portable Devices (WPD) API does not support targeted cancellation of specific operations.</remarks>
        HResult Cancel();
    }
}
