using Microsoft.WindowsAPICodePack.Win32Native.PortableDevices.EventSystem;

namespace Microsoft.WindowsAPICodePack.Win32Native.PortableDevices.PropertySystem
{
    /// <summary>
    /// This enum describes options that are supported by a device when deleting an object.
    /// </summary>
    /// <remarks>The application can retrieve the deletion options that the device supports by calling <see cref="IPortableDeviceCapabilities.GetCommandOptions"/> for the <see cref="Microsoft.WindowsAPICodePack.PortableDevices.CommandSystem.Object.Management.Commands.DeleteObjects"/> command. It should examine the <see cref="Microsoft.WindowsAPICodePack.PortableDevices.CommandSystem.Object.Management.Options.RecursiveDeleteSupported"/> option value that this method returns in an <see cref="IPortableDeviceValuesCollection"/> object.</remarks>
    public enum DeleteObjectOptionValues : uint
    {
        /// <summary>
        /// Delete the object only and fail if it has children.
        /// </summary>
        NoRecursion = 0,

        /// <summary>
        /// Delete the object and all its children.
        /// </summary>
        Recursion = 1
    }

    /// <summary>
    /// This enum describes the content type of a short message service (SMS) message.
    /// </summary>
    /// <seealso cref="Microsoft.WindowsAPICodePack.PortableDevices.CommandSystem.SMS.Commands.Send"/>
    public enum SMSMessageTypeValues : uint
    {
        /// <summary>
        /// A text message.
        /// </summary>
        SMSTextMessage = 0,

        /// <summary>
        /// A binary message.
        /// </summary>
        SMSBinaryMessage = 1
    }

    /// <summary>
    /// This enum describes an audio file's compression type.
    /// </summary>
    /// <seealso cref="Microsoft.WindowsAPICodePack.PortableDevices.PropertySystem.Properties.Legacy.Media.BitRateType"/>
    public enum BitrateTypeValues : uint
    {
        /// <summary>
        /// This value has not been specified.
        /// </summary>
        BitrateTypeUnused = 0,

        /// <summary>
        /// Constant bit rate compression.
        /// </summary>
        BitrateTypeDiscrete = 1,

        /// <summary>
        /// Variable bit rate compression.
        /// </summary>
        BitrateTypeVariable = 2,

        /// <summary>
        /// Free format bit rate. This is a constant bit rate that is lower than the maximum allowed bit rate.
        /// </summary>
        BitrateTypeFree = 3
    }

    /// <summary>
    /// This enum describes the capture timing mode of a still image capture.
    /// </summary>
    /// <seealso cref="Microsoft.WindowsAPICodePack.PortableDevices.PropertySystem.Properties.StillImageCapture.CaptureMode"/>
    public enum CaptureModeValues : uint
    {
        /// <summary>
        /// The capture mode has not been defined.
        /// </summary>
        CaptureModeUndefined = 0,

        /// <summary>
        /// No delay or burst mode should be used.
        /// </summary>
        CaptureModeNormal = 1,

        /// <summary>
        /// Specifies that a defined number of images should be captured with a defined interval between them. The number of images to capture and time delay between them are specified by the WPD_STILL_IMAGE_BURST_NUMBER and WPD_STILL_IMAGE_BURST_INTERVAL properties.
        /// </summary>
        CaptureModeBurst = 2,

        /// <summary>
        /// Image capture should use time lapse photography. The number of images and interval between them are described by the WPD_STILL_IMAGE_BURST_NUMBER and WPD_STILL_IMAGE_BURST_INTERVAL properties.
        /// </summary>
        CaptureModeTimelapse = 3
    }

    /// <summary>
    /// This enum describes the color correction status of an image or video file.
    /// </summary>
    /// <seealso cref="Microsoft.WindowsAPICodePack.PortableDevices.PropertySystem.Properties.Legacy.Object.Image.ColorCorrectedStatus"/>
    public enum ColorCorrectedStatusValues:uint
    {
        /// <summary>
        /// The image has not been color corrected.
        /// </summary>
        NotCorrected = 0,

        /// <summary>
        /// The image has been color corrected.
        /// </summary>
        Corrected = 1,

        /// <summary>
        /// The image has not been, and should not be, color corrected.
        /// </summary>
        ShouldNotBeCorrected = 2
    }

    /// <summary>
    /// This enum describes the cropping status of an image.
    /// </summary>
    /// <seealso cref="Microsoft.WindowsAPICodePack.PortableDevices.PropertySystem.Properties.Legacy.Object.Image.CroppedStatus"/>
    public enum CroppedStatusValues:uint
    {
        /// <summary>
        /// The image has not been cropped.
        /// </summary>
        NotCropped = 0,

        /// <summary>
        /// The image has been cropped.
        /// </summary>
        Cropped = 1,

        /// <summary>
        /// The image has not been, and should not be, cropped.
        /// </summary>
        ShouldNotBeCropped = 2
    }

    /// <summary>
    /// This enum specifies the inheritance relationship for a service.
    /// </summary>
    /// <seealso cref="Microsoft.WindowsAPICodePack.PortableDevices.PropertySystem.Properties.Device.Transport"/>
    public enum DeviceTransportValues:uint
    {
        /// <summary>
        /// The transport type was not specified.
        /// </summary>
        Unspecified = 0,

        /// <summary>
        /// The device is connected through USB.
        /// </summary>
        USB = 1,

        /// <summary>
        /// The device is connected through Internet Protocol (IP).
        /// </summary>
        IP = 2,

        /// <summary>
        /// The device is connected through Bluetooth.
        /// </summary>
        Bluetooth = 3
    }

    /// <summary>
    /// This enum describes various visual effects that can be applied to an image.
    /// </summary>
    /// <seealso cref="Microsoft.WindowsAPICodePack.PortableDevices.PropertySystem.Properties.StillImageCapture.EffectMode"/>
    public enum EffectModeValues:uint
    {
        /// <summary>
        /// No effect has been specified.
        /// </summary>
        Undefined = 0,

        /// <summary>
        /// The image should be color.
        /// </summary>
        Color = 1,

        /// <summary>
        /// The image should be black and white.
        /// </summary>
        BlackAndWhite = 2,

        /// <summary>
        /// The image should be sepia.
        /// </summary>
        Sepia = 3
    }

    /// <summary>
    /// This enum describes the metering mode to use when estimating exposure for still image capture by a device.
    /// </summary>
    /// <seealso cref="Microsoft.WindowsAPICodePack.PortableDevices.PropertySystem.Properties.StillImageCapture.ExposureMeteringMode"/>
    public enum ExposureMeteringModeValues:uint
    {
        /// <summary>
        /// The metering mode is undefined.
        /// </summary>
        Undefined = 0,

        /// <summary>
        /// Use averaged exposure across the full image.
        /// </summary>
        Average = 1,

        /// <summary>
        /// Use an averaged exposure, with the center of the image given more weight.
        /// </summary>
        CenterWeightedAverage = 2,

        /// <summary>
        /// Use a multi-spot averaging technique.
        /// </summary>
        MultiSpot = 3,

        /// <summary>
        /// Use a center-spot averaging technique.
        /// </summary>
        CenterSpot = 4
    }

    /// <summary>
    /// This enum describes an exposure mode to use when capturing images with a device.
    /// </summary>
    /// <seealso cref="Microsoft.WindowsAPICodePack.PortableDevices.PropertySystem.Properties.StillImageCapture.ExposureProgramMode"/>
    public enum ExposureProgramModeValues:uint
    {
        /// <summary>
        /// The exposure mode has not been specified.
        /// </summary>
        Undefined = 0,

        /// <summary>
        /// The application should specify all exposure settings.
        /// </summary>
        Manual = 1,

        /// <summary>
        /// Use a device-defined automatic exposure mode.
        /// </summary>
        Auto = 2,

        /// <summary>
        /// An automated exposure mode that indicates that the lens aperture value should remain fixed, but shutter speed should be determined by the device.
        /// </summary>
        AperturePriority = 3,

        /// <summary>
        /// An automated exposure mode that indicates that the shutter speed should remain fixed, but that lens aperture should be determined by the device.
        /// </summary>
        ShutterPriority = 4,

        /// <summary>
        /// An automated exposure mode that tries to maximize the depth of field.
        /// </summary>
        Creative = 5,

        /// <summary>
        /// An automated exposure mode that tries to maximize the shutter speed.
        /// </summary>
        Action = 6,

        /// <summary>
        /// An automated exposure mode that specifies a relatively shallow depth of field.
        /// </summary>
        Portrait = 7
    }

    /// <summary>
    /// This enum describes a flash mode to use when capturing images with a device.
    /// </summary>
    /// <seealso cref="Microsoft.WindowsAPICodePack.PortableDevices.PropertySystem.Properties.StillImageCapture.FlashMode"/>
    public enum FlashModeValues:uint
    {
        /// <summary>
        /// No flash mode has been specified.
        /// </summary>
        Undefined = 0,

        /// <summary>
        /// Specifies that the flash should be used in the automatic mode, as specified by the device.
        /// </summary>
        Auto = 1,

        /// <summary>
        /// Specifies that no flash should be used.
        /// </summary>
        Off = 2,

        /// <summary>
        /// Specifies a fill-type flash.
        /// </summary>
        Fill = 3,

        /// <summary>
        /// Specifies that the red eye reduction flash should be used.
        /// </summary>
        RedEyeAuto = 4,

        /// <summary>
        /// Specifies that the red eye fill flash should be used.
        /// </summary>
        RedEyeFill = 5,

        /// <summary>
        /// Specifies that the flash should be synchronized with other external flash devices.
        /// </summary>
        ExternalSync = 6
    }

    /// <summary>
    /// This enum describes how a device should decide what part of a frame to use to set focus.
    /// </summary>
    /// <seealso cref="Microsoft.WindowsAPICodePack.PortableDevices.PropertySystem.Properties.StillImageCapture.FocusMeteringMode"/>
    public enum FocusMeteringModeValues:uint
    {
        /// <summary>
        /// Indicates that no focusing mode has been specified.
        /// </summary>
        Undefined = 0,

        /// <summary>
        /// Focuses on the center of the framed area.
        /// </summary>
        CenterSpot = 1,

        /// <summary>
        /// Determine focus by analyzing multiple parts of the framed area.
        /// </summary>
        MultiSpot = 2
    }

    /// <summary>
    /// This enum describes the focus mode used by a still image capture device.
    /// </summary>
    /// <seealso cref="Microsoft.WindowsAPICodePack.PortableDevices.PropertySystem.Properties.StillImageCapture.FocusMode"/>
    public enum FocusModeValues:uint
    {
        /// <summary>
        /// The focus mode has not been specified.
        /// </summary>
        Undefined = 0,

        /// <summary>
        /// Specifies manual focus.
        /// </summary>
        Manual = 1,

        /// <summary>
        /// Specifies automatic focus, controlled by the device.
        /// </summary>
        Automatic = 2,

        /// <summary>
        /// Specifies that the device should automatically switch between macro and normal focus, as required.
        /// </summary>
        AutomaticMacro = 3
    }

    /// <summary>
    /// This enum describes a broad genre type of a media file.
    /// </summary>
    /// <seealso cref="Microsoft.WindowsAPICodePack.PortableDevices.PropertySystem.Properties.Legacy.Media.MetaGenre"/>
    public enum MetaGenreValues:uint
    {
        /// <summary>
        /// The genre has not been set, or is not applicable.
        /// </summary>
        Unused = 0x0,

        /// <summary>
        /// This is a generic music file (audio only).
        /// </summary>
        GenericMusicAudioFile = 0x1,

        /// <summary>
        /// This is a generic non-music audio file, for example, a speech or audio book.
        /// </summary>
        GenericNonMusicAudioFile = 0x11,

        /// <summary>
        /// This is an audio book file.
        /// </summary>
        SpokenWordAudioBookFiles = 0x12,

        /// <summary>
        /// This is a spoken-word audio file that is not an audio book, for example, an interview or speech.
        /// </summary>
        SpokenWordFilesNonAudioBook = 0x13,

        /// <summary>
        /// This is a news audio or video file.
        /// </summary>
        SpokenWordNews = 0x14,

        /// <summary>
        /// This is an audio recording of a talk show.
        /// </summary>
        SpokenWordTalkShows = 0x15,

        /// <summary>
        /// This is a generic video file.
        /// </summary>
        GenericVideoFile = 0x21,

        /// <summary>
        /// This is a news video file.
        /// </summary>
        NewsVideoFile = 0x22,

        /// <summary>
        /// This is a music video file.
        /// </summary>
        MusicVideoFile = 0x23,

        /// <summary>
        /// This is a home video file.
        /// </summary>
        HomeVideoFile = 0x24,

        /// <summary>
        /// This is a feature film video file.
        /// </summary>
        FeatureFilmVideoFile = 0x25,

        /// <summary>
        /// This is a television program video file.
        /// </summary>
        TelevisionVideoFile = 0x26,

        /// <summary>
        /// This is a television program video file.
        /// </summary>
        TrainingEducationalVideoFile = 0x27,

        /// <summary>
        /// This is a video file featuring a photo montage.
        /// </summary>
        PhotoMontageVideoFile = 0x28,

        /// <summary>
        /// This is a file without audio or video.
        /// </summary>
        GenericNonAudioNonVideo = 0x30,

        /// <summary>
        /// This is an audio podcast.
        /// </summary>
        AudioPodcast = 0x40,

        /// <summary>
        /// This is a video podcast.
        /// </summary>
        VideoPodcast = 0x41,

        /// <summary>
        /// This is a podcast containing both audio and video.
        /// </summary>
        MixedPodcast = 0x42
    }

    /// <summary>
    /// This enum describes how a method parameter is used in a given method.
    /// </summary>
    public enum ParameterUsageTypeValues
    {
        /// <summary>
        /// The parameter receives the return value, if specified by the method.
        /// </summary>
        Return = 0,

        /// <summary>
        /// The parameter contains an input value before the method is called.
        /// </summary>
        In = 1,

        /// <summary>
        /// The parameter contains an output value when the method returns.
        /// </summary>
        Out = 2,

        /// <summary>
        /// The parameter contains an input value before the method is called and an output value when it returns.
        /// </summary>
        InOut = 3
    }

    /// <summary>
    /// This enum describes the power source that a device is using.
    /// </summary>
    /// <seealso cref="Microsoft.WindowsAPICodePack.PortableDevices.PropertySystem.Properties.Device.PowerSource"/>
    public enum PowerSourceValues:uint
    {
        /// <summary>
        /// The device power source is a battery.
        /// </summary>
        Battery = 0,

        /// <summary>
        /// The device uses an external power source.
        /// </summary>
        External = 1
    }

    /// <summary>
    /// This enum indicates whether the rendering information profile entry corresponds to an Object or a Resource.
    /// </summary>
    /// <seealso cref="Microsoft.WindowsAPICodePack.PortableDevices.PropertySystem.Properties.AudioRendering.ProfileEntryType"/>
    public enum RenderingInformationProfileEntryTypeValues:uint
    {
        /// <summary>
        /// The entry corresponds to an object.
        /// </summary>
        Object = 0,

        /// <summary>
        /// The entry corresponds to a resource.
        /// </summary>
        Resource = 1
    }

    /// <summary>
    /// This enum indicates the units for a referenced section of data.
    /// </summary>
    /// <seealso cref="Microsoft.WindowsAPICodePack.PortableDevices.PropertySystem.Properties.Legacy.Object.Section.DataUnits"/>
    public enum SectionDataUnitValues:uint
    {
        /// <summary>
        /// The given units are specified in bytes.
        /// </summary>
        Bytes = 0,

        /// <summary>
        /// The given units are specified in milliseconds.
        /// </summary>
        Milliseconds = 1
    }

    /// <summary>
    /// This enum describes the encoding type of a short message service (SMS) message.
    /// </summary>
    /// <seealso cref="Microsoft.WindowsAPICodePack.PortableDevices.PropertySystem.Properties.Legacy.Object.SMS.Encoding"/>
    public enum SMSEncodingTypeValues:uint
    {
        /// <summary>
        /// Seven-bit encoding.
        /// </summary>
        Encoding7Bit = 0,

        /// <summary>
        /// Eight-bit encoding.
        /// </summary>
        Encoding8Bit = 1,

        /// <summary>
        /// Sixteen-bit encoding (UTF).
        /// </summary>
        UTF16 = 2
    }

    /// <summary>
    /// This enum describes how the fields in a video file are encoded.
    /// </summary>
    /// <remarks>There are two types of interleaved file formats that are specified by this enumeration. WPD_VIDEO_SCAN_TYPE_FIELD_INTERLEAVED refers to a file format where frames are delivered as they were scanned fields alternate and data goes line by line.</remarks>
    /// <seealso cref="Microsoft.WindowsAPICodePack.PortableDevices.PropertySystem.Properties.Legacy.Object.Video.ScanType"/>
    public enum VideoScanTypeValues:uint
    {
        /// <summary>
        /// The scan type has not been defined for this video file, or is not applicable.
        /// </summary>
        Unused = 0,

        /// <summary>
        /// A progressive scan video file.
        /// </summary>
        Progressive = 1,

        /// <summary>
        /// An interleaved video file where the fields alternate and the upper field (with line 1) is drawn first. For more information, see the Remarks section.
        /// </summary>
        FieldInterleavedUpperFirst = 2,

        /// <summary>
        /// An interleaved video file where the fields alternate and the lower field (with line 2) is drawn first. For more information, see Remarks, following this section.
        /// </summary>
        FieldInterleavedLowerFirst = 3,

        /// <summary>
        /// An interleaved video file where the fields are sent as contiguous samples and the upper field (with line 1) is drawn first. For more information, see Remarks, following this section.
        /// </summary>
        FieldSingleUpperFirst = 4,

        /// <summary>
        /// An interleaved video file where the fields are sent as contiguous samples and the lower field (with line 2) is sent first.
        /// </summary>
        FieldSingleLowerFirst = 5,

        /// <summary>
        /// A video file with a mix of interlacing modes.
        /// </summary>
        MixedInterlace = 6,

        /// <summary>
        /// A video file with a mix of interlaced and progressive modes.
        /// </summary>
        MixedInterlaceAndProgressive = 7
    }

    /// <summary>
    /// This enum describes how a video or image device weights color channels to achieve a proper white balance.
    /// </summary>
    /// <seealso cref="Microsoft.WindowsAPICodePack.PortableDevices.PropertySystem.Properties.StillImageCapture.WhiteBalance"/>
    public enum WhiteBalanceSettingValues:uint
    {
        /// <summary>
        /// This value has not been defined.
        /// </summary>
        Undefined = 0,

        /// <summary>
        /// The white balance is set explicitly by using the WPD_STILL_IMAGE_RGB_GAIN property and will not change by itself.
        /// </summary>
        Manual = 1,

        /// <summary>
        /// The device will set the white balance.
        /// </summary>
        Automatic = 2,

        /// <summary>
        /// The device will set the white balance, but only when the user pushes the device's capture button while aiming the device at a white field.
        /// </summary>
        OnePushAutomatic = 3,

        /// <summary>
        /// The device will use white balance numbers appropriate for use in most daylight settings.
        /// </summary>
        DayLight = 4,

        /// <summary>
        /// The device will use white balance numbers appropriate for use in most indoor, incandescent lighting settings.
        /// </summary>
        Tungsten = 5,

        /// <summary>
        /// The device will use white balance numbers appropriate for use with a flash.
        /// </summary>
        Flash = 6
    }

    /// <summary>
    /// This enum describes how a property stores its values.
    /// </summary>
    /// <seealso cref="Microsoft.WindowsAPICodePack.PortableDevices.PropertySystem.Attribute.Property.Form"/>
    public enum PropertyAttributeFormValues:uint
    {
        /// <summary>
        /// The form of the property's data is not specified.
        /// </summary>
        Unspecified = 0,

        /// <summary>
        /// The value is expressed as a range of values, with a minimum and a maximum.
        /// </summary>
        Range = 1,

        /// <summary>
        /// The property has a series of individual values.
        /// </summary>
        Enumeration = 2,

        /// <summary>
        /// The property value is a regular expression, not a literal expression.
        /// </summary>
        RegularExpression = 3,

        /// <summary>
        /// The property value represents an object identifier.
        /// </summary>
        OjbectIdentifier = 4
    }

    /// <summary>
    /// This enum describes how a (method or event) parameter stores its value.
    /// </summary>
    /// <seealso cref="Microsoft.WindowsAPICodePack.PortableDevices.PropertySystem.Attribute.Parameter.Form"/>
    public enum ParameterAttributeFormValues:uint
    {
        /// <summary>
        /// The form of the parameter is not specified.
        /// </summary>
        Unspecified = 0,

        /// <summary>
        /// The parameter specifies a range.
        /// </summary>
        Range = 1,

        /// <summary>
        /// The parameter is an enumeration.
        /// </summary>
        Enumeration = 2,

        /// <summary>
        /// The parameter is a regular expression.
        /// </summary>
        RegularExpression = 3,

        /// <summary>
        /// The parameter is an object identifier.
        /// </summary>
        ObjectIdentifier = 4
    }

    /// <summary>
    /// This enum describes the different Windows Portable Device storage types.
    /// </summary>
    /// <seealso cref="Microsoft.WindowsAPICodePack.PortableDevices.PropertySystem.Properties.Storage.Type"/>
    public enum StorageTypeValues : uint
    {
        /// <summary>
        /// The storage is of an undefined type.
        /// </summary>
        Undefined = 0,

        /// <summary>
        /// The storage is non-removable and read-only.
        /// </summary>
        FixedRom = 1,

        /// <summary>
        /// The storage is removable and is read-only.
        /// </summary>
        RemovableRom = 2,

        /// <summary>
        /// The storage is non-removable and is read/write capable.
        /// </summary>
        FixedRam = 3,

        /// <summary>
        /// The storage is removable and is read/write capable.
        /// </summary>
        RemovableRam = 4
    }

    /// <summary>
    /// This enum describes the different Windows Portable Device (WPD) types commonly used to determine the basic classification and visual appearance of a portable device.
    /// </summary>
    /// <remarks><para><see cref="DeviceTypeValues"/> are read using the <see cref="IPortableDeviceManager"/> interface. WPD applications may use these values to determine the generic visual appearance of the device. That is, a camera picture is displayed for camera-like devices, a mobile phone picture is displayed for phone-like devices, and so on.</para>
    /// <para>Note: WPD applications must use the capabilities of the portable device to determine functionally, not the <see cref="DeviceTypeValues"/> value.</para>
    /// </remarks>
    /// <seealso cref="Microsoft.WindowsAPICodePack.PortableDevices.PropertySystem.Properties.Device.Type"/>
    public enum DeviceTypeValues:uint
    {
        /// <summary>
        /// A generic WPD that includes multifunction devices that do not fall into one of the other <see cref="DeviceTypeValues"/> enumeration values.
        /// </summary>
        Generic = 0,

        /// <summary>
        /// A camera device, such as a digital still camera.
        /// </summary>
        Camera = 1,

        /// <summary>
        /// A media player device that supports playing audio, video, or viewing pictures, such as a portable music player or portable media center. Not all of this functionally is classified as a WPD_DEVICE_TYPE_MEDIA_PLAYER. For example, portable music player devices are classified as WPD_DEVICE_TYPE_MEDIA_PLAYER.
        /// </summary>
        MediaPlayer = 2,

        /// <summary>
        /// A phone device, such as a mobile phone.
        /// </summary>
        Phone = 3,

        /// <summary>
        /// A video device.
        /// </summary>
        Video = 4,

        /// <summary>
        /// A personal information manager device.
        /// </summary>
        PersonalInformationManager = 5,

        /// <summary>
        /// An audio recorder device.
        /// </summary>
        AudioRecorder = 6
    }

    /// <summary>
    /// This enum values describe the current state of an operation in progress.
    /// </summary>
    /// <remarks>These values are received in the application-defined callback (<see cref="IPortableDeviceEventCallback"/>).</remarks>
    /// <seealso cref="Microsoft.WindowsAPICodePack.PortableDevices.EventSystem.Parameter.OperationState"/>
    public enum OperationStateValues:uint
    {
        /// <summary>
        /// The current operation is in an unspecified state (not set) and unknown.
        /// </summary>
        Unspecified = 0,

        /// <summary>
        /// The operation is started.
        /// </summary>
        Started = 1,

        /// <summary>
        /// The operation is running.
        /// </summary>
        Running = 2,

        /// <summary>
        /// The operation is paused.
        /// </summary>
        Paused = 3,

        /// <summary>
        /// The operation is canceled.
        /// </summary>
        Cancelled = 4,

        /// <summary>
        /// The operation is finished.
        /// </summary>
        Finished = 5,

        /// <summary>
        /// The operation is aborted.
        /// </summary>
        Aborted = 6
    }

    /// <summary>
    /// This enum specifies the inheritance relationship for a service.
    /// </summary>
    /// <seealso cref="IPortableDeviceServiceCapabilities.GetInheritedServices"/>
    public enum ServiceInheritanceTypeValues
    {
        /// <summary>
        /// The service inherits by implementing an abstract service definition.
        /// </summary>
        Implementation = 0
    }

    /// <summary>
    /// The WPD_STREAM_UNITS enumeration specifies the unit types to be used for <see cref="IPortableDeviceUnitsStream"/> operations.
    /// </summary>
    /// <seealso cref="IPortableDeviceUnitsStream"/>
    /// <seealso cref="IPortableDeviceUnitsStream.SeekInUnits"/>
    public enum StreamUnitValues:uint
    {
        /// <summary>
        /// The stream units are specified in bytes.
        /// </summary>
        Bytes = 0,

        /// <summary>
        /// The stream units are specified in frames.
        /// </summary>
        Frames = 1,

        /// <summary>
        /// The stream units are specified in rows.
        /// </summary>
        Rows = 2,

        /// <summary>
        /// The stream units are specified in milliseconds.
        /// </summary>
        Milliseconds = 3,

        /// <summary>
        /// The stream units are specified in microseconds.
        /// </summary>
        Microseconds = 4
    }
}
