// Dragon6 API Copyright DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Refer to the LICENSE file for more info

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DragonFruit.Six.Api.Accounts.Entities;
using DragonFruit.Six.Api.Enums;
using DragonFruit.Six.Api.Modern.Containers;
using DragonFruit.Six.Api.Modern.Entities;
using DragonFruit.Six.Api.Modern.Enums;
using DragonFruit.Six.Api.Modern.Requests;
using DragonFruit.Six.Api.Modern.Utils;
using JetBrains.Annotations;
using Newtonsoft.Json.Linq;

namespace DragonFruit.Six.Api.Modern
{
    public static class ModernStatsExtensions
    {
        /// <summary>
        /// Gets the user's recently played maps, with information including K/D, W/L and time alive
        /// </summary>
        /// <param name="client">The <see cref="Dragon6Client"/> to use</param>
        /// <param name="account">The <see cref="UbisoftAccount"/> to get stats for</param>
        /// <param name="playlistType">The <see cref="PlaylistType"/> to get stats for</param>
        /// <param name="operatorType">The <see cref="OperatorType"/> to filter stats by</param>
        /// <param name="startDate">The first day to return stats for. Must be within the last 120 days</param>
        /// <param name="endDate">The last day to include stats for. Must be at least 1 day before current UTC time</param>
        /// <param name="token">Optional <see cref="CancellationToken"/></param>
        /// <returns>A container with the requested map stats. Will return null if no stats found</returns>
        [CanBeNull]
        public static Task<ModernModeStatsContainer<IEnumerable<ModernMapStats>>> GetModernMapStatsAsync(this Dragon6Client client, UbisoftAccount account, PlaylistType playlistType = PlaylistType.All, OperatorType operatorType = OperatorType.All, DateTimeOffset? startDate = null, DateTimeOffset? endDate = null, CancellationToken token = default)
        {
            var request = new ModernMapStatsRequest(account)
            {
                Playlist = playlistType,
                OperatorType = operatorType
            };

            ValueUtils.ApplyValue(startDate, s => request.StartDate = s);
            ValueUtils.ApplyValue(endDate, e => request.EndDate = e);

            return client.PerformAsync<JObject>(request, token)
                         .ContinueWith(t => t.Result.ProcessData<IEnumerable<ModernMapStats>>(request), TaskContinuationOptions.OnlyOnRanToCompletion);
        }

        /// <summary>
        /// Gets the user's recently played operators, with information including K/D, W/L and time alive
        /// </summary>
        /// <param name="client">The <see cref="Dragon6Client"/> to use</param>
        /// <param name="account">The <see cref="UbisoftAccount"/> to get stats for</param>
        /// <param name="playlistType">The <see cref="PlaylistType"/> to get stats for</param>
        /// <param name="operatorType">The <see cref="OperatorType"/> to filter stats by</param>
        /// <param name="startDate">The first day to return stats for. Must be within the last 120 days</param>
        /// <param name="endDate">The last day to include stats for. Must be at least 1 day before current UTC time</param>
        /// <param name="token">Optional <see cref="CancellationToken"/></param>
        /// <returns>A container with the requested operator stats. Will return null if no stats found</returns>
        [CanBeNull]
        public static Task<ModernModeStatsContainer<IEnumerable<ModernOperatorStats>>> GetModernOperatorStatsAsync(this Dragon6Client client, UbisoftAccount account, PlaylistType playlistType = PlaylistType.All, OperatorType operatorType = OperatorType.All, DateTimeOffset? startDate = null, DateTimeOffset? endDate = null, CancellationToken token = default)
        {
            var request = new ModernOperatorStatsRequest(account)
            {
                Playlist = playlistType,
                OperatorType = operatorType
            };

            ValueUtils.ApplyValue(startDate, s => request.StartDate = s);
            ValueUtils.ApplyValue(endDate, e => request.EndDate = e);

            return client.PerformAsync<JObject>(request, token)
                         .ContinueWith(t => t.Result.ProcessData<IEnumerable<ModernOperatorStats>>(request), TaskContinuationOptions.OnlyOnRanToCompletion);
        }

        /// <summary>
        /// Gets the user's seasonal history
        /// </summary>
        /// <param name="client">The <see cref="Dragon6Client"/> to use</param>
        /// <param name="account">The <see cref="UbisoftAccount"/> to get stats for</param>
        /// <param name="playlistType">The <see cref="PlaylistType"/> to get stats for</param>
        /// <param name="token">Optional <see cref="CancellationToken"/></param>
        /// <returns>A container with all seasons tracked. Will return null if no stats found</returns>
        [CanBeNull]
        public static Task<ModernModeStatsContainer<IEnumerable<ModernSeasonStats>>> GetModernSeasonStatsAsync(this Dragon6Client client, UbisoftAccount account, PlaylistType playlistType = PlaylistType.All, CancellationToken token = default)
        {
            var request = new ModernSeasonalStatsRequest(account)
            {
                Playlist = playlistType
            };

            return client.PerformAsync<JObject>(request, token)
                         .ContinueWith(t => t.Result.ProcessData<IEnumerable<ModernSeasonStats>>(request), TaskContinuationOptions.OnlyOnRanToCompletion);
        }

        /// <summary>
        /// Gets a summary of the user's current activity, with information including K/D, W/L and time alive
        /// </summary>
        /// <param name="client">The <see cref="Dragon6Client"/> to use</param>
        /// <param name="account">The <see cref="UbisoftAccount"/> to get stats for</param>
        /// <param name="playlistType">The <see cref="PlaylistType"/> to get stats for</param>
        /// <param name="operatorType">The <see cref="OperatorType"/> to filter stats by</param>
        /// <param name="startDate">The first day to return stats for. Must be within the last 120 days</param>
        /// <param name="endDate">The last day to include stats for. Must be at least 1 day before current UTC time</param>
        /// <param name="token">Optional <see cref="CancellationToken"/></param>
        /// <returns>A container with the requested stats. Will return null if no stats found.</returns>
        /// <remarks>This returns a collection of <see cref="ModernStatsSummary"/> items, but is recommended to use FirstOrDefault() to get the correct stats object</remarks>
        [CanBeNull]
        public static Task<ModernModeStatsContainer<IEnumerable<ModernStatsSummary>>> GetModernStatsSummaryAsync(this Dragon6Client client, UbisoftAccount account, PlaylistType playlistType = PlaylistType.All, OperatorType operatorType = OperatorType.All, DateTimeOffset? startDate = null, DateTimeOffset? endDate = null, CancellationToken token = default)
        {
            var request = new ModernStatsSummaryRequest(account)
            {
                Playlist = playlistType,
                OperatorType = operatorType
            };

            ValueUtils.ApplyValue(startDate, s => request.StartDate = s);
            ValueUtils.ApplyValue(endDate, e => request.EndDate = e);

            return client.PerformAsync<JObject>(request, token)
                         .ContinueWith(t => t.Result.ProcessData<IEnumerable<ModernStatsSummary>>(request), TaskContinuationOptions.OnlyOnRanToCompletion);
        }

        /// <summary>
        /// Gets the user's graphs
        /// </summary>
        /// <param name="client">The <see cref="Dragon6Client"/> to use</param>
        /// <param name="account">The <see cref="UbisoftAccount"/> to get stats for</param>
        /// <param name="playlistType">The <see cref="PlaylistType"/> to get stats for</param>
        /// <param name="operatorType">The <see cref="OperatorType"/> to filter stats by</param>
        /// <param name="startDate">The first day to return stats for. Must be within the last 120 days</param>
        /// <param name="endDate">The last day to include stats for. Must be at least 1 day before current UTC time</param>
        /// <param name="token">Optional <see cref="CancellationToken"/></param>
        /// <returns>A container with the data needed to plot the graphs seen on the ubisoft stats site. Will return null if no stats found</returns>
        [CanBeNull]
        public static Task<ModernModeStatsContainer<IEnumerable<ModernStatsTrend>>> GetModernStatsTrendAsync(this Dragon6Client client, UbisoftAccount account, PlaylistType playlistType = PlaylistType.All, OperatorType operatorType = OperatorType.All, DateTimeOffset? startDate = null, DateTimeOffset? endDate = null, CancellationToken token = default)
        {
            var request = new ModernStatsTrendRequest(account)
            {
                Playlist = playlistType,
                OperatorType = operatorType,
                TrendSpan = TrendSpan.Weekly
            };

            ValueUtils.ApplyValue(startDate, s => request.StartDate = s);
            ValueUtils.ApplyValue(endDate, e => request.EndDate = e);

            return client.PerformAsync<JObject>(request, token)
                         .ContinueWith(t => t.Result.ProcessData<IEnumerable<ModernStatsTrend>>(request), TaskContinuationOptions.OnlyOnRanToCompletion);
        }

        /// <summary>
        /// Gets the user's recently used weapons
        /// </summary>
        /// <param name="client">The <see cref="Dragon6Client"/> to use</param>
        /// <param name="account">The <see cref="UbisoftAccount"/> to get stats for</param>
        /// <param name="playlistType">The <see cref="PlaylistType"/> to get stats for</param>
        /// <param name="operatorType">The <see cref="OperatorType"/> to filter stats by</param>
        /// <param name="startDate">The first day to return stats for. Must be within the last 120 days</param>
        /// <param name="endDate">The last day to include stats for. Must be at least 1 day before current UTC time</param>
        /// <param name="token">Optional <see cref="CancellationToken"/></param>
        /// <returns>A container with the requested weapon stats. Will return null if no stats found</returns>
        [CanBeNull]
        public static Task<ModernModeStatsContainer<WeaponSlot>> GetModernWeaponStatsAsync(this Dragon6Client client, UbisoftAccount account, PlaylistType playlistType = PlaylistType.All, OperatorType operatorType = OperatorType.All, DateTimeOffset? startDate = null, DateTimeOffset? endDate = null, CancellationToken token = default)
        {
            var request = new ModernWeaponStatsRequest(account)
            {
                Playlist = playlistType,
                OperatorType = operatorType
            };

            ValueUtils.ApplyValue(startDate, s => request.StartDate = s);
            ValueUtils.ApplyValue(endDate, e => request.EndDate = e);

            return client.PerformAsync<JObject>(request, token)
                         .ContinueWith(t => t.Result.ProcessData<WeaponSlot>(request), TaskContinuationOptions.OnlyOnRanToCompletion);
        }
    }
}
