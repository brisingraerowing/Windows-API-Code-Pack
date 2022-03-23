using System;

namespace Microsoft.WindowsAPICodePack.COMNative.PropertySystem
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true, Inherited = true)]
    public sealed class GuidAttribute : Attribute
    {
        public string Guid { get; }

        public GuidAttribute(string guid) => Guid = guid;
    }
}
