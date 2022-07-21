using Microsoft.WindowsAPICodePack.Win32Native.Shell;
using Microsoft.WindowsAPICodePack.Win32Native.Shell.DesktopWindowManager;

using System;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media;

using static Microsoft.WindowsAPICodePack.Win32Native.Shell.DesktopWindowManager.DesktopWindowManager;

namespace Microsoft.WindowsAPICodePack.Shell
{
    public class Window : System.Windows.Window
    {
        public IntPtr Handle { get; private set; }

        private static readonly DependencyPropertyKey IsSourceInitializedPropertyKey = DependencyProperty.RegisterReadOnly(nameof(IsSourceInitialized), typeof(bool), typeof(Window), new PropertyMetadata(false));

        public static readonly DependencyProperty IsSourceInitializedProperty = IsSourceInitializedPropertyKey.DependencyProperty;

        public bool IsSourceInitialized => (bool)GetValue(IsSourceInitializedProperty);

        protected virtual IntPtr OnSourceHook2(WindowMessage msg, IntPtr wParam, IntPtr lParam, out bool handled)
        {
            handled = false;

            return IntPtr.Zero;
        }

        protected virtual IntPtr OnSourceHook(WindowMessage msg, IntPtr wParam, IntPtr lParam, ref bool handled) => handled ? IntPtr.Zero : OnSourceHook2(msg, wParam, lParam, out handled);

        protected virtual void OnSourceInitialized(HwndSource hwndSource) => hwndSource.AddHook((IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled) => OnSourceHook((WindowMessage)msg, wParam, lParam, ref handled));

        protected virtual void OnSourceInitializing(EventArgs e) { /* Left empty. */ }

        /// <summary>
        /// Override SourceInitialized to initialize windowHandle for this window.
        /// A valid windowHandle is available only after the sourceInitialized is completed
        /// </summary>
        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);

            // add Window Proc hook to capture DWM messages
            OnSourceInitialized(HwndSource.FromHwnd(Handle = new WindowInteropHelper(this).Handle));

            OnSourceInitializing(e);

            SetValue(IsSourceInitializedPropertyKey, true);
        }
    }

    /// <summary>
    /// WPF Glass Window. Inherit from this window class to enable glass on a WPF window.
    /// </summary>
    public class GlassWindow : Window
    {
        #region Properties
        /// <summary>
        /// Get determines if AeroGlass is enabled on the desktop. Set enables/disables AreoGlass on the desktop.
        /// </summary>
        public static bool AeroGlassCompositionEnabled { get => DwmIsCompositionEnabled(); set => DwmEnableComposition(value ? CompositionEnable.Enable : CompositionEnable.Disable); }

        public static readonly DependencyProperty AeroGlassCompositionActivatedProperty = DependencyProperty.Register(nameof(AeroGlassCompositionActivated), typeof(bool), typeof(GlassWindow), new PropertyMetadata(false, (DependencyObject d, DependencyPropertyChangedEventArgs e) =>
        {
            var window = (GlassWindow)d;

            if (window.IsSourceInitialized)

                if ((bool)e.NewValue)

                    window.ActivateAeroGlassComposition();

                else

                    window.UpdateColors(SystemColors.WindowColor, SystemColors.WindowBrush);
        }));

        /// <summary>
        /// Get: Gets a value indicating whether the current window is displayed with an Aero background. Set: Makes the background of current window transparent from both Wpf and Windows Perspective if the value is <see langword="true"/>, otherwise resets the backgrounds to their respective system default values.
        /// </summary>
        public bool AeroGlassCompositionActivated { get => (bool)GetValue(AeroGlassCompositionActivatedProperty); set => SetValue(AeroGlassCompositionActivatedProperty, value); }
        #endregion Properties

        /// <summary>
        /// Fires when the availability of Glass effect changes.
        /// </summary>
        public event EventHandler<AeroGlassCompositionChangedEventArgs> AeroGlassCompositionChanged;

        #region Operations
        private void UpdateColors(in System.Windows.Media.Color color, in SolidColorBrush brush)
        {
            // Set the Background to transparent from Win32 perpective 
            HwndSource.FromHwnd(Handle).CompositionTarget.BackgroundColor = color;

            // Set the Background to transparent from WPF perpective 
            Background = brush;
        }

        private void ActivateAeroGlassComposition() => UpdateColors(Colors.Transparent, Brushes.Transparent);

        /// <summary>
        /// Excludes a UI element from the AeroGlass frame.
        /// </summary>
        /// <param name="element">The element to exclude.</param>
        /// <remarks>Many non-WPF rendered controls (i.e., the ExplorerBrowser control) will not 
        /// render properly on top of an AeroGlass frame. </remarks>
        public void ExcludeElementFromAeroGlass(FrameworkElement element)
        {
            if (AeroGlassCompositionEnabled && element != null)
            {
                // calculate total size of window nonclient area
                var hwndSource = PresentationSource.FromVisual(this) as HwndSource;
                _ = HandlerNativeMethods.GetWindowRect(hwndSource.Handle, out NativeRect windowRect);
                _ = HandlerNativeMethods.GetClientRect(hwndSource.Handle, out NativeRect clientRect);
                var nonClientSize = new Size(
                        windowRect.Right - windowRect.Left - (double)(clientRect.Right - clientRect.Left),
                        windowRect.Bottom - windowRect.Top - (double)(clientRect.Bottom - clientRect.Top));

                // calculate size of element relative to nonclient area
                GeneralTransform transform = element.TransformToAncestor(this);
                Point topLeftFrame = transform.Transform(new Point(0, 0));
                Point bottomRightFrame = transform.Transform(new Point(
                            element.ActualWidth + nonClientSize.Width,
                            element.ActualHeight + nonClientSize.Height));

                // Create a margin structure
                var margins = new Margins
                {
                    LeftWidth = (int)topLeftFrame.X,
                    RightWidth = (int)(ActualWidth - bottomRightFrame.X),
                    TopHeight = (int)(topLeftFrame.Y),
                    BottomHeight = (int)(ActualHeight - bottomRightFrame.Y)
                };

                // Extend the Frame into client area
                _ = DwmExtendFrameIntoClientArea(Handle, ref margins);
            }
        }

        /// <summary>
        /// Resets the AeroGlass exclusion area.
        /// </summary>
        public void ResetAeroGlass()
        {
            var margins = new Margins(true);
            _ = DwmExtendFrameIntoClientArea(Handle, ref margins);
        }
        #endregion Operations

        #region Implementation
        protected override IntPtr OnSourceHook2(WindowMessage msg, IntPtr wParam, IntPtr lParam, out bool handled)
        {
            switch (msg)
            {
                case WindowMessage.DWMCompositionChanged:
                case WindowMessage.DWMNCRenderingChanged:

                    AeroGlassCompositionChanged?.Invoke(this, new AeroGlassCompositionChangedEventArgs(AeroGlassCompositionEnabled));

                    handled = true;

                    break;

                default:

                    handled = false;

                    break;
            }

            return IntPtr.Zero;
        }

        /// <summary>
        /// OnSourceInitialized
        /// Override SourceInitialized to initialize windowHandle for this window.
        /// A valid windowHandle is available only after the sourceInitialized is completed
        /// </summary>
        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);

            ResetAeroGlass();

            if (AeroGlassCompositionActivated)

                ActivateAeroGlassComposition();
        }
        #endregion Implementation
    }
}
