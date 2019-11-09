﻿using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using Microsoft.WindowsAPICodePack.Win32Native.Core;
using Microsoft.WindowsAPICodePack.Win32Native.Shell;

namespace Microsoft.WindowsAPICodePack.Win32Native.ShellExtensions.Interop
{
    public static class HandlerNativeMethods
    {
        [DllImport("user32.dll")]
        public static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        [DllImport("user32.dll")]
        public static extern IntPtr GetFocus();

        //[DllImport("user32.dll")]
        //public static extern uint GetWindowLong(IntPtr hwnd, GetWindowLong index);

        [DllImport("user32.dll", EntryPoint = "GetWindowLong")]
        private static extern int GetWindowLongPtr32(IntPtr hWnd, GetWindowLong nIndex);

        [DllImport("user32.dll", EntryPoint = "GetWindowLongPtr")]
        private static extern int GetWindowLongPtr64(IntPtr hWnd, GetWindowLong nIndex);

        // This static method is required because Win32 does not support
        // GetWindowLongPtr directly
        public static int GetWindowLongPtr(IntPtr hWnd, GetWindowLong nIndex) => IntPtr.Size == 8 ? GetWindowLongPtr64(hWnd, nIndex) : GetWindowLongPtr32(hWnd, nIndex);

        //[DllImport("user32.dll")]
        //public static extern int SetWindowLong(IntPtr hwnd, GetWindowLong index, uint newStyle);

        // This helper static method is required because the 32-bit version of user32.dll does not contain this API
        // (on any versions of Windows), so linking the method will fail at run-time. The bridge dispatches the request
        // to the correct function (GetWindowLong in 32-bit mode and GetWindowLongPtr in 64-bit mode)
        public static int SetWindowLongPtr(IntPtr hWnd, GetWindowLong nIndex, uint dwNewLong) => IntPtr.Size == 8
                ? SetWindowLongPtr64(hWnd, nIndex, dwNewLong)
                : SetWindowLong32(hWnd, nIndex, dwNewLong);

        [DllImport("user32.dll", EntryPoint = "SetWindowLong")]
        private static extern int SetWindowLong32(IntPtr hWnd, GetWindowLong nIndex, uint dwNewLong);

        [DllImport("user32.dll", EntryPoint = "SetWindowLongPtr")]
        private static extern int SetWindowLongPtr64(IntPtr hWnd, GetWindowLong nIndex, uint dwNewLong);

        [DllImport("user32.dll")]
        public static extern bool SetWindowPos(
            IntPtr hWnd,
            IntPtr hWndInsertAfter,
            int x,
            int y,
            int cx,
            int cy,
            SetWindowPositionOptions flags);

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int GetWindowThreadProcessId(IntPtr handle, out int processId);

        public static readonly Guid IPreviewHandlerGuid = new Guid("8895b1c6-b41f-4c1c-a562-0d564250836f");
        public static readonly Guid IThumbnailProviderGuid = new Guid("e357fccd-a995-4576-b01f-234630154e96");

        public static readonly Guid IInitializeWithFileGuid = new Guid("b7d14566-0509-4cce-a71f-0a554233bd9b");
        public static readonly Guid IInitializeWithStreamGuid = new Guid("b824b49d-22ac-4161-ac8a-9916e8fa3f7f");
        public static readonly Guid IInitializeWithItemGuid = new Guid("7f73be3f-fb79-493c-a6c7-7ee14e245841");

        public static readonly Guid IMarshalGuid = new Guid("00000003-0000-0000-C000-000000000046");
    }

    #region Interfaces

    /// <summary>
    /// ComVisible interface for native IThumbnailProvider
    /// </summary>
    [ComImport]
    [Guid("e357fccd-a995-4576-b01f-234630154e96")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
   public interface IThumbnailProvider
    {
        /// <summary>
        /// Gets a pointer to a bitmap to display as a thumbnail
        /// </summary>
        /// <param name="squareLength"></param>
        /// <param name="bitmapHandle"></param>
        /// <param name="bitmapType"></param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "2#"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "1#")]
        void GetThumbnail(uint squareLength, [Out] out IntPtr bitmapHandle, [Out] out UInt32 bitmapType);
    }

    /// <summary>
    /// Provides means by which to initialize with a file.
    /// </summary>
    [ComImport]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("b7d14566-0509-4cce-a71f-0a554233bd9b")]
    public interface IInitializeWithFile
    {
        /// <summary>
        /// Initializes with a file.
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="fileMode"></param>
        void Initialize([MarshalAs(UnmanagedType.LPWStr)] string filePath, AccessModes fileMode);
    }

    /// <summary>
    /// Provides means by which to initialize with a stream.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1711:IdentifiersShouldNotHaveIncorrectSuffix")]
    [ComImport]
    [Guid("b824b49d-22ac-4161-ac8a-9916e8fa3f7f")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IInitializeWithStream
    {
        /// <summary>
        /// Initializes with a stream.
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="fileMode"></param>
        void Initialize(IStream stream, AccessModes fileMode);
    }

    /// <summary>
    /// Provides means by which to initialize with a ShellObject
    /// </summary>
    [ComImport]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("7f73be3f-fb79-493c-a6c7-7ee14e245841")]
    public interface IInitializeWithItem
    {
        /// <summary>
        /// Initializes with ShellItem
        /// </summary>
        /// <param name="shellItem"></param>
        /// <param name="accessMode"></param>
        void Initialize(IShellItem shellItem, AccessModes accessMode);
    }

    [ComImport]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("fc4801a3-2ba9-11cf-a229-00aa003d7352")]
    public interface IObjectWithSite
    {
        void SetSite([In, MarshalAs(UnmanagedType.IUnknown)] object pUnkSite);
        void GetSite(ref Guid riid, [MarshalAs(UnmanagedType.IUnknown)] out object ppvSite);
    }

    [ComImport]
    [Guid("00000114-0000-0000-C000-000000000046")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IOleWindow
    {
        void GetWindow(out IntPtr phwnd);
        void ContextSensitiveHelp([MarshalAs(UnmanagedType.Bool)] bool fEnterMode);
    }

    [ComImport]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("8895b1c6-b41f-4c1c-a562-0d564250836f")]
    public interface IPreviewHandler
    {
        void SetWindow(IntPtr hwnd, ref NativeRect rect);
        void SetRect(ref NativeRect rect);
        void DoPreview();
        void Unload();
        void SetFocus();
        void QueryFocus(out IntPtr phwnd);
        [PreserveSig]
        HResult TranslateAccelerator(ref Message pmsg);
    }

    [ComImport]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("fec87aaf-35f9-447a-adb7-20234491401a")]
    public interface IPreviewHandlerFrame
    {
        void GetWindowContext(IntPtr pinfo);
        [PreserveSig]
        HResult TranslateAccelerator(ref Message pmsg);
    };

    [ComImport]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("8327b13c-b63f-4b24-9b8a-d010dcc3f599")]
    public interface IPreviewHandlerVisuals
    {
        void SetBackgroundColor(NativeColorRef color);
        void SetFont(ref LogFont plf);
        void SetTextColor(NativeColorRef color);
    }
    #endregion

    #region Structs

    /// <summary>
    /// Class for marshaling to native LogFont struct
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public class LogFont
    {
        /// <summary>
        /// Font height
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// Font width
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// Font escapement
        /// </summary>
        public int Escapement { get; set; }

        /// <summary>
        /// Font orientation
        /// </summary>
        public int Orientation { get; set; }

        /// <summary>
        /// Font weight
        /// </summary>
        public int Weight { get; set; }

        /// <summary>
        /// Font italic
        /// </summary>
        public byte Italic { get; set; }

        /// <summary>
        /// Font underline
        /// </summary>
        public byte Underline { get; set; }

        /// <summary>
        /// Font strikeout
        /// </summary>
        public byte Strikeout { get; set; }

        /// <summary>
        /// Font character set
        /// </summary>
        public byte CharacterSet { get; set; }

        /// <summary>
        /// Font out precision
        /// </summary>
        public byte OutPrecision { get; set; }

        /// <summary>
        /// Font clip precision
        /// </summary>
        public byte ClipPrecision { get; set; }

        /// <summary>
        /// Font quality
        /// </summary>
        public byte Quality { get; set; }

        /// <summary>
        /// Font pitch and family
        /// </summary>
        public byte PitchAndFamily { get; set; }

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        private string faceName = string.Empty;

        /// <summary>
        /// Font face name
        /// </summary>
        public string FaceName { get => faceName; set => faceName = value; }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct NativeColorRef
    {
        public uint Dword { get; set; }
    }

    #endregion

    [Flags]
    public enum SetWindowPositionOptions
    {
        AsyncWindowPos = 0x4000,
        DeferErase = 0x2000,
        DrawFrame = FrameChanged,
        FrameChanged = 0x0020,  // The frame changed: send WM_NCCALCSIZE
        HideWindow = 0x0080,
        NoActivate = 0x0010,
        CoCopyBits = 0x0100,
        NoMove = 0x0002,
        NoOwnerZOrder = 0x0200,  // Don't do owner Z ordering
        NoRedraw = 0x0008,
        NoResposition = NoOwnerZOrder,
        NoSendChanging = 0x0400,  // Don't send WM_WINDOWPOSCHANGING
        NoSize = 0x0001,
        NoZOrder = 0x0004,
        ShowWindow = 0x0040
    }

    public enum SetWindowPositionInsertAfter
    {
        NoTopMost = -2,
        TopMost = -1,
        Top = 0,
        Bottom = 1
    }

    public enum GetWindowLong
    {

        WindowProcedure = -4,
        HandleInstance = -6,
        HWndParent = -8,
        Style = -16,
        ExStyle = -20,
        UserData = -21,
        Id = -12,
        User = 0x8,
        MessageResult = 0x0,
        DLGProcedure = 0x4

    }

    public enum SystemCommand
    {

        ContextHelp = 0xF180

    }
}
