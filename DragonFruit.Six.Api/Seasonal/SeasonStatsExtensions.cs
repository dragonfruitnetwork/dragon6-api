// Dragon6 API Copyright DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Refer to the LICENSE file for more info

using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DragonFruit.Six.Api.Accounts.Entities;
using DragonFruit.Six.Api.Enums;
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
        /// Get current season stats for the provided <see cref="UbisoftAccount"/>
        /// </summary>
        /// <param name="client">The <see cref="Dragon6Client"/> to use</param>
        /// <param name="account">The <see cref="UbisoftAccount"/> to get stats for</param>
        /// <param name="platforms">The <see cref="PlatformGroup"/>s to return stats for</param>
        /// <param name="cancellation">Optional cancellation token</param>
        /// <returns>The current season stats for each account. Ranked, Casual, Deathmatch and Event stats will be returned as a separate <see cref="Ranked2SeasonStats"/> object</returns>
        /// <remarks>
        /// This extension uses a protected endpoint to access data, and as such a supported token is needed.
        /// Ensure that your <see cref="Dragon6Client"/> implementation requests a token for the provided <see cref="UbisoftService"/> when called.
        /// </remarks>
        public static Task<IEnumerable<Ranked2SeasonStats>> GetSeasonalStatsAsync(this Dragon6Client client, UbisoftAccount account, PlatformGroup platforms = PlatformGroup.PC | PlatformGroup.Console, CancellationToken cancellation = default)
        {
            return GetSeasonalStatsAsync(client, account.Yield(), platforms, cancellation);
        }

        /// <summary>
        /// Get current season stats for the provided <see cref="UbisoftAccount"/>s (crossplay compatible)
        /// </summary>
        /// <param name="client">The <see cref="Dragon6Client"/> to use</param>
        /// <param name="accounts">The <see cref="UbisoftAccount"/>s to get stats for</param>
        /// <param name="platforms">The <see cref="PlatformGroup"/>s to return stats for</param>
        /// <param name="cancellation">Optional cancellation token</param>
        /// <returns>The current season stats for each account. Ranked, Casual, Deathmatch and Event stats will be returned as a separate <see cref="Ranked2SeasonStats"/> object</returns>
        /// <remarks>
        /// This extension uses a protected endpoint to access data, and as such a supported token is needed.
        /// Ensure that your <see cref="Dragon6Client"/> implementation requests a token for the provided <see cref="UbisoftService"/> when called.
        /// </remarks>
        public static async Task<IEnumerable<Ranked2SeasonStats>> GetSeasonalStatsAsync(this Dragon6Client client, IEnumerable<UbisoftAccount> accounts, PlatformGroup platforms = PlatformGroup.PC | PlatformGroup.Console, CancellationToken cancellation = default)
        {
            var request = new Ranked2StatsRequest(accounts, platforms);
            var response = await client.PerformAsync<JObject>(request, cancellation).ConfigureAwait(false);

            return response.SelectTokens("$..full_profiles[*]").Select(x =>
            {
                var children = x.Values();
                var root = (JObject)children.First();

                foreach (var other in children.Skip(1).Cast<JObject>())
                {
                    root.Merge(other);
                }

                return root.ToObject<Ranked2SeasonStats>();
            });
        }

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
        public static Task<IEnumerable<SeasonalStats>> GetSeasonalStatsRecordsAsync(this Dragon6Client client, UbisoftAccount account, IEnumerable<int> seasonIds, BoardType? boards = null, Region? regions = null, CancellationToken token = default)
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
        public static async Task<IEnumerable<SeasonalStats>> GetSeasonalStatsRecordsAsync(this Dragon6Client client, IEnumerable<UbisoftAccount> accounts, IEnumerable<int> seasonIds, BoardType? boards = null, Region? regions = null, CancellationToken token = default)
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
                var platformRequests = accounts.GroupBy(x => x.Platform).Select(x =>
                {
                    var request = new SeasonalStatsRecordRequest(x, otherSeasons, boards.Value);

                    if (regions.HasValue)
                    {
                        request.Regions = regions.Value;
                    }

                    return request;
                });

                requests.AddRange(platformRequests);
            }

            var seasonalStatsRequests = requests.Select(x => client.PerformAsync<JObject>(x, token));
            var seasonalStatsResponses = await Task.WhenAll(seasonalStatsRequests).ConfigureAwait(false);

            return seasonalStatsResponses.SelectMany(x => x.SelectTokens("$..players_skill_records[*]")).Select(x => x.ToObject<SeasonalStats>());
        }
    }
}
