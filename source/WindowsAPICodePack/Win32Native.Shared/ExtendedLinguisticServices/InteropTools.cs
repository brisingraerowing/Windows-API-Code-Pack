// Copyright (c) Microsoft Corporation.  All rights reserved.

using System;
using System.Runtime.InteropServices;
using System.Collections;
using System.Collections.Generic;
using Microsoft.WindowsAPICodePack.Win32Native.ExtendedLinguisticServices;
using Microsoft.WindowsAPICodePack.ExtendedLinguisticServices;

namespace Microsoft.WindowsAPICodePack.Win32Native.ExtendedLinguisticServices
{

    public static class InteropTools
    {
        // TODO: put these fields to Win32Native?
        public static readonly IntPtr SizeOfGuid = (IntPtr)Marshal.SizeOf(typeof(Guid));
        public static readonly IntPtr SizeOfWin32EnumOptions = (IntPtr)Marshal.SizeOf(typeof(Win32EnumOptions));
        public static readonly IntPtr SizeOfWin32Options = (IntPtr)Marshal.SizeOf(typeof(Win32Options));
        public static readonly ulong SizeOfService = (ulong)Marshal.SizeOf(typeof(Win32Service));
        public static readonly IntPtr SizeOfWin32PropertyBag = (IntPtr)Marshal.SizeOf(typeof(Win32PropertyBag));
        public static readonly ulong SizeOfWin32DataRange = (ulong)Marshal.SizeOf(typeof(Win32DataRange));
        public static readonly ulong OffsetOfGuidInService = (ulong)Marshal.OffsetOf(typeof(Win32Service), "_guid");
        public static readonly Type TypeOfGuid = typeof(Guid);

        public static T Unpack<T>(IntPtr value) where T : struct => value == IntPtr.Zero ? (default) : (T)Marshal.PtrToStructure(value, typeof(T));

        public static IntPtr Pack<T>(ref T data) where T : struct
        {
            IntPtr pointer = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(T)));
            Marshal.StructureToPtr(data, pointer, false);
            return pointer;
        }

        public static void Free<T>(ref IntPtr pointer) where T : struct
        {
            if (pointer == IntPtr.Zero)

                return;    
            
                // Thus we clear the strings previously allocated to the struct:
                Marshal.StructureToPtr(default(T), pointer, true);
                // Here we clean up the memory for the struct itself:
                Marshal.FreeHGlobal(pointer);
                // This is to avoid calling freeing this pointer multiple times:
                pointer = IntPtr.Zero;
                    }

        public static string[] UnpackStringArray(IntPtr strPtr, uint count)
        {
            if (strPtr == IntPtr.Zero && count != 0)
            
                throw new LinguisticException(Win32Native.Consts.ExtendedLinguisticServices.InvalidArgs);
            
            string[] retVal = new string[count];

            int offset = 0;
            for (int i = 0; i < count; i++)
            {
                retVal[i] = Marshal.PtrToStringUni(Marshal.ReadIntPtr(strPtr, offset));
                offset += IntPtr.Size;
            }

            return retVal;
        }

    }

}
