using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.WindowsAPICodePack.Win32Native.Shell.ShellNativeMethods;

namespace Microsoft.WindowsAPICodePack.Shell
{
    /// <summary>
    /// The reason that <see cref="CopyProgressRoutine"/> was called.
    /// </summary>
    public enum CopyProgressCallbackReason : uint
    {
        /// <summary>
        /// Another part of the data file was copied.
        /// </summary>
        ChunkFinished = 0x00000000,

        /// <summary>
        /// Another stream was created and is about to be copied. This is the callback reason given when the callback routine is first invoked. 
        /// </summary>
        StreamSwitch = 0x00000001
    }
}
