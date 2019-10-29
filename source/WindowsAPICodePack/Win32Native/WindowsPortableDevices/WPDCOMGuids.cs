using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.WindowsAPICodePack.Win32Native.PortableDevices
{
    public static class WPDCOMGuids
    {
        public const string IEnumPortableDeviceObjectID = "10ece955-cf41-4728-bfa0-41eedf1bbf19";
        public const string IPortableDevice = "625e2df8-6392-4cf0-9ad1-3cfa5f17775c";
        public const string IPortableDeviceCapabilities = "2c8c6dbf-e3dc-4061-becc-8542e810d126";
        public const string IPortableDeviceContent = "6a96ed84-7c73-4480-9938-bf5af477d426";
        public const string IPortableDeviceContent2 = "9b4add96-f6bf-4034-8708-eca72bf10554";
        public const string IPortableDeviceDataStream = "88e04db3-1012-4d64-9996-f703a950d3f4";
        public const string IPortableDeviceEventCallback = "a8792a31-f385-493c-a893-40f64eb45f6e";
        public const string IPortableDeviceManager = "a1567595-4c2f-4574-a6fa-ecef917b9a40";
        public const string IPortableDeviceProperties = "7f6d695c-03df-4439-a809-59266beee3a6";
        public const string IPortableDevicePropertiesBulk = "482b05c0-4056-44ed-9e0f-5e23b009da93";
        public const string IPortableDevicePropertiesBulkCallback = "9deacb80-11e8-40e3-a9f3-f557986a7845";
        public const string IPortableDeviceResources = "fd8878ac-d841-4d17-891c-e6829cdb6934";
        public const string IPortableDeviceService = "d3bd3a44-d7b5-40a9-98b7-2fa4d01dec08";
        public const string IPortableDeviceServiceCapabilities = "24dbd89d-413e-43e0-bd5b-197f3c56c886";
        public const string IPortableDeviceUnitsStream = "5e98025f-bfc4-47a2-9a5f-bc900a507c67";
        public const string IPortableDeviceServiceMethods = "e20333c9-fd34-412d-a381-cc6f2d820df7";
        public const string IPortableDeviceServiceMethodCallback = "c424233c-afce-4828-a756-7ed7a2350083";
        public const string IPortableDeviceServiceManager = "a8abc4e9-a84a-47a9-80b3-c5d9b172a961";
        public const string IPortableDeviceKeyCollection = "dada2357-e0ad-492e-98db-dd61c53ba353";
        public const string IPortableDevicePropVariantCollection = "89b2e422-4f1b-4316-bcef-a44afea83eb3";
        public const string IPortableDeviceValues = "6848f6f2-3155-4f86-b6f5-263eeeab3143";
        public const string IPortableDeviceValuesCollection = "6e3f2d79-4e07-48c4-8208-d8c2e5af4a99";

        public const string PortableDeviceFTM = "f7c0039a-4762-488a-b4b3-760ef9a1ba9b";
        [Obsolete("This CLSID does not aggregates the free-threaded marshaler and is here for legacy reasons. Use the IPortableDeviceFTM constant instead.")]
        public const string PortableDevice = "728a21c5-3d9e-48d7-9810-864848f0f404";
        public const string PortableDeviceManager = "0af10cec-2ecd-4b92-9581-34f6ae0637f3";
    }
}
