//Copyright (c) Microsoft Corporation.  All rights reserved.

using Microsoft.WindowsAPICodePack.Resources;
using Microsoft.WindowsAPICodePack.Win32Native.Dialogs;

namespace Microsoft.WindowsAPICodePack.Dialogs
{
    internal static class DialogsDefaults
    {
        internal static string Caption => LocalizedMessages.DialogDefaultCaption;
        internal static string MainInstruction => LocalizedMessages.DialogDefaultMainInstruction;
        internal static string Content => LocalizedMessages.DialogDefaultContent;

        internal const int ProgressBarStartingValue = 0;
        internal const int ProgressBarMinimumValue = 0;
        internal const int ProgressBarMaximumValue = 100;

        internal const int IdealWidth = 0;

        // For generating control ID numbers that won't 
        // collide with the standard button return IDs.
        internal const int MinimumDialogControlId =
            (int)Win32Native.Dialogs.TaskDialog.TaskDialogCommonButtonReturnIds.Close + 1;
    }
}
