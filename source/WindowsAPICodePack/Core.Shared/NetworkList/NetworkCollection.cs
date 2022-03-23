//Copyright (c) Microsoft Corporation.  All rights reserved.  Distributed under the Microsoft Public License (MS-PL)

using Microsoft.WindowsAPICodePack.COMNative.Net;

using System.Collections;
using System.Collections.Generic;

namespace Microsoft.WindowsAPICodePack.Net
{
    /// <summary>
    /// An enumerable collection of <see cref="Network"/> objects.
    /// </summary>
    public class NetworkCollection : IEnumerable<Network>
    {
        readonly IEnumerable _networkEnumerable;

        internal NetworkCollection(in IEnumerable networkEnumerable) => this._networkEnumerable = networkEnumerable;

        #region IEnumerable<Network> Members
        /// <summary>
        /// Returns the strongly typed enumerator for this collection.
        /// </summary>
        /// <returns>An <see cref="IEnumerator{T}"/>  object.</returns>
        public IEnumerator<Network> GetEnumerator()
        {
            foreach (INetwork network in _networkEnumerable)

                yield return new Network(network);
        }
        #endregion

        #region IEnumerable Members
        /// <summary>
        /// Returns the enumerator for this collection.
        /// </summary>
        ///<returns>An <see cref="IEnumerator"/> object.</returns>
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        #endregion
    }
}