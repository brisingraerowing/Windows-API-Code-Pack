using Microsoft.WindowsAPICodePack.NativeAPI.Consts;

using System;
using System.Runtime.InteropServices;

using static System.Runtime.InteropServices.UnmanagedType;

namespace Microsoft.WindowsAPICodePack.Win32Native.Shell.WindowsAccessibilityFeatures
{
    public enum Event : uint
    {
        Min = 0x00000001,

        Max = 0x7FFFFFFF,

        SystemSound = 0x0001,

        SystemAlert = 0x0002,

        SystemForeground = 0x0003,

        SystemMenuStart = 0x0004,

        SystemMenuEnd = 0x0005,

        SystemMenuPopupStart = 0x0006,

        SystemMenuPopupEnd = 0x0007,

        SystemCaptureStart = 0x0008,

        SystemCaptureEnd = 0x0009,

        SystemMoveSizeStart = 0x000A,

        SystemMoveSizeEnd = 0x000B,

        SystemContextHelpStart = 0x000C,

        SystemContextHelpEnd = 0x000D,

        SystemDragDropStart = 0x000E,

        SystemDragDropEnd = 0x000F,

        SystemDialogStart = 0x0010,

        SystemDialogEnd = 0x0011,

        SystemScrollingStart = 0x0012,

        SystemScrollingEnd = 0x0013,

        SystemSwitchStart = 0x0014,

        SystemSwitchEnd = 0x0015,

        SystemMinimizeStart = 0x0016,

        SystemMinimizeEnd = 0x0017,

        SystemDesktopSwitch = 0x0020,

        SystemSwitcherAppGrabbed = 0x0024,

        SystemSwitcherAppOverTarget = 0x0025,

        SystemSwitcherAppDropped = 0x0026,

        SystemSwitcherCancelled = 0x0027,

        SystemIMEKeyNotification = 0x0029,

        SystemEnd = 0x00FF,

        OEMDefinedStart = 0x0101,
        OEMDefinedEnd = 0x01FF,

        UIAEventIDStart = 0x4E00,
        UIAEventIDEnd = 0x4EFF,

        UIAPropIDStart = 0x7500,
        UIAPropIDEnd = 0x75ff,

        ConsoleCaret = 0x4001,
        ConsoleUpdateRegion = 0x4002,
        ConsoleUpdateSimple = 0x4003,
        ConsoleUpdateScroll = 0x4004,
        ConsoleLayout = 0x4005,
        ConsoleStartApplication = 0x4006,
        ConsoleEndApplication = 0x4007,

        ConsoleEnd = 0x40ff,

        ObjectCreate = 0x8000,

        ObjectDestroy = 0x8001,

        ObjectShow = 0x8002,

        ObjectHide = 0x8003,

        ObjectReorder = 0x8004,

        ObjectFocus = 0x8005,

        ObjectSelection = 0x8006,

        ObjectSelectionAdd = 0x8007,

        ObjectSelectionRemove = 0x8008,

        ObjectSelectionWithin = 0x8009,

        ObjectStateChange = 0x800a,

        ObjectLocationChange = 0x800b,

        ObjectNameChange = 0x800c,
        ObjectDescriptionChange = 0x800d,
        ObjectValueChange = 0x800e,
        ObjectParentChange = 0x800f,
        ObjectHelpChange = 0x8010,
        ObjectDefactionChange = 0x8011,
        ObjectAcceleratorChange = 0x8012,

        ObjectInvoked = 0x8013,
        ObjectTextSelectionChanged = 0x8014,
        ObjectContentScrolled = 0x8015,

        SystemArrangmentPreview = 0x8016,

        ObjectCloaked = 0x8017,
        ObjectUncloaked = 0x8018,

        ObjectLiveregionChanged = 0x8019,

        ObjectHostedObjectsInvalidated = 0x8020,

        ObjectDragStart = 0x8021,
        ObjectDragCancel = 0x8022,
        ObjectDragComplete = 0x8023,

        ObjectDragEnter = 0x8024,
        ObjectDragLeave = 0x8025,
        ObjectDragDropped = 0x8026,

        ObjectIMEShow = 0x8027,
        ObjectIMEHide = 0x8028,

        ObjectIMEChange = 0x8029,

        ObjectTextEditConversionTargetChanged = 0x8030,

        ObjectEnd = 0x80ff,

        AIAStart = 0xa000,
        AIAEnd = 0xafff
    }

    [Flags]
    public enum Events : uint
    {
        OutOfContext = 0x0000,
        SkipOwnThread = 0x0001,
        SkipOwnProcess = 0x0002,
        InContext = 0x0004
    }

    public delegate void WinEventProc(IntPtr hWinEventHook, [MarshalAs(U4)] Event @event, IntPtr hwnd, [MarshalAs(I4)] int idObject, [MarshalAs(I4)] int idChild, [MarshalAs(U4)] uint idEventThread, [MarshalAs(U4)] uint dwmsEventTime);

    public static class WindowsAccessibilityFeatures
    {
        [DllImport(DllNames.User32)]
        public static extern IntPtr SetWinEventHook([In, MarshalAs(U4)] Event eventMin, [In, MarshalAs(U4)] Event eventMax, [In] IntPtr hmodWinEventProc, [In] WinEventProc pfnWinEventProc, [In, MarshalAs(U4)] uint idProcess, [In, MarshalAs(U4)] uint idThread, [In, MarshalAs(U4)] Events dwFlags);

        [DllImport(DllNames.User32)]
        [return: MarshalAs(Bool)]
        public static extern bool UnhookWinEvent([In] IntPtr hWinEventHook);
    }
}
