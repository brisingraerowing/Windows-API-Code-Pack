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
}
