//Copyright (c) Microsoft Corporation.  All rights reserved.  Distributed under the Microsoft Public License (MS-PL)

using System.Collections.Generic;
using Microsoft.WindowsAPICodePack.PropertySystem;
using Microsoft.WindowsAPICodePack.Win32Native.PropertySystem;
using Microsoft.WindowsAPICodePack.COMNative.Shell.PropertySystem;

namespace Microsoft.WindowsAPICodePack.Shell.PropertySystem
{
    public class ShellPropertyDescriptionsCache
    {
        private ShellPropertyDescriptionsCache() => propsDictionary = new Dictionary<PropertyKey, ShellPropertyDescription>();

        private IDictionary<PropertyKey, ShellPropertyDescription> propsDictionary;
        private static ShellPropertyDescriptionsCache cacheInstance;

        public static ShellPropertyDescriptionsCache Cache
        {
            get
            {
                if (cacheInstance == null)
                
                    cacheInstance = new ShellPropertyDescriptionsCache();
                
                return cacheInstance;
            }
        }

        public ShellPropertyDescription GetPropertyDescription(PropertyKey key)
        {
            if (!propsDictionary.ContainsKey(key))
            
                propsDictionary.Add(key, new ShellPropertyDescription(key));
            
            return propsDictionary[key];
        }
    }
}
