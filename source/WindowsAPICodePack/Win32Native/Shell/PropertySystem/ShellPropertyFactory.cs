using Microsoft.WindowsAPICodePack.Win32Native.Shell.PropertySystem;
using Microsoft.WindowsAPICodePack.Win32Native.Shell.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.WindowsAPICodePack.Win32Native.Shell.PropertySystem
{
    public static class ShellPropertyFactory
    {

        /// <summary>
        /// Converts VarEnum to its associated .net Type.
        /// </summary>
        /// <param name="VarEnumType">VarEnum value</param>
        /// <returns>Associated .net equivelent.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        public static Type VarEnumToSystemType(VarEnum VarEnumType)
        {
            switch (VarEnumType)
            {
                case (VarEnum.VT_EMPTY):
                case (VarEnum.VT_NULL):
                    return typeof(object);
                case (VarEnum.VT_UI1):
                    return typeof(byte?);
                case (VarEnum.VT_I2):
                    return typeof(short?);
                case (VarEnum.VT_UI2):
                    return typeof(ushort?);
                case (VarEnum.VT_I4):
                    return typeof(int?);
                case (VarEnum.VT_UI4):
                    return typeof(uint?);
                case (VarEnum.VT_I8):
                    return typeof(long?);
                case (VarEnum.VT_UI8):
                    return typeof(ulong?);
                case (VarEnum.VT_R8):
                    return typeof(double?);
                case (VarEnum.VT_BOOL):
                    return typeof(bool?);
                case (VarEnum.VT_FILETIME):
                    return typeof(DateTime?);
                case (VarEnum.VT_CLSID):
                    return typeof(IntPtr?);
                case (VarEnum.VT_CF):
                    return typeof(IntPtr?);
                case (VarEnum.VT_BLOB):
                    return typeof(byte[]);
                case (VarEnum.VT_LPWSTR):
                    return typeof(string);
                case (VarEnum.VT_UNKNOWN):
                    return typeof(IntPtr?);
                case (VarEnum.VT_STREAM):
                    return typeof(IStream);
                case (VarEnum.VT_VECTOR | VarEnum.VT_UI1):
                    return typeof(byte[]);
                case (VarEnum.VT_VECTOR | VarEnum.VT_I2):
                    return typeof(short[]);
                case (VarEnum.VT_VECTOR | VarEnum.VT_UI2):
                    return typeof(ushort[]);
                case (VarEnum.VT_VECTOR | VarEnum.VT_I4):
                    return typeof(int[]);
                case (VarEnum.VT_VECTOR | VarEnum.VT_UI4):
                    return typeof(uint[]);
                case (VarEnum.VT_VECTOR | VarEnum.VT_I8):
                    return typeof(long[]);
                case (VarEnum.VT_VECTOR | VarEnum.VT_UI8):
                    return typeof(ulong[]);
                case (VarEnum.VT_VECTOR | VarEnum.VT_R8):
                    return typeof(double[]);
                case (VarEnum.VT_VECTOR | VarEnum.VT_BOOL):
                    return typeof(bool[]);
                case (VarEnum.VT_VECTOR | VarEnum.VT_FILETIME):
                    return typeof(DateTime[]);
                case (VarEnum.VT_VECTOR | VarEnum.VT_CLSID):
                    return typeof(IntPtr[]);
                case (VarEnum.VT_VECTOR | VarEnum.VT_CF):
                    return typeof(IntPtr[]);
                case (VarEnum.VT_VECTOR | VarEnum.VT_LPWSTR):
                    return typeof(string[]);
                default:
                    return typeof(object);
            }
        }
    }
}
