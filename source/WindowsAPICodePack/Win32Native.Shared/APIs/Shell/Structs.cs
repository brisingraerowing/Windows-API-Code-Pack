using System;
using System.Runtime.InteropServices;

using static System.Runtime.InteropServices.UnmanagedType;

namespace Microsoft.WindowsAPICodePack.Win32Native.Shell
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
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

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct FilterSpec
    {
        [MarshalAs(UnmanagedType.LPWStr)]
        public string Name;
        [MarshalAs(UnmanagedType.LPWStr)]
        public string Spec;

        public FilterSpec(string name, string spec)
        {
            Name = name;
            Spec = spec;
        }
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct ThumbnailId
    {
        [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 16)]
        public byte rgbKey;
    }

    /// <summary>
    /// Contains information about a file object.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
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
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = NativeAPI.Consts.Shell.MaxPath)]
        public string szDisplayName;

        /// <summary>
        /// A string that describes the type of file.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
        public string szTypeName;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct SHQUERYRBINFO
    {
        public int cbSize;
        public long i64Size;
        public long i64NumItems;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ShellNotifyStruct
    {
        public IntPtr item1;
        public IntPtr item2;
    }
}
