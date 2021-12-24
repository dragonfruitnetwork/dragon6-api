// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DragonFruit.Six.Api.Accounts.Entities;
using DragonFruit.Six.Api.Seasonal.Entities;
using DragonFruit.Six.Api.Seasonal.Enums;
using DragonFruit.Six.Api.Seasonal.Requests;
using DragonFruit.Six.Api.Utils;

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
            return GetSeasonalStatsAsync(client, account.Yield(), seasonId, board, region, token).ContinueWith(t => t.Result.For(account), TaskContinuationOptions.OnlyOnRanToCompletion);
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
            var request = new SeasonalStatsRequest(accounts, board, seasonId, region);
            return client.PerformAsync<SeasonalStatsResponse>(request, token);
        }
    }
}
