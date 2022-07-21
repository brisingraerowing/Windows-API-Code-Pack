//Copyright (c) Microsoft Corporation.  All rights reserved.  Distributed under the Microsoft Public License (MS-PL)

using System;
using System.Collections.Generic;
using System.Linq;

using static Microsoft.WindowsAPICodePack.Shell.Resources.LocalizedMessages;

namespace Microsoft.WindowsAPICodePack.Dialogs.Controls
{
    /// <summary>
    /// Provides a strongly typed collection for dialog controls.
    /// </summary>
    public sealed class CommonFileDialogControlCollection<T> : System.Collections.ObjectModel.Collection<T> where T : DialogControl
    {
        private readonly IDialogControlHost hostingDialog;

        internal CommonFileDialogControlCollection(IDialogControlHost host) => hostingDialog = host;

        /// <summary>
        /// Inserts an dialog control at the specified index.
        /// </summary>
        /// <param name="index">The location to insert the control.</param>
        /// <param name="control">The item to insert.</param>
        /// <permission cref="InvalidOperationException">
        /// <para>A control with the same name already exists in this collection</para>
        /// <para>-or- the control is being hosted by another dialog</para>
        /// <para>-or- the associated dialog is showing and cannot be modified.</para></permission>
        protected override void InsertItem(int index, T control)
        {
            // Reparent, add control.
            control.HostingDialog = Items.Contains(control) // Check for duplicates, lack of host, and during-show adds.
                ? throw new InvalidOperationException(DialogControlCollectionMoreThanOneControl)
                : control.HostingDialog == null
                ? hostingDialog.IsCollectionChangeAllowed()
                ? control is CommonFileDialogMenuItem
                ? throw new InvalidOperationException(DialogControlCollectionMenuItemControlsCannotBeAdded)
                : hostingDialog
                : throw new InvalidOperationException(DialogControlCollectionModifyingControls)
                : throw new InvalidOperationException(DialogControlCollectionRemoveControlFirst);

            base.InsertItem(index, control);

            // Notify that we've added a control.
            hostingDialog.ApplyCollectionChanged();
        }

        /// <summary>
        /// Removes the control at the specified index.
        /// </summary>
        /// <param name="index">The location of the control to remove.</param>
        /// <permission cref="InvalidOperationException">
        /// The associated dialog is showing and cannot be modified.</permission>
        protected override void RemoveItem(int index) => throw new NotSupportedException(DialogControlCollectionCannotRemoveControls);

        /// <summary>
        /// Defines the indexer that supports accessing controls by name. 
        /// </summary>
        /// <remarks>
        /// <para>Control names are case sensitive.</para>
        /// <para>This indexer is useful when the dialog is created in XAML
        /// rather than constructed in code.</para></remarks>
        /// <exception cref="ArgumentException">
        /// The name cannot be null or a zero-length string.</exception>
        /// <remarks>If there is more than one control with the same name, only the <b>first control</b> will be returned.</remarks>
        public T
#if CS9
            ?
#endif
            this[string name]
        {
            get
            {
                foreach (T control in string.IsNullOrEmpty(name) ? throw new ArgumentException(DialogControlCollectionEmptyName, nameof(name)) : Items)
                {
                    // NOTE: we don't ToLower() the strings - casing effects 
                    // hash codes, so we are case-sensitive.
                    if (control.Name == name) return control;

                    if (control is CommonFileDialogGroupBox groupBox)

                        foreach (T subControl in groupBox.Items.Cast<T>())

                            if (subControl.Name == name) return subControl;
                }

                return null;
            }
        }

        /// <summary>
        /// Recursively searches for the control who's id matches the value
        /// passed in the <paramref name="id"/> parameter.
        /// </summary>
        /// <param name="id">An integer containing the identifier of the 
        /// control being searched for.</param>
        /// <returns>A <see cref="DialogControl"/> who's id matches the value of the
        /// <paramref name="id"/> parameter.</returns>
        internal DialogControl
#if CS8
            ?
#endif
            GetControlbyId(int id) => GetSubControlbyId(Items.Cast<DialogControl>(), id);

        /// <summary>
        /// Recursively searches for a given control id in the 
        /// collection passed via the <paramref name="controlCollection"/> parameter.
        /// </summary>
        /// <param name="id">An int containing the identifier of the control 
        /// being searched for.</param>
        /// <returns>A <see cref="DialogControl"/> who's Id matches the value of the
        /// <paramref name="id"/> parameter.</returns>
        internal DialogControl
#if CS8
            ?
#endif
            GetSubControlbyId(IEnumerable<DialogControl> controlCollection, int id)
        {
            // if ctrlColl is null, it will throw in the foreach.
            if (controlCollection == null) return null;

            DialogControl
#if CS8
            ?
#endif
            temp;

            foreach (DialogControl control in controlCollection)
            {
                if (control.Id == id) return control;

                // Search GroupBox child items
                if (control is CommonFileDialogGroupBox groupBox)

                    if ((temp = GetSubControlbyId(groupBox.Items, id)) != null) return temp;
            }

            return null;
        }
    }
}
