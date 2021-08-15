//Copyright (c) Microsoft Corporation.  All rights reserved.  Distributed under the Microsoft Public License (MS-PL)

using Microsoft.WindowsAPICodePack.Shell.Resources;
using Microsoft.WindowsAPICodePack.Win32Native;
using Microsoft.WindowsAPICodePack.Win32Native.Shell;

using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media.Imaging;

using static Microsoft.WindowsAPICodePack.Win32Native.Shell.StockIconSize;
using static Microsoft.WindowsAPICodePack.Win32Native.Shell.StockIconsNativeMethods;

namespace Microsoft.WindowsAPICodePack.Shell
{
    /// <summary>
    /// Represents a standard system icon.
    /// </summary>
    public class StockIcon : IDisposable
    {
        #region Private Members
        private StockIconIdentifier identifier = StockIconIdentifier.Application;
        private StockIconSize currentSize = StockIconSize.Large;
        private bool linkOverlay;
        private bool selected;
        private bool invalidateIcon = true;
        private IntPtr hIcon = IntPtr.Zero;
        #endregion

        #region Public Constructors
        /// <summary>
        /// Creates a new StockIcon instance with the specified identifer, default size 
        /// and no link overlay or selected states.
        /// </summary>
        /// <param name="id">A value that identifies the icon represented by this instance.</param>
        public StockIcon(StockIconIdentifier id)
        {
            identifier = id;
            invalidateIcon = true;
        }

        /// <summary>
        /// Creates a new StockIcon instance with the specified identifer and options.
        /// </summary>
        /// <param name="id">A value that identifies the icon represented by this instance.</param>
        /// <param name="size">A value that indicates the size of the stock icon.</param>
        /// <param name="isLinkOverlay">A bool value that indicates whether the icon has a link overlay.</param>
        /// <param name="isSelected">A bool value that indicates whether the icon is in a selected state.</param>
        public StockIcon(StockIconIdentifier id, StockIconSize size, bool isLinkOverlay, bool isSelected)
        {
            identifier = id;
            linkOverlay = isLinkOverlay;
            selected = isSelected;
            currentSize = size;
            invalidateIcon = true;
        }
        #endregion

        #region Public Properties
        /// <summary>
        /// Gets or sets a value indicating whether the icon appears selected.
        /// </summary>
        /// <value>A <see cref="bool"/> value.</value>
        public bool Selected { get => selected; set => UpdateValue(ref selected, value); }

        /// <summary>
        /// Gets or sets a value that cotrols whether to put a link overlay on the icon.
        /// </summary>
        /// <value>A <see cref="bool"/> value.</value>
        public bool LinkOverlay { get => linkOverlay; set => UpdateValue(ref linkOverlay, value); }

        /// <summary>
        /// Gets or sets a value that controls the size of the Stock Icon.
        /// </summary>
        /// <value>A <see cref="StockIconSize"/> value.</value>
        public StockIconSize CurrentSize { get => currentSize; set => UpdateValue(ref currentSize, value); }

        /// <summary>
        /// Gets or sets the Stock Icon identifier associated with this icon.
        /// </summary>
        public StockIconIdentifier Identifier { get => identifier; set => UpdateValue(ref identifier, value); }

        /// <summary>
        /// Gets the icon image in <see cref="System.Drawing.Bitmap"/> format. 
        /// </summary>
        public Bitmap Bitmap
        {
            get
            {
                UpdateHIcon();

                return hIcon != IntPtr.Zero ? Bitmap.FromHicon(hIcon) : null;
            }
        }

        /// <summary>
        /// Gets the icon image in <see cref="System.Windows.Media.Imaging.BitmapSource"/> format. 
        /// </summary>
        public BitmapSource BitmapSource
        {
            get
            {
                UpdateHIcon();

                return (hIcon != IntPtr.Zero) ? Imaging.CreateBitmapSourceFromHIcon(hIcon, Int32Rect.Empty, null) : null;
            }
        }

        /// <summary>
        /// Gets the icon image in <see cref="System.Drawing.Icon"/> format.
        /// </summary>
        public Icon Icon
        {
            get
            {
                UpdateHIcon();

                return hIcon != IntPtr.Zero ? Icon.FromHandle(hIcon) : null;
            }
        }

        #endregion

        #region Private Methods
        private void UpdateValue<T>(ref T value, in T newValue)
        {
            value = newValue;

            invalidateIcon = true;
        }

        private void UpdateHIcon()
        {
            if (invalidateIcon)
            {
                if (hIcon != IntPtr.Zero)

                    _ = Core.DestroyIcon(hIcon);

                hIcon = GetHIcon();

                invalidateIcon = false;
            }
        }

        private IntPtr GetHIcon()
        {
            // Create our internal flag to pass to the native method
            StockIconsNativeMethods.StockIconOptions flags = StockIconsNativeMethods.StockIconOptions.Handle;

            // Based on the current settings, update the flags
#if CS8
            flags |= CurrentSize switch
            {
#else
            switch (CurrentSize)
            {
                case 
#endif
                Small
#if CS8
                =>
#else
                : flags |=
#endif
                StockIconOptions.Small
#if CS8
                ,
#else
                ;

                break;

                case
#endif
                ShellSize
#if CS8
                =>
#else
                : flags |=
#endif
                StockIconOptions.ShellSize
#if CS8
                ,

                _ =>
#else
                ;

                break;

                default:

                flags |=
#endif
                StockIconOptions.Large
#if CS8
            };
#else
                ;

                break;
            }
#endif

            if (Selected)

                flags |= StockIconOptions.Selected;

            if (LinkOverlay)

                flags |= StockIconOptions.LinkOverlay;

            // Create a StockIconInfo structure to pass to the native method.
            var info = new StockIconInfo { StuctureSize = (uint)Marshal.SizeOf(typeof(StockIconInfo)) };

            // Pass the struct to the native method
            HResult hr = SHGetStockIconInfo(identifier, flags, ref info);

            // If we get an error, return null as the icon requested might not be supported
            // on the current system

            // If we succeed, return the HIcon

            return hr == HResult.Ok ? info.Handle :

            hr == HResult.InvalidArguments
                    ? throw new InvalidOperationException(
                        string.Format(System.Globalization.CultureInfo.InvariantCulture,
                        LocalizedMessages.StockIconInvalidGuid,
                        identifier))
                    : IntPtr.Zero;
        }
        #endregion

        #region IDisposable Members
        /// <summary>
        /// Release the native and managed objects
        /// </summary>
        protected virtual void DisposeOverride()
        {
            // Unmanaged resources
            if (hIcon != IntPtr.Zero)

                _ = Core.DestroyIcon(hIcon);
        }

        /// <summary>
        /// Release the native objects
        /// </summary>
        public void Dispose()
        {
            DisposeOverride();
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// 
        /// </summary>
        ~StockIcon() => DisposeOverride();
        #endregion
    }
}

