// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System.Collections.Generic;
using System.Linq;
using DragonFruit.Six.API.Data.Deserializers;
using DragonFruit.Six.API.Data.Requests;
using Newtonsoft.Json.Linq;

namespace DragonFruit.Six.API.Data.Extensions
{
    public static class SeasonStatsExtensions
    {
        /// <summary>
        /// Get ranked (seasonal) stats for the <see cref="AccountInfo"/> (latest season)
        /// </summary>
        /// <remarks>
        /// Seasonal stats are now region-independent
        /// </remarks>
        public static SeasonStats GetSeasonStats<T>(this T client, AccountInfo account) where T : Dragon6Client
            => GetSeasonStats(client, new[] { account }, "EMEA", -1).First();

        /// <summary>
        /// Get ranked (seasonal) stats for an array of <see cref="AccountInfo"/>s (latest season)
        /// </summary>
        /// <remarks>
        /// Seasonal stats are now region-independent
        /// </remarks>
        public static IEnumerable<SeasonStats> GetSeasonStats<T>(this T client, IEnumerable<AccountInfo> accounts) where T : Dragon6Client
            => GetSeasonStats(client, accounts, "EMEA", -1);

        /// <summary>
        /// Get ranked (seasonal) stats for an <see cref="AccountInfo"/>
        /// </summary>
        /// <remarks>
        /// Seasonal stats pre-season 18 are region-independent (pass any region)
        /// </remarks>
        public static SeasonStats GetSeasonStats<T>(this T client, AccountInfo account, string region, int seasonId) where T : Dragon6Client
            => GetSeasonStats(client, new[] { account }, region, seasonId).First();

        /// <summary>
        /// Get ranked (seasonal) stats for an array of <see cref="AccountInfo"/>s (latest season)
        /// </summary>
        /// <remarks>
        /// Seasonal stats pre-season 18 are region-independent (pass any region)
        /// </remarks>
        public static IEnumerable<SeasonStats> GetSeasonStats<T>(this T client, IEnumerable<AccountInfo> accounts, string region, int seasonId) where T : Dragon6Client
        {
            var filteredGroups = accounts.GroupBy(x => x.Platform);

            foreach (var group in filteredGroups)
            {
                var request = new SeasonStatsRequest(group)
                {
                    Season = seasonId,
                    Region = region
                };

                var data = client.Perform<JObject>(request);

                foreach (var id in request.AccountIds)
                {
                    yield return data.DeserializeSeasonStatsFor(id);
                }
            }
        }
    }
}
