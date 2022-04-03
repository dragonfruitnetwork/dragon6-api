// Dragon6 API Copyright DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Refer to the LICENSE file for more info

using System;
using DragonFruit.Six.Api.Seasonal.Entities;
using Newtonsoft.Json;

namespace DragonFruit.Six.Api.Legacy.Entities
{
    public class LegacyPlaylistStats : LegacyStatsBase
    {
        private TimeSpan? _timePlayed;

        [JsonProperty("matches")]
        public int MatchesPlayed { get; set; }

        [JsonProperty("time")]
        protected internal int Duration { get; set; }

        [JsonIgnore]
        public TimeSpan TimePlayed => _timePlayed ??= TimeSpan.FromSeconds(Duration);

        /// <summary>
        /// Applies the seasonal stats provided to the current <see cref="LegacyPlaylistStats"/>
        /// </summary>
        public void Include(SeasonalStats stats, bool includeAbandonsAsLosses = true)
        {
            Kills += stats.Kills;
            Deaths += stats.Deaths;
            Wins += stats.Wins;
            Losses += stats.Losses;

            if (includeAbandonsAsLosses)
            {
                Losses += stats.Abandons;
            }
        }
    }
}
