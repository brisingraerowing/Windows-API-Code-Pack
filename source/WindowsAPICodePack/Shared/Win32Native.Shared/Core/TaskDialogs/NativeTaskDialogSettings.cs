//Copyright (c) Microsoft Corporation.  All rights reserved.  Distributed under the Microsoft Public License (MS-PL)

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Microsoft.WindowsAPICodePack.Win32Native.Dialogs
{
    ///<summary>
    /// Encapsulates additional configuration needed by NativeTaskDialog
    /// that it can't get from the TASKDIALOGCONFIG struct.
    ///</summary>
    public class NativeTaskDialogSettings
    {
        public NativeTaskDialogSettings()
        {
            NativeConfiguration = new TaskDialog.TaskDialogConfiguration();

            // Apply standard settings.
            NativeConfiguration.size = (uint)Marshal.SizeOf(NativeConfiguration);
            NativeConfiguration.parentHandle = IntPtr.Zero;
            NativeConfiguration.instance = IntPtr.Zero;
            NativeConfiguration.taskDialogFlags = TaskDialog.TaskDialogOptions.AllowCancel;
            NativeConfiguration.commonButtons = TaskDialog.TaskDialogCommonButtons.Ok;
            NativeConfiguration.mainIcon = new TaskDialog.IconUnion(0);
            NativeConfiguration.footerIcon = new TaskDialog.IconUnion(0);
            NativeConfiguration.width = TaskDialogDefaults.IdealWidth;

            // Zero out all the custom button fields.
            NativeConfiguration.buttonCount = 0;
            NativeConfiguration.radioButtonCount = 0;
            NativeConfiguration.buttons = IntPtr.Zero;
            NativeConfiguration.radioButtons = IntPtr.Zero;
            NativeConfiguration.defaultButtonIndex = 0;
            NativeConfiguration.defaultRadioButtonIndex = 0;

            // Various text defaults.
            NativeConfiguration.windowTitle = TaskDialogDefaults.Caption;
            NativeConfiguration.mainInstruction = TaskDialogDefaults.MainInstruction;
            NativeConfiguration.content = TaskDialogDefaults.Content;
            NativeConfiguration.verificationText = null;
            NativeConfiguration.expandedInformation = null;
            NativeConfiguration.expandedControlText = null;
            NativeConfiguration.collapsedControlText = null;
            NativeConfiguration.footerText = null;
        }

        public int ProgressBarMinimum { get; set; }
        public int ProgressBarMaximum { get; set; }
        public int ProgressBarValue { get; set; }
        public TaskDialogProgressBarState ProgressBarState { get; set; }
        public bool InvokeHelp { get; set; }
        public TaskDialog.TaskDialogConfiguration NativeConfiguration { get; private set; }
        public TaskDialog.TaskDialogButton[] Buttons { get; set; }
        public TaskDialog.TaskDialogButton[] RadioButtons { get; set; }
        public List<int> ElevatedButtons { get; set; }
    }
}
