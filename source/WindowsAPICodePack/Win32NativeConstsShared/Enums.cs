using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.WindowsAPICodePack.Win32Native
{
    /// <summary>
    /// The facility codes
    /// </summary>
    public enum HResultFacility
    {
        Null = 0,
        RPC = 1,
        Dispatch = 2,
        Storage = 3,
        ITF = 4,
        Win32 = 7,
        Windows = 8,
        SSPI = 9,
        Security = 9,
        Control = 10,
        Cert = 11,
        Internet = 12,
        MediaServer = 13,
        MSMQ = 14,
        SetupAPI = 15,
        SCard = 16,
        COMPlus = 17,
        AAF = 18,
        URT = 19,
        ACS = 20,
        DPlay = 21,
        UMI = 22,
        SXS = 23,
        WindowsCE = 24,
        HTTP = 25,
        UserModeCommonLog = 26,
        WER = 27,
        UserModeFilterManager = 31,
        BackgroundCopy = 32,
        Configuration = 33,
        WIA = 33,
        StateManagement = 34,
        MetaDirectory = 35,
        WindowsUpdate = 36,
        DirectoryService = 37,
        Graphics = 38,
        Shell = 39,
        NAP = 39,
        TPMServices = 40,
        TPMSoftware = 41,
        UI = 42,
        XAML = 43,
        ActionQueue = 44,
        PLA = 48,
        WindowsSetup = 48,
        FVE = 49,
        FWP = 50,
        WinRM = 51,
        NDIS = 52,
        UserModeHypervisor = 53,
        CMI = 54,
        UserModeVirtualization = 55,
        UserModeVolMgr = 56,
        BCD = 57,
        UserModeVhd = 58,
        UserModeHNS = 59,
        SDIAG = 60,
        WebServices = 61,
        WinPE = 61,
        WPN = 62,
        WindowsStore = 63,
        Input = 64,
        EAP = 66,
        WindowsDefender = 80,
        OPC = 81,
        XPS = 82,
        MBN = 84,
        PowerShell = 84,
        RAS = 83,
        P2PInt = 98,
        P2P = 99,
        DAF = 100,
        BluetoothAtt = 101,
        Audio = 102,
        StateRepository = 103,
        VisualCpp = 109,
        Script = 112,
        Parse = 113,
        BLB = 120,
        BLBCLI = 121,
        WSBApp = 122,
        BLBUI = 128,
        USN = 129,
        UserModeVolSnap = 130,
        Tiering = 131,
        WSBOnline = 133,
        OnlineId = 134,
        DeviceUpdateAgent = 135,
        DRVServicing = 136,
        DLS = 153,
        DeliveryOptimization = 208,
        UserModeSpaces = 231,
        UserModeSecurityCore = 232,
        UserModeLicensing = 234,
        SOS = 160,
        Debuggers = 176,
        SPP = 256,
        Restore = 256,
        DMServer = 256,
        DeploymentServicesServer = 257,
        DeploymentServicesImaging = 258,
        DeploymentServicesManagement = 259,
        DeploymentServicesUtil = 260,
        DeploymentServicesBinlSvc = 261,
        DeploymentServicesPXE = 263,
        DeploymentServicesTFTP = 264,
        DeploymentServicesTransportManagement = 272,
        DeploymentServicesDriverProvisioning = 278,
        DeploymentServicesMulticastServer = 289,
        DeploymentServicesMulticastClient = 290,
        DeploymentServicesContentProvider = 293,
        LinguisticServices = 305,
        AudioStreaming = 1094,
        Accelerator = 1536,
        WMAAEcma = 1996,
        DirectMusic = 2168,
        Direct3D10 = 2169,
        DXGI = 2170,
        DXGI_DDI = 2171,
        Direct3D11 = 2172,
        Direct3D11Debug = 2173,
        Direct3D12 = 2174,
        Direct3D12Debug = 2175,
        Leap = 2184,
        Audclnt = 2185,
        WinCodecDWriteDWM = 2200,
        WinML = 2192,
        Direct2D = 2201,
        Defrag = 2304,
        UserModeSDBus = 2305,
        JScript = 2306,
        PIDGenX = 2561,
        EAS = 85,
        Web = 885,
        WebSocket = 886,
        Mobile = 1793,
        SQLite = 1967,
        UTC = 1989,
        WEP = 2049,
        SyncEngine = 2050,
        Xbox = 2339,
        PIX = 2748

    }

    public enum HResult

    {

        /// <summary>
        /// Win32 Error code: ERROR_CANCELLED
        /// </summary>
        Win32ErrorCanceled = 1223, // TODO: This is a Win32 error code and should be removed from this enum.

        /// <summary>
        /// ERROR_CANCELLED
        /// </summary>
        Canceled = unchecked((int)0x800704C7), // TODO: This is from a Win32 error code and should be removed from this enum.

        /// <summary>
        /// E_ELEMENTNOTFOUND
        /// </summary>
        ElementNotFound = unchecked((int)0x80070490),

        /// <summary>     
        /// S_OK          
        /// </summary>    
        Ok = 0x0000,

        /// <summary>
        /// NOERROR
        /// </summary>
        NoError = Ok,

        /// <summary>
        /// S_FALSE
        /// </summary>        
        False = 0x0001,

        //
        // Codes 0x4000-0x40ff are reserved for OLE
        //
        //
        // Error codes
        //

        /// <summary>
        /// <para>MessageId: E_UNEXPECTED</para>
        /// <para>MessageText: Catastrophic failure</para>
        /// </summary>
        Unexpected = unchecked((int)0x8000FFFF),

        /// <summary>
        /// <para>MessageId: E_NOTIMPL</para>
        /// <para>MessageText: Not implemented</para>
        /// </summary>
        NotImplemented = unchecked((int)0x80004001),

        /// <summary>
        /// <para>MessageId: E_OUTOFMEMORY</para>
        /// <para>MessageText: Ran out of memory</para>
        /// </summary>
        OutOfMemory = unchecked((int)0x8007000E),

        /// <summary>
        /// <para>MessageId: E_INVALIDARG</para>
        /// <para>MessageText: One or more arguments are invalid</para>
        /// </summary>
        InvalidArguments = unchecked((int)0x80070057),

        /// <summary>
        /// <para>MessageId: E_NOINTERFACE</para>
        /// <para>MessageText: No such interface supported</para>
        /// </summary>
        NoInterface = unchecked((int)0x80004002),

        /// <summary>
        /// <para>MessageId: E_POINTER</para>
        /// <para>MessageText: Invalid pointer</para>
        /// </summary>
        InvalidPointer = unchecked((int)0x80004003),

        /// <summary>
        /// <para>MessageId: E_HANDLE</para>
        /// <para>MessageText: Invalid handle</para>
        /// </summary>
        InvalidHandle = unchecked((int)0x80070006),

        /// <summary>
        /// <para>MessageId: E_ABORT</para>
        /// <para>MessageText: Operation aborted</para>
        /// </summary>
        Abort = unchecked((int)0x80004004),

        /// <summary>
        /// <para>MessageId: E_FAIL</para>
        /// <para>MessageText: Unspecified error</para>
        /// </summary>
        Fail = unchecked((int)0x80004005),

        /// <summary>
        /// <para>MessageId: E_ACCESSDENIED</para>
        /// <para>MessageText: General access denied error</para>
        /// </summary>
        AccessDenied = unchecked((int)0x80070005),

        /// <summary>
        /// <para>MessageId: E_PENDING</para>
        /// <para>MessageText: The data necessary to complete this operation is not yet available.</para>
        /// </summary>
        Pending = unchecked((int)0x8000000A),

        /// <summary>
        /// <para>MessageId: E_BOUNDS</para>
        /// <para>MessageText: The operation attempted to access data outside the valid range</para>
        /// </summary>
        Bounds = unchecked((int)0x8000000B),

        /// <summary>
        /// <para>MessageId: E_CHANGED_STATE</para>
        /// <para>MessageText: A concurrent or interleaved operation changed the state of the object, invalidating this operation.</para>
        /// </summary>
        ChangedState = unchecked((int)0x8000000C),

        /// <summary>
        /// <para>MessageId: E_ILLEGAL_STATE_CHANGE</para>
        /// <para>MessageText: An illegal state change was requested.</para>
        /// </summary>
        IllegalStateChange = unchecked((int)0x8000000D),

        /// <summary>
        /// <para>MessageId: E_ILLEGAL_METHOD_CALL</para>
        /// <para>MessageText: A method was called at an unexpected time.</para>
        /// </summary>
        IllegalMethodCall = unchecked((int)0x8000000E),

        /// <summary>
        /// <para>MessageId: RO_E_METADATA_NAME_NOT_FOUND</para>
        /// <para>MessageText: Typename or Namespace was not found in metadata file.</para>
        /// </summary>
        MetadataNameNotFound = unchecked((int)0x8000000F),

        /// <summary>
        /// <para>MessageId: RO_E_METADATA_NAME_IS_NAMESPACE</para>
        /// <para>MessageText: Name is an existing namespace rather than a typename.</para>
        /// </summary>
        MetadataNameIsNamespace = unchecked((int)0x80000010),

        /// <summary>
        /// <para>MessageId: RO_E_METADATA_INVALID_TYPE_FORMAT</para>
        /// <para>MessageText: Typename has an invalid format.</para>
        /// </summary>
        MetadataInvalidTypeFormat = unchecked((int)0x80000011),

        /// <summary>
        /// <para>MessageId: RO_E_INVALID_METADATA_FILE</para>
        /// <para>MessageText: Metadata file is invalid or corrupted.</para>
        /// </summary>
        InvalidMetadataFile = unchecked((int)0x80000012),



        /// <summary>
        /// <para>MessageId: INPLACE_S_TRUNCATED</para>
        /// <para>MessageText: Message is too long; some of it had to be truncated before displaying</para>
        /// </summary>
        InPlaceStringTruncated = 0x000401A0,



        /// <summary>
        /// <para>MessageId: MK_E_NOOBJECT</para>
        /// <para>MessageText: No object for moniker</para>
        /// </summary>
        NoObject = unchecked((int)0x800401E5)

    }
}
