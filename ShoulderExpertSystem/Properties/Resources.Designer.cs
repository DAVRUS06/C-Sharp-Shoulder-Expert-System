﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ShoulderExpertSystem.Properties {
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
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("ShoulderExpertSystem.Properties.Resources", typeof(Resources).Assembly);
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
        ///   Looks up a localized string similar to {
        ///  &quot;numberofrules&quot;: 11,
        ///  &quot;systemname&quot;: &quot;Shoulder Problems Expert System&quot;,
        ///  &quot;rules&quot;: [
        ///    {
        ///      &quot;ruleid&quot;: 1,
        ///      &quot;nextruleid&quot;: 2,
        ///      &quot;question&quot;: &quot;Did you hit, injure or fall on your upper arm or shoulder recently?&quot;,
        ///      &quot;diagnosis&quot;: &quot;Your SHOULDER may be or may have been DISLOCATED.&quot;,
        ///      &quot;selfcare&quot;: &quot;See your doctor right away.&quot;
        ///    },
        ///    {
        ///      &quot;ruleid&quot;: 2,
        ///      &quot;nextruleid&quot;: 3,
        ///      &quot;question&quot;: &quot;Is your upper arm swollen or misshaped?&quot;,
        ///      &quot;diagnosis&quot;: &quot;Your HUMERUS (u [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string rules {
            get {
                return ResourceManager.GetString("rules", resourceCulture);
            }
        }
    }
}
