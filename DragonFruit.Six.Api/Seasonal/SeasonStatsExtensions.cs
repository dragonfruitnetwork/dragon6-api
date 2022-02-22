// Dragon6 API Copyright DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Refer to the LICENSE file for more info

using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DragonFruit.Data;
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
        /// Get seasonal stats for the provided <see cref="UbisoftAccount"/>
        /// </summary>
        /// <param name="client">The <see cref="Dragon6Client"/> to use</param>
        /// <param name="account">The <see cref="UbisoftAccount"/> to get stats for</param>
        /// <param name="seasonId">The season id. Defaults to the current season</param>
        /// <param name="board">The leaderboard to get rankings for</param>
        /// <param name="region">The region to get stats for. Seasons after ~17 do not need to set this</param>
        /// <param name="token">Optional cancellation token</param>
        public static Task<SeasonalStats> GetSeasonalStatsAsync(this Dragon6Client client, UbisoftAccount account, int seasonId = -1, BoardType board = BoardType.Ranked, Region region = Region.EMEA, CancellationToken token = default)
        {
            var request = new SeasonalStatsRequest(account.Yield(), board, seasonId, region);
            return client.PerformAsync<SeasonalStatsResponse>(request, token).ContinueWith(t => t.Result.For(account), TaskContinuationOptions.OnlyOnRanToCompletion);
        }

        /// <summary>
        /// Get seasonal stats for the provided <see cref="UbisoftAccount"/>s
        /// </summary>
        /// <param name="client">The <see cref="Dragon6Client"/> to use</param>
        /// <param name="accounts">The <see cref="UbisoftAccount"/>s to get stats for</param>
        /// <param name="seasonId">The season id. Defaults to the current season</param>
        /// <param name="board">The leaderboard to get rankings for</param>
        /// <param name="region">The region to get stats for. Seasons after ~17 do not need to set this</param>
        /// <param name="token">Optional cancellation token</param>
        public static Task<SeasonalStatsResponse> GetSeasonalStatsAsync(this Dragon6Client client, IEnumerable<UbisoftAccount> accounts, int seasonId = -1, BoardType board = BoardType.Ranked, Region region = Region.EMEA, CancellationToken token = default)
        {
            var platformRequests = accounts.GroupBy(x => x.Platform).Select(x =>
            {
                var request = new SeasonalStatsRequest(x, board, seasonId, region);
                return client.PerformAsync<JObject>(request, token);
            });

            return Task.WhenAll(platformRequests).ContinueWith(t =>
            {
                var json = t.Result.Aggregate((a, b) =>
                {
                    a.Merge(b);
                    return a;
                });

                return json.ToObject<SeasonalStatsResponse>();
            }, TaskContinuationOptions.OnlyOnRanToCompletion);
        }

        /// <summary>
        /// Gets a <see cref="IReadOnlyCollection{T}"/> of metadata for all seasons with stats available
        /// </summary>
        /// <remarks>
        /// The information returned by this method is maintained by the Dragon6 team
        /// </remarks>
        /// <param name="client">The <see cref="ApiClient"/> to use</param>
        public static Task<IReadOnlyCollection<SeasonInfo>> GetSeasonInfoAsync(this ApiClient client)
        {
            return client.PerformAsync<IReadOnlyCollection<SeasonInfo>>(new SeasonInfoRequest());
        }
    }
}
