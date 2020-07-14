//Copyright (c) Microsoft Corporation.  All rights reserved.  Distributed under the Microsoft Public License (MS-PL)

using System;
using System.Threading;

using static Microsoft.WindowsAPICodePack.ApplicationServices.Guids.EventManager;

namespace Microsoft.WindowsAPICodePack.ApplicationServices
{
    /// <summary>
    /// This class keeps track of the current state of each type of event.  
    /// The MessageManager class tracks event handlers.  
    /// This class only deals with each event type (i.e.
    /// BatteryLifePercentChanged) as a whole.
    /// </summary>
    internal static class EventManager
    {
        // Prevents reading from PowerManager members while they are still null.
        // MessageManager notifies the PowerManager that the member 
        // has been set and can be used.        
        internal static AutoResetEvent monitorOnReset = new AutoResetEvent(false);

        #region private static members

        // Used to catch the initial message Windows sends when 
        // you first register for a power notification.
        // We do not want to fire any event handlers when this happens.
        private static bool personalityCaught;
        private static bool powerSrcCaught;
        private static bool batteryLifeCaught;
        private static bool monitorOnCaught;

        #endregion

        /// <summary>
        /// Determines if a message should be caught, preventing
        /// the event handler from executing. 
        /// This is needed when an event is initially registered.
        /// </summary>
        /// <param name="eventGuid">The event to check.</param>
        /// <returns>A boolean value. Returns true if the 
        /// message should be caught.</returns>
        internal static bool IsMessageCaught(in string eventGuid)
        {
            if (eventGuid == BatteryCapacityChange)
            {
                if (!batteryLifeCaught)
                {
                    batteryLifeCaught = true;
                    return true;
                }
            }
            else if (eventGuid == MonitorPowerStatus)
            {
                if (!monitorOnCaught)
                {
                    monitorOnCaught = true;
                    return true;
                }
            }
            else if (eventGuid == PowerPersonalityChange)
            {
                if (!personalityCaught)
                {
                    personalityCaught = true;
                    return true;
                }
            }
            else if (eventGuid == PowerSourceChange)
            
                if (!powerSrcCaught)
                {
                    powerSrcCaught = true;
                    return true;
                }
            
            return false;
        }
    }
}
