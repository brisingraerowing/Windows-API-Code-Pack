//Copyright (c) Microsoft Corporation.  All rights reserved.  Distributed under the Microsoft Public License (MS-PL)

using System;
using System.Runtime.InteropServices;

namespace Microsoft.WindowsAPICodePack.Win32Native
{
    [StructLayout(LayoutKind.Sequential)]
    public class ACL
    {
        public byte AclRevision;
        public byte Sbz1;
        public ushort AclSize;
        public ushort AceCount;
        public ushort Sbz2;
    }

    [StructLayout(LayoutKind.Sequential)]
    public class SecurityDescriptor
    {
        public byte Revision;
        public byte Sbz1;
        public ushort Control;
        public IntPtr Owner;
        public IntPtr Group;
        public ACL Sacl;
        public ACL Dacl;
    }

        /// <summary>
        /// The <see cref="SecurityAttributes"/> structure contains the security descriptor for an object and specifies whether the handle retrieved by specifying this structure is inheritable. This structure provides security settings for objects created by various functions, such as CreateFile, CreatePipe, CreateProcess, RegCreateKeyEx, or RegSaveKeyEx.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
    public class SecurityAttributes
    {
        /// <summary>
        /// The size, in bytes, of this structure. Set this value to the size of the <see cref="SecurityAttributes"/> structure.
        /// </summary>
        [MarshalAs(UnmanagedType.U4)]
        public uint nLength;

        /// <summary>
        /// A <see cref="SecurityDescriptor"/> class that controls access to the object. If the value of this member is <see langword="null"/>, the object is assigned the default security descriptor associated with the access token of the calling process. This is not the same as granting access to everyone by assigning a <see langword="null"/> discretionary access control list (DACL). By default, the default DACL in the access token of a process allows access only to the user represented by the access token.
        /// </summary>
        public IntPtr lpSecurityDescriptor;

        /// <summary>
        /// A <see cref="bool"/> value that specifies whether the returned handle is inherited when a new process is created. If this member is <see langword="true"/>, the new process inherits the handle.
        /// </summary>
        [MarshalAs(UnmanagedType.Bool)]
        public bool bInheritHandle;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct IconInfo
    {
        [MarshalAs(UnmanagedType.Bool)]
        public bool fIcon;
        [MarshalAs(UnmanagedType.U4)]
        public uint xHotspot;
        [MarshalAs(UnmanagedType.U4)]
        public uint yHotspot;
        public IntPtr hbmMask;
        public IntPtr hbmColor;
    }

    #region GDI and DWM Declarations
    /// <summary>
    /// A Wrapper for a SIZE struct
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct Size
    {
        /// <summary>
        /// Width
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// Height
        /// </summary>
        public int Height { get; set; }
    };
    #endregion
}
