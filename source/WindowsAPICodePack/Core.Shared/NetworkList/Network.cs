//Copyright (c) Microsoft Corporation.  All rights reserved.  Distributed under the Microsoft Public License (MS-PL)

using Microsoft.WindowsAPICodePack.COMNative.Net;
using Microsoft.WindowsAPICodePack.COMNative.NetworkList;

using System;

namespace Microsoft.WindowsAPICodePack.Net
{
    /// <summary>
    /// Represents a network on the local machine. 
    /// It can also represent a collection of network 
    /// connections with a similar network signature.
    /// </summary>
    /// <remarks>
    /// Instances of this class are obtained by calling 
    /// methods on the <see cref="NetworkListManager"/> class.
    /// </remarks>
    public class Network
    {
        readonly INetwork _network;

        internal Network(in INetwork network) => this._network = network;

        /// <summary>
        /// Gets or sets the category of a network. The 
        /// categories are trusted, untrusted, or 
        /// authenticated.
        /// </summary>
        /// <value>A <see cref="NetworkCategory"/> value.</value>
        public NetworkCategory Category
        {
            get => _network.GetCategory();

            set => _network.SetCategory(value);
        }

        /// <summary>
        /// Gets the local date and time when the network 
        /// was connected.
        /// </summary>
        /// <value>A <see cref="System.DateTime"/> object.</value>
        public System.DateTime ConnectedTime
        {
            get
            {
                _network.GetTimeCreatedAndConnected(out _, out _, out uint low, out uint high);
                long time = high;
                // Shift the day info into the high order bits.
                time <<= 32;
                time |= low;
                return System.DateTime.FromFileTimeUtc(time);
            }
        }

        /// <summary>
        /// Gets the network connections for the network.
        /// </summary>
        /// <value>A <see cref="NetworkConnectionCollection"/> object.</value>
        public NetworkConnectionCollection Connections => new NetworkConnectionCollection(_network.GetNetworkConnections());

        /// <summary>
        /// Gets the connectivity state of the network.
        /// </summary>
        /// <value>A <see cref="Connectivity"/> value.</value>
        /// <remarks>Connectivity provides information on whether
        /// the network is connected, and the protocols
        /// in use for network traffic.</remarks>
        public ConnectivityStates Connectivity => _network.GetConnectivity();

        /// <summary>
        /// Gets the local date and time when the 
        /// network was created.
        /// </summary>
        /// <value>A <see cref="System.DateTime"/> object.</value>
        public System.DateTime CreatedTime
        {
            get
            {
                _network.GetTimeCreatedAndConnected(out uint low, out uint high, out _, out _);
                long time = high;
                //Shift the value into the high order bits.
                time <<= 32;
                time |= low;
                return System.DateTime.FromFileTimeUtc(time);
            }
        }

        /// <summary>
        /// Gets or sets a description for the network.
        /// </summary>
        /// <value>A <see cref="string"/> value.</value>
        public string Description
        {
            get => _network.GetDescription();

            set => _network.SetDescription(value);
        }

        /// <summary>
        /// Gets the domain type of the network. 
        /// </summary>
        /// <value>A <see cref="DomainType"/> value.</value>
        /// <remarks>The domain
        /// indictates whether the network is an Active
        /// Directory Network, and whether the machine
        /// has been authenticated by Active Directory.</remarks>
        public DomainType DomainType => _network.GetDomainType();

        /// <summary>
        /// Gets a value that indicates whether there is
        /// network connectivity.
        /// </summary>
        /// <value>A <see cref="bool"/> value.</value>
        public bool IsConnected => _network.IsConnected;

        /// <summary>
        /// Gets a value that indicates whether there is 
        /// Internet connectivity.
        /// </summary>
        /// <value>A <see cref="bool"/> value.</value>
        public bool IsConnectedToInternet => _network.IsConnectedToInternet;

        /// <summary>
        /// Gets or sets the name of the network.
        /// </summary>
        /// <value>A <see cref="string"/> value.</value>
        public string Name
        {
            get => _network.GetName();

            set => _network.SetName(value);
        }

        /// <summary>
        /// Gets a unique identifier for the network.
        /// </summary>
        /// <value>A <see cref="Guid"/> value.</value>
        public Guid NetworkId => _network.GetNetworkId();
    }
}