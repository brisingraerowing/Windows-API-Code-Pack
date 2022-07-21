//Copyright (c) Microsoft Corporation.  All rights reserved.  Distributed under the Microsoft Public License (MS-PL)

using Microsoft.WindowsAPICodePack.COMNative.Shell;
using Microsoft.WindowsAPICodePack.COMNative.Shell.PropertySystem;
using Microsoft.WindowsAPICodePack.Win32Native;
using Microsoft.WindowsAPICodePack.Win32Native.Shell;

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

using GuidAttribute = System.Runtime.InteropServices.GuidAttribute;

namespace Microsoft.WindowsAPICodePack.COMNative.Dialogs
{
    // Disable warning if a method declaration hides another inherited from a parent COM interface
    // To successfully import a COM interface, all inherited methods need to be declared again with 
    // the exception of those already declared in "IUnknown"
#pragma warning disable 0108
    [ComImport(),
    Guid(NativeAPI.Guids.Shell.IFileDialog),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IFileDialog : IModalWindow
    {
        // Defined on IModalWindow - repeated here due to requirements of COM interop layer.
        [PreserveSig]
        int Show([In] IntPtr parent);

        // IFileDialog-Specific interface members.

        void SetFileTypes(
            [In] uint cFileTypes,
            [In, MarshalAs(UnmanagedType.LPArray)] FilterSpec[] rgFilterSpec);

        void SetFileTypeIndex([In] uint iFileType);

        void GetFileTypeIndex(out uint piFileType);

        void Advise(
            [In, MarshalAs(UnmanagedType.Interface)] IFileDialogEvents pfde,
            out uint pdwCookie);

        void Unadvise([In] uint dwCookie);

        void SetOptions([In] FileOpenOptions fos);

        void GetOptions(out FileOpenOptions pfos);

        void SetDefaultFolder([In, MarshalAs(UnmanagedType.Interface)] IShellItem psi);

        void SetFolder([In, MarshalAs(UnmanagedType.Interface)] IShellItem psi);

        void GetFolder([MarshalAs(UnmanagedType.Interface)] out IShellItem ppsi);

        void GetCurrentSelection([MarshalAs(UnmanagedType.Interface)] out IShellItem ppsi);

        void SetFileName([In, MarshalAs(UnmanagedType.LPWStr)] string pszName);

        void GetFileName([MarshalAs(UnmanagedType.LPWStr)] out string pszName);

        void SetTitle([In, MarshalAs(UnmanagedType.LPWStr)] string pszTitle);

        void SetOkButtonLabel([In, MarshalAs(UnmanagedType.LPWStr)] string pszText);

        void SetFileNameLabel([In, MarshalAs(UnmanagedType.LPWStr)] string pszLabel);

        void GetResult([MarshalAs(UnmanagedType.Interface)] out IShellItem ppsi);

        void AddPlace([In, MarshalAs(UnmanagedType.Interface)] IShellItem psi, FileDialogAddPlacement fdap);

        void SetDefaultExtension([In, MarshalAs(UnmanagedType.LPWStr)] string pszDefaultExtension);

        void Close([MarshalAs(UnmanagedType.Error)] int hr);

        void SetClientGuid([In] ref Guid guid);

        void ClearClientData();

        // Not supported:  IShellItemFilter is not defined, converting to IntPtr.
        void SetFilter([MarshalAs(UnmanagedType.Interface)] IntPtr pFilter);
    }

    [ComImport(),
    Guid(NativeAPI.Guids.Shell.IFileOpenDialog),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IFileOpenDialog : IFileDialog
    {
        // Defined on IModalWindow - repeated here due to requirements of COM interop layer.
        [PreserveSig]
        int Show([In] IntPtr parent);

        // Defined on IFileDialog - repeated here due to requirements of COM interop layer.
        void SetFileTypes([In] uint cFileTypes, [In] ref FilterSpec rgFilterSpec);

        void SetFileTypeIndex([In] uint iFileType);

        void GetFileTypeIndex(out uint piFileType);

        void Advise(
            [In, MarshalAs(UnmanagedType.Interface)] IFileDialogEvents pfde,
            out uint pdwCookie);

        void Unadvise([In] uint dwCookie);

        void SetOptions([In] FileOpenOptions fos);

        void GetOptions(out FileOpenOptions pfos);

        void SetDefaultFolder([In, MarshalAs(UnmanagedType.Interface)] IShellItem psi);

        void SetFolder([In, MarshalAs(UnmanagedType.Interface)] IShellItem psi);

        void GetFolder([MarshalAs(UnmanagedType.Interface)] out IShellItem ppsi);

        void GetCurrentSelection([MarshalAs(UnmanagedType.Interface)] out IShellItem ppsi);

        void SetFileName([In, MarshalAs(UnmanagedType.LPWStr)] string pszName);

        void GetFileName([MarshalAs(UnmanagedType.LPWStr)] out string pszName);

        void SetTitle([In, MarshalAs(UnmanagedType.LPWStr)] string pszTitle);

        void SetOkButtonLabel([In, MarshalAs(UnmanagedType.LPWStr)] string pszText);

        void SetFileNameLabel([In, MarshalAs(UnmanagedType.LPWStr)] string pszLabel);

        void GetResult([MarshalAs(UnmanagedType.Interface)] out IShellItem ppsi);

        void AddPlace([In, MarshalAs(UnmanagedType.Interface)] IShellItem psi, FileDialogAddPlacement fdap);

        void SetDefaultExtension([In, MarshalAs(UnmanagedType.LPWStr)] string pszDefaultExtension);

        void Close([MarshalAs(UnmanagedType.Error)] int hr);

        void SetClientGuid([In] ref Guid guid);

        void ClearClientData();

        // Not supported:  IShellItemFilter is not defined, converting to IntPtr.
        void SetFilter([MarshalAs(UnmanagedType.Interface)] IntPtr pFilter);

        // Defined by IFileOpenDialog.
        void GetResults([MarshalAs(UnmanagedType.Interface)] out IShellItemArray ppenum);

        void GetSelectedItems([MarshalAs(UnmanagedType.Interface)] out IShellItemArray ppsai);
    }

    [ComImport(),
    Guid(NativeAPI.Guids.Shell.IFileSaveDialog),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IFileSaveDialog : IFileDialog
    {
        // Defined on IModalWindow - repeated here due to requirements of COM interop layer.
        [PreserveSig]
        int Show([In] IntPtr parent);

        // Defined on IFileDialog - repeated here due to requirements of COM interop layer.
        void SetFileTypes(
            [In] uint cFileTypes,
            [In] ref FilterSpec rgFilterSpec);

        void SetFileTypeIndex([In] uint iFileType);

        void GetFileTypeIndex(out uint piFileType);

        void Advise(
            [In, MarshalAs(UnmanagedType.Interface)] IFileDialogEvents pfde,
            out uint pdwCookie);

        void Unadvise([In] uint dwCookie);

        void SetOptions([In] FileOpenOptions fos);

        void GetOptions(out FileOpenOptions pfos);

        void SetDefaultFolder([In, MarshalAs(UnmanagedType.Interface)] IShellItem psi);

        void SetFolder([In, MarshalAs(UnmanagedType.Interface)] IShellItem psi);

        void GetFolder([MarshalAs(UnmanagedType.Interface)] out IShellItem ppsi);

        void GetCurrentSelection([MarshalAs(UnmanagedType.Interface)] out IShellItem ppsi);

        void SetFileName([In, MarshalAs(UnmanagedType.LPWStr)] string pszName);

        void GetFileName([MarshalAs(UnmanagedType.LPWStr)] out string pszName);

        void SetTitle([In, MarshalAs(UnmanagedType.LPWStr)] string pszTitle);

        void SetOkButtonLabel([In, MarshalAs(UnmanagedType.LPWStr)] string pszText);

        void SetFileNameLabel([In, MarshalAs(UnmanagedType.LPWStr)] string pszLabel);

        void GetResult([MarshalAs(UnmanagedType.Interface)] out IShellItem ppsi);

        void AddPlace(
            [In, MarshalAs(UnmanagedType.Interface)] IShellItem psi,
            FileDialogAddPlacement fdap);

        void SetDefaultExtension([In, MarshalAs(UnmanagedType.LPWStr)] string pszDefaultExtension);

        void Close([MarshalAs(UnmanagedType.Error)] int hr);

        void SetClientGuid([In] ref Guid guid);

        void ClearClientData();

        // Not supported:  IShellItemFilter is not defined, converting to IntPtr.
        void SetFilter([MarshalAs(UnmanagedType.Interface)] IntPtr pFilter);

        // Defined by IFileSaveDialog interface.

        void SetSaveAsItem([In, MarshalAs(UnmanagedType.Interface)] IShellItem psi);

        // Not currently supported: IPropertyStore.
        void SetProperties([In, MarshalAs(UnmanagedType.Interface)] IntPtr pStore);

        [PreserveSig]
        int SetCollectedProperties(
            [In] IPropertyDescriptionList pList,
            [In] bool fAppendDefault);

        [PreserveSig]
        HResult GetProperties(out IPropertyStore ppStore);

        // Not currently supported: IPropertyStore, IFileOperationProgressSink.
        void ApplyProperties(
            [In, MarshalAs(UnmanagedType.Interface)] IShellItem psi,
            [In, MarshalAs(UnmanagedType.Interface)] IntPtr pStore,
            [In, ComAliasName("ShellObjects.wireHWND")] ref IntPtr hwnd,
            [In, MarshalAs(UnmanagedType.Interface)] IntPtr pSink);
    }

    [ComImport,
    Guid(NativeAPI.Guids.Shell.IFileDialogEvents),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IFileDialogEvents
    {
        // NOTE: some of these callbacks are cancelable - returning S_FALSE means that 
        // the dialog should not proceed (e.g. with closing, changing folder); to 
        // support this, we need to use the PreserveSig attribute to enable us to return
        // the proper HRESULT.

        [        PreserveSig]
        HResult OnFileOk([In, MarshalAs(UnmanagedType.Interface)] IFileDialog pfd);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime),
        PreserveSig]
        HResult OnFolderChanging(
            [In, MarshalAs(UnmanagedType.Interface)] IFileDialog pfd,
            [In, MarshalAs(UnmanagedType.Interface)] IShellItem psiFolder);

        void OnFolderChange([In, MarshalAs(UnmanagedType.Interface)] IFileDialog pfd);

        void OnSelectionChange([In, MarshalAs(UnmanagedType.Interface)] IFileDialog pfd);

        void OnShareViolation(
            [In, MarshalAs(UnmanagedType.Interface)] IFileDialog pfd,
            [In, MarshalAs(UnmanagedType.Interface)] IShellItem psi,
            out FileDialogEventShareViolationResponse pResponse);

        void OnTypeChange([In, MarshalAs(UnmanagedType.Interface)] IFileDialog pfd);

        void OnOverwrite([In, MarshalAs(UnmanagedType.Interface)] IFileDialog pfd,
            [In, MarshalAs(UnmanagedType.Interface)] IShellItem psi,
            out FileDialogEventOverwriteResponse pResponse);
    }

    [ComImport,
    Guid(NativeAPI.Guids.Shell.IFileDialogCustomize),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IFileDialogCustomize
    {
        void EnableOpenDropDown([In] int dwIDCtl);

        void AddMenu(
            [In] int dwIDCtl,
            [In, MarshalAs(UnmanagedType.LPWStr)] string pszLabel);

        void AddPushButton(
            [In] int dwIDCtl,
            [In, MarshalAs(UnmanagedType.LPWStr)] string pszLabel);

        void AddComboBox([In] int dwIDCtl);

        void AddRadioButtonList([In] int dwIDCtl);

        void AddCheckButton(
            [In] int dwIDCtl,
            [In, MarshalAs(UnmanagedType.LPWStr)] string pszLabel,
            [In] bool bChecked);

        void AddEditBox(
            [In] int dwIDCtl,
            [In, MarshalAs(UnmanagedType.LPWStr)] string pszText);

        void AddSeparator([In] int dwIDCtl);

        void AddText(
            [In] int dwIDCtl,
            [In, MarshalAs(UnmanagedType.LPWStr)] string pszText);

        void SetControlLabel(
            [In] int dwIDCtl,
            [In, MarshalAs(UnmanagedType.LPWStr)] string pszLabel);

        void GetControlState(
            [In] int dwIDCtl,
            [Out] out ControlState pdwState);

        void SetControlState(
            [In] int dwIDCtl,
            [In] ControlState dwState);

        void GetEditBoxText(
            [In] int dwIDCtl,
            [MarshalAs(UnmanagedType.LPWStr)] out string ppszText);

        void SetEditBoxText(
            [In] int dwIDCtl,
            [In, MarshalAs(UnmanagedType.LPWStr)] string pszText);

        void GetCheckButtonState(
            [In] int dwIDCtl,
            [Out] out bool pbChecked);

        void SetCheckButtonState(
            [In] int dwIDCtl,
            [In] bool bChecked);

        void AddControlItem(
            [In] int dwIDCtl,
            [In] int dwIDItem,
            [In, MarshalAs(UnmanagedType.LPWStr)] string pszLabel);

        void RemoveControlItem(
            [In] int dwIDCtl,
            [In] int dwIDItem);

        void RemoveAllControlItems([In] int dwIDCtl);

        void GetControlItemState(
            [In] int dwIDCtl,
            [In] int dwIDItem,
            [Out] out ControlState pdwState);

        void SetControlItemState(
            [In] int dwIDCtl,
            [In] int dwIDItem,
            [In] ControlState dwState);

        void GetSelectedControlItem(
            [In] int dwIDCtl,
            [Out] out int pdwIDItem);

        void SetSelectedControlItem(
            [In] int dwIDCtl,
            [In] int dwIDItem); // Not valid for OpenDropDown.

        void StartVisualGroup(
            [In] int dwIDCtl,
            [In, MarshalAs(UnmanagedType.LPWStr)] string pszLabel);

        void EndVisualGroup();

        void MakeProminent([In] int dwIDCtl);
    }

    [ComImport,
    Guid(NativeAPI.Guids.Shell.IFileDialogControlEvents),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IFileDialogControlEvents
    {
        void OnItemSelected(
            [In, MarshalAs(UnmanagedType.Interface)] IFileDialogCustomize pfdc,
            [In] int dwIDCtl,
            [In] int dwIDItem);

        void OnButtonClicked(
            [In, MarshalAs(UnmanagedType.Interface)] IFileDialogCustomize pfdc,
            [In] int dwIDCtl);

        void OnCheckButtonToggled(
            [In, MarshalAs(UnmanagedType.Interface)] IFileDialogCustomize pfdc,
            [In] int dwIDCtl,
            [In] bool bChecked);

        void OnControlActivating(
            [In, MarshalAs(UnmanagedType.Interface)] IFileDialogCustomize pfdc,
            [In] int dwIDCtl);
    }
    // Restore the warning
#pragma warning restore 0108
}
