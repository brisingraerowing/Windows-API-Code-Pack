//Copyright (c) Microsoft Corporation.  All rights reserved.

using System;
using System.Runtime.InteropServices;
using Microsoft.WindowsAPICodePack.Win32Native;
using Microsoft.WindowsAPICodePack.Win32Native.COM;

namespace Microsoft.WindowsAPICodePack.Win32Native.Taskbar
{
    [ComImport()]
    [Guid(Guids.Taskbar.ICustomDestinationList)]
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

    [Guid(Guids.Taskbar.CDestinationList)]
    [ClassInterface(ClassInterfaceType.None)]
    [ComImport()]
    public class CDestinationList { }

    [Guid(Guids.Taskbar.CEnumerableObjectCollection)]
    [ClassInterface(ClassInterfaceType.None)]
    [ComImport()]
    public class CEnumerableObjectCollection { }

    [ComImport()]
    [Guid(Guids.Taskbar.ITaskbarList)]
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
    [Guid(Guids.Taskbar.ITaskbarList2)]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ITaskbarList2: ITaskbarList
    {
        [PreserveSig]
        void MarkFullscreenWindow(
                IntPtr hwnd,
                [MarshalAs(UnmanagedType.Bool)] bool fFullscreen);
    }

    [ComImport()]
    [Guid(Guids.Taskbar.ITaskbarList3)]
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
    [Guid(Guids.Taskbar.ITaskbarList4)]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ITaskbarList4: ITaskbarList3
    { 
    void SetTabProperties(IntPtr hwndTab, SetTabPropertiesOption stpFlags);
    }

    [Guid(Guids.Taskbar.CTaskbarList)]
    [ClassInterface(ClassInterfaceType.None)]
    [ComImport()]
    public class CTaskbarList { }
}
