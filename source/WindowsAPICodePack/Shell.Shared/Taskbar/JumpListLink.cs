//Copyright (c) Microsoft Corporation.  All rights reserved.  Distributed under the Microsoft Public License (MS-PL)

using Microsoft.WindowsAPICodePack.COMNative.Shell;
using Microsoft.WindowsAPICodePack.COMNative.Shell.PropertySystem;
using Microsoft.WindowsAPICodePack.PropertySystem;
using Microsoft.WindowsAPICodePack.Win32Native;
using Microsoft.WindowsAPICodePack.Win32Native.PropertySystem;
using Microsoft.WindowsAPICodePack.Win32Native.Shell;

using System;
using System.Runtime.InteropServices;

using static Microsoft.WindowsAPICodePack.Shell.Resources.LocalizedMessages;
using static Microsoft.WindowsAPICodePack.Win32Native.CoreHelpers;

namespace Microsoft.WindowsAPICodePack.Taskbar
{
    /// <summary>
    /// Represents a jump list link object.
    /// </summary>
    public class JumpListLink : JumpListTask, IJumpListItem, IDisposable
    {
        #region Fields
        private string path;
        private string title;
        private IPropertyStore nativePropertyStore;
        private IShellLinkW nativeShellLink;
        internal static PropertyKey PKEY_Title = SystemProperties.System.Title;
        #endregion

        /// <summary>
        /// Initializes a new instance of a JumpListLink with the specified path.
        /// </summary>
        /// <param name="pathValue">The path to the item. The path is required for the JumpList Link</param>
        /// <param name="titleValue">The title for the JumpListLink item. The title is required for the JumpList link.</param>
        public JumpListLink(string pathValue, string titleValue)
        {
            Check(ref path, pathValue, nameof(pathValue), JumpListLinkPathRequired);

            Check(ref title, titleValue, nameof(titleValue), JumpListLinkTitleRequired);
        }

        #region Properties
        /// <summary>
        /// Gets or sets the link's title
        /// </summary>
        public string Title { get => title; set => Check(ref title, value, nameof(value), JumpListLinkTitleRequired); }

        /// <summary>
        /// Gets or sets the link's path
        /// </summary>
        public string Path { get => path; set => Check(ref path, value, nameof(value), JumpListLinkTitleRequired); }

        /// <summary>
        /// Gets or sets the icon reference (location and index) of the link's icon.
        /// </summary>
        public IconReference IconReference { get; set; }

        /// <summary>
        /// Gets or sets the object's arguments (passed to the command line).
        /// </summary>
        public string Arguments { get; set; }

        /// <summary>
        /// Gets or sets the object's working directory.
        /// </summary>
        public string WorkingDirectory { get; set; }

        /// <summary>
        /// Gets or sets the show command of the lauched application.
        /// </summary>
        public WindowShowCommand ShowCommand { get; set; }

        /// <summary>
        /// Gets an IShellLinkW representation of this object
        /// </summary>
        internal override IShellLinkW NativeShellLink
        {
            get
            {
                WinCopies.
#if WAPICP3
    UtilHelpers
#else
    Util.Util
#endif
                .UpdateValue(ref nativeShellLink, (IShellLinkW)new CShellLink());

                WinCopies.
#if WAPICP3
    UtilHelpers
#else
    Util.Util
#endif
    .UpdateValue(ref nativePropertyStore, (IPropertyStore)nativeShellLink);

                nativeShellLink.SetPath(Path);

                if (!string.IsNullOrEmpty(IconReference.ModuleName))

                    nativeShellLink.SetIconLocation(IconReference.ModuleName, IconReference.ResourceId);

                if (!string.IsNullOrEmpty(Arguments))

                    nativeShellLink.SetArguments(Arguments);

                if (!string.IsNullOrEmpty(WorkingDirectory))

                    nativeShellLink.SetWorkingDirectory(WorkingDirectory);

                nativeShellLink.SetShowCmd((uint)ShowCommand);

                using (var propVariant = new PropVariant(Title))
                {
                    HResult result = nativePropertyStore.SetValue(ref PKEY_Title, propVariant);

                    _ = CoreErrorHelper.Succeeded(result) ? nativePropertyStore.Commit() : throw new ShellException(result);
                }

                return nativeShellLink;
            }
        }
        #endregion

        private static void Check(ref string field, in string value, in string paramName, in string errorMessage) => field = string.IsNullOrEmpty(value) ? throw new ArgumentNullException(paramName, errorMessage) : value;

        #region IDisposable Members
        /// <summary>
        /// Release the native and managed objects
        /// </summary>
        /// <param name="disposing">Indicates that this is being called from Dispose(), rather than the finalizer.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)

                title = null;

            DisposeCOMObject(ref nativePropertyStore);

            DisposeCOMObject(ref nativeShellLink);
        }

        /// <summary>
        /// Release the native objects.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Implement the finalizer.
        /// </summary>
        ~JumpListLink() => Dispose(false);
        #endregion
    }
}
