//Copyright (c) Microsoft Corporation.  All rights reserved.  Distributed under the Microsoft Public License (MS-PL)

using Microsoft.WindowsAPICodePack.Resources;
using Microsoft.WindowsAPICodePack.Win32Native.ApplicationServices;

using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

using static Microsoft.WindowsAPICodePack.ApplicationServices.Guids.EventManager;

namespace Microsoft.WindowsAPICodePack.ApplicationServices
{
    /// <summary>
    /// This class generates .NET events based on Windows messages.  
    /// The PowerRegWindow class processes the messages from Windows.
    /// </summary>
    internal static class MessageManager
    {
        private static readonly object lockObject = new
#if !CS9
            object
#endif
            ();
        private static PowerRegWindow window;

        #region Methods
        /// <summary>
        /// Ensures that the hidden window is initialized and 
        /// listening for messages.
        /// </summary>
        private static void EnsureInitialized(in Action action)
        {
            lock (lockObject)

                if (window == null)

                    // Create a new hidden window to listen
                    // for power management related window messages.
                    window = new PowerRegWindow();

            action();
        }

        #region Internal Static Methods
        /// <summary>
        /// Registers a callback for a power event.
        /// </summary>
        /// <param name="eventId">Guid for the event.</param>
        /// <param name="eventToRegister">Event handler for the specified event.</param>
        internal static void RegisterPowerEvent(Guid eventId, EventHandler eventToRegister) => EnsureInitialized(() => window.RegisterPowerEvent(eventId, eventToRegister));

        /// <summary>
        /// Unregisters an event handler for a power event.
        /// </summary>
        /// <param name="eventId">Guid for the event.</param>
        /// <param name="eventToUnregister">Event handler to unregister.</param>
        internal static void UnregisterPowerEvent(Guid eventId, EventHandler eventToUnregister) => EnsureInitialized(() => window.UnregisterPowerEvent(eventId, eventToUnregister));
        #endregion Internal Static Methods
        #endregion Methods

        /// <summary>
        /// Catch Windows messages and generates events for power specific
        /// messages.
        /// </summary>
        internal class PowerRegWindow : Form
        {
            private readonly Hashtable eventList = new
#if !CS9
                Hashtable
#endif
                ();
            private readonly ReaderWriterLock readerWriterLock = new
#if !CS9
                ReaderWriterLock
#endif
                ();

            internal PowerRegWindow() : base() { /* Left empty. */ }

            #region Internal Methods
            /// <summary>
            /// Adds an event handler to call when Windows sends 
            /// a message for an event.
            /// </summary>
            /// <param name="eventId">Guid for the event.</param>
            /// <param name="eventToRegister">Event handler for the event.</param>
            internal void RegisterPowerEvent(in Guid eventId, in EventHandler eventToRegister)
            {
                readerWriterLock.AcquireWriterLock(Timeout.Infinite);

                if (eventList.Contains(eventId))

                    _ = ((ArrayList)eventList[eventId]).Add(eventToRegister);

                else
                {
                    _ = Power.RegisterPowerSettingNotification(Handle, eventId);
                    var newList = new ArrayList();
                    _ = newList.Add(eventToRegister);
                    eventList.Add(eventId, newList);
                }

                readerWriterLock.ReleaseWriterLock();
            }

            /// <summary>
            /// Removes an event handler.
            /// </summary>
            /// <param name="eventId">Guid for the event.</param>
            /// <param name="eventToUnregister">Event handler to remove.</param>
            /// <exception cref="InvalidOperationException">Cannot unregister 
            /// a function that is not registered.</exception>
            internal void UnregisterPowerEvent(in Guid eventId, in EventHandler eventToUnregister)
            {
                readerWriterLock.AcquireWriterLock(Timeout.Infinite);

                ((ArrayList)(eventList.Contains(eventId) ? eventList : throw new InvalidOperationException(LocalizedMessages.MessageManagerHandlerNotRegistered))[eventId]).Remove(eventToUnregister);

                readerWriterLock.ReleaseWriterLock();
            }

            #endregion

            /// <summary>
            /// Executes any registered event handlers.
            /// </summary>
            /// <param name="eventHandlerList">ArrayList of event handlers.</param>            
            private static void ExecuteEvents(in ArrayList eventHandlerList)
            {
                foreach (EventHandler handler in eventHandlerList)

                    handler.Invoke(null, new EventArgs());
            }

            /// <summary>
            /// This method is called when a Windows message 
            /// is sent to this window.
            /// The method calls the registered event handlers.
            /// </summary>
            protected override void WndProc(ref Message m)
            {
                // Make sure it is a Power Management message.
                if (m.Msg == PowerManagementNativeMethods.PowerBroadcastMessage &&
                    (int)m.WParam == PowerManagementNativeMethods.PowerSettingChangeMessage)
                {
                    var ps =
                         (PowerManagementNativeMethods.PowerBroadcastSetting)Marshal.PtrToStructure(
                             m.LParam, typeof(PowerManagementNativeMethods.PowerBroadcastSetting));

                    var pData = new IntPtr(m.LParam.ToInt64() + Marshal.SizeOf(ps));
                    string currentEvent = ps.PowerSetting.ToString();

                    // IsMonitorOn
                    if (currentEvent == MonitorPowerStatus &&
                        ps.DataLength == Marshal.SizeOf(typeof(int)))
                    {
                        int monitorStatus = (int)Marshal.PtrToStructure(pData, typeof(int));
                        PowerManager.IsMonitorOn = monitorStatus != 0;
                        _ = EventManager.monitorOnReset.Set();
                    }

                    if (!EventManager.IsMessageCaught(currentEvent))

                        ExecuteEvents((ArrayList)eventList[currentEvent]);
                }

                else

                    base.WndProc(ref m);
            }
        }
    }
}
