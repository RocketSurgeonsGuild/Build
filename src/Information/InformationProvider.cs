using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;

namespace Rocket.Surgery.Build.Information
{
    /// <summary>
    /// An information provider to pull assembly data out of the assembly
    /// </summary>
    public class InformationProvider
    {
        private readonly IReadOnlyDictionary<string, string> _results;

        public InformationProvider(Assembly assembly)
        {
            _results = new ReadOnlyDictionary<string, string>( new Dictionary<string, string>(
                assembly
                    .GetCustomAttributes()
                    .Where(x => x.GetType().Name == nameof(AssemblyDataAttribute))
                    .Select(x =>
                    {
                        var type = x.GetType().GetTypeInfo();
                        return new KeyValuePair<string, string>(type.GetDeclaredProperty("Key").GetValue(x) as string,type.GetDeclaredProperty("Value").GetValue(x) as string);
                    })
                    .ToDictionary(
                        x => x.Key,
                        x => x.Value,
                        StringComparer.OrdinalIgnoreCase
                    )));
        }

        public string GetValue(string key)
        {
            _results.TryGetValue(key, out var result);
            return result;
        }

        public bool HasPrefix(string key)
        {
            return _results.Keys.Any(z => z.StartsWith(key, StringComparison.OrdinalIgnoreCase));
        }
    }
}
