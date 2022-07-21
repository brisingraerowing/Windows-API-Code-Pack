//Copyright (c) Microsoft Corporation.  All rights reserved.  Distributed under the Microsoft Public License (MS-PL)

using Microsoft.WindowsAPICodePack.COMNative.Shell;
using Microsoft.WindowsAPICodePack.Win32Native;
using Microsoft.WindowsAPICodePack.Win32Native.Shell;
using Microsoft.WindowsAPICodePack.Win32Native.Shell.Resources;

using System;
using System.Diagnostics;

using static Microsoft.WindowsAPICodePack.Win32Native.Shell.Shell;

namespace Microsoft.WindowsAPICodePack.Shell
{
    /// <summary>
    /// Creates the helper class for known folders.
    /// </summary>
    public static class KnownFolderHelper
    {
        /// <summary>
        /// Returns the native known folder (<see cref="IKnownFolderNative"/>) given a PID list
        /// </summary>
        internal static IKnownFolderNative FromPIDL(in IntPtr pidl) => new KnownFolderManagerClass().FindFolderFromIDList(pidl, out IKnownFolderNative knownFolder) == HResult.Ok ? knownFolder : null;

        public static IKnownFolder FromKnownFolderId(in string knownFolderId) => FromKnownFolderId(new Guid(knownFolderId));

        /// <summary>
        /// Returns a known folder given a globally unique identifier.
        /// </summary>
        /// <param name="knownFolderId">A <see cref="Guid"/> for the requested known folder.</param>
        /// <returns>A known folder representing the specified name.</returns>
        /// <exception cref="ArgumentException">Thrown if the given Known Folder ID is invalid.</exception>
        public static IKnownFolder FromKnownFolderId(in Guid knownFolderId)
        {
            HResult hr = new KnownFolderManagerClass().GetFolder(knownFolderId, out IKnownFolderNative knownFolderNative);

            return hr != HResult.Ok
                ? throw new ShellException(hr)
                : GetKnownFolder(knownFolderNative) ?? throw new ArgumentException(LocalizedMessages.KnownFolderInvalidGuid, nameof(knownFolderId));
        }

        /// <summary>
        /// Returns a known folder given a globally unique identifier.
        /// </summary>
        /// <param name="knownFolderId">A <see cref="Guid"/> for the requested known folder.</param>
        /// <returns>A known folder representing the specified name. Returns <see langword="null"/> if Known Folder is not found or could not be created.</returns>
        internal static IKnownFolder FromKnownFolderIdInternal(in Guid knownFolderId) => new KnownFolderManagerClass().GetFolder(knownFolderId, out IKnownFolderNative knownFolderNative) == HResult.Ok ? GetKnownFolder(knownFolderNative) : null;

        /// <summary>
        /// Given a native KnownFolder (<see cref="IKnownFolderNative"/>), create the right type of
        /// <see cref="IKnownFolder"/> object (<see cref="FileSystemKnownFolder"/> or <see cref="NonFileSystemKnownFolder"/>)
        /// </summary>
        /// <param name="knownFolderNative">Native Known Folder</param>
        private static IKnownFolder GetKnownFolder(in IKnownFolderNative knownFolderNative)
        {
            Debug.Assert(knownFolderNative != null, "Native IKnownFolder should not be null.");

            // Get the native IShellItem2 from the native IKnownFolder
            var guid = new Guid(NativeAPI.Guids.Shell.IShellItem2);

            HResult hr = knownFolderNative.GetShellItem(0, ref guid, out IShellItem2 shellItem);

            if (!CoreErrorHelper.Succeeded(hr)) return null;

            bool isFileSystem = false;

            // If we have a valid IShellItem, try to get the FileSystem attribute.
            if (shellItem != null)
            {
                shellItem.GetAttributes(ShellFileGetAttributesOptions.FileSystem, out ShellFileGetAttributesOptions sfgao);

                // Is this item a FileSystem item?
                isFileSystem = (sfgao & ShellFileGetAttributesOptions.FileSystem) != 0;
            }

            // If it's FileSystem, create a FileSystemKnownFolder, else NonFileSystemKnownFolder
            return isFileSystem ? new FileSystemKnownFolder(knownFolderNative) : (IKnownFolder)new NonFileSystemKnownFolder(knownFolderNative);
        }

        /// <summary>
        /// Returns the known folder given its canonical name.
        /// </summary>
        /// <param name="canonicalName">A non-localized canonical name for the known folder, such as MyComputer.</param>
        /// <returns>A known folder representing the specified name.</returns>
        /// <exception cref="System.ArgumentException">Thrown if the given canonical name is invalid or if the KnownFolder could not be created.</exception>
        public static IKnownFolder FromCanonicalName(in string canonicalName)
        {
            new KnownFolderManagerClass().GetFolderByName(canonicalName, out IKnownFolderNative knownFolderNative);

            return GetKnownFolder(knownFolderNative) ?? throw new ArgumentException(LocalizedMessages.ShellInvalidCanonicalName, nameof(canonicalName));
        }

        /// <summary>
        /// Returns a known folder given its shell path, such as <c>C:\users\public\documents</c> or 
        /// <c>::{645FF040-5081-101B-9F08-00AA002F954E}</c> for the Recycle Bin.
        /// </summary>
        /// <param name="path">The path for the requested known folder; either a physical path or a virtual path.</param>
        /// <returns>A known folder representing the specified name.</returns>
        public static IKnownFolder FromPath(in string path) => FromParsingName(path);

        /// <summary>
        /// Returns a known folder given its shell namespace parsing name, such as 
        /// <c>::{645FF040-5081-101B-9F08-00AA002F954E}</c> for the Recycle Bin.
        /// </summary>
        /// <param name="parsingName">The parsing name (or path) for the requested known folder.</param>
        /// <returns>A known folder representing the specified name.</returns>
        /// <exception cref="System.ArgumentException">Thrown if the given parsing name is invalid.</exception>
        public static IKnownFolder FromParsingName(in string parsingName)
        {
            IntPtr pidl = parsingName == null ? throw new ArgumentNullException(nameof(parsingName)) : IntPtr.Zero;
            IntPtr pidl2 = IntPtr.Zero;

            try
            {
                pidl = ShellHelper.PidlFromParsingName(parsingName);

                // It's probably a special folder, try to get it                
                IKnownFolderNative knownFolderNative = pidl == IntPtr.Zero ? throw new ArgumentException(LocalizedMessages.KnownFolderParsingName, nameof(parsingName)) : FromPIDL(pidl);

                if (knownFolderNative != null)

                    return GetKnownFolder(knownFolderNative) ?? throw new ArgumentException(LocalizedMessages.KnownFolderParsingName, nameof(parsingName));

                // No physical storage was found for this known folder
                // We'll try again with a different name

                // try one more time with a trailing \0
                pidl2 = ShellHelper.PidlFromParsingName(parsingName.PadRight(1, '\0'));

                return pidl2 == IntPtr.Zero
                    ? throw new ArgumentException(LocalizedMessages.KnownFolderParsingName, nameof(parsingName))
                    : GetKnownFolder(FromPIDL(pidl)) ?? throw new ArgumentException(LocalizedMessages.KnownFolderParsingName, nameof(parsingName));
            }

            finally
            {
                ILFree(pidl);
                ILFree(pidl2);
            }
        }
    }
}
