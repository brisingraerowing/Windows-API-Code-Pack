#if WAPICP3 && CS5
using Microsoft.WindowsAPICodePack.Win32Native;
using Microsoft.WindowsAPICodePack.Win32Native.Net;
using Microsoft.WindowsAPICodePack.Win32Native.Shell;

using System;
using System.Collections;
using System.Text;

using WinCopies;
using WinCopies.Collections.DotNetFix.Generic;
using WinCopies.Collections.Generic;
using WinCopies.Util;

using static Microsoft.WindowsAPICodePack.Win32Native.CoreErrorHelper;
using static Microsoft.WindowsAPICodePack.Win32Native.Net.NativeMethods;
using static Microsoft.WindowsAPICodePack.Win32Native.Net.FTP.NativeMethods;

using static WinCopies.ThrowHelper;

namespace Microsoft.WindowsAPICodePack.Net.FTP
{
    public interface IFTPConnection : IInternetConnection, IFTPFolderBase
    {
        bool IsEnumerating { get; }

        string RootPath { get; }

        bool TryCreateDirectory(string directory);

        void CreateDirectory(string directory);

        bool TryDeleteDirectory(string path);

        bool TryDeleteFile(string path);

        void DeleteDirectory(string path);

        void DeleteFile(string path);

        System.Collections.Generic.IEnumerator<IFTPItem> GetEnumerator(string path);

        System.Collections.Generic.IEnumerable<IFTPItem> Enumerate(string path);

#if CS8
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
#endif
    }

    public class FTPConnection : InternetConnection, IFTPConnection
    {
        public class Enumerator : Enumerator<IFTPItem>
        {
            private IntPtr _enumerationPtr;
            private Win32FindData _data;
            private Func<bool> _moveNext;
            private IFTPItem _current;
            private string _path;
            private IFTPFolder
#if CS8
                ?
#endif
                _parent;

            protected FTPConnection FTPConnection { get; }

            public override bool? IsResetSupported => true;

            protected override IFTPItem CurrentOverride => _current;

            private Enumerator(in FTPConnection connection, in string path, in IFTPFolder
#if CS8
                ?
#endif
                folder)
            {
                FTPConnection = connection;

                connection._currentEnumerator = this;

                _path = path;

                _parent = folder;

                ResetMoveNext();
            }

            public Enumerator(in FTPConnection connection) : this(connection ?? throw GetArgumentNullException(nameof(connection)), connection.RootPath, null) { /* Left empty. */ }

            public Enumerator(in FTPFolder folder) : this((FTPConnection)(folder ?? throw GetArgumentNullException(nameof(folder))).Connection, folder.GetPath(), folder) { /* Left empty. */ }

            public Enumerator(in FTPConnection connection, in string path) : this(connection ?? throw GetArgumentNullException(nameof(connection)), path, null) { /* Left empty. */ }

            public void ResetMoveNext() => _moveNext = () =>
            {
                FTPConnection._currentEnumerator = FTPConnection.IsEnumerating && FTPConnection._currentEnumerator != this ? throw FTPConnection.GetEnumerationRunningException() : this;

                FTPConnection.SetCurrentPath(_path);

                _enumerationPtr = FtpFindFirstFile(FTPConnection.ConnectionHandle, null, out _data, InternetFlags.NoCacheWrite | InternetFlags.Reload, (UIntPtr)1);

                bool onError() => GetLastWin32Error() == ErrorCode.NoMoreFiles
                        ? false
                        : throw GetExceptionForLastWin32Error();

                if (_enumerationPtr == IntPtr.Zero)

                    return onError();

                void setCurrent() => _current = _data.dwFileAttributes.HasFlag(FileAttributes.Directory) ?
#if !CS9
                (IFTPItem)(
#endif
                _parent == null ? new FTPFolder(FTPConnection, _data, _path) : new FTPFolder(FTPConnection, _data, _parent)
#if !CS9
                )
#endif
                : _parent == null ? new FTPFile(FTPConnection, _data, _path) : new FTPFile(FTPConnection, _data, _parent);

                _moveNext = () =>
                {
                    if (InternetFindNextFile(_enumerationPtr, out _data))
                    {
                        setCurrent();

                        return true;
                    }

                    return onError();
                };

                setCurrent();

                return true;
            };

            protected override bool MoveNextOverride() => _moveNext();

            protected override void ResetCurrent()
            {
                _current = null;
                _data = new Win32FindData();

                base.ResetCurrent();
            }

            private void ReleaseHandle()
            {
                _ = InternetCloseHandle(_enumerationPtr);

                _enumerationPtr = IntPtr.Zero;

                FTPConnection._currentEnumerator = null;
            }

            protected override void ResetOverride()
            {
                base.ResetOverride();

                ResetMoveNext();

                ReleaseHandle();
            }

            protected virtual void DisposeUnmanaged() => ReleaseHandle();

            protected override void DisposeManaged()
            {
                ResetCurrent();

                _moveNext = null;
                _path = null;
                _parent = null;

                base.DisposeManaged();
            }

            protected override void Dispose(bool disposing)
            {
                DisposeUnmanaged();

                base.Dispose(disposing);
            }
        }

        private Enumerator _currentEnumerator;
        private string _currentPath;

        public bool IsEnumerating => _currentEnumerator != null;

        public string RootPath { get; private set; }

        public FTPConnection(InternetConnectionData connectionInfo, in InternetOpenType internetOpenType, in InternetConnectionProxyInfo? proxyInfo, in InternetFlags openingFlags, in InternetFlags connectionFlags)

            : base(connectionInfo, internetOpenType, proxyInfo, openingFlags, InternetPort.DefaultFTPPort, InternetService.FTP, connectionFlags) { /* Left empty. */ }

        protected InvalidOperationException GetEnumerationRunningException() => new
#if !CS9
                InvalidOperationException
#endif
                ("An enumeration is already running.");

        protected override void OnConnected()
        {
            base.OnConnected();

            uint nbChars = NativeAPI.Consts.Shell.MaxPath;

            StringBuilder sb = new
#if !CS9
                StringBuilder
#endif
                ((int)nbChars);

            RunWin32Action(() => FtpGetCurrentDirectory(ConnectionHandle, sb, ref nbChars));

            RootPath = sb.ToString();
        }

        protected bool TrySetCurrentPath(string path) => _currentPath == path
            || RunActionIfConnected(() =>
            {
                if (FtpSetCurrentDirectory(ConnectionHandle, path))
                {
                    _currentPath = path;

                    return true;
                }

                return false;
            });

        public bool TryCreateDirectory(string directory) => FtpCreateDirectory(ConnectionHandle, directory);

        public void CreateDirectory(string directory) => RunWin32Action(() => TryCreateDirectory(directory));

        public bool TryUploadFile(string local, string remote) => FtpPutFile(ConnectionHandle, local, remote, 0, (UIntPtr)1);

        public void UploadFile(string local, string remote) => RunWin32Action(() => TryUploadFile(local, remote));

        public bool TryDeleteDirectory(string path) => FtpRemoveDirectory(ConnectionHandle, path);

        public bool TryDeleteFile(string path) => FtpDeleteFile(ConnectionHandle, path);

        public void DeleteDirectory(string path) => RunWin32Action(() => TryDeleteDirectory(path));

        public void DeleteFile(string path) => RunWin32Action(() => TryDeleteFile(path));

        protected internal void SetCurrentPath(string path) => RunWin32Action(() => TrySetCurrentPath(path));

        public System.Collections.Generic.IEnumerator<IFTPItem> GetEnumerator() => RunActionIfConnected(() => new Enumerator(this));

        public System.Collections.Generic.IEnumerator<IFTPItem> GetEnumerator(string path) => RunActionIfConnected(() => new Enumerator(this, path));

        public System.Collections.Generic.IEnumerable<IFTPItem> Enumerate(string path) => new Enumerable<IFTPItem>(() => GetEnumerator(path));

#if !CS8
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
#endif

        protected override void OnDisconnected()
        {
            base.OnDisconnected();

            RootPath = null;
        }
    }

    public static class FTPHelper
    {
        public static string GetPath(this IFTPItem item)
        {
            ThrowIfNull(item, nameof(item));

            if (item.Parent == null)

                return $"{(item.Connection.RootPath == "/" ? null : item.Connection.RootPath)}/{item.Name}";

            IStack<string> paths = new WinCopies.Collections.DotNetFix.Generic.Stack<string>();

            IFTPFolder parent = item.Parent;

            do

                paths.Push(parent.Name);

            while ((parent = parent.Parent) != null);

            StringBuilder sb = new
#if !CS9
                StringBuilder
#endif
                ();

            while (paths.Count != 0)
            {
                _ = sb.Append(paths.Pop());

                _ = sb.Append('/');
            }

            _ = sb.Append(item.Name);

            string path = sb.ToString();

            return path.StartsWith("//") ? path
#if CS8
                [
#else
                .Substring(
#endif
                1
#if CS8
                ..]
#else
                )
#endif
                : path;
        }
    }
}
#endif
