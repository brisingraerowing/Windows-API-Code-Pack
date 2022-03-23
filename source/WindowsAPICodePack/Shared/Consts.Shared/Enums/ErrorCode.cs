namespace Microsoft.WindowsAPICodePack.Win32Native
{
    public enum ErrorCode
    {
        /// <summary>
        /// <para>MessageId: ERROR_SUCCESS</para>
        /// <para>MessageText: The operation completed successfully.</para>
        /// </summary>
        Success = 0,

        NoError = 0,                                                 // dderror
                                                                     // SEC_E_OK                         ((HRESULT)0x00000000,)

        /// <summary>
        /// <para>MessageId: ERROR_INVALID_FUNCTION</para>
        /// <para>MessageText: Incorrect function.</para>
        /// </summary>
        InvalidFunction = 1,    // dderror

        /// <summary>
        /// <para>MessageId: ERROR_FILE_NOT_FOUND</para>
        /// <para>MessageText: The system cannot find the file specified.</para>
        /// </summary>
        FileNotFound = 2,

        /// <summary>
        /// <para>MessageId: ERROR_PATH_NOT_FOUND</para>
        /// <para>MessageText: The system cannot find the path specified.</para>
        /// </summary>
        PathNotFound = 3,

        /// <summary>
        /// <para>MessageId: ERROR_TOO_MANY_OPEN_FILES</para>
        /// <para>MessageText: The system cannot open the file.</para>
        /// </summary>
        TooManyOpenFiles = 4,

        /// <summary>
        /// <para>MessageId: ERROR_ACCESS_DENIED</para>
        /// <para>MessageText: Access is denied.</para>
        /// </summary>
        AccessDenied = 5,

        /// <summary>
        /// <para>MessageId: ERROR_INVALID_HANDLE</para>
        /// <para>MessageText: The handle is invalid.</para>
        /// </summary>
        InvalidHandle = 6,

        /// <summary>
        /// <para>MessageId: ERROR_ARENA_TRASHED</para>
        /// <para>MessageText: The storage control blocks were destroyed.</para>
        /// </summary>
        ArenaTrashed = 7,

        /// <summary>
        /// <para>MessageId: ERROR_NOT_ENOUGH_MEMORY</para>
        /// <para>MessageText: Not enough memory resources are available to process this command.</para>
        /// </summary>
        NotEnoughMemory = 8,    // dderror

        /// <summary>
        /// <para>MessageId: ERROR_INVALID_BLOCK</para>
        /// <para>MessageText: The storage control block address is invalid.</para>
        /// </summary>
        InvalidBlock = 9,

        /// <summary>
        /// <para>MessageId: ERROR_BAD_ENVIRONMENT</para>
        /// <para>MessageText: The environment is incorrect.</para>
        /// </summary>
        BadEnvironment = 10,

        /// <summary>
        /// <para>MessageId: ERROR_BAD_FORMAT</para>
        /// <para>MessageText: An attempt was made to load a program with an incorrect format.</para>
        /// </summary>
        BadFormat = 11,

        /// <summary>
        /// <para>MessageId: ERROR_INVALID_ACCESS</para>
        /// <para>MessageText: The access code is invalid.</para>
        /// </summary>
        InvalidAccess = 12,

        /// <summary>
        /// <para>MessageId: ERROR_INVALID_DATA</para>
        /// <para>MessageText: The data is invalid.</para>
        /// </summary>
        InvalidData = 13,

        /// <summary>
        /// <para>MessageId: ERROR_OUTOFMEMORY</para>
        /// <para>MessageText: Not enough memory resources are available to complete this operation.</para>
        /// </summary>
        OutOfMemory = 14,

        /// <summary>
        /// <para>MessageId: ERROR_INVALID_DRIVE</para>
        /// <para>MessageText: The system cannot find the drive specified.</para>
        /// </summary>
        InvalidDrive = 15,

        /// <summary>
        /// <para>MessageId: ERROR_CURRENT_DIRECTORY</para>
        /// <para>MessageText: The directory cannot be removed.</para>
        /// </summary>
        CurrentDirectory = 16,

        /// <summary>
        /// <para>MessageId: ERROR_NOT_SAME_DEVICE</para>
        /// <para>MessageText: The system cannot move the file to a different disk drive.</para>
        /// </summary>
        NotSameDevice = 17,

        /// <summary>
        /// <para>MessageId: ERROR_NO_MORE_FILES</para>
        /// <para>MessageText: There are no more files.</para>
        /// </summary>
        NoMoreFiles = 18,

        /// <summary>
        /// <para>MessageId: ERROR_WRITE_PROTECT</para>
        /// <para>MessageText: The media is write protected.</para>
        /// </summary>
        WriteProtect = 19,

        /// <summary>
        /// <para>MessageId: ERROR_BAD_UNIT</para>
        /// <para>MessageText: The system cannot find the device specified.</para>
        /// </summary>
        BadUnit = 20,

        /// <summary>
        /// <para>MessageId: ERROR_NOT_READY</para>
        /// <para>MessageText: The device is not ready.</para>
        /// </summary>
        NotReady = 21,

        /// <summary>
        /// <para>MessageId: ERROR_BAD_COMMAND</para>
        /// <para>MessageText: The device does not recognize the command.</para>
        /// </summary>
        BadCommand = 22,

        /// <summary>
        /// <para>MessageId: ERROR_CRC</para>
        /// <para>MessageText: Data error (cyclic redundancy check).</para>
        /// </summary>
        CRC = 23,

        /// <summary>
        /// <para>MessageId: ERROR_BAD_LENGTH</para>
        /// <para>MessageText: The program issued a command but the command length is incorrect.</para>
        /// </summary>
        BadLength = 24,

        /// <summary>
        /// <para>MessageId: ERROR_SEEK</para>
        /// <para>MessageText: The drive cannot locate a specific area or track on the disk.</para>
        /// </summary>
        Seek = 25,

        /// <summary>
        /// <para>MessageId: ERROR_NOT_DOS_DISK</para>
        /// <para>MessageText: The specified disk or diskette cannot be accessed.</para>
        /// </summary>
        NotDOSDisk = 26,

        /// <summary>
        /// <para>MessageId: ERROR_SECTOR_NOT_FOUND</para>
        /// <para>MessageText: The drive cannot find the sector requested.</para>
        /// </summary>
        SectorNotFound = 27,

        /// <summary>
        /// <para>MessageId: ERROR_OUT_OF_PAPER</para>
        /// <para>MessageText: The printer is out of paper.</para>
        /// </summary>
        OutOfPaper = 28,

        /// <summary>
        /// <para>MessageId: ERROR_WRITE_FAULT</para>
        /// <para>MessageText: The system cannot write to the specified device.</para>
        /// </summary>
        WriteFault = 29,

        /// <summary>
        /// <para>MessageId: ERROR_READ_FAULT</para>
        /// <para>MessageText: The system cannot read from the specified device.</para>
        /// </summary>
        ReadFault = 30,

        /// <summary>
        /// <para>MessageId: ERROR_GEN_FAILURE</para>
        /// <para>MessageText: A device attached to the system is not functioning.</para>
        /// </summary>
        GenFailure = 31,

        /// <summary>
        /// <para>MessageId: ERROR_SHARING_VIOLATION</para>
        /// <para>MessageText: The process cannot access the file because it is being used by another process.</para>
        /// </summary>
        SharingViolation = 32,

        /// <summary>
        /// <para>MessageId: ERROR_LOCK_VIOLATION</para>
        /// <para>MessageText: The process cannot access the file because another process has locked a portion of the file.</para>
        /// </summary>
        LockViolation = 33,

        /// <summary>
        /// <para>MessageId: ERROR_WRONG_DISK</para>
        /// <para>MessageText: The wrong diskette is in the drive.</para>
        /// </summary>
        WrongDisk = 34,

        /// <summary>
        /// <para>MessageId: ERROR_SHARING_BUFFER_EXCEEDED</para>
        /// <para>MessageText: Too many files opened for sharing.</para>
        /// </summary>
        SharingBufferExceeded = 36,

        /// <summary>
        /// <para>MessageId: ERROR_HANDLE_EOF</para>
        /// <para>MessageText: Reached the end of the file.</para>
        /// </summary>
        HandleEOF = 38,

        /// <summary>
        /// <para>MessageId: ERROR_HANDLE_DISK_FULL</para>
        /// <para>MessageText: The disk is full.</para>
        /// </summary>
        HandleDiskFull = 39,

        /// <summary>
        /// <para>MessageId: ERROR_NOT_SUPPORTED</para>
        /// <para>MessageText: The request is not supported.</para>
        /// </summary>
        NotSupported = 50,

        /// <summary>
        /// <para>MessageId: ERROR_REM_NOT_LIST</para>
        /// <para>MessageText: Windows cannot find the network path. Verify that the network path is correct and the destination computer is not busy or turned off. If Windows still cannot find the network path, contact your network administrator.</para>
        /// </summary>
        RemNotList = 51,

        /// <summary>
        /// <para>MessageId: ERROR_DUP_NAME</para>
        /// <para>MessageText: You were not connected because a duplicate name exists on the network. If joining a domain, go to System in Control Panel to change the computer name and try again. If joining a workgroup, choose another workgroup name.</para>
        /// </summary>
        DupName = 52,

        /// <summary>
        /// <para>MessageId: ERROR_BAD_NETPATH</para>
        /// <para>MessageText: The network path was not found.</para>
        /// </summary>
        BadNetPath = 53,

        /// <summary>
        /// <para>MessageId: ERROR_NETWORK_BUSY</para>
        /// <para>MessageText: The network is busy.</para>
        /// </summary>
        NetworkBusy = 54,

        /// <summary>
        /// <para>MessageId: ERROR_DEV_NOT_EXIST</para>
        /// <para>MessageText: The specified network resource or device is no longer available.</para>
        /// </summary>
        DevNotExist = 55,    // dderror

        /// <summary>
        /// <para>MessageId: ERROR_TOO_MANY_CMDS</para>
        /// <para>MessageText: The network BIOS command limit has been reached.</para>
        /// </summary>
        TooManyCmds = 56,

        /// <summary>
        /// <para>MessageId: ERROR_ADAP_HDW_ERR</para>
        /// <para>MessageText: A network adapter hardware error occurred.</para>
        /// </summary>
        AdapHdwErr = 57,

        /// <summary>
        /// <para>MessageId: ERROR_BAD_NET_RESP</para>
        /// <para>MessageText: The specified server cannot perform the requested operation.</para>
        /// </summary>
        BadNetResp = 58,

        /// <summary>
        /// <para>MessageId: ERROR_UNEXP_NET_ERR</para>
        /// <para>MessageText: An unexpected network error occurred.</para>
        /// </summary>
        UnexpNetErr = 59,

        /// <summary>
        /// <para>MessageId: ERROR_BAD_REM_ADAP</para>
        /// <para>MessageText: The remote adapter is not compatible.</para>
        /// </summary>
        BadRemAdap = 60,

        /// <summary>
        /// <para>MessageId: ERROR_PRINTQ_FULL</para>
        /// <para>MessageText: The printer queue is full.</para>
        /// </summary>
        PrintqFull = 61,

        /// <summary>
        /// <para>MessageId: ERROR_NO_SPOOL_SPACE</para>
        /// <para>MessageText: Space to store the file waiting to be printed is not available on the server.</para>
        /// </summary>
        NoSpoolSpace = 62,

        /// <summary>
        /// <para>MessageId: ERROR_PRINT_CANCELLED</para>
        /// <para>MessageText: Your file waiting to be printed was deleted.</para>
        /// </summary>
        PrintCancelled = 63,

        /// <summary>
        /// <para>MessageId: ERROR_NETNAME_DELETED</para>
        /// <para>MessageText: The specified network name is no longer available.</para>
        /// </summary>
        NetNameDeleted = 64,

        /// <summary>
        /// <para>MessageId: ERROR_NETWORK_ACCESS_DENIED</para>
        /// <para>MessageText: Network access is denied.</para>
        /// </summary>
        NetworkAccessDenied = 65,

        /// <summary>
        /// <para>MessageId: ERROR_BAD_DEV_TYPE</para>
        /// <para>MessageText: The network resource type is not correct.</para>
        /// </summary>
        BadDevType = 66,

        /// <summary>
        /// <para>MessageId: ERROR_BAD_NET_NAME</para>
        /// <para>MessageText: The network name cannot be found.</para>
        /// </summary>
        BadNetName = 67,

        /// <summary>
        /// <para>MessageId: ERROR_TOO_MANY_NAMES</para>
        /// <para>MessageText: The name limit for the local computer network adapter card was exceeded.</para>
        /// </summary>
        TooManyNames = 68,

        /// <summary>
        /// <para>MessageId: ERROR_TOO_MANY_SESS</para>
        /// <para>MessageText: The network BIOS session limit was exceeded.</para>
        /// </summary>
        TooManySess = 69,

        /// <summary>
        /// <para>MessageId: ERROR_SHARING_PAUSED</para>
        /// <para>MessageText: The remote server has been paused or is in the process of being started.</para>
        /// </summary>
        SharingPaused = 70,

        /// <summary>
        /// <para>MessageId: ERROR_REQ_NOT_ACCEP</para>
        /// <para>MessageText: No more connections can be made to this remote computer at this time because there are already as many connections as the computer can accept.</para>
        /// </summary>
        ReqNotAccep = 71,

        /// <summary>
        /// <para>MessageId: ERROR_REDIR_PAUSED</para>
        /// <para>MessageText: The specified printer or disk device has been paused.</para>
        /// </summary>
        RedirPaused = 72,

        /// <summary>
        /// <para>MessageId: ERROR_FILE_EXISTS</para>
        /// <para>MessageText: The file exists.</para>
        /// </summary>
        FileExists = 80,

        /// <summary>
        /// <para>MessageId: ERROR_CANNOT_MAKE</para>
        /// <para>MessageText: The directory or file cannot be created.</para>
        /// </summary>
        CannotMake = 82,

        /// <summary>
        /// <para>MessageId: ERROR_FAIL_I24</para>
        /// <para>MessageText: Fail on INT= 24.</para>
        /// </summary>
        FailI24 = 83,

        /// <summary>
        /// <para>MessageId: ERROR_OUT_OF_STRUCTURES</para>
        /// <para>MessageText: Storage to process this request is not available.</para>
        /// </summary>
        OutOfStructures = 84,

        /// <summary>
        /// <para>MessageId: ERROR_ALREADY_ASSIGNED</para>
        /// <para>MessageText: The local device name is already in use.</para>
        /// </summary>
        AlreadyAssigned = 85,

        /// <summary>
        /// <para>MessageId: ERROR_INVALID_PASSWORD</para>
        /// <para>MessageText: The specified network password is not correct.</para>
        /// </summary>
        InvalidPassword = 86,

        /// <summary>
        /// <para>MessageId: ERROR_INVALID_PARAMETER</para>
        /// <para>MessageText: The parameter is incorrect.</para>
        /// </summary>
        InvalidParameter = 87,    // dderror

        /// <summary>
        /// <para>MessageId: ERROR_NET_WRITE_FAULT</para>
        /// <para>MessageText: A write fault occurred on the network.</para>
        /// </summary>
        NetWriteFault = 88,

        /// <summary>
        /// <para>MessageId: ERROR_NO_PROC_SLOTS</para>
        /// <para>MessageText: The system cannot start another process at this time.</para>
        /// </summary>
        NoProcSlots = 89,

        /// <summary>
        /// <para>MessageId: ERROR_TOO_MANY_SEMAPHORES</para>
        /// <para>MessageText: Cannot create another system semaphore.</para>
        /// </summary>
        TooManySemaphores = 100,

        /// <summary>
        /// <para>MessageId: ERROR_EXCL_SEM_ALREADY_OWNED</para>
        /// <para>MessageText: The exclusive semaphore is owned by another process.</para>
        /// </summary>
        ExclSemAlreadyOwned = 101,

        /// <summary>
        /// <para>MessageId: ERROR_SEM_IS_SET</para>
        /// <para>MessageText: The semaphore is set and cannot be closed.</para>
        /// </summary>
        SemIsSet = 102,

        /// <summary>
        /// <para>MessageId: ERROR_TOO_MANY_SEM_REQUESTS</para>
        /// <para>MessageText: The semaphore cannot be set again.</para>
        /// </summary>
        TooManySemRequests = 103,

        /// <summary>
        /// <para>MessageId: ERROR_INVALID_AT_INTERRUPT_TIME</para>
        /// <para>MessageText: Cannot request exclusive semaphores at interrupt time.</para>
        /// </summary>
        InvalidAtInterruptTime = 104,

        /// <summary>
        /// <para>MessageId: ERROR_SEM_OWNER_DIED</para>
        /// <para>MessageText: The previous ownership of this semaphore has ended.</para>
        /// </summary>
        SemOwnerDied = 105,

        /// <summary>
        /// <para>MessageId: ERROR_SEM_USER_LIMIT</para>
        /// <para>MessageText: Insert the diskette for drive %1.</para>
        /// </summary>
        SemUserLimit = 106,

        /// <summary>
        /// <para>MessageId: ERROR_DISK_CHANGE</para>
        /// <para>MessageText: The program stopped because an alternate diskette was not inserted.</para>
        /// </summary>
        DiskChange = 107,

        /// <summary>
        /// <para>MessageId: ERROR_DRIVE_LOCKED</para>
        /// <para>MessageText: The disk is in use or locked by another process.</para>
        /// </summary>
        DriveLocked = 108,

        /// <summary>
        /// <para>MessageId: ERROR_BROKEN_PIPE</para>
        /// <para>MessageText: The pipe has been ended.</para>
        /// </summary>
        BrokenPipe = 109,

        /// <summary>
        /// <para>MessageId: ERROR_OPEN_FAILED</para>
        /// <para>MessageText: The system cannot open the device or file specified.</para>
        /// </summary>
        OpenFailed = 110,

        /// <summary>
        /// <para>MessageId: ERROR_BUFFER_OVERFLOW</para>
        /// <para>MessageText: The file name is too long.</para>
        /// </summary>
        BufferOverflow = 111,

        /// <summary>
        /// <para>MessageId: ERROR_DISK_FULL</para>
        /// <para>MessageText: There is not enough space on the disk.</para>
        /// </summary>
        DiskFull = 112,

        /// <summary>
        /// <para>MessageId: ERROR_NO_MORE_SEARCH_HANDLES</para>
        /// <para>MessageText: No more internal file identifiers available.</para>
        /// </summary>
        NoMoreSearchHandles = 113,

        /// <summary>
        /// <para>MessageId: ERROR_INVALID_TARGET_HANDLE</para>
        /// <para>MessageText: The target internal file identifier is incorrect.</para>
        /// </summary>
        InvalidTargetHandle = 114,

        /// <summary>
        /// <para>MessageId: ERROR_INVALID_CATEGORY</para>
        /// <para>MessageText: The IOCTL call made by the application program is not correct.</para>
        /// </summary>
        InvalidCategory = 117,

        /// <summary>
        /// <para>MessageId: ERROR_INVALID_VERIFY_SWITCH</para>
        /// <para>MessageText: The verify-on-write switch parameter value is not correct.</para>
        /// </summary>
        InvalidVerifySwitch = 118,

        /// <summary>
        /// <para>MessageId: ERROR_BAD_DRIVER_LEVEL</para>
        /// <para>MessageText: The system does not support the command requested.</para>
        /// </summary>
        BadDriverLevel = 119,

        /// <summary>
        /// <para>MessageId: ERROR_CALL_NOT_IMPLEMENTED</para>
        /// <para>MessageText: This function is not supported on this system.</para>
        /// </summary>
        CallNotImplemented = 120,

        /// <summary>
        /// <para>MessageId: ERROR_SEM_TIMEOUT</para>
        /// <para>MessageText: The semaphore timeout period has expired.</para>
        /// </summary>
        SemTimeOut = 121,

        /// <summary>
        /// <para>MessageId: ERROR_INSUFFICIENT_BUFFER</para>
        /// <para>MessageText: The data area passed to a system call is too small.</para>
        /// </summary>
        InsufficientBuffer = 122,    // dderror

        /// <summary>
        /// <para>MessageId: ERROR_INVALID_NAME</para>
        /// <para>MessageText: The filename, directory name, or volume label syntax is incorrect.</para>
        /// </summary>
        InvalidName = 123,    // dderror

        /// <summary>
        /// <para>MessageId: ERROR_INVALID_LEVEL</para>
        /// <para>MessageText: The system call level is not correct.</para>
        /// </summary>
        InvalidLevel = 124,

        /// <summary>
        /// <para>MessageId: ERROR_NO_VOLUME_LABEL</para>
        /// <para>MessageText: The disk has no volume label.</para>
        /// </summary>
        NoVolumeLabel = 125,

        /// <summary>
        /// <para>MessageId: ERROR_MOD_NOT_FOUND</para>
        /// <para>MessageText: The specified module could not be found.</para>
        /// </summary>
        ModNotFound = 126,

        /// <summary>
        /// <para>MessageId: ERROR_PROC_NOT_FOUND</para>
        /// <para>MessageText: The specified procedure could not be found.</para>
        /// </summary>
        ProcNotFound = 127,

        /// <summary>
        /// <para>MessageId: ERROR_WAIT_NO_CHILDREN</para>
        /// <para>MessageText: There are no child processes to wait for.</para>
        /// </summary>
        WaitNoChildren = 128,

        /// <summary>
        /// <para>MessageId: ERROR_CHILD_NOT_COMPLETE</para>
        /// <para>MessageText: The %1 application cannot be run in Win32 mode.</para>
        /// </summary>
        ChildNotComplete = 129,

        /// <summary>
        /// <para>MessageId: ERROR_DIRECT_ACCESS_HANDLE</para>
        /// <para>MessageText: Attempt to use a file handle to an open disk partition for an operation other than raw disk I/O.</para>
        /// </summary>
        DirectAccessHandle = 130,

        /// <summary>
        /// <para>MessageId: ERROR_NEGATIVE_SEEK</para>
        /// <para>MessageText: An attempt was made to move the file pointer before the beginning of the file.</para>
        /// </summary>
        NegativeSeek = 131,

        /// <summary>
        /// <para>MessageId: ERROR_SEEK_ON_DEVICE</para>
        /// <para>MessageText: The file pointer cannot be set on the specified device or file.</para>
        /// </summary>
        SeekOnDevice = 132,

        /// <summary>
        /// <para>MessageId: ERROR_IS_JOIN_TARGET</para>
        /// <para>MessageText: A JOIN or SUBST command cannot be used for a drive that contains previously joined drives.</para>
        /// </summary>
        IsJoinTarget = 133,

        /// <summary>
        /// <para>MessageId: ERROR_IS_JOINED</para>
        /// <para>MessageText: An attempt was made to use a JOIN or SUBST command on a drive that has already been joined.</para>
        /// </summary>
        IsJoined = 134,

        /// <summary>
        /// <para>MessageId: ERROR_IS_SUBSTED</para>
        /// <para>MessageText: An attempt was made to use a JOIN or SUBST command on a drive that has already been substituted.</para>
        /// </summary>
        IsSubsted = 135,

        /// <summary>
        /// <para>MessageId: ERROR_NOT_JOINED</para>
        /// <para>MessageText: The system tried to delete the JOIN of a drive that is not joined.</para>
        /// </summary>
        NotJoined = 136,

        /// <summary>
        /// <para>MessageId: ERROR_NOT_SUBSTED</para>
        /// <para>MessageText: The system tried to delete the substitution of a drive that is not substituted.</para>
        /// </summary>
        NotSubsted = 137,

        /// <summary>
        /// <para>MessageId: ERROR_JOIN_TO_JOIN</para>
        /// <para>MessageText: The system tried to join a drive to a directory on a joined drive.</para>
        /// </summary>
        JoinToJoin = 138,

        /// <summary>
        /// <para>MessageId: ERROR_SUBST_TO_SUBST</para>
        /// <para>MessageText: The system tried to substitute a drive to a directory on a substituted drive.</para>
        /// </summary>
        SubstToSubst = 139,

        /// <summary>
        /// <para>MessageId: ERROR_JOIN_TO_SUBST</para>
        /// <para>MessageText: The system tried to join a drive to a directory on a substituted drive.</para>
        /// </summary>
        JoinToSubst = 140,

        /// <summary>
        /// <para>MessageId: ERROR_SUBST_TO_JOIN</para>
        /// <para>MessageText: The system tried to SUBST a drive to a directory on a joined drive.</para>
        /// </summary>
        SubstToJoin = 141,

        /// <summary>
        /// <para>MessageId: ERROR_BUSY_DRIVE</para>
        /// <para>MessageText: The system cannot perform a JOIN or SUBST at this time.</para>
        /// </summary>
        BusyDrive = 142,

        /// <summary>
        /// <para>MessageId: ERROR_SAME_DRIVE</para>
        /// <para>MessageText: The system cannot join or substitute a drive to or for a directory on the same drive.</para>
        /// </summary>
        SameDrive = 143,

        /// <summary>
        /// <para>MessageId: ERROR_DIR_NOT_ROOT</para>
        /// <para>MessageText: The directory is not a subdirectory of the root directory.</para>
        /// </summary>
        DirNotRoot = 144,

        /// <summary>
        /// <para>MessageId: ERROR_DIR_NOT_EMPTY</para>
        /// <para>MessageText: The directory is not empty.</para>
        /// </summary>
        DirNotEmpty = 145,

        /// <summary>
        /// <para>MessageId: ERROR_IS_SUBST_PATH</para>
        /// <para>MessageText: The path specified is being used in a substitute.</para>
        /// </summary>
        IsSubstPath = 146,

        /// <summary>
        /// <para>MessageId: ERROR_IS_JOIN_PATH</para>
        /// <para>MessageText: Not enough resources are available to process this command.</para>
        /// </summary>
        IsJoinPath = 147,

        /// <summary>
        /// <para>MessageId: ERROR_PATH_BUSY</para>
        /// <para>MessageText: The path specified cannot be used at this time.</para>
        /// </summary>
        PathBusy = 148,

        /// <summary>
        /// <para>MessageId: ERROR_IS_SUBST_TARGET</para>
        /// <para>MessageText: An attempt was made to join or substitute a drive for which a directory on the drive is the target of a previous substitute.</para>
        /// </summary>
        IsSubstTarget = 149,

        /// <summary>
        /// <para>MessageId: ERROR_SYSTEM_TRACE</para>
        /// <para>MessageText: System trace information was not specified in your CONFIG.SYS file, or tracing is disallowed.</para>
        /// </summary>
        SystemTrace = 150,

        /// <summary>
        /// <para>MessageId: ERROR_INVALID_EVENT_COUNT</para>
        /// <para>MessageText: The number of specified semaphore events for DosMuxSemWait is not correct.</para>
        /// </summary>
        InvalidEventCount = 151,

        /// <summary>
        /// <para>MessageId: ERROR_TOO_MANY_MUXWAITERS</para>
        /// <para>MessageText: DosMuxSemWait did not execute; too many semaphores are already set.</para>
        /// </summary>
        TooManyMuxWaiters = 152,

        /// <summary>
        /// <para>MessageId: ERROR_INVALID_LIST_FORMAT</para>
        /// <para>MessageText: The DosMuxSemWait list is not correct.</para>
        /// </summary>
        InvalidListFormat = 153,

        /// <summary>
        /// <para>MessageId: ERROR_LABEL_TOO_LONG</para>
        /// <para>MessageText: The volume label you entered exceeds the label character limit of the target file system.</para>
        /// </summary>
        LabelTooLong = 154,

        /// <summary>
        /// <para>MessageId: ERROR_TOO_MANY_TCBS</para>
        /// <para>MessageText: Cannot create another thread.</para>
        /// </summary>
        TooManyTCBS = 155,

        /// <summary>
        /// <para>MessageId: ERROR_SIGNAL_REFUSED</para>
        /// <para>MessageText: The recipient process has refused the signal.</para>
        /// </summary>
        SignalRefused = 156,

        /// <summary>
        /// <para>MessageId: ERROR_DISCARDED</para>
        /// <para>MessageText: The segment is already discarded and cannot be locked.</para>
        /// </summary>
        Discarded = 157,

        /// <summary>
        /// <para>MessageId: ERROR_NOT_LOCKED</para>
        /// <para>MessageText: The segment is already unlocked.</para>
        /// </summary>
        NotLocked = 158,

        /// <summary>
        /// <para>MessageId: ERROR_BAD_THREADID_ADDR</para>
        /// <para>MessageText: The address for the thread ID is not correct.</para>
        /// </summary>
        BadThreadidAddr = 159,

        /// <summary>
        /// <para>MessageId: ERROR_BAD_ARGUMENTS</para>
        /// <para>MessageText: One or more arguments are not correct.</para>
        /// </summary>
        BadArguments = 160,

        /// <summary>
        /// <para>MessageId: ERROR_BAD_PATHNAME</para>
        /// <para>MessageText: The specified path is invalid.</para>
        /// </summary>
        BadPathName = 161,

        /// <summary>
        /// <para>MessageId: ERROR_SIGNAL_PENDING</para>
        /// <para>MessageText: A signal is already pending.</para>
        /// </summary>
        SignalPending = 162,

        /// <summary>
        /// <para>MessageId: ERROR_MAX_THRDS_REACHED</para>
        /// <para>MessageText: No more threads can be created in the system.</para>
        /// </summary>
        MaxTHRDSReached = 164,

        /// <summary>
        /// <para>MessageId: ERROR_LOCK_FAILED</para>
        /// <para>MessageText: Unable to lock a region of a file.</para>
        /// </summary>
        LockFailed = 167,

        /// <summary>
        /// <para>MessageId: ERROR_BUSY</para>
        /// <para>MessageText: The requested resource is in use.</para>
        /// </summary>
        Busy = 170,    // dderror

        /// <summary>
        /// <para>MessageId: ERROR_DEVICE_SUPPORT_IN_PROGRESS</para>
        /// <para>MessageText: Device's command support detection is in progress.</para>
        /// </summary>
        DeviceSupportInProgress = 171,

        /// <summary>
        /// <para>MessageId: ERROR_CANCEL_VIOLATION</para>
        /// <para>MessageText: A lock request was not outstanding for the supplied cancel region.</para>
        /// </summary>
        CancelViolation = 173,

        /// <summary>
        /// <para>MessageId: ERROR_ATOMIC_LOCKS_NOT_SUPPORTED</para>
        /// <para>MessageText: The file system does not support atomic changes to the lock type.</para>
        /// </summary>
        AtomicLocksNotSupported = 174,

        /// <summary>
        /// <para>MessageId: ERROR_INVALID_SEGMENT_NUMBER</para>
        /// <para>MessageText: The system detected a segment number that was not correct.</para>
        /// </summary>
        InvalidSegmentNumber = 180,

        /// <summary>
        /// <para>MessageId: ERROR_INVALID_ORDINAL</para>
        /// <para>MessageText: The operating system cannot run %1.</para>
        /// </summary>
        InvalidOrdinal = 182,

        /// <summary>
        /// <para>MessageId: ERROR_ALREADY_EXISTS</para>
        /// <para>MessageText: Cannot create a file when that file already exists.</para>
        /// </summary>
        AlreadyExists = 183,

        /// <summary>
        /// <para>MessageId: ERROR_INVALID_FLAG_NUMBER</para>
        /// <para>MessageText: The flag passed is not correct.</para>
        /// </summary>
        InvalidFlagNumber = 186,

        /// <summary>
        /// <para>MessageId: ERROR_SEM_NOT_FOUND</para>
        /// <para>MessageText: The specified system semaphore name was not found.</para>
        /// </summary>
        SemNotFound = 187,

        /// <summary>
        /// <para>MessageId: ERROR_INVALID_STARTING_CODESEG</para>
        /// <para>MessageText: The operating system cannot run %1.</para>
        /// </summary>
        InvalidStartingCodeSeg = 188,

        /// <summary>
        /// <para>MessageId: ERROR_INVALID_STACKSEG</para>
        /// <para>MessageText: The operating system cannot run %1.</para>
        /// </summary>
        InvalidStackSeg = 189,

        /// <summary>
        /// <para>MessageId: ERROR_INVALID_MODULETYPE</para>
        /// <para>MessageText: The operating system cannot run %1.</para>
        /// </summary>
        InvalidModuleType = 190,

        /// <summary>
        /// <para>MessageId: ERROR_INVALID_EXE_SIGNATURE</para>
        /// <para>MessageText: Cannot run %1 in Win32 mode.</para>
        /// </summary>
        InvalidExeSignature = 191,

        /// <summary>
        /// <para>MessageId: ERROR_EXE_MARKED_INVALID</para>
        /// <para>MessageText: The operating system cannot run %1.</para>
        /// </summary>
        ExeMarkedInvalid = 192,

        /// <summary>
        /// <para>MessageId: ERROR_BAD_EXE_FORMAT</para>
        /// <para>MessageText: %1 is not a valid Win32 application.</para>
        /// </summary>
        BadExeFormat = 193,

        /// <summary>
        /// <para>MessageId: ERROR_ITERATED_DATA_EXCEEDS_64k</para>
        /// <para>MessageText: The operating system cannot run %1.</para>
        /// </summary>
        IteratedDataExceeds64k = 194,

        /// <summary>
        /// <para>MessageId: ERROR_INVALID_MINALLOCSIZE</para>
        /// <para>MessageText: The operating system cannot run %1.</para>
        /// </summary>
        InvalidMinallocSize = 195,

        /// <summary>
        /// <para>MessageId: ERROR_DYNLINK_FROM_INVALID_RING</para>
        /// <para>MessageText: The operating system cannot run this application program.</para>
        /// </summary>
        DynLinkFromInvalidRing = 196,

        /// <summary>
        /// <para>MessageId: ERROR_IOPL_NOT_ENABLED</para>
        /// <para>MessageText: The operating system is not presently configured to run this application.</para>
        /// </summary>
        IOPLNotEnabled = 197,

        /// <summary>
        /// <para>MessageId: ERROR_INVALID_SEGDPL</para>
        /// <para>MessageText: The operating system cannot run %1.</para>
        /// </summary>
        InvalidSegDPL = 198,

        /// <summary>
        /// <para>MessageId: ERROR_AUTODATASEG_EXCEEDS_64k</para>
        /// <para>MessageText: The operating system cannot run this application program.</para>
        /// </summary>
        AutoDataSegExceeds64k = 199,

        /// <summary>
        /// <para>MessageId: ERROR_RING2SEG_MUST_BE_MOVABLE</para>
        /// <para>MessageText: The code segment cannot be greater than or equal to= 64K.</para>
        /// </summary>
        Ring2SegMustBeMovable = 200,

        /// <summary>
        /// <para>MessageId: ERROR_RELOC_CHAIN_XEEDS_SEGLIM</para>
        /// <para>MessageText: The operating system cannot run %1.</para>
        /// </summary>
        RelocChainXeedsSegLim = 201,

        /// <summary>
        /// <para>MessageId: ERROR_INFLOOP_IN_RELOC_CHAIN</para>
        /// <para>MessageText: The operating system cannot run %1.</para>
        /// </summary>
        InfLoopInRelocChain = 202,

        /// <summary>
        /// <para>MessageId: ERROR_ENVVAR_NOT_FOUND</para>
        /// <para>MessageText: The system could not find the environment option that was entered.</para>
        /// </summary>
        EnvVarNotFound = 203,

        /// <summary>
        /// <para>MessageId: ERROR_NO_SIGNAL_SENT</para>
        /// <para>MessageText: No process in the command subtree has a signal handler.</para>
        /// </summary>
        NoSignalSent = 205,

        /// <summary>
        /// <para>MessageId: ERROR_FILENAME_EXCED_RANGE</para>
        /// <para>MessageText: The filename or extension is too long.</para>
        /// </summary>
        FileNameExcedRange = 206,

        /// <summary>
        /// <para>MessageId: ERROR_RING2_STACK_IN_USE</para>
        /// <para>MessageText: The ring= 2 stack is in use.</para>
        /// </summary>
        Ring2StackInUse = 207,

        /// <summary>
        /// <para>MessageId: ERROR_META_EXPANSION_TOO_LONG</para>
        /// <para>MessageText: The global filename characters, * or ?, are entered incorrectly or too many global filename characters are specified.</para>
        /// </summary>
        MetaExpansionTooLong = 208,

        /// <summary>
        /// <para>MessageId: ERROR_INVALID_SIGNAL_NUMBER</para>
        /// <para>MessageText: The signal being posted is not correct.</para>
        /// </summary>
        InvalidSignalNumber = 209,

        /// <summary>
        /// <para>MessageId: ERROR_THREAD_1_INACTIVE</para>
        /// <para>MessageText: The signal handler cannot be set.</para>
        /// </summary>
        Thread1Inactive = 210,

        /// <summary>
        /// <para>MessageId: ERROR_LOCKED</para>
        /// <para>MessageText: The segment is locked and cannot be reallocated.</para>
        /// </summary>
        Locked = 212,

        /// <summary>
        /// <para>MessageId: ERROR_TOO_MANY_MODULES</para>
        /// <para>MessageText: Too many dynamic-link modules are attached to this program or dynamic-link module.</para>
        /// </summary>
        TooManyModules = 214,

        /// <summary>
        /// <para>MessageId: ERROR_NESTING_NOT_ALLOWED</para>
        /// <para>MessageText: Cannot nest calls to LoadModule.</para>
        /// </summary>
        NestingNotAllowed = 215,

        /// <summary>
        /// <para>MessageId: ERROR_EXE_MACHINE_TYPE_MISMATCH</para>
        /// <para>MessageText: This version of %1 is not compatible with the version of Windows you're running. Check your computer's system information and then contact the software publisher.</para>
        /// </summary>
        ExeMachineTypeMismatch = 216,

        /// <summary>
        /// <para>MessageId: ERROR_EXE_CANNOT_MODIFY_SIGNED_BINARY</para>
        /// <para>MessageText: The image file %1 is signed, unable to modify.</para>
        /// </summary>
        ExeCannotModifySignedBinary = 217,

        /// <summary>
        /// <para>MessageId: ERROR_EXE_CANNOT_MODIFY_STRONG_SIGNED_BINARY</para>
        /// <para>MessageText: The image file %1 is strong signed, unable to modify.</para>
        /// </summary>
        ExeCannotModifyStrongSignedBinary = 218,

        /// <summary>
        /// <para>MessageId: ERROR_FILE_CHECKED_OUT</para>
        /// <para>MessageText: This file is checked out or locked for editing by another user.</para>
        /// </summary>
        FileCheckedOut = 220,

        /// <summary>
        /// <para>MessageId: ERROR_CHECKOUT_REQUIRED</para>
        /// <para>MessageText: The file must be checked out before saving changes.</para>
        /// </summary>
        CheckOutRequired = 221,

        /// <summary>
        /// <para>MessageId: ERROR_BAD_FILE_TYPE</para>
        /// <para>MessageText: The file type being saved or retrieved has been blocked.</para>
        /// </summary>
        BadFileType = 222,

        /// <summary>
        /// <para>MessageId: ERROR_FILE_TOO_LARGE</para>
        /// <para>MessageText: The file size exceeds the limit allowed and cannot be saved.</para>
        /// </summary>
        FileTooLarge = 223,

        /// <summary>
        /// <para>MessageId: ERROR_FORMS_AUTH_REQUIRED</para>
        /// <para>MessageText: Access Denied. Before opening files in this location, you must first add the web site to your trusted sites list, browse to the web site, and select the option to login automatically.</para>
        /// </summary>
        FormsAuthRequired = 224,

        /// <summary>
        /// <para>MessageId: ERROR_VIRUS_INFECTED</para>
        /// <para>MessageText: Operation did not complete successfully because the file contains a virus or potentially unwanted software.</para>
        /// </summary>
        VirusInfected = 225,

        /// <summary>
        /// <para>MessageId: ERROR_VIRUS_DELETED</para>
        /// <para>MessageText: This file contains a virus or potentially unwanted software and cannot be opened. Due to the nature of this virus or potentially unwanted software, the file has been removed from this location.</para>
        /// </summary>
        VirusDeleted = 226,

        /// <summary>
        /// <para>MessageId: ERROR_PIPE_LOCAL</para>
        /// <para>MessageText: The pipe is local.</para>
        /// </summary>
        PipeLocal = 229,

        /// <summary>
        /// <para>MessageId: ERROR_BAD_PIPE</para>
        /// <para>MessageText: The pipe state is invalid.</para>
        /// </summary>
        BadPipe = 230,

        /// <summary>
        /// <para>MessageId: ERROR_PIPE_BUSY</para>
        /// <para>MessageText: All pipe instances are busy.</para>
        /// </summary>
        PipeBusy = 231,

        /// <summary>
        /// <para>MessageId: ERROR_NO_DATA</para>
        /// <para>MessageText: The pipe is being closed.</para>
        /// </summary>
        NoData = 232,

        /// <summary>
        /// <para>MessageId: ERROR_PIPE_NOT_CONNECTED</para>
        /// <para>MessageText: No process is on the other end of the pipe.</para>
        /// </summary>
        PipeNotConnected = 233,

        /// <summary>
        /// <para>MessageId: ERROR_MORE_DATA</para>
        /// <para>MessageText: More data is available.</para>
        /// </summary>
        MoreData = 234,    // dderror

        /// <summary>
        /// <para>MessageId: ERROR_NO_WORK_DONE</para>
        /// <para>MessageText: The action requested resulted in no work being done. Error-style clean-up has been performed.</para>
        /// </summary>
        NoWorkDone = 235,

        /// <summary>
        /// <para>MessageId: ERROR_VC_DISCONNECTED</para>
        /// <para>MessageText: The session was canceled.</para>
        /// </summary>
        VCDisconnected = 240,

        /// <summary>
        /// <para>MessageId: ERROR_INVALID_EA_NAME</para>
        /// <para>MessageText: The specified extended attribute name was invalid.</para>
        /// </summary>
        InvalidEAName = 254,

        /// <summary>
        /// <para>MessageId: ERROR_EA_LIST_INCONSISTENT</para>
        /// <para>MessageText: The extended attributes are inconsistent.</para>
        /// </summary>
        EAListInconsistent = 255,

        /// <summary>
        /// <para>MessageId: WAIT_TIMEOUT</para>
        /// <para>MessageText: The wait operation timed out.</para>
        /// </summary>
        WaitTimeOut = 258,    // dderror

        /// <summary>
        /// <para>MessageId: ERROR_NO_MORE_ITEMS</para>
        /// <para>MessageText: No more data is available.</para>
        /// </summary>
        NoMoreItems = 259,

        /// <summary>
        /// <para>MessageId: ERROR_CANNOT_COPY</para>
        /// <para>MessageText: The copy functions cannot be used.</para>
        /// </summary>
        CannotCopy = 266,

        /// <summary>
        /// <para>MessageId: ERROR_DIRECTORY</para>
        /// <para>MessageText: The directory name is invalid.</para>
        /// </summary>
        Directory = 267,

        /// <summary>
        /// <para>MessageId: ERROR_EAS_DIDNT_FIT</para>
        /// <para>MessageText: The extended attributes did not fit in the buffer.</para>
        /// </summary>
        EASDidntFit = 275,

        /// <summary>
        /// <para>MessageId: ERROR_EA_FILE_CORRUPT</para>
        /// <para>MessageText: The extended attribute file on the mounted file system is corrupt.</para>
        /// </summary>
        EAFileCorrupt = 276,

        /// <summary>
        /// <para>MessageId: ERROR_EA_TABLE_FULL</para>
        /// <para>MessageText: The extended attribute table file is full.</para>
        /// </summary>
        EATableFull = 277,

        /// <summary>
        /// <para>MessageId: ERROR_INVALID_EA_HANDLE</para>
        /// <para>MessageText: The specified extended attribute handle is invalid.</para>
        /// </summary>
        InvalidEAHandle = 278,

        /// <summary>
        /// <para>MessageId: ERROR_EAS_NOT_SUPPORTED</para>
        /// <para>MessageText: The mounted file system does not support extended attributes.</para>
        /// </summary>
        EASNotSupported = 282,

        /// <summary>
        /// <para>MessageId: ERROR_NOT_OWNER</para>
        /// <para>MessageText: Attempt to release mutex not owned by caller.</para>
        /// </summary>
        NotOwner = 288,

        /// <summary>
        /// <para>MessageId: ERROR_TOO_MANY_POSTS</para>
        /// <para>MessageText: Too many posts were made to a semaphore.</para>
        /// </summary>
        TooManyPosts = 298,

        /// <summary>
        /// <para>MessageId: ERROR_PARTIAL_COPY</para>
        /// <para>MessageText: Only part of a ReadProcessMemory or WriteProcessMemory request was completed.</para>
        /// </summary>
        PartialCopy = 299,

        /// <summary>
        /// <para>MessageId: ERROR_OPLOCK_NOT_GRANTED</para>
        /// <para>MessageText: The oplock request is denied.</para>
        /// </summary>
        OplockNotGranted = 300,

        /// <summary>
        /// <para>MessageId: ERROR_INVALID_OPLOCK_PROTOCOL</para>
        /// <para>MessageText: An invalid oplock acknowledgment was received by the system.</para>
        /// </summary>
        InvalidOplockProtocol = 301,

        /// <summary>
        /// <para>MessageId: ERROR_DISK_TOO_FRAGMENTED</para>
        /// <para>MessageText: The volume is too fragmented to complete this operation.</para>
        /// </summary>
        DiskTooFragmented = 302,

        /// <summary>
        /// <para>MessageId: ERROR_DELETE_PENDING</para>
        /// <para>MessageText: The file cannot be opened because it is in the process of being deleted.</para>
        /// </summary>
        DeletePending = 303,

        /// <summary>
        /// <para>MessageId: ERROR_INCOMPATIBLE_WITH_GLOBAL_SHORT_NAME_REGISTRY_SETTING</para>
        /// <para>MessageText: Short name settings may not be changed on this volume due to the global registry setting.</para>
        /// </summary>
        IncompatibleWithGlobalShortNameRegistrySetting = 304,

        /// <summary>
        /// <para>MessageId: ERROR_SHORT_NAMES_NOT_ENABLED_ON_VOLUME</para>
        /// <para>MessageText: Short names are not enabled on this volume.</para>
        /// </summary>
        ShortNamesNotEnabledOnVolume = 305,

        /// <summary>
        /// <para>MessageId: ERROR_SECURITY_STREAM_IS_INCONSISTENT</para>
        /// <para>MessageText: The security stream for the given volume is in an inconsistent state.</para>
        /// </summary>
        SecurityStreamIsInconsistent = 306,

        /// <summary>
        /// <para>MessageId: ERROR_INVALID_LOCK_RANGE</para>
        /// <para>MessageText: A requested file lock operation cannot be processed due to an invalid byte range.</para>
        /// </summary>
        InvalidLockRange = 307,

        /// <summary>
        /// <para>MessageId: ERROR_IMAGE_SUBSYSTEM_NOT_PRESENT</para>
        /// <para>MessageText: The subsystem needed to support the image type is not present.</para>
        /// </summary>
        ImageSubsystemNotPresent = 308,

        /// <summary>
        /// <para>MessageId: ERROR_NOTIFICATION_GUID_ALREADY_DEFINED</para>
        /// <para>MessageText: The specified file already has a notification GUID associated with it.</para>
        /// </summary>
        NotificationGuidAlreadyDefined = 309,

        /// <summary>
        /// <para>MessageId: ERROR_INVALID_EXCEPTION_HANDLER</para>
        /// <para>MessageText: An invalid exception handler routine has been detected.</para>
        /// </summary>
        InvalidExceptionHandler = 310,

        /// <summary>
        /// <para>MessageId: ERROR_DUPLICATE_PRIVILEGES</para>
        /// <para>MessageText: Duplicate privileges were specified for the token.</para>
        /// </summary>
        DuplicatePrivileges = 311,

        /// <summary>
        /// <para>MessageId: ERROR_NO_RANGES_PROCESSED</para>
        /// <para>MessageText: No ranges for the specified operation were able to be processed.</para>
        /// </summary>
        NoRangesProcessed = 312,

        /// <summary>
        /// <para>MessageId: ERROR_NOT_ALLOWED_ON_SYSTEM_FILE</para>
        /// <para>MessageText: Operation is not allowed on a file system internal file.</para>
        /// </summary>
        NotAllowedOnSystemFile = 313,

        /// <summary>
        /// <para>MessageId: ERROR_DISK_RESOURCES_EXHAUSTED</para>
        /// <para>MessageText: The physical resources of this disk have been exhausted.</para>
        /// </summary>
        DiskResourcesExhausted = 314,

        /// <summary>
        /// <para>MessageId: ERROR_INVALID_TOKEN</para>
        /// <para>MessageText: The token representing the data is invalid.</para>
        /// </summary>
        InvalidToken = 315,

        /// <summary>
        /// <para>MessageId: ERROR_DEVICE_FEATURE_NOT_SUPPORTED</para>
        /// <para>MessageText: The device does not support the command feature.</para>
        /// </summary>
        DeviceFeatureNotSupported = 316,

        /// <summary>
        /// <para>MessageId: ERROR_MR_MID_NOT_FOUND</para>
        /// <para>MessageText: The system cannot find message text for message number= 0x%1 in the message file for %2.</para>
        /// </summary>
        MRMIDNotFound = 317,

        /// <summary>
        /// <para>MessageId: ERROR_SCOPE_NOT_FOUND</para>
        /// <para>MessageText: The scope specified was not found.</para>
        /// </summary>
        ScopeNotFound = 318,

        /// <summary>
        /// <para>MessageId: ERROR_UNDEFINED_SCOPE</para>
        /// <para>MessageText: The Central Access Policy specified is not defined on the target machine.</para>
        /// </summary>
        UndefinedScope = 319,

        /// <summary>
        /// <para>MessageId: ERROR_INVALID_CAP</para>
        /// <para>MessageText: The Central Access Policy obtained from Active Directory is invalid.</para>
        /// </summary>
        InvalidCap = 320,

        /// <summary>
        /// <para>MessageId: ERROR_DEVICE_UNREACHABLE</para>
        /// <para>MessageText: The device is unreachable.</para>
        /// </summary>
        DeviceUnreachable = 321,

        /// <summary>
        /// <para>MessageId: ERROR_DEVICE_NO_RESOURCES</para>
        /// <para>MessageText: The target device has insufficient resources to complete the operation.</para>
        /// </summary>
        DeviceNoResources = 322,

        /// <summary>
        /// <para>MessageId: ERROR_DATA_CHECKSUM_ERROR</para>
        /// <para>MessageText: A data integrity checksum error occurred. Data in the file stream is corrupt.</para>
        /// </summary>
        DataChecksumError = 323,

        /// <summary>
        /// <para>MessageId: ERROR_INTERMIXED_KERNEL_EA_OPERATION</para>
        /// <para>MessageText: An attempt was made to modify both a KERNEL and normal Extended Attribute (EA) in the same operation.</para>
        /// </summary>
        IntermixedKernelEAOperation = 324,

        /// <summary>
        /// <para>MessageId: ERROR_FILE_LEVEL_TRIM_NOT_SUPPORTED</para>
        /// <para>MessageText: Device does not support file-level TRIM.</para>
        /// </summary>
        FileLevelTrimNotSupported = 326,

        /// <summary>
        /// <para>MessageId: ERROR_OFFSET_ALIGNMENT_VIOLATION</para>
        /// <para>MessageText: The command specified a data offset that does not align to the device's granularity/alignment.</para>
        /// </summary>
        OffsetAlignmentViolation = 327,

        /// <summary>
        /// <para>MessageId: ERROR_INVALID_FIELD_IN_PARAMETER_LIST</para>
        /// <para>MessageText: The command specified an invalid field in its parameter list.</para>
        /// </summary>
        InvalidFieldInParameterList = 328,

        /// <summary>
        /// <para>MessageId: ERROR_OPERATION_IN_PROGRESS</para>
        /// <para>MessageText: An operation is currently in progress with the device.</para>
        /// </summary>
        OperationInProgress = 329,

        /// <summary>
        /// <para>MessageId: ERROR_BAD_DEVICE_PATH</para>
        /// <para>MessageText: An attempt was made to send down the command via an invalid path to the target device.</para>
        /// </summary>
        BadDevicePath = 330,

        /// <summary>
        /// <para>MessageId: ERROR_TOO_MANY_DESCRIPTORS</para>
        /// <para>MessageText: The command specified a number of descriptors that exceeded the maximum supported by the device.</para>
        /// </summary>
        TooManyDescriptors = 331,

        /// <summary>
        /// <para>MessageId: ERROR_SCRUB_DATA_DISABLED</para>
        /// <para>MessageText: Scrub is disabled on the specified file.</para>
        /// </summary>
        ScrubDataDisabled = 332,

        /// <summary>
        /// <para>MessageId: ERROR_NOT_REDUNDANT_STORAGE</para>
        /// <para>MessageText: The storage device does not provide redundancy.</para>
        /// </summary>
        NotRedundantStorage = 333,

        /// <summary>
        /// <para>MessageId: ERROR_RESIDENT_FILE_NOT_SUPPORTED</para>
        /// <para>MessageText: An operation is not supported on a resident file.</para>
        /// </summary>
        ResidentFileNotSupported = 334,

        /// <summary>
        /// <para>MessageId: ERROR_COMPRESSED_FILE_NOT_SUPPORTED</para>
        /// <para>MessageText: An operation is not supported on a compressed file.</para>
        /// </summary>
        CompressedFileNotSupported = 335,

        /// <summary>
        /// <para>MessageId: ERROR_DIRECTORY_NOT_SUPPORTED</para>
        /// <para>MessageText: An operation is not supported on a directory.</para>
        /// </summary>
        DirectoryNotSupported = 336,

        /// <summary>
        /// <para>MessageId: ERROR_NOT_READ_FROM_COPY</para>
        /// <para>MessageText: The specified copy of the requested data could not be read.</para>
        /// </summary>
        NotReadFromCopy = 337,

        /// <summary>
        /// <para>MessageId: ERROR_FT_WRITE_FAILURE</para>
        /// <para>MessageText: The specified data could not be written to any of the copies.</para>
        /// </summary>
        FTWriteFailure = 338,

        /// <summary>
        /// <para>MessageId: ERROR_FT_DI_SCAN_REQUIRED</para>
        /// <para>MessageText: One or more copies of data on this device may be out of sync. No writes may be performed until a data integrity scan is completed.</para>
        /// </summary>
        FTDIScanRequired = 339,

        /// <summary>
        /// <para>MessageId: ERROR_INVALID_KERNEL_INFO_VERSION</para>
        /// <para>MessageText: The supplied kernel information version is invalid.</para>
        /// </summary>
        InvalidKernelInfoVersion = 340,

        /// <summary>
        /// <para>MessageId: ERROR_INVALID_PEP_INFO_VERSION</para>
        /// <para>MessageText: The supplied PEP information version is invalid.</para>
        /// </summary>
        InvalidPEPInfoVersion = 341,

        /// <summary>
        /// <para>MessageId: ERROR_OBJECT_NOT_EXTERNALLY_BACKED</para>
        /// <para>MessageText: This object is not externally backed by any provider.</para>
        /// </summary>
        ObjectNotExternallyBacked = 342,

        /// <summary>
        /// <para>MessageId: ERROR_EXTERNAL_BACKING_PROVIDER_UNKNOWN</para>
        /// <para>MessageText: The external backing provider is not recognized.</para>
        /// </summary>
        ExternalBackingProviderUnknown = 343,

        /// <summary>
        /// <para>MessageId: ERROR_COMPRESSION_NOT_BENEFICIAL</para>
        /// <para>MessageText: Compressing this object would not save space.</para>
        /// </summary>
        CompressionNotBeneficial = 344,

        /// <summary>
        /// <para>MessageId: ERROR_STORAGE_TOPOLOGY_ID_MISMATCH</para>
        /// <para>MessageText: The request failed due to a storage topology ID mismatch.</para>
        /// </summary>
        StorageTopologyIdMismatch = 345,

        /// <summary>
        /// <para>MessageId: ERROR_BLOCKED_BY_PARENTAL_CONTROLS</para>
        /// <para>MessageText: The operation was blocked by parental controls.</para>
        /// </summary>
        BlockedByParentalControls = 346,

        /// <summary>
        /// <para>MessageId: ERROR_BLOCK_TOO_MANY_REFERENCES</para>
        /// <para>MessageText: A file system block being referenced has already reached the maximum reference count and can't be referenced any further.</para>
        /// </summary>
        BlockTooManyReferences = 347,

        /// <summary>
        /// <para>MessageId: ERROR_MARKED_TO_DISALLOW_WRITES</para>
        /// <para>MessageText: The requested operation failed because the file stream is marked to disallow writes.</para>
        /// </summary>
        MarkedToDisallowWrites = 348,

        /// <summary>
        /// <para>MessageId: ERROR_ENCLAVE_FAILURE</para>
        /// <para>MessageText: The requested operation failed with an architecture-specific failure code.</para>
        /// </summary>
        EnclaveFailure = 349,

        /// <summary>
        /// <para>MessageId: ERROR_FAIL_NOACTION_REBOOT</para>
        /// <para>MessageText: No action was taken as a system reboot is required.</para>
        /// </summary>
        FailNoActionReboot = 350,

        /// <summary>
        /// <para>MessageId: ERROR_FAIL_SHUTDOWN</para>
        /// <para>MessageText: The shutdown operation failed.</para>
        /// </summary>
        FailShutdown = 351,

        /// <summary>
        /// <para>MessageId: ERROR_FAIL_RESTART</para>
        /// <para>MessageText: The restart operation failed.</para>
        /// </summary>
        FailRestart = 352,

        /// <summary>
        /// <para>MessageId: ERROR_MAX_SESSIONS_REACHED</para>
        /// <para>MessageText: The maximum number of sessions has been reached.</para>
        /// </summary>
        MaxSessionsReached = 353,

        /// <summary>
        /// <para>MessageId: ERROR_NETWORK_ACCESS_DENIED_EDP</para>
        /// <para>MessageText: Windows Information Protection policy does not allow access to this network resource.</para>
        /// </summary>
        NetworkAccessDeniedEDP = 354,

        /// <summary>
        /// <para>MessageId: ERROR_DEVICE_HINT_NAME_BUFFER_TOO_SMALL</para>
        /// <para>MessageText: The device hint name buffer is too small to receive the remaining name.</para>
        /// </summary>
        DeviceHintNameBufferTooSmall = 355,

        /// <summary>
        /// <para>MessageId: ERROR_EDP_POLICY_DENIES_OPERATION</para>
        /// <para>MessageText: The requested operation was blocked by Windows Information Protection policy. For more information, contact your system administrator.</para>
        /// </summary>
        EDPPolicyDeniesOperation = 356,

        /// <summary>
        /// <para>MessageId: ERROR_EDP_DPL_POLICY_CANT_BE_SATISFIED</para>
        /// <para>MessageText: The requested operation cannot be performed because hardware or software configuration of the device does not comply with Windows Information Protection under Lock policy. Please, verify that user PIN has been created. For more information, contact your system administrator.</para>
        /// </summary>
        EDPDPLPolicyCantBeSatisfied = 357,

        /// <summary>
        /// <para>MessageId: ERROR_CLOUD_FILE_SYNC_ROOT_METADATA_CORRUPT</para>
        /// <para>MessageText: The cloud sync root metadata is corrupted.</para>
        /// </summary>
        CloudFileSyncRootMetadataCorrupt = 358,

        /// <summary>
        /// <para>MessageId: ERROR_DEVICE_IN_MAINTENANCE</para>
        /// <para>MessageText: The device is in maintenance mode.</para>
        /// </summary>
        DeviceInMaintenance = 359,

        /// <summary>
        /// <para>MessageId: ERROR_NOT_SUPPORTED_ON_DAX</para>
        /// <para>MessageText: This operation is not supported on a DAX volume.</para>
        /// </summary>
        NotSupportedOnDax = 360,

        /// <summary>
        /// <para>MessageId: ERROR_DAX_MAPPING_EXISTS</para>
        /// <para>MessageText: The volume has active DAX mappings.</para>
        /// </summary>
        DAXMappingExists = 361,

        /// <summary>
        /// <para>MessageId: ERROR_CLOUD_FILE_PROVIDER_NOT_RUNNING</para>
        /// <para>MessageText: The cloud file provider is not running.</para>
        /// </summary>
        CloudFileProviderNotRunning = 362,

        /// <summary>
        /// <para>MessageId: ERROR_CLOUD_FILE_METADATA_CORRUPT</para>
        /// <para>MessageText: The cloud file metadata is corrupt and unreadable.</para>
        /// </summary>
        CloudFileMetadataCorrupt = 363,

        /// <summary>
        /// <para>MessageId: ERROR_CLOUD_FILE_METADATA_TOO_LARGE</para>
        /// <para>MessageText: The cloud file metadata is too large.</para>
        /// </summary>
        CloudFileMetadataTooLarge = 364,

        /// <summary>
        /// <para>MessageId: ERROR_CLOUD_FILE_PROPERTY_BLOB_TOO_LARGE</para>
        /// <para>MessageText: The cloud file property is too large.</para>
        /// </summary>
        CloudFilePropertyBlobTooLarge = 365,

        /// <summary>
        /// <para>MessageId: ERROR_CLOUD_FILE_PROPERTY_BLOB_CHECKSUM_MISMATCH</para>
        /// <para>MessageText: The cloud file property is possibly corrupt. The on-disk checksum does not match the computed checksum.</para>
        /// </summary>
        CloudFilePropertyBlobChecksumMismatch = 366,

        /// <summary>
        /// <para>MessageId: ERROR_CHILD_PROCESS_BLOCKED</para>
        /// <para>MessageText: The process creation has been blocked.</para>
        /// </summary>
        ChildProcessBlocked = 367,

        /// <summary>
        /// <para>MessageId: ERROR_STORAGE_LOST_DATA_PERSISTENCE</para>
        /// <para>MessageText: The storage device has lost data or persistence.</para>
        /// </summary>
        StorageLostDataPersistence = 368,

        /// <summary>
        /// <para>MessageId: ERROR_FILE_SYSTEM_VIRTUALIZATION_UNAVAILABLE</para>
        /// <para>MessageText: The provider that supports file system virtualization is temporarily unavailable.</para>
        /// </summary>
        FileSystemVirtualizationUnavailable = 369,

        /// <summary>
        /// <para>MessageId: ERROR_FILE_SYSTEM_VIRTUALIZATION_METADATA_CORRUPT</para>
        /// <para>MessageText: The metadata for file system virtualization is corrupt and unreadable.</para>
        /// </summary>
        FileSystemVirtualizationMetadataCorrupt = 370,

        /// <summary>
        /// <para>MessageId: ERROR_FILE_SYSTEM_VIRTUALIZATION_BUSY</para>
        /// <para>MessageText: The provider that supports file system virtualization is too busy to complete this operation.</para>
        /// </summary>
        FileSystemVirtualizationBusy = 371,

        /// <summary>
        /// <para>MessageId: ERROR_FILE_SYSTEM_VIRTUALIZATION_PROVIDER_UNKNOWN</para>
        /// <para>MessageText: The provider that supports file system virtualization is unknown.</para>
        /// </summary>
        FileSystemVirtualizationProviderUnknown = 372,

        /// <summary>
        /// <para>MessageId: ERROR_GDI_HANDLE_LEAK</para>
        /// <para>MessageText: GDI handles were potentially leaked by the application.</para>
        /// </summary>
        GDIHandleLeak = 373,

        /// <summary>
        /// <para>MessageId: ERROR_CLOUD_FILE_TOO_MANY_PROPERTY_BLOBS</para>
        /// <para>MessageText: The maximum number of cloud file properties has been reached.</para>
        /// </summary>
        CloudFileTooManyPropertyBlobs = 374,

        /// <summary>
        /// <para>MessageId: ERROR_CLOUD_FILE_PROPERTY_VERSION_NOT_SUPPORTED</para>
        /// <para>MessageText: The version of the cloud file property store is not supported.</para>
        /// </summary>
        CloudFilePropertyVersionNotSupported = 375,

        /// <summary>
        /// <para>MessageId: ERROR_NOT_A_CLOUD_FILE</para>
        /// <para>MessageText: The file is not a cloud file.</para>
        /// </summary>
        NotACloudFile = 376,

        /// <summary>
        /// <para>MessageId: ERROR_CLOUD_FILE_NOT_IN_SYNC</para>
        /// <para>MessageText: The file is not in sync with the cloud.</para>
        /// </summary>
        CloudFileNotInSync = 377,

        /// <summary>
        /// <para>MessageId: ERROR_CLOUD_FILE_ALREADY_CONNECTED</para>
        /// <para>MessageText: The cloud sync root is already connected with another cloud sync provider.</para>
        /// </summary>
        CloudFileAlreadyConnected = 378,

        /// <summary>
        /// <para>MessageId: ERROR_CLOUD_FILE_NOT_SUPPORTED</para>
        /// <para>MessageText: The operation is not supported by the cloud sync provider.</para>
        /// </summary>
        CloudFileNotSupported = 379,

        /// <summary>
        /// <para>MessageId: ERROR_CLOUD_FILE_INVALID_REQUEST</para>
        /// <para>MessageText: The cloud operation is invalid.</para>
        /// </summary>
        CloudFileInvalidRequest = 380,

        /// <summary>
        /// <para>MessageId: ERROR_CLOUD_FILE_READ_ONLY_VOLUME</para>
        /// <para>MessageText: The cloud operation is not supported on a read-only volume.</para>
        /// </summary>
        CloudFileReadOnlyVolume = 381,

        /// <summary>
        /// <para>MessageId: ERROR_CLOUD_FILE_CONNECTED_PROVIDER_ONLY</para>
        /// <para>MessageText: The operation is reserved for a connected cloud sync provider.</para>
        /// </summary>
        CloudFileConnectedProviderOnly = 382,

        /// <summary>
        /// <para>MessageId: ERROR_CLOUD_FILE_VALIDATION_FAILED</para>
        /// <para>MessageText: The cloud sync provider failed to validate the downloaded data.</para>
        /// </summary>
        CloudFileValidationFailed = 383,

        /// <summary>
        /// <para>MessageId: ERROR_SMB1_NOT_AVAILABLE</para>
        /// <para>MessageText: You can't connect to the file share because it's not secure. This share requires the obsolete SMB1 protocol, which is unsafe and could expose your system to attack.</para>
        /// </summary>
        SMB1NotAvailable = 384,

        /// <summary>
        /// <para>MessageId: ERROR_FILE_SYSTEM_VIRTUALIZATION_INVALID_OPERATION</para>
        /// <para>MessageText: The virtualization operation is not allowed on the file in its current state.</para>
        /// </summary>
        FileSystemVirtualizationInvalidOperation = 385,

        /// <summary>
        /// <para>MessageId: ERROR_CLOUD_FILE_AUTHENTICATION_FAILED</para>
        /// <para>MessageText: The cloud sync provider failed user authentication.</para>
        /// </summary>
        CloudFileAuthenticationFailed = 386,

        /// <summary>
        /// <para>MessageId: ERROR_CLOUD_FILE_INSUFFICIENT_RESOURCES</para>
        /// <para>MessageText: The cloud sync provider failed to perform the operation due to low system resources.</para>
        /// </summary>
        CloudFileInsufficientResources = 387,

        /// <summary>
        /// <para>MessageId: ERROR_CLOUD_FILE_NETWORK_UNAVAILABLE</para>
        /// <para>MessageText: The cloud sync provider failed to perform the operation due to network being unavailable.</para>
        /// </summary>
        CloudFileNetworkUnavailable = 388,

        /// <summary>
        /// <para>MessageId: ERROR_CLOUD_FILE_UNSUCCESSFUL</para>
        /// <para>MessageText: The cloud operation was unsuccessful.</para>
        /// </summary>
        CloudFileUnsuccessful = 389,

        /// <summary>
        /// <para>MessageId: ERROR_CLOUD_FILE_NOT_UNDER_SYNC_ROOT</para>
        /// <para>MessageText: The operation is only supported on files under a cloud sync root.</para>
        /// </summary>
        CloudFileNotUnderSyncRoot = 390,

        /// <summary>
        /// <para>MessageId: ERROR_CLOUD_FILE_IN_USE</para>
        /// <para>MessageText: The operation cannot be performed on cloud files in use.</para>
        /// </summary>
        CloudFileInUse = 391,

        /// <summary>
        /// <para>MessageId: ERROR_CLOUD_FILE_PINNED</para>
        /// <para>MessageText: The operation cannot be performed on pinned cloud files.</para>
        /// </summary>
        CloudFilePinned = 392,

        /// <summary>
        /// <para>MessageId: ERROR_CLOUD_FILE_REQUEST_ABORTED</para>
        /// <para>MessageText: The cloud operation was aborted.</para>
        /// </summary>
        CloudFileRequestAborted = 393,

        /// <summary>
        /// <para>MessageId: ERROR_CLOUD_FILE_PROPERTY_CORRUPT</para>
        /// <para>MessageText: The cloud file's property store is corrupt.</para>
        /// </summary>
        CloudFilePropertyCorrupt = 394,

        /// <summary>
        /// <para>MessageId: ERROR_CLOUD_FILE_ACCESS_DENIED</para>
        /// <para>MessageText: Access to the cloud file is denied.</para>
        /// </summary>
        CloudFileAccessDenied = 395,

        /// <summary>
        /// <para>MessageId: ERROR_CLOUD_FILE_INCOMPATIBLE_HARDLINKS</para>
        /// <para>MessageText: The cloud operation cannot be performed on a file with incompatible hardlinks.</para>
        /// </summary>
        CloudFileIncompatibleHardlinks = 396,

        /// <summary>
        /// <para>MessageId: ERROR_CLOUD_FILE_PROPERTY_LOCK_CONFLICT</para>
        /// <para>MessageText: The operation failed due to a conflicting cloud file property lock.</para>
        /// </summary>
        CloudFilePropertyLockConflict = 397,

        /// <summary>
        /// <para>MessageId: ERROR_CLOUD_FILE_REQUEST_CANCELED</para>
        /// <para>MessageText: The cloud operation was canceled by user.</para>
        /// </summary>
        CloudFileRequestCanceled = 398,

        /// <summary>
        /// <para>MessageId: ERROR_EXTERNAL_SYSKEY_NOT_SUPPORTED</para>
        /// <para>MessageText: An externally encrypted syskey has been configured, but the system no longer supports this feature.  Please see https://go.microsoft.com/fwlink/?linkid=851152 for more information.</para>
        /// </summary>
        ExternalSyskeyNotSupported = 399,

        /// <summary>
        /// <para>MessageId: ERROR_THREAD_MODE_ALREADY_BACKGROUND</para>
        /// <para>MessageText: The thread is already in background processing mode.</para>
        /// </summary>
        ThreadModeAlreadyBackground = 400,

        /// <summary>
        /// <para>MessageId: ERROR_THREAD_MODE_NOT_BACKGROUND</para>
        /// <para>MessageText: The thread is not in background processing mode.</para>
        /// </summary>
        ThreadModeNotBackground = 401,

        /// <summary>
        /// <para>MessageId: ERROR_PROCESS_MODE_ALREADY_BACKGROUND</para>
        /// <para>MessageText: The process is already in background processing mode.</para>
        /// </summary>
        ProcessModeAlreadyBackground = 402,

        /// <summary>
        /// <para>MessageId: ERROR_PROCESS_MODE_NOT_BACKGROUND</para>
        /// <para>MessageText: The process is not in background processing mode.</para>
        /// </summary>
        ProcessModeNotBackground = 403,

        /// <summary>
        /// <para>MessageId: ERROR_CLOUD_FILE_PROVIDER_TERMINATED</para>
        /// <para>MessageText: The cloud file provider exited unexpectedly.</para>
        /// </summary>
        CloudFileProviderTerminated = 404,

        /// <summary>
        /// <para>MessageId: ERROR_NOT_A_CLOUD_SYNC_ROOT</para>
        /// <para>MessageText: The file is not a cloud sync root.</para>
        /// </summary>
        NotACloudSyncRoot = 405,

        /// <summary>
        /// <para>MessageId: ERROR_FILE_PROTECTED_UNDER_DPL</para>
        /// <para>MessageText: The read or write operation to an encrypted file could not be completed because the file can only be accessed when the device is unlocked.</para>
        /// </summary>
        FileProtectedUnderDPL = 406,

        /// <summary>
        /// <para>MessageId: ERROR_VOLUME_NOT_CLUSTER_ALIGNED</para>
        /// <para>MessageText: The volume is not cluster aligned on the disk.</para>
        /// </summary>
        VolumeNotClusterAligned = 407,

        /// <summary>
        /// <para>MessageId: ERROR_NO_PHYSICALLY_ALIGNED_FREE_SPACE_FOUND</para>
        /// <para>MessageText: No physically aligned free space was found on the volume.</para>
        /// </summary>
        NoPhysicallyAlignedFreeSpaceFound = 408,

        /// <summary>
        /// <para>MessageId: ERROR_APPX_FILE_NOT_ENCRYPTED</para>
        /// <para>MessageText: The APPX file can not be accessed because it is not encrypted as expected.</para>
        /// </summary>
        AppxFileNotEncrypted = 409,

        /// <summary>
        /// <para>MessageId: ERROR_RWRAW_ENCRYPTED_FILE_NOT_ENCRYPTED</para>
        /// <para>MessageText: A read or write of raw encrypted data cannot be performed because the file is not encrypted.</para>
        /// </summary>
        RWRAWEncryptedFileNotEncrypted = 410,

        /// <summary>
        /// <para>MessageId: ERROR_RWRAW_ENCRYPTED_INVALID_EDATAINFO_FILEOFFSET</para>
        /// <para>MessageText: An invalid file offset in the encrypted data info block was passed for read or write operation of file's raw encrypted data.</para>
        /// </summary>
        RWRAWEncryptedInvalidEDataInfoFileOffset = 411,

        /// <summary>
        /// <para>MessageId: ERROR_RWRAW_ENCRYPTED_INVALID_EDATAINFO_FILERANGE</para>
        /// <para>MessageText: An invalid offset and length combination in the encrypted data info block was passed for read or write operation of file's raw encrypted data.</para>
        /// </summary>
        RWRAWEncryptedInvalidEDataInfoFileRange = 412,

        /// <summary>
        /// <para>MessageId: ERROR_RWRAW_ENCRYPTED_INVALID_EDATAINFO_PARAMETER</para>
        /// <para>MessageText: An invalid parameter in the encrypted data info block was passed for read or write operation of file's raw encrypted data.</para>
        /// </summary>
        RWRAWEncryptedInvalidEdatainfoParameter = 413,

        /// <summary>
        /// <para>MessageId: ERROR_LINUX_SUBSYSTEM_NOT_PRESENT</para>
        /// <para>MessageText: The Windows Subsystem for Linux has not been enabled.</para>
        /// </summary>
        LinuxSubsystemNotPresent = 414,

        /// <summary>
        /// <para>MessageId: ERROR_FT_READ_FAILURE</para>
        /// <para>MessageText: The specified data could not be read from any of the copies.</para>
        /// </summary>
        FTReadFailure = 415,

        /// <summary>
        /// <para>MessageId: ERROR_STORAGE_RESERVE_ID_INVALID</para>
        /// <para>MessageText: The specified storage reserve ID is invalid.</para>
        /// </summary>
        StorageReserveIdInvalid = 416,

        /// <summary>
        /// <para>MessageId: ERROR_STORAGE_RESERVE_DOES_NOT_EXIST</para>
        /// <para>MessageText: The specified storage reserve does not exist.</para>
        /// </summary>
        StorageReserveDoesNotExist = 417,

        /// <summary>
        /// <para>MessageId: ERROR_STORAGE_RESERVE_ALREADY_EXISTS</para>
        /// <para>MessageText: The specified storage reserve already exists.</para>
        /// </summary>
        StorageReserveAlreadyExists = 418,

        /// <summary>
        /// <para>MessageId: ERROR_STORAGE_RESERVE_NOT_EMPTY</para>
        /// <para>MessageText: The specified storage reserve is not empty.</para>
        /// </summary>
        StorageReserveNotEmpty = 419,

        /// <summary>
        /// <para>MessageId: ERROR_NOT_A_DAX_VOLUME</para>
        /// <para>MessageText: This operation requires a DAX volume.</para>
        /// </summary>
        NotADAXVolume = 420,

        /// <summary>
        /// <para>MessageId: ERROR_NOT_DAX_MAPPABLE</para>
        /// <para>MessageText: This stream is not DAX mappable.</para>
        /// </summary>
        NotDAXMappable = 421,

        /// <summary>
        /// <para>MessageId: ERROR_TIME_SENSITIVE_THREAD</para>
        /// <para>MessageText: Operation cannot be performed on a time critical thread.</para>
        /// </summary>
        TimeSensitiveThread = 422,

        /// <summary>
        /// <para>MessageId: ERROR_DPL_NOT_SUPPORTED_FOR_USER</para>
        /// <para>MessageText: User data protection is not supported for the current or provided user.</para>
        /// </summary>
        DPLNotSupportedForUser = 423,

        /// <summary>
        /// <para>MessageId: ERROR_CASE_DIFFERING_NAMES_IN_DIR</para>
        /// <para>MessageText: This directory contains entries whose names differ only in case.</para>
        /// </summary>
        CaseDifferingNamesInDir = 424,

        /// <summary>
        /// <para>MessageId: ERROR_FILE_NOT_SUPPORTED</para>
        /// <para>MessageText: The file cannot be safely opened because it is not supported by this version of Windows.</para>
        /// </summary>
        FileNotSupported = 425,

        /// <summary>
        /// <para>MessageId: ERROR_CLOUD_FILE_REQUEST_TIMEOUT</para>
        /// <para>MessageText: The cloud operation was not completed before the time-out period expired.</para>
        /// </summary>
        CloudFileRequestTimeOut = 426,

        /// <summary>
        /// <para>MessageId: ERROR_NO_TASK_QUEUE</para>
        /// <para>MessageText: A task queue is required for this operation but none is available.</para>
        /// </summary>
        NoTaskQueue = 427,

        /// <summary>
        /// <para>MessageId: ERROR_SRC_SRV_DLL_LOAD_FAILED</para>
        /// <para>MessageText: Failed loading a valid version of srcsrv.dll.</para>
        /// </summary>
        SRCSRVDllLoadFailed = 428,

        /// <summary>
        /// <para>MessageId: ERROR_NOT_SUPPORTED_WITH_BTT</para>
        /// <para>MessageText: This operation is not supported with BTT enabled.</para>
        /// </summary>
        NotSupportedWithBtt = 429,

        /// <summary>
        /// <para>MessageId: ERROR_ENCRYPTION_DISABLED</para>
        /// <para>MessageText: This operation cannot be performed because encryption is currently disabled.</para>
        /// </summary>
        EncryptionDisabled = 430,

        /// <summary>
        /// <para>MessageId: ERROR_ENCRYPTING_METADATA_DISALLOWED</para>
        /// <para>MessageText: This encryption operation cannot be performed on filesystem metadata.</para>
        /// </summary>
        EncryptingMetadataDisallowed = 431,

        /// <summary>
        /// <para>MessageId: ERROR_CANT_CLEAR_ENCRYPTION_FLAG</para>
        /// <para>MessageText: Encryption cannot be cleared on this file/directory because it still has an encrypted attribute.</para>
        /// </summary>
        CantClearEncryptionFlag = 432,

        /// <summary>
        /// <para>MessageId: ERROR_NO_SUCH_DEVICE</para>
        /// <para>MessageText: A device which does not exist was specified.</para>
        /// </summary>
        NoSuchDevice = 433,

        /// <summary>
        /// <para>MessageId: ERROR_CAPAUTHZ_NOT_DEVUNLOCKED</para>
        /// <para>MessageText: Neither developer unlocked mode nor side loading mode is enabled on the device.</para>
        /// </summary>
        CapAuthzNotDevUnlocked = 450,

        /// <summary>
        /// <para>MessageId: ERROR_CAPAUTHZ_CHANGE_TYPE</para>
        /// <para>MessageText: Can not change application type during upgrade or re-provision.</para>
        /// </summary>
        CapAuthzChangeType = 451,

        /// <summary>
        /// <para>MessageId: ERROR_CAPAUTHZ_NOT_PROVISIONED</para>
        /// <para>MessageText: The application has not been provisioned.</para>
        /// </summary>
        CapAuthzNotProvisioned = 452,

        /// <summary>
        /// <para>MessageId: ERROR_CAPAUTHZ_NOT_AUTHORIZED</para>
        /// <para>MessageText: The requested capability can not be authorized for this application.</para>
        /// </summary>
        CapAuthzNotAuthorized = 453,

        /// <summary>
        /// <para>MessageId: ERROR_CAPAUTHZ_NO_POLICY</para>
        /// <para>MessageText: There is no capability authorization policy on the device.</para>
        /// </summary>
        CapAuthzNoPolicy = 454,

        /// <summary>
        /// <para>MessageId: ERROR_CAPAUTHZ_DB_CORRUPTED</para>
        /// <para>MessageText: The capability authorization database has been corrupted.</para>
        /// </summary>
        CapAuthzDBCorrupted = 455,

        /// <summary>
        /// <para>MessageId: ERROR_CAPAUTHZ_SCCD_INVALID_CATALOG</para>
        /// <para>MessageText: The custom capability's SCCD has an invalid catalog.</para>
        /// </summary>
        CapAuthzSCCDInvalidCatalog = 456,

        /// <summary>
        /// <para>MessageId: ERROR_CAPAUTHZ_SCCD_NO_AUTH_ENTITY</para>
        /// <para>MessageText: None of the authorized entity elements in the SCCD matched the app being installed; either the PFNs don't match, or the element's signature hash doesn't validate.</para>
        /// </summary>
        CapAuthzSCCDNoAuthEntity = 457,

        /// <summary>
        /// <para>MessageId: ERROR_CAPAUTHZ_SCCD_PARSE_ERROR</para>
        /// <para>MessageText: The custom capability's SCCD failed to parse.</para>
        /// </summary>
        CapAuthzSCCDParseError = 458,

        /// <summary>
        /// <para>MessageId: ERROR_CAPAUTHZ_SCCD_DEV_MODE_REQUIRED</para>
        /// <para>MessageText: The custom capability's SCCD requires developer mode.</para>
        /// </summary>
        CapAuthzSCCDDevModeRequired = 459,

        /// <summary>
        /// <para>MessageId: ERROR_CAPAUTHZ_SCCD_NO_CAPABILITY_MATCH</para>
        /// <para>MessageText: There not all declared custom capabilities are found in the SCCD.</para>
        /// </summary>
        CapAuthzSCCDNoCapabilityMatch = 460,

        /// <summary>
        /// <para>MessageId: ERROR_PNP_QUERY_REMOVE_DEVICE_TIMEOUT</para>
        /// <para>MessageText: The operation timed out waiting for this device to complete a PnP query-remove request due to a potential hang in its device stack. The system may need to be rebooted to complete the request.</para>
        /// </summary>
        PNPQueryRemoveDeviceTimeOut = 480,

        /// <summary>
        /// <para>MessageId: ERROR_PNP_QUERY_REMOVE_RELATED_DEVICE_TIMEOUT</para>
        /// <para>MessageText: The operation timed out waiting for this device to complete a PnP query-remove request due to a potential hang in the device stack of a related device. The system may need to be rebooted to complete the operation.</para>
        /// </summary>
        PNPQueryRemoveRelatedDeviceTimeOut = 481,

        /// <summary>
        /// <para>MessageId: ERROR_PNP_QUERY_REMOVE_UNRELATED_DEVICE_TIMEOUT</para>
        /// <para>MessageText: The operation timed out waiting for this device to complete a PnP query-remove request due to a potential hang in the device stack of an unrelated device. The system may need to be rebooted to complete the operation.</para>
        /// </summary>
        PNPQueryRemoveUnrelatedDeviceTimeOut = 482,

        /// <summary>
        /// <para>MessageId: ERROR_DEVICE_HARDWARE_ERROR</para>
        /// <para>MessageText: The request failed due to a fatal device hardware error.</para>
        /// </summary>
        DeviceHardwareError = 483,

        /// <summary>
        /// <para>MessageId: ERROR_INVALID_ADDRESS</para>
        /// <para>MessageText: Attempt to access invalid address.</para>
        /// </summary>
        InvalidAddress = 487,

        /// <summary>
        /// <para>MessageId: ERROR_VRF_CFG_ENABLED</para>
        /// <para>MessageText: Driver Verifier Volatile settings cannot be set when CFG is enabled.</para>
        /// </summary>
        VRFCFGEnabled = 1183,

        /// <summary>
        /// <para>MessageId: ERROR_PARTITION_TERMINATING</para>
        /// <para>MessageText: An attempt was made to access a partition that has begun termination.</para>
        /// </summary>
        PartitionTerminating = 1184,

        /// <summary>
        /// <para>MessageId: ERROR_USER_PROFILE_LOAD</para>
        /// <para>MessageText: User profile cannot be loaded.</para>
        /// </summary>
        UserProfileLoad = 500,

        /// <summary>
        /// <para>MessageId: ERROR_ARITHMETIC_OVERFLOW</para>
        /// <para>MessageText: Arithmetic result exceeded= 32 bits.</para>
        /// </summary>
        ArithmeticOverflow = 534,

        /// <summary>
        /// <para>MessageId: ERROR_PIPE_CONNECTED</para>
        /// <para>MessageText: There is a process on other end of the pipe.</para>
        /// </summary>
        PipeConnected = 535,

        /// <summary>
        /// <para>MessageId: ERROR_PIPE_LISTENING</para>
        /// <para>MessageText: Waiting for a process to open the other end of the pipe.</para>
        /// </summary>
        PipeListening = 536,

        /// <summary>
        /// <para>MessageId: ERROR_VERIFIER_STOP</para>
        /// <para>MessageText: Application verifier has found an error in the current process.</para>
        /// </summary>
        VerifierStop = 537,

        /// <summary>
        /// <para>MessageId: ERROR_ABIOS_ERROR</para>
        /// <para>MessageText: An error occurred in the ABIOS subsystem.</para>
        /// </summary>
        AbiosError = 538,

        /// <summary>
        /// <para>MessageId: ERROR_WX86_WARNING</para>
        /// <para>MessageText: A warning occurred in the WX86 subsystem.</para>
        /// </summary>
        WX86Warning = 539,

        /// <summary>
        /// <para>MessageId: ERROR_WX86_ERROR</para>
        /// <para>MessageText: An error occurred in the WX86 subsystem.</para>
        /// </summary>
        WX86Error = 540,

        /// <summary>
        /// <para>MessageId: ERROR_TIMER_NOT_CANCELED</para>
        /// <para>MessageText: An attempt was made to cancel or set a timer that has an associated APC and the subject thread is not the thread that originally set the timer with an associated APC routine.</para>
        /// </summary>
        TimerNotCanceled = 541,

        /// <summary>
        /// <para>MessageId: ERROR_UNWIND</para>
        /// <para>MessageText: Unwind exception code.</para>
        /// </summary>
        Unwind = 542,

        /// <summary>
        /// <para>MessageId: ERROR_BAD_STACK</para>
        /// <para>MessageText: An invalid or unaligned stack was encountered during an unwind operation.</para>
        /// </summary>
        BadStack = 543,

        /// <summary>
        /// <para>MessageId: ERROR_INVALID_UNWIND_TARGET</para>
        /// <para>MessageText: An invalid unwind target was encountered during an unwind operation.</para>
        /// </summary>
        InvalidUnwindTarget = 544,

        /// <summary>
        /// <para>MessageId: ERROR_INVALID_PORT_ATTRIBUTES</para>
        /// <para>MessageText: Invalid Object Attributes specified to NtCreatePort or invalid Port Attributes specified to NtConnectPort</para>
        /// </summary>
        InvalidPortAttributes = 545,

        /// <summary>
        /// <para>MessageId: ERROR_PORT_MESSAGE_TOO_LONG</para>
        /// <para>MessageText: Length of message passed to NtRequestPort or NtRequestWaitReplyPort was longer than the maximum message allowed by the port.</para>
        /// </summary>
        PortMessageTooLong = 546,

        /// <summary>
        /// <para>MessageId: ERROR_INVALID_QUOTA_LOWER</para>
        /// <para>MessageText: An attempt was made to lower a quota limit below the current usage.</para>
        /// </summary>
        InvalidQuotaLower = 547,

        /// <summary>
        /// <para>MessageId: ERROR_DEVICE_ALREADY_ATTACHED</para>
        /// <para>MessageText: An attempt was made to attach to a device that was already attached to another device.</para>
        /// </summary>
        DeviceAlreadyAttached = 548,

        /// <summary>
        /// <para>MessageId: ERROR_INSTRUCTION_MISALIGNMENT</para>
        /// <para>MessageText: An attempt was made to execute an instruction at an unaligned address and the host system does not support unaligned instruction references.</para>
        /// </summary>
        InstructionMisalignment = 549,

        /// <summary>
        /// <para>MessageId: ERROR_PROFILING_NOT_STARTED</para>
        /// <para>MessageText: Profiling not started.</para>
        /// </summary>
        ProfilingNotStarted = 550,

        /// <summary>
        /// <para>MessageId: ERROR_PROFILING_NOT_STOPPED</para>
        /// <para>MessageText: Profiling not stopped.</para>
        /// </summary>
        ProfilingNotStopped = 551,

        /// <summary>
        /// <para>MessageId: ERROR_COULD_NOT_INTERPRET</para>
        /// <para>MessageText: The passed ACL did not contain the minimum required information.</para>
        /// </summary>
        CouldNotInterpret = 552,

        /// <summary>
        /// <para>MessageId: ERROR_PROFILING_AT_LIMIT</para>
        /// <para>MessageText: The number of active profiling objects is at the maximum and no more may be started.</para>
        /// </summary>
        ProfilingAtLimit = 553,

        /// <summary>
        /// <para>MessageId: ERROR_CANT_WAIT</para>
        /// <para>MessageText: Used to indicate that an operation cannot continue without blocking for I/O.</para>
        /// </summary>
        CantWait = 554,

        /// <summary>
        /// <para>MessageId: ERROR_CANT_TERMINATE_SELF</para>
        /// <para>MessageText: Indicates that a thread attempted to terminate itself by default (called NtTerminateThread with NULL) and it was the last thread in the current process.</para>
        /// </summary>
        CantTerminateSelf = 555,

        /// <summary>
        /// <para>MessageId: ERROR_UNEXPECTED_MM_CREATE_ERR</para>
        /// <para>MessageText: If an MM error is returned which is not defined in the standard FsRtl filter, it is converted to one of the following errors which is guaranteed to be in the filter.</para>
        /// </summary>
        UnexpectedMMCreateErr = 556,

        /// <summary>
        /// <para>MessageId: ERROR_UNEXPECTED_MM_MAP_ERROR</para>
        /// <para>MessageText: If an MM error is returned which is not defined in the standard FsRtl filter, it is converted to one of the following errors which is guaranteed to be in the filter.</para>
        /// </summary>
        UnexpectedMMMapError = 557,

        /// <summary>
        /// <para>MessageId: ERROR_UNEXPECTED_MM_EXTEND_ERR</para>
        /// <para>MessageText: If an MM error is returned which is not defined in the standard FsRtl filter, it is converted to one of the following errors which is guaranteed to be in the filter.</para>
        /// </summary>
        UnexpectedMMExtendErr = 558,

        /// <summary>
        /// <para>MessageId: ERROR_BAD_FUNCTION_TABLE</para>
        /// <para>MessageText: A malformed function table was encountered during an unwind operation.</para>
        /// </summary>
        BadFunctionTable = 559,

        /// <summary>
        /// <para>MessageId: ERROR_NO_GUID_TRANSLATION</para>
        /// <para>MessageText: Indicates that an attempt was made to assign protection to a file system file or directory and one of the SIDs in the security descriptor could not be translated into a GUID that could be stored by the file system.</para>
        /// </summary>
        NoGuidTranslation = 560,

        /// <summary>
        /// <para>MessageId: ERROR_INVALID_LDT_SIZE</para>
        /// <para>MessageText: Indicates that an attempt was made to grow an LDT by setting its size, or that the size was not an even number of selectors.</para>
        /// </summary>
        InvalidLDTSize = 561,

        /// <summary>
        /// <para>MessageId: ERROR_INVALID_LDT_OFFSET</para>
        /// <para>MessageText: Indicates that the starting value for the LDT information was not an integral multiple of the selector size.</para>
        /// </summary>
        InvalidLDTOffset = 563,

        /// <summary>
        /// <para>MessageId: ERROR_INVALID_LDT_DESCRIPTOR</para>
        /// <para>MessageText: Indicates that the user supplied an invalid descriptor when trying to set up Ldt descriptors.</para>
        /// </summary>
        InvalidLDTDescriptor = 564,

        /// <summary>
        /// <para>MessageId: ERROR_TOO_MANY_THREADS</para>
        /// <para>MessageText: Indicates a process has too many threads to perform the requested action. For example, assignment of a primary token may only be performed when a process has zero or one threads.</para>
        /// </summary>
        TooManyThreads = 565,

        /// <summary>
        /// <para>MessageId: ERROR_THREAD_NOT_IN_PROCESS</para>
        /// <para>MessageText: An attempt was made to operate on a thread within a specific process, but the thread specified is not in the process specified.</para>
        /// </summary>
        ThreadNotInProcess = 566,

        /// <summary>
        /// <para>MessageId: ERROR_PAGEFILE_QUOTA_EXCEEDED</para>
        /// <para>MessageText: Page file quota was exceeded.</para>
        /// </summary>
        PagefileQuotaExceeded = 567,

        /// <summary>
        /// <para>MessageId: ERROR_LOGON_SERVER_CONFLICT</para>
        /// <para>MessageText: The Netlogon service cannot start because another Netlogon service running in the domain conflicts with the specified role.</para>
        /// </summary>
        LogonServerConflict = 568,

        /// <summary>
        /// <para>MessageId: ERROR_SYNCHRONIZATION_REQUIRED</para>
        /// <para>MessageText: The SAM database on a Windows Server is significantly out of synchronization with the copy on the Domain Controller. A complete synchronization is required.</para>
        /// </summary>
        SynchronizationRequired = 569,

        /// <summary>
        /// <para>MessageId: ERROR_NET_OPEN_FAILED</para>
        /// <para>MessageText: The NtCreateFile API failed. This error should never be returned to an application, it is a place holder for the Windows Lan Manager Redirector to use in its internal error mapping routines.</para>
        /// </summary>
        NetOpenFailed = 570,

        /// <summary>
        /// <para>MessageId: ERROR_IO_PRIVILEGE_FAILED</para>
        /// <para>MessageText: {Privilege Failed}</para>
        /// </summary>
        IOPrivilegeFailed = 571,

        /// <summary>
        /// <para>MessageId: ERROR_CONTROL_C_EXIT</para>
        /// <para>MessageText: {Application Exit by CTRL+C}</para>
        /// </summary>
        ControlCExit = 572,    // winnt

        /// <summary>
        /// <para>MessageId: ERROR_MISSING_SYSTEMFILE</para>
        /// <para>MessageText: {Missing System File}</para>
        /// </summary>
        MissingSystemFile = 573,

        /// <summary>
        /// <para>MessageId: ERROR_UNHANDLED_EXCEPTION</para>
        /// <para>MessageText: {Application Error}</para>
        /// </summary>
        UnhandledException = 574,

        /// <summary>
        /// <para>MessageId: ERROR_APP_INIT_FAILURE</para>
        /// <para>MessageText: {Application Error}</para>
        /// </summary>
        AppInitFailure = 575,

        /// <summary>
        /// <para>MessageId: ERROR_PAGEFILE_CREATE_FAILED</para>
        /// <para>MessageText: {Unable to Create Paging File}</para>
        /// </summary>
        PageFileCreateFailed = 576,

        /// <summary>
        /// <para>MessageId: ERROR_INVALID_IMAGE_HASH</para>
        /// <para>MessageText: Windows cannot verify the digital signature for this file. A recent hardware or software change might have installed a file that is signed incorrectly or damaged, or that might be malicious software from an unknown source.</para>
        /// </summary>
        InvalidImageHash = 577,

        /// <summary>
        /// <para>MessageId: ERROR_NO_PAGEFILE</para>
        /// <para>MessageText: {No Paging File Specified}</para>
        /// </summary>
        NoPageFile = 578,

        /// <summary>
        /// <para>MessageId: ERROR_ILLEGAL_FLOAT_CONTEXT</para>
        /// <para>MessageText: {EXCEPTION}</para>
        /// </summary>
        IllegalFloatContext = 579,

        /// <summary>
        /// <para>MessageId: ERROR_NO_EVENT_PAIR</para>
        /// <para>MessageText: An event pair synchronization operation was performed using the thread specific client/server event pair object, but no event pair object was associated with the thread.</para>
        /// </summary>
        NoEventPair = 580,

        /// <summary>
        /// <para>MessageId: ERROR_DOMAIN_CTRLR_CONFIG_ERROR</para>
        /// <para>MessageText: A Windows Server has an incorrect configuration.</para>
        /// </summary>
        DomainCtrlRConfigError = 581,

        /// <summary>
        /// <para>MessageId: ERROR_ILLEGAL_CHARACTER</para>
        /// <para>MessageText: An illegal character was encountered. For a multi-byte character set this includes a lead byte without a succeeding trail byte. For the Unicode character set this includes the characters= 0xFFFF and= 0xFFFE.</para>
        /// </summary>
        IllegalCharacter = 582,

        /// <summary>
        /// <para>MessageId: ERROR_UNDEFINED_CHARACTER</para>
        /// <para>MessageText: The Unicode character is not defined in the Unicode character set installed on the system.</para>
        /// </summary>
        UndefinedCharacter = 583,

        /// <summary>
        /// <para>MessageId: ERROR_FLOPPY_VOLUME</para>
        /// <para>MessageText: The paging file cannot be created on a floppy diskette.</para>
        /// </summary>
        FloppyVolume = 584,

        /// <summary>
        /// <para>MessageId: ERROR_BIOS_FAILED_TO_CONNECT_INTERRUPT</para>
        /// <para>MessageText: The system BIOS failed to connect a system interrupt to the device or bus for which the device is connected.</para>
        /// </summary>
        BIOSFailedToConnectInterrupt = 585,

        /// <summary>
        /// <para>MessageId: ERROR_BACKUP_CONTROLLER</para>
        /// <para>MessageText: This operation is only allowed for the Primary Domain Controller of the domain.</para>
        /// </summary>
        BackupController = 586,

        /// <summary>
        /// <para>MessageId: ERROR_MUTANT_LIMIT_EXCEEDED</para>
        /// <para>MessageText: An attempt was made to acquire a mutant such that its maximum count would have been exceeded.</para>
        /// </summary>
        MutantLimitExceeded = 587,

        /// <summary>
        /// <para>MessageId: ERROR_FS_DRIVER_REQUIRED</para>
        /// <para>MessageText: A volume has been accessed for which a file system driver is required that has not yet been loaded.</para>
        /// </summary>
        FSDriverRequired = 588,

        /// <summary>
        /// <para>MessageId: ERROR_CANNOT_LOAD_REGISTRY_FILE</para>
        /// <para>MessageText: {Registry File Failure}</para>
        /// </summary>
        CannotLoadRegistryFile = 589,

        /// <summary>
        /// <para>MessageId: ERROR_DEBUG_ATTACH_FAILED</para>
        /// <para>MessageText: {Unexpected Failure in DebugActiveProcess}</para>
        /// </summary>
        DebugAttachFailed = 590,

        /// <summary>
        /// <para>MessageId: ERROR_SYSTEM_PROCESS_TERMINATED</para>
        /// <para>MessageText: {Fatal System Error}</para>
        /// </summary>
        SystemProcessTerminated = 591,

        /// <summary>
        /// <para>MessageId: ERROR_DATA_NOT_ACCEPTED</para>
        /// <para>MessageText: {Data Not Accepted}</para>
        /// </summary>
        DataNotAccepted = 592,

        /// <summary>
        /// <para>MessageId: ERROR_VDM_HARD_ERROR</para>
        /// <para>MessageText: NTVDM encountered a hard error.</para>
        /// </summary>
        VDMHardError = 593,

        /// <summary>
        /// <para>MessageId: ERROR_DRIVER_CANCEL_TIMEOUT</para>
        /// <para>MessageText: {Cancel Timeout}</para>
        /// </summary>
        DriverCancelTimeOut = 594,

        /// <summary>
        /// <para>MessageId: ERROR_REPLY_MESSAGE_MISMATCH</para>
        /// <para>MessageText: {Reply Message Mismatch}</para>
        /// </summary>
        ReplyMessageMismatch = 595,

        /// <summary>
        /// <para>MessageId: ERROR_LOST_WRITEBEHIND_DATA</para>
        /// <para>MessageText: {Delayed Write Failed}</para>
        /// </summary>
        LostWriteBehindData = 596,

        /// <summary>
        /// <para>MessageId: ERROR_CLIENT_SERVER_PARAMETERS_INVALID</para>
        /// <para>MessageText: The parameter(s) passed to the server in the client/server .Shared memory window were invalid. Too much data may have been put in the .Shared memory window.</para>
        /// </summary>
        ClientServerParametersInvalid = 597,

        /// <summary>
        /// <para>MessageId: ERROR_NOT_TINY_STREAM</para>
        /// <para>MessageText: The stream is not a tiny stream.</para>
        /// </summary>
        NotTinyStream = 598,

        /// <summary>
        /// <para>MessageId: ERROR_STACK_OVERFLOW_READ</para>
        /// <para>MessageText: The request must be handled by the stack overflow code.</para>
        /// </summary>
        StackOverflowRead = 599,

        /// <summary>
        /// <para>MessageId: ERROR_CONVERT_TO_LARGE</para>
        /// <para>MessageText: Internal OFS status codes indicating how an allocation operation is handled. Either it is retried after the containing onode is moved or the extent stream is converted to a large stream.</para>
        /// </summary>
        ConvertToLarge = 600,

        /// <summary>
        /// <para>MessageId: ERROR_FOUND_OUT_OF_SCOPE</para>
        /// <para>MessageText: The attempt to find the object found an object matching by ID on the volume but it is out of the scope of the handle used for the operation.</para>
        /// </summary>
        FoundOutOfScope = 601,

        /// <summary>
        /// <para>MessageId: ERROR_ALLOCATE_BUCKET</para>
        /// <para>MessageText: The bucket array must be grown. Retry transaction after doing so.</para>
        /// </summary>
        AllocateBucket = 602,

        /// <summary>
        /// <para>MessageId: ERROR_MARSHALL_OVERFLOW</para>
        /// <para>MessageText: The user/kernel marshalling buffer has overflowed.</para>
        /// </summary>
        MarshallOverflow = 603,

        /// <summary>
        /// <para>MessageId: ERROR_INVALID_VARIANT</para>
        /// <para>MessageText: The supplied variant structure contains invalid data.</para>
        /// </summary>
        InvalidVariant = 604,

        /// <summary>
        /// <para>MessageId: ERROR_BAD_COMPRESSION_BUFFER</para>
        /// <para>MessageText: The specified buffer contains ill-formed data.</para>
        /// </summary>
        BadCompressionBuffer = 605,

        /// <summary>
        /// <para>MessageId: ERROR_AUDIT_FAILED</para>
        /// <para>MessageText: {Audit Failed}</para>
        /// </summary>
        AuditFailed = 606,

        /// <summary>
        /// <para>MessageId: ERROR_TIMER_RESOLUTION_NOT_SET</para>
        /// <para>MessageText: The timer resolution was not previously set by the current process.</para>
        /// </summary>
        TimerResolutionNotSet = 607,

        /// <summary>
        /// <para>MessageId: ERROR_INSUFFICIENT_LOGON_INFO</para>
        /// <para>MessageText: There is insufficient account information to log you on.</para>
        /// </summary>
        InsufficientLogonInfo = 608,

        /// <summary>
        /// <para>MessageId: ERROR_BAD_DLL_ENTRYPOINT</para>
        /// <para>MessageText: {Invalid DLL Entrypoint}</para>
        /// </summary>
        BadDllEntryPoint = 609,

        /// <summary>
        /// <para>MessageId: ERROR_BAD_SERVICE_ENTRYPOINT</para>
        /// <para>MessageText: {Invalid Service Callback Entrypoint}</para>
        /// </summary>
        BadServiceEntryPoint = 610,

        /// <summary>
        /// <para>MessageId: ERROR_IP_ADDRESS_CONFLICT1</para>
        /// <para>MessageText: There is an IP address conflict with another system on the network</para>
        /// </summary>
        IPAddressConflict1 = 611,

        /// <summary>
        /// <para>MessageId: ERROR_IP_ADDRESS_CONFLICT2</para>
        /// <para>MessageText: There is an IP address conflict with another system on the network</para>
        /// </summary>
        IPAddressConflict2 = 612,

        /// <summary>
        /// <para>MessageId: ERROR_REGISTRY_QUOTA_LIMIT</para>
        /// <para>MessageText: {Low On Registry Space}</para>
        /// </summary>
        RegistryQuotaLimit = 613,

        /// <summary>
        /// <para>MessageId: ERROR_NO_CALLBACK_ACTIVE</para>
        /// <para>MessageText: A callback return system service cannot be executed when no callback is active.</para>
        /// </summary>
        NoCallbackActive = 614,

        /// <summary>
        /// <para>MessageId: ERROR_PWD_TOO_SHORT</para>
        /// <para>MessageText: The password provided is too short to meet the policy of your user account.</para>
        /// </summary>
        PWDTooShort = 615,

        /// <summary>
        /// <para>MessageId: ERROR_PWD_TOO_RECENT</para>
        /// <para>MessageText: The policy of your user account does not allow you to change passwords too frequently.</para>
        /// </summary>
        PWDTooRecent = 616,

        /// <summary>
        /// <para>MessageId: ERROR_PWD_HISTORY_CONFLICT</para>
        /// <para>MessageText: You have attempted to change your password to one that you have used in the past.</para>
        /// </summary>
        PWDHistoryConflict = 617,

        /// <summary>
        /// <para>MessageId: ERROR_UNSUPPORTED_COMPRESSION</para>
        /// <para>MessageText: The specified compression format is unsupported.</para>
        /// </summary>
        UnsupportedCompression = 618,

        /// <summary>
        /// <para>MessageId: ERROR_INVALID_HW_PROFILE</para>
        /// <para>MessageText: The specified hardware profile configuration is invalid.</para>
        /// </summary>
        InvalidHwProfile = 619,

        /// <summary>
        /// <para>MessageId: ERROR_INVALID_PLUGPLAY_DEVICE_PATH</para>
        /// <para>MessageText: The specified Plug and Play registry device path is invalid.</para>
        /// </summary>
        InvalidPlugPlayDevicePath = 620,

        /// <summary>
        /// <para>MessageId: ERROR_QUOTA_LIST_INCONSISTENT</para>
        /// <para>MessageText: The specified quota list is internally inconsistent with its descriptor.</para>
        /// </summary>
        QuotaListInconsistent = 621,

        /// <summary>
        /// <para>MessageId: ERROR_EVALUATION_EXPIRATION</para>
        /// <para>MessageText: {Windows Evaluation Notification}</para>
        /// </summary>
        EvaluationExpiration = 622,

        /// <summary>
        /// <para>MessageId: ERROR_ILLEGAL_DLL_RELOCATION</para>
        /// <para>MessageText: {Illegal System DLL Relocation}</para>
        /// </summary>
        IllegalDllRelocation = 623,

        /// <summary>
        /// <para>MessageId: ERROR_DLL_INIT_FAILED_LOGOFF</para>
        /// <para>MessageText: {DLL Initialization Failed}</para>
        /// </summary>
        DllInitFailedLogOff = 624,

        /// <summary>
        /// <para>MessageId: ERROR_VALIDATE_CONTINUE</para>
        /// <para>MessageText: The validation process needs to continue on to the next step.</para>
        /// </summary>
        ValidateContinue = 625,

        /// <summary>
        /// <para>MessageId: ERROR_NO_MORE_MATCHES</para>
        /// <para>MessageText: There are no more matches for the current index enumeration.</para>
        /// </summary>
        NoMoreMatches = 626,

        /// <summary>
        /// <para>MessageId: ERROR_RANGE_LIST_CONFLICT</para>
        /// <para>MessageText: The range could not be added to the range list because of a conflict.</para>
        /// </summary>
        RangeListConflict = 627,

        /// <summary>
        /// <para>MessageId: ERROR_SERVER_SID_MISMATCH</para>
        /// <para>MessageText: The server process is running under a SID different than that required by client.</para>
        /// </summary>
        ServerSidMismatch = 628,

        /// <summary>
        /// <para>MessageId: ERROR_CANT_ENABLE_DENY_ONLY</para>
        /// <para>MessageText: A group marked use for deny only cannot be enabled.</para>
        /// </summary>
        CantEnableDenyOnly = 629,

        /// <summary>
        /// <para>MessageId: ERROR_FLOAT_MULTIPLE_FAULTS</para>
        /// <para>MessageText: {EXCEPTION}</para>
        /// </summary>
        FloatMultipleFaults = 630,    // winnt

        /// <summary>
        /// <para>MessageId: ERROR_FLOAT_MULTIPLE_TRAPS</para>
        /// <para>MessageText: {EXCEPTION}</para>
        /// </summary>
        FloatMultipleTraps = 631,    // winnt

        /// <summary>
        /// <para>MessageId: ERROR_NOINTERFACE</para>
        /// <para>MessageText: The requested interface is not supported.</para>
        /// </summary>
        NoInterface = 632,

        /// <summary>
        /// <para>MessageId: ERROR_DRIVER_FAILED_SLEEP</para>
        /// <para>MessageText: {System Standby Failed}</para>
        /// </summary>
        DriverFailedSleep = 633,

        /// <summary>
        /// <para>MessageId: ERROR_CORRUPT_SYSTEM_FILE</para>
        /// <para>MessageText: The system file %1 has become corrupt and has been replaced.</para>
        /// </summary>
        CorruptSystemFile = 634,

        /// <summary>
        /// <para>MessageId: ERROR_COMMITMENT_MINIMUM</para>
        /// <para>MessageText: {Virtual Memory Minimum Too Low}</para>
        /// </summary>
        CommitmentMinimum = 635,

        /// <summary>
        /// <para>MessageId: ERROR_PNP_RESTART_ENUMERATION</para>
        /// <para>MessageText: A device was removed so enumeration must be restarted.</para>
        /// </summary>
        PNPRestartEnumeration = 636,

        /// <summary>
        /// <para>MessageId: ERROR_SYSTEM_IMAGE_BAD_SIGNATURE</para>
        /// <para>MessageText: {Fatal System Error}</para>
        /// </summary>
        SystemImageBadSignature = 637,

        /// <summary>
        /// <para>MessageId: ERROR_PNP_REBOOT_REQUIRED</para>
        /// <para>MessageText: Device will not start without a reboot.</para>
        /// </summary>
        PNPRebootRequired = 638,

        /// <summary>
        /// <para>MessageId: ERROR_INSUFFICIENT_POWER</para>
        /// <para>MessageText: There is not enough power to complete the requested operation.</para>
        /// </summary>
        InsufficientPower = 639,

        /// <summary>
        /// <para>MessageId: ERROR_MULTIPLE_FAULT_VIOLATION</para>
        /// <para>MessageText:  ERROR_MULTIPLE_FAULT_VIOLATION</para>
        /// </summary>
        MultipleFaultViolation = 640,

        /// <summary>
        /// <para>MessageId: ERROR_SYSTEM_SHUTDOWN</para>
        /// <para>MessageText: The system is in the process of shutting down.</para>
        /// </summary>
        SystemShutdown = 641,

        /// <summary>
        /// <para>MessageId: ERROR_PORT_NOT_SET</para>
        /// <para>MessageText: An attempt to remove a processes DebugPort was made, but a port was not already associated with the process.</para>
        /// </summary>
        PortNotSet = 642,

        /// <summary>
        /// <para>MessageId: ERROR_DS_VERSION_CHECK_FAILURE</para>
        /// <para>MessageText: This version of Windows is not compatible with the behavior version of directory forest, domain or domain controller.</para>
        /// </summary>
        DSVersionCheckFailure = 643,

        /// <summary>
        /// <para>MessageId: ERROR_RANGE_NOT_FOUND</para>
        /// <para>MessageText: The specified range could not be found in the range list.</para>
        /// </summary>
        RangeNotFound = 644,

        /// <summary>
        /// <para>MessageId: ERROR_NOT_SAFE_MODE_DRIVER</para>
        /// <para>MessageText: The driver was not loaded because the system is booting into safe mode.</para>
        /// </summary>
        NotSafeModeDriver = 646,

        /// <summary>
        /// <para>MessageId: ERROR_FAILED_DRIVER_ENTRY</para>
        /// <para>MessageText: The driver was not loaded because it failed its initialization call.</para>
        /// </summary>
        FailedDriverEntry = 647,

        /// <summary>
        /// <para>MessageId: ERROR_DEVICE_ENUMERATION_ERROR</para>
        /// <para>MessageText: The "%hs" encountered an error while applying power or reading the device configuration.</para>
        /// </summary>
        DeviceEnumerationError = 648,

        /// <summary>
        /// <para>MessageId: ERROR_MOUNT_POINT_NOT_RESOLVED</para>
        /// <para>MessageText: The create operation failed because the name contained at least one mount point which resolves to a volume to which the specified device object is not attached.</para>
        /// </summary>
        MountPointNotResolved = 649,

        /// <summary>
        /// <para>MessageId: ERROR_INVALID_DEVICE_OBJECT_PARAMETER</para>
        /// <para>MessageText: The device object parameter is either not a valid device object or is not attached to the volume specified by the file name.</para>
        /// </summary>
        InvalidDeviceObjectParameter = 650,

        /// <summary>
        /// <para>MessageId: ERROR_MCA_OCCURED</para>
        /// <para>MessageText: A Machine Check Error has occurred. Please check the system eventlog for additional information.</para>
        /// </summary>
        MCAOccured = 651,

        /// <summary>
        /// <para>MessageId: ERROR_DRIVER_DATABASE_ERROR</para>
        /// <para>MessageText: There was error [%2] processing the driver database.</para>
        /// </summary>
        DriverDatabaseError = 652,

        /// <summary>
        /// <para>MessageId: ERROR_SYSTEM_HIVE_TOO_LARGE</para>
        /// <para>MessageText: System hive size has exceeded its limit.</para>
        /// </summary>
        SystemHiveTooLarge = 653,

        /// <summary>
        /// <para>MessageId: ERROR_DRIVER_FAILED_PRIOR_UNLOAD</para>
        /// <para>MessageText: The driver could not be loaded because a previous version of the driver is still in memory.</para>
        /// </summary>
        DriverFailedPriorUnload = 654,

        /// <summary>
        /// <para>MessageId: ERROR_VOLSNAP_PREPARE_HIBERNATE</para>
        /// <para>MessageText: {Volume Shadow Copy Service}</para>
        /// </summary>
        VolSnapPrepareHibernate = 655,

        /// <summary>
        /// <para>MessageId: ERROR_HIBERNATION_FAILURE</para>
        /// <para>MessageText: The system has failed to hibernate (The error code is %hs). Hibernation will be disabled until the system is restarted.</para>
        /// </summary>
        HibernationFailure = 656,

        /// <summary>
        /// <para>MessageId: ERROR_PWD_TOO_LONG</para>
        /// <para>MessageText: The password provided is too long to meet the policy of your user account.</para>
        /// </summary>
        PWDTooLong = 657,

        /// <summary>
        /// <para>MessageId: ERROR_FILE_SYSTEM_LIMITATION</para>
        /// <para>MessageText: The requested operation could not be completed due to a file system limitation</para>
        /// </summary>
        FileSystemLimitation = 665,

        /// <summary>
        /// <para>MessageId: ERROR_ASSERTION_FAILURE</para>
        /// <para>MessageText: An assertion failure has occurred.</para>
        /// </summary>
        AssertionFailure = 668,

        /// <summary>
        /// <para>MessageId: ERROR_ACPI_ERROR</para>
        /// <para>MessageText: An error occurred in the ACPI subsystem.</para>
        /// </summary>
        ACPIError = 669,

        /// <summary>
        /// <para>MessageId: ERROR_WOW_ASSERTION</para>
        /// <para>MessageText: WOW Assertion Error.</para>
        /// </summary>
        WOWAssertion = 670,

        /// <summary>
        /// <para>MessageId: ERROR_PNP_BAD_MPS_TABLE</para>
        /// <para>MessageText: A device is missing in the system BIOS MPS table. This device will not be used.</para>
        /// </summary>
        PNPBadMPSTable = 671,

        /// <summary>
        /// <para>MessageId: ERROR_PNP_TRANSLATION_FAILED</para>
        /// <para>MessageText: A translator failed to translate resources.</para>
        /// </summary>
        PNPTranslationFailed = 672,

        /// <summary>
        /// <para>MessageId: ERROR_PNP_IRQ_TRANSLATION_FAILED</para>
        /// <para>MessageText: A IRQ translator failed to translate resources.</para>
        /// </summary>
        PNPIRQTranslationFailed = 673,

        /// <summary>
        /// <para>MessageId: ERROR_PNP_INVALID_ID</para>
        /// <para>MessageText: Driver %2 returned invalid ID for a child device (%3).</para>
        /// </summary>
        PNPInvalidId = 674,

        /// <summary>
        /// <para>MessageId: ERROR_WAKE_SYSTEM_DEBUGGER</para>
        /// <para>MessageText: {Kernel Debugger Awakened}</para>
        /// </summary>
        WakeSystemDebugger = 675,

        /// <summary>
        /// <para>MessageId: ERROR_HANDLES_CLOSED</para>
        /// <para>MessageText: {Handles Closed}</para>
        /// </summary>
        HandlesClosed = 676,

        /// <summary>
        /// <para>MessageId: ERROR_EXTRANEOUS_INFORMATION</para>
        /// <para>MessageText: {Too Much Information}</para>
        /// </summary>
        ExtraneousInformation = 677,

        /// <summary>
        /// <para>MessageId: ERROR_RXACT_COMMIT_NECESSARY</para>
        /// <para>MessageText: This warning level status indicates that the transaction state already exists for the registry sub-tree, but that a transaction commit was previously aborted.</para>
        /// </summary>
        RXACTCommitNecessary = 678,

        /// <summary>
        /// <para>MessageId: ERROR_MEDIA_CHECK</para>
        /// <para>MessageText: {Media Changed}</para>
        /// </summary>
        MediaCheck = 679,

        /// <summary>
        /// <para>MessageId: ERROR_GUID_SUBSTITUTION_MADE</para>
        /// <para>MessageText: {GUID Substitution}</para>
        /// </summary>
        GuidSubstitutionMade = 680,

        /// <summary>
        /// <para>MessageId: ERROR_STOPPED_ON_SYMLINK</para>
        /// <para>MessageText: The create operation stopped after reaching a symbolic link</para>
        /// </summary>
        StoppedOnSymLink = 681,

        /// <summary>
        /// <para>MessageId: ERROR_LONGJUMP</para>
        /// <para>MessageText: A long jump has been executed.</para>
        /// </summary>
        LongJump = 682,

        /// <summary>
        /// <para>MessageId: ERROR_PLUGPLAY_QUERY_VETOED</para>
        /// <para>MessageText: The Plug and Play query operation was not successful.</para>
        /// </summary>
        PlugPlayQueryVetoed = 683,

        /// <summary>
        /// <para>MessageId: ERROR_UNWIND_CONSOLIDATE</para>
        /// <para>MessageText: A frame consolidation has been executed.</para>
        /// </summary>
        UnwindConsolidate = 684,

        /// <summary>
        /// <para>MessageId: ERROR_REGISTRY_HIVE_RECOVERED</para>
        /// <para>MessageText: {Registry Hive Recovered}</para>
        /// </summary>
        RegistryHiveRecovered = 685,

        /// <summary>
        /// <para>MessageId: ERROR_DLL_MIGHT_BE_INSECURE</para>
        /// <para>MessageText: The application is attempting to run executable code from the module %hs. This may be insecure. An alternative, %hs, is available. Should the application use the secure module %hs?</para>
        /// </summary>
        DllMightBeInsecure = 686,

        /// <summary>
        /// <para>MessageId: ERROR_DLL_MIGHT_BE_INCOMPATIBLE</para>
        /// <para>MessageText: The application is loading executable code from the module %hs. This is secure, but may be incompatible with previous releases of the operating system. An alternative, %hs, is available. Should the application use the secure module %hs?</para>
        /// </summary>
        DllMightBeIncompatible = 687,

        /// <summary>
        /// <para>MessageId: ERROR_DBG_EXCEPTION_NOT_HANDLED</para>
        /// <para>MessageText: Debugger did not handle the exception.</para>
        /// </summary>
        DbgExceptionNotHandled = 688,    // winnt

        /// <summary>
        /// <para>MessageId: ERROR_DBG_REPLY_LATER</para>
        /// <para>MessageText: Debugger will reply later.</para>
        /// </summary>
        DbgReplyLater = 689,

        /// <summary>
        /// <para>MessageId: ERROR_DBG_UNABLE_TO_PROVIDE_HANDLE</para>
        /// <para>MessageText: Debugger cannot provide handle.</para>
        /// </summary>
        DbgUnableToProvideHandle = 690,

        /// <summary>
        /// <para>MessageId: ERROR_DBG_TERMINATE_THREAD</para>
        /// <para>MessageText: Debugger terminated thread.</para>
        /// </summary>
        DbgTerminateThread = 691,    // winnt

        /// <summary>
        /// <para>MessageId: ERROR_DBG_TERMINATE_PROCESS</para>
        /// <para>MessageText: Debugger terminated process.</para>
        /// </summary>
        DbgTerminateProcess = 692,    // winnt

        /// <summary>
        /// <para>MessageId: ERROR_DBG_CONTROL_C</para>
        /// <para>MessageText: Debugger got control C.</para>
        /// </summary>
        DbgControlC = 693,    // winnt

        /// <summary>
        /// <para>MessageId: ERROR_DBG_PRINTEXCEPTION_C</para>
        /// <para>MessageText: Debugger printed exception on control C.</para>
        /// </summary>
        DbgPrintExceptionC = 694,

        /// <summary>
        /// <para>MessageId: ERROR_DBG_RIPEXCEPTION</para>
        /// <para>MessageText: Debugger received RIP exception.</para>
        /// </summary>
        DbgRipException = 695,

        /// <summary>
        /// <para>MessageId: ERROR_DBG_CONTROL_BREAK</para>
        /// <para>MessageText: Debugger received control break.</para>
        /// </summary>
        DbgControlBreak = 696,    // winnt

        /// <summary>
        /// <para>MessageId: ERROR_DBG_COMMAND_EXCEPTION</para>
        /// <para>MessageText: Debugger command communication exception.</para>
        /// </summary>
        DbgCommandException = 697,    // winnt

        /// <summary>
        /// <para>MessageId: ERROR_OBJECT_NAME_EXISTS</para>
        /// <para>MessageText: {Object Exists}</para>
        /// </summary>
        ObjectNameExists = 698,

        /// <summary>
        /// <para>MessageId: ERROR_THREAD_WAS_SUSPENDED</para>
        /// <para>MessageText: {Thread Suspended}</para>
        /// </summary>
        ThreadWasSuspended = 699,

        /// <summary>
        /// <para>MessageId: ERROR_IMAGE_NOT_AT_BASE</para>
        /// <para>MessageText: {Image Relocated}</para>
        /// </summary>
        ImageNotAtBase = 700,

        /// <summary>
        /// <para>MessageId: ERROR_RXACT_STATE_CREATED</para>
        /// <para>MessageText: This informational level status indicates that a specified registry sub-tree transaction state did not yet exist and had to be created.</para>
        /// </summary>
        RXACTStateCreated = 701,

        /// <summary>
        /// <para>MessageId: ERROR_SEGMENT_NOTIFICATION</para>
        /// <para>MessageText: {Segment Load}</para>
        /// </summary>
        SegmentNotification = 702,    // winnt

        /// <summary>
        /// <para>MessageId: ERROR_BAD_CURRENT_DIRECTORY</para>
        /// <para>MessageText: {Invalid Current Directory}</para>
        /// </summary>
        BadCurrentDirectory = 703,

        /// <summary>
        /// <para>MessageId: ERROR_FT_READ_RECOVERY_FROM_BACKUP</para>
        /// <para>MessageText: {Redundant Read}</para>
        /// </summary>
        FTReadRecoveryFromBackup = 704,

        /// <summary>
        /// <para>MessageId: ERROR_FT_WRITE_RECOVERY</para>
        /// <para>MessageText: {Redundant Write}</para>
        /// </summary>
        FTWriteRecovery = 705,

        /// <summary>
        /// <para>MessageId: ERROR_IMAGE_MACHINE_TYPE_MISMATCH</para>
        /// <para>MessageText: {Machine Type Mismatch}</para>
        /// </summary>
        ImageMachineTypeMismatch = 706,

        /// <summary>
        /// <para>MessageId: ERROR_RECEIVE_PARTIAL</para>
        /// <para>MessageText: {Partial Data Received}</para>
        /// </summary>
        ReceivePartial = 707,

        /// <summary>
        /// <para>MessageId: ERROR_RECEIVE_EXPEDITED</para>
        /// <para>MessageText: {Expedited Data Received}</para>
        /// </summary>
        ReceiveExpedited = 708,

        /// <summary>
        /// <para>MessageId: ERROR_RECEIVE_PARTIAL_EXPEDITED</para>
        /// <para>MessageText: {Partial Expedited Data Received}</para>
        /// </summary>
        ReceivePartialExpedited = 709,

        /// <summary>
        /// <para>MessageId: ERROR_EVENT_DONE</para>
        /// <para>MessageText: {TDI Event Done}</para>
        /// </summary>
        EventDone = 710,

        /// <summary>
        /// <para>MessageId: ERROR_EVENT_PENDING</para>
        /// <para>MessageText: {TDI Event Pending}</para>
        /// </summary>
        EventPending = 711,

        /// <summary>
        /// <para>MessageId: ERROR_CHECKING_FILE_SYSTEM</para>
        /// <para>MessageText: Checking file system on %wZ</para>
        /// </summary>
        CheckingFileSystem = 712,

        /// <summary>
        /// <para>MessageId: ERROR_FATAL_APP_EXIT</para>
        /// <para>MessageText: {Fatal Application Exit}</para>
        /// </summary>
        FatalAppExit = 713,

        /// <summary>
        /// <para>MessageId: ERROR_PREDEFINED_HANDLE</para>
        /// <para>MessageText: The specified registry key is referenced by a predefined handle.</para>
        /// </summary>
        PredefinedHandle = 714,

        /// <summary>
        /// <para>MessageId: ERROR_WAS_UNLOCKED</para>
        /// <para>MessageText: {Page Unlocked}</para>
        /// </summary>
        WasUnlocked = 715,

        /// <summary>
        /// <para>MessageId: ERROR_SERVICE_NOTIFICATION</para>
        /// <para>MessageText: %hs</para>
        /// </summary>
        ServiceNotification = 716,

        /// <summary>
        /// <para>MessageId: ERROR_WAS_LOCKED</para>
        /// <para>MessageText: {Page Locked}</para>
        /// </summary>
        WasLocked = 717,

        /// <summary>
        /// <para>MessageId: ERROR_LOG_HARD_ERROR</para>
        /// <para>MessageText: Application popup: %1 : %2</para>
        /// </summary>
        LogHardError = 718,

        /// <summary>
        /// <para>MessageId: ERROR_ALREADY_WIN32</para>
        /// <para>MessageText:  ERROR_ALREADY_WIN32</para>
        /// </summary>
        AlreadyWin32 = 719,

        /// <summary>
        /// <para>MessageId: ERROR_IMAGE_MACHINE_TYPE_MISMATCH_EXE</para>
        /// <para>MessageText: {Machine Type Mismatch}</para>
        /// </summary>
        ImageMachineTypeMismatchExe = 720,

        /// <summary>
        /// <para>MessageId: ERROR_NO_YIELD_PERFORMED</para>
        /// <para>MessageText: A yield execution was performed and no thread was available to run.</para>
        /// </summary>
        NoYieldPerformed = 721,

        /// <summary>
        /// <para>MessageId: ERROR_TIMER_RESUME_IGNORED</para>
        /// <para>MessageText: The resumable flag to a timer API was ignored.</para>
        /// </summary>
        TimerResumeIgnored = 722,

        /// <summary>
        /// <para>MessageId: ERROR_ARBITRATION_UNHANDLED</para>
        /// <para>MessageText: The arbiter has deferred arbitration of these resources to its parent</para>
        /// </summary>
        ArbitrationUnhandled = 723,

        /// <summary>
        /// <para>MessageId: ERROR_CARDBUS_NOT_SUPPORTED</para>
        /// <para>MessageText: The inserted CardBus device cannot be started because of a configuration error on "%hs".</para>
        /// </summary>
        CardBusNotSupported = 724,

        /// <summary>
        /// <para>MessageId: ERROR_MP_PROCESSOR_MISMATCH</para>
        /// <para>MessageText: The CPUs in this multiprocessor system are not all the same revision level. To use all processors the operating system restricts itself to the features of the least capable processor in the system. Should problems occur with this system, contact the CPU manufacturer to see if this mix of processors is supported.</para>
        /// </summary>
        MPProcessorMismatch = 725,

        /// <summary>
        /// <para>MessageId: ERROR_HIBERNATED</para>
        /// <para>MessageText: The system was put into hibernation.</para>
        /// </summary>
        Hibernated = 726,

        /// <summary>
        /// <para>MessageId: ERROR_RESUME_HIBERNATION</para>
        /// <para>MessageText: The system was resumed from hibernation.</para>
        /// </summary>
        ResumeHibernation = 727,

        /// <summary>
        /// <para>MessageId: ERROR_FIRMWARE_UPDATED</para>
        /// <para>MessageText: Windows has detected that the system firmware (BIOS) was updated [previous firmware date = %2, current firmware date %3].</para>
        /// </summary>
        FirmwareUpdated = 728,

        /// <summary>
        /// <para>MessageId: ERROR_DRIVERS_LEAKING_LOCKED_PAGES</para>
        /// <para>MessageText: A device driver is leaking locked I/O pages causing system degradation. The system has automatically enabled tracking code in order to try and catch the culprit.</para>
        /// </summary>
        DriversLeakingLockedPages = 729,

        /// <summary>
        /// <para>MessageId: ERROR_WAKE_SYSTEM</para>
        /// <para>MessageText: The system has awoken</para>
        /// </summary>
        WakeSystem = 730,

        /// <summary>
        /// <para>MessageId: ERROR_WAIT_1</para>
        /// <para>MessageText:  ERROR_WAIT_1</para>
        /// </summary>
        Wait1 = 731,

        /// <summary>
        /// <para>MessageId: ERROR_WAIT_2</para>
        /// <para>MessageText:  ERROR_WAIT_2</para>
        /// </summary>
        Wait2 = 732,

        /// <summary>
        /// <para>MessageId: ERROR_WAIT_3</para>
        /// <para>MessageText:  ERROR_WAIT_3</para>
        /// </summary>
        Wait3 = 733,

        /// <summary>
        /// <para>MessageId: ERROR_WAIT_63</para>
        /// <para>MessageText:  ERROR_WAIT_63</para>
        /// </summary>
        Wait63 = 734,

        /// <summary>
        /// <para>MessageId: ERROR_ABANDONED_WAIT_0</para>
        /// <para>MessageText:  ERROR_ABANDONED_WAIT_0</para>
        /// </summary>
        AbandonedWait0 = 735,    // winnt

        /// <summary>
        /// <para>MessageId: ERROR_ABANDONED_WAIT_63</para>
        /// <para>MessageText:  ERROR_ABANDONED_WAIT_63</para>
        /// </summary>
        AbandonedWait63 = 736,

        /// <summary>
        /// <para>MessageId: ERROR_USER_APC</para>
        /// <para>MessageText:  ERROR_USER_APC</para>
        /// </summary>
        UserApc = 737,    // winnt

        /// <summary>
        /// <para>MessageId: ERROR_KERNEL_APC</para>
        /// <para>MessageText:  ERROR_KERNEL_APC</para>
        /// </summary>
        KernelAPC = 738,

        /// <summary>
        /// <para>MessageId: ERROR_ALERTED</para>
        /// <para>MessageText:  ERROR_ALERTED</para>
        /// </summary>
        Alerted = 739,

        /// <summary>
        /// <para>MessageId: ERROR_ELEVATION_REQUIRED</para>
        /// <para>MessageText: The requested operation requires elevation.</para>
        /// </summary>
        ElevationRequired = 740,

        /// <summary>
        /// <para>MessageId: ERROR_REPARSE</para>
        /// <para>MessageText: A reparse should be performed by the Object Manager since the name of the file resulted in a symbolic link.</para>
        /// </summary>
        Reparse = 741,

        /// <summary>
        /// <para>MessageId: ERROR_OPLOCK_BREAK_IN_PROGRESS</para>
        /// <para>MessageText: An open/create operation completed while an oplock break is underway.</para>
        /// </summary>
        OplockBreakInProgress = 742,

        /// <summary>
        /// <para>MessageId: ERROR_VOLUME_MOUNTED</para>
        /// <para>MessageText: A new volume has been mounted by a file system.</para>
        /// </summary>
        VolumeMounted = 743,

        /// <summary>
        /// <para>MessageId: ERROR_RXACT_COMMITTED</para>
        /// <para>MessageText: This success level status indicates that the transaction state already exists for the registry sub-tree, but that a transaction commit was previously aborted.</para>
        /// </summary>
        RXACTCommitted = 744,

        /// <summary>
        /// <para>MessageId: ERROR_NOTIFY_CLEANUP</para>
        /// <para>MessageText: This indicates that a notify change request has been completed due to closing the handle which made the notify change request.</para>
        /// </summary>
        NotifyCleanup = 745,

        /// <summary>
        /// <para>MessageId: ERROR_PRIMARY_TRANSPORT_CONNECT_FAILED</para>
        /// <para>MessageText: {Connect Failure on Primary Transport}</para>
        /// </summary>
        PrimaryTransportConnectFailed = 746,

        /// <summary>
        /// <para>MessageId: ERROR_PAGE_FAULT_TRANSITION</para>
        /// <para>MessageText: Page fault was a transition fault.</para>
        /// </summary>
        PageFaultTransition = 747,

        /// <summary>
        /// <para>MessageId: ERROR_PAGE_FAULT_DEMAND_ZERO</para>
        /// <para>MessageText: Page fault was a demand zero fault.</para>
        /// </summary>
        PageFaultDemandZero = 748,

        /// <summary>
        /// <para>MessageId: ERROR_PAGE_FAULT_COPY_ON_WRITE</para>
        /// <para>MessageText: Page fault was a demand zero fault.</para>
        /// </summary>
        PageFaultCopyOnWrite = 749,

        /// <summary>
        /// <para>MessageId: ERROR_PAGE_FAULT_GUARD_PAGE</para>
        /// <para>MessageText: Page fault was a demand zero fault.</para>
        /// </summary>
        PageFaultGuardPage = 750,

        /// <summary>
        /// <para>MessageId: ERROR_PAGE_FAULT_PAGING_FILE</para>
        /// <para>MessageText: Page fault was satisfied by reading from a secondary storage device.</para>
        /// </summary>
        PageFaultPagingFile = 751,

        /// <summary>
        /// <para>MessageId: ERROR_CACHE_PAGE_LOCKED</para>
        /// <para>MessageText: Cached page was locked during operation.</para>
        /// </summary>
        CachePageLocked = 752,

        /// <summary>
        /// <para>MessageId: ERROR_CRASH_DUMP</para>
        /// <para>MessageText: Crash dump exists in paging file.</para>
        /// </summary>
        CrashDump = 753,

        /// <summary>
        /// <para>MessageId: ERROR_BUFFER_ALL_ZEROS</para>
        /// <para>MessageText: Specified buffer contains all zeros.</para>
        /// </summary>
        BufferAllZeros = 754,

        /// <summary>
        /// <para>MessageId: ERROR_REPARSE_OBJECT</para>
        /// <para>MessageText: A reparse should be performed by the Object Manager since the name of the file resulted in a symbolic link.</para>
        /// </summary>
        ReparseObject = 755,

        /// <summary>
        /// <para>MessageId: ERROR_RESOURCE_REQUIREMENTS_CHANGED</para>
        /// <para>MessageText: The device has succeeded a query-stop and its resource requirements have changed.</para>
        /// </summary>
        ResourceRequirementsChanged = 756,

        /// <summary>
        /// <para>MessageId: ERROR_TRANSLATION_COMPLETE</para>
        /// <para>MessageText: The translator has translated these resources into the global space and no further translations should be performed.</para>
        /// </summary>
        TranslationComplete = 757,

        /// <summary>
        /// <para>MessageId: ERROR_NOTHING_TO_TERMINATE</para>
        /// <para>MessageText: A process being terminated has no threads to terminate.</para>
        /// </summary>
        NothingToTerminate = 758,

        /// <summary>
        /// <para>MessageId: ERROR_PROCESS_NOT_IN_JOB</para>
        /// <para>MessageText: The specified process is not part of a job.</para>
        /// </summary>
        ProcessNotInJob = 759,

        /// <summary>
        /// <para>MessageId: ERROR_PROCESS_IN_JOB</para>
        /// <para>MessageText: The specified process is part of a job.</para>
        /// </summary>
        ProcessInJob = 760,

        /// <summary>
        /// <para>MessageId: ERROR_VOLSNAP_HIBERNATE_READY</para>
        /// <para>MessageText: {Volume Shadow Copy Service}</para>
        /// </summary>
        VolSnapHibernateReady = 761,

        /// <summary>
        /// <para>MessageId: ERROR_FSFILTER_OP_COMPLETED_SUCCESSFULLY</para>
        /// <para>MessageText: A file system or file system filter driver has successfully completed an FsFilter operation.</para>
        /// </summary>
        FSFilterOpCompletedSuccessfully = 762,

        /// <summary>
        /// <para>MessageId: ERROR_INTERRUPT_VECTOR_ALREADY_CONNECTED</para>
        /// <para>MessageText: The specified interrupt vector was already connected.</para>
        /// </summary>
        InterruptVectorAlreadyConnected = 763,

        /// <summary>
        /// <para>MessageId: ERROR_INTERRUPT_STILL_CONNECTED</para>
        /// <para>MessageText: The specified interrupt vector is still connected.</para>
        /// </summary>
        InterruptStillConnected = 764,

        /// <summary>
        /// <para>MessageId: ERROR_WAIT_FOR_OPLOCK</para>
        /// <para>MessageText: An operation is blocked waiting for an oplock.</para>
        /// </summary>
        WaitForOplock = 765,

        /// <summary>
        /// <para>MessageId: ERROR_DBG_EXCEPTION_HANDLED</para>
        /// <para>MessageText: Debugger handled exception</para>
        /// </summary>
        DbgExceptionHandled = 766,    // winnt

        /// <summary>
        /// <para>MessageId: ERROR_DBG_CONTINUE</para>
        /// <para>MessageText: Debugger continued</para>
        /// </summary>
        DbgContinue = 767,    // winnt

        /// <summary>
        /// <para>MessageId: ERROR_CALLBACK_POP_STACK</para>
        /// <para>MessageText: An exception occurred in a user mode callback and the kernel callback frame should be removed.</para>
        /// </summary>
        CallbackPopStack = 768,

        /// <summary>
        /// <para>MessageId: ERROR_COMPRESSION_DISABLED</para>
        /// <para>MessageText: Compression is disabled for this volume.</para>
        /// </summary>
        CompressionDisabled = 769,

        /// <summary>
        /// <para>MessageId: ERROR_CANTFETCHBACKWARDS</para>
        /// <para>MessageText: The data provider cannot fetch backwards through a result set.</para>
        /// </summary>
        CantFetchBackwards = 770,

        /// <summary>
        /// <para>MessageId: ERROR_CANTSCROLLBACKWARDS</para>
        /// <para>MessageText: The data provider cannot scroll backwards through a result set.</para>
        /// </summary>
        CantScrollBackwards = 771,

        /// <summary>
        /// <para>MessageId: ERROR_ROWSNOTRELEASED</para>
        /// <para>MessageText: The data provider requires that previously fetched data is released before asking for more data.</para>
        /// </summary>
        RowsNotReleased = 772,

        /// <summary>
        /// <para>MessageId: ERROR_BAD_ACCESSOR_FLAGS</para>
        /// <para>MessageText: The data provider was not able to interpret the flags set for a column binding in an accessor.</para>
        /// </summary>
        BadAccessorFlags = 773,

        /// <summary>
        /// <para>MessageId: ERROR_ERRORS_ENCOUNTERED</para>
        /// <para>MessageText: One or more errors occurred while processing the request.</para>
        /// </summary>
        ErrorsEncountered = 774,

        /// <summary>
        /// <para>MessageId: ERROR_NOT_CAPABLE</para>
        /// <para>MessageText: The implementation is not capable of performing the request.</para>
        /// </summary>
        NotCapable = 775,

        /// <summary>
        /// <para>MessageId: ERROR_REQUEST_OUT_OF_SEQUENCE</para>
        /// <para>MessageText: The client of a component requested an operation which is not valid given the state of the component instance.</para>
        /// </summary>
        RequestOutOfSequence = 776,

        /// <summary>
        /// <para>MessageId: ERROR_VERSION_PARSE_ERROR</para>
        /// <para>MessageText: A version number could not be parsed.</para>
        /// </summary>
        VersionParseError = 777,

        /// <summary>
        /// <para>MessageId: ERROR_BADSTARTPOSITION</para>
        /// <para>MessageText: The iterator's start position is invalid.</para>
        /// </summary>
        BadStartPosition = 778,

        /// <summary>
        /// <para>MessageId: ERROR_MEMORY_HARDWARE</para>
        /// <para>MessageText: The hardware has reported an uncorrectable memory error.</para>
        /// </summary>
        MemoryHardware = 779,

        /// <summary>
        /// <para>MessageId: ERROR_DISK_REPAIR_DISABLED</para>
        /// <para>MessageText: The attempted operation required self healing to be enabled.</para>
        /// </summary>
        DiskRepairDisabled = 780,

        /// <summary>
        /// <para>MessageId: ERROR_INSUFFICIENT_RESOURCE_FOR_SPECIFIED_SHARED_SECTION_SIZE</para>
        /// <para>MessageText: The Desktop heap encountered an error while allocating session memory. There is more information in the system event log.</para>
        /// </summary>
        InsufficientResourceForSpecifiedSharedSectionSize = 781,

        /// <summary>
        /// <para>MessageId: ERROR_SYSTEM_POWERSTATE_TRANSITION</para>
        /// <para>MessageText: The system power state is transitioning from %2 to %3.</para>
        /// </summary>
        SystemPowerStateTransition = 782,

        /// <summary>
        /// <para>MessageId: ERROR_SYSTEM_POWERSTATE_COMPLEX_TRANSITION</para>
        /// <para>MessageText: The system power state is transitioning from %2 to %3 but could enter %4.</para>
        /// </summary>
        SystemPowerStateComplexTransition = 783,

        /// <summary>
        /// <para>MessageId: ERROR_MCA_EXCEPTION</para>
        /// <para>MessageText: A thread is getting dispatched with MCA EXCEPTION because of MCA.</para>
        /// </summary>
        MCAException = 784,

        /// <summary>
        /// <para>MessageId: ERROR_ACCESS_AUDIT_BY_POLICY</para>
        /// <para>MessageText: Access to %1 is monitored by policy rule %2.</para>
        /// </summary>
        AccessAuditByPolicy = 785,

        /// <summary>
        /// <para>MessageId: ERROR_ACCESS_DISABLED_NO_SAFER_UI_BY_POLICY</para>
        /// <para>MessageText: Access to %1 has been restricted by your Administrator by policy rule %2.</para>
        /// </summary>
        AccessDisabledNoSaferUIByPolicy = 786,

        /// <summary>
        /// <para>MessageId: ERROR_ABANDON_HIBERFILE</para>
        /// <para>MessageText: A valid hibernation file has been invalidated and should be abandoned.</para>
        /// </summary>
        AbandonHiberFile = 787,

        /// <summary>
        /// <para>MessageId: ERROR_LOST_WRITEBEHIND_DATA_NETWORK_DISCONNECTED</para>
        /// <para>MessageText: {Delayed Write Failed}</para>
        /// </summary>
        LostWriteBehindDataNetworkDisconnected = 788,

        /// <summary>
        /// <para>MessageId: ERROR_LOST_WRITEBEHIND_DATA_NETWORK_SERVER_ERROR</para>
        /// <para>MessageText: {Delayed Write Failed}</para>
        /// </summary>
        LostWriteBehindDataNetworkServerError = 789,

        /// <summary>
        /// <para>MessageId: ERROR_LOST_WRITEBEHIND_DATA_LOCAL_DISK_ERROR</para>
        /// <para>MessageText: {Delayed Write Failed}</para>
        /// </summary>
        LostWriteBehindDataLocalDiskError = 790,

        /// <summary>
        /// <para>MessageId: ERROR_BAD_MCFG_TABLE</para>
        /// <para>MessageText: The resources required for this device conflict with the MCFG table.</para>
        /// </summary>
        BadMCFGTable = 791,

        /// <summary>
        /// <para>MessageId: ERROR_DISK_REPAIR_REDIRECTED</para>
        /// <para>MessageText: The volume repair could not be performed while it is online.</para>
        /// </summary>
        DiskRepairRedirected = 792,

        /// <summary>
        /// <para>MessageId: ERROR_DISK_REPAIR_UNSUCCESSFUL</para>
        /// <para>MessageText: The volume repair was not successful.</para>
        /// </summary>
        DiskRepairUnsuccessful = 793,

        /// <summary>
        /// <para>MessageId: ERROR_CORRUPT_LOG_OVERFULL</para>
        /// <para>MessageText: One of the volume corruption logs is full. Further corruptions that may be detected won't be logged.</para>
        /// </summary>
        CorruptLogOverfull = 794,

        /// <summary>
        /// <para>MessageId: ERROR_CORRUPT_LOG_CORRUPTED</para>
        /// <para>MessageText: One of the volume corruption logs is internally corrupted and needs to be recreated. The volume may contain undetected corruptions and must be scanned.</para>
        /// </summary>
        CorruptLogCorrupted = 795,

        /// <summary>
        /// <para>MessageId: ERROR_CORRUPT_LOG_UNAVAILABLE</para>
        /// <para>MessageText: One of the volume corruption logs is unavailable for being operated on.</para>
        /// </summary>
        CorruptLogUnavailable = 796,

        /// <summary>
        /// <para>MessageId: ERROR_CORRUPT_LOG_DELETED_FULL</para>
        /// <para>MessageText: One of the volume corruption logs was deleted while still having corruption records in them. The volume contains detected corruptions and must be scanned.</para>
        /// </summary>
        CorruptLogDeletedFull = 797,

        /// <summary>
        /// <para>MessageId: ERROR_CORRUPT_LOG_CLEARED</para>
        /// <para>MessageText: One of the volume corruption logs was cleared by chkdsk and no longer contains real corruptions.</para>
        /// </summary>
        CorruptLogCleared = 798,

        /// <summary>
        /// <para>MessageId: ERROR_ORPHAN_NAME_EXHAUSTED</para>
        /// <para>MessageText: Orphaned files exist on the volume but could not be recovered because no more new names could be created in the recovery directory. Files must be moved from the recovery directory.</para>
        /// </summary>
        OrphanNameExhausted = 799,

        /// <summary>
        /// <para>MessageId: ERROR_OPLOCK_SWITCHED_TO_NEW_HANDLE</para>
        /// <para>MessageText: The oplock that was associated with this handle is now associated with a different handle.</para>
        /// </summary>
        OplockSwitchedToNewHandle = 800,

        /// <summary>
        /// <para>MessageId: ERROR_CANNOT_GRANT_REQUESTED_OPLOCK</para>
        /// <para>MessageText: An oplock of the requested level cannot be granted.  An oplock of a lower level may be available.</para>
        /// </summary>
        CannotGrantRequestedOplock = 801,

        /// <summary>
        /// <para>MessageId: ERROR_CANNOT_BREAK_OPLOCK</para>
        /// <para>MessageText: The operation did not complete successfully because it would cause an oplock to be broken. The caller has requested that existing oplocks not be broken.</para>
        /// </summary>
        CannotBreakOplock = 802,

        /// <summary>
        /// <para>MessageId: ERROR_OPLOCK_HANDLE_CLOSED</para>
        /// <para>MessageText: The handle with which this oplock was associated has been closed.  The oplock is now broken.</para>
        /// </summary>
        OplockHandleClosed = 803,

        /// <summary>
        /// <para>MessageId: ERROR_NO_ACE_CONDITION</para>
        /// <para>MessageText: The specified access control entry (ACE) does not contain a condition.</para>
        /// </summary>
        NoACECondition = 804,

        /// <summary>
        /// <para>MessageId: ERROR_INVALID_ACE_CONDITION</para>
        /// <para>MessageText: The specified access control entry (ACE) contains an invalid condition.</para>
        /// </summary>
        InvalidACECondition = 805,

        /// <summary>
        /// <para>MessageId: ERROR_FILE_HANDLE_REVOKED</para>
        /// <para>MessageText: Access to the specified file handle has been revoked.</para>
        /// </summary>
        FileHandleRevoked = 806,

        /// <summary>
        /// <para>MessageId: ERROR_IMAGE_AT_DIFFERENT_BASE</para>
        /// <para>MessageText: {Image Relocated}</para>
        /// </summary>
        ImageAtDifferentBase = 807,

        /// <summary>
        /// <para>MessageId: ERROR_ENCRYPTED_IO_NOT_POSSIBLE</para>
        /// <para>MessageText: The read or write operation to an encrypted file could not be completed because the file has not been opened for data access.</para>
        /// </summary>
        EncryptedIONotPossible = 808,

        /// <summary>
        /// <para>MessageId: ERROR_FILE_METADATA_OPTIMIZATION_IN_PROGRESS</para>
        /// <para>MessageText: File metadata optimization is already in progress.</para>
        /// </summary>
        FileMetadataOptimizationInProgress = 809,

        /// <summary>
        /// <para>MessageId: ERROR_QUOTA_ACTIVITY</para>
        /// <para>MessageText: The requested operation failed due to quota operation is still in progress.</para>
        /// </summary>
        QuotaActivity = 810,

        /// <summary>
        /// <para>MessageId: ERROR_HANDLE_REVOKED</para>
        /// <para>MessageText: Access to the specified handle has been revoked.</para>
        /// </summary>
        HandleRevoked = 811,

        /// <summary>
        /// <para>MessageId: ERROR_CALLBACK_INVOKE_INLINE</para>
        /// <para>MessageText: The callback function must be invoked inline.</para>
        /// </summary>
        CallbackInvokeInline = 812,

        /// <summary>
        /// <para>MessageId: ERROR_CPU_SET_INVALID</para>
        /// <para>MessageText: The specified CPU Set IDs are invalid.</para>
        /// </summary>
        CPUSetInvalid = 813,

        /// <summary>
        /// <para>MessageId: ERROR_ENCLAVE_NOT_TERMINATED</para>
        /// <para>MessageText: The specified enclave has not yet been terminated.</para>
        /// </summary>
        EnclaveNotTerminated = 814,

        /// <summary>
        /// <para>MessageId: ERROR_ENCLAVE_VIOLATION</para>
        /// <para>MessageText: An attempt was made to access protected memory in violation of its secure access policy.</para>
        /// </summary>
        EnclaveViolation = 815,

        /// <summary>
        /// <para>MessageId: ERROR_EA_ACCESS_DENIED</para>
        /// <para>MessageText: Access to the extended attribute was denied.</para>
        /// </summary>
        EAAccessDenied = 994,

        /// <summary>
        /// <para>MessageId: ERROR_OPERATION_ABORTED</para>
        /// <para>MessageText: The I/O operation has been aborted because of either a thread exit or an application request.</para>
        /// </summary>
        OperationAborted = 995,

        /// <summary>
        /// <para>MessageId: ERROR_IO_INCOMPLETE</para>
        /// <para>MessageText: Overlapped I/O event is not in a signaled state.</para>
        /// </summary>
        IOIncomplete = 996,

        /// <summary>
        /// <para>MessageId: ERROR_IO_PENDING</para>
        /// <para>MessageText: Overlapped I/O operation is in progress.</para>
        /// </summary>
        IOPending = 997,    // dderror

        /// <summary>
        /// <para>MessageId: ERROR_NOACCESS</para>
        /// <para>MessageText: Invalid access to memory location.</para>
        /// </summary>
        NoAccess = 998,

        /// <summary>
        /// <para>MessageId: ERROR_SWAPERROR</para>
        /// <para>MessageText: Error performing inpage operation.</para>
        /// </summary>
        SwapError = 999,

        /// <summary>
        /// <para>MessageId: ERROR_STACK_OVERFLOW</para>
        /// <para>MessageText: Recursion too deep; the stack overflowed.</para>
        /// </summary>
        StackOverflow = 1001,

        /// <summary>
        /// <para>MessageId: ERROR_INVALID_MESSAGE</para>
        /// <para>MessageText: The window cannot act on the sent message.</para>
        /// </summary>
        InvalidMessage = 1002,

        /// <summary>
        /// <para>MessageId: ERROR_CAN_NOT_COMPLETE</para>
        /// <para>MessageText: Cannot complete this function.</para>
        /// </summary>
        CanNotComplete = 1003,

        /// <summary>
        /// <para>MessageId: ERROR_INVALID_FLAGS</para>
        /// <para>MessageText: Invalid flags.</para>
        /// </summary>
        InvalidFlags = 1004,

        /// <summary>
        /// <para>MessageId: ERROR_UNRECOGNIZED_VOLUME</para>
        /// <para>MessageText: The volume does not contain a recognized file system.</para>
        /// </summary>
        UnrecognizedVolume = 1005,

        /// <summary>
        /// <para>MessageId: ERROR_FILE_INVALID</para>
        /// <para>MessageText: The volume for a file has been externally altered so that the opened file is no longer valid.</para>
        /// </summary>
        FileInvalid = 1006,

        /// <summary>
        /// <para>MessageId: ERROR_FULLSCREEN_MODE</para>
        /// <para>MessageText: The requested operation cannot be performed in full-screen mode.</para>
        /// </summary>
        FullScreenMode = 1007,

        /// <summary>
        /// <para>MessageId: ERROR_NO_TOKEN</para>
        /// <para>MessageText: An attempt was made to reference a token that does not exist.</para>
        /// </summary>
        NoToken = 1008,

        /// <summary>
        /// <para>MessageId: ERROR_BADDB</para>
        /// <para>MessageText: The configuration registry database is corrupt.</para>
        /// </summary>
        BadDB = 1009,

        /// <summary>
        /// <para>MessageId: ERROR_BADKEY</para>
        /// <para>MessageText: The configuration registry key is invalid.</para>
        /// </summary>
        BadKey = 1010,

        /// <summary>
        /// <para>MessageId: ERROR_CANTOPEN</para>
        /// <para>MessageText: The configuration registry key could not be opened.</para>
        /// </summary>
        CantOpen = 1011,

        /// <summary>
        /// <para>MessageId: ERROR_CANTREAD</para>
        /// <para>MessageText: The configuration registry key could not be read.</para>
        /// </summary>
        CantRead = 1012,

        /// <summary>
        /// <para>MessageId: ERROR_CANTWRITE</para>
        /// <para>MessageText: The configuration registry key could not be written.</para>
        /// </summary>
        CantWrite = 1013,

        /// <summary>
        /// <para>MessageId: ERROR_REGISTRY_RECOVERED</para>
        /// <para>MessageText: One of the files in the registry database had to be recovered by use of a log or alternate copy. The recovery was successful.</para>
        /// </summary>
        RegistryRecovered = 1014,

        /// <summary>
        /// <para>MessageId: ERROR_REGISTRY_CORRUPT</para>
        /// <para>MessageText: The registry is corrupted. The structure of one of the files containing registry data is corrupted, or the system's memory image of the file is corrupted, or the file could not be recovered because the alternate copy or log was absent or corrupted.</para>
        /// </summary>
        RegistryCorrupt = 1015,

        /// <summary>
        /// <para>MessageId: ERROR_REGISTRY_IO_FAILED</para>
        /// <para>MessageText: An I/O operation initiated by the registry failed unrecoverably. The registry could not read in, or write out, or flush, one of the files that contain the system's image of the registry.</para>
        /// </summary>
        RegistryIOFailed = 1016,

        /// <summary>
        /// <para>MessageId: ERROR_NOT_REGISTRY_FILE</para>
        /// <para>MessageText: The system has attempted to load or restore a file into the registry, but the specified file is not in a registry file format.</para>
        /// </summary>
        NotRegistryFile = 1017,

        /// <summary>
        /// <para>MessageId: ERROR_KEY_DELETED</para>
        /// <para>MessageText: Illegal operation attempted on a registry key that has been marked for deletion.</para>
        /// </summary>
        KeyDeleted = 1018,

        /// <summary>
        /// <para>MessageId: ERROR_NO_LOG_SPACE</para>
        /// <para>MessageText: System could not allocate the required space in a registry log.</para>
        /// </summary>
        NoLogSpace = 1019,

        /// <summary>
        /// <para>MessageId: ERROR_KEY_HAS_CHILDREN</para>
        /// <para>MessageText: Cannot create a symbolic link in a registry key that already has subkeys or values.</para>
        /// </summary>
        KeyHasChildren = 1020,

        /// <summary>
        /// <para>MessageId: ERROR_CHILD_MUST_BE_VOLATILE</para>
        /// <para>MessageText: Cannot create a stable subkey under a volatile parent key.</para>
        /// </summary>
        ChildMustBeVolatile = 1021,

        /// <summary>
        /// <para>MessageId: ERROR_NOTIFY_ENUM_DIR</para>
        /// <para>MessageText: A notify change request is being completed and the information is not being returned in the caller's buffer. The caller now needs to enumerate the files to find the changes.</para>
        /// </summary>
        NotifyEnumDir = 1022,

        /// <summary>
        /// <para>MessageId: ERROR_DEPENDENT_SERVICES_RUNNING</para>
        /// <para>MessageText: A stop control has been sent to a service that other running services are dependent on.</para>
        /// </summary>
        DependentServicesRunning = 1051,

        /// <summary>
        /// <para>MessageId: ERROR_INVALID_SERVICE_CONTROL</para>
        /// <para>MessageText: The requested control is not valid for this service.</para>
        /// </summary>
        InvalidServiceControl = 1052,

        /// <summary>
        /// <para>MessageId: ERROR_SERVICE_REQUEST_TIMEOUT</para>
        /// <para>MessageText: The service did not respond to the start or control request in a timely fashion.</para>
        /// </summary>
        ServiceRequestTimeout = 1053,

        /// <summary>
        /// <para>MessageId: ERROR_SERVICE_NO_THREAD</para>
        /// <para>MessageText: A thread could not be created for the service.</para>
        /// </summary>
        ServiceNoThread = 1054,

        /// <summary>
        /// <para>MessageId: ERROR_SERVICE_DATABASE_LOCKED</para>
        /// <para>MessageText: The service database is locked.</para>
        /// </summary>
        ServiceDatabaseLocked = 1055,

        /// <summary>
        /// <para>MessageId: ERROR_SERVICE_ALREADY_RUNNING</para>
        /// <para>MessageText: An instance of the service is already running.</para>
        /// </summary>
        ServiceAlreadyRunning = 1056,

        /// <summary>
        /// <para>MessageId: ERROR_INVALID_SERVICE_ACCOUNT</para>
        /// <para>MessageText: The account name is invalid or does not exist, or the password is invalid for the account name specified.</para>
        /// </summary>
        InvalidServiceAccount = 1057,

        /// <summary>
        /// <para>MessageId: ERROR_SERVICE_DISABLED</para>
        /// <para>MessageText: The service cannot be started, either because it is disabled or because it has no enabled devices associated with it.</para>
        /// </summary>
        ServiceDisabled = 1058,

        /// <summary>
        /// <para>MessageId: ERROR_CIRCULAR_DEPENDENCY</para>
        /// <para>MessageText: Circular service dependency was specified.</para>
        /// </summary>
        CircularDependency = 1059,

        /// <summary>
        /// <para>MessageId: ERROR_SERVICE_DOES_NOT_EXIST</para>
        /// <para>MessageText: The specified service does not exist as an installed service.</para>
        /// </summary>
        ServiceDoesNotExist = 1060,

        /// <summary>
        /// <para>MessageId: ERROR_SERVICE_CANNOT_ACCEPT_CTRL</para>
        /// <para>MessageText: The service cannot accept control messages at this time.</para>
        /// </summary>
        ServiceCannotAcceptCtrl = 1061,

        /// <summary>
        /// <para>MessageId: ERROR_SERVICE_NOT_ACTIVE</para>
        /// <para>MessageText: The service has not been started.</para>
        /// </summary>
        ServiceNotActive = 1062,

        /// <summary>
        /// <para>MessageId: ERROR_FAILED_SERVICE_CONTROLLER_CONNECT</para>
        /// <para>MessageText: The service process could not connect to the service controller.</para>
        /// </summary>
        FailedServiceControllerConnect = 1063,

        /// <summary>
        /// <para>MessageId: ERROR_EXCEPTION_IN_SERVICE</para>
        /// <para>MessageText: An exception occurred in the service when handling the control request.</para>
        /// </summary>
        ExceptionInService = 1064,

        /// <summary>
        /// <para>MessageId: ERROR_DATABASE_DOES_NOT_EXIST</para>
        /// <para>MessageText: The database specified does not exist.</para>
        /// </summary>
        DatabaseDoesNotExist = 1065,

        /// <summary>
        /// <para>MessageId: ERROR_SERVICE_SPECIFIC_ERROR</para>
        /// <para>MessageText: The service has returned a service-specific error code.</para>
        /// </summary>
        ServiceSpecificError = 1066,

        /// <summary>
        /// <para>MessageId: ERROR_PROCESS_ABORTED</para>
        /// <para>MessageText: The process terminated unexpectedly.</para>
        /// </summary>
        ProcessAborted = 1067,

        /// <summary>
        /// <para>MessageId: ERROR_SERVICE_DEPENDENCY_FAIL</para>
        /// <para>MessageText: The dependency service or group failed to start.</para>
        /// </summary>
        ServiceDependencyFail = 1068,

        /// <summary>
        /// <para>MessageId: ERROR_SERVICE_LOGON_FAILED</para>
        /// <para>MessageText: The service did not start due to a logon failure.</para>
        /// </summary>
        ServiceLogonFailed = 1069,

        /// <summary>
        /// <para>MessageId: ERROR_SERVICE_START_HANG</para>
        /// <para>MessageText: After starting, the service hung in a start-pending state.</para>
        /// </summary>
        ServiceStartHang = 1070,

        /// <summary>
        /// <para>MessageId: ERROR_INVALID_SERVICE_LOCK</para>
        /// <para>MessageText: The specified service database lock is invalid.</para>
        /// </summary>
        InvalidServiceLock = 1071,

        /// <summary>
        /// <para>MessageId: ERROR_SERVICE_MARKED_FOR_DELETE</para>
        /// <para>MessageText: The specified service has been marked for deletion.</para>
        /// </summary>
        ServiceMarkedForDelete = 1072,

        /// <summary>
        /// <para>MessageId: ERROR_SERVICE_EXISTS</para>
        /// <para>MessageText: The specified service already exists.</para>
        /// </summary>
        ServiceExists = 1073,

        /// <summary>
        /// <para>MessageId: ERROR_ALREADY_RUNNING_LKG</para>
        /// <para>MessageText: The system is currently running with the last-known-good configuration.</para>
        /// </summary>
        AlreadyRunningLKG = 1074,

        /// <summary>
        /// <para>MessageId: ERROR_SERVICE_DEPENDENCY_DELETED</para>
        /// <para>MessageText: The dependency service does not exist or has been marked for deletion.</para>
        /// </summary>
        ServiceDependencyDeleted = 1075,

        /// <summary>
        /// <para>MessageId: ERROR_BOOT_ALREADY_ACCEPTED</para>
        /// <para>MessageText: The current boot has already been accepted for use as the last-known-good control set.</para>
        /// </summary>
        BootAlreadyAccepted = 1076,

        /// <summary>
        /// <para>MessageId: ERROR_SERVICE_NEVER_STARTED</para>
        /// <para>MessageText: No attempts to start the service have been made since the last boot.</para>
        /// </summary>
        ServiceNeverStarted = 1077,

        /// <summary>
        /// <para>MessageId: ERROR_DUPLICATE_SERVICE_NAME</para>
        /// <para>MessageText: The name is already in use as either a service name or a service display name.</para>
        /// </summary>
        DuplicateServiceName = 1078,

        /// <summary>
        /// <para>MessageId: ERROR_DIFFERENT_SERVICE_ACCOUNT</para>
        /// <para>MessageText: The account specified for this service is different from the account specified for other services running in the same process.</para>
        /// </summary>
        DifferentServiceAccount = 1079,

        /// <summary>
        /// <para>MessageId: ERROR_CANNOT_DETECT_DRIVER_FAILURE</para>
        /// <para>MessageText: Failure actions can only be set for Win32 services, not for drivers.</para>
        /// </summary>
        CannotDetectDriverFailure = 1080,

        /// <summary>
        /// <para>MessageId: ERROR_CANNOT_DETECT_PROCESS_ABORT</para>
        /// <para>MessageText: This service runs in the same process as the service control manager.</para>
        /// </summary>
        CannotDetectProcessAbort = 1081,

        /// <summary>
        /// <para>MessageId: ERROR_NO_RECOVERY_PROGRAM</para>
        /// <para>MessageText: No recovery program has been configured for this service.</para>
        /// </summary>
        NoRecoveryProgram = 1082,

        /// <summary>
        /// <para>MessageId: ERROR_SERVICE_NOT_IN_EXE</para>
        /// <para>MessageText: The executable program that this service is configured to run in does not implement the service.</para>
        /// </summary>
        ServiceNotInExe = 1083,

        /// <summary>
        /// <para>MessageId: ERROR_NOT_SAFEBOOT_SERVICE</para>
        /// <para>MessageText: This service cannot be started in Safe Mode</para>
        /// </summary>
        NotSafebootService = 1084,

        /// <summary>
        /// <para>MessageId: ERROR_END_OF_MEDIA</para>
        /// <para>MessageText: The physical end of the tape has been reached.</para>
        /// </summary>
        EndOfMedia = 1100,

        /// <summary>
        /// <para>MessageId: ERROR_FILEMARK_DETECTED</para>
        /// <para>MessageText: A tape access reached a filemark.</para>
        /// </summary>
        FilemarkDetected = 1101,

        /// <summary>
        /// <para>MessageId: ERROR_BEGINNING_OF_MEDIA</para>
        /// <para>MessageText: The beginning of the tape or a partition was encountered.</para>
        /// </summary>
        BeginningOfMedia = 1102,

        /// <summary>
        /// <para>MessageId: ERROR_SETMARK_DETECTED</para>
        /// <para>MessageText: A tape access reached the end of a set of files.</para>
        /// </summary>
        SetmarkDetected = 1103,

        /// <summary>
        /// <para>MessageId: ERROR_NO_DATA_DETECTED</para>
        /// <para>MessageText: No more data is on the tape.</para>
        /// </summary>
        NoDataDetected = 1104,

        /// <summary>
        /// <para>MessageId: ERROR_PARTITION_FAILURE</para>
        /// <para>MessageText: Tape could not be partitioned.</para>
        /// </summary>
        PartitionFailure = 1105,

        /// <summary>
        /// <para>MessageId: ERROR_INVALID_BLOCK_LENGTH</para>
        /// <para>MessageText: When accessing a new tape of a multivolume partition, the current block size is incorrect.</para>
        /// </summary>
        InvalidBlockLength = 1106,

        /// <summary>
        /// <para>MessageId: ERROR_DEVICE_NOT_PARTITIONED</para>
        /// <para>MessageText: Tape partition information could not be found when loading a tape.</para>
        /// </summary>
        DeviceNotPartitioned = 1107,

        /// <summary>
        /// <para>MessageId: ERROR_UNABLE_TO_LOCK_MEDIA</para>
        /// <para>MessageText: Unable to lock the media eject mechanism.</para>
        /// </summary>
        UnableToLockMedia = 1108,

        /// <summary>
        /// <para>MessageId: ERROR_UNABLE_TO_UNLOAD_MEDIA</para>
        /// <para>MessageText: Unable to unload the media.</para>
        /// </summary>
        UnableToUnloadMedia = 1109,

        /// <summary>
        /// <para>MessageId: ERROR_MEDIA_CHANGED</para>
        /// <para>MessageText: The media in the drive may have changed.</para>
        /// </summary>
        MediaChanged = 1110,

        /// <summary>
        /// <para>MessageId: ERROR_BUS_RESET</para>
        /// <para>MessageText: The I/O bus was reset.</para>
        /// </summary>
        BusReset = 1111,

        /// <summary>
        /// <para>MessageId: ERROR_NO_MEDIA_IN_DRIVE</para>
        /// <para>MessageText: No media in drive.</para>
        /// </summary>
        NoMediaInDrive = 1112,

        /// <summary>
        /// <para>MessageId: ERROR_NO_UNICODE_TRANSLATION</para>
        /// <para>MessageText: No mapping for the Unicode character exists in the target multi-byte code page.</para>
        /// </summary>
        NoUnicodeTranslation = 1113,

        /// <summary>
        /// <para>MessageId: ERROR_DLL_INIT_FAILED</para>
        /// <para>MessageText: A dynamic link library (DLL) initialization routine failed.</para>
        /// </summary>
        DllInitFailed = 1114,

        /// <summary>
        /// <para>MessageId: ERROR_SHUTDOWN_IN_PROGRESS</para>
        /// <para>MessageText: A system shutdown is in progress.</para>
        /// </summary>
        ShutdownInProgress = 1115,

        /// <summary>
        /// <para>MessageId: ERROR_NO_SHUTDOWN_IN_PROGRESS</para>
        /// <para>MessageText: Unable to abort the system shutdown because no shutdown was in progress.</para>
        /// </summary>
        NoShutdownInProgress = 1116,

        /// <summary>
        /// <para>MessageId: ERROR_IO_DEVICE</para>
        /// <para>MessageText: The request could not be performed because of an I/O device error.</para>
        /// </summary>
        IODevice = 1117,

        /// <summary>
        /// <para>MessageId: ERROR_SERIAL_NO_DEVICE</para>
        /// <para>MessageText: No serial device was successfully initialized. The serial driver will unload.</para>
        /// </summary>
        SerialNoDevice = 1118,

        /// <summary>
        /// <para>MessageId: ERROR_IRQ_BUSY</para>
        /// <para>MessageText: Unable to open a device that was sharing an interrupt request (IRQ) with other devices. At least one other device that uses that IRQ was already opened.</para>
        /// </summary>
        IRQBusy = 1119,

        /// <summary>
        /// <para>MessageId: ERROR_MORE_WRITES</para>
        /// <para>MessageText: A serial I/O operation was completed by another write to the serial port.</para>
        /// </summary>
        MoreWrites = 1120,

        /// <summary>
        /// <para>MessageId: ERROR_COUNTER_TIMEOUT</para>
        /// <para>MessageText: A serial I/O operation completed because the timeout period expired.</para>
        /// </summary>
        CounterTimeout = 1121,

        /// <summary>
        /// <para>MessageId: ERROR_FLOPPY_ID_MARK_NOT_FOUND</para>
        /// <para>MessageText: No ID address mark was found on the floppy disk.</para>
        /// </summary>
        FloppyIdMarkNotFound = 1122,

        /// <summary>
        /// <para>MessageId: ERROR_FLOPPY_WRONG_CYLINDER</para>
        /// <para>MessageText: Mismatch between the floppy disk sector ID field and the floppy disk controller track address.</para>
        /// </summary>
        FloppyWrongCylinder = 1123,

        /// <summary>
        /// <para>MessageId: ERROR_FLOPPY_UNKNOWN_ERROR</para>
        /// <para>MessageText: The floppy disk controller reported an error that is not recognized by the floppy disk driver.</para>
        /// </summary>
        FloppyUnknownError = 1124,

        /// <summary>
        /// <para>MessageId: ERROR_FLOPPY_BAD_REGISTERS</para>
        /// <para>MessageText: The floppy disk controller returned inconsistent results in its registers.</para>
        /// </summary>
        FloppyBadRegisters = 1125,

        /// <summary>
        /// <para>MessageId: ERROR_DISK_RECALIBRATE_FAILED</para>
        /// <para>MessageText: While accessing the hard disk, a recalibrate operation failed, even after retries.</para>
        /// </summary>
        DiskRecalibrateFailed = 1126,

        /// <summary>
        /// <para>MessageId: ERROR_DISK_OPERATION_FAILED</para>
        /// <para>MessageText: While accessing the hard disk, a disk operation failed even after retries.</para>
        /// </summary>
        DiskOperationFailed = 1127,

        /// <summary>
        /// <para>MessageId: ERROR_DISK_RESET_FAILED</para>
        /// <para>MessageText: While accessing the hard disk, a disk controller reset was needed, but even that failed.</para>
        /// </summary>
        DiskResetFailed = 1128,

        /// <summary>
        /// <para>MessageId: ERROR_EOM_OVERFLOW</para>
        /// <para>MessageText: Physical end of tape encountered.</para>
        /// </summary>
        EOMOverflow = 1129,

        /// <summary>
        /// <para>MessageId: ERROR_NOT_ENOUGH_SERVER_MEMORY</para>
        /// <para>MessageText: Not enough server memory resources are available to process this command.</para>
        /// </summary>
        NotEnoughServerMemory = 1130,

        /// <summary>
        /// <para>MessageId: ERROR_POSSIBLE_DEADLOCK</para>
        /// <para>MessageText: A potential deadlock condition has been detected.</para>
        /// </summary>
        PossibleDeadlock = 1131,

        /// <summary>
        /// <para>MessageId: ERROR_MAPPED_ALIGNMENT</para>
        /// <para>MessageText: The base address or the file offset specified does not have the proper alignment.</para>
        /// </summary>
        MappedAlignment = 1132,

        /// <summary>
        /// <para>MessageId: ERROR_SET_POWER_STATE_VETOED</para>
        /// <para>MessageText: An attempt to change the system power state was vetoed by another application or driver.</para>
        /// </summary>
        SetPowerStateVetoed = 1140,

        /// <summary>
        /// <para>MessageId: ERROR_SET_POWER_STATE_FAILED</para>
        /// <para>MessageText: The system BIOS failed an attempt to change the system power state.</para>
        /// </summary>
        SetPowerStateFailed = 1141,

        /// <summary>
        /// <para>MessageId: ERROR_TOO_MANY_LINKS</para>
        /// <para>MessageText: An attempt was made to create more links on a file than the file system supports.</para>
        /// </summary>
        TooManyLinks = 1142,

        /// <summary>
        /// <para>MessageId: ERROR_OLD_WIN_VERSION</para>
        /// <para>MessageText: The specified program requires a newer version of Windows.</para>
        /// </summary>
        OldWinVersion = 1150,

        /// <summary>
        /// <para>MessageId: ERROR_APP_WRONG_OS</para>
        /// <para>MessageText: The specified program is not a Windows or MS-DOS program.</para>
        /// </summary>
        AppWrongOS = 1151,

        /// <summary>
        /// <para>MessageId: ERROR_SINGLE_INSTANCE_APP</para>
        /// <para>MessageText: Cannot start more than one instance of the specified program.</para>
        /// </summary>
        SingleInstanceApp = 1152,

        /// <summary>
        /// <para>MessageId: ERROR_RMODE_APP</para>
        /// <para>MessageText: The specified program was written for an earlier version of Windows.</para>
        /// </summary>
        RModeApp = 1153,

        /// <summary>
        /// <para>MessageId: ERROR_INVALID_DLL</para>
        /// <para>MessageText: One of the library files needed to run this application is damaged.</para>
        /// </summary>
        InvalidDll = 1154,

        /// <summary>
        /// <para>MessageId: ERROR_NO_ASSOCIATION</para>
        /// <para>MessageText: No application is associated with the specified file for this operation.</para>
        /// </summary>
        NoAssociation = 1155,

        /// <summary>
        /// <para>MessageId: ERROR_DDE_FAIL</para>
        /// <para>MessageText: An error occurred in sending the command to the application.</para>
        /// </summary>
        DDEFail = 1156,

        /// <summary>
        /// <para>MessageId: ERROR_DLL_NOT_FOUND</para>
        /// <para>MessageText: One of the library files needed to run this application cannot be found.</para>
        /// </summary>
        DllNotFound = 1157,

        /// <summary>
        /// <para>MessageId: ERROR_NO_MORE_USER_HANDLES</para>
        /// <para>MessageText: The current process has used all of its system allowance of handles for Window Manager objects.</para>
        /// </summary>
        NoMoreUserHandles = 1158,

        /// <summary>
        /// <para>MessageId: ERROR_MESSAGE_SYNC_ONLY</para>
        /// <para>MessageText: The message can be used only with synchronous operations.</para>
        /// </summary>
        MessageSyncOnly = 1159,

        /// <summary>
        /// <para>MessageId: ERROR_SOURCE_ELEMENT_EMPTY</para>
        /// <para>MessageText: The indicated source element has no media.</para>
        /// </summary>
        SourceElementEmpty = 1160,

        /// <summary>
        /// <para>MessageId: ERROR_DESTINATION_ELEMENT_FULL</para>
        /// <para>MessageText: The indicated destination element already contains media.</para>
        /// </summary>
        DestinationElementFull = 1161,

        /// <summary>
        /// <para>MessageId: ERROR_ILLEGAL_ELEMENT_ADDRESS</para>
        /// <para>MessageText: The indicated element does not exist.</para>
        /// </summary>
        IllegalElementAddress = 1162,

        /// <summary>
        /// <para>MessageId: ERROR_MAGAZINE_NOT_PRESENT</para>
        /// <para>MessageText: The indicated element is part of a magazine that is not present.</para>
        /// </summary>
        MagazineNotPresent = 1163,

        /// <summary>
        /// <para>MessageId: ERROR_DEVICE_REINITIALIZATION_NEEDED</para>
        /// <para>MessageText: The indicated device requires reinitialization due to hardware errors.</para>
        /// </summary>
        DeviceReinitializationNeeded = 1164,    // dderror

        /// <summary>
        /// <para>MessageId: ERROR_DEVICE_REQUIRES_CLEANING</para>
        /// <para>MessageText: The device has indicated that cleaning is required before further operations are attempted.</para>
        /// </summary>
        DeviceRequiresCleaning = 1165,

        /// <summary>
        /// <para>MessageId: ERROR_DEVICE_DOOR_OPEN</para>
        /// <para>MessageText: The device has indicated that its door is open.</para>
        /// </summary>
        DeviceDoorOpen = 1166,

        /// <summary>
        /// <para>MessageId: ERROR_DEVICE_NOT_CONNECTED</para>
        /// <para>MessageText: The device is not connected.</para>
        /// </summary>
        DeviceNotConnected = 1167,

        /// <summary>
        /// <para>MessageId: ERROR_NOT_FOUND</para>
        /// <para>MessageText: Element not found.</para>
        /// </summary>
        NotFound = 1168,

        /// <summary>
        /// <para>MessageId: ERROR_NO_MATCH</para>
        /// <para>MessageText: There was no match for the specified key in the index.</para>
        /// </summary>
        NoMatch = 1169,

        /// <summary>
        /// <para>MessageId: ERROR_SET_NOT_FOUND</para>
        /// <para>MessageText: The property set specified does not exist on the object.</para>
        /// </summary>
        SetNotFound = 1170,

        /// <summary>
        /// <para>MessageId: ERROR_POINT_NOT_FOUND</para>
        /// <para>MessageText: The point passed to GetMouseMovePoints is not in the buffer.</para>
        /// </summary>
        PointNotFound = 1171,

        /// <summary>
        /// <para>MessageId: ERROR_NO_TRACKING_SERVICE</para>
        /// <para>MessageText: The tracking (workstation) service is not running.</para>
        /// </summary>
        NoTrackingService = 1172,

        /// <summary>
        /// <para>MessageId: ERROR_NO_VOLUME_ID</para>
        /// <para>MessageText: The Volume ID could not be found.</para>
        /// </summary>
        NoVolumeId = 1173,

        /// <summary>
        /// <para>MessageId: ERROR_UNABLE_TO_REMOVE_REPLACED</para>
        /// <para>MessageText: Unable to remove the file to be replaced.</para>
        /// </summary>
        UnableToRemoveReplaced = 1175,

        /// <summary>
        /// <para>MessageId: ERROR_UNABLE_TO_MOVE_REPLACEMENT</para>
        /// <para>MessageText: Unable to move the replacement file to the file to be replaced. The file to be replaced has retained its original name.</para>
        /// </summary>
        UnableToMoveReplacement = 1176,

        /// <summary>
        /// <para>MessageId: ERROR_UNABLE_TO_MOVE_REPLACEMENT_2</para>
        /// <para>MessageText: Unable to move the replacement file to the file to be replaced. The file to be replaced has been renamed using the backup name.</para>
        /// </summary>
        UnableToMoveReplacement2 = 1177,

        /// <summary>
        /// <para>MessageId: ERROR_JOURNAL_DELETE_IN_PROGRESS</para>
        /// <para>MessageText: The volume change journal is being deleted.</para>
        /// </summary>
        JournalDeleteInProgress = 1178,

        /// <summary>
        /// <para>MessageId: ERROR_JOURNAL_NOT_ACTIVE</para>
        /// <para>MessageText: The volume change journal is not active.</para>
        /// </summary>
        JournalNotActive = 1179,

        /// <summary>
        /// <para>MessageId: ERROR_POTENTIAL_FILE_FOUND</para>
        /// <para>MessageText: A file was found, but it may not be the correct file.</para>
        /// </summary>
        PotentialFileFound = 1180,

        /// <summary>
        /// <para>MessageId: ERROR_JOURNAL_ENTRY_DELETED</para>
        /// <para>MessageText: The journal entry has been deleted from the journal.</para>
        /// </summary>
        JournalEntryDeleted = 1181,

        /// <summary>
        /// <para>MessageId: ERROR_SHUTDOWN_IS_SCHEDULED</para>
        /// <para>MessageText: A system shutdown has already been scheduled.</para>
        /// </summary>
        ShutdownIsScheduled = 1190,

        /// <summary>
        /// <para>MessageId: ERROR_SHUTDOWN_USERS_LOGGED_ON</para>
        /// <para>MessageText: The system shutdown cannot be initiated because there are other users logged on to the computer.</para>
        /// </summary>
        ShutdownUsersLoggedOn = 1191,

        /// <summary>
        /// <para>MessageId: ERROR_BAD_DEVICE</para>
        /// <para>MessageText: The specified device name is invalid.</para>
        /// </summary>
        BadDevice = 1200,

        /// <summary>
        /// <para>MessageId: ERROR_CONNECTION_UNAVAIL</para>
        /// <para>MessageText: The device is not currently connected but it is a remembered connection.</para>
        /// </summary>
        ConnectionUnavail = 1201,

        /// <summary>
        /// <para>MessageId: ERROR_DEVICE_ALREADY_REMEMBERED</para>
        /// <para>MessageText: The local device name has a remembered connection to another network resource.</para>
        /// </summary>
        DeviceAlreadyRemembered = 1202,

        /// <summary>
        /// <para>MessageId: ERROR_NO_NET_OR_BAD_PATH</para>
        /// <para>MessageText: The network path was either typed incorrectly, does not exist, or the network provider is not currently available. Please try retyping the path or contact your network administrator.</para>
        /// </summary>
        NoNetOrBadPath = 1203,

        /// <summary>
        /// <para>MessageId: ERROR_BAD_PROVIDER</para>
        /// <para>MessageText: The specified network provider name is invalid.</para>
        /// </summary>
        BadProvider = 1204,

        /// <summary>
        /// <para>MessageId: ERROR_CANNOT_OPEN_PROFILE</para>
        /// <para>MessageText: Unable to open the network connection profile.</para>
        /// </summary>
        CannotOpenProfile = 1205,

        /// <summary>
        /// <para>MessageId: ERROR_BAD_PROFILE</para>
        /// <para>MessageText: The network connection profile is corrupted.</para>
        /// </summary>
        BadProfile = 1206,

        /// <summary>
        /// <para>MessageId: ERROR_NOT_CONTAINER</para>
        /// <para>MessageText: Cannot enumerate a noncontainer.</para>
        /// </summary>
        NotContainer = 1207,

        /// <summary>
        /// <para>MessageId: ERROR_EXTENDED_ERROR</para>
        /// <para>MessageText: An extended error has occurred.</para>
        /// </summary>
        ExtendedError = 1208,

        /// <summary>
        /// <para>MessageId: ERROR_INVALID_GROUPNAME</para>
        /// <para>MessageText: The format of the specified group name is invalid.</para>
        /// </summary>
        InvalidGroupName = 1209,

        /// <summary>
        /// <para>MessageId: ERROR_INVALID_COMPUTERNAME</para>
        /// <para>MessageText: The format of the specified computer name is invalid.</para>
        /// </summary>
        InvalidComputerName = 1210,

        /// <summary>
        /// <para>MessageId: ERROR_INVALID_EVENTNAME</para>
        /// <para>MessageText: The format of the specified event name is invalid.</para>
        /// </summary>
        InvalidEventName = 1211,

        /// <summary>
        /// <para>MessageId: ERROR_INVALID_DOMAINNAME</para>
        /// <para>MessageText: The format of the specified domain name is invalid.</para>
        /// </summary>
        InvalidDomainName = 1212,

        /// <summary>
        /// <para>MessageId: ERROR_INVALID_SERVICENAME</para>
        /// <para>MessageText: The format of the specified service name is invalid.</para>
        /// </summary>
        InvalidServiceName = 1213,

        /// <summary>
        /// <para>MessageId: ERROR_INVALID_NETNAME</para>
        /// <para>MessageText: The format of the specified network name is invalid.</para>
        /// </summary>
        InvalidNetName = 1214,

        /// <summary>
        /// <para>MessageId: ERROR_INVALID_SHARENAME</para>
        /// <para>MessageText: The format of the specified share name is invalid.</para>
        /// </summary>
        InvalidShareName = 1215,

        /// <summary>
        /// <para>MessageId: ERROR_INVALID_PASSWORDNAME</para>
        /// <para>MessageText: The format of the specified password is invalid.</para>
        /// </summary>
        InvalidPasswordName = 1216,

        /// <summary>
        /// <para>MessageId: ERROR_INVALID_MESSAGENAME</para>
        /// <para>MessageText: The format of the specified message name is invalid.</para>
        /// </summary>
        InvalidMessageName = 1217,

        /// <summary>
        /// <para>MessageId: ERROR_INVALID_MESSAGEDEST</para>
        /// <para>MessageText: The format of the specified message destination is invalid.</para>
        /// </summary>
        InvalidMessageDest = 1218,

        /// <summary>
        /// <para>MessageId: ERROR_SESSION_CREDENTIAL_CONFLICT</para>
        /// <para>MessageText: Multiple connections to a server or .Shared resource by the same user, using more than one user name, are not allowed. Disconnect all previous connections to the server or .Shared resource and try again.</para>
        /// </summary>
        SessionCredentialConflict = 1219,

        /// <summary>
        /// <para>MessageId: ERROR_REMOTE_SESSION_LIMIT_EXCEEDED</para>
        /// <para>MessageText: An attempt was made to establish a session to a network server, but there are already too many sessions established to that server.</para>
        /// </summary>
        RemoteSessionLimitExceeded = 1220,

        /// <summary>
        /// <para>MessageId: ERROR_DUP_DOMAINNAME</para>
        /// <para>MessageText: The workgroup or domain name is already in use by another computer on the network.</para>
        /// </summary>
        DupDomainName = 1221,

        /// <summary>
        /// <para>MessageId: ERROR_NO_NETWORK</para>
        /// <para>MessageText: The network is not present or not started.</para>
        /// </summary>
        NoNetwork = 1222,

        /// <summary>
        /// <para>MessageId: ERROR_CANCELLED</para>
        /// <para>MessageText: The operation was canceled by the user.</para>
        /// </summary>
        Cancelled = 1223,

        /// <summary>
        /// <para>MessageId: ERROR_USER_MAPPED_FILE</para>
        /// <para>MessageText: The requested operation cannot be performed on a file with a user-mapped section open.</para>
        /// </summary>
        UserMappedFile = 1224,

        /// <summary>
        /// <para>MessageId: ERROR_CONNECTION_REFUSED</para>
        /// <para>MessageText: The remote computer refused the network connection.</para>
        /// </summary>
        ConnectionRefused = 1225,

        /// <summary>
        /// <para>MessageId: ERROR_GRACEFUL_DISCONNECT</para>
        /// <para>MessageText: The network connection was gracefully closed.</para>
        /// </summary>
        GracefulDisconnect = 1226,

        /// <summary>
        /// <para>MessageId: ERROR_ADDRESS_ALREADY_ASSOCIATED</para>
        /// <para>MessageText: The network transport endpoint already has an address associated with it.</para>
        /// </summary>
        AddressAlreadyAssociated = 1227,

        /// <summary>
        /// <para>MessageId: ERROR_ADDRESS_NOT_ASSOCIATED</para>
        /// <para>MessageText: An address has not yet been associated with the network endpoint.</para>
        /// </summary>
        AddressNotAssociated = 1228,

        /// <summary>
        /// <para>MessageId: ERROR_CONNECTION_INVALID</para>
        /// <para>MessageText: An operation was attempted on a nonexistent network connection.</para>
        /// </summary>
        ConnectionInvalid = 1229,

        /// <summary>
        /// <para>MessageId: ERROR_CONNECTION_ACTIVE</para>
        /// <para>MessageText: An invalid operation was attempted on an active network connection.</para>
        /// </summary>
        ConnectionActive = 1230,

        /// <summary>
        /// <para>MessageId: ERROR_NETWORK_UNREACHABLE</para>
        /// <para>MessageText: The network location cannot be reached. For information about network troubleshooting, see Windows Help.</para>
        /// </summary>
        NetworkUnreachable = 1231,

        /// <summary>
        /// <para>MessageId: ERROR_HOST_UNREACHABLE</para>
        /// <para>MessageText: The network location cannot be reached. For information about network troubleshooting, see Windows Help.</para>
        /// </summary>
        HostUnreachable = 1232,

        /// <summary>
        /// <para>MessageId: ERROR_PROTOCOL_UNREACHABLE</para>
        /// <para>MessageText: The network location cannot be reached. For information about network troubleshooting, see Windows Help.</para>
        /// </summary>
        ProtocolUnreachable = 1233,

        /// <summary>
        /// <para>MessageId: ERROR_PORT_UNREACHABLE</para>
        /// <para>MessageText: No service is operating at the destination network endpoint on the remote system.</para>
        /// </summary>
        PortUnreachable = 1234,

        /// <summary>
        /// <para>MessageId: ERROR_REQUEST_ABORTED</para>
        /// <para>MessageText: The request was aborted.</para>
        /// </summary>
        RequestAborted = 1235,

        /// <summary>
        /// <para>MessageId: ERROR_CONNECTION_ABORTED</para>
        /// <para>MessageText: The network connection was aborted by the local system.</para>
        /// </summary>
        ConnectionAborted = 1236,

        /// <summary>
        /// <para>MessageId: ERROR_RETRY</para>
        /// <para>MessageText: The operation could not be completed. A retry should be performed.</para>
        /// </summary>
        Retry = 1237,

        /// <summary>
        /// <para>MessageId: ERROR_CONNECTION_COUNT_LIMIT</para>
        /// <para>MessageText: A connection to the server could not be made because the limit on the number of concurrent connections for this account has been reached.</para>
        /// </summary>
        ConnectionCountLimit = 1238,

        /// <summary>
        /// <para>MessageId: ERROR_LOGIN_TIME_RESTRICTION</para>
        /// <para>MessageText: Attempting to log in during an unauthorized time of day for this account.</para>
        /// </summary>
        LoginTimeRestriction = 1239,

        /// <summary>
        /// <para>MessageId: ERROR_LOGIN_WKSTA_RESTRICTION</para>
        /// <para>MessageText: The account is not authorized to log in from this station.</para>
        /// </summary>
        LoginWkstaRestriction = 1240,

        /// <summary>
        /// <para>MessageId: ERROR_INCORRECT_ADDRESS</para>
        /// <para>MessageText: The network address could not be used for the operation requested.</para>
        /// </summary>
        IncorrectAddress = 1241,

        /// <summary>
        /// <para>MessageId: ERROR_ALREADY_REGISTERED</para>
        /// <para>MessageText: The service is already registered.</para>
        /// </summary>
        AlreadyRegistered = 1242,

        /// <summary>
        /// <para>MessageId: ERROR_SERVICE_NOT_FOUND</para>
        /// <para>MessageText: The specified service does not exist.</para>
        /// </summary>
        ServiceNotFound = 1243,

        /// <summary>
        /// <para>MessageId: ERROR_NOT_AUTHENTICATED</para>
        /// <para>MessageText: The operation being requested was not performed because the user has not been authenticated.</para>
        /// </summary>
        NotAuthenticated = 1244,

        /// <summary>
        /// <para>MessageId: ERROR_NOT_LOGGED_ON</para>
        /// <para>MessageText: The operation being requested was not performed because the user has not logged on to the network. The specified service does not exist.</para>
        /// </summary>
        NotLoggedOn = 1245,

        /// <summary>
        /// <para>MessageId: ERROR_CONTINUE</para>
        /// <para>MessageText: Continue with work in progress.</para>
        /// </summary>
        Continue = 1246,    // dderror

        /// <summary>
        /// <para>MessageId: ERROR_ALREADY_INITIALIZED</para>
        /// <para>MessageText: An attempt was made to perform an initialization operation when initialization has already been completed.</para>
        /// </summary>
        AlreadyInitialized = 1247,

        /// <summary>
        /// <para>MessageId: ERROR_NO_MORE_DEVICES</para>
        /// <para>MessageText: No more local devices.</para>
        /// </summary>
        NoMoreDevices = 1248,    // dderror

        /// <summary>
        /// <para>MessageId: ERROR_NO_SUCH_SITE</para>
        /// <para>MessageText: The specified site does not exist.</para>
        /// </summary>
        NoSuchSite = 1249,

        /// <summary>
        /// <para>MessageId: ERROR_DOMAIN_CONTROLLER_EXISTS</para>
        /// <para>MessageText: A domain controller with the specified name already exists.</para>
        /// </summary>
        DomainControllerExists = 1250,

        /// <summary>
        /// <para>MessageId: ERROR_ONLY_IF_CONNECTED</para>
        /// <para>MessageText: This operation is supported only when you are connected to the server.</para>
        /// </summary>
        OnlyIfConnected = 1251,

        /// <summary>
        /// <para>MessageId: ERROR_OVERRIDE_NOCHANGES</para>
        /// <para>MessageText: The group policy framework should call the extension even if there are no changes.</para>
        /// </summary>
        OverrideNoChanges = 1252,

        /// <summary>
        /// <para>MessageId: ERROR_BAD_USER_PROFILE</para>
        /// <para>MessageText: The specified user does not have a valid profile.</para>
        /// </summary>
        BadUserProfile = 1253,

        /// <summary>
        /// <para>MessageId: ERROR_NOT_SUPPORTED_ON_SBS</para>
        /// <para>MessageText: This operation is not supported on a computer running Windows Server= 2003 for Small Business Server</para>
        /// </summary>
        NotSupportedOnSbs = 1254,

        /// <summary>
        /// <para>MessageId: ERROR_SERVER_SHUTDOWN_IN_PROGRESS</para>
        /// <para>MessageText: The server machine is shutting down.</para>
        /// </summary>
        ServerShutdownInProgress = 1255,

        /// <summary>
        /// <para>MessageId: ERROR_HOST_DOWN</para>
        /// <para>MessageText: The remote system is not available. For information about network troubleshooting, see Windows Help.</para>
        /// </summary>
        HostDown = 1256,

        /// <summary>
        /// <para>MessageId: ERROR_NON_ACCOUNT_SID</para>
        /// <para>MessageText: The security identifier provided is not from an account domain.</para>
        /// </summary>
        NonAccountSid = 1257,

        /// <summary>
        /// <para>MessageId: ERROR_NON_DOMAIN_SID</para>
        /// <para>MessageText: The security identifier provided does not have a domain component.</para>
        /// </summary>
        NonDomainSID = 1258,

        /// <summary>
        /// <para>MessageId: ERROR_APPHELP_BLOCK</para>
        /// <para>MessageText: AppHelp dialog canceled thus preventing the application from starting.</para>
        /// </summary>
        AppHelpBlock = 1259,

        /// <summary>
        /// <para>MessageId: ERROR_ACCESS_DISABLED_BY_POLICY</para>
        /// <para>MessageText: This program is blocked by group policy. For more information, contact your system administrator.</para>
        /// </summary>
        AccessDisabledByPolicy = 1260,

        /// <summary>
        /// <para>MessageId: ERROR_REG_NAT_CONSUMPTION</para>
        /// <para>MessageText: A program attempt to use an invalid register value. Normally caused by an uninitialized register. This error is Itanium specific.</para>
        /// </summary>
        RegNatConsumption = 1261,

        /// <summary>
        /// <para>MessageId: ERROR_CSCSHARE_OFFLINE</para>
        /// <para>MessageText: The share is currently offline or does not exist.</para>
        /// </summary>
        CSCShareOffline = 1262,

        /// <summary>
        /// <para>MessageId: ERROR_PKINIT_FAILURE</para>
        /// <para>MessageText: The Kerberos protocol encountered an error while validating the KDC certificate during smartcard logon. There is more information in the system event log.</para>
        /// </summary>
        PKInitFailure = 1263,

        /// <summary>
        /// <para>MessageId: ERROR_SMARTCARD_SUBSYSTEM_FAILURE</para>
        /// <para>MessageText: The Kerberos protocol encountered an error while attempting to utilize the smartcard subsystem.</para>
        /// </summary>
        SmartCardSubsystemFailure = 1264,

        /// <summary>
        /// <para>MessageId: ERROR_DOWNGRADE_DETECTED</para>
        /// <para>MessageText: The system cannot contact a domain controller to service the authentication request. Please try again later.</para>
        /// </summary>
        DowngradeDetected = 1265,

        /// <summary>
        /// <para>MessageId: ERROR_MACHINE_LOCKED</para>
        /// <para>MessageText: The machine is locked and cannot be shut down without the force option.</para>
        /// </summary>
        MachineLocked = 1271,

        /// <summary>
        /// <para>MessageId: ERROR_SMB_GUEST_LOGON_BLOCKED</para>
        /// <para>MessageText: You can't access this shared folder because your organization's security policies block unauthenticated guest access. These policies help protect your PC from unsafe or malicious devices on the network.</para>
        /// </summary>
        SMBGuestLogonBlocked = 1272,

        /// <summary>
        /// <para>MessageId: ERROR_CALLBACK_SUPPLIED_INVALID_DATA</para>
        /// <para>MessageText: An application-defined callback gave invalid data when called.</para>
        /// </summary>
        CallbackSuppliedInvalidData = 1273,

        /// <summary>
        /// <para>MessageId: ERROR_SYNC_FOREGROUND_REFRESH_REQUIRED</para>
        /// <para>MessageText: The group policy framework should call the extension in the synchronous foreground policy refresh.</para>
        /// </summary>
        SyncForegroundRefreshRequired = 1274,

        /// <summary>
        /// <para>MessageId: ERROR_DRIVER_BLOCKED</para>
        /// <para>MessageText: This driver has been blocked from loading</para>
        /// </summary>
        DriverBlocked = 1275,

        /// <summary>
        /// <para>MessageId: ERROR_INVALID_IMPORT_OF_NON_DLL</para>
        /// <para>MessageText: A dynamic link library (DLL) referenced a module that was neither a DLL nor the process's executable image.</para>
        /// </summary>
        InvalidImportOfNonDll = 1276,

        /// <summary>
        /// <para>MessageId: ERROR_ACCESS_DISABLED_WEBBLADE</para>
        /// <para>MessageText: Windows cannot open this program since it has been disabled.</para>
        /// </summary>
        AccessDisabledWebblade = 1277,

        /// <summary>
        /// <para>MessageId: ERROR_ACCESS_DISABLED_WEBBLADE_TAMPER</para>
        /// <para>MessageText: Windows cannot open this program because the license enforcement system has been tampered with or become corrupted.</para>
        /// </summary>
        AccessDisabledWebbladeTamper = 1278,

        /// <summary>
        /// <para>MessageId: ERROR_RECOVERY_FAILURE</para>
        /// <para>MessageText: A transaction recover failed.</para>
        /// </summary>
        RecoveryFailure = 1279,

        /// <summary>
        /// <para>MessageId: ERROR_ALREADY_FIBER</para>
        /// <para>MessageText: The current thread has already been converted to a fiber.</para>
        /// </summary>
        AlreadyFiber = 1280,

        /// <summary>
        /// <para>MessageId: ERROR_ALREADY_THREAD</para>
        /// <para>MessageText: The current thread has already been converted from a fiber.</para>
        /// </summary>
        AlreadyThread = 1281,

        /// <summary>
        /// <para>MessageId: ERROR_STACK_BUFFER_OVERRUN</para>
        /// <para>MessageText: The system detected an overrun of a stack-based buffer in this application. This overrun could potentially allow a malicious user to gain control of this application.</para>
        /// </summary>
        StackBufferOverrun = 1282,

        /// <summary>
        /// <para>MessageId: ERROR_PARAMETER_QUOTA_EXCEEDED</para>
        /// <para>MessageText: Data present in one of the parameters is more than the function can operate on.</para>
        /// </summary>
        ParameterQuotaExceeded = 1283,

        /// <summary>
        /// <para>MessageId: ERROR_DEBUGGER_INACTIVE</para>
        /// <para>MessageText: An attempt to do an operation on a debug object failed because the object is in the process of being deleted.</para>
        /// </summary>
        DebuggerInactive = 1284,

        /// <summary>
        /// <para>MessageId: ERROR_DELAY_LOAD_FAILED</para>
        /// <para>MessageText: An attempt to delay-load a .dll or get a function address in a delay-loaded .dll failed.</para>
        /// </summary>
        DelayLoadFailed = 1285,

        /// <summary>
        /// <para>MessageId: ERROR_VDM_DISALLOWED</para>
        /// <para>MessageText: %1 is a 16-bit application. You do not have permissions to execute 16-bit applications. Check your permissions with your system administrator.</para>
        /// </summary>
        VDMDisallowed = 1286,

        /// <summary>
        /// <para>MessageId: ERROR_UNIDENTIFIED_ERROR</para>
        /// <para>MessageText: Insufficient information exists to identify the cause of failure.</para>
        /// </summary>
        UnidentifiedError = 1287,

        /// <summary>
        /// <para>MessageId: ERROR_INVALID_CRUNTIME_PARAMETER</para>
        /// <para>MessageText: The parameter passed to a C runtime function is incorrect.</para>
        /// </summary>
        InvalidCRuntimeParameter = 1288,

        /// <summary>
        /// <para>MessageId: ERROR_BEYOND_VDL</para>
        /// <para>MessageText: The operation occurred beyond the valid data length of the file.</para>
        /// </summary>
        BeyondVDL = 1289,

        /// <summary>
        /// <para>MessageId: ERROR_INCOMPATIBLE_SERVICE_SID_TYPE</para>
        /// <para>MessageText: The service start failed since one or more services in the same process have an incompatible service SID type setting. A service with restricted service SID type can only coexist in the same process with other services with a restricted SID type. If the service SID type for this service was just configured, the hosting process must be restarted in order to start this service.</para>
        /// </summary>
        IncompatibleServiceSIDType = 1290,

        /// <summary>
        /// <para>MessageId: ERROR_DRIVER_PROCESS_TERMINATED</para>
        /// <para>MessageText: The process hosting the driver for this device has been terminated.</para>
        /// </summary>
        DriverProcessTerminated = 1291,

        /// <summary>
        /// <para>MessageId: ERROR_IMPLEMENTATION_LIMIT</para>
        /// <para>MessageText: An operation attempted to exceed an implementation-defined limit.</para>
        /// </summary>
        ImplementationLimit = 1292,

        /// <summary>
        /// <para>MessageId: ERROR_PROCESS_IS_PROTECTED</para>
        /// <para>MessageText: Either the target process, or the target thread's containing process, is a protected process.</para>
        /// </summary>
        ProcessIsProtected = 1293,

        /// <summary>
        /// <para>MessageId: ERROR_SERVICE_NOTIFY_CLIENT_LAGGING</para>
        /// <para>MessageText: The service notification client is lagging too far behind the current state of services in the machine.</para>
        /// </summary>
        ServiceNotifyClientLagging = 1294,

        /// <summary>
        /// <para>MessageId: ERROR_DISK_QUOTA_EXCEEDED</para>
        /// <para>MessageText: The requested file operation failed because the storage quota was exceeded.</para>
        /// </summary>
        DiskQuotaExceeded = 1295,

        /// <summary>
        /// <para>MessageId: ERROR_CONTENT_BLOCKED</para>
        /// <para>MessageText: The requested file operation failed because the storage policy blocks that type of file. For more information, contact your system administrator.</para>
        /// </summary>
        ContentBlocked = 1296,

        /// <summary>
        /// <para>MessageId: ERROR_INCOMPATIBLE_SERVICE_PRIVILEGE</para>
        /// <para>MessageText: A privilege that the service requires to function properly does not exist in the service account configuration.</para>
        /// </summary>
        IncompatibleServicePrivilege = 1297,

        /// <summary>
        /// <para>MessageId: ERROR_APP_HANG</para>
        /// <para>MessageText: A thread involved in this operation appears to be unresponsive.</para>
        /// </summary>
        AppHang = 1298,



        /// <summary>
        /// <para>MessageId: ERROR_INVALID_LABEL</para>
        /// <para>MessageText: Indicates a particular Security ID may not be assigned as the label of an object.</para>
        /// </summary>
        InvalidLabel = 1299,

        /// <summary>
        /// <para>MessageId: ERROR_NOT_ALL_ASSIGNED</para>
        /// <para>MessageText: Not all privileges or groups referenced are assigned to the caller.</para>
        /// </summary>
        NotAllAssigned = 1300,

        /// <summary>
        /// <para>MessageId: ERROR_SOME_NOT_MAPPED</para>
        /// <para>MessageText: Some mapping between account names and security IDs was not done.</para>
        /// </summary>
        SomeNotMapped = 1301,

        /// <summary>
        /// <para>MessageId: ERROR_NO_QUOTAS_FOR_ACCOUNT</para>
        /// <para>MessageText: No system quota limits are specifically set for this account.</para>
        /// </summary>
        NoQuotasForAccount = 1302,

        /// <summary>
        /// <para>MessageId: ERROR_LOCAL_USER_SESSION_KEY</para>
        /// <para>MessageText: No encryption key is available. A well-known encryption key was returned.</para>
        /// </summary>
        LocalUserSessionKey = 1303,

        /// <summary>
        /// <para>MessageId: ERROR_NULL_LM_PASSWORD</para>
        /// <para>MessageText: The password is too complex to be converted to a LAN Manager password. The LAN Manager password returned is a NULL string.</para>
        /// </summary>
        NullLMPassword = 1304,

        /// <summary>
        /// <para>MessageId: ERROR_UNKNOWN_REVISION</para>
        /// <para>MessageText: The revision level is unknown.</para>
        /// </summary>
        UnknownRevision = 1305,

        /// <summary>
        /// <para>MessageId: ERROR_REVISION_MISMATCH</para>
        /// <para>MessageText: Indicates two revision levels are incompatible.</para>
        /// </summary>
        RevisionMismatch = 1306,

        /// <summary>
        /// <para>MessageId: ERROR_INVALID_OWNER</para>
        /// <para>MessageText: This security ID may not be assigned as the owner of this object.</para>
        /// </summary>
        InvalidOwner = 1307,

        /// <summary>
        /// <para>MessageId: ERROR_INVALID_PRIMARY_GROUP</para>
        /// <para>MessageText: This security ID may not be assigned as the primary group of an object.</para>
        /// </summary>
        InvalidPrimaryGroup = 1308,

        /// <summary>
        /// <para>MessageId: ERROR_NO_IMPERSONATION_TOKEN</para>
        /// <para>MessageText: An attempt has been made to operate on an impersonation token by a thread that is not currently impersonating a client.</para>
        /// </summary>
        NoImpersonationToken = 1309,

        /// <summary>
        /// <para>MessageId: ERROR_CANT_DISABLE_MANDATORY</para>
        /// <para>MessageText: The group may not be disabled.</para>
        /// </summary>
        CantDisableMandatory = 1310,

        /// <summary>
        /// <para>MessageId: ERROR_NO_LOGON_SERVERS</para>
        /// <para>MessageText: We can't sign you in with this credential because your domain isn't available. Make sure your device is connected to your organization's network and try again. If you previously signed in on this device with another credential, you can sign in with that credential.</para>
        /// </summary>
        NoLogonServers = 1311,

        /// <summary>
        /// <para>MessageId: ERROR_NO_SUCH_LOGON_SESSION</para>
        /// <para>MessageText: A specified logon session does not exist. It may already have been terminated.</para>
        /// </summary>
        NoSuchLogonSession = 1312,

        /// <summary>
        /// <para>MessageId: ERROR_NO_SUCH_PRIVILEGE</para>
        /// <para>MessageText: A specified privilege does not exist.</para>
        /// </summary>
        NoSuchPrivilege = 1313,

        /// <summary>
        /// <para>MessageId: ERROR_PRIVILEGE_NOT_HELD</para>
        /// <para>MessageText: A required privilege is not held by the client.</para>
        /// </summary>
        PrivilegeNotHeld = 1314,

        /// <summary>
        /// <para>MessageId: ERROR_INVALID_ACCOUNT_NAME</para>
        /// <para>MessageText: The name provided is not a properly formed account name.</para>
        /// </summary>
        InvalidAccountName = 1315,

        /// <summary>
        /// <para>MessageId: ERROR_USER_EXISTS</para>
        /// <para>MessageText: The specified account already exists.</para>
        /// </summary>
        UserExists = 1316,

        /// <summary>
        /// <para>MessageId: ERROR_NO_SUCH_USER</para>
        /// <para>MessageText: The specified account does not exist.</para>
        /// </summary>
        NoSuchUser = 1317,

        /// <summary>
        /// <para>MessageId: ERROR_GROUP_EXISTS</para>
        /// <para>MessageText: The specified group already exists.</para>
        /// </summary>
        GroupExists = 1318,

        /// <summary>
        /// <para>MessageId: ERROR_NO_SUCH_GROUP</para>
        /// <para>MessageText: The specified group does not exist.</para>
        /// </summary>
        NoSuchGroup = 1319,

        /// <summary>
        /// <para>MessageId: ERROR_MEMBER_IN_GROUP</para>
        /// <para>MessageText: Either the specified user account is already a member of the specified group, or the specified group cannot be deleted because it contains a member.</para>
        /// </summary>
        MemberInGroup = 1320,

        /// <summary>
        /// <para>MessageId: ERROR_MEMBER_NOT_IN_GROUP</para>
        /// <para>MessageText: The specified user account is not a member of the specified group account.</para>
        /// </summary>
        MemberNotInGroup = 1321,

        /// <summary>
        /// <para>MessageId: ERROR_LAST_ADMIN</para>
        /// <para>MessageText: This operation is disallowed as it could result in an administration account being disabled, deleted or unable to logon.</para>
        /// </summary>
        LastAdmin = 1322,

        /// <summary>
        /// <para>MessageId: ERROR_WRONG_PASSWORD</para>
        /// <para>MessageText: Unable to update the password. The value provided as the current password is incorrect.</para>
        /// </summary>
        WrongPassword = 1323,

        /// <summary>
        /// <para>MessageId: ERROR_ILL_FORMED_PASSWORD</para>
        /// <para>MessageText: Unable to update the password. The value provided for the new password contains values that are not allowed in passwords.</para>
        /// </summary>
        IllFormedPassword = 1324,

        /// <summary>
        /// <para>MessageId: ERROR_PASSWORD_RESTRICTION</para>
        /// <para>MessageText: Unable to update the password. The value provided for the new password does not meet the length, complexity, or history requirements of the domain.</para>
        /// </summary>
        PasswordRestriction = 1325,

        /// <summary>
        /// <para>MessageId: ERROR_LOGON_FAILURE</para>
        /// <para>MessageText: The user name or password is incorrect.</para>
        /// </summary>
        LogonFailure = 1326,

        /// <summary>
        /// <para>MessageId: ERROR_ACCOUNT_RESTRICTION</para>
        /// <para>MessageText: Account restrictions are preventing this user from signing in. For example: blank passwords aren't allowed, sign-in times are limited, or a policy restriction has been enforced.</para>
        /// </summary>
        AccountRestriction = 1327,

        /// <summary>
        /// <para>MessageId: ERROR_INVALID_LOGON_HOURS</para>
        /// <para>MessageText: Your account has time restrictions that keep you from signing in right now.</para>
        /// </summary>
        InvalidLogonHours = 1328,

        /// <summary>
        /// <para>MessageId: ERROR_INVALID_WORKSTATION</para>
        /// <para>MessageText: This user isn't allowed to sign in to this computer.</para>
        /// </summary>
        InvalidWorkstation = 1329,

        /// <summary>
        /// <para>MessageId: ERROR_PASSWORD_EXPIRED</para>
        /// <para>MessageText: The password for this account has expired.</para>
        /// </summary>
        PasswordExpired = 1330,

        /// <summary>
        /// <para>MessageId: ERROR_ACCOUNT_DISABLED</para>
        /// <para>MessageText: This user can't sign in because this account is currently disabled.</para>
        /// </summary>
        AccountDisabled = 1331,

        /// <summary>
        /// <para>MessageId: ERROR_NONE_MAPPED</para>
        /// <para>MessageText: No mapping between account names and security IDs was done.</para>
        /// </summary>
        NoneMapped = 1332,

        /// <summary>
        /// <para>MessageId: ERROR_TOO_MANY_LUIDS_REQUESTED</para>
        /// <para>MessageText: Too many local user identifiers (LUIDs) were requested at one time.</para>
        /// </summary>
        TooManyLUIDsRequested = 1333,

        /// <summary>
        /// <para>MessageId: ERROR_LUIDS_EXHAUSTED</para>
        /// <para>MessageText: No more local user identifiers (LUIDs) are available.</para>
        /// </summary>
        LUIDsExhausted = 1334,

        /// <summary>
        /// <para>MessageId: ERROR_INVALID_SUB_AUTHORITY</para>
        /// <para>MessageText: The subauthority part of a security ID is invalid for this particular use.</para>
        /// </summary>
        InvalidSubAuthority = 1335,

        /// <summary>
        /// <para>MessageId: ERROR_INVALID_ACL</para>
        /// <para>MessageText: The access control list (ACL) structure is invalid.</para>
        /// </summary>
        InvalidACL = 1336,

        /// <summary>
        /// <para>MessageId: ERROR_INVALID_SID</para>
        /// <para>MessageText: The security ID structure is invalid.</para>
        /// </summary>
        InvalidSID = 1337,

        /// <summary>
        /// <para>MessageId: ERROR_INVALID_SECURITY_DESCR</para>
        /// <para>MessageText: The security descriptor structure is invalid.</para>
        /// </summary>
        InvalidSecurityDescriptor = 1338,

        /// <summary>
        /// <para>MessageId: ERROR_BAD_INHERITANCE_ACL</para>
        /// <para>MessageText: The inherited access control list (ACL) or access control entry (ACE) could not be built.</para>
        /// </summary>
        BadInheritanceACL = 1340,

        /// <summary>
        /// <para>MessageId: ERROR_SERVER_DISABLED</para>
        /// <para>MessageText: The server is currently disabled.</para>
        /// </summary>
        ServerDisabled = 1341,

        /// <summary>
        /// <para>MessageId: ERROR_SERVER_NOT_DISABLED</para>
        /// <para>MessageText: The server is currently enabled.</para>
        /// </summary>
        ServerNotDisabled = 1342,

        /// <summary>
        /// <para>MessageId: ERROR_INVALID_ID_AUTHORITY</para>
        /// <para>MessageText: The value provided was an invalid value for an identifier authority.</para>
        /// </summary>
        InvalidIDAuthority = 1343,

        /// <summary>
        /// <para>MessageId: ERROR_ALLOTTED_SPACE_EXCEEDED</para>
        /// <para>MessageText: No more memory is available for security information updates.</para>
        /// </summary>
        AllottedSpaceExceeded = 1344,

        /// <summary>
        /// <para>MessageId: ERROR_INVALID_GROUP_ATTRIBUTES</para>
        /// <para>MessageText: The specified attributes are invalid, or incompatible with the attributes for the group as a whole.</para>
        /// </summary>
        InvalidGroupAttributes = 1345,

        /// <summary>
        /// <para>MessageId: ERROR_BAD_IMPERSONATION_LEVEL</para>
        /// <para>MessageText: Either a required impersonation level was not provided, or the provided impersonation level is invalid.</para>
        /// </summary>
        BadImpersonationLevel = 1346,

        /// <summary>
        /// <para>MessageId: ERROR_CANT_OPEN_ANONYMOUS</para>
        /// <para>MessageText: Cannot open an anonymous level security token.</para>
        /// </summary>
        CantOpenAnonymous = 1347,

        /// <summary>
        /// <para>MessageId: ERROR_BAD_VALIDATION_CLASS</para>
        /// <para>MessageText: The validation information class requested was invalid.</para>
        /// </summary>
        BadValidationClass = 1348,

        /// <summary>
        /// <para>MessageId: ERROR_BAD_TOKEN_TYPE</para>
        /// <para>MessageText: The type of the token is inappropriate for its attempted use.</para>
        /// </summary>
        BadTokenType = 1349,

        /// <summary>
        /// <para>MessageId: ERROR_NO_SECURITY_ON_OBJECT</para>
        /// <para>MessageText: Unable to perform a security operation on an object that has no associated security.</para>
        /// </summary>
        NoSecurityOnObject = 1350,

        /// <summary>
        /// <para>MessageId: ERROR_CANT_ACCESS_DOMAIN_INFO</para>
        /// <para>MessageText: Configuration information could not be read from the domain controller, either because the machine is unavailable, or access has been denied.</para>
        /// </summary>
        CantAccessDomainInfo = 1351,

        /// <summary>
        /// <para>MessageId: ERROR_INVALID_SERVER_STATE</para>
        /// <para>MessageText: The security account manager (SAM) or local security authority (LSA) server was in the wrong state to perform the security operation.</para>
        /// </summary>
        InvalidServerState = 1352,

        /// <summary>
        /// <para>MessageId: ERROR_INVALID_DOMAIN_STATE</para>
        /// <para>MessageText: The domain was in the wrong state to perform the security operation.</para>
        /// </summary>
        InvalidDomainState = 1353,

        /// <summary>
        /// <para>MessageId: ERROR_INVALID_DOMAIN_ROLE</para>
        /// <para>MessageText: This operation is only allowed for the Primary Domain Controller of the domain.</para>
        /// </summary>
        InvalidDomainRole = 1354,

        /// <summary>
        /// <para>MessageId: ERROR_NO_SUCH_DOMAIN</para>
        /// <para>MessageText: The specified domain either does not exist or could not be contacted.</para>
        /// </summary>
        NoSuchDomain = 1355,

        /// <summary>
        /// <para>MessageId: ERROR_DOMAIN_EXISTS</para>
        /// <para>MessageText: The specified domain already exists.</para>
        /// </summary>
        DomainExists = 1356,

        /// <summary>
        /// <para>MessageId: ERROR_DOMAIN_LIMIT_EXCEEDED</para>
        /// <para>MessageText: An attempt was made to exceed the limit on the number of domains per server.</para>
        /// </summary>
        DomainLimitExceeded = 1357,

        /// <summary>
        /// <para>MessageId: ERROR_INTERNAL_DB_CORRUPTION</para>
        /// <para>MessageText: Unable to complete the requested operation because of either a catastrophic media failure or a data structure corruption on the disk.</para>
        /// </summary>
        InternalDBCorruption = 1358,

        /// <summary>
        /// <para>MessageId: ERROR_INTERNAL_ERROR</para>
        /// <para>MessageText: An internal error occurred.</para>
        /// </summary>
        InternalError = 1359,

        /// <summary>
        /// <para>MessageId: ERROR_GENERIC_NOT_MAPPED</para>
        /// <para>MessageText: Generic access types were contained in an access mask which should already be mapped to nongeneric types.</para>
        /// </summary>
        GenericNotMapped = 1360,

        /// <summary>
        /// <para>MessageId: ERROR_BAD_DESCRIPTOR_FORMAT</para>
        /// <para>MessageText: A security descriptor is not in the right format (absolute or self-relative).</para>
        /// </summary>
        BadDescriptorFormat = 1361,

        /// <summary>
        /// <para>MessageId: ERROR_NOT_LOGON_PROCESS</para>
        /// <para>MessageText: The requested action is restricted for use by logon processes only. The calling process has not registered as a logon process.</para>
        /// </summary>
        NotLogonProcess = 1362,

        /// <summary>
        /// <para>MessageId: ERROR_LOGON_SESSION_EXISTS</para>
        /// <para>MessageText: Cannot start a new logon session with an ID that is already in use.</para>
        /// </summary>
        LogonSessionExists = 1363,

        /// <summary>
        /// <para>MessageId: ERROR_NO_SUCH_PACKAGE</para>
        /// <para>MessageText: A specified authentication package is unknown.</para>
        /// </summary>
        NoSuchPackage = 1364,

        /// <summary>
        /// <para>MessageId: ERROR_BAD_LOGON_SESSION_STATE</para>
        /// <para>MessageText: The logon session is not in a state that is consistent with the requested operation.</para>
        /// </summary>
        BadLogonSessionState = 1365,

        /// <summary>
        /// <para>MessageId: ERROR_LOGON_SESSION_COLLISION</para>
        /// <para>MessageText: The logon session ID is already in use.</para>
        /// </summary>
        LogonSessionCollision = 1366,

        /// <summary>
        /// <para>MessageId: ERROR_INVALID_LOGON_TYPE</para>
        /// <para>MessageText: A logon request contained an invalid logon type value.</para>
        /// </summary>
        InvalidLogonType = 1367,

        /// <summary>
        /// <para>MessageId: ERROR_CANNOT_IMPERSONATE</para>
        /// <para>MessageText: Unable to impersonate using a named pipe until data has been read from that pipe.</para>
        /// </summary>
        CannotImpersonate = 1368,

        /// <summary>
        /// <para>MessageId: ERROR_RXACT_INVALID_STATE</para>
        /// <para>MessageText: The transaction state of a registry subtree is incompatible with the requested operation.</para>
        /// </summary>
        RXACTInvalidState = 1369,

        /// <summary>
        /// <para>MessageId: ERROR_RXACT_COMMIT_FAILURE</para>
        /// <para>MessageText: An internal security database corruption has been encountered.</para>
        /// </summary>
        RXACTCommitFailure = 1370,

        /// <summary>
        /// <para>MessageId: ERROR_SPECIAL_ACCOUNT</para>
        /// <para>MessageText: Cannot perform this operation on built-in accounts.</para>
        /// </summary>
        SpecialAccount = 1371,

        /// <summary>
        /// <para>MessageId: ERROR_SPECIAL_GROUP</para>
        /// <para>MessageText: Cannot perform this operation on this built-in special group.</para>
        /// </summary>
        SpecialGroup = 1372,

        /// <summary>
        /// <para>MessageId: ERROR_SPECIAL_USER</para>
        /// <para>MessageText: Cannot perform this operation on this built-in special user.</para>
        /// </summary>
        SpecialUser = 1373,

        /// <summary>
        /// <para>MessageId: ERROR_MEMBERS_PRIMARY_GROUP</para>
        /// <para>MessageText: The user cannot be removed from a group because the group is currently the user's primary group.</para>
        /// </summary>
        MembersPrimaryGroup = 1374,

        /// <summary>
        /// <para>MessageId: ERROR_TOKEN_ALREADY_IN_USE</para>
        /// <para>MessageText: The token is already in use as a primary token.</para>
        /// </summary>
        TokenAlreadyInUse = 1375,

        /// <summary>
        /// <para>MessageId: ERROR_NO_SUCH_ALIAS</para>
        /// <para>MessageText: The specified local group does not exist.</para>
        /// </summary>
        NoSuchAlias = 1376,

        /// <summary>
        /// <para>MessageId: ERROR_MEMBER_NOT_IN_ALIAS</para>
        /// <para>MessageText: The specified account name is not a member of the group.</para>
        /// </summary>
        MemberNotInAlias = 1377,

        /// <summary>
        /// <para>MessageId: ERROR_MEMBER_IN_ALIAS</para>
        /// <para>MessageText: The specified account name is already a member of the group.</para>
        /// </summary>
        MemberInAlias = 1378,

        /// <summary>
        /// <para>MessageId: ERROR_ALIAS_EXISTS</para>
        /// <para>MessageText: The specified local group already exists.</para>
        /// </summary>
        AliasExists = 1379,

        /// <summary>
        /// <para>MessageId: ERROR_LOGON_NOT_GRANTED</para>
        /// <para>MessageText: Logon failure: the user has not been granted the requested logon type at this computer.</para>
        /// </summary>
        LogonNotGranted = 1380,

        /// <summary>
        /// <para>MessageId: ERROR_TOO_MANY_SECRETS</para>
        /// <para>MessageText: The maximum number of secrets that may be stored in a single system has been exceeded.</para>
        /// </summary>
        TooManySecrets = 1381,

        /// <summary>
        /// <para>MessageId: ERROR_SECRET_TOO_LONG</para>
        /// <para>MessageText: The length of a secret exceeds the maximum length allowed.</para>
        /// </summary>
        SecretTooLong = 1382,

        /// <summary>
        /// <para>MessageId: ERROR_INTERNAL_DB_ERROR</para>
        /// <para>MessageText: The local security authority database contains an internal inconsistency.</para>
        /// </summary>
        InternalDBError = 1383,

        /// <summary>
        /// <para>MessageId: ERROR_TOO_MANY_CONTEXT_IDS</para>
        /// <para>MessageText: During a logon attempt, the user's security context accumulated too many security IDs.</para>
        /// </summary>
        TooManyContextIDs = 1384,

        /// <summary>
        /// <para>MessageId: ERROR_LOGON_TYPE_NOT_GRANTED</para>
        /// <para>MessageText: Logon failure: the user has not been granted the requested logon type at this computer.</para>
        /// </summary>
        LogonTypeNotGranted = 1385,

        /// <summary>
        /// <para>MessageId: ERROR_NT_CROSS_ENCRYPTION_REQUIRED</para>
        /// <para>MessageText: A cross-encrypted password is necessary to change a user password.</para>
        /// </summary>
        NTCrossEncryptionRequired = 1386,

        /// <summary>
        /// <para>MessageId: ERROR_NO_SUCH_MEMBER</para>
        /// <para>MessageText: A member could not be added to or removed from the local group because the member does not exist.</para>
        /// </summary>
        NoSuchMember = 1387,

        /// <summary>
        /// <para>MessageId: ERROR_INVALID_MEMBER</para>
        /// <para>MessageText: A new member could not be added to a local group because the member has the wrong account type.</para>
        /// </summary>
        InvalidMember = 1388,

        /// <summary>
        /// <para>MessageId: ERROR_TOO_MANY_SIDS</para>
        /// <para>MessageText: Too many security IDs have been specified.</para>
        /// </summary>
        TooManySIDs = 1389,

        /// <summary>
        /// <para>MessageId: ERROR_LM_CROSS_ENCRYPTION_REQUIRED</para>
        /// <para>MessageText: A cross-encrypted password is necessary to change this user password.</para>
        /// </summary>
        LMCrossEncryptionRequired = 1390,

        /// <summary>
        /// <para>MessageId: ERROR_NO_INHERITANCE</para>
        /// <para>MessageText: Indicates an ACL contains no inheritable components.</para>
        /// </summary>
        NoInheritance = 1391,

        /// <summary>
        /// <para>MessageId: ERROR_FILE_CORRUPT</para>
        /// <para>MessageText: The file or directory is corrupted and unreadable.</para>
        /// </summary>
        FileCorrupt = 1392,

        /// <summary>
        /// <para>MessageId: ERROR_DISK_CORRUPT</para>
        /// <para>MessageText: The disk structure is corrupted and unreadable.</para>
        /// </summary>
        DiskCorrupt = 1393,

        /// <summary>
        /// <para>MessageId: ERROR_NO_USER_SESSION_KEY</para>
        /// <para>MessageText: There is no user session key for the specified logon session.</para>
        /// </summary>
        NoUserSessionKey = 1394,

        /// <summary>
        /// <para>MessageId: ERROR_LICENSE_QUOTA_EXCEEDED</para>
        /// <para>MessageText: The service being accessed is licensed for a particular number of connections. No more connections can be made to the service at this time because there are already as many connections as the service can accept.</para>
        /// </summary>
        LicenseQuotaExceeded = 1395,

        /// <summary>
        /// <para>MessageId: ERROR_WRONG_TARGET_NAME</para>
        /// <para>MessageText: The target account name is incorrect.</para>
        /// </summary>
        WrongTargetName = 1396,

        /// <summary>
        /// <para>MessageId: ERROR_MUTUAL_AUTH_FAILED</para>
        /// <para>MessageText: Mutual Authentication failed. The server's password is out of date at the domain controller.</para>
        /// </summary>
        MutualAuthFailed = 1397,

        /// <summary>
        /// <para>MessageId: ERROR_TIME_SKEW</para>
        /// <para>MessageText: There is a time and/or date difference between the client and server.</para>
        /// </summary>
        TimeSkew = 1398,

        /// <summary>
        /// <para>MessageId: ERROR_CURRENT_DOMAIN_NOT_ALLOWED</para>
        /// <para>MessageText: This operation cannot be performed on the current domain.</para>
        /// </summary>
        CurrentDomainNotAllowed = 1399,



        /// <summary>
        /// <para>MessageId: ERROR_INVALID_WINDOW_HANDLE</para>
        /// <para>MessageText: Invalid window handle.</para>
        /// </summary>
        InvalidWindowHandle = 1400,

        /// <summary>
        /// <para>MessageId: ERROR_INVALID_MENU_HANDLE</para>
        /// <para>MessageText: Invalid menu handle.</para>
        /// </summary>
        InvalidMenuHandle = 1401,

        /// <summary>
        /// <para>MessageId: ERROR_INVALID_CURSOR_HANDLE</para>
        /// <para>MessageText: Invalid cursor handle.</para>
        /// </summary>
        InvalidCursorHandle = 1402,

        /// <summary>
        /// <para>MessageId: ERROR_INVALID_ACCEL_HANDLE</para>
        /// <para>MessageText: Invalid accelerator table handle.</para>
        /// </summary>
        InvalidAcceleratorHandle = 1403,

        /// <summary>
        /// <para>MessageId: ERROR_INVALID_HOOK_HANDLE</para>
        /// <para>MessageText: Invalid hook handle.</para>
        /// </summary>
        InvalidHookHandle = 1404,

        /// <summary>
        /// <para>MessageId: ERROR_INVALID_DWP_HANDLE</para>
        /// <para>MessageText: Invalid handle to a multiple-window position structure.</para>
        /// </summary>
        InvalidDWPHandle = 1405,

        /// <summary>
        /// <para>MessageId: ERROR_TLW_WITH_WSCHILD</para>
        /// <para>MessageText: Cannot create a top-level child window.</para>
        /// </summary>
        TLWWithWSChild = 1406,

        /// <summary>
        /// <para>MessageId: ERROR_CANNOT_FIND_WND_CLASS</para>
        /// <para>MessageText: Cannot find window class.</para>
        /// </summary>
        CannotFindWndClass = 1407,

        /// <summary>
        /// <para>MessageId: ERROR_WINDOW_OF_OTHER_THREAD</para>
        /// <para>MessageText: Invalid window; it belongs to other thread.</para>
        /// </summary>
        WindowOfOtherThread = 1408,

        /// <summary>
        /// <para>MessageId: ERROR_HOTKEY_ALREADY_REGISTERED</para>
        /// <para>MessageText: Hot key is already registered.</para>
        /// </summary>
        HotKeyAlreadyRegistered = 1409,

        /// <summary>
        /// <para>MessageId: ERROR_CLASS_ALREADY_EXISTS</para>
        /// <para>MessageText: Class already exists.</para>
        /// </summary>
        ClassAlreadyExists = 1410,

        /// <summary>
        /// <para>MessageId: ERROR_CLASS_DOES_NOT_EXIST</para>
        /// <para>MessageText: Class does not exist.</para>
        /// </summary>
        ClassDoesNotExist = 1411,

        /// <summary>
        /// <para>MessageId: ERROR_CLASS_HAS_WINDOWS</para>
        /// <para>MessageText: Class still has open windows.</para>
        /// </summary>
        ClassHasWindows = 1412,

        /// <summary>
        /// <para>MessageId: ERROR_INVALID_INDEX</para>
        /// <para>MessageText: Invalid index.</para>
        /// </summary>
        InvalidIndex = 1413,

        /// <summary>
        /// <para>MessageId: ERROR_INVALID_ICON_HANDLE</para>
        /// <para>MessageText: Invalid icon handle.</para>
        /// </summary>
        InvalidIconHandle = 1414,

        /// <summary>
        /// <para>MessageId: ERROR_PRIVATE_DIALOG_INDEX</para>
        /// <para>MessageText: Using private DIALOG window words.</para>
        /// </summary>
        PrivateDialogIndex = 1415,

        /// <summary>
        /// <para>MessageId: ERROR_LISTBOX_ID_NOT_FOUND</para>
        /// <para>MessageText: The list box identifier was not found.</para>
        /// </summary>
        ListBoxIdNotFound = 1416,

        /// <summary>
        /// <para>MessageId: ERROR_NO_WILDCARD_CHARACTERS</para>
        /// <para>MessageText: No wildcards were found.</para>
        /// </summary>
        NoWildcardCharacters = 1417,

        /// <summary>
        /// <para>MessageId: ERROR_CLIPBOARD_NOT_OPEN</para>
        /// <para>MessageText: Thread does not have a clipboard open.</para>
        /// </summary>
        ClipboardNotOpen = 1418,

        /// <summary>
        /// <para>MessageId: ERROR_HOTKEY_NOT_REGISTERED</para>
        /// <para>MessageText: Hot key is not registered.</para>
        /// </summary>
        HotKeyNotRegistered = 1419,

        /// <summary>
        /// <para>MessageId: ERROR_WINDOW_NOT_DIALOG</para>
        /// <para>MessageText: The window is not a valid dialog window.</para>
        /// </summary>
        WindowNotDialog = 1420,

        /// <summary>
        /// <para>MessageId: ERROR_CONTROL_ID_NOT_FOUND</para>
        /// <para>MessageText: Control ID not found.</para>
        /// </summary>
        ControlIdNotFound = 1421,

        /// <summary>
        /// <para>MessageId: ERROR_INVALID_COMBOBOX_MESSAGE</para>
        /// <para>MessageText: Invalid message for a combo box because it does not have an edit control.</para>
        /// </summary>
        InvalidComboBoxMessage = 1422,

        /// <summary>
        /// <para>MessageId: ERROR_WINDOW_NOT_COMBOBOX</para>
        /// <para>MessageText: The window is not a combo box.</para>
        /// </summary>
        WindowNotComboBox = 1423,

        /// <summary>
        /// <para>MessageId: ERROR_INVALID_EDIT_HEIGHT</para>
        /// <para>MessageText: Height must be less than= 256.</para>
        /// </summary>
        InvalidEditHeight = 1424,

        /// <summary>
        /// <para>MessageId: ERROR_DC_NOT_FOUND</para>
        /// <para>MessageText: Invalid device context (DC) handle.</para>
        /// </summary>
        DCNotFound = 1425,

        /// <summary>
        /// <para>MessageId: ERROR_INVALID_HOOK_FILTER</para>
        /// <para>MessageText: Invalid hook procedure type.</para>
        /// </summary>
        InvalidHookFilter = 1426,

        /// <summary>
        /// <para>MessageId: ERROR_INVALID_FILTER_PROC</para>
        /// <para>MessageText: Invalid hook procedure.</para>
        /// </summary>
        InvalidFilterProc = 1427,

        /// <summary>
        /// <para>MessageId: ERROR_HOOK_NEEDS_HMOD</para>
        /// <para>MessageText: Cannot set nonlocal hook without a module handle.</para>
        /// </summary>
        HookNeedsHMod = 1428,

        /// <summary>
        /// <para>MessageId: ERROR_GLOBAL_ONLY_HOOK</para>
        /// <para>MessageText: This hook procedure can only be set globally.</para>
        /// </summary>
        GlobalOnlyHook = 1429,

        /// <summary>
        /// <para>MessageId: ERROR_JOURNAL_HOOK_SET</para>
        /// <para>MessageText: The journal hook procedure is already installed.</para>
        /// </summary>
        JournalHookSet = 1430,

        /// <summary>
        /// <para>MessageId: ERROR_HOOK_NOT_INSTALLED</para>
        /// <para>MessageText: The hook procedure is not installed.</para>
        /// </summary>
        HookNotInstalled = 1431,

        /// <summary>
        /// <para>MessageId: ERROR_INVALID_LB_MESSAGE</para>
        /// <para>MessageText: Invalid message for single-selection list box.</para>
        /// </summary>
        InvalidLBMessage = 1432,

        /// <summary>
        /// <para>MessageId: ERROR_SETCOUNT_ON_BAD_LB</para>
        /// <para>MessageText: LB_SETCOUNT sent to non-lazy list box.</para>
        /// </summary>
        SetCountOnBadLB = 1433,

        /// <summary>
        /// <para>MessageId: ERROR_LB_WITHOUT_TABSTOPS</para>
        /// <para>MessageText: This list box does not support tab stops.</para>
        /// </summary>
        LBWithoutTabStops = 1434,

        /// <summary>
        /// <para>MessageId: ERROR_DESTROY_OBJECT_OF_OTHER_THREAD</para>
        /// <para>MessageText: Cannot destroy object created by another thread.</para>
        /// </summary>
        DestroyObjectOfOtherThread = 1435,

        /// <summary>
        /// <para>MessageId: ERROR_CHILD_WINDOW_MENU</para>
        /// <para>MessageText: Child windows cannot have menus.</para>
        /// </summary>
        ChildWindowMenu = 1436,

        /// <summary>
        /// <para>MessageId: ERROR_NO_SYSTEM_MENU</para>
        /// <para>MessageText: The window does not have a system menu.</para>
        /// </summary>
        NoSystemMenu = 1437,

        /// <summary>
        /// <para>MessageId: ERROR_INVALID_MSGBOX_STYLE</para>
        /// <para>MessageText: Invalid message box style.</para>
        /// </summary>
        InvalidMsgBoxStyle = 1438,

        /// <summary>
        /// <para>MessageId: ERROR_INVALID_SPI_VALUE</para>
        /// <para>MessageText: Invalid system-wide (SPI_*) parameter.</para>
        /// </summary>
        InvalidSPIValue = 1439,

        /// <summary>
        /// <para>MessageId: ERROR_SCREEN_ALREADY_LOCKED</para>
        /// <para>MessageText: Screen already locked.</para>
        /// </summary>
        ScreenAlreadyLocked = 1440,

        /// <summary>
        /// <para>MessageId: ERROR_HWNDS_HAVE_DIFF_PARENT</para>
        /// <para>MessageText: All handles to windows in a multiple-window position structure must have the same parent.</para>
        /// </summary>
        HWndsHaveDiffParent = 1441,

        /// <summary>
        /// <para>MessageId: ERROR_NOT_CHILD_WINDOW</para>
        /// <para>MessageText: The window is not a child window.</para>
        /// </summary>
        NotChildWindow = 1442,

        /// <summary>
        /// <para>MessageId: ERROR_INVALID_GW_COMMAND</para>
        /// <para>MessageText: Invalid GW_* command.</para>
        /// </summary>
        InvalidGWCommand = 1443,

        /// <summary>
        /// <para>MessageId: ERROR_INVALID_THREAD_ID</para>
        /// <para>MessageText: Invalid thread identifier.</para>
        /// </summary>
        InvalidThreadId = 1444,

        /// <summary>
        /// <para>MessageId: ERROR_NON_MDICHILD_WINDOW</para>
        /// <para>MessageText: Cannot process a message from a window that is not a multiple document interface (MDI) window.</para>
        /// </summary>
        NonMDIChildWindow = 1445,

        /// <summary>
        /// <para>MessageId: ERROR_POPUP_ALREADY_ACTIVE</para>
        /// <para>MessageText: Popup menu already active.</para>
        /// </summary>
        PopupAlreadyActive = 1446,

        /// <summary>
        /// <para>MessageId: ERROR_NO_SCROLLBARS</para>
        /// <para>MessageText: The window does not have scroll bars.</para>
        /// </summary>
        NoScrollBars = 1447,

        /// <summary>
        /// <para>MessageId: ERROR_INVALID_SCROLLBAR_RANGE</para>
        /// <para>MessageText: Scroll bar range cannot be greater than MAXLONG.</para>
        /// </summary>
        InvalidScrollBarRange = 1448,

        /// <summary>
        /// <para>MessageId: ERROR_INVALID_SHOWWIN_COMMAND</para>
        /// <para>MessageText: Cannot show or remove the window in the way specified.</para>
        /// </summary>
        InvalidShowWinCommand = 1449,

        /// <summary>
        /// <para>MessageId: ERROR_NO_SYSTEM_RESOURCES</para>
        /// <para>MessageText: Insufficient system resources exist to complete the requested service.</para>
        /// </summary>
        NoSystemResources = 1450,

        /// <summary>
        /// <para>MessageId: ERROR_NONPAGED_SYSTEM_RESOURCES</para>
        /// <para>MessageText: Insufficient system resources exist to complete the requested service.</para>
        /// </summary>
        NonPagedSystemResources = 1451,

        /// <summary>
        /// <para>MessageId: ERROR_PAGED_SYSTEM_RESOURCES</para>
        /// <para>MessageText: Insufficient system resources exist to complete the requested service.</para>
        /// </summary>
        PagedSystemResources = 1452,

        /// <summary>
        /// <para>MessageId: ERROR_WORKING_SET_QUOTA</para>
        /// <para>MessageText: Insufficient quota to complete the requested service.</para>
        /// </summary>
        WorkingSetQuota = 1453,

        /// <summary>
        /// <para>MessageId: ERROR_PAGEFILE_QUOTA</para>
        /// <para>MessageText: Insufficient quota to complete the requested service.</para>
        /// </summary>
        PageFileQuota = 1454,

        /// <summary>
        /// <para>MessageId: ERROR_COMMITMENT_LIMIT</para>
        /// <para>MessageText: The paging file is too small for this operation to complete.</para>
        /// </summary>
        CommitmentLimit = 1455,

        /// <summary>
        /// <para>MessageId: ERROR_MENU_ITEM_NOT_FOUND</para>
        /// <para>MessageText: A menu item was not found.</para>
        /// </summary>
        MenuItemNotFound = 1456,

        /// <summary>
        /// <para>MessageId: ERROR_INVALID_KEYBOARD_HANDLE</para>
        /// <para>MessageText: Invalid keyboard layout handle.</para>
        /// </summary>
        InvalidKeyboardHandle = 1457,

        /// <summary>
        /// <para>MessageId: ERROR_HOOK_TYPE_NOT_ALLOWED</para>
        /// <para>MessageText: Hook type not allowed.</para>
        /// </summary>
        HookTypeNotAllowed = 1458,

        /// <summary>
        /// <para>MessageId: ERROR_REQUIRES_INTERACTIVE_WINDOWSTATION</para>
        /// <para>MessageText: This operation requires an interactive window station.</para>
        /// </summary>
        RequiresInteractiveWindowStation = 1459,

        /// <summary>
        /// <para>MessageId: ERROR_TIMEOUT</para>
        /// <para>MessageText: This operation returned because the timeout period expired.</para>
        /// </summary>
        Timeout = 1460,

        /// <summary>
        /// <para>MessageId: ERROR_INVALID_MONITOR_HANDLE</para>
        /// <para>MessageText: Invalid monitor handle.</para>
        /// </summary>
        InvalidMonitorHandle = 1461,

        /// <summary>
        /// <para>MessageId: ERROR_INCORRECT_SIZE</para>
        /// <para>MessageText: Incorrect size argument.</para>
        /// </summary>
        IncorrectSize = 1462,

        /// <summary>
        /// <para>MessageId: ERROR_SYMLINK_CLASS_DISABLED</para>
        /// <para>MessageText: The symbolic link cannot be followed because its type is disabled.</para>
        /// </summary>
        SymLinkClassDisabled = 1463,

        /// <summary>
        /// <para>MessageId: ERROR_SYMLINK_NOT_SUPPORTED</para>
        /// <para>MessageText: This application does not support the current operation on symbolic links.</para>
        /// </summary>
        SymLinkNotSupported = 1464,

        /// <summary>
        /// <para>MessageId: ERROR_XML_PARSE_ERROR</para>
        /// <para>MessageText: Windows was unable to parse the requested XML data.</para>
        /// </summary>
        XmlParseError = 1465,

        /// <summary>
        /// <para>MessageId: ERROR_XMLDSIG_ERROR</para>
        /// <para>MessageText: An error was encountered while processing an XML digital signature.</para>
        /// </summary>
        XmlDSigError = 1466,

        /// <summary>
        /// <para>MessageId: ERROR_RESTART_APPLICATION</para>
        /// <para>MessageText: This application must be restarted.</para>
        /// </summary>
        RestartApplication = 1467,

        /// <summary>
        /// <para>MessageId: ERROR_WRONG_COMPARTMENT</para>
        /// <para>MessageText: The caller made the connection request in the wrong routing compartment.</para>
        /// </summary>
        WrongCompartment = 1468,

        /// <summary>
        /// <para>MessageId: ERROR_AUTHIP_FAILURE</para>
        /// <para>MessageText: There was an AuthIP failure when attempting to connect to the remote host.</para>
        /// </summary>
        AuthIPFailure = 1469,

        /// <summary>
        /// <para>MessageId: ERROR_NO_NVRAM_RESOURCES</para>
        /// <para>MessageText: Insufficient NVRAM resources exist to complete the requested service. A reboot might be required.</para>
        /// </summary>
        NoNVRAMResources = 1470,

        /// <summary>
        /// <para>MessageId: ERROR_NOT_GUI_PROCESS</para>
        /// <para>MessageText: Unable to finish the requested operation because the specified process is not a GUI process.</para>
        /// </summary>
        NotGUIProcess = 1471,



        /// <summary>
        /// <para>MessageId: ERROR_EVENTLOG_FILE_CORRUPT</para>
        /// <para>MessageText: The event log file is corrupted.</para>
        /// </summary>
        EventLogFileCorrupt = 1500,

        /// <summary>
        /// <para>MessageId: ERROR_EVENTLOG_CANT_START</para>
        /// <para>MessageText: No event log file could be opened, so the event logging service did not start.</para>
        /// </summary>
        EventLogCantStart = 1501,

        /// <summary>
        /// <para>MessageId: ERROR_LOG_FILE_FULL</para>
        /// <para>MessageText: The event log file is full.</para>
        /// </summary>
        LogFileFull = 1502,

        /// <summary>
        /// <para>MessageId: ERROR_EVENTLOG_FILE_CHANGED</para>
        /// <para>MessageText: The event log file has changed between read operations.</para>
        /// </summary>
        EventLogFileChanged = 1503,

        /// <summary>
        /// <para>MessageId: ERROR_CONTAINER_ASSIGNED</para>
        /// <para>MessageText: The specified Job already has a container assigned to it.</para>
        /// </summary>
        ContainerAssigned = 1504,

        /// <summary>
        /// <para>MessageId: ERROR_JOB_NO_CONTAINER</para>
        /// <para>MessageText: The specified Job does not have a container assigned to it.</para>
        /// </summary>
        JobNoContainer = 1505,



        /// <summary>
        /// <para>MessageId: ERROR_INVALID_TASK_NAME</para>
        /// <para>MessageText: The specified task name is invalid.</para>
        /// </summary>
        InvalidTaskName = 1550,

        /// <summary>
        /// <para>MessageId: ERROR_INVALID_TASK_INDEX</para>
        /// <para>MessageText: The specified task index is invalid.</para>
        /// </summary>
        InvalidTaskIndex = 1551,

        /// <summary>
        /// <para>MessageId: ERROR_THREAD_ALREADY_IN_TASK</para>
        /// <para>MessageText: The specified thread is already joining a task.</para>
        /// </summary>
        ThreadAlreadyInTask = 1552,



        /// <summary>
        /// <para>MessageId: ERROR_INSTALL_SERVICE_FAILURE</para>
        /// <para>MessageText: The Windows Installer Service could not be accessed. This can occur if the Windows Installer is not correctly installed. Contact your support personnel for assistance.</para>
        /// </summary>
        InstallServiceFailure = 1601,

        /// <summary>
        /// <para>MessageId: ERROR_INSTALL_USEREXIT</para>
        /// <para>MessageText: User cancelled installation.</para>
        /// </summary>
        InstallUserExit = 1602,

        /// <summary>
        /// <para>MessageId: ERROR_INSTALL_FAILURE</para>
        /// <para>MessageText: Fatal error during installation.</para>
        /// </summary>
        InstallFailure = 1603,

        /// <summary>
        /// <para>MessageId: ERROR_INSTALL_SUSPEND</para>
        /// <para>MessageText: Installation suspended, incomplete.</para>
        /// </summary>
        InstallSuspend = 1604,

        /// <summary>
        /// <para>MessageId: ERROR_UNKNOWN_PRODUCT</para>
        /// <para>MessageText: This action is only valid for products that are currently installed.</para>
        /// </summary>
        UnknownProduct = 1605,

        /// <summary>
        /// <para>MessageId: ERROR_UNKNOWN_FEATURE</para>
        /// <para>MessageText: Feature ID not registered.</para>
        /// </summary>
        UnknownFeature = 1606,

        /// <summary>
        /// <para>MessageId: ERROR_UNKNOWN_COMPONENT</para>
        /// <para>MessageText: Component ID not registered.</para>
        /// </summary>
        UnknownComponent = 1607,

        /// <summary>
        /// <para>MessageId: ERROR_UNKNOWN_PROPERTY</para>
        /// <para>MessageText: Unknown property.</para>
        /// </summary>
        UnknownProperty = 1608,

        /// <summary>
        /// <para>MessageId: ERROR_INVALID_HANDLE_STATE</para>
        /// <para>MessageText: Handle is in an invalid state.</para>
        /// </summary>
        InvalidHandleState = 1609,

        /// <summary>
        /// <para>MessageId: ERROR_BAD_CONFIGURATION</para>
        /// <para>MessageText: The configuration data for this product is corrupt. Contact your support personnel.</para>
        /// </summary>
        BadConfiguration = 1610,

        /// <summary>
        /// <para>MessageId: ERROR_INDEX_ABSENT</para>
        /// <para>MessageText: Component qualifier not present.</para>
        /// </summary>
        IndexAbsent = 1611,

        /// <summary>
        /// <para>MessageId: ERROR_INSTALL_SOURCE_ABSENT</para>
        /// <para>MessageText: The installation source for this product is not available. Verify that the source exists and that you can access it.</para>
        /// </summary>
        InstallSourceAbsent = 1612,

        /// <summary>
        /// <para>MessageId: ERROR_INSTALL_PACKAGE_VERSION</para>
        /// <para>MessageText: This installation package cannot be installed by the Windows Installer service. You must install a Windows service pack that contains a newer version of the Windows Installer service.</para>
        /// </summary>
        InstallPackageVersion = 1613,

        /// <summary>
        /// <para>MessageId: ERROR_PRODUCT_UNINSTALLED</para>
        /// <para>MessageText: Product is uninstalled.</para>
        /// </summary>
        ProductUninstalled = 1614,

        /// <summary>
        /// <para>MessageId: ERROR_BAD_QUERY_SYNTAX</para>
        /// <para>MessageText: SQL query syntax invalid or unsupported.</para>
        /// </summary>
        BadQuerySyntax = 1615,

        /// <summary>
        /// <para>MessageId: ERROR_INVALID_FIELD</para>
        /// <para>MessageText: Record field does not exist.</para>
        /// </summary>
        InvalidField = 1616,

        /// <summary>
        /// <para>MessageId: ERROR_DEVICE_REMOVED</para>
        /// <para>MessageText: The device has been removed.</para>
        /// </summary>
        DeviceRemoved = 1617,

        /// <summary>
        /// <para>MessageId: ERROR_INSTALL_ALREADY_RUNNING</para>
        /// <para>MessageText: Another installation is already in progress. Complete that installation before proceeding with this install.</para>
        /// </summary>
        InstallAlreadyRunning = 1618,

        /// <summary>
        /// <para>MessageId: ERROR_INSTALL_PACKAGE_OPEN_FAILED</para>
        /// <para>MessageText: This installation package could not be opened. Verify that the package exists and that you can access it, or contact the application vendor to verify that this is a valid Windows Installer package.</para>
        /// </summary>
        InstallPackageOpenFailed = 1619,

        /// <summary>
        /// <para>MessageId: ERROR_INSTALL_PACKAGE_INVALID</para>
        /// <para>MessageText: This installation package could not be opened. Contact the application vendor to verify that this is a valid Windows Installer package.</para>
        /// </summary>
        InstallPackageInvalid = 1620,

        /// <summary>
        /// <para>MessageId: ERROR_INSTALL_UI_FAILURE</para>
        /// <para>MessageText: There was an error starting the Windows Installer service user interface. Contact your support personnel.</para>
        /// </summary>
        InstallUIFailure = 1621,

        /// <summary>
        /// <para>MessageId: ERROR_INSTALL_LOG_FAILURE</para>
        /// <para>MessageText: Error opening installation log file. Verify that the specified log file location exists and that you can write to it.</para>
        /// </summary>
        InstallLogFailure = 1622,

        /// <summary>
        /// <para>MessageId: ERROR_INSTALL_LANGUAGE_UNSUPPORTED</para>
        /// <para>MessageText: The language of this installation package is not supported by your system.</para>
        /// </summary>
        InstallLanguageUnsupported = 1623,

        /// <summary>
        /// <para>MessageId: ERROR_INSTALL_TRANSFORM_FAILURE</para>
        /// <para>MessageText: Error applying transforms. Verify that the specified transform paths are valid.</para>
        /// </summary>
        InstallTransformFailure = 1624,

        /// <summary>
        /// <para>MessageId: ERROR_INSTALL_PACKAGE_REJECTED</para>
        /// <para>MessageText: This installation is forbidden by system policy. Contact your system administrator.</para>
        /// </summary>
        InstallPackageRejected = 1625,

        /// <summary>
        /// <para>MessageId: ERROR_FUNCTION_NOT_CALLED</para>
        /// <para>MessageText: Function could not be executed.</para>
        /// </summary>
        FunctionNotCalled = 1626,

        /// <summary>
        /// <para>MessageId: ERROR_FUNCTION_FAILED</para>
        /// <para>MessageText: Function failed during execution.</para>
        /// </summary>
        FunctionFailed = 1627,

        /// <summary>
        /// <para>MessageId: ERROR_INVALID_TABLE</para>
        /// <para>MessageText: Invalid or unknown table specified.</para>
        /// </summary>
        InvalidTable = 1628,

        /// <summary>
        /// <para>MessageId: ERROR_DATATYPE_MISMATCH</para>
        /// <para>MessageText: Data supplied is of wrong type.</para>
        /// </summary>
        DataTypeMismatch = 1629,

        /// <summary>
        /// <para>MessageId: ERROR_UNSUPPORTED_TYPE</para>
        /// <para>MessageText: Data of this type is not supported.</para>
        /// </summary>
        UnsupportedType = 1630,

        /// <summary>
        /// <para>MessageId: ERROR_CREATE_FAILED</para>
        /// <para>MessageText: The Windows Installer service failed to start. Contact your support personnel.</para>
        /// </summary>
        CreateFailed = 1631,

        /// <summary>
        /// <para>MessageId: ERROR_INSTALL_TEMP_UNWRITABLE</para>
        /// <para>MessageText: The Temp folder is on a drive that is full or is inaccessible. Free up space on the drive or verify that you have write permission on the Temp folder.</para>
        /// </summary>
        InstallTempUnwritable = 1632,

        /// <summary>
        /// <para>MessageId: ERROR_INSTALL_PLATFORM_UNSUPPORTED</para>
        /// <para>MessageText: This installation package is not supported by this processor type. Contact your product vendor.</para>
        /// </summary>
        InstallPlatformUnsupported = 1633,

        /// <summary>
        /// <para>MessageId: ERROR_INSTALL_NOTUSED</para>
        /// <para>MessageText: Component not used on this computer.</para>
        /// </summary>
        InstallNotUsed = 1634,

        /// <summary>
        /// <para>MessageId: ERROR_PATCH_PACKAGE_OPEN_FAILED</para>
        /// <para>MessageText: This update package could not be opened. Verify that the update package exists and that you can access it, or contact the application vendor to verify that this is a valid Windows Installer update package.</para>
        /// </summary>
        PatchPackageOpenFailed = 1635,

        /// <summary>
        /// <para>MessageId: ERROR_PATCH_PACKAGE_INVALID</para>
        /// <para>MessageText: This update package could not be opened. Contact the application vendor to verify that this is a valid Windows Installer update package.</para>
        /// </summary>
        PatchPackageInvalid = 1636,

        /// <summary>
        /// <para>MessageId: ERROR_PATCH_PACKAGE_UNSUPPORTED</para>
        /// <para>MessageText: This update package cannot be processed by the Windows Installer service. You must install a Windows service pack that contains a newer version of the Windows Installer service.</para>
        /// </summary>
        PatchPackageUnsupported = 1637,

        /// <summary>
        /// <para>MessageId: ERROR_PRODUCT_VERSION</para>
        /// <para>MessageText: Another version of this product is already installed. Installation of this version cannot continue. To configure or remove the existing version of this product, use Add/Remove Programs on the Control Panel.</para>
        /// </summary>
        ProductVersion = 1638,

        /// <summary>
        /// <para>MessageId: ERROR_INVALID_COMMAND_LINE</para>
        /// <para>MessageText: Invalid command line argument. Consult the Windows Installer SDK for detailed command line help.</para>
        /// </summary>
        InvalidCommandLine = 1639,

        /// <summary>
        /// <para>MessageId: ERROR_INSTALL_REMOTE_DISALLOWED</para>
        /// <para>MessageText: Only administrators have permission to add, remove, or configure server software during a Terminal services remote session. If you want to install or configure software on the server, contact your network administrator.</para>
        /// </summary>
        InstallRemoteDisallowed = 1640,

        /// <summary>
        /// <para>MessageId: ERROR_SUCCESS_REBOOT_INITIATED</para>
        /// <para>MessageText: The requested operation completed successfully. The system will be restarted so the changes can take effect.</para>
        /// </summary>
        SuccessRebootInitiated = 1641,

        /// <summary>
        /// <para>MessageId: ERROR_PATCH_TARGET_NOT_FOUND</para>
        /// <para>MessageText: The upgrade cannot be installed by the Windows Installer service because the program to be upgraded may be missing, or the upgrade may update a different version of the program. Verify that the program to be upgraded exists on your computer and that you have the correct upgrade.</para>
        /// </summary>
        PatchTargetNotFound = 1642,

        /// <summary>
        /// <para>MessageId: ERROR_PATCH_PACKAGE_REJECTED</para>
        /// <para>MessageText: The update package is not permitted by software restriction policy.</para>
        /// </summary>
        PatchPackageRejected = 1643,

        /// <summary>
        /// <para>MessageId: ERROR_INSTALL_TRANSFORM_REJECTED</para>
        /// <para>MessageText: One or more customizations are not permitted by software restriction policy.</para>
        /// </summary>
        InstallTransformRejected = 1644,

        /// <summary>
        /// <para>MessageId: ERROR_INSTALL_REMOTE_PROHIBITED</para>
        /// <para>MessageText: The Windows Installer does not permit installation from a Remote Desktop Connection.</para>
        /// </summary>
        InstallRemoteProhibited = 1645,

        /// <summary>
        /// <para>MessageId: ERROR_PATCH_REMOVAL_UNSUPPORTED</para>
        /// <para>MessageText: Uninstallation of the update package is not supported.</para>
        /// </summary>
        PatchRemovalUnsupported = 1646,

        /// <summary>
        /// <para>MessageId: ERROR_UNKNOWN_PATCH</para>
        /// <para>MessageText: The update is not applied to this product.</para>
        /// </summary>
        UnknownPatch = 1647,

        /// <summary>
        /// <para>MessageId: ERROR_PATCH_NO_SEQUENCE</para>
        /// <para>MessageText: No valid sequence could be found for the set of updates.</para>
        /// </summary>
        PatchNoSequence = 1648,

        /// <summary>
        /// <para>MessageId: ERROR_PATCH_REMOVAL_DISALLOWED</para>
        /// <para>MessageText: Update removal was disallowed by policy.</para>
        /// </summary>
        PatchRemovalDisallowed = 1649,

        /// <summary>
        /// <para>MessageId: ERROR_INVALID_PATCH_XML</para>
        /// <para>MessageText: The XML update data is invalid.</para>
        /// </summary>
        InvalidPatchXML = 1650,

        /// <summary>
        /// <para>MessageId: ERROR_PATCH_MANAGED_ADVERTISED_PRODUCT</para>
        /// <para>MessageText: Windows Installer does not permit updating of managed advertised products. At least one feature of the product must be installed before applying the update.</para>
        /// </summary>
        PatchManagedAdvertisedProduct = 1651,

        /// <summary>
        /// <para>MessageId: ERROR_INSTALL_SERVICE_SAFEBOOT</para>
        /// <para>MessageText: The Windows Installer service is not accessible in Safe Mode. Please try again when your computer is not in Safe Mode or you can use System Restore to return your machine to a previous good state.</para>
        /// </summary>
        InstallServiceSafeBoot = 1652,

        /// <summary>
        /// <para>MessageId: ERROR_FAIL_FAST_EXCEPTION</para>
        /// <para>MessageText: A fail fast exception occurred. Exception handlers will not be invoked and the process will be terminated immediately.</para>
        /// </summary>
        FailFastException = 1653,

        /// <summary>
        /// <para>MessageId: ERROR_INSTALL_REJECTED</para>
        /// <para>MessageText: The app that you are trying to run is not supported on this version of Windows.</para>
        /// </summary>
        InstallRejected = 1654,

        /// <summary>
        /// <para>MessageId: ERROR_DYNAMIC_CODE_BLOCKED</para>
        /// <para>MessageText: The operation was blocked as the process prohibits dynamic code generation.</para>
        /// </summary>
        DynamicCodeBlocked = 1655,

        /// <summary>
        /// <para>MessageId: ERROR_NOT_SAME_OBJECT</para>
        /// <para>MessageText: The objects are not identical.</para>
        /// </summary>
        NotSameObject = 1656,

        /// <summary>
        /// <para>MessageId: ERROR_STRICT_CFG_VIOLATION</para>
        /// <para>MessageText: The specified image file was blocked from loading because it does not enable a feature required by the process: Control Flow Guard.</para>
        /// </summary>
        StrictCFGViolation = 1657,

        /// <summary>
        /// <para>MessageId: ERROR_SET_CONTEXT_DENIED</para>
        /// <para>MessageText: The thread context could not be updated because this has been restricted for the process.</para>
        /// </summary>
        SetContextDenied = 1660,

        /// <summary>
        /// <para>MessageId: ERROR_CROSS_PARTITION_VIOLATION</para>
        /// <para>MessageText: An invalid cross-partition private file/section access was attempted.</para>
        /// </summary>
        CrossPartitionViolation = 1661,



        /// <summary>
        /// <para>MessageId: RPC_S_INVALID_STRING_BINDING</para>
        /// <para>MessageText: The string binding is invalid.</para>
        /// </summary>
        RPCInvalidStringBinding = 1700,

        /// <summary>
        /// <para>MessageId: RPC_S_WRONG_KIND_OF_BINDING</para>
        /// <para>MessageText: The binding handle is not the correct type.</para>
        /// </summary>
        RPCWrongKindOfBinding = 1701,

        /// <summary>
        /// <para>MessageId: RPC_S_INVALID_BINDING</para>
        /// <para>MessageText: The binding handle is invalid.</para>
        /// </summary>
        RPCInvalidBinding = 1702,

        /// <summary>
        /// <para>MessageId: RPC_S_PROTSEQ_NOT_SUPPORTED</para>
        /// <para>MessageText: The RPC protocol sequence is not supported.</para>
        /// </summary>
        RPCProtSeqNotSupported = 1703,

        /// <summary>
        /// <para>MessageId: RPC_S_INVALID_RPC_PROTSEQ</para>
        /// <para>MessageText: The RPC protocol sequence is invalid.</para>
        /// </summary>
        RPCInvalidRPCProtSeq = 1704,

        /// <summary>
        /// <para>MessageId: RPC_S_INVALID_STRING_UUID</para>
        /// <para>MessageText: The string universal unique identifier (UUID) is invalid.</para>
        /// </summary>
        RPCInvalidStringUUID = 1705,

        /// <summary>
        /// <para>MessageId: RPC_S_INVALID_ENDPOINT_FORMAT</para>
        /// <para>MessageText: The endpoint format is invalid.</para>
        /// </summary>
        RPCInvalidEndpointFormat = 1706,

        /// <summary>
        /// <para>MessageId: RPC_S_INVALID_NET_ADDR</para>
        /// <para>MessageText: The network address is invalid.</para>
        /// </summary>
        RPCInvalidNetAddr = 1707,

        /// <summary>
        /// <para>MessageId: RPC_S_NO_ENDPOINT_FOUND</para>
        /// <para>MessageText: No endpoint was found.</para>
        /// </summary>
        RPCNoEndpointFound = 1708,

        /// <summary>
        /// <para>MessageId: RPC_S_INVALID_TIMEOUT</para>
        /// <para>MessageText: The timeout value is invalid.</para>
        /// </summary>
        RPCInvalidTimeout = 1709,

        /// <summary>
        /// <para>MessageId: RPC_S_OBJECT_NOT_FOUND</para>
        /// <para>MessageText: The object universal unique identifier (UUID) was not found.</para>
        /// </summary>
        RPCObjectNotFound = 1710,

        /// <summary>
        /// <para>MessageId: RPC_S_ALREADY_REGISTERED</para>
        /// <para>MessageText: The object universal unique identifier (UUID) has already been registered.</para>
        /// </summary>
        RPCAlreadyRegistered = 1711,

        /// <summary>
        /// <para>MessageId: RPC_S_TYPE_ALREADY_REGISTERED</para>
        /// <para>MessageText: The type universal unique identifier (UUID) has already been registered.</para>
        /// </summary>
        RPCTypeAlreadyRegistered = 1712,

        /// <summary>
        /// <para>MessageId: RPC_S_ALREADY_LISTENING</para>
        /// <para>MessageText: The RPC server is already listening.</para>
        /// </summary>
        RPCAlreadyListening = 1713,

        /// <summary>
        /// <para>MessageId: RPC_S_NO_PROTSEQS_REGISTERED</para>
        /// <para>MessageText: No protocol sequences have been registered.</para>
        /// </summary>
        RPCNoProtSeqsRegistered = 1714,

        /// <summary>
        /// <para>MessageId: RPC_S_NOT_LISTENING</para>
        /// <para>MessageText: The RPC server is not listening.</para>
        /// </summary>
        RPCNotListening = 1715,

        /// <summary>
        /// <para>MessageId: RPC_S_UNKNOWN_MGR_TYPE</para>
        /// <para>MessageText: The manager type is unknown.</para>
        /// </summary>
        RPCUnknownMgrType = 1716,

        /// <summary>
        /// <para>MessageId: RPC_S_UNKNOWN_IF</para>
        /// <para>MessageText: The interface is unknown.</para>
        /// </summary>
        RPCUnknownIf = 1717,

        /// <summary>
        /// <para>MessageId: RPC_S_NO_BINDINGS</para>
        /// <para>MessageText: There are no bindings.</para>
        /// </summary>
        RPCNoBindings = 1718,

        /// <summary>
        /// <para>MessageId: RPC_S_NO_PROTSEQS</para>
        /// <para>MessageText: There are no protocol sequences.</para>
        /// </summary>
        RPCNoProtSeqs = 1719,

        /// <summary>
        /// <para>MessageId: RPC_S_CANT_CREATE_ENDPOINT</para>
        /// <para>MessageText: The endpoint cannot be created.</para>
        /// </summary>
        RPCCantCreateEndpoint = 1720,

        /// <summary>
        /// <para>MessageId: RPC_S_OUT_OF_RESOURCES</para>
        /// <para>MessageText: Not enough resources are available to complete this operation.</para>
        /// </summary>
        RPCOutOfResources = 1721,

        /// <summary>
        /// <para>MessageId: RPC_S_SERVER_UNAVAILABLE</para>
        /// <para>MessageText: The RPC server is unavailable.</para>
        /// </summary>
        RPCServerUnavailable = 1722,

        /// <summary>
        /// <para>MessageId: RPC_S_SERVER_TOO_BUSY</para>
        /// <para>MessageText: The RPC server is too busy to complete this operation.</para>
        /// </summary>
        RPCServerTooBusy = 1723,

        /// <summary>
        /// <para>MessageId: RPC_S_INVALID_NETWORK_OPTIONS</para>
        /// <para>MessageText: The network options are invalid.</para>
        /// </summary>
        RPCInvalidNetworkOptions = 1724,

        /// <summary>
        /// <para>MessageId: RPC_S_NO_CALL_ACTIVE</para>
        /// <para>MessageText: There are no remote procedure calls active on this thread.</para>
        /// </summary>
        RPCNoCallActive = 1725,

        /// <summary>
        /// <para>MessageId: RPC_S_CALL_FAILED</para>
        /// <para>MessageText: The remote procedure call failed.</para>
        /// </summary>
        RPCCallFailed = 1726,

        /// <summary>
        /// <para>MessageId: RPC_S_CALL_FAILED_DNE</para>
        /// <para>MessageText: The remote procedure call failed and did not execute.</para>
        /// </summary>
        RPCCallFailedDNE = 1727,

        /// <summary>
        /// <para>MessageId: RPC_S_PROTOCOL_ERROR</para>
        /// <para>MessageText: A remote procedure call (RPC) protocol error occurred.</para>
        /// </summary>
        RPCProtocolError = 1728,

        /// <summary>
        /// <para>MessageId: RPC_S_PROXY_ACCESS_DENIED</para>
        /// <para>MessageText: Access to the HTTP proxy is denied.</para>
        /// </summary>
        RPCProxyAccessDenied = 1729,

        /// <summary>
        /// <para>MessageId: RPC_S_UNSUPPORTED_TRANS_SYN</para>
        /// <para>MessageText: The transfer syntax is not supported by the RPC server.</para>
        /// </summary>
        RPCUnsupportedTransSyn = 1730,

        /// <summary>
        /// <para>MessageId: RPC_S_UNSUPPORTED_TYPE</para>
        /// <para>MessageText: The universal unique identifier (UUID) type is not supported.</para>
        /// </summary>
        RPCUnsupportedType = 1732,

        /// <summary>
        /// <para>MessageId: RPC_S_INVALID_TAG</para>
        /// <para>MessageText: The tag is invalid.</para>
        /// </summary>
        RPCInvalidTag = 1733,

        /// <summary>
        /// <para>MessageId: RPC_S_INVALID_BOUND</para>
        /// <para>MessageText: The array bounds are invalid.</para>
        /// </summary>
        RPCInvalidBound = 1734,

        /// <summary>
        /// <para>MessageId: RPC_S_NO_ENTRY_NAME</para>
        /// <para>MessageText: The binding does not contain an entry name.</para>
        /// </summary>
        RPCNoEntryName = 1735,

        /// <summary>
        /// <para>MessageId: RPC_S_INVALID_NAME_SYNTAX</para>
        /// <para>MessageText: The name syntax is invalid.</para>
        /// </summary>
        RPCInvalidNameSyntax = 1736,

        /// <summary>
        /// <para>MessageId: RPC_S_UNSUPPORTED_NAME_SYNTAX</para>
        /// <para>MessageText: The name syntax is not supported.</para>
        /// </summary>
        RPCUnsupportedNameSyntax = 1737,

        /// <summary>
        /// <para>MessageId: RPC_S_UUID_NO_ADDRESS</para>
        /// <para>MessageText: No network address is available to use to construct a universal unique identifier (UUID).</para>
        /// </summary>
        RPCUUIDNoAddress = 1739,

        /// <summary>
        /// <para>MessageId: RPC_S_DUPLICATE_ENDPOINT</para>
        /// <para>MessageText: The endpoint is a duplicate.</para>
        /// </summary>
        RPCDuplicateEndpoint = 1740,

        /// <summary>
        /// <para>MessageId: RPC_S_UNKNOWN_AUTHN_TYPE</para>
        /// <para>MessageText: The authentication type is unknown.</para>
        /// </summary>
        RPCUnknownAuthnType = 1741,

        /// <summary>
        /// <para>MessageId: RPC_S_MAX_CALLS_TOO_SMALL</para>
        /// <para>MessageText: The maximum number of calls is too small.</para>
        /// </summary>
        RPCMaxCallsTooSmall = 1742,

        /// <summary>
        /// <para>MessageId: RPC_S_STRING_TOO_LONG</para>
        /// <para>MessageText: The string is too long.</para>
        /// </summary>
        RPCStringTooLong = 1743,

        /// <summary>
        /// <para>MessageId: RPC_S_PROTSEQ_NOT_FOUND</para>
        /// <para>MessageText: The RPC protocol sequence was not found.</para>
        /// </summary>
        RPCProtSeqNotFound = 1744,

        /// <summary>
        /// <para>MessageId: RPC_S_PROCNUM_OUT_OF_RANGE</para>
        /// <para>MessageText: The procedure number is out of range.</para>
        /// </summary>
        RPCProcNumOutOfRange = 1745,

        /// <summary>
        /// <para>MessageId: RPC_S_BINDING_HAS_NO_AUTH</para>
        /// <para>MessageText: The binding does not contain any authentication information.</para>
        /// </summary>
        RPCBindingHasNoAuth = 1746,

        /// <summary>
        /// <para>MessageId: RPC_S_UNKNOWN_AUTHN_SERVICE</para>
        /// <para>MessageText: The authentication service is unknown.</para>
        /// </summary>
        RPCUnknownAuthnService = 1747,

        /// <summary>
        /// <para>MessageId: RPC_S_UNKNOWN_AUTHN_LEVEL</para>
        /// <para>MessageText: The authentication level is unknown.</para>
        /// </summary>
        RPCUnknownAuthnLevel = 1748,

        /// <summary>
        /// <para>MessageId: RPC_S_INVALID_AUTH_IDENTITY</para>
        /// <para>MessageText: The security context is invalid.</para>
        /// </summary>
        RPCInvalidAuthIdentity = 1749,

        /// <summary>
        /// <para>MessageId: RPC_S_UNKNOWN_AUTHZ_SERVICE</para>
        /// <para>MessageText: The authorization service is unknown.</para>
        /// </summary>
        RPCUnknownAuthzService = 1750,

        /// <summary>
        /// <para>MessageId: EPT_S_INVALID_ENTRY</para>
        /// <para>MessageText: The entry is invalid.</para>
        /// </summary>
        EPTInvalidEntry = 1751,

        /// <summary>
        /// <para>MessageId: EPT_S_CANT_PERFORM_OP</para>
        /// <para>MessageText: The server endpoint cannot perform the operation.</para>
        /// </summary>
        EPTCantPerformOp = 1752,

        /// <summary>
        /// <para>MessageId: EPT_S_NOT_REGISTERED</para>
        /// <para>MessageText: There are no more endpoints available from the endpoint mapper.</para>
        /// </summary>
        EPTNotRegistered = 1753,

        /// <summary>
        /// <para>MessageId: RPC_S_NOTHING_TO_EXPORT</para>
        /// <para>MessageText: No interfaces have been exported.</para>
        /// </summary>
        RPCNothingToExport = 1754,

        /// <summary>
        /// <para>MessageId: RPC_S_INCOMPLETE_NAME</para>
        /// <para>MessageText: The entry name is incomplete.</para>
        /// </summary>
        RPCIncompleteName = 1755,

        /// <summary>
        /// <para>MessageId: RPC_S_INVALID_VERS_OPTION</para>
        /// <para>MessageText: The version option is invalid.</para>
        /// </summary>
        RPCInvalidVersOption = 1756,

        /// <summary>
        /// <para>MessageId: RPC_S_NO_MORE_MEMBERS</para>
        /// <para>MessageText: There are no more members.</para>
        /// </summary>
        RPCNoMoreMembers = 1757,

        /// <summary>
        /// <para>MessageId: RPC_S_NOT_ALL_OBJS_UNEXPORTED</para>
        /// <para>MessageText: There is nothing to unexport.</para>
        /// </summary>
        RPCNotAllObjsUnexported = 1758,

        /// <summary>
        /// <para>MessageId: RPC_S_INTERFACE_NOT_FOUND</para>
        /// <para>MessageText: The interface was not found.</para>
        /// </summary>
        RPCInterfaceNotFound = 1759,

        /// <summary>
        /// <para>MessageId: RPC_S_ENTRY_ALREADY_EXISTS</para>
        /// <para>MessageText: The entry already exists.</para>
        /// </summary>
        RPCEntryAlreadyExists = 1760,

        /// <summary>
        /// <para>MessageId: RPC_S_ENTRY_NOT_FOUND</para>
        /// <para>MessageText: The entry is not found.</para>
        /// </summary>
        RPCEntryNotFound = 1761,

        /// <summary>
        /// <para>MessageId: RPC_S_NAME_SERVICE_UNAVAILABLE</para>
        /// <para>MessageText: The name service is unavailable.</para>
        /// </summary>
        RPCNameServiceUnavailable = 1762,

        /// <summary>
        /// <para>MessageId: RPC_S_INVALID_NAF_ID</para>
        /// <para>MessageText: The network address family is invalid.</para>
        /// </summary>
        RPCInvalidNafId = 1763,

        /// <summary>
        /// <para>MessageId: RPC_S_CANNOT_SUPPORT</para>
        /// <para>MessageText: The requested operation is not supported.</para>
        /// </summary>
        RPCCannotSupport = 1764,

        /// <summary>
        /// <para>MessageId: RPC_S_NO_CONTEXT_AVAILABLE</para>
        /// <para>MessageText: No security context is available to allow impersonation.</para>
        /// </summary>
        RPCNoContextAvailable = 1765,

        /// <summary>
        /// <para>MessageId: RPC_S_INTERNAL_ERROR</para>
        /// <para>MessageText: An internal error occurred in a remote procedure call (RPC).</para>
        /// </summary>
        RPCInternalError = 1766,

        /// <summary>
        /// <para>MessageId: RPC_S_ZERO_DIVIDE</para>
        /// <para>MessageText: The RPC server attempted an integer division by zero.</para>
        /// </summary>
        RPCZeroDivide = 1767,

        /// <summary>
        /// <para>MessageId: RPC_S_ADDRESS_ERROR</para>
        /// <para>MessageText: An addressing error occurred in the RPC server.</para>
        /// </summary>
        RPCAddressError = 1768,

        /// <summary>
        /// <para>MessageId: RPC_S_FP_DIV_ZERO</para>
        /// <para>MessageText: A floating-point operation at the RPC server caused a division by zero.</para>
        /// </summary>
        RPCFPDivZero = 1769,

        /// <summary>
        /// <para>MessageId: RPC_S_FP_UNDERFLOW</para>
        /// <para>MessageText: A floating-point underflow occurred at the RPC server.</para>
        /// </summary>
        RPCFPUnderflow = 1770,

        /// <summary>
        /// <para>MessageId: RPC_S_FP_OVERFLOW</para>
        /// <para>MessageText: A floating-point overflow occurred at the RPC server.</para>
        /// </summary>
        RPCFPOverflow = 1771,

        /// <summary>
        /// <para>MessageId: RPC_X_NO_MORE_ENTRIES</para>
        /// <para>MessageText: The list of RPC servers available for the binding of auto handles has been exhausted.</para>
        /// </summary>
        RPCNoMoreEntries = 1772,

        /// <summary>
        /// <para>MessageId: RPC_X_SS_CHAR_TRANS_OPEN_FAIL</para>
        /// <para>MessageText: Unable to open the character translation table file.</para>
        /// </summary>
        RPCCharTransOpenFail = 1773,

        /// <summary>
        /// <para>MessageId: RPC_X_SS_CHAR_TRANS_SHORT_FILE</para>
        /// <para>MessageText: The file containing the character translation table has fewer than= 512 bytes.</para>
        /// </summary>
        RPCCharTransShortFile = 1774,

        /// <summary>
        /// <para>MessageId: RPC_X_SS_IN_NULL_CONTEXT</para>
        /// <para>MessageText: A null context handle was passed from the client to the host during a remote procedure call.</para>
        /// </summary>
        RPCInNullContext = 1775,

        /// <summary>
        /// <para>MessageId: RPC_X_SS_CONTEXT_DAMAGED</para>
        /// <para>MessageText: The context handle changed during a remote procedure call.</para>
        /// </summary>
        RPCContextDamaged = 1777,

        /// <summary>
        /// <para>MessageId: RPC_X_SS_HANDLES_MISMATCH</para>
        /// <para>MessageText: The binding handles passed to a remote procedure call do not match.</para>
        /// </summary>
        RPCHandlesMismatch = 1778,

        /// <summary>
        /// <para>MessageId: RPC_X_SS_CANNOT_GET_CALL_HANDLE</para>
        /// <para>MessageText: The stub is unable to get the remote procedure call handle.</para>
        /// </summary>
        RPCCannotGetCallHandle = 1779,

        /// <summary>
        /// <para>MessageId: RPC_X_NULL_REF_POINTER</para>
        /// <para>MessageText: A null reference pointer was passed to the stub.</para>
        /// </summary>
        RPCNullRefPointer = 1780,

        /// <summary>
        /// <para>MessageId: RPC_X_ENUM_VALUE_OUT_OF_RANGE</para>
        /// <para>MessageText: The enumeration value is out of range.</para>
        /// </summary>
        RPCEnumValueOutOfRange = 1781,

        /// <summary>
        /// <para>MessageId: RPC_X_BYTE_COUNT_TOO_SMALL</para>
        /// <para>MessageText: The byte count is too small.</para>
        /// </summary>
        RPCByteCountTooSmall = 1782,

        /// <summary>
        /// <para>MessageId: RPC_X_BAD_STUB_DATA</para>
        /// <para>MessageText: The stub received bad data.</para>
        /// </summary>
        RPCBadStubData = 1783,

        /// <summary>
        /// <para>MessageId: ERROR_INVALID_USER_BUFFER</para>
        /// <para>MessageText: The supplied user buffer is not valid for the requested operation.</para>
        /// </summary>
        InvalidUserBuffer = 1784,

        /// <summary>
        /// <para>MessageId: ERROR_UNRECOGNIZED_MEDIA</para>
        /// <para>MessageText: The disk media is not recognized. It may not be formatted.</para>
        /// </summary>
        UnrecognizedMedia = 1785,

        /// <summary>
        /// <para>MessageId: ERROR_NO_TRUST_LSA_SECRET</para>
        /// <para>MessageText: The workstation does not have a trust secret.</para>
        /// </summary>
        NoTrustLSASecret = 1786,

        /// <summary>
        /// <para>MessageId: ERROR_NO_TRUST_SAM_ACCOUNT</para>
        /// <para>MessageText: The security database on the server does not have a computer account for this workstation trust relationship.</para>
        /// </summary>
        NoTrustSAMAccount = 1787,

        /// <summary>
        /// <para>MessageId: ERROR_TRUSTED_DOMAIN_FAILURE</para>
        /// <para>MessageText: The trust relationship between the primary domain and the trusted domain failed.</para>
        /// </summary>
        TrustedDomainFailure = 1788,

        /// <summary>
        /// <para>MessageId: ERROR_TRUSTED_RELATIONSHIP_FAILURE</para>
        /// <para>MessageText: The trust relationship between this workstation and the primary domain failed.</para>
        /// </summary>
        TrustedRelationshipFailure = 1789,

        /// <summary>
        /// <para>MessageId: ERROR_TRUST_FAILURE</para>
        /// <para>MessageText: The network logon failed.</para>
        /// </summary>
        TrustFailure = 1790,

        /// <summary>
        /// <para>MessageId: RPC_S_CALL_IN_PROGRESS</para>
        /// <para>MessageText: A remote procedure call is already in progress for this thread.</para>
        /// </summary>
        RPCCallInProgress = 1791,

        /// <summary>
        /// <para>MessageId: ERROR_NETLOGON_NOT_STARTED</para>
        /// <para>MessageText: An attempt was made to logon, but the network logon service was not started.</para>
        /// </summary>
        NetLogonNotStarted = 1792,

        /// <summary>
        /// <para>MessageId: ERROR_ACCOUNT_EXPIRED</para>
        /// <para>MessageText: The user's account has expired.</para>
        /// </summary>
        AccountExpired = 1793,

        /// <summary>
        /// <para>MessageId: ERROR_REDIRECTOR_HAS_OPEN_HANDLES</para>
        /// <para>MessageText: The redirector is in use and cannot be unloaded.</para>
        /// </summary>
        RedirectorHasOpenHandles = 1794,

        /// <summary>
        /// <para>MessageId: ERROR_PRINTER_DRIVER_ALREADY_INSTALLED</para>
        /// <para>MessageText: The specified printer driver is already installed.</para>
        /// </summary>
        PrinterDriverAlreadyInstalled = 1795,

        /// <summary>
        /// <para>MessageId: ERROR_UNKNOWN_PORT</para>
        /// <para>MessageText: The specified port is unknown.</para>
        /// </summary>
        UnknownPort = 1796,

        /// <summary>
        /// <para>MessageId: ERROR_UNKNOWN_PRINTER_DRIVER</para>
        /// <para>MessageText: The printer driver is unknown.</para>
        /// </summary>
        UnknownPrinterDriver = 1797,

        /// <summary>
        /// <para>MessageId: ERROR_UNKNOWN_PRINTPROCESSOR</para>
        /// <para>MessageText: The print processor is unknown.</para>
        /// </summary>
        UnknownPrintProcessor = 1798,

        /// <summary>
        /// <para>MessageId: ERROR_INVALID_SEPARATOR_FILE</para>
        /// <para>MessageText: The specified separator file is invalid.</para>
        /// </summary>
        InvalidSeparatorFile = 1799,

        /// <summary>
        /// <para>MessageId: ERROR_INVALID_PRIORITY</para>
        /// <para>MessageText: The specified priority is invalid.</para>
        /// </summary>
        InvalidPriority = 1800,

        /// <summary>
        /// <para>MessageId: ERROR_INVALID_PRINTER_NAME</para>
        /// <para>MessageText: The printer name is invalid.</para>
        /// </summary>
        InvalidPrinterName = 1801,

        /// <summary>
        /// <para>MessageId: ERROR_PRINTER_ALREADY_EXISTS</para>
        /// <para>MessageText: The printer already exists.</para>
        /// </summary>
        PrinterAlreadyExists = 1802,

        /// <summary>
        /// <para>MessageId: ERROR_INVALID_PRINTER_COMMAND</para>
        /// <para>MessageText: The printer command is invalid.</para>
        /// </summary>
        InvalidPrinterCommand = 1803,

        /// <summary>
        /// <para>MessageId: ERROR_INVALID_DATATYPE</para>
        /// <para>MessageText: The specified datatype is invalid.</para>
        /// </summary>
        InvalidDataType = 1804,

        /// <summary>
        /// <para>MessageId: ERROR_INVALID_ENVIRONMENT</para>
        /// <para>MessageText: The environment specified is invalid.</para>
        /// </summary>
        InvalidEnvironment = 1805,

        /// <summary>
        /// <para>MessageId: RPC_S_NO_MORE_BINDINGS</para>
        /// <para>MessageText: There are no more bindings.</para>
        /// </summary>
        RPCNoMoreBindings = 1806,

        /// <summary>
        /// <para>MessageId: ERROR_NOLOGON_INTERDOMAIN_TRUST_ACCOUNT</para>
        /// <para>MessageText: The account used is an interdomain trust account. Use your global user account or local user account to access this server.</para>
        /// </summary>
        NoLogonInterDomainTrustAccount = 1807,

        /// <summary>
        /// <para>MessageId: ERROR_NOLOGON_WORKSTATION_TRUST_ACCOUNT</para>
        /// <para>MessageText: The account used is a computer account. Use your global user account or local user account to access this server.</para>
        /// </summary>
        NoLogonWorkstationTrustAccount = 1808,

        /// <summary>
        /// <para>MessageId: ERROR_NOLOGON_SERVER_TRUST_ACCOUNT</para>
        /// <para>MessageText: The account used is a server trust account. Use your global user account or local user account to access this server.</para>
        /// </summary>
        NoLogonServerTrustAccount = 1809,

        /// <summary>
        /// <para>MessageId: ERROR_DOMAIN_TRUST_INCONSISTENT</para>
        /// <para>MessageText: The name or security ID (SID) of the domain specified is inconsistent with the trust information for that domain.</para>
        /// </summary>
        DomainTrustInconsistent = 1810,

        /// <summary>
        /// <para>MessageId: ERROR_SERVER_HAS_OPEN_HANDLES</para>
        /// <para>MessageText: The server is in use and cannot be unloaded.</para>
        /// </summary>
        ServerHasOpenHandles = 1811,

        /// <summary>
        /// <para>MessageId: ERROR_RESOURCE_DATA_NOT_FOUND</para>
        /// <para>MessageText: The specified image file did not contain a resource section.</para>
        /// </summary>
        ResourceDataNotFound = 1812,

        /// <summary>
        /// <para>MessageId: ERROR_RESOURCE_TYPE_NOT_FOUND</para>
        /// <para>MessageText: The specified resource type cannot be found in the image file.</para>
        /// </summary>
        ResourceTypeNotFound = 1813,

        /// <summary>
        /// <para>MessageId: ERROR_RESOURCE_NAME_NOT_FOUND</para>
        /// <para>MessageText: The specified resource name cannot be found in the image file.</para>
        /// </summary>
        ResourceNameNotFound = 1814,

        /// <summary>
        /// <para>MessageId: ERROR_RESOURCE_LANG_NOT_FOUND</para>
        /// <para>MessageText: The specified resource language ID cannot be found in the image file.</para>
        /// </summary>
        ResourceLangNotFound = 1815,

        /// <summary>
        /// <para>MessageId: ERROR_NOT_ENOUGH_QUOTA</para>
        /// <para>MessageText: Not enough quota is available to process this command.</para>
        /// </summary>
        NotEnoughQuota = 1816,

        /// <summary>
        /// <para>MessageId: RPC_S_NO_INTERFACES</para>
        /// <para>MessageText: No interfaces have been registered.</para>
        /// </summary>
        RPCNoInterfaces = 1817,

        /// <summary>
        /// <para>MessageId: RPC_S_CALL_CANCELLED</para>
        /// <para>MessageText: The remote procedure call was cancelled.</para>
        /// </summary>
        RPCCallCancelled = 1818,

        /// <summary>
        /// <para>MessageId: RPC_S_BINDING_INCOMPLETE</para>
        /// <para>MessageText: The binding handle does not contain all required information.</para>
        /// </summary>
        RPCBindingIncomplete = 1819,

        /// <summary>
        /// <para>MessageId: RPC_S_COMM_FAILURE</para>
        /// <para>MessageText: A communications failure occurred during a remote procedure call.</para>
        /// </summary>
        RPCCommFailure = 1820,

        /// <summary>
        /// <para>MessageId: RPC_S_UNSUPPORTED_AUTHN_LEVEL</para>
        /// <para>MessageText: The requested authentication level is not supported.</para>
        /// </summary>
        RPCUnsupportedAuthnLevel = 1821,

        /// <summary>
        /// <para>MessageId: RPC_S_NO_PRINC_NAME</para>
        /// <para>MessageText: No principal name registered.</para>
        /// </summary>
        RPCNoPrincName = 1822,

        /// <summary>
        /// <para>MessageId: RPC_S_NOT_RPC_ERROR</para>
        /// <para>MessageText: The error specified is not a valid Windows RPC error code.</para>
        /// </summary>
        RPCNotRPCError = 1823,

        /// <summary>
        /// <para>MessageId: RPC_S_UUID_LOCAL_ONLY</para>
        /// <para>MessageText: A UUID that is valid only on this computer has been allocated.</para>
        /// </summary>
        RPCUUIDLocalOnly = 1824,

        /// <summary>
        /// <para>MessageId: RPC_S_SEC_PKG_ERROR</para>
        /// <para>MessageText: A security package specific error occurred.</para>
        /// </summary>
        RPCSecPKGError = 1825,

        /// <summary>
        /// <para>MessageId: RPC_S_NOT_CANCELLED</para>
        /// <para>MessageText: Thread is not canceled.</para>
        /// </summary>
        RPCNotCancelled = 1826,

        /// <summary>
        /// <para>MessageId: RPC_X_INVALID_ES_ACTION</para>
        /// <para>MessageText: Invalid operation on the encoding/decoding handle.</para>
        /// </summary>
        RPCInvalidESAction = 1827,

        /// <summary>
        /// <para>MessageId: RPC_X_WRONG_ES_VERSION</para>
        /// <para>MessageText: Incompatible version of the serializing package.</para>
        /// </summary>
        RPCWrongESVersion = 1828,

        /// <summary>
        /// <para>MessageId: RPC_X_WRONG_STUB_VERSION</para>
        /// <para>MessageText: Incompatible version of the RPC stub.</para>
        /// </summary>
        RPCWrongStubVersion = 1829,

        /// <summary>
        /// <para>MessageId: RPC_X_INVALID_PIPE_OBJECT</para>
        /// <para>MessageText: The RPC pipe object is invalid or corrupted.</para>
        /// </summary>
        RPCInvalidPipeObject = 1830,

        /// <summary>
        /// <para>MessageId: RPC_X_WRONG_PIPE_ORDER</para>
        /// <para>MessageText: An invalid operation was attempted on an RPC pipe object.</para>
        /// </summary>
        RPCWrongPipeOrder = 1831,

        /// <summary>
        /// <para>MessageId: RPC_X_WRONG_PIPE_VERSION</para>
        /// <para>MessageText: Unsupported RPC pipe version.</para>
        /// </summary>
        RPCWrongPipeVersion = 1832,

        /// <summary>
        /// <para>MessageId: RPC_S_COOKIE_AUTH_FAILED</para>
        /// <para>MessageText: HTTP proxy server rejected the connection because the cookie authentication failed.</para>
        /// </summary>
        RPCCookieAuthFailed = 1833,

        /// <summary>
        /// <para>MessageId: RPC_S_DO_NOT_DISTURB</para>
        /// <para>MessageText: The RPC server is suspended, and could not be resumed for this request. The call did not execute.</para>
        /// </summary>
        RPCDoNotDisturb = 1834,

        /// <summary>
        /// <para>MessageId: RPC_S_SYSTEM_HANDLE_COUNT_EXCEEDED</para>
        /// <para>MessageText: The RPC call contains too many handles to be transmitted in a single request.</para>
        /// </summary>
        RPCSystemHandleCountExceeded = 1835,

        /// <summary>
        /// <para>MessageId: RPC_S_SYSTEM_HANDLE_TYPE_MISMATCH</para>
        /// <para>MessageText: The RPC call contains a handle that differs from the declared handle type.</para>
        /// </summary>
        RPCSystemHandleTypeMismatch = 1836,

        /// <summary>
        /// <para>MessageId: RPC_S_GROUP_MEMBER_NOT_FOUND</para>
        /// <para>MessageText: The group member was not found.</para>
        /// </summary>
        RPCGroupMemberNotFound = 1898,

        /// <summary>
        /// <para>MessageId: EPT_S_CANT_CREATE</para>
        /// <para>MessageText: The endpoint mapper database entry could not be created.</para>
        /// </summary>
        EPTCantCreate = 1899,

        /// <summary>
        /// <para>MessageId: RPC_S_INVALID_OBJECT</para>
        /// <para>MessageText: The object universal unique identifier (UUID) is the nil UUID.</para>
        /// </summary>
        RPCInvalidObject = 1900,

        /// <summary>
        /// <para>MessageId: ERROR_INVALID_TIME</para>
        /// <para>MessageText: The specified time is invalid.</para>
        /// </summary>
        InvalidTime = 1901,

        /// <summary>
        /// <para>MessageId: ERROR_INVALID_FORM_NAME</para>
        /// <para>MessageText: The specified form name is invalid.</para>
        /// </summary>
        InvalidFormName = 1902,

        /// <summary>
        /// <para>MessageId: ERROR_INVALID_FORM_SIZE</para>
        /// <para>MessageText: The specified form size is invalid.</para>
        /// </summary>
        InvalidFormSize = 1903,

        /// <summary>
        /// <para>MessageId: ERROR_ALREADY_WAITING</para>
        /// <para>MessageText: The specified printer handle is already being waited on</para>
        /// </summary>
        AlreadyWaiting = 1904,

        /// <summary>
        /// <para>MessageId: ERROR_PRINTER_DELETED</para>
        /// <para>MessageText: The specified printer has been deleted.</para>
        /// </summary>
        PrinterDeleted = 1905,

        /// <summary>
        /// <para>MessageId: ERROR_INVALID_PRINTER_STATE</para>
        /// <para>MessageText: The state of the printer is invalid.</para>
        /// </summary>
        InvalidPrinterState = 1906,

        /// <summary>
        /// <para>MessageId: ERROR_PASSWORD_MUST_CHANGE</para>
        /// <para>MessageText: The user's password must be changed before signing in.</para>
        /// </summary>
        PasswordMustChange = 1907,

        /// <summary>
        /// <para>MessageId: ERROR_DOMAIN_CONTROLLER_NOT_FOUND</para>
        /// <para>MessageText: Could not find the domain controller for this domain.</para>
        /// </summary>
        DomainControllerNotFound = 1908,

        /// <summary>
        /// <para>MessageId: ERROR_ACCOUNT_LOCKED_OUT</para>
        /// <para>MessageText: The referenced account is currently locked out and may not be logged on to.</para>
        /// </summary>
        AccountLockedOut = 1909,

        /// <summary>
        /// <para>MessageId: OR_INVALID_OXID</para>
        /// <para>MessageText: The object exporter specified was not found.</para>
        /// </summary>
        ORInvalidOxid = 1910,

        /// <summary>
        /// <para>MessageId: OR_INVALID_OID</para>
        /// <para>MessageText: The object specified was not found.</para>
        /// </summary>
        ORInvalidOID = 1911,

        /// <summary>
        /// <para>MessageId: OR_INVALID_SET</para>
        /// <para>MessageText: The object resolver set specified was not found.</para>
        /// </summary>
        ORInvalidSet = 1912,

        /// <summary>
        /// <para>MessageId: RPC_S_SEND_INCOMPLETE</para>
        /// <para>MessageText: Some data remains to be sent in the request buffer.</para>
        /// </summary>
        RPCSendIncomplete = 1913,

        /// <summary>
        /// <para>MessageId: RPC_S_INVALID_ASYNC_HANDLE</para>
        /// <para>MessageText: Invalid asynchronous remote procedure call handle.</para>
        /// </summary>
        RPCInvalidAsyncHandle = 1914,

        /// <summary>
        /// <para>MessageId: RPC_S_INVALID_ASYNC_CALL</para>
        /// <para>MessageText: Invalid asynchronous RPC call handle for this operation.</para>
        /// </summary>
        RPCInvalidAsyncCall = 1915,

        /// <summary>
        /// <para>MessageId: RPC_X_PIPE_CLOSED</para>
        /// <para>MessageText: The RPC pipe object has already been closed.</para>
        /// </summary>
        RPCPipeClosed = 1916,

        /// <summary>
        /// <para>MessageId: RPC_X_PIPE_DISCIPLINE_ERROR</para>
        /// <para>MessageText: The RPC call completed before all pipes were processed.</para>
        /// </summary>
        RPCPipeDisciplineError = 1917,

        /// <summary>
        /// <para>MessageId: RPC_X_PIPE_EMPTY</para>
        /// <para>MessageText: No more data is available from the RPC pipe.</para>
        /// </summary>
        RPCPipeEmpty = 1918,

        /// <summary>
        /// <para>MessageId: ERROR_NO_SITENAME</para>
        /// <para>MessageText: No site name is available for this machine.</para>
        /// </summary>
        NoSiteName = 1919,

        /// <summary>
        /// <para>MessageId: ERROR_CANT_ACCESS_FILE</para>
        /// <para>MessageText: The file cannot be accessed by the system.</para>
        /// </summary>
        CantAccessFile = 1920,

        /// <summary>
        /// <para>MessageId: ERROR_CANT_RESOLVE_FILENAME</para>
        /// <para>MessageText: The name of the file cannot be resolved by the system.</para>
        /// </summary>
        CantResolveFileName = 1921,

        /// <summary>
        /// <para>MessageId: RPC_S_ENTRY_TYPE_MISMATCH</para>
        /// <para>MessageText: The entry is not of the expected type.</para>
        /// </summary>
        RPCEntryTypeMismatch = 1922,

        /// <summary>
        /// <para>MessageId: RPC_S_NOT_ALL_OBJS_EXPORTED</para>
        /// <para>MessageText: Not all object UUIDs could be exported to the specified entry.</para>
        /// </summary>
        RPCNotAllObjsExported = 1923,

        /// <summary>
        /// <para>MessageId: RPC_S_INTERFACE_NOT_EXPORTED</para>
        /// <para>MessageText: Interface could not be exported to the specified entry.</para>
        /// </summary>
        RPCInterfaceNotExported = 1924,

        /// <summary>
        /// <para>MessageId: RPC_S_PROFILE_NOT_ADDED</para>
        /// <para>MessageText: The specified profile entry could not be added.</para>
        /// </summary>
        RPCProfileNotAdded = 1925,

        /// <summary>
        /// <para>MessageId: RPC_S_PRF_ELT_NOT_ADDED</para>
        /// <para>MessageText: The specified profile element could not be added.</para>
        /// </summary>
        RPCPrfEltNotAdded = 1926,

        /// <summary>
        /// <para>MessageId: RPC_S_PRF_ELT_NOT_REMOVED</para>
        /// <para>MessageText: The specified profile element could not be removed.</para>
        /// </summary>
        RPCPrfEltNotRemoved = 1927,

        /// <summary>
        /// <para>MessageId: RPC_S_GRP_ELT_NOT_ADDED</para>
        /// <para>MessageText: The group element could not be added.</para>
        /// </summary>
        RPCGrpEltNotAdded = 1928,

        /// <summary>
        /// <para>MessageId: RPC_S_GRP_ELT_NOT_REMOVED</para>
        /// <para>MessageText: The group element could not be removed.</para>
        /// </summary>
        RPCGrpEltNotRemoved = 1929,

        /// <summary>
        /// <para>MessageId: ERROR_KM_DRIVER_BLOCKED</para>
        /// <para>MessageText: The printer driver is not compatible with a policy enabled on your computer that blocks NT 4.0 drivers.</para>
        /// </summary>
        KMDriverBlocked = 1930,

        /// <summary>
        /// <para>MessageId: ERROR_CONTEXT_EXPIRED</para>
        /// <para>MessageText: The context has expired and can no longer be used.</para>
        /// </summary>
        ContextExpired = 1931,

        /// <summary>
        /// <para>MessageId: ERROR_PER_USER_TRUST_QUOTA_EXCEEDED</para>
        /// <para>MessageText: The current user's delegated trust creation quota has been exceeded.</para>
        /// </summary>
        PerUserTrustQuotaExceeded = 1932,

        /// <summary>
        /// <para>MessageId: ERROR_ALL_USER_TRUST_QUOTA_EXCEEDED</para>
        /// <para>MessageText: The total delegated trust creation quota has been exceeded.</para>
        /// </summary>
        AllUserTrustQuotaExceeded = 1933,

        /// <summary>
        /// <para>MessageId: ERROR_USER_DELETE_TRUST_QUOTA_EXCEEDED</para>
        /// <para>MessageText: The current user's delegated trust deletion quota has been exceeded.</para>
        /// </summary>
        UserDeleteTrustQuotaExceeded = 1934,

        /// <summary>
        /// <para>MessageId: ERROR_AUTHENTICATION_FIREWALL_FAILED</para>
        /// <para>MessageText: The computer you are signing into is protected by an authentication firewall. The specified account is not allowed to authenticate to the computer.</para>
        /// </summary>
        AuthenticationFirewallFailed = 1935,

        /// <summary>
        /// <para>MessageId: ERROR_REMOTE_PRINT_CONNECTIONS_BLOCKED</para>
        /// <para>MessageText: Remote connections to the Print Spooler are blocked by a policy set on your machine.</para>
        /// </summary>
        RemotePrintConnectionsBlocked = 1936,

        /// <summary>
        /// <para>MessageId: ERROR_NTLM_BLOCKED</para>
        /// <para>MessageText: Authentication failed because NTLM authentication has been disabled.</para>
        /// </summary>
        NTLMBlocked = 1937,

        /// <summary>
        /// <para>MessageId: ERROR_PASSWORD_CHANGE_REQUIRED</para>
        /// <para>MessageText: Logon Failure: EAS policy requires that the user change their password before this operation can be performed.</para>
        /// </summary>
        PasswordChangeRequired = 1938,

        /// <summary>
        /// <para>MessageId: ERROR_LOST_MODE_LOGON_RESTRICTION</para>
        /// <para>MessageText: An administrator has restricted sign in. To sign in, make sure your device is connected to the Internet, and have your administrator sign in first.</para>
        /// </summary>
        LostModeLogonRestriction = 1939,



        /// <summary>
        /// <para>MessageId: ERROR_INVALID_PIXEL_FORMAT</para>
        /// <para>MessageText: The pixel format is invalid.</para>
        /// </summary>
        InvalidPixelFormat = 2000,

        /// <summary>
        /// <para>MessageId: ERROR_BAD_DRIVER</para>
        /// <para>MessageText: The specified driver is invalid.</para>
        /// </summary>
        BadDriver = 2001,

        /// <summary>
        /// <para>MessageId: ERROR_INVALID_WINDOW_STYLE</para>
        /// <para>MessageText: The window style or class attribute is invalid for this operation.</para>
        /// </summary>
        InvalidWindowStyle = 2002,

        /// <summary>
        /// <para>MessageId: ERROR_METAFILE_NOT_SUPPORTED</para>
        /// <para>MessageText: The requested metafile operation is not supported.</para>
        /// </summary>
        MetafileNotSupported = 2003,

        /// <summary>
        /// <para>MessageId: ERROR_TRANSFORM_NOT_SUPPORTED</para>
        /// <para>MessageText: The requested transformation operation is not supported.</para>
        /// </summary>
        TransformNotSupported = 2004,

        /// <summary>
        /// <para>MessageId: ERROR_CLIPPING_NOT_SUPPORTED</para>
        /// <para>MessageText: The requested clipping operation is not supported.</para>
        /// </summary>
        ClippingNotSupported = 2005,



        /// <summary>
        /// <para>MessageId: ERROR_INVALID_CMM</para>
        /// <para>MessageText: The specified color management module is invalid.</para>
        /// </summary>
        InvalidCMM = 2010,

        /// <summary>
        /// <para>MessageId: ERROR_INVALID_PROFILE</para>
        /// <para>MessageText: The specified color profile is invalid.</para>
        /// </summary>
        InvalidProfile = 2011,

        /// <summary>
        /// <para>MessageId: ERROR_TAG_NOT_FOUND</para>
        /// <para>MessageText: The specified tag was not found.</para>
        /// </summary>
        TagNotFound = 2012,

        /// <summary>
        /// <para>MessageId: ERROR_TAG_NOT_PRESENT</para>
        /// <para>MessageText: A required tag is not present.</para>
        /// </summary>
        TagNotPresent = 2013,

        /// <summary>
        /// <para>MessageId: ERROR_DUPLICATE_TAG</para>
        /// <para>MessageText: The specified tag is already present.</para>
        /// </summary>
        DuplicateTag = 2014,

        /// <summary>
        /// <para>MessageId: ERROR_PROFILE_NOT_ASSOCIATED_WITH_DEVICE</para>
        /// <para>MessageText: The specified color profile is not associated with the specified device.</para>
        /// </summary>
        ProfileNotAssociatedWithDevice = 2015,

        /// <summary>
        /// <para>MessageId: ERROR_PROFILE_NOT_FOUND</para>
        /// <para>MessageText: The specified color profile was not found.</para>
        /// </summary>
        ProfileNotFound = 2016,

        /// <summary>
        /// <para>MessageId: ERROR_INVALID_COLORSPACE</para>
        /// <para>MessageText: The specified color space is invalid.</para>
        /// </summary>
        InvalidColorSpace = 2017,

        /// <summary>
        /// <para>MessageId: ERROR_ICM_NOT_ENABLED</para>
        /// <para>MessageText: Image Color Management is not enabled.</para>
        /// </summary>
        ICMNotEnabled = 2018,

        /// <summary>
        /// <para>MessageId: ERROR_DELETING_ICM_XFORM</para>
        /// <para>MessageText: There was an error while deleting the color transform.</para>
        /// </summary>
        DeletingICMXForm = 2019,

        /// <summary>
        /// <para>MessageId: ERROR_INVALID_TRANSFORM</para>
        /// <para>MessageText: The specified color transform is invalid.</para>
        /// </summary>
        InvalidTransform = 2020,

        /// <summary>
        /// <para>MessageId: ERROR_COLORSPACE_MISMATCH</para>
        /// <para>MessageText: The specified transform does not match the bitmap's color space.</para>
        /// </summary>
        ColorspaceMismatch = 2021,

        /// <summary>
        /// <para>MessageId: ERROR_INVALID_COLORINDEX</para>
        /// <para>MessageText: The specified named color index is not present in the profile.</para>
        /// </summary>
        InvalidColorIndex = 2022,

        /// <summary>
        /// <para>MessageId: ERROR_PROFILE_DOES_NOT_MATCH_DEVICE</para>
        /// <para>MessageText: The specified profile is intended for a device of a different type than the specified device.</para>
        /// </summary>
        ProfileDoesNotMatchDevice = 2023,



        /// <summary>
        /// <para>MessageId: ERROR_CONNECTED_OTHER_PASSWORD</para>
        /// <para>MessageText: The network connection was made successfully, but the user had to be prompted for a password other than the one originally specified.</para>
        /// </summary>
        ConnectedOtherPassword = 2108,

        /// <summary>
        /// <para>MessageId: ERROR_CONNECTED_OTHER_PASSWORD_DEFAULT</para>
        /// <para>MessageText: The network connection was made successfully using default credentials.</para>
        /// </summary>
        ConnectedOtherPasswordDefault = 2109,

        /// <summary>
        /// <para>MessageId: ERROR_BAD_USERNAME</para>
        /// <para>MessageText: The specified username is invalid.</para>
        /// </summary>
        BadUserName = 2202,

        /// <summary>
        /// <para>MessageId: ERROR_NOT_CONNECTED</para>
        /// <para>MessageText: This network connection does not exist.</para>
        /// </summary>
        NotConnected = 2250,

        /// <summary>
        /// <para>MessageId: ERROR_OPEN_FILES</para>
        /// <para>MessageText: This network connection has files open or requests pending.</para>
        /// </summary>
        OpenFiles = 2401,

        /// <summary>
        /// <para>MessageId: ERROR_ACTIVE_CONNECTIONS</para>
        /// <para>MessageText: Active connections still exist.</para>
        /// </summary>
        ActiveConnections = 2402,

        /// <summary>
        /// <para>MessageId: ERROR_DEVICE_IN_USE</para>
        /// <para>MessageText: The device is in use by an active process and cannot be disconnected.</para>
        /// </summary>
        DeviceInUse = 2404,



        /// <summary>
        /// <para>MessageId: ERROR_UNKNOWN_PRINT_MONITOR</para>
        /// <para>MessageText: The specified print monitor is unknown.</para>
        /// </summary>
        UnknownPrintMonitor = 3000,

        /// <summary>
        /// <para>MessageId: ERROR_PRINTER_DRIVER_IN_USE</para>
        /// <para>MessageText: The specified printer driver is currently in use.</para>
        /// </summary>
        PrinterDriverInUse = 3001,

        /// <summary>
        /// <para>MessageId: ERROR_SPOOL_FILE_NOT_FOUND</para>
        /// <para>MessageText: The spool file was not found.</para>
        /// </summary>
        SpoolFileNotFound = 3002,

        /// <summary>
        /// <para>MessageId: ERROR_SPL_NO_STARTDOC</para>
        /// <para>MessageText: A StartDocPrinter call was not issued.</para>
        /// </summary>
        SPLNoStartDoc = 3003,

        /// <summary>
        /// <para>MessageId: ERROR_SPL_NO_ADDJOB</para>
        /// <para>MessageText: An AddJob call was not issued.</para>
        /// </summary>
        SPLNoAddJob = 3004,

        /// <summary>
        /// <para>MessageId: ERROR_PRINT_PROCESSOR_ALREADY_INSTALLED</para>
        /// <para>MessageText: The specified print processor has already been installed.</para>
        /// </summary>
        PrintProcessorAlreadyInstalled = 3005,

        /// <summary>
        /// <para>MessageId: ERROR_PRINT_MONITOR_ALREADY_INSTALLED</para>
        /// <para>MessageText: The specified print monitor has already been installed.</para>
        /// </summary>
        PrintMonitorAlreadyInstalled = 3006,

        /// <summary>
        /// <para>MessageId: ERROR_INVALID_PRINT_MONITOR</para>
        /// <para>MessageText: The specified print monitor does not have the required functions.</para>
        /// </summary>
        InvalidPrintMonitor = 3007,

        /// <summary>
        /// <para>MessageId: ERROR_PRINT_MONITOR_IN_USE</para>
        /// <para>MessageText: The specified print monitor is currently in use.</para>
        /// </summary>
        PrintMonitorInUse = 3008,

        /// <summary>
        /// <para>MessageId: ERROR_PRINTER_HAS_JOBS_QUEUED</para>
        /// <para>MessageText: The requested operation is not allowed when there are jobs queued to the printer.</para>
        /// </summary>
        PrinterHasJobsQueued = 3009,

        /// <summary>
        /// <para>MessageId: ERROR_SUCCESS_REBOOT_REQUIRED</para>
        /// <para>MessageText: The requested operation is successful. Changes will not be effective until the system is rebooted.</para>
        /// </summary>
        SuccessRebootRequired = 3010,

        /// <summary>
        /// <para>MessageId: ERROR_SUCCESS_RESTART_REQUIRED</para>
        /// <para>MessageText: The requested operation is successful. Changes will not be effective until the service is restarted.</para>
        /// </summary>
        SuccessRestartRequired = 3011,

        /// <summary>
        /// <para>MessageId: ERROR_PRINTER_NOT_FOUND</para>
        /// <para>MessageText: No printers were found.</para>
        /// </summary>
        PrinterNotFound = 3012,

        /// <summary>
        /// <para>MessageId: ERROR_PRINTER_DRIVER_WARNED</para>
        /// <para>MessageText: The printer driver is known to be unreliable.</para>
        /// </summary>
        PrinterDriverWarned = 3013,

        /// <summary>
        /// <para>MessageId: ERROR_PRINTER_DRIVER_BLOCKED</para>
        /// <para>MessageText: The printer driver is known to harm the system.</para>
        /// </summary>
        PrinterDriverBlocked = 3014,

        /// <summary>
        /// <para>MessageId: ERROR_PRINTER_DRIVER_PACKAGE_IN_USE</para>
        /// <para>MessageText: The specified printer driver package is currently in use.</para>
        /// </summary>
        PrinterDriverPackageInUse = 3015,

        /// <summary>
        /// <para>MessageId: ERROR_CORE_DRIVER_PACKAGE_NOT_FOUND</para>
        /// <para>MessageText: Unable to find a core driver package that is required by the printer driver package.</para>
        /// </summary>
        CoreDriverPackageNotFound = 3016,

        /// <summary>
        /// <para>MessageId: ERROR_FAIL_REBOOT_REQUIRED</para>
        /// <para>MessageText: The requested operation failed. A system reboot is required to roll back changes made.</para>
        /// </summary>
        FailRebootRequired = 3017,

        /// <summary>
        /// <para>MessageId: ERROR_FAIL_REBOOT_INITIATED</para>
        /// <para>MessageText: The requested operation failed. A system reboot has been initiated to roll back changes made.</para>
        /// </summary>
        FailRebootInitiated = 3018,

        /// <summary>
        /// <para>MessageId: ERROR_PRINTER_DRIVER_DOWNLOAD_NEEDED</para>
        /// <para>MessageText: The specified printer driver was not found on the system and needs to be downloaded.</para>
        /// </summary>
        PrinterDriverDownloadNeeded = 3019,

        /// <summary>
        /// <para>MessageId: ERROR_PRINT_JOB_RESTART_REQUIRED</para>
        /// <para>MessageText: The requested print job has failed to print. A print system update requires the job to be resubmitted.</para>
        /// </summary>
        PrintJobRestartRequired = 3020,

        /// <summary>
        /// <para>MessageId: ERROR_INVALID_PRINTER_DRIVER_MANIFEST</para>
        /// <para>MessageText: The printer driver does not contain a valid manifest, or contains too many manifests.</para>
        /// </summary>
        InvalidPrinterDriverManifest = 3021,

        /// <summary>
        /// <para>MessageId: ERROR_PRINTER_NOT_SHAREABLE</para>
        /// <para>MessageText: The specified printer cannot be .Shared.</para>
        /// </summary>
        PrinterNotShareable = 3022,



        /// <summary>
        /// <para>MessageId: ERROR_REQUEST_PAUSED</para>
        /// <para>MessageText: The operation was paused.</para>
        /// </summary>
        RequestPaused = 3050,



        /// <summary>
        /// <para>MessageId: ERROR_APPEXEC_CONDITION_NOT_SATISFIED</para>
        /// <para>MessageText: The condition supplied for the app execution request was not satisfied, so the request was not performed.</para>
        /// </summary>
        AppExecConditionNotSatisfied = 3060,

        /// <summary>
        /// <para>MessageId: ERROR_APPEXEC_HANDLE_INVALIDATED</para>
        /// <para>MessageText: The supplied handle has been invalidated and may not be used for the requested operation.</para>
        /// </summary>
        AppExecHandleInvalidated = 3061,

        /// <summary>
        /// <para>MessageId: ERROR_APPEXEC_INVALID_HOST_GENERATION</para>
        /// <para>MessageText: The supplied host generation has been invalidated and may not be used for the requested operation.</para>
        /// </summary>
        AppExecInvalidHostGeneration = 3062,

        /// <summary>
        /// <para>MessageId: ERROR_APPEXEC_UNEXPECTED_PROCESS_REGISTRATION</para>
        /// <para>MessageText: An attempt to register a process failed because the target host was not in a valid state to receive process registrations.</para>
        /// </summary>
        AppExecUnexpectedProcessRegistration = 3063,

        /// <summary>
        /// <para>MessageId: ERROR_APPEXEC_INVALID_HOST_STATE</para>
        /// <para>MessageText: The host is not in a valid state to support the execution request.</para>
        /// </summary>
        AppExecInvalidHostState = 3064,

        /// <summary>
        /// <para>MessageId: ERROR_APPEXEC_NO_DONOR</para>
        /// <para>MessageText: The operation was not completed because a required resource donor was not found for the host.</para>
        /// </summary>
        AppExecNoDonor = 3065,

        /// <summary>
        /// <para>MessageId: ERROR_APPEXEC_HOST_ID_MISMATCH</para>
        /// <para>MessageText: The operation was not completed because an unexpected host ID was encountered.</para>
        /// </summary>
        AppExecHostIdMismatch = 3066,

        /// <summary>
        /// <para>MessageId: ERROR_APPEXEC_UNKNOWN_USER</para>
        /// <para>MessageText: The operation was not completed because the specified user was not known to the service.</para>
        /// </summary>
        AppExecUnknownUser = 3067,








        /// <summary>
        /// <para>MessageId: ERROR_IO_REISSUE_AS_CACHED</para>
        /// <para>MessageText: Reissue the given operation as a cached IO operation</para>
        /// </summary>
        IOReissueAsCached = 3950,




        /// <summary>
        /// <para>MessageId: ERROR_WINS_INTERNAL</para>
        /// <para>MessageText: WINS encountered an error while processing the command.</para>
        /// </summary>
        WINSInternal = 4000,

        /// <summary>
        /// <para>MessageId: ERROR_CAN_NOT_DEL_LOCAL_WINS</para>
        /// <para>MessageText: The local WINS cannot be deleted.</para>
        /// </summary>
        CanNotDeleteLocalWINS = 4001,

        /// <summary>
        /// <para>MessageId: ERROR_STATIC_INIT</para>
        /// <para>MessageText: The importation from the file failed.</para>
        /// </summary>
        StaticInit = 4002,

        /// <summary>
        /// <para>MessageId: ERROR_INC_BACKUP</para>
        /// <para>MessageText: The backup failed. Was a full backup done before?</para>
        /// </summary>
        IncBackup = 4003,

        /// <summary>
        /// <para>MessageId: ERROR_FULL_BACKUP</para>
        /// <para>MessageText: The backup failed. Check the directory to which you are backing the database.</para>
        /// </summary>
        FullBackup = 4004,

        /// <summary>
        /// <para>MessageId: ERROR_REC_NON_EXISTENT</para>
        /// <para>MessageText: The name does not exist in the WINS database.</para>
        /// </summary>
        RecNonExistent = 4005,

        /// <summary>
        /// <para>MessageId: ERROR_RPL_NOT_ALLOWED</para>
        /// <para>MessageText: Replication with a nonconfigured partner is not allowed.</para>
        /// </summary>
        ReplicationNotAllowed = 4006,



        /// <summary>
        /// <para>MessageId: PEERDIST_ERROR_CONTENTINFO_VERSION_UNSUPPORTED</para>
        /// <para>MessageText: The version of the supplied content information is not supported.</para>
        /// </summary>
        PeerDistContentInfoVersionUnsupported = 4050,

        /// <summary>
        /// <para>MessageId: PEERDIST_ERROR_CANNOT_PARSE_CONTENTINFO</para>
        /// <para>MessageText: The supplied content information is malformed.</para>
        /// </summary>
        PeerDistCannotParseContentInfo = 4051,

        /// <summary>
        /// <para>MessageId: PEERDIST_ERROR_MISSING_DATA</para>
        /// <para>MessageText: The requested data cannot be found in local or peer caches.</para>
        /// </summary>
        PeerDistMissingData = 4052,

        /// <summary>
        /// <para>MessageId: PEERDIST_ERROR_NO_MORE</para>
        /// <para>MessageText: No more data is available or required.</para>
        /// </summary>
        PeerDistNoMore = 4053,

        /// <summary>
        /// <para>MessageId: PEERDIST_ERROR_NOT_INITIALIZED</para>
        /// <para>MessageText: The supplied object has not been initialized.</para>
        /// </summary>
        PeerDistNotInitialized = 4054,

        /// <summary>
        /// <para>MessageId: PEERDIST_ERROR_ALREADY_INITIALIZED</para>
        /// <para>MessageText: The supplied object has already been initialized.</para>
        /// </summary>
        PeerDistAlreadyInitialized = 4055,

        /// <summary>
        /// <para>MessageId: PEERDIST_ERROR_SHUTDOWN_IN_PROGRESS</para>
        /// <para>MessageText: A shutdown operation is already in progress.</para>
        /// </summary>
        PeerDistShutdownInProgress = 4056,

        /// <summary>
        /// <para>MessageId: PEERDIST_ERROR_INVALIDATED</para>
        /// <para>MessageText: The supplied object has already been invalidated.</para>
        /// </summary>
        PeerDistInvalidated = 4057,

        /// <summary>
        /// <para>MessageId: PEERDIST_ERROR_ALREADY_EXISTS</para>
        /// <para>MessageText: An element already exists and was not replaced.</para>
        /// </summary>
        PeerDistAlreadyExists = 4058,

        /// <summary>
        /// <para>MessageId: PEERDIST_ERROR_OPERATION_NOTFOUND</para>
        /// <para>MessageText: Can not cancel the requested operation as it has already been completed.</para>
        /// </summary>
        PeerDistOperationNotFound = 4059,

        /// <summary>
        /// <para>MessageId: PEERDIST_ERROR_ALREADY_COMPLETED</para>
        /// <para>MessageText: Can not perform the requested operation because it has already been carried out.</para>
        /// </summary>
        PeerDistAlreadyCompleted = 4060,

        /// <summary>
        /// <para>MessageId: PEERDIST_ERROR_OUT_OF_BOUNDS</para>
        /// <para>MessageText: An operation accessed data beyond the bounds of valid data.</para>
        /// </summary>
        PeerDistOutOfBounds = 4061,

        /// <summary>
        /// <para>MessageId: PEERDIST_ERROR_VERSION_UNSUPPORTED</para>
        /// <para>MessageText: The requested version is not supported.</para>
        /// </summary>
        PeerDistVersionUnsupported = 4062,

        /// <summary>
        /// <para>MessageId: PEERDIST_ERROR_INVALID_CONFIGURATION</para>
        /// <para>MessageText: A configuration value is invalid.</para>
        /// </summary>
        PeerDistInvalidConfiguration = 4063,

        /// <summary>
        /// <para>MessageId: PEERDIST_ERROR_NOT_LICENSED</para>
        /// <para>MessageText: The SKU is not licensed.</para>
        /// </summary>
        PeerDistNotLicensed = 4064,

        /// <summary>
        /// <para>MessageId: PEERDIST_ERROR_SERVICE_UNAVAILABLE</para>
        /// <para>MessageText: PeerDist Service is still initializing and will be available shortly.</para>
        /// </summary>
        PeerDistServiceUnavailable = 4065,

        /// <summary>
        /// <para>MessageId: PEERDIST_ERROR_TRUST_FAILURE</para>
        /// <para>MessageText: Communication with one or more computers will be temporarily blocked due to recent errors.</para>
        /// </summary>
        PeerDistTrustFailure = 4066,



        /// <summary>
        /// <para>MessageId: ERROR_DHCP_ADDRESS_CONFLICT</para>
        /// <para>MessageText: The DHCP client has obtained an IP address that is already in use on the network. The local interface will be disabled until the DHCP client can obtain a new address.</para>
        /// </summary>
        DHCPAddressConflict = 4100,





        /// <summary>
        /// <para>MessageId: ERROR_WMI_GUID_NOT_FOUND</para>
        /// <para>MessageText: The GUID passed was not recognized as valid by a WMI data provider.</para>
        /// </summary>
        WMIGuidNotFound = 4200,

        /// <summary>
        /// <para>MessageId: ERROR_WMI_INSTANCE_NOT_FOUND</para>
        /// <para>MessageText: The instance name passed was not recognized as valid by a WMI data provider.</para>
        /// </summary>
        WMIInstanceNotFound = 4201,

        /// <summary>
        /// <para>MessageId: ERROR_WMI_ITEMID_NOT_FOUND</para>
        /// <para>MessageText: The data item ID passed was not recognized as valid by a WMI data provider.</para>
        /// </summary>
        WMIItemIdNotFound = 4202,

        /// <summary>
        /// <para>MessageId: ERROR_WMI_TRY_AGAIN</para>
        /// <para>MessageText: The WMI request could not be completed and should be retried.</para>
        /// </summary>
        WMITryAgain = 4203,

        /// <summary>
        /// <para>MessageId: ERROR_WMI_DP_NOT_FOUND</para>
        /// <para>MessageText: The WMI data provider could not be located.</para>
        /// </summary>
        WMIDPNotFound = 4204,

        /// <summary>
        /// <para>MessageId: ERROR_WMI_UNRESOLVED_INSTANCE_REF</para>
        /// <para>MessageText: The WMI data provider references an instance set that has not been registered.</para>
        /// </summary>
        WMIUnresolvedInstanceRef = 4205,

        /// <summary>
        /// <para>MessageId: ERROR_WMI_ALREADY_ENABLED</para>
        /// <para>MessageText: The WMI data block or event notification has already been enabled.</para>
        /// </summary>
        WMIAlreadyEnabled = 4206,

        /// <summary>
        /// <para>MessageId: ERROR_WMI_GUID_DISCONNECTED</para>
        /// <para>MessageText: The WMI data block is no longer available.</para>
        /// </summary>
        WMIGuidDisconnected = 4207,

        /// <summary>
        /// <para>MessageId: ERROR_WMI_SERVER_UNAVAILABLE</para>
        /// <para>MessageText: The WMI data service is not available.</para>
        /// </summary>
        WMIServerUnavailable = 4208,

        /// <summary>
        /// <para>MessageId: ERROR_WMI_DP_FAILED</para>
        /// <para>MessageText: The WMI data provider failed to carry out the request.</para>
        /// </summary>
        WMIDPFailed = 4209,

        /// <summary>
        /// <para>MessageId: ERROR_WMI_INVALID_MOF</para>
        /// <para>MessageText: The WMI MOF information is not valid.</para>
        /// </summary>
        WMIInvalidMOF = 4210,

        /// <summary>
        /// <para>MessageId: ERROR_WMI_INVALID_REGINFO</para>
        /// <para>MessageText: The WMI registration information is not valid.</para>
        /// </summary>
        WMIInvalidRegInfo = 4211,

        /// <summary>
        /// <para>MessageId: ERROR_WMI_ALREADY_DISABLED</para>
        /// <para>MessageText: The WMI data block or event notification has already been disabled.</para>
        /// </summary>
        WMIAlreadyDisabled = 4212,

        /// <summary>
        /// <para>MessageId: ERROR_WMI_READ_ONLY</para>
        /// <para>MessageText: The WMI data item or data block is read only.</para>
        /// </summary>
        WMIReadOnly = 4213,

        /// <summary>
        /// <para>MessageId: ERROR_WMI_SET_FAILURE</para>
        /// <para>MessageText: The WMI data item or data block could not be changed.</para>
        /// </summary>
        WMISetFailure = 4214,



        /// <summary>
        /// <para>MessageId: ERROR_NOT_APPCONTAINER</para>
        /// <para>MessageText: This operation is only valid in the context of an app container.</para>
        /// </summary>
        NotAppContainer = 4250,

        /// <summary>
        /// <para>MessageId: ERROR_APPCONTAINER_REQUIRED</para>
        /// <para>MessageText: This application can only run in the context of an app container.</para>
        /// </summary>
        AppContainerRequired = 4251,

        /// <summary>
        /// <para>MessageId: ERROR_NOT_SUPPORTED_IN_APPCONTAINER</para>
        /// <para>MessageText: This functionality is not supported in the context of an app container.</para>
        /// </summary>
        NotSupportedInAppContainer = 4252,

        /// <summary>
        /// <para>MessageId: ERROR_INVALID_PACKAGE_SID_LENGTH</para>
        /// <para>MessageText: The length of the SID supplied is not a valid length for app container SIDs.</para>
        /// </summary>
        InvalidPackageSIDLength = 4253,


        /// <summary>
        /// <para>MessageId: ERROR_INVALID_MEDIA</para>
        /// <para>MessageText: The media identifier does not represent a valid medium.</para>
        /// </summary>
        InvalidMedia = 4300,

        /// <summary>
        /// <para>MessageId: ERROR_INVALID_LIBRARY</para>
        /// <para>MessageText: The library identifier does not represent a valid library.</para>
        /// </summary>
        InvalidLibrary = 4301,

        /// <summary>
        /// <para>MessageId: ERROR_INVALID_MEDIA_POOL</para>
        /// <para>MessageText: The media pool identifier does not represent a valid media pool.</para>
        /// </summary>
        InvalidMediaPool = 4302,

        /// <summary>
        /// <para>MessageId: ERROR_DRIVE_MEDIA_MISMATCH</para>
        /// <para>MessageText: The drive and medium are not compatible or exist in different libraries.</para>
        /// </summary>
        DriveMediaMismatch = 4303,

        /// <summary>
        /// <para>MessageId: ERROR_MEDIA_OFFLINE</para>
        /// <para>MessageText: The medium currently exists in an offline library and must be online to perform this operation.</para>
        /// </summary>
        MediaOffline = 4304,

        /// <summary>
        /// <para>MessageId: ERROR_LIBRARY_OFFLINE</para>
        /// <para>MessageText: The operation cannot be performed on an offline library.</para>
        /// </summary>
        LibraryOffline = 4305,

        /// <summary>
        /// <para>MessageId: ERROR_EMPTY</para>
        /// <para>MessageText: The library, drive, or media pool is empty.</para>
        /// </summary>
        Empty = 4306,

        /// <summary>
        /// <para>MessageId: ERROR_NOT_EMPTY</para>
        /// <para>MessageText: The library, drive, or media pool must be empty to perform this operation.</para>
        /// </summary>
        NotEmpty = 4307,

        /// <summary>
        /// <para>MessageId: ERROR_MEDIA_UNAVAILABLE</para>
        /// <para>MessageText: No media is currently available in this media pool or library.</para>
        /// </summary>
        MediaUnavailable = 4308,

        /// <summary>
        /// <para>MessageId: ERROR_RESOURCE_DISABLED</para>
        /// <para>MessageText: A resource required for this operation is disabled.</para>
        /// </summary>
        ResourceDisabled = 4309,

        /// <summary>
        /// <para>MessageId: ERROR_INVALID_CLEANER</para>
        /// <para>MessageText: The media identifier does not represent a valid cleaner.</para>
        /// </summary>
        InvalidCleaner = 4310,

        /// <summary>
        /// <para>MessageId: ERROR_UNABLE_TO_CLEAN</para>
        /// <para>MessageText: The drive cannot be cleaned or does not support cleaning.</para>
        /// </summary>
        UnableToClean = 4311,

        /// <summary>
        /// <para>MessageId: ERROR_OBJECT_NOT_FOUND</para>
        /// <para>MessageText: The object identifier does not represent a valid object.</para>
        /// </summary>
        ObjectNotFound = 4312,

        /// <summary>
        /// <para>MessageId: ERROR_DATABASE_FAILURE</para>
        /// <para>MessageText: Unable to read from or write to the database.</para>
        /// </summary>
        DatabaseFailure = 4313,

        /// <summary>
        /// <para>MessageId: ERROR_DATABASE_FULL</para>
        /// <para>MessageText: The database is full.</para>
        /// </summary>
        DatabaseFull = 4314,

        /// <summary>
        /// <para>MessageId: ERROR_MEDIA_INCOMPATIBLE</para>
        /// <para>MessageText: The medium is not compatible with the device or media pool.</para>
        /// </summary>
        MediaIncompatible = 4315,

        /// <summary>
        /// <para>MessageId: ERROR_RESOURCE_NOT_PRESENT</para>
        /// <para>MessageText: The resource required for this operation does not exist.</para>
        /// </summary>
        ResourceNotPresent = 4316,

        /// <summary>
        /// <para>MessageId: ERROR_INVALID_OPERATION</para>
        /// <para>MessageText: The operation identifier is not valid.</para>
        /// </summary>
        InvalidOperation = 4317,

        /// <summary>
        /// <para>MessageId: ERROR_MEDIA_NOT_AVAILABLE</para>
        /// <para>MessageText: The media is not mounted or ready for use.</para>
        /// </summary>
        MediaNotAvailable = 4318,

        /// <summary>
        /// <para>MessageId: ERROR_DEVICE_NOT_AVAILABLE</para>
        /// <para>MessageText: The device is not ready for use.</para>
        /// </summary>
        DeviceNotAvailable = 4319,

        /// <summary>
        /// <para>MessageId: ERROR_REQUEST_REFUSED</para>
        /// <para>MessageText: The operator or administrator has refused the request.</para>
        /// </summary>
        RequestRefused = 4320,

        /// <summary>
        /// <para>MessageId: ERROR_INVALID_DRIVE_OBJECT</para>
        /// <para>MessageText: The drive identifier does not represent a valid drive.</para>
        /// </summary>
        InvalidDriveObject = 4321,

        /// <summary>
        /// <para>MessageId: ERROR_LIBRARY_FULL</para>
        /// <para>MessageText: Library is full. No slot is available for use.</para>
        /// </summary>
        LibraryFull = 4322,

        /// <summary>
        /// <para>MessageId: ERROR_MEDIUM_NOT_ACCESSIBLE</para>
        /// <para>MessageText: The transport cannot access the medium.</para>
        /// </summary>
        MediumNotAccessible = 4323,

        /// <summary>
        /// <para>MessageId: ERROR_UNABLE_TO_LOAD_MEDIUM</para>
        /// <para>MessageText: Unable to load the medium into the drive.</para>
        /// </summary>
        UnableToLoadMedium = 4324,

        /// <summary>
        /// <para>MessageId: ERROR_UNABLE_TO_INVENTORY_DRIVE</para>
        /// <para>MessageText: Unable to retrieve the drive status.</para>
        /// </summary>
        UnableToInventoryDrive = 4325,

        /// <summary>
        /// <para>MessageId: ERROR_UNABLE_TO_INVENTORY_SLOT</para>
        /// <para>MessageText: Unable to retrieve the slot status.</para>
        /// </summary>
        UnableToInventorySlot = 4326,

        /// <summary>
        /// <para>MessageId: ERROR_UNABLE_TO_INVENTORY_TRANSPORT</para>
        /// <para>MessageText: Unable to retrieve status about the transport.</para>
        /// </summary>
        UnableToInventoryTransport = 4327,

        /// <summary>
        /// <para>MessageId: ERROR_TRANSPORT_FULL</para>
        /// <para>MessageText: Cannot use the transport because it is already in use.</para>
        /// </summary>
        TransportFull = 4328,

        /// <summary>
        /// <para>MessageId: ERROR_CONTROLLING_IEPORT</para>
        /// <para>MessageText: Unable to open or close the inject/eject port.</para>
        /// </summary>
        ControllingIEPort = 4329,

        /// <summary>
        /// <para>MessageId: ERROR_UNABLE_TO_EJECT_MOUNTED_MEDIA</para>
        /// <para>MessageText: Unable to eject the medium because it is in a drive.</para>
        /// </summary>
        UnableToEjectMountedMedia = 4330,

        /// <summary>
        /// <para>MessageId: ERROR_CLEANER_SLOT_SET</para>
        /// <para>MessageText: A cleaner slot is already reserved.</para>
        /// </summary>
        CleanerSlotSet = 4331,

        /// <summary>
        /// <para>MessageId: ERROR_CLEANER_SLOT_NOT_SET</para>
        /// <para>MessageText: A cleaner slot is not reserved.</para>
        /// </summary>
        CleanerSlotNotSet = 4332,

        /// <summary>
        /// <para>MessageId: ERROR_CLEANER_CARTRIDGE_SPENT</para>
        /// <para>MessageText: The cleaner cartridge has performed the maximum number of drive cleanings.</para>
        /// </summary>
        CleanerCartridgeSpent = 4333,

        /// <summary>
        /// <para>MessageId: ERROR_UNEXPECTED_OMID</para>
        /// <para>MessageText: Unexpected on-medium identifier.</para>
        /// </summary>
        UnexpectedOMID = 4334,

        /// <summary>
        /// <para>MessageId: ERROR_CANT_DELETE_LAST_ITEM</para>
        /// <para>MessageText: The last remaining item in this group or resource cannot be deleted.</para>
        /// </summary>
        CantDeleteLastItem = 4335,

        /// <summary>
        /// <para>MessageId: ERROR_MESSAGE_EXCEEDS_MAX_SIZE</para>
        /// <para>MessageText: The message provided exceeds the maximum size allowed for this parameter.</para>
        /// </summary>
        MessageExceedsMaxSize = 4336,

        /// <summary>
        /// <para>MessageId: ERROR_VOLUME_CONTAINS_SYS_FILES</para>
        /// <para>MessageText: The volume contains system or paging files.</para>
        /// </summary>
        VolumeContainsSysFiles = 4337,

        /// <summary>
        /// <para>MessageId: ERROR_INDIGENOUS_TYPE</para>
        /// <para>MessageText: The media type cannot be removed from this library since at least one drive in the library reports it can support this media type.</para>
        /// </summary>
        IndigenousType = 4338,

        /// <summary>
        /// <para>MessageId: ERROR_NO_SUPPORTING_DRIVES</para>
        /// <para>MessageText: This offline media cannot be mounted on this system since no enabled drives are present which can be used.</para>
        /// </summary>
        NoSupportingDrives = 4339,

        /// <summary>
        /// <para>MessageId: ERROR_CLEANER_CARTRIDGE_INSTALLED</para>
        /// <para>MessageText: A cleaner cartridge is present in the tape library.</para>
        /// </summary>
        CleanerCartridgeInstalled = 4340,

        /// <summary>
        /// <para>MessageId: ERROR_IEPORT_FULL</para>
        /// <para>MessageText: Cannot use the inject/eject port because it is not empty.</para>
        /// </summary>
        IEPortFull = 4341,



        /// <summary>
        /// <para>MessageId: ERROR_FILE_OFFLINE</para>
        /// <para>MessageText: This file is currently not available for use on this computer.</para>
        /// </summary>
        FileOffline = 4350,

        /// <summary>
        /// <para>MessageId: ERROR_REMOTE_STORAGE_NOT_ACTIVE</para>
        /// <para>MessageText: The remote storage service is not operational at this time.</para>
        /// </summary>
        RemoteStorageNotActive = 4351,

        /// <summary>
        /// <para>MessageId: ERROR_REMOTE_STORAGE_MEDIA_ERROR</para>
        /// <para>MessageText: The remote storage service encountered a media error.</para>
        /// </summary>
        RemoteStorageMediaError = 4352,



        /// <summary>
        /// <para>MessageId: ERROR_NOT_A_REPARSE_POINT</para>
        /// <para>MessageText: The file or directory is not a reparse point.</para>
        /// </summary>
        NotAReparsePoint = 4390,

        /// <summary>
        /// <para>MessageId: ERROR_REPARSE_ATTRIBUTE_CONFLICT</para>
        /// <para>MessageText: The reparse point attribute cannot be set because it conflicts with an existing attribute.</para>
        /// </summary>
        ReparseAttributeConflict = 4391,

        /// <summary>
        /// <para>MessageId: ERROR_INVALID_REPARSE_DATA</para>
        /// <para>MessageText: The data present in the reparse point buffer is invalid.</para>
        /// </summary>
        InvalidReparseData = 4392,

        /// <summary>
        /// <para>MessageId: ERROR_REPARSE_TAG_INVALID</para>
        /// <para>MessageText: The tag present in the reparse point buffer is invalid.</para>
        /// </summary>
        ReparseTagInvalid = 4393,

        /// <summary>
        /// <para>MessageId: ERROR_REPARSE_TAG_MISMATCH</para>
        /// <para>MessageText: There is a mismatch between the tag specified in the request and the tag present in the reparse point.</para>
        /// </summary>
        ReparseTagMismatch = 4394,

        /// <summary>
        /// <para>MessageId: ERROR_REPARSE_POINT_ENCOUNTERED</para>
        /// <para>MessageText: The object manager encountered a reparse point while retrieving an object.</para>
        /// </summary>
        ReparsePointEncountered = 4395,



        /// <summary>
        /// <para>MessageId: ERROR_APP_DATA_NOT_FOUND</para>
        /// <para>MessageText: Fast Cache data not found.</para>
        /// </summary>
        AppDataNotFound = 4400,

        /// <summary>
        /// <para>MessageId: ERROR_APP_DATA_EXPIRED</para>
        /// <para>MessageText: Fast Cache data expired.</para>
        /// </summary>
        AppDataExpired = 4401,

        /// <summary>
        /// <para>MessageId: ERROR_APP_DATA_CORRUPT</para>
        /// <para>MessageText: Fast Cache data corrupt.</para>
        /// </summary>
        AppDataCorrupt = 4402,

        /// <summary>
        /// <para>MessageId: ERROR_APP_DATA_LIMIT_EXCEEDED</para>
        /// <para>MessageText: Fast Cache data has exceeded its max size and cannot be updated.</para>
        /// </summary>
        AppDataLimitExceeded = 4403,

        /// <summary>
        /// <para>MessageId: ERROR_APP_DATA_REBOOT_REQUIRED</para>
        /// <para>MessageText: Fast Cache has been ReArmed and requires a reboot until it can be updated.</para>
        /// </summary>
        AppDataRebootRequired = 4404,



        /// <summary>
        /// <para>MessageId: ERROR_SECUREBOOT_ROLLBACK_DETECTED</para>
        /// <para>MessageText: Secure Boot detected that rollback of protected data has been attempted.</para>
        /// </summary>
        SecureBootRollbackDetected = 4420,

        /// <summary>
        /// <para>MessageId: ERROR_SECUREBOOT_POLICY_VIOLATION</para>
        /// <para>MessageText: The value is protected by Secure Boot policy and cannot be modified or deleted.</para>
        /// </summary>
        SecureBootPolicyViolation = 4421,

        /// <summary>
        /// <para>MessageId: ERROR_SECUREBOOT_INVALID_POLICY</para>
        /// <para>MessageText: The Secure Boot policy is invalid.</para>
        /// </summary>
        SecureBootInvalidPolicy = 4422,

        /// <summary>
        /// <para>MessageId: ERROR_SECUREBOOT_POLICY_PUBLISHER_NOT_FOUND</para>
        /// <para>MessageText: A new Secure Boot policy did not contain the current publisher on its update list.</para>
        /// </summary>
        SecureBootPolicyPublisherNotFound = 4423,

        /// <summary>
        /// <para>MessageId: ERROR_SECUREBOOT_POLICY_NOT_SIGNED</para>
        /// <para>MessageText: The Secure Boot policy is either not signed or is signed by a non-trusted signer.</para>
        /// </summary>
        SecureBootPolicyNotSigned = 4424,

        /// <summary>
        /// <para>MessageId: ERROR_SECUREBOOT_NOT_ENABLED</para>
        /// <para>MessageText: Secure Boot is not enabled on this machine.</para>
        /// </summary>
        SecureBootNotEnabled = 4425,

        /// <summary>
        /// <para>MessageId: ERROR_SECUREBOOT_FILE_REPLACED</para>
        /// <para>MessageText: Secure Boot requires that certain files and drivers are not replaced by other files or drivers.</para>
        /// </summary>
        SecureBootFileReplaced = 4426,

        /// <summary>
        /// <para>MessageId: ERROR_SECUREBOOT_POLICY_NOT_AUTHORIZED</para>
        /// <para>MessageText: The Secure Boot Supplemental Policy file was not authorized on this machine.</para>
        /// </summary>
        SecureBootPolicyNotAuthorized = 4427,

        /// <summary>
        /// <para>MessageId: ERROR_SECUREBOOT_POLICY_UNKNOWN</para>
        /// <para>MessageText: The Supplemental Policy is not recognized on this device.</para>
        /// </summary>
        SecureBootPolicyUnknown = 4428,

        /// <summary>
        /// <para>MessageId: ERROR_SECUREBOOT_POLICY_MISSING_ANTIROLLBACKVERSION</para>
        /// <para>MessageText: The Antirollback version was not found in the Secure Boot Policy.</para>
        /// </summary>
        SecureBootPolicyMissingAntirollbackVersion = 4429,

        /// <summary>
        /// <para>MessageId: ERROR_SECUREBOOT_PLATFORM_ID_MISMATCH</para>
        /// <para>MessageText: The Platform ID specified in the Secure Boot policy does not match the Platform ID on this device.</para>
        /// </summary>
        SecureBootPlatformIdMismatch = 4430,

        /// <summary>
        /// <para>MessageId: ERROR_SECUREBOOT_POLICY_ROLLBACK_DETECTED</para>
        /// <para>MessageText: The Secure Boot policy file has an older Antirollback Version than this device.</para>
        /// </summary>
        SecureBootPolicyRollbackDetected = 4431,

        /// <summary>
        /// <para>MessageId: ERROR_SECUREBOOT_POLICY_UPGRADE_MISMATCH</para>
        /// <para>MessageText: The Secure Boot policy file does not match the upgraded legacy policy.</para>
        /// </summary>
        SecureBootPolicyUpgradeMismatch = 4432,

        /// <summary>
        /// <para>MessageId: ERROR_SECUREBOOT_REQUIRED_POLICY_FILE_MISSING</para>
        /// <para>MessageText: The Secure Boot policy file is required but could not be found.</para>
        /// </summary>
        SecureBootRequiredPolicyFileMissing = 4433,

        /// <summary>
        /// <para>MessageId: ERROR_SECUREBOOT_NOT_BASE_POLICY</para>
        /// <para>MessageText: Supplemental Secure Boot policy file can not be loaded as a base Secure Boot policy.</para>
        /// </summary>
        SecureBootNotBasePolicy = 4434,

        /// <summary>
        /// <para>MessageId: ERROR_SECUREBOOT_NOT_SUPPLEMENTAL_POLICY</para>
        /// <para>MessageText: Base Secure Boot policy file can not be loaded as a Supplemental Secure Boot policy.</para>
        /// </summary>
        SecureBootNotSupplementalPolicy = 4435,



        /// <summary>
        /// <para>MessageId: ERROR_OFFLOAD_READ_FLT_NOT_SUPPORTED</para>
        /// <para>MessageText: The copy offload read operation is not supported by a filter.</para>
        /// </summary>
        OffloadReadFltNotSupported = 4440,

        /// <summary>
        /// <para>MessageId: ERROR_OFFLOAD_WRITE_FLT_NOT_SUPPORTED</para>
        /// <para>MessageText: The copy offload write operation is not supported by a filter.</para>
        /// </summary>
        OffloadWriteFltNotSupported = 4441,

        /// <summary>
        /// <para>MessageId: ERROR_OFFLOAD_READ_FILE_NOT_SUPPORTED</para>
        /// <para>MessageText: The copy offload read operation is not supported for the file.</para>
        /// </summary>
        OffloadReadFileNotSupported = 4442,

        /// <summary>
        /// <para>MessageId: ERROR_OFFLOAD_WRITE_FILE_NOT_SUPPORTED</para>
        /// <para>MessageText: The copy offload write operation is not supported for the file.</para>
        /// </summary>
        OffloadWriteFileNotSupported = 4443,

        /// <summary>
        /// <para>MessageId: ERROR_ALREADY_HAS_STREAM_ID</para>
        /// <para>MessageText: This file is currently associated with a different stream id.</para>
        /// </summary>
        AlreadyHasStreamId = 4444,

        /// <summary>
        /// <para>MessageId: ERROR_SMR_GARBAGE_COLLECTION_REQUIRED</para>
        /// <para>MessageText: The volume must undergo garbage collection.</para>
        /// </summary>
        SMRGarbageCollectionRequired = 4445,

        /// <summary>
        /// <para>MessageId: ERROR_WOF_WIM_HEADER_CORRUPT</para>
        /// <para>MessageText: The WOF driver encountered a corruption in WIM image's Header.</para>
        /// </summary>
        WOFWIMHeaderCorrupt = 4446,

        /// <summary>
        /// <para>MessageId: ERROR_WOF_WIM_RESOURCE_TABLE_CORRUPT</para>
        /// <para>MessageText: The WOF driver encountered a corruption in WIM image's Resource Table.</para>
        /// </summary>
        WOFWIMResourceTableCorrupt = 4447,

        /// <summary>
        /// <para>MessageId: ERROR_WOF_FILE_RESOURCE_TABLE_CORRUPT</para>
        /// <para>MessageText: The WOF driver encountered a corruption in the compressed file's Resource Table.</para>
        /// </summary>
        WOFFileResourceTableCorrupt = 4448,



        /// <summary>
        /// <para>MessageId: ERROR_VOLUME_NOT_SIS_ENABLED</para>
        /// <para>MessageText: Single Instance Storage is not available on this volume.</para>
        /// </summary>
        VolumeNotSISEnabled = 4500,



        /// <summary>
        /// <para>MessageId: ERROR_SYSTEM_INTEGRITY_ROLLBACK_DETECTED</para>
        /// <para>MessageText: System Integrity detected that policy rollback has been attempted.</para>
        /// </summary>
        SystemIntegrityRollbackDetected = 4550,

        /// <summary>
        /// <para>MessageId: ERROR_SYSTEM_INTEGRITY_POLICY_VIOLATION</para>
        /// <para>MessageText: Your organization used Device Guard to block this app. Contact your support person for more info.</para>
        /// </summary>
        SystemIntegrityPolicyViolation = 4551,

        /// <summary>
        /// <para>MessageId: ERROR_SYSTEM_INTEGRITY_INVALID_POLICY</para>
        /// <para>MessageText: The System Integrity policy is invalid.</para>
        /// </summary>
        SystemIntegrityInvalidPolicy = 4552,

        /// <summary>
        /// <para>MessageId: ERROR_SYSTEM_INTEGRITY_POLICY_NOT_SIGNED</para>
        /// <para>MessageText: The System Integrity policy is either not signed or is signed by a non-trusted signer.</para>
        /// </summary>
        SystemIntegrityPolicyNotSigned = 4553,

        /// <summary>
        /// <para>MessageId: ERROR_SYSTEM_INTEGRITY_TOO_MANY_POLICIES</para>
        /// <para>MessageText: The number of System Integrity policies is out of limit.</para>
        /// </summary>
        SystemIntegrityTooManyPolicies = 4554,

        /// <summary>
        /// <para>MessageId: ERROR_SYSTEM_INTEGRITY_SUPPLEMENTAL_POLICY_NOT_AUTHORIZED</para>
        /// <para>MessageText: The Code Integrity supplemental policy is not authorized by a Code Integrity base policy.</para>
        /// </summary>
        SystemIntegritySupplementalPolicyNotAuthorized = 4555,



        /// <summary>
        /// <para>MessageId: ERROR_VSM_NOT_INITIALIZED</para>
        /// <para>MessageText: Virtual Secure Mode (VSM) is not initialized. The hypervisor or VSM may not be present or enabled.</para>
        /// </summary>
        VSMNotInitialized = 4560,

        /// <summary>
        /// <para>MessageId: ERROR_VSM_DMA_PROTECTION_NOT_IN_USE</para>
        /// <para>MessageText: The hypervisor is not protecting DMA because an IOMMU is not present or not enabled in the BIOS.</para>
        /// </summary>
        VSMDMAProtectionNotInUse = 4561,


        //        /// <summary>
        //        /// <para>MessageId: ERROR_PLATFORM_MANIFEST_NOT_AUTHORIZED</para>
        //        /// <para>MessageText: The Platform Manifest file was not authorized on this machine.</para>
        //        /// </summary>
        //        PlatformManifestNotAuthorized = 4570,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_PLATFORM_MANIFEST_INVALID</para>
        //        /// <para>MessageText: The Platform Manifest file was not valid.</para>
        //        /// </summary>
        //        PlatformManifestInvalid = 4571,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_PLATFORM_MANIFEST_FILE_NOT_AUTHORIZED</para>
        //        /// <para>MessageText: The file is not authorized on this platform because an entry was not found in the Platform Manifest.</para>
        //        /// </summary>
        //        PlatformManifestFileNotAuthorized = 4572,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_PLATFORM_MANIFEST_CATALOG_NOT_AUTHORIZED</para>
        //        /// <para>MessageText: The catalog is not authorized on this platform because an entry was not found in the Platform Manifest.</para>
        //        /// </summary>
        //        PlatformManifestCatalogNotAuthorized = 4573,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_PLATFORM_MANIFEST_BINARY_ID_NOT_FOUND</para>
        //        /// <para>MessageText: The file is not authorized on this platform because a Binary ID was not found in the embedded signature.</para>
        //        /// </summary>
        //        PlatformManifestBinaryIdNotFound = 4574,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_PLATFORM_MANIFEST_NOT_ACTIVE</para>
        //        /// <para>MessageText: No active Platform Manifest exists on this system.</para>
        //        /// </summary>
        //        PlatformManifestNotActive = 4575,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_PLATFORM_MANIFEST_NOT_SIGNED</para>
        //        /// <para>MessageText: The Platform Manifest file was not properly signed.</para>
        //        /// </summary>
        //        PlatformManifestNotSigned = 4576,



        //        /// <summary>
        //        /// <para>MessageId: ERROR_DEPENDENT_RESOURCE_EXISTS</para>
        //        /// <para>MessageText: The operation cannot be completed because other resources are dependent on this resource.</para>
        //        /// </summary>
        //        DependentResourceExists = 5001,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DEPENDENCY_NOT_FOUND</para>
        //        /// <para>MessageText: The cluster resource dependency cannot be found.</para>
        //        /// </summary>
        //        DependencyNotFound = 5002,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DEPENDENCY_ALREADY_EXISTS</para>
        //        /// <para>MessageText: The cluster resource cannot be made dependent on the specified resource because it is already dependent.</para>
        //        /// </summary>
        //        DependencyAlreadyExists = 5003,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_RESOURCE_NOT_ONLINE</para>
        //        /// <para>MessageText: The cluster resource is not online.</para>
        //        /// </summary>
        //        ResourceNotOnline = 5004,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_HOST_NODE_NOT_AVAILABLE</para>
        //        /// <para>MessageText: A cluster node is not available for this operation.</para>
        //        /// </summary>
        //        HostNodeNotAvailable = 5005,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_RESOURCE_NOT_AVAILABLE</para>
        //        /// <para>MessageText: The cluster resource is not available.</para>
        //        /// </summary>
        //        ResourceNotAvailable = 5006,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_RESOURCE_NOT_FOUND</para>
        //        /// <para>MessageText: The cluster resource could not be found.</para>
        //        /// </summary>
        //        ResourceNotFound = 5007,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_SHUTDOWN_CLUSTER</para>
        //        /// <para>MessageText: The cluster is being shut down.</para>
        //        /// </summary>
        //        ShutdownCluster = 5008,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CANT_EVICT_ACTIVE_NODE</para>
        //        /// <para>MessageText: A cluster node cannot be evicted from the cluster unless the node is down or it is the last node.</para>
        //        /// </summary>
        //        CantEvictActiveNode = 5009,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_OBJECT_ALREADY_EXISTS</para>
        //        /// <para>MessageText: The object already exists.</para>
        //        /// </summary>
        //        ObjectAlreadyExists = 5010,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_OBJECT_IN_LIST</para>
        //        /// <para>MessageText: The object is already in the list.</para>
        //        /// </summary>
        //        ObjectInList = 5011,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_GROUP_NOT_AVAILABLE</para>
        //        /// <para>MessageText: The cluster group is not available for any new requests.</para>
        //        /// </summary>
        //        GroupNotAvailable = 5012,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_GROUP_NOT_FOUND</para>
        //        /// <para>MessageText: The cluster group could not be found.</para>
        //        /// </summary>
        //        GroupNotFound = 5013,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_GROUP_NOT_ONLINE</para>
        //        /// <para>MessageText: The operation could not be completed because the cluster group is not online.</para>
        //        /// </summary>
        //        GroupNotOnline = 5014,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_HOST_NODE_NOT_RESOURCE_OWNER</para>
        //        /// <para>MessageText: The operation failed because either the specified cluster node is not the owner of the resource, or the node is not a possible owner of the resource.</para>
        //        /// </summary>
        //        HostNodeNotResourceOwner = 5015,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_HOST_NODE_NOT_GROUP_OWNER</para>
        //        /// <para>MessageText: The operation failed because either the specified cluster node is not the owner of the group, or the node is not a possible owner of the group.</para>
        //        /// </summary>
        //        HostNodeNotGroupOwner = 5016,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_RESMON_CREATE_FAILED</para>
        //        /// <para>MessageText: The cluster resource could not be created in the specified resource monitor.</para>
        //        /// </summary>
        //        ResmonCreateFailed = 5017,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_RESMON_ONLINE_FAILED</para>
        //        /// <para>MessageText: The cluster resource could not be brought online by the resource monitor.</para>
        //        /// </summary>
        //        ResmonOnlineFailed = 5018,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_RESOURCE_ONLINE</para>
        //        /// <para>MessageText: The operation could not be completed because the cluster resource is online.</para>
        //        /// </summary>
        //        ResourceOnline = 5019,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_QUORUM_RESOURCE</para>
        //        /// <para>MessageText: The cluster resource could not be deleted or brought offline because it is the quorum resource.</para>
        //        /// </summary>
        //        QuorumResource = 5020,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_NOT_QUORUM_CAPABLE</para>
        //        /// <para>MessageText: The cluster could not make the specified resource a quorum resource because it is not capable of being a quorum resource.</para>
        //        /// </summary>
        //        NotQuorumCapable = 5021,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CLUSTER_SHUTTING_DOWN</para>
        //        /// <para>MessageText: The cluster software is shutting down.</para>
        //        /// </summary>
        //        ClusterShuttingDown = 5022,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_INVALID_STATE</para>
        //        /// <para>MessageText: The group or resource is not in the correct state to perform the requested operation.</para>
        //        /// </summary>
        //        InvalidState = 5023,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_RESOURCE_PROPERTIES_STORED</para>
        //        /// <para>MessageText: The properties were stored but not all changes will take effect until the next time the resource is brought online.</para>
        //        /// </summary>
        //        ResourcePropertiesStored = 5024,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_NOT_QUORUM_CLASS</para>
        //        /// <para>MessageText: The cluster could not make the specified resource a quorum resource because it does not belong to a .Shared storage class.</para>
        //        /// </summary>
        //        NotQuorumClass = 5025,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CORE_RESOURCE</para>
        //        /// <para>MessageText: The cluster resource could not be deleted since it is a core resource.</para>
        //        /// </summary>
        //        CoreResource = 5026,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_QUORUM_RESOURCE_ONLINE_FAILED</para>
        //        /// <para>MessageText: The quorum resource failed to come online.</para>
        //        /// </summary>
        //        QuorumResourceOnlineFailed = 5027,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_QUORUMLOG_OPEN_FAILED</para>
        //        /// <para>MessageText: The quorum log could not be created or mounted successfully.</para>
        //        /// </summary>
        //        QuorumlogOpenFailed = 5028,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CLUSTERLOG_CORRUPT</para>
        //        /// <para>MessageText: The cluster log is corrupt.</para>
        //        /// </summary>
        //        ClusterlogCorrupt = 5029,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CLUSTERLOG_RECORD_EXCEEDS_MAXSIZE</para>
        //        /// <para>MessageText: The record could not be written to the cluster log since it exceeds the maximum size.</para>
        //        /// </summary>
        //        ClusterlogRecordExceedsMaxsize = 5030,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CLUSTERLOG_EXCEEDS_MAXSIZE</para>
        //        /// <para>MessageText: The cluster log exceeds its maximum size.</para>
        //        /// </summary>
        //        ClusterlogExceedsMaxsize = 5031,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CLUSTERLOG_CHKPOINT_NOT_FOUND</para>
        //        /// <para>MessageText: No checkpoint record was found in the cluster log.</para>
        //        /// </summary>
        //        ClusterlogChkpointNotFound = 5032,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CLUSTERLOG_NOT_ENOUGH_SPACE</para>
        //        /// <para>MessageText: The minimum required disk space needed for logging is not available.</para>
        //        /// </summary>
        //        ClusterlogNotEnoughSpace = 5033,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_QUORUM_OWNER_ALIVE</para>
        //        /// <para>MessageText: The cluster node failed to take control of the quorum resource because the resource is owned by another active node.</para>
        //        /// </summary>
        //        QuorumOwnerAlive = 5034,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_NETWORK_NOT_AVAILABLE</para>
        //        /// <para>MessageText: A cluster network is not available for this operation.</para>
        //        /// </summary>
        //        NetworkNotAvailable = 5035,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_NODE_NOT_AVAILABLE</para>
        //        /// <para>MessageText: A cluster node is not available for this operation.</para>
        //        /// </summary>
        //        NodeNotAvailable = 5036,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_ALL_NODES_NOT_AVAILABLE</para>
        //        /// <para>MessageText: All cluster nodes must be running to perform this operation.</para>
        //        /// </summary>
        //        AllNodesNotAvailable = 5037,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_RESOURCE_FAILED</para>
        //        /// <para>MessageText: A cluster resource failed.</para>
        //        /// </summary>
        //        ResourceFailed = 5038,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CLUSTER_INVALID_NODE</para>
        //        /// <para>MessageText: The cluster node is not valid.</para>
        //        /// </summary>
        //        ClusterInvalidNode = 5039,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CLUSTER_NODE_EXISTS</para>
        //        /// <para>MessageText: The cluster node already exists.</para>
        //        /// </summary>
        //        ClusterNodeExists = 5040,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CLUSTER_JOIN_IN_PROGRESS</para>
        //        /// <para>MessageText: A node is in the process of joining the cluster.</para>
        //        /// </summary>
        //        ClusterJoinInProgress = 5041,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CLUSTER_NODE_NOT_FOUND</para>
        //        /// <para>MessageText: The cluster node was not found.</para>
        //        /// </summary>
        //        ClusterNodeNotFound = 5042,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CLUSTER_LOCAL_NODE_NOT_FOUND</para>
        //        /// <para>MessageText: The cluster local node information was not found.</para>
        //        /// </summary>
        //        ClusterLocalNodeNotFound = 5043,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CLUSTER_NETWORK_EXISTS</para>
        //        /// <para>MessageText: The cluster network already exists.</para>
        //        /// </summary>
        //        ClusterNetworkExists = 5044,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CLUSTER_NETWORK_NOT_FOUND</para>
        //        /// <para>MessageText: The cluster network was not found.</para>
        //        /// </summary>
        //        ClusterNetworkNotFound = 5045,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CLUSTER_NETINTERFACE_EXISTS</para>
        //        /// <para>MessageText: The cluster network interface already exists.</para>
        //        /// </summary>
        //        ClusterNetinterfaceExists = 5046,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CLUSTER_NETINTERFACE_NOT_FOUND</para>
        //        /// <para>MessageText: The cluster network interface was not found.</para>
        //        /// </summary>
        //        ClusterNetinterfaceNotFound = 5047,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CLUSTER_INVALID_REQUEST</para>
        //        /// <para>MessageText: The cluster request is not valid for this object.</para>
        //        /// </summary>
        //        ClusterInvalidRequest = 5048,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CLUSTER_INVALID_NETWORK_PROVIDER</para>
        //        /// <para>MessageText: The cluster network provider is not valid.</para>
        //        /// </summary>
        //        ClusterInvalidNetworkProvider = 5049,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CLUSTER_NODE_DOWN</para>
        //        /// <para>MessageText: The cluster node is down.</para>
        //        /// </summary>
        //        ClusterNodeDown = 5050,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CLUSTER_NODE_UNREACHABLE</para>
        //        /// <para>MessageText: The cluster node is not reachable.</para>
        //        /// </summary>
        //        ClusterNodeUnreachable = 5051,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CLUSTER_NODE_NOT_MEMBER</para>
        //        /// <para>MessageText: The cluster node is not a member of the cluster.</para>
        //        /// </summary>
        //        ClusterNodeNotMember = 5052,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CLUSTER_JOIN_NOT_IN_PROGRESS</para>
        //        /// <para>MessageText: A cluster join operation is not in progress.</para>
        //        /// </summary>
        //        ClusterJoinNotInProgress = 5053,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CLUSTER_INVALID_NETWORK</para>
        //        /// <para>MessageText: The cluster network is not valid.</para>
        //        /// </summary>
        //        ClusterInvalidNetwork = 5054,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CLUSTER_NODE_UP</para>
        //        /// <para>MessageText: The cluster node is up.</para>
        //        /// </summary>
        //        ClusterNodeUp = 5056,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CLUSTER_IPADDR_IN_USE</para>
        //        /// <para>MessageText: The cluster IP address is already in use.</para>
        //        /// </summary>
        //        ClusterIpaddrInUse = 5057,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CLUSTER_NODE_NOT_PAUSED</para>
        //        /// <para>MessageText: The cluster node is not paused.</para>
        //        /// </summary>
        //        ClusterNodeNotPaused = 5058,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CLUSTER_NO_SECURITY_CONTEXT</para>
        //        /// <para>MessageText: No cluster security context is available.</para>
        //        /// </summary>
        //        ClusterNoSecurityContext = 5059,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CLUSTER_NETWORK_NOT_INTERNAL</para>
        //        /// <para>MessageText: The cluster network is not configured for internal cluster communication.</para>
        //        /// </summary>
        //        ClusterNetworkNotInternal = 5060,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CLUSTER_NODE_ALREADY_UP</para>
        //        /// <para>MessageText: The cluster node is already up.</para>
        //        /// </summary>
        //        ClusterNodeAlreadyUp = 5061,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CLUSTER_NODE_ALREADY_DOWN</para>
        //        /// <para>MessageText: The cluster node is already down.</para>
        //        /// </summary>
        //        ClusterNodeAlreadyDown = 5062,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CLUSTER_NETWORK_ALREADY_ONLINE</para>
        //        /// <para>MessageText: The cluster network is already online.</para>
        //        /// </summary>
        //        ClusterNetworkAlreadyOnline = 5063,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CLUSTER_NETWORK_ALREADY_OFFLINE</para>
        //        /// <para>MessageText: The cluster network is already offline.</para>
        //        /// </summary>
        //        ClusterNetworkAlreadyOffline = 5064,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CLUSTER_NODE_ALREADY_MEMBER</para>
        //        /// <para>MessageText: The cluster node is already a member of the cluster.</para>
        //        /// </summary>
        //        ClusterNodeAlreadyMember = 5065,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CLUSTER_LAST_INTERNAL_NETWORK</para>
        //        /// <para>MessageText: The cluster network is the only one configured for internal cluster communication between two or more active cluster nodes. The internal communication capability cannot be removed from the network.</para>
        //        /// </summary>
        //        ClusterLastInternalNetwork = 5066,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CLUSTER_NETWORK_HAS_DEPENDENTS</para>
        //        /// <para>MessageText: One or more cluster resources depend on the network to provide service to clients. The client access capability cannot be removed from the network.</para>
        //        /// </summary>
        //        ClusterNetworkHasDependents = 5067,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_INVALID_OPERATION_ON_QUORUM</para>
        //        /// <para>MessageText: This operation cannot currently be performed on the cluster group containing the quorum resource.</para>
        //        /// </summary>
        //        InvalidOperationOnQuorum = 5068,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DEPENDENCY_NOT_ALLOWED</para>
        //        /// <para>MessageText: The cluster quorum resource is not allowed to have any dependencies.</para>
        //        /// </summary>
        //        DependencyNotAllowed = 5069,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CLUSTER_NODE_PAUSED</para>
        //        /// <para>MessageText: The cluster node is paused.</para>
        //        /// </summary>
        //        ClusterNodePaused = 5070,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_NODE_CANT_HOST_RESOURCE</para>
        //        /// <para>MessageText: The cluster resource cannot be brought online. The owner node cannot run this resource.</para>
        //        /// </summary>
        //        NodeCantHostResource = 5071,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CLUSTER_NODE_NOT_READY</para>
        //        /// <para>MessageText: The cluster node is not ready to perform the requested operation.</para>
        //        /// </summary>
        //        ClusterNodeNotReady = 5072,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CLUSTER_NODE_SHUTTING_DOWN</para>
        //        /// <para>MessageText: The cluster node is shutting down.</para>
        //        /// </summary>
        //        ClusterNodeShuttingDown = 5073,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CLUSTER_JOIN_ABORTED</para>
        //        /// <para>MessageText: The cluster join operation was aborted.</para>
        //        /// </summary>
        //        ClusterJoinAborted = 5074,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CLUSTER_INCOMPATIBLE_VERSIONS</para>
        //        /// <para>MessageText: The node failed to join the cluster because the joining node and other nodes in the cluster have incompatible operating system versions. To get more information about operating system versions of the cluster, run the Validate a Configuration Wizard or the Test-Cluster Windows PowerShell cmdlet.</para>
        //        /// </summary>
        //        ClusterIncompatibleVersions = 5075,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CLUSTER_MAXNUM_OF_RESOURCES_EXCEEDED</para>
        //        /// <para>MessageText: This resource cannot be created because the cluster has reached the limit on the number of resources it can monitor.</para>
        //        /// </summary>
        //        ClusterMaxnumOfResourcesExceeded = 5076,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CLUSTER_SYSTEM_CONFIG_CHANGED</para>
        //        /// <para>MessageText: The system configuration changed during the cluster join or form operation. The join or form operation was aborted.</para>
        //        /// </summary>
        //        ClusterSystemConfigChanged = 5077,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CLUSTER_RESOURCE_TYPE_NOT_FOUND</para>
        //        /// <para>MessageText: The specified resource type was not found.</para>
        //        /// </summary>
        //        ClusterResourceTypeNotFound = 5078,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CLUSTER_RESTYPE_NOT_SUPPORTED</para>
        //        /// <para>MessageText: The specified node does not support a resource of this type. This may be due to version inconsistencies or due to the absence of the resource DLL on this node.</para>
        //        /// </summary>
        //        ClusterRestypeNotSupported = 5079,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CLUSTER_RESNAME_NOT_FOUND</para>
        //        /// <para>MessageText: The specified resource name is not supported by this resource DLL. This may be due to a bad (or changed) name supplied to the resource DLL.</para>
        //        /// </summary>
        //        ClusterResnameNotFound = 5080,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CLUSTER_NO_RPC_PACKAGES_REGISTERED</para>
        //        /// <para>MessageText: No authentication package could be registered with the RPC server.</para>
        //        /// </summary>
        //        ClusterNoRpcPackagesRegistered = 5081,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CLUSTER_OWNER_NOT_IN_PREFLIST</para>
        //        /// <para>MessageText: You cannot bring the group online because the owner of the group is not in the preferred list for the group. To change the owner node for the group, move the group.</para>
        //        /// </summary>
        //        ClusterOwnerNotInPreflist = 5082,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CLUSTER_DATABASE_SEQMISMATCH</para>
        //        /// <para>MessageText: The join operation failed because the cluster database sequence number has changed or is incompatible with the locker node. This may happen during a join operation if the cluster database was changing during the join.</para>
        //        /// </summary>
        //        ClusterDatabaseSeqmismatch = 5083,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_RESMON_INVALID_STATE</para>
        //        /// <para>MessageText: The resource monitor will not allow the fail operation to be performed while the resource is in its current state. This may happen if the resource is in a pending state.</para>
        //        /// </summary>
        //        ResmonInvalidState = 5084,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CLUSTER_GUM_NOT_LOCKER</para>
        //        /// <para>MessageText: A non locker code got a request to reserve the lock for making global updates.</para>
        //        /// </summary>
        //        ClusterGumNotLocker = 5085,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_QUORUM_DISK_NOT_FOUND</para>
        //        /// <para>MessageText: The quorum disk could not be located by the cluster service.</para>
        //        /// </summary>
        //        QuorumDiskNotFound = 5086,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DATABASE_BACKUP_CORRUPT</para>
        //        /// <para>MessageText: The backed up cluster database is possibly corrupt.</para>
        //        /// </summary>
        //        DatabaseBackupCorrupt = 5087,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CLUSTER_NODE_ALREADY_HAS_DFS_ROOT</para>
        //        /// <para>MessageText: A DFS root already exists in this cluster node.</para>
        //        /// </summary>
        //        ClusterNodeAlreadyHasDfsRoot = 5088,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_RESOURCE_PROPERTY_UNCHANGEABLE</para>
        //        /// <para>MessageText: An attempt to modify a resource property failed because it conflicts with another existing property.</para>
        //        /// </summary>
        //        ResourcePropertyUnchangeable = 5089,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_NO_ADMIN_ACCESS_POINT</para>
        //        /// <para>MessageText: This operation is not supported on a cluster without an Administrator Access Point.</para>
        //        /// </summary>
        //        NoAdminAccessPoint = 5090,

        //        /*
        //         Codes from= 4300 through= 5889 overlap with codes in ds\published\inc\apperr2.w.
        //         Do not add any more error codes in that range.
        //        */
        //        /// <summary>
        //        /// <para>MessageId: ERROR_CLUSTER_MEMBERSHIP_INVALID_STATE</para>
        //        /// <para>MessageText: An operation was attempted that is incompatible with the current membership state of the node.</para>
        //        /// </summary>
        //        ClusterMembershipInvalidState = 5890,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CLUSTER_QUORUMLOG_NOT_FOUND</para>
        //        /// <para>MessageText: The quorum resource does not contain the quorum log.</para>
        //        /// </summary>
        //        ClusterQuorumlogNotFound = 5891,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CLUSTER_MEMBERSHIP_HALT</para>
        //        /// <para>MessageText: The membership engine requested shutdown of the cluster service on this node.</para>
        //        /// </summary>
        //        ClusterMembershipHalt = 5892,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CLUSTER_INSTANCE_ID_MISMATCH</para>
        //        /// <para>MessageText: The join operation failed because the cluster instance ID of the joining node does not match the cluster instance ID of the sponsor node.</para>
        //        /// </summary>
        //        ClusterInstanceIdMismatch = 5893,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CLUSTER_NETWORK_NOT_FOUND_FOR_IP</para>
        //        /// <para>MessageText: A matching cluster network for the specified IP address could not be found.</para>
        //        /// </summary>
        //        ClusterNetworkNotFoundForIp = 5894,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CLUSTER_PROPERTY_DATA_TYPE_MISMATCH</para>
        //        /// <para>MessageText: The actual data type of the property did not match the expected data type of the property.</para>
        //        /// </summary>
        //        ClusterPropertyDataTypeMismatch = 5895,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CLUSTER_EVICT_WITHOUT_CLEANUP</para>
        //        /// <para>MessageText: The cluster node was evicted from the cluster successfully, but the node was not cleaned up. To determine what cleanup steps failed and how to recover, see the Failover Clustering application event log using Event Viewer.</para>
        //        /// </summary>
        //        ClusterEvictWithoutCleanup = 5896,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CLUSTER_PARAMETER_MISMATCH</para>
        //        /// <para>MessageText: Two or more parameter values specified for a resource's properties are in conflict.</para>
        //        /// </summary>
        //        ClusterParameterMismatch = 5897,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_NODE_CANNOT_BE_CLUSTERED</para>
        //        /// <para>MessageText: This computer cannot be made a member of a cluster.</para>
        //        /// </summary>
        //        NodeCannotBeClustered = 5898,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CLUSTER_WRONG_OS_VERSION</para>
        //        /// <para>MessageText: This computer cannot be made a member of a cluster because it does not have the correct version of Windows installed.</para>
        //        /// </summary>
        //        ClusterWrongOsVersion = 5899,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CLUSTER_CANT_CREATE_DUP_CLUSTER_NAME</para>
        //        /// <para>MessageText: A cluster cannot be created with the specified cluster name because that cluster name is already in use. Specify a different name for the cluster.</para>
        //        /// </summary>
        //        ClusterCantCreateDupClusterName = 5900,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CLUSCFG_ALREADY_COMMITTED</para>
        //        /// <para>MessageText: The cluster configuration action has already been committed.</para>
        //        /// </summary>
        //        CluscfgAlreadyCommitted = 5901,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CLUSCFG_ROLLBACK_FAILED</para>
        //        /// <para>MessageText: The cluster configuration action could not be rolled back.</para>
        //        /// </summary>
        //        CluscfgRollbackFailed = 5902,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CLUSCFG_SYSTEM_DISK_DRIVE_LETTER_CONFLICT</para>
        //        /// <para>MessageText: The drive letter assigned to a system disk on one node conflicted with the drive letter assigned to a disk on another node.</para>
        //        /// </summary>
        //        CluscfgSystemDiskDriveLetterConflict = 5903,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CLUSTER_OLD_VERSION</para>
        //        /// <para>MessageText: One or more nodes in the cluster are running a version of Windows that does not support this operation.</para>
        //        /// </summary>
        //        ClusterOldVersion = 5904,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CLUSTER_MISMATCHED_COMPUTER_ACCT_NAME</para>
        //        /// <para>MessageText: The name of the corresponding computer account doesn't match the Network Name for this resource.</para>
        //        /// </summary>
        //        ClusterMismatchedComputerAcctName = 5905,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CLUSTER_NO_NET_ADAPTERS</para>
        //        /// <para>MessageText: No network adapters are available.</para>
        //        /// </summary>
        //        ClusterNoNetAdapters = 5906,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CLUSTER_POISONED</para>
        //        /// <para>MessageText: The cluster node has been poisoned.</para>
        //        /// </summary>
        //        ClusterPoisoned = 5907,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CLUSTER_GROUP_MOVING</para>
        //        /// <para>MessageText: The group is unable to accept the request since it is moving to another node.</para>
        //        /// </summary>
        //        ClusterGroupMoving = 5908,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CLUSTER_RESOURCE_TYPE_BUSY</para>
        //        /// <para>MessageText: The resource type cannot accept the request since is too busy performing another operation.</para>
        //        /// </summary>
        //        ClusterResourceTypeBusy = 5909,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_RESOURCE_CALL_TIMED_OUT</para>
        //        /// <para>MessageText: The call to the cluster resource DLL timed out.</para>
        //        /// </summary>
        //        ResourceCallTimedOut = 5910,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_INVALID_CLUSTER_IPV6_ADDRESS</para>
        //        /// <para>MessageText: The address is not valid for an IPv6 Address resource. A global IPv6 address is required, and it must match a cluster network. Compatibility addresses are not permitted.</para>
        //        /// </summary>
        //        InvalidClusterIpv6Address = 5911,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CLUSTER_INTERNAL_INVALID_FUNCTION</para>
        //        /// <para>MessageText: An internal cluster error occurred. A call to an invalid function was attempted.</para>
        //        /// </summary>
        //        ClusterInternalInvalidFunction = 5912,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CLUSTER_PARAMETER_OUT_OF_BOUNDS</para>
        //        /// <para>MessageText: A parameter value is out of acceptable range.</para>
        //        /// </summary>
        //        ClusterParameterOutOfBounds = 5913,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CLUSTER_PARTIAL_SEND</para>
        //        /// <para>MessageText: A network error occurred while sending data to another node in the cluster. The number of bytes transmitted was less than required.</para>
        //        /// </summary>
        //        ClusterPartialSend = 5914,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CLUSTER_REGISTRY_INVALID_FUNCTION</para>
        //        /// <para>MessageText: An invalid cluster registry operation was attempted.</para>
        //        /// </summary>
        //        ClusterRegistryInvalidFunction = 5915,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CLUSTER_INVALID_STRING_TERMINATION</para>
        //        /// <para>MessageText: An input string of characters is not properly terminated.</para>
        //        /// </summary>
        //        ClusterInvalidStringTermination = 5916,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CLUSTER_INVALID_STRING_FORMAT</para>
        //        /// <para>MessageText: An input string of characters is not in a valid format for the data it represents.</para>
        //        /// </summary>
        //        ClusterInvalidStringFormat = 5917,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CLUSTER_DATABASE_TRANSACTION_IN_PROGRESS</para>
        //        /// <para>MessageText: An internal cluster error occurred. A cluster database transaction was attempted while a transaction was already in progress.</para>
        //        /// </summary>
        //        ClusterDatabaseTransactionInProgress = 5918,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CLUSTER_DATABASE_TRANSACTION_NOT_IN_PROGRESS</para>
        //        /// <para>MessageText: An internal cluster error occurred. There was an attempt to commit a cluster database transaction while no transaction was in progress.</para>
        //        /// </summary>
        //        ClusterDatabaseTransactionNotInProgress = 5919,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CLUSTER_NULL_DATA</para>
        //        /// <para>MessageText: An internal cluster error occurred. Data was not properly initialized.</para>
        //        /// </summary>
        //        ClusterNullData = 5920,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CLUSTER_PARTIAL_READ</para>
        //        /// <para>MessageText: An error occurred while reading from a stream of data. An unexpected number of bytes was returned.</para>
        //        /// </summary>
        //        ClusterPartialRead = 5921,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CLUSTER_PARTIAL_WRITE</para>
        //        /// <para>MessageText: An error occurred while writing to a stream of data. The required number of bytes could not be written.</para>
        //        /// </summary>
        //        ClusterPartialWrite = 5922,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CLUSTER_CANT_DESERIALIZE_DATA</para>
        //        /// <para>MessageText: An error occurred while deserializing a stream of cluster data.</para>
        //        /// </summary>
        //        ClusterCantDeserializeData = 5923,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DEPENDENT_RESOURCE_PROPERTY_CONFLICT</para>
        //        /// <para>MessageText: One or more property values for this resource are in conflict with one or more property values associated with its dependent resource(s).</para>
        //        /// </summary>
        //        DependentResourcePropertyConflict = 5924,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CLUSTER_NO_QUORUM</para>
        //        /// <para>MessageText: A quorum of cluster nodes was not present to form a cluster.</para>
        //        /// </summary>
        //        ClusterNoQuorum = 5925,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CLUSTER_INVALID_IPV6_NETWORK</para>
        //        /// <para>MessageText: The cluster network is not valid for an IPv6 Address resource, or it does not match the configured address.</para>
        //        /// </summary>
        //        ClusterInvalidIpv6Network = 5926,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CLUSTER_INVALID_IPV6_TUNNEL_NETWORK</para>
        //        /// <para>MessageText: The cluster network is not valid for an IPv6 Tunnel resource. Check the configuration of the IP Address resource on which the IPv6 Tunnel resource depends.</para>
        //        /// </summary>
        //        ClusterInvalidIpv6TunnelNetwork = 5927,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_QUORUM_NOT_ALLOWED_IN_THIS_GROUP</para>
        //        /// <para>MessageText: Quorum resource cannot reside in the Available Storage group.</para>
        //        /// </summary>
        //        QuorumNotAllowedInThisGroup = 5928,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DEPENDENCY_TREE_TOO_COMPLEX</para>
        //        /// <para>MessageText: The dependencies for this resource are nested too deeply.</para>
        //        /// </summary>
        //        DependencyTreeTooComplex = 5929,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_EXCEPTION_IN_RESOURCE_CALL</para>
        //        /// <para>MessageText: The call into the resource DLL raised an unhandled exception.</para>
        //        /// </summary>
        //        ExceptionInResourceCall = 5930,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CLUSTER_RHS_FAILED_INITIALIZATION</para>
        //        /// <para>MessageText: The RHS process failed to initialize.</para>
        //        /// </summary>
        //        ClusterRhsFailedInitialization = 5931,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CLUSTER_NOT_INSTALLED</para>
        //        /// <para>MessageText: The Failover Clustering feature is not installed on this node.</para>
        //        /// </summary>
        //        ClusterNotInstalled = 5932,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CLUSTER_RESOURCES_MUST_BE_ONLINE_ON_THE_SAME_NODE</para>
        //        /// <para>MessageText: The resources must be online on the same node for this operation</para>
        //        /// </summary>
        //        ClusterResourcesMustBeOnlineOnTheSameNode = 5933,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CLUSTER_MAX_NODES_IN_CLUSTER</para>
        //        /// <para>MessageText: A new node can not be added since this cluster is already at its maximum number of nodes.</para>
        //        /// </summary>
        //        ClusterMaxNodesInCluster = 5934,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CLUSTER_TOO_MANY_NODES</para>
        //        /// <para>MessageText: This cluster can not be created since the specified number of nodes exceeds the maximum allowed limit.</para>
        //        /// </summary>
        //        ClusterTooManyNodes = 5935,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CLUSTER_OBJECT_ALREADY_USED</para>
        //        /// <para>MessageText: An attempt to use the specified cluster name failed because an enabled computer object with the given name already exists in the domain.</para>
        //        /// </summary>
        //        ClusterObjectAlreadyUsed = 5936,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_NONCORE_GROUPS_FOUND</para>
        //        /// <para>MessageText: This cluster cannot be destroyed. It has non-core application groups which must be deleted before the cluster can be destroyed.</para>
        //        /// </summary>
        //        NoncoreGroupsFound = 5937,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_FILE_SHARE_RESOURCE_CONFLICT</para>
        //        /// <para>MessageText: File share associated with file share witness resource cannot be hosted by this cluster or any of its nodes.</para>
        //        /// </summary>
        //        FileShareResourceConflict = 5938,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CLUSTER_EVICT_INVALID_REQUEST</para>
        //        /// <para>MessageText: Eviction of this node is invalid at this time. Due to quorum requirements node eviction will result in cluster shutdown.</para>
        //        /// </summary>
        //        ClusterEvictInvalidRequest = 5939,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CLUSTER_SINGLETON_RESOURCE</para>
        //        /// <para>MessageText: Only one instance of this resource type is allowed in the cluster.</para>
        //        /// </summary>
        //        ClusterSingletonResource = 5940,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CLUSTER_GROUP_SINGLETON_RESOURCE</para>
        //        /// <para>MessageText: Only one instance of this resource type is allowed per resource group.</para>
        //        /// </summary>
        //        ClusterGroupSingletonResource = 5941,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CLUSTER_RESOURCE_PROVIDER_FAILED</para>
        //        /// <para>MessageText: The resource failed to come online due to the failure of one or more provider resources.</para>
        //        /// </summary>
        //        ClusterResourceProviderFailed = 5942,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CLUSTER_RESOURCE_CONFIGURATION_ERROR</para>
        //        /// <para>MessageText: The resource has indicated that it cannot come online on any node.</para>
        //        /// </summary>
        //        ClusterResourceConfigurationError = 5943,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CLUSTER_GROUP_BUSY</para>
        //        /// <para>MessageText: The current operation cannot be performed on this group at this time.</para>
        //        /// </summary>
        //        ClusterGroupBusy = 5944,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CLUSTER_NOT_SHARED_VOLUME</para>
        //        /// <para>MessageText: The directory or file is not located on a cluster .Shared volume.</para>
        //        /// </summary>
        //        ClusterNot.SharedVolume = 5945,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CLUSTER_INVALID_SECURITY_DESCRIPTOR</para>
        //        /// <para>MessageText: The Security Descriptor does not meet the requirements for a cluster.</para>
        //        /// </summary>
        //        ClusterInvalidSecurityDescriptor = 5946,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CLUSTER_SHARED_VOLUMES_IN_USE</para>
        //        /// <para>MessageText: There is one or more .Shared volumes resources configured in the cluster.</para>
        //        /// </summary>
        //        Cluster.SharedVolumesInUse = 5947,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CLUSTER_USE_SHARED_VOLUMES_API</para>
        //        /// <para>MessageText: This group or resource cannot be directly manipulated.</para>
        //        /// </summary>
        //        ClusterUse.SharedVolumesApi = 5948,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CLUSTER_BACKUP_IN_PROGRESS</para>
        //        /// <para>MessageText: Back up is in progress. Please wait for backup completion before trying this operation again.</para>
        //        /// </summary>
        //        ClusterBackupInProgress = 5949,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_NON_CSV_PATH</para>
        //        /// <para>MessageText: The path does not belong to a cluster .Shared volume.</para>
        //        /// </summary>
        //        NonCsvPath = 5950,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CSV_VOLUME_NOT_LOCAL</para>
        //        /// <para>MessageText: The cluster .Shared volume is not locally mounted on this node.</para>
        //        /// </summary>
        //        CsvVolumeNotLocal = 5951,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CLUSTER_WATCHDOG_TERMINATING</para>
        //        /// <para>MessageText: The cluster watchdog is terminating.</para>
        //        /// </summary>
        //        ClusterWatchdogTerminating = 5952,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CLUSTER_RESOURCE_VETOED_MOVE_INCOMPATIBLE_NODES</para>
        //        /// <para>MessageText: A resource vetoed a move between two nodes because they are incompatible.</para>
        //        /// </summary>
        //        ClusterResourceVetoedMoveIncompatibleNodes = 5953,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CLUSTER_INVALID_NODE_WEIGHT</para>
        //        /// <para>MessageText: The request is invalid either because node weight cannot be changed while the cluster is in disk-only quorum mode, or because changing the node weight would violate the minimum cluster quorum requirements.</para>
        //        /// </summary>
        //        ClusterInvalidNodeWeight = 5954,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CLUSTER_RESOURCE_VETOED_CALL</para>
        //        /// <para>MessageText: The resource vetoed the call.</para>
        //        /// </summary>
        //        ClusterResourceVetoedCall = 5955,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_RESMON_SYSTEM_RESOURCES_LACKING</para>
        //        /// <para>MessageText: Resource could not start or run because it could not reserve sufficient system resources.</para>
        //        /// </summary>
        //        ResmonSystemResourcesLacking = 5956,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CLUSTER_RESOURCE_VETOED_MOVE_NOT_ENOUGH_RESOURCES_ON_DESTINATION</para>
        //        /// <para>MessageText: A resource vetoed a move between two nodes because the destination currently does not have enough resources to complete the operation.</para>
        //        /// </summary>
        //        ClusterResourceVetoedMoveNotEnoughResourcesOnDestination = 5957,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CLUSTER_RESOURCE_VETOED_MOVE_NOT_ENOUGH_RESOURCES_ON_SOURCE</para>
        //        /// <para>MessageText: </para>
        //        /// </summary>
        //        ClusterResourceVetoedMoveNotEnoughResourcesOnSource = 5958,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CLUSTER_GROUP_QUEUED</para>
        //        /// <para>MessageText: </para>
        //        /// </summary>
        //        ClusterGroupQueued = 5959,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CLUSTER_RESOURCE_LOCKED_STATUS</para>
        //        /// <para>MessageText: </para>
        //        /// </summary>
        //        ClusterResourceLockedStatus = 5960,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CLUSTER_SHARED_VOLUME_FAILOVER_NOT_ALLOWED</para>
        //        /// <para>MessageText: </para>
        //        /// </summary>
        //        Cluster.SharedVolumeFailoverNotAllowed = 5961,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CLUSTER_NODE_DRAIN_IN_PROGRESS</para>
        //        /// <para>MessageText: </para>
        //        /// </summary>
        //        ClusterNodeDrainInProgress = 5962,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CLUSTER_DISK_NOT_CONNECTED</para>
        //        /// <para>MessageText: </para>
        //        /// </summary>
        //        ClusterDiskNotConnected = 5963,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DISK_NOT_CSV_CAPABLE</para>
        //        /// <para>MessageText: </para>
        //        /// </summary>
        //        DiskNotCsvCapable = 5964,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_RESOURCE_NOT_IN_AVAILABLE_STORAGE</para>
        //        /// <para>MessageText: </para>
        //        /// </summary>
        //        ResourceNotInAvailableStorage = 5965,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CLUSTER_SHARED_VOLUME_REDIRECTED</para>
        //        /// <para>MessageText: </para>
        //        /// </summary>
        //        Cluster.SharedVolumeRedirected = 5966,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CLUSTER_SHARED_VOLUME_NOT_REDIRECTED</para>
        //        /// <para>MessageText: </para>
        //        /// </summary>
        //        Cluster.SharedVolumeNotRedirected = 5967,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CLUSTER_CANNOT_RETURN_PROPERTIES</para>
        //        /// <para>MessageText: </para>
        //        /// </summary>
        //        ClusterCannotReturnProperties = 5968,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CLUSTER_RESOURCE_CONTAINS_UNSUPPORTED_DIFF_AREA_FOR_SHARED_VOLUMES</para>
        //        /// <para>MessageText: </para>
        //        /// </summary>
        //        ClusterResourceContainsUnsupportedDiffAreaFor.SharedVolumes = 5969,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CLUSTER_RESOURCE_IS_IN_MAINTENANCE_MODE</para>
        //        /// <para>MessageText: </para>
        //        /// </summary>
        //        ClusterResourceIsInMaintenanceMode = 5970,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CLUSTER_AFFINITY_CONFLICT</para>
        //        /// <para>MessageText: </para>
        //        /// </summary>
        //        ClusterAffinityConflict = 5971,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CLUSTER_RESOURCE_IS_REPLICA_VIRTUAL_MACHINE</para>
        //        /// <para>MessageText: </para>
        //        /// </summary>
        //        ClusterResourceIsReplicaVirtualMachine = 5972,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CLUSTER_UPGRADE_INCOMPATIBLE_VERSIONS</para>
        //        /// <para>MessageText: </para>
        //        /// </summary>
        //        ClusterUpgradeIncompatibleVersions = 5973,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CLUSTER_UPGRADE_FIX_QUORUM_NOT_SUPPORTED</para>
        //        /// <para>MessageText: </para>
        //        /// </summary>
        //        ClusterUpgradeFixQuorumNotSupported = 5974,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CLUSTER_UPGRADE_RESTART_REQUIRED</para>
        //        /// <para>MessageText: </para>
        //        /// </summary>
        //        ClusterUpgradeRestartRequired = 5975,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CLUSTER_UPGRADE_IN_PROGRESS</para>
        //        /// <para>MessageText: </para>
        //        /// </summary>
        //        ClusterUpgradeInProgress = 5976,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CLUSTER_UPGRADE_INCOMPLETE</para>
        //        /// <para>MessageText: </para>
        //        /// </summary>
        //        ClusterUpgradeIncomplete = 5977,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CLUSTER_NODE_IN_GRACE_PERIOD</para>
        //        /// <para>MessageText: </para>
        //        /// </summary>
        //        ClusterNodeInGracePeriod = 5978,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CLUSTER_CSV_IO_PAUSE_TIMEOUT</para>
        //        /// <para>MessageText: </para>
        //        /// </summary>
        //        ClusterCsvIoPauseTimeout = 5979,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_NODE_NOT_ACTIVE_CLUSTER_MEMBER</para>
        //        /// <para>MessageText: </para>
        //        /// </summary>
        //        NodeNotActiveClusterMember = 5980,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CLUSTER_RESOURCE_NOT_MONITORED</para>
        //        /// <para>MessageText: </para>
        //        /// </summary>
        //        ClusterResourceNotMonitored = 5981,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CLUSTER_RESOURCE_DOES_NOT_SUPPORT_UNMONITORED</para>
        //        /// <para>MessageText: </para>
        //        /// </summary>
        //        ClusterResourceDoesNotSupportUnmonitored = 5982,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CLUSTER_RESOURCE_IS_REPLICATED</para>
        //        /// <para>MessageText: </para>
        //        /// </summary>
        //        ClusterResourceIsReplicated = 5983,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CLUSTER_NODE_ISOLATED</para>
        //        /// <para>MessageText: </para>
        //        /// </summary>
        //        ClusterNodeIsolated = 5984,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CLUSTER_NODE_QUARANTINED</para>
        //        /// <para>MessageText: </para>
        //        /// </summary>
        //        ClusterNodeQuarantined = 5985,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CLUSTER_DATABASE_UPDATE_CONDITION_FAILED</para>
        //        /// <para>MessageText: </para>
        //        /// </summary>
        //        ClusterDatabaseUpdateConditionFailed = 5986,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CLUSTER_SPACE_DEGRADED</para>
        //        /// <para>MessageText: </para>
        //        /// </summary>
        //        ClusterSpaceDegraded = 5987,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CLUSTER_TOKEN_DELEGATION_NOT_SUPPORTED</para>
        //        /// <para>MessageText: </para>
        //        /// </summary>
        //        ClusterTokenDelegationNotSupported = 5988,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CLUSTER_CSV_INVALID_HANDLE</para>
        //        /// <para>MessageText: </para>
        //        /// </summary>
        //        ClusterCsvInvalidHandle = 5989,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CLUSTER_CSV_SUPPORTED_ONLY_ON_COORDINATOR</para>
        //        /// <para>MessageText: </para>
        //        /// </summary>
        //        ClusterCsvSupportedOnlyOnCoordinator = 5990,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_GROUPSET_NOT_AVAILABLE</para>
        //        /// <para>MessageText: </para>
        //        /// </summary>
        //        GroupsetNotAvailable = 5991,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_GROUPSET_NOT_FOUND</para>
        //        /// <para>MessageText: </para>
        //        /// </summary>
        //        GroupsetNotFound = 5992,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_GROUPSET_CANT_PROVIDE</para>
        //        /// <para>MessageText: </para>
        //        /// </summary>
        //        GroupsetCantProvide = 5993,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CLUSTER_FAULT_DOMAIN_PARENT_NOT_FOUND</para>
        //        /// <para>MessageText: </para>
        //        /// </summary>
        //        ClusterFaultDomainParentNotFound = 5994,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CLUSTER_FAULT_DOMAIN_INVALID_HIERARCHY</para>
        //        /// <para>MessageText: </para>
        //        /// </summary>
        //        ClusterFaultDomainInvalidHierarchy = 5995,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CLUSTER_FAULT_DOMAIN_FAILED_S2D_VALIDATION</para>
        //        /// <para>MessageText: </para>
        //        /// </summary>
        //        ClusterFaultDomainFailedS2dValidation = 5996,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CLUSTER_FAULT_DOMAIN_S2D_CONNECTIVITY_LOSS</para>
        //        /// <para>MessageText: </para>
        //        /// </summary>
        //        ClusterFaultDomainS2dConnectivityLoss = 5997,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CLUSTER_INVALID_INFRASTRUCTURE_FILESERVER_NAME</para>
        //        /// <para>MessageText: </para>
        //        /// </summary>
        //        ClusterInvalidInfrastructureFileserverName = 5998,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CLUSTERSET_MANAGEMENT_CLUSTER_UNREACHABLE</para>
        //        /// <para>MessageText: </para>
        //        /// </summary>
        //        ClustersetManagementClusterUnreachable = 5999,



        /// <summary>
        /// <para>MessageId: ERROR_ENCRYPTION_FAILED</para>
        /// <para>MessageText: The specified file could not be encrypted.</para>
        /// </summary>
        EncryptionFailed = 6000,

        /// <summary>
        /// <para>MessageId: ERROR_DECRYPTION_FAILED</para>
        /// <para>MessageText: The specified file could not be decrypted.</para>
        /// </summary>
        DecryptionFailed = 6001,

        /// <summary>
        /// <para>MessageId: ERROR_FILE_ENCRYPTED</para>
        /// <para>MessageText: The specified file is encrypted and the user does not have the ability to decrypt it.</para>
        /// </summary>
        FileEncrypted = 6002,

        /// <summary>
        /// <para>MessageId: ERROR_NO_RECOVERY_POLICY</para>
        /// <para>MessageText: There is no valid encryption recovery policy configured for this system.</para>
        /// </summary>
        NoRecoveryPolicy = 6003,

        /// <summary>
        /// <para>MessageId: ERROR_NO_EFS</para>
        /// <para>MessageText: The required encryption driver is not loaded for this system.</para>
        /// </summary>
        NoEFS = 6004,

        /// <summary>
        /// <para>MessageId: ERROR_WRONG_EFS</para>
        /// <para>MessageText: The file was encrypted with a different encryption driver than is currently loaded.</para>
        /// </summary>
        WrongEFS = 6005,

        /// <summary>
        /// <para>MessageId: ERROR_NO_USER_KEYS</para>
        /// <para>MessageText: There are no EFS keys defined for the user.</para>
        /// </summary>
        NoUserKeys = 6006,

        /// <summary>
        /// <para>MessageId: ERROR_FILE_NOT_ENCRYPTED</para>
        /// <para>MessageText: The specified file is not encrypted.</para>
        /// </summary>
        FileNotEncrypted = 6007,

        /// <summary>
        /// <para>MessageId: ERROR_NOT_EXPORT_FORMAT</para>
        /// <para>MessageText: The specified file is not in the defined EFS export format.</para>
        /// </summary>
        NotExportFormat = 6008,

        /// <summary>
        /// <para>MessageId: ERROR_FILE_READ_ONLY</para>
        /// <para>MessageText: The specified file is read only.</para>
        /// </summary>
        FileReadOnly = 6009,

        /// <summary>
        /// <para>MessageId: ERROR_DIR_EFS_DISALLOWED</para>
        /// <para>MessageText: The directory has been disabled for encryption.</para>
        /// </summary>
        DirEFSDisallowed = 6010,

        /// <summary>
        /// <para>MessageId: ERROR_EFS_SERVER_NOT_TRUSTED</para>
        /// <para>MessageText: The server is not trusted for remote encryption operation.</para>
        /// </summary>
        EFSServerNotTrusted = 6011,

        /// <summary>
        /// <para>MessageId: ERROR_BAD_RECOVERY_POLICY</para>
        /// <para>MessageText: Recovery policy configured for this system contains invalid recovery certificate.</para>
        /// </summary>
        BadRecoveryPolicy = 6012,

        /// <summary>
        /// <para>MessageId: ERROR_EFS_ALG_BLOB_TOO_BIG</para>
        /// <para>MessageText: The encryption algorithm used on the source file needs a bigger key buffer than the one on the destination file.</para>
        /// </summary>
        EFSAlgBlobTooBig = 6013,

        /// <summary>
        /// <para>MessageId: ERROR_VOLUME_NOT_SUPPORT_EFS</para>
        /// <para>MessageText: The disk partition does not support file encryption.</para>
        /// </summary>
        VolumeNotSupportEFS = 6014,

        /// <summary>
        /// <para>MessageId: ERROR_EFS_DISABLED</para>
        /// <para>MessageText: This machine is disabled for file encryption.</para>
        /// </summary>
        EFSDisabled = 6015,

        /// <summary>
        /// <para>MessageId: ERROR_EFS_VERSION_NOT_SUPPORT</para>
        /// <para>MessageText: A newer system is required to decrypt this encrypted file.</para>
        /// </summary>
        EFSVersionNotSupport = 6016,

        /// <summary>
        /// <para>MessageId: ERROR_CS_ENCRYPTION_INVALID_SERVER_RESPONSE</para>
        /// <para>MessageText: The remote server sent an invalid response for a file being opened with Client Side Encryption.</para>
        /// </summary>
        CSEncryptionInvalidServerResponse = 6017,

        /// <summary>
        /// <para>MessageId: ERROR_CS_ENCRYPTION_UNSUPPORTED_SERVER</para>
        /// <para>MessageText: Client Side Encryption is not supported by the remote server even though it claims to support it.</para>
        /// </summary>
        CSEncryptionUnsupportedServer = 6018,

        /// <summary>
        /// <para>MessageId: ERROR_CS_ENCRYPTION_EXISTING_ENCRYPTED_FILE</para>
        /// <para>MessageText: File is encrypted and should be opened in Client Side Encryption mode.</para>
        /// </summary>
        CSEncryptionExistingEncryptedFile = 6019,

        /// <summary>
        /// <para>MessageId: ERROR_CS_ENCRYPTION_NEW_ENCRYPTED_FILE</para>
        /// <para>MessageText: A new encrypted file is being created and a $EFS needs to be provided.</para>
        /// </summary>
        CSEncryptionNewEncryptedFile = 6020,

        /// <summary>
        /// <para>MessageId: ERROR_CS_ENCRYPTION_FILE_NOT_CSE</para>
        /// <para>MessageText: The SMB client requested a CSE FSCTL on a non-CSE file.</para>
        /// </summary>
        CSEncryptionFileNotCSE = 6021,

        /// <summary>
        /// <para>MessageId: ERROR_ENCRYPTION_POLICY_DENIES_OPERATION</para>
        /// <para>MessageText: The requested operation was blocked by policy. For more information, contact your system administrator.</para>
        /// </summary>
        EncryptionPolicyDeniesOperation = 6022,

        /// <summary>
        /// <para>MessageId: ERROR_WIP_ENCRYPTION_FAILED</para>
        /// <para>MessageText: The specified file could not be encrypted with Windows Information Protection.</para>
        /// </summary>
        WIPEncryptionFailed = 6023,



        /// <summary>
        /// <para>MessageId: ERROR_NO_BROWSER_SERVERS_FOUND</para>
        /// <para>MessageText: The list of servers for this workgroup is not currently available</para>
        /// </summary>
        NoBrowserServersFound = 6118,



        /// <summary>
        /// <para>MessageId: SCHED_E_SERVICE_NOT_LOCALSYSTEM</para>
        /// <para>MessageText: The Task Scheduler service must be configured to run in the System account to function properly. Individual tasks may be configured to run in other accounts.</para>
        /// </summary>
        ScheduledErrorServiceNotLocalSystem = 6200,



        /// <summary>
        /// <para>MessageId: ERROR_LOG_SECTOR_INVALID</para>
        /// <para>MessageText: Log service encountered an invalid log sector.</para>
        /// </summary>
        LogSectorInvalid = 6600,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_LOG_SECTOR_PARITY_INVALID</para>
        //        /// <para>MessageText: Log service encountered a log sector with invalid block parity.</para>
        //        /// </summary>
        //        LogSectorParityInvalid = 6601,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_LOG_SECTOR_REMAPPED</para>
        //        /// <para>MessageText: Log service encountered a remapped log sector.</para>
        //        /// </summary>
        //        LogSectorRemapped = 6602,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_LOG_BLOCK_INCOMPLETE</para>
        //        /// <para>MessageText: Log service encountered a partial or incomplete log block.</para>
        //        /// </summary>
        //        LogBlockIncomplete = 6603,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_LOG_INVALID_RANGE</para>
        //        /// <para>MessageText: Log service encountered an attempt access data outside the active log range.</para>
        //        /// </summary>
        //        LogInvalidRange = 6604,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_LOG_BLOCKS_EXHAUSTED</para>
        //        /// <para>MessageText: Log service user marshalling buffers are exhausted.</para>
        //        /// </summary>
        //        LogBlocksExhausted = 6605,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_LOG_READ_CONTEXT_INVALID</para>
        //        /// <para>MessageText: Log service encountered an attempt read from a marshalling area with an invalid read context.</para>
        //        /// </summary>
        //        LogReadContextInvalid = 6606,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_LOG_RESTART_INVALID</para>
        //        /// <para>MessageText: Log service encountered an invalid log restart area.</para>
        //        /// </summary>
        //        LogRestartInvalid = 6607,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_LOG_BLOCK_VERSION</para>
        //        /// <para>MessageText: Log service encountered an invalid log block version.</para>
        //        /// </summary>
        //        LogBlockVersion = 6608,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_LOG_BLOCK_INVALID</para>
        //        /// <para>MessageText: Log service encountered an invalid log block.</para>
        //        /// </summary>
        //        LogBlockInvalid = 6609,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_LOG_READ_MODE_INVALID</para>
        //        /// <para>MessageText: Log service encountered an attempt to read the log with an invalid read mode.</para>
        //        /// </summary>
        //        LogReadModeInvalid = 6610,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_LOG_NO_RESTART</para>
        //        /// <para>MessageText: Log service encountered a log stream with no restart area.</para>
        //        /// </summary>
        //        LogNoRestart = 6611,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_LOG_METADATA_CORRUPT</para>
        //        /// <para>MessageText: Log service encountered a corrupted metadata file.</para>
        //        /// </summary>
        //        LogMetadataCorrupt = 6612,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_LOG_METADATA_INVALID</para>
        //        /// <para>MessageText: Log service encountered a metadata file that could not be created by the log file system.</para>
        //        /// </summary>
        //        LogMetadataInvalid = 6613,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_LOG_METADATA_INCONSISTENT</para>
        //        /// <para>MessageText: Log service encountered a metadata file with inconsistent data.</para>
        //        /// </summary>
        //        LogMetadataInconsistent = 6614,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_LOG_RESERVATION_INVALID</para>
        //        /// <para>MessageText: Log service encountered an attempt to erroneous allocate or dispose reservation space.</para>
        //        /// </summary>
        //        LogReservationInvalid = 6615,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_LOG_CANT_DELETE</para>
        //        /// <para>MessageText: Log service cannot delete log file or file system container.</para>
        //        /// </summary>
        //        LogCantDelete = 6616,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_LOG_CONTAINER_LIMIT_EXCEEDED</para>
        //        /// <para>MessageText: Log service has reached the maximum allowable containers allocated to a log file.</para>
        //        /// </summary>
        //        LogContainerLimitExceeded = 6617,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_LOG_START_OF_LOG</para>
        //        /// <para>MessageText: Log service has attempted to read or write backward past the start of the log.</para>
        //        /// </summary>
        //        LogStartOfLog = 6618,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_LOG_POLICY_ALREADY_INSTALLED</para>
        //        /// <para>MessageText: Log policy could not be installed because a policy of the same type is already present.</para>
        //        /// </summary>
        //        LogPolicyAlreadyInstalled = 6619,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_LOG_POLICY_NOT_INSTALLED</para>
        //        /// <para>MessageText: Log policy in question was not installed at the time of the request.</para>
        //        /// </summary>
        //        LogPolicyNotInstalled = 6620,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_LOG_POLICY_INVALID</para>
        //        /// <para>MessageText: The installed set of policies on the log is invalid.</para>
        //        /// </summary>
        //        LogPolicyInvalid = 6621,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_LOG_POLICY_CONFLICT</para>
        //        /// <para>MessageText: A policy on the log in question prevented the operation from completing.</para>
        //        /// </summary>
        //        LogPolicyConflict = 6622,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_LOG_PINNED_ARCHIVE_TAIL</para>
        //        /// <para>MessageText: Log space cannot be reclaimed because the log is pinned by the archive tail.</para>
        //        /// </summary>
        //        LogPinnedArchiveTail = 6623,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_LOG_RECORD_NONEXISTENT</para>
        //        /// <para>MessageText: Log record is not a record in the log file.</para>
        //        /// </summary>
        //        LogRecordNonexistent = 6624,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_LOG_RECORDS_RESERVED_INVALID</para>
        //        /// <para>MessageText: Number of reserved log records or the adjustment of the number of reserved log records is invalid.</para>
        //        /// </summary>
        //        LogRecordsReservedInvalid = 6625,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_LOG_SPACE_RESERVED_INVALID</para>
        //        /// <para>MessageText: Reserved log space or the adjustment of the log space is invalid.</para>
        //        /// </summary>
        //        LogSpaceReservedInvalid = 6626,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_LOG_TAIL_INVALID</para>
        //        /// <para>MessageText: An new or existing archive tail or base of the active log is invalid.</para>
        //        /// </summary>
        //        LogTailInvalid = 6627,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_LOG_FULL</para>
        //        /// <para>MessageText: Log space is exhausted.</para>
        //        /// </summary>
        //        LogFull = 6628,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_COULD_NOT_RESIZE_LOG</para>
        //        /// <para>MessageText: The log could not be set to the requested size.</para>
        //        /// </summary>
        //        CouldNotResizeLog = 6629,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_LOG_MULTIPLEXED</para>
        //        /// <para>MessageText: Log is multiplexed, no direct writes to the physical log is allowed.</para>
        //        /// </summary>
        //        LogMultiplexed = 6630,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_LOG_DEDICATED</para>
        //        /// <para>MessageText: The operation failed because the log is a dedicated log.</para>
        //        /// </summary>
        //        LogDedicated = 6631,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_LOG_ARCHIVE_NOT_IN_PROGRESS</para>
        //        /// <para>MessageText: The operation requires an archive context.</para>
        //        /// </summary>
        //        LogArchiveNotInProgress = 6632,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_LOG_ARCHIVE_IN_PROGRESS</para>
        //        /// <para>MessageText: Log archival is in progress.</para>
        //        /// </summary>
        //        LogArchiveInProgress = 6633,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_LOG_EPHEMERAL</para>
        //        /// <para>MessageText: The operation requires a non-ephemeral log, but the log is ephemeral.</para>
        //        /// </summary>
        //        LogEphemeral = 6634,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_LOG_NOT_ENOUGH_CONTAINERS</para>
        //        /// <para>MessageText: The log must have at least two containers before it can be read from or written to.</para>
        //        /// </summary>
        //        LogNotEnoughContainers = 6635,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_LOG_CLIENT_ALREADY_REGISTERED</para>
        //        /// <para>MessageText: A log client has already registered on the stream.</para>
        //        /// </summary>
        //        LogClientAlreadyRegistered = 6636,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_LOG_CLIENT_NOT_REGISTERED</para>
        //        /// <para>MessageText: A log client has not been registered on the stream.</para>
        //        /// </summary>
        //        LogClientNotRegistered = 6637,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_LOG_FULL_HANDLER_IN_PROGRESS</para>
        //        /// <para>MessageText: A request has already been made to handle the log full condition.</para>
        //        /// </summary>
        //        LogFullHandlerInProgress = 6638,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_LOG_CONTAINER_READ_FAILED</para>
        //        /// <para>MessageText: Log service encountered an error when attempting to read from a log container.</para>
        //        /// </summary>
        //        LogContainerReadFailed = 6639,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_LOG_CONTAINER_WRITE_FAILED</para>
        //        /// <para>MessageText: Log service encountered an error when attempting to write to a log container.</para>
        //        /// </summary>
        //        LogContainerWriteFailed = 6640,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_LOG_CONTAINER_OPEN_FAILED</para>
        //        /// <para>MessageText: Log service encountered an error when attempting open a log container.</para>
        //        /// </summary>
        //        LogContainerOpenFailed = 6641,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_LOG_CONTAINER_STATE_INVALID</para>
        //        /// <para>MessageText: Log service encountered an invalid container state when attempting a requested action.</para>
        //        /// </summary>
        //        LogContainerStateInvalid = 6642,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_LOG_STATE_INVALID</para>
        //        /// <para>MessageText: Log service is not in the correct state to perform a requested action.</para>
        //        /// </summary>
        //        LogStateInvalid = 6643,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_LOG_PINNED</para>
        //        /// <para>MessageText: Log space cannot be reclaimed because the log is pinned.</para>
        //        /// </summary>
        //        LogPinned = 6644,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_LOG_METADATA_FLUSH_FAILED</para>
        //        /// <para>MessageText: Log metadata flush failed.</para>
        //        /// </summary>
        //        LogMetadataFlushFailed = 6645,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_LOG_INCONSISTENT_SECURITY</para>
        //        /// <para>MessageText: Security on the log and its containers is inconsistent.</para>
        //        /// </summary>
        //        LogInconsistentSecurity = 6646,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_LOG_APPENDED_FLUSH_FAILED</para>
        //        /// <para>MessageText: Records were appended to the log or reservation changes were made, but the log could not be flushed.</para>
        //        /// </summary>
        //        LogAppendedFlushFailed = 6647,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_LOG_PINNED_RESERVATION</para>
        //        /// <para>MessageText: The log is pinned due to reservation consuming most of the log space. Free some reserved records to make space available.</para>
        //        /// </summary>
        //        LogPinnedReservation = 6648,



        //        /// <summary>
        //        /// <para>MessageId: ERROR_INVALID_TRANSACTION</para>
        //        /// <para>MessageText: The transaction handle associated with this operation is not valid.</para>
        //        /// </summary>
        //        InvalidTransaction = 6700,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_TRANSACTION_NOT_ACTIVE</para>
        //        /// <para>MessageText: The requested operation was made in the context of a transaction that is no longer active.</para>
        //        /// </summary>
        //        TransactionNotActive = 6701,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_TRANSACTION_REQUEST_NOT_VALID</para>
        //        /// <para>MessageText: The requested operation is not valid on the Transaction object in its current state.</para>
        //        /// </summary>
        //        TransactionRequestNotValid = 6702,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_TRANSACTION_NOT_REQUESTED</para>
        //        /// <para>MessageText: The caller has called a response API, but the response is not expected because the TM did not issue the corresponding request to the caller.</para>
        //        /// </summary>
        //        TransactionNotRequested = 6703,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_TRANSACTION_ALREADY_ABORTED</para>
        //        /// <para>MessageText: It is too late to perform the requested operation, since the Transaction has already been aborted.</para>
        //        /// </summary>
        //        TransactionAlreadyAborted = 6704,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_TRANSACTION_ALREADY_COMMITTED</para>
        //        /// <para>MessageText: It is too late to perform the requested operation, since the Transaction has already been committed.</para>
        //        /// </summary>
        //        TransactionAlreadyCommitted = 6705,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_TM_INITIALIZATION_FAILED</para>
        //        /// <para>MessageText: The Transaction Manager was unable to be successfully initialized. Transacted operations are not supported.</para>
        //        /// </summary>
        //        TmInitializationFailed = 6706,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_RESOURCEMANAGER_READ_ONLY</para>
        //        /// <para>MessageText: The specified ResourceManager made no changes or updates to the resource under this transaction.</para>
        //        /// </summary>
        //        ResourcemanagerReadOnly = 6707,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_TRANSACTION_NOT_JOINED</para>
        //        /// <para>MessageText: The resource manager has attempted to prepare a transaction that it has not successfully joined.</para>
        //        /// </summary>
        //        TransactionNotJoined = 6708,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_TRANSACTION_SUPERIOR_EXISTS</para>
        //        /// <para>MessageText: The Transaction object already has a superior enlistment, and the caller attempted an operation that would have created a new superior. Only a single superior enlistment is allow.</para>
        //        /// </summary>
        //        TransactionSuperiorExists = 6709,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CRM_PROTOCOL_ALREADY_EXISTS</para>
        //        /// <para>MessageText: The RM tried to register a protocol that already exists.</para>
        //        /// </summary>
        //        CrmProtocolAlreadyExists = 6710,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_TRANSACTION_PROPAGATION_FAILED</para>
        //        /// <para>MessageText: The attempt to propagate the Transaction failed.</para>
        //        /// </summary>
        //        TransactionPropagationFailed = 6711,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CRM_PROTOCOL_NOT_FOUND</para>
        //        /// <para>MessageText: The requested propagation protocol was not registered as a CRM.</para>
        //        /// </summary>
        //        CrmProtocolNotFound = 6712,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_TRANSACTION_INVALID_MARSHALL_BUFFER</para>
        //        /// <para>MessageText: The buffer passed in to PushTransaction or PullTransaction is not in a valid format.</para>
        //        /// </summary>
        //        TransactionInvalidMarshallBuffer = 6713,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CURRENT_TRANSACTION_NOT_VALID</para>
        //        /// <para>MessageText: The current transaction context associated with the thread is not a valid handle to a transaction object.</para>
        //        /// </summary>
        //        CurrentTransactionNotValid = 6714,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_TRANSACTION_NOT_FOUND</para>
        //        /// <para>MessageText: The specified Transaction object could not be opened, because it was not found.</para>
        //        /// </summary>
        //        TransactionNotFound = 6715,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_RESOURCEMANAGER_NOT_FOUND</para>
        //        /// <para>MessageText: The specified ResourceManager object could not be opened, because it was not found.</para>
        //        /// </summary>
        //        ResourcemanagerNotFound = 6716,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_ENLISTMENT_NOT_FOUND</para>
        //        /// <para>MessageText: The specified Enlistment object could not be opened, because it was not found.</para>
        //        /// </summary>
        //        EnlistmentNotFound = 6717,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_TRANSACTIONMANAGER_NOT_FOUND</para>
        //        /// <para>MessageText: The specified TransactionManager object could not be opened, because it was not found.</para>
        //        /// </summary>
        //        TransactionmanagerNotFound = 6718,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_TRANSACTIONMANAGER_NOT_ONLINE</para>
        //        /// <para>MessageText: The object specified could not be created or opened, because its associated TransactionManager is not online.  The TransactionManager must be brought fully Online by calling RecoverTransactionManager to recover to the end of its LogFile before objects in its Transaction or ResourceManager namespaces can be opened.  In addition, errors in writing records to its LogFile can cause a TransactionManager to go offline.</para>
        //        /// </summary>
        //        TransactionmanagerNotOnline = 6719,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_TRANSACTIONMANAGER_RECOVERY_NAME_COLLISION</para>
        //        /// <para>MessageText: The specified TransactionManager was unable to create the objects contained in its logfile in the Ob namespace. Therefore, the TransactionManager was unable to recover.</para>
        //        /// </summary>
        //        TransactionmanagerRecoveryNameCollision = 6720,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_TRANSACTION_NOT_ROOT</para>
        //        /// <para>MessageText: The call to create a superior Enlistment on this Transaction object could not be completed, because the Transaction object specified for the enlistment is a subordinate branch of the Transaction. Only the root of the Transaction can be enlisted on as a superior.</para>
        //        /// </summary>
        //        TransactionNotRoot = 6721,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_TRANSACTION_OBJECT_EXPIRED</para>
        //        /// <para>MessageText: Because the associated transaction manager or resource manager has been closed, the handle is no longer valid.</para>
        //        /// </summary>
        //        TransactionObjectExpired = 6722,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_TRANSACTION_RESPONSE_NOT_ENLISTED</para>
        //        /// <para>MessageText: The specified operation could not be performed on this Superior enlistment, because the enlistment was not created with the corresponding completion response in the NotificationMask.</para>
        //        /// </summary>
        //        TransactionResponseNotEnlisted = 6723,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_TRANSACTION_RECORD_TOO_LONG</para>
        //        /// <para>MessageText: The specified operation could not be performed, because the record that would be logged was too long. This can occur because of two conditions: either there are too many Enlistments on this Transaction, or the combined RecoveryInformation being logged on behalf of those Enlistments is too long.</para>
        //        /// </summary>
        //        TransactionRecordTooLong = 6724,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_IMPLICIT_TRANSACTION_NOT_SUPPORTED</para>
        //        /// <para>MessageText: Implicit transaction are not supported.</para>
        //        /// </summary>
        //        ImplicitTransactionNotSupported = 6725,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_TRANSACTION_INTEGRITY_VIOLATED</para>
        //        /// <para>MessageText: The kernel transaction manager had to abort or forget the transaction because it blocked forward progress.</para>
        //        /// </summary>
        //        TransactionIntegrityViolated = 6726,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_TRANSACTIONMANAGER_IDENTITY_MISMATCH</para>
        //        /// <para>MessageText: The TransactionManager identity that was supplied did not match the one recorded in the TransactionManager's log file.</para>
        //        /// </summary>
        //        TransactionmanagerIdentityMismatch = 6727,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_RM_CANNOT_BE_FROZEN_FOR_SNAPSHOT</para>
        //        /// <para>MessageText: This snapshot operation cannot continue because a transactional resource manager cannot be frozen in its current state.  Please try again.</para>
        //        /// </summary>
        //        RmCannotBeFrozenForSnapshot = 6728,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_TRANSACTION_MUST_WRITETHROUGH</para>
        //        /// <para>MessageText: The transaction cannot be enlisted on with the specified EnlistmentMask, because the transaction has already completed the PrePrepare phase.  In order to ensure correctness, the ResourceManager must switch to a write-through mode and cease caching data within this transaction.  Enlisting for only subsequent transaction phases may still succeed.</para>
        //        /// </summary>
        //        TransactionMustWritethrough = 6729,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_TRANSACTION_NO_SUPERIOR</para>
        //        /// <para>MessageText: The transaction does not have a superior enlistment.</para>
        //        /// </summary>
        //        TransactionNoSuperior = 6730,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_HEURISTIC_DAMAGE_POSSIBLE</para>
        //        /// <para>MessageText: The attempt to commit the Transaction completed, but it is possible that some portion of the transaction tree did not commit successfully due to heuristics.  Therefore it is possible that some data modified in the transaction may not have committed, resulting in transactional inconsistency.  If possible, check the consistency of the associated data.</para>
        //        /// </summary>
        //        HeuristicDamagePossible = 6731,



        //        /// <summary>
        //        /// <para>MessageId: ERROR_TRANSACTIONAL_CONFLICT</para>
        //        /// <para>MessageText: The function attempted to use a name that is reserved for use by another transaction.</para>
        //        /// </summary>
        //        TransactionalConflict = 6800,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_RM_NOT_ACTIVE</para>
        //        /// <para>MessageText: Transaction support within the specified resource manager is not started or was shut down due to an error.</para>
        //        /// </summary>
        //        RmNotActive = 6801,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_RM_METADATA_CORRUPT</para>
        //        /// <para>MessageText: The metadata of the RM has been corrupted. The RM will not function.</para>
        //        /// </summary>
        //        RmMetadataCorrupt = 6802,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DIRECTORY_NOT_RM</para>
        //        /// <para>MessageText: The specified directory does not contain a resource manager.</para>
        //        /// </summary>
        //        DirectoryNotRm = 6803,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_TRANSACTIONS_UNSUPPORTED_REMOTE</para>
        //        /// <para>MessageText: The remote server or share does not support transacted file operations.</para>
        //        /// </summary>
        //        TransactionsUnsupportedRemote = 6805,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_LOG_RESIZE_INVALID_SIZE</para>
        //        /// <para>MessageText: The requested log size is invalid.</para>
        //        /// </summary>
        //        LogResizeInvalidSize = 6806,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_OBJECT_NO_LONGER_EXISTS</para>
        //        /// <para>MessageText: The object (file, stream, link) corresponding to the handle has been deleted by a Transaction Savepoint Rollback.</para>
        //        /// </summary>
        //        ObjectNoLongerExists = 6807,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_STREAM_MINIVERSION_NOT_FOUND</para>
        //        /// <para>MessageText: The specified file miniversion was not found for this transacted file open.</para>
        //        /// </summary>
        //        StreamMiniversionNotFound = 6808,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_STREAM_MINIVERSION_NOT_VALID</para>
        //        /// <para>MessageText: The specified file miniversion was found but has been invalidated. Most likely cause is a transaction savepoint rollback.</para>
        //        /// </summary>
        //        StreamMiniversionNotValid = 6809,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_MINIVERSION_INACCESSIBLE_FROM_SPECIFIED_TRANSACTION</para>
        //        /// <para>MessageText: A miniversion may only be opened in the context of the transaction that created it.</para>
        //        /// </summary>
        //        MiniversionInaccessibleFromSpecifiedTransaction = 6810,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CANT_OPEN_MINIVERSION_WITH_MODIFY_INTENT</para>
        //        /// <para>MessageText: It is not possible to open a miniversion with modify access.</para>
        //        /// </summary>
        //        CantOpenMiniversionWithModifyIntent = 6811,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CANT_CREATE_MORE_STREAM_MINIVERSIONS</para>
        //        /// <para>MessageText: It is not possible to create any more miniversions for this stream.</para>
        //        /// </summary>
        //        CantCreateMoreStreamMiniversions = 6812,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_REMOTE_FILE_VERSION_MISMATCH</para>
        //        /// <para>MessageText: The remote server sent mismatching version number or Fid for a file opened with transactions.</para>
        //        /// </summary>
        //        RemoteFileVersionMismatch = 6814,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_HANDLE_NO_LONGER_VALID</para>
        //        /// <para>MessageText: The handle has been invalidated by a transaction. The most likely cause is the presence of memory mapping on a file or an open handle when the transaction ended or rolled back to savepoint.</para>
        //        /// </summary>
        //        HandleNoLongerValid = 6815,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_NO_TXF_METADATA</para>
        //        /// <para>MessageText: There is no transaction metadata on the file.</para>
        //        /// </summary>
        //        NoTxfMetadata = 6816,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_LOG_CORRUPTION_DETECTED</para>
        //        /// <para>MessageText: The log data is corrupt.</para>
        //        /// </summary>
        //        LogCorruptionDetected = 6817,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CANT_RECOVER_WITH_HANDLE_OPEN</para>
        //        /// <para>MessageText: The file can't be recovered because there is a handle still open on it.</para>
        //        /// </summary>
        //        CantRecoverWithHandleOpen = 6818,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_RM_DISCONNECTED</para>
        //        /// <para>MessageText: The transaction outcome is unavailable because the resource manager responsible for it has disconnected.</para>
        //        /// </summary>
        //        RmDisconnected = 6819,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_ENLISTMENT_NOT_SUPERIOR</para>
        //        /// <para>MessageText: The request was rejected because the enlistment in question is not a superior enlistment.</para>
        //        /// </summary>
        //        EnlistmentNotSuperior = 6820,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_RECOVERY_NOT_NEEDED</para>
        //        /// <para>MessageText: The transactional resource manager is already consistent. Recovery is not needed.</para>
        //        /// </summary>
        //        RecoveryNotNeeded = 6821,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_RM_ALREADY_STARTED</para>
        //        /// <para>MessageText: The transactional resource manager has already been started.</para>
        //        /// </summary>
        //        RmAlreadyStarted = 6822,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_FILE_IDENTITY_NOT_PERSISTENT</para>
        //        /// <para>MessageText: The file cannot be opened transactionally, because its identity depends on the outcome of an unresolved transaction.</para>
        //        /// </summary>
        //        FileIdentityNotPersistent = 6823,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CANT_BREAK_TRANSACTIONAL_DEPENDENCY</para>
        //        /// <para>MessageText: The operation cannot be performed because another transaction is depending on the fact that this property will not change.</para>
        //        /// </summary>
        //        CantBreakTransactionalDependency = 6824,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CANT_CROSS_RM_BOUNDARY</para>
        //        /// <para>MessageText: The operation would involve a single file with two transactional resource managers and is therefore not allowed.</para>
        //        /// </summary>
        //        CantCrossRmBoundary = 6825,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_TXF_DIR_NOT_EMPTY</para>
        //        /// <para>MessageText: The $Txf directory must be empty for this operation to succeed.</para>
        //        /// </summary>
        //        TxfDirNotEmpty = 6826,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_INDOUBT_TRANSACTIONS_EXIST</para>
        //        /// <para>MessageText: The operation would leave a transactional resource manager in an inconsistent state and is therefore not allowed.</para>
        //        /// </summary>
        //        IndoubtTransactionsExist = 6827,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_TM_VOLATILE</para>
        //        /// <para>MessageText: The operation could not be completed because the transaction manager does not have a log.</para>
        //        /// </summary>
        //        TmVolatile = 6828,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_ROLLBACK_TIMER_EXPIRED</para>
        //        /// <para>MessageText: A rollback could not be scheduled because a previously scheduled rollback has already executed or been queued for execution.</para>
        //        /// </summary>
        //        RollbackTimerExpired = 6829,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_TXF_ATTRIBUTE_CORRUPT</para>
        //        /// <para>MessageText: The transactional metadata attribute on the file or directory is corrupt and unreadable.</para>
        //        /// </summary>
        //        TxfAttributeCorrupt = 6830,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_EFS_NOT_ALLOWED_IN_TRANSACTION</para>
        //        /// <para>MessageText: The encryption operation could not be completed because a transaction is active.</para>
        //        /// </summary>
        //        EfsNotAllowedInTransaction = 6831,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_TRANSACTIONAL_OPEN_NOT_ALLOWED</para>
        //        /// <para>MessageText: This object is not allowed to be opened in a transaction.</para>
        //        /// </summary>
        //        TransactionalOpenNotAllowed = 6832,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_LOG_GROWTH_FAILED</para>
        //        /// <para>MessageText: An attempt to create space in the transactional resource manager's log failed. The failure status has been recorded in the event log.</para>
        //        /// </summary>
        //        LogGrowthFailed = 6833,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_TRANSACTED_MAPPING_UNSUPPORTED_REMOTE</para>
        //        /// <para>MessageText: Memory mapping (creating a mapped section) a remote file under a transaction is not supported.</para>
        //        /// </summary>
        //        TransactedMappingUnsupportedRemote = 6834,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_TXF_METADATA_ALREADY_PRESENT</para>
        //        /// <para>MessageText: Transaction metadata is already present on this file and cannot be superseded.</para>
        //        /// </summary>
        //        TxfMetadataAlreadyPresent = 6835,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_TRANSACTION_SCOPE_CALLBACKS_NOT_SET</para>
        //        /// <para>MessageText: A transaction scope could not be entered because the scope handler has not been initialized.</para>
        //        /// </summary>
        //        TransactionScopeCallbacksNotSet = 6836,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_TRANSACTION_REQUIRED_PROMOTION</para>
        //        /// <para>MessageText: Promotion was required in order to allow the resource manager to enlist, but the transaction was set to disallow it.</para>
        //        /// </summary>
        //        TransactionRequiredPromotion = 6837,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CANNOT_EXECUTE_FILE_IN_TRANSACTION</para>
        //        /// <para>MessageText: This file is open for modification in an unresolved transaction and may be opened for execute only by a transacted reader.</para>
        //        /// </summary>
        //        CannotExecuteFileInTransaction = 6838,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_TRANSACTIONS_NOT_FROZEN</para>
        //        /// <para>MessageText: The request to thaw frozen transactions was ignored because transactions had not previously been frozen.</para>
        //        /// </summary>
        //        TransactionsNotFrozen = 6839,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_TRANSACTION_FREEZE_IN_PROGRESS</para>
        //        /// <para>MessageText: Transactions cannot be frozen because a freeze is already in progress.</para>
        //        /// </summary>
        //        TransactionFreezeInProgress = 6840,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_NOT_SNAPSHOT_VOLUME</para>
        //        /// <para>MessageText: The target volume is not a snapshot volume. This operation is only valid on a volume mounted as a snapshot.</para>
        //        /// </summary>
        //        NotSnapshotVolume = 6841,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_NO_SAVEPOINT_WITH_OPEN_FILES</para>
        //        /// <para>MessageText: The savepoint operation failed because files are open on the transaction. This is not permitted.</para>
        //        /// </summary>
        //        NoSavepointWithOpenFiles = 6842,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DATA_LOST_REPAIR</para>
        //        /// <para>MessageText: Windows has discovered corruption in a file, and that file has since been repaired. Data loss may have occurred.</para>
        //        /// </summary>
        //        DataLostRepair = 6843,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_SPARSE_NOT_ALLOWED_IN_TRANSACTION</para>
        //        /// <para>MessageText: The sparse operation could not be completed because a transaction is active on the file.</para>
        //        /// </summary>
        //        SparseNotAllowedInTransaction = 6844,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_TM_IDENTITY_MISMATCH</para>
        //        /// <para>MessageText: The call to create a TransactionManager object failed because the Tm Identity stored in the logfile does not match the Tm Identity that was passed in as an argument.</para>
        //        /// </summary>
        //        TmIdentityMismatch = 6845,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_FLOATED_SECTION</para>
        //        /// <para>MessageText: I/O was attempted on a section object that has been floated as a result of a transaction ending. There is no valid data.</para>
        //        /// </summary>
        //        FloatedSection = 6846,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CANNOT_ACCEPT_TRANSACTED_WORK</para>
        //        /// <para>MessageText: The transactional resource manager cannot currently accept transacted work due to a transient condition such as low resources.</para>
        //        /// </summary>
        //        CannotAcceptTransactedWork = 6847,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CANNOT_ABORT_TRANSACTIONS</para>
        //        /// <para>MessageText: The transactional resource manager had too many transactions outstanding that could not be aborted. The transactional resource manger has been shut down.</para>
        //        /// </summary>
        //        CannotAbortTransactions = 6848,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_BAD_CLUSTERS</para>
        //        /// <para>MessageText: The operation could not be completed due to bad clusters on disk.</para>
        //        /// </summary>
        //        BadClusters = 6849,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_COMPRESSION_NOT_ALLOWED_IN_TRANSACTION</para>
        //        /// <para>MessageText: The compression operation could not be completed because a transaction is active on the file.</para>
        //        /// </summary>
        //        CompressionNotAllowedInTransaction = 6850,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_VOLUME_DIRTY</para>
        //        /// <para>MessageText: The operation could not be completed because the volume is dirty. Please run chkdsk and try again.</para>
        //        /// </summary>
        //        VolumeDirty = 6851,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_NO_LINK_TRACKING_IN_TRANSACTION</para>
        //        /// <para>MessageText: The link tracking operation could not be completed because a transaction is active.</para>
        //        /// </summary>
        //        NoLinkTrackingInTransaction = 6852,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_OPERATION_NOT_SUPPORTED_IN_TRANSACTION</para>
        //        /// <para>MessageText: This operation cannot be performed in a transaction.</para>
        //        /// </summary>
        //        OperationNotSupportedInTransaction = 6853,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_EXPIRED_HANDLE</para>
        //        /// <para>MessageText: The handle is no longer properly associated with its transaction.  It may have been opened in a transactional resource manager that was subsequently forced to restart.  Please close the handle and open a new one.</para>
        //        /// </summary>
        //        ExpiredHandle = 6854,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_TRANSACTION_NOT_ENLISTED</para>
        //        /// <para>MessageText: The specified operation could not be performed because the resource manager is not enlisted in the transaction.</para>
        //        /// </summary>
        //        TransactionNotEnlisted = 6855,




        //        /// <summary>
        //        /// <para>MessageId: ERROR_CTX_WINSTATION_NAME_INVALID</para>
        //        /// <para>MessageText: The specified session name is invalid.</para>
        //        /// </summary>
        //        CtxWinstationNameInvalid = 7001,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CTX_INVALID_PD</para>
        //        /// <para>MessageText: The specified protocol driver is invalid.</para>
        //        /// </summary>
        //        CtxInvalidPd = 7002,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CTX_PD_NOT_FOUND</para>
        //        /// <para>MessageText: The specified protocol driver was not found in the system path.</para>
        //        /// </summary>
        //        CtxPdNotFound = 7003,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CTX_WD_NOT_FOUND</para>
        //        /// <para>MessageText: The specified terminal connection driver was not found in the system path.</para>
        //        /// </summary>
        //        CtxWdNotFound = 7004,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CTX_CANNOT_MAKE_EVENTLOG_ENTRY</para>
        //        /// <para>MessageText: A registry key for event logging could not be created for this session.</para>
        //        /// </summary>
        //        CtxCannotMakeEventlogEntry = 7005,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CTX_SERVICE_NAME_COLLISION</para>
        //        /// <para>MessageText: A service with the same name already exists on the system.</para>
        //        /// </summary>
        //        CtxServiceNameCollision = 7006,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CTX_CLOSE_PENDING</para>
        //        /// <para>MessageText: A close operation is pending on the session.</para>
        //        /// </summary>
        //        CtxClosePending = 7007,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CTX_NO_OUTBUF</para>
        //        /// <para>MessageText: There are no free output buffers available.</para>
        //        /// </summary>
        //        CtxNoOutbuf = 7008,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CTX_MODEM_INF_NOT_FOUND</para>
        //        /// <para>MessageText: The MODEM.INF file was not found.</para>
        //        /// </summary>
        //        CtxModemInfNotFound = 7009,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CTX_INVALID_MODEMNAME</para>
        //        /// <para>MessageText: The modem name was not found in MODEM.INF.</para>
        //        /// </summary>
        //        CtxInvalidModemname = 7010,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CTX_MODEM_RESPONSE_ERROR</para>
        //        /// <para>MessageText: The modem did not accept the command sent to it. Verify that the configured modem name matches the attached modem.</para>
        //        /// </summary>
        //        CtxModemResponseError = 7011,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CTX_MODEM_RESPONSE_TIMEOUT</para>
        //        /// <para>MessageText: The modem did not respond to the command sent to it. Verify that the modem is properly cabled and powered on.</para>
        //        /// </summary>
        //        CtxModemResponseTimeout = 7012,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CTX_MODEM_RESPONSE_NO_CARRIER</para>
        //        /// <para>MessageText: Carrier detect has failed or carrier has been dropped due to disconnect.</para>
        //        /// </summary>
        //        CtxModemResponseNoCarrier = 7013,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CTX_MODEM_RESPONSE_NO_DIALTONE</para>
        //        /// <para>MessageText: Dial tone not detected within the required time. Verify that the phone cable is properly attached and functional.</para>
        //        /// </summary>
        //        CtxModemResponseNoDialtone = 7014,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CTX_MODEM_RESPONSE_BUSY</para>
        //        /// <para>MessageText: Busy signal detected at remote site on callback.</para>
        //        /// </summary>
        //        CtxModemResponseBusy = 7015,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CTX_MODEM_RESPONSE_VOICE</para>
        //        /// <para>MessageText: Voice detected at remote site on callback.</para>
        //        /// </summary>
        //        CtxModemResponseVoice = 7016,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CTX_TD_ERROR</para>
        //        /// <para>MessageText: Transport driver error</para>
        //        /// </summary>
        //        CtxTdError = 7017,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CTX_WINSTATION_NOT_FOUND</para>
        //        /// <para>MessageText: The specified session cannot be found.</para>
        //        /// </summary>
        //        CtxWinstationNotFound = 7022,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CTX_WINSTATION_ALREADY_EXISTS</para>
        //        /// <para>MessageText: The specified session name is already in use.</para>
        //        /// </summary>
        //        CtxWinstationAlreadyExists = 7023,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CTX_WINSTATION_BUSY</para>
        //        /// <para>MessageText: The task you are trying to do can't be completed because Remote Desktop Services is currently busy. Please try again in a few minutes. Other users should still be able to log on.</para>
        //        /// </summary>
        //        CtxWinstationBusy = 7024,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CTX_BAD_VIDEO_MODE</para>
        //        /// <para>MessageText: An attempt has been made to connect to a session whose video mode is not supported by the current client.</para>
        //        /// </summary>
        //        CtxBadVideoMode = 7025,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CTX_GRAPHICS_INVALID</para>
        //        /// <para>MessageText: The application attempted to enable DOS graphics mode. DOS graphics mode is not supported.</para>
        //        /// </summary>
        //        CtxGraphicsInvalid = 7035,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CTX_LOGON_DISABLED</para>
        //        /// <para>MessageText: Your interactive logon privilege has been disabled. Please contact your administrator.</para>
        //        /// </summary>
        //        CtxLogonDisabled = 7037,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CTX_NOT_CONSOLE</para>
        //        /// <para>MessageText: The requested operation can be performed only on the system console. This is most often the result of a driver or system DLL requiring direct console access.</para>
        //        /// </summary>
        //        CtxNotConsole = 7038,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CTX_CLIENT_QUERY_TIMEOUT</para>
        //        /// <para>MessageText: The client failed to respond to the server connect message.</para>
        //        /// </summary>
        //        CtxClientQueryTimeout = 7040,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CTX_CONSOLE_DISCONNECT</para>
        //        /// <para>MessageText: Disconnecting the console session is not supported.</para>
        //        /// </summary>
        //        CtxConsoleDisconnect = 7041,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CTX_CONSOLE_CONNECT</para>
        //        /// <para>MessageText: Reconnecting a disconnected session to the console is not supported.</para>
        //        /// </summary>
        //        CtxConsoleConnect = 7042,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CTX_SHADOW_DENIED</para>
        //        /// <para>MessageText: The request to control another session remotely was denied.</para>
        //        /// </summary>
        //        CtxShadowDenied = 7044,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CTX_WINSTATION_ACCESS_DENIED</para>
        //        /// <para>MessageText: The requested session access is denied.</para>
        //        /// </summary>
        //        CtxWinstationAccessDenied = 7045,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CTX_INVALID_WD</para>
        //        /// <para>MessageText: The specified terminal connection driver is invalid.</para>
        //        /// </summary>
        //        CtxInvalidWd = 7049,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CTX_SHADOW_INVALID</para>
        //        /// <para>MessageText: The requested session cannot be controlled remotely.</para>
        //        /// </summary>
        //        CtxShadowInvalid = 7050,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CTX_SHADOW_DISABLED</para>
        //        /// <para>MessageText: The requested session is not configured to allow remote control.</para>
        //        /// </summary>
        //        CtxShadowDisabled = 7051,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CTX_CLIENT_LICENSE_IN_USE</para>
        //        /// <para>MessageText: Your request to connect to this Terminal Server has been rejected. Your Terminal Server client license number is currently being used by another user. Please call your system administrator to obtain a unique license number.</para>
        //        /// </summary>
        //        CtxClientLicenseInUse = 7052,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CTX_CLIENT_LICENSE_NOT_SET</para>
        //        /// <para>MessageText: Your request to connect to this Terminal Server has been rejected. Your Terminal Server client license number has not been entered for this copy of the Terminal Server client. Please contact your system administrator.</para>
        //        /// </summary>
        //        CtxClientLicenseNotSet = 7053,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CTX_LICENSE_NOT_AVAILABLE</para>
        //        /// <para>MessageText: The number of connections to this computer is limited and all connections are in use right now. Try connecting later or contact your system administrator.</para>
        //        /// </summary>
        //        CtxLicenseNotAvailable = 7054,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CTX_LICENSE_CLIENT_INVALID</para>
        //        /// <para>MessageText: The client you are using is not licensed to use this system. Your logon request is denied.</para>
        //        /// </summary>
        //        CtxLicenseClientInvalid = 7055,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CTX_LICENSE_EXPIRED</para>
        //        /// <para>MessageText: The system license has expired. Your logon request is denied.</para>
        //        /// </summary>
        //        CtxLicenseExpired = 7056,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CTX_SHADOW_NOT_RUNNING</para>
        //        /// <para>MessageText: Remote control could not be terminated because the specified session is not currently being remotely controlled.</para>
        //        /// </summary>
        //        CtxShadowNotRunning = 7057,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CTX_SHADOW_ENDED_BY_MODE_CHANGE</para>
        //        /// <para>MessageText: The remote control of the console was terminated because the display mode was changed. Changing the display mode in a remote control session is not supported.</para>
        //        /// </summary>
        //        CtxShadowEndedByModeChange = 7058,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_ACTIVATION_COUNT_EXCEEDED</para>
        //        /// <para>MessageText: Activation has already been reset the maximum number of times for this installation. Your activation timer will not be cleared.</para>
        //        /// </summary>
        //        ActivationCountExceeded = 7059,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CTX_WINSTATIONS_DISABLED</para>
        //        /// <para>MessageText: Remote logins are currently disabled.</para>
        //        /// </summary>
        //        CtxWinstationsDisabled = 7060,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CTX_ENCRYPTION_LEVEL_REQUIRED</para>
        //        /// <para>MessageText: You do not have the proper encryption level to access this Session.</para>
        //        /// </summary>
        //        CtxEncryptionLevelRequired = 7061,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CTX_SESSION_IN_USE</para>
        //        /// <para>MessageText: The user %s\\%s is currently logged on to this computer. Only the current user or an administrator can log on to this computer.</para>
        //        /// </summary>
        //        CtxSessionInUse = 7062,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CTX_NO_FORCE_LOGOFF</para>
        //        /// <para>MessageText: The user %s\\%s is already logged on to the console of this computer. You do not have permission to log in at this time. To resolve this issue, contact %s\\%s and have them log off.</para>
        //        /// </summary>
        //        CtxNoForceLogoff = 7063,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CTX_ACCOUNT_RESTRICTION</para>
        //        /// <para>MessageText: Unable to log you on because of an account restriction.</para>
        //        /// </summary>
        //        CtxAccountRestriction = 7064,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_RDP_PROTOCOL_ERROR</para>
        //        /// <para>MessageText: The RDP protocol component %2 detected an error in the protocol stream and has disconnected the client.</para>
        //        /// </summary>
        //        RdpProtocolError = 7065,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CTX_CDM_CONNECT</para>
        //        /// <para>MessageText: The Client Drive Mapping Service Has Connected on Terminal Connection.</para>
        //        /// </summary>
        //        CtxCdmConnect = 7066,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CTX_CDM_DISCONNECT</para>
        //        /// <para>MessageText: The Client Drive Mapping Service Has Disconnected on Terminal Connection.</para>
        //        /// </summary>
        //        CtxCdmDisconnect = 7067,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_CTX_SECURITY_LAYER_ERROR</para>
        //        /// <para>MessageText: The Terminal Server security layer detected an error in the protocol stream and has disconnected the client.</para>
        //        /// </summary>
        //        CtxSecurityLayerError = 7068,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_TS_INCOMPATIBLE_SESSIONS</para>
        //        /// <para>MessageText: The target session is incompatible with the current session.</para>
        //        /// </summary>
        //        TsIncompatibleSessions = 7069,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_TS_VIDEO_SUBSYSTEM_ERROR</para>
        //        /// <para>MessageText: Windows can't connect to your session because a problem occurred in the Windows video subsystem. Try connecting again later, or contact the server administrator for assistance.</para>
        //        /// </summary>
        //        TsVideoSubsystemError = 7070,






        //        /// <summary>
        //        /// <para>MessageId: FRS_ERR_INVALID_API_SEQUENCE</para>
        //        /// <para>MessageText: The file replication service API was called incorrectly.</para>
        //        /// </summary>
        //        FRS_ERR_INVALID_API_SEQUENCE = 8001,

        //        /// <summary>
        //        /// <para>MessageId: FRS_ERR_STARTING_SERVICE</para>
        //        /// <para>MessageText: The file replication service cannot be started.</para>
        //        /// </summary>
        //        FRS_ERR_STARTING_SERVICE = 8002,

        //        /// <summary>
        //        /// <para>MessageId: FRS_ERR_STOPPING_SERVICE</para>
        //        /// <para>MessageText: The file replication service cannot be stopped.</para>
        //        /// </summary>
        //        FRS_ERR_STOPPING_SERVICE = 8003,

        //        /// <summary>
        //        /// <para>MessageId: FRS_ERR_INTERNAL_API</para>
        //        /// <para>MessageText: The file replication service API terminated the request. The event log may have more information.</para>
        //        /// </summary>
        //        FRS_ERR_INTERNAL_API = 8004,

        //        /// <summary>
        //        /// <para>MessageId: FRS_ERR_INTERNAL</para>
        //        /// <para>MessageText: The file replication service terminated the request. The event log may have more information.</para>
        //        /// </summary>
        //        FRS_ERR_INTERNAL = 8005,

        //        /// <summary>
        //        /// <para>MessageId: FRS_ERR_SERVICE_COMM</para>
        //        /// <para>MessageText: The file replication service cannot be contacted. The event log may have more information.</para>
        //        /// </summary>
        //        FRS_ERR_SERVICE_COMM = 8006,

        //        /// <summary>
        //        /// <para>MessageId: FRS_ERR_INSUFFICIENT_PRIV</para>
        //        /// <para>MessageText: The file replication service cannot satisfy the request because the user has insufficient privileges. The event log may have more information.</para>
        //        /// </summary>
        //        FRS_ERR_INSUFFICIENT_PRIV = 8007,

        //        /// <summary>
        //        /// <para>MessageId: FRS_ERR_AUTHENTICATION</para>
        //        /// <para>MessageText: The file replication service cannot satisfy the request because authenticated RPC is not available. The event log may have more information.</para>
        //        /// </summary>
        //        FRS_ERR_AUTHENTICATION = 8008,

        //        /// <summary>
        //        /// <para>MessageId: FRS_ERR_PARENT_INSUFFICIENT_PRIV</para>
        //        /// <para>MessageText: The file replication service cannot satisfy the request because the user has insufficient privileges on the domain controller. The event log may have more information.</para>
        //        /// </summary>
        //        FRS_ERR_PARENT_INSUFFICIENT_PRIV = 8009,

        //        /// <summary>
        //        /// <para>MessageId: FRS_ERR_PARENT_AUTHENTICATION</para>
        //        /// <para>MessageText: The file replication service cannot satisfy the request because authenticated RPC is not available on the domain controller. The event log may have more information.</para>
        //        /// </summary>
        //        FRS_ERR_PARENT_AUTHENTICATION = 8010,

        //        /// <summary>
        //        /// <para>MessageId: FRS_ERR_CHILD_TO_PARENT_COMM</para>
        //        /// <para>MessageText: The file replication service cannot communicate with the file replication service on the domain controller. The event log may have more information.</para>
        //        /// </summary>
        //        FRS_ERR_CHILD_TO_PARENT_COMM = 8011,

        //        /// <summary>
        //        /// <para>MessageId: FRS_ERR_PARENT_TO_CHILD_COMM</para>
        //        /// <para>MessageText: The file replication service on the domain controller cannot communicate with the file replication service on this computer. The event log may have more information.</para>
        //        /// </summary>
        //        FRS_ERR_PARENT_TO_CHILD_COMM = 8012,

        //        /// <summary>
        //        /// <para>MessageId: FRS_ERR_SYSVOL_POPULATE</para>
        //        /// <para>MessageText: The file replication service cannot populate the system volume because of an internal error. The event log may have more information.</para>
        //        /// </summary>
        //        FRS_ERR_SYSVOL_POPULATE = 8013,

        //        /// <summary>
        //        /// <para>MessageId: FRS_ERR_SYSVOL_POPULATE_TIMEOUT</para>
        //        /// <para>MessageText: The file replication service cannot populate the system volume because of an internal timeout. The event log may have more information.</para>
        //        /// </summary>
        //        FRS_ERR_SYSVOL_POPULATE_TIMEOUT = 8014,

        //        /// <summary>
        //        /// <para>MessageId: FRS_ERR_SYSVOL_IS_BUSY</para>
        //        /// <para>MessageText: The file replication service cannot process the request. The system volume is busy with a previous request.</para>
        //        /// </summary>
        //        FRS_ERR_SYSVOL_IS_BUSY = 8015,

        //        /// <summary>
        //        /// <para>MessageId: FRS_ERR_SYSVOL_DEMOTE</para>
        //        /// <para>MessageText: The file replication service cannot stop replicating the system volume because of an internal error. The event log may have more information.</para>
        //        /// </summary>
        //        FRS_ERR_SYSVOL_DEMOTE = 8016,

        //        /// <summary>
        //        /// <para>MessageId: FRS_ERR_INVALID_SERVICE_PARAMETER</para>
        //        /// <para>MessageText: The file replication service detected an invalid parameter.</para>
        //        /// </summary>
        //        FRS_ERR_INVALID_SERVICE_PARAMETER = 8017,

        //        DS_S_SUCCESS = NO_ERROR,
        ///// <summary>
        ///// <para>MessageId: ERROR_DS_NOT_INSTALLED</para>
        ///// <para>MessageText: An error occurred while installing the directory service. For more information, see the event log.</para>
        ///// </summary>
        //DsNotInstalled = 8200,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_MEMBERSHIP_EVALUATED_LOCALLY</para>
        //        /// <para>MessageText: The directory service evaluated group memberships locally.</para>
        //        /// </summary>
        //        DsMembershipEvaluatedLocally = 8201,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_NO_ATTRIBUTE_OR_VALUE</para>
        //        /// <para>MessageText: The specified directory service attribute or value does not exist.</para>
        //        /// </summary>
        //        DsNoAttributeOrValue = 8202,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_INVALID_ATTRIBUTE_SYNTAX</para>
        //        /// <para>MessageText: The attribute syntax specified to the directory service is invalid.</para>
        //        /// </summary>
        //        DsInvalidAttributeSyntax = 8203,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_ATTRIBUTE_TYPE_UNDEFINED</para>
        //        /// <para>MessageText: The attribute type specified to the directory service is not defined.</para>
        //        /// </summary>
        //        DsAttributeTypeUndefined = 8204,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_ATTRIBUTE_OR_VALUE_EXISTS</para>
        //        /// <para>MessageText: The specified directory service attribute or value already exists.</para>
        //        /// </summary>
        //        DsAttributeOrValueExists = 8205,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_BUSY</para>
        //        /// <para>MessageText: The directory service is busy.</para>
        //        /// </summary>
        //        DsBusy = 8206,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_UNAVAILABLE</para>
        //        /// <para>MessageText: The directory service is unavailable.</para>
        //        /// </summary>
        //        DsUnavailable = 8207,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_NO_RIDS_ALLOCATED</para>
        //        /// <para>MessageText: The directory service was unable to allocate a relative identifier.</para>
        //        /// </summary>
        //        DsNoRidsAllocated = 8208,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_NO_MORE_RIDS</para>
        //        /// <para>MessageText: The directory service has exhausted the pool of relative identifiers.</para>
        //        /// </summary>
        //        DsNoMoreRids = 8209,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_INCORRECT_ROLE_OWNER</para>
        //        /// <para>MessageText: The requested operation could not be performed because the directory service is not the master for that type of operation.</para>
        //        /// </summary>
        //        DsIncorrectRoleOwner = 8210,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_RIDMGR_INIT_ERROR</para>
        //        /// <para>MessageText: The directory service was unable to initialize the subsystem that allocates relative identifiers.</para>
        //        /// </summary>
        //        DsRidmgrInitError = 8211,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_OBJ_CLASS_VIOLATION</para>
        //        /// <para>MessageText: The requested operation did not satisfy one or more constraints associated with the class of the object.</para>
        //        /// </summary>
        //        DsObjClassViolation = 8212,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_CANT_ON_NON_LEAF</para>
        //        /// <para>MessageText: The directory service can perform the requested operation only on a leaf object.</para>
        //        /// </summary>
        //        DsCantOnNonLeaf = 8213,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_CANT_ON_RDN</para>
        //        /// <para>MessageText: The directory service cannot perform the requested operation on the RDN attribute of an object.</para>
        //        /// </summary>
        //        DsCantOnRdn = 8214,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_CANT_MOD_OBJ_CLASS</para>
        //        /// <para>MessageText: The directory service detected an attempt to modify the object class of an object.</para>
        //        /// </summary>
        //        DsCantModObjClass = 8215,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_CROSS_DOM_MOVE_ERROR</para>
        //        /// <para>MessageText: The requested cross-domain move operation could not be performed.</para>
        //        /// </summary>
        //        DsCrossDomMoveError = 8216,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_GC_NOT_AVAILABLE</para>
        //        /// <para>MessageText: Unable to contact the global catalog server.</para>
        //        /// </summary>
        //        DsGcNotAvailable = 8217,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_SHARED_POLICY</para>
        //        /// <para>MessageText: The policy object is .Shared and can only be modified at the root.</para>
        //        /// </summary>
        //        .SharedPolicy = 8218,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_POLICY_OBJECT_NOT_FOUND</para>
        //        /// <para>MessageText: The policy object does not exist.</para>
        //        /// </summary>
        //        PolicyObjectNotFound = 8219,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_POLICY_ONLY_IN_DS</para>
        //        /// <para>MessageText: The requested policy information is only in the directory service.</para>
        //        /// </summary>
        //        PolicyOnlyInDs = 8220,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_PROMOTION_ACTIVE</para>
        //        /// <para>MessageText: A domain controller promotion is currently active.</para>
        //        /// </summary>
        //        PromotionActive = 8221,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_NO_PROMOTION_ACTIVE</para>
        //        /// <para>MessageText: A domain controller promotion is not currently active</para>
        //        /// </summary>
        //        NoPromotionActive = 8222,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_OPERATIONS_ERROR</para>
        //        /// <para>MessageText: An operations error occurred.</para>
        //        /// </summary>
        //        DsOperationsError = 8224,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_PROTOCOL_ERROR</para>
        //        /// <para>MessageText: A protocol error occurred.</para>
        //        /// </summary>
        //        DsProtocolError = 8225,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_TIMELIMIT_EXCEEDED</para>
        //        /// <para>MessageText: The time limit for this request was exceeded.</para>
        //        /// </summary>
        //        DsTimelimitExceeded = 8226,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_SIZELIMIT_EXCEEDED</para>
        //        /// <para>MessageText: The size limit for this request was exceeded.</para>
        //        /// </summary>
        //        DsSizelimitExceeded = 8227,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_ADMIN_LIMIT_EXCEEDED</para>
        //        /// <para>MessageText: The administrative limit for this request was exceeded.</para>
        //        /// </summary>
        //        DsAdminLimitExceeded = 8228,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_COMPARE_FALSE</para>
        //        /// <para>MessageText: The compare response was false.</para>
        //        /// </summary>
        //        DsCompareFalse = 8229,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_COMPARE_TRUE</para>
        //        /// <para>MessageText: The compare response was true.</para>
        //        /// </summary>
        //        DsCompareTrue = 8230,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_AUTH_METHOD_NOT_SUPPORTED</para>
        //        /// <para>MessageText: The requested authentication method is not supported by the server.</para>
        //        /// </summary>
        //        DsAuthMethodNotSupported = 8231,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_STRONG_AUTH_REQUIRED</para>
        //        /// <para>MessageText: A more secure authentication method is required for this server.</para>
        //        /// </summary>
        //        DsStrongAuthRequired = 8232,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_INAPPROPRIATE_AUTH</para>
        //        /// <para>MessageText: Inappropriate authentication.</para>
        //        /// </summary>
        //        DsInappropriateAuth = 8233,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_AUTH_UNKNOWN</para>
        //        /// <para>MessageText: The authentication mechanism is unknown.</para>
        //        /// </summary>
        //        DsAuthUnknown = 8234,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_REFERRAL</para>
        //        /// <para>MessageText: A referral was returned from the server.</para>
        //        /// </summary>
        //        DsReferral = 8235,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_UNAVAILABLE_CRIT_EXTENSION</para>
        //        /// <para>MessageText: The server does not support the requested critical extension.</para>
        //        /// </summary>
        //        DsUnavailableCritExtension = 8236,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_CONFIDENTIALITY_REQUIRED</para>
        //        /// <para>MessageText: This request requires a secure connection.</para>
        //        /// </summary>
        //        DsConfidentialityRequired = 8237,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_INAPPROPRIATE_MATCHING</para>
        //        /// <para>MessageText: Inappropriate matching.</para>
        //        /// </summary>
        //        DsInappropriateMatching = 8238,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_CONSTRAINT_VIOLATION</para>
        //        /// <para>MessageText: A constraint violation occurred.</para>
        //        /// </summary>
        //        DsConstraintViolation = 8239,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_NO_SUCH_OBJECT</para>
        //        /// <para>MessageText: There is no such object on the server.</para>
        //        /// </summary>
        //        DsNoSuchObject = 8240,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_ALIAS_PROBLEM</para>
        //        /// <para>MessageText: There is an alias problem.</para>
        //        /// </summary>
        //        DsAliasProblem = 8241,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_INVALID_DN_SYNTAX</para>
        //        /// <para>MessageText: An invalid dn syntax has been specified.</para>
        //        /// </summary>
        //        DsInvalidDnSyntax = 8242,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_IS_LEAF</para>
        //        /// <para>MessageText: The object is a leaf object.</para>
        //        /// </summary>
        //        DsIsLeaf = 8243,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_ALIAS_DEREF_PROBLEM</para>
        //        /// <para>MessageText: There is an alias dereferencing problem.</para>
        //        /// </summary>
        //        DsAliasDerefProblem = 8244,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_UNWILLING_TO_PERFORM</para>
        //        /// <para>MessageText: The server is unwilling to process the request.</para>
        //        /// </summary>
        //        DsUnwillingToPerform = 8245,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_LOOP_DETECT</para>
        //        /// <para>MessageText: A loop has been detected.</para>
        //        /// </summary>
        //        DsLoopDetect = 8246,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_NAMING_VIOLATION</para>
        //        /// <para>MessageText: There is a naming violation.</para>
        //        /// </summary>
        //        DsNamingViolation = 8247,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_OBJECT_RESULTS_TOO_LARGE</para>
        //        /// <para>MessageText: The result set is too large.</para>
        //        /// </summary>
        //        DsObjectResultsTooLarge = 8248,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_AFFECTS_MULTIPLE_DSAS</para>
        //        /// <para>MessageText: The operation affects multiple DSAs</para>
        //        /// </summary>
        //        DsAffectsMultipleDsas = 8249,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_SERVER_DOWN</para>
        //        /// <para>MessageText: The server is not operational.</para>
        //        /// </summary>
        //        DsServerDown = 8250,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_LOCAL_ERROR</para>
        //        /// <para>MessageText: A local error has occurred.</para>
        //        /// </summary>
        //        DsLocalError = 8251,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_ENCODING_ERROR</para>
        //        /// <para>MessageText: An encoding error has occurred.</para>
        //        /// </summary>
        //        DsEncodingError = 8252,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_DECODING_ERROR</para>
        //        /// <para>MessageText: A decoding error has occurred.</para>
        //        /// </summary>
        //        DsDecodingError = 8253,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_FILTER_UNKNOWN</para>
        //        /// <para>MessageText: The search filter cannot be recognized.</para>
        //        /// </summary>
        //        DsFilterUnknown = 8254,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_PARAM_ERROR</para>
        //        /// <para>MessageText: One or more parameters are illegal.</para>
        //        /// </summary>
        //        DsParamError = 8255,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_NOT_SUPPORTED</para>
        //        /// <para>MessageText: The specified method is not supported.</para>
        //        /// </summary>
        //        DsNotSupported = 8256,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_NO_RESULTS_RETURNED</para>
        //        /// <para>MessageText: No results were returned.</para>
        //        /// </summary>
        //        DsNoResultsReturned = 8257,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_CONTROL_NOT_FOUND</para>
        //        /// <para>MessageText: The specified control is not supported by the server.</para>
        //        /// </summary>
        //        DsControlNotFound = 8258,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_CLIENT_LOOP</para>
        //        /// <para>MessageText: A referral loop was detected by the client.</para>
        //        /// </summary>
        //        DsClientLoop = 8259,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_REFERRAL_LIMIT_EXCEEDED</para>
        //        /// <para>MessageText: The preset referral limit was exceeded.</para>
        //        /// </summary>
        //        DsReferralLimitExceeded = 8260,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_SORT_CONTROL_MISSING</para>
        //        /// <para>MessageText: The search requires a SORT control.</para>
        //        /// </summary>
        //        DsSortControlMissing = 8261,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_OFFSET_RANGE_ERROR</para>
        //        /// <para>MessageText: The search results exceed the offset range specified.</para>
        //        /// </summary>
        //        DsOffsetRangeError = 8262,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_RIDMGR_DISABLED</para>
        //        /// <para>MessageText: The directory service detected the subsystem that allocates relative identifiers is disabled. This can occur as a protective mechanism when the system determines a significant portion of relative identifiers (RIDs) have been exhausted. Please see http://go.microsoft.com/fwlink/?LinkId=228610 for recommended diagnostic steps and the procedure to re-enable account creation.</para>
        //        /// </summary>
        //        DsRidmgrDisabled = 8263,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_ROOT_MUST_BE_NC</para>
        //        /// <para>MessageText: The root object must be the head of a naming context. The root object cannot have an instantiated parent.</para>
        //        /// </summary>
        //        DsRootMustBeNc = 8301,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_ADD_REPLICA_INHIBITED</para>
        //        /// <para>MessageText: The add replica operation cannot be performed. The naming context must be writeable in order to create the replica.</para>
        //        /// </summary>
        //        DsAddReplicaInhibited = 8302,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_ATT_NOT_DEF_IN_SCHEMA</para>
        //        /// <para>MessageText: A reference to an attribute that is not defined in the schema occurred.</para>
        //        /// </summary>
        //        DsAttNotDefInSchema = 8303,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_MAX_OBJ_SIZE_EXCEEDED</para>
        //        /// <para>MessageText: The maximum size of an object has been exceeded.</para>
        //        /// </summary>
        //        DsMaxObjSizeExceeded = 8304,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_OBJ_STRING_NAME_EXISTS</para>
        //        /// <para>MessageText: An attempt was made to add an object to the directory with a name that is already in use.</para>
        //        /// </summary>
        //        DsObjStringNameExists = 8305,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_NO_RDN_DEFINED_IN_SCHEMA</para>
        //        /// <para>MessageText: An attempt was made to add an object of a class that does not have an RDN defined in the schema.</para>
        //        /// </summary>
        //        DsNoRdnDefinedInSchema = 8306,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_RDN_DOESNT_MATCH_SCHEMA</para>
        //        /// <para>MessageText: An attempt was made to add an object using an RDN that is not the RDN defined in the schema.</para>
        //        /// </summary>
        //        DsRdnDoesntMatchSchema = 8307,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_NO_REQUESTED_ATTS_FOUND</para>
        //        /// <para>MessageText: None of the requested attributes were found on the objects.</para>
        //        /// </summary>
        //        DsNoRequestedAttsFound = 8308,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_USER_BUFFER_TO_SMALL</para>
        //        /// <para>MessageText: The user buffer is too small.</para>
        //        /// </summary>
        //        DsUserBufferToSmall = 8309,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_ATT_IS_NOT_ON_OBJ</para>
        //        /// <para>MessageText: The attribute specified in the operation is not present on the object.</para>
        //        /// </summary>
        //        DsAttIsNotOnObj = 8310,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_ILLEGAL_MOD_OPERATION</para>
        //        /// <para>MessageText: Illegal modify operation. Some aspect of the modification is not permitted.</para>
        //        /// </summary>
        //        DsIllegalModOperation = 8311,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_OBJ_TOO_LARGE</para>
        //        /// <para>MessageText: The specified object is too large.</para>
        //        /// </summary>
        //        DsObjTooLarge = 8312,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_BAD_INSTANCE_TYPE</para>
        //        /// <para>MessageText: The specified instance type is not valid.</para>
        //        /// </summary>
        //        DsBadInstanceType = 8313,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_MASTERDSA_REQUIRED</para>
        //        /// <para>MessageText: The operation must be performed at a master DSA.</para>
        //        /// </summary>
        //        DsMasterdsaRequired = 8314,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_OBJECT_CLASS_REQUIRED</para>
        //        /// <para>MessageText: The object class attribute must be specified.</para>
        //        /// </summary>
        //        DsObjectClassRequired = 8315,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_MISSING_REQUIRED_ATT</para>
        //        /// <para>MessageText: A required attribute is missing.</para>
        //        /// </summary>
        //        DsMissingRequiredAtt = 8316,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_ATT_NOT_DEF_FOR_CLASS</para>
        //        /// <para>MessageText: An attempt was made to modify an object to include an attribute that is not legal for its class.</para>
        //        /// </summary>
        //        DsAttNotDefForClass = 8317,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_ATT_ALREADY_EXISTS</para>
        //        /// <para>MessageText: The specified attribute is already present on the object.</para>
        //        /// </summary>
        //        DsAttAlreadyExists = 8318,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_CANT_ADD_ATT_VALUES</para>
        //        /// <para>MessageText: The specified attribute is not present, or has no values.</para>
        //        /// </summary>
        //        DsCantAddAttValues = 8320,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_SINGLE_VALUE_CONSTRAINT</para>
        //        /// <para>MessageText: Multiple values were specified for an attribute that can have only one value.</para>
        //        /// </summary>
        //        DsSingleValueConstraint = 8321,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_RANGE_CONSTRAINT</para>
        //        /// <para>MessageText: A value for the attribute was not in the acceptable range of values.</para>
        //        /// </summary>
        //        DsRangeConstraint = 8322,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_ATT_VAL_ALREADY_EXISTS</para>
        //        /// <para>MessageText: The specified value already exists.</para>
        //        /// </summary>
        //        DsAttValAlreadyExists = 8323,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_CANT_REM_MISSING_ATT</para>
        //        /// <para>MessageText: The attribute cannot be removed because it is not present on the object.</para>
        //        /// </summary>
        //        DsCantRemMissingAtt = 8324,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_CANT_REM_MISSING_ATT_VAL</para>
        //        /// <para>MessageText: The attribute value cannot be removed because it is not present on the object.</para>
        //        /// </summary>
        //        DsCantRemMissingAttVal = 8325,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_ROOT_CANT_BE_SUBREF</para>
        //        /// <para>MessageText: The specified root object cannot be a subref.</para>
        //        /// </summary>
        //        DsRootCantBeSubref = 8326,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_NO_CHAINING</para>
        //        /// <para>MessageText: Chaining is not permitted.</para>
        //        /// </summary>
        //        DsNoChaining = 8327,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_NO_CHAINED_EVAL</para>
        //        /// <para>MessageText: Chained evaluation is not permitted.</para>
        //        /// </summary>
        //        DsNoChainedEval = 8328,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_NO_PARENT_OBJECT</para>
        //        /// <para>MessageText: The operation could not be performed because the object's parent is either uninstantiated or deleted.</para>
        //        /// </summary>
        //        DsNoParentObject = 8329,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_PARENT_IS_AN_ALIAS</para>
        //        /// <para>MessageText: Having a parent that is an alias is not permitted. Aliases are leaf objects.</para>
        //        /// </summary>
        //        DsParentIsAnAlias = 8330,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_CANT_MIX_MASTER_AND_REPS</para>
        //        /// <para>MessageText: The object and parent must be of the same type, either both masters or both replicas.</para>
        //        /// </summary>
        //        DsCantMixMasterAndReps = 8331,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_CHILDREN_EXIST</para>
        //        /// <para>MessageText: The operation cannot be performed because child objects exist. This operation can only be performed on a leaf object.</para>
        //        /// </summary>
        //        DsChildrenExist = 8332,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_OBJ_NOT_FOUND</para>
        //        /// <para>MessageText: Directory object not found.</para>
        //        /// </summary>
        //        DsObjNotFound = 8333,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_ALIASED_OBJ_MISSING</para>
        //        /// <para>MessageText: The aliased object is missing.</para>
        //        /// </summary>
        //        DsAliasedObjMissing = 8334,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_BAD_NAME_SYNTAX</para>
        //        /// <para>MessageText: The object name has bad syntax.</para>
        //        /// </summary>
        //        DsBadNameSyntax = 8335,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_ALIAS_POINTS_TO_ALIAS</para>
        //        /// <para>MessageText: It is not permitted for an alias to refer to another alias.</para>
        //        /// </summary>
        //        DsAliasPointsToAlias = 8336,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_CANT_DEREF_ALIAS</para>
        //        /// <para>MessageText: The alias cannot be dereferenced.</para>
        //        /// </summary>
        //        DsCantDerefAlias = 8337,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_OUT_OF_SCOPE</para>
        //        /// <para>MessageText: The operation is out of scope.</para>
        //        /// </summary>
        //        DsOutOfScope = 8338,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_OBJECT_BEING_REMOVED</para>
        //        /// <para>MessageText: The operation cannot continue because the object is in the process of being removed.</para>
        //        /// </summary>
        //        DsObjectBeingRemoved = 8339,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_CANT_DELETE_DSA_OBJ</para>
        //        /// <para>MessageText: The DSA object cannot be deleted.</para>
        //        /// </summary>
        //        DsCantDeleteDsaObj = 8340,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_GENERIC_ERROR</para>
        //        /// <para>MessageText: A directory service error has occurred.</para>
        //        /// </summary>
        //        DsGenericError = 8341,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_DSA_MUST_BE_INT_MASTER</para>
        //        /// <para>MessageText: The operation can only be performed on an internal master DSA object.</para>
        //        /// </summary>
        //        DsDsaMustBeIntMaster = 8342,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_CLASS_NOT_DSA</para>
        //        /// <para>MessageText: The object must be of class DSA.</para>
        //        /// </summary>
        //        DsClassNotDsa = 8343,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_INSUFF_ACCESS_RIGHTS</para>
        //        /// <para>MessageText: Insufficient access rights to perform the operation.</para>
        //        /// </summary>
        //        DsInsuffAccessRights = 8344,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_ILLEGAL_SUPERIOR</para>
        //        /// <para>MessageText: The object cannot be added because the parent is not on the list of possible superiors.</para>
        //        /// </summary>
        //        DsIllegalSuperior = 8345,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_ATTRIBUTE_OWNED_BY_SAM</para>
        //        /// <para>MessageText: Access to the attribute is not permitted because the attribute is owned by the Security Accounts Manager (SAM).</para>
        //        /// </summary>
        //        DsAttributeOwnedBySam = 8346,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_NAME_TOO_MANY_PARTS</para>
        //        /// <para>MessageText: The name has too many parts.</para>
        //        /// </summary>
        //        DsNameTooManyParts = 8347,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_NAME_TOO_LONG</para>
        //        /// <para>MessageText: The name is too long.</para>
        //        /// </summary>
        //        DsNameTooLong = 8348,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_NAME_VALUE_TOO_LONG</para>
        //        /// <para>MessageText: The name value is too long.</para>
        //        /// </summary>
        //        DsNameValueTooLong = 8349,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_NAME_UNPARSEABLE</para>
        //        /// <para>MessageText: The directory service encountered an error parsing a name.</para>
        //        /// </summary>
        //        DsNameUnparseable = 8350,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_NAME_TYPE_UNKNOWN</para>
        //        /// <para>MessageText: The directory service cannot get the attribute type for a name.</para>
        //        /// </summary>
        //        DsNameTypeUnknown = 8351,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_NOT_AN_OBJECT</para>
        //        /// <para>MessageText: The name does not identify an object; the name identifies a phantom.</para>
        //        /// </summary>
        //        DsNotAnObject = 8352,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_SEC_DESC_TOO_SHORT</para>
        //        /// <para>MessageText: The security descriptor is too short.</para>
        //        /// </summary>
        //        DsSecDescTooShort = 8353,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_SEC_DESC_INVALID</para>
        //        /// <para>MessageText: The security descriptor is invalid.</para>
        //        /// </summary>
        //        DsSecDescInvalid = 8354,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_NO_DELETED_NAME</para>
        //        /// <para>MessageText: Failed to create name for deleted object.</para>
        //        /// </summary>
        //        DsNoDeletedName = 8355,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_SUBREF_MUST_HAVE_PARENT</para>
        //        /// <para>MessageText: The parent of a new subref must exist.</para>
        //        /// </summary>
        //        DsSubrefMustHaveParent = 8356,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_NCNAME_MUST_BE_NC</para>
        //        /// <para>MessageText: The object must be a naming context.</para>
        //        /// </summary>
        //        DsNcnameMustBeNc = 8357,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_CANT_ADD_SYSTEM_ONLY</para>
        //        /// <para>MessageText: It is not permitted to add an attribute which is owned by the system.</para>
        //        /// </summary>
        //        DsCantAddSystemOnly = 8358,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_CLASS_MUST_BE_CONCRETE</para>
        //        /// <para>MessageText: The class of the object must be structural; you cannot instantiate an abstract class.</para>
        //        /// </summary>
        //        DsClassMustBeConcrete = 8359,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_INVALID_DMD</para>
        //        /// <para>MessageText: The schema object could not be found.</para>
        //        /// </summary>
        //        DsInvalidDmd = 8360,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_OBJ_GUID_EXISTS</para>
        //        /// <para>MessageText: A local object with this GUID (dead or alive) already exists.</para>
        //        /// </summary>
        //        DsObjGuidExists = 8361,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_NOT_ON_BACKLINK</para>
        //        /// <para>MessageText: The operation cannot be performed on a back link.</para>
        //        /// </summary>
        //        DsNotOnBacklink = 8362,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_NO_CROSSREF_FOR_NC</para>
        //        /// <para>MessageText: The cross reference for the specified naming context could not be found.</para>
        //        /// </summary>
        //        DsNoCrossrefForNc = 8363,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_SHUTTING_DOWN</para>
        //        /// <para>MessageText: The operation could not be performed because the directory service is shutting down.</para>
        //        /// </summary>
        //        DsShuttingDown = 8364,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_UNKNOWN_OPERATION</para>
        //        /// <para>MessageText: The directory service request is invalid.</para>
        //        /// </summary>
        //        DsUnknownOperation = 8365,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_INVALID_ROLE_OWNER</para>
        //        /// <para>MessageText: The role owner attribute could not be read.</para>
        //        /// </summary>
        //        DsInvalidRoleOwner = 8366,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_COULDNT_CONTACT_FSMO</para>
        //        /// <para>MessageText: The requested FSMO operation failed. The current FSMO holder could not be contacted.</para>
        //        /// </summary>
        //        DsCouldntContactFsmo = 8367,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_CROSS_NC_DN_RENAME</para>
        //        /// <para>MessageText: Modification of a DN across a naming context is not permitted.</para>
        //        /// </summary>
        //        DsCrossNcDnRename = 8368,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_CANT_MOD_SYSTEM_ONLY</para>
        //        /// <para>MessageText: The attribute cannot be modified because it is owned by the system.</para>
        //        /// </summary>
        //        DsCantModSystemOnly = 8369,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_REPLICATOR_ONLY</para>
        //        /// <para>MessageText: Only the replicator can perform this function.</para>
        //        /// </summary>
        //        DsReplicatorOnly = 8370,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_OBJ_CLASS_NOT_DEFINED</para>
        //        /// <para>MessageText: The specified class is not defined.</para>
        //        /// </summary>
        //        DsObjClassNotDefined = 8371,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_OBJ_CLASS_NOT_SUBCLASS</para>
        //        /// <para>MessageText: The specified class is not a subclass.</para>
        //        /// </summary>
        //        DsObjClassNotSubclass = 8372,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_NAME_REFERENCE_INVALID</para>
        //        /// <para>MessageText: The name reference is invalid.</para>
        //        /// </summary>
        //        DsNameReferenceInvalid = 8373,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_CROSS_REF_EXISTS</para>
        //        /// <para>MessageText: A cross reference already exists.</para>
        //        /// </summary>
        //        DsCrossRefExists = 8374,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_CANT_DEL_MASTER_CROSSREF</para>
        //        /// <para>MessageText: It is not permitted to delete a master cross reference.</para>
        //        /// </summary>
        //        DsCantDelMasterCrossref = 8375,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_SUBTREE_NOTIFY_NOT_NC_HEAD</para>
        //        /// <para>MessageText: Subtree notifications are only supported on NC heads.</para>
        //        /// </summary>
        //        DsSubtreeNotifyNotNcHead = 8376,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_NOTIFY_FILTER_TOO_COMPLEX</para>
        //        /// <para>MessageText: Notification filter is too complex.</para>
        //        /// </summary>
        //        DsNotifyFilterTooComplex = 8377,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_DUP_RDN</para>
        //        /// <para>MessageText: Schema update failed: duplicate RDN.</para>
        //        /// </summary>
        //        DsDupRdn = 8378,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_DUP_OID</para>
        //        /// <para>MessageText: Schema update failed: duplicate OID.</para>
        //        /// </summary>
        //        DsDupOid = 8379,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_DUP_MAPI_ID</para>
        //        /// <para>MessageText: Schema update failed: duplicate MAPI identifier.</para>
        //        /// </summary>
        //        DsDupMapiId = 8380,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_DUP_SCHEMA_ID_GUID</para>
        //        /// <para>MessageText: Schema update failed: duplicate schema-id GUID.</para>
        //        /// </summary>
        //        DsDupSchemaIdGuid = 8381,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_DUP_LDAP_DISPLAY_NAME</para>
        //        /// <para>MessageText: Schema update failed: duplicate LDAP display name.</para>
        //        /// </summary>
        //        DsDupLdapDisplayName = 8382,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_SEMANTIC_ATT_TEST</para>
        //        /// <para>MessageText: Schema update failed: range-lower less than range upper.</para>
        //        /// </summary>
        //        DsSemanticAttTest = 8383,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_SYNTAX_MISMATCH</para>
        //        /// <para>MessageText: Schema update failed: syntax mismatch.</para>
        //        /// </summary>
        //        DsSyntaxMismatch = 8384,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_EXISTS_IN_MUST_HAVE</para>
        //        /// <para>MessageText: Schema deletion failed: attribute is used in must-contain.</para>
        //        /// </summary>
        //        DsExistsInMustHave = 8385,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_EXISTS_IN_MAY_HAVE</para>
        //        /// <para>MessageText: Schema deletion failed: attribute is used in may-contain.</para>
        //        /// </summary>
        //        DsExistsInMayHave = 8386,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_NONEXISTENT_MAY_HAVE</para>
        //        /// <para>MessageText: Schema update failed: attribute in may-contain does not exist.</para>
        //        /// </summary>
        //        DsNonexistentMayHave = 8387,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_NONEXISTENT_MUST_HAVE</para>
        //        /// <para>MessageText: Schema update failed: attribute in must-contain does not exist.</para>
        //        /// </summary>
        //        DsNonexistentMustHave = 8388,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_AUX_CLS_TEST_FAIL</para>
        //        /// <para>MessageText: Schema update failed: class in aux-class list does not exist or is not an auxiliary class.</para>
        //        /// </summary>
        //        DsAuxClsTestFail = 8389,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_NONEXISTENT_POSS_SUP</para>
        //        /// <para>MessageText: Schema update failed: class in poss-superiors does not exist.</para>
        //        /// </summary>
        //        DsNonexistentPossSup = 8390,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_SUB_CLS_TEST_FAIL</para>
        //        /// <para>MessageText: Schema update failed: class in subclassof list does not exist or does not satisfy hierarchy rules.</para>
        //        /// </summary>
        //        DsSubClsTestFail = 8391,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_BAD_RDN_ATT_ID_SYNTAX</para>
        //        /// <para>MessageText: Schema update failed: Rdn-Att-Id has wrong syntax.</para>
        //        /// </summary>
        //        DsBadRdnAttIdSyntax = 8392,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_EXISTS_IN_AUX_CLS</para>
        //        /// <para>MessageText: Schema deletion failed: class is used as auxiliary class.</para>
        //        /// </summary>
        //        DsExistsInAuxCls = 8393,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_EXISTS_IN_SUB_CLS</para>
        //        /// <para>MessageText: Schema deletion failed: class is used as sub class.</para>
        //        /// </summary>
        //        DsExistsInSubCls = 8394,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_EXISTS_IN_POSS_SUP</para>
        //        /// <para>MessageText: Schema deletion failed: class is used as poss superior.</para>
        //        /// </summary>
        //        DsExistsInPossSup = 8395,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_RECALCSCHEMA_FAILED</para>
        //        /// <para>MessageText: Schema update failed in recalculating validation cache.</para>
        //        /// </summary>
        //        DsRecalcschemaFailed = 8396,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_TREE_DELETE_NOT_FINISHED</para>
        //        /// <para>MessageText: The tree deletion is not finished. The request must be made again to continue deleting the tree.</para>
        //        /// </summary>
        //        DsTreeDeleteNotFinished = 8397,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_CANT_DELETE</para>
        //        /// <para>MessageText: The requested delete operation could not be performed.</para>
        //        /// </summary>
        //        DsCantDelete = 8398,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_ATT_SCHEMA_REQ_ID</para>
        //        /// <para>MessageText: Cannot read the governs class identifier for the schema record.</para>
        //        /// </summary>
        //        DsAttSchemaReqId = 8399,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_BAD_ATT_SCHEMA_SYNTAX</para>
        //        /// <para>MessageText: The attribute schema has bad syntax.</para>
        //        /// </summary>
        //        DsBadAttSchemaSyntax = 8400,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_CANT_CACHE_ATT</para>
        //        /// <para>MessageText: The attribute could not be cached.</para>
        //        /// </summary>
        //        DsCantCacheAtt = 8401,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_CANT_CACHE_CLASS</para>
        //        /// <para>MessageText: The class could not be cached.</para>
        //        /// </summary>
        //        DsCantCacheClass = 8402,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_CANT_REMOVE_ATT_CACHE</para>
        //        /// <para>MessageText: The attribute could not be removed from the cache.</para>
        //        /// </summary>
        //        DsCantRemoveAttCache = 8403,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_CANT_REMOVE_CLASS_CACHE</para>
        //        /// <para>MessageText: The class could not be removed from the cache.</para>
        //        /// </summary>
        //        DsCantRemoveClassCache = 8404,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_CANT_RETRIEVE_DN</para>
        //        /// <para>MessageText: The distinguished name attribute could not be read.</para>
        //        /// </summary>
        //        DsCantRetrieveDn = 8405,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_MISSING_SUPREF</para>
        //        /// <para>MessageText: No superior reference has been configured for the directory service. The directory service is therefore unable to issue referrals to objects outside this forest.</para>
        //        /// </summary>
        //        DsMissingSupref = 8406,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_CANT_RETRIEVE_INSTANCE</para>
        //        /// <para>MessageText: The instance type attribute could not be retrieved.</para>
        //        /// </summary>
        //        DsCantRetrieveInstance = 8407,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_CODE_INCONSISTENCY</para>
        //        /// <para>MessageText: An internal error has occurred.</para>
        //        /// </summary>
        //        DsCodeInconsistency = 8408,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_DATABASE_ERROR</para>
        //        /// <para>MessageText: A database error has occurred.</para>
        //        /// </summary>
        //        DsDatabaseError = 8409,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_GOVERNSID_MISSING</para>
        //        /// <para>MessageText: The attribute GOVERNSID is missing.</para>
        //        /// </summary>
        //        DsGovernsidMissing = 8410,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_MISSING_EXPECTED_ATT</para>
        //        /// <para>MessageText: An expected attribute is missing.</para>
        //        /// </summary>
        //        DsMissingExpectedAtt = 8411,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_NCNAME_MISSING_CR_REF</para>
        //        /// <para>MessageText: The specified naming context is missing a cross reference.</para>
        //        /// </summary>
        //        DsNcnameMissingCrRef = 8412,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_SECURITY_CHECKING_ERROR</para>
        //        /// <para>MessageText: A security checking error has occurred.</para>
        //        /// </summary>
        //        DsSecurityCheckingError = 8413,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_SCHEMA_NOT_LOADED</para>
        //        /// <para>MessageText: The schema is not loaded.</para>
        //        /// </summary>
        //        DsSchemaNotLoaded = 8414,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_SCHEMA_ALLOC_FAILED</para>
        //        /// <para>MessageText: Schema allocation failed. Please check if the machine is running low on memory.</para>
        //        /// </summary>
        //        DsSchemaAllocFailed = 8415,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_ATT_SCHEMA_REQ_SYNTAX</para>
        //        /// <para>MessageText: Failed to obtain the required syntax for the attribute schema.</para>
        //        /// </summary>
        //        DsAttSchemaReqSyntax = 8416,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_GCVERIFY_ERROR</para>
        //        /// <para>MessageText: The global catalog verification failed. The global catalog is not available or does not support the operation. Some part of the directory is currently not available.</para>
        //        /// </summary>
        //        DsGcverifyError = 8417,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_DRA_SCHEMA_MISMATCH</para>
        //        /// <para>MessageText: The replication operation failed because of a schema mismatch between the servers involved.</para>
        //        /// </summary>
        //        DsDraSchemaMismatch = 8418,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_CANT_FIND_DSA_OBJ</para>
        //        /// <para>MessageText: The DSA object could not be found.</para>
        //        /// </summary>
        //        DsCantFindDsaObj = 8419,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_CANT_FIND_EXPECTED_NC</para>
        //        /// <para>MessageText: The naming context could not be found.</para>
        //        /// </summary>
        //        DsCantFindExpectedNc = 8420,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_CANT_FIND_NC_IN_CACHE</para>
        //        /// <para>MessageText: The naming context could not be found in the cache.</para>
        //        /// </summary>
        //        DsCantFindNcInCache = 8421,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_CANT_RETRIEVE_CHILD</para>
        //        /// <para>MessageText: The child object could not be retrieved.</para>
        //        /// </summary>
        //        DsCantRetrieveChild = 8422,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_SECURITY_ILLEGAL_MODIFY</para>
        //        /// <para>MessageText: The modification was not permitted for security reasons.</para>
        //        /// </summary>
        //        DsSecurityIllegalModify = 8423,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_CANT_REPLACE_HIDDEN_REC</para>
        //        /// <para>MessageText: The operation cannot replace the hidden record.</para>
        //        /// </summary>
        //        DsCantReplaceHiddenRec = 8424,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_BAD_HIERARCHY_FILE</para>
        //        /// <para>MessageText: The hierarchy file is invalid.</para>
        //        /// </summary>
        //        DsBadHierarchyFile = 8425,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_BUILD_HIERARCHY_TABLE_FAILED</para>
        //        /// <para>MessageText: The attempt to build the hierarchy table failed.</para>
        //        /// </summary>
        //        DsBuildHierarchyTableFailed = 8426,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_CONFIG_PARAM_MISSING</para>
        //        /// <para>MessageText: The directory configuration parameter is missing from the registry.</para>
        //        /// </summary>
        //        DsConfigParamMissing = 8427,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_COUNTING_AB_INDICES_FAILED</para>
        //        /// <para>MessageText: The attempt to count the address book indices failed.</para>
        //        /// </summary>
        //        DsCountingAbIndicesFailed = 8428,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_HIERARCHY_TABLE_MALLOC_FAILED</para>
        //        /// <para>MessageText: The allocation of the hierarchy table failed.</para>
        //        /// </summary>
        //        DsHierarchyTableMallocFailed = 8429,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_INTERNAL_FAILURE</para>
        //        /// <para>MessageText: The directory service encountered an internal failure.</para>
        //        /// </summary>
        //        DsInternalFailure = 8430,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_UNKNOWN_ERROR</para>
        //        /// <para>MessageText: The directory service encountered an unknown failure.</para>
        //        /// </summary>
        //        DsUnknownError = 8431,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_ROOT_REQUIRES_CLASS_TOP</para>
        //        /// <para>MessageText: A root object requires a class of 'top'.</para>
        //        /// </summary>
        //        DsRootRequiresClassTop = 8432,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_REFUSING_FSMO_ROLES</para>
        //        /// <para>MessageText: This directory server is shutting down, and cannot take ownership of new floating single-master operation roles.</para>
        //        /// </summary>
        //        DsRefusingFsmoRoles = 8433,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_MISSING_FSMO_SETTINGS</para>
        //        /// <para>MessageText: The directory service is missing mandatory configuration information, and is unable to determine the ownership of floating single-master operation roles.</para>
        //        /// </summary>
        //        DsMissingFsmoSettings = 8434,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_UNABLE_TO_SURRENDER_ROLES</para>
        //        /// <para>MessageText: The directory service was unable to transfer ownership of one or more floating single-master operation roles to other servers.</para>
        //        /// </summary>
        //        DsUnableToSurrenderRoles = 8435,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_DRA_GENERIC</para>
        //        /// <para>MessageText: The replication operation failed.</para>
        //        /// </summary>
        //        DsDraGeneric = 8436,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_DRA_INVALID_PARAMETER</para>
        //        /// <para>MessageText: An invalid parameter was specified for this replication operation.</para>
        //        /// </summary>
        //        DsDraInvalidParameter = 8437,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_DRA_BUSY</para>
        //        /// <para>MessageText: The directory service is too busy to complete the replication operation at this time.</para>
        //        /// </summary>
        //        DsDraBusy = 8438,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_DRA_BAD_DN</para>
        //        /// <para>MessageText: The distinguished name specified for this replication operation is invalid.</para>
        //        /// </summary>
        //        DsDraBadDn = 8439,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_DRA_BAD_NC</para>
        //        /// <para>MessageText: The naming context specified for this replication operation is invalid.</para>
        //        /// </summary>
        //        DsDraBadNc = 8440,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_DRA_DN_EXISTS</para>
        //        /// <para>MessageText: The distinguished name specified for this replication operation already exists.</para>
        //        /// </summary>
        //        DsDraDnExists = 8441,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_DRA_INTERNAL_ERROR</para>
        //        /// <para>MessageText: The replication system encountered an internal error.</para>
        //        /// </summary>
        //        DsDraInternalError = 8442,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_DRA_INCONSISTENT_DIT</para>
        //        /// <para>MessageText: The replication operation encountered a database inconsistency.</para>
        //        /// </summary>
        //        DsDraInconsistentDit = 8443,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_DRA_CONNECTION_FAILED</para>
        //        /// <para>MessageText: The server specified for this replication operation could not be contacted.</para>
        //        /// </summary>
        //        DsDraConnectionFailed = 8444,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_DRA_BAD_INSTANCE_TYPE</para>
        //        /// <para>MessageText: The replication operation encountered an object with an invalid instance type.</para>
        //        /// </summary>
        //        DsDraBadInstanceType = 8445,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_DRA_OUT_OF_MEM</para>
        //        /// <para>MessageText: The replication operation failed to allocate memory.</para>
        //        /// </summary>
        //        DsDraOutOfMem = 8446,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_DRA_MAIL_PROBLEM</para>
        //        /// <para>MessageText: The replication operation encountered an error with the mail system.</para>
        //        /// </summary>
        //        DsDraMailProblem = 8447,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_DRA_REF_ALREADY_EXISTS</para>
        //        /// <para>MessageText: The replication reference information for the target server already exists.</para>
        //        /// </summary>
        //        DsDraRefAlreadyExists = 8448,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_DRA_REF_NOT_FOUND</para>
        //        /// <para>MessageText: The replication reference information for the target server does not exist.</para>
        //        /// </summary>
        //        DsDraRefNotFound = 8449,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_DRA_OBJ_IS_REP_SOURCE</para>
        //        /// <para>MessageText: The naming context cannot be removed because it is replicated to another server.</para>
        //        /// </summary>
        //        DsDraObjIsRepSource = 8450,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_DRA_DB_ERROR</para>
        //        /// <para>MessageText: The replication operation encountered a database error.</para>
        //        /// </summary>
        //        DsDraDbError = 8451,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_DRA_NO_REPLICA</para>
        //        /// <para>MessageText: The naming context is in the process of being removed or is not replicated from the specified server.</para>
        //        /// </summary>
        //        DsDraNoReplica = 8452,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_DRA_ACCESS_DENIED</para>
        //        /// <para>MessageText: Replication access was denied.</para>
        //        /// </summary>
        //        DsDraAccessDenied = 8453,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_DRA_NOT_SUPPORTED</para>
        //        /// <para>MessageText: The requested operation is not supported by this version of the directory service.</para>
        //        /// </summary>
        //        DsDraNotSupported = 8454,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_DRA_RPC_CANCELLED</para>
        //        /// <para>MessageText: The replication remote procedure call was cancelled.</para>
        //        /// </summary>
        //        DsDraRpcCancelled = 8455,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_DRA_SOURCE_DISABLED</para>
        //        /// <para>MessageText: The source server is currently rejecting replication requests.</para>
        //        /// </summary>
        //        DsDraSourceDisabled = 8456,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_DRA_SINK_DISABLED</para>
        //        /// <para>MessageText: The destination server is currently rejecting replication requests.</para>
        //        /// </summary>
        //        DsDraSinkDisabled = 8457,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_DRA_NAME_COLLISION</para>
        //        /// <para>MessageText: The replication operation failed due to a collision of object names.</para>
        //        /// </summary>
        //        DsDraNameCollision = 8458,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_DRA_SOURCE_REINSTALLED</para>
        //        /// <para>MessageText: The replication source has been reinstalled.</para>
        //        /// </summary>
        //        DsDraSourceReinstalled = 8459,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_DRA_MISSING_PARENT</para>
        //        /// <para>MessageText: The replication operation failed because a required parent object is missing.</para>
        //        /// </summary>
        //        DsDraMissingParent = 8460,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_DRA_PREEMPTED</para>
        //        /// <para>MessageText: The replication operation was preempted.</para>
        //        /// </summary>
        //        DsDraPreempted = 8461,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_DRA_ABANDON_SYNC</para>
        //        /// <para>MessageText: The replication synchronization attempt was abandoned because of a lack of updates.</para>
        //        /// </summary>
        //        DsDraAbandonSync = 8462,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_DRA_SHUTDOWN</para>
        //        /// <para>MessageText: The replication operation was terminated because the system is shutting down.</para>
        //        /// </summary>
        //        DsDraShutdown = 8463,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_DRA_INCOMPATIBLE_PARTIAL_SET</para>
        //        /// <para>MessageText: Synchronization attempt failed because the destination DC is currently waiting to synchronize new partial attributes from source. This condition is normal if a recent schema change modified the partial attribute set. The destination partial attribute set is not a subset of source partial attribute set.</para>
        //        /// </summary>
        //        DsDraIncompatiblePartialSet = 8464,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_DRA_SOURCE_IS_PARTIAL_REPLICA</para>
        //        /// <para>MessageText: The replication synchronization attempt failed because a master replica attempted to sync from a partial replica.</para>
        //        /// </summary>
        //        DsDraSourceIsPartialReplica = 8465,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_DRA_EXTN_CONNECTION_FAILED</para>
        //        /// <para>MessageText: The server specified for this replication operation was contacted, but that server was unable to contact an additional server needed to complete the operation.</para>
        //        /// </summary>
        //        DsDraExtnConnectionFailed = 8466,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_INSTALL_SCHEMA_MISMATCH</para>
        //        /// <para>MessageText: The version of the directory service schema of the source forest is not compatible with the version of directory service on this computer.</para>
        //        /// </summary>
        //        DsInstallSchemaMismatch = 8467,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_DUP_LINK_ID</para>
        //        /// <para>MessageText: Schema update failed: An attribute with the same link identifier already exists.</para>
        //        /// </summary>
        //        DsDupLinkId = 8468,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_NAME_ERROR_RESOLVING</para>
        //        /// <para>MessageText: Name translation: Generic processing error.</para>
        //        /// </summary>
        //        DsNameErrorResolving = 8469,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_NAME_ERROR_NOT_FOUND</para>
        //        /// <para>MessageText: Name translation: Could not find the name or insufficient right to see name.</para>
        //        /// </summary>
        //        DsNameErrorNotFound = 8470,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_NAME_ERROR_NOT_UNIQUE</para>
        //        /// <para>MessageText: Name translation: Input name mapped to more than one output name.</para>
        //        /// </summary>
        //        DsNameErrorNotUnique = 8471,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_NAME_ERROR_NO_MAPPING</para>
        //        /// <para>MessageText: Name translation: Input name found, but not the associated output format.</para>
        //        /// </summary>
        //        DsNameErrorNoMapping = 8472,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_NAME_ERROR_DOMAIN_ONLY</para>
        //        /// <para>MessageText: Name translation: Unable to resolve completely, only the domain was found.</para>
        //        /// </summary>
        //        DsNameErrorDomainOnly = 8473,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_NAME_ERROR_NO_SYNTACTICAL_MAPPING</para>
        //        /// <para>MessageText: Name translation: Unable to perform purely syntactical mapping at the client without going out to the wire.</para>
        //        /// </summary>
        //        DsNameErrorNoSyntacticalMapping = 8474,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_CONSTRUCTED_ATT_MOD</para>
        //        /// <para>MessageText: Modification of a constructed attribute is not allowed.</para>
        //        /// </summary>
        //        DsConstructedAttMod = 8475,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_WRONG_OM_OBJ_CLASS</para>
        //        /// <para>MessageText: The OM-Object-Class specified is incorrect for an attribute with the specified syntax.</para>
        //        /// </summary>
        //        DsWrongOmObjClass = 8476,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_DRA_REPL_PENDING</para>
        //        /// <para>MessageText: The replication request has been posted; waiting for reply.</para>
        //        /// </summary>
        //        DsDraReplPending = 8477,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_DS_REQUIRED</para>
        //        /// <para>MessageText: The requested operation requires a directory service, and none was available.</para>
        //        /// </summary>
        //        DsDsRequired = 8478,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_INVALID_LDAP_DISPLAY_NAME</para>
        //        /// <para>MessageText: The LDAP display name of the class or attribute contains non-ASCII characters.</para>
        //        /// </summary>
        //        DsInvalidLdapDisplayName = 8479,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_NON_BASE_SEARCH</para>
        //        /// <para>MessageText: The requested search operation is only supported for base searches.</para>
        //        /// </summary>
        //        DsNonBaseSearch = 8480,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_CANT_RETRIEVE_ATTS</para>
        //        /// <para>MessageText: The search failed to retrieve attributes from the database.</para>
        //        /// </summary>
        //        DsCantRetrieveAtts = 8481,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_BACKLINK_WITHOUT_LINK</para>
        //        /// <para>MessageText: The schema update operation tried to add a backward link attribute that has no corresponding forward link.</para>
        //        /// </summary>
        //        DsBacklinkWithoutLink = 8482,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_EPOCH_MISMATCH</para>
        //        /// <para>MessageText: Source and destination of a cross-domain move do not agree on the object's epoch number. Either source or destination does not have the latest version of the object.</para>
        //        /// </summary>
        //        DsEpochMismatch = 8483,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_SRC_NAME_MISMATCH</para>
        //        /// <para>MessageText: Source and destination of a cross-domain move do not agree on the object's current name. Either source or destination does not have the latest version of the object.</para>
        //        /// </summary>
        //        DsSrcNameMismatch = 8484,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_SRC_AND_DST_NC_IDENTICAL</para>
        //        /// <para>MessageText: Source and destination for the cross-domain move operation are identical. Caller should use local move operation instead of cross-domain move operation.</para>
        //        /// </summary>
        //        DsSrcAndDstNcIdentical = 8485,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_DST_NC_MISMATCH</para>
        //        /// <para>MessageText: Source and destination for a cross-domain move are not in agreement on the naming contexts in the forest. Either source or destination does not have the latest version of the Partitions container.</para>
        //        /// </summary>
        //        DsDstNcMismatch = 8486,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_NOT_AUTHORITIVE_FOR_DST_NC</para>
        //        /// <para>MessageText: Destination of a cross-domain move is not authoritative for the destination naming context.</para>
        //        /// </summary>
        //        DsNotAuthoritiveForDstNc = 8487,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_SRC_GUID_MISMATCH</para>
        //        /// <para>MessageText: Source and destination of a cross-domain move do not agree on the identity of the source object. Either source or destination does not have the latest version of the source object.</para>
        //        /// </summary>
        //        DsSrcGuidMismatch = 8488,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_CANT_MOVE_DELETED_OBJECT</para>
        //        /// <para>MessageText: Object being moved across-domains is already known to be deleted by the destination server. The source server does not have the latest version of the source object.</para>
        //        /// </summary>
        //        DsCantMoveDeletedObject = 8489,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_PDC_OPERATION_IN_PROGRESS</para>
        //        /// <para>MessageText: Another operation which requires exclusive access to the PDC FSMO is already in progress.</para>
        //        /// </summary>
        //        DsPdcOperationInProgress = 8490,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_CROSS_DOMAIN_CLEANUP_REQD</para>
        //        /// <para>MessageText: A cross-domain move operation failed such that two versions of the moved object exist - one each in the source and destination domains. The destination object needs to be removed to restore the system to a consistent state.</para>
        //        /// </summary>
        //        DsCrossDomainCleanupReqd = 8491,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_ILLEGAL_XDOM_MOVE_OPERATION</para>
        //        /// <para>MessageText: This object may not be moved across domain boundaries either because cross-domain moves for this class are disallowed, or the object has some special characteristics, e.g.: trust account or restricted RID, which prevent its move.</para>
        //        /// </summary>
        //        DsIllegalXdomMoveOperation = 8492,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_CANT_WITH_ACCT_GROUP_MEMBERSHPS</para>
        //        /// <para>MessageText: Can't move objects with memberships across domain boundaries as once moved, this would violate the membership conditions of the account group. Remove the object from any account group memberships and retry.</para>
        //        /// </summary>
        //        DsCantWithAcctGroupMembershps = 8493,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_NC_MUST_HAVE_NC_PARENT</para>
        //        /// <para>MessageText: A naming context head must be the immediate child of another naming context head, not of an interior node.</para>
        //        /// </summary>
        //        DsNcMustHaveNcParent = 8494,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_CR_IMPOSSIBLE_TO_VALIDATE</para>
        //        /// <para>MessageText: The directory cannot validate the proposed naming context name because it does not hold a replica of the naming context above the proposed naming context. Please ensure that the domain naming master role is held by a server that is configured as a global catalog server, and that the server is up to date with its replication partners. (Applies only to Windows= 2000 Domain Naming masters)</para>
        //        /// </summary>
        //        DsCrImpossibleToValidate = 8495,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_DST_DOMAIN_NOT_NATIVE</para>
        //        /// <para>MessageText: Destination domain must be in native mode.</para>
        //        /// </summary>
        //        DsDstDomainNotNative = 8496,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_MISSING_INFRASTRUCTURE_CONTAINER</para>
        //        /// <para>MessageText: The operation cannot be performed because the server does not have an infrastructure container in the domain of interest.</para>
        //        /// </summary>
        //        DsMissingInfrastructureContainer = 8497,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_CANT_MOVE_ACCOUNT_GROUP</para>
        //        /// <para>MessageText: Cross-domain move of non-empty account groups is not allowed.</para>
        //        /// </summary>
        //        DsCantMoveAccountGroup = 8498,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_CANT_MOVE_RESOURCE_GROUP</para>
        //        /// <para>MessageText: Cross-domain move of non-empty resource groups is not allowed.</para>
        //        /// </summary>
        //        DsCantMoveResourceGroup = 8499,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_INVALID_SEARCH_FLAG</para>
        //        /// <para>MessageText: The search flags for the attribute are invalid. The ANR bit is valid only on attributes of Unicode or Teletex strings.</para>
        //        /// </summary>
        //        DsInvalidSearchFlag = 8500,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_NO_TREE_DELETE_ABOVE_NC</para>
        //        /// <para>MessageText: Tree deletions starting at an object which has an NC head as a descendant are not allowed.</para>
        //        /// </summary>
        //        DsNoTreeDeleteAboveNc = 8501,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_COULDNT_LOCK_TREE_FOR_DELETE</para>
        //        /// <para>MessageText: The directory service failed to lock a tree in preparation for a tree deletion because the tree was in use.</para>
        //        /// </summary>
        //        DsCouldntLockTreeForDelete = 8502,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_COULDNT_IDENTIFY_OBJECTS_FOR_TREE_DELETE</para>
        //        /// <para>MessageText: The directory service failed to identify the list of objects to delete while attempting a tree deletion.</para>
        //        /// </summary>
        //        DsCouldntIdentifyObjectsForTreeDelete = 8503,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_SAM_INIT_FAILURE</para>
        //        /// <para>MessageText: Security Accounts Manager initialization failed because of the following error: %1.</para>
        //        /// </summary>
        //        DsSamInitFailure = 8504,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_SENSITIVE_GROUP_VIOLATION</para>
        //        /// <para>MessageText: Only an administrator can modify the membership list of an administrative group.</para>
        //        /// </summary>
        //        DsSensitiveGroupViolation = 8505,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_CANT_MOD_PRIMARYGROUPID</para>
        //        /// <para>MessageText: Cannot change the primary group ID of a domain controller account.</para>
        //        /// </summary>
        //        DsCantModPrimarygroupid = 8506,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_ILLEGAL_BASE_SCHEMA_MOD</para>
        //        /// <para>MessageText: An attempt is made to modify the base schema.</para>
        //        /// </summary>
        //        DsIllegalBaseSchemaMod = 8507,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_NONSAFE_SCHEMA_CHANGE</para>
        //        /// <para>MessageText: Adding a new mandatory attribute to an existing class, deleting a mandatory attribute from an existing class, or adding an optional attribute to the special class Top that is not a backlink attribute (directly or through inheritance, for example, by adding or deleting an auxiliary class) is not allowed.</para>
        //        /// </summary>
        //        DsNonsafeSchemaChange = 8508,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_SCHEMA_UPDATE_DISALLOWED</para>
        //        /// <para>MessageText: Schema update is not allowed on this DC because the DC is not the schema FSMO Role Owner.</para>
        //        /// </summary>
        //        DsSchemaUpdateDisallowed = 8509,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_CANT_CREATE_UNDER_SCHEMA</para>
        //        /// <para>MessageText: An object of this class cannot be created under the schema container. You can only create attribute-schema and class-schema objects under the schema container.</para>
        //        /// </summary>
        //        DsCantCreateUnderSchema = 8510,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_INSTALL_NO_SRC_SCH_VERSION</para>
        //        /// <para>MessageText: The replica/child install failed to get the objectVersion attribute on the schema container on the source DC. Either the attribute is missing on the schema container or the credentials supplied do not have permission to read it.</para>
        //        /// </summary>
        //        DsInstallNoSrcSchVersion = 8511,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_INSTALL_NO_SCH_VERSION_IN_INIFILE</para>
        //        /// <para>MessageText: The replica/child install failed to read the objectVersion attribute in the SCHEMA section of the file schema.ini in the system32 directory.</para>
        //        /// </summary>
        //        DsInstallNoSchVersionInInifile = 8512,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_INVALID_GROUP_TYPE</para>
        //        /// <para>MessageText: The specified group type is invalid.</para>
        //        /// </summary>
        //        DsInvalidGroupType = 8513,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_NO_NEST_GLOBALGROUP_IN_MIXEDDOMAIN</para>
        //        /// <para>MessageText: You cannot nest global groups in a mixed domain if the group is security-enabled.</para>
        //        /// </summary>
        //        DsNoNestGlobalgroupInMixeddomain = 8514,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_NO_NEST_LOCALGROUP_IN_MIXEDDOMAIN</para>
        //        /// <para>MessageText: You cannot nest local groups in a mixed domain if the group is security-enabled.</para>
        //        /// </summary>
        //        DsNoNestLocalgroupInMixeddomain = 8515,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_GLOBAL_CANT_HAVE_LOCAL_MEMBER</para>
        //        /// <para>MessageText: A global group cannot have a local group as a member.</para>
        //        /// </summary>
        //        DsGlobalCantHaveLocalMember = 8516,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_GLOBAL_CANT_HAVE_UNIVERSAL_MEMBER</para>
        //        /// <para>MessageText: A global group cannot have a universal group as a member.</para>
        //        /// </summary>
        //        DsGlobalCantHaveUniversalMember = 8517,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_UNIVERSAL_CANT_HAVE_LOCAL_MEMBER</para>
        //        /// <para>MessageText: A universal group cannot have a local group as a member.</para>
        //        /// </summary>
        //        DsUniversalCantHaveLocalMember = 8518,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_GLOBAL_CANT_HAVE_CROSSDOMAIN_MEMBER</para>
        //        /// <para>MessageText: A global group cannot have a cross-domain member.</para>
        //        /// </summary>
        //        DsGlobalCantHaveCrossdomainMember = 8519,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_LOCAL_CANT_HAVE_CROSSDOMAIN_LOCAL_MEMBER</para>
        //        /// <para>MessageText: A local group cannot have another cross domain local group as a member.</para>
        //        /// </summary>
        //        DsLocalCantHaveCrossdomainLocalMember = 8520,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_HAVE_PRIMARY_MEMBERS</para>
        //        /// <para>MessageText: A group with primary members cannot change to a security-disabled group.</para>
        //        /// </summary>
        //        DsHavePrimaryMembers = 8521,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_STRING_SD_CONVERSION_FAILED</para>
        //        /// <para>MessageText: The schema cache load failed to convert the string default SD on a class-schema object.</para>
        //        /// </summary>
        //        DsStringSdConversionFailed = 8522,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_NAMING_MASTER_GC</para>
        //        /// <para>MessageText: Only DSAs configured to be Global Catalog servers should be allowed to hold the Domain Naming Master FSMO role. (Applies only to Windows= 2000 servers)</para>
        //        /// </summary>
        //        DsNamingMasterGc = 8523,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_DNS_LOOKUP_FAILURE</para>
        //        /// <para>MessageText: The DSA operation is unable to proceed because of a DNS lookup failure.</para>
        //        /// </summary>
        //        DsDnsLookupFailure = 8524,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_COULDNT_UPDATE_SPNS</para>
        //        /// <para>MessageText: While processing a change to the DNS Host Name for an object, the Service Principal Name values could not be kept in sync.</para>
        //        /// </summary>
        //        DsCouldntUpdateSpns = 8525,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_CANT_RETRIEVE_SD</para>
        //        /// <para>MessageText: The Security Descriptor attribute could not be read.</para>
        //        /// </summary>
        //        DsCantRetrieveSd = 8526,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_KEY_NOT_UNIQUE</para>
        //        /// <para>MessageText: The object requested was not found, but an object with that key was found.</para>
        //        /// </summary>
        //        DsKeyNotUnique = 8527,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_WRONG_LINKED_ATT_SYNTAX</para>
        //        /// <para>MessageText: The syntax of the linked attribute being added is incorrect. Forward links can only have syntax= 2.5.5.1,= 2.5.5.7, and= 2.5.5.14, and backlinks can only have syntax= 2.5.5.1</para>
        //        /// </summary>
        //        DsWrongLinkedAttSyntax = 8528,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_SAM_NEED_BOOTKEY_PASSWORD</para>
        //        /// <para>MessageText: Security Account Manager needs to get the boot password.</para>
        //        /// </summary>
        //        DsSamNeedBootkeyPassword = 8529,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_SAM_NEED_BOOTKEY_FLOPPY</para>
        //        /// <para>MessageText: Security Account Manager needs to get the boot key from floppy disk.</para>
        //        /// </summary>
        //        DsSamNeedBootkeyFloppy = 8530,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_CANT_START</para>
        //        /// <para>MessageText: Directory Service cannot start.</para>
        //        /// </summary>
        //        DsCantStart = 8531,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_INIT_FAILURE</para>
        //        /// <para>MessageText: Directory Services could not start.</para>
        //        /// </summary>
        //        DsInitFailure = 8532,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_NO_PKT_PRIVACY_ON_CONNECTION</para>
        //        /// <para>MessageText: The connection between client and server requires packet privacy or better.</para>
        //        /// </summary>
        //        DsNoPktPrivacyOnConnection = 8533,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_SOURCE_DOMAIN_IN_FOREST</para>
        //        /// <para>MessageText: The source domain may not be in the same forest as destination.</para>
        //        /// </summary>
        //        DsSourceDomainInForest = 8534,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_DESTINATION_DOMAIN_NOT_IN_FOREST</para>
        //        /// <para>MessageText: The destination domain must be in the forest.</para>
        //        /// </summary>
        //        DsDestinationDomainNotInForest = 8535,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_DESTINATION_AUDITING_NOT_ENABLED</para>
        //        /// <para>MessageText: The operation requires that destination domain auditing be enabled.</para>
        //        /// </summary>
        //        DsDestinationAuditingNotEnabled = 8536,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_CANT_FIND_DC_FOR_SRC_DOMAIN</para>
        //        /// <para>MessageText: The operation couldn't locate a DC for the source domain.</para>
        //        /// </summary>
        //        DsCantFindDcForSrcDomain = 8537,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_SRC_OBJ_NOT_GROUP_OR_USER</para>
        //        /// <para>MessageText: The source object must be a group or user.</para>
        //        /// </summary>
        //        DsSrcObjNotGroupOrUser = 8538,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_SRC_SID_EXISTS_IN_FOREST</para>
        //        /// <para>MessageText: The source object's SID already exists in destination forest.</para>
        //        /// </summary>
        //        DsSrcSidExistsInForest = 8539,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_SRC_AND_DST_OBJECT_CLASS_MISMATCH</para>
        //        /// <para>MessageText: The source and destination object must be of the same type.</para>
        //        /// </summary>
        //        DsSrcAndDstObjectClassMismatch = 8540,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_SAM_INIT_FAILURE</para>
        //        /// <para>MessageText: Security Accounts Manager initialization failed because of the following error: %1.</para>
        //        /// </summary>
        //        SamInitFailure = 8541,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_DRA_SCHEMA_INFO_SHIP</para>
        //        /// <para>MessageText: Schema information could not be included in the replication request.</para>
        //        /// </summary>
        //        DsDraSchemaInfoShip = 8542,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_DRA_SCHEMA_CONFLICT</para>
        //        /// <para>MessageText: The replication operation could not be completed due to a schema incompatibility.</para>
        //        /// </summary>
        //        DsDraSchemaConflict = 8543,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_DRA_EARLIER_SCHEMA_CONFLICT</para>
        //        /// <para>MessageText: The replication operation could not be completed due to a previous schema incompatibility.</para>
        //        /// </summary>
        //        DsDraEarlierSchemaConflict = 8544,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_DRA_OBJ_NC_MISMATCH</para>
        //        /// <para>MessageText: The replication update could not be applied because either the source or the destination has not yet received information regarding a recent cross-domain move operation.</para>
        //        /// </summary>
        //        DsDraObjNcMismatch = 8545,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_NC_STILL_HAS_DSAS</para>
        //        /// <para>MessageText: The requested domain could not be deleted because there exist domain controllers that still host this domain.</para>
        //        /// </summary>
        //        DsNcStillHasDsas = 8546,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_GC_REQUIRED</para>
        //        /// <para>MessageText: The requested operation can be performed only on a global catalog server.</para>
        //        /// </summary>
        //        DsGcRequired = 8547,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_LOCAL_MEMBER_OF_LOCAL_ONLY</para>
        //        /// <para>MessageText: A local group can only be a member of other local groups in the same domain.</para>
        //        /// </summary>
        //        DsLocalMemberOfLocalOnly = 8548,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_NO_FPO_IN_UNIVERSAL_GROUPS</para>
        //        /// <para>MessageText: Foreign security principals cannot be members of universal groups.</para>
        //        /// </summary>
        //        DsNoFpoInUniversalGroups = 8549,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_CANT_ADD_TO_GC</para>
        //        /// <para>MessageText: The attribute is not allowed to be replicated to the GC because of security reasons.</para>
        //        /// </summary>
        //        DsCantAddToGc = 8550,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_NO_CHECKPOINT_WITH_PDC</para>
        //        /// <para>MessageText: The checkpoint with the PDC could not be taken because there too many modifications being processed currently.</para>
        //        /// </summary>
        //        DsNoCheckpointWithPdc = 8551,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_SOURCE_AUDITING_NOT_ENABLED</para>
        //        /// <para>MessageText: The operation requires that source domain auditing be enabled.</para>
        //        /// </summary>
        //        DsSourceAuditingNotEnabled = 8552,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_CANT_CREATE_IN_NONDOMAIN_NC</para>
        //        /// <para>MessageText: Security principal objects can only be created inside domain naming contexts.</para>
        //        /// </summary>
        //        DsCantCreateInNondomainNc = 8553,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_INVALID_NAME_FOR_SPN</para>
        //        /// <para>MessageText: A Service Principal Name (SPN) could not be constructed because the provided hostname is not in the necessary format.</para>
        //        /// </summary>
        //        DsInvalidNameForSpn = 8554,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_FILTER_USES_CONTRUCTED_ATTRS</para>
        //        /// <para>MessageText: A Filter was passed that uses constructed attributes.</para>
        //        /// </summary>
        //        DsFilterUsesContructedAttrs = 8555,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_UNICODEPWD_NOT_IN_QUOTES</para>
        //        /// <para>MessageText: The unicodePwd attribute value must be enclosed in double quotes.</para>
        //        /// </summary>
        //        DsUnicodepwdNotInQuotes = 8556,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_MACHINE_ACCOUNT_QUOTA_EXCEEDED</para>
        //        /// <para>MessageText: Your computer could not be joined to the domain. You have exceeded the maximum number of computer accounts you are allowed to create in this domain. Contact your system administrator to have this limit reset or increased.</para>
        //        /// </summary>
        //        DsMachineAccountQuotaExceeded = 8557,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_MUST_BE_RUN_ON_DST_DC</para>
        //        /// <para>MessageText: For security reasons, the operation must be run on the destination DC.</para>
        //        /// </summary>
        //        DsMustBeRunOnDstDc = 8558,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_SRC_DC_MUST_BE_SP4_OR_GREATER</para>
        //        /// <para>MessageText: For security reasons, the source DC must be NT4SP4 or greater.</para>
        //        /// </summary>
        //        DsSrcDcMustBeSp4OrGreater = 8559,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_CANT_TREE_DELETE_CRITICAL_OBJ</para>
        //        /// <para>MessageText: Critical Directory Service System objects cannot be deleted during tree delete operations. The tree delete may have been partially performed.</para>
        //        /// </summary>
        //        DsCantTreeDeleteCriticalObj = 8560,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_INIT_FAILURE_CONSOLE</para>
        //        /// <para>MessageText: Directory Services could not start because of the following error: %1.</para>
        //        /// </summary>
        //        DsInitFailureConsole = 8561,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_SAM_INIT_FAILURE_CONSOLE</para>
        //        /// <para>MessageText: Security Accounts Manager initialization failed because of the following error: %1.</para>
        //        /// </summary>
        //        DsSamInitFailureConsole = 8562,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_FOREST_VERSION_TOO_HIGH</para>
        //        /// <para>MessageText: The version of the operating system is incompatible with the current AD DS forest functional level or AD LDS Configuration Set functional level. You must upgrade to a new version of the operating system before this server can become an AD DS Domain Controller or add an AD LDS Instance in this AD DS Forest or AD LDS Configuration Set.</para>
        //        /// </summary>
        //        DsForestVersionTooHigh = 8563,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_DOMAIN_VERSION_TOO_HIGH</para>
        //        /// <para>MessageText: The version of the operating system installed is incompatible with the current domain functional level. You must upgrade to a new version of the operating system before this server can become a domain controller in this domain.</para>
        //        /// </summary>
        //        DsDomainVersionTooHigh = 8564,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_FOREST_VERSION_TOO_LOW</para>
        //        /// <para>MessageText: The version of the operating system installed on this server no longer supports the current AD DS Forest functional level or AD LDS Configuration Set functional level. You must raise the AD DS Forest functional level or AD LDS Configuration Set functional level before this server can become an AD DS Domain Controller or an AD LDS Instance in this Forest or Configuration Set.</para>
        //        /// </summary>
        //        DsForestVersionTooLow = 8565,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_DOMAIN_VERSION_TOO_LOW</para>
        //        /// <para>MessageText: The version of the operating system installed on this server no longer supports the current domain functional level. You must raise the domain functional level before this server can become a domain controller in this domain.</para>
        //        /// </summary>
        //        DsDomainVersionTooLow = 8566,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_INCOMPATIBLE_VERSION</para>
        //        /// <para>MessageText: The version of the operating system installed on this server is incompatible with the functional level of the domain or forest.</para>
        //        /// </summary>
        //        DsIncompatibleVersion = 8567,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_LOW_DSA_VERSION</para>
        //        /// <para>MessageText: The functional level of the domain (or forest) cannot be raised to the requested value, because there exist one or more domain controllers in the domain (or forest) that are at a lower incompatible functional level.</para>
        //        /// </summary>
        //        DsLowDsaVersion = 8568,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_NO_BEHAVIOR_VERSION_IN_MIXEDDOMAIN</para>
        //        /// <para>MessageText: The forest functional level cannot be raised to the requested value since one or more domains are still in mixed domain mode. All domains in the forest must be in native mode, for you to raise the forest functional level.</para>
        //        /// </summary>
        //        DsNoBehaviorVersionInMixeddomain = 8569,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_NOT_SUPPORTED_SORT_ORDER</para>
        //        /// <para>MessageText: The sort order requested is not supported.</para>
        //        /// </summary>
        //        DsNotSupportedSortOrder = 8570,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_NAME_NOT_UNIQUE</para>
        //        /// <para>MessageText: The requested name already exists as a unique identifier.</para>
        //        /// </summary>
        //        DsNameNotUnique = 8571,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_MACHINE_ACCOUNT_CREATED_PRENT4</para>
        //        /// <para>MessageText: The machine account was created pre-NT4. The account needs to be recreated.</para>
        //        /// </summary>
        //        DsMachineAccountCreatedPrent4 = 8572,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_OUT_OF_VERSION_STORE</para>
        //        /// <para>MessageText: The database is out of version store.</para>
        //        /// </summary>
        //        DsOutOfVersionStore = 8573,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_INCOMPATIBLE_CONTROLS_USED</para>
        //        /// <para>MessageText: Unable to continue operation because multiple conflicting controls were used.</para>
        //        /// </summary>
        //        DsIncompatibleControlsUsed = 8574,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_NO_REF_DOMAIN</para>
        //        /// <para>MessageText: Unable to find a valid security descriptor reference domain for this partition.</para>
        //        /// </summary>
        //        DsNoRefDomain = 8575,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_RESERVED_LINK_ID</para>
        //        /// <para>MessageText: Schema update failed: The link identifier is reserved.</para>
        //        /// </summary>
        //        DsReservedLinkId = 8576,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_LINK_ID_NOT_AVAILABLE</para>
        //        /// <para>MessageText: Schema update failed: There are no link identifiers available.</para>
        //        /// </summary>
        //        DsLinkIdNotAvailable = 8577,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_AG_CANT_HAVE_UNIVERSAL_MEMBER</para>
        //        /// <para>MessageText: An account group cannot have a universal group as a member.</para>
        //        /// </summary>
        //        DsAgCantHaveUniversalMember = 8578,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_MODIFYDN_DISALLOWED_BY_INSTANCE_TYPE</para>
        //        /// <para>MessageText: Rename or move operations on naming context heads or read-only objects are not allowed.</para>
        //        /// </summary>
        //        DsModifydnDisallowedByInstanceType = 8579,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_NO_OBJECT_MOVE_IN_SCHEMA_NC</para>
        //        /// <para>MessageText: Move operations on objects in the schema naming context are not allowed.</para>
        //        /// </summary>
        //        DsNoObjectMoveInSchemaNc = 8580,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_MODIFYDN_DISALLOWED_BY_FLAG</para>
        //        /// <para>MessageText: A system flag has been set on the object and does not allow the object to be moved or renamed.</para>
        //        /// </summary>
        //        DsModifydnDisallowedByFlag = 8581,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_MODIFYDN_WRONG_GRANDPARENT</para>
        //        /// <para>MessageText: This object is not allowed to change its grandparent container. Moves are not forbidden on this object, but are restricted to sibling containers.</para>
        //        /// </summary>
        //        DsModifydnWrongGrandparent = 8582,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_NAME_ERROR_TRUST_REFERRAL</para>
        //        /// <para>MessageText: Unable to resolve completely, a referral to another forest is generated.</para>
        //        /// </summary>
        //        DsNameErrorTrustReferral = 8583,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_NOT_SUPPORTED_ON_STANDARD_SERVER</para>
        //        /// <para>MessageText: The requested action is not supported on standard server.</para>
        //        /// </summary>
        //        NotSupportedOnStandardServer = 8584,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_CANT_ACCESS_REMOTE_PART_OF_AD</para>
        //        /// <para>MessageText: Could not access a partition of the directory service located on a remote server. Make sure at least one server is running for the partition in question.</para>
        //        /// </summary>
        //        DsCantAccessRemotePartOfAd = 8585,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_CR_IMPOSSIBLE_TO_VALIDATE_V2</para>
        //        /// <para>MessageText: The directory cannot validate the proposed naming context (or partition) name because it does not hold a replica nor can it contact a replica of the naming context above the proposed naming context. Please ensure that the parent naming context is properly registered in DNS, and at least one replica of this naming context is reachable by the Domain Naming master.</para>
        //        /// </summary>
        //        DsCrImpossibleToValidateV2 = 8586,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_THREAD_LIMIT_EXCEEDED</para>
        //        /// <para>MessageText: The thread limit for this request was exceeded.</para>
        //        /// </summary>
        //        DsThreadLimitExceeded = 8587,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_NOT_CLOSEST</para>
        //        /// <para>MessageText: The Global catalog server is not in the closest site.</para>
        //        /// </summary>
        //        DsNotClosest = 8588,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_CANT_DERIVE_SPN_WITHOUT_SERVER_REF</para>
        //        /// <para>MessageText: The DS cannot derive a service principal name (SPN) with which to mutually authenticate the target server because the corresponding server object in the local DS database has no serverReference attribute.</para>
        //        /// </summary>
        //        DsCantDeriveSpnWithoutServerRef = 8589,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_SINGLE_USER_MODE_FAILED</para>
        //        /// <para>MessageText: The Directory Service failed to enter single user mode.</para>
        //        /// </summary>
        //        DsSingleUserModeFailed = 8590,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_NTDSCRIPT_SYNTAX_ERROR</para>
        //        /// <para>MessageText: The Directory Service cannot parse the script because of a syntax error.</para>
        //        /// </summary>
        //        DsNtdscriptSyntaxError = 8591,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_NTDSCRIPT_PROCESS_ERROR</para>
        //        /// <para>MessageText: The Directory Service cannot process the script because of an error.</para>
        //        /// </summary>
        //        DsNtdscriptProcessError = 8592,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_DIFFERENT_REPL_EPOCHS</para>
        //        /// <para>MessageText: The directory service cannot perform the requested operation because the servers involved are of different replication epochs (which is usually related to a domain rename that is in progress).</para>
        //        /// </summary>
        //        DsDifferentReplEpochs = 8593,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_DRS_EXTENSIONS_CHANGED</para>
        //        /// <para>MessageText: The directory service binding must be renegotiated due to a change in the server extensions information.</para>
        //        /// </summary>
        //        DsDrsExtensionsChanged = 8594,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_REPLICA_SET_CHANGE_NOT_ALLOWED_ON_DISABLED_CR</para>
        //        /// <para>MessageText: Operation not allowed on a disabled cross ref.</para>
        //        /// </summary>
        //        DsReplicaSetChangeNotAllowedOnDisabledCr = 8595,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_NO_MSDS_INTID</para>
        //        /// <para>MessageText: Schema update failed: No values for msDS-IntId are available.</para>
        //        /// </summary>
        //        DsNoMsdsIntid = 8596,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_DUP_MSDS_INTID</para>
        //        /// <para>MessageText: Schema update failed: Duplicate msDS-INtId. Retry the operation.</para>
        //        /// </summary>
        //        DsDupMsdsIntid = 8597,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_EXISTS_IN_RDNATTID</para>
        //        /// <para>MessageText: Schema deletion failed: attribute is used in rDNAttID.</para>
        //        /// </summary>
        //        DsExistsInRdnattid = 8598,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_AUTHORIZATION_FAILED</para>
        //        /// <para>MessageText: The directory service failed to authorize the request.</para>
        //        /// </summary>
        //        DsAuthorizationFailed = 8599,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_INVALID_SCRIPT</para>
        //        /// <para>MessageText: The Directory Service cannot process the script because it is invalid.</para>
        //        /// </summary>
        //        DsInvalidScript = 8600,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_REMOTE_CROSSREF_OP_FAILED</para>
        //        /// <para>MessageText: The remote create cross reference operation failed on the Domain Naming Master FSMO. The operation's error is in the extended data.</para>
        //        /// </summary>
        //        DsRemoteCrossrefOpFailed = 8601,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_CROSS_REF_BUSY</para>
        //        /// <para>MessageText: A cross reference is in use locally with the same name.</para>
        //        /// </summary>
        //        DsCrossRefBusy = 8602,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_CANT_DERIVE_SPN_FOR_DELETED_DOMAIN</para>
        //        /// <para>MessageText: The DS cannot derive a service principal name (SPN) with which to mutually authenticate the target server because the server's domain has been deleted from the forest.</para>
        //        /// </summary>
        //        DsCantDeriveSpnForDeletedDomain = 8603,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_CANT_DEMOTE_WITH_WRITEABLE_NC</para>
        //        /// <para>MessageText: Writeable NCs prevent this DC from demoting.</para>
        //        /// </summary>
        //        DsCantDemoteWithWriteableNc = 8604,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_DUPLICATE_ID_FOUND</para>
        //        /// <para>MessageText: The requested object has a non-unique identifier and cannot be retrieved.</para>
        //        /// </summary>
        //        DsDuplicateIdFound = 8605,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_INSUFFICIENT_ATTR_TO_CREATE_OBJECT</para>
        //        /// <para>MessageText: Insufficient attributes were given to create an object. This object may not exist because it may have been deleted and already garbage collected.</para>
        //        /// </summary>
        //        DsInsufficientAttrToCreateObject = 8606,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_GROUP_CONVERSION_ERROR</para>
        //        /// <para>MessageText: The group cannot be converted due to attribute restrictions on the requested group type.</para>
        //        /// </summary>
        //        DsGroupConversionError = 8607,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_CANT_MOVE_APP_BASIC_GROUP</para>
        //        /// <para>MessageText: Cross-domain move of non-empty basic application groups is not allowed.</para>
        //        /// </summary>
        //        DsCantMoveAppBasicGroup = 8608,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_CANT_MOVE_APP_QUERY_GROUP</para>
        //        /// <para>MessageText: Cross-domain move of non-empty query based application groups is not allowed.</para>
        //        /// </summary>
        //        DsCantMoveAppQueryGroup = 8609,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_ROLE_NOT_VERIFIED</para>
        //        /// <para>MessageText: The FSMO role ownership could not be verified because its directory partition has not replicated successfully with at least one replication partner.</para>
        //        /// </summary>
        //        DsRoleNotVerified = 8610,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_WKO_CONTAINER_CANNOT_BE_SPECIAL</para>
        //        /// <para>MessageText: The target container for a redirection of a well known object container cannot already be a special container.</para>
        //        /// </summary>
        //        DsWkoContainerCannotBeSpecial = 8611,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_DOMAIN_RENAME_IN_PROGRESS</para>
        //        /// <para>MessageText: The Directory Service cannot perform the requested operation because a domain rename operation is in progress.</para>
        //        /// </summary>
        //        DsDomainRenameInProgress = 8612,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_EXISTING_AD_CHILD_NC</para>
        //        /// <para>MessageText: The directory service detected a child partition below the requested partition name. The partition hierarchy must be created in a top down method.</para>
        //        /// </summary>
        //        DsExistingAdChildNc = 8613,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_REPL_LIFETIME_EXCEEDED</para>
        //        /// <para>MessageText: The directory service cannot replicate with this server because the time since the last replication with this server has exceeded the tombstone lifetime.</para>
        //        /// </summary>
        //        DsReplLifetimeExceeded = 8614,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_DISALLOWED_IN_SYSTEM_CONTAINER</para>
        //        /// <para>MessageText: The requested operation is not allowed on an object under the system container.</para>
        //        /// </summary>
        //        DsDisallowedInSystemContainer = 8615,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_LDAP_SEND_QUEUE_FULL</para>
        //        /// <para>MessageText: The LDAP servers network send queue has filled up because the client is not processing the results of its requests fast enough. No more requests will be processed until the client catches up. If the client does not catch up then it will be disconnected.</para>
        //        /// </summary>
        //        DsLdapSendQueueFull = 8616,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_DRA_OUT_SCHEDULE_WINDOW</para>
        //        /// <para>MessageText: The scheduled replication did not take place because the system was too busy to execute the request within the schedule window. The replication queue is overloaded. Consider reducing the number of partners or decreasing the scheduled replication frequency.</para>
        //        /// </summary>
        //        DsDraOutScheduleWindow = 8617,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_POLICY_NOT_KNOWN</para>
        //        /// <para>MessageText: At this time, it cannot be determined if the branch replication policy is available on the hub domain controller. Please retry at a later time to account for replication latencies.</para>
        //        /// </summary>
        //        DsPolicyNotKnown = 8618,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_NO_SITE_SETTINGS_OBJECT</para>
        //        /// <para>MessageText: The site settings object for the specified site does not exist.</para>
        //        /// </summary>
        //        NoSiteSettingsObject = 8619,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_NO_SECRETS</para>
        //        /// <para>MessageText: The local account store does not contain secret material for the specified account.</para>
        //        /// </summary>
        //        NoSecrets = 8620,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_NO_WRITABLE_DC_FOUND</para>
        //        /// <para>MessageText: Could not find a writable domain controller in the domain.</para>
        //        /// </summary>
        //        NoWritableDcFound = 8621,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_NO_SERVER_OBJECT</para>
        //        /// <para>MessageText: The server object for the domain controller does not exist.</para>
        //        /// </summary>
        //        DsNoServerObject = 8622,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_NO_NTDSA_OBJECT</para>
        //        /// <para>MessageText: The NTDS Settings object for the domain controller does not exist.</para>
        //        /// </summary>
        //        DsNoNtdsaObject = 8623,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_NON_ASQ_SEARCH</para>
        //        /// <para>MessageText: The requested search operation is not supported for ASQ searches.</para>
        //        /// </summary>
        //        DsNonAsqSearch = 8624,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_AUDIT_FAILURE</para>
        //        /// <para>MessageText: A required audit event could not be generated for the operation.</para>
        //        /// </summary>
        //        DsAuditFailure = 8625,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_INVALID_SEARCH_FLAG_SUBTREE</para>
        //        /// <para>MessageText: The search flags for the attribute are invalid. The subtree index bit is valid only on single valued attributes.</para>
        //        /// </summary>
        //        DsInvalidSearchFlagSubtree = 8626,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_INVALID_SEARCH_FLAG_TUPLE</para>
        //        /// <para>MessageText: The search flags for the attribute are invalid. The tuple index bit is valid only on attributes of Unicode strings.</para>
        //        /// </summary>
        //        DsInvalidSearchFlagTuple = 8627,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_HIERARCHY_TABLE_TOO_DEEP</para>
        //        /// <para>MessageText: The address books are nested too deeply. Failed to build the hierarchy table.</para>
        //        /// </summary>
        //        DsHierarchyTableTooDeep = 8628,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_DRA_CORRUPT_UTD_VECTOR</para>
        //        /// <para>MessageText: The specified up-to-date-ness vector is corrupt.</para>
        //        /// </summary>
        //        DsDraCorruptUtdVector = 8629,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_DRA_SECRETS_DENIED</para>
        //        /// <para>MessageText: The request to replicate secrets is denied.</para>
        //        /// </summary>
        //        DsDraSecretsDenied = 8630,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_RESERVED_MAPI_ID</para>
        //        /// <para>MessageText: Schema update failed: The MAPI identifier is reserved.</para>
        //        /// </summary>
        //        DsReservedMapiId = 8631,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_MAPI_ID_NOT_AVAILABLE</para>
        //        /// <para>MessageText: Schema update failed: There are no MAPI identifiers available.</para>
        //        /// </summary>
        //        DsMapiIdNotAvailable = 8632,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_DRA_MISSING_KRBTGT_SECRET</para>
        //        /// <para>MessageText: The replication operation failed because the required attributes of the local krbtgt object are missing.</para>
        //        /// </summary>
        //        DsDraMissingKrbtgtSecret = 8633,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_DOMAIN_NAME_EXISTS_IN_FOREST</para>
        //        /// <para>MessageText: The domain name of the trusted domain already exists in the forest.</para>
        //        /// </summary>
        //        DsDomainNameExistsInForest = 8634,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_FLAT_NAME_EXISTS_IN_FOREST</para>
        //        /// <para>MessageText: The flat name of the trusted domain already exists in the forest.</para>
        //        /// </summary>
        //        DsFlatNameExistsInForest = 8635,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_INVALID_USER_PRINCIPAL_NAME</para>
        //        /// <para>MessageText: The User Principal Name (UPN) is invalid.</para>
        //        /// </summary>
        //        InvalidUserPrincipalName = 8636,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_OID_MAPPED_GROUP_CANT_HAVE_MEMBERS</para>
        //        /// <para>MessageText: OID mapped groups cannot have members.</para>
        //        /// </summary>
        //        DsOidMappedGroupCantHaveMembers = 8637,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_OID_NOT_FOUND</para>
        //        /// <para>MessageText: The specified OID cannot be found.</para>
        //        /// </summary>
        //        DsOidNotFound = 8638,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_DRA_RECYCLED_TARGET</para>
        //        /// <para>MessageText: The replication operation failed because the target object referred by a link value is recycled.</para>
        //        /// </summary>
        //        DsDraRecycledTarget = 8639,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_DISALLOWED_NC_REDIRECT</para>
        //        /// <para>MessageText: The redirect operation failed because the target object is in a NC different from the domain NC of the current domain controller.</para>
        //        /// </summary>
        //        DsDisallowedNcRedirect = 8640,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_HIGH_ADLDS_FFL</para>
        //        /// <para>MessageText: The functional level of the AD LDS configuration set cannot be lowered to the requested value.</para>
        //        /// </summary>
        //        DsHighAdldsFfl = 8641,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_HIGH_DSA_VERSION</para>
        //        /// <para>MessageText: The functional level of the domain (or forest) cannot be lowered to the requested value.</para>
        //        /// </summary>
        //        DsHighDsaVersion = 8642,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_LOW_ADLDS_FFL</para>
        //        /// <para>MessageText: The functional level of the AD LDS configuration set cannot be raised to the requested value, because there exist one or more ADLDS instances that are at a lower incompatible functional level.</para>
        //        /// </summary>
        //        DsLowAdldsFfl = 8643,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DOMAIN_SID_SAME_AS_LOCAL_WORKSTATION</para>
        //        /// <para>MessageText: The domain join cannot be completed because the SID of the domain you attempted to join was identical to the SID of this machine. This is a symptom of an improperly cloned operating system install.  You should run sysprep on this machine in order to generate a new machine SID. Please see http://go.microsoft.com/fwlink/?LinkId=168895 for more information.</para>
        //        /// </summary>
        //        DomainSidSameAsLocalWorkstation = 8644,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_UNDELETE_SAM_VALIDATION_FAILED</para>
        //        /// <para>MessageText: The undelete operation failed because the Sam Account Name or Additional Sam Account Name of the object being undeleted conflicts with an existing live object.</para>
        //        /// </summary>
        //        DsUndeleteSamValidationFailed = 8645,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_INCORRECT_ACCOUNT_TYPE</para>
        //        /// <para>MessageText: The system is not authoritative for the specified account and therefore cannot complete the operation. Please retry the operation using the provider associated with this account. If this is an online provider please use the provider's online site.</para>
        //        /// </summary>
        //        IncorrectAccountType = 8646,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_SPN_VALUE_NOT_UNIQUE_IN_FOREST</para>
        //        /// <para>MessageText: The operation failed because SPN value provided for addition/modification is not unique forest-wide.</para>
        //        /// </summary>
        //        DsSpnValueNotUniqueInForest = 8647,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_UPN_VALUE_NOT_UNIQUE_IN_FOREST</para>
        //        /// <para>MessageText: The operation failed because UPN value provided for addition/modification is not unique forest-wide.</para>
        //        /// </summary>
        //        DsUpnValueNotUniqueInForest = 8648,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_MISSING_FOREST_TRUST</para>
        //        /// <para>MessageText: The operation failed because the addition/modification referenced an inbound forest-wide trust that is not present.</para>
        //        /// </summary>
        //        DsMissingForestTrust = 8649,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DS_VALUE_KEY_NOT_UNIQUE</para>
        //        /// <para>MessageText: The link value specified was not found, but a link value with that key was found.</para>
        //        /// </summary>
        //        DsValueKeyNotUnique = 8650,







        //        RorResponseCodesBase = 9000,

        //RorRcodeNoError =noError,

        //RorMask = 0x00002328, //= 9000 or dnsErrorResponseCodesBase

        ///// <summary>
        ///// <para>MessageId: DNS_ERROR_RCODE_FORMAT_ERROR</para>
        ///// <para>MessageText: DNS server unable to interpret format.</para>
        ///// </summary>
        //        RorRcodeFormatError = 9001,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_RCODE_SERVER_FAILURE</para>
        //        /// <para>MessageText: DNS server failure.</para>
        //        /// </summary>
        //        RorRcodeServerFailure = 9002,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_RCODE_NAME_ERROR</para>
        //        /// <para>MessageText: DNS name does not exist.</para>
        //        /// </summary>
        //        RorRcodeNameError = 9003,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_RCODE_NOT_IMPLEMENTED</para>
        //        /// <para>MessageText: DNS request not supported by name server.</para>
        //        /// </summary>
        //        RorRcodeNotImplemented = 9004,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_RCODE_REFUSED</para>
        //        /// <para>MessageText: DNS operation refused.</para>
        //        /// </summary>
        //        RorRcodeRefused = 9005,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_RCODE_YXDOMAIN</para>
        //        /// <para>MessageText: DNS name that ought not exist, does exist.</para>
        //        /// </summary>
        //        RorRcodeYxdomain = 9006,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_RCODE_YXRRSET</para>
        //        /// <para>MessageText: DNS RR set that ought not exist, does exist.</para>
        //        /// </summary>
        //        RorRcodeYxrrset = 9007,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_RCODE_NXRRSET</para>
        //        /// <para>MessageText: DNS RR set that ought to exist, does not exist.</para>
        //        /// </summary>
        //        RorRcodeNxrrset = 9008,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_RCODE_NOTAUTH</para>
        //        /// <para>MessageText: DNS server not authoritative for zone.</para>
        //        /// </summary>
        //        RorRcodeNotauth = 9009,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_RCODE_NOTZONE</para>
        //        /// <para>MessageText: DNS name in update or prereq is not in zone.</para>
        //        /// </summary>
        //        RorRcodeNotzone = 9010,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_RCODE_BADSIG</para>
        //        /// <para>MessageText: DNS signature failed to verify.</para>
        //        /// </summary>
        //        RorRcodeBadsig = 9016,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_RCODE_BADKEY</para>
        //        /// <para>MessageText: DNS bad key.</para>
        //        /// </summary>
        //        RorRcodeBadkey = 9017,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_RCODE_BADTIME</para>
        //        /// <para>MessageText: DNS signature validity expired.</para>
        //        /// </summary>
        //        RorRcodeBadtime = 9018,

        //        RorRcodeLast = dnsErrorRcodeBadtime,



        //RorDnssecBase = 9100,

        ///// <summary>
        ///// <para>MessageId: DNS_ERROR_KEYMASTER_REQUIRED</para>
        ///// <para>MessageText: Only the DNS server acting as the key master for the zone may perform this operation.</para>
        ///// </summary>
        //        RorKeymasterRequired = 9101,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_NOT_ALLOWED_ON_SIGNED_ZONE</para>
        //        /// <para>MessageText: This operation is not allowed on a zone that is signed or has signing keys.</para>
        //        /// </summary>
        //        RorNotAllowedOnSignedZone = 9102,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_NSEC3_INCOMPATIBLE_WITH_RSA_SHA1</para>
        //        /// <para>MessageText: NSEC3 is not compatible with the RSA-SHA-1 algorithm. Choose a different algorithm or use NSEC.</para>
        //        /// </summary>
        //        RorNsec3IncompatibleWithRsaSha1 = 9103,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_NOT_ENOUGH_SIGNING_KEY_DESCRIPTORS</para>
        //        /// <para>MessageText: The zone does not have enough signing keys. There must be at least one key signing key (KSK) and at least one zone signing key (ZSK).</para>
        //        /// </summary>
        //        RorNotEnoughSigningKeyDescriptors = 9104,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_UNSUPPORTED_ALGORITHM</para>
        //        /// <para>MessageText: The specified algorithm is not supported.</para>
        //        /// </summary>
        //        RorUnsupportedAlgorithm = 9105,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_INVALID_KEY_SIZE</para>
        //        /// <para>MessageText: The specified key size is not supported.</para>
        //        /// </summary>
        //        RorInvalidKeySize = 9106,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_SIGNING_KEY_NOT_ACCESSIBLE</para>
        //        /// <para>MessageText: One or more of the signing keys for a zone are not accessible to the DNS server. Zone signing will not be operational until this error is resolved.</para>
        //        /// </summary>
        //        RorSigningKeyNotAccessible = 9107,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_KSP_DOES_NOT_SUPPORT_PROTECTION</para>
        //        /// <para>MessageText: The specified key storage provider does not support DPAPI++ data protection. Zone signing will not be operational until this error is resolved.</para>
        //        /// </summary>
        //        RorKspDoesNotSupportProtection = 9108,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_UNEXPECTED_DATA_PROTECTION_ERROR</para>
        //        /// <para>MessageText: An unexpected DPAPI++ error was encountered. Zone signing will not be operational until this error is resolved.</para>
        //        /// </summary>
        //        RorUnexpectedDataProtectionError = 9109,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_UNEXPECTED_CNG_ERROR</para>
        //        /// <para>MessageText: An unexpected crypto error was encountered. Zone signing may not be operational until this error is resolved.</para>
        //        /// </summary>
        //        RorUnexpectedCngError = 9110,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_UNKNOWN_SIGNING_PARAMETER_VERSION</para>
        //        /// <para>MessageText: The DNS server encountered a signing key with an unknown version. Zone signing will not be operational until this error is resolved.</para>
        //        /// </summary>
        //        RorUnknownSigningParameterVersion = 9111,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_KSP_NOT_ACCESSIBLE</para>
        //        /// <para>MessageText: The specified key service provider cannot be opened by the DNS server.</para>
        //        /// </summary>
        //        RorKspNotAccessible = 9112,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_TOO_MANY_SKDS</para>
        //        /// <para>MessageText: The DNS server cannot accept any more signing keys with the specified algorithm and KSK flag value for this zone.</para>
        //        /// </summary>
        //        RorTooManySkds = 9113,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_INVALID_ROLLOVER_PERIOD</para>
        //        /// <para>MessageText: The specified rollover period is invalid.</para>
        //        /// </summary>
        //        RorInvalidRolloverPeriod = 9114,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_INVALID_INITIAL_ROLLOVER_OFFSET</para>
        //        /// <para>MessageText: The specified initial rollover offset is invalid.</para>
        //        /// </summary>
        //        RorInvalidInitialRolloverOffset = 9115,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_ROLLOVER_IN_PROGRESS</para>
        //        /// <para>MessageText: The specified signing key is already in process of rolling over keys.</para>
        //        /// </summary>
        //        RorRolloverInProgress = 9116,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_STANDBY_KEY_NOT_PRESENT</para>
        //        /// <para>MessageText: The specified signing key does not have a standby key to revoke.</para>
        //        /// </summary>
        //        RorStandbyKeyNotPresent = 9117,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_NOT_ALLOWED_ON_ZSK</para>
        //        /// <para>MessageText: This operation is not allowed on a zone signing key (ZSK).</para>
        //        /// </summary>
        //        RorNotAllowedOnZsk = 9118,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_NOT_ALLOWED_ON_ACTIVE_SKD</para>
        //        /// <para>MessageText: This operation is not allowed on an active signing key.</para>
        //        /// </summary>
        //        RorNotAllowedOnActiveSkd = 9119,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_ROLLOVER_ALREADY_QUEUED</para>
        //        /// <para>MessageText: The specified signing key is already queued for rollover.</para>
        //        /// </summary>
        //        RorRolloverAlreadyQueued = 9120,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_NOT_ALLOWED_ON_UNSIGNED_ZONE</para>
        //        /// <para>MessageText: This operation is not allowed on an unsigned zone.</para>
        //        /// </summary>
        //        RorNotAllowedOnUnsignedZone = 9121,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_BAD_KEYMASTER</para>
        //        /// <para>MessageText: This operation could not be completed because the DNS server listed as the current key master for this zone is down or misconfigured. Resolve the problem on the current key master for this zone or use another DNS server to seize the key master role.</para>
        //        /// </summary>
        //        RorBadKeymaster = 9122,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_INVALID_SIGNATURE_VALIDITY_PERIOD</para>
        //        /// <para>MessageText: The specified signature validity period is invalid.</para>
        //        /// </summary>
        //        RorInvalidSignatureValidityPeriod = 9123,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_INVALID_NSEC3_ITERATION_COUNT</para>
        //        /// <para>MessageText: The specified NSEC3 iteration count is higher than allowed by the minimum key length used in the zone.</para>
        //        /// </summary>
        //        RorInvalidNsec3IterationCount = 9124,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_DNSSEC_IS_DISABLED</para>
        //        /// <para>MessageText: This operation could not be completed because the DNS server has been configured with DNSSEC features disabled. Enable DNSSEC on the DNS server.</para>
        //        /// </summary>
        //        RorDnssecIsDisabled = 9125,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_INVALID_XML</para>
        //        /// <para>MessageText: This operation could not be completed because the XML stream received is empty or syntactically invalid.</para>
        //        /// </summary>
        //        RorInvalidXml = 9126,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_NO_VALID_TRUST_ANCHORS</para>
        //        /// <para>MessageText: This operation completed, but no trust anchors were added because all of the trust anchors received were either invalid, unsupported, expired, or would not become valid in less than= 30 days.</para>
        //        /// </summary>
        //        RorNoValidTrustAnchors = 9127,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_ROLLOVER_NOT_POKEABLE</para>
        //        /// <para>MessageText: The specified signing key is not waiting for parental DS update.</para>
        //        /// </summary>
        //        RorRolloverNotPokeable = 9128,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_NSEC3_NAME_COLLISION</para>
        //        /// <para>MessageText: Hash collision detected during NSEC3 signing. Specify a different user-provided salt, or use a randomly generated salt, and attempt to sign the zone again.</para>
        //        /// </summary>
        //        RorNsec3NameCollision = 9129,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_NSEC_INCOMPATIBLE_WITH_NSEC3_RSA_SHA1</para>
        //        /// <para>MessageText: NSEC is not compatible with the NSEC3-RSA-SHA-1 algorithm. Choose a different algorithm or use NSEC3.</para>
        //        /// </summary>
        //        RorNsecIncompatibleWithNsec3RsaSha1 = 9130,



        //        RorPacketFmtBase = 9500,

        ///// <summary>
        ///// <para>MessageId: DNS_INFO_NO_RECORDS</para>
        ///// <para>MessageText: No records found for given DNS query.</para>
        ///// </summary>
        //        DNS_INFO_NO_RECORDS = 9501,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_BAD_PACKET</para>
        //        /// <para>MessageText: Bad DNS packet.</para>
        //        /// </summary>
        //        RorBadPacket = 9502,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_NO_PACKET</para>
        //        /// <para>MessageText: No DNS packet.</para>
        //        /// </summary>
        //        RorNoPacket = 9503,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_RCODE</para>
        //        /// <para>MessageText: DNS error, check rcode.</para>
        //        /// </summary>
        //        RorRcode = 9504,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_UNSECURE_PACKET</para>
        //        /// <para>MessageText: Unsecured DNS packet.</para>
        //        /// </summary>
        //        RorUnsecurePacket = 9505,

        //        AtusPacketUnsecure = dnsErrorUnsecurePacket,

        ///// <summary>
        ///// <para>MessageId: DNS_REQUEST_PENDING</para>
        ///// <para>MessageText: DNS query request is pending.</para>
        ///// </summary>
        //        DNS_REQUEST_PENDING = 9506,



        //        RorNoMemory          =  errorOutofmemory,
        //RorInvalidName       =  errorInvalidName,
        //RorInvalidData       =  errorInvalidData,

        //RorGeneralApiBase = 9550,

        ///// <summary>
        ///// <para>MessageId: DNS_ERROR_INVALID_TYPE</para>
        ///// <para>MessageText: Invalid DNS type.</para>
        ///// </summary>
        //        RorInvalidType = 9551,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_INVALID_IP_ADDRESS</para>
        //        /// <para>MessageText: Invalid IP address.</para>
        //        /// </summary>
        //        RorInvalidIpAddress = 9552,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_INVALID_PROPERTY</para>
        //        /// <para>MessageText: Invalid property.</para>
        //        /// </summary>
        //        RorInvalidProperty = 9553,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_TRY_AGAIN_LATER</para>
        //        /// <para>MessageText: Try DNS operation again later.</para>
        //        /// </summary>
        //        RorTryAgainLater = 9554,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_NOT_UNIQUE</para>
        //        /// <para>MessageText: Record for given name and type is not unique.</para>
        //        /// </summary>
        //        RorNotUnique = 9555,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_NON_RFC_NAME</para>
        //        /// <para>MessageText: DNS name does not comply with RFC specifications.</para>
        //        /// </summary>
        //        RorNonRfcName = 9556,

        //        /// <summary>
        //        /// <para>MessageId: DNS_STATUS_FQDN</para>
        //        /// <para>MessageText: DNS name is a fully-qualified DNS name.</para>
        //        /// </summary>
        //        DNS_STATUS_FQDN = 9557,

        //        /// <summary>
        //        /// <para>MessageId: DNS_STATUS_DOTTED_NAME</para>
        //        /// <para>MessageText: DNS name is dotted (multi-label).</para>
        //        /// </summary>
        //        DNS_STATUS_DOTTED_NAME = 9558,

        //        /// <summary>
        //        /// <para>MessageId: DNS_STATUS_SINGLE_PART_NAME</para>
        //        /// <para>MessageText: DNS name is a single-part name.</para>
        //        /// </summary>
        //        DNS_STATUS_SINGLE_PART_NAME = 9559,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_INVALID_NAME_CHAR</para>
        //        /// <para>MessageText: DNS name contains an invalid character.</para>
        //        /// </summary>
        //        RorInvalidNameChar = 9560,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_NUMERIC_NAME</para>
        //        /// <para>MessageText: DNS name is entirely numeric.</para>
        //        /// </summary>
        //        RorNumericName = 9561,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_NOT_ALLOWED_ON_ROOT_SERVER</para>
        //        /// <para>MessageText: The operation requested is not permitted on a DNS root server.</para>
        //        /// </summary>
        //        RorNotAllowedOnRootServer = 9562,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_NOT_ALLOWED_UNDER_DELEGATION</para>
        //        /// <para>MessageText: The record could not be created because this part of the DNS namespace has been delegated to another server.</para>
        //        /// </summary>
        //        RorNotAllowedUnderDelegation = 9563,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_CANNOT_FIND_ROOT_HINTS</para>
        //        /// <para>MessageText: The DNS server could not find a set of root hints.</para>
        //        /// </summary>
        //        RorCannotFindRootHints = 9564,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_INCONSISTENT_ROOT_HINTS</para>
        //        /// <para>MessageText: The DNS server found root hints but they were not consistent across all adapters.</para>
        //        /// </summary>
        //        RorInconsistentRootHints = 9565,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_DWORD_VALUE_TOO_SMALL</para>
        //        /// <para>MessageText: The specified value is too small for this parameter.</para>
        //        /// </summary>
        //        RorDwordValueTooSmall = 9566,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_DWORD_VALUE_TOO_LARGE</para>
        //        /// <para>MessageText: The specified value is too large for this parameter.</para>
        //        /// </summary>
        //        RorDwordValueTooLarge = 9567,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_BACKGROUND_LOADING</para>
        //        /// <para>MessageText: This operation is not allowed while the DNS server is loading zones in the background. Please try again later.</para>
        //        /// </summary>
        //        RorBackgroundLoading = 9568,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_NOT_ALLOWED_ON_RODC</para>
        //        /// <para>MessageText: The operation requested is not permitted on against a DNS server running on a read-only DC.</para>
        //        /// </summary>
        //        RorNotAllowedOnRodc = 9569,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_NOT_ALLOWED_UNDER_DNAME</para>
        //        /// <para>MessageText: No data is allowed to exist underneath a DNAME record.</para>
        //        /// </summary>
        //        RorNotAllowedUnderDname = 9570,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_DELEGATION_REQUIRED</para>
        //        /// <para>MessageText: This operation requires credentials delegation.</para>
        //        /// </summary>
        //        RorDelegationRequired = 9571,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_INVALID_POLICY_TABLE</para>
        //        /// <para>MessageText: Name resolution policy table has been corrupted. DNS resolution will fail until it is fixed. Contact your network administrator.</para>
        //        /// </summary>
        //        RorInvalidPolicyTable = 9572,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_ADDRESS_REQUIRED</para>
        //        /// <para>MessageText: Not allowed to remove all addresses.</para>
        //        /// </summary>
        //        RorAddressRequired = 9573,



        //        RorZoneBase = 9600,

        ///// <summary>
        ///// <para>MessageId: DNS_ERROR_ZONE_DOES_NOT_EXIST</para>
        ///// <para>MessageText: DNS zone does not exist.</para>
        ///// </summary>
        //        RorZoneDoesNotExist = 9601,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_NO_ZONE_INFO</para>
        //        /// <para>MessageText: DNS zone information not available.</para>
        //        /// </summary>
        //        RorNoZoneInfo = 9602,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_INVALID_ZONE_OPERATION</para>
        //        /// <para>MessageText: Invalid operation for DNS zone.</para>
        //        /// </summary>
        //        RorInvalidZoneOperation = 9603,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_ZONE_CONFIGURATION_ERROR</para>
        //        /// <para>MessageText: Invalid DNS zone configuration.</para>
        //        /// </summary>
        //        RorZoneConfigurationError = 9604,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_ZONE_HAS_NO_SOA_RECORD</para>
        //        /// <para>MessageText: DNS zone has no start of authority (SOA) record.</para>
        //        /// </summary>
        //        RorZoneHasNoSoaRecord = 9605,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_ZONE_HAS_NO_NS_RECORDS</para>
        //        /// <para>MessageText: DNS zone has no Name Server (NS) record.</para>
        //        /// </summary>
        //        RorZoneHasNoNsRecords = 9606,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_ZONE_LOCKED</para>
        //        /// <para>MessageText: DNS zone is locked.</para>
        //        /// </summary>
        //        RorZoneLocked = 9607,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_ZONE_CREATION_FAILED</para>
        //        /// <para>MessageText: DNS zone creation failed.</para>
        //        /// </summary>
        //        RorZoneCreationFailed = 9608,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_ZONE_ALREADY_EXISTS</para>
        //        /// <para>MessageText: DNS zone already exists.</para>
        //        /// </summary>
        //        RorZoneAlreadyExists = 9609,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_AUTOZONE_ALREADY_EXISTS</para>
        //        /// <para>MessageText: DNS automatic zone already exists.</para>
        //        /// </summary>
        //        RorAutozoneAlreadyExists = 9610,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_INVALID_ZONE_TYPE</para>
        //        /// <para>MessageText: Invalid DNS zone type.</para>
        //        /// </summary>
        //        RorInvalidZoneType = 9611,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_SECONDARY_REQUIRES_MASTER_IP</para>
        //        /// <para>MessageText: Secondary DNS zone requires master IP address.</para>
        //        /// </summary>
        //        RorSecondaryRequiresMasterIp = 9612,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_ZONE_NOT_SECONDARY</para>
        //        /// <para>MessageText: DNS zone not secondary.</para>
        //        /// </summary>
        //        RorZoneNotSecondary = 9613,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_NEED_SECONDARY_ADDRESSES</para>
        //        /// <para>MessageText: Need secondary IP address.</para>
        //        /// </summary>
        //        RorNeedSecondaryAddresses = 9614,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_WINS_INIT_FAILED</para>
        //        /// <para>MessageText: WINS initialization failed.</para>
        //        /// </summary>
        //        RorWinsInitFailed = 9615,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_NEED_WINS_SERVERS</para>
        //        /// <para>MessageText: Need WINS servers.</para>
        //        /// </summary>
        //        RorNeedWinsServers = 9616,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_NBSTAT_INIT_FAILED</para>
        //        /// <para>MessageText: NBTSTAT initialization call failed.</para>
        //        /// </summary>
        //        RorNbstatInitFailed = 9617,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_SOA_DELETE_INVALID</para>
        //        /// <para>MessageText: Invalid delete of start of authority (SOA)</para>
        //        /// </summary>
        //        RorSoaDeleteInvalid = 9618,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_FORWARDER_ALREADY_EXISTS</para>
        //        /// <para>MessageText: A conditional forwarding zone already exists for that name.</para>
        //        /// </summary>
        //        RorForwarderAlreadyExists = 9619,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_ZONE_REQUIRES_MASTER_IP</para>
        //        /// <para>MessageText: This zone must be configured with one or more master DNS server IP addresses.</para>
        //        /// </summary>
        //        RorZoneRequiresMasterIp = 9620,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_ZONE_IS_SHUTDOWN</para>
        //        /// <para>MessageText: The operation cannot be performed because this zone is shut down.</para>
        //        /// </summary>
        //        RorZoneIsShutdown = 9621,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_ZONE_LOCKED_FOR_SIGNING</para>
        //        /// <para>MessageText: This operation cannot be performed because the zone is currently being signed. Please try again later.</para>
        //        /// </summary>
        //        RorZoneLockedForSigning = 9622,



        //        RorDatafileBase = 9650,

        ///// <summary>
        ///// <para>MessageId: DNS_ERROR_PRIMARY_REQUIRES_DATAFILE</para>
        ///// <para>MessageText: Primary DNS zone requires datafile.</para>
        ///// </summary>
        //        RorPrimaryRequiresDatafile = 9651,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_INVALID_DATAFILE_NAME</para>
        //        /// <para>MessageText: Invalid datafile name for DNS zone.</para>
        //        /// </summary>
        //        RorInvalidDatafileName = 9652,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_DATAFILE_OPEN_FAILURE</para>
        //        /// <para>MessageText: Failed to open datafile for DNS zone.</para>
        //        /// </summary>
        //        RorDatafileOpenFailure = 9653,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_FILE_WRITEBACK_FAILED</para>
        //        /// <para>MessageText: Failed to write datafile for DNS zone.</para>
        //        /// </summary>
        //        RorFileWritebackFailed = 9654,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_DATAFILE_PARSING</para>
        //        /// <para>MessageText: Failure while reading datafile for DNS zone.</para>
        //        /// </summary>
        //        RorDatafileParsing = 9655,



        //        RorDatabaseBase = 9700,

        ///// <summary>
        ///// <para>MessageId: DNS_ERROR_RECORD_DOES_NOT_EXIST</para>
        ///// <para>MessageText: DNS record does not exist.</para>
        ///// </summary>
        //        RorRecordDoesNotExist = 9701,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_RECORD_FORMAT</para>
        //        /// <para>MessageText: DNS record format error.</para>
        //        /// </summary>
        //        RorRecordFormat = 9702,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_NODE_CREATION_FAILED</para>
        //        /// <para>MessageText: Node creation failure in DNS.</para>
        //        /// </summary>
        //        RorNodeCreationFailed = 9703,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_UNKNOWN_RECORD_TYPE</para>
        //        /// <para>MessageText: Unknown DNS record type.</para>
        //        /// </summary>
        //        RorUnknownRecordType = 9704,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_RECORD_TIMED_OUT</para>
        //        /// <para>MessageText: DNS record timed out.</para>
        //        /// </summary>
        //        RorRecordTimedOut = 9705,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_NAME_NOT_IN_ZONE</para>
        //        /// <para>MessageText: Name not in DNS zone.</para>
        //        /// </summary>
        //        RorNameNotInZone = 9706,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_CNAME_LOOP</para>
        //        /// <para>MessageText: CNAME loop detected.</para>
        //        /// </summary>
        //        RorCnameLoop = 9707,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_NODE_IS_CNAME</para>
        //        /// <para>MessageText: Node is a CNAME DNS record.</para>
        //        /// </summary>
        //        RorNodeIsCname = 9708,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_CNAME_COLLISION</para>
        //        /// <para>MessageText: A CNAME record already exists for given name.</para>
        //        /// </summary>
        //        RorCnameCollision = 9709,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_RECORD_ONLY_AT_ZONE_ROOT</para>
        //        /// <para>MessageText: Record only at DNS zone root.</para>
        //        /// </summary>
        //        RorRecordOnlyAtZoneRoot = 9710,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_RECORD_ALREADY_EXISTS</para>
        //        /// <para>MessageText: DNS record already exists.</para>
        //        /// </summary>
        //        RorRecordAlreadyExists = 9711,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_SECONDARY_DATA</para>
        //        /// <para>MessageText: Secondary DNS zone data error.</para>
        //        /// </summary>
        //        RorSecondaryData = 9712,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_NO_CREATE_CACHE_DATA</para>
        //        /// <para>MessageText: Could not create DNS cache data.</para>
        //        /// </summary>
        //        RorNoCreateCacheData = 9713,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_NAME_DOES_NOT_EXIST</para>
        //        /// <para>MessageText: DNS name does not exist.</para>
        //        /// </summary>
        //        RorNameDoesNotExist = 9714,

        //        /// <summary>
        //        /// <para>MessageId: DNS_WARNING_PTR_CREATE_FAILED</para>
        //        /// <para>MessageText: Could not create pointer (PTR) record.</para>
        //        /// </summary>
        //        DNS_WARNING_PTR_CREATE_FAILED = 9715,

        //        /// <summary>
        //        /// <para>MessageId: DNS_WARNING_DOMAIN_UNDELETED</para>
        //        /// <para>MessageText: DNS domain was undeleted.</para>
        //        /// </summary>
        //        DNS_WARNING_DOMAIN_UNDELETED = 9716,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_DS_UNAVAILABLE</para>
        //        /// <para>MessageText: The directory service is unavailable.</para>
        //        /// </summary>
        //        RorDsUnavailable = 9717,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_DS_ZONE_ALREADY_EXISTS</para>
        //        /// <para>MessageText: DNS zone already exists in the directory service.</para>
        //        /// </summary>
        //        RorDsZoneAlreadyExists = 9718,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_NO_BOOTFILE_IF_DS_ZONE</para>
        //        /// <para>MessageText: DNS server not creating or reading the boot file for the directory service integrated DNS zone.</para>
        //        /// </summary>
        //        RorNoBootfileIfDsZone = 9719,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_NODE_IS_DNAME</para>
        //        /// <para>MessageText: Node is a DNAME DNS record.</para>
        //        /// </summary>
        //        RorNodeIsDname = 9720,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_DNAME_COLLISION</para>
        //        /// <para>MessageText: A DNAME record already exists for given name.</para>
        //        /// </summary>
        //        RorDnameCollision = 9721,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_ALIAS_LOOP</para>
        //        /// <para>MessageText: An alias loop has been detected with either CNAME or DNAME records.</para>
        //        /// </summary>
        //        RorAliasLoop = 9722,



        //        RorOperationBase = 9750,

        ///// <summary>
        ///// <para>MessageId: DNS_INFO_AXFR_COMPLETE</para>
        ///// <para>MessageText: DNS AXFR (zone transfer) complete.</para>
        ///// </summary>
        //        DNS_INFO_AXFR_COMPLETE = 9751,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_AXFR</para>
        //        /// <para>MessageText: DNS zone transfer failed.</para>
        //        /// </summary>
        //        RorAxfr = 9752,

        //        /// <summary>
        //        /// <para>MessageId: DNS_INFO_ADDED_LOCAL_WINS</para>
        //        /// <para>MessageText: Added local WINS server.</para>
        //        /// </summary>
        //        DNS_INFO_ADDED_LOCAL_WINS = 9753,



        //        RorSecureBase = 9800,

        ///// <summary>
        ///// <para>MessageId: DNS_STATUS_CONTINUE_NEEDED</para>
        ///// <para>MessageText: Secure update call needs to continue update request.</para>
        ///// </summary>
        //        DNS_STATUS_CONTINUE_NEEDED = 9801,



        //        RorSetupBase = 9850,

        ///// <summary>
        ///// <para>MessageId: DNS_ERROR_NO_TCPIP</para>
        ///// <para>MessageText: TCP/IP network protocol not installed.</para>
        ///// </summary>
        //        RorNoTcpip = 9851,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_NO_DNS_SERVERS</para>
        //        /// <para>MessageText: No DNS servers configured for local system.</para>
        //        /// </summary>
        //        RorNoDnsServers = 9852,



        //        RorDpBase = 9900,

        ///// <summary>
        ///// <para>MessageId: DNS_ERROR_DP_DOES_NOT_EXIST</para>
        ///// <para>MessageText: The specified directory partition does not exist.</para>
        ///// </summary>
        //        RorDpDoesNotExist = 9901,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_DP_ALREADY_EXISTS</para>
        //        /// <para>MessageText: The specified directory partition already exists.</para>
        //        /// </summary>
        //        RorDpAlreadyExists = 9902,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_DP_NOT_ENLISTED</para>
        //        /// <para>MessageText: This DNS server is not enlisted in the specified directory partition.</para>
        //        /// </summary>
        //        RorDpNotEnlisted = 9903,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_DP_ALREADY_ENLISTED</para>
        //        /// <para>MessageText: This DNS server is already enlisted in the specified directory partition.</para>
        //        /// </summary>
        //        RorDpAlreadyEnlisted = 9904,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_DP_NOT_AVAILABLE</para>
        //        /// <para>MessageText: The directory partition is not available at this time. Please wait a few minutes and try again.</para>
        //        /// </summary>
        //        RorDpNotAvailable = 9905,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_DP_FSMO_ERROR</para>
        //        /// <para>MessageText: The operation failed because the domain naming master FSMO role could not be reached. The domain controller holding the domain naming master FSMO role is down or unable to service the request or is not running Windows Server= 2003 or later.</para>
        //        /// </summary>
        //        RorDpFsmoError = 9906,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_RRL_NOT_ENABLED</para>
        //        /// <para>MessageText: The RRL is not enabled.</para>
        //        /// </summary>
        //        RorRrlNotEnabled = 9911,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_RRL_INVALID_WINDOW_SIZE</para>
        //        /// <para>MessageText: The window size parameter is invalid. It should be greater than or equal to= 1.</para>
        //        /// </summary>
        //        RorRrlInvalidWindowSize = 9912,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_RRL_INVALID_IPV4_PREFIX</para>
        //        /// <para>MessageText: The IPv4 prefix length parameter is invalid. It should be less than or equal to= 32.</para>
        //        /// </summary>
        //        RorRrlInvalidIpv4Prefix = 9913,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_RRL_INVALID_IPV6_PREFIX</para>
        //        /// <para>MessageText: The IPv6 prefix length parameter is invalid. It should be less than or equal to= 128.</para>
        //        /// </summary>
        //        RorRrlInvalidIpv6Prefix = 9914,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_RRL_INVALID_TC_RATE</para>
        //        /// <para>MessageText: The TC Rate parameter is invalid. It should be less than= 10.</para>
        //        /// </summary>
        //        RorRrlInvalidTcRate = 9915,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_RRL_INVALID_LEAK_RATE</para>
        //        /// <para>MessageText: The Leak Rate parameter is invalid. It should be either= 0, or between= 2 and= 10.</para>
        //        /// </summary>
        //        RorRrlInvalidLeakRate = 9916,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_RRL_LEAK_RATE_LESSTHAN_TC_RATE</para>
        //        /// <para>MessageText: The Leak Rate or TC Rate parameter is invalid. Leak Rate should be greater than TC Rate.</para>
        //        /// </summary>
        //        RorRrlLeakRateLessthanTcRate = 9917,


        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_VIRTUALIZATION_INSTANCE_ALREADY_EXISTS</para>
        //        /// <para>MessageText: The virtualization instance already exists.</para>
        //        /// </summary>
        //        RorVirtualizationInstanceAlreadyExists = 9921,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_VIRTUALIZATION_INSTANCE_DOES_NOT_EXIST</para>
        //        /// <para>MessageText: The virtualization instance does not exist.</para>
        //        /// </summary>
        //        RorVirtualizationInstanceDoesNotExist = 9922,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_VIRTUALIZATION_TREE_LOCKED</para>
        //        /// <para>MessageText: The virtualization tree is locked.</para>
        //        /// </summary>
        //        RorVirtualizationTreeLocked = 9923,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_INVAILD_VIRTUALIZATION_INSTANCE_NAME</para>
        //        /// <para>MessageText: Invalid virtualization instance name.</para>
        //        /// </summary>
        //        RorInvaildVirtualizationInstanceName = 9924,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_DEFAULT_VIRTUALIZATION_INSTANCE</para>
        //        /// <para>MessageText: The default virtualization instance cannot be added, removed or modified.</para>
        //        /// </summary>
        //        RorDefaultVirtualizationInstance = 9925,


        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_ZONESCOPE_ALREADY_EXISTS</para>
        //        /// <para>MessageText: The scope already exists for the zone.</para>
        //        /// </summary>
        //        RorZonescopeAlreadyExists = 9951,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_ZONESCOPE_DOES_NOT_EXIST</para>
        //        /// <para>MessageText: The scope does not exist for the zone.</para>
        //        /// </summary>
        //        RorZonescopeDoesNotExist = 9952,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_DEFAULT_ZONESCOPE</para>
        //        /// <para>MessageText: The scope is the same as the default zone scope.</para>
        //        /// </summary>
        //        RorDefaultZonescope = 9953,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_INVALID_ZONESCOPE_NAME</para>
        //        /// <para>MessageText: The scope name contains invalid characters.</para>
        //        /// </summary>
        //        RorInvalidZonescopeName = 9954,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_NOT_ALLOWED_WITH_ZONESCOPES</para>
        //        /// <para>MessageText: Operation not allowed when the zone has scopes.</para>
        //        /// </summary>
        //        RorNotAllowedWithZonescopes = 9955,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_LOAD_ZONESCOPE_FAILED</para>
        //        /// <para>MessageText: Failed to load zone scope.</para>
        //        /// </summary>
        //        RorLoadZonescopeFailed = 9956,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_ZONESCOPE_FILE_WRITEBACK_FAILED</para>
        //        /// <para>MessageText: Failed to write data file for DNS zone scope. Please verify the file exists and is writable.</para>
        //        /// </summary>
        //        RorZonescopeFileWritebackFailed = 9957,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_INVALID_SCOPE_NAME</para>
        //        /// <para>MessageText: The scope name contains invalid characters.</para>
        //        /// </summary>
        //        RorInvalidScopeName = 9958,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_SCOPE_DOES_NOT_EXIST</para>
        //        /// <para>MessageText: The scope does not exist.</para>
        //        /// </summary>
        //        RorScopeDoesNotExist = 9959,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_DEFAULT_SCOPE</para>
        //        /// <para>MessageText: The scope is the same as the default scope.</para>
        //        /// </summary>
        //        RorDefaultScope = 9960,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_INVALID_SCOPE_OPERATION</para>
        //        /// <para>MessageText: The operation is invalid on the scope.</para>
        //        /// </summary>
        //        RorInvalidScopeOperation = 9961,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_SCOPE_LOCKED</para>
        //        /// <para>MessageText: The scope is locked.</para>
        //        /// </summary>
        //        RorScopeLocked = 9962,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_SCOPE_ALREADY_EXISTS</para>
        //        /// <para>MessageText: The scope already exists.</para>
        //        /// </summary>
        //        RorScopeAlreadyExists = 9963,


        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_POLICY_ALREADY_EXISTS</para>
        //        /// <para>MessageText: A policy with the same name already exists on this level (server level or zone level) on the DNS server.</para>
        //        /// </summary>
        //        RorPolicyAlreadyExists = 9971,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_POLICY_DOES_NOT_EXIST</para>
        //        /// <para>MessageText: No policy with this name exists on this level (server level or zone level) on the DNS server.</para>
        //        /// </summary>
        //        RorPolicyDoesNotExist = 9972,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_POLICY_INVALID_CRITERIA</para>
        //        /// <para>MessageText: The criteria provided in the policy are invalid.</para>
        //        /// </summary>
        //        RorPolicyInvalidCriteria = 9973,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_POLICY_INVALID_SETTINGS</para>
        //        /// <para>MessageText: At least one of the settings of this policy is invalid.</para>
        //        /// </summary>
        //        RorPolicyInvalidSettings = 9974,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_CLIENT_SUBNET_IS_ACCESSED</para>
        //        /// <para>MessageText: The client subnet cannot be deleted while it is being accessed by a policy.</para>
        //        /// </summary>
        //        RorClientSubnetIsAccessed = 9975,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_CLIENT_SUBNET_DOES_NOT_EXIST</para>
        //        /// <para>MessageText: The client subnet does not exist on the DNS server.</para>
        //        /// </summary>
        //        RorClientSubnetDoesNotExist = 9976,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_CLIENT_SUBNET_ALREADY_EXISTS</para>
        //        /// <para>MessageText: A client subnet with this name already exists on the DNS server.</para>
        //        /// </summary>
        //        RorClientSubnetAlreadyExists = 9977,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_SUBNET_DOES_NOT_EXIST</para>
        //        /// <para>MessageText: The IP subnet specified does not exist in the client subnet.</para>
        //        /// </summary>
        //        RorSubnetDoesNotExist = 9978,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_SUBNET_ALREADY_EXISTS</para>
        //        /// <para>MessageText: The IP subnet that is being added, already exists in the client subnet.</para>
        //        /// </summary>
        //        RorSubnetAlreadyExists = 9979,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_POLICY_LOCKED</para>
        //        /// <para>MessageText: The policy is locked.</para>
        //        /// </summary>
        //        RorPolicyLocked = 9980,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_POLICY_INVALID_WEIGHT</para>
        //        /// <para>MessageText: The weight of the scope in the policy is invalid.</para>
        //        /// </summary>
        //        RorPolicyInvalidWeight = 9981,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_POLICY_INVALID_NAME</para>
        //        /// <para>MessageText: The DNS policy name is invalid.</para>
        //        /// </summary>
        //        RorPolicyInvalidName = 9982,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_POLICY_MISSING_CRITERIA</para>
        //        /// <para>MessageText: The policy is missing criteria.</para>
        //        /// </summary>
        //        RorPolicyMissingCriteria = 9983,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_INVALID_CLIENT_SUBNET_NAME</para>
        //        /// <para>MessageText: The name of the the client subnet record is invalid.</para>
        //        /// </summary>
        //        RorInvalidClientSubnetName = 9984,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_POLICY_PROCESSING_ORDER_INVALID</para>
        //        /// <para>MessageText: Invalid policy processing order.</para>
        //        /// </summary>
        //        RorPolicyProcessingOrderInvalid = 9985,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_POLICY_SCOPE_MISSING</para>
        //        /// <para>MessageText: The scope information has not been provided for a policy that requires it.</para>
        //        /// </summary>
        //        RorPolicyScopeMissing = 9986,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_POLICY_SCOPE_NOT_ALLOWED</para>
        //        /// <para>MessageText: The scope information has been provided for a policy that does not require it.</para>
        //        /// </summary>
        //        RorPolicyScopeNotAllowed = 9987,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_SERVERSCOPE_IS_REFERENCED</para>
        //        /// <para>MessageText: The server scope cannot be deleted because it is referenced by a DNS Policy.</para>
        //        /// </summary>
        //        RorServerscopeIsReferenced = 9988,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_ZONESCOPE_IS_REFERENCED</para>
        //        /// <para>MessageText: The zone scope cannot be deleted because it is referenced by a DNS Policy.</para>
        //        /// </summary>
        //        RorZonescopeIsReferenced = 9989,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_POLICY_INVALID_CRITERIA_CLIENT_SUBNET</para>
        //        /// <para>MessageText: The criterion client subnet provided in the policy is invalid.</para>
        //        /// </summary>
        //        RorPolicyInvalidCriteriaClientSubnet = 9990,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_POLICY_INVALID_CRITERIA_TRANSPORT_PROTOCOL</para>
        //        /// <para>MessageText: The criterion transport protocol provided in the policy is invalid.</para>
        //        /// </summary>
        //        RorPolicyInvalidCriteriaTransportProtocol = 9991,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_POLICY_INVALID_CRITERIA_NETWORK_PROTOCOL</para>
        //        /// <para>MessageText: The criterion network protocol provided in the policy is invalid.</para>
        //        /// </summary>
        //        RorPolicyInvalidCriteriaNetworkProtocol = 9992,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_POLICY_INVALID_CRITERIA_INTERFACE</para>
        //        /// <para>MessageText: The criterion interface provided in the policy is invalid.</para>
        //        /// </summary>
        //        RorPolicyInvalidCriteriaInterface = 9993,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_POLICY_INVALID_CRITERIA_FQDN</para>
        //        /// <para>MessageText: The criterion FQDN provided in the policy is invalid.</para>
        //        /// </summary>
        //        RorPolicyInvalidCriteriaFqdn = 9994,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_POLICY_INVALID_CRITERIA_QUERY_TYPE</para>
        //        /// <para>MessageText: The criterion query type provided in the policy is invalid.</para>
        //        /// </summary>
        //        RorPolicyInvalidCriteriaQueryType = 9995,

        //        /// <summary>
        //        /// <para>MessageId: DNS_ERROR_POLICY_INVALID_CRITERIA_TIME_OF_DAY</para>
        //        /// <para>MessageText: The criterion time of day provided in the policy is invalid.</para>
        //        /// </summary>
        //        RorPolicyInvalidCriteriaTimeOfDay = 9996,







        //# ifndef WSABASEERR
        //        WSABASEERR = 10000,
        ///// <summary>
        ///// <para>MessageId: WSAEINTR</para>
        ///// <para>MessageText: A blocking operation was interrupted by a call to WSACancelBlockingCall.</para>
        ///// </summary>
        //WSAEINTR = 10004,

        //        /// <summary>
        //        /// <para>MessageId: WSAEBADF</para>
        //        /// <para>MessageText: The file handle supplied is not valid.</para>
        //        /// </summary>
        //        WSAEBADF = 10009,

        //        /// <summary>
        //        /// <para>MessageId: WSAEACCES</para>
        //        /// <para>MessageText: An attempt was made to access a socket in a way forbidden by its access permissions.</para>
        //        /// </summary>
        //        WSAEACCES = 10013,

        //        /// <summary>
        //        /// <para>MessageId: WSAEFAULT</para>
        //        /// <para>MessageText: The system detected an invalid pointer address in attempting to use a pointer argument in a call.</para>
        //        /// </summary>
        //        WSAEFAULT = 10014,

        //        /// <summary>
        //        /// <para>MessageId: WSAEINVAL</para>
        //        /// <para>MessageText: An invalid argument was supplied.</para>
        //        /// </summary>
        //        WSAEINVAL = 10022,

        //        /// <summary>
        //        /// <para>MessageId: WSAEMFILE</para>
        //        /// <para>MessageText: Too many open sockets.</para>
        //        /// </summary>
        //        WSAEMFILE = 10024,

        //        /// <summary>
        //        /// <para>MessageId: WSAEWOULDBLOCK</para>
        //        /// <para>MessageText: A non-blocking socket operation could not be completed immediately.</para>
        //        /// </summary>
        //        WSAEWOULDBLOCK = 10035,

        //        /// <summary>
        //        /// <para>MessageId: WSAEINPROGRESS</para>
        //        /// <para>MessageText: A blocking operation is currently executing.</para>
        //        /// </summary>
        //        WSAEINPROGRESS = 10036,

        //        /// <summary>
        //        /// <para>MessageId: WSAEALREADY</para>
        //        /// <para>MessageText: An operation was attempted on a non-blocking socket that already had an operation in progress.</para>
        //        /// </summary>
        //        WSAEALREADY = 10037,

        //        /// <summary>
        //        /// <para>MessageId: WSAENOTSOCK</para>
        //        /// <para>MessageText: An operation was attempted on something that is not a socket.</para>
        //        /// </summary>
        //        WSAENOTSOCK = 10038,

        //        /// <summary>
        //        /// <para>MessageId: WSAEDESTADDRREQ</para>
        //        /// <para>MessageText: A required address was omitted from an operation on a socket.</para>
        //        /// </summary>
        //        WSAEDESTADDRREQ = 10039,

        //        /// <summary>
        //        /// <para>MessageId: WSAEMSGSIZE</para>
        //        /// <para>MessageText: A message sent on a datagram socket was larger than the internal message buffer or some other network limit, or the buffer used to receive a datagram into was smaller than the datagram itself.</para>
        //        /// </summary>
        //        WSAEMSGSIZE = 10040,

        //        /// <summary>
        //        /// <para>MessageId: WSAEPROTOTYPE</para>
        //        /// <para>MessageText: A protocol was specified in the socket function call that does not support the semantics of the socket type requested.</para>
        //        /// </summary>
        //        WSAEPROTOTYPE = 10041,

        //        /// <summary>
        //        /// <para>MessageId: WSAENOPROTOOPT</para>
        //        /// <para>MessageText: An unknown, invalid, or unsupported option or level was specified in a getsockopt or setsockopt call.</para>
        //        /// </summary>
        //        WSAENOPROTOOPT = 10042,

        //        /// <summary>
        //        /// <para>MessageId: WSAEPROTONOSUPPORT</para>
        //        /// <para>MessageText: The requested protocol has not been configured into the system, or no implementation for it exists.</para>
        //        /// </summary>
        //        WSAEPROTONOSUPPORT = 10043,

        //        /// <summary>
        //        /// <para>MessageId: WSAESOCKTNOSUPPORT</para>
        //        /// <para>MessageText: The support for the specified socket type does not exist in this address family.</para>
        //        /// </summary>
        //        WSAESOCKTNOSUPPORT = 10044,

        //        /// <summary>
        //        /// <para>MessageId: WSAEOPNOTSUPP</para>
        //        /// <para>MessageText: The attempted operation is not supported for the type of object referenced.</para>
        //        /// </summary>
        //        WSAEOPNOTSUPP = 10045,

        //        /// <summary>
        //        /// <para>MessageId: WSAEPFNOSUPPORT</para>
        //        /// <para>MessageText: The protocol family has not been configured into the system or no implementation for it exists.</para>
        //        /// </summary>
        //        WSAEPFNOSUPPORT = 10046,

        //        /// <summary>
        //        /// <para>MessageId: WSAEAFNOSUPPORT</para>
        //        /// <para>MessageText: An address incompatible with the requested protocol was used.</para>
        //        /// </summary>
        //        WSAEAFNOSUPPORT = 10047,

        //        /// <summary>
        //        /// <para>MessageId: WSAEADDRINUSE</para>
        //        /// <para>MessageText: Only one usage of each socket address (protocol/network address/port) is normally permitted.</para>
        //        /// </summary>
        //        WSAEADDRINUSE = 10048,

        //        /// <summary>
        //        /// <para>MessageId: WSAEADDRNOTAVAIL</para>
        //        /// <para>MessageText: The requested address is not valid in its context.</para>
        //        /// </summary>
        //        WSAEADDRNOTAVAIL = 10049,

        //        /// <summary>
        //        /// <para>MessageId: WSAENETDOWN</para>
        //        /// <para>MessageText: A socket operation encountered a dead network.</para>
        //        /// </summary>
        //        WSAENETDOWN = 10050,

        //        /// <summary>
        //        /// <para>MessageId: WSAENETUNREACH</para>
        //        /// <para>MessageText: A socket operation was attempted to an unreachable network.</para>
        //        /// </summary>
        //        WSAENETUNREACH = 10051,

        //        /// <summary>
        //        /// <para>MessageId: WSAENETRESET</para>
        //        /// <para>MessageText: The connection has been broken due to keep-alive activity detecting a failure while the operation was in progress.</para>
        //        /// </summary>
        //        WSAENETRESET = 10052,

        //        /// <summary>
        //        /// <para>MessageId: WSAECONNABORTED</para>
        //        /// <para>MessageText: An established connection was aborted by the software in your host machine.</para>
        //        /// </summary>
        //        WSAECONNABORTED = 10053,

        //        /// <summary>
        //        /// <para>MessageId: WSAECONNRESET</para>
        //        /// <para>MessageText: An existing connection was forcibly closed by the remote host.</para>
        //        /// </summary>
        //        WSAECONNRESET = 10054,

        //        /// <summary>
        //        /// <para>MessageId: WSAENOBUFS</para>
        //        /// <para>MessageText: An operation on a socket could not be performed because the system lacked sufficient buffer space or because a queue was full.</para>
        //        /// </summary>
        //        WSAENOBUFS = 10055,

        //        /// <summary>
        //        /// <para>MessageId: WSAEISCONN</para>
        //        /// <para>MessageText: A connect request was made on an already connected socket.</para>
        //        /// </summary>
        //        WSAEISCONN = 10056,

        //        /// <summary>
        //        /// <para>MessageId: WSAENOTCONN</para>
        //        /// <para>MessageText: A request to send or receive data was disallowed because the socket is not connected and (when sending on a datagram socket using a sendto call) no address was supplied.</para>
        //        /// </summary>
        //        WSAENOTCONN = 10057,

        //        /// <summary>
        //        /// <para>MessageId: WSAESHUTDOWN</para>
        //        /// <para>MessageText: A request to send or receive data was disallowed because the socket had already been shut down in that direction with a previous shutdown call.</para>
        //        /// </summary>
        //        WSAESHUTDOWN = 10058,

        //        /// <summary>
        //        /// <para>MessageId: WSAETOOMANYREFS</para>
        //        /// <para>MessageText: Too many references to some kernel object.</para>
        //        /// </summary>
        //        WSAETOOMANYREFS = 10059,

        //        /// <summary>
        //        /// <para>MessageId: WSAETIMEDOUT</para>
        //        /// <para>MessageText: A connection attempt failed because the connected party did not properly respond after a period of time, or established connection failed because connected host has failed to respond.</para>
        //        /// </summary>
        //        WSAETIMEDOUT = 10060,

        //        /// <summary>
        //        /// <para>MessageId: WSAECONNREFUSED</para>
        //        /// <para>MessageText: No connection could be made because the target machine actively refused it.</para>
        //        /// </summary>
        //        WSAECONNREFUSED = 10061,

        //        /// <summary>
        //        /// <para>MessageId: WSAELOOP</para>
        //        /// <para>MessageText: Cannot translate name.</para>
        //        /// </summary>
        //        WSAELOOP = 10062,

        //        /// <summary>
        //        /// <para>MessageId: WSAENAMETOOLONG</para>
        //        /// <para>MessageText: Name component or name was too long.</para>
        //        /// </summary>
        //        WSAENAMETOOLONG = 10063,

        //        /// <summary>
        //        /// <para>MessageId: WSAEHOSTDOWN</para>
        //        /// <para>MessageText: A socket operation failed because the destination host was down.</para>
        //        /// </summary>
        //        WSAEHOSTDOWN = 10064,

        //        /// <summary>
        //        /// <para>MessageId: WSAEHOSTUNREACH</para>
        //        /// <para>MessageText: A socket operation was attempted to an unreachable host.</para>
        //        /// </summary>
        //        WSAEHOSTUNREACH = 10065,

        //        /// <summary>
        //        /// <para>MessageId: WSAENOTEMPTY</para>
        //        /// <para>MessageText: Cannot remove a directory that is not empty.</para>
        //        /// </summary>
        //        WSAENOTEMPTY = 10066,

        //        /// <summary>
        //        /// <para>MessageId: WSAEPROCLIM</para>
        //        /// <para>MessageText: A Windows Sockets implementation may have a limit on the number of applications that may use it simultaneously.</para>
        //        /// </summary>
        //        WSAEPROCLIM = 10067,

        //        /// <summary>
        //        /// <para>MessageId: WSAEUSERS</para>
        //        /// <para>MessageText: Ran out of quota.</para>
        //        /// </summary>
        //        WSAEUSERS = 10068,

        //        /// <summary>
        //        /// <para>MessageId: WSAEDQUOT</para>
        //        /// <para>MessageText: Ran out of disk quota.</para>
        //        /// </summary>
        //        WSAEDQUOT = 10069,

        //        /// <summary>
        //        /// <para>MessageId: WSAESTALE</para>
        //        /// <para>MessageText: File handle reference is no longer available.</para>
        //        /// </summary>
        //        WSAESTALE = 10070,

        //        /// <summary>
        //        /// <para>MessageId: WSAEREMOTE</para>
        //        /// <para>MessageText: Item is not available locally.</para>
        //        /// </summary>
        //        WSAEREMOTE = 10071,

        //        /// <summary>
        //        /// <para>MessageId: WSASYSNOTREADY</para>
        //        /// <para>MessageText: WSAStartup cannot function at this time because the underlying system it uses to provide network services is currently unavailable.</para>
        //        /// </summary>
        //        WSASYSNOTREADY = 10091,

        //        /// <summary>
        //        /// <para>MessageId: WSAVERNOTSUPPORTED</para>
        //        /// <para>MessageText: The Windows Sockets version requested is not supported.</para>
        //        /// </summary>
        //        WSAVERNOTSUPPORTED = 10092,

        //        /// <summary>
        //        /// <para>MessageId: WSANOTINITIALISED</para>
        //        /// <para>MessageText: Either the application has not called WSAStartup, or WSAStartup failed.</para>
        //        /// </summary>
        //        WSANOTINITIALISED = 10093,

        //        /// <summary>
        //        /// <para>MessageId: WSAEDISCON</para>
        //        /// <para>MessageText: Returned by WSARecv or WSARecvFrom to indicate the remote party has initiated a graceful shutdown sequence.</para>
        //        /// </summary>
        //        WSAEDISCON = 10101,

        //        /// <summary>
        //        /// <para>MessageId: WSAENOMORE</para>
        //        /// <para>MessageText: No more results can be returned by WSALookupServiceNext.</para>
        //        /// </summary>
        //        WSAENOMORE = 10102,

        //        /// <summary>
        //        /// <para>MessageId: WSAECANCELLED</para>
        //        /// <para>MessageText: A call to WSALookupServiceEnd was made while this call was still processing. The call has been canceled.</para>
        //        /// </summary>
        //        WSAECANCELLED = 10103,

        //        /// <summary>
        //        /// <para>MessageId: WSAEINVALIDPROCTABLE</para>
        //        /// <para>MessageText: The procedure call table is invalid.</para>
        //        /// </summary>
        //        WSAEINVALIDPROCTABLE = 10104,

        //        /// <summary>
        //        /// <para>MessageId: WSAEINVALIDPROVIDER</para>
        //        /// <para>MessageText: The requested service provider is invalid.</para>
        //        /// </summary>
        //        WSAEINVALIDPROVIDER = 10105,

        //        /// <summary>
        //        /// <para>MessageId: WSAEPROVIDERFAILEDINIT</para>
        //        /// <para>MessageText: The requested service provider could not be loaded or initialized.</para>
        //        /// </summary>
        //        WSAEPROVIDERFAILEDINIT = 10106,

        //        /// <summary>
        //        /// <para>MessageId: WSASYSCALLFAILURE</para>
        //        /// <para>MessageText: A system call has failed.</para>
        //        /// </summary>
        //        WSASYSCALLFAILURE = 10107,

        //        /// <summary>
        //        /// <para>MessageId: WSASERVICE_NOT_FOUND</para>
        //        /// <para>MessageText: No such service is known. The service cannot be found in the specified name space.</para>
        //        /// </summary>
        //        WSASERVICE_NOT_FOUND = 10108,

        //        /// <summary>
        //        /// <para>MessageId: WSATYPE_NOT_FOUND</para>
        //        /// <para>MessageText: The specified class was not found.</para>
        //        /// </summary>
        //        WSATYPE_NOT_FOUND = 10109,

        //        /// <summary>
        //        /// <para>MessageId: WSA_E_NO_MORE</para>
        //        /// <para>MessageText: No more results can be returned by WSALookupServiceNext.</para>
        //        /// </summary>
        //        WSA_E_NO_MORE = 10110,

        //        /// <summary>
        //        /// <para>MessageId: WSA_E_CANCELLED</para>
        //        /// <para>MessageText: A call to WSALookupServiceEnd was made while this call was still processing. The call has been canceled.</para>
        //        /// </summary>
        //        WSA_E_CANCELLED = 10111,

        //        /// <summary>
        //        /// <para>MessageId: WSAEREFUSED</para>
        //        /// <para>MessageText: A database query failed because it was actively refused.</para>
        //        /// </summary>
        //        WSAEREFUSED = 10112,

        //        /// <summary>
        //        /// <para>MessageId: WSAHOST_NOT_FOUND</para>
        //        /// <para>MessageText: No such host is known.</para>
        //        /// </summary>
        //        WSAHOST_NOT_FOUND = 11001,

        //        /// <summary>
        //        /// <para>MessageId: WSATRY_AGAIN</para>
        //        /// <para>MessageText: This is usually a temporary error during hostname resolution and means that the local server did not receive a response from an authoritative server.</para>
        //        /// </summary>
        //        WSATRY_AGAIN = 11002,

        //        /// <summary>
        //        /// <para>MessageId: WSANO_RECOVERY</para>
        //        /// <para>MessageText: A non-recoverable error occurred during a database lookup.</para>
        //        /// </summary>
        //        WSANO_RECOVERY = 11003,

        //        /// <summary>
        //        /// <para>MessageId: WSANO_DATA</para>
        //        /// <para>MessageText: The requested name is valid, but no data of the requested type was found.</para>
        //        /// </summary>
        //        WSANO_DATA = 11004,

        //        /// <summary>
        //        /// <para>MessageId: WSA_QOS_RECEIVERS</para>
        //        /// <para>MessageText: At least one reserve has arrived.</para>
        //        /// </summary>
        //        WSA_QOS_RECEIVERS = 11005,

        //        /// <summary>
        //        /// <para>MessageId: WSA_QOS_SENDERS</para>
        //        /// <para>MessageText: At least one path has arrived.</para>
        //        /// </summary>
        //        WSA_QOS_SENDERS = 11006,

        //        /// <summary>
        //        /// <para>MessageId: WSA_QOS_NO_SENDERS</para>
        //        /// <para>MessageText: There are no senders.</para>
        //        /// </summary>
        //        WSA_QOS_NO_SENDERS = 11007,

        //        /// <summary>
        //        /// <para>MessageId: WSA_QOS_NO_RECEIVERS</para>
        //        /// <para>MessageText: There are no receivers.</para>
        //        /// </summary>
        //        WSA_QOS_NO_RECEIVERS = 11008,

        //        /// <summary>
        //        /// <para>MessageId: WSA_QOS_REQUEST_CONFIRMED</para>
        //        /// <para>MessageText: Reserve has been confirmed.</para>
        //        /// </summary>
        //        WSA_QOS_REQUEST_CONFIRMED = 11009,

        //        /// <summary>
        //        /// <para>MessageId: WSA_QOS_ADMISSION_FAILURE</para>
        //        /// <para>MessageText: Error due to lack of resources.</para>
        //        /// </summary>
        //        WSA_QOS_ADMISSION_FAILURE = 11010,

        //        /// <summary>
        //        /// <para>MessageId: WSA_QOS_POLICY_FAILURE</para>
        //        /// <para>MessageText: Rejected for administrative reasons - bad credentials.</para>
        //        /// </summary>
        //        WSA_QOS_POLICY_FAILURE = 11011,

        //        /// <summary>
        //        /// <para>MessageId: WSA_QOS_BAD_STYLE</para>
        //        /// <para>MessageText: Unknown or conflicting style.</para>
        //        /// </summary>
        //        WSA_QOS_BAD_STYLE = 11012,

        //        /// <summary>
        //        /// <para>MessageId: WSA_QOS_BAD_OBJECT</para>
        //        /// <para>MessageText: Problem with some part of the filterspec or providerspecific buffer in general.</para>
        //        /// </summary>
        //        WSA_QOS_BAD_OBJECT = 11013,

        //        /// <summary>
        //        /// <para>MessageId: WSA_QOS_TRAFFIC_CTRL_ERROR</para>
        //        /// <para>MessageText: Problem with some part of the flowspec.</para>
        //        /// </summary>
        //        WSA_QOS_TRAFFIC_CTRL_ERROR = 11014,

        //        /// <summary>
        //        /// <para>MessageId: WSA_QOS_GENERIC_ERROR</para>
        //        /// <para>MessageText: General QOS error.</para>
        //        /// </summary>
        //        WSA_QOS_GENERIC_ERROR = 11015,

        //        /// <summary>
        //        /// <para>MessageId: WSA_QOS_ESERVICETYPE</para>
        //        /// <para>MessageText: An invalid or unrecognized service type was found in the flowspec.</para>
        //        /// </summary>
        //        WSA_QOS_ESERVICETYPE = 11016,

        //        /// <summary>
        //        /// <para>MessageId: WSA_QOS_EFLOWSPEC</para>
        //        /// <para>MessageText: An invalid or inconsistent flowspec was found in the QOS structure.</para>
        //        /// </summary>
        //        WSA_QOS_EFLOWSPEC = 11017,

        //        /// <summary>
        //        /// <para>MessageId: WSA_QOS_EPROVSPECBUF</para>
        //        /// <para>MessageText: Invalid QOS provider-specific buffer.</para>
        //        /// </summary>
        //        WSA_QOS_EPROVSPECBUF = 11018,

        //        /// <summary>
        //        /// <para>MessageId: WSA_QOS_EFILTERSTYLE</para>
        //        /// <para>MessageText: An invalid QOS filter style was used.</para>
        //        /// </summary>
        //        WSA_QOS_EFILTERSTYLE = 11019,

        //        /// <summary>
        //        /// <para>MessageId: WSA_QOS_EFILTERTYPE</para>
        //        /// <para>MessageText: An invalid QOS filter type was used.</para>
        //        /// </summary>
        //        WSA_QOS_EFILTERTYPE = 11020,

        //        /// <summary>
        //        /// <para>MessageId: WSA_QOS_EFILTERCOUNT</para>
        //        /// <para>MessageText: An incorrect number of QOS FILTERSPECs were specified in the FLOWDESCRIPTOR.</para>
        //        /// </summary>
        //        WSA_QOS_EFILTERCOUNT = 11021,

        //        /// <summary>
        //        /// <para>MessageId: WSA_QOS_EOBJLENGTH</para>
        //        /// <para>MessageText: An object with an invalid ObjectLength field was specified in the QOS provider-specific buffer.</para>
        //        /// </summary>
        //        WSA_QOS_EOBJLENGTH = 11022,

        //        /// <summary>
        //        /// <para>MessageId: WSA_QOS_EFLOWCOUNT</para>
        //        /// <para>MessageText: An incorrect number of flow descriptors was specified in the QOS structure.</para>
        //        /// </summary>
        //        WSA_QOS_EFLOWCOUNT = 11023,

        //        /// <summary>
        //        /// <para>MessageId: WSA_QOS_EUNKOWNPSOBJ</para>
        //        /// <para>MessageText: An unrecognized object was found in the QOS provider-specific buffer.</para>
        //        /// </summary>
        //        WSA_QOS_EUNKOWNPSOBJ = 11024,

        //        /// <summary>
        //        /// <para>MessageId: WSA_QOS_EPOLICYOBJ</para>
        //        /// <para>MessageText: An invalid policy object was found in the QOS provider-specific buffer.</para>
        //        /// </summary>
        //        WSA_QOS_EPOLICYOBJ = 11025,

        //        /// <summary>
        //        /// <para>MessageId: WSA_QOS_EFLOWDESC</para>
        //        /// <para>MessageText: An invalid QOS flow descriptor was found in the flow descriptor list.</para>
        //        /// </summary>
        //        WSA_QOS_EFLOWDESC = 11026,

        //        /// <summary>
        //        /// <para>MessageId: WSA_QOS_EPSFLOWSPEC</para>
        //        /// <para>MessageText: An invalid or inconsistent flowspec was found in the QOS provider specific buffer.</para>
        //        /// </summary>
        //        WSA_QOS_EPSFLOWSPEC = 11027,

        //        /// <summary>
        //        /// <para>MessageId: WSA_QOS_EPSFILTERSPEC</para>
        //        /// <para>MessageText: An invalid FILTERSPEC was found in the QOS provider-specific buffer.</para>
        //        /// </summary>
        //        WSA_QOS_EPSFILTERSPEC = 11028,

        //        /// <summary>
        //        /// <para>MessageId: WSA_QOS_ESDMODEOBJ</para>
        //        /// <para>MessageText: An invalid shape discard mode object was found in the QOS provider specific buffer.</para>
        //        /// </summary>
        //        WSA_QOS_ESDMODEOBJ = 11029,

        //        /// <summary>
        //        /// <para>MessageId: WSA_QOS_ESHAPERATEOBJ</para>
        //        /// <para>MessageText: An invalid shaping rate object was found in the QOS provider-specific buffer.</para>
        //        /// </summary>
        //        WSA_QOS_ESHAPERATEOBJ = 11030,

        //        /// <summary>
        //        /// <para>MessageId: WSA_QOS_RESERVED_PETYPE</para>
        //        /// <para>MessageText: A reserved policy element was found in the QOS provider-specific buffer.</para>
        //        /// </summary>
        //        WSA_QOS_RESERVED_PETYPE = 11031,

        //        /// <summary>
        //        /// <para>MessageId: WSA_SECURE_HOST_NOT_FOUND</para>
        //        /// <para>MessageText: No such host is known securely.</para>
        //        /// </summary>
        //        WSA_SECURE_HOST_NOT_FOUND = 11032,

        //        /// <summary>
        //        /// <para>MessageId: WSA_IPSEC_NAME_POLICY_ERROR</para>
        //        /// <para>MessageText: Name based IPSEC policy could not be added.</para>
        //        /// </summary>
        //        WSA_IPSEC_NAME_POLICY_ERROR = 11033,

        //#endif // defined(WSABASEERR)






        //        /// <summary>
        //        /// <para>MessageId: ERROR_IPSEC_QM_POLICY_EXISTS</para>
        //        /// <para>MessageText: The specified quick mode policy already exists.</para>
        //        /// </summary>
        //        IpsecQmPolicyExists = 13000,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_IPSEC_QM_POLICY_NOT_FOUND</para>
        //        /// <para>MessageText: The specified quick mode policy was not found.</para>
        //        /// </summary>
        //        IpsecQmPolicyNotFound = 13001,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_IPSEC_QM_POLICY_IN_USE</para>
        //        /// <para>MessageText: The specified quick mode policy is being used.</para>
        //        /// </summary>
        //        IpsecQmPolicyInUse = 13002,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_IPSEC_MM_POLICY_EXISTS</para>
        //        /// <para>MessageText: The specified main mode policy already exists.</para>
        //        /// </summary>
        //        IpsecMmPolicyExists = 13003,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_IPSEC_MM_POLICY_NOT_FOUND</para>
        //        /// <para>MessageText: The specified main mode policy was not found</para>
        //        /// </summary>
        //        IpsecMmPolicyNotFound = 13004,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_IPSEC_MM_POLICY_IN_USE</para>
        //        /// <para>MessageText: The specified main mode policy is being used.</para>
        //        /// </summary>
        //        IpsecMmPolicyInUse = 13005,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_IPSEC_MM_FILTER_EXISTS</para>
        //        /// <para>MessageText: The specified main mode filter already exists.</para>
        //        /// </summary>
        //        IpsecMmFilterExists = 13006,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_IPSEC_MM_FILTER_NOT_FOUND</para>
        //        /// <para>MessageText: The specified main mode filter was not found.</para>
        //        /// </summary>
        //        IpsecMmFilterNotFound = 13007,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_IPSEC_TRANSPORT_FILTER_EXISTS</para>
        //        /// <para>MessageText: The specified transport mode filter already exists.</para>
        //        /// </summary>
        //        IpsecTransportFilterExists = 13008,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_IPSEC_TRANSPORT_FILTER_NOT_FOUND</para>
        //        /// <para>MessageText: The specified transport mode filter does not exist.</para>
        //        /// </summary>
        //        IpsecTransportFilterNotFound = 13009,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_IPSEC_MM_AUTH_EXISTS</para>
        //        /// <para>MessageText: The specified main mode authentication list exists.</para>
        //        /// </summary>
        //        IpsecMmAuthExists = 13010,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_IPSEC_MM_AUTH_NOT_FOUND</para>
        //        /// <para>MessageText: The specified main mode authentication list was not found.</para>
        //        /// </summary>
        //        IpsecMmAuthNotFound = 13011,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_IPSEC_MM_AUTH_IN_USE</para>
        //        /// <para>MessageText: The specified main mode authentication list is being used.</para>
        //        /// </summary>
        //        IpsecMmAuthInUse = 13012,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_IPSEC_DEFAULT_MM_POLICY_NOT_FOUND</para>
        //        /// <para>MessageText: The specified default main mode policy was not found.</para>
        //        /// </summary>
        //        IpsecDefaultMmPolicyNotFound = 13013,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_IPSEC_DEFAULT_MM_AUTH_NOT_FOUND</para>
        //        /// <para>MessageText: The specified default main mode authentication list was not found.</para>
        //        /// </summary>
        //        IpsecDefaultMmAuthNotFound = 13014,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_IPSEC_DEFAULT_QM_POLICY_NOT_FOUND</para>
        //        /// <para>MessageText: The specified default quick mode policy was not found.</para>
        //        /// </summary>
        //        IpsecDefaultQmPolicyNotFound = 13015,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_IPSEC_TUNNEL_FILTER_EXISTS</para>
        //        /// <para>MessageText: The specified tunnel mode filter exists.</para>
        //        /// </summary>
        //        IpsecTunnelFilterExists = 13016,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_IPSEC_TUNNEL_FILTER_NOT_FOUND</para>
        //        /// <para>MessageText: The specified tunnel mode filter was not found.</para>
        //        /// </summary>
        //        IpsecTunnelFilterNotFound = 13017,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_IPSEC_MM_FILTER_PENDING_DELETION</para>
        //        /// <para>MessageText: The Main Mode filter is pending deletion.</para>
        //        /// </summary>
        //        IpsecMmFilterPendingDeletion = 13018,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_IPSEC_TRANSPORT_FILTER_PENDING_DELETION</para>
        //        /// <para>MessageText: The transport filter is pending deletion.</para>
        //        /// </summary>
        //        IpsecTransportFilterPendingDeletion = 13019,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_IPSEC_TUNNEL_FILTER_PENDING_DELETION</para>
        //        /// <para>MessageText: The tunnel filter is pending deletion.</para>
        //        /// </summary>
        //        IpsecTunnelFilterPendingDeletion = 13020,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_IPSEC_MM_POLICY_PENDING_DELETION</para>
        //        /// <para>MessageText: The Main Mode policy is pending deletion.</para>
        //        /// </summary>
        //        IpsecMmPolicyPendingDeletion = 13021,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_IPSEC_MM_AUTH_PENDING_DELETION</para>
        //        /// <para>MessageText: The Main Mode authentication bundle is pending deletion.</para>
        //        /// </summary>
        //        IpsecMmAuthPendingDeletion = 13022,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_IPSEC_QM_POLICY_PENDING_DELETION</para>
        //        /// <para>MessageText: The Quick Mode policy is pending deletion.</para>
        //        /// </summary>
        //        IpsecQmPolicyPendingDeletion = 13023,

        //        /// <summary>
        //        /// <para>MessageId: WARNING_IPSEC_MM_POLICY_PRUNED</para>
        //        /// <para>MessageText: The Main Mode policy was successfully added, but some of the requested offers are not supported.</para>
        //        /// </summary>
        //        WARNING_IPSEC_MM_POLICY_PRUNED = 13024,

        //        /// <summary>
        //        /// <para>MessageId: WARNING_IPSEC_QM_POLICY_PRUNED</para>
        //        /// <para>MessageText: The Quick Mode policy was successfully added, but some of the requested offers are not supported.</para>
        //        /// </summary>
        //        WARNING_IPSEC_QM_POLICY_PRUNED = 13025,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_IPSEC_IKE_NEG_STATUS_BEGIN</para>
        //        /// <para>MessageText:  ERROR_IPSEC_IKE_NEG_STATUS_BEGIN</para>
        //        /// </summary>
        //        IpsecIkeNegStatusBegin = 13800,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_IPSEC_IKE_AUTH_FAIL</para>
        //        /// <para>MessageText: IKE authentication credentials are unacceptable</para>
        //        /// </summary>
        //        IpsecIkeAuthFail = 13801,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_IPSEC_IKE_ATTRIB_FAIL</para>
        //        /// <para>MessageText: IKE security attributes are unacceptable</para>
        //        /// </summary>
        //        IpsecIkeAttribFail = 13802,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_IPSEC_IKE_NEGOTIATION_PENDING</para>
        //        /// <para>MessageText: IKE Negotiation in progress</para>
        //        /// </summary>
        //        IpsecIkeNegotiationPending = 13803,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_IPSEC_IKE_GENERAL_PROCESSING_ERROR</para>
        //        /// <para>MessageText: General processing error</para>
        //        /// </summary>
        //        IpsecIkeGeneralProcessingError = 13804,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_IPSEC_IKE_TIMED_OUT</para>
        //        /// <para>MessageText: Negotiation timed out</para>
        //        /// </summary>
        //        IpsecIkeTimedOut = 13805,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_IPSEC_IKE_NO_CERT</para>
        //        /// <para>MessageText: IKE failed to find valid machine certificate. Contact your Network Security Administrator about installing a valid certificate in the appropriate Certificate Store.</para>
        //        /// </summary>
        //        IpsecIkeNoCert = 13806,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_IPSEC_IKE_SA_DELETED</para>
        //        /// <para>MessageText: IKE SA deleted by peer before establishment completed</para>
        //        /// </summary>
        //        IpsecIkeSaDeleted = 13807,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_IPSEC_IKE_SA_REAPED</para>
        //        /// <para>MessageText: IKE SA deleted before establishment completed</para>
        //        /// </summary>
        //        IpsecIkeSaReaped = 13808,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_IPSEC_IKE_MM_ACQUIRE_DROP</para>
        //        /// <para>MessageText: Negotiation request sat in Queue too long</para>
        //        /// </summary>
        //        IpsecIkeMmAcquireDrop = 13809,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_IPSEC_IKE_QM_ACQUIRE_DROP</para>
        //        /// <para>MessageText: Negotiation request sat in Queue too long</para>
        //        /// </summary>
        //        IpsecIkeQmAcquireDrop = 13810,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_IPSEC_IKE_QUEUE_DROP_MM</para>
        //        /// <para>MessageText: Negotiation request sat in Queue too long</para>
        //        /// </summary>
        //        IpsecIkeQueueDropMm = 13811,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_IPSEC_IKE_QUEUE_DROP_NO_MM</para>
        //        /// <para>MessageText: Negotiation request sat in Queue too long</para>
        //        /// </summary>
        //        IpsecIkeQueueDropNoMm = 13812,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_IPSEC_IKE_DROP_NO_RESPONSE</para>
        //        /// <para>MessageText: No response from peer</para>
        //        /// </summary>
        //        IpsecIkeDropNoResponse = 13813,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_IPSEC_IKE_MM_DELAY_DROP</para>
        //        /// <para>MessageText: Negotiation took too long</para>
        //        /// </summary>
        //        IpsecIkeMmDelayDrop = 13814,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_IPSEC_IKE_QM_DELAY_DROP</para>
        //        /// <para>MessageText: Negotiation took too long</para>
        //        /// </summary>
        //        IpsecIkeQmDelayDrop = 13815,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_IPSEC_IKE_ERROR</para>
        //        /// <para>MessageText: Unknown error occurred</para>
        //        /// </summary>
        //        IpsecIkeError = 13816,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_IPSEC_IKE_CRL_FAILED</para>
        //        /// <para>MessageText: Certificate Revocation Check failed</para>
        //        /// </summary>
        //        IpsecIkeCrlFailed = 13817,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_IPSEC_IKE_INVALID_KEY_USAGE</para>
        //        /// <para>MessageText: Invalid certificate key usage</para>
        //        /// </summary>
        //        IpsecIkeInvalidKeyUsage = 13818,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_IPSEC_IKE_INVALID_CERT_TYPE</para>
        //        /// <para>MessageText: Invalid certificate type</para>
        //        /// </summary>
        //        IpsecIkeInvalidCertType = 13819,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_IPSEC_IKE_NO_PRIVATE_KEY</para>
        //        /// <para>MessageText: IKE negotiation failed because the machine certificate used does not have a private key. IPsec certificates require a private key. Contact your Network Security administrator about replacing with a certificate that has a private key.</para>
        //        /// </summary>
        //        IpsecIkeNoPrivateKey = 13820,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_IPSEC_IKE_SIMULTANEOUS_REKEY</para>
        //        /// <para>MessageText: Simultaneous rekeys were detected.</para>
        //        /// </summary>
        //        IpsecIkeSimultaneousRekey = 13821,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_IPSEC_IKE_DH_FAIL</para>
        //        /// <para>MessageText: Failure in Diffie-Hellman computation</para>
        //        /// </summary>
        //        IpsecIkeDhFail = 13822,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_IPSEC_IKE_CRITICAL_PAYLOAD_NOT_RECOGNIZED</para>
        //        /// <para>MessageText: Don't know how to process critical payload</para>
        //        /// </summary>
        //        IpsecIkeCriticalPayloadNotRecognized = 13823,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_IPSEC_IKE_INVALID_HEADER</para>
        //        /// <para>MessageText: Invalid header</para>
        //        /// </summary>
        //        IpsecIkeInvalidHeader = 13824,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_IPSEC_IKE_NO_POLICY</para>
        //        /// <para>MessageText: No policy configured</para>
        //        /// </summary>
        //        IpsecIkeNoPolicy = 13825,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_IPSEC_IKE_INVALID_SIGNATURE</para>
        //        /// <para>MessageText: Failed to verify signature</para>
        //        /// </summary>
        //        IpsecIkeInvalidSignature = 13826,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_IPSEC_IKE_KERBEROS_ERROR</para>
        //        /// <para>MessageText: Failed to authenticate using Kerberos</para>
        //        /// </summary>
        //        IpsecIkeKerberosError = 13827,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_IPSEC_IKE_NO_PUBLIC_KEY</para>
        //        /// <para>MessageText: Peer's certificate did not have a public key</para>
        //        /// </summary>
        //        IpsecIkeNoPublicKey = 13828,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_IPSEC_IKE_PROCESS_ERR</para>
        //        /// <para>MessageText: Error processing error payload</para>
        //        /// </summary>
        //        IpsecIkeProcessErr = 13829,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_IPSEC_IKE_PROCESS_ERR_SA</para>
        //        /// <para>MessageText: Error processing SA payload</para>
        //        /// </summary>
        //        IpsecIkeProcessErrSa = 13830,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_IPSEC_IKE_PROCESS_ERR_PROP</para>
        //        /// <para>MessageText: Error processing Proposal payload</para>
        //        /// </summary>
        //        IpsecIkeProcessErrProp = 13831,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_IPSEC_IKE_PROCESS_ERR_TRANS</para>
        //        /// <para>MessageText: Error processing Transform payload</para>
        //        /// </summary>
        //        IpsecIkeProcessErrTrans = 13832,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_IPSEC_IKE_PROCESS_ERR_KE</para>
        //        /// <para>MessageText: Error processing KE payload</para>
        //        /// </summary>
        //        IpsecIkeProcessErrKe = 13833,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_IPSEC_IKE_PROCESS_ERR_ID</para>
        //        /// <para>MessageText: Error processing ID payload</para>
        //        /// </summary>
        //        IpsecIkeProcessErrId = 13834,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_IPSEC_IKE_PROCESS_ERR_CERT</para>
        //        /// <para>MessageText: Error processing Cert payload</para>
        //        /// </summary>
        //        IpsecIkeProcessErrCert = 13835,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_IPSEC_IKE_PROCESS_ERR_CERT_REQ</para>
        //        /// <para>MessageText: Error processing Certificate Request payload</para>
        //        /// </summary>
        //        IpsecIkeProcessErrCertReq = 13836,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_IPSEC_IKE_PROCESS_ERR_HASH</para>
        //        /// <para>MessageText: Error processing Hash payload</para>
        //        /// </summary>
        //        IpsecIkeProcessErrHash = 13837,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_IPSEC_IKE_PROCESS_ERR_SIG</para>
        //        /// <para>MessageText: Error processing Signature payload</para>
        //        /// </summary>
        //        IpsecIkeProcessErrSig = 13838,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_IPSEC_IKE_PROCESS_ERR_NONCE</para>
        //        /// <para>MessageText: Error processing Nonce payload</para>
        //        /// </summary>
        //        IpsecIkeProcessErrNonce = 13839,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_IPSEC_IKE_PROCESS_ERR_NOTIFY</para>
        //        /// <para>MessageText: Error processing Notify payload</para>
        //        /// </summary>
        //        IpsecIkeProcessErrNotify = 13840,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_IPSEC_IKE_PROCESS_ERR_DELETE</para>
        //        /// <para>MessageText: Error processing Delete Payload</para>
        //        /// </summary>
        //        IpsecIkeProcessErrDelete = 13841,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_IPSEC_IKE_PROCESS_ERR_VENDOR</para>
        //        /// <para>MessageText: Error processing VendorId payload</para>
        //        /// </summary>
        //        IpsecIkeProcessErrVendor = 13842,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_IPSEC_IKE_INVALID_PAYLOAD</para>
        //        /// <para>MessageText: Invalid payload received</para>
        //        /// </summary>
        //        IpsecIkeInvalidPayload = 13843,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_IPSEC_IKE_LOAD_SOFT_SA</para>
        //        /// <para>MessageText: Soft SA loaded</para>
        //        /// </summary>
        //        IpsecIkeLoadSoftSa = 13844,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_IPSEC_IKE_SOFT_SA_TORN_DOWN</para>
        //        /// <para>MessageText: Soft SA torn down</para>
        //        /// </summary>
        //        IpsecIkeSoftSaTornDown = 13845,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_IPSEC_IKE_INVALID_COOKIE</para>
        //        /// <para>MessageText: Invalid cookie received.</para>
        //        /// </summary>
        //        IpsecIkeInvalidCookie = 13846,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_IPSEC_IKE_NO_PEER_CERT</para>
        //        /// <para>MessageText: Peer failed to send valid machine certificate</para>
        //        /// </summary>
        //        IpsecIkeNoPeerCert = 13847,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_IPSEC_IKE_PEER_CRL_FAILED</para>
        //        /// <para>MessageText: Certification Revocation check of peer's certificate failed</para>
        //        /// </summary>
        //        IpsecIkePeerCrlFailed = 13848,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_IPSEC_IKE_POLICY_CHANGE</para>
        //        /// <para>MessageText: New policy invalidated SAs formed with old policy</para>
        //        /// </summary>
        //        IpsecIkePolicyChange = 13849,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_IPSEC_IKE_NO_MM_POLICY</para>
        //        /// <para>MessageText: There is no available Main Mode IKE policy.</para>
        //        /// </summary>
        //        IpsecIkeNoMmPolicy = 13850,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_IPSEC_IKE_NOTCBPRIV</para>
        //        /// <para>MessageText: Failed to enabled TCB privilege.</para>
        //        /// </summary>
        //        IpsecIkeNotcbpriv = 13851,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_IPSEC_IKE_SECLOADFAIL</para>
        //        /// <para>MessageText: Failed to load SECURITY.DLL.</para>
        //        /// </summary>
        //        IpsecIkeSecloadfail = 13852,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_IPSEC_IKE_FAILSSPINIT</para>
        //        /// <para>MessageText: Failed to obtain security function table dispatch address from SSPI.</para>
        //        /// </summary>
        //        IpsecIkeFailsspinit = 13853,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_IPSEC_IKE_FAILQUERYSSP</para>
        //        /// <para>MessageText: Failed to query Kerberos package to obtain max token size.</para>
        //        /// </summary>
        //        IpsecIkeFailqueryssp = 13854,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_IPSEC_IKE_SRVACQFAIL</para>
        //        /// <para>MessageText: Failed to obtain Kerberos server credentials for ISAKMP/ERROR_IPSEC_IKE service. Kerberos authentication will not function. The most likely reason for this is lack of domain membership. This is normal if your computer is a member of a workgroup.</para>
        //        /// </summary>
        //        IpsecIkeSrvacqfail = 13855,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_IPSEC_IKE_SRVQUERYCRED</para>
        //        /// <para>MessageText: Failed to determine SSPI principal name for ISAKMP/ERROR_IPSEC_IKE service (QueryCredentialsAttributes).</para>
        //        /// </summary>
        //        IpsecIkeSrvquerycred = 13856,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_IPSEC_IKE_GETSPIFAIL</para>
        //        /// <para>MessageText: Failed to obtain new SPI for the inbound SA from IPsec driver. The most common cause for this is that the driver does not have the correct filter. Check your policy to verify the filters.</para>
        //        /// </summary>
        //        IpsecIkeGetspifail = 13857,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_IPSEC_IKE_INVALID_FILTER</para>
        //        /// <para>MessageText: Given filter is invalid</para>
        //        /// </summary>
        //        IpsecIkeInvalidFilter = 13858,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_IPSEC_IKE_OUT_OF_MEMORY</para>
        //        /// <para>MessageText: Memory allocation failed.</para>
        //        /// </summary>
        //        IpsecIkeOutOfMemory = 13859,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_IPSEC_IKE_ADD_UPDATE_KEY_FAILED</para>
        //        /// <para>MessageText: Failed to add Security Association to IPsec Driver. The most common cause for this is if the IKE negotiation took too long to complete. If the problem persists, reduce the load on the faulting machine.</para>
        //        /// </summary>
        //        IpsecIkeAddUpdateKeyFailed = 13860,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_IPSEC_IKE_INVALID_POLICY</para>
        //        /// <para>MessageText: Invalid policy</para>
        //        /// </summary>
        //        IpsecIkeInvalidPolicy = 13861,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_IPSEC_IKE_UNKNOWN_DOI</para>
        //        /// <para>MessageText: Invalid DOI</para>
        //        /// </summary>
        //        IpsecIkeUnknownDoi = 13862,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_IPSEC_IKE_INVALID_SITUATION</para>
        //        /// <para>MessageText: Invalid situation</para>
        //        /// </summary>
        //        IpsecIkeInvalidSituation = 13863,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_IPSEC_IKE_DH_FAILURE</para>
        //        /// <para>MessageText: Diffie-Hellman failure</para>
        //        /// </summary>
        //        IpsecIkeDhFailure = 13864,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_IPSEC_IKE_INVALID_GROUP</para>
        //        /// <para>MessageText: Invalid Diffie-Hellman group</para>
        //        /// </summary>
        //        IpsecIkeInvalidGroup = 13865,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_IPSEC_IKE_ENCRYPT</para>
        //        /// <para>MessageText: Error encrypting payload</para>
        //        /// </summary>
        //        IpsecIkeEncrypt = 13866,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_IPSEC_IKE_DECRYPT</para>
        //        /// <para>MessageText: Error decrypting payload</para>
        //        /// </summary>
        //        IpsecIkeDecrypt = 13867,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_IPSEC_IKE_POLICY_MATCH</para>
        //        /// <para>MessageText: Policy match error</para>
        //        /// </summary>
        //        IpsecIkePolicyMatch = 13868,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_IPSEC_IKE_UNSUPPORTED_ID</para>
        //        /// <para>MessageText: Unsupported ID</para>
        //        /// </summary>
        //        IpsecIkeUnsupportedId = 13869,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_IPSEC_IKE_INVALID_HASH</para>
        //        /// <para>MessageText: Hash verification failed</para>
        //        /// </summary>
        //        IpsecIkeInvalidHash = 13870,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_IPSEC_IKE_INVALID_HASH_ALG</para>
        //        /// <para>MessageText: Invalid hash algorithm</para>
        //        /// </summary>
        //        IpsecIkeInvalidHashAlg = 13871,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_IPSEC_IKE_INVALID_HASH_SIZE</para>
        //        /// <para>MessageText: Invalid hash size</para>
        //        /// </summary>
        //        IpsecIkeInvalidHashSize = 13872,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_IPSEC_IKE_INVALID_ENCRYPT_ALG</para>
        //        /// <para>MessageText: Invalid encryption algorithm</para>
        //        /// </summary>
        //        IpsecIkeInvalidEncryptAlg = 13873,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_IPSEC_IKE_INVALID_AUTH_ALG</para>
        //        /// <para>MessageText: Invalid authentication algorithm</para>
        //        /// </summary>
        //        IpsecIkeInvalidAuthAlg = 13874,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_IPSEC_IKE_INVALID_SIG</para>
        //        /// <para>MessageText: Invalid certificate signature</para>
        //        /// </summary>
        //        IpsecIkeInvalidSig = 13875,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_IPSEC_IKE_LOAD_FAILED</para>
        //        /// <para>MessageText: Load failed</para>
        //        /// </summary>
        //        IpsecIkeLoadFailed = 13876,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_IPSEC_IKE_RPC_DELETE</para>
        //        /// <para>MessageText: Deleted via RPC call</para>
        //        /// </summary>
        //        IpsecIkeRpcDelete = 13877,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_IPSEC_IKE_BENIGN_REINIT</para>
        //        /// <para>MessageText: Temporary state created to perform reinitialization. This is not a real failure.</para>
        //        /// </summary>
        //        IpsecIkeBenignReinit = 13878,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_IPSEC_IKE_INVALID_RESPONDER_LIFETIME_NOTIFY</para>
        //        /// <para>MessageText: The lifetime value received in the Responder Lifetime Notify is below the Windows= 2000 configured minimum value. Please fix the policy on the peer machine.</para>
        //        /// </summary>
        //        IpsecIkeInvalidResponderLifetimeNotify = 13879,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_IPSEC_IKE_INVALID_MAJOR_VERSION</para>
        //        /// <para>MessageText: The recipient cannot handle version of IKE specified in the header.</para>
        //        /// </summary>
        //        IpsecIkeInvalidMajorVersion = 13880,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_IPSEC_IKE_INVALID_CERT_KEYLEN</para>
        //        /// <para>MessageText: Key length in certificate is too small for configured security requirements.</para>
        //        /// </summary>
        //        IpsecIkeInvalidCertKeylen = 13881,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_IPSEC_IKE_MM_LIMIT</para>
        //        /// <para>MessageText: Max number of established MM SAs to peer exceeded.</para>
        //        /// </summary>
        //        IpsecIkeMmLimit = 13882,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_IPSEC_IKE_NEGOTIATION_DISABLED</para>
        //        /// <para>MessageText: IKE received a policy that disables negotiation.</para>
        //        /// </summary>
        //        IpsecIkeNegotiationDisabled = 13883,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_IPSEC_IKE_QM_LIMIT</para>
        //        /// <para>MessageText: Reached maximum quick mode limit for the main mode. New main mode will be started.</para>
        //        /// </summary>
        //        IpsecIkeQmLimit = 13884,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_IPSEC_IKE_MM_EXPIRED</para>
        //        /// <para>MessageText: Main mode SA lifetime expired or peer sent a main mode delete.</para>
        //        /// </summary>
        //        IpsecIkeMmExpired = 13885,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_IPSEC_IKE_PEER_MM_ASSUMED_INVALID</para>
        //        /// <para>MessageText: Main mode SA assumed to be invalid because peer stopped responding.</para>
        //        /// </summary>
        //        IpsecIkePeerMmAssumedInvalid = 13886,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_IPSEC_IKE_CERT_CHAIN_POLICY_MISMATCH</para>
        //        /// <para>MessageText: Certificate doesn't chain to a trusted root in IPsec policy.</para>
        //        /// </summary>
        //        IpsecIkeCertChainPolicyMismatch = 13887,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_IPSEC_IKE_UNEXPECTED_MESSAGE_ID</para>
        //        /// <para>MessageText: Received unexpected message ID.</para>
        //        /// </summary>
        //        IpsecIkeUnexpectedMessageId = 13888,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_IPSEC_IKE_INVALID_AUTH_PAYLOAD</para>
        //        /// <para>MessageText: Received invalid authentication offers.</para>
        //        /// </summary>
        //        IpsecIkeInvalidAuthPayload = 13889,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_IPSEC_IKE_DOS_COOKIE_SENT</para>
        //        /// <para>MessageText: Sent DoS cookie notify to initiator.</para>
        //        /// </summary>
        //        IpsecIkeDosCookieSent = 13890,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_IPSEC_IKE_SHUTTING_DOWN</para>
        //        /// <para>MessageText: IKE service is shutting down.</para>
        //        /// </summary>
        //        IpsecIkeShuttingDown = 13891,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_IPSEC_IKE_CGA_AUTH_FAILED</para>
        //        /// <para>MessageText: Could not verify binding between CGA address and certificate.</para>
        //        /// </summary>
        //        IpsecIkeCgaAuthFailed = 13892,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_IPSEC_IKE_PROCESS_ERR_NATOA</para>
        //        /// <para>MessageText: Error processing NatOA payload.</para>
        //        /// </summary>
        //        IpsecIkeProcessErrNatoa = 13893,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_IPSEC_IKE_INVALID_MM_FOR_QM</para>
        //        /// <para>MessageText: Parameters of the main mode are invalid for this quick mode.</para>
        //        /// </summary>
        //        IpsecIkeInvalidMmForQm = 13894,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_IPSEC_IKE_QM_EXPIRED</para>
        //        /// <para>MessageText: Quick mode SA was expired by IPsec driver.</para>
        //        /// </summary>
        //        IpsecIkeQmExpired = 13895,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_IPSEC_IKE_TOO_MANY_FILTERS</para>
        //        /// <para>MessageText: Too many dynamically added IKEEXT filters were detected.</para>
        //        /// </summary>
        //        IpsecIkeTooManyFilters = 13896,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_IPSEC_IKE_NEG_STATUS_END</para>
        //        /// <para>MessageText:  ERROR_IPSEC_IKE_NEG_STATUS_END</para>
        //        /// </summary>
        //        IpsecIkeNegStatusEnd = 13897,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_IPSEC_IKE_KILL_DUMMY_NAP_TUNNEL</para>
        //        /// <para>MessageText: NAP reauth succeeded and must delete the dummy NAP IKEv2 tunnel.</para>
        //        /// </summary>
        //        IpsecIkeKillDummyNapTunnel = 13898,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_IPSEC_IKE_INNER_IP_ASSIGNMENT_FAILURE</para>
        //        /// <para>MessageText: Error in assigning inner IP address to initiator in tunnel mode.</para>
        //        /// </summary>
        //        IpsecIkeInnerIpAssignmentFailure = 13899,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_IPSEC_IKE_REQUIRE_CP_PAYLOAD_MISSING</para>
        //        /// <para>MessageText: Require configuration payload missing.</para>
        //        /// </summary>
        //        IpsecIkeRequireCpPayloadMissing = 13900,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_IPSEC_KEY_MODULE_IMPERSONATION_NEGOTIATION_PENDING</para>
        //        /// <para>MessageText: A negotiation running as the security principle who issued the connection is in progress</para>
        //        /// </summary>
        //        IpsecKeyModuleImpersonationNegotiationPending = 13901,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_IPSEC_IKE_COEXISTENCE_SUPPRESS</para>
        //        /// <para>MessageText: SA was deleted due to IKEv1/AuthIP co-existence suppress check.</para>
        //        /// </summary>
        //        IpsecIkeCoexistenceSuppress = 13902,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_IPSEC_IKE_RATELIMIT_DROP</para>
        //        /// <para>MessageText: Incoming SA request was dropped due to peer IP address rate limiting.</para>
        //        /// </summary>
        //        IpsecIkeRatelimitDrop = 13903,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_IPSEC_IKE_PEER_DOESNT_SUPPORT_MOBIKE</para>
        //        /// <para>MessageText: Peer does not support MOBIKE.</para>
        //        /// </summary>
        //        IpsecIkePeerDoesntSupportMobike = 13904,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_IPSEC_IKE_AUTHORIZATION_FAILURE</para>
        //        /// <para>MessageText: SA establishment is not authorized.</para>
        //        /// </summary>
        //        IpsecIkeAuthorizationFailure = 13905,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_IPSEC_IKE_STRONG_CRED_AUTHORIZATION_FAILURE</para>
        //        /// <para>MessageText: SA establishment is not authorized because there is not a sufficiently strong PKINIT-based credential.</para>
        //        /// </summary>
        //        IpsecIkeStrongCredAuthorizationFailure = 13906,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_IPSEC_IKE_AUTHORIZATION_FAILURE_WITH_OPTIONAL_RETRY</para>
        //        /// <para>MessageText: SA establishment is not authorized.  You may need to enter updated or different credentials such as a smartcard.</para>
        //        /// </summary>
        //        IpsecIkeAuthorizationFailureWithOptionalRetry = 13907,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_IPSEC_IKE_STRONG_CRED_AUTHORIZATION_AND_CERTMAP_FAILURE</para>
        //        /// <para>MessageText: SA establishment is not authorized because there is not a sufficiently strong PKINIT-based credential. This might be related to certificate-to-account mapping failure for the SA.</para>
        //        /// </summary>
        //        IpsecIkeStrongCredAuthorizationAndCertmapFailure = 13908,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_IPSEC_IKE_NEG_STATUS_EXTENDED_END</para>
        //        /// <para>MessageText:  ERROR_IPSEC_IKE_NEG_STATUS_EXTENDED_END</para>
        //        /// </summary>
        //        IpsecIkeNegStatusExtendedEnd = 13909,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_IPSEC_BAD_SPI</para>
        //        /// <para>MessageText: The SPI in the packet does not match a valid IPsec SA.</para>
        //        /// </summary>
        //        IpsecBadSpi = 13910,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_IPSEC_SA_LIFETIME_EXPIRED</para>
        //        /// <para>MessageText: Packet was received on an IPsec SA whose lifetime has expired.</para>
        //        /// </summary>
        //        IpsecSaLifetimeExpired = 13911,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_IPSEC_WRONG_SA</para>
        //        /// <para>MessageText: Packet was received on an IPsec SA that does not match the packet characteristics.</para>
        //        /// </summary>
        //        IpsecWrongSa = 13912,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_IPSEC_REPLAY_CHECK_FAILED</para>
        //        /// <para>MessageText: Packet sequence number replay check failed.</para>
        //        /// </summary>
        //        IpsecReplayCheckFailed = 13913,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_IPSEC_INVALID_PACKET</para>
        //        /// <para>MessageText: IPsec header and/or trailer in the packet is invalid.</para>
        //        /// </summary>
        //        IpsecInvalidPacket = 13914,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_IPSEC_INTEGRITY_CHECK_FAILED</para>
        //        /// <para>MessageText: IPsec integrity check failed.</para>
        //        /// </summary>
        //        IpsecIntegrityCheckFailed = 13915,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_IPSEC_CLEAR_TEXT_DROP</para>
        //        /// <para>MessageText: IPsec dropped a clear text packet.</para>
        //        /// </summary>
        //        IpsecClearTextDrop = 13916,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_IPSEC_AUTH_FIREWALL_DROP</para>
        //        /// <para>MessageText: IPsec dropped an incoming ESP packet in authenticated firewall mode. This drop is benign.</para>
        //        /// </summary>
        //        IpsecAuthFirewallDrop = 13917,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_IPSEC_THROTTLE_DROP</para>
        //        /// <para>MessageText: IPsec dropped a packet due to DoS throttling.</para>
        //        /// </summary>
        //        IpsecThrottleDrop = 13918,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_IPSEC_DOSP_BLOCK</para>
        //        /// <para>MessageText: IPsec DoS Protection matched an explicit block rule.</para>
        //        /// </summary>
        //        IpsecDospBlock = 13925,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_IPSEC_DOSP_RECEIVED_MULTICAST</para>
        //        /// <para>MessageText: IPsec DoS Protection received an IPsec specific multicast packet which is not allowed.</para>
        //        /// </summary>
        //        IpsecDospReceivedMulticast = 13926,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_IPSEC_DOSP_INVALID_PACKET</para>
        //        /// <para>MessageText: IPsec DoS Protection received an incorrectly formatted packet.</para>
        //        /// </summary>
        //        IpsecDospInvalidPacket = 13927,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_IPSEC_DOSP_STATE_LOOKUP_FAILED</para>
        //        /// <para>MessageText: IPsec DoS Protection failed to look up state.</para>
        //        /// </summary>
        //        IpsecDospStateLookupFailed = 13928,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_IPSEC_DOSP_MAX_ENTRIES</para>
        //        /// <para>MessageText: IPsec DoS Protection failed to create state because the maximum number of entries allowed by policy has been reached.</para>
        //        /// </summary>
        //        IpsecDospMaxEntries = 13929,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_IPSEC_DOSP_KEYMOD_NOT_ALLOWED</para>
        //        /// <para>MessageText: IPsec DoS Protection received an IPsec negotiation packet for a keying module which is not allowed by policy.</para>
        //        /// </summary>
        //        IpsecDospKeymodNotAllowed = 13930,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_IPSEC_DOSP_NOT_INSTALLED</para>
        //        /// <para>MessageText: IPsec DoS Protection has not been enabled.</para>
        //        /// </summary>
        //        IpsecDospNotInstalled = 13931,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_IPSEC_DOSP_MAX_PER_IP_RATELIMIT_QUEUES</para>
        //        /// <para>MessageText: IPsec DoS Protection failed to create a per internal IP rate limit queue because the maximum number of queues allowed by policy has been reached.</para>
        //        /// </summary>
        //        IpsecDospMaxPerIpRatelimitQueues = 13932,





        //        /// <summary>
        //        /// <para>MessageId: ERROR_SXS_SECTION_NOT_FOUND</para>
        //        /// <para>MessageText: The requested section was not present in the activation context.</para>
        //        /// </summary>
        //        SxsSectionNotFound = 14000,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_SXS_CANT_GEN_ACTCTX</para>
        //        /// <para>MessageText: The application has failed to start because its side-by-side configuration is incorrect. Please see the application event log or use the command-line sxstrace.exe tool for more detail.</para>
        //        /// </summary>
        //        SxsCantGenActctx = 14001,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_SXS_INVALID_ACTCTXDATA_FORMAT</para>
        //        /// <para>MessageText: The application binding data format is invalid.</para>
        //        /// </summary>
        //        SxsInvalidActctxdataFormat = 14002,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_SXS_ASSEMBLY_NOT_FOUND</para>
        //        /// <para>MessageText: The referenced assembly is not installed on your system.</para>
        //        /// </summary>
        //        SxsAssemblyNotFound = 14003,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_SXS_MANIFEST_FORMAT_ERROR</para>
        //        /// <para>MessageText: The manifest file does not begin with the required tag and format information.</para>
        //        /// </summary>
        //        SxsManifestFormatError = 14004,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_SXS_MANIFEST_PARSE_ERROR</para>
        //        /// <para>MessageText: The manifest file contains one or more syntax errors.</para>
        //        /// </summary>
        //        SxsManifestParseError = 14005,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_SXS_ACTIVATION_CONTEXT_DISABLED</para>
        //        /// <para>MessageText: The application attempted to activate a disabled activation context.</para>
        //        /// </summary>
        //        SxsActivationContextDisabled = 14006,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_SXS_KEY_NOT_FOUND</para>
        //        /// <para>MessageText: The requested lookup key was not found in any active activation context.</para>
        //        /// </summary>
        //        SxsKeyNotFound = 14007,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_SXS_VERSION_CONFLICT</para>
        //        /// <para>MessageText: A component version required by the application conflicts with another component version already active.</para>
        //        /// </summary>
        //        SxsVersionConflict = 14008,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_SXS_WRONG_SECTION_TYPE</para>
        //        /// <para>MessageText: The type requested activation context section does not match the query API used.</para>
        //        /// </summary>
        //        SxsWrongSectionType = 14009,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_SXS_THREAD_QUERIES_DISABLED</para>
        //        /// <para>MessageText: Lack of system resources has required isolated activation to be disabled for the current thread of execution.</para>
        //        /// </summary>
        //        SxsThreadQueriesDisabled = 14010,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_SXS_PROCESS_DEFAULT_ALREADY_SET</para>
        //        /// <para>MessageText: An attempt to set the process default activation context failed because the process default activation context was already set.</para>
        //        /// </summary>
        //        SxsProcessDefaultAlreadySet = 14011,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_SXS_UNKNOWN_ENCODING_GROUP</para>
        //        /// <para>MessageText: The encoding group identifier specified is not recognized.</para>
        //        /// </summary>
        //        SxsUnknownEncodingGroup = 14012,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_SXS_UNKNOWN_ENCODING</para>
        //        /// <para>MessageText: The encoding requested is not recognized.</para>
        //        /// </summary>
        //        SxsUnknownEncoding = 14013,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_SXS_INVALID_XML_NAMESPACE_URI</para>
        //        /// <para>MessageText: The manifest contains a reference to an invalid URI.</para>
        //        /// </summary>
        //        SxsInvalidXmlNamespaceUri = 14014,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_SXS_ROOT_MANIFEST_DEPENDENCY_NOT_INSTALLED</para>
        //        /// <para>MessageText: The application manifest contains a reference to a dependent assembly which is not installed</para>
        //        /// </summary>
        //        SxsRootManifestDependencyNotInstalled = 14015,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_SXS_LEAF_MANIFEST_DEPENDENCY_NOT_INSTALLED</para>
        //        /// <para>MessageText: The manifest for an assembly used by the application has a reference to a dependent assembly which is not installed</para>
        //        /// </summary>
        //        SxsLeafManifestDependencyNotInstalled = 14016,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_SXS_INVALID_ASSEMBLY_IDENTITY_ATTRIBUTE</para>
        //        /// <para>MessageText: The manifest contains an attribute for the assembly identity which is not valid.</para>
        //        /// </summary>
        //        SxsInvalidAssemblyIdentityAttribute = 14017,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_SXS_MANIFEST_MISSING_REQUIRED_DEFAULT_NAMESPACE</para>
        //        /// <para>MessageText: The manifest is missing the required default namespace specification on the assembly element.</para>
        //        /// </summary>
        //        SxsManifestMissingRequiredDefaultNamespace = 14018,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_SXS_MANIFEST_INVALID_REQUIRED_DEFAULT_NAMESPACE</para>
        //        /// <para>MessageText: The manifest has a default namespace specified on the assembly element but its value is not "urn:schemas-microsoft-com:asm.v1".</para>
        //        /// </summary>
        //        SxsManifestInvalidRequiredDefaultNamespace = 14019,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_SXS_PRIVATE_MANIFEST_CROSS_PATH_WITH_REPARSE_POINT</para>
        //        /// <para>MessageText: The private manifest probed has crossed a path with an unsupported reparse point.</para>
        //        /// </summary>
        //        SxsPrivateManifestCrossPathWithReparsePoint = 14020,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_SXS_DUPLICATE_DLL_NAME</para>
        //        /// <para>MessageText: Two or more components referenced directly or indirectly by the application manifest have files by the same name.</para>
        //        /// </summary>
        //        SxsDuplicateDllName = 14021,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_SXS_DUPLICATE_WINDOWCLASS_NAME</para>
        //        /// <para>MessageText: Two or more components referenced directly or indirectly by the application manifest have window classes with the same name.</para>
        //        /// </summary>
        //        SxsDuplicateWindowclassName = 14022,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_SXS_DUPLICATE_CLSID</para>
        //        /// <para>MessageText: Two or more components referenced directly or indirectly by the application manifest have the same COM server CLSIDs.</para>
        //        /// </summary>
        //        SxsDuplicateClsid = 14023,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_SXS_DUPLICATE_IID</para>
        //        /// <para>MessageText: Two or more components referenced directly or indirectly by the application manifest have proxies for the same COM interface IIDs.</para>
        //        /// </summary>
        //        SxsDuplicateIid = 14024,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_SXS_DUPLICATE_TLBID</para>
        //        /// <para>MessageText: Two or more components referenced directly or indirectly by the application manifest have the same COM type library TLBIDs.</para>
        //        /// </summary>
        //        SxsDuplicateTlbid = 14025,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_SXS_DUPLICATE_PROGID</para>
        //        /// <para>MessageText: Two or more components referenced directly or indirectly by the application manifest have the same COM ProgIDs.</para>
        //        /// </summary>
        //        SxsDuplicateProgid = 14026,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_SXS_DUPLICATE_ASSEMBLY_NAME</para>
        //        /// <para>MessageText: Two or more components referenced directly or indirectly by the application manifest are different versions of the same component which is not permitted.</para>
        //        /// </summary>
        //        SxsDuplicateAssemblyName = 14027,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_SXS_FILE_HASH_MISMATCH</para>
        //        /// <para>MessageText: A component's file does not match the verification information present in the component manifest.</para>
        //        /// </summary>
        //        SxsFileHashMismatch = 14028,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_SXS_POLICY_PARSE_ERROR</para>
        //        /// <para>MessageText: The policy manifest contains one or more syntax errors.</para>
        //        /// </summary>
        //        SxsPolicyParseError = 14029,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_SXS_XML_E_MISSINGQUOTE</para>
        //        /// <para>MessageText: Manifest Parse Error : A string literal was expected, but no opening quote character was found.</para>
        //        /// </summary>
        //        SxsXmlEMissingquote = 14030,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_SXS_XML_E_COMMENTSYNTAX</para>
        //        /// <para>MessageText: Manifest Parse Error : Incorrect syntax was used in a comment.</para>
        //        /// </summary>
        //        SxsXmlECommentsyntax = 14031,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_SXS_XML_E_BADSTARTNAMECHAR</para>
        //        /// <para>MessageText: Manifest Parse Error : A name was started with an invalid character.</para>
        //        /// </summary>
        //        SxsXmlEBadstartnamechar = 14032,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_SXS_XML_E_BADNAMECHAR</para>
        //        /// <para>MessageText: Manifest Parse Error : A name contained an invalid character.</para>
        //        /// </summary>
        //        SxsXmlEBadnamechar = 14033,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_SXS_XML_E_BADCHARINSTRING</para>
        //        /// <para>MessageText: Manifest Parse Error : A string literal contained an invalid character.</para>
        //        /// </summary>
        //        SxsXmlEBadcharinstring = 14034,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_SXS_XML_E_XMLDECLSYNTAX</para>
        //        /// <para>MessageText: Manifest Parse Error : Invalid syntax for an xml declaration.</para>
        //        /// </summary>
        //        SxsXmlEXmldeclsyntax = 14035,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_SXS_XML_E_BADCHARDATA</para>
        //        /// <para>MessageText: Manifest Parse Error : An Invalid character was found in text content.</para>
        //        /// </summary>
        //        SxsXmlEBadchardata = 14036,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_SXS_XML_E_MISSINGWHITESPACE</para>
        //        /// <para>MessageText: Manifest Parse Error : Required white space was missing.</para>
        //        /// </summary>
        //        SxsXmlEMissingwhitespace = 14037,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_SXS_XML_E_EXPECTINGTAGEND</para>
        //        /// <para>MessageText: Manifest Parse Error : The character '>' was expected.</para>
        //        /// </summary>
        //        SxsXmlEExpectingtagend = 14038,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_SXS_XML_E_MISSINGSEMICOLON</para>
        //        /// <para>MessageText: Manifest Parse Error : A semi colon character was expected.</para>
        //        /// </summary>
        //        SxsXmlEMissingsemicolon = 14039,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_SXS_XML_E_UNBALANCEDPAREN</para>
        //        /// <para>MessageText: Manifest Parse Error : Unbalanced parentheses.</para>
        //        /// </summary>
        //        SxsXmlEUnbalancedparen = 14040,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_SXS_XML_E_INTERNALERROR</para>
        //        /// <para>MessageText: Manifest Parse Error : Internal error.</para>
        //        /// </summary>
        //        SxsXmlEInternalerror = 14041,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_SXS_XML_E_UNEXPECTED_WHITESPACE</para>
        //        /// <para>MessageText: Manifest Parse Error : Whitespace is not allowed at this location.</para>
        //        /// </summary>
        //        SxsXmlEUnexpectedWhitespace = 14042,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_SXS_XML_E_INCOMPLETE_ENCODING</para>
        //        /// <para>MessageText: Manifest Parse Error : End of file reached in invalid state for current encoding.</para>
        //        /// </summary>
        //        SxsXmlEIncompleteEncoding = 14043,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_SXS_XML_E_MISSING_PAREN</para>
        //        /// <para>MessageText: Manifest Parse Error : Missing parenthesis.</para>
        //        /// </summary>
        //        SxsXmlEMissingParen = 14044,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_SXS_XML_E_EXPECTINGCLOSEQUOTE</para>
        //        /// <para>MessageText: Manifest Parse Error : A single or double closing quote character (\' or \") is missing.</para>
        //        /// </summary>
        //        SxsXmlEExpectingclosequote = 14045,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_SXS_XML_E_MULTIPLE_COLONS</para>
        //        /// <para>MessageText: Manifest Parse Error : Multiple colons are not allowed in a name.</para>
        //        /// </summary>
        //        SxsXmlEMultipleColons = 14046,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_SXS_XML_E_INVALID_DECIMAL</para>
        //        /// <para>MessageText: Manifest Parse Error : Invalid character for decimal digit.</para>
        //        /// </summary>
        //        SxsXmlEInvalidDecimal = 14047,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_SXS_XML_E_INVALID_HEXIDECIMAL</para>
        //        /// <para>MessageText: Manifest Parse Error : Invalid character for hexadecimal digit.</para>
        //        /// </summary>
        //        SxsXmlEInvalidHexidecimal = 14048,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_SXS_XML_E_INVALID_UNICODE</para>
        //        /// <para>MessageText: Manifest Parse Error : Invalid unicode character value for this platform.</para>
        //        /// </summary>
        //        SxsXmlEInvalidUnicode = 14049,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_SXS_XML_E_WHITESPACEORQUESTIONMARK</para>
        //        /// <para>MessageText: Manifest Parse Error : Expecting whitespace or '?'.</para>
        //        /// </summary>
        //        SxsXmlEWhitespaceorquestionmark = 14050,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_SXS_XML_E_UNEXPECTEDENDTAG</para>
        //        /// <para>MessageText: Manifest Parse Error : End tag was not expected at this location.</para>
        //        /// </summary>
        //        SxsXmlEUnexpectedendtag = 14051,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_SXS_XML_E_UNCLOSEDTAG</para>
        //        /// <para>MessageText: Manifest Parse Error : The following tags were not closed: %1.</para>
        //        /// </summary>
        //        SxsXmlEUnclosedtag = 14052,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_SXS_XML_E_DUPLICATEATTRIBUTE</para>
        //        /// <para>MessageText: Manifest Parse Error : Duplicate attribute.</para>
        //        /// </summary>
        //        SxsXmlEDuplicateattribute = 14053,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_SXS_XML_E_MULTIPLEROOTS</para>
        //        /// <para>MessageText: Manifest Parse Error : Only one top level element is allowed in an XML document.</para>
        //        /// </summary>
        //        SxsXmlEMultipleroots = 14054,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_SXS_XML_E_INVALIDATROOTLEVEL</para>
        //        /// <para>MessageText: Manifest Parse Error : Invalid at the top level of the document.</para>
        //        /// </summary>
        //        SxsXmlEInvalidatrootlevel = 14055,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_SXS_XML_E_BADXMLDECL</para>
        //        /// <para>MessageText: Manifest Parse Error : Invalid xml declaration.</para>
        //        /// </summary>
        //        SxsXmlEBadxmldecl = 14056,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_SXS_XML_E_MISSINGROOT</para>
        //        /// <para>MessageText: Manifest Parse Error : XML document must have a top level element.</para>
        //        /// </summary>
        //        SxsXmlEMissingroot = 14057,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_SXS_XML_E_UNEXPECTEDEOF</para>
        //        /// <para>MessageText: Manifest Parse Error : Unexpected end of file.</para>
        //        /// </summary>
        //        SxsXmlEUnexpectedeof = 14058,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_SXS_XML_E_BADPEREFINSUBSET</para>
        //        /// <para>MessageText: Manifest Parse Error : Parameter entities cannot be used inside markup declarations in an internal subset.</para>
        //        /// </summary>
        //        SxsXmlEBadperefinsubset = 14059,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_SXS_XML_E_UNCLOSEDSTARTTAG</para>
        //        /// <para>MessageText: Manifest Parse Error : Element was not closed.</para>
        //        /// </summary>
        //        SxsXmlEUnclosedstarttag = 14060,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_SXS_XML_E_UNCLOSEDENDTAG</para>
        //        /// <para>MessageText: Manifest Parse Error : End element was missing the character '>'.</para>
        //        /// </summary>
        //        SxsXmlEUnclosedendtag = 14061,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_SXS_XML_E_UNCLOSEDSTRING</para>
        //        /// <para>MessageText: Manifest Parse Error : A string literal was not closed.</para>
        //        /// </summary>
        //        SxsXmlEUnclosedstring = 14062,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_SXS_XML_E_UNCLOSEDCOMMENT</para>
        //        /// <para>MessageText: Manifest Parse Error : A comment was not closed.</para>
        //        /// </summary>
        //        SxsXmlEUnclosedcomment = 14063,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_SXS_XML_E_UNCLOSEDDECL</para>
        //        /// <para>MessageText: Manifest Parse Error : A declaration was not closed.</para>
        //        /// </summary>
        //        SxsXmlEUncloseddecl = 14064,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_SXS_XML_E_UNCLOSEDCDATA</para>
        //        /// <para>MessageText: Manifest Parse Error : A CDATA section was not closed.</para>
        //        /// </summary>
        //        SxsXmlEUnclosedcdata = 14065,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_SXS_XML_E_RESERVEDNAMESPACE</para>
        //        /// <para>MessageText: Manifest Parse Error : The namespace prefix is not allowed to start with the reserved string "xml".</para>
        //        /// </summary>
        //        SxsXmlEReservednamespace = 14066,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_SXS_XML_E_INVALIDENCODING</para>
        //        /// <para>MessageText: Manifest Parse Error : System does not support the specified encoding.</para>
        //        /// </summary>
        //        SxsXmlEInvalidencoding = 14067,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_SXS_XML_E_INVALIDSWITCH</para>
        //        /// <para>MessageText: Manifest Parse Error : Switch from current encoding to specified encoding not supported.</para>
        //        /// </summary>
        //        SxsXmlEInvalidswitch = 14068,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_SXS_XML_E_BADXMLCASE</para>
        //        /// <para>MessageText: Manifest Parse Error : The name 'xml' is reserved and must be lower case.</para>
        //        /// </summary>
        //        SxsXmlEBadxmlcase = 14069,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_SXS_XML_E_INVALID_STANDALONE</para>
        //        /// <para>MessageText: Manifest Parse Error : The standalone attribute must have the value 'yes' or 'no'.</para>
        //        /// </summary>
        //        SxsXmlEInvalidStandalone = 14070,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_SXS_XML_E_UNEXPECTED_STANDALONE</para>
        //        /// <para>MessageText: Manifest Parse Error : The standalone attribute cannot be used in external entities.</para>
        //        /// </summary>
        //        SxsXmlEUnexpectedStandalone = 14071,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_SXS_XML_E_INVALID_VERSION</para>
        //        /// <para>MessageText: Manifest Parse Error : Invalid version number.</para>
        //        /// </summary>
        //        SxsXmlEInvalidVersion = 14072,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_SXS_XML_E_MISSINGEQUALS</para>
        //        /// <para>MessageText: Manifest Parse Error : Missing equals sign between attribute and attribute value.</para>
        //        /// </summary>
        //        SxsXmlEMissingequals = 14073,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_SXS_PROTECTION_RECOVERY_FAILED</para>
        //        /// <para>MessageText: Assembly Protection Error : Unable to recover the specified assembly.</para>
        //        /// </summary>
        //        SxsProtectionRecoveryFailed = 14074,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_SXS_PROTECTION_PUBLIC_KEY_TOO_SHORT</para>
        //        /// <para>MessageText: Assembly Protection Error : The public key for an assembly was too short to be allowed.</para>
        //        /// </summary>
        //        SxsProtectionPublicKeyTooShort = 14075,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_SXS_PROTECTION_CATALOG_NOT_VALID</para>
        //        /// <para>MessageText: Assembly Protection Error : The catalog for an assembly is not valid, or does not match the assembly's manifest.</para>
        //        /// </summary>
        //        SxsProtectionCatalogNotValid = 14076,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_SXS_UNTRANSLATABLE_HRESULT</para>
        //        /// <para>MessageText: An HRESULT could not be translated to a corresponding Win32 error code.</para>
        //        /// </summary>
        //        SxsUntranslatableHresult = 14077,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_SXS_PROTECTION_CATALOG_FILE_MISSING</para>
        //        /// <para>MessageText: Assembly Protection Error : The catalog for an assembly is missing.</para>
        //        /// </summary>
        //        SxsProtectionCatalogFileMissing = 14078,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_SXS_MISSING_ASSEMBLY_IDENTITY_ATTRIBUTE</para>
        //        /// <para>MessageText: The supplied assembly identity is missing one or more attributes which must be present in this context.</para>
        //        /// </summary>
        //        SxsMissingAssemblyIdentityAttribute = 14079,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_SXS_INVALID_ASSEMBLY_IDENTITY_ATTRIBUTE_NAME</para>
        //        /// <para>MessageText: The supplied assembly identity has one or more attribute names that contain characters not permitted in XML names.</para>
        //        /// </summary>
        //        SxsInvalidAssemblyIdentityAttributeName = 14080,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_SXS_ASSEMBLY_MISSING</para>
        //        /// <para>MessageText: The referenced assembly could not be found.</para>
        //        /// </summary>
        //        SxsAssemblyMissing = 14081,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_SXS_CORRUPT_ACTIVATION_STACK</para>
        //        /// <para>MessageText: The activation context activation stack for the running thread of execution is corrupt.</para>
        //        /// </summary>
        //        SxsCorruptActivationStack = 14082,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_SXS_CORRUPTION</para>
        //        /// <para>MessageText: The application isolation metadata for this process or thread has become corrupt.</para>
        //        /// </summary>
        //        SxsCorruption = 14083,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_SXS_EARLY_DEACTIVATION</para>
        //        /// <para>MessageText: The activation context being deactivated is not the most recently activated one.</para>
        //        /// </summary>
        //        SxsEarlyDeactivation = 14084,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_SXS_INVALID_DEACTIVATION</para>
        //        /// <para>MessageText: The activation context being deactivated is not active for the current thread of execution.</para>
        //        /// </summary>
        //        SxsInvalidDeactivation = 14085,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_SXS_MULTIPLE_DEACTIVATION</para>
        //        /// <para>MessageText: The activation context being deactivated has already been deactivated.</para>
        //        /// </summary>
        //        SxsMultipleDeactivation = 14086,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_SXS_PROCESS_TERMINATION_REQUESTED</para>
        //        /// <para>MessageText: A component used by the isolation facility has requested to terminate the process.</para>
        //        /// </summary>
        //        SxsProcessTerminationRequested = 14087,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_SXS_RELEASE_ACTIVATION_CONTEXT</para>
        //        /// <para>MessageText: A kernel mode component is releasing a reference on an activation context.</para>
        //        /// </summary>
        //        SxsReleaseActivationContext = 14088,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_SXS_SYSTEM_DEFAULT_ACTIVATION_CONTEXT_EMPTY</para>
        //        /// <para>MessageText: The activation context of system default assembly could not be generated.</para>
        //        /// </summary>
        //        SxsSystemDefaultActivationContextEmpty = 14089,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_SXS_INVALID_IDENTITY_ATTRIBUTE_VALUE</para>
        //        /// <para>MessageText: The value of an attribute in an identity is not within the legal range.</para>
        //        /// </summary>
        //        SxsInvalidIdentityAttributeValue = 14090,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_SXS_INVALID_IDENTITY_ATTRIBUTE_NAME</para>
        //        /// <para>MessageText: The name of an attribute in an identity is not within the legal range.</para>
        //        /// </summary>
        //        SxsInvalidIdentityAttributeName = 14091,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_SXS_IDENTITY_DUPLICATE_ATTRIBUTE</para>
        //        /// <para>MessageText: An identity contains two definitions for the same attribute.</para>
        //        /// </summary>
        //        SxsIdentityDuplicateAttribute = 14092,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_SXS_IDENTITY_PARSE_ERROR</para>
        //        /// <para>MessageText: The identity string is malformed. This may be due to a trailing comma, more than two unnamed attributes, missing attribute name or missing attribute value.</para>
        //        /// </summary>
        //        SxsIdentityParseError = 14093,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_MALFORMED_SUBSTITUTION_STRING</para>
        //        /// <para>MessageText: A string containing localized substitutable content was malformed. Either a dollar sign ($) was followed by something other than a left parenthesis or another dollar sign or an substitution's right parenthesis was not found.</para>
        //        /// </summary>
        //        MalformedSubstitutionString = 14094,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_SXS_INCORRECT_PUBLIC_KEY_TOKEN</para>
        //        /// <para>MessageText: The public key token does not correspond to the public key specified.</para>
        //        /// </summary>
        //        SxsIncorrectPublicKeyToken = 14095,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_UNMAPPED_SUBSTITUTION_STRING</para>
        //        /// <para>MessageText: A substitution string had no mapping.</para>
        //        /// </summary>
        //        UnmappedSubstitutionString = 14096,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_SXS_ASSEMBLY_NOT_LOCKED</para>
        //        /// <para>MessageText: The component must be locked before making the request.</para>
        //        /// </summary>
        //        SxsAssemblyNotLocked = 14097,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_SXS_COMPONENT_STORE_CORRUPT</para>
        //        /// <para>MessageText: The component store has been corrupted.</para>
        //        /// </summary>
        //        SxsComponentStoreCorrupt = 14098,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_ADVANCED_INSTALLER_FAILED</para>
        //        /// <para>MessageText: An advanced installer failed during setup or servicing.</para>
        //        /// </summary>
        //        AdvancedInstallerFailed = 14099,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_XML_ENCODING_MISMATCH</para>
        //        /// <para>MessageText: The character encoding in the XML declaration did not match the encoding used in the document.</para>
        //        /// </summary>
        //        XmlEncodingMismatch = 14100,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_SXS_MANIFEST_IDENTITY_SAME_BUT_CONTENTS_DIFFERENT</para>
        //        /// <para>MessageText: The identities of the manifests are identical but their contents are different.</para>
        //        /// </summary>
        //        SxsManifestIdentitySameButContentsDifferent = 14101,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_SXS_IDENTITIES_DIFFERENT</para>
        //        /// <para>MessageText: The component identities are different.</para>
        //        /// </summary>
        //        SxsIdentitiesDifferent = 14102,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_SXS_ASSEMBLY_IS_NOT_A_DEPLOYMENT</para>
        //        /// <para>MessageText: The assembly is not a deployment.</para>
        //        /// </summary>
        //        SxsAssemblyIsNotADeployment = 14103,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_SXS_FILE_NOT_PART_OF_ASSEMBLY</para>
        //        /// <para>MessageText: The file is not a part of the assembly.</para>
        //        /// </summary>
        //        SxsFileNotPartOfAssembly = 14104,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_SXS_MANIFEST_TOO_BIG</para>
        //        /// <para>MessageText: The size of the manifest exceeds the maximum allowed.</para>
        //        /// </summary>
        //        SxsManifestTooBig = 14105,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_SXS_SETTING_NOT_REGISTERED</para>
        //        /// <para>MessageText: The setting is not registered.</para>
        //        /// </summary>
        //        SxsSettingNotRegistered = 14106,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_SXS_TRANSACTION_CLOSURE_INCOMPLETE</para>
        //        /// <para>MessageText: One or more required members of the transaction are not present.</para>
        //        /// </summary>
        //        SxsTransactionClosureIncomplete = 14107,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_SMI_PRIMITIVE_INSTALLER_FAILED</para>
        //        /// <para>MessageText: The SMI primitive installer failed during setup or servicing.</para>
        //        /// </summary>
        //        SmiPrimitiveInstallerFailed = 14108,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_GENERIC_COMMAND_FAILED</para>
        //        /// <para>MessageText: A generic command executable returned a result that indicates failure.</para>
        //        /// </summary>
        //        GenericCommandFailed = 14109,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_SXS_FILE_HASH_MISSING</para>
        //        /// <para>MessageText: A component is missing file verification information in its manifest.</para>
        //        /// </summary>
        //        SxsFileHashMissing = 14110,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_SXS_DUPLICATE_ACTIVATABLE_CLASS</para>
        //        /// <para>MessageText: Two or more components referenced directly or indirectly by the application manifest have the same WinRT ActivatableClass IDs.</para>
        //        /// </summary>
        //        SxsDuplicateActivatableClass = 14111,





        //        /// <summary>
        //        /// <para>MessageId: ERROR_EVT_INVALID_CHANNEL_PATH</para>
        //        /// <para>MessageText: The specified channel path is invalid.</para>
        //        /// </summary>
        //        EvtInvalidChannelPath = 15000,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_EVT_INVALID_QUERY</para>
        //        /// <para>MessageText: The specified query is invalid.</para>
        //        /// </summary>
        //        EvtInvalidQuery = 15001,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_EVT_PUBLISHER_METADATA_NOT_FOUND</para>
        //        /// <para>MessageText: The publisher metadata cannot be found in the resource.</para>
        //        /// </summary>
        //        EvtPublisherMetadataNotFound = 15002,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_EVT_EVENT_TEMPLATE_NOT_FOUND</para>
        //        /// <para>MessageText: The template for an event definition cannot be found in the resource (error = %1).</para>
        //        /// </summary>
        //        EvtEventTemplateNotFound = 15003,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_EVT_INVALID_PUBLISHER_NAME</para>
        //        /// <para>MessageText: The specified publisher name is invalid.</para>
        //        /// </summary>
        //        EvtInvalidPublisherName = 15004,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_EVT_INVALID_EVENT_DATA</para>
        //        /// <para>MessageText: The event data raised by the publisher is not compatible with the event template definition in the publisher's manifest.</para>
        //        /// </summary>
        //        EvtInvalidEventData = 15005,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_EVT_CHANNEL_NOT_FOUND</para>
        //        /// <para>MessageText: The specified channel could not be found.</para>
        //        /// </summary>
        //        EvtChannelNotFound = 15007,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_EVT_MALFORMED_XML_TEXT</para>
        //        /// <para>MessageText: The specified XML text was not well-formed. See Extended Error for more details.</para>
        //        /// </summary>
        //        EvtMalformedXmlText = 15008,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_EVT_SUBSCRIPTION_TO_DIRECT_CHANNEL</para>
        //        /// <para>MessageText: The events for a direct channel go directly to a log file and cannot be subscribed to.</para>
        //        /// </summary>
        //        EvtSubscriptionToDirectChannel = 15009,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_EVT_CONFIGURATION_ERROR</para>
        //        /// <para>MessageText: Configuration error.</para>
        //        /// </summary>
        //        EvtConfigurationError = 15010,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_EVT_QUERY_RESULT_STALE</para>
        //        /// <para>MessageText: The query result is stale or invalid and must be recreated. This may be due to the log being cleared or rolling over after the query result was created.</para>
        //        /// </summary>
        //        EvtQueryResultStale = 15011,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_EVT_QUERY_RESULT_INVALID_POSITION</para>
        //        /// <para>MessageText: The query result is currently at an invalid position.</para>
        //        /// </summary>
        //        EvtQueryResultInvalidPosition = 15012,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_EVT_NON_VALIDATING_MSXML</para>
        //        /// <para>MessageText: Registered MSXML doesn't support validation.</para>
        //        /// </summary>
        //        EvtNonValidatingMsxml = 15013,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_EVT_FILTER_ALREADYSCOPED</para>
        //        /// <para>MessageText: An expression can only be followed by a change-of-scope operation if the expression evaluates to a node set and is not already part of another change-of-scope operation.</para>
        //        /// </summary>
        //        EvtFilterAlreadyscoped = 15014,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_EVT_FILTER_NOTELTSET</para>
        //        /// <para>MessageText: Cannot perform a step operation from a term that does not represent an element set.</para>
        //        /// </summary>
        //        EvtFilterNoteltset = 15015,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_EVT_FILTER_INVARG</para>
        //        /// <para>MessageText: Left-hand side arguments to binary operators must be either attributes, nodes or variables. Right-hand side arguments must be constants.</para>
        //        /// </summary>
        //        EvtFilterInvarg = 15016,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_EVT_FILTER_INVTEST</para>
        //        /// <para>MessageText: A step operation must involve a node test or, in the case of a predicate, an algebraic expression against which to test each node in the preceeding node set.</para>
        //        /// </summary>
        //        EvtFilterInvtest = 15017,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_EVT_FILTER_INVTYPE</para>
        //        /// <para>MessageText: This data type is currently unsupported.</para>
        //        /// </summary>
        //        EvtFilterInvtype = 15018,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_EVT_FILTER_PARSEERR</para>
        //        /// <para>MessageText: A syntax error occurred at position %1!d!</para>
        //        /// </summary>
        //        EvtFilterParseerr = 15019,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_EVT_FILTER_UNSUPPORTEDOP</para>
        //        /// <para>MessageText: This operator is unsupported by this implementation of the filter.</para>
        //        /// </summary>
        //        EvtFilterUnsupportedop = 15020,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_EVT_FILTER_UNEXPECTEDTOKEN</para>
        //        /// <para>MessageText: An unexpected token was encountered.</para>
        //        /// </summary>
        //        EvtFilterUnexpectedtoken = 15021,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_EVT_INVALID_OPERATION_OVER_ENABLED_DIRECT_CHANNEL</para>
        //        /// <para>MessageText: The requested operation cannot be performed over an enabled direct channel. The channel must first be disabled.</para>
        //        /// </summary>
        //        EvtInvalidOperationOverEnabledDirectChannel = 15022,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_EVT_INVALID_CHANNEL_PROPERTY_VALUE</para>
        //        /// <para>MessageText: Channel property %1!s! contains an invalid value. The value has an invalid type, is outside of its valid range, cannot be changed, or is not supported by this type of channel.</para>
        //        /// </summary>
        //        EvtInvalidChannelPropertyValue = 15023,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_EVT_INVALID_PUBLISHER_PROPERTY_VALUE</para>
        //        /// <para>MessageText: Publisher property %1!s! contains an invalid value. The value has an invalid type, is outside of its valid range, cannot be changed, or is not supported by this type of publisher.</para>
        //        /// </summary>
        //        EvtInvalidPublisherPropertyValue = 15024,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_EVT_CHANNEL_CANNOT_ACTIVATE</para>
        //        /// <para>MessageText: The channel failed to activate.</para>
        //        /// </summary>
        //        EvtChannelCannotActivate = 15025,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_EVT_FILTER_TOO_COMPLEX</para>
        //        /// <para>MessageText: The XPath expression exceeded the supported complexity. Simplify the expression or split it into multiple expressions.</para>
        //        /// </summary>
        //        EvtFilterTooComplex = 15026,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_EVT_MESSAGE_NOT_FOUND</para>
        //        /// <para>MessageText: The message resource is present but the message was not found in the message table.</para>
        //        /// </summary>
        //        EvtMessageNotFound = 15027,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_EVT_MESSAGE_ID_NOT_FOUND</para>
        //        /// <para>MessageText: The message ID for the desired message could not be found.</para>
        //        /// </summary>
        //        EvtMessageIdNotFound = 15028,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_EVT_UNRESOLVED_VALUE_INSERT</para>
        //        /// <para>MessageText: The substitution string for insert index (%1) could not be found.</para>
        //        /// </summary>
        //        EvtUnresolvedValueInsert = 15029,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_EVT_UNRESOLVED_PARAMETER_INSERT</para>
        //        /// <para>MessageText: The description string for parameter reference (%1) could not be found.</para>
        //        /// </summary>
        //        EvtUnresolvedParameterInsert = 15030,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_EVT_MAX_INSERTS_REACHED</para>
        //        /// <para>MessageText: The maximum number of replacements has been reached.</para>
        //        /// </summary>
        //        EvtMaxInsertsReached = 15031,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_EVT_EVENT_DEFINITION_NOT_FOUND</para>
        //        /// <para>MessageText: The event definition could not be found for event ID (%1).</para>
        //        /// </summary>
        //        EvtEventDefinitionNotFound = 15032,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_EVT_MESSAGE_LOCALE_NOT_FOUND</para>
        //        /// <para>MessageText: The locale specific resource for the desired message is not present.</para>
        //        /// </summary>
        //        EvtMessageLocaleNotFound = 15033,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_EVT_VERSION_TOO_OLD</para>
        //        /// <para>MessageText: The resource is too old and is not supported.</para>
        //        /// </summary>
        //        EvtVersionTooOld = 15034,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_EVT_VERSION_TOO_NEW</para>
        //        /// <para>MessageText: The resource is too new and is not supported.</para>
        //        /// </summary>
        //        EvtVersionTooNew = 15035,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_EVT_CANNOT_OPEN_CHANNEL_OF_QUERY</para>
        //        /// <para>MessageText: The channel at index %1!d! of the query can't be opened.</para>
        //        /// </summary>
        //        EvtCannotOpenChannelOfQuery = 15036,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_EVT_PUBLISHER_DISABLED</para>
        //        /// <para>MessageText: The publisher has been disabled and its resource is not available. This usually occurs when the publisher is in the process of being uninstalled or upgraded.</para>
        //        /// </summary>
        //        EvtPublisherDisabled = 15037,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_EVT_FILTER_OUT_OF_RANGE</para>
        //        /// <para>MessageText: Attempted to create a numeric type that is outside of its valid range.</para>
        //        /// </summary>
        //        EvtFilterOutOfRange = 15038,



        //        /// <summary>
        //        /// <para>MessageId: ERROR_EC_SUBSCRIPTION_CANNOT_ACTIVATE</para>
        //        /// <para>MessageText: The subscription fails to activate.</para>
        //        /// </summary>
        //        EcSubscriptionCannotActivate = 15080,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_EC_LOG_DISABLED</para>
        //        /// <para>MessageText: The log of the subscription is in disabled state, and can not be used to forward events to. The log must first be enabled before the subscription can be activated.</para>
        //        /// </summary>
        //        EcLogDisabled = 15081,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_EC_CIRCULAR_FORWARDING</para>
        //        /// <para>MessageText: When forwarding events from local machine to itself, the query of the subscription can't contain target log of the subscription.</para>
        //        /// </summary>
        //        EcCircularForwarding = 15082,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_EC_CREDSTORE_FULL</para>
        //        /// <para>MessageText: The credential store that is used to save credentials is full.</para>
        //        /// </summary>
        //        EcCredstoreFull = 15083,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_EC_CRED_NOT_FOUND</para>
        //        /// <para>MessageText: The credential used by this subscription can't be found in credential store.</para>
        //        /// </summary>
        //        EcCredNotFound = 15084,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_EC_NO_ACTIVE_CHANNEL</para>
        //        /// <para>MessageText: No active channel is found for the query.</para>
        //        /// </summary>
        //        EcNoActiveChannel = 15085,



        //        /// <summary>
        //        /// <para>MessageId: ERROR_MUI_FILE_NOT_FOUND</para>
        //        /// <para>MessageText: The resource loader failed to find MUI file.</para>
        //        /// </summary>
        //        MuiFileNotFound = 15100,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_MUI_INVALID_FILE</para>
        //        /// <para>MessageText: The resource loader failed to load MUI file because the file fail to pass validation.</para>
        //        /// </summary>
        //        MuiInvalidFile = 15101,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_MUI_INVALID_RC_CONFIG</para>
        //        /// <para>MessageText: The RC Manifest is corrupted with garbage data or unsupported version or missing required item.</para>
        //        /// </summary>
        //        MuiInvalidRcConfig = 15102,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_MUI_INVALID_LOCALE_NAME</para>
        //        /// <para>MessageText: The RC Manifest has invalid culture name.</para>
        //        /// </summary>
        //        MuiInvalidLocaleName = 15103,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_MUI_INVALID_ULTIMATEFALLBACK_NAME</para>
        //        /// <para>MessageText: The RC Manifest has invalid ultimatefallback name.</para>
        //        /// </summary>
        //        MuiInvalidUltimatefallbackName = 15104,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_MUI_FILE_NOT_LOADED</para>
        //        /// <para>MessageText: The resource loader cache doesn't have loaded MUI entry.</para>
        //        /// </summary>
        //        MuiFileNotLoaded = 15105,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_RESOURCE_ENUM_USER_STOP</para>
        //        /// <para>MessageText: User stopped resource enumeration.</para>
        //        /// </summary>
        //        ResourceEnumUserStop = 15106,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_MUI_INTLSETTINGS_UILANG_NOT_INSTALLED</para>
        //        /// <para>MessageText: UI language installation failed.</para>
        //        /// </summary>
        //        MuiIntlsettingsUilangNotInstalled = 15107,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_MUI_INTLSETTINGS_INVALID_LOCALE_NAME</para>
        //        /// <para>MessageText: Locale installation failed.</para>
        //        /// </summary>
        //        MuiIntlsettingsInvalidLocaleName = 15108,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_MRM_RUNTIME_NO_DEFAULT_OR_NEUTRAL_RESOURCE</para>
        //        /// <para>MessageText: A resource does not have default or neutral value.</para>
        //        /// </summary>
        //        MrmRuntimeNoDefaultOrNeutralResource = 15110,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_MRM_INVALID_PRICONFIG</para>
        //        /// <para>MessageText: Invalid PRI config file.</para>
        //        /// </summary>
        //        MrmInvalidPriconfig = 15111,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_MRM_INVALID_FILE_TYPE</para>
        //        /// <para>MessageText: Invalid file type.</para>
        //        /// </summary>
        //        MrmInvalidFileType = 15112,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_MRM_UNKNOWN_QUALIFIER</para>
        //        /// <para>MessageText: Unknown qualifier.</para>
        //        /// </summary>
        //        MrmUnknownQualifier = 15113,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_MRM_INVALID_QUALIFIER_VALUE</para>
        //        /// <para>MessageText: Invalid qualifier value.</para>
        //        /// </summary>
        //        MrmInvalidQualifierValue = 15114,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_MRM_NO_CANDIDATE</para>
        //        /// <para>MessageText: No Candidate found.</para>
        //        /// </summary>
        //        MrmNoCandidate = 15115,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_MRM_NO_MATCH_OR_DEFAULT_CANDIDATE</para>
        //        /// <para>MessageText: The ResourceMap or NamedResource has an item that does not have default or neutral resource..</para>
        //        /// </summary>
        //        MrmNoMatchOrDefaultCandidate = 15116,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_MRM_RESOURCE_TYPE_MISMATCH</para>
        //        /// <para>MessageText: Invalid ResourceCandidate type.</para>
        //        /// </summary>
        //        MrmResourceTypeMismatch = 15117,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_MRM_DUPLICATE_MAP_NAME</para>
        //        /// <para>MessageText: Duplicate Resource Map.</para>
        //        /// </summary>
        //        MrmDuplicateMapName = 15118,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_MRM_DUPLICATE_ENTRY</para>
        //        /// <para>MessageText: Duplicate Entry.</para>
        //        /// </summary>
        //        MrmDuplicateEntry = 15119,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_MRM_INVALID_RESOURCE_IDENTIFIER</para>
        //        /// <para>MessageText: Invalid Resource Identifier.</para>
        //        /// </summary>
        //        MrmInvalidResourceIdentifier = 15120,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_MRM_FILEPATH_TOO_LONG</para>
        //        /// <para>MessageText: Filepath too long.</para>
        //        /// </summary>
        //        MrmFilepathTooLong = 15121,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_MRM_UNSUPPORTED_DIRECTORY_TYPE</para>
        //        /// <para>MessageText: Unsupported directory type.</para>
        //        /// </summary>
        //        MrmUnsupportedDirectoryType = 15122,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_MRM_INVALID_PRI_FILE</para>
        //        /// <para>MessageText: Invalid PRI File.</para>
        //        /// </summary>
        //        MrmInvalidPriFile = 15126,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_MRM_NAMED_RESOURCE_NOT_FOUND</para>
        //        /// <para>MessageText: NamedResource Not Found.</para>
        //        /// </summary>
        //        MrmNamedResourceNotFound = 15127,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_MRM_MAP_NOT_FOUND</para>
        //        /// <para>MessageText: ResourceMap Not Found.</para>
        //        /// </summary>
        //        MrmMapNotFound = 15135,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_MRM_UNSUPPORTED_PROFILE_TYPE</para>
        //        /// <para>MessageText: Unsupported MRT profile type.</para>
        //        /// </summary>
        //        MrmUnsupportedProfileType = 15136,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_MRM_INVALID_QUALIFIER_OPERATOR</para>
        //        /// <para>MessageText: Invalid qualifier operator.</para>
        //        /// </summary>
        //        MrmInvalidQualifierOperator = 15137,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_MRM_INDETERMINATE_QUALIFIER_VALUE</para>
        //        /// <para>MessageText: Unable to determine qualifier value or qualifier value has not been set.</para>
        //        /// </summary>
        //        MrmIndeterminateQualifierValue = 15138,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_MRM_AUTOMERGE_ENABLED</para>
        //        /// <para>MessageText: Automerge is enabled in the PRI file.</para>
        //        /// </summary>
        //        MrmAutomergeEnabled = 15139,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_MRM_TOO_MANY_RESOURCES</para>
        //        /// <para>MessageText: Too many resources defined for package.</para>
        //        /// </summary>
        //        MrmTooManyResources = 15140,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_MRM_UNSUPPORTED_FILE_TYPE_FOR_MERGE</para>
        //        /// <para>MessageText: Resource File can not be used for merge operation.</para>
        //        /// </summary>
        //        MrmUnsupportedFileTypeForMerge = 15141,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_MRM_UNSUPPORTED_FILE_TYPE_FOR_LOAD_UNLOAD_PRI_FILE</para>
        //        /// <para>MessageText: Load/UnloadPriFiles cannot be used with resource packages.</para>
        //        /// </summary>
        //        MrmUnsupportedFileTypeForLoadUnloadPriFile = 15142,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_MRM_NO_CURRENT_VIEW_ON_THREAD</para>
        //        /// <para>MessageText: Resource Contexts may not be created on threads that do not have a CoreWindow.</para>
        //        /// </summary>
        //        MrmNoCurrentViewOnThread = 15143,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DIFFERENT_PROFILE_RESOURCE_MANAGER_EXIST</para>
        //        /// <para>MessageText: The singleton Resource Manager with different profile is already created.</para>
        //        /// </summary>
        //        DifferentProfileResourceManagerExist = 15144,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_OPERATION_NOT_ALLOWED_FROM_SYSTEM_COMPONENT</para>
        //        /// <para>MessageText: The system component cannot operate given API operation</para>
        //        /// </summary>
        //        OperationNotAllowedFromSystemComponent = 15145,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_MRM_DIRECT_REF_TO_NON_DEFAULT_RESOURCE</para>
        //        /// <para>MessageText: The resource is a direct reference to a non-default resource candidate.</para>
        //        /// </summary>
        //        MrmDirectRefToNonDefaultResource = 15146,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_MRM_GENERATION_COUNT_MISMATCH</para>
        //        /// <para>MessageText: Resource Map has been re-generated and the query string is not valid anymore.</para>
        //        /// </summary>
        //        MrmGenerationCountMismatch = 15147,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_PRI_MERGE_VERSION_MISMATCH</para>
        //        /// <para>MessageText: The PRI files to be merged have incompatible versions.</para>
        //        /// </summary>
        //        PriMergeVersionMismatch = 15148,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_PRI_MERGE_MISSING_SCHEMA</para>
        //        /// <para>MessageText: The primary PRI files to be merged does not contain a schema.</para>
        //        /// </summary>
        //        PriMergeMissingSchema = 15149,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_PRI_MERGE_LOAD_FILE_FAILED</para>
        //        /// <para>MessageText: Unable to load one of the PRI files to be merged.</para>
        //        /// </summary>
        //        PriMergeLoadFileFailed = 15150,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_PRI_MERGE_ADD_FILE_FAILED</para>
        //        /// <para>MessageText: Unable to add one of the PRI files to the merged file.</para>
        //        /// </summary>
        //        PriMergeAddFileFailed = 15151,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_PRI_MERGE_WRITE_FILE_FAILED</para>
        //        /// <para>MessageText: Unable to create the merged PRI file.</para>
        //        /// </summary>
        //        PriMergeWriteFileFailed = 15152,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_PRI_MERGE_MULTIPLE_PACKAGE_FAMILIES_NOT_ALLOWED</para>
        //        /// <para>MessageText: Packages for a PRI file merge must all be from the same package family.</para>
        //        /// </summary>
        //        PriMergeMultiplePackageFamiliesNotAllowed = 15153,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_PRI_MERGE_MULTIPLE_MAIN_PACKAGES_NOT_ALLOWED</para>
        //        /// <para>MessageText: Packages for a PRI file merge must not include multiple main packages.</para>
        //        /// </summary>
        //        PriMergeMultipleMainPackagesNotAllowed = 15154,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_PRI_MERGE_BUNDLE_PACKAGES_NOT_ALLOWED</para>
        //        /// <para>MessageText: Packages for a PRI file merge must not include bundle packages.</para>
        //        /// </summary>
        //        PriMergeBundlePackagesNotAllowed = 15155,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_PRI_MERGE_MAIN_PACKAGE_REQUIRED</para>
        //        /// <para>MessageText: Packages for a PRI file merge must include one main package.</para>
        //        /// </summary>
        //        PriMergeMainPackageRequired = 15156,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_PRI_MERGE_RESOURCE_PACKAGE_REQUIRED</para>
        //        /// <para>MessageText: Packages for a PRI file merge must include at least one resource package.</para>
        //        /// </summary>
        //        PriMergeResourcePackageRequired = 15157,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_PRI_MERGE_INVALID_FILE_NAME</para>
        //        /// <para>MessageText: Invalid name supplied for a canonical merged PRI file.</para>
        //        /// </summary>
        //        PriMergeInvalidFileName = 15158,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_MRM_PACKAGE_NOT_FOUND</para>
        //        /// <para>MessageText: Unable to find the specified package.</para>
        //        /// </summary>
        //        MrmPackageNotFound = 15159,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_MRM_MISSING_DEFAULT_LANGUAGE</para>
        //        /// <para>MessageText: No default value for language was specified.</para>
        //        /// </summary>
        //        MrmMissingDefaultLanguage = 15160,



        //        /// <summary>
        //        /// <para>MessageId: ERROR_MCA_INVALID_CAPABILITIES_STRING</para>
        //        /// <para>MessageText: The monitor returned a DDC/CI capabilities string that did not comply with the ACCESS.bus= 3.0, DDC/CI= 1.1 or MCCS= 2 Revision= 1 specification.</para>
        //        /// </summary>
        //        McaInvalidCapabilitiesString = 15200,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_MCA_INVALID_VCP_VERSION</para>
        //        /// <para>MessageText: The monitor's VCP Version (0xDF) VCP code returned an invalid version value.</para>
        //        /// </summary>
        //        McaInvalidVcpVersion = 15201,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_MCA_MONITOR_VIOLATES_MCCS_SPECIFICATION</para>
        //        /// <para>MessageText: The monitor does not comply with the MCCS specification it claims to support.</para>
        //        /// </summary>
        //        McaMonitorViolatesMccsSpecification = 15202,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_MCA_MCCS_VERSION_MISMATCH</para>
        //        /// <para>MessageText: The MCCS version in a monitor's mccs_ver capability does not match the MCCS version the monitor reports when the VCP Version (0xDF) VCP code is used.</para>
        //        /// </summary>
        //        McaMccsVersionMismatch = 15203,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_MCA_UNSUPPORTED_MCCS_VERSION</para>
        //        /// <para>MessageText: The Monitor Configuration API only works with monitors that support the MCCS= 1.0 specification, MCCS= 2.0 specification or the MCCS= 2.0 Revision= 1 specification.</para>
        //        /// </summary>
        //        McaUnsupportedMccsVersion = 15204,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_MCA_INTERNAL_ERROR</para>
        //        /// <para>MessageText: An internal Monitor Configuration API error occurred.</para>
        //        /// </summary>
        //        McaInternalError = 15205,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_MCA_INVALID_TECHNOLOGY_TYPE_RETURNED</para>
        //        /// <para>MessageText: The monitor returned an invalid monitor technology type. CRT, Plasma and LCD (TFT) are examples of monitor technology types. This error implies that the monitor violated the MCCS= 2.0 or MCCS= 2.0 Revision= 1 specification.</para>
        //        /// </summary>
        //        McaInvalidTechnologyTypeReturned = 15206,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_MCA_UNSUPPORTED_COLOR_TEMPERATURE</para>
        //        /// <para>MessageText: The caller of SetMonitorColorTemperature specified a color temperature that the current monitor did not support. This error implies that the monitor violated the MCCS= 2.0 or MCCS= 2.0 Revision= 1 specification.</para>
        //        /// </summary>
        //        McaUnsupportedColorTemperature = 15207,



        //        /// <summary>
        //        /// <para>MessageId: ERROR_AMBIGUOUS_SYSTEM_DEVICE</para>
        //        /// <para>MessageText: The requested system device cannot be identified due to multiple indistinguishable devices potentially matching the identification criteria.</para>
        //        /// </summary>
        //        AmbiguousSystemDevice = 15250,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_SYSTEM_DEVICE_NOT_FOUND</para>
        //        /// <para>MessageText: The requested system device cannot be found.</para>
        //        /// </summary>
        //        SystemDeviceNotFound = 15299,


        //        /// <summary>
        //        /// <para>MessageId: ERROR_HASH_NOT_SUPPORTED</para>
        //        /// <para>MessageText: Hash generation for the specified hash version and hash type is not enabled on the server.</para>
        //        /// </summary>
        //        HashNotSupported = 15300,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_HASH_NOT_PRESENT</para>
        //        /// <para>MessageText: The hash requested from the server is not available or no longer valid.</para>
        //        /// </summary>
        //        HashNotPresent = 15301,


        //        /// <summary>
        //        /// <para>MessageId: ERROR_SECONDARY_IC_PROVIDER_NOT_REGISTERED</para>
        //        /// <para>MessageText: The secondary interrupt controller instance that manages the specified interrupt is not registered.</para>
        //        /// </summary>
        //        SecondaryIcProviderNotRegistered = 15321,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_GPIO_CLIENT_INFORMATION_INVALID</para>
        //        /// <para>MessageText: The information supplied by the GPIO client driver is invalid.</para>
        //        /// </summary>
        //        GpioClientInformationInvalid = 15322,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_GPIO_VERSION_NOT_SUPPORTED</para>
        //        /// <para>MessageText: The version specified by the GPIO client driver is not supported.</para>
        //        /// </summary>
        //        GpioVersionNotSupported = 15323,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_GPIO_INVALID_REGISTRATION_PACKET</para>
        //        /// <para>MessageText: The registration packet supplied by the GPIO client driver is not valid.</para>
        //        /// </summary>
        //        GpioInvalidRegistrationPacket = 15324,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_GPIO_OPERATION_DENIED</para>
        //        /// <para>MessageText: The requested operation is not supported for the specified handle.</para>
        //        /// </summary>
        //        GpioOperationDenied = 15325,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_GPIO_INCOMPATIBLE_CONNECT_MODE</para>
        //        /// <para>MessageText: The requested connect mode conflicts with an existing mode on one or more of the specified pins.</para>
        //        /// </summary>
        //        GpioIncompatibleConnectMode = 15326,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_GPIO_INTERRUPT_ALREADY_UNMASKED</para>
        //        /// <para>MessageText: The interrupt requested to be unmasked is not masked.</para>
        //        /// </summary>
        //        GpioInterruptAlreadyUnmasked = 15327,


        //        /// <summary>
        //        /// <para>MessageId: ERROR_CANNOT_SWITCH_RUNLEVEL</para>
        //        /// <para>MessageText: The requested run level switch cannot be completed successfully.</para>
        //        /// </summary>
        //        CannotSwitchRunlevel = 15400,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_INVALID_RUNLEVEL_SETTING</para>
        //        /// <para>MessageText: The service has an invalid run level setting. The run level for a service</para>
        //        /// </summary>
        //        InvalidRunlevelSetting = 15401,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_RUNLEVEL_SWITCH_TIMEOUT</para>
        //        /// <para>MessageText: The requested run level switch cannot be completed successfully since</para>
        //        /// </summary>
        //        RunlevelSwitchTimeout = 15402,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_RUNLEVEL_SWITCH_AGENT_TIMEOUT</para>
        //        /// <para>MessageText: A run level switch agent did not respond within the specified timeout.</para>
        //        /// </summary>
        //        RunlevelSwitchAgentTimeout = 15403,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_RUNLEVEL_SWITCH_IN_PROGRESS</para>
        //        /// <para>MessageText: A run level switch is currently in progress.</para>
        //        /// </summary>
        //        RunlevelSwitchInProgress = 15404,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_SERVICES_FAILED_AUTOSTART</para>
        //        /// <para>MessageText: One or more services failed to start during the service startup phase of a run level switch.</para>
        //        /// </summary>
        //        ServicesFailedAutostart = 15405,


        //        /// <summary>
        //        /// <para>MessageId: ERROR_COM_TASK_STOP_PENDING</para>
        //        /// <para>MessageText: The task stop request cannot be completed immediately since</para>
        //        /// </summary>
        //        ComTaskStopPending = 15501,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_INSTALL_OPEN_PACKAGE_FAILED</para>
        //        /// <para>MessageText: Package could not be opened.</para>
        //        /// </summary>
        //        InstallOpenPackageFailed = 15600,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_INSTALL_PACKAGE_NOT_FOUND</para>
        //        /// <para>MessageText: Package was not found.</para>
        //        /// </summary>
        //        InstallPackageNotFound = 15601,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_INSTALL_INVALID_PACKAGE</para>
        //        /// <para>MessageText: Package data is invalid.</para>
        //        /// </summary>
        //        InstallInvalidPackage = 15602,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_INSTALL_RESOLVE_DEPENDENCY_FAILED</para>
        //        /// <para>MessageText: Package failed updates, dependency or conflict validation.</para>
        //        /// </summary>
        //        InstallResolveDependencyFailed = 15603,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_INSTALL_OUT_OF_DISK_SPACE</para>
        //        /// <para>MessageText: There is not enough disk space on your computer. Please free up some space and try again.</para>
        //        /// </summary>
        //        InstallOutOfDiskSpace = 15604,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_INSTALL_NETWORK_FAILURE</para>
        //        /// <para>MessageText: There was a problem downloading your product.</para>
        //        /// </summary>
        //        InstallNetworkFailure = 15605,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_INSTALL_REGISTRATION_FAILURE</para>
        //        /// <para>MessageText: Package could not be registered.</para>
        //        /// </summary>
        //        InstallRegistrationFailure = 15606,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_INSTALL_DEREGISTRATION_FAILURE</para>
        //        /// <para>MessageText: Package could not be unregistered.</para>
        //        /// </summary>
        //        InstallDeregistrationFailure = 15607,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_INSTALL_CANCEL</para>
        //        /// <para>MessageText: User cancelled the install request.</para>
        //        /// </summary>
        //        InstallCancel = 15608,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_INSTALL_FAILED</para>
        //        /// <para>MessageText: Install failed. Please contact your software vendor.</para>
        //        /// </summary>
        //        InstallFailed = 15609,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_REMOVE_FAILED</para>
        //        /// <para>MessageText: Removal failed. Please contact your software vendor.</para>
        //        /// </summary>
        //        RemoveFailed = 15610,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_PACKAGE_ALREADY_EXISTS</para>
        //        /// <para>MessageText: The provided package is already installed, and reinstallation of the package was blocked. Check the AppXDeployment-Server event log for details.</para>
        //        /// </summary>
        //        PackageAlreadyExists = 15611,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_NEEDS_REMEDIATION</para>
        //        /// <para>MessageText: The application cannot be started. Try reinstalling the application to fix the problem.</para>
        //        /// </summary>
        //        NeedsRemediation = 15612,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_INSTALL_PREREQUISITE_FAILED</para>
        //        /// <para>MessageText: A Prerequisite for an install could not be satisfied.</para>
        //        /// </summary>
        //        InstallPrerequisiteFailed = 15613,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_PACKAGE_REPOSITORY_CORRUPTED</para>
        //        /// <para>MessageText: The package repository is corrupted.</para>
        //        /// </summary>
        //        PackageRepositoryCorrupted = 15614,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_INSTALL_POLICY_FAILURE</para>
        //        /// <para>MessageText: To install this application you need either a Windows developer license or a sideloading-enabled system.</para>
        //        /// </summary>
        //        InstallPolicyFailure = 15615,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_PACKAGE_UPDATING</para>
        //        /// <para>MessageText: The application cannot be started because it is currently updating.</para>
        //        /// </summary>
        //        PackageUpdating = 15616,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DEPLOYMENT_BLOCKED_BY_POLICY</para>
        //        /// <para>MessageText: The package deployment operation is blocked by policy. Please contact your system administrator.</para>
        //        /// </summary>
        //        DeploymentBlockedByPolicy = 15617,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_PACKAGES_IN_USE</para>
        //        /// <para>MessageText: The package could not be installed because resources it modifies are currently in use.</para>
        //        /// </summary>
        //        PackagesInUse = 15618,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_RECOVERY_FILE_CORRUPT</para>
        //        /// <para>MessageText: The package could not be recovered because necessary data for recovery have been corrupted.</para>
        //        /// </summary>
        //        RecoveryFileCorrupt = 15619,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_INVALID_STAGED_SIGNATURE</para>
        //        /// <para>MessageText: The signature is invalid. To register in developer mode, AppxSignature.p7x and AppxBlockMap.xml must be valid or should not be present.</para>
        //        /// </summary>
        //        InvalidStagedSignature = 15620,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DELETING_EXISTING_APPLICATIONDATA_STORE_FAILED</para>
        //        /// <para>MessageText: An error occurred while deleting the package's previously existing application data.</para>
        //        /// </summary>
        //        DeletingExistingApplicationdataStoreFailed = 15621,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_INSTALL_PACKAGE_DOWNGRADE</para>
        //        /// <para>MessageText: The package could not be installed because a higher version of this package is already installed.</para>
        //        /// </summary>
        //        InstallPackageDowngrade = 15622,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_SYSTEM_NEEDS_REMEDIATION</para>
        //        /// <para>MessageText: An error in a system binary was detected. Try refreshing the PC to fix the problem.</para>
        //        /// </summary>
        //        SystemNeedsRemediation = 15623,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_APPX_INTEGRITY_FAILURE_CLR_NGEN</para>
        //        /// <para>MessageText: A corrupted CLR NGEN binary was detected on the system.</para>
        //        /// </summary>
        //        AppxIntegrityFailureClrNgen = 15624,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_RESILIENCY_FILE_CORRUPT</para>
        //        /// <para>MessageText: The operation could not be resumed because necessary data for recovery have been corrupted.</para>
        //        /// </summary>
        //        ResiliencyFileCorrupt = 15625,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_INSTALL_FIREWALL_SERVICE_NOT_RUNNING</para>
        //        /// <para>MessageText: The package could not be installed because the Windows Firewall service is not running. Enable the Windows Firewall service and try again.</para>
        //        /// </summary>
        //        InstallFirewallServiceNotRunning = 15626,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_PACKAGE_MOVE_FAILED</para>
        //        /// <para>MessageText: Package move failed.</para>
        //        /// </summary>
        //        PackageMoveFailed = 15627,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_INSTALL_VOLUME_NOT_EMPTY</para>
        //        /// <para>MessageText: The deployment operation failed because the volume is not empty.</para>
        //        /// </summary>
        //        InstallVolumeNotEmpty = 15628,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_INSTALL_VOLUME_OFFLINE</para>
        //        /// <para>MessageText: The deployment operation failed because the volume is offline.</para>
        //        /// </summary>
        //        InstallVolumeOffline = 15629,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_INSTALL_VOLUME_CORRUPT</para>
        //        /// <para>MessageText: The deployment operation failed because the specified volume is corrupt.</para>
        //        /// </summary>
        //        InstallVolumeCorrupt = 15630,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_NEEDS_REGISTRATION</para>
        //        /// <para>MessageText: The deployment operation failed because the specified application needs to be registered first.</para>
        //        /// </summary>
        //        NeedsRegistration = 15631,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_INSTALL_WRONG_PROCESSOR_ARCHITECTURE</para>
        //        /// <para>MessageText: The deployment operation failed because the package targets the wrong processor architecture.</para>
        //        /// </summary>
        //        InstallWrongProcessorArchitecture = 15632,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DEV_SIDELOAD_LIMIT_EXCEEDED</para>
        //        /// <para>MessageText: You have reached the maximum number of developer sideloaded packages allowed on this device. Please uninstall a sideloaded package and try again.</para>
        //        /// </summary>
        //        DevSideloadLimitExceeded = 15633,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_INSTALL_OPTIONAL_PACKAGE_REQUIRES_MAIN_PACKAGE</para>
        //        /// <para>MessageText: A main app package is required to install this optional package.  Install the main package first and try again.</para>
        //        /// </summary>
        //        InstallOptionalPackageRequiresMainPackage = 15634,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_PACKAGE_NOT_SUPPORTED_ON_FILESYSTEM</para>
        //        /// <para>MessageText: This app package type is not supported on this filesystem</para>
        //        /// </summary>
        //        PackageNotSupportedOnFilesystem = 15635,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_PACKAGE_MOVE_BLOCKED_BY_STREAMING</para>
        //        /// <para>MessageText: Package move operation is blocked until the application has finished streaming</para>
        //        /// </summary>
        //        PackageMoveBlockedByStreaming = 15636,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_INSTALL_OPTIONAL_PACKAGE_APPLICATIONID_NOT_UNIQUE</para>
        //        /// <para>MessageText: A main or another optional app package has the same application ID as this optional package.  Change the application ID for the optional package to avoid conflicts.</para>
        //        /// </summary>
        //        InstallOptionalPackageApplicationidNotUnique = 15637,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_PACKAGE_STAGING_ONHOLD</para>
        //        /// <para>MessageText: This staging session has been held to allow another staging operation to be prioritized.</para>
        //        /// </summary>
        //        PackageStagingOnhold = 15638,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_INSTALL_INVALID_RELATED_SET_UPDATE</para>
        //        /// <para>MessageText: A related set cannot be updated because the updated set is invalid. All packages in the related set must be updated at the same time.</para>
        //        /// </summary>
        //        InstallInvalidRelatedSetUpdate = 15639,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_INSTALL_OPTIONAL_PACKAGE_REQUIRES_MAIN_PACKAGE_FULLTRUST_CAPABILITY</para>
        //        /// <para>MessageText: An optional package with a FullTrust entry point requires the main package to have the runFullTrust capability.</para>
        //        /// </summary>
        //        InstallOptionalPackageRequiresMainPackageFulltrustCapability = 15640,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DEPLOYMENT_BLOCKED_BY_USER_LOG_OFF</para>
        //        /// <para>MessageText: An error occurred because a user was logged off.</para>
        //        /// </summary>
        //        DeploymentBlockedByUserLogOff = 15641,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_PROVISION_OPTIONAL_PACKAGE_REQUIRES_MAIN_PACKAGE_PROVISIONED</para>
        //        /// <para>MessageText: An optional package provision requires the dependency main package to also be provisioned.</para>
        //        /// </summary>
        //        ProvisionOptionalPackageRequiresMainPackageProvisioned = 15642,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_PACKAGES_REPUTATION_CHECK_FAILED</para>
        //        /// <para>MessageText: The packages failed the SmartScreen reputation check.</para>
        //        /// </summary>
        //        PackagesReputationCheckFailed = 15643,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_PACKAGES_REPUTATION_CHECK_TIMEDOUT</para>
        //        /// <para>MessageText: The SmartScreen reputation check operation timed out.</para>
        //        /// </summary>
        //        PackagesReputationCheckTimedout = 15644,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DEPLOYMENT_OPTION_NOT_SUPPORTED</para>
        //        /// <para>MessageText: The current deployment option is not supported.</para>
        //        /// </summary>
        //        DeploymentOptionNotSupported = 15645,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_APPINSTALLER_ACTIVATION_BLOCKED</para>
        //        /// <para>MessageText: Activation is blocked due to the .appinstaller update settings for this app.</para>
        //        /// </summary>
        //        AppinstallerActivationBlocked = 15646,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_REGISTRATION_FROM_REMOTE_DRIVE_NOT_SUPPORTED</para>
        //        /// <para>MessageText: Remote drives are not supported; use \\server\share to register a remote package.</para>
        //        /// </summary>
        //        RegistrationFromRemoteDriveNotSupported = 15647,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_APPX_RAW_DATA_WRITE_FAILED</para>
        //        /// <para>MessageText: Failed to process and write downloaded APPX package data to disk.</para>
        //        /// </summary>
        //        AppxRawDataWriteFailed = 15648,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DEPLOYMENT_BLOCKED_BY_VOLUME_POLICY_PACKAGE</para>
        //        /// <para>MessageText: The deployment operation was blocked due to a per-package-family policy restricting deployments on a non-system volume. Per policy, this app must be installed to the system drive, but that's not set as the default. In Storage Settings, make the system drive the default location to save new content, then retry the install.</para>
        //        /// </summary>
        //        DeploymentBlockedByVolumePolicyPackage = 15649,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DEPLOYMENT_BLOCKED_BY_VOLUME_POLICY_MACHINE</para>
        //        /// <para>MessageText: The deployment operation was blocked due to a machine-wide policy restricting deployments on a non-system volume. Per policy, this app must be installed to the system drive, but that's not set as the default. In Storage Settings, make the system drive the default location to save new content, then retry the install.</para>
        //        /// </summary>
        //        DeploymentBlockedByVolumePolicyMachine = 15650,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DEPLOYMENT_BLOCKED_BY_PROFILE_POLICY</para>
        //        /// <para>MessageText: The deployment operation was blocked because Special profile deployment is not allowed. Please try logging into an account that is not a Special profile. You can try logging out and logging back into the current account, or try logging into a different account.</para>
        //        /// </summary>
        //        DeploymentBlockedByProfilePolicy = 15651,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DEPLOYMENT_FAILED_CONFLICTING_MUTABLE_PACKAGE_DIRECTORY</para>
        //        /// <para>MessageText: The deployment operation failed due to a conflicting package's mutable package directory. To install this package remove the existing package with the conflicting mutable package directory.</para>
        //        /// </summary>
        //        DeploymentFailedConflictingMutablePackageDirectory = 15652,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_SINGLETON_RESOURCE_INSTALLED_IN_ACTIVE_USER</para>
        //        /// <para>MessageText: The package installation failed because a singleton resource was specified and another user with that package installed is logged in. Please make sure that all active users with the package installed are logged out and retry installation.</para>
        //        /// </summary>
        //        SingletonResourceInstalledInActiveUser = 15653,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_DIFFERENT_VERSION_OF_PACKAGED_SERVICE_INSTALLED</para>
        //        /// <para>MessageText: The package installation failed because a different version of the service is installed. Try installing a newer version of the package.</para>
        //        /// </summary>
        //        DifferentVersionOfPackagedServiceInstalled = 15654,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_SERVICE_EXISTS_AS_NON_PACKAGED_SERVICE</para>
        //        /// <para>MessageText: The package installation failed because a version of the service exists outside of APPX packaging. Please contact your software vendor.</para>
        //        /// </summary>
        //        ServiceExistsAsNonPackagedService = 15655,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_PACKAGED_SERVICE_REQUIRES_ADMIN_PRIVILEGES</para>
        //        /// <para>MessageText: The package installation failed because administrator privileges are required. Please contact an administrator to install this package.</para>
        //        /// </summary>
        //        PackagedServiceRequiresAdminPrivileges = 15656,

        //        /// <summary>
        //        /// <para>MessageId: APPMODEL_ERROR_NO_PACKAGE</para>
        //        /// <para>MessageText: The process has no package identity.</para>
        //        /// </summary>
        //        ElErrorNoPackage = 15700,

        //        /// <summary>
        //        /// <para>MessageId: APPMODEL_ERROR_PACKAGE_RUNTIME_CORRUPT</para>
        //        /// <para>MessageText: The package runtime information is corrupted.</para>
        //        /// </summary>
        //        ElErrorPackageRuntimeCorrupt = 15701,

        //        /// <summary>
        //        /// <para>MessageId: APPMODEL_ERROR_PACKAGE_IDENTITY_CORRUPT</para>
        //        /// <para>MessageText: The package identity is corrupted.</para>
        //        /// </summary>
        //        ElErrorPackageIdentityCorrupt = 15702,

        //        /// <summary>
        //        /// <para>MessageId: APPMODEL_ERROR_NO_APPLICATION</para>
        //        /// <para>MessageText: The process has no application identity.</para>
        //        /// </summary>
        //        ElErrorNoApplication = 15703,

        //        /// <summary>
        //        /// <para>MessageId: APPMODEL_ERROR_DYNAMIC_PROPERTY_READ_FAILED</para>
        //        /// <para>MessageText: One or more AppModel Runtime group policy values could not be read. Please contact your system administrator with the contents of your AppModel Runtime event log.</para>
        //        /// </summary>
        //        ElErrorDynamicPropertyReadFailed = 15704,

        //        /// <summary>
        //        /// <para>MessageId: APPMODEL_ERROR_DYNAMIC_PROPERTY_INVALID</para>
        //        /// <para>MessageText: One or more AppModel Runtime group policy values are invalid. Please contact your system administrator with the contents of your AppModel Runtime event log.</para>
        //        /// </summary>
        //        ElErrorDynamicPropertyInvalid = 15705,

        //        /// <summary>
        //        /// <para>MessageId: APPMODEL_ERROR_PACKAGE_NOT_AVAILABLE</para>
        //        /// <para>MessageText: The package is currently not available.</para>
        //        /// </summary>
        //        ElErrorPackageNotAvailable = 15706,

        //        /// <summary>
        //        /// <para>MessageId: APPMODEL_ERROR_NO_MUTABLE_DIRECTORY</para>
        //        /// <para>MessageText: The package does not have a mutable directory.</para>
        //        /// </summary>
        //        ElErrorNoMutableDirectory = 15707,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_STATE_LOAD_STORE_FAILED</para>
        //        /// <para>MessageText: Loading the state store failed.</para>
        //        /// </summary>
        //        StateLoadStoreFailed = 15800,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_STATE_GET_VERSION_FAILED</para>
        //        /// <para>MessageText: Retrieving the state version for the application failed.</para>
        //        /// </summary>
        //        StateGetVersionFailed = 15801,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_STATE_SET_VERSION_FAILED</para>
        //        /// <para>MessageText: Setting the state version for the application failed.</para>
        //        /// </summary>
        //        StateSetVersionFailed = 15802,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_STATE_STRUCTURED_RESET_FAILED</para>
        //        /// <para>MessageText: Resetting the structured state of the application failed.</para>
        //        /// </summary>
        //        StateStructuredResetFailed = 15803,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_STATE_OPEN_CONTAINER_FAILED</para>
        //        /// <para>MessageText: State Manager failed to open the container.</para>
        //        /// </summary>
        //        StateOpenContainerFailed = 15804,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_STATE_CREATE_CONTAINER_FAILED</para>
        //        /// <para>MessageText: State Manager failed to create the container.</para>
        //        /// </summary>
        //        StateCreateContainerFailed = 15805,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_STATE_DELETE_CONTAINER_FAILED</para>
        //        /// <para>MessageText: State Manager failed to delete the container.</para>
        //        /// </summary>
        //        StateDeleteContainerFailed = 15806,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_STATE_READ_SETTING_FAILED</para>
        //        /// <para>MessageText: State Manager failed to read the setting.</para>
        //        /// </summary>
        //        StateReadSettingFailed = 15807,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_STATE_WRITE_SETTING_FAILED</para>
        //        /// <para>MessageText: State Manager failed to write the setting.</para>
        //        /// </summary>
        //        StateWriteSettingFailed = 15808,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_STATE_DELETE_SETTING_FAILED</para>
        //        /// <para>MessageText: State Manager failed to delete the setting.</para>
        //        /// </summary>
        //        StateDeleteSettingFailed = 15809,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_STATE_QUERY_SETTING_FAILED</para>
        //        /// <para>MessageText: State Manager failed to query the setting.</para>
        //        /// </summary>
        //        StateQuerySettingFailed = 15810,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_STATE_READ_COMPOSITE_SETTING_FAILED</para>
        //        /// <para>MessageText: State Manager failed to read the composite setting.</para>
        //        /// </summary>
        //        StateReadCompositeSettingFailed = 15811,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_STATE_WRITE_COMPOSITE_SETTING_FAILED</para>
        //        /// <para>MessageText: State Manager failed to write the composite setting.</para>
        //        /// </summary>
        //        StateWriteCompositeSettingFailed = 15812,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_STATE_ENUMERATE_CONTAINER_FAILED</para>
        //        /// <para>MessageText: State Manager failed to enumerate the containers.</para>
        //        /// </summary>
        //        StateEnumerateContainerFailed = 15813,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_STATE_ENUMERATE_SETTINGS_FAILED</para>
        //        /// <para>MessageText: State Manager failed to enumerate the settings.</para>
        //        /// </summary>
        //        StateEnumerateSettingsFailed = 15814,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_STATE_COMPOSITE_SETTING_VALUE_SIZE_LIMIT_EXCEEDED</para>
        //        /// <para>MessageText: The size of the state manager composite setting value has exceeded the limit.</para>
        //        /// </summary>
        //        StateCompositeSettingValueSizeLimitExceeded = 15815,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_STATE_SETTING_VALUE_SIZE_LIMIT_EXCEEDED</para>
        //        /// <para>MessageText: The size of the state manager setting value has exceeded the limit.</para>
        //        /// </summary>
        //        StateSettingValueSizeLimitExceeded = 15816,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_STATE_SETTING_NAME_SIZE_LIMIT_EXCEEDED</para>
        //        /// <para>MessageText: The length of the state manager setting name has exceeded the limit.</para>
        //        /// </summary>
        //        StateSettingNameSizeLimitExceeded = 15817,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_STATE_CONTAINER_NAME_SIZE_LIMIT_EXCEEDED</para>
        //        /// <para>MessageText: The length of the state manager container name has exceeded the limit.</para>
        //        /// </summary>
        //        StateContainerNameSizeLimitExceeded = 15818,

        //        /// <summary>
        //        /// <para>MessageId: ERROR_API_UNAVAILABLE</para>
        //        /// <para>MessageText: This API cannot be used in the context of the caller's application type.</para>
        //        /// </summary>
        //        ApiUnavailable = 15841,

        //        /// <summary>
        //        /// <para>MessageId: STORE_ERROR_UNLICENSED</para>
        //        /// <para>MessageText: This PC does not have a valid license for the application or product.</para>
        //        /// </summary>
        //        ErrorUnlicensed = 15861,

        //        /// <summary>
        //        /// <para>MessageId: STORE_ERROR_UNLICENSED_USER</para>
        //        /// <para>MessageText: The authenticated user does not have a valid license for the application or product.</para>
        //        /// </summary>
        //        ErrorUnlicensedUser = 15862,

        //        /// <summary>
        //        /// <para>MessageId: STORE_ERROR_PENDING_COM_TRANSACTION</para>
        //        /// <para>MessageText: The commerce transaction associated with this license is still pending verification.</para>
        //        /// </summary>
        //        ErrorPendingComTransaction = 15863,

        //        /// <summary>
        //        /// <para>MessageId: STORE_ERROR_LICENSE_REVOKED</para>
        //        /// <para>MessageText: The license has been revoked for this user.</para>
        //        /// </summary>
        //        ErrorLicenseRevoked = 15864



        InternetErrorBase = 12000,

        InternetOutOfHandles = InternetErrorBase + 1,
        InternetTimeout = InternetErrorBase + 2,
        InternetExtendedError = InternetErrorBase + 3,
        InternetInternalError = InternetErrorBase + 4,
        InternetInvalidURL = InternetErrorBase + 5,
        InternetUnrecognizedScheme = InternetErrorBase + 6,
        InternetNameNotResolved = InternetErrorBase + 7,
        InternetProtocolNotFound = InternetErrorBase + 8,
        InternetInvalidOption = InternetErrorBase + 9,
        InternetBadOptionLength = InternetErrorBase + 10,
        /*InternetOPTION_NOT_SETTABLE = InternetErrorBase + 11,
        InternetSHUTDOWN = InternetErrorBase + 12,
        InternetINCORRECT_USER_NAME = InternetErrorBase + 13,
        InternetINCORRECT_PASSWORD = InternetErrorBase + 14,
        InternetLOGIN_FAILURE = InternetErrorBase + 15,
        InternetINVALID_OPERATION = InternetErrorBase + 16,
        InternetOPERATION_CANCELLED = InternetErrorBase + 17,
        InternetINCORRECT_HANDLE_TYPE = InternetErrorBase + 18,
        InternetINCORRECT_HANDLE_STATE = InternetErrorBase + 19,
        InternetNOT_PROXY_REQUEST = InternetErrorBase + 20,
        InternetREGISTRY_VALUE_NOT_FOUND = InternetErrorBase + 21,
        InternetBAD_REGISTRY_PARAMETER = InternetErrorBase + 22,*/
        InternetNoDirectAccess = InternetErrorBase + 23,
        /*InternetNO_CONTEXT = InternetErrorBase + 24,
        InternetNO_CALLBACK = InternetErrorBase + 25,
        InternetREQUEST_PENDING = InternetErrorBase + 26,
        InternetINCORRECT_FORMAT = InternetErrorBase + 27,
        InternetITEM_NOT_FOUND = InternetErrorBase + 28,
        InternetCANNOT_CONNECT = InternetErrorBase + 29,
        InternetCONNECTION_ABORTED = InternetErrorBase + 30,
        InternetCONNECTION_RESET = InternetErrorBase + 31,
        InternetFORCE_RETRY = InternetErrorBase + 32,
        InternetINVALID_PROXY_REQUEST = InternetErrorBase + 33,
        InternetNEED_UI = InternetErrorBase + 34,

        InternetHANDLE_EXISTS = InternetErrorBase + 36,
        InternetSEC_CERT_DATE_INVALID = InternetErrorBase + 37,
        InternetSEC_CERT_CN_INVALID = InternetErrorBase + 38,
        InternetHTTP_TO_HTTPS_ON_REDIR = InternetErrorBase + 39,
        InternetHTTPS_TO_HTTP_ON_REDIR = InternetErrorBase + 40,
        InternetMIXED_SECURITY = InternetErrorBase + 41,
        InternetCHG_POST_IS_NON_SECURE = InternetErrorBase + 42,
        InternetPOST_IS_NON_SECURE = InternetErrorBase + 43,
        InternetCLIENT_AUTH_CERT_NEEDED = InternetErrorBase + 44,
        InternetINVALID_CA = InternetErrorBase + 45,
        InternetCLIENT_AUTH_NOT_SETUP = InternetErrorBase + 46,
        InternetASYNC_THREAD_FAILED = InternetErrorBase + 47,
        InternetREDIRECT_SCHEME_CHANGE = InternetErrorBase + 48,
        InternetDIALOG_PENDING = InternetErrorBase + 49,
        InternetRETRY_DIALOG = InternetErrorBase + 50,
        InternetHTTPS_HTTP_SUBMIT_REDIR = InternetErrorBase + 52,
        InternetINSERT_CDROM = InternetErrorBase + 53,
        InternetFORTEZZA_LOGIN_NEEDED = InternetErrorBase + 54,
        InternetSEC_CERT_ERRORS = InternetErrorBase + 55,
        InternetSEC_CERT_NO_REV = InternetErrorBase + 56,
        InternetSEC_CERT_REV_FAILED = InternetErrorBase + 57,*/


        HTTP_HSTSRedirectRequired = InternetErrorBase + 60,


        InternetSecCertWeakSignature = InternetErrorBase + 62,


        //
        // FTP API errors
        //

        FTPTransferInProgress = InternetErrorBase + 110,
        FTPDropped = InternetErrorBase + 111,
        FTPNoPassiveMode = InternetErrorBase + 112,

        //
        // gopher API errors
        //

        GopherProtocolError = InternetErrorBase + 130,
        GopherNotFile = InternetErrorBase + 131,
        GopherDataError = InternetErrorBase + 132,
        GopherEndOfData = InternetErrorBase + 133,
        GopherInvalidLocator = InternetErrorBase + 134,
        GopherIncorrectLocatorType = InternetErrorBase + 135,
        GopherNotGopherPlus = InternetErrorBase + 136,
        GopherAttributeNotFound = InternetErrorBase + 137,
        GopherUnknownLocator = InternetErrorBase + 138,

        //
        // HTTP API errors
        //

        HTTPHeaderNotFound = InternetErrorBase + 150,
        HTTPDownLevelServer = InternetErrorBase + 151,
        HTTPInvalidServerResponse = InternetErrorBase + 152,
        HTTPInvalidHeader = InternetErrorBase + 153,
        HTTPInvalidQueryRequest = InternetErrorBase + 154,
        HTTPHeaderAlreadyExists = InternetErrorBase + 155,
        HTTPRedirectFailed = InternetErrorBase + 156,
        HTTPNotRedirected = InternetErrorBase + 160,
        HTTPCookieNeedsConfirmation = InternetErrorBase + 161,
        HTTPCookieDeclined = InternetErrorBase + 162,
        HTTPRedirectNeedsConfirmation = InternetErrorBase + 168,

        //
        // Additional Internet API error codes
        //

        /*InternetSECURITY_CHANNEL_ERROR = InternetErrorBase + 157,
        InternetUNABLE_TO_CACHE_FILE = InternetErrorBase + 158,
        InternetTCPIP_NOT_INSTALLED = InternetErrorBase + 159,
        InternetDISCONNECTED = InternetErrorBase + 163,
        InternetSERVER_UNREACHABLE = InternetErrorBase + 164,
        InternetPROXY_SERVER_UNREACHABLE = InternetErrorBase + 165,

        InternetBAD_AUTO_PROXY_SCRIPT = InternetErrorBase + 166,
        InternetUNABLE_TO_DOWNLOAD_SCRIPT = InternetErrorBase + 167,
        InternetSEC_INVALID_CERT = InternetErrorBase + 169,
        InternetSEC_CERT_REVOKED = InternetErrorBase + 170,

        // InternetAutodial specific errors

        InternetFAILED_DUETOSECURITYCHECK = InternetErrorBase + 171,
        InternetNOT_INITIALIZED = InternetErrorBase + 172,
        InternetNEED_MSN_SSPI_PKG = InternetErrorBase + 173,
        InternetLOGIN_FAILURE_DISPLAY_ENTITY_BODY = InternetErrorBase + 174,*/

        // Decoding/Decompression specific errors

        InternetDecodingFailed = InternetErrorBase + 175,

        InternetClientAuthCertNeededProxy = InternetErrorBase + 187,
        InternetSecureFailureProxy = InternetErrorBase + 188,
        InternetHTTPProtocolMismatch = InternetErrorBase + 190
    }
}
