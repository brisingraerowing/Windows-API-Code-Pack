//Copyright (c) Microsoft Corporation.  All rights reserved.  Distributed under the Microsoft Public License (MS-PL)

using Microsoft.WindowsAPICodePack.Resources;

using System;
using System.Diagnostics;

namespace Microsoft.WindowsAPICodePack.Dialogs
{
    /// <summary>
    /// Abstract base class for all dialog controls.
    /// </summary>
    public abstract class DialogControl
    {
        private static int nextId = DialogsDefaults.MinimumDialogControlId;
        private string _name;

        /// <summary>
        /// Gets the name for this control.
        /// </summary>
        public string Name
        {
            get => _name;

            set =>
                // Names for controls need to be quite stable, 
                // as we are going to maintain a mapping between 
                // the names and the underlying Win32/COM control IDs.

                // Note that we don't notify the hosting dialog of 
                // the change, as the initial set of name is (must be)
                // always legal, and renames are always illegal.
                _name = string.IsNullOrEmpty(value) ? throw new ArgumentException(LocalizedMessages.DialogControlNameCannotBeEmpty) : string.IsNullOrEmpty(_name) ? value : throw new InvalidOperationException(LocalizedMessages.DialogControlsCannotBeRenamed);
        }

        /// <summary>
        /// The native dialog that is hosting this control. This property is null is there is not associated dialog.
        /// </summary>
        public IDialogControlHost HostingDialog { get; set; }

        /// <summary>
        /// Gets the identifier for this control.
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        /// Creates a new instance of a dialog control.
        /// </summary>
        protected DialogControl()
        {
            Id = nextId;

            // Support wrapping of control IDs in case you create a lot of custom controls
            if (nextId == int.MaxValue)

                nextId = DialogsDefaults.MinimumDialogControlId;

            else nextId++;
        }

        /// <summary>
        /// Creates a new instance of a dialog control with the specified name.
        /// </summary>
        /// <param name="name">The name for this dialog.</param>
        protected DialogControl(in string name) : this() => Name = name;

        private void OnPropertyChange(in string propName, in Converter<IDialogControlHost, Action<string, DialogControl>> converter
#if DEBUG
            , in string text
#endif
            )
        {
#if DEBUG
            Debug.Assert(!string.IsNullOrEmpty(propName), $"Property {text} was not specified");
#endif
            if (HostingDialog != null)

                converter(HostingDialog)(propName, this);
        }

        ///<summary>
        /// Calls the hosting dialog, if it exists, to check whether the 
        /// property can be set in the dialog's current state. 
        /// The host should throw an exception if the change is not supported.
        /// Note that if the dialog isn't set yet, 
        /// there are no restrictions on setting the property.
        /// </summary>
        /// <param name="propName">The name of the property that is changing</param>
        protected void CheckPropertyChangeAllowed(in string propName) => OnPropertyChange(propName, hostingDialog => (string propertyName, DialogControl control) => hostingDialog.IsControlPropertyChangeAllowed(propertyName, control)
#if DEBUG
        , "to change"
#endif
        ); // This will throw if the property change is not allowed.

        ///<summary>
        /// Calls the hosting dialog, if it exists, to
        /// to indicate that a property has changed, and that 
        /// the dialog should do whatever is necessary 
        /// to propagate the change to the native control.
        /// Note that if the dialog isn't set yet, 
        /// there are no restrictions on setting the property.
        /// </summary>
        /// <param name="propName">The name of the property that is changing.</param>
        protected void ApplyPropertyChange(in string propName) => OnPropertyChange(propName, hostingDialog => hostingDialog.ApplyControlPropertyChange
#if DEBUG
        , "changed"
#endif
        );

        /// <summary>
        /// Compares two objects to determine whether they are equal
        /// </summary>
        /// <param name="obj">The object to compare against.</param>
        /// <returns>A <see cref="bool"/> value.</returns>
        public override bool Equals(object obj) => obj is DialogControl control && Id == control.Id;

        /// <summary>
        /// Serves as a hash function for a particular type. 
        /// </summary>
        /// <returns>An <see cref="int"/> hash code for this control.</returns>
        public override int GetHashCode() => Name == null ? ToString().GetHashCode() : Name.GetHashCode();
    }
}
