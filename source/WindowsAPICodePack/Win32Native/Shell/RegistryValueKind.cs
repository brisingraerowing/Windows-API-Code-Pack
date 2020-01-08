namespace Microsoft.WindowsAPICodePack.Shell.Registry

{

    public enum RegistryValueKind : uint

    {

        /// <summary>
        /// No value type
        /// </summary>
        None = 0u,
        /// <summary>
        /// Unicode nul terminated string
        /// </summary>
        String = 1u,
        /// <summary>
        /// Unicode nul terminated string (with environment variable references)
        /// </summary>
        ExpandString = 2u,
        /// <summary>
        /// Free form binary
        /// </summary>
        Binary = 3u,
        /// <summary>
        /// 32-bit number
        /// </summary>
        DWord = 4u,
        /// <summary>
        /// 32-bit number (same as <see cref="DWord"/>)
        /// </summary>
        DWordLittleEndian = DWord,
        /// <summary>
        /// 32-bit number
        /// </summary>
        DWordBigEndian = 5u,
        /// <summary>
        /// Symbolic Link (unicode)
        /// </summary>
        Link = 6u,
        /// <summary>
        /// Multiple Unicode strings
        /// </summary>
        MultiString = 7u,
        /// <summary>
        /// Resource list in the resource map
        /// </summary>
        ResourceList = 8u,
        /// <summary>
        /// Resource list in the hardware description
        /// </summary>
        FullResourceDescriptor = 9u,
        ResourceRequirementsList = 10u,
        /// <summary>
        /// 64-bit number
        /// </summary>
        QWord = 11u,
        /// <summary>
        /// 64-bit number (same as <see cref="QWord"/>)
        /// </summary>
        QWordLittleEndian = QWord

    }

}