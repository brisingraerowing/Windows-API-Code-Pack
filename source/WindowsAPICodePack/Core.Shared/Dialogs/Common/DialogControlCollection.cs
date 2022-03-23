//Copyright (c) Microsoft Corporation.  All rights reserved.  Distributed under the Microsoft Public License (MS-PL)

using Microsoft.WindowsAPICodePack.Resources;

using System;
using System.Linq;

namespace Microsoft.WindowsAPICodePack.Dialogs
{
    /// <summary>
    /// Strongly typed collection for dialog controls.
    /// </summary>
    public sealed class DialogControlCollection<T> : System.Collections.ObjectModel.Collection<T> where T : DialogControl
    {
        private readonly IDialogControlHost hostingDialog;

        /// <summary>
        /// Defines the indexer that supports accessing controls by name. 
        /// </summary>
        /// <remarks>
        /// <para>Control names are case sensitive.</para>
        /// <para>This indexer is useful when the dialog is created in XAML
        /// rather than constructed in code.</para></remarks>
        ///<exception cref="ArgumentException">
        /// The name cannot be null or a zero-length string.</exception>
        /// <remarks>If there is more than one control with the same name, only the <B>first control</B> will be returned.</remarks>
        public T this[string name] => string.IsNullOrEmpty(name) ? throw new ArgumentException(LocalizedMessages.DialogCollectionControlNameNull, nameof(name)) : Items.FirstOrDefault(x => x.Name == name);

        internal DialogControlCollection(in IDialogControlHost host) => hostingDialog = host;

        /// <summary>
        /// Inserts an dialog control at the specified index.
        /// </summary>
        /// <param name="index">The location to insert the control.</param>
        /// <param name="control">The item to insert.</param>
        /// <permission cref="InvalidOperationException">A control with 
        /// the same name already exists in this collection -or- 
        /// the control is being hosted by another dialog -or- the associated dialog is 
        /// showing and cannot be modified.</permission>
        protected override void InsertItem(int index, T control)
        {
            // Reparent, add control.
            control.HostingDialog =
                // Check for duplicates, lack of host,
                // and during-show adds.
                Items.Contains(control) ? throw new InvalidOperationException(LocalizedMessages.DialogCollectionCannotHaveDuplicateNames)
                : control.HostingDialog != null ? throw new InvalidOperationException(LocalizedMessages.DialogCollectionControlAlreadyHosted)
                : !hostingDialog.IsCollectionChangeAllowed() ? throw new InvalidOperationException(LocalizedMessages.DialogCollectionModifyShowingDialog)
                : hostingDialog;

            base.InsertItem(index, control);

            // Notify that we've added a control.
            hostingDialog.ApplyCollectionChanged();
        }

        /// <summary>
        /// Removes the control at the specified index.
        /// </summary>
        /// <param name="index">The location of the control to remove.</param>
        /// <permission cref="System.InvalidOperationException">
        /// The associated dialog is 
        /// showing and cannot be modified.</permission>
        protected override void RemoveItem(int index)
        {
            // Unparent and remove.
            Items[
                // Notify that we're about to remove a control.
                // Throw if dialog showing.
                hostingDialog.IsCollectionChangeAllowed() ? index : throw new InvalidOperationException(LocalizedMessages.DialogCollectionModifyShowingDialog)]
                .HostingDialog = null;

            base.RemoveItem(index);

            hostingDialog.ApplyCollectionChanged();
        }

        /// <summary>
        /// Searches for the control who's id matches the value passed in the <paramref name="id"/> parameter.
        /// </summary>
        /// <param name="id">An integer containing the identifier of the control being searched for.</param>
        /// <returns>A DialogControl who's id matches the value of the <paramref name="id"/> parameter.</returns>
        internal DialogControl GetControlbyId(int id) => Items.FirstOrDefault(x => x.Id == id);
    }
}
