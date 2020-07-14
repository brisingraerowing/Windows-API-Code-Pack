using Microsoft.WindowsAPICodePack.Win32Native;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Microsoft.WindowsAPICodePack.COMNative.COM
{
    /// <summary>
    /// Specifies a counted array of <see cref="Guid"/> types used to receive an array of CLSIDs for the property pages that the object wants to display.
    /// </summary>
    /// <seealso cref="ISpecifyPropertyPages.GetPages(out CAUUID)"/>
    public struct CAUUID
    {
        /// <summary>
        /// The size of the array pointed to by <see cref="pElems"/>.
        /// </summary>
        public uint cElems;
        /// <summary>
        /// A pointer to an array of values, each of which specifies a CLSID of a particular property page. This array is allocated by the callee using <see cref="Marshal.AllocCoTaskMem(int)"/> and is freed by the caller using <see cref="Marshal.FreeCoTaskMem(IntPtr)"/>.
        /// </summary>
        public IntPtr pElems;
    }

    /// <summary>
    /// Indicates that an object supports property pages. OLE property pages enable an object to display its properties in a tabbed dialog box known as a property sheet. An end user can then view and change the object's properties. An object can display its property pages independent of its client, or the client can manage the display of property pages from a number of contained objects in a single property sheet. Property pages also provide a means for notifying a client of changes in an object's properties.
    /// </summary>
    /// <remarks><para>A property page object manages a particular page within a property sheet. A property page implements at least IPropertyPage and can optionally implement IPropertyPage2 if selection of a specific property is supported.</para>
    /// <para>An object specifies its support for property pages by implementing <see cref="ISpecifyPropertyPages"/>. Through this interface the caller can obtain a list of CLSIDs identifying the specific property pages that the object supports. If the object specifies a property page CLSID, the object must be able to receive property changes from the property page.</para></remarks>
    [ComImport,
        Guid(NativeAPI.Guids.COM.ISpecifyPropertyPages),
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ISpecifyPropertyPages
    {
        /// <summary>
        /// Retrieves a list of property pages that can be displayed in this object's property sheet.
        /// </summary>
        /// <remarks>A pointer to a caller-allocated <see cref="CAUUID"/> structure that must be initialized and filled before returning. The pElems member in the structure is allocated by the callee with <see cref="Marshal.AllocCoTaskMem(int)"/> and freed by the caller with <see cref="Marshal.FreeCoTaskMem(IntPtr)"/>.</remarks>
        /// <returns><para>This method can return the standard return values <see cref="HResult.OutOfMemory"/> and <see cref="HResult.Unexpected"/>, as well as the following values.</para><para><ul><li><see cref="HResult.Ok"/></li><li><see cref="HResult.InvalidPointer"/></li></ul></para></returns>
        /// <remarks><para>The <see cref="CAUUID"/> structure is caller-allocated, but is not initialized by the caller. The <see cref="GetPages(out CAUUID)"/> method fills the cElements member in the structure. This method also allocates memory for the array pointed to by the pElems member using <see cref="Marshal.AllocCoTaskMem(int)"/>. Then, it fills the newly allocated array. After this method returns successfully, the structure contains a counted array of UUIDs, each UUID specifying a property page CLSID.</para><para><b>Notes to Callers:</b> The caller must release the memory pointed to by the <see cref="CAUUID.pElems"/> member of <see cref="CAUUID"/>, using <see cref="Marshal.FreeCoTaskMem(IntPtr)"/> when it is no longer needed.</para><para><b>Notes to Implementers:</b> <see cref="HResult.NotImplemented"/> is not allowed as a return value, because an object with no property pages should not expose the <see cref="ISpecifyPropertyPages"/> interface.</para></remarks>
        HResult GetPages(
            [Out] out CAUUID pPages);
    }
}
