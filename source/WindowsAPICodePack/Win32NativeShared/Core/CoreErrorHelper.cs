//Copyright (c) Microsoft Corporation.  All rights reserved.

namespace Microsoft.WindowsAPICodePack.Win32Native
{

    //// todo: to add the other error codes

    ///// <summary>
    ///// HRESULT Wrapper    
    ///// </summary>    
    //public enum HResult
    //{
    //    /// <summary>     
    //    /// S_OK          
    //    /// </summary>    
    //    Ok = 0x0000,

    //    /// <summary>
    //    /// NOERROR
    //    /// </summary>
    //    NoError = Ok,

    //    /// <summary>
    //    /// S_FALSE
    //    /// </summary>        
    //    False = 0x0001,

    //    /// <summary>
    //    /// Catastrophic failure (E_UNEXPECTED)
    //    /// </summary>
    //    Unexpected = unchecked((int)0x8000FFFF),

    //    /// <summary>
    //    /// Not implemented (E_NOTIMPL)
    //    /// </summary>
    //    NotImplemented = unchecked((int)0x80004001),

    //    /// <summary>
    //    /// Ran out of memory (E_OUTOFMEMORY)
    //    /// </summary>
    //    OutOfMemory = unchecked((int)0x8007000E),

    //    /// <summary>
    //    /// One or more arguments are invalid (E_INVALIDARG)
    //    /// </summary>
    //    InvalidArguments = unchecked((int)0x80070057),

    //    /// <summary>
    //    /// No such interface supported (E_NOINTERFACE)
    //    /// </summary>
    //    NoInterface = unchecked((int)0x80004002),

    //    /// <summary>
    //    /// Invalid pointer (E_POINTER)
    //    /// </summary>
    //    InvalidPointer = unchecked((int)0x80004003),

    //    /// <summary>
    //    /// Operation aborted (E_ABORT)
    //    /// </summary>
    //    OperationAborted = unchecked((int)0x80004004),

    //    /// <summary>
    //    /// Unspecified error (E_FAIL)
    //    /// </summary>
    //    Fail = unchecked((int)0x80004005),

    //    /// <summary>
    //    /// E_ELEMENTNOTFOUND
    //    /// </summary>
    //    ElementNotFound = unchecked((int)0x80070490),

    //    /// <summary>
    //    /// TYPE_E_ELEMENTNOTFOUND (TYPE_E_ELEMENTNOTFOUND)
    //    /// </summary>
    //    TypeElementNotFound = unchecked((int)0x8002802B),

    //    /// <summary>
    //    /// No object for moniker. (MK_E_NOOBJECT)
    //    /// </summary>
    //    NoObject = unchecked((int)0x800401E5),

    //    /// <summary>
    //    /// Access denied. (STG_E_ACCESSDENIED)
    //    /// </summary>
    //    AccessDenied = unchecked((int)0x80030005),

    //    /// <summary>
    //    /// OpenClipboard failed.
    //    /// </summary>
    //    CLIPBRD_E_CANT_OPEN = unchecked((int)0x800401D0),

    //    /// <summary>
    //    /// EmptyClipboard failed.
    //    /// </summary>
    //    CLIPBRD_E_CANT_EMPTY = unchecked((int)0x800401D1),

    //    /// <summary>
    //    /// CloseClipboard failed.
    //    /// </summary>
    //    CLIPBRD_E_CANT_CLOSE = unchecked((int)0x800401D4),

    //    /// <summary>
    //    /// SetClipboard failed.
    //    /// </summary>
    //    CLIPBRD_E_CANT_SET = unchecked((int)0x800401D2)
    //}

    /// <summary>
    /// Provide Error Message Helper Methods.
    /// This is intended for unmanaged code use only.
    /// </summary>
    public static class CoreErrorHelper
    {

        /// <summary>
        /// This is intended for Library Internal use only.
        /// </summary>
        public const int Ignored = (int)HResult.Ok;

        /// <summary>
        /// This is intended for Library Internal use only.
        /// </summary>
        /// <param name="win32ErrorCode">The Windows API error code.</param>
        /// <returns>The equivalent HRESULT.</returns>
        public static int HResultFromWin32(int win32ErrorCode)
        {
            if (win32ErrorCode > 0)

                win32ErrorCode =
                    (int)(((uint)win32ErrorCode & 0x0000FFFF) | ( (int) HResultFacility.Win32 << 16) | 0x80000000);

            return win32ErrorCode;

        }

        public static HResult HResultFromWin32(ErrorCode win32ErrorCode) => (HResult) HResultFromWin32((int)win32ErrorCode);

        /// <summary>
        /// This is intended for Library Internal use only.
        /// </summary>
        /// <param name="result">The error code.</param>
        /// <returns>True if the error code indicates success.</returns>
        public static bool Succeeded(int result) => result >= 0;

        /// <summary>
        /// This is intended for Library Internal use only.
        /// </summary>
        /// <param name="result">The error code.</param>
        /// <returns>True if the error code indicates success.</returns>
        public static bool Succeeded(HResult result) => Succeeded((int)result);

        /// <summary>
        /// This is intended for Library Internal use only.
        /// </summary>
        /// <param name="result">The error code.</param>
        /// <returns>True if the error code indicates failure.</returns>
        public static bool Failed(HResult result) => !Succeeded(result);

        /// <summary>
        /// This is intended for Library Internal use only.
        /// </summary>
        /// <param name="result">The error code.</param>
        /// <returns>True if the error code indicates failure.</returns>
        public static bool Failed(int result) => !Succeeded(result);

        /// <summary>
        /// This is intended for Library Internal use only.
        /// </summary>
        /// <param name="result">The COM error code.</param>
        /// <param name="win32ErrorCode">The Win32 error code.</param>
        /// <returns>Inticates that the Win32 error code corresponds to the COM error code.</returns>
        public static bool Matches(int result, int win32ErrorCode) => result == HResultFromWin32(win32ErrorCode);
    }
}
