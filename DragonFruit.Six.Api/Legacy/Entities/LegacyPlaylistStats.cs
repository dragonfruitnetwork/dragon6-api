// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System;
using Newtonsoft.Json;

namespace DragonFruit.Six.Api.Legacy.Entities
{
    public class LegacyPlaylistStats : LegacyStatsBase
    {
        private TimeSpan? _timePlayed;

        [JsonProperty("matches")]
        public uint MatchesPlayed { get; set; }

        [JsonProperty("time")]
        protected internal uint Duration { get; set; }

        [JsonIgnore]
        public TimeSpan TimePlayed => _timePlayed ??= TimeSpan.FromSeconds(Duration);
    }
}
