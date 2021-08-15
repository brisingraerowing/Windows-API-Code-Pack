using Microsoft.WindowsAPICodePack.PropertySystem;
using Microsoft.WindowsAPICodePack.Win32Native;
using Microsoft.WindowsAPICodePack.Win32Native.PropertySystem;

using System;
using System.Runtime.InteropServices;

namespace Microsoft.WindowsAPICodePack.COMNative.Shell.PropertySystem
{
    /// <summary>
    /// Exposes methods for several multiple change operations that may be passed to <see cref="IFileOperation"/>.
    /// </summary>
    /// <remarks>Either call CoCreateInstance with a class identifier (CLSID) of CLSID_PropertyChangeArray or call PSCreatePropertyChangeArray to obtain a standard implementation of this interface. This is a container interface that allows multiple changes to be passed to a single file operation to prevent accessing a file multiple times.</remarks>
    [ComImport,
    Guid(NativeAPI.Guids.Shell.PropertySystem.IPropertyChangeArray),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IPropertyChangeArray
    {
        /// <summary>
        /// Gets the number of change operations in the array.
        /// </summary>
        /// <param name="pcOperations">A pointer to the number of change operations.</param>
        /// <returns>Always returns <see cref="HResult.Ok"/>.</returns>
        HResult GetCount(ref uint pcOperations);

        /// <summary>
        /// Gets the change operation at a specified array index.
        /// </summary>
        /// <param name="iIndex">The index of the change to retrieve.</param>
        /// <param name="riid">A reference to the desired IID.</param>
        /// <param name="ppv">The address of a pointer to the interface specified by riid, usually <see cref="IPropertyChange"/>.</param>
        /// <returns>If this method succeeds, it returns <see cref="HResult.Ok"/>. Otherwise, it returns an <see cref="HResult"/> error code.</returns>
        HResult GetAt(uint iIndex, ref Guid riid, object ppv);

        /// <summary>
        /// Inserts a change operation into an array at the specified position.
        /// </summary>
        /// <param name="iIndex">The index at which the change is inserted.</param>
        /// <param name="ppropChange">A pointer to the interface that contains the change.</param>
        /// <returns>If this method succeeds, it returns <see cref="HResult.Ok"/>. Otherwise, it returns an <see cref="HResult"/> error code.</returns>
        HResult InsertAt(uint iIndex, ref IPropertyChange ppropChange);

        /// <summary>
        /// Inserts a change operation at the end of an array.
        /// </summary>
        /// <param name="ppropChange">A pointer to the interface that contains the change.</param>
        /// <returns>If this method succeeds, it returns <see cref="HResult.Ok"/>. Otherwise, it returns an <see cref="HResult"/> error code.</returns>
        HResult Append(ref IPropertyChange ppropChange);

        /// <summary>
        /// Replaces the first occurrence of a change that affects the same property key as the provided change. If the property key is not already in the array, this method appends the change to the end of the array.
        /// </summary>
        /// <param name="ppropChange">A pointer to the interface that contains the change</param>
        /// <returns>Returns <see cref="HResult.Ok"/> if successful, or an error value otherwise.</returns>
        HResult AppendOrReplace(ref IPropertyChange ppropChange);

        /// <summary>
        /// Removes a specified change.
        /// </summary>
        /// <param name="iIndex">The index of the change to remove.</param>
        /// <returns>If this method succeeds, it returns <see cref="HResult.Ok"/>. Otherwise, it returns an <see cref="HResult"/> error code.</returns>
        HResult RemoveAt(uint iIndex);

        /// <summary>
        /// Specifies whether a particular property key exists in the change array.
        /// </summary>
        /// <param name="key">A reference to the <see cref="PropertyKey"/> structure of interest.</param>
        /// <returns>Returns <see cref="HResult.Ok"/> if key is found; otherwise, E_FAIL.</returns>
        HResult IsKeyInArray(ref PropertyKey key);
    }

    /// <summary>
    /// Exposes a method that encapsulates a change to a single property.
    /// </summary>
    [ComImport,
    Guid(NativeAPI.Guids.Shell.PropertySystem.IPropertyChange),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IPropertyChange
    {
        /// <summary>
        /// Applies a change to a property value.
        /// </summary>
        /// <param name="propvarIn">A reference to a source <see cref="PropVariant"/> structure.</param>
        /// <param name="ppropvarOut">A pointer to a changed <see cref="PropVariant"/> structure.</param>
        /// <returns>If this method succeeds, it returns <see cref="HResult.Ok"/>. Otherwise, it returns an <see cref="HResult"/> error code.</returns>
        HResult ApplyToPropVariant(PropVariant propvarIn, PropVariant ppropvarOut);
    }
}
