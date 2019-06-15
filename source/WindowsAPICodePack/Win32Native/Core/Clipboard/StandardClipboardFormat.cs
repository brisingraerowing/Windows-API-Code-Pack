using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.WindowsAPICodePack.Win32Native.Core
{


    /// <summary>
    /// The clipboard formats defined by the system.
    /// </summary>
    public enum StandardClipboardFormats : int
    {

        /// <summary>
        /// A handle to a bitmap (HBITMAP).
        /// </summary>
        Bitmap = 2,

        /// <summary>
        /// A memory object containing a BITMAPINFO structure followed by the bitmap bits.
        /// </summary>
        Dib = 8,

        /// <summary>
        /// A memory object containing a BITMAPV5HEADER structure followed by the bitmap color space information and the bitmap bits.
        /// </summary>
        DibV5 = 17,

        /// <summary>
        /// Software Arts' Data Interchange Format.
        /// </summary>
        Dif = 5,

        /// <summary>
        /// Bitmap display format associated with a private format. The hMem parameter must be a handle to data that can be displayed in bitmap format in lieu of the privately formatted data.
        /// </summary>
        DSBitmap = 0x0082,

        /// <summary>
        /// Enhanced metafile display format associated with a private format. The hMem parameter must be a handle to data that can be displayed in enhanced metafile format in lieu of the privately formatted data.
        /// </summary>
        DSPEnhMetaFile = 0x008E,

        /// <summary>
        /// Metafile-picture display format associated with a private format. The hMem parameter must be a handle to data that can be displayed in metafile-picture format in lieu of the privately formatted data.
        /// </summary>
        DSPMetaFilePicture = 0x0083,

        /// <summary>
        /// Text display format associated with a private format. The hMem parameter must be a handle to data that can be displayed in text format in lieu of the privately formatted data.
        /// </summary>
        DSPText = 0x0081,

        /// <summary>
        /// A handle to an enhanced metafile (HENHMETAFILE).
        /// </summary>
        EnhMetaFile = 14,

        /// <summary>
        /// Start of a range of integer values for application-defined GDI object clipboard formats. The end of the range is <see cref="GDIObjLast"/>.
        /// Handles associated with clipboard formats in this range are not automatically deleted using the GlobalFree function when the clipboard is emptied. Also, when using values in this range, the hMem parameter is not a handle to a GDI object, but is a handle allocated by the GlobalAlloc function with the GMEM_MOVEABLE flag.
        /// </summary>
        GDIObjFirst = 0x0300,

        /// <summary>
        /// See <see cref="GDIObjFirst"/>.
        /// </summary>
        GDIObjLast = 0x03FF,

        /// <summary>
        /// A handle to type HDROP that identifies a list of files. An application can retrieve information about the files by passing the handle to the DragQueryFile function.
        /// </summary>
        HDrop = 15,

        /// <summary>
        /// The data is a handle to the locale identifier associated with text in the clipboard. When you close the clipboard, if it contains <see cref="CF_TEXT"/> data but no Locale data, the system automatically sets the Locale format to the current input language. You can use the Locale format to associate a different locale with the clipboard text.
        /// An application that pastes text from the clipboard can retrieve this format to determine which character set was used to generate the text.
        /// Note that the clipboard does not support plain text in multiple character sets. To achieve this, use a formatted text data type such as RTF instead.
        /// The system uses the code page associated with Locale to implicitly convert from <see cref="CF_TEXT"/> to <see cref="CF_UNICODETEXT"/>. Therefore, the correct code page table is used for the conversion.
        /// </summary>
        Locale = 16,

        /// <summary>
        /// Handle to a metafile picture format as defined by the MetaFilePicture structure. When passing a MetaFilePicture handle by means of DDE, the application responsible for deleting hMem should also free the metafile referred to by the MetaFilePicture handle.
        /// </summary>
        MetaFilePicture = 3,

        /// <summary>
        /// Text format containing characters in the OEM character set. Each line ends with a carriage return/linefeed (CR-LF) combination. A null character signals the end of the data.
        /// </summary>
        OEMText = 7,

        /// <summary>
        /// Owner-display format. The clipboard owner must display and update the clipboard viewer window, and receive the WM_ASKCBFORMATNAME, WM_HSCROLLCLIPBOARD, WM_PAINTCLIPBOARD, WM_SIZECLIPBOARD, and WM_VSCROLLCLIPBOARD messages. The hMem parameter must be NULL.
        /// </summary>
        OwnerDisplay = 0x0080,

        /// <summary>
        /// Handle to a color palette. Whenever an application places data in the clipboard that depends on or assumes a color palette, it should place the palette on the clipboard as well.
        /// If the clipboard contains data in the Palette (logical color palette) format, the application should use the SelectPalette and RealizePalette functions to realize (compare) any other data in the clipboard against that logical palette.
        /// When displaying clipboard data, the clipboard always uses as its current palette any object on the clipboard that is in the Palette format.
        /// </summary>
        Palette = 9,

        /// <summary>
        /// Data for the pen extensions to the Microsoft Windows for Pen Computing.
        /// </summary>
        PenData = 10,

        /// <summary>
        /// Start of a range of integer values for private clipboard formats.The range ends with <see cref="CF_PRIVATELAST"/>. Handles associated with private clipboard formats are not freed automatically; the clipboard owner must free such handles, typically in response to the WM_DESTROYCLIPBOARD message.
        /// </summary>
        PrivateFirst = 0x0200,

        /// <summary>
        /// See <see cref="PrivateFirst"/>.
        /// </summary>
        PrivateLast = 0x02FF,

        /// <summary>
        /// Represents audio data more complex than can be represented in a <see cref="CF_WAVE"/> standard wave format.
        /// </summary>
        RIFF = 11,

        /// <summary>
        /// Microsoft Symbolic Link (SYLK) format.
        /// </summary>
        SYLK = 4,

        /// <summary>
        /// Text format. Each line ends with a carriage return/linefeed (CR-LF) combination. A null character signals the end of the data.Use this format for ANSI text.
        /// </summary>
        Text = 1,

        /// <summary>
        /// Tagged-image file format.
        /// </summary>
        TIFF = 6,

        /// <summary>
        /// Unicode text format.Each line ends with a carriage return/linefeed (CR-LF) combination. A null character signals the end of the data.
        /// </summary>
        UnicodeText = 13,

        /// <summary>
        /// Represents audio data in one of the standard wave formats, such as 11 kHz or 22 kHz PCM.
        /// </summary>
        Wave = 12

    }
}
