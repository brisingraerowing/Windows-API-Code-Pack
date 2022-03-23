﻿using Microsoft.WindowsAPICodePack.Win32Native.Shell.DesktopWindowManager;

using System;
using System.Drawing;
using System.Windows.Forms;

using static Microsoft.WindowsAPICodePack.Win32Native.Shell.DesktopWindowManager.DesktopWindowManager;

namespace Microsoft.WindowsAPICodePack.Shell
{
    /// <summary>
    /// Windows Glass Form
    /// Inherit from this form to be able to enable glass on Windows Form
    /// </summary>
    public class GlassForm : Form
    {
        #region properties
        /// <summary>
        /// Get determines if AeroGlass is enabled on the desktop. Set enables/disables AreoGlass on the desktop.
        /// </summary>
        public static bool AeroGlassCompositionEnabled
        {
            get => DwmIsCompositionEnabled();

            set => DwmEnableComposition(
                    value ? CompositionEnable.Enable : CompositionEnable.Disable);
        }
        #endregion

        #region events
        /// <summary>
        /// Fires when the availability of Glass effect changes.
        /// </summary>
        public event EventHandler<AeroGlassCompositionChangedEventArgs> AeroGlassCompositionChanged;
        #endregion

        #region operations
        /// <summary>
        /// Makes the background of current window transparent
        /// </summary>
        public void SetAeroGlassTransparency() => BackColor = Color.Transparent;

        /// <summary>
        /// Excludes a Control from the AeroGlass frame.
        /// </summary>
        /// <param name="control">The control to exclude.</param>
        /// <remarks>Many non-WPF rendered controls (i.e., the ExplorerBrowser control) will not 
        /// render properly on top of an AeroGlass frame. </remarks>
        public void ExcludeControlFromAeroGlass(Control control)
        {
            if (control == null) throw new ArgumentNullException(nameof(control));

            if (AeroGlassCompositionEnabled)
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
        #endregion

        #region implementation
        /// <summary>
        /// Catches the DWM messages to this window and fires the appropriate event.
        /// </summary>
        /// <param name="m"></param>

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == (int)WindowMessage.DWMCompositionChanged
                || m.Msg == (int)WindowMessage.DWMNCRenderingChanged)

                if (AeroGlassCompositionChanged != null)

                    AeroGlassCompositionChanged.Invoke(this,
                        new AeroGlassCompositionChangedEventArgs(AeroGlassCompositionEnabled));

            base.WndProc(ref m);
        }

        /// <summary>
        /// Initializes the Form for AeroGlass
        /// </summary>
        /// <param name="e">The arguments for this event</param>
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

            if (DesignMode == false)

                if (AeroGlassCompositionEnabled)

                    // Paint the all the regions black to enable glass
                    e?.Graphics.FillRectangle(Brushes.Black, ClientRectangle);

        }
        #endregion
    }
}
