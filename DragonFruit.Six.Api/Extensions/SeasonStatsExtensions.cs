// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System.Collections.Generic;
using System.Linq;
using System.Threading;
using DragonFruit.Six.Api.Entities;
using DragonFruit.Six.Api.Deserializers;
using DragonFruit.Six.Api.Requests;
using DragonFruit.Six.Api.Utils;
using Newtonsoft.Json.Linq;

namespace DragonFruit.Six.Api.Extensions
{
    public static class SeasonStatsExtensions
    {
        /// <summary>
        /// Get ranked (seasonal) stats for the <see cref="AccountInfo"/> (latest season)
        /// </summary>
        /// <remarks>
        /// Seasonal stats are now region-independent
        /// </remarks>
        public static SeasonStats GetSeasonStats<T>(this T client, AccountInfo account, CancellationToken token = default) where T : Dragon6Client
            => GetSeasonStats(client, account.Yield(), "EMEA", -1, token).For(account);

        /// <summary>
        /// Get ranked (seasonal) stats for the <see cref="AccountInfo"/> (latest season)
        /// </summary>
        /// <remarks>
        /// Seasonal stats are now region-independent
        /// </remarks>
        public static SeasonStats GetSeasonStats<T>(this T client, AccountInfo account, int season, CancellationToken token = default) where T : Dragon6Client
            => GetSeasonStats(client, account.Yield(), "EMEA", season, token).For(account);

        /// <summary>
        /// Get ranked (seasonal) stats for an array of <see cref="AccountInfo"/>s (latest season)
        /// </summary>
        /// <remarks>
        /// Seasonal stats are now region-independent
        /// </remarks>
        public static ILookup<string, SeasonStats> GetSeasonStats<T>(this T client, IEnumerable<AccountInfo> accounts, CancellationToken token = default) where T : Dragon6Client
            => GetSeasonStats(client, accounts, "EMEA", -1, token);

        /// <summary>
        /// Get ranked (seasonal) stats for an <see cref="AccountInfo"/>
        /// </summary>
        /// <remarks>
        /// Seasonal stats pre-season 18 are region-independent (pass any region)
        /// </remarks>
        public static SeasonStats GetSeasonStats<T>(this T client, AccountInfo account, string region, int seasonId, CancellationToken token = default) where T : Dragon6Client
            => GetSeasonStats(client, account.Yield(), region, seasonId, token).For(account);

        /// <summary>
        /// Get ranked (seasonal) stats for an array of <see cref="AccountInfo"/>s (latest season)
        /// </summary>
        /// <remarks>
        /// Seasonal stats pre-season 18 are region-independent (pass any region)
        /// </remarks>
        public static ILookup<string, SeasonStats> GetSeasonStats<T>(this T client, IEnumerable<AccountInfo> accounts, string region, int seasonId, CancellationToken token = default) where T : Dragon6Client
        {
            var filteredGroups = accounts.GroupBy(x => x.Platform);
            JObject data = null;

            foreach (var group in filteredGroups)
            {
                var request = new SeasonStatsRequest(group)
                {
                    Season = seasonId,
                    Region = region
                };

                var platformResponse = client.Perform<JObject>(request, token);

                if (data == null)
                {
                    data = platformResponse;
                }
                else
                {
                    data.Merge(platformResponse);
                }
            }

            return data.DeserializeSeasonStats();
        }
    }
}
