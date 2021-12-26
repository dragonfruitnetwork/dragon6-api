// Dragon6 API Copyright DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Refer to the LICENSE file for more info

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DragonFruit.Six.Api.Accounts.Entities;
using DragonFruit.Six.Api.Enums;
using DragonFruit.Six.Api.Modern.Containers;
using DragonFruit.Six.Api.Modern.Entities;
using DragonFruit.Six.Api.Modern.Enums;
using DragonFruit.Six.Api.Modern.Requests;
using DragonFruit.Six.Api.Modern.Utils;
using Newtonsoft.Json.Linq;

namespace DragonFruit.Six.Api.Modern
{
    public static class ModernStatsExtensions
    {
        public static Task<ModernModeStatsContainer<IEnumerable<ModernMapStats>>> GetModernMapStatsAsync(this Dragon6Client client, UbisoftAccount account, PlaylistType playlistType = PlaylistType.All, OperatorType operatorType = OperatorType.Independent, DateTimeOffset? startDate = null, DateTimeOffset? endDate = null)
        {
            var request = new ModernMapStatsRequest(account)
            {
                Playlist = playlistType,
                OperatorType = operatorType
            };

            ValueUtils.ApplyValue(startDate, s => request.StartDate = s);
            ValueUtils.ApplyValue(endDate, e => request.EndDate = e);

            return client.PerformAsync<JObject>(request)
                         .ContinueWith(t => t.Result.ProcessData<IEnumerable<ModernMapStats>>(request), TaskContinuationOptions.OnlyOnRanToCompletion);
        }

        public static Task<ModernModeStatsContainer<IEnumerable<ModernOperatorStats>>> GetModernOperatorStatsAsync(this Dragon6Client client, UbisoftAccount account, PlaylistType playlistType = PlaylistType.All, OperatorType operatorType = OperatorType.Independent, DateTimeOffset? startDate = null, DateTimeOffset? endDate = null)
        {
            var request = new ModernOperatorStatsRequest(account)
            {
                Playlist = playlistType,
                OperatorType = operatorType
            };

            ValueUtils.ApplyValue(startDate, s => request.StartDate = s);
            ValueUtils.ApplyValue(endDate, e => request.EndDate = e);

            return client.PerformAsync<JObject>(request)
                         .ContinueWith(t => t.Result.ProcessData<IEnumerable<ModernOperatorStats>>(request), TaskContinuationOptions.OnlyOnRanToCompletion);
        }

        public static Task<ModernModeStatsContainer<IEnumerable<ModernSeasonStats>>> GetModernSeasonStatsAsync(this Dragon6Client client, UbisoftAccount account, PlaylistType playlistType = PlaylistType.All)
        {
            var request = new ModernSeasonalStatsRequest(account)
            {
                Playlist = playlistType
            };

            return client.PerformAsync<JObject>(request)
                         .ContinueWith(t => t.Result.ProcessData<IEnumerable<ModernSeasonStats>>(request), TaskContinuationOptions.OnlyOnRanToCompletion);
        }

        public static Task<ModernModeStatsContainer<IEnumerable<ModernStatsSummary>>> GetModernStatsSummaryAsync(this Dragon6Client client, UbisoftAccount account, PlaylistType playlistType = PlaylistType.All, OperatorType operatorType = OperatorType.Independent, DateTimeOffset? startDate = null, DateTimeOffset? endDate = null)
        {
            var request = new ModernStatsSummaryRequest(account)
            {
                Playlist = playlistType,
                OperatorType = operatorType
            };

            ValueUtils.ApplyValue(startDate, s => request.StartDate = s);
            ValueUtils.ApplyValue(endDate, e => request.EndDate = e);

            return client.PerformAsync<JObject>(request)
                         .ContinueWith(t => t.Result.ProcessData<IEnumerable<ModernStatsSummary>>(request), TaskContinuationOptions.OnlyOnRanToCompletion);
        }

        public static Task<ModernModeStatsContainer<IEnumerable<ModernStatsTrend>>> GetModernStatsTrendAsync(this Dragon6Client client, UbisoftAccount account, PlaylistType playlistType = PlaylistType.All, OperatorType operatorType = OperatorType.Independent, DateTimeOffset? startDate = null, DateTimeOffset? endDate = null)
        {
            var request = new ModernStatsTrendRequest(account)
            {
                Playlist = playlistType,
                OperatorType = operatorType,
                TrendSpan = TrendSpan.Weekly
            };

            ValueUtils.ApplyValue(startDate, s => request.StartDate = s);
            ValueUtils.ApplyValue(endDate, e => request.EndDate = e);

            return client.PerformAsync<JObject>(request)
                         .ContinueWith(t => t.Result.ProcessData<IEnumerable<ModernStatsTrend>>(request), TaskContinuationOptions.OnlyOnRanToCompletion);
        }

        public static Task<ModernModeStatsContainer<WeaponSlot>> GetModernWeaponStatsAsync(this Dragon6Client client, UbisoftAccount account, PlaylistType playlistType = PlaylistType.All, OperatorType operatorType = OperatorType.Independent, DateTimeOffset? startDate = null, DateTimeOffset? endDate = null)
        {
            var request = new ModernWeaponStatsRequest(account)
            {
                Playlist = playlistType,
                OperatorType = operatorType
            };

            ValueUtils.ApplyValue(startDate, s => request.StartDate = s);
            ValueUtils.ApplyValue(endDate, e => request.EndDate = e);

            return client.PerformAsync<JObject>(request)
                         .ContinueWith(t => t.Result.ProcessData<WeaponSlot>(request), TaskContinuationOptions.OnlyOnRanToCompletion);
        }
    }
}
