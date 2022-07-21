//Copyright (c) Microsoft Corporation.  All rights reserved.  Distributed under the Microsoft Public License (MS-PL)

using Microsoft.WindowsAPICodePack.Win32Native.Shell;

using System;
using System.Text;
using WinCopies.Collections;

namespace Microsoft.WindowsAPICodePack.Dialogs
{
    /// <summary>
    /// Stores the file extensions used when filtering files in File Open and File Save dialogs.
    /// </summary>
    public class CommonFileDialogFilter
    {
        private string _rawDisplayName;

        /// <summary>
        /// Creates a new instance of this class.
        /// </summary>
        public CommonFileDialogFilter() => Extensions = new System.Collections.ObjectModel.Collection<string>();

        /// <summary>
        /// Creates a new instance of this class with the specified display name and file extension list.
        /// </summary>
        /// <param name="rawDisplayName">The name of this filter.</param>
        /// <param name="extensionList">The list of extensions in this filter. See remarks.</param>
        /// <remarks>The <paramref name="extensionList"/> can use a semicolon(";") 
        /// or comma (",") to separate extensions. Extensions can be prefaced 
        /// with a period (".") or with the file wild card specifier "*.".</remarks>
        /// <permission cref="ArgumentNullException">
        /// The <paramref name="extensionList"/> cannot be null or a zero-length string.
        /// </permission>
        public CommonFileDialogFilter(string rawDisplayName, string extensionList) : this()
        {
            _rawDisplayName = string.IsNullOrEmpty(extensionList) ? throw new ArgumentNullException(nameof(extensionList)) : rawDisplayName;

            // Parse string and create extension strings.
            // Format: "bat,cmd", or "bat;cmd", or "*.bat;*.cmd"
            // Can support leading "." or "*." - these will be stripped.
            foreach (string extension in extensionList.Split(',', ';'))

                Extensions.Add(NormalizeExtension(extension));
        }

        /// <summary>
        /// Gets or sets the display name for this filter.
        /// </summary>
        /// <permission cref="System.ArgumentNullException">
        /// The value for this property cannot be set to null or a 
        /// zero-length string. 
        /// </permission>        
        public string DisplayName
        {
            get => ShowExtensions
                    ? string.Format(System.Globalization.CultureInfo.InvariantCulture,
                        "{0} ({1})",
                        _rawDisplayName,
                        GetDisplayExtensionList(Extensions))
                    : _rawDisplayName;

            set => _rawDisplayName = string.IsNullOrEmpty(value) ? throw new ArgumentNullException(nameof(value)) : value;
        }

        /// <summary>
        /// Gets a collection of the individual extensions described by this filter.
        /// </summary>
        public System.Collections.ObjectModel.Collection<string> Extensions { get; }

        /// <summary>
        /// Gets or sets a value that controls whether the extensions are displayed.
        /// </summary>
        public bool ShowExtensions { get; set; } = true;

        private static string NormalizeExtension(string rawExtension)
        {
            rawExtension = rawExtension.Trim();
            rawExtension = rawExtension.Replace("*.", null);
            rawExtension = rawExtension.Replace(".", null);
            return rawExtension;
        }

        private static string GetDisplayExtensionList(System.Collections.ObjectModel.Collection<string> extensions)
        {
            var extensionList = new StringBuilder();

            void append(in string text) => extensionList.Append(text);

            void appendExtension(string extension)
            {
                append("*.");
                append(extension);
            }

            appendExtension(extensions[0]);

            for (int i = 1; i < extensions.Count; i++)
            {
                append(", ");
                appendExtension(extensions[i]);
            }

            return extensionList.ToString();
        }

        /// <summary>
        /// Internal helper that generates a single filter 
        /// specification for this filter, used by the COM API.
        /// </summary>
        /// <returns>Filter specification for this filter</returns>
        internal FilterSpec GetFilterSpec()
        {
            var filterList = new StringBuilder();

            if (Extensions.Count > 0)
            {
                int i = 0;

                void _append(in string text) => filterList.Append(text);

                void append()
                {
                    _append("*.");
                    _append(Extensions[i]);
                }

                append();
                
                for (i = 1; i < Extensions.Count; i++)
                {
                    _ = filterList.Append(';');

                    append();
                }
            }

            return new FilterSpec(DisplayName, filterList.ToString());
        }

        /// <summary>
        /// Returns a string representation for this filter that includes
        /// the display name and the list of extensions.
        /// </summary>
        /// <returns>A <see cref="string"/>.</returns>
        public override string ToString() => string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "{0} ({1})",
                _rawDisplayName,
                GetDisplayExtensionList(Extensions));
    }
}
