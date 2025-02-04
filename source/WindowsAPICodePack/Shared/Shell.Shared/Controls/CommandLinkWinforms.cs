//Copyright (c) Microsoft Corporation.  All rights reserved.  Distributed under the Microsoft Public License (MS-PL)

using Microsoft.WindowsAPICodePack.Win32Native;

using System;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;

using static Microsoft.WindowsAPICodePack.NativeAPI.Consts.Shell;
using static Microsoft.WindowsAPICodePack.NativeAPI.Consts.Shell.CommandLinkDefinitions;

namespace Microsoft.WindowsAPICodePack.Controls.WindowsForms
{
    /// <summary>
    /// Implements a CommandLink button that can be used in
    /// WinForms user interfaces.
    /// </summary>    
    public class CommandLink : Button
    {
        /// <summary>
        /// Gets a System.Windows.Forms.CreateParams on the base class when 
        /// creating a window.
        /// </summary>        
        protected override CreateParams CreateParams
        {

            get
            {
                // Add BS_COMMANDLINK style before control creation.
                CreateParams cp = base.CreateParams;

                cp.Style = AddCommandLinkStyle(cp.Style);

                return cp;
            }
        }

        // Let Windows handle the rendering.
        /// <summary>
        /// Creates a new instance of this class.
        /// </summary>
        public CommandLink()
        {
            CoreHelpers.ThrowIfNotVista();

            FlatStyle = FlatStyle.System;
        }

        // Add Design-Time Support.

        /// <summary>
        /// Increase default width.
        /// </summary>
        protected override System.Drawing.Size DefaultSize => new System.Drawing.Size(180, 60);

        /// <summary>
        /// Specifies the supporting note text
        /// </summary>
        [Category("Appearance")]
        [Description("Specifies the supporting note text.")]
        [Browsable(true)]
        [DefaultValue("(Note Text)")]
        public string NoteText { get => GetNote(this); set => SetNote(this, value); }

        /// <summary>
        /// Enable shield icon to be set at design-time.
        /// </summary>
        [Category("Appearance")]
        [Description("Indicates whether the button should be decorated with the security shield icon (Windows Vista only).")]
        [Browsable(true)]
        [DefaultValue(false)]
        public bool UseElevationIcon
        {
            get => useElevationIcon;

            set
            {
                useElevationIcon = value;
                SetShieldIcon(this, useElevationIcon);
            }
        }
        private bool useElevationIcon;


        #region Interop helpers
        private static int AddCommandLinkStyle(int style)
        {
            // Only add BS_COMMANDLINK style on Windows Vista or above.
            // Otherwise, button creation will fail.
            if (CoreHelpers.RunningOnVista)

                style |= CommandLinkDefinitions.CommandLink;

            return style;
        }

        private static string GetNote(Button Button)
        {
            IntPtr retVal = Core.SendMessage(
                Button.Handle,
                GetNoteLength,
                IntPtr.Zero,
                IntPtr.Zero);

            // Add 1 for null terminator, to get the entire string back.
            int len = ((int)retVal) + 1;
            var strBld = new StringBuilder(len);

            _ = Core.SendMessage(Button.Handle, CommandLinkDefinitions.GetNote, ref len, strBld);

            return strBld.ToString();
        }

        private static void SetNote(System.Windows.Forms.Button button, string text) =>
            // This call will be ignored on versions earlier than Windows Vista.
            Core.SendMessage(button.Handle, CommandLinkDefinitions.SetNote, 0, text);

        static internal void SetShieldIcon(Button Button, bool Show)
        {
            var fRequired = new IntPtr(Show ? 1 : 0);
            _ = Core.SendMessage(
               Button.Handle,
                SetShield,
                IntPtr.Zero,
                fRequired);
        }
        #endregion

        /// <summary>
        /// Indicates whether this feature is supported on the current platform.
        /// </summary>
        public static bool IsPlatformSupported =>
                // We need Windows Vista onwards ...
                CoreHelpers.RunningOnVista;
    }
}
