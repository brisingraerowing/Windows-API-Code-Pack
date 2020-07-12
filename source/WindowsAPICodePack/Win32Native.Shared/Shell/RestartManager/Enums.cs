using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Microsoft.WindowsAPICodePack.Win32Native.Shell.RestartManager
{
    [Flags]
    public enum RM_REBOOT_REASON:uint
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
        RmRebootReasonSessionMismatch=0x2,

        /// <summary>
        /// A critical process has been detected.
        /// </summary>
        RmRebootReasonCriticalProcess=0x4,

        /// <summary>
        /// A critical service has been detected.
        /// </summary>
        RmRebootReasonCriticalService=0x8,

        /// <summary>
        /// The current process has been detected.
        /// </summary>
        RmRebootReasonDetectedSelf=0x10
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
    /// <summary>
    /// Describes an application that is to be registered with the Restart Manager.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct RM_PROCESS_INFO
    {
        /// <summary>
        /// Contains an <see cref="RM_UNIQUE_PROCESS"/> structure that uniquely identifies the application by its PID and the time the process began.
        /// </summary>
        public RM_UNIQUE_PROCESS Process;

        /// <summary>
        /// If the process is a service, this parameter returns the long name for the service.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = CCH_RM_MAX_APP_NAME + 1)]
        public string strAppName;

        /// <summary>
        /// If the process is a service, this is the short name for the service.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = CCH_RM_MAX_SVC_NAME + 1)]
        public string strServiceShortName;

        /// <summary>
        /// Contains an RM_APP_TYPE enumeration value.
        /// </summary>
        public RM_APP_TYPE ApplicationType;

        /// <summary>
        /// Contains a bit mask that describes the current status of the application.
        /// </summary>
        public uint AppStatus;

        /// <summary>
        /// Contains the Terminal Services session ID of the process.
        /// </summary>
        public uint TSSessionId;

        /// <summary>
        /// <see langword="true"/> if the application can be restarted by the Restart Manager; otherwise, <see langword="false"/>.
        /// </summary>
        [MarshalAs(UnmanagedType.Bool)]
        public bool bRestartable;
    }
    /// <summary>
    /// Uniquely identifies a process by its PID and the time the process began. An array of <see cref="RM_UNIQUE_PROCESS"/> structures can be passed to the RmRegisterResources function.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct RM_UNIQUE_PROCESS
    {
        /// <summary>
        /// The product identifier (PID).
        /// </summary>
        public int dwProcessId;

        /// <summary>
        /// The creation time of the process.
        /// </summary>
        public System.Runtime.InteropServices.ComTypes.FILETIME ProcessStartTime;
    }
}
