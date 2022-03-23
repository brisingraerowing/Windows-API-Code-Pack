//-----------------------------------------------------------------------
// <copyright file="SingleInstance.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
// <summary>
//     This class checks to make sure that only one instance of 
//     this application is running at a time.
// </summary>
//-----------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Security;

using static Microsoft.WindowsAPICodePack.NativeAPI.Consts.DllNames;

namespace Microsoft.WindowsAPICodePack.Win32Native.Shell
{
    [SuppressUnmanagedCodeSecurity]
    public static class SingleInstanceNativeMethods
    {
        /// <summary>
        /// Delegate declaration that matches WndProc signatures.
        /// </summary>
        public delegate IntPtr MessageHandler(WM uMsg, IntPtr wParam, IntPtr lParam, out bool handled);

        [DllImport(Shell32, EntryPoint = nameof(CommandLineToArgvW), CharSet = CharSet.Unicode)]
        public static extern IntPtr CommandLineToArgvW([MarshalAs(UnmanagedType.LPWStr)] string cmdLine, out int numArgs);

        public static string[] CommandLineToArgv(string cmdLine)
        {
            IntPtr argv = IntPtr.Zero;

            try
            {
                argv = CommandLineToArgvW(cmdLine, out int numArgs);

                if (argv == IntPtr.Zero)

                    throw new Win32Exception();

                string[] result = new string[numArgs];

                for (int i = 0; i < numArgs; i++)

                    result[i] = Marshal.PtrToStringUni(Marshal.ReadIntPtr(argv, i * Marshal.SizeOf(typeof(IntPtr))));

                return result;
            }

            finally
            {

                _ = Core.LocalFree(argv);
                // Otherwise LocalFree failed.
                // Assert.AreEqual(IntPtr.Zero, p);
            }
        }
    }
}
