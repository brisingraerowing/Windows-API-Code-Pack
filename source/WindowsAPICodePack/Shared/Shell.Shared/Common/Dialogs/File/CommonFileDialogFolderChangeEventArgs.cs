//Copyright (c) Microsoft Corporation.  All rights reserved.  Distributed under the Microsoft Public License (MS-PL)

using System.ComponentModel;

namespace Microsoft.WindowsAPICodePack.Dialogs
{
    /// <summary>
    /// Creates the event data associated with <see cref="CommonFileDialog.FolderChanging"/> event.
    /// </summary>
    public class CommonFileDialogFolderChangeEventArgs : CancelEventArgs
    {
        /// <summary>
        /// Gets or sets the name of the folder.
        /// </summary>
        public string
#if CS8
            ?
#endif
            Folder
        { get; set; }

        /// <summary>
        /// Creates a new instance of this class.
        /// </summary>
        /// <param name="folder">The name of the folder.</param>
        public CommonFileDialogFolderChangeEventArgs(string
#if CS8
            ?
#endif
            folder) => Folder = folder;
    }
}
