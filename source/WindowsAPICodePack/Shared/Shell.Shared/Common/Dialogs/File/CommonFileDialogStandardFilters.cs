//Copyright (c) Microsoft Corporation.  All rights reserved.  Distributed under the Microsoft Public License (MS-PL)

using Microsoft.WindowsAPICodePack.Shell.Resources;

using static Microsoft.WindowsAPICodePack.Shell.Resources.LocalizedMessages;

namespace Microsoft.WindowsAPICodePack.Dialogs
{
    /// <summary>
    /// Defines the class of commonly used file filters.
    /// </summary>
    public static class CommonFileDialogStandardFilters
    {
        private static CommonFileDialogFilter
#if CS8
            ?
#endif
            _textFilesFilter;
        private static CommonFileDialogFilter
#if CS8
            ?
#endif
            _pictureFilesFilter;
        private static CommonFileDialogFilter
#if CS8
            ?
#endif
            _officeFilesFilter;

        /// <summary>
        /// Gets a value that specifies the filter for *.txt files.
        /// </summary>
        public static CommonFileDialogFilter TextFiles => _textFilesFilter
#if CS8
            ??=
#else
            ?? (_textFilesFilter =
#endif
            new CommonFileDialogFilter(CommonFiltersText, "*.txt")
#if !CS8
            )
#endif
            ;

        /// <summary>
        /// Gets a value that specifies the filter for picture files.
        /// </summary>
        public static CommonFileDialogFilter PictureFiles => _pictureFilesFilter
#if CS8
            ??=
#else
            ?? (_pictureFilesFilter =
#endif
            new CommonFileDialogFilter(CommonFiltersPicture,
                        "*.bmp, *.jpg, *.jpeg, *.png, *.ico")
#if !CS8
            )
#endif
            ;

        /// <summary>
        /// Gets a value that specifies the filter for Microsoft Office files.
        /// </summary>
        public static CommonFileDialogFilter OfficeFiles => _officeFilesFilter
#if CS8
            ??=
#else
            ?? (_officeFilesFilter =
#endif
            new CommonFileDialogFilter(CommonFiltersOffice,
                        "*.doc, *.docx, *.xls, *.xlsx, *.ppt, *.pptx")
#if !CS8
            )
#endif
            ;
    }
}
