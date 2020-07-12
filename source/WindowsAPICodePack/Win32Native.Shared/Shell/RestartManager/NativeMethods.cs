//Copyright (c) Microsoft Corporation.  All rights reserved.  Distributed under the Microsoft Public License (MS-PL)

using System.Runtime.InteropServices;

using static Microsoft.WindowsAPICodePack.Win32Native.Consts.DllNames;

namespace Microsoft.WindowsAPICodePack.Win32Native.Shell.RestartManager
{
    public static class NativeMethods
    {
        /// <summary>
        /// Registers resources to a Restart Manager session. The Restart Manager uses the list of resources registered with the session to determine which applications and services must be shut down and restarted. Resources can be identified by file names, service short names, or <see cref="RM_UNIQUE_PROCESS"/> structures that describe running applications.
        /// </summary>
        /// <param name="dwSessionHandle">A handle to an existing Restart Manager session.</param>
        /// <param name="nFiles">The number of files being registered</param>
        /// <param name="rgsFileNames">An array of null-terminated strings of full filename paths.</param>
        /// <param name="nApplications">The number of processes being registered</param>
        /// <param name="rgApplications">An array of RM_UNIQUE_PROCESS structures</param>
        /// <param name="nServices">The number of services to be registered</param>
        /// <param name="rgsServiceNames">An array of null-terminated strings of service short names.</param>
        /// <returns><para>The function can return one of the system error codes that are defined in Winerror.h</para>
        /// <para>ERROR_SEM_TIMEOUT: Failed to obtain semaphore lock in allotted time.</para>
        /// <para>ERROR_BAD_ARGUMENTS: An invalid argument was supplied to the function.</para>
        /// <para>ERROR_WRITE_FAULT: Read/write operation failed.</para>
        /// <para>ERROR_OUTOFMEMORY: Could not allocate memory or instantiate class object.</para>
        /// <para>ERROR_INVALID_HANDLE: No session exists for the supplied handle.</para></returns>
        [DllImport(Rstrtmgr, CharSet = CharSet.Unicode, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.U4)]
        public static extern uint RmRegisterResources([In, MarshalAs(UnmanagedType.U4)] uint dwSessionHandle, [In, MarshalAs(UnmanagedType.U4)] uint nFiles, [In, MarshalAs(UnmanagedType.LPWStr)] string[] rgsFileNames, [In, MarshalAs(UnmanagedType.U4)] uint nApplications, [In] RM_UNIQUE_PROCESS[] rgApplications, [In, MarshalAs(UnmanagedType.U4)] uint nServices, [In, MarshalAs(UnmanagedType.LPWStr)] string[] rgsServiceNames);

        /// <summary>
        /// Starts a new Restart Manager session. A maximum of 64 Restart Manager sessions per user session can be open on the system at the same time. When this function starts a session, it returns a session handle and session key that can be used in subsequent calls to the Restart Manager API.
        /// </summary>
        /// <param name="pSessionHandle">A pointer to the handle of a Restart Manager session.</param>
        /// <param name="dwSessionFlags">Reserved. This parameter should be 0.</param>
        /// <param name="strSessionKey">A null-terminated string that contains the session key to the new session.</param>
        /// <returns><para>ERROR_SEM_TIMEOUT: Failed to obtain semaphore lock in allotted time.</para>
        /// <para>ERROR_BAD_ARGUMENTS: An invalid argument was supplied to the function.</para>
        /// <para>ERROR_WRITE_FAULT: Read/write operation failed.</para>
        /// <para>ERROR_OUTOFMEMORY: Could not allocate memory or instantiate class object.</para></returns>
        [DllImport(Rstrtmgr, CharSet = CharSet.Unicode, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.U4)]
        public static extern uint RmStartSession([Out, MarshalAs(UnmanagedType.U4)] out uint pSessionHandle, [MarshalAs(UnmanagedType.U4)] uint dwSessionFlags, string strSessionKey);

        /// <summary>
        /// Ends the Restart Manager session. This function should be called by the primary installer that has previously started the session by calling the <see cref="RmStartSession"/> function. The <see cref="RmEndSession"/> function can be called by a secondary installer that is joined to the session once no more resources need to be registered by the secondary installer.
        /// </summary>
        /// <param name="pSessionHandle">A handle to an existing Restart Manager session.</param>
        /// <returns><para>The function can return one of the system error codes that are defined in Winerror.h.</para>
        /// <para>ERROR_SEM_TIMEOUT: Failed to obtain semaphore lock in allotted time.</para>
        /// <para>ERROR_BAD_ARGUMENTS: An invalid argument was supplied to the function.</para>
        /// <para>ERROR_WRITE_FAULT: Read/write operation failed.</para>
        /// <para>ERROR_OUTOFMEMORY: Could not allocate memory or instantiate class object.</para>
        /// <para>ERROR_INVALID_HANDLE: No session exists for the supplied handle.</para></returns>
        [DllImport(Rstrtmgr, CharSet = CharSet.Auto, SetLastError = true)]
        public static extern uint RmEndSession([In, MarshalAs(UnmanagedType.U4)] uint pSessionHandle);

        /// <summary>
        /// Gets a list of all applications and services that are currently using resources that have been registered with the Restart Manager session.
        /// </summary>
        /// <param name="dwSessionHandle">A handle to an existing Restart Manager session.</param>
        /// <param name="pnProcInfoNeeded">A pointer to an array size necessary to receive RM_PROCESS_INFO structures required to return information for all affected applications and services.</param>
        /// <param name="pnProcInfo">A pointer to the total number of <see cref="RM_PROCESS_INFO"/> structures in an array and number of structures filled.</param>
        /// <param name="rgAffectedApps">An array of <see cref="RM_PROCESS_INFO"/> structures that list the applications and services using resources that have been registered with the session.</param>
        /// <param name="lpdwRebootReasons">Pointer to location that receives a value of the <see cref="RM_REBOOT_REASON"/> enumeration that describes the reason a system restart is needed.</param>
        /// <returns><para>ERROR_MORE_DATA: Buffer is not large enough for all information.</para>
        /// <para>ERROR_CANCELLED: Operation was cancelled by user.</para>
        /// <para>ERROR_SEM_TIMEOUT: Failed to obtain semaphore lock in allotted time.</para>
        /// <para>ERROR_BAD_ARGUMENTS: An invalid argument was supplied to the function.</para>
        /// <para>ERROR_WRITE_FAULT: Read/write operation failed.</para>
        /// <para>ERROR_OUTOFMEMORY: Could not allocate memory or instantiate class object.</para>
        /// <para>ERROR_INVALID_HANDLE: No session exists for the supplied handle.</para></returns>
        [DllImport(Rstrtmgr, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.U4)]
        public static extern uint RmGetList([In, MarshalAs(UnmanagedType.U4)] uint dwSessionHandle, [Out, MarshalAs(UnmanagedType.U4)] out uint pnProcInfoNeeded, [In, Out, MarshalAs(UnmanagedType.U4)] ref uint pnProcInfo, [In, Out] RM_PROCESS_INFO[] rgAffectedApps, [Out, MarshalAs(UnmanagedType.U4)] out RM_REBOOT_REASON lpdwRebootReasons);
    }
}
