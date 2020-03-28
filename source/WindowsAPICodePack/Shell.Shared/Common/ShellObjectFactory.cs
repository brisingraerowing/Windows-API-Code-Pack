// Copyright (c) Microsoft Corporation.  All rights reserved.

using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Linq;
using System.Threading;
using Microsoft.WindowsAPICodePack.Win32Native.Shell;
using Microsoft.WindowsAPICodePack.Win32Native;
using Microsoft.WindowsAPICodePack.Win32Native.Shell.Resources;
using Microsoft.WindowsAPICodePack.COMNative.Shell;

namespace Microsoft.WindowsAPICodePack.Shell
{
    public static class ShellObjectFactory
    {
        /// <summary>
        /// Creates a ShellObject given a native IShellItem interface
        /// </summary>
        /// <param name="nativeShellItem"></param>
        /// <returns>A newly constructed ShellObject object</returns>
        public static ShellObject Create(IShellItem nativeShellItem)
        {
            // Sanity check
            Debug.Assert(nativeShellItem != null, "nativeShellItem should not be null");

            // Need to make sure we're running on Vista or higher
            if (!CoreHelpers.RunningOnVista)

                throw new PlatformNotSupportedException(LocalizedMessages.ShellObjectFactoryPlatformNotSupported);

            // A lot of APIs need IShellItem2, so just keep a copy of it here
            var nativeShellItem2 = nativeShellItem as IShellItem2;

            // Get the System.ItemType property
            string itemType = ShellHelper.GetItemType(nativeShellItem2);

            if (!string.IsNullOrEmpty(itemType)) itemType = itemType.ToUpperInvariant();

            // Get some IShellItem attributes
            nativeShellItem2.GetAttributes(ShellFileGetAttributesOptions.FileSystem | ShellFileGetAttributesOptions.Folder, out ShellFileGetAttributesOptions sfgao);

            // Is this item a FileSystem item?
            bool isFileSystem = (sfgao & ShellFileGetAttributesOptions.FileSystem) != 0;

            // Is this item a Folder?
            bool isFolder = (sfgao & ShellFileGetAttributesOptions.Folder) != 0;

            // Shell Library
            ShellLibrary shellLibrary;

            // Create the right type of ShellObject based on the above information 

            // 1. First check if this is a Shell Link
            if (itemType == ".lnk")

                return new ShellLink(nativeShellItem2);

            // 2. Check if this is a container or a single item (entity)
            else if (isFolder)
            {
                // 3. If this is a folder, check for types: Shell Library, Shell Folder or Search Container
                switch (itemType)
                {
                    case ".library-ms" when (shellLibrary = ShellLibrary.FromShellItem(nativeShellItem2, true)) != null:
                        return shellLibrary; // we already created this above while checking for Library
                    case ".searchconnector-ms":
                        return new ShellSearchConnector(nativeShellItem2);
                    case ".search-ms":
                        return new ShellSavedSearchCollection(nativeShellItem2);
                }

                // 4. It's a ShellFolder
                if (isFileSystem)
                {
                    // 5. Is it a (File-System / Non-Virtual) Known Folder
                    if (!IsVirtualKnownFolder(nativeShellItem2))
                    { //needs to check if it is a known folder and not virtual
                        var kf = new FileSystemKnownFolder(nativeShellItem2);

                        return kf;
                    }

                    return new ShellFileSystemFolder(nativeShellItem2);
                }

                // 5. Is it a (Non File-System / Virtual) Known Folder
                if (IsVirtualKnownFolder(nativeShellItem2))
                { //needs to check if known folder is virtual
                    var kf = new NonFileSystemKnownFolder(nativeShellItem2);

                    return kf;
                }

                return new ShellNonFileSystemFolder(nativeShellItem2);
            }

            // 6. If this is an entity (single item), check if its filesystem or not
            return isFileSystem ? new ShellFile(nativeShellItem2) : (ShellObject)new ShellNonFileSystemItem(nativeShellItem2);
        }

        // This is a work around for the STA thread bug.  This will execute the call on a non-sta thread, then return the result
        private static bool IsVirtualKnownFolder(IShellItem2 nativeShellItem2)
        {
            IntPtr pidl = IntPtr.Zero;

            try
            {
                IKnownFolderNative nativeFolder = null;
                var definition = new KnownFoldersSafeNativeMethods.NativeFolderDefinition();

                // We found a bug where the enumeration of shell folders was
                // not reliable when called from a STA thread - it would return
                // different results the first time vs the other times.
                //
                // This is a work around.  We call FindFolderFromIDList on a
                // worker MTA thread instead of the main STA thread.
                //
                // Ultimately, it would be a very good idea to replace the 'getting shell object' logic
                // to get a list of pidl's in 1 step, then look up their information in a 2nd, rather than
                // looking them up as we get them.  This would replace the need for the work around.
                object padlock = new object();

                lock (padlock)
                {
                    IntPtr unknown = Marshal.GetIUnknownForObject(nativeShellItem2);

                    _ = ThreadPool.QueueUserWorkItem(obj =>
                      {
                          lock (padlock)
                          {
                              pidl = ShellHelper.PidlFromUnknown(unknown);

                              new KnownFolderManagerClass().FindFolderFromIDList(pidl, out nativeFolder);

                                  nativeFolder?.GetFolderDefinition(out definition);

                              Monitor.Pulse(padlock);
                          }
                      });

                    _ = Monitor.Wait(padlock);
                }

                return nativeFolder != null && definition.category == FolderCategory.Virtual;
            }
            finally
            {
                Win32Native.Shell.Shell.ILFree(pidl);
            }
        }

        /// <summary>
        /// Creates a ShellObject given a parsing name
        /// </summary>
        /// <param name="parsingName"></param>
        /// <returns>A newly constructed ShellObject object</returns>
        public static ShellObject Create(string parsingName)
        {
            if (string.IsNullOrEmpty(parsingName))
            
                throw new ArgumentNullException(nameof(parsingName));

            // Create a native shellitem from our path
            var guid = new Guid(Win32Native.Guids.Shell.IShellItem2);
            int retCode = COMNative.Shell.Shell.SHCreateItemFromParsingName(parsingName, IntPtr.Zero, ref guid, out IShellItem2 nativeShellItem);

            return CoreErrorHelper.Succeeded(retCode) ? ShellObjectFactory.Create(nativeShellItem) : throw new ShellException(LocalizedMessages.ShellObjectFactoryUnableToCreateItem, Marshal.GetExceptionForHR(retCode));
        }

        /// <summary>
        /// Constructs a new Shell object from IDList pointer
        /// </summary>
        /// <param name="idListPtr"></param>
        /// <returns></returns>
        public static ShellObject Create(IntPtr idListPtr)
        {
            // Throw exception if not running on Win7 or newer.
            CoreHelpers.ThrowIfNotVista();

            var guid = new Guid(Win32Native.Guids.Shell.IShellItem2);

            int retCode = COMNative.Shell.Shell.SHCreateItemFromIDList(idListPtr, ref guid, out IShellItem2 nativeShellItem);

            return CoreErrorHelper.Succeeded(retCode) ? Create(nativeShellItem) : null;
        }

        /// <summary>
        /// Constructs a new Shell object from IDList pointer
        /// </summary>
        /// <param name="idListPtr"></param>
        /// <param name="parent"></param>
        /// <returns></returns>
        public static ShellObject Create(IntPtr idListPtr, ShellContainer parent)
        {
            int retCode = COMNative.Shell.Shell.SHCreateShellItem(
                IntPtr.Zero,
                parent.NativeShellFolder,
                idListPtr, out IShellItem nativeShellItem);

            return CoreErrorHelper.Succeeded(retCode) ? Create(nativeShellItem) : null;
        }
    }
}
