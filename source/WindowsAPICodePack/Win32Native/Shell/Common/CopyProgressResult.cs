namespace Microsoft.WindowsAPICodePack.Shell
{
    /// <summary>
    /// The result that is returned by the <see cref="CopyProgressRoutine"/> function.
    /// </summary>
    public enum CopyProgressResult : uint
    {
        /// <summary>
        /// Continue the copy operation.
        /// </summary>
        Continue = 0,

        /// <summary>
        /// Cancel the copy operation and delete the destination file.
        /// </summary>
        Cancel = 1,

        /// <summary>
        /// Stop the copy operation. It can be restarted at a later time.
        /// </summary>
        Stop = 2,

        /// <summary>
        /// Continue the copy operation, but stop invoking CopyProgressRoutine to report progress.
        /// </summary>
        Quiet = 3
    }
}
