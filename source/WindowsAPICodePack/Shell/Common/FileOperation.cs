using Microsoft.WindowsAPICodePack.Win32Native.Core;
using Microsoft.WindowsAPICodePack.Win32Native.Shell;
using Microsoft.WindowsAPICodePack.Win32Native.Shell.PropertySystem;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Interop;
using static Microsoft.WindowsAPICodePack.Win32Native.Shell.ShellNativeMethods;

namespace Microsoft.WindowsAPICodePack.Shell
{
    /// <summary>
    /// Provides methods to perform file system operations.
    /// </summary>
    public class FileOperation : IDisposable
    {

        private IFileOperation fileOperation = null;

        private bool disposed = false;

        List<uint> cookies = new List<uint>();

        public ReadOnlyCollection<uint> Cookies { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="FileOperation"/> class.
        /// </summary>
        public FileOperation()
        {
            fileOperation = (IFileOperation)Activator.CreateInstance(Type.GetTypeFromCLSID(new Guid("3ad05575-8857-4850-9277-11b85bdb8e09")));

            Cookies = new ReadOnlyCollection<uint>(cookies);
        }

        public void Dispose()
        {

            if (disposed) return;

            disposed = true;

            foreach (uint cookie in cookies)

                UnadviseInternal(cookie);

            Marshal.FinalReleaseComObject(fileOperation);

        }

        /// <summary>
        /// Enables a handler to provide status and error information for all operations.
        /// </summary>
        /// <param name="pfops">An <see cref="IFileOperationProgressSink"/> object to be used for progress status and error notifications.</param>
        /// <returns>A returned token that uniquely identifies this connection. The calling application uses this token later to delete the connection by passing it to <see cref="Unadvise"/>.</returns>
        /// <remarks>Several individual methods have the ability to declare their own progress sinks, which are redundant to the one set here. They are used when you only want to be given progress and error information for a specific operation.</remarks>
        /// <exception cref="ArgumentNullException">Exception thrown when a parameter is null.</exception>
        /// <exception cref="ObjectDisposedException">Exception thrown when this object is disposed.</exception>
        /// <exception cref="Win32Exception">Exception thrown when this method fails because of an error in the Win32 COM API implementation.</exception>
        public uint Advise(FileOperationProgressSink pfops)
        {

            if (pfops == null) throw new ArgumentNullException(nameof(pfops));

            if (disposed) throw new ObjectDisposedException(nameof(FileOperation));

            HResult hr = fileOperation.Advise(pfops.FileOperationProgressSinkInternal, out uint pdwCookie);

            if (CoreErrorHelper.Succeeded(hr))
            {

                cookies.Add(pdwCookie);

                return pdwCookie;

            }

            else throw new Win32Exception((int)hr);

        }

        /// <summary>
        /// Terminates an advisory connection previously established through <see cref="Advise"/>.
        /// </summary>
        /// <param name="dwCookie">The connection token that identifies the connection to delete. This value was originally retrieved by <see cref="Advise"/> when the connection was made.</param>
        /// <exception cref="ObjectDisposedException">Exception thrown when this object is disposed.</exception>
        /// <exception cref="Win32Exception">Exception thrown when this method fails because of an error in the Win32 COM API implementation.</exception>
        public void Unadvise(uint dwCookie)
        {

            if (disposed) throw new ObjectDisposedException(nameof(FileOperation));

            UnadviseInternal(dwCookie);

        }

        internal void UnadviseInternal(uint dwCookie)
        {

            HResult hr = fileOperation.Unadvise(dwCookie);

            if (!CoreErrorHelper.Succeeded(hr))

                throw new Win32Exception((int)hr);

        }

        /// <summary>
        /// Sets parameters for the current operation.
        /// </summary>
        /// <param name="dwOperationFlags">Flags that control the file operation. FOF flags are defined in Shellapi.h and FOFX flags are defined in Shobjidl.h. Note : If this method is not called, the default value used by the operation is <see cref=" ShellOperationFlags.FOF_ALLOWUNDO"/> | <see cref="ShellOperationFlags.FOF_NOCONFIRMMKDIR"/>.</param>
        /// <remarks>Set these flags before you call <see cref="PerformOperations"/> to define the parameters for whatever operations are being performed, such as copy, delete, or rename.</remarks>
        /// <exception cref="ObjectDisposedException">Exception thrown when this object is disposed.</exception>
        /// <exception cref="PlatformNotSupportedException">Exception thrown when a requested flag is not supported by the current platform.</exception>
        /// <exception cref="Win32Exception">Exception thrown when this method fails because of an error in the Win32 COM API implementation.</exception>
        public void SetOperationFlags(ShellOperationFlags dwOperationFlags)
        {

            if (disposed) throw new ObjectDisposedException(nameof(FileOperation));

            switch (dwOperationFlags)

            {

                case ShellOperationFlags.FOFX_ADDUNDORECORD:
                case ShellOperationFlags.FOFX_RECYCLEONDELETE:

                    CoreHelpers.ThrowIfNotWin8();

                    break;

                case ShellOperationFlags.FOFX_COPYASDOWNLOAD:
                case ShellOperationFlags.FOFX_DONTDISPLAYLOCATIONS:

                    CoreHelpers.ThrowIfNotWin7();

                    break;

                case ShellOperationFlags.FOFX_REQUIREELEVATION:

                    CoreHelpers.ThrowIfNotVista();

                    break;

            }

            HResult hr = fileOperation.SetOperationFlags(dwOperationFlags);

            if (!CoreErrorHelper.Succeeded(hr))

                throw new Win32Exception((int)hr);

        }

        /// <summary>
        /// Not implemented.
        /// </summary>
        /// <param name="pszMessage">The window title.</param>
        /// <exception cref="ObjectDisposedException">Exception thrown when this object is disposed.</exception>
        /// <exception cref="Win32Exception">Exception thrown when this method fails because of an error in the Win32 COM API implementation.</exception>
        public void SetProgressMessage(string pszMessage)
        {

            if (disposed) throw new ObjectDisposedException(nameof(FileOperation));

            HResult hr = fileOperation.SetProgressMessage(pszMessage);

            if (!CoreErrorHelper.Succeeded(hr))

                throw new Win32Exception((int)hr);

        }

        // todo: to encapsulate

        /// <summary>
        /// Specifies a dialog box used to display the progress of the operation.
        /// </summary>
        /// <param name="popd">An <see cref="IOperationsProgressDialog"/> object that represents the dialog box.</param>
        /// <exception cref="ArgumentNullException">Exception thrown when a parameter is null.</exception>
        /// <exception cref="Win32Exception">Exception thrown when this method fails because of an error in the Win32 COM API implementation.</exception>
        public void SetProgressDialog(IOperationsProgressDialog popd)
        {

            if (popd == null) throw new ArgumentNullException(nameof(popd));

            if (disposed) throw new ObjectDisposedException(nameof(FileOperation));

            HResult hr = fileOperation.SetProgressDialog(popd);

            if (!CoreErrorHelper.Succeeded(hr))

                throw new Win32Exception((int)hr);

        }

        // todo: to encapsulate

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
        public void SetProperties(IPropertyChangeArray pproparray)
        {

            if (pproparray == null) throw new ArgumentNullException(nameof(pproparray));

            if (disposed) throw new ObjectDisposedException(nameof(FileOperation));

            HResult hr = fileOperation.SetProperties(pproparray);

            if (!CoreErrorHelper.Succeeded(hr))

                throw new Win32Exception((int)hr);

        }

        public void SetOwnerWindow(IntPtr hwndOwner)
        {

            if (disposed) throw new ObjectDisposedException(nameof(FileOperation));

            HResult hr = fileOperation.SetOwnerWindow(hwndOwner);

            if (!CoreErrorHelper.Succeeded(hr))

                throw new Win32Exception((int)hr);

        }

        public void SetOwnerWindow(System.Windows.Forms.Form window) => SetOwnerWindow(window.Handle);

        public void SetOwnerWindow(System.Windows.Window window) => SetOwnerWindow(new WindowInteropHelper(window).Handle);

        public void ApplyPropertiesToItem(IShellItem psiItem)
        {

            if (disposed) throw new ObjectDisposedException(nameof(FileOperation));

            HResult hr = fileOperation.ApplyPropertiesToItem(psiItem);

            // todo: to add error wrappers using the return error code

            if (!CoreErrorHelper.Succeeded(hr))

                throw new Win32Exception((int)hr);

        }

        public void ApplyPropertiesToItem(ShellObject shellObject) => ApplyPropertiesToItem(shellObject.NativeShellItem);

        //public HResult ApplyPropertiesToItems(object punkItems)
        //{
        //    throw new NotImplementedException();
        //}

        public void RenameItem(IShellItem psiItem, string pszNewName, FileOperationProgressSink pfopsItem)
        {

            if (disposed) throw new ObjectDisposedException(nameof(FileOperation));

            HResult hr = fileOperation.RenameItem(psiItem, pszNewName, pfopsItem?.FileOperationProgressSinkInternal);

            if (!CoreErrorHelper.Succeeded(hr))

                throw new Win32Exception((int)hr);

        }

        public void RenameItem(ShellObject shellObject, string newName, FileOperationProgressSink pfopsItem) => RenameItem(shellObject.NativeShellItem, newName, pfopsItem);

        //public HResult RenameItems(object pUnkItems, string pszNewName)
        //{
        //    throw new NotImplementedException();
        //}

        public void MoveItem(IShellItem psiItem, IShellItem psiDestinationFolder, string pszNewName, FileOperationProgressSink pfopsItem)
        {

            if (disposed) throw new ObjectDisposedException(nameof(FileOperation));

            HResult hr = fileOperation.MoveItem(psiItem, psiDestinationFolder, pszNewName, pfopsItem?.FileOperationProgressSinkInternal);

            if (!CoreErrorHelper.Succeeded(hr))

                throw new Win32Exception((int)hr);

        }

        public void MoveItem(ShellObject shellObject, ShellObject destinationShellObject, string newName, FileOperationProgressSink pfopsItem) => MoveItem(shellObject.NativeShellItem, destinationShellObject.NativeShellItem, newName, pfopsItem);

        //public HResult MoveItems(object punkItems, IShellItem psiDestinationFolder) => throw new NotImplementedException();

        public void CopyItem(IShellItem psiItem, IShellItem psiDestinationFolder, string pszCopyName, FileOperationProgressSink pfopsItem)
        {

            if (disposed) throw new ObjectDisposedException(nameof(FileOperation));

            HResult hr = fileOperation.CopyItem(psiItem, psiDestinationFolder, pszCopyName, pfopsItem?.FileOperationProgressSinkInternal);

            if (!CoreErrorHelper.Succeeded(hr))

                throw new Win32Exception((int)hr);

        }

        public void CopyItem(ShellObject shellObject, ShellObject destinationFolder, string copyName, FileOperationProgressSink pfopsItem) => CopyItem(shellObject.NativeShellItem, destinationFolder.NativeShellItem, copyName, pfopsItem);

        //public HResult CopyItems(object punkItems, IShellItem psiDestinationFolder) => throw new NotImplementedException();

        public void DeleteItem(IShellItem psiItem, FileOperationProgressSink pfopsItem)
        {

            if (disposed) throw new ObjectDisposedException(nameof(FileOperation));

            HResult hr = fileOperation.DeleteItem(psiItem, pfopsItem?.FileOperationProgressSinkInternal);

            if (!CoreErrorHelper.Succeeded(hr))

                throw new Win32Exception((int)hr);

        }

        public void DeleteItem(ShellObject shellObject, FileOperationProgressSink pfopsItem) => DeleteItem(shellObject.NativeShellItem, pfopsItem);

        //public HResult DeleteItems(object punkItems) => throw new NotImplementedException();

        public void NewItem(IShellItem psiDestinationFolder, FileAttributes dwFileAttributes, string pszName, string pszTemplateName, FileOperationProgressSink pfopsItem)
        {

            if (disposed) throw new ObjectDisposedException(nameof(FileOperation));

            HResult hr = fileOperation.NewItem(psiDestinationFolder, dwFileAttributes, pszName, pszTemplateName, pfopsItem?.FileOperationProgressSinkInternal);

            if (!CoreErrorHelper.Succeeded(hr))

                throw new Win32Exception((int)hr);

        }

        public void NewItem(ShellObject destinationFolder, FileAttributes fileAttributes, string name, string templateName, FileOperationProgressSink pfopsItem) => NewItem(destinationFolder.NativeShellItem, fileAttributes, name, templateName, pfopsItem);

        public void PerformOperations()
        {

            if (disposed) throw new ObjectDisposedException(nameof(FileOperation));

            HResult hr = fileOperation.PerformOperations();

            if (!CoreErrorHelper.Succeeded(hr))

                throw new Win32Exception((int)hr);

        }

        public bool GetAnyOperationsAborted()
        {

            if (disposed) throw new ObjectDisposedException(nameof(FileOperation));

            HResult hr = fileOperation.GetAnyOperationsAborted(out bool anyOperationsAborted);

            if (CoreErrorHelper.Succeeded(hr)) return anyOperationsAborted;

            else throw new Win32Exception((int)hr);

        }

        /// <summary>
        /// Queries the size and the number of items in the Recycle Bin.
        /// </summary>
        /// <param name="drivePath">The path to the Recycle Bin drive. Leave this parameter null or empty if you want to get the info for the Recycle Bins for all drives.</param>
        /// <param name="recycleBinInfo">The out Recycle Bin info</param>
        /// <returns><see langword="true"/> if the drive supports the Recycle Bin, otherwise <see langword="false"/>.</returns>
        /// <exception cref="Win32Exception">Exception thrown if a Win32 exception has occurred during thr process.</exception>
        public static bool QueryRecycleBinInfo(string drivePath, out RecycleBinInfo recycleBinInfo)
        {

            ShellNativeMethods.SHQUERYRBINFO rbInfo = new ShellNativeMethods.SHQUERYRBINFO
            {
                cbSize = Marshal.SizeOf(typeof(ShellNativeMethods.SHQUERYRBINFO))
            };

            HResult hr = ShellNativeMethods.SHQueryRecycleBin(drivePath, ref rbInfo);

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

                throw new Win32Exception((int)hr);

        }

        /// <summary>
        /// Empties the Recycle Bin.
        /// </summary>
        /// <param name="windowHandle">A handle to the owner window</param>
        /// <param name="drivePath">The path to the Recycle Bin drive. Leave this parameter null or empty if you want to get the info for the Recycle Bins for all drives.</param>
        /// <param name="emptyRecycleBinFlags">Flags to describe the behavior for the process.</param>
        /// <returns><see langword="true"/> if the drive supports the Recycle Bin, otherwise <see langword="false"/>.</returns>
        /// <exception cref="Win32Exception">Exception thrown if a Win32 exception has occurred during thr process.</exception>
        public static bool EmptyRecycleBin(IntPtr windowHandle, string drivePath, EmptyRecycleBinFlags emptyRecycleBinFlags)
        {

            HResult hr = SHEmptyRecycleBin(windowHandle, drivePath, emptyRecycleBinFlags);

            if (hr == HResult.Ok) return true;

            else if (hr == HResult.Fail) return false;

            else throw new Win32Exception((int)hr);

        }

        /// <summary>
        /// Empties the Recycle Bin.
        /// </summary>
        /// <param name="window">The owner window</param>
        /// <param name="drivePath">The path to the Recycle Bin drive. Leave this parameter null or empty if you want to get the info for the Recycle Bins for all drives.</param>
        /// <param name="emptyRecycleBinFlags">Flags to describe the behavior for the process.</param>
        /// <returns><see langword="true"/> if the drive supports the Recycle Bin, otherwise <see langword="false"/>.</returns>
        /// <exception cref="Win32Exception">Exception thrown if a Win32 exception has occurred during thr process.</exception>
        public static bool EmptyRecycleBin(Form window, string drivePath, EmptyRecycleBinFlags emptyRecycleBinFlags)
        {

            HResult hr = SHEmptyRecycleBin(window.Handle, drivePath, emptyRecycleBinFlags);

            if (hr == HResult.Ok) return true;

            else if (hr == HResult.Fail) return false;

            else throw new Win32Exception((int)hr);

        }

        /// <summary>
        /// Empties the Recycle Bin.
        /// </summary>
        /// <param name="window">The owner window</param>
        /// <param name="drivePath">The path to the Recycle Bin drive. Leave this parameter null or empty if you want to get the info for the Recycle Bins for all drives.</param>
        /// <param name="emptyRecycleBinFlags">Flags to describe the behavior for the process.</param>
        /// <returns><see langword="true"/> if the drive supports the Recycle Bin, otherwise <see langword="false"/>.</returns>
        /// <exception cref="Win32Exception">Exception thrown if a Win32 exception has occurred during thr process.</exception>
        public static bool EmptyRecycleBin(Window window, string drivePath, EmptyRecycleBinFlags emptyRecycleBinFlags)
        {

            HResult hr = SHEmptyRecycleBin(new WindowInteropHelper(window).Handle, drivePath, emptyRecycleBinFlags);

            if (hr == HResult.Ok) return true;

            else if (hr == HResult.Fail) return false;

            else throw new Win32Exception((int)hr);

        }
    }

    public struct RecycleBinInfo
    {

        public long Size { get; }

        public long NumItems { get; }

        internal RecycleBinInfo(long size, long numItems)
        {

            Size = size;

            NumItems = numItems;

        }

    }

    public class FileOperationProgressSink : IDisposable
    {
        internal FileOperationProgressSinkInternal FileOperationProgressSinkInternal { get; }

        public FileOperationProgressSink() => FileOperationProgressSinkInternal = new FileOperationProgressSinkInternal(this);

        /// <summary>
        /// Gets or sets a delegate to call in the <see cref="FileOperation"/> class when file operations are starting.
        /// </summary>
        public Action StartOperations { get; set; }

        public Action FinishOperations { get; set; }

        public Action<uint, IShellItem, string> PreRenameItem { get; set; }

        public Action<uint, IShellItem, string, IShellItem> PostRenameItem { get; set; }

        public Action<uint, IShellItem, IShellItem, string> PreMoveItem { get; set; }

        public Action<uint, IShellItem, IShellItem, string, IShellItem> PostMoveItem { get; set; }

        public Action<uint, IShellItem, IShellItem, string> PreCopyItem { get; set; }

        public Action<uint, IShellItem, IShellItem, string, IShellItem> PostCopyItem { get; set; }

        public Action<uint, IShellItem> PreDeleteItem { get; set; }

        public Action<uint, IShellItem, IShellItem> PostDeleteItem { get; set; }

        public Action<uint, IShellItem, string> PreNewItem { get; set; }

        public Action<uint, IShellItem, string, string, FileAttributes, IShellItem> PostNewItem { get; set; }

        public Action<uint, uint> UpdateProgress { get; set; }

        public Action ResetTimer { get; set; }

        public Action PauseTimer { get; set; }

        public Action ResumeTimer { get; set; }

        public void Dispose() => throw new NotImplementedException();
    }

    internal class FileOperationProgressSinkInternal : IFileOperationProgressSink
    {
        internal FileOperationProgressSink fileOperationProgressSink;

        public FileOperationProgressSinkInternal(FileOperationProgressSink fileOperationProgressSink) => this.fileOperationProgressSink = fileOperationProgressSink;

        public virtual void StartOperations() => fileOperationProgressSink.StartOperations?.Invoke(); /*return HResult.Ok;*/

        public virtual void FinishOperations(HResult hr)
        {
            if (!CoreErrorHelper.Succeeded(hr))

                throw new Win32Exception((int)hr);

            fileOperationProgressSink.FinishOperations?.Invoke();

            //return hr;
        }

        public virtual void PreRenameItem(uint dwFlags, IShellItem psiItem, string pszNewName) => fileOperationProgressSink.PreRenameItem?.Invoke(dwFlags, psiItem, pszNewName); /*return HResult.Ok;*/

        public virtual void PostRenameItem(uint dwFlags, IShellItem psiItem, string pszNewName, HResult hrRename, IShellItem psiNewlyCreated)
        {
            if (!CoreErrorHelper.Succeeded(hrRename))

                throw new Win32Exception((int)hrRename);

            fileOperationProgressSink.PostRenameItem?.Invoke(dwFlags, psiItem, pszNewName, psiNewlyCreated);

            // return hrRename;
        }

        public virtual void PreMoveItem(uint dwFlags, IShellItem psiItem, IShellItem psiDestinationFolder, string pszNewName) => fileOperationProgressSink.PreMoveItem?.Invoke(dwFlags, psiItem, psiDestinationFolder, pszNewName); /*return HResult.Ok;*/

        public virtual void PostMoveItem(uint dwFlags, IShellItem psiItem, IShellItem psiDestinationFolder, string pszNewName, HResult hrMove, IShellItem psiNewlyCreated)
        {
            if (!CoreErrorHelper.Succeeded(hrMove))

                throw new Win32Exception((int)hrMove);

            fileOperationProgressSink.PostMoveItem?.Invoke(dwFlags, psiItem, psiDestinationFolder, pszNewName, psiNewlyCreated);

            // return hrMove;
        }

        public virtual void PreCopyItem(uint dwFlags, IShellItem psiItem, IShellItem psiDestinationFolder, string pszNewName) => fileOperationProgressSink.PreCopyItem?.Invoke(dwFlags, psiItem, psiDestinationFolder, pszNewName); /*return HResult.Ok;*/

        public virtual void PostCopyItem(uint dwFlags, IShellItem psiItem, IShellItem psiDestinationFolder, string pszNewName, HResult hrCopy, IShellItem psiNewlyCreated)
        {

            if (!CoreErrorHelper.Succeeded(hrCopy))

                throw new Win32Exception((int)hrCopy);

            fileOperationProgressSink.PostCopyItem?.Invoke(dwFlags, psiItem, psiDestinationFolder, pszNewName, psiNewlyCreated);

            // return hrCopy;

        }

        public virtual void PreDeleteItem(uint dwFlags, IShellItem psiItem) => fileOperationProgressSink.PreDeleteItem?.Invoke(dwFlags, psiItem); /*return HResult.Ok;*/

        public virtual void PostDeleteItem(uint dwFlags, IShellItem psiItem, HResult hrDelete, IShellItem psiNewlyCreated)
        {

            if (!CoreErrorHelper.Succeeded(hrDelete))

                throw new Win32Exception((int)hrDelete);

            fileOperationProgressSink.PostDeleteItem?.Invoke(dwFlags, psiItem, psiNewlyCreated);

            //return hrDelete;

        }

        public virtual void PreNewItem(uint dwFlags, IShellItem psiDestinationFolder, string pszNewName) => fileOperationProgressSink.PreNewItem?.Invoke(dwFlags, psiDestinationFolder, pszNewName); /*return HResult.Ok;*/

        public virtual void PostNewItem(uint dwFlags, IShellItem psiDestinationFolder, string pszNewName, string pszTemplateName, FileAttributes dwFileAttributes, HResult hrNew, IShellItem psiNewItem)
        {

            if (!CoreErrorHelper.Succeeded(hrNew))

                throw new Win32Exception((int)hrNew);

            fileOperationProgressSink.PostNewItem?.Invoke(dwFlags, psiDestinationFolder, pszNewName, pszTemplateName, dwFileAttributes, psiNewItem);

            //return hrNew;

        }

        public virtual void UpdateProgress(uint iWorkTotal, uint iWorkSoFar) => fileOperationProgressSink.UpdateProgress?.Invoke(iWorkTotal, iWorkSoFar); /*return HResult.Ok;*/

        public virtual void ResetTimer() => fileOperationProgressSink.ResetTimer?.Invoke(); /*return HResult.Ok;*/

        public virtual void PauseTimer() => fileOperationProgressSink.PauseTimer?.Invoke(); /*return HResult.Ok;*/

        public virtual void ResumeTimer() => fileOperationProgressSink.ResumeTimer?.Invoke(); /*return HResult.Ok;*/
    }
}
