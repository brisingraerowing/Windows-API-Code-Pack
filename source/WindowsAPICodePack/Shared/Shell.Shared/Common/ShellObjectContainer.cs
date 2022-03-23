//Copyright (c) Microsoft Corporation.  All rights reserved.  Distributed under the Microsoft Public License (MS-PL)

using Microsoft.WindowsAPICodePack.COMNative.Shell;
using Microsoft.WindowsAPICodePack.Win32Native;
using Microsoft.WindowsAPICodePack.Win32Native.Shell;

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

using static WinCopies.
#if WAPICP3
    ThrowHelper;
#else
    Util.Util;
#endif

namespace Microsoft.WindowsAPICodePack.Shell
{
    /// <summary>
    /// Represents the base class for all types of Shell "containers". Any class deriving from this class
    /// can contain other ShellObjects (e.g. ShellFolder, FileSystemKnownFolder, ShellLibrary, etc)
    /// </summary>
    public abstract class ShellContainer : ShellObject, IEnumerable<ShellObject>, IDisposable
    {
        #region Private Fields
        private IShellFolder desktopFolderEnumeration;
        private IShellFolder nativeShellFolder;
        #endregion

        #region Internal Properties
        internal IShellFolder NativeShellFolder
        {
            get
            {
                if (nativeShellFolder == null)
                {
                    var guid = new Guid(NativeAPI.Guids.Shell.IShellFolder);
                    var handler = new Guid(Guids.ShellBindingHandlerID.ShellFolderObject);

                    HResult hr = NativeShellItem.BindToHandler(
                        IntPtr.Zero, ref handler, ref guid, out nativeShellFolder);

                    if (CoreErrorHelper.Failed(hr))
                    {
                        string str = ShellHelper.GetParsingName(NativeShellItem);

                        if (str != null && str != Environment.GetFolderPath(Environment.SpecialFolder.Desktop))

                            throw new ShellException(hr);
                    }
                }

                return nativeShellFolder;
            }
        }
        #endregion

        #region Internal Constructor
        internal ShellContainer() { }

        internal ShellContainer(IShellItem2 shellItem) : base(shellItem) { }
        #endregion

#if WAPICP3
#if CS7
        public static IntPtr[] GetPIDLs(IEnumerable<ShellObject> items)
        {
            if (items is IReadOnlyList<ShellObject> _items)

                return GetPIDLs(_items);

            var pidls = new WinCopies.Collections.Generic.ArrayBuilder<IntPtr>();

            foreach (ShellObject item in items)

                _ = pidls.AddLast(COMNative.Shell.Shell.GetPidl(item.ParsingName));

            return pidls.ToArray();
        }
#endif

        public static IntPtr[] GetPIDLs(
#if CS6
            System.
#else
            WinCopies.
#endif
            Collections.Generic.IReadOnlyList<ShellObject> items)
        {
            var pidls = new IntPtr[items.Count];

            for (int i = 0; i < items.Count; i++)

                pidls[i] = COMNative.Shell.Shell.GetPidl(items[i].ParsingName);

            return pidls;
        }

        public HResult TryGetUIObjectOf(IntPtr hwndOwner, IntPtr[] ptrs, ref Guid guid, out IntPtr ptr) => ptrs == null ? throw GetArgumentNullException(nameof(ptrs)) : NativeShellFolder.GetUIObjectOf(hwndOwner, (uint)ptrs.Length, ptrs, ref guid, IntPtr.Zero, out ptr);

        public IntPtr GetUIObjectOf(IntPtr hwndOwner, IntPtr[] ptrs, ref Guid guid)
        {
            CoreErrorHelper.ThrowExceptionForHResult(TryGetUIObjectOf(hwndOwner, ptrs, ref guid, out IntPtr ptr));

            return ptr;
        }
#endif

        #region Disposable Pattern
        /// <summary>
        /// Release resources
        /// </summary>
        /// <param name="disposing"><B>True</B> indicates that this is being called from Dispose(), rather than the finalizer.</param>
        protected override void Dispose(bool disposing)
        {
            if (nativeShellFolder != null)
            {
                _ = Marshal.ReleaseComObject(nativeShellFolder);
                nativeShellFolder = null;
            }

            if (desktopFolderEnumeration != null)
            {
                _ = Marshal.ReleaseComObject(desktopFolderEnumeration);
                desktopFolderEnumeration = null;
            }

            base.Dispose(disposing);
        }
        #endregion

        #region IEnumerable<ShellObject> Members
        /// <summary>
        /// Enumerates through contents of the ShellObjectContainer
        /// </summary>
        /// <returns>Enumerated contents</returns>
        public IEnumerator<ShellObject> GetEnumerator()
        {
            if (NativeShellFolder == null)
            {
                if (desktopFolderEnumeration == null)

                    _ = COMNative.Shell.Shell.SHGetDesktopFolder(out desktopFolderEnumeration);

                nativeShellFolder = desktopFolderEnumeration;
            }

            return new ShellFolderItems(this);
        }
        #endregion

        #region IEnumerable Members
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => new ShellFolderItems(this);
        #endregion
    }
}
