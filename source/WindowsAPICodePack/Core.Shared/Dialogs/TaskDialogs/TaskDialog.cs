//Copyright (c) Microsoft Corporation.  All rights reserved.  Distributed under the Microsoft Public License (MS-PL)

using Microsoft.WindowsAPICodePack.Resources;
using Microsoft.WindowsAPICodePack.Win32Native;
using Microsoft.WindowsAPICodePack.Win32Native.Dialogs;

using System;
using System.Collections.Generic;
using System.Diagnostics;

using WinCopies
#if !WAPICP3
.Util
#endif
    ;

using static Microsoft.WindowsAPICodePack.Win32Native.Dialogs.TaskDialog.TaskDialogCommonButtonReturnIds;

namespace Microsoft.WindowsAPICodePack.Dialogs
{
    /// <summary>
    /// Encapsulates a new-to-Vista Win32 TaskDialog window 
    /// - a powerful successor to the MessageBox available
    /// in previous versions of Windows.
    /// </summary>
    public sealed class TaskDialog : IDialogControlHost, WinCopies.
#if !WAPICP3
        Util.
#endif
        DotNetFix.IDisposable
    {
        #region Private Fields
        // Global instance of TaskDialog, to be used by static Show() method.
        // As most parameters of a dialog created via static Show() will have
        // identical parameters, we'll create one TaskDialog and treat it
        // as a NativeTaskDialog generator for all static Show() calls.
        private static TaskDialog _staticDialog;

        // Main current native dialog.
        private NativeTaskDialog _nativeDialog;

        private List<TaskDialogButtonBase> buttons = new
#if !CS9
            List<TaskDialogButtonBase>
#endif
            ();
        private List<TaskDialogButtonBase> radioButtons = new
#if !CS9
            List<TaskDialogButtonBase>
#endif
            ();
        private List<TaskDialogButtonBase> commandLinks = new
#if !CS9
            List<TaskDialogButtonBase>
#endif
            ();
        private IntPtr ownerWindow;

        // Main content (maps to MessageBox's "message"). 
        private string text;
        private string instructionText;
        private string caption;
        private string footerText;
        private string checkBoxText;
        private string detailsExpandedText;
        private bool detailsExpanded;
        private string detailsExpandedLabel;
        private string detailsCollapsedLabel;
        private bool cancelable;
        private TaskDialogStandardIcon icon;
        private TaskDialogStandardIcon footerIcon;
        private TaskDialogStandardButtons standardButtons = TaskDialogStandardButtons.None;
        private bool hyperlinksEnabled;
        private bool? footerCheckBoxChecked = null;
        private TaskDialogExpandedDetailsLocation expansionMode;
        private TaskDialogStartupLocation startupLocation;
        private TaskDialogProgressBar progressBar;
        #endregion

        #region Public Properties
        /// <summary>
        /// Gets or sets a value that contains the owner window's handle.
        /// </summary>
        public IntPtr OwnerWindowHandle
        {
            get => ownerWindow;

            set => UpdateValue(ref ownerWindow, value, LocalizedMessages.OwnerCannotBeChanged);
        }

        /// <summary>
        /// Gets or sets a value that contains the message text.
        /// </summary>
        public string Text
        {
            get => text;

            set =>
                // Set local value, then update native dialog if showing.
                UpdateValue(ref text, value, _nativeDialog.UpdateText);
        }

        /// <summary>
        /// Gets or sets a value that contains the instruction text.
        /// </summary>
        public string InstructionText
        {
            get => instructionText;

            set =>
                // Set local value, then update native dialog if showing.
                UpdateValue(ref instructionText, value, _nativeDialog.UpdateInstruction);
        }

        /// <summary>
        /// Gets or sets a value that contains the caption text.
        /// </summary>
        public string Caption
        {
            get => caption;

            set => UpdateValue(ref caption, value, LocalizedMessages.CaptionCannotBeChanged);
        }

        /// <summary>
        /// Gets or sets a value that contains the footer text.
        /// </summary>
        public string FooterText
        {
            get => footerText;

            set =>
                // Set local value, then update native dialog if showing.
                UpdateValue(ref footerText, value, _nativeDialog.UpdateFooterText);
        }

        /// <summary>
        /// Gets or sets a value that contains the footer check box text.
        /// </summary>
        public string FooterCheckBoxText
        {
            get => checkBoxText;

            set => UpdateValue(ref checkBoxText, value, LocalizedMessages.CheckBoxCannotBeChanged);
        }

        /// <summary>
        /// Gets or sets a value that contains the expanded text in the details section.
        /// </summary>
        public string DetailsExpandedText
        {
            get => detailsExpandedText;

            set =>
                // Set local value, then update native dialog if showing.
                UpdateValue(ref detailsExpandedText, value, _nativeDialog.UpdateExpandedText);
        }

        /// <summary>
        /// Gets or sets a value that determines if the details section is expanded.
        /// </summary>
        public bool DetailsExpanded
        {
            get => detailsExpanded;

            set => UpdateValue(ref detailsExpanded, value, LocalizedMessages.ExpandingStateCannotBeChanged);
        }

        /// <summary>
        /// Gets or sets a value that contains the expanded control text.
        /// </summary>
        public string DetailsExpandedLabel
        {
            get => detailsExpandedLabel;

            set => UpdateValue(ref detailsExpandedLabel, value, LocalizedMessages.ExpandedLabelCannotBeChanged);
        }

        /// <summary>
        /// Gets or sets a value that contains the collapsed control text.
        /// </summary>
        public string DetailsCollapsedLabel
        {
            get => detailsCollapsedLabel;

            set => UpdateValue(ref detailsCollapsedLabel, value, LocalizedMessages.CollapsedTextCannotBeChanged);
        }

        /// <summary>
        /// Gets or sets a value that determines if Cancelable is set.
        /// </summary>
        public bool Cancelable
        {
            get => cancelable;

            set => UpdateValue(ref cancelable, value, LocalizedMessages.CancelableCannotBeChanged);
        }

        /// <summary>
        /// Gets or sets a value that contains the TaskDialog main icon.
        /// </summary>
        public TaskDialogStandardIcon Icon
        {
            get => icon;

            set =>
                // Set local value, then update native dialog if showing.
                UpdateValue(ref icon, value, _nativeDialog.UpdateMainIcon);
        }

        /// <summary>
        /// Gets or sets a value that contains the footer icon.
        /// </summary>
        public TaskDialogStandardIcon FooterIcon
        {
            get => footerIcon;

            set =>
                // Set local value, then update native dialog if showing.
                UpdateValue(ref footerIcon, value, _nativeDialog.UpdateFooterIcon);
        }

        /// <summary>
        /// Gets or sets a value that contains the standard buttons.
        /// </summary>
        public TaskDialogStandardButtons StandardButtons
        {
            get => standardButtons;

            set => UpdateValue(ref standardButtons, value, LocalizedMessages.StandardButtonsCannotBeChanged);
        }

        /// <summary>
        /// Gets a value that contains the TaskDialog controls.
        /// </summary>
        public DialogControlCollection<TaskDialogControl> Controls
        {
            // "Show protection" provided by collection itself, 
            // as well as individual controls.
            get;
        }

        /// <summary>
        /// Gets or sets a value that determines if hyperlinks are enabled.
        /// </summary>
        public bool HyperlinksEnabled
        {
            get => hyperlinksEnabled;

            set => UpdateValue(ref hyperlinksEnabled, value, LocalizedMessages.HyperlinksCannotBetSet);
        }

        /// <summary>
        /// Gets or sets a value that indicates if the footer checkbox is checked.
        /// </summary>
        public bool? FooterCheckBoxChecked
        {
            get => footerCheckBoxChecked.GetValueOrDefault(false);

            set
            {
                // Set local value, then update native dialog if showing.
                footerCheckBoxChecked = value;
                if (NativeDialogShowing) _nativeDialog.UpdateCheckBoxChecked(footerCheckBoxChecked.Value);
            }
        }

        /// <summary>
        /// Gets or sets a value that contains the expansion mode for this dialog.
        /// </summary>
        public TaskDialogExpandedDetailsLocation ExpansionMode
        {
            get => expansionMode;

            set => UpdateValue(ref expansionMode, value, LocalizedMessages.ExpandedDetailsCannotBeChanged);
        }

        /// <summary>
        /// Gets or sets a value that contains the startup location.
        /// </summary>
        public TaskDialogStartupLocation StartupLocation
        {
            get => startupLocation;

            set => UpdateValue(ref startupLocation, value, LocalizedMessages.StartupLocationCannotBeChanged);
        }

        /// <summary>
        /// Gets or sets the progress bar on the taskdialog. ProgressBar a visual representation 
        /// of the progress of a long running operation.
        /// </summary>
        public TaskDialogProgressBar ProgressBar
        {
            get => progressBar;

            set
            {
                ThrowIfDialogShowing(LocalizedMessages.ProgressBarCannotBeChanged);

                if (value != null)

                    value.HostingDialog = value.HostingDialog == null ? this : throw new InvalidOperationException(LocalizedMessages.ProgressBarCannotBeHostedInMultipleDialogs);

                progressBar = value;
            }
        }
        #endregion

        #region Public Events
        /// <summary>
        /// Occurs when a progress bar changes.
        /// </summary>
        public event System.EventHandler<TaskDialogTickEventArgs> Tick;

        /// <summary>
        /// Occurs when a user clicks a hyperlink.
        /// </summary>
        public event System.EventHandler<TaskDialogHyperlinkClickedEventArgs> HyperlinkClick;

        /// <summary>
        /// Occurs when the TaskDialog is closing.
        /// </summary>
        public event System.EventHandler<TaskDialogClosingEventArgs> Closing;

        /// <summary>
        /// Occurs when a user clicks on Help.
        /// </summary>
        public event EventHandler HelpInvoked;

        /// <summary>
        /// Occurs when the TaskDialog is opened.
        /// </summary>
        public event EventHandler Opened;
        #endregion

        #region Constructors
        /// <summary>
        /// Creates a basic TaskDialog window 
        /// </summary>
        public TaskDialog()
        {
            CoreHelpers.ThrowIfNotVista();

            // Initialize various data structs.
            Controls = new DialogControlCollection<TaskDialogControl>(this);
        }
        #endregion

        #region Static Show Methods
        /// <summary>
        /// Creates and shows a task dialog with the specified message text.
        /// </summary>
        /// <param name="text">The text to display.</param>
        /// <returns>The dialog result.</returns>
        public static TaskDialogResult Show(in string text) => ShowCoreStatic(
                text,
                TaskDialogDefaults.MainInstruction,
                TaskDialogDefaults.Caption);

        /// <summary>
        /// Creates and shows a task dialog with the specified supporting text and main instruction.
        /// </summary>
        /// <param name="text">The supporting text to display.</param>
        /// <param name="instructionText">The main instruction text to display.</param>
        /// <returns>The dialog result.</returns>
        public static TaskDialogResult Show(in string text, in string instructionText) => ShowCoreStatic(
                text,
                instructionText,
                TaskDialogDefaults.Caption);

        /// <summary>
        /// Creates and shows a task dialog with the specified supporting text, main instruction, and dialog caption.
        /// </summary>
        /// <param name="text">The supporting text to display.</param>
        /// <param name="instructionText">The main instruction text to display.</param>
        /// <param name="caption">The caption for the dialog.</param>
        /// <returns>The dialog result.</returns>
        public static TaskDialogResult Show(in string text, in string instructionText, in string caption) => ShowCoreStatic(text, instructionText, caption);
        #endregion

        #region Instance Show Methods
        /// <summary>
        /// Creates and shows a task dialog.
        /// </summary>
        /// <returns>The dialog result.</returns>
        public TaskDialogResult Show() => ShowCore();
        #endregion

        #region Core Show Logic
        // CORE SHOW METHODS:
        // All static Show() calls forward here - 
        // it is responsible for retrieving
        // or creating our cached TaskDialog instance, getting it configured,
        // and in turn calling the appropriate instance Show.

        private static TaskDialogResult ShowCoreStatic(
            string text,
            string instructionText,
            string caption)
        {
            CoreHelpers.ThrowIfNotVista();

            // If no instance cached yet, create it.
            if (_staticDialog == null)

                // New TaskDialog will automatically pick up defaults when 
                // a new config structure is created as part of ShowCore().
                _staticDialog = new TaskDialog();

            // Set the few relevant properties, 
            // and go with the defaults for the others.
            _staticDialog.text = text;
            _staticDialog.instructionText = instructionText;
            _staticDialog.caption = caption;

            return _staticDialog.Show();
        }

        private TaskDialogResult ShowCore()
        {
            TaskDialogResult result;

            try
            {
                // Populate control lists, based on current 
                // contents - note we are somewhat late-bound 
                // on our control lists, to support XAML scenarios.
                SortDialogControls();

                // First, let's make sure it even makes 
                // sense to try a show.
                ValidateCurrentDialogSettings();

                // Create settings object for new dialog, 
                // based on current state.
                var settings = new NativeTaskDialogSettings();
                ApplyCoreSettings(settings);
                ApplySupplementalSettings(settings);

                // Show the dialog.
                // NOTE: this is a BLOCKING call; the dialog proc callbacks
                // will be executed by the same thread as the 
                // Show() call before the thread of execution 
                // contines to the end of this method.
                _nativeDialog = new NativeTaskDialog(settings, this);
                _nativeDialog.NativeShow();

                // Build and return dialog result to public API - leaving it
                // null after an exception is thrown is fine in this case
                result = ConstructDialogResult(_nativeDialog);
                footerCheckBoxChecked = _nativeDialog.CheckBoxChecked;
            }

            finally
            {
                CleanUp();
                _nativeDialog = null;
            }

            return result;
        }

        // Helper that looks at the current state of the TaskDialog and verifies
        // that there aren't any abberant combinations of properties.
        // NOTE that this method is designed to throw 
        // rather than return a bool.
        private void ValidateCurrentDialogSettings()
        {
            if (footerCheckBoxChecked.HasValue &&
                footerCheckBoxChecked.Value == true &&
                string.IsNullOrEmpty(checkBoxText))

                throw new InvalidOperationException(LocalizedMessages.TaskDialogCheckBoxTextRequiredToEnableCheckBox);

            // Progress bar validation.
            // Make sure the progress bar values are valid.
            // the Win32 API will valiantly try to rationalize 
            // bizarre min/max/value combinations, but we'll save
            // it the trouble by validating.
            if (progressBar != null && !progressBar.HasValidValues)

                throw new InvalidOperationException(LocalizedMessages.TaskDialogProgressBarValueInRange);

            // Validate Buttons collection.
            // Make sure we don't have buttons AND 
            // command-links - the Win32 API treats them as different
            // flavors of a single button struct.
            if (buttons.Count > 0)

                if (commandLinks.Count > 0)

                    throw new NotSupportedException(LocalizedMessages.TaskDialogSupportedButtonsAndLinks);

                else if (standardButtons != TaskDialogStandardButtons.None)

                    throw new NotSupportedException(LocalizedMessages.TaskDialogSupportedButtonsAndButtons);
        }

        // Analyzes the final state of the NativeTaskDialog instance and creates the 
        // final TaskDialogResult that will be returned from the public API
        private static TaskDialogResult ConstructDialogResult(in NativeTaskDialog native)
        {
            Debug.Assert(native.ShowState == DialogShowState.Closed, "dialog result being constructed for unshown dialog.");

            TaskDialogStandardButtons standardButton = MapButtonIdToStandardButton(native.SelectedButtonId);

            // If returned ID isn't a standard button, let's fetch 
            return standardButton == TaskDialogStandardButtons.None ? TaskDialogResult.CustomButtonClicked : (TaskDialogResult)standardButton;
        }

        /// <summary>
        /// Close TaskDialog with a given <see cref="TaskDialogResult"/>
        /// </summary>
        /// <param name="closingResult"><see cref="TaskDialogResult"/> to return from the <see cref="Show()"/> method</param>
        /// <exception cref="InvalidOperationException">if TaskDialog is not showing.</exception>
        public void Close(in TaskDialogResult closingResult) => (NativeDialogShowing ? _nativeDialog : throw new InvalidOperationException(LocalizedMessages.TaskDialogCloseNonShowing)).NativeClose(closingResult);

        /// <summary>
        /// Close TaskDialog
        /// </summary>
        /// <exception cref="InvalidOperationException">if TaskDialog is not showing.</exception>
        public void Close() => Close(TaskDialogResult.Cancel); // TaskDialog's own cleanup code -
                                                               // which runs post show - will handle disposal of native dialog.
        #endregion

        #region Configuration Construction
        private void ApplyCoreSettings(in NativeTaskDialogSettings settings)
        {
            ApplyGeneralNativeConfiguration(settings.NativeConfiguration);
            ApplyTextConfiguration(settings.NativeConfiguration);
            ApplyOptionConfiguration(settings.NativeConfiguration);
            ApplyControlConfiguration(settings);
        }

        private void ApplyGeneralNativeConfiguration(in Win32Native.Dialogs.TaskDialog.TaskDialogConfiguration dialogConfig)
        {
            // If an owner wasn't specifically specified, 
            // we'll use the app's main window.
            if (ownerWindow != IntPtr.Zero)

                dialogConfig.parentHandle = ownerWindow;

            // Other miscellaneous sets.
            dialogConfig.mainIcon = new Win32Native.Dialogs.TaskDialog.IconUnion((int)icon);
            dialogConfig.footerIcon = new Win32Native.Dialogs.TaskDialog.IconUnion((int)footerIcon);
            dialogConfig.commonButtons = (Win32Native.Dialogs.TaskDialog.TaskDialogCommonButtons)standardButtons;
        }

        /// <summary>
        /// Sets important text properties.
        /// </summary>
        /// <param name="dialogConfig">An instance of a <see cref="Win32Native.Dialogs.TaskDialog.TaskDialogConfiguration"/> object.</param>
        private void ApplyTextConfiguration(in Win32Native.Dialogs.TaskDialog.TaskDialogConfiguration dialogConfig)
        {
            // note that nulls or empty strings are fine here.
            dialogConfig.content = text;
            dialogConfig.windowTitle = caption;
            dialogConfig.mainInstruction = instructionText;
            dialogConfig.expandedInformation = detailsExpandedText;
            dialogConfig.expandedControlText = detailsExpandedLabel;
            dialogConfig.collapsedControlText = detailsCollapsedLabel;
            dialogConfig.footerText = footerText;
            dialogConfig.verificationText = checkBoxText;
        }

        private void ApplyOptionConfiguration(in Win32Native.Dialogs.TaskDialog.TaskDialogConfiguration dialogConfig)
        {
            // Handle options - start with no options set.
            Win32Native.Dialogs.TaskDialog.TaskDialogOptions options = Win32Native.Dialogs.TaskDialog.TaskDialogOptions.None;

            if (cancelable)

                options |= Win32Native.Dialogs.TaskDialog.TaskDialogOptions.AllowCancel;

            if (footerCheckBoxChecked.HasValue && footerCheckBoxChecked.Value)

                options |= Win32Native.Dialogs.TaskDialog.TaskDialogOptions.CheckVerificationFlag;

            if (hyperlinksEnabled)

                options |= Win32Native.Dialogs.TaskDialog.TaskDialogOptions.EnableHyperlinks;

            if (detailsExpanded)

                options |= Win32Native.Dialogs.TaskDialog.TaskDialogOptions.ExpandedByDefault;

            if (Tick != null)

                options |= Win32Native.Dialogs.TaskDialog.TaskDialogOptions.UseCallbackTimer;

            if (startupLocation == TaskDialogStartupLocation.CenterOwner)

                options |= Win32Native.Dialogs.TaskDialog.TaskDialogOptions.PositionRelativeToWindow;

            // Note: no validation required, as we allow this to 
            // be set even if there is no expanded information 
            // text because that could be added later.
            // Default for Win32 API is to expand into (and after) 
            // the content area.
            if (expansionMode == TaskDialogExpandedDetailsLocation.ExpandFooter)

                options |= Win32Native.Dialogs.TaskDialog.TaskDialogOptions.ExpandFooterArea;

            // Finally, apply options to config.
            dialogConfig.taskDialogFlags = options;
        }

        // Builds the actual configuration 
        // that the NativeTaskDialog (and underlying Win32 API)
        // expects, by parsing the various control 
        // lists, marshalling to the unmanaged heap, etc.

        private void ApplyControlConfiguration(in NativeTaskDialogSettings settings)
        {
            // Deal with progress bars/marquees.
            if (progressBar != null)

                settings.NativeConfiguration.taskDialogFlags |= progressBar.State == TaskDialogProgressBarState.Marquee ? Win32Native.Dialogs.TaskDialog.TaskDialogOptions.ShowMarqueeProgressBar : Win32Native.Dialogs.TaskDialog.TaskDialogOptions.ShowProgressBar;

            // Build the native struct arrays that NativeTaskDialog 
            // needs - though NTD will handle
            // the heavy lifting marshalling to make sure 
            // all the cleanup is centralized there.
            if (buttons.Count > 0 || commandLinks.Count > 0)
            {
                // These are the actual arrays/lists of 
                // the structs that we'll copy to the 
                // unmanaged heap.
                List<TaskDialogButtonBase> sourceList = (buttons.Count > 0 ? buttons : commandLinks);
                settings.Buttons = BuildButtonStructArray(sourceList);

                // Apply option flag that forces all 
                // custom buttons to render as command links.
                if (commandLinks.Count > 0)

                    settings.NativeConfiguration.taskDialogFlags |= Win32Native.Dialogs.TaskDialog.TaskDialogOptions.UseCommandLinks;

                // Set default button and add elevation icons 
                // to appropriate buttons.
                settings.NativeConfiguration.defaultButtonIndex = FindDefaultButtonId(sourceList);

                ApplyElevatedIcons(settings, sourceList);
            }

            if (radioButtons.Count > 0)
            {
                settings.RadioButtons = BuildButtonStructArray(radioButtons);

                // Set default radio button - radio buttons don't support.
                int defaultRadioButton = FindDefaultButtonId(radioButtons);
                settings.NativeConfiguration.defaultRadioButtonIndex = defaultRadioButton;

                if (defaultRadioButton == Win32Native.Dialogs.TaskDialog.NoDefaultButtonSpecified)

                    settings.NativeConfiguration.taskDialogFlags |= Win32Native.Dialogs.TaskDialog.TaskDialogOptions.NoDefaultRadioButton;
            }
        }

        private static Win32Native.Dialogs.TaskDialog.TaskDialogButton[] BuildButtonStructArray(in List<TaskDialogButtonBase> controls)
        {
            Win32Native.Dialogs.TaskDialog.TaskDialogButton[] buttonStructs;
            TaskDialogButtonBase button;

            int totalButtons = controls.Count;
            buttonStructs = new Win32Native.Dialogs.TaskDialog.TaskDialogButton[totalButtons];
            for (int i = 0; i < totalButtons; i++)
            {
                button = controls[i];
                buttonStructs[i] = new Win32Native.Dialogs.TaskDialog.TaskDialogButton(button.Id, button.ToString());
            }
            return buttonStructs;
        }

        // Searches list of controls and returns the ID of 
        // the default control, or 0 if no default was specified.
        private static int FindDefaultButtonId(in List<TaskDialogButtonBase> controls)
        {
            List<TaskDialogButtonBase> defaults = controls.FindAll(control => control.Default);

            return defaults.Count == 1 ? defaults[0].Id : defaults.Count > 1 ? throw new InvalidOperationException(LocalizedMessages.TaskDialogOnlyOneDefaultControl) : Win32Native.Dialogs.TaskDialog.NoDefaultButtonSpecified;
        }

        private static void ApplyElevatedIcons(in NativeTaskDialogSettings settings, in List<TaskDialogButtonBase> controls)
        {
            foreach (TaskDialogButton control in controls)

                if (control.UseElevationIcon)

                    (settings.ElevatedButtons
#if CS8
                        ??=
#else
                        ?? (settings.ElevatedButtons =
#endif
                        new List<int>()
#if !CS8
                        )
#endif
                    ).Add(control.Id);
        }

        private void ApplySupplementalSettings(in NativeTaskDialogSettings settings)
        {
            if (progressBar != null &&
                progressBar.State != TaskDialogProgressBarState.Marquee)
            {
                settings.ProgressBarMinimum = progressBar.Minimum;
                settings.ProgressBarMaximum = progressBar.Maximum;
                settings.ProgressBarValue = progressBar.Value;
                settings.ProgressBarState = progressBar.State;
            }

            if (HelpInvoked != null) settings.InvokeHelp = true;
        }

        // Here we walk our controls collection and 
        // sort the various controls by type.         
        private void SortDialogControls()
        {
            foreach (TaskDialogControl control in Controls)
            {
                var buttonBase = control as TaskDialogButtonBase;
                var commandLink = control as TaskDialogCommandLink;

                if (buttonBase != null && string.IsNullOrEmpty(buttonBase.Text) &&
                    commandLink != null && string.IsNullOrEmpty(commandLink.Instruction))

                    throw new InvalidOperationException(LocalizedMessages.TaskDialogButtonTextEmpty);

                // Loop through child controls 
                // and sort the controls based on type.
                if (commandLink != null)

                    commandLinks.Add(commandLink);

                else if (control is TaskDialogRadioButton radButton)

                    (radioButtons
#if CS8
                        ??=
#else
                        ?? (radioButtons =
#endif
                        new List<TaskDialogButtonBase>()
#if !CS8
                        )
#endif
                        ).Add(radButton);

                else if (buttonBase != null)

                    (buttons
#if CS8
                        ??=
#else
                        ?? (buttons =
#endif
                        new List<TaskDialogButtonBase>()
#if !CS8
                        )
#endif
                        ).Add(buttonBase);

                else progressBar = control is TaskDialogProgressBar progBar
                    ? progBar
                    : throw new InvalidOperationException(LocalizedMessages.TaskDialogUnkownControl);
            }
        }
        #endregion

        #region Helpers
        // Helper to map the standard button IDs returned by 
        // TaskDialogIndirect to the standard button ID enum - 
        // note that we can't just cast, as the Win32
        // typedefs differ incoming and outgoing.

        private static TaskDialogStandardButtons MapButtonIdToStandardButton(in int id)
#if CS8
         =>
#else
        {
            switch (
#endif
            (Win32Native.Dialogs.TaskDialog.TaskDialogCommonButtonReturnIds)id
#if CS8
            switch
#else
            )
#endif
            {
#if !CS8
                case
#endif
                Ok
#if CS8
                =>
#else
                :
                    return
#endif
                TaskDialogStandardButtons.Ok
#if CS8
                ,
#else
                ;
                case
#endif
                Cancel
#if CS8
                =>
#else
                :
                    return
#endif
                TaskDialogStandardButtons.Cancel
#if CS8
                ,
#else
                ;
                case
#endif
                Abort
#if CS8
                =>
#else
                :
                    return
#endif
                TaskDialogStandardButtons.None // Included for completeness in API -
                                               // we can't pass in an Abort standard button.
#if CS8
                ,
#else
                ;
                case
#endif
                Retry
#if CS8
                =>
#else
                :
                    return
#endif
                TaskDialogStandardButtons.Retry
#if CS8
                ,
#else
                ;
                case
#endif
                Ignore
#if CS8
                =>
#else
                :
                    return
#endif
                TaskDialogStandardButtons.None // Included for completeness in API -
                                               // we can't pass in an Ignore standard button.
#if CS8
                ,
#else
                ;
                case
#endif
                Yes
#if CS8
                =>
#else
                :
                    return
#endif
                TaskDialogStandardButtons.Yes
#if CS8
                ,
#else
                ;
                case
#endif
                No
#if CS8
                =>
#else
                :
                    return
#endif
                TaskDialogStandardButtons.No
#if CS8
                ,
#else
                ;
                case
#endif
                Win32Native.Dialogs.TaskDialog.TaskDialogCommonButtonReturnIds.Close
#if CS8
                =>
#else
                :
                    return
#endif
                TaskDialogStandardButtons.Close
#if CS8
                ,
                _ =>
#else
                ;
                default:
                    return
#endif
                TaskDialogStandardButtons.None
#if CS8
            };
#else
                ;
            }
        }
#endif

        private void UpdateValue<T>(ref T value, in T newValue, ActionIn<T> action)
        {
            value = newValue;

            if (NativeDialogShowing)

                action(newValue);
        }

        private void UpdateValue<T>(ref T value, in T newValue, in string errorMessage)
        {
            ThrowIfDialogShowing(errorMessage);
            value = newValue;
        }

        private void ThrowIfDialogShowing(string message)
        {
            if (NativeDialogShowing) throw new NotSupportedException(message);
        }

        private bool NativeDialogShowing => (_nativeDialog != null)
                    && (_nativeDialog.ShowState == DialogShowState.Showing
                    || _nativeDialog.ShowState == DialogShowState.Closing);

        // NOTE: we are going to require names be unique 
        // across both buttons and radio buttons,
        // even though the Win32 API allows them to be separate.
        private TaskDialogButtonBase GetButtonForId(int id) => (TaskDialogButtonBase)Controls.GetControlbyId(id);
        #endregion

        #region IDialogControlHost Members
        // We're explicitly implementing this interface 
        // as the user will never need to know about it
        // or use it directly - it is only for the internal 
        // implementation of "pseudo controls" within 
        // the dialogs.

        // Called whenever controls are being added 
        // to or removed from the dialog control collection.
        bool IDialogControlHost.IsCollectionChangeAllowed() =>
            // Only allow additions to collection if dialog is NOT showing.
            !NativeDialogShowing;

        // Called whenever controls have been added or removed.
        void IDialogControlHost.ApplyCollectionChanged() =>
            // If we're showing, we should never get here - 
            // the changing notification would have thrown and the 
            // property would not have been changed.
            Debug.Assert(!NativeDialogShowing,
                "Collection changed notification received despite show state of dialog");

        // Called when a control currently in the collection 
        // has a property changing - this is 
        // basically to screen out property changes that 
        // cannot occur while the dialog is showing
        // because the Win32 API has no way for us to 
        // propagate the changes until we re-invoke the Win32 call.
        bool IDialogControlHost.IsControlPropertyChangeAllowed(in string propertyName, in DialogControl control)
        {
            Debug.Assert(control is TaskDialogControl,
                "Property changing for a control that is not a TaskDialogControl-derived type");
            Debug.Assert(propertyName != "Name",
                "Name changes at any time are not supported - public API should have blocked this");

            bool canChange = false;

            if (!NativeDialogShowing)

                // Certain properties can't be changed if the dialog is not showing
                // we need a handle created before we can set these...
                canChange = propertyName != "Enabled";

            else

                // If the dialog is showing, we can only 
                // allow some properties to change.
                switch (propertyName)
                {
                    // Properties that CAN'T be changed while dialog is showing.
                    case "Text":
                    case "Default":
                        canChange = false;
                        break;

                    // Properties that CAN be changed while dialog is showing.
                    case "ShowElevationIcon":
                    case "Enabled":
                        canChange = true;
                        break;
                    default:
                        Debug.Assert(true, "Unknown property name coming through property changing handler");
                        break;
                }

            return canChange;
        }

        // Called when a control currently in the collection 
        // has a property changed - this handles propagating
        // the new property values to the Win32 API. 
        // If there isn't a way to change the Win32 value, then we
        // should have already screened out the property set 
        // in NotifyControlPropertyChanging.        
        void IDialogControlHost.ApplyControlPropertyChange(in string propertyName, in DialogControl control)
        {
            // We only need to apply changes to the 
            // native dialog when it actually exists.
            if (NativeDialogShowing)

                if (control is TaskDialogProgressBar)
                {
                    if (!progressBar.HasValidValues)

                        throw new ArgumentException(LocalizedMessages.TaskDialogProgressBarValueInRange);

                    switch (propertyName)
                    {
                        case "State":
                            _nativeDialog.UpdateProgressBarState(progressBar.State);
                            break;
                        case "Value":
                            _nativeDialog.UpdateProgressBarValue(progressBar.Value);
                            break;
                        case "Minimum":
                        case "Maximum":
                            _nativeDialog.UpdateProgressBarRange();
                            break;
                        default:
                            Debug.Assert(true, "Unknown property being set");
                            break;
                    }
                }
                else if (control is TaskDialogButton button)

                    switch (propertyName)
                    {
                        case "ShowElevationIcon":
                            _nativeDialog.UpdateElevationIcon(button.Id, button.UseElevationIcon);
                            break;
                        case "Enabled":
                            _nativeDialog.UpdateButtonEnabled(button.Id, button.Enabled);
                            break;
                        default:
                            Debug.Assert(true, "Unknown property being set");
                            break;
                    }

                else if (control is TaskDialogRadioButton radioButton)

                    switch (propertyName)
                    {
                        case "Enabled":
                            _nativeDialog.UpdateRadioButtonEnabled(radioButton.Id, radioButton.Enabled);
                            break;
                        default:
                            Debug.Assert(true, "Unknown property being set");
                            break;
                    }

                else

                    // Do nothing with property change - 
                    // note that this shouldn't ever happen, we should have
                    // either thrown on the changing event, or we handle above.
                    Debug.Assert(true, "Control property changed notification not handled properly - being ignored");
        }
        #endregion

        #region Event Percolation Methods
        // All Raise*() methods are called by the 
        // NativeTaskDialog when various pseudo-controls
        // are triggered.
        internal void RaiseButtonClickEvent(in int id) =>
            // First check to see if the ID matches a custom button.

            // If a custom button was found, 
            // raise the event - if not, it's a standard button, and
            // we don't support custom event handling for the standard buttons
            GetButtonForId(id)?.RaiseClickEvent();

        internal void RaiseHyperlinkClickEvent(in string link) => HyperlinkClick?.Invoke(this, new TaskDialogHyperlinkClickedEventArgs(link));

        // Gives event subscriber a chance to prevent 
        // the dialog from closing, based on 
        // the current state of the app and the button 
        // used to commit. Note that we don't 
        // have full access at this stage to 
        // the full dialog state.
        internal int RaiseClosingEvent(in int id)
        {
            System.EventHandler<TaskDialogClosingEventArgs> handler = Closing;

            if (handler != null)
            {
                TaskDialogButtonBase customButton = null;
                var e = new TaskDialogClosingEventArgs();

                // Try to identify the button - is it a standard one?
                TaskDialogStandardButtons buttonClicked = MapButtonIdToStandardButton(id);

                // If not, it had better be a custom button...
                if (buttonClicked == TaskDialogStandardButtons.None)
                {
                    customButton = GetButtonForId(id);

                    // ... or we have a problem.
                    if (customButton == null)

                        throw new InvalidOperationException(LocalizedMessages.TaskDialogBadButtonId);

                    e.CustomButton = customButton.Name;
                    e.TaskDialogResult = TaskDialogResult.CustomButtonClicked;
                }

                else

                    e.TaskDialogResult = (TaskDialogResult)buttonClicked;

                // Raise the event and determine how to proceed.
                handler(this, e);

                if (e.Cancel) return (int)HResult.False;
            }

            // It's okay to let the dialog close.
            return (int)HResult.Ok;
        }

        internal void RaiseHelpInvokedEvent() => HelpInvoked?.Invoke(this, EventArgs.Empty);

        internal void RaiseOpenedEvent() => Opened?.Invoke(this, EventArgs.Empty);

        internal void RaiseTickEvent(in int ticks) => Tick?.Invoke(this, new TaskDialogTickEventArgs(ticks));
        #endregion

        #region Cleanup Code
        // Cleans up data and structs from a single 
        // native dialog Show() invocation.
        private void CleanUp()
        {
            // Reset values that would be considered 
            // 'volatile' in a given instance.
            progressBar?.Reset();

            // Clean out sorted control lists - 
            // though we don't of course clear the main controls collection,
            // so the controls are still around; we'll 
            // resort on next show, since the collection may have changed.
            buttons?.Clear();
            commandLinks?.Clear();
            radioButtons?.Clear();
            progressBar = null;

            // Have the native dialog clean up the rest.
            _nativeDialog?.Dispose();
        }

        // Dispose pattern - cleans up data and structs for 
        // a) any native dialog currently showing, and
        // b) anything else that the outer TaskDialog has.
        public bool IsDisposed { get; private set; }

        /// <summary>
        /// Dispose TaskDialog Resources
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// TaskDialog Finalizer
        /// </summary>
        ~TaskDialog() => Dispose(false);

        /// <summary>
        /// Dispose TaskDialog Resources
        /// </summary>
        /// <param name="disposing">If true, indicates that this is being called via Dispose rather than via the finalizer.</param>
        public void Dispose(bool disposing)
        {
            if (!IsDisposed)
            {
                IsDisposed = true;

                if (disposing)
                {
                    // Clean up managed resources.
                    if (_nativeDialog != null && _nativeDialog.ShowState == DialogShowState.Showing)

                        _nativeDialog.NativeClose(TaskDialogResult.Cancel);

                    buttons = null;
                    radioButtons = null;
                    commandLinks = null;
                }

                // Clean up unmanaged resources SECOND, NTD counts on 
                // being closed before being disposed.
                if (_nativeDialog != null)
                {
                    _nativeDialog.Dispose();
                    _nativeDialog = null;
                }

                if (_staticDialog != null)
                {
                    _staticDialog.Dispose();
                    _staticDialog = null;
                }
            }
        }
        #endregion

        /// <summary>
        /// Indicates whether this feature is supported on the current platform.
        /// </summary>
        public static bool IsPlatformSupported =>
                // We need Windows Vista onwards ...
                CoreHelpers.RunningOnVista;
    }
}
