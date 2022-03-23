//Copyright (c) Microsoft Corporation.  All rights reserved.  Distributed under the Microsoft Public License (MS-PL)

using Microsoft.WindowsAPICodePack.COMNative.Net;

using System.Collections;
using System.Collections.Generic;

namespace Microsoft.WindowsAPICodePack.Net
{
    /// <summary>
    /// An enumerable collection of <see cref="NetworkConnection"/> objects.
    /// </summary>
    public class NetworkConnectionCollection : IEnumerable<NetworkConnection>
    {
        readonly IEnumerable _networkConnectionEnumerable;

        internal NetworkConnectionCollection(in IEnumerable networkConnectionEnumerable) => this._networkConnectionEnumerable = networkConnectionEnumerable;

        #region IEnumerable<NetworkConnection> Members
        /// <summary>
        /// Returns the strongly typed enumerator for this collection.
        /// </summary>
        /// <returns>A <see cref="IEnumerator{T}"/> object.</returns>
        public IEnumerator<NetworkConnection> GetEnumerator()
        {
            foreach (INetworkConnection networkConnection in _networkConnectionEnumerable)

                yield return new NetworkConnection(networkConnection);
        }
        #endregion

        #region IEnumerable Members
        /// <summary>
        /// Returns the enumerator for this collection.
        /// </summary>
        ///<returns>A <see cref="IEnumerator"/> object.</returns>
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        #endregion
    }
}