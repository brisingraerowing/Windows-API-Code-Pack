//Copyright (c) Microsoft Corporation.  All rights reserved.  Distributed under the Microsoft Public License (MS-PL)

using System;

namespace Microsoft.WindowsAPICodePack.ExtendedLinguisticServices
{

    /// <summary>
    /// A <see cref="MappingAsyncResult">MappingAsyncResult</see> subclass to be used only for asynchronous calls to text recognition.
    /// <seealso cref="MappingService.BeginDoAction">MappingService.BeginDoAction</seealso>
    /// </summary>
    public class MappingRecognizeAsyncResult : MappingAsyncResult
    {
        internal MappingRecognizeAsyncResult(
            in object callerData,
            in AsyncCallback asyncCallback,
            in string text,
            in int length,
            in int index,
            in MappingOptions options)
            : base(callerData, asyncCallback)
        {
            Text = text;
            Length = length;
            Index = index;
            Options = options;
        }

        /// <summary>
        /// Gets the text parameter for MappingService.RecognizeText or MappingService.BeginRecognizeText.
        /// </summary>        
        public string Text { get; private set; }

        /// <summary>
        /// Gets the length parameter for MappingService.RecognizeText or MappingService.BeginRecognizeText.
        /// </summary>        
        public int Length { get; private set; }

        /// <summary>
        /// Gets the index parameter for MappingService.RecognizeText or MappingService.BeginRecognizeText.
        /// </summary>        
        public int Index { get; private set; }

        /// <summary>
        /// Gets the options parameter for MappingService.RecognizeText or MappingService.BeginRecognizeText.
        /// </summary>        
        public MappingOptions Options { get; private set; }
    }

}
