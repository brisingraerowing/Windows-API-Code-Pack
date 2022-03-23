//Copyright (c) Pierre Sprimont.  All rights reserved.

using Microsoft.WindowsAPICodePack.Win32Native;

using System;
using System.Reflection;

namespace Microsoft.WindowsAPICodePack.PortableDevices
{
    public struct ClientVersion
    {
        public string ClientName { get; }
        public uint MajorVersion { get; }
        public uint MinorVersion { get; }
        public uint Revision { get; }

        public ClientVersion(in string clientName, in uint majorVersion, in uint minorVersion, in uint revision)
        {
            ClientName = clientName;

            MajorVersion = majorVersion;

            MinorVersion = minorVersion;

            Revision = revision;
        }

        public ClientVersion(in string clientName, in Version version) : this(clientName, (uint)version.Major, (uint)version.Minor, (uint)version.Revision)
        {
            // Left empty.
        }

        public ClientVersion(in AssemblyName assemblyName) : this(assemblyName.Name, assemblyName.Version)
        {
            // Left empty.
        }

        public override bool Equals(object obj) => obj is ClientVersion _obj ? _obj.ClientName == ClientName && _obj.MajorVersion == MajorVersion && _obj.MinorVersion == MinorVersion && _obj.Revision == Revision : false;

        public override int GetHashCode() => ClientName.GetHashCode() ^ MajorVersion.GetHashCode() ^ MinorVersion.GetHashCode() ^ Revision.GetHashCode();

        public static bool operator ==(ClientVersion left, ClientVersion right) => left.Equals(right);

        public static bool operator !=(ClientVersion left, ClientVersion right) => !(left == right);
    }

    public struct PortableDeviceOpeningOptions
    {
        public GenericRights GenericRights { get; }

        public FileShareOptions FileShare { get; }

        public bool ManualCloseOnDisconnect { get; }

        public PortableDeviceOpeningOptions(in GenericRights genericRights, in FileShareOptions fileShare, in bool manualCloseOnDisconnect)
        {
            GenericRights = genericRights;

            FileShare = fileShare;

            ManualCloseOnDisconnect = manualCloseOnDisconnect;
        }
    }
}
