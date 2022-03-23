//Copyright (c) Microsoft Corporation.  All rights reserved.  Distributed under the Microsoft Public License (MS-PL)

using Microsoft.WindowsAPICodePack.COMNative.Shell;

using System;
using System.Runtime.InteropServices.ComTypes;

namespace Microsoft.WindowsAPICodePack.Shell
{
    /// <summary>
    /// Represents a link to existing FileSystem or Virtual item.
    /// </summary>
    public class ShellLink :
#if WAPICP3
        ShellFile
#else
        ShellObject
#endif
    {
        #region Fields
#if !WAPICP3
        /// Path for this file e.g. c:\Windows\file.txt,
        private string _path;
#endif
        private string _targetLocation;
        private string _arguments;
        private string _comments;
        #endregion

        #region Public Properties
#if !WAPICP3
        /// <summary>
        /// The path for this link
        /// </summary>
        public virtual string Path
        {
            get
            {
                if (_path == null && NativeShellItem != null)

                    _path = base.ParsingName;

                return _path;
            }

            protected set => _path = value;
        }
#endif

        /// <summary>
        /// Gets the location to which this link points to.
        /// </summary>
        public string TargetLocation
        {
            get
            {
                if (string.IsNullOrEmpty(_targetLocation) && NativeShellItem2 != null)

                    _targetLocation = Properties.System.Link.TargetParsingPath.Value;

                return _targetLocation;
            }

            set
            {
                if (value == null) return;

                if (NativeShellItem2 != null)
                {
                    Properties.System.Link.TargetParsingPath.Value = _targetLocation;

                    _targetLocation = value;
                }
            }
        }

        /// <summary>
        /// Gets the ShellObject to which this link points to.
        /// </summary>
        public ShellObject TargetShellObject => ShellObjectFactory.Create(TargetLocation);

        /// <summary>
        /// Gets or sets the link's title
        /// </summary>
        public string Title
        {
            get => NativeShellItem2 != null ? Properties.System.Title.Value : null;

            set
            {
                if (value == null)

                    throw new ArgumentNullException(nameof(value));

                if (NativeShellItem2 != null)

                    Properties.System.Title.Value = value;
            }
        }

        /// <summary>
        /// Gets the arguments associated with this link.
        /// </summary>
        public string Arguments
        {
            get
            {
                if (string.IsNullOrEmpty(_arguments) && NativeShellItem2 != null)

                    _arguments = Properties.System.Link.Arguments.Value;

                return _arguments;
            }

            set
            {
                if (value == null)

                    throw new ArgumentNullException(nameof(value));

                if (NativeShellItem2 != null)
                {
                    Properties.System.Link.Arguments.Value = value;

                    _arguments = value;
                }
            }
        }

        /// <summary>
        /// Gets the comments associated with this link.
        /// </summary>
        public string Comments
        {
            get
            {
                if (string.IsNullOrEmpty(_comments) && NativeShellItem2 != null)

                    _comments = Properties.System.Comment.Value;

                return _comments;
            }

            set
            {
                if (value == null)

                    throw new ArgumentNullException(nameof(value));

                if (NativeShellItem2 != null)
                {
                    Properties.System.Comment.Value = value;

                    _comments = value;
                }
            }
        }
        #endregion

        #region Constructors
        internal ShellLink(in IShellItem2 shellItem) : base(shellItem)
        {
            // Left empty.
        }

#if WAPICP3
        private ShellLink(in IShellItem2 shellItem, in string sourcePath) : base(shellItem) => TargetLocation = sourcePath;

        /// <summary>
        /// Creates a shortcut on the disk and returns a <see cref="ShellLink"/> that represents it.
        /// </summary>
        /// <param name="sourcePath">The full target path.</param>
        /// <param name="destPath">If <paramref name="relative"/>, only the destination path's directory; otherwise, the full destination path for the shortcut.</param>
        /// <param name="relative">Indicates whether <paramref name="destPath"/> is relative.</param>
        /// <returns>A <see cref="ShellLink"/> that represents the newly created shortcut.</returns>
        public static ShellLink Create(string sourcePath, string destPath, bool relative)
        {
            if (relative)

                return Create(sourcePath, $"{destPath}\\\\{System.IO.Path.GetFileNameWithoutExtension(sourcePath)}.lnk", false);
#else
        /// <summary>
        /// Initializes a new instance of the <see cref="ShellLink"/> class and directly saves the link on disk.
        /// </summary>
        /// <param name="sourcePath">The full source path.</param>
        /// <param name="destPath">The destination directory.</param>
        public ShellLink(in string sourcePath, string destPath)
        {
#endif
            var lnk = Activator.CreateInstance(Type.GetTypeFromCLSID(new Guid(NativeAPI.Guids.Shell.CShellLink), true)) as IShellLinkW;
            lnk.SetPath(sourcePath);
#if !WAPICP3
            destPath = $"{destPath}\\\\{System.IO.Path.GetFileNameWithoutExtension(sourcePath)}.lnk";
#endif
            ((IPersistFile)lnk).Save(destPath, true);
#if WAPICP3
            return new ShellLink(ShellObjectFactory.GetNativeShellItem(destPath), sourcePath);
#else
            Path = destPath;
            TargetLocation = sourcePath;
#endif
        }
        #endregion
    }
}
