﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Planet.Domain.Resources.ValidationResources {
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
    public class ValidationMessages {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal ValidationMessages() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Planet.Domain.Resources.ValidationResources.ValidationMessages", typeof(ValidationMessages).Assembly);
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
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to E-Posta adresi geçerli değildir..
        /// </summary>
        public static string Email_Invalid {
            get {
                return ResourceManager.GetString("Email_Invalid", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to E-Posta uzunluğu belirtilen aralıkta değil. (Minimum: {0}, Maksimum: {1}).
        /// </summary>
        public static string Email_InvalidLength {
            get {
                return ResourceManager.GetString("Email_InvalidLength", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to E-Posta adresi boş olamaz..
        /// </summary>
        public static string Email_NullOrWhiteSpace {
            get {
                return ResourceManager.GetString("Email_NullOrWhiteSpace", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to İsim uzunluğu belirtilen aralıkta değil. (Minimum: {0}, Maksimum: {1}).
        /// </summary>
        public static string FirstName_InvalidLength {
            get {
                return ResourceManager.GetString("FirstName_InvalidLength", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to İsim boş olamaz..
        /// </summary>
        public static string FirstName_NullOrWhiteSpace {
            get {
                return ResourceManager.GetString("FirstName_NullOrWhiteSpace", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Soyisim uzunluğu belirtilen aralıkta değil. (Minimum: {0}, Maksimum: {1}).
        /// </summary>
        public static string LastName_InvalidLength {
            get {
                return ResourceManager.GetString("LastName_InvalidLength", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Soyisim boş olamaz..
        /// </summary>
        public static string LastName_NullOrWhiteSpace {
            get {
                return ResourceManager.GetString("LastName_NullOrWhiteSpace", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Şifreler eşleşmiyor..
        /// </summary>
        public static string Password_NotMatch {
            get {
                return ResourceManager.GetString("Password_NotMatch", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Şifre boş olamaz..
        /// </summary>
        public static string Password_NullOrWhiteSpace {
            get {
                return ResourceManager.GetString("Password_NullOrWhiteSpace", resourceCulture);
            }
        }
    }
}
