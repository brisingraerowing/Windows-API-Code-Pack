using Microsoft.WindowsAPICodePack.NativeAPI.Consts;

using System;
using System.Runtime.InteropServices;

using static System.Runtime.InteropServices.UnmanagedType;

namespace Microsoft.WindowsAPICodePack.Win32Native.Shell.WindowsAndMessages
{
    public enum WindowHook
    {
        Min = (-1),
        MsgFilter = (-1),
        JournalRecord = 0,
        JournalPlayback = 1,
        Keyboard = 2,
        GetMessage = 3,
        CallWndProc = 4,
        CBT = 5,
        SysMsgFilter = 6,
        Mouse = 7,
        Hardware = 8,
        Debug = 9,
        Shell = 10,
        ForegroundIDLE = 11,
        CallWndProcRet = 12,

        KeyboardLL = 13,
        MouseLL = 14,

        Max = 14,

        MinHook = Min,
        MaxHook = Max
    }

    public delegate IntPtr HookProc([MarshalAs(I4)] int code, UIntPtr wParam, IntPtr lParam);

    class WindowsAndMessages
    {
        [DllImport(DllNames.User32, CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern IntPtr SetWindowsHookExW([In, MarshalAs(I4)] WindowHook idHook, [In] HookProc lpfn, [In] IntPtr hmod, [In, MarshalAs(U4)] uint dwThreadId);

        [DllImport(DllNames.User32)]
        public static extern IntPtr CallNextHookEx([In] IntPtr hhk, [In] int nCode, [In] UIntPtr wParam, [In] IntPtr lParam);
    }
}
