// Dragon6 API Copyright DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Refer to the LICENSE file for more info

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DragonFruit.Six.Api.Legacy.Utils
{
    internal static class LegacyStatsMapping
    {
        private static LegacyStatTypes[] _categories;
        private static Dictionary<LegacyStatTypes, string[]> _categoryKeys;

        /// <summary>
        /// Gets the stats identifiers for the <see cref="LegacyStatTypes"/> keys provided
        /// </summary>
        public static IEnumerable<string> GetDefaultStats(this LegacyStatTypes stats)
        {
            return _categories.Where(x => (stats & x) == x)
                              .Aggregate(Enumerable.Empty<string>(), (a, b) => _categoryKeys.TryGetValue(b, out var data) ? a.Concat(data) : a);
        }

        /// <summary>
        /// Initializes the <see cref="LegacyStatTypes"/> keys for resolving at request-time via <see cref="GetDefaultStats"/>
        /// </summary>
        public static void InitialiseStatsBuckets()
        {
            if (_categoryKeys is not null)
            {
                return;
            }

            var cache = new Dictionary<LegacyStatTypes, IEnumerable<string>>(7);

            foreach (var type in Assembly.GetExecutingAssembly().GetTypes())
            {
                var attr = type.GetCustomAttribute<DefaultStatsAttribute>();

                if (attr is null)
                {
                    continue;
                }

                // get all consts from the class
                var classKeys = type.GetFields(BindingFlags.Public | BindingFlags.Static)
                                    .Where(x => x.IsLiteral && !x.IsInitOnly)
                                    .Select(x => (string)x.GetRawConstantValue());

                // get or add stats key
                if (cache.TryGetValue(attr.TargetCategory, out var currentKeys))
                {
                    cache[attr.TargetCategory] = currentKeys.Concat(classKeys);
                }
                else
                {
                    cache[attr.TargetCategory] = classKeys;
                }
            }

            // then create a new dictionary by enumerating all values
            _categories = Enum.GetValues(typeof(LegacyStatTypes)).Cast<LegacyStatTypes>().ToArray();
            _categoryKeys = cache.ToDictionary(x => x.Key, x => x.Value.ToArray());
        }
    }
}
