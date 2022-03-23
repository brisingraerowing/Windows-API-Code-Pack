//Copyright (c) Microsoft Corporation.  All rights reserved.  Distributed under the Microsoft Public License (MS-PL)

using System.Runtime.InteropServices;

using static Microsoft.WindowsAPICodePack.NativeAPI.Consts.Shell;

namespace Microsoft.WindowsAPICodePack.Win32Native.Shell.RestartManager
{
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
