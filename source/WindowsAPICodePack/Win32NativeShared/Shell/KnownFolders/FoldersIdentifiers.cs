//Copyright (c) Microsoft Corporation.  All rights reserved.

using Microsoft.WindowsAPICodePack.Win32Native.Shell.Resources;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Microsoft.WindowsAPICodePack.Win32Native.Shell
{
    /// <summary>
    /// Contains the GUID identifiers for well-known folders.
    /// </summary>
    public static class FolderIdentifiers
    {
        private static Dictionary<Guid, string> folders;

        static FolderIdentifiers()
        {
            folders = new Dictionary<Guid, string>();
            Type folderIDs = typeof(FolderIdentifiers);

            FieldInfo[] fields = folderIDs.GetFields(BindingFlags.NonPublic | BindingFlags.Static);
            foreach (FieldInfo f in fields)
            {
                // Ignore dictionary field.
                if (f.FieldType == typeof(Guid))

                    folders.Add((Guid)f.GetValue(null), f.Name);
            }
        }
        /// <summary>
        /// Returns the friendly name for a specified folder.
        /// </summary>
        /// <param name="folderId">The Guid identifier for a known folder.</param>
        /// <returns>A <see cref="T:System.String"/> value.</returns>
        public static string NameForGuid(Guid folderId)
        {
            if (!folders.TryGetValue(folderId, out string folder))

                throw new ArgumentException(LocalizedMessages.FolderIdsUnknownGuid, "folderId");

            return folder;
        }
        /// <summary>
        /// Returns a sorted list of name, guid pairs for 
        /// all known folders.
        /// </summary>
        /// <returns></returns>
        public static SortedList<string, Guid> GetAllFolders()
        {
            // Make a copy of the dictionary
            // because the Keys and Values collections
            // are mutable.
            ICollection<Guid> keys = folders.Keys;

            SortedList<string, Guid> slist = new SortedList<string, Guid>();
            foreach (Guid g in keys)

                slist.Add(folders[g], g);

            return slist;
        }
    }
}