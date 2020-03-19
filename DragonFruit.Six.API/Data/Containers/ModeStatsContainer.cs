// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System;
using Newtonsoft.Json;

namespace DragonFruit.Six.API.Data.Containers
{
    public class ModeStatsContainer
    {
        [JsonProperty("kills")]
        public uint Kills { get; set; }

        [JsonProperty("deaths")]
        public uint Deaths { get; set; }

        [JsonProperty("wins")]
        public uint Wins { get; set; }

        [JsonProperty("losses")]
        public uint Losses { get; set; }

        [JsonProperty("kd")]
        public float Kd { get; set; }

        [JsonProperty("wl")]
        public float Wl { get; set; }

        [JsonProperty("matches")]
        public uint MatchesPlayed { get; set; }

        [JsonProperty("time")]
        public TimeSpan TimePlayed { get; set; }
    }
}
