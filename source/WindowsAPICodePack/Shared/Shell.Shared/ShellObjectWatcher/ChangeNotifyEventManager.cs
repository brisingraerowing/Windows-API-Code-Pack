using Microsoft.WindowsAPICodePack.Win32Native.Shell;

using System;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.WindowsAPICodePack.Shell
{
    internal class ChangeNotifyEventManager
    {
        #region Change order
        private static readonly ShellObjectChangeTypes[] _changeOrder = {
            ShellObjectChangeTypes.ItemCreate,
            ShellObjectChangeTypes.ItemRename,
            ShellObjectChangeTypes.ItemDelete,

            ShellObjectChangeTypes.AttributesChange,

            ShellObjectChangeTypes.DirectoryCreate,
            ShellObjectChangeTypes.DirectoryDelete,
            ShellObjectChangeTypes.DirectoryContentsUpdate,
            ShellObjectChangeTypes.DirectoryRename,

            ShellObjectChangeTypes.Update,

            ShellObjectChangeTypes.MediaInsert,
            ShellObjectChangeTypes.MediaRemove,
            ShellObjectChangeTypes.DriveAdd,
            ShellObjectChangeTypes.DriveRemove,
            ShellObjectChangeTypes.NetShare,
            ShellObjectChangeTypes.NetUnshare,

            ShellObjectChangeTypes.ServerDisconnect,
            ShellObjectChangeTypes.SystemImageUpdate,

            ShellObjectChangeTypes.AssociationChange,
            ShellObjectChangeTypes.FreeSpace,

            ShellObjectChangeTypes.DiskEventsMask,
            ShellObjectChangeTypes.GlobalEventsMask,
            ShellObjectChangeTypes.AllEventsMask
        };
        #endregion

        private readonly Dictionary<ShellObjectChangeTypes, Delegate> _events = new
#if !CS9
            Dictionary<ShellObjectChangeTypes, Delegate>
#endif
            ();

        public void Register(ShellObjectChangeTypes changeType, Delegate handler)
        {
            if (_events.TryGetValue(changeType, out Delegate del))
            {
                del = Delegate.Combine(del, handler);
                _events[changeType] = del;
            }

            else

                _events.Add(changeType, handler);
        }

        public void Unregister(ShellObjectChangeTypes changeType, Delegate handler)
        {
            if (_events.TryGetValue(changeType, out Delegate del))
            {
                del = Delegate.Remove(del, handler);

                if (del == null) // It's a bug in .NET if del is non-null and has an empty invocation list.

                    _ = _events.Remove(changeType);

                else

                    _events[changeType] = del;
            }
        }

        public void UnregisterAll() => _events.Clear();

        public void Invoke(object sender, ShellObjectChangeTypes changeType, EventArgs args)
        {
            // Removes FromInterrupt flag if pressent
            changeType &= ~ShellObjectChangeTypes.FromInterrupt;

            foreach (ShellObjectChangeTypes change in _changeOrder.Where(x => (x & changeType) != 0))

                if (_events.TryGetValue(change, out Delegate del))

                    _ = del.DynamicInvoke(sender, args);
        }

        public ShellObjectChangeTypes RegisteredTypes => _events.Keys.Aggregate(
                    ShellObjectChangeTypes.None,
                    (accumulator, changeType) => changeType | accumulator);
    }
}
