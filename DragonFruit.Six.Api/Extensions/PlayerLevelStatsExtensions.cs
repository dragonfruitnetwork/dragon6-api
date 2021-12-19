// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DragonFruit.Six.Api.Accounts.Entities;
using DragonFruit.Six.Api.Entities;
using DragonFruit.Six.Api.Deserializers;
using DragonFruit.Six.Api.Requests;
using DragonFruit.Six.Api.Utils;

namespace DragonFruit.Six.Api.Extensions
{
    public static class PlayerLevelStatsExtensions
    {
        /// <summary>
        /// Get the level, level progression and alpha pack chances for an <see cref="UbisoftAccount"/>
        /// </summary>
        public static PlayerLevelStats GetLevel<T>(this T client, UbisoftAccount account, CancellationToken token = default) where T : Dragon6Client
        {
            return GetLevel(client, account.Yield(), token).For(account);
        }

        /// <summary>
        /// Get the level, level progression and alpha pack chances for an array of <see cref="UbisoftAccount"/>s
        /// </summary>
        public static ILookup<string, PlayerLevelStats> GetLevel<T>(this T client, IEnumerable<UbisoftAccount> accounts, CancellationToken token = default) where T : Dragon6Client
        {
            return PlatformStatsExtensions.GetPlatformStats<PlayerLevelStatsRequest, PlayerLevelStats>(client, accounts, token, j => j.DeserializePlayerLevelStats());
        }

        /// <summary>
        /// Get the level, level progression and alpha pack chances for an <see cref="UbisoftAccount"/>
        /// </summary>
        public static Task<PlayerLevelStats> GetLevelAsync<T>(this T client, UbisoftAccount account, CancellationToken token = default) where T : Dragon6Client
        {
            return GetLevelAsync(client, account.Yield(), token).ContinueWith(t => t.Result.For(account), TaskContinuationOptions.OnlyOnRanToCompletion);
        }

        /// <summary>
        /// Get the level, level progression and alpha pack chances for an array of <see cref="UbisoftAccount"/>s
        /// </summary>
        public static Task<ILookup<string, PlayerLevelStats>> GetLevelAsync<T>(this T client, IEnumerable<UbisoftAccount> accounts, CancellationToken token = default) where T : Dragon6Client
        {
            return PlatformStatsExtensions.GetPlatformStatsAsync<PlayerLevelStatsRequest, PlayerLevelStats>(client, accounts, token, j => j.DeserializePlayerLevelStats());
        }
    }
}
