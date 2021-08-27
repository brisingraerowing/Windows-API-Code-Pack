Windows-API-Code-Pack
=====================

README
======

License
-------

See [LICENSE](https://github.com/pierresprim/Windows-API-Code-Pack/blob/master/LICENSE) for the original license (retrieved from [WebArchive](http://web.archive.org/web/20130717101016/http://archive.msdn.microsoft.com/WindowsAPICodePack/Project/License.aspx)). The library is not developed anymore by Microsoft and seems to have been left as 'free to use'. A clarification or update about the license terms from Microsoft is welcome, however.

Release notes
-------------

Be careful! This is the preview 3.x branch.

See [CHANGELOG](https://github.com/pierresprim/Windows-API-Code-Pack/blob/master/CHANGELOG.md) for latest changes.

Contributing
------------

Any contributor to this project has to read [this code of conduct](https://github.com/pierresprim/Windows-API-Code-Pack/blob/master/CODE_OF_CONDUCT.md) before contributing and has to follow the rules described in it for any contribution to this project.

Bugs
----

When you submit a bug:

 - provide a short example code showing the bug
 - describe the expected behavior/result

Usage notes
-----------

This assembly/package provides code that can be used directly and also code that can be used in other packages to implement property systems features.

**TaskDialog**

If you get the following exception when you instantiate a `TaskDialog`:

```
An unhandled exception of type 'System.NotSupportedException' occurred in Microsoft.WindowsAPICodePack.dll

Additional information: TaskDialog feature needs to load version 6 of comctl32.dll but a different version is current loaded in memory.
```

To fix it, create an application manifest and un-comment the following block section:

```
  <!-- Enable themes for Windows common controls and dialogs (Windows XP and later) -->
  <!-- <dependency>
    <dependentAssembly>
      <assemblyIdentity
          type="win32"
          name="Microsoft.Windows.Common-Controls"
          version="6.0.0.0"
          processorArchitecture="*"
          publicKeyToken="6595b64144ccf1df"
          language="*"
        />
    </dependentAssembly>
  </dependency>-->
```

Note: you might have to restart Visual Studio as the DLLs seems to be cached in memory and rebuilding your project doesn't seem to be enough in some cases.
