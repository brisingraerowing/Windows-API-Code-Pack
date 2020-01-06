using Microsoft.WindowsAPICodePack.Win32Native.Core;
using Microsoft.WindowsAPICodePack.Win32Native.Shell;
using MS.WindowsAPICodePack.Win32Native.Shell.PropertySystem;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows;

namespace Microsoft.WindowsAPICodePack.Win32Native.MediaDevices
{
    /// <summary>
    /// The WMDMID structure describes serial numbers and group IDs.
    /// </summary>
    public struct WMDMID
    {
        /// <summary>
        /// Size of the <see cref="WMDMID"/> structure, in bytes.
        /// </summary>
        public ushort cbSize;
        /// <summary>
        /// <see cref="uint"/> containing the registered ID number of the vendor. Contains zero if not in use.
        /// </summary>
        public uint dwVendorID;
        /// <summary>
        /// An array of bytes containing the serial number. The serial number is a string of byte values that have no standard format. Note that this is not a wide-character value. <see cref="Consts.WMDMID_LENGTH"/> is a constant value defined in mswmdm.h in the Windows SDK.
        /// </summary>
        public char[] pID;
        /// <summary>
        /// Actual length of the serial number returned, in bytes.
        /// </summary>
        public ushort SerialNumberLength;
    }

    /// <summary>
    /// The <see cref="WaveFormatEx"/> structure defines the format of waveform-audio data.
    /// </summary>
    public struct WaveFormatEx
    {
        /// <summary>
        /// Must be set to a format or formats supported by the device. Note that previous versions of the Windows Media Device Manager recommended using WMDM_WAVE_FORMAT_ALL to indicate support for all formats. However, this is no longer recommended, as different media players will interpret this in different ways, and few devices can truly play any file format. It is now recommended that you use the <see cref="PropValidValuesForm.Any"/> value of the <see cref="PropValidValuesForm"/> enumeration, or better yet specify a range of formats with the <see cref="PropValuesRange"/> structure.
        /// </summary>
        public PropValidValuesForm wFormatTag;
        public ushort nChannels;
        public uint nSamplesPerSec;
        public uint nAvgBytesPerSec;
        public ushort nBlockAlign;
        public ushort wBitsPerSample;
        public ushort cbSize;
    }

    /// <summary>
    /// The <see cref="PropValuesRange"/> structure describes a range of valid values for a particular property in a particular property configuration.
    /// </summary>
    /// <remarks>This structure is used in the <see cref="PropDesc"/> structure to describe a range of valid values. A range of valid values is applicable when <see cref="PropValidValuesForm.Enum"/> is selected from the <see cref="PropValidValuesForm"/> enumeration.</remarks>
    /// <seealso cref="IWMDMDevice3.GetFormatCapability"/>
    /// <seealso cref="PropValidValuesForm"/>
    /// <seealso cref="FormatCapability"/>
    /// <seealso cref="WMDM_PROP_CONFIG"/>
    /// <seealso cref="PropDesc"/>
    /// <seealso cref="PropValuesEnum"/>
    /// <seealso href="https://docs.microsoft.com/fr-fr/windows/win32/wmdm/structures"/>
    public struct PropValuesRange
    {
        /// <summary>
        /// Minimum value in the range.
        /// </summary>
        public PropVariant rangeMin;
        /// <summary>
        /// Maximum value in the range.
        /// </summary>
        public PropVariant rangeMax;
        /// <summary>
        /// The step size in which valid values increment from the minimum value to the maximum value.This permits specifying discrete permissible values in a range.
        /// </summary>
        public PropVariant rangeStep;
    }

    /// <summary>
    /// The <see cref="PropDesc"/> structure describes valid values of a property in a particular property configuration.
    /// </summary>
    /// <remarks><para>The <see cref="PropDesc"/> structure contains a property description that consists of a property name and its valid values in a particular configuration.</para>
    /// <para>The caller is required to free the memory used by <see cref="PropDescValidValues.ValidValuesRange"/> or <see cref="PropDescValidValues.EnumeratedValidValues"/>. For an example of how to do this, see <see cref="FormatCapability"/>.</para></remarks>
    public struct PropDesc
    {
        /// <summary>
        /// Name of the property. The application must free this memory when it is done using it.
        /// </summary>
        [MarshalAs(UnmanagedType.LPWStr)]
        public string pwszPropName;
        /// <summary>
        /// A <see cref="PropValidValuesForm"/> enumeration value describing the type of values, such as a range or list. The value of this enumeration determines which member variable is used.
        /// </summary>
        public PropValidValuesForm ValidValuesForm;
        /// <summary>
        /// See <see cref="PropDescValidValues"/>.
        /// </summary>
        public PropDescValidValues ValidValues;
    }

    /// <summary>
    /// Holds the valid values of the property in a particular property configuration. This member holds one of three items: the enumeration value <see cref="PropValidValuesForm.Any"/>; the member <see cref="ValidValuesRange"/>; or the member <see cref="EnumeratedValidValues"/>. The value or member is indicated by <see cref="PropDesc.ValidValuesForm"/>.
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public struct PropDescValidValues

    {

        /// <summary>
        /// A <see cref="PropValuesRange"/> structure containing a range of valid values. This is present only when <see cref="PropDesc.ValidValuesForm"/> is set to <see cref="PropValidValuesForm.Range"/>. See the Remarks section of the <see cref="PropDesc"/> structure.
        /// </summary>
        [FieldOffset(0)]
        public PropValuesRange ValidValuesRange;
        /// <summary>
        /// A <see cref="PropValuesEnum"/> structure containing an enumerated set of valid values. This is present only when <see cref="PropDesc.ValidValuesForm"/> is set to <see cref="PropValidValuesForm.Enum"/>. See the Remarks section of the <see cref="PropDesc"/> structure.
        /// </summary>
        [FieldOffset(0)]
        public PropValuesEnum EnumeratedValidValues;

    }
    /// <summary>
    /// The <see cref="PropValuesEnum"/> structure contains an enumerated set of valid values for a particular property in a particular property configuration.
    /// </summary>
    /// <remarks><para>This structure is used in the <see cref="PropDesc"/> structure to describe an enumerated set of valid values. An enumerated set of valid values is applicable when <see cref="PropValidValuesForm.Enum"/> is selected from the <see cref="PropValidValuesForm"/> enumeration.</para>
    /// <para>The caller is required to free the memory used by pValues. For an example of how to do this, see <a href="https://docs.microsoft.com/fr-fr/windows/win32/wmdm/wmdm-format-capability">WMDM_FORMAT_CAPABILITY</a>.</para></remarks>
    /// <seealso cref="IWMDMDevice3.GetFormatCapability"/>
    /// <seealso cref="PropValidValuesForm"/>
    /// <seealso cref="FormatCapability"/>
    /// <seealso cref="WMDM_PROP_CONFIG"/>
    /// <seealso cref="PropDesc"/>
    /// <seealso cref="PropValuesRange"/>
    /// <seealso cref="https://docs.microsoft.com/fr-fr/windows/win32/wmdm/structures"/>
    public struct PropValuesEnum
    {
        /// <summary>
        /// Count of enumerated values.
        /// </summary>
        public ushort cEnumValues;

        /// <summary>
        /// An array of values. The size of the array is equal to the value of <see cref="cEnumValues"/>.
        /// </summary>
        public PropVariant[] pValues;
    }

    public struct OpaqueCommand
    {
        public Guid guidCommand;
        public uint dwDataLen;
        public char pData;
        public StringBuilder abMAC;
    }

    public struct VideoInfoHeader
    {
        public NativeRect rcSource;
        public NativeRect rcTarget;
        public uint dwBitRate;
        public uint dwBitErrorRate;
        public long AvgTimePerFrame;
        public BitmapInfoHeader bmiHeader;
    }

    public struct BitmapInfoHeader
    {
        public uint biSize;
        public int biWidth;
        public int biHeight;
        public ushort biPlanes;
        public ushort biBitCount;
        public uint biCompression;
        public uint biSizeImage;
        public int biXPelsPerMeter;
        public int biYPelsPerMeter;
        public uint biClrUsed;
        public uint biClrImportant;
    }

    public struct FileCapabilities
    {
        [MarshalAs(UnmanagedType.LPWStr)] 
        public string pwszMimeType;
        public uint dwReserved;
    }

    public struct FormatCapability
    {
        public ushort nPropConfig;
        public IntPtr pConfigs;
    }

    public struct MetadataView
    {
        public StringBuilder pwszViewName;
        public ushort nDepth;
        public StringBuilder ppwszTags;
    }

    public struct WMDMRights
    {
        public ushort cbSize;
        public uint dwContentType;
        public uint fuFlags;
        public uint fuRights;
        public uint dwAppSec;
        public uint dwPlaybackCount;
        public WMDMDateTime ExpirationDate;
    }

    public struct WMDMDateTime
    {
        public ushort wYear;
        public ushort wMonth;
        public ushort wDay;
        public ushort wHour;
        public ushort wMinute;
        public ushort wSecond;
    }
}
