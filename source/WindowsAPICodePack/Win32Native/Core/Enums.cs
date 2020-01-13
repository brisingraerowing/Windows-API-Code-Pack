using System;
using System.Collections.Generic;
using System.Text;

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
}
