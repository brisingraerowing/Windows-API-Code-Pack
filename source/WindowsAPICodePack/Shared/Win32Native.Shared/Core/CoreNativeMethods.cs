﻿//Copyright (c) Microsoft Corporation.  All rights reserved.  Distributed under the Microsoft Public License (MS-PL)

using System;
using System.Runtime.InteropServices;
using System.Text;
using static Microsoft.WindowsAPICodePack.NativeAPI.Consts.DllNames;

namespace Microsoft.WindowsAPICodePack.Win32Native
{
    [return: MarshalAs(UnmanagedType.Bool)]
    public delegate bool EnumResNameProc([In] IntPtr hModule, [In, MarshalAs(UnmanagedType.LPWStr)] string lpType, [In, MarshalAs(UnmanagedType.LPWStr)] string lpName, [In] IntPtr lParam);

    [return: MarshalAs(UnmanagedType.Bool)]
    public delegate bool IntPtrEnumResNameProc([In] IntPtr hModule, [In] IntPtr lpType, [In] IntPtr lpName, [In] IntPtr lParam);

    [return: MarshalAs(UnmanagedType.Bool)]
    public delegate bool EnumResTypeProc([In] IntPtr hModule, [In, MarshalAs(UnmanagedType.LPWStr)] string lpType, [In] IntPtr lParam);

    [return: MarshalAs(UnmanagedType.Bool)]
    public delegate bool IntPtrEnumResTypeProc([In] IntPtr hModule, [In] IntPtr lpType, [In] IntPtr lParam);

    #region Windows OS structs and consts
    public delegate int WNDPROC(IntPtr hWnd,
        uint uMessage,
        IntPtr wParam,
        IntPtr lParam);
    #endregion

    /// <summary>
    /// <para>Wrappers for Native Methods and Structs.</para>
    /// <para>This type is intended for unmanaged use only.</para>
    /// </summary>    
    public static class Core
    {
        #region General Definitions
        /// <summary>
        /// Retrieves the thread identifier of the calling thread.
        /// </summary>
        /// <returns>The thread identifier of the calling thread.</returns>
        /// <remarks>Until the thread terminates, the thread identifier uniquely identifies the thread throughout the system.</remarks>
        [DllImport(Kernel32)]
        public static extern uint GetCurrentThreadId();

        /// <summary>
        /// Places (posts) a message in the message queue associated with the thread that created
        /// the specified window and returns without waiting for the thread to process the message.
        /// </summary>
        /// <param name="windowHandle">Handle to the window whose window procedure will receive the message. 
        /// If this parameter is HWND_BROADCAST, the message is sent to all top-level windows in the system, 
        /// including disabled or invisible unowned windows, overlapped windows, and pop-up windows; 
        /// but the message is not sent to child windows.
        /// </param>
        /// <param name="message">Specifies the message to be sent.</param>
        /// <param name="wparam">Specifies additional message-specific information.</param>
        /// <param name="lparam">Specifies additional message-specific information.</param>
        /// <returns>A return code specific to the message being sent.</returns>     
        [DllImport(User32, CharSet = CharSet.Auto, PreserveSig = false, SetLastError = true)]
        public static extern void PostMessage(
            IntPtr windowHandle,
            WindowMessage message,
            IntPtr wparam,
            IntPtr lparam
        );

        /// <summary>
        /// Sends the specified message to a window or windows. The SendMessage function calls 
        /// the window procedure for the specified window and does not return until the window 
        /// procedure has processed the message. 
        /// </summary>
        /// <param name="windowHandle">Handle to the window whose window procedure will receive the message. 
        /// If this parameter is HWND_BROADCAST, the message is sent to all top-level windows in the system, 
        /// including disabled or invisible unowned windows, overlapped windows, and pop-up windows; 
        /// but the message is not sent to child windows.
        /// </param>
        /// <param name="message">Specifies the message to be sent.</param>
        /// <param name="wparam">Specifies additional message-specific information.</param>
        /// <param name="lparam">Specifies additional message-specific information.</param>
        /// <returns>A return code specific to the message being sent.</returns>     
        [DllImport(User32, CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr SendMessage(
            IntPtr windowHandle,
            WindowMessage message,
            IntPtr wparam,
            IntPtr lparam
        );

        /// <summary>
        /// Sends the specified message to a window or windows. The SendMessage function calls 
        /// the window procedure for the specified window and does not return until the window 
        /// procedure has processed the message. 
        /// </summary>
        /// <param name="windowHandle">Handle to the window whose window procedure will receive the message. 
        /// If this parameter is HWND_BROADCAST, the message is sent to all top-level windows in the system, 
        /// including disabled or invisible unowned windows, overlapped windows, and pop-up windows; 
        /// but the message is not sent to child windows.
        /// </param>
        /// <param name="message">Specifies the message to be sent.</param>
        /// <param name="wparam">Specifies additional message-specific information.</param>
        /// <param name="lparam">Specifies additional message-specific information.</param>
        /// <returns>A return code specific to the message being sent.</returns>        
        [DllImport(User32, CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr SendMessage(
            IntPtr windowHandle,
            uint message,
            IntPtr wparam,
            IntPtr lparam
        );

        /// <summary>
        /// Sends the specified message to a window or windows. The SendMessage function calls 
        /// the window procedure for the specified window and does not return until the window 
        /// procedure has processed the message. 
        /// </summary>
        /// <param name="windowHandle">Handle to the window whose window procedure will receive the message. 
        /// If this parameter is HWND_BROADCAST, the message is sent to all top-level windows in the system, 
        /// including disabled or invisible unowned windows, overlapped windows, and pop-up windows; 
        /// but the message is not sent to child windows.
        /// </param>
        /// <param name="message">Specifies the message to be sent.</param>
        /// <param name="wparam">Specifies additional message-specific information.</param>
        /// <param name="lparam">Specifies additional message-specific information.</param>
        /// <returns>A return code specific to the message being sent.</returns>
        [DllImport(User32, CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr SendMessage(
           IntPtr windowHandle,
           uint message,
           IntPtr wparam,
           [MarshalAs(UnmanagedType.LPWStr)] string lparam);

        /// <summary>
        /// Sends the specified message to a window or windows. The SendMessage function calls 
        /// the window procedure for the specified window and does not return until the window 
        /// procedure has processed the message. 
        /// </summary>
        /// <param name="windowHandle">Handle to the window whose window procedure will receive the message. 
        /// If this parameter is HWND_BROADCAST, the message is sent to all top-level windows in the system, 
        /// including disabled or invisible unowned windows, overlapped windows, and pop-up windows; 
        /// but the message is not sent to child windows.
        /// </param>
        /// <param name="message">Specifies the message to be sent.</param>
        /// <param name="wparam">Specifies additional message-specific information.</param>
        /// <param name="lparam">Specifies additional message-specific information.</param>
        /// <returns>A return code specific to the message being sent.</returns>
        public static IntPtr SendMessage(
            IntPtr windowHandle,
            uint message,
            int wparam,
            string lparam) => SendMessage(windowHandle, message, (IntPtr)wparam, lparam);

        /// <summary>
        /// Sends the specified message to a window or windows. The SendMessage function calls 
        /// the window procedure for the specified window and does not return until the window 
        /// procedure has processed the message. 
        /// </summary>
        /// <param name="windowHandle">Handle to the window whose window procedure will receive the message. 
        /// If this parameter is HWND_BROADCAST, the message is sent to all top-level windows in the system, 
        /// including disabled or invisible unowned windows, overlapped windows, and pop-up windows; 
        /// but the message is not sent to child windows.
        /// </param>
        /// <param name="message">Specifies the message to be sent.</param>
        /// <param name="wparam">Specifies additional message-specific information.</param>
        /// <param name="lparam">Specifies additional message-specific information.</param>
        /// <returns>A return code specific to the message being sent.</returns>

        [DllImport(User32, CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr SendMessage(
            IntPtr windowHandle,
            uint message,
            ref int wparam,
            [MarshalAs(UnmanagedType.LPWStr)] StringBuilder lparam);

        // Various helpers for forcing binding to proper 
        // version of Comctl32 (v6).
        [DllImport(Kernel32, SetLastError = true, ThrowOnUnmappableChar = true, BestFitMapping = false)]
        public static extern IntPtr LoadLibrary([MarshalAs(UnmanagedType.LPStr)] string fileName);

        [DllImport(Kernel32, SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern IntPtr LoadLibraryEx([In, MarshalAs(UnmanagedType.LPWStr)] string lpLibFileName, IntPtr hFile,
            [In, MarshalAs(UnmanagedType.U4)] uint dwFlags);

        [DllImport(User32, SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern int LoadString(
            IntPtr instanceHandle,
            int id,
            StringBuilder buffer,
            int bufferSize);

        [DllImport(Kernel32, EntryPoint = nameof(LocalFree), SetLastError = true)]
        public static extern IntPtr LocalFree(ref Guid guid);


        [DllImport(Kernel32, EntryPoint = nameof(LocalFree), SetLastError = true)]
        public static extern IntPtr LocalFree(IntPtr hMem);

        /// <summary>
        /// Destroys an icon and frees any memory the icon occupied.
        /// </summary>
        /// <param name="hIcon">Handle to the icon to be destroyed. The icon must not be in use. </param>
        /// <returns>If the function succeeds, the return value is nonzero. If the function fails, the return value is zero. To get extended error information, call GetLastError. </returns>
        [DllImport(User32, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool DestroyIcon(IntPtr hIcon);
        #endregion

        #region Window Handling
        [DllImport(User32, SetLastError = true, EntryPoint = nameof(DestroyWindow), CallingConvention = CallingConvention.StdCall)]
        public static extern int DestroyWindow(IntPtr handle);
        #endregion

        #region General Declarations
        /// <summary>
        /// Gets the HiWord
        /// </summary>
        /// <param name="value">The value to get the hi word from.</param>
        /// <param name="size">Size</param>
        /// <returns>The upper half of the dword.</returns>        
        public static int GetHiWord(long value, int size) => (short)(value >> size);

        /// <summary>
        /// Gets the LoWord
        /// </summary>
        /// <param name="value">The value to get the low word from.</param>
        /// <returns>The lower half of the dword.</returns>
        public static int GetLoWord(long value) => (short)(value & 0xFFFF);
        #endregion

        [DllImport(User32, ExactSpelling = true, SetLastError = true)]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport(Kernel32, EntryPoint = "RtlMoveMemory", SetLastError = true)]
        public unsafe static extern void CopyMemory([Out] void* dest, [In] void* src,
#if WIN64
            [In, MarshalAs(UnmanagedType.U8)] ulong
#else
            [In, MarshalAs(UnmanagedType.U4)] uint
#endif
             length);

        [DllImport(Kernel32, SetLastError = true)]
        public static extern IntPtr BeginUpdateResource([In] string pFileName, [In, MarshalAs(UnmanagedType.Bool)] bool bDeleteExistingResources
            );

        [DllImport(Kernel32, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool EndUpdateResource([In] IntPtr hUpdate, [In, MarshalAs(UnmanagedType.Bool)] bool fDiscard);

        [DllImport(Kernel32, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool UpdateResource([In] IntPtr hUpdate, [In, MarshalAs(UnmanagedType.LPWStr)] string lpType, [In, MarshalAs(UnmanagedType.LPWStr)] string lpName, [In, MarshalAs(UnmanagedType.U2)] ushort wLanguage, [In] byte[] lpData, [In, MarshalAs(UnmanagedType.U4)] uint cb);

        [DllImport(Kernel32, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool UpdateResource([In] IntPtr hUpdate, [In] IntPtr lpType, [In] IntPtr lpName, [In, MarshalAs(UnmanagedType.U2)] ushort wLanguage, [In] byte[] lpData, [In, MarshalAs(UnmanagedType.U4)] uint cb);

        [DllImport(Kernel32, SetLastError = true)]
        public static extern uint SizeofResource([In] IntPtr hModule, [In] IntPtr hResInfo);

        [DllImport(Kernel32, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool FreeLibrary([In] IntPtr hLibModule);

        [DllImport(Kernel32, SetLastError = true)]
        public static extern IntPtr LockResource([In] IntPtr hResData);

        [DllImport(Kernel32, SetLastError = true)]
        public static extern IntPtr LoadResource([In] IntPtr hModule, [In] IntPtr hResInfo);

        [DllImport(Kernel32, SetLastError = true, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool EnumResourceNames([In] IntPtr hModule, [In, MarshalAs(UnmanagedType.LPWStr)] string lpType, [In] EnumResNameProc lpEnumFunc, [In] IntPtr lParam);

        [DllImport(Kernel32, SetLastError = true, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool EnumResourceNames([In] IntPtr hModule, [In] IntPtr lpType, [In] IntPtrEnumResNameProc lpEnumFunc, [In] IntPtr lParam);

        [DllImport(Kernel32, SetLastError = true)]
        public static extern bool EnumResourceTypes([In] IntPtr hModule, [In] EnumResTypeProc lpEnumFunc, [In] IntPtr lParam);

        [DllImport(Kernel32, SetLastError = true)]
        public static extern bool EnumResourceTypes([In] IntPtr hModule, [In] IntPtrEnumResTypeProc lpEnumFunc, [In] IntPtr lParam);

        [DllImport(Kernel32, SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern IntPtr FindResource([In] IntPtr hModule, [In, MarshalAs(UnmanagedType.LPWStr)] string lpName, [In, MarshalAs(UnmanagedType.LPWStr)] string lpType);

        [DllImport(Kernel32, SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern IntPtr FindResource([In] IntPtr hModule, [In, MarshalAs(UnmanagedType.U2)] ushort lpName, [In, MarshalAs(UnmanagedType.U2)] ushort lpType);

        [DllImport(Kernel32, SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern IntPtr FindResource([In] IntPtr hModule, [In] IntPtr lpName, [In] IntPtr lpType);

        [DllImport(User32, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetIconInfo([In] IntPtr hIcon, [Out] out IconInfo piconinfo);

        [DllImport(Kernel32, SetLastError = true)]
        public static extern IntPtr GetCurrentProcess();

        [DllImport(Kernel32, SetLastError = true, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.U4)]
        public static extern uint QueryDosDevice([In, MarshalAs(UnmanagedType.LPWStr)]string lpDeviceName, [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder lpTargetPath, [In, MarshalAs(UnmanagedType.U4)] uint ucchMax);

        [DllImport(Psapi, SetLastError = true, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.U4)]
        public static extern uint GetMappedFileName([In] IntPtr hProcess, [In] IntPtr lpv, [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder lpFileName, [In] uint nSize);
    }
}
