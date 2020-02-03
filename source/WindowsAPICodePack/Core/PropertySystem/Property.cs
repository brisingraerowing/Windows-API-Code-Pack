using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;
using Microsoft.WindowsAPICodePack.Win32Native;
using Microsoft.WindowsAPICodePack.Win32Native.Shell;
using Microsoft.WindowsAPICodePack.Win32Native.Shell.PropertySystem;
using Microsoft.WindowsAPICodePack.Win32Native.Shell.Resources;
using MS.WindowsAPICodePack.Win32Native.Shell.PropertySystem;
using System.Collections.Generic;
using System.Text;
using Microsoft.WindowsAPICodePack.Win32Native.PropertySystem;

namespace Microsoft.WindowsAPICodePack.PropertySystem
{
    /// <summary>
    /// This class wraps native <see cref="PropVariant"/> types into managed type. Please note that the Shell API, however, has its own managed wrapper, the <c>ShellProperty</c> class.
    /// </summary>
    public class ObjectProperty
    {
        #region Private Fields

        private readonly PropertyKey propertyKey;
        private readonly INativePropertyCollection nativePropertyCollection;

        #endregion

        #region Private Methods

        private void StorePropVariantValue(ref PropVariant propVar, out bool stringTruncated)
        {
            PropertyKey propertyKey = this.propertyKey;

            HResult result = nativePropertyCollection.SetValue(ref propertyKey, ref propVar);

            if (!CoreErrorHelper.Succeeded(result))

                throw new PropertySystemException(LocalizedMessages.ShellPropertySetValue, Marshal.GetExceptionForHR((int)result));

            stringTruncated = result == HResult.InPlaceStringTruncated ? true : false;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the strongly-typed value of this property.
        /// The value of the property is cleared if the value is set to null.
        /// </summary>
        public (Type, object) GetValue()
        {

            PropertyKey propertyKey = this.propertyKey;

            Marshal.ThrowExceptionForHR((int)nativePropertyCollection.GetValue(ref propertyKey, out PropVariant propVariant));

            (Type, object) result = (NativePropertyHelper.VarEnumToSystemType(propVariant.VarType), propVariant.Value);

            propVariant.Dispose();

            return result;

        }

        public void SetValue(object value, out bool stringTruncated)
        {

            if (value is Nullable)
            {
                PropertyInfo pi = value.GetType().GetProperty("HasValue");

                if (pi != null && !(bool)pi.GetValue(value, null))
                {
                    ClearValue();
                    stringTruncated = false;
                    return;
                }
            }
            else if (value == null)
            {
                ClearValue();
                stringTruncated = false;
                return;
            }

            PropVariant propVariant = PropVariant.FromObject(value);

            StorePropVariantValue(ref propVariant, out stringTruncated);
        }


        #endregion

        #region IProperty Members

        /// <summary>
        /// Gets the property key identifying this property.
        /// </summary>
        public PropertyKey PropertyKey => propertyKey;

        /// <summary>
        /// Clears the value of the property.
        /// </summary>
        public void ClearValue()
        {
            var propVar = new PropVariant();

            StorePropVariantValue(ref propVar, out _);
        }

        #endregion

    }
}
