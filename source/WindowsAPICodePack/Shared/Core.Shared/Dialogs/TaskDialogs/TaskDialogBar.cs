//Copyright (c) Microsoft Corporation.  All rights reserved.  Distributed under the Microsoft Public License (MS-PL)

using Microsoft.WindowsAPICodePack.Win32Native.Dialogs;

namespace Microsoft.WindowsAPICodePack.Dialogs
{
    /// <summary>
    /// Defines a common class for all task dialog bar controls, such as the progress and marquee bars.
    /// </summary>
    public class TaskDialogBar : TaskDialogControl
    {
        private TaskDialogProgressBarState state;

        /// <summary>
        /// Gets or sets the state of the progress bar.
        /// </summary>
        public TaskDialogProgressBarState State
        {
            get => state;

            set
            {
                CheckPropertyChangeAllowed(nameof(State));
                state = value;
                ApplyPropertyChange(nameof(State));
            }
        }

        /// <summary>
        /// Creates a new instance of this class.
        /// </summary>
        public TaskDialogBar() { /* Left empty. */ }

        /// <summary>
        /// Creates a new instance of this class with the specified name.
        /// </summary>
        /// <param name="name">The name for this control.</param>
        protected TaskDialogBar(in string name) : base(name) { /* Left empty. */ }

        /// <summary>
        /// Resets the state of the control to normal.
        /// </summary>
        protected internal virtual void Reset() => state = TaskDialogProgressBarState.Normal;
    }
}
