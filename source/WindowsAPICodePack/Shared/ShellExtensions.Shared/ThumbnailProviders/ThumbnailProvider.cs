﻿using Microsoft.Win32;
using Microsoft.WindowsAPICodePack.COMNative.Shell;
using Microsoft.WindowsAPICodePack.COMNative.ShellExtensions;
using Microsoft.WindowsAPICodePack.Shell;
using Microsoft.WindowsAPICodePack.ShellExtensions.Resources;
using Microsoft.WindowsAPICodePack.Win32Native.Taskbar;

using System;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;

using FileInfo = System.IO.FileInfo;

namespace Microsoft.WindowsAPICodePack.ShellExtensions
{
    /// <summary>
    /// This is the base class for all thumbnail providers and provides their basic functionality.
    /// To create a custom thumbnail provider a class must derive from this, use the <see name="ThumbnailProviderAttribute"/>,
    /// and implement 1 or more of the following interfaces: 
    /// <see name="IThumbnailFromStream"/>, <see name="IThumbnailFromShellObject"/>, <see name="IThumbnailFromFile"/>.   
    /// </summary>
    public abstract class ThumbnailProvider : IThumbnailProvider, ICustomQueryInterface, IDisposable,
        IInitializeWithStream, IInitializeWithItem, IInitializeWithFile
    {
        // Determines which interface should be called to return a bitmap
        private Bitmap GetBitmap(int sideLength) => _stream != null && this is IThumbnailFromStream stream
                ? stream.ConstructBitmap(_stream, sideLength)
                : _shellObject != null && this is IThumbnailFromShellObject shellObject
                ? shellObject.ConstructBitmap(_shellObject, sideLength)
                : _info != null && this is IThumbnailFromFile file
                ? file.ConstructBitmap(_info, sideLength)
                : throw new InvalidOperationException(
                string.Format(System.Globalization.CultureInfo.InvariantCulture,
                LocalizedMessages.ThumbnailProviderInterfaceNotImplemented,
                GetType().Name));

        /// <summary>
        /// Sets the AlphaType of the generated thumbnail.
        /// Override this method in a derived class to change the thumbnails AlphaType, default is Unknown.
        /// </summary>
        public virtual ThumbnailAlphaType GetThumbnailAlphaType() => ThumbnailAlphaType.Unknown;

        private StorageStream _stream = null;
        private FileInfo _info = null;
        private ShellObject _shellObject = null;

        #region IThumbnailProvider Members
        void IThumbnailProvider.GetThumbnail(uint sideLength, out IntPtr hBitmap, out uint alphaType)
        {
            using (Bitmap map = GetBitmap((int)sideLength))

                hBitmap = map.GetHbitmap();

            alphaType = (uint)GetThumbnailAlphaType();
        }
        #endregion

        #region ICustomQueryInterface Members
        CustomQueryInterfaceResult ICustomQueryInterface.GetInterface(ref Guid iid, out IntPtr ppv)
        {
            ppv = IntPtr.Zero;

            string _iid = iid.ToString();

            // Forces COM to not use the managed (free threaded) marshaler

            return _iid == NativeAPI.Guids.COM.IMarshal || (_iid == NativeAPI.Guids.ShellExtensions.IInitializeWithStream && !(this is IThumbnailFromStream))
            || (_iid == NativeAPI.Guids.ShellExtensions.IInitializeWithItem && !(this is IThumbnailFromShellObject))
            || (_iid == NativeAPI.Guids.ShellExtensions.IInitializeWithFile && !(this is IThumbnailFromFile)) ? CustomQueryInterfaceResult.Failed : CustomQueryInterfaceResult.NotHandled;
        }
        #endregion

        #region COM Registration
        /// <summary>
        /// Called when the assembly is registered via RegAsm.
        /// </summary>
        /// <param name="registerType">Type to be registered.</param>
        [ComRegisterFunction]
        private static void Register(Type registerType)
        {
            if (registerType != null && registerType.IsSubclassOf(typeof(ThumbnailProvider)))
            {
                object[] attributes = registerType.GetCustomAttributes(typeof(ThumbnailProviderAttribute), true);

                if (attributes != null && attributes.Length == 1)
                {
                    var attribute = attributes[0] as ThumbnailProviderAttribute;
                    ThrowIfInvalid(registerType, attribute);
                    RegisterThumbnailHandler(registerType.GUID.ToString("B"), attribute);
                }
            }
        }

        private static void RegisterThumbnailHandler(string guid, ThumbnailProviderAttribute attribute)
        {
            // set process isolation
            using (RegistryKey clsidKey = Registry.ClassesRoot.OpenSubKey("CLSID"))
            using (RegistryKey guidKey = clsidKey.OpenSubKey(guid, true))
            {
                guidKey.SetValue("DisableProcessIsolation", attribute.DisableProcessIsolation ? 1 : 0, RegistryValueKind.DWord);

                using
#if !CS8
                    (
#endif
                    RegistryKey inproc = guidKey.OpenSubKey("InprocServer32", true)
#if CS8
                    ;
#else
                    )
#endif
                inproc.SetValue("ThreadingModel", "Apartment", RegistryValueKind.String);
            }

            // register file as an approved extension
            using (RegistryKey approvedShellExtensions = Registry.LocalMachine.OpenSubKey(
                 @"SOFTWARE\Microsoft\Windows\CurrentVersion\Shell Extensions\Approved", true))

                approvedShellExtensions.SetValue(guid, attribute.Name, RegistryValueKind.String);

            // register extension with each extension in the list
            string[] extensions = attribute.Extensions.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string extension in extensions)

                using (RegistryKey extensionKey = Registry.ClassesRoot.CreateSubKey(extension)) // Create makes it writable
                using (RegistryKey shellExKey = extensionKey.CreateSubKey("shellex"))
                using (RegistryKey providerKey = shellExKey.CreateSubKey(new Guid(NativeAPI.Guids.ShellExtensions.IThumbnailProvider).ToString("B")))
                {
                    providerKey.SetValue(null, guid, RegistryValueKind.String);

                    if (attribute.ThumbnailCutoff == ThumbnailCutoffSize.Square20)

                        extensionKey.DeleteValue(nameof(attribute.ThumbnailCutoff), false);

                    else

                        extensionKey.SetValue(nameof(attribute.ThumbnailCutoff), (int)attribute.ThumbnailCutoff, RegistryValueKind.DWord);

                    if (attribute.TypeOverlay != null)

                        extensionKey.SetValue(nameof(attribute.TypeOverlay), attribute.TypeOverlay, RegistryValueKind.String);

                    if (attribute.ThumbnailAdornment == ThumbnailAdornment.Default)

                        extensionKey.DeleteValue("Treatment", false);

                    else

                        extensionKey.SetValue("Treatment", (int)attribute.ThumbnailAdornment, RegistryValueKind.DWord);
                }
        }

        /// <summary>
        /// Called when the assembly is registered via RegAsm.
        /// </summary>
        /// <param name="registerType">Type to register.</param>
        [ComUnregisterFunction]
        private static void Unregister(Type registerType)
        {
            if (registerType != null && registerType.IsSubclassOf(typeof(ThumbnailProvider)))
            {
                object[] attributes = registerType.GetCustomAttributes(typeof(ThumbnailProviderAttribute), true);

                if (attributes != null && attributes.Length == 1)

                    UnregisterThumbnailHandler(registerType.GUID.ToString("B"), attributes[0] as ThumbnailProviderAttribute);
            }
        }

        private static void UnregisterThumbnailHandler(string guid, ThumbnailProviderAttribute attribute)
        {
            string[] extensions = attribute.Extensions.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string extension in extensions)
            {
                using
#if !CS8
                    (
#endif
                    RegistryKey extKey = Registry.ClassesRoot.OpenSubKey(extension, true)
#if CS8
                    ;
#else
                    )
#endif
                using
#if !CS8
                    (
#endif
                    RegistryKey shellexKey = extKey.OpenSubKey("shellex", true)
#if CS8
                    ;
#else
                    )
                {
#endif
                shellexKey.DeleteSubKey(new Guid(NativeAPI.Guids.ShellExtensions.IThumbnailProvider).ToString("B"), false);

                void deleteValue(string name) => extKey.DeleteValue(name, false);

                deleteValue("ThumbnailCutoff");
                deleteValue("TypeOverlay");
                deleteValue("Treatment"); // Thumbnail adornment
#if !CS8
                }
#endif
            }

            using
#if !CS8
                (
#endif
                RegistryKey approvedShellExtensions = Registry.LocalMachine.OpenSubKey(
                @"SOFTWARE\Microsoft\Windows\CurrentVersion\Shell Extensions\Approved", true)
#if CS8
                ;
#else
                )
#endif
            approvedShellExtensions.DeleteValue(guid, false);
        }

        private static void ThrowIfInvalid(Type type, ThumbnailProviderAttribute attribute)
        {
            Type[] interfaces = type.GetInterfaces();
            bool interfaced = interfaces.Any(x => x == typeof(IThumbnailFromStream));

            if (interfaces.Any(x => x == typeof(IThumbnailFromShellObject) || x == typeof(IThumbnailFromFile)))

                // According to MSDN (http://msdn.microsoft.com/en-us/library/cc144114(v=VS.85).aspx)
                // A thumbnail provider that does not implement IInitializeWithStream must opt out of 
                // running in the isolated process. The default behavior of the indexer opts in
                // to process isolation regardless of which interfaces are implemented.                

                interfaced = interfaced || attribute.DisableProcessIsolation ? true : throw new InvalidOperationException(
                    string.Format(System.Globalization.CultureInfo.InvariantCulture,
                    LocalizedMessages.ThumbnailProviderDisabledProcessIsolation,
                    type.Name));

            if (!interfaced)

                throw new InvalidOperationException(
                        string.Format(System.Globalization.CultureInfo.InvariantCulture,
                        LocalizedMessages.ThumbnailProviderInterfaceNotImplemented,
                        type.Name));
        }
        #endregion

        #region IInitializeWithStream Members
        void IInitializeWithStream.Initialize(System.Runtime.InteropServices.ComTypes.IStream stream, AccessModes fileMode) => _stream = new StorageStream(stream, fileMode != AccessModes.ReadWrite);
        #endregion

        #region IInitializeWithItem Members
        void IInitializeWithItem.Initialize(IShellItem shellItem, AccessModes accessMode) => _shellObject = ShellObjectFactory.Create(shellItem);
        #endregion

        #region IInitializeWithFile Members
        void IInitializeWithFile.Initialize(string filePath, AccessModes fileMode) => _info = new FileInfo(filePath);
        #endregion

        #region IDisposable Members
        /// <summary>
        /// Disploses the thumbnail provider.
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing && _stream != null)

                _stream.Dispose();
        }

        /// <summary>
        /// Disposes the thumbnail provider.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Finalizer for the thumbnail provider.
        /// </summary>
        ~ThumbnailProvider() => Dispose(false);
        #endregion
    }
}
