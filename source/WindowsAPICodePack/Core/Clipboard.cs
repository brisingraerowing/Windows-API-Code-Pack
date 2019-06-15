//using Microsoft.WindowsAPICodePack.Win32Native.Core;
//using System;
//using System.Collections.Specialized;
//using System.ComponentModel;
//using System.IO;
//using System.Linq;
//using System.Threading;
//using IDataObject = System.Runtime.InteropServices.ComTypes.IDataObject;

//namespace Microsoft.WindowsAPICodePack
//{

//    public enum CommonClipboardFormats
//    {

//        None,

//        Audio,

//        Image,

//        Text,

//        FileDropList,

//        Data,

//        All

//    }

//    public static class Clipboard
//    {

//        public enum GetClipboardDataFlags
//        {
//            RECO_PASTE = 0,
//            RECO_DROP = 1,
//            RECO_COPY = 2,
//            RECO_CUT = 3,
//            RECO_DRAG = 4
//        }

//        private static bool ContainsInternal(bool value, out StandardClipboardFormats formatToSet, StandardClipboardFormats format)

//        {

//            CloseClipboard();

//            formatToSet = format;

//            return value;

//        }

//        public static bool Contains(WindowInteropHelper ownerWindow, string format)
//        {

//            OpenClipboard(ownerWindow.Handle);

//            int formatId = DataFormats.GetDataFormat(format).Id;

//            CloseClipboard();

//            return IsClipboardFormatAvailable(formatId);

//        }

//        public static bool Contains(WindowInteropHelper ownerWindow, CommonClipboardFormats format, out StandardClipboardFormats standardClipboardFormat)

//        {

//            format.ThrowIfNotValidEnumValue();

//            OpenClipboard(ownerWindow.Handle);

//            switch (format)

//            {

//                case CommonClipboardFormats.None:

//                    foreach (object value in typeof(StandardClipboardFormats).GetEnumValues())

//                        if (IsClipboardFormatAvailable((int)value))

//                            return ContainsInternal(false, out standardClipboardFormat, (StandardClipboardFormats)value);

//                    return ContainsInternal(true, out standardClipboardFormat, 0);

//                case CommonClipboardFormats.All:

//                    Array values = typeof(StandardClipboardFormats).GetEnumValues();

//                    foreach (object value in values)

//                        if (!IsClipboardFormatAvailable((int)value))

//                            return ContainsInternal(false, out standardClipboardFormat, (StandardClipboardFormats)value);

//                    return ContainsInternal(true, out standardClipboardFormat, (StandardClipboardFormats)values.ToList()[0]);

//            }

//            StandardClipboardFormats[] formats;

//            switch (format)

//            {

//                case CommonClipboardFormats.Audio:

//                    formats = new StandardClipboardFormats[] { StandardClipboardFormats.RIFF, StandardClipboardFormats.Wave };

//                    break;

//                case CommonClipboardFormats.Image:

//                    formats = new StandardClipboardFormats[] { StandardClipboardFormats.Bitmap, StandardClipboardFormats.Dib, StandardClipboardFormats.DibV5, StandardClipboardFormats.DSBitmap, StandardClipboardFormats.Palette, StandardClipboardFormats.PenData, StandardClipboardFormats.TIFF };

//                    break;

//                case CommonClipboardFormats.Text:

//                    formats = new StandardClipboardFormats[] { StandardClipboardFormats.DSPText, StandardClipboardFormats.Locale, StandardClipboardFormats.OEMText, StandardClipboardFormats.Text, StandardClipboardFormats.UnicodeText };

//                    break;

//                case CommonClipboardFormats.FileDropList:

//                    formats = new StandardClipboardFormats[] { StandardClipboardFormats.HDrop };

//                    break;

//                case CommonClipboardFormats.Data:

//                    formats = new StandardClipboardFormats[] { StandardClipboardFormats.DSPEnhMetaFile, StandardClipboardFormats.DSPMetaFilePicture, StandardClipboardFormats.EnhMetaFile, StandardClipboardFormats.GDIObjFirst, StandardClipboardFormats.GDIObjLast, StandardClipboardFormats.CF_METAFILEPICT, StandardClipboardFormats.CF_OWNERDISPLAY, StandardClipboardFormats.CF_PRIVATEFIRST, StandardClipboardFormats.CF_PRIVATELAST, StandardClipboardFormats.CF_SYLK };

//                    break;

//                default:

//                    // We wouldn't reach this code.

//                    standardClipboardFormat = 0;

//                    return false;

//            }

//            foreach (StandardClipboardFormats value in formats)

//                if (IsClipboardFormatAvailable((int)value))

//                    return ContainsInternal(true, out standardClipboardFormat, value);

//            return ContainsInternal(false, out standardClipboardFormat, 0);

//        }

//        public static System.Windows.IDataObject GetDataObject(WindowInteropHelper ownerWindow)

//        {

//            OpenClipboard(ownerWindow.Handle);

//            object oleDataObject;

//            uint result = OleGetClipboard(out oleDataObject);

//            /*if (closeClipboard) */
//            CloseClipboard();

//            if (result == (int)ErrorCodes.ERROR_SUCCESS)

//                return oleDataObject is System.Windows.IDataObject ? (System.Windows.IDataObject)oleDataObject : oleDataObject != null ? new DataObject(oleDataObject) : null;

//            else

//                throw new Win32Exception((int)result);

//        }

//        public static object GetData(WindowInteropHelper ownerWindow, string format) => GetDataObject(ownerWindow)?.GetData(format);

//        public static object GetData(WindowInteropHelper ownerWindow, StandardClipboardFormats format) => GetDataObject(ownerWindow)?.GetData(DataFormats.GetDataFormat((int)format).Name);

//        public static Stream GetAudioStream(WindowInteropHelper ownerWindow) => GetData(ownerWindow, StandardClipboardFormats.CF_WAVE) as Stream;

//        public static StringCollection GetFileDropList(WindowInteropHelper ownerWindow)

//        {

//            string[] fileDropArray = GetData(ownerWindow, StandardClipboardFormats.HDrop) as string[];

//            StringCollection sc = new StringCollection();

//            if (fileDropArray != null)

//                sc.AddRange(fileDropArray);

//            return sc;

//        }

//        public static BitmapSource GetBitmapSource(WindowInteropHelper ownerWindow) => GetData(ownerWindow, StandardClipboardFormats.Bitmap) as BitmapSource;

//        public static string GetText(WindowInteropHelper ownerWindow) => GetData(ownerWindow, StandardClipboardFormats.CF_UNICODETEXT) as string;

//        public static string GetText(WindowInteropHelper ownerWindow, TextDataFormat format)

//        {

//            format.ThrowIfNotValidEnumValue();

//            int standardClipboardFormat;

//            switch (format)

//            {

//                case TextDataFormat.Text:

//                    standardClipboardFormat = (int)StandardClipboardFormats.CF_TEXT;

//                    break;

//                case TextDataFormat.UnicodeText:

//                    standardClipboardFormat = (int)StandardClipboardFormats.CF_UNICODETEXT;

//                    break;

//                case TextDataFormat.Rtf:

//                    standardClipboardFormat = DataFormats.GetDataFormat(DataFormats.Rtf).Id;

//                    break;

//                case TextDataFormat.Html:

//                    standardClipboardFormat = DataFormats.GetDataFormat(DataFormats.Html).Id;

//                    break;

//                case TextDataFormat.CommaSeparatedValue:

//                    standardClipboardFormat = DataFormats.GetDataFormat(DataFormats.CommaSeparatedValue).Id;

//                    break;

//                case TextDataFormat.Xaml:

//                    standardClipboardFormat = DataFormats.GetDataFormat(DataFormats.Xaml).Id;

//                    break;

//                default:

//                    // We wouldn't reach this code.

//                    return null;

//            }

//            return GetData(ownerWindow, (StandardClipboardFormats)standardClipboardFormat) as string;

//        }

//        public static void Flush()

//        {

//            int result = OleFlushClipboard();

//            if (result != (int)ErrorCodes.ERROR_SUCCESS)

//                throw new Win32Exception(result);

//        }
//        const uint CLIPBRD_E_CANT_OPEN = 0x800401D0;
//        public static void SetDataObject(IDataObject dataObject, bool copy)

//        {

//            //bool r = OpenClipboard(ownerWindow.Handle);

//            // r = EmptyClipboard();

//            //if (OpenClipboard(ownerWindow.Handle))

//            //{

//            bool value = false;
//            uint result = 0;

//            for (int i = 0; i < 10; i++)
//            {
//                result = OleSetClipboard(dataObject);
//                value = CLIPBRD_E_CANT_OPEN == result;
//                if (value)
//                    Thread.Sleep(10);
//                else
//                    break;
//            }

//            if (result != (int)ErrorCodes.ERROR_SUCCESS)

//                throw new Win32Exception((int)result);

//            if (copy)

//            {

//                result = (uint)OleFlushClipboard();

//                if (result != (int)ErrorCodes.ERROR_SUCCESS)

//                {

//                    // CloseClipboard();

//                    throw new Win32Exception((int)result);

//                }

//            }

//            // CloseClipboard();

//            // }

//        }

//        public static void SetData(WindowInteropHelper ownerWindow, string format, object data, bool copy) => SetDataObject(data is IDataObject ? (IDataObject)data : new DataObject(format, data), copy);

//        public static void SetData(WindowInteropHelper ownerWindow, StandardClipboardFormats format, object data, bool copy) => SetDataObject(data is IDataObject ? (IDataObject)data : new DataObject(DataFormats.GetDataFormat((int)format).Name, data), copy);

//        public static void SetAudio(WindowInteropHelper ownerWindow, Stream data, bool copy) => SetData(ownerWindow, StandardClipboardFormats.CF_WAVE, data, copy);

//        public static void SetFileDropList(WindowInteropHelper ownerWindow, StringCollection sc, bool copy) => SetData(ownerWindow, StandardClipboardFormats.HDrop, sc.ToList().ToArray(typeof(string)), copy);

//    }
//}
