using Microsoft.WindowsAPICodePack.Win32Native;

using System;
using System.Runtime.InteropServices;

namespace Microsoft.WindowsAPICodePack.Controls
{
    /// <summary>
    /// An exception thrown when an error occurs while dealing with Control objects.
    /// </summary>
    [Serializable]
    public class CommonControlException : COMException
    {
        /// <inheritdoc/>
        public CommonControlException() { /* Left empty. */ }

        /// <inheritdoc/>
        public CommonControlException(string message) : base(message) { /* Left empty. */ }

        /// <inheritdoc/>
        public CommonControlException(string message, Exception innerException) : base(message, innerException) { /* Left empty. */ }

        /// <inheritdoc/>
        public CommonControlException(string message, int errorCode) : base(message, errorCode) { /* Left empty. */ }

        /// <summary>
        /// Initializes an exception with custom message and error code.
        /// </summary>
        internal CommonControlException(string message, HResult errorCode) : this(message, (int)errorCode) { /* Left empty. */ }

        /// <inheritdoc/>
        protected CommonControlException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context) { /* Left empty. */ }
    }
}
