using System;
using System.Runtime.InteropServices;

namespace Microsoft.WindowsAPICodePack.Win32Native.Shell
{
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

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
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
