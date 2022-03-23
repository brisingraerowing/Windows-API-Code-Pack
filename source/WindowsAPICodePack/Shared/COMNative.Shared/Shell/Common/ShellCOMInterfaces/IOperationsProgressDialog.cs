//Copyright (c) Microsoft Corporation.  All rights reserved.  Distributed under the Microsoft Public License (MS-PL)

using Microsoft.WindowsAPICodePack.Win32Native;

using System;
using System.Runtime.InteropServices;

namespace Microsoft.WindowsAPICodePack.COMNative.Shell
{
    /// <summary>
    /// Exposes methods to get, set, and query a progress dialog.
    /// </summary>
    [ComImport,
        Guid("0C9FB851-E5C9-43EB-A370-F0677B13874C"),
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IOperationsProgressDialog
    {
        /// <summary>
        /// Starts the specified progress dialog.
        /// </summary>
        /// <param name="hwndOwner">A handle to the parent window.</param>
        /// <param name="flags">Flags that customize the operation. Note that these flags are declared in Shlobj.h.</param>
        /// <returns>If this method succeeds, it returns <see cref="HResult"/>. Otherwise, it returns an <see cref="HResult"/> error code.</returns>
        /// <remarks><para>The progress dialog should be created on a separate thread than the file operation on which the dialog is reporting. If the dialog is running in the same thread as the file operation, progress messages are, at best, only sent as resources allow. Progress messages on the same thread as the file operation might not be sent at all.</para>
        /// <para>Once <see cref="StartProgressDialog"/> is called, that instance of the CLSID_ProgressDialog object cannot be accessed by IProgressDialog, IActionProgressDialog, or IActionProgress. Although QueryInterface can be used to access these interfaces, most of their methods cannot be invoked. IOperationsProgressDialog is the interface used to display the new progress dialog for the Windows Vista and later operations engine.</para></remarks>
        HResult StartProgressDialog(IntPtr hwndOwner, OPPROGDLG flags);

        /// <summary>
        /// Stops current progress dialog.
        /// </summary>
        /// <returns>If this method succeeds, it returns <see cref="HResult.Ok"/>. Otherwise, it returns an <see cref="HResult"/> error code.</returns>
        HResult StopProgressDialog();

        /// <summary>
        /// Sets which progress dialog operation is occurring, and whether we are in pre-flight or undo mode.
        /// </summary>
        /// <param name="action">Specifies operation.</param>
        /// <returns>If this method succeeds, it returns <see cref="HResult.Ok"/>. Otherwise, it returns an <see cref="HResult"/> error code.</returns>
        HResult SetOperation(SPAction action);

        /// <summary>
        /// Sets progress dialog operations mode.
        /// </summary>
        /// <param name="mode">Specifies the operation mode.</param>
        /// <returns>If this method succeeds, it returns <see cref="HResult.Ok"/>. Otherwise, it returns an <see cref="HResult"/> error code.</returns>
        HResult SetMode(PDMODE mode);

        /// <summary>
        /// Updates the current progress dialog, as specified.
        /// </summary>
        /// <param name="ullPointsCurrent">Current points, used for showing progress in points.</param>
        /// <param name="ullPointsTotal">Total points, used for showing progress in points.</param>
        /// <param name="ullSizeCurrent">Current size in bytes, used for showing progress in bytes.</param>
        /// <param name="ullSizeTotal">Total size in bytes, used for showing progress in bytes.</param>
        /// <param name="ullItemsCurrent">Current items, used for showing progress in items.</param>
        /// <param name="ullItemsTotal">Specifies total items, used for showing progress in items.</param>
        /// <returns>If this method succeeds, it returns <see cref="HResult.Ok"/>. Otherwise, it returns an <see cref="HResult"/> error code.</returns>
        HResult UpdateProgress(ref ulong ullPointsCurrent, ref ulong ullPointsTotal, ref ulong ullSizeCurrent, ref ulong ullSizeTotal, ref ulong ullItemsCurrent, ref ulong ullItemsTotal);

        /// <summary>
        /// Called to specify the text elements stating the source and target in the current progress dialog.
        /// </summary>
        /// <param name="psiSource">A pointer to an <see cref="IShellItem"/> that represents the source Shell item.</param>
        /// <param name="psiTarget">A pointer to an <see cref="IShellItem"/> that represents the target Shell item.</param>
        /// <param name="psiItem">A pointer to an <see cref="IShellItem"/> that represents the item currently being operated on by the operation engine. This parameter is only used in Windows 7 and later. In earlier versions, this parameter should be <see langword="null"/>.</param>
        /// <returns>If this method succeeds, it returns <see cref="HResult.Ok"/>. Otherwise, it returns an <see cref="HResult"/> error code.</returns>
        HResult UpdateLocations(ref IShellItem psiSource, ref IShellItem psiTarget, ref IShellItem psiItem);

        /// <summary>
        /// Resets progress dialog timer to 0.
        /// </summary>
        /// <returns>If this method succeeds, it returns <see cref="HResult.Ok"/>. Otherwise, it returns an <see cref="HResult"/> error code.</returns>
        HResult ResetTimer();

        /// <summary>
        /// Pauses progress dialog timer.
        /// </summary>
        /// <returns>If this method succeeds, it returns <see cref="HResult.Ok"/>. Otherwise, it returns an <see cref="HResult"/> error code.</returns>
        HResult PauseTimer();

        /// <summary>
        /// Resumes progress dialog timer.
        /// </summary>
        /// <returns>If this method succeeds, it returns <see cref="HResult.Ok"/>. Otherwise, it returns an <see cref="HResult"/> error code.</returns>
        HResult ResumeTimer();

        /// <summary>
        /// Gets elapsed and remaining time for progress dialog.
        /// </summary>
        /// <param name="pullElapsed">A pointer to the elapsed time in milliseconds.</param>
        /// <param name="pullRemaining">A pointer to the remaining time in milliseconds.</param>
        /// <returns>If this method succeeds, it returns <see cref="HResult.Ok"/>. Otherwise, it returns an <see cref="HResult"/> error code.</returns>
        HResult GetMilliseconds(ref ulong pullElapsed, ref ulong pullRemaining);

        /// <summary>
        /// Gets operation status for progress dialog.
        /// </summary>
        /// <param name="popstatus">Contains pointer to the operation status. See <see cref="PDOPSTATUS"/>.</param>
        /// <returns>If this method succeeds, it returns <see cref="HResult.Ok"/>. Otherwise, it returns an <see cref="HResult"/> error code.</returns>
        HResult GetOperationStatus(ref PDOPSTATUS popstatus);
    }
}
