/* Copyright © Pierre Sprimont, 2019
 *
 * This file is part of the WinCopies Windows API Code Pack.
 *
 * This part of the WinCopies Windows API Code Pack is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * This part of the WinCopies Windows API Code Pack is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with the WinCopies Windows API Code Pack.  If not, see <https://www.gnu.org/licenses/>. */

#if CS7
using Microsoft.WindowsAPICodePack.COMNative.Shell;
using Microsoft.WindowsAPICodePack.COMNative.Shell.PropertySystem;
using Microsoft.WindowsAPICodePack.Win32Native;
using Microsoft.WindowsAPICodePack.Win32Native.Shell;

using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Interop;

using static Microsoft.WindowsAPICodePack.Win32Native.Shell.Shell;

using static WinCopies.
#if WAPICP3
    ThrowHelper;

using WinCopies.Collections.DotNetFix.Generic;
#else
    Util.Util;

using System.Collections.Generic;
#endif

using static Microsoft.WindowsAPICodePack.Win32Native.CoreErrorHelper;

using FileAttributes = Microsoft.WindowsAPICodePack.Win32Native.Shell.FileAttributes;

namespace Microsoft.WindowsAPICodePack.Shell
{
    /// <summary>
    /// Contains information about a file object.
    /// </summary>
    /// <remarks>This structure is used with the <see cref="FileOperation.GetFileInfo(in string, in FileAttributes, in GetFileInfoOptions)"/> function.</remarks>
    public struct FileInfo :
#if WinCopies3
        WinCopies.DotNetFix
#else
        System
#endif
        .IDisposable
    {
        /// <summary>
        /// Gets or sets the icon that represents the file. When the <see cref="Dispose"/> method of this struct is called, that method calls the <see cref="Dispose"/> method on the current <see cref="Icon"/>.
        /// </summary>
        public Icon Icon { get; private set; }

        /// <summary>
        /// Gets or sets the index of the icon image within the system image list.
        /// </summary>
        public int IconIndex { get; }

        /// <summary>
        /// Gets or sets an array of values that indicates the attributes of the file object. For information about these values, see the <see cref="IShellFolder.GetAttributesOf"/> method.
        /// </summary>
        public ShellFileGetAttributesOptions Attributes { get; }

        /// <summary>
        /// Gets or sets a string that contains the name of the file as it appears in the Windows Shell, or the path and file name of the file that contains the icon representing the file.
        /// </summary>
        public string DisplayName { get; private set; }

        /// <summary>
        /// Gets or sets a string that describes the type of file.
        /// </summary>
        public string TypeName { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="FileInfo"/> structure.
        /// </summary>
        /// <param name="icon">The icon of the file represented by this structure.</param>
        /// <param name="iconIndex">The icon index of the retrieved icon.</param>
        /// <param name="attributes">The attributes of the file represented by this structure.</param>
        /// <param name="displayName">The display name of the file represented by this structure.</param>
        /// <param name="typeName">The type name of the file represented by this structure.</param>
        public FileInfo(
#if WinCopies3
            in
#endif
            Icon icon,
#if WinCopies3
            in
#endif
            int iconIndex,
#if WinCopies3
            in
#endif
            ShellFileGetAttributesOptions attributes,
#if WinCopies3
            in
#endif
            string displayName,
#if WinCopies3
            in
#endif
            string typeName)
        {
            Icon = icon;

            IconIndex = iconIndex;

            Attributes = attributes;

            DisplayName = displayName;

            TypeName = typeName;
        }

#if WinCopies3
        public bool IsDisposed => Icon == null;

        public void Dispose()
        {
            if (IsDisposed)

                return;

            Icon.Dispose();
            Icon = null;

            DisplayName = null;

            TypeName = null;
        }
#else
        /// <summary>
        /// Calls the <see cref="Icon.Dispose"/> method from the <see cref="Icon"/> property.
        /// </summary>
        public void Dispose() => Icon.Dispose();
#endif
    }

    /// <summary>
    /// Provides methods to perform file system operations.
    /// </summary>
    public class FileOperation : WinCopies.
#if !WAPICP3
        Util.
#endif
        DotNetFix.IDisposable
    {
        private readonly IFileOperation _fileOperation;
        private readonly
#if WAPICP3
            ILinkedList
#else
List
#endif
            <uint> _cookies = new
#if WAPICP3
            WinCopies.Collections.DotNetFix.Generic.LinkedList
#else
List
#endif
            <uint>();

        public
#if WAPICP3
            IReadOnlyLinkedList
#else
            System.Collections.ObjectModel.ReadOnlyCollection
#endif
            <uint> Cookies
        { get; }

        public bool IsDisposed { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="FileOperation"/> class.
        /// </summary>
        public FileOperation()
        {
            _fileOperation = (IFileOperation)Activator.CreateInstance(Type.GetTypeFromCLSID(new Guid(NativeAPI.Guids.Shell.FileOperation)));

            Cookies = new
#if WAPICP3
                WinCopies.Collections.DotNetFix.Generic.ReadOnlyLinkedList
#else
System.Collections.ObjectModel.ReadOnlyCollection
#endif
                <uint>(_cookies);
        }

        public static HResult TryExtractIcon(in string extension, in ShellImageListIconSize size, in IImageList imageList, out Icon icon)
        {
            FileInfo fileInfo = GetFileInfo(extension, FileAttributes.Normal, GetFileInfoOptions.IconLocation | GetFileInfoOptions.UseFileAttributes);

            // var guid = new Guid(NativeAPI.Guids.Shell.IImageList);

            // _ = SHGetImageList(size, ref guid, out IntPtr ptr);

            HResult result = /*((IImageList)Marshal.GetTypedObjectForIUnknown(ptr, typeof(IImageList)))*/imageList.GetIcon(fileInfo.IconIndex, ImageListDrawFlags.Transparent, out IntPtr iconPtr);

            if (Succeeded(result))
            {
                icon = (Icon)Icon.FromHandle(iconPtr).Clone();

                _ = Core.DestroyIcon(iconPtr);
            }

            else

                icon = null;

            return result;
        }

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (IsDisposed) return;

            foreach (uint cookie in _cookies)

                Unadvise(cookie);

            _ = Marshal.FinalReleaseComObject(_fileOperation);

            IsDisposed = true;
        }

        ~FileOperation() => Dispose(false);

#if WAPICP3
        public HResult TryAdvise(in IFileOperationProgressSinkProvider fileOperationProgressSinkProvider, out uint cookie) => TryAdvise(fileOperationProgressSinkProvider?.GetFileOperationProgressSink(), out cookie);
#endif

        public HResult TryAdvise(in
#if WAPICP3
            IFileOperationProgressSink
#else
            FileOperationProgressSink
#endif
            pfops, out uint cookie)
        {
            if (pfops == null) throw new ArgumentNullException(nameof(pfops));

            if (IsDisposed) throw new ObjectDisposedException(nameof(FileOperation));

            HResult hr = _fileOperation.Advise(pfops
#if !WAPICP3
                ?.InnerFileOperationProgressSink
#endif
                , out cookie);

            if (Succeeded(hr))

                _cookies.Add(cookie);

            return hr;
        }

#if WAPICP3
        public uint Advise(in IFileOperationProgressSinkProvider fileOperationProgressSinkProvider) => Advise(fileOperationProgressSinkProvider?.GetFileOperationProgressSink());
#endif

        /// <summary>
        /// Enables a handler to provide status and error information for all operations.
        /// </summary>
        /// <param name="pfops">An <see cref="IFileOperationProgressSink"/> object to be used for progress status and error notifications.</param>
        /// <returns>A returned token that uniquely identifies this connection. The calling application uses this token later to delete the connection by passing it to <see cref="Unadvise"/>.</returns>
        /// <remarks>Several individual methods have the ability to declare their own progress sinks, which are redundant to the one set here. They are used when you only want to be given progress and error information for a specific operation.</remarks>
        /// <exception cref="ArgumentNullException">Exception thrown when a parameter is null.</exception>
        /// <exception cref="ObjectDisposedException">Exception thrown when this object is disposed.</exception>
        /// <exception cref="Win32Exception">Exception thrown when this method fails because of an error in the Win32 COM API implementation.</exception>
        public uint Advise(
#if WAPICP3
            in IFileOperationProgressSink
#else
            FileOperationProgressSink
#endif
            pfops)
        {
            ThrowExceptionForHResult(TryAdvise(pfops, out uint cookie));

            return cookie;
        }

        public HResult TryUnadvise(in uint cookie)
        {
            if (IsDisposed) throw new ObjectDisposedException(nameof(FileOperation));

            HResult hr = _fileOperation.Unadvise(cookie);

            if (Succeeded(hr))

                _ = _cookies.Remove(cookie);

            return hr;
        }

        /// <summary>
        /// Terminates an advisory connection previously established through <see cref="Advise"/>.
        /// </summary>
        /// <param name="dwCookie">The connection token that identifies the connection to delete. This value was originally retrieved by <see cref="Advise"/> when the connection was made.</param>
        /// <exception cref="ObjectDisposedException">Exception thrown when this object is disposed.</exception>
        /// <exception cref="Win32Exception">Exception thrown when this method fails because of an error in the Win32 COM API implementation.</exception>
        public void Unadvise(
#if WAPICP3
            in
#endif
            uint dwCookie) => ThrowExceptionForHResult(TryUnadvise(dwCookie));

        private HResult GetHResult(in Func<HResult> func) => IsDisposed ? throw new ObjectDisposedException(nameof(FileOperation)) : func();

        public HResult TrySetOperationFlags(ShellOperationFlags flags) => GetHResult(() =>
        {
            switch (flags)
            {
                case ShellOperationFlags.AddUndoRecord:
                case ShellOperationFlags.RecycleOnDelete:

                    CoreHelpers.ThrowIfNotWin8();

                    break;

                case ShellOperationFlags.CopyAsDownload:
                case ShellOperationFlags.DoNotDisplayLocations:

                    CoreHelpers.ThrowIfNotWin7();

                    break;

                case ShellOperationFlags.RequireElevation:

                    CoreHelpers.ThrowIfNotVista();

                    break;
            }

            return _fileOperation.SetOperationFlags(flags);
        });

        /// <summary>
        /// Sets parameters for the current operation.
        /// </summary>
        /// <param name="flags">Flags that control the file operation. FOF flags are defined in Shellapi.h and FOFX flags are defined in Shobjidl.h. Note : If this method is not called, the default value used by the operation is <see cref=" ShellOperationFlags.FOF_ALLOWUNDO"/> | <see cref="ShellOperationFlags.FOF_NOCONFIRMMKDIR"/>.</param>
        /// <remarks>Set these flags before you call <see cref="PerformOperations"/> to define the parameters for whatever operations are being performed, such as copy, delete, or rename.</remarks>
        /// <exception cref="ObjectDisposedException">Exception thrown when this object is disposed.</exception>
        /// <exception cref="PlatformNotSupportedException">Exception thrown when a requested flag is not supported by the current platform.</exception>
        /// <exception cref="Win32Exception">Exception thrown when this method fails because of an error in the Win32 COM API implementation.</exception>
        public void SetOperationFlags(
#if WAPICP3
            in
#endif
            ShellOperationFlags flags) => ThrowExceptionForHResult(TrySetOperationFlags(flags));

        public HResult TrySetProgressDialog(IOperationsProgressDialog progressDialog)
        {
            ThrowIfNull(progressDialog, nameof(progressDialog));

            return GetHResult(() => _fileOperation.SetProgressDialog(progressDialog));
        }

        /// <summary>
        /// Specifies a dialog box used to display the progress of the operation.
        /// </summary>
        /// <param name="popd">An <see cref="IOperationsProgressDialog"/> object that represents the dialog box.</param>
        /// <exception cref="ArgumentNullException">Exception thrown when a parameter is null.</exception>
        /// <exception cref="Win32Exception">Exception thrown when this method fails because of an error in the Win32 COM API implementation.</exception>
        public void SetProgressDialog(
#if WAPICP3
            in
#endif
            IOperationsProgressDialog popd) => ThrowExceptionForHResult(TrySetProgressDialog(popd));

        public HResult TrySetProperties(IPropertyChangeArray pproparray)
        {
            ThrowIfNull(pproparray, nameof(pproparray));

            return GetHResult(() => _fileOperation.SetProperties(pproparray));
        }

        /// <summary>
        /// Declares a set of properties and values to be set on an item or items.
        /// </summary>
        /// <param name="pproparray">An <see cref="IPropertyChangeArray"/>, which accesses a collection of <see cref="IPropertyChange"/> objects that specify the properties to be set and their new values.</param>
        /// <remarks>This method does not set the new property values, it merely declares them. To set property values on an item or a group of items, you must make at least the sequence of calls detailed here:
        /// <ol><li>Call <see cref="SetProperties"/> to declare the specific properties to be set and their new values.</li>
        /// <li>Call <see cref="ApplyPropertiesToItem(ShellObject)"/> or <see cref="ApplyPropertiesToItem(IShellItem)"/> to declare the item or items whose properties are to be set.</li>
        /// <li>Call <see cref="PerformOperations"/> to apply the properties to the item or items.</li></ol></remarks>
        /// <exception cref="ArgumentNullException">Exception thrown when a parameter is null.</exception>
        /// <exception cref="ObjectDisposedException">Exception thrown when this object is disposed.</exception>
        /// <exception cref="Win32Exception">Exception thrown when this method fails because of an error in the Win32 COM API implementation.</exception>
        public void SetProperties(
#if WAPICP3
            in
#endif
            IPropertyChangeArray pproparray) => ThrowExceptionForHResult(TrySetProperties(pproparray));

        public HResult TrySetOwnerWindow(IntPtr ptr) => GetHResult(() => _fileOperation.SetOwnerWindow(ptr));

        public void SetOwnerWindow(
#if WAPICP3
            in
#endif
            IntPtr hwndOwner) => ThrowExceptionForHResult(TrySetOwnerWindow(hwndOwner));

        public HResult TrySetOwnerWindow(in Form window) => TrySetOwnerWindow(window.Handle);

        public void SetOwnerWindow(
#if WAPICP3
            in
#endif
            Form window) => SetOwnerWindow(window.Handle);

        public HResult TrySetOwnerWindow(in Window window) => TrySetOwnerWindow(new WindowInteropHelper(window).Handle);

        public void SetOwnerWindow(
#if WAPICP3
            in
#endif
            Window window) => SetOwnerWindow(new WindowInteropHelper(window).Handle);

        public HResult TryApplyPropertiesToItem(IShellItem item) => GetHResult(() => _fileOperation.ApplyPropertiesToItem(item));

        public void ApplyPropertiesToItem(
#if WAPICP3
            in
#endif
            IShellItem psiItem) => ThrowExceptionForHResult(TryApplyPropertiesToItem(psiItem));

        private static IShellItem GetShellItem(in ShellObject shellObject) => (IShellItem)typeof(ShellObject).GetProperty("NativeShellItem", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(shellObject);

        public void ApplyPropertiesToItem(
#if WAPICP3
            in
#endif
            ShellObject shellObject) => ApplyPropertiesToItem(GetShellItem(shellObject));

#if WAPICP3
        public HResult TryRenameItem(in IShellItem item, in string newName, in IFileOperationProgressSinkProvider provider) => TryRenameItem(item, newName, provider?.GetFileOperationProgressSink());

        public HResult TryRenameItem(in ShellObject item, in string newName, in IFileOperationProgressSinkProvider provider) => TryRenameItem(GetShellItem(item), newName, provider?.GetFileOperationProgressSink());

        public void RenameItem(in IShellItem psiItem, in string pszNewName, in IFileOperationProgressSinkProvider pfopsItem) => RenameItem(psiItem, pszNewName, pfopsItem?.GetFileOperationProgressSink());

        public void RenameItem(in ShellObject shellObject, in string newName, in IFileOperationProgressSinkProvider pfopsItem) => RenameItem(GetShellItem(shellObject), newName, pfopsItem.GetFileOperationProgressSink());
#endif

        public HResult TryRenameItem(IShellItem item, string newName,
#if WAPICP3
            IFileOperationProgressSink
#else
            FileOperationProgressSink
#endif
            fileOperationProgressSink) => GetHResult(() => _fileOperation.RenameItem(item, newName, fileOperationProgressSink
#if !WAPICP3
                ?.InnerFileOperationProgressSink
#endif
                ));

        public HResult TryRenameItem(in ShellObject item, in string newName, in
#if WAPICP3
            IFileOperationProgressSink
#else
            FileOperationProgressSink
#endif
            fileOperationProgressSink) => TryRenameItem(GetShellItem(item), newName, fileOperationProgressSink);

        public void RenameItem(
#if WAPICP3
            in
#endif
            IShellItem psiItem,
#if WAPICP3
            in
#endif
            string pszNewName,
#if WAPICP3
            in IFileOperationProgressSink
#else
            FileOperationProgressSink
#endif
         pfopsItem) => ThrowExceptionForHResult(TryRenameItem(psiItem, pszNewName, pfopsItem));

        public void RenameItem(
#if WAPICP3
            in
#endif
            ShellObject shellObject,
#if WAPICP3
            in
#endif
            string newName,
#if WAPICP3
            in IFileOperationProgressSink
#else
            FileOperationProgressSink
#endif
         pfopsItem) => RenameItem(GetShellItem(shellObject), newName, pfopsItem);

#if WAPICP3
        public HResult TryMoveItem(in IShellItem item, in IShellItem destinationFolder, in string newName, in IFileOperationProgressSinkProvider provider) => TryMoveItem(item, destinationFolder, newName, provider?.GetFileOperationProgressSink());

        public HResult TryMoveItem(in ShellObject item, in ShellObject destinationFolder, in string newName, in IFileOperationProgressSinkProvider provider) => TryMoveItem(GetShellItem(item), GetShellItem(destinationFolder), newName, provider?.GetFileOperationProgressSink());
#endif

        public HResult TryMoveItem(IShellItem item, IShellItem destinationFolder, string newName,
#if WAPICP3
            IFileOperationProgressSink
#else
            FileOperationProgressSink
#endif
          fileOperationProgressSink) => GetHResult(() => _fileOperation.MoveItem(item, destinationFolder, newName, fileOperationProgressSink
#if !WAPICP3
                ?.InnerFileOperationProgressSink
#endif
                ));

        public HResult TryMoveItem(in ShellObject item, in ShellObject destinationFolder, in string newName, in
#if WAPICP3
            IFileOperationProgressSink
#else
            FileOperationProgressSink
#endif
          fileOperationProgressSink) => TryMoveItem(GetShellItem(item), GetShellItem(destinationFolder), newName, fileOperationProgressSink);

#if WAPICP3
        public void MoveItem(in IShellItem item, in IShellItem destinationFolder, in string newName, in IFileOperationProgressSinkProvider provider) => MoveItem(item, destinationFolder, newName, provider?.GetFileOperationProgressSink());

        public void MoveItem(in ShellObject item, in ShellObject destinationFolder, in string newName, IFileOperationProgressSinkProvider provider) => MoveItem(GetShellItem(item), GetShellItem(destinationFolder), newName, provider?.GetFileOperationProgressSink());
#endif

        public void MoveItem(
#if WAPICP3
            in
#endif
            IShellItem psiItem,
#if WAPICP3
            in
#endif
            IShellItem psiDestinationFolder,
#if WAPICP3
            in
#endif
            string pszNewName,
#if WAPICP3
            in IFileOperationProgressSink
#else
            FileOperationProgressSink
#endif
            pfopsItem) => ThrowExceptionForHResult(TryMoveItem(psiItem, psiDestinationFolder, pszNewName, pfopsItem));

        public void MoveItem(
#if WAPICP3
            in
#endif
            ShellObject shellObject,
#if WAPICP3
            in
#endif
            ShellObject destinationShellObject,
#if WAPICP3
            in
#endif
            string newName,
#if WAPICP3
            in IFileOperationProgressSink
#else
            FileOperationProgressSink
#endif
        pfopsItem) => MoveItem(GetShellItem(shellObject), GetShellItem(destinationShellObject), newName, pfopsItem);

        public HResult TryCopyItem(IShellItem item, IShellItem destinationFolder, string copyName,
#if WAPICP3
            IFileOperationProgressSink
#else
            FileOperationProgressSink
#endif
       fileOperationProgressSink) => GetHResult(() => _fileOperation.CopyItem(item, destinationFolder, copyName, fileOperationProgressSink
#if !WAPICP3
            ?.InnerFileOperationProgressSink
#endif
            ));

        public HResult TryCopyItem(in ShellObject item, in ShellObject destinationFolder, in string copyName, in
#if WAPICP3
            IFileOperationProgressSink
#else
            FileOperationProgressSink
#endif
            fileOperationProgressSink) => TryCopyItem(GetShellItem(item), GetShellItem(destinationFolder), copyName, fileOperationProgressSink);

#if WAPICP3
        public HResult TryCopyItem(in IShellItem item, in IShellItem destinationFolder, in string copyName, in IFileOperationProgressSinkProvider provider) => TryCopyItem(item, destinationFolder, copyName, provider?.GetFileOperationProgressSink());

        public HResult TryCopyItem(in ShellObject item, in ShellObject destinationFolder, in string copyName, in IFileOperationProgressSinkProvider provider) => TryCopyItem(GetShellItem(item), GetShellItem(destinationFolder), copyName, provider?.GetFileOperationProgressSink());

        public void CopyItem(in IShellItem item, in IShellItem destinationFolder, in string copyName, in IFileOperationProgressSinkProvider provider) => CopyItem(item, destinationFolder, copyName, provider?.GetFileOperationProgressSink());

        public void CopyItem(in ShellObject item, in ShellObject destinationFolder, in string copyName, in IFileOperationProgressSinkProvider provider) => CopyItem(GetShellItem(item), GetShellItem(destinationFolder), copyName, provider?.GetFileOperationProgressSink());
#endif

        public void CopyItem(
#if WAPICP3
            in
#endif
            IShellItem psiItem,
#if WAPICP3
            in
#endif
            IShellItem psiDestinationFolder,
#if WAPICP3
            in
#endif
            string pszCopyName,
#if WAPICP3
            in IFileOperationProgressSink
#else
            FileOperationProgressSink
#endif
             pfopsItem) => ThrowExceptionForHResult(TryCopyItem(psiItem, psiDestinationFolder, pszCopyName, pfopsItem));

        public void CopyItem(
#if WAPICP3
            in
#endif
            ShellObject shellObject,
#if WAPICP3
            in
#endif
            ShellObject destinationFolder,
#if WAPICP3
            in
#endif
            string copyName,
#if WAPICP3
            in IFileOperationProgressSink
#else
            FileOperationProgressSink
#endif
             pfopsItem) => CopyItem(GetShellItem(shellObject), GetShellItem(destinationFolder), copyName, pfopsItem);

        public HResult TryDeleteItem(IShellItem item,
#if WAPICP3
            IFileOperationProgressSink
#else
            FileOperationProgressSink
#endif
          fileOperationProgressSink) => GetHResult(() => _fileOperation.DeleteItem(item, fileOperationProgressSink
#if !WAPICP3
            ?.InnerFileOperationProgressSink
#endif
            ));

        public HResult TryDeleteItem(in ShellObject item,
#if WAPICP3
            IFileOperationProgressSink
#else
            FileOperationProgressSink
#endif
          fileOperationProgressSink) => TryDeleteItem(GetShellItem(item), fileOperationProgressSink);

#if WAPICP3
        public HResult TryDeleteItem(in IShellItem item, in IFileOperationProgressSinkProvider provider) => TryDeleteItem(item, provider?.GetFileOperationProgressSink());

        public HResult TryDeleteItem(in ShellObject item, in IFileOperationProgressSinkProvider provider) => TryDeleteItem(GetShellItem(item), provider?.GetFileOperationProgressSink());

        public void DeleteItem(in IShellItem item, in IFileOperationProgressSinkProvider provider) => DeleteItem(item, provider?.GetFileOperationProgressSink());

        public void DeleteItem(in ShellObject item, in IFileOperationProgressSinkProvider provider) => DeleteItem(GetShellItem(item), provider?.GetFileOperationProgressSink());
#endif

        public void DeleteItem(
#if WAPICP3
            in
#endif
            IShellItem psiItem,
#if WAPICP3
            in IFileOperationProgressSink
#else
            FileOperationProgressSink
#endif
            pfopsItem) => ThrowExceptionForHResult(TryDeleteItem(psiItem, pfopsItem));

        public void DeleteItem(
#if WAPICP3
            in
#endif
            ShellObject shellObject,
#if WAPICP3
            in IFileOperationProgressSink
#else
            FileOperationProgressSink
#endif
            pfopsItem) => DeleteItem(GetShellItem(shellObject), pfopsItem);

        public HResult TryNewItem(IShellItem destinationFolder, FileAttributes fileAttributes, string name, string templateName,
#if WAPICP3
            IFileOperationProgressSink
#else
            FileOperationProgressSink
#endif
          fileOperationProgressSink) => GetHResult(() => _fileOperation.NewItem(destinationFolder, fileAttributes, name, templateName, fileOperationProgressSink
#if !WAPICP3
            ?.InnerFileOperationProgressSink
#endif
            ));

        public HResult TryNewItem(in ShellObject destinationFolder, in FileAttributes fileAttributes, in string name, in string templateName,
#if WAPICP3
            IFileOperationProgressSink
#else
            FileOperationProgressSink
#endif
          fileOperationProgressSink) => TryNewItem(GetShellItem(destinationFolder), fileAttributes, name, templateName, fileOperationProgressSink);

#if WAPICP3
        public HResult TryNewItem(in IShellItem destinationFolder, in FileAttributes fileAttributes, in string name, in string templateName, in IFileOperationProgressSinkProvider fileOperationProgressSink) => TryNewItem(destinationFolder, fileAttributes, name, templateName, fileOperationProgressSink?.GetFileOperationProgressSink());

        public HResult TryNewItem(in ShellObject destinationFolder, in FileAttributes fileAttributes, in string name, in string templateName, in IFileOperationProgressSinkProvider fileOperationProgressSink) => TryNewItem(GetShellItem(destinationFolder), fileAttributes, name, templateName, fileOperationProgressSink?.GetFileOperationProgressSink());

        public void NewItem(in IShellItem destinationFolder, in FileAttributes fileAttributes, in string name, in string templateName, in IFileOperationProgressSinkProvider provider) => NewItem(destinationFolder, fileAttributes, name, templateName, provider.GetFileOperationProgressSink());

        public void NewItem(in ShellObject destinationFolder, in FileAttributes fileAttributes, in string name, in string templateName, in IFileOperationProgressSinkProvider provider) => NewItem(GetShellItem(destinationFolder), fileAttributes, name, templateName, provider.GetFileOperationProgressSink());
#endif

        public void NewItem(
#if WAPICP3
            in
#endif
            IShellItem psiDestinationFolder,
#if WAPICP3
            in
#endif
            FileAttributes dwFileAttributes,
#if WAPICP3
            in
#endif
            string pszName,
#if WAPICP3
            in
#endif
            string pszTemplateName,
#if WAPICP3
            in IFileOperationProgressSink
#else
            FileOperationProgressSink
#endif
            pfopsItem) => ThrowExceptionForHResult(TryNewItem(psiDestinationFolder, dwFileAttributes, pszName, pszTemplateName, pfopsItem));

        public void NewItem(
#if WAPICP3
            in
#endif
            ShellObject destinationFolder,
#if WAPICP3
            in
#endif
            FileAttributes fileAttributes,
#if WAPICP3
            in
#endif
            string name,
#if WAPICP3
            in
#endif
            string templateName,
#if WAPICP3
            in IFileOperationProgressSink
#else
            FileOperationProgressSink
#endif
            pfopsItem) => NewItem(GetShellItem(destinationFolder), fileAttributes, name, templateName, pfopsItem);

        public HResult TryPerformOperations() => GetHResult(() => _fileOperation.PerformOperations());

        public void PerformOperations() => ThrowExceptionForHResult(TryPerformOperations());

        public HResult TryGetAnyOperationsAborted(out bool anyOperationsAborted) => IsDisposed
                ? throw new ObjectDisposedException(nameof(FileOperation))
                : _fileOperation.GetAnyOperationsAborted(out anyOperationsAborted);

        public bool GetAnyOperationsAborted() => GetIfSucceeded<bool>(TryGetAnyOperationsAborted);

        /// <summary>
        /// Retrieves information about an object in the file system, such as a file, folder, directory, or drive root.
        /// </summary>
        /// <param name="path"><para>A string of maximum length <see cref="MaxPath"/> that contains the path and file name. Both absolute and relative paths are valid.</para>
        /// <para>If the <b>uFlags</b> parameter includes the <see cref="GetFileInfoOptions.PIDL"/> flag, this parameter must be the address of an ITEMIDLIST(PIDL) structure that contains the list of item identifiers that uniquely identifies the file within the Shell's namespace. The PIDL must be a fully qualified PIDL. Relative PIDLs are not allowed.</para>
        /// <para>If the <b>uFlags</b> parameter includes the <see cref="GetFileInfoOptions.UseFileAttributes"/> flag, this parameter does not have to be a valid file name. The function will proceed as if the file exists with the specified name and with the file attributes passed in the <b>dwFileAttributes</b> parameter. This allows you to obtain information about a file type by passing just the extension for <b>pszPath</b> and passing <see cref="FileAttributes.Normal"/> in <b>dwFileAttributes</b>.</para>
        /// <para>This string can use either short (the 8.3 form) or long file names.</para></param>
        /// <param name="fileAttributes">A combination of one or more <see cref="FileAttributes"/> flags. If <b>uFlags</b> does not include the <see cref="GetFileInfoOptions.UseFileAttributes"/> flag, this parameter is ignored.</param>
        /// <param name="options">The flags that specify the file information to retrieve. This parameter can be a combination of the values of the <see cref="GetFileInfoOptions"/> enum.</param>
        /// <returns>A <see cref="FileInfo"/> structure that contains the file information.</returns>
        public static FileInfo GetFileInfo(
#if WAPICP3
            in
#endif
            string path,
#if WAPICP3
            in
#endif
            FileAttributes fileAttributes,
#if WAPICP3
            in
#endif
            GetFileInfoOptions options)
        {
            var psfi = new SHFILEINFO();

            HResult hr = SHGetFileInfo(path, fileAttributes, ref psfi, (uint)Marshal.SizeOf(psfi), options);

            if (!Succeeded(hr))

                CoreErrorHelper.ThrowExceptionForHResult(hr);

            Icon icon;

            if (psfi.hIcon == IntPtr.Zero)

                icon = null;

            else
            {
                icon = (Icon)Icon.FromHandle(psfi.hIcon).Clone();

                _ = Core.DestroyIcon(psfi.hIcon);
            }

            return new FileInfo(icon, psfi.iIcon, psfi.dwAttributes, psfi.szDisplayName, psfi.szTypeName);
        }

        /// <summary>
        /// Retrieves information about an object in the file system, such as a file, folder, directory, or drive root and a value that indicates the exe type.
        /// </summary>
        /// <param name="path"><para>A string of maximum length <see cref="MaxPath"/> that contains the path and file name. Both absolute and relative paths are valid.</para>
        /// <para>If the <b>uFlags</b> parameter includes the <see cref="GetFileInfoOptions.PIDL"/> flag, this parameter must be the address of an ITEMIDLIST(PIDL) structure that contains the list of item identifiers that uniquely identifies the file within the Shell's namespace. The PIDL must be a fully qualified PIDL. Relative PIDLs are not allowed.</para>
        /// <para>If the <b>uFlags</b> parameter includes the <see cref="GetFileInfoOptions.UseFileAttributes"/> flag, this parameter does not have to be a valid file name. The function will proceed as if the file exists with the specified name and with the file attributes passed in the <b>dwFileAttributes</b> parameter. This allows you to obtain information about a file type by passing just the extension for <b>pszPath</b> and passing <see cref="FileAttributes.Normal"/> in <b>dwFileAttributes</b>.</para>
        /// <para>This string can use either short (the 8.3 form) or long file names.</para></param>
        /// <param name="fileAttributes">A combination of one or more <see cref="FileAttributes"/> flags. If <b>uFlags</b> does not include the <see cref="GetFileInfoOptions.UseFileAttributes"/> flag, this parameter is ignored.</param>
        /// <param name="options">The flags that specify the file information to retrieve. This parameter can be a combination of the values of the <see cref="GetFileInfoOptions"/> enum.</param>
        /// <param name="exeType">The exe type. In order to this method retrieves the exe type, you need to use the <see cref="GetFileInfoOptions.ExeType"/> flag in the <b>options</b> parameter.</param>
        /// <returns>A <see cref="FileInfo"/> structure that contains the file information.</returns>
        public static FileInfo GetFileInfo(
#if WAPICP3
            in
#endif
            string path,
#if WAPICP3
            in
#endif
            FileAttributes fileAttributes,
#if WAPICP3
            in
#endif
            GetFileInfoOptions options, out int exeType)
        {
            var psfi = new SHFILEINFO();

            HResult hr = SHGetFileInfo(path, fileAttributes, ref psfi, (uint)Marshal.SizeOf(psfi), options);

            if (!Succeeded(hr))

                CoreErrorHelper.ThrowExceptionForHResult(hr);

            exeType = options.HasFlag(GetFileInfoOptions.ExeType) ? (int)hr : 0;

            Icon icon;

            if (psfi.hIcon == IntPtr.Zero)

                icon = null;

            else
            {
                icon = (Icon)Icon.FromHandle(psfi.hIcon).Clone();

                _ = Core.DestroyIcon(psfi.hIcon);
            }

            return new FileInfo(icon, psfi.iIcon, psfi.dwAttributes, psfi.szDisplayName, psfi.szTypeName);
        }

        public static void CopyFile(
#if WAPICP3
            in
#endif
            string sourceFileName,
#if WAPICP3
            in
#endif
            string newFileName,
#if WAPICP3
            in
#endif
            CopyProgressRoutine progressRoutine,
#if WAPICP3
            in
#endif
            IntPtr data, ref bool cancel,
#if WAPICP3
            in
#endif
            CopyFileFlags copyFlags)
        {
            if (copyFlags == CopyFileFlags.CopySymLink || copyFlags == CopyFileFlags.NoBuffering)

                CoreHelpers.ThrowIfNotVista();

            if (!CopyFileEx(sourceFileName, newFileName, progressRoutine, data, ref cancel, copyFlags))

                ThrowExceptionForHResult(Marshal.GetHRForLastWin32Error());
        }

        /// <summary>
        /// Queries the size and the number of items in the Recycle Bin.
        /// </summary>
        /// <param name="drivePath">The path to the Recycle Bin drive. Leave this parameter null or empty if you want to get the info for the Recycle Bins for all drives.</param>
        /// <param name="recycleBinInfo">The out Recycle Bin info</param>
        /// <returns><see langword="true"/> if the drive supports the Recycle Bin, otherwise <see langword="false"/>.</returns>
        /// <exception cref="Win32Exception">Exception thrown if a Win32 exception has occurred during thr process.</exception>
        public static bool QueryRecycleBinInfo(
#if WAPICP3
            in
#endif
            string drivePath, out RecycleBinInfo recycleBinInfo)
        {
            var rbInfo = new SHQUERYRBINFO
#if CS7
            {
                cbSize = Marshal.SizeOf<SHQUERYRBINFO>()
            };
#else
                ();

            rbInfo.cbSize = Marshal.SizeOf(rbInfo);
#endif

            HResult hr = SHQueryRecycleBin(drivePath, ref rbInfo);

            if (hr == HResult.Ok)
            {
                recycleBinInfo = new RecycleBinInfo(rbInfo.i64Size, rbInfo.i64NumItems);

                return true;
            }

            else if (hr == HResult.Fail)
            {
                recycleBinInfo = default;

                return false;
            }

            else

                CoreErrorHelper.ThrowExceptionForHResult(hr);

            recycleBinInfo = default;

            return false;
        }

        /// <summary>
        /// Empties the Recycle Bin.
        /// </summary>
        /// <param name="windowHandle">A handle to the owner window</param>
        /// <param name="drivePath">The path to the Recycle Bin drive. Leave this parameter null or empty if you want to get the info for the Recycle Bins for all drives.</param>
        /// <param name="emptyRecycleBinFlags">Flags to describe the behavior for the process.</param>
        /// <returns><see langword="true"/> if the drive supports the Recycle Bin, otherwise <see langword="false"/>.</returns>
        /// <exception cref="Win32Exception">Exception thrown if a Win32 exception has occurred during thr process.</exception>
        public static bool EmptyRecycleBin(
#if WAPICP3
            in
#endif
            IntPtr windowHandle,
#if WAPICP3
            in
#endif
            string drivePath,
#if WAPICP3
            in
#endif
            EmptyRecycleBinFlags emptyRecycleBinFlags)
        {
            HResult hr = SHEmptyRecycleBin(windowHandle, drivePath, emptyRecycleBinFlags);

            if (hr == HResult.Ok) return true;

            else if (hr == HResult.Fail) return false;

            else CoreErrorHelper.ThrowExceptionForHResult(hr);

            return false;
        }

        /// <summary>
        /// Empties the Recycle Bin.
        /// </summary>
        /// <param name="window">The owner window</param>
        /// <param name="drivePath">The path to the Recycle Bin drive. Leave this parameter null or empty if you want to get the info for the Recycle Bins for all drives.</param>
        /// <param name="emptyRecycleBinFlags">Flags to describe the behavior for the process.</param>
        /// <returns><see langword="true"/> if the drive supports the Recycle Bin, otherwise <see langword="false"/>.</returns>
        /// <exception cref="Win32Exception">Exception thrown if a Win32 exception has occurred during thr process.</exception>
        public static bool EmptyRecycleBin(
#if WAPICP3
            in
#endif
            Form window,
#if WAPICP3
            in
#endif
            string drivePath,
#if WAPICP3
            in
#endif
            EmptyRecycleBinFlags emptyRecycleBinFlags)
        {
            HResult hr = SHEmptyRecycleBin(window.Handle, drivePath, emptyRecycleBinFlags);

            if (hr == HResult.Ok) return true;

            else if (hr == HResult.Fail) return false;

            else CoreErrorHelper.ThrowExceptionForHResult(hr);

            return false;
        }

        /// <summary>
        /// Empties the Recycle Bin.
        /// </summary>
        /// <param name="window">The owner window</param>
        /// <param name="drivePath">The path to the Recycle Bin drive. Leave this parameter null or empty if you want to get the info for the Recycle Bins for all drives.</param>
        /// <param name="emptyRecycleBinFlags">Flags to describe the behavior for the process.</param>
        /// <returns><see langword="true"/> if the drive supports the Recycle Bin, otherwise <see langword="false"/>.</returns>
        /// <exception cref="Win32Exception">Exception thrown if a Win32 exception has occurred during thr process.</exception>
        public static bool EmptyRecycleBin(
#if WAPICP3
            in
#endif
            Window window,
#if WAPICP3
            in
#endif
            string drivePath,
#if WAPICP3
            in
#endif
            EmptyRecycleBinFlags emptyRecycleBinFlags)
        {
            HResult hr = SHEmptyRecycleBin(new WindowInteropHelper(window).Handle, drivePath, emptyRecycleBinFlags);

            switch (hr)
            {
                case HResult.Ok:

                    return true;

                case HResult.Fail:

                    return false;
            }

            CoreErrorHelper.ThrowExceptionForHResult(hr);

            return false;
        }
    }

    public struct RecycleBinInfo
    {
        public long Size { get; }

        public long NumItems { get; }

        internal RecycleBinInfo(in long size, in long numItems)
        {
            Size = size;

            NumItems = numItems;
        }
    }

#if WAPICP3
    public delegate HResult PreNewItem(TransferSourceFlags dwFlags, IShellItem psiItem, string pszNewName);

    public delegate HResult PostNewItem(TransferSourceFlags dwFlags, IShellItem psiDestinationFolder, string pszNewName, string pszTemplateName, Microsoft.WindowsAPICodePack.Win32Native.Shell.FileAttributes dwFileAttributes, HResult hrNew, IShellItem psiNewItem);

    public delegate HResult PostRename(TransferSourceFlags dwFlags, IShellItem psiItem, string pszNewName, HResult hrRename, IShellItem psiNewlyCreated);

    public delegate HResult PreCopy(TransferSourceFlags dwFlags, IShellItem psiItem, IShellItem psiDestinationFolder, string pszNewName);

    public delegate HResult PostCopy(TransferSourceFlags dwFlags, IShellItem psiItem, IShellItem psiDestinationFolder, string pszNewName, HResult hrCopy, IShellItem psiNewlyCreated);

    public delegate HResult PreDelete(TransferSourceFlags dwFlags, IShellItem psiItem);

    public delegate HResult PostDelete(TransferSourceFlags dwFlags, IShellItem psiItem, HResult hrDelete, IShellItem psiNewlyCreated);

    public delegate HResult UpdateProgress(uint iWorkTotal, uint iWorkSoFar);

    public interface IFileOperationProgressSinkProvider
    {
        IFileOperationProgressSink GetFileOperationProgressSink();
    }

    public abstract class FileOperationProgressSinkAbstract : IFileOperationProgressSink, IFileOperationProgressSinkProvider
    {
        public abstract HResult StartOperations();
        public abstract HResult FinishOperations([In] HResult hr);
        public abstract HResult PreRenameItem([In, MarshalAs(UnmanagedType.U4)] TransferSourceFlags dwFlags, [In] IShellItem psiItem, [In, MarshalAs(UnmanagedType.LPWStr)] string pszNewName);
        public abstract HResult PostRenameItem([In, MarshalAs(UnmanagedType.U4)] TransferSourceFlags dwFlags, IShellItem psiItem, [In, MarshalAs(UnmanagedType.LPWStr)] string pszNewName, [In] HResult hrRename, [In] IShellItem psiNewlyCreated);
        public abstract HResult PreMoveItem([In, MarshalAs(UnmanagedType.U4)] TransferSourceFlags dwFlags, [In] IShellItem psiItem, [In] IShellItem psiDestinationFolder, [In, MarshalAs(UnmanagedType.LPWStr)] string pszNewName);
        public abstract HResult PostMoveItem([In, MarshalAs(UnmanagedType.U4)] TransferSourceFlags dwFlags, [In] IShellItem psiItem, [In] IShellItem psiDestinationFolder, [In, MarshalAs(UnmanagedType.LPWStr)] string pszNewName, [In] HResult hrMove, [In] IShellItem psiNewlyCreated);
        public abstract HResult PreCopyItem([In, MarshalAs(UnmanagedType.U4)] TransferSourceFlags dwFlags, [In] IShellItem psiItem, [In] IShellItem psiDestinationFolder, [In, MarshalAs(UnmanagedType.LPWStr)] string pszNewName);
        public abstract HResult PostCopyItem([In, MarshalAs(UnmanagedType.U4)] TransferSourceFlags dwFlags, [In] IShellItem psiItem, [In] IShellItem psiDestinationFolder, [In, MarshalAs(UnmanagedType.LPWStr)] string pszNewName, [In] HResult hrCopy, [In] IShellItem psiNewlyCreated);
        public abstract HResult PreDeleteItem([In, MarshalAs(UnmanagedType.U4)] TransferSourceFlags dwFlags, [In] IShellItem psiItem);
        public abstract HResult PostDeleteItem([In, MarshalAs(UnmanagedType.U4)] TransferSourceFlags dwFlags, [In] IShellItem psiItem, [In] HResult hrDelete, [In] IShellItem psiNewlyCreated);
        public abstract HResult PreNewItem([In, MarshalAs(UnmanagedType.U4)] TransferSourceFlags dwFlags, [In] IShellItem psiDestinationFolder, [In, MarshalAs(UnmanagedType.LPWStr)] string pszNewName);
        public abstract HResult PostNewItem([In, MarshalAs(UnmanagedType.U4)] TransferSourceFlags dwFlags, [In] IShellItem psiDestinationFolder, [In, MarshalAs(UnmanagedType.LPWStr)] string pszNewName, [In, MarshalAs(UnmanagedType.LPWStr)] string pszTemplateName, [In, MarshalAs(UnmanagedType.U4)] FileAttributes dwFileAttributes, [In] HResult hrNew, [In] IShellItem psiNewItem);
        public abstract HResult UpdateProgress([In, MarshalAs(UnmanagedType.U4)] uint iWorkTotal, [In, MarshalAs(UnmanagedType.U4)] uint iWorkSoFar);
        public abstract HResult ResetTimer();
        public abstract HResult PauseTimer();
        public abstract HResult ResumeTimer();

        IFileOperationProgressSink IFileOperationProgressSinkProvider.GetFileOperationProgressSink() => this;
    }
#endif

    public class FileOperationProgressSink : WinCopies.
#if !WAPICP3
        Util.
#endif
        DotNetFix.IDisposable
#if WAPICP3
        , IFileOperationProgressSinkProvider
#endif
    {
#if WAPICP3
        protected FileOperationProgressSinkDefault
#else
        internal FileOperationProgressSinkInternal
#endif
             InnerFileOperationProgressSink
        { get; private set; }

        public FileOperationProgressSink() => InnerFileOperationProgressSink = new
#if WAPICP3
            FileOperationProgressSinkDefault
#else
            FileOperationProgressSinkInternal
#endif
            (this);

        /// <summary>
        /// Gets or sets a delegate to call in the <see cref="FileOperation"/> class when file operations are starting.
        /// </summary>
        public
#if WAPICP3
            Func<HResult>
#else
Action
#endif
            StartOperations
        { get; set; }

        public
#if WAPICP3
            Func<HResult, HResult>
#else
Action
#endif
            FinishOperations
        { get; set; }

        public
#if WAPICP3
            PreNewItem
#else
            Action<uint, IShellItem, string>
#endif
          PreRenameItem
        { get; set; }

        public
#if WAPICP3
            PostRename
#else
            Action<uint, IShellItem, string, IShellItem>
#endif
        PostRenameItem
        { get; set; }

        public
#if WAPICP3
            PreCopy
#else
Action<uint, IShellItem, IShellItem, string>
#endif
            PreMoveItem
        { get; set; }

        public
#if WAPICP3
            PostCopy
#else
            Action<uint, IShellItem, IShellItem, string, IShellItem>
#endif
            PostMoveItem
        { get; set; }

        public
#if WAPICP3
            PreCopy
#else
            Action<uint, IShellItem, IShellItem, string>
#endif
            PreCopyItem
        { get; set; }

        public
#if WAPICP3
            PostCopy
#else
Action<uint, IShellItem, IShellItem, string, IShellItem>
#endif
            PostCopyItem
        { get; set; }

        public
#if WAPICP3
            PreDelete
#else
            Action<uint, IShellItem>
#endif
            PreDeleteItem
        { get; set; }

        public
#if WAPICP3
            PostDelete
#else
Action<uint, IShellItem, IShellItem>
#endif
            PostDeleteItem
        { get; set; }

        public
#if WAPICP3
            PreNewItem
#else
Action<uint, IShellItem, string>
#endif
            PreNewItem
        { get; set; }

        public
#if WAPICP3
            PostNewItem
#else
            Action<uint, IShellItem, string, string, FileAttributes, IShellItem>
#endif
            PostNewItem
        { get; set; }

        public
#if WAPICP3
            UpdateProgress
#else
            Action<uint, uint>
#endif
            UpdateProgress
        { get; set; }

        public
#if WAPICP3
            Func<HResult>
#else
Action
#endif
            ResetTimer
        { get; set; }

        public
#if WAPICP3
            Func<HResult>
#else
Action
#endif
       PauseTimer
        { get; set; }

        public
#if WAPICP3
            Func<HResult>
#else
Action
#endif
       ResumeTimer
        { get; set; }

        public IFileOperationProgressSink GetFileOperationProgressSink() => InnerFileOperationProgressSink;

        #region IDisposable Support
        public bool IsDisposed => InnerFileOperationProgressSink == null;

        protected virtual void Dispose(bool disposing)
        {
            // if (!disposedValue)
            // {
            if (disposing)

                foreach (System.Reflection.PropertyInfo prop in this.GetType().GetProperties())

                    prop.SetValue(this, null);

            InnerFileOperationProgressSink = null;

            // disposedValue = true;
            // }
        }

        ~FileOperationProgressSink() => Dispose(false);

        public void Dispose()
        {
            if (IsDisposed)

                return;

            Dispose(true);

            GC.SuppressFinalize(this);
        }
        #endregion
    }

#if WAPICP3
    public class FileOperationProgressSinkDefault : FileOperationProgressSinkAbstract
    {
        protected FileOperationProgressSink FileOperationProgressSink { get; }

        public FileOperationProgressSinkDefault(FileOperationProgressSink fileOperationProgressSink) => FileOperationProgressSink = fileOperationProgressSink;

        // todo: replace by a call to WinCopies.Util.GetValue.

        private static HResult GetHResult(in HResult? value) => value ?? HResult.Ok;
        private static HResult GetHResult(Func<HResult> value) => value == null ? HResult.Ok : value();
        private static HResult GetHResult<T>(in Func<T, HResult> value, in T param) => value == null ? HResult.Ok : value(param);

        public override HResult StartOperations() => GetHResult(FileOperationProgressSink.StartOperations);

        public override HResult FinishOperations([In] HResult hr) => GetHResult(FileOperationProgressSink.FinishOperations, hr);

        public override HResult PreRenameItem([In, MarshalAs(UnmanagedType.U4)] TransferSourceFlags dwFlags, [In] IShellItem psiItem, [In, MarshalAs(UnmanagedType.LPWStr)] string pszNewName) => GetHResult(FileOperationProgressSink.PreRenameItem?.Invoke(dwFlags, psiItem, pszNewName));

        public override HResult PostRenameItem([In, MarshalAs(UnmanagedType.U4)] TransferSourceFlags dwFlags, IShellItem psiItem, [In, MarshalAs(UnmanagedType.LPWStr)] string pszNewName, [In] HResult hrRename, [In] IShellItem psiNewlyCreated) => GetHResult(FileOperationProgressSink.PostRenameItem?.Invoke(dwFlags, psiItem, pszNewName, hrRename, psiNewlyCreated));

        public override HResult PreMoveItem([In, MarshalAs(UnmanagedType.U4)] TransferSourceFlags dwFlags, [In] IShellItem psiItem, [In] IShellItem psiDestinationFolder, [In, MarshalAs(UnmanagedType.LPWStr)] string pszNewName) => GetHResult(FileOperationProgressSink.PreMoveItem?.Invoke(dwFlags, psiItem, psiDestinationFolder, pszNewName));

        public override HResult PostMoveItem([In, MarshalAs(UnmanagedType.U4)] TransferSourceFlags dwFlags, [In] IShellItem psiItem, [In] IShellItem psiDestinationFolder, [In, MarshalAs(UnmanagedType.LPWStr)] string pszNewName, [In] HResult hrMove, [In] IShellItem psiNewlyCreated) => GetHResult(FileOperationProgressSink.PostMoveItem?.Invoke(dwFlags, psiItem, psiDestinationFolder, pszNewName, hrMove, psiNewlyCreated));

        public override HResult PreCopyItem([In, MarshalAs(UnmanagedType.U4)] TransferSourceFlags dwFlags, [In] IShellItem psiItem, [In] IShellItem psiDestinationFolder, [In, MarshalAs(UnmanagedType.LPWStr)] string pszNewName) => GetHResult(FileOperationProgressSink.PreCopyItem?.Invoke(dwFlags, psiItem, psiDestinationFolder, pszNewName));

        public override HResult PostCopyItem([In, MarshalAs(UnmanagedType.U4)] TransferSourceFlags dwFlags, [In] IShellItem psiItem, [In] IShellItem psiDestinationFolder, [In, MarshalAs(UnmanagedType.LPWStr)] string pszNewName, [In] HResult hrCopy, [In] IShellItem psiNewlyCreated) => GetHResult(FileOperationProgressSink.PostCopyItem?.Invoke(dwFlags, psiItem, psiDestinationFolder, pszNewName, hrCopy, psiNewlyCreated));

        public override HResult PreDeleteItem([In, MarshalAs(UnmanagedType.U4)] TransferSourceFlags dwFlags, [In] IShellItem psiItem) => GetHResult(FileOperationProgressSink.PreDeleteItem?.Invoke(dwFlags, psiItem));

        public override HResult PostDeleteItem([In, MarshalAs(UnmanagedType.U4)] TransferSourceFlags dwFlags, [In] IShellItem psiItem, [In] HResult hrDelete, [In] IShellItem psiNewlyCreated) => GetHResult(FileOperationProgressSink.PostDeleteItem(dwFlags, psiItem, hrDelete, psiNewlyCreated));

        public override HResult PreNewItem([In, MarshalAs(UnmanagedType.U4)] TransferSourceFlags dwFlags, [In] IShellItem psiDestinationFolder, [In, MarshalAs(UnmanagedType.LPWStr)] string pszNewName) => GetHResult(FileOperationProgressSink.PreNewItem?.Invoke(dwFlags, psiDestinationFolder, pszNewName));

        public override HResult PostNewItem([In, MarshalAs(UnmanagedType.U4)] TransferSourceFlags dwFlags, [In] IShellItem psiDestinationFolder, [In, MarshalAs(UnmanagedType.LPWStr)] string pszNewName, [In, MarshalAs(UnmanagedType.LPWStr)] string pszTemplateName, [In, MarshalAs(UnmanagedType.U4)] FileAttributes dwFileAttributes, [In] HResult hrNew, [In] IShellItem psiNewItem) => GetHResult(FileOperationProgressSink.PostNewItem?.Invoke(dwFlags, psiDestinationFolder, pszNewName, pszTemplateName, dwFileAttributes, hrNew, psiNewItem));

        public override HResult UpdateProgress([In, MarshalAs(UnmanagedType.U4)] uint iWorkTotal, [In, MarshalAs(UnmanagedType.U4)] uint iWorkSoFar) => GetHResult(FileOperationProgressSink.UpdateProgress?.Invoke(iWorkTotal, iWorkSoFar));

        public override HResult ResetTimer() => GetHResult(FileOperationProgressSink.ResetTimer);

        public override HResult PauseTimer() => GetHResult(FileOperationProgressSink.PauseTimer);

        public override HResult ResumeTimer() => GetHResult(FileOperationProgressSink.ResumeTimer);
    }
#else
    internal class FileOperationProgressSinkInternal : IFileOperationProgressSink
    {
        internal FileOperationProgressSink fileOperationProgressSink;

        public FileOperationProgressSinkInternal(FileOperationProgressSink fileOperationProgressSink) => this.fileOperationProgressSink = fileOperationProgressSink;

        public virtual void StartOperations() => fileOperationProgressSink.StartOperations?.Invoke(); /*return HResult.Ok;*/

        public virtual void FinishOperations(HResult hr)
        {
            if (!Succeeded(hr))

                CoreErrorHelper.ThrowExceptionForHResult(hr);

            fileOperationProgressSink.FinishOperations?.Invoke();

            //return hr;
        }

        public virtual void PreRenameItem(uint dwFlags, IShellItem psiItem, string pszNewName) => fileOperationProgressSink.PreRenameItem?.Invoke(dwFlags, psiItem, pszNewName); /*return HResult.Ok;*/

        public virtual void PostRenameItem(uint dwFlags, IShellItem psiItem, string pszNewName, HResult hrRename, IShellItem psiNewlyCreated)
        {
            if (!Succeeded(hrRename))

                CoreErrorHelper.ThrowExceptionForHResult(hrRename);

            fileOperationProgressSink.PostRenameItem?.Invoke(dwFlags, psiItem, pszNewName, psiNewlyCreated);

            // return hrRename;
        }

        public virtual void PreMoveItem(uint dwFlags, IShellItem psiItem, IShellItem psiDestinationFolder, string pszNewName) => fileOperationProgressSink.PreMoveItem?.Invoke(dwFlags, psiItem, psiDestinationFolder, pszNewName); /*return HResult.Ok;*/

        public virtual void PostMoveItem(uint dwFlags, IShellItem psiItem, IShellItem psiDestinationFolder, string pszNewName, HResult hrMove, IShellItem psiNewlyCreated)
        {
            if (!Succeeded(hrMove))

                CoreErrorHelper.ThrowExceptionForHResult(hrMove);

            fileOperationProgressSink.PostMoveItem?.Invoke(dwFlags, psiItem, psiDestinationFolder, pszNewName, psiNewlyCreated);

            // return hrMove;
        }

        public virtual void PreCopyItem(uint dwFlags, IShellItem psiItem, IShellItem psiDestinationFolder, string pszNewName) => fileOperationProgressSink.PreCopyItem?.Invoke(dwFlags, psiItem, psiDestinationFolder, pszNewName); /*return HResult.Ok;*/

        public virtual void PostCopyItem(uint dwFlags, IShellItem psiItem, IShellItem psiDestinationFolder, string pszNewName, HResult hrCopy, IShellItem psiNewlyCreated)
        {
            if (!Succeeded(hrCopy))

                CoreErrorHelper.ThrowExceptionForHResult(hrCopy);

            fileOperationProgressSink.PostCopyItem?.Invoke(dwFlags, psiItem, psiDestinationFolder, pszNewName, psiNewlyCreated);

            // return hrCopy;
        }

        public virtual void PreDeleteItem(uint dwFlags, IShellItem psiItem) => fileOperationProgressSink.PreDeleteItem?.Invoke(dwFlags, psiItem); /*return HResult.Ok;*/

        public virtual void PostDeleteItem(uint dwFlags, IShellItem psiItem, HResult hrDelete, IShellItem psiNewlyCreated)
        {
            if (!Succeeded(hrDelete))

                CoreErrorHelper.ThrowExceptionForHResult(hrDelete);

            fileOperationProgressSink.PostDeleteItem?.Invoke(dwFlags, psiItem, psiNewlyCreated);

            //return hrDelete;
        }

        public virtual void PreNewItem(uint dwFlags, IShellItem psiDestinationFolder, string pszNewName) => fileOperationProgressSink.PreNewItem?.Invoke(dwFlags, psiDestinationFolder, pszNewName); /*return HResult.Ok;*/

        public virtual void PostNewItem(uint dwFlags, IShellItem psiDestinationFolder, string pszNewName, string pszTemplateName, Microsoft.WindowsAPICodePack.Win32Native.Shell.FileAttributes dwFileAttributes, HResult hrNew, IShellItem psiNewItem)
        {
            if (!Succeeded(hrNew))

                CoreErrorHelper.ThrowExceptionForHResult(hrNew);

            fileOperationProgressSink.PostNewItem?.Invoke(dwFlags, psiDestinationFolder, pszNewName, pszTemplateName, dwFileAttributes, psiNewItem);

            //return hrNew;
        }

        public virtual void UpdateProgress(uint iWorkTotal, uint iWorkSoFar) => fileOperationProgressSink.UpdateProgress?.Invoke(iWorkTotal, iWorkSoFar); /*return HResult.Ok;*/

        public virtual void ResetTimer() => fileOperationProgressSink.ResetTimer?.Invoke(); /*return HResult.Ok;*/

        public virtual void PauseTimer() => fileOperationProgressSink.PauseTimer?.Invoke(); /*return HResult.Ok;*/

        public virtual void ResumeTimer() => fileOperationProgressSink.ResumeTimer?.Invoke(); /*return HResult.Ok;*/
    }
#endif
}
#endif
