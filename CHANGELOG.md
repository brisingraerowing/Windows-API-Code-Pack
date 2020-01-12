WindowsAPICodePack CHANGELOG
============================

???? 2.0
========

Win32Native 2.0
---------------

- Move some types to the Microsoft.WindowsAPICodePack.Win32Native.* and Microsoft.WindowsAPICodePack namespaces.
- Move GUIDs to the new Win32NativeGuids project.
- Add the BlobHelper and the BlobValueKind types to process binary data easier. This is particularly useful for data retrieved from Win32 APIs like the Windows Registry, Portable Devices, ...

Win32NativeGuids 2.0
--------------------

First release

WindowsPortableDevices
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