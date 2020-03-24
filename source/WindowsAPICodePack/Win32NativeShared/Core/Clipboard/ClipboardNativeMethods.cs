using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using IDataObject = System.Runtime.InteropServices.ComTypes.IDataObject;
using static Microsoft.WindowsAPICodePack.Win32Native.Consts.DllNames;

namespace Microsoft.WindowsAPICodePack.Win32Native.Clipboard
{
    public static class ClipboardNativeMethods
    {

        [DllImport(User32, SetLastError = true)]
        public static extern bool OpenClipboard(IntPtr ownerWindowNewOwner);

        [DllImport(User32, SetLastError = true)]
        public static extern IntPtr GetClipboardData(StandardClipboardFormats uFormat);

        [DllImport(User32, SetLastError = true)]
        public static extern bool IsClipboardFormatAvailable(int format);

        [DllImport(User32, SetLastError = true)]
        public static extern IntPtr GetOpenClipboardWindow();

        [DllImport(User32, SetLastError = true)]
        public static extern IntPtr GetClipboardOwner();

        [DllImport(User32, SetLastError = true)]
        public static extern int EnumClipboardFormats(int format);

        [DllImport(User32, SetLastError = true)]
        public static extern bool EmptyClipboard();

        [DllImport(Ole32)]
        public static extern HResult OleGetClipboard([MarshalAs(UnmanagedType.IUnknown)]out object ppDataObj);

        [DllImport(Ole32)]
        public static extern HResult OleSetClipboard(IDataObject pDataObj);

        [DllImport(Ole32)]
        public static extern HResult OleFlushClipboard();

        [DllImport(User32, SetLastError = true)]
        public static extern bool CloseClipboard();

    }
}
