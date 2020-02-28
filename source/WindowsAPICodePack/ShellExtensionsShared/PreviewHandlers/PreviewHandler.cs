using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using Microsoft.WindowsAPICodePack.Shell;
using Microsoft.WindowsAPICodePack.ShellExtensions.Resources;
using Microsoft.WindowsAPICodePack.Win32Native;
using Microsoft.WindowsAPICodePack.Win32Native.Shell;
using Microsoft.WindowsAPICodePack.Win32Native.ShellExtensions;
using FileInfo = System.IO.FileInfo;

namespace Microsoft.WindowsAPICodePack.ShellExtensions
{
    /// <summary>
    /// This is the base class for all preview handlers and provides their basic functionality.
    /// To create a custom preview handler a class must derive from this, use the <typeparamref name="PreviewHandlerAttribute"/>,
    /// and implement 1 or more of the following interfaces: 
    /// <typeparamref name="IPreviewFromStream"/>, 
    /// <typeparamref name="IPreviewFromShellObject"/>, 
    /// <typeparamref name="IPreviewFromFile"/>.   
    /// </summary>
    public abstract class PreviewHandler : ICustomQueryInterface, IPreviewHandler, IPreviewHandlerVisuals,
        IOleWindow, IObjectWithSite, IInitializeWithStream, IInitializeWithItem, IInitializeWithFile
    {
        private IntPtr _parentHwnd;
        private IPreviewHandlerFrame _frame;

        /// <summary>
        /// Gets whether the preview is currently showing
        /// </summary>
        public bool IsPreviewShowing { get; private set; }

        /// <summary>
        /// Called immediately before the preview is to be shown.        
        /// </summary>
        protected virtual void Initialize() { }

        /// <summary>
        /// Called when the preview is no longer shown.
        /// </summary>
        protected virtual void Uninitialize() { }

        #region Required functions - Abstract functions
        /// <summary>
        /// This should return the window handle to be displayed in the Preview.
        /// </summary>
        protected abstract IntPtr Handle { get; }

        /// <summary>
        /// Called to update the bounds and position of the preview control
        /// </summary>
        /// <param name="bounds"></param>
        protected abstract void UpdateBounds(in NativeRect bounds);

        /// <summary>
        /// Called when an exception occurs during the initialization of the control
        /// </summary>
        /// <param name="caughtException"></param>
        protected abstract void HandleInitializeException(in Exception caughtException);

        /// <summary>
        /// Called when the preview control obtains focus.
        /// </summary>
        protected abstract void SetFocus();

        /// <summary>
        /// Called when a request is received to set or change the background color according to the user's preferences.
        /// </summary>
        /// <param name="color">An int representing the ARGB color</param>
        protected abstract void SetBackground(in int argb);

        /// <summary>
        /// Called when a request is received to set or change the foreground color according to the user's preferences.
        /// </summary>
        /// <param name="color">An int representing the ARGB color</param>
        protected abstract void SetForeground(in int argb);

        /// <summary>
        /// Called to set the font of the preview control according to the user's preferences.
        /// </summary>
        /// <param name="font"></param>
        protected abstract void SetFont(in LogFont font);

        /// <summary>
        /// Called to set the parent of the preview control.
        /// </summary>
        /// <param name="handle"></param>
        protected abstract void SetParentHandle(IntPtr handle);
        #endregion

        #region IPreviewHandler
        void IPreviewHandler.SetWindow(IntPtr hwnd, ref NativeRect rect)
        {
            _parentHwnd = hwnd;
            UpdateBounds(rect);
            SetParentHandle(_parentHwnd);
        }

        void IPreviewHandler.SetRect(ref NativeRect rect) => UpdateBounds(rect);

        void IPreviewHandler.DoPreview()
        {
            IsPreviewShowing = true;
            try
            {
                Initialize();
            }
            catch (Exception exc)
            {
                HandleInitializeException(exc);
            }
        }

        void IPreviewHandler.Unload()
        {
            Uninitialize();
            IsPreviewShowing = false;
        }

        void IPreviewHandler.SetFocus() => SetFocus();

        void IPreviewHandler.QueryFocus(out IntPtr phwnd) => phwnd = HandlerNativeMethods.GetFocus();

        HResult IPreviewHandler.TranslateAccelerator(ref Message pmsg) => _frame != null ? _frame.TranslateAccelerator(ref pmsg) : HResult.False;
        #endregion

        #region IPreviewHandlerVisuals
        void IPreviewHandlerVisuals.SetBackgroundColor(NativeColorRef color) => SetBackground((int)color.Dword);

        void IPreviewHandlerVisuals.SetTextColor(NativeColorRef color) => SetForeground((int)color.Dword);

        void IPreviewHandlerVisuals.SetFont(ref LogFont plf) => SetFont(plf);
        #endregion

        #region IOleWindow
        void IOleWindow.GetWindow(out IntPtr phwnd) => phwnd = Handle;

        void IOleWindow.ContextSensitiveHelp(bool fEnterMode) =>
            // Preview handlers don't support context sensitive help. (As far as I know.)
            throw new NotImplementedException();
        #endregion

        #region IObjectWithSite
        void IObjectWithSite.SetSite(object pUnkSite) => _frame = pUnkSite as IPreviewHandlerFrame;

        void IObjectWithSite.GetSite(ref Guid riid, out object ppvSite) => ppvSite = _frame;
        #endregion

        #region IInitializeWithStream Members

        void IInitializeWithStream.Initialize(System.Runtime.InteropServices.ComTypes.IStream stream, AccessModes fileMode)
        {
            var preview = this as IPreviewFromStream;

            if (preview == null)
            
                throw new InvalidOperationException(
                    string.Format(System.Globalization.CultureInfo.InvariantCulture,
                    LocalizedMessages.PreviewHandlerUnsupportedInterfaceCalled,
                    nameof(IPreviewFromStream)));

            using var storageStream = new StorageStream(stream, fileMode != AccessModes.ReadWrite);
            preview.Load(storageStream);
        }

        #endregion

        #region IInitializeWithItem Members

        void IInitializeWithItem.Initialize(IShellItem shellItem, AccessModes accessMode)
        {
            var preview = this as IPreviewFromShellObject;

            if (preview == null)
            
                throw new InvalidOperationException(
                    string.Format(System.Globalization.CultureInfo.InvariantCulture,
                    LocalizedMessages.PreviewHandlerUnsupportedInterfaceCalled,
                    "IPreviewFromShellObject"));

            using ShellObject shellObject = ShellObjectFactory.Create(shellItem);
            preview.Load(shellObject);
        }

        #endregion

        #region IInitializeWithFile Members

        void IInitializeWithFile.Initialize(string filePath, AccessModes fileMode)
        {
            var preview = this as IPreviewFromFile;

            if (preview == null)
            
                throw new InvalidOperationException(
                    string.Format(System.Globalization.CultureInfo.InvariantCulture,
                    LocalizedMessages.PreviewHandlerUnsupportedInterfaceCalled,
                    "IPreviewFromFile"));
            
            preview.Load(new FileInfo(filePath));
        }

        #endregion

        #region ComRegistration
        /// <summary>
        /// Called when the assembly is registered via RegAsm.
        /// </summary>
        /// <param name="registerType">Type to register.</param>
        [ComRegisterFunction]
        private static void Register(Type registerType)
        {
            if (registerType != null && registerType.IsSubclassOf(typeof(PreviewHandler)))
            {
                object[] attrs = registerType.GetCustomAttributes(typeof(PreviewHandlerAttribute), true);
                if (attrs != null && attrs.Length == 1)
                {
                    var attr = attrs[0] as PreviewHandlerAttribute;
                    ThrowIfNotValid(registerType);
                    RegisterPreviewHandler(registerType.GUID, attr);
                }
                else
                
                    throw new NotSupportedException(
                        string.Format(System.Globalization.CultureInfo.InvariantCulture,
                        LocalizedMessages.PreviewHandlerInvalidAttributes, registerType.Name));
            }
        }

        /// <summary>
        /// Called when the assembly is Unregistered via RegAsm.
        /// </summary>
        /// <param name="registerType">Type to unregister</param>
        [ComUnregisterFunction]
        private static void Unregister(Type registerType)
        {
            if (registerType != null && registerType.IsSubclassOf(typeof(PreviewHandler)))
            {
                object[] attrs = registerType.GetCustomAttributes(typeof(PreviewHandlerAttribute), true);
                if (attrs != null && attrs.Length == 1)
                    UnregisterPreviewHandler(registerType.GUID, attrs[0] as PreviewHandlerAttribute);
            }
        }

        private static void RegisterPreviewHandler(Guid previewerGuid, PreviewHandlerAttribute attribute)
        {
            string guid = previewerGuid.ToString("B");
            // Create a new prevhost AppID so that this always runs in its own isolated process
            using (RegistryKey appIdsKey = Registry.ClassesRoot.OpenSubKey("AppID", true))
            using (RegistryKey appIdKey = appIdsKey.CreateSubKey(attribute.AppId))
            
                appIdKey.SetValue("DllSurrogate", @"%SystemRoot%\system32\prevhost.exe", RegistryValueKind.ExpandString);

            // Add preview handler to preview handler list
            using (RegistryKey handlersKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\PreviewHandlers", true))
            
                handlersKey.SetValue(guid, attribute.Name, RegistryValueKind.String);

            // Modify preview handler registration
            using (RegistryKey clsidKey = Registry.ClassesRoot.OpenSubKey("CLSID"))
            using (RegistryKey idKey = clsidKey.OpenSubKey(guid, true))
            {
                idKey.SetValue("DisplayName", attribute.Name, RegistryValueKind.String);
                idKey.SetValue("AppID", attribute.AppId, RegistryValueKind.String);
                idKey.SetValue("DisableLowILProcessIsolation", attribute.DisableLowILProcessIsolation ? 1 : 0, RegistryValueKind.DWord);

                using RegistryKey inproc = idKey.OpenSubKey("InprocServer32", true);
                inproc.SetValue("ThreadingModel", "Apartment", RegistryValueKind.String);
            }

            foreach (string extension in attribute.Extensions.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries))
            {
                Trace.WriteLine("Registering extension '" + extension + "' with previewer '" + guid + "'");

                // Set preview handler for specific extension
                using RegistryKey extensionKey = Registry.ClassesRoot.CreateSubKey(extension);
                using RegistryKey shellexKey = extensionKey.CreateSubKey("shellex");
                using RegistryKey previewKey = shellexKey.CreateSubKey(new Guid(Guids.IPreviewHandler).ToString("B"));
                previewKey.SetValue(null, guid, RegistryValueKind.String);
            }
        }

        private static void UnregisterPreviewHandler(Guid previewerGuid, PreviewHandlerAttribute attribute)
        {
            string guid = previewerGuid.ToString("B");
            foreach (string extension in attribute.Extensions.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries))
            {
                Trace.WriteLine("Unregistering extension '" + extension + "' with previewer '" + guid + "'");
                using RegistryKey shellexKey = Registry.ClassesRoot.OpenSubKey(extension + "\\shellex", true);
                shellexKey.DeleteSubKey(Guids.IPreviewHandler, false);
            }

            using (RegistryKey appIdsKey = Registry.ClassesRoot.OpenSubKey("AppID", true))
            
                appIdsKey.DeleteSubKey(attribute.AppId, false);

            using RegistryKey classesKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\PreviewHandlers", true);
            classesKey.DeleteValue(guid, false);
        }

        private static void ThrowIfNotValid(Type type)
        {
            Type[] interfaces = type.GetInterfaces();
            if (!interfaces.Any(x =>
                x == typeof(IPreviewFromStream)
                || x == typeof(IPreviewFromShellObject)
                || x == typeof(IPreviewFromFile)))
            
                throw new NotImplementedException(
                    string.Format(System.Globalization.CultureInfo.InvariantCulture,
                    LocalizedMessages.PreviewHandlerInterfaceNotImplemented,
                    type.Name));
        }

        #endregion

        #region ICustomQueryInterface Members

        CustomQueryInterfaceResult ICustomQueryInterface.GetInterface(ref Guid iid, out IntPtr ppv)
        {
            ppv = IntPtr.Zero;
            // Forces COM to not use the managed (free threaded) marshaler
            if (iid == new Guid(Win32Native.Guids.COM.IMarshal))
            
                return CustomQueryInterfaceResult.Failed;

            return (iid == new Guid(Guids.IInitializeWithStream) && !(this is IPreviewFromStream))
                || (iid == new Guid(Guids.IInitializeWithItem) && !(this is IPreviewFromShellObject))
                || (iid == new Guid(Guids.IInitializeWithFile) && !(this is IPreviewFromFile))
                ? CustomQueryInterfaceResult.Failed
                : CustomQueryInterfaceResult.NotHandled;
        }


        #endregion
    }
}
