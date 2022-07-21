//Copyright (c) Microsoft Corporation.  All rights reserved.  Distributed under the Microsoft Public License (MS-PL)

using Microsoft.WindowsAPICodePack.PropertySystem;

using System.Collections.Generic;

namespace Microsoft.WindowsAPICodePack.Shell.PropertySystem
{
    public class ShellPropertyDescriptionsCache
    {
        private ShellPropertyDescriptionsCache() => propsDictionary = new Dictionary<PropertyKey, ShellPropertyDescription>();

        private readonly IDictionary<PropertyKey, ShellPropertyDescription> propsDictionary;
        private static ShellPropertyDescriptionsCache cacheInstance;

        public static ShellPropertyDescriptionsCache Cache => cacheInstance
#if CS8
            ??=
#else
            ?? (cacheInstance =
#endif
            new ShellPropertyDescriptionsCache()
#if !CS8
            )
#endif
            ;

        public ShellPropertyDescription GetPropertyDescription(PropertyKey key)
        {
            if (!propsDictionary.ContainsKey(key))

                propsDictionary.Add(key, new ShellPropertyDescription(key));

            return propsDictionary[key];
        }
    }
}
