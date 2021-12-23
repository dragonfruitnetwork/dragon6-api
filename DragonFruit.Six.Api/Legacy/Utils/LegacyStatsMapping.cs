// Dragon6 API Copyright 2021 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DragonFruit.Six.Api.Legacy.Utils
{
    internal static class LegacyStatsMapping
    {
        private static Dictionary<LegacyStatTypes, List<string>> _categoryCache;

        /// <summary>
        /// Gets the stats identifiers for the <see cref="LegacyStatTypes"/> keys provided
        /// </summary>
        public static IEnumerable<string> GetDefaultStats(this LegacyStatTypes stats)
        {
            return Enum.GetValues(typeof(LegacyStatTypes))
                       .Cast<LegacyStatTypes>()
                       .Aggregate(Enumerable.Empty<string>(), (a, b) => _categoryCache.TryGetValue(b, out var data) ? a.Concat(data) : a);
        }

        /// <summary>
        /// Initializes the <see cref="LegacyStatTypes"/> keys for resolving at request-time via <see cref="GetDefaultStats"/>
        /// </summary>
        public static void InitialiseStatsBuckets()
        {
            if (_categoryCache is not null)
            {
                return;
            }

            var cache = new Dictionary<LegacyStatTypes, List<string>>(7);

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

                // get or add entry, then push
                (cache[attr.TargetCategory] ??= new List<string>()).AddRange(classKeys);
            }

            foreach (var list in cache.Values)
            {
                // these lists won't be modified anymore, so trim excess space
                list.TrimExcess();
            }

            _categoryCache = cache;
        }
    }
}
