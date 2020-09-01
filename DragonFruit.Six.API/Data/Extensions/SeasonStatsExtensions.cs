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
        public static SeasonStats GetSeasonStats<T>(this T client, AccountInfo account, string region) where T : Dragon6Client
            => GetSeasonStats(client, new[] { account }, region, -1).First();

        public static IEnumerable<SeasonStats> GetSeasonStats<T>(this T client, IEnumerable<AccountInfo> accounts, string region) where T : Dragon6Client
            => GetSeasonStats(client, accounts, region, -1);

        public static SeasonStats GetSeasonStats<T>(this T client, AccountInfo account, string region, int seasonId) where T : Dragon6Client
            => GetSeasonStats(client, new[] { account }, region, seasonId).First();

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
