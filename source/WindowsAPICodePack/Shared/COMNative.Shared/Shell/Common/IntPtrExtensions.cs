﻿using System;
using System.Runtime.InteropServices;

namespace Microsoft.WindowsAPICodePack.COMNative
{
    public static class IntPtrExtensions
    {
        public static T MarshalAs<T>(this IntPtr ptr) => (T)Marshal.PtrToStructure(ptr, typeof(T));
    }
}
