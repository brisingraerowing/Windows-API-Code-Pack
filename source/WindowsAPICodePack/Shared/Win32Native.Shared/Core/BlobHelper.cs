using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Microsoft.WindowsAPICodePack
{
    public static class BlobHelper
    {

        public static object ToDotNetType(byte[] array, BlobValueKind valueKind, bool doNotExpand)

        {

            if (array is null) throw new ArgumentNullException(nameof(array));

            string toString()

            {

                if (array.Length % 2 == 1)

                    // todo: add a byte to the array to re-load the array from the source instead of throwing an exception

                    // if (array.Length < int.MaxValue)

                    // length++;

                    throw new IOException("The given array does not have a valid length. Maybe corrupt data ?");

                // else throw new IOException("The IO operation cannot complete because of a memory overflow.");

                unsafe
                {
                    fixed (byte* b = &array[0])
                    {

                        return array.Length > 1 && BitConverter.ToChar(new byte[] {

                        #if CS8
                            
                            array[^2], array[^1]
                            
#else
                        
                        array[array.Length - 2], array[array.Length - 1]

#endif
                        
                        }, 0) == (char)0
                            ? new string((char*)b, 0, (array.Length / 2) - 1)
                            : new string((char*)b);

                    }

                }

            }

            switch (valueKind)

            {

                case BlobValueKind.None:
                case BlobValueKind.DWordBigEndian:
                case BlobValueKind.Binary:

                    return array;

                case BlobValueKind.QWord:
                    // same as: case RegistryValueKind.QWordLittleEndian:

                    if (array.Length > 8) goto case BlobValueKind.Binary;

                    return BitConverter.ToInt64(array, 0);

                case BlobValueKind.DWord:
                    // same as: case RegistryValueKind.DWordLittleEndian:

                    if (array.Length > 4) goto case BlobValueKind.QWord;

                    return BitConverter.ToInt32(array, 0);

                case BlobValueKind.String:

                    return toString();

                case BlobValueKind.ExpandString:

                    return !doNotExpand ? Environment.ExpandEnvironmentVariables(toString()) : toString();

                case BlobValueKind.MultiString:

                    return toString().Split('\0');

                default:

                    return array;

            }

        }

    }
}
