// Copyright (c) Microsoft Corporation.  All rights reserved.

using System;
using System.Threading;

namespace Microsoft.WindowsAPICodePack.ExtendedLinguisticServices
{

    /// <summary>
    /// <see cref="System.IAsyncResult">IAsyncResult</see> implementation for use with asynchronous calls to ELS.
    /// </summary>
    public class MappingAsyncResult : IAsyncResult, IDisposable
    {
        private MappingResultState _resultState;
        private ManualResetEvent _waitHandle;

        internal MappingAsyncResult(
            object callerData,
            AsyncCallback asyncCallback)
        {
            CallerData = callerData;
            AsyncCallback = asyncCallback;
            _waitHandle = new ManualResetEvent(false);
        }

        internal AsyncCallback AsyncCallback { get; }

        /// <summary>
        /// Queries whether the operation completed successfully.
        /// </summary>
        public bool Succeeded => PropertyBag != null && _resultState.HResult == 0;

        /// <summary>
        /// Gets the resulting <see cref="MappingPropertyBag">MappingPropertyBag</see> (if it exists).
        /// </summary>
        public MappingPropertyBag PropertyBag { get; private set; }

        /// <summary>
        /// Returns the current result state associated with this operation.
        /// </summary>
        public MappingResultState ResultState => _resultState;

        /// <summary>
        /// Returns the caller data associated with this operation.
        /// </summary>
        public object CallerData { get; }

        internal void SetResult(MappingPropertyBag bag, MappingResultState resultState)
        {
            _resultState = resultState;
            PropertyBag = bag;
        }

        #region IAsyncResult Members

        // returns MappingResultState
        /// <summary>
        /// Returns the result state.
        /// </summary>
        public object AsyncState => ResultState;

        /// <summary>
        /// Gets the WaitHandle which will be notified when
        /// the opration completes (successfully or not).
        /// </summary>
        public WaitHandle AsyncWaitHandle => _waitHandle;

        /// <summary>
        /// From MSDN:
        /// Most implementers of the IAsyncResult interface
        /// will not use this property and should return false.
        /// </summary>
        public bool CompletedSynchronously => false;

        /// <summary>
        /// Queries whether the operation has completed.
        /// </summary>
        public bool IsCompleted
        {
            get
            {
                Thread.MemoryBarrier();
                return AsyncWaitHandle.WaitOne(0, false);
            }
        }

        #endregion

        #region IDisposable Members

        /// <summary>
        /// Dispose the MappingAsyncresult
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Dispose the MappingAsyncresult
        /// </summary>
        protected virtual void Dispose(bool disposed)
        {
            if (disposed)

                _waitHandle.Close();
        }

        #endregion
    }

}
