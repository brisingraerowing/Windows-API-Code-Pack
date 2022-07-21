//Copyright (c) Microsoft Corporation.  All rights reserved.  Distributed under the Microsoft Public License (MS-PL)

using Microsoft.WindowsAPICodePack.COMNative.Controls;
using Microsoft.WindowsAPICodePack.Controls.WindowsForms;
using Microsoft.WindowsAPICodePack.Shell.Resources;
using Microsoft.WindowsAPICodePack.Win32Native;

using EBCSO = Microsoft.WindowsAPICodePack.Controls.ExplorerBrowserContentSectionOptions;

namespace Microsoft.WindowsAPICodePack.Controls
{
    /// <summary>
    /// These options control how the content of the Explorer Browser 
    /// is rendered.
    /// </summary>
    public class ExplorerBrowserContentOptions
    {
        readonly ExplorerBrowser eb;
        internal ExplorerBrowserContentOptions(ExplorerBrowser eb) => this.eb = eb;

        #region ViewMode property
        // This is a one-way property of the explorer browser. 
        // Keeping it around for the get implementations.
        internal FolderSettings folderSettings = new
#if !CS9
            FolderSettings
#endif
            ();

        /// <summary>
        /// The viewing mode of the Explorer Browser
        /// </summary>
        public ExplorerBrowserViewMode ViewMode
        {
            get => (ExplorerBrowserViewMode)folderSettings.ViewMode;

            set
            {
                folderSettings.ViewMode = (FolderViewMode)value;

                if (eb.explorerBrowserControl != null)

                    CoreErrorHelper.ThrowExceptionForHResult(eb.explorerBrowserControl.SetFolderSettings(folderSettings));
            }
        }
        #endregion

        /// <summary>
        /// The binary representation of the <see cref="ExplorerBrowser"/> content flags.
        /// </summary>
        public EBCSO Flags
        {
            get => (EBCSO)folderSettings.Options;

            set
            {
                folderSettings.Options = (FolderOptions)value | FolderOptions.UseSearchFolders | FolderOptions.NoWebView;

                eb.explorerBrowserControl?.SetFolderSettings(folderSettings);
            }
        }

        #region Content flags to properties mapping
        /// <summary>
        /// The view should be left-aligned. 
        /// </summary>
        public bool AlignLeft { get => IsFlagSet(EBCSO.AlignLeft); set => SetFlag(EBCSO.AlignLeft, value); }

        /// <summary>
        /// Automatically arrange the elements in the view. 
        /// </summary>
        public bool AutoArrange { get => IsFlagSet(EBCSO.AutoArrange); set => SetFlag(EBCSO.AutoArrange, value); }

        /// <summary>
        /// Turns on check mode for the view.
        /// </summary>
        public bool CheckSelect { get => IsFlagSet(EBCSO.CheckSelect); set => SetFlag(EBCSO.CheckSelect, value); }

        /// <summary>
        /// When the view is in "tile view mode" the layout of a single item should be extended to the width of the view.
        /// </summary>
        public bool ExtendedTiles { get => IsFlagSet(EBCSO.ExtendedTiles); set => SetFlag(EBCSO.ExtendedTiles, value); }

        /// <summary>
        /// When an item is selected, the item and all its sub-items are highlighted.
        /// </summary>
        public bool FullRowSelect { get => IsFlagSet(EBCSO.FullRowSelect); set => SetFlag(EBCSO.FullRowSelect, value); }

        /// <summary>
        /// The view should not display file names
        /// </summary>
        public bool HideFileNames { get => IsFlagSet(EBCSO.HideFileNames); set => SetFlag(EBCSO.HideFileNames, value); }

        /// <summary>
        /// The view should not save view state in the browser.
        /// </summary>
        public bool NoBrowserViewState { get => IsFlagSet(EBCSO.NoBrowserViewState); set => SetFlag(EBCSO.NoBrowserViewState, value); }

        /// <summary>
        /// Do not display a column header in the view in any view mode.
        /// </summary>
        public bool NoColumnHeader { get => IsFlagSet(EBCSO.NoColumnHeader); set => SetFlag(EBCSO.NoColumnHeader, value); }

        /// <summary>
        /// Only show the column header in details view mode.
        /// </summary>
        public bool NoHeaderInAllViews { get => IsFlagSet(EBCSO.NoHeaderInAllViews); set => SetFlag(EBCSO.NoHeaderInAllViews, value); }

        /// <summary>
        /// The view should not display icons. 
        /// </summary>
        public bool NoIcons { get => IsFlagSet(EBCSO.NoIcons); set => SetFlag(EBCSO.NoIcons, value); }

        /// <summary>
        /// Do not show subfolders. 
        /// </summary>
        public bool NoSubfolders { get => IsFlagSet(EBCSO.NoSubfolders); set => SetFlag(EBCSO.NoSubfolders, value); }

        /// <summary>
        /// Navigate with a single click.
        /// </summary>
        public bool SingleClickActivate { get => IsFlagSet(EBCSO.SingleClickActivate); set => SetFlag(EBCSO.SingleClickActivate, value); }

        /// <summary>
        /// Do not allow more than a single item to be selected.
        /// </summary>
        public bool SingleSelection { get => IsFlagSet(EBCSO.SingleSelection); set => SetFlag(EBCSO.SingleSelection, value); }

        private bool IsFlagSet(EBCSO flag) => (folderSettings.Options & (FolderOptions)flag) != 0;

        private void SetFlag(EBCSO flag, bool value)
        {
            if (value)

                folderSettings.Options |= (FolderOptions)flag;

            else

                folderSettings.Options &= ~(FolderOptions)flag;

            eb.explorerBrowserControl?.SetFolderSettings(folderSettings);
        }
        #endregion Content flags to properties mapping

        #region Thumbnail size
        /// <summary>
        /// The size of the thumbnails in pixels.
        /// </summary>
        public int ThumbnailSize
        {
            get
            {
                int iconSize = 0;
                IFolderView2 iFV2 = eb.GetFolderView2();

                if (iFV2 != null)

                    try
                    {
                        HResult hr = iFV2.GetViewModeAndIconSize(out int fvm, out iconSize);

                        if (hr != HResult.Ok)

                            throw new CommonControlException(LocalizedMessages.ExplorerBrowserIconSize, hr);
                    }

                    finally
                    {
                        CoreHelpers.DisposeCOMObject(ref iFV2);
                    }

                return iconSize;
            }

            set
            {
                IFolderView2 iFV2 = eb.GetFolderView2();

                if (iFV2 != null)

                    try
                    {
                        HResult hr = iFV2.GetViewModeAndIconSize(out int fvm, out int iconSize);

                        if ((hr = hr == HResult.Ok ? iFV2.SetViewModeAndIconSize(fvm, value) : throw new CommonControlException(LocalizedMessages.ExplorerBrowserIconSize, hr)) != HResult.Ok)

                            throw new CommonControlException(LocalizedMessages.ExplorerBrowserIconSize, hr);
                    }

                    finally
                    {
                        CoreHelpers.DisposeCOMObject(ref iFV2);
                    }
            }
        }
        #endregion
    }
}
