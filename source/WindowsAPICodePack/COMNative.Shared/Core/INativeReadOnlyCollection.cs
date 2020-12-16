#if WAPICP2
using System.Collections;
#else
using Microsoft.WindowsAPICodePack.Win32Native;
#endif
using System.Collections.Generic;

namespace Microsoft.WindowsAPICodePack.
#if WAPICP2
    Win32Native
#else
    COMNative
#endif
{
    public interface INativeReadOnlyCollection<T> : WinCopies.
#if WAPICP2
        Util.
#endif
        DotNetFix.IDisposable, IEnumerable<T>
#if WAPICP2
, IEnumerable
#endif
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
