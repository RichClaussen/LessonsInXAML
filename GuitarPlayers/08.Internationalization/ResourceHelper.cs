// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ResourceHelper.cs" company="">
//   
// </copyright>
// <summary>
//   The resource key attribute.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Globalization;
using System.Reflection;
using System.Resources;

using WelchAllyn.Core.Properties;

namespace WelchAllyn.Core.Localization
{
    /// <summary>
    /// The resource key attribute.
    /// </summary>
    [AttributeUsage(AttributeTargets.All, Inherited = true, AllowMultiple = false)]
    public class ResourceKeyAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceKeyAttribute"/> class.
        /// </summary>
        /// <param name="resourceKey">
        /// The resource key.
        /// </param>
        public ResourceKeyAttribute(string resourceKey)
            : this(resourceKey, typeof(Resources))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceKeyAttribute"/> class.
        /// </summary>
        /// <param name="resourceKey">The resource key.</param>
        /// <param name="resourceType">Type of the resource.</param>
        public ResourceKeyAttribute(string resourceKey, Type resourceType)
        {
            this.ResourceKey = resourceKey;
            this.ResourceType = resourceType ?? typeof(Resources);
        }

        /// <summary>
        /// Gets or sets the ResourceKey.
        /// </summary>
        public string ResourceKey { get; set; }

        /// <summary>
        /// Gets the type of the resource.
        /// </summary>
        /// <value>
        /// The type of the resource.
        /// </value>
        public Type ResourceType { get; private set; }
    }

    /// <summary>
    /// The resource helper.
    /// </summary>
    public static class ResourceHelperExtensions
    {
        /// <summary>
        /// Gets the resource key.
        /// </summary>
        /// <param name="value">
        /// The enum value.
        /// </param>
        /// <returns>
        /// The resource key.
        /// </returns>
        public static string GetResourceKey(this Enum value)
        {
            string result = null;

            // Read the description attribute from the enum.
            FieldInfo fieldInfo = value.GetType().GetField(value.ToString());
            var attributes = fieldInfo.GetCustomAttributes(typeof(ResourceKeyAttribute), false) as ResourceKeyAttribute[];

            // Return the attribute, or the enum.ToString();
            if ((attributes != null) && (attributes.Length == 1))
            {
                result = attributes[0].ResourceKey;
            }

            if (string.IsNullOrWhiteSpace(result)) result = value.ToString();

            return result;
        }

        /// <summary>
        /// Gets the resource key.
        /// </summary>
        /// <param name="value">
        /// The enum value.
        /// </param>
        /// <returns>
        /// The resource key.
        /// </returns>
        public static string GetResource(this Enum value)
        {
            string result = null;

            // Read the description attribute from the enum.
            FieldInfo fieldInfo = value.GetType().GetField(value.ToString());
            var attributes = fieldInfo.GetCustomAttributes(typeof(ResourceKeyAttribute), false) as ResourceKeyAttribute[];

            Type resourceType = ((attributes != null) && (attributes.Length == 1)) ? attributes[0].ResourceType : typeof(Resources);

            var resourceManager = resourceType.InvokeMember(
                                      @"ResourceManager",
                                      BindingFlags.GetProperty | BindingFlags.Static |
                                      BindingFlags.Public | BindingFlags.NonPublic,
                                      null,
                                      null,
                                      new object[] { }) as ResourceManager;

            var culture = resourceType.InvokeMember(
                              @"Culture",
                              BindingFlags.GetProperty | BindingFlags.Static |
                              BindingFlags.Public | BindingFlags.NonPublic,
                              null,
                              null,
                              new object[] { }) as CultureInfo;

            string key = value.GetResourceKey();
            if (resourceManager != null) result = resourceManager.GetString(key, culture);
            if (string.IsNullOrWhiteSpace(result)) result = key;

            return result;
        }
    }
}
