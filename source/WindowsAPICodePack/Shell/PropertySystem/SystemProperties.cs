using Microsoft.WindowsAPICodePack.Win32Native;
using Microsoft.WindowsAPICodePack.Win32Native.PropertySystem;
using Microsoft.WindowsAPICodePack.Win32Native.Shell.PropertySystem;
using Microsoft.WindowsAPICodePack.Win32Native.Shell.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.WindowsAPICodePack.Shell.PropertySystem
{
    public static class SystemProperties
    {

        /// <summary>
        /// Returns the property description for a given property key.
        /// </summary>
        /// <param name="propertyKey">Property key of the property whose description is required.</param>
        /// <returns>Property Description for a given property key</returns>
        public static ShellPropertyDescription GetPropertyDescription(PropertyKey propertyKey) => ShellPropertyDescriptionsCache.Cache.GetPropertyDescription(propertyKey);


        /// <summary>
        /// Gets the property description for a given property's canonical name.
        /// </summary>
        /// <param name="canonicalName">Canonical name of the property whose description is required.</param>
        /// <returns>Property Description for a given property key</returns>
        public static ShellPropertyDescription GetPropertyDescription(string canonicalName)
        {
            int result = PropertySystemNativeMethods.PSGetPropertyKeyFromName(canonicalName, out PropertyKey propKey);

            if (!CoreErrorHelper.Succeeded(result))

                // todo: some localized messages could now apply only for the Shell project (and not for Win32Native), so they should be moved to the Shell project.

                throw new ArgumentException(LocalizedMessages.ShellInvalidCanonicalName, Marshal.GetExceptionForHR(result));

            return ShellPropertyDescriptionsCache.Cache.GetPropertyDescription(propKey);
        }
    }
}
