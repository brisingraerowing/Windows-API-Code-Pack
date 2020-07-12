//Copyright (c) Microsoft Corporation.  All rights reserved.  Distributed under the Microsoft Public License (MS-PL)

using System;
using System.Runtime.InteropServices;
using Microsoft.WindowsAPICodePack.COMNative;
using Microsoft.WindowsAPICodePack.COMNative.COM;
using Microsoft.WindowsAPICodePack.Win32Native;
using Microsoft.WindowsAPICodePack.Win32Native.Taskbar;

namespace Microsoft.WindowsAPICodePack.COMNative.Taskbar
{
    [ComImport()]
    [Guid(Win32Native.Guids.Taskbar.ICustomDestinationList)]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICustomDestinationList
    {
        void SetAppID(
            [MarshalAs(UnmanagedType.LPWStr)] string pszAppID);
        [PreserveSig]
        HResult BeginList(
            out uint cMaxSlots,
            ref Guid riid,
            [Out(), MarshalAs(UnmanagedType.Interface)] out object ppvObject);
        [PreserveSig]
        HResult AppendCategory(
            [MarshalAs(UnmanagedType.LPWStr)] string pszCategory,
            [MarshalAs(UnmanagedType.Interface)] IObjectArray poa);
        void AppendKnownCategory(
            [MarshalAs(UnmanagedType.I4)] KnownDestinationCategory category);
        [PreserveSig]
        HResult AddUserTasks(
            [MarshalAs(UnmanagedType.Interface)] IObjectArray poa);
        void CommitList();
        void GetRemovedDestinations(
            ref Guid riid,
            [Out(), MarshalAs(UnmanagedType.Interface)] out object ppvObject);
        void DeleteList(
            [MarshalAs(UnmanagedType.LPWStr)] string pszAppID);
        void AbortList();
    }

    [Guid(Win32Native.Guids.Taskbar.CDestinationList)]
    [ClassInterface(ClassInterfaceType.None)]
    [ComImport()]
    public class CDestinationList { }

    [ComImport()]
    [Guid(Win32Native.Guids.Taskbar.ITaskbarList)]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ITaskbarList
    {
        [PreserveSig]
        void HrInit();
        [PreserveSig]
        void AddTab(IntPtr hwnd);
        [PreserveSig]
        void DeleteTab(IntPtr hwnd);
        [PreserveSig]
        void ActivateTab(IntPtr hwnd);
        [PreserveSig]
        void SetActiveAlt(IntPtr hwnd);
    }

    [ComImport()]
    [Guid(Win32Native.Guids.Taskbar.ITaskbarList2)]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ITaskbarList2: ITaskbarList
    {
        [PreserveSig]
        void MarkFullscreenWindow(
                IntPtr hwnd,
                [MarshalAs(UnmanagedType.Bool)] bool fFullscreen);
    }

    [ComImport()]
    [Guid(Win32Native.Guids.Taskbar.ITaskbarList3)]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ITaskbarList3: ITaskbarList2
    {
        [PreserveSig]
        void SetProgressValue(IntPtr hwnd, ulong ullCompleted, ulong ullTotal);
        [PreserveSig]
        void SetProgressState(IntPtr hwnd, TaskbarProgressBarStatus tbpFlags);
        [PreserveSig]
        void RegisterTab(IntPtr hwndTab, IntPtr hwndMDI);
        [PreserveSig]
        void UnregisterTab(IntPtr hwndTab);
        [PreserveSig]
        void SetTabOrder(IntPtr hwndTab, IntPtr hwndInsertBefore);
        [PreserveSig]
        void SetTabActive(IntPtr hwndTab, IntPtr hwndInsertBefore, uint dwReserved);
        [PreserveSig]
        HResult ThumbBarAddButtons(
            IntPtr hwnd,
            uint cButtons,
            [MarshalAs(UnmanagedType.LPArray)] ThumbButton[] pButtons);
        [PreserveSig]
        HResult ThumbBarUpdateButtons(
            IntPtr hwnd,
            uint cButtons,
            [MarshalAs(UnmanagedType.LPArray)] ThumbButton[] pButtons);
        [PreserveSig]
        void ThumbBarSetImageList(IntPtr hwnd, IntPtr himl);
        [PreserveSig]
        void SetOverlayIcon(
          IntPtr hwnd,
          IntPtr hIcon,
          [MarshalAs(UnmanagedType.LPWStr)] string pszDescription);
        [PreserveSig]
        void SetThumbnailTooltip(
            IntPtr hwnd,
            [MarshalAs(UnmanagedType.LPWStr)] string pszTip);
        [PreserveSig]
        void SetThumbnailClip(
            IntPtr hwnd,
            IntPtr prcClip);
    }

    [ComImport()]
    [Guid(Win32Native.Guids.Taskbar.ITaskbarList4)]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ITaskbarList4: ITaskbarList3
    { 
    void SetTabProperties(IntPtr hwndTab, SetTabPropertiesOption stpFlags);
    }

    [Guid(Win32Native.Guids.Taskbar.CTaskbarList)]
    [ClassInterface(ClassInterfaceType.None)]
    [ComImport()]
    public class CTaskbarList { }
}
