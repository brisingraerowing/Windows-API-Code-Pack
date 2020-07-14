//Copyright (c) Microsoft Corporation.  All rights reserved.  Distributed under the Microsoft Public License (MS-PL)

using System;

namespace Microsoft.WindowsAPICodePack.Win32Native.Shell.RestartManager
{
    [Flags]
    public enum RM_REBOOT_REASON : uint
    {
        /// <summary>
        /// Reboot not required.
        /// </summary>
        RmRebootReasonNone = 0x0,

        /// <summary>
        /// Current user does not have permission to shut down one or more detected processes.
        /// </summary>
        RmRebootReasonPermissionDenied = 0x1,

        /// <summary>
        /// One or more processes are running in another TS session.
        /// </summary>
        RmRebootReasonSessionMismatch = 0x2,

        /// <summary>
        /// A critical process has been detected.
        /// </summary>
        RmRebootReasonCriticalProcess = 0x4,

        /// <summary>
        /// A critical service has been detected.
        /// </summary>
        RmRebootReasonCriticalService = 0x8,

        /// <summary>
        /// The current process has been detected.
        /// </summary>
        RmRebootReasonDetectedSelf = 0x10
    }

    /// <summary>
    /// Specifies the type of application that is described by the <see cref="RM_PROCESS_INFO"/> structure.
    /// </summary>
    public enum RM_APP_TYPE
    {
        /// <summary>
        /// The application cannot be classified as any other type.
        /// </summary>
        RmUnknownApp = 0,

        /// <summary>
        /// A Windows application run as a stand-alone process that displays a top-level window.
        /// </summary>
        RmMainWindow = 1,

        /// <summary>
        /// A Windows application that does not run as a stand-alone process and does not display a top-level window.
        /// </summary>
        RmOtherWindow = 2,

        /// <summary>
        /// The application is a Windows service.
        /// </summary>
        RmService = 3,

        /// <summary>
        /// The application is Windows Explorer.
        /// </summary>
        RmExplorer = 4,

        /// <summary>
        /// The application is a stand-alone console application.
        /// </summary>
        RmConsole = 5,

        /// <summary>
        /// A system restart is required to complete the installation because a process cannot be shut down.
        /// </summary>
        RmCritical = 1000
    }
}
