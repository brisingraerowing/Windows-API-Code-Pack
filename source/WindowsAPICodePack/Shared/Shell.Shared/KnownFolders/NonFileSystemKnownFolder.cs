﻿//Copyright (c) Microsoft Corporation.  All rights reserved.  Distributed under the Microsoft Public License (MS-PL)

using Microsoft.WindowsAPICodePack.COMNative.Shell;
using Microsoft.WindowsAPICodePack.Win32Native.Shell;

using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Microsoft.WindowsAPICodePack.Shell
{
    /// <summary>
    /// Represents a registered non file system Known Folder.
    /// </summary>
    public class NonFileSystemKnownFolder : ShellNonFileSystemFolder, IKnownFolder, IDisposable
    {
        #region Private Fields
        private IKnownFolderNative knownFolderNative;
        private KnownFolderSettings knownFolderSettings;
        #endregion

        #region Internal Constructors
        internal NonFileSystemKnownFolder(IShellItem2 shellItem) : base(shellItem) { /* Left empty. */ }

        internal NonFileSystemKnownFolder(IKnownFolderNative kf)
        {
            Debug.Assert(kf != null);
            knownFolderNative = kf;

            // Set the native shell item
            // and set it on the base class (ShellObject)
            Guid guid = new Guid(NativeAPI.Guids.Shell.IShellItem2);
            knownFolderNative.GetShellItem(0, ref guid, out _nativeShellItem);
        }
        #endregion

        #region Private Members
        private KnownFolderSettings KnownFolderSettings
        {
            get
            {
                if (knownFolderNative == null)
                {
                    // We need to get the PIDL either from the NativeShellItem,
                    // or from base class's property (if someone already set it on us).
                    // Need to use the PIDL to get the native IKnownFolder interface.

                    // Get teh PIDL for the ShellItem
                    if (_nativeShellItem != null && base.PIDL == IntPtr.Zero)

                        base.PIDL = ShellHelper.PidlFromShellItem(_nativeShellItem);

                    // If we have a valid PIDL, get the native IKnownFolder
                    if (base.PIDL != IntPtr.Zero)

                        knownFolderNative = KnownFolderHelper.FromPIDL(base.PIDL);

                    Debug.Assert(knownFolderNative != null);
                }

                // If this is the first time this property is being called,
                // get the native Folder Defination (KnownFolder properties)

                return knownFolderSettings
#if CS8
                    ??=
#else
                    ?? (knownFolderSettings =
#endif
                    new KnownFolderSettings(knownFolderNative)
#if !CS8
                    )
#endif
                    ;
            }
        }
        #endregion

        #region IKnownFolder Members
        /// <summary>
        /// Gets the path for this known folder.
        /// </summary>
        public string Path => KnownFolderSettings.Path;

        /// <summary>
        /// Gets the category designation for this known folder.
        /// </summary>
        public FolderCategory Category => KnownFolderSettings.Category;

        /// <summary>
        /// Gets this known folder's canonical name.
        /// </summary>
        public string CanonicalName => KnownFolderSettings.CanonicalName;

        /// <summary>
        /// Gets this known folder's description.
        /// </summary>
        public string Description => KnownFolderSettings.Description;

        /// <summary>
        /// Gets the unique identifier for this known folder's parent folder.
        /// </summary>
        public Guid ParentId => KnownFolderSettings.ParentId;

        /// <summary>
        /// Gets this known folder's relative path.
        /// </summary>
        public string RelativePath => KnownFolderSettings.RelativePath;

        /// <summary>
        /// Gets this known folder's parsing name.
        /// </summary>
        public override string ParsingName => base.ParsingName;

        /// <summary>
        /// Gets this known folder's tool tip text.
        /// </summary>
        public string Tooltip => KnownFolderSettings.Tooltip;

        /// <summary>
        /// Gets the resource identifier for this 
        /// known folder's tool tip text.
        /// </summary>
        public string TooltipResourceId => KnownFolderSettings.TooltipResourceId;

        /// <summary>
        /// Gets this known folder's localized name.
        /// </summary>
        public string LocalizedName => KnownFolderSettings.LocalizedName;
        /// <summary>
        /// Gets the resource identifier for this 
        /// known folder's localized name.
        /// </summary>
        public string LocalizedNameResourceId => KnownFolderSettings.LocalizedNameResourceId;

        /// <summary>
        /// Gets this known folder's security attributes.
        /// </summary>
        public string Security => KnownFolderSettings.Security;

        /// <summary>
        /// Gets this known folder's file attributes, 
        /// such as "read-only".
        /// </summary>
        public FileAttributes FileAttributes => KnownFolderSettings.FileAttributes;

        /// <summary>
        /// Gets an value that describes this known folder's behaviors.
        /// </summary>
        public DefinitionOptions DefinitionOptions => KnownFolderSettings.DefinitionOptions;

        /// <summary>
        /// Gets the unique identifier for this known folder's type.
        /// </summary>
        public Guid FolderTypeId => KnownFolderSettings.FolderTypeId;

        /// <summary>
        /// Gets a string representation of this known folder's type.
        /// </summary>
        public string FolderType => KnownFolderSettings.FolderType;

        /// <summary>
        /// Gets the unique identifier for this known folder.
        /// </summary>
        public Guid FolderId => KnownFolderSettings.FolderId;

        /// <summary>
        /// Gets a value that indicates whether this known folder's path exists on the computer. 
        /// </summary>
        /// <value>A <see cref="bool"/> value.</value>
        /// <remarks>If this property value is <b>false</b>, 
        /// the folder might be a virtual folder (<see cref="Category"/> property will
        /// be <see cref="FolderCategory.Virtual"/> for virtual folders)</remarks>
        public bool PathExists => KnownFolderSettings.PathExists;

        /// <summary>
        /// Gets a value that states whether this known folder 
        /// can have its path set to a new value, 
        /// including any restrictions on the redirection.
        /// </summary>
        public RedirectionCapability Redirection => KnownFolderSettings.Redirection;
        #endregion IKnownFolder Members

        #region IDisposable Members
        /// <summary>
        /// Release resources.
        /// </summary>
        /// <param name="disposing">Indicates that this mothod is being called from <see cref="Dispose"/> rather than the finalizer.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)

                knownFolderSettings = null;

            Win32Native.CoreHelpers.DisposeCOMObject(ref knownFolderNative);

            base.Dispose(disposing);
        }
        #endregion
    }
}
