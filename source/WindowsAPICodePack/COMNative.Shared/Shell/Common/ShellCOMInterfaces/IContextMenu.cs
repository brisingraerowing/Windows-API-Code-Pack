using Microsoft.WindowsAPICodePack.Win32Native;

using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Microsoft.WindowsAPICodePack.COMNative.Shell
{
    [ComImport,
    Guid(NativeAPI.Guids.Shell.IContextMenu),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IContextMenu
    {
        [PreserveSig]
        HResult QueryContextMenu(IntPtr hmenu, uint iMenu, uint idCmdFirst, uint idCmdLast, ContextMenuFlags uFlags);

        [PreserveSig]
        HResult InvokeCommand(ref ContextMenuInvokeCommandInfo info);

        [PreserveSig]
        HResult GetCommandString(uint idcmd, GetCommandStringFlags uflags, uint reserved, [MarshalAs(UnmanagedType.LPArray)] byte[] commandstring, int cch);
    }

    [ComImport,
    Guid(NativeAPI.Guids.Shell.IContextMenu2),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
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

    [ComImport,
    Guid(NativeAPI.Guids.Shell.IContextMenu3),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
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
