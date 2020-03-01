//Copyright (c) Microsoft Corporation.  All rights reserved.

using Microsoft.WindowsAPICodePack.Win32Native;
using Microsoft.WindowsAPICodePack.Win32Native.Shell;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;

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
        public static ICollection<IKnownFolder> All => GetAllFolders();

        private static System.Collections.ObjectModel.ReadOnlyCollection<IKnownFolder> GetAllFolders()
        {
            // Should this method be thread-safe?? (It'll take a while
            // to get a list of all the known folders, create the managed wrapper
            // and return the read-only collection.

            IList<IKnownFolder> foldersList = new List<IKnownFolder>();
            IntPtr folders = IntPtr.Zero;

            try
            {

                var knownFolderManager = new KnownFolderManagerClass();
                knownFolderManager.GetFolderIds(out folders, out uint count);

                if (count > 0 && folders != IntPtr.Zero)
                {
                    // Loop through all the KnownFolderID elements
                    for (int i = 0; i < count; i++)
                    {
                        // Read the current pointer
                        var current = new IntPtr(folders.ToInt64() + (Marshal.SizeOf(typeof(Guid)) * i));

                        // Convert to Guid
                        Guid knownFolderID = (Guid)Marshal.PtrToStructure(current, typeof(Guid));

                        IKnownFolder kf = KnownFolderHelper.FromKnownFolderIdInternal(knownFolderID);

                        // Add to our collection if it's not null (some folders might not exist on the system
                        // or we could have an exception that resulted in the null return from above method call
                        if (kf != null) { foldersList.Add(kf); }
                    }
                }
            }
            finally
            {
                if (folders != IntPtr.Zero) { Marshal.FreeCoTaskMem(folders); }
            }

            return new System.Collections.ObjectModel.ReadOnlyCollection<IKnownFolder>(foldersList);
        }

        private static IKnownFolder GetKnownFolder(Guid guid) => KnownFolderHelper.FromKnownFolderId(guid);

        #region Default Known Folders

        /// <summary>
        /// Gets the metadata for the <b>Computer</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder Computer => GetKnownFolder(
                    new Guid(Win32Native.Guids.Shell.FolderIdentifiers.KnownFolders.Computer));

        /// <summary>
        /// Gets the metadata for the <b>Conflict</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder Conflict => GetKnownFolder(
                    new Guid(Win32Native.Guids.Shell.FolderIdentifiers.KnownFolders.Conflict));

        /// <summary>
        /// Gets the metadata for the <b>ControlPanel</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder ControlPanel => GetKnownFolder(
                    new Guid(Win32Native.Guids.Shell.FolderIdentifiers.KnownFolders.ControlPanel));

        /// <summary>
        /// Gets the metadata for the <b>Desktop</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder Desktop => GetKnownFolder(
                    new Guid(Win32Native.Guids.Shell.FolderIdentifiers.KnownFolders.Desktop));

        /// <summary>
        /// Gets the metadata for the <b>Internet</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder Internet => GetKnownFolder(
                    new Guid(Win32Native.Guids.Shell.FolderIdentifiers.KnownFolders.Internet));

        /// <summary>
        /// Gets the metadata for the <b>Network</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder Network => GetKnownFolder(
                    new Guid(Win32Native.Guids.Shell.FolderIdentifiers.KnownFolders.Network));

        /// <summary>
        /// Gets the metadata for the <b>Printers</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder Printers => GetKnownFolder(
                    new Guid(Win32Native.Guids.Shell.FolderIdentifiers.KnownFolders.Printers));

        /// <summary>
        /// Gets the metadata for the <b>SyncManager</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder SyncManager => GetKnownFolder(
                    new Guid(Win32Native.Guids.Shell.FolderIdentifiers.KnownFolders.SyncManager));

        /// <summary>
        /// Gets the metadata for the <b>Connections</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder Connections => GetKnownFolder(
                    new Guid(Win32Native.Guids.Shell.FolderIdentifiers.KnownFolders.Connections));

        /// <summary>
        /// Gets the metadata for the <b>SyncSetup</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder SyncSetup => GetKnownFolder(
                    new Guid(Win32Native.Guids.Shell.FolderIdentifiers.KnownFolders.SyncSetup));

        /// <summary>
        /// Gets the metadata for the <b>SyncResults</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder SyncResults => GetKnownFolder(
                    new Guid(Win32Native.Guids.Shell.FolderIdentifiers.KnownFolders.SyncResults));

        /// <summary>
        /// Gets the metadata for the <b>RecycleBin</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder RecycleBin => GetKnownFolder(
                    new Guid(Win32Native.Guids.Shell.FolderIdentifiers.KnownFolders.RecycleBin));

        /// <summary>
        /// Gets the metadata for the <b>Fonts</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder Fonts => GetKnownFolder(new Guid(Win32Native.Guids.Shell.FolderIdentifiers.KnownFolders.Fonts));

        /// <summary>
        /// Gets the metadata for the <b>Startup</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder Startup => GetKnownFolder(new Guid(Win32Native.Guids.Shell.FolderIdentifiers.KnownFolders.Startup));

        /// <summary>
        /// Gets the metadata for the <b>Programs</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder Programs => GetKnownFolder(new Guid(Win32Native.Guids.Shell.FolderIdentifiers.KnownFolders.Programs));

        /// <summary>
        /// Gets the metadata for the per-user <b>StartMenu</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder StartMenu => GetKnownFolder(new Guid(Win32Native.Guids.Shell.FolderIdentifiers.KnownFolders.StartMenu));

        /// <summary>
        /// Gets the metadata for the per-user <b>Recent</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder Recent => GetKnownFolder(new Guid(Win32Native.Guids.Shell.FolderIdentifiers.KnownFolders.Recent));

        /// <summary>
        /// Gets the metadata for the per-user <b>SendTo</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder SendTo => GetKnownFolder(new Guid(Win32Native.Guids.Shell.FolderIdentifiers.KnownFolders.SendTo));

        /// <summary>
        /// Gets the metadata for the per-user <b>Documents</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder Documents => GetKnownFolder(new Guid(Win32Native.Guids.Shell.FolderIdentifiers.KnownFolders.Documents));

        /// <summary>
        /// Gets the metadata for the per-user <b>Favorites</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder Favorites => GetKnownFolder(new Guid(Win32Native.Guids.Shell.FolderIdentifiers.KnownFolders.Favorites));

        /// <summary>
        /// Gets the metadata for the <b>NetHood</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder NetHood => GetKnownFolder(new Guid(Win32Native.Guids.Shell.FolderIdentifiers.KnownFolders.NetHood));

        /// <summary>
        /// Gets the metadata for the <b>PrintHood</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder PrintHood => GetKnownFolder(new Guid(Win32Native.Guids.Shell.FolderIdentifiers.KnownFolders.PrintHood));

        /// <summary>
        /// Gets the metadata for the <b>Templates</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder Templates => GetKnownFolder(new Guid(Win32Native.Guids.Shell.FolderIdentifiers.KnownFolders.Templates));

        /// <summary>
        /// Gets the metadata for the <b>CommonStartup</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder CommonStartup => GetKnownFolder(new Guid(Win32Native.Guids.Shell.FolderIdentifiers.KnownFolders.CommonStartup));

        /// <summary>
        /// Gets the metadata for the <b>CommonPrograms</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder CommonPrograms => GetKnownFolder(new Guid(Win32Native.Guids.Shell.FolderIdentifiers.KnownFolders.CommonPrograms));

        /// <summary>
        /// Gets the metadata for the <b>CommonStartMenu</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder CommonStartMenu => GetKnownFolder(new Guid(Win32Native.Guids.Shell.FolderIdentifiers.KnownFolders.CommonStartMenu));

        /// <summary>
        /// Gets the metadata for the <b>PublicDesktop</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder PublicDesktop => GetKnownFolder(new Guid(Win32Native.Guids.Shell.FolderIdentifiers.KnownFolders.PublicDesktop));

        /// <summary>
        /// Gets the metadata for the <b>ProgramData</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder ProgramData => GetKnownFolder(new Guid(Win32Native.Guids.Shell.FolderIdentifiers.KnownFolders.ProgramData));

        /// <summary>
        /// Gets the metadata for the <b>CommonTemplates</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder CommonTemplates => GetKnownFolder(new Guid(Win32Native.Guids.Shell.FolderIdentifiers.KnownFolders.CommonTemplates));

        /// <summary>
        /// Gets the metadata for the <b>PublicDocuments</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder PublicDocuments => GetKnownFolder(new Guid(Win32Native.Guids.Shell.FolderIdentifiers.KnownFolders.PublicDocuments));

        /// <summary>
        /// Gets the metadata for the <b>RoamingAppData</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder RoamingAppData => GetKnownFolder(new Guid(Win32Native.Guids.Shell.FolderIdentifiers.KnownFolders.RoamingAppData));

        /// <summary>
        /// Gets the metadata for the per-user <b>LocalAppData</b>  
        /// folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder LocalAppData => GetKnownFolder(new Guid(Win32Native.Guids.Shell.FolderIdentifiers.KnownFolders.LocalAppData));

        /// <summary>
        /// Gets the metadata for the <b>LocalAppDataLow</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder LocalAppDataLow => GetKnownFolder(new Guid(Win32Native.Guids.Shell.FolderIdentifiers.KnownFolders.LocalAppDataLow));

        /// <summary>
        /// Gets the metadata for the <b>InternetCache</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder InternetCache => GetKnownFolder(new Guid(Win32Native.Guids.Shell.FolderIdentifiers.KnownFolders.InternetCache));

        /// <summary>
        /// Gets the metadata for the <b>Cookies</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder Cookies => GetKnownFolder(new Guid(Win32Native.Guids.Shell.FolderIdentifiers.KnownFolders.Cookies));

        /// <summary>
        /// Gets the metadata for the <b>History</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder History => GetKnownFolder(new Guid(Win32Native.Guids.Shell.FolderIdentifiers.KnownFolders.History));

        /// <summary>
        /// Gets the metadata for the <b>System</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder System => GetKnownFolder(new Guid(Win32Native.Guids.Shell.FolderIdentifiers.KnownFolders.System));

        /// <summary>
        /// Gets the metadata for the <b>SystemX86</b>  
        /// folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder SystemX86 => GetKnownFolder(new Guid(Win32Native.Guids.Shell.FolderIdentifiers.KnownFolders.SystemX86));

        /// <summary>
        /// Gets the metadata for the <b>Windows</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder Windows => GetKnownFolder(new Guid(Win32Native.Guids.Shell.FolderIdentifiers.KnownFolders.Windows));

        /// <summary>
        /// Gets the metadata for the <b>Profile</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder Profile => GetKnownFolder(new Guid(Win32Native.Guids.Shell.FolderIdentifiers.KnownFolders.Profile));

        /// <summary>
        /// Gets the metadata for the per-user <b>Pictures</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder Pictures => GetKnownFolder(new Guid(Win32Native.Guids.Shell.FolderIdentifiers.KnownFolders.Pictures));

        /// <summary>
        /// Gets the metadata for the <b>ProgramFilesX86</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder ProgramFilesX86 => GetKnownFolder(new Guid(Win32Native.Guids.Shell.FolderIdentifiers.KnownFolders.ProgramFilesX86));

        /// <summary>
        /// Gets the metadata for the <b>ProgramFilesCommonX86</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder ProgramFilesCommonX86 => GetKnownFolder(new Guid(Win32Native.Guids.Shell.FolderIdentifiers.KnownFolders.ProgramFilesCommonX86));

        /// <summary>
        /// Gets the metadata for the <b>ProgramsFilesX64</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder ProgramFilesX64 => GetKnownFolder(new Guid(Win32Native.Guids.Shell.FolderIdentifiers.KnownFolders.ProgramFilesX64));

        /// <summary>
        ///  Gets the metadata for the <b> ProgramFilesCommonX64</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder ProgramFilesCommonX64 => GetKnownFolder(new Guid(Win32Native.Guids.Shell.FolderIdentifiers.KnownFolders.ProgramFilesCommonX64));

        /// <summary>
        /// Gets the metadata for the <b>ProgramFiles</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder ProgramFiles => GetKnownFolder(new Guid(Win32Native.Guids.Shell.FolderIdentifiers.KnownFolders.ProgramFiles));

        /// <summary>
        /// Gets the metadata for the <b>ProgramFilesCommon</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder ProgramFilesCommon => GetKnownFolder(new Guid(Win32Native.Guids.Shell.FolderIdentifiers.KnownFolders.ProgramFilesCommon));

        /// <summary>
        /// Gets the metadata for the <b>AdminTools</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder AdminTools => GetKnownFolder(new Guid(Win32Native.Guids.Shell.FolderIdentifiers.KnownFolders.AdminTools));

        /// <summary>
        /// Gets the metadata for the <b>CommonAdminTools</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder CommonAdminTools => GetKnownFolder(new Guid(Win32Native.Guids.Shell.FolderIdentifiers.KnownFolders.CommonAdminTools));

        /// <summary>
        /// Gets the metadata for the per-user <b>Music</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder Music => GetKnownFolder(new Guid(Win32Native.Guids.Shell.FolderIdentifiers.KnownFolders.Music));

        /// <summary>
        /// Gets the metadata for the <b>Videos</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder Videos => GetKnownFolder(new Guid(Win32Native.Guids.Shell.FolderIdentifiers.KnownFolders.Videos));

        /// <summary>
        /// Gets the metadata for the <b>PublicPictures</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder PublicPictures => GetKnownFolder(new Guid(Win32Native.Guids.Shell.FolderIdentifiers.KnownFolders.PublicPictures));

        /// <summary>
        /// Gets the metadata for the <b>PublicMusic</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder PublicMusic => GetKnownFolder(new Guid(Win32Native.Guids.Shell.FolderIdentifiers.KnownFolders.PublicMusic));

        /// <summary>
        /// Gets the metadata for the <b>PublicVideos</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder PublicVideos => GetKnownFolder(new Guid(Win32Native.Guids.Shell.FolderIdentifiers.KnownFolders.PublicVideos));

        /// <summary>
        /// Gets the metadata for the <b>ResourceDir</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder ResourceDir => GetKnownFolder(new Guid(Win32Native.Guids.Shell.FolderIdentifiers.KnownFolders.ResourceDir));

        /// <summary>
        /// Gets the metadata for the <b>LocalizedResourcesDir</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder LocalizedResourcesDir => GetKnownFolder(new Guid(Win32Native.Guids.Shell.FolderIdentifiers.KnownFolders.LocalizedResourcesDir));

        /// <summary>
        /// Gets the metadata for the <b>CommonOEMLinks</b> folder. 
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder CommonOemLinks => GetKnownFolder(new Guid(Win32Native.Guids.Shell.FolderIdentifiers.KnownFolders.CommonOEMLinks));

        /// <summary>
        /// Gets the metadata for the <b>CDBurning</b> folder. 
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder CDBurning => GetKnownFolder(new Guid(Win32Native.Guids.Shell.FolderIdentifiers.KnownFolders.CDBurning));

        /// <summary>
        /// Gets the metadata for the <b>UserProfiles</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder UserProfiles => GetKnownFolder(new Guid(Win32Native.Guids.Shell.FolderIdentifiers.KnownFolders.UserProfiles));

        /// <summary>
        /// Gets the metadata for the <b>Playlists</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder Playlists => GetKnownFolder(new Guid(Win32Native.Guids.Shell.FolderIdentifiers.KnownFolders.Playlists));

        /// <summary>
        /// Gets the metadata for the <b>SamplePlaylists</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder SamplePlaylists => GetKnownFolder(new Guid(Win32Native.Guids.Shell.FolderIdentifiers.KnownFolders.SamplePlaylists));

        /// <summary>
        /// Gets the metadata for the <b>SampleMusic</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder SampleMusic => GetKnownFolder(new Guid(Win32Native.Guids.Shell.FolderIdentifiers.KnownFolders.SampleMusic));

        /// <summary>
        /// Gets the metadata for the <b>SamplePictures</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder SamplePictures => GetKnownFolder(new Guid(Win32Native.Guids.Shell.FolderIdentifiers.KnownFolders.SamplePictures));

        /// <summary>
        /// Gets the metadata for the <b>SampleVideos</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder SampleVideos => GetKnownFolder(new Guid(Win32Native.Guids.Shell.FolderIdentifiers.KnownFolders.SampleVideos));

        /// <summary>
        /// Gets the metadata for the <b>PhotoAlbums</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder PhotoAlbums => GetKnownFolder(new Guid(Win32Native.Guids.Shell.FolderIdentifiers.KnownFolders.PhotoAlbums));

        /// <summary>
        /// Gets the metadata for the <b>Public</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder Public => GetKnownFolder(new Guid(Win32Native.Guids.Shell.FolderIdentifiers.KnownFolders.Public));

        /// <summary>
        /// Gets the metadata for the <b>ChangeRemovePrograms</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder ChangeRemovePrograms => GetKnownFolder(new Guid(Win32Native.Guids.Shell.FolderIdentifiers.KnownFolders.ChangeRemovePrograms));

        /// <summary>
        /// Gets the metadata for the <b>AppUpdates</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder AppUpdates => GetKnownFolder(new Guid(Win32Native.Guids.Shell.FolderIdentifiers.KnownFolders.AppUpdates));

        /// <summary>
        /// Gets the metadata for the <b>AddNewPrograms</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder AddNewPrograms => GetKnownFolder(new Guid(Win32Native.Guids.Shell.FolderIdentifiers.KnownFolders.AddNewPrograms));

        /// <summary>
        /// Gets the metadata for the per-user <b>Downloads</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder Downloads => GetKnownFolder(new Guid(Win32Native.Guids.Shell.FolderIdentifiers.KnownFolders.Downloads));

        /// <summary>
        /// Gets the metadata for the <b>PublicDownloads</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder PublicDownloads => GetKnownFolder(new Guid(Win32Native.Guids.Shell.FolderIdentifiers.KnownFolders.PublicDownloads));

        /// <summary>
        /// Gets the metadata for the per-user <b>SavedSearches</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder SavedSearches => GetKnownFolder(new Guid(Win32Native.Guids.Shell.FolderIdentifiers.KnownFolders.SavedSearches));

        /// <summary>
        /// Gets the metadata for the per-user <b>QuickLaunch</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder QuickLaunch => GetKnownFolder(new Guid(Win32Native.Guids.Shell.FolderIdentifiers.KnownFolders.QuickLaunch));

        /// <summary>
        /// Gets the metadata for the <b>Contacts</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder Contacts => GetKnownFolder(new Guid(Win32Native.Guids.Shell.FolderIdentifiers.KnownFolders.Contacts));

        /// <summary>
        /// Gets the metadata for the <b>SidebarParts</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder SidebarParts => GetKnownFolder(new Guid(Win32Native.Guids.Shell.FolderIdentifiers.KnownFolders.SidebarParts));

        /// <summary>
        /// Gets the metadata for the <b>SidebarDefaultParts</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder SidebarDefaultParts => GetKnownFolder(new Guid(Win32Native.Guids.Shell.FolderIdentifiers.KnownFolders.SidebarDefaultParts));

        /// <summary>
        /// Gets the metadata for the <b>TreeProperties</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder TreeProperties => GetKnownFolder(new Guid(Win32Native.Guids.Shell.FolderIdentifiers.KnownFolders.TreeProperties));

        /// <summary>
        /// Gets the metadata for the <b>PublicGameTasks</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder PublicGameTasks => GetKnownFolder(new Guid(Win32Native.Guids.Shell.FolderIdentifiers.KnownFolders.PublicGameTasks));

        /// <summary>
        /// Gets the metadata for the <b>GameTasks</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder GameTasks => GetKnownFolder(new Guid(Win32Native.Guids.Shell.FolderIdentifiers.KnownFolders.GameTasks));

        /// <summary>
        /// Gets the metadata for the per-user <b>SavedGames</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder SavedGames => GetKnownFolder(new Guid(Win32Native.Guids.Shell.FolderIdentifiers.KnownFolders.SavedGames));

        /// <summary>
        /// Gets the metadata for the <b>Games</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder Games => GetKnownFolder(new Guid(Win32Native.Guids.Shell.FolderIdentifiers.KnownFolders.Games));

        /// <summary>
        /// Gets the metadata for the <b>RecordedTV</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        /// <remarks>This folder is not used.</remarks>
        public static IKnownFolder RecordedTV => GetKnownFolder(new Guid(Win32Native.Guids.Shell.FolderIdentifiers.KnownFolders.RecordedTV));

        /// <summary>
        /// Gets the metadata for the <b>SearchMapi</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder SearchMapi => GetKnownFolder(new Guid(Win32Native.Guids.Shell.FolderIdentifiers.KnownFolders.SearchMapi));

        /// <summary>
        /// Gets the metadata for the <b>SearchCsc</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder SearchCsc => GetKnownFolder(new Guid(Win32Native.Guids.Shell.FolderIdentifiers.KnownFolders.SearchCsc));

        /// <summary>
        /// Gets the metadata for the per-user <b>Links</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder Links => GetKnownFolder(new Guid(Win32Native.Guids.Shell.FolderIdentifiers.KnownFolders.Links));

        /// <summary>
        /// Gets the metadata for the <b>UsersFiles</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder UsersFiles => GetKnownFolder(new Guid(Win32Native.Guids.Shell.FolderIdentifiers.KnownFolders.UsersFiles));

        /// <summary>
        /// Gets the metadata for the <b>SearchHome</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder SearchHome => GetKnownFolder(new Guid(Win32Native.Guids.Shell.FolderIdentifiers.KnownFolders.SearchHome));

        /// <summary>
        /// Gets the metadata for the <b>OriginalImages</b> folder.
        /// </summary>
        /// <value>An <see cref="IKnownFolder"/> object.</value>
        public static IKnownFolder OriginalImages => GetKnownFolder(new Guid(Win32Native.Guids.Shell.FolderIdentifiers.KnownFolders.OriginalImages));

        /// <summary>
        /// Gets the metadata for the <b>UserProgramFiles</b> folder.
        /// </summary>
        public static IKnownFolder UserProgramFiles
        {
            get
            {
                CoreHelpers.ThrowIfNotWin7();
                return GetKnownFolder(new Guid(Win32Native.Guids.Shell.FolderIdentifiers.KnownFolders.Win7.UserProgramFiles));
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
                return GetKnownFolder(new Guid(Win32Native.Guids.Shell.FolderIdentifiers.KnownFolders.Win7.UserProgramFilesCommon));
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
                return GetKnownFolder(new Guid(Win32Native.Guids.Shell.FolderIdentifiers.KnownFolders.Win7.Ringtones));
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
                return GetKnownFolder(new Guid(Win32Native.Guids.Shell.FolderIdentifiers.KnownFolders.Win7.PublicRingtones));
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
                return GetKnownFolder(new Guid(Win32Native.Guids.Shell.FolderIdentifiers.KnownFolders.Win7.UsersLibraries));
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
                return GetKnownFolder(new Guid(Win32Native.Guids.Shell.FolderIdentifiers.KnownFolders.Win7.DocumentsLibrary));
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
                return GetKnownFolder(new Guid(Win32Native.Guids.Shell.FolderIdentifiers.KnownFolders.Win7.MusicLibrary));
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
                return GetKnownFolder(new Guid(Win32Native.Guids.Shell.FolderIdentifiers.KnownFolders.Win7.PicturesLibrary));
            }
        }

        public static IKnownFolder CameraRollLibrary
        {

            get
            {

                CoreHelpers.ThrowIfNotWin7();
                return GetKnownFolder(new Guid(Win32Native.Guids.Shell.FolderIdentifiers.KnownFolders.Win7.CameraRollLibrary));

            }

        }

        public static IKnownFolder SavedPicturesLibrary
        {

            get
            {

                CoreHelpers.ThrowIfNotWin7();
                return GetKnownFolder(new Guid(Win32Native.Guids.Shell.FolderIdentifiers.KnownFolders.Win7.SavedPicturesLibrary));

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
                return GetKnownFolder(new Guid(Win32Native.Guids.Shell.FolderIdentifiers.KnownFolders.Win7.VideosLibrary));
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
                return GetKnownFolder(new Guid(Win32Native.Guids.Shell.FolderIdentifiers.KnownFolders.Win7.RecordedTVLibrary));
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
                return GetKnownFolder(new Guid(Win32Native.Guids.Shell.FolderIdentifiers.KnownFolders.Win7.OtherUsers));
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
                return GetKnownFolder(new Guid(Win32Native.Guids.Shell.FolderIdentifiers.KnownFolders.Win7.DeviceMetadataStore));
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
                return GetKnownFolder(new Guid(Win32Native.Guids.Shell.FolderIdentifiers.KnownFolders.Win7.Libraries));
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
                return GetKnownFolder(new Guid(Win32Native.Guids.Shell.FolderIdentifiers.KnownFolders.Win7.UserPinned));
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
                return GetKnownFolder(new Guid(Win32Native.Guids.Shell.FolderIdentifiers.KnownFolders.Win7.ImplicitAppShortcuts));
            }
        }

        #endregion

    }
}