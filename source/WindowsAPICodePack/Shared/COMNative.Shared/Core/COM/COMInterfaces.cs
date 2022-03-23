using Microsoft.WindowsAPICodePack.Win32Native;

using System;
using System.Runtime.InteropServices;

using static System.Runtime.InteropServices.ComInterfaceType;
using static System.Runtime.InteropServices.UnmanagedType;

using COMGuids = Microsoft.WindowsAPICodePack.NativeAPI.Guids.COM;

namespace Microsoft.WindowsAPICodePack.COMNative.COM
{
    /// <summary>
    /// This enumeration values indicate whether the method should try to return a name in the pwcsName member of the <see cref="STATSTG"/> structure. The values are used in the ILockBytes::Stat, IStorage::Stat, and <see cref="IStream.Stat"/> methods to save memory when the pwcsName member is not required.
    /// </summary>
    public enum StatFlag : uint
    {
        /// <summary>
        /// Requests that the statistics include the pwcsName member of the <see cref="STATSTG"/> structure.
        /// </summary>
        Default = 0,

        /// <summary>
        /// Requests that the statistics not include the pwcsName member of the <see cref="STATSTG"/> structure. If the name is omitted, there is no need for the ILockBytes::Stat, IStorage::Stat, and <see cref="IStream.Stat"/> methods methods to allocate and free memory for the string value of the name, therefore the method reduces time and resources used in an allocation and free operation.
        /// </summary>
        NoName = 1,

        /// <summary>
        /// Not implemented.
        /// </summary>
        NoOpen = 2
    }

    /// <summary>
    /// This enumeration values specify the origin from which to calculate the new seek-pointer location. They are used for the dworigin parameter in the <see cref="IStream.Seek"/> method. The new seek position is calculated using this value and the dlibMove parameter.
    /// </summary>
    public enum StreamSeek : uint
    {
        /// <summary>
        /// The new seek pointer is an offset relative to the beginning of the stream. In this case, the dlibMove parameter is the new seek position relative to the beginning of the stream.
        /// </summary>
        Set = 0,

        /// <summary>
        /// The new seek pointer is an offset relative to the current seek pointer location. In this case, the dlibMove parameter is the signed displacement from the current seek position.
        /// </summary>
        Cursor = 1,

        /// <summary>
        /// The new seek pointer is an offset relative to the end of the stream. In this case, the dlibMove parameter is the new seek position relative to the end of the stream.
        /// </summary>
        End = 2
    }

    public struct FILETIME
    {
        public uint dwLowDateTime;
        public uint dwHighDateTime;
    }

    public struct STATSTG
    {
        public string pwcsName;
        [MarshalAs(U4)]
        public uint type;
        [MarshalAs(U8)]
        public ulong cbSize;
        public FILETIME mtime;
        public FILETIME ctime;
        public FILETIME atime;
        [MarshalAs(U4)]
        public uint grfMode;
        [MarshalAs(U4)]
        public uint grfLocksSupported;
        public Guid clsid;
        [MarshalAs(U4)]
        public uint grfStateBits;
        [MarshalAs(U4)]
        public uint reserved;
    }

    [ComImport,
        Guid(COMGuids.ISequentialStream),
    InterfaceType(InterfaceIsIUnknown)]
    public interface ISequentialStream
    {
        HResult Read(byte[] pv, [In, MarshalAs(U4)] uint cb, [Out, MarshalAs(U4)] out uint pcbRead);

        HResult Write(byte[] pv, [In, MarshalAs(U4)] uint cb, [Out, MarshalAs(U4)] out uint pcbWritten);
    }

    [ComImport,
        Guid(COMGuids.IStream),
    InterfaceType(InterfaceIsIUnknown)]
    public interface IStream : ISequentialStream
    {
        HResult Seek([In, MarshalAs(I8)] long dlibMove, [In, MarshalAs(U4)] StreamSeek dwOrigin, [Out, MarshalAs(U8)] out ulong plibNewPosition);

        HResult SetSize([In, MarshalAs(U8)] ulong libNewSize);

        HResult CopyTo([In, MarshalAs(Interface)] IStream pstm, [In, MarshalAs(U8)] ulong cb, [Out, MarshalAs(U8)] out ulong pcbRead, [Out, MarshalAs(U8)] out ulong pcbWritten);

        HResult Commit([In, MarshalAs(U4)] uint grfCommitFlags);

        HResult Revert();

        HResult LockRegion([In, MarshalAs(U8)] ulong libOffset, [In, MarshalAs(U8)] ulong cb, [In, MarshalAs(U4)] uint dwLockType);

        HResult UnlockRegion([In, MarshalAs(U8)] ulong libOffset, [In, MarshalAs(U8)] ulong cb, [In, MarshalAs(U4)] uint dwLockType);

        HResult Stat([Out] out STATSTG pstatstg, [In, MarshalAs(U4)] StatFlag grfStatFlag);

        HResult Clone([Out, MarshalAs(Interface)] out IStream ppstm);
    }

    [ComImport,
        Guid(COMGuids.IObjectArray),
        InterfaceType(InterfaceIsIUnknown)]
    public interface IObjectArray
    {
        void GetCount(out uint cObjects);

        void GetAt(uint iIndex, ref Guid riid, [Out, MarshalAs(Interface)] out object ppvObject);
    }

    [ComImport,
    Guid(COMGuids.IObjectCollection),
    InterfaceType(InterfaceIsIUnknown)]
    public interface IObjectCollection : IObjectArray
    {
        void AddObject([MarshalAs(Interface)] object pvObject);

        void AddFromArray([MarshalAs(Interface)] IObjectArray poaSource);

        void RemoveObject(uint uiIndex);

        void Clear();
    }

    [ComImport,
    Guid(NativeAPI.Guids.Taskbar.CEnumerableObjectCollection),
    ClassInterface(ClassInterfaceType.None)]
    public class CEnumerableObjectCollection { /* Left empty. */ }
}
