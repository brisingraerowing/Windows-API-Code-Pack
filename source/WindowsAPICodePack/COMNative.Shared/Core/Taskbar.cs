using Microsoft.WindowsAPICodePack.PropertySystem;
using Microsoft.WindowsAPICodePack.Win32Native;
using Microsoft.WindowsAPICodePack.Win32Native.PropertySystem;
using Microsoft.WindowsAPICodePack.Win32Native.Shell;
using Microsoft.WindowsAPICodePack.COMNative.Shell.PropertySystem;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using static Microsoft.WindowsAPICodePack.Win32Native.Consts.DllNames;
using static Microsoft.WindowsAPICodePack.COMNative.Shell.PropertySystem.SystemProperties.System;

namespace Microsoft.WindowsAPICodePack. COMNative.Taskbar
{
    public static class Taskbar
    {

        [DllImport(Shell32)]
        public static extern int SHGetPropertyStoreForWindow(
            IntPtr hwnd,
            ref Guid iid /*IID_IPropertyStore*/,
            [Out(), MarshalAs(UnmanagedType.Interface)]out IPropertyStore propertyStore);

        /// <summary>
        /// Sets the window's application id by its window handle.
        /// </summary>
        /// <param name="hwnd">The window handle.</param>
        /// <param name="appId">The application id.</param>
        public static void SetWindowAppId(IntPtr hwnd, string appId) => SetWindowProperty(hwnd, AppUserModel.ID, appId);

        public static void SetWindowProperty(IntPtr hwnd, PropertyKey propkey, string value)
        {
            // Get the IPropertyStore for the given window handle
            IPropertyStore propStore = GetWindowPropertyStore(hwnd);

            // Set the value
            using (var pv = new PropVariant(value))
            {
                HResult result = propStore.SetValue(ref propkey, pv);

                if (CoreErrorHelper.Succeeded(result))

                    // Dispose the IPropertyStore and PropVariant
                    _ = Marshal.ReleaseComObject(propStore);

                else

                throw new ShellException(result);
            }
        }

        public static IPropertyStore GetWindowPropertyStore(IntPtr hwnd)
        {
            var guid = new Guid(Win32Native.Guids.Shell.IPropertyStore);

            int rc = SHGetPropertyStoreForWindow(
                hwnd,
                ref guid,
                out IPropertyStore propStore);

            return rc == 0 ? propStore : throw Marshal.GetExceptionForHR(rc);
        }
    }
}
