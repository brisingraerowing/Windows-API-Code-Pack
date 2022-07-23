//Copyright (c) Microsoft Corporation.  All rights reserved.  Distributed under the Microsoft Public License (MS-PL)

using Microsoft.WindowsAPICodePack.Shell.Resources;
using Microsoft.WindowsAPICodePack.Win32Native.Shell;

using System;
using System.ComponentModel;
using System.Threading;

using static Microsoft.WindowsAPICodePack.Win32Native.Shell.ShellObjectChangeTypes;

using static WinCopies.
#if WAPICP3
    ThrowHelper
#else
    Util.Util
#endif
    ;

using SOCT = Microsoft.WindowsAPICodePack.Win32Native.Shell.ShellObjectChangeTypes;

namespace Microsoft.WindowsAPICodePack.Shell
{
    /// <summary>
    /// Listens for changes in/on a ShellObject and raises events when they occur.
    /// This class supports all items under the shell namespace including
    /// files, folders and virtual folders (libraries, search results and network items), etc.
    /// </summary>
    public class ShellObjectWatcher : IDisposable
    {
        private readonly ShellObject _shellObject;
        private readonly bool _recursive;
        private readonly ChangeNotifyEventManager _manager = new
#if !CS9
            ChangeNotifyEventManager
#endif
            ();
        private readonly IntPtr _listenerHandle;
        private readonly uint _message;
        private uint _registrationId;
        private volatile bool _running;
        private readonly SynchronizationContext _context = SynchronizationContext.Current;

        /// <summary>
        /// Creates the ShellObjectWatcher for the given ShellObject
        /// </summary>
        /// <param name="shellObject">The ShellObject to monitor</param>
        /// <param name="recursive">Whether to listen for changes recursively (for when monitoring a container)</param>
        public ShellObjectWatcher(ShellObject shellObject, bool recursive)
        {
            _shellObject = shellObject ?? throw GetArgumentNullException(nameof(shellObject));
            _recursive = recursive;

            if (_context == null)
            {
                _context = new SynchronizationContext();
                SynchronizationContext.SetSynchronizationContext(_context);
            }

            MessageListenerFilterRegistrationResult result = MessageListenerFilter.Register(OnWindowMessageReceived);
            _listenerHandle = result.WindowHandle;
            _message = result.Message;
        }

        /// <summary>
        /// Gets whether the watcher is currently running.
        /// </summary>
        public bool Running { get => _running; private set => _running = value; }

        #region Change Events
        #region Mask Events
        /// <summary>
        /// Raised when any event occurs.
        /// </summary>
        public event EventHandler<ShellObjectNotificationEventArgs> AllEvents
        {
            add => HandleEvent(_manager.Register, AllEventsMask, value);

            remove => HandleEvent(_manager.Unregister, AllEventsMask, value);
        }

        /// <summary>
        /// Raised when global events occur.
        /// </summary>
        public event EventHandler<ShellObjectNotificationEventArgs> GlobalEvents
        {
            add => HandleEvent(_manager.Register, GlobalEventsMask, value);

            remove => HandleEvent(_manager.Unregister, GlobalEventsMask, value);
        }

        /// <summary>
        /// Raised when disk events occur.
        /// </summary>
        public event EventHandler<ShellObjectNotificationEventArgs> DiskEvents
        {
            add => HandleEvent(_manager.Register, DiskEventsMask, value);

            remove => HandleEvent(_manager.Unregister, DiskEventsMask, value);
        }
        #endregion

        #region Single Events
        /// <summary>
        /// Raised when an item is renamed.
        /// </summary>
        public event EventHandler<ShellObjectRenamedEventArgs> ItemRenamed
        {
            add => HandleEvent(_manager.Register, ItemRename, value);

            remove => HandleEvent(_manager.Unregister, ItemRename, value);
        }

        /// <summary>
        /// Raised when an item is created.
        /// </summary>
        public event EventHandler<ShellObjectChangedEventArgs> ItemCreated
        {
            add => HandleEvent(_manager.Register, ItemCreate, value);

            remove => HandleEvent(_manager.Unregister, ItemCreate, value);
        }

        /// <summary>
        /// Raised when an item is deleted.
        /// </summary>
        public event EventHandler<ShellObjectChangedEventArgs> ItemDeleted
        {
            add => HandleEvent(_manager.Register, ItemDelete, value);

            remove => HandleEvent(_manager.Unregister, ItemDelete, value);
        }

        /// <summary>
        /// Raised when an item is updated.
        /// </summary>
        public event EventHandler<ShellObjectChangedEventArgs> Updated
        {
            add => HandleEvent(_manager.Register, SOCT.Update, value);

            remove => HandleEvent(_manager.Unregister, SOCT.Update, value);
        }

        /// <summary>
        /// Raised when a directory is updated.
        /// </summary>
        public event EventHandler<ShellObjectChangedEventArgs> DirectoryUpdated
        {
            add => HandleEvent(_manager.Register, DirectoryContentsUpdate, value);

            remove => HandleEvent(_manager.Unregister, DirectoryContentsUpdate, value);
        }

        /// <summary>
        /// Raised when a directory is renamed.
        /// </summary>
        public event EventHandler<ShellObjectRenamedEventArgs> DirectoryRenamed
        {
            add => HandleEvent(_manager.Register, DirectoryRename, value);

            remove => HandleEvent(_manager.Unregister, DirectoryRename, value);
        }

        /// <summary>
        /// Raised when a directory is created.
        /// </summary>
        public event EventHandler<ShellObjectChangedEventArgs> DirectoryCreated
        {
            add => HandleEvent(_manager.Register, DirectoryCreate, value);

            remove => HandleEvent(_manager.Unregister, DirectoryCreate, value);
        }

        /// <summary>
        /// Raised when a directory is deleted.
        /// </summary>
        public event EventHandler<ShellObjectChangedEventArgs> DirectoryDeleted
        {
            add => HandleEvent(_manager.Register, DirectoryDelete, value);

            remove => HandleEvent(_manager.Unregister, DirectoryDelete, value);
        }

        /// <summary>
        /// Raised when media is inserted.
        /// </summary>
        public event EventHandler<ShellObjectChangedEventArgs> MediaInserted
        {
            add => HandleEvent(_manager.Register, MediaInsert, value);

            remove => HandleEvent(_manager.Unregister, MediaInsert, value);
        }

        /// <summary>
        /// Raised when media is removed.
        /// </summary>
        public event EventHandler<ShellObjectChangedEventArgs> MediaRemoved
        {
            add => HandleEvent(_manager.Register, MediaRemove, value);

            remove => HandleEvent(_manager.Unregister, MediaRemove, value);
        }

        /// <summary>
        /// Raised when a drive is added.
        /// </summary>
        public event EventHandler<ShellObjectChangedEventArgs> DriveAdded
        {
            add => HandleEvent(_manager.Register, DriveAdd, value);

            remove => HandleEvent(_manager.Unregister, DriveAdd, value);
        }

        /// <summary>
        /// Raised when a drive is removed.
        /// </summary>
        public event EventHandler<ShellObjectChangedEventArgs> DriveRemoved
        {
            add => HandleEvent(_manager.Register, DriveRemove, value);

            remove => HandleEvent(_manager.Unregister, DriveRemove, value);
        }

        /// <summary>
        /// Raised when a folder is .Shared on a network.
        /// </summary>
        public event EventHandler<ShellObjectChangedEventArgs> FolderNetworkShared
        {
            add => HandleEvent(_manager.Register, NetShare, value);

            remove => HandleEvent(_manager.Unregister, NetShare, value);
        }

        /// <summary>
        /// Raised when a folder is un.Shared from the network.
        /// </summary>
        public event EventHandler<ShellObjectChangedEventArgs> FolderNetworkUnShared
        {
            add => HandleEvent(_manager.Register, NetUnshare, value);

            remove => HandleEvent(_manager.Unregister, NetUnshare, value);
        }

        /// <summary>
        /// Raised when a server is disconnected.
        /// </summary>
        public event EventHandler<ShellObjectChangedEventArgs> ServerDisconnected
        {
            add => HandleEvent(_manager.Register, ServerDisconnect, value);

            remove => HandleEvent(_manager.Unregister, ServerDisconnect, value);
        }

        /// <summary>
        /// Raised when a system image is changed.
        /// </summary>
        public event EventHandler<ShellObjectChangedEventArgs> SystemImageChanged
        {
            add => HandleEvent(_manager.Register, SystemImageUpdate, value);

            remove => HandleEvent(_manager.Unregister, SystemImageUpdate, value);
        }

        /// <summary>
        /// Raised when free space changes.
        /// </summary>
        public event EventHandler<ShellObjectChangedEventArgs> FreeSpaceChanged
        {
            add => HandleEvent(_manager.Register, FreeSpace, value);

            remove => HandleEvent(_manager.Unregister, FreeSpace, value);
        }

        /// <summary>
        /// Raised when a file type association changes.
        /// </summary>
        public event EventHandler<ShellObjectChangedEventArgs> FileTypeAssociationChanged
        {
            add => HandleEvent(_manager.Register, AssociationChange, value);

            remove => HandleEvent(_manager.Unregister, AssociationChange, value);
        }
        #endregion
        #endregion

        /// <summary>
        /// Start the watcher and begin receiving change notifications.        
        /// <remarks>
        /// If the watcher is running, has no effect.
        /// Registration for notifications should be done before this is called.
        /// </remarks>
        /// </summary>
        public void Start()
        {
            if (Running) return;

            #region Registration
            var entry = new SHChangeNotifyEntry
            {
                recursively = _recursive,

                pIdl = _shellObject.PIDL
            };

            _registrationId = Win32Native.Shell.Shell.SHChangeNotifyRegister(
                _listenerHandle,
                ShellChangeNotifyEventSource.ShellLevel | ShellChangeNotifyEventSource.InterruptLevel | ShellChangeNotifyEventSource.NewDelivery,
                 _manager.RegisteredTypes, //ShellObjectChangeTypes.AllEventsMask,
                _message,
                1,
                ref entry);

            if (_registrationId == 0)

                throw new Win32Exception(LocalizedMessages.ShellObjectWatcherRegisterFailed);
            #endregion

            Running = true;
        }

        /// <summary>
        /// Stop the watcher and prevent further notifications from being received.
        /// <remarks>If the watcher is not running, this has no effect.</remarks>
        /// </summary>
        public void Stop()
        {
            if (!Running) return;

            if (_registrationId > 0)
            {
                _ = Win32Native.Shell.Shell.SHChangeNotifyDeregister(_registrationId);
                _registrationId = 0;
            }

            Running = false;
        }

        private void OnWindowMessageReceived(WindowMessageEventArgs e)
        {
            if (e.Message.Msg == _message)

                _context.Send(x => ProcessChangeNotificationEvent(e), null);
        }

        private void ThrowIfRunning()
        {
            if (Running)

                throw new InvalidOperationException(LocalizedMessages.ShellObjectWatcherUnableToChangeEvents);
        }

        /// <summary>
        /// Processes all change notifications sent by the Windows Shell.
        /// </summary>
        /// <param name="e">The windows message representing the notification event</param>
        protected virtual void ProcessChangeNotificationEvent(WindowMessageEventArgs e)
        {
            if (!Running) return;

            if (e == null) throw GetArgumentNullException(nameof(e));

            var notifyLock = new ChangeNotifyLock(e.Message);

            ShellObjectNotificationEventArgs args;

            switch (notifyLock.ChangeType)
            {
                case DirectoryRename:
                case ItemRename:
                    args = new ShellObjectRenamedEventArgs(notifyLock);
                    break;
                case SystemImageUpdate:
                    args = new SystemImageUpdatedEventArgs(notifyLock);
                    break;
                default:
                    args = new ShellObjectChangedEventArgs(notifyLock);
                    break;
            }

            _manager.Invoke(this, notifyLock.ChangeType, args);
        }

        protected void HandleEvent(in Action<ShellObjectChangeTypes, Delegate> action, in ShellObjectChangeTypes shellObjectChangeTypes, Delegate @delegate)
        {
            ThrowIfRunning();

            (action ?? throw GetArgumentNullException(nameof(action)))(shellObjectChangeTypes, @delegate);
        }

        #region IDisposable Members
        /// <summary>
        /// Disposes ShellObjectWatcher
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            Stop();
            _manager.UnregisterAll();

            if (_listenerHandle != IntPtr.Zero)

                MessageListenerFilter.Unregister(_listenerHandle, _message);
        }

        /// <summary>
        /// Disposes ShellObjectWatcher.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Finalizer for ShellObjectWatcher
        /// </summary>
        ~ShellObjectWatcher() => Dispose(false);
        #endregion
    }
}
