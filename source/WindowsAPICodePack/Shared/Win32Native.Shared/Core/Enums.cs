﻿using System;

namespace Microsoft.WindowsAPICodePack.Win32Native
{
    ////////////////////////////////////////////////////////////////////
    //                                                                //
    //           Security Quality Of Service                          //
    //                                                                //
    //                                                                //
    ////////////////////////////////////////////////////////////////////

    // begin_wdm
    //
    // Impersonation Level
    //

    /// <summary>
    /// Impersonation level is represented by a pair of bits in Windows.
    /// If a new impersonation level is added or lowest value is changed from
    /// 0 to something else, fix the Windows CreateFile call.
    /// </summary>
    public enum SecurityImpersonationLevel : uint
    {
        SecurityAnonymous,
        SecurityIdentification,
        SecurityImpersonation,
        SecurityDelegation
    }

    /// <summary>
    /// The generic rights.
    /// </summary>
    [Flags]
    public enum GenericRights : uint
    {
        All = 0x10000000,
        Execute = 0x20000000,
        Write = 0x40000000,
        Read = 0x80000000
    }

    [Flags]
    public enum FileShareOptions : uint
    {
        Read = 0x00000001,
        Write = 0x00000002,
        Delete = 0x00000004
    }

    [Flags]
    public enum ShowWindowCommands
    {
        Hide = 0,
        ShowNormal = Normal,
        Normal = 1,
        ShowMinimized = 2,
        ShowMaximized = Maximize,
        Maximize = 3,
        ShowNoActivate = 4,
        Show = 5,
        Minimize = 6,
        ShowMinNoActive = 7,
        ShowNA = 8,
        Restore = 9,
        ShowDefault = 10,
        ForceMinimize = Max,
        Max = 11
    }
}
