using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.WindowsAPICodePack.Win32Native.Shell.PropertySystem
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true, Inherited = true)]
    public sealed class GuidAttribute : Attribute
    {
        public string Guid { get; }

        public GuidAttribute(string guid) => Guid = guid;
    }
}
