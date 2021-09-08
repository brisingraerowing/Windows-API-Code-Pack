using Microsoft.WindowsAPICodePack.Win32Native;

using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;

using static System.Runtime.InteropServices.UnmanagedType;

namespace Microsoft.WindowsAPICodePack.COMNative.Shell
{
    [Flags]
    public enum ContextMenuFlags : uint
    {
        Normal = 0x00000000,
        DefaultOnly = 0x00000001,
        VerbsOnly = 0x00000002,
        Explore = 0x00000004,
        NoVerbs = 0x00000008,
        CanRename = 0x00000010,
        NoDefault = 0x00000020,
        ItemMenu = 0x00000080,
        ExtendedVerbs = 0x00000100,
        DisabledVerbs = 0x00000200,
        AsyncVerbState = 0x00000400,
        OptimizeForInvoke = 0x00000800,
        SyncCascadeMenu = 0x00001000,
        DoNotPickDefault = 0x00002000,
        Reserved = 0xffff0000
    }

    public enum SeeMask
    {
        Default = 0x00000000,
        ClassName = 0x00000001,  // SHELLEXECUTEINFO.lpClass is valid
        ClassKey = 0x00000003, // SHELLEXECUTEINFO.hkeyClass is valid

        IDList = 0x00000004, // SHELLEXECUTEINFO.lpIDList is valid
        InvokeIDList = 0x0000000c, // enable IContextMenu based verbs
        HotKey = 0x00000020, // SHELLEXECUTEINFO.dwHotKey is valid
        NoCloseProcess = 0x00000040, // SHELLEXECUTEINFO.hProcess
        ConnectNetDrv = 0x00000080, // enables re-connecting disconnected network drives
        NoAsync = 0x00000100, // block on the call until the invoke has completed, use for callers that exit after calling ShellExecuteEx()
        FlagDDEWait = NoAsync,  // Use SEE_MASK_NOASYNC instead of SEE_MASK_FLAG_DDEWAIT as it more accuratly describes the behavior
        DOENVSUBST = 0x00000200, // indicates that SHELLEXECUTEINFO.lpFile contains env vars that should be expanded
        FlagNoUI = 0x00000400, // disable UI including error messages
        Unicode = 0x00004000,
        NoConsole = 0x00008000,
        AsyncOK = 0x00100000,
        HMonitor = 0x00200000, // SHELLEXECUTEINFO.hMonitor
        NoZoneChecks = 0x00800000,
        NoQueryClassStore = 0x01000000,
        WaitForInputIDLE = 0x02000000,
        FlagLogUsage = 0x04000000,

        // When SEE_MASK_FLAG_HINST_IS_SITE is specified SHELLEXECUTEINFO.hInstApp is used as an
        // _In_ parameter and specifies a IUnknown* to be used as a site pointer. The site pointer
        // is used to provide services to shell execute, the handler binding process and the verb handlers
        // once they are invoked.
        FlagHInstIsSite = 0x08000000
    }

    [Flags]
    public enum ContextMenuInvokeCommandFlags : uint
    {
        HotKey = SeeMask.HotKey,
        // Icon          = SeeMask.Icon,
        FlagNoUI = SeeMask.FlagNoUI,
        Unicode = SeeMask.Unicode,
        NoConsole = SeeMask.NoConsole,
        AsyncOK = SeeMask.AsyncOK,
        NoAsync = SeeMask.NoAsync,
        ShiftDown = 0x10000000,
        ControlDown = 0x40000000,
        FlagLogUsage = SeeMask.FlagLogUsage,
        NoZoneChecks = SeeMask.NoZoneChecks,
        PtInvoke = 0x20000000
    }

    public struct ContextMenuInvokeCommandInfo
    {
        [MarshalAs(U4)]
        public uint cbSize;

        [MarshalAs(U4)]
        public ContextMenuInvokeCommandFlags fMask;

        public IntPtr hwnd;

        public IntPtr lpVerb;

        [MarshalAs(LPStr)]
        public string lpParameters;

        [MarshalAs(LPStr)]
        public string lpDirectory;

        [MarshalAs(I4)]
        public ShowWindowCommands nShow;

        [MarshalAs(U4)]
        public uint dwHotKey;

        public IntPtr hIcon;

        [MarshalAs(LPStr)]
        public string lpTitle;

        public IntPtr lpVerbW;

        [MarshalAs(LPWStr)]
        public string lpParametersW;

        [MarshalAs(LPWStr)]
        public string lpDirectoryW;

        [MarshalAs(LPWStr)]
        public string lpTitleW;

        public Point ptInvoke;
    }

    public enum GetCommandStringFlags : uint
    {
        VerbA = 0x00000000,// canonical verb
        HelpTextA = 0x00000001,// help text (for status bar)
        ValidateA = 0x00000002,// validate command exists
        VerbW = 0x00000004, // canonical verb (unicode)
        HelpTextW = 0x00000005,  // help text (unicode version)
        ValidateW = 0x00000006,   // validate command exists (unicode)
        VerbIconW = 0x00000014,    // icon string (unicode)
        Unicode = 0x00000004,     // for bit testing - Unicode string

        Verb = VerbW,
        HelpText = HelpTextW,
        Validate = ValidateW
    }

    [ComImport]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("000214e4-0000-0000-c000-000000000046")]
    public  interface IContextMenu
    {
        [PreserveSig]
        HResult QueryContextMenu(IntPtr hmenu, uint iMenu, uint idCmdFirst, uint idCmdLast, ContextMenuFlags uFlags);

        [PreserveSig]
        HResult InvokeCommand(ref ContextMenuInvokeCommandInfo info);

        [PreserveSig]
        HResult GetCommandString(uint idcmd, GetCommandStringFlags uflags, uint reserved, [MarshalAs(UnmanagedType.LPArray)] byte[] commandstring, int cch);
    }

    [ComImport, Guid("000214f4-0000-0000-c000-000000000046")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IContextMenu2
    {
        [PreserveSig]
        HResult QueryContextMenu(IntPtr hmenu, uint iMenu, uint idCmdFirst, uint idCmdLast, ContextMenuFlags uFlags);

        [PreserveSig]
        HResult InvokeCommand(ref ContextMenuInvokeCommandInfo info);

        [PreserveSig]
        HResult GetCommandString(uint idcmd, GetCommandStringFlags uflags, uint reserved, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder commandstring, int cch);

        [PreserveSig]
        HResult HandleMenuMsg(uint uMsg, IntPtr wParam, IntPtr lParam);
    }

    [ComImport, Guid("bcfce0a0-ec17-11d0-8d10-00a0c90f2719")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IContextMenu3
    {
        [PreserveSig]
        HResult QueryContextMenu(IntPtr hmenu, uint iMenu, uint idCmdFirst, uint idCmdLast, ContextMenuFlags uFlags);

        [PreserveSig]
        HResult InvokeCommand(ref ContextMenuInvokeCommandInfo info);

        [PreserveSig]
        HResult GetCommandString(uint idcmd, GetCommandStringFlags uflags, uint reserved, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder commandstring, int cch);

        [PreserveSig]
        HResult HandleMenuMsg(uint uMsg, IntPtr wParam, IntPtr lParam);

        [PreserveSig]
        HResult HandleMenuMsg2(uint uMsg, IntPtr wParam, IntPtr lParam, IntPtr plResult);
    }
}
