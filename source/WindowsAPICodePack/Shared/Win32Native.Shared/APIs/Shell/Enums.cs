using System;

namespace Microsoft.WindowsAPICodePack.Win32Native.Shell
{
    public enum ShellImageListIconSize
    {
        /// <summary>
        /// The image size is normally 32x32 pixels. However, if the Use large icons option is selected from the Effects section of the Appearance tab in Display Properties, the image is 48x48 pixels.
        /// </summary>
        Large = 0,

        /// <summary>
        /// These images are the Shell standard small icon size of 16x16, but the size can be customized by the user.
        /// </summary>
        Small = 1,

        /// <summary>
        /// These images are the Shell standard extra-large icon size. This is typically 48x48, but the size can be customized by the user.
        /// </summary>
        ExtraLarge = 2,

        /// <summary>
        /// These images are the size specified by GetSystemMetrics called with SM_CXSMICON and GetSystemMetrics called with SM_CYSMICON.
        /// </summary>
        SysSmall = 3,

        /// <summary>
        /// Windows Vista and later. The image is normally 256x256 pixels.
        /// </summary>
        Jumbo = 4,

        /// <summary>
        /// The largest valid flag value, for validation purposes.
        /// </summary>
        Last = Jumbo
    }

    public enum NotifyIconVersion : uint
    {
        None = 0,
        Version3 = 3,
        Version4 = 4
    }

    [Flags]
    public enum NotifyIconFlags : uint
    {
        /// <summary>
        /// The <see cref="NotifyIconData.uCallbackMessage"/> member is valid.
        /// </summary>
        Message = 0x00000001,

        /// <summary>
        /// The <see cref="NotifyIconData.hIcon"/> member is valid.
        /// </summary>
        Icon = 0x00000002,

        /// <summary>
        /// The <see cref="NotifyIconData.szTip"/> member is valid.
        /// </summary>
        Tip = 0x00000004,

        /// <summary>
        /// The <see cref="NotifyIconData.dwState"/> and <see cref="NotifyIconData.dwStateMask"/> members are valid.
        /// </summary>
        State = 0x00000008,

        /// <summary>
        /// <para>Display a balloon notification. The <see cref="NotifyIconData.szInfo"/>, <see cref="NotifyIconData.szInfoTitle"/>, <see cref="NotifyIconData.dwInfoFlags"/>, and <see cref="NotifyIconData.uTimeout"/> members are valid. Note that <see cref="NotifyIconData.uTimeout"/> is valid only in Windows 2000 and Windows XP.</para>
        /// <para>To display the balloon notification, specify <see cref="Info"/> and provide text in <see cref="NotifyIconData.szInfo"/>.</para>
        /// <para>To remove a balloon notification, specify <see cref="Info"/> and provide an empty string through <see cref="NotifyIconData.szInfo"/>.</para>
        /// <para>To add a notification area icon without displaying a notification, do not set the <see cref="Info"/> flag.</para>
        /// </summary>
        Info = 0x00000010,

        /// <summary>
        /// <para>Windows 7 and later: The guidItem is valid.</para>
        /// <para>Windows Vista and earlier: Reserved.</para>
        /// </summary>
        Guid = 0x00000020,

        /// <summary>
        /// Windows Vista and later. If the balloon notification cannot be displayed immediately, discard it. Use this flag for notifications that represent real-time information which would be meaningless or misleading if displayed at a later time. For example, a message that states "Your telephone is ringing." <see cref="RealTime"/> is meaningful only when combined with the <see cref="Info"/> flag.
        /// </summary>
        RealTime = 0x00000040,

        /// <summary>
        /// Windows Vista and later. Use the standard tooltip. Normally, when <see cref="NotifyIconData.uVersion"/> is set to <see cref="NotifyIconVersion.Version4"/>, the standard tooltip is suppressed and can be replaced by the application-drawn, pop-up UI. If the application wants to show the standard tooltip with <see cref="NotifyIconVersion.Version4"/>, it can specify <see cref="ShowTip"/> to indicate the standard tooltip should still be shown.
        /// </summary>
        ShowTip = 0x00000080
    }

    [Flags]
    public enum NotifyIconStates : uint
    {
        /// <summary>
        /// The icon is hidden.
        /// </summary>
        Hidden = 0x00000001,

        /// <summary>
        /// The icon resource is shared between multiple icons.
        /// </summary>
        SharedIcon = 0x00000002
    }

    [Flags]
    public enum NotifyIconInfos : uint
    {
        None = 0x00000000,

        Info = 0x00000001,

        Warning = 0x00000002,

        Error = 0x00000003,

        User = 0x00000004,

        NoSound = 0x00000010,

        LargeIcon = 0x00000020,

        RespectQuietTime = 0x00000080,

        IconMask = 0x0000000F
    }

    public enum NotifyIconModification : uint
    {
        /// <summary>
        /// Adds an icon to the status area. The icon is given an identifier in the <see cref="NotifyIconData"/> structure pointed to by lpdata—either through its uID or guidItem member. This identifier is used in subsequent calls to <see cref="InteropTools.Shell_NotifyIconW(NotifyIconModification, PNOTIFYICONDATAW)"/> to perform later actions on the icon.
        /// </summary>
        Add = 0x00000000,

        /// <summary>
        /// Modifies an icon in the status area. <see cref="NotifyIconData"/> structure pointed to by lpdata uses the ID originally assigned to the icon when it was added to the notification area (<see cref="Add"/>) to identify the icon to be modified.
        /// </summary>
        Modify = 0x00000001,

        /// <summary>
        /// Deletes an icon from the status area. <see cref="NotifyIconData"/> structure pointed to by lpdata uses the ID originally assigned to the icon when it was added to the notification area (<see cref="Add"/>) to identify the icon to be deleted.
        /// </summary>
        Delete = 0x00000002,

        /// <summary>
        /// Shell32.dll version 5.0 and later only. Returns focus to the taskbar notification area. Notification area icons should use this message when they have completed their UI operation. For example, if the icon displays a shortcut menu, but the user presses ESC to cancel it, use <see cref="SetFocus"/> to return focus to the notification area.
        /// </summary>
        SetFocus = 0x00000003,

        /// <summary>
        /// <para>Shell32.dll version 5.0 and later only. Instructs the notification area to behave according to the version number specified in the <see cref="NotifyIconData.uVersion"/> member of the structure pointed to by lpdata. The version number specifies which members are recognized.</para>
        /// <para><see cref="SetVersion"/> must be called every time a notification area icon is added (<see cref="Add"/>)>. It does not need to be called with <see cref="Modify"/>. The version setting is not persisted once a user logs off.</para>
        /// </summary>
        SetVersion = 0x00000004
    }

    public enum NotifyIconNotification
    {
        Select = (WindowMessage.User + 0),
        Key = 0x1,
        KeySelect = (Select | Key),

        BalloonShow = (WindowMessage.User + 2),
        BalloonHide = (WindowMessage.User + 3),
        BalloonTimeOut = (WindowMessage.User + 4),
        BalloonUserClick = (WindowMessage.User + 5),
        PopupOpen = (WindowMessage.User + 6),
        PopupClose = (WindowMessage.User + 7)
    }

    [Flags]
    public enum EmptyRecycleBinFlags : uint
    {
        /// <summary>
        /// No dialog box confirming the deletion of the objects will be displayed.
        /// </summary>
        NoConfirmation = 0x00000001,

        /// <summary>
        /// No dialog box indicating the progress will be displayed.
        /// </summary>
        NoProgressUI = 0x00000002,

        /// <summary>
        /// No sound will be played when the operation is complete.
        /// </summary>
        NoSound = 0x00000004
    }

    [Flags]
    public enum FileOpenOptions
    {
        OverwritePrompt = 0x00000002,
        StrictFileTypes = 0x00000004,
        NoChangeDirectory = 0x00000008,
        PickFolders = 0x00000020,
        // Ensure that items returned are filesystem items.
        ForceFilesystem = 0x00000040,
        // Allow choosing items that have no storage.
        AllNonStorageItems = 0x00000080,
        NoValidate = 0x00000100,
        AllowMultiSelect = 0x00000200,
        PathMustExist = 0x00000800,
        FileMustExist = 0x00001000,
        CreatePrompt = 0x00002000,
        ShareAware = 0x00004000,
        NoReadOnlyReturn = 0x00008000,
        NoTestFileCreate = 0x00010000,
        HideMruPlaces = 0x00020000,
        HidePinnedPlaces = 0x00040000,
        NoDereferenceLinks = 0x00100000,
        DontAddToRecent = 0x02000000,
        ForceShowHidden = 0x10000000,
        DefaultNoMiniMode = 0x20000000
    }

    public enum ControlState
    {
        Inactive = 0x00000000,
        Enable = 0x00000001,
        Visible = 0x00000002
    }

    public enum ShellItemDesignNameOptions
    {
        Normal = 0x00000000,           // SIGDN_NORMAL
        ParentRelativeParsing = unchecked((int)0x80018001),   // SIGDN_INFOLDER | SIGDN_FORPARSING
        DesktopAbsoluteParsing = unchecked((int)0x80028000),  // SIGDN_FORPARSING
        ParentRelativeEditing = unchecked((int)0x80031001),   // SIGDN_INFOLDER | SIGDN_FOREDITING
        DesktopAbsoluteEditing = unchecked((int)0x8004c000),  // SIGDN_FORPARSING | SIGDN_FORADDRESSBAR
        FileSystemPath = unchecked((int)0x80058000),             // SIGDN_FORPARSING
        Url = unchecked((int)0x80068000),                     // SIGDN_FORPARSING
        ParentRelativeForAddressBar = unchecked((int)0x8007c001),     // SIGDN_INFOLDER | SIGDN_FORPARSING | SIGDN_FORADDRESSBAR
        ParentRelative = unchecked((int)0x80080001)           // SIGDN_INFOLDER
    }

    public enum FileDialogEventShareViolationResponse
    {
        Default = 0x00000000,
        Accept = 0x00000001,
        Refuse = 0x00000002
    }

    public enum FileDialogEventOverwriteResponse
    {
        Default = 0x00000000,
        Accept = 0x00000001,
        Refuse = 0x00000002
    }

    public enum FileDialogAddPlacement
    {
        Bottom = 0x00000000,
        Top = 0x00000001,
    }

    #region Shell Library Enums
    public enum LibraryFolderFilter
    {
        ForceFileSystem = 1,
        StorageItems = 2,
        AllItems = 3
    };

    [Flags]
    public enum LibraryOptions
    {
        Default = 0,
        PinnedToNavigationPane = 0x1,
        MaskAll = 0x1
    };

    public enum DefaultSaveFolderType
    {
        Detect = 1,
        Private = 2,
        Public = 3
    };

    public enum LibrarySaveOptions
    {
        FailIfThere = 0,
        OverrideExisting = 1,
        MakeUniqueName = 2
    };
    #endregion

    /// <summary>
    /// Indicate flags that modify the property store object retrieved by methods 
    /// that create a property store, such as IShellItem2::GetPropertyStore or 
    /// IPropertyStoreFactory::GetPropertyStore.
    /// </summary>
    [Flags]
    public enum GetPropertyStoreOptions
    {
        /// <summary>
        /// Meaning to a calling process: Return a read-only property store that contains all 
        /// properties. Slow items (offline files) are not opened. 
        /// Combination with other flags: Can be overridden by other flags.
        /// </summary>
        Default = 0,

        /// <summary>
        /// Meaning to a calling process: Include only properties directly from the property
        /// handler, which opens the file on the disk, network, or device. Meaning to a file 
        /// folder: Only include properties directly from the handler.
        /// 
        /// Meaning to other folders: When delegating to a file folder, pass this flag on 
        /// to the file folder; do not do any multiplexing (MUX). When not delegating to a 
        /// file folder, ignore this flag instead of returning a failure code.
        /// 
        /// Combination with other flags: Cannot be combined with GPS_TEMPORARY, 
        /// GPS_FASTPROPERTIESONLY, or GPS_BESTEFFORT.
        /// </summary>
        HandlePropertiesOnly = 0x1,

        /// <summary>
        /// Meaning to a calling process: Can write properties to the item. 
        /// Note: The store may contain fewer properties than a read-only store. 
        /// 
        /// Meaning to a file folder: ReadWrite.
        /// 
        /// Meaning to other folders: ReadWrite. Note: When using default MUX, 
        /// return a single unmultiplexed store because the default MUX does not support ReadWrite.
        /// 
        /// Combination with other flags: Cannot be combined with GPS_TEMPORARY, GPS_FASTPROPERTIESONLY, 
        /// GPS_BESTEFFORT, or GPS_DELAYCREATION. Implies GPS_HANDLERPROPERTIESONLY.
        /// </summary>
        ReadWrite = 0x2,

        /// <summary>
        /// Meaning to a calling process: Provides a writable store, with no initial properties, 
        /// that exists for the lifetime of the Shell item instance; basically, a property bag 
        /// attached to the item instance. 
        /// 
        /// Meaning to a file folder: Not applicable. Handled by the Shell item.
        /// 
        /// Meaning to other folders: Not applicable. Handled by the Shell item.
        /// 
        /// Combination with other flags: Cannot be combined with any other flag. Implies GPS_READWRITE
        /// </summary>
        Temporary = 0x4,

        /// <summary>
        /// Meaning to a calling process: Provides a store that does not involve reading from the 
        /// disk or network. Note: Some values may be different, or missing, compared to a store 
        /// without this flag. 
        /// 
        /// Meaning to a file folder: Include the "innate" and "fallback" stores only. Do not load the handler.
        /// 
        /// Meaning to other folders: Include only properties that are available in memory or can 
        /// be computed very quickly (no properties from disk, network, or peripheral IO devices). 
        /// This is normally only data sources from the IDLIST. When delegating to other folders, pass this flag on to them.
        /// 
        /// Combination with other flags: Cannot be combined with GPS_TEMPORARY, GPS_READWRITE, 
        /// GPS_HANDLERPROPERTIESONLY, or GPS_DELAYCREATION.
        /// </summary>
        FastPropertiesOnly = 0x8,

        /// <summary>
        /// Meaning to a calling process: Open a slow item (offline file) if necessary. 
        /// Meaning to a file folder: Retrieve a file from offline storage, if necessary. 
        /// Note: Without this flag, the handler is not created for offline files.
        /// 
        /// Meaning to other folders: Do not return any properties that are very slow.
        /// 
        /// Combination with other flags: Cannot be combined with GPS_TEMPORARY or GPS_FASTPROPERTIESONLY.
        /// </summary>
        OpensLowItem = 0x10,

        /// <summary>
        /// Meaning to a calling process: Delay memory-intensive operations, such as file access, until 
        /// a property is requested that requires such access. 
        /// 
        /// Meaning to a file folder: Do not create the handler until needed; for example, either 
        /// GetCount/GetAt or GetValue, where the innate store does not satisfy the request. 
        /// Note: GetValue might fail due to file access problems.
        /// 
        /// Meaning to other folders: If the folder has memory-intensive properties, such as 
        /// delegating to a file folder or network access, it can optimize performance by 
        /// supporting IDelayedPropertyStoreFactory and splitting up its properties into a 
        /// fast and a slow store. It can then use delayed MUX to recombine them.
        /// 
        /// Combination with other flags: Cannot be combined with GPS_TEMPORARY or 
        /// GPS_READWRITE
        /// </summary>
        DelayCreation = 0x20,

        /// <summary>
        /// Meaning to a calling process: Succeed at getting the store, even if some 
        /// properties are not returned. Note: Some values may be different, or missing,
        /// compared to a store without this flag. 
        /// 
        /// Meaning to a file folder: Succeed and return a store, even if the handler or 
        /// innate store has an error during creation. Only fail if substores fail.
        /// 
        /// Meaning to other folders: Succeed on getting the store, even if some properties 
        /// are not returned.
        /// 
        /// Combination with other flags: Cannot be combined with GPS_TEMPORARY, 
        /// GPS_READWRITE, or GPS_HANDLERPROPERTIESONLY.
        /// </summary>
        BestEffort = 0x40,

        /// <summary>
        /// Mask for valid GETPROPERTYSTOREFLAGS values.
        /// </summary>
        MaskValid = 0xff,
    }

    public enum ShellItemAttributeOptions
    {
        // if multiple items and the attirbutes together.
        And = 0x00000001,
        // if multiple items or the attributes together.
        Or = 0x00000002,
        // Call GetAttributes directly on the 
        // ShellFolder for multiple attributes.
        AppCompat = 0x00000003,

        // A mask for SIATTRIBFLAGS_AND, SIATTRIBFLAGS_OR, and SIATTRIBFLAGS_APPCOMPAT. Callers normally do not use this value.
        Mask = 0x00000003,

        // Windows 7 and later. Examine all items in the array to compute the attributes. 
        // Note that this can result in poor performance over large arrays and therefore it 
        // should be used only when needed. Cases in which you pass this flag should be extremely rare.
        AllItems = 0x00004000
    }

    [Flags]
    public enum SIIGBF
    {
        ResizeToFit = 0x00,
        BiggerSizeOk = 0x01,
        MemoryOnly = 0x02,
        IconOnly = 0x04,
        ThumbnailOnly = 0x08,
        InCacheOnly = 0x10,
    }

    [Flags]
    public enum ThumbnailOptions
    {
        Extract = 0x00000000,
        InCacheOnly = 0x00000001,
        FastExtract = 0x00000002,
        ForceExtraction = 0x00000004,
        SlowReclaim = 0x00000008,
        ExtractDoNotCache = 0x00000020
    }

    [Flags]
    public enum ThumbnailCacheOptions
    {
        Default = 0x00000000,
        LowQuality = 0x00000001,
        Cached = 0x00000002,
    }

    [Flags]
    public enum ShellFolderEnumerationOptions : ushort
    {
        CheckingForChildren = 0x0010,
        Folders = 0x0020,
        NonFolders = 0x0040,
        IncludeHidden = 0x0080,
        InitializeOnFirstNext = 0x0100,
        NetPrinterSearch = 0x0200,
        Shareable = 0x0400,
        Storage = 0x0800,
        NavigationEnum = 0x1000,
        FastItems = 0x2000,
        FlatList = 0x4000,
        EnableAsync = 0x8000
    }
}
