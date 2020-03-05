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
        private static readonly Dictionary<Guid, string> folders;

        static FolderIdentifiers()
        {
            folders = new Dictionary<Guid, string>();
            Type folderIDs = typeof(Microsoft.WindowsAPICodePack.Shell.Guids.KnownFolders);

#if !NETFRAMEWORK

            static

#endif

                void add(in Type type)

            {

                FieldInfo[] fields = type.GetFields(BindingFlags.NonPublic | BindingFlags.Static);
                foreach (FieldInfo f in fields)

                    folders.Add(new Guid((string)f.GetValue(null)), f.Name);

            }

            add(folderIDs);

            // todo: parse sub-nested types

            Type[] types = folderIDs.GetNestedTypes();

            foreach (Type t in types)

            {

                if (t.IsClass)

                    add(t);

            }
        }

        /// <summary>
        /// Returns the friendly name for a specified folder.
        /// </summary>
        /// <param name="folderId">The Guid identifier for a known folder.</param>
        /// <returns>A <see cref="T:System.String"/> value.</returns>
        public static string NameForGuid(Guid folderId) => folders.TryGetValue(folderId, out string folder) ? folder : throw new ArgumentException(LocalizedMessages.FolderIdsUnknownGuid, nameof(folderId));

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

            var slist = new SortedList<string, Guid>();
            foreach (Guid g in keys)

                slist.Add(folders[g], g);

            return slist;
        }
    }
}