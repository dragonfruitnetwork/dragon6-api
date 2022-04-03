// Dragon6 API Copyright DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Refer to the LICENSE file for more info

using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DragonFruit.Data;
using DragonFruit.Six.Api.Accounts.Entities;
using DragonFruit.Six.Api.Legacy;
using DragonFruit.Six.Api.Seasonal.Entities;
using DragonFruit.Six.Api.Seasonal.Enums;
using DragonFruit.Six.Api.Seasonal.Requests;
using DragonFruit.Six.Api.Utils;

namespace DragonFruit.Six.Api.Seasonal
{
    public static class SeasonStatsExtensions
    {
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
            return LegacyStatsExtensions.GetPlatformStatsImplAsync(client, accounts,
                p => new SeasonalStatsRequest(p, board, seasonId, region),
                j => j.ToObject<SeasonalStatsResponse>(), token);
        }

        /// <summary>
        /// Get seasonal stats "records" for the provided <see cref="UbisoftAccount"/>s
        /// </summary>
        /// <param name="client">The <see cref="Dragon6Client"/> to use</param>
        /// <param name="accounts">The <see cref="UbisoftAccount"/>s to get stats for</param>
        /// <param name="seasonIds">The season ids. Defaults to the current season</param>
        /// <param name="boards">The leaderboards to get rankings for</param>
        /// <param name="regions">The regions to get stats for. Seasons after ~17 do not need to set this</param>
        /// <param name="token">Optional cancellation token</param>
        /// <remarks>
        /// This call is able to return results for multiple accounts spanning large numbers of seasons, ranking boards and regions. If you need a single season, use <see cref="GetSeasonalStatsAsync(DragonFruit.Six.Api.Dragon6Client,DragonFruit.Six.Api.Accounts.Entities.UbisoftAccount,int,DragonFruit.Six.Api.Seasonal.Enums.BoardType,DragonFruit.Six.Api.Seasonal.Enums.Region,System.Threading.CancellationToken)"/> instead.
        /// Elements are returned ungrouped and unordered due to the large ways the dataset could be sorted. It is recommended to sort then convert the returned <see cref="IEnumerable{T}"/> to an array afterwards.
        /// This does not return stats for the current season (either -1 or the positive id), use the other overload to get the current season
        /// </remarks>
        public static Task<IEnumerable<SeasonalStats>> GetSeasonalStatsRecordsAsync(this Dragon6Client client, IEnumerable<UbisoftAccount> accounts, IEnumerable<int> seasonIds, BoardType boards, Region regions, CancellationToken token = default)
        {
            return LegacyStatsExtensions.GetPlatformStatsImplAsync(client, accounts,
                p => new SeasonalStatsRecordRequest(p, boards, seasonIds, regions),
                j => j.SelectTokens("$..players_skill_records[*]").Select(x => x.ToObject<SeasonalStats>()), token);
        }

        /// <summary>
        /// Get seasonal stats "records" for the provided <see cref="UbisoftAccount"/>s
        /// </summary>
        /// <param name="client">The <see cref="Dragon6Client"/> to use</param>
        /// <param name="account">The <see cref="UbisoftAccount"/> to get stats for</param>
        /// <param name="seasonIds">The season ids. Defaults to the current season</param>
        /// <param name="boards">The leaderboards to get rankings for</param>
        /// <param name="regions">The regions to get stats for. Seasons after ~17 do not need to set this</param>
        /// <param name="token">Optional cancellation token</param>
        /// <remarks>
        /// This call is able to return results for multiple accounts spanning large numbers of seasons, ranking boards and regions. If you need a single season, use <see cref="GetSeasonalStatsAsync(DragonFruit.Six.Api.Dragon6Client,DragonFruit.Six.Api.Accounts.Entities.UbisoftAccount,int,DragonFruit.Six.Api.Seasonal.Enums.BoardType,DragonFruit.Six.Api.Seasonal.Enums.Region,System.Threading.CancellationToken)"/> instead.
        /// Elements are returned ungrouped and unordered due to the large ways the dataset could be sorted. It is recommended to sort then convert the returned <see cref="IEnumerable{T}"/> to an array afterwards.
        /// This does not return stats for the current season (either -1 or the positive id), use the other overload to get the current season
        /// </remarks>
        public static Task<IEnumerable<SeasonalStats>> GetSeasonalStatsRecordsAsync(this Dragon6Client client, UbisoftAccount account, IEnumerable<int> seasonIds, BoardType boards, Region regions, CancellationToken token = default)
        {
            return GetSeasonalStatsRecordsAsync(client, account.Yield(), seasonIds, boards, regions, token);
        }
    }
}
