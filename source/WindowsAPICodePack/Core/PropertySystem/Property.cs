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
    public sealed class ObjectProperty : IDisposable
    {

        private INativePropertyCollection _nativePropertyCollection;

        internal ObjectProperty(INativePropertyCollection nativePropertyCollection, PropertyKey propertyKey)

        {

            _nativePropertyCollection = nativePropertyCollection;

            PropertyKey = propertyKey;

        }

        private void StorePropVariantValue(ref PropVariant propVar, out bool stringTruncated)
        {
            PropertyKey propertyKey = PropertyKey;

            HResult result = _nativePropertyCollection.SetValue(ref propertyKey, ref propVar);

            if (!CoreErrorHelper.Succeeded(result))

                throw new PropertySystemException(LocalizedMessages.ShellPropertySetValue, Marshal.GetExceptionForHR((int)result));

            stringTruncated = result == HResult.InPlaceStringTruncated ? true : false;
        }

        /// <summary>
        /// Gets the value of this property.
        /// </summary>
        public (Type, object) GetValue()
        {

            PropertyKey propertyKey = PropertyKey;

            Marshal.ThrowExceptionForHR((int)_nativePropertyCollection.GetValue(ref propertyKey, out PropVariant propVariant));

            (Type, object) result = (NativePropertyHelper.VarEnumToSystemType(propVariant.VarType), propVariant.Value);

            propVariant.Dispose();

            return result;

        }

        /// <summary>
        /// Sets the value of this property.
        /// The value of the property is cleared if the value is set to null.
        /// </summary>
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

        /// <summary>
        /// Gets the property key identifying this property.
        /// </summary>
        public PropertyKey PropertyKey { get; }

        /// <summary>
        /// Clears the value of the property.
        /// </summary>
        public void ClearValue()
        {
            var propVar = new PropVariant();

            StorePropVariantValue(ref propVar, out _);
        }

        #region IDisposable Support
        public bool IsDisposed { get; private set; } = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!IsDisposed)
            {
                if (disposing)

                    _nativePropertyCollection = null;

                IsDisposed = true;
            }
        }

        // ~ObjectProperty()
        // {
        //   Dispose(false);
        // }

        public void Dispose() => Dispose(true);// GC.SuppressFinalize(this);
        #endregion

    }
}
