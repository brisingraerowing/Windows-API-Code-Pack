using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAPICodePack.Win32Native.PortableDevices.ClientInterfaces;
using Microsoft.WindowsAPICodePack.Win32Native.PortableDevices.CollectionInterfaces;

namespace Microsoft.WindowsAPICodePack.Win32Native.PortableDevices
{

    /// <summary>
    /// The <see cref="PropValidValuesForm"/> enumeration type describes possible forms of valid values for a property.
    /// </summary>
    /// <remarks>
    /// This enumeration is used in the <see cref="WMDM_PROP_DESC"/> structure to specify the form of valid values for a property.
    /// </remarks>
    /// <seealso cref="IWMDMDevice3::GetFormatCapability"/>
    /// <seealso cref="WMDM_FORMAT_CAPABILITY"/>
    /// <seealso cref="WMDM_PROP_CONFIG"/>
    /// <seealso cref="WMDM_PROP_DESC"/>
    /// <seealso cref="WMDM_PROP_VALUES_ENUM"/>
    /// <seealso cref="WMDM_PROP_VALUES_RANGE"/>
    public enum PropValidValuesForm
    {
        /// <summary>
        /// All values are valid.
        /// </summary>
        Any,
        /// <summary>
        /// Valid values are expressed as a range. For detailed information, see the <see cref="WMDM_PROP_VALUES_RANGE"/> structure.
        /// </summary>
        Range,
        /// <summary>
        /// Valid values are an enumerated set. For detailed information, see the <see cref="WMDM_PROP_VALUES_ENUM"/> structure.
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
        Html,
        /// <summary>
        /// Format code used to represent the digital print order format.
        /// </summary>
        Dpof,
        /// <summary>
        /// Format code used to represent the audio interchange file format.
        /// </summary>
        Aiff,
        /// <summary>
        /// Format code used for a WAV file.
        /// </summary>
        Wave,
        /// <summary>
        /// 
        /// </summary>
        MP3,
        /// <summary>
        /// 
        /// </summary>
        AVI,
        /// <summary>
        /// 
        /// </summary>
        MPEG,
        /// <summary>
        /// 
        /// </summary>
        ASF,
        /// <summary>
        /// 
        /// </summary>
        RESERVED_FIRST,
        /// <summary>
        /// 
        /// </summary>
        RESERVED_LAST,
        /// <summary>
        /// 
        /// </summary>
        IMAGE_UNDEFINED,
        /// <summary>
        /// 
        /// </summary>
        IMAGE_EXIF,
        /// <summary>
        /// 
        /// </summary>
        IMAGE_TIFFEP,
        /// <summary>
        /// 
        /// </summary>
        IMAGE_FLASHPIX,
        /// <summary>
        /// 
        /// </summary>
        IMAGE_BMP,
        /// <summary>
        /// 
        /// </summary>
        IMAGE_CIFF,
        /// <summary>
        /// 
        /// </summary>
        IMAGE_GIF,
        /// <summary>
        /// 
        /// </summary>
        IMAGE_JFIF,
        /// <summary>
        /// 
        /// </summary>
        IMAGE_PCD,
        /// <summary>
        /// 
        /// </summary>
        IMAGE_PICT,
        /// <summary>
        /// 
        /// </summary>
        IMAGE_PNG,
        /// <summary>
        /// 
        /// </summary>
        IMAGE_TIFF,
        /// <summary>
        /// 
        /// </summary>
        IMAGE_TIFFIT,
        /// <summary>
        /// 
        /// </summary>
        IMAGE_JP2,
        /// <summary>
        /// 
        /// </summary>
        IMAGE_JPX,
        /// <summary>
        /// 
        /// </summary>
        IMAGE_RESERVED_FIRST,
        /// <summary>
        /// 
        /// </summary>
        IMAGE_RESERVED_LAST,
        /// <summary>
        /// 
        /// </summary>
        UNDEFINEDFIRMWARE,
        /// <summary>
        /// 
        /// </summary>
        WBMP
    ,
        /// <summary>
        /// 
        /// </summary>
        JPEGXR
    ,
        /// <summary>
        /// 
        /// </summary>
        WINDOWSIMAGEFORMAT,
        /// <summary>
        /// 
        /// </summary>
        UNDEFINEDAUDIO,
        /// <summary>
        /// 
        /// </summary>
        WMA,
        /// <summary>
        /// 
        /// </summary>
        OGG,
        /// <summary>
        /// 
        /// </summary>
        AAC,
        /// <summary>
        /// 
        /// </summary>
        AUDIBLE,
        /// <summary>
        /// 
        /// </summary>
        FLAC,
        /// <summary>
        /// 
        /// </summary>
        QCELP
    ,
        /// <summary>
        /// 
        /// </summary>
        AMR
    ,
        /// <summary>
        /// 
        /// </summary>
        UNDEFINEDVIDEO,
        /// <summary>
        /// 
        /// </summary>
        WMV,
        /// <summary>
        /// 
        /// </summary>
        MP4,
        /// <summary>
        /// 
        /// </summary>
        MP2,
    /// <summary>
    /// 
    /// </summary>
          ThreeG2
    ,
        /// <summary>
        /// 
        /// </summary>
        AVCHD
    ,
        /// <summary>
        /// 
        /// </summary>
        ATSCTS
    ,
        /// <summary>
        /// 
        /// </summary>
        DVBTS
    ,
        /// <summary>
        /// 
        /// </summary>
        UNDEFINEDCOLLECTION,
        /// <summary>
        /// 
        /// </summary>
        ABSTRACTMULTIMEDIAALBUM,
        /// <summary>
        /// 
        /// </summary>
        ABSTRACTIMAGEALBUM,
        /// <summary>
        /// 
        /// </summary>
        ABSTRACTAUDIOALBUM,
        /// <summary>
        /// 
        /// </summary>
        ABSTRACTVIDEOALBUM,
        /// <summary>
        /// 
        /// </summary>
        ABSTRACTAUDIOVIDEOPLAYLIST,
        /// <summary>
        /// 
        /// </summary>
        ABSTRACTCONTACTGROUP,
        /// <summary>
        /// 
        /// </summary>
        ABSTRACTMESSAGEFOLDER,
        /// <summary>
        /// 
        /// </summary>
        ABSTRACTCHAPTEREDPRODUCTION,
        /// <summary>
        /// 
        /// </summary>
        WPLPLAYLIST,
        /// <summary>
        /// 
        /// </summary>
        M3UPLAYLIST,
        /// <summary>
        /// 
        /// </summary>
        MPLPLAYLIST,
        /// <summary>
        /// 
        /// </summary>
        ASXPLAYLIST,
        /// <summary>
        /// 
        /// </summary>
        PLSPLAYLIST,
        /// <summary>
        /// 
        /// </summary>
        UNDEFINEDDOCUMENT,
        /// <summary>
        /// 
        /// </summary>
        ABSTRACTDOCUMENT,
        /// <summary>
        /// 
        /// </summary>
        XMLDOCUMENT,
        /// <summary>
        /// 
        /// </summary>
        MICROSOFTWORDDOCUMENT,
        /// <summary>
        /// 
        /// </summary>
        MHTCOMPILEDHTMLDOCUMENT,
        /// <summary>
        /// 
        /// </summary>
        MICROSOFTEXCELSPREADSHEET,
        /// <summary>
        /// 
        /// </summary>
        MICROSOFTPOWERPOINTDOCUMENT,
        /// <summary>
        /// 
        /// </summary>
        UNDEFINEDMESSAGE,
        /// <summary>
        /// 
        /// </summary>
        ABSTRACTMESSAGE,
        /// <summary>
        /// 
        /// </summary>
        UNDEFINEDCONTACT,
        /// <summary>
        /// 
        /// </summary>
        ABSTRACTCONTACT,
        /// <summary>
        /// 
        /// </summary>
        VCARD2,
        /// <summary>
        /// 
        /// </summary>
        VCARD3,
        /// <summary>
        /// 
        /// </summary>
        UNDEFINEDCALENDARITEM,
        /// <summary>
        /// 
        /// </summary>
        ABSTRACTCALENDARITEM,
        /// <summary>
        /// 
        /// </summary>
        VCALENDAR1,
        /// <summary>
        /// 
        /// </summary>
        VCALENDAR2,
        /// <summary>
        /// 
        /// </summary>
        UNDEFINEDWINDOWSEXECUTABLE,
        /// <summary>
        /// 
        /// </summary>
        MEDIA_CAST,
        /// <summary>
        /// 
        /// </summary>
        SECTION,
    /// <summary>
    /// 
    /// </summary>
                                  ThreeG2A

    }

}
