﻿//Copyright (c) Microsoft Corporation.  All rights reserved.  Distributed under the Microsoft Public License (MS-PL)

using Microsoft.WindowsAPICodePack.COMNative.Controls;
using Microsoft.WindowsAPICodePack.COMNative.Shell;
using Microsoft.WindowsAPICodePack.Internal;
using Microsoft.WindowsAPICodePack.Shell;
using Microsoft.WindowsAPICodePack.Shell.Guids;
using Microsoft.WindowsAPICodePack.Shell.Resources;
using Microsoft.WindowsAPICodePack.Win32Native;
using Microsoft.WindowsAPICodePack.Win32Native.Controls;
using Microsoft.WindowsAPICodePack.Win32Native.Shell;

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Microsoft.WindowsAPICodePack.Controls.WindowsForms
{
    /// <summary>
    /// This class is a wrapper around the Windows Explorer Browser control.
    /// </summary>
    public sealed class ExplorerBrowser : UserControl,
        COMNative.Controls.IServiceProvider,
        IExplorerPaneVisibility,
        IExplorerBrowserEvents,
        ICommDlgBrowser3,
        IMessageFilter
    {
        private IShellItemArray shellItemsArray;
        private ShellObjectCollection itemsCollection;
        private IShellItemArray selectedShellItemsArray;
        private ShellObjectCollection selectedItemsCollection;
        internal ExplorerBrowserClass explorerBrowserControl;
        // for the IExplorerBrowserEvents Advise call
        internal uint eventsCookie;
        // name of the property bag that contains the view state options of the browser
        string propertyBagName = typeof(ExplorerBrowser).FullName;
        ShellObject antecreationNavigationTarget;
        ExplorerBrowserViewEvents viewEvents;

        #region Properties
        /// <summary>
        /// Options that control how the ExplorerBrowser navigates
        /// </summary>
        public ExplorerBrowserNavigationOptions NavigationOptions { get; private set; }

        /// <summary>
        /// Options that control how the content of the ExplorerBorwser looks
        /// </summary>
        public ExplorerBrowserContentOptions ContentOptions { get; private set; }

        /// <summary>
        /// The set of ShellObjects in the Explorer Browser.
        /// </summary>
        public ShellObjectCollection Items
        {
            get
            {
                CoreHelpers.DisposeCOMObject(ref shellItemsArray);

                if (itemsCollection != null)
                {
                    itemsCollection.Dispose();
                    itemsCollection = null;
                }

                shellItemsArray = GetItemsArray();
                itemsCollection = new ShellObjectCollection(shellItemsArray, true);

                return itemsCollection;
            }
        }

        /// <summary>
        /// The set of selected ShellObjects in the Explorer Browser
        /// </summary>
        public ShellObjectCollection SelectedItems
        {
            get
            {
                CoreHelpers.DisposeCOMObject(ref selectedShellItemsArray);

                if (selectedItemsCollection != null)
                {
                    selectedItemsCollection.Dispose();
                    selectedItemsCollection = null;
                }

                selectedShellItemsArray = GetSelectedItemsArray();
                selectedItemsCollection = new ShellObjectCollection(selectedShellItemsArray, true);

                return selectedItemsCollection;
            }
        }

        /// <summary>
        /// Contains the navigation history of the ExplorerBrowser.
        /// </summary>
        public ExplorerBrowserNavigationLog NavigationLog { get; private set; }

        /// <summary>
        /// The name of the property bag used to persist changes to the ExplorerBrowser's view state.
        /// </summary>
        public string PropertyBagName
        {
            get => propertyBagName;

            set
            {
                propertyBagName = value;

                explorerBrowserControl?.SetPropertyBag(propertyBagName);
            }
        }
        #endregion Properties

        #region Operations
        /// <summary>
        /// Clears the Explorer Browser of existing content, fills it with
        /// content from the specified container, and adds a new point to the Travel Log.
        /// </summary>
        /// <param name="shellObject">The shell container to navigate to.</param>
        /// <exception cref="COMException">Will throw if navigation fails for any other reason.</exception>
        public void Navigate(ShellObject shellObject)
        {
            if (shellObject == null ? throw new ArgumentNullException(nameof(shellObject)) : explorerBrowserControl == null)

                antecreationNavigationTarget = shellObject;

            else
            {
                HResult hr = explorerBrowserControl.BrowseToObject(shellObject.NativeShellItem, 0);

                if (hr != HResult.Ok)
                {
                    var args = (hr == (HResult)unchecked((int)0x800700AA) || hr == HResult.Canceled) && NavigationFailed != null ? new NavigationFailedEventArgs
                    {
                        FailedLocation = shellObject
                    }
                    : throw new CommonControlException(LocalizedMessages.ExplorerBrowserBrowseToObjectFailed, hr);

                    NavigationFailed(this, args);
                }
            }
        }

        /// <summary>
        /// Navigates within the navigation log. This does not change the set of 
        /// locations in the navigation log.
        /// </summary>
        /// <param name="direction">Forward of Backward</param>
        /// <returns><see langword="true"/> if the navigation succeeded, <see langword="false"/> if it failed for any reason.</returns>
        public bool NavigateLogLocation(NavigationLogDirection direction) => NavigationLog.NavigateLog(direction);

        /// <summary>
        /// Navigate within the navigation log. This does not change the set of 
        /// locations in the navigation log.
        /// </summary>
        /// <param name="navigationLogIndex">An index into the navigation logs Locations collection.</param>
        /// <returns><see langword="true"/> if the navigation succeeded, <see langword="false"/> if it failed for any reason.</returns>
        public bool NavigateLogLocation(int navigationLogIndex) => NavigationLog.NavigateLog(navigationLogIndex);
        #endregion Operations

        #region Events
        /// <summary>
        /// Fires when the SelectedItems collection changes. 
        /// </summary>
        public event EventHandler SelectionChanged;

        /// <summary>
        /// Fires when the Items colection changes. 
        /// </summary>
        public event EventHandler ItemsChanged;

        /// <summary>
        /// Fires when a navigation has been initiated, but is not yet complete.
        /// </summary>
        public event EventHandler<NavigationPendingEventArgs> NavigationPending;

        /// <summary>
        /// Fires when a navigation has been 'completed': no NavigationPending listener 
        /// has cancelled, and the ExplorerBorwser has created a new view. The view 
        /// will be populated with new items asynchronously, and ItemsChanged will be 
        /// fired to reflect this some time later.
        /// </summary>
        public event EventHandler<NavigationCompleteEventArgs> NavigationComplete;

        /// <summary>
        /// Fires when either a NavigationPending listener cancels the navigation, or
        /// if the operating system determines that navigation is not possible.
        /// </summary>
        public event EventHandler<NavigationFailedEventArgs> NavigationFailed;

        /// <summary>
        /// Fires when the ExplorerBorwser view has finished enumerating files.
        /// </summary>
        public event EventHandler ViewEnumerationComplete;

        /// <summary>
        /// Fires when the item selected in the view has changed (i.e., a rename ).
        /// This is not the same as SelectionChanged.
        /// </summary>
        public event EventHandler ViewSelectedItemChanged;
        #endregion Events

        #region Implementation
        #region Construction
        /// <summary>
        /// Initializes the ExplorerBorwser WinForms wrapper.
        /// </summary>
        public ExplorerBrowser()
            : base()
        {
            NavigationOptions = new ExplorerBrowserNavigationOptions(this);
            ContentOptions = new ExplorerBrowserContentOptions(this);
            NavigationLog = new ExplorerBrowserNavigationLog(this);
        }
        #endregion Construction

        #region Message handlers
        /// <summary>
        /// Displays a placeholder for the explorer browser in design mode
        /// </summary>
        /// <param name="e">Contains information about the paint event.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            if (DesignMode && e != null)
            {
                using (LinearGradientBrush linGrBrush = new LinearGradientBrush(
                    ClientRectangle,
                    System.Drawing.Color.Aqua,
                    System.Drawing.Color.CadetBlue,
                    LinearGradientMode.ForwardDiagonal))

                    e.Graphics.FillRectangle(linGrBrush, ClientRectangle);

                using
#if !CS8
                    (
#endif
                    Font font = new Font("Garamond", 30)
#if CS8
                ;
#else
                )
#endif
                using
#if !CS8
                    (
#endif
                    StringFormat sf = new StringFormat()
#if CS8
                ;
#else
                )
#endif
                {
                    sf.Alignment = StringAlignment.Center;
                    sf.LineAlignment = StringAlignment.Center;
                    e.Graphics.DrawString(
                        "ExplorerBrowserControl",
                        font,
                        Brushes.White,
                        ClientRectangle,
                        sf);
                }
            }

            base.OnPaint(e);
        }

        /// <summary>
        /// Creates and initializes the native ExplorerBrowser control
        /// </summary>
        protected override void OnCreateControl()
        {
            base.OnCreateControl();

            if (!DesignMode)
            {
                explorerBrowserControl = new ExplorerBrowserClass();

                // hooks up IExplorerPaneVisibility and ICommDlgBrowser event notifications
                ExplorerBrowserNativeMethods.IUnknown_SetSite(explorerBrowserControl, this);

                // hooks up IExplorerBrowserEvents event notification
                explorerBrowserControl.Advise(
                    Marshal.GetComInterfaceForObject(this, typeof(IExplorerBrowserEvents)),
                    out eventsCookie);

                // sets up ExplorerBrowser view connection point events
                viewEvents = new ExplorerBrowserViewEvents(this);

                NativeRect rect = new NativeRect();
                rect.Top = ClientRectangle.Top;
                rect.Left = ClientRectangle.Left;
                rect.Right = ClientRectangle.Right;
                rect.Bottom = ClientRectangle.Bottom;

                explorerBrowserControl.Initialize(Handle, ref rect, null);

                // Force an initial show frames so that IExplorerPaneVisibility works the first time it is set.
                // This also enables the control panel to be browsed to. If it is not set, then navigating to 
                // the control panel succeeds, but no items are visible in the view.
                explorerBrowserControl.SetOptions(ExplorerBrowserOptions.ShowFrames);

                explorerBrowserControl.SetPropertyBag(propertyBagName);

                if (antecreationNavigationTarget != null)

                    BeginInvoke(new MethodInvoker(
                    delegate
                    {
                        Navigate(antecreationNavigationTarget);
                        antecreationNavigationTarget = null;
                    }));
            }

            Application.AddMessageFilter(this);
        }

        /// <summary>
        /// Sizes the native control to match the WinForms control wrapper.
        /// </summary>
        /// <param name="e">Contains information about the size changed event.</param>
        protected override void OnSizeChanged(EventArgs e)
        {
            if (explorerBrowserControl != null)
            {
                NativeRect rect = new NativeRect();
                rect.Top = ClientRectangle.Top;
                rect.Left = ClientRectangle.Left;
                rect.Right = ClientRectangle.Right;
                rect.Bottom = ClientRectangle.Bottom;

                IntPtr ptr = IntPtr.Zero;
                explorerBrowserControl.SetRect(ref ptr, rect);
            }

            base.OnSizeChanged(e);
        }

        /// <summary>
        /// Cleans up the explorer browser events+object when the window is being taken down.
        /// </summary>
        /// <param name="e">An EventArgs that contains event data.</param>
        protected override void OnHandleDestroyed(EventArgs e)
        {
            if (explorerBrowserControl != null)
            {
                // unhook events
                viewEvents.DisconnectFromView();
                explorerBrowserControl.Unadvise(eventsCookie);
                ExplorerBrowserNativeMethods.IUnknown_SetSite(explorerBrowserControl, null);

                // destroy the explorer browser control
                explorerBrowserControl.Destroy();

                // release com reference to it
                CoreHelpers.DisposeCOMObject(ref explorerBrowserControl);
            }

            base.OnHandleDestroyed(e);
        }
        #endregion Message handlers

        #region Object interfaces
        #region IServiceProvider
        /*/// <param name="guidService">calling service</param>
        /// <param name="riid">requested interface guid</param>
        /// <param name="ppvObject">caller-allocated memory for interface pointer</param>
        /// <returns></returns>*/
        HResult COMNative.Controls.IServiceProvider.QueryService(
            ref Guid guidService, ref Guid riid, out IntPtr ppvObject)
        {
            HResult hr;

            if (guidService.CompareTo(new Guid(NativeAPI.Guids.Shell.ExplorerBrowser.IExplorerPaneVisibility)) == 0)
            {
                // Responding to this SID allows us to control the visibility of the 
                // explorer browser panes
                ppvObject =
                    Marshal.GetComInterfaceForObject(this, typeof(IExplorerPaneVisibility));
                hr = HResult.Ok;
            }

            else if (guidService.CompareTo(new Guid(NativeAPI.Guids.Shell.ExplorerBrowser.ICommDlgBrowser)) == 0)
            {
                if (riid.CompareTo(new Guid(NativeAPI.Guids.Shell.ExplorerBrowser.ICommDlgBrowser)) == 0)
                {
                    ppvObject = Marshal.GetComInterfaceForObject(this, typeof(ICommDlgBrowser3));
                    hr = HResult.Ok;
                }

                // The below lines are commented out to decline requests for the ICommDlgBrowser2 interface.
                // This interface is incorrectly marshaled back to unmanaged, and causes an exception.
                // There is a bug for this, I have not figured the underlying cause.
                // Remove this comment and uncomment the following code to enable the ICommDlgBrowser2 interface
                //else if (riid.CompareTo(new Guid(NativeAPI.Guids.Shell.ExplorerBrowser.ICommDlgBrowser2)) == 0)
                //{
                //    ppvObject = Marshal.GetComInterfaceForObject(this, typeof(ICommDlgBrowser3));
                //    hr = HResult.Ok;                    
                //}

                else if (riid.CompareTo(new Guid(NativeAPI.Guids.Shell.ExplorerBrowser.ICommDlgBrowser3)) == 0)
                {
                    ppvObject = Marshal.GetComInterfaceForObject(this, typeof(ICommDlgBrowser3));
                    hr = HResult.Ok;
                }

                else
                {
                    ppvObject = IntPtr.Zero;
                    hr = HResult.NoInterface;
                }
            }

            else
            {
                IntPtr nullObj = IntPtr.Zero;
                ppvObject = nullObj;
                hr = HResult.NoInterface;
            }

            return hr;
        }
        #endregion IServiceProvider

        #region IExplorerPaneVisibility
        /// <summary>
        /// Controls the visibility of the explorer borwser panes
        /// </summary>
        /// <param name="explorerPane">a guid identifying the pane</param>
        /// <param name="peps">the pane state desired</param>
        /// <returns></returns>
        HResult IExplorerPaneVisibility.GetPaneState(ref Guid explorerPane, out ExplorerPaneState peps)
        {
            switch (explorerPane.ToString())
            {
                case ExplorerBrowserViewPanes.AdvancedQuery:
                    peps = VisibilityToPaneState(NavigationOptions.PaneVisibility.AdvancedQuery);
                    break;
                case ExplorerBrowserViewPanes.Commands:
                    peps = VisibilityToPaneState(NavigationOptions.PaneVisibility.Commands);
                    break;
                case ExplorerBrowserViewPanes.CommandsOrganize:
                    peps = VisibilityToPaneState(NavigationOptions.PaneVisibility.CommandsOrganize);
                    break;
                case ExplorerBrowserViewPanes.CommandsView:
                    peps = VisibilityToPaneState(NavigationOptions.PaneVisibility.CommandsView);
                    break;
                case ExplorerBrowserViewPanes.Details:
                    peps = VisibilityToPaneState(NavigationOptions.PaneVisibility.Details);
                    break;
                case ExplorerBrowserViewPanes.Navigation:
                    peps = VisibilityToPaneState(NavigationOptions.PaneVisibility.Navigation);
                    break;
                case ExplorerBrowserViewPanes.Preview:
                    peps = VisibilityToPaneState(NavigationOptions.PaneVisibility.Preview);
                    break;
                case ExplorerBrowserViewPanes.Query:
                    peps = VisibilityToPaneState(NavigationOptions.PaneVisibility.Query);
                    break;
                default:
#if LOG_UNKNOWN_PANES
                    System.Diagnostics.Debugger.Log( 4, "ExplorerBrowser", "unknown pane view state. id=" + explorerPane.ToString( ) );
#endif
                    peps = VisibilityToPaneState(PaneVisibilityState.Show);
                    break;
            }

            return HResult.Ok;
        }

        private static ExplorerPaneState VisibilityToPaneState(PaneVisibilityState visibility)
        {
            switch (visibility)
            {
                case PaneVisibilityState.DoNotCare:
                    return ExplorerPaneState.DoNotCare;

                case PaneVisibilityState.Hide:
                    return ExplorerPaneState.DefaultOff | ExplorerPaneState.Force;

                case PaneVisibilityState.Show:
                    return ExplorerPaneState.DefaultOn | ExplorerPaneState.Force;

                default:
                    throw new ArgumentException("unexpected PaneVisibilityState");
            }
        }
        #endregion IExplorerPaneVisibility

        #region IExplorerBrowserEvents
        HResult IExplorerBrowserEvents.OnNavigationPending(IntPtr pidlFolder)
        {
            bool canceled = false;

            if (NavigationPending != null)
            {
                var args = new NavigationPendingEventArgs();

                // For some special items (like network machines), ShellObject.FromIDList
                // might return null
                args.PendingLocation = ShellObjectFactory.Create(pidlFolder);

                if (args.PendingLocation != null)

                    foreach (Delegate del in NavigationPending.GetInvocationList())
                    {
                        del.DynamicInvoke(new object[] { this, args });

                        if (args.Cancel)

                            canceled = true;
                    }
            }

            return canceled ? HResult.Canceled : HResult.Ok;
        }

        HResult IExplorerBrowserEvents.OnViewCreated(object psv)
        {
            viewEvents.ConnectToView((IShellView)psv);

            return HResult.Ok;
        }

        HResult IExplorerBrowserEvents.OnNavigationComplete(IntPtr pidlFolder)
        {
            // view mode may change 
            ContentOptions.folderSettings.ViewMode = GetCurrentViewMode();

            if (NavigationComplete != null)
            {
                NavigationCompleteEventArgs args = new NavigationCompleteEventArgs();
                args.NewLocation = ShellObjectFactory.Create(pidlFolder);
                NavigationComplete(this, args);
            }

            return HResult.Ok;
        }

        HResult IExplorerBrowserEvents.OnNavigationFailed(IntPtr pidlFolder)
        {
            if (NavigationFailed != null)
            {
                NavigationFailedEventArgs args = new NavigationFailedEventArgs();
                args.FailedLocation = ShellObjectFactory.Create(pidlFolder);
                NavigationFailed(this, args);
            }

            return HResult.Ok;
        }
        #endregion IExplorerBrowserEvents

        #region ICommDlgBrowser
        HResult ICommDlgBrowser3.OnDefaultCommand(IntPtr ppshv) => HResult.False; //return HResult.Ok;

        HResult ICommDlgBrowser3.OnStateChange(IntPtr ppshv, CommDlgBrowserStateChange uChange)
        {
            if (uChange == CommDlgBrowserStateChange.SelectionChange)

                FireSelectionChanged();

            return HResult.Ok;
        }

        HResult ICommDlgBrowser3.IncludeObject(IntPtr ppshv, IntPtr pidl)
        {
            // items in the view have changed, so the collections need updating
            FireContentChanged();

            return HResult.Ok;
        }
        #endregion ICommDlgBrowser

        #region ICommDlgBrowser2 Members
        // The below methods can be called into, but marshalling the response causes an exception to be
        // thrown from unmanaged code.  At this time, I decline calls requesting the ICommDlgBrowser2
        // interface.  This is logged as a bug, but moved to less of a priority, as it only affects being
        // able to change the default action text for remapping the default action.

        HResult ICommDlgBrowser3.GetDefaultMenuText(IShellView shellView, IntPtr text, int cchMax) => HResult.False;//return HResult.Ok;//OK if new//False if default//other if error

        HResult ICommDlgBrowser3.GetViewFlags(out uint pdwFlags)
        {
            //var flags = CommDlgBrowser2ViewFlags.NoSelectVerb;
            //Marshal.WriteInt32(pdwFlags, 0);
            pdwFlags = (uint)CommDlgBrowser2ViewFlags.ShowAllFiles;
            return HResult.Ok;
        }

        HResult ICommDlgBrowser3.Notify(IntPtr pshv, CommDlgBrowserNotifyType notifyType) => HResult.Ok;
        #endregion ICommDlgBrowser2 Members

        #region ICommDlgBrowser3 Members
        HResult ICommDlgBrowser3.GetCurrentFilter(StringBuilder pszFileSpec, int cchFileSpec) =>
            // If the method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.
            HResult.Ok;

        HResult ICommDlgBrowser3.OnColumnClicked(IShellView ppshv, int iColumn) =>
            // If the method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.
            HResult.Ok;

        HResult ICommDlgBrowser3.OnPreViewCreated(IShellView ppshv) =>
            // If the method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code
            HResult.Ok;
        #endregion ICommDlgBrowser3 Members

        #region IMessageFilter Members
        bool IMessageFilter.PreFilterMessage(ref System.Windows.Forms.Message m) =>
            // translate keyboard input

            explorerBrowserControl != null && ((IInputObject)explorerBrowserControl).TranslateAcceleratorIO(ref m) == HResult.Ok;
        #endregion IMessageFilter Members
        #endregion Object interfaces

        #region Utilities
        /// <summary>
        /// Returns the current view mode of the browser
        /// </summary>
        internal FolderViewMode GetCurrentViewMode()
        {
            IFolderView2 ifv2 = GetFolderView2();
            uint viewMode = 0;

            if (ifv2 != null)

                try
                {
                    HResult hr = ifv2.GetCurrentViewMode(out viewMode);

                    if (hr != HResult.Ok) throw new ShellException(hr);
                }

                finally
                {
                    CoreHelpers.DisposeCOMObject(ref ifv2);
                }

            return (FolderViewMode)viewMode;
        }

        /// <summary>
        /// Gets the <see cref="IFolderView2"/> interface from the explorer browser.
        /// </summary>
        internal IFolderView2
#if CS8
            ?
#endif
            GetFolderView2()
        {
            Guid iid = new Guid(NativeAPI.Guids.Shell.ExplorerBrowser.IFolderView2);
            IntPtr view = IntPtr.Zero;

            if (explorerBrowserControl == null)

                return null;

            HResult hr = explorerBrowserControl.GetCurrentView(ref iid, out view);

            switch (hr)
            {
                case HResult.Ok:
                    break;

                case HResult.NoInterface:
                case HResult.Fail:
#if LOG_KNOWN_COM_ERRORS
                        Debugger.Log( 2, "ExplorerBrowser", "Unable to obtain view. Error=" + e.ToString( ) );
#endif
                    return null;

                default:

                    throw new CommonControlException(LocalizedMessages.ExplorerBrowserFailedToGetView, hr);
            }

            return (IFolderView2)Marshal.GetObjectForIUnknown(view);
        }

        /// <summary>
        /// Gets the selected items in the explorer browser as an <see cref="IShellItemArray"/>.
        /// </summary>
        internal IShellItemArray
#if CS8
            ?
#endif
            GetSelectedItemsArray()
        {
            IShellItemArray
#if CS8
                ?
#endif
                iArray = null;
            IFolderView2 iFV2 = GetFolderView2();

            if (iFV2 != null)
            {
                try
                {
                    Guid iidShellItemArray = new Guid(NativeAPI.Guids.Shell.IShellItemArray);
                    HResult hr = iFV2.Items((uint)ShellViewGetItemObject.Selection, ref iidShellItemArray, out object oArray);
                    iArray = oArray as IShellItemArray;

                    if (!(hr == HResult.Ok ||
                        hr == HResult.ElementNotFound ||
                        hr == HResult.Fail))

                        throw new CommonControlException(LocalizedMessages.ExplorerBrowserUnexpectedError, hr);
                }

                finally
                {
                    CoreHelpers.DisposeCOMObject(ref iFV2);
                }
            }

            return iArray;
        }

        internal int GetItemsCount()
        {
            int itemsCount = 0;
            IFolderView2
#if CS8
                ?
#endif
                iFV2 = GetFolderView2();

            if (iFV2 != null)

                try
                {
                    HResult hr = iFV2.ItemCount((uint)ShellViewGetItemObject.AllView, out itemsCount);

                    if (!(hr == HResult.Ok ||
                        hr == HResult.ElementNotFound ||
                        hr == HResult.Fail))

                        throw new CommonControlException(LocalizedMessages.ExplorerBrowserItemCount, hr);
                }

                finally
                {
                    CoreHelpers.DisposeCOMObject(ref iFV2);
                }

            return itemsCount;
        }

        internal int GetSelectedItemsCount()
        {
            int itemsCount = 0;
            IFolderView2
#if CS8
                ?
#endif
                iFV2 = GetFolderView2();

            if (iFV2 != null)

                try
                {
                    HResult hr = iFV2.ItemCount((uint)ShellViewGetItemObject.Selection, out itemsCount);

                    if (!(hr == HResult.Ok ||
                        hr == HResult.ElementNotFound ||
                        hr == HResult.Fail))

                        throw new CommonControlException(LocalizedMessages.ExplorerBrowserSelectedItemCount, hr);
                }

                finally
                {
                    CoreHelpers.DisposeCOMObject(ref iFV2);
                }

            return itemsCount;
        }

        /// <summary>
        /// Gets the items in the <see cref="ExplorerBrowser"/> as an <see cref="IShellItemArray"/>.
        /// </summary>
        internal IShellItemArray
#if CS8
            ?
#endif
            GetItemsArray()
        {
            IShellItemArray
#if CS8
                ?
#endif
                iArray = null;
            IFolderView2
#if CS8
                ?
#endif
                iFV2 = GetFolderView2();

            if (iFV2 != null)

                try
                {
                    Guid iidShellItemArray = new Guid(NativeAPI.Guids.Shell.IShellItemArray);
                    HResult hr = iFV2.Items((uint)ShellViewGetItemObject.AllView, ref iidShellItemArray, out object oArray);

                    if (!(hr == HResult.Ok ||
                        hr == HResult.Fail ||
                        hr == HResult.ElementNotFound ||
                        hr == HResult.InvalidArguments))

                        throw new CommonControlException(LocalizedMessages.ExplorerBrowserViewItems, hr);

                    iArray = oArray as IShellItemArray;
                }

                finally
                {
                    CoreHelpers.DisposeCOMObject(ref iFV2);
                }

            return iArray;
        }
        #endregion Utilities

        #region View event forwarding
        internal void FireSelectionChanged() => SelectionChanged?.Invoke(this, EventArgs.Empty);

        internal void FireContentChanged() => ItemsChanged?.Invoke(this, EventArgs.Empty);

        internal void FireContentEnumerationComplete() => ViewEnumerationComplete?.Invoke(this, EventArgs.Empty);

        internal void FireSelectedItemChanged() => ViewSelectedItemChanged?.Invoke(this, EventArgs.Empty);
        #endregion View event forwarding
        #endregion Implementation
    }
}
