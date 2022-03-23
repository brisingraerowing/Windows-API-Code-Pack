namespace Microsoft.WindowsAPICodePack.Win32Native.Net
{
    public enum InternetPort : ushort
    {
        /// <summary>
        /// Uses the default port for the service specified by dwService.
        /// </summary>
        InternetInvalidPortNumber = 0, // use the protocol-specific default

        /// <summary>
        /// Uses the default port for FTP servers (port 21).
        /// </summary>
        DefaultFTPPort = 21, // default for FTP servers

        /// <summary>
        /// <para>Uses the default port for Gopher servers (port 70).</para>
        /// <para>Note: Windows XP and Windows Server 2003 R2 and earlier only.</para>
        /// </summary>
        DefaultGopherPort = 70, //    "     "  gopher "

        /// <summary>
        /// Uses the default port for HTTP servers (port 80).
        /// </summary>
        DefaultHTTPPort = 80, //    "     "  HTTP   "

        /// <summary>
        /// Uses the default port for Secure Hypertext Transfer Protocol (HTTPS) servers (port 443).
        /// </summary>
        DefaultHTTPSPort = 443, //    "     "  HTTPS  "

        /// <summary>
        /// Uses the default port for SOCKS firewall servers (port 1080).
        /// </summary>
        DefaultSocksPort = 1080 // default for SOCKS firewall servers.
    }

    public enum InternetService : uint
    {
        /// <summary>
        /// FTP service.
        /// </summary>
        FTP = 1,

        /// <summary>
        /// <para>Gopher service.</para>
        /// <para>Note: Windows XP and Windows Server 2003 R2 and earlier only.</para>
        /// </summary>
        Gopher = 2,

        /// <summary>
        /// HTTP service.
        /// </summary>
        HTTP = 3
    }

    public enum InternetFlags : uint
    {
        //
        // flags for IDN enable/disable via INTERNET_OPTION_IDN
        //
        IDNDirect = 0x00000001, // IDN enabled for direct connections
        IDNProxy = 0x00000002, // IDN enabled for proxy

        //
        // flags common to open functions (not InternetOpen()):
        //

        /// <summary>
        /// Forces a download of the requested file, object, or directory listing from the origin server, not from the cache.
        /// </summary>
        Reload = 0x80000000, // retrieve the original item

        //
        // flags for InternetOpenUrl():
        //

        RawData = 0x40000000, // FTP/gopher find: receive the item as raw (structured) data
        ExistingConnect = 0x20000000, // FTP: use existing InternetConnect handle for server if possible

        //
        // flags for InternetOpen():
        //

        Async = 0x10000000, // this request is asynchronous (where supported)

        //
        // protocol-specific flags:
        //

        Passive = 0x08000000, // used for FTP connections

        //
        // additional cache flags
        //

        NoCacheWrite = 0x04000000, // don't write this item to the cache
        DoNotCache = NoCacheWrite,
        MakePersistent = 0x02000000, // make this item persistent in cache
        FromCache = 0x01000000, // use offline semantics
        Offline = FromCache,

        //
        // additional flags
        //

        Secure = 0x00800000, // use PCT/SSL if applicable (HTTP)
        KeepConnection = 0x00400000, // use keep-alive semantics
        NoAutoRedirect = 0x00200000, // don't handle redirections automatically
        ReadPrefetch = 0x00100000, // do background read prefetch
        NoCookies = 0x00080000, // no automatic cookie handling
        NoAuth = 0x00040000, // no automatic authentication handling
        RestrictedZone = 0x00020000, // apply restricted zone policies for cookies, auth
        CacheIfNetFail = 0x00010000, // return cache file if net request fails

        //
        // Security Ignore Flags, Allow HttpOpenRequest to overide
        //  Secure Channel (SSL/PCT) failures of the following types.
        //

        IgnoreRedirectToHTTP = 0x00008000, // ex: https:// to http://
        IgnoreRedirectToHTTPS = 0x00004000, // ex: http:// to https://
        IgnoreCertDateInvalid = 0x00002000, // expired X509 Cert.
        IgnoreCertCNInvalid = 0x00001000, // bad common name in X509 Cert.

        //
        // more caching flags
        //

        /// <summary>
        /// <para>Reloads HTTP resources if the resource has been modified since the last time it was downloaded. All FTP resources are reloaded.</para>
        /// <para>Windows XP and Windows Server 2003 R2 and earlier: Gopher resources are also reloaded.</para>
        /// </summary>
        Resynchronize = 0x00000800, // asking wininet to update an item if it is newer

        /// <summary>
        /// Forces a reload if there was no Expires time and no LastModified time returned from the server when determining whether to reload the item from the network.
        /// </summary>
        Hyperlink = 0x00000400, // asking wininet to do hyperlinking semantic which works right for scripts
        NoUI = 0x00000200, // no cookie popup
        PragmaNoCache = 0x00000100, // asking wininet to add "pragma: no-cache"
        CacheAsync = 0x00000080, // ok to perform lazy cache-write
        FormsSubmit = 0x00000040, // this is a forms submit
        ForwardBack = 0x00000020, // fwd-back button op

        /// <summary>
        /// Causes a temporary file to be created if the file cannot be cached.
        /// </summary>
        NeedFile = 0x00000010, // need a file for this request
        MustCacheRequest = NeedFile,

        //
        // flags for FTP
        //

        /// <summary>
        /// Transfers the file as ASCII.
        /// </summary>
        TransferASCII = FTP.TransferType.ASCII, // 0x00000001

        /// <summary>
        /// Transfers the file as binary.
        /// </summary>
        TransferBinary = FTP.TransferType.Binary, // 0x00000002
    }

    public enum InternetOpenType : uint
    {
        /// <summary>
        /// Retrieves the proxy or direct configuration from the registry.
        /// </summary>
        Preconfig = 0, // use registry configuration

        /// <summary>
        /// Resolves all host names locally.
        /// </summary>
        Direct = 1, // direct to net

        /// <summary>
        /// Passes requests to the proxy unless a proxy bypass list is supplied and the name to be resolved bypasses the proxy. In this case, the function uses <see cref="Direct"/>.
        /// </summary>
        Proxy = 3, // via named proxy

        /// <summary>
        /// Retrieves the proxy or direct configuration from the registry and prevents the use of a startup Microsoft JScript or Internet Setup (INS) file.
        /// </summary>
        PreconfigWithNoAutoProxy = 4 // prevent using java/script/INS
    }

    /// <summary>
    /// Status manifests for Internet status callback.
    /// </summary>
    public enum InternetStatus
    {
        ResolvingName = 10,
        NameResolved = 11,
        ConnectingToServer = 20,
        ConnectedToServer = 21,
        SendingRequest = 30,
        RequestSent = 31,
        ReceivingResponse = 40,
        ResponseReceived = 41,
        CTLResponseReceived = 42,
        Prefetch = 43,
        ClosingConnection = 50,
        ConnectionClosed = 51,
        HandleCreated = 60,
        HandleClosing = 70,
        DetectingProxy = 80,
        RequestComplete = 100,
        Redirect = 110,
        IntermediateResponse = 120,
        UserInputRequired = 140,
        StateChange = 200,
        CookieSent = 320,
        CookieReceived = 321,
        PrivacyImpacted = 324,
        P3PHeader = 325,
        P3PPolicyRef = 326,
        CookieHistory = 327
    }
}
