using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.WindowsAPICodePack.Win32Native.MediaDevices
{

    /// <summary>
    /// The <see cref="PropValidValuesForm"/> enumeration type describes possible forms of valid values for a property.
    /// </summary>
    /// <remarks>
    /// This enumeration is used in the <see cref="PropDesc"/> structure to specify the form of valid values for a property.
    /// </remarks>
    /// <seealso cref="IWMDMDevice3.GetFormatCapability"/>
    /// <seealso cref="FormatCapability"/>
    /// <seealso cref="PropDesc"/>
    /// <seealso cref="PropValuesEnum"/>
    /// <seealso cref="PropValuesRange"/>
    public enum PropValidValuesForm
    {
        /// <summary>
        /// All values are valid.
        /// </summary>
        Any,
        /// <summary>
        /// Valid values are expressed as a range. For detailed information, see the <see cref="PropValuesRange"/> structure.
        /// </summary>
        Range,
        /// <summary>
        /// Valid values are an enumerated set. For detailed information, see the <see cref="PropValuesEnum"/> structure.
        /// </summary>
        Enum
    }

    /// <summary>
    /// The <see cref="FindScope"/> enumeration type defines the scope of the storage object.
    /// </summary>
    public enum FindScope
    {
        /// <summary>
        /// Looking for the matching object anywhere on the device.
        /// </summary>
        Global,
        /// <summary>
        /// Looking for the matching object within this storage and its children.
        /// </summary>
        ImmediateChildren
    }

    /// <summary>
    /// The <see cref="FormatCode"/> enumeration type defines a list of format codes that describe types of content transferred to and from a device.
    /// </summary>
    /// <remarks><para>To discover the formats supported by a device, an application can use <see cref="IWMDMDevice3.GetProperty"/> to query the <b>g_wszWMDMFormatsSupported</b> device property.</para>
    /// <para>To discover device capabilities for a particular format, an application can call <see cref="IWMDMDevice3.GetFormatCapability"/>.</para>
    /// <para>An application can set the format code while creating a storage on device by including the g_wszWMDMFormatCode property in metadata passed in the pMetaData parameter of a call to <see cref="IWMDMStorageControl3.Insert3"/>.</para>
    /// <para>An application can query the format code of a storage by calling <see cref="IWMDMStorage3.GetMetadata"/> or <see cref="IWMDMStorage4.GetSpecifiedMetadata"/> and retrieving the <b>g_wszWMDMFormatCode</b> property.</para>
    /// <para>If the device supports setting the format code after the creation of storage, an application can use <see cref="IWMDMStorage3.SetMetadata"/> to set the <b>g_wszWMDMFormatCode</b> property. Some devices may not allow changing the format code after the storage is created on the device. Therefore, setting this property along with the metadata passed in <see cref="IWMDMStorageControl3.Insert3"/> is strongly recommended.</para></remarks>
    public enum FormatCode
    {
        /// <summary>
        /// No format code is used.
        /// </summary>
        NotUsed,
        /// <summary>
        /// Format code used to query for all undefined objects.
        /// </summary>
        AllImages,
        /// <summary>
        /// Format code used to define a link between two objects.
        /// </summary>
        Undefined,
        /// <summary>
        /// Format code used to define a link between two objects.
        /// </summary>
        Association,
        /// <summary>
        /// Format code for a script file.
        /// </summary>
        Script,
        /// <summary>
        /// Format code for an executable file.
        /// </summary>
        Executable,
        /// <summary>
        /// Format code for a text file.
        /// </summary>
        Text,
        /// <summary>
        /// Format code for an HTML file.
        /// </summary>
        HTML,
        /// <summary>
        /// Format code used to represent the digital print order format.
        /// </summary>
        DPOF,
        /// <summary>
        /// Format code used to represent the audio interchange file format.
        /// </summary>
        AIFF,
        /// <summary>
        /// Format code used for a WAV file.
        /// </summary>
        Wave,
        /// <summary>
        /// Format code used for an MP3 file.
        /// </summary>
        MP3,
        /// <summary>
        /// Format code used for an AVI file.
        /// </summary>
        AVI,
        /// <summary>
        /// Format code used for an MPEG file.
        /// </summary>
        MPEG,
        /// <summary>
        /// Format code used to represent an Advanced Systems Format (ASF) file.
        /// </summary>
        ASF,
        /// <summary>
        /// Format code that is the first in a range reserved for Picture Transfer Protocol (PTP).
        /// </summary>
        ReservedFirst,
        /// <summary>
        /// Format code that is last in a range reserved for PTP.
        /// </summary>
        ReservedLast,
        /// <summary>
        /// Format code used to represent and image of an undefined type.
        /// </summary>
        ImageUndefined,
        /// <summary>
        /// Format code for an EXIF file. Also used for JPEG images not covered by <see cref="ImageJP2"/> or <see cref="ImageJPX"/>.
        /// </summary>
        ImageEXIF,
        /// <summary>
        /// Format code used for images that are of type Tagged Image File Format for Electronic Photography (TIFF/EP)
        /// </summary>
        ImageTIFFEP,
        /// <summary>
        /// Format code for a file of type FPX.
        /// </summary>
        ImageFLASHPIX,
        /// <summary>
        /// Format code for a file of type BMP.
        /// </summary>
        ImageBMP,
        /// <summary>
        /// Format code for an image in the camera image file format.
        /// </summary>
        ImageCIFF,
        /// <summary>
        /// Format code for a GIF file.
        /// </summary>
        ImageGIF,
        /// <summary>
        /// Format code for a file of type JFIF.
        /// </summary>
        ImageJFIF,
        /// <summary>
        /// Format code for an image of type photo cd.
        /// </summary>
        ImagePCD,
        /// <summary>
        /// Format code for an image of type PICT.
        /// </summary>
        ImagePICT,
        /// <summary>
        /// Format code for an image of type PNG.
        /// </summary>
        ImagePNG,
        /// <summary>
        /// Format code for a file of type TIFF.
        /// </summary>
        ImageTIFF,
        /// <summary>
        /// Format code for an image of type Tagged Image File Format with image technology.
        /// </summary>
        ImageTIFFIT,
        /// <summary>
        /// Format code for a jpeg200 image.
        /// </summary>
        ImageJP2,
        /// <summary>
        /// Format code for an image built on JPEG200, using extended still image registration.The file name extension is usually.jpf or.jpx.
        /// </summary>
        ImageJPX,
        /// <summary>
        /// Format code that is the first in a range reserved for an image reference in PTP.
        /// </summary>
        ImageReservedFirst,
        /// <summary>
        /// Format code that is the last in a range reserved for an image reference in PTP.
        /// </summary>
        ImageReservedLast,
        /// <summary>
        /// Format code when firmware is undefined.
        /// </summary>
        UndefinedFirmware,
        /// <summary>
        /// Format code for a Wireless Application Protocol Bitmap (.wbmp) image.
        /// </summary>
        WBMP
    ,
        /// <summary>
        /// Format code for an HD Photo image
        /// </summary>
        JPEGXR
    ,
        /// <summary>
        /// Format code for Windows image format.
        /// </summary>
        WindowsImageFormat,
        /// <summary>
        /// Format code for an audio file of undefined type.
        /// </summary>
        UndefinedAudio,
        /// <summary>
        /// Format code for a Windows Media Audio (WMA) file.
        /// </summary>
        WMA,
        /// <summary>
        /// Format code for a Vorbis-encoded audio file in an Ogg container.
        /// </summary>
        OGG,
        /// <summary>
        /// Format code for an Advanced Audio Coding (AAC) file.
        /// </summary>
        AAC,
        /// <summary>
        /// Format code for an Audible file.
        /// </summary>
        Audible,
        /// <summary>
        /// Format code for a Free Lossless Audio Codec (FLAC) file.
        /// </summary>
        FLAC,
        /// <summary>
        /// Format code for a Qualcomm Code Excited Linear Prediction (QCELP) codec file.
        /// </summary>
        QCELP
    ,
        /// <summary>
        /// Format code for an Adaptive Multi-Rate audio (AMR) codec file.
        /// </summary>
        AMR
    ,
        /// <summary>
        /// Format code for a video file with an undefined type.
        /// </summary>
        UndefinedVideo,
        /// <summary>
        /// Format code for a Windows Media Video (WMV) file.
        /// </summary>
        WMV,
        /// <summary>
        /// Format code for an MP4 file.
        /// </summary>
        MP4,
        /// <summary>
        /// Format code for an MP2 file.
        /// </summary>
        MP2,
        /// <summary>
        /// Format code for a 3G2 (3GPP2) multimedia container format. A file of this type may contain audio, video, or text.
        /// </summary>
        ThreeG2
    ,
        /// <summary>
        /// Format code for an AVCHD (Advanced Video Coding High Definition) video file.
        /// </summary>
        AVCHD
    ,
        /// <summary>
        /// Format code for the Advanced Television Systems Committee (ATSCTS) format standard.
        /// </summary>
        ATSCTS
    ,
        /// <summary>
        /// Format code for an MPEG-2 video and MPEG-1 Layer II, or AC-3, audio within a DVB-compliant MPEG-2 Transport Stream.
        /// </summary>
        DVBTS
    ,
        /// <summary>
        /// Format code for a collection of an undefined type.
        /// </summary>
        UndefinedCollection,
        /// <summary>
        /// Format code for a multimedia album where the object contains the properties of a multimedia album and, optionally, data. Any contained data is of an undefined format with respect to the MTP specification.
        /// </summary>
        AbstractMultimediaAlbum,
        /// <summary>
        /// Format code for an image album where the object contains the properties of an image album and, optionally, data. Any contained data is of an undefined format with respect to the MTP specification.
        /// </summary>
        AbstractImageAlbum,
        /// <summary>
        /// Format code for an audio album where the object contains the properties of an audio album and, optionally, data. Any contained data is of an undefined format with respect to the MTP specification.
        /// </summary>
        AbstractAudioAlbum,
        /// <summary>
        /// Format code for a video album where the object contains the properties of a video album and, optionally, data. Any contained data is of an undefined format with respect to the MTP specification.
        /// </summary>
        AbstractVideoAlbum,
        /// <summary>
        /// Format code for an audio/video playlist where the object contains the properties of an audio/video playlist and, optionally, data. Any contained data is of an undefined format with respect to the MTP specification.
        /// </summary>
        AbstractAudioVideoPlaylist,
        /// <summary>
        /// Format code for a contact group where the object contains the properties of a contact group and, optionally, data. Any contained data is of an undefined format with respect to the MTP specification.
        /// </summary>
        AbstractContactGroup,
        /// <summary>
        /// Format code for a message folder where the object contains the properties of a message folder and, optionally, data. Any contained data is of an undefined format with respect to the MTP specification.
        /// </summary>
        AbstractMessageFolder,
        /// <summary>
        /// Format code for a chaptered production where the object contains the properties of a chaptered production and, optionally, data. Any contained data is of an undefined format with respect to the MTP specification.
        /// </summary>
        AbstractChapteredProduction,
        /// <summary>
        /// Format code for a playlist formatted with Windows Media playlist formatting.
        /// </summary>
        WPLPlaylist,
        /// <summary>
        /// Format code for a playlist with M3U formatting.
        /// </summary>
        M3UPlaylist,
        /// <summary>
        /// Format code for a playlist with MPL formatting.
        /// </summary>
        MPLPlaylist,
        /// <summary>
        /// Format code for a playlist with ASX formatting.
        /// </summary>
        ASXPlaylist,
        /// <summary>
        /// Format code for a playlist with PLS formatting.
        /// </summary>
        PLSPlaylist,
        /// <summary>
        /// Format code for a document of undefined type.
        /// </summary>
        UndefinedDocument,
        /// <summary>
        /// Format code for a document where the object contains the properties of a document and, optionally, data. Any contained data is of an undefined format with respect to the MTP specification.
        /// </summary>
        AbstractDocument,
        /// <summary>
        /// Format code for an XML document.
        /// </summary>
        XmlDocument,
        /// <summary>
        /// Format code for a Microsoft Word document.
        /// </summary>
        MicrosoftWordDocument,
        /// <summary>
        /// Format code for a compiled HTML document.
        /// </summary>
        MHTCompiledHTMLDocument,
        /// <summary>
        /// Format code for a Microsoft Excel spreadsheet.
        /// </summary>
        MicrosoftExcelSpreadsheet,
        /// <summary>
        /// Format code for a Microsoft PowerPoint document.
        /// </summary>
        MicrosoftPowerPointDocument,
        /// <summary>
        /// Format code for a message of undefined type.
        /// </summary>
        UndefinedMessage,
        /// <summary>
        /// Format code for a message where the object contains the properties of a message and, optionally, data. Any contained data is of an undefined format with respect to the MTP specification.
        /// </summary>
        AbstractMessage,
        /// <summary>
        /// Format code for a contact of undefined type.
        /// </summary>
        UndefinedContact,
        /// <summary>
        /// Format code for a contact where the object contains the properties of a contact and, optionally, data. Any contained data is of an undefined format with respect to the MTP specification.
        /// </summary>
        AbstractContact,
        /// <summary>
        /// Format code for an electronic card with vcard version 2 formatting.
        /// </summary>
        VCard2,
        /// <summary>
        /// Format code for an electronic card with vcard version 3 formatting.
        /// </summary>
        VCard3,
        /// <summary>
        /// Format code for an electronic calendar item of undefined type.
        /// </summary>
        UndefinedCalendarItem,
        /// <summary>
        /// Format code for a calendar item where the object contains the properties of a calendar item and, optionally, data. Any contained data is of an undefined format with respect to the MTP specification.
        /// </summary>
        AbstractCalendarItem,
        /// <summary>
        /// Format code for an electronic calendar item with vcalendar version 1 formatting.
        /// </summary>
        VCalendar1,
        /// <summary>
        /// Format code for an electronic calendar item with vcalendar version 2 formatting.
        /// </summary>
        VCalendar2,
        /// <summary>
        /// Format code for a Windows-based executable of undefined type.
        /// </summary>
        UndefinedWindowsExecutable,
        /// <summary>
        /// Format code for a media cast object.
        /// </summary>
        MediaCast,
        /// <summary>
        /// Format code for a section of data that is contained in another object.
        /// </summary>
        Section,
        /// <summary>
        /// Format code for a 3G2A (3GPP2A) multimedia container format.
        /// </summary>
        ThreeG2A

    }

    /// <summary>
    /// The <see cref="SessionType"/> enumeration type defines the session type.
    /// </summary>
    public enum SessionType
    {
        /// <summary>
        /// The session is not defined.
        /// </summary>
        None,
        /// <summary>
        /// The session is defined as transferring data to the device.
        /// </summary>
        TransferToDevice,
        /// <summary>
        /// The session is defined as transferring data from the device.
        /// </summary>
        TransferFromDevice,
        /// <summary>
        /// The session is defined as deleting data.
        /// </summary>
        SessionDelete,
        /// <summary>
        /// The session is defined as a custom session.
        /// </summary>
        SessionCustom
    }

    /// <summary>
    /// The <see cref="StorageEnumMode"/> enumeration type defines how the content on the storage is to be enumerated. This enumeration is used by <see cref="IWMDMStorage3.SetEnumPreference"/>.
    /// </summary>
    public enum StorageEnumMode
    {
        /// <summary>
        /// Enumerates content on the storage just as it is organized in the file system of the storage.
        /// </summary>
        Raw,
        /// <summary>
        /// Enumerates content on the storage based on the device preference as indicated by the UseMetadataViews device parameter.
        /// </summary>
        UseDevicePref,
        /// <summary>
        /// Enumerates content on the storage by organizing the content based on a metadata view.
        /// </summary>
        MetadataViews
    }

    /// <summary>
    /// The <see cref="DataType"/> enumeration type defines a data type.
    /// </summary>
    public enum DataType
    {
        /// <summary>
        /// Specifies a 4-byte DWORD value.
        /// </summary>
        DWORD,
        /// <summary>
        /// Specifies a null-terminated Unicode string (2 bytes per character).
        /// </summary>
        STRING,
        /// <summary>
        /// Specifies an array of bytes.
        /// </summary>
        BINARY,
        /// <summary>
        /// Specifies a 4-byte Boolean value.
        /// </summary>
        BOOL,
        /// <summary>
        /// Specifies an 8-byte QWORD value.
        /// </summary>
        QWORD,
        /// <summary>
        /// Specifies a 2-byte WORD value.
        /// </summary>
        WORD,
        /// <summary>
        /// Specifies a 128-bit (16-byte) GUID.
        /// </summary>
        GUID,
        /// <summary>
        /// Specifies a date.
        /// </summary>
        DATE
    }
    /// <summary>
    /// The <see cref="Message"/> enumeration type defines message types and states.
    /// </summary>
    public enum Message
    {
        /// <summary>
        /// A Windows Media Device Manager device has been plugged in.
        /// </summary>
        DeviceArrival,
        /// <summary>
        /// A Windows Media Device Manager device has been removed.
        /// </summary>
        DeviceRemoval,
        /// <summary>
        /// Media has been inserted in a Windows Media Device Manager device.
        /// </summary>
        MediaArrival,
        /// <summary>
        /// Media has been removed from a Windows Media Device Manager device.
        /// </summary>
        MediaRemoval

    }

}
