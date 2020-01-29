using Microsoft.WindowsAPICodePack.Win32Native.Shell.PropertySystem;
using MS.WindowsAPICodePack.Win32Native.Shell.PropertySystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAPICodePack.Win32Native.PortableDevices;
using Microsoft.WindowsAPICodePack.Win32Native;
using Microsoft.WindowsAPICodePack.Win32Native.PortableDevices.PropertySystem;
using GuidAttribute = System.Runtime.InteropServices.GuidAttribute;

namespace Microsoft.WindowsAPICodePack.Win32Native.PortableDevices
{
    /// <summary>
    /// The <see cref="IPortableDeviceCapabilities"/> interface a variety of device capabilities, including supported formats, commands, and functional objects. You can retrieve this interface from a device by calling <see cref="IPortableDevice.Capabilities"/>.
    /// </summary>
    [ComImport,
        Guid(Win32Native.Guids.PortableDevices.IPortableDeviceCapabilities),
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IPortableDeviceCapabilities
    {
        /// <summary>
        /// The <see cref="GetSupportedCommands"/> method retrieves a list of all the supported commands for this device.
        /// </summary>
        /// <param name="ppCommands">Reference to an <see cref="IPortableDeviceKeyCollection"/> interface that holds all the valid commands. For a list of commands that are defined by Windows Portable Devices, see <a href="https://docs.microsoft.com/en-us/windows/win32/wpd_sdk/commands">Commands</a>. The caller must release this interface when it is done with it.</param>
        /// <returns><para>The method returns an <see cref="HResult"/>. Possible values include, but are not limited to, those in the following list.</para>
        /// <para><ul><li><see cref="HResult.Ok"/></li></ul></para></returns>
        [PreserveSig]
        HResult GetSupportedCommands(
            [Out, MarshalAs(UnmanagedType.Interface)] out IPortableDeviceKeyCollection ppCommands);

        /// <summary>
        /// The <see cref="GetCommandOptions"/> method retrieves all the supported options for the specified command on the device.
        /// </summary>
        /// <param name="Command">A <see cref="PropertyKey"/> that specifies a command to query for supported options. For a list of the commands that are defined by Windows Portable Devices, see <a href="https://docs.microsoft.com/en-us/windows/win32/wpd_sdk/commands">Commands</a>.</param>
        /// <param name="ppOptions">Address of a variable that receives a pointer to an <see cref="IPortableDeviceValues"/> interface that contains the supported options. If no options are supported, this will not contain any values. The caller must release this interface when it is done with it. For more information, see Remarks.</param>
        /// <returns><para>The method returns an HResult. Possible values include, but are not limited to, those in the following list.</para>
        /// <para><ul><li><see cref="HResult.Ok"/></li></ul></para></returns>
        /// <remarks><para>This method is called by applications that want to call a command directly on the driver by calling <see cref="IPortableDevice.SendCommand"/>. Some commands allow the caller to specify additional options. For example, some drivers support recursive child deletion when deleting an object using the WPD_COMMAND_OBJECT_MANAGEMENT_DELETE_OBJECTS command.</para>
        /// <para>If an option is a simple <see cref="bool"/> value, the key of the retrieved <see cref="IPortableDeviceValues"/> interface will be the name of the option, and the <see cref="PropVariant"/> value will be a <see cref="bool"/> value of <see langword="true"/> or <see langword="false"/>. If an option has several values, the retrieved <see cref="PropVariant"/> value will be a collection type that holds the supported values.</para>
        /// <para>If this method is called for the WPD_COMMAND_STORAGE_FORMAT command and the ppOptions parameter is set to WPD_OPTION_VALID_OBJECT_IDS, the driver will return an IPortableDevicePropVariant collection of type <see cref="string"/> that specifies the identifiers for each object on the device that can be formatted. (If this option does not exist, the format command is available for all objects.)</para></remarks>
        [PreserveSig]
        HResult GetCommandOptions(
            [In] ref PropertyKey Command,
            [Out, MarshalAs(UnmanagedType.Interface)] out IPortableDeviceValues ppOptions);

        /// <summary>
        /// The <see cref="GetFunctionalCategories"/> method retrieves all functional categories supported by the device.
        /// </summary>
        /// <param name="ppCategories">Reference to an <see cref="IPortableDevicePropVariantCollection"/> interface that holds all the functional categories for this device. The values will be <see cref="Guid"/>s of type VT_CLSID in the retrieved <see cref="PropVariant"/> values. The caller must release this interface when it is done with it.</param>
        /// <returns><para>The method returns an HResult. Possible values include, but are not limited to, those in the following list.</para>
        /// <para><ul><li><see cref="HResult.Ok"/></li></ul></para></returns>
        /// <remarks><para>Functional categories describe the types of functions that a device can perform, such as image capture, audio capture, and storage. This method is typically very fast, because the driver usually queries the device only on startup and caches the results.</para>
        /// <para>For an example of how to use this method see <a href="https://docs.microsoft.com/en-us/windows/win32/wpd_sdk/retrieving-the-functional-categories-supported-by-a-device">Retrieving the Functional Categories Supported by a Device</a>.</para></remarks>
        [PreserveSig]
        HResult GetFunctionalCategories(
            [Out, MarshalAs(UnmanagedType.Interface)] out IPortableDevicePropVariantCollection ppCategories);

        /// <summary>
        /// The <see cref="GetFunctionalObjects"/> method retrieves all functional objects that match a specified category on the device.
        /// </summary>
        /// <param name="Category">A reference to a <see cref="Guid"/> that specifies the category to search for. This can be WPD_FUNCTIONAL_CATEGORY_ALL to return all functional objects.</param>
        /// <param name="ppObjectIDs">A reference to an <see cref="IPortableDevicePropVariantCollection"/> interface that contains the object IDs of the functional objects as strings (type <see cref="string"/> in the retrieved <see cref="PropVariant"/> items). If no objects of the requested type are found, this will be an empty collection (not <see langword="null"/>). The caller must release this interface when it is done with it.</param>
        /// <returns><para>The method returns an HResult. Possible values include, but are not limited to, those in the following list.</para>
        /// <para><ul><li><see cref="HResult.Ok"/></li></ul></para></returns>
        /// <remarks><para>This operation is usually fast, because the driver does not need to perform a full content enumeration, and the number of retrieved functional objects is typically less than 10. If no objects of the requested type are found, this method will not return an error, but returns an empty collection for <paramref name="ppObjectIDs"/>.</para>
        /// <para>For an example of how to use this method, see <a href="https://docs.microsoft.com/en-us/windows/win32/wpd_sdk/retrieving-the-functional-object-identifiers-for-a-device">Retrieving the Functional Object Identifiers for a Device</a></para></remarks>
        [PreserveSig]
        HResult GetFunctionalObjects(
            [In] ref Guid Category,
            [Out, MarshalAs(UnmanagedType.Interface)] out IPortableDevicePropVariantCollection ppObjectIDs);

        /// <summary>
        /// The <see cref="GetSupportedContentTypes"/> method retrieves all supported content types for a specified functional object type on a device.
        /// </summary>
        /// <param name="Category">A reference to a <see cref="Guid"/> that specifies a functional object category. To get a list of functional categories on the device, call <see cref="GetFunctionalCategories"/>.</param>
        /// <param name="ppContentTypes">Reference to an <see cref="IPortableDevicePropVariantCollection"/> interface that lists all the supported object types for the specified functional object category. These object types will be <see cref="Guid"/> values of type VT_CLSID in the retrieved <see cref="PropVariant"/> items. See <a href="https://docs.microsoft.com/en-us/windows/win32/wpd_sdk/requirements-for-objects">Requirements for Objects</a> for a list of object types defined by Windows Portable Devices. The caller must release this interface when it is done with it.</param>
        /// <returns><para>The method returns an HResult. Possible values include, but are not limited to, those in the following list.</para>
        /// <para><ul><li><see cref="HResult.Ok"/></li></ul></para></returns>
        [PreserveSig]
        HResult GetSupportedContentTypes(
            [In] ref Guid Category,
            [Out, MarshalAs(UnmanagedType.Interface)] out IPortableDevicePropVariantCollection ppContentTypes);

        [PreserveSig]
        HResult GetSupportedFormats(
            [In] ref Guid ContentType,
            [Out] out IPortableDevicePropVariantCollection ppFormats);

        [PreserveSig]
        HResult GetSupportedFormatProperties(
            [In] ref Guid Format,
            [Out, MarshalAs(UnmanagedType.Interface)] out IPortableDeviceKeyCollection ppKeys);

        /// <summary>
        /// The <see cref="GetFixedPropertyAttributes"/> method retrieves the standard property attributes for a specified property and format. Standard attributes are those that have the same value for all objects of the same format. For example, one device might not allow users to modify video file names; this device would return WPD_PROPERTY_ATTRIBUTE_CAN_WRITE with a value of False for WMV formatted objects. Attributes that can have different values for a format, or optional attributes, are not returned.
        /// </summary>
        /// <param name="Format">A reference to a <see cref="Guid"/> that specifies the format of the objects of interest. For format <see cref="Guid"/> values, see <a href="https://docs.microsoft.com/en-us/windows/win32/wpd_sdk/object-format-guids">Object Formats</a>.</param>
        /// <param name="Key">A reference to a <see cref="PropertyKey"/> that specifies the property that you want to know the attributes of. Properties defined by Windows Portable Devices are listed in <a href="https://docs.microsoft.com/en-us/windows/win32/wpd_sdk/properties-and-attributes">Properties and Attributes</a>.</param>
        /// <param name="ppAttributes">Reference to an <see cref="IPortableDeviceValues"/> interface that holds the attributes and their values. The caller must release this interface when it is done with it.</param>
        /// <returns><para>The method returns an HResult. Possible values include, but are not limited to, those in the following list.</para>
        /// <para><ul><li><see cref="HResult.Ok"/></li></ul></para></returns>
        /// <remarks><para>You can specify WPD_OBJECT_FORMAT_ALL for the Format parameter to retrieve the complete set of property attributes.</para>
        /// <para>Attributes describe properties. Example attributes are WPD_PROPERTY_ATTRIBUTE_CAN_READ and WPD_PROPERTY_ATTRIBUTE_CAN_WRITE. This method does not retrieve resource attributes.</para></remarks>
        [PreserveSig]
        HResult GetFixedPropertyAttributes(
            [In] ref Guid Format,
            [In] ref PropertyKey Key,
            [Out, MarshalAs(UnmanagedType.Interface)] out IPortableDeviceValues ppAttributes);

        /// <summary>
        /// The <see cref="Cancel"/> method cancels a pending request on this interface.
        /// </summary>
        /// <returns><para>The method returns an HResult. Possible values include, but are not limited to, those in the following list.</para></returns>
        /// <remarks>This method cancels all pending operations on the current device handle, which corresponds to a session associated with an <see cref="IPortableDevice"/> interface. The Windows Portable Devices (WPD) API does not support targeted cancellation of specific operations.</remarks>
        [PreserveSig]
        HResult Cancel();

        [PreserveSig]
        HResult GetSupportedEvents(
            [Out, MarshalAs(UnmanagedType.Interface)] out IPortableDevicePropVariantCollection ppEvents);

        /// <summary>
        /// The <see cref="GetEventOptions"/> method retrieves all the supported options for the specified event on the device.
        /// </summary>
        /// <param name="Event">A reference to a <see cref="Guid"/> that specifies a event to query for supported options. For a list of the events that are defined by Windows Portable Devices, see <a href="https://docs.microsoft.com/en-us/windows/win32/wpd_sdk/commands">Events</a>.</param>
        /// <param name="ppOptions">Address of a variable that receives a pointer to an <see cref="IPortableDeviceValues"/> interface that contains the supported options. If no options are supported, this will not contain any values. The caller must release this interface when it is done with it.</param>
        /// <returns><para>The method returns an HResult. Possible values include, but are not limited to, those in the following list.</para>
        /// <para><ul><li><see cref="HResult.Ok"/></li>
        /// <li><see cref="HResult.Pointer"/></li></ul></para></returns>
        [PreserveSig]
        HResult GetEventOptions(
            [In] ref Guid Event,
            [Out, MarshalAs(UnmanagedType.Interface)] out IPortableDeviceValues ppOptions);
    }
}
