﻿using Microsoft.WindowsAPICodePack.Shell;

using System;
using System.IO;
using System.Linq;
using System.Threading;

using Xunit;

namespace Tests
{
    public class ShellObjectWatcherTests
    {
        private const int TimeoutMS = 5000;

        [Fact]
        public void ItemRenamedTest() => TestMethod("ItemRenamed", x => File.Move(x, x + "renamed"), false);

        [Fact]
        public void ItemCreatedTest() => TestMethod("ItemCreated", x => File.WriteAllText(Path.Combine(x, "tempFile"), "This file is created"), true);

        [Fact]
        public void ItemDeletedTest() => TestMethod("ItemDeleted", x => File.Delete(x), false);

        [Fact]
        public void UpdatedTest() => TestMethod("Updated", x => File.WriteAllText(Path.Combine(x, "tempFile"), "contents changed or created"), true);

        [Fact]
        public void DirectoryUpdatedTest() => TestMethod("DirectoryUpdated", x => File.WriteAllText(Path.Combine(x, "tempFile"), "Contents updated"), true);

        [Fact]
        public void DirectoryRenamedTest() => TestMethod("DirectoryRenamed", x => Directory.Move(x, x + "renamed"), true);

        [Fact]
        public void DirectoryCreatedTest() => TestMethod("DirectoryCreated", x => Directory.CreateDirectory(Path.Combine(x, "NewDir")), true);

        [Fact]
        public void DirectoryDeletedTest() => TestMethod("DirectoryDeleted", x => Directory.Delete(Directory.CreateDirectory(Path.Combine(x, "NewDir")).FullName), true);

        [Fact]
        public void MediaInsertedTest() { }
        [Fact]
        public void MediaRemovedTest() { }
        [Fact]
        public void DriveAddedTest() { }
        [Fact]
        public void DriveRemovedTest() { }
        [Fact]
        public void FolderNetworkSharedTest() { }
        [Fact]
        public void FolderNetworkUnsharedTest() { }
        [Fact]
        public void ServerDisconnectedTest() { }

        [Fact]
        public void FreeSpaceChangedTest()
        {
            TestMethod("FreeSpaceChanged", x =>
            {
                byte[] data = new byte[2048];
                new Random().NextBytes(data);
                File.WriteAllBytes(Path.GetTempFileName(), data);
            }, @"C:\");
        }

        [Fact]
        public void FileTypeAssociationChanged() { }

        private void TestMethod(string eventName, Action<string> test, bool folder)
        {
            string path = folder ? CreateTempFolder() : CreateTempFile();
            TestMethod(eventName, test, path);
        }
        private void TestMethod(string eventName, Action<string> test, string path)
        {
            var shellObject = ShellObject.FromParsingName(path);

            using (var evt = new AutoResetEvent(false))
            using (var watcher = new ShellObjectWatcher(shellObject, true))
            {
                bool success = false;

                var successEvent = new Action(() =>
                {
                    success = true;
                    _ = evt.Set();
                });

                var changedHandler = new EventHandler<ShellObjectChangedEventArgs>((sender, args) => successEvent());
                var renamedHandler = new EventHandler<ShellObjectRenamedEventArgs>((sender, args) => successEvent());

                //register for event
                System.Reflection.MethodInfo addMethod = typeof(ShellObjectWatcher)
                .GetEvents()
                .FirstOrDefault(x => x.Name.Equals(eventName, StringComparison.InvariantCultureIgnoreCase))
                .GetAddMethod();

                Type paramType = addMethod.GetParameters()[0].ParameterType
                    .GetGenericArguments()[0];

                if (paramType == typeof(ShellObjectChangedEventArgs))
                
                    addMethod.Invoke(watcher, new object[] { changedHandler });
                
                else if (paramType == typeof(ShellObjectRenamedEventArgs))
                
                    addMethod.Invoke(watcher, new object[] { renamedHandler });
                
                else
                
                    throw new Exception("Unknown handler type.");
                
                //start
                watcher.Start();

                test(path);

                _ = evt.WaitOne(TimeoutMS);

                Assert.True(success);
            }
        }

        private static string CreateTempFile()
        {
            //string path = string.Format("text{0}.txt", DateTime.Now.Millisecond);
            //File.WriteAllText(path, string.Empty);
            //return Path.GetFullPath(path);
            string test = Path.GetTempFileName();
            File.AppendAllText(test, "no longer an empty file");
            return test;
        }

        private static string CreateTempFolder()
        {
            string path = Path.Combine(Path.GetTempPath(), "temp" + DateTime.Now.Millisecond);
            return Directory.CreateDirectory(path).FullName;
        }
    }
}
