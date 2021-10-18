using System;

namespace Microsoft.WindowsAPICodePack.Win32Native.Menus
{
    /// <summary>
    /// Options for <see cref="Menus.TrackPopupMenu(IntPtr, TrackPopupMenuFlags, int, int, int, IntPtr, IntPtr)"/>.
    /// </summary>
    [Flags]
    public enum TrackPopupMenuFlags : uint
    {
        /// <summary>
        /// <para>Name: TPM_LEFTBUTTON</para>
        /// <para>Description: The user can select menu items with only the left mouse button.</para>
        /// </summary>
        LeftButton = 0x0000,

        /// <summary>
        /// <para>Name: TPM_RIGHTBUTTON</para>
        /// <para>Description: The user can select menu items with both the left and right mouse buttons.</para>
        /// </summary>
        RightButton = 0x0002,

        /// <summary>
        /// <para>Name: TPM_LEFTALIGN</para>
        /// <para>Description: Positions the shortcut menu so that its left side is aligned with the coordinate specified by the x parameter.</para>
        /// </summary>
        LeftAlign = LeftButton,

        /// <summary>
        /// <para>Name: TPM_CENTERALIGN</para>
        /// <para>Description: Centers the shortcut menu horizontally relative to the coordinate specified by the x parameter.</para>
        /// </summary>
        CenterAlign = 0x0004,

        /// <summary>
        /// <para>Name: TPM_RIGHTALIGN</para>
        /// <para>Description: Positions the shortcut menu so that its right side is aligned with the coordinate specified by the x parameter.</para>
        /// </summary>
        RightAlign = 0x0008,

        /// <summary>
        /// <para>Name: TPM_TOPALIGN</para>
        /// <para>Description: Positions the shortcut menu so that its top side is aligned with the coordinate specified by the y parameter.</para>
        /// </summary>
        TopAlign = LeftButton,

        /// <summary>
        /// <para>Name: TPM_VCENTERALIGN</para>
        /// <para>Description: Centers the shortcut menu vertically relative to the coordinate specified by the y parameter.</para>
        /// </summary>
        VerticalCenterAlign = 0x0010,

        /// <summary>
        /// <para>Name: TPM_BOTTOMALIGN</para>
        /// <para>Description: Positions the shortcut menu so that its bottom side is aligned with the coordinate specified by the y parameter.</para>
        /// </summary>
        BottomAlign = 0x0020,

        /// <summary>
        /// <para>Name: TPM_HORIZONTAL</para>
        /// <para>Description: If the menu cannot be shown at the specified location without overlapping the excluded rectangle, the system tries to accommodate the requested horizontal alignment before the requested vertical alignment.</para>
        /// </summary>
        Horizontal = LeftButton,  /* Horz alignment matters more */

        /// <summary>
        /// <para>Name: TPM_VERTICAL</para>
        /// <para>Description: If the menu cannot be shown at the specified location without overlapping the excluded rectangle, the system tries to accommodate the requested vertical alignment before the requested horizontal alignment.</para>
        /// </summary>
        Vertical = 0x0040,   /* Vert alignment matters more */

        /// <summary>
        /// <para>Name: TPM_NONOTIFY</para>
        /// <para>Description: The function does not send notification messages when the user clicks a menu item.</para>
        /// </summary>
        NoNotify = 0x0080,    /* Don't send any notification msgs */

        /// <summary>
        /// <para>Name: TPM_RETURNCMD</para>
        /// <para>Description: The function returns the menu item identifier of the user's selection in the return value.</para>
        /// </summary>
        ReturnCommand = 0x0100,

        /// <summary>
        /// <para>Name: TPM_RECURSE</para>
        /// <para>Description: Displays a menu when another menu is already displayed. This is intended to support context menus within a menu.</para>
        /// </summary>
        Recurse = 0x0001,

        /// <summary>
        /// <para>Name: TPM_HORPOSANIMATION</para>
        /// <para>Description: Animates the menu from left to right.</para>
        /// </summary>
        HorizontalPositionAnimation = 0x0400,

        /// <summary>
        /// <para>Name: TPM_HORNEGANIMATION</para>
        /// <para>Description: Animates the menu from right to left.</para>
        /// </summary>
        HorizontalNegativeAnimation = 0x0800,

        /// <summary>
        /// <para>Name: TPM_VERPOSANIMATION</para>
        /// <para>Description: Animates the menu from top to bottom.</para>
        /// </summary>
        VerticalPositionAnimation = 0x1000,

        /// <summary>
        /// <para>Name: TPM_VERNEGANIMATION</para>
        /// <para>Description: Animates the menu from bottom to top.</para>
        /// </summary>
        VerticalNegativeAnimation = 0x2000,

        /// <summary>
        /// <para>Name: TPM_NOANIMATION</para>
        /// <para>Description: Displays menu without animation.</para>
        /// </summary>
        NoAnimation = 0x4000,

        /// <summary>
        /// <para>Name: TPM_LAYOUTRTL</para>
        /// <para>Description: Uses right-to-left text layout. By default, the text layout is left-to-right.</para>
        /// </summary>
        LayoutRightToLeft = 0x8000,

        WorkArea = 0x10000
    }
}
