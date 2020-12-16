//Copyright (c) Pierre Sprimont.  All rights reserved.

using Microsoft.WindowsAPICodePack.COMNative.PortableDevices.PropertySystem;
using Microsoft.WindowsAPICodePack.PropertySystem;
using Microsoft.WindowsAPICodePack.Win32Native;
using Microsoft.WindowsAPICodePack.Win32Native.Storage;

using System;
using System.Runtime.InteropServices;

using GuidAttribute = System.Runtime.InteropServices.GuidAttribute;

namespace Microsoft.WindowsAPICodePack.COMNative.PortableDevices.ResourceSystem
{
    [ComImport,
        Guid(NativeAPI.Guids.PortableDevices.IPortableDeviceResources),
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IPortableDeviceResources
    {
        [PreserveSig]
        HResult GetSupportedResources(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pszObjectID,
            [Out, MarshalAs(UnmanagedType.Interface)] out IPortableDeviceKeyCollection ppKeys);

        [PreserveSig]
        HResult GetResourceAttributes(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pszObjectID,
            [In] ref PropertyKey Key,
            [Out, MarshalAs(UnmanagedType.Interface)] out IPortableDeviceValues ppResourceAttributes);

        /// <summary>
        /// The <see cref="GetStream"/> method gets an IStream interface with which to read or write the content data in an object on a device. The retrieved interface enables you to read from or write to the object data.
        /// </summary>
        /// <param name="pszObjectID">Pointer to a null-terminated string that contains the object ID of the object.</param>
        /// <param name="Key">A <see cref="PropertyKey"/> that specifies which resource to read. You can retrieve the keys of all the object's resources by calling <see cref="GetSupportedResources"/>.</param>
        /// <param name="dwMode">One of the value of the <see cref="STGM.Access"/> enum.</param>
        /// <param name="pdwOptimalBufferSize">An optional reference to a <see cref="uint"/> that specifies an estimate of the best buffer size to use when reading or writing data by using ppStream. A driver is required to support this value.</param>
        /// <param name="ppStream">An IStream interface. This interface is used to read and write data to the object. The caller must release this interface when it is done with it.</param>
        /// <returns></returns>
        [PreserveSig]
        HResult GetStream(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pszObjectID,
            [In] ref PropertyKey Key,
            [In] uint dwMode,
            [In, Out] ref uint pdwOptimalBufferSize,
            [Out, MarshalAs(UnmanagedType.Interface)] out System.Runtime.InteropServices.ComTypes.IStream ppStream);

        [PreserveSig]
        HResult Delete(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pszObjectID,
            [In, MarshalAs(UnmanagedType.Interface)] ref IPortableDeviceKeyCollection pKeys);

        [PreserveSig]
        HResult Cancel();

        [PreserveSig]
        HResult CreateResource(
            [In, MarshalAs(UnmanagedType.Interface)] ref IPortableDeviceValues pResourceAttributes,
            [Out, MarshalAs(UnmanagedType.Interface)] out System.Runtime.InteropServices.ComTypes.IStream ppData,
            [In, Out] ref uint pdwOptimalWriteBufferSize,
            [In, Out, MarshalAs(UnmanagedType.LPWStr)] ref string ppszCookie);
    }
}
