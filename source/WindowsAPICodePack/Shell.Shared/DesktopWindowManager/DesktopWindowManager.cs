using Microsoft.WindowsAPICodePack.Win32Native.Shell;
using Microsoft.WindowsAPICodePack.Win32Native.Shell.DesktopWindowManager;

using System;
using System.Diagnostics;
using System.Windows.Interop;

using static Microsoft.WindowsAPICodePack.Win32Native.Menus.MenuFlags;
using static Microsoft.WindowsAPICodePack.Win32Native.Menus.Menus;
using static Microsoft.WindowsAPICodePack.Win32Native.Shell.DesktopWindowManager.HandlerNativeMethods;
using static Microsoft.WindowsAPICodePack.Win32Native.Shell.DesktopWindowManager.SystemMenuCommands;

using static System.Runtime.InteropServices.Marshal;

namespace Microsoft.WindowsAPICodePack.Shell
{
    public static class DesktopWindowManager
    {
        public static bool EnableCloseMenuItemFromMenuHandle(in IntPtr hMenu) => EnableMenuItemByCommand(hMenu, Close, Enabled);

        public static bool EnableCloseMenuItemFromWindowHandle(in IntPtr hwnd)
        {
            IntPtr hMenu = Win32Native.Shell.DesktopWindowManager.DesktopWindowManager.GetSystemMenu(hwnd, false);

            return hMenu != IntPtr.Zero && EnableCloseMenuItemFromMenuHandle(hMenu);
        }

        public static bool EnableCloseMenuItem(in System.Windows.Forms.Form form) => EnableCloseMenuItemFromWindowHandle(form.Handle);

        public static bool EnableCloseMenuItem(in System.Windows.Window window) => EnableCloseMenuItemFromWindowHandle(new WindowInteropHelper(window).Handle);

        public static bool DisableCloseMenuItemFromMenuHandle(in IntPtr hMenu) => EnableMenuItemByCommand(hMenu, Close, Grayed);

        public static bool DisableCloseMenuItemFromWindowHandle(in IntPtr hwnd)
        {
            IntPtr hMenu = Win32Native.Shell.DesktopWindowManager.DesktopWindowManager.GetSystemMenu(hwnd, false);

            return hMenu != IntPtr.Zero && DisableCloseMenuItemFromMenuHandle(hMenu);
        }

        public static bool DisableCloseMenuItem(in System.Windows.Forms.Form form) => DisableCloseMenuItemFromWindowHandle(form.Handle);

        public static bool DisableCloseMenuItem(in System.Windows.Window window) => DisableCloseMenuItemFromWindowHandle(new WindowInteropHelper(window).Handle);

        /// <summary>
        /// Retrieves information about the specified window. The function also retrieves the value at a specified offset into the extra window memory.
        /// </summary>
        /// <param name="hwnd">A handle to the window and, indirectly, the class to which the window belongs.</param>
        /// <returns>
        /// <para>If the function succeeds, the return value is the requested value.</para>
        /// <para>If the function fails, the return value is zero. To get extended error information, call <see cref="GetLastWin32Error"/>.</para>
        /// <para>If <see cref="SetWindowStyles(IntPtr,  WindowStyles)"/> has not been called previously, <see cref="GetWindowLongPtr(IntPtr, GetWindowLongEnum)"/> returns zero for values in the extra window or class memory.</para>
        /// </returns>
        public static WindowStyles GetWindowStyles(IntPtr hwnd
#if WAPICP3
            , GetWindowLongEnum getWindowLongEnum
#endif
            )
        {
#if WAPICP3
            long
#else
int
#endif
          result = GetWindowLongPtr(hwnd,
#if WAPICP3
          getWindowLongEnum
#else
          GetWindowLongEnum.Style
#endif
          );

            if (result == 0)

                ThrowExceptionForHR(GetHRForLastWin32Error());

            return (WindowStyles)result;
        }

#if !WAPICP3
        [Obsolete("Use GetWindowStyles instead.")]
        public static WindowStylesEx GetWindowStylesEx(IntPtr hwnd)
        {
            int result = GetWindowLongPtr(hwnd, GetWindowLongEnum.ExStyle);

            if (result == 0)

                ThrowExceptionForHR(GetHRForLastWin32Error());

            return (WindowStylesEx)result;
        }
        
        [Obsolete("Use GetWindowStyles instead.")]
        public static void SetWindowStylesEx(IntPtr hwnd, WindowStylesEx styles)
        {
            if (SetWindowLongPtr(hwnd, GetWindowLongEnum.ExStyle, (int)styles) == 0)

                ThrowExceptionForHR(GetHRForLastWin32Error());
        }
#endif

        public static void SetWindowStyles(IntPtr hwnd, WindowStyles styles
#if WAPICP3
            , GetWindowLongEnum getWindowLongEnum
#endif
          )
        {
            if (SetWindowLongPtr(hwnd,
#if WAPICP3
          getWindowLongEnum
#else
          GetWindowLongEnum.Style
#endif
          ,
#if WAPICP3
(long)
#else
                (int)
#endif
                styles) == 0)

                ThrowExceptionForHR(GetHRForLastWin32Error());
        }

        public static void SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int x, int y, int cx, int cy, SetWindowPositionOptions windowPositionOptions)
        {
            if (!HandlerNativeMethods.SetWindowPos(hWnd, hWndInsertAfter, x, y, cx, cy, windowPositionOptions))

                ThrowExceptionForHR(GetHRForLastWin32Error());
        }

        public static void SetWindow(IntPtr hWnd, IntPtr hWndInsertAfter, int x, int y, int cx, int cy, WindowStyles styles,
#if WAPICP3
            WindowStyles
#else
            WindowStylesEx 
#endif
            stylesEx, SetWindowPositionOptions windowPositionOptions)
        {
            SetWindowStyles(hWnd, styles
#if WAPICP3
                , GetWindowLongEnum.Style
#endif
                );
#if WAPICP3
            SetWindowStyles
#else
            SetWindowStylesEx
#endif
                (hWnd, stylesEx
#if WAPICP3
                , GetWindowLongEnum.ExStyle
#endif
                );

            SetWindowPos(hWnd, hWndInsertAfter, x, y, cx, cy, windowPositionOptions);
        }

        public static bool IsOnForeground(IntPtr hWnd)
        {
            IntPtr activatedHandle = HandlerNativeMethods.GetForegroundWindow();

            return  activatedHandle != IntPtr.Zero && activatedHandle == hWnd;
        }

        // TODO: also return the int given by HandlerNativeMethods.GetWindowThreadProcessId?
        public static int GetWindowThreadProcessId(IntPtr activatedHandle)
        {
            _ = HandlerNativeMethods.GetWindowThreadProcessId(activatedHandle, out int activeProcId);

            return activeProcId;
        }

        // TODO: should HandlerNativeMethods.GetForegroundWindow() be used directly?
        public static IntPtr GetForegroundWindow() => HandlerNativeMethods.GetForegroundWindow();

        public static bool AreAnyCurrentThreadWindowOnForeground()
        {
            IntPtr activatedHandle = GetForegroundWindow();

            if (activatedHandle == null || activatedHandle == IntPtr.Zero) return false;

            int procId = Process.GetCurrentProcess().Id;

            return GetWindowThreadProcessId(activatedHandle) == procId;
        }

        public static System.Drawing.Point GetParentOffsetOfChild(IntPtr hwnd, IntPtr hwndParent)
        {
            var childScreenCoord = new NativePoint();

            _ = ClientToScreen(hwnd, ref childScreenCoord);

            var parentScreenCoord = new NativePoint();

            _ = ClientToScreen(hwndParent, ref parentScreenCoord);

            var offset = new System.Drawing.Point(
                childScreenCoord.X - parentScreenCoord.X,
                childScreenCoord.Y - parentScreenCoord.Y);

            return offset;
        }

        public static System.Drawing.Size GetNonClientArea(IntPtr hwnd)
        {
            var c = new NativePoint();

            _ = ClientToScreen(hwnd, ref c);

            _ = GetWindowRect(hwnd, out NativeRect r);

            return new System.Drawing.Size(c.X - r.Left, c.Y - r.Top);
        }
    }

    [Flags]
    public enum WindowStyles
#if WAPICP3
        : long
    {
        /// <summary>
        /// <para>Name: WS_OVERLAPPED</para>
        /// <para>Description: The window is an overlapped window. An overlapped window has a title bar and a border. Same as the <see cref="Tiled"/> style.</para>
        /// </summary>
        Overlapped = 0x00000000,

        /// <summary>
        /// <para>Name: WS_TILED</para>
        /// <para>Description: The window is an overlapped window. An overlapped window has a title bar and a border. Same as the <see cref="Overlapped"/> style.</para>
        /// </summary>
        Tiled = Overlapped,

        /// <summary>
        /// <para>Name: WS_POPUP</para>
        /// <para>Description: The window is a pop-up window. This style cannot be used with the <see cref="Child"/> style.</para>
        /// </summary>
        Popup = 0x80000000,

        /// <summary>
        /// <para>Name: WS_CHILD</para>
        /// <para>Description: The window is a child window. A window with this style cannot have a menu bar. This style cannot be used with the <see cref="Popup"/> style.</para>
        /// </summary>
        Child = 0x40000000,

        /// <summary>
        /// <para>Name: WS_MINIMIZE</para>
        /// <para>Description: The window is initially minimized. Same as the <see cref="Iconic"/> style.</para>
        /// </summary>
        Minimize = 0x20000000,

        /// <summary>
        /// <para>Name: WS_ICONIC</para>
        /// <para>Description: The window is initially minimized. Same as the <see cref="Minimize"/> style.</para>
        /// </summary>
        Iconic = Minimize,

        /// <summary>
        /// <para>Name: WS_VISIBLE</para>
        /// <para>Description: The window is initially visible. This style can be turned on and off by using the ShowWindow or <see cref="SetWindowPos"/> function.</para>
        /// </summary>
        Visible = 0x10000000,

        /// <summary>
        /// <para>Name: WS_DISABLED</para>
        /// <para>Description: The window is initially disabled. A disabled window cannot receive input from the user. To change this after a window has been created, use the EnableWindow function.</para>
        /// </summary>
        Disabled = 0x08000000,

        /// <summary>
        /// <para>Name: WS_CLIPSIBLINGS</para>
        /// <para>Description: Clips child windows relative to each other; that is, when a particular child window receives a <see cref="WindowMessage.Paint"/> message, the <see cref="ClipSiblings"/> style clips all other overlapping child windows out of the region of the child window to be updated. If <see cref="ClipSiblings"/> is not specified and child windows overlap, it is possible, when drawing within the client area of a child window, to draw within the client area of a neighboring child window.</para>
        /// </summary>
        ClipSiblings = 0x04000000,

        /// <summary>
        /// <para>Name: WS_CLIPCHILDREN</para>
        /// <para>Description: Excludes the area occupied by child windows when drawing occurs within the parent window. This style is used when creating the parent window.</para>
        /// </summary>
        ClipChildren = 0x02000000,

        /// <summary>
        /// <para>Name: WS_MAXIMIZE</para>
        /// <para>Description: The window is initially maximized.</para>
        /// </summary>
        Maximize = 0x01000000,

        /// <summary>
        /// <para>Name: WS_CAPTION</para>
        /// <para>Description: The window has a title bar (includes the <see cref="Border"/> style).</para>
        /// </summary>
        Caption = Border | DialogFrame,

        /// <summary>
        /// <para>Name: WS_BORDER</para>
        /// <para>Description: The window has a thin-line border.</para>
        /// </summary>
        Border = 0x00800000,

        /// <summary>
        /// <para>Name: WS_DLGFRAME</para>
        /// <para>Description: The window has a border of a style typically used with dialog boxes. A window with this style cannot have a title bar.</para>
        /// </summary>
        DialogFrame = 0x00400000,

        /// <summary>
        /// <para>Name: WS_VSCROLL</para>
        /// <para>Description: The window has a vertical scroll bar.</para>
        /// </summary>
        VerticalScrollBar = 0x00200000,

        /// <summary>
        /// <para>Name: WS_HSCROLL</para>
        /// <para>Description: The window has a horizontal scroll bar.</para>
        /// </summary>
        HorizontalScrollBar = 0x00100000,

        /// <summary>
        /// <para>Name: WS_SYSMENU</para>
        /// <para>Description: The window has a window menu on its title bar. The <see cref="Caption"/> style must also be specified.</para>
        /// </summary>
        SystemMenu = 0x00080000,

        /// <summary>
        /// <para>Name: WS_THICKFRAME</para>
        /// <para>Description: The window has a sizing border. Same as the <see cref="SizeBox"/> style.</para>
        /// </summary>
        ThickFrame = 0x00040000,

        /// <summary>
        /// <para>Name: WS_SIZEBOX</para>
        /// <para>Description: The window has a sizing border. Same as the <see cref="ThickFrame"/> style.</para>
        /// </summary>
        SizeBox = ThickFrame,

        /// <summary>
        /// <para>Name: WS_GROUP</para>
        /// <para>Description: The window is the first control of a group of controls. The group consists of this first control and all controls defined after it, up to the next control with the <see cref="Group"/> style. The first control in each group usually has the <see cref="TabStop"/> style so that the user can move from group to group. The user can subsequently change the keyboard focus from one control in the group to the next control in the group by using the direction keys. You can turn this style on and off to change dialog box navigation. To change this style after a window has been created, use the <see cref="SetWindowLongPtr(IntPtr, GetWindowLongEnum, long)"/> function.</para>
        /// </summary>
        Group = 0x00020000,

        /// <summary>
        /// <para>Name: WS_TABSTOP</para>
        /// <para>Description: The window is a control that can receive the keyboard focus when the user presses the TAB key. Pressing the TAB key changes the keyboard focus to the next control with the <see cref="TabStop"/> style. You can turn this style on and off to change dialog box navigation. To change this style after a window has been created, use the <see cref="SetWindowLongPtr(IntPtr, GetWindowLongEnum, long)"/> function. For user-created windows and modeless dialogs to work with tab stops, alter the message loop to call the IsDialogMessage function.</para>
        /// </summary>
        TabStop = 0x00010000,



        /// <summary>
        /// <para>Name: WS_MINIMIZEBOX</para>
        /// <para>Description: The window has a minimize button. Cannot be combined with the <see cref="ContextHelp"/> style. The <see cref="SystemMenu"/> style must also be specified.</para>
        /// </summary>
        MinimizeBox = Group,

        /// <summary>
        /// <para>Name: WS_MAXIMIZEBOX</para>
        /// <para>Description: The window has a maximize button. Cannot be combined with the <see cref="ContextHelp"/> style. The <see cref="SystemMenu"/> style must also be specified. </para>
        /// </summary>
        MaximizeBox = TabStop,

        /// <summary>
        /// <para>Name: WS_TILEDWINDOW</para>
        /// <para>Description: The window is an overlapped window. Same as the <see cref="OverlappedWindow"/> style.</para>
        /// </summary>
        TiledWindow = OverlappedWindow,

        /// <summary>
        /// <para>Name: WS_OVERLAPPEDWINDOW</para>
        /// <para>Description: The window is an overlapped window. Same as the <see cref="TiledWindow"/> style. </para>
        /// </summary>
        OverlappedWindow = Overlapped | Caption | SystemMenu | ThickFrame | MinimizeBox | MaximizeBox,

        /// <summary>
        /// <para>Name: WS_POPUPWINDOW</para>
        /// <para>Description: The window is a pop-up window. The <see cref="Caption"/> and <see cref="PopupWindow"/> styles must be combined to make the window menu visible.</para>
        /// </summary>
        PopupWindow = Popup | Border | SystemMenu,

        /// <summary>
        /// <para>Name: WS_CHILDWINDOW</para>
        /// <para>Description: Same as the <see cref="Child"/> style.</para>
        /// </summary>
        ChildWindow = Child,



        /// <summary>
        /// <para>Name: WS_EX_DLGMODALFRAME</para>
        /// <para>Description: The window has a double border; the window can, optionally, be created with a title bar by specifying the <see cref="Caption"/> style in the dwStyle parameter.</para>
        /// </summary>
        DialogModalFrame = 0x00000001,

        /// <summary>
        /// <para>Name: WS_EX_NOPARENTNOTIFY</para>
        /// <para>Description: The child window created with this style does not send the <see cref="WindowMessage.ParentNotify"/> message to its parent window when it is created or destroyed.</para>
        /// </summary>
        NoParentNotify = 0x00000004,

        /// <summary>
        /// <para>Name: WS_EX_TOPMOST</para>
        /// <para>Description: The window should be placed above all non-topmost windows and should stay above them, even when the window is deactivated. To add or remove this style, use the <see cref="SetWindowPos(IntPtr, IntPtr, int, int, int, int, SetWindowPositionOptions)"/> function.</para>
        /// </summary>
        TopMost = 0x00000008,

        /// <summary>
        /// <para>Name: WS_EX_ACCEPTFILES</para>
        /// <para>Description: The window accepts drag-drop files.</para>
        /// </summary>
        AcceptFiles = 0x00000010,

        /// <summary>
        /// <para>Name: WS_EX_TRANSPARENT</para>
        /// <para>Description: The window should not be painted until siblings beneath the window (that were created by the same thread) have been painted. The window appears transparent because the bits of underlying sibling windows have already been painted. To achieve transparency without these restrictions, use the SetWindowRgn function.</para>
        /// </summary>
        Transparent = 0x00000020,



        /// <summary>
        /// <para>Name: WS_EX_MDICHILD</para>
        /// <para>Description: The window is a MDI child window.</para>
        /// </summary>
        MDIChild = 0x00000040,

        /// <summary>
        /// <para>Name: WS_EX_TOOLWINDOW</para>
        /// <para>Description: The window is intended to be used as a floating toolbar. A tool window has a title bar that is shorter than a normal title bar, and the window title is drawn using a smaller font. A tool window does not appear in the taskbar or in the dialog that appears when the user presses ALT+TAB. If a tool window has a system menu, its icon is not displayed on the title bar. However, you can display the system menu by right-clicking or by typing ALT+SPACE.</para>
        /// </summary>
        ToolWindow = 0x00000080,

        /// <summary>
        /// <para>Name: WS_EX_WINDOWEDGE</para>
        /// <para>Description: The window has a border with a raised edge.</para>
        /// </summary>
        WindowEdge = 0x00000100,

        /// <summary>
        /// <para>Name: WS_EX_CLIENTEDGE</para>
        /// <para>Description: The window has a border with a sunken edge.</para>
        /// </summary>
        ClientEdge = 0x00000200,

        /// <summary>
        /// <para>Name: WS_EX_CONTEXTHELP</para>
        /// <para>Description: The title bar of the window includes a question mark. When the user clicks the question mark, the cursor changes to a question mark with a pointer. If the user then clicks a child window, the child receives a <see cref="WindowMessage.Help"/> message. The child window should pass the message to the parent window procedure, which should call the WinHelp function using the HELP_WM_HELP command. The Help application displays a pop-up window that typically contains help for the child window. <see cref="ContextHelp"/> cannot be used with the <see cref="MaximizeBox"/> or <see cref="MinimizeBox"/> styles.</para>
        /// </summary>
        ContextHelp = 0x00000400,



        /// <summary>
        /// <para>Name: WS_EX_RIGHT</para>
        /// <para>Description: 	The window has generic "right-aligned" properties. This depends on the window class. This style has an effect only if the shell language is Hebrew, Arabic, or another language that supports reading-order alignment; otherwise, the style is ignored. Using the <see cref="Right"/> style for static or edit controls has the same effect as using the SS_RIGHT or ES_RIGHT style, respectively. Using this style with button controls has the same effect as using BS_RIGHT and BS_RIGHTBUTTON styles.</para>
        /// </summary>
        Right = 0x00001000,

        /// <summary>
        /// <para>Name: WS_EX_LEFT</para>
        /// <para>Description: The window has generic left-aligned properties. This is the default.</para>
        /// </summary>
        Left = Overlapped,

        /// <summary>
        /// <para>Name: WS_EX_RTLREADING</para>
        /// <para>Description: If the shell language is Hebrew, Arabic, or another language that supports reading-order alignment, the window text is displayed using right-to-left reading-order properties. For other languages, the style is ignored.</para>
        /// </summary>
        RTLReading = 0x00002000,

        /// <summary>
        /// <para>Name: WS_EX_LTRREADING</para>
        /// <para>Description: The window text is displayed using left-to-right reading-order properties. This is the default.</para>
        /// </summary>
        LTRReading = Overlapped,

        /// <summary>
        /// <para>Name: WS_EX_LEFTSCROLLBAR</para>
        /// <para>Description: If the shell language is Hebrew, Arabic, or another language that supports reading order alignment, the vertical scroll bar (if present) is to the left of the client area. For other languages, the style is ignored.</para>
        /// </summary>
        LeftScrollBar = 0x00004000,

        /// <summary>
        /// <para>Name: WS_EX_RIGHTSCROLLBAR</para>
        /// <para>Description: The vertical scroll bar (if present) is to the right of the client area. This is the default.</para>
        /// </summary>
        RightScrollBar = Overlapped,

        /// <summary>
        /// <para>Name: WS_EX_CONTROLPARENT</para>
        /// <para>Description: The window itself contains child windows that should take part in dialog box navigation. If this style is specified, the dialog manager recurses into children of this window when performing navigation operations such as handling the TAB key, an arrow key, or a keyboard mnemonic.</para>
        /// </summary>
        ControlParent = TabStop,

        /// <summary>
        /// <para>Name: WS_EX_STATICEDGE</para>
        /// <para>Description: The window has a three-dimensional border style intended to be used for items that do not accept user input.</para>
        /// </summary>
        StaticEdge = Group,

        /// <summary>
        /// <para>Name: WS_EX_APPWINDOW</para>
        /// <para>Description: Forces a top-level window onto the taskbar when the window is visible.</para>
        /// </summary>
        AppWindow = ThickFrame,



        /// <summary>
        /// <para>Name: WS_EX_OVERLAPPEDWINDOW</para>
        /// <para>Description: The window is an overlapped window.</para>
        /// </summary>
        OverlappedWindowEx = WindowEdge | ClientEdge,

        /// <summary>
        /// <para>Name: WS_EX_PALETTEWINDOW</para>
        /// <para>Description: The window is palette window, which is a modeless dialog box that presents an array of commands.</para>
        /// </summary>
        PaletteWindow = WindowEdge | ToolWindow | TopMost,



        /// <summary>
        /// <para>Name: WS_EX_LAYERED</para>
        /// <para>Description: The window is a layered window. This style cannot be used if the window has a class style of either CS_OWNDC or CS_CLASSDC. Windows 8: The <see cref="Layered"/> style is supported for top-level windows and child windows. Previous Windows versions support <see cref="Layered"/> only for top-level windows.</para>
        /// </summary>
        Layered = SystemMenu,

        /// <summary>
        /// <para>Name: WS_EX_NOINHERITLAYOUT</para>
        /// <para>Description: The window does not pass its window layout to its child windows.</para>
        /// </summary>
        NoInheritLayout = HorizontalScrollBar, // Disable inheritence of mirroring by children

        /// <summary>
        /// <para>Name: WS_EX_NOREDIRECTIONBITMAP</para>
        /// <para>Description: The window does not render to a redirection surface. This is for windows that do not have visible content or that use mechanisms other than surfaces to provide their visual.</para>
        /// </summary>
        NoRedirectionBitmap = VerticalScrollBar,

        /// <summary>
        /// <para>Name: WS_EX_LAYOUTRTL</para>
        /// <para>Description: If the shell language is Hebrew, Arabic, or another language that supports reading order alignment, the horizontal origin of the window is on the right edge. Increasing horizontal values advance to the left.</para>
        /// </summary>
        LayoutRTL = DialogFrame, // Right to left mirroring

        /// <summary>
        /// <para>Name: WS_EX_COMPOSITED</para>
        /// <para>Description: Paints all descendants of a window in bottom-to-top painting order using double-buffering. Bottom-to-top painting order allows a descendent window to have translucency (alpha) and transparency (color-key) effects, but only if the descendent window also has the <see cref="Transparent"/> bit set. Double-buffering allows the window and its descendents to be painted without flicker. This cannot be used if the window has a class style of either CS_OWNDC or CS_CLASSDC. Windows 2000: This style is not supported.</para>
        /// </summary>
        Composited = ClipChildren,

        /// <summary>
        /// <para>Name: WS_EX_NOACTIVATE</para>
        /// <para>Description: A top-level window created with this style does not become the foreground window when the user clicks it. The system does not bring this window to the foreground when the user minimizes or closes the foreground window. The window should not be activated through programmatic access or via keyboard navigation by accessible technology, such as Narrator. To activate the window, use the SetActiveWindow or SetForegroundWindow function. The window does not appear on the taskbar by default. To force the window to appear on the taskbar, use the <see cref="AppWindow"/> style.</para>
        /// </summary>
        NoActivate = Disabled
    }

    [Flags]
    public enum CommonWindowStyles : long
    {
        OverlappedWindow = WindowStyles.OverlappedWindow,

        PopupWindow = WindowStyles.PopupWindow,

        ChildWindow = WindowStyles.ChildWindow
    }

    [Flags]
    public enum ExtendedWindowStyles
    {
        /// <summary>
        /// See <see cref="WindowStyles.DialogModalFrame"/>
        /// </summary>
        DialogModalFrame = (int)WindowStyles.DialogModalFrame,

        /// <summary>
        /// See <see cref="WindowStyles.NoParentNotify"/>
        /// </summary>
        NoParentNotify = (int)WindowStyles.NoParentNotify,

        /// <summary>
        /// See <see cref="WindowStyles.TopMost"/>
        /// </summary>
        TopMost = (int)WindowStyles.TopMost,

        /// <summary>
        /// See <see cref="WindowStyles.AcceptFiles"/>
        /// </summary>
        AcceptFiles = (int)WindowStyles.AcceptFiles,

        /// <summary>
        /// See <see cref="WindowStyles.Transparent"/>
        /// </summary>
        Transparent = (int)WindowStyles.Transparent,



        /// <summary>
        /// See <see cref="WindowStyles.MDIChild"/>
        /// </summary>
        MDIChild = (int)WindowStyles.MDIChild,

        /// <summary>
        /// See <see cref="WindowStyles.ToolWindow"/>
        /// </summary>
        ToolWindow = (int)WindowStyles.ToolWindow,

        /// <summary>
        /// See <see cref="WindowStyles.WindowEdge"/>
        /// </summary>
        WindowEdge = (int)WindowStyles.WindowEdge,

        /// <summary>
        /// See <see cref="WindowStyles.ClientEdge"/>
        /// </summary>
        ClientEdge = (int)WindowStyles.ClientEdge,

        /// <summary>
        /// See <see cref="WindowStyles.ContextHelp"/>
        /// </summary>
        ContextHelp = (int)WindowStyles.ContextHelp,



        /// <summary>
        /// See <see cref="WindowStyles.Right"/>
        /// </summary>
        Right = (int)WindowStyles.Right,

        /// <summary>
        /// See <see cref="WindowStyles.Left"/>
        /// </summary>
        Left = (int)WindowStyles.Left,

        /// <summary>
        /// See <see cref="WindowStyles.RTLReading"/>
        /// </summary>
        RTLReading = (int)WindowStyles.RTLReading,

        /// <summary>
        /// See <see cref="WindowStyles.LTRReading"/>
        /// </summary>
        LTRReading = Left,

        /// <summary>
        /// See <see cref="WindowStyles.LeftScrollBar"/>
        /// </summary>
        LeftScrollBar = (int)WindowStyles.LeftScrollBar,

        /// <summary>
        /// See <see cref="WindowStyles.RightScrollBar"/>
        /// </summary>
        RightScrollBar = Left,

        /// <summary>
        /// See <see cref="WindowStyles.ControlParent"/>
        /// </summary>
        ControlParent = (int)WindowStyles.ControlParent,

        /// <summary>
        /// See <see cref="WindowStyles.StaticEdge"/>
        /// </summary>
        StaticEdge = (int)WindowStyles.StaticEdge,

        /// <summary>
        /// See <see cref="WindowStyles.AppWindow"/>
        /// </summary>
        AppWindow = (int)WindowStyles.AppWindow,



        /// <summary>
        /// See <see cref="WindowStyles.OverlappedWindowEx"/>
        /// </summary>
        OverlappedWindowEx = (int)WindowStyles.OverlappedWindowEx,

        /// <summary>
        /// See <see cref="WindowStyles.PaletteWindow"/>
        /// </summary>
        PaletteWindow = (int)WindowStyles.PaletteWindow,



        /// <summary>
        /// See <see cref="WindowStyles.Layered"/>
        /// </summary>
        Layered = (int)WindowStyles.Layered,

        /// <summary>
        /// See <see cref="WindowStyles.NoInheritLayout"/>
        /// </summary>
        NoInheritLayout = (int)WindowStyles.NoInheritLayout, // Disable inheritence of mirroring by children

        /// <summary>
        /// See <see cref="WindowStyles.NoRedirectionBitmap"/>
        /// </summary>
        NoRedirectionBitmap = (int)WindowStyles.NoRedirectionBitmap,

        /// <summary>
        /// See <see cref="WindowStyles.LayoutRTL"/>
        /// </summary>
        LayoutRTL = (int)WindowStyles.LayoutRTL, // Right to left mirroring

        /// <summary>
        /// See <see cref="WindowStyles.Composited"/>
        /// </summary>
        Composited = (int)WindowStyles.Composited,

        /// <summary>
        /// See <see cref="WindowStyles.NoActivate"/>
        /// </summary>
        NoActivate = (int)WindowStyles.NoActivate
#else
    {
        /// <summary>
        /// The window has a thin-line border.
        /// </summary>
        Border = 0x00800000,

        /// <summary>
        /// The window has a title bar (includes the WS_BORDER style).
        /// </summary>
        Caption = 0x00C00000,

        /// <summary>
        /// The window is a child window. 
        /// A window with this style cannot have a menu bar. 
        /// This style cannot be used with the WS_POPUP style.
        /// </summary>
        Child = 0x40000000,

        /// <summary>
        /// Same as the WS_CHILD style.
        /// </summary>
        ChildWindow = 0x40000000,

        /// <summary>
        /// Excludes the area occupied by child windows when drawing occurs within the parent window. 
        /// This style is used when creating the parent window.
        /// </summary>
        ClipChildren = 0x02000000,

        /// <summary>
        /// Clips child windows relative to each other; 
        /// that is, when a particular child window receives a WM_PAINT message, 
        /// the WS_CLIPSIBLINGS style clips all other overlapping child windows out of the region of the child window to be updated. 
        /// If WS_CLIPSIBLINGS is not specified and child windows overlap, it is possible, 
        /// when drawing within the client area of a child window, to draw within the client area of a neighboring child window.
        /// </summary>
        ClipSiblings = 0x04000000,

        /// <summary>
        /// The window is initially disabled. A disabled window cannot receive input from the user. 
        /// To change this after a window has been created, use the EnableWindow function.
        /// </summary>
        Disabled = 0x08000000,

        /// <summary>
        /// The window has a border of a style typically used with dialog boxes. 
        /// A window with this style cannot have a title bar.
        /// </summary>
        DialogFrame = 0x0040000,

        /// <summary>
        /// The window is the first control of a group of controls. 
        /// The group consists of this first control and all controls defined after it, up to the next control with the WS_GROUP style. 
        /// The first control in each group usually has the WS_TABSTOP style so that the user can move from group to group. 
        /// The user can subsequently change the keyboard focus from one control in the group to the next control 
        /// in the group by using the direction keys.
        /// 
        /// You can turn this style on and off to change dialog box navigation. 
        /// To change this style after a window has been created, use the SetWindowLong function.
        /// </summary>
        Group = 0x00020000,

        /// <summary>
        /// The window has a horizontal scroll bar.
        /// </summary>
        HorizontalScroll = 0x00100000,

        /// <summary>
        /// The window is initially minimized. 
        /// Same as the WS_MINIMIZE style.
        /// </summary>
        Iconic = 0x20000000,

        /// <summary>
        /// The window is initially maximized.
        /// </summary>
        Maximize = 0x01000000,

        /// <summary>
        /// The window has a maximize button. 
        /// Cannot be combined with the WS_EX_CONTEXTHELP style. 
        /// The WS_SYSMENU style must also be specifie
        /// </summary>
        MaximizeBox = 0x00010000,

        /// <summary>
        /// The window is initially minimized. 
        /// Same as the WS_ICONIC style.
        /// </summary>
        Minimize = 0x20000000,

        /// <summary>
        /// The window has a minimize button. 
        /// Cannot be combined with the WS_EX_CONTEXTHELP style. 
        /// The WS_SYSMENU style must also be specified.
        /// </summary>
        MinimizeBox = 0x00020000,

        /// <summary>
        /// The window is an overlapped window. 
        /// An overlapped window has a title bar and a border. 
        /// Same as the WS_TILED style.
        /// </summary>
        Overlapped = 0x00000000,

        /// <summary>
        /// The windows is a pop-up window. 
        /// This style cannot be used with the WS_CHILD style.
        /// </summary>
        Popup = unchecked((int)0x80000000),

        /// <summary>
        /// The window has a sizing border. 
        /// Same as the WS_THICKFRAME style.
        /// </summary>
        SizeBox = 0x00040000,

        /// <summary>
        /// The window has a window menu on its title bar. 
        /// The WS_CAPTION style must also be specified.
        /// </summary>
        SystemMenu = 0x00080000,

        /// <summary>
        /// The window is a control that can receive the keyboard focus when the user presses the TAB key. 
        /// Pressing the TAB key changes the keyboard focus to the next control with the WS_TABSTOP style.
        /// 
        /// You can turn this style on and off to change dialog box navigation. 
        /// To change this style after a window has been created, use the SetWindowLong function. 
        /// For user-created windows and modeless dialogs to work with tab stops, 
        /// alter the message loop to call the IsDialogMessage function.
        /// </summary>
        Tabstop = 0x00010000,

        /// <summary>
        /// The window has a sizing border. 
        /// Same as the WS_SIZEBOX style.
        /// </summary>
        ThickFrame = 0x00040000,

        /// <summary>
        /// The window is an overlapped window. 
        /// An overlapped window has a title bar and a border. 
        /// Same as the WS_OVERLAPPED style.
        /// </summary>
        Tiled = 0x00000000,

        /// <summary>
        /// The window is initially visible.
        /// 
        /// This style can be turned on and off by using the ShowWindow or SetWindowPos function.
        /// </summary>
        Visible = 0x10000000,

        /// <summary>
        /// The window has a vertical scroll bar.
        /// </summary>
        VerticalScroll = 0x00200000,

        /// <summary>
        /// The window is an overlapped window. 
        /// Same as the WS_OVERLAPPEDWINDOW style.
        /// </summary>
        TiledWindowMask = Overlapped | Caption | SystemMenu | ThickFrame | MinimizeBox | MaximizeBox,

        /// <summary>
        /// The window is a pop-up window. 
        /// The WS_CAPTION and WS_POPUPWINDOW styles must be combined to make the window menu visible.
        /// </summary>
        PopupWindowMask = Popup | Border | SystemMenu,

        /// <summary>
        /// The window is an overlapped window. Same as the WS_TILEDWINDOW style.
        /// </summary>
        OverlappedWindowMask = Overlapped | Caption | SystemMenu | ThickFrame | MinimizeBox | MaximizeBox
#endif
    }

    [Flags, Obsolete("This enum has been replaced with WindowStyles.")]
    public enum WindowStylesEx
    {
        ContextHelp = 0x00000400
    }
}
