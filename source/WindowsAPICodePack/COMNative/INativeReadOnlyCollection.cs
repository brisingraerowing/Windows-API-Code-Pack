using Microsoft.WindowsAPICodePack.Win32Native;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.WindowsAPICodePack. Win32Native
{
    public interface INativeReadOnlyCollection<T> : WinCopies.Util.DotNetFix.IDisposable, IEnumerable<T>, IEnumerable
    {
        bool IsReadOnly { get; }

        HResult GetAt(ref uint index, out T item);

        HResult GetCount(out uint count);
    }

    public interface INativeCollection<T> : INativeReadOnlyCollection<T>

    {

        bool IsFixedSize { get; }

        HResult Add(ref T value);

        HResult RemoveAt(in uint index);

        HResult Clear();

    }
}
