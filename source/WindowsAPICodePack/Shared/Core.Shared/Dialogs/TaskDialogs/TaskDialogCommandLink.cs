//Copyright (c) Microsoft Corporation.  All rights reserved.  Distributed under the Microsoft Public License (MS-PL)

using System;
using System.Globalization;

namespace Microsoft.WindowsAPICodePack.Dialogs
{
    /// <summary>
    /// Represents a command-link. 
    /// </summary>
    public class TaskDialogCommandLink : TaskDialogButton
    {
        /// <summary>
        /// Gets or sets the instruction associated with this command link button.
        /// </summary>
        public string Instruction { get; set; }

        /// <summary>
        /// Creates a new instance of this class.
        /// </summary>
        public TaskDialogCommandLink() { /* Left empty. */ }

        /// <summary>
        /// Creates a new instance of this class with the specified name and label.
        /// </summary>
        /// <param name="name">The name for this button.</param>
        /// <param name="text">The label for this button.</param>
        public TaskDialogCommandLink(in string name, in string text) : base(name, text) { /* Left empty. */ }

        /// <summary>
        /// Creates a new instance of this class with the specified name,label, and instruction.
        /// </summary>
        /// <param name="name">The name for this button.</param>
        /// <param name="text">The label for this button.</param>
        /// <param name="instruction">The instruction for this command link.</param>
        public TaskDialogCommandLink(in string name, in string text, in string instruction)
            : base(name, text) => Instruction = instruction;

        /// <summary>
        /// Returns a string representation of this object.
        /// </summary>
        public override string ToString() => string.Format(CultureInfo.CurrentCulture, "{0}{1}{2}",
                Text ?? string.Empty,
                !(string.IsNullOrEmpty(Text) || string.IsNullOrEmpty(Instruction)) ? Environment.NewLine : string.Empty,
                Instruction ?? string.Empty);
    }
}
