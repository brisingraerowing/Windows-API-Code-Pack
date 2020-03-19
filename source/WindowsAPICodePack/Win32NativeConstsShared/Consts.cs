using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.WindowsAPICodePack.Win32Native.PortableDevices
{
    public static class Consts
    {

        /****************************************************************************
         * This section declares WPD defines
         ****************************************************************************/

        /// <summary>
        /// WPD specific function number used to construct WPD I/O control codes. Drivers should not use this define directly.
        /// </summary>
        public const uint ControlFunctionGenericMessage = 0x42;

        /// <summary>
        /// Pre-defined ObjectID for the DEVICE object.
        /// </summary>
        public const string DeviceObjectId = "DEVICE";

        public static class PortableDevice

        {

            /// <summary>
            /// <para>Pre-defined name of a REG_DWORD value that defines the device type, used for representation purposes only. Functional characteristics of the device are decided through functional objects.</para>
            /// <para>This value can be retrieved using IPortableDeviceManager::GetDeviceProperty(...).  See WPD_DEVICE_TYPES enumeration for possible values.</para>
            /// </summary>
            public const string Type = "PortableDeviceType";

            /// <summary>
            /// <para>Pre-defined name of a REG_SZ/REG_EXPAND_SZ/REG_MULTI_SZ value that indicates the location of the device icon file or device icon resource.</para>
            /// <para>This value can be retrieved using IPortableDeviceManager::GetDeviceProperty(...).  This REG_SZ/REG_EXPAND_SZ/REG_MULTI_SZ value is either in the form "file.dll, resourceID" or a full file path to an icon file. e.g.: "x:\file.ico" </para>
            /// </summary>
            public const string Icon = "Icons";

            /// <summary>
            /// <para>Pre-defined name of a REG_DWORD value that indicates the amount of time in milliseconds the WPD Namespace Extension will keep its reference to the device open under idle conditions.</para>
            /// <para>This value can be retrieved using IPortableDeviceManager::GetDeviceProperty(...). </para>
            /// </summary>
            public const string NamespaceTimeout = "PortableDeviceNameSpaceTimeout";

            /// <summary>
            /// <para>Pre-defined name of a REG_DWORD value that is used as a flag to indicate whether the device should, or should not, be shown in the Explorer view.</para>
            /// <para>This value can be retrieved using IPortableDeviceManager::GetDeviceProperty(...).  Meaning of values are: 0 = include, 1 = exclude. 0 is assumed if this value doesn't exist.</para>
            /// </summary>
            public const string NamespaceExcludeFromShell = "PortableDeviceNameSpaceExcludeFromShell";

            /// <summary>
            /// <para>Pre-defined name of a REG_SZ or REG_MULTI_SZ value containing content type guids that are used indicate for what content types the portable device namespace should attempt to automatically generate a thumbnail when placing new content on the device.</para>
            /// <para>This value can be retrieved using IPortableDeviceManager::GetDeviceProperty(...).  Values should be a string representation of a GUID, in the form '{00000000-0000-0000-0000-000000000000}'. By default the portable device namespace attempts to automatically generate thumbnails for WPD_CONTENT_TYPE_IMAGE, if a device does not want this behavior it can set this value to an empty string.  </para>
            /// </summary>
            public const string NamespaceThumbnailContentTypes = "PortableDeviceNameSpaceThumbnailContentTypes";

            /// <summary>
            /// <para>Pre-defined name of a REG_DWORD value that indicates whether a Portable Device is a Mass Storage Class (MSC) device. This is used to avoid duplication of the device in certain views and scenarios that include both file system and Portable Devices.</para>
            /// <para>This value can be retrieved using IPortableDeviceManager::GetDeviceProperty(...).  Meaning of values are: 0 = device is not mass storage, 1 = device is mass storage. 0 is assumed if this value doesn't exist. </para>
            /// </summary>
            public const string IsMassStorage = "PortableDeviceIsMassStorage";

            /// <summary>
            /// <para>Pre-defined value identifying the "Windows Media Digital Rights Management 10 for Portable Devices" scheme for protecting content.</para>
            /// <para>This value can be used by drivers to indicate they support WMDRM10-PD.  See WPD_DEVICE_SUPPORTED_DRM_SCHEMES. </para>
            /// </summary>
            public const string DRMSchemeWMDRM10PD = "WMDRM10-PD";

            /// <summary>
            /// <para>Pre-defined value identifying the "Portable Device Digital Rights Management" scheme for protecting content.</para>
            /// <para>This value can be used by drivers to indicate they support PDDRM.  See WPD_DEVICE_SUPPORTED_DRM_SCHEMES. </para>
            /// </summary>
            public const string DRMSchemePDDRM = "PDDRM";

        }
    }
}

namespace Microsoft.WindowsAPICodePack.Win32Native.Controls.ExplorerBrowserViewDispatchIds
{

    public static class Consts
    {
        public const int SelectionChanged = 200;
        public const int ContentsChanged = 207;
        public const int FileListEnumDone = 201;
        public const int SelectedItemChanged = 220;
    }

}

namespace Microsoft.WindowsAPICodePack.Win32Native.Taskbar.Consts

{

    public static class Common

    {

        public const int WmCommand = 0x0111;

    }

    public static class TabbedThumbnail

    {

        public const uint WaActive = 1;
        public const uint WaClickActive = 2;

        public const int ScClose = 0xF060;
        public const int ScMaximize = 0xF030;
        public const int ScMinimize = 0xF020;

    }

}

namespace Microsoft.WindowsAPICodePack.Win32Native.MediaDevices
{
    public static class Consts
    {
        public const short WMDMID_LENGTH = 128;
    }
}

namespace Microsoft.WindowsAPICodePack.Win32Native.Shell.Consts

{

    public static class Common

    {

        public const int MaxPath = 260;

    }

    public static class DesktopWindowManager

    {

        public const int DisplayFrame = 0x00000001;

        public const int ForceIconicRepresentation = 7;
        public const int HasIconicBitmap = 10;

    }

    public static class CommandLinkDefinitions

    {

        public const int CommandLink = 0x0000000E;
        public const uint SetNote = 0x00001609;
        public const uint GetNote = 0x0000160A;
        public const uint GetNoteLength = 0x0000160B;
        public const uint SetShield = 0x0000160C;

    }

}
