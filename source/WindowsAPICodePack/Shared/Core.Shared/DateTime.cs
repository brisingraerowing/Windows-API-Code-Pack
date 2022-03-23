using System;

namespace Microsoft.WindowsAPICodePack
{
    public struct DateTime
    {
        public long? _innerValue;

        public System.DateTime? Local => TryGetDateTime(System.DateTime.FromFileTime);

        public System.DateTime? UTC => TryGetDateTime(System.DateTime.FromFileTimeUtc);

        public DateTime(in long? value) => _innerValue = value;

        private System.DateTime? TryGetDateTime(Converter<long, System.DateTime> converter) => _innerValue.HasValue ?
#if !CS9
            (System.DateTime?)
#endif
            converter(_innerValue.Value) : null;
    }
}
