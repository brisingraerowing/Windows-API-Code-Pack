WindowsAPICodePack CHANGELOG
============================

Note:

- The '#<number\>' notice indicates that the relative issue has been opened starting with the relative release.
- The 'Fixation #<number\>'/'Fixes #<number\>' notice indicates that the relative issue has been fixed starting with the relative release.

For issues and bug fixes details, visit [https://wincopies.com/fwd.php?id=3](https://wincopies.com/fwd.php?id=3)

For the original code (version 1.1, last release by Microsoft), see [https://wincopies.com/fwd.php?id=1](https://wincopies.com/fwd.php?id=1)

## 09/21/2021 3.7.1

- Add GetPIDLs methods to ShellContainer.
- Add types and TryExtractIcon method to FileOperation and SHGetImageList native method.

## 09/08/2021 3.6.1

- Add:
    - ShellContextMenu.
    - types and static methods.
    - consts.
- Update IShellFolder implementation.

## 08/28/2021 3.5

- Update DeleteConsoleMenu method parameters.

## 08/16/2021 3.4

- Update file operations implementations to extend features.
- Microsoft.WindowsAPICodePack.Shell.FileInfo:
    - implements WinCopies.DotNetFix.IDisposable.
    - constructor parameters have the 'in' modifier.

## 07/17/2021 3.3

- The PortableDevice event args have been updated to let the user know which device was updated.
- Rename FileLockFinder.FindLockFinder to FindFileLock.

## 05/24/2021 3.1.1-3.2

Bug fixes in window styles. The window style-related managed method definitions have been updated.

## 05/05/2021 3.1

### Shell

WindowStyles is defined for the 'long' underlying type and its values have been updated.

02/04/2021 3.0.1
================

Targets WinCopies Framework 3.x.

Shell 3.0
---------

- Changes:
    - ShellObject.FromParsingName was removed because it was redundant with ShellObjectFactory.Create.
    - ShellFile has a new constructor instead of the FromFilePath static method.
    - ShellLink inherits from ShellFile instead of ShellObject. ShellObject inheritance is still available through ShellFile.
    - The ShellLink's constructor was replaced by a static method.

PortableDevices 3.0
-------------------

- Additions:
    - Properties and events to the main object model interfaces.
    - IPortableDeviceObject.Delete method.
    - IPortableDeviceFile.TransferFrom(string path, FileMode fileMode, FileShare fileShare, int bufferSize, bool forceBufferSize, PortableDeviceTransferCallback d) method.
- Changes:
    - IEnumerable now implements interfaces instead of IPortableDevice and IEnumerablePortableDeviceObject. However, these interfaces have changed: IEnumerable now implements only System.Collections.Generic.IEnumerable.

COMNative 3.0
-------------

- Removals:
    - Some 'ref' keywords in native PortableDevices interfaces. These keywords have been removed for interface type parameters because they was redundant.

## 09/26/2021 2.9.3

- #24, #27

## 09/21/2021 2.9.1

- Add setter to NotificationIcon.ToolTip.
- Add properties to ShellThumbnail.
- Add types and TryExtractIcon method to FileOperation and SHGetImageList native method.

## 09/08/2021 2.8

- Add:
    - types and static methods.
    - consts.
- Remove hook from window when NotificationIcon is disposing.

## 08/28/2021 2.7

- Add:
    - Win32 API implementations
    - notification support for WPF
    - new static methods
    - fields to SystemCommand
- Update Readme files. Fixes #25

## 08/16/2021 2.6

- Add new types.
- Update file operations implementations to extend features.
- Add support for .Net 3.5, 4.0, 4.5 and 6.0. Fixes #22.
- Bug fixed in SHQUERYRBINFO: wrong StructLayout.Pack value.

## 07/17/2021 2.5

- Bug fixed in FileOperation: the unadvised cookies were not removed from the cookies list.
- Add new helper methods.

## 06/19/2021 2.4

Add new types, mainly for named pipes.

## 05/24/2021 2.3

Add features to PortableDevices.

## 05/05/2021 2.2

- DesktopWindowManager:
    - Add new helper methods for windows.
    - Remove 'Get/SetWindowStylesEx' method.

### Win32Native

- Add 'MenuFlags' and SystemMenuCommands enums.
- Add new methods to DesktopWindowManager and Shell.

02/04/2021 2.1.1
================

- Bug fixed in PropVariant. Vectors thrown errors because of invalid field offset. Fixes #18.
- Other bug fixes in PropertySystem and PortableDevices.
- Add constructors to ClientVersion.

12/16/2020 2.1.0
================

- Supports .Net Core 3.1 and .Net 5.0. Fixes #16.
- Add methods to transfer content to and from portable devices.

07/14/2020 2.0.1
================

- The assembly 'Microsoft.WindowsAPICodePack.Win32Native.Consts' has been renamed to 'Microsoft.WindowsAPICodePack.Consts'.
- The namespace 'Microsoft.WindowsAPICodePack.Win32Native.Consts' has been renamed to 'Microsoft.WindowsAPICodePack.NativeAPI.Consts'.
- The namespace 'Microsoft.WindowsAPICodePack.Win32Native.Guids' has been renamed to 'Microsoft.WindowsAPICodePack.NativeAPI.Guids'.

WinCopies.WindowsAPICodePack.Shell 2.0.1
----------------------------------------

Add the FileLockFinder static class.

WinCopies.WindowsAPICodePack.Win32Native 2.0.1
----------------------------------------------

- Add a part of the Restart Manager API
- Some content of the Microsoft.WindowsAPICodePack.Win32Native.ExtendedLinguisticServices.InteropTools class has moved to the new Microsoft.WindowsAPICodePack.Win32Native.InteropTools class.

WinCopies.WindowsAPICodePack.Consts 2.0.1
-----------------------------------------

- Changes:
    - HResultFacility has moved to the Microsoft.WindowsAPICodePack.Win32Native namespace.
- Additions:
    - Add new error codes

05/01/2020 2.0.0-preview6
=========================

WinCopies.WindowsAPICodePack.Shell 2.0.0-preview6
-------------------------------------------------

- Bug fixes:
    - #11
    - #12

WinCopies.WindowsAPICodePack.Win32Native 2.0.0-preview6
-------------------------------------------------------

- Existing items behavior updates:
    - Add CharSet.Auto for the native methods in the Microsoft.WindowsAPICodePack.Win32Native.GDI.GDI class for better compatibility with other packages.

04/25/2020 2.0.0-preview5
=========================

WinCopies.WindowsAPICodePack.Win32Native 2.0.0-preview5
-------------------------------------------------------

- Depends on WinCopies.Util version 2.2.0-preview3.

- Existing items behavior updates:
    - Fix marshaling for the Microsoft.WindowsAPICodePack.Win32Native.GDI.GDI.CreateDIBSection(IntPtr hdc, ref BitmapInfo pbmi, uint usage, out IntPtr ppvBits, IntPtr hSection, uint offset) method.
    - Fix Microsoft.WindowsAPICodePack.Win32Native.GDI.GDI.BitmapInfoHeader fields.

04/25/2020 2.0.0-preview4
=========================

WinCopies.WindowsAPICodePack.Win32Native 2.0.0-preview4
-------------------------------------------------------

- Existing items behavior updates:
    - Update marshaling for the Microsoft.WindowsAPICodePack.Win32Native.Core.UpdateResource(IntPtr hUpdate, string lpType, string lpName, ushort wLanguage, byte[] lpData, uint cb) method.

- Replacements:
    - Microsoft.WindowsAPICodePack.Win32Native.Core.UpdateResource([In] IntPtr hUpdate, [In, MarshalAs(UnmanagedType.U2)] ushort lpType, [In, MarshalAs(UnmanagedType.U2)] ushort lpName, [In] ushort wLanguage, [In] byte[] lpData, [In] uint cb) method by the Microsoft.WindowsAPICodePack.Win32Native.Core.UpdateResource([In] IntPtr hUpdate, [In] IntPtr lpType, [In] IntPtr lpName, [In, MarshalAs(UnmanagedType.U2)] ushort wLanguage, [In] byte[] lpData, [In, MarshalAs(UnmanagedType.U4)] uint cb) method.

- Bug fixes:
    - The Microsoft.WindowsAPICodePack.Win32Native.GDI.GDI.CreateCompatibleBitmap([In] IntPtr hdc, [In, MarshalAs(UnmanagedType.I4)] int cx, [In, MarshalAs(UnmanagedType.I4)] int cy) method did not specify the DLLImport attribute.

04/24/2020 2.0.0-preview3
=========================

Remove original code archive; for the original code (version 1.1, last release by Microsoft), see [https://wincopies.com/fwd.php?id=1](https://wincopies.com/fwd.php?id=1)

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
- Add handling for the SHGetFileInfo API

Win32Native 1.2.0
-----------------
- Move some enums from Win32Native to Shell namespace
- Add handling for the SHGetFileInfo API

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
