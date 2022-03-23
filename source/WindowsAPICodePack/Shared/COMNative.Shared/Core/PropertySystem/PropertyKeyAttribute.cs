using System;

namespace Microsoft.WindowsAPICodePack.COMNative.PropertySystem
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public sealed class PropertyKeyAttribute : Attribute
    {
        public string Guid { get; }

        public short PropertyId { get; }

        public PropertyKeyAttribute(string guid, short propertyId)
        {
            Guid = guid;

            PropertyId = propertyId;
        }
    }
}
