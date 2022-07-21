//Copyright (c) Microsoft Corporation.  All rights reserved.  Distributed under the Microsoft Public License (MS-PL)

namespace Microsoft.WindowsAPICodePack.Dialogs
{
    /// <summary>
    /// Specifies identifiers to indicate the return value of a <see cref="CommonFileDialog"/> dialog.
    /// </summary>
    public enum CommonFileDialogResult
    {
        /// <summary>
        /// Default value for enumeration, a dialog box should never return this value.
        /// </summary>
        None = 0,

        /// <summary>
        /// The dialog box return value is OK (usually sent from a button labeled OK or Save).
        /// </summary>
        Ok = 1,

        /// <summary>
        /// The dialog box return value is Cancel (usually sent from a button labeled Cancel).
        /// </summary>
        Cancel = 2,
    }
}
