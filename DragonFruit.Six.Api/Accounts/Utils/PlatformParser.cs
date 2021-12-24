// Dragon6 API Copyright DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Refer to the LICENSE file for more info

using System;
using System.Collections.Generic;
using System.Linq;
using DragonFruit.Six.Api.Accounts.Enums;

namespace DragonFruit.Six.Api.Accounts.Utils
{
    public static class PlatformParser
    {
        /// <summary>
        /// <see cref="Platform"/> Identifier to Ubisoft string
        /// </summary>
        // todo move to reflecting EnumMember
        public static string PlatformIdentifierFor(Platform platform) => platform switch
        {
            Platform.PSN => "psn",
            Platform.XB1 => "xbl",
            Platform.PC => "uplay",

            _ => throw new ArgumentOutOfRangeException()
        };

        /// <summary>
        /// Enumerates over all <see cref="Platform"/>s, producing a <see cref="Dictionary{TKey,TValue}"/>
        /// of platforms to a user-defined value
        /// </summary>
        internal static Dictionary<T, Platform> PlatformsTo<T>(Func<Platform, T> selector)
        {
            var platforms = (Platform[])Enum.GetValues(typeof(Platform));
            return platforms.ToDictionary(selector.Invoke, x => x);
        }
    }
}
