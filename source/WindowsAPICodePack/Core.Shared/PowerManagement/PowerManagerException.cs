﻿using System;

namespace Microsoft.WindowsAPICodePack.ApplicationServices
{
    /// <summary>
    /// This exception is thrown when there are problems with getting piece of data within PowerManager.
    /// </summary>
    [Serializable]
    public class PowerManagerException : Exception
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public PowerManagerException() { /* Left empty. */ }

        /// <summary>
        /// Initializes an excpetion with a custom message.
        /// </summary>
        /// <param name="message">A custom message for the exception.</param>
        public PowerManagerException(in string message) : base(message) { /* Left empty. */ }

        /// <summary>
        /// Initializes an exception with custom message and inner exception.
        /// </summary>
        /// <param name="message">A custom message for the exception.</param>
        /// <param name="innerException">An inner exception on which to base this exception.</param>
        public PowerManagerException(in string message, in Exception innerException)
            : base(message, innerException) { /* Left empty. */ }

        /// <summary>
        /// Initializes an exception from serialization info and a context.
        /// </summary>
        /// <param name="info">SerializationInfo for the exception.</param>
        /// <param name="context">StreamingContext for the exception.</param>
        protected PowerManagerException(
            in System.Runtime.Serialization.SerializationInfo info,
            in System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { /* Left empty. */ }
    }
}
