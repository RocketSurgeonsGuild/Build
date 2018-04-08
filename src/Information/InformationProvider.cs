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
        private readonly IReadOnlyDictionary<string, string[]> _results;

        public InformationProvider(Assembly assembly)
        {
            var value =  assembly
                    .GetCustomAttributes<AssemblyMetadataAttribute>()
                    .GroupBy(x => x.Key, StringComparer.OrdinalIgnoreCase)
                    .ToDictionary(
                        x => x.Key,
                        x => x.Select(z => z.Value).ToArray()
                    );
            _results = new ReadOnlyDictionary<string, string[]>(value);
        }

        public string[] GetValue(string key)
        {
            _results.TryGetValue(key, out var result);
            return result ?? new string[0];
        }

        public bool HasPrefix(string key)
        {
            return _results.Keys.Any(z => z.StartsWith(key, StringComparison.OrdinalIgnoreCase));
        }
    }
}
