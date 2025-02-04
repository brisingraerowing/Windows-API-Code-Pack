﻿//Copyright (c) Microsoft Corporation.  All rights reserved.  Distributed under the Microsoft Public License (MS-PL)

using Microsoft.WindowsAPICodePack.COMNative.Dialogs;
using Microsoft.WindowsAPICodePack.Win32Native.Dialogs;

using System;
using System.Diagnostics;

namespace Microsoft.WindowsAPICodePack.Dialogs.Controls
{
    /// <summary>
    ///  Defines the text box controls in the Common File Dialog.
    /// </summary>
    public class CommonFileDialogTextBox : CommonFileDialogControl
    {
        /// <summary>
        /// Creates a new instance of this class.
        /// </summary>
        public CommonFileDialogTextBox() : base(string.Empty) { /* Left empty. */ }

        /// <summary>
        /// Creates a new instance of this class with the specified text.
        /// </summary>
        /// <param name="text">The text to display for this control.</param>
        public CommonFileDialogTextBox(string text) : base(text) { /* Left empty. */ }

        /// <summary>
        /// Creates a new instance of this class with the specified name and text.
        /// </summary>
        /// <param name="name">The name of this control.</param>
        /// <param name="text">The text to display for this control.</param>
        public CommonFileDialogTextBox(string name, string text) : base(name, text) { /* Left empty. */ }

        internal bool Closed { get; set; }

        /// <summary>
        /// Gets or sets a value for the text string contained in the CommonFileDialogTextBox.
        /// </summary>
        public override string Text
        {
            get
            {
                if (!Closed)

                    SyncValue();

                return base.Text;
            }

            set
            {
                if (customizedDialog is object)

                    customizedDialog.SetEditBoxText(Id, value);

                base.Text = value;
            }
        }

        /// <summary>
        /// Holds an instance of the customized (/native) dialog and should
        /// be null until after the Attach() call is made.
        /// </summary>
        private IFileDialogCustomize
#if CS8
            ?
#endif
            customizedDialog;

        /// <summary>
        /// Attach the TextBox control to the dialog object
        /// </summary>
        /// <param name="dialog">Target dialog</param>
        internal override void Attach(IFileDialogCustomize dialog)
        {
            Debug.Assert(dialog != null, $"{nameof(CommonFileDialogTextBox)}.{nameof(Attach)}: dialog parameter can not be null");

            // Add a text entry control
            dialog.AddEditBox(Id, Text);

            // Set to local instance in order to gate access to same.
            customizedDialog = dialog;

            // Sync unmanaged properties with managed properties
            SyncUnmanagedProperties();

            Closed = false;
        }

        internal void SyncValue()
        {
            // Make sure that the local native dialog instance is NOT 
            // null. If it's null, just return the "textValue" var,
            // otherwise, use the native call to get the text value, 
            // setting the textValue member variable then return it.

            if (customizedDialog is object)
            {
                customizedDialog.GetEditBoxText(Id, out string textValue);

                base.Text = textValue;
            }
        }
    }
}
