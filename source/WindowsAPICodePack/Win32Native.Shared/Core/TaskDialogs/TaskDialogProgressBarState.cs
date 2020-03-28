//Copyright (c) Microsoft Corporation.  All rights reserved.

namespace Microsoft.WindowsAPICodePack.Win32Native.Dialogs
{
    /// <summary>
    /// Sets the state of a task dialog progress bar.
    /// </summary>        
    public enum TaskDialogProgressBarState
    {
        /// <summary>
        /// Uninitialized state, this should never occur.
        /// </summary>
        None = 0,

        /// <summary>
        /// Normal state.
        /// </summary>
        Normal = TaskDialog.ProgressBarState.Normal,

        /// <summary>
        /// An error occurred.
        /// </summary>
        Error = TaskDialog.ProgressBarState.Error,

        /// <summary>
        /// The progress is paused.
        /// </summary>
        Paused = TaskDialog.ProgressBarState.Paused,

        /// <summary>
        /// Displays marquee (indeterminate) style progress
        /// </summary>
        Marquee
    }
}
