//Copyright (c) Microsoft Corporation.  All rights reserved.

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Microsoft.WindowsAPICodePack.Resources;
using Microsoft.WindowsAPICodePack.Win32Native;
using Microsoft.WindowsAPICodePack.Win32Native.Dialogs;

namespace Microsoft.WindowsAPICodePack.Dialogs
{
    /// <summary>
    /// Encapsulates the native logic required to create, 
    /// configure, and show a TaskDialog, 
    /// via the TaskDialogIndirect() Win32 function.
    /// </summary>
    /// <remarks>A new instance of this class should 
    /// be created for each messagebox show, as
    /// the HWNDs for TaskDialogs do not remain constant 
    /// across calls to TaskDialogIndirect.
    /// </remarks>
    internal class NativeTaskDialog : IDisposable
    {
        private readonly Win32Native.Dialogs.TaskDialog.TaskDialogConfiguration nativeDialogConfig;
        private readonly NativeTaskDialogSettings settings;
        private IntPtr hWndDialog;
        private readonly TaskDialog outerDialog;

        private readonly IntPtr[] updatedStrings = new IntPtr[Enum.GetNames(typeof(Win32Native.Dialogs.TaskDialog.TaskDialogElements)).Length];
        private IntPtr buttonArray, radioButtonArray;

        // Flag tracks whether our first radio 
        // button click event has come through.
        private bool firstRadioButtonClicked = true;

        #region Constructors

        // Configuration is applied at dialog creation time.
        internal NativeTaskDialog(in NativeTaskDialogSettings settings, in TaskDialog outerDialog)
        {
            nativeDialogConfig = settings.NativeConfiguration;
            this.settings = settings;

            // Wireup dialog proc message loop for this instance.
            nativeDialogConfig.callback = new Win32Native.Dialogs.TaskDialog.TaskDialogCallback(DialogProc);

            ShowState = DialogShowState.PreShow;

            // Keep a reference to the outer shell, so we can notify.
            this.outerDialog = outerDialog;
        }

        #endregion

        #region Public Properties

        public DialogShowState ShowState { get; private set; }

        public int SelectedButtonId { get; private set; }

        public int SelectedRadioButtonId { get; private set; }

        public bool CheckBoxChecked { get; private set; }

        #endregion

        internal void NativeShow()
        {
            // Applies config struct and other settings, then
            // calls main Win32 function.
            if (settings == null)

                throw new InvalidOperationException(LocalizedMessages.NativeTaskDialogConfigurationError);

            // Do a last-minute parse of the various dialog control lists,  
            // and only allocate the memory at the last minute.

            MarshalDialogControlStructs();

            // Make the call and show the dialog.
            // NOTE: this call is BLOCKING, though the thread 
            // WILL re-enter via the DialogProc.
            try
            {
                ShowState = DialogShowState.Showing;

                // Here is the way we use "vanilla" P/Invoke to call TaskDialogIndirect().  
                HResult hresult = Win32Native.Dialogs.TaskDialog.TaskDialogIndirect(
                    nativeDialogConfig,
                    out int selectedButtonId,
                    out int selectedRadioButtonId,
                    out bool checkBoxChecked);

                if (CoreErrorHelper.Failed(hresult))
                {
#if CS7


                    string msg;
                    switch (hresult)
                    {
                        case HResult.InvalidArguments:
                            msg = LocalizedMessages.NativeTaskDialogInternalErrorArgs;
                            break;
                        case HResult.OutOfMemory:
                            msg = LocalizedMessages.NativeTaskDialogInternalErrorComplex;
                            break;
                        default:
                            msg = string.Format(System.Globalization.CultureInfo.InvariantCulture,
                                LocalizedMessages.NativeTaskDialogInternalErrorUnexpected,
                                hresult);
                            break;
                    }

#else
                    string msg = hresult switch
                    {
                        HResult.InvalidArguments => LocalizedMessages.NativeTaskDialogInternalErrorArgs,
                        HResult.OutOfMemory => LocalizedMessages.NativeTaskDialogInternalErrorComplex,
                        _ => string.Format(System.Globalization.CultureInfo.InvariantCulture,
LocalizedMessages.NativeTaskDialogInternalErrorUnexpected,
hresult),
                    };
#endif
                    throw new Win32Exception(msg, Marshal.GetExceptionForHR((int)hresult));
                }

                SelectedButtonId = selectedButtonId;
                SelectedRadioButtonId = selectedRadioButtonId;
                CheckBoxChecked = checkBoxChecked;
            }
            catch (EntryPointNotFoundException exc)
            {
                throw new NotSupportedException(LocalizedMessages.NativeTaskDialogVersionError, exc);
            }
            finally
            {
                ShowState = DialogShowState.Closed;
            }
        }

        // The new task dialog does not support the existing 
        // Win32 functions for closing (e.g. EndDialog()); instead,
        // a "click button" message is sent. In this case, we're 
        // abstracting out to say that the TaskDialog consumer can
        // simply call "Close" and we'll "click" the cancel button. 
        // Note that the cancel button doesn't actually
        // have to exist for this to work.
        internal void NativeClose(in TaskDialogResult result)
        {
            ShowState = DialogShowState.Closing;
#if CS7

            int id;
            switch (result)
            {
                case TaskDialogResult.Close:
                    id = (int)Win32Native.Dialogs.TaskDialog.TaskDialogCommonButtonReturnIds.Close;
                    break;
                case TaskDialogResult.CustomButtonClicked:
                    id = DialogsDefaults.MinimumDialogControlId; // custom buttons
                    break;
                case TaskDialogResult.No:
                    id = (int)Win32Native.Dialogs.TaskDialog.TaskDialogCommonButtonReturnIds.No;
                    break;
                case TaskDialogResult.Ok:
                    id = (int)Win32Native.Dialogs.TaskDialog.TaskDialogCommonButtonReturnIds.Ok;
                    break;
                case TaskDialogResult.Retry:
                    id = (int)Win32Native.Dialogs.TaskDialog.TaskDialogCommonButtonReturnIds.Retry;
                    break;
                case TaskDialogResult.Yes:
                    id = (int)Win32Native.Dialogs.TaskDialog.TaskDialogCommonButtonReturnIds.Yes;
                    break;
                default:
                    id = (int)Win32Native.Dialogs.TaskDialog.TaskDialogCommonButtonReturnIds.Cancel;
                    break;
            }

#else
            int id = result switch
            {
                TaskDialogResult.Close => (int)Win32Native.Dialogs.TaskDialog.TaskDialogCommonButtonReturnIds.Close,
                TaskDialogResult.CustomButtonClicked => DialogsDefaults.MinimumDialogControlId,// custom buttons
                TaskDialogResult.No => (int)Win32Native.Dialogs.TaskDialog.TaskDialogCommonButtonReturnIds.No,
                TaskDialogResult.Ok => (int)Win32Native.Dialogs.TaskDialog.TaskDialogCommonButtonReturnIds.Ok,
                TaskDialogResult.Retry => (int)Win32Native.Dialogs.TaskDialog.TaskDialogCommonButtonReturnIds.Retry,
                TaskDialogResult.Yes => (int)Win32Native.Dialogs.TaskDialog.TaskDialogCommonButtonReturnIds.Yes,
                _ => (int)Win32Native.Dialogs.TaskDialog.TaskDialogCommonButtonReturnIds.Cancel,
            };
#endif
            _ = SendMessageHelper(Win32Native.Dialogs.TaskDialog.TaskDialogMessages.ClickButton, id, 0);
        }

        #region Main Dialog Proc

        private int DialogProc(
            IntPtr windowHandle,
            uint message,
            IntPtr wparam,
            IntPtr lparam,
            IntPtr referenceData)
        {
            // Fetch the HWND - it may be the first time we're getting it.
            hWndDialog = windowHandle;

            // Big switch on the various notifications the 
            // dialog proc can get.
            switch ((Win32Native.Dialogs.TaskDialog.TaskDialogNotifications)message)
            {
                case Win32Native.Dialogs.TaskDialog.TaskDialogNotifications.Created:
                    int result = PerformDialogInitialization();
                    outerDialog.RaiseOpenedEvent();
                    return result;
                case Win32Native.Dialogs.TaskDialog.TaskDialogNotifications.ButtonClicked:
                    return HandleButtonClick((int)wparam);
                case Win32Native.Dialogs.TaskDialog.TaskDialogNotifications.RadioButtonClicked:
                    return HandleRadioButtonClick((int)wparam);
                case Win32Native.Dialogs.TaskDialog.TaskDialogNotifications.HyperlinkClicked:
                    return HandleHyperlinkClick(lparam);
                case Win32Native.Dialogs.TaskDialog.TaskDialogNotifications.Help:
                    return HandleHelpInvocation();
                case Win32Native.Dialogs.TaskDialog.TaskDialogNotifications.Timer:
                    return HandleTick((int)wparam);
                case Win32Native.Dialogs.TaskDialog.TaskDialogNotifications.Destroyed:
                    return PerformDialogCleanup();
                default:
                    break;
            }
            return (int)HResult.Ok;
        }

        // Once the task dialog HWND is open, we need to send 
        // additional messages to configure it.
        private int PerformDialogInitialization()
        {
            // Initialize Progress or Marquee Bar.
            if (IsOptionSet(Win32Native.Dialogs.TaskDialog.TaskDialogOptions.ShowProgressBar))
            {
                UpdateProgressBarRange();

                // The order of the following is important - 
                // state is more important than value, 
                // and non-normal states turn off the bar value change 
                // animation, which is likely the intended
                // and preferable behavior.
                UpdateProgressBarState(settings.ProgressBarState);
                UpdateProgressBarValue(settings.ProgressBarValue);

                // Due to a bug that wasn't fixed in time for RTM of Vista,
                // second SendMessage is required if the state is non-Normal.
                UpdateProgressBarValue(settings.ProgressBarValue);
            }
            else if (IsOptionSet(Win32Native.Dialogs.TaskDialog.TaskDialogOptions.ShowMarqueeProgressBar))
            {
                // TDM_SET_PROGRESS_BAR_MARQUEE is necessary 
                // to cause the marquee to start animating.
                // Note that this internal task dialog setting is 
                // round-tripped when the marquee is
                // is set to different states, so it never has to 
                // be touched/sent again.
                _ = SendMessageHelper(Win32Native.Dialogs.TaskDialog.TaskDialogMessages.SetProgressBarMarquee, 1, 0);
                UpdateProgressBarState(settings.ProgressBarState);
            }

            if (settings.ElevatedButtons != null && settings.ElevatedButtons.Count > 0)

                foreach (int id in settings.ElevatedButtons)

                    UpdateElevationIcon(id, true);

            return CoreErrorHelper.Ignored;
        }

        private int HandleButtonClick(int id)
        {
            // First we raise a Click event, if there is a custom button
            // However, we implement Close() by sending a cancel button, so 
            // we don't want to raise a click event in response to that.
            if (ShowState != DialogShowState.Closing)

                outerDialog.RaiseButtonClickEvent(id);

            // Once that returns, we raise a Closing event for the dialog
            // The Win32 API handles button clicking-and-closing 
            // as an atomic action,
            // but it is more .NET friendly to split them up.
            // Unfortunately, we do NOT have the return values at this stage.
            if (id < DialogsDefaults.MinimumDialogControlId)

                return outerDialog.RaiseClosingEvent(id);

            // https://msdn.microsoft.com/en-us/library/windows/desktop/bb760542(v=vs.85).aspx
            // The return value is specific to the notification being processed.
            // When responding to a button click, your implementation should return S_FALSE
            // if the Task Dialog is not to close. Otherwise return S_OK.
            return ShowState == DialogShowState.Closing ? (int)HResult.Ok : (int)HResult.False;
        }

        private int HandleRadioButtonClick(int id)
        {
            // When the dialog sets the radio button to default, 
            // it (somewhat confusingly)issues a radio button clicked event
            //  - we mask that out - though ONLY if
            // we do have a default radio button
            if (firstRadioButtonClicked
                && !IsOptionSet(Win32Native.Dialogs.TaskDialog.TaskDialogOptions.NoDefaultRadioButton))

                firstRadioButtonClicked = false;

            else

                outerDialog.RaiseButtonClickEvent(id);

            // Note: we don't raise Closing, as radio 
            // buttons are non-committing buttons
            return CoreErrorHelper.Ignored;
        }

        private int HandleHyperlinkClick(IntPtr href)
        {
            string link = Marshal.PtrToStringUni(href);
            outerDialog.RaiseHyperlinkClickEvent(link);

            return CoreErrorHelper.Ignored;
        }


        private int HandleTick(int ticks)
        {
            outerDialog.RaiseTickEvent(ticks);
            return CoreErrorHelper.Ignored;
        }

        private int HandleHelpInvocation()
        {
            outerDialog.RaiseHelpInvokedEvent();
            return CoreErrorHelper.Ignored;
        }

        // There should be little we need to do here, 
        // as the use of the NativeTaskDialog is
        // that it is instantiated for a single show, then disposed of.
        private int PerformDialogCleanup()
        {
            firstRadioButtonClicked = true;

            return CoreErrorHelper.Ignored;
        }

        #endregion

        #region Update members

        internal void UpdateProgressBarValue(int i)
        {
            AssertCurrentlyShowing();
            _ = SendMessageHelper(Win32Native.Dialogs.TaskDialog.TaskDialogMessages.SetProgressBarPosition, i, 0);
        }

        internal void UpdateProgressBarRange()
        {
            AssertCurrentlyShowing();

            // Build range LPARAM - note it is in REVERSE intuitive order.
            long range = MakeLongLParam(
                settings.ProgressBarMaximum,
                settings.ProgressBarMinimum);

            _ = SendMessageHelper(Win32Native.Dialogs.TaskDialog.TaskDialogMessages.SetProgressBarRange, 0, range);
        }

        internal void UpdateProgressBarState(TaskDialogProgressBarState state)
        {
            AssertCurrentlyShowing();
            _ = SendMessageHelper(Win32Native.Dialogs.TaskDialog.TaskDialogMessages.SetProgressBarState, (int)state, 0);
        }

        internal void UpdateText(in string text) => UpdateTextCore(text, Win32Native.Dialogs.TaskDialog.TaskDialogElements.Content);

        internal void UpdateInstruction(in string instruction) => UpdateTextCore(instruction, Win32Native.Dialogs.TaskDialog.TaskDialogElements.MainInstruction);

        internal void UpdateFooterText(in string footerText) => UpdateTextCore(footerText, Win32Native.Dialogs.TaskDialog.TaskDialogElements.Footer);

        internal void UpdateExpandedText(in string expandedText) => UpdateTextCore(expandedText, Win32Native.Dialogs.TaskDialog.TaskDialogElements.ExpandedInformation);

        private void UpdateTextCore(in string s, in Win32Native.Dialogs.TaskDialog.TaskDialogElements element)
        {
            AssertCurrentlyShowing();

            FreeOldString(element);
            _ = SendMessageHelper(
                Win32Native.Dialogs.TaskDialog.TaskDialogMessages.SetElementText,
                (int)element,
                (long)MakeNewString(s, element));
        }

        internal void UpdateMainIcon(in TaskDialogStandardIcon mainIcon) => UpdateIconCore(mainIcon, Win32Native.Dialogs.TaskDialog.TaskDialogIconElement.Main);

        internal void UpdateFooterIcon(in TaskDialogStandardIcon footerIcon) => UpdateIconCore(footerIcon, Win32Native.Dialogs.TaskDialog.TaskDialogIconElement.Footer);

        private void UpdateIconCore(in TaskDialogStandardIcon icon, in Win32Native.Dialogs.TaskDialog.TaskDialogIconElement element)
        {
            AssertCurrentlyShowing();
            _ = SendMessageHelper(
                Win32Native.Dialogs.TaskDialog.TaskDialogMessages.UpdateIcon,
                (int)element,
                (long)icon);
        }

        internal void UpdateCheckBoxChecked(in bool cbc)
        {
            AssertCurrentlyShowing();
            _ = SendMessageHelper(
                Win32Native.Dialogs.TaskDialog.TaskDialogMessages.ClickVerification,
                cbc ? 1 : 0,
                1);
        }

        internal void UpdateElevationIcon(in int buttonId, in bool showIcon)
        {
            AssertCurrentlyShowing();
            _ = SendMessageHelper(
                Win32Native.Dialogs.TaskDialog.TaskDialogMessages.SetButtonElevationRequiredState,
                buttonId,
                Convert.ToInt32(showIcon));
        }

        internal void UpdateButtonEnabled(in int buttonID, in bool enabled)
        {
            AssertCurrentlyShowing();
            _ = SendMessageHelper(
                Win32Native.Dialogs.TaskDialog.TaskDialogMessages.EnableButton, buttonID, enabled == true ? 1 : 0);
        }

        internal void UpdateRadioButtonEnabled(in int buttonID, in bool enabled)
        {
            AssertCurrentlyShowing();
            _ = SendMessageHelper(Win32Native.Dialogs.TaskDialog.TaskDialogMessages.EnableRadioButton,
                buttonID, enabled == true ? 1 : 0);
        }

        internal void AssertCurrentlyShowing() => Debug.Assert(ShowState == DialogShowState.Showing,
                "Update*() methods should only be called while native dialog is showing");

        #endregion

        #region Helpers

        private int SendMessageHelper(in Win32Native.Dialogs.TaskDialog.TaskDialogMessages message, in int wparam, in long lparam)
        {
            // Be sure to at least assert here - 
            // messages to invalid handles often just disappear silently
            Debug.Assert(hWndDialog != null, "HWND for dialog is null during SendMessage");

            return (int)Core.SendMessage(
                hWndDialog,
                (uint)message,
                (IntPtr)wparam,
                new IntPtr(lparam));
        }

        private bool IsOptionSet(in Win32Native.Dialogs.TaskDialog.TaskDialogOptions flag) => (nativeDialogConfig.taskDialogFlags & flag) == flag;

        // Allocates a new string on the unmanaged heap, 
        // and stores the pointer so we can free it later.

        private IntPtr MakeNewString(in string text, in Win32Native.Dialogs.TaskDialog.TaskDialogElements element)
        {
            IntPtr newStringPtr = Marshal.StringToHGlobalUni(text);
            updatedStrings[(int)element] = newStringPtr;
            return newStringPtr;
        }

        // Checks to see if the given element already has an 
        // updated string, and if so, 
        // frees it. This is done in preparation for a call to 
        // MakeNewString(), to prevent
        // leaks from multiple updates calls on the same element 
        // within a single native dialog lifetime.
        private void FreeOldString(in Win32Native.Dialogs.TaskDialog.TaskDialogElements element)
        {
            int elementIndex = (int)element;
            if (updatedStrings[elementIndex] != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(updatedStrings[elementIndex]);
                updatedStrings[elementIndex] = IntPtr.Zero;
            }
        }

        // Based on the following defines in WinDef.h and WinUser.h:
        // #define MAKELPARAM(l, h) ((LPARAM)(DWORD)MAKELONG(l, h))
        // #define MAKELONG(a, b) ((LONG)(((WORD)(((DWORD_PTR)(a)) & 0xffff)) | ((DWORD)((WORD)(((DWORD_PTR)(b)) & 0xffff))) << 16))
        private static long MakeLongLParam(in int a, in int b) => (a << 16) + b;

        // Builds the actual configuration that the 
        // NativeTaskDialog (and underlying Win32 API)
        // expects, by parsing the various control lists, 
        // marshaling to the unmanaged heap, etc.
        private void MarshalDialogControlStructs()
        {
            if (settings.Buttons != null && settings.Buttons.Length > 0)
            {
                buttonArray = AllocateAndMarshalButtons(settings.Buttons);
                settings.NativeConfiguration.buttons = buttonArray;
                settings.NativeConfiguration.buttonCount = (uint)settings.Buttons.Length;
            }

            if (settings.RadioButtons != null && settings.RadioButtons.Length > 0)
            {
                radioButtonArray = AllocateAndMarshalButtons(settings.RadioButtons);
                settings.NativeConfiguration.radioButtons = radioButtonArray;
                settings.NativeConfiguration.radioButtonCount = (uint)settings.RadioButtons.Length;
            }
        }

        private static IntPtr AllocateAndMarshalButtons(in Win32Native.Dialogs.TaskDialog.TaskDialogButton[] structs)
        {
            IntPtr initialPtr = Marshal.AllocHGlobal(
                Marshal.SizeOf(typeof(Win32Native.Dialogs.TaskDialog.TaskDialogButton)) * structs.Length);

            IntPtr currentPtr = initialPtr;
            bool is64Bit = Marshal.SizeOf(typeof(IntPtr)) == 8;
            foreach (Win32Native.Dialogs.TaskDialog.TaskDialogButton button in structs)
            {
                Marshal.StructureToPtr(button, currentPtr, false);
                currentPtr = (IntPtr)(is64Bit ? currentPtr.ToInt64() : currentPtr.ToInt32() + Marshal.SizeOf(button));
            }

            return initialPtr;
        }

        #endregion

        #region IDispose Pattern

        private bool disposed;

        // Finalizer and IDisposable implementation.

        // Core disposing logic.
        public void Dispose()
        {
            DisposeInternal();
            GC.SuppressFinalize(this);
        }

        ~NativeTaskDialog()
        {
            DisposeInternal();
        }

        internal void DisposeInternal()
        {
            if (!disposed)
            {
                disposed = true;

                // Single biggest resource - make sure the dialog 
                // itself has been instructed to close.

                if (ShowState == DialogShowState.Showing)

                    NativeClose(TaskDialogResult.Cancel);

                // Clean up custom allocated strings that were updated
                // while the dialog was showing. Note that the strings
                // passed in the initial TaskDialogIndirect call will
                // be cleaned up automagically by the default 
                // marshalling logic.

                if (updatedStrings != null)

                    for (int i = 0; i < updatedStrings.Length; i++)

                        if (updatedStrings[i] != IntPtr.Zero)
                        {
                            Marshal.FreeHGlobal(updatedStrings[i]);
                            updatedStrings[i] = IntPtr.Zero;
                        }

                // Clean up the button and radio button arrays, if any.
                if (buttonArray != IntPtr.Zero)
                {
                    Marshal.FreeHGlobal(buttonArray);
                    buttonArray = IntPtr.Zero;
                }
                if (radioButtonArray != IntPtr.Zero)
                {
                    Marshal.FreeHGlobal(radioButtonArray);
                    radioButtonArray = IntPtr.Zero;
                }

                //if (disposing)
                //{
                // Clean up managed resources - currently there are none
                // that are interesting.
                //}
            }
        }

        #endregion
    }
}
