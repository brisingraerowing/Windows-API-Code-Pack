//Copyright (c) Microsoft Corporation.  All rights reserved.  Distributed under the Microsoft Public License (MS-PL)

using System;
using System.Runtime.InteropServices;

namespace Microsoft.WindowsAPICodePack.Win32Native
{
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
        /// <see cref="HResult.Ok"/> value.
        /// </summary>
        public const int Ignored = (int)HResult.Ok;

        /// <summary>
        /// Returns an HRESULT from a given Win32 error code.
        /// </summary>
        /// <param name="win32ErrorCode">The Windows API error code.</param>
        /// <returns>The equivalent HRESULT.</returns>
        public static int HResultFromWin32(in int win32ErrorCode) => win32ErrorCode > 0 ? (int)(((uint)win32ErrorCode & 0x0000FFFF) | ((int)HResultFacility.Win32 << 16) | 0x80000000) : win32ErrorCode;

        /// <summary>
        /// Returns an <see cref="HResult"/> from a given <see cref="ErrorCode"/>.
        /// </summary>
        /// <param name="win32ErrorCode">The Windows API error code.</param>
        /// <returns>The equivalent <see cref="HResult"/>.</returns>
        public static HResult HResultFromWin32(in ErrorCode win32ErrorCode) => (HResult)HResultFromWin32((int)win32ErrorCode);

        /// <summary>
        /// Determines whether a given error code indicates success.
        /// </summary>
        /// <param name="result">The error code.</param>
        /// <returns><see langword="true"/> if the error code indicates success; otherwise <see langword="false"/>.</returns>
        public static bool Succeeded(in int result) => result >= 0;

        /// <summary>
        /// Determines whether a given <see cref="ErrorCode"/> indicates success.
        /// </summary>
        /// <param name="result">The error code.</param>
        /// <returns><see langword="true"/> if the error code indicates success; otherwise <see langword="false"/>.</returns>
        public static bool Succeeded(in ErrorCode result) => result >= 0;

        /// <summary>
        /// Determines whether a given <see cref="HResult"/> indicates success.
        /// </summary>
        /// <param name="result">The error code.</param>
        /// <returns><see langword="true"/> if the error code indicates success; otherwise <see langword="false"/>.</returns>
        public static bool Succeeded(in HResult result) => Succeeded((int)result);

        /// <summary>
        /// Determines whether a given <see cref="HResult"/> indicates failure.
        /// </summary>
        /// <param name="result">The error code.</param>
        /// <returns><see langword="true"/> if the error code indicates failure; otherwise <see langword="false"/>.</returns>
        public static bool Failed(in HResult result) => !Succeeded(result);

        /// <summary>
        /// Determines whether a given error code indicates failure.
        /// </summary>
        /// <param name="result">The error code.</param>
        /// <returns><see langword="true"/> if the error code indicates failure; otherwise <see langword="false"/>.</returns>
        public static bool Failed(in int result) => !Succeeded(result);

        /// <summary>
        /// Determines whether a given HRESULT corresponds to a given Win32 error code.
        /// </summary>
        /// <param name="result">The COM error code.</param>
        /// <param name="win32ErrorCode">The Win32 error code.</param>
        /// <returns><see langword="true"/> if <paramref name="result"/> corresponds to <paramref name="win32ErrorCode"/>; otherwise <see langword="false"/>.</returns>
        public static bool Matches(in int result, in int win32ErrorCode) => result == HResultFromWin32(win32ErrorCode);

        /// <summary>
        /// Determines whether a given <see cref="HResult"/> corresponds to a given <see cref="ErrorCode"/>.
        /// </summary>
        /// <param name="result">The COM error code.</param>
        /// <param name="win32ErrorCode">The Win32 error code.</param>
        /// <returns><see langword="true"/> if <paramref name="result"/> corresponds to <paramref name="win32ErrorCode"/>; otherwise <see langword="false"/>.</returns>
        public static bool Matches(in HResult result, in ErrorCode win32ErrorCode) => result == HResultFromWin32(win32ErrorCode);

        public static void ThrowExceptionForHR(in HResult hresult) => Marshal.ThrowExceptionForHR((int)hresult);

        public static Exception GetExceptionForHR(in HResult hResult) => Marshal.GetExceptionForHR((int)hResult);

        public static Exception GetExceptionForHR(in HResult hResult, in IntPtr errorInfo) => Marshal.GetExceptionForHR((int)hResult, errorInfo);

        public static HResult GetHRForException(in Exception ex) => (HResult)Marshal.GetHRForException(ex);

        public static T GetIfSucceeded<T>(in T value, in HResult hResult) => Succeeded(hResult) ? value : throw GetExceptionForHR(hResult);

        // TODO: replace by WinCopies.FuncOut:

        public delegate HResult FuncOut<T>(out T param);

        public static T GetIfSucceeded<T>(in FuncOut<T> func)
        {
            HResult hr = (func ?? throw WinCopies.
#if WAPICP3
                ThrowHelper
#else
                Util.Util
#endif
                .GetArgumentNullException(nameof(func)))(out T param);

            return GetIfSucceeded(param, hr);
        }
    }
}
