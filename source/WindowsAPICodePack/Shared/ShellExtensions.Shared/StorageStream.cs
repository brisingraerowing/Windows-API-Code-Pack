﻿using Microsoft.WindowsAPICodePack.COMNative.COM;
using Microsoft.WindowsAPICodePack.ShellExtensions.Resources;

using System;
using System.IO;
using System.Runtime.InteropServices;

namespace Microsoft.WindowsAPICodePack.ShellExtensions
{
    /// <summary>
    /// A wrapper for the native <see cref="System.Runtime.InteropServices.ComTypes.IStream"/> object.
    /// </summary>
    public class StorageStream : Stream, IDisposable
    {
        private System.Runtime.InteropServices.ComTypes.IStream _stream;
        private readonly bool _isReadOnly = false;

        internal StorageStream(in System.Runtime.InteropServices.ComTypes.IStream stream, in bool readOnly)
        {
            _stream = stream ?? throw new ArgumentNullException(nameof(stream));

            _isReadOnly = readOnly;
        }

        /// <summary>
        /// Reads a single byte from the stream, moving the current position ahead by 1.
        /// </summary>
        /// <returns>A single byte from the stream, -1 if end of stream.</returns>
        public override int ReadByte()
        {
            ThrowIfDisposed();

            byte[] buffer = new byte[1];

            return Read(buffer, 0, 1) > 0 ? buffer[0] : -1;
        }

        /// <summary>
        /// Writes a single byte to the stream
        /// </summary>
        /// <param name="value">Byte to write to stream</param>
        public override void WriteByte(byte value)
        {
            ThrowIfDisposed();

            byte[] buffer = new byte[] { value };

            Write(buffer, 0, 1);
        }

        /// <summary>
        /// Gets whether the stream can be read from.
        /// </summary>
        public override bool CanRead => _stream != null;

        /// <summary>
        /// Gets whether seeking is supported by the stream.
        /// </summary>
        public override bool CanSeek => _stream != null;

        /// <summary>
        /// Gets whether the stream can be written to.
        /// Always false.
        /// </summary>
        public override bool CanWrite => !(_stream == null || _isReadOnly);

        /// <summary>
        /// Reads a buffer worth of bytes from the stream.
        /// </summary>
        /// <param name="buffer">Buffer to fill</param>
        /// <param name="offset">Offset to start filling in the buffer</param>
        /// <param name="count">Number of bytes to read from the stream</param>
        public override int Read(byte[] buffer, int offset, int count)
        {
            ThrowIfDisposed();

            int bytesRead = buffer == null ? throw new ArgumentNullException(nameof(buffer)) : offset < 0 ? throw new ArgumentOutOfRangeException(nameof(offset), LocalizedMessages.StorageStreamOffsetLessThanZero) : count < 0 ? throw new ArgumentOutOfRangeException(nameof(count), LocalizedMessages.StorageStreamCountLessThanZero) : offset + count > buffer.Length ? throw new ArgumentException(LocalizedMessages.StorageStreamBufferOverflow, nameof(count)) : 0;

            if (count > 0)
            {
                IntPtr ptr = Marshal.AllocCoTaskMem(sizeof(ulong));

                try
                {
                    if (offset == 0)
                    {
                        _stream.Read(buffer, count, ptr);

                        bytesRead = (int)Marshal.ReadInt64(ptr);
                    }

                    else
                    {
                        byte[] tempBuffer = new byte[count];

                        _stream.Read(tempBuffer, count, ptr);

                        bytesRead = (int)Marshal.ReadInt64(ptr);

                        if (bytesRead > 0)

                            Array.Copy(tempBuffer, 0, buffer, offset, bytesRead);
                    }
                }

                finally
                {
                    Marshal.FreeCoTaskMem(ptr);
                }
            }

            return bytesRead;
        }

        /// <summary>
        /// Writes a buffer to the stream if able to do so.
        /// </summary>
        /// <param name="buffer">Buffer to write</param>
        /// <param name="offset">Offset in buffer to start writing</param>
        /// <param name="count">Number of bytes to write to the stream</param>
        public override void Write(byte[] buffer, int offset, int count)
        {
            ThrowIfDisposed();

            if (_isReadOnly ? throw new InvalidOperationException(LocalizedMessages.StorageStreamIsReadonly) : buffer == null ? throw new ArgumentNullException(nameof(buffer)) : offset < 0 ? throw new ArgumentOutOfRangeException(nameof(offset), LocalizedMessages.StorageStreamOffsetLessThanZero) : count < 0 ? throw new ArgumentOutOfRangeException(nameof(count), LocalizedMessages.StorageStreamCountLessThanZero) : offset + count > buffer.Length ? throw new ArgumentException(LocalizedMessages.StorageStreamBufferOverflow, nameof(count)) : count > 0)
            {
                IntPtr ptr = Marshal.AllocCoTaskMem(sizeof(ulong));

                try
                {
                    if (offset == 0)

                        _stream.Write(buffer, count, ptr);

                    else
                    {
                        byte[] tempBuffer = new byte[count];
                        Array.Copy(buffer, offset, tempBuffer, 0, count);
                        _stream.Write(tempBuffer, count, ptr);
                    }
                }

                finally
                {
                    Marshal.FreeCoTaskMem(ptr);
                }
            }
        }

        /// <summary>
        /// Gets the length of the <see cref="System.Runtime.InteropServices.ComTypes.IStream"/>
        /// </summary>
        public override long Length
        {
            get
            {
                ThrowIfDisposed();

                _stream.Stat(out System.Runtime.InteropServices.ComTypes.STATSTG stats, (int)StatFlag.NoName);

                return stats.cbSize;
            }
        }

        /// <summary>
        /// Gets or sets the current position within the underlying <see cref="System.Runtime.InteropServices.ComTypes.IStream"/>.
        /// </summary>
        public override long Position
        {
            get
            {
                ThrowIfDisposed();

                return Seek(0, SeekOrigin.Current);
            }

            set
            {
                ThrowIfDisposed();

                _ = Seek(value, SeekOrigin.Begin);
            }
        }

        /// <summary>
        /// Seeks within the underlying System.Runtime.InteropServices.ComTypes.IStream.
        /// </summary>
        /// <param name="offset">Offset</param>
        /// <param name="origin">Where to start seeking</param>
        public override long Seek(long offset, SeekOrigin origin)
        {
            ThrowIfDisposed();

            IntPtr ptr = Marshal.AllocCoTaskMem(sizeof(long));

            try
            {
                _stream.Seek(offset, (int)origin, ptr);

                return Marshal.ReadInt64(ptr);
            }

            finally
            {
                Marshal.FreeCoTaskMem(ptr);
            }
        }

        /// <summary>
        /// Sets the length of the stream
        /// </summary>
        public override void SetLength(long value)
        {
            ThrowIfDisposed();

            _stream.SetSize(value);
        }

        /// <summary>
        /// Commits data to be written to the stream if it is being cached.
        /// </summary>
        public override void Flush() => _stream.Commit((int)StorageStreamCommitOptions.None);

        /// <summary>
        /// Disposes the stream.
        /// </summary>
        /// <param name="disposing"><see langword="true"/> if called from <see cref="Stream.Dispose()"/>, <see langword="false"/> if called from finalizer.</param>
        protected override void Dispose(bool disposing)
        {
            _stream = null;

            base.Dispose(disposing);
        }

        private void ThrowIfDisposed() { if (_stream == null) throw new ObjectDisposedException(GetType().Name); }
    }

    /// <summary>
    /// Options for commiting (flushing) an System.Runtime.InteropServices.ComTypes.IStream storage stream
    /// </summary>
    [Flags]
    internal enum StorageStreamCommitOptions
    {
        /// <summary>
        /// Uses default options
        /// </summary>
        None = 0,

        /// <summary>
        /// Overwrite option
        /// </summary>
        Overwrite = 1,

        /// <summary>
        /// Only if current
        /// </summary>
        OnlyIfCurrent = 2,

        /// <summary>
        /// Commits to disk cache dangerously
        /// </summary>
        DangerouslyCommitMerelyToDiskCache = 4,

        /// <summary>
        /// Consolidate
        /// </summary>
        Consolidate = 8
    }
}
