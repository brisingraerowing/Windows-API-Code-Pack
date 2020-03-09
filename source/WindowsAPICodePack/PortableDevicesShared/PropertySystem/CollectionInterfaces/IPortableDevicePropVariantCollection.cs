//using System;
//using System.Collections.Generic;
//using System.Runtime.InteropServices;
//using System.Text;

//namespace Microsoft.WindowsAPICodePack.PortableDevices.PropertySystem
//{
//    public interface IPortableDevicePropVariantCollection : WinCopies.Util.DotNetFix.IDisposable
//    {
//        uint Count { get; }

//        object GetAt(
//            in uint dwIndex,
//            out Type valueType);

//        void Add(
//            in object pValue);

//        VarEnum GetItemVariantType();

//        void ChangeItemVariantType(in VarEnum vt);

//        void Clear();

//        void RemoveAt(
//            in uint dwIndex);
//    }
//}
