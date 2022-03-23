using System;
using System.Runtime.InteropServices;

using static Microsoft.WindowsAPICodePack.NativeAPI.Consts.Shell;

using static System.Runtime.InteropServices.CharSet;
using static System.Runtime.InteropServices.LayoutKind;
using static System.Runtime.InteropServices.UnmanagedType;

namespace Microsoft.WindowsAPICodePack.Win32Native.Shell
{
    [StructLayout(Sequential)]
    public struct FileTime
    {
        [MarshalAs(U4)]
        public uint dwLowDateTime;

        [MarshalAs(U4)]
        public uint dwHighDateTime;
    }

    [StructLayout(Sequential)]
    public struct FileSize
    {
        [MarshalAs(U4)]
        public uint nFileSizeHigh;

        [MarshalAs(U4)]
        public uint nFileSizeLow;
    }

    [StructLayout(Sequential, CharSet = Unicode)]
    public struct Win32FindData
    {
        public const byte AlternateFileName = 14;

        [MarshalAs(U4)]
        public FileAttributes dwFileAttributes;
        public FileTime ftCreationTime;
        public FileTime ftLastAccessTime;
        public FileTime ftLastWriteTime;
        public FileSize fileSize;
        [MarshalAs(U4)]
        public uint reserved0;
        [MarshalAs(U4)]
        public uint reserved1;
        [MarshalAs(ByValTStr, SizeConst = MaxPath)]
        public string cFileName;
        [MarshalAs(ByValTStr, SizeConst = AlternateFileName)]
        public string cAlternateFileName;
        public uint  dwFileType;
        public uint  dwCreatorType;
        public ushort wFinderFlags;
    }

    [StructLayout(Sequential, CharSet = Unicode)]
    public struct NotifyIconData
    {
        [MarshalAs(U4)]
        public uint cbSize;

        public IntPtr hWnd;

        [MarshalAs(U4)]
        public uint uID;

        [MarshalAs(U4)]
        public NotifyIconFlags uFlags;

        [MarshalAs(U4)]
        public uint uCallbackMessage;

        public IntPtr hIcon;

        [MarshalAs(ByValTStr, SizeConst = 128)]
        public string szTip;

        [MarshalAs(U4)]
        public NotifyIconStates dwState;

        [MarshalAs(U4)]
        public NotifyIconStates dwStateMask;

        [MarshalAs(ByValTStr, SizeConst = 256)]
        public string szInfo;

        [MarshalAs(U4)]
        public NotifyIconVersion uVersion;

        [MarshalAs(ByValTStr, SizeConst = 64)]
        public string szInfoTitle;

        [MarshalAs(U4)]
        public NotifyIconInfos dwInfoFlags;

        public Guid guidItem;

        public IntPtr hBalloonIcon;
    }

    [StructLayout(Sequential, CharSet = CharSet.Auto)]
    public struct FilterSpec
    {
        [MarshalAs(LPWStr)]
        public string Name;
        [MarshalAs(LPWStr)]
        public string Spec;

        public FilterSpec(string name, string spec)
        {
            Name = name;
            Spec = spec;
        }
    }

    [StructLayout(Sequential, CharSet = CharSet.Auto)]
    public struct ThumbnailId
    {
        [MarshalAs(LPArray, SizeParamIndex = 16)]
        public byte rgbKey;
    }

    /// <summary>
    /// Contains information about a file object.
    /// </summary>
    [StructLayout(Sequential, CharSet = Unicode)]
    public struct SHFILEINFO
    {
        /// <summary>
        /// A handle to the icon that represents the file. You are responsible for destroying this handle with DestroyIcon when you no longer need it.
        /// </summary>
        public IntPtr hIcon;

        /// <summary>
        /// The index of the icon image within the system image list.
        /// </summary>
        public int iIcon;

        /// <summary>
        /// An array of values that indicates the attributes of the file object. For information about these values, see the IShellFolder.GetAttributesOf method.
        /// </summary>
        public ShellFileGetAttributesOptions dwAttributes;

        /// <summary>
        /// A string that contains the name of the file as it appears in the Windows Shell, or the path and file name of the file that contains the icon representing the file.
        /// </summary>
        [MarshalAs(ByValTStr, SizeConst = MaxPath)]
        public string szDisplayName;

        /// <summary>
        /// A string that describes the type of file.
        /// </summary>
        [MarshalAs(ByValTStr, SizeConst = 80)]
        public string szTypeName;
    }

    [StructLayout(Sequential, Pack = 8)]
    public struct SHQUERYRBINFO
    {
        public int cbSize;
        public long i64Size;
        public long i64NumItems;
    }

    [StructLayout(Sequential)]
    public struct ShellNotifyStruct
    {
        public IntPtr item1;
        public IntPtr item2;
    }
}
