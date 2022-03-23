using Microsoft.WindowsAPICodePack.Win32Native;

using System;
using System.Runtime.InteropServices;

using static System.Runtime.InteropServices.UnmanagedType;

namespace Microsoft.WindowsAPICodePack.COMNative.MediaDevices
{
    [ComImport,
        Guid(NativeAPI.Guids.MediaDevices.IComponentAuthenticate),
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IComponentAuthenticate
    {
        HResult SACAuth(
            [In, MarshalAs(U4)] uint dwProtocolID,
            [In, MarshalAs(U4)] uint dwPass,
            [In, MarshalAs(LPArray)] byte[] pbDataIn,
            [In, MarshalAs(U4)] uint dwDataInLen,
            [Out, MarshalAs(LPArray)] byte[] ppbDataOut,
            [Out, MarshalAs(U4)] out uint pdwDataOutLen);

        HResult SACGetProtocols(
            [Out, MarshalAs(U4)] out uint ppdwProtocols,
            [Out, MarshalAs(U4)] out uint pdwProtocolCount);
    }

    [ComImport,
        Guid(NativeAPI.Guids.MediaDevices.MediaDevMgr),
        ClassInterface(ClassInterfaceType.None),
        TypeLibType(TypeLibTypeFlags.FCanCreate)]
    public class MediaDevMgr
    {

    }
}
