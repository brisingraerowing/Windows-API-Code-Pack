//Copyright (c) Microsoft Corporation.  All rights reserved.  Distributed under the Microsoft Public License (MS-PL)

using Microsoft.WindowsAPICodePack.COMNative.Net;
using Microsoft.WindowsAPICodePack.COMNative.NetworkList;
using Microsoft.WindowsAPICodePack.Win32Native;

using System;

#if !WAPICP3
using WinCopies.Util;
#endif

namespace Microsoft.WindowsAPICodePack.Net
{
    /// <summary>
    /// Provides access to objects that represent networks and network connections.
    /// </summary>
    public static class NetworkListManager
    {
        private static readonly NetworkListManagerClass _manager = new
#if !CS9
            NetworkListManagerClass
#endif
            ();

        /// <summary>
        /// Gets a value that indicates whether this machine 
        /// has Internet connectivity.
        /// </summary>
        /// <value>A <see cref="bool"/> value.</value>
        public static bool IsConnectedToInternet => GetValue(() => _manager.IsConnectedToInternet);

        /// <summary>
        /// Gets a value that indicates whether this machine 
        /// has network connectivity.
        /// </summary>
        /// <value>A <see cref="bool"/> value.</value>
        public static bool IsConnected => GetValue(() => _manager.IsConnected);

        /// <summary>
        /// Gets the connectivity state of this machine.
        /// </summary>
        /// <value>A <see cref="Connectivity"/> value.</value>
        public static ConnectivityStates Connectivity => GetValue(_manager.GetConnectivity);

        private static T GetValue<T>(in Func<T> func)
        {
            // Throw PlatformNotSupportedException if the user is not running Vista or beyond
            CoreHelpers.ThrowIfNotVista();

            return func();
        }

#if !WAPICP3
        private static U GetValue<T, U>(in T value, in FuncIn<T, U> func)
        {
            // Throw PlatformNotSupportedException if the user is not running Vista or beyond
            CoreHelpers.ThrowIfNotVista();

            return func(value);
        }
#endif

        /// <summary>
        /// Retrieves a collection of <see cref="Network"/> objects that represent the networks defined for this machine.
        /// </summary>
        /// <param name="level">
        /// The <see cref="NetworkConnectivityLevels"/> that specify the connectivity level of the returned <see cref="Network"/> objects.
        /// </param>
        /// <returns>
        /// A <see cref="NetworkCollection"/> of <see cref="Network"/> objects.
        /// </returns>
        public static NetworkCollection GetNetworks(
#if !WAPICP3
            in
#endif
            NetworkConnectivityLevels level) => GetValue(
#if !WAPICP3
                level,
#endif
                (
#if !WAPICP3
                    in NetworkConnectivityLevels _level
#endif
                ) => new NetworkCollection(_manager.GetNetworks(
#if WAPICP3
                    level
#else
                    _level
#endif
                )));

        /// <summary>
        /// Retrieves the <see cref="Network"/> identified by the specified network identifier.
        /// </summary>
        /// <param name="networkId">
        /// A <see cref="Guid"/> that specifies the unique identifier for the network.
        /// </param>
        /// <returns>
        /// The <see cref="Network"/> that represents the network identified by the identifier.
        /// </returns>
        public static Network GetNetwork(
#if !WAPICP3
            in
#endif
            Guid networkId) => GetValue(
#if !WAPICP3
                networkId,
#endif
                (
#if !WAPICP3
                    in Guid _networkId
#endif
                ) => new Network(_manager.GetNetwork(
#if WAPICP3
                    networkId
#else
                    _networkId
#endif
                )));

        /// <summary>
        /// Retrieves a collection of <see cref="NetworkConnection"/> objects that represent the connections for this machine.
        /// </summary>
        /// <returns>
        /// A <see cref="NetworkConnectionCollection"/> containing the network connections.
        /// </returns>
        public static NetworkConnectionCollection GetNetworkConnections() => GetValue(() => new NetworkConnectionCollection(_manager.GetNetworkConnections()));

        /// <summary>
        /// Retrieves the <see cref="NetworkConnection"/> identified by the specified connection identifier.
        /// </summary>
        /// <param name="networkConnectionId">
        /// A <see cref="Guid"/> that specifies the unique identifier for the network connection.
        /// </param>
        /// <returns>
        /// The <see cref="NetworkConnection"/> identified by the specified identifier.
        /// </returns>
        public static NetworkConnection GetNetworkConnection(
#if !WAPICP3
            in
#endif
            Guid networkConnectionId) => GetValue(
#if !WAPICP3
                networkConnectionId,
#endif
                (
#if !WAPICP3
                    in Guid _networkConnectionId
#endif
                ) => new NetworkConnection(_manager.GetNetworkConnection(
#if WAPICP3
                    networkConnectionId
#else
                    _networkConnectionId
#endif
                )));
    }
}
