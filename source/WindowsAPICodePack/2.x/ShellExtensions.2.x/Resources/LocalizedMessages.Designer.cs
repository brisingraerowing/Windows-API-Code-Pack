﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Microsoft.WindowsAPICodePack.ShellExtensions.Resources {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class LocalizedMessages {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal LocalizedMessages() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Microsoft.WindowsAPICodePack.ShellExtensions.Resources.LocalizedMessages", typeof(LocalizedMessages).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Control has not yet been assigned. Methods requiring it cannot be called..
        /// </summary>
        internal static string PreviewHandlerControlNotInitialized {
            get {
                return ResourceManager.GetString("PreviewHandlerControlNotInitialized", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0} must implement one or more of IPreviewFromStream, IPreviewFromShellObject or IPreviewFromFile..
        /// </summary>
        internal static string PreviewHandlerInterfaceNotImplemented {
            get {
                return ResourceManager.GetString("PreviewHandlerInterfaceNotImplemented", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to PreviewHandler &apos;{0}&apos; must have exactly one PreviewHandler attribute..
        /// </summary>
        internal static string PreviewHandlerInvalidAttributes {
            get {
                return ResourceManager.GetString("PreviewHandlerInvalidAttributes", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unable to call interface {0} because it is not supported on this object..
        /// </summary>
        internal static string PreviewHandlerUnsupportedInterfaceCalled {
            get {
                return ResourceManager.GetString("PreviewHandlerUnsupportedInterfaceCalled", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The sum of offset and count must be less than or equal to the size of the buffer..
        /// </summary>
        internal static string StorageStreamBufferOverflow {
            get {
                return ResourceManager.GetString("StorageStreamBufferOverflow", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Count must be greater than or equal to zero..
        /// </summary>
        internal static string StorageStreamCountLessThanZero {
            get {
                return ResourceManager.GetString("StorageStreamCountLessThanZero", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The stream was initialized as read-only..
        /// </summary>
        internal static string StorageStreamIsReadonly {
            get {
                return ResourceManager.GetString("StorageStreamIsReadonly", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Offset must be greater than or equal to zero..
        /// </summary>
        internal static string StorageStreamOffsetLessThanZero {
            get {
                return ResourceManager.GetString("StorageStreamOffsetLessThanZero", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0} does not implement IThumbnailFromStream and so requires DisableProcessIsolation set to true..
        /// </summary>
        internal static string ThumbnailProviderDisabledProcessIsolation {
            get {
                return ResourceManager.GetString("ThumbnailProviderDisabledProcessIsolation", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0} must implement one or more of IThumbnailFromStream, IThumbnailFromShellObject or IThumbnailFromFile..
        /// </summary>
        internal static string ThumbnailProviderInterfaceNotImplemented {
            get {
                return ResourceManager.GetString("ThumbnailProviderInterfaceNotImplemented", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cannot retrieve handle because proxy window has not been created..
        /// </summary>
        internal static string WpfPreviewHandlerNoHandle {
            get {
                return ResourceManager.GetString("WpfPreviewHandlerNoHandle", resourceCulture);
            }
        }
    }
}
