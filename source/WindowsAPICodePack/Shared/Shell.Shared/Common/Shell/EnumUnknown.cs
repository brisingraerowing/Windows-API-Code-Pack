﻿//Copyright (c) Microsoft Corporation.  All rights reserved.  Distributed under the Microsoft Public License (MS-PL)

using Microsoft.WindowsAPICodePack.COMNative.Shell;
using Microsoft.WindowsAPICodePack.Win32Native;

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Microsoft.WindowsAPICodePack.Shell
{
    internal class EnumUnknownClass : IEnumUnknown
    {
        readonly List<ICondition> conditionList = new List<ICondition>();
        int current = -1;

        internal EnumUnknownClass(ICondition[] conditions) => conditionList.AddRange(conditions);

        #region IEnumUnknown Members
        public HResult Next(uint requestedNumber, ref IntPtr buffer, ref uint fetchedNumber)
        {
            current++;

            if (current < conditionList.Count)
            {
                buffer = Marshal.GetIUnknownForObject(conditionList[current]);
                fetchedNumber = 1;
                return HResult.Ok;
            }

            return HResult.False;
        }

        public HResult Skip(uint number)
        {
            int temp = current + (int)number;

            if (temp > (conditionList.Count - 1))
            
                return HResult.False;
            
            current = temp;

            return HResult.Ok;
        }

        public HResult Reset()
        {
            current = -1;

            return HResult.Ok;
        }

        public HResult Clone(out IEnumUnknown result)
        {
            result = new EnumUnknownClass(conditionList.ToArray());

            return HResult.Ok;
        }
        #endregion
    }
}