//Copyright (c) Microsoft Corporation.  All rights reserved.  Distributed under the Microsoft Public License (MS-PL)

using Microsoft.WindowsAPICodePack.Win32Native;
using System;
using System.Runtime.InteropServices;
using static Microsoft.WindowsAPICodePack.Win32Native.Consts.DllNames;

namespace Microsoft.WindowsAPICodePack.Win32Native.ApplicationServices
{
    public static class AppRestartRecoveryNativeMethods
    {
        #region Application Restart and Recovery Definitions

        public delegate uint RecoveryCallbackDelegate(IntPtr state);

        public static RecoveryCallbackDelegate RecoveryCallback { get; } = new RecoveryCallbackDelegate(RecoveryHandler);

        private static uint RecoveryHandler(IntPtr parameter)
        {
            Marshal.ThrowExceptionForHR( (int) ApplicationRecoveryInProgress(out _));

            var handle = GCHandle.FromIntPtr(parameter);
            var data = handle.Target as RecoveryData;
            data.Invoke();
            handle.Free();

            return 0;
        }

        [DllImport(Kernel32)]
        public static extern void ApplicationRecoveryFinished(
           [MarshalAs(UnmanagedType.Bool)] bool success);

        [DllImport(Kernel32)]
        [PreserveSig]
        public static extern HResult ApplicationRecoveryInProgress(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool canceled);

        [DllImport(Kernel32, CharSet = CharSet.Unicode)]
        [PreserveSig]
        public static extern HResult RegisterApplicationRecoveryCallback(
            RecoveryCallbackDelegate callback, IntPtr param,
            uint pingInterval,
            uint flags); // Unused.

        [DllImport(Kernel32)]
        [PreserveSig]
        public static extern HResult RegisterApplicationRestart(
            [MarshalAs(UnmanagedType.BStr)] string commandLineArgs,
            RestartRestrictions flags);

        [DllImport(Kernel32)]
        [PreserveSig]
        public static extern HResult UnregisterApplicationRecoveryCallback();

        [DllImport(Kernel32)]
        [PreserveSig]
        public static extern HResult UnregisterApplicationRestart();

        #endregion
    }
}
