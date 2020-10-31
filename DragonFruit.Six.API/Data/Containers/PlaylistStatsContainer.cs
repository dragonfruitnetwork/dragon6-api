// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System;
using Newtonsoft.Json;

namespace DragonFruit.Six.API.Data.Containers
{
    public class PlaylistStatsContainer : StatsBase
    {
        private TimeSpan? _timePlayed;

        [JsonProperty("matches")]
        public uint MatchesPlayed { get; set; }

        [JsonProperty("time")]
        internal uint Duration { get; set; }

        [JsonIgnore]
        public TimeSpan TimePlayed => _timePlayed ??= TimeSpan.FromSeconds(Duration);
    }
}
