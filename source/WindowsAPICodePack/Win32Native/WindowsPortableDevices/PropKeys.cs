using Microsoft.WindowsAPICodePack.Win32Native.PortableDevices;
using Microsoft.WindowsAPICodePack.Win32Native.Shell.PropertySystem;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.WindowsAPICodePack.Win32Native.PortableDevices
{

    namespace PropertySystem

    {

        public static class Properties
        {
            #region This class defines all Commands-Parameters and Options associated with: WPD_CATEGORY_NULL. This category is used exclusively for the NULL property key define.

            //   [ VT_EMPTY ] A NULL property key.
            public static PropertyKey PropertyNull => new PropertyKey("00000000-0000-0000-0000-000000000000", 0);
            #endregion

            /// <summary>
            /// This class defines all Commands-Parameters and Options associated with: <see cref="Guids.PortableDevices.PropertieSystem.ObjectV1"/> and <see cref="Guids.PortableDevices.PropertieSystem.ObjectV2"/>. This category is for all common object properties.
            /// </summary>
            public static class Object

            {

                /// <summary>
                /// <para>Name: WPD_OBJECT_CONTENT_TYPE</para>
                /// <para>Description: The abstract type for the object content-indicating the kinds of properties and data that may be supported on the object.</para>
                /// <para>Type: VT_CLSID</para>
                /// </summary>
                public static PropertyKey ContentType => new PropertyKey(Guids.PortableDevices.PropertieSystem.ObjectV1, 7);

                /// <summary>
                /// <para>Name: WPD_OBJECT_REFERENCES</para>
                /// <para>Description: <see cref="IPortableDevicePropVariantCollection"/> of type VT_LPWSTR indicating a list of ObjectIDs.</para>
                /// <para>Type: VT_UNKNOWN</para>
                /// </summary>
                public static PropertyKey References => new PropertyKey(Guids.PortableDevices.PropertieSystem.ObjectV1, 14);

                /// <summary>
                /// <para>Name: WPD_OBJECT_CONTAINER_FUNCTIONAL_OBJECT_ID</para>
                /// <para>Description: Indicates the Object ID of the closest functional object ancestor. For example-objects that represent files/folders under a Storage functional object-will have this property set to the object ID of the storage functional object.</para>
                /// <para>Type: VT_LPWSTR</para>
                /// </summary>
                public static PropertyKey ContainerFunctionalObjectId => new PropertyKey(Guids.PortableDevices.PropertieSystem.ObjectV1, 23);

                /// <summary>
                /// <para>Name: WPD_OBJECT_GENERATE_THUMBNAIL_FROM_RESOURCE</para>
                /// <para>Description: Indicates whether the thumbnail for this object should be generated from the default resource.</para>
                /// <para>Type: VT_BOOL</para>
                /// </summary>
                public static PropertyKey GenerateThumbnailFromResource => new PropertyKey(Guids.PortableDevices.PropertieSystem.ObjectV1, 24);

                /// <summary>
                /// <para>Name: WPD_OBJECT_HINT_LOCATION_DISPLAY_NAME</para>
                /// <para>Description: If this object appears as a hint location-this property indicates the hint-specific name to display instead of the object name.</para>
                /// <para>Type: VT_LPWSTR</para>
                /// </summary>
                public static PropertyKey HintLocationDisplayName => new PropertyKey(Guids.PortableDevices.PropertieSystem.ObjectV1, 25);

                /// <summary>
                /// <para>Name: WPD_OBJECT_SUPPORTED_UNITS</para>
                /// <para>Description: Indicates the units supported on this object.</para>
                /// <para>Type: VT_UI4</para>
                /// </summary>
                public static PropertyKey SupportedUnits => new PropertyKey(Guids.PortableDevices.PropertieSystem.ObjectV2, 2);

            }

            /// <summary>
            /// <para>Name: WPD_FUNCTIONAL_OBJECT_CATEGORY</para>
            /// <para>Description: Indicates the object's functional category.</para>
            /// <para>Type: VT_CLSID</para>
            /// </summary>
            public static PropertyKey Category => new PropertyKey(Guids.PortableDevices.PropertieSystem.FunctionalObjectV1, 2);

            /// <summary>
            /// This class defines all Commands-Parameters and Options associated with: <see cref="Guids.PortableDevices.PropertieSystem.StorageObjectV1"/>. This category is for properties common to all objects whose functional category is <see cref="Guids.PortableDevices.PropertieSystem.FunctionalCategory.Storage"/>.
            /// </summary>
            public static class Storage

            {

                /// <summary>
                /// <para>Name: WPD_STORAGE_TYPE</para>
                /// <para>Description: Indicates the type of storage e.g. fixed-removable etc.</para>
                /// <para>Type: VT_UI4</para>
                /// </summary>
                public static PropertyKey Type => new PropertyKey(Guids.PortableDevices.PropertieSystem.StorageObjectV1, 2);

                /// <summary>
                /// <para>Name: WPD_STORAGE_FILE_SYSTEM_TYPE</para>
                /// <para>Description: Indicates the file system type e.g. "FAT32" or "NTFS" or "My Special File System"</para>
                /// <para>Type: VT_LPWSTR</para>
                /// </summary>
                public static PropertyKey FileSystemType => new PropertyKey(Guids.PortableDevices.PropertieSystem.StorageObjectV1, 3);

                /// <summary>
                /// <para>Name: WPD_STORAGE_CAPACITY</para>
                /// <para>Description: Indicates the total storage capacity in bytes.</para>
                /// <para>Type: VT_UI8</para>
                /// </summary>
                public static PropertyKey Capacity => new PropertyKey(Guids.PortableDevices.PropertieSystem.StorageObjectV1, 4);

                /// <summary>
                /// <para>Name: WPD_STORAGE_FREE_SPACE_IN_BYTES</para>
                /// <para>Description: Indicates the available space in bytes.</para>
                /// <para>Type: VT_UI8</para>
                /// </summary>
                public static PropertyKey FreeSpaceInBytes => new PropertyKey(Guids.PortableDevices.PropertieSystem.StorageObjectV1, 5);

                /// <summary>
                /// <para>Name: WPD_STORAGE_FREE_SPACE_IN_OBJECTS</para>
                /// <para>Description: Indicates the available space in objects e.g. available slots on a SIM card.</para>
                /// <para>Type: VT_UI8</para>
                /// </summary>
                public static PropertyKey FreeSpaceInObjects => new PropertyKey(Guids.PortableDevices.PropertieSystem.StorageObjectV1, 6);

                /// <summary>
                /// <para>Name: WPD_STORAGE_DESCRIPTION</para>
                /// <para>Description: Contains a description of the storage.</para>
                /// <para>Type: VT_LPWSTR</para>
                /// </summary>
                public static PropertyKey Description => new PropertyKey(Guids.PortableDevices.PropertieSystem.StorageObjectV1, 7);

                /// <summary>
                /// <para>Name: WPD_STORAGE_SERIAL_NUMBER</para>
                /// <para>Description: Contains the serial number of the storage.</para>
                /// <para>Type: VT_LPWSTR</para>
                /// </summary>
                public static PropertyKey SerialNumber => new PropertyKey(Guids.PortableDevices.PropertieSystem.StorageObjectV1, 8);

                /// <summary>
                /// <para>Name: WPD_STORAGE_MAX_OBJECT_SIZE</para>
                /// <para>Description: Specifies the maximum size of a single object (in bytes) that can be placed on this storage.</para>
                /// <para>Type: VT_UI8</para>
                /// </summary>
                public static PropertyKey MaxObjectSize => new PropertyKey(Guids.PortableDevices.PropertieSystem.StorageObjectV1, 9);

                /// <summary>
                /// <para>Name: WPD_STORAGE_CAPACITY_IN_OBJECTS</para>
                /// <para>Description: Indicates the total storage capacity in objects e.g. available slots on a SIM card.</para>
                /// <para>Type: VT_UI8</para>
                /// </summary>
                public static PropertyKey CapacityInObjects => new PropertyKey(Guids.PortableDevices.PropertieSystem.StorageObjectV1, 10);

                /// <summary>
                /// <para>Name: WPD_STORAGE_ACCESS_CAPABILITY</para>
                /// <para>Description: This property identifies any write-protection that globally affects this storage. This takes precedence over access specified on individual objects.</para>
                /// <para>Type: VT_UI4</para>
                /// </summary>
                public static PropertyKey AccessCapability => new PropertyKey(Guids.PortableDevices.PropertieSystem.StorageObjectV1, 11);

            }

            /// <summary>
            /// This class defines all Commands-Parameters and Options associated with: <see cref="Guids.PortableDevices.PropertieSystem.StillImageCaptureObjectV1"/>. This category is for properties common to all objects whose functional category is WPD_FUNCTIONAL_CATEGORY_STILL_IMAGE_CAPTURE
            /// </summary>
            public static class StillImageCapture

            {

                //
                // WPD_STILL_IMAGE_CAPTURE_RESOLUTION  
                //   [ VT_LPWSTR ] Controls the size of the image dimensions to capture in pixel width and height.
                public static PropertyKey Resolution => new PropertyKey(Guids.PortableDevices.PropertieSystem.StillImageCaptureObjectV1, 2);
                //
                // WPD_STILL_IMAGE_CAPTURE_FORMAT  
                //   [ VT_CLSID ] Controls the format of the image to capture.
                public static PropertyKey Format => new PropertyKey(Guids.PortableDevices.PropertieSystem.StillImageCaptureObjectV1, 3);
                //
                // WPD_STILL_IMAGE_COMPRESSION_SETTING  
                //   [ VT_UI8 ] Controls the device-specific quality setting.
                public static PropertyKey CompressionSetting => new PropertyKey(Guids.PortableDevices.PropertieSystem.StillImageCaptureObjectV1, 4);
                //
                // WPD_STILL_IMAGE_WHITE_BALANCE  
                //   [ VT_UI4 ] Controls how the device weights color channels.
                public static PropertyKey WhiteBalance => new PropertyKey(Guids.PortableDevices.PropertieSystem.StillImageCaptureObjectV1, 5);
                //
                // WPD_STILL_IMAGE_RGB_GAIN  
                //   [ VT_LPWSTR ] Controls the RGB gain.
                public static PropertyKey RGBGain => new PropertyKey(Guids.PortableDevices.PropertieSystem.StillImageCaptureObjectV1, 6);
                //
                // WPD_STILL_IMAGE_FNUMBER  
                //   [ VT_UI4 ] Controls the aperture of the lens.
                public static PropertyKey FNumber => new PropertyKey(Guids.PortableDevices.PropertieSystem.StillImageCaptureObjectV1, 7);
                //
                // WPD_STILL_IMAGE_FOCAL_LENGTH  
                //   [ VT_UI4 ] Controls the 35mm equivalent focal length.
                public static PropertyKey FocalLength => new PropertyKey(Guids.PortableDevices.PropertieSystem.StillImageCaptureObjectV1, 8);
                //
                // WPD_STILL_IMAGE_FOCUS_DISTANCE  
                //   [ VT_UI4 ] This property corresponds to the focus distance in millimeters
                public static PropertyKey FocusDistance => new PropertyKey(Guids.PortableDevices.PropertieSystem.StillImageCaptureObjectV1, 9);
                //
                // WPD_STILL_IMAGE_FOCUS_MODE  
                //   [ VT_UI4 ] Identifies the focusing mode used by the device for image capture.
                public static PropertyKey FocusMode => new PropertyKey(Guids.PortableDevices.PropertieSystem.StillImageCaptureObjectV1, 10);
                //
                // WPD_STILL_IMAGE_EXPOSURE_METERING_MODE  
                //   [ VT_UI4 ] Identifies the exposure metering mode used by the device for image capture.
                public static PropertyKey ExposureMeteringMode => new PropertyKey(Guids.PortableDevices.PropertieSystem.StillImageCaptureObjectV1, 11);
                //
                // WPD_STILL_IMAGE_FLASH_MODE  
                //   [ VT_UI4 ] 
                public static PropertyKey FlashMode => new PropertyKey(Guids.PortableDevices.PropertieSystem.StillImageCaptureObjectV1, 12);
                //
                // WPD_STILL_IMAGE_EXPOSURE_TIME  
                //   [ VT_UI4 ] Controls the shutter speed of the device.
                public static PropertyKey ExposureTime => new PropertyKey(Guids.PortableDevices.PropertieSystem.StillImageCaptureObjectV1, 13);
                //
                // WPD_STILL_IMAGE_EXPOSURE_PROGRAM_MODE  
                //   [ VT_UI4 ] Controls the exposure program mode of the device.
                public static PropertyKey ExposureProgramMode => new PropertyKey(Guids.PortableDevices.PropertieSystem.StillImageCaptureObjectV1, 14);
                //
                // WPD_STILL_IMAGE_EXPOSURE_INDEX  
                //   [ VT_UI4 ] Controls the emulation of film speed settings.
                public static PropertyKey ExposureIndex => new PropertyKey(Guids.PortableDevices.PropertieSystem.StillImageCaptureObjectV1, 15);
                //
                // WPD_STILL_IMAGE_EXPOSURE_BIAS_COMPENSATION  
                //   [ VT_I4 ] Controls the adjustment of the auto exposure control.
                public static PropertyKey ExposureBiasCompensation => new PropertyKey(Guids.PortableDevices.PropertieSystem.StillImageCaptureObjectV1, 16);
                //
                // WPD_STILL_IMAGE_CAPTURE_DELAY  
                //   [ VT_UI4 ] Controls the amount of time delay between the capture trigger and the actual data capture (in milliseconds).
                public static PropertyKey CaptureDelay => new PropertyKey(Guids.PortableDevices.PropertieSystem.StillImageCaptureObjectV1, 17);
                //
                // WPD_STILL_IMAGE_CAPTURE_MODE  
                //   [ VT_UI4 ] Controls the type of still image capture.
                public static PropertyKey CaptureMode => new PropertyKey(Guids.PortableDevices.PropertieSystem.StillImageCaptureObjectV1, 18);
                //
                // WPD_STILL_IMAGE_CONTRAST  
                //   [ VT_UI4 ] Controls the perceived contrast of captured images.
                public static PropertyKey Contrast => new PropertyKey(Guids.PortableDevices.PropertieSystem.StillImageCaptureObjectV1, 19);
                //
                // WPD_STILL_IMAGE_SHARPNESS  
                //   [ VT_UI4 ] Controls the perceived sharpness of the captured image.
                public static PropertyKey Sharpness => new PropertyKey(Guids.PortableDevices.PropertieSystem.StillImageCaptureObjectV1, 20);
                //
                // WPD_STILL_IMAGE_DIGITAL_ZOOM  
                //   [ VT_UI4 ] Controls the effective zoom ratio of a digital camera's acquired image scaled by a factor of 10.
                public static PropertyKey DigitalZoom => new PropertyKey(Guids.PortableDevices.PropertieSystem.StillImageCaptureObjectV1, 21);
                //
                // WPD_STILL_IMAGE_EFFECT_MODE  
                //   [ VT_UI4 ] Controls the special effect mode of the capture.
                public static PropertyKey EffectMode => new PropertyKey(Guids.PortableDevices.PropertieSystem.StillImageCaptureObjectV1, 22);
                //
                // WPD_STILL_IMAGE_BURST_NUMBER  
                //   [ VT_UI4 ] Controls the number of images that the device will attempt to capture upon initiation of a burst operation.
                public static PropertyKey BurstNumber => new PropertyKey(Guids.PortableDevices.PropertieSystem.StillImageCaptureObjectV1, 23);
                //
                // WPD_STILL_IMAGE_BURST_INTERVAL  
                //   [ VT_UI4 ] Controls the time delay between captures upon initiation of a burst operation.
                public static PropertyKey BurstInterval => new PropertyKey(Guids.PortableDevices.PropertieSystem.StillImageCaptureObjectV1, 24);
                //
                // WPD_STILL_IMAGE_TIMELAPSE_NUMBER  
                //   [ VT_UI4 ] Controls the number of images that the device will attempt to capture upon initiation of a time-lapse capture.
                public static PropertyKey TimelapseNumber => new PropertyKey(Guids.PortableDevices.PropertieSystem.StillImageCaptureObjectV1, 25);
                //
                // WPD_STILL_IMAGE_TIMELAPSE_INTERVAL  
                //   [ VT_UI4 ] Controls the time delay between captures upon initiation of a time-lapse operation.
                public static PropertyKey TimelapseInterval => new PropertyKey(Guids.PortableDevices.PropertieSystem.StillImageCaptureObjectV1, 26);
                //
                // WPD_STILL_IMAGE_FOCUS_METERING_MODE  
                //   [ VT_UI4 ] Controls which automatic focus mechanism is used by the device.
                public static PropertyKey FocusMeteringMode => new PropertyKey(Guids.PortableDevices.PropertieSystem.StillImageCaptureObjectV1, 27);
                //
                // WPD_STILL_IMAGE_UPLOAD_URL  
                //   [ VT_LPWSTR ] Used to describe the URL that the device may use to upload images upon capture.
                public static PropertyKey UploadUrl => new PropertyKey(Guids.PortableDevices.PropertieSystem.StillImageCaptureObjectV1, 28);
                //
                // WPD_STILL_IMAGE_ARTIST  
                //   [ VT_LPWSTR ] Contains the owner/user of the device-which may be inserted as meta-data into any images that are captured.
                public static PropertyKey Artist => new PropertyKey(Guids.PortableDevices.PropertieSystem.StillImageCaptureObjectV1, 29);
                //
                // WPD_STILL_IMAGE_CAMERA_MODEL  
                //   [ VT_LPWSTR ] Contains the model of the device
                public static PropertyKey CameraModel => new PropertyKey(Guids.PortableDevices.PropertieSystem.StillImageCaptureObjectV1, 30);
                //
                // WPD_STILL_IMAGE_CAMERA_MANUFACTURER  
                //   [ VT_LPWSTR ] Contains the manufacturer of the device
                public static PropertyKey CameraManufacturer => new PropertyKey(Guids.PortableDevices.PropertieSystem.StillImageCaptureObjectV1, 31);

            }

            /// <summary>
            /// This class defines all Commands-Parameters and Options associated with: <see cref="Guids.PortableDevices.PropertieSystem.RenderingInformationObjectV1"/>. This category is for properties common to all objects whose functional category is WPD_FUNCTIONAL_CATEGORY_AUDIO_RENDERING_INFORMATION.
            /// </summary>
            public static class AudioRendering

            {

                //
                // WPD_RENDERING_INFORMATION_PROFILES  
                //   [ VT_UNKNOWN ] IPortableDeviceValuesCollection-where each element indicates the property settings for a supported profile.
                public static PropertyKey Profiles => new PropertyKey(Guids.PortableDevices.PropertieSystem.RenderingInformationObjectV1, 2);
                //
                // WPD_RENDERING_INFORMATION_PROFILE_ENTRY_TYPE  
                //   [ VT_UI4 ] Indicates whether a given entry (i.e. an IPortableDeviceValues) in WPD_RENDERING_INFORMATION_PROFILES relates to an Object or a Resource.
                public static PropertyKey ProfileEntryType => new PropertyKey(Guids.PortableDevices.PropertieSystem.RenderingInformationObjectV1, 3);
                //
                // WPD_RENDERING_INFORMATION_PROFILE_ENTRY_CREATABLE_RESOURCES  
                //   [ VT_UNKNOWN ] This is an IPortableDeviceKeyCollection identifying the resources that can be created on an object with this rendering profile.
                public static PropertyKey ProfileEntryCreatableResources => new PropertyKey(Guids.PortableDevices.PropertieSystem.RenderingInformationObjectV1, 4);

            }

            /// <summary>
            /// This class defines all Commands-Parameters and Options associated with: <see cref="Guids.PortableDevices.PropertieSystem.NetworkAssociationV1"/>. This category is for properties common to all network association objects.
            /// </summary>
            public static class NetworkAssociation

            {
                //
                // WPD_NETWORK_ASSOCIATION_HOST_NETWORK_IDENTIFIERS  
                //   [ VT_VECTOR | VT_UI1 ] The list of EUI-64 host identifiers valid for this association.
                public static PropertyKey HostNetworkIdentifiers => new PropertyKey(Guids.PortableDevices.PropertieSystem.NetworkAssociationV1, 2);
                //
                // WPD_NETWORK_ASSOCIATION_X509V3SEQUENCE  
                //   [ VT_VECTOR | VT_UI1 ] The sequence of X.509 v3 certificates to be provided for TLS server authentication.
                public static PropertyKey X509v3Sequence => new PropertyKey(Guids.PortableDevices.PropertieSystem.NetworkAssociationV1, 3);

            }

            /// <summary>
            /// This class defines all Commands-Parameters and Options associated with: <see cref="Guids.PortableDevices.PropertieSystem.ClientInformationV1"/>.
            /// </summary>
            public static class Client

            {
                /// <summary>
                /// <para>Name: WPD_CLIENT_NAME</para>
                /// <para>Description: Specifies the name the client uses to identify itself.</para>
                /// <para>Type: VT_LPWSTR</para>
                /// <para>FormatID: <see cref="Guids.PortableDevices.PropertieSystem.ClientInformationV1"/>, 2</para>
                /// </summary>
                public static PropertyKey Name => new PropertyKey(Guids.PortableDevices.PropertieSystem.ClientInformationV1, 2);

                /// <summary>
                /// <para>Name: WPD_CLIENT_MAJOR_VERSION</para>
                /// <para>Description: Specifies the major version of the client.</para>
                /// <para>Type: VT_UI4</para>
                /// <para>FormatID: <see cref="Guids.PortableDevices.PropertieSystem.ClientInformationV1"/>, 3</para>
                /// </summary>
                public static PropertyKey MajorVersion => new PropertyKey(Guids.PortableDevices.PropertieSystem.ClientInformationV1, 3);

                /// <summary>
                /// <para>Name: WPD_CLIENT_MINOR_VERSION</para>
                /// <para>Description: Specifies the major version of the client.</para>
                /// <para>Type: VT_UI4</para>
                /// <para>FormatID: <see cref="Guids.PortableDevices.PropertieSystem.ClientInformationV1"/>, 4</para>
                /// </summary>
                public static PropertyKey MinorVersion => new PropertyKey(Guids.PortableDevices.PropertieSystem.ClientInformationV1, 4);

                /// <summary>
                /// <para>Name: WPD_CLIENT_REVISION</para>
                /// <para>Description: Specifies the revision (or build number) of the client.</para>
                /// <para>Type: VT_UI4</para>
                /// <para>FormatID: <see cref="Guids.PortableDevices.PropertieSystem.ClientInformationV1"/>, 5</para>
                /// </summary>
                public static PropertyKey Revision => new PropertyKey(Guids.PortableDevices.PropertieSystem.ClientInformationV1, 5);

                /// <summary>
                /// <para>Name: WPD_CLIENT_WMDRM_APPLICATION_PRIVATE_KEY</para>
                /// <para>Description: Specifies the Windows Media DRM application private key of the client.</para>
                /// <para>Type: VT_VECTOR | VT_UI1</para>
                /// <para>FormatID: <see cref="Guids.PortableDevices.PropertieSystem.ClientInformationV1"/>, 6</para>
                /// </summary>
                public static PropertyKey WMDRMApplicationPrivateKey => new PropertyKey(Guids.PortableDevices.PropertieSystem.ClientInformationV1, 6);

                /// <summary>
                /// <para>Name: WPD_CLIENT_WMDRM_APPLICATION_CERTIFICATE</para>
                /// <para>Description: Specifies the Windows Media DRM application certificate of the client.</para>
                /// <para>Type: VT_VECTOR | VT_UI1</para>
                /// <para>FormatID: <see cref="Guids.PortableDevices.PropertieSystem.ClientInformationV1"/>, 7</para>
                /// </summary>
                public static PropertyKey WMDRMApplicationCertificate => new PropertyKey(Guids.PortableDevices.PropertieSystem.ClientInformationV1, 7);

                /// <summary>
                /// <para>Name: WPD_CLIENT_SECURITY_QUALITY_OF_SERVICE</para>
                /// <para>Description: Specifies the Security Quality of Service for the connection to the driver. This relates to the Security Quality of Service flags for CreateFile. For example-these allow or disallow a driver to impersonate the client.</para>
                /// <para>Type: VT_UI4</para>
                /// <para>FormatID: <see cref="Guids.PortableDevices.PropertieSystem.ClientInformationV1"/>, 8</para>
                /// </summary>
                public static PropertyKey SecurityQualityOfService => new PropertyKey(Guids.PortableDevices.PropertieSystem.ClientInformationV1, 8);

                /// <summary>
                /// <para>Name: WPD_CLIENT_DESIRED_ACCESS</para>
                /// <para>Description: Specifies the desired access the client is requesting to this driver. The possible values are the same as for CreateFile (e.g. GENERIC_READ-GENERIC_WRITE etc.).</para>
                /// <para>Type: VT_UI4</para>
                /// <para>FormatID: <see cref="Guids.PortableDevices.PropertieSystem.ClientInformationV1"/>, 9</para>
                /// </summary>
                public static PropertyKey DesiredAccess => new PropertyKey(Guids.PortableDevices.PropertieSystem.ClientInformationV1, 9);

                /// <summary>
                /// <para>Name: WPD_CLIENT_SHARE_MODE</para>
                /// <para>Description: Specifies the share mode the client is requesting to this driver. The possible values are the same as for CreateFile (e.g. FILE_SHARE_READ-FILE_SHARE_WRITE etc.).</para>
                /// <para>Type: VT_UI4</para>
                /// <para>FormatID: <see cref="Guids.PortableDevices.PropertieSystem.ClientInformationV1"/>, 10</para>
                /// </summary>
                public static PropertyKey ShareMode => new PropertyKey(Guids.PortableDevices.PropertieSystem.ClientInformationV1, 10);

                /// <summary>
                /// <para>Name: WPD_CLIENT_EVENT_COOKIE</para>
                /// <para>Description: Client supplied cookie returned by the driver in events posted as a direct result of operations issued by this client.</para>
                /// <para>Type: VT_LPWSTR</para>
                /// <para>FormatID: <see cref="Guids.PortableDevices.PropertieSystem.ClientInformationV1"/>, 11</para>
                /// </summary>
                public static PropertyKey EventCookie => new PropertyKey(Guids.PortableDevices.PropertieSystem.ClientInformationV1, 11);

                /// <summary>
                /// <para>Name: WPD_CLIENT_MINIMUM_RESULTS_BUFFER_SIZE</para>
                /// <para>Description: Specifies the minimum buffer size (in bytes) used for sending commands to the driver.</para>
                /// <para>Type: VT_UI4</para>
                /// <para>FormatID: <see cref="Guids.PortableDevices.PropertieSystem.ClientInformationV1"/>, 12</para>
                /// </summary>
                public static PropertyKey MinimumResultsBufferSize => new PropertyKey(Guids.PortableDevices.PropertieSystem.ClientInformationV1, 12);

                /// <summary>
                /// <para>Name: WPD_CLIENT_MANUAL_CLOSE_ON_DISCONNECT</para>
                /// <para>Description: An advanced option for clients that wish to manually call <see cref="IPortableDevice.Close"/> or <see cref="IPortableDeviceService.Close"/> for each object on device disconnect-instead of relying on the API to call Close on its behalf.</para>
                /// <para>Type: VT_BOOL</para>
                /// <para>FormatID: <see cref="Guids.PortableDevices.PropertieSystem.ClientInformationV1"/>, 13</para>
                /// </summary>
                public static PropertyKey ManualCloseOnDisconnect => new PropertyKey(Guids.PortableDevices.PropertieSystem.ClientInformationV1, 13);

            }

            /// <summary>
            /// This class defines all Commands-Parameters and Options associated with: <see cref="Guids.PortableDevices.PropertieSystem.DeviceV1"/>, <see cref="Guids.PortableDevices.PropertieSystem.DeviceV2"/> and <see cref="Guids.PortableDevices.PropertieSystem.DeviceV3"/>.
            /// </summary>
            public static class DeviceProperty

            {
                //
                // WPD_DEVICE_SYNC_PARTNER  
                //   [ VT_LPWSTR ] Indicates a human-readable description of a synchronization partner for the device.
                public static PropertyKey SyncPartner => new PropertyKey(Guids.PortableDevices.PropertieSystem.DeviceV1, 2);
                //
                // WPD_DEVICE_FIRMWARE_VERSION  
                //   [ VT_LPWSTR ] Indicates the firmware version for the device.
                public static PropertyKey FirmwareVersion => new PropertyKey(Guids.PortableDevices.PropertieSystem.DeviceV1, 3);
                //
                // WPD_DEVICE_POWER_LEVEL  
                //   [ VT_UI4 ] Indicates the power level of the device's battery.
                public static PropertyKey PowerLevel => new PropertyKey(Guids.PortableDevices.PropertieSystem.DeviceV1, 4);
                //
                // WPD_DEVICE_POWER_SOURCE  
                //   [ VT_UI4 ] Indicates the power source of the device e.g. whether it is battery or external.
                public static PropertyKey PowerSource => new PropertyKey(Guids.PortableDevices.PropertieSystem.DeviceV1, 5);
                //
                // WPD_DEVICE_PROTOCOL  
                //   [ VT_LPWSTR ] Identifies the device protocol being used.
                public static PropertyKey Protocol => new PropertyKey(Guids.PortableDevices.PropertieSystem.DeviceV1, 6);
                //
                // WPD_DEVICE_MANUFACTURER  
                //   [ VT_LPWSTR ] Identifies the device manufacturer.
                public static PropertyKey Manufacturer => new PropertyKey(Guids.PortableDevices.PropertieSystem.DeviceV1, 7);
                //
                // WPD_DEVICE_MODEL  
                //   [ VT_LPWSTR ] Identifies the device model.
                public static PropertyKey Model => new PropertyKey(Guids.PortableDevices.PropertieSystem.DeviceV1, 8);
                //
                // WPD_DEVICE_SERIAL_NUMBER  
                //   [ VT_LPWSTR ] Identifies the serial number of the device.
                public static PropertyKey SerialNumber => new PropertyKey(Guids.PortableDevices.PropertieSystem.DeviceV1, 9);
                //
                // WPD_DEVICE_SUPPORTS_NON_CONSUMABLE  
                //   [ VT_BOOL ] Indicates whether the device supports non-consumable objects.
                public static PropertyKey SupportsNonConsumable => new PropertyKey(Guids.PortableDevices.PropertieSystem.DeviceV1, 10);
                //
                // WPD_DEVICE_DATETIME  
                //   [ VT_DATE ] Represents the current date and time settings of the device.
                public static PropertyKey DateTime => new PropertyKey(Guids.PortableDevices.PropertieSystem.DeviceV1, 11);
                //
                // WPD_DEVICE_FRIENDLY_NAME  
                //   [ VT_LPWSTR ] Represents the friendly name set by the user on the device.
                public static PropertyKey FriendlyName => new PropertyKey(Guids.PortableDevices.PropertieSystem.DeviceV1, 12);
                //
                // WPD_DEVICE_SUPPORTED_DRM_SCHEMES  
                //   [ VT_UNKNOWN ] An IPortableDevicePropVariantCollection of VT_LPWSTR values indicating the Digital Rights Management schemes supported by the driver.
                public static PropertyKey SupportedDRMSchemes => new PropertyKey(Guids.PortableDevices.PropertieSystem.DeviceV1, 13);
                //
                // WPD_DEVICE_SUPPORTED_FORMATS_ARE_ORDERED  
                //   [ VT_BOOL ] Indicates whether the supported formats returned from the device are in a preferred order. (First format in the list is most preferred by the device-while the last is the least preferred.)
                public static PropertyKey SupportedFormatsAreOrdered => new PropertyKey(Guids.PortableDevices.PropertieSystem.DeviceV1, 14);
                //
                // WPD_DEVICE_TYPE  
                //   [ VT_UI4 ] Indicates the device type-used for representation purposes only. Functional characteristics of the device are decided through functional objects.
                public static PropertyKey Type => new PropertyKey(Guids.PortableDevices.PropertieSystem.DeviceV1, 15);
                //
                // WPD_DEVICE_NETWORK_IDENTIFIER  
                //   [ VT_UI8 ] Indicates the EUI-64 network identifier of the device-used for out-of-band Network Association operations.
                public static PropertyKey NetworkIdentifier => new PropertyKey(Guids.PortableDevices.PropertieSystem.DeviceV1, 16);
                //
                // WPD_DEVICE_FUNCTIONAL_UNIQUE_ID  
                //   [ VT_VECTOR | VT_UI1 ] Indicates a unique 16 byte identifier common across multiple transports supported by the device.
                public static PropertyKey FunctionalUniqueId => new PropertyKey(Guids.PortableDevices.PropertieSystem.DeviceV2, 2);
                //
                // WPD_DEVICE_MODEL_UNIQUE_ID  
                //   [ VT_VECTOR | VT_UI1 ] Indicates a unique 16 byte identifier for cosmetic differentiation among different models of the device.
                public static PropertyKey ModelUniqueId => new PropertyKey(Guids.PortableDevices.PropertieSystem.DeviceV2, 3);
                //
                // WPD_DEVICE_TRANSPORT  
                //   [ VT_UI4 ] Indicates the transport type (USB-IP-Bluetooth-etc.).
                public static PropertyKey Transport => new PropertyKey(Guids.PortableDevices.PropertieSystem.DeviceV2, 4);
                //
                // WPD_DEVICE_USE_DEVICE_STAGE  
                //   [ VT_BOOL ] If this property exists and is set to TRUE-the device can be used with Device Stage.
                public static PropertyKey UseDeviceStage => new PropertyKey(Guids.PortableDevices.PropertieSystem.DeviceV2, 5);
                //
                // WPD_DEVICE_EDP_IDENTITY  
                //   [ VT_LPWSTR ] Represents EDP identity of the device.
                public static PropertyKey EDPIdentity => new PropertyKey(Guids.PortableDevices.PropertieSystem.DeviceV3, 1);

            }

            #region This class defines all Commands-Parameters and Options associated with: WPD_SERVICE_PROPERTIES_V1
            //
            // WPD_SERVICE_VERSION  
            //   [ VT_LPWSTR ] Indicates the implementation version of a service.
            public static PropertyKey ServiceVersion => new PropertyKey(Guids.PortableDevices.PropertieSystem.ServiceV1, 2);
            #endregion

            /// <summary>
            /// This class defines all Commands-Parameters and Options associated with: <see cref="Guids.PortableDevices.PropertieSystem.APIOptionsV1"/>. The properties in this category describe API options.
            /// </summary>
            public static class APIOption

            {

                //
                // WPD_API_OPTION_USE_CLEAR_DATA_STREAM  
                //   [ VT_BOOL ] Indicates that the data stream created for data transfer will be clear only (i.e. No DRM will be involved).
                public static PropertyKey UseClearDataStream => new PropertyKey(Guids.PortableDevices.PropertieSystem.APIOptionsV1, 2);
                //
                // WPD_API_OPTION_IOCTL_ACCESS  
                //   [ VT_UI4 ] An optional property that clients can add to the IN parameter set of IPortableDevice::SendCommand to specify the access required for the command. The Portable Device API uses this to identify whether the IOCTL sent to the driver is sent with FILE_READ_ACCESS or (FILE_READ_ACCESS | FILE_WRITE_ACCESS) access flags.
                public static PropertyKey IOCTLAccess => new PropertyKey(Guids.PortableDevices.PropertieSystem.APIOptionsV1, 3);

            }

            /// <summary>
            /// This class defines all Commands-Parameters and Options associated with: <see cref="Guids.PortableDevices.PropertieSystem.ClassExtensionOptionsV1"/>, <see cref="Guids.PortableDevices.PropertieSystem.ClassExtensionOptionsV2"/> and <see cref="Guids.PortableDevices.PropertieSystem.ClassExtensionOptionsV3"/>. This category of properties relates to options used for the WPD device class extension.
            /// </summary>
            public static class ClassExtensionOption

            {

                //
                // WPD_CLASS_EXTENSION_OPTIONS_SUPPORTED_CONTENT_TYPES  
                //   [ VT_UNKNOWN ] Indicates the (super-set) list of content types supported by the driver (similar to calling WPD_COMMAND_CAPABILITIES_GET_SUPPORTED_CONTENT_TYPES on WPD_FUNCTIONAL_CATEGORY_ALL).
                public static PropertyKey SupportedContentTypes => new PropertyKey(Guids.PortableDevices.PropertieSystem.ClassExtensionOptionsV1, 2);
                //
                // WPD_CLASS_EXTENSION_OPTIONS_DONT_REGISTER_WPD_DEVICE_INTERFACE  
                //   [ VT_BOOL ] Indicates that the caller does not want the WPD class extension library to register the WPD Device Class interface. The caller will take responsibility for doing it.
                public static PropertyKey DontRegisterWPDDeviceInterface => new PropertyKey(Guids.PortableDevices.PropertieSystem.ClassExtensionOptionsV1, 3);
                //
                // WPD_CLASS_EXTENSION_OPTIONS_REGISTER_WPD_PRIVATE_DEVICE_INTERFACE  
                //   [ VT_BOOL ] Indicates that the caller wants the WPD class extension library to register the private WPD Device Class interface.
                public static PropertyKey RegisterWPDPrivateDeviceInterface => new PropertyKey(Guids.PortableDevices.PropertieSystem.ClassExtensionOptionsV1, 4);

                //
                // WPD_CLASS_EXTENSION_OPTIONS_MULTITRANSPORT_MODE  
                //   [ VT_BOOL ] Indicates that the caller wants the WPD class extension library to go into Multi-Transport mode (if TRUE).
                public static PropertyKey MultitransportMode => new PropertyKey(Guids.PortableDevices.PropertieSystem.ClassExtensionOptionsV2, 2);
                //
                // WPD_CLASS_EXTENSION_OPTIONS_DEVICE_IDENTIFICATION_VALUES  
                //   [ VT_UNKNOWN ] This is an IPortableDeviceValues which contains the device identification values (WPD_DEVICE_MANUFACTURER-WPD_DEVICE_MODEL-WPD_DEVICE_FIRMWARE_VERSION and WPD_DEVICE_FUNCTIONAL_UNIQUE_ID). Include this with other Class Extension options when initializing.
                public static PropertyKey DeviceIdentificationValues => new PropertyKey(Guids.PortableDevices.PropertieSystem.ClassExtensionOptionsV2, 3);
                //
                // WPD_CLASS_EXTENSION_OPTIONS_TRANSPORT_BANDWIDTH  
                //   [ VT_UI4 ] Indicates the theoretical maximum bandwidth of the transport in kilobits per second.
                public static PropertyKey TransportBandwidth => new PropertyKey(Guids.PortableDevices.PropertieSystem.ClassExtensionOptionsV2, 4);

                //
                // WPD_CLASS_EXTENSION_OPTIONS_SILENCE_AUTOPLAY  
                //   [ VT_BOOL ] Indicates that the caller wants Autoplay to be silent when the device is connected (if TRUE).
                public static PropertyKey SilenceAutoplay => new PropertyKey(Guids.PortableDevices.PropertieSystem.ClassExtensionOptionsV3, 2);

            }

            /// <summary>
            /// This class defines the legacy WPD Properties
            /// </summary>
            public static class Legacy

            {

                public static class Object

                {

                    public static class Common

                    {

                        //
                        // WPD_OBJECT_ID 
                        //   [ VT_LPWSTR ] Uniquely identifies object on the Portable Device.
                        //   Recommended Device Services Property: PKEY_GenericObj_ObjectID
                        public static PropertyKey Id => new PropertyKey(Guids.PortableDevices.PropertieSystem.ObjectV1, 2);
                        //
                        // WPD_OBJECT_PARENT_ID 
                        //   [ VT_LPWSTR ] Object identifier indicating the parent object.
                        //   Recommended Device Services Property: PKEY_GenericObj_ParentID
                        public static PropertyKey ParentId => new PropertyKey(Guids.PortableDevices.PropertieSystem.ObjectV1, 3);
                        //
                        // WPD_OBJECT_NAME 
                        //   [ VT_LPWSTR ] The display name for this object.
                        //   Recommended Device Services Property: PKEY_GenericObj_Name
                        public static PropertyKey Name => new PropertyKey(Guids.PortableDevices.PropertieSystem.ObjectV1, 4);
                        //
                        // WPD_OBJECT_PERSISTENT_UNIQUE_ID 
                        //   [ VT_LPWSTR ] Uniquely identifies the object on the Portable Device-similar to WPD_OBJECT_ID-but this ID will not change between sessions.
                        //   Recommended Device Services Property: PKEY_GenericObj_PersistentUID
                        public static PropertyKey PersistentUniqueId => new PropertyKey(Guids.PortableDevices.PropertieSystem.ObjectV1, 5);
                        //
                        // WPD_OBJECT_FORMAT 
                        //   [ VT_CLSID ] Indicates the format of the object's data.
                        //   Recommended Device Services Property: PKEY_GenericObj_ObjectFormat
                        public static PropertyKey Format => new PropertyKey(Guids.PortableDevices.PropertieSystem.ObjectV1, 6);
                        //
                        // WPD_OBJECT_ISHIDDEN 
                        //   [ VT_BOOL ] Indicates whether the object should be hidden.
                        //   Recommended Device Services Property: PKEY_GenericObj_Hidden
                        public static PropertyKey IsHidden => new PropertyKey(Guids.PortableDevices.PropertieSystem.ObjectV1, 9);
                        //
                        // WPD_OBJECT_ISSYSTEM 
                        //   [ VT_BOOL ] Indicates whether the object represents system data.
                        //   Recommended Device Services Property: PKEY_GenericObj_SystemObject
                        public static PropertyKey IsSystem => new PropertyKey(Guids.PortableDevices.PropertieSystem.ObjectV1, 10);
                        //
                        // WPD_OBJECT_SIZE 
                        //   [ VT_UI8 ] The size of the object data.
                        //   Recommended Device Services Property: PKEY_GenericObj_ObjectSize
                        public static PropertyKey Size => new PropertyKey(Guids.PortableDevices.PropertieSystem.ObjectV1, 11);
                        //
                        // WPD_OBJECT_ORIGINAL_FILE_NAME 
                        //   [ VT_LPWSTR ] Contains the name of the file this object represents.
                        //   Recommended Device Services Property: PKEY_GenericObj_ObjectFileName
                        public static PropertyKey OriginalFileName => new PropertyKey(Guids.PortableDevices.PropertieSystem.ObjectV1, 12);
                        //
                        // WPD_OBJECT_NON_CONSUMABLE 
                        //   [ VT_BOOL ] This property determines whether or not this object is intended to be understood by the device-or whether it has been placed on the device just for storage.
                        //   Recommended Device Services Property: PKEY_GenericObj_NonConsumable
                        public static PropertyKey NonConsumable => new PropertyKey(Guids.PortableDevices.PropertieSystem.ObjectV1, 13);
                        //
                        // WPD_OBJECT_KEYWORDS 
                        //   [ VT_LPWSTR ] String containing a list of keywords associated with this object.
                        //   Recommended Device Services Property: PKEY_GenericObj_Keywords
                        public static PropertyKey Keywords => new PropertyKey(Guids.PortableDevices.PropertieSystem.ObjectV1, 15);
                        //
                        // WPD_OBJECT_SYNC_ID 
                        //   [ VT_LPWSTR ] Opaque string set by client to retain state between sessions without retaining a catalogue of connected device content.
                        //   Recommended Device Services Property: PKEY_GenericObj_SyncID
                        public static PropertyKey SyncId => new PropertyKey(Guids.PortableDevices.PropertieSystem.ObjectV1, 16);
                        //
                        // WPD_OBJECT_IS_DRM_PROTECTED 
                        //   [ VT_BOOL ] Indicates whether the media data is DRM protected.
                        //   Recommended Device Services Property: PKEY_GenericObj_DRMStatus
                        public static PropertyKey IsDRMProtected => new PropertyKey(Guids.PortableDevices.PropertieSystem.ObjectV1, 17);
                        //
                        // WPD_OBJECT_DATE_CREATED 
                        //   [ VT_DATE ] Indicates the date and time the object was created on the device.
                        //   Recommended Device Services Property: PKEY_GenericObj_DateCreated
                        public static PropertyKey DateCreated => new PropertyKey(Guids.PortableDevices.PropertieSystem.ObjectV1, 18);
                        //
                        // WPD_OBJECT_DATE_MODIFIED 
                        //   [ VT_DATE ] Indicates the date and time the object was modified on the device.
                        //   Recommended Device Services Property: PKEY_GenericObj_DateModified
                        public static PropertyKey DateModified => new PropertyKey(Guids.PortableDevices.PropertieSystem.ObjectV1, 19);
                        //
                        // WPD_OBJECT_DATE_AUTHORED 
                        //   [ VT_DATE ] Indicates the date and time the object was authored (e.g. for music-this would be the date the music was recorded).
                        //   Recommended Device Services Property: PKEY_GenericObj_DateAuthored
                        public static PropertyKey DateAuthored => new PropertyKey(Guids.PortableDevices.PropertieSystem.ObjectV1, 20);
                        //
                        // WPD_OBJECT_BACK_REFERENCES 
                        //   [ VT_UNKNOWN ] IPortableDevicePropVariantCollection of type VT_LPWSTR indicating a list of ObjectIDs.
                        //   Recommended Device Services Property: PKEY_GenericObj_ReferenceParentID
                        public static PropertyKey BackReferences => new PropertyKey(Guids.PortableDevices.PropertieSystem.ObjectV1, 21);
                        //
                        // WPD_OBJECT_CAN_DELETE 
                        //   [ VT_BOOL ] Indicates whether the object can be deleted-or not.
                        //   Recommended Device Services Property: PKEY_GenericObj_ProtectionStatus
                        public static PropertyKey CanDelete => new PropertyKey(Guids.PortableDevices.PropertieSystem.ObjectV1, 26);
                        //
                        // WPD_OBJECT_LANGUAGE_LOCALE 
                        //   [ VT_LPWSTR ] Identifies the language of this object. If multiple languages are contained in this object-it should identify the primary language (if any).
                        //   Recommended Device Services Property: PKEY_GenericObj_LanguageLocale
                        public static PropertyKey LanguageLocale => new PropertyKey(Guids.PortableDevices.PropertieSystem.ObjectV1, 27);

                    }

                    //
                    // WPD_FOLDER_CONTENT_TYPES_ALLOWED 
                    //   [ VT_UNKNOWN ] Indicates the subset of content types that can be created in this folder directly (i.e. children may have different restrictions).
                    //   Recommended Device Services Property: None
                    public static PropertyKey FolderContentTypesAllowed => new PropertyKey(Guids.PortableDevices.PropertieSystem.FolderObjectV1, 2);

                    public static class Image

                    {

                        //
                        // WPD_IMAGE_BITDEPTH 
                        //   [ VT_UI4 ] Indicates the bitdepth of an image
                        //   Recommended Device Services Property: PKEY_ImageObj_ImageBitDepth
                        public static PropertyKey BitDepth => new PropertyKey(Guids.PortableDevices.PropertieSystem.ImageObjectV1, 3);
                        //
                        // WPD_IMAGE_CROPPED_STATUS 
                        //   [ VT_UI4 ] Signals whether the file has been cropped.
                        //   Recommended Device Services Property: PKEY_ImageObj_IsCropped
                        public static PropertyKey CroppedStatus => new PropertyKey(Guids.PortableDevices.PropertieSystem.ImageObjectV1, 4);
                        //
                        // WPD_IMAGE_COLOR_CORRECTED_STATUS 
                        //   [ VT_UI4 ] Signals whether the file has been color corrected.
                        //   Recommended Device Services Property: PKEY_ImageObj_IsColorCorrected
                        public static PropertyKey ColorCorrectedStatus => new PropertyKey(Guids.PortableDevices.PropertieSystem.ImageObjectV1, 5);
                        //
                        // WPD_IMAGE_FNUMBER 
                        //   [ VT_UI4 ] Identifies the aperture setting of the lens when this image was captured.
                        //   Recommended Device Services Property: PKEY_ImageObj_Aperature
                        public static PropertyKey FNumber => new PropertyKey(Guids.PortableDevices.PropertieSystem.ImageObjectV1, 6);
                        //
                        // WPD_IMAGE_EXPOSURE_TIME 
                        //   [ VT_UI4 ] Identifies the shutter speed of the device when this image was captured.
                        //   Recommended Device Services Property: PKEY_ImageObj_Exposure
                        public static PropertyKey ExposureTime => new PropertyKey(Guids.PortableDevices.PropertieSystem.ImageObjectV1, 7);
                        //
                        // WPD_IMAGE_EXPOSURE_INDEX 
                        //   [ VT_UI4 ] Identifies the emulation of film speed settings when this image was captured.
                        //   Recommended Device Services Property: PKEY_ImageObj_ISOSpeed
                        public static PropertyKey ExposureIndex => new PropertyKey(Guids.PortableDevices.PropertieSystem.ImageObjectV1, 8);
                        //
                        // WPD_IMAGE_HORIZONTAL_RESOLUTION 
                        //   [ VT_R8 ] Indicates the horizontal resolution (DPI) of an image
                        //   Recommended Device Services Property: None
                        public static PropertyKey HorizontalResolution => new PropertyKey(Guids.PortableDevices.PropertieSystem.ImageObjectV1, 9);
                        //
                        // WPD_IMAGE_VERTICAL_RESOLUTION 
                        //   [ VT_R8 ] Indicates the vertical resolution (DPI) of an image
                        //   Recommended Device Services Property: None
                        public static PropertyKey VerticalResolution => new PropertyKey(Guids.PortableDevices.PropertieSystem.ImageObjectV1, 10);

                    }

                    public static class Contact

                    {
                        //
                        // WPD_CONTACT_DISPLAY_NAME 
                        //   [ VT_LPWSTR ] Indicates the display name of the contact (e.g "John Doe")
                        //   Recommended Device Services Property: None
                        public static PropertyKey DisplayName => new PropertyKey(Guids.PortableDevices.PropertieSystem.ContactObjectV1, 2);
                        //
                        // WPD_CONTACT_FIRST_NAME 
                        //   [ VT_LPWSTR ] Indicates the first name of the contact (e.g. "John")
                        //   Recommended Device Services Property: PKEY_ContactObj_GivenName
                        public static PropertyKey FirstName => new PropertyKey(Guids.PortableDevices.PropertieSystem.ContactObjectV1, 3);
                        //
                        // WPD_CONTACT_MIDDLE_NAMES 
                        //   [ VT_LPWSTR ] Indicates the middle name of the contact
                        //   Recommended Device Services Property: PKEY_ContactObj_MiddleNames
                        public static PropertyKey MiddleNames => new PropertyKey(Guids.PortableDevices.PropertieSystem.ContactObjectV1, 4);
                        //
                        // WPD_CONTACT_LAST_NAME 
                        //   [ VT_LPWSTR ] Indicates the last name of the contact (e.g. "Doe")
                        //   Recommended Device Services Property: PKEY_ContactObj_FamilyName
                        public static PropertyKey LastName => new PropertyKey(Guids.PortableDevices.PropertieSystem.ContactObjectV1, 5);
                        //
                        // WPD_CONTACT_PREFIX 
                        //   [ VT_LPWSTR ] Indicates the prefix of the name of the contact (e.g. "Mr.")
                        //   Recommended Device Services Property: PKEY_ContactObj_Title
                        public static PropertyKey Prefix => new PropertyKey(Guids.PortableDevices.PropertieSystem.ContactObjectV1, 6);
                        //
                        // WPD_CONTACT_SUFFIX 
                        //   [ VT_LPWSTR ] Indicates the suffix of the name of the contact (e.g. "Jr.")
                        //   Recommended Device Services Property: PKEY_ContactObj_Suffix
                        public static PropertyKey Suffix => new PropertyKey(Guids.PortableDevices.PropertieSystem.ContactObjectV1, 7);
                        //
                        // WPD_CONTACT_PHONETIC_FIRST_NAME 
                        //   [ VT_LPWSTR ] The phonetic guide for pronouncing the contact's first name.
                        //   Recommended Device Services Property: PKEY_ContactObj_PhoneticGivenName
                        public static PropertyKey PhoneticFirstName => new PropertyKey(Guids.PortableDevices.PropertieSystem.ContactObjectV1, 8);
                        //
                        // WPD_CONTACT_PHONETIC_LAST_NAME 
                        //   [ VT_LPWSTR ] The phonetic guide for pronouncing the contact's last name.
                        //   Recommended Device Services Property: PKEY_ContactObj_PhoneticFamilyName
                        public static PropertyKey PhoneticLastName => new PropertyKey(Guids.PortableDevices.PropertieSystem.ContactObjectV1, 9);
                        //
                        // WPD_CONTACT_PERSONAL_FULL_POSTAL_ADDRESS 
                        //   [ VT_LPWSTR ] Indicates the full postal address of the contact (e.g. "555 Dial Drive-PhoneLand-WA 12345")
                        //   Recommended Device Services Property: PKEY_ContactObj_PersonalAddressFull
                        public static PropertyKey PersonalFullPostalAddress => new PropertyKey(Guids.PortableDevices.PropertieSystem.ContactObjectV1, 10);
                        //
                        // WPD_CONTACT_PERSONAL_POSTAL_ADDRESS_LINE1 
                        //   [ VT_LPWSTR ] Indicates the first line of a postal address of the contact (e.g. "555 Dial Drive")
                        //   Recommended Device Services Property: PKEY_ContactObj_PersonalAddressStreet
                        public static PropertyKey PersonalPostalAddressLine1 => new PropertyKey(Guids.PortableDevices.PropertieSystem.ContactObjectV1, 11);
                        //
                        // WPD_CONTACT_PERSONAL_POSTAL_ADDRESS_LINE2 
                        //   [ VT_LPWSTR ] Indicates the second line of a postal address of the contact
                        //   Recommended Device Services Property: PKEY_ContactObj_PersonalAddressLine2
                        public static PropertyKey PersonalPostalAddressLine2 => new PropertyKey(Guids.PortableDevices.PropertieSystem.ContactObjectV1, 12);
                        //
                        // WPD_CONTACT_PERSONAL_POSTAL_ADDRESS_CITY 
                        //   [ VT_LPWSTR ] Indicates the city of a postal address of the contact (e.g. "PhoneLand")
                        //   Recommended Device Services Property: PKEY_ContactObj_PersonalAddressCity
                        public static PropertyKey PersonalPostalAddressCity => new PropertyKey(Guids.PortableDevices.PropertieSystem.ContactObjectV1, 13);
                        //
                        // WPD_CONTACT_PERSONAL_POSTAL_ADDRESS_REGION 
                        //   [ VT_LPWSTR ] Indicates the region of a postal address of the contact
                        //   Recommended Device Services Property: PKEY_ContactObj_PersonalAddressRegion
                        public static PropertyKey PersonalPostalAddressRegion => new PropertyKey(Guids.PortableDevices.PropertieSystem.ContactObjectV1, 14);
                        //
                        // WPD_CONTACT_PERSONAL_POSTAL_ADDRESS_POSTAL_CODE 
                        //   [ VT_LPWSTR ] Indicates the postal code of the address.
                        //   Recommended Device Services Property: PKEY_ContactObj_PersonalAddressPostalCode
                        public static PropertyKey PersonalPostalAddressPostalCode => new PropertyKey(Guids.PortableDevices.PropertieSystem.ContactObjectV1, 15);
                        //
                        // WPD_CONTACT_PERSONAL_POSTAL_ADDRESS_COUNTRY 
                        //   [ VT_LPWSTR ] 
                        //   Recommended Device Services Property: PKEY_ContactObj_PersonalAddressCountry
                        public static PropertyKey PersonalPostalAddressCountry => new PropertyKey(Guids.PortableDevices.PropertieSystem.ContactObjectV1, 16);
                        //
                        // WPD_CONTACT_BUSINESS_FULL_POSTAL_ADDRESS 
                        //   [ VT_LPWSTR ] Indicates the full postal address of the contact (e.g. "555 Dial Drive-PhoneLand-WA 12345")
                        //   Recommended Device Services Property: PKEY_ContactObj_BusinessAddressFull
                        public static PropertyKey BusinessFullPostalAddress => new PropertyKey(Guids.PortableDevices.PropertieSystem.ContactObjectV1, 17);
                        //
                        // WPD_CONTACT_BUSINESS_POSTAL_ADDRESS_LINE1 
                        //   [ VT_LPWSTR ] Indicates the first line of a postal address of the contact (e.g. "555 Dial Drive")
                        //   Recommended Device Services Property: PKEY_ContactObj_BusinessAddressStreet
                        public static PropertyKey BusinessPostalAddressLine1 => new PropertyKey(Guids.PortableDevices.PropertieSystem.ContactObjectV1, 18);
                        //
                        // WPD_CONTACT_BUSINESS_POSTAL_ADDRESS_LINE2 
                        //   [ VT_LPWSTR ] Indicates the second line of a postal address of the contact
                        //   Recommended Device Services Property: PKEY_ContactObj_BusinessAddressLine2
                        public static PropertyKey BusinessPostalAddressLine2 => new PropertyKey(Guids.PortableDevices.PropertieSystem.ContactObjectV1, 19);
                        //
                        // WPD_CONTACT_BUSINESS_POSTAL_ADDRESS_CITY 
                        //   [ VT_LPWSTR ] Indicates the city of a postal address of the contact (e.g. "PhoneLand")
                        //   Recommended Device Services Property: PKEY_ContactObj_BusinessAddressCity
                        public static PropertyKey BusinessPostalAddressCity => new PropertyKey(Guids.PortableDevices.PropertieSystem.ContactObjectV1, 20);
                        //
                        // WPD_CONTACT_BUSINESS_POSTAL_ADDRESS_REGION 
                        //   [ VT_LPWSTR ] 
                        //   Recommended Device Services Property: PKEY_ContactObj_BusinessAddressRegion
                        public static PropertyKey BusinessPostalAddressRegion => new PropertyKey(Guids.PortableDevices.PropertieSystem.ContactObjectV1, 21);
                        //
                        // WPD_CONTACT_BUSINESS_POSTAL_ADDRESS_POSTAL_CODE 
                        //   [ VT_LPWSTR ] Indicates the postal code of the address.
                        //   Recommended Device Services Property: PKEY_ContactObj_BusinessAddressPostalCode
                        public static PropertyKey BusinessPostalAddressPostalCode => new PropertyKey(Guids.PortableDevices.PropertieSystem.ContactObjectV1, 22);
                        //
                        // WPD_CONTACT_BUSINESS_POSTAL_ADDRESS_COUNTRY 
                        //   [ VT_LPWSTR ] 
                        //   Recommended Device Services Property: PKEY_ContactObj_BusinessAddressCountry
                        public static PropertyKey BusinessPostalAddressCountry => new PropertyKey(Guids.PortableDevices.PropertieSystem.ContactObjectV1, 23);
                        //
                        // WPD_CONTACT_OTHER_FULL_POSTAL_ADDRESS 
                        //   [ VT_LPWSTR ] Indicates the full postal address of the contact (e.g. "555 Dial Drive-PhoneLand-WA 12345").
                        //   Recommended Device Services Property: PKEY_ContactObj_OtherAddressFull
                        public static PropertyKey OtherFullPostalAddress => new PropertyKey(Guids.PortableDevices.PropertieSystem.ContactObjectV1, 24);
                        //
                        // WPD_CONTACT_OTHER_POSTAL_ADDRESS_LINE1 
                        //   [ VT_LPWSTR ] Indicates the first line of a postal address of the contact (e.g. "555 Dial Drive").
                        //   Recommended Device Services Property: PKEY_ContactObj_OtherAddressStreet
                        public static PropertyKey OtherPostalAddressLine1 => new PropertyKey(Guids.PortableDevices.PropertieSystem.ContactObjectV1, 25);
                        //
                        // WPD_CONTACT_OTHER_POSTAL_ADDRESS_LINE2 
                        //   [ VT_LPWSTR ] Indicates the second line of a postal address of the contact.
                        //   Recommended Device Services Property: PKEY_ContactObj_OtherAddressLine2
                        public static PropertyKey OtherPostalAddressLine2 => new PropertyKey(Guids.PortableDevices.PropertieSystem.ContactObjectV1, 26);
                        //
                        // WPD_CONTACT_OTHER_POSTAL_ADDRESS_CITY 
                        //   [ VT_LPWSTR ] Indicates the city of a postal address of the contact (e.g. "PhoneLand").
                        //   Recommended Device Services Property: PKEY_ContactObj_OtherAddressCity
                        public static PropertyKey OtherPostalAddressCity => new PropertyKey(Guids.PortableDevices.PropertieSystem.ContactObjectV1, 27);
                        //
                        // WPD_CONTACT_OTHER_POSTAL_ADDRESS_REGION 
                        //   [ VT_LPWSTR ] Indicates the region of a postal address of the contact.
                        //   Recommended Device Services Property: PKEY_ContactObj_OtherAddressRegion
                        public static PropertyKey OtherPostalAddressRegion => new PropertyKey(Guids.PortableDevices.PropertieSystem.ContactObjectV1, 28);
                        //
                        // WPD_CONTACT_OTHER_POSTAL_ADDRESS_POSTAL_CODE 
                        //   [ VT_LPWSTR ] Indicates the postal code of the address.
                        //   Recommended Device Services Property: PKEY_ContactObj_OtherAddressPostalCode
                        public static PropertyKey OtherPostalAddressPostalCode => new PropertyKey(Guids.PortableDevices.PropertieSystem.ContactObjectV1, 29);
                        //
                        // WPD_CONTACT_OTHER_POSTAL_ADDRESS_POSTAL_COUNTRY 
                        //   [ VT_LPWSTR ] Indicates the country/region of the postal address.
                        //   Recommended Device Services Property: PKEY_ContactObj_OtherAddressCountry
                        public static PropertyKey OtherPostalAddressPostalCountry => new PropertyKey(Guids.PortableDevices.PropertieSystem.ContactObjectV1, 30);
                        //
                        // WPD_CONTACT_PRIMARY_EMAIL_ADDRESS 
                        //   [ VT_LPWSTR ] Indicates the primary email address for the contact e.g. "someone@example.com"
                        //   Recommended Device Services Property: PKEY_ContactObj_Email
                        public static PropertyKey PrimaryEmailAddress => new PropertyKey(Guids.PortableDevices.PropertieSystem.ContactObjectV1, 31);
                        //
                        // WPD_CONTACT_PERSONAL_EMAIL 
                        //   [ VT_LPWSTR ] Indicates the personal email address for the contact e.g. "someone@example.com"
                        //   Recommended Device Services Property: PKEY_ContactObj_PersonalEmail
                        public static PropertyKey PersonalEmail => new PropertyKey(Guids.PortableDevices.PropertieSystem.ContactObjectV1, 32);
                        //
                        // WPD_CONTACT_PERSONAL_EMAIL2 
                        //   [ VT_LPWSTR ] Indicates an alternate personal email address for the contact e.g. "someone@example.com"
                        //   Recommended Device Services Property: PKEY_ContactObj_PersonalEmail2
                        public static PropertyKey PersonalEmail2 => new PropertyKey(Guids.PortableDevices.PropertieSystem.ContactObjectV1, 33);
                        //
                        // WPD_CONTACT_BUSINESS_EMAIL 
                        //   [ VT_LPWSTR ] Indicates the business email address for the contact e.g. "someone@example.com"
                        //   Recommended Device Services Property: PKEY_ContactObj_BusinessEmail
                        public static PropertyKey BusinessEmail => new PropertyKey(Guids.PortableDevices.PropertieSystem.ContactObjectV1, 34);
                        //
                        // WPD_CONTACT_BUSINESS_EMAIL2 
                        //   [ VT_LPWSTR ] Indicates an alternate business email address for the contact e.g. "someone@example.com"
                        //   Recommended Device Services Property: PKEY_ContactObj_BusinessEmail2
                        public static PropertyKey BusinessEmail2 => new PropertyKey(Guids.PortableDevices.PropertieSystem.ContactObjectV1, 35);
                        //
                        // WPD_CONTACT_OTHER_EMAILS 
                        //   [ VT_UNKNOWN ] An IPortableDevicePropVariantCollection of type VT_LPWSTR-where each element is an alternate email addresses for the contact.
                        //   Recommended Device Services Property: PKEY_ContactObj_OtherEmail
                        public static PropertyKey OtherEmails => new PropertyKey(Guids.PortableDevices.PropertieSystem.ContactObjectV1, 36);
                        //
                        // WPD_CONTACT_PRIMARY_PHONE 
                        //   [ VT_LPWSTR ] Indicates the primary phone number for the contact.
                        //   Recommended Device Services Property: PKEY_ContactObj_Phone
                        public static PropertyKey PrimaryPhone => new PropertyKey(Guids.PortableDevices.PropertieSystem.ContactObjectV1, 37);
                        //
                        // WPD_CONTACT_PERSONAL_PHONE 
                        //   [ VT_LPWSTR ] Indicates the personal phone number for the contact.
                        //   Recommended Device Services Property: PKEY_ContactObj_PersonalPhone
                        public static PropertyKey PersonalPhone => new PropertyKey(Guids.PortableDevices.PropertieSystem.ContactObjectV1, 38);
                        //
                        // WPD_CONTACT_PERSONAL_PHONE2 
                        //   [ VT_LPWSTR ] Indicates an alternate personal phone number for the contact.
                        //   Recommended Device Services Property: PKEY_ContactObj_PersonalPhone2
                        public static PropertyKey PersonalPhone2 => new PropertyKey(Guids.PortableDevices.PropertieSystem.ContactObjectV1, 39);
                        //
                        // WPD_CONTACT_BUSINESS_PHONE 
                        //   [ VT_LPWSTR ] Indicates the business phone number for the contact.
                        //   Recommended Device Services Property: PKEY_ContactObj_BusinessPhone
                        public static PropertyKey BusinessPhone => new PropertyKey(Guids.PortableDevices.PropertieSystem.ContactObjectV1, 40);
                        //
                        // WPD_CONTACT_BUSINESS_PHONE2 
                        //   [ VT_LPWSTR ] Indicates an alternate business phone number for the contact.
                        //   Recommended Device Services Property: PKEY_ContactObj_BusinessPhone2
                        public static PropertyKey BusinessPhone2 => new PropertyKey(Guids.PortableDevices.PropertieSystem.ContactObjectV1, 41);
                        //
                        // WPD_CONTACT_MOBILE_PHONE 
                        //   [ VT_LPWSTR ] Indicates the mobile phone number for the contact.
                        //   Recommended Device Services Property: PKEY_ContactObj_MobilePhone
                        public static PropertyKey MobilePhone => new PropertyKey(Guids.PortableDevices.PropertieSystem.ContactObjectV1, 42);
                        //
                        // WPD_CONTACT_MOBILE_PHONE2 
                        //   [ VT_LPWSTR ] Indicates an alternate mobile phone number for the contact.
                        //   Recommended Device Services Property: PKEY_ContactObj_MobilePhone2
                        public static PropertyKey MobilePhone2 => new PropertyKey(Guids.PortableDevices.PropertieSystem.ContactObjectV1, 43);
                        //
                        // WPD_CONTACT_PERSONAL_FAX 
                        //   [ VT_LPWSTR ] Indicates the personal fax number for the contact.
                        //   Recommended Device Services Property: PKEY_ContactObj_PersonalFax
                        public static PropertyKey PersonalFax => new PropertyKey(Guids.PortableDevices.PropertieSystem.ContactObjectV1, 44);
                        //
                        // WPD_CONTACT_BUSINESS_FAX 
                        //   [ VT_LPWSTR ] Indicates the business fax number for the contact.
                        //   Recommended Device Services Property: PKEY_ContactObj_BusinessFax
                        public static PropertyKey BusinessFax => new PropertyKey(Guids.PortableDevices.PropertieSystem.ContactObjectV1, 45);
                        //
                        // WPD_CONTACT_PAGER 
                        //   [ VT_LPWSTR ] 
                        //   Recommended Device Services Property: PKEY_ContactObj_Pager
                        public static PropertyKey Pager => new PropertyKey(Guids.PortableDevices.PropertieSystem.ContactObjectV1, 46);
                        //
                        // WPD_CONTACT_OTHER_PHONES 
                        //   [ VT_UNKNOWN ] An IPortableDevicePropVariantCollection of type VT_LPWSTR-where each element is an alternate phone number for the contact.
                        //   Recommended Device Services Property: PKEY_ContactObj_OtherPhone
                        public static PropertyKey OtherPhones => new PropertyKey(Guids.PortableDevices.PropertieSystem.ContactObjectV1, 47);
                        //
                        // WPD_CONTACT_PRIMARY_WEB_ADDRESS 
                        //   [ VT_LPWSTR ] Indicates the primary web address for the contact.
                        //   Recommended Device Services Property: PKEY_ContactObj_WebAddress
                        public static PropertyKey PrimaryWebAddress => new PropertyKey(Guids.PortableDevices.PropertieSystem.ContactObjectV1, 48);
                        //
                        // WPD_CONTACT_PERSONAL_WEB_ADDRESS 
                        //   [ VT_LPWSTR ] Indicates the personal web address for the contact.
                        //   Recommended Device Services Property: PKEY_ContactObj_PersonalWebAddress
                        public static PropertyKey PersonalWebAddress => new PropertyKey(Guids.PortableDevices.PropertieSystem.ContactObjectV1, 49);
                        //
                        // WPD_CONTACT_BUSINESS_WEB_ADDRESS 
                        //   [ VT_LPWSTR ] Indicates the business web address for the contact.
                        //   Recommended Device Services Property: PKEY_ContactObj_BusinessWebAddress
                        public static PropertyKey BusinessWebAddress => new PropertyKey(Guids.PortableDevices.PropertieSystem.ContactObjectV1, 50);
                        //
                        // WPD_CONTACT_INSTANT_MESSENGER 
                        //   [ VT_LPWSTR ] Indicates the instant messenger address for the contact.
                        //   Recommended Device Services Property: PKEY_ContactObj_IMAddress
                        public static PropertyKey InstantMessenger => new PropertyKey(Guids.PortableDevices.PropertieSystem.ContactObjectV1, 51);
                        //
                        // WPD_CONTACT_INSTANT_MESSENGER2 
                        //   [ VT_LPWSTR ] Indicates an alternate instant messenger address for the contact.
                        //   Recommended Device Services Property: PKEY_ContactObj_IMAddress2
                        public static PropertyKey InstantMessenger2 => new PropertyKey(Guids.PortableDevices.PropertieSystem.ContactObjectV1, 52);
                        //
                        // WPD_CONTACT_INSTANT_MESSENGER3 
                        //   [ VT_LPWSTR ] Indicates an alternate instant messenger address for the contact.
                        //   Recommended Device Services Property: PKEY_ContactObj_IMAddress3
                        public static PropertyKey InstantMessenger3 => new PropertyKey(Guids.PortableDevices.PropertieSystem.ContactObjectV1, 53);
                        //
                        // WPD_CONTACT_COMPANY_NAME 
                        //   [ VT_LPWSTR ] Indicates the company name for the contact.
                        //   Recommended Device Services Property: PKEY_ContactObj_Organization
                        public static PropertyKey CompanyName => new PropertyKey(Guids.PortableDevices.PropertieSystem.ContactObjectV1, 54);
                        //
                        // WPD_CONTACT_PHONETIC_COMPANY_NAME 
                        //   [ VT_LPWSTR ] The phonetic guide for pronouncing the contact's company name.
                        //   Recommended Device Services Property: PKEY_ContactObj_PhoneticOrganization
                        public static PropertyKey PhoneticCompanyName => new PropertyKey(Guids.PortableDevices.PropertieSystem.ContactObjectV1, 55);
                        //
                        // WPD_CONTACT_ROLE 
                        //   [ VT_LPWSTR ] Indicates the role for the contact e.g. "Software Engineer".
                        //   Recommended Device Services Property: PKEY_ContactObj_Role
                        public static PropertyKey Role => new PropertyKey(Guids.PortableDevices.PropertieSystem.ContactObjectV1, 56);
                        //
                        // WPD_CONTACT_BIRTHDATE 
                        //   [ VT_DATE ] Indicates the birthdate for the contact.
                        //   Recommended Device Services Property: PKEY_ContactObj_Birthdate
                        public static PropertyKey BirthDate => new PropertyKey(Guids.PortableDevices.PropertieSystem.ContactObjectV1, 57);
                        //
                        // WPD_CONTACT_PRIMARY_FAX 
                        //   [ VT_LPWSTR ] Indicates the primary fax number for the contact.
                        //   Recommended Device Services Property: PKEY_ContactObj_Fax
                        public static PropertyKey PrimaryFax => new PropertyKey(Guids.PortableDevices.PropertieSystem.ContactObjectV1, 58);
                        //
                        // WPD_CONTACT_SPOUSE 
                        //   [ VT_LPWSTR ] Indicates the full name of the spouse/domestic partner for the contact.
                        //   Recommended Device Services Property: PKEY_ContactObj_Spouse
                        public static PropertyKey Spouse => new PropertyKey(Guids.PortableDevices.PropertieSystem.ContactObjectV1, 59);
                        //
                        // WPD_CONTACT_CHILDREN 
                        //   [ VT_UNKNOWN ] An IPortableDevicePropVariantCollection of type VT_LPWSTR-where each element is the full name of a child of the contact.
                        //   Recommended Device Services Property: PKEY_ContactObj_Children
                        public static PropertyKey Children => new PropertyKey(Guids.PortableDevices.PropertieSystem.ContactObjectV1, 60);
                        //
                        // WPD_CONTACT_ASSISTANT 
                        //   [ VT_LPWSTR ] Indicates the full name of the assistant for the contact.
                        //   Recommended Device Services Property: PKEY_ContactObj_Assistant
                        public static PropertyKey Assistant => new PropertyKey(Guids.PortableDevices.PropertieSystem.ContactObjectV1, 61);
                        //
                        // WPD_CONTACT_ANNIVERSARY_DATE 
                        //   [ VT_DATE ] Indicates the anniversary date for the contact.
                        //   Recommended Device Services Property: PKEY_ContactObj_AnniversaryDate
                        public static PropertyKey AnniversaryDate => new PropertyKey(Guids.PortableDevices.PropertieSystem.ContactObjectV1, 62);
                        //
                        // WPD_CONTACT_RINGTONE 
                        //   [ VT_LPWSTR ] Indicates an object id of a ringtone file on the device.
                        //   Recommended Device Services Property: PKEY_ContactObj_Ringtone
                        public static PropertyKey Ringtone => new PropertyKey(Guids.PortableDevices.PropertieSystem.ContactObjectV1, 63);

                    }

                    public static class Media

                    {
                        //
                        // WPD_MUSIC_ALBUM 
                        //   [ VT_LPWSTR ] Indicates the album of the music file.
                        //   Recommended Device Services Property: PKEY_MediaObj_AlbumName
                        public static PropertyKey MusicAlbum => new PropertyKey(Guids.PortableDevices.PropertieSystem.MusicObjectV1, 3);
                        //
                        // WPD_MUSIC_TRACK 
                        //   [ VT_UI4 ] Indicates the track number for the music file.
                        //   Recommended Device Services Property: PKEY_MediaObj_Track
                        public static PropertyKey MusicTrack => new PropertyKey(Guids.PortableDevices.PropertieSystem.MusicObjectV1, 4);
                        //
                        // WPD_MUSIC_LYRICS 
                        //   [ VT_LPWSTR ] Indicates the lyrics for the music file.
                        //   Recommended Device Services Property: PKEY_AudioObj_Lyrics
                        public static PropertyKey MusicLyrics => new PropertyKey(Guids.PortableDevices.PropertieSystem.MusicObjectV1, 6);
                        //
                        // WPD_MUSIC_MOOD 
                        //   [ VT_LPWSTR ] Indicates the mood for the music file.
                        //   Recommended Device Services Property: PKEY_MediaObj_Mood
                        public static PropertyKey MusicMood => new PropertyKey(Guids.PortableDevices.PropertieSystem.MusicObjectV1, 8);
                        //
                        // WPD_AUDIO_BITRATE 
                        //   [ VT_UI4 ] Indicates the bit rate for the audio data-specified in bits per second.
                        //   Recommended Device Services Property: PKEY_AudioObj_AudioBitRate
                        public static PropertyKey AudioBitRate => new PropertyKey(Guids.PortableDevices.PropertieSystem.MusicObjectV1, 9);
                        //
                        // WPD_AUDIO_CHANNEL_COUNT 
                        //   [ VT_R4 ] Indicates the number of channels in this audio file e.g. 1-2-5.1 etc.
                        //   Recommended Device Services Property: PKEY_AudioObj_Channels
                        public static PropertyKey AudioChannelCount => new PropertyKey(Guids.PortableDevices.PropertieSystem.MusicObjectV1, 10);
                        //
                        // WPD_AUDIO_FORMAT_CODE 
                        //   [ VT_UI4 ] Indicates the registered WAVE format code.
                        //   Recommended Device Services Property: PKEY_AudioObj_AudioFormatCode
                        public static PropertyKey AudioFormatCode => new PropertyKey(Guids.PortableDevices.PropertieSystem.MusicObjectV1, 11);
                        //
                        // WPD_AUDIO_BIT_DEPTH 
                        //   [ VT_UI4 ] This property identifies the bit-depth of the audio.
                        //   Recommended Device Services Property: PKEY_AudioObj_AudioBitDepth
                        public static PropertyKey AudioBitDepth => new PropertyKey(Guids.PortableDevices.PropertieSystem.MusicObjectV1, 12);
                        //
                        // WPD_AUDIO_BLOCK_ALIGNMENT 
                        //   [ VT_UI4 ] This property identifies the audio block alignment
                        //   Recommended Device Services Property: PKEY_AudioObj_AudioBlockAlignment
                        public static PropertyKey AudioBlockAlignment => new PropertyKey(Guids.PortableDevices.PropertieSystem.MusicObjectV1, 13);

                    }

                    /// <summary>
                    /// This class defines all Commands-Parameters and Options associated with: <see cref="Guids.PortableDevices.PropertieSystem.VideoObjectV1"/>. This category is for properties common to all video objects.
                    /// </summary>
                    public static class Video

                    {
                        //
                        // WPD_VIDEO_AUTHOR 
                        //   [ VT_LPWSTR ] Indicates the author of the video file.
                        //   Recommended Device Services Property: PKEY_MediaObj_Producer
                        public static PropertyKey Author => new PropertyKey(Guids.PortableDevices.PropertieSystem.VideoObjectV1, 2);
                        //
                        // WPD_VIDEO_RECORDEDTV_STATION_NAME 
                        //   [ VT_LPWSTR ] Indicates the TV station the video was recorded from.
                        //   Recommended Device Services Property: PKEY_VideoObj_Source
                        public static PropertyKey RecordedTVStationName => new PropertyKey(Guids.PortableDevices.PropertieSystem.VideoObjectV1, 4);
                        //
                        // WPD_VIDEO_RECORDEDTV_CHANNEL_NUMBER 
                        //   [ VT_UI4 ] Indicates the TV channel number the video was recorded from.
                        //   Recommended Device Services Property: None
                        public static PropertyKey RecordedTVChannelNumber => new PropertyKey(Guids.PortableDevices.PropertieSystem.VideoObjectV1, 5);
                        //
                        // WPD_VIDEO_RECORDEDTV_REPEAT 
                        //   [ VT_BOOL ] Indicates whether the recorded TV program was a repeat showing.
                        //   Recommended Device Services Property: None
                        public static PropertyKey RecordedTVRepeat => new PropertyKey(Guids.PortableDevices.PropertieSystem.VideoObjectV1, 7);
                        //
                        // WPD_VIDEO_BUFFER_SIZE 
                        //   [ VT_UI4 ] Indicates the video buffer size.
                        //   Recommended Device Services Property: PKEY_MediaObj_BufferSize
                        public static PropertyKey BufferSize => new PropertyKey(Guids.PortableDevices.PropertieSystem.VideoObjectV1, 8);
                        //
                        // WPD_VIDEO_CREDITS 
                        //   [ VT_LPWSTR ] Indicates the credit text for the video file.
                        //   Recommended Device Services Property: PKEY_MediaObj_Credits
                        public static PropertyKey Credits => new PropertyKey(Guids.PortableDevices.PropertieSystem.VideoObjectV1, 9);
                        //
                        // WPD_VIDEO_KEY_FRAME_DISTANCE 
                        //   [ VT_UI4 ] Indicates the interval between key frames in milliseconds.
                        //   Recommended Device Services Property: PKEY_VideoObj_KeyFrameDistance
                        public static PropertyKey KeyFrameDistance => new PropertyKey(Guids.PortableDevices.PropertieSystem.VideoObjectV1, 10);
                        //
                        // WPD_VIDEO_QUALITY_SETTING 
                        //   [ VT_UI4 ] Indicates the quality setting for the video file.
                        //   Recommended Device Services Property: PKEY_MediaObj_EncodingQuality
                        public static PropertyKey QualitySetting => new PropertyKey(Guids.PortableDevices.PropertieSystem.VideoObjectV1, 11);
                        //
                        // WPD_VIDEO_SCAN_TYPE 
                        //   [ VT_UI4 ] This property identifies the video scan information.
                        //   Recommended Device Services Property: PKEY_VideoObj_ScanType
                        public static PropertyKey ScanType => new PropertyKey(Guids.PortableDevices.PropertieSystem.VideoObjectV1, 12);
                        //
                        // WPD_VIDEO_BITRATE 
                        //   [ VT_UI4 ] Indicates the bitrate for the video data.
                        //   Recommended Device Services Property: PKEY_VideoObj_VideoBitRate
                        public static PropertyKey BitRate => new PropertyKey(Guids.PortableDevices.PropertieSystem.VideoObjectV1, 13);
                        //
                        // WPD_VIDEO_FOURCC_CODE 
                        //   [ VT_UI4 ] The registered FourCC code indicating the codec used for the video file.
                        //   Recommended Device Services Property: PKEY_VideoObj_VideoFormatCode
                        public static PropertyKey FourCCCode => new PropertyKey(Guids.PortableDevices.PropertieSystem.VideoObjectV1, 14);
                        //
                        // WPD_VIDEO_FRAMERATE 
                        //   [ VT_UI4 ] Indicates the frame rate for the video data.
                        //   Recommended Device Services Property: PKEY_VideoObj_VideoFrameRate
                        public static PropertyKey FrameRate => new PropertyKey(Guids.PortableDevices.PropertieSystem.VideoObjectV1, 15);

                    }

                    /// <summary>
                    /// This class defines all Commands-Parameters and Options associated with: <see cref="Guids.PortableDevices.PropertieSystem.CommonInformationObjectV1"/>. This category is properties that pertain to informational objects such as appointments-tasks-memos and even documents.
                    /// </summary>
                    public static class Information

                    {
                        //
                        // WPD_COMMON_INFORMATION_SUBJECT 
                        //   [ VT_LPWSTR ] Indicates the subject field of this object.
                        //   Recommended Device Services Property: PKEY_MessageObj_Subject
                        public static PropertyKey Subject => new PropertyKey(Guids.PortableDevices.PropertieSystem.CommonInformationObjectV1, 2);
                        //
                        // WPD_COMMON_INFORMATION_BODY_TEXT 
                        //   [ VT_LPWSTR ] This property contains the body text of an object-in plaintext or HTML format.
                        //   Recommended Device Services Property: PKEY_MessageObj_Body
                        public static PropertyKey BodyText => new PropertyKey(Guids.PortableDevices.PropertieSystem.CommonInformationObjectV1, 3);
                        //
                        // WPD_COMMON_INFORMATION_PRIORITY 
                        //   [ VT_UI4 ] Indicates the priority of this object.
                        //   Recommended Device Services Property: PKEY_MessageObj_Priority
                        public static PropertyKey Priority => new PropertyKey(Guids.PortableDevices.PropertieSystem.CommonInformationObjectV1, 4);
                        //
                        // WPD_COMMON_INFORMATION_START_DATETIME 
                        //   [ VT_DATE ] For appointments-tasks and similar objects-this indicates the date/time that this item is scheduled to start.
                        //   Recommended Device Services Property: PKEY_MessageObj_PatternValidStartDate
                        public static PropertyKey StartDatetime => new PropertyKey(Guids.PortableDevices.PropertieSystem.CommonInformationObjectV1, 5);
                        //
                        // WPD_COMMON_INFORMATION_END_DATETIME 
                        //   [ VT_DATE ] For appointments-tasks and similar objects-this indicates the date/time that this item is scheduled to end.
                        //   Recommended Device Services Property: PKEY_MessageObj_PatternValidEndDate
                        public static PropertyKey EndDatetime => new PropertyKey(Guids.PortableDevices.PropertieSystem.CommonInformationObjectV1, 6);
                        //
                        // WPD_COMMON_INFORMATION_NOTES 
                        //   [ VT_LPWSTR ] For appointments-tasks and similar objects-this indicates any notes for this object.
                        //   Recommended Device Services Property: None
                        public static PropertyKey Notes => new PropertyKey(Guids.PortableDevices.PropertieSystem.CommonInformationObjectV1, 7);

                    }

                    public static class Email

                    {

                        //
                        // WPD_EMAIL_TO_LINE 
                        //   [ VT_LPWSTR ] Indicates the normal recipients for the message.
                        //   Recommended Device Services Property: PKEY_MessageObj_To
                        public static PropertyKey EmailToLine => new PropertyKey(Guids.PortableDevices.PropertieSystem.EmailObjectV1, 2);
                        //
                        // WPD_EMAIL_CC_LINE 
                        //   [ VT_LPWSTR ] Indicates the copied recipients for the message.
                        //   Recommended Device Services Property: PKEY_MessageObj_CC
                        public static PropertyKey EmailCCLine => new PropertyKey(Guids.PortableDevices.PropertieSystem.EmailObjectV1, 3);
                        //
                        // WPD_EMAIL_BCC_LINE 
                        //   [ VT_LPWSTR ] Indicates the recipients for the message who receive a "blind copy".
                        //   Recommended Device Services Property: PKEY_MessageObj_BCC
                        public static PropertyKey EmailBCCLine => new PropertyKey(Guids.PortableDevices.PropertieSystem.EmailObjectV1, 4);
                        //
                        // WPD_EMAIL_HAS_BEEN_READ 
                        //   [ VT_BOOL ] Indicates whether the user has read this message.
                        //   Recommended Device Services Property: PKEY_MessageObj_Read
                        public static PropertyKey EmailHasBeenRead => new PropertyKey(Guids.PortableDevices.PropertieSystem.EmailObjectV1, 7);
                        //
                        // WPD_EMAIL_RECEIVED_TIME 
                        //   [ VT_DATE ] Indicates at what time the message was received.
                        //   Recommended Device Services Property: PKEY_MessageObj_ReceivedTime
                        public static PropertyKey EmailReceivedTime => new PropertyKey(Guids.PortableDevices.PropertieSystem.EmailObjectV1, 8);
                        //
                        // WPD_EMAIL_HAS_ATTACHMENTS 
                        //   [ VT_BOOL ] Indicates whether this message has attachments.
                        //   Recommended Device Services Property: None
                        public static PropertyKey EmailHasAttachments => new PropertyKey(Guids.PortableDevices.PropertieSystem.EmailObjectV1, 9);
                        //
                        // WPD_EMAIL_SENDER_ADDRESS 
                        //   [ VT_LPWSTR ] Indicates who sent the message.
                        //   Recommended Device Services Property: PKEY_MessageObj_Sender
                        public static PropertyKey EmailSenderAddress => new PropertyKey(Guids.PortableDevices.PropertieSystem.EmailObjectV1, 10);

                    }

                    public static class Appointment

                    {

                        //
                        // WPD_APPOINTMENT_LOCATION 
                        //   [ VT_LPWSTR ] Indicates the location of the appointment e.g. "Building 5-Conf. room 7".
                        //   Recommended Device Services Property: PKEY_CalendarObj_Location
                        public static PropertyKey Location => new PropertyKey(Guids.PortableDevices.PropertieSystem.AppointmentObjectV1, 3);
                        //
                        // WPD_APPOINTMENT_TYPE 
                        //   [ VT_LPWSTR ] Indicates the type of appointment e.g. "Personal"-"Business" etc.
                        //   Recommended Device Services Property: None
                        public static PropertyKey Type => new PropertyKey(Guids.PortableDevices.PropertieSystem.AppointmentObjectV1, 7);
                        //
                        // WPD_APPOINTMENT_REQUIRED_ATTENDEES 
                        //   [ VT_LPWSTR ] Semi-colon separated list of required attendees.
                        //   Recommended Device Services Property: None
                        public static PropertyKey RequiredAttendees => new PropertyKey(Guids.PortableDevices.PropertieSystem.AppointmentObjectV1, 8);
                        //
                        // WPD_APPOINTMENT_OPTIONAL_ATTENDEES 
                        //   [ VT_LPWSTR ] Semi-colon separated list of optional attendees.
                        //   Recommended Device Services Property: None
                        public static PropertyKey OptionalAttendees => new PropertyKey(Guids.PortableDevices.PropertieSystem.AppointmentObjectV1, 9);
                        //
                        // WPD_APPOINTMENT_ACCEPTED_ATTENDEES 
                        //   [ VT_LPWSTR ] Semi-colon separated list of attendees who have accepted the appointment.
                        //   Recommended Device Services Property: PKEY_CalendarObj_Accepted
                        public static PropertyKey AcceptedAttendees => new PropertyKey(Guids.PortableDevices.PropertieSystem.AppointmentObjectV1, 10);
                        //
                        // WPD_APPOINTMENT_RESOURCES 
                        //   [ VT_LPWSTR ] Semi-colon separated list of resources needed for the appointment.
                        //   Recommended Device Services Property: None
                        public static PropertyKey Resources => new PropertyKey(Guids.PortableDevices.PropertieSystem.AppointmentObjectV1, 11);
                        //
                        // WPD_APPOINTMENT_TENTATIVE_ATTENDEES 
                        //   [ VT_LPWSTR ] Semi-colon separated list of attendees who have tentatively accepted the appointment.
                        //   Recommended Device Services Property: PKEY_CalendarObj_Tentative
                        public static PropertyKey TentativeAttendees => new PropertyKey(Guids.PortableDevices.PropertieSystem.AppointmentObjectV1, 12);
                        //
                        // WPD_APPOINTMENT_DECLINED_ATTENDEES 
                        //   [ VT_LPWSTR ] Semi-colon separated list of attendees who have declined the appointment.
                        //   Recommended Device Services Property: PKEY_CalendarObj_Declined
                        public static PropertyKey DeclinedAttendees => new PropertyKey(Guids.PortableDevices.PropertieSystem.AppointmentObjectV1, 13);

                    }

                    public static class Task

                    {
                        //
                        // WPD_TASK_STATUS 
                        //   [ VT_LPWSTR ] Indicates the status of the task e.g. "In Progress".
                        //   Recommended Device Services Property: None
                        public static PropertyKey Status => new PropertyKey(Guids.PortableDevices.PropertieSystem.TaskObjectV1, 6);
                        //
                        // WPD_TASK_PERCENT_COMPLETE 
                        //   [ VT_UI4 ] Indicates how much of the task has been completed.
                        //   Recommended Device Services Property: PKEY_TaskObj_Complete
                        public static PropertyKey PercentComplete => new PropertyKey(Guids.PortableDevices.PropertieSystem.TaskObjectV1, 8);
                        //
                        // WPD_TASK_REMINDER_DATE 
                        //   [ VT_DATE ] Indicates the date and time set for the reminder. If this value is 0-then it is assumed that this task has no reminder.
                        //   Recommended Device Services Property: PKEY_TaskObj_ReminderDateTime
                        public static PropertyKey ReminderDate => new PropertyKey(Guids.PortableDevices.PropertieSystem.TaskObjectV1, 10);
                        //
                        // WPD_TASK_OWNER 
                        //   [ VT_LPWSTR ] Indicates the owner of the task.
                        //   Recommended Device Services Property: None
                        public static PropertyKey Owner => new PropertyKey(Guids.PortableDevices.PropertieSystem.TaskObjectV1, 11);

                    }

                    public static class SMS

                    {

                        //
                        // WPD_SMS_PROVIDER 
                        //   [ VT_LPWSTR ] Indicates the service provider name.
                        //   Recommended Device Services Property: None
                        public static PropertyKey Provider => new PropertyKey(Guids.PortableDevices.PropertieSystem.SMSObjectV1, 2);
                        //
                        // WPD_SMS_TIMEOUT 
                        //   [ VT_UI4 ] Indicates the number of milliseconds until a timeout is returned.
                        //   Recommended Device Services Property: None
                        public static PropertyKey TimeOut => new PropertyKey(Guids.PortableDevices.PropertieSystem.SMSObjectV1, 3);
                        //
                        // WPD_SMS_MAX_PAYLOAD 
                        //   [ VT_UI4 ] Indicates the maximum number of bytes that can be contained in a message.
                        //   Recommended Device Services Property: None
                        public static PropertyKey MaxPayLoad => new PropertyKey(Guids.PortableDevices.PropertieSystem.SMSObjectV1, 4);
                        //
                        // WPD_SMS_ENCODING 
                        //   [ VT_UI4 ] Indicates how the driver will encode the text message sent by the client.
                        //   Recommended Device Services Property: None
                        public static PropertyKey Encoding => new PropertyKey(Guids.PortableDevices.PropertieSystem.SMSObjectV1, 5);

                    }

                    public static class Section

                    {
                        //
                        // WPD_SECTION_DATA_OFFSET 
                        //   [ VT_UI8 ] Indicates the zero-based offset of the data for the referenced object.
                        //   Recommended Device Services Property: None
                        public static PropertyKey DataOffset => new PropertyKey(Guids.PortableDevices.PropertieSystem.SectionObjectV1, 2);
                        //
                        // WPD_SECTION_DATA_LENGTH 
                        //   [ VT_UI8 ] Indicates the length of data for the referenced object.
                        //   Recommended Device Services Property: None
                        public static PropertyKey DataLength => new PropertyKey(Guids.PortableDevices.PropertieSystem.SectionObjectV1, 3);
                        //
                        // WPD_SECTION_DATA_UNITS 
                        //   [ VT_UI4 ] Indicates the units for WPD_SECTION_DATA_OFFSET and WPD_SECTION_DATA_LENGTH properties on this object (e.g. offset in bytes-offset in milliseconds etc.).
                        //   Recommended Device Services Property: None
                        public static PropertyKey DataUnits => new PropertyKey(Guids.PortableDevices.PropertieSystem.SectionObjectV1, 4);
                        //
                        // WPD_SECTION_DATA_REFERENCED_OBJECT_RESOURCE 
                        //   [ VT_UNKNOWN ] This is an IPortableDeviceKeyCollection containing a single value-which is the key identifying the resource on the referenced object which the WPD_SECTION_DATA_OFFSET and WPD_SECTION_DATA_LENGTH apply to.
                        //   Recommended Device Services Property: None
                        public static PropertyKey DataReferencedObjectResource => new PropertyKey(Guids.PortableDevices.PropertieSystem.SectionObjectV1, 5);

                    }

                }

                public static class Media

                {
                    //
                    // WPD_MEDIA_TOTAL_BITRATE 
                    //   [ VT_UI4 ] The total number of bits that one second will consume.
                    //   Recommended Device Services Property: PKEY_MediaObj_TotalBitRate
                    public static PropertyKey TotalBitRate => new PropertyKey(Guids.PortableDevices.PropertieSystem.MediaV1, 2);
                    //
                    // WPD_MEDIA_BITRATE_TYPE 
                    //   [ VT_UI4 ] Further qualifies the bitrate of audio or video data.
                    //   Recommended Device Services Property: PKEY_MediaObj_BitRateType
                    public static PropertyKey BitRateType => new PropertyKey(Guids.PortableDevices.PropertieSystem.MediaV1, 3);
                    //
                    // WPD_MEDIA_COPYRIGHT 
                    //   [ VT_LPWSTR ] Indicates the copyright information.
                    //   Recommended Device Services Property: PKEY_GenericObj_Copyright
                    public static PropertyKey Copyright => new PropertyKey(Guids.PortableDevices.PropertieSystem.MediaV1, 4);
                    //
                    // WPD_MEDIA_SUBSCRIPTION_CONTENT_ID 
                    //   [ VT_LPWSTR ] Provides additional information to identify a piece of content relative to an online subscription service.
                    //   Recommended Device Services Property: PKEY_MediaObj_SubscriptionContentID
                    public static PropertyKey SubscriptionContentId => new PropertyKey(Guids.PortableDevices.PropertieSystem.MediaV1, 5);
                    //
                    // WPD_MEDIA_USE_COUNT 
                    //   [ VT_UI4 ] Indicates the total number of times this media has been played or viewed on the device.
                    //   Recommended Device Services Property: PKEY_MediaObj_UseCount
                    public static PropertyKey UseCount => new PropertyKey(Guids.PortableDevices.PropertieSystem.MediaV1, 6);
                    //
                    // WPD_MEDIA_SKIP_COUNT 
                    //   [ VT_UI4 ] Indicates the total number of times this media was setup to be played or viewed but was manually skipped by the user.
                    //   Recommended Device Services Property: PKEY_MediaObj_SkipCount
                    public static PropertyKey SkipCount => new PropertyKey(Guids.PortableDevices.PropertieSystem.MediaV1, 7);
                    //
                    // WPD_MEDIA_LAST_ACCESSED_TIME 
                    //   [ VT_DATE ] Indicates the date and time the media was last accessed on the device.
                    //   Recommended Device Services Property: PKEY_GenericObj_DateAccessed
                    public static PropertyKey LastAccessedTime => new PropertyKey(Guids.PortableDevices.PropertieSystem.MediaV1, 8);
                    //
                    // WPD_MEDIA_PARENTAL_RATING 
                    //   [ VT_LPWSTR ] Indicates the parental rating of the media file.
                    //   Recommended Device Services Property: PKEY_MediaObj_ParentalRating
                    public static PropertyKey ParentalRating => new PropertyKey(Guids.PortableDevices.PropertieSystem.MediaV1, 9);
                    //
                    // WPD_MEDIA_META_GENRE 
                    //   [ VT_UI4 ] Further qualifies a piece of media in a contextual way.
                    //   Recommended Device Services Property: PKEY_MediaObj_MediaType
                    public static PropertyKey MetaGenre => new PropertyKey(Guids.PortableDevices.PropertieSystem.MediaV1, 10);
                    //
                    // WPD_MEDIA_COMPOSER 
                    //   [ VT_LPWSTR ] Identifies the composer when the composer is not the artist who performed it.
                    //   Recommended Device Services Property: PKEY_MediaObj_Composer
                    public static PropertyKey Composer => new PropertyKey(Guids.PortableDevices.PropertieSystem.MediaV1, 11);
                    //
                    // WPD_MEDIA_EFFECTIVE_RATING 
                    //   [ VT_UI4 ] Contains an assigned rating for media not set by the user-but is generated based upon usage statistics.
                    //   Recommended Device Services Property: PKEY_MediaObj_EffectiveRating
                    public static PropertyKey EffectiveRating => new PropertyKey(Guids.PortableDevices.PropertieSystem.MediaV1, 12);
                    //
                    // WPD_MEDIA_SUB_TITLE 
                    //   [ VT_LPWSTR ] Further qualifies the title when the title is ambiguous or general.
                    //   Recommended Device Services Property: PKEY_MediaObj_Subtitle
                    public static PropertyKey SubTitle => new PropertyKey(Guids.PortableDevices.PropertieSystem.MediaV1, 13);
                    //
                    // WPD_MEDIA_RELEASE_DATE 
                    //   [ VT_DATE ] Indicates when the media was released.
                    //   Recommended Device Services Property: PKEY_MediaObj_DateOriginalRelease
                    public static PropertyKey ReleaseDate => new PropertyKey(Guids.PortableDevices.PropertieSystem.MediaV1, 14);
                    //
                    // WPD_MEDIA_SAMPLE_RATE 
                    //   [ VT_UI4 ] Indicates the number of times media selection was sampled per second during encoding.
                    //   Recommended Device Services Property: PKEY_MediaObj_SampleRate
                    public static PropertyKey SampleRate => new PropertyKey(Guids.PortableDevices.PropertieSystem.MediaV1, 15);
                    //
                    // WPD_MEDIA_STAR_RATING 
                    //   [ VT_UI4 ] Indicates the star rating for this media.
                    //   Recommended Device Services Property: None
                    public static PropertyKey StarRating => new PropertyKey(Guids.PortableDevices.PropertieSystem.MediaV1, 16);
                    //
                    // WPD_MEDIA_USER_EFFECTIVE_RATING 
                    //   [ VT_UI4 ] Indicates the rating for this media.
                    //   Recommended Device Services Property: PKEY_MediaObj_UserRating
                    public static PropertyKey UserEffectiveRating => new PropertyKey(Guids.PortableDevices.PropertieSystem.MediaV1, 17);
                    //
                    // WPD_MEDIA_TITLE 
                    //   [ VT_LPWSTR ] Indicates the title of this media.
                    //   Recommended Device Services Property: None
                    public static PropertyKey Title => new PropertyKey(Guids.PortableDevices.PropertieSystem.MediaV1, 18);
                    //
                    // WPD_MEDIA_DURATION 
                    //   [ VT_UI8 ] Indicates the duration of this media in milliseconds.
                    //   Recommended Device Services Property: PKEY_MediaObj_Duration
                    public static PropertyKey Duration => new PropertyKey(Guids.PortableDevices.PropertieSystem.MediaV1, 19);
                    //
                    // WPD_MEDIA_BUY_NOW 
                    //   [ VT_BOOL ] TBD
                    //   Recommended Device Services Property: None
                    public static PropertyKey BuyNow => new PropertyKey(Guids.PortableDevices.PropertieSystem.MediaV1, 20);
                    //
                    // WPD_MEDIA_ENCODING_PROFILE 
                    //   [ VT_LPWSTR ] Media codecs may be encoded in accordance with a profile-which defines a particular encoding algorithm or optimization process.
                    //   Recommended Device Services Property: PKEY_MediaObj_EncodingProfile
                    public static PropertyKey EncodingProfile => new PropertyKey(Guids.PortableDevices.PropertieSystem.MediaV1, 21);
                    //
                    // WPD_MEDIA_WIDTH 
                    //   [ VT_UI4 ] Indicates the width of an object in pixels
                    //   Recommended Device Services Property: PKEY_MediaObj_Width
                    public static PropertyKey Width => new PropertyKey(Guids.PortableDevices.PropertieSystem.MediaV1, 22);
                    //
                    // WPD_MEDIA_HEIGHT 
                    //   [ VT_UI4 ] Indicates the height of an object in pixels
                    //   Recommended Device Services Property: PKEY_MediaObj_Height
                    public static PropertyKey Height => new PropertyKey(Guids.PortableDevices.PropertieSystem.MediaV1, 23);
                    //
                    // WPD_MEDIA_ARTIST 
                    //   [ VT_LPWSTR ] Indicates the artist for this media.
                    //   Recommended Device Services Property: PKEY_MediaObj_Artist
                    public static PropertyKey Artist => new PropertyKey(Guids.PortableDevices.PropertieSystem.MediaV1, 24);
                    //
                    // WPD_MEDIA_ALBUM_ARTIST 
                    //   [ VT_LPWSTR ] Indicates the artist of the entire album rather than for a particular track.
                    //   Recommended Device Services Property: PKEY_MediaObj_AlbumArtist
                    public static PropertyKey AlbumArtist => new PropertyKey(Guids.PortableDevices.PropertieSystem.MediaV1, 25);
                    //
                    // WPD_MEDIA_OWNER 
                    //   [ VT_LPWSTR ] Indicates the e-mail address of the owner for this media.
                    //   Recommended Device Services Property: PKEY_MediaObj_Owner
                    public static PropertyKey Owner => new PropertyKey(Guids.PortableDevices.PropertieSystem.MediaV1, 26);
                    //
                    // WPD_MEDIA_MANAGING_EDITOR 
                    //   [ VT_LPWSTR ] Indicates the e-mail address of the managing editor for this media.
                    //   Recommended Device Services Property: PKEY_MediaObj_Editor
                    public static PropertyKey ManagingEditor => new PropertyKey(Guids.PortableDevices.PropertieSystem.MediaV1, 27);
                    //
                    // WPD_MEDIA_WEBMASTER 
                    //   [ VT_LPWSTR ] Indicates the e-mail address of the Webmaster for this media.
                    //   Recommended Device Services Property: PKEY_MediaObj_WebMaster
                    public static PropertyKey WebMaster => new PropertyKey(Guids.PortableDevices.PropertieSystem.MediaV1, 28);
                    //
                    // WPD_MEDIA_SOURCE_URL 
                    //   [ VT_LPWSTR ] Identifies the source URL for this object.
                    //   Recommended Device Services Property: PKEY_MediaObj_URLSource
                    public static PropertyKey SourceUrl => new PropertyKey(Guids.PortableDevices.PropertieSystem.MediaV1, 29);
                    //
                    // WPD_MEDIA_DESTINATION_URL 
                    //   [ VT_LPWSTR ] Identifies the URL that an object is linked to if a user clicks on it.
                    //   Recommended Device Services Property: PKEY_MediaObj_URLLink
                    public static PropertyKey DestinationUrl => new PropertyKey(Guids.PortableDevices.PropertieSystem.MediaV1, 30);
                    //
                    // WPD_MEDIA_DESCRIPTION 
                    //   [ VT_LPWSTR ] Contains a description of the media content for this object.
                    //   Recommended Device Services Property: PKEY_GenericObj_Description
                    public static PropertyKey Description => new PropertyKey(Guids.PortableDevices.PropertieSystem.MediaV1, 31);
                    //
                    // WPD_MEDIA_GENRE 
                    //   [ VT_LPWSTR ] A text field indicating the genre this media belongs to.
                    //   Recommended Device Services Property: PKEY_MediaObj_Genre
                    public static PropertyKey Genre => new PropertyKey(Guids.PortableDevices.PropertieSystem.MediaV1, 32);
                    //
                    // WPD_MEDIA_TIME_BOOKMARK 
                    //   [ VT_UI8 ] Indicates a bookmark (in milliseconds) of the last position played or viewed on media that have duration.
                    //   Recommended Device Services Property: PKEY_MediaObj_BookmarkTime
                    public static PropertyKey TimeBookmark => new PropertyKey(Guids.PortableDevices.PropertieSystem.MediaV1, 33);
                    //
                    // WPD_MEDIA_OBJECT_BOOKMARK 
                    //   [ VT_LPWSTR ] Indicates a WPD_OBJECT_ID of the last object viewed or played for those objects that refer to a list of objects (such as playlists or media casts).
                    //   Recommended Device Services Property: PKEY_MediaObj_BookmarkObject
                    public static PropertyKey ObjectBookmark => new PropertyKey(Guids.PortableDevices.PropertieSystem.MediaV1, 34);
                    //
                    // WPD_MEDIA_LAST_BUILD_DATE 
                    //   [ VT_DATE ] Indicates the last time a series in a media cast was changed or edited.
                    //   Recommended Device Services Property: PKEY_GenericObj_DateRevised
                    public static PropertyKey LastBuildDate => new PropertyKey(Guids.PortableDevices.PropertieSystem.MediaV1, 35);
                    //
                    // WPD_MEDIA_BYTE_BOOKMARK 
                    //   [ VT_UI8 ] Indicates a bookmark (as a zero-based byte offset) of the last position played or viewed on this media object.
                    //   Recommended Device Services Property: PKEY_MediaObj_BookmarkByte
                    public static PropertyKey ByteBookmark => new PropertyKey(Guids.PortableDevices.PropertieSystem.MediaV1, 36);
                    //
                    // WPD_MEDIA_TIME_TO_LIVE 
                    //   [ VT_UI8 ] It is the number of minutes that indicates how long a channel can be cached before refreshing from the source. Applies to WPD_CONTENT_TYPE_MEDIA_CAST objects.
                    //   Recommended Device Services Property: PKEY_GenericObj_TimeToLive
                    public static PropertyKey TimeToLive => new PropertyKey(Guids.PortableDevices.PropertieSystem.MediaV1, 37);
                    //
                    // WPD_MEDIA_GUID 
                    //   [ VT_LPWSTR ] A text field indicating the GUID of this media.
                    //   Recommended Device Services Property: PKEY_MediaObj_MediaUID
                    public static PropertyKey Guid => new PropertyKey(Guids.PortableDevices.PropertieSystem.MediaV1, 38);
                    //
                    // WPD_MEDIA_SUB_DESCRIPTION 
                    //   [ VT_LPWSTR ] Contains a sub description of the media content for this object.
                    //   Recommended Device Services Property: PKEY_GenericObj_SubDescription
                    public static PropertyKey SubDescription => new PropertyKey(Guids.PortableDevices.PropertieSystem.MediaV1, 39);
                    //
                    // WPD_MEDIA_AUDIO_ENCODING_PROFILE 
                    //   [ VT_LPWSTR ] Media codecs may be encoded in accordance with a profile-which defines a particular encoding algorithm or optimization process.
                    //   Recommended Device Services Property: PKEY_MediaObj_AudioEncodingProfile
                    public static PropertyKey AudioEncodingProfile => new PropertyKey(Guids.PortableDevices.PropertieSystem.MediaV1, 49);

                }

            }

        }

        /// <summary>
        /// This class defines all Commands-Parameters and Options associated with: <see cref="Guids.PortableDevices.PropertieSystem.PropertyAttributesV1"/> and <see cref="Guids.PortableDevices.PropertieSystem.PropertyAttributesV2"/>.
        /// </summary>
        public static class PropertyAttribute

        {

            public static class Property

            {

                //
                // WPD_PROPERTY_ATTRIBUTE_FORM  
                //   [ VT_UI4 ] Specifies the form of the valid values allowed for this property.
                public static PropertyKey Form => new PropertyKey(Guids.PortableDevices.PropertieSystem.PropertyAttributesV1, 2);
                //
                // WPD_PROPERTY_ATTRIBUTE_CAN_READ  
                //   [ VT_BOOL ] Indicates whether client applications have permission to Read the property.
                public static PropertyKey CanRead => new PropertyKey(Guids.PortableDevices.PropertieSystem.PropertyAttributesV1, 3);
                //
                // WPD_PROPERTY_ATTRIBUTE_CAN_WRITE  
                //   [ VT_BOOL ] Indicates whether client applications have permission to Write the property.
                public static PropertyKey CanWrite => new PropertyKey(Guids.PortableDevices.PropertieSystem.PropertyAttributesV1, 4);
                //
                // WPD_PROPERTY_ATTRIBUTE_CAN_DELETE  
                //   [ VT_BOOL ] Indicates whether client applications have permission to Delete the property.
                public static PropertyKey CanDelete => new PropertyKey(Guids.PortableDevices.PropertieSystem.PropertyAttributesV1, 5);
                //
                // WPD_PROPERTY_ATTRIBUTE_DEFAULT_VALUE  
                //   [ VT_XXXX ] Specifies the default value for a write-able property.
                public static PropertyKey DefaultValue => new PropertyKey(Guids.PortableDevices.PropertieSystem.PropertyAttributesV1, 6);
                //
                // WPD_PROPERTY_ATTRIBUTE_FAST_PROPERTY  
                //   [ VT_BOOL ] If True-then this property belongs to the PORTABLE_DEVICE_FAST_PROPERTIES group.
                public static PropertyKey FastProperty => new PropertyKey(Guids.PortableDevices.PropertieSystem.PropertyAttributesV1, 7);
                //
                // WPD_PROPERTY_ATTRIBUTE_RANGE_MIN  
                //   [ VT_XXXX ] The minimum value for a property whose form is of WPD_PROPERTY_ATTRIBUTE_FORM_RANGE.
                public static PropertyKey RangeMin => new PropertyKey(Guids.PortableDevices.PropertieSystem.PropertyAttributesV1, 8);
                //
                // WPD_PROPERTY_ATTRIBUTE_RANGE_MAX  
                //   [ VT_XXXX ] The maximum value for a property whose form is of WPD_PROPERTY_ATTRIBUTE_FORM_RANGE.
                public static PropertyKey RangeMax => new PropertyKey(Guids.PortableDevices.PropertieSystem.PropertyAttributesV1, 9);
                //
                // WPD_PROPERTY_ATTRIBUTE_RANGE_STEP  
                //   [ VT_XXXX ] The step value for a property whose form is of WPD_PROPERTY_ATTRIBUTE_FORM_RANGE.
                public static PropertyKey RangeStep => new PropertyKey(Guids.PortableDevices.PropertieSystem.PropertyAttributesV1, 10);
                //
                // WPD_PROPERTY_ATTRIBUTE_ENUMERATION_ELEMENTS  
                //   [ VT_UNKNOWN ] An IPortableDevicePropVariantCollection containing the enumeration values.
                public static PropertyKey EnumerationElements => new PropertyKey(Guids.PortableDevices.PropertieSystem.PropertyAttributesV1, 11);
                //
                // WPD_PROPERTY_ATTRIBUTE_REGULAR_EXPRESSION  
                //   [ VT_LPWSTR ] A regular expression string indicating acceptable values for properties whose form is WPD_PROPERTY_ATTRIBUTE_FORM_REGULAR_EXPRESSION.
                public static PropertyKey RegularExpression => new PropertyKey(Guids.PortableDevices.PropertieSystem.PropertyAttributesV1, 12);
                //
                // WPD_PROPERTY_ATTRIBUTE_MAX_SIZE  
                //   [ VT_UI8 ] This indicates the maximum size (in bytes) for the value of this property.
                public static PropertyKey MaxSize => new PropertyKey(Guids.PortableDevices.PropertieSystem.PropertyAttributesV1, 13);

                //
                // WPD_PROPERTY_ATTRIBUTE_NAME  
                //   [ VT_LPWSTR ] Contains the name of the property.
                public static PropertyKey Name => new PropertyKey(Guids.PortableDevices.PropertieSystem.PropertyAttributesV2, 2);
                //
                // WPD_PROPERTY_ATTRIBUTE_VARTYPE  
                //   [ VT_UI4 ] Contains the VARTYPE of the property.
                public static PropertyKey VarType => new PropertyKey(Guids.PortableDevices.PropertieSystem.PropertyAttributesV2, 3);

            }

            /// <summary>
            /// This class defines all Commands-Parameters and Options associated with: <see cref="Guids.PortableDevices.PropertieSystem.FormatAttributesV1"/>. The properties in this category describe format attributes.
            /// </summary>
            public static class Format

            {

                //
                // WPD_FORMAT_ATTRIBUTE_NAME  
                //   [ VT_LPWSTR ] Contains the name of the format.
                public static PropertyKey Name => new PropertyKey(Guids.PortableDevices.PropertieSystem.FormatAttributesV1, 2);
                //
                // WPD_FORMAT_ATTRIBUTE_MIMETYPE  
                //   [ VT_LPWSTR ] Contains the MIME type of the format.
                public static PropertyKey MIMEType => new PropertyKey(Guids.PortableDevices.PropertieSystem.FormatAttributesV1, 3);

            }

            /// <summary>
            /// This class defines all Commands-Parameters and Options associated with: <see cref="Guids.PortableDevices.PropertieSystem.MethodAttributesV1"/>. The properties in this category describe method attributes.
            /// </summary>
            public static class Method

            {

                //
                // WPD_METHOD_ATTRIBUTE_NAME  
                //   [ VT_LPWSTR ] Contains the name of the method.
                public static PropertyKey Name => new PropertyKey(Guids.PortableDevices.PropertieSystem.MethodAttributesV1, 2);
                //
                // WPD_METHOD_ATTRIBUTE_ASSOCIATED_FORMAT  
                //   [ VT_CLSID ] Contains the format this method applies to. This is GUID_NULL if the method does not apply to a format.
                public static PropertyKey AssociatedFormat => new PropertyKey(Guids.PortableDevices.PropertieSystem.MethodAttributesV1, 3);
                //
                // WPD_METHOD_ATTRIBUTE_ACCESS  
                //   [ VT_UI4 ] Indicates the required access for a method.
                public static PropertyKey Access => new PropertyKey(Guids.PortableDevices.PropertieSystem.MethodAttributesV1, 4);
                //
                // WPD_METHOD_ATTRIBUTE_PARAMETERS  
                //   [ VT_UNKNOWN ] This is an IPortableDeviceKeyCollection containing the method parameters.
                public static PropertyKey Parameters => new PropertyKey(Guids.PortableDevices.PropertieSystem.MethodAttributesV1, 5);

            }

            /// <summary>
            /// This class defines all Commands-Parameters and Options associated with: <see cref="Guids.PortableDevices.PropertieSystem.ParameterAttributesV1"/>. The properties in this category describe parameter attributes.
            /// </summary>
            public static class Parameter

            {

                //
                // WPD_PARAMETER_ATTRIBUTE_ORDER  
                //   [ VT_UI4 ] The order (starting from 0) of a method parameter.
                public static PropertyKey Order => new PropertyKey(Guids.PortableDevices.PropertieSystem.ParameterAttributesV1, 2);
                //
                // WPD_PARAMETER_ATTRIBUTE_USAGE  
                //   [ VT_UI4 ] The usage of the method parameter.
                public static PropertyKey Usage => new PropertyKey(Guids.PortableDevices.PropertieSystem.ParameterAttributesV1, 3);
                //
                // WPD_PARAMETER_ATTRIBUTE_FORM  
                //   [ VT_UI4 ] Specifies the form of the valid values allowed for this parameter.
                public static PropertyKey Form => new PropertyKey(Guids.PortableDevices.PropertieSystem.ParameterAttributesV1, 4);
                //
                // WPD_PARAMETER_ATTRIBUTE_DEFAULT_VALUE  
                //   [ VT_XXXX ] Specifies the default value for this parameter.
                public static PropertyKey DefaultValue => new PropertyKey(Guids.PortableDevices.PropertieSystem.ParameterAttributesV1, 5);
                //
                // WPD_PARAMETER_ATTRIBUTE_RANGE_MIN  
                //   [ VT_XXXX ] The minimum value for a parameter whose form is of WPD_PARAMETER_ATTRIBUTE_FORM_RANGE.
                public static PropertyKey RangeMin => new PropertyKey(Guids.PortableDevices.PropertieSystem.ParameterAttributesV1, 6);
                //
                // WPD_PARAMETER_ATTRIBUTE_RANGE_MAX  
                //   [ VT_XXXX ] The maximum value for a parameter whose form is of WPD_PARAMETER_ATTRIBUTE_FORM_RANGE.
                public static PropertyKey RangeMax => new PropertyKey(Guids.PortableDevices.PropertieSystem.ParameterAttributesV1, 7);
                //
                // WPD_PARAMETER_ATTRIBUTE_RANGE_STEP  
                //   [ VT_XXXX ] The step value for a parameter whose form is of WPD_PARAMETER_ATTRIBUTE_FORM_RANGE.
                public static PropertyKey RangeStep => new PropertyKey(Guids.PortableDevices.PropertieSystem.ParameterAttributesV1, 8);
                //
                // WPD_PARAMETER_ATTRIBUTE_ENUMERATION_ELEMENTS  
                //   [ VT_UNKNOWN ] An IPortableDevicePropVariantCollection containing the enumeration values.
                public static PropertyKey EnumerationElements => new PropertyKey(Guids.PortableDevices.PropertieSystem.ParameterAttributesV1, 9);
                //
                // WPD_PARAMETER_ATTRIBUTE_REGULAR_EXPRESSION  
                //   [ VT_LPWSTR ] A regular expression string indicating acceptable values for parameters whose form is WPD_PARAMETER_ATTRIBUTE_FORM_REGULAR_EXPRESSION.
                public static PropertyKey RegularExpression => new PropertyKey(Guids.PortableDevices.PropertieSystem.ParameterAttributesV1, 10);
                //
                // WPD_PARAMETER_ATTRIBUTE_MAX_SIZE  
                //   [ VT_UI8 ] This indicates the maximum size (in bytes) for the value of this parameter.
                public static PropertyKey MaxSize => new PropertyKey(Guids.PortableDevices.PropertieSystem.ParameterAttributesV1, 11);
                //
                // WPD_PARAMETER_ATTRIBUTE_VARTYPE  
                //   [ VT_UI4 ] Contains the VARTYPE of the parameter.
                public static PropertyKey VarType => new PropertyKey(Guids.PortableDevices.PropertieSystem.ParameterAttributesV1, 12);
                //
                // WPD_PARAMETER_ATTRIBUTE_NAME  
                //   [ VT_LPWSTR ] Contains the parameter name.
                public static PropertyKey Name => new PropertyKey(Guids.PortableDevices.PropertieSystem.ParameterAttributesV1, 13);

            }

        }

    }

    namespace EventSystem

    {

        public static class Events

        {

            /// <summary>
            /// This class defines all Commands-Parameters and Options associated with: <see cref="Guids.PortableDevices.PropertieSystem.EventV1"/> and <see cref="Guids.PortableDevices.PropertieSystem.EventV2"/>. The properties in this category are for properties that may be needed for event processing-but do not have object property equivalents(i.e.they are not exposed as object properties-but rather-used only as event parameters).
            /// </summary>
            public static class Parameter

            {
                //
                // WPD_EVENT_PARAMETER_PNP_DEVICE_ID  
                //   [ VT_LPWSTR ] Indicates the device that originated the event.
                public static PropertyKey PNPDeviceId => new PropertyKey(Guids.PortableDevices.PropertieSystem.EventV1, 2);
                //
                // WPD_EVENT_PARAMETER_EVENT_ID  
                //   [ VT_CLSID ] Indicates the event sent.
                public static PropertyKey EventId => new PropertyKey(Guids.PortableDevices.PropertieSystem.EventV1, 3);
                //
                // WPD_EVENT_PARAMETER_OPERATION_STATE  
                //   [ VT_UI4 ] Indicates the current state of the operation (e.g. started-running-stopped etc.).
                public static PropertyKey OperationState => new PropertyKey(Guids.PortableDevices.PropertieSystem.EventV1, 4);
                //
                // WPD_EVENT_PARAMETER_OPERATION_PROGRESS  
                //   [ VT_UI4 ] Indicates the progress of a currently executing operation. Value is from 0 to 100-with 100 indicating that the operation is complete.
                public static PropertyKey OperationProgress => new PropertyKey(Guids.PortableDevices.PropertieSystem.EventV1, 5);
                //
                // WPD_EVENT_PARAMETER_OBJECT_PARENT_PERSISTENT_UNIQUE_ID  
                //   [ VT_LPWSTR ] Uniquely identifies the parent object-similar to WPD_OBJECT_PARENT_ID-but this ID will not change between sessions.
                public static PropertyKey ObjectParentPersistentUniqueId => new PropertyKey(Guids.PortableDevices.PropertieSystem.EventV1, 6);
                //
                // WPD_EVENT_PARAMETER_OBJECT_CREATION_COOKIE  
                //   [ VT_LPWSTR ] This is the cookie handed back to a client when it requested an object creation using the IPortableDeviceContent::CreateObjectWithPropertiesAndData method.
                public static PropertyKey ObjectCreationCookie => new PropertyKey(Guids.PortableDevices.PropertieSystem.EventV1, 7);
                //
                // WPD_EVENT_PARAMETER_CHILD_HIERARCHY_CHANGED  
                //   [ VT_BOOL ] Indicates that the child hiearchy for the object has changed.
                public static PropertyKey ChildHierarchyChanged => new PropertyKey(Guids.PortableDevices.PropertieSystem.EventV1, 8);

                //
                // WPD_EVENT_PARAMETER_SERVICE_METHOD_CONTEXT  
                //   [ VT_LPWSTR ] Indicates the service method invocation context.
                public static PropertyKey ServiceMethodContext => new PropertyKey(Guids.PortableDevices.PropertieSystem.EventV2, 2);

            }

            /// <summary>
            /// This class defines all Commands-Parameters and Options associated with: <see cref="Guids.PortableDevices.PropertieSystem.EventOptionsV1"/>. The properties in this category describe event options.
            /// </summary>
            public static class Option

            {

                //
                // WPD_EVENT_OPTION_IS_BROADCAST_EVENT  
                //   [ VT_BOOL ] Indicates that the event is broadcast to all clients.
                public static PropertyKey IsBroadcastEvent => new PropertyKey(Guids.PortableDevices.PropertieSystem.EventOptionsV1, 2);
                //
                // WPD_EVENT_OPTION_IS_AUTOPLAY_EVENT  
                //   [ VT_BOOL ] Indicates that the event is sent to and handled by Autoplay.
                public static PropertyKey IsAutoplayEvent => new PropertyKey(Guids.PortableDevices.PropertieSystem.EventOptionsV1, 3);

            }

            /// <summary>
            /// This class defines all Commands-Parameters and Options associated with: <see cref="Guids.PortableDevices.PropertieSystem.EventAttributesV1"/>. The properties in this category describe event attributes.
            /// </summary>
            public static class Attribute

            {

                //
                // WPD_EVENT_ATTRIBUTE_NAME  
                //   [ VT_LPWSTR ] Contains the name of the event.
                public static PropertyKey Name => new PropertyKey(Guids.PortableDevices.PropertieSystem.EventAttributesV1, 2);
                //
                // WPD_EVENT_ATTRIBUTE_PARAMETERS  
                //   [ VT_UNKNOWN ] IPortableDeviceKeyCollection containing the event parameters.
                public static PropertyKey Parameters => new PropertyKey(Guids.PortableDevices.PropertieSystem.EventAttributesV1, 3);
                //
                // WPD_EVENT_ATTRIBUTE_OPTIONS  
                //   [ VT_UNKNOWN ] IPortableDeviceValues containing the event options.
                public static PropertyKey Options => new PropertyKey(Guids.PortableDevices.PropertieSystem.EventAttributesV1, 4);

            }

        }

    }

    namespace CommandSystem

    {

        /// <summary>
        /// Commands, parameters and options associated with the <see cref="Guids.PortableDevices.CommandSystem.Common"/> (WPD_CATEGORY_COMMON) command category.
        /// </summary>
        public static class Common

        {

            public static class Commands

            {

                // ======== Commands ========
                //
                // WPD_COMMAND_COMMON_RESET_DEVICE 
                //    This command is sent by clients to reset the device. 
                // Access:
                //     (FILE_READ_ACCESS | FILE_WRITE_ACCESS)
                // Parameters:
                //     None
                // Results:
                //     None
                public static PropertyKey ResetDevice => new PropertyKey(Guids.PortableDevices.CommandSystem.Common, 2);
                //
                // WPD_COMMAND_COMMON_GET_OBJECT_IDS_FROM_PERSISTENT_UNIQUE_IDS 
                //    This command is sent when a client wants to get current ObjectIDs representing objects specified by previously acquired Persistent Unique IDs. 
                // Access:
                //     FILE_READ_ACCESS
                // Parameters:
                //     [ Required ]  WPD_PROPERTY_COMMON_PERSISTENT_UNIQUE_IDS 
                // Results:
                //     [ Required ]  WPD_PROPERTY_COMMON_OBJECT_IDS 
                public static PropertyKey GetObjectIdsFromPersistentUniqueIds => new PropertyKey(Guids.PortableDevices.CommandSystem.Common, 3);
                //
                // WPD_COMMAND_COMMON_SAVE_CLIENT_INFORMATION 
                //    This command is sent when a client first connects to a device. 
                // Access:
                //     FILE_READ_ACCESS
                // Parameters:
                //     [ Required ]  WPD_PROPERTY_COMMON_CLIENT_INFORMATION 
                // Results:
                //     [ Optional ]  WPD_PROPERTY_COMMON_CLIENT_INFORMATION_CONTEXT 
                public static PropertyKey SaveClientInformation => new PropertyKey(Guids.PortableDevices.CommandSystem.Common, 4);

            }

            public static class Parameters

            {

                // ======== Command Parameters ======== 

                //
                // WPD_PROPERTY_COMMON_COMMAND_CATEGORY  
                //   [ VT_CLSID ] Specifies the command Category (i.e. the GUID portion of the PROPERTYKEY indicating the command).
                public static PropertyKey CommandCategory => new PropertyKey(Guids.PortableDevices.CommandSystem.Common, 1001);
                //
                // WPD_PROPERTY_COMMON_COMMAND_ID  
                //   [ VT_UI4 ] Specifies the command ID-which is the PID portion of the PROPERTYKEY indicating the command.
                public static PropertyKey CommandId => new PropertyKey(Guids.PortableDevices.CommandSystem.Common, 1002);
                //
                // WPD_PROPERTY_COMMON_HRESULT  
                //   [ VT_ERROR ] The driver sets this to be the HRESULT of the requested operation.
                public static PropertyKey HResult => new PropertyKey(Guids.PortableDevices.CommandSystem.Common, 1003);
                //
                // WPD_PROPERTY_COMMON_DRIVER_ERROR_CODE  
                //   [ VT_UI4 ] Special driver specific code which driver may return on error. Typically only for use with diagnostic tools or vertical solutions.
                public static PropertyKey DriverErrorCode => new PropertyKey(Guids.PortableDevices.CommandSystem.Common, 1004);
                //
                // WPD_PROPERTY_COMMON_COMMAND_TARGET  
                //   [ VT_LPWSTR ] Identifies the object which the command is intended for.
                public static PropertyKey CommandTarget => new PropertyKey(Guids.PortableDevices.CommandSystem.Common, 1006);
                //
                // WPD_PROPERTY_COMMON_PERSISTENT_UNIQUE_IDS  
                //   [ VT_UNKNOWN ] IPortableDevicePropVariantCollection of type VT_LPWSTR specifying list of Persistent Unique IDs.
                public static PropertyKey PersistentUniqueIds => new PropertyKey(Guids.PortableDevices.CommandSystem.Common, 1007);
                //
                // WPD_PROPERTY_COMMON_OBJECT_IDS  
                //   [ VT_UNKNOWN ] IPortableDevicePropVariantCollection of type VT_LPWSTR specifying list of Objects IDs.
                public static PropertyKey ObjectIds => new PropertyKey(Guids.PortableDevices.CommandSystem.Common, 1008);
                //
                // WPD_PROPERTY_COMMON_CLIENT_INFORMATION  
                //   [ VT_UNKNOWN ] IPortableDeviceValues used to identify itself to the driver.
                public static PropertyKey ClientInformation => new PropertyKey(Guids.PortableDevices.CommandSystem.Common, 1009);
                //
                // WPD_PROPERTY_COMMON_CLIENT_INFORMATION_CONTEXT  
                //   [ VT_LPWSTR ] Driver specified context which will be sent for the particular client on all subsequent operations.
                public static PropertyKey ClientInformationContext => new PropertyKey(Guids.PortableDevices.CommandSystem.Common, 1010);
                //
                // WPD_PROPERTY_COMMON_ACTIVITY_ID  
                //   [ VT_CLSID ] An optional ActivityID set either by a client or by WPD API-when ETW tracing is enabled.
                public static PropertyKey ActivityId => new PropertyKey(Guids.PortableDevices.CommandSystem.Common, 1011);

            }

            public static class Options

            {

                // ======== Command Options ========
                //
                // WPD_OPTION_VALID_OBJECT_IDS 
                //   [ VT_UNKNOWN ]  IPortableDevicePropVariantCollection of type VT_LPWSTR specifying list of Objects IDs of the objects that support the command. 
                public static PropertyKey ValidObjectIds => new PropertyKey(Guids.PortableDevices.CommandSystem.Common, 5001);

            }

        }

        namespace Object

        {

            /// <summary>
            /// Commands, parameters and options associated to the <see cref="Guids.PortableDevices.CommandSystem.Object.Enumeration"/> (WPD_CATEGORY_OBJECT_ENUMERATION) command category. The commands in this category are used for basic object enumeration.
            /// </summary>
            public static class Enumeration

            {

                public static class Commands

                {

                    // ======== Commands ========
                    //
                    // WPD_COMMAND_OBJECT_ENUMERATION_START_FIND 
                    //    The driver receives this command when a client wishes to start enumeration. 
                    // Access:
                    //     FILE_READ_ACCESS
                    // Parameters:
                    //     [ Required ]  WPD_PROPERTY_OBJECT_ENUMERATION_PARENT_ID 
                    //     [ Optional ]  WPD_PROPERTY_OBJECT_ENUMERATION_FILTER 
                    // Results:
                    //     [ Required ]  WPD_PROPERTY_OBJECT_ENUMERATION_CONTEXT 
                    public static PropertyKey StartFind => new PropertyKey(Guids.PortableDevices.CommandSystem.Object.Enumeration, 2);
                    //
                    // WPD_COMMAND_OBJECT_ENUMERATION_FIND_NEXT 
                    //    This command is used when the client requests the next batch of ObjectIDs during enumeration. Only objects that match the constraints set up in WPD_COMMAND_OBJECT_ENUMERATION_START_FIND should be returned. 
                    // Access:
                    //     FILE_READ_ACCESS
                    // Parameters:
                    //     [ Required ]  WPD_PROPERTY_OBJECT_ENUMERATION_CONTEXT 
                    //     [ Required ]  WPD_PROPERTY_OBJECT_ENUMERATION_NUM_OBJECTS_REQUESTED 
                    // Results:
                    //     [ Required ]  WPD_PROPERTY_OBJECT_ENUMERATION_OBJECT_IDS 
                    public static PropertyKey FindNext => new PropertyKey(Guids.PortableDevices.CommandSystem.Object.Enumeration, 3);
                    //
                    // WPD_COMMAND_OBJECT_ENUMERATION_END_FIND 
                    //    The driver should destroy any resources associated with this enumeration context. 
                    // Access:
                    //     FILE_READ_ACCESS
                    // Parameters:
                    //     [ Required ]  WPD_PROPERTY_OBJECT_ENUMERATION_CONTEXT 
                    // Results:
                    //     None
                    public static PropertyKey EndFind => new PropertyKey(Guids.PortableDevices.CommandSystem.Object.Enumeration, 4);

                }

                public static class Parameters

                {

                    // ======== Command Parameters ======== 

                    //
                    // WPD_PROPERTY_OBJECT_ENUMERATION_PARENT_ID  
                    //   [ VT_LPWSTR ] The ObjectID specifying the parent object where enumeration should start.
                    public static PropertyKey ParentId => new PropertyKey(Guids.PortableDevices.CommandSystem.Object.Enumeration, 1001);
                    //
                    // WPD_PROPERTY_OBJECT_ENUMERATION_FILTER  
                    //   [ VT_UNKNOWN ] This is an IPortableDeviceValues which specifies the properties used to filter on. If the caller does not want filtering-then this value will not be set.
                    public static PropertyKey Filter => new PropertyKey(Guids.PortableDevices.CommandSystem.Object.Enumeration, 1002);
                    //
                    // WPD_PROPERTY_OBJECT_ENUMERATION_OBJECT_IDS  
                    //   [ VT_UNKNOWN ] This is an IPortableDevicePropVariantCollection of ObjectIDs (of type VT_LPWSTR). If 0 objects are returned-this should be an empty collection-not NULL.
                    public static PropertyKey ObjectIds => new PropertyKey(Guids.PortableDevices.CommandSystem.Object.Enumeration, 1003);
                    //
                    // WPD_PROPERTY_OBJECT_ENUMERATION_CONTEXT  
                    //   [ VT_LPWSTR ] This is a driver-specified identifier for the context associated with this enumeration.
                    public static PropertyKey Context => new PropertyKey(Guids.PortableDevices.CommandSystem.Object.Enumeration, 1004);
                    //
                    // WPD_PROPERTY_OBJECT_ENUMERATION_NUM_OBJECTS_REQUESTED  
                    //   [ VT_UI4 ] The maximum number of ObjectIDs to return back to the client.
                    public static PropertyKey NumObjectsRequested => new PropertyKey(Guids.PortableDevices.CommandSystem.Object.Enumeration, 1005);

                }

            }

            /// <summary>
            /// Commands, parameters and options associated with the <see cref="Guids.PortableDevices.CommandSystem.Object.Properties"/> (WPD_CATEGORY_OBJECT_PROPERTIES) command category. This category of commands is used to perform basic property operations such as Reading/Writing values-listing supported values and so on.
            /// </summary>
            public static class Property

            {

                public static class Commands

                {

                    // ======== Commands ========
                    //
                    // WPD_COMMAND_OBJECT_PROPERTIES_GET_SUPPORTED 
                    //    This command is used when the client requests the list of properties supported by the specified object. 
                    // Access:
                    //     FILE_READ_ACCESS
                    // Parameters:
                    //     [ Required ]  WPD_PROPERTY_OBJECT_PROPERTIES_OBJECT_ID 
                    // Results:
                    //     [ Required ]  WPD_PROPERTY_OBJECT_PROPERTIES_PROPERTY_KEYS 
                    public static PropertyKey GetSupported => new PropertyKey(Guids.PortableDevices.CommandSystem.Object.Properties, 2);
                    //
                    // WPD_COMMAND_OBJECT_PROPERTIES_GET_ATTRIBUTES 
                    //    This command is used when the client requests the property attributes for the specified object properties. 
                    // Access:
                    //     FILE_READ_ACCESS
                    // Parameters:
                    //     [ Required ]  WPD_PROPERTY_OBJECT_PROPERTIES_OBJECT_ID 
                    //     [ Required ]  WPD_PROPERTY_OBJECT_PROPERTIES_PROPERTY_KEYS 
                    // Results:
                    //     [ Required ]  WPD_PROPERTY_OBJECT_PROPERTIES_PROPERTY_ATTRIBUTES 
                    public static PropertyKey GetAttributes => new PropertyKey(Guids.PortableDevices.CommandSystem.Object.Properties, 3);
                    //
                    // WPD_COMMAND_OBJECT_PROPERTIES_GET 
                    //    This command is used when the client requests a set of property values for the specified object. 
                    // Access:
                    //     FILE_READ_ACCESS
                    // Parameters:
                    //     [ Required ]  WPD_PROPERTY_OBJECT_PROPERTIES_OBJECT_ID 
                    //     [ Required ]  WPD_PROPERTY_OBJECT_PROPERTIES_PROPERTY_KEYS 
                    // Results:
                    //     [ Required ]  WPD_PROPERTY_OBJECT_PROPERTIES_PROPERTY_VALUES 
                    public static PropertyKey Get => new PropertyKey(Guids.PortableDevices.CommandSystem.Object.Properties, 4);
                    //
                    // WPD_COMMAND_OBJECT_PROPERTIES_SET 
                    //    This command is used when the client requests to write a set of property values on the specified object. 
                    // Access:
                    //     (FILE_READ_ACCESS | FILE_WRITE_ACCESS)
                    // Parameters:
                    //     [ Required ]  WPD_PROPERTY_OBJECT_PROPERTIES_OBJECT_ID 
                    //     [ Required ]  WPD_PROPERTY_OBJECT_PROPERTIES_PROPERTY_VALUES 
                    // Results:
                    //     [ Required ]  WPD_PROPERTY_OBJECT_PROPERTIES_PROPERTY_WRITE_RESULTS 
                    public static PropertyKey Set => new PropertyKey(Guids.PortableDevices.CommandSystem.Object.Properties, 5);
                    //
                    // WPD_COMMAND_OBJECT_PROPERTIES_GET_ALL 
                    //    This command is used when the client requests all property values for the specified object. 
                    // Access:
                    //     FILE_READ_ACCESS
                    // Parameters:
                    //     [ Required ]  WPD_PROPERTY_OBJECT_PROPERTIES_OBJECT_ID 
                    // Results:
                    //     [ Required ]  WPD_PROPERTY_OBJECT_PROPERTIES_PROPERTY_VALUES 
                    public static PropertyKey GetAll => new PropertyKey(Guids.PortableDevices.CommandSystem.Object.Properties, 6);
                    //
                    // WPD_COMMAND_OBJECT_PROPERTIES_DELETE 
                    //    This command is sent when the caller wants to delete properties from the specified object. 
                    // Access:
                    //     (FILE_READ_ACCESS | FILE_WRITE_ACCESS)
                    // Parameters:
                    //     [ Required ]  WPD_PROPERTY_OBJECT_PROPERTIES_OBJECT_ID 
                    //     [ Required ]  WPD_PROPERTY_OBJECT_PROPERTIES_PROPERTY_KEYS 
                    // Results:
                    //     [ Optional ]  WPD_PROPERTY_OBJECT_PROPERTIES_PROPERTY_DELETE_RESULTS 
                    public static PropertyKey Delete => new PropertyKey(Guids.PortableDevices.CommandSystem.Object.Properties, 7);

                }

                public static class Parameters

                {

                    // ======== Command Parameters ======== 

                    //
                    // WPD_PROPERTY_OBJECT_PROPERTIES_OBJECT_ID  
                    //   [ VT_LPWSTR ] The ObjectID specifying the object whose properties are being queried/manipulated.
                    public static PropertyKey ObjectId => new PropertyKey(Guids.PortableDevices.CommandSystem.Object.Properties, 1001);
                    //
                    // WPD_PROPERTY_OBJECT_PROPERTIES_PROPERTY_KEYS  
                    //   [ VT_UNKNOWN ] An IPortableDeviceKeyCollection identifying which specific property values we are querying/manipulating.
                    public static PropertyKey PropertyKeys => new PropertyKey(Guids.PortableDevices.CommandSystem.Object.Properties, 1002);
                    //
                    // WPD_PROPERTY_OBJECT_PROPERTIES_PROPERTY_ATTRIBUTES  
                    //   [ VT_UNKNOWN ] This is an IPortableDeviceValues which contains the attributes for each property requested.
                    public static PropertyKey PropertyAttributes => new PropertyKey(Guids.PortableDevices.CommandSystem.Object.Properties, 1003);
                    //
                    // WPD_PROPERTY_OBJECT_PROPERTIES_PROPERTY_VALUES  
                    //   [ VT_UNKNOWN ] This is an IPortableDeviceValues which contains the values read. For any property whose value could not be read-the type must be set to VT_ERROR-and the 'scode' field must contain the failure HRESULT.
                    public static PropertyKey PropertyValues => new PropertyKey(Guids.PortableDevices.CommandSystem.Object.Properties, 1004);
                    //
                    // WPD_PROPERTY_OBJECT_PROPERTIES_PROPERTY_WRITE_RESULTS  
                    //   [ VT_UNKNOWN ] This is an IPortableDeviceValues which contains the result of each property write operation.
                    public static PropertyKey PropertyWriteResults => new PropertyKey(Guids.PortableDevices.CommandSystem.Object.Properties, 1005);
                    //
                    // WPD_PROPERTY_OBJECT_PROPERTIES_PROPERTY_DELETE_RESULTS  
                    //   [ VT_UNKNOWN ] This is an IPortableDeviceValues which contains the result of each property delete operation.
                    public static PropertyKey PropertyDeleteResults => new PropertyKey(Guids.PortableDevices.CommandSystem.Object.Properties, 1006);

                }

            }

            /// <summary>
            /// Commands, parameters and options associated with the <see cref="Guids.PortableDevices.CommandSystem.Object.PropertiesBulk"/> (WPD_CATEGORY_OBJECT_PROPERTIES_BULK) command category. This category contains commands and properties for property operations across multiple objects.
            /// </summary>
            public static class PropertyBulk

            {

                public static class Commands

                {

                    // ======== Commands ========
                    //
                    // WPD_COMMAND_OBJECT_PROPERTIES_BULK_GET_VALUES_BY_OBJECT_LIST_START 
                    //    Initializes the operation to get the property values for all caller-specified objects. 
                    // Access:
                    //     FILE_READ_ACCESS
                    // Parameters:
                    //     [ Required ]  WPD_PROPERTY_OBJECT_PROPERTIES_BULK_OBJECT_IDS 
                    //     [ Optional ]  WPD_PROPERTY_OBJECT_PROPERTIES_BULK_PROPERTY_KEYS 
                    // Results:
                    //     [ Required ]  WPD_PROPERTY_OBJECT_PROPERTIES_BULK_CONTEXT 
                    public static PropertyKey GetValuesByObjectListStart => new PropertyKey(Guids.PortableDevices.CommandSystem.Object.PropertiesBulk, 2);
                    //
                    // WPD_COMMAND_OBJECT_PROPERTIES_BULK_GET_VALUES_BY_OBJECT_LIST_NEXT 
                    //    Get the next set of property values. 
                    // Access:
                    //     FILE_READ_ACCESS
                    // Parameters:
                    //     [ Required ]  WPD_PROPERTY_OBJECT_PROPERTIES_BULK_CONTEXT 
                    // Results:
                    //     [ Required ]  WPD_PROPERTY_OBJECT_PROPERTIES_BULK_VALUES 
                    public static PropertyKey GetValuesByObjectListNext => new PropertyKey(Guids.PortableDevices.CommandSystem.Object.PropertiesBulk, 3);
                    //
                    // WPD_COMMAND_OBJECT_PROPERTIES_BULK_GET_VALUES_BY_OBJECT_LIST_END 
                    //    Ends the bulk property operation for getting property values by object list. 
                    // Access:
                    //     FILE_READ_ACCESS
                    // Parameters:
                    //     [ Required ]  WPD_PROPERTY_OBJECT_PROPERTIES_BULK_CONTEXT 
                    // Results:
                    //     None
                    public static PropertyKey GetValuesByObjectListEnd => new PropertyKey(Guids.PortableDevices.CommandSystem.Object.PropertiesBulk, 4);
                    //
                    // WPD_COMMAND_OBJECT_PROPERTIES_BULK_GET_VALUES_BY_OBJECT_FORMAT_START 
                    //    Initializes the operation to get the property values for objects of the specified format 
                    // Access:
                    //     FILE_READ_ACCESS
                    // Parameters:
                    //     [ Required ]  WPD_PROPERTY_OBJECT_PROPERTIES_BULK_OBJECT_FORMAT 
                    //     [ Required ]  WPD_PROPERTY_OBJECT_PROPERTIES_BULK_PARENT_OBJECT_ID 
                    //     [ Required ]  WPD_PROPERTY_OBJECT_PROPERTIES_BULK_DEPTH 
                    //     [ Optional ]  WPD_PROPERTY_OBJECT_PROPERTIES_BULK_PROPERTY_KEYS 
                    // Results:
                    //     [ Required ]  WPD_PROPERTY_OBJECT_PROPERTIES_BULK_CONTEXT 
                    public static PropertyKey GetValuesByObjectFormatStart => new PropertyKey(Guids.PortableDevices.CommandSystem.Object.PropertiesBulk, 5);
                    //
                    // WPD_COMMAND_OBJECT_PROPERTIES_BULK_GET_VALUES_BY_OBJECT_FORMAT_NEXT 
                    //    Get the next set of property values. 
                    // Access:
                    //     FILE_READ_ACCESS
                    // Parameters:
                    //     [ Required ]  WPD_PROPERTY_OBJECT_PROPERTIES_BULK_CONTEXT 
                    // Results:
                    //     [ Required ]  WPD_PROPERTY_OBJECT_PROPERTIES_BULK_VALUES 
                    public static PropertyKey GetValuesByObjectFormatNext => new PropertyKey(Guids.PortableDevices.CommandSystem.Object.PropertiesBulk, 6);
                    //
                    // WPD_COMMAND_OBJECT_PROPERTIES_BULK_GET_VALUES_BY_OBJECT_FORMAT_END 
                    //    Ends the bulk property operation for getting property values by object format. 
                    // Access:
                    //     FILE_READ_ACCESS
                    // Parameters:
                    //     [ Required ]  WPD_PROPERTY_OBJECT_PROPERTIES_BULK_CONTEXT 
                    // Results:
                    //     None
                    public static PropertyKey GetValuesByObjectFormatEnd => new PropertyKey(Guids.PortableDevices.CommandSystem.Object.PropertiesBulk, 7);
                    //
                    // WPD_COMMAND_OBJECT_PROPERTIES_BULK_SET_VALUES_BY_OBJECT_LIST_START 
                    //    Initializes the operation to set the property values for specified objects. 
                    // Access:
                    //     (FILE_READ_ACCESS | FILE_WRITE_ACCESS)
                    // Parameters:
                    //     [ Required ]  WPD_PROPERTY_OBJECT_PROPERTIES_BULK_VALUES 
                    // Results:
                    //     [ Required ]  WPD_PROPERTY_OBJECT_PROPERTIES_BULK_CONTEXT 
                    public static PropertyKey SetValuesByObjectListStart => new PropertyKey(Guids.PortableDevices.CommandSystem.Object.PropertiesBulk, 8);
                    //
                    // WPD_COMMAND_OBJECT_PROPERTIES_BULK_SET_VALUES_BY_OBJECT_LIST_NEXT 
                    //    Set the next set of property values. 
                    // Access:
                    //     (FILE_READ_ACCESS | FILE_WRITE_ACCESS)
                    // Parameters:
                    //     [ Required ]  WPD_PROPERTY_OBJECT_PROPERTIES_BULK_CONTEXT 
                    // Results:
                    //     [ Required ]  WPD_PROPERTY_OBJECT_PROPERTIES_BULK_WRITE_RESULTS 
                    public static PropertyKey SetValuesByObjectListNext => new PropertyKey(Guids.PortableDevices.CommandSystem.Object.PropertiesBulk, 9);
                    //
                    // WPD_COMMAND_OBJECT_PROPERTIES_BULK_SET_VALUES_BY_OBJECT_LIST_END 
                    //    Ends the bulk property operation for setting property values by object list. 
                    // Access:
                    //     (FILE_READ_ACCESS | FILE_WRITE_ACCESS)
                    // Parameters:
                    //     [ Required ]  WPD_PROPERTY_OBJECT_PROPERTIES_BULK_CONTEXT 
                    // Results:
                    //     None
                    public static PropertyKey SetValuesByObjectListEnd => new PropertyKey(Guids.PortableDevices.CommandSystem.Object.PropertiesBulk, 10);

                }

                public static class Parameters

                {

                    // ======== Command Parameters ======== 

                    //
                    // WPD_PROPERTY_OBJECT_PROPERTIES_BULK_OBJECT_IDS  
                    //   [ VT_UNKNOWN ] A collection of ObjectIDs for which supported property list must be returned.
                    public static PropertyKey ObjectIds => new PropertyKey(Guids.PortableDevices.CommandSystem.Object.PropertiesBulk, 1001);
                    //
                    // WPD_PROPERTY_OBJECT_PROPERTIES_BULK_CONTEXT  
                    //   [ VT_LPWSTR ] The driver-specified context identifying this particular bulk operation.
                    public static PropertyKey Context => new PropertyKey(Guids.PortableDevices.CommandSystem.Object.PropertiesBulk, 1002);
                    //
                    // WPD_PROPERTY_OBJECT_PROPERTIES_BULK_VALUES  
                    //   [ VT_UNKNOWN ] Contains an IPortableDeviceValuesCollection specifying the next set of IPortableDeviceValues elements.
                    public static PropertyKey Values => new PropertyKey(Guids.PortableDevices.CommandSystem.Object.PropertiesBulk, 1003);
                    //
                    // WPD_PROPERTY_OBJECT_PROPERTIES_BULK_PROPERTY_KEYS  
                    //   [ VT_UNKNOWN ] Contains an IPortableDeviceKeyCollection specifying which properties the caller wants to return. May not exist-which indicates caller wants ALL properties.
                    public static PropertyKey PropertyKeys => new PropertyKey(Guids.PortableDevices.CommandSystem.Object.PropertiesBulk, 1004);
                    //
                    // WPD_PROPERTY_OBJECT_PROPERTIES_BULK_DEPTH  
                    //   [ VT_UI4 ] Contains a value specifying the hierarchical depth from the parent to include in this operation.
                    public static PropertyKey Depth => new PropertyKey(Guids.PortableDevices.CommandSystem.Object.PropertiesBulk, 1005);
                    //
                    // WPD_PROPERTY_OBJECT_PROPERTIES_BULK_PARENT_OBJECT_ID  
                    //   [ VT_LPWSTR ] Contains the ObjectID of the object to start the operation from.
                    public static PropertyKey ParentObjectId => new PropertyKey(Guids.PortableDevices.CommandSystem.Object.PropertiesBulk, 1006);
                    //
                    // WPD_PROPERTY_OBJECT_PROPERTIES_BULK_OBJECT_FORMAT  
                    //   [ VT_CLSID ] Specifies the object format the client is interested in.
                    public static PropertyKey ObjectFormat => new PropertyKey(Guids.PortableDevices.CommandSystem.Object.PropertiesBulk, 1007);
                    //
                    // WPD_PROPERTY_OBJECT_PROPERTIES_BULK_WRITE_RESULTS  
                    //   [ VT_UNKNOWN ] Contains an IPortableDeviceValuesCollection specifying the set of IPortableDeviceValues elements indicating the write results for each property set.
                    public static PropertyKey WriteResults => new PropertyKey(Guids.PortableDevices.CommandSystem.Object.PropertiesBulk, 1008);

                }

            }

            /// <summary>
            /// This class defines all Commands-Parameters and Options associated with: <see cref="Guids.PortableDevices.CommandSystem.Object.Resources"/>. The commands in this category are used for basic object resource enumeration and transfer.
            /// </summary>
            public static class Resource

            {

                public static class Commands

                {

                    // ======== Commands ========
                    //
                    // WPD_COMMAND_OBJECT_RESOURCES_GET_SUPPORTED 
                    //    This command is sent when a client wants to get the list of resources supported on a particular object. 
                    // Access:
                    //     FILE_READ_ACCESS
                    // Parameters:
                    //     [ Required ]  WPD_PROPERTY_OBJECT_RESOURCES_OBJECT_ID 
                    // Results:
                    //     [ Required ]  WPD_PROPERTY_OBJECT_RESOURCES_RESOURCE_KEYS 
                    public static PropertyKey GetSupported => new PropertyKey(Guids.PortableDevices.CommandSystem.Object.Resources, 2);
                    //
                    // WPD_COMMAND_OBJECT_RESOURCES_GET_ATTRIBUTES 
                    //    This command is used when the client requests the attributes for the specified object resource. 
                    // Access:
                    //     FILE_READ_ACCESS
                    // Parameters:
                    //     [ Required ]  WPD_PROPERTY_OBJECT_RESOURCES_OBJECT_ID 
                    //     [ Required ]  WPD_PROPERTY_OBJECT_RESOURCES_RESOURCE_KEYS 
                    // Results:
                    //     [ Required ]  WPD_PROPERTY_OBJECT_RESOURCES_RESOURCE_ATTRIBUTES 
                    public static PropertyKey GetAttributes => new PropertyKey(Guids.PortableDevices.CommandSystem.Object.Resources, 3);
                    //
                    // WPD_COMMAND_OBJECT_RESOURCES_OPEN 
                    //    This command is sent when a client wants to use a particular resource on an object. 
                    // Access:
                    //     Dependent on the value of WPD_PROPERTY_OBJECT_RESOURCES_ACCESS_MODE.  STGM_READ will indicate FILE_READ_ACCESS for the command-anything else will indicate (FILE_READ_ACCESS | FILE_WRITE_ACCESS).
                    // Parameters:
                    //     [ Required ]  WPD_PROPERTY_OBJECT_RESOURCES_OBJECT_ID 
                    //     [ Required ]  WPD_PROPERTY_OBJECT_RESOURCES_RESOURCE_KEYS 
                    //     [ Required ]  WPD_PROPERTY_OBJECT_RESOURCES_ACCESS_MODE 
                    // Results:
                    //     [ Required ]  WPD_PROPERTY_OBJECT_RESOURCES_CONTEXT 
                    //     [ Required ]  WPD_PROPERTY_OBJECT_RESOURCES_OPTIMAL_TRANSFER_BUFFER_SIZE 
                    //     [ Optional ]  WPD_PROPERTY_OBJECT_RESOURCES_SUPPORTS_UNITS 
                    public static PropertyKey Open => new PropertyKey(Guids.PortableDevices.CommandSystem.Object.Resources, 4);
                    //
                    // WPD_COMMAND_OBJECT_RESOURCES_READ 
                    //    This command is sent when a client wants to read the next band of data from a previously opened object resource. 
                    // Access:
                    //     FILE_READ_ACCESS
                    // Parameters:
                    //     [ Required ]  WPD_PROPERTY_OBJECT_RESOURCES_CONTEXT 
                    //     [ Required ]  WPD_PROPERTY_OBJECT_RESOURCES_NUM_BYTES_TO_READ 
                    //     [ Required except when the driver returns TRUE for the WPD_OPTION_OBJECT_RESOURCES_NO_INPUT_BUFFER_ON_READ option. ]  WPD_PROPERTY_OBJECT_RESOURCES_DATA 
                    // Results:
                    //     [ Required ]  WPD_PROPERTY_OBJECT_RESOURCES_NUM_BYTES_READ 
                    //     [ Required ]  WPD_PROPERTY_OBJECT_RESOURCES_DATA 
                    public static PropertyKey Read => new PropertyKey(Guids.PortableDevices.CommandSystem.Object.Resources, 5);
                    //
                    // WPD_COMMAND_OBJECT_RESOURCES_WRITE 
                    //    This command is sent when a client wants to write the next band of data to a previously opened object resource. 
                    // Access:
                    //     (FILE_READ_ACCESS | FILE_WRITE_ACCESS)
                    // Parameters:
                    //     [ Required ]  WPD_PROPERTY_OBJECT_RESOURCES_CONTEXT 
                    //     [ Required ]  WPD_PROPERTY_OBJECT_RESOURCES_NUM_BYTES_TO_WRITE 
                    //     [ Required ]  WPD_PROPERTY_OBJECT_RESOURCES_DATA 
                    // Results:
                    //     [ Required ]  WPD_PROPERTY_OBJECT_RESOURCES_NUM_BYTES_WRITTEN 
                    public static PropertyKey Write => new PropertyKey(Guids.PortableDevices.CommandSystem.Object.Resources, 6);
                    //
                    // WPD_COMMAND_OBJECT_RESOURCES_CLOSE 
                    //    This command is sent when a client is finished transferring data to a previously opened object resource. 
                    // Access:
                    //     FILE_READ_ACCESS
                    // Parameters:
                    //     [ Required ]  WPD_PROPERTY_OBJECT_RESOURCES_CONTEXT 
                    // Results:
                    //     None
                    public static PropertyKey Close => new PropertyKey(Guids.PortableDevices.CommandSystem.Object.Resources, 7);
                    //
                    // WPD_COMMAND_OBJECT_RESOURCES_DELETE 
                    //    This command is sent when the client wants to delete the data associated with the specified resources from the specified object. 
                    // Access:
                    //     (FILE_READ_ACCESS | FILE_WRITE_ACCESS)
                    // Parameters:
                    //     [ Required ]  WPD_PROPERTY_OBJECT_RESOURCES_OBJECT_ID 
                    //     [ Required ]  WPD_PROPERTY_OBJECT_RESOURCES_RESOURCE_KEYS 
                    // Results:
                    //     None
                    public static PropertyKey Delete => new PropertyKey(Guids.PortableDevices.CommandSystem.Object.Resources, 8);
                    //
                    // WPD_COMMAND_OBJECT_RESOURCES_CREATE_RESOURCE 
                    //    This command is sent when a client wants to create a new object resource on the device. 
                    // Access:
                    //     (FILE_READ_ACCESS | FILE_WRITE_ACCESS)
                    // Parameters:
                    //     [ Required ]  WPD_PROPERTY_OBJECT_RESOURCES_RESOURCE_ATTRIBUTES 
                    // Results:
                    //     [ Required ]  WPD_PROPERTY_OBJECT_RESOURCES_CONTEXT 
                    //     [ Required ]  WPD_PROPERTY_OBJECT_RESOURCES_OPTIMAL_TRANSFER_BUFFER_SIZE 
                    public static PropertyKey CreateResource => new PropertyKey(Guids.PortableDevices.CommandSystem.Object.Resources, 9);
                    //
                    // WPD_COMMAND_OBJECT_RESOURCES_REVERT 
                    //    This command is sent when a client wants to cancel the resource creation request that is currently still in progress. 
                    // Access:
                    //     (FILE_READ_ACCESS | FILE_WRITE_ACCESS)
                    // Parameters:
                    //     [ Required ]  WPD_PROPERTY_OBJECT_RESOURCES_CONTEXT 
                    // Results:
                    //     None
                    public static PropertyKey Revert => new PropertyKey(Guids.PortableDevices.CommandSystem.Object.Resources, 10);
                    //
                    // WPD_COMMAND_OBJECT_RESOURCES_SEEK 
                    //    This command is sent when a client wants to seek to a specific offset in the data stream. 
                    // Access:
                    //     FILE_READ_ACCESS
                    // Parameters:
                    //     [ Required ]  WPD_PROPERTY_OBJECT_RESOURCES_CONTEXT 
                    //     [ Required ]  WPD_PROPERTY_OBJECT_RESOURCES_SEEK_OFFSET 
                    //     [ Required ]  WPD_PROPERTY_OBJECT_RESOURCES_SEEK_ORIGIN_FLAG 
                    // Results:
                    //     [ Required ]  WPD_PROPERTY_OBJECT_RESOURCES_POSITION_FROM_START 
                    public static PropertyKey Seek => new PropertyKey(Guids.PortableDevices.CommandSystem.Object.Resources, 11);
                    //
                    // WPD_COMMAND_OBJECT_RESOURCES_COMMIT 
                    //    This command is sent when a client wants to commit changes to a data stream. 
                    // Access:
                    //     (FILE_READ_ACCESS | FILE_WRITE_ACCESS)
                    // Parameters:
                    //     [ Required ]  WPD_PROPERTY_OBJECT_RESOURCES_CONTEXT 
                    // Results:
                    //     None
                    public static PropertyKey Commit => new PropertyKey(Guids.PortableDevices.CommandSystem.Object.Resources, 12);
                    //
                    // WPD_COMMAND_OBJECT_RESOURCES_SEEK_IN_UNITS 
                    //    This command is sent when a client wants to seek to a specific offset in the data stream using alternate units. 
                    // Access:
                    //     FILE_READ_ACCESS
                    // Parameters:
                    //     [ Required ]  WPD_PROPERTY_OBJECT_RESOURCES_CONTEXT 
                    //     [ Required ]  WPD_PROPERTY_OBJECT_RESOURCES_SEEK_OFFSET 
                    //     [ Required ]  WPD_PROPERTY_OBJECT_RESOURCES_STREAM_UNITS 
                    //     [ Required ]  WPD_PROPERTY_OBJECT_RESOURCES_SEEK_ORIGIN_FLAG 
                    // Results:
                    //     [ Required ]  WPD_PROPERTY_OBJECT_RESOURCES_POSITION_FROM_START 
                    public static PropertyKey SeekInUnits => new PropertyKey(Guids.PortableDevices.CommandSystem.Object.Resources, 13);

                }

                public static class Parameters

                {

                    // ======== Command Parameters ======== 

                    //
                    // WPD_PROPERTY_OBJECT_RESOURCES_OBJECT_ID  
                    //   [ VT_LPWSTR ] 
                    public static PropertyKey ObjectId => new PropertyKey(Guids.PortableDevices.CommandSystem.Object.Resources, 1001);
                    //
                    // WPD_PROPERTY_OBJECT_RESOURCES_ACCESS_MODE  
                    //   [ VT_UI4 ] Specifies the type of access the client is requesting for the resource.
                    public static PropertyKey AccessMode => new PropertyKey(Guids.PortableDevices.CommandSystem.Object.Resources, 1002);
                    //
                    // WPD_PROPERTY_OBJECT_RESOURCES_RESOURCE_KEYS  
                    //   [ VT_UNKNOWN ] 
                    public static PropertyKey ResourceKeys => new PropertyKey(Guids.PortableDevices.CommandSystem.Object.Resources, 1003);
                    //
                    // WPD_PROPERTY_OBJECT_RESOURCES_RESOURCE_ATTRIBUTES  
                    //   [ VT_UNKNOWN ] This is an IPortableDeviceValues which contains the attributes for the resource requested.
                    public static PropertyKey ResourceAttributes => new PropertyKey(Guids.PortableDevices.CommandSystem.Object.Resources, 1004);
                    //
                    // WPD_PROPERTY_OBJECT_RESOURCES_CONTEXT  
                    //   [ VT_LPWSTR ] This is a driver-specified identifier for the context associated with the resource operation.
                    public static PropertyKey Context => new PropertyKey(Guids.PortableDevices.CommandSystem.Object.Resources, 1005);
                    //
                    // WPD_PROPERTY_OBJECT_RESOURCES_NUM_BYTES_TO_READ  
                    //   [ VT_UI4 ] Specifies the number of bytes the client is requesting to read.
                    public static PropertyKey NumBytesToRead => new PropertyKey(Guids.PortableDevices.CommandSystem.Object.Resources, 1006);
                    //
                    // WPD_PROPERTY_OBJECT_RESOURCES_NUM_BYTES_READ  
                    //   [ VT_UI4 ] Specifies the number of bytes actually read from the resource.
                    public static PropertyKey NumBytesRead => new PropertyKey(Guids.PortableDevices.CommandSystem.Object.Resources, 1007);
                    //
                    // WPD_PROPERTY_OBJECT_RESOURCES_NUM_BYTES_TO_WRITE  
                    //   [ VT_UI4 ] Specifies the number of bytes the client is requesting to write.
                    public static PropertyKey NumBytesToWrite => new PropertyKey(Guids.PortableDevices.CommandSystem.Object.Resources, 1008);
                    //
                    // WPD_PROPERTY_OBJECT_RESOURCES_NUM_BYTES_WRITTEN  
                    //   [ VT_UI4 ] Driver sets this to let caller know how many bytes were actually written.
                    public static PropertyKey NumBytesWritten => new PropertyKey(Guids.PortableDevices.CommandSystem.Object.Resources, 1009);
                    //
                    // WPD_PROPERTY_OBJECT_RESOURCES_DATA  
                    //   [ VT_VECTOR | VT_UI1 ] 
                    public static PropertyKey Data => new PropertyKey(Guids.PortableDevices.CommandSystem.Object.Resources, 1010);
                    //
                    // WPD_PROPERTY_OBJECT_RESOURCES_OPTIMAL_TRANSFER_BUFFER_SIZE  
                    //   [ VT_UI4 ] Indicates the optimal transfer buffer size (in bytes) that clients should use when reading/writing this resource.
                    public static PropertyKey OptimalTransferBufferSize => new PropertyKey(Guids.PortableDevices.CommandSystem.Object.Resources, 1011);
                    //
                    // WPD_PROPERTY_OBJECT_RESOURCES_SEEK_OFFSET  
                    //   [ VT_I8 ] Displacement to be added to the location indicated by the WPD_PROPERTY_OBJECT_RESOURCES_SEEK_ORIGIN_FLAG parameter.
                    public static PropertyKey SeekOffset => new PropertyKey(Guids.PortableDevices.CommandSystem.Object.Resources, 1012);
                    //
                    // WPD_PROPERTY_OBJECT_RESOURCES_SEEK_ORIGIN_FLAG  
                    //   [ VT_UI4 ] Specifies the origin of the displacement for the seek operation.
                    public static PropertyKey SeekOriginFlag => new PropertyKey(Guids.PortableDevices.CommandSystem.Object.Resources, 1013);
                    //
                    // WPD_PROPERTY_OBJECT_RESOURCES_POSITION_FROM_START  
                    //   [ VT_UI8 ] Value of the new seek pointer from the beginning of the data stream.
                    public static PropertyKey PositionFromStart => new PropertyKey(Guids.PortableDevices.CommandSystem.Object.Resources, 1014);
                    //
                    // WPD_PROPERTY_OBJECT_RESOURCES_SUPPORTS_UNITS  
                    //   [ VT_BOOL ] A Boolean value that specifies whether this resource supports operations (such as seek) using alternate units. This occurs if the driver can understand WPD_COMMAND_OBJECT_RESOURCES_SEEK_IN_UNITS.
                    public static PropertyKey SupportsUnits => new PropertyKey(Guids.PortableDevices.CommandSystem.Object.Resources, 1015);
                    //
                    // WPD_PROPERTY_OBJECT_RESOURCES_STREAM_UNITS  
                    //   [ VT_UI4 ] The units for the WPD_PROPERTY_OBJECT_SEEK_OFFSET parameter and the WPD_PROPERTY_OBJECT_RESOURCES_POSITION_FROM_START result.
                    public static PropertyKey StreamUnits => new PropertyKey(Guids.PortableDevices.CommandSystem.Object.Resources, 1016);

                }

                public static class Options

                {

                    // ======== Command Options ========
                    //
                    // WPD_OPTION_OBJECT_RESOURCES_SEEK_ON_READ_SUPPORTED 
                    //   [ VT_BOOL ]  Indicates whether the driver can Seek on a resource opened for Read access. 
                    public static PropertyKey SeekOnReadSupported => new PropertyKey(Guids.PortableDevices.CommandSystem.Object.Resources, 5001);
                    //
                    // WPD_OPTION_OBJECT_RESOURCES_SEEK_ON_WRITE_SUPPORTED 
                    //   [ VT_BOOL ]  Indicates whether the driver can Seek on a resource opened for Write access. 
                    public static PropertyKey SeekOnWriteSupported => new PropertyKey(Guids.PortableDevices.CommandSystem.Object.Resources, 5002);
                    //
                    // WPD_OPTION_OBJECT_RESOURCES_NO_INPUT_BUFFER_ON_READ 
                    //   [ VT_BOOL ]  Indicates whether the driver requires an input buffer for WPD_COMMAND_OBJECT_RESOURCES_READ. If not set-defaults to False. 
                    public static PropertyKey NoInputBufferOnRead => new PropertyKey(Guids.PortableDevices.CommandSystem.Object.Resources, 5003);

                }

            }

            /// <summary>
            /// This class defines all Commands-Parameters and Options associated with: <see cref="Guids.PortableDevices.CommandSystem.Object.Management"/>. The commands specified in this category are used to Create/Delete objects on the device.
            /// </summary>
            public static class Management

            {

                public static class Commands

                {

                    // ======== Commands ========
                    //
                    // WPD_COMMAND_OBJECT_MANAGEMENT_CREATE_OBJECT_WITH_PROPERTIES_ONLY 
                    //    This command is sent when a client wants to create a new object on the device-specified only by properties. 
                    // Access:
                    //     (FILE_READ_ACCESS | FILE_WRITE_ACCESS)
                    // Parameters:
                    //     [ Required ]  WPD_PROPERTY_OBJECT_MANAGEMENT_CREATION_PROPERTIES 
                    // Results:
                    //     [ Required ]  WPD_PROPERTY_OBJECT_MANAGEMENT_OBJECT_ID 
                    public static PropertyKey CreateObjectWithPropertiesOnly => new PropertyKey(Guids.PortableDevices.CommandSystem.Object.Management, 2);
                    //
                    // WPD_COMMAND_OBJECT_MANAGEMENT_CREATE_OBJECT_WITH_PROPERTIES_AND_DATA 
                    //    This command is sent when a client wants to create a new object on the device-specified by properties and data. 
                    // Access:
                    //     (FILE_READ_ACCESS | FILE_WRITE_ACCESS)
                    // Parameters:
                    //     [ Required ]  WPD_PROPERTY_OBJECT_MANAGEMENT_CREATION_PROPERTIES 
                    // Results:
                    //     [ Required ]  WPD_PROPERTY_OBJECT_MANAGEMENT_CONTEXT 
                    public static PropertyKey CreateObjectWithPropertiesAndData => new PropertyKey(Guids.PortableDevices.CommandSystem.Object.Management, 3);
                    //
                    // WPD_COMMAND_OBJECT_MANAGEMENT_WRITE_OBJECT_DATA 
                    //    This command is sent when a client wants to write the next band of data to a newly created object or an object being updated. 
                    // Access:
                    //     (FILE_READ_ACCESS | FILE_WRITE_ACCESS)
                    // Parameters:
                    //     [ Required ]  WPD_PROPERTY_OBJECT_MANAGEMENT_CONTEXT 
                    //     [ Required ]  WPD_PROPERTY_OBJECT_MANAGEMENT_NUM_BYTES_TO_WRITE 
                    //     [ Required ]  WPD_PROPERTY_OBJECT_MANAGEMENT_DATA 
                    // Results:
                    //     [ Required ]  WPD_PROPERTY_OBJECT_MANAGEMENT_NUM_BYTES_WRITTEN 
                    public static PropertyKey WriteObjectData => new PropertyKey(Guids.PortableDevices.CommandSystem.Object.Management, 4);
                    //
                    // WPD_COMMAND_OBJECT_MANAGEMENT_COMMIT_OBJECT 
                    //    This command is sent when a client has finished sending all the data associated with an object creation or update request-and wishes to ensure that the object is saved to the device. 
                    // Access:
                    //     (FILE_READ_ACCESS | FILE_WRITE_ACCESS)
                    // Parameters:
                    //     [ Required ]  WPD_PROPERTY_OBJECT_MANAGEMENT_CONTEXT 
                    // Results:
                    //     [ Required ]  WPD_PROPERTY_OBJECT_MANAGEMENT_OBJECT_ID 
                    public static PropertyKey CommitObject => new PropertyKey(Guids.PortableDevices.CommandSystem.Object.Management, 5);
                    //
                    // WPD_COMMAND_OBJECT_MANAGEMENT_REVERT_OBJECT 
                    //    This command is sent when a client wants to cancel the object creation or update request that is currently still in progress. 
                    // Access:
                    //     (FILE_READ_ACCESS | FILE_WRITE_ACCESS)
                    // Parameters:
                    //     [ Required ]  WPD_PROPERTY_OBJECT_MANAGEMENT_CONTEXT 
                    // Results:
                    //     None
                    public static PropertyKey RevertObject => new PropertyKey(Guids.PortableDevices.CommandSystem.Object.Management, 6);
                    //
                    // WPD_COMMAND_OBJECT_MANAGEMENT_DELETE_OBJECTS 
                    //    This command is sent when the client wishes to remove a set of objects from the device. 
                    // Access:
                    //     (FILE_READ_ACCESS | FILE_WRITE_ACCESS)
                    // Parameters:
                    //     [ Required ]  WPD_PROPERTY_OBJECT_MANAGEMENT_DELETE_OPTIONS 
                    //     [ Required ]  WPD_PROPERTY_OBJECT_MANAGEMENT_OBJECT_IDS 
                    // Results:
                    //     [ Required ]  WPD_PROPERTY_OBJECT_MANAGEMENT_DELETE_RESULTS 
                    public static PropertyKey DeleteObjects => new PropertyKey(Guids.PortableDevices.CommandSystem.Object.Management, 7);
                    //
                    // WPD_COMMAND_OBJECT_MANAGEMENT_MOVE_OBJECTS 
                    //    This command will move the specified objects to the destination folder. 
                    // Access:
                    //     (FILE_READ_ACCESS | FILE_WRITE_ACCESS)
                    // Parameters:
                    //     [ Required ]  WPD_PROPERTY_OBJECT_MANAGEMENT_OBJECT_IDS 
                    //     [ Required ]  WPD_PROPERTY_OBJECT_MANAGEMENT_DESTINATION_FOLDER_OBJECT_ID 
                    // Results:
                    //     [ Required ]  WPD_PROPERTY_OBJECT_MANAGEMENT_MOVE_RESULTS 
                    public static PropertyKey MoveObjects => new PropertyKey(Guids.PortableDevices.CommandSystem.Object.Management, 8);
                    //
                    // WPD_COMMAND_OBJECT_MANAGEMENT_COPY_OBJECTS 
                    //    This command will copy the specified objects to the destination folder. 
                    // Access:
                    //     (FILE_READ_ACCESS | FILE_WRITE_ACCESS)
                    // Parameters:
                    //     [ Required ]  WPD_PROPERTY_OBJECT_MANAGEMENT_OBJECT_IDS 
                    //     [ Required ]  WPD_PROPERTY_OBJECT_MANAGEMENT_DESTINATION_FOLDER_OBJECT_ID 
                    // Results:
                    //     [ Required ]  WPD_PROPERTY_OBJECT_MANAGEMENT_COPY_RESULTS 
                    public static PropertyKey CopyObjects => new PropertyKey(Guids.PortableDevices.CommandSystem.Object.Management, 9);
                    //
                    // WPD_COMMAND_OBJECT_MANAGEMENT_UPDATE_OBJECT_WITH_PROPERTIES_AND_DATA 
                    //    This command is sent when a client wants to update the object's data and dependent properties simultaneously. 
                    // Access:
                    //     (FILE_READ_ACCESS | FILE_WRITE_ACCESS)
                    // Parameters:
                    //     [ Required ]  WPD_PROPERTY_OBJECT_MANAGEMENT_OBJECT_ID 
                    //     [ Required ]  WPD_PROPERTY_OBJECT_MANAGEMENT_UPDATE_PROPERTIES 
                    // Results:
                    //     [ Required ]  WPD_PROPERTY_OBJECT_MANAGEMENT_CONTEXT 
                    //     [ Required ]  WPD_PROPERTY_OBJECT_MANAGEMENT_OPTIMAL_TRANSFER_BUFFER_SIZE 
                    public static PropertyKey UpdateObjectWithPropertiesAndData => new PropertyKey(Guids.PortableDevices.CommandSystem.Object.Management, 10);

                }

                public static class Parameters

                {

                    // ======== Command Parameters ======== 

                    //
                    // WPD_PROPERTY_OBJECT_MANAGEMENT_CREATION_PROPERTIES  
                    //   [ VT_UNKNOWN ] This is an IPortableDeviceValues which specifies the properties used to create the new object.
                    public static PropertyKey CreationProperties => new PropertyKey(Guids.PortableDevices.CommandSystem.Object.Management, 1001);
                    //
                    // WPD_PROPERTY_OBJECT_MANAGEMENT_CONTEXT  
                    //   [ VT_LPWSTR ] This is a driver-specified identifier for the context associated with this 'create object' operation.
                    public static PropertyKey Context => new PropertyKey(Guids.PortableDevices.CommandSystem.Object.Management, 1002);
                    //
                    // WPD_PROPERTY_OBJECT_MANAGEMENT_NUM_BYTES_TO_WRITE  
                    //   [ VT_UI4 ] Specifies the number of bytes the client is requesting to write.
                    public static PropertyKey NumBytesToWrite => new PropertyKey(Guids.PortableDevices.CommandSystem.Object.Management, 1003);
                    //
                    // WPD_PROPERTY_OBJECT_MANAGEMENT_NUM_BYTES_WRITTEN  
                    //   [ VT_UI4 ] Indicates the number of bytes written for the object.
                    public static PropertyKey NumBytesWritten => new PropertyKey(Guids.PortableDevices.CommandSystem.Object.Management, 1004);
                    //
                    // WPD_PROPERTY_OBJECT_MANAGEMENT_DATA  
                    //   [ VT_VECTOR | VT_UI1 ] Indicates binary data of the object being created on the device.
                    public static PropertyKey Data => new PropertyKey(Guids.PortableDevices.CommandSystem.Object.Management, 1005);
                    //
                    // WPD_PROPERTY_OBJECT_MANAGEMENT_OBJECT_ID  
                    //   [ VT_LPWSTR ] Identifies a newly created object on the device.
                    public static PropertyKey ObjectId => new PropertyKey(Guids.PortableDevices.CommandSystem.Object.Management, 1006);
                    //
                    // WPD_PROPERTY_OBJECT_MANAGEMENT_DELETE_OPTIONS  
                    //   [ VT_UI4 ] Indicates if the delete operation should be recursive or not.
                    public static PropertyKey DeleteOptions => new PropertyKey(Guids.PortableDevices.CommandSystem.Object.Management, 1007);
                    //
                    // WPD_PROPERTY_OBJECT_MANAGEMENT_OPTIMAL_TRANSFER_BUFFER_SIZE  
                    //   [ VT_UI4 ] Indicates the optimal transfer buffer size (in bytes) that clients should use when writing this object's data.
                    public static PropertyKey OptimalTransferBufferSize => new PropertyKey(Guids.PortableDevices.CommandSystem.Object.Management, 1008);
                    //
                    // WPD_PROPERTY_OBJECT_MANAGEMENT_OBJECT_IDS  
                    //   [ VT_UNKNOWN ] IPortableDevicePropVariantCollection of type VT_LPWSTR-containing the ObjectIDs to delete.
                    public static PropertyKey ObjectIds => new PropertyKey(Guids.PortableDevices.CommandSystem.Object.Management, 1009);
                    //
                    // WPD_PROPERTY_OBJECT_MANAGEMENT_DELETE_RESULTS  
                    //   [ VT_UNKNOWN ] IPortableDevicePropVariantCollection of type VT_ERROR-where each element is the HRESULT indicating the success or failure of the operation.
                    public static PropertyKey DeleteResults => new PropertyKey(Guids.PortableDevices.CommandSystem.Object.Management, 1010);
                    //
                    // WPD_PROPERTY_OBJECT_MANAGEMENT_DESTINATION_FOLDER_OBJECT_ID  
                    //   [ VT_LPWSTR ] Indicates the destination folder for the move operation.
                    public static PropertyKey DestinationFolderObjectId => new PropertyKey(Guids.PortableDevices.CommandSystem.Object.Management, 1011);
                    //
                    // WPD_PROPERTY_OBJECT_MANAGEMENT_MOVE_RESULTS  
                    //   [ VT_UNKNOWN ] IPortableDevicePropVariantCollection of type VT_ERROR-where each element is the HRESULT indicating the success or failure of the operation.
                    public static PropertyKey MoveResults => new PropertyKey(Guids.PortableDevices.CommandSystem.Object.Management, 1012);
                    //
                    // WPD_PROPERTY_OBJECT_MANAGEMENT_COPY_RESULTS  
                    //   [ VT_UNKNOWN ] IPortableDevicePropVariantCollection of type VT_ERROR-where each element is the HRESULT indicating the success or failure of the operation.
                    public static PropertyKey CopyResults => new PropertyKey(Guids.PortableDevices.CommandSystem.Object.Management, 1013);
                    //
                    // WPD_PROPERTY_OBJECT_MANAGEMENT_UPDATE_PROPERTIES  
                    //   [ VT_UNKNOWN ] IPortableDeviceValues containing the object properties to update.
                    public static PropertyKey UpdateProperties => new PropertyKey(Guids.PortableDevices.CommandSystem.Object.Management, 1014);
                    //
                    // WPD_PROPERTY_OBJECT_MANAGEMENT_PROPERTY_KEYS  
                    //   [ VT_UNKNOWN ] IPortableDeviceKeyCollection containing the property keys required to update this object.
                    public static PropertyKey PropertyKeys => new PropertyKey(Guids.PortableDevices.CommandSystem.Object.Management, 1015);
                    //
                    // WPD_PROPERTY_OBJECT_MANAGEMENT_OBJECT_FORMAT  
                    //   [ VT_CLSID ] Indicates the object format the caller is interested in.
                    public static PropertyKey ObjectFormat => new PropertyKey(Guids.PortableDevices.CommandSystem.Object.Management, 1016);

                }

                public static class Options

                {

                    // ======== Command Options ========
                    //
                    // WPD_OPTION_OBJECT_MANAGEMENT_RECURSIVE_DELETE_SUPPORTED 
                    //   [ VT_BOOL ]  Indicates whether the driver supports recursive deletion. 
                    public static PropertyKey RecursiveDeleteSupported => new PropertyKey(Guids.PortableDevices.CommandSystem.Object.Management, 5001);

                }

            }

        }

        /// <summary>
        /// This class defines all Commands-Parameters and Options associated with: <see cref="Guids.PortableDevices.CommandSystem.Capabilities"/>. This command category is used to query capabilities of the device.
        /// </summary>
        public static class Capability

        {

            public static class Commands

            {

                // ======== Commands ========
                //
                // WPD_COMMAND_CAPABILITIES_GET_SUPPORTED_COMMANDS 
                //    Return all commands supported by this driver. This includes custom commands-if any. 
                // Access:
                //     FILE_READ_ACCESS
                // Parameters:
                //     None
                // Results:
                //     [ Required ]  WPD_PROPERTY_CAPABILITIES_SUPPORTED_COMMANDS 
                public static PropertyKey GetSupportedCommands => new PropertyKey(Guids.PortableDevices.CommandSystem.Capabilities, 2);
                //
                // WPD_COMMAND_CAPABILITIES_GET_COMMAND_OPTIONS 
                //    Returns the supported options for the specified command. 
                // Access:
                //     FILE_READ_ACCESS
                // Parameters:
                //     [ Required ]  WPD_PROPERTY_CAPABILITIES_COMMAND 
                // Results:
                //     [ Required ]  WPD_PROPERTY_CAPABILITIES_COMMAND_OPTIONS 
                public static PropertyKey GetCommandOptions => new PropertyKey(Guids.PortableDevices.CommandSystem.Capabilities, 3);
                //
                // WPD_COMMAND_CAPABILITIES_GET_SUPPORTED_FUNCTIONAL_CATEGORIES 
                //    This command is used by clients to query the functional categories supported by the driver. 
                // Access:
                //     FILE_READ_ACCESS
                // Parameters:
                //     None
                // Results:
                //     [ Required ]  WPD_PROPERTY_CAPABILITIES_FUNCTIONAL_CATEGORIES 
                public static PropertyKey GetSupportedFunctionalCategories => new PropertyKey(Guids.PortableDevices.CommandSystem.Capabilities, 4);
                //
                // WPD_COMMAND_CAPABILITIES_GET_FUNCTIONAL_OBJECTS 
                //    Retrieves the ObjectIDs of the objects belonging to the specified functional category. 
                // Access:
                //     FILE_READ_ACCESS
                // Parameters:
                //     [ Required ]  WPD_PROPERTY_CAPABILITIES_FUNCTIONAL_CATEGORY 
                // Results:
                //     [ Required ]  WPD_PROPERTY_CAPABILITIES_FUNCTIONAL_OBJECTS 
                public static PropertyKey GetFunctionalObjects => new PropertyKey(Guids.PortableDevices.CommandSystem.Capabilities, 5);
                //
                // WPD_COMMAND_CAPABILITIES_GET_SUPPORTED_CONTENT_TYPES 
                //    Retrieves the list of content types supported by this driver for the specified functional category. 
                // Access:
                //     FILE_READ_ACCESS
                // Parameters:
                //     [ Required ]  WPD_PROPERTY_CAPABILITIES_FUNCTIONAL_CATEGORY 
                // Results:
                //     [ Required ]  WPD_PROPERTY_CAPABILITIES_CONTENT_TYPES 
                public static PropertyKey GetSupportedContentTypes => new PropertyKey(Guids.PortableDevices.CommandSystem.Capabilities, 6);
                //
                // WPD_COMMAND_CAPABILITIES_GET_SUPPORTED_FORMATS 
                //    This command is used to query the possible formats supported by the specified content type (e.g. for image objects-the driver may choose to support JPEG and BMP files). 
                // Access:
                //     FILE_READ_ACCESS
                // Parameters:
                //     [ Required ]  WPD_PROPERTY_CAPABILITIES_CONTENT_TYPE 
                // Results:
                //     [ Required ]  WPD_PROPERTY_CAPABILITIES_FORMATS 
                public static PropertyKey GetSupportedFormats => new PropertyKey(Guids.PortableDevices.CommandSystem.Capabilities, 7);
                //
                // WPD_COMMAND_CAPABILITIES_GET_SUPPORTED_FORMAT_PROPERTIES 
                //    Get the list of properties that an object of the given format supports. 
                // Access:
                //     FILE_READ_ACCESS
                // Parameters:
                //     [ Required ]  WPD_PROPERTY_CAPABILITIES_FORMAT 
                // Results:
                //     [ Required ]  WPD_PROPERTY_CAPABILITIES_PROPERTY_KEYS 
                public static PropertyKey GetSupportedFormatProperties => new PropertyKey(Guids.PortableDevices.CommandSystem.Capabilities, 8);
                //
                // WPD_COMMAND_CAPABILITIES_GET_FIXED_PROPERTY_ATTRIBUTES 
                //    Returns the property attributes that are the same for all objects of the given format. 
                // Access:
                //     FILE_READ_ACCESS
                // Parameters:
                //     [ Required ]  WPD_PROPERTY_CAPABILITIES_FORMAT 
                //     [ Required ]  WPD_PROPERTY_CAPABILITIES_PROPERTY_KEYS 
                // Results:
                //     [ Required ]  WPD_PROPERTY_CAPABILITIES_PROPERTY_ATTRIBUTES 
                public static PropertyKey GetFixedPropertyAttributes => new PropertyKey(Guids.PortableDevices.CommandSystem.Capabilities, 9);
                //
                // WPD_COMMAND_CAPABILITIES_GET_SUPPORTED_EVENTS 
                //    Return all events supported by this driver. This includes custom events-if any. 
                // Access:
                //     FILE_READ_ACCESS
                // Parameters:
                //     None
                // Results:
                //     [ Required ]  WPD_PROPERTY_CAPABILITIES_SUPPORTED_EVENTS 
                public static PropertyKey GetSupportedEvents => new PropertyKey(Guids.PortableDevices.CommandSystem.Capabilities, 10);
                //
                // WPD_COMMAND_CAPABILITIES_GET_EVENT_OPTIONS 
                //    Return extra information about a specified event-such as whether the event is for notification or action purposes. 
                // Access:
                //     FILE_READ_ACCESS
                // Parameters:
                //     [ Required ]  WPD_PROPERTY_CAPABILITIES_EVENT 
                // Results:
                //     [ Required ]  WPD_PROPERTY_CAPABILITIES_EVENT_OPTIONS 
                public static PropertyKey GetEventOptions => new PropertyKey(Guids.PortableDevices.CommandSystem.Capabilities, 11);

            }

            public static class Parameters

            {

                // ======== Command Parameters ======== 

                //
                // WPD_PROPERTY_CAPABILITIES_SUPPORTED_COMMANDS  
                //   [ VT_UNKNOWN ] IPortableDeviceKeyCollection containing all commands a driver supports.
                public static PropertyKey SupportedCommands => new PropertyKey(Guids.PortableDevices.CommandSystem.Capabilities, 1001);
                //
                // WPD_PROPERTY_CAPABILITIES_COMMAND  
                //   [ VT_UNKNOWN ] Indicates the command whose options the caller is interested in.
                public static PropertyKey Command => new PropertyKey(Guids.PortableDevices.CommandSystem.Capabilities, 1002);
                //
                // WPD_PROPERTY_CAPABILITIES_COMMAND_OPTIONS  
                //   [ VT_UNKNOWN ] Contains an IPortableDeviceValues with the relevant command options.
                public static PropertyKey CommandOptions => new PropertyKey(Guids.PortableDevices.CommandSystem.Capabilities, 1003);
                //
                // WPD_PROPERTY_CAPABILITIES_FUNCTIONAL_CATEGORIES  
                //   [ VT_UNKNOWN ] An IPortableDevicePropVariantCollection of type VT_CLSID which indicates the functional categories supported by the driver.
                public static PropertyKey FunctionalCategories => new PropertyKey(Guids.PortableDevices.CommandSystem.Capabilities, 1004);
                //
                // WPD_PROPERTY_CAPABILITIES_FUNCTIONAL_CATEGORY  
                //   [ VT_CLSID ] The category the caller is interested in.
                public static PropertyKey FunctionalCategory => new PropertyKey(Guids.PortableDevices.CommandSystem.Capabilities, 1005);
                //
                // WPD_PROPERTY_CAPABILITIES_FUNCTIONAL_OBJECTS  
                //   [ VT_UNKNOWN ] An IPortableDevicePropVariantCollection (of type VT_LPWSTR) containing the ObjectIDs of the functional objects who belong to the specified functional category.
                public static PropertyKey FunctionalObjects => new PropertyKey(Guids.PortableDevices.CommandSystem.Capabilities, 1006);
                //
                // WPD_PROPERTY_CAPABILITIES_CONTENT_TYPES  
                //   [ VT_UNKNOWN ] Indicates list of content types supported for the specified functional category.
                public static PropertyKey ContentTypes => new PropertyKey(Guids.PortableDevices.CommandSystem.Capabilities, 1007);
                //
                // WPD_PROPERTY_CAPABILITIES_CONTENT_TYPE  
                //   [ VT_CLSID ] Indicates the content type whose formats the caller is interested in.
                public static PropertyKey ContentType => new PropertyKey(Guids.PortableDevices.CommandSystem.Capabilities, 1008);
                //
                // WPD_PROPERTY_CAPABILITIES_FORMATS  
                //   [ VT_UNKNOWN ] An IPortableDevicePropVariantCollection of VT_CLSID values indicating the formats supported for the specified content type.
                public static PropertyKey Formats => new PropertyKey(Guids.PortableDevices.CommandSystem.Capabilities, 1009);
                //
                // WPD_PROPERTY_CAPABILITIES_FORMAT  
                //   [ VT_CLSID ] Specifies the format the caller is interested in.
                public static PropertyKey Format => new PropertyKey(Guids.PortableDevices.CommandSystem.Capabilities, 1010);
                //
                // WPD_PROPERTY_CAPABILITIES_PROPERTY_KEYS  
                //   [ VT_UNKNOWN ] An IPortableDeviceKeyCollection containing the property keys.
                public static PropertyKey PropertyKeys => new PropertyKey(Guids.PortableDevices.CommandSystem.Capabilities, 1011);
                //
                // WPD_PROPERTY_CAPABILITIES_PROPERTY_ATTRIBUTES  
                //   [ VT_UNKNOWN ] An IPortableDeviceValues containing the property attributes.
                public static PropertyKey PropertyAttributes => new PropertyKey(Guids.PortableDevices.CommandSystem.Capabilities, 1012);
                //
                // WPD_PROPERTY_CAPABILITIES_SUPPORTED_EVENTS  
                //   [ VT_UNKNOWN ] IPortableDevicePropVariantCollection of VT_CLSID values containing all events a driver supports.
                public static PropertyKey SupportedEvents => new PropertyKey(Guids.PortableDevices.CommandSystem.Capabilities, 1013);
                //
                // WPD_PROPERTY_CAPABILITIES_EVENT  
                //   [ VT_CLSID ] Indicates the event the caller is interested in.
                public static PropertyKey Event => new PropertyKey(Guids.PortableDevices.CommandSystem.Capabilities, 1014);
                //
                // WPD_PROPERTY_CAPABILITIES_EVENT_OPTIONS  
                //   [ VT_UNKNOWN ] Contains an IPortableDeviceValues with the relevant event options.
                public static PropertyKey EventOptions => new PropertyKey(Guids.PortableDevices.CommandSystem.Capabilities, 1015);

            }

        }

        /// <summary>
        /// This class defines all Commands-Parameters and Options associated with: <see cref="Guids.PortableDevices.CommandSystem.Storage"/>. This category is for commands and parameters for storage functional objects.
        /// </summary>
        public static class Storage

        {

            public static class Commands

            {

                // ======== Commands ========
                //
                // WPD_COMMAND_STORAGE_FORMAT 
                //    This command will format the storage. 
                // Access:
                //     (FILE_READ_ACCESS | FILE_WRITE_ACCESS)
                // Parameters:
                //     [ Required ]  WPD_PROPERTY_STORAGE_OBJECT_ID 
                // Results:
                //     None
                public static PropertyKey Format => new PropertyKey(Guids.PortableDevices.CommandSystem.Storage, 2);
                //
                // WPD_COMMAND_STORAGE_EJECT 
                //    This will eject the storage-if it is a removable store and is capable of being ejected by the device. 
                // Access:
                //     (FILE_READ_ACCESS | FILE_WRITE_ACCESS)
                // Parameters:
                //     [ Required ]  WPD_PROPERTY_STORAGE_OBJECT_ID 
                // Results:
                //     None
                public static PropertyKey Eject => new PropertyKey(Guids.PortableDevices.CommandSystem.Storage, 4);

            }

            public static class Parameters

            {

                // ======== Command Parameters ======== 

                //
                // WPD_PROPERTY_STORAGE_OBJECT_ID  
                //   [ VT_LPWSTR ] Indicates the object to format-move or eject.
                public static PropertyKey ObjectId => new PropertyKey(Guids.PortableDevices.CommandSystem.Storage, 1001);
                //
                // WPD_PROPERTY_STORAGE_DESTINATION_OBJECT_ID  
                //   [ VT_LPWSTR ] Indicates the (folder) object destination for a move operation.
                public static PropertyKey DestinationObjectId => new PropertyKey(Guids.PortableDevices.CommandSystem.Storage, 1002);

            }

        }

        /// <summary>
        /// This class defines all Commands-Parameters and Options associated with: <see cref="Guids.PortableDevices.CommandSystem.SMS"/>. The commands in this category relate to Short-Message-Service functionality-typically exposed on mobile phones.
        /// </summary>
        public static class SMS

        {

            public static class Commands

            {

                // ======== Commands ========
                //
                // WPD_COMMAND_SMS_SEND 
                //    This command is used to initiate the sending of an SMS message. 
                // Access:
                //     (FILE_READ_ACCESS | FILE_WRITE_ACCESS)
                // Parameters:
                //     [ Required ]  WPD_PROPERTY_COMMON_COMMAND_TARGET 
                //     [ Required ]  WPD_PROPERTY_SMS_RECIPIENT 
                //     [ Required ]  WPD_PROPERTY_SMS_MESSAGE_TYPE 
                //     [ Optional ]  WPD_PROPERTY_SMS_TEXT_MESSAGE 
                //     [ Optional ]  WPD_PROPERTY_SMS_BINARY_MESSAGE 
                // Results:
                //     None
                public static PropertyKey Send => new PropertyKey(Guids.PortableDevices.CommandSystem.SMS, 2);

            }

            public static class Parameters

            {

                // ======== Command Parameters ======== 

                //
                // WPD_PROPERTY_SMS_RECIPIENT  
                //   [ VT_LPWSTR ] Indicates the recipient's address.
                public static PropertyKey Recipient => new PropertyKey(Guids.PortableDevices.CommandSystem.SMS, 1001);
                //
                // WPD_PROPERTY_SMS_MESSAGE_TYPE  
                //   [ VT_UI4 ] Indicates whether the message is binary or text.
                public static PropertyKey MessageType => new PropertyKey(Guids.PortableDevices.CommandSystem.SMS, 1002);
                //
                // WPD_PROPERTY_SMS_TEXT_MESSAGE  
                //   [ VT_LPWSTR ] if WPD_PROPERTY_SMS_MESSAGE_TYPE == SMS_TEXT_MESSAGE-then this will contain the message body.
                public static PropertyKey TextMessage => new PropertyKey(Guids.PortableDevices.CommandSystem.SMS, 1003);
                //
                // WPD_PROPERTY_SMS_BINARY_MESSAGE  
                //   [ VT_VECTOR | VT_UI1 ] if WPD_PROPERTY_SMS_MESSAGE_TYPE == SMS_BINARY_MESSAGE-then this will contain the binary message body.
                public static PropertyKey BinaryMessage => new PropertyKey(Guids.PortableDevices.CommandSystem.SMS, 1004);

            }

            public static class Options

            {

                // ======== Command Options ========
                //
                // WPD_OPTION_SMS_BINARY_MESSAGE_SUPPORTED 
                //   [ VT_BOOL ]  Indicates whether the driver can support binary messages as well as text messages. 
                public static PropertyKey BinaryMessageSupported => new PropertyKey(Guids.PortableDevices.CommandSystem.SMS, 5001);

            }

        }

        /// <summary>
        /// This class defines all Commands-Parameters and Options associated with: <see cref="Guids.PortableDevices.CommandSystem.StillImageCapture"/>.
        /// </summary>
        public static class StillImageCapture

        {

            public static class Commands

            {

                // ======== Commands ========
                //
                // WPD_COMMAND_STILL_IMAGE_CAPTURE_INITIATE 
                //    Initiates a still image capture. This is processed as a single command i.e. there is no start or stop required. 
                // Access:
                //     (FILE_READ_ACCESS | FILE_WRITE_ACCESS)
                // Parameters:
                //     [ Required ]  WPD_PROPERTY_COMMON_COMMAND_TARGET 
                // Results:
                //     None
                public static PropertyKey Initiate => new PropertyKey(Guids.PortableDevices.CommandSystem.StillImageCapture, 2);

            }

        }

        /// <summary>
        /// This class defines all Commands-Parameters and Options associated with: <see cref="Guids.PortableDevices.CommandSystem.MediaCapture"/>.
        /// </summary>
        public static class MediaCapture

        {

            public static class Commands

            {

                // ======== Commands ========
                //
                // WPD_COMMAND_MEDIA_CAPTURE_START 
                //    Initiates a media capture operation that will only be ended by a subsequent WPD_COMMAND_MEDIA_CAPTURE_STOP command. Typically used to capture media streams such as audio and video. 
                // Access:
                //     (FILE_READ_ACCESS | FILE_WRITE_ACCESS)
                // Parameters:
                //     [ Required ]  WPD_PROPERTY_COMMON_COMMAND_TARGET 
                // Results:
                //     None
                public static PropertyKey Start => new PropertyKey(Guids.PortableDevices.CommandSystem.MediaCapture, 2);
                //
                // WPD_COMMAND_MEDIA_CAPTURE_STOP 
                //    Ends a media capture operation started by a WPD_COMMAND_MEDIA_CAPTURE_START command. Typically used to end capture of media streams such as audio and video. 
                // Access:
                //     (FILE_READ_ACCESS | FILE_WRITE_ACCESS)
                // Parameters:
                //     [ Required ]  WPD_PROPERTY_COMMON_COMMAND_TARGET 
                // Results:
                //     None
                public static PropertyKey Stop => new PropertyKey(Guids.PortableDevices.CommandSystem.MediaCapture, 3);
                //
                // WPD_COMMAND_MEDIA_CAPTURE_PAUSE 
                //    Pauses a media capture operation started by a WPD_COMMAND_MEDIA_CAPTURE_START command. Typically used to pause capture of media streams such as audio and video. 
                // Access:
                //     (FILE_READ_ACCESS | FILE_WRITE_ACCESS)
                // Parameters:
                //     [ Required ]  WPD_PROPERTY_COMMON_COMMAND_TARGET 
                // Results:
                //     None
                public static PropertyKey Pause => new PropertyKey(Guids.PortableDevices.CommandSystem.MediaCapture, 4);

            }

        }

        /// <summary>
        /// This class defines all Commands-Parameters and Options associated with: <see cref="Guids.PortableDevices.CommandSystem.DeviceHints"/>. The commands in this category relate to hints that a device can provide to improve end-user experience.
        /// </summary>
        public static class DeviceHint

        {

            public static class Commands

            {

                // ======== Commands ========
                //
                // WPD_COMMAND_DEVICE_HINTS_GET_CONTENT_LOCATION 
                //    This command is used to retrieve the ObjectIDs of folders that contain the specified content type. 
                // Access:
                //     FILE_READ_ACCESS
                // Parameters:
                //     [ Required ]  WPD_PROPERTY_DEVICE_HINTS_CONTENT_TYPE 
                // Results:
                //     [ Required ]  WPD_PROPERTY_DEVICE_HINTS_CONTENT_LOCATIONS 
                public static PropertyKey GetContentLocation => new PropertyKey(Guids.PortableDevices.CommandSystem.DeviceHints, 2);

            }

            public static class Parameters

            {

                // ======== Command Parameters ======== 

                //
                // WPD_PROPERTY_DEVICE_HINTS_CONTENT_TYPE  
                //   [ VT_CLSID ] Indicates the WPD content type that the caller is looking for. For example-to get the top-level folder objects that contain images-this parameter would be WPD_CONTENT_TYPE_IMAGE.
                public static PropertyKey ContentType => new PropertyKey(Guids.PortableDevices.CommandSystem.DeviceHints, 1001);
                //
                // WPD_PROPERTY_DEVICE_HINTS_CONTENT_LOCATIONS  
                //   [ VT_UNKNOWN ] IPortableDevicePropVariantCollection of type VT_LPWSTR indicating a list of folder ObjectIDs.
                public static PropertyKey ContentLocations => new PropertyKey(Guids.PortableDevices.CommandSystem.DeviceHints, 1002);

            }

        }

        /// <summary>
        /// This class defines all Commands-Parameters and Options associated with: <see cref="Guids.PortableDevices.CommandSystem.ClassExtensionV1"/> and <see cref="Guids.PortableDevices.CommandSystem.ClassExtensionV2"/>. The commands in this category relate to the WPD device class extension.
        /// </summary>
        public static class ClassExtension

        {

            public static class Commands

            {

                // ======== Commands ========
                //
                // WPD_COMMAND_CLASS_EXTENSION_WRITE_DEVICE_INFORMATION 
                //    This command is used to update the a cache of device-specific information. 
                // Access:
                //     (FILE_READ_ACCESS | FILE_WRITE_ACCESS)
                // Parameters:
                //     [ Required ]  WPD_PROPERTY_CLASS_EXTENSION_DEVICE_INFORMATION_VALUES 
                // Results:
                //     [ Required ]  WPD_PROPERTY_CLASS_EXTENSION_DEVICE_INFORMATION_WRITE_RESULTS 
                public static PropertyKey WriteDeviceInformation => new PropertyKey(Guids.PortableDevices.CommandSystem.ClassExtensionV1, 2);

                // ======== Commands ========
                //
                // WPD_COMMAND_CLASS_EXTENSION_REGISTER_SERVICE_INTERFACES 
                //    This command is used to register a service's Plug and Play interfaces. 
                // Access:
                //     (FILE_READ_ACCESS | FILE_WRITE_ACCESS)
                // Parameters:
                //     [ Required ]  WPD_PROPERTY_CLASS_EXTENSION_SERVICE_OBJECT_ID 
                //     [ Required ]  WPD_PROPERTY_CLASS_EXTENSION_SERVICE_INTERFACES 
                // Results:
                //     [ Required ]  WPD_PROPERTY_CLASS_EXTENSION_SERVICE_REGISTRATION_RESULTS 
                public static PropertyKey RegisterServiceInterfaces => new PropertyKey(Guids.PortableDevices.CommandSystem.ClassExtensionV2, 2);
                //
                // WPD_COMMAND_CLASS_EXTENSION_UNREGISTER_SERVICE_INTERFACES 
                //    This command is used to unregister a service's Plug and Play interfaces. 
                // Access:
                //     (FILE_READ_ACCESS | FILE_WRITE_ACCESS)
                // Parameters:
                //     [ Required ]  WPD_PROPERTY_CLASS_EXTENSION_SERVICE_OBJECT_ID 
                //     [ Required ]  WPD_PROPERTY_CLASS_EXTENSION_SERVICE_INTERFACES 
                // Results:
                //     [ Required ]  WPD_PROPERTY_CLASS_EXTENSION_SERVICE_REGISTRATION_RESULTS 
                public static PropertyKey UnregisterServiceInterfaces => new PropertyKey(Guids.PortableDevices.CommandSystem.ClassExtensionV2, 3);

            }

            public static class Parameters

            {

                // ======== Command Parameters ======== 

                //
                // WPD_PROPERTY_CLASS_EXTENSION_DEVICE_INFORMATION_VALUES  
                //   [ VT_UNKNOWN ] This is an IPortableDeviceValues which contains the values.
                public static PropertyKey DeviceInformationValues => new PropertyKey(Guids.PortableDevices.CommandSystem.ClassExtensionV1, 1001);
                //
                // WPD_PROPERTY_CLASS_EXTENSION_DEVICE_INFORMATION_WRITE_RESULTS  
                //   [ VT_UNKNOWN ] This is an IPortableDeviceValues which contains the result of each value write operation.
                public static PropertyKey DeviceInformationWriteResults => new PropertyKey(Guids.PortableDevices.CommandSystem.ClassExtensionV1, 1002);

                // ======== Command Parameters ======== 

                //
                // WPD_PROPERTY_CLASS_EXTENSION_SERVICE_OBJECT_ID  
                //   [ VT_LPWSTR ] The Object ID of the service.
                public static PropertyKey ServiceObjectId => new PropertyKey(Guids.PortableDevices.CommandSystem.ClassExtensionV2, 1001);
                //
                // WPD_PROPERTY_CLASS_EXTENSION_SERVICE_INTERFACES  
                //   [ VT_UNKNOWN ] This is an IPortablePropVariantCollection of type VT_CLSID which contains the interface GUIDs that this service implements-including the service type GUID.
                public static PropertyKey ServiceInterfaces => new PropertyKey(Guids.PortableDevices.CommandSystem.ClassExtensionV2, 1002);
                //
                // WPD_PROPERTY_CLASS_EXTENSION_SERVICE_REGISTRATION_RESULTS  
                //   [ VT_UNKNOWN ] This is an IPortablePropVariantCollection of type VT_ERROR-where each element is the HRESULT indicating the success or failure of the operation.
                public static PropertyKey ServiceRegistrationResults => new PropertyKey(Guids.PortableDevices.CommandSystem.ClassExtensionV2, 1003);

            }

        }

        public static class NetworkConfiguration

        {

            public static class Commands

            {

                // ======== Commands ========
                //
                // WPD_COMMAND_GENERATE_KEYPAIR 
                //    Initiates the generation of a public/private key pair and returns the public key. 
                // Access:
                //     (FILE_READ_ACCESS | FILE_WRITE_ACCESS)
                // Parameters:
                //     None
                // Results:
                //     [ Required ]  WPD_PROPERTY_PUBLIC_KEY 
                public static PropertyKey GenerateKeyPair => new PropertyKey(Guids.PortableDevices.CommandSystem.NetworkConfiguration, 2);
                //
                // WPD_COMMAND_COMMIT_KEYPAIR 
                //    Commits a public/private key pair. 
                // Access:
                //     (FILE_READ_ACCESS | FILE_WRITE_ACCESS)
                // Parameters:
                //     None
                // Results:
                //     None
                public static PropertyKey CommitKeyPair => new PropertyKey(Guids.PortableDevices.CommandSystem.NetworkConfiguration, 3);
                //
                // WPD_COMMAND_PROCESS_WIRELESS_PROFILE 
                //    Initiates the processing of a Wireless Profile file. 
                // Access:
                //     (FILE_READ_ACCESS | FILE_WRITE_ACCESS)
                // Parameters:
                //     [ Required ]  WPD_PROPERTY_OBJECT_PROPERTIES_OBJECT_ID 
                // Results:
                //     None
                public static PropertyKey ProcessWirelessProfile => new PropertyKey(Guids.PortableDevices.CommandSystem.NetworkConfiguration, 4);

            }

            public static class CommandParameters

            {

                // ======== Command Parameters ======== 

                //
                // WPD_PROPERTY_PUBLIC_KEY  
                //   [ VT_VECTOR | VT_UI1 ] A public key generated for RSA key exchange.
                public static PropertyKey PublicKey => new PropertyKey(Guids.PortableDevices.CommandSystem.NetworkConfiguration, 1001);

            }

        }

        namespace Service

        {

            public static class Common

            {

                public static class Commands

                {

                    // ======== Commands ========
                    //
                    // WPD_COMMAND_SERVICE_COMMON_GET_SERVICE_OBJECT_ID 
                    //    This command is used to get the service object identifier. 
                    // Access:
                    //     FILE_READ_ACCESS
                    // Parameters:
                    //     None
                    // Results:
                    //     [ Required ]  WPD_PROPERTY_SERVICE_OBJECT_ID 
                    public static PropertyKey GetServiceObjectId => new PropertyKey(Guids.PortableDevices.CommandSystem.Service.Common, 2);

                }

                public static class CommandParameters

                {

                    // ======== Command Parameters ======== 

                    //
                    // WPD_PROPERTY_SERVICE_OBJECT_ID  
                    //   [ VT_LPWSTR ] Contains the service object identifier.
                    public static PropertyKey ObjectId => new PropertyKey(Guids.PortableDevices.CommandSystem.Service.Common, 1001);

                }

            }

            public static class Capability

            {

                public static class Commands

                {

                    // ======== Commands ========
                    //
                    // WPD_COMMAND_SERVICE_CAPABILITIES_GET_SUPPORTED_METHODS 
                    //    This command is used to get the methods that apply to a service. 
                    // Access:
                    //     FILE_READ_ACCESS
                    // Parameters:
                    //     None
                    // Results:
                    //     [ Required ]  WPD_PROPERTY_SERVICE_CAPABILITIES_SUPPORTED_METHODS 
                    public static PropertyKey GetSupportedMethods => new PropertyKey(Guids.PortableDevices.CommandSystem.Service.Capabilities, 2);
                    //
                    // WPD_COMMAND_SERVICE_CAPABILITIES_GET_SUPPORTED_METHODS_BY_FORMAT 
                    //    This command is used to get the methods that apply to a format of a service. 
                    // Access:
                    //     FILE_READ_ACCESS
                    // Parameters:
                    //     [ Required ]  WPD_PROPERTY_SERVICE_CAPABILITIES_FORMAT 
                    // Results:
                    //     [ Required ]  WPD_PROPERTY_SERVICE_CAPABILITIES_SUPPORTED_METHODS 
                    public static PropertyKey GetSupportedMethodsByFormat => new PropertyKey(Guids.PortableDevices.CommandSystem.Service.Capabilities, 3);
                    //
                    // WPD_COMMAND_SERVICE_CAPABILITIES_GET_METHOD_ATTRIBUTES 
                    //    This command is used to get the attributes of a method. 
                    // Access:
                    //     FILE_READ_ACCESS
                    // Parameters:
                    //     [ Required ]  WPD_PROPERTY_SERVICE_CAPABILITIES_METHOD 
                    // Results:
                    //     [ Required ]  WPD_PROPERTY_SERVICE_CAPABILITIES_METHOD_ATTRIBUTES 
                    public static PropertyKey GetMethodAttributes => new PropertyKey(Guids.PortableDevices.CommandSystem.Service.Capabilities, 4);
                    //
                    // WPD_COMMAND_SERVICE_CAPABILITIES_GET_METHOD_PARAMETER_ATTRIBUTES 
                    //    This command is used to get the attributes of a parameter used in a method. 
                    // Access:
                    //     FILE_READ_ACCESS
                    // Parameters:
                    //     [ Required ]  WPD_PROPERTY_SERVICE_CAPABILITIES_METHOD 
                    //     [ Required ]  WPD_PROPERTY_SERVICE_CAPABILITIES_PARAMETER 
                    // Results:
                    //     [ Required ]  WPD_PROPERTY_SERVICE_CAPABILITIES_PARAMETER_ATTRIBUTES 
                    public static PropertyKey GetMethodParameterAttributes => new PropertyKey(Guids.PortableDevices.CommandSystem.Service.Capabilities, 5);
                    //
                    // WPD_COMMAND_SERVICE_CAPABILITIES_GET_SUPPORTED_FORMATS 
                    //    This command is used to get formats supported by this service. 
                    // Access:
                    //     FILE_READ_ACCESS
                    // Parameters:
                    //     None
                    // Results:
                    //     [ Required ]  WPD_PROPERTY_SERVICE_CAPABILITIES_FORMATS 
                    public static PropertyKey GetSupportedFormats => new PropertyKey(Guids.PortableDevices.CommandSystem.Service.Capabilities, 6);
                    //
                    // WPD_COMMAND_SERVICE_CAPABILITIES_GET_FORMAT_ATTRIBUTES 
                    //    This command is used to get attributes of a format-such as the format name. 
                    // Access:
                    //     FILE_READ_ACCESS
                    // Parameters:
                    //     [ Required ]  WPD_PROPERTY_SERVICE_CAPABILITIES_FORMAT 
                    // Results:
                    //     [ Required ]  WPD_PROPERTY_SERVICE_CAPABILITIES_FORMAT_ATTRIBUTES 
                    public static PropertyKey GetFormatAttributes => new PropertyKey(Guids.PortableDevices.CommandSystem.Service.Capabilities, 7);
                    //
                    // WPD_COMMAND_SERVICE_CAPABILITIES_GET_SUPPORTED_FORMAT_PROPERTIES 
                    //    This command is used to get supported properties of a format. 
                    // Access:
                    //     FILE_READ_ACCESS
                    // Parameters:
                    //     [ Required ]  WPD_PROPERTY_SERVICE_CAPABILITIES_FORMAT 
                    // Results:
                    //     [ Required ]  WPD_PROPERTY_SERVICE_CAPABILITIES_PROPERTY_KEYS 
                    public static PropertyKey GetSupportedFormatProperties => new PropertyKey(Guids.PortableDevices.CommandSystem.Service.Capabilities, 8);
                    //
                    // WPD_COMMAND_SERVICE_CAPABILITIES_GET_FORMAT_PROPERTY_ATTRIBUTES 
                    //    This command is used to get the property attributes that are same for all objects of a given format on the service. 
                    // Access:
                    //     FILE_READ_ACCESS
                    // Parameters:
                    //     [ Required ]  WPD_PROPERTY_SERVICE_CAPABILITIES_FORMAT 
                    //     [ Required ]  WPD_PROPERTY_SERVICE_CAPABILITIES_PROPERTY_KEYS 
                    // Results:
                    //     [ Required ]  WPD_PROPERTY_SERVICE_CAPABILITIES_PROPERTY_ATTRIBUTES 
                    public static PropertyKey GetFormatPropertyAttributes => new PropertyKey(Guids.PortableDevices.CommandSystem.Service.Capabilities, 9);
                    //
                    // WPD_COMMAND_SERVICE_CAPABILITIES_GET_SUPPORTED_EVENTS 
                    //    This command is used to get the supported events of the service. 
                    // Access:
                    //     FILE_READ_ACCESS
                    // Parameters:
                    //     None
                    // Results:
                    //     [ Required ]  WPD_PROPERTY_SERVICE_CAPABILITIES_SUPPORTED_EVENTS 
                    public static PropertyKey GetSupportedEvents => new PropertyKey(Guids.PortableDevices.CommandSystem.Service.Capabilities, 10);
                    //
                    // WPD_COMMAND_SERVICE_CAPABILITIES_GET_EVENT_ATTRIBUTES 
                    //    This command is used to get the attributes of an event. 
                    // Access:
                    //     FILE_READ_ACCESS
                    // Parameters:
                    //     [ Required ]  WPD_PROPERTY_SERVICE_CAPABILITIES_EVENT 
                    // Results:
                    //     [ Required ]  WPD_PROPERTY_SERVICE_CAPABILITIES_EVENT_ATTRIBUTES 
                    public static PropertyKey GetEventAttributes => new PropertyKey(Guids.PortableDevices.CommandSystem.Service.Capabilities, 11);
                    //
                    // WPD_COMMAND_SERVICE_CAPABILITIES_GET_EVENT_PARAMETER_ATTRIBUTES 
                    //    This command is used to get the attributes of a parameter used in an event. 
                    // Access:
                    //     FILE_READ_ACCESS
                    // Parameters:
                    //     [ Required ]  WPD_PROPERTY_SERVICE_CAPABILITIES_EVENT 
                    //     [ Required ]  WPD_PROPERTY_SERVICE_CAPABILITIES_PARAMETER 
                    // Results:
                    //     [ Required ]  WPD_PROPERTY_SERVICE_CAPABILITIES_PARAMETER_ATTRIBUTES 
                    public static PropertyKey GetEventParameterAttributes => new PropertyKey(Guids.PortableDevices.CommandSystem.Service.Capabilities, 12);
                    //
                    // WPD_COMMAND_SERVICE_CAPABILITIES_GET_INHERITED_SERVICES 
                    //    This command is used to get the inherited services. 
                    // Access:
                    //     FILE_READ_ACCESS
                    // Parameters:
                    //     [ Required ]  WPD_PROPERTY_SERVICE_CAPABILITIES_INHERITANCE_TYPE 
                    // Results:
                    //     [ Required ]  WPD_PROPERTY_SERVICE_CAPABILITIES_INHERITED_SERVICES 
                    public static PropertyKey GetInheritedServices => new PropertyKey(Guids.PortableDevices.CommandSystem.Service.Capabilities, 13);
                    //
                    // WPD_COMMAND_SERVICE_CAPABILITIES_GET_FORMAT_RENDERING_PROFILES 
                    //    This command is used to get the resource rendering profiles for a format. 
                    // Access:
                    //     FILE_READ_ACCESS
                    // Parameters:
                    //     [ Required ]  WPD_PROPERTY_SERVICE_CAPABILITIES_FORMAT 
                    // Results:
                    //     [ Required ]  WPD_PROPERTY_SERVICE_CAPABILITIES_RENDERING_PROFILES 
                    public static PropertyKey GetFormatRenderingProfiles => new PropertyKey(Guids.PortableDevices.CommandSystem.Service.Capabilities, 14);
                    //
                    // WPD_COMMAND_SERVICE_CAPABILITIES_GET_SUPPORTED_COMMANDS 
                    //    Return all commands supported by this driver for a service. This includes custom commands-if any. 
                    // Access:
                    //     FILE_READ_ACCESS
                    // Parameters:
                    //     None
                    // Results:
                    //     [ Required ]  WPD_PROPERTY_SERVICE_CAPABILITIES_SUPPORTED_COMMANDS 
                    public static PropertyKey GetSupportedCommands => new PropertyKey(Guids.PortableDevices.CommandSystem.Service.Capabilities, 15);
                    //
                    // WPD_COMMAND_SERVICE_CAPABILITIES_GET_COMMAND_OPTIONS 
                    //    Returns the supported options for the specified command. 
                    // Access:
                    //     FILE_READ_ACCESS
                    // Parameters:
                    //     [ Required ]  WPD_PROPERTY_SERVICE_CAPABILITIES_COMMAND 
                    // Results:
                    //     [ Required ]  WPD_PROPERTY_SERVICE_CAPABILITIES_COMMAND_OPTIONS 
                    public static PropertyKey GetCommandOptions => new PropertyKey("24457E74-2E9F-44F9-8C57-1D1BCB170B8", 16);

                }

                public static class CommandParameters

                {

                    // ======== Command Parameters ======== 

                    //
                    // WPD_PROPERTY_SERVICE_CAPABILITIES_SUPPORTED_METHODS  
                    //   [ VT_UNKNOWN ] IPortableDevicePropVariantCollection (of type VT_CLSID) containing methods that apply to a service.
                    public static PropertyKey SupportedMethods => new PropertyKey(Guids.PortableDevices.CommandSystem.Service.Capabilities, 1001);
                    //
                    // WPD_PROPERTY_SERVICE_CAPABILITIES_FORMAT  
                    //   [ VT_CLSID ] Indicates the format the caller is interested in.
                    public static PropertyKey Format => new PropertyKey(Guids.PortableDevices.CommandSystem.Service.Capabilities, 1002);
                    //
                    // WPD_PROPERTY_SERVICE_CAPABILITIES_METHOD  
                    //   [ VT_CLSID ] Indicates the method the caller is interested in.
                    public static PropertyKey Method => new PropertyKey(Guids.PortableDevices.CommandSystem.Service.Capabilities, 1003);
                    //
                    // WPD_PROPERTY_SERVICE_CAPABILITIES_METHOD_ATTRIBUTES  
                    //   [ VT_UNKNOWN ] IPortableDeviceValues containing the method attributes.
                    public static PropertyKey MethodAttributes => new PropertyKey(Guids.PortableDevices.CommandSystem.Service.Capabilities, 1004);
                    //
                    // WPD_PROPERTY_SERVICE_CAPABILITIES_PARAMETER  
                    //   [ VT_UNKNOWN ] IPortableDeviceKeyCollection containing the parameter the caller is interested in.
                    public static PropertyKey Parameter => new PropertyKey(Guids.PortableDevices.CommandSystem.Service.Capabilities, 1005);
                    //
                    // WPD_PROPERTY_SERVICE_CAPABILITIES_PARAMETER_ATTRIBUTES  
                    //   [ VT_UNKNOWN ] IPortableDeviceValues containing the parameter attributes.
                    public static PropertyKey ParameterAttributes => new PropertyKey(Guids.PortableDevices.CommandSystem.Service.Capabilities, 1006);
                    //
                    // WPD_PROPERTY_SERVICE_CAPABILITIES_FORMATS  
                    //   [ VT_UNKNOWN ] IPortableDevicePropVariantCollection (of type VT_CLSID) containing the formats.
                    public static PropertyKey Formats => new PropertyKey(Guids.PortableDevices.CommandSystem.Service.Capabilities, 1007);
                    //
                    // WPD_PROPERTY_SERVICE_CAPABILITIES_FORMAT_ATTRIBUTES  
                    //   [ VT_UNKNOWN ] IPortableDeviceValues containing the format attributes-such as the format name and MIME Type.
                    public static PropertyKey FormatAttributes => new PropertyKey(Guids.PortableDevices.CommandSystem.Service.Capabilities, 1008);
                    //
                    // WPD_PROPERTY_SERVICE_CAPABILITIES_PROPERTY_KEYS  
                    //   [ VT_UNKNOWN ] IPortableDeviceKeyCollection containing the supported property keys.
                    public static PropertyKey PropertyKeys => new PropertyKey(Guids.PortableDevices.CommandSystem.Service.Capabilities, 1009);
                    //
                    // WPD_PROPERTY_SERVICE_CAPABILITIES_PROPERTY_ATTRIBUTES  
                    //   [ VT_UNKNOWN ] IPortableDeviceValues containing the property attributes.
                    public static PropertyKey PropertyAttributes => new PropertyKey(Guids.PortableDevices.CommandSystem.Service.Capabilities, 1010);
                    //
                    // WPD_PROPERTY_SERVICE_CAPABILITIES_SUPPORTED_EVENTS  
                    //   [ VT_UNKNOWN ] IPortableDevicePropVariantCollection (of type VT_CLSID) containing all events supported by the service.
                    public static PropertyKey SupportedEvents => new PropertyKey(Guids.PortableDevices.CommandSystem.Service.Capabilities, 1011);
                    //
                    // WPD_PROPERTY_SERVICE_CAPABILITIES_EVENT  
                    //   [ VT_CLSID ] Indicates the event the caller is interested in.
                    public static PropertyKey Event => new PropertyKey(Guids.PortableDevices.CommandSystem.Service.Capabilities, 1012);
                    //
                    // WPD_PROPERTY_SERVICE_CAPABILITIES_EVENT_ATTRIBUTES  
                    //   [ VT_UNKNOWN ] IPortableDeviceValues containing the event attributes.
                    public static PropertyKey EventAttributes => new PropertyKey(Guids.PortableDevices.CommandSystem.Service.Capabilities, 1013);
                    //
                    // WPD_PROPERTY_SERVICE_CAPABILITIES_INHERITANCE_TYPE  
                    //   [ VT_UI4 ] Indicates the inheritance type the caller is interested in.
                    public static PropertyKey InheritanceType => new PropertyKey(Guids.PortableDevices.CommandSystem.Service.Capabilities, 1014);
                    //
                    // WPD_PROPERTY_SERVICE_CAPABILITIES_INHERITED_SERVICES  
                    //   [ VT_UNKNOWN ] Contains the list of inherited services.
                    public static PropertyKey InheritedServices => new PropertyKey(Guids.PortableDevices.CommandSystem.Service.Capabilities, 1015);
                    //
                    // WPD_PROPERTY_SERVICE_CAPABILITIES_RENDERING_PROFILES  
                    //   [ VT_UNKNOWN ] Contains the list of format rendering profiles.
                    public static PropertyKey RenderingProfiles => new PropertyKey(Guids.PortableDevices.CommandSystem.Service.Capabilities, 1016);
                    //
                    // WPD_PROPERTY_SERVICE_CAPABILITIES_SUPPORTED_COMMANDS  
                    //   [ VT_UNKNOWN ] IPortableDeviceKeyCollection containing all commands a driver supports for a service.
                    public static PropertyKey SupportedCommands => new PropertyKey(Guids.PortableDevices.CommandSystem.Service.Capabilities, 1017);
                    //
                    // WPD_PROPERTY_SERVICE_CAPABILITIES_COMMAND  
                    //   [ VT_UNKNOWN ] Indicates the command whose options the caller is interested in.
                    public static PropertyKey Command => new PropertyKey(Guids.PortableDevices.CommandSystem.Service.Capabilities, 1018);
                    //
                    // WPD_PROPERTY_SERVICE_CAPABILITIES_COMMAND_OPTIONS  
                    //   [ VT_UNKNOWN ] Contains an IPortableDeviceValues with the relevant command options.
                    public static PropertyKey CommandOptions => new PropertyKey(Guids.PortableDevices.CommandSystem.Service.Capabilities, 1019);

                }

            }

            public static class Method

            {

                public static class Commands

                {

                    // ======== Commands ========
                    //
                    // WPD_COMMAND_SERVICE_METHODS_START_INVOKE 
                    //    Invokes a service method. 
                    // Access:
                    //     Dependent on the value of WPD_METHOD_ATTRIBUTE_ACCESS.
                    // Parameters:
                    //     [ Required ]  WPD_PROPERTY_SERVICE_METHOD 
                    //     [ Required ]  WPD_PROPERTY_SERVICE_METHOD_PARAMETER_VALUES 
                    // Results:
                    //     [ Required ]  WPD_PROPERTY_SERVICE_METHOD_CONTEXT 
                    public static PropertyKey StartInvoke => new PropertyKey(Guids.PortableDevices.CommandSystem.Service.Methods, 2);
                    //
                    // WPD_COMMAND_SERVICE_METHODS_CANCEL_INVOKE 
                    //    This command is sent when a client wants to cancel a method that is currently still in progress. 
                    // Access:
                    //     Dependent on the value of WPD_METHOD_ATTRIBUTE_ACCESS.
                    // Parameters:
                    //     [ Required ]  WPD_PROPERTY_SERVICE_METHOD_CONTEXT 
                    // Results:
                    //     None
                    public static PropertyKey CancelInvoke => new PropertyKey(Guids.PortableDevices.CommandSystem.Service.Methods, 3);
                    //
                    // WPD_COMMAND_SERVICE_METHODS_END_INVOKE 
                    //    This command is sent in response to a WPD_EVENT_SERVICE_METHOD_COMPLETE event from the driver to retrieve the method results. 
                    // Access:
                    //     Dependent on the value of WPD_METHOD_ATTRIBUTE_ACCESS.
                    // Parameters:
                    //     [ Required ]  WPD_PROPERTY_SERVICE_METHOD_CONTEXT 
                    // Results:
                    //     [ Required ]  WPD_PROPERTY_SERVICE_METHOD_RESULT_VALUES 
                    //     [ Required ]  WPD_PROPERTY_SERVICE_METHOD_HRESULT 
                    public static PropertyKey EndInvoke => new PropertyKey(Guids.PortableDevices.CommandSystem.Service.Methods, 4);

                }

                public static class CommandParameters

                {

                    // ======== Command Parameters ======== 

                    //
                    // WPD_PROPERTY_SERVICE_METHOD  
                    //   [ VT_CLSID ] Indicates the method to invoke.
                    public static PropertyKey ServiceMethod => new PropertyKey(Guids.PortableDevices.CommandSystem.Service.Methods, 1001);
                    //
                    // WPD_PROPERTY_SERVICE_METHOD_PARAMETER_VALUES  
                    //   [ VT_UNKNOWN ] IPortableDeviceValues containing the method parameters.
                    public static PropertyKey ParameterValues => new PropertyKey(Guids.PortableDevices.CommandSystem.Service.Methods, 1002);
                    //
                    // WPD_PROPERTY_SERVICE_METHOD_RESULT_VALUES  
                    //   [ VT_UNKNOWN ] IPortableDeviceValues containing the method results.
                    public static PropertyKey ResultValues => new PropertyKey(Guids.PortableDevices.CommandSystem.Service.Methods, 1003);
                    //
                    // WPD_PROPERTY_SERVICE_METHOD_CONTEXT  
                    //   [ VT_LPWSTR ] The unique context identifying this method operation.
                    public static PropertyKey Context => new PropertyKey(Guids.PortableDevices.CommandSystem.Service.Methods, 1004);
                    //
                    // WPD_PROPERTY_SERVICE_METHOD_HRESULT  
                    //   [ VT_ERROR ] Contains the status HRESULT of this method invocation.
                    public static PropertyKey HResult => new PropertyKey(Guids.PortableDevices.CommandSystem.Service.Methods, 1005);

                }

            }

        }

    }

    namespace ResourceSystem

    {

        /// <summary>
        /// This class defines all Resource keys. Resources are place-holders for binary data.
        /// </summary>
        public static class Resources

        {

            //
            //  WPD_RESOURCE_DEFAULT 
            // Represents the entire object's data. There can be only one default resource on an object. 
            public static PropertyKey Default => new PropertyKey("E81E79BE-34F0-41BF-B53F-F1A06AE87842", 0);
            //
            //  WPD_RESOURCE_CONTACT_PHOTO 
            // Represents the contact's photo data. 
            public static PropertyKey ContactPhoto => new PropertyKey("2C4D6803-80EA-4580-AF9A-5BE1A23EDDCB", 0);
            //
            //  WPD_RESOURCE_THUMBNAIL 
            // Represents the thumbnail data for an object. 
            public static PropertyKey Thumbnail => new PropertyKey("C7C407BA-98FA-46B5-9960-23FEC124CFDE", 0);
            //
            //  WPD_RESOURCE_ICON 
            // Represents the icon data for an object. 
            public static PropertyKey Icon => new PropertyKey("F195FED8-AA28-4EE3-B153-E182DD5EDC39", 0);
            //
            //  WPD_RESOURCE_AUDIO_CLIP 
            // Represents an audio sample data for an object. 
            public static PropertyKey AudioClip => new PropertyKey("3BC13982-85B1-48E0-95A6-8D3AD06BE117", 0);
            //
            //  WPD_RESOURCE_ALBUM_ART 
            // Represents the album artwork this media originated from. 
            public static PropertyKey AlbumArt => new PropertyKey("F02AA354-2300-4E2D-A1B9-3B6730F7FA21", 0);
            //
            //  WPD_RESOURCE_GENERIC 
            // Represents an arbitrary binary blob associated with this object. 
            public static PropertyKey Generic => new PropertyKey("B9B9F515-BA70-4647-94DC-FA4925E95A07", 0);
            //
            //  WPD_RESOURCE_VIDEO_CLIP 
            // Represents a video sample for an object. 
            public static PropertyKey VideoClip => new PropertyKey("B566EE42-6368-4290-8662-70182FB79F20", 0);
            //
            //  WPD_RESOURCE_BRANDING_ART 
            // Represents the product branding artwork or logo for an object. This resource is typically found on-but not limited to the device object. 
            public static PropertyKey BrandingArt => new PropertyKey("B633B1AE-6CAF-4A87-9589-22DED6DD5899", 0);

        }

        /// <summary>
        /// This class defines all Commands-Parameters and Options associated with: <see cref="Guids.PortableDevices.PropertieSystem.ResourceAttributesV1"/>.
        /// </summary>
        public static class ResourceAttribute

        {

            //
            // WPD_RESOURCE_ATTRIBUTE_TOTAL_SIZE  
            //   [ VT_UI8 ] Total size in bytes of the resource data.
            public static PropertyKey TotalSize => new PropertyKey(Guids.PortableDevices.PropertieSystem.ResourceAttributesV1, 2);
            //
            // WPD_RESOURCE_ATTRIBUTE_CAN_READ  
            //   [ VT_BOOL ] Indicates whether client applications have permission to open the resource for Read access.
            public static PropertyKey CanRead => new PropertyKey(Guids.PortableDevices.PropertieSystem.ResourceAttributesV1, 3);
            //
            // WPD_RESOURCE_ATTRIBUTE_CAN_WRITE  
            //   [ VT_BOOL ] Indicates whether client applications have permission to open the resource for Write access.
            public static PropertyKey CanWrite => new PropertyKey(Guids.PortableDevices.PropertieSystem.ResourceAttributesV1, 4);
            //
            // WPD_RESOURCE_ATTRIBUTE_CAN_DELETE  
            //   [ VT_BOOL ] Indicates whether client applications have permission to Delete a resource from the device.
            public static PropertyKey CanDelete => new PropertyKey(Guids.PortableDevices.PropertieSystem.ResourceAttributesV1, 5);
            //
            // WPD_RESOURCE_ATTRIBUTE_OPTIMAL_READ_BUFFER_SIZE  
            //   [ VT_UI4 ] The recommended buffer size a caller should use when doing buffered reads on the resource.
            public static PropertyKey OptimalReadBufferSize => new PropertyKey(Guids.PortableDevices.PropertieSystem.ResourceAttributesV1, 6);
            //
            // WPD_RESOURCE_ATTRIBUTE_OPTIMAL_WRITE_BUFFER_SIZE  
            //   [ VT_UI4 ] The recommended buffer size a caller should use when doing buffered writes on the resource.
            public static PropertyKey OptimalWriteBufferSize => new PropertyKey(Guids.PortableDevices.PropertieSystem.ResourceAttributesV1, 7);
            //
            // WPD_RESOURCE_ATTRIBUTE_FORMAT  
            //   [ VT_CLSID ] Indicates the format of the resource data.
            public static PropertyKey Format => new PropertyKey(Guids.PortableDevices.PropertieSystem.ResourceAttributesV1, 8);
            //
            // WPD_RESOURCE_ATTRIBUTE_RESOURCE_KEY  
            //   [ VT_UNKNOWN ] This is an IPortableDeviceKeyCollection containing a single value-which is the key identifying the resource.
            public static PropertyKey ResourceKey => new PropertyKey(Guids.PortableDevices.PropertieSystem.ResourceAttributesV1, 9);

        }

    }

}
