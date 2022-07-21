using Microsoft.WindowsAPICodePack.Win32Native.Shell.DesktopWindowManager;

using System;
using System.Drawing;
using System.Windows.Forms;

using static Microsoft.WindowsAPICodePack.Win32Native.Shell.DesktopWindowManager.DesktopWindowManager;
using static Microsoft.WindowsAPICodePack.WindowMessage;

namespace Microsoft.WindowsAPICodePack.Shell
{
    /// <summary>
    /// Windows Glass Form. Inherit from this form to be able to enable glass on Windows Form.
    /// </summary>
    public class GlassForm : Form
    {
        /// <summary>
        /// Get determines if Aero Glass is enabled on the desktop. Set enables/disables Areo Glass on the desktop.
        /// </summary>
        public static bool AeroGlassCompositionEnabled { get => DwmIsCompositionEnabled(); set => DwmEnableComposition(value ? CompositionEnable.Enable : CompositionEnable.Disable); }

        /// <summary>
        /// Fires when the availability of Glass effect changes.
        /// </summary>
        public event EventHandler<AeroGlassCompositionChangedEventArgs> AeroGlassCompositionChanged;

        #region Operations
        /// <summary>
        /// Makes the background of current window transparent.
        /// </summary>
        public void SetAeroGlassTransparency() => BackColor = System.Drawing.Color.Transparent;

        /// <summary>
        /// Excludes a Control from the AeroGlass frame.
        /// </summary>
        /// <param name="control">The control to exclude.</param>
        /// <remarks>Many non-WPF rendered controls (i.e., the ExplorerBrowser control) will not 
        /// render properly on top of an AeroGlass frame. </remarks>
        public void ExcludeControlFromAeroGlass(Control control)
        {
            if (control == null ? throw new ArgumentNullException(nameof(control)) : AeroGlassCompositionEnabled)
            {
                Rectangle clientScreen = RectangleToScreen(ClientRectangle);
                Rectangle controlScreen = control.RectangleToScreen(control.ClientRectangle);

                var margins = new Margins
                {
                    LeftWidth = controlScreen.Left - clientScreen.Left,
                    RightWidth = clientScreen.Right - controlScreen.Right,
                    TopHeight = controlScreen.Top - clientScreen.Top,
                    BottomHeight = clientScreen.Bottom - controlScreen.Bottom
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
            if (Handle != IntPtr.Zero)
            {
                var margins = new Margins(true);
                _ = DwmExtendFrameIntoClientArea(Handle, ref margins);
            }
        }
        #endregion Operations

        #region Implementation
        /// <summary>
        /// Catches the DWM messages to this window and fires the appropriate event.
        /// </summary>
        protected override void WndProc(ref Message m)
        {
#if CS8
            static
#endif
                bool check(in Message _m, in WindowMessage msg) => _m.Msg == (int)msg;

            if (check(m, DWMCompositionChanged) || check(m, DWMNCRenderingChanged))

                AeroGlassCompositionChanged?.Invoke(this,
                    new AeroGlassCompositionChangedEventArgs(AeroGlassCompositionEnabled));

            base.WndProc(ref m);
        }

        /// <summary>
        /// Initializes the Form for AeroGlass.
        /// </summary>
        /// <param name="e">The arguments for this event.</param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            ResetAeroGlass();
        }

        /// <summary>
        /// Overide OnPaint to paint the background as black.
        /// </summary>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (!DesignMode && AeroGlassCompositionEnabled)

                // Paint the all the regions black to enable glass
                e?.Graphics.FillRectangle(Brushes.Black, ClientRectangle);

        }
        #endregion Implementation
    }
}
