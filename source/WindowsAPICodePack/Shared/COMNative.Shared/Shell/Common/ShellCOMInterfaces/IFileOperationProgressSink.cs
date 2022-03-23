//Copyright (c) Microsoft Corporation.  All rights reserved.  Distributed under the Microsoft Public License (MS-PL)

using Microsoft.WindowsAPICodePack.Win32Native;
using Microsoft.WindowsAPICodePack.Win32Native.Shell;

using System;
using System.Runtime.InteropServices;

using static System.Runtime.InteropServices.UnmanagedType;

namespace Microsoft.WindowsAPICodePack.COMNative.Shell
{
    [Flags]
    public enum TransferSourceFlags : uint
    {
        /// <summary>
        /// Fail if the destination already exists, unless <see cref="OverwriteExist"/> is specified. This is a default behavior.
        /// </summary>
        Normal = 0,

        /// <summary>
        /// See <see cref="Normal"/>.
        /// </summary>
        FailExist = Normal,

        /// <summary>
        /// Rename with auto-name generation if the destination already exists.
        /// </summary>
        RenameExist = 0x1,

        /// <summary>
        /// Overwrite or merge with the destination.
        /// </summary>
        OverwriteExist = 0x2,

        /// <summary>
        /// Allow creation of a decrypted destination.
        /// </summary>
        AllowDecryption = 0x4,

        /// <summary>
        /// No discretionary access control list (DACL), system access control list (SACL), or owner.
        /// </summary>
        NoSecurity = 0x8,

        /// <summary>
        /// Copy the creation time as part of the copy. This can be useful for a move operation that is being used as a copy and delete operation (<see cref="MoveAsCopyDelete"/>).
        /// </summary>
        CopyCreationTime = 0x10,

        /// <summary>
        /// Copy the last write time as part of the copy.
        /// </summary>
        CopyWriteTime = 0x20,

        /// <summary>
        /// Assign write, read, and delete permissions as share mode.
        /// </summary>
        UseFullAccess = 0x40,

        /// <summary>
        /// Recycle on file delete, if possible.
        /// </summary>
        DeleteRecycleIfPossible = 0x80,

        /// <summary>
        /// Hard link to the desired source (not required). This avoids a normal copy operation.
        /// </summary>
        CopyHardLink = 0x100,

        /// <summary>
        /// Copy the localized name.
        /// </summary>
        CopyLocalizedName = 0x200,

        /// <summary>
        /// Move as a copy and delete operation.
        /// </summary>
        MoveAsCopyDelete = 0x400,

        /// <summary>
        /// Suspend Shell events.
        /// </summary>
        SuspendShellEvents = 0x800
    }

    /// <summary>
    /// Exposes methods that provide a rich notification system used by callers of <see cref="IFileOperation"/> to monitor the details of the operations they are performing through that interface.
    /// </summary>
    [ComImport,
    Guid("04B0F1A7-9490-44BC-96E1-4296A31252E2"),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IFileOperationProgressSink
    {
        /// <summary>
        /// Performs caller-implemented actions before any specific file operations are performed.
        /// </summary>
        /// <returns>If this method succeeds, it returns <see cref="HResult.Ok"/>. Otherwise, it returns an <see cref="HResult"/> error code.</returns>
        /// <remarks>StartOperations is the first of the <see cref="IFileOperationProgressSink"/> methods to be called after <see cref="IFileOperation.PerformOperations"/>. It can be used to perform any setup or initialization that you require before the file operations begin.</remarks>
#if WAPICP3
        HResult
#else
        void
#endif
            StartOperations();

        /// <summary>
        /// Performs caller-implemented actions after the last operation performed by the call to <see cref="IFileOperation"/> is complete.
        /// </summary>
        /// <param name="hr">The return value of the final operation. Note that this is not the <see cref="HResult"/> returned by one of the <see cref="IFileOperation"/> methods, which simply queue the operations. Instead, this is the result of the actual operation, such as copy, delete, or move.</param>
        /// <returns>Not used.</returns>

#if WAPICP3
        HResult
#else
        void
#endif
             FinishOperations([In] HResult hr);

        /// <summary>
        /// Performs caller-implemented actions before the rename process for each item begins.
        /// </summary>
        /// <param name="dwFlags">Bitwise value that contains flags that control the operation.</param>
        /// <param name="psiItem">Pointer to an <see cref="IShellItem"/> that specifies the item to be renamed.</param>
        /// <param name="pszNewName">Pointer to the new <a href="https://msdn.microsoft.com/9b159be9-3797-4c8b-90f8-9d3b3a3afb71">display name</a> of the item. This is a null-terminated, Unicode string.</param>
        /// <returns>Returns <see cref="HResult.Ok"/> if successful, or an error value otherwise. In the case of an error value, the rename operation and all subsequent operations pending from the call to <see cref="IFileOperation"/> are canceled.</returns>

#if WAPICP3
        HResult
#else
        void
#endif
             PreRenameItem([In, MarshalAs(U4)]
#if WAPICP3
             TransferSourceFlags
#else
uint
#endif
        dwFlags, [In] IShellItem psiItem, [In, MarshalAs(LPWStr)] string pszNewName);

        /// <summary>
        /// Performs caller-implemented actions after the rename process for each item is complete.
        /// </summary>
        /// <param name="dwFlags">Bitwise value that contains flags that were used during the rename operation. Some values can be set or changed during the rename operation.</param>
        /// <param name="psiItem">Pointer to an <see cref="IShellItem"/> that specifies the item before it was renamed.</param>
        /// <param name="pszNewName">Pointer to the new <a href="https://msdn.microsoft.com/9b159be9-3797-4c8b-90f8-9d3b3a3afb71">display name</a> of the item. This is a null-terminated, Unicode string. Note that this might not be the name that you asked for, given collisions and other naming rules.</param>
        /// <param name="hrRename">The return value of the rename operation. Note that this is not the HRESULT returned by <see cref="IFileOperation.RenameItem"/>, which simply queues the rename operation. Instead, this is the result of the actual rename operation.</param>
        /// <param name="psiNewlyCreated">Pointer to an <see cref="IShellItem"/> that represents the item with its new name.</param>
        /// <returns>Returns <see cref="HResult.Ok"/> if successful, or an error value otherwise. In the case of an error value, all subsequent operations pending from the call to <see cref="IFileOperation"/> are canceled.</returns>

#if WAPICP3
        HResult
#else
        void
#endif
             PostRenameItem([In, MarshalAs(U4)]
#if WAPICP3
             TransferSourceFlags
#else
uint
#endif
       dwFlags, IShellItem psiItem, [In, MarshalAs(LPWStr)] string pszNewName, [In] HResult hrRename, [In] IShellItem psiNewlyCreated);

        /// <summary>
        /// Performs caller-implemented actions before the move process for each item begins.
        /// </summary>
        /// <param name="dwFlags">Bitwise value that contains flags that control the operation.</param>
        /// <param name="psiItem">Pointer to an <see cref="IShellItem"/> that specifies the item to be moved.</param>
        /// <param name="psiDestinationFolder">Pointer to an <see cref="IShellItem"/> that specifies the destination folder to contain the moved item.</param>
        /// <param name="pszNewName">Pointer to a new name for the item in its new location. This is a null-terminated Unicode string and can be <see langword="null"/>. If <see langword="null"/>, the name of the destination item is the same as the source.</param>
        /// <returns>Returns <see cref="HResult.Ok"/> if successful, or an error value otherwise. In the case of an error value, the move operation and all subsequent operations pending from the call to <see cref="IFileOperation"/> are canceled.</returns>

#if WAPICP3
        HResult
#else
        void
#endif
             PreMoveItem([In, MarshalAs(U4)]
#if WAPICP3
             TransferSourceFlags
#else
uint
#endif
       dwFlags, [In] IShellItem psiItem, [In] IShellItem psiDestinationFolder, [In, MarshalAs(LPWStr)] string pszNewName);

        /// <summary>
        /// Performs caller-implemented actions after the move process for each item is complete.
        /// </summary>
        /// <param name="dwFlags">Bitwise value that contains flags that were used during the move operation. Some values can be set or changed during the move operation.</param>
        /// <param name="psiItem">Pointer to an <see cref="IShellItem"/> that specifies the source item.</param>
        /// <param name="psiDestinationFolder">Pointer to an <see cref="IShellItem"/> that specifies the destination folder that contains the moved item.</param>
        /// <param name="pszNewName">Pointer to the name that was given to the item after it was moved. This is a null-terminated Unicode string. Note that this might not be the name that you asked for, given collisions and other naming rules.</param>
        /// <param name="hrMove">The return value of the move operation. Note that this is not the HRESULT returned by <see cref="IFileOperation.MoveItem"/>, which simply queues the move operation. Instead, this is the result of the actual move.</param>
        /// <param name="psiNewlyCreated">Pointer to an <see cref="IShellItem"/> that represents the moved item in its new location.</param>
        /// <returns>Returns <see cref="HResult.Ok"/> if successful, or an error value otherwise. In the case of an error value, all subsequent operations pending from the call to <see cref="IFileOperation"/> are canceled.</returns>

#if WAPICP3
        HResult
#else
        void
#endif
             PostMoveItem([In, MarshalAs(U4)]
#if WAPICP3
             TransferSourceFlags
#else
uint
#endif
       dwFlags, [In] IShellItem psiItem, [In] IShellItem psiDestinationFolder, [In, MarshalAs(LPWStr)] string pszNewName, [In] HResult hrMove, [In] IShellItem psiNewlyCreated);

        /// <summary>
        /// Performs caller-implemented actions before the copy process for each item begins.
        /// </summary>
        /// <param name="dwFlags">Bitwise value that contains flags that control the operation.</param>
        /// <param name="psiItem">Pointer to an <see cref="IShellItem"/> that specifies the source item.</param>
        /// <param name="psiDestinationFolder">Pointer to an <see cref="IShellItem"/> that specifies the destination folder to contain the copy of the item.</param>
        /// <param name="pszNewName">Pointer to a new name for the item after it has been copied. This is a null-terminated Unicode string and can be <see langword="null"/>. If <see langword="null"/>, the name of the destination item is the same as the source.</param>
        /// <returns>Returns <see cref="HResult.Ok"/> if successful, or an error value otherwise. In the case of an error value, the copy operation and all subsequent operations pending from the call to <see cref="IFileOperation"/> are canceled.</returns>

#if WAPICP3
        HResult
#else
        void
#endif
             PreCopyItem([In, MarshalAs(U4)]
#if WAPICP3
             TransferSourceFlags
#else
uint
#endif
       dwFlags, [In] IShellItem psiItem, [In] IShellItem psiDestinationFolder, [In, MarshalAs(LPWStr)] string pszNewName);

        /// <summary>
        /// Performs caller-implemented actions after the copy process for each item is complete.
        /// </summary>
        /// <param name="dwFlags">Bitwise value that contains flags that were used during the copy operation. Some values can be set or changed during the copy operation.</param>
        /// <param name="psiItem">Pointer to an <see cref="IShellItem"/> that specifies the source item.</param>
        /// <param name="psiDestinationFolder">Pointer to an <see cref="IShellItem"/> that specifies the destination folder to which the item was copied.</param>
        /// <param name="pszNewName">Pointer to the new name that was given to the item after it was copied. This is a null-terminated Unicode string. Note that this might not be the name that you asked for, given collisions and other naming rules.</param>
        /// <param name="hrCopy">The return value of the copy operation. Note that this is not the <see cref="HResult"/> returned by <see cref="IFileOperation.CopyItem"/>, which simply queues the copy operation. Instead, this is the result of the actual copy.</param>
        /// <param name="psiNewlyCreated">Pointer to an <see cref="IShellItem"/> that represents the new copy of the item.</param>
        /// <returns>Returns <see cref="HResult.Ok"/> if successful, or an error value otherwise. In the case of an error value, all subsequent operations pending from the call to <see cref="IFileOperation"/> are canceled.</returns>

#if WAPICP3
        HResult
#else
        void
#endif
             PostCopyItem([In, MarshalAs(U4)]
#if WAPICP3
             TransferSourceFlags
#else
uint
#endif
       dwFlags, [In] IShellItem psiItem, [In] IShellItem psiDestinationFolder, [In, MarshalAs(LPWStr)] string pszNewName, [In] HResult hrCopy, [In] IShellItem psiNewlyCreated);

        /// <summary>
        /// Performs caller-implemented actions before the delete process for each item begins.
        /// </summary>
        /// <param name="dwFlags">Bitwise value that contains flags that control the operation.</param>
        /// <param name="psiItem">Pointer to an <see cref="IShellItem"/> that specifies the item to be deleted.</param>
        /// <returns>Returns <see cref="HResult.Ok"/> if successful, or an error value otherwise. In the case of an error value, the delete operation and all subsequent operations pending from the call to <see cref="IFileOperation"/> are canceled.</returns>

#if WAPICP3
        HResult
#else
        void
#endif
             PreDeleteItem([In, MarshalAs(U4)]
#if WAPICP3
             TransferSourceFlags
#else
uint
#endif
       dwFlags, [In] IShellItem psiItem);

        /// <summary>
        /// Performs caller-implemented actions after the delete process for each item is complete.
        /// </summary>
        /// <param name="dwFlags">Bitwise value that contains flags that were used during the delete operation. Some values can be set or changed during the delete operation.</param>
        /// <param name="psiItem">Pointer to an <see cref="IShellItem"/> that specifies the item that was deleted.</param>
        /// <param name="hrDelete">The return value of the delete operation. Note that this is not the <see cref="HResult"/> returned by <see cref="IFileOperation.DeleteItem"/>, which simply queues the delete operation. Instead, this is the result of the actual deletion.</param>
        /// <param name="psiNewlyCreated">A pointer to an <see cref="IShellItem"/> that specifies the deleted item, now in the Recycle Bin. If the item was fully deleted, this value is <see langword="null"/>.</param>
        /// <returns>Returns <see cref="HResult.Ok"/> if successful, or an error value otherwise. In the case of an error value, all subsequent operations pending from the call to <see cref="IFileOperation"/> are canceled.</returns>

#if WAPICP3
        HResult
#else
        void
#endif
             PostDeleteItem([In, MarshalAs(U4)]
#if WAPICP3
             TransferSourceFlags
#else
uint
#endif
       dwFlags, [In] IShellItem psiItem, [In] HResult hrDelete, [In] IShellItem psiNewlyCreated);

        /// <summary>
        /// Performs caller-implemented actions before the process to create a new item begins.
        /// </summary>
        /// <param name="dwFlags">Bitwise value that contains flags that control the operation.</param>
        /// <param name="psiDestinationFolder">Pointer to an <see cref="IShellItem"/> that specifies the destination folder that will contain the new item.</param>
        /// <param name="pszNewName">Pointer to the file name of the new item, for instance <b>Newfile.txt</b>. This is a null-terminated, Unicode string.</param>
        /// <returns>Returns <see cref="HResult.Ok"/> if successful, or an error value otherwise. In the case of an error value, this operation and all subsequent operations pending from the call to <see cref="IFileOperation"/> are canceled.</returns>

#if WAPICP3
        HResult
#else
        void
#endif
             PreNewItem([In, MarshalAs(U4)]
#if WAPICP3
             TransferSourceFlags
#else
uint
#endif
       dwFlags, [In] IShellItem psiDestinationFolder, [In, MarshalAs(LPWStr)] string pszNewName);

        /// <summary>
        /// Performs caller-implemented actions after the new item is created.
        /// </summary>
        /// <param name="dwFlags">Bitwise value that contains flags that were used during the creation operation. Some values can be set or changed during the creation operation.</param>
        /// <param name="psiDestinationFolder">Pointer to an <see cref="IShellItem"/> that specifies the destination folder to which the new item was added.</param>
        /// <param name="pszNewName">Pointer to the file name of the new item, for instance <b>Newfile.txt</b>. This is a null-terminated, Unicode string.</param>
        /// <param name="pszTemplateName">Pointer to the name of the template file (for example <b>Excel9.xls</b>) that the new item is based on, stored in one of the following locations:
        /// <ol><li>CSIDL_COMMON_TEMPLATES. The default path for this folder is %ALLUSERSPROFILE%\Templates.</li>
        /// <li>CSIDL_TEMPLATES. The default path for this folder is %USERPROFILE%\Templates.</li>
        /// <li>%SystemRoot%\shellnew</li></ol>
        /// <para>This is a null-terminated, Unicode string used to specify an existing file of the same type as the new file, containing the minimal content that an application wants to include in any new file.</para>
        /// <para>This parameter is normally <see langword="null"/> to specify a new, blank file.</para></param>
        /// <param name="dwFileAttributes">The file attributes applied to the new item.</param>
        /// <param name="hrNew">The return value of the creation operation. Note that this is not the <see cref="HResult"/> returned by <see cref="IFileOperation.NewItem"/>, which simply queues the creation operation. Instead, this is the result of the actual creation.</param>
        /// <param name="psiNewItem">Pointer to an <see cref="IShellItem"/> that represents the new item.</param>
        /// <returns>Returns <see cref="HResult.Ok"/> if successful, or an error value otherwise. In the case of an error value, all subsequent operations pending from the call to <see cref="IFileOperation"/> are canceled.</returns>

#if WAPICP3
        HResult
#else
        void
#endif
             PostNewItem([In, MarshalAs(U4)]
#if WAPICP3
             TransferSourceFlags
#else
uint
#endif
       dwFlags, [In] IShellItem psiDestinationFolder, [In, MarshalAs(LPWStr)] string pszNewName, [In, MarshalAs(LPWStr)] string pszTemplateName, [In, MarshalAs(U4)] FileAttributes dwFileAttributes, [In] HResult hrNew, [In] IShellItem psiNewItem);

        /// <summary>
        /// Provides an estimate of the total amount of work currently done in relation to the total amount of work.
        /// </summary>
        /// <param name="iWorkTotal">An estimate of the amount of work to be completed.</param>
        /// <param name="iWorkSoFar">The portion of iWorkTotal that has been completed so far.</param>
        /// <returns>If this method succeeds, it returns <see cref="HResult.Ok"/>. Otherwise, it returns an <see cref="HResult"/> error code.</returns>
        /// <remarks>The iWorkTotal and iWorkSoFar values are "points" or estimates of the amount of work to be done, and how much is completed. They are not specified in any particular units, but should be roughly proportional to how much time the total process takes. For example, to copy one small file might be considered two points, and a large file might be considered ten points. If a process is performing an operation that copies five small files and one large file, and the process has completed four of the small files, iWorkSoFar would be eight points (4 x 2 = 8) and iWorkTotal would be twenty points (5 x 2 + 10 = 20), so the estimate would be 8 of 20 points (or 40%) complete.</remarks>

#if WAPICP3
        HResult
#else
        void
#endif
             UpdateProgress([In, MarshalAs(U4)] uint iWorkTotal, [In, MarshalAs(U4)] uint iWorkSoFar);

        /// <summary>
        /// Not supported.
        /// </summary>
        /// <returns>If this method succeeds, it returns <see cref="HResult.Ok"/>. Otherwise, it returns an <see cref="HResult"/> error code.</returns>
        /// <remarks>This method should return <see cref="HResult.Ok"/> rather than <see cref="HResult.NotImplemented"/>.</remarks>

#if WAPICP3
        HResult
#else
        void
#endif
             ResetTimer();

        /// <summary>
        /// Not supported.
        /// </summary>
        /// <returns>If this method succeeds, it returns <see cref="HResult.Ok"/>. Otherwise, it returns an <see cref="HResult"/> error code.</returns>
        /// <remarks>This method should return <see cref="HResult.Ok"/> rather than <see cref="HResult.NotImplemented"/>.</remarks>

#if WAPICP3
        HResult
#else
        void
#endif
             PauseTimer();

        /// <summary>
        /// Not supported.
        /// </summary>
        /// <returns>If this method succeeds, it returns <see cref="HResult.Ok"/>. Otherwise, it returns an <see cref="HResult"/> error code.</returns>
        /// <remarks>This method should return <see cref="HResult.Ok"/> rather than <see cref="HResult.NotImplemented"/>.</remarks>

#if WAPICP3
        HResult
#else
        void
#endif
             ResumeTimer();
    }
}
