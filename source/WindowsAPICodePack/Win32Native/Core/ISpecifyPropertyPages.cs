using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Microsoft.WindowsAPICodePack.Win32Native.Core.COM
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
    /// <remarks><para>A property page object manages a particular page within a property sheet. A property page implements at least <see cref="IPropertyPage"/> and can optionally implement <see cref="IPropertyPage2"/> if selection of a specific property is supported.</para>
    /// <para>An object specifies its support for property pages by implementing <see cref="ISpecifyPropertyPages"/>. Through this interface the caller can obtain a list of CLSIDs identifying the specific property pages that the object supports. If the object specifies a property page CLSID, the object must be able to receive property changes from the property page.</para></remarks>
    /// <seealso cref="IPropertyPage"/>
    /// <seealso cref="IPropertyPage2"/>
    /// <seealso cref="IPropertyPageSite"/>
    [ComImport,
        Guid(Guids.Core.COM.ISpecifyPropertyPages),
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ISpecifyPropertyPages
    {
        /// <summary>
        /// Retrieves a list of property pages that can be displayed in this object's property sheet.
        /// </summary>
        /// <remarks>A pointer to a caller-allocated <see cref="CAUUID"/> structure that must be initialized and filled before returning. The pElems member in the structure is allocated by the callee with <see cref="Marshal.AllocCoTaskMem(int)"/> and freed by the caller with <see cref="Marshal.FreeCoTaskMem(IntPtr)"/>.</remarks>
        /// <returns>This method can return the standard return values E_OUTOFMEMORY and <see cref="HResult.Unexpected"/>, as well as the following values.</returns>
        HResult GetPages(
            [Out] out CAUUID pPages);
    }
}
