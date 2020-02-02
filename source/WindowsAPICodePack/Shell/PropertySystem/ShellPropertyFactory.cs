using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using Microsoft.WindowsAPICodePack.Win32Native.Shell.PropertySystem;
using Microsoft.WindowsAPICodePack.Win32Native.Shell.Resources;
using static Microsoft.WindowsAPICodePack.Win32Native.Shell.PropertySystem.ShellPropertyFactory;

namespace Microsoft.WindowsAPICodePack.Shell.PropertySystem
{

    /// <summary>
    /// Factory class for creating typed ShellProperties.
    /// Generates/caches expressions to create generic ShellProperties.
    /// </summary>
    internal static class ShellPropertyFactory
    {
        // Constructor cache.  It takes object as the third param so a single function will suffice for both constructors.
        private static readonly Dictionary<int, Func<PropertyKey, ShellPropertyDescription, object, IShellProperty>> _storeCache
            = new Dictionary<int, Func<PropertyKey, ShellPropertyDescription, object, IShellProperty>>();

        /// <summary>
        /// Creates a generic ShellProperty.
        /// </summary>
        /// <param name="propKey">PropertyKey</param>
        /// <param name="shellObject">Shell object from which to get property</param>
        /// <returns>ShellProperty matching type of value in property.</returns>
        public static IShellProperty CreateShellProperty(PropertyKey propKey, ShellObject shellObject) => GenericCreateShellProperty(propKey, shellObject);

        /// <summary>
        /// Creates a generic ShellProperty.
        /// </summary>
        /// <param name="propKey">PropertyKey</param>
        /// <param name="store">IPropertyStore from which to get property</param>
        /// <returns>ShellProperty matching type of value in property.</returns>
        public static IShellProperty CreateShellProperty(PropertyKey propKey, IPropertyStore store) => GenericCreateShellProperty(propKey, store);

        private static IShellProperty GenericCreateShellProperty<T>(PropertyKey propKey, T thirdArg)
        {
            Type thirdType = (thirdArg is ShellObject) ? typeof(ShellObject) : typeof(T);

            ShellPropertyDescription propDesc = ShellPropertyDescriptionsCache.Cache.GetPropertyDescription(propKey);

            // Get the generic type
            Type type = typeof(ShellProperty<>).MakeGenericType(VarEnumToSystemType(propDesc.VarEnumType));

            // The hash for the function is based off the generic type and which type (constructor) we're using.
            int hash = GetTypeHash(type, thirdType);

            if (!_storeCache.TryGetValue(hash, out Func<PropertyKey, ShellPropertyDescription, object, IShellProperty> ctor))
            {
                Type[] argTypes = { typeof(PropertyKey), typeof(ShellPropertyDescription), thirdType };
                ctor = ExpressConstructor(type, argTypes);
                _storeCache.Add(hash, ctor);
            }

            return ctor(propKey, propDesc, thirdArg);
        }

        #region Private static helper functions

        // Creates an expression for the specific constructor of the given type.
        private static Func<PropertyKey, ShellPropertyDescription, object, IShellProperty> ExpressConstructor(Type type, Type[] argTypes)
        {
            int typeHash = GetTypeHash(argTypes);

            // Finds the correct constructor by matching the hash of the types.
            ConstructorInfo ctorInfo = type.GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public)
                .FirstOrDefault(x => typeHash == GetTypeHash(x.GetParameters().Select(a => a.ParameterType)));

            if (ctorInfo == null)

                throw new ArgumentException(LocalizedMessages.ShellPropertyFactoryConstructorNotFound, nameof(type));

            ParameterExpression key = Expression.Parameter(argTypes[0], "propKey");
            ParameterExpression desc = Expression.Parameter(argTypes[1], "desc");
            ParameterExpression third = Expression.Parameter(typeof(object), "third"); //needs to be object to avoid casting later

            NewExpression create = Expression.New(ctorInfo, key, desc,
                Expression.Convert(third, argTypes[2]));

            return Expression.Lambda<Func<PropertyKey, ShellPropertyDescription, object, IShellProperty>>(
                create, key, desc, third).Compile();
        }

        private static int GetTypeHash(params Type[] types) => GetTypeHash((IEnumerable<Type>)types);

        // Creates a hash code, unique to the number and order of types.
        private static int GetTypeHash(IEnumerable<Type> types)
        {
            int hash = 0;
            foreach (Type type in types)

                hash = (hash * 31) + type.GetHashCode();

            return hash;
        }

        #endregion
    }
}
