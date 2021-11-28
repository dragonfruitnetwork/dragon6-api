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
using Newtonsoft.Json.Linq;

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
            return accounts.GroupBy(x => x.Platform)
                           .Select(x =>
                           {
                               var request = new SeasonStatsRequest(x)
                               {
                                   Region = region,
                                   Season = season
                               };

                               return client.Perform<JObject>(request, token);
                           })
                           .Aggregate(GeneralStatsExtensions.Merge)
                           .DeserializeSeasonStats();
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
            var requests = accounts.GroupBy(x => x.Platform).Select(x =>
            {
                var request = new SeasonStatsRequest(x)
                {
                    Region = region,
                    Season = season
                };

                return client.PerformAsync<JObject>(request, token);
            });

            return Task.WhenAll(requests).ContinueWith(t => t.Result.Aggregate(GeneralStatsExtensions.Merge).DeserializeSeasonStats(), TaskContinuationOptions.OnlyOnRanToCompletion);
        }
    }
}
