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

        /// <summary>
        /// Initializes a new instance of the <see cref="InformationProvider"/> class.
        /// </summary>
        /// <param name="assembly">The assembly.</param>
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

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>System.String[].</returns>
        public IEnumerable<string> GetValue(string key)
        {
            _results.TryGetValue(key, out var result);
            return result ?? Array.Empty<string>();
        }

        /// <summary>
        /// Determines whether the specified key has prefix.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns><c>true</c> if the specified key has prefix; otherwise, <c>false</c>.</returns>
        public bool HasPrefix(string key)
        {
            return _results.Keys.Any(z => z.StartsWith(key, StringComparison.OrdinalIgnoreCase));
        }
    }
}
