﻿//Copyright (c) Microsoft Corporation.  All rights reserved.  Distributed under the Microsoft Public License (MS-PL)

using Microsoft.WindowsAPICodePack.COMNative.Dialogs;

using System;
using System.Diagnostics;

namespace Microsoft.WindowsAPICodePack.Dialogs.Controls
{
    /// <summary>
    /// Creates the check button controls used by the Common File Dialog.
    /// </summary>
    public class CommonFileDialogCheckBox : CommonFileDialogProminentControl
    {
        private bool isChecked;

        /// <summary>
        /// Gets or sets the state of the check box.
        /// </summary>
        public bool IsChecked
        {
            get => isChecked;

            set
            {
                // Check if property has changed
                if (isChecked != value)
                {
                    isChecked = value;
                    ApplyPropertyChange(nameof(IsChecked));
                }
            }
        }

        /// <summary>
        /// Creates a new instance of this class.
        /// </summary>
        public CommonFileDialogCheckBox() { /* Left empty. */ }

        /// <summary>
        /// Creates a new instance of this class with the specified text.
        /// </summary>
        /// <param name="text">The text to display for this control.</param>
        public CommonFileDialogCheckBox(string text) : base(text) { /* Left empty. */ }

        /// <summary>
        /// Creates a new instance of this class with the specified name and text.
        /// </summary>
        /// <param name="name">The name of this control.</param>
        /// <param name="text">The text to display for this control.</param>
        public CommonFileDialogCheckBox(string name, string text) : base(name, text) { /* Left empty. */ }

        /// <summary>
        /// Creates a new instance of this class with the specified text and check state.
        /// </summary>
        /// <param name="text">The text to display for this control.</param>
        /// <param name="isChecked">The check state of this control.</param>
        public CommonFileDialogCheckBox(string text, bool isChecked) : base(text) => this.isChecked = isChecked;

        /// <summary>
        /// Creates a new instance of this class with the specified name, text and check state.
        /// </summary>
        /// <param name="name">The name of this control.</param>
        /// <param name="text">The text to display for this control.</param>
        /// <param name="isChecked">The check state of this control.</param>
        public CommonFileDialogCheckBox(string name, string text, bool isChecked) : base(name, text) => this.isChecked = isChecked;

        /// <summary>
        /// Occurs when the user changes the check state.
        /// </summary>
        public event EventHandler CheckedChanged = delegate { };

        internal void RaiseCheckedChangedEvent()
        {
            // Make sure that this control is enabled and has a specified delegate
            if (Enabled)

                CheckedChanged(this, EventArgs.Empty);
        }

        /// <summary>
        /// Attach the CheckButton control to the dialog object.
        /// </summary>
        /// <param name="dialog">the target dialog</param>
        internal override void Attach(IFileDialogCustomize dialog)
        {
            Debug.Assert(dialog != null, $"{nameof(CommonFileDialogCheckBox)}.{nameof(Attach)}: dialog parameter can not be null.");

            // Add a check button control
            dialog.AddCheckButton(Id, Text, isChecked);

            // Make this control prominent if needed
            if (IsProminent) dialog.MakeProminent(Id);

            // Make sure this property is set
            ApplyPropertyChange(nameof(IsChecked));

            // Sync unmanaged properties with managed properties
            SyncUnmanagedProperties();
        }
    }
}