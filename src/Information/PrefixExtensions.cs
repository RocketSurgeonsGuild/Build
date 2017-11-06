using System;
using System.Reflection;

namespace Rocket.Surgery.Build.Information
{
    static class PrefixExtensions
    {
        internal static void Infer<T>(this InformationProvider provider, T instance)
        {
            foreach (var property in instance.GetType().GetTypeInfo().DeclaredProperties)
            {
                // simple props only
                if (
                    property.PropertyType.GetTypeInfo().IsPrimitive ||
                    property.PropertyType.GetTypeInfo().IsEnum ||
                    property.PropertyType == typeof(string))
                {
                    var prefix = property.GetCustomAttribute<PrefixAttribute>()?.Key ?? string.Empty;
                    var value = provider.GetValue(prefix + property.Name);
                    if (!string.IsNullOrWhiteSpace(value))
                    {
                        property.SetValue(instance, Convert.ChangeType(value, property.PropertyType));
                    }
                }
            }
        }
    }
}
