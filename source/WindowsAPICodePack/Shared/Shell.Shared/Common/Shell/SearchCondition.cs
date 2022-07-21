//Copyright (c) Microsoft Corporation.  All rights reserved.  Distributed under the Microsoft Public License (MS-PL)

using Microsoft.WindowsAPICodePack.COMNative.Shell;
using Microsoft.WindowsAPICodePack.COMNative.Shell.PropertySystem;
using Microsoft.WindowsAPICodePack.PropertySystem;
using Microsoft.WindowsAPICodePack.Win32Native;
using Microsoft.WindowsAPICodePack.Win32Native.PropertySystem;
using Microsoft.WindowsAPICodePack.Win32Native.Shell;

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Microsoft.WindowsAPICodePack.Shell
{
    /// <summary>
    /// Exposes properties and methods for retrieving information about a search condition.
    /// </summary>
    public class SearchCondition : IDisposable
    {
        private readonly string canonicalName;
        private PropertyKey propertyKey;
        private PropertyKey emptyPropertyKey = new PropertyKey();
        private readonly SearchConditionOperation conditionOperation = SearchConditionOperation.Implicit;
        private readonly SearchConditionType conditionType = SearchConditionType.Leaf;

        internal ICondition NativeSearchCondition { get; set; }

        /// <summary>
        /// The name of a property to be compared or NULL for an unspecified property.
        /// </summary>
        public string PropertyCanonicalName => canonicalName;

        /// <summary>
        /// The property key for the property that is to be compared.
        /// </summary>        
        public PropertyKey PropertyKey
        {
            get
            {
                if (propertyKey == emptyPropertyKey)
                {
                    int hr = PropertySystemNativeMethods.PSGetPropertyKeyFromName(PropertyCanonicalName, out propertyKey);

                    if (!CoreErrorHelper.Succeeded(hr))

                        throw new ShellException(hr);
                }

                return propertyKey;
            }
        }

        /// <summary>
        /// A value (in <see cref="string"/> format) to which the property is compared.
        /// </summary>
        public string PropertyValue { get; internal set; }

        /// <summary>
        /// Search condition operation to be performed on the property/value combination.
        /// See <see cref="SearchConditionOperation"/> for more details.
        /// </summary>        
        public SearchConditionOperation ConditionOperation => conditionOperation;

        /// <summary>
        /// Represents the condition type for the given node. 
        /// </summary>        
        public SearchConditionType ConditionType => conditionType;

        internal SearchCondition(ICondition nativeSearchCondition)
        {
            NativeSearchCondition = nativeSearchCondition ?? throw new ArgumentNullException(nameof(nativeSearchCondition));

            HResult hr = NativeSearchCondition.GetConditionType(out conditionType);

            if (CoreErrorHelper.Succeeded(hr) ? ConditionType == SearchConditionType.Leaf : throw new ShellException(hr))

                using (var propVar = new PropVariant())
                {
                    hr = NativeSearchCondition.GetComparisonInfo(out canonicalName, out conditionOperation, propVar);

                    PropertyValue = CoreErrorHelper.Succeeded(hr) ? propVar.Value.ToString() : throw new ShellException(hr);
                }
        }

        /// <summary>
        /// Retrieves an array of the sub-conditions. 
        /// </summary>
        public IEnumerable<SearchCondition> GetSubConditions()
        {
            // Our list that we'll return
            var subConditionsList = new List<SearchCondition>();

            // Get the sub-conditions from the native API
            var guid = new Guid(NativeAPI.Guids.Shell.IEnumUnknown);

            HResult hr = NativeSearchCondition.GetSubConditions(ref guid, out object subConditionObj);

            // Convert each ICondition to SearchCondition
            if ((CoreErrorHelper.Succeeded(hr) ? subConditionObj : throw new ShellException(hr)) != null)
            {
                var enumUnknown = subConditionObj as IEnumUnknown;

                IntPtr buffer = IntPtr.Zero;
                uint fetched = 0;

                while (hr == HResult.Ok)
                {
                    hr = enumUnknown.Next(1, ref buffer, ref fetched);

                    if (hr == HResult.Ok && fetched == 1)

                        subConditionsList.Add(new SearchCondition((ICondition)Marshal.GetObjectForIUnknown(buffer)));
                }
            }

            return subConditionsList;
        }

        #region IDisposable Members
        ~SearchCondition() => Dispose(false);

        /// <summary>
        /// Release the native objects.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Release the native objects.
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (NativeSearchCondition != null)
            {
                _ = Marshal.ReleaseComObject(NativeSearchCondition);
                NativeSearchCondition = null;
            }
        }
        #endregion
    }
}
