//Copyright (c) Microsoft Corporation.  All rights reserved.

using Microsoft.WindowsAPICodePack.ApplicationServices;
using System;
using static Microsoft.WindowsAPICodePack.ApplicationServices.Guids.PowerPersonality;

namespace Microsoft.WindowsAPICodePack.Win32Native.ApplicationServices
{
    public static class PowerPersonalityGuids
    {

      public static PowerPersonality GuidToEnum(string guid) => guid ==  HighPerformance
                ? PowerPersonality.HighPerformance
                : guid == PowerSaver ? PowerPersonality.PowerSaver : guid == Automatic ? PowerPersonality.Automatic : PowerPersonality.Unknown;
    }
}
