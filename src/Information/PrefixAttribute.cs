using System;

namespace Rocket.Surgery.Build.Information
{
    [AttributeUsage(AttributeTargets.Property)]
    class PrefixAttribute : Attribute
    {
        public string Key { get; }

        public PrefixAttribute(string key)
        {
            Key = key;
        }
    }
}