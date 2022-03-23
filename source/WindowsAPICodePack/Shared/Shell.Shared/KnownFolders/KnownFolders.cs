//Copyright (c) Microsoft Corporation.  All rights reserved.  Distributed under the Microsoft Public License (MS-PL)

using Microsoft.WindowsAPICodePack.COMNative.Shell;
using Microsoft.WindowsAPICodePack.Win32Native;

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

using static Microsoft.WindowsAPICodePack.Shell.KnownFolderHelper;

namespace Microsoft.WindowsAPICodePack.Shell
{
    /// <summary>
    /// Defines properties for known folders that identify the path of standard known folders.
    /// </summary>
    public static class KnownFolders
    {
        /// <summary>
        /// Gets a strongly-typed read-only collection of all the registered known folders.
        /// </summary>
        public static System.Collections.Generic.ICollection<IKnownFolder> All => GetAllFolders();

        private static System.Collections.ObjectModel.ReadOnlyCollection<IKnownFolder> GetAllFolders()
        {
            // Should this method be thread-safe?? (It'll take a while
            // to get a list of all the known folders, create the managed wrapper
            // and return the read-only collection.

            var foldersList = new
#if CS7
                WinCopies.Collections.
#if WAPICP3
                Generic.
#endif
                ArrayBuilder
#else
                LinkedList
#endif
                <IKnownFolder>();

            IntPtr folders = IntPtr.Zero;

            try
            {
                new KnownFolderManagerClass().GetFolderIds(out folders, out uint count);

                if (count > 0 && folders != IntPtr.Zero)

                    // Loop through all the KnownFolderID elements
                    for (int i = 0; i < count; i++)
                    {
                        // Convert to Guid
                        var knownFolderID = (Guid)Marshal.PtrToStructure(new IntPtr(folders.ToInt64() + (Marshal.SizeOf(typeof(Guid)) * i)), typeof(Guid));

                        IKnownFolder kf = FromKnownFolderIdInternal(knownFolderID);

                        // Add to our collection if it's not null (some folders might not exist on the system
                        // or we could have an exception that resulted in the null return from above method call
                        if (kf != null) _ = foldersList.AddLast(kf);
                    }
            }

            finally
            {
                if (folders != IntPtr.Zero) Marshal.FreeCoTaskMem(folders);
            }

#if !CS7
            var list = new List<IKnownFolder>(foldersList.Count);

            foreach (IKnownFolder item in list)

                list.Add(item);
#endif

            return new System.Collections.ObjectModel.ReadOnlyCollection<IKnownFolder>(
#if CS7
                foldersList.ToList()
#else
                list
#endif
                );
        }

        #region Default Known Folders
        /// <summary>
        /// Gets the metadata for the <b>Computer</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder Computer => FromKnownFolderId(Guids.KnownFolders.Computer);

        /// <summary>
        /// Gets the metadata for the <b>Conflict</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder Conflict => FromKnownFolderId(Guids.KnownFolders.Conflict);

        /// <summary>
        /// Gets the metadata for the <b>ControlPanel</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder ControlPanel => FromKnownFolderId(Guids.KnownFolders.ControlPanel);

        /// <summary>
        /// Gets the metadata for the <b>Desktop</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder Desktop => FromKnownFolderId(Guids.KnownFolders.Desktop);

        /// <summary>
        /// Gets the metadata for the <b>Internet</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder Internet => FromKnownFolderId(Guids.KnownFolders.Internet);

        /// <summary>
        /// Gets the metadata for the <b>Network</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder Network => FromKnownFolderId(Guids.KnownFolders.Network);

        /// <summary>
        /// Gets the metadata for the <b>Printers</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder Printers => FromKnownFolderId(Guids.KnownFolders.Printers);

        /// <summary>
        /// Gets the metadata for the <b>SyncManager</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder SyncManager => FromKnownFolderId(Guids.KnownFolders.SyncManager);

        /// <summary>
        /// Gets the metadata for the <b>Connections</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder Connections => FromKnownFolderId(Guids.KnownFolders.Connections);

        /// <summary>
        /// Gets the metadata for the <b>SyncSetup</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder SyncSetup => FromKnownFolderId(Guids.KnownFolders.SyncSetup);

        /// <summary>
        /// Gets the metadata for the <b>SyncResults</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder SyncResults => FromKnownFolderId(Guids.KnownFolders.SyncResults);

        /// <summary>
        /// Gets the metadata for the <b>RecycleBin</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder RecycleBin => FromKnownFolderId(Guids.KnownFolders.RecycleBin);

        /// <summary>
        /// Gets the metadata for the <b>Fonts</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder Fonts => FromKnownFolderId(Guids.KnownFolders.Fonts);

        /// <summary>
        /// Gets the metadata for the <b>Startup</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder Startup => FromKnownFolderId(Guids.KnownFolders.Startup);

        /// <summary>
        /// Gets the metadata for the <b>Programs</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder Programs => FromKnownFolderId(Guids.KnownFolders.Programs);

        /// <summary>
        /// Gets the metadata for the per-user <b>StartMenu</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder StartMenu => FromKnownFolderId(Guids.KnownFolders.StartMenu);

        /// <summary>
        /// Gets the metadata for the per-user <b>Recent</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder Recent => FromKnownFolderId(Guids.KnownFolders.Recent);

        /// <summary>
        /// Gets the metadata for the per-user <b>SendTo</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder SendTo => FromKnownFolderId(Guids.KnownFolders.SendTo);

        /// <summary>
        /// Gets the metadata for the per-user <b>Documents</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder Documents => FromKnownFolderId(Guids.KnownFolders.Documents);

        /// <summary>
        /// Gets the metadata for the per-user <b>Favorites</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder Favorites => FromKnownFolderId(Guids.KnownFolders.Favorites);

        /// <summary>
        /// Gets the metadata for the <b>NetHood</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder NetHood => FromKnownFolderId(Guids.KnownFolders.NetHood);

        /// <summary>
        /// Gets the metadata for the <b>PrintHood</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder PrintHood => FromKnownFolderId(Guids.KnownFolders.PrintHood);

        /// <summary>
        /// Gets the metadata for the <b>Templates</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder Templates => FromKnownFolderId(Guids.KnownFolders.Templates);

        /// <summary>
        /// Gets the metadata for the <b>CommonStartup</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder CommonStartup => FromKnownFolderId(Guids.KnownFolders.CommonStartup);

        /// <summary>
        /// Gets the metadata for the <b>CommonPrograms</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder CommonPrograms => FromKnownFolderId(Guids.KnownFolders.CommonPrograms);

        /// <summary>
        /// Gets the metadata for the <b>CommonStartMenu</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder CommonStartMenu => FromKnownFolderId(Guids.KnownFolders.CommonStartMenu);

        /// <summary>
        /// Gets the metadata for the <b>PublicDesktop</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder PublicDesktop => FromKnownFolderId(Guids.KnownFolders.PublicDesktop);

        /// <summary>
        /// Gets the metadata for the <b>ProgramData</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder ProgramData => FromKnownFolderId(Guids.KnownFolders.ProgramData);

        /// <summary>
        /// Gets the metadata for the <b>CommonTemplates</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder CommonTemplates => FromKnownFolderId(Guids.KnownFolders.CommonTemplates);

        /// <summary>
        /// Gets the metadata for the <b>PublicDocuments</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder PublicDocuments => FromKnownFolderId(Guids.KnownFolders.PublicDocuments);

        /// <summary>
        /// Gets the metadata for the <b>RoamingAppData</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder RoamingAppData => FromKnownFolderId(Guids.KnownFolders.RoamingAppData);

        /// <summary>
        /// Gets the metadata for the per-user <b>LocalAppData</b>  
        /// folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder LocalAppData => FromKnownFolderId(Guids.KnownFolders.LocalAppData);

        /// <summary>
        /// Gets the metadata for the <b>LocalAppDataLow</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder LocalAppDataLow => FromKnownFolderId(Guids.KnownFolders.LocalAppDataLow);

        /// <summary>
        /// Gets the metadata for the <b>InternetCache</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder InternetCache => FromKnownFolderId(Guids.KnownFolders.InternetCache);

        /// <summary>
        /// Gets the metadata for the <b>Cookies</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder Cookies => FromKnownFolderId(Guids.KnownFolders.Cookies);

        /// <summary>
        /// Gets the metadata for the <b>History</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder History => FromKnownFolderId(Guids.KnownFolders.History);

        /// <summary>
        /// Gets the metadata for the <b>System</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder System => FromKnownFolderId(Guids.KnownFolders.System);

        /// <summary>
        /// Gets the metadata for the <b>SystemX86</b>  
        /// folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder SystemX86 => FromKnownFolderId(Guids.KnownFolders.SystemX86);

        /// <summary>
        /// Gets the metadata for the <b>Windows</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder Windows => FromKnownFolderId(Guids.KnownFolders.Windows);

        /// <summary>
        /// Gets the metadata for the <b>Profile</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder Profile => FromKnownFolderId(Guids.KnownFolders.Profile);

        /// <summary>
        /// Gets the metadata for the per-user <b>Pictures</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder Pictures => FromKnownFolderId(Guids.KnownFolders.Pictures);

        /// <summary>
        /// Gets the metadata for the <b>ProgramFilesX86</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder ProgramFilesX86 => FromKnownFolderId(Guids.KnownFolders.ProgramFilesX86);

        /// <summary>
        /// Gets the metadata for the <b>ProgramFilesCommonX86</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder ProgramFilesCommonX86 => FromKnownFolderId(Guids.KnownFolders.ProgramFilesCommonX86);

        /// <summary>
        /// Gets the metadata for the <b>ProgramsFilesX64</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder ProgramFilesX64 => FromKnownFolderId(Guids.KnownFolders.ProgramFilesX64);

        /// <summary>
        ///  Gets the metadata for the <b> ProgramFilesCommonX64</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder ProgramFilesCommonX64 => FromKnownFolderId(Guids.KnownFolders.ProgramFilesCommonX64);

        /// <summary>
        /// Gets the metadata for the <b>ProgramFiles</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder ProgramFiles => FromKnownFolderId(Guids.KnownFolders.ProgramFiles);

        /// <summary>
        /// Gets the metadata for the <b>ProgramFilesCommon</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder ProgramFilesCommon => FromKnownFolderId(Guids.KnownFolders.ProgramFilesCommon);

        /// <summary>
        /// Gets the metadata for the <b>AdminTools</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder AdminTools => FromKnownFolderId(Guids.KnownFolders.AdminTools);

        /// <summary>
        /// Gets the metadata for the <b>CommonAdminTools</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder CommonAdminTools => FromKnownFolderId(Guids.KnownFolders.CommonAdminTools);

        /// <summary>
        /// Gets the metadata for the per-user <b>Music</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder Music => FromKnownFolderId(Guids.KnownFolders.Music);

        /// <summary>
        /// Gets the metadata for the <b>Videos</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder Videos => FromKnownFolderId(Guids.KnownFolders.Videos);

        /// <summary>
        /// Gets the metadata for the <b>PublicPictures</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder PublicPictures => FromKnownFolderId(Guids.KnownFolders.PublicPictures);

        /// <summary>
        /// Gets the metadata for the <b>PublicMusic</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder PublicMusic => FromKnownFolderId(Guids.KnownFolders.PublicMusic);

        /// <summary>
        /// Gets the metadata for the <b>PublicVideos</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder PublicVideos => FromKnownFolderId(Guids.KnownFolders.PublicVideos);

        /// <summary>
        /// Gets the metadata for the <b>ResourceDir</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder ResourceDir => FromKnownFolderId(Guids.KnownFolders.ResourceDir);

        /// <summary>
        /// Gets the metadata for the <b>LocalizedResourcesDir</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder LocalizedResourcesDir => FromKnownFolderId(Guids.KnownFolders.LocalizedResourcesDir);

        /// <summary>
        /// Gets the metadata for the <b>CommonOEMLinks</b> folder. 
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder CommonOemLinks => FromKnownFolderId(Guids.KnownFolders.CommonOEMLinks);

        /// <summary>
        /// Gets the metadata for the <b>CDBurning</b> folder. 
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder CDBurning => FromKnownFolderId(Guids.KnownFolders.CDBurning);

        /// <summary>
        /// Gets the metadata for the <b>UserProfiles</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder UserProfiles => FromKnownFolderId(Guids.KnownFolders.UserProfiles);

        /// <summary>
        /// Gets the metadata for the <b>Playlists</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder Playlists => FromKnownFolderId(Guids.KnownFolders.Playlists);

        /// <summary>
        /// Gets the metadata for the <b>SamplePlaylists</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder SamplePlaylists => FromKnownFolderId(Guids.KnownFolders.SamplePlaylists);

        /// <summary>
        /// Gets the metadata for the <b>SampleMusic</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder SampleMusic => FromKnownFolderId(Guids.KnownFolders.SampleMusic);

        /// <summary>
        /// Gets the metadata for the <b>SamplePictures</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder SamplePictures => FromKnownFolderId(Guids.KnownFolders.SamplePictures);

        /// <summary>
        /// Gets the metadata for the <b>SampleVideos</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder SampleVideos => FromKnownFolderId(Guids.KnownFolders.SampleVideos);

        /// <summary>
        /// Gets the metadata for the <b>PhotoAlbums</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder PhotoAlbums => FromKnownFolderId(Guids.KnownFolders.PhotoAlbums);

        /// <summary>
        /// Gets the metadata for the <b>Public</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder Public => FromKnownFolderId(Guids.KnownFolders.Public);

        /// <summary>
        /// Gets the metadata for the <b>ChangeRemovePrograms</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder ChangeRemovePrograms => FromKnownFolderId(Guids.KnownFolders.ChangeRemovePrograms);

        /// <summary>
        /// Gets the metadata for the <b>AppUpdates</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder AppUpdates => FromKnownFolderId(Guids.KnownFolders.AppUpdates);

        /// <summary>
        /// Gets the metadata for the <b>AddNewPrograms</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder AddNewPrograms => FromKnownFolderId(Guids.KnownFolders.AddNewPrograms);

        /// <summary>
        /// Gets the metadata for the per-user <b>Downloads</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder Downloads => FromKnownFolderId(Guids.KnownFolders.Downloads);

        /// <summary>
        /// Gets the metadata for the <b>PublicDownloads</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder PublicDownloads => FromKnownFolderId(Guids.KnownFolders.PublicDownloads);

        /// <summary>
        /// Gets the metadata for the per-user <b>SavedSearches</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder SavedSearches => FromKnownFolderId(Guids.KnownFolders.SavedSearches);

        /// <summary>
        /// Gets the metadata for the per-user <b>QuickLaunch</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder QuickLaunch => FromKnownFolderId(Guids.KnownFolders.QuickLaunch);

        /// <summary>
        /// Gets the metadata for the <b>Contacts</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder Contacts => FromKnownFolderId(Guids.KnownFolders.Contacts);

        /// <summary>
        /// Gets the metadata for the <b>SidebarParts</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder SidebarParts => FromKnownFolderId(Guids.KnownFolders.SidebarParts);

        /// <summary>
        /// Gets the metadata for the <b>SidebarDefaultParts</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder SidebarDefaultParts => FromKnownFolderId(Guids.KnownFolders.SidebarDefaultParts);

        /// <summary>
        /// Gets the metadata for the <b>TreeProperties</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder TreeProperties => FromKnownFolderId(Guids.KnownFolders.TreeProperties);

        /// <summary>
        /// Gets the metadata for the <b>PublicGameTasks</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder PublicGameTasks => FromKnownFolderId(Guids.KnownFolders.PublicGameTasks);

        /// <summary>
        /// Gets the metadata for the <b>GameTasks</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder GameTasks => FromKnownFolderId(Guids.KnownFolders.GameTasks);

        /// <summary>
        /// Gets the metadata for the per-user <b>SavedGames</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder SavedGames => FromKnownFolderId(Guids.KnownFolders.SavedGames);

        /// <summary>
        /// Gets the metadata for the <b>Games</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder Games => FromKnownFolderId(Guids.KnownFolders.Games);

        /// <summary>
        /// Gets the metadata for the <b>RecordedTV</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        /// <remarks>This folder is not used.</remarks>
        public static IKnownFolder RecordedTV => FromKnownFolderId(Guids.KnownFolders.RecordedTV);

        /// <summary>
        /// Gets the metadata for the <b>SearchMapi</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder SearchMapi => FromKnownFolderId(Guids.KnownFolders.SearchMapi);

        /// <summary>
        /// Gets the metadata for the <b>SearchCsc</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder SearchCsc => FromKnownFolderId(Guids.KnownFolders.SearchCsc);

        /// <summary>
        /// Gets the metadata for the per-user <b>Links</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder Links => FromKnownFolderId(Guids.KnownFolders.Links);

        /// <summary>
        /// Gets the metadata for the <b>UsersFiles</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder UsersFiles => FromKnownFolderId(Guids.KnownFolders.UsersFiles);

        /// <summary>
        /// Gets the metadata for the <b>SearchHome</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder SearchHome => FromKnownFolderId(Guids.KnownFolders.SearchHome);

        /// <summary>
        /// Gets the metadata for the <b>OriginalImages</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder OriginalImages => FromKnownFolderId(Guids.KnownFolders.OriginalImages);

        /// <summary>
        /// Gets the metadata for the <b>UserProgramFiles</b> folder.
        /// </summary>
        public static IKnownFolder UserProgramFiles
        {
            get
            {
                CoreHelpers.ThrowIfNotWin7();

                return FromKnownFolderId(Guids.KnownFolders.Windows7.UserProgramFiles);
            }
        }

        /// <summary>
        /// Gets the metadata for the <b>UserProgramFilesCommon</b> folder.
        /// </summary>
        public static IKnownFolder UserProgramFilesCommon
        {
            get
            {
                CoreHelpers.ThrowIfNotWin7();

                return FromKnownFolderId(Guids.KnownFolders.Windows7.UserProgramFilesCommon);
            }
        }

        /// <summary>
        /// Gets the metadata for the <b>Ringtones</b> folder.
        /// </summary>
        public static IKnownFolder Ringtones
        {
            get
            {
                CoreHelpers.ThrowIfNotWin7();

                return FromKnownFolderId(Guids.KnownFolders.Windows7.Ringtones);
            }
        }

        /// <summary>
        /// Gets the metadata for the <b>PublicRingtones</b> folder.
        /// </summary>
        public static IKnownFolder PublicRingtones
        {
            get
            {
                CoreHelpers.ThrowIfNotWin7();

                return FromKnownFolderId(Guids.KnownFolders.Windows7.PublicRingtones);
            }
        }

        /// <summary>
        /// Gets the metadata for the <b>UsersLibraries</b> folder.
        /// </summary>
        public static IKnownFolder UsersLibraries
        {
            get
            {
                CoreHelpers.ThrowIfNotWin7();

                return FromKnownFolderId(Guids.KnownFolders.Windows7.UsersLibraries);
            }
        }

        /// <summary>
        /// Gets the metadata for the <b>DocumentsLibrary</b> folder.
        /// </summary>
        public static IKnownFolder DocumentsLibrary
        {
            get
            {
                CoreHelpers.ThrowIfNotWin7();

                return FromKnownFolderId(Guids.KnownFolders.Windows7.DocumentsLibrary);
            }
        }

        /// <summary>
        /// Gets the metadata for the <b>MusicLibrary</b> folder.
        /// </summary>
        public static IKnownFolder MusicLibrary
        {
            get
            {
                CoreHelpers.ThrowIfNotWin7();

                return FromKnownFolderId(Guids.KnownFolders.Windows7.MusicLibrary);
            }
        }

        /// <summary>
        /// Gets the metadata for the <b>PicturesLibrary</b> folder.
        /// </summary>
        public static IKnownFolder PicturesLibrary
        {
            get
            {
                CoreHelpers.ThrowIfNotWin7();

                return FromKnownFolderId(Guids.KnownFolders.Windows7.PicturesLibrary);
            }
        }

        public static IKnownFolder CameraRollLibrary
        {
            get
            {
                CoreHelpers.ThrowIfNotWin7();

                return FromKnownFolderId(Guids.KnownFolders.Windows7.CameraRollLibrary);
            }
        }

        public static IKnownFolder SavedPicturesLibrary
        {
            get
            {
                CoreHelpers.ThrowIfNotWin7();

                return FromKnownFolderId(Guids.KnownFolders.Windows7.SavedPicturesLibrary);
            }
        }

        /// <summary>
        /// Gets the metadata for the <b>VideosLibrary</b> folder.
        /// </summary>
        public static IKnownFolder VideosLibrary
        {
            get
            {
                CoreHelpers.ThrowIfNotWin7();

                return FromKnownFolderId(Guids.KnownFolders.Windows7.VideosLibrary);
            }
        }

        /// <summary>
        /// Gets the metadata for the <b>RecordedTVLibrary</b> folder.
        /// </summary>
        public static IKnownFolder RecordedTVLibrary
        {
            get
            {
                CoreHelpers.ThrowIfNotWin7();

                return FromKnownFolderId(Guids.KnownFolders.Windows7.RecordedTVLibrary);
            }
        }

        /// <summary>
        /// Gets the metadata for the <b>OtherUsers</b> folder.
        /// </summary>
        public static IKnownFolder OtherUsers
        {
            get
            {
                CoreHelpers.ThrowIfNotWin7();

                return FromKnownFolderId(Guids.KnownFolders.Windows7.OtherUsers);
            }
        }

        /// <summary>
        /// Gets the metadata for the <b>DeviceMetadataStore</b> folder.
        /// </summary>
        public static IKnownFolder DeviceMetadataStore
        {
            get
            {
                CoreHelpers.ThrowIfNotWin7();

                return FromKnownFolderId(Guids.KnownFolders.Windows7.DeviceMetadataStore);
            }
        }

        /// <summary>
        /// Gets the metadata for the <b>Libraries</b> folder.
        /// </summary>
        public static IKnownFolder Libraries
        {
            get
            {
                CoreHelpers.ThrowIfNotWin7();

                return FromKnownFolderId(Guids.KnownFolders.Windows7.Libraries);
            }
        }

        /// <summary>
        ///Gets the metadata for the <b>UserPinned</b> folder.
        /// </summary>
        public static IKnownFolder UserPinned
        {
            get
            {
                CoreHelpers.ThrowIfNotWin7();

                return FromKnownFolderId(Guids.KnownFolders.Windows7.UserPinned);
            }
        }

        /// <summary>
        /// Gets the metadata for the <b>ImplicitAppShortcuts</b> folder.
        /// </summary>
        public static IKnownFolder ImplicitAppShortcuts
        {
            get
            {
                CoreHelpers.ThrowIfNotWin7();

                return FromKnownFolderId(Guids.KnownFolders.Windows7.ImplicitAppShortcuts);
            }
        }
        #endregion
    }
}
