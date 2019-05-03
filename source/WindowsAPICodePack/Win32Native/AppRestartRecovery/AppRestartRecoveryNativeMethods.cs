//Copyright (c) Microsoft Corporation.  All rights reserved.

using Microsoft.WindowsAPICodePack.Win32Native;
using System;
using System.Runtime.InteropServices;

namespace Microsoft.WindowsAPICodePack.Win32Native.ApplicationServices
{
    public static class AppRestartRecoveryNativeMethods
    {
        #region Application Restart and Recovery Definitions

        public delegate uint RecoveryCallbackDelegate(IntPtr state);

        public static RecoveryCallbackDelegate RecoveryCallback { get; } = new RecoveryCallbackDelegate(RecoveryHandler);

        private static uint RecoveryHandler(IntPtr parameter)
        {
            ApplicationRecoveryInProgress(out bool cancelled);

            GCHandle handle = GCHandle.FromIntPtr(parameter);
            RecoveryData data = handle.Target as RecoveryData;
            data.Invoke();
            handle.Free();

            return (0);
        }



        [DllImport("kernel32.dll")]
        public static extern void ApplicationRecoveryFinished(
           [MarshalAs(UnmanagedType.Bool)] bool success);

        [DllImport("kernel32.dll")]
        [PreserveSig]
        public static extern HResult ApplicationRecoveryInProgress(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool canceled);

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
        [PreserveSig]
        public static extern HResult RegisterApplicationRecoveryCallback(
            RecoveryCallbackDelegate callback, IntPtr param,
            uint pingInterval,
            uint flags); // Unused.

        [DllImport("kernel32.dll")]
        [PreserveSig]
        public static extern HResult RegisterApplicationRestart(
            [MarshalAs(UnmanagedType.BStr)] string commandLineArgs,
            RestartRestrictions flags);

        [DllImport("kernel32.dll")]
        [PreserveSig]
        public static extern HResult UnregisterApplicationRecoveryCallback();

        [DllImport("kernel32.dll")]
        [PreserveSig]
        public static extern HResult UnregisterApplicationRestart();

        #endregion
    }
}
