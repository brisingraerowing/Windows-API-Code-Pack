﻿//Copyright (c) Microsoft Corporation.  All rights reserved.  Distributed under the Microsoft Public License (MS-PL)

using Microsoft.WindowsAPICodePack.COMNative.Dialogs;

using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Windows.Markup;

namespace Microsoft.WindowsAPICodePack.Dialogs.Controls
{
    /// <summary>
    /// Represents a group box control for the Common File Dialog.
    /// </summary>note
    [ContentProperty("Items")]
    public class CommonFileDialogGroupBox : CommonFileDialogProminentControl
    {
        /// <summary>
        /// Gets the collection of controls for this group box.
        /// </summary>
        public Collection<DialogControl> Items { get; private set; }

        /// <summary>
        /// Creates a new instance of this class.
        /// </summary>
        public CommonFileDialogGroupBox() : base(string.Empty) => Initialize();

        /// <summary>
        /// Create a new instance of this class with the specified text.
        /// </summary>
        /// <param name="text">The text to display for this control.</param>
        public CommonFileDialogGroupBox(string text) : base(text) => Initialize();

        /// <summary>
        /// Creates a new instance of this class with the specified name and text.
        /// </summary>
        /// <param name="name">The name of this control.</param>
        /// <param name="text">The text to display for this control.</param>
        public CommonFileDialogGroupBox(string name, string text) : base(name, text) => Initialize();

        /// <summary>
        /// Initializes the item collection for this class.
        /// </summary>
        private void Initialize() => Items = new Collection<DialogControl>();

        /// <summary>
        /// Attach the GroupBox control to the dialog object
        /// </summary>
        /// <param name="dialog">Target dialog</param>
        internal override void Attach(IFileDialogCustomize dialog)
        {
            Debug.Assert(dialog != null, $"{nameof(CommonFileDialogGroupBox)}.{nameof(Attach)}: dialog parameter can not be null");

            // Start a visual group
            dialog.StartVisualGroup(Id, Text);

            // Add child controls
            foreach (CommonFileDialogControl item in Items.Cast<CommonFileDialogControl>())
            {
                item.HostingDialog = HostingDialog;
                item.Attach(dialog);
            }

            // End visual group
            dialog.EndVisualGroup();

            // Make this control prominent if needed
            if (IsProminent)

                dialog.MakeProminent(Id);

            // Sync unmanaged properties with managed properties
            SyncUnmanagedProperties();
        }
    }
}
