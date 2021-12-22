// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DragonFruit.Six.Api.Accounts.Entities;
using DragonFruit.Six.Api.Legacy;
using DragonFruit.Six.Api.Utils;
using LegacyStats = DragonFruit.Six.Api.Legacy.Entities.LegacyStats;

namespace DragonFruit.Six.Api.Extensions
{
    public static class GeneralStatsExtensions
    {
        /// <summary>
        /// Get the <see cref="Legacy.Entities.LegacyStats"/> (non-seasonal) for an <see cref="UbisoftAccount"/>
        /// </summary>
        public static LegacyStats GetStats<T>(this T client, UbisoftAccount account, CancellationToken token = default) where T : Dragon6Client
        {
            return GetStats(client, account.Yield(), token).For(account);
        }

        /// <summary>
        /// Get the <see cref="LegacyStats"/> (non-seasonal) for an array of <see cref="UbisoftAccount"/>s
        /// </summary>
        public static ILookup<string, LegacyStats> GetStats<T>(this T client, IEnumerable<UbisoftAccount> accounts, CancellationToken token = default) where T : Dragon6Client
        {
            return PlatformStatsExtensions.GetPlatformStats<StatsRequest, LegacyStats>(client, accounts, token, j => LegacyStatsDeserializer.DeserializeGeneralStats(j));
        }

        /// <summary>
        /// Get the <see cref="LegacyStats"/> (non-seasonal) for an <see cref="UbisoftAccount"/>
        /// </summary>
        public static Task<LegacyStats> GetStatsAsync<T>(this T client, UbisoftAccount account, CancellationToken token = default) where T : Dragon6Client
        {
            return GetStatsAsync(client, account.Yield(), token).ContinueWith(t => t.Result.For(account), TaskContinuationOptions.OnlyOnRanToCompletion);
        }

        /// <summary>
        /// Get the <see cref="LegacyStats"/> (non-seasonal) for an array of <see cref="UbisoftAccount"/>s
        /// </summary>
        public static Task<ILookup<string, LegacyStats>> GetStatsAsync<T>(this T client, IEnumerable<UbisoftAccount> accounts, CancellationToken token = default) where T : Dragon6Client
        {
            return PlatformStatsExtensions.GetPlatformStatsAsync<StatsRequest, LegacyStats>(client, accounts, token, j => LegacyStatsDeserializer.DeserializeGeneralStats(j));
        }
    }
}
