WindowsAPICodePack CHANGELOG
============================

Please note:

- The '#<number\>' notice indicates that the relative issue has been opened starting with the relative release.
- The 'Fixation #<number\>' notice indicates that the relative issue has been fixed starting with the relative release.

For issue and fix details, visit https://github.com/pierresprim/Windows-API-Code-Pack/issues

???? 2.0
========

Global
------

Some types have been renamed and/or have moved.

WinCopies.WindowsAPICodePack.Shell 2.0
---------

- #2
- The following methods and properties throw a NotSupportedException instead of a NotImplementedException:
    - ShellLibrary.this[int]
    - ShellLibrary.Insert(int, ShellFileSystemFolder)
    - ShellLibrary.RemoveAt(int)
    - ShellLibrary implementation of System.Collections.Generic.ICollection<ShellFileSystemFolder>.CopyTo(ShellFileSystemFolder[], int)
- The ShellLibrary does not commit changes automatically anymore. Use the Commit method to commit changes.

WinCopies.WindowsAPICodePack.ShellExtensions 2.0
-------------------

- Fixation #5
- Fixation #7
- Fixation #8

WinCopies.WindowsAPICodePack.Win32Native 2.0
---------------

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

WinCopies.WindowsAPICodePack.Win32NativeConsts 2.0
--------------------

First release

WinCopies.WindowsAPICodePack.PortableDevices 2.0
----------------------

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
