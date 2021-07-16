//Copyright (c) Microsoft Corporation.  All rights reserved.  Distributed under the Microsoft Public License (MS-PL)

using Microsoft.WindowsAPICodePack.COMNative.Shell.PropertySystem;
using Microsoft.WindowsAPICodePack.Win32Native;
using Microsoft.WindowsAPICodePack.Win32Native.Shell;

using System;
using System.Runtime.InteropServices;

namespace Microsoft.WindowsAPICodePack.COMNative.Shell
{
    // todo: add a class to encapsulate this interface into the 'Shell' project and check, on the method calls, if all of the enum params are supported by the current version of the OS.

    [ComImport,
       Guid(NativeAPI.Guids.Shell.IFileOperation),
       InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IFileOperation
    {
        /// <summary>
        /// Enables a handler to provide status and error information for all operations.
        /// </summary>
        /// <param name="pfops">An <see cref="IFileOperationProgressSink"/> object to be used for progress status and error notifications.</param>
        /// <param name="pdwCookie">When this method returns, this parameter points to a returned token that uniquely identifies this connection. The calling application uses this token later to delete the connection by passing it to <see cref="Unadvise"/>. If the call to <see cref="Advise"/> fails, this value is meaningless.</param>
        /// <returns>If this method succeeds, it returns <see cref="HResult.Ok"/>. Otherwise, it returns an <see cref="HResult"/> error code.</returns>
        /// <remarks>Several individual methods have the ability to declare their own progress sinks, which are redundant to the one set here. They are used when you only want to be given progress and error information for a specific operation.</remarks>
        HResult Advise(IFileOperationProgressSink pfops, out uint pdwCookie);

        /// <summary>
        /// Terminates an advisory connection previously established through <see cref="Advise"/>.
        /// </summary>
        /// <param name="dwCookie">The connection token that identifies the connection to delete. This value was originally retrieved by <see cref="Advise"/> when the connection was made.</param>
        /// <returns>Any value other than those listed here indicate a failure.
        /// | Return code              | Description                                                  |
        /// |--------------------------+--------------------------------------------------------------|
        /// | <see cref="HResult.Ok"/> | The connection was terminated successfully.                  |
        /// | CONNECT_E_NOCONNECTION   | The value in dwCookie does not represent a valid connection. |</returns>
        HResult Unadvise(uint dwCookie);

        /// <summary>
        /// Sets parameters for the current operation.
        /// </summary>
        /// <param name="dwOperationFlags">Flags that control the file operation. FOF flags are defined in Shellapi.h and FOFX flags are defined in Shobjidl.h. Note : If this method is not called, the default value used by the operation is <see cref=" ShellOperationFlags.FOF_ALLOWUNDO"/> | <see cref="ShellOperationFlags.FOF_NOCONFIRMMKDIR"/>.</param>
        /// <returns>If this method succeeds, it returns <see cref="HResult.Ok"/>. Otherwise, it returns an <see cref="HResult"/> error code.</returns>
        /// <remarks>Set these flags before you call <see cref="PerformOperations"/> to define the parameters for whatever operations are being performed, such as copy, delete, or rename.</remarks>
        HResult SetOperationFlags(ShellOperationFlags dwOperationFlags);

        /// <summary>
        /// Not implemented.
        /// </summary>
        /// <param name="pszMessage">The window title.</param>
        /// <returns>If this method succeeds, it returns <see cref="HResult.Ok"/>. Otherwise, it returns an <see cref="HResult"/> error code.</returns>
        HResult SetProgressMessage([MarshalAs(UnmanagedType.LPWStr)] string pszMessage);

        /// <summary>
        /// Specifies a dialog box used to display the progress of the operation.
        /// </summary>
        /// <param name="popd">An <see cref="IOperationsProgressDialog"/> object that represents the dialog box.</param>
        /// <returns>If this method succeeds, it returns <see cref="HResult.Ok"/>. Otherwise, it returns an <see cref="HResult"/> error code.</returns>
        HResult SetProgressDialog(IOperationsProgressDialog popd);

        /// <summary>
        /// Declares a set of properties and values to be set on an item or items.
        /// </summary>
        /// <param name="pproparray">An <see cref="IPropertyChangeArray"/>, which accesses a collection of <see cref="IPropertyChange"/> objects that specify the properties to be set and their new values.</param>
        /// <returns>If this method succeeds, it returns <see cref="HResult.Ok"/>. Otherwise, it returns an <see cref="HResult"/> error code.</returns>
        /// <remarks>This method does not set the new property values, it merely declares them. To set property values on an item or a group of items, you must make at least the sequence of calls detailed here:
        /// <ol><li>Call <see cref="SetProperties"/> to declare the specific properties to be set and their new values.</li>
        /// <li>Call <see cref="ApplyPropertiesToItem"/> or <see cref="ApplyPropertiesToItems"/> to declare the item or items whose properties are to be set.</li>
        /// <li>Call <see cref="PerformOperations"/> to apply the properties to the item or items.</li></ol></remarks>
        HResult SetProperties(IPropertyChangeArray pproparray);

        /// <summary>
        /// Sets the parent or owner window for progress and dialog windows.
        /// </summary>
        /// <param name="hwndOwner">A handle to the owner window of the operation. This window will receive error messages.</param>
        /// <returns>If this method succeeds, it returns <see cref="HResult.Ok"/>. Otherwise, it returns an <see cref="HResult"/> error code.</returns>
        HResult SetOwnerWindow(IntPtr hwndOwner);

        /// <summary>
        /// Declares a single item whose property values are to be set.
        /// </summary>
        /// <param name="psiItem">Pointer to the item to receive the new property values.</param>
        /// <returns>If this method succeeds, it returns <see cref="HResult.Ok"/>. Otherwise, it returns an <see cref="HResult"/> error code.</returns>
        /// <remarks>This method does not apply the properties to the item, it merely declares the item. To set property values on an item, you must make at least the sequence of calls detailed here:
        /// <ol><li>Call <see cref="SetProperties"/> to declare the specific properties to be set and their new values.</li>
        /// <li>Call <see cref="ApplyPropertiesToItem"/> to declare the item whose properties are to be set.</li>
        /// <li>Call <see cref="PerformOperations"/> to apply the properties to the item.</li></ol></remarks>
        HResult ApplyPropertiesToItem(IShellItem psiItem);

        /// <summary>
        /// Declares a set of items for which to apply a common set of property values.
        /// </summary>
        /// <param name="punkItems">Pointer to the IUnknown of the <see cref="IShellItemArray"/>, <see cref="IDataObject"/>, or <see cref="IEnumShellItems"/> object which represents the group of items. You can also point to an <see cref="IPersistIDList"/> object to represent a single item, effectively accomplishing the same function as <see cref="ApplyPropertiesToItem"/>.</param>
        /// <returns>If this method succeeds, it returns S_OK. Otherwise, it returns an <see cref="HResult"/> error code.</returns>
        /// <remarks>This method does not apply the properties to the items, it merely declares the items. To set property values on a group of items, you must make at least the sequence of calls detailed here:
        /// <ol><li>Call <see cref="SetProperties"/> to declare the specific properties to be set and their new values.</li>
        /// <li>Call <see cref="ApplyPropertiesToItems"/> to declare the items whose property values are to be set.</li>
        /// <li>Call <see cref="PerformOperations"/> to apply the properties to the items.</li></ol></remarks>
        HResult ApplyPropertiesToItems([MarshalAs(UnmanagedType.Interface)] object punkItems);

        /// <summary>
        /// Declares a single item that is to be given a new display name.
        /// </summary>
        /// <param name="psiItem">Pointer to an <see cref="IShellItem"/> that specifies the source item.</param>
        /// <param name="pszNewName">Pointer to the new <a href="https://msdn.microsoft.com/9b159be9-3797-4c8b-90f8-9d3b3a3afb71">display name</a> of the item. This is a null-terminated, Unicode string.</param>
        /// <param name="pfopsItem">Pointer to an <see cref="IFileOperationProgressSink"/> object to be used for status and failure notifications. If you call <see cref="Advise"/> for the overall operation, progress status and error notifications for the rename operation are included there, so set this parameter to <see langword="null"/>.</param>
        /// <returns>If this method succeeds, it returns <see cref="HResult.Ok"/>. Otherwise, it returns an <see cref="HResult"/> error code.</returns>
        /// <remarks>This method does not rename the item, it merely declares the item to be renamed. To rename an object, you must make at least the sequence of calls detailed here:
        /// <ol><li>Call <see cref="RenameItem"/> to declare the new name.</li>
        /// <li>Call <see cref="PerformOperations"/> to begin the rename operation.</li></ol></remarks>
        HResult RenameItem(IShellItem psiItem, [MarshalAs(UnmanagedType.LPWStr)] string pszNewName, [MarshalAs(UnmanagedType.LPWStr)] IFileOperationProgressSink pfopsItem);

        /// <summary>
        /// Declares a set of items that are to be given a new display name. All items are given the same name.
        /// </summary>
        /// <param name="pUnkItems">Pointer to the <see cref="UnmanagedType.IUnknown"/> of the <see cref="IShellItemArray"/>, <see cref="IDataObject"/>, or <see cref="IEnumShellItems"/> object which represents the group of items to be renamed. You can also point to an <see cref="IPersistIDList"/> object to represent a single item, effectively accomplishing the same function as <see cref="RenameItem"/>.</param>
        /// <param name="pszNewName">Pointer to the new display name of the items. This is a null-terminated, Unicode string.</param>
        /// <returns>If this method succeeds, it returns <see cref="HResult.Ok"/>. Otherwise, it returns an <see cref="HResult"/> error code.</returns>
        /// <remarks><para>If more than one of the items in the collection at pUnkItems is in the same folder, the renamed files are appended with a number in parentheses to differentiate them, for instance newfile(1).txt, newfile(2).txt, and newfile(3).txt.</para>
        /// <para>This method does not rename the items, it merely declares the items to be renamed.To rename a group of objects, you must make at least the sequence of calls detailed here:</para>
        /// <ol><li>Call <see cref="RenameItems"/> to declare the source files or folders and the new name.</li>
        /// <li>Call <see cref="PerformOperations"/> to begin the rename operation.</li></ol></remarks>
        HResult RenameItems([MarshalAs(UnmanagedType.Interface)] object pUnkItems, [MarshalAs(UnmanagedType.LPWStr)] string pszNewName);

        /// <summary>
        /// Declares a single item that is to be moved to a specified destination.
        /// </summary>
        /// <param name="psiItem">Pointer to an <see cref="IShellItem"/> that specifies the source item.</param>
        /// <param name="psiDestinationFolder">Pointer to an <see cref="IShellItem"/> that specifies the destination folder to contain the moved item.</param>
        /// <param name="pszNewName">Pointer to a new name for the item in its new location. This is a null-terminated Unicode string and can be <see langword="null"/>. If <see langword="null"/>, the name of the destination item is the same as the source.</param>
        /// <param name="pfopsItem">Pointer to an <see cref="IFileOperationProgressSink"/> object to be used for progress status and error notifications for this specific move operation. If you call <see cref="Advise"/> for the overall operation, progress status and error notifications for the move operation are included there, so set this parameter to <see langword="null"/>.</param>
        /// <returns>If this method succeeds, it returns S_OK. Otherwise, it returns an <see cref="HResult"/> error code.</returns>
        /// <remarks>This method does not move the item, it merely declares the item to be moved. To move an object, you must make at least the sequence of calls detailed here:
        /// <ol><li>Call <see cref="MoveItem"/> to declare the source item, destination folder, and destination name.</li>
        /// <li>Call <see cref="PerformOperations"/> to begin the move operation.</li></ol></remarks>
        HResult MoveItem(IShellItem psiItem, IShellItem psiDestinationFolder, [MarshalAs(UnmanagedType.LPWStr)] string pszNewName, IFileOperationProgressSink pfopsItem);

        /// <summary>
        /// Declares a set of items that are to be moved to a specified destination.
        /// </summary>
        /// <param name="punkItems">Pointer to the IUnknown of the <see cref="IShellItemArray"/>, <see cref="IDataObject"/>, or <see cref="IEnumShellItems"/> object which represents the group of items to be moved. You can also point to an <see cref="IPersistIDList"/> object to represent a single item, effectively accomplishing the same function as IFileOperation::MoveItem.</param>
        /// <param name="psiDestinationFolder">Pointer to an <see cref="IShellItem"/> that specifies the destination folder to contain the moved items.</param>
        /// <returns>If this method succeeds, it returns S_OK. Otherwise, it returns an <see cref="HResult"/> error code.</returns>
        /// <remarks>This method does not move the items, it merely declares the items to be moved. To move a group of items, you must make at least the sequence of calls detailed here:
        /// <ul><li>Call <see cref="MoveItems"/> to declare the source files or folders and the destination folder.</li>
        /// <li>Call <see cref="PerformOperations"/> to begin the move operation.</li></ul></remarks>
        HResult MoveItems([MarshalAs(UnmanagedType.Interface)] object punkItems, IShellItem psiDestinationFolder);

        /// <summary>
        /// Declares a single item that is to be copied to a specified destination.
        /// </summary>
        /// <param name="psiItem">Pointer to an <see cref="IShellItem"/> that specifies the source item.</param>
        /// <param name="psiDestinationFolder">Pointer to an <see cref="IShellItem"/> that specifies the destination folder to contain the copy of the item.</param>
        /// <param name="pszCopyName">Pointer to a new name for the item after it has been copied. This is a null-terminated Unicode string and can be <see langword="null"/>. If <see langword="null"/>, the name of the destination item is the same as the source.</param>
        /// <param name="pfopsItem">Pointer to an <see cref="IFileOperationProgressSink"/> object to be used for progress status and error notifications for this specific copy operation. If you call <see cref="Advise"/> for the overall operation, progress status and error notifications for the copy operation are included there, so set this parameter to <see langword="null"/>.</param>
        /// <returns>If this method succeeds, it returns S_OK. Otherwise, it returns an <see cref="HResult"/> error code.</returns>
        /// <remarks>This method does not copy the item, it merely declares the item to be copied. To copy an object, you must make at least the sequence of calls detailed here:
        /// <ol><li>Call <see cref="CopyItem"/> to declare the source item, destination folder, and destination name.</li>
        /// <li>Call <see cref="PerformOperations"/> to begin the copy operation.</li></ol></remarks>
        HResult CopyItem(IShellItem psiItem, IShellItem psiDestinationFolder, [MarshalAs(UnmanagedType.LPWStr)] string pszCopyName, IFileOperationProgressSink pfopsItem);

        /// <summary>
        /// Declares a set of items that are to be copied to a specified destination.
        /// </summary>
        /// <param name="punkItems">Pointer to the IUnknown of the <see cref="IShellItemArray"/>, <see cref="IDataObject"/>, or <see cref="IEnumShellItems"/> object which represents the group of items to be copied. You can also point to an <see cref="IPersistIDList"/> object to represent a single item, effectively accomplishing the same function as IFileOperation::CopyItem.</param>
        /// <param name="psiDestinationFolder">Pointer to an <see cref="IShellItem"/> that specifies the destination folder to contain the copy of the items.</param>
        /// <returns>If this method succeeds, it returns S_OK. Otherwise, it returns an <see cref="HResult"/> error code.</returns>
        /// <remarks>This method does not copy the items, it merely declares the items to be copied. To copy a group of items, you must make at least the sequence of calls detailed here:
        /// <ol><li>Call <see cref="CopyItems"/> to declare the source items and the destination folder.</li>
        /// <li>Call <see cref="PerformOperations"/> to begin the copy operation.</li></ol></remarks>
        HResult CopyItems([MarshalAs(UnmanagedType.Interface)] object punkItems, IShellItem psiDestinationFolder);

        /// <summary>
        /// Declares a single item that is to be deleted.
        /// </summary>
        /// <param name="psiItem">Pointer to an <see cref="IShellItem"/> that specifies the item to be deleted.</param>
        /// <param name="pfopsItem">Pointer to an <see cref="IFileOperationProgressSink"/> object to be used for progress status and error notifications for this specific delete operation. If you call <see cref="Advise"/> for the overall operation, progress status and error notifications for the delete operation are included there, so set this parameter to <see langword="null"/>.</param>
        /// <returns>If this method succeeds, it returns S_OK. Otherwise, it returns an <see cref="HResult"/> error code.</returns>
        /// <remarks>This method does not delete the item, it merely declares the item to be deleted. To delete an item, you must make at least the sequence of calls detailed here:
        /// <ol><li>Call <see cref="DeleteItem"/> to declare the file or folder to be deleted.</li>
        /// <li>Call <see cref="PerformOperations"/> to begin the delete operation.</li></ol></remarks>
        HResult DeleteItem(IShellItem psiItem, IFileOperationProgressSink pfopsItem);

        /// <summary>
        /// Declares a set of items that are to be deleted.
        /// </summary>
        /// <param name="punkItems">Pointer to the IUnknown of the <see cref="IShellItemArray"/>, <see cref="IDataObject"/>, or <see cref="IEnumShellItems"/> object which represents the group of items to be deleted. You can also point to an <see cref="IPersistIDList"/> object to represent a single item, effectively accomplishing the same function as IFileOperation::DeleteItem.</param>
        /// <returns>If this method succeeds, it returns S_OK. Otherwise, it returns an <see cref="HResult"/> error code.</returns>
        /// <remarks>This method does not delete the items, it merely declares the items to be deleted. To delete a group of items, you must make at least the sequence of calls detailed here:
        /// <ol><li>Call <see cref="DeleteItems"/> to declare the files or folders to be deleted.</li>
        /// <li>Call <see cref="PerformOperations"/> to begin the delete operation.</li></ol></remarks>
        HResult DeleteItems([MarshalAs(UnmanagedType.Interface)] object punkItems);

        /// <summary>
        /// Declares a new item that is to be created in a specified location.
        /// </summary>
        /// <param name="psiDestinationFolder">Pointer to an <see cref="IShellItem"/> that specifies the destination folder that will contain the new item.</param>
        /// <param name="dwFileAttributes">A bitwise value that specifies the file system attributes for the file or folder. See <see cref="File.GetAttributes(string)"/> for possible values.</param>
        /// <param name="pszName">Pointer to the file name of the new item, for instance <b>Newfile.txt</b>. This is a null-terminated, Unicode string.</param>
        /// <param name="pszTemplateName">Pointer to the name of the template file (for example Excel9.xls) that the new item is based on, stored in one of the following locations:
        /// <ol><li>CSIDL_COMMON_TEMPLATES.The default path for this folder is %ALLUSERSPROFILE%\Templates.</li>
        /// <li>CSIDL_TEMPLATES.The default path for this folder is %USERPROFILE%\Templates.</li>
        /// <li>%SystemRoot%\shellnew</li></ol>
        /// <para>This is a null-terminated, Unicode string used to specify an existing file of the same type as the new file, containing the minimal content that an application wants to include in any new file.</para>
        /// <para>This parameter is normally <see langword="null"/> to specify a new, blank file.</para></param>
        /// <param name="pfopsItem">Pointer to an <see cref="IFileOperationProgressSink"/> object to be used for status and failure notifications. If you call <see cref="Advise"/> for the overall operation, progress status and error notifications for the creation operation are included there, so set this parameter to <see langword="null"/>.</param>
        /// <returns>If this method succeeds, it returns <see cref="HResult.Ok"/>. Otherwise, it returns an <see cref="HResult"/> error code.</returns>
        /// <remarks>This method does not create the new item, it merely declares the item to be created. To create a new item, you must make at least the sequence of calls detailed here:
        /// <ol><li>Call <see cref="NewItem"/> to declare the specifics of the new file or folder.</li>
        /// <li>Call <see cref="PerformOperations"/> to create the new item.</li></ol></remarks>
        HResult NewItem(IShellItem psiDestinationFolder, FileAttributes dwFileAttributes, [MarshalAs(UnmanagedType.LPWStr)] string pszName, [MarshalAs(UnmanagedType.LPWStr)] string pszTemplateName, IFileOperationProgressSink pfopsItem);

        /// <summary>
        /// Executes all selected operations.
        /// </summary>
        /// <returns>Returns <see cref="HResult.Ok"/> if successful, or an error value otherwise. Note that if the operation was canceled by the user, this method can still return a success code. Use the <see cref="GetAnyOperationsAborted"/> method to determine if this was the case.</returns>
        /// <remarks>This method is called last to execute those actions that have been specified earlier by calling their individual methods. For instance, <see cref="RenameItem"/> does not rename the item, it simply sets the parameters. The actual renaming is done when you call <see cref="PerformOperations"/>.</remarks>
        HResult PerformOperations();

        /// <summary>
        /// Gets a value that states whether any file operations initiated by a call to <see cref="PerformOperations"/> were stopped before they were complete. The operations could be stopped either by user action or silently by the system.
        /// </summary>
        /// <param name="pfAnyOperationsAborted">When this method returns, points to <see langword="true"/> if any file operations were aborted before they were complete; otherwise, <see langword="false"/>.</param>
        /// <returns>If this method succeeds, it returns S_OK. Otherwise, it returns an <see cref="HResult"/> error code.</returns>
        /// <remarks><para>Call this method after <see cref="PerformOperations"/> returns.</para>
        /// <para>You should call <see cref="GetAnyOperationsAborted"/> regardless of whether <see cref="PerformOperations"/> returned a success or failure code.A success code can be returned even if the operation was stopped by the user or the system.</para>
        /// <para>This method provides the same functionality as the fAnyOperationsAborted member of the SHFILEOPSTRUCT structure used by the legacy function SHFileOperation.</para></remarks>
        HResult GetAnyOperationsAborted(out bool pfAnyOperationsAborted);
    }
}
