// Some parts of this file are Copyright (c) Microsoft Corporation.  All rights reserved.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.WindowsAPICodePack.Win32Native.ShellExtensions

{

    public static class Guids

    {

        public const string IPreviewHandler = "8895b1c6-b41f-4c1c-a562-0d564250836f";
        public const string IPreviewHandlerFrame = "fec87aaf-35f9-447a-adb7-20234491401a";
        public const string IPreviewHandlerVisuals = "8327b13c-b63f-4b24-9b8a-d010dcc3f599";
        public const string IThumbnailProvider = "e357fccd-a995-4576-b01f-234630154e96";

        public const string IInitializeWithFile = "b7d14566-0509-4cce-a71f-0a554233bd9b";
        public const string IInitializeWithStream = "b824b49d-22ac-4161-ac8a-9916e8fa3f7f";
        public const string IInitializeWithItem = "7f73be3f-fb79-493c-a6c7-7ee14e245841";

        public const string IObjectWithSite = "fc4801a3-2ba9-11cf-a229-00aa003d7352";
        public const string IOleWindow = "00000114-0000-0000-C000-000000000046";

    }

}

namespace Microsoft.WindowsAPICodePack

{

    public static class DevInterfaceGuids

    {

        public const string Sensor = "BA1BB692-9B7A-4833-9A1E-525ED134E7E2";

    }

}

namespace Microsoft.WindowsAPICodePack.Sensors

{

    public static class Guids

    {

        public static class EventSystem

        {

            /// <summary>
            /// Register for sensor state change notifications.
            /// </summary>
            public const string StateChanged = "BFD96016-6BD7-4560-AD34-F2F6607E8F81";

            /// <summary>
            /// Register for asynchronous sensor data updates. This has power management implications.
            /// </summary>
            public const string DataUpdated = "2ED0F2A4-0087-41D3-87DB-6773370B3C88";

            public const string PropertyChanged = "2358F099-84C9-4D3D-90DF-C2421E2B2045";

            public const string AccelerometerShake = "825F5A94-0F48-4396-9CA0-6ECB5C99D915";

            public const string ParameterCommon = "64346E30-8728-4B34-BDF6-4F52442C5C28";

        }

        public const string ErrorParameterCommon = "77112BCD-FCE1-4f43-B8B8-A88256ADB4B3";

        /// <summary>
        /// Sensor Properties
        /// </summary>
        public static class PropertySystem

        {

            /// <summary>
            /// The common Guid used by the property keys.
            /// </summary>
            public const string PropertyCommon = "7F8383EC-D3EC-495C-A8CF-B8BBE85C2920";

        }

        public static class SensorCategory

        {

            public const string All = "C317C286-C468-4288-9975-D4C4587C442C";

            public const string Location = "BFA794E4-F964-4FDB-90F6-51056BFE4B44";

            public const string Environmental = "323439AA-7F66-492B-BA0C-73E9AA0A65D5";

            public const string Motion = "CD09DAF1-3B2E-4C3D-B598-B5E5FF93FD46";

            public const string Orientation = "9E6C04B6-96FE-4954-B726-68682A473F69";

            public const string Mechanical = "8D131D68-8EF7-4656-80B5-CCCBD93791C5";

            public const string Electrical = "FB73FCD8-FC4A-483C-AC58-27B691C6BEFF";

            public const string Biometric = "CA19690F-A2C7-477D-A99E-99EC6E2B5648";

            public const string Light = "17A665C0-9063-4216-B202-5C7A255E18CE";

            public const string Scanner = "B000E77E-F5B5-420F-815D-0270A726F270";

            public const string Other = "2C90E7A9-F4C9-4FA2-AF37-56D471FE5A3D";

            public const string Unsupported = "2BEAE7FA-19B0-48C5-A1F6-B5480DC206B0";

        }

        public static class SensorType

        {

            public static class Location

            {

                public const string GPS = "ED4CA589-327A-4FF9-A560-91DA4B48275E";

                public const string Static = "095F8184-0FA9-4445-8E6E-B70F320B6B4C";

                public const string Lookup = "3B2EAE4A-72CE-436D-96D2-3C5B8570E987";

                public const string Triangulation = "691C341A-5406-4FE1-942F-2246CBEB39E0";

                public const string Other = "9B2D0566-0368-4F71-B88D-533F132031DE";

                public const string Broadcast = "D26988CF-5162-4039-BB17-4C58B698E44A";

                public const string DeadReckoning = "1A37D538-F28B-42DA-9FCE-A9D0A2A6D829";


            }

            public static class Environmental

            {

                public const string Temperature = "04FD0EC4-D5DA-45FA-95A9-5DB38EE19306";

                public const string AtmosphericPressure = "0E903829-FF8A-4A93-97DF-3DCBDE402288";

                public const string Humidity = "5C72BF67-BD7E-4257-990B-98A3BA3B400A";

                public const string WindSpeed = "DD50607B-A45F-42CD-8EFD-EC61761C4226";

                public const string WindDirection = "9EF57A35-9306-434D-AF09-37FA5A9C00BD";


            }

            public static class Motion

            {

                public const string Accelerometer1D = "C04D2387-7340-4CC2-991E-3B18CB8EF2F4";

                public const string Accelerometer2D = "B2C517A8-F6B5-4BA6-A423-5DF560B4CC07";

                public const string Accelerometer3D = "C2FB0F5F-E2D2-4C78-BCD0-352A9582819D";

                public const string MotionDetector = "5C7C1A12-30A5-43B9-A4B2-CF09EC5B7BE8";

                public const string Gyrometer1D = "FA088734-F552-4584-8324-EDFAF649652C";

                public const string Gyrometer2D = "31EF4F83-919B-48BF-8DE0-5D7A9D240556";

                public const string Gyrometer3D = "09485F5A-759E-42C2-BD4B-A349B75C8643";

                public const string Speedometer = "6BD73C1F-0BB4-4310-81B2-DFC18A52BF94";

            }

            public static class Orientation

            {

                public const string Compass1D = "A415F6C5-CB50-49D0-8E62-A8270BD7A26C";

                public const string Compass2D = "15655CC0-997A-4D30-84DB-57CABA3648BB";

                public const string Compass3D = "76B5CE0D-17DD-414D-93A1-E127F40BDF6E";

                public const string Inclinometer1D = "B96F98C5-7A75-4BA7-94E9-AC868C966DD8";

                public const string Inclinometer2D = "AB140F6D-83EB-4264-B70B-B16A5B256A01";

                public const string Inclinometer3D = "B84919FB-EA85-4976-8444-6F6F5C6D31DB";

                public const string Distance1D = "5F14AB2F-1407-4306-A93F-B1DBABE4F9C0";

                public const string Distance2D = "5CF9A46C-A9A2-4E55-B6A1-A04AAFA95A92";

                public const string Distance3D = "A20CAE31-0E25-4772-9FE5-96608A1354B2";

                public const string AggregatedQuadrantOrientation = "9F81F1AF-C4AB-4307-9904-C828BFB90829";

                public const string AggregatedDeviceOrientation = "CDB5D8F7-3CFD-41C8-8542-CCE622CF5D6E";

                public const string AggregatedSimpleDeviceOrientation = "86A19291-0482-402C-BF4C-ADDAC52B1C39";

            }

            public static class Electrical

            {

                public const string Voltage = "C5484637-4FB7-4953-98B8-A56D8AA1FB1E";

                public const string Current = "5ADC9FCE-15A0-4BBE-A1AD-2D38A9AE831C";

                public const string Capacitance = "CA2FFB1C-2317-49C0-A0B4-B63CE63461A0";

                public const string Resistance = "9993D2C8-C157-4A52-A7B5-195C76037231";

                public const string Inductance = "DC1D933F-C435-4C7D-A2FE-607192A524D3";

                public const string ElectricalPower = "212F10F5-14AB-4376-9A43-A7794098C2FE";

                public const string Potentiometer = "2B3681A9-CADC-45AA-A6FF-54957C8BB440";

                public const string Frequency = "8CD2CBB6-73E6-4640-A709-72AE8FB60D7F";

            }

            public static class Mechanical

            {

                public const string BooleanSwitch = "9C7E371F-1041-460B-8D5C-71E4752E350C";

                public const string MultivalueSwitch = "B3EE4D76-37A4-4402-B25E-99C60A775FA1";

                public const string Force = "C2AB2B02-1A1C-4778-A81B-954A1788CC75";

                public const string Scale = "C06DD92C-7FEB-438E-9BF6-82207FFF5BB8";

                public const string Pressure = "26D31F34-6352-41CF-B793-EA0713D53D77";

                public const string Strain = "C6D1EC0E-6803-4361-AD3D-85BCC58C6D29";

                public const string BooleanSwitchArray = "545C8BA5-B143-4545-868F-CA7FD986B4F6";

            }

            public static class Biometric

            {

                public const string HumanPresence = "C138C12B-AD52-451C-9375-87F518FF10C6";

                public const string HumanProximity = "5220DAE9-3179-4430-9F90-06266D2A34DE";

                public const string Touch = "17DB3018-06C4-4F7D-81AF-9274B7599C27";

            }

            public const string AmbientLight = "97F115C8-599A-4153-8894-D2D12899918A";

            public static class Scanner

            {

                public const string RFIDScanner = "44328EF5-02DD-4E8D-AD5D-9249832B2ECA";

                public const string BarcodeScanner = "990B3D8F-85BB-45FF-914D-998C04F372DF";

            }

            public const string Custom = "E83AF229-8640-4D18-A213-E22675EBB2C3";

            public const string Unknown = "10BA83E3-EF4F-41ED-9885-A87D6435A8E1";

        }

        public static class DataType

        {

            public const string Common = "DB5E0CF2-CF1F-4C18-B46C-D86011D62150";

            public const string Location = "055C74D8-CA6F-47D6-95C6-1ED3637A0FF4";

            public const string Environmental = "8B0AA2F1-2D57-42EE-8CC0-4D27622B46C4";

            public const string Motion = "3F8A69A2-07C5-4E48-A965-CD797AAB56D5";

            public const string Orientation = "1637D8A2-4248-4275-865D-558DE84AEDFD";

            public const string Mechanical = "38564A7C-F2F2-49BB-9B2B-BA60F66A58DF";

            public const string Biometric = "2299288A-6D9E-4B0B-B7EC-3528F89E40AF";

            public const string Light = "E4C77CE2-DCB7-46E9-8439-4FEC548833A6";

            public const string Scanner = "D7A59A3C-3421-44AB-8D3A-9DE8AB6C4CAE";

            public const string Electrical = "BBB246D1-E242-4780-A2D3-CDED84F35842";

            public const string Custom = "B14C764F-07CF-41E8-9D82-EBE3D0776A6F";

        }

    }

}

namespace Microsoft.WindowsAPICodePack.PortableDevices.Guids

{

    /// <summary>
    /// This class defines all WPD Events.
    /// </summary>
    public static class EventSystem

    {

        /// <summary>
        /// This GUID is used to identify all WPD driver events to the event sub-system. The driver uses this as the GUID identifier when it queues an event with IWdfDevice::PostEvent(). Applications never use this value.
        /// </summary>
        public const string Notification = "2BA2E40A-6B4C-4295-BB43-26322B99AEB2";

        /// <summary>
        /// This event is sent after a new object is available on the device.
        /// </summary>
        public const string ObjectAdded = "A726DA95-E207-4B02-8D44-BEF2E86CBFFC";

        /// <summary>
        /// This event is sent after a previously existing object has been removed from the device.
        /// </summary>
        public const string ObjectRemoved = "BE82AB88-A52C-4823-96E5-D0272671FC38";

        /// <summary>
        /// This event is sent after an object has been updated such that any connected client should refresh its view of that object.
        /// </summary>
        public const string ObjectUpdated = "1445A759-2E01-485D-9F27-FF07DAE697AB";

        /// <summary>
        /// This event indicates that the device is about to be reset-and all connected clients should close their connection to the device.
        /// </summary>
        public const string DeviceReset = "7755CF53-C1ED-44F3-B5A2-451E2C376B27";

        /// <summary>
        /// This event indicates that the device capabilities have changed. Clients should re-query the device if they have made any decisions based on device capabilities.
        /// </summary>
        public const string DeviceCapabilitiesUpdated = "36885AA1-CD54-4DAA-B3D0-AFB3E03F5999";

        /// <summary>
        /// This event indicates the progress of a format operation on a storage object.
        /// </summary>
        public const string StorageFormat = "3782616B-22BC-4474-A251-3070F8D38857";

        /// <summary>
        /// This event is sent to request an application to transfer a particular object from the device.
        /// </summary>
        public const string ObjectTransferRequested = "8D16A0A1-F2C6-41DA-8F19-5E53721ADBF2";

        /// <summary>
        /// This event is sent when a driver for a device is being unloaded. This is typically a result of the device being unplugged.
        /// </summary>
        public const string DeviceRemoved = "E4CBCA1B-6918-48B9-85EE-02BE7C850AF9";

        /// <summary>
        /// This event is sent when a driver has completed invoking a service method. This event must be sent even when the method fails.
        /// </summary>
        public const string ServiceMethodComplete = "8A33F5F8-0ACC-4D9B-9CC4-112D353B86CA";

    }

    public static class PropertySystem

    {

        /// <summary>
        /// This section defines all Commands-Parameters and Options associated with: WPD_CLASS_EXTENSION_OPTIONS_V1. This category of properties relates to options used for the WPD device class extension
        /// </summary>
        public const string ClassExtensionOptionsV1 = "6309FFEF-A87C-4CA7-8434-797576E40A96";

        /// <summary>
        /// This section defines all Commands-Parameters and Options associated with: WPD_CLASS_EXTENSION_OPTIONS_V2. This category of properties relates to options used for the WPD device class extension
        /// </summary>
        public const string ClassExtensionOptionsV2 = "3E3595DA-4D71-49FE-A0B4-D4406C3AE93F";

        /// <summary>
        /// This section defines all Commands-Parameters and Options associated with: WPD_CLASS_EXTENSION_OPTIONS_V3. This category of properties relates to options used for the WPD device class extension
        /// </summary>
        public const string ClassExtensionOptionsV3 = "65C160F8-1367-4CE2-939D-8310839F0D30";

        /// <summary>
        /// This section defines all Commands-Parameters and Options associated with: WPD_RESOURCE_ATTRIBUTES_V1
        /// </summary>
        public const string ResourceAttributesV1 = "1EB6F604-9278-429F-93CC-5BB8C06656B6";

        /// <summary>
        /// This section defines all Commands-Parameters and Options associated with: WPD_EVENT_OPTIONS_V1 The properties in this category describe event options.
        /// </summary>
        public const string EventOptionsV1 = "B3D8DAD7-A361-4B83-8A48-5B02CE10713B";

        /// <summary>
        /// This section defines all Commands-Parameters and Options associated with: WPD_EVENT_ATTRIBUTES_V1 The properties in this category describe event attributes.
        /// </summary>
        public const string EventAttributesV1 = "10C96578-2E81-4111-ADDE-E08CA6138F6D";

        /// <summary>
        /// This section defines all Commands-Parameters and Options associated with: WPD_API_OPTIONS_V1 The properties in this category describe API options.
        /// </summary>
        public const string APIOptionsV1 = "10E54A3E-052D-4777-A13C-DE7614BE2BC4";

        /// <summary>
        /// This section defines all Commands-Parameters and Options associated with: WPD_FORMAT_ATTRIBUTES_V1 The properties in this category describe format attributes.
        /// </summary>
        public const string FormatAttributesV1 = "A0A02000-BCAF-4BE8-B3F5-233F231CF58F";

        /// <summary>
        /// This section defines all Commands-Parameters and Options associated with: WPD_METHOD_ATTRIBUTES_V1 The properties in this category describe method attributes.
        /// </summary>
        public const string MethodAttributesV1 = "F17A5071-F039-44AF-8EFE-432CF32E432A";

        /// <summary>
        /// This section defines all Commands-Parameters and Options associated with: WPD_PARAMETER_ATTRIBUTES_V1 The properties in this category describe parameter attributes.
        /// </summary>
        public const string ParameterAttributesV1 = "E6864DD7-F325-45EA-A1D5-97CF73B6CA58";

        /// <summary>
        /// This section defines all Commands-Parameters and Options associated with: WPD_DEVICE_PROPERTIES_V1
        /// </summary>
        public const string DeviceV1 = "26D4979A-E643-4626-9E2B-736DC0C92FDC";

        /// <summary>
        /// This section defines all Commands-Parameters and Options associated with: WPD_DEVICE_PROPERTIES_V2
        /// </summary>
        public const string DeviceV2 = "463DD662-7FC4-4291-911C-7F4C9CCA9799";

        /// <summary>
        /// This section defines all Commands-Parameters and Options associated with: WPD_DEVICE_PROPERTIES_V3
        /// </summary>
        public const string DeviceV3 = "6C2B878C-C2EC-490D-B425-D7A75E23E5ED";

        /// <summary>
        /// This section defines all Commands-Parameters and Options associated with: WPD_SERVICE_PROPERTIES_V1
        /// </summary>
        public const string ServiceV1 = "7510698A-CB54-481C-B8DB-0D75C93F1C06";

        /// <summary>
        /// This section defines all Commands-Parameters and Options associated with: WPD_FOLDER_OBJECT_PROPERTIES_V1. This category is for properties common to all folder objects.
        /// </summary>
        public const string FolderObjectV1 = "7E9A7ABF-E568-4B34-AA2F-13BB12AB177D";

        /// <summary>
        /// This section defines all Commands-Parameters and Options associated with: WPD_IMAGE_OBJECT_PROPERTIES_V1. This category is for properties common to all image objects.
        /// </summary>
        public const string ImageObjectV1 = "63D64908-9FA1-479F-85BA-9952216447DB";

        /// <summary>
        /// This section defines all Commands-Parameters and Options associated with: WPD_DOCUMENT_OBJECT_PROPERTIES_V1. This category is for properties common to all document objects.
        /// </summary>
        public const string DocumentObjectV1 = "0B110203-EB95-4F02-93E0-97C631493AD5";

        /// <summary>
        /// This section defines all Commands-Parameters and Options associated with: WPD_MEDIA_PROPERTIES_V1. This category is for properties common to media objects(e.g.audio and video).
        /// </summary>
        public const string MediaV1 = "2ED8BA05-0AD3-42DC-B0D0-BC95AC396AC8";

        /// <summary>
        /// This section defines all Commands-Parameters and Options associated with: WPD_CONTACT_OBJECT_PROPERTIES_V1. This category is for properties common to all contact objects.
        /// </summary>
        public const string ContactObjectV1 = "FBD4FDAB-987D-4777-B3F9-726185A9312B";

        /// <summary>
        /// This section defines all Commands-Parameters and Options associated with: WPD_MUSIC_OBJECT_PROPERTIES_V1. This category is for properties common to all music objects.
        /// </summary>
        public const string MusicObjectV1 = "B324F56A-DC5D-46E5-B6DF-D2EA414888C6";

        /// <summary>
        /// This section defines all Commands-Parameters and Options associated with: WPD_VIDEO_OBJECT_PROPERTIES_V1. This category is for properties common to all video objects.
        /// </summary>
        public const string VideoObjectV1 = "346F2163-F998-4146-8B01-D19B4C00DE9A";

        /// <summary>
        /// This section defines all Commands-Parameters and Options associated with: WPD_COMMON_INFORMATION_OBJECT_PROPERTIES_V1. This category is properties that pertain to informational objects such as appointments-tasks-memos and even documents.
        /// </summary>
        public const string CommonInformationObjectV1 = "B28AE94B-05A4-4E8E-BE01-72CC7E099D8F";

        /// <summary>
        /// This section defines all Commands-Parameters and Options associated with: WPD_MEMO_OBJECT_PROPERTIES_V1. This category is for properties common to all memo objects.
        /// </summary>
        public const string MemoObjectV1 = "5FFBFC7B-7483-41AD-AFB9-DA3F4E592B8D";

        /// <summary>
        /// This section defines all Commands-Parameters and Options associated with: WPD_EMAIL_OBJECT_PROPERTIES_V1. This category is for properties common to all email objects.
        /// </summary>
        public const string EmailObjectV1 = "41F8F65A-5484-4782-B13D-4740DD7C37C5";

        /// <summary>
        /// This section defines all Commands-Parameters and Options associated with: WPD_APPOINTMENT_OBJECT_PROPERTIES_V1. This category is for properties common to all appointment objects.
        /// </summary>
        public const string AppointmentObjectV1 = "F99EFD03-431D-40D8-A1C9-4E220D9C88D3";

        /// <summary>
        /// This section defines all Commands-Parameters and Options associated with: WPD_TASK_OBJECT_PROPERTIES_V1. This category is for properties common to all task objects.
        /// </summary>
        public const string TaskObjectV1 = "E354E95E-D8A0-4637-A03A-0CB26838DBC7";

        /// <summary>
        /// This section defines all Commands-Parameters and Options associated with: WPD_SMS_OBJECT_PROPERTIES_V1. This category is for properties common to all objects whose functional category is WPD_FUNCTIONAL_CATEGORY_SMS
        /// </summary>
        public const string SMSObjectV1 = "7E1074CC-50FF-4DD1-A742-53BE6F093A0D";

        /// <summary>
        /// This section defines all Commands-Parameters and Options associated with: WPD_SECTION_OBJECT_PROPERTIES_V1. This category is for properties common to all objects whose content type is WPD_CONTENT_TYPE_SECTION
        /// </summary>
        public const string SectionObjectV1 = "516AFD2B-C64E-44F0-98DC-BEE1C88F7D66";

        /// <summary>
        /// This section defines all Commands-Parameters and Options associated with: WPD_FUNCTIONAL_OBJECT_PROPERTIES_V1. This category is for properties common to all functional objects.
        /// </summary>
        public const string FunctionalObjectV1 = "8F052D93-ABCA-4FC5-A5AC-B01DF4DBE598";

        /// <summary>
        /// This section defines all Commands-Parameters and Options associated with: WPD_STORAGE_OBJECT_PROPERTIES_V1. This category is for properties common to all objects whose functional category is WPD_FUNCTIONAL_CATEGORY_STORAGE.
        /// </summary>
        public const string StorageObjectV1 = "01A3057A-74D6-4E80-BEA7-DC4C212CE50A";

        /// <summary>
        /// This section defines all Commands-Parameters and Options associated with: WPD_NETWORK_ASSOCIATION_PROPERTIES_V1. This category is for properties common to all network association objects.
        /// </summary>
        public const string NetworkAssociationV1 = "E4C93C1F-B203-43F1-A100-5A07D11B0274";

        /// <summary>
        /// This section defines all Commands-Parameters and Options associated with: WPD_STILL_IMAGE_CAPTURE_OBJECT_PROPERTIES_V1. This category is for properties common to all objects whose functional category is WPD_FUNCTIONAL_CATEGORY_STILL_IMAGE_CAPTURE
        /// </summary>
        public const string StillImageCaptureObjectV1 = "58C571EC-1BCB-42A7-8AC5-BB291573A260";

        /// <summary>
        /// This section defines all Commands-Parameters and Options associated with: WPD_RENDERING_INFORMATION_OBJECT_PROPERTIES_V1. This category is for properties common to all objects whose functional category is WPD_FUNCTIONAL_CATEGORY_AUDIO_RENDERING_INFORMATION
        /// </summary>
        public const string RenderingInformationObjectV1 = "C53D039F-EE23-4A31-8590-7639879870B4";

        /// <summary>
        /// This section defines all Commands-Parameters and Options associated with: WPD_CLIENT_INFORMATION_PROPERTIES_V1.
        /// </summary>
        public const string ClientInformationV1 = "204D9F0C-2292-4080-9F42-40664E70F859";

        /// <summary>
        /// This class defines all WPD content types.
        /// </summary>
        public static class ContentType

        {

            /// <summary>
            /// <para>Name: WPD_CONTENT_TYPE_FUNCTIONAL_OBJECT</para>
            /// <para>Description: Indicates this object represents a functional object-not content data on the device.</para>
            /// </summary>
            public const string FunctionalObject = "99ED0160-17FF-4C44-9D98-1D7A6F941921";

            /// <summary>
            /// <para>Name: WPD_CONTENT_TYPE_FOLDER</para>
            /// <para>Description: Indicates this object is a folder.</para>
            /// </summary>
            public const string Folder = "27E2E392-A111-48E0-AB0C-E17705A05F85";

            /// <summary>
            /// <para>Name: WPD_CONTENT_TYPE_IMAGE</para>
            /// <para>Description: Indicates this object represents image data (e.g. a JPEG file)</para>
            /// </summary>
            public const string Image = "ef2107d5-a52a-4243-a26b-62d4176d7603";

            /// <summary>
            /// <para>Name: WPD_CONTENT_TYPE_DOCUMENT</para>
            /// <para>Description: Indicates this object represents document data (e.g. a MS WORD file-TEXT file-etc.)</para>
            /// </summary>
            public const string Document = "680ADF52-950A-4041-9B41-65E393648155";

            /// <summary>
            /// <para>Name: WPD_CONTENT_TYPE_CONTACT</para>
            /// <para>Description: Indicates this object represents contact data (e.g. name/number-or a VCARD file)</para>
            /// </summary>
            public const string Contact = "EABA8313-4525-4707-9F0E-87C6808E9435";

            /// <summary>
            /// <para>Name: WPD_CONTENT_TYPE_CONTACT_GROUP</para>
            /// <para>Description: Indicates this object represents a group of contacts.</para>
            /// </summary>
            public const string ContactGroup = "346B8932-4C36-40D8-9415-1828291F9DE9";

            /// <summary>
            /// <para>Name: WPD_CONTENT_TYPE_AUDIO</para>
            /// <para>Description: Indicates this object represents audio data (e.g. a WMA or MP3 file)</para>
            /// </summary>
            public const string Audio = "4AD2C85E-5E2D-45E5-8864-4F229E3C6CF0";

            /// <summary>
            /// <para>Name: WPD_CONTENT_TYPE_VIDEO</para>
            /// <para>Description: Indicates this object represents video data (e.g. a WMV or AVI file)</para>
            /// </summary>
            public const string Video = "9261B03C-3D78-4519-85E3-02C5E1F50BB9";

            /// <summary>
            /// <para>Name: WPD_CONTENT_TYPE_TELEVISION</para>
            /// <para>Description: Indicates this object represents a television recording.</para>
            /// </summary>
            public const string Television = "60A169CF-F2AE-4E21-9375-9677F11C1C6E";

            /// <summary>
            /// <para>Name: WPD_CONTENT_TYPE_PLAYLIST</para>
            /// <para>Description: Indicates this object represents a playlist.</para>
            /// </summary>
            public const string Playlist = "1A33F7E4-AF13-48F5-994E-77369DFE04A3";

            /// <summary>
            /// <para>Name: WPD_CONTENT_TYPE_MIXED_CONTENT_ALBUM</para>
            /// <para>Description: Indicates this object represents an album-which may contain objects of different content types (typically-MUSIC-IMAGE and VIDEO).</para>
            /// </summary>
            public const string MixedContentAlbum = "00F0C3AC-A593-49AC-9219-24ABCA5A2563";

            /// <summary>
            /// <para>Name: WPD_CONTENT_TYPE_AUDIO_ALBUM</para>
            /// <para>Description: Indicates this object represents an audio album.</para>
            /// </summary>
            public const string AudioAlbum = "AA18737E-5009-48FA-AE21-85F24383B4E6";

            /// <summary>
            /// <para>Name: WPD_CONTENT_TYPE_IMAGE_ALBUM</para>
            /// <para>Description: Indicates this object represents an image album.</para>
            /// </summary>
            public const string ImageAlbum = "75793148-15F5-4A30-A813-54ED8A37E226";

            /// <summary>
            /// <para>Name: WPD_CONTENT_TYPE_VIDEO_ALBUM</para>
            /// <para>Description: Indicates this object represents a video album.</para>
            /// </summary>
            public const string VideoAlbum = "012B0DB7-D4C1-45D6-B081-94B87779614F";

            /// <summary>
            /// <para>Name: WPD_CONTENT_TYPE_MEMO</para>
            /// <para>Description: Indicates this object represents memo data</para>
            /// </summary>
            public const string Memo = "9CD20ECF-3B50-414F-A641-E473FFE45751";

            /// <summary>
            /// <para>Name: WPD_CONTENT_TYPE_EMAIL</para>
            /// <para>Description: Indicates this object represents e-mail data</para>
            /// </summary>
            public const string Email = "8038044A-7E51-4F8F-883D-1D0623D14533";

            /// <summary>
            /// <para>Name: WPD_CONTENT_TYPE_APPOINTMENT</para>
            /// <para>Description: Indicates this object represents an appointment in a calendar</para>
            /// </summary>
            public const string Appointment = "0FED060E-8793-4B1E-90C9-48AC389AC631";

            /// <summary>
            /// <para>Name: WPD_CONTENT_TYPE_TASK</para>
            /// <para>Description: Indicates this object represents a task for tracking (e.g. a TODO list)</para>
            /// </summary>
            public const string Task = "63252F2C-887F-4CB6-B1AC-D29855DCEF6C";

            /// <summary>
            /// <para>Name: WPD_CONTENT_TYPE_PROGRAM</para>
            /// <para>Description: Indicates this object represents a file that can be run. This could be a script-executable and so on.</para>
            /// </summary>
            public const string Program = "D269F96A-247C-4BFF-98FB-97F3C49220E6";

            /// <summary>
            /// <para>Name: WPD_CONTENT_TYPE_GENERIC_FILE</para>
            /// <para>Description: Indicates this object represents a file that does not fall into any of the other predefined WPD types for files.</para>
            /// </summary>
            public const string GenericFile = "0085E0A6-8D34-45D7-BC5C-447E59C73D48";

            /// <summary>
            /// <para>Name: WPD_CONTENT_TYPE_CALENDAR</para>
            /// <para>Description: Indicates this object represents a calendar</para>
            /// </summary>
            public const string Calendar = "A1FD5967-6023-49A0-9DF1-F8060BE751B0";

            /// <summary>
            /// <para>Name: WPD_CONTENT_TYPE_GENERIC_MESSAGE</para>
            /// <para>Description: Indicates this object represents a message (e.g. SMS message-E-Mail message-etc.)</para>
            /// </summary>
            public const string GenericMessage = "E80EAAF8-B2DB-4133-B67E-1BEF4B4A6E5F";

            /// <summary>
            /// <para>Name: WPD_CONTENT_TYPE_NETWORK_ASSOCIATION</para>
            /// <para>Description: Indicates this object represents an association between a host and a device.</para>
            /// </summary>
            public const string NetworkAssociation = "031DA7EE-18C8-4205-847E-89A11261D0F3";

            /// <summary>
            /// <para>Name: WPD_CONTENT_TYPE_CERTIFICATE</para>
            /// <para>Description: Indicates this object represents certificate used for authentication.</para>
            /// </summary>
            public const string Certificate = "DC3876E8-A948-4060-9050-CBD77E8A3D87";

            /// <summary>
            /// <para>Name: WPD_CONTENT_TYPE_WIRELESS_PROFILE</para>
            /// <para>Description: Indicates this object represents wireless network access information.</para>
            /// </summary>
            public const string WirelessProfile = "0BAC070A-9F5F-4DA4-A8F6-3DE44D68FD6C";

            /// <summary>
            /// <para>Name: WPD_CONTENT_TYPE_MEDIA_CAST</para>
            /// <para>Description: Indicates this object represents a media cast. A media cast object can be though of as a container object that groups related content-similar to how a playlist groups songs to play. Often-a media cast object is used to group media content originally published online.</para>
            /// </summary>
            public const string MediaCast = "5E88B3CC-3E65-4E62-BFFF-229495253AB0";

            /// <summary>
            /// <para>Name: WPD_CONTENT_TYPE_SECTION</para>
            /// <para>Description: Indicates this object describes a section of data contained in another object. The WPD_OBJECT_REFERENCES property indicates which object contains the actual data.</para>
            /// </summary>
            public const string Section = "821089F5-1D91-4DC9-BE3C-BBB1B35B18CE";

            /// <summary>
            /// <para>Name: WPD_CONTENT_TYPE_UNSPECIFIED</para>
            /// <para>Description: Indicates this object doesn't fall into the predefined WPD content types</para>
            /// </summary>
            public const string Unspecified = "28D8D31E-249C-454E-AABC-34883168E634";

            /// <summary>
            /// <para>Name: WPD_CONTENT_TYPE_ALL</para>
            /// <para>Description: This content type is only valid as a parameter to API functions and driver commands. It should not be reported as a supported content type by the driver.</para>
            /// </summary>
            public const string All = "80E170D2-1055-4A3E-B952-82CC4F8A8689";

            /// <summary>
            /// This class defines all WPD Functional Categories
            /// </summary>
            public static class FunctionalCategory

            {

                //
                // WPD_FUNCTIONAL_CATEGORY_DEVICE
                // Used for the device object-which is always the top-most object of the device. 
                public const string Device = "08EA466B-E3A4-4336-A1F3-A44D2B5C438C";
                //
                // WPD_FUNCTIONAL_CATEGORY_STORAGE
                // Indicates this object encapsulates storage functionality on the device (e.g. memory cards-internal memory) 
                public const string Storage = "23F05BBC-15DE-4C2A-A55B-A9AF5CE412EF";
                //
                // WPD_FUNCTIONAL_CATEGORY_STILL_IMAGE_CAPTURE
                // Indicates this object encapsulates still image capture functionality on the device (e.g. camera or camera attachment) 
                public const string StillImageCapture = "613CA327-AB93-4900-B4FA-895BB5874B79";
                //
                // WPD_FUNCTIONAL_CATEGORY_AUDIO_CAPTURE
                // Indicates this object encapsulates audio capture functionality on the device (e.g. voice recorder or other audio recording component) 
                public const string AudioCapture = "3F2A1919-C7C2-4A00-855D-F57CF06DEBBB";
                //
                // WPD_FUNCTIONAL_CATEGORY_VIDEO_CAPTURE
                // Indicates this object encapsulates video capture functionality on the device (e.g. video recorder or video recording component) 
                public const string VideoCapture = "E23E5F6B-7243-43AA-8DF1-0EB3D968A918";
                //
                // WPD_FUNCTIONAL_CATEGORY_SMS
                // Indicates this object encapsulates SMS sending functionality on the device (not the receiving or saved SMS messages since those are represented as content objects on the device) 
                public const string SMS = "0044A0B1-C1E9-4AFD-B358-A62C6117C9CF";
                //
                // WPD_FUNCTIONAL_CATEGORY_RENDERING_INFORMATION
                // Indicates this object provides information about the rendering characteristics of the device. 
                public const string RenderingInformation = "08600BA4-A7BA-4A01-AB0E-0065D0A356D3";
                //
                // WPD_FUNCTIONAL_CATEGORY_NETWORK_CONFIGURATION
                // Indicates this object encapsulates network configuration functionality on the device (e.g. WiFi Profiles-Partnerships). 
                public const string NetworkConfiguration = "48F4DB72-7C6A-4AB0-9E1A-470E3CDBF26A";
                //
                // WPD_FUNCTIONAL_CATEGORY_ALL
                // This functional category is only valid as a parameter to API functions and driver commands. It should not be reported as a supported functional category by the driver. 
                public const string All = "2D8A6512-A74C-448E-BA8A-F4AC07C49399";

            }

        }

        /// <summary>
        /// This class defines all WPD Formats
        /// </summary>
        public static class ObjectFormat

        {
            //
            // WPD_OBJECT_FORMAT_ICON
            //   Standard Windows ICON format 
            public const string Icon = "077232ED-102C-4638-9C22-83F142BFC822";
            //
            // WPD_OBJECT_FORMAT_M4A
            //   Audio file format 
            public const string M4A = "30ABA7AC-6FFD-4C23-A359-3E9B52F3F1C8";
            //
            // WPD_OBJECT_FORMAT_NETWORK_ASSOCIATION
            //   Network Association file format. 
            public const string NetworkAssociation = "B1020000-AE6C-4804-98BA-C57B46965FE7";
            //
            // WPD_OBJECT_FORMAT_X509V3CERTIFICATE
            //   X.509 V3 Certificate file format. 
            public const string X509v3Certificate = "B1030000-AE6C-4804-98BA-C57B46965FE7";
            //
            // WPD_OBJECT_FORMAT_MICROSOFT_WFC
            //   Windows Connect Now file format. 
            public const string MicrosoftWFC = "B1040000-AE6C-4804-98BA-C57B46965FE7";
            //
            // WPD_OBJECT_FORMAT_3GPA
            //   Audio file format 
            public const string ThreeGPA = "E5172730-F971-41EF-A10B-2271A0019D7A";
            //
            // WPD_OBJECT_FORMAT_3G2A
            //   Audio file format 
            public const string ThreeG2A = "1A11202D-8759-4E34-BA5E-B1211087EEE4";
            //
            // WPD_OBJECT_FORMAT_ALL
            //   This format is only valid as a parameter to API functions and driver commands. It should not be reported as a supported format by the driver. 
            public const string All = "C1F62EB2-4BB3-479C-9CFA-05B5F3A57B22";

        }

        /// <summary>
        /// This section defines all Commands-Parameters and Options associated with: WPD_OBJECT_PROPERTIES_V1. This category is for all common object properties.
        /// </summary>
        public const string ObjectV1 = "EF6B490D-5CD8-437A-AFFC-DA8B60EE4A3C";

        /// <summary>
        /// This section defines all Commands-Parameters and Options associated with: WPD_OBJECT_PROPERTIES_V2. This category is for all common object properties.
        /// </summary>
        public const string ObjectV2 = "0373CD3D-4A46-40D7-B4D8-73E8DA74E775";

        /// <summary>
        /// This section defines all Commands-Parameters and Options associated with: WPD_PROPERTY_ATTRIBUTES_V1
        /// </summary>
        public const string PropertyAttributesV1 = "AB7943D8-6332-445F-A00D-8D5EF1E96F37";

        /// <summary>
        /// This section defines all Commands-Parameters and Options associated with: WPD_PROPERTY_ATTRIBUTES_V2. This category defines additional property attributes used by device services.
        /// </summary>
        public const string PropertyAttributesV2 = "5D9DA160-74AE-43CC-85A9-FE555A80798E";

        /// <summary>
        /// This section defines all Commands-Parameters and Options associated with: WPD_EVENT_PROPERTIES_V1 The properties in this category are for properties that may be needed for event processing-but do not have object property equivalents(i.e.they are not exposed as object properties-but rather-used only as event parameters).
        /// </summary>
        public const string EventV1 = "15AB1953-F817-4FEF-A921-5676E838F6E0";

        /// <summary>
        /// This section defines all Commands-Parameters and Options associated with: WPD_EVENT_PROPERTIES_V2 The properties in this category are for properties that may be needed for event processing-but do not have object property equivalents(i.e.they are not exposed as object properties-but rather-used only as event parameters).
        /// </summary>
        public const string EventV2 = "52807B8A-4914-4323-9B9A-74F654B2B846";

        #region This section defines the legacy WPD definitions. When WPD_SERVICES_STRICT mode is defined-these definitions are removed from this header file. You may find replacements or equivalents in the Device Services headers (for example-BridgeDeviceService.h).
        // # ifndef WPD_SERVICES_STRICT

        public static class Legacy

        {

            #endregion
            /// <summary>
            /// This class defines the legacy WPD Formats
            /// </summary>
            public static class ObjectFormat

            {

                //
                // WPD_OBJECT_FORMAT_PROPERTIES_ONLY
                //   This object has no data stream and is completely specified by properties only.
                //   Device Services Format: FORMAT_Association
                public const string PropertiesOnly = "30010000-AE6C-4804-98BA-C57B46965FE7";
                //
                // WPD_OBJECT_FORMAT_UNSPECIFIED
                //   An undefined object format on the device (e.g. objects that can not be classified by the other defined WPD format codes)
                //   Device Services Format: FORMAT_Undefined
                public const string Unspecified = "30000000-AE6C-4804-98BA-C57B46965FE7";
                //
                // WPD_OBJECT_FORMAT_SCRIPT
                //   A device model-specific script
                //   Device Services Format: FORMAT_DeviceScript
                public const string Script = "30020000-AE6C-4804-98BA-C57B46965FE7";
                //
                // WPD_OBJECT_FORMAT_EXECUTABLE
                //   A device model-specific binary executable
                //   Device Services Format: FORMAT_DeviceExecutable
                public const string Executable = "30030000-AE6C-4804-98BA-C57B46965FE7";
                //
                // WPD_OBJECT_FORMAT_TEXT
                //   A text file
                //   Device Services Format: FORMAT_TextDocument
                public const string Text = "30040000-AE6C-4804-98BA-C57B46965FE7";
                //
                // WPD_OBJECT_FORMAT_HTML
                //   A HyperText Markup Language file (text)
                //   Device Services Format: FORMAT_HTMLDocument
                public const string HTML = "30050000-AE6C-4804-98BA-C57B46965FE7";
                //
                // WPD_OBJECT_FORMAT_DPOF
                //   A Digital Print Order File (text)
                //   Device Services Format: FORMAT_DPOFDocument
                public const string DPOF = "30060000-AE6C-4804-98BA-C57B46965FE7";
                //
                // WPD_OBJECT_FORMAT_AIFF
                //   Audio file format
                //   Device Services Format: FORMAT_AIFFFile
                public const string AIFF = "30070000-AE6C-4804-98BA-C57B46965FE7";
                //
                // WPD_OBJECT_FORMAT_WAVE
                //   Audio file format
                //   Device Services Format: FORMAT_WAVFile
                public const string WAV = "30080000-AE6C-4804-98BA-C57B46965FE7";
                //
                // WPD_OBJECT_FORMAT_MP3
                //   Audio file format
                //   Device Services Format: FORMAT_MP3File
                public const string MP3 = "30090000-AE6C-4804-98BA-C57B46965FE7";
                //
                // WPD_OBJECT_FORMAT_AVI
                //   Video file format
                //   Device Services Format: FORMAT_AVIFile
                public const string AVI = "300A0000-AE6C-4804-98BA-C57B46965FE7";
                //
                // WPD_OBJECT_FORMAT_MPEG
                //   Video file format
                //   Device Services Format: FORMAT_MPEGFile
                public const string MPEG = "300B0000-AE6C-4804-98BA-C57B46965FE7";
                //
                // WPD_OBJECT_FORMAT_ASF
                //   Video file format (Microsoft Advanced Streaming Format)
                //   Device Services Format: FORMAT_ASFFile
                public const string ASF = "300C0000-AE6C-4804-98BA-C57B46965FE7";
                //
                // WPD_OBJECT_FORMAT_EXIF
                //   Image file format (Exchangeable File Format)-JEIDA standard
                //   Device Services Format: FORMAT_EXIFImage
                public const string EXIF = "38010000-AE6C-4804-98BA-C57B46965FE7";
                //
                // WPD_OBJECT_FORMAT_TIFFEP
                //   Image file format (Tag Image File Format for Electronic Photography)
                //   Device Services Format: FORMAT_TIFFEPImage
                public const string TIFFEP = "38020000-AE6C-4804-98BA-C57B46965FE7";
                //
                // WPD_OBJECT_FORMAT_FLASHPIX
                //   Image file format (Structured Storage Image Format)
                //   Device Services Format: FORMAT_FlashPixImage
                public const string FlashPIX = "38030000-AE6C-4804-98BA-C57B46965FE7";
                //
                // WPD_OBJECT_FORMAT_BMP
                //   Image file format (Microsoft Windows Bitmap file)
                //   Device Services Format: FORMAT_BMPImage
                public const string BMP = "38040000-AE6C-4804-98BA-C57B46965FE7";
                //
                // WPD_OBJECT_FORMAT_CIFF
                //   Image file format (Canon Camera Image File Format)
                //   Device Services Format: FORMAT_CIFFImage
                public const string CIFF = "38050000-AE6C-4804-98BA-C57B46965FE7";
                //
                // WPD_OBJECT_FORMAT_GIF
                //   Image file format (Graphics Interchange Format)
                //   Device Services Format: FORMAT_GIFImage
                public const string GIF = "38070000-AE6C-4804-98BA-C57B46965FE7";
                //
                // WPD_OBJECT_FORMAT_JFIF
                //   Image file format (JPEG Interchange Format)
                //   Device Services Format: FORMAT_JFIFImage
                public const string JFIF = "38080000-AE6C-4804-98BA-C57B46965FE7";
                //
                // WPD_OBJECT_FORMAT_PCD
                //   Image file format (PhotoCD Image Pac)
                //   Device Services Format: FORMAT_PCDImage
                public const string PCD = "38090000-AE6C-4804-98BA-C57B46965FE7";
                //
                // WPD_OBJECT_FORMAT_PICT
                //   Image file format (Quickdraw Image Format)
                //   Device Services Format: FORMAT_PICTImage
                public const string PICT = "380A0000-AE6C-4804-98BA-C57B46965FE7";
                //
                // WPD_OBJECT_FORMAT_PNG
                //   Image file format (Portable Network Graphics)
                //   Device Services Format: FORMAT_PNGImage
                public const string PNG = "380B0000-AE6C-4804-98BA-C57B46965FE7";
                //
                // WPD_OBJECT_FORMAT_TIFF
                //   Image file format (Tag Image File Format)
                //   Device Services Format: FORMAT_TIFFImage
                public const string TIFF = "380D0000-AE6C-4804-98BA-C57B46965FE7";
                //
                // WPD_OBJECT_FORMAT_TIFFIT
                //   Image file format (Tag Image File Format for Informational Technology) Graphic Arts
                //   Device Services Format: FORMAT_TIFFITImage
                public const string TIFFIT = "380E0000-AE6C-4804-98BA-C57B46965FE7";
                //
                // WPD_OBJECT_FORMAT_JP2
                //   Image file format (JPEG2000 Baseline File Format)
                //   Device Services Format: FORMAT_JP2Image
                public const string JP2 = "380F0000-AE6C-4804-98BA-C57B46965FE7";
                //
                // WPD_OBJECT_FORMAT_JPX
                //   Image file format (JPEG2000 Extended File Format)
                //   Device Services Format: FORMAT_JPXImage
                public const string JPX = "38100000-AE6C-4804-98BA-C57B46965FE7";
                //
                // WPD_OBJECT_FORMAT_WBMP
                //   Image file format (Wireless Application Protocol Bitmap Format)
                //   Device Services Format: FORMAT_WBMPImage
                public const string WBMP = "B8030000-AE6C-4804-98BA-C57B46965FE7";
                //
                // WPD_OBJECT_FORMAT_JPEGXR
                //   Image file format (JPEG XR-also known as HD Photo)
                //   Device Services Format: FORMAT_JPEGXRImage
                public const string JPEGXR = "B8040000-AE6C-4804-98BA-C57B46965FE7";
                //
                // WPD_OBJECT_FORMAT_WINDOWSIMAGEFORMAT
                //   Image file format
                //   Device Services Format: FORMAT_HDPhotoImage
                public const string WindowsImageFormat = "B8810000-AE6C-4804-98BA-C57B46965FE7";
                //
                // WPD_OBJECT_FORMAT_WMA
                //   Audio file format (Windows Media Audio)
                //   Device Services Format: FORMAT_WMAFile
                public const string WMA = "B9010000-AE6C-4804-98BA-C57B46965FE7";
                //
                // WPD_OBJECT_FORMAT_WMV
                //   Video file format (Windows Media Video)
                //   Device Services Format: FORMAT_WMVFile
                public const string WMV = "B9810000-AE6C-4804-98BA-C57B46965FE7";
                //
                // WPD_OBJECT_FORMAT_WPLPLAYLIST
                //   Playlist file format
                //   Device Services Format: FORMAT_WPLPlaylist
                public const string WPLPlaylist = "BA100000-AE6C-4804-98BA-C57B46965FE7";
                //
                // WPD_OBJECT_FORMAT_M3UPLAYLIST
                //   Playlist file format
                //   Device Services Format: FORMAT_M3UPlaylist
                public const string M3UPlaylist = "BA110000-AE6C-4804-98BA-C57B46965FE7";
                //
                // WPD_OBJECT_FORMAT_MPLPLAYLIST
                //   Playlist file format
                //   Device Services Format: FORMAT_MPLPlaylist
                public const string MPLPlaylist = "BA120000-AE6C-4804-98BA-C57B46965FE7";
                //
                // WPD_OBJECT_FORMAT_ASXPLAYLIST
                //   Playlist file format
                //   Device Services Format: FORMAT_ASXPlaylist
                public const string ASXPlaylist = "BA130000-AE6C-4804-98BA-C57B46965FE7";
                //
                // WPD_OBJECT_FORMAT_PLSPLAYLIST
                //   Playlist file format
                //   Device Services Format: FORMAT_PSLPlaylist
                public const string PLSPlaylist = "BA140000-AE6C-4804-98BA-C57B46965FE7";
                //
                // WPD_OBJECT_FORMAT_ABSTRACT_CONTACT_GROUP
                //   Generic format for contact group objects
                //   Device Services Format: FORMAT_AbstractContactGroup
                public const string AbstractContactGroup = "BA060000-AE6C-4804-98BA-C57B46965FE7";
                //
                // WPD_OBJECT_FORMAT_ABSTRACT_MEDIA_CAST
                //   MediaCast file format
                //   Device Services Format: FORMAT_AbstractMediacast
                public const string AbstractMediaCast = "BA0B0000-AE6C-4804-98BA-C57B46965FE7";
                //
                // WPD_OBJECT_FORMAT_VCALENDAR1
                //   VCALENDAR file format (VCALENDAR Version 1)
                //   Device Services Format: FORMAT_VCalendar1
                public const string VCalendar1 = "BE020000-AE6C-4804-98BA-C57B46965FE7";
                //
                // WPD_OBJECT_FORMAT_ICALENDAR
                //   ICALENDAR file format (VCALENDAR Version 2)
                //   Device Services Format: FORMAT_ICalendar
                public const string ICalendar = "BE030000-AE6C-4804-98BA-C57B46965FE7";
                //
                // WPD_OBJECT_FORMAT_ABSTRACT_CONTACT
                //   Abstract contact file format
                //   Device Services Format: FORMAT_AbstractContact
                public const string AbstractContact = "BB810000-AE6C-4804-98BA-C57B46965FE7";
                //
                // WPD_OBJECT_FORMAT_VCARD2
                //   VCARD file format (VCARD Version 2)
                //   Device Services Format: FORMAT_VCard2Contact
                public const string VCard2 = "BB820000-AE6C-4804-98BA-C57B46965FE7";
                //
                // WPD_OBJECT_FORMAT_VCARD3
                //   VCARD file format (VCARD Version 3)
                //   Device Services Format: FORMAT_VCard3Contact
                public const string VCard3 = "BB830000-AE6C-4804-98BA-C57B46965FE7";
                //
                // WPD_OBJECT_FORMAT_XML
                //   XML file format.
                //   Device Services Format: FORMAT_XMLDocument
                public const string XML = "BA820000-AE6C-4804-98BA-C57B46965FE7";
                //
                // WPD_OBJECT_FORMAT_AAC
                //   Audio file format
                //   Device Services Format: FORMAT_AACFile
                public const string AAC = "B9030000-AE6C-4804-98BA-C57B46965FE7";
                //
                // WPD_OBJECT_FORMAT_AUDIBLE
                //   Audio file format
                //   Device Services Format: FORMAT_AudibleFile
                public const string Audible = "B9040000-AE6C-4804-98BA-C57B46965FE7";
                //
                // WPD_OBJECT_FORMAT_FLAC
                //   Audio file format
                //   Device Services Format: FORMAT_FLACFile
                public const string FLAC = "B9060000-AE6C-4804-98BA-C57B46965FE7";
                //
                // WPD_OBJECT_FORMAT_QCELP
                //   Audio file format (Qualcomm Code Excited Linear Prediction)
                //   Device Services Format: FORMAT_QCELPFile
                public const string QCELP = "B9070000-AE6C-4804-98BA-C57B46965FE7";
                //
                // WPD_OBJECT_FORMAT_AMR
                //   Audio file format (Adaptive Multi-Rate audio codec)
                //   Device Services Format: FORMAT_AMRFile
                public const string AMR = "B9080000-AE6C-4804-98BA-C57B46965FE7";
                //
                // WPD_OBJECT_FORMAT_OGG
                //   Audio file format
                //   Device Services Format: FORMAT_OGGFile
                public const string OGG = "B9020000-AE6C-4804-98BA-C57B46965FE7";
                //
                // WPD_OBJECT_FORMAT_MP4
                //   Audio or Video file format
                //   Device Services Format: FORMAT_MPEG4File
                public const string MP4 = "B9820000-AE6C-4804-98BA-C57B46965FE7";
                //
                // WPD_OBJECT_FORMAT_MP2
                //   Audio or Video file format
                //   Device Services Format: FORMAT_MPEG2File
                public const string MP2 = "B9830000-AE6C-4804-98BA-C57B46965FE7";
                //
                // WPD_OBJECT_FORMAT_MICROSOFT_WORD
                //   Microsoft Office Word Document file format.
                //   Device Services Format: FORMAT_WordDocument
                public const string MicrosoftWord = "BA830000-AE6C-4804-98BA-C57B46965FE7";
                //
                // WPD_OBJECT_FORMAT_MHT_COMPILED_HTML
                //   MHT Compiled HTML Document file format.
                //   Device Services Format: FORMAT_MHTDocument
                public const string MHTCompiledHTML = "BA840000-AE6C-4804-98BA-C57B46965FE7";
                //
                // WPD_OBJECT_FORMAT_MICROSOFT_EXCEL
                //   Microsoft Office Excel Document file format.
                //   Device Services Format: FORMAT_ExcelDocument
                public const string MicrosoftExcel = "BA850000-AE6C-4804-98BA-C57B46965FE7";
                //
                // WPD_OBJECT_FORMAT_MICROSOFT_POWERPOINT
                //   Microsoft Office PowerPoint Document file format.
                //   Device Services Format: FORMAT_PowerPointDocument
                public const string MicrosoftPowerPoint = "BA860000-AE6C-4804-98BA-C57B46965FE7";
                //
                // WPD_OBJECT_FORMAT_3GP
                //   Audio or Video file format
                //   Device Services Format: FORMAT_3GPPFile
                public const string ThreeGP = "B9840000-AE6C-4804-98BA-C57B46965FE7";
                //
                // WPD_OBJECT_FORMAT_3G2
                //   Audio or Video file format
                //   Device Services Format: FORMAT_3GPP2File
                public const string ThreeG2 = "B9850000-AE6C-4804-98BA-C57B46965FE7";
                //
                // WPD_OBJECT_FORMAT_AVCHD
                //   Audio or Video file format
                //   Device Services Format: FORMAT_AVCHDFile
                public const string AVCHD = "B9860000-AE6C-4804-98BA-C57B46965FE7";
                //
                // WPD_OBJECT_FORMAT_ATSCTS
                //   Audio or Video file format
                //   Device Services Format: FORMAT_ATSCTSFile
                public const string ATSCTS = "B9870000-AE6C-4804-98BA-C57B46965FE7";
                //
                // WPD_OBJECT_FORMAT_DVBTS
                //   Audio or Video file format
                //   Device Services Format: FORMAT_DVBTSFile
                public const string DVBTS = "B9880000-AE6C-4804-98BA-C57B46965FE7";
                //
                // WPD_OBJECT_FORMAT_MKV
                //   Audio or Video file format
                //   Device Services Format: FORMAT_MKVFile
                public const string MKV = "B9900000-AE6C-4804-98BA-c57B46965FE7";

            }

            // #endif // WPD_SERVICES_STRICT

        }

    }

    public static class CommandSystem

    {

        /// <summary>
        /// All Commands-Parameters and Options associated with: WPD_CATEGORY_COMMON.
        /// </summary>
        public const string Common = "F0422A9C-5DC8-4440-B5BD-5DF28835658A";

        public static class Object

        {

            /// <summary>
            /// This section defines all Commands-Parameters and Options associated with: WPD_CATEGORY_OBJECT_ENUMERATION. The commands in this category are used for basic object enumeration.
            /// </summary>
            public const string Enumeration = "B7474E91-E7F8-4AD9-B400-AD1A4B58EEEC";

            /// <summary>
            /// This section defines all Commands-Parameters and Options associated with: WPD_CATEGORY_OBJECT_PROPERTIES. This category of commands is used to perform basic property operations such as Reading/Writing values-listing supported values and so on.
            /// </summary>
            public const string Properties = "9E5582E4-0814-44E6-981A-B2998D583804";

            /// <summary>
            /// This section defines all Commands-Parameters and Options associated with: WPD_CATEGORY_OBJECT_PROPERTIES_BULK. This category contains commands and properties for property operations across multiple objects.
            /// </summary>
            public const string PropertiesBulk = "11C824DD-04CD-4E4E-8C7B-F6EFB794D84E";

            /// <summary>
            /// This section defines all Commands-Parameters and Options associated with: WPD_CATEGORY_OBJECT_RESOURCES. The commands in this category are used for basic object resource enumeration and transfer.
            /// </summary>
            public const string Resources = "B3A2B22D-A595-4108-BE0A-FC3C965F3D4A";

            /// <summary>
            /// This section defines all Commands-Parameters and Options associated with: WPD_CATEGORY_OBJECT_MANAGEMENT. The commands specified in this category are used to Create/Delete objects on the device.
            /// </summary>
            public const string Management = "EF1E43DD-A9ED-4341-8BCC-186192AEA089";

        }

        /// <summary>
        /// This section defines all Commands-Parameters and Options associated with: WPD_CATEGORY_CAPABILITIES. This command category is used to query capabilities of the device.
        /// </summary>
        public const string Capabilities = "0CABEC78-6B74-41C6-9216-2639D1FCE356";

        /// <summary>
        /// This section defines all Commands-Parameters and Options associated with: WPD_CATEGORY_STORAGE. This category is for commands and parameters for storage functional objects.
        /// </summary>
        public const string Storage = "D8F907A6-34CC-45FA-97FB-D007FA47EC94";

        /// <summary>
        /// This section defines all Commands-Parameters and Options associated with: WPD_CATEGORY_SMS. The commands in this category relate to Short-Message-Service functionality-typically exposed on mobile phones.
        /// </summary>
        public const string SMS = "AFC25D66-FE0D-4114-9097-970C93E920D1";

        /// <summary>
        /// This section defines all Commands-Parameters and Options associated with: WPD_CATEGORY_STILL_IMAGE_CAPTURE
        /// </summary>
        public const string StillImageCapture = "4FCD6982-22A2-4B05-A48B-62D38BF27B32";

        /// <summary>
        /// This section defines all Commands-Parameters and Options associated with: WPD_CATEGORY_MEDIA_CAPTURE
        /// </summary>
        public const string MediaCapture = "59B433BA-FE44-4D8D-808C-6BCB9B0F15E8";

        /// <summary>
        /// This section defines all Commands-Parameters and Options associated with: WPD_CATEGORY_DEVICE_HINTS. The commands in this category relate to hints that a device can provide to improve end-user experience.
        /// </summary>
        public const string DeviceHints = "0D5FB92B-CB46-4C4F-8343-0BC3D3F17C84";

        /// <summary>
        /// This section defines all Commands-Parameters and Options associated with: WPD_CLASS_EXTENSION_V1. The commands in this category relate to the WPD device class extension.
        /// </summary>
        public const string ClassExtensionV1 = "33FB0D11-64A3-4FAC-B4C7-3DFEAA99B051";

        /// <summary>
        /// This section defines all Commands-Parameters and Options associated with: WPD_CLASS_EXTENSION_V2. The commands in this category relate to the WPD device class extension.
        /// </summary>
        public const string ClassExtensionV2 = "7F0779B5-FA2B-4766-9CB2-F73BA30B6758";

        /// <summary>
        /// This section defines all Commands-Parameters and Options associated with: WPD_CATEGORY_NULL. This category is used exclusively for the NULL property key define.
        /// </summary>
        public const string CategoryNull = "00000000-0000-0000-0000-000000000000";

        /// <summary>
        /// This section defines all Commands-Parameters and Options associated with: WPD_CATEGORY_NETWORK_CONFIGURATION. The commands in this category are used for Network Association and WiFi Configuration.
        /// </summary>
        public const string NetworkConfiguration = "78F9C6FC-79B8-473C-9060-6BD23DD072C4";

        public static class Service

        {

            /// <summary>
            /// This section defines all Commands-Parameters and Options associated with: WPD_CATEGORY_SERVICE_COMMON. The commands in this category relate to a device service.
            /// </summary>
            public const string Common = "322F071D-36EF-477F-B4B5-6F52D734BAEE";

            /// <summary>
            /// This section defines all Commands-Parameters and Options associated with: WPD_CATEGORY_SERVICE_CAPABILITIES. The commands in this category relate to capabilities of a device service.
            /// </summary>
            public const string Capabilities = "24457E74-2E9F-44F9-8C57-1D1BCB170B89";

            /// <summary>
            /// This section defines all Commands-Parameters and Options associated with: WPD_CATEGORY_SERVICE_METHODS. The commands in this category relate to methods of a device service.
            /// </summary>
            public const string Methods = "2D521CA8-C1B0-4268-A342-CF19321569BC";

        }

    }

}

namespace Microsoft.WindowsAPICodePack.Win32Native.Guids

{

    public static class Sensors

    {

        public const string ISensor = "5FA08F80-2657-458E-AF75-46F73FA6AC5C";

    }

    public static class PortableDevices

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

        public const string IWpdSerializer = "b32f4002-bb27-45ff-af4f-06631c1e8dad";

        public const string PortableDeviceFTM = "f7c0039a-4762-488a-b4b3-760ef9a1ba9b";
        [Obsolete("This CLSID does not aggregates the free-threaded marshaler and is here for legacy reasons. Use the IPortableDeviceFTM constant instead.")]
        public const string PortableDevice = "728a21c5-3d9e-48d7-9810-864848f0f404";
        public const string PortableDeviceManager = "0af10cec-2ecd-4b92-9581-34f6ae0637f3";
        public const string PortableDeviceValues = "0c15d503-d017-47ce-9016-7b3f978721cc";
        public const string PortableDevicePropVariantCollection = "08a99e2f-6d6d-4b80-af5a-baf2bcbe4cb9";
        public const string PortableDeviceKeyCollection = "de2d022d-2480-43be-97f0-d1fa2cf98f4f";

    }

    public static class MediaDevices

    {

        public const string IComponentAuthenticate = "A9889C00-6D2B-11d3-8496-00C04F79DBC0";
        public const string IMDServiceProvider = "1DCB3A10-33ED-11d3-8470-00C04F79DBC0";
        public const string IMDServiceProvider2 = "B2FA24B7-CDA3-4694-9862-413AE1A34819";
        public const string IMDServiceProvider3 = "4ed13ef3-a971-4d19-9f51-0e1826b2da57";
        public const string IMDSPDevice = "1DCB3A12-33ED-11d3-8470-00C04F79DBC0";
        public const string IMDSPDevice2 = "420D16AD-C97D-4e00-82AA-00E9F4335DDD";
        public const string IMDSPDevice3 = "1a839845-fc55-487c-976f-ee38ac0e8c4e";
        public const string IMDSPDeviceControl = "1DCB3A14-33ED-11d3-8470-00C04F79DBC0";
        public const string IMDSPDirectTransfer = "c2fe57a8-9304-478c-9ee4-47e397b912d7";
        public const string IMDSPEnumDevice = "1DCB3A11-33ED-11d3-8470-00C04F79DBC0";
        public const string IMDSPEnumStorage = "1DCB3A15-33ED-11d3-8470-00C04F79DBC0";
        public const string IMDSPObject = "1DCB3A18-33ED-11d3-8470-00C04F79DBC0";
        public const string IMDSPObject2 = "3f34cd3e-5907-4341-9af9-97f4187c3aa5";
        public const string IMDSPObjectInfo = "1DCB3A19-33ED-11d3-8470-00C04F79DBC0";
        public const string IMDSPRevoked = "A4E8F2D4-3F31-464d-B53D-4FC335998184";
        public const string IMDSPStorage = "1DCB3A16-33ED-11d3-8470-00C04F79DBC0";
        public const string IMDSPStorage2 = "0A5E07A5-6454-4451-9C36-1C6AE7E2B1D6";
        public const string IMDSPStorage3 = "6C669867-97ED-4a67-9706-1C5529D2A414";
        public const string IMDSPStorage4 = "3133b2c4-515c-481b-b1ce-39327ecb4f74";
        public const string IMDSPStorageGlobals = "1DCB3A17-33ED-11d3-8470-00C04F79DBC0";
        public const string ISCPSecureAuthenticate = "1DCB3A0F-33ED-11d3-8470-00C04F79DBC0";
        public const string ISCPSecureAuthenticate2 = "B580CFAE-1672-47e2-ACAA-44BBECBCAE5B";
        public const string ISCPSecureExchange = "1DCB3A0E-33ED-11d3-8470-00C04F79DBC0";
        public const string ISCPSecureExchange2 = "6C62FC7B-2690-483F-9D44-0A20CB35577C";
        public const string ISCPSecureExchange3 = "ab4e77e4-8908-4b17-bd2a-b1dbe6dd69e1";
        public const string ISCPSecureQuery = "1DCB3A0D-33ED-11d3-8470-00C04F79DBC0";
        public const string ISCPSecureQuery2 = "EBE17E25-4FD7-4632-AF46-6D93D4FCC72E";
        public const string ISCPSecureQuery3 = "B7EDD1A2-4DAB-484b-B3C5-AD39B8B4C0B1";
        public const string ISCPSession = "88a3e6ed-eee4-4619-bbb3-fd4fb62715d1";
        public const string IWMDeviceManager = "1DCB3A00-33ED-11d3-8470-00C04F79DBC0";
        public const string IWMDeviceManager2 = "923E5249-8731-4c5b-9B1C-B8B60B6E46AF";
        public const string IWMDeviceManager3 = "af185c41-100d-46ed-be2e-9ce8c44594ef";
        public const string IWMDMDevice = "1DCB3A02-33ED-11d3-8470-00C04F79DBC0";
        public const string IWMDMDevice2 = "E34F3D37-9D67-4fc1-9252-62D28B2F8B55";
        public const string IWMDMDevice3 = "6c03e4fe-05db-4dda-9e3c-06233a6d5d65";
        public const string IWMDMDeviceControl = "1DCB3A04-33ED-11d3-8470-00C04F79DBC0";
        public const string IWMDMDeviceSession = "82af0a65-9d96-412c-83e5-3c43e4b06cc7";
        public const string IWMDMEnumDevice = "1DCB3A01-33ED-11d3-8470-00C04F79DBC0";
        public const string IWMDMEnumStorage = "1DCB3A05-33ED-11d3-8470-00C04F79DBC0";
        public const string IWMDMMetaData = "EC3B0663-0951-460a-9A80-0DCEED3C043C";
        public const string IWMDMNotification = "3F5E95C0-0F43-4ed4-93D2-C89A45D59B81";
        public const string IWMDMObjectInfo = "1DCB3A09-33ED-11d3-8470-00C04F79DBC0";
        public const string IWMDMOperation = "1DCB3A0B-33ED-11d3-8470-00C04F79DBC0";
        public const string IWMDMOperation2 = "33445B48-7DF7-425c-AD8F-0FC6D82F9F75";
        public const string IWMDMOperation3 = "d1f9b46a-9ca8-46d8-9d0f-1ec9bae54919";
        public const string IWMDMProgress = "1DCB3A0C-33ED-11d3-8470-00C04F79DBC0";
        public const string IWMDMProgress2 = "3A43F550-B383-4e92-B04A-E6BBC660FEFC";
        public const string IWMDMProgress3 = "21DE01CB-3BB4-4929-B21A-17AF3F80F658";
        public const string IWMDMRevoked = "EBECCEDB-88EE-4e55-B6A4-8D9F07D696AA";
        public const string IWMDMStorage = "1DCB3A06-33ED-11d3-8470-00C04F79DBC0";
        public const string IWMDMStorage2 = "1ED5A144-5CD5-4683-9EFF-72CBDB2D9533";
        public const string IWMDMStorage3 = "97717EEA-926A-464e-96A4-247B0216026E";
        public const string IWMDMStorage4 = "c225bac5-a03a-40b8-9a23-91cf478c64a6";
        public const string IWMDMStorageControl = "1DCB3A08-33ED-11d3-8470-00C04F79DBC0";
        public const string IWMDMStorageControl2 = "972C2E88-BD6C-4125-8E09-84F837E637B6";
        public const string IWMDMStorageControl3 = "B3266365-D4F3-4696-8D53-BD27EC60993A";
        public const string IWMDMStorageGlobals = "1DCB3A07-33ED-11d3-8470-00C04F79DBC0";
        public const string IWMDMLogger = "110A3200-5A79-11d3-8D78-444553540000";

    }

    public static class COM

    {

        public const string ISpecifyPropertyPages = "B196B28B-BAB4-101A-B69C-00AA00341D07";
        public const string IMarshal = "00000003-0000-0000-C000-000000000046";

    }

    public static class Net

    {

        public const string INetwork = "DCB00002-570F-4A9B-8D69-199FDBA5723B";
        public const string INetworkConnection = "DCB00005-570F-4A9B-8D69-199FDBA5723B";
        public const string INetworkListManager = "DCB00000-570F-4A9B-8D69-199FDBA5723B";
        public const string NetworkListManagerClass = "DCB00C01-570F-4A9B-8D69-199FDBA5723B";

    }

}

namespace Microsoft.WindowsAPICodePack.ApplicationServices.Guids

{
    public static class PowerPersonality
    {

        public const string HighPerformance = "8c5e7fda-e8bf-4a96-9a85-a6e23a8c635c";
        public const string PowerSaver = "a1841308-3541-4fab-bc81-f71556f20b4a";
        public const string Automatic = "381b4222-f694-41f0-9685-ff5bb260df2e";

        public const string All = "68A1E95E-13EA-41E1-8011-0C496CA490B0";

    }

    /// <summary>
    /// Hardcoded GUIDS for each event.
    /// </summary>
    public static class EventManager

    {

        public const string PowerPersonalityChange = "245d8541-3943-4422-b025-13A784F679B7";
        public const string PowerSourceChange = "5d3e9a59-e9D5-4b00-a6bd-ff34ff516548";
        public const string BatteryCapacityChange = "a7ad8041-b45a-4cae-87a3-eecbb468a9e1";
        public const string BackgroundTaskNotification = "515c31d8-f734-163d-a0fd-11a08c91e8f1";
        public const string MonitorPowerStatus = "02731015-4510-4526-99e6-e5a17ebd1aea";

    }

}

namespace Microsoft.WindowsAPICodePack.Win32Native.Guids

{
    public static class Taskbar
    {
        public const string IObjectArray = "92CA9DCD-5622-4BBA-A805-5E9F541BD8C9";
        public const string IUnknown = "00000000-0000-0000-C000-000000000046";
    }

}

namespace Microsoft.WindowsAPICodePack.Shell.Guids

{

    namespace PropertySystem

    {

        public static class SystemProperties
        {

            public const string AcquisitionID = "65A98875-3C80-40AB-ABBC-EFDAF77DBEE2";
            public const string PSGUID_MediaFileSummaryInformation = "64440492-4C8B-11D1-8B70-080036B11A03";
            public const string DateAcquired = "2CBAA8F5-D81F-47CA-B17A-F8D822300131";
            public const string DateArchived = "43F8D7B7-A444-4F87-9383-52271C9B915C";
            public const string DateCompleted = "72FAB781-ACDA-43E5-B155-B2434F85E678";
            public const string DueDate = "3F8472B5-E0AF-4DB2-8071-C53FE76AE7CE";
            public const string EndDate = "C75FAA05-96FD-49E7-9CB4-9F601082D553";
            public const string FileExtension = "E4F10A3C-49E6-405D-8288-A23BD4EEAA6C";
            public const string FileName = "41CF5AE0-F75A-4806-BD87-59C7D9248EB9";
            public const string FlagColor = "67DF94DE-0CA7-4D6F-B792-053A3E4F03CF";
            public const string FlagColorText = "45EAE747-8E2A-40AE-8CBF-CA52ABA6152A";
            public const string FlagStatus = "E3E0584C-B788-4A5A-BB20-7F5A44C9ACDD";
            public const string FlagStatusText = "DC54FD2E-189D-4871-AA01-08C2F57A4ABC";
            public const string FullText = "1E3EE840-BC2B-476C-8237-2ACD1A839B22";
            public const string IdentityProperty = "A26F4AFC-7346-4299-BE47-EB1AE613139F";
            public const string ImageParsingName = "D7750EE0-C6A4-48EC-B53E-B87B52E6D073";
            public const string Importance = "E3E0584C-B788-4A5A-BB20-7F5A44C9ACDD";
            public const string ImportanceText = "A3B29791-7713-4E1D-BB40-17DB85F01831";
            public const string InfoTipText = "C9944A21-A406-48FE-8225-AEC7E24C211B";
            public const string IsAttachment = "F23F425C-71A1-4FA8-922F-678EA4A60408";
            public const string IsDefaultNonOwnerSaveLocation = "5D76B67F-9B3D-44BB-B6AE-25DA4F638A67";
            public const string IsDefaultSaveLocation = "5D76B67F-9B3D-44BB-B6AE-25DA4F638A67";
            public const string IsDeleted = "5CDA5FC8-33EE-4FF3-9094-AE7BD8868C4D";
            public const string IsEncrypted = "90E5E14E-648B-4826-B2AA-ACAF790E3513";
            public const string IsFlagged = "5DA84765-E3FF-4278-86B0-A27967FBDD03";

            public static class FormatIdentifiersGuids
            {

                public const string SummaryInformation = "F29F85E0-4FF9-1068-AB91-08002B27B3D9";
                public const string Volume = "9B174B35-40FF-11D2-A27E-00C04FC30871";
                public const string DocumentSummaryInformation = "D5CDD502-2E9C-101B-9397-08002B2CF9AE";
                public const string ShellDetails = "28636AA6-953D-11D2-B5D6-00C04FD918D0";
                public const string Storage = "B725F130-47EF-101A-A5F1-02608C9EEBAC";
                public const string Version = "0CEF7D53-FA64-11D1-A203-0000F81FEDEE";
                public const string Misc = "9B174B34-40FF-11D2-A27E-00C04FC30871";
                public const string Query = "49691C90-7E17-101A-A91C-08002B2ECDA9";
                public const string ImageProperties = "14B81DA1-0135-4D31-96D9-6CBFC9671A99";
                public const string IntSite = "000214A1-0000-0000-C000-000000000046";

            }

        }

    }

    public static class ShellKFIDGuid
    {

        public const string ComputerFolder = "0AC0837C-BBF8-452A-850D-79D08E667CA7";
        public const string Favorites = "1777F761-68AD-4D8A-87BD-30B759FA33DD";
        public const string Documents = "FDD39AD0-238F-46AF-ADB4-6C85480369C7";
        public const string Profile = "5E6C858F-0E22-4760-9AFE-EA3317B67173";

        public const string GenericLibrary = "5c4f28b5-f869-4e84-8e60-f11db97c5cc7";
        public const string DocumentsLibrary = "7d49d726-3c21-4f05-99aa-fdc2c9474656";
        public const string MusicLibrary = "94d6ddcc-4a68-4175-a374-bd584a510b78";
        public const string PicturesLibrary = "b3690e58-e961-423b-b687-386ebfd83239";
        public const string VideosLibrary = "5fa96407-7e77-483c-ac93-691d05850de8";

        public const string Libraries = "1B3EA5DC-B587-4786-B4EF-BD1DC332AEAE";
    }

    public static class ShellBHIDGuid
    {
        public const string ShellFolderObject = "3981e224-f559-11d3-8e3a-00c04f6837d5";
    }

    public static class KnownFoldersKFIDGuid
    {
        public const string ComputerFolder = "0AC0837C-BBF8-452A-850D-79D08E667CA7";
        public const string Favorites = "1777F761-68AD-4D8A-87BD-30B759FA33DD";
        public const string Documents = "FDD39AD0-238F-46AF-ADB4-6C85480369C7";
        public const string Profile = "5E6C858F-0E22-4760-9AFE-EA3317B67173";
    }

    public static class FolderTypes
    {
        /// <summary>
        /// No particular content type has been detected or specified. This value is not supported in Windows 7 and later systems.
        /// </summary>
        public const string NotSpecified = "5c4f28b5-f869-4e84-8e60-f11db97c5cc7";

        /// <summary>
        /// The folder is invalid. There are several things that can cause this judgement: hard disk errors-file system errors-and compression errors among them.
        /// </summary>
        public const string Invalid = "57807898-8c4f-4462-bb63-71042380b109";

        /// <summary>
        /// The folder contains document files. These can be of mixed format.doc-.txt-and others.
        /// </summary>
        public const string Documents = "7d49d726-3c21-4f05-99aa-fdc2c9474656";

        /// <summary>
        /// Image files-such as .jpg-.tif-or .png files.
        /// </summary>
        public const string Pictures = "b3690e58-e961-423b-b687-386ebfd83239";

        /// <summary>
        /// Windows 7 and later. The folder contains audio files-such as .mp3 and .wma files.
        /// </summary>
        public const string Music = "af9c03d6-7db9-4a15-9464-13bf9fb69a2a";

        /// <summary>
        /// A list of music files displayed in Icons view. This value is not supported in Windows 7 and later systems.
        /// </summary>
        public const string MusicIcons = "0b7467fb-84ba-4aae-a09b-15b71097af9e";

        /// <summary>
        /// The folder is the Games folder found in the Start menu.
        /// </summary>
        public const string Games = "b689b0d0-76d3-4cbb-87f7-585d0e0ce070";

        /// <summary>
        /// The Control Panel in category view. This is a virtual folder.
        /// </summary>
        public const string ControlPanelCategory = "de4f0660-fa10-4b8f-a494-068b20b22307";

        /// <summary>
        /// The Control Panel in classic view. This is a virtual folder.
        /// </summary>
        public const string ControlPanelClassic = "0c3794f3-b545-43aa-a329-c37430c58d2a";

        /// <summary>
        /// Printers that have been added to the system. This is a virtual folder.
        /// </summary>
        public const string Printers = "2c7bbec6-c844-4a0a-91fa-cef6f59cfda1";

        /// <summary>
        /// The Recycle Bin. This is a virtual folder.
        /// </summary>
        public const string RecycleBin = "d6d9e004-cd87-442b-9d57-5e0aeb4f6f72";

        /// <summary>
        /// The software explorer window used by the Add or Remove Programs control panel icon.
        /// </summary>
        public const string SoftwareExplorer = "d674391b-52d9-4e07-834e-67c98610f39d";

        /// <summary>
        /// The folder is a compressed archive-such as a compressed file with a .zip file name extension.
        /// </summary>
        public const string CompressedFolder = "80213e82-bcfd-4c4f-8817-bb27601267a9";

        /// <summary>
        /// An e-mail-related folder that contains contact information.
        /// </summary>
        public const string Contacts = "de2b70ec-9bf7-4a93-bd3d-243f7881d492";

        /// <summary>
        /// A default library view without a more specific template. This value is not supported in Windows 7 and later systems.
        /// </summary>
        public const string Library = "4badfc68-c4ac-4716-a0a0-4d5daa6b0f3e";

        /// <summary>
        /// The Network Explorer folder.
        /// </summary>
        public const string NetworkExplorer = "25cc242b-9a7c-4f51-80e0-7a2928febe42";

        /// <summary>
        /// The folder is the FOLDERID_UsersFiles folder.
        /// </summary>
        public const string UserFiles = "cd0fc69b-71e2-46e5-9690-5bcd9f57aab3";

        /// <summary>
        /// Windows 7 and later. The folder contains search results-but they are of mixed or no specific type.
        /// </summary>
        public const string GenericSearchResults = "7fde1a1e-8b31-49a5-93b8-6be14cfa4943";

        /// <summary>
        /// Windows 7 and later. The folder is a library-but of no specified type.
        /// </summary>
        public const string GenericLibrary = "5f4eab9a-6833-4f61-899d-31cf46979d49";

        /// <summary>
        /// Windows 7 and later. The folder contains video files. These can be of mixed format.wmv-.mov-and others.
        /// </summary>
        public const string Videos = "5fa96407-7e77-483c-ac93-691d05850de8";

        /// <summary>
        /// Windows 7 and later. The view shown when the user clicks the Windows Explorer button on the taskbar.
        /// </summary>
        public const string UsersLibraries = "c4d98f09-6124-4fe0-9942-82641682da9";

        /// <summary>
        /// Windows 7 and later. The homegroup view.
        /// </summary>
        public const string OtherUsers = "b337fd00-9dd5-4635-a6d4-da33fd102b7a";

        /// <summary>
        /// Windows 7 and later. A folder that contains communication-related files such as e-mails-calendar information-and contact information.
        /// </summary>
        public const string Communications = "91475fe5-586b-4eba-8d75-d17434b8cdf6";

        /// <summary>
        /// Windows 7 and later. The folder contains recorded television broadcasts.
        /// </summary>
        public const string RecordedTV = "5557a28f-5da6-4f83-8809-c2c98a11a6fa";

        /// <summary>
        /// Windows 7 and later. The folder contains saved game states.
        /// </summary>
        public const string SavedGames = "d0363307-28cb-4106-9f23-2956e3e5e0e7";

        /// <summary>
        /// Windows 7 and later. The folder contains federated search OpenSearch results.
        /// </summary>
        public const string OpenSearch = "8faf9629-1980-46ff-8023-9dceab9c3ee3";

        /// <summary>
        /// Windows 7 and later. Before you search.
        /// </summary>
        public const string SearchConnector = "982725ee-6f47-479e-b447-812bfa7d2e8f";

        /// <summary>
        /// Windows 7 and later. A user's Searches folder-normally found at C:\Users\username\Searches.
        /// </summary>
        public const string Searches = "0b0ba2e3-405f-415e-a6ee-cad625207853";

    }

}

namespace Microsoft.WindowsAPICodePack.Win32Native.Guids.Shell
{
    public static class PropertySystem
    {
        public const string IPropertyChangeArray = "380F5CAD-1B5E-42F2-805D-637FD392D31E";
        public const string IPropertyChange = "F917BC8A-1BBA-4478-A245-1BDE03EB9431";
    }

    public static class ShellIIDGuid
    {

        // IID GUID strings for relevant Shell COM interfaces.
        public const string IModalWindow = "B4DB1657-70D7-485E-8E3E-6FCB5A5C1802";
        public const string IFileDialog = "42F85136-DB7E-439C-85F1-E4075D135FC8";
        public const string IFileOpenDialog = "D57C7288-D4AD-4768-BE02-9D969532D960";
        public const string IFileSaveDialog = "84BCCD23-5FDE-4CDB-AEA4-AF64B83D78AB";
        public const string IFileDialogEvents = "973510DB-7D7F-452B-8975-74A85828D354";
        public const string IFileDialogControlEvents = "36116642-D713-4B97-9B83-7484A9D00433";
        public const string IFileDialogCustomize = "E6FDD21A-163F-4975-9C8C-A69F1BA37034";

        public const string IShellItem = "43826D1E-E718-42EE-BC55-A1E261C37BFE";
        public const string IShellItem2 = "7E9FB0D3-919F-4307-AB2E-9B1860310C93";
        public const string IShellItemArray = "B63EA76D-1F85-456F-A19C-48159EFA858B";
        public const string IShellLibrary = "11A66EFA-382E-451A-9234-1E0E12EF3085";
        public const string IThumbnailCache = "F676C15D-596A-4ce2-8234-33996F445DB1";
        public const string ISharedBitmap = "091162a4-bc96-411f-aae8-c5122cd03363";
        public const string IShellFolder = "000214E6-0000-0000-C000-000000000046";
        public const string IShellFolder2 = "93F2F68C-1D1B-11D3-A30E-00C04F79ABD1";
        public const string IEnumIDList = "000214F2-0000-0000-C000-000000000046";
        public const string IShellLinkW = "000214F9-0000-0000-C000-000000000046";
        public const string CShellLink = "00021401-0000-0000-C000-000000000046";

        public const string IPropertyStore = "886D8EEB-8CF2-4446-8D02-CDBA1DBDCF99";
        public const string IPropertyStoreCache = "3017056d-9a91-4e90-937d-746c72abbf4f";
        public const string IPropertyDescription = "6F79D558-3E96-4549-A1D1-7D75D2288814";
        public const string IPropertyDescription2 = "57D2EDED-5062-400E-B107-5DAE79FE57A6";
        public const string IPropertyDescriptionList = "1F9FC1D0-C39B-4B26-817F-011967D3440E";
        public const string IPropertyEnumType = "11E1FBF9-2D56-4A6B-8DB3-7CD193A471F2";
        public const string IPropertyEnumType2 = "9B6E051C-5DDD-4321-9070-FE2ACB55E794";
        public const string IPropertyEnumTypeList = "A99400F4-3D84-4557-94BA-1242FB2CC9A6";
        public const string IPropertyStoreCapabilities = "c8e2d566-186e-4d49-bf41-6909ead56acc";

        public const string ICondition = "0FC988D4-C935-4b97-A973-46282EA175C8";
        public const string ISearchFolderItemFactory = "a0ffbc28-5482-4366-be27-3e81e78e06c2";
        public const string IConditionFactory = "A5EFE073-B16F-474f-9F3E-9F8B497A3E08";
        public const string IRichChunk = "4FDEF69C-DBC9-454e-9910-B34F3C64B510";
        public const string IPersistStream = "00000109-0000-0000-C000-000000000046";
        public const string IPersist = "0000010c-0000-0000-C000-000000000046";
        public const string IEnumUnknown = "00000100-0000-0000-C000-000000000046";
        public const string IQuerySolution = "D6EBC66B-8921-4193-AFDD-A1789FB7FF57";
        public const string IQueryParser = "2EBDEE67-3505-43f8-9946-EA44ABC8E5B0";
        public const string IQueryParserManager = "A879E3C4-AF77-44fb-8F37-EBD1487CF920";
        public const string IEntity = "24264891-E80B-4fd3-B7CE-4FF2FAE8931F";
        public const string IFileOperation = "947AAB5F-0A5C-4C13-B4D6-4BF7836FC9F8";
    }

    public static class ShellCLSIDGuid
    {

        // CLSID GUID strings for relevant coclasses.
        public const string FileOpenDialog = "DC1C5A9C-E88A-4DDE-A5A1-60F82A20AEF7";
        public const string FileSaveDialog = "C0B4E2F3-BA21-4773-8DBA-335EC946EB8B";
        public const string KnownFolderManager = "4DF0C730-DF9D-4AE3-9153-AA6B82E9795A";
        public const string ShellLibrary = "D9B3211D-E57F-4426-AAEF-30A806ADD397";
        public const string SearchFolderItemFactory = "14010e02-bbbd-41f0-88e3-eda371216584";
        public const string ConditionFactory = "E03E85B0-7BE3-4000-BA98-6C13DE9FA486";
        public const string QueryParserManager = "5088B39A-29B4-4d9d-8245-4EE289222F66";
    }

    public static class KnownFoldersIIDGuid
    {
        // IID GUID strings for relevant Shell COM interfaces.
        public const string IKnownFolder = "3AA7AF7E-9B36-420c-A8E3-F77D4674A488";
        public const string IKnownFolderManager = "8BE2D872-86AA-4d47-B776-32CCA40C7018";
    }

    public static class KnownFoldersCLSIDGuid
    {
        // CLSID GUID strings for relevant coclasses.
        public const string KnownFolderManager = "4df0c730-df9d-4ae3-9153-aa6b82e9795a";
    }


}

namespace Microsoft.WindowsAPICodePack.Win32Native.Guids.Shell.FolderIdentifiers

{

    /// <summary>
    /// KnownFolder Guids
    /// </summary>
    public static class KnownFolders

    {

        /// <summary>
        /// Computer
        /// </summary>
        public const string Computer = "0AC0837C-BBF8-452A-850D-79D08E667CA7";

        /// <summary>
        /// Conflicts
        /// </summary>
        public const string Conflict = "4bfefb45-347d-4006-a5be-ac0cb0567192";

        /// <summary>
        /// Control Panel
        /// </summary>
        public const string ControlPanel = "82A74AEB-AEB4-465C-A014-D097EE346D63";

        /// <summary>
        /// Desktop
        /// </summary>
        public const string Desktop = "B4BFCC3A-DB2C-424C-B029-7FE99A87C641";

        /// <summary>
        /// Internet Explorer
        /// </summary>
        public const string Internet = "4D9F7874-4E0C-4904-967B-40B0D20C3E4B";

        /// <summary>
        /// Network
        /// </summary>
        public const string Network = "D20BEEC4-5CA8-4905-AE3B-BF251EA09B53";

        /// <summary>
        /// Printers
        /// </summary>
        public const string Printers = "76FC4E2D-D6AD-4519-A663-37BD56068185";

        /// <summary>
        /// Sync Center
        /// </summary>
        public const string SyncManager = "43668BF8-C14E-49B2-97C9-747784D784B7";

        /// <summary>
        /// Network Connections
        /// </summary>
        public const string Connections = "6F0CD92B-2E97-45D1-88FF-B0D186B8DEDD";

        /// <summary>
        /// Sync Setup
        /// </summary>
        public const string SyncSetup = "f214138-b1d3-4a90-bba9-27cbc0c5389a";

        /// <summary>
        /// Sync Results
        /// </summary>
        public const string SyncResults = "289a9a43-be44-4057-a41b-587a76d7e7f9";

        /// <summary>
        /// Recycle Bin
        /// </summary>
        public const string RecycleBin = "B7534046-3ECB-4C18-BE4E-64CD4CB7D6AC";

        /// <summary>
        /// Fonts
        /// </summary>
        public const string Fonts = "FD228CB7-AE11-4AE3-864C-16F3910AB8FE";

        /// <summary>
        /// Startup
        /// </summary>
        public const string Startup = "B97D20BB-F46A-4C97-BA10-5E3608430854";

        /// <summary>
        /// Programs
        /// </summary>
        public const string Programs = "A77F5D77-2E2B-44C3-A6A2-ABA601054A51";

        /// <summary>
        /// Start Menu
        /// </summary>
        public const string StartMenu = "625B53C3-AB48-4EC1-BA1F-A1EF4146FC19";

        /// <summary>
        /// Recent Items
        /// </summary>
        public const string Recent = "AE50C081-EBD2-438A-8655-8A092E34987A";

        /// <summary>
        /// SendTo
        /// </summary>
        public const string SendTo = "8983036C-27C0-404B-8F08-102D10DCFD74";

        /// <summary>
        /// Documents
        /// </summary>
        public const string Documents = "FDD39AD0-238F-46AF-ADB4-6C85480369C7";

        /// <summary>
        /// Favorites
        /// </summary>
        public const string Favorites = "1777F761-68AD-4D8A-87BD-30B759FA33DD";

        /// <summary>
        /// Network Shortcuts
        /// </summary>
        public const string NetHood = "C5ABBF53-E17F-4121-8900-86626FC2C973";

        /// <summary>
        /// Printer Shortcuts
        /// </summary>
        public const string PrintHood = "9274BD8D-CFD1-41C3-B35E-B13F55A758F4";

        /// <summary>
        /// Templates
        /// </summary>
        public const string Templates = "A63293E8-664E-48DB-A079-DF759E0509F7";

        /// <summary>
        /// Startup
        /// </summary>
        public const string CommonStartup = "82A5EA35-D9CD-47C5-9629-E15D2F714E6E";

        /// <summary>
        /// Programs
        /// </summary>
        public const string CommonPrograms = "0139D44E-6AFE-49F2-8690-3DAFCAE6FFB8";

        /// <summary>
        /// Start Menu
        /// </summary>
        public const string CommonStartMenu = "A4115719-D62E-491D-AA7C-E74B8BE3B067";

        /// <summary>
        /// Public Desktop
        /// </summary>
        public const string PublicDesktop = "C4AA340D-F20F-4863-AFEF-F87EF2E6BA25";

        /// <summary>
        /// ProgramData
        /// </summary>
        public const string ProgramData = "62AB5D82-FDC1-4DC3-A9DD-070D1D495D97";

        /// <summary>
        /// Templates
        /// </summary>
        public const string CommonTemplates = "B94237E7-57AC-4347-9151-B08C6C32D1F7";

        /// <summary>
        /// Public Documents
        /// </summary>
        public const string PublicDocuments = "ED4824AF-DCE4-45A8-81E2-FC7965083634";

        /// <summary>
        /// Roaming
        /// </summary>
        public const string RoamingAppData = "3EB685DB-65F9-4CF6-A03A-E3EF65729F3D";

        /// <summary>
        /// Local
        /// </summary>
        public const string LocalAppData = "F1B32785-6FBA-4FCF-9D55-7B8E7F157091";

        /// <summary>
        /// LocalLow
        /// </summary>
        public const string LocalAppDataLow = "A520A1A4-1780-4FF6-BD18-167343C5AF16";

        /// <summary>
        /// Temporary Internet Files
        /// </summary>
        public const string InternetCache = "352481E8-33BE-4251-BA85-6007CAEDCF9D";

        /// <summary>
        /// Cookies
        /// </summary>
        public const string Cookies = "2B0F765D-C0E9-4171-908E-08A611B84FF6";

        /// <summary>
        /// History
        /// </summary>
        public const string History = "D9DC8A3B-B784-432E-A781-5A1130A75963";

        /// <summary>
        /// System32
        /// </summary>
        public const string System = "1AC14E77-02E7-4E5D-B744-2EB1AE5198B7";

        /// <summary>
        /// System32
        /// </summary>
        public const string SystemX86 = "D65231B0-B2F1-4857-A4CE-A8E7C6EA7D27";

        /// <summary>
        /// Windows
        /// </summary>
        public const string Windows = "F38BF404-1D43-42F2-9305-67DE0B28FC23";

        /// <summary>
        /// The user's username (%USERNAME%"
        /// </summary>
        public const string Profile = "5E6C858F-0E22-4760-9AFE-EA3317B67173";

        /// <summary>
        /// Pictures
        /// </summary>
        public const string Pictures = "33E28130-4E1E-4676-835A-98395C3BC3BB";

        /// <summary>
        /// Program Files
        /// </summary>
        public const string ProgramFilesX86 = "7C5A40EF-A0FB-4BFC-874A-C0F2E0B9FA8E";

        /// <summary>
        /// Common Files
        /// </summary>
        public const string ProgramFilesCommonX86 = "DE974D24-D9C6-4D3E-BF91-F4455120B917";

        /// <summary>
        /// Program Files
        /// </summary>
        public const string ProgramFilesX64 = "6d809377-6af0-444b-8957-a3773f02200e";

        /// <summary>
        /// Common Files
        /// </summary>
        public const string ProgramFilesCommonX64 = "6365d5a7-f0d-45e5-87f6-da56b6a4f7d";

        /// <summary>
        /// Program Files
        /// </summary>
        public const string ProgramFiles = "905e63b6-c1bf-494e-b29c-65b732d3d21a";

        /// <summary>
        /// Common Files
        /// </summary>
        public const string ProgramFilesCommon = "F7F1ED05-9F6D-47A2-AAAE-29D317C6F066";

        /// <summary>
        /// Administrative Tools
        /// </summary>
        public const string AdminTools = "724EF170-A42D-4FEF-9F26-B60E846FBA4F";

        /// <summary>
        /// Administrative Tools
        /// </summary>
        public const string CommonAdminTools = "D0384E7D-BAC3-4797-8F14-CBA229B392B5";

        /// <summary>
        /// Music
        /// </summary>
        public const string Music = "4BD8D571-6D19-48D3-BE97-422220080E43";

        /// <summary>
        /// Videos
        /// </summary>
        public const string Videos = "18989B1D-99B5-455B-841C-AB7C74E4DDFC";

        /// <summary>
        /// Public Pictures
        /// </summary>
        public const string PublicPictures = "B6EBFB86-6907-413C-9AF7-4FC2ABF07CC5";

        /// <summary>
        /// Public Music
        /// </summary>
        public const string PublicMusic = "3214FAB5-9757-4298-BB61-92A9DEAA44FF";

        /// <summary>
        /// Public Videos
        /// </summary>
        public const string PublicVideos = "2400183A-6185-49FB-A2D8-4A392A602BA3";

        /// <summary>
        /// Resources
        /// </summary>
        public const string ResourceDir = "8AD10C31-2ADB-4296-A8F7-E4701232C972";

        /// <summary>
        /// None
        /// </summary>
        public const string LocalizedResourcesDir = "2A00375E-224C-49DE-B8D1-440DF7EF3DDC";

        /// <summary>
        /// OEM Links
        /// </summary>
        public const string CommonOEMLinks = "C1BAE2D0-10DF-4334-BEDD-7AA20B227A9D";

        /// <summary>
        /// Temporary Burn Folder
        /// </summary>
        public const string CDBurning = "9E52AB10-F80D-49DF-ACB8-4330F5687855";

        /// <summary>
        /// Users
        /// </summary>
        public const string UserProfiles = "0762D272-C50A-4BB0-A382-697DCD729B80";

        /// <summary>
        /// Playlists
        /// </summary>
        public const string Playlists = "DE92C1C7-837F-4F69-A3BB-86E631204A23";

        /// <summary>
        /// Sample Playlists
        /// </summary>
        public const string SamplePlaylists = "15CA69B3-30EE-49C1-ACE1-6B5EC372AFB5";

        /// <summary>
        /// Sample Music
        /// </summary>
        public const string SampleMusic = "B250C668-F57D-4EE1-A63C-290EE7D1AA1F";

        /// <summary>
        /// Sample Pictures
        /// </summary>
        public const string SamplePictures = "C4900540-2379-4C75-844B-64E6FAF8716B";

        /// <summary>
        /// Sample Videos
        /// </summary>
        public const string SampleVideos = "859EAD94-2E85-48AD-A71A-0969CB56A6CD";

        /// <summary>
        /// Slide Shows
        /// </summary>
        public const string PhotoAlbums = "69D2CF90-FC33-4FB7-9A0C-EBB0F0FCB43C";

        /// <summary>
        /// Public
        /// </summary>
        public const string Public = "DFDF76A2-C82A-4D63-906A-5644AC457385";

        /// <summary>
        /// Programs and Features
        /// </summary>
        public const string ChangeRemovePrograms = "df7266ac-9274-4867-8d55-3bd661de872d";

        /// <summary>
        /// Installed Updates
        /// </summary>
        public const string AppUpdates = "a305ce99-f527-492b-8b1a-7e76fa98d6e4";

        /// <summary>
        /// Get Programs
        /// </summary>
        public const string AddNewPrograms = "de61d971-5ebc-4f02-a3a9-6c82895e5c04";

        /// <summary>
        /// Downloads
        /// </summary>
        public const string Downloads = "374de290-123f-4565-9164-39c4925e467b";

        /// <summary>
        /// Public Downloads
        /// </summary>
        public const string PublicDownloads = "3d644c9b-1fb8-4f30-9b45-f670235f79c0";

        /// <summary>
        /// Searches
        /// </summary>
        public const string SavedSearches = "7d1d3a04-debb-4115-95cf-2f29da2920da";

        /// <summary>
        /// Quick Launch
        /// </summary>
        public const string QuickLaunch = "52a4f021-7b75-48a9-9f6b-4b87a210bc8f";

        /// <summary>
        /// Contacts
        /// </summary>
        public const string Contacts = "56784854-c6cb-462b-8169-88e350acb882";

        /// <summary>
        /// Gadgets
        /// </summary>
        public const string SidebarParts = "a75d362e-50fc-4fb7-ac2c-a8beaa314493";

        /// <summary>
        /// Gadgets
        /// </summary>
        public const string SidebarDefaultParts = "7b396e54-9ec5-4300-bea-2482ebae1a26";

        /// <summary>
        /// Tree property value folder
        /// </summary>
        public const string TreeProperties = "5b3749ad-b49f-49c1-83eb-15370fbd4882";

        /// <summary>
        /// GameExplorer
        /// </summary>
        public const string PublicGameTasks = "debf2536-e1a8-4c59-b6a2-414586476aea";

        /// <summary>
        /// GameExplorer
        /// </summary>
        public const string GameTasks = "54fae61-4dd8-4787-80b6-9220c4b70";

        /// <summary>
        /// Saved Games
        /// </summary>
        public const string SavedGames = "4c5c32ff-bb9d-43b0-b5b4-2d72e54eaaa4";

        /// <summary>
        /// Games
        /// </summary>
        public const string Games = "cac52c1a-b53d-4edc-92d7-6b2e8ac19434";

        /// <summary>
        /// Recorded TV
        /// </summary>
        public const string RecordedTV = "bd85e001-112e-431e-983b-7b15ac09fff1";

        /// <summary>
        /// Microsoft Office Outlook
        /// </summary>
        public const string SearchMapi = "98ec0e18-2098-4d44-8644-66979315a281";

        /// <summary>
        /// Offline Files
        /// </summary>
        public const string SearchCsc = "ee32e446-31ca-4aba-814f-a5ebd2fd6d5e";

        /// <summary>
        /// Links
        /// </summary>
        public const string Links = "bfb9d5e0-c6a9-404c-b2b2-ae6db6af4968";

        /// <summary>
        /// The user's full name (for instance-Jean Philippe Bagel" entered when the user account was created.
        /// </summary>
        public const string UsersFiles = "f3ce0f7c-4901-4acc-8648-d5d44b04ef8f";

        /// <summary>
        /// Search home
        /// </summary>
        public const string SearchHome = "190337d1-b8ca-4121-a639-6d472d16972a";

        /// <summary>
        /// Original Images
        /// </summary>
        public const string OriginalImages = "2C36C0AA-5812-4b87-bfd0-4cd0dfb19b39";

        /// <summary>
        /// Win7 KnownFolders Guids
        /// </summary>
        public static class Win7

        {

            /// <summary>
            /// UserProgramFiles
            /// </summary>
            public const string UserProgramFiles = "5cd7aee2-2219-4a67-b85d-6c9ce15660cb";

            /// <summary>
            /// UserProgramFilesCommon
            /// </summary>
            public const string UserProgramFilesCommon = "bcbd3057-ca5c-4622-b42d-bc56db0ae516";

            /// <summary>
            /// Ringtones
            /// </summary>
            public const string Ringtones = "C870044B-F49E-4126-A9C3-B52A1FF411E8";

            /// <summary>
            /// PublicRingtones
            /// </summary>
            public const string PublicRingtones = "E555AB60-153B-4D17-9F04-A5FE99FC15EC";

            /// <summary>
            /// UsersLibraries
            /// </summary>
            public const string UsersLibraries = "a302545d-deff-464b-abe8-61c8648d939b";

            /// <summary>
            /// DocumentsLibrary
            /// </summary>
            public const string DocumentsLibrary = "7b0db17d-9cd2-4a93-9733-46cc89022e7c";

            /// <summary>
            /// MusicLibrary
            /// </summary>
            public const string MusicLibrary = "2112ab0a-c86a-4ffe-a368-de96e4712e";

            /// <summary>
            /// PicturesLibrary
            /// </summary>
            public const string PicturesLibrary = "a990ae9f-a03b-4e80-94bc-9912d750414";

            public const string CameraRollLibrary = "2b20df75-1eda-4039-8097-38798227d5b7";

            public const string SavedPicturesLibrary = "e25b5812-be88-4bd9-94b0-29233477b6c3";

            /// <summary>
            /// VideosLibrary
            /// </summary>
            public const string VideosLibrary = "491e922f-5643-4af4-a7eb-4e7a138d8174";

            /// <summary>
            /// RecordedTVLibrary
            /// </summary>
            public const string RecordedTVLibrary = "1a6fdba2-f42d-4358-a798-b74d745926c5";

            /// <summary>
            /// OtherUsers
            /// </summary>
            public const string OtherUsers = "52528a6b-b9e3-4add-b6d-588c2dba842d";

            /// <summary>
            /// DeviceMetadataStore
            /// </summary>
            public const string DeviceMetadataStore = "5ce4a5e9-e4eb-479d-b89f-130c02886155";

            /// <summary>
            /// Libraries
            /// </summary>
            public const string Libraries = "1b3ea5dc-b587-4786-b4ef-bd1dc332aeae";

            /// <summary>
            /// UserPinned
            /// </summary>
            public const string UserPinned = "9e3995ab-1f9c-4f13-b827-48b24b6c7174";

            /// <summary>
            /// ImplicitAppShortcuts
            /// </summary>
            public const string ImplicitAppShortcuts = "bcb5256f-79f6-4cee-b725-dc34e42fd46";

        }

    }

}

namespace Microsoft.WindowsAPICodePack.Win32Native.Controls
{
    public static class ExplorerBrowserIIDGuid
    {
        // IID GUID strings for relevant Shell COM interfaces.
        public const string IExplorerBrowser = "DFD3B6B5-C10C-4BE9-85F6-A66969F402F6";
        public const string IKnownFolderManager = "8BE2D872-86AA-4d47-B776-32CCA40C7018";
        public const string IFolderView = "cde725b0-ccc9-4519-917e-325d72fab4ce";
        public const string IFolderView2 = "1af3a467-214f-4298-908e-06b03e0b39f9";
        public const string IServiceProvider = "6d5140c1-7436-11ce-8034-00aa006009fa";
        public const string IExplorerPaneVisibility = "e07010ec-bc17-44c0-97b0-46c7c95b9edc";
        public const string IExplorerBrowserEvents = "361bbdc7-e6ee-4e13-be58-58e2240c810f";
        public const string IInputObject = "68284fAA-6A48-11D0-8c78-00C04fd918b4";
        public const string IShellView = "000214E3-0000-0000-C000-000000000046";
        public const string IDispatch = "00020400-0000-0000-C000-000000000046";
        public const string DShellFolderViewEvents = "62112AA2-EBE4-11cf-A5FB-0020AFE7292D";

        public const string ICommDlgBrowser = "000214F1-0000-0000-C000-000000000046";
        public const string ICommDlgBrowser2 = "10339516-2894-11d2-9039-00C04F8EEB3E";
        public const string ICommDlgBrowser3 = "c8ad25a1-3294-41ee-8165-71174bd01c57";

    }

    public static class ExplorerBrowserViewPanes
    {
        public const string Navigation = "cb316b22-25f7-42b8-8a09-540d23a43c2f";
        public const string Commands = "d9745868-ca5f-4a76-91cd-f5a129fbb076";
        public const string CommandsOrganize = "72e81700-e3ec-4660-bf24-3c3b7b648806";
        public const string CommandsView = "21f7c32d-eeaa-439b-bb51-37b96fd6a943";
        public const string Details = "43abf98b-89b8-472d-b9ce-e69b8229f019";
        public const string Preview = "893c63d1-45c8-4d17-be19-223be71be365";
        public const string Query = "65bcde4f-4f07-4f27-83a7-1afca4df7ddd";
        public const string AdvancedQuery = "b4e9db8b-34ba-4c39-b5cc-16a1bd2c411c";
    }

    public static class ExplorerBrowserCLSIDGuid
    {
        // CLSID GUID strings for relevant coclasses.
        public const string ExplorerBrowser = "71F96385-DDD6-48D3-A0C1-AE06E8B055FB";
    }
}

namespace Microsoft.WindowsAPICodePack.Win32Native.Guids.ExtendedLinguisticServices
{

    /// <summary>
    /// This class contains constants describing the existing ELS services for Windows 7.
    /// </summary>
    public static class MappingAvailableServices
    {
        /// <summary>
        /// The guid of the Microsoft Language Detection service.
        /// </summary>
        public const string LanguageDetection = "CF7E00B1-909B-4d95-A8F4-611F7C377702";

        /// <summary>
        /// The guid of the Microsoft Script Detection service.
        /// </summary>
        public const string ScriptDetection = "2D64B439-6CAF-4f6b-B688-E5D0F4FAA7D7";

        /// <summary>
        /// The guid of the Microsoft Traditional Chinese to Simplified Chinese Transliteration service.
        /// </summary>        
        public const string TransliterationHantToHans = "A3A8333B-F4FC-42f6-A0C4-0462FE7317CB";

        /// <summary>
        /// The guid of the Microsoft Simplified Chinese to Traditional Chinese Transliteration service.
        /// </summary>
        public const string TransliterationHansToHant = "3CACCDC8-5590-42dc-9A7B-B5A6B5B3B63B";

        /// <summary>
        /// The guid of the Microsoft Malayalam to Latin Transliteration service.
        /// </summary>
        public const string TransliterationMalayalamToLatin = "D8B983B1-F8BF-4a2b-BCD5-5B5EA20613E1";

        /// <summary>
        /// The guid of the Microsoft Devanagari to Latin Transliteration service.
        /// </summary>        
        public const string TransliterationDevanagariToLatin = "C4A4DCFE-2661-4d02-9835-F48187109803";

        /// <summary>
        /// The guid of the Microsoft Cyrillic to Latin Transliteration service.
        /// </summary>
        public const string TransliterationCyrillicToLatin = "3DD12A98-5AFD-4903-A13F-E17E6C0BFE01";

        /// <summary>
        /// The guid of the Microsoft Bengali to Latin Transliteration service.
        /// </summary>
        public const string TransliterationBengaliToLatin = "F4DFD825-91A4-489f-855E-9AD9BEE55727";
    }

}
