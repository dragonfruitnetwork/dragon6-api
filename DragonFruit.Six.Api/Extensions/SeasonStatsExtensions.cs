// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DragonFruit.Six.Api.Entities;
using DragonFruit.Six.Api.Deserializers;
using DragonFruit.Six.Api.Requests;
using DragonFruit.Six.Api.Utils;

namespace DragonFruit.Six.Api.Extensions
{
    public static class SeasonStatsExtensions
    {
        private const string DefaultRegion = "EMEA";

        /// <summary>
        /// Get ranked (seasonal) stats for the <see cref="AccountInfo"/>
        /// </summary>
        public static SeasonStats GetSeasonStats<T>(this T client, AccountInfo account, int season = -1, string region = DefaultRegion, CancellationToken token = default) where T : Dragon6Client
        {
            return GetSeasonStats(client, account.Yield(), season, region, token).For(account);
        }

        /// <summary>
        /// Get ranked (seasonal) stats for an array of <see cref="AccountInfo"/>s (latest season)
        /// </summary>
        /// <remarks>
        /// Seasonal stats pre-season 18 are region-independent
        /// </remarks>
        public static ILookup<string, SeasonStats> GetSeasonStats<T>(this T client, IEnumerable<AccountInfo> accounts, int season = -1, string region = DefaultRegion, CancellationToken token = default) where T : Dragon6Client
        {
            return PlatformStatsExtensions.GetPlatformStats(client, accounts, token, j => j.DeserializeSeasonStats(), a => new SeasonStatsRequest(a)
            {
                Region = region,
                Season = season
            });
        }

        /// <summary>
        /// Get ranked (seasonal) stats for the <see cref="AccountInfo"/>
        /// </summary>
        public static Task<SeasonStats> GetSeasonStatsAsync<T>(this T client, AccountInfo account, int season = -1, string region = DefaultRegion, CancellationToken token = default) where T : Dragon6Client
        {
            return GetSeasonStatsAsync(client, account.Yield(), season, region, token).ContinueWith(t => t.Result.For(account), TaskContinuationOptions.OnlyOnRanToCompletion);
        }

        /// <summary>
        /// Get ranked (seasonal) stats for an array of <see cref="AccountInfo"/>s (latest season)
        /// </summary>
        /// <remarks>
        /// Seasonal stats pre-season 18 are region-independent
        /// </remarks>
        public static Task<ILookup<string, SeasonStats>> GetSeasonStatsAsync<T>(this T client, IEnumerable<AccountInfo> accounts, int season = -1, string region = DefaultRegion, CancellationToken token = default) where T : Dragon6Client
        {
            return PlatformStatsExtensions.GetPlatformStatsAsync(client, accounts, token, j => j.DeserializeSeasonStats(), a => new SeasonStatsRequest(a)
            {
                Region = region,
                Season = season
            });
        }
    }
}
