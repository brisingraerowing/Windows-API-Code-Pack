﻿//Copyright (c) Microsoft Corporation.  All rights reserved.

using Microsoft.WindowsAPICodePack.Win32Native.Shell;
using Microsoft.WindowsAPICodePack.Win32Native.Shell.Resources;
using System.IO;

namespace Microsoft.WindowsAPICodePack.Shell
{
    /// <summary>
    /// A file in the Shell Namespace
    /// </summary>
    public class ShellFile : ShellObject
    {
        #region Internal Constructor

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        private ShellFile(string path)
        {
            // Get the absolute path
            string absPath = ShellHelper.GetAbsolutePath(path);
            
            ParsingName = File.Exists(absPath) ? absPath : throw new FileNotFoundException(
                    string.Format(System.Globalization.CultureInfo.InvariantCulture,
                    LocalizedMessages.FilePathNotExist, path)); // Make sure this is valid
        }

        internal ShellFile(IShellItem2 shellItem) => nativeShellItem = shellItem;

        #endregion

        #region Public Methods
        /// <summary>
        /// Constructs a new ShellFile object given a file path
        /// </summary>
        /// <param name="path">The file or folder path</param>
        /// <returns>ShellFile object created using given file path.</returns>
        static public ShellFile FromFilePath(string path) => new ShellFile(path);

        #endregion

        #region Public Properties

        /// <summary>
        /// The path for this file
        /// </summary>
        virtual public string Path => ParsingName;

        #endregion
    }
}
