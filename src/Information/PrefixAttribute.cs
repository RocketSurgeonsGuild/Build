using System;

namespace Rocket.Surgery.Build.Information
{
    /// <summary>
    /// Class PrefixAttribute.
    /// Implements the <see cref="System.Attribute" />
    /// </summary>
    /// <seealso cref="System.Attribute" />
    [AttributeUsage(AttributeTargets.Property)]
    class PrefixAttribute : Attribute
    {
        /// <summary>
        /// Gets the key.
        /// </summary>
        /// <value>The key.</value>
        public string Key { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PrefixAttribute"/> class.
        /// </summary>
        /// <param name="key">The key.</param>
        public PrefixAttribute(string key)
        {
            Key = key;
        }
    }
}
