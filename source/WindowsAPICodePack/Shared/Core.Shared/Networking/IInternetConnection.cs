using Microsoft.WindowsAPICodePack.Win32Native.Net;

using System.Collections;
using System.Security;

namespace Microsoft.WindowsAPICodePack.Net
{
    public interface IInternetConnection : System.IDisposable
    {
        InternetOpenType InternetOpenType { get; }

        InternetFlags OpeningFlags { get; }

        InternetFlags ConnectionFlags { get; }

        bool IsOpen { get; }

        bool IsConnected { get; }

        InternetPort InternetPort { get; }

        InternetService InternetService { get; }

        string UserName { get; }

        string ClientName { get; }

        string ServerName { get; }

        bool TryOpen();

        void Open();

        bool TryConnect( SecureString password);

        void Connect(SecureString password);

        void Disconnect();

        void Close();
    }
}
