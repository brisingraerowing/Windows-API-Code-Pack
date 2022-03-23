﻿//Copyright (c) Microsoft Corporation.  All rights reserved.  Distributed under the Microsoft Public License (MS-PL)

using Microsoft.WindowsAPICodePack.Win32Native.Resources;

using System;
using System.Runtime.InteropServices;

namespace Microsoft.WindowsAPICodePack.PropertySystem
{
    /// <summary>
    /// Defines a unique key for a Shell Property
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public struct PropertyKey : IEquatable<PropertyKey>
    {
        private Guid formatId;

        #region Public Properties
        /// <summary>
        /// A unique GUID for the property
        /// </summary>
        public Guid FormatId => formatId;

        /// <summary>
        ///  Property identifier (PID)
        /// </summary>
        public uint PropertyId { get; }
        #endregion

        #region Public Construction
        /// <summary>
        /// PropertyKey Constructor
        /// </summary>
        /// <param name="formatId">A unique GUID for the property</param>
        /// <param name="propertyId">Property identifier (PID)</param>
        public PropertyKey(Guid formatId, uint propertyId)
        {
            this.formatId = formatId;

            PropertyId = propertyId;
        }

        /// <summary>
        /// PropertyKey Constructor
        /// </summary>
        /// <param name="formatId">A string represenstion of a GUID for the property</param>
        /// <param name="propertyId">Property identifier (PID)</param>
        public PropertyKey(string formatId, uint propertyId) : this(new Guid(formatId), propertyId) { /* Left empty. */ }
        #endregion

        #region equality and hashing
        /// <summary>
        /// Returns whether this object is equal to another. This is vital for performance of value types.
        /// </summary>
        /// <param name="other">The object to compare against.</param>
        /// <returns>Equality result.</returns>
        public bool Equals(PropertyKey other) => other.Equals((object)this);

        /// <summary>
        /// Returns the hash code of the object. This is vital for performance of value types.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode() => formatId.GetHashCode() ^ (int)PropertyId;

        /// <summary>
        /// Returns whether this object is equal to another. This is vital for performance of value types.
        /// </summary>
        /// <param name="obj">The object to compare against.</param>
        /// <returns>Equality result.</returns>
        public override bool Equals(object obj) =>

            // PropertyKey other = (PropertyKey)obj;
            obj != null && obj is PropertyKey propertyKey && propertyKey.formatId.Equals(formatId) && (propertyKey.PropertyId == PropertyId);

        /// <summary>
        /// Implements the == (equality) operator.
        /// </summary>
        /// <param name="propKey1">First property key to compare.</param>
        /// <param name="propKey2">Second property key to compare.</param>
        /// <returns>true if object a equals object b. false otherwise.</returns>        
        public static bool operator ==(PropertyKey propKey1, PropertyKey propKey2) => propKey1.Equals(propKey2);

        /// <summary>
        /// Implements the != (inequality) operator.
        /// </summary>
        /// <param name="propKey1">First property key to compare</param>
        /// <param name="propKey2">Second property key to compare.</param>
        /// <returns>true if object a does not equal object b. false otherwise.</returns>
        public static bool operator !=(PropertyKey propKey1, PropertyKey propKey2) => !propKey1.Equals(propKey2);

        /// <summary>
        /// Override ToString() to provide a user friendly string representation
        /// </summary>
        /// <returns>String representing the property key</returns>        
        public override string ToString() => string.Format(System.Globalization.CultureInfo.InvariantCulture,
                LocalizedMessages.PropertyKeyFormatString,
                formatId.ToString("B"), PropertyId);
        #endregion
    }
}
