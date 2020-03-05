using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace Microsoft.WindowsAPICodePack.Win32Native
{
    public static class IntPtrExtensions
    {
        public static T MarshalAs<T>(this IntPtr ptr) => (T)Marshal.PtrToStructure(ptr, typeof(T));
    }
}
