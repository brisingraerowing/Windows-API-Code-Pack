using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Microsoft.WindowsAPICodePack.Win32Native.COM
{
    [ComImport()]
    [Guid(Guids.COM.IObjectArray)]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IObjectArray
    {
        void GetCount(out uint cObjects);
        void GetAt(
            uint iIndex,
            ref Guid riid,
            [Out(), MarshalAs(UnmanagedType.Interface)] out object ppvObject);
    }

    [ComImport()]
    [Guid(Guids.COM.IObjectCollection)]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IObjectCollection : IObjectArray
    {
        void AddObject(
            [MarshalAs(UnmanagedType.Interface)] object pvObject);
        void AddFromArray(
            [MarshalAs(UnmanagedType.Interface)] IObjectArray poaSource);
        void RemoveObject(uint uiIndex);
        void Clear();
    }
}
