// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System.Collections.Generic;
using DragonFruit.Six.API.Enums;

namespace DragonFruit.Six.API.Helpers
{
    public static partial class UbisoftIdentifiers
    {
        private static IReadOnlyDictionary<Platform, string> _gameIds;

        /// <summary>
        /// <see cref="IReadOnlyDictionary{TKey,TValue}"/> of platforms to game ids used for checking playtime stats
        /// </summary>
        internal static IReadOnlyDictionary<Platform, string> GameIds => _gameIds ??= PlatformParser.PlatformsTo(p => p.GameId());
    }
}
