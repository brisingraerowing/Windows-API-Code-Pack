/* MIT License

Copyright (c) 2018 Jacques Kang, Copyright (c) 2021 Pierre Sprimont

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE. */

using Microsoft.Win32.SafeHandles;
using Microsoft.WindowsAPICodePack.NativeAPI.Consts;

using System;
using System.IO.Pipes;
using System.Runtime.InteropServices;
using System.Security.AccessControl;

namespace Microsoft.WindowsAPICodePack.Win32Native.NamedPipe
{
    public enum Wait : uint
    {
        Wait = 0x00000000,

        NoWait = 0x00000001
    }

    public enum Read : uint
    {
        Byte = 0x00000000,

        Message = 0x00000002
    }

    public enum Type : uint
    {
        /// <summary>
        /// Data is written to the pipe as a stream of bytes. This mode cannot be used with <see cref="Read.Message"/>. The pipe does not distinguish bytes written during different write operations.
        /// </summary>
        Byte = 0x00000000,

        /// <summary>
        /// Data is written to the pipe as a stream of messages. The pipe treats the bytes written during each write operation as a message unit. The <see cref="Marshal.GetLastWin32Error"/> function returns <see cref="ErrorCode.MoreData"/> when a message is not read completely. This mode can be used with either <see cref="Read.Message"/> or <see cref="Read.Byte"/>.
        /// </summary>
        Message = 0x00000004
    }

    public enum RemoteClient : uint
    {
        AcceptRemoteClients = 0x00000000,

        RejectRemoteClients = 0x00000008
    }

    public enum Access : uint
    {
        /// <summary>
        /// The flow of data in the pipe goes from client to server only. This mode gives the server the equivalent of GENERIC_READ access to the pipe. The client must specify GENERIC_WRITE access when connecting to the pipe. If the client must read pipe settings by calling the GetNamedPipeInfo or GetNamedPipeHandleState functions, the client must specify GENERIC_WRITE and FILE_READ_ATTRIBUTES access when connecting to the pipe.
        /// </summary>
        InBound = 0x00000001,

        /// <summary>
        /// The flow of data in the pipe goes from server to client only. This mode gives the server the equivalent of GENERIC_WRITE access to the pipe. The client must specify GENERIC_READ access when connecting to the pipe. If the client must change pipe settings by calling the SetNamedPipeHandleState function, the client must specify GENERIC_READ and FILE_WRITE_ATTRIBUTES access when connecting to the pipe.
        /// </summary>
        OutBound = 0x00000002,

        /// <summary>
        /// The pipe is bi-directional; both server and client processes can read from and write to the pipe. This mode gives the server the equivalent of GENERIC_READ and GENERIC_WRITE access to the pipe. The client can specify GENERIC_READ or GENERIC_WRITE, or both, when it connects to the pipe using the CreateFile function.
        /// </summary>
        Duplex = 0x00000003
    }

    [Flags]
    public enum File : uint
    {
        /// <summary>
        /// If you attempt to create multiple instances of a pipe with this flag, creation of the first instance succeeds, but creation of the next instance fails with ERROR_ACCESS_DENIED.
        /// </summary>
        FirstPipeInstance = 0x00080000,

        /// <summary>
        /// Write-through mode is enabled. This mode affects only write operations on byte-type pipes and, then, only when the client and server processes are on different computers. If this mode is enabled, functions writing to a named pipe do not return until the data written is transmitted across the network and is in the pipe's buffer on the remote computer. If this mode is not enabled, the system enhances the efficiency of network operations by buffering data until a minimum number of bytes accumulate or until a maximum time elapses.
        /// </summary>
        WriteThrough = 0x80000000,

        /// <summary>
        /// Overlapped mode is enabled. If this mode is enabled, functions performing read, write, and connect operations that may take a significant time to be completed can return immediately. This mode enables the thread that started the operation to perform other operations while the time-consuming operation executes in the background. For example, in overlapped mode, a thread can handle simultaneous input and output (I/O) operations on multiple instances of a pipe or perform simultaneous read and write operations on the same pipe handle. If overlapped mode is not enabled, functions performing read, write, and connect operations on the pipe handle do not return until the operation is finished. The ReadFileEx and WriteFileEx functions can only be used with a pipe handle in overlapped mode. The ReadFile, WriteFile, ConnectNamedPipe, and TransactNamedPipe functions can execute either synchronously or as overlapped operations.
        /// </summary>
        Overlapped = 0x40000000
    }

    [Flags]
    public enum WriteAccess : long
    {
        DAC = 0x00040000L,

        Owner = 0x00080000L,

        SystemSecurity = 0x01000000L
    }

    /// <summary>
    /// Native API for Named Pipes
    /// https://github.com/PowerShell/PowerShell/blob/master/src/System.Management.Automation/engine/remoting/common/RemoteSessionNamedPipe.cs#L124-L256
    /// </summary>
    public static class NamedPipe
    {
        public const int UnlimitedInstances = 255;

        /// <summary>
        /// Creates an instance of a named pipe and returns a handle for subsequent pipe operations. A named pipe server process uses this function either to create the first instance of a specific named pipe and establish its basic attributes or to create a new instance of an existing named pipe.
        /// </summary>
        /// <param name="lpName">
        /// <para>The unique pipe name. This string must have the following form: \\.\pipe\pipename</para>
        /// <para>The pipename part of the name can include any character other than a backslash, including numbers and special characters. The entire pipe name string can be up to 256 characters long. Pipe names are not case sensitive.</para></param>
        /// <param name="dwOpenMode">
        /// <para>The open mode.</para>
        /// <para>The function fails if <paramref name="dwOpenMode"/> specifies anything other than 0 or the flags listed in the following tables.</para>
        /// <para>This parameter must specify one of the <see cref="Access"/> modes. The same mode must be specified for each instance of the pipe.</para>
        /// <para>This parameter can also include one or more of the <see cref="File"/> enum flags, which enable the write-through and overlapped modes. These modes can be different for different instances of the same pipe.</para>
        /// <para>This parameter can include any combination of the <see cref="WriteAccess"/> security access modes. These modes can be different for different instances of the same pipe.</para></param>
        /// <param name="dwPipeMode"><para>The pipe mode.</para>
        /// <para>The function fails if dwPipeMode specifies anything other than 0 or the flags listed in the following tables.</para>
        /// <para>One of the <see cref="Type"/> modes can be specified. The same type mode must be specified for each instance of the pipe.</para>
        /// <para>One of the <see cref="Read"/> modes can be specified. Different instances of the same pipe can specify different read modes.</para>
        /// <para>One of the <see cref="Wait"/> modes can be specified. Different instances of the same pipe can specify different wait modes.</para>
        /// <para>One of the <see cref="RemoteClient"/> modes can be specified. Different instances of the same pipe can specify different remote-client modes.</para></param>
        /// <param name="nMaxInstances"><para>The maximum number of instances that can be created for this pipe. The first instance of the pipe can specify this value; the same number must be specified for other instances of the pipe. Acceptable values are in the range 1 through <see cref="UnlimitedInstances"/> (255).</para>
        /// <para>If this parameter is <see cref="UnlimitedInstances"/>, the number of pipe instances that can be created is limited only by the availability of system resources. If nMaxInstances is greater than <see cref="UnlimitedInstances"/>, the return value is INVALID_HANDLE_VALUE and <see cref="Marshal.GetLastWin32Error"/> returns <see cref="ErrorCode.InvalidParameter"/>.</para></param>
        /// <param name="nOutBufferSize">The number of bytes to reserve for the output buffer.</param>
        /// <param name="nInBufferSize">The number of bytes to reserve for the input buffer.</param>
        /// <param name="nDefaultTimeOut"><para>The default time-out value, in milliseconds, if the WaitNamedPipe function specifies NMPWAIT_USE_DEFAULT_WAIT. Each instance of a named pipe must specify the same value.</para>
        /// <para>A value of zero will result in a default time-out of 50 milliseconds.</para></param>
        /// <param name="lpSecurityAttributes">A pointer to a <see cref="SecurityAttributes"/> structure that specifies a security descriptor for the new named pipe and determines whether child processes can inherit the returned handle. If lpSecurityAttributes is <see langword="null"/>, the named pipe gets a default security descriptor and the handle cannot be inherited. The ACLs in the default security descriptor for a named pipe grant full control to the LocalSystem account, administrators, and the creator owner. They also grant read access to members of the Everyone group and the anonymous account.</param>
        /// <returns><para>If the function succeeds, the return value is a handle to the server end of a named pipe instance.</para>
        /// <para>If the function fails, the return value is INVALID_HANDLE_VALUE. To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.</para></returns>
        [DllImport(DllNames.Kernel32, SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern SafePipeHandle CreateNamedPipeW([In, MarshalAs(UnmanagedType.LPWStr)] string lpName, [In, MarshalAs(UnmanagedType.U4)] uint dwOpenMode, [In, MarshalAs(UnmanagedType.U4)] uint dwPipeMode, [In, MarshalAs(UnmanagedType.U4)] uint nMaxInstances, [In, MarshalAs(UnmanagedType.U4)] uint nOutBufferSize, [In, MarshalAs(UnmanagedType.U4)] uint nInBufferSize, [In, MarshalAs(UnmanagedType.U4)] uint nDefaultTimeOut, [In, MarshalAs(UnmanagedType.LPStruct)] SecurityAttributes lpSecurityAttributes);

        /// <summary>
        /// Helper method to create a PowerShell transport named pipe via native API, along
        /// with a returned .Net NamedPipeServerStream object wrapping the named pipe.
        /// </summary>
        /// <param name="pipeName">Named pipe core name.</param>
        /// <returns>An instance of the <see cref="NamedPipeServerStream"/> class.</returns>
        public static NamedPipeServerStream CreateNamedPipe(string pipeName, uint maxNumberOfServerInstances, PipeSecurity pipeSecurity)
        {
            string fullPipeName = @"\\.\pipe\" + pipeName;

            var securityDesc = new CommonSecurityDescriptor(false, false, pipeSecurity.GetSecurityDescriptorBinaryForm(), 0);

            // Create optional security attributes based on provided PipeSecurity.
            SecurityAttributes securityAttributes = null;
            GCHandle? securityDescHandle = null;

            if (securityDesc != null)
            {
                byte[] securityDescBuffer = new byte[securityDesc.BinaryLength];
                securityDesc.GetBinaryForm(securityDescBuffer, 0);

                securityDescHandle = GCHandle.Alloc(securityDescBuffer, GCHandleType.Pinned);
                securityAttributes = CoreHelpers.GetSecurityAttributes(securityDescHandle.Value);
            }

            uint openMode = (uint)Access.Duplex | (uint)File.Overlapped;

            if (maxNumberOfServerInstances == 1)

                openMode |= (uint)File.FirstPipeInstance;

            // Create named pipe.
            SafePipeHandle pipeHandle = CreateNamedPipeW(
                fullPipeName,
                openMode,
                (uint)Type.Byte | (uint)Read.Byte,
                maxNumberOfServerInstances,
                1,
                1,
                0,
                securityAttributes);

            if (securityDescHandle != null)

                securityDescHandle.Value.Free();

            if (pipeHandle.IsInvalid)

                throw new InvalidOperationException("Error code: " + Marshal.GetLastWin32Error().ToString());

            // Create the .Net NamedPipeServerStream wrapper.
            try
            {
                return new NamedPipeServerStream(
                    PipeDirection.InOut,
                    true,                       // IsAsync
                    false,                      // IsConnected
                    pipeHandle);
            }

            catch (Exception)
            {
                pipeHandle.Dispose();
                throw;
            }
        }
    }
}
