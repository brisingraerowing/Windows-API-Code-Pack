﻿//Copyright (c) Microsoft Corporation.  All rights reserved.  Distributed under the Microsoft Public License (MS-PL)

using Microsoft.WindowsAPICodePack.Win32Native.Resources;

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.InteropServices;

using static Microsoft.WindowsAPICodePack.NativeAPI.Consts.DllNames;

namespace Microsoft.WindowsAPICodePack.Win32Native.PropertySystem
{
    /// <summary>
    /// Represents the OLE struct PROPVARIANT.
    /// This class is intended for managed reimplementations only.
    /// </summary>
    /// <remarks>
    /// Originally sourced from http://blogs.msdn.com/adamroot/pages/interop-with-propvariants-in-net.aspx
    /// and modified to support additional types including vectors and ability to set values
    /// </remarks>
    [StructLayout(LayoutKind.Explicit)]
    public sealed partial class PropVariant : IDisposable
    {
        #region Vector Action Cache
        // A static dictionary of delegates to get data from array's contained within PropVariants
        private static Dictionary<Type, Action<PropVariant, Array, uint>> _vectorActions = null;

        private static Dictionary<Type, Action<PropVariant, Array, uint>> GenerateVectorActions()
        {
            var cache = new Dictionary<Type, Action<PropVariant, Array, uint>>
            {
                {
                    typeof(short),
                    (pv, array, i) =>
    {
        PropVariantGetInt16Elem(pv, i, out short val);
        array.SetValue(val, i);
    }
                },

                {
                    typeof(ushort),
                    (pv, array, i) =>
   {
       PropVariantGetUInt16Elem(pv, i, out ushort val);
       array.SetValue(val, i);
   }
                },

                {
                    typeof(int),
                    (pv, array, i) =>
    {
        PropVariantGetInt32Elem(pv, i, out int val);
        array.SetValue(val, i);
    }
                },

                {
                    typeof(uint),
                    (pv, array, i) =>
   {
       PropVariantGetUInt32Elem(pv, i, out uint val);
       array.SetValue(val, i);
   }
                },

                {
                    typeof(long),
                    (pv, array, i) =>
    {
        PropVariantGetInt64Elem(pv, i, out long val);
        array.SetValue(val, i);
    }
                },

                {
                    typeof(ulong),
                    (pv, array, i) =>
   {
       PropVariantGetUInt64Elem(pv, i, out ulong val);
       array.SetValue(val, i);
   }
                },

                {
                    typeof(System.DateTime),
                    (pv, array, i) =>
 {
     PropVariantGetFileTimeElem(pv, i, out System.Runtime.InteropServices.ComTypes.FILETIME val);

     long fileTime = GetFileTimeAsLong(ref val);

     array.SetValue(System.DateTime.FromFileTime(fileTime), i);
 }
                },

                {
                    typeof(bool),
                    (pv, array, i) =>
  {
      PropVariantGetBooleanElem(pv, i, out bool val);
      array.SetValue(val, i);
  }
                },

                {
                    typeof(double),
                    (pv, array, i) =>
   {
       PropVariantGetDoubleElem(pv, i, out double val);
       array.SetValue(val, i);
   }
                },

                {
                    typeof(float),
                    (pv, array, i) => // float
                    {
                        float[] val = new float[1];
                        Marshal.Copy(pv._ptr2, val, (int)i, 1);
                        array.SetValue(val[0], (int)i);
                    }
                },

                {
                    typeof(decimal),
                    (pv, array, i) =>
  {
      int[] val = new int[4];
      for (int a = 0; a < val.Length; a++)

          val[a] = Marshal.ReadInt32(pv._ptr2,
              ((int)i * sizeof(decimal)) + (a * sizeof(int))); //index * size + offset quarter
                
      array.SetValue(new decimal(val), i);
  }
                },

                {
                    typeof(string),
                    (pv, array, i) =>
   {
       string val = string.Empty;
       PropVariantGetStringElem(pv, i, ref val);
       array.SetValue(val, i);
   }
                }
            };

            return cache;
        }
        #endregion

        #region Dynamic Construction / Factory (Expressions)
        /// <summary>
        /// Attempts to create a PropVariant by finding an appropriate constructor.
        /// </summary>
        /// <param name="value">Object from which PropVariant should be created.</param>
        public static PropVariant FromObject(object value) => value == null ? new PropVariant() : GetDynamicConstructor(value.GetType())(value);

        // A dictionary and lock to contain compiled expression trees for constructors
        private static readonly Dictionary<Type, Func<object, PropVariant>> _cache = new Dictionary<Type, Func<object, PropVariant>>();
        private static readonly object _padlock = new object();

        // Retrieves a cached constructor expression.
        // If no constructor has been cached, it attempts to find/add it.  If it cannot be found
        // an exception is thrown.
        // This method looks for a public constructor with the same parameter type as the object.
        private static Func<object, PropVariant> GetDynamicConstructor(Type type)
        {
            lock (_padlock)
            {
                // initial check, if action is found, return it
                if (!_cache.TryGetValue(type, out Func<object, PropVariant> action))
                {
                    // iterates through all constructors
                    ConstructorInfo constructor = typeof(PropVariant)
                        .GetConstructor(new Type[] { type });

                    if (constructor == null)
                        // if the method was not found, throw.
                        throw new ArgumentException(LocalizedMessages.PropVariantTypeNotSupported);

                    else // if the method was found, create an expression to call it.
                    {
                        // create parameters to action                    
                        ParameterExpression arg = Expression.Parameter(typeof(object), nameof(arg));

                        // create an expression to invoke the constructor with an argument cast to the correct type
                        NewExpression create = Expression.New(constructor, Expression.Convert(arg, type));

                        // compiles expression into an action delegate
                        action = Expression.Lambda<Func<object, PropVariant>>(create, arg).Compile();
                        _cache.Add(type, action);
                    }
                }
                return action;
            }
        }
        #endregion

        #region Fields
        [FieldOffset(0)]
        decimal _decimal;

        // This is actually a VarEnum value, but the VarEnum type
        // requires 4 bytes instead of the expected 2.
        [FieldOffset(0)]
        ushort _valueType;

        // Reserved Fields
        //[FieldOffset(2)]
        //ushort _wReserved1;
        //[FieldOffset(4)]
        //ushort _wReserved2;
        //[FieldOffset(6)]
        //ushort _wReserved3;

        // In order to allow x64 compat, we need to allow for
        // expansion of the IntPtr. However, the BLOB struct
        // uses a 4-byte int, followed by an IntPtr, so
        // although the valueData field catches most pointer values,
        // we need an additional 4-bytes to get the BLOB
        // pointer. The valueDataExt field provides this, as well as
        // the last 4-bytes of an 8-byte value on 32-bit
        // architectures.
        [FieldOffset(16)]
        IntPtr _ptr2;
        [FieldOffset(8)]
        IntPtr _ptr;
        [FieldOffset(8)]
        int _int32;
        [FieldOffset(8)]
        uint _uint32;
        [FieldOffset(8)]
        byte _byte;
        [FieldOffset(8)]
        sbyte _sbyte;
        [FieldOffset(8)]
        short _short;
        [FieldOffset(8)]
        ushort _ushort;
        [FieldOffset(8)]
        long _long;
        [FieldOffset(8)]
        ulong _ulong;
        [FieldOffset(8)]
        double _double;
        [FieldOffset(8)]
        float _float;
        #endregion Fields

        #region Constructors
        /// <summary>
        /// Default constrcutor
        /// </summary>
        public PropVariant() { /* Left empty. */ }

        /// <summary>
        /// Set a <see cref="string"/> value
        /// </summary>
        public PropVariant(string value)
        {
            if (value == null)

                throw new ArgumentException(LocalizedMessages.PropVariantNullString, nameof(value));

            _valueType = (ushort)VarEnum.VT_LPWSTR;
            _ptr = Marshal.StringToCoTaskMemUni(value);
        }

        private static void ThrowIfNull(object value) => WinCopies.
#if WAPICP3
            ThrowHelper
#else
            Util.Util
#endif
            .ThrowIfNull(value, nameof(value));

        private static ArgumentNullException GetArgumentNullException() => new ArgumentNullException("value");

        /// <summary>
        /// Set a <see cref="string"/> vector
        /// </summary>
        public PropVariant(string[] value) => InitPropVariantFromStringVector(value ?? throw GetArgumentNullException(), (uint)value.Length, this);

        /// <summary>
        /// Set a <see cref="bool"/> vector
        /// </summary>
        public PropVariant(bool[] value) => InitPropVariantFromBooleanVector(value ?? throw GetArgumentNullException(), (uint)value.Length, this);

        /// <summary>
        /// Set a <see cref="short"/> vector
        /// </summary>
        public PropVariant(short[] value) => InitPropVariantFromInt16Vector(value ?? throw GetArgumentNullException(), (uint)value.Length, this);

        /// <summary>
        /// Set a <see cref="ushort"/> vector
        /// </summary>
        public PropVariant(ushort[] value) => InitPropVariantFromUInt16Vector(value ?? throw GetArgumentNullException(), (uint)value.Length, this);

        /// <summary>
        /// Set an <see cref="int"/> vector
        /// </summary>
        public PropVariant(int[] value) => InitPropVariantFromInt32Vector(value ?? throw GetArgumentNullException(), (uint)value.Length, this);

        /// <summary>
        /// Set a <see cref="uint"/> vector
        /// </summary>
        public PropVariant(uint[] value) => InitPropVariantFromUInt32Vector(value ?? throw GetArgumentNullException(), (uint)value.Length, this);

        /// <summary>
        /// Set a <see cref="long"/> vector
        /// </summary>
        public PropVariant(long[] value) => InitPropVariantFromInt64Vector(value ?? throw GetArgumentNullException(), (uint)value.Length, this);

        /// <summary>
        /// Set a <see cref="ulong"/> vector
        /// </summary>
        public PropVariant(ulong[] value) => InitPropVariantFromUInt64Vector(value ?? throw GetArgumentNullException(), (uint)value.Length, this);

        /// <summary>>
        /// Set a <see cref="double"/> vector
        /// </summary>
        public PropVariant(double[] value) => InitPropVariantFromDoubleVector(value ?? throw GetArgumentNullException(), (uint)value.Length, this);



        /// <summary>
        /// Set a <see cref="DateTime"/> vector
        /// </summary>
        public PropVariant(DateTime[] value)
        {
            ThrowIfNull(value);

            var fileTimeArr =
                new System.Runtime.InteropServices.ComTypes.FILETIME[value.Length];

            for (int i = 0; i < value.Length; i++)

                fileTimeArr[i] = DateTimeToFileTime(value[i]);

            InitPropVariantFromFileTimeVector(fileTimeArr, (uint)fileTimeArr.Length, this);
        }

        /// <summary>
        /// Set a <see cref="bool"/> value
        /// </summary>
        public PropVariant(bool value)
        {
            _valueType = (ushort)VarEnum.VT_BOOL;
            _int32 = (value == true) ? -1 : 0;
        }

        /// <summary>
        /// Set a <see cref="DateTime"/> value
        /// </summary>
        public PropVariant(DateTime value)
        {
            _valueType = (ushort)VarEnum.VT_FILETIME;

            System.Runtime.InteropServices.ComTypes.FILETIME ft = DateTimeToFileTime(value);
            InitPropVariantFromFileTime(ref ft, this);
        }

        /// <summary>
        /// Set a <see cref="byte"/> value
        /// </summary>
        public PropVariant(byte value)
        {
            _valueType = (ushort)VarEnum.VT_UI1;
            _byte = value;
        }

        /// <summary>
        /// Set a <see cref="sbyte"/> value
        /// </summary>
        public PropVariant(sbyte value)
        {
            _valueType = (ushort)VarEnum.VT_I1;
            _sbyte = value;
        }

        /// <summary>
        /// Set a <see cref="short"/> value
        /// </summary>
        public PropVariant(short value)
        {
            _valueType = (ushort)VarEnum.VT_I2;
            _short = value;
        }

        /// <summary>
        /// Set a <see cref="ushort"/> value
        /// </summary>
        public PropVariant(ushort value)
        {
            _valueType = (ushort)VarEnum.VT_UI2;
            _ushort = value;
        }

        /// <summary>
        /// Set an <see cref="int"/> value
        /// </summary>
        public PropVariant(int value)
        {
            _valueType = (ushort)VarEnum.VT_I4;
            _int32 = value;
        }

        /// <summary>
        /// Set a <see cref="uint"/> value
        /// </summary>
        public PropVariant(uint value)
        {
            _valueType = (ushort)VarEnum.VT_UI4;
            _uint32 = value;
        }

        /// <summary>
        /// Set a <see cref="decimal"/> value
        /// </summary>
        public PropVariant(decimal value)
        {
            _decimal = value;

            // It is critical that the value type be set after the decimal value, because they overlap.
            // If valuetype is written first, its value will be lost when _decimal is written.
            _valueType = (ushort)VarEnum.VT_DECIMAL;
        }

        /// <summary>
        /// Create a <see cref="PropVariant"/> with a contained <see cref="decimal"/> array.
        /// </summary>
        /// <param name="value"><see cref="decimal"/> array to wrap.</param>
        public PropVariant(decimal[] value)
        {
            ThrowIfNull(value);

            _valueType = (ushort)(VarEnum.VT_DECIMAL | VarEnum.VT_VECTOR);
            _int32 = value.Length;

            // allocate required memory for array with 128bit elements
            _ptr2 = Marshal.AllocCoTaskMem(value.Length * sizeof(decimal));
            for (int i = 0; i < value.Length; i++)
            {
                int[] bits = decimal.GetBits(value[i]);
                Marshal.Copy(bits, 0, _ptr2, bits.Length);
            }
        }

        /// <summary>
        /// Create a <see cref="PropVariant"/> containing a <see cref="float"/> value.
        /// </summary>        
        public PropVariant(float value)
        {
            _valueType = (ushort)VarEnum.VT_R4;

            _float = value;
        }

        /// <summary>
        /// Creates a <see cref="PropVariant"/> containing a <see cref="float"/> array.
        /// </summary>        
        public PropVariant(float[] value)
        {
            ThrowIfNull(value);

            _valueType = (ushort)(VarEnum.VT_R4 | VarEnum.VT_VECTOR);
            _int32 = value.Length;

            _ptr2 = Marshal.AllocCoTaskMem(value.Length * sizeof(float));

            Marshal.Copy(value, 0, _ptr2, value.Length);
        }

        /// <summary>
        /// Set a <see cref="long"/>
        /// </summary>
        public PropVariant(long value)
        {
            _long = value;
            _valueType = (ushort)VarEnum.VT_I8;
        }

        /// <summary>
        /// Set a <see cref="ulong"/>
        /// </summary>
        public PropVariant(ulong value)
        {
            _valueType = (ushort)VarEnum.VT_UI8;
            _ulong = value;
        }

        /// <summary>
        /// Set a <see cref="double"/>
        /// </summary>
        public PropVariant(double value)
        {
            _valueType = (ushort)VarEnum.VT_R8;
            _double = value;
        }
        #endregion

        #region Uncalled methods - These are currently not called, but I think may be valid in the future.
        /// <summary>
        /// Set an IUnknown value
        /// </summary>
        /// <param name="value">The new value to set.</param>
        internal void SetIUnknown(object value)
        {
            _valueType = (ushort)VarEnum.VT_UNKNOWN;
            _ptr = Marshal.GetIUnknownForObject(value);
        }

        /// <summary>
        /// Set a safe array value
        /// </summary>
        /// <param name="array">The new value to set.</param>
        internal void SetSafeArray(Array array)
        {
            if (array == null) throw new ArgumentNullException(nameof(array));

            const ushort vtUnknown = 13;
            IntPtr psa = SafeArrayCreateVector(vtUnknown, 0, (uint)array.Length);

            IntPtr pvData = SafeArrayAccessData(psa);
            try // to remember to release lock on data
            {
                for (int i = 0; i < array.Length; ++i)
                {
                    object obj = array.GetValue(i);
                    IntPtr punk = (obj != null) ? Marshal.GetIUnknownForObject(obj) : IntPtr.Zero;
                    Marshal.WriteIntPtr(pvData, i * IntPtr.Size, punk);
                }
            }

            finally
            {
                SafeArrayUnaccessData(psa);
            }

            _valueType = (ushort)VarEnum.VT_ARRAY | (ushort)VarEnum.VT_UNKNOWN;
            _ptr = psa;
        }
        #endregion

        #region public Properties
        /// <summary>
        /// Gets or sets the variant type.
        /// </summary>
        public VarEnum VarType
        {
            get => (VarEnum)_valueType;
            set => _valueType = (ushort)value;
        }

        /// <summary>
        /// Checks if this has an empty or null value
        /// </summary>
        /// <returns></returns>
        public bool IsNullOrEmpty => _valueType == (ushort)VarEnum.VT_EMPTY || _valueType == (ushort)VarEnum.VT_NULL;

        /// <summary>
        /// Gets the variant value.
        /// </summary>
        public object Value
        {
            get
            {
                switch ((VarEnum)_valueType)
                {
                    case VarEnum.VT_I1:
                        return _sbyte;
                    case VarEnum.VT_UI1:
                        return _byte;
                    case VarEnum.VT_I2:
                        return _short;
                    case VarEnum.VT_UI2:
                        return _ushort;
                    case VarEnum.VT_I4:
                    case VarEnum.VT_INT:
                        return _int32;
                    case VarEnum.VT_UI4:
                    case VarEnum.VT_UINT:
                        return _uint32;
                    case VarEnum.VT_I8:
                        return _long;
                    case VarEnum.VT_UI8:
                        return _ulong;
                    case VarEnum.VT_R4:
                        return _float;
                    case VarEnum.VT_R8:
                        return _double;
                    case VarEnum.VT_BOOL:
                        return _int32 == -1;
                    case VarEnum.VT_ERROR:
                        return _long;
                    case VarEnum.VT_CY:
                        return _decimal;
                    case VarEnum.VT_DATE:
                        return System.DateTime.FromOADate(_double);
                    case VarEnum.VT_FILETIME:
                        return System.DateTime.FromFileTime(_long);
                    case VarEnum.VT_BSTR:
                        return Marshal.PtrToStringBSTR(_ptr);
                    case VarEnum.VT_BLOB:
                        return GetBlobData();
                    case VarEnum.VT_LPSTR:
                        return Marshal.PtrToStringAnsi(_ptr);
                    case VarEnum.VT_LPWSTR:
                        return Marshal.PtrToStringUni(_ptr);
                    case VarEnum.VT_UNKNOWN:
                        return Marshal.GetObjectForIUnknown(_ptr);
                    case VarEnum.VT_DISPATCH:
                        return Marshal.GetObjectForIUnknown(_ptr);
                    case VarEnum.VT_DECIMAL:
                        return _decimal;
                    case VarEnum.VT_CLSID:
                        return Marshal.PtrToStructure
#if CS7
                            <Guid>(_ptr);
#else
                            (_ptr, typeof(Guid));
#endif
                    case VarEnum.VT_ARRAY | VarEnum.VT_UNKNOWN:
                        return CrackSingleDimSafeArray(_ptr);
                    case (VarEnum.VT_VECTOR | VarEnum.VT_LPWSTR):
                        return GetVector<string>();
                    case (VarEnum.VT_VECTOR | VarEnum.VT_I2):
                        return GetVector<short>();
                    case (VarEnum.VT_VECTOR | VarEnum.VT_UI2):
                        return GetVector<ushort>();
                    case (VarEnum.VT_VECTOR | VarEnum.VT_I4):
                        return GetVector<int>();
                    case (VarEnum.VT_VECTOR | VarEnum.VT_UI4):
                        return GetVector<uint>();
                    case (VarEnum.VT_VECTOR | VarEnum.VT_I8):
                        return GetVector<long>();
                    case (VarEnum.VT_VECTOR | VarEnum.VT_UI8):
                        return GetVector<ulong>();
                    case (VarEnum.VT_VECTOR | VarEnum.VT_R4):
                        return GetVector<float>();
                    case (VarEnum.VT_VECTOR | VarEnum.VT_R8):
                        return GetVector<double>();
                    case (VarEnum.VT_VECTOR | VarEnum.VT_BOOL):
                        return GetVector<bool>();
                    case (VarEnum.VT_VECTOR | VarEnum.VT_FILETIME):
                        return GetVector<DateTime>();
                    case (VarEnum.VT_VECTOR | VarEnum.VT_DECIMAL):
                        return GetVector<decimal>();
                    default:
                        // if the value cannot be marshaled
                        return null;
                }
            }
        }
        #endregion

        public static long GetLong(int high, int low) => (((long)high) << 32) | (uint)low;
        public static ulong GetULong(uint high, uint low) => (((ulong)high) << 32) | low;

        public static long GetFileTimeAsLong(ref System.Runtime.InteropServices.ComTypes.FILETIME val) => GetLong(val.dwHighDateTime, val.dwLowDateTime);
        public static ulong GetFileTimeAsULong(Shell.FileTime val) => GetULong(val.dwHighDateTime, val.dwLowDateTime);

        public static System.Runtime.InteropServices.ComTypes.FILETIME DateTimeToFileTime(System.DateTime value) => DateTimeToFileTime(value.ToFileTime());
        public static System.Runtime.InteropServices.ComTypes.FILETIME DateTimeToFileTimeUTC(System.DateTime value) => DateTimeToFileTime(value.ToFileTimeUtc());

        #region Private Methods
        private static System.Runtime.InteropServices.ComTypes.FILETIME DateTimeToFileTime(in long value) => new System.Runtime.InteropServices.ComTypes.FILETIME
        {
            dwLowDateTime = (int)(value & 0xFFFFFFFF),
            dwHighDateTime = (int)(value >> 32)
        };

        private object GetBlobData()
        {
            byte[] blobData = new byte[_int32];

            IntPtr pBlobData = _ptr2;
            Marshal.Copy(pBlobData, blobData, 0, _int32);

            return blobData;
        }

        private Array GetVector<T>()
        {
            int count = PropVariantGetElementCount(this);

            if (count <= 0) return null;

            lock (_padlock)
            {
#if CS8
                _vectorActions ??= GenerateVectorActions();
#else
                if (_vectorActions == null)

                    _vectorActions = GenerateVectorActions();
#endif
            }

            if (_vectorActions.TryGetValue(typeof(T), out Action<PropVariant, Array, uint> action))
            {
                Array array = new T[count];

                for (uint i = 0; i < count; i++)

                    action(this, array, i);

                return array;
            }

            throw new InvalidCastException(LocalizedMessages.PropVariantUnsupportedType);
        }

        private static Array CrackSingleDimSafeArray(IntPtr psa)
        {
            if (SafeArrayGetDim(psa) != 1)

                throw new ArgumentException(LocalizedMessages.PropVariantMultiDimArray, nameof(psa));

            int lBound = SafeArrayGetLBound(psa, 1U);
            int uBound = SafeArrayGetUBound(psa, 1U);

            int n = uBound - lBound + 1; // uBound is inclusive

            object[] array = new object[n];

            for (int i = lBound; i <= uBound; ++i)

                array[i] = SafeArrayGetElement(psa, ref i);

            return array;
        }
        #endregion

        #region IDisposable Members
        /// <summary>
        /// Disposes the object, calls the clear function.
        /// </summary>
        public void Dispose()
        {
            PropVariantClear(this);

            GC.SuppressFinalize(this);
        }

        ~PropVariant() => Dispose();
        #endregion

        /// <summary>
        /// Provides an simple string representation of the contained data and type.
        /// </summary>
        /// <returns></returns>
        public override string ToString() => string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "{0}: {1}", Value, VarType.ToString());

        #region Native methods
        [DllImport(Ole32, PreserveSig = false)] // returns hresult
        public extern static void PropVariantClear([In, Out] PropVariant pvar);

        [DllImport(OleAut32, PreserveSig = true)] // psa is actually returned, not hresult
        public extern static IntPtr SafeArrayCreateVector(ushort vt, int lowerBound, uint cElems);

        [DllImport(OleAut32, PreserveSig = false)] // returns hresult
        public extern static IntPtr SafeArrayAccessData(IntPtr psa);

        [DllImport(OleAut32, PreserveSig = false)] // returns hresult
        public extern static void SafeArrayUnaccessData(IntPtr psa);

        [DllImport(OleAut32, PreserveSig = true)] // retuns uint32
        public extern static uint SafeArrayGetDim(IntPtr psa);

        [DllImport(OleAut32, PreserveSig = false)] // returns hresult
        public extern static int SafeArrayGetLBound(IntPtr psa, uint nDim);

        [DllImport(OleAut32, PreserveSig = false)] // returns hresult
        public extern static int SafeArrayGetUBound(IntPtr psa, uint nDim);

        // This decl for SafeArrayGetElement is only valid for cDims==1!
        [DllImport(OleAut32, PreserveSig = false)] // returns hresult
        [return: MarshalAs(UnmanagedType.IUnknown)]
        public extern static object SafeArrayGetElement(IntPtr psa, ref int rgIndices);

        [DllImport(Propsys, CharSet = CharSet.Unicode, SetLastError = true, PreserveSig = false)]
        public static extern void InitPropVariantFromPropVariantVectorElem([In] PropVariant propvarIn, uint iElem, [Out] PropVariant ppropvar);

        [DllImport(Propsys, CharSet = CharSet.Unicode, SetLastError = true, PreserveSig = false)]
        public static extern void InitPropVariantFromFileTime([In] ref System.Runtime.InteropServices.ComTypes.FILETIME pftIn, [Out] PropVariant ppropvar);

        [DllImport(Propsys, CharSet = CharSet.Unicode, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.I4)]
        public static extern int PropVariantGetElementCount([In] PropVariant propVar);

        [DllImport(Propsys, CharSet = CharSet.Unicode, SetLastError = true, PreserveSig = false)]
        public static extern void PropVariantGetBooleanElem([In] PropVariant propVar, [In] uint iElem, [Out, MarshalAs(UnmanagedType.Bool)] out bool pfVal);

        [DllImport(Propsys, CharSet = CharSet.Unicode, SetLastError = true, PreserveSig = false)]
        public static extern void PropVariantGetInt16Elem([In] PropVariant propVar, [In] uint iElem, [Out] out short pnVal);

        [DllImport(Propsys, CharSet = CharSet.Unicode, SetLastError = true, PreserveSig = false)]
        public static extern void PropVariantGetUInt16Elem([In] PropVariant propVar, [In] uint iElem, [Out] out ushort pnVal);

        [DllImport(Propsys, CharSet = CharSet.Unicode, SetLastError = true, PreserveSig = false)]
        public static extern void PropVariantGetInt32Elem([In] PropVariant propVar, [In] uint iElem, [Out] out int pnVal);

        [DllImport(Propsys, CharSet = CharSet.Unicode, SetLastError = true, PreserveSig = false)]
        public static extern void PropVariantGetUInt32Elem([In] PropVariant propVar, [In] uint iElem, [Out] out uint pnVal);

        [DllImport(Propsys, CharSet = CharSet.Unicode, SetLastError = true, PreserveSig = false)]
        public static extern void PropVariantGetInt64Elem([In] PropVariant propVar, [In] uint iElem, [Out] out long pnVal);

        [DllImport(Propsys, CharSet = CharSet.Unicode, SetLastError = true, PreserveSig = false)]
        public static extern void PropVariantGetUInt64Elem([In] PropVariant propVar, [In] uint iElem, [Out] out ulong pnVal);

        [DllImport(Propsys, CharSet = CharSet.Unicode, SetLastError = true, PreserveSig = false)]
        public static extern void PropVariantGetDoubleElem([In] PropVariant propVar, [In] uint iElem, [Out] out double pnVal);

        [DllImport(Propsys, CharSet = CharSet.Unicode, SetLastError = true, PreserveSig = false)]
        public static extern void PropVariantGetFileTimeElem([In] PropVariant propVar, [In] uint iElem, [Out, MarshalAs(UnmanagedType.Struct)] out System.Runtime.InteropServices.ComTypes.FILETIME pftVal);

        [DllImport(Propsys, CharSet = CharSet.Unicode, SetLastError = true, PreserveSig = false)]
        public static extern void PropVariantGetStringElem([In] PropVariant propVar, [In] uint iElem, [MarshalAs(UnmanagedType.LPWStr)] ref string ppszVal);

        [DllImport(Propsys, CharSet = CharSet.Unicode, SetLastError = true, PreserveSig = false)]
        public static extern void InitPropVariantFromBooleanVector([In, MarshalAs(UnmanagedType.LPArray)] bool[] prgf, uint cElems, [Out] PropVariant ppropvar);

        [DllImport(Propsys, CharSet = CharSet.Unicode, SetLastError = true, PreserveSig = false)]
        public static extern void InitPropVariantFromInt16Vector([In, Out] Int16[] prgn, uint cElems, [Out] PropVariant ppropvar);

        [DllImport(Propsys, CharSet = CharSet.Unicode, SetLastError = true, PreserveSig = false)]
        public static extern void InitPropVariantFromUInt16Vector([In, Out] UInt16[] prgn, uint cElems, [Out] PropVariant ppropvar);

        [DllImport(Propsys, CharSet = CharSet.Unicode, SetLastError = true, PreserveSig = false)]
        public static extern void InitPropVariantFromInt32Vector([In, Out] Int32[] prgn, uint cElems, [Out] PropVariant propVar);

        [DllImport(Propsys, CharSet = CharSet.Unicode, SetLastError = true, PreserveSig = false)]
        public static extern void InitPropVariantFromUInt32Vector([In, Out] UInt32[] prgn, uint cElems, [Out] PropVariant ppropvar);

        [DllImport(Propsys, CharSet = CharSet.Unicode, SetLastError = true, PreserveSig = false)]
        public static extern void InitPropVariantFromInt64Vector([In, Out] Int64[] prgn, uint cElems, [Out] PropVariant ppropvar);

        [DllImport(Propsys, CharSet = CharSet.Unicode, SetLastError = true, PreserveSig = false)]
        public static extern void InitPropVariantFromUInt64Vector([In, Out] UInt64[] prgn, uint cElems, [Out] PropVariant ppropvar);

        [DllImport(Propsys, CharSet = CharSet.Unicode, SetLastError = true, PreserveSig = false)]
        public static extern void InitPropVariantFromDoubleVector([In, Out] double[] prgn, uint cElems, [Out] PropVariant propvar);

        [DllImport(Propsys, CharSet = CharSet.Unicode, SetLastError = true, PreserveSig = false)]
        public static extern void InitPropVariantFromFileTimeVector([In, Out] System.Runtime.InteropServices.ComTypes.FILETIME[] prgft, uint cElems, [Out] PropVariant ppropvar);

        [DllImport(Propsys, CharSet = CharSet.Unicode, SetLastError = true, PreserveSig = false)]
        public static extern void InitPropVariantFromStringVector([In, Out] string[] prgsz, uint cElems, [Out] PropVariant ppropvar);
        #endregion
    }
}
