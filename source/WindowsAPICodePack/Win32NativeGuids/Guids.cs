using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.WindowsAPICodePack.Win32Native.Guids

{

    public static class Sensors

    {

        public const string ISensor = "5FA08F80-2657-458E-AF75-46F73FA6AC5C";

    }

    public static class PortableDevices

    {

        public const string IEnumPortableDeviceObjectID = "10ece955-cf41-4728-bfa0-41eedf1bbf19";
        public const string IPortableDevice = "625e2df8-6392-4cf0-9ad1-3cfa5f17775c";
        public const string IPortableDeviceCapabilities = "2c8c6dbf-e3dc-4061-becc-8542e810d126";
        public const string IPortableDeviceContent = "6a96ed84-7c73-4480-9938-bf5af477d426";
        public const string IPortableDeviceContent2 = "9b4add96-f6bf-4034-8708-eca72bf10554";
        public const string IPortableDeviceDataStream = "88e04db3-1012-4d64-9996-f703a950d3f4";
        public const string IPortableDeviceEventCallback = "a8792a31-f385-493c-a893-40f64eb45f6e";
        public const string IPortableDeviceManager = "a1567595-4c2f-4574-a6fa-ecef917b9a40";
        public const string IPortableDeviceProperties = "7f6d695c-03df-4439-a809-59266beee3a6";
        public const string IPortableDevicePropertiesBulk = "482b05c0-4056-44ed-9e0f-5e23b009da93";
        public const string IPortableDevicePropertiesBulkCallback = "9deacb80-11e8-40e3-a9f3-f557986a7845";
        public const string IPortableDeviceResources = "fd8878ac-d841-4d17-891c-e6829cdb6934";
        public const string IPortableDeviceService = "d3bd3a44-d7b5-40a9-98b7-2fa4d01dec08";
        public const string IPortableDeviceServiceCapabilities = "24dbd89d-413e-43e0-bd5b-197f3c56c886";
        public const string IPortableDeviceUnitsStream = "5e98025f-bfc4-47a2-9a5f-bc900a507c67";
        public const string IPortableDeviceServiceMethods = "e20333c9-fd34-412d-a381-cc6f2d820df7";
        public const string IPortableDeviceServiceMethodCallback = "c424233c-afce-4828-a756-7ed7a2350083";
        public const string IPortableDeviceServiceManager = "a8abc4e9-a84a-47a9-80b3-c5d9b172a961";
        public const string IPortableDeviceKeyCollection = "dada2357-e0ad-492e-98db-dd61c53ba353";
        public const string IPortableDevicePropVariantCollection = "89b2e422-4f1b-4316-bcef-a44afea83eb3";
        public const string IPortableDeviceValues = "6848f6f2-3155-4f86-b6f5-263eeeab3143";
        public const string IPortableDeviceValuesCollection = "6e3f2d79-4e07-48c4-8208-d8c2e5af4a99";

        public const string IWpdSerializer = "b32f4002-bb27-45ff-af4f-06631c1e8dad";

        public const string PortableDeviceFTM = "f7c0039a-4762-488a-b4b3-760ef9a1ba9b";
        [Obsolete("This CLSID does not aggregates the free-threaded marshaler and is here for legacy reasons. Use the IPortableDeviceFTM constant instead.")]
        public const string PortableDevice = "728a21c5-3d9e-48d7-9810-864848f0f404";
        public const string PortableDeviceManager = "0af10cec-2ecd-4b92-9581-34f6ae0637f3";

        public static class Properties

        {

            /// <summary>
            /// This class defines all WPD Events.
            /// </summary>
            public static class Events

            {

                /// <summary>
                /// This GUID is used to identify all WPD driver events to the event sub-system. The driver uses this as the GUID identifier when it queues an event with IWdfDevice::PostEvent(). Applications never use this value.
                /// </summary>
                public const string Notification = "0x2BA2E40A-0x6B4C-0x4295-0xBB-0x43-0x26-0x32-0x2B-0x99-0xAE-0xB2";

                /// <summary>
                /// This event is sent after a new object is available on the device.
                /// </summary>
                public const string ObjectAdded = "0xA726DA95-0xE207-0x4B02-0x8D-0x44-0xBE-0xF2-0xE8-0x6C-0xBF-0xFC";

                /// <summary>
                /// This event is sent after a previously existing object has been removed from the device.
                /// </summary>
                public const string ObjectRemoved = "0xBE82AB88-0xA52C-0x4823-0x96-0xE5-0xD0-0x27-0x26-0x71-0xFC-0x38";

                /// <summary>
                /// This event is sent after an object has been updated such that any connected client should refresh its view of that object.
                /// </summary>
                public const string ObjectUpdated = "0x1445A759-0x2E01-0x485D-0x9F-0x27-0xFF-0x07-0xDA-0xE6-0x97-0xAB";

                /// <summary>
                /// This event indicates that the device is about to be reset-and all connected clients should close their connection to the device.
                /// </summary>
                public const string DeviceReset = "0x7755CF53-0xC1ED-0x44F3-0xB5-0xA2-0x45-0x1E-0x2C-0x37-0x6B-0x27";

                /// <summary>
                /// This event indicates that the device capabilities have changed. Clients should re-query the device if they have made any decisions based on device capabilities.
                /// </summary>
                public const string DeviceCapabilitiesUpdated = "0x36885AA1-0xCD54-0x4DAA-0xB3-0xD0-0xAF-0xB3-0xE0-0x3F-0x59-0x99";

                /// <summary>
                /// This event indicates the progress of a format operation on a storage object.
                /// </summary>
                public const string StorageFormat = "0x3782616B-0x22BC-0x4474-0xA2-0x51-0x30-0x70-0xF8-0xD3-0x88-0x57";

                /// <summary>
                /// This event is sent to request an application to transfer a particular object from the device.
                /// </summary>
                public const string ObjectTransferRequested = "0x8D16A0A1-0xF2C6-0x41DA-0x8F-0x19-0x5E-0x53-0x72-0x1A-0xDB-0xF2";

                /// <summary>
                /// This event is sent when a driver for a device is being unloaded. This is typically a result of the device being unplugged.
                /// </summary>
                public const string DeviceRemoved = "0xE4CBCA1B-0x6918-0x48B9-0x85-0xEE-0x02-0xBE-0x7C-0x85-0x0A-0xF9";

                /// <summary>
                /// This event is sent when a driver has completed invoking a service method. This event must be sent even when the method fails.
                /// </summary>
                public const string ServiceMethodComplete = "0x8A33F5F8-0x0ACC-0x4D9B-0x9C-0xC4-0x11-0x2D-0x35-0x3B-0x86-0xCA";

            }

            /// <summary>
            /// This class defines all WPD content types.
            /// </summary>
            public static class ContentType

            {

                /// <summary>
                /// <para>Name: WPD_CONTENT_TYPE_FUNCTIONAL_OBJECT</para>
                /// <para>Description: Indicates this object represents a functional object-not content data on the device.</para>
                /// </summary>
                public const string FunctionalObject = "0x99ED0160-0x17FF-0x4C44-0x9D-0x98-0x1D-0x7A-0x6F-0x94-0x19-0x21";

                /// <summary>
                /// <para>Name: WPD_CONTENT_TYPE_FOLDER</para>
                /// <para>Description: Indicates this object is a folder.</para>
                /// </summary>
                public const string Folder = "0x27E2E392-0xA111-0x48E0-0xAB-0x0C-0xE1-0x77-0x05-0xA0-0x5F-0x85";

                /// <summary>
                /// <para>Name: WPD_CONTENT_TYPE_IMAGE</para>
                /// <para>Description: Indicates this object represents image data (e.g. a JPEG file)</para>
                /// </summary>
                public const string Image = "0xef2107d5-0xa52a-0x4243-0xa2-0x6b-0x62-0xd4-0x17-0x6d-0x76-0x03";

                /// <summary>
                /// <para>Name: WPD_CONTENT_TYPE_DOCUMENT</para>
                /// <para>Description: Indicates this object represents document data (e.g. a MS WORD file-TEXT file-etc.)</para>
                /// </summary>
                public const string Document = "0x680ADF52-0x950A-0x4041-0x9B-0x41-0x65-0xE3-0x93-0x64-0x81-0x55";

                /// <summary>
                /// <para>Name: WPD_CONTENT_TYPE_CONTACT</para>
                /// <para>Description: Indicates this object represents contact data (e.g. name/number-or a VCARD file)</para>
                /// </summary>
                public const string Contact = "0xEABA8313-0x4525-0x4707-0x9F-0x0E-0x87-0xC6-0x80-0x8E-0x94-0x35";

                /// <summary>
                /// <para>Name: WPD_CONTENT_TYPE_CONTACT_GROUP</para>
                /// <para>Description: Indicates this object represents a group of contacts.</para>
                /// </summary>
                public const string ContactGroup = "0x346B8932-0x4C36-0x40D8-0x94-0x15-0x18-0x28-0x29-0x1F-0x9D-0xE9";

                /// <summary>
                /// <para>Name: WPD_CONTENT_TYPE_AUDIO</para>
                /// <para>Description: Indicates this object represents audio data (e.g. a WMA or MP3 file)</para>
                /// </summary>
                public const string Audio = "0x4AD2C85E-0x5E2D-0x45E5-0x88-0x64-0x4F-0x22-0x9E-0x3C-0x6C-0xF0";

                /// <summary>
                /// <para>Name: WPD_CONTENT_TYPE_VIDEO</para>
                /// <para>Description: Indicates this object represents video data (e.g. a WMV or AVI file)</para>
                /// </summary>
                public const string Video = "0x9261B03C-0x3D78-0x4519-0x85-0xE3-0x02-0xC5-0xE1-0xF5-0x0B-0xB9";

                /// <summary>
                /// <para>Name: WPD_CONTENT_TYPE_TELEVISION</para>
                /// <para>Description: Indicates this object represents a television recording.</para>
                /// </summary>
                public const string Television = "0x60A169CF-0xF2AE-0x4E21-0x93-0x75-0x96-0x77-0xF1-0x1C-0x1C-0x6E";

                /// <summary>
                /// <para>Name: WPD_CONTENT_TYPE_PLAYLIST</para>
                /// <para>Description: Indicates this object represents a playlist.</para>
                /// </summary>
                public const string Playlist = "0x1A33F7E4-0xAF13-0x48F5-0x99-0x4E-0x77-0x36-0x9D-0xFE-0x04-0xA3";

                /// <summary>
                /// <para>Name: WPD_CONTENT_TYPE_MIXED_CONTENT_ALBUM</para>
                /// <para>Description: Indicates this object represents an album-which may contain objects of different content types (typically-MUSIC-IMAGE and VIDEO).</para>
                /// </summary>
                public const string MixedContentAlbum = "0x00F0C3AC-0xA593-0x49AC-0x92-0x19-0x24-0xAB-0xCA-0x5A-0x25-0x63";

                /// <summary>
                /// <para>Name: WPD_CONTENT_TYPE_AUDIO_ALBUM</para>
                /// <para>Description: Indicates this object represents an audio album.</para>
                /// </summary>
                public const string AudioAlbum = "0xAA18737E-0x5009-0x48FA-0xAE-0x21-0x85-0xF2-0x43-0x83-0xB4-0xE6";

                /// <summary>
                /// <para>Name: WPD_CONTENT_TYPE_IMAGE_ALBUM</para>
                /// <para>Description: Indicates this object represents an image album.</para>
                /// </summary>
                public const string ImageAlbum = "0x75793148-0x15F5-0x4A30-0xA8-0x13-0x54-0xED-0x8A-0x37-0xE2-0x26";

                /// <summary>
                /// <para>Name: WPD_CONTENT_TYPE_VIDEO_ALBUM</para>
                /// <para>Description: Indicates this object represents a video album.</para>
                /// </summary>
                public const string VideoAlbum = "0x012B0DB7-0xD4C1-0x45D6-0xB0-0x81-0x94-0xB8-0x77-0x79-0x61-0x4F";

                /// <summary>
                /// <para>Name: WPD_CONTENT_TYPE_MEMO</para>
                /// <para>Description: Indicates this object represents memo data</para>
                /// </summary>
                public const string Memo = "0x9CD20ECF-0x3B50-0x414F-0xA6-0x41-0xE4-0x73-0xFF-0xE4-0x57-0x51";

                /// <summary>
                /// <para>Name: WPD_CONTENT_TYPE_EMAIL</para>
                /// <para>Description: Indicates this object represents e-mail data</para>
                /// </summary>
                public const string Email = "0x8038044A-0x7E51-0x4F8F-0x88-0x3D-0x1D-0x06-0x23-0xD1-0x45-0x33";

                /// <summary>
                /// <para>Name: WPD_CONTENT_TYPE_APPOINTMENT</para>
                /// <para>Description: Indicates this object represents an appointment in a calendar</para>
                /// </summary>
                public const string Appointment = "0x0FED060E-0x8793-0x4B1E-0x90-0xC9-0x48-0xAC-0x38-0x9A-0xC6-0x31";

                /// <summary>
                /// <para>Name: WPD_CONTENT_TYPE_TASK</para>
                /// <para>Description: Indicates this object represents a task for tracking (e.g. a TODO list)</para>
                /// </summary>
                public const string Task = "0x63252F2C-0x887F-0x4CB6-0xB1-0xAC-0xD2-0x98-0x55-0xDC-0xEF-0x6C";

                /// <summary>
                /// <para>Name: WPD_CONTENT_TYPE_PROGRAM</para>
                /// <para>Description: Indicates this object represents a file that can be run. This could be a script-executable and so on.</para>
                /// </summary>
                public const string Program = "0xD269F96A-0x247C-0x4BFF-0x98-0xFB-0x97-0xF3-0xC4-0x92-0x20-0xE6";

                /// <summary>
                /// <para>Name: WPD_CONTENT_TYPE_GENERIC_FILE</para>
                /// <para>Description: Indicates this object represents a file that does not fall into any of the other predefined WPD types for files.</para>
                /// </summary>
                public const string GenericFile = "0x0085E0A6-0x8D34-0x45D7-0xBC-0x5C-0x44-0x7E-0x59-0xC7-0x3D-0x48";

                /// <summary>
                /// <para>Name: WPD_CONTENT_TYPE_CALENDAR</para>
                /// <para>Description: Indicates this object represents a calendar</para>
                /// </summary>
                public const string Calendar = "0xA1FD5967-0x6023-0x49A0-0x9D-0xF1-0xF8-0x06-0x0B-0xE7-0x51-0xB0";

                /// <summary>
                /// <para>Name: WPD_CONTENT_TYPE_GENERIC_MESSAGE</para>
                /// <para>Description: Indicates this object represents a message (e.g. SMS message-E-Mail message-etc.)</para>
                /// </summary>
                public const string GenericMessage = "0xE80EAAF8-0xB2DB-0x4133-0xB6-0x7E-0x1B-0xEF-0x4B-0x4A-0x6E-0x5F";

                /// <summary>
                /// <para>Name: WPD_CONTENT_TYPE_NETWORK_ASSOCIATION</para>
                /// <para>Description: Indicates this object represents an association between a host and a device.</para>
                /// </summary>
                public const string NetworkAssociation = "0x031DA7EE-0x18C8-0x4205-0x84-0x7E-0x89-0xA1-0x12-0x61-0xD0-0xF3";

                /// <summary>
                /// <para>Name: WPD_CONTENT_TYPE_CERTIFICATE</para>
                /// <para>Description: Indicates this object represents certificate used for authentication.</para>
                /// </summary>
                public const string Certificate = "0xDC3876E8-0xA948-0x4060-0x90-0x50-0xCB-0xD7-0x7E-0x8A-0x3D-0x87";

                /// <summary>
                /// <para>Name: WPD_CONTENT_TYPE_WIRELESS_PROFILE</para>
                /// <para>Description: Indicates this object represents wireless network access information.</para>
                /// </summary>
                public const string WirelessProfile = "0x0BAC070A-0x9F5F-0x4DA4-0xA8-0xF6-0x3D-0xE4-0x4D-0x68-0xFD-0x6C";

                /// <summary>
                /// <para>Name: WPD_CONTENT_TYPE_MEDIA_CAST</para>
                /// <para>Description: Indicates this object represents a media cast. A media cast object can be though of as a container object that groups related content-similar to how a playlist groups songs to play. Often-a media cast object is used to group media content originally published online.</para>
                /// </summary>
                public const string MediaCast = "0x5E88B3CC-0x3E65-0x4E62-0xBF-0xFF-0x22-0x94-0x95-0x25-0x3A-0xB0";

                /// <summary>
                /// <para>Name: WPD_CONTENT_TYPE_SECTION</para>
                /// <para>Description: Indicates this object describes a section of data contained in another object. The WPD_OBJECT_REFERENCES property indicates which object contains the actual data.</para>
                /// </summary>
                public const string Section = "0x821089F5-0x1D91-0x4DC9-0xBE-0x3C-0xBB-0xB1-0xB3-0x5B-0x18-0xCE";

                /// <summary>
                /// <para>Name: WPD_CONTENT_TYPE_UNSPECIFIED</para>
                /// <para>Description: Indicates this object doesn't fall into the predefined WPD content types</para>
                /// </summary>
                public const string Unspecified = "0x28D8D31E-0x249C-0x454E-0xAA-0xBC-0x34-0x88-0x31-0x68-0xE6-0x34";

                /// <summary>
                /// <para>Name: WPD_CONTENT_TYPE_ALL</para>
                /// <para>Description: This content type is only valid as a parameter to API functions and driver commands. It should not be reported as a supported content type by the driver.</para>
                /// </summary>
                public const string All = "0x80E170D2-0x1055-0x4A3E-0xB9-0x52-0x82-0xCC-0x4F-0x8A-0x86-0x89";

            }

            /// <summary>
            /// This class defines all WPD Functional Categories
            /// </summary>
            public static class FunctionalCategory

            {

                //
                // WPD_FUNCTIONAL_CATEGORY_DEVICE
                // Used for the device object-which is always the top-most object of the device. 
                public const string Device = "0x08EA466B-0xE3A4-0x4336-0xA1-0xF3-0xA4-0x4D-0x2B-0x5C-0x43-0x8C";
                //
                // WPD_FUNCTIONAL_CATEGORY_STORAGE
                // Indicates this object encapsulates storage functionality on the device (e.g. memory cards-internal memory) 
                public const string Storage = "0x23F05BBC-0x15DE-0x4C2A-0xA5-0x5B-0xA9-0xAF-0x5C-0xE4-0x12-0xEF";
                //
                // WPD_FUNCTIONAL_CATEGORY_STILL_IMAGE_CAPTURE
                // Indicates this object encapsulates still image capture functionality on the device (e.g. camera or camera attachment) 
                public const string StillImageCapture = "0x613CA327-0xAB93-0x4900-0xB4-0xFA-0x89-0x5B-0xB5-0x87-0x4B-0x79";
                //
                // WPD_FUNCTIONAL_CATEGORY_AUDIO_CAPTURE
                // Indicates this object encapsulates audio capture functionality on the device (e.g. voice recorder or other audio recording component) 
                public const string AudioCapture = "0x3F2A1919-0xC7C2-0x4A00-0x85-0x5D-0xF5-0x7C-0xF0-0x6D-0xEB-0xBB";
                //
                // WPD_FUNCTIONAL_CATEGORY_VIDEO_CAPTURE
                // Indicates this object encapsulates video capture functionality on the device (e.g. video recorder or video recording component) 
                public const string VideoCapture = "0xE23E5F6B-0x7243-0x43AA-0x8D-0xF1-0x0E-0xB3-0xD9-0x68-0xA9-0x18";
                //
                // WPD_FUNCTIONAL_CATEGORY_SMS
                // Indicates this object encapsulates SMS sending functionality on the device (not the receiving or saved SMS messages since those are represented as content objects on the device) 
                public const string SMS = "0x0044A0B1-0xC1E9-0x4AFD-0xB3-0x58-0xA6-0x2C-0x61-0x17-0xC9-0xCF";
                //
                // WPD_FUNCTIONAL_CATEGORY_RENDERING_INFORMATION
                // Indicates this object provides information about the rendering characteristics of the device. 
                public const string RenderingInformation = "0x08600BA4-0xA7BA-0x4A01-0xAB-0x0E-0x00-0x65-0xD0-0xA3-0x56-0xD3";
                //
                // WPD_FUNCTIONAL_CATEGORY_NETWORK_CONFIGURATION
                // Indicates this object encapsulates network configuration functionality on the device (e.g. WiFi Profiles-Partnerships). 
                public const string NetworkConfiguration = "0x48F4DB72-0x7C6A-0x4AB0-0x9E-0x1A-0x47-0x0E-0x3C-0xDB-0xF2-0x6A";
                //
                // WPD_FUNCTIONAL_CATEGORY_ALL
                // This functional category is only valid as a parameter to API functions and driver commands. It should not be reported as a supported functional category by the driver. 
                public const string All = "0x2D8A6512-0xA74C-0x448E-0xBA-0x8A-0xF4-0xAC-0x07-0xC4-0x93-0x99";

            }

            /// <summary>
            /// This class defines all WPD Formats
            /// </summary>
            public static class ObjectFormat

            {
                //
                // WPD_OBJECT_FORMAT_ICON
                //   Standard Windows ICON format 
                public const string Icon = "0x077232ED-0x102C-0x4638-0x9C-0x22-0x83-0xF1-0x42-0xBF-0xC8-0x22";
                //
                // WPD_OBJECT_FORMAT_M4A
                //   Audio file format 
                public const string M4A = "0x30ABA7AC-0x6FFD-0x4C23-0xA3-0x59-0x3E-0x9B-0x52-0xF3-0xF1-0xC8";
                //
                // WPD_OBJECT_FORMAT_NETWORK_ASSOCIATION
                //   Network Association file format. 
                public const string NetworkAssociation = "0xB1020000-0xAE6C-0x4804-0x98-0xBA-0xC5-0x7B-0x46-0x96-0x5F-0xE7";
                //
                // WPD_OBJECT_FORMAT_X509V3CERTIFICATE
                //   X.509 V3 Certificate file format. 
                public const string X509v3Certificate = "0xB1030000-0xAE6C-0x4804-0x98-0xBA-0xC5-0x7B-0x46-0x96-0x5F-0xE7";
                //
                // WPD_OBJECT_FORMAT_MICROSOFT_WFC
                //   Windows Connect Now file format. 
                public const string MicrosoftWFC = "0xB1040000-0xAE6C-0x4804-0x98-0xBA-0xC5-0x7B-0x46-0x96-0x5F-0xE7";
                //
                // WPD_OBJECT_FORMAT_3GPA
                //   Audio file format 
                public const string ThreeGPA = "0xE5172730-0xF971-0x41EF-0xA1-0x0B-0x22-0x71-0xA0-0x01-0x9D-0x7A";
                //
                // WPD_OBJECT_FORMAT_3G2A
                //   Audio file format 
                public const string ThreeG2A = "0x1A11202D-0x8759-0x4E34-0xBA-0x5E-0xB1-0x21-0x10-0x87-0xEE-0xE4";
                //
                // WPD_OBJECT_FORMAT_ALL
                //   This format is only valid as a parameter to API functions and driver commands. It should not be reported as a supported format by the driver. 
                public const string All = "0xC1F62EB2-0x4BB3-0x479C-0x9C-0xFA-0x05-0xB5-0xF3-0xA5-0x7B-0x22";

            }

            // #region This section defines all Commands-Parameters and Options associated with: WPD_OBJECT_PROPERTIES_V1. This category is for all common object properties.

            public const string ObjectPropertiesV1 = "0xEF6B490D-0x5CD8-0x437A-0xAF-0xFC-0xDA-0x8B-0x60-0xEE-0x4A-0x3C";

            // #endregion

            // #region This section defines all Commands-Parameters and Options associated with: WPD_OBJECT_PROPERTIES_V2. This category is for all common object properties.

            public const string ObjectPropertiesV2 = "0x0373CD3D-0x4A46-0x40D7-0xB4-0xD8-0x73-0xE8-0xDA-0x74-0xE7-0x75";

            // #endregion

            // #region This section defines all Commands-Parameters and Options associated with: WPD_CATEGORY_NULL. This category is used exclusively for the NULL property key define.

            public const string CategoryNull = "0x00000000-0x0000-0x0000-0x00-0x00-0x00-0x00-0x00-0x00-0x00-0x00";

            // #endregion

            // #region This section defines all Commands-Parameters and Options associated with: WPD_FUNCTIONAL_OBJECT_PROPERTIES_V1. This category is for properties common to all functional objects.

            public const string FunctionalObjectPropertiesV1 = "0x8F052D93-0xABCA-0x4FC5-0xA5-0xAC-0xB0-0x1D-0xF4-0xDB-0xE5-0x98";

            // #endregion

            // #region This section defines all Commands-Parameters and Options associated with: WPD_STORAGE_OBJECT_PROPERTIES_V1. This category is for properties common to all objects whose functional category is WPD_FUNCTIONAL_CATEGORY_STORAGE.

            public const string StorageObjectPropertiesV1 = "0x01A3057A-0x74D6-0x4E80-0xBE-0xA7-0xDC-0x4C-0x21-0x2C-0xE5-0x0A";

            // #endregion

            // #region This section defines all Commands-Parameters and Options associated with: WPD_NETWORK_ASSOCIATION_PROPERTIES_V1. This category is for properties common to all network association objects.

            public const string NetworkAssociationPropertiesV1 = "0xE4C93C1F-0xB203-0x43F1-0xA1-0x00-0x5A-0x07-0xD1-0x1B-0x02-0x74";

            // #endregion

            // #region This section defines all Commands-Parameters and Options associated with: WPD_STILL_IMAGE_CAPTURE_OBJECT_PROPERTIES_V1. This category is for properties common to all objects whose functional category is WPD_FUNCTIONAL_CATEGORY_STILL_IMAGE_CAPTURE

            public const string StillImageCaptureObjectPropertiesV1 = "0x58C571EC-0x1BCB-0x42A7-0x8A-0xC5-0xBB-0x29-0x15-0x73-0xA2-0x60";

            // #endregion

            // #region This section defines all Commands-Parameters and Options associated with: WPD_RENDERING_INFORMATION_OBJECT_PROPERTIES_V1. This category is for properties common to all objects whose functional category is WPD_FUNCTIONAL_CATEGORY_AUDIO_RENDERING_INFORMATION

            public const string RenderingInformationObjectPropertiesV1 = "0xC53D039F-0xEE23-0x4A31-0x85-0x90-0x76-0x39-0x87-0x98-0x70-0xB4";

            // #endregion

            // #region This section defines all Commands-Parameters and Options associated with: WPD_CLIENT_INFORMATION_PROPERTIES_V1.

            public const string ClientInformationPropertiesV1 = "0x204D9F0C-0x2292-0x4080-0x9F-0x42-0x40-0x66-0x4E-0x70-0xF8-0x59";

            // #endregion

            // #region This section defines all Commands-Parameters and Options associated with: WPD_PROPERTY_ATTRIBUTES_V1

            public const string PropertyAttributesV1 = "0xAB7943D8-0x6332-0x445F-0xA0-0x0D-0x8D-0x5E-0xF1-0xE9-0x6F-0x37";

            // #endregion

            // #region This section defines all Commands-Parameters and Options associated with: WPD_PROPERTY_ATTRIBUTES_V2. This category defines additional property attributes used by device services.

            public const string PropertyAttributesV2 = "0x5D9DA160-0x74AE-0x43CC-0x85-0xA9-0xFE-0x55-0x5A-0x80-0x79-0x8E";

            // #endregion

            // #region This section defines all Commands-Parameters and Options associated with: WPD_CLASS_EXTENSION_OPTIONS_V1. This category of properties relates to options used for the WPD device class extension

            public const string ClassExtensionOptionsV1 = "0x6309FFEF-0xA87C-0x4CA7-0x84-0x34-0x79-0x75-0x76-0xE4-0x0A-0x96";

            // #endregion

            // #region This section defines all Commands-Parameters and Options associated with: WPD_CLASS_EXTENSION_OPTIONS_V2. This category of properties relates to options used for the WPD device class extension

            public const string ClassExtensionOptionsV2 = "0x3E3595DA-0x4D71-0x49FE-0xA0-0xB4-0xD4-0x40-0x6C-0x3A-0xE9-0x3F";

            // #endregion

            // #region This section defines all Commands-Parameters and Options associated with: WPD_CLASS_EXTENSION_OPTIONS_V3. This category of properties relates to options used for the WPD device class extension

            public const string ClassExtensionOptionsV3 = "0x65C160F8-0x1367-0x4CE2-0x93-0x9D-0x83-0x10-0x83-0x9F-0x0D-0x30";

            //#endregion

            #region This section defines all Commands-Parameters and Options associated with: WPD_RESOURCE_ATTRIBUTES_V1

            public const string ResourceAttributesV1 = "0x1EB6F604-0x9278-0x429F-0x93-0xCC-0x5B-0xB8-0xC0-0x66-0x56-0xB6";

            #endregion
            #region This section defines all Commands-Parameters and Options associated with: WPD_DEVICE_PROPERTIES_V1
            public const string DevicePropertiesV1 = "0x26D4979A-0xE643-0x4626-0x9E-0x2B-0x73-0x6D-0xC0-0xC9-0x2F-0xDC";

            #endregion
            #region This section defines all Commands-Parameters and Options associated with: WPD_DEVICE_PROPERTIES_V2
            public const string DevicePropertiesV2 = "0x463DD662-0x7FC4-0x4291-0x91-0x1C-0x7F-0x4C-0x9C-0xCA-0x97-0x99";

            #endregion
            #region This section defines all Commands-Parameters and Options associated with: WPD_DEVICE_PROPERTIES_V3
            public const string DevicePropertiesV3 = "0x6C2B878C-0xC2EC-0x490D-0xB4-0x25-0xD7-0xA7-0x5E-0x23-0xE5-0xED";

            #endregion
            #region This section defines all Commands-Parameters and Options associated with: WPD_SERVICE_PROPERTIES_V1
            public const string ServicePropertiesV1 = "0x7510698A-0xCB54-0x481C-0xB8-0xDB-0x0D-0x75-0xC9-0x3F-0x1C-0x06";

            #endregion
            #region This section defines all Commands-Parameters and Options associated with: WPD_EVENT_PROPERTIES_V1 The properties in this category are for properties that may be needed for event processing-but do not have object property equivalents(i.e.they are not exposed as object properties-but rather-used only as event parameters).
            public const string EventPropertiesV1 = "0x15AB1953-0xF817-0x4FEF-0xA9-0x21-0x56-0x76-0xE8-0x38-0xF6-0xE0";

            #endregion
            #region This section defines all Commands-Parameters and Options associated with: WPD_EVENT_PROPERTIES_V2 The properties in this category are for properties that may be needed for event processing-but do not have object property equivalents(i.e.they are not exposed as object properties-but rather-used only as event parameters).
            public const string EventPropertiesV2 = "0x52807B8A-0x4914-0x4323-0x9B-0x9A-0x74-0xF6-0x54-0xB2-0xB8-0x46";

            #endregion
            #region This section defines all Commands-Parameters and Options associated with: WPD_EVENT_OPTIONS_V1 The properties in this category describe event options.
            public const string EventOptionsV1 = "0xB3D8DAD7-0xA361-0x4B83-0x8A-0x48-0x5B-0x02-0xCE-0x10-0x71-0x3B";

            #endregion
            #region This section defines all Commands-Parameters and Options associated with: WPD_EVENT_ATTRIBUTES_V1 The properties in this category describe event attributes.
            public const string EventAttributesV1 = "0x10C96578-0x2E81-0x4111-0xAD-0xDE-0xE0-0x8C-0xA6-0x13-0x8F-0x6D";

            #endregion
            #region This section defines all Commands-Parameters and Options associated with: WPD_API_OPTIONS_V1 The properties in this category describe API options.
            public const string APIOptionsV1 = "0x10E54A3E-0x052D-0x4777-0xA1-0x3C-0xDE-0x76-0x14-0xBE-0x2B-0xC4";

            #endregion
            #region This section defines all Commands-Parameters and Options associated with: WPD_FORMAT_ATTRIBUTES_V1 The properties in this category describe format attributes.
            public const string FormatAttributesV1 = "0xA0A02000-0xBCAF-0x4BE8-0xB3-0xF5-0x23-0x3F-0x23-0x1C-0xF5-0x8F";

            #endregion
            #region This section defines all Commands-Parameters and Options associated with: WPD_METHOD_ATTRIBUTES_V1 The properties in this category describe method attributes.
            public const string MethodAttributesV1 = "0xF17A5071-0xF039-0x44AF-0x8E-0xFE-0x43-0x2C-0xF3-0x2E-0x43-0x2A";

            #endregion
            #region This section defines all Commands-Parameters and Options associated with: WPD_PARAMETER_ATTRIBUTES_V1 The properties in this category describe parameter attributes.
            public const string ParameterAttributesV1 = "0xE6864DD7-0xF325-0x45EA-0xA1-0xD5-0x97-0xCF-0x73-0xB6-0xCA-0x58";

            #endregion
            #region This section defines all Commands-Parameters and Options associated with: WPD_CLASS_EXTENSION_V1. The commands in this category relate to the WPD device class extension.

            public const string ClassExtensionV1 = "0x33FB0D11-0x64A3-0x4FAC-0xB4-0xC7-0x3D-0xFE-0xAA-0x99-0xB0-0x51";

            #endregion
            #region This section defines all Commands-Parameters and Options associated with: WPD_CLASS_EXTENSION_V2. The commands in this category relate to the WPD device class extension.

            public const string ClassExtensionV2 = "0x7F0779B5-0xFA2B-0x4766-0x9C-0xB2-0xF7-0x3B-0xA3-0x0B-0x67-0x58";

            #endregion
            #region This section defines all Commands-Parameters and Options associated with: WPD_CATEGORY_NETWORK_CONFIGURATION. The commands in this category are used for Network Association and WiFi Configuration.

            public const string NetworkConfiguration = "0x78F9C6FC-0x79B8-0x473C-0x90-0x60-0x6B-0xD2-0x3D-0xD0-0x72-0xC4";

            #endregion
            #region This section defines all Commands-Parameters and Options associated with: WPD_CATEGORY_SERVICE_COMMON. The commands in this category relate to a device service.

            public const string ServiceCommon = "0x322F071D-0x36EF-0x477F-0xB4-0xB5-0x6F-0x52-0xD7-0x34-0xBA-0xEE";

            #endregion
            #region This section defines all Commands-Parameters and Options associated with: WPD_CATEGORY_SERVICE_CAPABILITIES. The commands in this category relate to capabilities of a device service.

            public const string ServiceCapabilities = "0x24457E74-0x2E9F-0x44F9-0x8C-0x57-0x1D-0x1B-0xCB-0x17-0x0B-0x89";

            #endregion
            #region This section defines all Commands-Parameters and Options associated with: WPD_CATEGORY_SERVICE_METHODS. The commands in this category relate to methods of a device service.

            public const string ServiceMethods = "0x2D521CA8-0xC1B0-0x4268-0xA3-0x42-0xCF-0x19-0x32-0x15-0x69-0xBC";

            #endregion
            #region This section defines the legacy WPD definitions. When WPD_SERVICES_STRICT mode is defined-these definitions are removed from this header file. You may find replacements or equivalents in the Device Services headers (for example-BridgeDeviceService.h).
            // # ifndef WPD_SERVICES_STRICT

            public static class Legacy

            {

                #endregion
                #region This section defines the legacy WPD Formats
                public static class ObjectFormat

                {

                    //
                    // WPD_OBJECT_FORMAT_PROPERTIES_ONLY
                    //   This object has no data stream and is completely specified by properties only.
                    //   Device Services Format: FORMAT_Association
                    public const string PropertiesOnly = "0x30010000-0xAE6C-0x4804-0x98-0xBA-0xC5-0x7B-0x46-0x96-0x5F-0xE7";
                    //
                    // WPD_OBJECT_FORMAT_UNSPECIFIED
                    //   An undefined object format on the device (e.g. objects that can not be classified by the other defined WPD format codes)
                    //   Device Services Format: FORMAT_Undefined
                    public const string Unspecified = "0x30000000-0xAE6C-0x4804-0x98-0xBA-0xC5-0x7B-0x46-0x96-0x5F-0xE7";
                    //
                    // WPD_OBJECT_FORMAT_SCRIPT
                    //   A device model-specific script
                    //   Device Services Format: FORMAT_DeviceScript
                    public const string Script = "0x30020000-0xAE6C-0x4804-0x98-0xBA-0xC5-0x7B-0x46-0x96-0x5F-0xE7";
                    //
                    // WPD_OBJECT_FORMAT_EXECUTABLE
                    //   A device model-specific binary executable
                    //   Device Services Format: FORMAT_DeviceExecutable
                    public const string Executable = "0x30030000-0xAE6C-0x4804-0x98-0xBA-0xC5-0x7B-0x46-0x96-0x5F-0xE7";
                    //
                    // WPD_OBJECT_FORMAT_TEXT
                    //   A text file
                    //   Device Services Format: FORMAT_TextDocument
                    public const string Text = "0x30040000-0xAE6C-0x4804-0x98-0xBA-0xC5-0x7B-0x46-0x96-0x5F-0xE7";
                    //
                    // WPD_OBJECT_FORMAT_HTML
                    //   A HyperText Markup Language file (text)
                    //   Device Services Format: FORMAT_HTMLDocument
                    public const string HTML = "0x30050000-0xAE6C-0x4804-0x98-0xBA-0xC5-0x7B-0x46-0x96-0x5F-0xE7";
                    //
                    // WPD_OBJECT_FORMAT_DPOF
                    //   A Digital Print Order File (text)
                    //   Device Services Format: FORMAT_DPOFDocument
                    public const string DPOF = "0x30060000-0xAE6C-0x4804-0x98-0xBA-0xC5-0x7B-0x46-0x96-0x5F-0xE7";
                    //
                    // WPD_OBJECT_FORMAT_AIFF
                    //   Audio file format
                    //   Device Services Format: FORMAT_AIFFFile
                    public const string AIFF = "0x30070000-0xAE6C-0x4804-0x98-0xBA-0xC5-0x7B-0x46-0x96-0x5F-0xE7";
                    //
                    // WPD_OBJECT_FORMAT_WAVE
                    //   Audio file format
                    //   Device Services Format: FORMAT_WAVFile
                    public const string WAV = "0x30080000-0xAE6C-0x4804-0x98-0xBA-0xC5-0x7B-0x46-0x96-0x5F-0xE7";
                    //
                    // WPD_OBJECT_FORMAT_MP3
                    //   Audio file format
                    //   Device Services Format: FORMAT_MP3File
                    public const string MP3 = "0x30090000-0xAE6C-0x4804-0x98-0xBA-0xC5-0x7B-0x46-0x96-0x5F-0xE7";
                    //
                    // WPD_OBJECT_FORMAT_AVI
                    //   Video file format
                    //   Device Services Format: FORMAT_AVIFile
                    public const string AVI = "0x300A0000-0xAE6C-0x4804-0x98-0xBA-0xC5-0x7B-0x46-0x96-0x5F-0xE7";
                    //
                    // WPD_OBJECT_FORMAT_MPEG
                    //   Video file format
                    //   Device Services Format: FORMAT_MPEGFile
                    public const string MPEG = "0x300B0000-0xAE6C-0x4804-0x98-0xBA-0xC5-0x7B-0x46-0x96-0x5F-0xE7";
                    //
                    // WPD_OBJECT_FORMAT_ASF
                    //   Video file format (Microsoft Advanced Streaming Format)
                    //   Device Services Format: FORMAT_ASFFile
                    public const string ASF = "0x300C0000-0xAE6C-0x4804-0x98-0xBA-0xC5-0x7B-0x46-0x96-0x5F-0xE7";
                    //
                    // WPD_OBJECT_FORMAT_EXIF
                    //   Image file format (Exchangeable File Format)-JEIDA standard
                    //   Device Services Format: FORMAT_EXIFImage
                    public const string EXIF = "0x38010000-0xAE6C-0x4804-0x98-0xBA-0xC5-0x7B-0x46-0x96-0x5F-0xE7";
                    //
                    // WPD_OBJECT_FORMAT_TIFFEP
                    //   Image file format (Tag Image File Format for Electronic Photography)
                    //   Device Services Format: FORMAT_TIFFEPImage
                    public const string TIFFEP = "0x38020000-0xAE6C-0x4804-0x98-0xBA-0xC5-0x7B-0x46-0x96-0x5F-0xE7";
                    //
                    // WPD_OBJECT_FORMAT_FLASHPIX
                    //   Image file format (Structured Storage Image Format)
                    //   Device Services Format: FORMAT_FlashPixImage
                    public const string FlashPIX = "0x38030000-0xAE6C-0x4804-0x98-0xBA-0xC5-0x7B-0x46-0x96-0x5F-0xE7";
                    //
                    // WPD_OBJECT_FORMAT_BMP
                    //   Image file format (Microsoft Windows Bitmap file)
                    //   Device Services Format: FORMAT_BMPImage
                    public const string BMP = "0x38040000-0xAE6C-0x4804-0x98-0xBA-0xC5-0x7B-0x46-0x96-0x5F-0xE7";
                    //
                    // WPD_OBJECT_FORMAT_CIFF
                    //   Image file format (Canon Camera Image File Format)
                    //   Device Services Format: FORMAT_CIFFImage
                    public const string CIFF = "0x38050000-0xAE6C-0x4804-0x98-0xBA-0xC5-0x7B-0x46-0x96-0x5F-0xE7";
                    //
                    // WPD_OBJECT_FORMAT_GIF
                    //   Image file format (Graphics Interchange Format)
                    //   Device Services Format: FORMAT_GIFImage
                    public const string GIF = "0x38070000-0xAE6C-0x4804-0x98-0xBA-0xC5-0x7B-0x46-0x96-0x5F-0xE7";
                    //
                    // WPD_OBJECT_FORMAT_JFIF
                    //   Image file format (JPEG Interchange Format)
                    //   Device Services Format: FORMAT_JFIFImage
                    public const string JFIF = "0x38080000-0xAE6C-0x4804-0x98-0xBA-0xC5-0x7B-0x46-0x96-0x5F-0xE7";
                    //
                    // WPD_OBJECT_FORMAT_PCD
                    //   Image file format (PhotoCD Image Pac)
                    //   Device Services Format: FORMAT_PCDImage
                    public const string PCD = "0x38090000-0xAE6C-0x4804-0x98-0xBA-0xC5-0x7B-0x46-0x96-0x5F-0xE7";
                    //
                    // WPD_OBJECT_FORMAT_PICT
                    //   Image file format (Quickdraw Image Format)
                    //   Device Services Format: FORMAT_PICTImage
                    public const string PICT = "0x380A0000-0xAE6C-0x4804-0x98-0xBA-0xC5-0x7B-0x46-0x96-0x5F-0xE7";
                    //
                    // WPD_OBJECT_FORMAT_PNG
                    //   Image file format (Portable Network Graphics)
                    //   Device Services Format: FORMAT_PNGImage
                    public const string PNG = "0x380B0000-0xAE6C-0x4804-0x98-0xBA-0xC5-0x7B-0x46-0x96-0x5F-0xE7";
                    //
                    // WPD_OBJECT_FORMAT_TIFF
                    //   Image file format (Tag Image File Format)
                    //   Device Services Format: FORMAT_TIFFImage
                    public const string TIFF = "0x380D0000-0xAE6C-0x4804-0x98-0xBA-0xC5-0x7B-0x46-0x96-0x5F-0xE7";
                    //
                    // WPD_OBJECT_FORMAT_TIFFIT
                    //   Image file format (Tag Image File Format for Informational Technology) Graphic Arts
                    //   Device Services Format: FORMAT_TIFFITImage
                    public const string TIFFIT = "0x380E0000-0xAE6C-0x4804-0x98-0xBA-0xC5-0x7B-0x46-0x96-0x5F-0xE7";
                    //
                    // WPD_OBJECT_FORMAT_JP2
                    //   Image file format (JPEG2000 Baseline File Format)
                    //   Device Services Format: FORMAT_JP2Image
                    public const string JP2 = "0x380F0000-0xAE6C-0x4804-0x98-0xBA-0xC5-0x7B-0x46-0x96-0x5F-0xE7";
                    //
                    // WPD_OBJECT_FORMAT_JPX
                    //   Image file format (JPEG2000 Extended File Format)
                    //   Device Services Format: FORMAT_JPXImage
                    public const string JPX = "0x38100000-0xAE6C-0x4804-0x98-0xBA-0xC5-0x7B-0x46-0x96-0x5F-0xE7";
                    //
                    // WPD_OBJECT_FORMAT_WBMP
                    //   Image file format (Wireless Application Protocol Bitmap Format)
                    //   Device Services Format: FORMAT_WBMPImage
                    public const string WBMP = "0xB8030000-0xAE6C-0x4804-0x98-0xBA-0xC5-0x7B-0x46-0x96-0x5F-0xE7";
                    //
                    // WPD_OBJECT_FORMAT_JPEGXR
                    //   Image file format (JPEG XR-also known as HD Photo)
                    //   Device Services Format: FORMAT_JPEGXRImage
                    public const string JPEGXR = "0xB8040000-0xAE6C-0x4804-0x98-0xBA-0xC5-0x7B-0x46-0x96-0x5F-0xE7";
                    //
                    // WPD_OBJECT_FORMAT_WINDOWSIMAGEFORMAT
                    //   Image file format
                    //   Device Services Format: FORMAT_HDPhotoImage
                    public const string WindowsImageFormat = "0xB8810000-0xAE6C-0x4804-0x98-0xBA-0xC5-0x7B-0x46-0x96-0x5F-0xE7";
                    //
                    // WPD_OBJECT_FORMAT_WMA
                    //   Audio file format (Windows Media Audio)
                    //   Device Services Format: FORMAT_WMAFile
                    public const string WMA = "0xB9010000-0xAE6C-0x4804-0x98-0xBA-0xC5-0x7B-0x46-0x96-0x5F-0xE7";
                    //
                    // WPD_OBJECT_FORMAT_WMV
                    //   Video file format (Windows Media Video)
                    //   Device Services Format: FORMAT_WMVFile
                    public const string WMV = "0xB9810000-0xAE6C-0x4804-0x98-0xBA-0xC5-0x7B-0x46-0x96-0x5F-0xE7";
                    //
                    // WPD_OBJECT_FORMAT_WPLPLAYLIST
                    //   Playlist file format
                    //   Device Services Format: FORMAT_WPLPlaylist
                    public const string WPLPlaylist = "0xBA100000-0xAE6C-0x4804-0x98-0xBA-0xC5-0x7B-0x46-0x96-0x5F-0xE7";
                    //
                    // WPD_OBJECT_FORMAT_M3UPLAYLIST
                    //   Playlist file format
                    //   Device Services Format: FORMAT_M3UPlaylist
                    public const string M3UPlaylist = "0xBA110000-0xAE6C-0x4804-0x98-0xBA-0xC5-0x7B-0x46-0x96-0x5F-0xE7";
                    //
                    // WPD_OBJECT_FORMAT_MPLPLAYLIST
                    //   Playlist file format
                    //   Device Services Format: FORMAT_MPLPlaylist
                    public const string MPLPlaylist = "0xBA120000-0xAE6C-0x4804-0x98-0xBA-0xC5-0x7B-0x46-0x96-0x5F-0xE7";
                    //
                    // WPD_OBJECT_FORMAT_ASXPLAYLIST
                    //   Playlist file format
                    //   Device Services Format: FORMAT_ASXPlaylist
                    public const string ASXPlaylist = "0xBA130000-0xAE6C-0x4804-0x98-0xBA-0xC5-0x7B-0x46-0x96-0x5F-0xE7";
                    //
                    // WPD_OBJECT_FORMAT_PLSPLAYLIST
                    //   Playlist file format
                    //   Device Services Format: FORMAT_PSLPlaylist
                    public const string PLSPlaylist = "0xBA140000-0xAE6C-0x4804-0x98-0xBA-0xC5-0x7B-0x46-0x96-0x5F-0xE7";
                    //
                    // WPD_OBJECT_FORMAT_ABSTRACT_CONTACT_GROUP
                    //   Generic format for contact group objects
                    //   Device Services Format: FORMAT_AbstractContactGroup
                    public const string AbstractContactGroup = "0xBA060000-0xAE6C-0x4804-0x98-0xBA-0xC5-0x7B-0x46-0x96-0x5F-0xE7";
                    //
                    // WPD_OBJECT_FORMAT_ABSTRACT_MEDIA_CAST
                    //   MediaCast file format
                    //   Device Services Format: FORMAT_AbstractMediacast
                    public const string AbstractMediaCast = "0xBA0B0000-0xAE6C-0x4804-0x98-0xBA-0xC5-0x7B-0x46-0x96-0x5F-0xE7";
                    //
                    // WPD_OBJECT_FORMAT_VCALENDAR1
                    //   VCALENDAR file format (VCALENDAR Version 1)
                    //   Device Services Format: FORMAT_VCalendar1
                    public const string VCalendar1 = "0xBE020000-0xAE6C-0x4804-0x98-0xBA-0xC5-0x7B-0x46-0x96-0x5F-0xE7";
                    //
                    // WPD_OBJECT_FORMAT_ICALENDAR
                    //   ICALENDAR file format (VCALENDAR Version 2)
                    //   Device Services Format: FORMAT_ICalendar
                    public const string ICalendar = "0xBE030000-0xAE6C-0x4804-0x98-0xBA-0xC5-0x7B-0x46-0x96-0x5F-0xE7";
                    //
                    // WPD_OBJECT_FORMAT_ABSTRACT_CONTACT
                    //   Abstract contact file format
                    //   Device Services Format: FORMAT_AbstractContact
                    public const string AbstractContact = "0xBB810000-0xAE6C-0x4804-0x98-0xBA-0xC5-0x7B-0x46-0x96-0x5F-0xE7";
                    //
                    // WPD_OBJECT_FORMAT_VCARD2
                    //   VCARD file format (VCARD Version 2)
                    //   Device Services Format: FORMAT_VCard2Contact
                    public const string VCard2 = "0xBB820000-0xAE6C-0x4804-0x98-0xBA-0xC5-0x7B-0x46-0x96-0x5F-0xE7";
                    //
                    // WPD_OBJECT_FORMAT_VCARD3
                    //   VCARD file format (VCARD Version 3)
                    //   Device Services Format: FORMAT_VCard3Contact
                    public const string VCard3 = "0xBB830000-0xAE6C-0x4804-0x98-0xBA-0xC5-0x7B-0x46-0x96-0x5F-0xE7";
                    //
                    // WPD_OBJECT_FORMAT_XML
                    //   XML file format.
                    //   Device Services Format: FORMAT_XMLDocument
                    public const string XML = "0xBA820000-0xAE6C-0x4804-0x98-0xBA-0xC5-0x7B-0x46-0x96-0x5F-0xE7";
                    //
                    // WPD_OBJECT_FORMAT_AAC
                    //   Audio file format
                    //   Device Services Format: FORMAT_AACFile
                    public const string AAC = "0xB9030000-0xAE6C-0x4804-0x98-0xBA-0xC5-0x7B-0x46-0x96-0x5F-0xE7";
                    //
                    // WPD_OBJECT_FORMAT_AUDIBLE
                    //   Audio file format
                    //   Device Services Format: FORMAT_AudibleFile
                    public const string Audible = "0xB9040000-0xAE6C-0x4804-0x98-0xBA-0xC5-0x7B-0x46-0x96-0x5F-0xE7";
                    //
                    // WPD_OBJECT_FORMAT_FLAC
                    //   Audio file format
                    //   Device Services Format: FORMAT_FLACFile
                    public const string FLAC = "0xB9060000-0xAE6C-0x4804-0x98-0xBA-0xC5-0x7B-0x46-0x96-0x5F-0xE7";
                    //
                    // WPD_OBJECT_FORMAT_QCELP
                    //   Audio file format (Qualcomm Code Excited Linear Prediction)
                    //   Device Services Format: FORMAT_QCELPFile
                    public const string QCELP = "0xB9070000-0xAE6C-0x4804-0x98-0xBA-0xC5-0x7B-0x46-0x96-0x5F-0xE7";
                    //
                    // WPD_OBJECT_FORMAT_AMR
                    //   Audio file format (Adaptive Multi-Rate audio codec)
                    //   Device Services Format: FORMAT_AMRFile
                    public const string AMR = "0xB9080000-0xAE6C-0x4804-0x98-0xBA-0xC5-0x7B-0x46-0x96-0x5F-0xE7";
                    //
                    // WPD_OBJECT_FORMAT_OGG
                    //   Audio file format
                    //   Device Services Format: FORMAT_OGGFile
                    public const string OGG = "0xB9020000-0xAE6C-0x4804-0x98-0xBA-0xC5-0x7B-0x46-0x96-0x5F-0xE7";
                    //
                    // WPD_OBJECT_FORMAT_MP4
                    //   Audio or Video file format
                    //   Device Services Format: FORMAT_MPEG4File
                    public const string MP4 = "0xB9820000-0xAE6C-0x4804-0x98-0xBA-0xC5-0x7B-0x46-0x96-0x5F-0xE7";
                    //
                    // WPD_OBJECT_FORMAT_MP2
                    //   Audio or Video file format
                    //   Device Services Format: FORMAT_MPEG2File
                    public const string MP2 = "0xB9830000-0xAE6C-0x4804-0x98-0xBA-0xC5-0x7B-0x46-0x96-0x5F-0xE7";
                    //
                    // WPD_OBJECT_FORMAT_MICROSOFT_WORD
                    //   Microsoft Office Word Document file format.
                    //   Device Services Format: FORMAT_WordDocument
                    public const string MicrosoftWord = "0xBA830000-0xAE6C-0x4804-0x98-0xBA-0xC5-0x7B-0x46-0x96-0x5F-0xE7";
                    //
                    // WPD_OBJECT_FORMAT_MHT_COMPILED_HTML
                    //   MHT Compiled HTML Document file format.
                    //   Device Services Format: FORMAT_MHTDocument
                    public const string MHTCompiledHTML = "0xBA840000-0xAE6C-0x4804-0x98-0xBA-0xC5-0x7B-0x46-0x96-0x5F-0xE7";
                    //
                    // WPD_OBJECT_FORMAT_MICROSOFT_EXCEL
                    //   Microsoft Office Excel Document file format.
                    //   Device Services Format: FORMAT_ExcelDocument
                    public const string MicrosoftExcel = "0xBA850000-0xAE6C-0x4804-0x98-0xBA-0xC5-0x7B-0x46-0x96-0x5F-0xE7";
                    //
                    // WPD_OBJECT_FORMAT_MICROSOFT_POWERPOINT
                    //   Microsoft Office PowerPoint Document file format.
                    //   Device Services Format: FORMAT_PowerPointDocument
                    public const string MicrosoftPowerPoint = "0xBA860000-0xAE6C-0x4804-0x98-0xBA-0xC5-0x7B-0x46-0x96-0x5F-0xE7";
                    //
                    // WPD_OBJECT_FORMAT_3GP
                    //   Audio or Video file format
                    //   Device Services Format: FORMAT_3GPPFile
                    public const string ThreeGP = "0xB9840000-0xAE6C-0x4804-0x98-0xBA-0xC5-0x7B-0x46-0x96-0x5F-0xE7";
                    //
                    // WPD_OBJECT_FORMAT_3G2
                    //   Audio or Video file format
                    //   Device Services Format: FORMAT_3GPP2File
                    public const string ThreeG2 = "0xB9850000-0xAE6C-0x4804-0x98-0xBA-0xC5-0x7B-0x46-0x96-0x5F-0xE7";
                    //
                    // WPD_OBJECT_FORMAT_AVCHD
                    //   Audio or Video file format
                    //   Device Services Format: FORMAT_AVCHDFile
                    public const string AVCHD = "0xB9860000-0xAE6C-0x4804-0x98-0xBA-0xC5-0x7B-0x46-0x96-0x5F-0xE7";
                    //
                    // WPD_OBJECT_FORMAT_ATSCTS
                    //   Audio or Video file format
                    //   Device Services Format: FORMAT_ATSCTSFile
                    public const string ATSCTS = "0xB9870000-0xAE6C-0x4804-0x98-0xBA-0xC5-0x7B-0x46-0x96-0x5F-0xE7";
                    //
                    // WPD_OBJECT_FORMAT_DVBTS
                    //   Audio or Video file format
                    //   Device Services Format: FORMAT_DVBTSFile
                    public const string DVBTS = "0xB9880000-0xAE6C-0x4804-0x98-0xBA-0xC5-0x7B-0x46-0x96-0x5F-0xE7";
                    //
                    // WPD_OBJECT_FORMAT_MKV
                    //   Audio or Video file format
                    //   Device Services Format: FORMAT_MKVFile
                    public const string MKV = "0xB9900000-0xAE6C-0x4804-0x98-0xBA-0xc5-0x7B-0x46-0x96-0x5F-0xE7";

                }

                #endregion
                #region This section defines all Commands-Parameters and Options associated with: WPD_FOLDER_OBJECT_PROPERTIES_V1. This category is for properties common to all folder objects.
                public const string FolderObjectPropertiesV1 = "0x7E9A7ABF-0xE568-0x4B34-0xAA-0x2F-0x13-0xBB-0x12-0xAB-0x17-0x7D";

                #endregion
                #region This section defines all Commands-Parameters and Options associated with: WPD_IMAGE_OBJECT_PROPERTIES_V1. This category is for properties common to all image objects.
                public const string ImageObjectPropertiesV1 = "0x63D64908-0x9FA1-0x479F-0x85-0xBA-0x99-0x52-0x21-0x64-0x47-0xDB";

                #endregion
                #region This section defines all Commands-Parameters and Options associated with: WPD_DOCUMENT_OBJECT_PROPERTIES_V1. This category is for properties common to all document objects.
                public const string DocumentObjectPropertiesV1 = "0x0B110203-0xEB95-0x4F02-0x93-0xE0-0x97-0xC6-0x31-0x49-0x3A-0xD5";

                #endregion
                #region This section defines all Commands-Parameters and Options associated with: WPD_MEDIA_PROPERTIES_V1. This category is for properties common to media objects(e.g.audio and video).
                public const string MediaPropertiesV1 = "0x2ED8BA05-0x0AD3-0x42DC-0xB0-0xD0-0xBC-0x95-0xAC-0x39-0x6A-0xC8";

                #endregion
                #region This section defines all Commands-Parameters and Options associated with: WPD_CONTACT_OBJECT_PROPERTIES_V1. This category is for properties common to all contact objects.
                public const string ContactObjectPropertiesV1 = "0xFBD4FDAB-0x987D-0x4777-0xB3-0xF9-0x72-0x61-0x85-0xA9-0x31-0x2B";

                #endregion
                #region This section defines all Commands-Parameters and Options associated with: WPD_MUSIC_OBJECT_PROPERTIES_V1. This category is for properties common to all music objects.
                public const string MusicObjectPropertiesV1 = "0xB324F56A-0xDC5D-0x46E5-0xB6-0xDF-0xD2-0xEA-0x41-0x48-0x88-0xC6";

                #endregion
                #region This section defines all Commands-Parameters and Options associated with: WPD_VIDEO_OBJECT_PROPERTIES_V1. This category is for properties common to all video objects.
                public const string VideoObjectPropertiesV1 = "0x346F2163-0xF998-0x4146-0x8B-0x01-0xD1-0x9B-0x4C-0x00-0xDE-0x9A";

                #endregion
                #region This section defines all Commands-Parameters and Options associated with: WPD_COMMON_INFORMATION_OBJECT_PROPERTIES_V1. This category is properties that pertain to informational objects such as appointments-tasks-memos and even documents.
                public const string CommonInformationObjectPropertiesV1 = "0xB28AE94B-0x05A4-0x4E8E-0xBE-0x01-0x72-0xCC-0x7E-0x09-0x9D-0x8F";

                #endregion
                #region This section defines all Commands-Parameters and Options associated with: WPD_MEMO_OBJECT_PROPERTIES_V1. This category is for properties common to all memo objects.
                public const string MemoObjectPropertiesV1 = "0x5FFBFC7B-0x7483-0x41AD-0xAF-0xB9-0xDA-0x3F-0x4E-0x59-0x2B-0x8D";

                #endregion
                #region This section defines all Commands-Parameters and Options associated with: WPD_EMAIL_OBJECT_PROPERTIES_V1. This category is for properties common to all email objects.
                public const string EmailObjectPropertiesV1 = "0x41F8F65A-0x5484-0x4782-0xB1-0x3D-0x47-0x40-0xDD-0x7C-0x37-0xC5";

                #endregion
                #region This section defines all Commands-Parameters and Options associated with: WPD_APPOINTMENT_OBJECT_PROPERTIES_V1. This category is for properties common to all appointment objects.
                public const string ObjectPropertiesV1 = "0xF99EFD03-0x431D-0x40D8-0xA1-0xC9-0x4E-0x22-0x0D-0x9C-0x88-0xD3";

                #endregion
                #region This section defines all Commands-Parameters and Options associated with: WPD_TASK_OBJECT_PROPERTIES_V1. This category is for properties common to all task objects.
                public const string TaskObjectPropertiesV1 = "0xE354E95E-0xD8A0-0x4637-0xA0-0x3A-0x0C-0xB2-0x68-0x38-0xDB-0xC7";

                #endregion
                #region This section defines all Commands-Parameters and Options associated with: WPD_SMS_OBJECT_PROPERTIES_V1. This category is for properties common to all objects whose functional category is WPD_FUNCTIONAL_CATEGORY_SMS
                public const string SMSObjectPropertiesV1 = "0x7E1074CC-0x50FF-0x4DD1-0xA7-0x42-0x53-0xBE-0x6F-0x09-0x3A-0x0D";

                #endregion
                #region This section defines all Commands-Parameters and Options associated with: WPD_SECTION_OBJECT_PROPERTIES_V1. This category is for properties common to all objects whose content type is WPD_CONTENT_TYPE_SECTION
                public const string SectionObjectPropertiesV1 = "0x516AFD2B-0xC64E-0x44F0-0x98-0xDC-0xBE-0xE1-0xC8-0x8F-0x7D-0x66";

                #endregion

                // #endif // WPD_SERVICES_STRICT

            }

        }

        public static class CommandCategory

        {

            #region This section defines all Commands-Parameters and Options associated with: WPD_CATEGORY_COMMON

            public const string Common = "0xF0422A9C-0x5DC8-0x4440-0xB5-0xBD-0x5D-0xF2-0x88-0x35-0x65-0x8A";

            #endregion
            #region This section defines all Commands-Parameters and Options associated with: WPD_CATEGORY_OBJECT_ENUMERATION. The commands in this category are used for basic object enumeration.

            public const string ObjectEnumeration = "0xB7474E91-0xE7F8-0x4AD9-0xB4-0x00-0xAD-0x1A-0x4B-0x58-0xEE-0xEC";

            #endregion
            #region This section defines all Commands-Parameters and Options associated with: WPD_CATEGORY_OBJECT_PROPERTIES. This category of commands is used to perform basic property operations such as Reading/Writing values-listing supported values and so on.

            public const string ObjectProperties = "0x9E5582E4-0x0814-0x44E6-0x98-0x1A-0xB2-0x99-0x8D-0x58-0x38-0x04";

            #endregion
            #region This section defines all Commands-Parameters and Options associated with: WPD_CATEGORY_OBJECT_PROPERTIES_BULK. This category contains commands and properties for property operations across multiple objects.

            public const string ObjectPropertiesBulk = "0x11C824DD-0x04CD-0x4E4E-0x8C-0x7B-0xF6-0xEF-0xB7-0x94-0xD8-0x4E";

            #endregion
            #region This section defines all Commands-Parameters and Options associated with: WPD_CATEGORY_OBJECT_RESOURCES. The commands in this category are used for basic object resource enumeration and transfer.

            public const string ObjectResources = "0xB3A2B22D-0xA595-0x4108-0xBE-0x0A-0xFC-0x3C-0x96-0x5F-0x3D-0x4A";

            #endregion
            #region This section defines all Commands-Parameters and Options associated with: WPD_CATEGORY_OBJECT_MANAGEMENT. The commands specified in this category are used to Create/Delete objects on the device.

            public const string ObjectManagement = "0xEF1E43DD-0xA9ED-0x4341-0x8B-0xCC-0x18-0x61-0x92-0xAE-0xA0-0x89";

            #endregion
            #region This section defines all Commands-Parameters and Options associated with: WPD_CATEGORY_CAPABILITIES. This command category is used to query capabilities of the device.

            public const string Capabilities = "0x0CABEC78-0x6B74-0x41C6-0x92-0x16-0x26-0x39-0xD1-0xFC-0xE3-0x56";

            #endregion
            #region This section defines all Commands-Parameters and Options associated with: WPD_CATEGORY_STORAGE. This category is for commands and parameters for storage functional objects.

            public const string Storage = "0xD8F907A6-0x34CC-0x45FA-0x97-0xFB-0xD0-0x07-0xFA-0x47-0xEC-0x94";

            #endregion
            #region This section defines all Commands-Parameters and Options associated with: WPD_CATEGORY_SMS. The commands in this category relate to Short-Message-Service functionality-typically exposed on mobile phones.
            public const string SMS = "0xAFC25D66-0xFE0D-0x4114-0x90-0x97-0x97-0x0C-0x93-0xE9-0x20-0xD1";

            #endregion
            #region This section defines all Commands-Parameters and Options associated with: WPD_CATEGORY_STILL_IMAGE_CAPTURE

            public const string StillImageCapture = "0x4FCD6982-0x22A2-0x4B05-0xA4-0x8B-0x62-0xD3-0x8B-0xF2-0x7B-0x32";

            #endregion
            #region This section defines all Commands-Parameters and Options associated with: WPD_CATEGORY_MEDIA_CAPTURE

            public const string MediaCapture = "0x59B433BA-0xFE44-0x4D8D-0x80-0x8C-0x6B-0xCB-0x9B-0x0F-0x15-0xE8";

            #endregion
            #region This section defines all Commands-Parameters and Options associated with: WPD_CATEGORY_DEVICE_HINTS. The commands in this category relate to hints that a device can provide to improve end-user experience.

            public const string DeviceHints = "0x0D5FB92B-0xCB46-0x4C4F-0x83-0x43-0x0B-0xC3-0xD3-0xF1-0x7C-0x84";

        }

    }

    public static class MediaDevices

    {

        public const string IComponentAuthenticate = "A9889C00-6D2B-11d3-8496-00C04F79DBC0";
        public const string IMDServiceProvider = "1DCB3A10-33ED-11d3-8470-00C04F79DBC0";
        public const string IMDServiceProvider2 = "B2FA24B7-CDA3-4694-9862-413AE1A34819";
        public const string IMDServiceProvider3 = "4ed13ef3-a971-4d19-9f51-0e1826b2da57";
        public const string IMDSPDevice = "1DCB3A12-33ED-11d3-8470-00C04F79DBC0";
        public const string IMDSPDevice2 = "420D16AD-C97D-4e00-82AA-00E9F4335DDD";
        public const string IMDSPDevice3 = "1a839845-fc55-487c-976f-ee38ac0e8c4e";
        public const string IMDSPDeviceControl = "1DCB3A14-33ED-11d3-8470-00C04F79DBC0";
        public const string IMDSPDirectTransfer = "c2fe57a8-9304-478c-9ee4-47e397b912d7";
        public const string IMDSPEnumDevice = "1DCB3A11-33ED-11d3-8470-00C04F79DBC0";
        public const string IMDSPEnumStorage = "1DCB3A15-33ED-11d3-8470-00C04F79DBC0";
        public const string IMDSPObject = "1DCB3A18-33ED-11d3-8470-00C04F79DBC0";
        public const string IMDSPObject2 = "3f34cd3e-5907-4341-9af9-97f4187c3aa5";
        public const string IMDSPObjectInfo = "1DCB3A19-33ED-11d3-8470-00C04F79DBC0";
        public const string IMDSPRevoked = "A4E8F2D4-3F31-464d-B53D-4FC335998184";
        public const string IMDSPStorage = "1DCB3A16-33ED-11d3-8470-00C04F79DBC0";
        public const string IMDSPStorage2 = "0A5E07A5-6454-4451-9C36-1C6AE7E2B1D6";
        public const string IMDSPStorage3 = "6C669867-97ED-4a67-9706-1C5529D2A414";
        public const string IMDSPStorage4 = "3133b2c4-515c-481b-b1ce-39327ecb4f74";
        public const string IMDSPStorageGlobals = "1DCB3A17-33ED-11d3-8470-00C04F79DBC0";
        public const string ISCPSecureAuthenticate = "1DCB3A0F-33ED-11d3-8470-00C04F79DBC0";
        public const string ISCPSecureAuthenticate2 = "B580CFAE-1672-47e2-ACAA-44BBECBCAE5B";
        public const string ISCPSecureExchange = "1DCB3A0E-33ED-11d3-8470-00C04F79DBC0";
        public const string ISCPSecureExchange2 = "6C62FC7B-2690-483F-9D44-0A20CB35577C";
        public const string ISCPSecureExchange3 = "ab4e77e4-8908-4b17-bd2a-b1dbe6dd69e1";
        public const string ISCPSecureQuery = "1DCB3A0D-33ED-11d3-8470-00C04F79DBC0";
        public const string ISCPSecureQuery2 = "EBE17E25-4FD7-4632-AF46-6D93D4FCC72E";
        public const string ISCPSecureQuery3 = "B7EDD1A2-4DAB-484b-B3C5-AD39B8B4C0B1";
        public const string ISCPSession = "88a3e6ed-eee4-4619-bbb3-fd4fb62715d1";
        public const string IWMDeviceManager = "1DCB3A00-33ED-11d3-8470-00C04F79DBC0";
        public const string IWMDeviceManager2 = "923E5249-8731-4c5b-9B1C-B8B60B6E46AF";
        public const string IWMDeviceManager3 = "af185c41-100d-46ed-be2e-9ce8c44594ef";
        public const string IWMDMDevice = "1DCB3A02-33ED-11d3-8470-00C04F79DBC0";
        public const string IWMDMDevice2 = "E34F3D37-9D67-4fc1-9252-62D28B2F8B55";
        public const string IWMDMDevice3 = "6c03e4fe-05db-4dda-9e3c-06233a6d5d65";
        public const string IWMDMDeviceControl = "1DCB3A04-33ED-11d3-8470-00C04F79DBC0";
        public const string IWMDMDeviceSession = "82af0a65-9d96-412c-83e5-3c43e4b06cc7";
        public const string IWMDMEnumDevice = "1DCB3A01-33ED-11d3-8470-00C04F79DBC0";
        public const string IWMDMEnumStorage = "1DCB3A05-33ED-11d3-8470-00C04F79DBC0";
        public const string IWMDMMetaData = "EC3B0663-0951-460a-9A80-0DCEED3C043C";
        public const string IWMDMNotification = "3F5E95C0-0F43-4ed4-93D2-C89A45D59B81";
        public const string IWMDMObjectInfo = "1DCB3A09-33ED-11d3-8470-00C04F79DBC0";
        public const string IWMDMOperation = "1DCB3A0B-33ED-11d3-8470-00C04F79DBC0";
        public const string IWMDMOperation2 = "33445B48-7DF7-425c-AD8F-0FC6D82F9F75";
        public const string IWMDMOperation3 = "d1f9b46a-9ca8-46d8-9d0f-1ec9bae54919";
        public const string IWMDMProgress = "1DCB3A0C-33ED-11d3-8470-00C04F79DBC0";
        public const string IWMDMProgress2 = "3A43F550-B383-4e92-B04A-E6BBC660FEFC";
        public const string IWMDMProgress3 = "21DE01CB-3BB4-4929-B21A-17AF3F80F658";
        public const string IWMDMRevoked = "EBECCEDB-88EE-4e55-B6A4-8D9F07D696AA";
        public const string IWMDMStorage = "1DCB3A06-33ED-11d3-8470-00C04F79DBC0";
        public const string IWMDMStorage2 = "1ED5A144-5CD5-4683-9EFF-72CBDB2D9533";
        public const string IWMDMStorage3 = "97717EEA-926A-464e-96A4-247B0216026E";
        public const string IWMDMStorage4 = "c225bac5-a03a-40b8-9a23-91cf478c64a6";
        public const string IWMDMStorageControl = "1DCB3A08-33ED-11d3-8470-00C04F79DBC0";
        public const string IWMDMStorageControl2 = "972C2E88-BD6C-4125-8E09-84F837E637B6";
        public const string IWMDMStorageControl3 = "B3266365-D4F3-4696-8D53-BD27EC60993A";
        public const string IWMDMStorageGlobals = "1DCB3A07-33ED-11d3-8470-00C04F79DBC0";
        public const string IWMDMLogger = "110A3200-5A79-11d3-8D78-444553540000";

    }

}

namespace Microsoft.WindowsAPICodePack.Win32Native.Guids.Core

{

    public static class COM

    {

        public const string ISpecifyPropertyPages = "B196B28B-BAB4-101A-B69C-00AA00341D07";

    }

    public static class Net

    {

        public const string INetwork = "DCB00002-570F-4A9B-8D69-199FDBA5723B";
        public const string INetworkConnection = "DCB00005-570F-4A9B-8D69-199FDBA5723B";
        public const string INetworkListManager = "DCB00000-570F-4A9B-8D69-199FDBA5723B";
        public const string NetworkListManagerClass = "DCB00C01-570F-4A9B-8D69-199FDBA5723B";

    }

}

namespace Microsoft.WindowsAPICodePack.Win32Native.Guids.Shell
{
    public static class PropertySystem
    {
        public const string IPropertyChangeArray = "380F5CAD-1B5E-42F2-805D-637FD392D31E";
        public const string IPropertyChange = "F917BC8A-1BBA-4478-A245-1BDE03EB9431";

        public static class SystemProperties
        {

            public const string AcquisitionID = "65A98875-3C80-40AB-ABBC-EFDAF77DBEE2";
            public const string PSGUID_MediaFileSummaryInformation = "64440492-4C8B-11D1-8B70-080036B11A03";
            public const string DateAcquired = "2CBAA8F5-D81F-47CA-B17A-F8D822300131";
            public const string DateArchived = "43F8D7B7-A444-4F87-9383-52271C9B915C";
            public const string DateCompleted = "72FAB781-ACDA-43E5-B155-B2434F85E678";
            public const string DueDate = "3F8472B5-E0AF-4DB2-8071-C53FE76AE7CE";
            public const string EndDate = "C75FAA05-96FD-49E7-9CB4-9F601082D553";
            public const string FileExtension = "E4F10A3C-49E6-405D-8288-A23BD4EEAA6C";
            public const string FileName = "41CF5AE0-F75A-4806-BD87-59C7D9248EB9";
            public const string FlagColor = "67DF94DE-0CA7-4D6F-B792-053A3E4F03CF";
            public const string FlagColorText = "45EAE747-8E2A-40AE-8CBF-CA52ABA6152A";
            public const string FlagStatus = "E3E0584C-B788-4A5A-BB20-7F5A44C9ACDD";
            public const string FlagStatusText = "DC54FD2E-189D-4871-AA01-08C2F57A4ABC";
            public const string FullText = "1E3EE840-BC2B-476C-8237-2ACD1A839B22";
            public const string IdentityProperty = "A26F4AFC-7346-4299-BE47-EB1AE613139F";
            public const string ImageParsingName = "D7750EE0-C6A4-48EC-B53E-B87B52E6D073";
            public const string Importance = "E3E0584C-B788-4A5A-BB20-7F5A44C9ACDD";
            public const string ImportanceText = "A3B29791-7713-4E1D-BB40-17DB85F01831";
            public const string InfoTipText = "C9944A21-A406-48FE-8225-AEC7E24C211B";
            public const string IsAttachment = "F23F425C-71A1-4FA8-922F-678EA4A60408";
            public const string IsDefaultNonOwnerSaveLocation = "5D76B67F-9B3D-44BB-B6AE-25DA4F638A67";
            public const string IsDefaultSaveLocation = "5D76B67F-9B3D-44BB-B6AE-25DA4F638A67";
            public const string IsDeleted = "5CDA5FC8-33EE-4FF3-9094-AE7BD8868C4D";
            public const string IsEncrypted = "90E5E14E-648B-4826-B2AA-ACAF790E3513";
            public const string IsFlagged = "5DA84765-E3FF-4278-86B0-A27967FBDD03";

            public static class FormatIdentifiersGuids
            {

                public const string SummaryInformation = "F29F85E0-4FF9-1068-AB91-08002B27B3D9";
                public const string Volume = "9B174B35-40FF-11D2-A27E-00C04FC30871";
                public const string DocumentSummaryInformation = "D5CDD502-2E9C-101B-9397-08002B2CF9AE";
                public const string ShellDetails = "28636AA6-953D-11D2-B5D6-00C04FD918D0";
                public const string Storage = "B725F130-47EF-101A-A5F1-02608C9EEBAC";
                public const string Version = "0CEF7D53-FA64-11D1-A203-0000F81FEDEE";
                public const string Misc = "9B174B34-40FF-11D2-A27E-00C04FC30871";
                public const string Query = "49691C90-7E17-101A-A91C-08002B2ECDA9";
                public const string ImageProperties = "14B81DA1-0135-4D31-96D9-6CBFC9671A99";
                public const string IntSite = "000214A1-0000-0000-C000-000000000046";

            }

        }
    }

    public static class ShellIIDGuid
    {

        // IID GUID strings for relevant Shell COM interfaces.
        public const string IModalWindow = "B4DB1657-70D7-485E-8E3E-6FCB5A5C1802";
        public const string IFileDialog = "42F85136-DB7E-439C-85F1-E4075D135FC8";
        public const string IFileOpenDialog = "D57C7288-D4AD-4768-BE02-9D969532D960";
        public const string IFileSaveDialog = "84BCCD23-5FDE-4CDB-AEA4-AF64B83D78AB";
        public const string IFileDialogEvents = "973510DB-7D7F-452B-8975-74A85828D354";
        public const string IFileDialogControlEvents = "36116642-D713-4B97-9B83-7484A9D00433";
        public const string IFileDialogCustomize = "E6FDD21A-163F-4975-9C8C-A69F1BA37034";

        public const string IShellItem = "43826D1E-E718-42EE-BC55-A1E261C37BFE";
        public const string IShellItem2 = "7E9FB0D3-919F-4307-AB2E-9B1860310C93";
        public const string IShellItemArray = "B63EA76D-1F85-456F-A19C-48159EFA858B";
        public const string IShellLibrary = "11A66EFA-382E-451A-9234-1E0E12EF3085";
        public const string IThumbnailCache = "F676C15D-596A-4ce2-8234-33996F445DB1";
        public const string ISharedBitmap = "091162a4-bc96-411f-aae8-c5122cd03363";
        public const string IShellFolder = "000214E6-0000-0000-C000-000000000046";
        public const string IShellFolder2 = "93F2F68C-1D1B-11D3-A30E-00C04F79ABD1";
        public const string IEnumIDList = "000214F2-0000-0000-C000-000000000046";
        public const string IShellLinkW = "000214F9-0000-0000-C000-000000000046";
        public const string CShellLink = "00021401-0000-0000-C000-000000000046";

        public const string IPropertyStore = "886D8EEB-8CF2-4446-8D02-CDBA1DBDCF99";
        public const string IPropertyStoreCache = "3017056d-9a91-4e90-937d-746c72abbf4f";
        public const string IPropertyDescription = "6F79D558-3E96-4549-A1D1-7D75D2288814";
        public const string IPropertyDescription2 = "57D2EDED-5062-400E-B107-5DAE79FE57A6";
        public const string IPropertyDescriptionList = "1F9FC1D0-C39B-4B26-817F-011967D3440E";
        public const string IPropertyEnumType = "11E1FBF9-2D56-4A6B-8DB3-7CD193A471F2";
        public const string IPropertyEnumType2 = "9B6E051C-5DDD-4321-9070-FE2ACB55E794";
        public const string IPropertyEnumTypeList = "A99400F4-3D84-4557-94BA-1242FB2CC9A6";
        public const string IPropertyStoreCapabilities = "c8e2d566-186e-4d49-bf41-6909ead56acc";

        public const string ICondition = "0FC988D4-C935-4b97-A973-46282EA175C8";
        public const string ISearchFolderItemFactory = "a0ffbc28-5482-4366-be27-3e81e78e06c2";
        public const string IConditionFactory = "A5EFE073-B16F-474f-9F3E-9F8B497A3E08";
        public const string IRichChunk = "4FDEF69C-DBC9-454e-9910-B34F3C64B510";
        public const string IPersistStream = "00000109-0000-0000-C000-000000000046";
        public const string IPersist = "0000010c-0000-0000-C000-000000000046";
        public const string IEnumUnknown = "00000100-0000-0000-C000-000000000046";
        public const string IQuerySolution = "D6EBC66B-8921-4193-AFDD-A1789FB7FF57";
        public const string IQueryParser = "2EBDEE67-3505-43f8-9946-EA44ABC8E5B0";
        public const string IQueryParserManager = "A879E3C4-AF77-44fb-8F37-EBD1487CF920";
        public const string IEntity = "24264891-E80B-4fd3-B7CE-4FF2FAE8931F";
        public const string IFileOperation = "947AAB5F-0A5C-4C13-B4D6-4BF7836FC9F8";
    }

    public static class ShellCLSIDGuid
    {

        // CLSID GUID strings for relevant coclasses.
        public const string FileOpenDialog = "DC1C5A9C-E88A-4DDE-A5A1-60F82A20AEF7";
        public const string FileSaveDialog = "C0B4E2F3-BA21-4773-8DBA-335EC946EB8B";
        public const string KnownFolderManager = "4DF0C730-DF9D-4AE3-9153-AA6B82E9795A";
        public const string ShellLibrary = "D9B3211D-E57F-4426-AAEF-30A806ADD397";
        public const string SearchFolderItemFactory = "14010e02-bbbd-41f0-88e3-eda371216584";
        public const string ConditionFactory = "E03E85B0-7BE3-4000-BA98-6C13DE9FA486";
        public const string QueryParserManager = "5088B39A-29B4-4d9d-8245-4EE289222F66";
    }

    public static class ShellKFIDGuid
    {

        public const string ComputerFolder = "0AC0837C-BBF8-452A-850D-79D08E667CA7";
        public const string Favorites = "1777F761-68AD-4D8A-87BD-30B759FA33DD";
        public const string Documents = "FDD39AD0-238F-46AF-ADB4-6C85480369C7";
        public const string Profile = "5E6C858F-0E22-4760-9AFE-EA3317B67173";

        public const string GenericLibrary = "5c4f28b5-f869-4e84-8e60-f11db97c5cc7";
        public const string DocumentsLibrary = "7d49d726-3c21-4f05-99aa-fdc2c9474656";
        public const string MusicLibrary = "94d6ddcc-4a68-4175-a374-bd584a510b78";
        public const string PicturesLibrary = "b3690e58-e961-423b-b687-386ebfd83239";
        public const string VideosLibrary = "5fa96407-7e77-483c-ac93-691d05850de8";

        public const string Libraries = "1B3EA5DC-B587-4786-B4EF-BD1DC332AEAE";
    }

    public static class ShellBHIDGuid
    {
        public const string ShellFolderObject = "3981e224-f559-11d3-8e3a-00c04f6837d5";
    }

    public static class KnownFoldersIIDGuid
    {
        // IID GUID strings for relevant Shell COM interfaces.
        public const string IKnownFolder = "3AA7AF7E-9B36-420c-A8E3-F77D4674A488";
        public const string IKnownFolderManager = "8BE2D872-86AA-4d47-B776-32CCA40C7018";
    }

    public static class KnownFoldersCLSIDGuid
    {
        // CLSID GUID strings for relevant coclasses.
        public const string KnownFolderManager = "4df0c730-df9d-4ae3-9153-aa6b82e9795a";
    }

    public static class KnownFoldersKFIDGuid
    {
        public const string ComputerFolder = "0AC0837C-BBF8-452A-850D-79D08E667CA7";
        public const string Favorites = "1777F761-68AD-4D8A-87BD-30B759FA33DD";
        public const string Documents = "FDD39AD0-238F-46AF-ADB4-6C85480369C7";
        public const string Profile = "5E6C858F-0E22-4760-9AFE-EA3317B67173";
    }

    public static class FolderTypes
    {
        /// <summary>
        /// No particular content type has been detected or specified. This value is not supported in Windows 7 and later systems.
        /// </summary>
        public static string NotSpecified = "0x5c4f28b5-0xf869-0x4e84-0x8e-0x60-0xf1-0x1d-0xb9-0x7c-0x5c-0xc7";

        /// <summary>
        /// The folder is invalid. There are several things that can cause this judgement: hard disk errors-file system errors-and compression errors among them.
        /// </summary>
        public static string Invalid = "0x57807898-0x8c4f-0x4462-0xbb-0x63-0x71-0x04-0x23-0x80-0xb1-0x09";

        /// <summary>
        /// The folder contains document files. These can be of mixed format.doc-.txt-and others.
        /// </summary>
        public static string Documents = "0x7d49d726-0x3c21-0x4f05-0x99-0xaa-0xfd-0xc2-0xc9-0x47-0x46-0x56";

        /// <summary>
        /// Image files-such as .jpg-.tif-or .png files.
        /// </summary>
        public static string Pictures = "0xb3690e58-0xe961-0x423b-0xb6-0x87-0x38-0x6e-0xbf-0xd8-0x32-0x39";

        /// <summary>
        /// Windows 7 and later. The folder contains audio files-such as .mp3 and .wma files.
        /// </summary>
        public static string Music = "0xaf9c03d6-0x7db9-0x4a15-0x94-0x64-0x13-0xbf-0x9f-0xb6-0x9a-0x2a";

        /// <summary>
        /// A list of music files displayed in Icons view. This value is not supported in Windows 7 and later systems.
        /// </summary>
        public static string MusicIcons = "0x0b7467fb-0x84ba-0x4aae-0xa0-0x9b-0x15-0xb7-0x10-0x97-0xaf-0x9e";

        /// <summary>
        /// The folder is the Games folder found in the Start menu.
        /// </summary>
        public static string Games = "0xb689b0d0-0x76d3-0x4cbb-0x87-0xf7-0x58-0x5d-0x0e-0x0c-0xe0-0x70";

        /// <summary>
        /// The Control Panel in category view. This is a virtual folder.
        /// </summary>
        public static string ControlPanelCategory = "0xde4f0660-0xfa10-0x4b8f-0xa4-0x94-0x06-0x8b-0x20-0xb2-0x23-0x07";

        /// <summary>
        /// The Control Panel in classic view. This is a virtual folder.
        /// </summary>
        public static string ControlPanelClassic = "0x0c3794f3-0xb545-0x43aa-0xa3-0x29-0xc3-0x74-0x30-0xc5-0x8d-0x2a";

        /// <summary>
        /// Printers that have been added to the system. This is a virtual folder.
        /// </summary>
        public static string Printers = "0x2c7bbec6-0xc844-0x4a0a-0x91-0xfa-0xce-0xf6-0xf5-0x9c-0xfd-0xa1";

        /// <summary>
        /// The Recycle Bin. This is a virtual folder.
        /// </summary>
        public static string RecycleBin = "0xd6d9e004-0xcd87-0x442b-0x9d-0x57-0x5e-0x0a-0xeb-0x4f-0x6f-0x72";

        /// <summary>
        /// The software explorer window used by the Add or Remove Programs control panel icon.
        /// </summary>
        public static string SoftwareExplorer = "0xd674391b-0x52d9-0x4e07-0x83-0x4e-0x67-0xc9-0x86-0x10-0xf3-0x9d";

        /// <summary>
        /// The folder is a compressed archive-such as a compressed file with a .zip file name extension.
        /// </summary>
        public static string CompressedFolder = "0x80213e82-0xbcfd-0x4c4f-0x88-0x17-0xbb-0x27-0x60-0x12-0x67-0xa9";

        /// <summary>
        /// An e-mail-related folder that contains contact information.
        /// </summary>
        public static string Contacts = "0xde2b70ec-0x9bf7-0x4a93-0xbd-0x3d-0x24-0x3f-0x78-0x81-0xd4-0x92";

        /// <summary>
        /// A default library view without a more specific template. This value is not supported in Windows 7 and later systems.
        /// </summary>
        public static string Library = "0x4badfc68-0xc4ac-0x4716-0xa0-0xa0-0x4d-0x5d-0xaa-0x6b-0x0f-0x3e";

        /// <summary>
        /// The Network Explorer folder.
        /// </summary>
        public static string NetworkExplorer = "0x25cc242b-0x9a7c-0x4f51-0x80-0xe0-0x7a-0x29-0x28-0xfe-0xbe-0x42";

        /// <summary>
        /// The folder is the FOLDERID_UsersFiles folder.
        /// </summary>
        public static string UserFiles = "0xcd0fc69b-0x71e2-0x46e5-0x96-0x90-0x5b-0xcd-0x9f-0x57-0xaa-0xb3";

        /// <summary>
        /// Windows 7 and later. The folder contains search results-but they are of mixed or no specific type.
        /// </summary>
        public static string GenericSearchResults = "0x7fde1a1e-0x8b31-0x49a5-0x93-0xb8-0x6b-0xe1-0x4c-0xfa-0x49-0x43";

        /// <summary>
        /// Windows 7 and later. The folder is a library-but of no specified type.
        /// </summary>
        public static string GenericLibrary = "0x5f4eab9a-0x6833-0x4f61-0x89-0x9d-0x31-0xcf-0x46-0x97-0x9d-0x49";

        /// <summary>
        /// Windows 7 and later. The folder contains video files. These can be of mixed format.wmv-.mov-and others.
        /// </summary>
        public static string Videos = "0x5fa96407-0x7e77-0x483c-0xac-0x93-0x69-0x1d-0x05-0x85-0x0d-0xe8";

        /// <summary>
        /// Windows 7 and later. The view shown when the user clicks the Windows Explorer button on the taskbar.
        /// </summary>
        public static string UsersLibraries = "0xc4d98f09-0x6124-0x4fe0-0x99-0x42-0x82-0x64-0x16-0x8-0x2d-0xa9";

        /// <summary>
        /// Windows 7 and later. The homegroup view.
        /// </summary>
        public static string OtherUsers = "0xb337fd00-0x9dd5-0x4635-0xa6-0xd4-0xda-0x33-0xfd-0x10-0x2b-0x7a";

        /// <summary>
        /// Windows 7 and later. A folder that contains communication-related files such as e-mails-calendar information-and contact information.
        /// </summary>
        public static string Communications = "0x91475fe5-0x586b-0x4eba-0x8d-0x75-0xd1-0x74-0x34-0xb8-0xcd-0xf6";

        /// <summary>
        /// Windows 7 and later. The folder contains recorded television broadcasts.
        /// </summary>
        public static string RecordedTV = "0x5557a28f-0x5da6-0x4f83-0x88-0x09-0xc2-0xc9-0x8a-0x11-0xa6-0xfa";

        /// <summary>
        /// Windows 7 and later. The folder contains saved game states.
        /// </summary>
        public static string SavedGames = "0xd0363307-0x28cb-0x4106-0x9f-0x23-0x29-0x56-0xe3-0xe5-0xe0-0xe7";

        /// <summary>
        /// Windows 7 and later. The folder contains federated search OpenSearch results.
        /// </summary>
        public static string OpenSearch = "0x8faf9629-0x1980-0x46ff-0x80-0x23-0x9d-0xce-0xab-0x9c-0x3e-0xe3";

        /// <summary>
        /// Windows 7 and later. Before you search.
        /// </summary>
        public static string SearchConnector = "0x982725ee-0x6f47-0x479e-0xb4-0x47-0x81-0x2b-0xfa-0x7d-0x2e-0x8f";

        /// <summary>
        /// Windows 7 and later. A user's Searches folder-normally found at C:\Users\username\Searches.
        /// </summary>
        public static string Searches = "0x0b0ba2e3-0x405f-0x415e-0xa6-0xee-0xca-0xd6-0x25-0x20-0x78-0x53";

    }

}

namespace Microsoft.WindowsAPICodePack.Win32Native.Guids.Shell.FolderIdentifiers

{

    public static class KnownFolders

    {

        #region KnownFolder Guids

        /// <summary>
        /// Computer
        /// </summary>
        public const string Computer = "0x0AC0837C-0xBBF8-0x452A-0x85-0x0D-0x79-0xD0-0x8E-0x66-0x7C-0xA7";

        /// <summary>
        /// Conflicts
        /// </summary>
        public const string Conflict = "0x4bfefb45-0x347d-0x4006-0xa5-0xbe-0xac-0x0c-0xb0-0x56-0x71-0x92";

        /// <summary>
        /// Control Panel
        /// </summary>
        public const string ControlPanel = "0x82A74AEB-0xAEB4-0x465C-0xA0-0x14-0xD0-0x97-0xEE-0x34-0x6D-0x63";

        /// <summary>
        /// Desktop
        /// </summary>
        public const string Desktop = "0xB4BFCC3A-0xDB2C-0x424C-0xB0-0x29-0x7F-0xE9-0x9A-0x87-0xC6-0x41";

        /// <summary>
        /// Internet Explorer
        /// </summary>
        public const string Internet = "0x4D9F7874-0x4E0C-0x4904-0x96-0x7B-0x40-0xB0-0xD2-0x0C-0x3E-0x4B";

        /// <summary>
        /// Network
        /// </summary>
        public const string Network = "0xD20BEEC4-0x5CA8-0x4905-0xAE-0x3B-0xBF-0x25-0x1E-0xA0-0x9B-0x53";

        /// <summary>
        /// Printers
        /// </summary>
        public const string Printers = "0x76FC4E2D-0xD6AD-0x4519-0xA6-0x63-0x37-0xBD-0x56-0x06-0x81-0x85";

        /// <summary>
        /// Sync Center
        /// </summary>
        public const string SyncManager = "0x43668BF8-0xC14E-0x49B2-0x97-0xC9-0x74-0x77-0x84-0xD7-0x84-0xB7";

        /// <summary>
        /// Network Connections
        /// </summary>
        public const string Connections = "0x6F0CD92B-0x2E97-0x45D1-0x88-0xFF-0xB0-0xD1-0x86-0xB8-0xDE-0xDD";

        /// <summary>
        /// Sync Setup
        /// </summary>
        public const string SyncSetup = "0xf214138-0xb1d3-0x4a90-0xbb-0xa9-0x27-0xcb-0xc0-0xc5-0x38-0x9a";

        /// <summary>
        /// Sync Results
        /// </summary>
        public const string SyncResults = "0x289a9a43-0xbe44-0x4057-0xa4-0x1b-0x58-0x7a-0x76-0xd7-0xe7-0xf9";

        /// <summary>
        /// Recycle Bin
        /// </summary>
        public const string RecycleBin = "0xB7534046-0x3ECB-0x4C18-0xBE-0x4E-0x64-0xCD-0x4C-0xB7-0xD6-0xAC";

        /// <summary>
        /// Fonts
        /// </summary>
        public const string Fonts = "0xFD228CB7-0xAE11-0x4AE3-0x86-0x4C-0x16-0xF3-0x91-0x0A-0xB8-0xFE";

        /// <summary>
        /// Startup
        /// </summary>
        public const string Startup = "0xB97D20BB-0xF46A-0x4C97-0xBA-0x10-0x5E-0x36-0x08-0x43-0x08-0x54";

        /// <summary>
        /// Programs
        /// </summary>
        public const string Programs = "0xA77F5D77-0x2E2B-0x44C3-0xA6-0xA2-0xAB-0xA6-0x01-0x05-0x4A-0x51";

        /// <summary>
        /// Start Menu
        /// </summary>
        public const string StartMenu = "0x625B53C3-0xAB48-0x4EC1-0xBA-0x1F-0xA1-0xEF-0x41-0x46-0xFC-0x19";

        /// <summary>
        /// Recent Items
        /// </summary>
        public const string Recent = "0xAE50C081-0xEBD2-0x438A-0x86-0x55-0x8A-0x09-0x2E-0x34-0x98-0x7A";

        /// <summary>
        /// SendTo
        /// </summary>
        public const string SendTo = "0x8983036C-0x27C0-0x404B-0x8F-0x08-0x10-0x2D-0x10-0xDC-0xFD-0x74";

        /// <summary>
        /// Documents
        /// </summary>
        public const string Documents = "0xFDD39AD0-0x238F-0x46AF-0xAD-0xB4-0x6C-0x85-0x48-0x03-0x69-0xC7";

        /// <summary>
        /// Favorites
        /// </summary>
        public const string Favorites = "0x1777F761-0x68AD-0x4D8A-0x87-0xBD-0x30-0xB7-0x59-0xFA-0x33-0xDD";

        /// <summary>
        /// Network Shortcuts
        /// </summary>
        public const string NetHood = "0xC5ABBF53-0xE17F-0x4121-0x89-0x00-0x86-0x62-0x6F-0xC2-0xC9-0x73";

        /// <summary>
        /// Printer Shortcuts
        /// </summary>
        public const string PrintHood = "0x9274BD8D-0xCFD1-0x41C3-0xB3-0x5E-0xB1-0x3F-0x55-0xA7-0x58-0xF4";

        /// <summary>
        /// Templates
        /// </summary>
        public const string Templates = "0xA63293E8-0x664E-0x48DB-0xA0-0x79-0xDF-0x75-0x9E-0x05-0x09-0xF7";

        /// <summary>
        /// Startup
        /// </summary>
        public const string CommonStartup = "0x82A5EA35-0xD9CD-0x47C5-0x96-0x29-0xE1-0x5D-0x2F-0x71-0x4E-0x6E";

        /// <summary>
        /// Programs
        /// </summary>
        public const string CommonPrograms = "0x0139D44E-0x6AFE-0x49F2-0x86-0x90-0x3D-0xAF-0xCA-0xE6-0xFF-0xB8";

        /// <summary>
        /// Start Menu
        /// </summary>
        public const string CommonStartMenu = "0xA4115719-0xD62E-0x491D-0xAA-0x7C-0xE7-0x4B-0x8B-0xE3-0xB0-0x67";

        /// <summary>
        /// Public Desktop
        /// </summary>
        public const string PublicDesktop = "0xC4AA340D-0xF20F-0x4863-0xAF-0xEF-0xF8-0x7E-0xF2-0xE6-0xBA-0x25";

        /// <summary>
        /// ProgramData
        /// </summary>
        public const string ProgramData = "0x62AB5D82-0xFDC1-0x4DC3-0xA9-0xDD-0x07-0x0D-0x1D-0x49-0x5D-0x97";

        /// <summary>
        /// Templates
        /// </summary>
        public const string CommonTemplates = "0xB94237E7-0x57AC-0x4347-0x91-0x51-0xB0-0x8C-0x6C-0x32-0xD1-0xF7";

        /// <summary>
        /// Public Documents
        /// </summary>
        public const string PublicDocuments = "0xED4824AF-0xDCE4-0x45A8-0x81-0xE2-0xFC-0x79-0x65-0x08-0x36-0x34";

        /// <summary>
        /// Roaming
        /// </summary>
        public const string RoamingAppData = "0x3EB685DB-0x65F9-0x4CF6-0xA0-0x3A-0xE3-0xEF-0x65-0x72-0x9F-0x3D";

        /// <summary>
        /// Local
        /// </summary>
        public const string LocalAppData = "0xF1B32785-0x6FBA-0x4FCF-0x9D-0x55-0x7B-0x8E-0x7F-0x15-0x70-0x91";

        /// <summary>
        /// LocalLow
        /// </summary>
        public const string LocalAppDataLow = "0xA520A1A4-0x1780-0x4FF6-0xBD-0x18-0x16-0x73-0x43-0xC5-0xAF-0x16";

        /// <summary>
        /// Temporary Internet Files
        /// </summary>
        public const string InternetCache = "0x352481E8-0x33BE-0x4251-0xBA-0x85-0x60-0x07-0xCA-0xED-0xCF-0x9D";

        /// <summary>
        /// Cookies
        /// </summary>
        public const string Cookies = "0x2B0F765D-0xC0E9-0x4171-0x90-0x8E-0x08-0xA6-0x11-0xB8-0x4F-0xF6";

        /// <summary>
        /// History
        /// </summary>
        public const string History = "0xD9DC8A3B-0xB784-0x432E-0xA7-0x81-0x5A-0x11-0x30-0xA7-0x59-0x63";

        /// <summary>
        /// System32
        /// </summary>
        public const string System = "0x1AC14E77-0x02E7-0x4E5D-0xB7-0x44-0x2E-0xB1-0xAE-0x51-0x98-0xB7";

        /// <summary>
        /// System32
        /// </summary>
        public const string SystemX86 = "0xD65231B0-0xB2F1-0x4857-0xA4-0xCE-0xA8-0xE7-0xC6-0xEA-0x7D-0x27";

        /// <summary>
        /// Windows
        /// </summary>
        public const string Windows = "0xF38BF404-0x1D43-0x42F2-0x93-0x05-0x67-0xDE-0x0B-0x28-0xFC-0x23";

        /// <summary>
        /// The user's username (%USERNAME%"
        /// </summary>
        public const string Profile = "0x5E6C858F-0x0E22-0x4760-0x9A-0xFE-0xEA-0x33-0x17-0xB6-0x71-0x73";

        /// <summary>
        /// Pictures
        /// </summary>
        public const string Pictures = "0x33E28130-0x4E1E-0x4676-0x83-0x5A-0x98-0x39-0x5C-0x3B-0xC3-0xBB";

        /// <summary>
        /// Program Files
        /// </summary>
        public const string ProgramFilesX86 = "0x7C5A40EF-0xA0FB-0x4BFC-0x87-0x4A-0xC0-0xF2-0xE0-0xB9-0xFA-0x8E";

        /// <summary>
        /// Common Files
        /// </summary>
        public const string ProgramFilesCommonX86 = "0xDE974D24-0xD9C6-0x4D3E-0xBF-0x91-0xF4-0x45-0x51-0x20-0xB9-0x17";

        /// <summary>
        /// Program Files
        /// </summary>
        public const string ProgramFilesX64 = "0x6d809377-0x6af0-0x444b-0x89-0x57-0xa3-0x77-0x3f-0x02-0x20-0x0e";

        /// <summary>
        /// Common Files
        /// </summary>
        public const string ProgramFilesCommonX64 = "0x6365d5a7-0xf0d-0x45e5-0x87-0xf6-0xd-0xa5-0x6b-0x6a-0x4f-0x7d";

        /// <summary>
        /// Program Files
        /// </summary>
        public const string ProgramFiles = "0x905e63b6-0xc1bf-0x494e-0xb2-0x9c-0x65-0xb7-0x32-0xd3-0xd2-0x1a";

        /// <summary>
        /// Common Files
        /// </summary>
        public const string ProgramFilesCommon = "0xF7F1ED05-0x9F6D-0x47A2-0xAA-0xAE-0x29-0xD3-0x17-0xC6-0xF0-0x66";

        /// <summary>
        /// Administrative Tools
        /// </summary>
        public const string AdminTools = "0x724EF170-0xA42D-0x4FEF-0x9F-0x26-0xB6-0x0E-0x84-0x6F-0xBA-0x4F";

        /// <summary>
        /// Administrative Tools
        /// </summary>
        public const string CommonAdminTools = "0xD0384E7D-0xBAC3-0x4797-0x8F-0x14-0xCB-0xA2-0x29-0xB3-0x92-0xB5";

        /// <summary>
        /// Music
        /// </summary>
        public const string Music = "0x4BD8D571-0x6D19-0x48D3-0xBE-0x97-0x42-0x22-0x20-0x08-0x0E-0x43";

        /// <summary>
        /// Videos
        /// </summary>
        public const string Videos = "0x18989B1D-0x99B5-0x455B-0x84-0x1C-0xAB-0x7C-0x74-0xE4-0xDD-0xFC";

        /// <summary>
        /// Public Pictures
        /// </summary>
        public const string PublicPictures = "0xB6EBFB86-0x6907-0x413C-0x9A-0xF7-0x4F-0xC2-0xAB-0xF0-0x7C-0xC5";

        /// <summary>
        /// Public Music
        /// </summary>
        public const string PublicMusic = "0x3214FAB5-0x9757-0x4298-0xBB-0x61-0x92-0xA9-0xDE-0xAA-0x44-0xFF";

        /// <summary>
        /// Public Videos
        /// </summary>
        public const string PublicVideos = "0x2400183A-0x6185-0x49FB-0xA2-0xD8-0x4A-0x39-0x2A-0x60-0x2B-0xA3";

        /// <summary>
        /// Resources
        /// </summary>
        public const string ResourceDir = "0x8AD10C31-0x2ADB-0x4296-0xA8-0xF7-0xE4-0x70-0x12-0x32-0xC9-0x72";

        /// <summary>
        /// None
        /// </summary>
        public const string LocalizedResourcesDir = "0x2A00375E-0x224C-0x49DE-0xB8-0xD1-0x44-0x0D-0xF7-0xEF-0x3D-0xDC";

        /// <summary>
        /// OEM Links
        /// </summary>
        public const string CommonOEMLinks = "0xC1BAE2D0-0x10DF-0x4334-0xBE-0xDD-0x7A-0xA2-0x0B-0x22-0x7A-0x9D";

        /// <summary>
        /// Temporary Burn Folder
        /// </summary>
        public const string CDBurning = "0x9E52AB10-0xF80D-0x49DF-0xAC-0xB8-0x43-0x30-0xF5-0x68-0x78-0x55";

        /// <summary>
        /// Users
        /// </summary>
        public const string UserProfiles = "0x0762D272-0xC50A-0x4BB0-0xA3-0x82-0x69-0x7D-0xCD-0x72-0x9B-0x80";

        /// <summary>
        /// Playlists
        /// </summary>
        public const string Playlists = "0xDE92C1C7-0x837F-0x4F69-0xA3-0xBB-0x86-0xE6-0x31-0x20-0x4A-0x23";

        /// <summary>
        /// Sample Playlists
        /// </summary>
        public const string SamplePlaylists = "0x15CA69B3-0x30EE-0x49C1-0xAC-0xE1-0x6B-0x5E-0xC3-0x72-0xAF-0xB5";

        /// <summary>
        /// Sample Music
        /// </summary>
        public const string SampleMusic = "0xB250C668-0xF57D-0x4EE1-0xA6-0x3C-0x29-0x0E-0xE7-0xD1-0xAA-0x1F";

        /// <summary>
        /// Sample Pictures
        /// </summary>
        public const string SamplePictures = "0xC4900540-0x2379-0x4C75-0x84-0x4B-0x64-0xE6-0xFA-0xF8-0x71-0x6B";

        /// <summary>
        /// Sample Videos
        /// </summary>
        public const string SampleVideos = "0x859EAD94-0x2E85-0x48AD-0xA7-0x1A-0x09-0x69-0xCB-0x56-0xA6-0xCD";

        /// <summary>
        /// Slide Shows
        /// </summary>
        public const string PhotoAlbums = "0x69D2CF90-0xFC33-0x4FB7-0x9A-0x0C-0xEB-0xB0-0xF0-0xFC-0xB4-0x3C";

        /// <summary>
        /// Public
        /// </summary>
        public const string Public = "0xDFDF76A2-0xC82A-0x4D63-0x90-0x6A-0x56-0x44-0xAC-0x45-0x73-0x85";

        /// <summary>
        /// Programs and Features
        /// </summary>
        public const string ChangeRemovePrograms = "0xdf7266ac-0x9274-0x4867-0x8d-0x55-0x3b-0xd6-0x61-0xde-0x87-0x2d";

        /// <summary>
        /// Installed Updates
        /// </summary>
        public const string AppUpdates = "0xa305ce99-0xf527-0x492b-0x8b-0x1a-0x7e-0x76-0xfa-0x98-0xd6-0xe4";

        /// <summary>
        /// Get Programs
        /// </summary>
        public const string AddNewPrograms = "0xde61d971-0x5ebc-0x4f02-0xa3-0xa9-0x6c-0x82-0x89-0x5e-0x5c-0x04";

        /// <summary>
        /// Downloads
        /// </summary>
        public const string Downloads = "0x374de290-0x123f-0x4565-0x91-0x64-0x39-0xc4-0x92-0x5e-0x46-0x7b";

        /// <summary>
        /// Public Downloads
        /// </summary>
        public const string PublicDownloads = "0x3d644c9b-0x1fb8-0x4f30-0x9b-0x45-0xf6-0x70-0x23-0x5f-0x79-0xc0";

        /// <summary>
        /// Searches
        /// </summary>
        public const string SavedSearches = "0x7d1d3a04-0xdebb-0x4115-0x95-0xcf-0x2f-0x29-0xda-0x29-0x20-0xda";

        /// <summary>
        /// Quick Launch
        /// </summary>
        public const string QuickLaunch = "0x52a4f021-0x7b75-0x48a9-0x9f-0x6b-0x4b-0x87-0xa2-0x10-0xbc-0x8f";

        /// <summary>
        /// Contacts
        /// </summary>
        public const string Contacts = "0x56784854-0xc6cb-0x462b-0x81-0x69-0x88-0xe3-0x50-0xac-0xb8-0x82";

        /// <summary>
        /// Gadgets
        /// </summary>
        public const string SidebarParts = "0xa75d362e-0x50fc-0x4fb7-0xac-0x2c-0xa8-0xbe-0xaa-0x31-0x44-0x93";

        /// <summary>
        /// Gadgets
        /// </summary>
        public const string SidebarDefaultParts = "0x7b396e54-0x9ec5-0x4300-0xbe-0xa-0x24-0x82-0xeb-0xae-0x1a-0x26";

        /// <summary>
        /// Tree property value folder
        /// </summary>
        public const string TreeProperties = "0x5b3749ad-0xb49f-0x49c1-0x83-0xeb-0x15-0x37-0x0f-0xbd-0x48-0x82";

        /// <summary>
        /// GameExplorer
        /// </summary>
        public const string PublicGameTasks = "0xdebf2536-0xe1a8-0x4c59-0xb6-0xa2-0x41-0x45-0x86-0x47-0x6a-0xea";

        /// <summary>
        /// GameExplorer
        /// </summary>
        public const string GameTasks = "0x54fae61-0x4dd8-0x4787-0x80-0xb6-0x9-0x2-0x20-0xc4-0xb7-0x0";

        /// <summary>
        /// Saved Games
        /// </summary>
        public const string SavedGames = "0x4c5c32ff-0xbb9d-0x43b0-0xb5-0xb4-0x2d-0x72-0xe5-0x4e-0xaa-0xa4";

        /// <summary>
        /// Games
        /// </summary>
        public const string Games = "0xcac52c1a-0xb53d-0x4edc-0x92-0xd7-0x6b-0x2e-0x8a-0xc1-0x94-0x34";

        /// <summary>
        /// Recorded TV
        /// </summary>
        public const string RecordedTV = "0xbd85e001-0x112e-0x431e-0x98-0x3b-0x7b-0x15-0xac-0x09-0xff-0xf1";

        /// <summary>
        /// Microsoft Office Outlook
        /// </summary>
        public const string SearchMapi = "0x98ec0e18-0x2098-0x4d44-0x86-0x44-0x66-0x97-0x93-0x15-0xa2-0x81";

        /// <summary>
        /// Offline Files
        /// </summary>
        public const string SearchCsc = "0xee32e446-0x31ca-0x4aba-0x81-0x4f-0xa5-0xeb-0xd2-0xfd-0x6d-0x5e";

        /// <summary>
        /// Links
        /// </summary>
        public const string Links = "0xbfb9d5e0-0xc6a9-0x404c-0xb2-0xb2-0xae-0x6d-0xb6-0xaf-0x49-0x68";

        /// <summary>
        /// The user's full name (for instance-Jean Philippe Bagel" entered when the user account was created.
        /// </summary>
        public const string UsersFiles = "0xf3ce0f7c-0x4901-0x4acc-0x86-0x48-0xd5-0xd4-0x4b-0x04-0xef-0x8f";

        /// <summary>
        /// Search home
        /// </summary>
        public const string SearchHome = "0x190337d1-0xb8ca-0x4121-0xa6-0x39-0x6d-0x47-0x2d-0x16-0x97-0x2a";

        /// <summary>
        /// Original Images
        /// </summary>
        public const string OriginalImages = "0x2C36C0AA-0x5812-0x4b87-0xbf-0xd0-0x4c-0xd0-0xdf-0xb1-0x9b-0x39";

        #endregion

        public static class Win7

        {

            #region Win7 KnownFolders Guids

            /// <summary>
            /// UserProgramFiles
            /// </summary>
            public const string UserProgramFiles = "0x5cd7aee2-0x2219-0x4a67-0xb8-0x5d-0x6c-0x9c-0xe1-0x56-0x60-0xcb";

            /// <summary>
            /// UserProgramFilesCommon
            /// </summary>
            public const string UserProgramFilesCommon = "0xbcbd3057-0xca5c-0x4622-0xb4-0x2d-0xbc-0x56-0xdb-0x0a-0xe5-0x16";

            /// <summary>
            /// Ringtones
            /// </summary>
            public const string Ringtones = "0xC870044B-0xF49E-0x4126-0xA9-0xC3-0xB5-0x2A-0x1F-0xF4-0x11-0xE8";

            /// <summary>
            /// PublicRingtones
            /// </summary>
            public const string PublicRingtones = "0xE555AB60-0x153B-0x4D17-0x9F-0x04-0xA5-0xFE-0x99-0xFC-0x15-0xEC";

            /// <summary>
            /// UsersLibraries
            /// </summary>
            public const string UsersLibraries = "0xa302545d-0xdeff-0x464b-0xab-0xe8-0x61-0xc8-0x64-0x8d-0x93-0x9b";

            /// <summary>
            /// DocumentsLibrary
            /// </summary>
            public const string DocumentsLibrary = "0x7b0db17d-0x9cd2-0x4a93-0x97-0x33-0x46-0xcc-0x89-0x02-0x2e-0x7c";

            /// <summary>
            /// MusicLibrary
            /// </summary>
            public const string MusicLibrary = "0x2112ab0a-0xc86a-0x4ffe-0xa3-0x68-0xd-0xe9-0x6e-0x47-0x1-0x2e";

            /// <summary>
            /// PicturesLibrary
            /// </summary>
            public const string PicturesLibrary = "0xa990ae9f-0xa03b-0x4e80-0x94-0xbc-0x99-0x12-0xd7-0x50-0x41-0x4";

            public const string CameraRollLibrary = "2b20df75-1eda-4039-8097-38798227d5b7";

            public const string SavedPicturesLibrary = "e25b5812-be88-4bd9-94b0-29233477b6c3";

            /// <summary>
            /// VideosLibrary
            /// </summary>
            public const string VideosLibrary = "0x491e922f-0x5643-0x4af4-0xa7-0xeb-0x4e-0x7a-0x13-0x8d-0x81-0x74";

            /// <summary>
            /// RecordedTVLibrary
            /// </summary>
            public const string RecordedTVLibrary = "0x1a6fdba2-0xf42d-0x4358-0xa7-0x98-0xb7-0x4d-0x74-0x59-0x26-0xc5";

            /// <summary>
            /// OtherUsers
            /// </summary>
            public const string OtherUsers = "0x52528a6b-0xb9e3-0x4add-0xb6-0xd-0x58-0x8c-0x2d-0xba-0x84-0x2d";

            /// <summary>
            /// DeviceMetadataStore
            /// </summary>
            public const string DeviceMetadataStore = "0x5ce4a5e9-0xe4eb-0x479d-0xb8-0x9f-0x13-0x0c-0x02-0x88-0x61-0x55";

            /// <summary>
            /// Libraries
            /// </summary>
            public const string Libraries = "0x1b3ea5dc-0xb587-0x4786-0xb4-0xef-0xbd-0x1d-0xc3-0x32-0xae-0xae";

            /// <summary>
            /// UserPinned
            /// </summary>
            public const string UserPinned = "0x9e3995ab-0x1f9c-0x4f13-0xb8-0x27-0x48-0xb2-0x4b-0x6c-0x71-0x74";

            /// <summary>
            /// ImplicitAppShortcuts
            /// </summary>
            public const string ImplicitAppShortcuts = "0xbcb5256f-0x79f6-0x4cee-0xb7-0x25-0xdc-0x34-0xe4-0x2-0xfd-0x46";

            #endregion

        }

    }

}

namespace Microsoft.WindowsAPICodePack.Win32Native.Guids.ExtendedLinguisticServices
{

    /// <summary>
    /// This class contains constants describing the existing ELS services for Windows 7.
    /// </summary>
    public static class MappingAvailableServices
    {
        /// <summary>
        /// The guid of the Microsoft Language Detection service.
        /// </summary>
        public const string LanguageDetection = "CF7E00B1-909B-4d95-A8F4-611F7C377702";

        /// <summary>
        /// The guid of the Microsoft Script Detection service.
        /// </summary>
        public const string ScriptDetection = "2D64B439-6CAF-4f6b-B688-E5D0F4FAA7D7";

        /// <summary>
        /// The guid of the Microsoft Traditional Chinese to Simplified Chinese Transliteration service.
        /// </summary>        
        public const string TransliterationHantToHans = "A3A8333B-F4FC-42f6-A0C4-0462FE7317CB";

        /// <summary>
        /// The guid of the Microsoft Simplified Chinese to Traditional Chinese Transliteration service.
        /// </summary>
        public const string TransliterationHansToHant = "3CACCDC8-5590-42dc-9A7B-B5A6B5B3B63B";

        /// <summary>
        /// The guid of the Microsoft Malayalam to Latin Transliteration service.
        /// </summary>
        public const string TransliterationMalayalamToLatin = "D8B983B1-F8BF-4a2b-BCD5-5B5EA20613E1";

        /// <summary>
        /// The guid of the Microsoft Devanagari to Latin Transliteration service.
        /// </summary>        
        public const string TransliterationDevanagariToLatin = "C4A4DCFE-2661-4d02-9835-F48187109803";

        /// <summary>
        /// The guid of the Microsoft Cyrillic to Latin Transliteration service.
        /// </summary>
        public const string TransliterationCyrillicToLatin = "3DD12A98-5AFD-4903-A13F-E17E6C0BFE01";

        /// <summary>
        /// The guid of the Microsoft Bengali to Latin Transliteration service.
        /// </summary>
        public const string TransliterationBengaliToLatin = "F4DFD825-91A4-489f-855E-9AD9BEE55727";
    }

}

#endregion