using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using Microsoft.WindowsAPICodePack.COMNative.Shell;
using Microsoft.WindowsAPICodePack.COMNative.ShellExtensions;
using Microsoft.WindowsAPICodePack.Shell;
using Microsoft.WindowsAPICodePack.ShellExtensions.Resources;
using Microsoft.WindowsAPICodePack.Win32Native.Shell;
using Microsoft.WindowsAPICodePack.Win32Native.Taskbar;
using FileInfo = System.IO.FileInfo;

namespace Microsoft.WindowsAPICodePack.ShellExtensions
{
    /// <summary>
    /// This is the base class for all thumbnail providers and provides their basic functionality.
    /// To create a custom thumbnail provider a class must derive from this, use the <typeparamref name="ThumbnailProviderAttribute"/>,
    /// and implement 1 or more of the following interfaces: 
    /// <typeparamref name="IThumbnailFromStream"/>, <typeparamref name="IThumbnailFromShellObject"/>, <typeparamref name="IThumbnailFromFile"/>.   
    /// </summary>
    public abstract class ThumbnailProvider : IThumbnailProvider, ICustomQueryInterface, IDisposable,
        IInitializeWithStream, IInitializeWithItem, IInitializeWithFile
    {
        // Determines which interface should be called to return a bitmap
        private Bitmap GetBitmap(int sideLength)
        {
            if (_stream != null && this is IThumbnailFromStream stream)

                return stream.ConstructBitmap(_stream, sideLength);

            if (_shellObject != null && this is IThumbnailFromShellObject shellObject)
            
                return shellObject.ConstructBitmap(_shellObject, sideLength);
            
            if (_info != null && this is IThumbnailFromFile file)
            
                return file.ConstructBitmap(_info, sideLength);
            
            throw new InvalidOperationException(
                string.Format(System.Globalization.CultureInfo.InvariantCulture,
                LocalizedMessages.ThumbnailProviderInterfaceNotImplemented,
                GetType().Name));
        }

        /// <summary>
        /// Sets the AlphaType of the generated thumbnail.
        /// Override this method in a derived class to change the thumbnails AlphaType, default is Unknown.
        /// </summary>
        /// <returns>ThumnbailAlphaType</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate")]
        public virtual ThumbnailAlphaType GetThumbnailAlphaType() => ThumbnailAlphaType.Unknown;

        private StorageStream _stream = null;
        private FileInfo _info = null;
        private ShellObject _shellObject = null;

        #region IThumbnailProvider Members

        void IThumbnailProvider.GetThumbnail(uint sideLength, out IntPtr hBitmap, out uint alphaType)
        {
            using (Bitmap map = GetBitmap((int)sideLength))
            {
                hBitmap = map.GetHbitmap();
            }
            alphaType = (uint)GetThumbnailAlphaType();
        }

        #endregion

        #region ICustomQueryInterface Members

        CustomQueryInterfaceResult ICustomQueryInterface.GetInterface(ref Guid iid, out IntPtr ppv)
        {
            ppv = IntPtr.Zero;

            string _iid = iid.ToString();

            // Forces COM to not use the managed (free threaded) marshaler
            
            
                return _iid == Win32Native.Guids.COM.IMarshal || (_iid == Win32Native.Guids.ShellExtensions.IInitializeWithStream && !(this is IThumbnailFromStream))
                || (_iid == Win32Native.Guids.ShellExtensions.IInitializeWithItem && !(this is IThumbnailFromShellObject))
                || (_iid == Win32Native.Guids.ShellExtensions.IInitializeWithFile && !(this is IThumbnailFromFile)) ?  CustomQueryInterfaceResult.Failed : CustomQueryInterfaceResult.NotHandled;
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

#if NETFRAMEWORK

                using (RegistryKey inproc = guidKey.OpenSubKey("InprocServer32", true))

#else

                using RegistryKey inproc = guidKey.OpenSubKey("InprocServer32", true);

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
            {

#if NETFRAMEWORK

                using (RegistryKey extensionKey = Registry.ClassesRoot.CreateSubKey(extension)) // Create makes it writable
                using (RegistryKey shellExKey = extensionKey.CreateSubKey("shellex"))
                using (RegistryKey providerKey = shellExKey.CreateSubKey(new Guid(Win32Native.Guids.ShellExtensions.IThumbnailProvider).ToString("B")))

                {

#else

                using RegistryKey extensionKey = Registry.ClassesRoot.CreateSubKey(extension); // Create makes it writable
                using RegistryKey shellExKey = extensionKey.CreateSubKey("shellex");
                using RegistryKey providerKey = shellExKey.CreateSubKey(new Guid(Win32Native.Guids.ShellExtensions.IThumbnailProvider).ToString("B"));

#endif

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

#if NETFRAMEWORK

                }

#endif

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

#if NETFRAMEWORK

                using (RegistryKey extKey = Registry.ClassesRoot.OpenSubKey(extension, true))
                using (RegistryKey shellexKey = extKey.OpenSubKey("shellex", true))
                {

#else

                using RegistryKey extKey = Registry.ClassesRoot.OpenSubKey(extension, true);
                using RegistryKey shellexKey = extKey.OpenSubKey("shellex", true);

#endif

                shellexKey.DeleteSubKey(new Guid(Win32Native.Guids.ShellExtensions.IThumbnailProvider).ToString("B"), false);

                extKey.DeleteValue("ThumbnailCutoff", false);
                extKey.DeleteValue("TypeOverlay", false);
                extKey.DeleteValue("Treatment", false); // Thumbnail adornment

#if NETFRAMEWORK

                }

#endif

            }

#if NETFRAMEWORK

            using (RegistryKey approvedShellExtensions = Registry.LocalMachine.OpenSubKey(
                @"SOFTWARE\Microsoft\Windows\CurrentVersion\Shell Extensions\Approved", true))

#else 

            using RegistryKey approvedShellExtensions = Registry.LocalMachine.OpenSubKey(
                @"SOFTWARE\Microsoft\Windows\CurrentVersion\Shell Extensions\Approved", true);

#endif

            approvedShellExtensions.DeleteValue(guid, false);
        }

        private static void ThrowIfInvalid(Type type, ThumbnailProviderAttribute attribute)
        {
            Type[] interfaces = type.GetInterfaces();
            bool interfaced = interfaces.Any(x => x == typeof(IThumbnailFromStream));

            if (interfaces.Any(x => x == typeof(IThumbnailFromShellObject) || x == typeof(IThumbnailFromFile)))
            {
                // According to MSDN (http://msdn.microsoft.com/en-us/library/cc144114(v=VS.85).aspx)
                // A thumbnail provider that does not implement IInitializeWithStream must opt out of 
                // running in the isolated process. The default behavior of the indexer opts in
                // to process isolation regardless of which interfaces are implemented.                
                if (!interfaced && !attribute.DisableProcessIsolation)
                
                    throw new InvalidOperationException(
                        string.Format(System.Globalization.CultureInfo.InvariantCulture,
                        LocalizedMessages.ThumbnailProviderDisabledProcessIsolation,
                        type.Name));
                
                interfaced = true;
            }

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
        /// Finalizer for the thumbnail provider.
        /// </summary>
        ~ThumbnailProvider()
        {
            Dispose(false);
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
        /// Disploses the thumbnail provider.
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing && _stream != null)
            
                _stream.Dispose();
        }

#endregion

    }
}
