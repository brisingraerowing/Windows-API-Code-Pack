﻿//Copyright (c) Microsoft Corporation.  All rights reserved.  Distributed under the Microsoft Public License (MS-PL)

using System;
using System.Runtime.InteropServices;

using static Microsoft.WindowsAPICodePack.NativeAPI.Consts.Common;

namespace Microsoft.WindowsAPICodePack.Win32Native.Dialogs
{

    /// <summary>
    /// public class containing most native interop declarations used
    /// throughout the library.
    /// Functions that are not performance intensive belong in this class.
    /// </summary>
    public static class TaskDialog
    {
        #region TaskDialog Definitions

        [DllImport("Comctl32.dll", SetLastError = true)]
        public static extern HResult TaskDialogIndirect(
            [In] TaskDialogConfiguration taskConfig,
            [Out] out int button,
            [Out] out int radioButton,
            [MarshalAs(UnmanagedType.Bool), Out] out bool verificationFlagChecked);

        // Main task dialog configuration struct.
        // NOTE: Packing must be set to 4 to make this work on 64-bit platforms.
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto, Pack = 4)]
        public class TaskDialogConfiguration
        {
            public uint size;
            public IntPtr parentHandle;
            public IntPtr instance;
            public TaskDialogOptions taskDialogFlags;
            public TaskDialogCommonButtons commonButtons;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string windowTitle;
            public IconUnion mainIcon; // NOTE: 32-bit union field, holds pszMainIcon as well
            [MarshalAs(UnmanagedType.LPWStr)]
            public string mainInstruction;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string content;
            public uint buttonCount;
            public IntPtr buttons;           // Ptr to TASKDIALOG_BUTTON structs
            public int defaultButtonIndex;
            public uint radioButtonCount;
            public IntPtr radioButtons;      // Ptr to TASKDIALOG_BUTTON structs
            public int defaultRadioButtonIndex;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string verificationText;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string expandedInformation;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string expandedControlText;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string collapsedControlText;
            public IconUnion footerIcon;  // NOTE: 32-bit union field, holds pszFooterIcon as well
            [MarshalAs(UnmanagedType.LPWStr)]
            public string footerText;
            public TaskDialogCallback callback;
            public IntPtr callbackData;
            public uint width;
        }

        public const int TaskDialogIdealWidth = 0;  // Value for TASKDIALOGCONFIG.cxWidth
        public const int TaskDialogButtonShieldIcon = 1;

        // NOTE: We include a "spacer" so that the struct size varies on 
        // 64-bit architectures.
        [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Auto)]
        public struct IconUnion
        {
            public IconUnion(int i) => mainIcon = new IntPtr(i);

            [FieldOffset(0)]
            private readonly IntPtr mainIcon;

            /// <summary>
            /// Gets the handle to the Icon
            /// </summary>
            public IntPtr MainIcon => mainIcon;
        }

        // NOTE: Packing must be set to 4 to make this work on 64-bit platforms.
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto, Pack = 4)]
        public struct TaskDialogButton
        {
            public TaskDialogButton(int buttonId, string text)
            {
                this.buttonId = buttonId;
                buttonText = text;
            }

            public int buttonId;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string buttonText;
        }

        // Task Dialog - identifies common buttons.
        [Flags]
        public enum TaskDialogCommonButtons
        {
            Ok = 0x0001, // selected control return value IDOK
            Yes = 0x0002, // selected control return value IDYES
            No = 0x0004, // selected control return value IDNO
            Cancel = 0x0008, // selected control return value IDCANCEL
            Retry = 0x0010, // selected control return value IDRETRY
            Close = 0x0020  // selected control return value IDCLOSE
        }

        // Identify button *return values* - note that, unfortunately, these are different
        // from the inbound button values.
        public enum TaskDialogCommonButtonReturnIds
        {
            Ok = 1,
            Cancel = 2,
            Abort = 3,
            Retry = 4,
            Ignore = 5,
            Yes = 6,
            No = 7,
            Close = 8
        }

        public enum TaskDialogElements
        {
            Content,
            ExpandedInformation,
            Footer,
            MainInstruction
        }

        public enum TaskDialogIconElement
        {
            Main,
            Footer
        }

        // Task Dialog - flags
        [Flags]
        public enum TaskDialogOptions
        {
            None = 0,
            EnableHyperlinks = 0x0001,
            UseMainIcon = 0x0002,
            UseFooterIcon = 0x0004,
            AllowCancel = 0x0008,
            UseCommandLinks = 0x0010,
            UseNoIconCommandLinks = 0x0020,
            ExpandFooterArea = 0x0040,
            ExpandedByDefault = 0x0080,
            CheckVerificationFlag = 0x0100,
            ShowProgressBar = 0x0200,
            ShowMarqueeProgressBar = 0x0400,
            UseCallbackTimer = 0x0800,
            PositionRelativeToWindow = 0x1000,
            RightToLeftLayout = 0x2000,
            NoDefaultRadioButton = 0x4000
        }

        public enum TaskDialogMessages
        {
            NavigatePage = UserMessage + 101,
            ClickButton = UserMessage + 102, // wParam = Button ID
            SetMarqueeProgressBar = UserMessage + 103, // wParam = 0 (nonMarque) wParam != 0 (Marquee)
            SetProgressBarState = UserMessage + 104, // wParam = new progress state
            SetProgressBarRange = UserMessage + 105, // lParam = MAKELPARAM(nMinRange, nMaxRange)
            SetProgressBarPosition = UserMessage + 106, // wParam = new position
            SetProgressBarMarquee = UserMessage + 107, // wParam = 0 (stop marquee), wParam != 0 (start marquee), lparam = speed (milliseconds between repaints)
            SetElementText = UserMessage + 108, // wParam = element (TASKDIALOG_ELEMENTS), lParam = new element text (LPCWSTR)
            ClickRadioButton = UserMessage + 110, // wParam = Radio Button ID
            EnableButton = UserMessage + 111, // lParam = 0 (disable), lParam != 0 (enable), wParam = Button ID
            EnableRadioButton = UserMessage + 112, // lParam = 0 (disable), lParam != 0 (enable), wParam = Radio Button ID
            ClickVerification = UserMessage + 113, // wParam = 0 (unchecked), 1 (checked), lParam = 1 (set key focus)
            UpdateElementText = UserMessage + 114, // wParam = element (TASKDIALOG_ELEMENTS), lParam = new element text (LPCWSTR)
            SetButtonElevationRequiredState = UserMessage + 115, // wParam = Button ID, lParam = 0 (elevation not required), lParam != 0 (elevation required)
            UpdateIcon = UserMessage + 116  // wParam = icon element (TASKDIALOG_ICON_ELEMENTS), lParam = new icon (hIcon if TDF_USE_HICON_* was set, PCWSTR otherwise)
        }

        public enum TaskDialogNotifications
        {
            Created = 0,
            Navigated = 1,
            ButtonClicked = 2,            // wParam = Button ID
            HyperlinkClicked = 3,         // lParam = (LPCWSTR)pszHREF
            Timer = 4,                     // wParam = Milliseconds since dialog created or timer reset
            Destroyed = 5,
            RadioButtonClicked = 6,      // wParam = Radio Button ID
            Constructed = 7,
            VerificationClicked = 8,      // wParam = 1 if checkbox checked, 0 if not, lParam is unused and always 0
            Help = 9,
            ExpandButtonClicked = 10    // wParam = 0 (dialog is now collapsed), wParam != 0 (dialog is now expanded)
        }

        // Used in the various SET_DEFAULT* TaskDialog messages
        public const int NoDefaultButtonSpecified = 0;

        // Task Dialog config and related structs (for TaskDialogIndirect())
        public delegate int TaskDialogCallback(
            IntPtr hwnd,
            uint message,
            IntPtr wparam,
            IntPtr lparam,
            IntPtr referenceData);

        public enum ProgressBarState
        {
            Normal = 0x0001,
            Error = 0x0002,
            Paused = 0x0003
        }

        public enum TaskDialogIcons
        {
            Warning = 65535,
            Error = 65534,
            Information = 65533,
            Shield = 65532
        }

        #endregion
    }
}
