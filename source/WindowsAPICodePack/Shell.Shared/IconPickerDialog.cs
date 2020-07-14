using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Windows.Forms;
using static Microsoft.WindowsAPICodePack.NativeAPI.Consts.Shell;

namespace Microsoft.WindowsAPICodePack.Shell
{
    public class IconPickerDialog : CommonDialog
    {

        [DefaultValue(default(string))]
        public string FileName { get; set; }

        [DefaultValue(0)]
        public int IconIndex { get; set; }

        protected override bool RunDialog(IntPtr hwndOwner)
        {
            var buf = new StringBuilder(FileName, MaxPath);

            bool ok = Win32Native.Shell.Shell.SHPickIconDialog(hwndOwner, buf, MaxPath, out int index);

            if (ok)
            {
                FileName = Environment.ExpandEnvironmentVariables(buf.ToString());
                IconIndex = index;
            }

            return ok;
        }

        public override void Reset()
        {
            FileName = null;
            IconIndex = 0;
        }
    }
}
