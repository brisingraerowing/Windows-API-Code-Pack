//Copyright (c) Pierre Sprimont.  All rights reserved.

using System;
using System.Runtime.Serialization;
using System.Security;

namespace Microsoft.WindowsAPICodePack.PortableDevices
{
    [Serializable]
    public class PortableDeviceException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PortableDeviceException"/> class.
        /// </summary>
        public PortableDeviceException() : base() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="PortableDeviceException"/> class with a custom error message.
        /// </summary>
        /// <param name="message">Message that describes the error.</param>
        public PortableDeviceException(string message) : base(message) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="PortableDeviceException"/> class with a custom error message and a reference to the inner exception that thrown this exception.
        /// </summary>
        /// <param name="message">Message that describes the error.</param>
        /// <param name="innerException">The exception that thrown  the current exception, or a <see langword="null"/> reference (<see langword="Nothing"/> in Visual Basic) if no inner exception is given.</param>
        public PortableDeviceException(string message, Exception innerException) : base(message, innerException) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="PortableDeviceException"/> class with serialized data.
        /// </summary>
        /// <param name="info"><see cref="SerializationInfo"/> that contains the serialized object data about the thrown exception.</param>
        /// <param name="context"><see cref="StreamingContext"/> that contains contextual information about the source or the destination.</param>
        /// <exception cref="ArgumentNullException"><paramref name="info"/> is <see langword="null"/>.</exception>
        /// <exception cref="SerializationException">The class name is <see langword="null"/> or <see cref="System.Exception.HResult"/> is zero (0).</exception>
        [SecuritySafeCritical]
        protected PortableDeviceException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
