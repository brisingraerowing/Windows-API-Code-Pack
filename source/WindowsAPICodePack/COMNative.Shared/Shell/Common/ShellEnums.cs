//Copyright (c) Microsoft Corporation.  All rights reserved.  Distributed under the Microsoft Public License (MS-PL)

using Microsoft.WindowsAPICodePack.COMNative.Shell;
using System;

namespace Microsoft.WindowsAPICodePack.COMNative.Shell
{
    /// <summary>
    /// CommonFileDialog AddPlace locations
    /// </summary>
    public enum FileDialogAddPlaceLocation
    {
        /// <summary>
        /// At the bottom of the Favorites or Places list.
        /// </summary>
        Bottom = 0x00000000,

        /// <summary>
        /// At the top of the Favorites or Places list.
        /// </summary>
        Top = 0x00000001,
    }

    /// <summary>
    /// One of the values that indicates how the ShellObject DisplayName should look.
    /// </summary>
    public enum DisplayNameType
    {
        /// <summary>
        /// Returns the display name relative to the desktop.
        /// </summary>
        Default = 0x00000000,

        /// <summary>
        /// Returns the parsing name relative to the parent folder.
        /// </summary>
        RelativeToParent = unchecked((int)0x80018001),

        /// <summary>
        /// Returns the path relative to the parent folder in a 
        /// friendly format as displayed in an address bar.
        /// </summary>
        RelativeToParentAddressBar = unchecked((int)0x8007c001),

        /// <summary>
        /// Returns the parsing name relative to the desktop.
        /// </summary>
        RelativeToDesktop = unchecked((int)0x80028000),

        /// <summary>
        /// Returns the editing name relative to the parent folder.
        /// </summary>
        RelativeToParentEditing = unchecked((int)0x80031001),

        /// <summary>
        /// Returns the editing name relative to the desktop.
        /// </summary>
        RelativeToDesktopEditing = unchecked((int)0x8004c000),

        /// <summary>
        /// Returns the display name relative to the file system path.
        /// </summary>
        FileSystemPath = unchecked((int)0x80058000),

        /// <summary>
        /// Returns the display name relative to a URL.
        /// </summary>
        Url = unchecked((int)0x80068000),
    }
    /// <summary>
    /// Available Library folder types
    /// </summary>
    public enum LibraryFolderType
    {
        /// <summary>
        /// General Items
        /// </summary>
        Generic = 0,

        /// <summary>
        /// Documents
        /// </summary>
        Documents,

        /// <summary>
        /// Music
        /// </summary>
        Music,

        /// <summary>
        /// Pictures
        /// </summary>
        Pictures,

        /// <summary>
        /// Videos
        /// </summary>
        Videos

    }

    /// <summary>
    /// Flags controlling the appearance of a window
    /// </summary>
    public enum WindowShowCommand
    {
        /// <summary>
        /// Hides the window and activates another window.
        /// </summary>
        Hide = 0,

        /// <summary>
        /// Activates and displays the window (including restoring
        /// it to its original size and position).
        /// </summary>
        Normal = 1,

        /// <summary>
        /// Minimizes the window.
        /// </summary>
        Minimized = 2,

        /// <summary>
        /// Maximizes the window.
        /// </summary>
        Maximized = 3,

        /// <summary>
        /// Similar to <see cref="Normal"/>, except that the window
        /// is not activated.
        /// </summary>
        ShowNoActivate = 4,

        /// <summary>
        /// Activates the window and displays it in its current size
        /// and position.
        /// </summary>
        Show = 5,

        /// <summary>
        /// Minimizes the window and activates the next top-level window.
        /// </summary>
        Minimize = 6,

        /// <summary>
        /// Minimizes the window and does not activate it.
        /// </summary>
        ShowMinimizedNoActivate = 7,

        /// <summary>
        /// Similar to <see cref="Normal"/>, except that the window is not
        /// activated.
        /// </summary>
        ShowNA = 8,

        /// <summary>
        /// Activates and displays the window, restoring it to its original
        /// size and position.
        /// </summary>
        Restore = 9,

        /// <summary>
        /// Sets the show state based on the initial value specified when
        /// the process was created.
        /// </summary>
        Default = 10,

        /// <summary>
        /// Minimizes a window, even if the thread owning the window is not
        /// responding.  Use this only to minimize windows from a different
        /// thread.
        /// </summary>
        ForceMinimize = 11
    }

    /// <summary>
    /// Provides a set of flags to be used with <see cref="SearchCondition"/> 
    /// to indicate the operation in <see cref="SearchConditionFactory"/> methods.
    /// </summary>
    public enum SearchConditionOperation
    {
        /// <summary>
        /// An implicit comparison between the value of the property and the value of the constant.
        /// </summary>
        Implicit = 0,

        /// <summary>
        /// The value of the property and the value of the constant must be equal.
        /// </summary>
        Equal = 1,

        /// <summary>
        /// The value of the property and the value of the constant must not be equal.
        /// </summary>
        NotEqual = 2,

        /// <summary>
        /// The value of the property must be less than the value of the constant.
        /// </summary>
        LessThan = 3,

        /// <summary>
        /// The value of the property must be greater than the value of the constant.
        /// </summary>
        GreaterThan = 4,

        /// <summary>
        /// The value of the property must be less than or equal to the value of the constant.
        /// </summary>
        LessThanOrEqual = 5,

        /// <summary>
        /// The value of the property must be greater than or equal to the value of the constant.
        /// </summary>
        GreaterThanOrEqual = 6,

        /// <summary>
        /// The value of the property must begin with the value of the constant.
        /// </summary>
        ValueStartsWith = 7,

        /// <summary>
        /// The value of the property must end with the value of the constant.
        /// </summary>
        ValueEndsWith = 8,

        /// <summary>
        /// The value of the property must contain the value of the constant.
        /// </summary>
        ValueContains = 9,

        /// <summary>
        /// The value of the property must not contain the value of the constant.
        /// </summary>
        ValueNotContains = 10,

        /// <summary>
        /// The value of the property must match the value of the constant, where '?' 
        /// matches any single character and '*' matches any sequence of characters.
        /// </summary>
        DosWildcards = 11,

        /// <summary>
        /// The value of the property must contain a word that is the value of the constant.
        /// </summary>
        WordEqual = 12,

        /// <summary>
        /// The value of the property must contain a word that begins with the value of the constant.
        /// </summary>
        WordStartsWith = 13,

        /// <summary>
        /// The application is free to interpret this in any suitable way.
        /// </summary>
        ApplicationSpecific = 14
    }

    /// <summary>
    /// Set of flags to be used with <see cref="SearchConditionFactory"/>.
    /// </summary>
    public enum SearchConditionType
    {
        /// <summary>
        /// Indicates that the values of the subterms are combined by "AND".
        /// </summary>
        And = 0,

        /// <summary>
        /// Indicates that the values of the subterms are combined by "OR".
        /// </summary>
        Or = 1,

        /// <summary>
        /// Indicates a "NOT" comparison of subterms.
        /// </summary>
        Not = 2,

        /// <summary>
        /// Indicates that the node is a comparison between a property and a 
        /// constant value using a <see cref="Microsoft.WindowsAPICodePack.COMNative.Shell.SearchConditionOperation"/>.
        /// </summary>
        Leaf = 3,
    }

    /// <summary>
    /// Used to describe the view mode.
    /// </summary>
    public enum FolderLogicalViewMode
    {
        /// <summary>
        /// The view is not specified.
        /// </summary>
        Unspecified = -1,

        /// <summary>
        /// This should have the same affect as Unspecified.
        /// </summary>
        None = 0,

        /// <summary>
        /// The minimum valid enumeration value. Used for validation purposes only.
        /// </summary>
        First = 1,

        /// <summary>
        /// Details view.
        /// </summary>
        Details = 1,

        /// <summary>
        /// Tiles view.
        /// </summary>
        Tiles = 2,

        /// <summary>
        /// Icons view.
        /// </summary>
        Icons = 3,

        /// <summary>
        /// Windows 7 and later. List view.
        /// </summary>
        List = 4,

        /// <summary>
        /// Windows 7 and later. Content view.
        /// </summary>
        Content = 5,

        /// <summary>
        /// The maximum valid enumeration value. Used for validation purposes only.
        /// </summary>
        Last = 5
    }

    /// <summary>
    /// The direction in which the items are sorted.
    /// </summary>
    public enum SortDirection
    {
        /// <summary>
        /// A default value for sort direction, this value should not be used;
        /// instead use Descending or Ascending.
        /// </summary>
        Default = 0,

        /// <summary>
        /// The items are sorted in descending order. Whether the sort is alphabetical, numerical, 
        /// and so on, is determined by the data type of the column indicated in propkey.
        /// </summary>
        Descending = -1,

        /// <summary>
        /// The items are sorted in ascending order. Whether the sort is alphabetical, numerical, 
        /// and so on, is determined by the data type of the column indicated in propkey.
        /// </summary>
        Ascending = 1,
    }

    /// <summary>
    /// Provides a set of flags to be used with IQueryParser::SetOption and 
    /// IQueryParser::GetOption to indicate individual options.
    /// </summary>
    public enum StructuredQuerySingleOption
    {
        /// <summary>
        /// The value should be VT_LPWSTR and the path to a file containing a schema binary.
        /// </summary>
        Schema,

        /// <summary>
        /// The value must be VT_EMPTY (the default) or a VT_UI4 that is an LCID. It is used
        /// as the locale of contents (not keywords) in the query to be searched for, when no
        /// other information is available. The default value is the current keyboard locale.
        /// Retrieving the value always returns a VT_UI4.
        /// </summary>
        Locale,

        /// <summary>
        /// This option is used to override the default word breaker used when identifying keywords
        /// in queries. The default word breaker is chosen according to the language of the keywords
        /// (cf. SQSO_LANGUAGE_KEYWORDS below). When setting this option, the value should be VT_EMPTY
        /// for using the default word breaker, or a VT_UNKNOWN with an object supporting
        /// the IWordBreaker interface. Retrieving the option always returns a VT_UNKNOWN with an object
        /// supporting the IWordBreaker interface.
        /// </summary>
        WordBreaker,

        /// <summary>
        /// The value should be VT_EMPTY or VT_BOOL with VARIANT_TRUE to allow natural query
        /// syntax (the default) or VT_BOOL with VARIANT_FALSE to allow only advanced query syntax.
        /// Retrieving the option always returns a VT_BOOL.
        /// This option is now deprecated, use SQSO_SYNTAX.
        /// </summary>
        NaturalSyntax,

        /// <summary>
        /// The value should be VT_BOOL with VARIANT_TRUE to generate query expressions
        /// as if each word in the query had a star appended to it (unless followed by punctuation
        /// other than a parenthesis), or VT_EMPTY or VT_BOOL with VARIANT_FALSE to
        /// use the words as they are (the default). A word-wheeling application
        /// will generally want to set this option to true.
        /// Retrieving the option always returns a VT_BOOL.
        /// </summary>
        AutomaticWildcard,

        /// <summary>
        /// Reserved. The value should be VT_EMPTY (the default) or VT_I4.
        /// Retrieving the option always returns a VT_I4.
        /// </summary>
        TraceLevel,

        /// <summary>
        /// The value must be a VT_UI4 that is a LANGID. It defaults to the default user UI language.
        /// </summary>
        LanguageKeywords,

        /// <summary>
        /// The value must be a VT_UI4 that is a STRUCTURED_QUERY_SYNTAX value.
        /// It defaults to SQS_NATURAL_QUERY_SYNTAX.
        /// </summary>
        Syntax,

        /// <summary>
        /// The value must be a VT_BLOB that is a copy of a TIME_ZONE_INFORMATION structure.
        /// It defaults to the current time zone.
        /// </summary>
        TimeZone,

        /// <summary>
        /// This setting decides what connector should be assumed between conditions when none is specified.
        /// The value must be a VT_UI4 that is a CONDITION_TYPE. Only CT_AND_CONDITION and CT_OR_CONDITION
        /// are valid. It defaults to CT_AND_CONDITION.
        /// </summary>
        ImplicitConnector,

        /// <summary>
        /// This setting decides whether there are special requirements on the case of connector keywords (such
        /// as AND or OR). The value must be a VT_UI4 that is a CASE_REQUIREMENT value.
        /// It defaults to CASE_REQUIREMENT_UPPER_IF_AQS.
        /// </summary>
        ConnectorCase,

    }

    /// <summary>
    /// Provides a set of flags to be used with IQueryParser::SetMultiOption 
    /// to indicate individual options.
    /// </summary>
    public enum StructuredQueryMultipleOption
    {
        /// <summary>
        /// The key should be property name P. The value should be a
        /// VT_UNKNOWN with an IEnumVARIANT which has two values: a VT_BSTR that is another
        /// property name Q and a VT_I4 that is a CONDITION_OPERATION cop. A predicate with
        /// property name P, some operation and a value V will then be replaced by a predicate
        /// with property name Q, operation cop and value V before further processing happens.
        /// </summary>
        VirtualProperty,

        /// <summary>
        /// The key should be a value type name V. The value should be a
        /// VT_LPWSTR with a property name P. A predicate with no property name and a value of type
        /// V (or any subtype of V) will then use property P.
        /// </summary>
        DefaultProperty,

        /// <summary>
        /// The key should be a value type name V. The value should be a
        /// VT_UNKNOWN with a IConditionGenerator G. The GenerateForLeaf method of
        /// G will then be applied to any predicate with value type V and if it returns a query
        /// expression, that will be used. If it returns NULL, normal processing will be used
        /// instead.
        /// </summary>
        GeneratorForType,

        /// <summary>
        /// The key should be a property name P. The value should be a VT_VECTOR|VT_LPWSTR,
        /// where each string is a property name. The count must be at least one. This "map" will be
        /// added to those of the loaded schema and used during resolution. A second call with the
        /// same key will replace the current map. If the value is VT_NULL, the map will be removed.
        /// </summary>
        MapProperty,
    }

    /// <summary>
    /// Used by IQueryParserManager::SetOption to set parsing options. 
    /// This can be used to specify schemas and localization options.
    /// </summary>
    public enum QueryParserManagerOption
    {
        /// <summary>
        /// A VT_LPWSTR containing the name of the file that contains the schema binary. 
        /// The default value is StructuredQuerySchema.bin for the SystemIndex catalog 
        /// and StructuredQuerySchemaTrivial.bin for the trivial catalog.
        /// </summary>
        SchemaBinaryName = 0,

        /// <summary>
        /// Either a VT_BOOL or a VT_LPWSTR. If the value is a VT_BOOL and is FALSE, 
        /// a pre-localized schema will not be used. If the value is a VT_BOOL and is TRUE, 
        /// IQueryParserManager will use the pre-localized schema binary in 
        /// "%ALLUSERSPROFILE%\Microsoft\Windows". If the value is a VT_LPWSTR, the value should 
        /// contain the full path of the folder in which the pre-localized schema binary can be found. 
        /// The default value is VT_BOOL with TRUE.
        /// </summary>
        PreLocalizedSchemaBinaryPath = 1,

        /// <summary>
        /// A VT_LPWSTR containing the full path to the folder that contains the 
        /// unlocalized schema binary. The default value is "%SYSTEMROOT%\System32".
        /// </summary>
        UnlocalizedSchemaBinaryPath = 2,

        /// <summary>
        /// A VT_LPWSTR containing the full path to the folder that contains the 
        /// localized schema binary that can be read and written to as needed. 
        /// The default value is "%LOCALAPPDATA%\Microsoft\Windows".
        /// </summary>
        LocalizedSchemaBinaryPath = 3,

        /// <summary>
        /// A VT_BOOL. If TRUE, then the paths for pre-localized and localized binaries 
        /// have "\(LCID)" appended to them, where language code identifier (LCID) is 
        /// the decimal locale ID for the localized language. The default is TRUE.
        /// </summary>
        AppendLCIDToLocalizedPath = 4,

        /// <summary>
        /// A VT_UNKNOWN with an object supporting ISchemaLocalizerSupport. 
        /// This object will be used instead of the default localizer support object.
        /// </summary>
        LocalizerSupport = 5
    }

    [Flags]
    public enum ShellOperationFlags : uint
    {

        /// <summary>
        /// <para>Preserve undo information, if possible.</para>
        /// <para>Prior to Windows Vista, operations could be undone only from the same process that performed the original operation.</para>
        /// <para>In Windows Vista and later systems, the scope of the undo is a user session. Any process running in the user session can undo another operation. The undo state is held in the Explorer.exe process, and as long as that process is running, it can coordinate the undo functions.</para>
        /// <para>If the source file parameter does not contain fully qualified path and file names, this flag is ignored.</para>
        /// </summary>
        AllowUndo = 0x0040,

        /// <summary>
        /// Perform the operation only on files (not on folders) if a wildcard file name (.) is specified.
        /// </summary>
        FilesOnly = 0x0080,

        /// <summary>
        /// Respond with <b>Yes to All</b> for any dialog box that is displayed.
        /// </summary>
        NoConfirmation = 0x0010,

        /// <summary>
        /// Do not confirm the creation of a new folder if the operation requires one to be created.
        /// </summary>
        NoConfirmMkDir = 0x0200,

        /// <summary>
        /// Do not move connected items as a group. Only move the specified files.
        /// </summary>
        NoConnectedElements = 0x2000,

        /// <summary>
        /// Do not copy the security attributes of the item.
        /// </summary>
        NoCopySecurityAttribs = 0x0800,

        /// <summary>
        /// Do not display a message to the user if an error occurs. If this flag is set without <see cref="EarlyFailure"/>, any error is treated as if the user had chosen <b>Ignore</b> or <b>Continue</b> in a dialog box. It halts the current action, sets a flag to indicate that an action was aborted, and proceeds with the rest of the operation.
        /// </summary>
        NoErrorUI = 0x0400,

        /// <summary>
        /// Only operate in the local folder. Do not operate recursively into subdirectories.
        /// </summary>
        NoRecursion = 0x1000,

        /// <summary>
        /// Give the item being operated on a new name in a move, copy, or rename operation if an item with the target name already exists.
        /// </summary>
        RenameOnCollision = 0x0008,

        /// <summary>
        /// Do not display a progress dialog box.
        /// </summary>
        Silent = 0x0004,

        /// <summary>
        /// Send a warning if a file or folder is being destroyed during a delete operation rather than recycled. This flag partially overrides <see cref="NoConfirmation"/>.
        /// </summary>
        WantNukeWarning = 0x4000,

        /// <summary>
        /// <b>Introduced in Windows 8.</b> The file operation was user-invoked and should be placed on the undo stack. This flag is preferred to <see cref="AllowUndo"/>.
        /// </summary>
        AddUndoRecord = 0x20000000,

        /// <summary>
        /// Walk into Shell namespace junctions. By default, junctions are not entered. For more information on junctions, see <a href="https://msdn.microsoft.com/2c1fdd5d-b359-4d5c-a20e-0622f3a1cb1d">Specifying a Namespace Extension's Location</a>.
        /// </summary>
        NoSkipJunctions = 0x00010000,

        /// <summary>
        /// If possible, create a hard link rather than a new instance of the file in the destination.
        /// </summary>
        PreferHardLink = 0x00020000,

        /// <summary>
        /// If an operation requires elevated rights and the <see cref="NoErrorUI"/> flag is set to disable error UI, display a UAC UI prompt nonetheless.
        /// </summary>
        ShowElevationPrompt = 0x00040000,

        /// <summary>
        /// If <see cref="EarlyFailure"/> is set together with <see cref="NoErrorUI"/>, the entire set of operations is stopped upon encountering any error in any operation. This flag is valid only when <see cref="NoErrorUI"/> is set.
        /// </summary>
        EarlyFailure = 0x00100000,

        /// <summary>
        /// Rename collisions in such a way as to preserve file name extensions. This flag is valid only when <see cref="RenameOnCollision"/> is also set.
        /// </summary>
        PreserveFileExtensions = 0x00200000,

        /// <summary>
        /// Keep the newer file or folder, based on the Date Modified property, if a collision occurs. This is done automatically with no prompt UI presented to the user.
        /// </summary>
        KeepNewerFile = 0x00400000,

        /// <summary>
        /// Do not use copy hooks.
        /// </summary>
        NoCopyHooks = 0x00800000,

        /// <summary>
        /// Do not allow the progress dialog to be minimized.
        /// </summary>
        NoMinimizeBox = 0x01000000,

        /// <summary>
        /// Copy the security attributes of the source item to the destination item when performing a cross-volume move operation. Without this flag, the destination item receives the security attributes of its new folder.
        /// </summary>
        MoveACLSAcrossVolumes = 0x02000000,

        /// <summary>
        /// Do not display the path of the source item in the progress dialog.
        /// </summary>
        DoNotDisplaySourcePath = 0x04000000,

        /// <summary>
        /// Do not display the path of the destination item in the progress dialog.
        /// </summary>
        DoNotDisplayDestPath = 0x08000000,

        /// <summary>
        /// <b>Introduced in Windows 8.</b> When a file is deleted, send it to the Recycle Bin rather than permanently deleting it.
        /// </summary>
        RecycleOnDelete = 0x00080000,

        /// <summary>
        /// <b>Introduced in Windows Vista SP1.</b> The user expects a requirement for rights elevation, so do not display a dialog box asking for a confirmation of the elevation.
        /// </summary>
        RequireElevation = 0x10000000,

        /// <summary>
        /// <b>Introduced in Windows 7.</b> Display a <b>Downloading</b> instead of <b>Copying</b> message in the progress dialog.
        /// </summary>
        CopyAsDownload = 0x40000000,

        /// <summary>
        /// <b>Introduced in Windows 7.</b> Do not display the location line in the progress dialog.
        /// </summary>
        DoNotDisplayLocations = 0x80000000

    }

    /// <summary>
    /// Provides operation status flags.
    /// </summary>
    public enum PDOPSTATUS
    {

        /// <summary>
        /// Operation is running, no user intervention.
        /// </summary>
        Running,

        /// <summary>
        /// Operation has been paused by the user.
        /// </summary>
        Paused,

        /// <summary>
        /// Operation has been canceled by the user - now go undo.
        /// </summary>
        Cancelled,

        /// <summary>
        /// Operation has been stopped by the user - terminate completely.
        /// </summary>
        Stopped,

        /// <summary>
        /// Operation has gone as far as it can go without throwing error dialogs.
        /// </summary>
        Errors

    }

    public enum PDMODE
    {

        /// <summary>
        /// Use the default progress dialog operations mode.
        /// </summary>
        Default = 0x00000000,

        /// <summary>
        /// The operation is running.
        /// </summary>
        Run = 0x00000001,

        /// <summary>
        /// The operation is gathering data before it begins, such as calculating the predicted operation time.
        /// </summary>
        Prelight = 0x00000002,

        /// <summary>
        /// The operation is rolling back due to an Undo command from the user.
        /// </summary>
        Undoing = 0x00000004,

        /// <summary>
        /// Error dialogs are blocking progress from continuing.
        /// </summary>
        ErrorsBlocking = 0x00000008,

        /// <summary>
        /// The length of the operation is indeterminate. Do not show a timer and display the progress bar in marquee mode.
        /// </summary>
        Indeterminate = 0x00000010

    }

    /// <summary>
    /// Describes an action being performed that requires progress to be shown to the user using an IActionProgress interface.
    /// </summary>
    public enum SPAction
    {

        /// <summary>
        /// No action is being performed.
        /// </summary>
        None,

        /// <summary>
        /// Files are being moved.
        /// </summary>
        Moving,

        /// <summary>
        /// Files are being copied.
        /// </summary>
        Copying,

        /// <summary>
        /// Files are being deleted.
        /// </summary>
        Recycling,

        /// <summary>
        /// A set of attributes are being applied to files.
        /// </summary>
        ApplyingAttribs,

        /// <summary>
        /// A file is being downloaded from a remote source.
        /// </summary>
        Downloading,

        /// <summary>
        /// An Internet search is being performed.
        /// </summary>
        SearchingInternet,

        /// <summary>
        /// A calculation is being performed.
        /// </summary>
        Calculating,

        /// <summary>
        /// A file is being uploaded to a remote source.
        /// </summary>
        Uploading,

        /// <summary>
        /// A local search is being performed.
        /// </summary>
        SearchingFiles,

        /// <summary>
        /// <b>Windows Vista and later.</b> A deletion is being performed.
        /// </summary>
        Deleting,

        /// <summary>
        /// <b>Windows Vista and later.</b> A renaming action is being performed.
        /// </summary>
        Renaming,

        /// <summary>
        /// <b>Windows Vista and later.</b> A formatting action is being performed.
        /// </summary>
        Formatting,

        /// <summary>
        /// <b>Windows 7 and later.</b> A copy or move action is being performed.
        /// </summary>
        CopyMoving

    }

    [Flags]
    public enum OPPROGDLG
    {

        /// <summary>
        /// Default, normal progress dialog behavior.
        /// </summary>
        Normal = 0x00000000,

        /// <summary>
        /// The dialog is modal to its hwndOwner. The default setting is modeless.
        /// </summary>
        Modal = 0x00000001,

        /// <summary>
        /// Update "Line3" text with the time remaining. This flag does not need to be implicitly set because progress dialogs started by <see cref="IOperationsProgressDialog.StartProgressDialog"/> automatically display the time remaining.
        /// </summary>
        AutoTime = 0x00000002,

        /// <summary>
        /// Do not show the time remaining. We do not recommend setting this flag through <see cref="IOperationsProgressDialog"/> because it goes against the purpose of the dialog.
        /// </summary>
        NoTime = 0x00000004,

        /// <summary>
        /// Do not display the minimize button.
        /// </summary>
        NoMinimize = 0x00000008,

        /// <summary>
        /// Do not display the progress bar.
        /// </summary>
        NoProgressBar = 0x00000010,

        /// <summary>
        /// This flag is invalid in this method. To set the progress bar to marquee mode, use the flags in <see cref="IOperationsProgressDialog.SetMode"/>.
        /// </summary>
        MarqueeProgress = 0x00000020,

        /// <summary>
        /// Do not display a cancel button because the operation cannot be canceled. Use this value only when absolutely necessary.
        /// </summary>
        NoCancel = 0x00000040,

        /// <summary>
        /// <b>Windows 7 and later.</b> Indicates default, normal operation progress dialog behavior.
        /// </summary>
        Default = 0x00000000,

        /// <summary>
        /// Display a pause button. Use this only in situations where the operation can be paused.
        /// </summary>
        EnablePause = 0x00000080,

        /// <summary>
        /// The operation can be undone through the dialog. The <b>Stop</b> button becomes <b>Undo</b>. If pressed, the <b>Undo</b> button then reverts to <b>Stop</b>.
        /// </summary>
        AllowUndo = 0x00000100,

        /// <summary>
        /// Do not display the path of source file in the progress dialog.
        /// </summary>
        DoNotDisplaySourcePath = 0x00000200,

        /// <summary>
        /// Do not display the path of the destination file in the progress dialog.
        /// </summary>
        DoNotDisplayDestPath = 0x00000400,

        /// <summary>
        /// <b>Windows 7 and later.</b> If the estimated time to completion is greater than one day, do not display the time.
        /// </summary>
        NoMultiDayEstimates = 0x00000800,

        /// <summary>
        /// <b>Windows 7 and later.</b> Do not display the location line in the progress dialog.
        /// </summary>
        DoNotDisplayLocations = 0x00001000

    }
}
