#if WAPICP3 && CS5
using Microsoft.WindowsAPICodePack.Win32Native;
using Microsoft.WindowsAPICodePack.Win32Native.Net;

using System;
using System.Net;
using System.Security;

using static Microsoft.WindowsAPICodePack.Win32Native.CoreErrorHelper;
using static Microsoft.WindowsAPICodePack.Win32Native.Net.NativeMethods;

using static WinCopies.ThrowHelper;

namespace Microsoft.WindowsAPICodePack.Net
{
    public struct InternetConnectionHandles
    {
        public IntPtr Handle;

        public IntPtr ConnectionHandle;
    }

    public struct InternetConnectionProxyInfo
    {
        public string
#if CS8
            ?
#endif
            Proxy
        { get; }

        public string
#if CS8
            ?
#endif
            ProxyBypass
        { get; }

        public InternetConnectionProxyInfo(in string
#if CS8
            ?
#endif
            proxy, in string
#if CS8
            ?
#endif
            proxyBypass)
        {
            Proxy = proxy;

            ProxyBypass = proxyBypass;
        }
    }

    public struct InternetConnectionData
    {
        public string UserName
        {
            get;
#if CS9
            init;
#endif
        }

        public string ClientName
        {
            get;
#if CS9
            init;
#endif
        }

        public string ServerName
        {
            get;
#if CS9
            init;
#endif
        }

#if !CS9
        public InternetConnectionData(in string userName, in string clientName, in string serverName)
        {
            UserName = userName;

            ClientName = clientName;

            ServerName = serverName;
        }
#endif
    }

    internal struct InternetConnectionDataExtended
    {
        public InternetConnectionHandles Handles;

        public InternetConnectionProxyInfo ProxyInfo { get; }

        public InternetConnectionData Data { get; }

        public InternetConnectionDataExtended(in InternetConnectionHandles handles, in InternetConnectionProxyInfo? proxyInfo, in InternetConnectionData data)
        {
            Handles = handles;

            ProxyInfo = proxyInfo ?? new InternetConnectionProxyInfo(null, null);

            Data = data;
        }
    }

    public class InternetConnection : IInternetConnection
    {
        InternetConnectionDataExtended _data;

        protected IntPtr Handle => _data.Handles.Handle;

        protected IntPtr ConnectionHandle => _data.Handles.ConnectionHandle;

        public InternetOpenType InternetOpenType { get; }

        public InternetFlags OpeningFlags { get; }

        public InternetFlags ConnectionFlags { get; }

        public bool IsOpen => _data.Handles.Handle != IntPtr.Zero;

        public bool IsConnected => _data.Handles.ConnectionHandle != IntPtr.Zero;

        public InternetPort InternetPort { get; }

        public InternetService InternetService { get; }

        public string UserName => _data.Data.UserName;

        public string ClientName => _data.Data.ClientName;

        public string ServerName => _data.Data.ServerName;

        public InternetConnection(InternetConnectionData connectionInfo, in InternetOpenType internetOpenType, in InternetConnectionProxyInfo? proxyInfo, in InternetFlags openingFlags, in InternetPort internetPort, in InternetService internetService, in InternetFlags connectionFlags)
        {
            _data = new InternetConnectionDataExtended(new InternetConnectionHandles(), proxyInfo, connectionInfo);

            InternetOpenType = internetOpenType;

            OpeningFlags = openingFlags;

            InternetPort = internetPort;

            InternetService = internetService;

            ConnectionFlags = connectionFlags;
        }

        protected virtual void OnOpen() { /* Left empty. */ }

        public bool TryOpen()
        {
            InternetConnectionProxyInfo proxyInfo = _data.ProxyInfo;

            if ((_data.Handles.Handle = InternetOpen(_data.Data.ClientName, InternetOpenType, proxyInfo.Proxy, proxyInfo.ProxyBypass, OpeningFlags)) != IntPtr.Zero)
            {
                OnOpen();

                return true;
            }

            return false;
        }

        protected T RunActionIfConnected<T>(in Func<T> func)
        {
            ThrowIfNull(func, nameof(func));

            return IsConnected ? func() : throw new InvalidOperationException("The connection is not open.");
        }

        public void Open() => RunWin32Action(TryOpen);

        protected virtual void OnConnected() { /* Left empty. */ }

        public bool TryConnect( SecureString password)
        {
            if (!IsOpen && !TryOpen())

                return false;

            var data = _data.Data;

            if ((_data.Handles.ConnectionHandle = InternetConnect(_data.Handles.Handle, data.ServerName, InternetPort, data.UserName, new NetworkCredential(data.UserName, password).Password, InternetService, ConnectionFlags, (UIntPtr)1)) != IntPtr.Zero)
            {
                OnConnected();

                return true;
            }

            return false;
        }

        public void Connect(SecureString password) => RunWin32Action(() => TryConnect(password));

        protected virtual void OnDisconnected() { /* Left empty. */ }

        public void Disconnect()
        {
            if (IsConnected)
            {
                _ = InternetCloseHandle(_data.Handles.ConnectionHandle);

                OnDisconnected();
            }
        }

        protected virtual void OnClosed() { /* Left empty. */ }

        public void Close()
        {
            if (IsOpen)
            {
                Disconnect();

                _ = InternetCloseHandle(_data.Handles.Handle);

                OnClosed();
            }
        }

        protected virtual void DisposeUnmanaged() => Close();

        protected virtual void DisposeManaged() { /* Left empty. */ }

        ~InternetConnection() => DisposeUnmanaged();

        public void Dispose()
        {
            DisposeManaged();
            DisposeUnmanaged();

            GC.SuppressFinalize(this);
        }
    }
}
#endif
