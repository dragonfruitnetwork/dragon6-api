// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System;
using DragonFruit.Six.API.Utils;
using Newtonsoft.Json;

namespace DragonFruit.Six.API.Data.Containers
{
    public class PlaylistStatsContainer
    {
        private float? _kd;
        private float? _wl;
        private TimeSpan? _timePlayed;

        [JsonProperty("kills")]
        public uint Kills { get; set; }

        [JsonProperty("deaths")]
        public uint Deaths { get; set; }

        [JsonProperty("wins")]
        public uint Wins { get; set; }

        [JsonProperty("losses")]
        public uint Losses { get; set; }

        [JsonProperty("matches")]
        public uint MatchesPlayed { get; set; }

        [JsonIgnore]
        internal uint Duration { get; set; }

        [JsonProperty("kd")]
        public float Kd => _kd ??= RatioUtils.RatioOf(Kills, Deaths);

        [JsonProperty("wl")]
        public float Wl => _wl ??= RatioUtils.RatioOf(Wins, Losses);

        [JsonProperty("time")]
        public TimeSpan TimePlayed => _timePlayed ??= TimeSpan.FromSeconds(Duration);
    }
}
