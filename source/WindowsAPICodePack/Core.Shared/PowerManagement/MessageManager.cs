//Copyright (c) Microsoft Corporation.  All rights reserved.

using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using Microsoft.WindowsAPICodePack.Resources;
using Microsoft.WindowsAPICodePack.Win32Native.ApplicationServices;

using static Microsoft.WindowsAPICodePack.ApplicationServices.Guids.EventManager;

namespace Microsoft.WindowsAPICodePack.ApplicationServices
{
    /// <summary>
    /// This class generates .NET events based on Windows messages.  
    /// The PowerRegWindow class processes the messages from Windows.
    /// </summary>
    internal static class MessageManager
    {
        private static readonly object lockObject = new object();
        private static PowerRegWindow window;

        #region Internal static methods

        /// <summary>
        /// Registers a callback for a power event.
        /// </summary>
        /// <param name="eventId">Guid for the event.</param>
        /// <param name="eventToRegister">Event handler for the specified event.</param>
        internal static void RegisterPowerEvent(in Guid eventId, in EventHandler eventToRegister)
        {
            EnsureInitialized();
            window.RegisterPowerEvent(eventId, eventToRegister);
        }

        /// <summary>
        /// Unregisters an event handler for a power event.
        /// </summary>
        /// <param name="eventId">Guid for the event.</param>
        /// <param name="eventToUnregister">Event handler to unregister.</param>
        internal static void UnregisterPowerEvent(in Guid eventId, in EventHandler eventToUnregister)
        {
            EnsureInitialized();
            window.UnregisterPowerEvent(eventId, eventToUnregister);
        }

        #endregion

        /// <summary>
        /// Ensures that the hidden window is initialized and 
        /// listening for messages.
        /// </summary>
        private static void EnsureInitialized()
        {
            lock (lockObject)

                if (window == null)

                    // Create a new hidden window to listen
                    // for power management related window messages.
                    window = new PowerRegWindow();
        }

        /// <summary>
        /// Catch Windows messages and generates events for power specific
        /// messages.
        /// </summary>
        internal class PowerRegWindow : Form
        {
            private readonly Hashtable eventList = new Hashtable();
            private readonly ReaderWriterLock readerWriterLock = new ReaderWriterLock();

            internal PowerRegWindow()
                : base()
            {

            }

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
                if (!eventList.Contains(eventId))
                {
                    _ = Power.RegisterPowerSettingNotification(Handle, eventId);
                    var newList = new ArrayList();
                    _ = newList.Add(eventToRegister);
                    eventList.Add(eventId, newList);
                }
                else
                {
                    var currList = (ArrayList)eventList[eventId];
                    _ = currList.Add(eventToRegister);
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
                if (eventList.Contains(eventId))
                {
                    var currList = (ArrayList)eventList[eventId];
                    currList.Remove(eventToUnregister);
                }
                else

                    throw new InvalidOperationException(LocalizedMessages.MessageManagerHandlerNotRegistered);

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
