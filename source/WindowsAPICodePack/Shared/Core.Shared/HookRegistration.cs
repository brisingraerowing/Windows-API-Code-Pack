using System;

namespace Microsoft.WindowsAPICodePack
{
#if WAPICP3
    public struct HookRegistration
    {
        public Action<HwndSourceHook> AddHook
        {
            get;
#if CS9
            init;
#endif
        }

        public Action<HwndSourceHook> RemoveHook
        {
            get;
#if CS9
            init;
#endif
        }

        public HookRegistration(in Action<HwndSourceHook> addHook, in Action<HwndSourceHook> removeHook)
        {
            AddHook = addHook;

            RemoveHook = removeHook;
        }

        public bool Validate() => AddHook != null && RemoveHook != null;
    }
#endif
}
