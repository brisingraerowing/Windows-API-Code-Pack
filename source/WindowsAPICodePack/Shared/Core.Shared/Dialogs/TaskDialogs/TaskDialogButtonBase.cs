//Copyright (c) Microsoft Corporation.  All rights reserved.  Distributed under the Microsoft Public License (MS-PL)

using System;

using WinCopies.Util;

namespace Microsoft.WindowsAPICodePack.Dialogs
{
    // ContentProperty allows us to specify the text 
    // of the button as the child text of
    // a button element in XAML, as well as explicitly 
    // set with 'Text="<text>"'
    // Note that this attribute is inherited, so it 
    // applies to command-links and radio buttons as well.
    /// <summary>
    /// Defines the abstract base class for task dialog buttons. 
    /// Classes that inherit from this class will inherit 
    /// the Text property defined in this class.
    /// </summary>
    public abstract class TaskDialogButtonBase : TaskDialogControl
    {
        private byte _bools = 0b1;
        private string _text;

        /// <summary>
        /// Gets or sets the button text.
        /// </summary>
        public string Text { get => _text; set => UpdateProperty(() => _text = value, nameof(Text)); }

        /// <summary>
        /// Gets or sets a value that determines whether the button is enabled. The enabled state can cannot be changed before the dialog is shown.
        /// </summary>
        public bool Enabled { get => GetBit(0); set => UpdateProperty(0, value, nameof(Enabled)); }

        /// <summary>
        /// Gets or sets a value that indicates whether this button is the default button.
        /// </summary>
        public bool Default { get => GetBit(1); set => UpdateProperty(1, value, nameof(Default)); }

        // Note that we don't need to explicitly 
        // implement the add/remove delegate for the Click event;
        // the hosting dialog only needs the delegate 
        // information when the Click event is 
        // raised (indirectly) by NativeTaskDialog, 
        // so the latest delegate is always available.

        /// <summary>
        /// Raised when the task dialog button is clicked.
        /// </summary>
        public event EventHandler Click;

        /// <summary>
        /// Creates a new instance on a task dialog button.
        /// </summary>
        protected TaskDialogButtonBase() { /* Left empty. */ }

        /// <summary>
        /// Creates a new instance on a task dialog button with
        /// the specified name and text.
        /// </summary>
        /// <param name="name">The name for this button.</param>
        /// <param name="text">The label for this button.</param>
        protected TaskDialogButtonBase(string name, string text) : base(name) => _text = text;

        private bool GetBit(in byte pos) => _bools.GetBit(pos);

        protected void UpdateProperty(in Action action, in string propertyName)
        {
            CheckPropertyChangeAllowed(propertyName);
            action();
            ApplyPropertyChange(propertyName);
        }

        private void UpdateProperty(byte pos, bool value, in string propertyName) => UpdateProperty(() => WinCopies.
#if WAPICP3
        UtilHelpers
#else
        Util.Util
#endif
        .SetBit(ref _bools, pos, value), propertyName);

        internal void RaiseClickEvent()
        {
            // Only perform click if the button is enabled.
            if (Enabled)

                Click?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Returns the Text property value for this button.
        /// </summary>
        /// <returns>A <see cref="string"/>.</returns>
        public override string ToString() => _text ?? string.Empty;
    }
}
