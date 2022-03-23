//Copyright (c) Microsoft Corporation.  All rights reserved.  Distributed under the Microsoft Public License (MS-PL)

using System;
using Microsoft.WindowsAPICodePack.Win32Native.PropertySystem;
using Microsoft.WindowsAPICodePack.COMNative.Shell.PropertySystem;

namespace Microsoft.WindowsAPICodePack.Shell.PropertySystem
{
    /// <summary>
    /// Defines the enumeration values for a property type.
    /// </summary>
    public class ShellPropertyEnumType
    {
        #region Private Properties

        private string displayText;
        private PropEnumType? enumType;
        private object minValue, setValue, enumerationValue;

        private IPropertyEnumType NativePropertyEnumType { get; set; }

        #endregion

        #region Internal Constructor

        internal ShellPropertyEnumType(IPropertyEnumType nativePropertyEnumType) => NativePropertyEnumType = nativePropertyEnumType;

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets display text from an enumeration information structure. 
        /// </summary>
        public string DisplayText
        {
            get
            {
                if (displayText == null)

                    NativePropertyEnumType.GetDisplayText(out displayText);

                return displayText;
            }
        }

        /// <summary>
        /// Gets an enumeration type from an enumeration information structure. 
        /// </summary>
        public PropEnumType EnumType
        {
            get
            {
                if (!enumType.HasValue)
                {
                    NativePropertyEnumType.GetEnumType(out PropEnumType tempEnumType);
                    enumType = tempEnumType;
                }
                return enumType.Value;
            }
        }

        /// <summary>
        /// Gets a minimum value from an enumeration information structure. 
        /// </summary>
        public object RangeMinValue
        {
            get
            {
                if (minValue == null)

                    using (var propVar = new PropVariant())
                    {
                        NativePropertyEnumType.GetRangeMinValue(propVar);
                        minValue = propVar.Value;
                    }

                return minValue;

            }
        }

        /// <summary>
        /// Gets a set value from an enumeration information structure. 
        /// </summary>
        public object RangeSetValue
        {
            get
            {
                if (setValue == null)

                    using (var propVar = new PropVariant())
                    {
                        NativePropertyEnumType.GetRangeSetValue(propVar);
                        setValue = propVar.Value;
                    }

                return setValue;

            }
        }

        /// <summary>
        /// Gets a value from an enumeration information structure. 
        /// </summary>
        public object RangeValue
        {
            get
            {
                if (enumerationValue == null)

                    using (var propVar = new PropVariant())
                    {
                        NativePropertyEnumType.GetValue(propVar);
                        enumerationValue = propVar.Value;
                    }

                return enumerationValue;
            }
        }

        #endregion
    }
}
