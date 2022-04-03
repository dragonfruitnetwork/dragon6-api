// Dragon6 API Copyright DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Refer to the LICENSE file for more info

using System;
using DragonFruit.Six.Api.Utils;
using Newtonsoft.Json;

namespace DragonFruit.Six.Api.Legacy.Entities
{
    [Serializable]
    [JsonObject(MemberSerialization.OptIn)]
    public abstract class LegacyStatsBase
    {
        private float? _kd, _wl;

        [JsonProperty("kills")]
        public int Kills { get; set; }

        [JsonProperty("deaths")]
        public int Deaths { get; set; }

        [JsonProperty("wins")]
        public int Wins { get; set; }

        [JsonProperty("losses")]
        public int Losses { get; set; }

        public float Kd => _kd ??= RatioUtils.RatioOf(Kills, Deaths);
        public float Wl => _wl ??= RatioUtils.RatioOf(Wins, Losses);
    }
}
