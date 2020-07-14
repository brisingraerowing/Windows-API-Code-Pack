//Copyright (c) Microsoft Corporation.  All rights reserved.  Distributed under the Microsoft Public License (MS-PL)

using Microsoft.WindowsAPICodePack.PropertySystem;
using Microsoft.WindowsAPICodePack.Win32Native;
using Microsoft.WindowsAPICodePack.Win32Native.PropertySystem;
using Microsoft.WindowsAPICodePack.Win32Native.Shell;
using System;
using System.Runtime.InteropServices;
using static Microsoft.WindowsAPICodePack.NativeAPI.Consts.DllNames;

namespace Microsoft.WindowsAPICodePack.Win32Native.Taskbar
{
    #region Enums
    public enum KnownDestinationCategory
    {
        Frequent = 1,
        Recent
    }

    public enum ShellAddToRecentDocs
    {
        Pidl = 0x1,
        PathA = 0x2,
        PathW = 0x3,
        AppIdInfo = 0x4,       // indicates the data type is a pointer to a SHARDAPPIDINFO structure
        AppIdInfoIdList = 0x5, // indicates the data type is a pointer to a SHARDAPPIDINFOIDLIST structure
        Link = 0x6,            // indicates the data type is a pointer to an IShellLink instance
        AppIdInfoLink = 0x7,   // indicates the data type is a pointer to a SHARDAPPIDINFOLINK structure 
    }

    public enum TaskbarProgressBarStatus
    {
        NoProgress = 0,
        Indeterminate = 0x1,
        Normal = 0x2,
        Error = 0x4,
        Paused = 0x8
    }

    public enum TaskbarActiveTabSetting
    {
        UseMdiThumbnail = 0x1,
        UseMdiLivePreview = 0x2
    }

    public enum ThumbButtonMask
    {
        Bitmap = 0x1,
        Icon = 0x2,
        Tooltip = 0x4,
        THB_FLAGS = 0x8
    }

    [Flags]
    public enum ThumbButtonOptions
    {
        Enabled = 0x00000000,
        Disabled = 0x00000001,
        DismissOnClick = 0x00000002,
        NoBackground = 0x00000004,
        Hidden = 0x00000008,
        NonInteractive = 0x00000010
    }

    public enum SetTabPropertiesOption
    {
        None = 0x0,
        UseAppThumbnailAlways = 0x1,
        UseAppThumbnailWhenActive = 0x2,
        UseAppPeekAlways = 0x4,
        UseAppPeekWhenActive = 0x8
    }

    #endregion

    #region Structs

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct ThumbButton
    {
        /// <summary>
        /// WPARAM value for a THUMBBUTTON being clicked.
        /// </summary>
        public const int Clicked = 0x1800;

        [MarshalAs(UnmanagedType.U4)]
        public ThumbButtonMask Mask;
        public uint Id;
        public uint Bitmap;
        public IntPtr Icon;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
        public string Tip;
        [MarshalAs(UnmanagedType.U4)]
        public ThumbButtonOptions Flags;
    }
    #endregion;

    public static class Taskbar
    {

        // Register Window Message used by Shell to notify that the corresponding taskbar button has been added to the taskbar.
        public static readonly uint WmTaskbarButtonCreated = RegisterWindowMessage("TaskbarButtonCreated");

        #region Methods

        [DllImport(Shell32)]
        public static extern void SetCurrentProcessExplicitAppUserModelID(
            [MarshalAs(UnmanagedType.LPWStr)] string AppID);

        [DllImport(Shell32)]
        public static extern void GetCurrentProcessExplicitAppUserModelID(
            [Out(), MarshalAs(UnmanagedType.LPWStr)] out string AppID);

        [DllImport(Shell32)]
        public static extern void SHAddToRecentDocs(
            ShellAddToRecentDocs flags,
            [MarshalAs(UnmanagedType.LPWStr)] string path);

        public static void SHAddToRecentDocs(string path) => SHAddToRecentDocs(ShellAddToRecentDocs.PathW, path);

        [DllImport(User32, EntryPoint = "RegisterWindowMessage", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern uint RegisterWindowMessage([MarshalAs(UnmanagedType.LPWStr)] string lpString);

        #endregion
    }

    /// <summary>
    /// Thumbnail Alpha Types
    /// </summary>
    public enum ThumbnailAlphaType
    {
        /// <summary>
        /// Let the system decide.
        /// </summary>
        Unknown = 0,

        /// <summary>
        /// No transparency
        /// </summary>
        NoAlphaChannel = 1,

        /// <summary>
        /// Has transparency
        /// </summary>
        HasAlphaChannel = 2,
    }
}
