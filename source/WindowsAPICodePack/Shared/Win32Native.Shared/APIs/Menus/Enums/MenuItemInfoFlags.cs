namespace Microsoft.WindowsAPICodePack.Win32Native.Menus
{
    public enum MenuItemInfoFlags : uint
    {
        /// <summary>
        /// Retrieves or sets the <see cref="MenuItemInfo.fState"/> member.
        /// </summary>
        State = 0x00000001,

        /// <summary>
        /// Retrieves or sets the <see cref="MenuItemInfo.wID"/> member.
        /// </summary>
        ID = 0x00000002,

        /// <summary>
        /// Retrieves or sets the <see cref="MenuItemInfo.hSubMenu"/> member.
        /// </summary>
        SubMenu = 0x00000004,

        /// <summary>
        /// Retrieves or sets the <see cref="MenuItemInfo.hbmpChecked"/> and <see cref="MenuItemInfo.hbmpUnchecked"/> members.
        /// </summary>
        CheckMarks = 0x00000008,

        /// <summary>
        /// <para>Retrieves or sets the <see cref="MenuItemInfo.fType"/> and <see cref="MenuItemInfo.dwTypeData"/> members.</para>
        /// <para>MIIM_TYPE is replaced by <see cref="Bitmap"/>, <see cref="FType"/>, and <see cref="String"/>.</para>
        /// </summary>
        Type = 0x00000010,

        /// <summary>
        /// Retrieves or sets the <see cref="MenuItemInfo.dwItemData"/> member.
        /// </summary>
        Data = 0x00000020,

        /// <summary>
        /// Retrieves or sets the <see cref="MenuItemInfo.dwTypeData"/> member.
        /// </summary>
        String = 0x00000040,

        /// <summary>
        /// Retrieves or sets the <see cref="MenuItemInfo.hbmpItem"/> member.
        /// </summary>
        Bitmap = 0x00000080,

        /// <summary>
        /// Retrieves or sets the <see cref="MenuItemInfo.fType"/> member.
        /// </summary>
        FType = 0x00000100
    }
}
