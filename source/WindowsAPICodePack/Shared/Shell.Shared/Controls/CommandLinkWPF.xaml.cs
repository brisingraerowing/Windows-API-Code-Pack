//Copyright (c) Microsoft Corporation.  All rights reserved.  Distributed under the Microsoft Public License (MS-PL)

using Microsoft.WindowsAPICodePack.Win32Native;

using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Microsoft.WindowsAPICodePack.Controls.WindowsPresentationFoundation
{
    /// <summary>
    /// Implements a CommandLink button that can be used in WPF user interfaces.
    /// </summary>
    public partial class CommandLink : UserControl, INotifyPropertyChanged
    {
        private string link;
        private string note;
        private ImageSource icon;

        /// <summary>
        /// Indicates whether this feature is supported on the current platform.
        /// </summary>
        public static bool IsPlatformSupported => CoreHelpers.RunningOnVista;

        /// <summary>
        /// Specifies the main instruction text.
        /// </summary>
        public string Link { get => link; set => UpdateValue(ref link, value, nameof(Link)); }

        /// <summary>
        /// Routed UI command to use for this button
        /// </summary>
        public RoutedUICommand Command { get; set; }

        /// <summary>
        /// Specifies the supporting note text.
        /// </summary>
        public string Note { get => note; set => UpdateValue(ref note, value, nameof(Note)); }

        /// <summary>
        /// Icon to set for the command link button
        /// </summary>
        public ImageSource Icon { get => icon; set => UpdateValue(ref icon, value, nameof(Icon)); }

        /// <summary>
        /// Indicates if the button is in a checked state
        /// </summary>
        public bool? IsCheck { get => button.IsChecked; set => button.IsChecked = value; }

        /// <summary>
        /// Occurs when the control is clicked.
        /// </summary>
        public event RoutedEventHandler Click;

        /// <summary>
        /// Creates a new instance of this class.
        /// </summary>
        public CommandLink()
        {
            // Throw PlatformNotSupportedException if the user is not running Vista or beyond
            CoreHelpers.ThrowIfNotVista();

            DataContext = this;
            InitializeComponent();
            button.Click += new RoutedEventHandler(button_Click);
        }

        #region INotifyPropertyChanged Members
        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        private void button_Click(object sender, RoutedEventArgs e)
        {
            e.Source = this;
            Click?.Invoke(sender, e);
        }

        protected void UpdateValue<T>(ref T value, in T newValue, in PropertyChangedEventArgs e)
        {
            if (value == null)
            {
                if (newValue == null)

                    return;
            }

            else if (value.Equals(newValue))

                return;

            value = newValue;

            PropertyChanged?.Invoke(this, e);
        }

        protected void UpdateValue<T>(ref T value, in T newValue, in string propertyName) => UpdateValue(ref value, newValue, new PropertyChangedEventArgs(propertyName));
    }
}