WindowsAPICodePack CHANGELOG
============================

Please note:

- The '#<number\>' notice indicates that the relative issue has been opened starting with the relative release.
- The 'Fixation #<number\>'/'Fixes #<number\>' notice indicates that the relative issue has been fixed starting with the relative release.

For issue and fixation details, visit [https://wincopies.com/fwd.php?id=3](https://wincopies.com/fwd.php?id=3)

???? 2.0.0-preview3
===================

Remove original code archive; for the original code, see [https://wincopies.com/fwd.php?id=1](https://wincopies.com/fwd.php?id=1)

WinCopies.WindowsAPICodePack.Sensors 2.0.0-preview3
---------------------------------------------------

- Existing items behavior updates:
	- The Microsoft.WindowsAPICodePack.Sensros.DataReportChangedEventHandler delegate does not have the 'in' keyword anymore for the 'Sensor sender' parameter.

WinCopies.WindowsAPICodePack.ShellExtensions 2.0.0-preview3
-----------------------------------------------------------

- Existing items behavior updates:
	- The Microsoft.WindowsAPICodePack.ShellExtensions.WindowUtilities type has moved to the WinCopies.WindowsAPICodePack.Shell package into the Microsoft.WindowsAPICodePack.Shell package and is now called 'DesktopWindowManager'.

WinCopies.WindowsAPICodePack.Win32Native 2.0.0-preview3
-------------------------------------------------------

- Bug fixes:
    - The Microsoft.WindowsAPICodePack.Win32Native.Shell.SHFILEINFO struct was not capable to handle file display name and type name.

- Existing items behavior updates:
	- The Microsoft.WindowsAPICodePack.COMNative.Shell.WindowStyles(Ex) enums have moved to the WinCopies.WindowsAPICodePack.Shell package into the Microsoft.WindowsAPICodePack.Shell namespace.
	- The GetParentOffsetOfChild and GetNonClientArea methods of the Microsoft.WindowsAPICodePack.ComNative.Shell.WindowUtilities class have moved to the WinCopies.WindowsAPICodePack.Shell package into the new Microsoft.WindowsAPICodePack.Shell.DesktopWindowManager class.
	- The Microsoft.WindowsAPICodePack.Win32Native.WindowMessage type has moved to the Microsoft.WindowsAPICodePack namespace.
    - The Microsoft.WindowsAPICodePack.Win32Native.Shell.FileAttributes, Microsoft.WindowsAPICodePack.GetFileInfoOptions and Microsoft.WindowsAPICodePack.Win32Native.Shell.ShellFileGetAttributesOptions enums now have the uint underlying type.
    - The Microsoft.WindowsAPICodePack.Win32Native.Shell.Shell.SHGetFileInfo method now targets the unicode variant.
    - The Microsoft.WindowsAPICodePack.Shell.FileInfo struct is not mutable anymore.

- Additions:
    - New P/Invoke methods in the Microsoft.WindowsAPICodePack.Win32Native.Core class.

03/28/2020 2.0.0-preview2
=========================

Global
------

Some types have been renamed and/or have moved.

WinCopies.WindowsAPICodePack.Win32Native 2.0.0-preview2
-------------------------------------------------------

- Add new P/Invoke methods.

WinCopies.WindowsAPICodePack.COMNative 2.0.0-preview2
-----------------------------------------------------

First release

03/19/2020 2.0.0-preview1
=========================

Global
------

Some types have been renamed and/or have moved.

WinCopies.WindowsAPICodePack.Shell 2.0.0-preview1
-------------------------------------------------

- #2
- The following methods and properties throw a NotSupportedException instead of a NotImplementedException:
    - ShellLibrary.this\[int]
    - ShellLibrary.Insert(int, ShellFileSystemFolder)
    - ShellLibrary.RemoveAt(int)
    - ShellLibrary implementation of System.Collections.Generic.ICollection<ShellFileSystemFolder>.CopyTo(ShellFileSystemFolder\[], int)
- The ShellLibrary does not commit changes automatically anymore. Use the Commit method to commit changes.

WinCopies.WindowsAPICodePack.ShellExtensions 2.0.0-preview1
-----------------------------------------------------------

- Fixation #5
- Fixation #7
- Fixation #8

WinCopies.WindowsAPICodePack.Win32Native 2.0.0-preview1
-------------------------------------------------------

- Move some types to the Microsoft.WindowsAPICodePack.Win32Native.* and Microsoft.WindowsAPICodePack namespaces.
- Move GUIDs and consts to the new Win32NativeConsts project.
- Add the BlobHelper and the BlobValueKind types to process binary data easier. This is particularly useful for data retrieved from Win32 APIs like the Windows Registry, Portable Devices, ...
- Some classes and interfaces of the Sensor package or the Win32Native package's Sensor section have changed or have been removed.
- The namespace has changed for some types.
- The following properties of the Microsoft.WindowsAPICodePack.Win32Native.Shell.Resources class have changed:
    - from: FolderTypeSearchResults to: FolderTypeGenericSearchResults
    - from: FolderTypeClassic to: FolderTypeControlPanelClassic
    - from: FolderTypeControlPanelCategory to: FolderTypeCategory
- Fixation #5
- Fixation #6
- Fixation #9
- Fixation #10

WinCopies.WindowsAPICodePack.Win32Native.Consts 2.0.0-preview1
--------------------------------------------------------------

First release

WinCopies.WindowsAPICodePack.PortableDevices 2.0.0-preview1
-----------------------------------------------------------

First release

08/04/2019 1.1.5.2
==================

- Add support for Source Link

Shell 1.2.2
-----------
- Optimize FileOperation class.

07/24/2019 1.1.5.1
==================

Shell 1.2.1
------------
- Bug fix: GetFileInfo methods: This method now can be called for files that does not have icon

07/23/2019 1.1.5
================

Shell 1.2.0
-----------
- Add gesture for the SHGetFileInfo API

Win32Native 1.2.0
-----------------
- Move some enums from Win32Native to Shell namespace
- Add gesture for the SHGetFileInfo API

06/16/2019 1.1.4
================

Shell 1.1.2
-----------
Add feature for creating single-instance apps

06/15/2019 1.1.4
================

Win32Native 1.1.0
-----------------
Add features for interacting with the system Clipboard and to create single-instance apps

06/01/2019
==========

Shell 1.1.1
-----------
Add some features for interacting with file system

Win32Native 1.0.0
-----------------
Move some native Win32 and COM APIs to this new project

02/01/2016
==========
 
Core 1.1.2
----------
- TaskDialog icons were visible only when defined in Opened event
- TaskDialog custom/hyperlink button not closing dialog from within Click event
