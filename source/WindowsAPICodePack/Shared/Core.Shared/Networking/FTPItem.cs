#if WAPICP3 && CS5
using Microsoft.WindowsAPICodePack.Win32Native;
using Microsoft.WindowsAPICodePack.Win32Native.PropertySystem;
using Microsoft.WindowsAPICodePack.Win32Native.Shell;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using WinCopies.Collections.DotNetFix.Generic;

namespace Microsoft.WindowsAPICodePack.Net.FTP
{
    public interface IFTPItem
    {
        IFTPConnection Connection { get; }

        IFTPFolder
#if CS8
                ?
#endif
                Parent
        { get; }

        string Directory { get; }

        FileAttributes FileAttributes { get; }

        DateTime CreationTime { get; }

        DateTime LastAccessTime { get; }

        DateTime LastWriteTime { get; }

        ulong FileSize { get; }

        string Name { get; }

        bool TryDelete();

        void Delete();
    }

    public interface IFTPFolderBase : System.Collections.Generic.IEnumerable<IFTPItem>
    {
        // Left empty.
    }

    public interface IFTPFolder : IFTPFolderBase, IFTPItem
    {
        // Left empty.
    }

    public abstract class FTPItem : IFTPItem
    {
        public IFTPConnection Connection { get; }

        public IFTPFolder
#if CS8
                ?
#endif
                Parent
        { get; }

        public FileAttributes FileAttributes { get; }

        public DateTime CreationTime { get; }

        public DateTime LastAccessTime { get; }

        public DateTime LastWriteTime { get; }

        public ulong FileSize { get; }

        public string Directory { get; }

        public string Name { get; }

        private FTPItem(in FTPConnection connection, in Win32FindData data, in IFTPFolder
#if CS8
                ?
#endif
                parent, in string directory)
        {
            Connection = connection;

            FileAttributes = data.dwFileAttributes;

#if CS8
            static
#endif
            DateTime getDateTime(in FileTime value) => new
#if !CS9
                DateTime
#endif
                (value.dwHighDateTime == 0 && value.dwLowDateTime == 0 ? null : (long
#if !CS9
                ?
#endif
                )PropVariant.GetFileTimeAsULong(value));

            CreationTime = getDateTime(data.ftCreationTime);

            LastAccessTime = getDateTime(data.ftLastAccessTime);

            LastWriteTime = getDateTime(data.ftLastWriteTime);

            FileSize = PropVariant.GetULong(data.fileSize.nFileSizeHigh, data.fileSize.nFileSizeLow);

            Name = data.cFileName;

            Parent = parent;

            Directory = directory;
        }

        public FTPItem(in FTPConnection connection, in Win32FindData data, in IFTPFolder
#if CS8
                ?
#endif
                parent) : this(connection, data, parent, parent == null ? connection.RootPath : parent.GetPath()) { /* Left empty. */ }

        public FTPItem(in FTPConnection connection, in Win32FindData data, in string directory) : this(connection, data, null, directory) { /* Left empty. */ }

        public abstract bool TryDelete();

        public void Delete() => CoreErrorHelper.RunWin32Action(TryDelete);
    }

    public class FTPFolder : FTPItem, IFTPFolder
    {
        public FTPFolder(in FTPConnection connection, Win32FindData data, in IFTPFolder
#if CS8
                ?
#endif
                parent) : base(GetConnection(connection, data), data, parent) { /* Left empty. */ }

        public FTPFolder(in FTPConnection connection, Win32FindData data, in string directory) : base(GetConnection(connection, data), data, directory) { /* Left empty. */ }

        protected static FTPConnection GetConnection(in FTPConnection connection, in Win32FindData data) => data.dwFileAttributes.HasFlag(FileAttributes.Directory) ? connection : throw new ArgumentException("The data do not represent a folder.", nameof(data));

        public override bool TryDelete() => Connection.TryDeleteDirectory(this.GetPath());

        public System.Collections.Generic.IEnumerator<IFTPItem> GetEnumerator() => new FTPConnection.Enumerator(this);

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class FTPFile : FTPItem
    {
        public FTPFile(in FTPConnection connection, in Win32FindData data, in IFTPFolder
#if CS8
                ?
#endif
                parent) : base(connection, data, parent) { /* Left empty. */ }

        public FTPFile(in FTPConnection connection, in Win32FindData data, in string directory) : base(connection, data, directory) { /* Left empty. */ }

        public override bool TryDelete() => Connection.TryDeleteFile(this.GetPath());
    }
}
#endif
