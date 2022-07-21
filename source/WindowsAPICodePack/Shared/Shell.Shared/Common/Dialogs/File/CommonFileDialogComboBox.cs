//Copyright (c) Microsoft Corporation.  All rights reserved.  Distributed under the Microsoft Public License (MS-PL)

using Microsoft.WindowsAPICodePack.COMNative.Dialogs;
using Microsoft.WindowsAPICodePack.Shell.Resources;

using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Markup;

namespace Microsoft.WindowsAPICodePack.Dialogs.Controls
{
    /// <summary>
    /// Creates the ComboBox controls in the Common File Dialog.
    /// </summary>
    [ContentProperty("Items")]
    public class CommonFileDialogComboBox : CommonFileDialogProminentControl, ICommonFileDialogIndexedControls
    {
        /// <summary>
        /// Gets the collection of <see cref="CommonFileDialogComboBoxItem"/> objects.
        /// </summary>
        public Collection<CommonFileDialogComboBoxItem> Items { get; } = new
#if !CS9
            Collection<CommonFileDialogComboBoxItem>
#endif
            ();

        /// <summary>
        /// Creates a new instance of this class.
        /// </summary>
        public CommonFileDialogComboBox() { /* Left empty. */ }

        /// <summary>
        /// Creates a new instance of this class with the specified name.
        /// </summary>
        /// <param name="name">Text to display for this control</param>
        public CommonFileDialogComboBox(string name) : base(name, string.Empty) { /* Left empty. */ }

        #region ICommonFileDialogIndexedControls Members
        private int selectedIndex = -1;

        /// <summary>
        /// Gets or sets the current index of the selected item.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2201:DoNotRaiseReservedExceptionTypes")]
        public int SelectedIndex
        {
            get => selectedIndex;

            set
            {
                // Don't update property if it hasn't changed
                if (selectedIndex == value)

                    return;

                if (HostingDialog == null)
                {
                    selectedIndex = value;
                    return;
                }

                // Only update this property if it has a valid value
                selectedIndex = value >= 0 && value < Items.Count ? value : throw new IndexOutOfRangeException(LocalizedMessages.ComboBoxIndexOutsideBounds);
                ApplyPropertyChange(nameof(SelectedIndex));
            }
        }

        /// <summary>
        /// Occurs when the <see cref="SelectedIndex"/> is changed.
        /// </summary>
        /// <remarks>
        /// By initializing the <see cref="SelectedIndexChanged"/> event with an empty
        /// delegate, it is not necessary to check  
        /// if the SelectedIndexChanged is not <see langword="null"/>.
        /// </remarks>
        public event EventHandler SelectedIndexChanged = delegate { };

        /// <summary>
        /// Raises the <see cref="SelectedIndexChanged"/> event if this control is enabled.
        /// </summary>
        /// <remarks>Because this method is defined in an interface, we can either
        /// have it as <see langword="public"/>, or make it <see langword="private"/> and explicitly implement (like below).
        /// Making it <see langword="public"/> doesn't really help as its only internal (but can't have this 
        /// internal because of the interface).
        /// </remarks>
        void ICommonFileDialogIndexedControls.RaiseSelectedIndexChangedEvent()
        {
            // Make sure that this control is enabled and has a specified delegate
            if (Enabled)
                SelectedIndexChanged(this, EventArgs.Empty);
        }
        #endregion ICommonFileDialogIndexedControls Members

        /// <summary>
        /// Attach the ComboBox control to the dialog object
        /// </summary>
        /// <param name="dialog">The target dialog</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2201:DoNotRaiseReservedExceptionTypes")]
        internal override void Attach(IFileDialogCustomize dialog)
        {
            Debug.Assert(dialog != null, $"{nameof(CommonFileDialogComboBox)}.{nameof(Attach)}: dialog parameter can not be null");

            // Add the combo box control
            dialog.AddComboBox(Id);

            // Add the combo box items
            for (int index = 0; index < Items.Count; index++)
                dialog.AddControlItem(Id, index, Items[index].Text);

            // Set the currently selected item
            if (selectedIndex >= 0 && selectedIndex < Items.Count)

                dialog.SetSelectedControlItem(Id, selectedIndex);

            else if (selectedIndex != -1)

                throw new IndexOutOfRangeException(LocalizedMessages.ComboBoxIndexOutsideBounds);

            // Make this control prominent if needed
            if (IsProminent)

                dialog.MakeProminent(Id);

            // Sync additional properties
            SyncUnmanagedProperties();
        }
    }

    /// <summary>
    /// Creates a <b>ComboBoxItem</b> for the <see cref="CommonFileDialog"/>.
    /// </summary>
    public class CommonFileDialogComboBoxItem
    {
        /// <summary>
        /// Gets or sets the string that is displayed for this item.
        /// </summary>
        public string Text { get; set; } = string.Empty;

        /// <summary>
        /// Creates a new instance of this class.
        /// </summary>
        public CommonFileDialogComboBoxItem() { /* Left empty. */ }

        /// <summary>
        /// Creates a new instance of this class with the specified text.
        /// </summary>
        /// <param name="text">The text to use for the combo box item.</param>
        public CommonFileDialogComboBoxItem(string text) => Text = text;
    }
}
