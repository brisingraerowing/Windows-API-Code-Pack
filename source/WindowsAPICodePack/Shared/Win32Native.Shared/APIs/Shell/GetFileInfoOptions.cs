using System;

namespace Microsoft.WindowsAPICodePack.Win32Native.Shell
{
    [Flags]
    public enum GetFileInfoOptions : uint
    {
        /// <summary>
        /// Apply the appropriate overlays to the file's icon. The <see cref="Icon"/> flag must also be set. <b>Windows ME or higher.</b>
        /// </summary>
        AddOverlays = 0x000000020,

        /// <summary>
        /// Modify <see cref="Attributes"/> to indicate that the <see cref="SHFILEINFO.dwAttributes"/> member of the <see cref="SHFILEINFO"/> structure at <b>psfi</b> contains the specific attributes that are desired. These attributes are passed to <see cref="IShellFolder.GetAttributesOf"/>. If this flag is not specified, 0xFFFFFFFF is passed to <see cref="IShellFolder.GetAttributesOf"/>, requesting all attributes. This flag cannot be specified with the <see cref="Icon"/> flag.
        /// </summary>
        AttributesSpecified = 0x000020000,

        /// <summary>
        /// Retrieve the item attributes. The attributes are copied to the <see cref="SHFILEINFO.dwAttributes"/> member of the structure specified in the <b>psfi</b> parameter. These are the same attributes that are obtained from <see cref="IShellFolder.GetAttributesOf"/>.
        /// </summary>
        Attributes = 0x000000800,

        /// <summary>
        /// Retrieve the display name for the file, which is the name as it appears in Windows Explorer. The name is copied to the <see cref="SHFILEINFO.szDisplayName"/> member of the structure specified in <b>psfi</b>. The returned display name uses the long file name, if there is one, rather than the 8.3 form of the file name. Note that the display name can be affected by settings such as whether extensions are shown.
        /// </summary>
        DisplayName = 0x000000200,

        /// <summary>
        /// Retrieve the type of the executable file if <b>pszPath</b> identifies an executable file. The information is packed into the return value. This flag cannot be specified with any other flags.
        /// </summary>
        ExeType = 0x000002000,

        /// <summary>
        /// Retrieve the handle to the icon that represents the file and the index of the icon within the system image list. The handle is copied to the <see cref="SHFILEINFO.hIcon"/> member of the structure specified by <b>psfi</b>, and the index is copied to the <see cref="SHFILEINFO.iIcon"/> member.
        /// </summary>
        Icon = 0x000000100,

        /// <summary>
        /// Retrieve the name of the file that contains the icon representing the file specified by <b>pszPath</b>, as returned by the <see cref="IExtractIcon.GetIconLocation"/> method of the file's icon handler. Also retrieve the icon index within that file. The name of the file containing the icon is copied to the <see cref="SHFILEINFO.szDisplayName"/> member of the structure specified by <b>psfi</b>. The icon's index is copied to that structure's <see cref="SHFILEINFO.iIcon"/> member.
        /// </summary>
        IconLocation = 0x000001000,

        /// <summary>
        /// Modify <see cref="Icon"/>, causing the function to retrieve the file's large icon. The <see cref="Icon"/> flag must also be set.
        /// </summary>
        LargeIcon = 0x000000000,

        /// <summary>
        /// Modify <see cref="Icon"/>, causing the function to add the link overlay to the file's icon. The <see cref="Icon"/> flag must also be set.
        /// </summary>
        LinkOverlay = 0x000008000,

        /// <summary>
        /// Modify <see cref="Icon"/>, causing the function to retrieve the file's open icon. Also used to modify <see cref="SysIconIndex"/>, causing the function to return the handle to the system image list that contains the file's small open icon. A container object displays an open icon to indicate that the container is open. The <see cref="Icon"/> and/or <see cref="SysIconIndex"/> flag must also be set.
        /// </summary>
        OpenIcon = 0x000000002,

        /// <summary>
        /// Return the index of the overlay icon. The value of the overlay index is returned in the upper eight bits of the <see cref="SHFILEINFO.iIcon"/> member of the structure specified by <b>psfi</b>. This flag requires that the <see cref="Icon"/> be set as well. <b>Windows ME or higher.</b>
        /// </summary>
        OverlayIndex = 0x000000040,

        /// <summary>
        /// Indicate that <b>pszPath</b> is the address of an <see cref="ITEMIDLIST"/> structure rather than a path name.
        /// </summary>
        PIDL = 0x000000008,

        /// <summary>
        /// Modify <see cref="Icon"/>, causing the function to blend the file's icon with the system highlight color. The <see cref="Icon"/> flag must also be set.
        /// </summary>
        Selected = 0x000010000,

        /// <summary>
        /// Modify <see cref="Icon"/>, causing the function to retrieve a Shell-sized icon. If this flag is not specified the function sizes the icon according to the system metric values. The <see cref="Icon"/> flag must also be set.
        /// </summary>
        ShelliconSize = 0x000000004,

        /// <summary>
        /// Modify <see cref="Icon"/>, causing the function to retrieve the file's small icon. Also used to modify <see cref="SysIconIndex"/>, causing the function to return the handle to the system image list that contains small icon images. The <see cref="Icon"/> and/or <see cref="SysIconIndex"/> flag must also be set.
        /// </summary>
        SmallIcon = 0x000000001,

        /// <summary>
        /// Retrieve the index of a system image list icon. If successful, the index is copied to the <see cref="SHFILEINFO.iIcon"/> member of <b>psfi</b>. The return value is a handle to the system image list. Only those images whose indices are successfully copied to iIcon are valid. Attempting to access other images in the system image list will result in undefined behavior.
        /// </summary>
        SysIconIndex = 0x000004000,

        /// <summary>
        /// Retrieve the string that describes the file's type. The string is copied to the <see cref="SHFILEINFO.szTypeName"/> member of the structure specified in <b>psfi</b>.
        /// </summary>
        TypeName = 0x000000400,

        /// <summary>
        /// Indicates that the function should not attempt to access the file specified by <b>pszPath</b>. Rather, it should act as if the file specified by <b>pszPath</b> exists with the file attributes passed in <b>dwFileAttributes</b>. This flag cannot be combined with the <see cref="Attributes"/>, <see cref="ExeType"/>, or <see cref="PIDL"/> flags.
        /// </summary>
        UseFileAttributes = 0x000000010
    }
}
