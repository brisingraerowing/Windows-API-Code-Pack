//Copyright (c) Microsoft Corporation.  All rights reserved.  Distributed under the Microsoft Public License (MS-PL)

using Microsoft.WindowsAPICodePack.PropertySystem;
using Microsoft.WindowsAPICodePack.Win32Native;
using Microsoft.WindowsAPICodePack.Win32Native.Shell;
using Microsoft.WindowsAPICodePack.COMNative.Shell.PropertySystem;
using Microsoft.WindowsAPICodePack.Win32Native.PropertySystem;
using Microsoft.WindowsAPICodePack.COMNative.Shell;

using System;
using System.Runtime.InteropServices;

namespace Microsoft.WindowsAPICodePack.Taskbar
{
    /// <summary>
    /// Represents a separator in the user task list. The JumpListSeparator control
    /// can only be used in a user task list.
    /// </summary>
    public class JumpListSeparator : JumpListTask, IDisposable
    {
        internal static PropertyKey PKEY_AppUserModel_IsDestListSeparator = SystemProperties.System.AppUserModel.IsDestinationListSeparator;

        private IPropertyStore nativePropertyStore;
        private IShellLinkW nativeShellLink;

        /// <summary>
        /// Gets an IShellLinkW representation of this object
        /// </summary>
        internal override IShellLinkW NativeShellLink
        {
            get
            {
                if (nativeShellLink != null)
                {
                    _ = Marshal.ReleaseComObject(nativeShellLink);

                    nativeShellLink = null;
                }

                nativeShellLink = (IShellLinkW)new CShellLink();

                if (nativePropertyStore != null)
                {
                    _ = Marshal.ReleaseComObject(nativePropertyStore);

                    nativePropertyStore = null;
                }

                nativePropertyStore = (IPropertyStore)nativeShellLink;

                using (var propVariant = new PropVariant(true))
                {
                    HResult result = nativePropertyStore.SetValue(ref PKEY_AppUserModel_IsDestListSeparator, propVariant);

                    if (!CoreErrorHelper.Succeeded(result))

                        throw new ShellException(result);

                    _ = nativePropertyStore.Commit();
                }

                return nativeShellLink;
            }
        }

        #region IDisposable Members
        /// <summary>
        /// Release the native and managed objects
        /// </summary>
        /// <param name="disposing">Indicates that this is being called from Dispose(), rather than the finalizer.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (nativePropertyStore != null)
            {
                _ = Marshal.ReleaseComObject(nativePropertyStore);

                nativePropertyStore = null;
            }

            if (nativeShellLink != null)
            {
                _ = Marshal.ReleaseComObject(nativeShellLink);

                nativeShellLink = null;
            }
        }

        /// <summary>
        /// Release the native objects.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Implement the finalizer.
        /// </summary>
        ~JumpListSeparator() => Dispose(false);
        #endregion
    }
}
