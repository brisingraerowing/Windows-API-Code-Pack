//Copyright (c) Microsoft Corporation.  All rights reserved.  Distributed under the Microsoft Public License (MS-PL)

using Microsoft.WindowsAPICodePack.COMNative.Shell;
using Microsoft.WindowsAPICodePack.Win32Native.Shell.Resources;

using System.IO;

namespace Microsoft.WindowsAPICodePack.Shell
{
    /// <summary>
    /// A file in the Shell Namespace
    /// </summary>
    public class ShellFile : ShellObject
    {
        #region Constructors
        /// <summary>
        /// Constructs a new ShellFile object given a file path
        /// </summary>
        /// <param name="path">The file or folder path</param>
        public ShellFile(in string path)
        {
            // Get the absolute path
            string absPath = WinCopies.Util.IO.Path.GetAbsolutePath(path);

            ParsingName = File.Exists(absPath) ? absPath : throw new FileNotFoundException(
                    string.Format(System.Globalization.CultureInfo.InvariantCulture,
                    LocalizedMessages.FilePathNotExist, path)); // Make sure this is valid
        }

        internal ShellFile(IShellItem2 shellItem) => nativeShellItem = shellItem;
        #endregion

        #region Public Properties
        /// <summary>
        /// The path for this file
        /// </summary>
        virtual public string Path => ParsingName;
        #endregion

#if !WAPICP3
        #region Public Methods
        /// <summary>
        /// Constructs a new ShellFile object given a file path
        /// </summary>
        /// <param name="path">The file or folder path</param>
        /// <returns>ShellFile object created using given file path.</returns>
        public static ShellFile FromFilePath(string path) => new ShellFile(path);
        #endregion
#endif
    }
}
