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
        private readonly ILookup<string, string> _results;

        /// <summary>
        /// Initializes a new instance of the <see cref="InformationProvider"/> class.
        /// </summary>
        /// <param name="assembly">The assembly.</param>
        public InformationProvider(Assembly assembly) =>
            _results = assembly
                .GetCustomAttributes<AssemblyMetadataAttribute>()
                .ToLookup(
                    x => x.Key,
                    x => x.Value,
                    StringComparer.OrdinalIgnoreCase
                );

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>System.String[].</returns>
        public IEnumerable<string> GetValue(string key) =>
            _results.Contains(key) ? _results[key] : Array.Empty<string>();

        /// <summary>
        /// Determines whether the specified key has prefix.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns><c>true</c> if the specified key has prefix; otherwise, <c>false</c>.</returns>
        public bool HasPrefix(string key) =>
            _results.Any(z => z.Key.StartsWith(key, StringComparison.OrdinalIgnoreCase));
    }
}
