#if CS7
using Microsoft.WindowsAPICodePack.Win32Native.Shell;

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Microsoft.WindowsAPICodePack.Dialogs
{
    public class IconPickerDialog
    {
        protected IntPtr OwnerWindowPtr { get; }

        public Color[] Colors { get; } = new Color[16];

        public IconPickerDialog(in IntPtr ownerWindowPtr, in IReadOnlyList<Color> colors)
        {
            OwnerWindowPtr = ownerWindowPtr;

            for (byte i = 0; i < 16; i++)

                Colors[i] = colors[i];
        }

        public IconPickerDialog(in IntPtr ownerWindowPtr) : this(ownerWindowPtr, GetColors()) { /* Left empty. */ }

        public static Color[] GetColors()
        {
            var colors = new Color[16];

            for (byte i = 0; i < 16; i++)

                colors[i] = new Color(255, 255, 255);

            return colors;
        }

        public unsafe Color? ShowDialog()
        {
            uint[] array = new uint[16];
            uint b;
            Color[] colors = Colors;
            Color color;

            for (byte i = 0; i < 16; i++)
            {
                b = (color = colors[i]).B;
                b <<= 8;
                b |= color.G;
                b <<= 8;
                b |= color.R;

                array[i] = b;
            }

            fixed (uint* ptr = array)
            {
                var chooseColor = new ChooseColor
                {
                    hwndOwner = OwnerWindowPtr,
                    lpCustColors = ptr,
                    Flags = ChooseColorFlags.FullOpen | ChooseColorFlags.RGBInit,
                    lStructSize = (uint)Marshal.SizeOf<ChooseColor>()
                };

                bool value = Win32Native.Shell.Shell.ChooseColorW(ref chooseColor);

#if CS8
                static
#endif
                    Color getColor(in uint _color)
                {
                    byte[] bytes = BitConverter.GetBytes(_color);

                    return new Color(bytes[0], bytes[1], bytes[2]);
                }

                for (byte i = 0; i < 16; i++)

                    colors[i] = getColor(array[i]);

                return value ? getColor(chooseColor.rgbResult) :
#if !CS9
                    (Color?)
#endif
                    null;
            }
        }
    }
}
#endif
