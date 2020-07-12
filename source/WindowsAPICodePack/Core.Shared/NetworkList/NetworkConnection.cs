//Copyright (c) Microsoft Corporation.  All rights reserved.  Distributed under the Microsoft Public License (MS-PL)

using Microsoft.WindowsAPICodePack.COMNative.Net;
using Microsoft.WindowsAPICodePack.COMNative.NetworkList;
using System;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Microsoft.WindowsAPICodePack.Net
{
    /// <summary>
    /// Represents a connection to a network.
    /// </summary>
    /// <remarks> A collection containing instances of this class is obtained by calling
    /// the <see cref="P:Microsoft.WindowsAPICodePack.Net.Network.Connections"/> property.</remarks>
    public class NetworkConnection
    {
        #region Private Fields

        readonly INetworkConnection networkConnection;

        #endregion // Private Fields

        internal NetworkConnection(in INetworkConnection networkConnection) => this.networkConnection = networkConnection;

        /// <summary>
        /// Retrieves an object that represents the network 
        /// associated with this connection.
        /// </summary>
        /// <returns>A <see cref="Network"/> object.</returns>
        public Network Network => new Network(networkConnection.GetNetwork());

        /// <summary>
        /// Gets the adapter identifier for this connection.
        /// </summary>
        /// <value>A <see cref="Guid"/> object.</value>
        public Guid AdapterId => networkConnection.GetAdapterId();

        /// <summary>
        /// Gets the unique identifier for this connection.
        /// </summary>
        /// <value>A <see cref="Guid"/> object.</value>
        public Guid ConnectionId => networkConnection.GetConnectionId();

        /// <summary>
        /// Gets a value that indicates the connectivity of this connection.
        /// </summary>
        /// <value>A <see cref="Connectivity"/> value.</value>
        public ConnectivityStates Connectivity => networkConnection.GetConnectivity();

        /// <summary>
        /// Gets a value that indicates whether the network associated
        /// with this connection is 
        /// an Active Directory network and whether the machine
        /// has been authenticated by Active Directory.
        /// </summary>
        /// <value>A <see cref="DomainType"/> value.</value>
        public DomainType DomainType => networkConnection.GetDomainType();

        /// <summary>
        /// Gets a value that indicates whether this 
        /// connection has Internet access.
        /// </summary>
        /// <value>A <see cref="bool"/> value.</value>
        public bool IsConnectedToInternet => networkConnection.IsConnectedToInternet;

        /// <summary>
        /// Gets a value that indicates whether this connection has
        /// network connectivity.
        /// </summary>
        /// <value>A <see cref="bool"/> value.</value>
        public bool IsConnected => networkConnection.IsConnected;
    }
}