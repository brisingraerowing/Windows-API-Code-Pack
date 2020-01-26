//Copyright (c) Microsoft Corporation.  All rights reserved.

using Microsoft.WindowsAPICodePack.Win32Native.Shell.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Microsoft.WindowsAPICodePack.Win32Native.Shell
{
    /// <summary>
    /// The FolderTypes values represent a view template applied to a folder, 
    /// usually based on its intended use and contents.
    /// </summary>
    public static class FolderTypes
    {
        //static Dictionary<Guid, string> types;

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1810:InitializeReferenceTypeStaticFieldsInline")]
        //static FolderTypes()
        //{
            //types = new Dictionary<Guid, string>();
            // Review: These Localized messages could probably be a reflected value of the field's name.
            //types.Add(new Guid(Guids.Shell.FolderTypes.NotSpecified), LocalizedMessages.FolderTypeNotSpecified);
            //types.Add(new Guid(Guids.Shell.FolderTypes.Invalid), LocalizedMessages.FolderTypeInvalid);
            //types.Add(new Guid(Guids.Shell.FolderTypes.Communications), LocalizedMessages.FolderTypeCommunications);
            //types.Add(new Guid(Guids.Shell.FolderTypes.CompressedFolder), LocalizedMessages.FolderTypeCompressedFolder);
            //types.Add(new Guid(Guids.Shell.FolderTypes.Contacts), LocalizedMessages.FolderTypeContacts);
            //types.Add(new Guid(Guids.Shell.FolderTypes.ControlPanelCategory), LocalizedMessages.FolderTypeCategory);
            //types.Add(new Guid(Guids.Shell.FolderTypes.ControlPanelClassic), LocalizedMessages.FolderTypeClassic);
            //types.Add(new Guid(Guids.Shell.FolderTypes.Documents), LocalizedMessages.FolderTypeDocuments);
            //types.Add(new Guid(Guids.Shell.FolderTypes.Games), LocalizedMessages.FolderTypeGames);
            //types.Add(new Guid(Guids.Shell.FolderTypes.GenericSearchResults), LocalizedMessages.FolderTypeSearchResults);
            //types.Add(new Guid(Guids.Shell.FolderTypes.GenericLibrary), LocalizedMessages.FolderTypeGenericLibrary);
            //types.Add(new Guid(Guids.Shell.FolderTypes.Library), LocalizedMessages.FolderTypeLibrary);
            //types.Add(new Guid(Guids.Shell.FolderTypes.Music), LocalizedMessages.FolderTypeMusic);
            //types.Add(new Guid(Guids.Shell.FolderTypes.MusicIcons), LocalizedMessages.FolderTypeMusicIcons);
            //types.Add(new Guid(Guids.Shell.FolderTypes.NetworkExplorer), LocalizedMessages.FolderTypeNetworkExplorer);
            //types.Add(new Guid(Guids.Shell.FolderTypes.OtherUsers), LocalizedMessages.FolderTypeOtherUsers);
            //types.Add(new Guid(Guids.Shell.FolderTypes.OpenSearch), LocalizedMessages.FolderTypeOpenSearch);
            //types.Add(new Guid(Guids.Shell.FolderTypes.Pictures), LocalizedMessages.FolderTypePictures);
            //types.Add(new Guid(Guids.Shell.FolderTypes.Printers), LocalizedMessages.FolderTypePrinters);
            //types.Add(new Guid(Guids.Shell.FolderTypes.RecycleBin), LocalizedMessages.FolderTypeRecycleBin);
            //types.Add(new Guid(Guids.Shell.FolderTypes.RecordedTV), LocalizedMessages.FolderTypeRecordedTV);
            //types.Add(new Guid(Guids.Shell.FolderTypes.SoftwareExplorer), LocalizedMessages.FolderTypeSoftwareExplorer);
            //types.Add(new Guid(Guids.Shell.FolderTypes.SavedGames), LocalizedMessages.FolderTypeSavedGames);
            //types.Add(new Guid(Guids.Shell.FolderTypes.SearchConnector), LocalizedMessages.FolderTypeSearchConnector);
            //types.Add(new Guid(Guids.Shell.FolderTypes.Searches), LocalizedMessages.FolderTypeSearches);
            //types.Add(new Guid(Guids.Shell.FolderTypes.UsersLibraries), LocalizedMessages.FolderTypeUserLibraries);
            //types.Add(new Guid(Guids.Shell.FolderTypes.UserFiles), LocalizedMessages.FolderTypeUserFiles);
            //types.Add(new Guid(Guids.Shell.FolderTypes.Videos), LocalizedMessages.FolderTypeVideos);
        //}

        public static string GetFolderType(Guid typeId)
        {
            FieldInfo fieldInfo = typeof(Guids.Shell.FolderTypes).GetFields(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static).Where(f => f.IsLiteral && !f.IsInitOnly && new Guid((string)f.GetValue(null)) == typeId).FirstOrDefault();

            if (fieldInfo is null)

                return string.Empty;

            string propertyName = "FolderType" + fieldInfo.Name;

            return (string) typeof(LocalizedMessages).GetProperties().Where(p => p.Name == propertyName).First().GetValue(null);
        }
    }
}
