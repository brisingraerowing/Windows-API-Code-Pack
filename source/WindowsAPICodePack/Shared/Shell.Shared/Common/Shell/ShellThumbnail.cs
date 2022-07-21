//Copyright (c) Microsoft Corporation.  All rights reserved.  Distributed under the Microsoft Public License (MS-PL)

using Microsoft.WindowsAPICodePack.COMNative.Shell;
using Microsoft.WindowsAPICodePack.Win32Native;
using Microsoft.WindowsAPICodePack.Win32Native.GDI;
using Microsoft.WindowsAPICodePack.Win32Native.Shell;
using Microsoft.WindowsAPICodePack.Win32Native.Shell.Resources;

using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Interop;
using System.Windows.Media.Imaging;

namespace Microsoft.WindowsAPICodePack.Shell
{
    /// <summary>
    /// Represents a thumbnail or an icon for a ShellObject.
    /// </summary>
    public class ShellThumbnail
    {
        private enum ShellThumbnailOption : byte
        {
            Default = 0,

            Icon = 1,

            Thumbnail = 2
        }

        #region Private members
        /// <summary>
        /// Native shellItem
        /// </summary>
        private readonly IShellItem shellItemNative;

        /// <summary>
        /// Internal member to keep track of the current size
        /// </summary>
        private System.Windows.Size currentSize = new System.Windows.Size(256, 256);

        private ShellThumbnailFormatOption formatOption = ShellThumbnailFormatOption.Default;
        #endregion

        #region Public properties
        /// <summary>
        /// Gets or sets the default size of the thumbnail or icon. The default is 32x32 pixels for icons and 
        /// 256x256 pixels for thumbnails.
        /// </summary>
        /// <remarks>If the size specified is larger than the maximum size of 1024x1024 for thumbnails and 256x256 for icons,
        /// an <see cref="ArgumentOutOfRangeException"/> is thrown.
        /// </remarks>
        public System.Windows.Size CurrentSize
        {
            get => currentSize;

            set
            {
                // Check for 0; negative number check not required as System.Windows.Size only allows positive numbers.
                System.Windows.Size size = value.Height == 0 || value.Width == 0 ? throw new ArgumentOutOfRangeException(nameof(value), LocalizedMessages.ShellThumbnailSizeCannotBe0) : FormatOption == ShellThumbnailFormatOption.IconOnly ? DefaultIconSize.Maximum : DefaultThumbnailSize.Maximum;

                currentSize = value.Height > size.Height || value.Width > size.Width ? throw new ArgumentOutOfRangeException(nameof(value),
                    string.Format(System.Globalization.CultureInfo.InvariantCulture,
                        LocalizedMessages.ShellThumbnailCurrentSizeRange, size.ToString())) : value;
            }
        }

        /// <summary>
        /// Gets the thumbnail or icon image in <see cref="System.Drawing.Bitmap"/> format.
        /// Null is returned if the ShellObject does not have a thumbnail or icon image.
        /// </summary>
        public Bitmap Bitmap => GetBitmap(ShellThumbnailOption.Default);

        public Bitmap IconBitmap => GetBitmap(ShellThumbnailOption.Icon);

        public Bitmap ThumbnailBitmap => GetBitmap(ShellThumbnailOption.Thumbnail);

        /// <summary>
        /// Gets the thumbnail or icon image in <see cref="System.Windows.Media.Imaging.BitmapSource"/> format. 
        /// Null is returned if the ShellObject does not have a thumbnail or icon image.
        /// </summary>
        public BitmapSource BitmapSource => GetBitmapSource(ShellThumbnailOption.Default);

        public BitmapSource IconBitmapSource => GetBitmapSource(ShellThumbnailOption.Icon);

        public BitmapSource ThumbnailBitmapSource => GetBitmapSource(ShellThumbnailOption.Thumbnail);

        /// <summary>
        /// Gets the thumbnail or icon image in <see cref="System.Drawing.Icon"/> format. 
        /// Null is returned if the ShellObject does not have a thumbnail or icon image.
        /// </summary>
        public Icon Icon => GetIcon(Bitmap);

        public Icon IconIcon => GetIcon(IconBitmap);

        public Icon ThumbnailIcon => GetIcon(ThumbnailBitmap);

        /// <summary>
        /// Gets the thumbnail or icon in small size and <see cref="System.Drawing.Bitmap"/> format.
        /// </summary>
        public Bitmap SmallBitmap => GetBitmap(DefaultIconSize.Small, DefaultThumbnailSize.Small, ShellThumbnailOption.Default);

        public Bitmap SmallIconBitmap => GetBitmap(DefaultIconSize.Small, DefaultThumbnailSize.Small, ShellThumbnailOption.Icon);

        public Bitmap SmallThumbnailBitmap => GetBitmap(DefaultIconSize.Small, DefaultThumbnailSize.Small, ShellThumbnailOption.Thumbnail);

        /// <summary>
        /// Gets the thumbnail or icon in small size and <see cref="System.Windows.Media.Imaging.BitmapSource"/> format.
        /// </summary>
        public BitmapSource SmallBitmapSource => GetBitmapSource(DefaultIconSize.Small, DefaultThumbnailSize.Small, ShellThumbnailOption.Default);

        public BitmapSource SmallIconBitmapSource => GetBitmapSource(DefaultIconSize.Small, DefaultThumbnailSize.Small, ShellThumbnailOption.Icon);

        public BitmapSource SmallThumbnailBitmapSource => GetBitmapSource(DefaultIconSize.Small, DefaultThumbnailSize.Small, ShellThumbnailOption.Thumbnail);

        /// <summary>
        /// Gets the thumbnail or icon in small size and <see cref="System.Drawing.Icon"/> format.
        /// </summary>
        public Icon SmallIcon => GetIcon(SmallBitmap);

        public Icon SmallIconIcon => GetIcon(SmallIconBitmap);

        public Icon SmallThumbnailIcon => GetIcon(SmallThumbnailBitmap);

        /// <summary>
        /// Gets the thumbnail or icon in Medium size and <see cref="System.Drawing.Bitmap"/> format.
        /// </summary>
        public Bitmap MediumBitmap => GetBitmap(DefaultIconSize.Medium, DefaultThumbnailSize.Medium, ShellThumbnailOption.Default);

        public Bitmap MediumIconBitmap => GetBitmap(DefaultIconSize.Medium, DefaultThumbnailSize.Medium, ShellThumbnailOption.Icon);

        public Bitmap MediumThumbnailBitmap => GetBitmap(DefaultIconSize.Medium, DefaultThumbnailSize.Medium, ShellThumbnailOption.Thumbnail);

        /// <summary>
        /// Gets the thumbnail or icon in medium size and <see cref="System.Windows.Media.Imaging.BitmapSource"/> format.
        /// </summary>
        public BitmapSource MediumBitmapSource => GetBitmapSource(DefaultIconSize.Medium, DefaultThumbnailSize.Medium, ShellThumbnailOption.Default);

        public BitmapSource MediumIconBitmapSource => GetBitmapSource(DefaultIconSize.Medium, DefaultThumbnailSize.Medium, ShellThumbnailOption.Icon);

        public BitmapSource MediumThumbnailBitmapSource => GetBitmapSource(DefaultIconSize.Medium, DefaultThumbnailSize.Medium, ShellThumbnailOption.Thumbnail);

        /// <summary>
        /// Gets the thumbnail or icon in Medium size and <see cref="System.Drawing.Icon"/> format.
        /// </summary>
        public Icon MediumIcon => GetIcon(MediumBitmap);

        public Icon MediumIconIcon => GetIcon(MediumIconBitmap);

        public Icon MediumThumbnailIcon => GetIcon(MediumThumbnailBitmap);

        /// <summary>
        /// Gets the thumbnail or icon in large size and <see cref="System.Drawing.Bitmap"/> format.
        /// </summary>
        public Bitmap LargeBitmap => GetBitmap(DefaultIconSize.Large, DefaultThumbnailSize.Large, ShellThumbnailOption.Default);

        public Bitmap LargeIconBitmap => GetBitmap(DefaultIconSize.Large, DefaultThumbnailSize.Large, ShellThumbnailOption.Icon);

        public Bitmap LargeThumbnailBitmap => GetBitmap(DefaultIconSize.Large, DefaultThumbnailSize.Large, ShellThumbnailOption.Thumbnail);

        /// <summary>
        /// Gets the thumbnail or icon in large size and <see cref="System.Windows.Media.Imaging.BitmapSource"/> format.
        /// </summary>
        public BitmapSource LargeBitmapSource => GetBitmapSource(DefaultIconSize.Large, DefaultThumbnailSize.Large, ShellThumbnailOption.Default);

        public BitmapSource LargeIconBitmapSource => GetBitmapSource(DefaultIconSize.Large, DefaultThumbnailSize.Large, ShellThumbnailOption.Icon);

        public BitmapSource LargeThumbnailBitmapSource => GetBitmapSource(DefaultIconSize.Large, DefaultThumbnailSize.Large, ShellThumbnailOption.Thumbnail);

        /// <summary>
        /// Gets the thumbnail or icon in Large size and <see cref="System.Drawing.Icon"/> format.
        /// </summary>
        public Icon LargeIcon => GetIcon(LargeBitmap);

        public Icon LargeIconIcon => GetIcon(LargeIconBitmap);

        public Icon LargeThumbnailIcon => GetIcon(LargeThumbnailBitmap);

        /// <summary>
        /// Gets the thumbnail or icon in extra large size and <see cref="System.Drawing.Bitmap"/> format.
        /// </summary>
        public Bitmap ExtraLargeBitmap => GetBitmap(DefaultIconSize.ExtraLarge, DefaultThumbnailSize.ExtraLarge, ShellThumbnailOption.Default);

        public Bitmap ExtraLargeIconBitmap => GetBitmap(DefaultIconSize.ExtraLarge, DefaultThumbnailSize.ExtraLarge, ShellThumbnailOption.Icon);

        public Bitmap ExtraLargeThumbnailBitmap => GetBitmap(DefaultIconSize.ExtraLarge, DefaultThumbnailSize.ExtraLarge, ShellThumbnailOption.Thumbnail);

        /// <summary>
        /// Gets the thumbnail or icon in Extra Large size and <see cref="System.Windows.Media.Imaging.BitmapSource"/> format.
        /// </summary>
        public BitmapSource ExtraLargeBitmapSource => GetBitmapSource(DefaultIconSize.ExtraLarge, DefaultThumbnailSize.ExtraLarge, ShellThumbnailOption.Default);

        public BitmapSource ExtraLargeIconBitmapSource => GetBitmapSource(DefaultIconSize.ExtraLarge, DefaultThumbnailSize.ExtraLarge, ShellThumbnailOption.Icon);

        public BitmapSource ExtraLargeThumbnailBitmapSource => GetBitmapSource(DefaultIconSize.ExtraLarge, DefaultThumbnailSize.ExtraLarge, ShellThumbnailOption.Thumbnail);

        /// <summary>
        /// Gets the thumbnail or icon in Extra Large size and <see cref="System.Drawing.Icon"/> format.
        /// </summary>
        public Icon ExtraLargeIcon => GetIcon(ExtraLargeBitmap);

        public Icon ExtraLargeIconIcon => GetIcon(ExtraLargeIconBitmap);

        public Icon ExtraLargeThumbnailIcon => GetIcon(ExtraLargeThumbnailBitmap);

        /// <summary>
        /// Gets or sets a value that determines if the current retrieval option is cache or extract, cache only, or from memory only.
        /// The default is cache or extract.
        /// </summary>
        public ShellThumbnailRetrievalOption RetrievalOption { get; set; }

        /// <summary>
        /// Gets or sets a value that determines if the current format option is thumbnail or icon, thumbnail only, or icon only.
        /// The default is thumbnail or icon.
        /// </summary>
        public ShellThumbnailFormatOption FormatOption
        {
            get => formatOption;

            set
            {
                // Do a similar check as we did in CurrentSize property setter,
                // If our mode is IconOnly, then our max is defined by DefaultIconSize.Maximum. We should make sure 
                // our CurrentSize is within this max range
                if ((formatOption = value) == ShellThumbnailFormatOption.IconOnly
                    && (CurrentSize.Height > DefaultIconSize.Maximum.Height || CurrentSize.Width > DefaultIconSize.Maximum.Width))

                    CurrentSize = DefaultIconSize.Maximum;
            }
        }

        /// <summary>
        /// Gets or sets a value that determines if the user can manually stretch the returned image.
        /// The default value is false.
        /// </summary>
        /// <remarks>
        /// For example, if the caller passes in 80x80 a 96x96 thumbnail could be returned. 
        /// This could be used as a performance optimization if the caller will need to stretch 
        /// the image themselves anyway. Note that the Shell implementation performs a GDI stretch blit. 
        /// If the caller wants a higher quality image stretch, they should pass this flag and do it themselves.
        /// </remarks>
        public bool AllowBiggerSize { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Internal constructor that takes in a parent ShellObject.
        /// </summary>
        /// <param name="shellObject"></param>
        internal ShellThumbnail(ShellObject shellObject) => shellItemNative = shellObject == null || shellObject.NativeShellItem == null ? throw new ArgumentNullException(nameof(shellObject)) : shellObject.NativeShellItem;
        #endregion

        #region Private Methods
        private Icon GetIcon(in Bitmap bitmap) => Icon.FromHandle(bitmap.GetHicon());

        private Bitmap GetBitmap(in ShellThumbnailOption option) => GetBitmap(CurrentSize, option);

        private BitmapSource GetBitmapSource(in ShellThumbnailOption option) => GetBitmapSource(CurrentSize, option);

        private bool GetIconOnlyRequestedValue(in ShellThumbnailOption option) => option == ShellThumbnailOption.Icon || formatOption == ShellThumbnailFormatOption.IconOnly;

        private bool GetThumbnailOnlyRequestedValue(in ShellThumbnailOption option) => option == ShellThumbnailOption.Thumbnail || formatOption == ShellThumbnailFormatOption.ThumbnailOnly;

        private SIIGBF CalculateFlags(in ShellThumbnailOption option)
        {
            SIIGBF flags = 0x0000;

            if (AllowBiggerSize)

                flags |= SIIGBF.BiggerSizeOk;



            if (RetrievalOption == ShellThumbnailRetrievalOption.CacheOnly)

                flags |= SIIGBF.InCacheOnly;

            else if (RetrievalOption == ShellThumbnailRetrievalOption.MemoryOnly)

                flags |= SIIGBF.MemoryOnly;



            if (GetIconOnlyRequestedValue(option))

                flags |= SIIGBF.IconOnly;

            else if (GetThumbnailOnlyRequestedValue(option))

                flags |= SIIGBF.ThumbnailOnly;

            return flags;
        }

        private IntPtr GetHBitmap(in System.Windows.Size size, in ShellThumbnailOption option)
        {
            // Create a size structure to pass to the native method
            var nativeSIZE = new Win32Native.Size
            {
                Width = Convert.ToInt32(size.Width),
                Height = Convert.ToInt32(size.Height)
            };

            // Use IShellItemImageFactory to get an icon
            // Options passed in: Resize to fit
            HResult hr = ((IShellItemImageFactory)shellItemNative).GetImage(nativeSIZE, CalculateFlags(option), out IntPtr hbitmap);

            if (hr == HResult.Ok) return hbitmap;

            else if ((uint)hr == 0x8004B200 && option != ShellThumbnailOption.Icon)
            {
                if (option == ShellThumbnailOption.Thumbnail)

                    return IntPtr.Zero;

                if (formatOption == ShellThumbnailFormatOption.ThumbnailOnly)

                    // Thumbnail was requested, but this ShellItem doesn't have a thumbnail.
                    throw new InvalidOperationException(LocalizedMessages.ShellThumbnailDoesNotHaveThumbnail, Marshal.GetExceptionForHR((int)hr));
            }

            throw (uint)hr == 0x80040154 // REGDB_E_CLASSNOTREG
                ? new NotSupportedException(LocalizedMessages.ShellThumbnailNoHandler, Marshal.GetExceptionForHR((int)hr))
                :
#if !CS9
                (Exception)
#endif
                new ShellException(hr);
        }

        private Bitmap GetBitmap(in System.Windows.Size iconOnlySize, in System.Windows.Size thumbnailSize, in ShellThumbnailOption option) => GetBitmap(GetIconOnlyRequestedValue(option) ? iconOnlySize : thumbnailSize, option);

        private Bitmap GetBitmap(in System.Windows.Size size, in ShellThumbnailOption option)
        {
            IntPtr hBitmap = GetHBitmap(size, option);

            // return a System.Drawing.Bitmap from the hBitmap
            Bitmap returnValue = Image.FromHbitmap(hBitmap);

            // delete HBitmap to avoid memory leaks
            _ = GDI.DeleteObject(hBitmap);

            return returnValue;
        }

        private BitmapSource GetBitmapSource(in System.Windows.Size iconOnlySize, in System.Windows.Size thumbnailSize, in ShellThumbnailOption option) => GetBitmapSource(GetIconOnlyRequestedValue(option) ? iconOnlySize : thumbnailSize, option);

        private BitmapSource GetBitmapSource(in System.Windows.Size size, in ShellThumbnailOption option)
        {
            IntPtr hBitmap = GetHBitmap(size, option);

            if (hBitmap == IntPtr.Zero) return null;

            // return a System.Media.Imaging.BitmapSource
            // Use interop to create a BitmapSource from hBitmap.
            BitmapSource returnValue = Imaging.CreateBitmapSourceFromHBitmap(
                hBitmap,
                IntPtr.Zero,
                System.Windows.Int32Rect.Empty,
                BitmapSizeOptions.FromEmptyOptions());

            // delete HBitmap to avoid memory leaks
            _ = GDI.DeleteObject(hBitmap);

            return returnValue;
        }
        #endregion
    }
}
