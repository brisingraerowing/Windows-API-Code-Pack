//Copyright (c) Microsoft Corporation.  All rights reserved.  Distributed under the Microsoft Public License (MS-PL)

using Microsoft.WindowsAPICodePack.COMNative.Shell.PropertySystem;
using Microsoft.WindowsAPICodePack.PropertySystem;
using Microsoft.WindowsAPICodePack.Win32Native;

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

using static Microsoft.WindowsAPICodePack.COMNative.PropertySystem.NativePropertyHelper;

namespace Microsoft.WindowsAPICodePack.Shell.PropertySystem
{
    /// <summary>
    /// Defines the shell property description information for a property.
    /// </summary>
    public class ShellPropertyDescription : IDisposable
    {
        #region Private Fields
        private IPropertyDescription nativePropertyDescription;
        private string canonicalName;
        private PropertyKey propertyKey;
        private string displayName;
        private string editInvitation;
        private VarEnum? varEnumType = null;
        private PropertyDisplayType? displayType;
        private PropertyAggregationType? aggregationTypes;
        private uint? defaultColumWidth;
        private PropertyTypeOptions? propertyTypeFlags;
        private PropertyViewOptions? propertyViewFlags;
        private Type valueType;
        private System.Collections.ObjectModel.ReadOnlyCollection<ShellPropertyEnumType> propertyEnumTypes;
        private PropertyColumnStateOptions? columnState;
        private PropertyConditionType? conditionType;
        private PropertyConditionOperation? conditionOperation;
        private PropertyGroupingRange? groupingRange;
        private PropertySortDescription? sortDescription;
        #endregion

        #region Public Properties
        /// <summary>
        /// Gets the case-sensitive name of a property as it is known to the system, 
        /// regardless of its localized name.
        /// </summary>
        public string CanonicalName
        {
            get
            {
                if (canonicalName == null)

                    _ = PropertySystemNativeMethods.PSGetNameFromPropertyKey(ref propertyKey, out canonicalName);

                return canonicalName;
            }
        }

        /// <summary>
        /// Gets the property key identifying the underlying property.
        /// </summary>
        public PropertyKey PropertyKey => propertyKey;

        /// <summary>
        /// Gets the display name of the property as it is shown in any user interface (UI).
        /// </summary>
        public string DisplayName
        {
            get
            {
                if (NativePropertyDescription != null && displayName == null && CoreErrorHelper.Succeeded(NativePropertyDescription.GetDisplayName(out IntPtr dispNameptr)) && dispNameptr != IntPtr.Zero)
                {
                    displayName = Marshal.PtrToStringUni(dispNameptr);

                    // Free the string
                    Marshal.FreeCoTaskMem(dispNameptr);
                }

                return displayName;
            }
        }

        /// <summary>
        /// Gets the text used in edit controls hosted in various dialog boxes.
        /// </summary>
        public string EditInvitation
        {
            get
            {
                if (NativePropertyDescription != null && editInvitation == null && CoreErrorHelper.Succeeded(NativePropertyDescription.GetEditInvitation(out IntPtr ptr)) && ptr != IntPtr.Zero) // EditInvitation can be empty, so ignore the HR value, but don't throw an exception
                {
                    editInvitation = Marshal.PtrToStringUni(ptr);
                    // Free the string
                    Marshal.FreeCoTaskMem(ptr);
                }

                return editInvitation;
            }
        }

        private T GetValue<T>(ref T? value, in Func<WinCopies.
#if !WAPICP3
            Util.
#endif
            FuncOut<T, HResult>> func) where T : struct => (NativePropertyDescription != null && value == null && CoreErrorHelper.Succeeded(func()(out T tmpValue)) ? value = tmpValue : value) ?? default;

        /// <summary>
        /// Gets the VarEnum OLE type for this property.
        /// </summary>
        public VarEnum VarEnumType => GetValue(ref varEnumType, () => NativePropertyDescription.GetPropertyType);

        /// <summary>
        /// Gets the .NET system type for a value of this property, or
        /// null if the value is empty.
        /// </summary>
        public Type ValueType => valueType ?? (valueType = VarEnumToSystemType(VarEnumType));

        /// <summary>
        /// Gets the current data type used to display the property.
        /// </summary>
        public PropertyDisplayType DisplayType => GetValue(ref displayType, () => NativePropertyDescription.GetDisplayType);

        /// <summary>
        /// Gets the default user interface (UI) column width for this property.
        /// </summary>
        public uint DefaultColumWidth => (NativePropertyDescription != null && !defaultColumWidth.HasValue && CoreErrorHelper.Succeeded(NativePropertyDescription.GetDefaultColumnWidth(out uint tempDefaultColumWidth)) ? defaultColumWidth = tempDefaultColumWidth : defaultColumWidth) ?? default;

        /// <summary>
        /// Gets a value that describes how the property values are displayed when 
        /// multiple items are selected in the user interface (UI).
        /// </summary>
        public PropertyAggregationType AggregationTypes => GetValue(ref aggregationTypes, () => NativePropertyDescription.GetAggregationType);

        /// <summary>
        /// Gets a list of the possible values for this property.
        /// </summary>
        public System.Collections.ObjectModel.ReadOnlyCollection<ShellPropertyEnumType> PropertyEnumTypes
        {
            get
            {
                if (NativePropertyDescription != null && propertyEnumTypes == null)
                {
                    var propEnumTypeList = new List<ShellPropertyEnumType>();

                    var guid = new Guid(NativeAPI.Guids.Shell.IPropertyEnumTypeList);
                    HResult hr = NativePropertyDescription.GetEnumTypeList(ref guid, out IPropertyEnumTypeList nativeList);

                    if (nativeList != null && CoreErrorHelper.Succeeded(hr))
                    {
                        nativeList.GetCount(out uint count);
                        guid = new Guid(NativeAPI.Guids.Shell.IPropertyEnumType);

                        for (uint i = 0; i < count; i++)
                        {
                            nativeList.GetAt(i, ref guid, out IPropertyEnumType nativeEnumType);
                            propEnumTypeList.Add(new ShellPropertyEnumType(nativeEnumType));
                        }
                    }

                    propertyEnumTypes = new System.Collections.ObjectModel.ReadOnlyCollection<ShellPropertyEnumType>(propEnumTypeList);
                }

                return propertyEnumTypes;
            }
        }

        /// <summary>
        /// Gets the column state flag, which describes how the property 
        /// should be treated by interfaces or APIs that use this flag.
        /// </summary>
        public PropertyColumnStateOptions ColumnState => GetValue(ref columnState, () => NativePropertyDescription.GetColumnState);

        private T GetConditionValue<T>(ref T? conditionValue) where T : struct
        {
            // If default/first value, try to get it again, otherwise used the cached one.
            if (!(NativePropertyDescription == null || conditionValue.HasValue) && CoreErrorHelper.Succeeded(NativePropertyDescription.GetConditionType(out PropertyConditionType tempConditionType, out PropertyConditionOperation tempConditionOperation)))
            {
                conditionOperation = tempConditionOperation;
                conditionType = tempConditionType;
            }

            return conditionValue ?? default;
        }

        /// <summary>
        /// Gets the condition type to use when displaying the property in 
        /// the query builder user interface (UI). This influences the list 
        /// of predicate conditions (for example, equals, less than, and 
        /// contains) that are shown for this property.
        /// </summary>
        /// <remarks>For more information, see the <c>conditionType</c> attribute 
        /// of the <c>typeInfo</c> element in the property's .propdesc file.</remarks>
        public PropertyConditionType ConditionType => GetConditionValue(ref conditionType);

        /// <summary>
        /// Gets the default condition operation to use 
        /// when displaying the property in the query builder user 
        /// interface (UI). This influences the list of predicate conditions 
        /// (for example, equals, less than, and contains) that are shown 
        /// for this property.
        /// </summary>
        /// <remarks>For more information, see the <c>conditionType</c> attribute of the 
        /// <c>typeInfo</c> element in the property's .propdesc file.</remarks>
        public PropertyConditionOperation ConditionOperation => GetConditionValue(ref conditionOperation);

        /// <summary>
        /// Gets the method used when a view is grouped by this property.
        /// </summary>
        /// <remarks>The information retrieved by this method comes from 
        /// the <c>groupingRange</c> attribute of the <c>typeInfo</c> element in the 
        /// property's .propdesc file.</remarks>
        public PropertyGroupingRange GroupingRange => GetValue(ref
                // If default/first value, try to get it again, otherwise used the cached one.
                groupingRange, () => NativePropertyDescription.GetGroupingRange);

        /// <summary>
        /// Gets the current sort description flags for the property, 
        /// which indicate the particular wordings of sort offerings.
        /// </summary>
        /// <remarks>The settings retrieved by this method are set 
        /// through the <c>sortDescription</c> attribute of the <c>labelInfo</c> 
        /// element in the property's .propdesc file.</remarks>
        public PropertySortDescription SortDescription => GetValue(ref
                // If default/first value, try to get it again, otherwise used the cached one.
                sortDescription, () => NativePropertyDescription.GetSortDescription);

        /// <summary>
        /// Gets the localized display string that describes the current sort order.
        /// </summary>
        /// <param name="descending">Indicates the sort order should 
        /// reference the string "Z on top"; otherwise, the sort order should reference the string "A on top".</param>
        /// <returns>The sort description for this property.</returns>
        /// <remarks>The string retrieved by this method is determined by flags set in the 
        /// <c>sortDescription</c> attribute of the <c>labelInfo</c> element in the property's .propdesc file.</remarks>
        public string GetSortDescriptionLabel(bool descending)
        {
            string label = string.Empty;

            if (NativePropertyDescription != null && CoreErrorHelper.Succeeded(NativePropertyDescription.GetSortDescriptionLabel(descending, out IntPtr ptr)) && ptr != IntPtr.Zero)
            {
                label = Marshal.PtrToStringUni(ptr);
                // Free the string
                Marshal.FreeCoTaskMem(ptr);
            }

            return label;
        }

        /// <summary>
        /// Gets a set of flags that describe the uses and capabilities of the property.
        /// </summary>
        public PropertyTypeOptions TypeFlags => (NativePropertyDescription != null && propertyTypeFlags == null ? propertyTypeFlags = CoreErrorHelper.Succeeded(NativePropertyDescription.GetTypeFlags(PropertyTypeOptions.MaskAll, out PropertyTypeOptions tempFlags)) ? tempFlags : default : propertyTypeFlags) ?? default;

        /// <summary>
        /// Gets the current set of flags governing the property's view.
        /// </summary>
        public PropertyViewOptions ViewFlags => (NativePropertyDescription != null && propertyViewFlags == null ? propertyViewFlags = CoreErrorHelper.Succeeded(NativePropertyDescription.GetViewFlags(out PropertyViewOptions tempFlags)) ? tempFlags : default : propertyViewFlags) ?? default;

        /// <summary>
        /// Gets a value that determines if the native property description is present on the system.
        /// </summary>
        public bool HasSystemDescription => NativePropertyDescription != null;
        #endregion

        internal ShellPropertyDescription(PropertyKey key) => propertyKey = key;

        /// <summary>
        /// Get the native property description COM interface
        /// </summary>
        internal IPropertyDescription NativePropertyDescription
        {
            get
            {
                if (nativePropertyDescription == null)
                {
                    var guid = new Guid(NativeAPI.Guids.Shell.IPropertyDescription);
                    _ = PropertySystemNativeMethods.PSGetPropertyDescription(ref propertyKey, ref guid, out nativePropertyDescription);
                }

                return nativePropertyDescription;
            }
        }

        #region IDisposable Members
        /// <summary>
        /// Release the native objects
        /// </summary>
        /// <param name="disposing">Indicates that this is being called from Dispose(), rather than the finalizer.</param>
        protected virtual void Dispose(bool disposing)
        {
            CoreHelpers.DisposeCOMObject(ref nativePropertyDescription);

            if (disposing)
            {
                // and the managed ones
                canonicalName = null;
                displayName = null;
                editInvitation = null;
                defaultColumWidth = null;
                valueType = null;
                propertyEnumTypes = null;
            }
        }

        /// <summary>
        /// Release the native objects
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Release the native objects
        /// </summary>
        ~ShellPropertyDescription() => Dispose(false);
        #endregion
    }
}
