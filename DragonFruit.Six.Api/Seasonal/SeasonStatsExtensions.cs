// Dragon6 API Copyright DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Refer to the LICENSE file for more info

using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DragonFruit.Six.Api.Accounts.Entities;
using DragonFruit.Six.Api.Seasonal.Entities;
using DragonFruit.Six.Api.Seasonal.Enums;
using DragonFruit.Six.Api.Seasonal.Requests;
using DragonFruit.Six.Api.Utils;
using Newtonsoft.Json.Linq;

namespace DragonFruit.Six.Api.Seasonal
{
    public static class SeasonStatsExtensions
    {
        /// <summary>
        /// Get seasonal stats "records" for the provided <see cref="UbisoftAccount"/>s
        /// </summary>
        /// <param name="client">The <see cref="Dragon6Client"/> to use</param>
        /// <param name="account">The <see cref="UbisoftAccount"/> to get stats for</param>
        /// <param name="seasonIds">The season ids. Defaults to the current season</param>
        /// <param name="boards">The leaderboards to get rankings for</param>
        /// <param name="regions">(Optional) regions to return stats for. In most cases, this isn't needed anymore</param>
        /// <param name="token">Optional cancellation token</param>
        /// <remarks>
        /// This call is able to return results for multiple accounts spanning large numbers of seasons, ranking boards and regions.
        /// Elements are returned ungrouped and unordered - it is recommended to sort then convert the returned <see cref="IEnumerable{T}"/> to an array or list afterwards.
        /// </remarks>
        public static Task<IReadOnlyCollection<SeasonalStats>> GetSeasonalStatsRecordsAsync(this Dragon6Client client, UbisoftAccount account, IEnumerable<int> seasonIds, BoardType? boards = null, Region? regions = null, CancellationToken token = default)
        {
            return GetSeasonalStatsRecordsAsync(client, account.Yield(), seasonIds, boards, regions, token);
        }

        /// <summary>
        /// Get seasonal stats "records" for the provided <see cref="UbisoftAccount"/>s
        /// </summary>
        /// <param name="client">The <see cref="Dragon6Client"/> to use</param>
        /// <param name="accounts">The <see cref="UbisoftAccount"/>s to get stats for</param>
        /// <param name="seasonIds">The season ids. Defaults to the current season</param>
        /// <param name="boards">(Optional) Leaderboards to return. Defaults to returning all available boards</param>
        /// <param name="regions">(Optional) regions to return stats for. In most cases, this isn't needed anymore</param>
        /// <param name="token">Optional cancellation token</param>
        /// <remarks>
        /// This call is able to return results for multiple accounts spanning large numbers of seasons, ranking boards and regions.
        /// Elements are returned ungrouped and unordered - It is recommended to sort then convert the returned <see cref="IEnumerable{T}"/> to an array or list afterwards.
        /// </remarks>
        public static async Task<IReadOnlyCollection<SeasonalStats>> GetSeasonalStatsRecordsAsync(this Dragon6Client client, IEnumerable<UbisoftAccount> accounts, IEnumerable<int> seasonIds, BoardType? boards = null, Region? regions = null, CancellationToken token = default)
        {
            boards ??= BoardType.All;
            seasonIds ??= (-1).Yield();
            accounts = accounts as IReadOnlyCollection<UbisoftAccount> ?? accounts.ToList();
            seasonIds = seasonIds as IReadOnlyCollection<int> ?? seasonIds.ToList();

            var requests = new List<SeasonalStatsRecordRequest>(4);
            var ranked2Seasons = seasonIds.Where(x => x is >= SeasonalStatsRecordRequest.CrossPlatformProgressionId or -1);
            var otherSeasons = seasonIds.Except(ranked2Seasons);

            // handle creation of ranked 2.0 requests
            if (ranked2Seasons.Any())
            {
                requests.Add(new SeasonalStatsRecordRequest(accounts, ranked2Seasons, boards.Value));
            }

            if (otherSeasons.Any())
            {
                var platformRequests = accounts.GroupBy(x => x.Platform).Select(x => new SeasonalStatsRecordRequest(x, otherSeasons, boards.Value));
                requests.AddRange(platformRequests);
            }

            var seasonalStatsRequests = requests.Select(x =>
            {
                if (regions.HasValue)
                {
                    x.Regions = regions.Value;
                }

                return client.PerformAsync<JObject>(x, token);
            });

            var seasonalStatsResponses = await Task.WhenAll(seasonalStatsRequests).ConfigureAwait(false);
            return seasonalStatsResponses.SelectMany(x => x.SelectTokens("$..players_skill_records[*]")).Select(x => x.ToObject<SeasonalStats>()).ToList();
        }
    }
}
