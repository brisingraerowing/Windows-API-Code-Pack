//Copyright (c) Microsoft Corporation.  All rights reserved.  Distributed under the Microsoft Public License (MS-PL)

using Microsoft.WindowsAPICodePack.Win32Native.ExtendedLinguisticServices;

using System;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Threading;

using Win32NativeInteropTools = Microsoft.WindowsAPICodePack.Win32Native.InteropTools;

namespace Microsoft.WindowsAPICodePack.ExtendedLinguisticServices
{

    /// <summary>
    /// Contains the text recognition data properties retrieved by MappingService.RecognizeText or
    /// MappingService.BeginRecognizeText.
    /// </summary>
    public class MappingPropertyBag : CriticalFinalizerObject, IDisposable
    {
        internal Win32PropertyBag _win32PropertyBag;
        internal IntPtr _options = IntPtr.Zero;
        internal GCHandle _text;
        private readonly ServiceCache _serviceCache;
        private int _isFinalized;

        internal MappingPropertyBag(MappingOptions options, string text)
        {
            if (!(_serviceCache = ServiceCache.Instance).RegisterResource())

                throw new LinguisticException();

            _win32PropertyBag._size = InteropTools.SizeOfWin32PropertyBag;

            if (options != null)

                _options = Win32NativeInteropTools.Pack(ref options._win32Options);

            _text = GCHandle.Alloc(text, GCHandleType.Pinned);
        }

        /// <summary>
        /// Frees all unmanaged resources allocated for the property bag, if needed.
        /// </summary>
        ~MappingPropertyBag()
        {
            Dispose(false);
        }

        /// <summary>
        /// An array of <see cref="MappingDataRange">MappingDataRange</see> objects containing all recognized text range results. This member is populated
        /// by MappingService.RecognizeText or asynchronously with
        /// MappingService.BeginRecognizeText.
        /// </summary>
        public MappingDataRange[] GetResultRanges()
        {
            var result = new MappingDataRange[_win32PropertyBag._rangesCount];
            for (int i = 0; i < result.Length; ++i)
            {
                result[i] = new MappingDataRange
                {
                    _win32DataRange = Win32NativeInteropTools.Unpack<Win32DataRange>(
                    (IntPtr)((ulong)_win32PropertyBag._ranges + ((ulong)i * InteropTools.SizeOfWin32DataRange)))
                };
            }
            return result;
        }

        /// <summary>
        /// Formats the low-level data contained in this <see cref="MappingPropertyBag">MappingPropertyBag</see> using an implementation of the
        /// <see cref="IMappingFormatter{T}">IMappingFormatter</see> interface.
        /// </summary>
        /// <typeparam name="T">The type with which <see cref="IMappingFormatter{T}">IMappingFormatter</see> is parameterized.</typeparam>
        /// <param name="formatter">The formatter to be used in the formatting.</param>
        /// <returns></returns>
        public T[] FormatData<T>(in IMappingFormatter<T> formatter) => (formatter ?? throw new ArgumentNullException(nameof(formatter))).FormatAll(this);

        private bool DisposeInternal()
        {
            if (_win32PropertyBag._context == IntPtr.Zero)

                return true;

            uint hResult = ExtendedLinguisticServicesNativeMethods.MappingFreePropertyBag(ref _win32PropertyBag);

            return hResult == 0 ? true : throw new LinguisticException(hResult);
        }

        /// <summary>
        /// Frees all unmanaged resources allocated for the property bag.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Clean up both managed and native resources.
        /// </summary>
        /// <param name="disposed"></param>
        protected virtual void Dispose(in bool disposed)
        {
            if (Interlocked.CompareExchange(ref _isFinalized, 0, 0) == 0 && DisposeInternal())
            {
                _serviceCache.UnregisterResource();
                Win32NativeInteropTools.Free<Win32Options>(ref _options);
                _text.Free();
                _ = Interlocked.CompareExchange(ref _isFinalized, 1, 0);
            }
        }
    }
}
