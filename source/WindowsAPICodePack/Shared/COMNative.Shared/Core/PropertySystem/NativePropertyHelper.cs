using System;
using System.Runtime.InteropServices;

namespace Microsoft.WindowsAPICodePack.COMNative.PropertySystem
{
    public static class NativePropertyHelper
    {
        /// <summary>
        /// Converts <see cref="VarEnum"/> to its associated .net Type.
        /// </summary>
        /// <param name="VarEnumType"><see cref="VarEnum"/> value</param>
        /// <returns>Associated .net equivelent.</returns>
        public static Type VarEnumToSystemType(VarEnum VarEnumType)
        {
            switch (VarEnumType)
            {
                case VarEnum.VT_EMPTY:
                case VarEnum.VT_NULL:
                    return typeof(object);
                case VarEnum.VT_UI1:
                    return typeof(byte?);
                case VarEnum.VT_I2:
                    return typeof(short?);
                case VarEnum.VT_UI2:
                    return typeof(ushort?);
                case VarEnum.VT_I4:
                    return typeof(int?);
                case VarEnum.VT_UI4:
                    return typeof(uint?);
                case VarEnum.VT_I8:
                    return typeof(long?);
                case VarEnum.VT_UI8:
                    return typeof(ulong?);
                case VarEnum.VT_R8:
                    return typeof(double?);
                case VarEnum.VT_BOOL:
                    return typeof(bool?);
                case VarEnum.VT_FILETIME:
                    return typeof(DateTime?);
                case VarEnum.VT_CLSID:
                    return typeof(IntPtr?);
                case VarEnum.VT_CF:
                    return typeof(IntPtr?);
                case VarEnum.VT_BLOB:
                    return typeof(byte[]);
                case VarEnum.VT_LPWSTR:
                    return typeof(string);
                case VarEnum.VT_UNKNOWN:
                    return typeof(IntPtr?);
                case VarEnum.VT_STREAM:
                    return typeof(System.Runtime.InteropServices.ComTypes.IStream);
                case VarEnum.VT_VECTOR | VarEnum.VT_UI1:
                    return typeof(byte[]);
                case VarEnum.VT_VECTOR | VarEnum.VT_I2:
                    return typeof(short[]);
                case VarEnum.VT_VECTOR | VarEnum.VT_UI2:
                    return typeof(ushort[]);
                case VarEnum.VT_VECTOR | VarEnum.VT_I4:
                    return typeof(int[]);
                case VarEnum.VT_VECTOR | VarEnum.VT_UI4:
                    return typeof(uint[]);
                case VarEnum.VT_VECTOR | VarEnum.VT_I8:
                    return typeof(long[]);
                case VarEnum.VT_VECTOR | VarEnum.VT_UI8:
                    return typeof(ulong[]);
                case VarEnum.VT_VECTOR | VarEnum.VT_R8:
                    return typeof(double[]);
                case VarEnum.VT_VECTOR | VarEnum.VT_BOOL:
                    return typeof(bool[]);
                case VarEnum.VT_VECTOR | VarEnum.VT_FILETIME:
                    return typeof(DateTime[]);
                case VarEnum.VT_VECTOR | VarEnum.VT_CLSID:
                    return typeof(IntPtr[]);
                case VarEnum.VT_VECTOR | VarEnum.VT_CF:
                    return typeof(IntPtr[]);
                case VarEnum.VT_VECTOR | VarEnum.VT_LPWSTR:
                    return typeof(string[]);
                default:
                    return typeof(object);
            }
        }
    }
}
