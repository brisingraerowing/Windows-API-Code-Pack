using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAPICodePack.Win32Native.Core;

// todo: for portable and media devices: implement interfaces for service providers

namespace Microsoft.WindowsAPICodePack.Win32Native.PortableDevices
{
    /// <summary>
    /// <para>The <see cref="IPortableDevice"/> interface provides access to a portable device.</para>
    /// <para>To create and open this interface, first call <see cref="CoCreateInstance"/> with <see cref="Win32Native.Guids.PortableDevices.PortableDeviceFTM"/> or <see cref="Win32Native.Guids.PortableDevices.PortableDevice"/> to retrieve an <see cref="IPortableDevice"/> interface, and then call <see cref="Open"/> to open a connection to the device.</para>
    /// </summary>
    /// <remarks><para>The client interfaces are designed to be used for any WPD object; it is not necessary to create a new instance for each object referenced by the application. After an application opens an instance of the <see cref="IPortableDevice"/> interface, it should open and cache any other WPD client interfaces that it will require.</para>
    /// <para>For Windows 7, <see cref="IPortableDevice"/> supports two CLSIDs for <see cref="CoCreateInstance"/>. <see cref="Win32Native.Guids.PortableDevices.PortableDevice"/> returns an <see cref="IPortableDevice"/> pointer that does not aggregate the free-threaded marshaler; <see cref="Win32Native.Guids.PortableDevices.PortableDeviceFTM"/> is a new CLSID that returns an <see cref="IPortableDevice"/> pointer that aggregates the free-threaded marshaler.Both pointers support the same functionality otherwise.</para>
    /// <para>Applications that live in Single Threaded Apartments should use <see cref="Win32Native.Guids.PortableDevices.PortableDeviceFTM"/> as this eliminates the overhead of interface pointer marshaling. <see cref="Win32Native.Guids.PortableDevices.PortableDevice"/> is still supported for legacy applications.</para></remarks>
    [ComImport(),
        Guid(Win32Native.Guids.PortableDevices.IPortableDevice),
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IPortableDevice
    {
        /// <summary>
        /// The <see cref="Open"/> method opens a connection between the application and the device.
        /// </summary>
        /// <param name="pszPnPDeviceID">A reference to a null-terminated string that contains the Plug and Play ID string for the device. You can get this string by calling <see cref="IPortableDeviceManager.GetDevices"/>.</param>
        /// <param name="pClientInfo"><para>A reference to an <see cref="IPortableDeviceValues"/> interface that holds information that identifies the application to the device. This interface holds PROPERTYKEY/value pairs that try to identify an application uniquely. Although the presence of a CoCreated interface is required, the application is not required to send any key/value pairs. However, sending data might improve performance. Typical key/value pairs include the application name, major and minor version, and build number.</para>
        /// <para>See properties beginning with "WPD_CLIENT_" in the <a href="https://docs.microsoft.com/en-us/windows/win32/wpd_sdk/properties-and-attributes">Properties</a> section.</para></param>
        /// <returns><para>The method returns an <see cref="HResult"/>. Possible values include, but are not limited to, those in the following list.</para>
        /// <para><ul><li><see cref="HResult.Ok"/></li>
        /// <li><see cref="HResult.DeviceAlreadyOpened"/></li>
        /// <li><see cref="HResult.Pointer"/></li></ul></para></returns>
        /// <remarks><para>A device must be opened before you can call any methods on it. (Note that the <see cref="IPortableDeviceManager"/> methods do not require you to open a device before calling any methods.) However, usually you do not need to call <see cref="Close"/>.</para>
        /// <para>Administrators can restrict the access of portable devices to computers running on a network.For example, an administrator may restrict all Guest users to read-only access, while Authenticated users are given read/write access.</para>
        /// <para>Due to these security issues, if your application will not perform write operations, it should call the <see cref="Open"/> method and request read-only access by specifying GENERIC_READ for the WPD_CLIENT_DESIRED_ACCESS property that it supplies in the pClientInfo parameter.</para>
        /// <para>If your application requires write operations, it should call the <see cref="Open"/> method as shown in the following example code. The first time, it should request read/write access by passing the default WPD_CLIENT_DESIRED_ACCESS property in the pClientInfo parameter.If this first call fails and returns E_ACCESSDENIED, your application should call the <see cref="Open"/> method a second time and request read-only access by specifying GENERIC_READ for the WPD_CLIENT_DESIRED_ACCESS property that it supplies in the pClientInfo parameter.</para>
        /// <para>Applications that live in Single Threaded Apartments should use <see cref="Win32Native.Guids.PortableDevices.PortableDeviceFTM"/>, as this eliminates the overhead of interface pointer marshaling. <see cref="Win32Native.Guids.PortableDevices.PortableDevice"/> is still supported for legacy applications.</para></remarks>
        /// <example>
        /// <code>
        /// const string CLIENT_NAME = "My WPD Application";
        /// const string CLIENT_MAJOR_VER = 1;
        /// const string CLIENT_MINOR_VER = 0;
        /// const string CLIENT_REVISION = 0;
        /// 
        /// HResult OpenDevice(string wszPnPDeviceID, ref IPortableDevice ppDevice)
        /// {
        ///     HResult hr = HResult.Ok;
        ///     IPortableDeviceValues pClientInformation = null;
        ///     IPortableDevice pDevice = null;
        ///     
        ///     if ((wszPnPDeviceID == null) || (ppDevice == null))
        ///     {
        ///         hr = HResult.InvalidArgument;
        ///         return hr;
        ///     }
        ///     
        ///     // CoCreate an IPortableDeviceValues interface to hold the client information.
        ///     hr = CoCreateInstance(Win32Native.Guids.PortableDevices.PortableDeviceValues,
        ///                           null,
        ///                           CLSCTX_INPROC_SERVER,
        ///                           Win32Native.Guids.PortableDevices.IPortableDeviceValues,
        ///                           ref pClientInformation);
        ///     if (CoreErrorHelper.Succeeded(hr))
        ///     {
        ///         HResult ClientInfoHR = HResult.Ok;
        /// 
        ///         // Attempt to set all properties for client information. If we fail to set
        ///         // any of the properties below it is OK. Failing to set a property in the
        ///         // client information isn't a fatal error.
        ///         ClientInfoHR = pClientInformation.SetStringValue(WPD_CLIENT_NAME, CLIENT_NAME);
        ///         if (CoreErrorHelper.Failed(ClientInfoHR))
        ///         {
        ///             // Failed to set WPD_CLIENT_NAME
        ///         }
        /// 
        ///         ClientInfoHR = pClientInformation.SetUnsignedIntegerValue(WPD_CLIENT_MAJOR_VERSION, CLIENT_MAJOR_VER);
        ///         if (CoreErrorHelper.Failed(ClientInfoHR))
        ///         {
        ///             // Failed to set WPD_CLIENT_MAJOR_VERSION
        ///         }
        /// 
        ///         ClientInfoHR = pClientInformation.SetUnsignedIntegerValue(WPD_CLIENT_MINOR_VERSION, CLIENT_MINOR_VER);
        ///         if (CoreErrorHelper.Failed(ClientInfoHR))
        ///         {
        ///             // Failed to set WPD_CLIENT_MINOR_VERSION
        ///         }
        /// 
        ///         ClientInfoHR = pClientInformation.SetUnsignedIntegerValue(WPD_CLIENT_REVISION, CLIENT_REVISION);
        ///         if (CoreErrorHelper.Failed(ClientInfoHR))
        ///         {
        ///             // Failed to set WPD_CLIENT_REVISION
        ///         }
        ///     }
        ///     else
        ///     {
        ///         // Failed to CoCreateInstance Win32Native.Guids.PortableDevices.PortableDeviceValues for client information
        ///     }
        /// 
        ///     ClientInfoHR = pClientInformation.SetUnsignedIntegerValue(WPD_CLIENT_SECURITY_QUALITY_OF_SERVICE, SECURITY_IMPERSONATION);
        ///     if (CoreErrorHelper.Failed(ClientInfoHR))
        ///     {
        ///         // Failed to set WPD_CLIENT_SECURITY_QUALITY_OF_SERVICE
        ///     }
        /// 
        ///     if (CoreErrorHelper.Succeeded(hr))
        ///     {
        ///         // CoCreate an IPortableDevice interface
        ///         hr = CoCreateInstance(Win32Native.Guids.PortableDevices.PortableDeviceFTM,
        ///                               null,
        ///                               CLSCTX_INPROC_SERVER,
        ///                               Win32Native.Guids.PortableDevices.IPortableDevice,
        ///                               ref pDevice);
        /// 
        ///         if (CoreErrorHelper.Succeeded(hr))
        ///         {
        ///             // Attempt to open the device using the PnPDeviceID string given
        ///             // to this function and the newly created client information.
        ///             // Note that we're attempting to open the device the first 
        ///             // time using the default (read/write) access. If this fails
        ///             // with HResult.AccessDenied, we'll attempt to open a second time
        ///             // with read-only access.
        ///             hr = pDevice.Open(wszPnPDeviceID, pClientInformation);
        ///             if (hr == HResult.AccessDenied)
        ///             {
        ///                 // Attempt to open for read-only access
        ///                 pClientInformation.SetUnsignedIntegerValue(
        ///                                                            WPD_CLIENT_DESIRED_ACCESS,
        ///                                                            GENERIC_READ);
        ///                 hr = pDevice.Open(wszPnPDeviceID, pClientInformation);
        ///             }
        ///             if (CoreErrorHelper.Succeeded(hr))
        ///             {
        ///                 // The device successfully opened, obtain an instance of the Device into
        ///                 // ppDevice so the caller can be returned an opened IPortableDevice.
        ///                 hr = pDevice.QueryInterface(Win32Native.Guids.PortableDevices.IPortableDevice, ref ppDevice);
        ///                 if (CoreErrorHelper.Failed(hr))
        ///                 {
        ///                     // Failed to QueryInterface the opened IPortableDevice
        ///                 }
        ///             }
        ///         }
        ///         else
        ///         {
        ///             // Failed to CoCreateInstance Win32Native.Guids.PortableDevices.PortableDevice
        ///         }
        ///     }
        /// 
        ///     // Release the IPortableDevice when finished
        ///     if (pDevice != null)
        ///     {
        ///         pDevice.Release();
        ///         Marshal.ReleaseCOMObject(pDevice);
        ///     }
        /// 
        ///     // Release the IPortableDeviceValues that contains the client information when finished
        ///     if (pClientInformation != null)
        ///     {
        ///         pClientInformation.Release();
        ///         Marshal.ReleaseCOMObject(pClientInformation);
        ///     }
        /// 
        ///     return hr;
        /// }</code>
        /// </example>
        HResult Open(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pszPnPDeviceID,
            [In, MarshalAs(UnmanagedType.Interface)] ref IPortableDeviceValues pClientInfo);

        /// <summary>
        /// The <see cref="SendCommand"/> method sends a command to the device and retrieves the results synchronously.
        /// </summary>
        /// <param name="dwFlags">Currently not used; specify zero.</param>
        /// <param name="pParameters"><para>Reference to an <see cref="IPortableDeviceValues"/> interface that specifies the command and parameters to call on the device. This interface must include the following two values to indicate the command. Additional parameters vary depending on the command. For a list of the parameters that are required for each command, see <a href="https://docs.microsoft.com/en-us/windows/win32/wpd_sdk/commands">Commands</a>.</para>
        /// <para>WPD_PROPERTY_COMMON_COMMAND_CATEGORY</para>
        /// <para>WPD_PROPERTY_COMMON_COMMAND_ID</para></param>
        /// <param name="ppResults">Address of a variable that receives a pointer to an <see cref="IPortableDeviceValues"/> interface that indicates the results of the command results, including success or failure, and any command values returned by the device. The caller must release this interface when it is done with it. The retrieved values vary by command; see the appropriate command documentation in <a href="https://docs.microsoft.com/en-us/windows/win32/wpd_sdk/commands">Commands</a> to learn what values are returned by each command call.</param>
        /// <returns><para>The returned value indicates success or failure to send a command and return a result from the driver; it does not indicate whether the driver supports the command or if it encountered some error in processing the command. (For more information, see Remarks.) These errors are returned in the <see cref="HResult"/> values of the <paramref name="ppResults"/> parameter. The possible <see cref="HResult"/> values returned by this method include, but are not limited to, those in the following list.</para>
        /// <para><ul><li><see cref="HResult.Ok"/></li>
        /// <li><see cref="HResult.Pointer"/></li></ul></para></returns>
        /// <remarks>TODO</remarks>
        /// <example><code>TODO</code></example>
        HResult SendCommand(
            [In] uint dwFlags,
            [In, MarshalAs(UnmanagedType.Interface)] ref IPortableDeviceValues pParameters,
            [Out, MarshalAs(UnmanagedType.Interface)] out IPortableDeviceValues ppResults);

        /// <summary>
        /// The <see cref="Content"/> method retrieves an interface that you can use to access objects on a device.
        /// </summary>
        /// <param name="ppContent">Address of a variable that receives a pointer to an <see cref="IPortableDeviceContent"/> interface that is used to access the content on a device. The caller must release this interface when it is done with it.</param>
        /// <returns><para>The method returns an <see cref="HResult"/>. Possible values include, but are not limited to, those in the following list.</para>
        /// <para><ul><li><see cref="HResult.OK"/></li>
        /// <li><see cref="HResult.Pointer"/></li></ul></para></returns>
        HResult Content(
            [Out, MarshalAs(UnmanagedType.Interface)] out IPortableDeviceContent ppContent);

        /// <summary>
        /// The <see cref="Capabilities"/> method retrieves an interface used to query the capabilities of a portable device.
        /// </summary>
        /// <param name="ppCapabilities">A variable that receives a reference to an <see cref="IPortableDeviceCapabilities"/> interface that can describe the device's capabilities. The caller must release this interface when it is done with it.</param>
        /// <returns><para>The method returns an <see cref="HResult"/>. Possible values include, but are not limited to, those in the following list.</para>
        /// <para><ul><li><see cref="HResult.OK"/></li>
        /// <li><see cref="HResult.Pointer"/></li></ul></para></returns>
        HResult Capabilities(
            [Out, MarshalAs(UnmanagedType.Interface)] out IPortableDeviceCapabilities ppCapabilities);

        /// <summary>
        /// The <see cref="Cancel"/> method cancels a pending operation on this interface.
        /// </summary>
        /// <returns><para>The method returns an <see cref="HResult"/>. Possible values include, but are not limited to, those in the following list.</para>
        /// <para><ul><li><see cref="HResult.Ok"/></li></ul></para></returns>
        /// <remarks><para>If your application invokes the WPD API from multiple threads, each thread should create a new instance of the <see cref="IPortableDevice"/> interface. Doing this ensures that any cancel operation affects only the I/O for the affected thread.</para>
        /// <para>If an <see cref="System.Runtime.InteropServices.ComTypes.IStream"/> write operation is underway when the <see cref="Cancel"/> method is invoked, your application should discard all changes by invoking the <see cref="System.Runtime.InteropServices.ComTypes.IStream.Revert"/> method. Once the changes are discarded, the application should also close the stream by invoking the IUnknown.Release method.</para>
        /// <para>Also, note that if the <see cref="Cancel"/> method is invoked before an <see cref="System.Runtime.InteropServices.ComTypes.IStream.Write"/> method has completed, the data being written may be corrupted.</para></remarks>
        HResult Cancel();

        /// <summary>
        /// The <see cref="Close"/> method closes the connection with the device.
        /// </summary>
        /// <returns><para>The method returns an <see cref="HResult"/>. Possible values include, but are not limited to, those in the following list.</para>
        /// <para><ul><li><see cref="HResult.Ok"/></li></ul></para></returns>
        /// <remarks>You should not usually need to call this method yourself. When the last reference to the <see cref="IPortableDevice"/> interface is released, Windows Portable Devices calls <see cref="Close"/> for you. Calling this method manually forces the connection to the device to close, and any Windows Portable Devices objects hosted on this device will cease to function. You can call <see cref="Open"/> to reopen the connection.</remarks>
        HResult Close();

        /// <summary>
        /// The <see cref="Advise"/> method registers an application-defined callback that receives device events.
        /// </summary>
        /// <param name="dwFlags"><see cref="uint"/> that specifies option flags.</param>
        /// <param name="pCallback">Reference to a callback object.</param>
        /// <param name="pParameters">This parameter is ignored and should be set to <see langword="null"/>.</param>
        /// <param name="ppszCookie">A string that represents a unique context ID. This is used to unregister for callbacks when calling <see cref="Unadvise"/>.</param>
        /// <returns><para>The method returns an <see cref="HResult"/>. Possible values include, but are not limited to, those in the following list.</para>
        /// <para><ul><li><see cref="HResult.Ok"/></li></ul></para></returns>
        HResult Advise(
            [In] uint dwFlags,
            [In, MarshalAs(UnmanagedType.Interface)] ref IPortableDeviceEventCallback pCallback,
            [In, MarshalAs(UnmanagedType.Interface)] ref IPortableDeviceValues pParameters,
            [Out, MarshalAs(UnmanagedType.LPWStr)] out string ppszCookie);

        /// <summary>
        /// The <see cref="Unadvise"/> method unregisters a client from receiving callback notifications. You must call this method if you called <see cref="Advise"/> previously.
        /// </summary>
        /// <param name="pszCookie">Reference to a null-terminated string that is a unique context ID. This was retrieved in the initial call to <see cref="Advise"/>.</param>
        /// <returns><para>The method returns an <see cref="HResult"/>. Possible values include, but are not limited to, those in the following list.</para>
        /// <para><ul><li><see cref="HResult.Ok"/></li></ul></para></returns>
        HResult Unadvise(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pszCookie);

        /// <summary>
        /// The <see cref="GetPnPDeviceID"/> method retrieves the Plug and Play (PnP) device identifier that the application used to open the device.
        /// </summary>
        /// <param name="ppszPnPDeviceID">Reference to a null-terminated string that contains the Plug and Play ID string for the device.</param>
        /// <returns><para>The method returns an <see cref="HResult"/>. Possible values include, but are not limited to, those in the following list.</para>
        /// <para><ul><li><see cref="HResult.Ok"/></li>
        /// <li><see cref="HResult.DeviceNotOpen"/></li></ul></para></returns>
        /// <remarks><para>After the application is through using the string returned by this method, it must call the <see cref="CoTaskMemFree"/> function to free the string.</para>
        /// <para>The <paramref name="ppszPnPDeviceID"/> argument must not be set to <see langword="null"/>.</para></remarks>
        HResult GetPnPDeviceID(
            [Out, MarshalAs(UnmanagedType.LPWStr)] out string ppszPnPDeviceID);
    }
}
