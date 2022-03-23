//Copyright (c) Microsoft Corporation.  All rights reserved.  Distributed under the Microsoft Public License (MS-PL)

using Microsoft.WindowsAPICodePack.Win32Native;
using Microsoft.WindowsAPICodePack.Win32Native.Shell.RestartManager;

using System;
using System.Collections.Generic;
using System.Diagnostics;

using static Microsoft.WindowsAPICodePack.Win32Native.Shell.RestartManager.NativeMethods;
using static Microsoft.WindowsAPICodePack.Shell.Resources.LocalizedMessages;

namespace Microsoft.WindowsAPICodePack.Shell
{
    /// <summary>
    /// This class contains all the functions to find out which are the processes are locking a file.
    /// </summary>
    public static class FileLockFinder
    {
        // private delegate void AddTreeNode(TreeNode node);
        // private static List<Process> LastProcessList;

        /// <summary>
        /// This function finds out what process(es) have a lock on the specified file.
        /// </summary>
        /// <param name="path">Path of the file</param>
        /// <returns>Processes locking the file</returns>
        public static List<Process>
#if WAPICP3
            FindFileLock
#else
            FindLockFinder
#endif
            (string path)
        {
            string key = Guid.NewGuid().ToString();
#if !WAPICP3
            var processes = new List<Process>();
#endif

            if (RmStartSession(out uint handle, 0, key) != 0)

                throw new Exception(UnableToDetermineFileLocker);

            try
            {
                uint pnProcInfo = 0;
                string[] resources = new string[] { path };

                if (RmRegisterResources(handle, (uint)resources.Length, resources, 0, null, 0, null) != 0)

                    throw new Exception(CouldNotRegisterResource);

                // There's a race around condition here. The first call to RmGetList()
                // returns the total number of process. However, when we call RmGetList()
                // again to get the actual processes this number may have increased.

                uint res = RmGetList(handle, out uint pnProcInfoNeeded, ref pnProcInfo, null, out RM_REBOOT_REASON lpdwRebootReasons);

                if ((ErrorCode)res == ErrorCode.MoreData)
                {
                    // Create an array to store the process results.
                    var processInfo = new RM_PROCESS_INFO[pnProcInfoNeeded];

                    pnProcInfo = pnProcInfoNeeded;

                    // Get the list.

                    if (RmGetList(handle, out pnProcInfoNeeded, ref pnProcInfo, processInfo, out lpdwRebootReasons) == 0)
                    {
#if WAPICP3
                        var
#endif
                            processes = new List<Process>((int)pnProcInfo);

                        // Enumerate all of the results and add them to the list to be returned.
                        for (int i = 0; i < pnProcInfo; i++)

                            try
                            {
                                processes.Add(Process.GetProcessById(processInfo[i].Process.dwProcessId));

#if WAPICP3
                                return processes;
#endif
                            }

                            // Catch the error in case the process is no longer running.
                            catch (ArgumentException) { }
                    }

                    else

                        throw new Exception(CouldNotListProcessesLockingResource);
                }

                else if (res != 0)

                    throw new Exception(FailedToGetSizeOfResult);
            }

            //catch (Exception exception)
            //{
            //    MessageBox.Show(exception.Message, "Lock Finder", MessageBoxButtons.OK,
            //                    MessageBoxIcon.Error);
            //}

            finally
            {
                _ = RmEndSession(handle);
            }

            return
#if WAPICP3
                null;
#else
                processes;
#endif
        }
    }
}
