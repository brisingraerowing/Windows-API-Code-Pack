//Copyright (c) Microsoft Corporation.  All rights reserved.  Distributed under the Microsoft Public License (MS-PL)

using Microsoft.WindowsAPICodePack.Win32Native.Shell;

using System.Collections.ObjectModel;

namespace Microsoft.WindowsAPICodePack.Dialogs
{
    /// <summary>
    /// Provides a strongly typed collection for file dialog filters.
    /// </summary>
    public class CommonFileDialogFilterCollection : Collection<CommonFileDialogFilter>
    {
        // Make the default constructor internal so users can't instantiate this 
        // collection by themselves.
        internal CommonFileDialogFilterCollection() { /* Left empty. */ }

        internal FilterSpec[] GetAllFilterSpecs()
        {
            var filterSpecs = new FilterSpec[Count];

            for (int i = 0; i < Count; i++)

                filterSpecs[i] = this[i].GetFilterSpec();

            return filterSpecs;
        }
    }
}
