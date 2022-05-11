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
    public abstract class ShellContainer : ShellObject, IEnumerable<ShellObject>, System.IDisposable
    {
        #region Private Fields
        private IShellFolder _desktopFolderEnumeration;
        private IShellFolder _nativeShellFolder;
        #endregion

        #region Internal Properties
        internal IShellFolder NativeShellFolder
        {
            get
            {
                if (_nativeShellFolder == null)
                {
                    var guid = new Guid(NativeAPI.Guids.Shell.IShellFolder);
                    var handler = new Guid(Guids.ShellBindingHandlerID.ShellFolderObject);

                    HResult hr = NativeShellItem.BindToHandler(
                        IntPtr.Zero, ref handler, ref guid, out _nativeShellFolder);

                    if (CoreErrorHelper.Failed(hr))
                    {
                        string str = ShellHelper.GetParsingName(NativeShellItem);

                        if (str != null && str != Environment.GetFolderPath(Environment.SpecialFolder.Desktop))

                            throw new ShellException(hr);
                    }
                }

                return _nativeShellFolder;
            }
        }
        #endregion

        #region Internal Constructor
        internal ShellContainer() { /* Left empty. */ }

        internal ShellContainer(IShellItem2 shellItem) : base(shellItem) { /* Left empty. */ }
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
            {
                _ = Win32Native.Shell.Shell.SHBindToParent(items[i].PIDL, new Guid(NativeAPI.Guids.Shell.IShellFolder), out object ppv, out IntPtr pidl);

                pidls[i] = pidl;

                CoreHelpers.DisposeCOMObject(ref ppv);
            }

            return pidls;
        }

        /*public static IntPtr[] GetPIDLs(
#if CS6
            System.
#else
            WinCopies.
#endif
            Collections.Generic.IReadOnlyList<ShellObject> items, string parent = null)
        {
            FuncIn<int, IntPtr> func = parent == null ? (in int i) => COMNative.Shell.Shell.GetPidl(items[i].ParsingName) :
#if !CS9
                (FuncIn<int, IntPtr>)(
#endif
                (in int i) => COMNative.Shell.Shell.GetPidl(parent, items[i].Name)
#if !CS9
                )
#endif
                ;

            var pidls = new IntPtr[items.Count];

            for (int i = 0; i < items.Count; i++)

                pidls[i] = func(i);

            return pidls;
        }

        public static IntPtr[] GetPIDLsRel(
#if CS6
            System.
#else
            WinCopies.
#endif
            Collections.Generic.IReadOnlyList<ShellObject> items)
        {
            var pidls = new IntPtr[items.Count];

            for (int i = 0; i < items.Count; i++)

                pidls[i] = items[i].PIDLRel;

            return pidls;
        }*/

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
            CoreHelpers.DisposeCOMObject(ref _nativeShellFolder);
            CoreHelpers.DisposeCOMObject(ref _desktopFolderEnumeration);

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
                if (_desktopFolderEnumeration == null)

                    _ = COMNative.Shell.Shell.SHGetDesktopFolder(out _desktopFolderEnumeration);

                _nativeShellFolder = _desktopFolderEnumeration;
            }

            return new ShellFolderItems(this);
        }
        #endregion

        #region IEnumerable Members
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => new ShellFolderItems(this);
        #endregion
    }
}
