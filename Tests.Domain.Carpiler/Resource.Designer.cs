﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Tests.Domain.Carpiler {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resource {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resource() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Tests.Domain.Carpiler.Resource", typeof(Resource).Assembly);
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
        ///   Looks up a localized string similar to bool expressao = 10 &lt;= 5;.
        /// </summary>
        internal static string BoolDeclaration {
            get {
                return ResourceManager.GetString("BoolDeclaration", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to return true;.
        /// </summary>
        internal static string ReturnTrue {
            get {
                return ResourceManager.GetString("ReturnTrue", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to string letras = &quot;string&quot;;.
        /// </summary>
        internal static string StringDeclaration {
            get {
                return ResourceManager.GetString("StringDeclaration", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to int [] array = new int[10];
        ///int i = 0;
        ///while(i &lt; 10)
        ///{
        ///	print(array[i]);
        ///	i = i +1;
        ///}.
        /// </summary>
        internal static string WhileOverArray {
            get {
                return ResourceManager.GetString("WhileOverArray", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to int i = 0;
        ///while(i&lt;20)
        ///{
        ///     print(i);
        ///}.
        /// </summary>
        internal static string WhilePrint {
            get {
                return ResourceManager.GetString("WhilePrint", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to while(true)
        ///{
        ///
        ///}.
        /// </summary>
        internal static string WhileTrue {
            get {
                return ResourceManager.GetString("WhileTrue", resourceCulture);
            }
        }
    }
}
