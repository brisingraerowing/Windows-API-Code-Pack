using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using IDataObject = System.Runtime.InteropServices.ComTypes.IDataObject;

namespace Microsoft.WindowsAPICodePack.Win32Native.Core.Clipboard
{
    public static class ClipboardNativeMethods
    {

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool OpenClipboard(IntPtr ownerWindowNewOwner);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr GetClipboardData(StandardClipboardFormats uFormat);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool IsClipboardFormatAvailable(int format);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr GetOpenClipboardWindow();

        [DllImport("user32.dll", SetLastError = true)]
        public static extern int EnumClipboardFormats(int format);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool EmptyClipboard();

        [DllImport("ole32.dll")]
        public static extern uint OleGetClipboard([MarshalAs(UnmanagedType.IUnknown)]out object ppDataObj);

        [DllImport("ole32.dll")]
        public static extern uint OleSetClipboard(IDataObject pDataObj);

        [DllImport("ole32.dll")]
        public static extern int OleFlushClipboard();

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool CloseClipboard();

    }
}
