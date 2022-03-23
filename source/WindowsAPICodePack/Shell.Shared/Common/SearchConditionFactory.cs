﻿//Copyright (c) Microsoft Corporation.  All rights reserved.  Distributed under the Microsoft Public License (MS-PL)

using Microsoft.WindowsAPICodePack.COMNative.Shell;
using Microsoft.WindowsAPICodePack.COMNative.Shell.PropertySystem;
using Microsoft.WindowsAPICodePack.PropertySystem;
using Microsoft.WindowsAPICodePack.Win32Native;
using Microsoft.WindowsAPICodePack.Win32Native.PropertySystem;
using Microsoft.WindowsAPICodePack.Win32Native.Shell;
using Microsoft.WindowsAPICodePack.Win32Native.Shell.Resources;

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.InteropServices;

namespace Microsoft.WindowsAPICodePack.Shell
{
    /// <summary>
    /// Provides methods for creating or resolving a condition tree that was obtained by parsing a query string.
    /// </summary>
    public static class SearchConditionFactory
    {
        /// <summary>
        /// Creates a leaf condition node that represents a comparison of property value and constant value. 
        /// </summary>
        /// <param name="propertyName">The name of a property to be compared, or null for an unspecified property. 
        /// The locale name of the leaf node is LOCALE_NAME_USER_DEFAULT.</param>
        /// <param name="value">The constant value against which the property value should be compared.</param>
        /// <param name="operation">Specific condition to be used when comparing the actual value and the expected value of the given property</param>
        /// <returns><see cref="SearchCondition"/> based on the given parameters</returns>
        /// <remarks>
        /// The search will only work for files that are indexed, as well as the specific properties are indexed. To find 
        /// the properties that are indexed, look for the specific property's property description and 
        /// <see cref="PropertySystem.ShellPropertyDescription.TypeFlags"/> property for IsQueryable flag.
        /// </remarks>
        public static SearchCondition CreateLeafCondition(string propertyName, string value, SearchConditionOperation operation)
        {
            using (var propVar = new PropVariant(value))

                return CreateLeafCondition(propertyName, propVar, null, operation);
        }

        /// <summary>
        /// Creates a leaf condition node that represents a comparison of property value and constant value. 
        /// Overload method takes a <see cref="System.DateTime"/> parameter for the comparison value.
        /// </summary>
        /// <param name="propertyName">The name of a property to be compared, or null for an unspecified property. 
        /// The locale name of the leaf node is LOCALE_NAME_USER_DEFAULT.</param>
        /// <param name="value">The <see cref="System.DateTime"/> value against which the property value should be compared.</param>
        /// <param name="operation">Specific condition to be used when comparing the actual value and the expected value of the given property</param>
        /// <returns><see cref="SearchCondition"/> based on the given parameters</returns>
        /// <remarks>
        /// The search will only work for files that are indexed, as well as the specific properties are indexed. To find 
        /// the properties that are indexed, look for the specific property's property description and 
        /// <see cref="PropertySystem.ShellPropertyDescription.TypeFlags"/> property for IsQueryable flag.
        /// </remarks>
        public static SearchCondition CreateLeafCondition(string propertyName, System.DateTime value, SearchConditionOperation operation)
        {
            using (var propVar = new PropVariant(value))

                return CreateLeafCondition(propertyName, propVar, "System.StructuredQuery.CustomProperty.System.DateTime", operation);
        }

        /// <summary>
        /// Creates a leaf condition node that represents a comparison of property value and Integer value. 
        /// </summary>
        /// <param name="propertyName">The name of a property to be compared, or null for an unspecified property. 
        /// The locale name of the leaf node is LOCALE_NAME_USER_DEFAULT.</param>
        /// <param name="value">The Integer value against which the property value should be compared.</param>
        /// <param name="operation">Specific condition to be used when comparing the actual value and the expected value of the given property</param>
        /// <returns><see cref="SearchCondition"/> based on the given parameters</returns>
        /// <remarks>
        /// The search will only work for files that are indexed, as well as the specific properties are indexed. To find 
        /// the properties that are indexed, look for the specific property's property description and 
        /// <see cref="PropertySystem.ShellPropertyDescription.TypeFlags"/> property for IsQueryable flag.
        /// </remarks>
        public static SearchCondition CreateLeafCondition(string propertyName, int value, SearchConditionOperation operation)
        {
            using (var propVar = new PropVariant(value))

                return CreateLeafCondition(propertyName, propVar, "System.StructuredQuery.CustomProperty.Integer", operation);
        }

        /// <summary>
        /// Creates a leaf condition node that represents a comparison of property value and Boolean value. 
        /// </summary>
        /// <param name="propertyName">The name of a property to be compared, or null for an unspecified property. 
        /// The locale name of the leaf node is LOCALE_NAME_USER_DEFAULT.</param>
        /// <param name="value">The Boolean value against which the property value should be compared.</param>
        /// <param name="operation">Specific condition to be used when comparing the actual value and the expected value of the given property</param>
        /// <returns><see cref="SearchCondition"/> based on the given parameters</returns>
        /// <remarks>
        /// The search will only work for files that are indexed, as well as the specific properties are indexed. To find 
        /// the properties that are indexed, look for the specific property's property description and 
        /// <see cref="PropertySystem.ShellPropertyDescription.TypeFlags"/> property for IsQueryable flag.
        /// </remarks>
        public static SearchCondition CreateLeafCondition(string propertyName, bool value, SearchConditionOperation operation)
        {
            using (var propVar = new PropVariant(value))

                return CreateLeafCondition(propertyName, propVar, "System.StructuredQuery.CustomProperty.Boolean", operation);
        }

        /// <summary>
        /// Creates a leaf condition node that represents a comparison of property value and Floating Point value. 
        /// </summary>
        /// <param name="propertyName">The name of a property to be compared, or null for an unspecified property. 
        /// The locale name of the leaf node is LOCALE_NAME_USER_DEFAULT.</param>
        /// <param name="value">The Floating Point value against which the property value should be compared.</param>
        /// <param name="operation">Specific condition to be used when comparing the actual value and the expected value of the given property</param>
        /// <returns><see cref="SearchCondition"/> based on the given parameters</returns>
        /// <remarks>
        /// The search will only work for files that are indexed, as well as the specific properties are indexed. To find 
        /// the properties that are indexed, look for the specific property's property description and 
        /// <see cref="PropertySystem.ShellPropertyDescription.TypeFlags"/> property for IsQueryable flag.
        /// </remarks>
        public static SearchCondition CreateLeafCondition(string propertyName, double value, SearchConditionOperation operation)
        {
            using (var propVar = new PropVariant(value))

                return CreateLeafCondition(propertyName, propVar, "System.StructuredQuery.CustomProperty.FloatingPoint", operation);
        }

        private static SearchCondition CreateLeafCondition(string propertyName, PropVariant propVar, string valueType, SearchConditionOperation operation)
        {
            IConditionFactory nativeConditionFactory = null;
            SearchCondition condition = null;

            try
            {
                // Same as the native "IConditionFactory:MakeLeaf" method
                nativeConditionFactory = (IConditionFactory)new ConditionFactoryCoClass();

                if (string.IsNullOrEmpty(propertyName) || propertyName.ToUpperInvariant() == "SYSTEM.NULL")

                    propertyName = null;

                HResult hr = HResult.Fail;

                hr = nativeConditionFactory.MakeLeaf(propertyName, operation, valueType,
                    propVar, null, null, null, false, out ICondition nativeCondition);

                if (!CoreErrorHelper.Succeeded(hr))

                    throw new ShellException(hr);

                // Create our search condition and set the various properties.
                condition = new SearchCondition(nativeCondition);
            }

            finally
            {
                if (nativeConditionFactory != null)

                    _ = Marshal.ReleaseComObject(nativeConditionFactory);
            }

            return condition;
        }

        /// <summary>
        /// Creates a leaf condition node that represents a comparison of property value and constant value. 
        /// </summary>
        /// <param name="propertyKey">The property to be compared.</param>
        /// <param name="value">The constant value against which the property value should be compared.</param>
        /// <param name="operation">Specific condition to be used when comparing the actual value and the expected value of the given property</param>
        /// <returns><see cref="SearchCondition"/> based on the given parameters</returns>
        /// <remarks>
        /// The search will only work for files that are indexed, as well as the specific properties are indexed. To find 
        /// the properties that are indexed, look for the specific property's property description and 
        /// <see cref="PropertySystem.ShellPropertyDescription.TypeFlags"/> property for IsQueryable flag.
        /// </remarks>
        public static SearchCondition CreateLeafCondition(PropertyKey propertyKey, string value, SearchConditionOperation operation)
        {
            CoreErrorHelper.ThrowExceptionForHResult(PropertySystemNativeMethods.PSGetNameFromPropertyKey(ref propertyKey, out string canonicalName));

            return string.IsNullOrEmpty(canonicalName)
                ? throw new ArgumentException(LocalizedMessages.SearchConditionFactoryInvalidProperty, nameof(propertyKey))
                : CreateLeafCondition(canonicalName, value, operation);
        }

        /// <summary>
        /// Creates a leaf condition node that represents a comparison of property value and constant value. 
        /// Overload method takes a <see cref="System.DateTime"/> parameter for the comparison value.
        /// </summary>
        /// <param name="propertyKey">The property to be compared.</param>
        /// <param name="value">The <see cref="System.DateTime"/> value against which the property value should be compared.</param>
        /// <param name="operation">Specific condition to be used when comparing the actual value and the expected value of the given property</param>
        /// <returns><see cref="SearchCondition"/> based on the given parameters</returns>
        /// <remarks>
        /// The search will only work for files that are indexed, as well as the specific properties are indexed. To find 
        /// the properties that are indexed, look for the specific property's property description and 
        /// <see cref="PropertySystem.ShellPropertyDescription.TypeFlags"/> property for IsQueryable flag.
        /// </remarks>
        public static SearchCondition CreateLeafCondition(PropertyKey propertyKey, System.DateTime value, SearchConditionOperation operation)
        {
            _ = PropertySystemNativeMethods.PSGetNameFromPropertyKey(ref propertyKey, out string canonicalName);

            return string.IsNullOrEmpty(canonicalName)
                ? throw new ArgumentException(LocalizedMessages.SearchConditionFactoryInvalidProperty, nameof(propertyKey))
                : CreateLeafCondition(canonicalName, value, operation);
        }

        /// <summary>
        /// Creates a leaf condition node that represents a comparison of property value and Boolean value. 
        /// Overload method takes a <see cref="System.DateTime"/> parameter for the comparison value.
        /// </summary>
        /// <param name="propertyKey">The property to be compared.</param>
        /// <param name="value">The boolean value against which the property value should be compared.</param>
        /// <param name="operation">Specific condition to be used when comparing the actual value and the expected value of the given property</param>
        /// <returns><see cref="SearchCondition"/> based on the given parameters</returns>
        /// <remarks>
        /// The search will only work for files that are indexed, as well as the specific properties are indexed. To find 
        /// the properties that are indexed, look for the specific property's property description and 
        /// <see cref="PropertySystem.ShellPropertyDescription.TypeFlags"/> property for IsQueryable flag.
        /// </remarks>
        public static SearchCondition CreateLeafCondition(PropertyKey propertyKey, bool value, SearchConditionOperation operation)
        {
            _ = PropertySystemNativeMethods.PSGetNameFromPropertyKey(ref propertyKey, out string canonicalName);

            return string.IsNullOrEmpty(canonicalName)
                ? throw new ArgumentException(LocalizedMessages.SearchConditionFactoryInvalidProperty, nameof(propertyKey))
                : CreateLeafCondition(canonicalName, value, operation);
        }

        /// <summary>
        /// Creates a leaf condition node that represents a comparison of property value and Floating Point value. 
        /// Overload method takes a <see cref="System.DateTime"/> parameter for the comparison value.
        /// </summary>
        /// <param name="propertyKey">The property to be compared.</param>
        /// <param name="value">The Floating Point value against which the property value should be compared.</param>
        /// <param name="operation">Specific condition to be used when comparing the actual value and the expected value of the given property</param>
        /// <returns><see cref="SearchCondition"/> based on the given parameters</returns>
        /// <remarks>
        /// The search will only work for files that are indexed, as well as the specific properties are indexed. To find 
        /// the properties that are indexed, look for the specific property's property description and 
        /// <see cref="PropertySystem.ShellPropertyDescription.TypeFlags"/> property for IsQueryable flag.
        /// </remarks>
        public static SearchCondition CreateLeafCondition(PropertyKey propertyKey, double value, SearchConditionOperation operation)
        {
            _ = PropertySystemNativeMethods.PSGetNameFromPropertyKey(ref propertyKey, out string canonicalName);

            return string.IsNullOrEmpty(canonicalName)
                ? throw new ArgumentException(LocalizedMessages.SearchConditionFactoryInvalidProperty, nameof(propertyKey))
                : CreateLeafCondition(canonicalName, value, operation);
        }

        /// <summary>
        /// Creates a leaf condition node that represents a comparison of property value and Integer value. 
        /// Overload method takes a <see cref="System.DateTime"/> parameter for the comparison value.
        /// </summary>
        /// <param name="propertyKey">The property to be compared.</param>
        /// <param name="value">The Integer value against which the property value should be compared.</param>
        /// <param name="operation">Specific condition to be used when comparing the actual value and the expected value of the given property</param>
        /// <returns><see cref="SearchCondition"/> based on the given parameters</returns>
        /// <remarks>
        /// The search will only work for files that are indexed, as well as the specific properties are indexed. To find 
        /// the properties that are indexed, look for the specific property's property description and 
        /// <see cref="PropertySystem.ShellPropertyDescription.TypeFlags"/> property for IsQueryable flag.
        /// </remarks>
        public static SearchCondition CreateLeafCondition(PropertyKey propertyKey, int value, SearchConditionOperation operation)
        {
            _ = PropertySystemNativeMethods.PSGetNameFromPropertyKey(ref propertyKey, out string canonicalName);

            return string.IsNullOrEmpty(canonicalName)
                ? throw new ArgumentException(LocalizedMessages.SearchConditionFactoryInvalidProperty, nameof(propertyKey))
                : CreateLeafCondition(canonicalName, value, operation);
        }

        /// <summary>
        /// Creates a condition node that is a logical conjunction ("AND") or disjunction ("OR") of a collection of subconditions.
        /// </summary>
        /// <param name="conditionType">The SearchConditionType of the condition node. 
        /// Must be either AndCondition or OrCondition.</param>
        /// <param name="simplify">TRUE to logically simplify the result, if possible; 
        /// then the result will not necessarily to be of the specified kind. FALSE if the result should 
        /// have exactly the prescribed structure. An application that plans to execute a query based on the 
        /// condition tree would typically benefit from setting this parameter to TRUE. </param>
        /// <param name="conditionNodes">Array of subconditions</param>
        /// <returns>New <see cref="SearchCondition"/> based on the operation</returns>
        public static SearchCondition CreateAndOrCondition(SearchConditionType conditionType, bool simplify, params SearchCondition[] conditionNodes)
        {
            // Same as the native "IConditionFactory:MakeAndOr" method
            var nativeConditionFactory = (IConditionFactory)new ConditionFactoryCoClass();
            ICondition result = null;

            try
            {
                // 
                var conditionList = new List<ICondition>();

                if (conditionNodes != null)

                    foreach (SearchCondition c in conditionNodes)

                        conditionList.Add(c.NativeSearchCondition);

                IEnumUnknown subConditions = new EnumUnknownClass(conditionList.ToArray());

                HResult hr = nativeConditionFactory.MakeAndOr(conditionType, subConditions, simplify, out result);

                if (!CoreErrorHelper.Succeeded(hr)) throw new ShellException(hr);
            }

            finally
            {
                if (nativeConditionFactory != null)

                    _ = Marshal.ReleaseComObject(nativeConditionFactory);
            }

            return new SearchCondition(result);
        }

        /// <summary>
        /// Creates a condition node that is a logical negation (NOT) of another condition 
        /// (a subnode of this node). 
        /// </summary>
        /// <param name="conditionToBeNegated">SearchCondition node to be negated.</param>
        /// <param name="simplify">True to logically simplify the result if possible; False otherwise. 
        /// In a query builder scenario, simplyfy should typically be set to false.</param>
        public static SearchCondition CreateNotCondition(SearchCondition conditionToBeNegated, bool simplify)
        {
            if (conditionToBeNegated == null)

                throw new ArgumentNullException(nameof(conditionToBeNegated));

            // Same as the native "IConditionFactory:MakeNot" method
            var nativeConditionFactory = (IConditionFactory)new ConditionFactoryCoClass();
            ICondition result;

            try
            {
                HResult hr = nativeConditionFactory.MakeNot(conditionToBeNegated.NativeSearchCondition, simplify, out result);

                if (!CoreErrorHelper.Succeeded(hr)) throw new ShellException(hr);
            }

            finally
            {
                if (nativeConditionFactory != null)

                    _ = Marshal.ReleaseComObject(nativeConditionFactory);
            }

            return new SearchCondition(result);
        }

        /// <summary>
        /// Parses an input string that contains Structured Query keywords (using Advanced Query Syntax 
        /// or Natural Query Syntax) and produces a SearchCondition object.
        /// </summary>
        /// <param name="query">The query to be parsed</param>
        /// <returns>Search condition resulting from the query</returns>
        /// <remarks>For more information on structured query syntax, visit http://msdn.microsoft.com/en-us/library/bb233500.aspx and
        /// http://www.microsoft.com/windows/products/winfamily/desktopsearch/technicalresources/advquery.mspx</remarks>
        public static SearchCondition ParseStructuredQuery(string query) => ParseStructuredQuery(query, null);

        /// <summary>
        /// Parses an input string that contains Structured Query keywords (using Advanced Query Syntax 
        /// or Natural Query Syntax) and produces a SearchCondition object.
        /// </summary>
        /// <param name="query">The query to be parsed</param>
        /// <param name="cultureInfo">The culture used to select the localized language for keywords.</param>
        /// <returns>Search condition resulting from the query</returns>
        /// <remarks>For more information on structured query syntax, visit http://msdn.microsoft.com/en-us/library/bb233500.aspx and
        /// http://www.microsoft.com/windows/products/winfamily/desktopsearch/technicalresources/advquery.mspx</remarks>
        public static SearchCondition ParseStructuredQuery(string query, CultureInfo cultureInfo)
        {
            if (string.IsNullOrEmpty(query))

                throw new ArgumentNullException(nameof(query));

            var nativeQueryParserManager = (IQueryParserManager)new QueryParserManagerCoClass();
            IQueryParser queryParser = null;
            IQuerySolution querySolution = null;
            ICondition result = null;

            IEntity mainType = null;
            SearchCondition searchCondition = null;

            try
            {
                // First, try to create a new IQueryParser using IQueryParserManager
                var guid = new Guid(NativeAPI.Guids.Shell.IQueryParser);
                HResult hr = nativeQueryParserManager.CreateLoadedParser(
                    "SystemIndex",
                    cultureInfo == null ? (ushort)0 : (ushort)cultureInfo.LCID,
                    ref guid,
                    out queryParser);

                if (!CoreErrorHelper.Succeeded(hr)) throw new ShellException(hr);

                if (queryParser != null)
                {
                    // If user specified natural query, set the option on the query parser
                    using (var optionValue = new PropVariant(true))

                        hr = queryParser.SetOption(StructuredQuerySingleOption.NaturalSyntax, optionValue);

                    if (!CoreErrorHelper.Succeeded(hr)) throw new ShellException(hr);

                    // Next, try to parse the query.
                    // Result would be IQuerySolution that we can use for getting the ICondition and other
                    // details about the parsed query.
                    hr = queryParser.Parse(query, null, out querySolution);

                    if (!CoreErrorHelper.Succeeded(hr)) throw new ShellException(hr);

                    if (querySolution != null)
                    {
                        // Lastly, try to get the ICondition from this parsed query
                        hr = querySolution.GetQuery(out result, out mainType);

                        if (!CoreErrorHelper.Succeeded(hr)) throw new ShellException(hr);
                    }
                }

                searchCondition = new SearchCondition(result);

                return searchCondition;
            }

            catch
            {
                if (searchCondition != null) searchCondition.Dispose();

                throw;
            }

            finally
            {
                if (nativeQueryParserManager != null)

                    _ = Marshal.ReleaseComObject(nativeQueryParserManager);

                if (queryParser != null)

                    _ = Marshal.ReleaseComObject(queryParser);

                if (querySolution != null)

                    _ = Marshal.ReleaseComObject(querySolution);

                if (mainType != null)

                    _ = Marshal.ReleaseComObject(mainType);
            }
        }
    }
}
