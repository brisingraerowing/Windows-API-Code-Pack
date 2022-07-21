//Copyright (c) Microsoft Corporation.  All rights reserved.  Distributed under the Microsoft Public License (MS-PL)

using Microsoft.WindowsAPICodePack.Win32Native.Shell;
using Microsoft.WindowsAPICodePack.Win32Native;
using Microsoft.WindowsAPICodePack.Win32Native.Shell.Resources;
using Microsoft.WindowsAPICodePack.COMNative.Shell;

using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;

namespace Microsoft.WindowsAPICodePack.Shell
{
    public static class ShellObjectFactory
    {
        /// <summary>
        /// Creates a <see cref="ShellObject"/> given a native <see cref="IShellItem"/> interface.
        /// </summary>
        /// <param name="nativeShellItem">The native <see cref="IShellItem"/> from which to create the new <see cref="ShellObject"/>.</param>
        /// <returns>A newly constructed <see cref="ShellObject"/> object.</returns>
        public static ShellObject Create(IShellItem nativeShellItem)
        {
            // Sanity check
            Debug.Assert(nativeShellItem != null, "nativeShellItem should not be null");

            // Need to make sure we're running on Vista or higher
            // A lot of APIs need IShellItem2, so just keep a copy of it here
            var nativeShellItem2 = CoreHelpers.RunningOnVista ? nativeShellItem as IShellItem2 : throw new PlatformNotSupportedException(LocalizedMessages.ShellObjectFactoryPlatformNotSupported);

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
            if (".lnk".Equals(itemType, StringComparison.OrdinalIgnoreCase))

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
                return isFileSystem ?

                    // 5. Is it a (File-System / Non-Virtual) Known Folder
                    IsVirtualKnownFolder(nativeShellItem2) ?
                        //needs to check if it is a known folder and not virtual


                        new ShellFileSystemFolder(nativeShellItem2)
                        : new FileSystemKnownFolder(nativeShellItem2)

                    // 5. Is it a (Non File-System / Virtual) Known Folder
                    : IsVirtualKnownFolder(nativeShellItem2) ?
                    //needs to check if known folder is virtual
                    new NonFileSystemKnownFolder(nativeShellItem2)

                    :
#if !CS9
                    (ShellObject)
#endif
                    new ShellNonFileSystemFolder(nativeShellItem2);
            }

            // 6. If this is an entity (single item), check if its filesystem or not
            return isFileSystem ? new ShellFile(nativeShellItem2) :
#if !CS9
                    (ShellObject)
#endif
                    new ShellNonFileSystemItem(nativeShellItem2);
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
                var padlock = new object();

                lock (padlock)
                {
                    IntPtr unknown = Marshal.GetIUnknownForObject(nativeShellItem2);

                    _ = ThreadPool.QueueUserWorkItem(obj =>
                    {
                        lock (padlock)
                        {
                            pidl = ShellHelper.PidlFromUnknown(unknown);

                            _ = new KnownFolderManagerClass().FindFolderFromIDList(pidl, out nativeFolder);

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

        public static
#if WAPICP3
            HResult
#else
            int
#endif
            TryGetNativeShellItem(string parsingName, out IShellItem2 result)
        {
            // Create a native shellitem from our path
            var guid = string.IsNullOrEmpty(parsingName) ? throw new ArgumentNullException(nameof(parsingName)) : new Guid(NativeAPI.Guids.Shell.IShellItem2);

            return COMNative.Shell.Shell.SHCreateItemFromParsingName(parsingName, IntPtr.Zero, ref guid, out result);
        }

        public static IShellItem2 GetNativeShellItem(string parsingName)
        {
            HResult retCode =
#if !WAPICP3
                (HResult)
#endif
                TryGetNativeShellItem(parsingName, out IShellItem2 result);

            return CoreErrorHelper.Succeeded(retCode) ? result : throw new ShellException(LocalizedMessages.ShellObjectFactoryUnableToCreateItem, CoreErrorHelper.GetExceptionForHR(retCode));
        }

        /// <summary>
        /// Creates a <see cref="ShellObject"/> given a parsing name.
        /// </summary>
        /// <param name="parsingName">The parsing name from which to create the new <see cref="ShellObject"/>.</param>
        /// <returns>A newly constructed <see cref="ShellObject"/> object.</returns>
        public static ShellObject Create(string parsingName) => Create(GetNativeShellItem(parsingName));

        /// <summary>
        /// Constructs a new <see cref="ShellObject"/> from an IDList pointer.
        /// </summary>
        /// <param name="idListPtr">The IDList pointer from which to create the new <see cref="ShellObject"/>.</param>
        /// <returns>A newly constructed <see cref="ShellObject"/> object or <see langword="null"/> if no <see cref="IShellItem2"/> could be retrieved.</returns>
        /// <seealso cref="Create(IntPtr, ShellContainer)"/>
        public static ShellObject
#if CS8
            ?
#endif
            Create(IntPtr idListPtr)
        {
            // Throw exception if not running on Win7 or newer.
            CoreHelpers.ThrowIfNotVista();

            var guid = new Guid(NativeAPI.Guids.Shell.IShellItem2);

            int retCode = COMNative.Shell.Shell.SHCreateItemFromIDList(idListPtr, ref guid, out IShellItem2 nativeShellItem);

            return CoreErrorHelper.Succeeded(retCode) ? Create(nativeShellItem) : null;
        }

        /// <summary>
        /// Constructs a new <see cref="ShellObject"/> from an IDList pointer and a parent <see cref="ShellContainer"/>.
        /// </summary>
        /// <param name="idListPtr">The IDList pointer from which to create the new <see cref="ShellObject"/>.</param>
        /// <returns>A newly constructed <see cref="ShellObject"/> object or <see langword="null"/> if no <see cref="IShellItem"/> could be retrieved.</returns>
        /// <seealso cref="Create(IntPtr)"/>
        public static ShellObject Create(IntPtr idListPtr, ShellContainer parent) => CoreErrorHelper.Succeeded(COMNative.Shell.Shell.SHCreateShellItem(
                IntPtr.Zero,
                parent.NativeShellFolder,
                idListPtr, out IShellItem nativeShellItem)) ? Create(nativeShellItem) : null;
    }
}
