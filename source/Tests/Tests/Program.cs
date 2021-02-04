/* Copyright © Pierre Sprimont, 2020
 *
 * This file is part of the Windows API Code Pack.
 *
 * The WinCopies Framework is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * The WinCopies Framework is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with the WinCopies Framework.  If not, see <https://www.gnu.org/licenses/>. */

using Microsoft.WindowsAPICodePack.PortableDevices;
using Microsoft.WindowsAPICodePack.Win32Native;

using System;
using System.IO;

using WinCopies.Collections.Generic;

namespace PortableDeviceTests
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            using var portableDeviceManager = new PortableDeviceManager();

            portableDeviceManager.GetDevices();

            int i;

            for (i = 0; i < portableDeviceManager.PortableDevices.Count; i++)

                Console.WriteLine($"{i}: {portableDeviceManager.PortableDevices[i].DeviceFriendlyName}");

            Console.WriteLine("Please choose a device.");

            if (uint.TryParse(Console.ReadLine(), out uint uintResult) && uintResult < i)
            {
                IPortableDevice portableDevice = portableDeviceManager.PortableDevices[(int)uintResult];

                portableDevice.Open(new ClientVersion("PortableDeviceTests", 1, 0, 0), new PortableDeviceOpeningOptions(GenericRights.Read | GenericRights.Write, FileShareOptions.Read | FileShareOptions.Write, false));

                i = 0;

                var b = new ArrayBuilder<IPortableDeviceObject>();

                foreach (IPortableDeviceObject portableDeviceObject in portableDevice)
                {
                    if (portableDeviceObject.Type == new Guid(Microsoft.WindowsAPICodePack.PortableDevices.Guids.PropertySystem.ContentType.FunctionalObject))
                    {
                        _ = b.AddLast(portableDeviceObject);

                        Console.WriteLine($"{i++}: {portableDeviceObject.Name}");
                    }
                }

                Console.WriteLine("Please enter a memory id.");

                if (uint.TryParse(Console.ReadLine(), out uintResult) && uintResult < i)
                {
                    i = 0;

                    var enumerable = (IEnumerablePortableDeviceObject)b.ToArray()[(int)uintResult];

                    b.Clear();

                    foreach (IPortableDeviceObject portableDeviceObject in enumerable)

                        if (portableDeviceObject is IPortableDeviceFolder folder)
                        {
                            _ = b.AddLast(folder);

                            Console.WriteLine($"{i++}: {folder.Name}");
                        }

                    Console.WriteLine("Enter the id of the action to perform on the device.");
                    Console.WriteLine("0: Transfer content.");
                    Console.WriteLine("1: Delete content.");

                    string _menuId = Console.ReadLine();

                    if (int.TryParse(_menuId, out int menuId))
                    {
                        if (menuId == 0)
                        {
                            Console.WriteLine("Please enter the id of the folder to copy the file to.");

                            if (uint.TryParse(Console.ReadLine(), out uintResult) && uintResult < i)
                            {
                                var _folder = (IPortableDeviceFolder)b.ToArray()[(int)uintResult];

                                b.Clear();

                                Console.WriteLine("Please enter a file to copy to the portable device.");

                                string path = Console.ReadLine();

                                Console.WriteLine("Enter the file content type GUID.");

                                string contentType = Console.ReadLine();

                                if (Guid.TryParse(contentType, out Guid guidContentType))
                                {
                                    Console.WriteLine("Enter the file format GUID.");

                                    string format = Console.ReadLine();

                                    if (Guid.TryParse(format, out Guid guidFormat))
                                    {
                                        var stream = new FileStream(path, FileMode.Open);

                                        uint totalWritten = 0;

                                        _folder.PortableDeviceObjectAdded += PortableDevice_PortableDeviceObjectAdded;

                                        _folder.TransferTo(stream, 4000, false, guidContentType, guidFormat, written =>
                                        {
                                            Console.WriteLine($"{written} bytes written during the last write operation; {(totalWritten += written)} total. Continue (Y/y: yes; other input: no)?");

                                            return true; // Console.ReadLine().ToUpper() == "Y"
                                        });
                                    }
                                }

                                i = 0;

                                foreach (IPortableDeviceObject file in _folder)
                                {
                                    if (file is IPortableDeviceFile _file)
                                    {
                                        _ = b.AddLast(_file);

                                        Console.WriteLine($"{i++}: {_file.Name}");
                                    }
                                }

                                if (uint.TryParse(Console.ReadLine(), out uintResult) && uintResult < i)
                                {
                                    var portableDeviceFile = (IPortableDeviceFile)b.ToArray()[(int)uintResult];

                                    b.Clear();

                                    Console.WriteLine("Please enter a destination file.");

                                    path = Console.ReadLine();

                                    path = $"{System.IO.Path.GetDirectoryName(path)}\\{Path.GetFileNameWithoutExtension(path)} - Copy{Path.GetExtension(path)}";

                                    uint totalWritten = 0;

                                    var stream = new FileStream(path, FileMode.CreateNew);

                                    portableDeviceFile.TransferFrom(stream, 4000, false, written =>
                                    {
                                        Console.WriteLine($"Written: {written}; total: {(totalWritten += written)}.");

                                        return true;
                                    });

                                    stream.Flush();

                                    stream.Dispose();
                                }
                            }
                        }

                        else if (menuId == 1)
                        {
                            Console.WriteLine("Please enter the id of the folder of the file to delete.");

                            if (uint.TryParse(Console.ReadLine(), out uintResult) && uintResult < i)
                            {
                                var _folder = (IPortableDeviceFolder)b.ToArray()[(int)uintResult];

                                b.Clear();

                                if (_folder.Count == 1)
                                {
                                    if (_folder[0] is IPortableDeviceFile item)
                                    {
                                        _folder.PortableDeviceObjectRemoved += PortableDevice_PortableDeviceObjectRemoved;

                                        item.Delete();
                                    }

                                    else

                                        Console.WriteLine("The folder of the given id does not contain a file.");
                                }

                                else

                                    Console.WriteLine("The folder of the given id is empty or contains more than one file.");
                            }
                        }

                        else Console.WriteLine("Incorrect menu id.");
                    }

                    else Console.WriteLine("Incorrect menu id.");
                }
            }

            else

                Console.WriteLine("Incorrect device id.");
        }

        private static void PortableDevice_PortableDeviceObjectAdded(object sender, PortableDeviceObjectEventArgs e) => Console.WriteLine(e.PortableDeviceObject.Path+" added.");

        private static void PortableDevice_PortableDeviceObjectRemoved(object sender, PortableDeviceObjectEventArgs e) => Console.WriteLine(e.PortableDeviceObject.Path + " removed.");
    }
}
