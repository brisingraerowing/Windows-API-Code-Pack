﻿//Copyright (c) Microsoft Corporation.  All rights reserved.  Distributed under the Microsoft Public License (MS-PL)

using Microsoft.WindowsAPICodePack.COMNative.COM;
using Microsoft.WindowsAPICodePack.COMNative.Shell;
using Microsoft.WindowsAPICodePack.COMNative.Taskbar;
using Microsoft.WindowsAPICodePack.Shell.Resources;
using Microsoft.WindowsAPICodePack.Win32Native;
using Microsoft.WindowsAPICodePack.Win32Native.Shell;
using Microsoft.WindowsAPICodePack.Win32Native.Taskbar;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

using static Microsoft.WindowsAPICodePack.Taskbar.TaskbarManager;

namespace Microsoft.WindowsAPICodePack.Taskbar
{
    /// <summary>
    /// Represents an instance of a Taskbar button jump list.
    /// </summary>
    public class JumpList
    {
        #region Fields
        private readonly ICustomDestinationList customDestinationList; // Native implementation of destination list
        private JumpListCustomCategoryCollection customCategoriesCollection;
        private JumpListItemCollection<JumpListTask> userTasks;
        private readonly object syncLock = new
#if !CS9
            object
#endif
            (); // Best practice recommends defining a private object to lock on
        private int knownCategoryOrdinalPosition;
        #endregion

        /// <summary>
        /// Create a JumpList for the application's taskbar button.
        /// </summary>
        /// <returns>A new JumpList that is associated with the app id of the main application window</returns>
        /// <remarks>If there are any other child (top-level) windows for this application and they don't have
        /// a specific JumpList created for them, they all will share the same JumpList as the main application window.
        /// In order to have a individual JumpList for a top-level window, use the overloaded method CreateJumpListForIndividualWindow.</remarks>
        public static JumpList CreateJumpList() => new
#if !CS9
            JumpList
#endif
            (TaskbarManager.Instance.ApplicationId);

        /// <summary>
        /// Create a JumpList for the application's taskbar button.
        /// </summary>
        /// <param name="appId">Application Id for the individual window. This must be unique for each top-level window in order to have a individual JumpList.</param>
        /// <param name="windowHandle">Handle of the window associated with the new JumpList</param>
        /// <returns>A new JumpList that is associated with the specific window handle</returns>
        public static JumpList CreateJumpListForIndividualWindow(string appId, IntPtr windowHandle) => new
#if !CS9
            JumpList
#endif
            (appId, windowHandle);

        /// <summary>
        /// Create a JumpList for the application's taskbar button.
        /// </summary>
        /// <param name="appId">Application Id for the individual window. This must be unique for each top-level window in order to have a individual JumpList.</param>
        /// <param name="window">WPF Window associated with the new JumpList</param>
        /// <returns>A new JumpList that is associated with the specific WPF window</returns>
        public static JumpList CreateJumpListForIndividualWindow(string appId, System.Windows.Window window) => new
#if !CS9
            JumpList
#endif
            (appId, window);

        #region Properties
        /// <summary>
        /// Gets the recommended number of items to add to the jump list.  
        /// </summary>
        /// <remarks>
        /// This number doesn’t 
        /// imply or suggest how many items will appear on the jump list.  
        /// This number should only be used for reference purposes since
        /// the actual number of slots in the jump list can change after the last
        /// refresh due to items being pinned or removed and resolution changes. 
        /// The jump list can increase in size accordingly.
        /// </remarks>
        public uint MaxSlotsInList
        {
            get
            {
                // Because we need the correct number for max slots, start a commit, get the max slots
                // and then abort. If we wait until the user calls RefreshTaskbarlist(), it will be too late.
                // The user needs to use this number before they update the jumplist.

                var guid = new Guid(NativeAPI.Guids.COM.IObjectArray);

                // Native call to start adding items to the taskbar destination list
                HResult hr = customDestinationList.BeginList(
                    out uint maxSlotsInList,
                    ref guid,
                    out _);

                if (CoreErrorHelper.Succeeded(hr))

                    customDestinationList.AbortList();

                return maxSlotsInList;
            }
        }

        /// <summary>
        /// Gets or sets the type of known categories to display.
        /// </summary>
        public JumpListKnownCategoryType KnownCategoryToDisplay { get; set; }

        /// <summary>
        /// Gets or sets the value for the known category location relative to the 
        /// custom category collection.
        /// </summary>
        public int KnownCategoryOrdinalPosition { get => knownCategoryOrdinalPosition; set => knownCategoryOrdinalPosition = value < 0 ? throw new ArgumentOutOfRangeException(nameof(value), LocalizedMessages.JumpListNegativeOrdinalPosition) : value; }

        /// <summary>
        /// Gets or sets the application ID to use for this jump list.
        /// </summary>
        public string ApplicationId { get; private set; }

        /// <summary>
        /// Retrieves the current list of destinations that have been removed from the existing jump list by the user. 
        /// The removed destinations may become items on a custom jump list.
        /// </summary>
        /// <value>A collection of items (filenames) removed from the existing jump list by the user.</value>
        public IEnumerable RemovedDestinations
        {
            get
            {
                var guid = new Guid(NativeAPI.Guids.COM.IObjectArray);

                // Get list of removed items from native code
                customDestinationList.GetRemovedDestinations(ref guid, out object removedItems);

                return ProcessDeletedItems((IObjectArray)removedItems);
            }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Creates a new instance of the JumpList class with the specified
        /// appId. The JumpList is associated with the main window of the application.
        /// </summary>
        /// <param name="appID">Application Id to use for this instace.</param>
        internal JumpList(string appID) : this(appID, TaskbarManager.Instance.OwnerHandle) { /* Left empty. */ }

        /// <summary>
        /// Creates a new instance of the JumpList class with the specified
        /// appId. The JumpList is associated with the given WPF Window.
        /// </summary>
        /// <param name="appID">Application Id to use for this instace.</param>
        /// <param name="window">WPF Window that is associated with this JumpList</param>
        internal JumpList(string appID, System.Windows.Window window) : this(appID, (new System.Windows.Interop.WindowInteropHelper(window)).Handle) { /* Left empty. */ }

        /// <summary>
        /// Creates a new instance of the JumpList class with the specified
        /// appId. The JumpList is associated with the given window.
        /// </summary>
        /// <param name="appID">Application Id to use for this instace.</param>
        /// <param name="windowHandle">Window handle for the window that is associated with this JumpList</param>
        private JumpList(string appID, IntPtr windowHandle)
        {
            // Throw exception if not running on Win7 or newer
            CoreHelpers.ThrowIfNotWin7();

            // Native implementation of destination list
            customDestinationList = (ICustomDestinationList)new CDestinationList();

            // Set application user model ID
            if (!string.IsNullOrEmpty(appID))
            {
                ApplicationId = appID;

                // If the user hasn't yet set the application id for the whole process,
                // use the first JumpList's AppId for the whole process. This will ensure
                // we have the same JumpList for all the windows (unless user overrides and creates a new
                // JumpList for a specific child window)
                if (!Instance.ApplicationIdSetProcessWide)

                    Instance.ApplicationId = appID;

                Instance.SetApplicationIdForSpecificWindow(windowHandle, appID);
            }
        }
        #endregion

        /// <summary>
        /// Occurs when items are removed from the Taskbar's jump list since the last
        /// refresh. 
        /// </summary>
        /// <remarks>
        /// This event is not triggered
        /// immediately when a user removes an item from the jump list but rather
        /// when the application refreshes the task bar list directly.
        /// </remarks>
        public event EventHandler<UserRemovedJumpListItemsEventArgs> JumpListItemsRemoved = delegate { };

        #region Methods
        /// <summary>
        /// Adds a collection of custom categories to the Taskbar jump list.
        /// </summary>
        /// <param name="customCategories">The catagories to add to the jump list.</param>
        public void AddCustomCategories(params JumpListCustomCategory[] customCategories)
        {
            lock (syncLock)

                if (customCategoriesCollection == null)

                    customCategoriesCollection = new JumpListCustomCategoryCollection();

            if (customCategories != null)

                foreach (JumpListCustomCategory category in customCategories)

                    customCategoriesCollection.Add(category);
        }

        /// <summary>
        /// Adds user tasks to the Taskbar JumpList. User tasks can only consist of JumpListTask or
        /// JumpListSeparator objects.
        /// </summary>
        /// <param name="tasks">The user tasks to add to the JumpList.</param>
        public void AddUserTasks(params JumpListTask[] tasks)
        {
            if (userTasks == null)

                // Make sure that we don't create multiple instances
                // of this object
                lock (syncLock)

                    if (userTasks == null)

                        userTasks = new JumpListItemCollection<JumpListTask>();

            if (tasks != null)

                foreach (JumpListTask task in tasks)

                    userTasks.Add(task);
        }

        /// <summary>
        /// Removes all user tasks that have been added.
        /// </summary>
        public void ClearAllUserTasks() => userTasks?.Clear();

        /// <summary>
        /// Reports document usage to the shell.
        /// </summary>
        /// <param name="destination">The full path of the file to report usage.</param>
        public static void AddToRecent(string destination) => Win32Native.Taskbar.Taskbar.SHAddToRecentDocs(destination);

        /// <summary>
        /// Commits the pending JumpList changes and refreshes the Taskbar.
        /// </summary>
        /// <exception cref="InvalidOperationException">Will throw if the type of the file being added to the JumpList is not registered with the application.</exception>
        /// <exception cref="UnauthorizedAccessException">Will throw if recent documents tracking is turned off by the user or via group policy.</exception>
        /// <exception cref="COMException">Will throw if updating the JumpList fails for any other reason.</exception>
        public void Refresh()
        {
            // Let the taskbar know which specific jumplist we are updating
            if (!string.IsNullOrEmpty(ApplicationId))

                customDestinationList.SetAppID(ApplicationId);

            // Begins rendering on the taskbar destination list
            BeginList();

            Exception exception = null;

            try
            {
                // try to add the user tasks first
                AppendTaskList();
            }

            catch (Exception e)
            {
                // If this fails, save the exception but don't throw it yet.
                // We need to continue to try and add the custom categories
                exception = e;
            }

            // Even it fails, continue appending the custom categories
            try
            {
                // Add custom categories
                AppendCustomCategories();
            }

            finally
            {
                // End rendering of the taskbar destination list
                customDestinationList.CommitList();
            }

            // If an exception was thrown while adding the user tasks or
            // custom categories, throw it.
            if (exception != null)

                throw exception;
        }

        private void BeginList()
        {
            var guid = new Guid(NativeAPI.Guids.COM.IObjectArray);

            // Get list of removed items from native code
            // Native call to start adding items to the taskbar destination list
            HResult hr = customDestinationList.BeginList(
                out uint maxSlotsInList,
                ref guid,
                out object removedItems);

            // Process the deleted items
            IEnumerable removedItemsArray = CoreErrorHelper.Succeeded(hr) ? ProcessDeletedItems((IObjectArray)removedItems) : throw new ShellException(hr);

            // Raise the event if items were removed
            if (JumpListItemsRemoved != null && removedItemsArray != null && removedItemsArray.GetEnumerator().MoveNext())

                JumpListItemsRemoved(this, new UserRemovedJumpListItemsEventArgs(removedItemsArray));
        }

        private IEnumerable<string> ProcessDeletedItems(IObjectArray removedItems)
        {
            var removedItemsArray = new List<string>();

            removedItems.GetCount(out uint count);

            // Process each removed item based on its type
            for (uint i = 0; i < count; i++)
            {
                var guid = new Guid(NativeAPI.Guids.COM.IUnknown);

                // Native call to retrieve objects from IObjectArray
                removedItems.GetAt(i,
                    ref guid,
                    out object item);

                // Process item
                if (item is IShellItem shellItem)

                    removedItemsArray.Add(RemoveCustomCategoryItem(shellItem));

                else if (item is IShellLinkW shellLink)

                    removedItemsArray.Add(RemoveCustomCategoryLink(shellLink));
            }

            return removedItemsArray;
        }

        private string RemoveCustomCategoryItem(IShellItem item)
        {
            string path = null;

            if (customCategoriesCollection != null)
            {
                if (item.GetDisplayName(ShellItemDesignNameOptions.FileSystemPath, out IntPtr pszString) == HResult.Ok && pszString != IntPtr.Zero)
                {
                    path = Marshal.PtrToStringAuto(pszString);

                    // Free the string
                    Marshal.FreeCoTaskMem(pszString);
                }

                // Remove this item from each category
                foreach (JumpListCustomCategory category in customCategoriesCollection)

                    category.RemoveJumpListItem(path);
            }

            return path;
        }

        private string RemoveCustomCategoryLink(IShellLinkW link)
        {
            string path = null;

            if (customCategoriesCollection != null)
            {
                var sb = new StringBuilder(256);
                link.GetPath(sb, sb.Capacity, IntPtr.Zero, 2);

                path = sb.ToString();

                // Remove this item from each category
                foreach (JumpListCustomCategory category in customCategoriesCollection)

                    category.RemoveJumpListItem(path);
            }

            return path;
        }

        private void AppendCustomCategories()
        {
            // Initialize our current index in the custom categories list
            int currentIndex = 0;

            // Keep track whether we add the Known Categories to our list
            bool knownCategoriesAdded = false;

            if (customCategoriesCollection != null)

                // Append each category to list
                foreach (JumpListCustomCategory category in customCategoriesCollection)
                {
                    // If our current index is same as the KnownCategory OrdinalPosition,
                    // append the Known Categories
                    if (!knownCategoriesAdded && currentIndex == KnownCategoryOrdinalPosition)
                    {
                        AppendKnownCategories();
                        knownCategoriesAdded = true;
                    }

                    // Don't process empty categories
                    if (category.JumpListItems.Count == 0) continue;

                    var categoryContent = (IObjectCollection)new CEnumerableObjectCollection();

                    // Add each link's shell representation to the object array
                    foreach (IJumpListItem link in category.JumpListItems)

                        if (link is JumpListItem listItem)

                            categoryContent.AddObject(listItem.NativeShellItem);

                        else if (link is JumpListLink listLink)

                            categoryContent.AddObject(listLink.NativeShellLink);

                    // Add current category to destination list
                    HResult hr = customDestinationList.AppendCategory(
                        category.Name,
                        categoryContent);

                    if (!CoreErrorHelper.Succeeded(hr))
                    {
                        if ((uint)hr == 0x80040F03)

                            throw new InvalidOperationException(LocalizedMessages.JumpListFileTypeNotRegistered);

                        else if (hr == HResult.AccessDenied)

                            // If the recent documents tracking is turned off by the user,
                            // custom categories or items to an existing category cannot be added.
                            // The recent documents tracking can be changed via:
                            //      1. Group Policy “Do not keep history of recently opened documents”.
                            //      2. Via the user setting “Store and display recently opened items in 
                            //         the Start menu and the taskbar” in the Start menu property dialog.

                            throw new UnauthorizedAccessException(LocalizedMessages.JumpListCustomCategoriesDisabled);

                        throw new ShellException(hr);
                    }

                    // Increase our current index
                    currentIndex++;
                }

            // If the ordinal position was out of range, append the Known Categories
            // at the end
            if (!knownCategoriesAdded)

                AppendKnownCategories();
        }

        private void AppendTaskList()
        {
            if (userTasks == null || userTasks.Count == 0) return;

            var taskContent =
                    (IObjectCollection)new CEnumerableObjectCollection();

            // Add each task's shell representation to the object array
            foreach (JumpListTask task in userTasks)

                if (task is JumpListLink link)

                    taskContent.AddObject(link.NativeShellLink);

                else if (task is JumpListSeparator seperator)

                    taskContent.AddObject(seperator.NativeShellLink);

            // Add tasks to the taskbar
            HResult hr = customDestinationList.AddUserTasks(taskContent);

            if (!CoreErrorHelper.Succeeded(hr))

#if CS9
                throw
#else
                if (
#endif
                    (uint)hr == 0x80040F03
#if CS9
                    ?
#else
                    )

                    throw
#endif
                    new InvalidOperationException(LocalizedMessages.JumpListFileTypeNotRegistered)
#if CS9
                    :
#else
                    ;

            throw
#endif
            new ShellException(hr);
        }

        private void AppendKnownCategories()
        {
            if (KnownCategoryToDisplay == JumpListKnownCategoryType.Recent)

                customDestinationList.AppendKnownCategory(KnownDestinationCategory.Recent);

            else if (KnownCategoryToDisplay == JumpListKnownCategoryType.Frequent)

                customDestinationList.AppendKnownCategory(KnownDestinationCategory.Frequent);
        }
        #endregion
    }
}
