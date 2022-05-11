using Microsoft.WindowsAPICodePack.Win32Native;

using System;
using System.Runtime.InteropServices;
using System.Text;

using static System.Runtime.InteropServices.UnmanagedType;

namespace Microsoft.WindowsAPICodePack.COMNative.Shell
{
    [ComImport,
    Guid(NativeAPI.Guids.Shell.IContextMenu),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IContextMenu
    {
        [PreserveSig]
        HResult QueryContextMenu(IntPtr hmenu, [In, MarshalAs(U4)] uint iMenu, [In, MarshalAs(U4)] uint idCmdFirst, [In, MarshalAs(U4)] uint idCmdLast, [In, MarshalAs(U4)] ContextMenuFlags uFlags);

        [PreserveSig]
        HResult InvokeCommand(ref ContextMenuInvokeCommandInfo info);

        [PreserveSig]
        HResult GetCommandString([In, MarshalAs(U4)] uint idcmd, [In, MarshalAs(U4)] GetCommandStringFlags uflags, [In, MarshalAs(U4)] uint reserved, [MarshalAs(LPArray)] byte[] commandstring, [In, MarshalAs(I4)] int cch);
    }

    [ComImport,
    Guid(NativeAPI.Guids.Shell.IContextMenu2),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IContextMenu2
    {
        [PreserveSig]
        HResult QueryContextMenu(IntPtr hmenu, [In, MarshalAs(U4)] uint iMenu, [In, MarshalAs(U4)] uint idCmdFirst, [In, MarshalAs(U4)] uint idCmdLast, [In, MarshalAs(U4)] ContextMenuFlags uFlags);

        [PreserveSig]
        HResult InvokeCommand(ref ContextMenuInvokeCommandInfo info);

        [PreserveSig]
        HResult GetCommandString([In, MarshalAs(U4)] uint idcmd, [In, MarshalAs(U4)] GetCommandStringFlags uflags, [In, MarshalAs(U4)] uint reserved, [MarshalAs(LPWStr)] StringBuilder commandstring, [In, MarshalAs(I4)] int cch);

        [PreserveSig]
        HResult HandleMenuMsg([In, MarshalAs(U4)] uint uMsg, IntPtr wParam, IntPtr lParam);
    }

    [ComImport,
    Guid(NativeAPI.Guids.Shell.IContextMenu3),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IContextMenu3
    {
        [PreserveSig]
        HResult QueryContextMenu(IntPtr hmenu, [In, MarshalAs(U4)] uint iMenu, [In, MarshalAs(U4)] uint idCmdFirst, [In, MarshalAs(U4)] uint idCmdLast, [In, MarshalAs(U4)] ContextMenuFlags uFlags);

        [PreserveSig]
        HResult InvokeCommand(ref ContextMenuInvokeCommandInfo info);

        [PreserveSig]
        HResult GetCommandString([In, MarshalAs(U4)] uint idcmd, [In, MarshalAs(U4)] GetCommandStringFlags uflags, [In, MarshalAs(U4)] uint reserved, [MarshalAs(LPWStr)] StringBuilder commandstring, [In, MarshalAs(I4)] int cch);

        [PreserveSig]
        HResult HandleMenuMsg([In, MarshalAs(U4)] uint uMsg, IntPtr wParam, IntPtr lParam);

        [PreserveSig]
        HResult HandleMenuMsg2([In, MarshalAs(U4)] uint uMsg, IntPtr wParam, IntPtr lParam, IntPtr plResult);
    }
}
