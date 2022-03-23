using System;

namespace Microsoft.WindowsAPICodePack.Win32Native.Menus
{
    [Flags]
    public enum MenuFlags : uint
    {
        Insert = 0x00000000,
        Change = 0x00000080,
        Append = 0x00000100,
        Delete = 0x00000200,
        Remove = 0x00001000,



        ByCommand = Insert,
        ByPosition = 0x00000400,



        /// <summary>
        /// <para>Name: MFT_SEPARATOR</para>
        /// <para>Description: Specifies that the menu item is a separator. A menu item separator appears as a horizontal dividing line. The dwTypeData and cch members are ignored. This value is valid only in a drop-down menu, submenu, or shortcut menu.</para>
        /// </summary>
        Separator = 0x00000800,



        Enabled = Insert,
        Grayed = 0x00000001,
        Disabled = 0x00000002,



        Unchecked = Insert,
        Checked = 0x00000008,
        UseCheckBitmaps = Delete,



        /// <summary>
        /// <para>Name: MFT_STRING</para>
        /// <para>Description: Displays the menu item using a text string. The <see cref="MenuItemInfo.dwTypeData"/> member is the pointer to a null-terminated string, and the cch member is the length of the string.</para>
        /// <para>Replaced by: <see cref="MenuItemInfoFlags.String"/>.</para>
        /// </summary>
        String = Insert,

        /// <summary>
        /// <para>Name: MFT_BITMAP</para>
        /// <para>Description: Displays the menu item using a bitmap. The low-order word of the dwTypeData member is the bitmap handle, and the cch member is ignored.</para>
        /// <para>Replaced by: <see cref="MenuItemInfoFlags.Bitmap"/> and <see cref="MenuItemInfo.hbmpItem"/>.</para>
        /// </summary>
        Bitmap = 0x00000004,

        /// <summary>
        /// <para>Name: MFT_OWNERDRAW</para>
        /// <para>Description: Assigns responsibility for drawing the menu item to the window that owns the menu. The window receives a <see cref="WindowMessage.MeasureItem"/> message before the menu is displayed for the first time, and a <see cref="WindowMessage.DrawItem"/> message whenever the appearance of the menu item must be updated. If this value is specified, the dwTypeData member contains an application-defined value.</para>
        /// </summary>
        OwnerDraw = Append,



        Popup = 0x00000010,

        /// <summary>
        /// <para>Name: MFT_MENUBARBREAK</para>
        /// <para>Description: Places the menu item on a new line (for a menu bar) or in a new column (for a drop-down menu, submenu, or shortcut menu). For a drop-down menu, submenu, or shortcut menu, a vertical line separates the new column from the old.</para>
        /// </summary>
        MenuBarBreak = 0x00000020,

        /// <summary>
        /// <para>Name: MFT_MENUBREAK</para>
        /// <para>Description: Places the menu item on a new line (for a menu bar) or in a new column (for a drop-down menu, submenu, or shortcut menu). For a drop-down menu, submenu, or shortcut menu, the columns are not separated by a vertical line.</para>
        /// </summary>
        MenuBreak = 0x00000040,



        Unhilite = Insert,
        Hilite = Change,



        Default = Remove,



        SystemMenu = 0x00002000,
        Help = 0x00004000,



        /// <summary>
        /// <para>Name: MFT_RIGHTJUSTIFY</para>
        /// <para>Description: Right-justifies the menu item and any subsequent items. This value is valid only if the menu item is in a menu bar.</para>
        /// </summary>
        RightJustify = Help,



        MouseSelect = 0x00008000,



        End = Change,  /* Obsolete -- only used by old RES files */



        /// <summary>
        /// <para>Name: MFT_RADIOCHECK</para>
        /// <para>Description: Displays selected menu items using a radio-button mark instead of a check mark if the <see cref="MenuItemInfo.hbmpChecked"/> member is <see langword="null"/>.</para>
        /// </summary>
        RadioCheck = Delete,

        /// <summary>
        /// <para>Name: MFT_RIGHTORDER</para>
        /// <para>Description: Specifies that menus cascade right-to-left (the default is left-to-right). This is used to support right-to-left languages, such as Arabic and Hebrew.</para>
        /// </summary>
        RightOrder = SystemMenu
    }

    [Flags]
    public enum MenuStates : uint
    {
        /// <summary>
        /// <para>Name: MFS_GRAYED</para>
        /// <para>Description: Disables the menu item and grays it so that it cannot be selected. This is equivalent to <see cref="Disabled"/>.</para>
        /// </summary>
        Grayed = 0x00000003,

        /// <summary>
        /// <para>Name: MFS_DISABLED</para>
        /// <para>Description: Disables the menu item and grays it so that it cannot be selected. This is equivalent to <see cref="Grayed"/>.</para>
        /// </summary>
        Disabled = Grayed,

        /// <summary>
        /// <para>Name: MFS_CHECKED</para>
        /// <para>Description: Checks the menu item. For more information about selected menu items, see the <see cref="MenuItemInfo.hbmpChecked"/> member.</para>
        /// </summary>
        Checked = MenuFlags.Checked,

        /// <summary>
        /// <para>Name: MFS_HILITE</para>
        /// <para>Description: Highlights the menu item.</para>
        /// </summary>
        Hilite = MenuFlags.Hilite,

        /// <summary>
        /// <para>Name: MFS_ENABLED</para>
        /// <para>Description: Enables the menu item so that it can be selected. This is the default state.</para>
        /// </summary>
        Enabled = MenuFlags.Enabled,

        /// <summary>
        /// <para>Name: MFS_UNCHECKED</para>
        /// <para>Description: Unchecks the menu item. For more information about clear menu items, see the <see cref="MenuItemInfo.hbmpChecked"/> member.</para>
        /// </summary>
        Unchecked = Enabled,

        /// <summary>
        /// <para>Name: MFS_UNHILITE</para>
        /// <para>Description: Removes the highlight from the menu item. This is the default state.</para>
        /// </summary>
        Unhilite = Enabled,

        /// <summary>
        /// <para>Name: MFS_DEFAULT</para>
        /// <para>Description: Specifies that the menu item is the default. A menu can contain only one default menu item, which is displayed in bold.</para>
        /// </summary>
        Default = MenuFlags.Default
    }
}
