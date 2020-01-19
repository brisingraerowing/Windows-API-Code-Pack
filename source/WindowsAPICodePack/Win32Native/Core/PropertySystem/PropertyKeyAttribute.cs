using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.WindowsAPICodePack.Win32Native.Shell.PropertySystem
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public sealed class PropertyKeyAttribute : Attribute
    {
        public string Guid { get; }

        public short PId { get; }

        public PropertyKeyAttribute(string guid, short pid)

        {

            Guid = guid;

            PId = pid;

        }
    }
}
