//Copyright (c) Microsoft Corporation.  All rights reserved.

using System.Collections.ObjectModel;
using Microsoft.WindowsAPICodePack.Shell;
using Microsoft.WindowsAPICodePack.Win32Native.Shell;

namespace Microsoft.WindowsAPICodePack.Dialogs
{
    /// <summary>
    /// Provides a strongly typed collection for file dialog filters.
    /// </summary>
    public class CommonFileDialogFilterCollection : System.Collections.ObjectModel.Collection<CommonFileDialogFilter>
    {
        // Make the default constructor internal so users can't instantiate this 
        // collection by themselves.
        internal CommonFileDialogFilterCollection() { }

        internal FilterSpec[] GetAllFilterSpecs()
        {
            var filterSpecs = new FilterSpec[Count];

            for (int i = 0; i < Count; i++)

                filterSpecs[i] = this[i].GetFilterSpec();

            return filterSpecs;
        }
    }
}
