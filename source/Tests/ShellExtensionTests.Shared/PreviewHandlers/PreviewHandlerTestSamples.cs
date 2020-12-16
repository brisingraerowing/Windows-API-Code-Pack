using Microsoft.WindowsAPICodePack.ShellExtensions;

using ShellExtensionTests;

namespace Tests.ShellExtensions.PreviewHandlers
{
    public class WinformsPreviewHandlerTestSample : WinFormsPreviewHandler, IPreviewFromStream
    {
        public WinformsPreviewHandlerTestSample() => Control = new WinFormsPreviewHandlerSampleForm();

        #region IPreviewFromStream Members

        public void Load(in System.IO.Stream stream)
        {
            
        }

        #endregion
    }

}
