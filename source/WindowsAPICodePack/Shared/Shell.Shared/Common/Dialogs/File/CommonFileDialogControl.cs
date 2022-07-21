//Copyright (c) Microsoft Corporation.  All rights reserved.  Distributed under the Microsoft Public License (MS-PL)

using Microsoft.WindowsAPICodePack.COMNative.Dialogs;

using System;

using WinCopies.Util;

namespace Microsoft.WindowsAPICodePack.Dialogs.Controls
{
    /// <summary>
    /// Defines an abstract class that supports .Shared functionality for the 
    /// common file dialog controls.
    /// </summary>
    public abstract class CommonFileDialogControl : DialogControl
    {
        private byte _bools = 0b11;

        /// <summary>
        /// Holds the text that is displayed for this control.
        /// </summary>
        private string
#if CS8
            ?
#endif
            textValue;

        /// <summary>
        /// Gets or sets the text string that is displayed on the control.
        /// </summary>
        public virtual string
#if CS8
            ?
#endif
            Text
        { get => textValue; set => UpdateValue(() => textValue, () => textValue = value, value, nameof(Text)); }

        /// <summary>
        /// Gets or sets a value that determines if this control is enabled.  
        /// </summary>
        public bool Enabled { get => GetBit(0); set => UpdateValue(0, value, nameof(Enabled)); }

        /// <summary>
        /// Gets or sets a boolean value that indicates whether this control is visible.
        /// </summary>
        public bool Visible { get => GetBit(1); set => UpdateValue(1, value, nameof(Visible)); }

        /// <summary>
        /// Has this control been added to the dialog.
        /// </summary>
        internal bool IsAdded { get => GetBit(2); set => SetBit(2, value); }

        /// <summary>
        /// Creates a new instance of this class.
        /// </summary>
        protected CommonFileDialogControl() { /* Left empty. */ }

        /// <summary>
        /// Creates a new instance of this class with the text.
        /// </summary>
        /// <param name="text">The text of the common file dialog control.</param>
        protected CommonFileDialogControl(string text) : base() => textValue = text;

        /// <summary>
        /// Creates a new instance of this class with the specified name and text.
        /// </summary>
        /// <param name="name">The name of the common file dialog control.</param>
        /// <param name="text">The text of the common file dialog control.</param>
        protected CommonFileDialogControl(string name, string text) : base(name) => textValue = text;

        private bool GetBit(in byte pos) => _bools.GetBit(pos);
        private void SetBit(in byte pos, in bool value) => WinCopies.UtilHelpers.SetBit(ref _bools, pos, value);

        private void UpdateValue<T>(in Func<T> func, in Action action, in T newValue, in string propertyName)
        {
            // Don't update this property if it hasn't changed
            if (Equals(newValue, func())) return;

            action();
            ApplyPropertyChange(propertyName);
        }

        private void UpdateValue(byte pos, bool value, in string propertyName) => UpdateValue(() => GetBit(pos), () => SetBit(pos, value), value, propertyName);

        /// <summary>
        /// Attach the custom control itself to the specified dialog.
        /// </summary>
        /// <param name="dialog">The target dialog</param>
        internal abstract void Attach(IFileDialogCustomize dialog);

        internal virtual void SyncUnmanagedProperties()
        {
            ApplyPropertyChange(nameof(Enabled));
            ApplyPropertyChange(nameof(Visible));
        }
    }
}
