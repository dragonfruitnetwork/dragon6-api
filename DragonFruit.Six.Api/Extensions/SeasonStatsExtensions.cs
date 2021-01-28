// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System.Collections.Generic;
using System.Linq;
using System.Threading;
using DragonFruit.Six.Api.Entities;
using DragonFruit.Six.Api.Deserializers;
using DragonFruit.Six.Api.Requests;
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
            => GetSeasonStats(client, new[] { account }, "EMEA", -1, token).First();

        /// <summary>
        /// Get ranked (seasonal) stats for the <see cref="AccountInfo"/> (latest season)
        /// </summary>
        /// <remarks>
        /// Seasonal stats are now region-independent
        /// </remarks>
        public static SeasonStats GetSeasonStats<T>(this T client, AccountInfo account, int season, CancellationToken token = default) where T : Dragon6Client
            => GetSeasonStats(client, new[] { account }, "EMEA", season, token).First();

        /// <summary>
        /// Get ranked (seasonal) stats for an array of <see cref="AccountInfo"/>s (latest season)
        /// </summary>
        /// <remarks>
        /// Seasonal stats are now region-independent
        /// </remarks>
        public static IEnumerable<SeasonStats> GetSeasonStats<T>(this T client, IEnumerable<AccountInfo> accounts, CancellationToken token = default) where T : Dragon6Client
            => GetSeasonStats(client, accounts, "EMEA", -1, token);

        /// <summary>
        /// Get ranked (seasonal) stats for an <see cref="AccountInfo"/>
        /// </summary>
        /// <remarks>
        /// Seasonal stats pre-season 18 are region-independent (pass any region)
        /// </remarks>
        public static SeasonStats GetSeasonStats<T>(this T client, AccountInfo account, string region, int seasonId, CancellationToken token = default) where T : Dragon6Client
            => GetSeasonStats(client, new[] { account }, region, seasonId, token).First();

        /// <summary>
        /// Get ranked (seasonal) stats for an array of <see cref="AccountInfo"/>s (latest season)
        /// </summary>
        /// <remarks>
        /// Seasonal stats pre-season 18 are region-independent (pass any region)
        /// </remarks>
        public static IEnumerable<SeasonStats> GetSeasonStats<T>(this T client, IEnumerable<AccountInfo> accounts, string region, int seasonId, CancellationToken token = default)
            where T : Dragon6Client
        {
            var filteredGroups = accounts.GroupBy(x => x.Platform);

            foreach (var group in filteredGroups)
            {
                var request = new SeasonStatsRequest(group)
                {
                    Season = seasonId,
                    Region = region
                };

                var data = client.Perform<JObject>(request, token);

                foreach (var id in request.AccountIds)
                {
                    yield return data.DeserializeSeasonStatsFor(id);
                }
            }
        }
    }
}
