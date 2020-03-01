using Microsoft.WindowsAPICodePack.Win32Native;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.WindowsAPICodePack. Win32Native
{
    public interface IReadOnlyNativeCollection<T> : IEnumerable<T>, IEnumerable
    {
        bool IsReadOnly { get; }

        HResult GetAt(ref uint index, out T item);

        HResult GetCount(out uint count);
    }

    public interface INativeCollection<T> : IReadOnlyNativeCollection<T>

    {

        bool IsFixedSize { get; } 

        HResult Add(ref T value);

        HResult RemoveAt(ref uint index);

        HResult Clear();

    }
    public interface IReadOnlyDisposableNativeCollection<T> : IDisposable, IEnumerable<T>, IEnumerable
    {
        bool IsReadOnly { get; }

        HResult GetAt(ref uint index, out T item);

        HResult GetCount(out uint count);
    }

    public interface IDisposableNativeCollection<T> : IReadOnlyDisposableNativeCollection<T>

    {

        bool IsFixedSize { get; }

        HResult Add(ref T value);

        HResult RemoveAt(ref uint index);

        HResult Clear();

    }
}
