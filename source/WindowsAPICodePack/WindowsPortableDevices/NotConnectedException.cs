using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.WindowsAPICodePack.PortableDevices
{
    public class NotConnectedException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NotConnectedException"/> class.
        /// </summary>
        public NotConnectedException() : base() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="NotConnectedException"/> class with a custom error message.
        /// </summary>
        /// <param name="message">Message that describes the error.</param>
        public NotConnectedException(string message) : base(message) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="NotConnectedException"/> class with a custom error message and a reference to the inner exception that thrown this exception.
        /// </summary>
        /// <param name="message">Message that describes the error.</param>
        /// <param name="innerException">The exception that thrown  the current exception, or a <see langword="null"/> reference (<see langword="Nothing"/> in Visual Basic) if no inner exception is given.</param>
        public NotConnectedException(string message, Exception innerException) : base(message, innerException) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="NotConnectedException"/> class with serialized data.
        /// </summary>
        /// <param name="info"><see cref="SerializationInfo"/> that contains the serialized object data about the thrown exception.</param>
        /// <param name="context"><see cref="StreamingContext"/> that contains contextual information about the source or the destination.</param>
        /// <exception cref="ArgumentNullException"><paramref name="info"/> is <see langword="null"/>.</exception>
        /// <exception cref="SerializationException">The class name is <see langword="null"/> or <see cref="System.Exception.HResult"/> is zero (0).</exception>
        [SecuritySafeCritical]
        protected NotConnectedException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
